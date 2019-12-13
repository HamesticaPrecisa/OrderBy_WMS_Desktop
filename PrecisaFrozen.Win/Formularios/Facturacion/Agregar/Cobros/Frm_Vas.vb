Public Class Frm_Vas

    Dim fnc As New Funciones
    Dim tabla_detalle As DataTable = New DataTable
    Dim MODO_EDICION = False
    Dim MODO_ACTUALIZACION = False
    Public tipo_vas As Integer = 0

    Private Sub Frm_Vas_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If txtcodigo.Text <> "" AndAlso txtcodigo.Enabled = False Then
            If fnc.verificaExistencia("facvas", "vas_cod", CerosAnteriorString(txtcodigo.Text, 7)) = False Then

                If MsgBox("Esta seguro de salir sin guardar la información", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbNo Then
                    e.Cancel = True
                Else
                    CancelaCorrelativo("012", txtcodigo.Text)
                    f_addvas = False
                End If
            Else
                f_addvas = False
            End If

        Else
            f_addvas = False
        End If
    End Sub

    Private Sub Frm_Vas_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If tipo_vas = 1 Then
            Dgv_DetaVas.Visible = False

            tabla_detalle.Columns.Add("Dvas_ServCod")
            tabla_detalle.Columns.Add("serv_nom")
            tabla_detalle.Columns.Add("Dvas_Unid")
            tabla_detalle.Columns.Add("Dvas_ValUni")
            tabla_detalle.Columns.Add("Dvas_ValTot")
            tabla_detalle.Columns.Add("Dvas_Obs")
            tabla_detalle.Columns.Add("Dvas_entsal")

        Else
            tabla_detalle.Columns.Add("Dvas_ServCod")
            tabla_detalle.Columns.Add("serv_nom")
            tabla_detalle.Columns.Add("Dvas_Unid")
            tabla_detalle.Columns.Add("Dvas_Cajas")
            tabla_detalle.Columns.Add("Dvas_Kilos")
            tabla_detalle.Columns.Add("Dvas_Obs")
            tabla_detalle.Columns.Add("Dvas_entsal")
        End If

        CbTipoMov.DataSource = fnc.ListarTablasSQL("SELECT  tmov_codi, tmov_desc FROM P_TipoMovVas ORDER BY tmov_codi")
        CbTipoMov.DisplayMember = "tmov_desc"
        CbTipoMov.ValueMember = "tmov_codi"


    End Sub

    Private Sub txtcodigo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcodigo.KeyPress
        If e.KeyChar = ChrW(13) Then
            If txtcodigo.Text = "" Then
                txtcodigo.Text = BuscaCorrelativo("012")
                txtcodigo.Enabled = False
                GroupBox1.Enabled = True
                BtnBuscar.Enabled = False
                BtnAgregar.Enabled = True

                RbRecepcion.Enabled = True
                RbDespacho.Enabled = True
                RbRepaletizado.Enabled = True
                RbOtro.Enabled = True
                RbEtiquetado.Enabled = True
                GroupBox3.Enabled = True

            Else
                busca_vas(CerosAnteriorString(txtcodigo.Text, 7))
            End If
        Else
            SoloNumeros(sender, e)
        End If
    End Sub

    Private Sub Btn_Cliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cliente.Click
        Dim frm As New Lst_AyudaClientes
        frm.ShowDialog(Frm_Principal)

        If Frm_Principal.buscavalor = "" Then
            If txtrut.Text = "" Then
                Exit Sub
            Else
                Frm_Principal.buscavalor = txtrut.Text
            End If
            txtrut.Text = ""
            txtnombre.Text = ""
            txtrut.Focus()
        End If

        txtrut.Text = Frm_Principal.buscavalor
        txtnombre.Text = RetornaCliente(QuitarCaracteres(txtrut.Text))
        txtrut.Enabled = False
        Btn_Contrato.Enabled = True
        txtdesccont.Text = ""
        txtcodcont.Text = ""
        Frm_Principal.buscavalor = ""
        txtcodcont.Focus()
    End Sub

    Private Sub Btn_Contrato_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Contrato.Click
        Dim frm As New Lst_AyudaContratos
        frm.condicion = "WHERE  cont_rutclie='" + txtrut.Text + "'"
        frm.ShowDialog(Frm_Principal)
        txtcodcont.Text = Frm_Principal.buscavalor
        txtdesccont.Text = RetornaContrato(txtcodcont.Text)
        Frm_Principal.buscavalor = ""
        txtcodcont.Enabled = False
    End Sub

    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click

        If txtrut.Text = "" Or txtcodcont.Text = "" Then
            MsgBox("Debe seleccionar minimo un cliente y un contrato para agregar servicios", MsgBoxStyle.Critical, "Aviso")
            Exit Sub
        End If

        If tipo_vas = 0 Then

            btn_guardar.Enabled = True
            GroupBox4.Visible = True
            Btn_Cliente.Enabled = False
            Btn_Contrato.Enabled = False
            GroupBox5.Enabled = False
            GroupBox1.Enabled = False
            L1.Text = "UNIDADES"
            L2.Text = "CAJAS"
            L3.Text = "KILOS"
            Btn_BuscaServicio.Focus()
            bnd.Enabled = True

        ElseIf tipo_vas = 1 Then

            btn_guardar.Enabled = True
            GroupBox4.Visible = True
            Btn_Cliente.Enabled = False
            Btn_Contrato.Enabled = False
            GroupBox5.Enabled = False
            GroupBox1.Enabled = False
            Btn_BuscaServicio.Focus()
            L1.Text = "UNIDADES"
            L2.Text = "VALOR UNITARIO"
            L3.Text = "TOTAL"
            txtkilos.Enabled = False
            req3.Visible = False
        End If


    End Sub

    Private Sub Dgv_DetaVas_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv_DetaVas.CellClick
        If e.RowIndex > -1 AndAlso e.ColumnIndex = 0 Then
            If fnc.verificaExistencia("facvas", "vas_cod", txtcodigo.Text) = True Then
                If MODO_ACTUALIZACION = False Then
                    MsgBox("No puede eliminar la información", MsgBoxStyle.Critical, "Aviso")
                    Exit Sub
                End If
            End If
            If e.ColumnIndex = 0 Then
                If MsgBox("¿Seguro de eliminar el registro?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbYes Then
                    If fnc.verificaExistencia("facvas", "vas_cod", txtcodigo.Text) = True Then
                        Dim _DEL = "DELETE FROM facvasdeta WHERE Dvas_vascod='" + txtcodigo.Text + "' " +
                                   "AND dvas_servcod='" + Dgv_DetaVas.Rows(e.RowIndex).Cells("COD_SERV").Value.ToString() + "'"

                        Dim _log As String = "INSERT INTO LOG_VAS(LVAS_CODI, LVAS_FECHA, LVAS_HORA, LVAS_USUARIO, LVAS_PC, LVAS_OP) " +
                                             "VALUES('" + txtcodigo.Text + "','" + devuelve_fecha(fnc.DevuelveFechaServidor()) + "'," +
                                             "'" + DevuelveHora() + "','" + Frm_Principal.InfoUsuario.Text + "','" + My.Computer.Name + "'," +
                                             "'ELIMINO " + Dgv_DetaVas.Rows(e.RowIndex).Cells("COD_SERV").Value.ToString() + "')"
                        fnc.MovimientoSQL(_log)

                        If fnc.MovimientoSQL(_DEL) > 0 Then
                            MsgBox("Servicio eliminado", MsgBoxStyle.Information, "Aviso")
                        End If

                    End If
                    tabla_detalle.Rows.RemoveAt(e.RowIndex)
                    Dgv_DetaVas.DataSource = tabla_detalle
                End If
            End If
        End If
    End Sub

    Private Sub btn_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        If txtcodigo.Text <> "" Then
            If fnc.verificaExistencia("facvas", "vas_cod", txtcodigo.Text) = False AndAlso txtcodigo.Enabled = False Then
                If MsgBox("Seguro de salir del ingreso del vas", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbYes Then
                    CancelaCorrelativo("012", txtcodigo.Text)
                    limpiarformulario()
                Else
                    Exit Sub
                End If
            Else
                limpiarformulario()
            End If
        Else
            limpiarformulario()
        End If
    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        If validacion() = True Then
            If fnc.verificaExistencia("facvas", "vas_cod", txtcodigo.Text) = False Then
                If tipo_vas = 0 Then

                    If MsgBox("Seguro de finalizar el ingreso la información", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbNo Then
                        Exit Sub
                    End If

                    Dim sql As String = "INSERT INTO FacVas(Vas_cod, Vas_clirut, Vas_Cont, Vas_Dcto, Vas_Fecha, Vas_Guia, " +
                                                       "Vas_Estado, Vas_Seccion, Vas_TipDoc, Vas_Obs, Vas_emis, vas_usucod)" +
                                                       "VALUES('" + txtcodigo.Text + "','" + txtrut.Text + "','" + txtcodcont.Text + "','" + txtdcto.Text + "'," +
                                                       "'" + devuelve_fecha(dt_fecha.Value) + "','" + txtguia.Text + "','0','1'," +
                                                       "'" + retorna_asoc(99) + "','" + txtobs.Text + "'," +
                                                       "GETDATE(),'" + Frm_Principal.InfoUsuario.Text + "')"

                    If fnc.MovimientoSQL(sql) > 0 Then
                        MsgBox("Documento ingresado correctamente", MsgBoxStyle.Information, "Aviso")

                        For i As Integer = 0 To Dgv_DetaVas.Rows.Count - 1

                            Dim Sql_Detalle As String = "INSERT INTO FacVasDeta (Dvas_VasCod, Dvas_ServCod, Dvas_Unid, Dvas_Cajas, Dvas_Kilos, Dvas_Obs, Dvas_entsal) " +
                                "VALUES('" + txtcodigo.Text + "'," +
                                "'" + Dgv_DetaVas.Rows(i).Cells(1).Value.ToString() + "'," +
                                "'" + Dgv_DetaVas.Rows(i).Cells(3).Value.ToString() + "'," +
                                "'" + Dgv_DetaVas.Rows(i).Cells(4).Value.ToString() + "'," +
                                "'" + Dgv_DetaVas.Rows(i).Cells(5).Value.ToString() + "'," +
                                "'" + Dgv_DetaVas.Rows(i).Cells(6).Value.ToString() + "'," +
                                "'" + Dgv_DetaVas.Rows(i).Cells(7).Value.ToString() + "')"

                            fnc.MovimientoSQL(Sql_Detalle)

                        Next
                        BtnImprimir.Enabled = True
                        BtnAgregar.Enabled = False
                    Else
                        MsgBox("Error al ingresar Documento", MsgBoxStyle.Critical, "Aviso")
                    End If
                Else
                    If MsgBox("Seguro de finalizar el ingreso la información", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbNo Then
                        Exit Sub
                    End If

                    Dim sql As String = "INSERT INTO FacVas(Vas_cod, Vas_clirut, Vas_Cont, Vas_Dcto, Vas_Fecha, Vas_Guia, " +
                                                       "Vas_Estado, Vas_Seccion, Vas_TipDoc, Vas_Obs, Vas_emis, vas_usucod)" +
                                                       "VALUES('" + txtcodigo.Text + "','" + txtrut.Text + "','" + txtcodcont.Text + "','" + txtdcto.Text + "'," +
                                                       "'" + devuelve_fecha(dt_fecha.Value) + "','" + txtguia.Text + "','0','2'," +
                                                       "'" + retorna_asoc(99) + "','" + txtobs.Text + "'," +
                                                       "GETDATE(),'" + Frm_Principal.InfoUsuario.Text + "')"

                    If fnc.MovimientoSQL(sql) > 0 Then
                        MsgBox("Documento ingresado correctamente", MsgBoxStyle.Information, "Aviso")

                        For i As Integer = 0 To DgvDetaAdmin.Rows.Count - 1

                            Dim Sql_Detalle As String = "INSERT INTO FacVasDeta (Dvas_VasCod, Dvas_ServCod, Dvas_Unid, Dvas_valuni, Dvas_valtot, Dvas_Obs) " +
                                "VALUES('" + txtcodigo.Text + "'," +
                                "'" + DgvDetaAdmin.Rows(i).Cells(1).Value.ToString() + "'," +
                                "'" + DgvDetaAdmin.Rows(i).Cells(3).Value.ToString() + "'," +
                                "'" + DgvDetaAdmin.Rows(i).Cells(4).Value.ToString() + "'," +
                                "'" + DgvDetaAdmin.Rows(i).Cells(5).Value.ToString() + "'," +
                                "'" + DgvDetaAdmin.Rows(i).Cells(6).Value.ToString() + "')"

                            fnc.MovimientoSQL(Sql_Detalle)

                        Next

                        BtnImprimir.Enabled = True
                        BtnBuscar.Enabled = True
                        BtnAgregar.Enabled = False
                    Else
                        MsgBox("Error al ingresar documento", MsgBoxStyle.Critical, "Aviso")
                    End If

                End If

            Else
                'modificar
                Dim x = MODO_ACTUALIZACION
                Dim sql As String = "UPDATE facvas SET Vas_Cont='" + txtcodcont.Text + "', Vas_Dcto='" + txtdcto.Text + "', " +
                                    "Vas_Fecha='" + devuelve_fecha(dt_fecha.Value) + "', Vas_Guia='" + txtguia.Text + "', " +
                                    "Vas_TipDoc='" + retorna_asoc(99) + "', Vas_Obs='" + txtobs.Text + "' WHERE Vas_cod='" + txtcodigo.Text + "'"

                Dim _log As String = "INSERT INTO LOG_VAS(LVAS_CODI, LVAS_FECHA, LVAS_HORA, LVAS_USUARIO, LVAS_PC, LVAS_OP) " +
                    "VALUES('" + txtcodigo.Text + "','" + devuelve_fecha(fnc.DevuelveFechaServidor()) + "','" + DevuelveHora() + "','" + Frm_Principal.InfoUsuario.Text + "','" + My.Computer.Name + "','FICHA')"

                If fnc.MovimientoSQL(sql) > 0 Then
                    fnc.MovimientoSQL(_log)
                    MsgBox("Vas Actualizado Correctamente", MsgBoxStyle.Information, "Aviso")
                End If
            End If
        End If


    End Sub

    Private Sub Btn_BuscaServicio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_BuscaServicio.Click
        Dim f As New Frm_AyudaServicios
        f.bloq_estado = True
        f.tipo = tipo_vas
        f.ncontrato = txtcodcont.Text
        f.ShowDialog(Frm_Principal)

        If Frm_Principal.buscavalor.ToString() <> "" Then
            TxtCodServ.Text = Frm_Principal.buscavalor.ToString()

            'busca info del contrato
            Dim sql_info As String = "SELECT Serv_Nom, Dcon_Medida, med_descr, Dcon_valor, serv_entsal FROM ContratosDetalle " +
                "INNER JOIN FacServicios ON Dcon_ServCod=Serv_Cod INNER JOIN medidas ON med_codi=Dcon_Medida " +
                "WHERE Dcon_Codigo='" + txtcodcont.Text + "' AND Dcon_ServCod='" + TxtCodServ.Text + "'"
            Dim tabla As DataTable = fnc.ListarTablasSQL(sql_info)

            If tabla.Rows.Count > 0 Then
                TxtDescServ.Text = tabla.Rows(0)(0).ToString()
                tmed_cod.Text = tabla.Rows(0)(1).ToString()
                tmed_nom.Text = tabla.Rows(0)(2).ToString()

                If tabla.Rows(0)(4).ToString() = "1" Then
                    Label13.Visible = True
                    CbTipoMov.Visible = True
                Else
                    Label13.Visible = False
                    CbTipoMov.Visible = False
                    CbTipoMov.SelectedValue = 0
                End If

                If tipo_vas = 0 Then
                    If tabla.Rows(0)(1).ToString() = "001" Then
                        L1.Text = "SOPORTANTES"
                        L2.Text = "ENVASES"
                        L3.Text = "KILOS"
                    ElseIf tabla.Rows(0)(1).ToString() = "002" Then
                        L1.Text = "SOPORTANTES"
                        L2.Text = "ENVASES"
                        L3.Text = "KILOS"
                    ElseIf tabla.Rows(0)(1).ToString() = "003" Then
                        L1.Text = "SOPORTANTES"
                        L2.Text = "ENVASES"
                        L3.Text = "KILOS"
                    ElseIf tabla.Rows(0)(1).ToString() = "004" Then
                        L1.Text = "DIAS"
                        L2.Text = "HORAS"
                        L3.Text = "MINUTOS"
                    ElseIf tabla.Rows(0)(1).ToString() = "005" Then
                        L1.Text = "UNIDADES"
                        L2.Text = "----"
                        L3.Text = "----"
                    End If
                End If
            Else
                MsgBox("Error al capturar los registros del sistema, intentelo mas tarde", MsgBoxStyle.Critical, "Aviso")
                TxtCodServ.Text = ""
            End If
            txtunid.Focus()

        End If
    End Sub

    Private Sub txtunid_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtunid.KeyPress
        If e.KeyChar = ChrW(13) Then
            txtcaj.Focus()
        Else
            SoloNumeros(sender, e)
        End If
    End Sub

    Private Sub txtcaj_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcaj.KeyPress
        If e.KeyChar = ChrW(13) Then
            If txtcaj.Text = "" Then
                txtcaj.Text = "0"
            End If
            If tipo_vas = 0 Then
                txtkilos.Focus()
            Else
                Bgd.Focus()
            End If

        Else
            SoloNumeros(sender, e)
        End If
    End Sub

    Private Sub txtkilos_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtkilos.KeyPress
        If e.KeyChar = ChrW(13) Then
            If txtkilos.Text = "" Then
                txtkilos.Text = "0"
            End If
            Bgd.Focus()
        Else
            SoloKilos(sender, e)
        End If
    End Sub

    Private Sub Bgd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bgd.Click
        'seleccione servicio?

        'Validacion de objetos

        If tipo_vas = 1 Then
            If IsNumeric(txtunid.Text) Then
                If IsNumeric(txtcaj.Text) Then
                    txtkilos.Text = CType(txtcaj.Text, Integer) * CType(txtunid.Text, Integer)
                Else
                    MsgBox("Debe ingresar el valor unitario", MsgBoxStyle.Information, "Aviso")
                    Exit Sub
                End If
            Else
                MsgBox("Debe ingresar una cantidad", MsgBoxStyle.Information, "Aviso")
                Exit Sub
            End If
        Else
            If TxtCodServ.Text = "" Then
                MsgBox("Seleccione un servicio", MsgBoxStyle.Critical, "Aviso")
                Exit Sub
            Else
                If txtunid.Text = "" Then
                    txtunid.Text = "0"
                End If

                If txtcaj.Text = "" Then
                    txtcaj.Text = "0"
                End If

                If txtkilos.Text = "" Then
                    txtkilos.Text = "0"
                End If
                Try
                    If Convert.ToInt32(txtunid.Text) = "0" AndAlso Convert.ToInt32(txtcaj.Text) = "0" AndAlso Convert.ToDouble(txtkilos.Text) = "0" Then
                        MsgBox("No puede agregar un vas con valor 0", MsgBoxStyle.Critical, "Aviso")
                        Exit Sub
                    End If
                Catch ex As Exception
                    MsgBox("Error al ingresar el vas", MsgBoxStyle.Critical, "Aviso")
                    Exit Sub
                End Try
            End If
        End If

        'Consulto si es Administracion de pallets
        If TxtCodServ.Text = "018" Then
            'pregunto el stock de pallets que hay para no quedar en negativo

            Dim sql As String = "SELECT  CASE WHEN Dvas_entsal=0 THEN SUM(Dvas_Unid) ELSE 0 END, CASE WHEN Dvas_entsal=1 THEN SUM(Dvas_Unid) ELSE 0 END FROM GvwDetalleVas " +
                                "WHERE Dvas_ServCod = 018  AND Vas_fecha<='" + devuelve_fecha(dt_fecha.Value) + "' AND Vas_Cont='" + txtcodcont.Text + "' GROUP BY Dvas_entsal"


            Dim dt As DataTable = fnc.ListarTablasSQL(sql)

            Dim ent As Integer = 0
            Dim sal As Integer = 0
            Dim saldo As Integer = 0

            For i As Integer = 0 To dt.Rows.Count - 1
                ent = ent + dt.Rows(i)(0).ToString()
                sal = sal + dt.Rows(i)(1).ToString()
            Next

            saldo = ent - sal

            If (Convert.ToInt32(txtunid.Text) > saldo) Then
                MsgBox("El total a rebajar es mayor a la cantidad de pallets que existen (" + saldo.ToString() + ")", MsgBoxStyle.Critical, "Aviso")
                Exit Sub
            End If

        End If

        'verificar si puede guardar el servicio

        Dim verifica As Integer = 0

        If MODO_EDICION = False Then
            For i As Integer = 0 To Dgv_DetaVas.Rows.Count - 1
                If Dgv_DetaVas.Rows(i).Cells(1).Value.ToString() = TxtCodServ.Text Then
                    verifica += 1
                End If
            Next
        Else
            For i As Integer = 0 To tabla_detalle.Rows.Count - 1
                Try
                    Console.WriteLine(tabla_detalle.Columns.Count)
                    If tabla_detalle.Rows(i)(0).ToString() = TxtCodServ.Text Then
                        tabla_detalle.Rows(i)(2) = Convert.ToDouble(txtunid.Text.Replace(".", ","))
                        tabla_detalle.Rows(i)(3) = txtcaj.Text
                        tabla_detalle.Rows(i)(4) = Convert.ToDouble(txtkilos.Text.Replace(".", ","))
                        tabla_detalle.Rows(i)(5) = TxtDetaObs.Text
                        tabla_detalle.Rows(i)(6) = CbTipoMov.SelectedValue.ToString()
                    End If
                Catch ex As Exception
                    MsgBox("Error al actualizar el servicio", MsgBoxStyle.Critical, "Aviso")
                End Try

            Next
        End If

        If verifica > 0 Then
            MsgBox("El Servicio " + TxtDescServ.Text + " ya se encuentra en este VAS", MsgBoxStyle.Critical, "Aviso")
            Exit Sub
        Else
            If MODO_EDICION = False Then
                tabla_detalle.Rows.Add(TxtCodServ.Text, TxtDescServ.Text, txtunid.Text, txtcaj.Text, txtkilos.Text, TxtDetaObs.Text, CbTipoMov.SelectedValue.ToString())
                MsgBox("Servicio agregado correctamente", MsgBoxStyle.Information, "Aviso")
                bnd_Click(Nothing, Nothing)
                Btn_BuscaServicio.Focus()
            Else
                If fnc.verificaExistenciaCondicional("facvasdeta", " dvas_vascod='" + txtcodigo.Text + "' AND dvas_servcod='" + TxtCodServ.Text + "'") = True Then
                    If L3.Text = "TOTAL" Then
                        'Administrativo
                        Dim sql As String = "UPDATE Facvasdeta SET dvas_unid='" + txtunid.Text + "', dvas_valuni='" + txtcaj.Text + "', dvas_valtot='" + txtkilos.Text + "' WHERE Dvas_vascod='" + txtcodigo.Text + "' AND dvas_servcod='" + TxtCodServ.Text + "'"
                        If fnc.MovimientoSQL(sql) > 0 Then
                            MsgBox("Servicio modificado correctamente", MsgBoxStyle.Information, "Aviso")
                        End If

                    Else
                        'frigorifico
                        Dim sql As String = "UPDATE Facvasdeta SET dvas_unid='" + txtunid.Text + "', dvas_cajas='" + txtcaj.Text + "', " +
                            "dvas_kilos='" + txtkilos.Text + "', Dvas_entsal='" + CbTipoMov.SelectedValue.ToString() + "' WHERE Dvas_vascod='" + txtcodigo.Text + "' AND dvas_servcod='" + TxtCodServ.Text + "'"
                        If fnc.MovimientoSQL(sql) > 0 Then
                            MsgBox("Servicio modificado correctamente", MsgBoxStyle.Information, "Aviso")
                        End If

                    End If
                    GroupBox4.Visible = False
                    GroupBox5.Enabled = True
                    GroupBox1.Enabled = True
                    bnd_Click(sender, e)
                    MODO_EDICION = False
                    Btn_BuscaServicio.Enabled = True
                Else
                    MsgBox("Servicio modificado correctamente", MsgBoxStyle.Information, "Aviso")
                    GroupBox4.Visible = False
                    GroupBox5.Enabled = True
                    GroupBox1.Enabled = True
                    bnd_Click(sender, e)
                    MODO_EDICION = False
                    Btn_BuscaServicio.Enabled = True
                End If
            End If
            If tipo_vas = 0 Then
                Dgv_DetaVas.DataSource = tabla_detalle
            Else
                DgvDetaAdmin.DataSource = tabla_detalle
            End If
            'bnd.Focus()
        End If

    End Sub

    Private Sub bnd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bnd.Click
        TxtCodServ.Text = ""
        TxtDescServ.Text = ""
        tmed_cod.Text = ""
        tmed_nom.Text = ""
        'TxtValor.Text = ""
        txtunid.Text = ""
        txtcaj.Text = ""
        txtkilos.Text = ""
        Label13.Visible = False
        CbTipoMov.Visible = False
        CbTipoMov.SelectedValue = 0
        Btn_BuscaServicio.Focus()
        MODO_EDICION = False
    End Sub

    Private Sub bsd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bsd.Click
        GroupBox4.Visible = False
        GroupBox5.Enabled = True
        GroupBox1.Enabled = True
        bnd_Click(sender, e)
        MODO_EDICION = False
        Btn_BuscaServicio.Enabled = True
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim sql As String = "SELECT Dvas_ServCod, serv_nom, Dvas_Unid, Dvas_Cajas, Dvas_Kilos FROM FacVasDeta INNER JOIN facservicios ON serv_cod=dvas_servcod WHERE Dvas_VasCod='" + txtcodigo.Text + "'"
        Dgv_DetaVas.DataSource = fnc.ListarTablasSQL(sql)
    End Sub

    Private Sub Dgv_DetaVas_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv_DetaVas.CellDoubleClick
        If fnc.verificaExistencia("facvas", "vas_cod", txtcodigo.Text) = True Then
            If MODO_ACTUALIZACION = False Then
                MsgBox("No puede actualizar la información", MsgBoxStyle.Critical, "Aviso")
                Exit Sub
            End If
        End If

        If e.RowIndex > -1 Then
            MODO_EDICION = True
            Btn_BuscaServicio.Enabled = False
            GroupBox4.Visible = True
            Btn_Cliente.Enabled = False
            Btn_Contrato.Enabled = False
            GroupBox5.Enabled = False
            GroupBox1.Enabled = False
            bnd.Enabled = False
            TxtCodServ.Text = Dgv_DetaVas.Rows(e.RowIndex).Cells(1).Value.ToString()
            txtunid.Text = Dgv_DetaVas.Rows(e.RowIndex).Cells(3).Value.ToString()
            txtcaj.Text = Dgv_DetaVas.Rows(e.RowIndex).Cells(4).Value.ToString()
            txtkilos.Text = Dgv_DetaVas.Rows(e.RowIndex).Cells(5).Value.ToString()
            txtkilos.Enabled = True
            CbTipoMov.SelectedValue = Dgv_DetaVas.Rows(e.RowIndex).Cells(7).Value.ToString()

            Dim sql_info As String = "SELECT Serv_Nom, Dcon_Medida, med_descr, Dcon_valor, Serv_entsal FROM ContratosDetalle " +
                "INNER JOIN FacServicios ON Dcon_ServCod=Serv_Cod INNER JOIN medidas ON med_codi=Dcon_Medida " +
                "WHERE Dcon_Codigo='" + txtcodcont.Text + "' AND Dcon_ServCod='" + TxtCodServ.Text + "'"
            Dim tabla As DataTable = fnc.ListarTablasSQL(sql_info)

            If tabla.Rows.Count > 0 Then
                TxtDescServ.Text = tabla.Rows(0)(0).ToString()
                tmed_cod.Text = tabla.Rows(0)(1).ToString()
                tmed_nom.Text = tabla.Rows(0)(2).ToString()

                If tabla.Rows(0)(1).ToString() = "001" Then
                    L1.Text = "SOPORTANTES"
                    L2.Text = "ENVASES"
                    L3.Text = "KILOS"
                ElseIf tabla.Rows(0)(1).ToString() = "002" Then
                    L1.Text = "SOPORTANTES"
                    L2.Text = "ENVASES"
                    L3.Text = "KILOS"
                ElseIf tabla.Rows(0)(1).ToString() = "003" Then
                    L1.Text = "SOPORTANTES"
                    L2.Text = "ENVASES"
                    L3.Text = "KILOS"
                ElseIf tabla.Rows(0)(1).ToString() = "004" Then
                    L1.Text = "DIAS"
                    L2.Text = "HORAS"
                    L3.Text = "MINUTOS"
                ElseIf tabla.Rows(0)(1).ToString() = "005" Then
                    L1.Text = "UNIDADES"
                    L2.Text = "----"
                    L3.Text = "----"
                End If
                If tabla.Rows(0)(4).ToString() = "1" Then
                    CbTipoMov.Visible = True
                    Label13.Visible = True
                End If
            End If
            txtunid.Focus()
        End If

    End Sub

    Function validacion() As Boolean
        Dim MENSAJE As String = ""
        If RbRecepcion.Checked = False AndAlso RbDespacho.Checked = False AndAlso RbEtiquetado.Checked = False AndAlso RbRepaletizado.Checked = False AndAlso RbOtro.Checked = False Then
            MENSAJE = "- Debe seleccionar un documento asociado" + vbCrLf
            validacion = False
        End If

        If tipo_vas = 0 Then
            If txtguia.Text = "" AndAlso txtdcto.Text = "" Then
                MENSAJE = "- Debe agregar un numero de documento asociado" + vbCrLf
                validacion = False
            End If

            If Dgv_DetaVas.Rows.Count = 0 Then
                MENSAJE = "- Debe agregar un detalle al documento" + vbCrLf
                validacion = False
            Else
                validacion = True
            End If
        ElseIf RbRecepcion.Checked = False AndAlso RbDespacho.Checked = False AndAlso RbEtiquetado.Checked = False AndAlso RbRepaletizado.Checked = False AndAlso RbOtro.Checked = False Then
            MENSAJE = "- Debe seleccionar el tipo de documento" + vbCrLf
            validacion = False
        Else
            If DgvDetaAdmin.Rows.Count = 0 Then
                MENSAJE = "- Debe agregar un detalle al documento" + vbCrLf
                validacion = False
            Else
                validacion = True
            End If


        End If

        

        If validacion = False Then
            MsgBox("Información faltante" + vbCrLf + MENSAJE, MsgBoxStyle.Critical, "Aviso")
        End If

        Return validacion
    End Function

    Sub limpiarformulario()
        txtcodigo.Text = ""
        txtcodigo.Enabled = False
        txtrut.Text = ""
        txtnombre.Text = ""
        txtcodcont.Text = ""
        txtdesccont.Text = ""

        RbRecepcion.Checked = False
        RbDespacho.Checked = False
        RbEtiquetado.Checked = False
        RbRepaletizado.Checked = False
        RbOtro.Checked = False
        LblEstado.Text = "ACTIVO"
        LblEstado.ForeColor = Color.Blue
        txtdcto.Text = ""
        txtguia.Text = ""
        GroupBox1.Enabled = False
        txtcodigo.Enabled = True
        Btn_Cliente.Enabled = True
        Btn_Contrato.Enabled = False
        BtnBuscar.Enabled = True
        dt_fecha.Value = fnc.DevuelveFechaServidor()
        BLOQ_DESBLOQ(1)
        For i As Integer = 0 To tabla_detalle.Rows.Count - 1
            tabla_detalle.Rows.RemoveAt(0)
        Next

        For i As Integer = 0 To Dgv_DetaVas.Rows.Count - 1
            Dgv_DetaVas.Rows.RemoveAt(0)
        Next

        For i As Integer = 0 To DgvDetaAdmin.Rows.Count - 1
            DgvDetaAdmin.Rows.RemoveAt(0)
        Next
        txtcodigo.Focus()
        Dgv_DetaVas.Enabled = True
        btn_guardar.Enabled = False
        BtnImprimir.Enabled = False
        BtnAnulaGuia.Enabled = False
    End Sub

    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        Dim F As New Frm_ListadoVas
        F.tipo = tipo_vas
        F.ShowDialog(Frm_Principal)
        If Frm_Principal.buscavalor.ToString() <> "" Then
            busca_vas(Frm_Principal.buscavalor.ToString())
        End If
    End Sub

    Sub busca_vas(ByVal codigo As String)

        Dim sql As String = "SELECT Vas_Clirut, cli_nomb, Vas_Cont, cont_descr, Vas_Dcto, Vas_guia, Vas_fecha, Vas_Estado, Sec_Desc, Vas_TipDoc, Vas_Obs " +
                            "FROM facvas INNER JOIN clientes ON cli_rut=Vas_Clirut INNER JOIN contrato ON cont_codi=Vas_Cont INNER JOIN FacSeccion ON Sec_codi=Vas_seccion " +
                            "WHERE Vas_cod='" + codigo + "'"

        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

        If tabla.Rows.Count > 0 Then
            MODO_ACTUALIZACION = False
            txtcodigo.Text = codigo
            txtcodigo.Enabled = False
            txtrut.Text = tabla.Rows(0)(0).ToString()
            txtnombre.Text = tabla.Rows(0)(1).ToString()
            txtcodcont.Text = tabla.Rows(0)(2).ToString()
            txtdesccont.Text = tabla.Rows(0)(3).ToString()
            txtdcto.Text = tabla.Rows(0)(4).ToString()
            txtguia.Text = tabla.Rows(0)(5).ToString()
            dt_fecha.Value = tabla.Rows(0)(6).ToString()

            If tabla.Rows(0)(7).ToString() = "0" Then
                LblEstado.Text = "ACTIVO"
                LblEstado.ForeColor = Color.Blue
            ElseIf tabla.Rows(0)(7).ToString() = "1" Then
                LblEstado.Text = "NULO"
                LblEstado.ForeColor = Color.Red
            End If

            TxtSeccion.Text = tabla.Rows(0)(8).ToString()

            If TxtSeccion.Text = "FRIGORIFICO (AUTO)" Then
                BLOQ_DESBLOQ()
            End If

            retorna_asoc(tabla.Rows(0)(9).ToString())
            txtobs.Text = tabla.Rows(0)(10).ToString()
            If tipo_vas = 0 Then
                Dgv_DetaVas.DataSource = fnc.ListarTablasSQL("SELECT Dvas_ServCod, Serv_Nom, Dvas_Unid, Dvas_Cajas, Dvas_Kilos, Dvas_Obs, isnull(Dvas_entsal,0) Dvas_entsal FROM FacVasDeta INNER JOIN FacServicios ON Dvas_ServCod=Serv_Cod WHERE Dvas_VasCod='" + codigo + "'")
                tabla_detalle = Dgv_DetaVas.DataSource
            Else
                DgvDetaAdmin.DataSource = fnc.ListarTablasSQL("SELECT Dvas_ServCod, Serv_Nom, Dvas_Unid, Dvas_ValUni, Dvas_ValTot, Dvas_Obs, isnull(Dvas_entsal,0) Dvas_entsal FROM FacVasDeta INNER JOIN FacServicios ON Dvas_ServCod=Serv_Cod WHERE Dvas_VasCod='" + codigo + "'")
                tabla_detalle = DgvDetaAdmin.DataSource
            End If

            GroupBox1.Enabled = True
            BtnBuscar.Enabled = True
            Btn_Cliente.Enabled = False
            BtnAgregar.Enabled = False
            GroupBox3.Enabled = False
            BtnAnulaGuia.Enabled = True
            BtnImprimir.Enabled = True
        Else
            MsgBox("El codigo ingresado no existe", MsgBoxStyle.Critical, "Aviso")
        End If

    End Sub

    Function retorna_asoc(ByVal opcion As Integer) As String
        retorna_asoc = opcion.ToString()

        If opcion = 99 Then
            If RbRecepcion.Checked = True Then
                retorna_asoc = "0"
            ElseIf RbDespacho.Checked = True Then
                retorna_asoc = "1"
            ElseIf RbEtiquetado.Checked = True Then
                retorna_asoc = "2"
            ElseIf RbRepaletizado.Checked = True Then
                retorna_asoc = "3"
            ElseIf RbOtro.Checked = True Then
                retorna_asoc = "4"
            End If
        Else
            If retorna_asoc = "0" Then
                RbRecepcion.Checked = True
            ElseIf retorna_asoc = "1" Then
                RbDespacho.Checked = True
            ElseIf retorna_asoc = "2" Then
                RbEtiquetado.Checked = True
            ElseIf retorna_asoc = "3" Then
                RbRepaletizado.Checked = True
            ElseIf retorna_asoc = "4" Then
                RbOtro.Checked = True
            End If
        End If

    End Function

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Close()
    End Sub

    Sub BLOQ_DESBLOQ(Optional ByVal op = 0)

        If op = 0 Then
            RbRecepcion.Enabled = False
            RbDespacho.Enabled = False
            RbEtiquetado.Enabled = False
            RbRepaletizado.Enabled = False
            RbOtro.Enabled = False
        Else
            RbRecepcion.Enabled = True
            RbDespacho.Enabled = True
            RbEtiquetado.Enabled = True
            RbRepaletizado.Enabled = True
            RbOtro.Enabled = True
        End If

    End Sub

    Private Sub txtcaj_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtcaj.KeyUp
        If tipo_vas = 1 Then
            If IsNumeric(txtunid.Text) Then
                If IsNumeric(txtcaj.Text) Then
                    txtkilos.Text = CType(txtcaj.Text, Integer) * CType(txtunid.Text, Integer)
                End If
            End If
        End If
    End Sub

    Private Sub txtunid_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtunid.KeyUp
        If tipo_vas = 1 Then
            If IsNumeric(txtunid.Text) Then
                If IsNumeric(txtcaj.Text) Then
                    txtkilos.Text = CType(txtcaj.Text, Integer) * CType(txtunid.Text, Integer)
                End If
            End If
        End If
    End Sub

    Private Sub Frm_Vas_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F2 Then
            If LblEstado.Text = "NULO" Then
                MsgBox("No puede modificar el contenido de un vas no vigente", MsgBoxStyle.Critical, "Aviso")
                Exit Sub
            End If

            If TxtSeccion.Text = "FRIGORIFICO (AUTO)" Then
                MsgBox("Para modificar este vas debe ir a la recepcion o despacho asociado", MsgBoxStyle.Critical, "Aviso")
                Exit Sub
            End If
            If RealizarAccion("023", "070", False) = True Or RealizarAccion("023", "071", False) = True Then
                If MsgBox("Desea habilitar modificacion del documento", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbYes Then
                    'HAB. MODIF. ADMIN
                    If RealizarAccion("023", "071", False) = True Then
                        'Modificacion Modo Administrativo
                        habilita_mod()
                        Exit Sub
                    Else
                        MsgBox("No tiene permisos para modificar este documento", MsgBoxStyle.Critical, "Aviso")
                        Exit Sub
                    End If

                    'If RealizarAccion("023", "070", False) = True Then
                    '    'Validar si ya pasaron los 3 dias desde la emision
                    '    Dim sql As String = "SELECT Vas_Emis FROM FacVas WHERE Vas_cod='" + txtcodigo.Text + "'"
                    '    Dim tabla As DataTable = fnc.ListarTablasSQL(sql)
                    '    If tabla.Rows.Count > 0 Then
                    '        If fnc.DevuelveFechaServidor() <= Convert.ToDateTime(tabla.Rows(0)(0).ToString()).AddDays(3) Then
                    '            'Modificacion Modo Usuario 3 dias desde la emision....
                    '            habilita_mod()
                    '        Else
                    '            MsgBox("No tiene permisos para modificar este documento", MsgBoxStyle.Critical, "Aviso")
                    '            Exit Sub
                    '        End If
                    '    End If
                    'End If

                End If
            Else
                MsgBox("No tiene permisos para modificar este documento", MsgBoxStyle.Critical, "Aviso")
            End If
        End If
    End Sub

    Public Sub habilita_mod()
        Btn_Cliente.Enabled = True
        Btn_Contrato.Enabled = True
        btn_guardar.Enabled = True
        If tipo_vas = 0 Then
            Dgv_DetaVas.Enabled = True
        Else
            DgvDetaAdmin.Enabled = True
        End If
        GroupBox3.Enabled = True
        RbRecepcion.Enabled = True
        RbDespacho.Enabled = True
        RbEtiquetado.Enabled = True
        RbRepaletizado.Enabled = True
        RbOtro.Enabled = True
        MODO_ACTUALIZACION = True
        BtnAgregar.Enabled = False
    End Sub

    Private Sub DgvDetaAdmin_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvDetaAdmin.CellClick
        If e.RowIndex > -1 AndAlso e.ColumnIndex = 0 Then
            If fnc.verificaExistencia("facvas", "vas_cod", txtcodigo.Text) = True Then
                If MODO_ACTUALIZACION = False Then
                    MsgBox("No puede eliminar la información", MsgBoxStyle.Critical, "Aviso")
                    Exit Sub
                End If
            End If
            If e.ColumnIndex = 0 Then
                If MsgBox("¿Seguro de eliminar el registro?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbYes Then
                    If fnc.verificaExistencia("facvas", "vas_cod", txtcodigo.Text) = True Then
                        Dim _DEL = "DELETE FROM facvasdeta WHERE Dvas_vascod='" + txtcodigo.Text + "' " +
                                   "AND dvas_servcod='" + DgvDetaAdmin.Rows(e.RowIndex).Cells("Codserv").Value.ToString() + "'"
                        If fnc.MovimientoSQL(_DEL) > 0 Then
                            MsgBox("Servicio eliminado", MsgBoxStyle.Information, "Aviso")
                        End If

                    End If
                    tabla_detalle.Rows.RemoveAt(e.RowIndex)
                    DgvDetaAdmin.DataSource = tabla_detalle
                End If
            End If
        End If
    End Sub

    Private Sub DgvDetaAdmin_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvDetaAdmin.CellDoubleClick
        If fnc.verificaExistencia("facvas", "vas_cod", txtcodigo.Text) = True Then
            If MODO_ACTUALIZACION = False Then
                MsgBox("No puede actualizar la información", MsgBoxStyle.Critical, "Aviso")
                Exit Sub
            End If
        End If

        If e.RowIndex > -1 Then
            MODO_EDICION = True
            Btn_BuscaServicio.Enabled = False
            GroupBox4.Visible = True
            Btn_Cliente.Enabled = False
            Btn_Contrato.Enabled = False
            GroupBox5.Enabled = False
            GroupBox1.Enabled = False
            bnd.Enabled = False
            TxtCodServ.Text = DgvDetaAdmin.Rows(e.RowIndex).Cells(1).Value.ToString()
            txtunid.Text = DgvDetaAdmin.Rows(e.RowIndex).Cells(3).Value.ToString()
            txtcaj.Text = DgvDetaAdmin.Rows(e.RowIndex).Cells(4).Value.ToString()
            txtkilos.Text = DgvDetaAdmin.Rows(e.RowIndex).Cells(5).Value.ToString()
            txtkilos.Enabled = False
            Dim sql_info As String = "SELECT Serv_Nom, Dcon_Medida, med_descr, Dcon_valor FROM ContratosDetalle " +
                "INNER JOIN FacServicios ON Dcon_ServCod=Serv_Cod INNER JOIN medidas ON med_codi=Dcon_Medida " +
                "WHERE Dcon_Codigo='" + txtcodcont.Text + "' AND Dcon_ServCod='" + TxtCodServ.Text + "'"
            Dim tabla As DataTable = fnc.ListarTablasSQL(sql_info)

            If tabla.Rows.Count > 0 Then
                TxtDescServ.Text = tabla.Rows(0)(0).ToString()
                tmed_cod.Text = tabla.Rows(0)(1).ToString()
                tmed_nom.Text = tabla.Rows(0)(2).ToString()
                L1.Text = "UNIDADES"
                L2.Text = "VALOR UNITARIO"
                L3.Text = "TOTAL"
            End If




            txtunid.Focus()
        End If
    End Sub

    Private Sub Btn_AnulaGuia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAnulaGuia.Click
        If RealizarAccion("023", "077", False) = False Then
            MsgBox("No tiene permisos para realizar esta acción", MsgBoxStyle.Critical, "Error")
            Exit Sub
        Else
            If MsgBox("Seguro de Anular el documento", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Aviso") = vbYes Then

                Dim sql As String = "UPDATE facvas SET vas_estado='1' WHERE vas_cod='" + txtcodigo.Text + "'"
                If fnc.MovimientoSQL(sql) > 0 Then
                    Dim _log As String = "INSERT INTO LOG_VAS(LVAS_CODI, LVAS_FECHA, LVAS_HORA, LVAS_USUARIO, LVAS_PC, LVAS_OP) " +
                                                     "VALUES('" + txtcodigo.Text + "','" + devuelve_fecha(fnc.DevuelveFechaServidor()) + "'," +
                                                     "'" + DevuelveHora() + "','" + Frm_Principal.InfoUsuario.Text + "','" + My.Computer.Name + "'," +
                                                     "'ANULACION')"
                    fnc.MovimientoSQL(_log)
                    MsgBox("Documento anulado", MsgBoxStyle.Information, "Aviso")
                    busca_vas(txtcodigo.Text)
                Else
                    MsgBox("Error al intentar eliminar el documento", MsgBoxStyle.Critical, "Error")
                End If
            End If
        End If
    End Sub

    Private Sub BtnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImprimir.Click
        If tipo_vas = 0 Then

            Dim frm As Frm_MuestraReporte = New Frm_MuestraReporte
            frm.Text = "Asistente de informes - Cobro vas frigorífico"

            Dim report As New Rpt_EmisionVAS

            report.SetDatabaseLogon(Usuario_ODBC, Pass_ODBC)
            report.SetParameterValue("codigo", txtcodigo.Text)

            frm.Contenedor.ReportSource = report
            frm.ShowDialog()

        Else
            Dim frm As Frm_MuestraReporte = New Frm_MuestraReporte
            frm.Text = "Asistente de informes - Cobro vas administrativos"

            Dim report As New Rpt_EmisionVasAdmin

            report.SetDatabaseLogon(Usuario_ODBC, Pass_ODBC)
            report.SetParameterValue("codigo", txtcodigo.Text)

            frm.Contenedor.ReportSource = report
            frm.ShowDialog()
        End If
    End Sub
End Class
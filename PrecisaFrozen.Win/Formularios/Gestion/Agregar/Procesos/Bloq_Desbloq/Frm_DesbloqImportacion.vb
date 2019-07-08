Public Class Frm_DesbloqImportacion

    Dim fnc As New Funciones


    Private Sub btn_BuscaCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_BuscaCliente.Click

        Dim frm As New Lst_AyudaClientes
        frm.ShowDialog(Frm_Principal)
        Dim RUT As String = Frm_Principal.buscavalor

        If RUT.ToString.Length > 0 Then

            If Len(RUT) >= 9 Then
                TxtClirut.Text = RUT
                txtclinom.Text = RetornaCliente(RUT)
                Btn_BuscaContrato.Enabled = True
                txtcodcontrato.Text = ""
                txtcontnom.Text = ""
                TxtClirut.Enabled = False

            Else
                MsgBox("El rut ingresado no existe", MsgBoxStyle.Information, "Aviso")
            End If
        End If

    End Sub

    Private Sub Btn_BuscaContrato_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_BuscaContrato.Click
        Dim frm As New Lst_AyudaContratos
        frm.condicion = "WHERE  cont_rutclie='" + QuitarCaracteres(TxtClirut.Text) + "'"
        frm.ShowDialog(Frm_Principal)

        Dim cod_cont As String = Frm_Principal.buscavalor

        If cod_cont.Length > 0 Then
            txtcodcontrato.Enabled = False
            txtcodcontrato.Text = cod_cont.ToString()
            txtcontnom.Text = RetornaContrato(cod_cont)
        End If


    End Sub

    Private Sub BtnContenedores_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnContenedores.Click
        If fnc.verificaExistencia("clientes", "cli_rut", TxtClirut.Text) = False Or fnc.verificaExistencia("contrato", "cont_codi", txtcodcontrato.Text) = False Then
            MsgBox("Debe seleccionar un cliente y un contrato valido", MsgBoxStyle.Information, "Aviso")
            Exit Sub
        End If

        Dim f As New Frm_AyudaContenedores
        f.contrato = txtcodcontrato.Text
        f.ShowDialog(Frm_Principal)
        Txtrece.Text = Frm_Principal.buscavalor.ToString()
        Dim sql As String = "SELECT frec_contenedor FROM fichrece WHERE frec_codi='" + Txtrece.Text + "'"
        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

        If tabla.Rows.Count > 0 Then
            txtcont.Text = tabla.Rows(0)(0).ToString()
            txtcont.Enabled = False
            RetornaDetallePallets(Frm_Principal.buscavalor.ToString())
        End If

    End Sub

    Private Sub TxtClirut_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtClirut.KeyPress
        If e.KeyChar = ChrW(13) Then
            If TxtClirut.Text.Length >= 9 Then
                txtclinom.Text = RetornaCliente(TxtClirut.Text)
                Btn_BuscaContrato.Enabled = True
                TxtClirut.Enabled = False
                GroupBox1.Enabled = True
                BtnImprimir.Enabled = False
            Else
                MsgBox("El rut ingresado no existe", MsgBoxStyle.Critical, "Aviso")
            End If
        End If
    End Sub

    Private Sub txtcodcontrato_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcodcontrato.KeyPress
        If e.KeyChar = ChrW(13) Then
            Dim sql As String = "SELECT cont_descr, cont_tempcon, cont_tempgra, Hor_SRI, Hor_SRT, Hor_FRI, Hor_FRT FROM contrato, contratosHorarios " +
                "WHERE cont_codi=Hor_Contcod AND cont_rutclie='" + TxtClirut.Text + "' AND cont_codi='" + CerosAnteriorString(txtcodcontrato.Text, 7) + "'"
            Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

            If tabla.Rows.Count > 0 Then
                txtcodcontrato.Enabled = False
                txtcodcontrato.Text = CerosAnteriorString(txtcodcontrato.Text, 7)
                txtcontnom.Text = tabla.Rows(0)(0).ToString()
            Else
                MsgBox("El numero ingresado no existe o no corresponde a este cliente", MsgBoxStyle.Critical, "Aviso")
            End If
        End If
    End Sub

    Private Sub Txtobs_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Txtobs.Lines.Count > 3 Then
            If Asc(e.KeyChar) <> "8" Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtfolio_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtfolio.KeyPress
        If e.KeyChar = ChrW(13) Then
            If txtfolio.Text = "" Then
                If RealizarAccion("020", "054", True) = False Then
                    Exit Sub
                End If
                txtfolio.Text = BuscaCorrelativo("013", 4)
                txtfolio.Enabled = False
                GroupBox1.Enabled = True
                Gb_Cliente.Enabled = True
                btn_guardar.Enabled = True
                BtnBuscar.Enabled = False
            Else
                RescataProceso(CerosAnteriorString(txtfolio.Text, 4))
            End If
        Else
            SoloNumeros(sender, e)
        End If


    End Sub

    Private Sub Frm_DesbloqImportacion_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If txtfolio.Text <> "" AndAlso txtfolio.Enabled = False Then
            If fnc.verificaExistencia("Proc_Importaciones", "pimp_codi", txtfolio.Text) = False Then
                If MsgBox("Esta seguro de salir sin guardar la información", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbNo Then
                    e.Cancel = True
                Else
                    CancelaCorrelativo("013", txtfolio.Text)
                    f_procdesbloq = False
                End If
            Else
                f_procdesbloq = False
        End If
        Else
            f_procdesbloq = False
        End If
    End Sub

    Private Sub btn_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        If txtfolio.Text <> "" Then
            If fnc.verificaExistencia("Proc_Importaciones", "pimp_codi", txtfolio.Text) = False Then
                If txtfolio.Enabled = False Then
                    If MsgBox("Desea salir del ingreso", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbYes Then
                        CancelaCorrelativo("013", txtfolio.Text)
                        limpiarFormulario()
                    End If
                Else
                    limpiarFormulario()
                End If
            Else
                limpiarFormulario()
            End If
        Else
            txtfolio.Focus()
        End If
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Sub RescataProceso(ByVal codigo_proceso As String)
        Dim sql As String = "SELECT cli_rut, cli_nomb, pimp_fecha, pimp_totsopo, pimp_totunid, pimp_totpeso, usu_nombre+' '+usu_ap as usuario, frec_codi, frec_contenedor, pimp_reso, cont_codi, cont_descr " +
            "FROM proc_importaciones, clientes, usuarios, fichrece, contrato  WHERE pimp_rutcli=cli_rut AND pimp_usucod=usu_codigo AND frec_codi=pimp_codrece AND cont_codi=frec_contcli AND pimp_codi='" + codigo_proceso + "'"


        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

        If tabla.Rows.Count > 0 Then
            txtfolio.Enabled = False
            txtfolio.Text = codigo_proceso.ToString()
            TxtClirut.Text = tabla.Rows(0)(0).ToString()
            txtclinom.Text = tabla.Rows(0)(1).ToString()
            dtfecha.Value = tabla.Rows(0)(2).ToString()
            txtsoportantes.Text = tabla.Rows(0)(3).ToString()
            txtcajas.Text = tabla.Rows(0)(4).ToString()
            txtkilos.Text = tabla.Rows(0)(5).ToString()
            Txtresp.Text = tabla.Rows(0)(6).ToString()
            Txtrece.Text = tabla.Rows(0)(7).ToString()
            txtcont.Text = tabla.Rows(0)(8).ToString()
            txtreso.Text = tabla.Rows(0)(9).ToString()
            txtcodcontrato.Text = tabla.Rows(0)(10).ToString()
            txtcontnom.Text = tabla.Rows(0)(11).ToString()

            RetornaDetallePallets(tabla.Rows(0)(7).ToString())
        Else
            MsgBox("El codigo ingresado no existe", MsgBoxStyle.Critical, "Aviso")
        End If
    End Sub

    Sub limpiarFormulario()

        txtfolio.Text = ""
        txtfolio.Enabled = True

        TxtClirut.Text = ""
        TxtClirut.Enabled = True
        txtclinom.Text = ""

        txtcodcontrato.Text = ""
        txtcontnom.Text = ""
        txtcodcontrato.Enabled = True

        txtcont.Text = ""
        txtcont.Enabled = True

        btn_BuscaCliente.Enabled = True
        Btn_BuscaContrato.Enabled = True
        BtnContenedores.Enabled = True

        txtreso.Text = ""
        Txtrece.Text = ""

        For i As Integer = 0 To DgvDetalle.Rows.Count - 1
            DgvDetalle.Rows.RemoveAt(0)
        Next

        txtsoportantes.Text = "0"
        txtcajas.Text = "0"
        txtkilos.Text = "0"
        Txtobs.Text = ""
        Gb_Cliente.Enabled = False
        BtnBuscar.Enabled = True
        txtfolio.Focus()
    End Sub

    Sub RetornaDetallePallets(ByVal recepcion As String)
        Dim sql As String = "SELECT drec_codi, drec_sopocli, drec_unidades, drec_peso, drec_fecprod, FechaVencimiento " +
            "FROM detarece WHERE frec_codi1='" + recepcion + "' ORDER BY drec_codi "

        DgvDetalle.DataSource = fnc.ListarTablasSQL(sql)

        If fnc.ListarTablasSQL(sql).Rows.Count > 0 Then
            btn_BuscaCliente.Enabled = False
            Btn_BuscaContrato.Enabled = False
            BtnContenedores.Enabled = False
            BtnBuscar.Enabled = True
            btn_guardar.Enabled = True
        End If

        suma_totales()
    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        If validaciones() = True Then
            If fnc.verificaExistencia("Proc_Importaciones", "pimp_codi", txtfolio.Text) = True Then

                Dim sql As String = "UPDATE Proc_Importaciones SET  pimp_ncont='" + txtcont.Text + "', pimp_reso='" + txtreso.Text + "' WHERE pimp_codi='" + txtfolio.Text + "'"

                If fnc.MovimientoSQL(sql) > 0 Then
                    MsgBox("Información actualizada correctamente", MsgBoxStyle.Information, "Aviso")
                Else
                    MsgBox("Error al actualizar la información", MsgBoxStyle.Critical, "Aviso")
                End If
            Else
                Dim sql As String = "INSERT INTO Proc_Importaciones (pimp_codi, pimp_rutcli, pimp_contcli, pimp_ncont, pimp_codrece, " +
                               "pimp_reso, pimp_totsopo, pimp_totunid, pimp_totpeso, pimp_obs, pimp_fecha, pimp_hora, pimp_usucod)" +
                               "VALUES('" + txtfolio.Text + "','" + TxtClirut.Text + "','" + txtcodcontrato.Text + "','" + txtcont.Text + "'," +
                               "'" + Txtrece.Text + "','" + txtreso.Text + "','" + txtsoportantes.Text + "','" + txtcajas.Text + "'," +
                               "'" + txtkilos.Text.Replace(",", ".") + "','" + Txtobs.Text.Trim + "','" + devuelve_fecha(dtfecha.Value) + "'," +
                               "'" + DevuelveHora() + "','" + Frm_Principal.InfoUsuario.Text + "')"

                If fnc.MovimientoSQL(sql) > 0 Then
                    MsgBox("Información guardada correctamente", MsgBoxStyle.Information, "Aviso")

                    Dim sql_racd As String = "UPDATE Rackdeta SET racd_estado='0', Lotecliente='" + txtreso.Text + "' WHERE racd_codi LIKE '%" + Txtrece.Text + "__%'"
                    ' Dim sql_detarec As String = "UPDATE detarece SET lotecliente='" + txtreso.Text + "' WHERE drec_codi LIKE '%" + Txtrece.Text + "__%'"

                    If fnc.MovimientoSQL(sql_racd) > 0 Then
                        MsgBox("Pallets desbloqueados del sistema", MsgBoxStyle.Information, "Aviso")
                        ' fnc.MovimientoSQL(sql_detarec)
                    Else
                        MsgBox("Error al desbloquear los pallets del sistema", MsgBoxStyle.Critical, "Aviso")
                    End If
                Else
                    MsgBox("Error al guardar la información", MsgBoxStyle.Critical, "Aviso")
                End If
            End If
        End If
    End Sub

    Function validaciones() As Boolean
        validaciones = True

        If txtreso.Text.Trim = "" Then
            validaciones = False
            MsgBox("Falta ingresar resolucion", MsgBoxStyle.Information, "Aviso")
        End If
        If Txtrece.Text.Trim = "" Then
            validaciones = False
            MsgBox("Falta ingresar recepcion", MsgBoxStyle.Information, "Aviso")
        End If
        Return validaciones
    End Function

    Sub suma_totales()

        Dim sum_unid As Integer = 0
        Dim sum_peso As Integer = 0

        For Each s As DataGridViewRow In DgvDetalle.Rows

            sum_unid = sum_unid + Val(s.Cells(2).Value)
            sum_peso = sum_peso + Val(s.Cells(3).Value)
        Next

        txtsoportantes.Text = DgvDetalle.Rows.Count - 1
        txtcajas.Text = sum_unid.ToString()
        txtkilos.Text = sum_peso.ToString()

    End Sub

    Private Sub Frm_DesbloqImportacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Frm_Principal.buscavalor = ""

        Txtresp.Text = Frm_Principal.lblnombre.Text
    End Sub

    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        Dim f As New Frm_ListadoImpor
        f.ShowDialog(Frm_Principal)
        If Frm_Principal.buscavalor.ToString() <> "" Then
            RescataProceso(CerosAnteriorString(Frm_Principal.buscavalor.ToString(), 4))
        End If
    End Sub

    Private Sub Frm_DesbloqImportacion_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F2 Then
            If RealizarAccion("020", "055", True) = False Then
                Exit Sub
            End If
            If txtfolio.Enabled = False Then
                Gb_Cliente.Enabled = True
                TxtClirut.Enabled = False
                txtcodcontrato.Enabled = False
                dtfecha.Enabled = True
            End If
        End If
    End Sub

    Private Sub BtnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImprimir.Click
        If txtfolio.Text = "" Then
            MsgBox("Debe guardar el formulario antes de imprimirlo", MsgBoxStyle.Critical, "Aviso")
        Else

            Dim frm As Frm_MuestraReporte = New Frm_MuestraReporte
            frm.Text = "Asistente de informes - Guia Recepcion"

            Dim report As New RptImportaciones

            report.SetDatabaseLogon(Usuario_ODBC, Pass_ODBC)
            report.SetParameterValue("codigo", txtfolio.Text)

            frm.Contenedor.ReportSource = report
            frm.ShowDialog()

        End If
    End Sub
End Class
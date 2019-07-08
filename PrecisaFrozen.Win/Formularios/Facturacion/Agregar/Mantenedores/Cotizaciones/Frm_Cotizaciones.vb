Public Class Frm_Cotizaciones

    Dim fnc As New Funciones

    Public Function validacion() As Integer
        Dim _mensaje As String = ""
        Dim _retorno As Integer = 0

        If txtdescripcion.Text = "" Then
            _mensaje = _mensaje + "- Ingresar una descripción de cotizaciones"
            _retorno = 1
        End If

        If devuelve_fecha(txtfcontrato.Value) > devuelve_fecha(txtfexpiracion.Value) Then
            _mensaje = _mensaje + "- La fecha de cotizaciones no puede ser mayor a la de expiración"
            _retorno = 1
        End If

        If txttemp.Text = "" Then
            _mensaje = _mensaje + "- Debe ingresar una temperatura"
            _retorno = 1
        End If

        If txttempgracia.Text = "" Then
            _mensaje = _mensaje + "- Debe ingresar la temperatura de gracia"
            _retorno = 1
        End If

        If txttunel.Text = "" Then
            _mensaje = _mensaje + "- Debe ingresar el tunel de gracia"
            _retorno = 1
        End If

        If txtderecho.Text = "" Then
            _mensaje = _mensaje + "- Debe ingresar los días de derecho de entrada"
            _retorno = 1
        End If

        If Not IsNumeric(CbNumerales.SelectedValue) Then
            _mensaje = _mensaje + "- Debe ingresar un tipo de numeral"
            _retorno = 1
        End If

        If Not IsDate(TxtHor1.Text) Or Not IsDate(TxtHor2.Text) Or Not IsDate(TxtHor3.Text) Or Not IsDate(TxtHor4.Text) _
            Or Not IsDate(TxtHor5.Text) Or Not IsDate(TxtHor6.Text) Or Not IsDate(TxtHor7.Text) Or Not IsDate(TxtHor8.Text) Then
            _mensaje = _mensaje + "- Debe ingresar el horario"
            _retorno = 1
        End If

        If (_mensaje.Length > 0) Then
            MsgBox("Debe normalizar lo siguiente antes de grabar" + Environment.NewLine + _mensaje, MsgBoxStyle.Critical, "Aviso")
        End If

        Return _retorno
    End Function

    Private Sub Frm_Cotizacioness_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If txtcoti.Enabled = False Then
            If fnc.verificaExistencia("cotizaciones", "coti_codi", txtcoti.Text) = False Then
                If MsgBox("Desea salir sin agregar la cotización", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbYes Then
                    CancelaCorrelativo("016", txtcoti.Text)
                Else
                    e.Cancel = True
                End If
            End If
        End If
        f_cotizaciones = False

    End Sub

    Private Sub Btn_BuscaCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_BuscaCliente.Click
        Dim frm As New Lst_AyudaClientes
        frm.ShowDialog(Me)

        If Frm_Principal.buscavalor <> "" Then
            Me.Txtrut.Text = Frm_Principal.buscavalor
            Frm_Principal.buscavalor = ""

            Dim sql As String = "SELECT cli_nomb FROM clientes WHERE cli_rut='" + QuitarCaracteres(Txtrut.Text) + "'"
            Dim tabla As DataTable = fnc.ListarTablasSQL(sql)
            If tabla.Rows.Count > 0 Then
                TxtCliente.Text = tabla.Rows(0)(0).ToString()
                Txtrut.Enabled = False
                txtcoti.Text = ""
                Btn_BuscaContrato.Enabled = True
            End If

        End If
    End Sub

    Private Sub txtclirut_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtrut.Click
        Txtrut.SelectAll()
    End Sub

    Private Sub txtclirut_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtrut.KeyUp

        If e.KeyCode = Keys.F1 Then
            Btn_BuscaCliente_Click(sender, e)
        End If
        If Txtrut.Text.Length >= 10 Then
            Dim sql As String = "SELECT cli_nomb FROM clientes WHERE cli_rut='" + QuitarCaracteres(Txtrut.Text) + "'"
            Dim tabla As DataTable = fnc.ListarTablasSQL(sql)
            If tabla.Rows.Count > 0 Then
                TxtCliente.Text = tabla.Rows(0)(0).ToString()
                Txtrut.Enabled = False
                Btn_BuscaContrato.Enabled = True
            Else
                TxtCliente.Text = ""
            End If
        End If

    End Sub

    Private Sub Btn_BuscaCotizaciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_BuscaContrato.Click

        If TxtCliente.Text = "" Then

            MsgBox("Debe elegir un cliente antes del Cotizaciones", MsgBoxStyle.Critical, "Aviso")

        Else

            Dim frm As New Frm_CotizacionesListado
            frm.condicion = "WHERE coti_rutclie='" + QuitarCaracteres(Txtrut.Text) + "' "
            frm.ShowDialog(Me)
            If Frm_Principal.buscavalor <> "" Then
                BUSCA_Cotizaciones_COMPLETO(Frm_Principal.buscavalor)
            End If

        End If

    End Sub
    Sub BUSCA_Cotizaciones_COMPLETO(ByVal CODIGO As String)

        'Cargar Cotizaciones

        Dim sql As String = "SELECT coti_descr, coti_feccont, coti_fecexpi, coti_tempcon, coti_tempgra, coti_diagracia, coti_pallet , coti_cc , coti_tunelG, coti_estado, Hor_SRI, Hor_SRT, Hor_SDI, Hor_SDT, " +
            "Hor_FRI, Hor_FRT, Hor_FDI, Hor_FDT, coti_bloqimp, coti_TipAlmc, coti_manual, coti_bloqfac, coti_lectura, cli_rut, cli_nomb, coti_tipseg, coti_descrsopo " +
            "FROM Cotizaciones INNER JOIN CotizacionesHorarios ON coti_codi=Hor_coticod INNER JOIN clientes ON cli_rut=coti_rutclie WHERE coti_codi='" + CODIGO + "'"

        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)
        If tabla.Rows.Count > 0 Then
            txtcoti.Text = CODIGO
            txtdescripcion.Text = tabla.Rows(0)(0).ToString()
            txtfcontrato.Value = devuelve_fecha(tabla.Rows(0)(1)).ToString()
            txtfexpiracion.Value = devuelve_fecha(tabla.Rows(0)(2)).ToString()
            txttemp.Text = tabla.Rows(0)(3).ToString()
            txttempgracia.Text = tabla.Rows(0)(4).ToString()
            txtderecho.Text = tabla.Rows(0)(5).ToString()
            txtpalletmin.Text = tabla.Rows(0)(6).ToString()
            txtcamaracerrada.Text = tabla.Rows(0)(7).ToString()
            txttunel.Text = tabla.Rows(0)(8).ToString()
            CheckEstado.CheckState = tabla.Rows(0)(9).ToString()
            TxtHor1.Text = tabla.Rows(0)(10).ToString()
            TxtHor2.Text = tabla.Rows(0)(11).ToString()
            TxtHor3.Text = tabla.Rows(0)(14).ToString()
            TxtHor4.Text = tabla.Rows(0)(15).ToString()
            TxtHor5.Text = tabla.Rows(0)(12).ToString()
            TxtHor6.Text = tabla.Rows(0)(13).ToString()
            TxtHor7.Text = tabla.Rows(0)(16).ToString()
            TxtHor8.Text = tabla.Rows(0)(17).ToString()
            CbImportaciones.Checked = tabla.Rows(0)(18).ToString()
            CbNumerales.SelectedValue = tabla.Rows(0)(19).ToString()
            CbCarga.Checked = tabla.Rows(0)(20).ToString()
            CBBloquearfact.Checked = tabla.Rows(0)(21).ToString()
            checklectura.Checked = tabla.Rows(0)(22).ToString()

            If Txtrut.Text.Trim = "-" Then
                Txtrut.Text = tabla.Rows(0)(23).ToString()
                TxtCliente.Text = tabla.Rows(0)(24).ToString()
                Txtrut.Enabled = False
            End If

            CbSeguros.SelectedValue = tabla.Rows(0)(25).ToString()
            txtdescsopo.Text = tabla.Rows(0)(26).ToString()

            Txtrut.Enabled = False
            txtcoti.Enabled = False
            Panel2.Enabled = True
        Else
            If Txtrut.Enabled = True Then
                txtcoti.Text = ""
                Return
            End If
            If CODIGO <> "" Then
                If RealizarAccion("015", "038", True) = False Then
                    Exit Sub
                End If
                txtcoti.Text = CODIGO
                txtcoti.Enabled = False
            End If
        End If
    End Sub

    Private Sub txtCotizaciones_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtcoti.KeyDown
        If e.KeyCode = Keys.F1 Then
            Btn_BuscaCotizaciones_Click(sender, e)
        ElseIf e.KeyCode = Keys.Enter Then

        End If
    End Sub

    Private Sub txtderecho_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttunel.KeyPress, txtpalletmin.KeyPress, txtderecho.KeyPress, txtcamaracerrada.KeyPress
        SoloNumeros(sender, e)
    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click

        If validacion() = 0 Then

            If fnc.verificaExistencia("Cotizaciones", "coti_codi", txtcoti.Text) = True Then
                'modificar
                If RealizarAccion("015", "041", True) = False Then
                    Exit Sub
                End If

                Dim sql As String = "UPDATE Cotizaciones SET coti_rutclie='" + QuitarCaracteres(Txtrut.Text) + "', " +
                    "coti_descr='" + txtdescripcion.Text + "', coti_feccont='" + devuelve_fecha(txtfcontrato.Value) + "', coti_descrsopo='" + txtdescsopo.Text + "', " +
                    "coti_fecexpi='" + devuelve_fecha(txtfexpiracion.Text) + "', " +
                    "coti_tempcon='" + txttemp.Text + "', coti_tempgra='" + txttempgracia.Text + "', coti_diagracia='" + txtderecho.Text + "', " +
                    "coti_pallet='" + txtpalletmin.Text + "' , coti_cc='" + txtcamaracerrada.Text + "', " +
                    "coti_tunelG='" + txttunel.Text + "', coti_estado='" + (Convert.ToInt32(CheckEstado.CheckState)).ToString() + "', " +
                    "coti_bloqimp='" + (Convert.ToInt32(CbImportaciones.Checked)).ToString() + "', coti_TipAlmc='" + CbNumerales.SelectedValue.ToString() + "', " +
                    "coti_manual='" + (Convert.ToInt32(CbCarga.Checked)).ToString() + "', coti_lectura='" + (Convert.ToInt32(checklectura.CheckState)).ToString() + "', " +
                    "coti_bloqfac='" + (Convert.ToInt32(CBBloquearfact.Checked)).ToString() + "', coti_tipseg='" + CbSeguros.SelectedValue.ToString() + "'  " +
                    "WHERE coti_codi='" + txtcoti.Text + "' "

                Dim SqlHorario As String = ""

                If fnc.verificaExistencia("CotizacionesHorarios", "Hor_coticod", txtcoti.Text) = False Then
                    SqlHorario = "INSERT INTO CotizacionesHorarios(Hor_CotiCod, Hor_SRI, Hor_SRT, Hor_SDI, Hor_SDT, Hor_FRI, Hor_FRT, Hor_FDI, Hor_FDT)" +
                        "VALUES('" + txtcoti.Text + "','" + TxtHor1.Text + "','" + TxtHor2.Text + "','" + TxtHor5.Text + "','" + TxtHor6.Text + "'," +
                        "'" + TxtHor3.Text + "','" + TxtHor4.Text + "','" + TxtHor7.Text + "','" + TxtHor8.Text + "')"
                Else
                    SqlHorario = "UPDATE CotizacionesHorarios SET Hor_SRI='" + TxtHor1.Text + "', Hor_SRT='" + TxtHor2.Text + "', " +
                        "Hor_SDI='" + TxtHor5.Text + "', Hor_SDT='" + TxtHor6.Text + "', Hor_FRI='" + TxtHor3.Text + "', Hor_FRT='" + TxtHor4.Text + "', " +
                        "Hor_FDI='" + TxtHor7.Text + "', Hor_FDT='" + TxtHor8.Text + "' WHERE Hor_CotiCod='" + txtcoti.Text + "'"
                End If

                If fnc.MovimientoSQL(sql) > 0 Then
                    MsgBox("Cotización actualizada correctamente", MsgBoxStyle.Information, "Aviso")
                    fnc.MovimientoSQL(SqlHorario)
                Else
                    MsgBox("Error al actualizar la cotización", MsgBoxStyle.Critical, "Aviso")
                End If

            Else
                'guardar
                Dim sql As String = "INSERT INTO Cotizaciones (coti_codi, coti_rutclie, coti_descr, coti_feccont, coti_fecexpi, " +
                                    "coti_tempcon, coti_tempgra, coti_diagracia, coti_pallet , coti_cc , " +
                                    "coti_tunelG, coti_estado, coti_bloqimp, coti_TipAlmc, coti_manual, coti_bloqfac, coti_lectura, coti_tipseg, coti_descrsopo)" +
                                    "VALUES('" + txtcoti.Text + "','" + QuitarCaracteres(Txtrut.Text) + "','" + txtdescripcion.Text + "'" +
                                    ",'" + devuelve_fecha(txtfcontrato.Value) + "','" + devuelve_fecha(txtfexpiracion.Text) + "', " +
                                    "'" + txttemp.Text + "','" + txttempgracia.Text + "','" + txtderecho.Text + "','" + txtpalletmin.Text + "'," +
                                    "'" + txtcamaracerrada.Text + "','" + txttunel.Text + "','" + (Convert.ToInt32(CheckEstado.CheckState)).ToString() + "', " +
                                    "'" + EstadoCheckBox(CbImportaciones.CheckState) + "','" + CbNumerales.SelectedValue.ToString() + "', '" + EstadoCheckBox(CbCarga.CheckState) + "'," +
                                    "'" + (Convert.ToInt32(CBBloquearfact.Checked)).ToString() + "', '" + (Convert.ToInt32(checklectura.Checked)).ToString() + "','" + CbSeguros.SelectedValue.ToString() + "', " +
                                    "'" + txtdescsopo.Text + "')"


                Dim SqlHorario As String = "INSERT INTO CotizacionesHorarios(Hor_ContCod, Hor_SRI, Hor_SRT, Hor_SDI, Hor_SDT, Hor_FRI, Hor_FRT, Hor_FDI, Hor_FDT)" +
                    "VALUES('" + txtcoti.Text + "','" + TxtHor1.Text + "','" + TxtHor2.Text + "','" + TxtHor5.Text + "','" + TxtHor6.Text + "'," +
                    "'" + TxtHor3.Text + "','" + TxtHor4.Text + "','" + TxtHor7.Text + "','" + TxtHor8.Text + "')"

                If fnc.MovimientoSQL(sql) > 0 Then
                    MsgBox("Cotización agregada correctamente", MsgBoxStyle.Information, "Aviso")
                    fnc.MovimientoSQL(SqlHorario)
                Else
                    MsgBox("Error al agregar las Cotizaciones", MsgBoxStyle.Critical, "Aviso")
                End If

            End If
        End If
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If txtcoti.Text <> "" Then
            If RealizarAccion("015", "040", True) = False Then
                Exit Sub
            End If
            Dim frm As New Frm_CotizacionesDetalle

            Dim Sql As String = "SELECT Serv_cod, Serv_MedPred, Serv_MonPred FROM FacServicios ORDER BY serv_cod ASC"
            Dim tabla As DataTable = fnc.ListarTablasSQL(Sql)

            For i As Integer = 0 To tabla.Rows.Count - 1
                If fnc.verificaExistenciaCondicional("CotizacionesDetalle", "Dcot_codigo='" + txtcoti.Text + "' AND " +
                                                     "Dcot_servCod='" + tabla.Rows(i)(0).ToString() + "'") = False Then

                    Dim Ingreso As String = "INSERT INTO CotizacionesDetalle(Dcot_codigo, Dcot_ServCod, Dcot_Activo, Dcot_Valor, Dcot_Moneda, Dcot_Medida, Dcot_CodVig)" +
                        "VALUES('" + txtcoti.Text + "','" + tabla.Rows(i)(0).ToString() + "','0','0','" + tabla.Rows(i)(2).ToString() + "'," +
                        "'" + tabla.Rows(i)(1).ToString() + "','0')"

                    fnc.MovimientoSQL(Ingreso)
                End If
            Next

            frm.Cotizacion = txtcoti.Text
            frm.CotizacionNombre = txtdescripcion.Text
            frm.nombre_cliente = TxtCliente.Text

            frm.ShowDialog()
        Else
            MsgBox("Seleccione el cliente y su cotizacion para ver el detalle", MsgBoxStyle.Critical, "Aviso")
        End If

    End Sub

    Private Sub txtCotizaciones_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcoti.KeyPress
        If e.KeyChar = ChrW(13) Then
            If txtcoti.Text = "" Then
                If RealizarAccion("015", "038", True) = False Then
                    Exit Sub
                End If
                txtcoti.Text = BuscaCorrelativo("016", 7)
                HorarioDefecto()
                txtcoti.Enabled = False
                Panel2.Enabled = True
            Else
                BUSCA_Cotizaciones_COMPLETO(CerosAnteriorString(txtcoti.Text, 7))
            End If
        End If
    End Sub

    Public Sub HorarioDefecto()

        Dim sql As String = "SELECT Hor_SRI, Hor_SRT, Hor_SDI, Hor_SDT, Hor_FRI, Hor_FRT, Hor_FDI, Hor_FDT FROM DefaultHorarios "

        Dim dt As DataTable = fnc.ListarTablasSQL(sql)

        If dt.Rows.Count > 0 Then
            TxtHor1.Text = dt.Rows(0)(0).ToString()
            TxtHor2.Text = dt.Rows(0)(1).ToString()
            TxtHor3.Text = dt.Rows(0)(2).ToString()
            TxtHor4.Text = dt.Rows(0)(3).ToString()
            TxtHor5.Text = dt.Rows(0)(4).ToString()
            TxtHor6.Text = dt.Rows(0)(5).ToString()
            TxtHor7.Text = dt.Rows(0)(6).ToString()
            TxtHor8.Text = dt.Rows(0)(7).ToString()
        Else
            TxtHor1.Text = "08:30"
            TxtHor2.Text = "16:30"
            TxtHor3.Text = "09:00"
            TxtHor4.Text = "13:00"
            TxtHor5.Text = "08:30"
            TxtHor6.Text = "16:30"
            TxtHor7.Text = "09:00"
            TxtHor8.Text = "13:00"
        End If

    End Sub


    Private Sub btn_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click

        If txtcoti.Enabled = False Then
            If fnc.verificaExistencia("Cotizaciones", "coti_codi", txtcoti.Text) = False Then
                If MsgBox("Desea salir sin agregar la cotización", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbYes Then
                    CancelaCorrelativo("016", txtcoti.Text)
                    Limpiar()
                End If
            Else
                Limpiar()
            End If
        Else
            Limpiar()
        End If

    End Sub

    Sub Limpiar()

        LimpiarCajas(GroupBox2)
        LimpiarCajasMaskedTextBox(GroupBox2)
        Txtrut.Enabled = True
        txtcoti.Enabled = True
        txtdescripcion.Text = ""
        HorarioDefecto()
        txttemp.Text = "-18"
        txttempgracia.Text = "2"
        txtderecho.Text = "15"
        txtpalletmin.Text = "0"
        txttunel.Text = "0"
        txtcamaracerrada.Text = "0"
        CbNumerales.SelectedValue = "1"
        checklectura.Checked = False
        CbCarga.Checked = False
        CbImportaciones.Checked = False
        CBBloquearfact.Checked = False
        Panel2.Enabled = False

        Btn_BuscaContrato.Enabled = False
        Txtrut.Focus()

    End Sub
    Private Sub txttempgracia_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttempgracia.KeyPress
        SoloNumeros(sender, e)
    End Sub

    Private Sub Frm_Cotizacioness_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim SQL As String = "SELECT tnum_codi, tnum_desc, tnum_act FROM P_TipoNumerales WHERE tnum_act='0'"
        CbNumerales.DataSource = fnc.ListarTablasSQL(SQL)
        CbNumerales.DisplayMember = "tnum_desc"
        CbNumerales.ValueMember = "tnum_codi"

        SQL = "SELECT tseg_codi, tseg_desc FROM P_TipoSeguros "
        CbSeguros.DataSource = fnc.ListarTablasSQL(SQL)
        CbSeguros.DisplayMember = "tseg_desc"
        CbSeguros.ValueMember = "tseg_codi"
        HorarioDefecto()

    End Sub

    Private Sub txtexedente_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        SoloKilos(sender, e)
    End Sub

    Private Sub txtlimite_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        SoloKilos(sender, e)
    End Sub

    Private Sub Frm_Cotizaciones_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.F4 Then
            BtnImprimir.PerformClick()
        ElseIf e.KeyCode = Keys.F5 Then
            btn_guardar.PerformClick()
        ElseIf e.KeyCode = Keys.F6 Then
            btn_nuevo.PerformClick()
        ElseIf e.KeyCode = Keys.F7 Then
            btn_eliminar.PerformClick()
        ElseIf e.KeyCode = Keys.Escape Then
            btn_salir.PerformClick()
        End If

    End Sub

    Private Sub BtnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImprimir.Click
        Dim frm As Frm_MuestraReporte = New Frm_MuestraReporte
        frm.Text = "Asistente de informes - Cotización de servicios"
        Dim report As New Rpt_Cotizaciones

        report.SetDatabaseLogon(Usuario_ODBC, Pass_ODBC)
        report.SetParameterValue("codigo", txtcoti.Text)
        frm.Contenedor.ReportSource = report
        frm.ShowDialog()
    End Sub
End Class
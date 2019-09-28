Public Class Frm_Contratos

    Dim fnc As New Funciones

    Public Function validacion() As Integer
        Dim _mensaje As String = ""
        Dim _retorno As Integer = 0

        If txtdescripcion.Text = "" Then
            _mensaje = _mensaje + "- Ingresar una descripción de contrato"
            _retorno = 1
        End If

        If devuelve_fecha(txtfcontrato.Value) > devuelve_fecha(txtfexpiracion.Value) Then
            _mensaje = _mensaje + "- La fecha de contrato no puede ser mayor a la de expiración"
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
            _mensaje = _mensaje + "- Debe ingresar el horario del contrato"
            _retorno = 1
        End If

        If (_mensaje.Length > 0) Then
            MsgBox("Debe normalizar lo siguiente antes de grabar" + Environment.NewLine + _mensaje, MsgBoxStyle.Critical, "Aviso")
        End If

        Return _retorno
    End Function

    Private Sub Frm_Contratos_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        f_addcontrato = False
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
                txtcontrato.Text = ""
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

    Private Sub Btn_BuscaContrato_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_BuscaContrato.Click

        If TxtCliente.Text = "" Then
            MsgBox("Debe elegir un cliente antes del contrato", MsgBoxStyle.Critical, "Aviso")
        Else

            Dim frm As New Lst_AyudaContratos
            frm.condicion = "WHERE cont_rutclie='" + QuitarCaracteres(Txtrut.Text) + "' "
            frm.ShowDialog(Me)
            BUSCA_CONTRATO_COMPLETO(Frm_Principal.buscavalor)
            Frm_Principal.buscavalor = ""
        End If

    End Sub
    Sub BUSCA_CONTRATO_COMPLETO(ByVal CODIGO As String)


        'cargar contrato

        Dim sql As String = "SELECT cont_descr, cont_feccont, cont_fecexpi, cont_tempcon, cont_tempgra, cont_diagracia, cont_pallet , cont_cc , cont_tunelG, cont_estado, Hor_SRI, Hor_SRT, Hor_SDI, Hor_SDT, " +
            "Hor_FRI, Hor_FRT, Hor_FDI, Hor_FDT, cont_bloqimp, Cont_TipAlmc, cont_manual, cont_bloqfac, cont_lectura, cli_rut, cli_nomb, cont_tipseg,cont_tipalm FROM contrato INNER JOIN contratoshorarios ON cont_codi=Hor_contcod INNER JOIN clientes ON cli_rut=cont_rutclie WHERE cont_codi='" + CODIGO + "'"

        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)
        If tabla.Rows.Count > 0 Then
            txtcontrato.Text = CODIGO
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
            If tabla.Rows(0)(26).ToString() = "" Then

                Cmbo_Almacenamiento.SelectedValue = 0

            Else

                Cmbo_Almacenamiento.Text = tabla.Rows(0)(26).ToString()
            End If
            CbSeguros.SelectedValue = tabla.Rows(0)(25).ToString()
            Txtrut.Enabled = False
            txtcontrato.Enabled = False
            Panel2.Enabled = True
        Else
            If Txtrut.Enabled = True Then
                Return
            End If
            If CODIGO <> "" Then
                If RealizarAccion("015", "038", True) = False Then
                    Exit Sub
                End If
                txtcontrato.Text = CODIGO
                txtcontrato.Enabled = False
            End If
        End If

        buscarCobroTracking(CODIGO)
    End Sub

    Sub buscarCobroTracking(ByVal Cont_Codi)
        Try
            Dim CobIn = 0
            Dim CobOut = 0

            Dim sql = "select Cont_In,Cont_Out from Contrato_Cobro_Tracking where Cont_Codi='" & Cont_Codi & "'"
            Dim dt As New DataTable
            dt = fnc.ListarTablasSQL(sql)

            If (dt.Rows.Count > 0) Then
                CobIn = dt.Rows(0).Item(0).ToString.Trim
                CobOut = dt.Rows(0).Item(1).ToString.Trim
            End If

            If (CobIn = "1") Then
                chkCobIn.Checked = True
            Else
                chkCobIn.Checked = False
            End If

            If (CobOut = "1") Then
                chkCobOut.Checked = True
            Else
                chkCobOut.Checked = False
            End If
        Catch ex As Exception
            MessageBox.Show("Ocurrio un error al buscar el detalle de cobro IN/OUT del contrato", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtcontrato_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtcontrato.KeyDown
        If e.KeyCode = Keys.F1 Then
            Btn_BuscaContrato_Click(sender, e)
        ElseIf e.KeyCode = Keys.Enter Then

        End If
    End Sub

    Private Sub txtderecho_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttunel.KeyPress, txtpalletmin.KeyPress, txtderecho.KeyPress, txtcamaracerrada.KeyPress
        SoloNumeros(sender, e)
    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        If txtcontrato.Text = "" Then
            Exit Sub
        End If
        If validacion() = 0 Then

            If fnc.verificaExistencia("contrato", "cont_codi", txtcontrato.Text) = True Then
                'modificar
                If RealizarAccion("015", "041", True) = False Then
                    Exit Sub
                End If

                Dim sql As String = "UPDATE contrato SET cont_rutclie='" + QuitarCaracteres(Txtrut.Text) + "', " +
                    "cont_descr='" + txtdescripcion.Text + "', cont_feccont='" + devuelve_fecha(txtfcontrato.Value) + "', " +
                    "cont_fecexpi='" + devuelve_fecha(txtfexpiracion.Text) + "', " +
                    "cont_tempcon='" + txttemp.Text + "', cont_tempgra='" + txttempgracia.Text + "', cont_diagracia='" + txtderecho.Text + "', " +
                    "cont_pallet='" + txtpalletmin.Text + "' , cont_cc='" + txtcamaracerrada.Text + "', " +
                    "cont_tunelG='" + txttunel.Text + "', cont_estado='" + (Convert.ToInt32(CheckEstado.CheckState)).ToString() + "', " +
                    "Cont_bloqimp='" + (Convert.ToInt32(CbImportaciones.Checked)).ToString() + "', Cont_TipAlmc='" + CbNumerales.SelectedValue.ToString() + "', " +
                    "cont_manual='" + (Convert.ToInt32(CbCarga.Checked)).ToString() + "', cont_lectura='" + (Convert.ToInt32(checklectura.CheckState)).ToString() + "', " +
                    "cont_bloqfac='" + (Convert.ToInt32(CBBloquearfact.Checked)).ToString() + "', cont_tipseg='" + CbSeguros.SelectedValue.ToString() + "' ,cont_tipalm='" + Cmbo_Almacenamiento.Text.Trim() + "' " +
                    "WHERE cont_codi='" + txtcontrato.Text + "' "

                Dim SqlHorario As String = ""

                If fnc.verificaExistencia("ContratosHorarios", "Hor_contcod", txtcontrato.Text) = False Then
                    SqlHorario = "INSERT INTO ContratosHorarios(Hor_ContCod, Hor_SRI, Hor_SRT, Hor_SDI, Hor_SDT, Hor_FRI, Hor_FRT, Hor_FDI, Hor_FDT)" +
                        "VALUES('" + txtcontrato.Text + "','" + TxtHor1.Text + "','" + TxtHor2.Text + "','" + TxtHor5.Text + "','" + TxtHor6.Text + "'," +
                        "'" + TxtHor3.Text + "','" + TxtHor4.Text + "','" + TxtHor7.Text + "','" + TxtHor8.Text + "')"
                Else
                    SqlHorario = "UPDATE ContratosHorarios SET Hor_SRI='" + TxtHor1.Text + "', Hor_SRT='" + TxtHor2.Text + "', " +
                        "Hor_SDI='" + TxtHor5.Text + "', Hor_SDT='" + TxtHor6.Text + "', Hor_FRI='" + TxtHor3.Text + "', Hor_FRT='" + TxtHor4.Text + "', " +
                        "Hor_FDI='" + TxtHor7.Text + "', Hor_FDT='" + TxtHor8.Text + "' WHERE Hor_ContCod='" + txtcontrato.Text + "'"
                End If

                If fnc.MovimientoSQL(sql) > 0 Then
                    grabarCobrosTracking(txtcontrato.Text.Trim)
                    MsgBox("Contrato Actualizado correctamente", MsgBoxStyle.Information, "Aviso")
                    fnc.MovimientoSQL(SqlHorario)
                Else
                    MsgBox("Error al actualizar el contrato", MsgBoxStyle.Critical, "Aviso")
                End If

            Else
                'guardar
                Dim sql As String = "INSERT INTO contrato (cont_codi, cont_rutclie, cont_descr, cont_feccont, cont_fecexpi, " +
                                    "cont_tempcon, cont_tempgra, cont_diagracia, cont_pallet , cont_cc , " +
                                    "cont_tunelG, cont_estado, Cont_bloqimp, Cont_TipAlmc, cont_manual, cont_bloqfac, cont_lectura, cont_tipseg,cont_tipalm)" +
                                    "VALUES('" + txtcontrato.Text + "','" + QuitarCaracteres(Txtrut.Text) + "','" + txtdescripcion.Text + "'" +
                                    ",'" + devuelve_fecha(txtfcontrato.Value) + "','" + devuelve_fecha(txtfexpiracion.Text) + "', " +
                                    "'" + txttemp.Text + "','" + txttempgracia.Text + "','" + txtderecho.Text + "','" + txtpalletmin.Text + "'," +
                                    "'" + txtcamaracerrada.Text + "','" + txttunel.Text + "','" + (Convert.ToInt32(CheckEstado.CheckState)).ToString() + "', " +
                                    "'" + EstadoCheckBox(CbImportaciones.CheckState) + "','" + CbNumerales.SelectedValue.ToString() + "', '" + EstadoCheckBox(CbCarga.CheckState) + "'," +
                                    "'" + (Convert.ToInt32(CBBloquearfact.Checked)).ToString() + "', '" + (Convert.ToInt32(checklectura.Checked)).ToString() + "','" + CbSeguros.SelectedValue.ToString() + "','" + Cmbo_Almacenamiento.Text.Trim() + "')"


                Dim SqlHorario As String = "INSERT INTO ContratosHorarios(Hor_ContCod, Hor_SRI, Hor_SRT, Hor_SDI, Hor_SDT, Hor_FRI, Hor_FRT, Hor_FDI, Hor_FDT)" +
                    "VALUES('" + txtcontrato.Text + "','" + TxtHor1.Text + "','" + TxtHor2.Text + "','" + TxtHor5.Text + "','" + TxtHor6.Text + "'," +
                    "'" + TxtHor3.Text + "','" + TxtHor4.Text + "','" + TxtHor7.Text + "','" + TxtHor8.Text + "')"

                If fnc.MovimientoSQL(sql) > 0 Then
                    grabarCobrosTracking(txtcontrato.Text.Trim)
                    MsgBox("Contrato agregado correctamente", MsgBoxStyle.Information, "Aviso")
                    fnc.MovimientoSQL(SqlHorario)
                Else
                    MsgBox("Error al agregar el contrato", MsgBoxStyle.Critical, "Aviso")
                End If
            End If
        End If
    End Sub

    Sub grabarCobrosTracking(ByVal NroCont)
        Try
            Dim CobIn As Integer = 0
            Dim CobOut As Integer = 0

            If (chkCobIn.Checked) Then
                CobIn = 1
            Else
                CobIn = 0
            End If

            If (chkCobOut.Checked) Then
                CobOut = 1
            Else
                CobOut = 0
            End If

            Dim sql = "sp_Contrato_Cobro_Tracking_Grabar '" & NroCont & "','" & CobIn & "','" & CobOut & "'"
            If (fnc.MovimientoSQL(sql) <> 1) Then
                MessageBox.Show("Ocurrio un error al grabar detalle de cobros IN/OUT de Traqueo.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Ocurrio un error al grabar detalle de cobros IN/OUT de Traqueo.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If txtcontrato.Text <> "" Then
            If RealizarAccion("015", "040", True) = False Then
                Exit Sub
            End If
            Dim frm As New Frm_ContratosDetalle

            Dim Sql As String = "SELECT Serv_cod, Serv_MedPred, Serv_MonPred FROM FacServicios ORDER BY serv_cod ASC"
            Dim tabla As DataTable = fnc.ListarTablasSQL(Sql)

            For i As Integer = 0 To tabla.Rows.Count - 1
                If fnc.verificaExistenciaCondicional("ContratosDetalle", "Dcon_codigo='" + txtcontrato.Text + "' AND " +
                                                     "Dcon_servCod='" + tabla.Rows(i)(0).ToString() + "'") = False Then

                    Dim Ingreso As String = "INSERT INTO ContratosDetalle(Dcon_codigo, Dcon_ServCod, Dcon_Activo, Dcon_Valor, Dcon_Moneda, Dcon_Medida, Dcon_CodVig)" +
                        "VALUES('" + txtcontrato.Text + "','" + tabla.Rows(i)(0).ToString() + "','0','0','" + tabla.Rows(i)(2).ToString() + "'," +
                        "'" + tabla.Rows(i)(1).ToString() + "','0')"
                    fnc.MovimientoSQL(Ingreso)
                End If
            Next

            frm.contrato = txtcontrato.Text
            frm.contratonombre = txtdescripcion.Text
            frm.nombre_cliente = TxtCliente.Text

            frm.ShowDialog()
        Else
            MsgBox("Seleccione el cliente y su contrato para ver el detalle", MsgBoxStyle.Critical, "Aviso")
        End If

    End Sub

    Private Sub txtcontrato_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcontrato.KeyPress
        If e.KeyChar = ChrW(13) Then
            If txtcontrato.Text = "" Then
                If RealizarAccion("015", "038", True) = False Then
                    Exit Sub
                End If
                txtcontrato.Text = CerosAnteriorString(fnc.ValorMaximo("contrato", "cont_codi", 10), 7)
                TxtHor1.Text = "08:30"
                TxtHor2.Text = "21:30"
                TxtHor3.Text = "09:00"
                TxtHor4.Text = "17:00"
                TxtHor5.Text = "08:30"
                TxtHor6.Text = "16:30"
                TxtHor7.Text = "09:00"
                TxtHor8.Text = "13:00"
                txtcontrato.Enabled = False
                Panel2.Enabled = True
            Else
                BUSCA_CONTRATO_COMPLETO(CerosAnteriorString(txtcontrato.Text, 7))
            End If

        End If
    End Sub

    Private Sub btn_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        LimpiarCajas(GroupBox2)
        LimpiarCajasMaskedTextBox(GroupBox2)
        Txtrut.Enabled = True
        txtcontrato.Enabled = True
        txtdescripcion.Text = ""

        txttemp.Text = "-18"
        txttempgracia.Text = "2"
        txtderecho.Text = "15"
        txtpalletmin.Text = "0"
        txttunel.Text = "0"
        txtcamaracerrada.Text = "0"
        CbNumerales.SelectedValue = "1"
        Cmbo_Almacenamiento.SelectedValue = "0"
        checklectura.Checked = False
        CbCarga.Checked = False
        CbImportaciones.Checked = False
        CBBloquearfact.Checked = False
        Panel2.Enabled = False
        HorarioDefecto()
        Btn_BuscaContrato.Enabled = False

        chkCobIn.Checked = False
        chkCobOut.Checked = False

        Txtrut.Focus()
    End Sub

    Public Sub HorarioDefecto()

        Dim sql As String = "SELECT Hor_SRI, Hor_SRT, Hor_SDI, Hor_SDT, Hor_FRI, Hor_FRT, Hor_FDI, Hor_FDT FROM DefaultHorarios"

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

    Private Sub txttempgracia_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttempgracia.KeyPress
        SoloNumeros(sender, e)
    End Sub

    Private Sub Frm_Contratos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Frm_Principal.buscavalor = ""

        Dim SQL As String = "SELECT tnum_codi, tnum_desc, tnum_act FROM P_TipoNumerales WHERE tnum_act='0'"
        CbNumerales.DataSource = fnc.ListarTablasSQL(SQL)
        CbNumerales.DisplayMember = "tnum_desc"
        CbNumerales.ValueMember = "tnum_codi"


        Cmbo_Almacenamiento.DataSource = fnc.ListarTablasSQL("SELECT id, almacenamiento FROM P_tipoalmacenamiento ORDER BY id ASC")
        Cmbo_Almacenamiento.ValueMember = "id"
        Cmbo_Almacenamiento.DisplayMember = "almacenamiento"

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

    'Public Function RetornoCobro() As String

    '    If rbsopo.Checked = True Then
    '        Return "0"
    '    Else
    '        Return "1"
    '    End If

    'End Function

    Private Sub checklectura_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles checklectura.CheckedChanged

    End Sub

    Private Sub btn_eliminar_Click(sender As System.Object, e As System.EventArgs) Handles btn_eliminar.Click

    End Sub

    Private Sub BtnImprimir_Click(sender As System.Object, e As System.EventArgs) Handles BtnImprimir.Click

    End Sub
End Class
Public Class Frm_BloqueoPallets

    Dim fnc As New Funciones

    Dim estado As Integer = 0

    Private Sub Frm_BloqueoPallets_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Cargar Combobox
        Dim sql As String = "SELECT CODIGO, DESCRIPCION FROM RACKDETA_ESTADO WHERE VISIBLE='1' "
        cbBloqueo.DataSource = fnc.ListarTablasSQL(sql)
        cbBloqueo.DisplayMember = "DESCRIPCION"
        cbBloqueo.ValueMember = "CODIGO"
    End Sub

    Private Sub txtcodpro_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcodi.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then ' si es enter
            'llamar información del soportante
            Dim sql As String = "SELECT racd_codi, racd_estado, cli_nomb, cont_descr, racd_unidades, racd_peso, mae_descr " +
                "FROM rackdeta INNER JOIN detarece on drec_codi=racd_codi INNER JOIN clientes ON cli_rut=drec_rutcli " +
                "INNER JOIN contrato ON cont_rutclie=cli_rut AND cont_codi=drec_contcli INNER JOIN maeprod ON mae_codi=drec_codpro " +
                "WHERE racd_codi='" + CerosAnteriorString(txtcodi.Text, 9) + "'"

            Dim dt As DataTable = fnc.ListarTablasSQL(sql)

            If dt.Rows.Count > 0 Then
                ' si tiene resolucion o esta en pre-despacho se cancela la llamada
                If Convert.ToInt32(dt.Rows(0)(1).ToString()) >= 5 Then
                    MsgBox("El soportante se encuentra bloqueado por resolución", MsgBoxStyle.Critical, "Aviso")
                    btn_nuevo_Click(Nothing, Nothing)
                    Exit Sub
                End If

                txtcodi.Enabled = False
                txtcodi.Text = CerosAnteriorString(txtcodi.Text, 9)
                cbBloqueo.SelectedValue = dt.Rows(0)(1).ToString()
                estado = Convert.ToInt32(dt.Rows(0)(1).ToString())
                txtcliente.Text = dt.Rows(0)(2).ToString()
                txtcontrato.Text = dt.Rows(0)(3).ToString()
                txtunidades.Text = dt.Rows(0)(4).ToString()
                txtkilos.Text = dt.Rows(0)(5).ToString()
                txtproducto.Text = dt.Rows(0)(6).ToString()
                btn_guardar.Enabled = True
                cbBloqueo.Focus()

            Else
                MsgBox("El codigo ingresado no se encuentra registrado", MsgBoxStyle.Critical, "Aviso")
                btn_nuevo_Click(Nothing, Nothing)
            End If

        End If
    End Sub
 

    Private Sub btn_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        LimpiarCajas(GroupBox1)
        txtcodi.Text = ""
        cbBloqueo.SelectedValue = 0
        txtcodi.Enabled = True
        btn_guardar.Enabled = False
        txtcodi.Focus()
    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        If Validacion() = True Then
            'actualiza estado
            Dim sql As String = "UPDATE rackdeta SET racd_estado='" + cbBloqueo.SelectedValue.ToString + "' WHERE racd_codi='" + txtcodi.Text + "'"
            If fnc.MovimientoSQL(sql) > 0 Then
                MsgBox("Estado del soportante Actualizado", MsgBoxStyle.Information, "Aviso")
                'Grabar LOG 
                Dim _log As String = "INSERT INTO LOG_BLOQUEOPALLETS(LBP_CODI, LBP_FECHA, LBP_HORA, LBP_USUARIO, LBP_PC, LBP_ESTADO)" +
                    "VALUES('" + txtcodi.Text + "','" + devuelve_fecha_Formato2(fnc.DevuelveFechaServidor()) + "','" + DevuelveHora() + "','" + Frm_Principal.InfoUsuario.Text + "','" + My.Computer.Name + "','" + cbBloqueo.SelectedValue.ToString() + "')"
                fnc.MovimientoSQL(_log)
                btn_nuevo_Click(Nothing, Nothing)
            Else
                MsgBox("Error al cambiar el estado del soportante", MsgBoxStyle.Information, "Aviso")
            End If
        End If

    End Sub

    Function Validacion() ' validacion de ingreso

        Dim mensaje As String = ""
        Dim retorno As Boolean = True

        If cbBloqueo.Text = "Seleccione" Then
            mensaje = " - Estado del soportante"
            retorno = False
        End If
        If estado = cbBloqueo.SelectedValue Then
            mensaje = " - El soportante ya tiene el estado que desea guardar"
            retorno = False
        End If
        If mensaje.Length > 0 Then
            MsgBox("Debe ingresar lo siguiente antes de continuar" + vbNewLine + "-----------------------------" + vbNewLine + mensaje, 16, "Aviso")
        End If

        Return retorno
    End Function

    Private Sub Frm_BloqueoPallets_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        f_bloqDesbloq = False
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Close()
    End Sub

    Private Sub cbBloqueo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbBloqueo.SelectedIndexChanged

    End Sub
End Class
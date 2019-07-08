Public Class Frm_AddPedidosxTramo
    Dim fnc As New Funciones
    Private Sub Frm_AddPedidosxTramo_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim sql As String = "SELECT * from maetramos "
        Dim tsbls As DataTable = fnc.ListarTablasSQL(sql)

        If tsbls.Rows.Count > 0 Then
            TextBox1.Text = tsbls.Rows(0)(0).ToString()
            TextBox2.Text = tsbls.Rows(0)(1).ToString()

            Dim strString(CBOMANUAL.Items.Count - 1) As String
            Dim valor As String = ""
            Dim valor2 As String = tsbls.Rows(0)(2).ToString().Trim()
            For i As Integer = 0 To CBOMANUAL.Items.Count - 1
                CBOMANUAL.SelectedIndex = i
                strString(i) = CBOMANUAL.Text
                valor = CBOMANUAL.Text
                If valor = tsbls.Rows(0)(2).ToString().Trim() Then
                    Exit For
                End If

            Next
            For i As Integer = 0 To CBOMECANIC.Items.Count - 1
                CBOMECANIC.SelectedIndex = i
                strString(i) = CBOMECANIC.Text
                valor = CBOMECANIC.Text
                If valor = tsbls.Rows(0)(3).ToString().Trim() Then
                    Exit For
                End If

            Next

       
        End If
    End Sub

    Private Sub TextBox1_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        SoloNumeros(sender, e)
    End Sub

    Private Sub TextBox2_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        SoloNumeros(sender, e)
    End Sub

    Private Sub btn_guardar_Click(sender As System.Object, e As System.EventArgs) Handles btn_guardar.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Then

            MsgBox("Debe ingresar todos los datos ", MsgBoxStyle.Critical, "Aviso")
        Else
            Dim sqltramo As String = "UPDATE maetramos SET manual_camiones='" + TextBox1.Text.Trim() + "', meca_camiones='" + TextBox2.Text.Trim() + "' ,manual_tramo ='" + CBOMANUAL.Text.Trim() + "',meca_tramo ='" + CBOMECANIC.Text.Trim() + "' "
            fnc.MovimientoSQL(sqltramo)
            MsgBox("Actualizado correctamente", MsgBoxStyle.Information, "Aviso")

            Dim sqllogtramo As String = "INSERT INTO log_maetramos(manual_camiones, Meca_Camiones, Manual_Tramo, Meca_Tramo, fecha_modificado, usr_mod, pc_mod)" +
                                                   "VALUES('" + TextBox1.Text.Trim() + "','" + TextBox2.Text.Trim() + "','" + CBOMANUAL.Text.Trim() + "','" + CBOMECANIC.Text.Trim() + "','" + devuelve_fecha(fnc.DevuelveFechaServidor()) + "'," +
                        "'" + Frm_Principal.InfoUsuario.Text + "','" + My.Computer.Name.ToString() + "')"

            fnc.MovimientoSQL(sqllogtramo)

        End If


    End Sub

    Private Sub Frm_AddPedidosxTramo_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        f_tramos = False
    End Sub
End Class
Public Class Frm_CambioClave

    Dim fnc As New Funciones

    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click

        Dim sql As String = "SELECT usu_pass FROM usuarios WHERE usu_codigo='" + Frm_Principal.InfoUsuario.Text + "'"
        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

        If tabla.Rows.Count > 0 Then
            If Desencriptar(tabla.Rows(0)(0).ToString()) = txtanterior.Text Then
                If txtnueva.Text = txtrepetir.Text Then

                    sql = "UPDATE Usuarios SET usu_pass='" + Encriptar(txtnueva.Text) + "', usu_pass2='" + CODIFICA(txtnueva.Text) + "', usu_passweb='" + MD5EncryptPass(txtnueva.Text) + "' WHERE usu_codigo='" + Frm_Principal.InfoUsuario.Text + "'"

                    If fnc.MovimientoSQL(sql) > 0 Then
                        MsgBox("Contraseña modifica con exito", MsgBoxStyle.Information, "Aviso")
                        Me.Close()
                    Else
                        MsgBox("Error al modificar la contraseña", MsgBoxStyle.Critical, "Aviso")
                    End If
                Else
                    MsgBox("las contraseñas nueva y repetir no son iguales", MsgBoxStyle.Critical, "Aviso")
                End If
            Else
                MsgBox("la contraseña indicada como anterior no es correcta", MsgBoxStyle.Critical, "Aviso")
            End If
        End If

    End Sub

End Class
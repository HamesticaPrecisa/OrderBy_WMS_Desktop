Public Class Frm_AddMedida
    Dim fnc As New Funciones
    Private Sub btn_salir_Click(sender As System.Object, e As System.EventArgs) Handles btn_salir.Click
        Close()
    End Sub

    Private Sub txtdireccion_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtcodigo.KeyPress

        If e.KeyChar = ChrW(13) Then
            If txtcodigo.Text <> "" Then
                txtcodigo.Text = CerosAnteriorString(txtcodigo.Text, 3)
                txtdescr.Enabled = True
                If fnc.verificaExistencia("medidas", "med_codi", txtcodigo.Text) = True Then
                    Dim sql = "SELECT med_descr FROM medidas WHERE med_codi='" + txtcodigo.Text + "'"
                    Dim tabla As DataTable = fnc.ListarTablasSQL(sql)
                    If tabla.Rows.Count > 0 Then
                        txtdescr.Text = tabla.Rows(0)(0)
                    End If
                Else
                    If RealizarAccion("010", "026") = False Then
                        Exit Sub
                    End If
                End If
                txtcodigo.Enabled = False
                txtdescr.Focus()
            Else
                MsgBox("Ingrese un numero", MsgBoxStyle.Information, "Aviso")
            End If
        End If

    End Sub

    Private Sub btn_guardar_Click(sender As System.Object, e As System.EventArgs) Handles btn_guardar.Click
        If txtcodigo.Text = "" Or txtdescr.Text = "" Then
            MsgBox("Todos los registros son requeridos", MsgBoxStyle.Critical, "Aviso")
            Exit Sub
        End If

        If fnc.verificaExistencia("medidas", "med_codi", txtcodigo.Text) = True Then
            'existe
            If RealizarAccion("010", "027") = False Then
                Exit Sub
            End If
            Dim sql As String = "UPDATE medidas SET med_descr='" + txtdescr.Text + "' WHERE med_codi='" + txtcodigo.Text + "'"
            If fnc.MovimientoSQL(sql) > 0 Then
                MsgBox("Información actualizada correctamente", MsgBoxStyle.Information, "Aviso")
            Else
                MsgBox("Error al actualizar la información ", MsgBoxStyle.Critical, "Aviso")
            End If
        Else
            'no existe
            Dim sql As String = "INSERT INTO medidas (med_codi, med_descr)VALUES('" + txtcodigo.Text + "','" + txtdescr.Text + "')"
            If fnc.MovimientoSQL(sql) > 0 Then
                MsgBox("Información guardada correctamente", MsgBoxStyle.Information, "Aviso")
            Else
                MsgBox("Error al agregar la información ", MsgBoxStyle.Critical, "Aviso")
            End If
        End If
    End Sub

    Private Sub btn_nuevo_Click(sender As System.Object, e As System.EventArgs) Handles btn_nuevo.Click
        LimpiarCajas(GroupBox2)
        txtcodigo.Enabled = True
        txtdescr.Enabled = False
        txtcodigo.Focus()
    End Sub

    Private Sub btn_eliminar_Click(sender As System.Object, e As System.EventArgs) Handles btn_eliminar.Click

        If txtcodigo.Text <> "" AndAlso txtcodigo.Enabled = False Then
            If RealizarAccion("010", "028") = False Then
                Exit Sub
            End If

            If MsgBox("Esta seguro de eliminar la información seleccionada", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbYes Then
                If MsgBox("Esta por eliminar la información, desea continuar?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo, "Aviso") = vbYes Then

                    Dim sql = "DELETE  FROM medidas WHERE med_codi='" + txtcodigo.Text + "'"

                    If fnc.MovimientoSQL(sql) > 0 Then
                        MsgBox("Registro eliminado", MsgBoxStyle.Information, "Aviso")
                        btn_nuevo_Click(sender, e)
                    End If
                End If

            End If

        End If

    End Sub
End Class
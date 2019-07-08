Public Class Frm_AddFamilias

    Dim fnc As New Funciones

    Function valida()
        Dim valor As Integer = 0
        If txtdesc.Text = "" Then
            valor += 1
        End If
        Return valor
    End Function

    Private Sub Frm_AddFamilias_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        f_addfamilias = False
        txtcodigo.Enabled = True
        txtdesc.Enabled = False
    End Sub

    Private Sub btn_guardar_Click(sender As System.Object, e As System.EventArgs) Handles btn_guardar.Click

        If valida() = 0 Then
            If fnc.verificaExistencia("famprod", "fam_codi", txtcodigo.Text + "0000") = False Then

                Dim sqlGuarda = "INSERT INTO famprod (fam_codi, fam_descr, fam_correl, fam_imp, fam_exp, fam_nac)" +
                          "Values('" + txtcodigo.Text + "0000" + "','" + txtdesc.Text + "','0','0','0','0')"

                If fnc.MovimientoSQL(sqlGuarda) > 0 Then
                    MsgBox("Familia agregada correctamente", MsgBoxStyle.Information, "Aviso")
                Else
                    MsgBox("Error al ingresar la familia", MsgBoxStyle.Critical, "Aviso")
                End If
            Else
                If RealizarAccion("009", "024") = False Then
                    Exit Sub
                End If
                Dim sqlModifica = "UPDATE famprod SET fam_descr='" + txtdesc.Text + "' " +
                        "WHERE fam_codi='" + txtcodigo.Text + "0000" + "'"

                If fnc.MovimientoSQL(sqlModifica) > 0 Then
                    MsgBox("Familia Actualizada correctamente", MsgBoxStyle.Information, "Aviso")
                Else
                    MsgBox("Error al actualizar la familia", MsgBoxStyle.Critical, "Aviso")
                End If
            End If
        Else
            MsgBox("Ingrese los campos requeridos", MsgBoxStyle.Critical, "Aviso")
        End If
    End Sub

    Private Sub btn_buscar_Click(sender As System.Object, e As System.EventArgs)
        Dim valor = InputBox("Ingrese Valor", "Buscador de Familias", "")

        If IsNumeric(valor) = False Then
            MsgBox("Debe ingresar solo numeros")
        Else
            txtcodigo.Text = valor.ToString()
            Dim sql = "SELECT fam_descr FROM famprod WHERE fam_codi='" + txtcodigo.Text + "0000" + "'"
            Dim tabla As DataTable = fnc.ListarTablasSQL(sql)
            If tabla.Rows.Count > 0 Then
                txtdesc.Text = tabla.Rows(0)(0)
            End If
        End If
    End Sub

    Private Sub btn_nuevo_Click(sender As System.Object, e As System.EventArgs) Handles btn_nuevo.Click
        LimpiarCajas(GroupBox2)
        txtcodigo.Enabled = True
        txtdesc.Enabled = False
        txtcodigo.Focus()

    End Sub

    Private Sub txtcodigo_Click(sender As Object, e As System.EventArgs) Handles txtcodigo.Click
        txtcodigo.SelectAll()
    End Sub

    Private Sub txtcodigo_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtcodigo.KeyPress
        SoloNumeros(sender, e)
        If e.KeyChar = ChrW(13) Then
            If txtcodigo.Text = "" Then
                MsgBox("Debe ingresar el codigo a crear", MsgBoxStyle.Critical, "Aviso")
                Exit Sub
            End If
            Dim sql = "SELECT fam_descr FROM famprod WHERE fam_codi='" + txtcodigo.Text + "0000" + "'"
            Dim tabla As DataTable = fnc.ListarTablasSQL(sql)
            If tabla.Rows.Count > 0 Then
                txtdesc.Text = tabla.Rows(0)(0)
            Else
                If RealizarAccion("009", "023") = False Then
                    Exit Sub
                End If
            End If
            txtcodigo.Enabled = False
            txtdesc.Enabled = True
            txtdesc.Focus()
        End If
    End Sub

    Private Sub btn_salir_Click(sender As System.Object, e As System.EventArgs) Handles btn_salir.Click
        Close()
    End Sub

    Private Sub btn_eliminar_Click(sender As System.Object, e As System.EventArgs) Handles btn_eliminar.Click
        If txtcodigo.Text <> "" Then
            If RealizarAccion("009", "025") = False Then
                Exit Sub
            End If
            If MsgBox("Seguro de eliminar la familia seleccionada?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbYes Then
                If MsgBox("Está seguro de eliminar la familia", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Aviso") = vbYes Then

                    Dim Elimina As String = "DELETE FROM famprod WHERE " +
                        "fam_codi='" + txtcodigo.Text + "0000" + "'"

                    If fnc.MovimientoSQL(Elimina) > 0 Then
                        MsgBox("Registro Eliminado", MsgBoxStyle.Information, "Aviso")

                        btn_nuevo_Click(sender, e)

                    End If


                End If
            End If
        End If

    End Sub

    Private Sub Frm_AddFamilias_LostFocus(sender As Object, e As System.EventArgs) Handles Me.LostFocus
        txtcodigo.Enabled = True
        txtdesc.Enabled = False
    End Sub

End Class
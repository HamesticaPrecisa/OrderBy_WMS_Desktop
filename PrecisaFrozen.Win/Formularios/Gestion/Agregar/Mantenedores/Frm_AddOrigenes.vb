Public Class Frm_AddOrigenes


    Dim fnc As New Funciones

    Private Sub txtcodigo_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtcodigo.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtcodigo.Text = "" Then
                MsgBox("Debe ingresar el codigo a crear", MsgBoxStyle.Critical, "Aviso")
                Exit Sub
            End If
            Dim sql As String = "SELECT ori_descr FROM Origen WHERE ori_codi='" + CerosAnteriorString(txtcodigo.Text, 2) + "'"

            Dim tabla As DataTable = fnc.ListarTablasSQL(sql)
            If tabla.Rows.Count > 0 Then
                txtcodigo.Text = CerosAnteriorString(txtcodigo.Text, 2)
                txtdesc.Text = tabla.Rows(0)(0)
            Else
                If RealizarAccion("012", "033") = False Then
                    Exit Sub
                End If
                txtcodigo.Text = CerosAnteriorString(txtcodigo.Text, 2)
            End If

            txtcodigo.Enabled = False
            txtdesc.Focus()
            txtdesc.Enabled = True
            txtdesc.SelectAll()

        End If
    End Sub

    Private Sub btn_guardar_Click(sender As System.Object, e As System.EventArgs) Handles btn_guardar.Click
        If txtdesc.Text = "" Then
            MsgBox("Ingrese Descripción ", MsgBoxStyle.Critical, "Aviso")
            Exit Sub
        End If
        If fnc.verificaExistencia("origen", "ori_codi", txtcodigo.Text) = True Then
            'modificar
            If RealizarAccion("012", "034") = False Then
                Exit Sub
            End If
            Dim sql As String = "UPDATE origen SET  ori_descr='" + txtdesc.Text + "' WHERE ori_codi='" + CerosAnteriorString(txtcodigo.Text, 2) + "'"

            If fnc.MovimientoSQL(sql) > 0 Then

                MsgBox("Origen actualizado correctamente", MsgBoxStyle.Information, "Aviso")
            Else
                MsgBox("Error al actualizar el origen ", MsgBoxStyle.Critical, "Aviso")
            End If

        Else

            'Insertar

            Dim sql As String = "INSERT INTO origen (ori_codi, ori_descr)VALUES('" + CerosAnteriorString(txtcodigo.Text, 2) + "'," +
                "'" + txtdesc.Text + "')"

            If fnc.MovimientoSQL(sql) > 0 Then

                MsgBox("Origen agregado correctamente", MsgBoxStyle.Information, "Aviso")
            Else
                MsgBox("Error al agregar el origen ", MsgBoxStyle.Critical, "Aviso")
            End If

        End If


    End Sub

    Private Sub btn_nuevo_Click(sender As System.Object, e As System.EventArgs) Handles btn_nuevo.Click
        txtcodigo.Enabled = True
        LimpiarCajas(GroupBox1)
        txtdesc.Enabled = False
        txtcodigo.Focus()
    End Sub

    Private Sub Frm_AddOrigenes_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        btn_nuevo_Click(sender, e)
    End Sub

    Private Sub btn_salir_Click(sender As System.Object, e As System.EventArgs) Handles btn_salir.Click
        Close()
    End Sub

    'Private Sub btn_eliminar_Click(sender As System.Object, e As System.EventArgs) Handles btn_eliminar.Click
    '    If txtcodigo.Text.Length >= 1 Then

    '        If MsgBox("Seguro de eliminar el origen seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbYes Then
    '            If MsgBox("Está seguro de eliminar el origen", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Aviso") = vbYes Then

    '                Dim Elimina As String = "DELETE FROM origen WHERE " +
    '                    "ori_codi='" + txtcodigo.Text + "'"

    '                If fnc.MovimientoSQL(Elimina) > 0 Then
    '                    MsgBox("Registro Eliminado", MsgBoxStyle.Information, "Aviso")
    '                    btn_nuevo_Click(sender, e)
    '                End If


    '            End If
    '        End If
    '    End If
    'End Sub

    Private Sub btn_eliminar_Click(sender As System.Object, e As System.EventArgs) Handles btn_eliminar.Click
        If MsgBox("Está seguro de eliminar el Origen", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Aviso") = vbYes Then

            Dim Elimina As String = "DELETE FROM origen WHERE " +
                "ori_codi='" + txtcodigo.Text.Trim() + "'"

            If fnc.MovimientoSQL(Elimina) > 0 Then
                MsgBox("Registro Eliminado", MsgBoxStyle.Information, "Aviso")
                btn_nuevo_Click(sender, e)
                txtcodigo.Text = ""
                txtdesc.Text = ""
            End If


        End If
    End Sub
End Class
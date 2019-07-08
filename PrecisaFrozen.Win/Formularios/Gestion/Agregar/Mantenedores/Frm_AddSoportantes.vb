Public Class Frm_AddSoportantes

    Dim fnc As New Funciones

    Function valida()
        Dim valor As Integer
        If txtdescripcion.Text = "" Then
            valor = +1
        ElseIf txtmaterial.Text = "" Then
            valor += 1
        ElseIf txtpeso.Text = "" Then
            valor += 1
        End If
        Return valor
    End Function


    Private Sub Frm_AddSoportantes_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        btn_nuevo_Click(sender, e)
    End Sub

    Private Sub btn_salir_Click(sender As System.Object, e As System.EventArgs) Handles btn_salir.Click
        Close()
    End Sub

    Private Sub txtpeso_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpeso.KeyPress
        SoloNumeros(sender, e)
    End Sub

    Private Sub btn_guardar_Click(sender As System.Object, e As System.EventArgs) Handles btn_guardar.Click
        If valida() = 0 Then
            If fnc.verificaExistencia("tiposopo", "tsop_codi", txtcodigo.Text) = False Then

                Dim sql = "INSERT INTO tiposopo(tsop_codi, tsop_descr, tsop_materi, pesoPallet)VALUES " +
                                 "('" + txtcodigo.Text + "','" + txtdescripcion.Text + "','" + txtmaterial.Text + "','" + txtpeso.Text + "')"

                If fnc.MovimientoSQL(sql) > 0 Then
                    MsgBox("Soportante agregado correctamente", MsgBoxStyle.Information, "Aviso")
                Else
                    MsgBox("Error al agregar el soportante ", MsgBoxStyle.Critical, "Aviso")
                End If
            Else
                If RealizarAccion("008", "021") = False Then
                    Exit Sub
                End If
                Dim sql = "UPDATE tiposopo SET tsop_descr='" + txtdescripcion.Text + "', tsop_materi='" + txtmaterial.Text + "' , pesoPallet='" + txtpeso.Text + "' " +
                    "WHERE tsop_codi='" + txtcodigo.Text + "'"
                If fnc.MovimientoSQL(sql) > 0 Then
                    MsgBox("Soportante Modificado correctamente", MsgBoxStyle.Information, "Aviso")
                Else
                    MsgBox("Error al modificar el soportante ", MsgBoxStyle.Critical, "Aviso")
                End If

            End If
        Else
            MsgBox("Todos los campos son requeridos", MsgBoxStyle.Critical, "Aviso")
        End If


    End Sub


    Private Sub btn_buscar_Click(sender As System.Object, e As System.EventArgs)
        Dim valor = InputBox("Ingrese Valor", "Buscador de Soportantes", "")

        If IsNumeric(valor) = False Then
            MsgBox("Debe ingresar solo numeros ")
        Else
            txtcodigo.Text = valor.ToString()
            Dim sql = "SELECT tsop_descr, tsop_materi, pesoPallet FROM tiposopo WHERE tsop_codi='" + txtcodigo.Text + "'"
            Dim tabla As DataTable = fnc.ListarTablasSQL(sql)
            If tabla.Rows.Count > 0 Then
                txtcodigo.Enabled = False
                txtdescripcion.Text = tabla.Rows(0)(0)
                txtmaterial.Text = tabla.Rows(0)(1)
                txtpeso.Text = tabla.Rows(0)(2)
            End If
        End If
    End Sub

    Private Sub btn_nuevo_Click(sender As System.Object, e As System.EventArgs) Handles btn_nuevo.Click
        txtcodigo.Text = ""
        LimpiarCajas(GroupBox1)
        txtcodigo.Enabled = True
        txtcodigo.Focus()
        txtdescripcion.Enabled = False
        txtmaterial.Enabled = False
        txtpeso.Enabled = False
    End Sub

    Private Sub btn_eliminar_Click(sender As System.Object, e As System.EventArgs) Handles btn_eliminar.Click
        If txtcodigo.Text <> "" Then
            If RealizarAccion("008", "022") = False Then
                Exit Sub
            End If
            If MsgBox("Seguro de eliminar el Soportante seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbYes Then
                If MsgBox("Está seguro de eliminar el Soportante", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Aviso") = vbYes Then

                    Dim Elimina As String = "DELETE FROM tiposopo WHERE " +
                        "tsop_codi='" + txtcodigo.Text + "'"

                    If fnc.MovimientoSQL(Elimina) > 0 Then
                        MsgBox("Registro Eliminado", MsgBoxStyle.Information, "Aviso")

                        btn_nuevo_Click(sender, e)

                    End If


                End If
            End If
        End If



    End Sub

    Private Sub txtcodigo_Click(sender As Object, e As System.EventArgs) Handles txtcodigo.Click
        Me.txtcodigo.SelectAll()
    End Sub

    Private Sub txtcodigo_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtcodigo.KeyPress
        SoloNumeros(sender, e)
        If e.KeyChar = ChrW(13) AndAlso txtcodigo.Text.Length > 0 Then

            txtcodigo.Text = CerosAnteriorString(txtcodigo.Text, 3)
            txtdescripcion.Enabled = True
            txtmaterial.Enabled = True
            txtpeso.Enabled = True
            Dim sql = "SELECT tsop_descr, tsop_materi, pesoPallet FROM tiposopo WHERE tsop_codi='" + txtcodigo.Text + "'"
            Dim tabla As DataTable = fnc.ListarTablasSQL(sql)
            If tabla.Rows.Count > 0 Then
                txtdescripcion.Text = tabla.Rows(0)(0)
                txtmaterial.Text = tabla.Rows(0)(1)
                txtpeso.Text = tabla.Rows(0)(2)
                txtdescripcion.Focus()
            Else
                If RealizarAccion("008", "020") = False Then
                    txtcodigo.Enabled = True
                    txtcodigo.Text = ""
                    txtdescripcion.Enabled = False
                    txtmaterial.Enabled = False
                    txtpeso.Enabled = False
                    Exit Sub
                End If
                txtdescripcion.Text = ""
                txtmaterial.Text = ""
                txtpeso.Text = ""
        End If
            txtcodigo.Enabled = False
        End If

    End Sub
End Class
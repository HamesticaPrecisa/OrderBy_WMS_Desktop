Public Class Frm_AddEnvases

    Dim fnc As New Funciones

    Function validar()
        Dim valor As Integer = 0
        If txtcodigo.Text = "" Then
            valor += 1
        ElseIf txtdesc.Text = "" Then
            valor += 1
        End If
        Return valor
    End Function

    Private Sub Frm_AddEnvases_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        f_addenvases = False
        btn_nuevo_Click(sender, e)
    End Sub

    Private Sub txtcodigo_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtcodigo.KeyPress
        If e.KeyChar = ChrW(13) Then

            If fnc.verificaExistencia("tipoenv", "tenv_codi", CerosAnteriorString(txtcodigo.Text, 5)).ToString() = True Then
                txtcodigo.Text = CerosAnteriorString(txtcodigo.Text, 5)
                If RealizarAccion("005", "012") = False Then
                    Exit Sub
                End If
                Dim sql = "SELECT tenv_codi, tenv_descr, tenv_mater FROM tipoenv WHERE " +
                    "tenv_codi='" + CerosAnteriorString(txtcodigo.Text, 5).ToString() + "' "
                Dim tabla As DataTable = fnc.ListarTablasSQL(sql)
                If tabla.Rows.Count > 0 Then

                    txtdesc.Text = tabla.Rows(0)(1)
                    txtmaterial.Text = tabla.Rows(0)(2)

                    txtdesc.Enabled = True
                    txtmaterial.Enabled = True
                End If
            Else
                If RealizarAccion("005", "011") = False Then
                    Exit Sub
                End If
                If txtcodigo.Text = "" Then
                    txtcodigo.Text = CerosAnteriorString(fnc.ValorMaximo("tipoenv", "tenv_codi", 1), 5)
                Else
                    txtcodigo.Text = CerosAnteriorString(txtcodigo.Text, 5)
                End If

                txtdesc.Enabled = True
                txtmaterial.Enabled = True
            End If

            txtcodigo.Enabled = False
            txtdesc.Focus()
        Else
            SoloNumeros(sender, e)
        End If

    End Sub

    Private Sub btn_guardar_Click(sender As System.Object, e As System.EventArgs) Handles btn_guardar.Click
        If validar() = 0 Then
            If fnc.verificaExistencia("tipoenv", "tenv_codi", CerosAnteriorString(txtcodigo.Text, 5)).ToString() = True Then
                'existe

                Dim SqlGuardar As String = "UPDATE tipoenv SET tenv_descr='" + txtdesc.Text + "', " +
                    "tenv_mater='" + txtmaterial.Text + "' WHERE tenv_codi='" + CerosAnteriorString(txtcodigo.Text, 5) + "'"

                If fnc.MovimientoSQL(SqlGuardar) > 0 Then
                    MsgBox("Envase actualizado correctamente", MsgBoxStyle.Information, "Aviso")
                Else
                    MsgBox("Error al actualizar el envase", MsgBoxStyle.Critical, "Aviso")
                End If

            Else
                'no existe
                
                Dim SqlGuardar As String = "INSERT INTO tipoenv(tenv_codi, tenv_descr, tenv_mater, tenv_fecproc)" +
                                "VALUES('" + CerosAnteriorString(txtcodigo.Text, 5) + "','" + txtdesc.Text + "', " +
                                "'" + txtmaterial.Text + "','" + devuelve_fecha(Date.Now) + "')"
                If fnc.MovimientoSQL(SqlGuardar) > 0 Then
                    MsgBox("Envase agregado correctamente", MsgBoxStyle.Information, "Aviso")
                Else
                    MsgBox("Error al agregar el envase", MsgBoxStyle.Critical, "Aviso")
                End If

            End If

        End If
    End Sub

    Private Sub btn_nuevo_Click(sender As System.Object, e As System.EventArgs) Handles btn_nuevo.Click
        LimpiarCajas(GroupBox2)
        txtdesc.Enabled = False
        txtmaterial.Enabled = False
        txtcodigo.Enabled = True
        txtcodigo.Focus()
    End Sub

    Private Sub btn_salir_Click(sender As System.Object, e As System.EventArgs) Handles btn_salir.Click
        Close()
    End Sub

    Private Sub btn_eliminar_Click(sender As System.Object, e As System.EventArgs) Handles btn_eliminar.Click
        If txtcodigo.Text <> "" Then
            Dim sqlVer As String = "SELECT * from maeprod WHERE mae_tipenv='" + CerosAnteriorString(txtcodigo.Text, 5) + "'"
            Dim tbl As DataTable = fnc.ListarTablasSQL(sqlVer)

            If tbl.Rows.Count > 0 Then
                MsgBox("No puede eliminar el envase, Existen registros relacionados", MsgBoxStyle.Critical, "Aviso")
                Exit Sub
            End If

            If MsgBox("Esta seguro de eliminar la información seleccionada", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbYes Then
                If MsgBox("Esta por eliminar la información, desea continuar?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo, "Aviso") = vbYes Then

                    Dim sql = "DELETE FROM tipoenv WHERE tenv_codi='" + CerosAnteriorString(txtcodigo.Text, 5) + "'"
                    If fnc.MovimientoSQL(sql) > 0 Then
                        MsgBox("Registro eliminado", MsgBoxStyle.Information, "Aviso")
                        btn_nuevo_Click(sender, e)
                    End If
                End If

            End If
        End If


    End Sub

    Private Sub Frm_AddEnvases_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
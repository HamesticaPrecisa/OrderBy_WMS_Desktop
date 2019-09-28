Imports System.Data
Imports System.Data.SqlClient


Public Class Frm_AddMercados

    Dim fnc As New Funciones
    Public mer_id As Integer


    Function valida()
        Dim valor As Integer = 0
        If txtNombre.Text = "" Then
            valor += 1
        ElseIf txttemp.Text = "" Then
            valor += 1
        ElseIf txtHoras.Text = "" Then
            valor += 1
        End If

        Return valor
    End Function



    Private Sub Frm_AddMercados_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        f_addmercados = False
        btn_nuevo_Click(sender, e)
    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        If valida() = 0 Then

            Dim check As DataRow = fnc.sqlExecuteRow("SELECT mer_id FROM mercados WHERE mer_nombre = @nombre AND mer_status <> 'ELIMINADO'",
                                                     New SqlParameter() {New SqlParameter("@nombre", SqlDbType.VarChar) With {.Value = txtNombre.Text}})

            If check Is Nothing Then
                Dim sql = "INSERT INTO mercados (mer_nombre, mer_temp, mer_horas, mer_status) VALUES (@nombre, @temp, @horas, 'ACTIVO')"
                Dim params() = New SqlParameter() {
                    New SqlParameter("@nombre", SqlDbType.VarChar) with {.Value = txtNombre.Text},
                    New SqlParameter("@temp", SqlDbType.Decimal) with {.Value = Decimal.Parse(txttemp.Text) },
                    New SqlParameter("@horas", SqlDbType.Int) With {.Value = Int32.Parse(txtHoras.Text)}
                }

                If fnc.runSQLCmd(sql, params).result Then
                    MsgBox("Mercado almacenado correctamente", MsgBoxStyle.Information, "Aviso")
                Else
                    MsgBox("Error al ingresar el mercado: " + lastSqlError, MsgBoxStyle.Critical, "Aviso")
                End If

            Else
                'actualizar
                If RealizarAccion("006", "015") = False Then
                    Exit Sub
                End If

                Dim sql = "UPDATE mercados SET mer_temp = @temp, mer_horas = @horas WHERE mer_id = @id"
                Dim params() = New SqlParameter() {
                    New SqlParameter("@id", SqlDbType.Int) With {.Value = mer_id},
                    New SqlParameter("@temp", SqlDbType.Decimal) With {.Value = Decimal.Parse(txttemp.Text)},
                    New SqlParameter("@horas", SqlDbType.Int) With {.Value = Int32.Parse(txtHoras.Text)}
                }

                If fnc.runSQLCmd(sql, params).result Then
                    MsgBox("Mercado actualizado correctamente", MsgBoxStyle.Information, "Aviso")
                Else
                    MsgBox("Error al actualizar el mercado: " + lastSqlError, MsgBoxStyle.Critical, "Aviso")
                End If

            End If
        Else

            MsgBox("Todos los campos son requeridos", MsgBoxStyle.Critical, "Aviso")

        End If
    End Sub

    Private Sub btn_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click

        LimpiarCajas(GroupBox3)
        txtNombre.Enabled = True
        txtNombre.Focus()
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Close()
    End Sub

    Private Sub btn_eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_eliminar.Click

        If mer_id = 1 Then
            MsgBox("No puede eliminar este registro", MsgBoxStyle.Exclamation, "Aviso")
            Return
        End If

        If RealizarAccion("006", "016") = False Then
            Exit Sub
        End If
        If MsgBox("Esta seguro de eliminar la información seleccionada", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbYes Then
            If MsgBox("Esta por eliminar la información, desea continuar?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbYes Then

                Dim sql = "DELETE FROM mercados WHERE mer_id = @id"
                If fnc.MovimientoSQL(sql, New SqlParameter() {New SqlParameter("@id", SqlDbType.Int) With {.Value = mer_id}}) > 0 Then
                    MsgBox("Registro eliminado", MsgBoxStyle.Information, "Aviso")
                End If
            End If

        End If
    End Sub

    Private Sub txtnombre_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = ChrW(13) Then
            If txtNombre.Text = "" Then
                MsgBox("Debe ingresar el nombre del mercado", MsgBoxStyle.Critical, "Aviso")
                Exit Sub
            End If

            Dim found = fnc.sqlExecuteRow("SELECT mer_id,mer_temp, mer_horas FROM mercados WHERE mer_status<>'ELIMINADO' AND mer_nombre = @nombre",
                                          New SqlParameter() {New SqlParameter("@nombre", SqlDbType.VarChar) With {.Value = txtNombre.Text}})

            If found IsNot Nothing Then
                mer_id = found(0)
                txttemp.Text = found(1).ToString()
                txtHoras.Text = found(2).ToString()
            End If
        End If
    End Sub

    Private Sub Frm_AddMercados_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtNombre.Focus()
    End Sub

    Private Sub txtHoras_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHoras.KeyPress
        SoloNumeros(sender, e)
    End Sub

    Private Sub txttemp_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttemp.KeyPress
        soloTemperatura(sender, e)
    End Sub
End Class
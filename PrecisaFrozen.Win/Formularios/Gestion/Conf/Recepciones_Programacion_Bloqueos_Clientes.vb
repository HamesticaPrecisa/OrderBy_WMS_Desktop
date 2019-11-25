Public Class Recepciones_Programacion_Bloqueos_Clientes

    Dim fnc As New Funciones
    Dim valorRecibido As String = ""

    Private Sub btnSal_Click(sender As System.Object, e As System.EventArgs) Handles btnSal.Click
        Me.Close()
    End Sub

    Sub cargarClientes()
        Try
            Dim IDBloq As String = txtIDBloq.Text.Trim

            Dim sql As String = "select * from V_Recepciones_Programacion_Horarios_Bloqueos_Clientes with(nolock) where ID_Bloqueo='" & IDBloq & "'"
            Dim dt As New DataTable

            dt = fnc.ListarTablasSQL(sql)

            gvCli.DataSource = dt
        Catch ex As Exception
            MsgBox("Ocurrió un error al cargar los clientes.", MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Sub limpiar()
        txtID.Text = ""
        btn_BuscaCliente.Enabled = True
        txtclinom.Text = ""
        TxtClirut.Text = ""

        cargarClientes()

        btn_BuscaCliente.Focus()
    End Sub

    Private Sub btnLim_Click(sender As System.Object, e As System.EventArgs) Handles btnLim.Click
        limpiar()
    End Sub

    Private Sub Recepciones_Programacion_Bloqueos_Clientes_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        limpiar()
    End Sub

    Sub grabar()
        Try
            Dim CantErr As Integer = 0
            Dim MsjErr As String = "Errores encontrados:"

            Dim RutCli As String = TxtClirut.Text.Trim
            If (RutCli = "") Then
                CantErr += 1
                MsjErr &= vbCrLf & "- Debe seleccionar un cliente."

                btn_BuscaCliente.Focus()
            End If

            Dim IDBloq As String = txtIDBloq.Text.Trim
            If (IDBloq = "") Then
                CantErr += 1
                MsjErr &= vbCrLf & "- No se encontrarón datos del bloqueo."
            End If

            Dim ID As String = txtID.Text.Trim

            If (CantErr > 0) Then
                MsgBox(MsjErr, MsgBoxStyle.Critical, "Error")
            Else
                Dim sql As String = "Recepciones_Programacion_Horarios_Bloqueos_Clientes_Grabar '" & ID & "','" & IDBloq & "','" & RutCli & "','" & Frm_Principal.InfoUsuario.Text.Trim & "'"
                Dim dt As New DataTable

                dt = fnc.ListarTablasSQL(sql)

                If (dt.Rows.Count > 0) Then
                    Dim Resp As String = dt.Rows(0).Item(0).ToString.Trim

                    If (Resp <> "-1") Then
                        MsgBox("Cliente registrado exitosamente.", MsgBoxStyle.Information, "Éxito!")
                        limpiar()
                    Else
                        MsgBox("Ocurrió un error al registrar clientes.", MsgBoxStyle.Critical, "Error")
                    End If
                Else
                    MsgBox("Ocurrió un error al registrar clientes.", MsgBoxStyle.Critical, "Error")
                End If
            End If
        Catch ex As Exception
            MsgBox("Ocurrió un error al registrar clientes.", MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnGra_Click(sender As System.Object, e As System.EventArgs) Handles btnGra.Click
        grabar()
    End Sub

    Private Sub gvCli_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gvCli.CellClick
        Try
            If (e.RowIndex > -1) Then
                Dim ID As String = gvCli.Rows(e.RowIndex).Cells("ID").Value.ToString.Trim

                If (gvCli.Columns(e.ColumnIndex).Name = "btnEli") Then
                    Dim RespEli As MsgBoxResult = MsgBox("¿Seguro de eliminar este cliente?.", MsgBoxStyle.YesNo, "Pregunta")

                    If (RespEli = MsgBoxResult.Yes) Then
                        Dim sql As String = "Recepciones_Programacion_Horarios_Bloqueos_Clientes_Eliminar '" & ID & "','" & Frm_Principal.InfoUsuario.Text.Trim & "'"
                        Dim dt As New DataTable

                        dt = fnc.ListarTablasSQL(sql)

                        If (dt.Rows.Count > 0) Then
                            Dim Resp As String = dt.Rows(0).Item(0).ToString.Trim

                            If (Resp <> "-1") Then
                                MsgBox("Cliente eliminado exitosamente.", MsgBoxStyle.Information, "Éxito")
                                limpiar()
                            Else
                                MsgBox("Ocurrió un error al eliminar clientes.", MsgBoxStyle.Critical, "Error")
                            End If
                        Else
                            MsgBox("Ocurrió un error al eliminar clientes.", MsgBoxStyle.Critical, "Error")
                        End If
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btn_BuscaCliente_Click(sender As System.Object, e As System.EventArgs) Handles btn_BuscaCliente.Click
        Dim frm As New Lst_AyudaClientes
        frm.ShowDialog(Frm_Principal)
        Me.valorRecibido = Frm_Principal.buscavalor

        If Len(valorRecibido) >= 9 Then

            Dim SqlBusca As String = "SELECT cli_nomb, cli_estado FROM clientes WHERE " +
                "cli_rut='" + valorRecibido + "'"

            Dim tabla As DataTable = fnc.ListarTablasSQL(SqlBusca)

            If tabla.Rows.Count > 0 Then
                If tabla.Rows(0)(1).ToString() = "N" Then
                    MsgBox("El cliente seleccionado se encuentra bloqueado", MsgBoxStyle.Critical, "Aviso")
                    Exit Sub
                End If

                TxtClirut.Text = valorRecibido
                txtclinom.Text = tabla.Rows(0)(0).ToString()
                Frm_Principal.buscavalor = ""
                TxtClirut.Enabled = False
            Else
                MsgBox("El rut ingresado no existe", MsgBoxStyle.Information, "Aviso")
            End If
        End If

        Frm_Principal.buscavalor = ""
    End Sub
End Class
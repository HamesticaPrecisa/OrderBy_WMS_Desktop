Public Class Control_Pallets_Fotos

    Dim fnc As New Funciones

    Private Sub btnArch_Click(sender As System.Object, e As System.EventArgs) Handles btnArch.Click
        Try
            Dim file As New OpenFileDialog
            file.Filter = "Archivo JPG|*.jpg"
            If (file.ShowDialog = Windows.Forms.DialogResult.OK) Then
                picArch.SizeMode = PictureBoxSizeMode.StretchImage
                picArch.Image = Image.FromFile(file.FileName)
                picArch.Load(file.FileName)
                txtNomArch.Text = file.FileName
            End If
        Catch ex As Exception
            MsgBox("Ocurrió un error al seleccionar archivo.", MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnGra_Click(sender As System.Object, e As System.EventArgs) Handles btnGra.Click
        Try
            Dim CantErr As Integer = 0
            Dim MsjErr As String = "Errores encontrados:"

            Dim IDCtrlPal As String = txtID.Text.Trim

            Dim IDArch As String = txtIDArch.Text.Trim

            Dim path As String = txtNomArch.Text.Trim
            Dim Ext As String = ""

            If (path = "") Then
                CantErr += 1
                MsjErr &= vbCrLf & "- Debe seleccionar un archivo."
            Else
                Dim pathPart As String() = path.Split(".")
                Ext = pathPart(1)
            End If

            If (CantErr > 0) Then
                MsgBox(MsjErr, MsgBoxStyle.Critical, "Error")
            Else
                Dim sql As String = "Control_Pallet_Fotos_Grabar '" & IDArch & "','" & IDCtrlPal & "','" & Ext & "','" & Frm_Principal.InfoUsuario.Text.Trim & "'"
                Dim dt As New DataTable

                dt = fnc.ListarTablasSQL(sql)

                If (dt.Rows.Count > 0) Then
                    Dim Resp As String = dt.Rows(0).Item(0).ToString.Trim

                    If (Resp <> "-1") Then
                        System.IO.File.Copy(path, "\\192.168.1.90\Custodia_Pallets\" & Resp, True)
                        MsgBox("Foto registrada exitosamente!.", MsgBoxStyle.Information, "Acción Existosa!")
                        limpiar()
                    Else
                        MsgBox("Ocurrió un error al registrar archivo.", MsgBoxStyle.Critical, "Error")
                    End If
                Else
                    MsgBox("Ocurrió un error al registrar archivo.", MsgBoxStyle.Critical, "Error")
                End If
            End If
        Catch ex As Exception
            MsgBox("Ocurrió un error al registrar archivo.", MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Sub limpiar()
        Try
            txtIDArch.Text = ""
            txtNomArch.Text = ""
            txtNomArch.Enabled = True
            btnArch.Enabled = True
            picArch.Image = Nothing
            btnArch.Focus()
            cargarFotos()
        Catch ex As Exception
            Me.Close()
        End Try
    End Sub

    Private Sub btnLim_Click(sender As System.Object, e As System.EventArgs) Handles btnLim.Click
        limpiar()
    End Sub

    Private Sub btnSal_Click(sender As System.Object, e As System.EventArgs) Handles btnSal.Click
        limpiar()
        Me.Close()
    End Sub

    Private Sub btnEli_Click(sender As System.Object, e As System.EventArgs) Handles btnEli.Click
        Try
            Dim IDArch As String = txtIDArch.Text.Trim

            If (IDArch <> "") Then
                Dim MsjResp As MsgBoxResult = MsgBox("¿Seguro de eliminar esta foto?", MsgBoxStyle.YesNo, "¿Seguro?")

                If (MsjResp = MsgBoxResult.Yes) Then
                    Dim sql As String = "Control_Pallet_Fotos_Eliminar '" & IDArch & "','" & Frm_Principal.InfoUsuario.Text.Trim & "'"
                    Dim dt As New DataTable

                    dt = fnc.ListarTablasSQL(sql)

                    If (dt.Rows.Count > 0) Then
                        Dim Resp As String = dt.Rows(0).Item(0).ToString.Trim

                        If (Resp = "-1") Then
                            MsgBox("Ocurrió un error al eliminar archivo.", MsgBoxStyle.Critical, "Error")
                        End If
                    Else
                        MsgBox("Ocurrió un error al eliminar archivo.", MsgBoxStyle.Critical, "Error")
                    End If
                End If
            Else
                MsgBox("Debe seleccionar una foto.", MsgBoxStyle.Critical, "Error")
            End If
        Catch ex As Exception
            MsgBox("Ocurrió un error al eliminar archivo.", MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub gvArch_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gvArch.CellClick
        Try
            If (e.RowIndex > -1) Then
                Dim IDArch As String = gvArch.Rows(e.RowIndex).Cells("ID").Value.ToString.Trim
                Dim NomArch As String = gvArch.Rows(e.RowIndex).Cells("Nombre").Value.ToString.Trim

                If (gvArch.Columns(e.ColumnIndex).Name = "Nombre") Then
                    txtIDArch.Text = IDArch
                    txtNomArch.Text = NomArch
                    txtNomArch.Enabled = False
                    btnArch.Enabled = False
                    picArch.SizeMode = PictureBoxSizeMode.StretchImage
                    picArch.Image = Image.FromFile("\\192.168.1.90\Custodia_Pallets\" & NomArch)
                ElseIf (gvArch.Columns(e.ColumnIndex).Name = "Descargar") Then
                    Dim pathDesktop As String = My.Computer.FileSystem.SpecialDirectories.Desktop & "\"
                    Dim archParts As String() = NomArch.Split(".")
                    Dim Ext As String = archParts(1)

                    System.IO.File.Copy("\\192.168.1.90\Custodia_Pallets\" & NomArch, pathDesktop & "Custodia_Pallets_" & IDArch & "." & Ext, True)

                    MsgBox("La foto se descargo a su escritorio.", MsgBoxStyle.Information, "Acción Existosa!")
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Sub cargarFotos()
        Try
            Dim IDCtrlPal As String = txtID.Text.Trim

            Dim sql As String = "select ID,Nombre from Control_Pallet_Fotos with(nolock) where ID_Control_Pallet='" & IDCtrlPal & "'"
            Dim dt As New DataTable

            dt = fnc.ListarTablasSQL(sql)

            gvArch.DataSource = dt
        Catch ex As Exception
            MsgBox("Ocurrió un error al cargar fotos.", MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub Control_Pallets_Fotos_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        cargarFotos()
    End Sub
End Class
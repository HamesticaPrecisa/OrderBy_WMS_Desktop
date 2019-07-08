Public Class Frm_Locales_Pedidos
    Dim fnc As New Funciones

    Private Sub Btn_BuscaCliente_Click(sender As System.Object, e As System.EventArgs) Handles Btn_BuscaCliente.Click
        Dim frm As New Lst_AyudaClientes
        frm.ShowDialog(Frm_Principal)
        If Frm_Principal.buscavalor <> "" Then
            txtrut.Text = Frm_Principal.buscavalor
            Frm_Principal.buscavalor = ""
            buscarRazSoc()
        End If
    End Sub

    Sub buscarRazSoc()
        Try
            Dim rut = txtrut.Text.Trim.Replace("-", "")

            If (rut <> "") Then
                Dim sql = "select cli_nomb from clientes where cli_rut='" & rut & "'"
                Dim dtCli As DataTable = fnc.ListarTablasSQL(sql)

                If (dtCli.Rows.Count > 0) Then
                    txtrsocial.Text = dtCli.Rows(0).Item(0).ToString.Trim
                    listarLocalesCliente()
                End If
            End If
        Catch ex As Exception
            MsgBox("Ocurrió un error al buscar los datos del Cliente.", MsgBoxStyle.Information, "Error")
        End Try
    End Sub

    Private Sub Frm_Locales_Pedidos_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        f_locs_pedidos = False
    End Sub

    Sub listarLocalesCliente()
        Try
            Dim Rut = txtrut.Text.Trim.Replace("-", "")
            If (Rut <> "") Then
                Dim sql = "SP_Pedidos_Archivos_Locales_Cliente '" & Rut & "'"
                Dim dtResp As DataTable = fnc.ListarTablasSQL(sql)

                dgvLocs.DataSource = dtResp
            End If
        Catch ex As Exception
            MsgBox("Ocurrió un error al buscar los Locales del Cliente", MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub dgvLocs_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLocs.CellClick
        Try
            If (e.RowIndex <> -1) Then
                Dim IDLoc = dgvLocs.Rows(e.RowIndex).Cells(0).Value.ToString.Trim
                Dim CodCli = dgvLocs.Rows(e.RowIndex).Cells(1).Value.ToString.Trim
                Dim NomLoc = dgvLocs.Rows(e.RowIndex).Cells(2).Value.ToString.Trim
                Dim Dir = dgvLocs.Rows(e.RowIndex).Cells(3).Value.ToString.Trim

                txtIdLoc.Text = IDLoc
                txtCodCli.Text = CodCli
                txtNomLoc.Text = NomLoc
                txtDir.Text = Dir
            End If
        Catch ex As Exception
            MsgBox("Ocurrió un error al obtener los datos del Local seleccionado.", MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnLim_Click(sender As System.Object, e As System.EventArgs) Handles btnLim.Click
        limpiar()
    End Sub

    Sub limpiar()
        txtrut.Text = ""
        txtrsocial.Text = ""

        limpiarDatLocal()

        dgvLocs.DataSource = Nothing

        Btn_BuscaCliente.Focus()
    End Sub

    Private Sub btnGra_Click(sender As System.Object, e As System.EventArgs) Handles btnGra.Click
        Try
            Dim IDLoc = txtIdLoc.Text.Trim
            If (IDLoc = "") Then
                IDLoc = "0"
            End If

            Dim Rut = txtrut.Text.Trim.Replace("-", "")
            If (Rut = "") Then
                MsgBox("Debe seleccionar un Cliente.", MsgBoxStyle.Information, "Info. Faltante")
                Btn_BuscaCliente.Focus()
                Exit Sub
            End If

            Dim CodCli = txtCodCli.Text.Trim
            If (CodCli = "") Then
                MsgBox("Debe ingresar un Codigo Cliente para el Local.", MsgBoxStyle.Information, "Info. Faltante")
                txtCodCli.Focus()
                Exit Sub
            End If

            Dim NomLoc = txtNomLoc.Text.Trim
            If (NomLoc = "") Then
                MsgBox("Debe ingresar el Nombre del Local.", MsgBoxStyle.Information, "Info. Faltante")
                txtNomLoc.Focus()
                Exit Sub
            End If

            Dim Dir = txtDir.Text.Trim

            Dim sql = "SP_Locales_Grabar '" & IDLoc & "','" & Rut & "','" & CodCli & "','" & NomLoc & "','" & Dir & "'"
            Dim Resp = fnc.MovimientoSQL(sql)

            If (Resp > 0) Then
                limpiarDatLocal()
                listarLocalesCliente()
            End If
        Catch ex As Exception
            MsgBox("Ocurrió un error al grabar los datos del Local.", MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Sub limpiarDatLocal()
        txtIdLoc.Text = ""
        txtCodCli.Text = ""
        txtNomLoc.Text = ""
        txtDir.Text = ""
        txtCodCli.Focus()
    End Sub

    Private Sub btnSal_Click(sender As System.Object, e As System.EventArgs) Handles btnSal.Click
        Me.Close()
    End Sub

    Private Sub btnEli_Click(sender As System.Object, e As System.EventArgs) Handles btnEli.Click
        Try
            Dim IdLoc = txtIdLoc.Text.Trim
            If (IdLoc <> "") Then
                Dim preg = MsgBox("¿Esta seguro de eliminar este Local?", MsgBoxStyle.YesNo, "¿Esta Seguro?")
                If (preg = MsgBoxResult.Yes) Then
                    Dim sql = "SP_Locales_Eliminar '" & IdLoc & "'"
                    Dim resp = fnc.MovimientoSQL(sql)
                    If (resp > 0) Then
                        MsgBox("Local se elimino exitosamente.", MsgBoxStyle.Information, "Exito")
                        limpiarDatLocal()
                        listarLocalesCliente()
                    Else
                        MsgBox("Ocurrió un error al eliminar el Local.", MsgBoxStyle.Critical, "Error")
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("Ocurrió un error al eliminar el Local.", MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
End Class
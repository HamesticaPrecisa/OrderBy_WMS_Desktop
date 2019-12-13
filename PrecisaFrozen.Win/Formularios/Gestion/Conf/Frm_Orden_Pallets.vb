Imports excel = Microsoft.Office.Interop.Excel

Public Class Frm_Orden_Pallets

    Dim archPed As New ArchivoPedidos
    Dim dtOrdPals As New DataTable
    Dim fnc As New Funciones

    Private Sub btnGra_Click(sender As System.Object, e As System.EventArgs) Handles btnGra.Click
        Try
            Dim ExiErr As Integer = 0
            Dim MsjErr As String = "Errores encontrados:"

            Dim RutCli As String = txtrut.Text.Trim.Replace("-", "")
            If (RutCli = "") Then
                ExiErr += 1
                MsjErr &= vbCrLf & "- Debe seleccionar un cliente."

                Btn_BuscaCliente.Focus()
            End If

            Dim Codusu As String = Frm_Principal.InfoUsuario.Text.Trim

            If (dtOrdPals.Rows.Count = 0) Then
                ExiErr += 1
                MsjErr &= vbCrLf & "- Debe seleccionar un archivo con datos."

                btnFldBrwXls.Focus()
            End If

            If (ExiErr > 0) Then
                MsgBox(MsjErr, MsgBoxStyle.Critical, "Error!")
            Else
                Dim ExiErrReg As Boolean = False

                For i = 0 To dtOrdPals.Rows.Count - 1
                    Dim Pallet As String = dtOrdPals.Rows(i).Item(0).ToString.Trim
                    Dim Caja As String = dtOrdPals.Rows(i).Item(1).ToString.Trim

                    Dim sql As String = "SP_Orden_Pallets_Grabar '','" & RutCli & "','" & Pallet & "','" & Caja & "','" & Codusu & "'"
                    Dim dt As New DataTable

                    dt = fnc.ListarTablasSQL(sql)

                    If (dt.Rows.Count > 0) Then
                        Dim Resp As String = dt.Rows(0).Item(0).ToString.Trim

                        If (Resp = "-1") Then
                            ExiErrReg = True
                        End If
                    Else
                        ExiErrReg = True
                    End If
                Next

                If (ExiErr) Then
                    MsgBox("Ocurrió un error al registrar orden de cajas.", MsgBoxStyle.Critical, "Error!")
                Else
                    MsgBox("Orden de cajas registrado exitosamente.", MsgBoxStyle.Information, "Éxito!")
                    limpiar()
                End If
            End If
        Catch ex As Exception
            MsgBox("Ocurrió un error al registrar orden de cajas.", MsgBoxStyle.Critical, "Error!")
        End Try
    End Sub

    Sub limpiar()
        txtrut.Text = ""
        txtrsocial.Text = ""
        Btn_BuscaCliente.Enabled = True
        limpiar2()
        Btn_BuscaCliente.Focus()
    End Sub

    Sub limpiar2()
        txtPath.Text = ""
        cboPalCli.DataSource = Nothing
        gvCajas.DataSource = Nothing

        Dim dtCbo As New DataTable
        dtCbo.Columns.Add("Pallet")

        Dim row As DataRow = dtCbo.NewRow
        row(0) = "Seleccione Pallet"
        dtCbo.Rows.Add(row)

        cboPalCli.DataSource = dtCbo
        cboPalCli.ValueMember = "Pallet"
        cboPalCli.DisplayMember = "Pallet"
    End Sub

    Private Sub btnFldBrwXls_Click(sender As System.Object, e As System.EventArgs) Handles btnFldBrwXls.Click
        Try
            fldBrwXls.ShowDialog()

            Dim pathArch = fldBrwXls.FileName.Trim

            If (pathArch <> "") Then
                If (archPed.validArchivo(pathArch)) Then
                    txtPath.Text = pathArch.Trim

                    dtOrdPals = leerArchivo(pathArch)

                    If (dtOrdPals.Rows.Count > 0) Then
                        Dim dtCboPals As New DataTable
                        dtCboPals.Columns.Add("Pallet")

                        For i = 0 To dtOrdPals.Rows.Count - 1
                            Dim Pallet As String = dtOrdPals.Rows(i).Item(0).ToString.Trim
                            Dim ExiPal As Boolean = False

                            For j = 0 To dtCboPals.Rows.Count - 1
                                Dim PallCbo As String = dtCboPals.Rows(j).Item(0).ToString.Trim
                                If (Pallet = PallCbo) Then
                                    ExiPal = True
                                End If
                            Next

                            If (Not ExiPal) Then
                                Dim row As DataRow = dtCboPals.NewRow
                                row(0) = Pallet
                                dtCboPals.Rows.Add(row)
                            End If
                        Next

                        Dim row2 As DataRow = dtCboPals.NewRow
                        row2(0) = "Seleccione Pallet"
                        dtCboPals.Rows.InsertAt(row2, 0)

                        cboPalCli.DataSource = dtCboPals
                        cboPalCli.ValueMember = "Pallet"
                        cboPalCli.DisplayMember = "Pallet"

                        gvCajas.DataSource = dtOrdPals
                    Else
                        MsgBox("No se encontraron datos legibles en este archivo.", MsgBoxStyle.Information, "Información")
                    End If
                Else
                    MsgBox("El archivo ingresado no es valido.", MsgBoxStyle.Information, "Formato Incorrecto")
                    limpiar2()
                End If
            End If
        Catch ex As Exception
            MsgBox("Ocurrió un error al leer el archivo.", MsgBoxStyle.Critical, "Error!")
        End Try
    End Sub

    Function leerArchivo(ByVal path As String) As DataTable
        Dim dt As New DataTable
        dt.Columns.Add("Pallet")
        dt.Columns.Add("Caja")

        Try
            Dim xlApp As New excel.Application
            Dim xlWorkBook As excel.Workbook = xlApp.Workbooks.Open(path)
            Dim xlWorkSheet As excel.Worksheet = xlWorkBook.ActiveSheet
            Dim range As excel.Range = xlWorkSheet.UsedRange

            Dim rCnt As Integer
            Dim cCnt As Integer
            Dim Obj As Object

            Dim CodPal As String = ""
            Dim CodCaj As String = ""

            For rCnt = 3 To range.Rows.Count
                Dim row As DataRow = dt.NewRow

                For cCnt = 1 To 2
                    Obj = CType(range.Cells(rCnt, cCnt), excel.Range)

                    Dim valRow As String = ""

                    If (Not IsNothing(Obj.value)) Then
                        valRow = Obj.value.ToString.Trim
                    End If

                    If ((cCnt - 1) = 0 And valRow <> "" And valRow <> "Total general") Then
                        CodPal = valRow
                    ElseIf ((cCnt - 1) = 1) Then
                        CodCaj = valRow
                    ElseIf ((cCnt - 1) = 0 And valRow <> "" And valRow = "Total general") Then
                        CodPal = ""
                    End If
                Next

                If (CodPal <> "") Then
                    row(0) = CodPal
                    row(1) = CodCaj

                    dt.Rows.Add(row)
                Else
                    Exit For
                End If
            Next

            xlWorkBook.Close()
            xlApp.Quit()

            releaseObject(xlApp)
            releaseObject(xlWorkBook)
            releaseObject(xlWorkSheet)
        Catch ex As Exception

        End Try

        Return dt
    End Function

    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

    Private Sub Frm_Orden_Pallets_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        f_OrdPal = False
    End Sub

    Private Sub cboPalCli_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cboPalCli.SelectedValueChanged
        Try
            Dim Pallet As String = cboPalCli.Text.Trim

            If (Pallet = "Seleccione Pallet" Or Pallet = "System.Data.DataRowView") Then
                Pallet = ""
            End If

            Dim dtCajs As New DataTable
            dtCajs.Columns.Add("Pallet")
            dtCajs.Columns.Add("Caja")

            For i = 0 To dtOrdPals.Rows.Count - 1
                Dim Pall As String = dtOrdPals.Rows(i).Item(0).ToString.Trim
                Dim Caj As String = dtOrdPals.Rows(i).Item(1).ToString.Trim

                If (Pall.Contains(Pallet)) Then
                    Dim ExiCaj As Boolean = False

                    For j = 0 To dtCajs.Rows.Count - 1
                        Dim CajDet As String = dtCajs.Rows(j).Item(1).ToString.Trim

                        If (Caj = CajDet) Then
                            ExiCaj = True
                        End If
                    Next

                    If (Not ExiCaj) Then
                        Dim row As DataRow = dtCajs.NewRow
                        row(0) = Pall
                        row(1) = Caj
                        dtCajs.Rows.Add(row)
                    End If
                End If
            Next

            gvCajas.DataSource = dtCajs
        Catch ex As Exception
            MsgBox("Ocurrió un error al filtrar cajas.", MsgBoxStyle.Critical, "Error!")
        End Try
    End Sub

    Private Sub btnLim_Click(sender As System.Object, e As System.EventArgs) Handles btnLim.Click
        limpiar()
    End Sub

    Private Sub Btn_BuscaCliente_Click(sender As System.Object, e As System.EventArgs) Handles Btn_BuscaCliente.Click
        Dim frm As New Lst_AyudaClientes
        frm.ShowDialog(Frm_Principal)
        If Frm_Principal.buscavalor <> "" Then
            txtrut.Text = Frm_Principal.buscavalor
            Frm_Principal.buscavalor = ""
            buscarRazSoc()
            btnFldBrwXls.Enabled = True
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
                End If
            End If
        Catch ex As Exception
            MsgBox("Ocurrió un error al buscar los datos del Cliente.", MsgBoxStyle.Information, "Error")
        End Try
    End Sub
End Class
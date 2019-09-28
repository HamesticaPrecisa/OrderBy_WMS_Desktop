Imports excel = Microsoft.Office.Interop.Excel

Public Class ArchivoPedidos
    Dim fnc As New Funciones

    Function obtenerConfigBD(ByVal Rut As String) As DataSet
        Dim ds As New DataSet

        Try
            Dim dtDat As New DataTable
            dtDat = obtenerDatBD(Rut)

            Dim dtDatClav As New DataTable
            dtDatClav = obtenerDatClavBD(Rut)

            ds.Tables.Add(dtDat)
            ds.Tables.Add(dtDatClav)
        Catch ex As Exception
            Dim dsErr As New DataSet
            Return dsErr
        End Try

        Return ds
    End Function

    Function obtenerDatBD(ByVal Rut As String) As DataTable
        Dim dt As New DataTable

        Try
            Dim sql = "select Columna_Inicial,Fila_Inicial,Orientacion_Lectura,Columna_Titulos,Cantidad_Encabezados,Usa_Separador,Separador_Columna,Separador_Fila from Pedidos_Conf_Archivo with(nolock) where Rut_Cliente='" & Rut & "'"
            dt = fnc.ListarTablasSQL(sql)
        Catch ex As Exception
            Dim dtErr As New DataTable
            Return dtErr
        End Try

        Return dt
    End Function

    Function obtenerDatClavBD(ByVal Rut As String) As DataTable
        Dim dt As New DataTable

        Try
            Dim sql = "select a.Dato,a.Posicion,a.Tabla,a.Campo from Pedidos_Conf_Archivo_Posiciones a with(nolock) inner join Pedidos_Conf_Archivo b with(nolock) on(a.ID_Config=b.ID_Config) where b.Rut_Cliente='" & Rut & "'"
            dt = fnc.ListarTablasSQL(sql)

            Dim dtDatClav As New DataTable

            If (dt.Rows.Count > 0) Then
                For i = 0 To dt.Columns.Count - 1
                    Dim NomCol = dt.Columns(i).ColumnName.Trim
                    dtDatClav.Columns.Add(NomCol)
                Next

                For i = 0 To dt.Rows.Count - 1
                    Dim dat = dt.Rows(i).Item(0).ToString.Trim
                    Dim pos = dt.Rows(i).Item(1).ToString.Trim
                    Dim tab = dt.Rows(i).Item(2).ToString.Trim
                    Dim cam = dt.Rows(i).Item(3).ToString.Trim

                    Dim row As DataRow = dtDatClav.NewRow
                    row(0) = dat
                    row(1) = pos
                    row(2) = tab
                    row(3) = cam
                    dtDatClav.Rows.Add(row)
                Next
            End If

            Return dtDatClav
        Catch ex As Exception
            Dim dtErr As New DataTable
            Return dtErr
        End Try

        Return dt
    End Function

    Function validArchivo(ByVal path As String) As Boolean
        Dim Resp As Boolean = False

        Try
            If (path <> "") Then
                Dim pathAux = path.Split("\")
                Dim pathLen = pathAux.Length - 1
                Dim NomArch = pathAux(pathLen)
                Dim NomArchAux = NomArch.Split(".")
                Dim Ext = NomArchAux(1).ToLower

                If (Ext = "xls" Or Ext = "xlsx" Or Ext = "csv") Then
                    Resp = True
                End If
            End If
        Catch ex As Exception

        End Try

        Return Resp
    End Function

    Function leerArchPedido(ByVal path As String, ByVal dsConfArch As DataSet) As DataTable
        Dim dtPrev As New DataTable

        Try
            If (path <> "") Then
                Dim OriLec = dsConfArch.Tables(0).Rows(0).Item(2).ToString.Trim
                Dim ColIni = CInt(dsConfArch.Tables(0).Rows(0).Item(0).ToString.Trim) + 1
                Dim FilIni = CInt(dsConfArch.Tables(0).Rows(0).Item(1).ToString.Trim) + 1
                Dim ColTit = dsConfArch.Tables(0).Rows(0).Item(3).ToString.Trim
                If (OriLec = "H" And ColTit = "1") Then
                    FilIni += 1
                ElseIf (OriLec = "V" And ColTit = "1") Then
                    ColIni += 1
                End If
                Dim UsaSep = dsConfArch.Tables(0).Rows(0).Item(5).ToString.Trim
                Dim SepCol = dsConfArch.Tables(0).Rows(0).Item(6).ToString.Trim
                Dim SepFil = dsConfArch.Tables(0).Rows(0).Item(7).ToString.Trim
                Dim CanEnc = dsConfArch.Tables(0).Rows(0).Item(4).ToString.Trim

                Dim xlApp As New excel.Application
                Dim xlWorkBook As excel.Workbook = xlApp.Workbooks.Open(path)
                Dim xlWorkSheet As excel.Worksheet = xlWorkBook.ActiveSheet
                Dim range As excel.Range = xlWorkSheet.UsedRange

                Dim rCnt As Integer
                Dim cCnt As Integer
                Dim Obj As Object

                Dim dt As New DataTable

                For i = 0 To dsConfArch.Tables(1).Rows.Count - 1
                    Dim Dat = dsConfArch.Tables(1).Rows(i).Item(0).ToString.Trim
                    Dim Pos = dsConfArch.Tables(1).Rows(i).Item(1).ToString.Trim

                    If (Pos <> "") Then
                        dt.Columns.Add(Dat)
                    End If
                Next

                If (UsaSep = "0") Then
                    If (OriLec = "H") Then
                        For rCnt = FilIni To range.Rows.Count
                            Dim row As DataRow = dt.NewRow

                            Dim filContDat As Boolean = True

                            For cCnt = ColIni To CanEnc
                                Dim colNom As String = ""

                                For j = 0 To dsConfArch.Tables(1).Rows.Count - 1
                                    Dim Pos = (cCnt - 1).ToString.Trim
                                    Dim NomDt = dsConfArch.Tables(1).Rows(j).Item(0).ToString.Trim
                                    Dim PosDt = dsConfArch.Tables(1).Rows(j).Item(1).ToString.Trim

                                    If (Pos = PosDt) Then
                                        colNom = NomDt
                                    End If
                                Next

                                If (colNom <> "") Then
                                    Obj = CType(range.Cells(rCnt, cCnt), excel.Range)

                                    Dim valRow As String = ""

                                    If (Not IsNothing(Obj.value)) Then
                                        If (colNom = "Hora") Then
                                            valRow = DateTime.FromOADate(Obj.value.ToString.Trim).ToString("HH:mm")
                                        ElseIf (colNom = "Fecha") Then
                                            valRow = CDate(Obj.value.ToString.Trim).ToString("dd/MM/yyyy")
                                        Else
                                            valRow = Obj.value.ToString.Trim
                                        End If
                                    Else
                                        filContDat = False
                                    End If

                                    row(colNom) = valRow
                                End If
                            Next

                            If (filContDat) Then
                                dt.Rows.Add(row)
                            End If
                        Next
                    Else
                        For rCnt = ColIni To range.Columns.Count
                            Dim row As DataRow = dt.NewRow

                            For cCnt = FilIni To CanEnc
                                Dim colNom As String = ""

                                For j = 0 To dsConfArch.Tables(1).Rows.Count - 1
                                    Dim Pos = (cCnt - 1).ToString.Trim
                                    Dim NomDt = dsConfArch.Tables(1).Rows(j).Item(0).ToString.Trim
                                    Dim PosDt = dsConfArch.Tables(1).Rows(j).Item(1).ToString.Trim

                                    If (Pos = PosDt) Then
                                        colNom = NomDt
                                    End If
                                Next

                                If (colNom <> "") Then
                                    Obj = CType(range.Cells(cCnt, rCnt), excel.Range)

                                    Dim valRow As String = ""

                                    If (colNom = "Hora") Then
                                        valRow = DateTime.FromOADate(Obj.value.ToString.Trim).ToString("HH:mm")
                                    ElseIf (colNom = "Fecha") Then
                                        valRow = CDate(Obj.value.ToString.Trim).ToString("dd/MM/yyyy")
                                    Else
                                        valRow = Obj.value.ToString.Trim
                                    End If

                                    row(colNom) = valRow
                                End If
                            Next

                            dt.Rows.Add(row)
                        Next
                    End If
                End If

                xlWorkBook.Close()
                xlApp.Quit()

                releaseObject(xlApp)
                releaseObject(xlWorkBook)
                releaseObject(xlWorkSheet)

                dtPrev = dt
            End If
        Catch ex As Exception
            MsgBox("Ocurrió un error al generar la vista previa del archivo.", MsgBoxStyle.Critical, "Error")
            Dim dtErr As New DataTable
            Return dtErr
        End Try

        Return dtPrev
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
End Class

Public Class Frm_Pedidos_Xls
    Dim archPed As New ArchivoPedidos
    Dim fnc As New Funciones

    Private Sub Frm_Pedidos_Xls_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        f_pedidos_xls = False
    End Sub

    Private Sub btnFldBrwXls_Click(sender As System.Object, e As System.EventArgs) Handles btnFldBrwXls.Click
        fldBrwXls.ShowDialog()

        Dim pathArch = fldBrwXls.FileName.Trim

        If (pathArch <> "") Then
            If (archPed.validArchivo(pathArch)) Then
                txtPath.Text = pathArch.Trim

                Dim rut = txtrut.Text.Trim.Replace("-", "")
                If (rut <> "") Then
                    Dim dtPrev As DataTable = archPed.leerArchPedido(pathArch, archPed.obtenerConfigBD(rut))
                    dgvPrevXls.DataSource = dtPrev

                    totalesArchPed(dtPrev)
                End If
            Else
                MsgBox("El archivo ingresado no es valido.", MsgBoxStyle.Information, "Formato Incorrecto")
                limpiar()
            End If
        End If
    End Sub

    Private Sub btnLim_Click(sender As System.Object, e As System.EventArgs)
        limpiar()
    End Sub

    Sub limpiar()
        txtrut.Text = ""
        txtrsocial.Text = ""
        txtPath.Text = ""
        btnFldBrwXls.Enabled = False
        dgvPrevXls.DataSource = Nothing

        txtTotLoc.Text = ""
        txtTotPal.Text = ""
        txtTotCaj.Text = ""

        btnFldBrwXls.Focus()
    End Sub

    Sub grabarDetallePedido(ByVal Ord As String, ByVal fechCab As String, ByVal dtArch As DataTable)
        Try
            Dim linea As String = 1

            For x = 0 To dtArch.Rows.Count - 1
                Dim grabarDet As Boolean = False

                For y = 0 To dtArch.Columns.Count - 1
                    Dim datArch = dtArch.Columns(y).ColumnName.Trim
                    Dim valArch = dtArch.Rows(x).Item(y).ToString.Trim

                    If (datArch = "Fecha" And valArch = fechCab) Then
                        grabarDet = True
                    End If
                Next

                If (grabarDet) Then
                    Dim FolCli = ""
                    Dim Fol = ""
                    Dim Uni = "0"
                    Dim IDLoc = "0"

                    For y = 0 To dtArch.Columns.Count - 1
                        Dim datArch = dtArch.Columns(y).ColumnName.Trim
                        Dim valArch = dtArch.Rows(x).Item(y).ToString.Trim

                        If (datArch = "Folio_Cliente") Then
                            FolCli = valArch
                        ElseIf (datArch = "Folio") Then
                            Fol = valArch
                        ElseIf (datArch = "Unidades") Then
                            Uni = valArch
                        ElseIf (datArch = "Local") Then
                            IDLoc = valArch
                        End If
                    Next

                    Dim sql = "sp_Pedidos_detalle_Desde_Archivo_Grabar '" & Ord & "','" & Fol & "','" & FolCli & "','" & Uni & "','" & linea & "','" & Frm_Principal.InfoUsuario.Text.Trim & "'"
                    Dim resp = fnc.MovimientoSQL(sql)

                    Dim Rut = txtrut.Text.Trim.Replace("-", "")

                    sql = "SP_Pedidos_Local_Grabar '" & Rut & "','" & Ord & "','" & IDLoc & "','" & FolCli & "','" & Fol & "','" & linea & "'"
                    resp = fnc.MovimientoSQL(sql)

                    linea += 1
                End If
            Next
        Catch ex As Exception
            MsgBox("Ocurrió un error al grabar detalle del Pedido", MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Sub totalesArchPed(ByVal dtArch As DataTable)
        Try
            Dim dtLocales As New DataTable
            Dim dtPalls As New DataTable

            dtLocales.Columns.Add("Local")

            dtPalls.Columns.Add("Folio")
            dtPalls.Columns.Add("Folio_Cliente")
            dtPalls.Columns.Add("TotalCajas")

            For i = 0 To dtArch.Rows.Count - 1
                Dim rowLoc As DataRow = dtLocales.NewRow
                Dim rowPal As DataRow = dtPalls.NewRow

                rowLoc(0) = ""

                rowPal(0) = ""
                rowPal(1) = "0"

                For j = 0 To dtArch.Columns.Count - 1
                    Dim tit = dtArch.Columns(j).ColumnName.Trim
                    Dim val = dtArch.Rows(i).Item(j).ToString.Trim

                    If (tit = "Local") Then
                        rowLoc(0) = val
                    ElseIf (tit = "Folio") Then
                        rowPal(0) = val

                        Dim sqlFolCli = "SP_Pedidos_Archivos_Obtener_Folios '" & val & "',''"
                        Dim dtResFolCli As DataTable = fnc.ListarTablasSQL(sqlFolCli)
                        If (dtResFolCli.Rows.Count > 0 And rowPal(1) = "") Then
                            rowPal(1) = dtResFolCli.Rows(0).Item(0).ToString.Trim
                        End If
                    ElseIf (tit = "Folio_Cliente") Then
                        rowPal(1) = val

                        Dim sqlFolCli = "SP_Pedidos_Archivos_Obtener_Folios '','" & val & "'"
                        Dim dtResFolCli As DataTable = fnc.ListarTablasSQL(sqlFolCli)
                        If (dtResFolCli.Rows.Count > 0 And rowPal(0) = "") Then
                            rowPal(0) = dtResFolCli.Rows(0).Item(0).ToString.Trim
                        End If
                    ElseIf (tit = "Unidades") Then
                        rowPal(2) = val
                    End If
                Next

                Dim NoExiLoc As Boolean = True
                Dim nroFilLoc = dtLocales.Rows.Count - 1

                If (nroFilLoc >= 0) Then
                    For x = 0 To nroFilLoc
                        Dim Loc = dtLocales.Rows(x).Item(0).ToString.Trim
                        Dim LocRow = rowLoc.Item(0).ToString.Trim

                        If (Loc = LocRow) Then
                            NoExiLoc = False
                        End If
                    Next
                End If

                If (NoExiLoc) Then
                    dtLocales.Rows.Add(rowLoc)
                End If

                Dim NoExiFol As Boolean = True
                Dim nroFilFol = dtPalls.Rows.Count - 1

                If (nroFilFol >= 0) Then
                    For x = 0 To nroFilFol
                        Dim Fol = dtPalls.Rows(x).Item(0).ToString.Trim
                        Dim FolCli = dtPalls.Rows(x).Item(1).ToString.Trim
                        Dim Uni = CDbl(dtPalls.Rows(x).Item(2).ToString.Trim)

                        Dim FolRow = rowPal.Item(0).ToString.Trim
                        Dim FolCliRow = rowPal.Item(1).ToString.Trim
                        Dim UniRow = CDbl(rowPal.Item(2).ToString.Trim)

                        If (Fol = FolRow) Then
                            dtPalls.Rows(x).Item(2) = Uni + UniRow
                            NoExiFol = False
                        End If
                    Next
                End If

                If (NoExiFol) Then
                    dtPalls.Rows.Add(rowPal)
                End If
            Next

            Dim SumLocs = dtLocales.Rows.Count
            txtTotLoc.Text = SumLocs

            Dim SumPals = dtPalls.Rows.Count
            txtTotPal.Text = SumPals

            Dim SumUnis As Double = 0

            For i = 0 To dtPalls.Rows.Count - 1
                Dim Uni = CDbl(dtPalls.Rows(i).Item(2).ToString.Trim)
                SumUnis = SumUnis + Uni
            Next

            txtTotCaj.Text = SumUnis
        Catch ex As Exception
            MsgBox("Ocurrió un erro al obtener los Totales del Archivo", MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Function validArchPed(ByVal dtArch As DataTable) As Boolean
        Dim Resp As Boolean = False

        Try
            Dim Rut = txtrut.Text.Trim.Replace("-", "")

            Dim Loc = ""
            Dim Fol = ""
            Dim FolCli = ""
            Dim CodPro = ""
            Dim Uni = ""

            Dim MensajeErr = ""

            Dim dtDetPals As New DataTable
            dtDetPals.Columns.Add("Folio")
            dtDetPals.Columns.Add("Folio_Cliente")
            dtDetPals.Columns.Add("Unidades")

            For i = 0 To dtArch.Rows.Count - 1
                Dim detPalsRow As DataRow = dtDetPals.NewRow

                detPalsRow(0) = ""
                detPalsRow(1) = ""
                detPalsRow(2) = ""

                For j = 0 To dtArch.Columns.Count - 1
                    Dim tit = dtArch.Columns(j).ColumnName.Trim
                    Dim val = dtArch.Rows(i).Item(j).ToString.Trim

                    If (tit = "Local") Then
                        Loc = val
                    ElseIf (tit = "Folio") Then
                        Fol = val

                        detPalsRow(0) = val
                    ElseIf (tit = "Folio_Cliente") Then
                        FolCli = val

                        detPalsRow(1) = val
                    ElseIf (tit = "Codigo_Producto") Then
                        CodPro = val
                    ElseIf (tit = "Unidades") Then
                        Uni = val

                        detPalsRow(2) = val
                    End If
                Next

                Dim NumRowsDetPal = dtDetPals.Rows.Count - 1

                If (NumRowsDetPal >= 0) Then
                    Dim exiPal As Boolean = False
                    Dim PalIdx As Integer = -1

                    Dim PalRow = detPalsRow.Item(0).ToString.Trim
                    Dim PalCliRow = detPalsRow.Item(1).ToString.Trim
                    Dim UnisPalRow = detPalsRow.Item(2).ToString.Trim

                    For z = 0 To NumRowsDetPal
                        Dim Pal = dtDetPals.Rows(z).Item(0).ToString.Trim
                        Dim PalCli = dtDetPals.Rows(z).Item(1).ToString.Trim
                        Dim UnisPal = dtDetPals.Rows(z).Item(2).ToString.Trim

                        If (Pal = PalRow And PalCli = PalCli) Then
                            exiPal = True
                            PalIdx = z
                        End If
                    Next

                    If (exiPal And PalIdx <> -1) Then
                        Dim UnisPal = dtDetPals.Rows(PalIdx).Item(2).ToString.Trim

                        dtDetPals.Rows(PalIdx).Item(2) = CDbl(UnisPal) + CDbl(UnisPalRow)
                    Else
                        dtDetPals.Rows.Add(detPalsRow)
                    End If
                Else
                    dtDetPals.Rows.Add(detPalsRow)
                End If

                Dim sql = "sp_Pedidos_Archivos_Validar '" & Rut & "','" & Loc & "','" & Fol & "','" & FolCli & "','" & CodPro & "','" & Uni & "'"
                Dim dtResp As DataTable = fnc.ListarTablasSQL(sql)

                Dim ResSql = "-1"
                If (dtResp.Rows.Count > 0) Then
                    ResSql = dtResp.Rows(0).Item(0).ToString.Trim
                End If

                If (ResSql = "-1") Then
                    MensajeErr = MensajeErr & "- Ocurrió un error al validar los datos del archivo" & vbCrLf
                    Resp = True
                ElseIf (ResSql = "1") Then
                    MensajeErr = MensajeErr & "- El Folio Cliente no corresponde al Folio ingresado. (Fila: " & i + 1 & ")" & vbCrLf
                    Resp = True
                ElseIf (ResSql = "2") Then
                    MensajeErr = MensajeErr & "- No se encontro el codigo del Local. (Fila: " & i + 1 & ")" & vbCrLf
                    Resp = True
                ElseIf (ResSql = "3") Then
                    MensajeErr = MensajeErr & "- El Codigo del Producto no corresponde al Folio ingresado. (Fila: " & i + 1 & ")" & vbCrLf
                    Resp = True
                ElseIf (ResSql = "4") Then
                    Dim UniDisp = dtResp.Rows(0).Item(1).ToString.Trim
                    MensajeErr = MensajeErr & "- No hay Stock suficiente para cubrir el pedido. Unidades disponibles: " & UniDisp & ". Unidades Pedido: " & Uni & ". (Fila: " & i + 1 & ")" & vbCrLf
                    Resp = True
                ElseIf (ResSql = "5") Then
                    MensajeErr = MensajeErr & "- El Folio ingresado no corresponde a este Cliente. (Fila: " & i + 1 & ")" & vbCrLf
                    Resp = True
                End If
            Next

            For i = 0 To dtDetPals.Rows.Count - 1
                Dim FolPal = dtDetPals.Rows(i).Item(0).ToString.Trim
                Dim FolCliPal = dtDetPals.Rows(i).Item(1).ToString.Trim
                Dim UnisPal = dtDetPals.Rows(i).Item(2).ToString.Trim

                Dim sqlDetPals = "sp_Pedidos_Archivos_Validar_Pallets '" & FolPal & "','" & FolCliPal & "','" & UnisPal & "'"
                Dim dtRespDet As DataTable = fnc.ListarTablasSQL(sqlDetPals)
                If (dtRespDet.Rows.Count > 0) Then
                    Dim RespDet = dtRespDet.Rows(0).Item(0).ToString.Trim

                    If (RespDet = "1") Then
                        Dim UniDisPal = dtRespDet.Rows(0).Item(1).ToString.Trim

                        If (FolPal <> "") Then
                            MensajeErr = MensajeErr & "- No hay stock suficiente para cubrir el pedido del Folio " & FolPal & ". Unidades disponibles: " & UniDisPal & ". Unidades Pedido: " & UnisPal & "." & vbCrLf
                        Else
                            MensajeErr = MensajeErr & "- No hay stock suficiente para cubrir el pedido del Folio Cliente" & FolCliPal & ". Unidades disponibles: " & UniDisPal & ". Unidades Pedido: " & UnisPal & "." & vbCrLf
                        End If

                        Resp = True
                    End If
                Else
                    If (FolPal <> "") Then
                        MensajeErr = MensajeErr & "- Ocurrió un error al verificar el stock del Folio: " & FolPal & "" & vbCrLf
                    Else
                        MensajeErr = MensajeErr & "- Ocurrió un error al verificar el stock del Folio Cliente: " & FolCliPal & "" & vbCrLf
                    End If

                    Resp = True
                End If
            Next

            If (Resp) Then
                MensajeErr = MensajeErr & vbCrLf & "Debe corregir el archivo del pedido y volver a intentar."

                MsgBox(MensajeErr, MsgBoxStyle.Critical, "Error")

                txtPath.Text = ""
                dgvPrevXls.DataSource = Nothing

                txtTotPal.Text = ""
                txtTotLoc.Text = ""
                txtTotCaj.Text = ""

                btnFldBrwXls.Focus()
            End If
        Catch ex As Exception
            MsgBox("Ocurrió un error al validar los datos del archivo", MsgBoxStyle.Critical, "Error")
            Resp = True
        End Try

        Return Resp
    End Function

    Private Sub btnGra_Click(sender As System.Object, e As System.EventArgs) Handles btnGra.Click
        Try
            Dim pathArch = txtPath.Text.Trim

            Dim rut = txtrut.Text.Trim.Replace("-", "")
            If (rut = "") Then
                MsgBox("Debe seleccionar un Cliente.", MsgBoxStyle.Critical, "Error")
                Exit Sub
            End If

            If (pathArch <> "") Then
                Dim dtArch As DataTable = archPed.leerArchPedido(pathArch, archPed.obtenerConfigBD(rut))

                If (validArchPed(dtArch)) Then
                    Exit Sub
                End If

                Dim dtConfClav As DataTable = archPed.obtenerDatClavBD(rut)

                grabarPedidosLocales(dtArch)

                'Exit Sub

                'Dim ds As New DataSet

                'Dim dtCab As New DataTable

                'For i = 0 To dtConfClav.Rows.Count - 1
                '    Dim tab = dtConfClav.Rows(i).Item(2).ToString.Trim
                '    Dim dat = dtConfClav.Rows(i).Item(0).ToString.Trim

                '    If (tab = "Pedidos_ficha") Then
                '        dtCab.Columns.Add(dat)
                '    End If
                'Next

                'For j = 0 To dtArch.Rows.Count - 1
                '    Dim rowCab As DataRow = dtCab.NewRow

                '    For i = 0 To dtArch.Columns.Count - 1
                '        Dim dat = dtArch.Columns(i).ColumnName

                '        For x = 0 To dtCab.Columns.Count - 1
                '            Dim datCab = dtCab.Columns(x).ColumnName.Trim

                '            If (dat = datCab) Then
                '                Dim val = dtArch.Rows(j).Item(i).ToString.Trim
                '                rowCab(x) = val
                '            End If
                '        Next
                '    Next

                '    Dim ExiFil As Boolean = True

                '    For y = 0 To dtCab.Rows.Count - 1
                '        Dim FilIgual As Boolean = True

                '        For z = 0 To dtCab.Columns.Count - 1
                '            If (dtCab.Rows(y).Item(z).ToString.Trim <> rowCab(z)) Then
                '                FilIgual = False
                '            End If
                '        Next

                '        ExiFil = Not FilIgual
                '    Next

                '    If (ExiFil) Then
                '        dtCab.Rows.Add(rowCab)
                '    End If
                'Next

                'Dim err As Boolean = True

                ''Dim Ords() As String
                ''Dim Peds() As String

                'For i = 0 To dtCab.Rows.Count - 1
                '    Dim sqlPedFich = "insert into Pedidos_ficha(codvig,terminado,fechapedido,ped_estpred,ped_revision,ped_enviado,ped_carga,cliente,pedido"

                '    Dim camps = ""
                '    Dim vars = ""

                '    Dim conHra As Boolean = False

                '    For j = 0 To dtConfClav.Rows.Count - 1
                '        Dim dat = dtConfClav.Rows(j).Item(0).ToString.Trim
                '        Dim tab = dtConfClav.Rows(j).Item(2).ToString.Trim
                '        Dim cam = dtConfClav.Rows(j).Item(3).ToString.Trim

                '        Dim var = ""

                '        If (tab = "Pedidos_ficha") Then
                '            camps = camps & "," & cam

                '            For y = 0 To dtCab.Columns.Count - 1
                '                Dim tit = dtCab.Columns(y).ColumnName.Trim

                '                If (tit = dat) Then
                '                    var = dtCab.Rows(i).Item(y).ToString.Trim

                '                    If (tit = "Fecha") Then
                '                        var = var.Replace("-", "/")
                '                    ElseIf (tit = "Hora") Then
                '                        conHra = True
                '                    End If
                '                End If
                '            Next

                '            If (tab = "Pedidos_ficha") Then
                '                vars = vars & ",'" & var & "'"
                '            End If
                '        End If
                '    Next

                '    If (conHra) Then
                '        sqlPedFich = sqlPedFich & camps & ") values('0','0',getdate(),'0','0','0','Manual','" & rut & "',CONVERT(varchar,GETDATE(),112)+replace(CONVERT(varchar,getdate(),108),':','')+'" & rut & "'" & vars & "); select Orden=@@IDENTITY;"
                '    Else
                '        sqlPedFich = sqlPedFich & camps & ",hora) values('0','0',getdate(),'0','0','0','Manual','" & rut & "',CONVERT(varchar,GETDATE(),112)+replace(CONVERT(varchar,getdate(),108),':','')+'" & rut & "'" & vars & ",Left(CONVERT(varchar,dateadd(hour,1,GETDATE()),108),5)); select Orden=@@IDENTITY;"
                '    End If

                '    Dim dtOrd As DataTable = fnc.ListarTablasSQL(sqlPedFich)

                '    Dim Ord = ""
                '    If (dtOrd.Rows.Count > 0) Then
                '        Ord = dtOrd.Rows(0).Item(0).ToString.Trim
                '    End If

                '    If (Ord <> "") Then
                '        'Dim Pedido = ""
                '        'Dim sqlPed = "SP_Pedidos_Obtener_Pedido_Orden '" & Ord & "'"
                '        'Dim dtPed As DataTable = fnc.ListarTablasSQL(sqlPed)

                '        'If (dtPed.Rows.Count > 0) Then
                '        '    Pedido = dtPed.Rows(0).Item(0).ToString.Trim
                '        'End If

                '        'Dim IdPedLoc = grabarPedidoLocal(Ord, dtCab.Rows(i).Item(0).ToString.Trim, dtArch)
                '        'If (IdPedLoc <> "-1") Then
                '        grabarDetallePedido(Ord, dtCab.Rows(i).Item(0).ToString.Trim, dtArch)
                '        'Else
                '        '    MsgBox("Ocurrió un error grabar el Pedido por Local.", MsgBoxStyle.Critical, "Error")
                '        '    err = False
                '        'End If

                '        'Ords(i) = Ord
                '        'Peds(i) = Pedido
                '    Else
                '        MsgBox("Ocurrió un error al Generar el Pedido", MsgBoxStyle.Critical, "Error")
                '        err = False
                '    End If
                'Next

                'If (err) Then
                '    Dim mensaje = "Pedido generado exitosamente."
                '    'For i = 0 To Ords.Length - 1
                '    '    mensaje = "\n" & mensaje & i + 1 & ".- Orden: " & Ords(i) & " - Pedido: " & Peds(i)
                '    'Next

                '    MsgBox("Pedido generado exitosamente.", MsgBoxStyle.Information, "Exito")
                '    limpiar()
                'End If
            End If
        Catch ex As Exception
            MsgBox("Ocurrió un error al Generar el Pedido", MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Sub grabarPedidosLocales(ByVal dtArch As DataTable)
        Try
            Dim dtFecs As New DataTable
            dtFecs.Columns.Add("Fecha")

            Dim dtDats As New DataTable
            dtDats.Columns.Add("Fecha")
            dtDats.Columns.Add("Folio")
            dtDats.Columns.Add("Unidades")

            Dim dtDetsLoc As New DataTable
            dtDetsLoc.Columns.Add("Fecha")
            dtDetsLoc.Columns.Add("Folio")
            dtDetsLoc.Columns.Add("Local")
            dtDetsLoc.Columns.Add("Unidades")

            Dim posFec As Integer = -1
            Dim posFol As Integer = -1
            Dim posUni As Integer = -1
            Dim posLoc As Integer = -1

            For i = 0 To dtArch.Columns.Count - 1
                Dim dat = dtArch.Columns(i).ColumnName.Trim
                Dim pos = i

                If (dat = "Fecha") Then
                    posFec = pos
                ElseIf (dat = "Folio") Then
                    posFol = pos
                ElseIf (dat = "Unidades") Then
                    posUni = pos
                ElseIf (dat = "Local") Then
                    posLoc = pos
                End If
            Next

            If (posFec <> -1 And posFol <> -1 And posUni <> -1 And posLoc <> -1) Then
                For i = 0 To dtArch.Rows.Count - 1
                    Dim fecNue As Boolean = True
                    Dim datNue As Boolean = True
                    Dim datLocNue As Boolean = True

                    Dim fecArch = dtArch.Rows(i).Item(posFec).ToString.Trim
                    Dim folArch = dtArch.Rows(i).Item(posFol).ToString.Trim
                    Dim UniArch = dtArch.Rows(i).Item(posUni).ToString.Trim
                    Dim LocArch = dtArch.Rows(i).Item(posLoc).ToString.Trim

                    For j = 0 To dtFecs.Rows.Count - 1
                        Dim fec = dtFecs.Rows(j).Item(0).ToString.Trim

                        If (fec = fecArch) Then
                            fecNue = False
                        End If
                    Next

                    If (fecNue) Then
                        Dim rowFec As DataRow = dtFecs.NewRow
                        rowFec(0) = fecArch
                        dtFecs.Rows.Add(rowFec)
                    End If

                    For j = 0 To dtDats.Rows.Count - 1
                        Dim fec = dtDats.Rows(j).Item(0).ToString.Trim
                        Dim fol = dtDats.Rows(j).Item(1).ToString.Trim
                        Dim Uni = dtDats.Rows(j).Item(2).ToString.Trim

                        If (fecArch = fec And folArch = fol) Then
                            datNue = False

                            dtDats.Rows(j).Item(2) = CInt(dtDats.Rows(j).Item(2).ToString.Trim) + CInt(UniArch)
                        End If
                    Next

                    If (datNue) Then
                        Dim rowDat As DataRow = dtDats.NewRow
                        rowDat(0) = fecArch
                        rowDat(1) = folArch
                        rowDat(2) = UniArch
                        dtDats.Rows.Add(rowDat)
                    End If

                    For j = 0 To dtDetsLoc.Rows.Count - 1
                        Dim fec = dtDetsLoc.Rows(j).Item(0).ToString.Trim
                        Dim fol = dtDetsLoc.Rows(j).Item(1).ToString.Trim
                        Dim loc = dtDetsLoc.Rows(j).Item(2).ToString.Trim
                        Dim Uni = dtDetsLoc.Rows(j).Item(3).ToString.Trim

                        If (fecArch = fec And folArch = fol And loc = LocArch) Then
                            datLocNue = False

                            dtDetsLoc.Rows(j).Item(3) = CInt(dtDats.Rows(j).Item(3).ToString.Trim) + CInt(UniArch)
                        End If
                    Next

                    If (datLocNue) Then
                        Dim rowDatLoc As DataRow = dtDetsLoc.NewRow
                        rowDatLoc(0) = fecArch
                        rowDatLoc(1) = folArch
                        rowDatLoc(2) = LocArch
                        rowDatLoc(3) = UniArch
                        dtDetsLoc.Rows.Add(rowDatLoc)
                    End If
                Next

                Dim rut = txtrut.Text.Trim.Replace("-", "")

                Dim OrdsGen As String = ""

                For i = 0 To dtFecs.Rows.Count - 1
                    Dim fec = dtFecs.Rows(i).Item(0).ToString.Trim.Replace("-", "/")
                    Dim sqlPedFich = "SP_Pedidos_Locales_Ficha_Grabar '" & rut & "','" & fec & "','" & Frm_Principal.InfoUsuario.Text.Trim & "'"
                    Dim dtOrd As DataTable = fnc.ListarTablasSQL(sqlPedFich)

                    If (dtOrd.Rows.Count > 0) Then
                        Dim Ord = dtOrd.Rows(0).Item(0).ToString.Trim
                        Dim Linea As Integer = 0

                        For j = 0 To dtDats.Rows.Count - 1
                            Dim FecDet = dtDats.Rows(j).Item(0).ToString.Trim.Replace("-", "/")

                            If (fec = FecDet) Then
                                Linea += 1

                                Dim FolDet = dtDats.Rows(j).Item(1).ToString.Trim
                                Dim UniDet = dtDats.Rows(j).Item(2).ToString.Trim

                                Dim sqlPedDet = "sp_Pedidos_detalle_Desde_Archivo_Grabar '" & Ord & "','" & FolDet & "','','" & UniDet & "','" & Linea & "','" & Frm_Principal.InfoUsuario.Text.Trim & "'"
                                
                                If (fnc.MovimientoSQL(sqlPedDet) > 0) Then
                                    For x = 0 To dtDetsLoc.Rows.Count - 1
                                        Dim fecLoc = dtDetsLoc.Rows(x).Item(0).ToString.Trim.Replace("-", "/")
                                        Dim FolLoc = dtDetsLoc.Rows(x).Item(1).ToString.Trim

                                        If (fec = fecLoc And FolDet = FolLoc) Then
                                            Dim Loc = dtDetsLoc.Rows(x).Item(2).ToString.Trim
                                            Dim UniLoc = dtDetsLoc.Rows(x).Item(3).ToString.Trim

                                            Dim sqlPedLoc = "SP_Pedidos_Local_Grabar '" & rut & "','" & Ord & "','" & Loc & "','','" & FolLoc & "','" & UniLoc & "','" & Linea & "'"
                                            If (fnc.MovimientoSQL(sqlPedLoc) = 0) Then
                                                MsgBox("Ocurrió un error al grabar el Local del Pedido.", MsgBoxStyle.Critical, "Error")
                                            End If
                                        End If
                                    Next
                                Else
                                    MsgBox("Ocurrió un error al grabar el Detalle del Pedido.", MsgBoxStyle.Critical, "Error")
                                End If
                            End If
                        Next

                        If (OrdsGen = "") Then
                            OrdsGen &= Ord
                        Else
                            OrdsGen &= "," & Ord
                        End If
                    Else
                        MsgBox("Ocurrió un error al grabar la Ficha del Pedido.", MsgBoxStyle.Critical, "Error")
                    End If

                    System.Threading.Thread.Sleep(1000)
                Next

                If (OrdsGen <> "") Then
                    Dim Ords = OrdsGen.Split(",")
                    Dim Msj = "Pedidos generados con exito: " & vbCrLf

                    For i = 0 To Ords.Length - 1
                        Msj &= "- " & Ords(i) & vbCrLf
                    Next

                    MsgBox(Msj, MsgBoxStyle.Information, "Exito")
                    limpiar()
                Else
                    MsgBox("No se generó ningun Pedido.", MsgBoxStyle.Critical, "Error")
                End If
            Else
                MsgBox("Ocurrió un error al separar Pedidos.", MsgBoxStyle.Critical, "Error")
            End If
        Catch ex As Exception
            MsgBox("Ocurrió un error al separar Pedidos.", MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnLim_Click_1(sender As System.Object, e As System.EventArgs) Handles btnLim.Click
        limpiar()
    End Sub

    Private Sub btnSal_Click(sender As System.Object, e As System.EventArgs) Handles btnSal.Click
        Me.Close()
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
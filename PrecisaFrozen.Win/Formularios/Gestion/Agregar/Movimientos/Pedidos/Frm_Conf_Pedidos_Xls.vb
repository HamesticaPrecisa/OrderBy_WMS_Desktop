Public Class Frm_Conf_Pedidos_Xls

    Dim fnc As New Funciones
    Dim archPed As New ArchivoPedidos

    Private Sub Frm_Conf_Pedidos_Xls_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        f_conf_pedidos_xls = False
    End Sub

    Private Sub btnSal_Click(sender As System.Object, e As System.EventArgs) Handles btnSal.Click
        Me.Close()
    End Sub

    Private Sub btnLim_Click(sender As System.Object, e As System.EventArgs) Handles btnLim.Click
        limpiar()
    End Sub

    Sub limpiar()
        txtrut.Text = ""
        txtrsocial.Text = ""

        limpiarDatos()
        limpiarDatosClaves()
        limpiarPreview()

        bloquearForm()

        'Dim ds As New DataSet
        'ds = archPed.obtenerConfigBD()

        'If (ds.Tables(0).Rows.Count > 0) Then
        '    setDatForm(ds.Tables(0))
        'Else
        '    limpiarDatos()
        'End If

        'If (ds.Tables(1).Rows.Count > 0) Then
        '    setDatClavForm(ds.Tables(1))
        'Else
        '    limpiarDatosClaves()
        'End If
    End Sub

    Sub setDatForm(ByVal dtDat As DataTable)
        Try
            txtColIni.Text = dtDat.Rows(0).Item(0).ToString.Trim
            txtFilIni.Text = dtDat.Rows(0).Item(1).ToString.Trim
            CboOriLec.SelectedValue = dtDat.Rows(0).Item(2).ToString.Trim
            If (dtDat.Rows(0).Item(3).ToString.Trim = "1") Then
                chkTit.Checked = True
            Else
                chkTit.Checked = False
            End If
            txtCanEnc.Text = dtDat.Rows(0).Item(4).ToString.Trim

            If (dtDat.Rows(0).Item(5).ToString.Trim = "1") Then
                chkCarSep.Checked = True
            Else
                chkCarSep.Checked = False
            End If

            txtSepCol.Text = dtDat.Rows(0).Item(6).ToString.Trim
            txtSepFil.Text = dtDat.Rows(0).Item(7).ToString.Trim
        Catch ex As Exception
            MsgBox("Ocurrió un error al cargar la configuracion de Datos al Formulario", MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Sub setDatClavForm(ByVal dtDatClav As DataTable)
        Try
            For i = 0 To dtDatClav.Rows.Count - 1
                Dim Dat = dtDatClav.Rows(i).Item(0).ToString
                Dim Pos = dtDatClav.Rows(i).Item(1).ToString

                Select Case Dat
                    Case "Fecha"
                        txtColFec.Text = Pos
                    Case "Hora"
                        txtColHra.Text = Pos
                    Case "Local"
                        txtColLoc.Text = Pos
                    Case "Folio_Cliente"
                        txtColFolCli.Text = Pos
                    Case "Codigo_Producto"
                        txtColCodPro.Text = Pos
                    Case "Unidades"
                        txtColUni.Text = Pos
                    Case "Peso"
                        txtColPes.Text = Pos
                    Case "Email"
                        txtColEma.Text = Pos
                    Case "Folio"
                        txtColFol.Text = Pos
                    Case "Folio_Caja"
                        txtColFolCaj.Text = Pos
                    Case "Destino"
                        txtColDes.Text = Pos
                    Case "Transporte"
                        txtColTrans.Text = Pos
                    Case "Encargado"
                        txtColEnc.Text = Pos
                    Case "Observacion"
                        txtColObs.Text = Pos
                End Select
            Next
        Catch ex As Exception
            MsgBox("Ocurrió un error al cargar la configuracion de Datos al Formulario", MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Sub limpiarDatos()
        txtColIni.Text = "0"
        txtFilIni.Text = "0"
        CboOriLec.SelectedIndex = 0
        chkTit.Text = "Titulos en Primera Columna"
        lblPosDat.Text = "Columna"
        chkTit.Checked = True
        txtCanEnc.Text = "5"
        chkCarSep.Checked = False
        txtSepCol.Text = ""
        txtSepCol.Enabled = False
        txtSepFil.Text = ""
        txtSepFil.Enabled = False
    End Sub

    Sub limpiarDatosClaves()
        Dim OriLec = CboOriLec.SelectedText.Trim
        If (OriLec = "H") Then
            lblPosDat.Text = "Columna"
        ElseIf (OriLec = "V") Then
            lblPosDat.Text = "Fila"
        End If

        txtColEma.Text = ""
        txtColFec.Text = "0"
        txtColHra.Text = ""
        txtColLoc.Text = "1"
        txtColCodPro.Text = "2"
        txtColFolCli.Text = ""
        txtColUni.Text = "3"
        txtColFol.Text = ""
        txtColFolCaj.Text = ""
        txtColPes.Text = ""
        txtColDes.Text = ""
        txtColTrans.Text = ""
        txtColEnc.Text = ""
        txtColObs.Text = ""
    End Sub

    Sub limpiarPreview()
        dgvPrevArch.DataSource = Nothing
    End Sub

    Private Sub btnLimPrev_Click(sender As System.Object, e As System.EventArgs) Handles btnLimPrev.Click
        limpiarPreview()
    End Sub

    Private Sub Frm_Conf_Pedidos_Xls_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        cargarCboOri()
        limpiar()
    End Sub

    Sub cargarCboOri()
        Try
            Dim dt As New DataTable
            dt.Columns.Add("val")
            dt.Columns.Add("text")

            Dim row1 As DataRow = dt.NewRow
            row1(0) = "H"
            row1(1) = "Horizontal"
            dt.Rows.Add(row1)

            Dim row2 As DataRow = dt.NewRow
            row2(0) = "V"
            row2(1) = "Vertical"
            dt.Rows.Add(row2)

            CboOriLec.DataSource = dt
            CboOriLec.ValueMember = "val"
            CboOriLec.DisplayMember = "text"

            CboOriLec.SelectedIndex = 0
        Catch ex As Exception
            MsgBox("Ocurrió un error al cargar Orienteción de Lectura", MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Function obtenerConfigForm() As DataSet
        Dim ds As New DataSet
        Dim dsErr As New DataSet

        Try
            Dim ColIni = txtColIni.Text.Trim
            Dim ColIniFrm As Integer
            If (Integer.TryParse(ColIni, ColIniFrm) = False) Then
                MsgBox("Debe ingresar una Columna Inicial valida.", MsgBoxStyle.Critical, "Error")
                txtColIni.Text = ""
                txtColIni.Focus()
                Return dsErr
            End If
            If (CInt(ColIni) < 0) Then
                MsgBox("Debe ingresar una Columna Inicial mayor o igual a cero.", MsgBoxStyle.Critical, "Error")
                txtColIni.Text = ""
                txtColIni.Focus()
                Return dsErr
            End If

            Dim FilIni = txtFilIni.Text.Trim
            Dim FilIniFrm As Integer
            If (Integer.TryParse(FilIni, FilIniFrm) = False) Then
                MsgBox("Debe ingresar una Fila Inicial valida.", MsgBoxStyle.Critical, "Error")
                txtFilIni.Text = ""
                txtFilIni.Focus()
                Return dsErr
            End If
            If (CInt(FilIni) < 0) Then
                MsgBox("Debe ingresar una Fila Inicial mayor o igual a cero.", MsgBoxStyle.Critical, "Error")
                txtFilIni.Text = ""
                txtFilIni.Focus()
                Return dsErr
            End If

            Dim OriLect = CboOriLec.SelectedValue.ToString.Trim

            Dim titCol = 0
            If (chkTit.Checked) Then
                titCol = 1
            End If

            Dim CanEnc = txtCanEnc.Text.Trim
            Dim CanEncFrm As Integer
            If (Integer.TryParse(CanEnc, CanEncFrm) = False) Then
                MsgBox("Debe ingresar una Cantidad de Encabezados valida.", MsgBoxStyle.Critical, "Error")
                txtCanEnc.Text = ""
                txtCanEnc.Focus()
                Return dsErr
            End If
            If (CInt(CanEnc) < 5) Then
                MsgBox("Debe ingresar una Columna Inicial mayor o igual a cinco.", MsgBoxStyle.Critical, "Error")
                txtCanEnc.Text = ""
                txtCanEnc.Focus()
                Return dsErr
            End If

            Dim UsaSep = "0"
            If (chkCarSep.Checked) Then
                UsaSep = "1"
            End If

            Dim SepCol = txtSepCol.Text.Trim
            If (UsaSep = "1" And SepCol = "") Then
                MsgBox("Debe ingresar una carácter separador de Columnas (Dato).", MsgBoxStyle.Critical, "Error")
                txtSepCol.Focus()
                Return dsErr
            End If

            Dim SepFil = txtSepFil.Text.Trim
            If (UsaSep = "1" And SepFil = "") Then
                MsgBox("Debe ingresar una carácter separador de Filas (Linea).", MsgBoxStyle.Critical, "Error")
                txtSepCol.Focus()
                Return dsErr
            End If

            Dim dtDat As New DataTable

            dtDat.Columns.Add("Columna_Inicial")
            dtDat.Columns.Add("Fila_Inicial")
            dtDat.Columns.Add("Orientacion_Lectura")
            dtDat.Columns.Add("Columna_Titulos")
            dtDat.Columns.Add("Cantidad_Encabezados")
            dtDat.Columns.Add("Usa_Separador")
            dtDat.Columns.Add("Separador_Columna")
            dtDat.Columns.Add("Separador_Fila")

            Dim rowDat As DataRow = dtDat.NewRow
            rowDat(0) = ColIni
            rowDat(1) = FilIni
            rowDat(2) = OriLect
            rowDat(3) = titCol
            rowDat(4) = CanEnc
            rowDat(5) = UsaSep
            rowDat(6) = SepCol
            rowDat(7) = SepFil
            dtDat.Rows.Add(rowDat)

            ds.Tables.Add(dtDat)



            Dim dtDatClav As New DataTable

            dtDatClav.Columns.Add("Dato")
            dtDatClav.Columns.Add("Posicion")
            dtDatClav.Columns.Add("Tabla")
            dtDatClav.Columns.Add("Campo")

            Dim EmaPos = txtColEma.Text.Trim
            If (EmaPos <> "") Then
                Dim EmaPosFrm As Integer
                If (Integer.TryParse(EmaPos, EmaPosFrm) = False) Then
                    MsgBox("Debe ingresar una posicion para Email valida.", MsgBoxStyle.Critical, "Error")
                    txtColEma.Text = ""
                    txtColEma.Focus()
                    Return dsErr
                End If
                If (CInt(EmaPos) < 0) Then
                    MsgBox("La posicion para Email debe ser mayor o igual a cero.", MsgBoxStyle.Critical, "Error")
                    txtColEma.Text = ""
                    txtColEma.Focus()
                    Return dsErr
                End If
                Dim rowDatClavEma As DataRow = dtDatClav.NewRow
                rowDatClavEma(0) = "Email"
                rowDatClavEma(1) = EmaPos
                rowDatClavEma(2) = "Pedidos_ficha"
                rowDatClavEma(3) = "mail"
                dtDatClav.Rows.Add(rowDatClavEma)
            End If

            Dim FecPos = txtColFec.Text.Trim
            Dim FecPosFrm As Integer
            If (Integer.TryParse(FecPos, FecPosFrm) = False) Then
                MsgBox("Debe ingresar una posicion para Fecha valida.", MsgBoxStyle.Critical, "Error")
                txtColFec.Text = ""
                txtColFec.Focus()
                Return dsErr
            End If
            If (CInt(FecPos) < 0) Then
                MsgBox("La posicion para Fecha debe ser mayor o igual a cero.", MsgBoxStyle.Critical, "Error")
                txtColFec.Text = ""
                txtColFec.Focus()
                Return dsErr
            End If
            Dim rowDatClavFec As DataRow = dtDatClav.NewRow
            rowDatClavFec(0) = "Fecha"
            rowDatClavFec(1) = FecPos
            rowDatClavFec(2) = "Pedidos_ficha"
            rowDatClavFec(3) = "fecha"
            dtDatClav.Rows.Add(rowDatClavFec)

            Dim HraPos = txtColHra.Text.Trim
            If (HraPos <> "") Then
                Dim HraPosFrm As Integer
                If (Integer.TryParse(HraPos, HraPosFrm) = False) Then
                    MsgBox("Debe ingresar una posicion para Hora valida.", MsgBoxStyle.Critical, "Error")
                    txtColHra.Text = ""
                    txtColHra.Focus()
                    Return dsErr
                End If
                If (CInt(HraPos) < 0) Then
                    MsgBox("La posicion para Hora debe ser mayor o igual a cero.", MsgBoxStyle.Critical, "Error")
                    txtColHra.Text = ""
                    txtColHra.Focus()
                    Return dsErr
                End If
                Dim rowDatClavHra As DataRow = dtDatClav.NewRow
                rowDatClavHra(0) = "Hora"
                rowDatClavHra(1) = HraPos
                rowDatClavHra(2) = "Pedidos_ficha"
                rowDatClavHra(3) = "hora"
                dtDatClav.Rows.Add(rowDatClavHra)
            End If

            Dim LocPos = txtColLoc.Text.Trim
            Dim LocPosFrm As Integer
            If (Integer.TryParse(LocPos, LocPosFrm) = False) Then
                MsgBox("Debe ingresar una posicion para Local valida.", MsgBoxStyle.Critical, "Error")
                txtColLoc.Text = ""
                txtColLoc.Focus()
                Return dsErr
            End If
            If (CInt(LocPos) < 0) Then
                MsgBox("La posicion para Local debe ser mayor o igual a cero.", MsgBoxStyle.Critical, "Error")
                txtColLoc.Text = ""
                txtColLoc.Focus()
                Return dsErr
            End If
            Dim rowDatClavLoc As DataRow = dtDatClav.NewRow
            rowDatClavLoc(0) = "Local"
            rowDatClavLoc(1) = LocPos
            rowDatClavLoc(2) = "Pedidos_Local"
            rowDatClavLoc(3) = "ID_Local"
            dtDatClav.Rows.Add(rowDatClavLoc)

            Dim FolCliPos = txtColFolCli.Text.Trim
            If (FolCliPos <> "") Then
                Dim FolCliPosFrm As Integer
                If (Integer.TryParse(FolCliPos, FolCliPosFrm) = False) Then
                    MsgBox("Debe ingresar una posicion para Folio Cliente valida.", MsgBoxStyle.Critical, "Error")
                    txtColFolCli.Text = ""
                    txtColFolCli.Focus()
                    Return dsErr
                End If
                If (CInt(FolCliPos) < 0) Then
                    MsgBox("La posicion para Folio Cliente debe ser mayor o igual a cero.", MsgBoxStyle.Critical, "Error")
                    txtColFolCli.Text = ""
                    txtColFolCli.Focus()
                    Return dsErr
                End If
                Dim rowDatClavFolCli As DataRow = dtDatClav.NewRow
                rowDatClavFolCli(0) = "Folio_Cliente"
                rowDatClavFolCli(1) = FolCliPos
                rowDatClavFolCli(2) = ""
                rowDatClavFolCli(3) = ""
                dtDatClav.Rows.Add(rowDatClavFolCli)
            End If

            Dim FolPos = txtColFol.Text.Trim
            If (FolPos <> "") Then
                Dim FolPosFrm As Integer
                If (Integer.TryParse(FolPos, FolPosFrm) = False) Then
                    MsgBox("Debe ingresar una posicion para Folio valida.", MsgBoxStyle.Critical, "Error")
                    txtColFol.Text = ""
                    txtColFol.Focus()
                    Return dsErr
                End If
                If (CInt(FolPos) < 0) Then
                    MsgBox("La posicion para Folio debe ser mayor o igual a cero.", MsgBoxStyle.Critical, "Error")
                    txtColFol.Text = ""
                    txtColFol.Focus()
                    Return dsErr
                End If
                Dim rowDatClavFol As DataRow = dtDatClav.NewRow
                rowDatClavFol(0) = "Folio"
                rowDatClavFol(1) = FolPos
                rowDatClavFol(2) = "Pedidos_detalle"
                rowDatClavFol(3) = "pallet"
                dtDatClav.Rows.Add(rowDatClavFol)
            End If

            If (FolCliPos = "" And FolPos = "") Then
                txtColFolCli.Focus()
                MsgBox("Debe ingresar la posicion del Folio o Folio Cliente.", MsgBoxStyle.Critical, "Error")
                Return dsErr
            End If

            Dim FolCajPos = txtColFolCaj.Text.Trim
            If (FolCajPos <> "") Then
                Dim FolCajPosFrm As Integer
                If (Integer.TryParse(FolCajPos, FolCajPosFrm) = False) Then
                    MsgBox("Debe ingresar una posicion para Folio Caja valida.", MsgBoxStyle.Critical, "Error")
                    txtColFolCaj.Text = ""
                    txtColFolCaj.Focus()
                    Return dsErr
                End If
                If (CInt(FolCajPos) < 0) Then
                    MsgBox("La posicion para Folio Caja debe ser mayor o igual a cero.", MsgBoxStyle.Critical, "Error")
                    txtColFolCaj.Text = ""
                    txtColFolCaj.Focus()
                    Return dsErr
                End If
                Dim rowDatClavFolCaj As DataRow = dtDatClav.NewRow
                rowDatClavFolCaj(0) = "Folio_Caja"
                rowDatClavFolCaj(1) = FolCajPos
                rowDatClavFolCaj(2) = ""
                rowDatClavFolCaj(3) = ""
                dtDatClav.Rows.Add(rowDatClavFolCaj)
            End If

            Dim CodProPos = txtColCodPro.Text.Trim
            Dim CodProPosFrm As Integer
            If (Integer.TryParse(CodProPos, CodProPosFrm) = False) Then
                MsgBox("Debe ingresar una posicion para Codigo Producto valida.", MsgBoxStyle.Critical, "Error")
                txtColCodPro.Text = ""
                txtColCodPro.Focus()
                Return dsErr
            End If
            If (CInt(CodProPos) < 0) Then
                MsgBox("La posicion para Codigo Producto debe ser mayor o igual a cero.", MsgBoxStyle.Critical, "Error")
                txtColCodPro.Text = ""
                txtColCodPro.Focus()
                Return dsErr
            End If
            Dim rowDatClavCodPro As DataRow = dtDatClav.NewRow
            rowDatClavCodPro(0) = "Codigo_Producto"
            rowDatClavCodPro(1) = CodProPos
            rowDatClavCodPro(2) = ""
            rowDatClavCodPro(3) = ""
            dtDatClav.Rows.Add(rowDatClavCodPro)

            Dim UniPos = txtColUni.Text.Trim
            Dim UniPosFrm As Integer
            If (Integer.TryParse(UniPos, UniPosFrm) = False) Then
                MsgBox("Debe ingresar una posicion para Unidades valida.", MsgBoxStyle.Critical, "Error")
                txtColUni.Text = ""
                txtColUni.Focus()
                Return dsErr
            End If
            If (CInt(UniPos) < 0) Then
                MsgBox("La posicion para Unidades debe ser mayor o igual a cero.", MsgBoxStyle.Critical, "Error")
                txtColUni.Text = ""
                txtColUni.Focus()
                Return dsErr
            End If
            Dim rowDatClavUni As DataRow = dtDatClav.NewRow
            rowDatClavUni(0) = "Unidades"
            rowDatClavUni(1) = UniPos
            rowDatClavUni(2) = "Pedidos_detalle"
            rowDatClavUni(3) = "cajas"
            dtDatClav.Rows.Add(rowDatClavUni)

            Dim PesPos = txtColPes.Text.Trim
            If (PesPos <> "") Then
                Dim PesPosFrm As Integer
                If (Integer.TryParse(PesPos, PesPosFrm) = False) Then
                    MsgBox("Debe ingresar una posicion para Peso valida.", MsgBoxStyle.Critical, "Error")
                    txtColPes.Text = ""
                    txtColPes.Focus()
                    Return dsErr
                End If
                If (CInt(UniPos) < 0) Then
                    MsgBox("La posicion para Peso debe ser mayor o igual a cero.", MsgBoxStyle.Critical, "Error")
                    txtColPes.Text = ""
                    txtColPes.Focus()
                    Return dsErr
                End If
                Dim rowDatClavPes As DataRow = dtDatClav.NewRow
                rowDatClavPes(0) = "Peso"
                rowDatClavPes(1) = PesPos
                rowDatClavPes(2) = "Pedidos_detalle"
                rowDatClavPes(3) = "kilos"
                dtDatClav.Rows.Add(rowDatClavPes)
            End If

            Dim DesPos = txtColDes.Text.Trim
            If (DesPos <> "") Then
                Dim DesPosFrm As Integer
                If (Integer.TryParse(DesPos, DesPosFrm) = False) Then
                    MsgBox("Debe ingresar una posicion para Destino valida.", MsgBoxStyle.Critical, "Error")
                    txtColDes.Text = ""
                    txtColDes.Focus()
                    Return dsErr
                End If
                If (CInt(DesPos) < 0) Then
                    MsgBox("La posicion para Destino debe ser mayor o igual a cero.", MsgBoxStyle.Critical, "Error")
                    txtColDes.Text = ""
                    txtColDes.Focus()
                    Return dsErr
                End If
                Dim rowDatClavDes As DataRow = dtDatClav.NewRow
                rowDatClavDes(0) = "Destino"
                rowDatClavDes(1) = DesPos
                rowDatClavDes(2) = "Pedidos_ficha"
                rowDatClavDes(3) = "destino"
                dtDatClav.Rows.Add(rowDatClavDes)
            End If

            Dim TransPos = txtColTrans.Text.Trim
            If (TransPos <> "") Then
                Dim TransPosFrm As Integer
                If (Integer.TryParse(TransPos, TransPosFrm) = False) Then
                    MsgBox("Debe ingresar una posicion para Transporte valida.", MsgBoxStyle.Critical, "Error")
                    txtColTrans.Text = ""
                    txtColTrans.Focus()
                    Return dsErr
                End If
                If (CInt(TransPos) < 0) Then
                    MsgBox("La posicion para Transporte debe ser mayor o igual a cero.", MsgBoxStyle.Critical, "Error")
                    txtColTrans.Text = ""
                    txtColTrans.Focus()
                    Return dsErr
                End If
                Dim rowDatClavTrans As DataRow = dtDatClav.NewRow
                rowDatClavTrans(0) = "Transporte"
                rowDatClavTrans(1) = TransPos
                rowDatClavTrans(2) = "Pedidos_ficha"
                rowDatClavTrans(3) = "transporte"
                dtDatClav.Rows.Add(rowDatClavTrans)
            End If

            Dim EncPos = txtColEnc.Text.Trim
            If (EncPos <> "") Then
                Dim EncPosFrm As Integer
                If (Integer.TryParse(EncPos, EncPosFrm) = False) Then
                    MsgBox("Debe ingresar una posicion para Encargado valida.", MsgBoxStyle.Critical, "Error")
                    txtColEnc.Text = ""
                    txtColEnc.Focus()
                    Return dsErr
                End If
                If (CInt(EncPos) < 0) Then
                    MsgBox("La posicion para Encargado debe ser mayor o igual a cero.", MsgBoxStyle.Critical, "Error")
                    txtColEnc.Text = ""
                    txtColEnc.Focus()
                    Return dsErr
                End If
                Dim rowDatClavEnc As DataRow = dtDatClav.NewRow
                rowDatClavEnc(0) = "Encargado"
                rowDatClavEnc(1) = EncPos
                rowDatClavEnc(2) = "Pedidos_ficha"
                rowDatClavEnc(3) = "Encargado"
                dtDatClav.Rows.Add(rowDatClavEnc)
            End If

            Dim ObsPos = txtColObs.Text.Trim
            If (ObsPos <> "") Then
                Dim ObsPosFrm As Integer
                If (Integer.TryParse(ObsPos, ObsPosFrm) = False) Then
                    MsgBox("Debe ingresar una posicion para Observacion valida.", MsgBoxStyle.Critical, "Error")
                    txtColObs.Text = ""
                    txtColObs.Focus()
                    Return dsErr
                End If
                If (CInt(ObsPos) < 0) Then
                    MsgBox("La posicion para Observacion debe ser mayor o igual a cero.", MsgBoxStyle.Critical, "Error")
                    txtColObs.Text = ""
                    txtColObs.Focus()
                    Return dsErr
                End If
                Dim rowDatClavObs As DataRow = dtDatClav.NewRow
                rowDatClavObs(0) = "Observacion"
                rowDatClavObs(1) = ObsPos
                rowDatClavObs(2) = "Pedidos_ficha"
                rowDatClavObs(3) = "Observacion"
                dtDatClav.Rows.Add(rowDatClavObs)
            End If

            Dim PosRep As Boolean = False

            Dim ContPos As Integer = 0

            For i = 0 To dtDatClav.Rows.Count - 1
                Dim PosAct = dtDatClav.Rows(i).Item(1).ToString.Trim

                If (PosAct <> "") Then
                    ContPos += 1

                    For j = 0 To dtDatClav.Rows.Count - 1
                        If (j <> i) Then
                            Dim PosEvaluar = dtDatClav.Rows(j).Item(1).ToString.Trim

                            If (PosEvaluar <> "") Then
                                If (PosAct = PosEvaluar) Then
                                    PosRep = True
                                End If
                            End If
                        End If
                    Next
                End If
            Next

            If (PosRep) Then
                MsgBox("No se puede repetir ninguna posicion de Datos Clave.", MsgBoxStyle.Critical, "Error")
                Return dsErr
            End If

            If (ContPos > CanEnc) Then
                MsgBox("Los Datos Clave configurados no cuadran con la Cantidad de Encabezados.", MsgBoxStyle.Critical, "Error")
                Return dsErr
            End If

            ds.Tables.Add(dtDatClav)

            Return ds
        Catch ex As Exception
            MsgBox("Ocurrio un error al obtener los datos del formulario", MsgBoxStyle.Critical, "Error")

            Return dsErr
        End Try

        Return ds
    End Function

    Private Sub btnGra_Click(sender As System.Object, e As System.EventArgs) Handles btnGra.Click
        Try
            Dim ds As New DataSet

            ds = obtenerConfigForm()
            If (ds.Tables.Count > 0) Then
                Dim dtDat As New DataTable
                dtDat = ds.Tables(0)
                Dim IDConfig = grabarDat(dtDat)
                If (IDConfig <> "-1") Then
                    Dim dtDatClav As New DataTable
                    dtDatClav = ds.Tables(1)
                    If (grabarDatClav(IDConfig, dtDatClav)) Then
                        MsgBox("Configuración de archivo grabada con éxito.", MsgBoxStyle.Information, "Éxito")
                    Else
                        MsgBox("Ocurrio un error al grabar la configuración de los Datos Claves.", MsgBoxStyle.Critical, "Error")
                    End If
                Else
                    MsgBox("Ocurrio un error al grabar la configuración del archivo.", MsgBoxStyle.Critical, "Error")
                End If
            End If
        Catch ex As Exception
            MsgBox("Ocurrio un error al grabar la configuración del archivo.", MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Function grabarDat(ByVal dt As DataTable) As String
        Dim Resp As String = "-1"

        Try
            Dim vars As String = "'" & txtrut.Text.Trim.Replace("-", "") & "'"

            For i = 0 To dt.Columns.Count - 1
                Dim dat = dt.Rows(0).Item(i).ToString.Trim

                vars = vars & ",'" & dat & "'"
            Next

            Dim sql = "SP_Pedidos_Conf_Archivo_Grabar " & vars
            Dim dtRes As DataTable = fnc.ListarTablasSQL(sql)

            If (dtRes.Rows.Count > 0) Then
                Resp = dtRes.Rows(0).Item(0).ToString.Trim
            End If
        Catch ex As Exception
            Return False
        End Try

        Return Resp
    End Function

    Function grabarDatClav(ByVal IDConfig As String, ByVal dt As DataTable) As Boolean
        Dim Resp As Boolean = False

        Try
            Dim procOk As Boolean = True

            For i = 0 To dt.Rows.Count - 1
                Dim dat = dt.Rows(i).Item(0).ToString.Trim
                Dim pos = dt.Rows(i).Item(1).ToString.Trim
                Dim tab = dt.Rows(i).Item(2).ToString.Trim
                Dim cam = dt.Rows(i).Item(3).ToString.Trim

                If (pos <> "") Then
                    Dim vars = "'" & IDConfig & "','" & dat & "','" & pos & "','" & tab & "','" & cam & "'"

                    Dim sql = "SP_Pedidos_Conf_Archivo_Posiciones_Grabar " & vars
                    If (fnc.MovimientoSQL(sql) = 0) Then
                        procOk = False
                    End If
                End If
            Next

            If (procOk) Then
                Resp = True
            End If
        Catch ex As Exception
            Return False
        End Try

        Return Resp
    End Function

    Private Sub CboOriLec_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles CboOriLec.SelectedIndexChanged
        Try
            Dim OriLec = CboOriLec.SelectedValue.ToString.Trim
            If (OriLec = "H") Then
                chkTit.Text = "Titulos en Primera Columna"
                lblSepCol.Text = "Separador Columna (Datos)"
                lblSepFil.Text = "Separador Fila (Líneas)"
                lblPosDat.Text = "Columna"
            Else
                chkTit.Text = "Titulos en Primera Fila"
                lblSepCol.Text = "Separador Fila (Datos)"
                lblSepFil.Text = "Separador Columna (Líneas)"
                lblPosDat.Text = "Fila"
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnArchPrev_Click(sender As System.Object, e As System.EventArgs) Handles btnArchPrev.Click
        frmArch.ShowDialog()

        Dim path = frmArch.FileName.Trim

        If (path <> "") Then
            If (archPed.validArchivo(path)) Then
                Dim dtPrev As DataTable = archPed.leerArchPedido(path, obtenerConfigForm)
                dgvPrevArch.DataSource = dtPrev
            Else
                MsgBox("El archivo ingresado no es valido.", MsgBoxStyle.Information, "Formato Incorrecto")
                limpiarPreview()
            End If
        End If
    End Sub

    Private Sub chkCarSep_CheckStateChanged(sender As Object, e As System.EventArgs) Handles chkCarSep.CheckStateChanged
        If (chkCarSep.Checked) Then
            txtSepCol.Enabled = True
            txtSepFil.Enabled = True
        Else
            txtSepCol.Text = ""
            txtSepCol.Enabled = False
            txtSepFil.Text = ""
            txtSepFil.Enabled = False
        End If
    End Sub

    Private Sub Btn_BuscaCliente_Click(sender As System.Object, e As System.EventArgs) Handles Btn_BuscaCliente.Click
        Dim frm As New Lst_AyudaClientes
        frm.ShowDialog(Frm_Principal)
        If Frm_Principal.buscavalor <> "" Then
            txtrut.Text = Frm_Principal.buscavalor
            Frm_Principal.buscavalor = ""
            buscarRazSoc()
            Dim dsConf As DataSet = archPed.obtenerConfigBD(txtrut.Text.Trim.Replace("-", ""))
            If (dsConf.Tables.Count > 0) Then
                Dim dtDat As DataTable = dsConf.Tables(0)
                If (dtDat.Rows.Count > 0) Then
                    setDatForm(dtDat)
                Else
                    limpiarDatos()
                End If

                Dim dtDatClav As DataTable = dsConf.Tables(1)
                If (dtDatClav.Rows.Count > 0) Then
                    setDatClavForm(dtDatClav)
                Else
                    limpiarDatosClaves()
                End If
            Else
                limpiar()
            End If

            desbloquearForm()
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

    Sub bloquearForm()
        gpbDat.Enabled = False
        gpbDatClav.Enabled = False
        gpbPrev.Enabled = False
        txtrut.Enabled = True
        Btn_BuscaCliente.Enabled = True
        txtrut.Focus()
    End Sub

    Sub desbloquearForm()
        txtrut.Enabled = False
        Btn_BuscaCliente.Enabled = False
        gpbDat.Enabled = True
        gpbDatClav.Enabled = True
        gpbPrev.Enabled = True
        txtColIni.Focus()
    End Sub
End Class
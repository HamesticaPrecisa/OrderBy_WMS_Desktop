Imports System.Threading


Imports System.Data.OleDb

Imports Microsoft.Office.Interop




Public Class Frm_RecuentoCajRPT
    Private ds As New DataSet
    Dim fnc As New Funciones
    Dim thread As Thread
    Public whereestado0 As String = ""
    Public whereestado1 As String = ""
    Public whereestado2 As String = ""
    Public whereestado3 As String = ""



    Private Sub Frm_RecuentoCajRPT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '  Me.DgvResultado.DataSource = fnc.ListarTablasSQL("SELECT TOP(100) fdes_codi, cli_nomb, Convert(datetime,fdes_fecha,111) as fdes_fecha, fdes_totsopo, fdes_totunidad, " +
        '    "fdes_totpeso as PESO FROM fichdespa, clientes WHERE cli_rut=fdes_rutcli ORDER BY fdes_codi DESC")
        Me.DgvResultado.DataSource = fnc.ListarTablasSQL("select pallet as PALLET, CAJ_COD AS CAJA,CAJ_PED AS ESTADO, CAJ_CALIDAD AS CALIDAD ,CAJ_CALIBRE AS CALIBRE ,CAJ_FELAB AS FELAB,CAJ_FVENC AS FVEN,CAJ_UNID AS UNIDAD ,CAJ_KG AS KG , caj_id as ID , CAJ_LOTE AS LOTE FROM VG_STOCK_CLIENTES WHERE drec_rutcli='" + LblCliente.Text + "' ")
        '  Me.DgvResultado.DataSource = fnc.ListarTablasSQL("SELECT    CAJ_PCOD AS PALET,CAJ_COD as CAJA,CAJ_CALIDAD AS CALIDAD,CAJ_CALIBRE AS CALIBRE,CAJ_FELAB AS FELAV,CAJ_FVENC AS FVEN,CAJ_UNID AS UNIDAD,CAJ_KG AS KG,CAJ_PED AS ESTADO FROM DetaReceCajas INNER JOIN rackdeta ON racd_codi=Caj_Pcod INNER JOIN detarece ON drec_codi=racd_codi WHERE drec_rutcli='" + LblCliente.Text + "' AND caj_ped<>3")
        Me.DgvResultado2.DataSource = fnc.ListarTablasSQL("SELECT CAJ_PCOD as PALET,CAJ_COD AS CAJA,CAJ_PED AS ESTADO FROM DetaReceCajas INNER JOIN rackdeta ON racd_codi=Caj_Pcod INNER JOIN detarece ON drec_codi=racd_codi  " +
        "WHERE CAJ_COD in (SELECT CAJ_COD FROM DetaReceCajas INNER JOIN rackdeta ON racd_codi=Caj_Pcod INNER JOIN detarece ON drec_codi=racd_codi " +
        "GROUP BY CAJ_COD HAVING count(*)>1) AND  drec_rutcli='" + LblCliente.Text + "'  AND caj_ped<>3 ORDER BY caj_cod ASC")

    End Sub
#Region "Cliente"
    Private Sub Btn_cliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_cliente.Click
        Lst_AyudaClientes.ShowDialog(Frm_Principal)
        If Frm_Principal.buscavalor.ToString <> "" Then
            Txtcliente.Text = RetornaCliente(Frm_Principal.buscavalor.ToString())
            LblCliente.Text = Frm_Principal.buscavalor.ToString()
            Frm_Principal.buscavalor = ""
        End If
    End Sub
#End Region

    Private Sub Btn_Calcular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Calcular.Click
        ' Me.DgvResultado.DataSource = fnc.ListarTablasSQL("SELECT    CAJ_PCOD AS PALET,CAJ_COD as CAJA,CAJ_CALIDAD AS CALIDAD,CAJ_CALIBRE AS CALIBRE,CAJ_FELAB AS FELAV,CAJ_FVENC AS FVEN,CAJ_UNID AS UNIDAD,CAJ_KG AS KG,CAJ_PED AS ESTADO FROM DetaReceCajas INNER JOIN rackdeta ON racd_codi=Caj_Pcod INNER JOIN detarece ON drec_codi=racd_codi WHERE drec_rutcli='" + LblCliente.Text + "' AND caj_ped<>3")
        Me.DgvResultado.DataSource = fnc.ListarTablasSQL("select pallet as PALLET, CAJ_COD AS CAJA,CAJ_PED AS ESTADO, CAJ_CALIDAD AS CALIDAD ,CAJ_CALIBRE AS CALIBRE ,CAJ_FELAB AS FELAB,CAJ_FVENC AS FVEN,CAJ_UNID AS UNIDAD ,CAJ_KG AS KG, CAJ_ID AS ID , CAJ_LOTE AS LOTE FROM VG_STOCK_CLIENTES WHERE drec_rutcli='" + LblCliente.Text + "' ")
        Me.DgvResultado2.DataSource = fnc.ListarTablasSQL("SELECT CAJ_PCOD as PALET,CAJ_COD AS CAJA,CAJ_PED AS ESTADO FROM DetaReceCajas INNER JOIN rackdeta ON racd_codi=Caj_Pcod INNER JOIN detarece ON drec_codi=racd_codi  " +
        "WHERE CAJ_COD in (SELECT CAJ_COD FROM DetaReceCajas INNER JOIN rackdeta ON racd_codi=Caj_Pcod INNER JOIN detarece ON drec_codi=racd_codi " +
        "GROUP BY CAJ_COD HAVING count(*)>1) AND  drec_rutcli='" + LblCliente.Text + "'  AND caj_ped<>3 ORDER BY caj_cod ASC")
        Me.dgvsuma.DataSource = fnc.ListarTablasSQL("SELECT CAJ_COD FROM DetaReceCajas INNER JOIN rackdeta ON racd_codi=Caj_Pcod INNER JOIN detarece ON drec_codi=racd_codi  " +
       "WHERE CAJ_COD in (SELECT CAJ_COD FROM DetaReceCajas INNER JOIN rackdeta ON racd_codi=Caj_Pcod INNER JOIN detarece ON drec_codi=racd_codi " +
       "GROUP BY CAJ_COD HAVING count(*)>1) AND  drec_rutcli='" + LblCliente.Text + "'  AND caj_ped<>3 GROUP BY CAJ_COD ORDER BY caj_cod ASC")


        Me.btn_Imprimir.Enabled = True
        Me.btn_nuevo.Enabled = True

        txtTotal.Text = dgvsuma.RowCount - 1

    End Sub
    Function ExportarExcel(ByVal ElGrid As DataGridView) As Boolean

        Dim exApp As New Microsoft.Office.Interop.Excel.Application
        Dim exLibro As Microsoft.Office.Interop.Excel.Workbook
        Dim exHoja As Microsoft.Office.Interop.Excel.Worksheet

        Try
            'Añadimos el Libro al programa, y la hoja al libro
            exLibro = exApp.Workbooks.Add
            exHoja = exLibro.Worksheets.Add()

            ProgressBar1.Maximum = DgvResultado.Rows.Count
            ' ¿Cuantas columnas y cuantas filas?
            Dim NCol As Integer = ElGrid.ColumnCount
            Dim NRow As Integer = ElGrid.RowCount

            'Aqui recorremos todas las filas, y por cada fila todas las columnas y vamos escribiendo.
            For i As Integer = 1 To NCol
                exHoja.Cells.Item(1, i) = ElGrid.Columns(i - 1).Name.ToString
                exHoja.Cells.Item(1, i).HorizontalAlignment = 3
            Next

            For Fila As Integer = 0 To NRow - 1
                For Col As Integer = 0 To NCol - 1
                    exHoja.Cells.Item(Fila + 2, Col + 1) = ElGrid.Rows(Fila).Cells(Col).Value
                    exHoja.Cells.Item(Fila + 2, Col + 1).Font.Size = 10
                Next
                ProgressBar1.Value += 1
            Next
            'Titulo en negrita, Alineado al centro y que el tamaño de la columna se
            'exHoja.Rows.Item(1).Font.Bold = 1
            'exHoja.Rows.Item(1).Font.Size = 11
            'exHoja.Rows.Item(1).HorizontalAlignment = 3
            'exHoja.Columns.AutoFit()

            'Aplicación visible
            exApp.Application.Visible = True

            exHoja = Nothing
            exLibro = Nothing
            exApp = Nothing
            Return True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al exportar a Excel")
            Return False
        End Try
    End Function
    Public Sub ExportarDatosExcelmejo(ByVal DataGridView1 As DataGridView, ByVal titulo As String)
        Dim m_Excel As New Excel.Application
        m_Excel.Cursor = Excel.XlMousePointer.xlWait
        m_Excel.Visible = True
        Dim objLibroExcel As Excel.Workbook = m_Excel.Workbooks.Add
        Dim objHojaExcel As Excel.Worksheet = objLibroExcel.Worksheets(1)
        With objHojaExcel
            .Visible = Excel.XlSheetVisibility.xlSheetVisible
            .Activate()
            'Encabezado.  
            .Range("A1").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            .Range("A1:L1").Merge()
            .Range("A1:L1").Value = "CORPORACION CLUB LAGOS DEL CAUJARAL."
            .Range("A1:L1").Font.Bold = True
            .Range("A1:L1").Font.Size = 16
            'Texto despues del encabezado.   
            .Range("A2:L2").Merge()
            .Range("A2:L2").Value = titulo
            .Range("A2:L2").Font.Bold = True
            .Range("A2:L2").Font.Size = 10
            'Espacio.
            .Range("A3:L3").Merge()
            .Range("A3:L3").Value = ""
            .Range("A3:L3").Font.Bold = True
            .Range("A3:L3").Font.Size = 10
            'Estilo a titulos de la tabla.
            .Range("A4:P4").Font.Bold = True
            'Establecer tipo de letra al rango determinado.
            .Range("A1:P100").Font.Name = "Tahoma"
            'Los datos se registran a partir de la columna A, fila 4.
            Const primeraLetra As Char = "A"
            Const primerNumero As Short = 4
            Dim Letra As Char, UltimaLetra As Char
            Dim Numero As Integer, UltimoNumero As Integer
            Dim cod_letra As Byte = Asc(primeraLetra) - 1
            Dim sepDec As String = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator
            Dim sepMil As String = Application.CurrentCulture.NumberFormat.NumberGroupSeparator
            Dim strColumna As String = ""
            Dim LetraIzq As String = ""
            Dim cod_LetraIzq As Byte = Asc(primeraLetra) - 1
            Letra = primeraLetra
            Numero = primerNumero
            Dim objCelda As Excel.Range
            For Each c As DataGridViewColumn In DataGridView1.Columns
                If c.Visible Then
                    : If Letra = "Z" Then
                        Letra = primeraLetra
                        cod_letra = Asc(primeraLetra)
                        cod_LetraIzq += 1
                        LetraIzq = Chr(cod_LetraIzq)
                    Else
                        cod_letra += 1
                        Letra = Chr(cod_letra)
                    End If
                    strColumna = LetraIzq + Letra + Numero.ToString
                    objCelda = .Range(strColumna, Type.Missing)
                    objCelda.Value = c.HeaderText
                    objCelda.EntireColumn.Font.Size = 10
                    'Establece un formato a los numeros por Default.
                    'objCelda.EntireColumn.NumberFormat = c.DefaultCellStyle.Format
                    If c.ValueType Is GetType(Decimal) OrElse c.ValueType Is GetType(Double) Then
                        objCelda.EntireColumn.NumberFormat = "#" + sepMil + "0" + sepDec + "00"
                    End If
                End If
            Next
            Dim objRangoEncab As Excel.Range = .Range(primeraLetra + Numero.ToString, LetraIzq + Letra + Numero.ToString)
            objRangoEncab.BorderAround(1, Excel.XlBorderWeight.xlMedium)
            UltimaLetra = Letra
            Dim UltimaLetraIzq As String = LetraIzq
            'Cargar Datos del DataGridView.   
            Dim i As Integer = Numero + 1
            For Each reg As DataGridViewRow In DataGridView1.Rows
                LetraIzq = ""
                cod_LetraIzq = Asc(primeraLetra) - 1
                Letra = primeraLetra
                cod_letra = Asc(primeraLetra) - 1
                For Each c As DataGridViewColumn In DataGridView1.Columns
                    If c.Visible Then
                        If Letra = "Z" Then
                            Letra = primeraLetra
                            cod_letra = Asc(primeraLetra)
                            cod_LetraIzq += 1
                            LetraIzq = Chr(cod_LetraIzq)
                        Else
                            cod_letra += 1
                            Letra = Chr(cod_letra)
                        End If
                        strColumna = LetraIzq + Letra
                        'Aqui se realiza la carga de datos.  
                        .Cells(i, strColumna) = IIf(IsDBNull(reg.ToString), "", reg.Cells(c.Index).Value)
                        'Establece las propiedades de los datos del DataGridView por Default.
                        '.Cells(i, strColumna) = IIf(IsDBNull(reg.(c.DataPropertyName)), c.DefaultCellStyle.NullValue, reg(c.DataPropertyName))   
                        '.Range(strColumna + i, strColumna + i).In()   
                    End If
                Next
                Dim objRangoReg As Excel.Range = .Range(primeraLetra + i.ToString, strColumna + i.ToString)
                objRangoReg.Rows.BorderAround()
                objRangoReg.Select()
                i += 1
            Next
            UltimoNumero = i
            'Dibujar las líneas de las columnas.  
            LetraIzq = ""
            cod_LetraIzq = Asc("A")
            cod_letra = Asc(primeraLetra)
            Letra = primeraLetra
            For Each c As DataGridViewColumn In DataGridView1.Columns
                If c.Visible Then
                    objCelda = .Range(LetraIzq + Letra + primerNumero.ToString, LetraIzq + Letra + (UltimoNumero - 1).ToString)
                    objCelda.BorderAround()
                    If Letra = "Z" Then
                        Letra = primeraLetra
                        cod_letra = Asc(primeraLetra)
                        LetraIzq = Chr(cod_LetraIzq)
                        cod_LetraIzq += 1
                    Else
                        cod_letra += 1
                        Letra = Chr(cod_letra)
                    End If
                End If
            Next
            'Dibujar el border exterior grueso de la tabla.   
            Dim objRango As Excel.Range = .Range(primeraLetra + primerNumero.ToString, UltimaLetraIzq + UltimaLetra + (UltimoNumero - 1).ToString)
            objRango.Select()
            objRango.Columns.AutoFit()
            objRango.Columns.BorderAround(1, Excel.XlBorderWeight.xlMedium)
        End With
        m_Excel.Cursor = Excel.XlMousePointer.xlDefault
    End Sub
    Private Sub expex()

        '// Creamos el Objeto Excel
        '/////////////////////////////
        Dim m_Excel
        Dim objLibroExcel
        Dim objHojaExcel
        m_Excel = CreateObject("Excel.Application")
        objLibroExcel = m_Excel.Workbooks.Add()
        objHojaExcel = objLibroExcel.Worksheets(1)
        objHojaExcel.Name = "Customers"
        objHojaExcel.Visible = Excel.XlSheetVisibility.xlSheetVisible
        objHojaExcel.Activate()

        '/////////////////////////////////////////////////////////
        '// Definimos dos variables para controlar fila y columna
        '/////////////////////////////////////////////////////////
        Dim fila As Integer = 1
        Dim columna As Integer = 1

        '/////////////////////////////////////////////////
        '// Armamos la linea con los títulos de columnas
        '/////////////////////////////////////////////////
        objHojaExcel.Range("A1").Select()
        For Each dc In DgvResultado.Columns()
            ' objHojaExcel.Range(nombreColumna(columna) & 1).Value = dc.ColumnName
            columna += 1
        Next
        fila += 1

        '/////////////////////////////////////////////
        '// Le damos formato a la fila de los títulos
        '/////////////////////////////////////////////
        Dim objRango As Excel.Range = objHojaExcel.Range("A1:" & nombreColumna(DgvResultado.Columns.Count) & "1")
        objRango.Font.Bold = True
        objRango.Cells.Interior.ColorIndex = 35

        objRango.Cells.Borders(Excel.XlBordersIndex.xlDiagonalDown).LineStyle = Excel.XlLineStyle.xlLineStyleNone
        objRango.Cells.Borders(Excel.XlBordersIndex.xlDiagonalUp).LineStyle = Excel.XlLineStyle.xlLineStyleNone
        objRango.Cells.Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlLineStyleNone
        objRango.Cells.Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
        objRango.Cells.Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
        objRango.Cells.Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous

        '//////////////////////////////////////////
        '// Cargamos todas las filas del datatable
        '//////////////////////////////////////////
        ProgressBar1.Maximum = DgvResultado.Rows.Count
        columna = 1
        ProgressBar1.Value = 0
        For Each dr In DgvResultado.Rows
            columna = 1
            For Each dc As DataGridViewColumn In DgvResultado.Columns
                '  objHojaExcel.Range(nombreColumna(columna) & fila).Value = dr(dc.DataGridView)
                columna += 1
            Next
            fila += 1
            ProgressBar1.Value += 1
        Next

        '//////////////////////////////////////
        '// Ajustamos automaticamente el ancho
        '// de todas las columnas utilizada
        '//////////////////////////////////////
        objRango = objHojaExcel.Range("A1:" & nombreColumna(DgvResultado.Columns.Count) & DgvResultado.Rows.Count.ToString)
        objRango.Select()
        objRango.Columns.AutoFit()

        '/////////////////////////////////////
        '// Le decimos a Excel que se muestre
        '/////////////////////////////////////
        MsgBox("Exportación a Excel completa", MsgBoxStyle.Information, ".:: solovb.net ::.")
        m_Excel.Visible = True

    End Sub


    Public Function nombreColumna(ByVal numero As Integer) As String
        Dim columna(256) As String

        columna(1) = "A"
        columna(2) = "B"
        columna(3) = "C"
        columna(4) = "D"
        columna(5) = "E"
        columna(6) = "F"
        columna(7) = "G"
        columna(8) = "H"
        columna(9) = "I"
        columna(10) = "J"
        columna(11) = "K"
        columna(12) = "L"
        columna(13) = "M"
        columna(14) = "N"
        columna(15) = "O"
        columna(16) = "P"
        columna(17) = "Q"
        columna(18) = "R"
        columna(19) = "S"
        columna(20) = "T"
        columna(21) = "U"
        columna(22) = "V"
        columna(23) = "W"
        columna(24) = "X"
        columna(25) = "Y"
        columna(26) = "Z"
        columna(27) = "AA"
        columna(28) = "AB"
        columna(29) = "AC"
        columna(30) = "AD"
        columna(31) = "AE"
        columna(32) = "AF"
        columna(33) = "AG"
        columna(34) = "AH"
        columna(35) = "AI"
        columna(36) = "AJ"
        columna(37) = "AK"
        columna(38) = "AL"
        columna(39) = "AM"
        columna(40) = "AN"
        columna(41) = "AO"
        columna(42) = "AP"
        columna(43) = "AQ"
        columna(44) = "AR"
        columna(45) = "AS"
        columna(46) = "AT"
        columna(47) = "AU"
        columna(48) = "AV"
        columna(49) = "AW"
        columna(50) = "AX"
        columna(51) = "AY"
        columna(52) = "AZ"
        columna(53) = "BA"
        columna(54) = "BB"
        columna(55) = "BC"
        columna(56) = "BD"
        columna(57) = "BE"
        columna(58) = "BF"
        columna(59) = "BG"
        columna(60) = "BH"
        columna(61) = "BI"
        columna(62) = "BJ"
        columna(63) = "BK"
        columna(64) = "BL"
        columna(65) = "BM"
        columna(66) = "BN"
        columna(67) = "BO"
        columna(68) = "BP"
        columna(69) = "BQ"
        columna(70) = "BR"
        columna(71) = "BS"
        columna(72) = "BT"
        columna(73) = "BU"
        columna(74) = "BV"
        columna(75) = "BW"
        columna(76) = "BX"
        columna(77) = "BY"
        columna(78) = "BZ"
        columna(79) = "CA"
        columna(80) = "CB"
        columna(81) = "CC"
        columna(82) = "CD"
        columna(83) = "CE"
        columna(84) = "CF"
        columna(85) = "CG"
        columna(86) = "CH"
        columna(87) = "CI"
        columna(88) = "CJ"
        columna(89) = "CK"
        columna(90) = "CL"
        columna(91) = "CM"
        columna(92) = "CN"
        columna(93) = "CO"
        columna(94) = "CP"
        columna(95) = "CQ"
        columna(96) = "CR"
        columna(97) = "CS"
        columna(98) = "CT"
        columna(99) = "CU"
        columna(100) = "CV"
        columna(101) = "CW"
        columna(102) = "CX"
        columna(103) = "CY"
        columna(104) = "CZ"
        columna(105) = "DA"
        columna(106) = "DB"
        columna(107) = "DC"
        columna(108) = "DD"
        columna(109) = "DE"
        columna(110) = "DF"
        columna(111) = "DG"
        columna(112) = "DH"
        columna(113) = "DI"
        columna(114) = "DJ"
        columna(115) = "DK"
        columna(116) = "DL"
        columna(117) = "DM"
        columna(118) = "DN"
        columna(119) = "DO"
        columna(120) = "DP"
        columna(121) = "DQ"
        columna(122) = "DR"
        columna(123) = "DS"
        columna(124) = "DT"
        columna(125) = "DU"
        columna(126) = "DV"
        columna(127) = "DW"
        columna(128) = "DX"
        columna(129) = "DY"
        columna(130) = "DZ"
        columna(131) = "EA"
        columna(132) = "EB"
        columna(133) = "EC"
        columna(134) = "ED"
        columna(135) = "EE"
        columna(136) = "EF"
        columna(137) = "EG"
        columna(138) = "EH"
        columna(139) = "EI"
        columna(140) = "EJ"
        columna(141) = "EK"
        columna(142) = "EL"
        columna(143) = "EM"
        columna(144) = "EN"
        columna(145) = "EO"
        columna(146) = "EP"
        columna(147) = "EQ"
        columna(148) = "ER"
        columna(149) = "ES"
        columna(150) = "ET"
        columna(151) = "EU"
        columna(152) = "EV"
        columna(153) = "EW"
        columna(154) = "EX"
        columna(155) = "EY"
        columna(156) = "EZ"
        columna(157) = "FA"
        columna(158) = "FB"
        columna(159) = "FC"
        columna(160) = "FD"
        columna(161) = "FE"
        columna(162) = "FF"
        columna(163) = "FG"
        columna(164) = "FH"
        columna(165) = "FI"
        columna(166) = "FJ"
        columna(167) = "FK"
        columna(168) = "FL"
        columna(169) = "FM"
        columna(170) = "FN"
        columna(171) = "FO"
        columna(172) = "FP"
        columna(173) = "FQ"
        columna(174) = "FR"
        columna(175) = "FS"
        columna(176) = "FT"
        columna(177) = "FU"
        columna(178) = "FV"
        columna(179) = "FW"
        columna(180) = "FX"
        columna(181) = "FY"
        columna(182) = "FZ"
        columna(183) = "GA"
        columna(184) = "GB"
        columna(185) = "GC"
        columna(186) = "GD"
        columna(187) = "GE"
        columna(188) = "GF"
        columna(189) = "GG"
        columna(190) = "GH"
        columna(191) = "GI"
        columna(192) = "GJ"
        columna(193) = "GK"
        columna(194) = "GL"
        columna(195) = "GM"
        columna(196) = "GN"
        columna(197) = "GO"
        columna(198) = "GP"
        columna(199) = "GQ"
        columna(200) = "GR"
        columna(201) = "GS"
        columna(202) = "GT"
        columna(203) = "GU"
        columna(204) = "GV"
        columna(205) = "GW"
        columna(206) = "GX"
        columna(207) = "GY"
        columna(208) = "GZ"
        columna(209) = "HA"
        columna(210) = "HB"
        columna(211) = "HC"
        columna(212) = "HD"
        columna(213) = "HE"
        columna(214) = "HF"
        columna(215) = "HG"
        columna(216) = "HH"
        columna(217) = "HI"
        columna(218) = "HJ"
        columna(219) = "HK"
        columna(220) = "HL"
        columna(221) = "HM"
        columna(222) = "HN"
        columna(223) = "HO"
        columna(224) = "HP"
        columna(225) = "HQ"
        columna(226) = "HR"
        columna(227) = "HS"
        columna(228) = "HT"
        columna(229) = "HU"
        columna(230) = "HV"
        columna(231) = "HW"
        columna(232) = "HX"
        columna(233) = "HY"
        columna(234) = "HZ"
        columna(235) = "IA"
        columna(236) = "IB"
        columna(237) = "IC"
        columna(238) = "ID"
        columna(239) = "IE"
        columna(240) = "IF"
        columna(241) = "IG"
        columna(242) = "IH"
        columna(243) = "II"
        columna(244) = "IJ"
        columna(245) = "IK"
        columna(246) = "IL"
        columna(247) = "IM"
        columna(248) = "IN"
        columna(249) = "IO"
        columna(250) = "IP"
        columna(251) = "IQ"
        columna(252) = "IR"
        columna(253) = "IS"
        columna(254) = "IT"
        columna(255) = "IU"
        columna(256) = "IV"

        Return columna(numero)
    End Function




    'Sub procesa()

    '    Dim WhereR As String = "AND"
    '    Dim WhereD As String = ""


    '    If ck_es0.Checked = True Then
    '        whereestado0 = "' OR  caj_ped=0  '"
    '    Else
    '        whereestado0 = ""
    '    End If


    '    If ck_es1.Checked = True Then

    '    End If



    '    If ck_es2.Checked = True Then

    '    End If
    '    If ck_es3.Checked = True Then

    '    End If








    '    Dim s As String = "* FROM DetaReceCajas INNER JOIN rackdeta ON racd_codi=Caj_Pcod INNER JOIN detarece ON drec_codi=racd_codi  " +
    '                                                 "WHERE drec_codpro=mae_codi AND mae_tipenv=tenv_codi AND drec_rutcli='" + LblCliente.Text + "' " +
    '                                                 "" + WhereR + " GROUP BY drec_codpro, mae_descr, tenv_descr"

    '    Dim tabla As DataTable = fnc.ListarTablasSQL(s)



    '    For i As Integer = 0 To tabla.Rows.Count - 1

    '        Dim SQl_RECEPCIONADO As String = "SELECT isnull(SUM(drec_pallet),0), isnull(SUM(drec_unidades),0), isnull(SUM(drec_peso),0) FROM detarece WHERE " +
    '                       "drec_codpro='" + tabla.Rows(i)(0).ToString() + "' AND drec_rutcli='" + LblCliente.Text + "' AND drec_fecrec<='" + devuelve_fecha(DtFecha.Value) + "' AND drec_codvig='0' " + WhereR

    '        Dim SQL_DESPACHADO As String = "SELECT isnull(SUM(ddes_pallet),0), isnull(SUM(ddes_unidades),0), isnull(SUM(ddes_peso),0) FROM detadespa WHERE " +
    '            "ddes_codpro='" + tabla.Rows(i)(0).ToString() + "' AND ddes_rutcli='" + LblCliente.Text + "' AND " +
    '            "ddes_fecha<='" + devuelve_fecha(DtFecha.Value) + "' " + WhereD


    '        Dim Tabla_Recepcionado As DataTable = fnc.ListarTablasSQL(SQl_RECEPCIONADO)
    '        Dim Tabla_Despachado As DataTable = fnc.ListarTablasSQL(SQL_DESPACHADO)

    '        If Val(Tabla_Recepcionado.Rows(0)(0).ToString()) - Val(Tabla_Despachado.Rows(0)(0).ToString()) <> 0 AndAlso Val(Tabla_Recepcionado.Rows(0)(1).ToString()) - Val(Tabla_Despachado.Rows(0)(1).ToString()) <> 0 _
    '            AndAlso Val(Tabla_Recepcionado.Rows(0)(2).ToString()) - Val(Tabla_Despachado.Rows(0)(2).ToString()) <> 0 Then

    '            DgvResultado.Rows.Add(tabla.Rows(i)(0).ToString(), tabla.Rows(i)(1).ToString(), tabla.Rows(i)(2).ToString(),
    '                              Val(Tabla_Recepcionado.Rows(0)(0).ToString()) - Val(Tabla_Despachado.Rows(0)(0).ToString()),
    '                              Val(Tabla_Recepcionado.Rows(0)(1).ToString()) - Val(Tabla_Despachado.Rows(0)(1).ToString()),
    '                              Convert.ToDouble(Tabla_Recepcionado.Rows(0)(2).ToString()) - Convert.ToDouble(Tabla_Despachado.Rows(0)(2).ToString()))

    '        End If


    '    Next



    '    Threading.Thread.Sleep(1000)

    '    btn_nuevo.Enabled = True
    '    btn_Imprimir.Enabled = True


    'End Sub

    Private Sub GroupBox3_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox3.Enter

    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ck_es0.CheckedChanged


    End Sub
    Public Sub ExportarDatosExcel(ByVal DataGridView1 As DataGridView, Optional ByVal titulo As String = "", Optional ByVal subtitulo As String = "")
        Dim m_Excel As New Excel.Application
        m_Excel.Cursor = Excel.XlMousePointer.xlWait
        m_Excel.Visible = True


        Dim objLibroExcel As Excel.Workbook = m_Excel.Workbooks.Add
        Dim objHojaExcel As Excel.Worksheet = objLibroExcel.Worksheets(1)
        With objHojaExcel
            .Visible = Excel.XlSheetVisibility.xlSheetVisible
            .Activate()
            'Encabezado  
            .Range("A1:L1").Merge()
            .Range("A1:L1").Value = titulo
            .Range("A1:L1").Font.Bold = True
            .Range("A1:L1").Font.Size = 15
            'Copete  
            .Range("A2:L2").Merge()
            .Range("A2:L2").Value = subtitulo
            .Range("A2:L2").Font.Bold = True
            .Range("A2:L2").Font.Size = 12
            .Name = "Resumen Checklist"
            Const primeraLetra As Char = "A"
            Const primerNumero As Short = 3
            Dim Letra As Char, UltimaLetra As Char
            Dim Numero As Integer, UltimoNumero As Integer
            Dim cod_letra As Byte = Asc(primeraLetra) - 1
            Dim sepDec As String = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator
            Dim sepMil As String = Application.CurrentCulture.NumberFormat.NumberGroupSeparator
            'Establecer formatos de las columnas de la hija de cálculo  
            Dim strColumna As String = ""
            Dim LetraIzq As String = ""
            Dim cod_LetraIzq As Byte = Asc(primeraLetra) - 1
            Letra = primeraLetra
            Numero = primerNumero
            Dim objCelda As Excel.Range
            For Each c As DataGridViewColumn In DataGridView1.Columns
                If c.Visible Then
                    If Letra = "Z" Then
                        Letra = primeraLetra
                        cod_letra = Asc(primeraLetra)
                        cod_LetraIzq += 1
                        LetraIzq = Chr(cod_LetraIzq)
                    Else
                        cod_letra += 1
                        Letra = Chr(cod_letra)
                    End If
                    strColumna = LetraIzq + Letra + Numero.ToString
                    objCelda = .Range(strColumna, Type.Missing)
                    objCelda.Value = c.HeaderText
                    ' objCelda.EntireColumn.
                    'objCelda.EntireColumn.NumberFormat = c.DefaultCellStyle.Format  
                    If c.ValueType Is GetType(Decimal) OrElse c.ValueType Is GetType(Double) Then
                        objCelda.EntireColumn.NumberFormat = "#" + sepMil + "0" + sepDec + "00"
                    End If
                End If
            Next

            Dim objRangoEncab As Excel.Range = .Range(primeraLetra + Numero.ToString, LetraIzq + Letra + Numero.ToString)
            objRangoEncab.BorderAround(1, Excel.XlBorderWeight.xlMedium)
            UltimaLetra = Letra
            Dim UltimaLetraIzq As String = LetraIzq

            'CARGA DE DATOS  
            Dim i As Integer = Numero + 1

            For Each reg As DataGridViewRow In DataGridView1.Rows
                LetraIzq = ""
                cod_LetraIzq = Asc(primeraLetra) - 1
                Letra = primeraLetra
                cod_letra = Asc(primeraLetra) - 1
                For Each c As DataGridViewColumn In DataGridView1.Columns
                    If c.Visible Then
                        If Letra = "Z" Then
                            Letra = primeraLetra
                            cod_letra = Asc(primeraLetra)
                            cod_LetraIzq += 1
                            LetraIzq = Chr(cod_LetraIzq)
                        Else
                            cod_letra += 1
                            Letra = Chr(cod_letra)
                        End If
                        strColumna = LetraIzq + Letra
                        ' acá debería realizarse la carga  
                        .Cells(i, strColumna) = IIf(IsDBNull(reg.ToString), "", reg.Cells(c.Index).Value)
                        .Cells.Interior.ColorIndex = 2
                        '.Cells(i, strColumna) = IIf(IsDBNull(reg.(c.DataPropertyName)), c.DefaultCellStyle.NullValue, reg(c.DataPropertyName))  
                        '.Range(strColumna + i, strColumna + i).In()  

                    End If
                Next
                Dim objRangoReg As Excel.Range = .Range(primeraLetra + i.ToString, strColumna + i.ToString)
                objRangoReg.Rows.BorderAround()
                objRangoReg.Select()
                i += 1
            Next
            UltimoNumero = i

            'Dibujar las líneas de las columnas  
            LetraIzq = ""
            cod_LetraIzq = Asc("A")
            cod_letra = Asc(primeraLetra)
            Letra = primeraLetra
            For Each c As DataGridViewColumn In DataGridView1.Columns
                If c.Visible Then
                    objCelda = .Range(LetraIzq + Letra + primerNumero.ToString, LetraIzq + Letra + (UltimoNumero - 1).ToString)
                    objCelda.BorderAround()
                    If Letra = "Z" Then
                        Letra = primeraLetra
                        cod_letra = Asc(primeraLetra)
                        LetraIzq = Chr(cod_LetraIzq)
                        cod_LetraIzq += 1
                    Else
                        cod_letra += 1
                        Letra = Chr(cod_letra)
                    End If
                End If
            Next

            If titulo = "STOCK CAJAS" Then
                .Range("A3:Z3").Interior.ColorIndex = 23
                .Range("A3:Z3").Font.Bold = True
                .Range("A3:Z3").Font.ColorIndex = 2
            ElseIf titulo = "Posiciones Libres" Then
                .Range("A3:D3").Interior.ColorIndex = 23
                .Range("A3:D3").Font.Bold = True
                .Range("A3:D3").Font.ColorIndex = 2
            End If

            ' .Cells(3, 2).Selection.RowHeight = 28
            'Dibujar el border exterior grueso  
            Dim objRango As Excel.Range = .Range(primeraLetra + primerNumero.ToString, UltimaLetraIzq + UltimaLetra + (UltimoNumero - 1).ToString)
            objRango.Select()
            objRango.Columns.AutoFit()
            objRango.Columns.BorderAround(1, Excel.XlBorderWeight.xlMedium)

        End With

        m_Excel.Cursor = Excel.XlMousePointer.xlDefault
    End Sub

    Private Sub btn_Imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Imprimir.Click
        'ExportarExcel(DgvResultado2)
        'Try
        '    'Intentar generar el documento.
        '    'Se adjunta un texto debajo del encabezado con la fecha actual del sistema.
        '    ExportarDatosExcel(DgvResultado, "Stock : " + Now.Date())
        'Catch ex As Exception
        '    'Si el intento es fallido, mostrar MsgBox.
        '    MessageBox.Show("No se puede generar el documento Excel.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
        Dim fecha As String = FormatDateTime(Now())
        Dim dt1 As New DateTime(DateTime.Now.Ticks)
        ExportarDatosExcel(DgvResultado2, "STOCK CAJAS REPETIDAS " + dt1
                           )
        ' expex()


    End Sub

    Private Sub btn_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        Me.Btn_Calcular.Enabled = True
        btn_nuevo.Enabled = False
        btn_Imprimir.Enabled = False
        Me.GroupBox1.Enabled = True
        For i As Integer = 0 To DgvResultado.RowCount - 1
            DgvResultado.Rows.RemoveAt(0)
        Next
        For i As Integer = 0 To DgvResultado2.RowCount - 1
            DgvResultado2.Rows.RemoveAt(0)
        Next
        Txtcliente.Text = ""
        LblCliente.Text = ""
        txtTotal.Text = ""

    End Sub

    Private Sub Btn_Salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Salir.Click
        Close()
    End Sub

    Private Sub Frm_RecuentoCajRPT_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        f_recuentoCjRPT = False
    End Sub
End Class
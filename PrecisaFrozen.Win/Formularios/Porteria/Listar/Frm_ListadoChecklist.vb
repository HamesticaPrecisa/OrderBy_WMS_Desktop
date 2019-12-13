Imports System
Imports System.Threading
Imports Microsoft.Office.Interop

Public Class Frm_ListadoChecklist


    Dim fnc As New Funciones
    Dim thread As Threading.Thread

    Private Sub Frm_ListadoChecklist_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            f_IngresoSalida = False
            thread.Abort("d")
        Catch ex As Exception

        End Try



    End Sub

    Sub busca_info_adicional()
        Dim filtro As String = ""
        If CBCLIENTE.Checked = False Then
            filtro = filtro + " AND cl_rutcli='" + TxtClirut.Text + "' "
        End If
        If CBFECHA.Checked = False Then
            filtro = filtro + " AND cl_lleg>=Convert(datetime,'" + devuelve_fecha_Formato2(dtfecha1.Value) + " 00:00:00' ) " +
                              " AND cl_lleg<=Convert(datetime,'" + devuelve_fecha_Formato2(dtfecha2.Value) + " 23:59:59' ) "
        End If

        BtnFiltrar.Enabled = False
        Dim sqlPrincipal As String = "SELECT cl_fol, usu_nombre+' '+usu_ap AS usu_nombre, tur_desc, cli_nomb, " +
                    "SUBSTRING(cho_rut, 0,3)+'.'+SUBSTRING(cho_rut,3,3)+'.'+SUBSTRING(cho_rut, 6,3)+'-'+SUBSTRING(cho_rut, 9,9) AS cho_rut, cho_nombre ,  " +
                    "Cl_ChoEmp, mov_desc, 'S/T' AS Temp , cl_pate, cl_ram, 'S/G' AS GUIA_ENTRADA,  'S/G' AS GUIA_SALIDA,  '-' AS SOPORT_ENTRADA, '-' AS SOPORT_SALIDA, " +
                    "convert(nvarchar(20),cl_lleg , 20) AS Fecha1 , " +
                    "convert(nvarchar(MAX),cl_ing, 20) AS Fecha2 , " +
                    "convert(nvarchar(MAX),cl_des, 20) AS Fecha3, '-' AS NRECEPCION,'-' AS NDESPACHO," +
                    "datediff(day,'19000101',cl_ing-cl_lleg) AS D1, CONVERT (VARCHAR(19),cl_ing-cl_lleg,108) AS F1, " +
                    "datediff(day,'19000101',cl_des-cl_ing) AS D2, CONVERT (VARCHAR(19),cl_des-cl_ing,108) AS F2, " +
                    "datediff(day,'19000101',cl_des-cl_lleg) AS D3, CONVERT (VARCHAR(19),cl_des-cl_lleg,108) AS F3 , cl_anden as DESTINO " +
                    "FROM clientes, zCheckList, P_MovChecklist, choferes, usuarios, P_turnos " +
                    "WHERE mov_codi = Cl_Mov And cli_rut = Cl_RutCli And cho_rut = Cl_chorut And usu_codigo = cl_gs And tur_codi = Cl_Tur " + filtro + " " +
                    "ORDER BY cl_fol DESC"


        DgvResultados.DataSource = fnc.ListarTablasSQL(sqlPrincipal)
        If DgvResultados.Rows.Count > 0 Then
            ProgressBar1.Maximum = DgvResultados.Rows.Count - 1

            For i As Integer = 0 To DgvResultados.Rows.Count - 1
                If fnc.verificaExistencia("fichrece", "frec_clfol", DgvResultados.Rows(i).Cells("FOLIO").Value.ToString()) = True Then
                    Dim Sql As String = "SELECT Cl_Ting, frec_guiades, frec_totsopo, frec_codi FROM zCheckList, fichrece WHERE Cl_fol=frec_clfol AND Cl_fol='" + DgvResultados.Rows(i).Cells("FOLIO").Value.ToString() + "'"
                    Dim tabla As DataTable = fnc.ListarTablasSQL(Sql)
                    If tabla.Rows.Count > 0 Then
                        DgvResultados.Rows(i).Cells("TEMP").Value = tabla.Rows(0)(0).ToString()
                        DgvResultados.Rows(i).Cells("GUIA_ENTRADA").Value = tabla.Rows(0)(1).ToString()
                        DgvResultados.Rows(i).Cells("SOPORT_ENTRADA").Value = tabla.Rows(0)(2).ToString()
                        DgvResultados.Rows(i).Cells("NRECEPCION").Value = tabla.Rows(0)(3).ToString()

                    End If
                End If

                If fnc.verificaExistencia("fichdespa", "fdes_clfol", DgvResultados.Rows(i).Cells("FOLIO").Value.ToString()) = True Then
                    Dim sql As String = "SELECT Cl_DesTemp, fdes_GuiaCliente, fdes_totsopo, fdes_codi FROM zCheckList, fichdespa WHERE Cl_fol=fdes_clfol AND Cl_fol='" + DgvResultados.Rows(i).Cells("FOLIO").Value.ToString() + "'"
                    Dim tabla As DataTable = fnc.ListarTablasSQL(sql)
                    If tabla.Rows.Count > 0 Then
                        DgvResultados.Rows(i).Cells("TEMP").Value = tabla.Rows(0)(0).ToString()
                        DgvResultados.Rows(i).Cells("GUIA_SALIDA").Value = tabla.Rows(0)(1).ToString()
                        DgvResultados.Rows(i).Cells("SOPORT_SALIDA").Value = tabla.Rows(0)(2).ToString()
                        DgvResultados.Rows(i).Cells("NDESPACHO").Value = tabla.Rows(0)(3).ToString()
                    End If
                End If
                ProgressBar1.Increment(1)
            Next
            thread.Sleep(2000)
            ProgressBar1.Value = 0

        Else
            MsgBox("No existe información para mostrar", MsgBoxStyle.Critical, "Aviso")
        End If
        BtnNuevo.Enabled = True
        BtnSalir.Enabled = True
        BtnExcel.Enabled = True
    End Sub

    Private Sub BtnFiltrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFiltrar.Click
        filtrar()
    End Sub

    Sub filtrar()
        CheckForIllegalCrossThreadCalls = False
        thread = New Threading.Thread(AddressOf busca_info_adicional)
        'Iniciamos el subproceso.
        thread.Start()
        ' busca_info_adicional()
    End Sub

    Private Sub btn_BuscaCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_BuscaCliente.Click

        Dim frm As New Lst_AyudaClientes
        frm.ShowDialog(Frm_Principal)
        Dim RUT As String = Frm_Principal.buscavalor

        If RUT.ToString.Length > 0 Then
            If Len(RUT) >= 9 Then
                TxtClirut.Text = RUT
                txtclinom.Text = RetornaCliente(RUT)
                TxtClirut.Enabled = False
            Else
                MsgBox("El rut ingresado no existe", MsgBoxStyle.Information, "Aviso")
            End If
        End If
    End Sub

    Private Sub TxtClirut_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtClirut.KeyPress
        If e.KeyChar = ChrW(13) Then
            If TxtClirut.Text.Length >= 9 Then
                txtclinom.Text = RetornaCliente(TxtClirut.Text)
                TxtClirut.Enabled = False
            Else
                MsgBox("El rut ingresado no existe", MsgBoxStyle.Critical, "Aviso")
            End If
        End If
    End Sub

    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        BtnFiltrar.Enabled = True
        BtnNuevo.Enabled = True
        TxtClirut.Text = ""
        txtclinom.Text = ""
        dtfecha1.Value = fnc.DevuelveFechaServidor()
        dtfecha2.Value = fnc.DevuelveFechaServidor()
        CBCLIENTE.Checked = True
        CBFECHA.Checked = True
        BtnNuevo.Enabled = False
        BtnExcel.Enabled = False

        For i As Integer = 0 To DgvResultados.Rows.Count - 1
            DgvResultados.Rows.RemoveAt(0)
        Next

    End Sub

    Private Sub BtnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExcel.Click
        'ExportarDatosExcel(DgvResultados, "INFORME CHECKLIST")
        GridAExcel(DgvResultados)
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

            If titulo = "INFORME CHECKLIST" Then
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


    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub
 
    Private Sub CBCLIENTE_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBCLIENTE.CheckedChanged
        If CBCLIENTE.Checked = True Then
            TxtClirut.Text = ""
            txtclinom.Text = ""
            btn_BuscaCliente.Enabled = False
        Else
            btn_BuscaCliente.Enabled = True
        End If
    End Sub

    Private Sub CBFECHA_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBFECHA.CheckedChanged
        If CBFECHA.Checked = True Then
            dtfecha1.Value = fnc.DevuelveFechaServidor()
            dtfecha2.Value = fnc.DevuelveFechaServidor()
            dtfecha1.Enabled = False
            dtfecha2.Enabled = False
        Else
            dtfecha1.Enabled = True
            dtfecha2.Enabled = True
        End If

    End Sub
 
    Private Sub Frm_ListadoChecklist_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Frm_Principal.buscavalor = ""
        filtrar()
    End Sub
End Class
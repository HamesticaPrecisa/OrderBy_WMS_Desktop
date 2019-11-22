Imports System.Data
Imports System.Data.SqlClient
Imports System.Text.RegularExpressions
Imports System.Text
Imports System.Security.Cryptography
Imports System.IO
Imports CrystalDecisions.Data.AdoDotNetInterop.InternalXmlSchemaDependencyTree


Module ModPublico

    Dim fnc As New Funciones

    Public Function devuelve_fecha(ByVal fecha As DateTime) As String
        Dim a, m, d As String

        d = fecha.Day
        If Val(d) < 10 Then d = "0" & d
        m = fecha.Month
        If Val(m) < 10 Then m = "0" & m
        a = fecha.Year
        devuelve_fecha = a & "/" & m & "/" & d
        Return devuelve_fecha
    End Function

    Public Function devuelve_fecha_Formato2(ByVal fecha As DateTime) As String
        Dim a, m, d As String

        d = fecha.Day
        If Val(d) < 10 Then d = "0" & d
        m = fecha.Month
        If Val(m) < 10 Then m = "0" & m
        a = fecha.Year
        devuelve_fecha_Formato2 = d & "/" & m & "/" & a
        Return devuelve_fecha_Formato2
    End Function

    Public Function RutDigito(ByVal Rut As String) As Boolean


        Dim sql As String = "SELECT valconf from conf_general where nombreconf='VALIDAR RUT'"

        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)
        If tabla.Rows.Count > 0 Then
            Dim nosi As String = ""
            nosi = tabla.Rows(0)(0)


            If nosi.Trim() = "1" Then


            End If

            If nosi.Trim() = "0" Then
                RutDigito = True
                Exit Function
            End If
        End If





        Try
            Dim ru, RU2 As Integer
            Dim Digito As Integer
            Dim Contador As Integer
            Dim Multiplo As Integer
            Dim Acumulador As Integer
            Dim r As String
            Rut = Rut.ToUpper()
            If Len(Rut) >= 9 Then
                ru = Mid(Rut, 1, Len(Rut) - 2)
                RU2 = ru
                Contador = 2
                Acumulador = 0
                While ru <> 0
                    Multiplo = (ru Mod 10) * Contador
                    Acumulador = Acumulador + Multiplo
                    ru = ru \ 10
                    Contador = Contador + 1
                    If Contador = 8 Then
                        Contador = 2
                    End If
                End While
                Digito = 11 - (Acumulador Mod 11)

                r = RU2 & "-" & CStr(Digito)
                If Digito = 10 Then r = RU2 & "-" & "K"
                If Digito = 11 Then r = RU2 & "-" & "0"

                If r = Rut Or "0" + r = Rut Then
                    RutDigito = True
                ElseIf CerosAnteriorString(r, 10) = Rut Then

                    RutDigito = True
                Else
                    RutDigito = False
                End If
            Else

                RutDigito = False
            End If
        Catch ex As Exception
            RutDigito = False
        End Try

    End Function

    Public Function FncConvierteNumero(ByVal mone As String) As Double
        Dim largo As Integer
        Dim cons, str As String

        cons = ""
        str = ""
        largo = Len(mone)
        For i = 1 To largo
            cons = Mid(mone, i, 1)
            If IsNumeric(cons) Then
                str = str & cons
            End If
        Next
        Return Val(str)
    End Function

    Public Sub SoloNumeros(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Public Sub SoloKilos(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If Not ((KeyAscii >= System.Windows.Forms.Keys.D0 And KeyAscii <= System.Windows.Forms.Keys.D9) Or
                (KeyAscii = System.Windows.Forms.Keys.Back) Or Chr(KeyAscii) = "." Or (Chr(KeyAscii) Like "[ ]")) Then
            KeyAscii = 0
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If

        If sender.Text.IndexOf(".") >= 0 And e.KeyChar = "." Then
            e.Handled = True
        End If

        If sender.Text.IndexOf(".") > 0 Then
            'System.Console.WriteLine(sender.SelectionStart)
            'System.Console.WriteLine(sender.Text.IndexOf("."))
            If sender.SelectionStart > sender.Text.IndexOf(".") Then
                If sender.Text.Length - sender.Text.IndexOf(".") = 3 AndAlso KeyAscii <> 8 Then
                    e.Handled = True
                End If
            End If
        End If
    End Sub

    Function GridAExcel(ByVal ElGrid As DataGridView) As Boolean
        'Creamos las variables
        Dim exApp As New Microsoft.Office.Interop.Excel.Application
        Dim exLibro As Microsoft.Office.Interop.Excel.Workbook
        Dim exHoja As Microsoft.Office.Interop.Excel.Worksheet
        Try
            'Añadimos el Libro al programa, y la hoja al libro
            exLibro = exApp.Workbooks.Add
            exHoja = exLibro.Worksheets.Add()
            ' ¿Cuantas columnas y cuantas filas?
            Dim NCol As Integer = ElGrid.ColumnCount
            Dim NRow As Integer = ElGrid.RowCount
            'Aqui recorremos todas las filas, y por cada fila todas las columnas y vamos escribiendo.
            For i As Integer = 1 To NCol
                exHoja.Cells.Item(1, i) = ElGrid.Columns(i - 1).Name.ToString
                'exHoja.Cells.Item(1, i).HorizontalAlignment = 3
            Next
            For Fila As Integer = 0 To NRow - 1
                For Col As Integer = 0 To NCol - 1
                    If (Not IsNothing(ElGrid.Rows(Fila).Cells(Col).Value)) Then
                        If (ElGrid.Rows(Fila).Cells(Col).Value.ToString.Trim.Contains("-") Or ElGrid.Rows(Fila).Cells(Col).Value.ToString.Trim.Contains("/")) Then
                            Dim fecFrm As Date
                            If (Date.TryParse(ElGrid.Rows(Fila).Cells(Col).Value.ToString, fecFrm)) Then
                                'Si es datetime
                                If (ElGrid.Rows(Fila).Cells(Col).Value.ToString.Trim.Contains(":")) Then
                                    exHoja.Cells.Item(Fila + 2, Col + 1) = fecFrm.ToString("yyyy-MM-dd HH:mm:ss")
                                    exHoja.Cells.Item(Fila + 2, Col + 1).NumberFormat = "dd-MM-yyyy HH:mm:ss"
                                Else
                                    exHoja.Cells.Item(Fila + 2, Col + 1) = fecFrm.ToString("yyyy-MM-dd")
                                    exHoja.Cells.Item(Fila + 2, Col + 1).NumberFormat = "dd-MM-yyyy"
                                End If
                            Else
                                exHoja.Cells.Item(Fila + 2, Col + 1) = ElGrid.Rows(Fila).Cells(Col).Value
                            End If
                        Else
                            exHoja.Cells.Item(Fila + 2, Col + 1) = ElGrid.Rows(Fila).Cells(Col).Value
                        End If
                    End If
                Next
            Next
            'Titulo en negrita, Alineado al centro y que el tamaño de la columna se ajuste al texto
            exHoja.Rows.Item(1).Font.Bold = 1
            exHoja.Rows.Item(1).HorizontalAlignment = 3
            exHoja.Columns.AutoFit()
            'exHoja.Columns("E:G").NumberFormat = "dd-MM-yyyy"
            'Aplicación visible
            exApp.Application.Visible = True

            exHoja = Nothing
            exLibro = Nothing
            exApp = Nothing



        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al exportar a Excel")
            Return False
        End Try

        Return True

    End Function

    Function GridAExcel2(ByVal ElGrid As DataGridView) As Boolean
        'Creamos las variables
        Dim exApp As New Microsoft.Office.Interop.Excel.Application
        Dim exLibro As Microsoft.Office.Interop.Excel.Workbook
        Dim exHoja As Microsoft.Office.Interop.Excel.Worksheet
        Try
            'Añadimos el Libro al programa, y la hoja al libro
            exLibro = exApp.Workbooks.Add
            exHoja = exLibro.Worksheets.Add()
            ' ¿Cuantas columnas y cuantas filas?
            Dim NCol As Integer = ElGrid.ColumnCount
            Dim NRow As Integer = ElGrid.RowCount
            'Aqui recorremos todas las filas, y por cada fila todas las columnas y vamos escribiendo.
            For i As Integer = 1 To NCol
                exHoja.Cells.Item(1, i) = ElGrid.Columns(i - 1).Name.ToString
                'exHoja.Cells.Item(1, i).HorizontalAlignment = 3
            Next
            For Fila As Integer = 0 To NRow - 1
                For Col As Integer = 0 To NCol - 1
                    exHoja.Cells.Item(Fila + 2, Col + 1) = ElGrid.Rows(Fila).Cells(Col).Value
                Next
            Next
            'Titulo en negrita, Alineado al centro y que el tamaño de la columna se ajuste al texto
            exHoja.Rows.Item(1).Font.Bold = 1
            exHoja.Rows.Item(1).HorizontalAlignment = 3
            exHoja.Columns.AutoFit()
            'exHoja.Columns("E:G").NumberFormat = "dd-MM-yyyy"
            'Aplicación visible
            exApp.Application.Visible = True

            exHoja = Nothing
            exLibro = Nothing
            exApp = Nothing



        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al exportar a Excel")
            Return False
        End Try

        Return True

    End Function

    Sub LimpiarCajas(ByVal Objeto As Object)
        For Each c As Control In Objeto.Controls
            If TypeOf c Is TextBox Then
                c.Text = ""
            End If
        Next
    End Sub

    Sub LimpiarCajasMaskedTextBox(ByVal Objeto As Object)
        For Each c As Control In Objeto.Controls
            If TypeOf c Is MaskedTextBox Then
                c.Text = ""
            End If
        Next
    End Sub

    Public Function QuitarCaracteres(ByVal cadena As String, Optional ByVal chars As String = ".:<>{}[]^+,;_-/*?¿!$%&/¨Ññ()='áéíóúÁÉÍÓÚ¡" + Chr(34)) As String
        Dim i As Integer
        Dim nCadena As String
        'Asignamos valor a la cadena de trabajo para
        'no modificar la que envía el cliente.
        nCadena = cadena
        For i = 1 To Len(chars)
            nCadena = Replace(nCadena, Mid(chars, i, 1), "")
        Next i
        'Devolvemos la cadena tratada
        QuitarCaracteres = nCadena
        Return nCadena
    End Function

    Function CerosAnteriorString(ByVal numero As String, ByVal largo As Integer)

        Dim valorCeros As String = ""

        For i As Integer = 0 To ((largo - 1) - numero.Length)
            valorCeros = valorCeros + "0"
        Next

        Return valorCeros + numero
    End Function

    Function CerosPosteriorString(ByVal numero As String, ByVal largo As Integer)

        Dim valorCeros As String = ""

        For i As Integer = 0 To ((largo - 1) - numero.Length)
            valorCeros = valorCeros + "0"
        Next

        Return numero + valorCeros
    End Function

    Public Function validar_Mail(ByVal sMail As String) As Boolean
        ' retorna true o false   
        Return Regex.IsMatch(sMail, _
                "^([\w-]+\.)*?[\w-]+@[\w-]+\.([\w-]+\.)*?[\w]+$")
    End Function

    Public Sub ValidaTemperatura(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        If Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> ChrW(189) Or e.KeyChar <> ChrW(109) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) AndAlso e.KeyChar <> ChrW(45) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Public Function ValidarHora(ByVal texto As String) As Boolean
        Dim ValidaHora As Boolean = IsDate(texto)
        Return ValidaHora
    End Function

    Public Function DevuelveHora(Optional ByVal hora As DateTime = Nothing) As String
        If hora = Nothing Then
            hora = fnc.DevuelveFechaServidor()
        End If
        Dim horaReturn As String = hora.ToString("HH:mm")
        Return horaReturn
    End Function

    Public Function GeneraNumeroDePallet(ByVal numero_Pallet As String) As String

        Dim sumapar As Integer = 0
        Dim sumaimp As Integer = 0

        Dim numeroVerificador As Integer = 0
        Dim impares As Integer = 0

        For i As Integer = 1 To Len(numero_Pallet)
            If i Mod 2 = 0 Then
                sumapar = sumapar + Val(Mid(numero_Pallet, i, 1))
            Else
                sumaimp = sumaimp + Val(Mid(numero_Pallet, i, 1))
            End If
        Next

        impares = (sumaimp * 3) + sumapar

        For i As Integer = 1 To 100
            If impares <= i * 10 Then
                Exit For
            End If
        Next i

        numeroVerificador = impares * 10 - impares

        Dim numero As String = numero_Pallet + numeroVerificador
        Return numero
    End Function

    Public Function EstadoCheckBox(ByVal check As Integer) As String
        Dim estado As String = "" + check.ToString()
        Return estado
    End Function

    '12 Digitos + Verificador
    Function DigitoVerificadorEAN13(ByVal numero As String) As Integer


        Dim separado(12) As String
        Dim valores(12) As Integer

        Dim suma As Integer = 0

        For i As Integer = 0 To numero.Length - 1
            separado(i) = numero.Chars(i)
        Next


        For i As Integer = 0 To separado.Length - 1
            If i Mod 2 = 0 Then
                suma = Convert.ToInt32(suma + (Val(separado(i)) * 1))

            Else
                suma = Convert.ToInt32(suma + (Val(separado(i)) * 3))

            End If
        Next

        Dim multiplo As Integer = 0


        For i As Integer = 0 To suma Step 10

            multiplo = multiplo + 10
        Next


        Dim verificador As Integer = multiplo - suma
        If verificador = 10 Then
            verificador = 0
        End If

        Return verificador
    End Function

    '17 Digitos + Verificador
    Function DigitoVerificadorEAN128UCC(ByVal numero As String) As String

        Dim separado(20) As String
        Dim valores(20) As Integer

        Dim suma As Integer = 0

        For i As Integer = 0 To numero.Length - 1
            separado(i) = numero.Chars(i)
        Next


        For i As Integer = 0 To separado.Length - 1
            If i Mod 2 = 1 Then
                suma = Convert.ToInt32(suma + (Val(separado(i)) * 1))
            Else
                suma = Convert.ToInt32(suma + (Val(separado(i)) * 3))
            End If
        Next

        Dim multiplo As Integer = 0


        For i As Integer = 0 To suma Step 10
            multiplo = multiplo + 10
        Next


        Dim verificador As Integer = multiplo - suma

        If verificador = 10 Then
            verificador = 0
        End If


        Return numero & "" & verificador.ToString()
    End Function


    Function ValidadorContenedor(ByVal contenedor As String) As Boolean 'Formato PONU 894235-8
        ValidadorContenedor = 0
        Dim cont As String = contenedor
        Dim dig As Integer = 0

        If contenedor.Length <> 13 Then
            ValidadorContenedor = False
        Else
            Dim arrayLetter() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}
            Dim arrayValor() As Integer = {10, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 34, 35, 36, 37, 38}
            Dim numeros() As Integer = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
            Dim numerosMult() As Integer = {1, 2, 4, 8, 16, 32, 64, 128, 256, 512}

            Dim suma_numeros = 0
            Dim j = 0

            ' REEMPLAZO LOS VALORES DE LAS LETRAS POR LOS NUMEROS Y DEJO LOS NUMEROS IGUAL
            For a As Integer = 0 To contenedor.Length - 3
                If a < 4 Then
                    For i As Integer = 0 To arrayLetter.Length - 1
                        If arrayLetter(i) = contenedor.Chars(a) Then
                            numeros(a) = arrayValor(i)
                            Exit For
                        End If
                    Next
                ElseIf a > 4 Then
                    Dim z = contenedor.Chars(a)
                    numeros(a - 1) = Val(z)

                End If
            Next

            For i As Integer = 1 To numeros.Length
                suma_numeros = suma_numeros + (Convert.ToInt32(numeros(i - 1)) * numerosMult(i - 1))
                Console.WriteLine((Convert.ToInt32(numeros(i - 1)) * numerosMult(i - 1)))
            Next

            Dim comparar As Integer = Int(suma_numeros / 11)
            dig = suma_numeros - (comparar * 11)
            If dig = 10 Then
                dig = 0
            End If
            If dig = Val(cont.Chars(cont.Length - 1)) Then
                ValidadorContenedor = True
            End If
        End If

        ' retorno 1- formato incorrecto
        Return ValidadorContenedor
    End Function

    '----------------------------------------
    '|          AYUDA_CODIGO                |
    '----------------------------------------

    Public Function BuscaCorrelativo(ByVal NCorrelat As String, Optional ByVal largo As Integer = 7) As String
        Dim CorrResp As String = "-1"

        Dim CodUsu As String = Frm_Principal.InfoUsuario.Text.Trim

        Dim sqlCorrTemp As String = "select a.tmps_codi,a.tmps_unica from Correlat_salto a with(nolock) where a.tmps_correl='" & NCorrelat & "' and a.tmps_personal='" & CodUsu & "'"
        Dim dtCorrTemp As New DataTable
        dtCorrTemp = fnc.ListarTablasSQL(sqlCorrTemp)

        If (dtCorrTemp.Rows.Count > 0) Then
            CorrResp = dtCorrTemp.Rows(0).Item(0).ToString.Trim

            fnc.MovimientoSQL("delete from Correlat_salto where tmps_unica='" & dtCorrTemp.Rows(0).Item(1).ToString.Trim & "'")
        Else
            Dim sqlCorrAct As String = "select a.cor_correact from correlat a with(nolock) where a.cor_codi='" & NCorrelat & "'"
            Dim dtCorrAct As New DataTable

            dtCorrAct = fnc.ListarTablasSQL(sqlCorrAct)

            If (dtCorrAct.Rows.Count > 0) Then
                CorrResp = StrDup(largo, "0") & dtCorrAct.Rows(0).Item(0).ToString.Trim
                CorrResp = CorrResp.Substring(CorrResp.Length - largo, largo)

                fnc.MovimientoSQL("update correlat set cor_correact=(convert(int,cor_correact)+1) where cor_codi='" & NCorrelat & "'")
                'fnc.MovimientoSQL("insert into Correlat_salto(tmps_codi,tmps_correl,tmps_personal,tmps_fecha,tmps_gestion) values('" & CorrResp & "','" & NCorrelat & "','" & CodUsu & "',CONVERT(varchar,GETDATE(),111),'1')")
            End If
        End If

        'Log_Correlativos 27-05-19
        Dim sqlNueCorr As String = "SP_Log_Correlativos_Grabar '" & NCorrelat & "','" & CorrResp & "','" & CodUsu & "'"
        fnc.MovimientoSQL(sqlNueCorr)
        'Fin Log_Correlativos 27-05-19

        Return CorrResp

        'Dim NcorrAct As String = ""

        'Dim SqlSalto As String = "SELECT tmps_unica, tmps_codi FROM Correlat_salto WHERE tmps_correl ='" + NCorrelat + "' ORDER BY tmps_codi ASC"
        'Dim tablaSalto As DataTable = fnc.ListarTablasSQL(SqlSalto)

        'If tablaSalto.Rows.Count > 0 Then
        '    If NCorrelat = "006" Then
        '        If fnc.verificaExistencia("Fichrece", "frec_codi", tablaSalto.Rows(0)(1).ToString()) = True Then

        '            Dim sqlEliminas As String = "DELETE FROM Correlat_salto WHERE tmps_unica='" + tablaSalto.Rows(0)(0).ToString() + "'"
        '            fnc.MovimientoSQL(sqlEliminas)

        '            Dim sql As String = "SELECT cor_correact FROM correlat WHERE cor_codi='" + NCorrelat + "'"
        '            Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

        '            If tabla.Rows.Count > 0 Then
        '                NcorrAct = tabla.Rows(0)(0).ToString()

        '                Dim sqlUpdate As String = "UPDATE correlat SET cor_correact='" + (Convert.ToInt32(tabla.Rows(0)(0).ToString()) + 1).ToString() + "' " +
        '                    "WHERE cor_codi='" + NCorrelat.ToString() + "'"

        '                fnc.MovimientoSQL(sqlUpdate)

        '                'Log_Correlativos 27-05-19
        '                Dim sqlNueCorr As String = "SP_Log_Correlativos_Grabar '" & NCorrelat & "','" & NcorrAct & "','" & Frm_Principal.InfoUsuario.Text.Trim & "'"
        '                fnc.MovimientoSQL(sqlNueCorr)
        '                'Fin Log_Correlativos 27-05-19
        '            End If
        '            Return CerosAnteriorString(NcorrAct, largo)
        '            Exit Function
        '        End If
        '    End If

        '    Dim sqlEliminaSalto As String = "DELETE FROM Correlat_salto WHERE tmps_unica='" + tablaSalto.Rows(0)(0).ToString() + "'"
        '    fnc.MovimientoSQL(sqlEliminaSalto)

        '    If (tablaSalto.Rows(0)(1).ToString().Trim = "") Then
        '        Dim sql As String = "SELECT cor_correact FROM correlat WHERE cor_codi='" + NCorrelat + "'"
        '        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

        '        If tabla.Rows.Count > 0 Then
        '            NcorrAct = tabla.Rows(0)(0).ToString()

        '            Dim sqlUpdate As String = "UPDATE correlat SET cor_correact='" + (Convert.ToInt32(tabla.Rows(0)(0).ToString()) + 1).ToString() + "' " +
        '                "WHERE cor_codi='" + NCorrelat.ToString() + "'"

        '            fnc.MovimientoSQL(sqlUpdate)

        '            'Log_Correlativos 27-05-19
        '            Dim sqlNueCorr As String = "SP_Log_Correlativos_Grabar '" & NCorrelat & "','" & NcorrAct & "','" & Frm_Principal.InfoUsuario.Text.Trim & "'"
        '            fnc.MovimientoSQL(sqlNueCorr)
        '            'Fin Log_Correlativos 27-05-19
        '        End If
        '    Else
        '        'Log_Correlativos 27-05-19
        '        Dim sqlNueCorr As String = "SP_Log_Correlativos_Grabar '" & NCorrelat & "','" & tablaSalto.Rows(0)(1).ToString() & "','" & Frm_Principal.InfoUsuario.Text.Trim & "'"
        '        fnc.MovimientoSQL(sqlNueCorr)
        '        'Fin Log_Correlativos 27-05-19

        '        Return tablaSalto.Rows(0)(1).ToString()
        '        Exit Function
        '    End If
        'Else

        '    Dim sql As String = "SELECT cor_correact FROM correlat WHERE cor_codi='" + NCorrelat + "'"
        '    Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

        '    If tabla.Rows.Count > 0 Then
        '        NcorrAct = tabla.Rows(0)(0).ToString()

        '        Dim sqlUpdate As String = "UPDATE correlat SET cor_correact='" + (Convert.ToInt32(tabla.Rows(0)(0).ToString()) + 1).ToString() + "' " +
        '            "WHERE cor_codi='" + NCorrelat.ToString() + "'"

        '        fnc.MovimientoSQL(sqlUpdate)

        '        'Log_Correlativos 27-05-19
        '        Dim sqlNueCorr As String = "SP_Log_Correlativos_Grabar '" & NCorrelat & "','" & NcorrAct & "','" & Frm_Principal.InfoUsuario.Text.Trim & "'"
        '        fnc.MovimientoSQL(sqlNueCorr)
        '        'Fin Log_Correlativos 27-05-19
        '    End If
        'End If
        'Return CerosAnteriorString(NcorrAct, largo)
    End Function

    Public Function CancelaCorrelativo(ByVal NCorrelat As String, ByVal CodigoEliminar As String)
        Dim x As Integer = 0

        Dim sql_log As String = "INSERT INTO LOG_SALTOCORR(tmps_codi, tmps_correl, tmps_personal, tmps_fecha, tmps_gestion)VALUES( " +
                   "'" + CodigoEliminar + "','" + NCorrelat + "','" + Frm_Principal.InfoUsuario.Text + "','" + fnc.DevuelveFechaServidor() + "','1')"

        fnc.MovimientoSQL(sql_log)

        If CodigoEliminar = "SI" Or CodigoEliminar = "si" Or CodigoEliminar = "Si" Or CodigoEliminar = "sI" Then
            Return 1
            Exit Function
        End If

        Dim sql As String = "INSERT INTO Correlat_Salto(tmps_codi, tmps_correl, tmps_personal, tmps_fecha, tmps_gestion)VALUES( " +
            "'" + CodigoEliminar + "','" + NCorrelat + "','" + Frm_Principal.InfoUsuario.Text + "','" + devuelve_fecha(fnc.DevuelveFechaServidor()) + "','1')"

        If fnc.MovimientoSQL(sql) > 0 Then
            x = 1
        End If

        Return x
    End Function

    Public Function Encriptar(ByVal Input As String) As String

        Dim IV() As Byte = ASCIIEncoding.ASCII.GetBytes("precisaf") 'La clave debe ser de 8 caracteres
        Dim EncryptionKey() As Byte = Convert.FromBase64String("vicSPvIvVLlrcmtzPU9/c67Gkj7yL1S5") 'No se puede alterar la cantidad de caracteres pero si la clave
        Dim buffer() As Byte = Encoding.UTF8.GetBytes(Input)
        Dim des As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider
        des.Key = EncryptionKey
        des.IV = IV

        Return Convert.ToBase64String(des.CreateEncryptor().TransformFinalBlock(buffer, 0, buffer.Length()))
    End Function

    Public Function Desencriptar(ByVal Input As String) As String

        Dim IV() As Byte = ASCIIEncoding.ASCII.GetBytes("precisaf") 'La clave debe ser de 8 caracteres
        Dim EncryptionKey() As Byte = Convert.FromBase64String("vicSPvIvVLlrcmtzPU9/c67Gkj7yL1S5") 'No se puede alterar la cantidad de caracteres pero si la clave
        Dim buffer() As Byte = Convert.FromBase64String(Input)
        Dim des As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider
        des.Key = EncryptionKey
        des.IV = IV

        Return Encoding.UTF8.GetString(des.CreateDecryptor().TransformFinalBlock(buffer, 0, buffer.Length()))
    End Function

    Function RealizarAccion(ByVal Seccion As String, ByVal Subseccion As String, Optional ByVal Mensaje As Boolean = True) As Boolean
        RealizarAccion = True

        Dim sql As String = "SELECT * FROM UsuariosFunciones AS uf ,PrivilegiosSubSeccion AS us , Usuarios " +
            "WHERE uf.Usu_Rut = Usuarios.usu_rut AND uf.Usu_SprivId = us.Spriv_Id AND  Spriv_PrivId='" + Seccion + "' AND Spriv_Id='" + Subseccion + "' AND usu_codigo='" + Frm_Principal.InfoUsuario.Text + "' "

        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)
        If tabla.Rows.Count = 0 Then
            If Mensaje = True Then
                MsgBox("No puede realizar esta acción, Operacion Denegada", MsgBoxStyle.Critical, "Aviso")
            End If
            RealizarAccion = False
        End If
    End Function

    '------------------
    'MANEJO DE IMAGENES
    '------------------

    Function Base64ToImage(ByVal base64string As String) As System.Drawing.Image
        If base64string = "" Then
            Return My.Resources.blanco
        End If
        'Setup image and get data stream together
        Dim img As System.Drawing.Image
        Dim MS As System.IO.MemoryStream = New System.IO.MemoryStream
        Dim b64 As String = base64string.Replace(" ", "+")
        Dim b() As Byte

        'Converts the base64 encoded msg to image data
        b = Convert.FromBase64String(b64)
        MS = New System.IO.MemoryStream(b)

        'creates image
        img = System.Drawing.Image.FromStream(MS)

        Return img
    End Function


    Public Function ImageToByte(ByVal bmp As Image) As Byte()
        Dim converter As New ImageConverter()
        ' Return DirectCast(converter.ConvertTo(img, GetType(Byte())), Byte())

        'Dim imgStream As MemoryStream = New MemoryStream()

        'img.Save(imgStream, System.Drawing.Imaging.ImageFormat.Png)

        'imgStream.Close()
        'Dim byteArray As Byte() = imgStream.ToArray()
        'imgStream.Dispose()

        'Return byteArray

        Dim Bitmap = New Bitmap(bmp.Width, bmp.Height, bmp.PixelFormat)
        Dim g = Graphics.FromImage(Bitmap)
        g.DrawImage(bmp, New Point(0, 0))
        g.Dispose()
        bmp.Dispose()
        ' Bitmap.Save(_project.MapFilePath)
        bmp = Bitmap
        Return DirectCast(converter.ConvertTo(bmp, GetType(Byte())), Byte())
    End Function

    Public Function ByteToImage(ByVal blob As Byte()) As Bitmap
        Dim mStream As New MemoryStream()
        Dim pData As Byte() = blob
        mStream.Write(pData, 0, Convert.ToInt32(pData.Length))
        Dim bm As New Bitmap(mStream, False)
        mStream.Dispose()
        Return bm

    End Function

    Function Usuario_ODBC() As String
        Return "sa"
    End Function

    Function Pass_ODBC() As String
        Return "precisa"
    End Function

    Function CODIFICA(ByVal PASS As String) As String
        Dim LETRAS As String
        LETRAS = "JJABRE"
        Dim largo As Integer = Len(PASS)
        Dim LARGO2 As Integer = Len(LETRAS)
        CODIFICA = ""
        Dim y As Integer = 1
        For X As Integer = 1 To largo
            Dim P1 = Asc(Mid(PASS, X, 1))
            Dim P2 = Asc(Mid(LETRAS, y, 1))
            Dim fin = Chr(P1 + P2)

            CODIFICA = CODIFICA & fin
            y = y + 1
            If y = LARGO2 Then y = 1
        Next X
        'CODIFICA = "•«®«"
    End Function

    Function DECODIFICA(ByVal PASS As String) As String
        Dim LETRAS As String
        LETRAS = "JJABRE"
        Dim largo As Integer = Len(PASS)
        Dim LARGO2 As Integer = Len(LETRAS)
        DECODIFICA = ""
        Dim y As Integer = 1
        For X As Integer = 1 To largo
            Dim P1 = Asc(Mid(PASS, X, 1))
            Dim P2 = Asc(Mid(LETRAS, y, 1))
            DECODIFICA = DECODIFICA & Chr(P1 - P2)
            y = y + 1
            If y = LARGO2 Then y = 1
        Next X
    End Function

    Public Function MD5EncryptPass(ByVal StrPass As String)

        Dim md5 As MD5CryptoServiceProvider
        Dim bytValue() As Byte
        Dim bytHash() As Byte
        Dim strPassOutput As String
        Dim i As Integer
        strPassOutput = ""

        md5 = New MD5CryptoServiceProvider

        bytValue = System.Text.Encoding.UTF8.GetBytes(StrPass)

        bytHash = md5.ComputeHash(bytValue)
        md5.Clear()

        For i = 0 To bytHash.Length - 1
            strPassOutput &= bytHash(i).ToString("x").PadLeft(2, "0")
        Next

        Return strPassOutput
    End Function

    Public Function retorna_iva() As Double
        Return 19
    End Function
End Module

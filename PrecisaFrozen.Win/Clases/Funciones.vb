Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data
Imports System.IO
Imports System.IO.Ports
Imports ReaderB
Imports System.Text

Public Class Funciones

    Dim con As New Conexion

    '-------------------- ÇRUTE SERVIDOR SQL SERVER GESTION ---------------------->

    Public Function ListarTablasSQL(ByVal Consulta_sql As String) As DataTable

        If CONECTARVARI = "" Then

        Else
            Dim tabla As DataTable = New DataTable
            Try
                con.conectar()
                If validacone = "NC" Then
                    Return tabla
                    Exit Function
                End If
                Dim Listado As SqlDataAdapter = New SqlDataAdapter(Consulta_sql, con.con)

                Listado.SelectCommand.CommandTimeout = 0
                Listado.Fill(tabla)


                con.cerrar()
            Catch ex As Exception
                MsgBox(ex.Message())
            End Try
            'retornar tabla con datos
            Return tabla

        End If


    End Function


    Public Function ListarTablasSQLetiqueta(ByVal Consulta_sql As String) As DataTable

        If CONECTARVARI = "" Then

        Else
            Dim tabla As DataTable = New DataTable
            Try
                con.conectareti()
                If validacone = "NC" Then
                    Return tabla
                    Exit Function
                End If
                Dim Listado As SqlDataAdapter = New SqlDataAdapter(Consulta_sql, con.con)

                Listado.SelectCommand.CommandTimeout = 0
                Listado.Fill(tabla)


                con.cerrar()
            Catch ex As Exception
                MsgBox(ex.Message())
            End Try
            'retornar tabla con datos
            Return tabla

        End If


    End Function
    Public Function ListarTablasSQLbd2(ByVal Consulta_sql As String) As DataTable

        If CONECTARVARI = "" Then

        Else
            Dim tabla As DataTable = New DataTable
            Try
                con.conectar3()
                If validacone = "NC" Then
                    Return tabla
                    Exit Function
                End If
                Dim Listado As SqlDataAdapter = New SqlDataAdapter(Consulta_sql, con.con)

                Listado.SelectCommand.CommandTimeout = 0
                Listado.Fill(tabla)


                con.cerrar()
            Catch ex As Exception
                MsgBox(ex.Message())
            End Try
            'retornar tabla con datos
            Return tabla

        End If


    End Function
    Public Function ListarTablasSQLbD68(ByVal Consulta_sql As String) As DataTable

        If CONECTARVARI = "" Then

        Else
            Dim tabla As DataTable = New DataTable
            Try
                con.conectar68()
                If validacone = "NC" Then
                    Return tabla
                    Exit Function
                End If
                Dim Listado As SqlDataAdapter = New SqlDataAdapter(Consulta_sql, con.con)

                Listado.SelectCommand.CommandTimeout = 0
                Listado.Fill(tabla)


                con.cerrar()
            Catch ex As Exception
                MsgBox(ex.Message())
            End Try
            'retornar tabla con datos
            Return tabla

        End If
    End Function

    Public Function ListarTablasSQL8(ByVal Consulta_sql As String) As DataTable
        If CONECTARVARI = "" Then

        Else
            Dim tabla As DataTable = New DataTable
            Try
                con.conectar2()
                If validacone = "NC" Then
                    Return tabla
                    Exit Function
                End If
                Dim Listado As SqlDataAdapter = New SqlDataAdapter(Consulta_sql, con.con)

                Listado.SelectCommand.CommandTimeout = 0
                Listado.Fill(tabla)

                con.cerrar()
            Catch ex As Exception
                MsgBox(ex.Message())
            End Try
            'retornar tabla con datos
            Return tabla

        End If
    End Function

    Public Function MovimientoSQL(ByVal Consulta_sql)
        Dim retorno As Integer = 0

        Try
            con.conectar()
            'Console.WriteLine(Consulta_sql)
            Dim _cmd As SqlCommand = New SqlCommand(Consulta_sql, con.con)
            _cmd.ExecuteNonQuery()
            _cmd.CommandTimeout = 0
            retorno = 1
            con.cerrar()

        Catch ex As Exception
            retorno = 0
            'MsgBox(ex.Message())
        End Try

        ' retornar 
        '1 si se ejecuta correctamente
        '0 si no se ejecuta

        Return retorno
    End Function

    Public Function UltimoRegistro(ByVal Consulta_sql)
        Dim _tabla As DataTable = New DataTable
        Dim _ultimoRegistro = 0
        Try
            con.conectar()

            Dim _cmd As SqlDataAdapter = New SqlDataAdapter(Consulta_sql, con.con)
            _cmd.Fill(_tabla)

            If _tabla.Rows.Count = 0 Then
                _ultimoRegistro = 1
            Else
                _ultimoRegistro = Val(_tabla.Rows(_tabla.Rows.Count - 1)(0) + 1)
            End If
            con.cerrar()


        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
        'retornar ultimo registro de la tabla 
        Return _ultimoRegistro
    End Function

    Public Function verificaExistencia(ByVal Tabla As String,
                                       ByVal Campo As String, ByVal valor As String) As Boolean

        Dim _tabla As DataTable = New DataTable
        Dim _RegistroExiste As Boolean = False
        Try
            con.conectar()
            Dim _cmd As SqlDataAdapter = New SqlDataAdapter("SELECT * FROM " + Tabla + " WHERE " + Campo + "='" + valor + "'", con.con)
            _cmd.Fill(_tabla)

            If _tabla.Rows.Count = 0 Then
                _RegistroExiste = False
            Else
                _RegistroExiste = True
            End If

            con.cerrar()

        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
        'retornar ultimo registro de la tabla 
        Return _RegistroExiste

    End Function
    Public Function ImagenToBytes(ByVal Imagen As Image) As Byte()
        'si hay imagen
        Dim arreglo As Byte() = Nothing
        Try
            If Not Imagen Is Nothing Then
                'variable de datos binarios en stream(flujo)
                Dim Bin As New MemoryStream
                'convertir a bytes
                Imagen.Save(Bin, Imaging.ImageFormat.Jpeg)
                'retorna binario
                arreglo = Bin.GetBuffer
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox("No convirtio a bytes por: " + ex.ToString)
        End Try
        Return arreglo
    End Function
    Public Function bytesToString(ByVal arreglo As Byte()) As String
        Dim salida As String = ""
        Dim x As Integer = 0
        'MsgBox("Tamaño del arreglo: " + arreglo.Length.ToString)
        Try
            For x = 0 To arreglo.Length - 1
                salida += arreglo(x).ToString + ","
            Next
        Catch ex As Exception
            MsgBox("No lo convertio a String por: " + ex.ToString)
        End Try

        Return salida
    End Function
    Public Function ValorMaximo(ByVal Tabla As String, ByVal Campo As String, ByVal ValorSumar As Integer) As String

        Dim _tabla As DataTable = New DataTable
        Dim _valorMaximo As Integer = 0

        Try
            con.conectar()

            Dim _cmd As SqlDataAdapter = New SqlDataAdapter("SELECT Max(" + Campo + ") FROM " + Tabla, con.con)
            _cmd.Fill(_tabla)

            If _tabla.Rows.Count > 0 Then
                _valorMaximo = Convert.ToInt32(_tabla.Rows(0)(0))
            Else
                _valorMaximo = 0
            End If
            con.cerrar()


        Catch ex As Exception
            MsgBox(ex.Message())
        End Try

        Return (Convert.ToInt32(_valorMaximo) + Convert.ToInt32(ValorSumar))
    End Function

    Public Function ValorMaximoCondicional(ByVal Tabla As String, ByVal Campo As String, ByVal CondicionConWhere As String, ByVal ValorSumar As Integer) As String

        Dim _tabla As DataTable = New DataTable
        Dim _valorMaximo As Integer = 0

        Try
            con.conectar()

            Dim _cmd As SqlDataAdapter = New SqlDataAdapter("SELECT Max(" + Campo + ") FROM " + Tabla + " " + CondicionConWhere, con.con)
            _cmd.Fill(_tabla)

            If _tabla.Rows.Count > 0 Then
                _valorMaximo = Convert.ToInt32(_tabla.Rows(0)(0))
            Else
                _valorMaximo = 0
            End If
            con.cerrar()


        Catch ex As Exception
            MsgBox(ex.Message())
        End Try

        Return (Convert.ToInt32(_valorMaximo) + Convert.ToInt32(ValorSumar))
    End Function

    Public Function verificaExistenciaCondicional(ByVal Tabla As String,
                                  ByVal Condicion As String) As Boolean

        Dim _tabla As DataTable = New DataTable
        Dim _RegistroExiste As Boolean = False
        Try
            con.conectar()
            Dim sql As String = "SELECT * FROM " + Tabla + " WHERE " + Condicion + ""
            Dim _cmd As SqlDataAdapter = New SqlDataAdapter(sql, con.con)
            _cmd.Fill(_tabla)

            If _tabla.Rows.Count = 0 Then
                _RegistroExiste = False
            Else
                _RegistroExiste = True
            End If

            con.cerrar()


        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
        'retornar ultimo registro de la tabla 
        Return _RegistroExiste


    End Function

    Public Function DevuelveCorrelativo(ByVal codigo As String) As String
        DevuelveCorrelativo = ""
        Dim sql As String = "SELECT cor_correact FROM correlat WHERE cor_codi='" + codigo.ToString() + "'"
        Dim tabla As DataTable = ListarTablasSQL(sql)
        If tabla.Rows.Count > 0 Then
            DevuelveCorrelativo = tabla.Rows(0)(0).ToString()
        Else
            MsgBox("Error al rescatar correlativo")
        End If
        Return DevuelveCorrelativo
    End Function

    Public Function DevuelveFechaServidor() As DateTime

        Dim tabla As DataTable = New DataTable
        Try
            con.conectar()
            Dim Listado As SqlDataAdapter = New SqlDataAdapter("SELECT GETDATE()", con.con)
            Listado.Fill(tabla)
            con.cerrar()
        Catch ex As Exception

        End Try
        Return Convert.ToDateTime(tabla.Rows(0)(0).ToString())

    End Function

    Public Function DevuelveUsuario(ByVal codigo As String) As String

        Dim tabla As DataTable = New DataTable
        Try
            con.conectar()
            Dim Listado As SqlDataAdapter = New SqlDataAdapter("SELECT usu_nombre+' '+ usu_ap FROM usuarios WHERE usu_codigo = '" + codigo + "'", con.con)
            Listado.Fill(tabla)
            con.cerrar()
        Catch ex As Exception

        End Try
        If tabla.Rows.Count > 0 Then

            Return Convert.ToString(tabla.Rows(0)(0).ToString())
        End If


    End Function

    Public Function GridAExcel(ByVal ElGrid As DataGridView) As Boolean

        Dim exApp As New Microsoft.Office.Interop.Excel.Application
        Dim exLibro As Microsoft.Office.Interop.Excel.Workbook
        Dim exHoja As Microsoft.Office.Interop.Excel.Worksheet

        Try

            exLibro = exApp.Workbooks.Add
            exHoja = exLibro.Worksheets.Add()

            Dim NCol As Integer = ElGrid.ColumnCount
            Dim NRow As Integer = ElGrid.RowCount

            For i As Integer = 1 To NCol
                exHoja.Cells.Item(1, i) = ElGrid.Columns(i - 1).Name.ToString.Trim.Replace("_Str", "").Replace("_Frm", "").Replace("_", " ")
            Next

            For Fila As Integer = 0 To NRow - 1
                For Col As Integer = 0 To NCol - 1
                    exHoja.Cells.Item(Fila + 2, Col + 1) = ElGrid.Rows(Fila).Cells(Col).Value
                Next
            Next

            exHoja.Rows.Item(1).Font.Bold = 1
            exHoja.Rows.Item(1).HorizontalAlignment = 3
            exHoja.Columns.AutoFit()

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

    Public Function dtToExcel(ByVal dt As DataTable) As Boolean
        Dim Resp As Boolean = False

        Try
            Dim exApp As New Microsoft.Office.Interop.Excel.Application
            Dim exLibro As Microsoft.Office.Interop.Excel.Workbook
            Dim exHoja As Microsoft.Office.Interop.Excel.Worksheet

            exLibro = exApp.Workbooks.Add
            exHoja = exLibro.Worksheets.Add()

            Dim NCol As Integer = dt.Columns.Count
            Dim NRow As Integer = dt.Rows.Count

            For i As Integer = 1 To NCol
                exHoja.Cells.Item(1, i) = dt.Columns(i - 1).ColumnName.Trim.Replace("_Str", "").Replace("_", " ")
            Next

            For Fila As Integer = 0 To NRow - 1
                For Col As Integer = 0 To NCol - 1
                    If (dt.Columns(Col).ColumnName.Contains("_Str")) Then
                        exHoja.Cells.Item(Fila + 2, Col + 1).NumberFormat = "@"
                    End If
                    exHoja.Cells.Item(Fila + 2, Col + 1) = dt.Rows(Fila).Item(Col).ToString.Trim
                Next
            Next

            exHoja.Rows.Item(1).Font.Bold = 1
            exHoja.Rows.Item(1).HorizontalAlignment = 3
            exHoja.Columns.AutoFit()

            exApp.Application.Visible = True
            exHoja = Nothing
            exLibro = Nothing
            exApp = Nothing
        Catch ex As Exception
            MsgBox("Error al exportar a Excel", MsgBoxStyle.Critical, "¡Error!")
            Resp = False
        End Try

        Return Resp
    End Function

    Function validPortRFID2() As Boolean
        Dim Resp As Boolean = False

        Try
            Dim NomPue As String = Frm_Principal.PuertoRFID

            If (NomPue = "") Then
                Dim f As New Frm_Usuarios_Registrar_TAG
                f.ShowDialog(Frm_Principal)
                NomPue = Frm_Principal.PuertoRFID
            End If

            If (NomPue = "") Then
                MessageBox.Show("Puerto COM no configurado. Vuelva a intentar", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return Resp
            End If

            Resp = True
        Catch ex As Exception
            MessageBox.Show("Ocurrio un error al validar el puerto del dispositivo RFID. Vuelva a intentar.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return Resp
    End Function

    Function validPortRFID() As Boolean
        Dim Resp As Boolean = False

        Try
            Dim NomPue As String = Frm_Principal.PuertoRFID
            If (NomPue = "") Then
                If (validPortRFID2() = False) Then
                    Return Resp
                End If
            End If

            NomPue = Frm_Principal.PuertoRFID

            Dim ExiPue As Boolean = False

            Dim SerialPort As New SerialPort()
            Dim PuertosDisp = SerialPort.GetPortNames

            For i = 0 To PuertosDisp.Length - 1
                If (NomPue = PuertosDisp(i).ToString) Then
                    ExiPue = True
                End If
            Next

            If (Not ExiPue) Then
                'MessageBox.Show("El Puerto " & NomPue & " no esta disponible. Compruebe la conexión del dispositivo RFID", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Dim RespMsg = MessageBox.Show("¿El dispositivo RFID esta conectado?", "Pregunta!", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If (RespMsg = Windows.Forms.DialogResult.No) Then
                    MessageBox.Show("Conecte el dispositivo RFID y vuelva a intentar.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return Resp
                Else
                    Frm_Principal.PuertoRFID = ""
                    If (validPortRFID2() = False) Then
                        Return Resp
                    End If
                End If
            End If

            NomPue = Frm_Principal.PuertoRFID

            Dim NumPue As Integer = CInt(NomPue.Replace("COM", ""))
            Dim ComAddr As Byte = Convert.ToByte(255)
            Dim Baud As Byte = Convert.ToByte(5)
            Dim PortHand As Integer = 0

            Dim OpenRes As Integer = -1
            OpenRes = StaticClassReaderB.OpenComPort(NumPue, ComAddr, Baud, PortHand)
            If (OpenRes <> 0) Then
                MessageBox.Show("El Puerto " & NomPue & " no corresponde a dispositivo RFID. Debe configurar puerto nuevamente.", "Información!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Frm_Principal.PuertoRFID = ""
                If (validPortRFID2() = False) Then
                    Return Resp
                End If
            Else
                StaticClassReaderB.CloseComPort()
                Resp = True
            End If
        Catch ex As Exception
            MessageBox.Show("Ocurrio un error al validar el puerto del dispositivo RFID.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return Resp
    End Function

    Sub writeTag(ByVal EPCText As String)
        Try
            If (validPortRFID()) Then
                Dim NomPue As String = Frm_Principal.PuertoRFID
                Dim NumPue As Integer = CInt(NomPue.Replace("COM", ""))

                Dim ComAddr As Byte = Convert.ToByte(255)
                Dim Baud As Byte = Convert.ToByte(5)
                Dim PortHand As Integer = 0

                Dim OpenRes As Integer = -1
                OpenRes = StaticClassReaderB.OpenComPort(NumPue, ComAddr, Baud, PortHand)
                If (OpenRes <> 0) Then
                    MessageBox.Show("Ocurrio un error al conectar con el dispositivo RFID.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    Dim PWD As Integer = StaticClassReaderB.SetPowerDbm(ComAddr, Convert.ToByte(0), PortHand)

                    Dim EPClean As Byte
                    Dim enume As Byte

                    EPClean = Convert.ToByte(EPCText.Length / 2)
                    enume = Convert.ToByte(EPCText.Length / 4)
                    Dim EPC(enume) As Byte
                    EPC = hexToStrArr(EPCText)
                    Dim Pass As Byte() = hexToStrArr("00000000")
                    Dim Err As Integer = 0
                    Dim fCmdRet As Integer = 0

                    Dim Alarm As Integer = StaticClassReaderB.BuzzerAndLEDControl(ComAddr, Convert.ToByte(1), Convert.ToByte(1), Convert.ToByte(2), PortHand)

                    Dim lectura As Integer = -1

                    While (lectura <> 0)
                        lectura = StaticClassReaderB.WriteEPC_G2(ComAddr, Pass, EPC, EPClean, Err, PortHand)
                    End While

                    If (lectura = 0) Then
                        MessageBox.Show("TAG registrado con exito.", "Registro Exitoso!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Ocurrio un error al intentar registrar el TAG. Intente nuevamente.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If

                    StaticClassReaderB.CloseComPort()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Ocurrio un error al intentar registrar el TAG. Intente nuevamente.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Function hexToStrArr(ByVal s As String) As Byte()
        s = s.Replace(" ", "")

        Dim buffer(s.Length / 2) As Byte

        For i = 0 To s.Length - 1 Step 2
            buffer(i / 2) = Convert.ToByte(s.Substring(i, 2), 16)
        Next

        Return buffer
    End Function

    Function readTag() As String
        Dim Resp As String = ""

        Try
            If (validPortRFID()) Then
                Dim NomPue As String = Frm_Principal.PuertoRFID
                Dim NumPue As Integer = CInt(NomPue.Replace("COM", ""))

                Dim ComAddr As Byte = Convert.ToByte(255)
                Dim Baud As Byte = Convert.ToByte(5)
                Dim PortHand As Integer = 0

                Dim OpenRes As Integer = -1
                OpenRes = StaticClassReaderB.OpenComPort(NumPue, ComAddr, Baud, PortHand)
                If (OpenRes <> 0) Then
                    MessageBox.Show("Ocurrio un error al conectar con el dispositivo.", "Error de conexión!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    Dim PWD As Integer = StaticClassReaderB.SetPowerDbm(ComAddr, Convert.ToByte(0), PortHand)

                    Dim AdrTID As Byte = Convert.ToByte(2)
                    Dim LenTID As Byte = Convert.ToByte(4)
                    Dim TIDFlag As Byte = Convert.ToByte(0)
                    Dim EPC(5000) As Byte
                    Dim Totallen As Integer = 0
                    Dim CardNum As Integer = 0

                    Dim Alarm As Integer = StaticClassReaderB.BuzzerAndLEDControl(ComAddr, Convert.ToByte(1), Convert.ToByte(1), Convert.ToByte(2), PortHand)

                    Dim lectura As Integer = -1

                    While (lectura <> 1)
                        lectura = StaticClassReaderB.Inventory_G2(ComAddr, AdrTID, LenTID, TIDFlag, EPC, Totallen, CardNum, PortHand)

                        If (lectura = 1) Then
                            Dim daw(Totallen) As Byte
                            Array.Copy(EPC, daw, Totallen)

                            Dim sb As New StringBuilder(daw.Length * 3)
                            For Each b As Byte In daw
                                sb.Append(Convert.ToString(b, 16).PadLeft(2, "0"))
                            Next

                            Dim temps As String = sb.ToString.ToUpper

                            Dim m As Integer = 0

                            Dim sEPC As String = ""

                            For i = 0 To CardNum - 1
                                Dim EPClen As Integer = daw(m)
                                sEPC = temps.Substring(m * 2 + 2, EPClen * 2)
                                m += EPClen + 1
                                If (sEPC.Length <> EPClen * 2) Then
                                    Exit For
                                End If
                            Next

                            Resp = sEPC
                        End If
                    End While

                    StaticClassReaderB.CloseComPort()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Ocurrio un error al intentar leer el TAG. Intente nuevamente.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return Resp
    End Function
End Class

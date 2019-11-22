Imports System
Imports System.IO
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.ComponentModel
Imports System.Runtime.InteropServices

Public Class ImpresionCOM1
    Dim fnc As New Funciones

    Public Const GENERIC_WRITE = &H40000000
    Public Const OPEN_EXISTING = 3
    Public Const FILE_SHARE_WRITE = &H2

    Dim LPTPORT As String
    Dim PuertoImpresion As String = "COM1"

    'Friend WithEvents btnImpresion As System.Windows.Forms.Button
    'Friend WithEvents btnSalir As System.Windows.Forms.Button
    Dim hPort As Integer

    Public Declare Function CreateFile Lib "kernel32" Alias "CreateFileA" ( _
    ByVal lpFileName As String, ByVal dwDesiredAccess As Integer, _
    ByVal dwShareMode As Integer, _
    ByRef lpSecurityAttributes As SECURITY_ATTRIBUTES, _
    ByVal dwCreationDisposition As Integer, _
    ByVal dwFlagsAndAttributes As Integer, _
    ByVal hTemplateFile As Integer) As Integer

    Public Declare Function CloseHandle Lib "kernel32" Alias "CloseHandle" _
                            (ByVal hObject As Integer) As Integer
    Dim retval As Integer


    Public Structure SECURITY_ATTRIBUTES
        Private nLength As Integer
        Private lpSecurityDescriptor As Integer
        Private bInheritHandle As Integer
    End Structure


    Public Sub Impresion(ByVal Cliente As String, ByVal Producto As String, _
                         ByVal FolioCliente As String, ByVal Unidades As String, _
                         ByVal Kilos As String, ByVal Fproduc As String, ByVal Fvenc As String, ByVal codigo_corto As String, ByVal Codigo As String, ByVal fecha As Date, ByVal copia As String)

        Dim sql As String = "SELECT racd_unidades FROM rackdeta WHERE racd_codi='" + codigo_corto + "'"

        Dim dt As DataTable = fnc.ListarTablasSQL(sql)
        Dim stock As String = "0"

        If dt.Rows.Count > 0 Then
            stock = dt.Rows(0)(0).ToString()
        ElseIf Convert.ToDateTime(fnc.DevuelveFechaServidor()).ToShortDateString() = Convert.ToDateTime(fecha).ToShortDateString() Then
            stock = Unidades
        End If

        'Modificacion letra tipo almacenamiento HAmestica 14/08/18
        Dim LetraAlm = ""

        Dim CodRece = codigo_corto.Substring(0, codigo_corto.Length - 2)

        Dim sqlAlm = "select left(frec_tipoalmacenamiento,1) from fichrece where frec_codi='" & CodRece & "'"
        Dim dtAlm As DataTable = fnc.ListarTablasSQL(sqlAlm)

        If (dtAlm.Rows.Count > 0) Then
            LetraAlm = dtAlm.Rows(0).Item(0).ToString.Trim
        End If
        'Fin modificacion letra tipo almacenamiento HAmestica 14/08/18

        Try
            Dim SA As SECURITY_ATTRIBUTES
            'outFile es el archivo stream que contien la etiqueta y su formato
            Dim outFile As FileStream, hPortP As IntPtr
            LPTPORT = PuertoImpresion

            hPort = CreateFile(LPTPORT, GENERIC_WRITE, FILE_SHARE_WRITE, _
                               SA, OPEN_EXISTING, 0, 0)

            'Convertir Integer a IntPtr 
            hPortP = New IntPtr(hPort)

            'Crear FileStream usando Handle 

            outFile = New FileStream(hPortP, FileAccess.Write, False)


            Dim fileWriter As New StreamWriter(outFile)

            '--------------------------INICIO ETIQUETA---------------------------' 
            fileWriter.Write("^XA")
            'Deshabilita el panel de la impresora, para que el usr no pueda acceder
            fileWriter.Write("^MP10.1")

            'Posicion del eje de cordenadas, en dots
            fileWriter.Write("^LH0,0")
            ' fileWriter.Write("^FO15,30^GB750,750,4^FS") 'CUADRADO BORDE

            fileWriter.Write("^FO50,60")
            fileWriter.Write("^A0,80,60^FD        PRECISA FROZEN    " & LetraAlm & "^FS")

            fileWriter.Write("^FO50,150")
            fileWriter.Write("^A0,40,25^FDCLIENTE            :  " & Cliente & "^FS")

            fileWriter.Write("^FO50,195")
            fileWriter.Write("^A0,40,25^FDPRODUCTO        : " + Producto + "^FS")

            fileWriter.Write("^FO50,240")
            fileWriter.Write("^A0,40,25^FDFOLIO CLIENTE  : " & FolioCliente & "       UND: " & stock & " / " & Unidades & "  KG: " & Kilos & "^FS")

            fileWriter.Write("^FO50,285")
            fileWriter.Write("^A0,40,25^FDF. PRODUCCION : " & devuelve_fecha_Formato2(Fproduc) & " F. VENCIMIENTO: " & Fvenc & "^FS")

            fileWriter.Write("^FO50,340")
            fileWriter.Write("^A0,50,50^FDPALLET:^FS")

            fileWriter.Write("^FO50,395")
            fileWriter.Write("^A0,200,160^FD" & codigo_corto & "^FS")
            fileWriter.Write("^A0,80,25^ " + copia + "^FS")
            'ean13 12 caracteres
            'Print #1, "^FO70,450" ' POSICION
            'Print #1, "^BY5" 'ANCHO DECODIGODE BARRA EAN 13
            'Print #1, "^BEN,250,Y,N"
            'Print #1, "^FD999999" & TXTCA.Text & TXTBA.Text & TXTCO.Text & "^FS"

            'EAN128 20 CARACTERES
            fileWriter.Write("^FO80,600")
            fileWriter.Write("^BY4^BC,100,Y,N,,U")
            fileWriter.Write("^FD" & Codigo & "^FS")
            fileWriter.Write("^XZ")
            fileWriter.Flush()
            fileWriter.Close()
            outFile.Close()

            retval = CloseHandle(hPort)
        Catch ex As Exception
            MsgBox("Error al intentar imprimir la recepción", MsgBoxStyle.Information, "Aviso")
        End Try

    End Sub

    Public Sub ImpresionCaja(ByVal Cliente As String, ByVal Pallet As String, ByRef foliocaja As String, ByVal foliopequenio As String)

        Try
            Dim SA As SECURITY_ATTRIBUTES
            'outFile es el archivo stream que contien la etiqueta y su formato
            Dim outFile As FileStream, hPortP As IntPtr
            LPTPORT = PuertoImpresion

            hPort = CreateFile(LPTPORT, GENERIC_WRITE, FILE_SHARE_WRITE, _
                               SA, OPEN_EXISTING, 0, 0)

            'Convertir Integer a IntPtr 
            hPortP = New IntPtr(hPort)

            'Crear FileStream usando Handle 

            outFile = New FileStream(hPortP, FileAccess.Write, False)


            Dim fileWriter As New StreamWriter(outFile)

            '--------------------------INICIO ETIQUETA---------------------------' 
            fileWriter.Write("^XA")
            'Deshabilita el panel de la impresora, para que el usr no pueda acceder
            fileWriter.Write("^MP10.1")

            'Posicion del eje de cordenadas, en dots
            fileWriter.Write("^LH0,0")
            fileWriter.Write("^FO15,30^GB750,750,4^FS") 'CUADRADO BORDE

            fileWriter.Write("^FO50,60")
            fileWriter.Write("^A0,80,60^FD      ETIQUETA CAJA ^FS")

            fileWriter.Write("^FO50,190")
            fileWriter.Write("^A0,40,25^FDCLIENTE            :  " & Cliente & "^FS")

            fileWriter.Write("^FO50,240")
            fileWriter.Write("^A0,40,25^FDPALLET             :  " & Pallet & "^FS")

            fileWriter.Write("^FO50,380")
            fileWriter.Write("^A0,200,160^FD" & foliopequenio & "^FS")

            'EAN128 20 CARACTERES
            fileWriter.Write("^FO80,570")
            fileWriter.Write("^BY4^BC,100,Y,N,,U")
            Console.WriteLine(foliocaja.Remove(foliocaja.Length - 1, 1))
            fileWriter.Write("^FD" & foliocaja.Remove(foliocaja.Length - 1, 1) & "^FS")
            fileWriter.Write("^XZ")
            fileWriter.Flush()
            fileWriter.Close()
            outFile.Close()

            retval = CloseHandle(hPort)
        Catch ex As Exception
            MsgBox("Error al intentar imprimir la etiqueta N° " + foliocaja, MsgBoxStyle.Information, "Aviso")
        End Try
    End Sub
End Class

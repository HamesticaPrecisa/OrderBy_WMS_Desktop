Imports System.Resources
Imports System.Drawing.Printing
Imports CrystalDecisions.Shared
Imports System.Runtime.InteropServices
Imports System.Deployment
Imports System.Windows.Forms
Imports System.IO
Imports System.Configuration
Imports System.Drawing.Imaging
Imports System.Data.SqlClient
Imports System.Text
Public Class PrimeraCarga
    Dim SCR As String = ""

    Sub creatxt()

        Dim obj As New Object
        Dim archivo As New Object
        Dim ruta As String = "C:\OrderByTMPcli.txt" 'Ej: Documentos\archivo1.txt

        obj = CreateObject("Scripting.FileSystemObject")
        archivo = obj.CreateTextFile(ruta, True)
        'Luego agregas las lineas que quieras al archivo
        archivo.WriteLine(txtdatab.Text)
        archivo.close()


    End Sub
    Sub creaBAT()

        Dim obj As New Object
        Dim archivo As New Object
        Dim ruta As String = "a.bat" 'Ej: Documentos\archivo1.txt

        obj = CreateObject("Scripting.FileSystemObject")
        archivo = obj.CreateTextFile(ruta, True)
        'Luego agregas las lineas que quieras al archivo
        archivo.WriteLine("sqlcmd -i \SQL.sql -S 192.168.1.68 -d BD" + txtdatab.Text.Trim() + " -U sa -P precisa")
        archivo.close()


    End Sub

    Sub leerarchivo()

        Dim objReader As New StreamReader("C:\OrderByTMPcli.txt")
        Dim sLine As String = ""
        Dim arrText As New ArrayList()

        Do
            sLine = objReader.ReadLine()
            If Not sLine Is Nothing Then
                arrText.Add(sLine)
            End If
        Loop Until sLine Is Nothing
        objReader.Close()

        For Each sLine In arrText
            Console.WriteLine(sLine)
        Next

        If sLine = "" Then

        Else

            rutclienteglo = sLine

            Dim sqlbd As String = "select estado from t_contacto where rutempresa='" + rutclienteglo + "' "

            Dim tabla As DataTable = fnc.ListarTablasSQLbd2(sqlbd)

            If tabla.Rows.Count > 0 Then
                If tabla.Rows(0)(0).ToString().Trim() = "0" Then


                    ConfSuperADM.ShowDialog()

                    Me.Close()
                ElseIf tabla.Rows(0)(0).ToString().Trim() = "1" Then

                    Frm_Principal.ShowDialog()
                    CONECTARVARI = "LOCAL"
                    ip = "192.168.1.68"
                    bdglobal = "BD" + rutclienteglo.Trim

                End If
            End If
        End If

    End Sub
    Sub leerarchivo2()

        Dim objReader As New StreamReader("tablas.txt")
        Dim sLine As String = ""
        Dim arrText As New ArrayList()

        Do
            sLine = objReader.ReadLine()
            If Not sLine Is Nothing Then
                arrText.Add(sLine)

                SCR = SCR + vbLf + sLine
            End If
        Loop Until sLine Is Nothing
        objReader.Close()

        For Each sLine In arrText
            Console.WriteLine(sLine)
        Next

        If sLine = "" Then

        Else

            ' SCR = arrText.ToString()

        
        End If

    End Sub
    Sub LEERTXT()
        Dim currentRow As String()

        Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser("C:\OrderByTMPcli.txt")
            MyReader.TextFieldType = FileIO.FieldType.Delimited
            MyReader.SetDelimiters(";")        'Separador del archivo de texto, en este caso punto y coma
            While Not MyReader.EndOfData ' Mientras no sea el final del archivo
                currentRow = MyReader.ReadFields()  'esto llenara el string() con las posiciones que contenga el .txt
                rutclienteglo = currentRow.ToString()
                txtdatab.Text = rutclienteglo

                'ej txt:   Lucas;Nahuel;18;Chile
                'currentRow(0) = Lucas
                'currentRow(1) = Nahuel
                'CurrentRow(2) = 18
                'CurrentRow(3) = Chile   
            End While
        End Using


    End Sub


    Sub BUSCARTXT()

   If My.Computer.FileSystem.FileExists("C:\OrderByTMPcli.txt") Then
            leerarchivo()
        Else
            txtdatab.Focus()

            ''  MsgBox("")
        End If
    End Sub
    '  Implements IForm
    Public buscavalor = ""
    Dim minimizar_barra = True
    Dim fnc As New Funciones
    Private Sub Label1_Click(sender As System.Object, e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
      
        'Dim createdatabase As String = "USE [master] CREATE DATABASE BD" + txtdatab.Text.Trim() + ""
        'fnc.MovimientoSQL(createdatabase)
        'CREABASE()
        CONECTARVARI = "LOCAL"
        ip = "192.168.1.68"
        Dim sqlbd As String = "select * from t_contacto where rutempresa='" + txtdatab.Text.Trim() + "' and  claveactivacion ='" + txtpass.Text.Trim() + "'"

        Dim tabla As DataTable = fnc.ListarTablasSQLbd2(sqlbd)

        If tabla.Rows.Count > 0 Then
            creatxt()
            CREABASE()
        Else


            MsgBox("Usuario ingresado no existe, o no se encuentra registrado en http://www.precisatech.cl ", MsgBoxStyle.Critical, "Aviso")

        End If


    End Sub
    Private Sub CREABASE()
        ip = "192.168.1.68"
        Dim createdatabase As String = " USE [master] CREATE DATABASE BD" + txtdatab.Text.Trim() + " "


        fnc.ListarTablasSQLbD68(createdatabase)

        creaBAT()
        Shell("c:a.bat", AppWinStyle.MaximizedFocus, True)

    End Sub
    Private info As ProcessStartInfo = New ProcessStartInfo("SCRIPT1.SQL")
    Private Sub PrimeraCarga_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'leerarchivo2()
        '  txtdatab.Text = "190408517"
        ' validacone = ""

        ' CONECTARVARI = "LOCAL"
        'leerarchivo2()
        'CREABASE()
        'txtdatab.Text = "220700"
        '  ip = "192.168.1.90"

        BUSCARTXT()
        'CREABASE()
    End Sub
End Class
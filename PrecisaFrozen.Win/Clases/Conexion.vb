Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Diagnostics

Public Class Conexion

    Public con As New SqlConnection
    Public con2 As New SqlConnection




    ' VES Sep 2019
    ' Abre una conexion con la BD
    '
    Private Sub openConn(ByVal tipo As String, ByVal catalog As String)
        Dim newConnStr As String = ""
        Select Case (tipo)
            Case "LOCAL"
                newConnStr = CONFIG.lanConnStr

            Case "WLAN"
                newConnStr = CONFIG.wlanConnStr

        End Select

        If (newConnStr <> String.Empty) Then
            newConnStr = newConnStr + ";Initial catalog=" + catalog + ";"
            Try
                If newConnStr <> con.ConnectionString Then
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    con.ConnectionString = newConnStr
                End If

                Debug.WriteLine("[openConn] Connecting to " + con.ConnectionString)
                con.Open()
                Debug.WriteLine("[openConn] Connected")

            Catch ex As SqlException
                validacone = "NC"
                Debug.WriteLine("[openConn] " + ex.Message)
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Conexion")
                MsgBox(con.ConnectionString, MsgBoxStyle.Critical, "Tipo: " & tipo)
            End Try

        Else
            validacone = "NC"
        End If
    End Sub


    Sub conectar()
        If CONECTARVARI = "" Then
        Else
            ' VES Sep 2017:  Cambiamos todos los connstring hardcoded por el valor de la propiedad connString y se centralizo el codigo de conexion en
            ' el metodo privado openConn
            'con.ConnectionString = ("Data Source=192.168.1.7\PRECISA; initial catalog=precisa2; Trusted_Connection=True; Connection Timeout=100;")
            Me.openConn(CONECTARVARI, CONFIG.mainCatalog)
        End If



    End Sub
    Sub conectareti()
        If CONECTARVARI = "" Then
        Else
            Try
                Try
                    If con.State = 0 Then
                        ' VES: Sep 2019
                        Me.openConn(CONECTARVARI, CONFIG.etiqCatalog)

                    End If
                Catch ex As SqlException
                    validacone = "NC"
                End Try
            Catch ex2 As Exception

            End Try
        End If



    End Sub
    Sub conectar2()
        If CONECTARVARI = "" Then
        Else
            Try
                Try
                    If con.State = 0 Then
                        ' VES Sep 2019
                        openConn(CONECTARVARI, CONFIG.mainCatalog)


                    End If
                Catch ex As SqlException
                    validacone = "NC"
                End Try
            Catch ex2 As Exception

            End Try
        End If



    End Sub
    Sub conectar3()
        If CONECTARVARI = "" Then
        Else
            Try
                Try
                    If con.State = 0 Then
                        ' VES Sep 2019
                        openConn(CONECTARVARI, "ORDERBY")  ' Por que ORDERBY ???

 
                    End If
                Catch ex As SqlException
                    validacone = "NC"
                End Try
            Catch ex2 As Exception

            End Try
        End If



    End Sub
    Sub conectar68()
        If CONECTARVARI = "" Then
        Else
            Try
                Try
                    If con.State = 0 Then
                        ' VES Sep 2019
                        ' Originalmente esta conexion no usaba la instancia PRECISABD.  Preguntar a Hernan.
                        openConn(CONECTARVARI, CONFIG.mainCatalog)

                    End If
                Catch ex As SqlException
                    validacone = "NC"
                End Try
            Catch ex2 As Exception

            End Try
        End If



    End Sub
    Sub cerrar()
        con.Close()
    End Sub

End Class

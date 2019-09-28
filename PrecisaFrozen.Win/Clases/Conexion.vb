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
        con.ConnectionString = String.Empty
        Select Case (tipo)
            Case "LOCAL"
                con.ConnectionString = CONFIG.lanConnStr

            Case "WLAN"
                con.ConnectionString = CONFIG.wlanConnStr

        End Select

        If (con.ConnectionString <> String.Empty) Then
            con.ConnectionString = con.ConnectionString + ";Initial catalog=" + catalog + ";"
            Try
                Debug.WriteLine("[openConn] Connecting to " + con.ConnectionString)
                con.Open()
                Debug.WriteLine("[openConn] Connected")

            Catch ex As SqlException
                validacone = "NC"
                Debug.WriteLine("[openConn] " + ex.Message)
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

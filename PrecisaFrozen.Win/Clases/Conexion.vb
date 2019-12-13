Imports System.Data.SqlClient

Public Class Conexion

    Public con As New SqlConnection
    Public con2 As New SqlConnection
 


    Sub conectar()
        If CONECTARVARI = "" Then
        Else
            Try
                Try
                    If con.State = 0 Then

                        con.ConnectionString = ("Data Source=192.168.1.7\PRECISA; initial catalog=precisa2; Trusted_Connection=True; Connection Timeout=100;")
                        CONECTARVARI = "LOCAL"

                        If CONECTARVARI = "LOCAL" Then
                            con.ConnectionString = ("Data Source=" + ip.Trim() + "\PRECISABD; initial catalog=PRECISA;  USER=sa; PWD=precisa; Connection Timeout=150; ")

                            con.Open()
                        ElseIf CONECTARVARI = "WLAN" Then

                            con.ConnectionString = ("Data Source=" + ip.Trim() + "\PRECISABD; initial catalog=PRECISA;  USER=sa; PWD=precisa; Connection Timeout=150; ")



                            con.Open()
                        End If

                        'If CONECTARVARI = "LOCAL" Then
                        '    con.ConnectionString = ("Data Source=" + ip.Trim() + "\PRECISABD; initial catalog=Precisa_Backup;  USER=sa; PWD=precisa; Connection Timeout=150; ")

                        '    con.Open()
                        'ElseIf CONECTARVARI = "WLAN" Then

                        '    con.ConnectionString = ("Data Source=" + ip.Trim() + "\PRECISABD; initial catalog=Precisa_Backup;  USER=sa; PWD=precisa; Connection Timeout=150; ")



                        '    con.Open()
                        'End If

                    End If
                Catch ex As SqlException
                    validacone = "NC"
                End Try
            Catch ex2 As Exception

            End Try
        End If
 
        
     
    End Sub
    Sub conectareti()
        If CONECTARVARI = "" Then
        Else
            Try
                Try
                    If con.State = 0 Then

                        'con.ConnectionString = ("Data Source=192.168.1.7\PRECISA; initial catalog=precisa2; Trusted_Connection=True; Connection Timeout=100;")
                        ' CONECTARVARI = "LOCAL"
                        If CONECTARVARI = "LOCAL" Then
                            con.ConnectionString = ("Data Source=" + ip.Trim() + "\PRECISABD; initial catalog=Etiquetado;  USER=sa; PWD=precisa; Connection Timeout=150; ")

                            con.Open()
                        ElseIf CONECTARVARI = "WLAN" Then

                            con.ConnectionString = ("Data Source=" + ip.Trim() + "\PRECISABD; initial catalog=Etiquetado;  USER=sa; PWD=precisa; Connection Timeout=150; ")



                            con.Open()
                        End If

                        'con.ConnectionString = ("Data Source=186.67.106.109\PRECISABD; initial catalog=PRECISA;  USER=sa; PWD=precisa; Connection Timeout=0;")


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

                        'con.ConnectionString = ("Data Source=192.168.1.7\PRECISA; initial catalog=precisa2; Trusted_Connection=True; Connection Timeout=100;")
                        ' CONECTARVARI = "LOCAL"
                        If CONECTARVARI = "LOCAL" Then
                            con.ConnectionString = ("Data Source=" + ip.Trim() + "\PRECISABD; initial catalog=PRECISA;  USER=sa; PWD=precisa; Connection Timeout=3; ")

                            con.Open()
                        ElseIf CONECTARVARI = "WLAN" Then

                            con.ConnectionString = ("Data Source=" + ip.Trim() + "\PRECISABD; initial catalog=PRECISA;  USER=sa; PWD=precisa; Connection Timeout=0; ")



                            con.Open()
                        End If

                        'con.ConnectionString = ("Data Source=186.67.106.109\PRECISABD; initial catalog=PRECISA;  USER=sa; PWD=precisa; Connection Timeout=0;")


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

                        'con.ConnectionString = ("Data Source=192.168.1.7\PRECISA; initial catalog=precisa2; Trusted_Connection=True; Connection Timeout=100;")
                        ' CONECTARVARI = "LOCAL"
                        If CONECTARVARI = "LOCAL" Then
                            con.ConnectionString = ("Data Source=" + ip.Trim() + "\PRECISABD; initial catalog=ORDERBY;  USER=sa; PWD=precisa; Connection Timeout=3; ")

                            con.Open()
                        ElseIf CONECTARVARI = "WLAN" Then

                            con.ConnectionString = ("Data Source=" + ip.Trim() + "\PRECISABD; initial catalog=ORDERBY;  USER=sa; PWD=precisa; Connection Timeout=3; ")



                            con.Open()
                        End If

                        'con.ConnectionString = ("Data Source=186.67.106.109\PRECISABD; initial catalog=PRECISA;  USER=sa; PWD=precisa; Connection Timeout=0;")


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

                        'con.ConnectionString = ("Data Source=192.168.1.7\PRECISA; initial catalog=precisa2; Trusted_Connection=True; Connection Timeout=100;")
                        ' CONECTARVARI = "LOCAL"
                        If CONECTARVARI = "LOCAL" Then
                            con.ConnectionString = ("Data Source=" + ip.Trim() + "; initial catalog=PRECISA;  USER=sa; PWD=precisa; Connection Timeout=3; ")

                            con.Open()
                        ElseIf CONECTARVARI = "WLAN" Then

                            con.ConnectionString = ("Data Source=" + ip.Trim() + "; initial catalog=PRECISA;  USER=sa; PWD=precisa; Connection Timeout=3; ")



                            con.Open()
                        End If

                        'con.ConnectionString = ("Data Source=186.67.106.109\PRECISABD; initial catalog=PRECISA;  USER=sa; PWD=precisa; Connection Timeout=0;")


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

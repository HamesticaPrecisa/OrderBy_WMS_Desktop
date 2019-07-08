Imports System.IO
Imports System.Configuration
Imports System.Drawing.Imaging
Imports System.Data.SqlClient

Public Class frmConvertirFotos

    Dim fnc As New Funciones

    Sub TraeImagenes()
        Dim sql As String = "SELECT rimg_imagen,rimg_rececodi,rimg_num FROM receimagen WHERE rimg_imagen2 IS NULL"
        Dim tablaimagen As DataTable = fnc.ListarTablasSQL(sql)

        Dim pbx1 As New PictureBox

        If tablaimagen.Rows.Count > 0 Then
            For i As Integer = 0 To tablaimagen.Rows.Count - 1
                If tablaimagen.Rows(i)(0).ToString() <> "" Then
                    pbx1.Image = ByteArrayToImage(DirectCast(tablaimagen.Rows(i)(0), Byte()))
                    GrabaImagenBase64(tablaimagen.Rows(i)(1), ImageToBase64String(pbx1.Image), tablaimagen.Rows(i)(2))
                End If
            Next
        End If
    End Sub

    Sub GrabaImagenBase64(ByVal guia As String, ByVal foto As String, ByVal num As Integer)

        Dim con As New SqlConnection
        Dim query As String = " UPDATE receimagen SET rimg_imagen2 = Convert(Varbinary(max),Convert(varchar(MAX),@foto)) " +
                              "  WHERE rimg_rececodi = @guia " +
                              "    AND rimg_num = @num "
        Dim cmd As New SqlCommand(query, con)

        cmd.Parameters.AddWithValue("@foto", foto)
        cmd.Parameters.AddWithValue("@guia", guia)
        cmd.Parameters.Add("@num", System.Data.SqlDbType.Int).Value = num
        con.ConnectionString = ("Data Source=" + ip.Trim() + "\PRECISABD; initial catalog=PRECISA;  USER=sa; PWD=precisa; Connection Timeout=0;")
        con.Open()

        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub

    Function ByteArrayToImage(ByVal byteArrayIn As Byte()) As Image
        Dim ms As New MemoryStream(byteArrayIn)
        Return Image.FromStream(ms)
    End Function

    Function ImageToBase64String(ByVal image As Image)
        Using memStream As New MemoryStream
            image.Save(memStream, ImageFormat.Jpeg)
            Dim result As String = Convert.ToBase64String(memStream.ToArray())
            memStream.Close()
            Return result
        End Using
    End Function

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        TraeImagenes()
        MsgBox("proceso Finalizado")
    End Sub

    Private Sub frmConvertirFotos_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
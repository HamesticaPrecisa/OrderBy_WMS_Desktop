Imports System.IO
Imports System.Configuration
Imports System.Drawing.Imaging
Imports System.Data.SqlClient
Public Class Frm_AdjuntaFotoDespacho

#Region "Declaraciones"
    Dim IMAGEN As String
    Dim fnc As New Funciones
#End Region

#Region "Funciones"
    Function ImageToByteArray(ByVal imageIn As Image) As Byte()
        Dim ms As New MemoryStream()
        imageIn.Save(ms, ImageFormat.Jpeg)
        Return ms.ToArray()
    End Function

    Function ByteArrayToImage(ByVal byteArrayIn As Byte()) As Image
        Dim ms As New MemoryStream(byteArrayIn)
        Return Image.FromStream(ms)
    End Function

    Function ImageToBase64String(ByVal image As Image)
        Using memStream As New MemoryStream

            image.Save(memStream, imageFormat.Jpeg)

            Dim result As String = Convert.ToBase64String(memStream.ToArray())

            memStream.Close()

            Return result

        End Using

    End Function

    Sub ExaminaImagen(pbox As PictureBox)
        Try
            Dim file As New OpenFileDialog()
            file.Filter = "Archivo JPG|*.jpg"
            If file.ShowDialog() = DialogResult.OK Then
                pbox.Image = Image.FromFile(file.FileName)
                pbox.Load(file.FileName)
                pbox.SizeMode = PictureBoxSizeMode.StretchImage
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub
    
    Sub GrabaImagen(ByVal guia As String, ByVal foto As Byte(), ByVal num As Integer, ByVal foto2 As String)
        Dim sql9 = "DELETE FROM despaimagen WHERE dimg_despcodi = '" + guia.ToString() + "' AND dimg_num = " + num.ToString() + ""
        fnc.MovimientoSQL(sql9)

        Dim con As New SqlConnection
        Dim query As String = "INSERT INTO despaimagen(dimg_imagen,dimg_despcodi,dimg_num,dimg_imagen2) VALUES(@foto,@guia,@num,Convert(Varbinary(max),Convert(varchar(MAX),@foto2)))"
        Dim cmd As New SqlCommand(query, con)

        cmd.Parameters.AddWithValue("@foto", foto)
        cmd.Parameters.AddWithValue("@foto2", foto2)
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

    Sub TraeImagenes()
        'Dim sql As String = "SELECT dimg_imagen,dimg_num FROM despaimagen WHERE dimg_despcodi= '" + Frm_Despacho.lblcodigo.Text + "'"
        Dim sql As String = "SELECT dimg_imagen,dimg_num FROM despaimagen WHERE dimg_despcodi= '" + Frm_Despacho.txtCodDesp.Text + "'"
        Dim tablaimagen As DataTable = fnc.ListarTablasSQL(sql)

        If tablaimagen.Rows.Count > 0 Then
            For i As Integer = 0 To tablaimagen.Rows.Count - 1
                If tablaimagen.Rows(i)(0).ToString() <> "" Then
                    Select Case tablaimagen.Rows(i)(1)
                        Case 1
                            PictureBox1.Image = ByteArrayToImage(DirectCast(tablaimagen.Rows(i)(0), Byte()))
                            PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
                        Case 2
                            PictureBox2.Image = ByteArrayToImage(DirectCast(tablaimagen.Rows(i)(0), Byte()))
                            PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage
                        Case 3
                            PictureBox3.Image = ByteArrayToImage(DirectCast(tablaimagen.Rows(i)(0), Byte()))
                            PictureBox3.SizeMode = PictureBoxSizeMode.StretchImage
                        Case 4
                            PictureBox4.Image = ByteArrayToImage(DirectCast(tablaimagen.Rows(i)(0), Byte()))
                            PictureBox4.SizeMode = PictureBoxSizeMode.StretchImage
                    End Select
                End If
            Next
        End If
    End Sub

#End Region

#Region "Eventos"

    Private Sub btnExaminar1_Click(sender As System.Object, e As System.EventArgs) Handles btnExaminar1.Click
        ExaminaImagen(PictureBox1)
    End Sub

    Private Sub btnExaminar2_Click(sender As System.Object, e As System.EventArgs) Handles btnExaminar2.Click
        ExaminaImagen(PictureBox2)
    End Sub

    Private Sub btnExaminar3_Click(sender As System.Object, e As System.EventArgs) Handles btnExaminar3.Click
        ExaminaImagen(PictureBox3)
    End Sub

    Private Sub btnExaminar4_Click(sender As System.Object, e As System.EventArgs) Handles btnExaminar4.Click
        ExaminaImagen(PictureBox4)
    End Sub

    Private Sub PictureBox1_MouseHover(sender As System.Object, e As System.EventArgs) Handles PictureBox1.MouseHover
        PictureBox5.Image = PictureBox1.Image
        PictureBox5.SizeMode = PictureBoxSizeMode.StretchImage
    End Sub

    Private Sub PictureBox1_MouseLeave(sender As System.Object, e As System.EventArgs) Handles PictureBox1.MouseLeave
        PictureBox5.Image = My.Resources.Resources._1391547217_File___Image_256x256_32
        PictureBox5.SizeMode = PictureBoxSizeMode.CenterImage
    End Sub

    Private Sub PictureBox2_MouseHover(sender As System.Object, e As System.EventArgs) Handles PictureBox2.MouseHover
        PictureBox5.Image = PictureBox2.Image
        PictureBox5.SizeMode = PictureBoxSizeMode.StretchImage
    End Sub

    Private Sub PictureBox2_MouseLeave(sender As Object, e As System.EventArgs) Handles PictureBox2.MouseLeave
        PictureBox5.Image = My.Resources.Resources._1391547217_File___Image_256x256_32
        PictureBox5.SizeMode = PictureBoxSizeMode.CenterImage
    End Sub

    Private Sub PictureBox3_MouseHover(sender As Object, e As System.EventArgs) Handles PictureBox3.MouseHover
        PictureBox5.Image = PictureBox3.Image
        PictureBox5.SizeMode = PictureBoxSizeMode.StretchImage
    End Sub

    Private Sub PictureBox3_MouseLeave(sender As Object, e As System.EventArgs) Handles PictureBox3.MouseLeave
        PictureBox5.Image = My.Resources.Resources._1391547217_File___Image_256x256_32
        PictureBox5.SizeMode = PictureBoxSizeMode.CenterImage
    End Sub

    Private Sub PictureBox4_MouseHover(sender As System.Object, e As System.EventArgs) Handles PictureBox4.MouseHover
        PictureBox5.Image = PictureBox4.Image
        PictureBox5.SizeMode = PictureBoxSizeMode.StretchImage
    End Sub

    Private Sub PictureBox4_MouseLeave(sender As Object, e As System.EventArgs) Handles PictureBox4.MouseLeave
        PictureBox5.Image = My.Resources.Resources._1391547217_File___Image_256x256_32
        PictureBox5.SizeMode = PictureBoxSizeMode.CenterImage
    End Sub

    Private Sub GuardaImagen1_Click(sender As System.Object, e As System.EventArgs) Handles GuardaImagen1.Click
        Dim msj = MsgBox("¿Seguro Desea Grabar Fotografía?", vbYesNo, "Adjuntar Fotografías Despacho")

        If msj = vbYes Then
            GrabaImagen(txtGuiaDespacho.Text, ImageToByteArray(PictureBox1.Image), 1, ImageToBase64String(PictureBox1.Image))
            MsgBox("Fotografía Guardada Exitosamente", MsgBoxStyle.Information, "Adjunta Fotografías a Despacho")
        End If
    End Sub

    Private Sub GuardaImagen2_Click(sender As System.Object, e As System.EventArgs) Handles GuardaImagen2.Click
        Dim msj = MsgBox("¿Seguro Desea Grabar Fotografía?", vbYesNo, "Adjuntar Fotografías Despacho")

        If msj = vbYes Then
            GrabaImagen(txtGuiaDespacho.Text, ImageToByteArray(PictureBox2.Image), 2, ImageToBase64String(PictureBox2.Image))
            MsgBox("Fotografía Guardada Exitosamente", MsgBoxStyle.Information, "Adjunta Fotografías a Despacho")
        End If
    End Sub

    Private Sub GuardaImagen3_Click(sender As System.Object, e As System.EventArgs) Handles GuardaImagen3.Click
        Dim msj = MsgBox("¿Seguro Desea Grabar Fotografía?", vbYesNo, "Adjuntar Fotografías Despacho")

        If msj = vbYes Then
            GrabaImagen(txtGuiaDespacho.Text, ImageToByteArray(PictureBox3.Image), 3, ImageToBase64String(PictureBox3.Image))
            MsgBox("Fotografía Guardada Exitosamente", MsgBoxStyle.Information, "Adjunta Fotografías a Despacho")
        End If
    End Sub

    Private Sub GuardaImagen4_Click(sender As System.Object, e As System.EventArgs) Handles GuardaImagen4.Click
        Dim msj = MsgBox("¿Seguro Desea Grabar Fotografía?", vbYesNo, "Adjuntar Fotografías Despacho")

        If msj = vbYes Then
            GrabaImagen(txtGuiaDespacho.Text, ImageToByteArray(PictureBox4.Image), 4, ImageToBase64String(PictureBox4.Image))
            MsgBox("Fotografía Guardada Exitosamente", MsgBoxStyle.Information, "Adjunta Fotografías a Despacho")
        End If
    End Sub

    Private Sub btnBorrar1_Click(sender As System.Object, e As System.EventArgs) Handles btnBorrar1.Click
        Dim msj = MsgBox("¿Seguro Desea Eliminar Fotografía?", vbYesNo, "Adjuntar Fotografías Despacho")

        If msj = vbYes Then
            PictureBox1.Image = My.Resources.Resources.sinimagen
            GrabaImagen(txtGuiaDespacho.Text, ImageToByteArray(PictureBox1.Image), 1, ImageToBase64String(PictureBox1.Image))
        End If
    End Sub

    Private Sub btnBorrar2_Click(sender As System.Object, e As System.EventArgs) Handles btnBorrar2.Click
        Dim msj = MsgBox("¿Seguro Desea Eliminar Fotografía?", vbYesNo, "Adjuntar Fotografías Despacho")

        If msj = vbYes Then
            PictureBox2.Image = My.Resources.Resources.sinimagen
            GrabaImagen(txtGuiaDespacho.Text, ImageToByteArray(PictureBox2.Image), 2, ImageToBase64String(PictureBox2.Image))
        End If
    End Sub

    Private Sub btnBorrar3_Click(sender As System.Object, e As System.EventArgs) Handles btnBorrar3.Click
        Dim msj = MsgBox("¿Seguro Desea Eliminar Fotografía?", vbYesNo, "Adjuntar Fotografías Despacho")

        If msj = vbYes Then
            PictureBox3.Image = My.Resources.Resources.sinimagen
            GrabaImagen(txtGuiaDespacho.Text, ImageToByteArray(PictureBox3.Image), 3, ImageToBase64String(PictureBox3.Image))
        End If
    End Sub

    Private Sub btnBorrar4_Click(sender As System.Object, e As System.EventArgs) Handles btnBorrar4.Click
        Dim msj = MsgBox("¿Seguro Desea Eliminar Fotografía?", vbYesNo, "Adjuntar Fotografías Despacho")

        If msj = vbYes Then
            PictureBox4.Image = My.Resources.Resources.sinimagen
            GrabaImagen(txtGuiaDespacho.Text, ImageToByteArray(PictureBox4.Image), 4, ImageToBase64String(PictureBox4.Image))
        End If
    End Sub

    Private Sub Frm_AdjuntaFotoDespacho_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        TraeImagenes()
    End Sub
#End Region

End Class
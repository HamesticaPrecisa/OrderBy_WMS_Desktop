Imports System.IO

Public Class Frm_ListarFotos

    Public codigo As String = ""

    Private fnc As New Funciones

    Private Sub Frm_ListarFotos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If codigo.Length > 0 Then
            Dim sqlImagen As String = "SELECT Convert(varchar(max), Convert(Varbinary(MAX),cl_imgtem)) , " +
                                      "       Convert(varchar(max), Convert(Varbinary(MAX),cl_imgsel)) , " +
                                      "       Convert(varchar(max), Convert(Varbinary(MAX),cl_imgpat)) , " +
                                      "       Convert(varchar(max), Convert(Varbinary(MAX),cl_imgtemS)), " +
                                      "       Convert(varchar(max), Convert(Varbinary(MAX),cl_imgselS)), " +
                                      "       Convert(varchar(max), Convert(Varbinary(MAX),cl_imgpatS))  " +
                                      "  FROM chk_images " +
                                      " WHERE id_chk = '" + Convert.ToInt32(codigo).ToString() + "'"

            Dim tablaimagen As DataTable = fnc.ListarTablasSQL(sqlImagen)

            If tablaimagen.Rows.Count > 0 Then

                'Imagen1
                If tablaimagen.Rows(0)(0).ToString() <> "" Then
                    PictureBox1.Image = Base64ToImage(tablaimagen.Rows(0)(0))
                Else
                    PictureBox1.Image = My.Resources.blanco
                End If

                'Imagen2
                If tablaimagen.Rows(0)(1).ToString() <> "" Then
                    PictureBox2.Image = Base64ToImage(tablaimagen.Rows(0)(1))
                Else
                    PictureBox2.Image = My.Resources.blanco
                End If

                'Imagen3
                If tablaimagen.Rows(0)(2).ToString() <> "" Then
                    PictureBox3.Image = Base64ToImage(tablaimagen.Rows(0)(2))
                Else
                    PictureBox3.Image = My.Resources.blanco
                End If

                'Imagen4
                If tablaimagen.Rows(0)(3).ToString() <> "" Then
                    PictureBox5.Image = Base64ToImage(tablaimagen.Rows(0)(3))
                Else
                    PictureBox5.Image = My.Resources.blanco
                End If

                'Imagen5
                If tablaimagen.Rows(0)(4).ToString() <> "" Then
                    PictureBox6.Image = Base64ToImage(tablaimagen.Rows(0)(4))
                Else
                    PictureBox6.Image = My.Resources.blanco
                End If

                'Imagen6
                If tablaimagen.Rows(0)(5).ToString() <> "" Then
                    PictureBox7.Image = Base64ToImage(tablaimagen.Rows(0)(5))
                Else
                    PictureBox7.Image = My.Resources.blanco
                End If
            Else
                PictureBox1.Image = Nothing
                PictureBox2.Image = Nothing
                PictureBox3.Image = Nothing
                PictureBox5.Image = Nothing
                PictureBox6.Image = Nothing
                PictureBox7.Image = Nothing
            End If
        End If

    End Sub
    Public Function ByteArrayToImage(ByVal byteArrayIn As Byte()) As Bitmap
        Dim ms = New MemoryStream(byteArrayIn)
        ms.Position = 0
        Dim imag = New Bitmap(ms)
        Return imag
    End Function
    Private Sub PictureBox1_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.MouseHover
        PictureBox4.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox4.Image = PictureBox1.Image
    End Sub

    Private Sub PictureBox1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox1.MouseLeave
        PictureBox4.Image = My.Resources.Resources._1391547217_File___Image_256x256_32
        PictureBox4.SizeMode = PictureBoxSizeMode.CenterImage
    End Sub

    Private Sub PictureBox2_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.MouseHover
        PictureBox4.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox4.Image = PictureBox2.Image
    End Sub

    Private Sub PictureBox2_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox2.MouseLeave
        PictureBox4.Image = My.Resources.Resources._1391547217_File___Image_256x256_32
        PictureBox4.SizeMode = PictureBoxSizeMode.CenterImage
    End Sub

    Private Sub PictureBox3_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.MouseHover
        PictureBox4.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox4.Image = PictureBox3.Image
    End Sub

    Private Sub PictureBox3_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox3.MouseLeave
        PictureBox4.Image = My.Resources.Resources._1391547217_File___Image_256x256_32
        PictureBox4.SizeMode = PictureBoxSizeMode.CenterImage
    End Sub
    Private Sub PictureBox5_MouseHover(sender As System.Object, e As System.EventArgs) Handles PictureBox5.MouseHover
        PictureBox4.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox4.Image = PictureBox5.Image
    End Sub
    Private Sub PictureBox5_MouseLeave(sender As Object, e As System.EventArgs) Handles PictureBox5.MouseLeave
        PictureBox4.Image = My.Resources.Resources._1391547217_File___Image_256x256_32
        PictureBox4.SizeMode = PictureBoxSizeMode.CenterImage
    End Sub
    Private Sub PictureBox6_MouseHover(sender As System.Object, e As System.EventArgs) Handles PictureBox6.MouseHover
        PictureBox4.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox4.Image = PictureBox6.Image
    End Sub
    Private Sub PictureBox6_MouseLeave(sender As Object, e As System.EventArgs) Handles PictureBox6.MouseLeave
        PictureBox4.Image = My.Resources.Resources._1391547217_File___Image_256x256_32
        PictureBox4.SizeMode = PictureBoxSizeMode.CenterImage
    End Sub
    Private Sub PictureBox7_MouseHover(sender As System.Object, e As System.EventArgs) Handles PictureBox7.MouseHover
        PictureBox4.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox4.Image = PictureBox7.Image
    End Sub
    Private Sub PictureBox7_MouseLeave(sender As Object, e As System.EventArgs) Handles PictureBox7.MouseLeave
        PictureBox4.Image = My.Resources.Resources._1391547217_File___Image_256x256_32
        PictureBox4.SizeMode = PictureBoxSizeMode.CenterImage
    End Sub
    Private Sub GuardaImagen1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GuardaImagen1.Click
        Guarda_Imagen(PictureBox1)
    End Sub
    Private Sub GuardaImagen2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GuardaImagen2.Click
        Guarda_Imagen(PictureBox2)
    End Sub
    Private Sub GuardaImagen3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles GuardaImagen3.Click
        Guarda_Imagen(PictureBox3)
    End Sub
    Private Sub GuardaImagen4_Click(sender As System.Object, e As System.EventArgs) Handles GuardaImagen4.Click
        Guarda_Imagen(PictureBox5)
    End Sub
    Private Sub GuardaImagen5_Click(sender As System.Object, e As System.EventArgs) Handles GuardaImagen5.Click
        Guarda_Imagen(PictureBox6)
    End Sub
    Private Sub GuardaImagen6_Click(sender As System.Object, e As System.EventArgs) Handles GuardaImagen6.Click
        Guarda_Imagen(PictureBox7)
    End Sub
    Sub Guarda_Imagen(ByVal pbx As PictureBox)
        Try
            'Dim pb As PictureBox = New PictureBox
            'pb.Width = 1200
            'pb.Height = 700
            'pb.SizeMode = PictureBoxSizeMode.StretchImage
            'pb.Image = pbx.Image

            Dim saveImage As New SaveFileDialog 'Este es el SaveFileDialog 
            Dim ruta As String = "" 'Para tener la ruta de la imagen 

            saveImage.Title = "Guardar imagen como..." 'Título de la ventana 
            saveImage.Filter = "Imagen JPG (*.jpg)|*.jpg|Imagen PNG (*.png)|*.png|Imagen BMP (*.bmp)|*.bmp" 'Los formatos en que se guardará la imagen 
            If saveImage.ShowDialog() = Windows.Forms.DialogResult.OK Then
                'Recuperar la ruta de la imagen si no está vacía 
                If Not String.IsNullOrEmpty(saveImage.FileName) Then ruta = saveImage.FileName

                Dim myImg As Image 'Objeto Image para guardar la imagen del Picture 
                Dim extension As String = ruta.Substring(ruta.Length - 3, 3) 'Recuperar los ultimos 3 caracteres de la extensión 
                myImg = pbx.Image 'Guardar la imagen del PictureBox en el objeto Image 

                '
                Dim scale_factor As Single = Single.Parse("800")

                ' Get the source bitmap.
                Dim bm_source As New Bitmap(myImg)

                ' Make a bitmap for the result.
                Dim bm_dest As New Bitmap( _
                    CInt(bm_source.Width * 6), _
                    CInt(bm_source.Height * 6))

                ' Make a Graphics object for the result Bitmap.
                Dim gr_dest As Graphics = Graphics.FromImage(bm_dest)

                ' Copy the source image into the destination bitmap.
                gr_dest.DrawImage(bm_source, 0, 0, _
                    bm_dest.Width + 1, _
                    bm_dest.Height + 1)

                ' Display the result.
                PictureBox4.Image = bm_dest

                '

                'ESTO SOLO FUNCIONA EN VISUAL BASIC 2008 
                Select Case extension
                    Case "bmp"
                        bm_dest.Save(ruta, Imaging.ImageFormat.Bmp) 'Guardar en formato BMP 
                    Case "jpg"
                        bm_dest.Save(ruta, Imaging.ImageFormat.Jpeg) 'Guardar en formato JPG 
                    Case "png"
                        bm_dest.Save(ruta, Imaging.ImageFormat.Png) 'Guardar en formato PNG 
                End Select
            End If
        Catch ex As Exception
            MsgBox("Error al Guardar Fotografia", MsgBoxStyle.Critical, "Error!")
        End Try
    End Sub

End Class
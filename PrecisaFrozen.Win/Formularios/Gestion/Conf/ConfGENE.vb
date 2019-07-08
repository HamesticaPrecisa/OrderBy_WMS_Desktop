Imports System.Drawing.Imaging
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Public Class ConfGENE
    Dim fnc As New Funciones

    Dim IMAGEN As String
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click

        Dim sino As String = ""
        If rdsi.Checked = True Then

            sino = "1"
        Else
            sino = "0"
        End If


        Dim sql As String = "UPDATE CONF_GENERAL SET  valconf='" + sino + "' WHERE nombreconf='VALIDAR RUT'"

        If fnc.MovimientoSQL(sql) > 0 Then

            MsgBox(" actualizado correctamente", MsgBoxStyle.Information, "Aviso")
        Else
            MsgBox("Error al actualizar el origen ", MsgBoxStyle.Critical, "Aviso")
        End If
    End Sub
    Sub cargarImagen()
        Try
            Me.OpenFileDialog1.ShowDialog()
            If Me.OpenFileDialog1.FileName <> "" Then

                IMAGEN = OpenFileDialog1.FileName
                Dim largo As Integer = IMAGEN.Length
                Dim imagen2 As String
                imagen2 = CStr(Microsoft.VisualBasic.Mid(RTrim(IMAGEN), largo - 2, largo))
                If imagen2 <> "gif" And imagen2 <> "bmp" And imagen2 <> "jpg" And imagen2 <> "jpeg" And imagen2 <> "GIF" And imagen2 <> "BMP" And imagen2 <> "JPG" And imagen2 <> "JPEG" Then
                    imagen2 = CStr(Microsoft.VisualBasic.Mid(RTrim(IMAGEN), largo - 3, largo))
                    If imagen2 <> "jpeg" And imagen2 <> "JPEG" And imagen2 <> "log1" Then
                        MsgBox("Formato no valido") : Exit Sub
                        If imagen2 <> "log1" Then Exit Sub
                    End If

                End If
            End If
        Catch ex As Exception

        End Try
        If Me.OpenFileDialog1.FileName = "OpenFileDialog1" Then
            Exit Sub
        Else
            PictureBox1.Load(IMAGEN)
        End If

    End Sub

    Public Sub Insert(ByVal codigo As String, ByVal foto As Byte(), ByVal foto2 As String)
        Dim sql9 = "delete from etiimg "
        fnc.MovimientoSQL(sql9)
        Dim con As New SqlConnection

        Dim query As String = "INSERT INTO etiimg(id,foto,foto2) VALUES(@codigo,@foto,Convert(Varbinary(max),Convert(varchar(MAX),@foto2)))"
        Dim cmd As New SqlCommand(query, con)


        cmd.Parameters.AddWithValue("@codigo", codigo)
        cmd.Parameters.Add("@foto", System.Data.SqlDbType.Image).Value = foto
        cmd.Parameters.AddWithValue("@foto2", foto2)
        con.ConnectionString = ("Data Source=" + ip.Trim() + "\PRECISABD; initial catalog=PRECISA;  USER=sa; PWD=precisa; Connection Timeout=0;")
        con.Open()
        Try
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try



        'Dim sql = "INSERT INTO usuimg(id,foto) VALUES('" + codigo + "','" + foto.ToString + "')"

        'fnc.MovimientoSQL(sql)
    End Sub
    Private Sub cargaimg()

        Dim sqlImagen As String = "SELECT foto from etiimg where id= '" + txtcodigo.Text + "'"

        Dim tablaimagen As DataTable = fnc.ListarTablasSQL(sqlImagen)

        If tablaimagen.Rows.Count > 0 Then

            'Imagen1
            If tablaimagen.Rows(0)(0).ToString() <> "" Then
                'PictureBox1.Image = Base64ToImage(tablaimagen.Rows(0)(0))
                PictureBox1.Image = ByteArrayToImage(DirectCast(tablaimagen.Rows(0)(0), Byte()))

            Else
                PictureBox1.Image = My.Resources.Resources.usuario_anonimo
            End If

        End If

    End Sub
    Public Function ByteArrayToImage(ByVal byteArrayIn As Byte()) As Image
        Dim ms As New MemoryStream(byteArrayIn)
        Return Image.FromStream(ms)
    End Function
    Private Sub ConfGENE_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        cargaimg()



        Dim sql As String = "SELECT valconf from conf_general where nombreconf='VALIDAR RUT'"

        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)
        If tabla.Rows.Count > 0 Then
            Dim nosi As String = ""
            nosi = tabla.Rows(0)(0)


            If nosi.Trim() = "1" Then

                rdsi.Checked = True
                rdno.Checked = False
            End If

            If nosi.Trim() = "0" Then

                rdsi.Checked = False
                rdno.Checked = True
            End If
        End If




        Dim sql2 As String = "SELECT * from conf_temp "

        Dim tabla2 As DataTable = fnc.ListarTablasSQL(sql2)
        If tabla2.Rows.Count > 0 Then
            txtcanttemp.Text = tabla2.Rows(0)(0).ToString()
            txtrangoxcong.Text = tabla2.Rows(0)(1).ToString()
            txtrangoycong.Text = tabla2.Rows(0)(2).ToString()
            txtranngoxrefri.Text = tabla2.Rows(0)(3).ToString()
            txtrangoyrefri.Text = tabla2.Rows(0)(4).ToString()
            txtrangoxseco.Text = tabla2.Rows(0)(5).ToString()
            txtrangoyseco.Text = tabla2.Rows(0)(6).ToString()




        
        End If
        Dim sql3 As String = "SELECT * from conf_limitkilo "

        Dim tabla3 As DataTable = fnc.ListarTablasSQL(sql3)
        If tabla3.Rows.Count > 0 Then
            txtmaxkil.Text = tabla3.Rows(0)(0).ToString()


        End If
        Dim sql4 As String = "SELECT * from conf_impcant "

        Dim tabla4 As DataTable = fnc.ListarTablasSQL(sql4)
        If tabla4.Rows.Count > 0 Then
            TXTCANTIMP.Text = tabla4.Rows(0)(0).ToString()


        End If
    End Sub

    Private Sub ConfGENE_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        f_confgene = False
    End Sub
    Public Function ImageToByteArray(ByVal imageIn As Image) As Byte()
        Dim ms As New MemoryStream()
        imageIn.Save(ms, ImageFormat.Jpeg)
        Return ms.ToArray()
    End Function

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        cargarImagen()
    End Sub
    Function ImageToBase64String(ByVal image As Image)
        Using memStream As New MemoryStream

            image.Save(memStream, imageFormat.Jpeg)

            Dim result As String = Convert.ToBase64String(memStream.ToArray())

            memStream.Close()

            Return result

        End Using

    End Function
    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Insert(txtcodigo.Text, ImageToByteArray(PictureBox1.Image), ImageToBase64String(PictureBox1.Image))
        MsgBox("Información Guardada correctamente", MsgBoxStyle.Information, "Aviso")
    End Sub

    Private Sub txtrangoxcong_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtrangoxcong.KeyPress
        Dim x As TextBox = CType(sender, TextBox)
        If Not IsNumeric(e) Then
            If e.KeyChar = "." Or e.KeyChar = ChrW(8) Or e.KeyChar = "-" Then

                For i As Integer = 0 To x.Text.Length - 1
                    If x.Text.Chars(i) = e.KeyChar Then
                        If Not (x.SelectionStart = 0 AndAlso x.SelectionLength = x.Text.Length) Then
                            SoloNumeros(sender, e)
                        End If
                    ElseIf x.Text.Chars(i) = e.KeyChar Then
                        SoloNumeros(sender, e)
                    ElseIf x.Text.Chars(i) = e.KeyChar Then
                        SoloNumeros(sender, e)
                    End If
                Next
            Else
                SoloNumeros(sender, e)
            End If
        End If

    End Sub

    Private Sub txtrangoycong_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtrangoycong.KeyPress
        Dim x As TextBox = CType(sender, TextBox)
        If Not IsNumeric(e) Then
            If e.KeyChar = "." Or e.KeyChar = ChrW(8) Or e.KeyChar = "-" Then

                For i As Integer = 0 To x.Text.Length - 1
                    If x.Text.Chars(i) = e.KeyChar Then
                        If Not (x.SelectionStart = 0 AndAlso x.SelectionLength = x.Text.Length) Then
                            SoloNumeros(sender, e)
                        End If
                    ElseIf x.Text.Chars(i) = e.KeyChar Then
                        SoloNumeros(sender, e)
                    ElseIf x.Text.Chars(i) = e.KeyChar Then
                        SoloNumeros(sender, e)
                    End If
                Next
            Else
                SoloNumeros(sender, e)
            End If
        End If

    End Sub

    Private Sub txtranngoxrefri_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtranngoxrefri.KeyPress
        Dim x As TextBox = CType(sender, TextBox)
        If Not IsNumeric(e) Then
            If e.KeyChar = "." Or e.KeyChar = ChrW(8) Or e.KeyChar = "-" Then

                For i As Integer = 0 To x.Text.Length - 1
                    If x.Text.Chars(i) = e.KeyChar Then
                        If Not (x.SelectionStart = 0 AndAlso x.SelectionLength = x.Text.Length) Then
                            SoloNumeros(sender, e)
                        End If
                    ElseIf x.Text.Chars(i) = e.KeyChar Then
                        SoloNumeros(sender, e)
                    ElseIf x.Text.Chars(i) = e.KeyChar Then
                        SoloNumeros(sender, e)
                    End If
                Next
            Else
                SoloNumeros(sender, e)
            End If
        End If

    End Sub

    Private Sub txtrangoyrefri_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtrangoyrefri.KeyPress
        Dim x As TextBox = CType(sender, TextBox)
        If Not IsNumeric(e) Then
            If e.KeyChar = "." Or e.KeyChar = ChrW(8) Or e.KeyChar = "-" Then

                For i As Integer = 0 To x.Text.Length - 1
                    If x.Text.Chars(i) = e.KeyChar Then
                        If Not (x.SelectionStart = 0 AndAlso x.SelectionLength = x.Text.Length) Then
                            SoloNumeros(sender, e)
                        End If
                    ElseIf x.Text.Chars(i) = e.KeyChar Then
                        SoloNumeros(sender, e)
                    ElseIf x.Text.Chars(i) = e.KeyChar Then
                        SoloNumeros(sender, e)
                    End If
                Next
            Else
                SoloNumeros(sender, e)
            End If
        End If

    End Sub

    Private Sub txtrangoxseco_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtrangoxseco.KeyPress
        Dim x As TextBox = CType(sender, TextBox)
        If Not IsNumeric(e) Then
            If e.KeyChar = "." Or e.KeyChar = ChrW(8) Or e.KeyChar = "-" Then

                For i As Integer = 0 To x.Text.Length - 1
                    If x.Text.Chars(i) = e.KeyChar Then
                        If Not (x.SelectionStart = 0 AndAlso x.SelectionLength = x.Text.Length) Then
                            SoloNumeros(sender, e)
                        End If
                    ElseIf x.Text.Chars(i) = e.KeyChar Then
                        SoloNumeros(sender, e)
                    ElseIf x.Text.Chars(i) = e.KeyChar Then
                        SoloNumeros(sender, e)
                    End If
                Next
            Else
                SoloNumeros(sender, e)
            End If
        End If

    End Sub

    Private Sub txtrangoyseco_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtrangoyseco.KeyPress
        Dim x As TextBox = CType(sender, TextBox)
        If Not IsNumeric(e) Then
            If e.KeyChar = "." Or e.KeyChar = ChrW(8) Or e.KeyChar = "-" Then

                For i As Integer = 0 To x.Text.Length - 1
                    If x.Text.Chars(i) = e.KeyChar Then
                        If Not (x.SelectionStart = 0 AndAlso x.SelectionLength = x.Text.Length) Then
                            SoloNumeros(sender, e)
                        End If
                    ElseIf x.Text.Chars(i) = e.KeyChar Then
                        SoloNumeros(sender, e)
                    ElseIf x.Text.Chars(i) = e.KeyChar Then
                        SoloNumeros(sender, e)
                    End If
                Next
            Else
                SoloNumeros(sender, e)
            End If
        End If

    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        If txtrangoxcong.Text = "" Or txtrangoxcong.Text = "-" Or txtrangoycong.Text = "" Or txtrangoycong.Text = "-" Or txtranngoxrefri.Text = "" Or txtranngoxrefri.Text = "-" Or txtrangoyrefri.Text = "" Or txtrangoyrefri.Text = "-" Or txtrangoxseco.Text = "" Or txtrangoxseco.Text = "-" Or txtrangoyseco.Text = "" Or txtrangoyseco.Text = "-" Then
            MsgBox("Complete Todos los rangos ", MsgBoxStyle.Critical, "Aviso")
            Exit Sub
        Else
            If txtcanttemp.Text = "" Then
                MsgBox("Ingrese cantidad de temp ", MsgBoxStyle.Critical, "Aviso")
                Exit Sub

            Else

                Dim sql As String = "UPDATE CONF_TEMP SET  Numerotemp='" + txtcanttemp.Text.Trim() + "', rangoxcong='" + txtrangoxcong.Text.Trim() + "', rangoycong='" + txtrangoycong.Text.Trim() + "',rangoxrefri='" + txtranngoxrefri.Text.Trim() + "',rangoyrefri='" + txtrangoyrefri.Text.Trim() + "',rangoxseco='" + txtrangoxseco.Text.Trim() + "',rangoyseco='" + txtrangoyseco.Text.Trim() + "' "

                If fnc.MovimientoSQL(sql) > 0 Then

                    MsgBox(" actualizado correctamente", MsgBoxStyle.Information, "Aviso")
                Else
                    MsgBox("Error al actualizar ", MsgBoxStyle.Critical, "Aviso")
                End If

            End If



        End If
    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        If txtmaxkil.Text = "" Then
            MsgBox("Ingrese cantidad ", MsgBoxStyle.Critical, "Aviso")
            Exit Sub
        Else
            Dim sql As String = "UPDATE CONF_limitkilo SET  limitekilos='" + txtmaxkil.Text.Trim() + "'"

            If fnc.MovimientoSQL(sql) > 0 Then

                MsgBox(" actualizado correctamente", MsgBoxStyle.Information, "Aviso")
            Else
                MsgBox("Error al actualizar ", MsgBoxStyle.Critical, "Aviso")
            End If


        End If
    End Sub

    Private Sub TextBox1_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCANTIMP.KeyPress
        SoloNumeros(sender, e)
    End Sub

    Private Sub Button6_Click(sender As System.Object, e As System.EventArgs) Handles Button6.Click
        If TXTCANTIMP.Text = "" Then
            MsgBox("Ingrese cantidad ", MsgBoxStyle.Critical, "Aviso")
            Exit Sub
        Else
            Dim sql As String = "UPDATE CONF_impcant SET  cantimp='" + TXTCANTIMP.Text.Trim() + "'"

            If fnc.MovimientoSQL(sql) > 0 Then

                MsgBox(" actualizado correctamente", MsgBoxStyle.Information, "Aviso")
            Else
                MsgBox("Error al actualizar ", MsgBoxStyle.Critical, "Aviso")
            End If


        End If
    End Sub
End Class
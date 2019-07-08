Imports System.IO
Imports System.Configuration
Imports System.Drawing.Imaging
Imports System.Data.SqlClient

Public Class Frm_MantenedorUsuarios
    Dim IMAGEN As String
    Dim fnc As New Funciones

    Dim TablaAsignaciones As DataTable = New DataTable

    Dim IsOperaciones As Boolean = False
    Private Sub Frm_MantenedorUsuarios_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        pf_usuarios = False
    End Sub

    Public Sub Insert(ByVal codigo As String, ByVal foto As Byte())
        Dim sql9 = "delete from usuimg where id='" + txtcodigo.Text + "'"
        fnc.MovimientoSQL(sql9)
        Dim con As New SqlConnection

        Dim query As String = "INSERT INTO usuimg(id,foto) VALUES(@codigo,@foto)"
        Dim cmd As New SqlCommand(query, con)


        cmd.Parameters.AddWithValue("@codigo", codigo)
        cmd.Parameters.Add("@foto", System.Data.SqlDbType.Image).Value = foto
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
    Public Function ByteArrayToImage(ByVal byteArrayIn As Byte()) As Image
        Dim ms As New MemoryStream(byteArrayIn)
        Return Image.FromStream(ms)
    End Function
    Private Sub cargaimg()

        Dim sqlImagen As String = "SELECT foto from usuimg where id= '" + txtcodigo.Text + "'"

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


    Private Sub cargaimg2()



    End Sub
    Private Sub llenacom()


        cbodesbod.DataSource = fnc.ListarTablasSQL("SELECT des_bodega  FROM mae_bodega ORDER BY Cod_Bodega ASC")
        cbodesbod.ValueMember = "des_bodega"
        cbodesbod.DisplayMember = "des_bodega"

    End Sub
    Private Sub Frm_MantenedorUsuarios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Frm_Principal.buscavalor = ""

        Dim where = ""

        If RealizarAccion("014", "089", False) = True AndAlso RealizarAccion("014", "036", False) = False Then
            where = " WHERE sec_id='2' "
            IsOperaciones = True
        End If


        Dim sql As String = "SELECT  Priv_Id, Priv_Nombre FROM  PrivilegiosSeccion  ORDER BY Priv_Id"

        Lst_categorias.DataSource = fnc.ListarTablasSQL(sql)
        Lst_categorias.DisplayMember = "Priv_Nombre"
        Lst_categorias.ValueMember = "Priv_Id"
        Lst_categorias.SelectedValue = 1

        Cmbo_Secciones.DataSource = fnc.ListarTablasSQL("SELECT sec_id, sec_Descr FROM secciones " + where + " ORDER BY sec_id ")
        Cmbo_Secciones.DisplayMember = "Sec_Descr"
        Cmbo_Secciones.ValueMember = "Sec_Id"

        sql = "SELECT Spriv_Id, Spriv_nombre FROM PrivilegiosSubSeccion WHERE spriv_Id=''"
        TablaAsignaciones = fnc.ListarTablasSQL(sql)
        Lst_Funciones.DataSource = TablaAsignaciones
        Lst_Funciones.DisplayMember = "Spriv_nombre"
        Lst_Funciones.ValueMember = "Spriv_id"
        llenacom()
    End Sub

    Private Sub Lst_categorias_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Lst_categorias.SelectedIndexChanged
        If Not IsNothing(Lst_categorias.SelectedValue) Then
            Dim where As String = ""

            If IsOperaciones = True Then
                where = "AND spriv_habil='1'"
            End If

            Dim sql As String = "SELECT  SPriv_Id, SPriv_Nombre FROM  PrivilegiosSubSeccion WHERE " +
                               "Spriv_PrivId='" + Lst_categorias.SelectedValue.ToString() + "' " + where + " ORDER BY SPriv_Id"

            Lst_SubCategorias.DataSource = fnc.ListarTablasSQL(sql)
            Lst_SubCategorias.DisplayMember = "SPriv_Nombre"
            Lst_SubCategorias.ValueMember = "SPriv_Id"
        End If
    End Sub

    Private Sub txtrut_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtrut.KeyPress
        If e.KeyChar = ChrW(13) Then
            If txtrut.Text.Length = 8 Then
                txtrutv.Focus()
            End If
        End If
    End Sub

    Private Sub txtrutv_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtrutv.KeyPress

        If e.KeyChar = ChrW(13) Then
            If txtrutv.Text.Length = 1 AndAlso txtrut.Text.Length = 8 Then
                If fnc.verificaExistencia("usuarios", "usu_rut", txtrut.Text + txtrutv.Text) = True Then
                    ' buscar
                    busca_usuario(txtrut.Text + txtrutv.Text)

                Else
                    If RutDigito(txtrut.Text + "-" + txtrutv.Text) = True Then
                        txtrut.Enabled = False
                        txtrutv.Enabled = False
                        Btn_BuscaUsuarios.Enabled = False
                        btn_guardar.Enabled = True
                        Panel1.Enabled = True
                    Else
                        MsgBox("El R.U.T ingresado no es valido", MsgBoxStyle.Critical, "Aviso")
                        txtrutv.Text = ""
                        txtrut.Text = ""
                        txtrut.Focus()
                    End If
                End If
            End If
        End If
    End Sub

    Sub busca_usuario(ByVal rut As String)

        Dim where As String = ""

        If IsOperaciones = True Then
            where = "AND Usu_SecCod='2'"
        End If

        Dim SqlBusca = "SELECT usu_nombre, usu_ap, usu_am, usu_email, usu_anexo, usu_teleme, usu_usuario, usu_pass, " +
                                   "radio, usu_codvig, Usu_SecCod, usu_codigo ,des_bodega FROM Usuarios WHERE usu_rut='" + rut + "' " + where

        Dim tabla As DataTable = fnc.ListarTablasSQL(SqlBusca)

        If tabla.Rows.Count > 0 Then

            TxtNom1.Text = tabla.Rows(0)(0).ToString()
            TxtAp.Text = tabla.Rows(0)(1).ToString()
            TxtAm.Text = tabla.Rows(0)(2).ToString()
            TxtEmail.Text = tabla.Rows(0)(3).ToString()
            TxtAnexo.Text = tabla.Rows(0)(4).ToString()
            TxtTelEme.Text = tabla.Rows(0)(5).ToString()
            TxtUsu.Text = tabla.Rows(0)(6).ToString()
            TxtPass.Text = Desencriptar(tabla.Rows(0)(7).ToString())
            TxtPass2.Text = Desencriptar(tabla.Rows(0)(7).ToString())
            Cb_Radio.CheckState = tabla.Rows(0)(8).ToString()
            Cb_Activo.CheckState = tabla.Rows(0)(9).ToString()
            Cmbo_Secciones.SelectedValue = tabla.Rows(0)(10).ToString()
            txtcodigo.Text = tabla.Rows(0)(11).ToString()
            cbodesbod.Text = tabla.Rows(0)(12).ToString()
            txtrut.Enabled = False
            txtrutv.Enabled = False
            Btn_BuscaUsuarios.Enabled = False
            btn_guardar.Enabled = True
            Panel1.Enabled = True
            btnTag.Enabled = True

            Dim SqlFunciones As String = "SELECT Usu_sprivId, Usu_Fnc FROM UsuariosFunciones WHERE usu_rut='" + txtrut.Text + txtrutv.Text + "'"

            TablaAsignaciones = fnc.ListarTablasSQL(SqlFunciones)
            Lst_Funciones.DataSource = TablaAsignaciones
            Lst_Funciones.DisplayMember = "Usu_Fnc"
            Lst_Funciones.ValueMember = "Usu_sprivId"
        Else
            btn_nuevo_Click(Nothing, Nothing)
        End If
    End Sub



    Function ValidaIngreso()
        ValidaIngreso = True
        Dim mensaje As String = ""


        If TxtNom1.Text.Trim = "" Then
            mensaje = mensaje + "- Nombre " + vbCrLf
            ValidaIngreso = False
        End If

        If TxtAp.Text.Trim = "" Then
            mensaje = mensaje + "- Apellido " + vbCrLf
            ValidaIngreso = False
        End If

        If TxtUsu.Text.Trim = "" Then
            mensaje = mensaje + "- Usuario " + vbCrLf
            ValidaIngreso = False
        End If

        If TxtTelEme.Text.Trim = "" Then
            TxtTelEme.Text = "0"
        End If

        If TxtPass.Text.Trim <> TxtPass2.Text.Trim Or (TxtPass2.Text.Trim = "" Or TxtPass.Text.Trim = "") Then
            mensaje = mensaje + "- Contraseñas Iguales " + vbCrLf
            ValidaIngreso = False
        End If

        If TxtUsu.BackColor = Color.Red Then
            mensaje = mensaje + "- Cambiar nombre de usuario" + vbCrLf
            ValidaIngreso = False
        End If

        If mensaje <> "" Then
            MsgBox("Ingrese Lo siguiente para continuar" + vbCrLf + mensaje, MsgBoxStyle.Critical, "Aviso")
        End If

    End Function


    Private Sub Lst_SubCategorias_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Lst_SubCategorias.DoubleClick
        For i As Integer = 0 To TablaAsignaciones.Rows.Count - 1
            If TablaAsignaciones(i)(0).ToString() = Me.Lst_SubCategorias.SelectedValue.ToString() Then
                Exit Sub
            End If
        Next
        If TablaAsignaciones.Columns.Count = 0 Then
            Lst_Funciones.DisplayMember = "nom"
            Lst_Funciones.ValueMember = "cod"
        End If
        TablaAsignaciones.Rows.Add(Lst_SubCategorias.SelectedValue.ToString(), Lst_SubCategorias.Text.ToString())
        Lst_Funciones.DataSource = TablaAsignaciones



    End Sub

    Private Sub Lst_Funciones_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Lst_Funciones.DoubleClick
        For i As Integer = 0 To TablaAsignaciones.Rows.Count - 1
            If TablaAsignaciones.Rows(i)(0).ToString() = Lst_Funciones.SelectedValue.ToString() Then
                TablaAsignaciones.Rows.RemoveAt(i)
                Exit For
            End If
        Next
        Lst_Funciones.DataSource = TablaAsignaciones
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim sql As String = "SELECT Spriv_Id, Spriv_nombre FROM PrivilegiosSubSeccion WHERE Spriv_id='0'"
        TablaAsignaciones = fnc.ListarTablasSQL(sql)
        Lst_Funciones.DataSource = TablaAsignaciones
        Lst_Funciones.DisplayMember = "Spriv_nombre"
        Lst_Funciones.ValueMember = "Spriv_id"
    End Sub



    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim sql As String = "SELECT Spriv_Id, Spriv_nombre FROM PrivilegiosSubSeccion"
        TablaAsignaciones = fnc.ListarTablasSQL(sql)
        Lst_Funciones.DataSource = TablaAsignaciones
        Lst_Funciones.DisplayMember = "Spriv_nombre"
        Lst_Funciones.ValueMember = "Spriv_id"
    End Sub
    Private Sub guardaimg()
        Dim myImg As Image 'Objeto Image para guardar la imagen del Picture 
        myImg = PictureBox1.Image 'Guardar la imagen del PictureBox en el objeto Image
        insertarImagen(fnc.bytesToString(fnc.ImagenToBytes(myImg)))

    End Sub
    Sub insertarImagen(ByVal foto As String)

        Dim sql0 As String = "Select * from usuimg  where id='" + txtcodigo.Text + "'"
        If fnc.MovimientoSQL(sql0) < 0 Then
            Dim sql2 = "UPDATE usuimg SET foto='" & foto & "' where id='" + txtcodigo.Text + "'"
            fnc.MovimientoSQL(sql2)
        Else
            Dim sql9 = "delete from usuimg where id='" + txtcodigo.Text + "'"
            fnc.MovimientoSQL(sql9)



            Dim sql = "insert into usuimg(Id,foto) values('" + txtcodigo.Text + "',Convert(Varbinary(max),Convert(varchar(MAX),'" & foto & "'))) "

            fnc.MovimientoSQL(sql)
        End If



    End Sub
    Public Function ImageToByteArray(ByVal imageIn As Image) As Byte()
        Dim ms As New MemoryStream()
        imageIn.Save(ms, ImageFormat.Jpeg)
        Return ms.ToArray()
    End Function
    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        If ValidaIngreso() = True Then
            If fnc.verificaExistencia("usuarios", "usu_rut", txtrut.Text + txtrutv.Text) = False Then

                Dim codigo_usuario As String = BuscaCorrelativo("004", 3)


                Dim sql As String = "INSERT INTO Usuarios(usu_codigo, usu_rut, usu_nombre, usu_ap, usu_am, usu_email, usu_anexo, " +
                                            "usu_teleme, usu_usuario, usu_pass, radio , personal, descri, usu_codvig, usu_seccod, usu_pass2, usu_passweb,des_bodega)" +
                                            "VALUES('" + codigo_usuario + "','" + txtrut.Text + txtrutv.Text + "'," +
                                            "'" + TxtNom1.Text + "','" + TxtAp.Text + "','" + TxtAm.Text + "','" + TxtEmail.Text + "'," +
                                            "'" + TxtAnexo.Text + "','" + TxtTelEme.Text + "','" + TxtUsu.Text + "','" + Encriptar(TxtPass.Text) + "'," +
                                            "'" + EstadoCheckBox(Cb_Radio.CheckState) + "','" + codigo_usuario + "'," +
                                            "'" + TxtNom1.Text + " " + TxtAp.Text + " " + TxtAm.Text + "','" + EstadoCheckBox(Cb_Activo.CheckState) + "', " +
                                            "'" + Cmbo_Secciones.SelectedValue.ToString() + "','" + CODIFICA(TxtPass2.Text) + "','" + MD5EncryptPass(TxtPass.Text) + "','" + cbodesbod.Text + "')"

                If fnc.MovimientoSQL(sql) > 0 Then

                    For i As Integer = 0 To TablaAsignaciones.Rows.Count - 1

                        Dim SqlDetalle As String = "INSERT INTO UsuariosFunciones(usu_rut, usu_sprivId, Usu_Fnc)VALUES" +
                            "('" + txtrut.Text + txtrutv.Text + "','" + TablaAsignaciones.Rows(i)(0).ToString() + "','" + TablaAsignaciones.Rows(i)(1).ToString() + "')"

                        If fnc.MovimientoSQL(SqlDetalle) > 0 Then


                        End If

                    Next
                    MsgBox("Usuario Agregado Correctamente", MsgBoxStyle.Information, "Aviso")
                    If primerusuario = "S" Then
                        Frm_Principal.ShowDialog()
                        Me.Close()
                    End If
                End If
            Else
                Dim SqlElimina As String = "DELETE  UsuariosFunciones WHERE Usu_Rut='" + txtrut.Text + txtrutv.Text + "'"

                If fnc.MovimientoSQL(SqlElimina) > 0 Then

                    Dim sql As String = "UPDATE Usuarios SET  usu_nombre='" + TxtNom1.Text + "', usu_ap='" + TxtAp.Text + "', usu_am='" + TxtAm.Text + "', " +
                                        "usu_email='" + TxtEmail.Text + "', usu_anexo='" + TxtAnexo.Text + "',  usu_teleme='" + TxtTelEme.Text + "', " +
                                        "usu_usuario='" + TxtUsu.Text + "', usu_pass='" + Encriptar(TxtPass.Text) + "' , " +
                                        "radio='" + EstadoCheckBox(Cb_Radio.CheckState) + "', descri='" + TxtNom1.Text + " " + TxtAp.Text + " " + TxtAm.Text + "', " +
                                        "usu_codvig='" + EstadoCheckBox(Cb_Activo.CheckState) + "', usu_seccod='" + Cmbo_Secciones.SelectedValue.ToString() + "', " +
                                        "usu_pass2='" + CODIFICA(TxtPass2.Text) + "', usu_passweb='" + MD5EncryptPass(TxtPass.Text) + "', des_bodega='" + cbodesbod.Text + "' " +
                                        "WHERE usu_rut='" + txtrut.Text + txtrutv.Text + "'"

                    If fnc.MovimientoSQL(sql) > 0 Then

                        For i As Integer = 0 To TablaAsignaciones.Rows.Count - 1

                            Dim SqlDetalle As String = "INSERT INTO UsuariosFunciones(usu_rut, usu_sprivId, Usu_Fnc)VALUES" +
                                "('" + txtrut.Text + txtrutv.Text + "','" + TablaAsignaciones.Rows(i)(0).ToString() + "','" + TablaAsignaciones.Rows(i)(1).ToString() + "')"

                            fnc.MovimientoSQL(SqlDetalle)
                        Next
                        '   guardaimg()
                        Insert(txtcodigo.Text, ImageToByteArray(PictureBox1.Image))
                        MsgBox("Usuario Actualizado Correctamente", MsgBoxStyle.Information, "Aviso")

                    Else
                        MsgBox("Error al actualizar el usuario", MsgBoxStyle.Information, "Aviso")
                    End If
                End If
            End If
        End If



    End Sub

    Private Sub btn_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        txtrut.Text = ""
        txtrutv.Text = ""
        txtrut.Focus()
        Cb_Radio.CheckState = CheckState.Unchecked
        txtrut.Enabled = True
        txtrutv.Enabled = True
        Btn_BuscaUsuarios.Enabled = True
        LimpiarCajas(GroupBox1)
        LimpiarCajas(GroupBox2)
        LimpiarCajas(Panel1)
        PictureBox1.Image = My.Resources.Resources.usuario_anonimo
        btnTag.Enabled = False
    End Sub

    Private Sub TxtTelEme_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtTelEme.KeyPress
        SoloNumeros(sender, e)
    End Sub

    Private Sub TxtUsu_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtUsu.KeyUp
        Dim sql As String = "SELECT * FROM usuarios WHERE usu_usuario='" + TxtUsu.Text + "' AND usu_rut<>'" + txtrut.Text & "" & txtrutv.Text + "'"
        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)
        If tabla.Rows.Count > 0 Then
            TxtUsu.BackColor = Color.Red
        Else
            TxtUsu.BackColor = Color.White
        End If
    End Sub


    Private Sub BtnContraseña_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnContraseña.Click
        Dim sql As String = "SELECT usu_pass FROM usuarios WHERE usu_codigo='" + txtcodigo.Text + "'"
        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

        If tabla.Rows.Count > 0 Then
            MsgBox(Desencriptar(tabla.Rows(0)(0).ToString()))
        End If
    End Sub

    Private Sub Btn_BuscaUsuarios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_BuscaUsuarios.Click
        Dim f As New Frm_ListadoUsuarios
        f.ShowDialog(Frm_Principal)
        If Frm_Principal.buscavalor.ToString() <> "" Then
            txtrut.Text = Frm_Principal.buscavalor.ToString().Remove(8)
            txtrutv.Text = Frm_Principal.buscavalor.ToString().Chars(8)
            busca_usuario(Frm_Principal.buscavalor.ToString())
        End If

        If txtcodigo.Text <> "" Then
            cargaimg()

        End If
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Close()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        cargarImagen()
    End Sub

    Private Sub btnTag_Click(sender As System.Object, e As System.EventArgs) Handles btnTag.Click
        Dim CodUsu = txtcodigo.Text.Trim
        If (CodUsu = "") Then
            MessageBox.Show("Debe seleccionar un usuario registrado en el sistema.", "Información!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim CodUsuAux = "00000000000000" & CodUsu

        Dim EPCText As String = "A" & CodUsuAux.Substring(CodUsuAux.Length - 14, 14) & "A"

        fnc.writeTag(EPCText)
    End Sub

    Private Sub btn_Imprimir_Click(sender As System.Object, e As System.EventArgs) Handles btn_Imprimir.Click
        Dim query As String = "select usu_codigo as Codigo, usu_nombre as Nombre, usu_ap as Apellido, Sec_Descr as Departamento, Usu_Fnc as Funcion from Usuarios as u " +
        "inner join UsuariosFunciones as uf on uf.Usu_Rut=u.usu_rut " +
        "inner join Secciones as s on s.Sec_Id=u.Usu_SecCod " +
        "where usu_codvig='1' order by Departamento,Codigo,Funcion asc;"

        Dim dt As New DataTable
        dt = fnc.ListarTablasSQL(query)

        DGVusuario.DataSource = dt
        GridAExcel2(DGVusuario)


    End Sub

End Class
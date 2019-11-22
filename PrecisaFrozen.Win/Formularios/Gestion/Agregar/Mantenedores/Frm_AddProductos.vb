Imports System.IO
Imports System.Configuration
Imports System.Drawing.Imaging
Imports System.Data.SqlClient
Public Class Frm_AddProductos


    Dim fnc As New Funciones
    Dim IMAGEN As String
    Dim tabla As DataTable
    Dim provar As String = ""

    Public Function validacion() As Boolean
        Dim valor As Boolean = True
        Dim mensaje As String = ""

        If txtproddescr.Text = "" Then
            mensaje = mensaje + "- Descripcion del producto" + vbCrLf
            valor = False
        ElseIf txtdescrenvase.Text = "" Then
            mensaje = mensaje + "- Envase del producto" + vbCrLf
            valor = False
        ElseIf RutDigito(clirut.Text) = False Then
            mensaje = mensaje + "- Cliente asociado" + vbCrLf
            valor = False
        ElseIf clinom.Text.Trim = "" Then
            mensaje = mensaje + "- El cliente ingresado no existe" + vbCrLf
            valor = False
        End If
        If TxtMesVenc.Text = "" Then
            mensaje = mensaje + "- Debe ingresar los meses de vencimiento" + vbCrLf
            valor = False
        End If
        If TxtMesVenc.Text = "" Then
            mensaje = mensaje + "- Debe ingresar los meses de vencimiento" + vbCrLf
            valor = False
        End If
        If Convert.ToInt32(TxtMesVenc.Text) = 0 Then
            mensaje = mensaje + "- Debe ingresar Duracion Superior a 0 Meses" + vbCrLf
            valor = False
        End If

        If fnc.verificaExistenciaCondicional("maeprod", "mae_codcli='" + TxtcodCli.Text + "' AND " +
                                             "mae_clirut='" + QuitarCaracteres(clirut.Text) + "' " +
                                             "AND mae_codcli<>'' AND mae_codi<>'" + (txtcodfamilia.Text + CerosAnteriorString(txtcorrelativo.Text, 4)) + "'") = True Then
            mensaje = mensaje + "- El codigo cliente esta registrado" + vbCrLf
            valor = False
        End If

        If mensaje.ToString() <> "" Then
            MsgBox("Debe ingresar lo siguiente antes de guardar : " + vbCrLf + mensaje, MsgBoxStyle.Critical, "Aviso")
        End If

        Return valor
    End Function

    Public Sub bskrFamilia()
        If fnc.verificaExistencia("famprod", "fam_codi", txtcodfamilia.Text + "0000") = True Then

            tabla = fnc.ListarTablasSQL("SELECT fam_descr FROM famprod " +
                                                         "WHERE fam_codi='" + txtcodfamilia.Text + "0000'")
            If tabla.Rows.Count > 0 Then
                txtdescrfam.Text = tabla.Rows(0)(0).ToString()
                txtcodfamilia.Enabled = False
                txtcorrelativo.Focus()
                txtcorrelativo.Text = ""
                LimpiarCajas(GroupBox3)
                LimpiarCajasMaskedTextBox(GroupBox3)
                txtcorrelativo.Enabled = True
                GroupBox3.Enabled = False
                txtcorrelativo.Focus()
                BtnProductos.Enabled = True
            End If

        Else
            txtdescrfam.Text = ""
            txtcodfamilia.SelectAll()
        End If
    End Sub

    Private Sub Frm_AddProductos_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        f_addproductos = False
        btn_limpiarp_Click(sender, e)
    End Sub

    Private Sub txtcodfamilia_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtcodfamilia.KeyDown
        If e.KeyCode = Keys.F1 Then
            Btn_BuscaFamilia_Click(sender, e)
        End If
        If e.KeyCode = Keys.Enter Then
            bskrFamilia()
        Else
        End If
    End Sub

    Private Sub Btn_BuscaFamilia_Click(sender As System.Object, e As System.EventArgs) Handles Btn_BuscaFamilia.Click

        Dim frm As New Lst_AyudaFamilias
        frm.txtbusca.Focus()
        frm.ShowDialog(Frm_Principal)

        If Len(Frm_Principal.buscavalor.ToString()) >= 3 Then

            txtcodfamilia.Text = Frm_Principal.buscavalor.ToString()

            Dim tabla As DataTable = fnc.ListarTablasSQL("SELECT fam_descr FROM famprod " +
                                                         "WHERE fam_codi='" + Frm_Principal.buscavalor.ToString() + "0000'")

            If tabla.Rows.Count > 0 Then
                txtdescrfam.Text = tabla.Rows(0)(0)
                Frm_Principal.buscavalor = ""
                txtcodfamilia.Enabled = False
                txtcorrelativo.Focus()

                txtcorrelativo.Text = ""
                LimpiarCajas(GroupBox3)
                LimpiarCajasMaskedTextBox(GroupBox3)
                txtcorrelativo.Enabled = True
                GroupBox3.Enabled = False
                txtcorrelativo.Focus()
                BtnProductos.Enabled = True
            Else

            End If
        End If

    End Sub

    Private Sub Btn_BuscaEnvase_Click(sender As System.Object, e As System.EventArgs) Handles Btn_BuscaEnvase.Click
        Dim frm As New Lst_AyudaEnvases
        frm.txtbusca.Focus()
        frm.ShowDialog(Me)

        If Len(Frm_Principal.buscavalor.ToString()) >= 3 Then

            txtcodenvase.Text = Frm_Principal.buscavalor.ToString()

            Dim tabla As DataTable = fnc.ListarTablasSQL("SELECT tenv_descr FROM tipoenv " +
                                                             "WHERE tenv_codi='" + Frm_Principal.buscavalor.ToString() + "'")

            If tabla.Rows.Count > 0 Then
                txtdescrenvase.Text = tabla.Rows(0)(0)
                txtcodenvase.Enabled = False
            End If
        End If

    End Sub

    Private Sub txtcodenvase_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtcodenvase.KeyDown
        If e.KeyCode = Keys.Enter Then

            Dim tabla As DataTable = fnc.ListarTablasSQL("SELECT tenv_descr FROM tipoenv " +
                                                             "WHERE tenv_codi='" + CerosAnteriorString(txtcodenvase.Text, 5) + "'")
            txtcodenvase.Text = CerosAnteriorString(txtcodenvase.Text, 5)
            If tabla.Rows.Count > 0 Then
                txtdescrenvase.Text = tabla.Rows(0)(0)
                txtcodenvase.Enabled = False
            Else
                txtdescrenvase.Text = ""
                txtcodenvase.Text = ""
                MsgBox("El codigo de envase ingresado no existe", MsgBoxStyle.Critical, "Aviso")
            End If

        ElseIf e.KeyCode = Keys.F1 Then
            Btn_BuscaEnvase_Click(sender, e)
        End If
    End Sub

    Private Sub Btn_BuscaCliente_Click(sender As System.Object, e As System.EventArgs) Handles Btn_BuscaCliente.Click
        Dim frm As New Lst_AyudaClientes
        frm.txtbusca.Focus()
        frm.ShowDialog(Me)

        If Len(clirut.Text) >= 9 Then
            clirut.Text = Frm_Principal.buscavalor.ToString()
            Dim SqlBusca As String = "SELECT cli_nomb FROM clientes WHERE " +
                "cli_rut='" + Frm_Principal.buscavalor.ToString() + "'"

            Dim tabla As DataTable = fnc.ListarTablasSQL(SqlBusca)

            If tabla.Rows.Count > 0 Then
                clinom.Text = tabla.Rows(0)(0)

            Else
                clinom.Text = ""
            End If
        Else
            clinom.Text = ""
        End If
        If clinom.Text = "CIAL ALIMENTOS S.A" Then
            Label12.Visible = True
            txtpcaja.Visible = True
            txtpcaja.Text = "0"
        Else
            Label12.Visible = False
            txtpcaja.Visible = False
            txtpcaja.Text = "0"
        End If
    End Sub

    Private Sub txtcorrelativo_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtcorrelativo.KeyDown
        If e.KeyCode = Keys.Enter Then
            ' buscar coorelativo
            If txtcorrelativo.Text = "" Then
                Dim valorAsignar As Integer = 1
                If RealizarAccion("011", "029") = False Then
                    Exit Sub
                End If
                While (True)
                    If fnc.verificaExistencia("maeprod", "mae_codi", txtcodfamilia.Text + CerosAnteriorString(valorAsignar, 4)) Then
                        valorAsignar += 1
                    Else
                        Exit While
                    End If

                End While

                txtcorrelativo.Text = valorAsignar.ToString()

                txtcodenvase.Enabled = True
                txtcorrelativo.Enabled = False
                GroupBox3.Enabled = True
                Btn_BuscaEnvase.Enabled = True
                Btn_BuscaCliente.Enabled = True
            Else

                If fnc.verificaExistencia("maeprod", "mae_codi", txtcodfamilia.Text + CerosAnteriorString(txtcorrelativo.Text, 4)) = True Then


                    Dim sql As String = "SELECT mae_descr, mae_tipenv, tenv_descr , mae_clirut, mae_estado, mae_codcli, isnull(mae_diasv,0) AS mae_diasv,sum_dias " +
                                        "FROM  tipoenv, maeprod WHERE  mae_tipenv=tenv_codi  AND " +
                                        "mae_codi='" + txtcodfamilia.Text + CerosAnteriorString(txtcorrelativo.Text, 4) + "'"


                    Dim tabla As DataTable = fnc.ListarTablasSQL(sql)
                    If tabla.Rows.Count > 0 Then
                        txtcorrelativo.Text = CerosAnteriorString(txtcorrelativo.Text, 3)
                        txtproddescr.Text = tabla.Rows(0)(0).ToString()
                        txtcodenvase.Text = tabla.Rows(0)(1).ToString()
                        txtdescrenvase.Text = tabla.Rows(0)(2).ToString()
                        clirut.Text = tabla.Rows(0)(3).ToString()
             



                        txtcodenvase.Enabled = False

                        If Convert.ToInt32(tabla.Rows(0)(4)) = 1 Then
                            checknulo.Checked = True
                        End If

                        TxtcodCli.Text = tabla.Rows(0)(5).ToString()

                        Dim Buscacliente As String = "SELECT cli_nomb FROM Clientes WHERE cli_rut='" + QuitarCaracteres(clirut.Text) + "'"

                        Dim tablacliente As DataTable = fnc.ListarTablasSQL(Buscacliente)

                        If tablacliente.Rows.Count > 0 Then
                            clinom.Text = tablacliente.Rows(0)(0).ToString()
                        Else
                            MsgBox("El cliente del producto seleccionado a sido eliminado", MsgBoxStyle.Critical, "Aviso")
                        End If
                        TxtMesVenc.Text = tabla.Rows(0)(6).ToString()
                        Txtdiasvenc.Text = tabla.Rows(0)(7).ToString()
                        If tabla.Rows(0)(7).ToString() = "" Then
                            Txtdiasvenc.Text = "0"
                        End If
                    End If
                End If

                txtcorrelativo.Enabled = False
                GroupBox3.Enabled = True

            End If
            TxtcodCli.Focus()
        End If
    End Sub

    Private Sub btn_limpiarp_Click(sender As System.Object, e As System.EventArgs) Handles btn_limpiarp.Click
        txtcodenvase.Enabled = True
        txtcodfamilia.Enabled = True
        txtcorrelativo.Enabled = True
        GroupBox3.Enabled = False
        LimpiarCajas(GroupBox1)
        LimpiarCajas(GroupBox2)
        LimpiarCajasMaskedTextBox(GroupBox3)
        txtcodfamilia.Focus()
        txtpcaja.Visible = False
        Label12.Visible = False
        txtpcaja.Text = "0"
        clirut.Text = ""
        BtnProductos.Enabled = False
    End Sub

    Private Sub txtcorrelativo_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtcorrelativo.KeyPress
        SoloNumeros(sender, e)
    End Sub

    Private Sub txtcodfamilia_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtcodfamilia.KeyPress
        SoloNumeros(sender, e)
    End Sub

    Private Sub txtcodenvase_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtcodenvase.KeyPress
        SoloNumeros(sender, e)
    End Sub

    Private Sub clirut_KeyUp(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles clirut.KeyUp
        If Len(QuitarCaracteres(clirut.Text)) >= 9 Then

            Dim SqlBusca As String = "SELECT cli_nomb FROM clientes WHERE " +
                    "cli_rut='" + QuitarCaracteres(clirut.Text) + "'"

            Dim tabla As DataTable = fnc.ListarTablasSQL(SqlBusca)

            If tabla.Rows.Count > 0 Then
                clinom.Text = tabla.Rows(0)(0)
            Else
                clinom.Text = ""
            End If

        Else
            clinom.Text = ""
        End If
    End Sub

    Private Sub clirut_Click(sender As System.Object, e As System.EventArgs) Handles clirut.Click
        clirut.SelectAll()
    End Sub

    Private Sub btn_guardarp_Click(sender As System.Object, e As System.EventArgs) Handles btn_guardarp.Click
        If CheckBox1.Checked = True Then
            provar = "SI"

        Else
            provar = "NO"
        End If
        If Txtdiasvenc.Text = "" Then
            Txtdiasvenc.Text = "0"

        End If
        If validacion() = True Then
            If fnc.verificaExistencia("maeprod", "mae_codi", txtcodfamilia.Text + CerosAnteriorString(txtcorrelativo.Text, 4)) = True Then
                'Modificar
                If RealizarAccion("011", "030") = False Then
                    Exit Sub
                End If
                If clinom.Text = "CIAL ALIMENTOS S.A" Then
                    If txtpcaja.Text.Trim = "" Then
                        MsgBox("ingrese peso caja/vacia", MsgBoxStyle.Critical, "Aviso")
                        Exit Sub
                    End If


                End If
                Dim sql = "UPDATE maeprod SET mae_descr='" + txtproddescr.Text + "', mae_tipenv='" + txtcodenvase.Text + "', " +
                          "mae_clirut='" + QuitarCaracteres(clirut.Text) + "', " +
                          "mae_estado='" + (Convert.ToInt32(checknulo.CheckState)).ToString() + "', mae_codcli='" + TxtcodCli.Text + "', mae_diasv='" + TxtMesVenc.Text + "' , sum_dias='" + Txtdiasvenc.Text + "',mae_pcaja='" + txtpcaja.Text + "', alt_pro='" + txtaltura.Text.Trim() + "', anch_pro ='" + txtancho.Text.Trim() + "', prof_pro='" + txtprofundidad.Text.Trim() + "',peso_pro='" + txtpeso.Text.Trim() + "',talla_pro='" + txttalla.Text.Trim() + "',color_pro='" + cmbColor1.Text.Trim() + "',pro_var='" + provar + "'" +
                          "WHERE mae_codi='" + (txtcodfamilia.Text + CerosAnteriorString(txtcorrelativo.Text, 4)) + "'"


                If fnc.MovimientoSQL(sql) > 0 Then
                    Insert(txtcodfamilia.Text + CerosAnteriorString(txtcorrelativo.Text, 4), ImageToByteArray(PictureBox1.Image))

                    'Inicio Actualizar Fechas Productos Almacenados. 04/10/19 HAmestica.
                    Dim sqlActProd As String = "SP_Maeprod_Actualizar_Vencimientos_Productos '" & (txtcodfamilia.Text + CerosAnteriorString(txtcorrelativo.Text, 4)) & "'"
                    fnc.MovimientoSQL(sqlActProd)
                    'Fin Actualizar Fechas Productos Almacenados. 04/10/19 HAmestica.

                    MsgBox("Producto modificado correctamente", MsgBoxStyle.Information, "Aviso")
                    GrabaLOG(1)
                Else
                    MsgBox("Error al modificar el producto seleccionado", MsgBoxStyle.Critical, "Aviso")
                End If

            Else
                'Guardar
                If clinom.Text = "CIAL ALIMENTOS S.A" Then
                    If txtpcaja.Text.Trim = "" Then
                        MsgBox("ingrese peso caja/vacia", MsgBoxStyle.Critical, "Aviso")
                        Exit Sub
                    End If
                End If

                Dim sql = "INSERT INTO maeprod(mae_codi, mae_descr, mae_tipenv, mae_clirut, mae_feccre, mae_estado, mae_codcli, mae_diasv,mae_pcaja,alt_pro,anch_pro,prof_pro,peso_pro,talla_pro,color_pro,pro_var,sum_dias) " +
                          "VALUES('" + (txtcodfamilia.Text + CerosAnteriorString(txtcorrelativo.Text, 4)) + "', " +
                          "'" + txtproddescr.Text + "','" + txtcodenvase.Text + "','" + QuitarCaracteres(clirut.Text) + "', " +
                          "'" + devuelve_fecha(Date.Now).ToString() + "','" + (Convert.ToInt32(checknulo.CheckState)).ToString() + "','" + TxtcodCli.Text + "','" + TxtMesVenc.Text + "','" + txtpcaja.Text + "','" + txtaltura.Text.Trim() + "','" + txtancho.Text.Trim() + "','" + txtprofundidad.Text.Trim() + "','" + txtpeso.Text.Trim() + "','" + txttalla.Text.Trim() + "','" + cmbColor1.Text.Trim() + "','" + provar + "','" + Txtdiasvenc.Text + "')"

                If fnc.MovimientoSQL(sql) > 0 Then
                    Insert(txtcodfamilia.Text + CerosAnteriorString(txtcorrelativo.Text, 4), ImageToByteArray(PictureBox1.Image))

                    'Inicio Actualizar Fechas Productos Almacenados. 04/10/19 HAmestica.
                    Dim sqlActProd As String = "SP_Maeprod_Actualizar_Vencimientos_Productos '" & (txtcodfamilia.Text + CerosAnteriorString(txtcorrelativo.Text, 4)) & "'"
                    fnc.MovimientoSQL(sqlActProd)
                    'Fin Actualizar Fechas Productos Almacenados. 04/10/19 HAmestica.

                    MsgBox("Producto agregado correctamente", MsgBoxStyle.Information, "Aviso")

                    GrabaLOG(2)
                Else
                    MsgBox("Error al agregar el producto seleccionado", MsgBoxStyle.Critical, "Aviso")
                End If

            End If
        End If

    End Sub

    Private Sub btn_salirp_Click(sender As System.Object, e As System.EventArgs) Handles btn_salirp.Click
        Close()
    End Sub

    Private Sub btn_eliminarp_Click(sender As System.Object, e As System.EventArgs) Handles btn_eliminarp.Click
        If MsgBox("Esta seguro de eliminar la información seleccionada", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbYes Then
            If MsgBox("Esta por eliminar la información, desea continuar?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbYes Then

                Dim sql = "DELETE FROM maeprod WHERE mae_codi='" + txtcodfamilia.Text + CerosAnteriorString(txtcorrelativo.Text, 4) + "'"

                If fnc.MovimientoSQL(sql) > 0 Then
                    MsgBox("Registro eliminado", MsgBoxStyle.Information, "Aviso")
                End If
            End If
        End If
    End Sub

    Private Sub clirut_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles clirut.KeyDown
        If e.KeyCode = Keys.F1 Then
            Btn_BuscaCliente_Click(sender, e)
        End If
    End Sub

    Private Sub checknulo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles checknulo.CheckedChanged
        If checknulo.CheckState = CheckState.Checked Then
            If RealizarAccion("011", "032") = False Then
                checknulo.CheckState = CheckState.Unchecked
            End If
        End If

    End Sub

    Private Sub BtnProductos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnProductos.Click
        Dim f As New Lst_AyudaProductosFamilia
        f.tipo_producto = txtcodfamilia.Text
        f.ShowDialog(Frm_Principal)

        If Frm_Principal.buscavalor <> "" Then
            txtcorrelativo.Text = Frm_Principal.buscavalor.ToString()
            Dim sql As String = "SELECT mae_descr, mae_tipenv, tenv_descr , mae_clirut, mae_estado, mae_codcli,  isnull(mae_diasv,0) AS mae_diasv ,mae_pcaja,alt_pro,anch_pro,prof_pro,peso_pro,talla_pro,color_pro,pro_var,sum_dias  " +
                    "FROM  tipoenv, maeprod WHERE  mae_tipenv=tenv_codi  AND " +
                    "mae_codi='" + txtcodfamilia.Text + CerosAnteriorString(txtcorrelativo.Text, 4) + "'"


            Dim tabla As DataTable = fnc.ListarTablasSQL(sql)
            If tabla.Rows.Count > 0 Then

                txtproddescr.Text = tabla.Rows(0)(0).ToString()
                txtcodenvase.Text = tabla.Rows(0)(1).ToString()
                txtdescrenvase.Text = tabla.Rows(0)(2).ToString()
                clirut.Text = tabla.Rows(0)(3).ToString()
                txtaltura.Text = tabla.Rows(0)(8).ToString()
                txtancho.Text = tabla.Rows(0)(9).ToString()
                txtprofundidad.Text = tabla.Rows(0)(10).ToString()
                txtpeso.Text = tabla.Rows(0)(11).ToString()
                txttalla.Text = tabla.Rows(0)(12).ToString()
                Txtdiasvenc.Text = tabla.Rows(0)(15).ToString()
                If tabla.Rows(0)(15).ToString() = "" Then
                    Txtdiasvenc.Text = "0"
                End If
                Dim color As String = tabla.Rows(0)(13).ToString()

                If tabla.Rows(0)(14).ToString().Trim() = "SI" Then

                    CheckBox1.Checked = True
                Else
                    CheckBox1.Checked = False
                End If

                Dim strString As String = ""

                For i As Integer = 0 To cmbColor1.Items.Count - 1
                    'cmbColor1.SelectedIndex = i

                    cmbColor1.SelectedIndex = i
                    strString = cmbColor1.Text

                    If color = strString Then
                        cmbColor1.SelectedIndex = i
                        Exit For
                    End If


                Next
                cargaimg()

                txtcodenvase.Enabled = False
                txtcorrelativo.Enabled = False
                txtproddescr.Enabled = True
                Btn_BuscaEnvase.Enabled = False
                Btn_BuscaCliente.Enabled = False
                clirut.Enabled = False
                GroupBox3.Enabled = True
                If Convert.ToInt32(tabla.Rows(0)(4).ToString()) = 1 Then
                    checknulo.Checked = True
                End If

                TxtcodCli.Text = tabla.Rows(0)(5).ToString()

                Dim Buscacliente As String = "SELECT cli_nomb FROM Clientes WHERE cli_rut='" + QuitarCaracteres(clirut.Text) + "'"

                Dim tablacliente As DataTable = fnc.ListarTablasSQL(Buscacliente)

                If tablacliente.Rows.Count > 0 Then
                    clinom.Text = tablacliente.Rows(0)(0).ToString()

                Else
                    MsgBox("El cliente del producto seleccionado a sido eliminado", MsgBoxStyle.Critical, "Aviso")
                End If

                TxtMesVenc.Text = tabla.Rows(0)(6).ToString()
                txtpcaja.Text = tabla.Rows(0)(7).ToString()
                If clinom.Text = "CIAL ALIMENTOS S.A" Then
                    Label12.Visible = True
                    txtpcaja.Visible = True

                Else
                    Label12.Visible = False
                    txtpcaja.Visible = False
                    txtpcaja.Text = "0"
                End If
            End If
        End If
    End Sub

    Public Sub GrabaLOG(ByVal cod)

        '1 log ingreso
        '2 log actualizacion

        If cod = 1 Then
            'LOG MODIFICO RECEPCION *************************************************************************************
            Dim _log As String = "INSERT INTO LOG_MAEPROD(LMP_CODI, LMP_FECHA, LMP_HORA, LMP_USUARIO, LMP_PC, LMP_OPERACION)" +
                "VALUES('" + txtcodfamilia.Text + CerosAnteriorString(txtcorrelativo.Text, 4) + "','" + devuelve_fecha(fnc.DevuelveFechaServidor()) + "'," +
                "'" + DevuelveHora() + "','" + Frm_Principal.InfoUsuario.Text + "','" + My.Computer.Name.ToString() + "','INGRESO')"
            fnc.MovimientoSQL(_log)
            'LOG MODIFICO RECEPCION *************************************************************************************
        ElseIf cod = 2 Then
            'LOG MODIFICO RECEPCION *************************************************************************************
            Dim _log As String = "INSERT INTO LOG_MAEPROD(LMP_CODI, LMP_FECHA, LMP_HORA, LMP_USUARIO, LMP_PC, LMP_OPERACION)" +
                "VALUES('" + txtcodfamilia.Text + CerosAnteriorString(txtcorrelativo.Text, 4) + "','" + devuelve_fecha(fnc.DevuelveFechaServidor()) + "'," +
                "'" + DevuelveHora() + "','" + Frm_Principal.InfoUsuario.Text + "','" + My.Computer.Name.ToString() + "','ACTUALIZACION')"
            fnc.MovimientoSQL(_log)
            'LOG MODIFICO RECEPCION *************************************************************************************
        End If




    End Sub

    Private Sub TxtMesVenc_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMesVenc.KeyPress
        SoloNumeros(sender, e)
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
        PictureBox1.Load(IMAGEN)
    End Sub
    Public Function ImageToByteArray(ByVal imageIn As Image) As Byte()
        Dim ms As New MemoryStream()
        imageIn.Save(ms, ImageFormat.Jpeg)
        Return ms.ToArray()
    End Function
    Public Sub Insert(ByVal codigo As String, ByVal foto As Byte())
        Dim sql9 = "delete from maeproimg where id='" + (txtcodfamilia.Text + CerosAnteriorString(txtcorrelativo.Text, 4)) + "'"
        fnc.MovimientoSQL(sql9)
        Dim con As New SqlConnection

        Dim query As String = "INSERT INTO maeproimg(id,foto) VALUES(@codigo,@foto)"
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


    Private Sub cargaimg()

        Dim sqlImagen As String = "SELECT foto from maeproimg where id= '" + (txtcodfamilia.Text + CerosAnteriorString(txtcorrelativo.Text, 4)) + "'"

        Dim tablaimagen As DataTable = fnc.ListarTablasSQL(sqlImagen)

        If tablaimagen.Rows.Count > 0 Then

            'Imagen1
            If tablaimagen.Rows(0)(0).ToString() <> "" Then
                'PictureBox1.Image = Base64ToImage(tablaimagen.Rows(0)(0))
                PictureBox1.Image = ByteArrayToImage(DirectCast(tablaimagen.Rows(0)(0), Byte()))

            Else
                ' PictureBox1.Image = Nothing
            End If
        Else

            '  PictureBox1.Image = Nothing
        End If

    End Sub
    Public Function ByteArrayToImage(ByVal byteArrayIn As Byte()) As Image
        Dim ms As New MemoryStream(byteArrayIn)
        Return Image.FromStream(ms)
    End Function
    Private Sub Frm_AddProductos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Frm_Principal.buscavalor = ""

        'PictureBox1.Visible = False
        'txtpcaja.Text = "0"
        'Label1.Parent = PictureBox1
        'Label2.Parent = PictureBox1
        'Label3.Parent = PictureBox1
        'Label4.Parent = PictureBox1
        'Label5.Parent = PictureBox1
        'Label6.Parent = PictureBox1
        'Label7.Parent = PictureBox1
        'Label8.Parent = PictureBox1
        'BtnProductos.Parent = PictureBox1
        'Label11.Parent = PictureBox1
        'Label12.Parent = PictureBox1
        'checknulo.Parent = PictureBox1
        'TxtcodCli.Parent = PictureBox1
        'txtcodenvase.Parent = PictureBox1
        'txtdescrenvase.Parent = PictureBox1
        'clirut.Parent = PictureBox1
        'clinom.Parent = PictureBox1
        'btn_guardarp.Parent = PictureBox1
        'Btn_BuscaEnvase.Parent = PictureBox1
        'btn_limpiarp.Parent = PictureBox1
        'txtproddescr.Parent = PictureBox1
        'btn_eliminarp.Parent = PictureBox1
        'btn_salirp.Parent = PictureBox1
        'Btn_BuscaCliente.Parent = PictureBox1
        'txtcodfamilia.Parent = PictureBox1
        'btn_guardarp.BackColor = Color.Transparent
        'For Each c As Control In Me.Controls
        '    If TypeOf c Is TextBox Then
        '        c.Parent = PictureBox1
        '    End If
        'Next
        'For Each d As Control In Me.Controls
        '    If TypeOf d Is Button Then
        '        d.Parent = PictureBox1
        '    End If
        'Next
        'PictureBox1.Visible = True
        cmbColor1.Items.Add(Color.Black)
        cmbColor1.Items.Add(Color.Blue)
        cmbColor1.Items.Add(Color.Red)
        cmbColor1.Items.Add(Color.White)
        cmbColor1.Items.Add(Color.Pink)
        cmbColor1.Items.Add(Color.Green)
        cmbColor1.Items.Add(Color.Yellow)
        cmbColor1.Items.Add(Color.Orange)
    End Sub


    Private Sub txtpcaja_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtpcaja.KeyPress
        e.Handled = True
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar = "," And Not txtpcaja.Text.IndexOf(",") Then
            e.Handled = True
        ElseIf e.KeyChar = "," Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub


    Private Sub PictureBox2_Click(sender As System.Object, e As System.EventArgs) Handles btn_guardarp.Click
        If validacion() = True Then
            If fnc.verificaExistencia("maeprod", "mae_codi", txtcodfamilia.Text + CerosAnteriorString(txtcorrelativo.Text, 4)) = True Then
                'Modificar
                If RealizarAccion("011", "030") = False Then
                    Exit Sub
                End If
                If clinom.Text = "CIAL ALIMENTOS S.A" Then
                    If txtpcaja.Text.Trim = "" Then
                        MsgBox("ingrese peso caja/vacia", MsgBoxStyle.Critical, "Aviso")
                        Exit Sub
                    End If


                End If
                Dim sql = "UPDATE maeprod SET mae_descr='" + txtproddescr.Text + "', mae_tipenv='" + txtcodenvase.Text + "', " +
                          "mae_clirut='" + QuitarCaracteres(clirut.Text) + "', " +
                          "mae_estado='" + (Convert.ToInt32(checknulo.CheckState)).ToString() + "', mae_codcli='" + TxtcodCli.Text + "', mae_diasv='" + TxtMesVenc.Text + "' , mae_pcaja='" + txtpcaja.Text + "'" +
                          "WHERE mae_codi='" + (txtcodfamilia.Text + CerosAnteriorString(txtcorrelativo.Text, 4)) + "'"


                If fnc.MovimientoSQL(sql) > 0 Then
                    MsgBox("Producto modificado correctamente", MsgBoxStyle.Information, "Aviso")
                    GrabaLOG(1)
                Else
                    MsgBox("Error al modificar el producto seleccionado", MsgBoxStyle.Critical, "Aviso")
                End If

            Else
                'Guardar
                If clinom.Text = "CIAL ALIMENTOS S.A" Then
                    If txtpcaja.Text.Trim = "" Then
                        MsgBox("ingrese peso caja/vacia", MsgBoxStyle.Critical, "Aviso")
                        Exit Sub
                    End If


                End If
                Dim sql = "INSERT INTO maeprod(mae_codi, mae_descr, mae_tipenv, mae_clirut, mae_feccre, mae_estado, mae_codcli, mae_diasv,mae_pcaja) " +
                          "VALUES('" + (txtcodfamilia.Text + CerosAnteriorString(txtcorrelativo.Text, 4)) + "', " +
                          "'" + txtproddescr.Text + "','" + txtcodenvase.Text + "','" + QuitarCaracteres(clirut.Text) + "', " +
                          "'" + devuelve_fecha(Date.Now).ToString() + "','" + (Convert.ToInt32(checknulo.CheckState)).ToString() + "','" + TxtcodCli.Text + "','" + TxtMesVenc.Text + "','" + txtpcaja.Text + "')"

                If fnc.MovimientoSQL(sql) > 0 Then
                    MsgBox("Producto agregado correctamente", MsgBoxStyle.Information, "Aviso")
                    GrabaLOG(2)
                Else
                    MsgBox("Error al agregar el producto seleccionado", MsgBoxStyle.Critical, "Aviso")
                End If

            End If
        End If
    End Sub

    Private Sub PictureBox2_Click_1(sender As System.Object, e As System.EventArgs) Handles btn_limpiarp.Click
        txtcodenvase.Enabled = True
        txtcodfamilia.Enabled = True
        txtcorrelativo.Enabled = True
        GroupBox3.Enabled = False
        'LimpiarCajas(GroupBox1)
        LimpiarCajas(GroupBox3)
        LimpiarCajasMaskedTextBox(GroupBox3)
        txtcodfamilia.Focus()
        txtpcaja.Visible = False
        Label12.Visible = False
        txtpcaja.Text = "0"
        BtnProductos.Enabled = False
    End Sub

    Private Sub btn_eliminarpp_Click(sender As System.Object, e As System.EventArgs) Handles btn_eliminarp.Click
        If MsgBox("Esta seguro de eliminar la información seleccionada", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbYes Then
            If MsgBox("Esta por eliminar la información, desea continuar?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbYes Then

                Dim sql = "DELETE FROM maeprod WHERE mae_codi='" + txtcodfamilia.Text + CerosAnteriorString(txtcorrelativo.Text, 4) + "'"

                If fnc.MovimientoSQL(sql) > 0 Then
                    MsgBox("Registro eliminado", MsgBoxStyle.Information, "Aviso")
                End If
            End If
        End If
    End Sub

    Private Sub btn_salirpp_Click(sender As System.Object, e As System.EventArgs) Handles btn_salirp.Click
        Close()
    End Sub

    Private Sub Label9_Click(sender As System.Object, e As System.EventArgs) Handles Label9.Click

    End Sub

    Private Sub TextBox1_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtaltura.KeyPress
        SoloKilos(sender, e)
    End Sub

    Private Sub TextBox2_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtancho.TextChanged

    End Sub

    Private Sub TextBox2_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtancho.KeyPress
        SoloKilos(sender, e)
    End Sub

    Private Sub TextBox3_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtprofundidad.KeyPress
        SoloKilos(sender, e)
    End Sub

    Private Sub TextBox4_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtpeso.KeyPress
        SoloKilos(sender, e)
    End Sub

    Private Sub ComboBox1_DrawItem(sender As System.Object, e As System.Windows.Forms.DrawItemEventArgs) Handles cmbColor1.DrawItem
        Dim cmb As ComboBox = TryCast(sender, ComboBox)
        If cmb Is Nothing Then
            Return
        End If
        If e.Index < 0 Then
            Return
        End If
        If Not (TypeOf cmb.Items(e.Index) Is Color) Then
            Return
        End If
        Dim color As Color = DirectCast(cmb.Items(e.Index), Color)

        Dim brush As Brush = New SolidBrush(color)
        e.Graphics.DrawRectangle(Pens.Black, New Rectangle(e.Bounds.Left + 2, e.Bounds.Top + 2, 19, e.Bounds.Size.Height - 4))
        e.Graphics.FillRectangle(brush, New Rectangle(e.Bounds.Left + 3, e.Bounds.Top + 3, 18, e.Bounds.Size.Height - 5))
        e.Graphics.DrawString(color.Name, cmb.Font, Brushes.Black, e.Bounds.Left + 25, e.Bounds.Top + 2)
        brush.Dispose()


    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        cargarImagen()
    End Sub

    Private Sub Txtdiasvenc_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles Txtdiasvenc.KeyPress
        SoloNumeros(sender, e)
    End Sub

    Private Sub btn_nuevo_Click(sender As System.Object, e As System.EventArgs) Handles btn_nuevo.Click

    End Sub

    Private Sub btn_eliminar_Click(sender As System.Object, e As System.EventArgs) Handles btn_eliminar.Click

    End Sub
End Class
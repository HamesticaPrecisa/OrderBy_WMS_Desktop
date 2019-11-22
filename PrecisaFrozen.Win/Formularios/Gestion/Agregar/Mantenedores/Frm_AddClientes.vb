Imports System.Drawing.Imaging
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration

Public Class Frm_AddClientes
    Dim fnc As New Funciones
    Dim fechasug As String = ""
    Public RutCliente As String = ""
    Public CHEC As String = ""
    Public contro As String = ""
    Dim IMAGEN As String
    'Public comboRegion As String = ""

    Sub LlenarCombo()

        cmbo_region.DataSource = fnc.ListarTablasSQL("SELECT ciu_codi, ciu_descr FROM ciudad")
        cmbo_region.DisplayMember = "ciu_descr"
        cmbo_region.ValueMember = "ciu_codi"

        cblist.DataSource = fnc.ListarTablasSQL("SELECT tcli_codi, tcli_desc FROM P_TipoClientes")
        cblist.DisplayMember = "tcli_desc"
        cblist.ValueMember = "tcli_codi"

    End Sub

    Function validarEntrada()
        Dim valor = 0
        If RutDigito(txtrut.Text) = False Then
            valor += 1
            MsgBox("El Rut ingresado no es correcto", MsgBoxStyle.Critical, "Aviso")
            Return valor
            Exit Function
        ElseIf txtrut.Text = "" Then
            valor += 1
            MsgBox("El Rut ingresado no es correcto", MsgBoxStyle.Critical, "Aviso")
            Return valor
            Exit Function
        ElseIf txtrsocial.Text = "" Then
            MsgBox("Debe ingresar razón social del cliente", MsgBoxStyle.Critical, "Aviso")
            valor += 1
            Return valor
            Exit Function
        ElseIf txtdireccion.Text = "" Then
            MsgBox("Debe ingresar dirección", MsgBoxStyle.Critical, "Aviso")
            valor += 1
            Return valor
            Exit Function
        ElseIf txtcomuna.Text = "" Then
            MsgBox("Debe ingresar comuna", MsgBoxStyle.Critical, "Aviso")
            valor += 1
            Return valor
            Exit Function
        ElseIf cmbo_estado.SelectedItem = "" Then
            MsgBox("Debe seleccionar estado", MsgBoxStyle.Critical, "Aviso")
            valor += 1
            Return valor
            Exit Function
        End If
 
        Return valor
    End Function

    Private Sub Frm_AddClientes_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        f_addclientes = False
        btn_nuevo_Click(sender, e)
    End Sub

    Private Sub Frm_AddClientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        hrs_homogenizacion.Text = "120"
        LlenarCombo()
        contro = "0"
        rdnofecha.Checked = True
        BUSCA_CLIENTE("0")
        txtHrsCongCam.Text = "504"
    End Sub

    Function Retornarestado(ByVal estado As String) As String
        Dim retorno As String = ""

        If estado.Length < 2 Then
            If estado = "N" Then
                retorno = "NULO"
            ElseIf estado = "A" Then
                retorno = "ACTIVO"
            End If
        Else
            If estado = "NULO" Then
                retorno = "N"
            ElseIf estado = "ACTIVO" Then
                retorno = "A"
            End If
        End If


        Return retorno
    End Function


    Private Sub btn_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Nuevo.Click
        LimpiarCajas(GroupBox3)
        txtrut.Enabled = True
        Btn_Guardar.Enabled = False
        GroupBox3.Enabled = False
        txtrut.Text = ""
        txtrut.Focus()
        chk_bloq.Checked = False
        _em1.Text = ""
        _em2.Text = ""
        _em3.Text = ""
        _em4.Text = ""
        CHEC = "0"
        hrs_homogenizacion.Text = "0"
        txtHrsCongCam.Text = "504"
        CheckBox2.Checked = False
        rdnofecha.Checked = True
        _vem1 = -1
        _vem2 = -1
        _vem3 = -1
        _vem4 = -1
        _vem5 = -1


        While (dgvpedweb.Rows.Count > 0)
            dgvpedweb.Rows.RemoveAt(0)
        End While

        While (dgvpedidos.Rows.Count > 0)
            dgvpedidos.Rows.RemoveAt(0)
        End While

        While (dgvryd.Rows.Count > 0)
            dgvryd.Rows.RemoveAt(0)
        End While

        While (dgvvenc.Rows.Count > 0)
            dgvvenc.Rows.RemoveAt(0)
        End While

        While (DgvContactos.Rows.Count > 0)
            DgvContactos.Rows.RemoveAt(0)
        End While


        For i As Integer = 0 To cblist.Items.Count - 1
            cblist.SetItemChecked(i, False)
        Next

        chkTag.Checked = False

        chkVentaDirectaPallet.Checked = False
    End Sub
    Private Sub LOGBLOQUEO()
        Dim rut As String = QuitarCaracteres(txtrut.Text)
        Dim MOV As String = ""

        If chk_bloq.Checked = True Then
            MOV = "BLOQUEO"
        End If
        If chk_bloq.Checked = False Then
            MOV = "DESBLOQUEO"
        End If


        Dim _log As String = "INSERT INTO LOG_BLOQ_WEB(LT_CLI,LT_MOV, LT_FECHA, LT_HORA, LT_USUARIO, LT_PC)" +
                         "VALUES('" + rut + "','" + MOV + "','" + devuelve_fecha(fnc.DevuelveFechaServidor()) + "'," +
                         "'" + DevuelveHora() + "','" + Frm_Principal.InfoUsuario.Text + "','" + My.Computer.Name.ToString() + "')"
        fnc.MovimientoSQL(_log)


    End Sub
    Public Function ImageToByteArray(ByVal imageIn As Image) As Byte()
        Dim ms As New MemoryStream()
        imageIn.Save(ms, ImageFormat.Jpeg)
        Return ms.ToArray()
    End Function
    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Guardar.Click
   

        If rdsifecha.Checked = True Then
            fechasug = "SI"

        Else
            fechasug = "NO"
        End If
        If QuitarCaracteres(txtrut.Text).Length >= 9 Then
            If fnc.verificaExistencia("Clientes", "cli_rut", QuitarCaracteres(txtrut.Text)) = False Then
                GuardarCliente()
                bloquearweb()
                bloquearGes()
                bloquearSTOCK0()
                If CHEC = "1" Then
                    LOGBLOQUEO()
                End If


            Else
                ModificaCliente()
                '   guardaimg()
                Insert(QuitarCaracteres(txtrut.Text), ImageToByteArray(PictureBox1.Image))
                bloquearweb()
                bloquearGes()
                bloquearSTOCK0()
                If CHEC = "1" Then
                    LOGBLOQUEO()
                End If
            End If
            'Grabar parametrización Horas Congelado Camara
            Dim hraCon = txtHrsCongCam.Text.Trim
            Dim hraConValid As Integer = 0

            If (Integer.TryParse(hraCon, hraConValid) = False) Then
                MessageBox.Show("No se registró parametro horas congelado cámara. Ingresar valor valido", "Info!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtHrsCongCam.Text = 0
            Else
                Dim sql = "SP_Clientes_Congelado_Camara_Grabar '" & QuitarCaracteres(txtrut.Text) & "','" & hraCon & "'"
                If (fnc.MovimientoSQL(sql) <> 1) Then
                    MessageBox.Show("No se registró parametro horas congelado cámara. Volver a intentar.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtHrsCongCam.Text = 0
                End If
            End If

            'Grabar parametrización de TAG RFID
            grabarConfRFID()
        End If

    End Sub

    Sub grabarConfRFID()
        Try
            Dim Rut As String = QuitarCaracteres(txtrut.Text.Trim)
            Dim UsaTag As Integer = 0
            If (chkTag.Checked) Then
                UsaTag = 1
            End If

            Dim tabla As String = "Clientes_TAGs"
            Dim condicion As String = "Rut_Cliente='" & Rut & "'"

            Dim sql As String = ""

            If (fnc.verificaExistenciaCondicional(tabla, condicion)) Then
                sql = "update Clientes_TAGs set Estado='" & UsaTag & "' where Rut_Cliente='" & Rut & "'"
            Else
                sql = "insert into Clientes_TAGs(Rut_Cliente,Estado) values('" & Rut & "','" & UsaTag & "')"
            End If

            If (fnc.MovimientoSQL(sql) = 0) Then
                MessageBox.Show("Ocurrió un error al grabar el parametro TAG RFID, vuelva a intentar.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Ocurrió un error al grabar el parametro TAG RFID, vuelva a intentar.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtrut_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtrut.Click
        txtrut.SelectAll()
    End Sub
    Sub bloquearweb()
        Dim rut As String = QuitarCaracteres(txtrut.Text)
        If chk_bloq.Checked = True Then

            Dim sql As String = "UPDATE clientes SET cli_blockweb ='1' WHERE cli_rut='" + rut + "'"
            fnc.MovimientoSQL(sql)
        Else
            Dim sql As String = "UPDATE clientes SET cli_blockweb ='0' WHERE cli_rut='" + rut + "'"
            fnc.MovimientoSQL(sql)
        End If


    End Sub
    Sub bloquearSTOCK0()
        Dim rut As String = QuitarCaracteres(txtrut.Text)
        If CheckBox3.Checked = True Then

            Dim sql As String = "UPDATE clientes SET cli_stock0 ='1' WHERE cli_rut='" + rut + "'"
            fnc.MovimientoSQL(sql)
        Else
            Dim sql As String = "UPDATE clientes SET cli_stock0 ='0' WHERE cli_rut='" + rut + "'"
            fnc.MovimientoSQL(sql)
        End If


    End Sub

    Sub bloquearGes()
        Dim rut As String = QuitarCaracteres(txtrut.Text)
        If CheckBox2.Checked = True Then

            Dim sql As String = "UPDATE clientes SET cli_blockges ='1' WHERE cli_rut='" + rut + "'"
            fnc.MovimientoSQL(sql)
        Else
            Dim sql As String = "UPDATE clientes SET cli_blockges ='0' WHERE cli_rut='" + rut + "'"
            fnc.MovimientoSQL(sql)
        End If


    End Sub

    Private Sub guardaenvmail1()
        Dim sqlGuardars As String = ""
        Dim codigoInforme As String = "0"
        Dim Lu, Ma, Mi, Ju, Vi, Sa, Dom, hora As String
        Lu = "no"
        Ma = "no"
        Mi = "no"
        Ju = "no"
        Sa = "no"
        Vi = "no"
        Dom = "no"
        hora = "1"
        Dim CHEC As String = ""
        Dim estado As String
        estado = "Activado"

        codigoInforme = "1"

        Dim rutc As String = QuitarCaracteres(txtrut.Text)
        sqlGuardars = " INSERT INTO informes_programa " +
           "(prg_rut_cli, prg_inf_cod, prg_emp, prg_hora, prg_mail, prg_lunes, prg_martes, prg_miercoles, prg_jueves, prg_viernes, prg_sabado, prg_domingo, prg_estado, prg_min) " +
           " VALUES ('" + rutc + "','" + codigoInforme + "','0','" + hora + "','','" + Lu + "','" + Ma + "','" + Mi + "','" + Ju + "','" + Vi + "','" + Sa + "','" + Dom + "','" + estado + "','')"
        If fnc.MovimientoSQL(sqlGuardars) > 0 Then
            'MsgBox("Registro Guardado Correctamente")
        End If

    End Sub
    Private Sub guardaenvmail7()
        Dim sqlGuardard As String = ""
        Dim codigoInforme As String = "0"
        Dim Lu, Ma, Mi, Ju, Vi, Sa, Dom, hora As String
        Lu = "no"
        Ma = "no"
        Mi = "no"
        Ju = "no"
        Sa = "no"
        Vi = "no"
        Dom = "no"
        hora = "1"
        Dim CHEC As String = ""
        Dim estado As String
        estado = "Activado"

        codigoInforme = "7"

        Dim rutc As String = QuitarCaracteres(txtrut.Text)
        sqlGuardard = " INSERT INTO informes_programa " +
           "(prg_rut_cli, prg_inf_cod, prg_emp, prg_hora, prg_mail, prg_lunes, prg_martes, prg_miercoles, prg_jueves, prg_viernes, prg_sabado, prg_domingo, prg_estado, prg_min) " +
           " VALUES ('" + rutc + "','" + codigoInforme + "','0','" + hora + "','','" + Lu + "','" + Ma + "','" + Mi + "','" + Ju + "','" + Vi + "','" + Sa + "','" + Dom + "','" + estado + "','')"
        If fnc.MovimientoSQL(sqlGuardard) > 0 Then
            ' MsgBox("Registro Guardado Correctamente")
        End If

    End Sub
    Private Sub guardaenvmail5()
        Dim sqlGuardarf As String = ""
        Dim codigoInforme As String = "0"
        Dim Lu, Ma, Mi, Ju, Vi, Sa, Dom, hora As String
        Lu = "no"
        Ma = "no"
        Mi = "no"
        Ju = "no"
        Sa = "no"
        Vi = "no"
        Dom = "no"
        hora = "1"
        Dim CHEC As String = ""
        Dim estado As String
        estado = "Activado"

        codigoInforme = "5"

        Dim rutc As String = QuitarCaracteres(txtrut.Text)
        sqlGuardarf = " INSERT INTO informes_programa " +
           "(prg_rut_cli, prg_inf_cod, prg_emp, prg_hora, prg_mail, prg_lunes, prg_martes, prg_miercoles, prg_jueves, prg_viernes, prg_sabado, prg_domingo, prg_estado, prg_min) " +
           " VALUES ('" + rutc + "','" + codigoInforme + "','0','" + hora + "','','" + Lu + "','" + Ma + "','" + Mi + "','" + Ju + "','" + Vi + "','" + Sa + "','" + Dom + "','" + estado + "','')"
        If fnc.MovimientoSQL(sqlGuardarf) > 0 Then
            '  MsgBox("Registro Guardado Correctamente")
        End If

    End Sub

    Public Sub Insert(ByVal codigo As String, ByVal foto As Byte())
        Dim rut As String = QuitarCaracteres(txtrut.Text)
        Dim sql9 = "delete from clienteimageninf where id='" + rut + "'"
        fnc.MovimientoSQL(sql9)
        Dim con As New SqlConnection

        Dim query As String = "INSERT INTO clienteimageninf(id,foto) VALUES(@codigo,@foto)"
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


    Sub GuardarCliente()

        If validarEntrada() = 0 Then
            Dim fecha = devuelve_fecha(Date.Now)
            Dim rut As String = QuitarCaracteres(txtrut.Text)
            guardaenvmail1()
            guardaenvmail5()
            guardaenvmail7()

            Dim sqlGuardar As String = "INSERT INTO clientes(cli_rut, cli_nomb, cli_direcc, cli_comuna, cli_ciudad, " +
                "cli_fono, cli_fax, cli_feccre, cli_estado, cli_rubro, cli_mail, mail2, CLI_VENC, CLI_CRYD, " +
                "CLI_PVENC, CLI_CODVIG, cli_pwdbloqueo, cli_tipoclie, cli_contactos,cli_hrs_homog,cli_maxcajas,cli_repafecha,cli_pedhorsem,cli_pedhorsab)VALUES(" +
                "'" + rut + "','" + txtrsocial.Text + "','" + txtdireccion.Text + "', " +
                "'" + txtcomuna.Text + "','" + cmbo_region.SelectedValue.ToString() + "', " +
                "'" + txttelefono.Text + "','" + txtfax.Text + "','" + fecha.ToString() + "', " +
                "'" + Retornarestado(cmbo_estado.SelectedItem) + "','" + txtgiro.Text + "', " +
                "'" + RetornaCorreos(dgvpedweb) + "','" + RetornaCorreos(dgvpedidos) + "','" + EstadoCheckBox(CheckBox1.CheckState) + "'," +
                "'" + RetornaCorreos(dgvryd) + "','" + RetornaCorreos(dgvvenc) + "','" + EstadoCheckBox(CbVigente.CheckState) + "'," +
                "'" + boqcajas.Text + "', '" + CategoriasHabilitadas() + "', '" + RetornaCorreos(DgvContactos, ",") + "'," + Convert.ToInt32(hrs_homogenizacion.Text).ToString() + ",'" + txtmaxcajas.Text.Trim() + "','" + fechasug + "','" + txthorasemana.Text.Trim() + "','" + txthorasabado.Text.Trim() + "')"

            If fnc.MovimientoSQL(sqlGuardar) > 0 Then
                Dim EstVenDir As String = "0"

                If (chkVentaDirectaPallet.Checked) Then
                    EstVenDir = "1"
                End If

                Dim sqlVentPall As String = "SP_Control_Pallet_Cliente_Venta_Directa_Grabar '','" & rut & "','" & EstVenDir & "','" & Frm_Principal.InfoUsuario.Text.Trim & "'"
                Dim dtVentPall As New DataTable

                dtVentPall = fnc.ListarTablasSQL(sqlVentPall)

                MsgBox("Información Guardada correctamente", MsgBoxStyle.Information, "Aviso")
                Dim sql As String = "INSERT INTO webusuclie(webclie_horabloqueo, webclie_permisos, webclie_nivel, webclie_rut, webclie_pass, webclie_usu) " +
                    "VALUES ('48','0','0','" + rut.ToString() + "','" + Txtpass.Text + "','" + Txtusu.Text + "')"
                fnc.MovimientoSQL(sql)

                Dim sqlLog As String = "SP_clientes_log_Grabar '" & rut & "','I','" & Frm_Principal.InfoUsuario.Text.Trim & "'"
                fnc.MovimientoSQL(sqlLog)
            Else
                MsgBox("Error al ingresar la información:" & vbCrLf & "- Verifique que los campos son correctos" & vbCrLf & "- Contactese con su administrador")
            End If

        End If
    End Sub

    Sub ModificaCliente()
        If RealizarAccion("004", "009") = False Then
            Exit Sub
        End If
        If validarEntrada() = 0 Then
            Dim fecha = devuelve_fecha(Date.Now)
            Dim rut As String = QuitarCaracteres(txtrut.Text)

            Dim sqlLog As String = "SP_clientes_log_Grabar '" & rut & "','U','" & Frm_Principal.InfoUsuario.Text.Trim & "'"
            fnc.MovimientoSQL(sqlLog)

            Dim sqlActualizar As String = "UPDATE clientes " +
                                          "   SET cli_nomb = '" + txtrsocial.Text + "', " +
                                          "       cli_direcc = '" + txtdireccion.Text + "', " +
                                          "       cli_comuna = '" + txtcomuna.Text + "', " +
                                          "       cli_ciudad = '" + cmbo_region.SelectedValue.ToString() + "', " +
                                          "       cli_fono = '" + txttelefono.Text + "', " +
                                          "       cli_fax = '" + txtfax.Text + "', " +
                                          "       cli_estado = '" + Retornarestado(cmbo_estado.SelectedItem) + "', " +
                                          "       cli_rubro = '" + txtgiro.Text + "', " +
                                          "       cli_mail = '" + RetornaCorreos(dgvpedweb) + "', " +
                                          "       mail2 = '" + RetornaCorreos(dgvpedidos) + "', " +
                                          "       CLI_VENC = '" + EstadoCheckBox(CheckBox1.CheckState) + "', " +
                                          "       CLI_CRYD = '" + RetornaCorreos(dgvryd) + "', " +
                                          "       CLI_PVENC = '" + RetornaCorreos(dgvvenc) + "', " +
                                          "       CLI_CODVIG = '" + EstadoCheckBox(CbVigente.CheckState) + "', " +
                                          "       cli_pwdbloqueo = '" + boqcajas.Text + "', " +
                                          "       cli_tipoclie = '" + CategoriasHabilitadas() + "', " +
                                          "       cli_contactos = '" + RetornaCorreos(DgvContactos, ",") + "', " +
                                          "       cli_hrs_homog = " + Convert.ToInt32(hrs_homogenizacion.Text).ToString() + ", " +
                                          "       cli_maxcajas = '" + txtmaxcajas.Text.Trim() + "', " +
                                          "       cli_repafecha = '" + fechasug + "', " +
                                          "       cli_pedhorsem = '" + txthorasemana.Text.Trim() + "', " +
                                          "       cli_pedhorsab = '" + txthorasabado.Text.Trim() + "' " +
                                          " WHERE cli_rut='" + rut + "'"


            If fnc.MovimientoSQL(sqlActualizar) > 0 Then
                Dim EstVenDir As String = "0"

                If (chkVentaDirectaPallet.Checked) Then
                    EstVenDir = "1"
                End If

                Dim sqlVentPall As String = "SP_Control_Pallet_Cliente_Venta_Directa_Grabar '','" & rut & "','" & EstVenDir & "','" & Frm_Principal.InfoUsuario.Text.Trim & "'"
                Dim dtVentPall As New DataTable

                dtVentPall = fnc.ListarTablasSQL(sqlVentPall)

                MsgBox("Información Actualizada correctamente", MsgBoxStyle.Information, "Aviso")
                If fnc.ListarTablasSQL("SELECT * FROM webusuclie WHERE webclie_rut='" + rut + "'").Rows.Count = 0 Then
                    Dim sql As String = "INSERT INTO webusuclie(webclie_horabloqueo, webclie_permisos, webclie_nivel, webclie_rut, webclie_pass, webclie_usu) " +
                                      "VALUES ('48','0','0','" + rut.ToString() + "','" + Txtpass.Text + "','" + Txtusu.Text + "')"
                    fnc.MovimientoSQL(sql)
                Else
                    Dim sql As String = "UPDATE webusuclie SET webclie_pass ='" + Txtpass.Text + "', webclie_usu ='" + Txtusu.Text + "' WHERE webclie_rut='" + rut + "'"
                    fnc.MovimientoSQL(sql)
                End If



            Else
                MsgBox("Error al Actualizar la información:" & vbCrLf & "- Verifique que los campos son correctos" & vbCrLf & "- Contactese con su administrador", MsgBoxStyle.Critical, "Aviso")
            End If

        End If
    End Sub

    Private Sub btn_eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Eliminar.Click
        If txtrut.Text.Length >= 10 Then
            If RealizarAccion("004", "010") = False Then
                Exit Sub
            End If
            Dim rut As String = QuitarCaracteres(txtrut.Text)

            If MsgBox("Seguro de eliminar el cliente seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbYes Then
                If MsgBox("Está seguro de eliminar el cliente", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Aviso") = vbYes Then

                    Dim sqlLog As String = "SP_clientes_log_Grabar '" & rut & "','D','" & Frm_Principal.InfoUsuario.Text.Trim & "'"
                    fnc.MovimientoSQL(sqlLog)

                    Dim Elimina As String = "DELETE FROM clientes WHERE " +
                        "cli_rut='" + rut + "'"

                    If fnc.MovimientoSQL(Elimina) > 0 Then
                        Dim sql = "delete from Clientes_Congelado_Camara with(nolock) where Rut_Cliente='" & rut & "'"
                        fnc.MovimientoSQL(sql)

                        MsgBox("Registro Eliminado", MsgBoxStyle.Information, "Aviso")
                    End If


                End If
            End If
        End If
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Salir.Click
        Close()
    End Sub

    Private Sub txtfax_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtfax.KeyPress
        SoloNumeros(sender, e)
    End Sub

    Private Sub txttelefono_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttelefono.KeyPress
        SoloNumeros(sender, e)
    End Sub
 
    Private Sub txtrut_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtrut.KeyPress
        If e.KeyChar = ChrW(13) Then
            If txtrut.Text.Length = 10 Then
                BUSCA_CLIENTE(QuitarCaracteres(txtrut.Text))
            End If
        End If
    End Sub

    Sub BUSCA_CLIENTE(ByVal rut_completo)

        Btn_Nuevo.PerformClick()

        Dim sqlBuscaCliente = "SELECT cli_rut, cli_nomb, cli_direcc, cli_comuna, cli_ciudad, cli_fono, cli_fax, cli_estado, " +
                              "cli_rubro, cli_mail, mail2, CLI_VENC, CLI_CRYD, CLI_PVENC, CLI_CODVIG, webclie_usu, webclie_pass,  " +
                              "cli_pwdbloqueo, cli_tipoclie, cli_contactos,cli_blockweb ,cli_blockges,cli_hrs_homog,cli_stock0,cli_maxcajas,cli_repafecha, " +
                              "cli_pedhorsem, cli_pedhorsab " +
                              "FROM Clientes LEFT JOIN webusuclie ON webclie_rut=cli_rut WHERE cli_rut='" + rut_completo + "'"

        Dim tabla As DataTable = fnc.ListarTablasSQL(sqlBuscaCliente)
        If tabla.Rows.Count > 0 Then

            txtrut.Text = tabla.Rows(0)(0).ToString()
            txtrsocial.Text = tabla.Rows(0)(1).ToString()
            txtdireccion.Text = tabla.Rows(0)(2).ToString()
            txtcomuna.Text = tabla.Rows(0)(3).ToString()
            cmbo_region.SelectedValue = tabla.Rows(0)(4).ToString()
            txttelefono.Text = tabla.Rows(0)(5).ToString()
            txtfax.Text = tabla.Rows(0)(6).ToString()

            Dim estado As String = Retornarestado(tabla.Rows(0)(7)).ToString()

            cmbo_estado.SelectedItem = estado
            txtgiro.Text = tabla.Rows(0)(8).ToString()
            LlamarCorreos(tabla.Rows(0)(9).ToString(), dgvpedweb)
            LlamarCorreos(tabla.Rows(0)(10).ToString(), dgvpedidos)
            CheckBox1.CheckState = tabla.Rows(0)(11).ToString()
            LlamarCorreos(tabla.Rows(0)(12).ToString(), dgvryd)
            LlamarCorreos(tabla.Rows(0)(13).ToString(), dgvvenc)
            CbVigente.CheckState = tabla.Rows(0)(14).ToString()
            Txtusu.Text = tabla.Rows(0)(15).ToString().Trim
            Txtpass.Text = tabla.Rows(0)(16).ToString().Trim
            boqcajas.Text = tabla.Rows(0)(17).ToString().Trim
            txthorasemana.Text = tabla.Rows(0)(26).ToString().Trim
            txthorasabado.Text = tabla.Rows(0)(27).ToString().Trim
            If tabla.Rows(0)(18).ToString() = "" Then

            Else
                SeleccionaTipo(tabla.Rows(0)(18).ToString())
            End If

            LlamarCorreos(tabla.Rows(0)(19).ToString(), DgvContactos, False, ",")
            If tabla.Rows(0)(20).ToString() = "1" Then
                chk_bloq.Checked = True
            End If
            If tabla.Rows(0)(20).ToString() = "0" Then
                chk_bloq.Checked = False
            End If
            If tabla.Rows(0)(21).ToString() = "1" Then
                CheckBox2.Checked = True
            End If
            If tabla.Rows(0)(21).ToString() = "0" Then
                CheckBox2.Checked = False
            End If
            If tabla.Rows(0)(23).ToString() = "1" Then
                CheckBox3.Checked = True
            End If
            If tabla.Rows(0)(23).ToString() = "0" Then
                CheckBox3.Checked = False
            End If

            If tabla.Rows(0)(25).ToString() = "SI" Then
                rdsifecha.Checked = True
            End If
            If tabla.Rows(0)(25).ToString() = "NO" Then
                rdnofecha.Checked = True
            End If
            txtmaxcajas.Text = tabla.Rows(0)(24).ToString().Trim


            hrs_homogenizacion.Text = tabla.Rows(0)(22).ToString().Trim

            Btn_Guardar.Enabled = True
            txtrut.Enabled = False
            GroupBox3.Enabled = True

            Dim sql = "select Horas_Congelado_Camara from Clientes_Congelado_Camara with(nolock) where Rut_Cliente='" & rut_completo & "'"
            Dim dt As New DataTable
            dt = fnc.ListarTablasSQL(sql)
            If (dt.Rows.Count > 0) Then
                txtHrsCongCam.Text = dt.Rows(0).Item(0).ToString.Trim
            Else
                txtHrsCongCam.Text = "504"
            End If

            buscarCliUsaTag()

            buscarVentaDirectaPallet()
        Else
            If RutDigito(txtrut.Text.ToUpper()) = True Then
                If RealizarAccion("004", "008") = False Then
                    Exit Sub
                End If
                txtrut.Enabled = False
                GroupBox3.Enabled = True
                Btn_Guardar.Enabled = True
            Else
                If contro = "0" Then

                    contro = ""
                Else
                    MsgBox("El R.U.T ingresado no es valido", MsgBoxStyle.Critical, "Aviso")
                End If
            End If
        End If
    End Sub

    Sub buscarCliUsaTag()
        Try
            Dim Rut As String = txtrut.Text.Trim.Replace("-", "")
            If (Rut <> "") Then
                Dim sql As String = "select Estado from Clientes_TAGs where Rut_Cliente='" & Rut & "'"
                Dim tabla As DataTable = fnc.ListarTablasSQL(sql)
                If (tabla.Rows.Count > 0) Then
                    If (tabla.Rows(0).Item(0).ToString.Trim = "1") Then
                        chkTag.Checked = True
                    Else
                        chkTag.Checked = False
                    End If
                Else
                    chkTag.Checked = False
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Ocurrio un error al cargar los datos del TAG RFID del cliente.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub buscarVentaDirectaPallet()
        Try
            Dim Rut As String = txtrut.Text.Trim.Replace("-", "")

            If (Rut <> "") Then
                Dim sql As String = "select Estado from Control_Pallet_Cliente_Venta_Directa with(nolock) where Rut_Cliente='" & Rut & "'"
                Dim dt As New DataTable

                dt = fnc.ListarTablasSQL(sql)

                Dim Resp As String = "0"

                If (dt.Rows.Count > 0) Then
                    Dim RespDt As String = dt.Rows(0).Item(0).ToString.Trim

                    If (RespDt <> "-1") Then
                        Resp = RespDt
                    End If
                End If

                If (Resp = "1") Then
                    chkVentaDirectaPallet.Checked = True
                Else
                    chkVentaDirectaPallet.Checked = False
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Ocurrio un error al buscar configuración venta directa arriendo pallets.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbo_estado_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbo_region.KeyPress, cmbo_estado.KeyPress
        e.Handled = True
    End Sub

    Private Sub Btn_BuscaCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_BuscaCliente.Click

        clientesbusc = "SI"
        CHEC = "0"
        Dim frm As New Lst_AyudaClientes
        frm.cliente = "SI"
        frm.ShowDialog(Frm_Principal)
        If Frm_Principal.buscavalor <> "" Then
            Me.txtrut.Text = Frm_Principal.buscavalor
            BUSCA_CLIENTE(Frm_Principal.buscavalor)
            Frm_Principal.buscavalor = ""
            txtrsocial.Focus()
        End If
        clientesbusc = ""
    End Sub



    Public Sub LlamarCorreos(ByVal correos As String, ByVal dgv As DataGridView, Optional ByVal isemail As Boolean = True, Optional ByVal _char As String = ";")

        If correos.Length > 0 Then
            If isemail = True Then
                correos = correos.ToLower()
            End If

            Dim _corr() = correos.Split(Convert.ToChar(_char))

            For i As Integer = 0 To _corr.Length - 1
                dgv.Rows.Add(_corr(i))
            Next

        End If

    End Sub

    Public Function RetornaCorreos(ByVal dgv As DataGridView, Optional ByVal _char As String = ";") As String

        Dim _corr As String = ""

        If dgv.Rows.Count > 0 Then

            For i As Integer = 0 To dgv.Rows.Count - 1
                _corr += dgv.Rows(i).Cells(0).Value + _char
            Next
            _corr = _corr.Remove(_corr.Length - 1, 1)
        End If
        Return _corr
    End Function


    Private _vem1 As Integer = -1
    Private _vem2 As Integer = -1
    Private _vem3 As Integer = -1
    Private _vem4 As Integer = -1
    Private _vem5 As Integer = -1


    Private Sub dgvpedweb_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        If e.RowIndex > -1 Then
            _em1.Text = dgvpedweb.Rows(e.RowIndex).Cells(0).Value.ToString()
            _vem1 = e.RowIndex()
        Else
            _em1.Text = ""
            _vem1 = -1
        End If
    End Sub

    Private Sub add_1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles add_1.Click
        If validar_Mail(_em1.Text) = True Then
            If _vem1 > -1 Then
                dgvpedweb.Rows(_vem1).Cells(0).Value = _em1.Text
                _vem1 = -1
                _em1.Text = ""
            Else
                dgvpedweb.Rows.Add(_em1.Text)
                _vem1 = -1
                _em1.Text = ""
            End If
            add_1.Focus()
        Else
            MsgBox("El correo ingresado no es valido", MsgBoxStyle.Critical, "Aviso")
        End If
    End Sub

    Private Sub _elim1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _elim1.Click
        _vem1 = -1
        _em1.Text = ""
        _em1.Focus()
    End Sub

    Private Sub dgvpedweb_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        If e.RowIndex > -1 AndAlso e.ColumnIndex = 1 Then
            dgvpedweb.Rows.RemoveAt(e.RowIndex)
        End If
    End Sub



    Private Sub dgvpedidos_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvpedidos.CellDoubleClick
        If e.RowIndex > -1 Then
            _em2.Text = dgvpedidos.Rows(e.RowIndex).Cells(0).Value.ToString()
            _vem2 = e.RowIndex()
        End If
    End Sub

    Private Sub add_2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles add_2.Click
        If validar_Mail(_em2.Text) = True Then
            If _vem2 > -1 Then
                dgvpedidos.Rows(_vem2).Cells(0).Value = _em2.Text
                _vem2 = -1
                _em2.Text = ""
            Else
                dgvpedidos.Rows.Add(_em2.Text)
                _vem2 = -1
                _em2.Text = ""
            End If
            add_2.Focus()
        Else
            MsgBox("El correo ingresado no es valido", MsgBoxStyle.Critical, "Aviso")
        End If
    End Sub

    Private Sub _elim2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _elim2.Click
        _vem2 = -1
        _em2.Text = ""
        _em2.Focus()
    End Sub

    Private Sub dgvpedidos_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvpedidos.CellClick
        If e.RowIndex > -1 AndAlso e.ColumnIndex = 1 Then
            dgvpedidos.Rows.RemoveAt(e.RowIndex)
        End If
    End Sub



    Private Sub dgvryd_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvryd.CellDoubleClick
        If e.RowIndex > -1 Then
            _em3.Text = dgvryd.Rows(e.RowIndex).Cells(0).Value.ToString()
            _vem3 = e.RowIndex()
        End If
    End Sub

    Private Sub add_3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles add_3.Click
        If validar_Mail(_em3.Text) = True Then
            If _vem3 > -1 Then
                dgvryd.Rows(_vem3).Cells(0).Value = _em3.Text
                _vem3 = -1
                _em3.Text = ""
            Else
                dgvryd.Rows.Add(_em3.Text)
                _vem3 = -1
                _em3.Text = ""
            End If
            _em3.Focus()
        Else
            MsgBox("El correo ingresado no es valido", MsgBoxStyle.Critical, "Aviso")
        End If
    End Sub

    Private Sub _elim3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _elim3.Click
        _vem3 = -1
        _em3.Text = ""
        _em3.Focus()
    End Sub

    Private Sub dgvryd_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvryd.CellClick
        If e.RowIndex > -1 AndAlso e.ColumnIndex = 1 Then
            dgvryd.Rows.RemoveAt(e.RowIndex)
        End If
    End Sub



    Private Sub dgvvenc_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvvenc.CellDoubleClick
        If e.RowIndex > -1 Then
            _em4.Text = dgvvenc.Rows(e.RowIndex).Cells(0).Value.ToString()
            _vem4 = e.RowIndex()
        End If
    End Sub

    Private Sub add_4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles add_4.Click
        If validar_Mail(_em4.Text) = True Then
            If _vem4 > -1 Then
                dgvvenc.Rows(_vem4).Cells(0).Value = _em4.Text
                _vem4 = -1
                _em4.Text = ""
            Else
                dgvvenc.Rows.Add(_em4.Text)
                _vem4 = -1
                _em4.Text = ""
            End If
            _em4.Focus()
        Else
            MsgBox("El correo ingresado no es valido", MsgBoxStyle.Critical, "Aviso")
        End If
    End Sub

    Private Sub _elim4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _elim4.Click
        _vem4 = -1
        _em4.Text = ""
    End Sub

    Private Sub dgvvenc_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvvenc.CellClick
        If e.RowIndex > -1 AndAlso e.ColumnIndex = 1 Then
            dgvvenc.Rows.RemoveAt(e.RowIndex)
        End If
    End Sub


    Private Sub add_5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles add_5.Click

        If _cont1.Text.Length > 5 Then
            If _vem5 > -1 Then
                DgvContactos.Rows(_vem5).Cells(0).Value = _cont1.Text
                _vem5 = -1
                _cont1.Text = ""
            Else
                DgvContactos.Rows.Add(_cont1.Text)
                _vem5 = -1
                _cont1.Text = ""
            End If
            _cont1.Focus()
        Else
            MsgBox("Debe ingresar el nombre completo", MsgBoxStyle.Critical, "Aviso")
        End If

    End Sub

    Private Sub _elim5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _elim5.Click
        _vem4 = -1
        _em4.Text = ""
    End Sub

    Private Sub DgvContactos_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvContactos.CellDoubleClick
        If e.RowIndex > -1 Then
            _cont1.Text = DgvContactos.Rows(e.RowIndex).Cells(0).Value.ToString()
            _vem5 = e.RowIndex()
        End If

    End Sub

    Private Sub DgvContactos_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvContactos.CellClick
        If e.RowIndex > -1 AndAlso e.ColumnIndex = 1 Then
            DgvContactos.Rows.RemoveAt(e.RowIndex)
        End If
    End Sub


    Private Function CategoriasHabilitadas() As String
        Dim cat As String = ""

        For i As Integer = 0 To cblist.Items.Count - 1
            If (cblist.GetItemChecked(i)) Then
                cat += cblist.GetItemText(i) + ","
            End If
        Next
        If cat.Length > 0 Then
            cat = cat.Remove(cat.Length - 1, 1)
        End If

        Return cat

    End Function

    Private Sub SeleccionaTipo(ByVal _string As String)

        Dim arreglo As String() = _string.Split(Convert.ToChar(","))

        For i As Integer = 0 To arreglo.Count - 1
            cblist.SetItemChecked(arreglo(i), True)
        Next

    End Sub

    Private Sub Frm_AddClientes_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.F5 Then
            Btn_Guardar.PerformClick()
        ElseIf e.KeyCode = Keys.F6 Then
            Btn_Nuevo.PerformClick()
        ElseIf e.KeyCode = Keys.F7 Then
            Btn_Eliminar.PerformClick()
        ElseIf e.KeyCode = Keys.Escape Then
            Btn_Salir.PerformClick()
        End If

    End Sub

    Private Sub _em1_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles _em1.KeyPress
        Select Case Asc(e.KeyChar)
            Case 225, 233, 237, 243, 250, 193, 201, 205, 211, 218 'vocales con tilde (mayúsculas y minúsculas)
                e.Handled = True
            Case 241, 209 'ñ y Ñ
                e.Handled = True
        End Select
    End Sub

    Private Sub CbVigente_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CbVigente.CheckedChanged

    End Sub

    Private Sub chk_bloq_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chk_bloq.CheckedChanged
        CHEC = "1"
    End Sub

    Private Sub TextBox1_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtmaxcajas.KeyPress
        SoloNumeros(sender, e)
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        cargarImagen()
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
End Class
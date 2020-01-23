Imports CrystalDecisions.Shared

Public Class Frm_CheckList

    Dim fnc As New Funciones

    Private Sub Frm_CheckList_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F2 Then
            If RealizarAccion("017", "046", True) = False Then
                Exit Sub
            End If

            If MsgBox("Desea Modificar Checklist?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbYes Then
                GroupBox1.Enabled = True
                btn_BuscaCliente.Enabled = True
                btn_guardar.Enabled = True
                txtNroCont.Enabled = True

                Dim Mov = CmboMovimiento.Text.Trim
                If (Mov.Contains("DESCARGA")) Then
                    txtGui.Enabled = True
                    txtSell.Enabled = True
                Else
                    txtGui.Text = ""
                    txtSell.Text = ""

                    txtGui.Enabled = False
                    txtSell.Enabled = False
                End If
            End If
        End If
    End Sub

    Private Sub Frm_CheckList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Frm_Principal.buscavalor = ""

        Dim sqlmov As String = "SELECT mov_codi, mov_desc FROM P_MovChecklist ORDER BY mov_codi ASC"
        CmboMovimiento.DataSource = fnc.ListarTablasSQL(sqlmov)
        CmboMovimiento.DisplayMember = "mov_desc"
        CmboMovimiento.ValueMember = "mov_codi"


        Dim sqlCont As String = "SELECT Con_codi, Con_desc FROM P_ConChecklist ORDER BY Con_codi ASC"
        CmboContenedor.DataSource = fnc.ListarTablasSQL(sqlCont)
        CmboContenedor.DisplayMember = "Con_desc"
        CmboContenedor.ValueMember = "Con_codi"
    End Sub

    Private Sub Txtfolio_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtfolio.KeyPress
        If e.KeyChar = ChrW(13) Then
            If Txtfolio.Text = "" Then
                If RealizarAccion("017", "043", True) = False Then
                    Exit Sub
                End If


                Dim buscarcorrelativo As String = "SELECT top(1) Cl_fol from zCheckList order by Cl_fol desc"
                Dim folio As New DataTable
                folio = fnc.ListarTablasSQL(buscarcorrelativo)
                Dim correlativo2 As Integer = folio.Rows(0).Item(0)
                correlativo2 = correlativo2 + 1
                Txtfolio.Text = CerosAnteriorString(correlativo2, 7)
                Txtfolio.Enabled = False

                TemSal.Visible = False
                Label12.Visible = False

                GroupBox1.Enabled = True
                btn_guardar.Enabled = True
                BtnAyuda.Enabled = False

                'Ocultar MOD Tiempos
                Label14.Visible = False
                Label15.Visible = False
                Label16.Visible = False

                LblFecLleg.Visible = False
                LblFecIng.Visible = False
                LblFecSal.Visible = False

                HorLleg.Visible = False
                HorIng.Visible = False
                HorSal.Visible = False
            Else
                RescataCheckList(CerosAnteriorString(Txtfolio.Text, 7))
            End If
        End If

        SoloNumeros(sender, e)
    End Sub

    Sub RescataCheckList(ByVal folio As String)
        Dim sql As String = ""
        If sucursalglo = "0" Then
            sql = "SELECT Cl_RutCli, cli_nomb, Cl_chorut, cho_nombre, Cl_ChoEmp, Cl_Ting, Cl_Cont, Cl_Mov, Cl_DesTemp, " +
      "cl_pate, Cl_Ram, cl_obs, cl_ori, isnull(Cl_Lleg,0) AS Cl_Lleg, isnull(Cl_ing,0) AS Cl_ing, isnull(Cl_Des,0) AS Cl_Des,Cl_salGuia=isnull(Cl_salGuia,''),Cl_DesSello=isnull(Cl_DesSello,'') " +
      "FROM zchecklist, clientes, choferes WHERE cho_rut=cl_chorut " +
      "AND cli_rut=cl_rutcli AND cl_fol='" + folio + "'"

        Else
            sql = "SELECT Cl_RutCli, cli_nomb, Cl_chorut, cho_nombre, Cl_ChoEmp, Cl_Ting, Cl_Cont, Cl_Mov, Cl_DesTemp, " +
                  "cl_pate, Cl_Ram, cl_obs, cl_ori, isnull(Cl_Lleg,0) AS Cl_Lleg, isnull(Cl_ing,0) AS Cl_ing, isnull(Cl_Des,0) AS Cl_Des,Cl_salGuia=isnull(Cl_salGuia,''),Cl_DesSello=isnull(Cl_DesSello,'') " +
                  "FROM zchecklist, clientes, choferes WHERE cho_rut=cl_chorut " +
                  "AND cli_rut=cl_rutcli AND cl_fol='" + folio + "'  "

        End If
  
        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

        If tabla.Rows.Count > 0 Then
            Txtfolio.Text = folio

            TxtClirut.Text = tabla.Rows(0)(0).ToString().Remove(8)
            TxtCliVeri.Text = tabla.Rows(0)(0).ToString().Chars(8)
            TxtCliNombre.Text = tabla.Rows(0)(1).ToString()

            TxtChoRut.Text = tabla.Rows(0)(2).ToString().Remove(8)
            TxtChoVeri.Text = tabla.Rows(0)(2).ToString().Chars(8)
            TxtChoNombre.Text = tabla.Rows(0)(3).ToString()

            txtempresa.Text = tabla.Rows(0)(4).ToString()
            TemIng.Text = tabla.Rows(0)(5).ToString()
            CmboContenedor.SelectedValue = tabla.Rows(0)(6).ToString()
            CmboMovimiento.SelectedValue = tabla.Rows(0)(7).ToString()
            TemSal.Text = tabla.Rows(0)(8).ToString()
            txtpatente.Text = tabla.Rows(0)(9).ToString()
            TxtRampla.Text = tabla.Rows(0)(10).ToString()
            txtobs.Text = tabla.Rows(0)(11).ToString()
            Txtorigen.Text = tabla.Rows(0)(12).ToString()
            HorLleg.Text = DevuelveHora(Convert.ToDateTime(tabla.Rows(0)(13).ToString()))
            LblFecLleg.Text = devuelve_fecha_Formato2(Convert.ToDateTime(tabla.Rows(0)(13).ToString()))

            txtGui.Text = tabla.Rows(0)(16).ToString()
            txtSell.Text = tabla.Rows(0)(17).ToString()

            Label14.Visible = True
            Label15.Visible = True
            Label16.Visible = True

            LblFecLleg.Visible = True
            LblFecIng.Visible = True
            LblFecSal.Visible = True

            HorLleg.Visible = True
            HorLleg.Enabled = False
            HorIng.Visible = True
            HorSal.Visible = True

            If tabla.Rows(0)(14).ToString() = "01-01-1900 0:00:00" Then
                HorIng.Visible = False
                HorIng.Text = ""
                LblFecIng.Visible = False
                Label15.Font = New Font(Label15.Font, Label15.Font.Style Or FontStyle.Strikeout)
                LblFecIng.Text = "00-00-0000"
            Else
                HorIng.Visible = True
                LblFecIng.Visible = True
                HorIng.Text = DevuelveHora(Convert.ToDateTime(tabla.Rows(0)(14).ToString()))
                LblFecIng.Text = devuelve_fecha_Formato2(Convert.ToDateTime(tabla.Rows(0)(14).ToString()))
                Label15.Font = New Font(Label15.Font, Label15.Font.Style And Not FontStyle.Strikeout)

            End If

            If tabla.Rows(0)(15).ToString() = "01-01-1900 0:00:00" Then
                HorSal.Visible = False
                LblFecSal.Visible = False
                HorSal.Text = ""
                Label16.Font = New Font(Label16.Font, Label16.Font.Style Or FontStyle.Strikeout)
                LblFecSal.Text = "00-00-0000"
            Else
                HorSal.Visible = True
                LblFecSal.Visible = True
                HorSal.Text = DevuelveHora(Convert.ToDateTime(tabla.Rows(0)(15).ToString()))
                LblFecSal.Text = devuelve_fecha_Formato2(Convert.ToDateTime(tabla.Rows(0)(15).ToString()))
                Label16.Font = New Font(Label16.Font, Label16.Font.Style And Not FontStyle.Strikeout)
            End If


            Txtfolio.Enabled = False
            BtnImagenes.Visible = True
            Label12.Visible = True
            TemSal.Visible = True

            Dim sqlCont = "select NroCont from zCheckList_Contenedores where Cl_fol='" & Txtfolio.Text.Trim & "'"
            Dim dtCont As DataTable = fnc.ListarTablasSQL(sqlCont)
            If (dtCont.Rows.Count > 0) Then
                txtNroCont.Text = dtCont.Rows(0).Item(0).ToString.Trim
                txtNroCont.Enabled = True
            End If
        Else
            MsgBox("El codigo ingresado no existe", MsgBoxStyle.Critical, "Aviso")
            Txtfolio.Text = ""
            Txtfolio.Focus()
        End If


    End Sub

    Private Sub btn_BuscaCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_BuscaCliente.Click
        Dim f As New Lst_AyudaClientes
        f.ShowDialog(Frm_Principal)

        If Frm_Principal.buscavalor.ToString() <> "" Then
            TxtClirut.Text = Frm_Principal.buscavalor.ToString().Remove(8)
            TxtCliVeri.Text = Frm_Principal.buscavalor.ToString().Chars(8)
            TxtCliNombre.Text = RetornaCliente(Frm_Principal.buscavalor.ToString())
            Frm_Principal.buscavalor = ""
        End If
    End Sub

    Private Sub BtnChofer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnChofer.Click
        Dim f As New Lst_AyudaChoferes
        f.ShowDialog(Frm_Principal)

        ' f.where = ""
        'f.where = TxtClirut.Text + "" + TxtCliVeri.Text

        'If Frm_Principal.buscavalor.ToString.Length >= 9 Then

        'TxtChoRut.Text = Frm_Principal.buscavalor.ToString().Remove(8)
        'TxtChoVeri.Text = Frm_Principal.buscavalor.ToString().Chars(8)

        Dim RutCompleto As String = Frm_Principal.buscavalor.ToString()
        Dim RutFrm As String = RutCompleto.Substring(0, RutCompleto.Length - 1)
        Dim Dv As String = RutCompleto.Substring(RutCompleto.Length - 1, 1)

        Dim SqlChofer As String = "SELECT cho_empresa, cho_nombre, cho_patente, cho_patente2 " +
                                  "FROM choferes WHERE cho_rut='" + Frm_Principal.buscavalor.ToString() + "' "

        Dim tabla As DataTable = fnc.ListarTablasSQL(SqlChofer)

        If tabla.Rows.Count > 0 Then
            txtpatente.Text = tabla.Rows(0)(2).ToString()
            TxtRampla.Text = tabla.Rows(0)(3).ToString()
            txtempresa.Text = tabla.Rows(0)(0).ToString()
            TxtChoNombre.Text = tabla.Rows(0)(1).ToString()
            TxtChoRut.Text = RutFrm
            TxtChoRut.Enabled = False
            TxtChoVeri.Text = Dv
            TxtChoVeri.Enabled = False
        Else
            txtempresa.Text = ""
            TxtRampla.Text = ""
            txtpatente.Text = ""
            TxtChoNombre.Text = ""
            TxtChoRut.Text = ""
            TxtChoVeri.Text = ""
        End If
        'End If
    End Sub

    Public Sub Frm_CheckList_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If Txtfolio.Text <> "" AndAlso Txtfolio.Enabled = False Then
            If fnc.verificaExistencia("zchecklist", "cl_fol", CerosAnteriorString(Txtfolio.Text, 7)) = False Then

                If fnc.verificaExistencia("zchecklist", "cl_fol", Txtfolio.Text) = False Then

                    If MsgBox("Esta seguro de salir sin guardar la información", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbNo Then
                        e.Cancel = True
                    Else
                        CancelaCorrelativo("100", Txtfolio.Text)
                        f_registrocamion = False
                    End If
                Else
                    f_registrocamion = False
                End If
            Else
                f_registrocamion = False
            End If
        Else
            f_registrocamion = False
        End If

    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
        Handles TemIng.KeyPress, TemSal.KeyPress

        Dim x As TextBox = sender
        If Not IsNumeric(e) Then
            If e.KeyChar = "," Or e.KeyChar = "." Or e.KeyChar = ChrW(8) Or e.KeyChar = "-" Then

                For i As Integer = 0 To x.Text.Length - 1
                    If x.Text.Chars(i) = e.KeyChar Then
                        SoloNumeros(sender, e)
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

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        If Valida_Registro() = True Then
            If fnc.verificaExistencia("zCheckList", "cl_fol", Txtfolio.Text) = False Then

                Dim turno As String = ""

                If Convert.ToDateTime("08:00:00") > DevuelveHora() AndAlso DevuelveHora() <= Convert.ToDateTime("19:59:59") Then
                    turno = "1"
                Else
                    turno = "2"
                End If

                'Dim sql As String = "INSERT INTO zCheckList(Cl_fol, Cl_RutCli, Cl_chorut, Cl_ChoEmp, Cl_Ting, Cl_Cont, Cl_Gs, " +
                '                             "Cl_Mov, Cl_DesTemp, cl_pate, Cl_Ram, Cl_EstPor, Cl_Estfrigo, cl_lleg, cl_obs, cl_tur, CL_ORI)VALUES(" +
                '                             "'" + Txtfolio.Text + "','" + TxtClirut.Text + "" + TxtCliVeri.Text + "', '" + TxtChoRut.Text + "" + TxtChoVeri.Text + "'," +
                '                             "'" + txtempresa.Text + "','" + TemIng.Text.Replace(",", ".") + "','" + CmboContenedor.SelectedValue.ToString() + "'," +
                '                             "'" + Frm_Principal.InfoUsuario.Text + "','" + CmboMovimiento.SelectedValue.ToString() + "','" + TemSal.Text.Replace(",", ".") + "', " +
                '                             "'" + txtpatente.Text + "', '" + TxtRampla.Text + "','0','0','" + fnc.DevuelveFechaServidor().ToString() + "'," +
                '                             "'" + txtobs.Text + "','" + turno + "','" + Txtorigen.Text + "')"

                Dim sql As String = "INSERT INTO zCheckList(Cl_fol, Cl_RutCli, Cl_chorut, Cl_ChoEmp, Cl_Ting, Cl_Cont, Cl_Gs, " +
                                             "Cl_Mov, Cl_DesTemp, cl_pate, Cl_Ram, Cl_EstPor, Cl_Estfrigo, cl_lleg, cl_obs, cl_tur, CL_ORI,Cl_salGuia,Cl_DesSello)VALUES(" +
                                             "'" + Txtfolio.Text + "','" + TxtClirut.Text + "" + TxtCliVeri.Text + "', '" + TxtChoRut.Text + "" + TxtChoVeri.Text + "'," +
                                             "'" + txtempresa.Text + "','" + TemIng.Text.Replace(",", ".") + "','" + CmboContenedor.SelectedValue.ToString() + "'," +
                                             "'" + Frm_Principal.InfoUsuario.Text + "','" + CmboMovimiento.SelectedValue.ToString() + "','" + TemSal.Text.Replace(",", ".") + "', " +
                                             "'" + txtpatente.Text + "', '" + TxtRampla.Text + "','0','0','" + fnc.DevuelveFechaServidor().ToString() + "'," +
                                             "'" + txtobs.Text + "','" + turno + "','" + Txtorigen.Text + "','" + txtGui.Text.Trim + "','" + txtSell.Text.Trim + "')"

                If fnc.MovimientoSQL(sql) > 0 Then
                    'Actualización Cierre camiones carga y descarga. 07-06-19
                    Dim cboContText As String = CmboMovimiento.Text.Trim

                    If (cboContText.Contains("CARGA") And cboContText.Contains("DESCARGA")) Then
                        Dim sqlCarDes As String = "SP_Camiones_Carga_Descarga_Grabar '0','" & Txtfolio.Text.Trim & "','0','0','" & Frm_Principal.InfoUsuario.Text.Trim & "'"
                        fnc.MovimientoSQL(sqlCarDes)
                    End If
                    'Fin actualización Cierre camiones carga y descarga. 07-06-19

                    MsgBox("Información guardada correctamente", MsgBoxStyle.Information, "Aviso")
                    btn_guardar.Enabled = False

                    'Actualiza tabla choferes
                    Dim Choferes As String = "UPDATE choferes SET cho_patente='" + txtpatente.Text + "', cho_patente2='" + TxtRampla.Text + "', " +
                        "cho_empresa='" + txtempresa.Text + "' WHERE cho_rut='" + TxtChoRut.Text + "" + TxtChoVeri.Text + "'"
                    If fnc.MovimientoSQL(Choferes) = 0 Then
                        MsgBox("El chofer NO se actualizo", MsgBoxStyle.Critical, "Aviso")
                    End If
                Else
                    MsgBox("Error al guardar la información", MsgBoxStyle.Critical, "Aviso")
                End If
            Else

                Dim turno As String = ""

                If Convert.ToDateTime("08:00:00") > DevuelveHora() AndAlso DevuelveHora() <= Convert.ToDateTime("19:59:59") Then
                    turno = "1"
                Else
                    turno = "2"
                End If


                Dim fecha_llegada As DateTime
                Dim fecha_ingreso As DateTime
                Dim fecha_salida As DateTime
                Dim qry As String = ""

                If HorLleg.Text.Trim <> ":" Then
                    fecha_llegada = LblFecLleg.Text + " " + HorLleg.Text.Trim + ":00"
                    qry = ", cl_lleg='" + fecha_llegada.ToString() + "'"
                End If

                If HorIng.Text.Trim <> ":" AndAlso IsDate(HorIng.Text) Then
                    If Convert.ToDateTime(LblFecLleg.Text + " " + HorLleg.Text.Trim + ":00") > Convert.ToDateTime(LblFecIng.Text + " " + HorIng.Text.Trim + ":00") Then
                        MsgBox("La hora de salida no puede ser menor a la hora de ingreso", MsgBoxStyle.Critical, "Aviso")
                        Exit Sub
                    End If
                    fecha_ingreso = LblFecIng.Text + " " + HorIng.Text.Trim + ":00"
                    qry = qry + ", Cl_ing='" + fecha_ingreso.ToString() + "' "

                ElseIf HorIng.Visible = True Then
                    MsgBox("El registro agregado como ""hora de llegada"" no corresponde a una hora ", MsgBoxStyle.Critical, "Aviso")
                    Exit Sub
                End If
                If HorSal.Text.Trim <> ":" Then
                Else

                    If HorSal.Text.Trim <> ":" AndAlso IsDate(HorSal.Text) Then
                        If Convert.ToDateTime(LblFecSal.Text + " " + HorSal.Text + ":00") < Convert.ToDateTime(LblFecIng.Text + " " + HorIng.Text.Trim + ":00") Then
                            MsgBox("La hora de salida no puede ser menor a la hora de ingreso", MsgBoxStyle.Critical, "Aviso")
                            Exit Sub
                        End If
                        fecha_salida = LblFecSal.Text + " " + HorSal.Text.Trim + ":00"
                        qry = qry + ", Cl_Des='" + fecha_salida.ToString() + "' "
                    ElseIf HorSal.Visible = True Then
                        MsgBox("El registro agregado como ""hora de salida"" no corresponde a una hora ", MsgBoxStyle.Critical, "Aviso")
                        Exit Sub
                    End If

                End If
              


                'Dim sql As String = "UPDATE zCheckList SET cl_rutcli='" + TxtClirut.Text + TxtCliVeri.Text + "', Cl_chorut='" + TxtChoRut.Text + "" + TxtChoVeri.Text + "', " +
                '                    "Cl_ChoEmp='" + txtempresa.Text + "', Cl_Ting='" + TemIng.Text.Replace(",", ".") + "', Cl_Cont='" + CmboContenedor.SelectedValue.ToString() + "', " +
                '                    "Cl_Mov='" + CmboMovimiento.SelectedValue.ToString() + "', Cl_DesTemp='" + TemSal.Text.Replace(",", ".") + "', " +
                '                    "cl_pate='" + txtpatente.Text + "', Cl_Ram='" + TxtRampla.Text + "', cl_obs='" + txtobs.Text + "', cl_ori='" + Txtorigen.Text + "' " + qry +
                '                    "WHERE Cl_fol='" + Txtfolio.Text + "'"

                Dim sql As String = "UPDATE zCheckList SET cl_rutcli='" + TxtClirut.Text + TxtCliVeri.Text + "', Cl_chorut='" + TxtChoRut.Text + "" + TxtChoVeri.Text + "', " +
                                    "Cl_ChoEmp='" + txtempresa.Text + "', Cl_Ting='" + TemIng.Text.Replace(",", ".") + "', Cl_Cont='" + CmboContenedor.SelectedValue.ToString() + "', " +
                                    "Cl_Mov='" + CmboMovimiento.SelectedValue.ToString() + "', Cl_DesTemp='" + TemSal.Text.Replace(",", ".") + "', " +
                                    "cl_pate='" + txtpatente.Text + "', Cl_Ram='" + TxtRampla.Text + "', cl_obs='" + txtobs.Text + "', cl_ori='" + Txtorigen.Text + "',Cl_salGuia='" + txtGui.Text.Trim + "',Cl_DesSello='" + txtSell.Text.Trim + "' " + qry +
                                    "WHERE Cl_fol='" + Txtfolio.Text + "'"


                If fnc.MovimientoSQL(sql) > 0 Then
                    'Actualización Cierre camiones carga y descarga. 07-06-19
                    Dim cboContText As String = CmboMovimiento.Text.Trim

                    If (cboContText.Contains("CARGA") And cboContText.Contains("DESCARGA")) Then
                        Dim sqlCarDes As String = "SP_Camiones_Carga_Descarga_Grabar '0','" & Txtfolio.Text.Trim & "','0','0','" & Frm_Principal.InfoUsuario.Text.Trim & "'"
                        fnc.MovimientoSQL(sqlCarDes)
                    End If
                    'Fin actualización Cierre camiones carga y descarga. 07-06-19

                    MsgBox("Información actualizada correctamente", MsgBoxStyle.Information, "Aviso")
                    btn_guardar.Enabled = False
                Else
                    MsgBox("Error al Actualizar la información", MsgBoxStyle.Critical, "Aviso")
                End If


            End If

            Dim sqlCont = "sp_zCheckList_Contenedores_grabar '" & Txtfolio.Text.Trim & "','" & txtNroCont.Text.Trim & "'"
            If (fnc.MovimientoSQL(sqlCont) = 0) Then
                MsgBox("Ocurrió un error al registrar el Nro. Contenedor.", MsgBoxStyle.Critical, "Aviso")
            End If

        End If
    End Sub

    Function Valida_Registro() As Boolean

        Dim mensaje As String = ""
        Valida_Registro = True


        If fnc.verificaExistencia("Clientes", "cli_rut", TxtClirut.Text + "" + TxtCliVeri.Text) = False Then
            mensaje = mensaje + "- Cliente no registrado" + vbCrLf
            Valida_Registro = False
        End If

        If fnc.verificaExistencia("Choferes", "cho_rut", TxtChoRut.Text + "" + TxtChoVeri.Text) = False Then
            mensaje = mensaje + "- Chofer no registrado" + vbCrLf
            Valida_Registro = False
        End If

        If txtempresa.Text.Trim = "" Then
            mensaje = mensaje + "- Nombre de la empresa " + vbCrLf
            Valida_Registro = False
        End If

        If txtpatente.Text.Trim = "" Then
            mensaje = mensaje + "- Patente no registrada" + vbCrLf
            Valida_Registro = False
        End If

        If TemIng.Text.Trim = "" AndAlso CmboMovimiento.SelectedValue = 1 Then
            mensaje = mensaje + "- Temperatura no registrada" + vbCrLf
            Valida_Registro = False
        End If

        If CmboContenedor.SelectedValue = 0 Then
            mensaje = mensaje + "- Tipo de contenedor " + vbCrLf
            Valida_Registro = False
        End If

        If CmboMovimiento.SelectedValue = 0 Then
            mensaje = mensaje + "- Tipo de Movimiento " + vbCrLf
            Valida_Registro = False
        End If

        If (CmboContenedor.SelectedValue.ToString.Trim = "3" And txtNroCont.Text.Trim = "") Then
            mensaje = mensaje + "- Debe ingresar Nro. Contenedor " + vbCrLf
            Valida_Registro = False
        End If

        If mensaje.Trim <> "" Then
            MsgBox("Debe verificar lo siguiente antes de guardar la información" + vbCrLf + mensaje, MsgBoxStyle.Critical, "Aviso")
        End If

        Return Valida_Registro
    End Function

    Private Sub btn_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        If Txtfolio.Text <> "" Then
            If fnc.verificaExistencia("zChecklist", "cl_fol", Txtfolio.Text) = False Then
                If Txtfolio.Enabled = False Then
                    If MsgBox("Desea salir del ingreso", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbYes Then
                        CancelaCorrelativo("100", Txtfolio.Text)
                        limpiarFormulario()
                    End If
                Else
                    limpiarFormulario()
                End If
            Else
                limpiarFormulario()
            End If
        Else
            Txtfolio.Focus()
        End If
    End Sub

    Private Sub limpiarFormulario()
        LimpiarCajas(GroupBox1)
        CmboContenedor.SelectedValue = 0
        CmboMovimiento.SelectedValue = 0
        Txtfolio.Enabled = True
        Txtfolio.Text = ""
        Txtfolio.Focus()
        GroupBox1.Enabled = False
        BtnAyuda.Enabled = True
        BtnImagenes.Visible = False

        Label15.Font = New Font(Label15.Font, Label15.Font.Style And Not FontStyle.Strikeout)
        Label16.Font = New Font(Label16.Font, Label16.Font.Style And Not FontStyle.Strikeout)

        LblFecIng.Text = "00-00-0000"
        LblFecSal.Text = "00-00-0000"
        LblFecLleg.Text = "00-00-0000"

        HorLleg.Text = ""
        HorIng.Text = ""
        HorSal.Text = ""

        txtNroCont.Text = ""
        txtNroCont.Enabled = True
    End Sub

    Private Sub BtnAyuda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAyuda.Click
        Dim f As New Frm_CheckListAyuda
        f.ShowDialog(Frm_Principal)
        If Frm_Principal.buscavalor.ToString() <> "" Then
            RescataCheckList(Frm_Principal.buscavalor.ToString())
        End If
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub BtnImagenes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImagenes.Click
        Dim f As New Frm_ListarFotos
        f.codigo = Me.Txtfolio.Text
        f.ShowDialog()
    End Sub

    Private Sub BtnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImprimir.Click
        If Txtfolio.Enabled = False Then

            Dim frm As Frm_MuestraReporte = New Frm_MuestraReporte

            Dim report As New Rpt_CheckList

            Dim PictureBox1 As New PictureBox
            Dim PictureBox2 As New PictureBox
            Dim PictureBox3 As New PictureBox
            Dim PictureBox4 As New PictureBox
            Dim PictureBox5 As New PictureBox
            Dim PictureBox6 As New PictureBox
            Dim PictureBox7 As New PictureBox

            Dim SqlImagen As String = "SELECT  Convert(varchar(max),Convert(Varbinary(MAX),cl_imgtem)) , " +
                                      "        Convert(varchar(max),Convert(Varbinary(MAX),cl_imgsel)) , " +
                                      "        Convert(varchar(max),Convert(Varbinary(MAX),cl_imgpat)) , " +
                                      "        Convert(varchar(max),Convert(Varbinary(MAX),cl_imgtemS)), " +
                                      "        Convert(varchar(max),Convert(Varbinary(MAX),cl_imgselS)), " +
                                      "        Convert(varchar(max),Convert(Varbinary(MAX),cl_imgpatS)),  " +
                                      "        Convert(varchar(max),Convert(Varbinary(MAX),cl_imgrutS))  " +
                                      "   FROM chk_images " +
                                      "  WHERE id_chk = '" + Convert.ToInt32(Txtfolio.Text).ToString() + "'"

            Dim tablaimagen As DataTable = fnc.ListarTablasSQL(sqlImagen)

            If tablaimagen.Rows.Count > 0 Then

                'Imagen1
                If tablaimagen.Rows(0)(0).ToString() <> "" Then
                    PictureBox1.Image = Base64ToImage(tablaimagen.Rows(0)(0).ToString())
                Else
                    PictureBox1.Image = My.Resources.blanco
                End If

                'Imagen2
                If tablaimagen.Rows(0)(1).ToString() <> "" Then
                    PictureBox2.Image = Base64ToImage(tablaimagen.Rows(0)(1).ToString())
                Else
                    PictureBox2.Image = My.Resources.blanco
                End If

                'Imagen3
                If tablaimagen.Rows(0)(2).ToString() <> "" Then
                    PictureBox3.Image = Base64ToImage(tablaimagen.Rows(0)(2).ToString())
                Else
                    PictureBox3.Image = My.Resources.blanco
                End If

                'Imagen4
                If tablaimagen.Rows(0)(3).ToString() <> "" Then
                    PictureBox4.Image = Base64ToImage(tablaimagen.Rows(0)(3).ToString())
                Else
                    PictureBox4.Image = My.Resources.blanco
                End If

                'Imagen5
                If tablaimagen.Rows(0)(4).ToString() <> "" Then
                    PictureBox5.Image = Base64ToImage(tablaimagen.Rows(0)(4).ToString())
                Else
                    PictureBox5.Image = My.Resources.blanco
                End If

                'Imagen6
                If tablaimagen.Rows(0)(5).ToString() <> "" Then
                    PictureBox6.Image = Base64ToImage(tablaimagen.Rows(0)(5).ToString())
                Else
                    PictureBox6.Image = My.Resources.blanco
                End If

                'ImagenRUT
                If tablaimagen.Rows(0)(6).ToString() <> "" Then
                    PictureBox7.Image = Base64ToImage(tablaimagen.Rows(0)(6).ToString())
                Else
                    PictureBox7.Image = My.Resources.blanco
                End If

            Else
                PictureBox1.Image = My.Resources.blanco
                PictureBox2.Image = My.Resources.blanco
                PictureBox3.Image = My.Resources.blanco
                PictureBox4.Image = My.Resources.blanco
                PictureBox5.Image = My.Resources.blanco
                PictureBox6.Image = My.Resources.blanco
                PictureBox7.Image = My.Resources.blanco
            End If

            Dim Ds As New Ds_Imagenes

            Ds.Imagenes.AddImagenesRow(ImageToByte(PictureBox1.Image), ImageToByte(PictureBox2.Image), ImageToByte(PictureBox3.Image), ImageToByte(PictureBox4.Image), ImageToByte(PictureBox5.Image), ImageToByte(PictureBox6.Image), ImageToByte(PictureBox7.Image))
            report.Subreports(0).SetDataSource(Ds)

            report.SetDatabaseLogon(Usuario_ODBC, Pass_ODBC)
            report.SetParameterValue("codigo", Txtfolio.Text)

            frm.Contenedor.ReportSource = report
            frm.ShowDialog()
        End If
    End Sub

    Private Sub TxtChoRut_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtChoRut.KeyPress
        If e.KeyChar = ChrW(13) Then
            TxtChoVeri.Focus()
        End If
    End Sub

    Private Sub TxtChoVeri_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtChoVeri.KeyPress
        If e.KeyChar = ChrW(13) Then
            If TxtChoRut.Text.Length = 8 AndAlso TxtChoVeri.Text.Length = 1 Then
                If fnc.verificaExistencia("choferes", "cho_rut", TxtChoRut.Text + "" + TxtChoVeri.Text) = True Then
                    Dim SqlChofer As String = "SELECT cho_empresa, cho_nombre, cho_patente, cho_patente2 " +
                                     "FROM choferes WHERE cho_rut='" + TxtChoRut.Text + "" + TxtChoVeri.Text + "' "

                    Dim tabla As DataTable = fnc.ListarTablasSQL(SqlChofer)

                    If tabla.Rows.Count > 0 Then
                        txtpatente.Text = tabla.Rows(0)(2).ToString()
                        TxtRampla.Text = tabla.Rows(0)(3).ToString()
                        txtempresa.Text = tabla.Rows(0)(0).ToString()
                        TxtChoNombre.Text = tabla.Rows(0)(1).ToString()
                        TxtChoRut.Enabled = False
                        TxtChoVeri.Enabled = False
                    End If
                Else
                    MsgBox("El rut ingresado no existe", MsgBoxStyle.Critical, "Aviso")
                End If
            Else
                MsgBox("El rut ingresado no tiene la totalidad de caracteres", MsgBoxStyle.Critical, "Aviso")
            End If
        End If
    End Sub

    Private Sub btneliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btneliminar.Click
        If RealizarAccion("017", "097", True) = False Then
            Exit Sub
        End If

        Dim _ver = "SELECT cl_ing, cl_des FROM zchecklist WHERE cl_fol='" + Txtfolio.Text + "'"
        Dim tb As DataTable = fnc.ListarTablasSQL(_ver)

        If tb.Rows.Count > 0 Then
             
            If tb.Rows(0)(1).ToString() <> "" Then
                MsgBox("No se puede eliminar el registro porque el camión ya se retiro", MsgBoxStyle.Critical, "Aviso")
                Return
            End If
            If tb.Rows(0)(0).ToString() <> "" Then
                MsgBox("No se puede eliminar el registro porque el camión ya ingreso a anden", MsgBoxStyle.Critical, "Aviso")
                Return
            End If

            If MsgBox("¿Seguro de eliminar el registro?", MsgBoxStyle.YesNo + MsgBoxStyle.Information, "Aviso") = vbYes Then

                Dim _sql = "DELETE FROM zchecklist WHERE cl_fol='" + Txtfolio.Text + "'"
                If fnc.MovimientoSQL(_sql) > 0 Then
                    Dim sqlEliNroCont = "delete from zCheckList_Contenedores where cl_fol='" & Txtfolio.Text & "'"

                    Dim resp = fnc.MovimientoSQL(sqlEliNroCont)
                    MsgBox("Registro eliminado correctamente", MsgBoxStyle.Information, "Aviso")
                    limpiarFormulario()
                Else
                    MsgBox("Error al eliminar el registro", MsgBoxStyle.Critical, "Aviso")
                End If

            End If
        Else
            MsgBox("No se puede eliminar el registro", MsgBoxStyle.Critical, "Aviso")
        End If

    End Sub

    Private Sub Txtfolio_TextChanged(sender As System.Object, e As System.EventArgs) Handles Txtfolio.TextChanged

    End Sub

    Private Sub CmboContenedor_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles CmboContenedor.SelectedIndexChanged
        Try
            Dim cboCont = CmboContenedor.SelectedValue.ToString.Trim
            If (cboCont = "3") Then
                txtNroCont.Text = ""
                txtNroCont.Enabled = True
            Else
                txtNroCont.Text = ""
                txtNroCont.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmboMovimiento_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles CmboMovimiento.SelectedIndexChanged
        Dim Mov = CmboMovimiento.Text.Trim
        If (Mov.Contains("DESCARGA")) Then
            txtGui.Enabled = True
            txtSell.Enabled = True
        Else
            txtGui.Text = ""
            txtSell.Text = ""

            txtGui.Enabled = False
            txtSell.Enabled = False
        End If
    End Sub
End Class
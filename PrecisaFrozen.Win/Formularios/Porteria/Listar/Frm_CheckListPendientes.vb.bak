Public Class Frm_CheckListPendientes

    Dim fnc As New Funciones

    Private Sub Frm_CheckListPendientes_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        f_listadocamion = False
    End Sub

    Private Sub Frm_CheckListPendientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        DgvRegistrados.DataSource = fnc.ListarTablasSQL("SELECT cl_fol, cli_nomb, cl_pate, mov_desc FROM P_MovChecklist, clientes, " +
                                                        "zCheckList WHERE cli_rut=cl_rutcli AND cl_mov=mov_codi AND " +
                                                        "cl_Estpor='0'")

        DgvContenedores.DataSource = fnc.ListarTablasSQL("SELECT cl_fol, cli_nomb, cl_pate, mov_desc FROM P_MovChecklist, clientes, " +
                                                        "zCheckList WHERE cli_rut=cl_rutcli AND cl_mov=mov_codi AND " +
                                                        "cl_Estpor='3'")

        DgvAndenes.DataSource = fnc.ListarTablasSQL("SELECT cl_fol, cli_nomb, cl_pate, mov_desc FROM P_MovChecklist, clientes, " +
                                                        "zCheckList WHERE cli_rut=cl_rutcli AND cl_mov=mov_codi AND " +
                                                        "cl_Estpor='1'")

        Mov.Start()
    End Sub
 
 
    Private Sub BtnActualizaIngreso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnActualizaIngreso.Click

        If MsgBox("Seguro de Ingresar el camion", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbYes Then

            Dim sql As String = ""

            If RbAndenes.Checked = True Then
                If Not IsNumeric(TxtAnden.Text) Then
                    MsgBox("Debe seleccionar un anden", MsgBoxStyle.Critical, "Aviso")
                    Exit Sub
                Else
                    If TxtAnden.Text > 6 Then
                        MsgBox("Solo existen 6 andenes en la planta", MsgBoxStyle.Critical, "Aviso")
                        Exit Sub
                    End If
                End If
                sql = "UPDATE zCheckList SET cl_Estpor='1', cl_ing='" + fnc.DevuelveFechaServidor().ToString() + "', cl_anden='" + TxtAnden.Text + "', cl_gs='" + Frm_Principal.InfoUsuario.Text + "' " +
                    "WHERE cl_fol='" + lblfolio.Text + "'"
            ElseIf RbContenedores.Checked = True Then
                sql = "UPDATE zCheckList SET cl_Estpor='3', cl_CargContenedor='" + fnc.DevuelveFechaServidor().ToString() + "', cl_gs='" + Frm_Principal.InfoUsuario.Text + "' WHERE cl_fol='" + lblfolio.Text + "'"
            ElseIf Rb_SectorSur.Checked = True Then
                sql = "UPDATE zCheckList SET cl_Estpor='1', cl_ing='" + fnc.DevuelveFechaServidor().ToString() + "', cl_anden='S. SUR', cl_gs='" + Frm_Principal.InfoUsuario.Text + "' " +
                   "WHERE cl_fol='" + lblfolio.Text + "'"
            End If
            If sql.Length = 0 Then
                MsgBox("Debe seleccionar la ubicacion de destino", MsgBoxStyle.Information, "Aviso")
                Exit Sub
            End If
            If fnc.MovimientoSQL(sql) > 0 Then
                MsgBox("Información Actualizada Correctamente", MsgBoxStyle.Information, "Aviso")
                GroupBox1.Visible = False
                RbAndenes.Checked = False
                RbContenedores.Checked = False

            Else
                MsgBox("Error al modificar ubicacion", MsgBoxStyle.Information, "Aviso")
            End If

        End If
    End Sub

    Private Sub btn_CancelaIngreso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_CancelaIngreso.Click
        GroupBox1.Visible = False
    End Sub

    Private Sub BtnActualizaSalida_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnActualizaSalida.Click
        If TxtTemp.Text <> "" Then

            If Not verificaCierreAnden(lblfolio.Text) Then
                Exit Sub
            End If

            Dim sql As String
            sql = "  UPDATE zCheckList SET cl_Estpor='2', cl_des='" + fnc.DevuelveFechaServidor().ToString() + "',Cl_DesTemp ='" + TxtTemp.Text + "'"
            sql += " WHERE cl_fol='" + lblfolio.Text + "'"

            If fnc.MovimientoSQL(sql) > 0 Then
                MsgBox("Información Actualizada Correctamente", MsgBoxStyle.Information, "Aviso")
                GroupBox2.Visible = False
                TxtTemp.Text = ""
            Else
                MsgBox("Error al despachar el camion de la planta", MsgBoxStyle.Information, "Aviso")
            End If

        Else
            MsgBox("Favor Ingrese Temperatura de Salida", MsgBoxStyle.Information, "Aviso")
        End If

    End Sub

    Private Sub BtnCancelaSalida_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelaSalida.Click
        GroupBox2.Visible = False
        TxtTemp.Text = ""
    End Sub

    Private Sub DgvContenedores_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvContenedores.CellClick
        If e.RowIndex > -1 AndAlso e.ColumnIndex = 0 Then
            If RealizarAccion("017", "044", True) = False Then
                Exit Sub
            End If
            If MsgBox("Seguro de Ingresar el Camion a Anden", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbYes Then
                lblfolio.Text = Me.DgvContenedores.Rows(e.RowIndex).Cells(1).Value.ToString()
                Dim sql As String = "UPDATE zCheckList SET cl_Estpor='1', cl_ing='" + fnc.DevuelveFechaServidor().ToString() + "' WHERE cl_fol='" + lblfolio.Text + "'"
                If fnc.MovimientoSQL(sql) > 0 Then
                    MsgBox("Información Actualizada Correctamente", MsgBoxStyle.Information, "Aviso")
                End If
            End If
        End If
    End Sub

    Private Sub DgvAndenes_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvAndenes.CellClick
        GroupBox2.Visible = False
        If e.RowIndex > -1 AndAlso e.ColumnIndex = 0 Then
            If RealizarAccion("017", "044", True) = False Then
                Exit Sub
            End If
            If MsgBox("Seguro de Despachar el camion", MsgBoxStyle.Question + vbYesNo, "Aviso") = vbYes Then
                GroupBox2.Visible = True
                lblfolio.Text = Me.DgvAndenes.Rows(e.RowIndex).Cells(1).Value.ToString()
            End If
        End If
    End Sub

    Private Sub DgvRegistrados_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvRegistrados.CellClick
        GroupBox1.Visible = False
        If e.RowIndex > -1 AndAlso e.ColumnIndex = 0 Then
            If RealizarAccion("017", "044", True) = False Then
                Exit Sub
            End If
            'Dim sql As String = "UPDATE zCheckList SET cl_Estpor='1', cl_ WHERE cl_fol='" + Me.DgvRegistrados.Rows(e.RowIndex).Cells(0).Value.ToString() + "'"
            If MsgBox("Seguro de ingresar el camion", MsgBoxStyle.Question + vbYesNo, "Aviso") = vbYes Then
                lblfolio.Text = Me.DgvRegistrados.Rows(e.RowIndex).Cells(1).Value.ToString()
                GroupBox1.Visible = True
                GroupBox1.Location = New Point(869, 47)
            Else
                GroupBox1.Visible = False
            End If
        End If
    End Sub

    Private Sub Mov_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Mov.Tick

        '0 camiones registrados.-
        '3 camiones en carga de contenedores.-
        '1 camiones en anden.-
        '2 camion ya retirado.-


        DgvRegistrados.DataSource = fnc.ListarTablasSQL("SELECT cl_fol, cli_nomb, cl_pate, mov_desc FROM zmovimientos, clientes, " +
                                                   "zCheckList WHERE cli_rut=cl_rutcli AND cl_mov=mov_codi AND " +
                                                   "cl_Estpor='0'")

        DgvContenedores.DataSource = fnc.ListarTablasSQL("SELECT cl_fol, cli_nomb, cl_pate, mov_desc FROM zmovimientos, clientes, " +
                                                        "zCheckList WHERE cli_rut=cl_rutcli AND cl_mov=mov_codi AND " +
                                                        "cl_Estpor='3'")

        DgvAndenes.DataSource = fnc.ListarTablasSQL("SELECT cl_fol, cli_nomb, cl_pate, mov_desc FROM zmovimientos, clientes, " +
                                                        "zCheckList WHERE cli_rut=cl_rutcli AND cl_mov=mov_codi AND " +
                                                        "cl_Estpor='1'")
    End Sub
 
    Private Sub TxtTempIng_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtTemp.KeyPress
        Dim x As TextBox = sender
        If Not IsNumeric(e) Then
            If e.KeyChar = "." Or e.KeyChar = ChrW(8) Or e.KeyChar = "-" Then
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

    Private Sub RbAndenes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbAndenes.CheckedChanged
        If RbAndenes.Checked = True Then
            TxtAnden.Visible = True
        Else
            TxtAnden.Visible = False
        End If
    End Sub

    Private Sub TxtAnden_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAnden.KeyPress
        SoloNumeros(sender, e)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Frm_ListadoPorteria.ShowDialog()

    End Sub

    Function verificaCierreAnden(ByVal folio As String) As Boolean

        Dim where As String = "folio = '" + folio + "' AND tip_mov = 'CIERRE'"

        If fnc.verificaExistenciaCondicional("AndenesReg", where.ToString()) Then
            Dim ExiRec As Boolean = True
            Dim ExiDes As Boolean = True
            Dim ExiReg As Boolean = True

            If fnc.verificaExistencia("fichrece", "frec_clfol", folio) = True Then
                Dim Sql As String = "SELECT Cl_Ting, frec_guiades, frec_totsopo, frec_codi FROM zCheckList, fichrece WHERE Cl_fol=frec_clfol AND Cl_fol='" + folio + "'"
                Dim tabla As DataTable = fnc.ListarTablasSQL(Sql)
                If tabla.Rows.Count <= 0 Then
                    ExiRec = False
                End If
            End If

            If fnc.verificaExistencia("fichdespa", "fdes_clfol", folio) = True Then
                Dim sql As String = "SELECT Cl_DesTemp, fdes_GuiaCliente, fdes_totsopo, fdes_codi FROM zCheckList, fichdespa WHERE Cl_fol=fdes_clfol AND Cl_fol='" + folio + "'"
                Dim tabla As DataTable = fnc.ListarTablasSQL(sql)
                If tabla.Rows.Count > 0 Then
                    If tabla.Rows.Count <= 0 Then
                        ExiDes = False
                    End If
                End If
            End If

            If (Not ExiRec And Not ExiDes) Then
                ExiReg = False
                MsgBox("El Camión aun no ha sido vinculado a ninguna Recepción o Despacho.", MsgBoxStyle.Information, "Aviso")
            End If

            Return ExiReg
        Else
            MsgBox("Andén aún no ha sido cerrado desde REDE", MsgBoxStyle.Information, "Aviso")
            Return False
        End If

        Return True
    End Function
End Class
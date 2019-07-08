Public Class Frm_AddChoferes

    Dim fnc As New Funciones

    '--------------------------------- BUSCA VARIABLE -----------------------------

    'Public Sub ChangeTextBoxText(text As String, text2 As String) Implements IForm.ChangeTextBoxText
    '    clirut.Text = text

    '    If Len(clirut.Text) >= 10 Then

    '        Dim SqlBusca As String = "SELECT cli_nomb FROM clientes WHERE " +
    '            "cli_rut='" + QuitarCaracteres(clirut.Text) + "'"

    '        Dim tabla As DataTable = fnc.ListarTablasSQL(SqlBusca)

    '        If tabla.Rows.Count > 0 Then
    '            clinombre.Text = tabla.Rows(0)(0)
    '            lblmensaje.Visible = False
    '        Else
    '            lblmensaje.Visible = True
    '        End If

    '    Else
    '        clinombre.Text = ""
    '        lblmensaje.Visible = False

    '    End If

    'End Sub
    '--------------------------------- BUSCA VARIABLE -----------------------------

    Function validacion() As Integer
        If RutDigito(chorut.Text.ToUpper) = False Then
            MsgBox("Rut Chofer incorrecto", MsgBoxStyle.Critical, "Aviso")
            Return 1
            Exit Function
        ElseIf chonombre.Text = "" Then
            MsgBox("Ingrese Nombre", MsgBoxStyle.Critical, "Aviso")
            Return 1
            Exit Function
        ElseIf chopatente.Text = "" Then
            MsgBox("Ingrese Patente", MsgBoxStyle.Critical, "Aviso")
            Return 1
            Exit Function
        ElseIf empnombre.Text.Trim = "" Then
            MsgBox("Ingrese Empresa", MsgBoxStyle.Critical, "Aviso")
            Return 1
            Exit Function
        ElseIf RutDigito(clirut.Text) = False Then
            MsgBox("Rut Cliente incorrecto", MsgBoxStyle.Critical, "Aviso")
            Return 1
            Exit Function
        End If

        Return 0
    End Function

    Private Sub Frm_AddChoferes_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        f_addchoferes = False
        btn_nuevo_Click(sender, e)
    End Sub

    Private Sub cli_rut_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles clirut.KeyUp
        If Len(clirut.Text) >= 10 Then

            Dim SqlBusca As String = "SELECT cli_nomb FROM clientes WHERE " +
                "cli_rut='" + QuitarCaracteres(clirut.Text) + "'"

            Dim tabla As DataTable = fnc.ListarTablasSQL(SqlBusca)

            If tabla.Rows.Count = 1 Then
                clinombre.Text = tabla.Rows(0)(0)
                lblmensaje.Visible = False

            Else

                lblmensaje.Visible = True
            End If

        Else
            clinombre.Text = ""
            lblmensaje.Visible = False

        End If
    End Sub

    Private Sub cli_rut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles clirut.Click
        clirut.SelectAll()
    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click

        If validacion() = 0 Then

            Dim valor As Boolean = fnc.verificaExistenciaCondicional("choferes", " cho_rut='" + QuitarCaracteres(chorut.Text) + "'")


            If valor = False Then

                If chorut.Text.Length < 8 Then
                    MsgBox("Debe agregar el rut completo", MsgBoxStyle.Information, "Aviso")
                    Exit Sub
                End If

                If emprut.Text.Length < 8 Then
                    MsgBox("Debe agregar el rut completo de transportista", MsgBoxStyle.Information, "Aviso")
                    Exit Sub
                End If

                Dim lnchofer As String
                If chkchofer.Checked Then
                    lnchofer = 1
                Else
                    lnchofer = 0
                End If

                Dim lnpatente As String
                If chkpatente.Checked Then
                    lnpatente = 1
                Else
                    lnpatente = 0
                End If

                Dim lnrampla As String
                If chkrampla.Checked Then
                    lnrampla = 1
                Else
                    lnrampla = 0
                End If

                Dim SqlGuardaChofer As String = "INSERT INTO choferes(cho_rut, cho_rutclie, cho_nombre, cho_patente, " +
                    "cho_empresa, cho_rutempresa, cho_patente2, cho_listanegra, cho_observacion)VALUES(" +
                    "'" + QuitarCaracteres(chorut.Text) + "','" + QuitarCaracteres(clirut.Text) + "'," +
                    "'" + chonombre.Text + "','" + chopatente.Text + "'," +
                    "'" + empnombre.Text + "','" + QuitarCaracteres(emprut.Text) + "','" + txtrampla.Text + "','" + lnchofer + "','" + txtobservchofer.Text + "')"

                If fnc.MovimientoSQL(SqlGuardaChofer) > 0 Then
                    MsgBox("Chofer agregado correctamente", MsgBoxStyle.Information, "Aviso")
                Else
                    MsgBox("Error al agregar el chofer", MsgBoxStyle.Information, "Aviso")

                End If

            Else
                If RealizarAccion("007", "018") = False Then
                    Exit Sub
                End If

                Dim lnchofer As String
                If chkchofer.Checked Then
                    lnchofer = 1
                Else
                    lnchofer = 0
                End If

                Dim lnpatente As String
                If chkpatente.Checked Then
                    lnpatente = 1
                Else
                    lnpatente = 0
                End If

                Dim lnrampla As String
                If chkrampla.Checked Then
                    lnrampla = 1
                Else
                    lnrampla = 0
                End If

                Dim SqlModificaChofer As String = "UPDATE choferes SET cho_nombre='" + chonombre.Text + "',  cho_patente='" + chopatente.Text + "', cho_patente2='" + txtrampla.Text + "' " +
                    ", cho_rutclie='" + QuitarCaracteres(clirut.Text) + "', cho_listanegra='" + lnchofer + "', cho_observacion='" + txtobservchofer.Text + "', Cho_rutempresa='" + QuitarCaracteres(emprut.Text) + "', cho_empresa='" + empnombre.Text + "'WHERE " +
                    " cho_rut='" + QuitarCaracteres(chorut.Text) + "'"

                If fnc.MovimientoSQL(SqlModificaChofer) > 0 Then
                    MsgBox("Chofer actualizado correctamente", MsgBoxStyle.Information, "Aviso")
                    Dim SqlBuscarPatente As String = "SELECT lnpat_cod FROM ListaNegraPatente WHERE lnpat_pat='" + chopatente.Text + "'"
                    Dim patente As DataTable = fnc.ListarTablasSQL(SqlBuscarPatente)
                    If patente.Rows.Count > 0 Then
                        Dim SqlUpdatePatente As String = "UPDATE ListaNegraPatente SET lnpat_est='" + lnpatente + "', lnpat_obs='" + txtobservpatente.Text + "' WHERE lnpat_pat='" + chopatente.Text + "'"
                        fnc.MovimientoSQL(SqlUpdatePatente)
                    Else
                        Dim SqlInsertPatente As String = "INSERT INTO ListaNegraPatente(lnpat_pat,lnpat_est,lnpat_obs)VALUES('" + chopatente.Text + "','" + lnpatente + "','" + txtobservpatente.Text + "')"
                        fnc.MovimientoSQL(SqlInsertPatente)
                    End If

                    Dim SqlBuscarRampla As String = "SELECT lnrpl_cod FROM ListaNegraRampla WHERE lnrpl_rpl='" + txtrampla.Text + "'"
                    Dim rampla As DataTable = fnc.ListarTablasSQL(SqlBuscarRampla)
                    If rampla.Rows.Count > 0 Then
                        Dim SqlUpdateRampla As String = "UPDATE ListaNegraRampla SET lnrpl_est='" + lnrampla + "', lnrpl_obs='" + txtobservrampla.Text + "' WHERE lnrpl_rpl='" + txtrampla.Text + "'"
                        fnc.MovimientoSQL(SqlUpdateRampla)
                    Else
                        Dim SqlInsertRampla As String = "INSERT INTO ListaNegraRampla(lnrpl_rpl,lnrpl_est,lnrpl_obs)VALUES('" + txtrampla.Text + "','" + lnrampla + "','" + txtobservrampla.Text + "')"
                        fnc.MovimientoSQL(SqlInsertRampla)
                    End If
                Else
                    MsgBox("Error al actualizar el chofer", MsgBoxStyle.Information, "Aviso")
                End If

            End If
        End If

    End Sub

    Private Sub chorut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chorut.Click
        chorut.SelectAll()
    End Sub

    Private Sub btn_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        LimpiarCajas(GroupBox3)
        LimpiarCajas(GroupBox4)
        LimpiarCajas(GroupBox5)
        chorut.Enabled = True
        LimpiarCajasMaskedTextBox(GroupBox4)
        LimpiarCajasMaskedTextBox(GroupBox5)
        chorut.Text = ""
        chorut.Focus()
        empnombre.Enabled = True
        emprut.Enabled = True
    End Sub

    Private Sub chorut_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles chorut.KeyUp
        If Len(chorut.Text) >= 10 Then
            If e.KeyCode = Keys.Enter Then
                If RealizarAccion("007", "017") = False Then
                    Exit Sub
                End If
                If RutDigito(chorut.Text.ToUpper) = False Then
                    MsgBox("Verifique el rut del chofer, el rut ingresado no es correcto", MsgBoxStyle.Critical, "Aviso")
                    Exit Sub
                End If
                chonombre.Focus()
                chorut.Enabled = False
            End If
            If RutDigito(chorut.Text.ToUpper()) = True Then
                lblrutcho.Text = "Rut Correcto"
                lblrutcho.ForeColor = Color.Blue
            Else
                lblrutcho.Text = "Rut Incorrecto"
                lblrutcho.ForeColor = Color.Red
            End If

            Dim sql As String = "SELECT cho_rut, cho_rutclie, cho_nombre, cho_patente, " +
                    "cho_empresa, cho_rutempresa, cho_patente2, cli_nomb   FROM choferes, clientes WHERE " +
                    "cho_rutclie=cli_rut AND cho_rut='" + QuitarCaracteres(chorut.Text) + "'"

            Dim tabla As DataTable = fnc.ListarTablasSQL(sql)
            If tabla.Rows.Count = 1 Then
                chorut.Text = tabla.Rows(0)(0).ToString()
                chonombre.Text = tabla.Rows(0)(2).ToString()
                chopatente.Text = tabla.Rows(0)(3).ToString()
                txtrampla.Text = tabla.Rows(0)(6).ToString()
                If tabla.Rows(0)(5).ToString <> "" AndAlso tabla.Rows(0)(5).ToString.Length > 9 Then
                    emprut.Text = tabla.Rows(0)(5).ToString().Remove(0, 4)
                ElseIf tabla.Rows(0)(5).ToString.Length = 9 Then
                    emprut.Text = tabla.Rows(0)(5).ToString()
                End If
                empnombre.Text = tabla.Rows(0)(4).ToString()
                clirut.Text = tabla.Rows(0)(1).ToString()
                clinombre.Text = tabla.Rows(0)(7).ToString()
                chorut.Enabled = False


                lblrutcho.Text = "Rut Correcto"
                lblrutcho.ForeColor = Color.Blue

            ElseIf tabla.Rows.Count > 1 Then

                Dim frm As New Frm_UtilidadChoferes
                Dim tablaList As New DataTable
                tablaList.Columns.Add("Codigo")
                tablaList.Columns.Add("Nombre")
                tablaList.Columns.Add("Empresa")

                For i As Integer = 0 To tabla.Rows.Count - 1
                    tablaList.Rows.Add(tabla.Rows(i)(1), tabla.Rows(i)(7), tabla.Rows(i)(4))
                Next

                '  frm.KryptonDataGridView1.DataSource = tablaList
                'frm.KryptonDataGridView1.ValueMember = "Codigo"
                'frm.KryptonDataGridView1.DisplayMember = "Nombre"

                frm.ShowDialog(Frm_Principal)
                '------------------------------>

                Dim Busca As String = "SELECT cho_rut, cho_rutclie, cho_nombre, cho_patente, " +
                                      "cho_empresa, cho_rutempresa, cho_patente2, cli_nomb FROM choferes, clientes WHERE " +
                                      "cho_rutclie=cli_rut AND cho_rut='" + QuitarCaracteres(chorut.Text) + "' AND cho_rutclie='" + Frm_Principal.InfoUsuario.ToString() + "'"

                Dim dt As DataTable = fnc.ListarTablasSQL(Busca)
                If tabla.Rows.Count > 0 Then
                    chorut.Text = dt.Rows(0)(0).ToString()
                    chonombre.Text = dt.Rows(0)(2).ToString()
                    chopatente.Text = dt.Rows(0)(3).ToString()
                    txtrampla.Text = dt.Rows(0)(6).ToString()
                    emprut.Text = dt.Rows(0)(5).ToString()
                    empnombre.Text = dt.Rows(0)(4).ToString()
                    clirut.Text = dt.Rows(0)(1).ToString()
                    clinombre.Text = dt.Rows(0)(7).ToString()
                    lblrutcho.Text = "Rut Correcto"
                    lblrutcho.ForeColor = Color.Blue
                Else

                    LimpiarCajas(GroupBox3)
                    LimpiarCajas(GroupBox4)
                    LimpiarCajas(GroupBox5)
                    LimpiarCajasMaskedTextBox(GroupBox4)
                    LimpiarCajasMaskedTextBox(GroupBox5)

                End If
                '------------------------------>
            End If
        ElseIf Len(QuitarCaracteres(chorut.Text)) = 0 Then
            lblrutcho.Text = "Ingrese Rut"
            lblrutcho.ForeColor = Color.Red
        End If

    End Sub

    Private Sub btn_eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_eliminar.Click
        If MsgBox("Seguro de eliminar el chofer seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbYes Then
            If MsgBox("Está seguro de eliminar el chofer", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Aviso") = vbYes Then

                Dim Elimina As String = "DELETE FROM choferes WHERE " +
                    "cho_rut='" + chorut.Text.Replace("-", "") + "'"

                If fnc.MovimientoSQL(Elimina) > 0 Then
                    MsgBox("Registro Eliminado", MsgBoxStyle.Information, "Aviso")
                    btn_nuevo_Click(sender, e)
                    chorut.Text = ""
                End If


            End If
        End If
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Close()
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim frm As New Lst_AyudaClientes
        frm.ShowDialog(Frm_Principal)

        If Len(Frm_Principal.buscavalor) >= 9 Then
            clirut.Text = Frm_Principal.buscavalor.ToString
            clinombre.Text = RetornaCliente(QuitarCaracteres(Frm_Principal.buscavalor.ToString))

            If clinombre.Text <> "" Then
                lblmensaje.Visible = False
            Else
                lblmensaje.Visible = True
            End If
        Else
            clinombre.Text = ""
            lblmensaje.Visible = False
        End If
    End Sub



    Private Sub Frm_AddChoferes_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub chkchofer_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkchofer.CheckedChanged
        If chkchofer.Checked Then
            txtobservchofer.Visible = True
        Else
            txtobservchofer.Visible = False
        End If
    End Sub

    Private Sub chkpatente_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkpatente.CheckedChanged
        If chkpatente.Checked Then
            txtobservpatente.Visible = True
        Else
            txtobservpatente.Visible = False
        End If
    End Sub

    Private Sub chkrampla_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkrampla.CheckedChanged
        If chkrampla.Checked Then
            txtobservrampla.Visible = True
        Else
            txtobservrampla.Visible = False
        End If
    End Sub
End Class
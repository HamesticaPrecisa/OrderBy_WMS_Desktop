Public Class Lst_Choferes

    Dim fnc As New Funciones


    Private Sub Lst_Choferes_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        f_lstChoferes = False
    End Sub

 
    Private Sub ToolStripButton2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton2.Click
        Frm_AddChoferes.ShowDialog()
        Rb_codigo_CheckedChanged(sender, e)
    End Sub

    Private Sub Lst_Choferes_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim sql As String = "SELECT cho_rut, cho_nombre, cho_patente, cho_patente2, cho_empresa, " +
                            "RIGHT(cho_rutempresa,9) AS cho_rutempresa,  cho_rutclie, cli_nomb FROM choferes, clientes " +
                            "WHERE cli_rut=cho_rutclie ORDER BY cho_rut ASC"

        BindingSource1.DataSource = fnc.ListarTablasSQL(sql)
        BindingNavigator1.BindingSource = BindingSource1
        DataGridView1.DataSource = BindingSource1

    End Sub
   
    Private Sub DataGridView1_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Dim sql As String = "SELECT cho_rut, cho_rutclie, cho_nombre, cho_patente, " +
        "cho_empresa, cho_rutempresa, cho_patente2, cli_nomb, ISNULL(cho_listanegra,0) as listanegra,ISNULL(cho_observacion,'') as observcho, " +
        "isnull(lnpat_est,0) as lnpatente, isnull(lnpat_obs,'') as observpat, isnull(lnrpl_est,0) as lnrampla, isnull(lnrpl_obs,'') as observrampla " +
        "FROM choferes inner join clientes on cho_rutclie=cli_rut " +
        "left JOIN ListaNegraPatente on cho_patente=lnpat_pat " +
        "left join ListaNegraRampla on cho_patente2=lnrpl_rpl " +
        "WHERE cho_rut='" + Me.DataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString() + "'"

        Dim form As New Frm_AddChoferes
        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)
        If tabla.Rows.Count > 0 Then
            form.chorut.Text = tabla.Rows(0)(0).ToString()
            form.chorut.Enabled = False
            form.chonombre.Text = tabla.Rows(0)(2).ToString()
            form.chopatente.Text = tabla.Rows(0)(3).ToString()
            form.txtrampla.Text = tabla.Rows(0)(6).ToString()
            If tabla.Rows(0)(5).ToString <> "" Then
                form.emprut.Text = tabla.Rows(0)(5).ToString().Remove(0, 4)
            End If

            If tabla.Rows(0)(8).ToString = 0 Then
                form.chkchofer.Checked = False
                form.txtobservchofer.Visible = False
                form.txtobservchofer.Text = tabla.Rows(0)(9).ToString()
            Else
                form.chkchofer.Checked = True
                form.txtobservchofer.Visible = True
                form.txtobservchofer.Text = tabla.Rows(0)(9).ToString()
            End If

            If tabla.Rows(0)(10).ToString = 0 Then
                form.chkpatente.Checked = False
                form.txtobservpatente.Visible = False
                form.txtobservpatente.Text = tabla.Rows(0)(11).ToString()
            Else
                form.chkpatente.Checked = True
                form.txtobservpatente.Visible = True
                form.txtobservpatente.Text = tabla.Rows(0)(11).ToString()
            End If

            If tabla.Rows(0)(12).ToString = 0 Then
                form.chkrampla.Checked = False
                form.txtobservrampla.Visible = False
                form.txtobservrampla.Text = tabla.Rows(0)(13).ToString()
            Else
                form.chkrampla.Checked = True
                form.txtobservrampla.Visible = True
                form.txtobservrampla.Text = tabla.Rows(0)(13).ToString()
            End If

            form.empnombre.Text = tabla.Rows(0)(4).ToString()
            form.clirut.Text = tabla.Rows(0)(1).ToString()
            form.clinombre.Text = tabla.Rows(0)(7).ToString()
            form.ShowDialog()
            Rb_codigo_CheckedChanged(sender, e)

        End If

    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If MsgBox("Seguro de eliminar el chofer seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbYes Then
            If MsgBox("Está seguro de eliminar el chofer", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Aviso") = vbYes Then

                Dim Elimina As String = "DELETE FROM choferes WHERE " +
                    "cho_rut='" + DataGridView1.Rows(pos.Text - 1).Cells(0).Value.ToString() + "'"

                If fnc.MovimientoSQL(Elimina) > 0 Then
                    MsgBox("Registro Eliminado", MsgBoxStyle.Information, "Aviso")
                    Rb_codigo_CheckedChanged(sender, e)
                End If


            End If
        End If
    End Sub

    Private Sub Rb_codigo_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles Rb_codigo.CheckedChanged
        Dim sql As String = "SELECT cho_rut, cho_nombre, cho_patente, cho_patente2, cho_empresa, " +
                    "cho_rutempresa,  cho_rutclie, cli_nomb FROM choferes, clientes " +
                    "WHERE cli_rut=cho_rutclie ORDER BY cho_rut ASC"

        BindingSource1.DataSource = fnc.ListarTablasSQL(sql)
        BindingNavigator1.BindingSource = BindingSource1
        DataGridView1.DataSource = BindingSource1

    End Sub

    Private Sub Rb_descrip_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles Rb_descrip.CheckedChanged
        Dim sql As String = "SELECT cho_rut, cho_nombre, cho_patente, cho_patente2, cho_empresa, " +
                    "cho_rutempresa,  cho_rutclie, cli_nomb FROM choferes, clientes " +
                    "WHERE cli_rut=cho_rutclie ORDER BY cho_nombre ASC"

        BindingSource1.DataSource = fnc.ListarTablasSQL(sql)
        BindingNavigator1.BindingSource = BindingSource1
        DataGridView1.DataSource = BindingSource1

    End Sub

    Private Sub txtbusca_KeyUp(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtbusca.KeyUp

        Dim sql As String = "SELECT cho_rut, cho_nombre, cho_patente, cho_patente2, cho_empresa, " +
            "cho_rutempresa,  cho_rutclie, cli_nomb FROM choferes, clientes " +
            "WHERE cli_rut=cho_rutclie AND (cho_rut LIKE '%" + txtbusca.Text + "%' OR cho_nombre LIKE'%" + txtbusca.Text + "%' OR cho_patente LIKE '%" + txtbusca.Text + "%' OR cho_patente2 LIKE '%" + txtbusca.Text + "%') ORDER BY cho_nombre ASC"

        BindingSource1.DataSource = fnc.ListarTablasSQL(sql)
        BindingNavigator1.BindingSource = BindingSource1
        DataGridView1.DataSource = BindingSource1

    End Sub

    Private Sub ToolStripButton5_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton5.Click
        Lst_Choferes_Load(sender, e)
        txtbusca.Text = ""
    End Sub

    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.Click
        GridAExcel(Me.DataGridView1)
    End Sub
End Class
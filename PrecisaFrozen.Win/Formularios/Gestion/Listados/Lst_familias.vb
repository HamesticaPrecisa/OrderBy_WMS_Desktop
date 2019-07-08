Public Class Lst_familias

    Dim fnc As New Funciones

    Function dataEliminaDigitos(ByVal tablaRecibida As DataTable)
        Dim tablaEnviada As New DataTable
        tablaEnviada.Columns.Add("fam_codi")
        tablaEnviada.Columns.Add("fam_descr")
        For i As Integer = 0 To tablaRecibida.Rows.Count - 1
            If tablaRecibida.Rows(i)(0).ToString.Length >= 4 Then
                tablaEnviada.Rows.Add(Mid(tablaRecibida.Rows(i)(0), 1, Len(tablaRecibida.Rows(i)(0).ToString()) - 4), tablaRecibida.Rows(i)(1))
            End If
        Next
        Return tablaEnviada
    End Function

    Private Sub Lst_familias_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        f_lstFamilias = False
    End Sub

    Private Sub Lst_familias_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim sql = "SELECT fam_codi, fam_descr FROM famprod ORDER BY fam_codi ASC"
        BindingSource1.DataSource = dataEliminaDigitos(fnc.ListarTablasSQL(sql))
        BindingNavigator1.BindingSource = BindingSource1
        DataGridView1.DataSource = BindingSource1
    End Sub

    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.Click
        GridAExcel(DataGridView1)
    End Sub

    Private Sub ToolStripButton4_Click(sender As System.Object, e As System.EventArgs)
        Lst_familias_Load(sender, e)
    End Sub

    Private Sub Rb_Codigo_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles Rb_Codigo.CheckedChanged
        Lst_familias_Load(sender, e)
    End Sub

    Private Sub Rb_Descripción_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles Rb_Descripción.CheckedChanged
        Dim sql = "SELECT fam_codi, fam_descr FROM famprod ORDER BY fam_descr ASC"
        BindingSource1.DataSource = dataEliminaDigitos(fnc.ListarTablasSQL(sql))
        BindingNavigator1.BindingSource = BindingSource1
        DataGridView1.DataSource = BindingSource1
    End Sub

    Private Sub ToolStripButton2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton2.Click
        Frm_AddFamilias.ShowDialog()
        Rb_Codigo_CheckedChanged(sender, e)
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If MsgBox("Seguro de eliminar la familia seleccionada?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbYes Then
            If MsgBox("Está seguro de eliminar la familia", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Aviso") = vbYes Then

                Dim Elimina As String = "DELETE FROM famprod WHERE " +
                    "fam_codi='" + DataGridView1.Rows(pos.Text - 1).Cells(0).Value.ToString() + "0000" + "'"

                If fnc.MovimientoSQL(Elimina) > 0 Then
                    MsgBox("Registro Eliminado", MsgBoxStyle.Information, "Aviso")
                    Rb_Codigo_CheckedChanged(sender, e)
                End If


            End If
        End If
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        If e.RowIndex > -1 Then
            Dim frm As New Frm_AddFamilias
            frm.txtcodigo.Text = DataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString()
            Dim sql = "SELECT fam_descr FROM famprod WHERE fam_codi='" + DataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString() + "0000" + "'"
            Dim tabla As DataTable = fnc.ListarTablasSQL(sql)
            If tabla.Rows.Count > 0 Then
                frm.txtdesc.Text = tabla.Rows(0)(0)
            Else
                frm.txtdesc.Focus()
            End If
            frm.txtcodigo.Enabled = False
            frm.txtdesc.Enabled = True
            frm.ShowDialog()
            Rb_Codigo_CheckedChanged(sender, e)
        End If
    End Sub

    Private Sub txtbusca_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtbusca.KeyPress
        If e.KeyChar = ChrW(13) Then
            Dim sql = "SELECT fam_codi, fam_descr FROM famprod WHERE (fam_codi LIKE '%" + txtbusca.Text + "%' OR " +
                "fam_descr LIKE '%" + txtbusca.Text + "%' ) ORDER BY fam_codi ASC"
            BindingSource1.DataSource = dataEliminaDigitos(fnc.ListarTablasSQL(sql))
            BindingNavigator1.BindingSource = BindingSource1
            DataGridView1.DataSource = BindingSource1
        End If
    End Sub

    Private Sub ToolStripButton4_Click_1(sender As System.Object, e As System.EventArgs) Handles ToolStripButton4.Click
        Rb_Codigo_CheckedChanged(sender, e)
    End Sub
End Class
Public Class Lst_Medidas

    Dim fnc As New Funciones

    Private Sub Lst_Medidas_DragOver(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles Me.DragOver
        f_LstMedidas = False
    End Sub

    Private Sub Lst_Medidas_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim sql = "SELECT  med_codi, med_descr FROM Medidas ORDER BY med_codi ASC"
        BindingSource1.DataSource = fnc.ListarTablasSQL(sql)
        BindingNavigator1.BindingSource = BindingSource1
        DataGridView1.DataSource = BindingSource1
    End Sub

    Private Sub Rb_Descripción_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles Rb_Descripción.CheckedChanged
        Dim sql = "SELECT  med_codi, med_descr FROM Medidas ORDER BY med_descr ASC"
        BindingSource1.DataSource = fnc.ListarTablasSQL(sql)
        BindingNavigator1.BindingSource = BindingSource1
        DataGridView1.DataSource = BindingSource1
    End Sub

    Private Sub Rb_Codigo_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles Rb_Codigo.CheckedChanged
        Lst_Medidas_Load(sender, e)
    End Sub


    Private Sub txtbusca_KeyUp(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtbusca.KeyUp
        Dim sql = "SELECT  med_codi, med_descr FROM Medidas WHERE (med_codi LIKE " +
                  "'%" + txtbusca.Text + "%' OR med_descr LIKE '%" + txtbusca.Text + "%') ORDER BY med_codi ASC"

        BindingSource1.DataSource = fnc.ListarTablasSQL(sql)
        BindingNavigator1.BindingSource = BindingSource1
        DataGridView1.DataSource = BindingSource1
    End Sub

    Private Sub ToolStripButton2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton2.Click
        Dim frm As New Frm_AddMedida
        frm.ShowDialog()
        Rb_Codigo_CheckedChanged(sender, e)
    End Sub

    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.Click
        GridAExcel(Me.DataGridView1)
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If MsgBox("Esta seguro de eliminar la información seleccionada", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbYes Then
            If MsgBox("Esta por eliminar la información, desea continuar?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo, "Aviso") = vbYes Then

                Dim sql = "DELETE FROM medidas WHERE med_codi='" + Me.DataGridView1.Rows(Val(pos.Text) - 1).Cells(0).Value.ToString() + "'"

                If fnc.MovimientoSQL(sql) > 0 Then
                    MsgBox("Registro eliminado", MsgBoxStyle.Information, "Aviso")
                    Rb_Codigo_CheckedChanged(sender, e)
                End If
            End If

        End If
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Dim frm As New Frm_AddMedida
        frm.txtcodigo.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString()
        frm.txtdescr.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString()
        frm.txtcodigo.Enabled = False
        frm.txtdescr.Enabled = True
        frm.txtdescr.SelectAll()
        frm.ShowDialog()
        Rb_Codigo_CheckedChanged(sender, e)

    End Sub

    Private Sub ToolStripButton4_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton4.Click
        Rb_Codigo_CheckedChanged(sender, e)
    End Sub
End Class
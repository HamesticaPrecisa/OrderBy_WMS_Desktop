Public Class Lst_soportantes

    Dim fnc As New Funciones

    Private Sub Lst_soportantes_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        f_lstSoportantes = False
    End Sub

    Private Sub Lst_soportantes_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        BindingSource1.DataSource = New Funciones().ListarTablasSQL("SELECT  tsop_codi, tsop_descr, tsop_materi, pesoPallet FROM tiposopo ORDER BY tsop_codi ASC")
        BindingNavigator1.BindingSource = BindingSource1
        DataGridView1.DataSource = BindingSource1
    End Sub

    Private Sub Rb_Codigo_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles Rb_Codigo.CheckedChanged
        Lst_soportantes_Load(sender, e)
    End Sub

    Private Sub Rb_Descripción_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles Rb_Descripción.CheckedChanged
        BindingSource1.DataSource = New Funciones().ListarTablasSQL("SELECT  tsop_codi, tsop_descr, tsop_materi, pesoPallet FROM tiposopo ORDER BY tsop_descr ASC")
        BindingNavigator1.BindingSource = BindingSource1
        DataGridView1.DataSource = BindingSource1
    End Sub

    Private Sub Rb_material_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles Rb_material.CheckedChanged
        BindingSource1.DataSource = New Funciones().ListarTablasSQL("SELECT  tsop_codi, tsop_descr, tsop_materi, pesoPallet FROM tiposopo ORDER BY tsop_materi ASC")
        BindingNavigator1.BindingSource = BindingSource1
        DataGridView1.DataSource = BindingSource1
    End Sub

    Private Sub Rb_peso_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles Rb_peso.CheckedChanged
        BindingSource1.DataSource = New Funciones().ListarTablasSQL("SELECT  tsop_codi, tsop_descr, tsop_materi, pesoPallet FROM tiposopo ORDER BY pesoPallet ASC")
        BindingNavigator1.BindingSource = BindingSource1
        DataGridView1.DataSource = BindingSource1
    End Sub


    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.Click
        GridAExcel(DataGridView1)
    End Sub

    Private Sub ToolStripButton2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton2.Click
        Frm_AddSoportantes.ShowDialog()
        Rb_Codigo_CheckedChanged(sender, e)
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If MsgBox("Seguro de eliminar el Soportante seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbYes Then
            If MsgBox("Está seguro de eliminar el Soportante", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Aviso") = vbYes Then

                Dim Elimina As String = "DELETE FROM tiposopo WHERE " +
                    "tsop_codi='" + DataGridView1.Rows(pos.Text - 1).Cells(0).Value.ToString() + "'"

                If fnc.MovimientoSQL(Elimina) > 0 Then
                    MsgBox("Registro Eliminado", MsgBoxStyle.Information, "Aviso")
                    Rb_Codigo_CheckedChanged(sender, e)
                End If


            End If
        End If

    End Sub

    Private Sub ToolStripButton4_Click(sender As System.Object, e As System.EventArgs)
        Rb_Codigo_CheckedChanged(sender, e)
    End Sub


    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        If e.RowIndex > -1 Then
            Dim frm As New Frm_AddSoportantes

            Dim sql = "SELECT tsop_descr, tsop_materi, pesoPallet FROM tiposopo WHERE tsop_codi='" + Me.DataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString() + "'"
            Dim tabla As DataTable = fnc.ListarTablasSQL(sql)
            If tabla.Rows.Count > 0 Then
                frm.txtdescripcion.Text = tabla.Rows(0)(0)
                frm.txtmaterial.Text = tabla.Rows(0)(1)
                frm.txtpeso.Text = tabla.Rows(0)(2)
                frm.txtcodigo.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString()
                frm.txtdescripcion.Focus()
                frm.txtdescripcion.Enabled = True
                frm.txtdescripcion.Focus()
                frm.txtmaterial.Enabled = True
            End If
            frm.txtcodigo.Enabled = False
            frm.ShowDialog()
            Rb_Codigo_CheckedChanged(sender, e)
        End If

    End Sub

    Private Sub txtbusca_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtbusca.KeyPress
        If e.KeyChar = ChrW(13) Then
            BindingSource1.DataSource = New Funciones().ListarTablasSQL("SELECT  tsop_codi, tsop_descr, tsop_materi,pesoPallet FROM " +
                                                                        "tiposopo WHERE (tsop_codi LIKE '%" + txtbusca.Text + "%'" +
                                                                        "OR tsop_descr LIKE '%" + txtbusca.Text + "%' OR " +
                                                                        "tsop_materi LIKE '%" + txtbusca.Text + "%'  OR " +
                                                                        "pesoPallet LIKE '%" + txtbusca.Text + "%' ) ORDER BY tsop_codi ASC")
            BindingNavigator1.BindingSource = BindingSource1
            DataGridView1.DataSource = BindingSource1
        End If
    End Sub

    Private Sub ToolStripButton4_Click_1(sender As System.Object, e As System.EventArgs) Handles ToolStripButton4.Click
        Rb_Codigo_CheckedChanged(sender, e)
    End Sub
End Class
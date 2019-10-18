Imports System.Data.SqlClient

Public Class Lst_Mercados
    Dim fnc As New Funciones
    Dim fila = -1
    Dim mainSQL As String

    Private Sub Lst_Mercados_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        f_lstMercados = False
    End Sub

    Private Sub Lst_Mercados_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' VES Sep 2019
        ' Se modifico el query para incuir la descripcion del tipo de camara
        mainSQL = "SELECT a.mer_nombre, a.mer_temp, a.mer_id" +
                  "  FROM mercados a "
        BindingSource1.DataSource = fnc.ListarTablasSQL(mainSQL + " ORDER BY a.mer_nombre ASC")
        BindingNavigator1.BindingSource = BindingSource1
        DataGridView1.DataSource = BindingSource1
    End Sub

    Private Sub Rb_nombre_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rb_descrip.CheckedChanged
        Lst_Mercados_Load(sender, e)
    End Sub

    Private Sub Rb_temp_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rb_temp.CheckedChanged
        BindingSource1.DataSource = fnc.ListarTablasSQL(mainSQL + " ORDER BY mer_temp")
        BindingNavigator1.BindingSource = BindingSource1
        DataGridView1.DataSource = BindingSource1
    End Sub


    Private Sub Rb_horas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rb_temp.CheckedChanged
        BindingSource1.DataSource = fnc.ListarTablasSQL(mainSQL + " ORDER BY mer_horas")
        BindingNavigator1.BindingSource = BindingSource1
        DataGridView1.DataSource = BindingSource1
    End Sub


    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        GridAExcel(DataGridView1)
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Frm_AddMercados.ShowDialog()
        Rb_nombre_CheckedChanged(sender, e)
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If RealizarAccion("006", "016") = False Then
            Exit Sub
        End If
        If MsgBox("Esta seguro de eliminar la información seleccionada", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbYes Then
            If MsgBox("Esta por eliminar la información, desea continuar?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbYes Then

                Dim sql = "UPDATE mercados SET mer_status = 'ELIMINADO' WHERE mer_id = " + DataGridView1.Rows(posi.Text - 1).Cells(0).Value.ToStrig()
                If fnc.MovimientoSQL(sql) > 0 Then
                    MsgBox("Registro eliminado", MsgBoxStyle.Information, "Aviso")
                    Rb_nombre_CheckedChanged(sender, e)
                End If
            End If

        End If
    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Rb_nombre_CheckedChanged(sender, e)
    End Sub

    Private Sub DataGridView1_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick

        If e.RowIndex > -1 Then

            Dim frm As New Frm_AddMercados


            Dim sql = "SELECT mer_id,mer_nombre,mer_temp,mer_horas, mer_trt, mer_crifec FROM mercados WHERE mer_id=@id"
            Dim mer_id As Integer = CInt(DataGridView1.Rows(posi.Text - 1).Cells(2).Value)

            Dim row As DataRow = fnc.sqlExecuteRow(sql, New SqlParameter() {New SqlParameter("@id", SqlDbType.Int) With {.Value = mer_id}})
            If row IsNot Nothing Then
                frm.mer_id = mer_id
                frm.txtNombre.Text = row("mer_nombre").ToString().Trim()
                frm.txttemp.Text = row("mer_temp").ToString().Trim()
                frm.txtHoras.Text = row("mer_horas").ToString().Trim()
                frm.txtTRT.Text = row("mer_trt").ToString().Trim()
                frm.cboCriFec.Text = row("mer_crifec").ToString().Trim()
                frm.txtNombre.Enabled = False
            End If
            frm.ShowDialog()
            Rb_nombre_CheckedChanged(sender, e)
        End If
    End Sub

    Private Sub ToolStripButton4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        Rb_nombre_CheckedChanged(sender, e)
    End Sub


    Private Sub txtbusca_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtbusca.KeyUp
        BindingSource1.DataSource = fnc.ListarTablasSQL(mainSQL + " WHERE a.mer_nombre LIKE '%" + txtbusca.Text + "%' ")
        BindingNavigator1.BindingSource = BindingSource1
        DataGridView1.DataSource = BindingSource1

    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub
End Class
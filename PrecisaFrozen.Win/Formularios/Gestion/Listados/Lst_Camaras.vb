Public Class Lst_Camaras
    Dim fnc As New Funciones
    Dim fila = -1
    Dim mainSQL As String

    Private Sub Lst_Camaras_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        f_lstCamaras = False
    End Sub

    Private Sub Lst_Camaras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' VES Sep 2019
        ' Se modifico el query para incuir la descripcion del tipo de camara
        mainSQL = "SELECT a.cam_codi, a.cam_descr, a.cam_numcol, a.cam_numpiso, " +
                  "       a.cam_numnive, a.cam_temper, a.cam_humed, a.cam_baninic, " +
                  "       a.cam_banfin, ISNULL(b.nombre,'(desconocido)') AS cam_destipo " +
                  "  FROM camaras a " +
                  "  LEFT JOIN vwTiposCamara b ON b.id = a.cam_tipo "
        BindingSource1.DataSource = fnc.ListarTablasSQL(mainSQL + " ORDER BY a.cam_codi ASC") ' VES Sep 2019
        BindingNavigator1.BindingSource = BindingSource1
        DataGridView1.DataSource = BindingSource1
    End Sub

    Private Sub Rb_codigo_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles Rb_codigo.CheckedChanged
        Lst_Camaras_Load(sender, e)
    End Sub

 
    Private Sub Rb_descrip_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles Rb_descrip.CheckedChanged
        BindingSource1.DataSource = fnc.ListarTablasSQL(mainSQL + " ORDER BY a.cam_descr ASC") ' VES Sep 2019
        BindingNavigator1.BindingSource = BindingSource1
        DataGridView1.DataSource = BindingSource1
    End Sub

    Private Sub Rb_temp_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles Rb_temp.CheckedChanged
        BindingSource1.DataSource = fnc.ListarTablasSQL(mainSQL + " ORDER BY cam_temper") ' VES Sep 2019
        BindingNavigator1.BindingSource = BindingSource1
        DataGridView1.DataSource = BindingSource1
    End Sub

    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.Click
        GridAExcel(DataGridView1)
    End Sub

    Private Sub ToolStripButton2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton2.Click
        Frm_AddCamaras.ShowDialog()
        Rb_codigo_CheckedChanged(sender, e)
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If RealizarAccion("006", "016") = False Then
            Exit Sub
        End If
        If MsgBox("Esta seguro de eliminar la información seleccionada", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbYes Then
            If MsgBox("Esta por eliminar la información, desea continuar?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbYes Then

                Dim sql = "DELETE FROM camaras WHERE cam_codi='" + DataGridView1.Rows(posi.Text - 1).Cells(0).Value.ToString() + "'"
                If fnc.MovimientoSQL(sql) > 0 Then
                    MsgBox("Registro eliminado", MsgBoxStyle.Information, "Aviso")
                    Rb_codigo_CheckedChanged(sender, e)
                End If
            End If

        End If
    End Sub

    Private Sub ToolStripButton4_Click(sender As System.Object, e As System.EventArgs)
        Rb_codigo_CheckedChanged(sender, e)
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick

        If e.RowIndex > -1 Then

            Dim frm As New Frm_AddCamaras


            Dim sql = "SELECT cam_descr, cam_numcol, cam_numpiso, cam_numnive, cam_temper, cam_humed, cam_capm3, " +
                 "cam_baninic, cam_banfin, cam_capa, cam_tipo FROM camaras WHERE cam_codi='" + Me.DataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString() + "'" ' VES SEp 2019. Se incluyo cam_tipo

            Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

            If tabla.Rows.Count > 0 Then
                frm.txtcodigo.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString()
                frm.txtcodigo.Enabled = False
                frm.txtdescr.Text = tabla.Rows(0)(0).ToString()
                frm.txtcol.Text = tabla.Rows(0)(1).ToString()
                frm.txtpis.Text = tabla.Rows(0)(2).ToString()
                frm.txtniv.Text = tabla.Rows(0)(3).ToString()
                frm.txttemp.Text = tabla.Rows(0)(4).ToString()
                frm.txthum.Text = tabla.Rows(0)(5).ToString()
                frm.mts3.Text = tabla.Rows(0)(6).ToString()
                frm.txtbdaini.Text = tabla.Rows(0)(7).ToString()
                frm.txtbdafin.Text = tabla.Rows(0)(8).ToString()
                frm.capacidad.Text = tabla.Rows(0)(9).ToString()
                frm.cboTipo.SelectedValue = Int32.Parse(tabla.Rows(0)(10).ToString())
                frm.txtdescr.Enabled = True
            End If
            frm.ShowDialog()
            Rb_codigo_CheckedChanged(sender, e)
        End If
    End Sub

    Private Sub ToolStripButton4_Click_1(sender As System.Object, e As System.EventArgs) Handles ToolStripButton4.Click
        Rb_codigo_CheckedChanged(sender, e)
    End Sub


    Private Sub txtbusca_KeyUp(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtbusca.KeyUp
        BindingSource1.DataSource = fnc.ListarTablasSQL(mainSQL +
                                                        " WHERE (a.cam_codi LIKE '%" + txtbusca.Text + "%' " +
                                                        "    OR a.cam_descr LIKE '%" + txtbusca.Text + "%')")


        BindingNavigator1.BindingSource = BindingSource1
        DataGridView1.DataSource = BindingSource1

    End Sub
End Class
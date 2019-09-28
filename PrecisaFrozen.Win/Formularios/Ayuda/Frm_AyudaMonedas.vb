Public Class Frm_AyudaMonedas

    Dim fnc As New Funciones

    Private Sub Lst_Moneda_Load(sender As System.Object, e As System.EventArgs)
        BindingSource1.DataSource = fnc.ListarTablasSQL("SELECT mon_codi, mon_descr, mon_valor, mon_fecval FROM " +
                                                        "monedas ORDER BY mon_codi ASC")
        BindingNavigator1.BindingSource = BindingSource1
        DataGridView1.DataSource = BindingSource1
    End Sub

    Private Sub Rb_descrip_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles Rb_descrip.CheckedChanged
        BindingSource1.DataSource = fnc.ListarTablasSQL("SELECT mon_codi, mon_descr, mon_valor, mon_fecval FROM " +
                                                        "monedas ORDER BY mon_descr ASC")
        BindingNavigator1.BindingSource = BindingSource1
        DataGridView1.DataSource = BindingSource1
    End Sub

    Private Sub Rb_codigo_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles Rb_codigo.CheckedChanged
        Lst_Moneda_Load(sender, e)
    End Sub

    Private Sub ToolStripButton3_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton3.Click
        If MsgBox("Esta seguro de eliminar la información seleccionada", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbYes Then
            If MsgBox("Esta por eliminar la información, desea continuar?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo, "Aviso") = vbYes Then

                Dim sql = "DELETE * FROM monedas WHERE mon_codi='" + Me.DataGridView1.Rows(Val(posi.Text) - 1).Cells(0).Value.ToString() + "'"

                If fnc.MovimientoSQL(sql) > 0 Then
                    MsgBox("Registro eliminado", MsgBoxStyle.Information, "Aviso")
                    Rb_codigo_CheckedChanged(sender, e)
                End If
            End If

        End If
    End Sub

    Private Sub Rb_valor_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles Rb_valor.CheckedChanged
        BindingSource1.DataSource = fnc.ListarTablasSQL("SELECT mon_codi, mon_descr, mon_valor, mon_fecval FROM " +
                                                        "monedas ORDER BY mon_valor ASC")
        BindingNavigator1.BindingSource = BindingSource1
        DataGridView1.DataSource = BindingSource1
    End Sub


    Private Sub DataGridView1_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        If e.RowIndex > -1 Then
            Dim _formInterface As IForm = CType(Me.Owner, IForm)
            _formInterface.ChangeTextBoxText(DataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString())
            Me.Close()
        End If

    End Sub

End Class
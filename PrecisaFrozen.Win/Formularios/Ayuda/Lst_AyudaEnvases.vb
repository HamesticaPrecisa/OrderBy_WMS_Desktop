Public Class Lst_AyudaEnvases


    Dim fnc As New Funciones

    Private Sub DataGridView1_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        If e.RowIndex > -1 Then
            Dim _formInterface As IForm = CType(Me.Owner, IForm)

            _formInterface.ChangeTextBoxText(DataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString())

            Me.Close()
        End If

    End Sub

    Private Sub Lst_AyudaEnvases_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        BindingSource1.DataSource = fnc.ListarTablasSQL("SELECT tenv_codi, tenv_descr FROM tipoenv " +
                                                "ORDER BY tenv_codi ASC")
        BindingNavigator1.BindingSource = BindingSource1
        DataGridView1.DataSource = BindingSource1
        txtbusca.Focus()
    End Sub

    Private Sub ToolStripButton4_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton4.Click
        Lst_AyudaEnvases_Load(sender, e)
    End Sub


    Private Sub txtbusca_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtbusca.KeyPress
        BindingSource1.DataSource = fnc.ListarTablasSQL("SELECT tenv_codi, tenv_descr FROM tipoenv " +
                                                        "WHERE (tenv_codi LIKE '%" + txtbusca.Text + "%' OR tenv_descr " +
                                                        "LIKE '%" + txtbusca.Text + "%' ) ORDER BY tenv_codi ASC")
        BindingNavigator1.BindingSource = BindingSource1
        DataGridView1.DataSource = BindingSource1
        txtbusca.Focus()
    End Sub
End Class
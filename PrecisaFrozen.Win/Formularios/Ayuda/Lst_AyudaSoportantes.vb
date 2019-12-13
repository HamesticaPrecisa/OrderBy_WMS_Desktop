Public Class Lst_AyudaSoportantes

    Dim fnc As New Funciones
    Dim Condicion As String = " "

    Private Sub Lst_AyudaSoportantes_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim sql As String = "SELECT  tsop_codi, tsop_descr FROM tiposopo ORDER BY tsop_codi ASC" + Condicion

        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)
        BindingSource1.DataSource = fnc.ListarTablasSQL(sql)
        BindingNavigator1.BindingSource = BindingSource1
        DataGridView1.DataSource = BindingSource1
    End Sub

    Private Sub txtbusca_KeyUp(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtbusca.KeyUp
        Dim sql As String = "SELECT  tsop_codi, tsop_descr  FROM tiposopo " +
            Condicion + " AND (tsop_codi LIKE '%" + txtbusca.Text + "%' OR tsop_descr LIKE '%" + txtbusca.Text + "%' ) ORDER BY tsop_codi ASC "

        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)
        BindingSource1.DataSource = fnc.ListarTablasSQL(sql)
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
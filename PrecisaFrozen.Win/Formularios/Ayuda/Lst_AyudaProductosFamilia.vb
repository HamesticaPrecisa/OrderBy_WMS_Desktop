Public Class Lst_AyudaProductosFamilia

    Public tipo_producto As String
    Dim fnc As New Funciones


    Private Sub Lst_AyudaProductosFamilia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DataGridView1.DataSource = fnc.ListarTablasSQL("SELECT RIGHT(mae_codi,3) AS cod, mae_descr FROM maeprod WHERE left(mae_codi,3)='" + tipo_producto + "'")

    End Sub

    Private Sub DataGridView1_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        If e.RowIndex > -1 Then
            Dim _formInterface As IForm = CType(Me.Owner, IForm)
            _formInterface.ChangeTextBoxText(DataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString())
            Me.Close()
        End If

    End Sub

    Private Sub busca_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles busca.TextChanged
        DataGridView1.DataSource = fnc.ListarTablasSQL("SELECT RIGHT(mae_codi,3) AS cod, mae_descr FROM " +
                                   "maeprod WHERE left(mae_codi,3)='" + tipo_producto + "' AND mae_descr LIKE'%" + busca.Text + "%'")
    End Sub
End Class
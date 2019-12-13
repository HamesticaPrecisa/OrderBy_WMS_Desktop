Public Class Frm_CategoriasAyuda

    Dim fnc As New Funciones

    Private Sub Frm_CategoriasAyuda_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim sql As String = "SELECT * FROM PrivilegiosSeccion ORDER BY priv_id ASC"
        Me.DataGridView1.DataSource = fnc.ListarTablasSQL(sql)
    End Sub

    Private Sub DataGridView1_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        If e.RowIndex > -1 Then
            Dim _formInterface As IForm = CType(Me.Owner, IForm)
            _formInterface.ChangeTextBoxText(DataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString())
            Me.Close()
        End If
    End Sub
End Class
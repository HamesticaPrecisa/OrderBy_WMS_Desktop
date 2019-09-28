Public Class Frm_AyudaAlmacenamiento

    Dim fnc As New Funciones

    Dim x As Integer = 0
    Dim y As Integer = 0

    Private Sub Frm_AyudaAlmacenamiento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DataGridView1.DataSource = fnc.ListarTablasSQL("SELECT id, almacenamiento FROM P_tipoalmacenamiento WHERE id<>'0' ORDER BY id ASC")
 
    End Sub

    Private Sub DataGridView1_CellContentDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentDoubleClick
        If e.RowIndex > -1 Then
            Dim _formInterface As IForm = CType(Me.Owner, IForm)
            _formInterface.ChangeTextBoxText(DataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString())
            Me.Close()
        End If
    End Sub
End Class
Public Class Frm_CheckListAyuda

    Dim fnc As New Funciones

    Private Sub Frm_CheckListAyuda_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        DataGridView1.DataSource = fnc.ListarTablasSQL("SELECT cl_fol, cli_nomb, cho_nombre " +
                                                       "FROM zchecklist, clientes, choferes " +
                                                       "WHERE cho_rut=cl_chorut AND cli_rut=cl_rutcli " +
                                                       "ORDER BY cl_fol DESC")
    End Sub


    Private Sub DataGridView1_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        If e.RowIndex > -1 Then
            Dim _formInterface As IForm = CType(Me.Owner, IForm)
            _formInterface.ChangeTextBoxText(DataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString())
            Me.Close()
        End If
    End Sub
End Class
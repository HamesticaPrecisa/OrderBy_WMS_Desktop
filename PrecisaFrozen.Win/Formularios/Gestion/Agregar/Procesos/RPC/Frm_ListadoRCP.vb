Public Class Frm_ListadoRCP

    Dim fnc As New Funciones

    Private Sub Frm_ListadoRCP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim sql As String = "SELECT LRCP_CODI, frec_guiades, LRCP_CODSAG, LRCP_FECHA FROM LOG_RCP INNER JOIN fichrece ON frec_codi=LRCP_CODI ORDER BY lrcp_codi desc"
        DgvListado.DataSource = fnc.ListarTablasSQL(sql)
    End Sub
 
    Private Sub DgvListado_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvListado.CellDoubleClick
        If e.RowIndex > -1 Then
            Dim _formInterface As IForm = CType(Me.Owner, IForm)
            _formInterface.ChangeTextBoxText(DgvListado.Rows(e.RowIndex).Cells(0).Value.ToString())
            Me.Close()
        End If
    End Sub
End Class
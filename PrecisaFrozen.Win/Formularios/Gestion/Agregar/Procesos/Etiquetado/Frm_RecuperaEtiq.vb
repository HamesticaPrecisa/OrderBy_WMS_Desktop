Public Class Frm_RecuperaEtiq

    Dim Fnc As New Funciones

    Private Sub Frm_RecuperaEtiq_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim sql As String = "SELECT ETIQ_CODI, cli_nomb, cont_descr FROM TMPFICHETIQ INNER JOIN clientes ON cli_rut=ETIQ_CLIRUT " +
            "INNER JOIN contrato  ON cont_codi=ETIQ_CODCONT WHERE ETIQ_CODENCA='" + Frm_Principal.InfoUsuario.Text + "' "
        DgvEtiq.DataSource = Fnc.ListarTablasSQL(sql)

    End Sub

    Private Sub DgvEtiq_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvEtiq.CellDoubleClick
        If e.RowIndex > -1 Then
            Dim _formInterface As IForm = CType(Me.Owner, IForm)
            _formInterface.ChangeTextBoxText(DgvEtiq.Rows(e.RowIndex).Cells(0).Value.ToString())
            Me.Close()
        End If
    End Sub
End Class
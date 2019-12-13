Public Class Frm_ListadoPreDespachos

    Dim fnc As New Funciones


    Private Sub Frm_ListadoPreDespachos_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        actualiza_tabla()
        Timer1.Start()
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        If e.RowIndex > -1 Then
            Dim _formInterface As IForm = CType(Me.Owner, IForm)
            _formInterface.ChangeTextBoxText(DataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString())
            Timer1.Stop()
            Me.Close()
        End If
    End Sub

    Sub actualiza_tabla()
        Dim SQL As String = "SELECT fpre_codi, cli_nomb, fpre_fecdes, fpre_totsopo, fpre_totunidad, fpre_totpeso " +
                            "FROM fichpred, clientes WHERE fpre_rutcli=cli_rut AND fpre_codvig='0' AND fpre_activa='0'"
        Me.DataGridView1.DataSource = fnc.ListarTablasSQL(SQL)
    End Sub

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        actualiza_tabla()
    End Sub
End Class
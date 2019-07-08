Public Class Lst_Clientes

    Dim fnc As New Funciones

    Private Sub Lst_Clientes_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        f_lstClientes = False
    End Sub

    Private Sub Lst_Clientes_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        DataGridView1.DataSource = New Funciones().ListarTablasSQL("SELECT cli_rut, cli_nomb, cli_direcc, " +
                                                                    "cli_comuna, ciu_descr, cli_fono, cli_fax, cli_mail, cli_feccre, " +
                                                                    "cli_estado FROM clientes, ciudad WHERE cli_ciudad=ciu_codi " +
                                                                    "ORDER BY cli_rut")
    End Sub


    Private Sub Rb_rut_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Lst_Clientes_Load(sender, e)
    End Sub

 
    Private Sub DataGridView1_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        If e.RowIndex > -1 Then

            Dim frm As New Frm_AddClientes
            frm.RutCliente = DataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString()
            frm.ShowDialog()

            Rb_rut_CheckedChanged(sender, e)

        End If
    End Sub

End Class
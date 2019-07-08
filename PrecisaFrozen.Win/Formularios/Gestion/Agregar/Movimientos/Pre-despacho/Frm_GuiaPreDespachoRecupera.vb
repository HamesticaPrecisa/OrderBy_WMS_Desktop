Public Class Frm_GuiaPreDespachoRecupera


    Dim fnc As New Funciones

    Private Sub Frm_GuiaPreDespachoRecupera_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Frm_GuiaPreDespachoRecupera_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim sql As String = "SELECT fpre_codi, cli_nomb,  fpre_fecdes, fpre_totsopo, fpre_totunidad, fpre_totpeso " +
                            "FROM TMPFICHPRED, CLIENTES WHERE Cli_rut=fpre_rutcli AND fpre_codienca='" + Frm_Principal.InfoUsuario.Text + "'"
        Me.DataGridView1.DataSource = fnc.ListarTablasSQL(sql)
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        If e.RowIndex > -1 Then
            Dim _formInterface As IForm = CType(Me.Owner, IForm)
            _formInterface.ChangeTextBoxText(DataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString())
            Me.Close()
        End If
    End Sub

    Private Sub DataGridView1_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.ColumnIndex = 0 AndAlso e.RowIndex > -1 Then
            Dim sql As String = "DELETE FROM TMPfichpred WHERE fpre_codi='" + Me.DataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString() + "'"
            If fnc.MovimientoSQL(sql) > 0 Then
                MsgBox("Temporal eliminado", MsgBoxStyle.Information, "Aviso")
                Dim sqle As String = "SELECT fpre_codi, cli_nomb,  fpre_fecdes, fpre_totsopo, fpre_totunidad, fpre_totpeso " +
                                    "FROM TMPFICHPRED, CLIENTES WHERE Cli_rut=fpre_rutcli "
                Me.DataGridView1.DataSource = fnc.ListarTablasSQL(sqle)
            Else
                MsgBox("Error al eliminar el temporal seleccionado", MsgBoxStyle.Information, "Aviso")
            End If
        End If
    End Sub


End Class
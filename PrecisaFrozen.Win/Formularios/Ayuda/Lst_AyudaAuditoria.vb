Public Class Lst_AyudaAuditoria

    Dim fnc As New Funciones

    Public cliente As String = "NO"

    Private Sub DataGridView1_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        If e.RowIndex > -1 AndAlso e.ColumnIndex > -1 Then
            Dim _formInterface As IForm = CType(Me.Owner, IForm)
            _formInterface.ChangeTextBoxText(DataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString())
            Me.Close()
        End If
    End Sub

    Private Sub Lst_AyudaClientes_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        txtbusca.Text = ""
    End Sub

    Private Sub Lst_ClientesAyuda_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        DataGridView1.DataSource = New Funciones().ListarTablasSQL("SELECT IdAuditoriaFicha, descripcion FROM ficha_auditoria ORDER BY IdAuditoriaFicha")


    End Sub


    Private Sub txtbusca_KeyDown1(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtbusca.KeyDown
        If e.KeyCode = Keys.Enter Then
            If DataGridView1.Rows.Count = 1 Then
                Dim _formInterface As IForm = CType(Me.Owner, IForm)
                _formInterface.ChangeTextBoxText(DataGridView1.Rows(0).Cells(0).Value.ToString())
                Me.Close()
            End If
        End If
    End Sub

    Private Sub txtbusca_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtbusca.TextChanged

            DataGridView1.DataSource = New Funciones().ListarTablasSQL("SELECT IdAuditoriaFicha, descripcion FROM ficha_auditoria " +
            "WHERE (IdAuditoriaFicha LIKE '%" + txtbusca.Text + "%' OR descripcion LIKE '%" + txtbusca.Text + "%') ORDER BY IdAuditoriaFicha  ")
  


    End Sub

    Private Sub DataGridView1_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyUp
        txtbusca.Focus()
        txtbusca.Text = ChrW(e.KeyValue)
        txtbusca.Select(txtbusca.Text.Length, 0)
    End Sub
End Class
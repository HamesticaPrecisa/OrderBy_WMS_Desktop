Public Class Lst_AyudaContratos

    Dim fnc As New Funciones
    Public condicion As String = ""

    Private Sub Lst_AyudaContratos_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        txtbusca.Text = ""
    End Sub

    Private Sub Lst_AyudaContratos_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            If DataGridView1.Rows.Count = 1 Then
                Dim _formInterface As IForm = CType(Me.Owner, IForm)
                _formInterface.ChangeTextBoxText(DataGridView1.Rows(0).Cells(0).Value.ToString())
                Me.Close()
            End If
        End If
    End Sub

    Private Sub Lst_AyudaContratos_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'DataGridView1.DataSource = fnc.ListarTablasSQL("SELECT cont_codi, cont_descr FROM contrato " + condicion + " AND cont_estado='0'")
        DataGridView1.DataSource = fnc.ListarTablasSQL("SELECT cont_codi,cont_descr,estado=case when cont_estado='0' then 'ACTIVO' else 'INACTIVO' end FROM contrato " + condicion + " and cont_estado='0' order by cont_estado,cont_descr asc")
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        If e.RowIndex > -1 Then
            Dim _formInterface As IForm = CType(Me.Owner, IForm)
            _formInterface.ChangeTextBoxText(DataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString())
            Me.Close()
        End If
    End Sub

    Private Sub txtbusca_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtbusca.TextChanged
        Dim tabla As DataTable = fnc.ListarTablasSQL("SELECT cont_codi, cont_descr FROM contrato " + condicion + " AND cont_estado='0' AND cont_descr LIKE '%" + txtbusca.Text + "%'")
        If tabla.Rows.Count > 0 Then
            DataGridView1.DataSource = tabla
        End If
    End Sub

    Private Sub DataGridView1_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyUp
        txtbusca.Focus()
        txtbusca.Text = ChrW(e.KeyValue)
        txtbusca.Select(txtbusca.Text.Length, 0)
    End Sub
    
End Class
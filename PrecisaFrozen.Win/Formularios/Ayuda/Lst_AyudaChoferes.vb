Public Class Lst_AyudaChoferes
    Dim fnc As New Funciones

    ' Public where As String = ""

    Private Sub Lst_AyudaChoferes_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
     
        Dim sql As String = "SELECT Cho_rut, cho_nombre FROM choferes"

        DataGridView1.DataSource = fnc.ListarTablasSQL(sql)

    End Sub

    Private Sub txtbusca_KeyUp(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtbusca.KeyUp

        Dim sql As String = "SELECT cho_rut, cho_nombre FROM Choferes WHERE cho_rutclie " +
            "LIKE '%" + txtbusca.Text + "%' OR cho_nombre LIKE '%" + txtbusca.Text + "%'"
        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

        If tabla.Rows.Count > 0 Then
            Me.DataGridView1.DataSource = tabla
        End If

    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        If e.RowIndex > -1 Then
            Dim _formInterface As IForm = CType(Me.Owner, IForm)
            _formInterface.ChangeTextBoxText(DataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString())
            Me.Close()
        End If
    End Sub

    Private Sub txtbusca_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtbusca.KeyPress
        If e.KeyChar = ChrW(13) Then
            If Me.DataGridView1.Rows.Count = 1 Then
                Dim _formInterface As IForm = CType(Me.Owner, IForm)
                _formInterface.ChangeTextBoxText(DataGridView1.Rows(0).Cells(0).Value.ToString())
                Me.Close()
            End If
        End If
    End Sub
End Class
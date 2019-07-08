Public Class Lst_AyudaOrigenes

    Dim fnc As New Funciones

    ' Dim where As String = ""

    Dim modo As Integer = 0

    Private Sub Lst_AyudaOrigenes_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim sql As String = ""

        If RealizarAccion("012", "062", False) = True Then
            modo = 1
            sql = "SELECT ori_codi, ori_descr FROM Origen "
        Else
            modo = 2
            sql = "SELECT ori_codi, ori_descr FROM Origen WHERE ori_codi<>'90' "
        End If

        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

        If tabla.Rows.Count > 0 Then
            Me.DataGridView1.DataSource = tabla
        End If

    End Sub

    Private Sub txtbusca_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtbusca.TextChanged
        Dim sql As String = ""

        If RealizarAccion("012", "062", False) = True Then
            modo = 1
            sql = "SELECT ori_codi, ori_descr FROM Origen WHERE ori_descr LIKE '%" + txtbusca.Text + "%'"
        Else
            modo = 2
            sql = "SELECT ori_codi, ori_descr FROM Origen WHERE ori_codi<>'90' AND ori_descr LIKE '%" + txtbusca.Text + "%'"
        End If

        Dim tabla As DataTable = fnc.ListarTablasSQL(Sql)

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

End Class
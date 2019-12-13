Public Class Lst_AyudaFamilias

    Dim fnc As New Funciones
    Private Sub DataGridView1_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        If e.RowIndex > -1 Then
            Dim _formInterface As IForm = CType(Me.Owner, IForm)
            _formInterface.ChangeTextBoxText(DataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString())
            Me.Close()
        End If

    End Sub
    Function dataEliminaDigitos(ByVal tablaRecibida As DataTable)
        Dim tablaEnviada As New DataTable
        tablaEnviada.Columns.Add("fam_codi")
        tablaEnviada.Columns.Add("fam_descr")
        For i As Integer = 0 To tablaRecibida.Rows.Count - 1
            If tablaRecibida.Rows(i)(0).ToString.Length >= 4 Then
                tablaEnviada.Rows.Add(Mid(tablaRecibida.Rows(i)(0), 1, Len(tablaRecibida.Rows(i)(0).ToString()) - 4), tablaRecibida.Rows(i)(1))
            End If
        Next
        Return tablaEnviada
    End Function


    Private Sub Lst_AyudaFamilias_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim sql = "SELECT fam_codi, fam_descr FROM famprod ORDER BY fam_codi ASC"
        BindingSource1.DataSource = dataEliminaDigitos(fnc.ListarTablasSQL(sql))
        BindingNavigator1.BindingSource = BindingSource1
        DataGridView1.DataSource = BindingSource1
    End Sub


    Private Sub txtbusca_KeyUp(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtbusca.KeyUp
        Dim sql = "SELECT fam_codi, fam_descr FROM famprod WHERE (fam_codi LIKE '%" + txtbusca.Text + "%' OR " +
            "fam_descr LIKE '%" + txtbusca.Text + "%') ORDER BY fam_codi ASC"
        BindingSource1.DataSource = dataEliminaDigitos(fnc.ListarTablasSQL(sql))
        BindingNavigator1.BindingSource = BindingSource1
        DataGridView1.DataSource = BindingSource1
    End Sub

End Class
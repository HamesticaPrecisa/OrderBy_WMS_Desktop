Public Class Frm_monedasAyuda

    Dim fnc As New Funciones

    Private Sub Frm_monedasAyuda_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim sql As String = "SELECT mon_codi, mon_descr FROM monedas"
        DgvMonedas.DataSource = fnc.ListarTablasSQL(sql)
    End Sub

    Private Sub DgvMonedas_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvMonedas.CellDoubleClick
        If e.RowIndex > -1 Then
            Dim _formInterface As IForm = CType(Me.Owner, IForm)
            _formInterface.ChangeTextBoxText(DgvMonedas.Rows(e.RowIndex).Cells(0).Value.ToString())
            Me.Close()
        End If
    End Sub

    Private Sub txtbusca_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtbusca.TextChanged
        Dim sql As String = "SELECT mon_codi, mon_descr FROM monedas WHERE mon_descr LIKE'%" + txtbusca.Text + "%'"
        DgvMonedas.DataSource = fnc.ListarTablasSQL(sql)
    End Sub

    Private Sub txtbusca_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtbusca.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) AndAlso DgvMonedas.Rows.Count = 1 Then
            Dim _formInterface As IForm = CType(Me.Owner, IForm)
            _formInterface.ChangeTextBoxText(DgvMonedas.Rows(0).Cells(0).Value.ToString())
            Me.Close()
        End If
    End Sub
End Class
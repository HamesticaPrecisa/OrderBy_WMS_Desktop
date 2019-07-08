Public Class Frm_CotizacionesListado

    Public condicion As String
    Dim fnc As New Funciones

    Private Sub Frm_CotizacionesListado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DgvCotizaciones.DataSource = fnc.ListarTablasSQL("SELECT coti_codi, coti_descr FROM cotizaciones " + condicion + " AND coti_estado='0'")
    End Sub

    Private Sub txtbusca_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtbusca.TextChanged
        Dim tabla As DataTable = fnc.ListarTablasSQL("SELECT coti_codi, coti_descr FROM cotizaciones " + condicion + " AND coti_estado='0' AND coti_descr LIKE '%" + txtbusca.Text + "%'")
        If tabla.Rows.Count > 0 Then
            DgvCotizaciones.DataSource = tabla
        End If
    End Sub
 
    Private Sub Frm_CotizacionesListado_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            If DgvCotizaciones.Rows.Count = 1 Then
                Dim _formInterface As IForm = CType(Me.Owner, IForm)
                _formInterface.ChangeTextBoxText(DgvCotizaciones.Rows(0).Cells(0).Value.ToString())
                Me.Close()
            End If
        End If
    End Sub

    Private Sub DgvCotizaciones_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvCotizaciones.CellDoubleClick
        If e.RowIndex > -1 Then
            Dim _formInterface As IForm = CType(Me.Owner, IForm)
            _formInterface.ChangeTextBoxText(DgvCotizaciones.Rows(e.RowIndex).Cells(0).Value.ToString())
            Me.Close()
        End If
    End Sub

    Private Sub DgvCotizaciones_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DgvCotizaciones.KeyUp
        txtbusca.Focus()
        txtbusca.Text = ChrW(e.KeyValue)
        txtbusca.Select(txtbusca.Text.Length, 0)
    End Sub
End Class
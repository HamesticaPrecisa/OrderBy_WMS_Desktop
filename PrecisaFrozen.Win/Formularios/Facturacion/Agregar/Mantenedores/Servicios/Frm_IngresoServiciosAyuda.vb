Public Class Frm_IngresoServiciosAyuda

    Dim fnc As New Funciones

    Private Sub Lst_AyudaServicios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim sql As String = "SELECT Serv_Cod, Serv_nom  FROM FacServicios "
        DgvServicios.DataSource = fnc.ListarTablasSQL(sql)
    End Sub

    Private Sub txtbusca_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtbusca.KeyUp
        Dim sql As String = "SELECT Serv_Cod, Serv_nom  FROM FacServicios WHERE serv_nom LIKE '%" + txtbusca.Text + "%'"
        DgvServicios.DataSource = fnc.ListarTablasSQL(sql)
    End Sub

    Private Sub DataGridView1_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvServicios.CellDoubleClick
        If e.RowIndex > -1 Then
            Dim _formInterface As IForm = CType(Me.Owner, IForm)
            _formInterface.ChangeTextBoxText(DgvServicios.Rows(e.RowIndex).Cells(0).Value.ToString())
            Me.Close()
        End If
    End Sub

    Private Sub txtbusca_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtbusca.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) AndAlso DgvServicios.Rows.Count = 1 Then
            Dim _formInterface As IForm = CType(Me.Owner, IForm)
            _formInterface.ChangeTextBoxText(DgvServicios.Rows(0).Cells(0).Value.ToString())
            Me.Close()
        End If
    End Sub
End Class
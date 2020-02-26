Public Class Lst_Pedidos_Fecha

    Dim fnc As New Funciones

    Private Sub Lst_Pedidos_Fecha_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim fecha1 = DateTime.Now.ToString("dd/MM/yyyy")
        DgvLimiteFechas.DataSource = fnc.ListarTablasSQL("select ID, Fecha, Limite from Pedidos_Tipo_Exportacion_Limite_Fecha where Fecha>='" + fecha1 + "' order by Fecha desc;")
    End Sub

    Private Sub DgvLimiteFechas_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvLimiteFechas.CellDoubleClick
        If e.RowIndex > -1 Then
            Dim _formInterface As IForm = CType(Me.Owner, IForm)

            _formInterface.ChangeTextBoxText(DgvLimiteFechas.Rows(e.RowIndex).Cells(0).Value)

            Me.Close()
        End If
    End Sub
End Class
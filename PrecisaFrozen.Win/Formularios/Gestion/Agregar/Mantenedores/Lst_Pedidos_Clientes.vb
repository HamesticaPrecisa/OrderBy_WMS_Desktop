Public Class Lst_Pedidos_Clientes
    Dim fnc As New Funciones

    Private Sub Lst_Pedidos_Clientes_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dgvclientespedidos.DataSource = fnc.ListarTablasSQL("select distinct ID, Rut_Cliente, Nombre from Pedidos_Tipo_Exportacion_Limites_Grupo_Clientes a inner join Pedidos_Tipo_Exportacion_Limites_Grupo as b on a.ID_Limite_Grupo=b.ID where Rut_Cliente<>'799842408'")
    End Sub

    Private Sub Dgvclientespedidos_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgvclientespedidos.CellDoubleClick
        If e.RowIndex > -1 Then
            Dim _formInterface As IForm = CType(Me.Owner, IForm)

            _formInterface.ChangeTextBoxText(Dgvclientespedidos.Rows(e.RowIndex).Cells(0).Value)

            Me.Close()
        End If
    End Sub
End Class
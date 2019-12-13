Public Class FrmInformeSaldosNoConf
    Dim fnc As New Funciones
    Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox1.TextChanged
        Dim sql2 As String = "select pedido,orden,pallet,saldoconfi as [Saldo A confirmar]FROM maereglas where f1  like'" + TextBox1.Text.Trim() + "%'"
        Dim tabla As DataTable = fnc.ListarTablasSQL(sql2)
        DgvResultado.DataSource = tabla
    End Sub

    Private Sub FrmInformeSaldosNoConf_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
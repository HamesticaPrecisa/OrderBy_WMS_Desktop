Public Class Frm_horpedido
    Dim fnc As New Funciones
    Private Sub Dtfecha_ValueChanged(sender As System.Object, e As System.EventArgs) Handles Dtfecha.ValueChanged

    End Sub

    Private Sub Btn_Calcular_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Calcular.Click
        For i As Integer = 0 To DgvResultado.RowCount - 1
            DgvResultado.Rows.RemoveAt(0)
        Next

        Dim SQL As String = "SELECT * FROM VG_HORAS_PEDIDO " +
                        "WHERE convert(date,TERMINO)='" + devuelve_fecha(Dtfecha.Value) + "' ORDER BY TERMINO DESC "

        DgvResultado.DataSource = fnc.ListarTablasSQL(SQL)
    End Sub

    Private Sub Frm_horpedido_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        f_controlHOR = False
    End Sub
End Class
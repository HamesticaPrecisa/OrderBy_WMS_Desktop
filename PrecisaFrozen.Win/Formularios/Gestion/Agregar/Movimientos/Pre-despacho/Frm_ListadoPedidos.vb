Public Class Frm_ListadoPedidos

    Dim fnc As New Funciones

    Public rutcli As String = ""


    Public Sub llena_grilla()

        'Dim sql As String = "SELECT Orden, pf.pedido, fecha, Destino, CASE WHEN COUNT(DISTINCT scaj_codcaja)=(SELECT SUM(cajas) FROM Pedidos_detalle WHERE pedido=pf.pedido) THEN 1 ELSE 0 END as caj " +
        '    "FROM  Pedidos_ficha pf LEFT JOIN TMP_SELECCIONCAJAS ON Orden=scaj_codped  WHERE cliente='" + rutcli.ToString() + "'  AND fecha>=convert(date, getdate()) " +
        '    "AND isnull(Ped_EstPred,0)<'3'  GROUP BY Orden, pf.pedido, fecha, Destino  ORDER BY Orden DESC "

        Dim sql As String = "SELECT top 15 Orden,ordenconjunta, pf.pedido, fecha, Destino, CASE WHEN COUNT(DISTINCT scaj_codcaja)=(SELECT SUM(cajas) FROM Pedidos_detalle WHERE pedido=pf.pedido) THEN 1 ELSE 0 END as caj , destino_rut  as RUTDES, destino_dir AS DIRRUT " +
        "FROM  Pedidos_ficha pf LEFT JOIN TMP_SELECCIONCAJAS ON Orden=scaj_codped  WHERE cliente='" + rutcli.ToString() + "'" +
        "AND isnull(Ped_EstPred,0)<'3'  GROUP BY Orden, pf.pedido,ordenconjunta, fecha, Destino, destino_rut , destino_dir  ORDER BY Orden DESC "

        DgvPedidos.DataSource = fnc.ListarTablasSQL(sql)

    End Sub

    Private Sub Frm_ListadoPedidos_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Timer1.Stop()
    End Sub

    Private Sub Frm_ListadoPedidos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        llena_grilla()
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        llena_grilla()
    End Sub

    Private Sub DgvPedidos_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvPedidos.CellDoubleClick
        If e.RowIndex > -1 Then
            Dim _formInterface As IForm = CType(Me.Owner, IForm)
            _formInterface.ChangeTextBoxText(DgvPedidos.Rows(e.RowIndex).Cells(0).Value.ToString() + "," + Convert.ToInt32(DgvPedidos.Rows(e.RowIndex).Cells(5).Value).ToString() + "," + DgvPedidos.Rows(e.RowIndex).Cells(4).Value.ToString() + "," + DgvPedidos.Rows(e.RowIndex).Cells(6).Value.ToString() + "," + DgvPedidos.Rows(e.RowIndex).Cells(7).Value.ToString())
            Me.Close()
        End If
    End Sub
End Class
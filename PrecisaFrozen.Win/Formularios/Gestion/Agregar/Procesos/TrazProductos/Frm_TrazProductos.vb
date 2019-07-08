Public Class Frm_TrazProductos
    Dim fnc As New Funciones

    Private Sub btn_BuscaCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_BuscaCliente.Click
        Dim frm As New Lst_AyudaClientes
        frm.ShowDialog(Frm_Principal)
        Dim valorRecibido = Frm_Principal.buscavalor

        If Len(valorRecibido) >= 9 Then

            Dim SqlBusca As String = "SELECT cli_nomb FROM clientes WHERE " +
                "cli_rut='" + valorRecibido + "'"

            Dim tabla As DataTable = fnc.ListarTablasSQL(SqlBusca)

            If tabla.Rows.Count > 0 Then

                TxtClirut.Text = valorRecibido
                txtclinom.Text = tabla.Rows(0)(0).ToString()
                TxtClirut.Enabled = False
                btn_BuscaCliente.Enabled = False
                Btn_buscaProducto.Enabled = True
            Else
                MsgBox("El rut ingresado no existe", MsgBoxStyle.Information, "Aviso")
            End If
        End If
        Frm_Principal.buscavalor = ""
    End Sub

    Private Sub Btn_buscaProducto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_buscaProducto.Click
        Dim frm As New Lst_AyudaProductos
        frm.Condicion = "mae_clirut='" + QuitarCaracteres(TxtClirut.Text) + "' "
        frm.IsRecepcion = True
        frm.ShowDialog(Frm_Principal)

        If Frm_Principal.buscavalor <> "" Then
            Me.txtprodcod.Text = Frm_Principal.buscavalor

            Dim sqlBusca = "SELECT mae_descr FROM maeprod WHERE mae_codi='" + txtprodcod.Text + "'"

            Dim tabla As DataTable = fnc.ListarTablasSQL(sqlBusca)
            If tabla.Rows.Count > 0 Then
                txtprodnom.Text = tabla.Rows(0)(0).ToString()
            End If

        End If
        Frm_Principal.buscavalor = ""
    End Sub

    Private Sub btn_acp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_acp.Click

        Dim _saldo As String = "SELECT SUM(UNIE)-SUM(UNIS), SUM(ENVE)-SUM(ENVS), SUM(KGE)-SUM(KGS) FROM GvwTrazProd " +
                                "WHERE producto='" + txtprodcod.Text + "'  AND fecha<='" + devuelve_fecha(dtinicial.Value) + "'"
        Dim tabla As DataTable = fnc.ListarTablasSQL(_saldo)

        DataGridView1.Rows.Add(devuelve_fecha_Formato2(dtinicial.Value), "", "", tabla.Rows(0)(0).ToString(), "", "", tabla.Rows(0)(1).ToString(), "", "", tabla.Rows(0)(2).ToString())
 
        Dim sql As String = "SELECT fecha, " +
                            "ISNULL(CASE WHEN TIPO='EN' THEN SUM(UNIE) END,0) ENTRADA_SOPO, " +
                            "ISNULL(CASE WHEN TIPO='SA' THEN SUM(UNIS) END,0) SALIDA_SOPO, " +
                            "ISNULL(CASE WHEN TIPO='EN' THEN SUM(ENVE) END,0) ENTRADA_UNID, " +
                            "ISNULL(CASE WHEN TIPO='SA' THEN SUM(ENVS) END,0) SALIDA_UNID," +
                            "ISNULL(CASE WHEN TIPO='EN' THEN SUM(KGE) END,0) ENTRADA_KG," +
                            "ISNULL(CASE WHEN TIPO='SA' THEN SUM(KGS) END,0) SALIDA_KG " +
                            "FROM GvwTrazProd WHERE producto='" + txtprodcod.Text + "'  AND fecha>='" + devuelve_fecha(dtinicial.Value) + "' " +
                            "AND fecha>='" + devuelve_fecha(dtfinal.Value) + "'" +
                            "GROUP BY TIPO, fecha " +
                            "ORDER BY fecha ASC"

        Dim tablaDeta As DataTable = fnc.ListarTablasSQL(sql)

        For i As Integer = 0 To tablaDeta.Rows.Count - 1

            DataGridView1.Rows.Add(devuelve_fecha_Formato2(tablaDeta.Rows(0)(1).ToString()), "", "", tabla.Rows(0)(0).ToString(), "", "", tabla.Rows(0)(1).ToString(), "", "", tabla.Rows(0)(2).ToString())
        Next

        'DataGridView1.Rows.Add(, , , , , , , , , , , , , )

    End Sub

End Class
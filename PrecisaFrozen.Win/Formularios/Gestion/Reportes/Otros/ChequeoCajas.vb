Public Class ChequeoCajas
    Dim fnc As New Funciones
    Dim thread As Threading.Thread

    Private Sub Btn_Calcular_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Calcular.Click
        Dim WhereC As String = ""


        If Txtcliente.Text <> "" Then
            WhereC = " where d.cli_nomb like '%" + Txtcliente.Text + "%' "
        End If

        DgvResultado.DataSource = Nothing

        DgvResultado.Rows.Clear()

        Dim s As String = "SELECT a.caj_cod as Caja, COUNT(*) AS Duplicados, MIN(a.caj_pcod) AS Pallet1, MAX(a.caj_pcod) AS Pallet2, MIN(b.frec_codi1) AS Recepcion1, MAX(b.frec_codi1) AS Recepcion2, MIN(d.cli_nomb) AS Cliente1, MAX(d.cli_nomb) AS Cliente2 FROM DetaReceCajas a LEFT JOIN detaRece b ON b.drec_codi = a.caj_pcod LEFT JOIN fichRece c ON c.frec_codi = b.frec_codi1 LEFT JOIN clientes d ON d.cli_rut = c.frec_rutcli " + WhereC + " GROUP BY a.caj_cod HAVING COUNT(*) > 1"

        Dim tabla As DataTable = fnc.ListarTablasSQL(s)

        If tabla.Rows.Count = 0 Then
            MsgBox("Este Cliente no tiene cajas repetidas.", MsgBoxStyle.Information, "Aviso")
            DgvResultado.DataSource = Nothing
            Txtcliente.Text = ""
            txtrutcli.Text = ""
            DgvResultado.Rows.Clear()
            Exit Sub
        End If

        ProgressBar1.Maximum = tabla.Rows.Count

        For i As Integer = 0 To tabla.Rows.Count - 1

            DgvResultado.Rows.Add(tabla.Rows(i)(0).ToString(), tabla.Rows(i)(1).ToString(), tabla.Rows(i)(2).ToString(),
                                  tabla.Rows(i)(3).ToString(), tabla.Rows(i)(4).ToString(), tabla.Rows(i)(5).ToString(),
                                  tabla.Rows(i)(6).ToString(), tabla.Rows(i)(7).ToString())



            ProgressBar1.Increment(1)
        Next

        Threading.Thread.Sleep(1000)
        ProgressBar1.Value = 0
        btn_nuevo.Enabled = True
        txtbusca.Enabled = True
        txtrutcli.Text = ""
    End Sub

    Private Sub ChequeoCajas_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Btn_cliente_Click(sender As System.Object, e As System.EventArgs) Handles Btn_cliente.Click

        clientesbusc = "SI"
        Dim frm As New Lst_AyudaClientes
        frm.cliente = "SI"
        frm.ShowDialog(Frm_Principal)
        If Frm_Principal.buscavalor <> "" Then
            txtrutcli.Text = Frm_Principal.buscavalor
            Txtcliente.Text = RetornaCliente(Frm_Principal.buscavalor.ToString())
            Frm_Principal.buscavalor = ""
            Btn_Calcular.Enabled = True
        End If
        clientesbusc = ""
        'Lst_AyudaClientes.ShowDialog(Frm_Principal)
        'If Frm_Principal.buscavalor.ToString <> "" Then
        '    Txtcliente.Text = RetornaCliente(Frm_Principal.buscavalor.ToString())
        '    txtrutcli.Text = Frm_Principal.buscavalor.ToString()
        '    Frm_Principal.buscavalor = ""
        '    Btn_Calcular.Enabled = True
        'End If
    End Sub

    Private Sub btn_nuevo_Click(sender As System.Object, e As System.EventArgs) Handles btn_nuevo.Click
        txtbusca.Enabled = False
        txtrutcli.Text = ""
        Txtcliente.Text = ""
        txtbusca.Text = ""
        btn_nuevo.Enabled = False
        DgvResultado.DataSource = Nothing

        DgvResultado.Rows.Clear()
    End Sub

    Private Sub Btn_Salir_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Salir.Click
        Close()
    End Sub

    Private Sub txtbusca_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtbusca.TextChanged
        DgvResultado.DataSource = New Funciones().ListarTablasSQL("SELECT a.caj_cod as Caja, COUNT(*) AS Duplicados, " +
      "MIN(a.caj_pcod) AS Pallet1, MAX(a.caj_pcod) AS Pallet2, " +
   "MIN(b.frec_codi1) AS Recepcion1, MAX(b.frec_codi1) AS Recepcion2, " +
   "MIN(d.cli_nomb) AS Cliente1, MAX(d.cli_nomb) AS Cliente2 " +
 "FROM DetaReceCajas a " +
 "LEFT JOIN detaRece b ON b.drec_codi = a.caj_pcod " +
 "LEFT JOIN fichRece c ON c.frec_codi = b.frec_codi1 " +
 "LEFT JOIN clientes d ON d.cli_rut = c.frec_rutcli " +
"where d.cli_nomb like '%" + txtbusca.Text + "%' or a.caj_cod like '%" + txtbusca.Text + "%'" +
 "GROUP BY a.caj_cod " +
"HAVING COUNT(*) > 1 ")

    End Sub
End Class
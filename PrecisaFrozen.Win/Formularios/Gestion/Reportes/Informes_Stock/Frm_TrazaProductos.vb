Imports System.Threading
Public Class Frm_TrazaProductos

    Dim fnc As New Funciones
    Dim thread As Thread
#Region "Cliente"


    Private Sub Btn_cliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_cliente.Click
        Lst_AyudaClientes.ShowDialog(Frm_Principal)
        If Frm_Principal.buscavalor.ToString <> "" Then
            Txtcliente.Text = RetornaCliente(Frm_Principal.buscavalor.ToString())
            LblCliente.Text = Frm_Principal.buscavalor.ToString()
            Frm_Principal.buscavalor = ""
            Btn_Producto.Enabled = True
        End If
    End Sub

#End Region


#Region "Producto"
    Private Sub Btn_Producto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Producto.Click

        Dim frm As New Lst_AyudaProductos
        If fnc.verificaExistencia("clientes", "Cli_rut", LblCliente.Text) = True Then
            frm.Condicion = "mae_clirut='" + QuitarCaracteres(LblCliente.Text) + "' "
        End If

        frm.ShowDialog(Frm_Principal)

        LblProducto.Text = Frm_Principal.buscavalor.ToString()
        TxtProducto.Text = RetornaProducto(Frm_Principal.buscavalor.ToString())
        Btn_Calcular.Enabled = True
        Btn_cliente.Enabled = False
    End Sub

#End Region


    Private Sub Btn_Calcular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Calcular.Click
        CheckForIllegalCrossThreadCalls = False
        thread = New Thread(AddressOf Procesa)
        'Iniciamos el subproceso.
        thread.Start()
        Me.Btn_Calcular.Enabled = False
        Me.GroupBox1.Enabled = False
    End Sub

    Sub Procesa()


        'Dim s As String = "SELECT COUNT(1) as soportantes,drec_codpro,drec_rutcli,drec_contcli, " +
        '         "frec_origen,cont_descr, ori_descr,mae_descr,sum(drec_unidades) as unidades, " +
        '        "sum(drec_peso) as kilos, convert(nvarchar,convert(date,drec_fecrec,111),103) as fechamov, " +
        '       "1 as recep,drec_fecrec as fecharef,  FROM detarece INNER JOIN fichrece on " +
        '      "LEFT(drec_codi,7)=fichrece.frec_codi INNER JOIN maeprod on mae_codi=drec_codpro " +
        '     "INNER JOIN contrato on cont_codi=frec_contcli LEFT JOIN origen ON " +
        '    "ori_codi=frec_origen WHERE drec_rutcli<>'116095327' AND drec_codvig=0 AND " +
        '   "drec_rutcli='" + LblCliente.Text + "' AND drec_codpro='" + LblProducto.Text + "' AND drec_fecrec>=('" + devuelve_fecha(DtFechaIni.Value) + "') AND " +
        '  "drec_fecrec<=('" + devuelve_fecha(DtFechaTer.Value) + "') " +
        ' "GROUP BY drec_codpro,drec_rutcli,drec_contcli,frec_origen,ori_descr,mae_descr," +
        '"drec_fecrec,cont_descr UNION ( SELECT SUM(CASE ddes_pallet WHEN 1 THEN 1 ELSE 0 END) as soportantes," +
        '"ddes_codpro,ddes_rutcli,ddes_contcli,fdes_origen,cont_descr,ori_descr, mae_descr, " +
        '"sum(ddes_unidades) as unidades,sum(ddes_peso) as kilos, " +
        '"convert(nvarchar,convert(date,ddes_fecha,111),103) as fechamov, " +
        '"0 as recep,ddes_fecha as fecharef FROM detadespa INNER JOIN detarece ON ddes_codrece=drec_codi AND " +
        '"drec_rutcli<>'116095327' AND drec_codvig=0 INNER JOIN maeprod on mae_codi=ddes_codpro INNER JOIN contrato on " +
        '"cont_codi=ddes_contcli INNER JOIN fichdespa ON fdes_codi=left(ddes_codi,7) LEFT JOIN origen ON " +
        '"ori_codi=fdes_origen WHERE ddes_rutcli<>'116095327' AND ddes_codvig=0 AND ddes_rutcli='" + LblCliente.Text + "' AND " +
        '"ddes_codpro='" + LblProducto.Text + "' AND ddes_fecha>=('" + devuelve_fecha(DtFechaIni.Value) + "') AND " +
        '"ddes_fecha<=('" + devuelve_fecha(DtFechaTer.Value) + "') " +
        '"GROUP BY ddes_codpro,ddes_rutcli,ddes_contcli,fdes_origen,ori_descr,mae_descr,ddes_fecha,cont_descr ) " +
        '"ORDER BY fecharef"

        Dim s As String = "SELECT COUNT(1) as soportantes,drec_codpro,drec_rutcli,drec_contcli," +
                  "frec_origen,cont_descr, ori_descr,mae_descr,sum(drec_unidades) as unidades," +
                  "sum(drec_peso) as kilos, convert(nvarchar,convert(date,drec_fecrec,111),103) as fechamov," +
                  "1 as recep,drec_fecrec as fecharef, fichrece.frec_codi as documento FROM detarece INNER JOIN fichrece on " +
                  "LEFT(drec_codi,7)=fichrece.frec_codi INNER JOIN maeprod on mae_codi=drec_codpro " +
                  "INNER JOIN contrato on cont_codi=frec_contcli LEFT JOIN origen ON " +
                  "ori_codi=frec_origen WHERE drec_rutcli<>'116095327' AND drec_codvig=0 AND " +
                  "drec_rutcli='" + LblCliente.Text + "' AND drec_codpro='" + LblProducto.Text + "' AND drec_fecrec>=('" + devuelve_fecha(DtFechaIni.Value) + "')" +
                  "AND drec_fecrec<=('" + devuelve_fecha(DtFechaTer.Value) + "') GROUP BY drec_codpro,drec_rutcli,drec_contcli,frec_origen,ori_descr,mae_descr," +
                  "drec_fecrec,cont_descr, fichrece.frec_codi UNION ( SELECT SUM(CASE ddes_pallet WHEN 1 THEN 1 ELSE 0 END) as soportantes," +
                  "ddes_codpro,ddes_rutcli,ddes_contcli,fdes_origen,cont_descr,ori_descr, mae_descr," +
                  "sum(ddes_unidades) as unidades,sum(ddes_peso) as kilos," +
                  "convert(nvarchar,convert(date,ddes_fecha,111),103) as fechamov," +
                  "0 as recep,ddes_fecha as fecharef, fdes_codi as documento FROM detadespa INNER JOIN detarece ON ddes_codrece=drec_codi AND " +
                  "drec_rutcli<>'116095327' AND drec_codvig=0 INNER JOIN maeprod on mae_codi=ddes_codpro INNER JOIN contrato on " +
                  "cont_codi=ddes_contcli INNER JOIN fichdespa ON fdes_codi=left(ddes_codi,7) LEFT JOIN origen ON " +
                  "ori_codi=fdes_origen WHERE ddes_rutcli<>'116095327' AND ddes_codvig=0 AND ddes_rutcli='" + LblCliente.Text + "' AND " +
                  "ddes_codpro='" + LblProducto.Text + "' AND ddes_fecha>=('" + devuelve_fecha(DtFechaIni.Value) + "') AND ddes_fecha<=('" + devuelve_fecha(DtFechaTer.Value) + "') " +
                  "GROUP BY ddes_codpro,ddes_rutcli,ddes_contcli,fdes_origen,ori_descr,mae_descr,ddes_fecha,cont_descr,fdes_codi ) " +
                  "ORDER BY fecharef"

        Dim tabla As DataTable = fnc.ListarTablasSQL(s)
        'DgvResultado.DataSource = fnc.ListarTablasSQL(s)

        ProgressBar1.Maximum = tabla.Rows.Count

        Dim saldosopo As Integer
        Dim saldouni As Integer
        Dim saldopeso As Decimal

        saldosopo = 0
        saldouni = 0
        saldopeso = 0

        For i As Integer = 0 To tabla.Rows.Count - 1


            If Val(tabla.Rows(i)(11).ToString()) = 1 Then
                saldosopo = saldosopo + tabla.Rows(i)(0).ToString()
                saldouni = saldouni + tabla.Rows(i)(8).ToString()
                saldopeso = saldopeso + tabla.Rows(i)(9).ToString()
            ElseIf Val(tabla.Rows(i)(11).ToString()) = 0 Then
                saldosopo = saldosopo - tabla.Rows(i)(0).ToString()
                saldouni = saldouni - tabla.Rows(i)(8).ToString()
                saldopeso = saldopeso - tabla.Rows(i)(9).ToString()
            End If

            If Val(tabla.Rows(i)(11).ToString()) = 1 Then

                DgvResultado.Rows.Add(tabla.Rows(i)(10).ToString(), tabla.Rows(i)(6).ToString(), tabla.Rows(i)(5).ToString(), tabla.Rows(i)(13).ToString(),
                                  tabla.Rows(i)(0).ToString(), 0, saldosopo,
                                  tabla.Rows(i)(8).ToString(), 0, saldouni,
                                  tabla.Rows(i)(9).ToString(), 0, saldopeso)
            ElseIf Val(tabla.Rows(i)(11).ToString()) = 0 Then

                DgvResultado.Rows.Add(tabla.Rows(i)(10).ToString(), tabla.Rows(i)(6).ToString(), tabla.Rows(i)(5).ToString(), tabla.Rows(i)(13).ToString(),
                                  0, tabla.Rows(i)(0).ToString(), saldosopo,
                                  0, tabla.Rows(i)(8).ToString(), saldouni,
                                  0, tabla.Rows(i)(9).ToString(), saldopeso)

            End If

            ProgressBar1.Increment(1)
        Next


        Threading.Thread.Sleep(1000)
        ProgressBar1.Value = 0
        btn_nuevo.Enabled = True
        btn_Imprimir.Enabled = True

    End Sub

    Private Sub btn_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        Me.Btn_Calcular.Enabled = False
        Me.Btn_cliente.Enabled = True
        Me.Btn_Producto.Enabled = False
        btn_nuevo.Enabled = False
        Txtcliente.Text = ""
        TxtProducto.Text = ""
        btn_Imprimir.Enabled = False
        Me.GroupBox1.Enabled = True
        For i As Integer = 0 To DgvResultado.RowCount - 1
            DgvResultado.Rows.RemoveAt(0)
        Next
    End Sub

    Private Sub btn_Imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Imprimir.Click
        Call GridAExcel(DgvResultado)
    End Sub

    Private Sub Frm_ResumidoFecha_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        f_resumido = False
    End Sub

    Private Sub Btn_Salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Salir.Click
        Close()
    End Sub

    Private Sub Frm_ResumidoFecha_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Frm_Principal.buscavalor = ""
    End Sub

    Private Sub txtsopo_TextChanged(sender As System.Object, e As System.EventArgs)

    End Sub
    Private Sub Frm_TrazaProductos_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        f_TrazProd = False
    End Sub
End Class
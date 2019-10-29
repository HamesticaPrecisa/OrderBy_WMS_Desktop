Imports System.Threading
Imports System.Data.SqlClient
Public Class Frm_GuiasPendTunel

    Dim fnc As New Funciones
    Dim thread As Thread

#Region "Cliente"


    Private Sub Btn_cliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_cliente.Click
        Lst_AyudaClientes.ShowDialog(Frm_Principal)
        If Frm_Principal.buscavalor.ToString <> "" Then
            Txtcliente.Text = RetornaCliente(Frm_Principal.buscavalor.ToString())
            LblCliente.Text = Frm_Principal.buscavalor.ToString()
            Frm_Principal.buscavalor = ""
        End If
    End Sub

#End Region

#Region "Producto"

    Private Sub T2producto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T2producto.CheckedChanged
        If T2producto.Checked = True Then
            TxtProducto.Text = "TODOS"
            Btn_Producto.Enabled = False
        Else
            TxtProducto.Text = ""
            Btn_Producto.Enabled = True
        End If
    End Sub

    Private Sub Btn_Producto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Producto.Click

        Dim frm As New Lst_AyudaProductos

        frm.ShowDialog(Frm_Principal)
        If Frm_Principal.buscavalor = "" Then
            T2producto.Checked = True
            Exit Sub
        End If

        LblProducto.Text = Frm_Principal.buscavalor.ToString()
        TxtProducto.Text = RetornaProducto(Frm_Principal.buscavalor.ToString())

    End Sub

#End Region


    Private Sub Frm_GuiasPendTunel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Frm_Principal.buscavalor = ""
        Btn_Calcular.Enabled = True
    End Sub


    Private Sub Btn_Calcular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Calcular.Click
        CheckForIllegalCrossThreadCalls = False
        thread = New Thread(AddressOf Procesa)
        'Iniciamos el subproceso.
        thread.Start()
        Me.Btn_Calcular.Enabled = False
        Me.GroupBox1.Enabled = False
    End Sub

    Sub Procesa()
        Dim WhereR As String = ""
        Dim WhereD As String = ""


        If T2producto.Checked = False Then
            If TxtProducto.Text = "" Then
                T2producto.Checked = True
            Else
                'WhereR = WhereR + "AND drec_codpro='" + LblProducto.Text + "' AND detarece.cod_bod='" + sucursalglo.Trim() + "' "
                'WhereD = WhereD + "AND ddes_codpro='" + LblProducto.Text + "' AND detadespa.cod_bod='" + sucursalglo.Trim() + "' "
            End If

        End If

        Dim sql As String = "SELECT frec_codi, cli_nomb, frec_fecrec, drec_fecprod, mer_nombre, hpt, numpallets" +
                            "  FROM vwGuiasPendTunel "
        If LblCliente.Text.Trim().Length > 0 Then
            WhereR = "frec_rutcli = @frec_rutcli"
        End If
        If T2producto.Checked = False And LblProducto.Text.Trim().Length > 0 Then
            WhereR = WhereR + IIf(WhereR.Length > 0, " AND ", "") +
                              " frec_codi IN (SELECT a.frec_codi1 " +
                              "                 FROM detarece a " +
                              "                INNER JOIN vwGuiasPendTunel b ON b.frec_codi = a.frec_codi1" +
                              "                WHERE a.drec_codpro = @drec_codpro)"
        End If
        If WhereR.Length > 0 Then sql = sql + " WHERE " + WhereR

        Dim tabla As DataTable = fnc.ListarTablasSQL(sql, New SqlParameter() {
                                                        New SqlParameter("@frec_rutcli", LblCliente.Text.Trim()),
                                                        New SqlParameter("@drec_codpro", LblProducto.Text.Trim())
                                                     })

        'DgvResultado.DataSource = tabla
        ProgressBar1.Value = 0
        ProgressBar1.Maximum = tabla.Rows.Count
        For Each row As DataRow In tabla.Rows
            DgvResultado.Rows.Add(row(0), row(1), row(2), row(3), row(4), row(5), row(6))
            ProgressBar1.Increment(1)
        Next

        Threading.Thread.Sleep(1000)
        ProgressBar1.Value = 0
        btn_nuevo.Enabled = True
        btn_Imprimir.Enabled = True

    End Sub


    Private Sub btn_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
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
        If DgvResultado.Rows.Count = 0 Then
            MsgBox("No existe información para mostrar", MsgBoxStyle.Critical, "Aviso")
            Exit Sub
        End If


        Dim tabla As DataTable = DgvResultado.DataSource
        documentoimp = DateTime.Now.ToString("MM-dd-yy") + "GUIASPARATUNEL"
        Dim frm As Frm_MuestraReporte = New Frm_MuestraReporte
        Dim report As New Rpt_GuiasPendTunel

        Dim Ds As New Ds_GuiasPendTunel

        For Each row As DataGridViewRow In DgvResultado.Rows
            Ds.Dt_GuiasPendTunel.AddDt_GuiasPendTunelRow(row.Cells(0).Value.ToString(),
                                         row.Cells(1).Value.ToString(),
                                         row.Cells(4).Value.ToString(),
                                         row.Cells(5).Value.ToString())
        Next
        Dim crt As New Rpt_GuiasPendTunel()
        crt.SetDataSource(Ds)
        crt.SetParameterValue("CLIENTE", IIf(Txtcliente.Text.Trim().Length = 0, "TODOS", Txtcliente.Text))
        crt.SetParameterValue("PRODUCTO", TxtProducto.Text)

        frm.Contenedor.ReportSource = crt
        frm.ShowDialog()
    End Sub

    Private Sub Frm_GuiasPendTunel_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        f_guiasPendTunel = False
    End Sub

    Private Sub Btn_Salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Salir.Click
        Close()
    End Sub


End Class
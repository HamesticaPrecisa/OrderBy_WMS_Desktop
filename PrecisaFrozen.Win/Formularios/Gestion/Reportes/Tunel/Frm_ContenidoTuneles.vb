Imports System.Threading
Imports System.Data.SqlClient
Public Class Frm_ContenidoTuneles

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


    Private Sub Frm_ContenidoTuneles_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Frm_Principal.buscavalor = ""
        cboTunel.DataSource = fnc.ListarTablasSQL("SELECT cam_descr, cam_codi FROM camaras WHERE cam_tipo=2 ORDER BY cam_codi")
        cboTunel.ValueMember = "cam_codi"
        cboTunel.DisplayMember = "cam_descr"
        cboTunel.Text = "TODOS"
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

        Dim sql As String = "SELECT ca.cam_descr, ct.racd_codi, ct.drec_codpro, ct.mae_descr, ct.fam_descr, " +
                            "       ct.drec_unidades, ct.drec_peso, " +
                            "       ct.racd_ca, ct.racd_ba, ct.racd_co, ct.racd_pi, ct.racd_ni, " +
                            "       ct.frec_codi, ct.mer_nombre, ct.cli_nomb, ct.ott_numero " +
                            "  FROM vwContenidoTuneles ct " +
                            " INNER JOIN camaras ca ON ca.cam_unica = ct.cam_unica AND ca.cam_tipo = 2"


        If LblCliente.Text.Trim().Length > 0 Then
            WhereR = "frec_rutcli = @frec_rutcli"
        End If
        If T2producto.Checked = False And LblProducto.Text.Trim().Length > 0 Then
            WhereR = WhereR + IIf(WhereR.Length > 0, " AND ", "") + "ct.drec_codpro = @drec_codpro"
        End If
        If cboTunel.Text <> "TODOS" Then
            WhereR = WhereR + IIf(WhereR.Length > 0, "AND ", "") + "ct.cam_codi = @cam_codi"
        End If
        If WhereR.Length > 0 Then sql = sql + " WHERE " + WhereR
        sql = sql + " ORDER BY ct.cam_codi, ct.racd_ca, ct.racd_ba, ct.racd_co, ct.racd_pi, ct.racd_ni"

        Dim cam_codi As String = IIf(cboTunel.Text <> "TODOS", cboTunel.SelectedValue, "")
        Dim tabla As DataTable = fnc.ListarTablasSQL(sql, New SqlParameter() {
                                                        New SqlParameter("@frec_rutcli", LblCliente.Text.Trim()),
                                                        New SqlParameter("@drec_codpro", LblProducto.Text.Trim()),
                                                        New SqlParameter("@cam_codi", cam_codi)
                                                     })

        'DgvResultado.DataSource = tabla
        ProgressBar1.Value = 0
        ProgressBar1.Maximum = tabla.Rows.Count
        For Each row As DataRow In tabla.Rows
            Dim posicion As String = row("racd_ca").ToString() +
                                     row("racd_ba").ToString() +
                                     row("racd_co").ToString() +
                                     row("racd_pi").ToString() +
                                     row("racd_ni").ToString()
            DgvResultado.Rows.Add(row("cam_descr"), posicion, row("frec_codi"), row("cli_nomb"), row("mer_nombre"),
                                  row("mae_descr"), row("drec_peso"), row("drec_unidades"),
                                  row("fam_descr"), row("ott_numero"))
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
        cboTunel.Text = "TODOS"
        btn_Imprimir.Enabled = False
        Me.GroupBox1.Enabled = True
        For i As Integer = 0 To DgvResultado.RowCount - 1
            DgvResultado.Rows.RemoveAt(0)
        Next
        Btn_Calcular.Enabled = True
    End Sub

    Private Sub btn_Imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Imprimir.Click
        If DgvResultado.Rows.Count = 0 Then
            MsgBox("No existe información para mostrar", MsgBoxStyle.Critical, "Aviso")
            Exit Sub
        End If


        Dim tabla As DataTable = DgvResultado.DataSource
        documentoimp = DateTime.Now.ToString("MM-dd-yy") + "CONTENIDOTUNELES"
        Dim frm As Frm_MuestraReporte = New Frm_MuestraReporte

        Dim Ds As New Ds_ContenidoTuneles

        For Each row As DataGridViewRow In DgvResultado.Rows
            Ds.Dt_ContenidoTuneles.AddDt_ContenidoTunelesRow(
                row.Cells(0).Value.ToString(),
                row.Cells(1).Value.ToString(),
                row.Cells(5).Value.ToString(),
                row.Cells(6).Value.ToString(),
                row.Cells(7).Value.ToString(),
                row.Cells(2).Value.ToString(),
                row.Cells(4).Value.ToString(),
                row.Cells(3).Value.ToString(),
                row.Cells(8).Value.ToString(),
                row.Cells(9).Value.ToString()
            )
        Next
        Dim crt As New Rpt_ContenidoTuneles()
        crt.SetDataSource(Ds)
        crt.SetParameterValue("CLIENTE", IIf(Txtcliente.Text.Trim().Length = 0, "TODOS", Txtcliente.Text))
        crt.SetParameterValue("PRODUCTO", TxtProducto.Text)
        crt.SetParameterValue("TUNEL", cboTunel.Text)

        frm.Contenedor.ReportSource = crt
        frm.ShowDialog()
    End Sub

    Private Sub Frm_ContenidoTuneles_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        f_contenidoTuneles = False
    End Sub

    Private Sub Btn_Salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Salir.Click
        Close()
    End Sub


    Private Sub DgvResultado_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvResultado.CellContentClick

    End Sub

    Private Sub cboTunel_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboTunel.KeyPress
        e.Handled = True
    End Sub
End Class
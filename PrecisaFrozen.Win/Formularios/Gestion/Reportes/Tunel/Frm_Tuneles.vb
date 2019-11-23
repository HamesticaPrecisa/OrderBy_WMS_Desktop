Imports System.Threading
Imports System.Data.SqlClient
Public Class Frm_Tuneles

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


    Private Sub Frm_Tuneles_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Frm_Principal.buscavalor = ""
        cboEstatus.SelectedIndex = 0
        Btn_Calcular.Enabled = True
        lblLastUpd.Text = ""
        Procesa()
    End Sub


    Private Sub Btn_Calcular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Calcular.Click
        CheckForIllegalCrossThreadCalls = False
        thread = New Thread(AddressOf Procesa)
        'Iniciamos el subproceso.
        thread.Start()
        Me.Btn_Calcular.Enabled = False
        Me.GroupBox1.Enabled = False
        Timer1.Enabled = True
    End Sub

    Sub Procesa()
        Dim WhereR As String = ""
        Dim WhereD As String = ""


        Dim sql As String = "SELECT cam_descr,descr_estado,ott_numero,frec_codi,frec_fecrec," +
                            "       numpallets,kilos,cajas,het,hft,heft," +
                            "       ott_iniciotunel,ott_finaltunel,cli_nomb,hfta" +
                            "  FROM vwEstadoTuneles "
        If LblCliente.Text.Trim().Length > 0 Then
            WhereR = "frec_rutcli = @frec_rutcli"
        End If
        If cboEstatus.SelectedIndex > 0 Then
            WhereR = WhereR + IIf(WhereR.Length > 0, " AND ", "") + " ott_status = @ott_status"
        End If

        If WhereR.Length > 0 Then sql = sql + " WHERE " + WhereR
        sql = sql + " ORDER BY cam_codi, frec_codi"

        Dim tabla As DataTable = fnc.ListarTablasSQL(sql, New SqlParameter() {
                                                        New SqlParameter("@frec_rutcli", LblCliente.Text.Trim()),
                                                        New SqlParameter("@ott_status", cboEstatus.Text.Replace(" ", ""))
                                                     })

        'DgvResultado.DataSource = tabla
        ProgressBar1.Value = 0
        ProgressBar1.Maximum = tabla.Rows.Count
        For Each row As DataRow In tabla.Rows
            DgvResultado.Rows.Add(
                row(0),
                row(1),
                row(2),
                row(3),
                fnc.ctod(row(4).ToString()),
                row(5),
                row(6),
                row(7),
                row(8),
                row(9),
                row(10),
                row(14),
                row(11),
                row(12),
                row(13)
            )
            ProgressBar1.Increment(1)
        Next

        Threading.Thread.Sleep(1000)
        ProgressBar1.Value = 0
        btn_nuevo.Enabled = True
        btn_Imprimir.Enabled = True
        lblLastUpd.Text = "Actualizado al " + DateTime.Now.ToString()
    End Sub


    Private Sub btn_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        LimpiarForma()
    End Sub

    Private Sub LimpiarForma()
        btn_nuevo.Enabled = False
        Txtcliente.Text = ""
        btn_Imprimir.Enabled = False
        Me.GroupBox1.Enabled = True
        For i As Integer = 0 To DgvResultado.RowCount - 1
            DgvResultado.Rows.RemoveAt(0)
        Next
        Btn_Calcular.Enabled = True
        Timer1.Enabled = False
    End Sub

    Private Sub btn_Imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Imprimir.Click
        If DgvResultado.Rows.Count = 0 Then
            MsgBox("No existe información para mostrar", MsgBoxStyle.Critical, "Aviso")
            Exit Sub
        End If

        Dim sql As String = "SELECT MAX(cam_descr) AS cam_descr,MAX(descr_estado) AS descr_estado," +
                            "       SUM(kilos) AS kilos, SUM(cajas) AS cajas, " +
                            "       MAX(het) AS het, MAX(ott_iniciotunel) AS ott_iniciotunel, " +
                            "       MAX(ott_finaltunel) AS ott_finaltunel, MAX(heft) AS heft, " +
                            "       MAX(frec_fecrec) AS frec_fecrec, MAX(hft) AS hft, MAX(hfta) AS hfta" +
                            "  FROM vwEstadoTuneles " +
                            " GROUP BY cam_codi " +
                            " ORDER BY cam_descr"

        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)
        documentoimp = DateTime.Now.ToString("MM-dd-yy") + "ESTADOTUNELES"
        Dim frm As Frm_MuestraReporte = New Frm_MuestraReporte
        Dim Ds As New Ds_EstadoTuneles
        For Each row As DataRow In tabla.Rows
            Ds.Dt_EstadoTuneles.AddDt_EstadoTunelesRow(
                row(0),
                row(1),
                row(2),
                row(3),
                row(4),
                IIf(row(5) IsNot System.DBNull.Value, row(5), ""),
                IIf(row(6) IsNot System.DBNull.Value, row(6), ""),
                row(7),
                row(8),
                row(9),
                row(10)
            )
        Next
        Dim crt As New Rpt_EstadoTuneles()
        crt.SetDataSource(Ds)
        crt.SetParameterValue("CLIENTE", IIf(Txtcliente.Text.Trim().Length = 0, "TODOS", Txtcliente.Text))
        crt.SetParameterValue("STATUS", cboEstatus.Text)

        frm.Contenedor.ReportSource = crt
        frm.ShowDialog()
    End Sub

    Private Sub Frm_Tuneles_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        f_estadoTuneles = False
        Timer1.Enabled = False
    End Sub

    Private Sub Btn_Salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Salir.Click
        Close()
    End Sub


    Private Sub cboEstatus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboEstatus.SelectedIndexChanged
        Btn_Calcular.Enabled = True
    End Sub

    Private Sub Label12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label12.Click

    End Sub

    Private Sub Label13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label13.Click

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        LimpiarForma()
        Procesa()
        Timer1.Enabled = True
    End Sub
End Class
Imports CrystalDecisions.Shared
Imports System.Threading
Imports AdvancedDataGridView

Public Class Rpt_StockHistorico


    Dim fnc As New Funciones
    Dim thread As Thread
    Dim fecha1 As String = ""

    Dim tablaGrupo As DataTable = New DataTable

    Private Sub t2fecharece_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles t2fecharece.CheckedChanged
        If t2fecharece.Checked = True Then
            TxtFecha.Text = "HOY"
            Btn_FecRec.Enabled = False
            ' CheckBox1.Visible = True
            Label7.Visible = True
            TextBox1.Visible = True
        Else
            CheckBox1.Checked = False
            CheckBox1.Visible = False

            TxtFecha.Text = ""
            Btn_FecRec.Enabled = True
            Label7.Visible = False
            TextBox1.Visible = False
        End If
    End Sub

    Private Sub Btn_FecRec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_FecRec.Click
        Frm_Calendario.ShowDialog(Frm_Principal)
        If IsDate(Frm_Principal.buscavalor) Then
            TxtFecha.Text = Frm_Principal.buscavalor.ToString()
            Frm_Principal.buscavalor = ""
        Else
            TxtFecha.Text = ""
            t2fecharece.Checked = True
        End If
    End Sub

    Private Sub Rpt_StockHistorico_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        f_acumulado = False
    End Sub

    Private Sub Rpt_StockHistorico_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = ChrW(13) Then
            Btn_Calcula_Click(sender, e)
        End If
    End Sub

    Private Sub Btn_Calcula_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Calcula.Click
        CheckForIllegalCrossThreadCalls = False
        Thread = New Thread(AddressOf Proceso)
        'Iniciamos el subproceso.
        Thread.Start()
        Me.Btn_Calcula.Enabled = False
        Btn_Calcula.Enabled = False

    End Sub

    Private Sub sumaautosopo()
        Dim sql2 As String = "select * from vg_count_autosoportantes"

        Dim tabla As DataTable = fnc.ListarTablasSQL(sql2)

        '    Me.DgvResultado.DataSource = fnc.ListarTablasSQL("Select Folio ,Cliente ,Cli_nomb as Nombre,Anden, Tip_mov as Mo   vimiento1,fec_reg as Apertura,usr_reg as UsuarioAper, Mov_cie as Movimiento2, fec_cie as Cierre, usr_reg2 as UsuarioCierr,DIFF AS Diferencia from Vg_Andenes_fin_fin2")


        TextBox1.Text = tabla.Rows(0)(0).ToString()

    End Sub

    Private Sub btn_Imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Imprimir.Click

        If dgvResultado.Rows.Count = 0 Then
            MsgBox("No existe información para mostrar", MsgBoxStyle.Critical, "Aviso")
            Exit Sub
        End If

        If CbContratos.Checked = False Then

            Dim tabla As DataTable = dgvResultado.DataSource
            documentoimp = DateTime.Now.ToString("MM-dd-yy") + "STOCKACUMULADO"
            Dim frm As Frm_MuestraReporte = New Frm_MuestraReporte
            Dim report As New Rpt_StockAcumulado

            'PARAMETRO
            Dim param As New ParameterField()
            param.ParameterFieldName = "Fecha"

            Dim discreteValue As New ParameterDiscreteValue()
            discreteValue.Value = fecha1.ToString()
            param.CurrentValues.Add(discreteValue)

            Dim paramFiels As New ParameterFields()
            paramFiels.Add(param)

            frm.Contenedor.ParameterFieldInfo = paramFiels

            Dim Ds As New Ds_StockAcumulado

            For Each row As DataGridViewRow In dgvResultado.Rows
                Ds.Acumulado.AddAcumuladoRow(row.Cells("Nombre_Cliente").Value.ToString(),
                                             row.Cells("Soportantes").Value.ToString(),
                                             row.Cells("Envases").Value.ToString(),
                                             row.Cells("Kilos").Value.ToString())
            Next
            Dim crt As New Rpt_StockAcumulado
            crt.SetDataSource(Ds)

            frm.Contenedor.ReportSource = crt
            frm.ShowDialog()
        Else
            Dim tabla As DataTable = tablaGrupo

            Dim frm As New Frm_MuestraReporte
            Dim report As New Rpt_AcumuladoContrato

            'PARAMETRO

            Dim Ds As New Ds_StockAcumuladoContrato

            For i As Integer = 0 To Ds.Tables("acumulado").Rows.Count - 1
                Ds.Tables("acumulado").Rows(0).Delete()
            Next

            For i As Integer = 0 To tablaGrupo.Rows.Count - 1

                'System.Console.WriteLine(tablaGrupo.Rows(i).Cells(0).ToString() + "         " + j.Cells(1).Value.ToString() + "         " + j.Cells(2).Value.ToString() + "         " + j.Cells(3).Value.ToString())
                Ds.acumulado.AddacumuladoRow(tablaGrupo.Rows(i)(0).ToString(),
                                            tablaGrupo.Rows(i)(1).ToString(),
                                            tablaGrupo.Rows(i)(3).ToString(),
                                            tablaGrupo.Rows(i)(4).ToString(),
                                            tablaGrupo.Rows(i)(2).ToString())

                'Console.WriteLine(tablaGrupo.Rows(0)(0).ToString() + "   " + tablaGrupo.Rows(0)(1).ToString() + " " + tablaGrupo.Rows(0)(2).ToString())

            Next
          
            Dim crt As New Rpt_AcumuladoContrato
            crt.SetDataSource(Ds)
            crt.SetParameterValue("Fecha", fecha1.ToString())
            frm.Contenedor.ReportSource = crt
            frm.ShowDialog()

        End If
    End Sub

    Private Sub Btn_Salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Salir.Click

        Me.Close()

    End Sub

    Private Sub Btn_Excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        GridAExcel(Me.dgvResultado)
    End Sub

    Sub total()
        Dim suma_sopo As Integer = 0
        Dim suma_cajas As Integer = 0
        Dim suma_kilos As Double = 0
        Dim suma_pos As Double = 0
        Dim suma_tran As Double = 0

        For Each row As DataGridViewRow In dgvResultado.Rows
            suma_sopo = suma_sopo + Val(row.Cells("Soportantes").Value.ToString())
            suma_cajas = suma_cajas + Val(row.Cells("Envases").Value.ToString())
            suma_kilos = suma_kilos + row.Cells("Kilos").Value.ToString()
            suma_pos = suma_pos + row.Cells("DataGridViewTextBoxColumn6").Value.ToString()
            suma_tran = suma_tran + row.Cells("PosTran").Value.ToString()
        Next
        txtsopo.Text = FormatNumber(suma_sopo.ToString(), 0)
        txtcajas.Text = FormatNumber(suma_cajas.ToString(), 0)
        txtkilos.Text = FormatNumber(suma_kilos.ToString(), 2)
        txtpos.Text = FormatNumber(suma_pos.ToString(), 0)
        txttran.Text = FormatNumber(suma_tran.ToString(), 0)
        Dim suma As Double = suma_pos + suma_tran
        txttotpos.Text = FormatNumber(suma.ToString(), 0)

    End Sub

    Sub Proceso()

        For i As Integer = 0 To dgvResultado.Rows.Count - 1
            dgvResultado.Rows.RemoveAt(0)
        Next

        If TxtFecha.Text = "HOY" Then
            fecha1 = devuelve_fecha(fnc.DevuelveFechaServidor())
        Else
            fecha1 = devuelve_fecha(TxtFecha.Text)
        End If

        Dim SqlClientes As String = "SELECT cli_rut, cli_nomb, POS,TRANS FROM VG_CLI ORDER BY cli_nomb ASC"
        Dim tablaClientes As DataTable = fnc.ListarTablasSQL(SqlClientes)

        ProgressBar1.Maximum = tablaClientes.Rows.Count


        'Declara Variable
        Dim Node As New TreeGridNode
        Dim NodeAdd As New TreeGridNode

        For i As Integer = 0 To tablaClientes.Rows.Count - 1

            Dim sql1 As String = "SELECT  isnull(SUM(ddes_pallet),0), isnull(SUM(ddes_unidades),0) , isnull(SUM(ddes_peso),0) FROM detadespa WHERE " +
                "ddes_fecha<='" + fecha1.ToString() + "' AND ddes_rutcli='" + tablaClientes.Rows(i)(0).ToString() + "' AND ddes_codvig='0' and cod_bod='" + sucursalglo + "'"

            Dim tabla1 As DataTable = fnc.ListarTablasSQL(sql1)

            Dim sql2 As String = "SELECT isnull(SUM(drec_pallet),0), isnull(SUM(drec_unidades),0), isnull(SUM(drec_peso),0) FROM detarece WHERE  " +
                "drec_fecrec<='" + fecha1.ToString() + "' AND drec_rutcli='" + tablaClientes.Rows(i)(0).ToString() + "' AND drec_codvig='0' and cod_bod='" + sucursalglo + "' "


            Dim tabla2 As DataTable = fnc.ListarTablasSQL(sql2)

            Dim SumaDespachoSopo As Integer = tabla1.Rows(0)(0).ToString()
            Dim SumaDespachoCajas As Integer = tabla1.Rows(0)(1).ToString()
            Dim SumaDespachoKilos As Double = tabla1.Rows(0)(2).ToString()

            Dim SumaRecepcionSopo As Integer = tabla2.Rows(0)(0).ToString()
            Dim SumaRecepcionCajas As Integer = tabla2.Rows(0)(1).ToString()
            Dim SumaRecepcionKilos As Double = tabla2.Rows(0)(2).ToString()

            '--------------------------------------------------------->

            'Dim sumadespachados As Integer = 0
            Dim ResultadoSopo As Integer = (SumaRecepcionSopo - SumaDespachoSopo)
            Dim ResultadoCajas As Integer = (SumaRecepcionCajas - SumaDespachoCajas)
            Dim ResultadoKilos As Double = (SumaRecepcionKilos - SumaDespachoKilos)

            ProgressBar1.PerformStep()



            Dim POS As Double = 0
            If ResultadoSopo > 0 Then

                Dim valor As String = (tablaClientes.Rows(i)(3).ToString())
                If tablaClientes.Rows(i)(2).ToString() = "" Then
                    POS = 0

                Else
                    POS = tablaClientes.Rows(i)(2).ToString()
                End If



                If (valor = "") Then

                    Dim cero As Double = 0
                    dgvResultado.Rows.Add(tablaClientes.Rows(i)(1).ToString(), ResultadoSopo, ResultadoCajas, ResultadoKilos, POS, cero)
                Else
                    Dim TRAN As Double = tablaClientes.Rows(i)(3).ToString()
                    dgvResultado.Rows.Add(tablaClientes.Rows(i)(1).ToString(), ResultadoSopo, ResultadoCajas, ResultadoKilos, POS, TRAN)
                End If


                'Llena valores
                Node = TreeGridView1.Nodes.Add(tablaClientes.Rows(i)(1).ToString(), ResultadoSopo, ResultadoCajas, ResultadoKilos, (tablaClientes.Rows(i)(2).ToString()))
                Dim boldFont = New Font(TreeGridView1.DefaultCellStyle.Font, FontStyle.Bold)
                Node.DefaultCellStyle.Font = boldFont
                Node.Height = 23
                Node.DefaultCellStyle.BackColor = Color.LightGray
                'TreeGridView1.Nodes.Add("contrato1", "0", "0", "0")



                Dim sql_contrato As String = "SELECT cont_codi, cont_descr FROM CONTRATO WHERE cont_rutclie='" + tablaClientes.Rows(i)(0).ToString() + "'"
                Dim tabla_contrato As DataTable = fnc.ListarTablasSQL(sql_contrato)

                For j As Integer = 0 To tabla_contrato.Rows.Count - 1

                    sql1 = "SELECT  isnull(SUM(ddes_pallet),0), isnull(SUM(ddes_unidades),0), ROUND(isnull(SUM(ddes_peso),0),3) FROM detadespa WHERE " +
                           "ddes_fecha<='" + fecha1.ToString() + "' AND ddes_rutcli='" + tablaClientes.Rows(i)(0).ToString() + "' " +
                           " AND ddes_contcli='" + tabla_contrato.Rows(j)(0).ToString() + "'"
                    tabla1 = fnc.ListarTablasSQL(sql1)


                    sql2 = "SELECT isnull(SUM(drec_pallet),0), isnull(SUM(drec_unidades),0), ROUND(isnull(SUM(drec_peso),0),3) FROM detarece WHERE  " +
                           "drec_fecrec<='" + fecha1.ToString() + "' AND drec_rutcli='" + tablaClientes.Rows(i)(0).ToString() + "' " +
                           "AND drec_codvig='0' AND drec_contcli='" + tabla_contrato.Rows(j)(0).ToString() + "'"
                    tabla2 = fnc.ListarTablasSQL(sql2)

                    Dim SumaDespachoContSopo As Integer = tabla1.Rows(0)(0).ToString()
                    Dim SumaDespachoContCajas As Integer = tabla1.Rows(0)(1).ToString()
                    Dim SumaDespachoContKilos As Double = tabla1.Rows(0)(2).ToString()

                    Dim SumaRecepcionContSopo As Integer = tabla2.Rows(0)(0).ToString()
                    Dim SumaRecepcionContCajas As Integer = tabla2.Rows(0)(1).ToString()
                    Dim SumaRecepcionContKilos As Double = tabla2.Rows(0)(2).ToString()

                    Dim ResultadoContSopo As Integer = (SumaRecepcionContSopo - SumaDespachoContSopo)
                    Dim ResultadoContCajas As Integer = (SumaRecepcionContCajas - SumaDespachoContCajas)
                    Dim ResultadoContKilos As Double = (SumaRecepcionContKilos - SumaDespachoContKilos)

                    If ResultadoContSopo > 0 Then
                        'Node.Height = 16
                        Node.Nodes.Add(tabla_contrato.Rows(j)(0).ToString() + "  " + tabla_contrato.Rows(j)(1).ToString(), ResultadoContSopo, ResultadoContCajas, ResultadoContKilos, (tablaClientes.Rows(i)(2).ToString()))
                        tablaGrupo.Rows.Add(tablaClientes.Rows(i)(1).ToString(), tabla_contrato.Rows(j)(0).ToString() + "  " + tabla_contrato.Rows(j)(1).ToString(), ResultadoContSopo, ResultadoContCajas, ResultadoContKilos, (tablaClientes.Rows(i)(2).ToString()))
                    End If
                Next

            End If
            'Node.Nodes.Add("contrato1", "10", "100", "1000")
            'Node.Nodes.Add("contrato2", "10", "100", "1000")


            Threading.Thread.Sleep(100)
        Next

        'tablaGrupo = TreeGridView1.DataSource

        ProgressBar1.Value = ProgressBar1.Maximum
        total()
        sumaautosopo()
        Threading.Thread.Sleep(1000)
        ProgressBar1.Value = 0
        btn_nuevo.Enabled = True
        btn_Imprimir.Enabled = True
    End Sub



    Private Sub btn_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        Me.Btn_Calcula.Enabled = True
        'btn_nuevo.Enabled = False
        btn_Imprimir.Enabled = True
        For i As Integer = 0 To dgvResultado.RowCount - 1
            dgvResultado.Rows.RemoveAt(0)
        Next

        For i As Integer = 0 To tablaGrupo.Rows.Count - 1
            tablaGrupo.Rows.RemoveAt(0)
        Next
        
        'For i As Integer = 0 To Me.TreeGridView1.Rows.Count - 1
        Me.TreeGridView1.Rows.Clear()
        'Next


    End Sub

    'Protected Sub UnSiteNode2(ByVal node As TreeGridNode)
    '    If node.IsSited Or node.IsRoot Then
    '        ' remove child rows first
    '        For Each childNode As TreeGridNode In node.Nodes
    '            Me.UnSiteNode2(childNode)
    '        Next

    '        ' now remove this row except for the root
    '        If Not node.IsRoot Then

    '            MyBase.Rows.Remove(node)
    '            ' Row isn't sited in the grid anymore after remove. Note that we cannot
    '            ' Use the RowRemoved event since we cannot map from the row index to
    '            ' the index of the expandable row/node.
    '            node.UnSited()

    '        End If

    '    End If

    'End Sub


    Private Sub CbContratos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CbContratos.CheckedChanged
        If CbContratos.Checked = True Then
            TreeGridView1.Visible = True
        Else
            TreeGridView1.Visible = False
        End If
    End Sub
 
    Private Sub TreeGridView1_NodeExpanding(ByVal sender As System.Object, ByVal e As AdvancedDataGridView.ExpandingEventArgs) Handles TreeGridView1.NodeExpanding
        'e.Cancel = True
    End Sub

    Private Sub TreeGridView1_NodeCollapsing(ByVal sender As Object, ByVal e As AdvancedDataGridView.CollapsingEventArgs) Handles TreeGridView1.NodeCollapsing
        e.Cancel = True
    End Sub

    Private Sub Rpt_StockHistorico_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tablaGrupo.Columns.Add("Col1")
        tablaGrupo.Columns.Add("Col2")
        tablaGrupo.Columns.Add("Col3")
        tablaGrupo.Columns.Add("Col4")
        tablaGrupo.Columns.Add("Col5")
        tablaGrupo.Columns.Add("Col6")

        dgvResultado.Columns(4).Width = 0
        dgvResultado.Columns(5).Width = 0
        Label4.Visible = False
        Label5.Visible = False
        Label6.Visible = False
        txttotpos.Visible = False
        txtpos.Visible = False
        txttran.Visible = False
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox1.CheckedChanged

        If CheckBox1.Checked = True Then

            dgvResultado.Columns(4).Width = 100
            dgvResultado.Columns(5).Width = 100
            Label4.Visible = True
            Label5.Visible = True
            Label6.Visible = True
            txttotpos.Visible = True
            txtpos.Visible = True
            txttran.Visible = True
        Else
            dgvResultado.Columns(4).Width = 0
            dgvResultado.Columns(5).Width = 0
            Label4.Visible = False
            Label5.Visible = False
            Label6.Visible = False
            txttotpos.Visible = False
            txtpos.Visible = False
            txttran.Visible = False

        End If
    End Sub

    Private Sub TextBox1_DoubleClick(sender As System.Object, e As System.EventArgs) Handles TextBox1.DoubleClick
        If TextBox1.Text = "" Then
        Else
            Dim frm As Frm_detalleautosoportantes = New Frm_detalleautosoportantes

            frm.ShowDialog()
        End If

       
    End Sub

    Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub txtpos_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtpos.TextChanged

    End Sub
End Class
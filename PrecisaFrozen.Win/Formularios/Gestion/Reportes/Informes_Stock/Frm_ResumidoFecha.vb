Imports System.Threading
Public Class Frm_ResumidoFecha

    Dim fnc As New Funciones
    Dim thread As Thread
#Region "Cliente"


    Private Sub Btn_cliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_cliente.Click
        Lst_AyudaClientes.ShowDialog(Frm_Principal)
        If Frm_Principal.buscavalor.ToString <> "" Then
            Txtcliente.Text = RetornaCliente(Frm_Principal.buscavalor.ToString())
            LblCliente.Text = Frm_Principal.buscavalor.ToString()
            Frm_Principal.buscavalor = ""
            Btn_Calcular.Enabled = True
        End If
    End Sub

#End Region

#Region "Contrato"

    Private Sub t2contrato_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles t2contrato.CheckedChanged
        If t2contrato.Checked = True Then
            TxtContrato.Text = "TODOS"
            Btn_Contrato.Enabled = False
        Else
            TxtContrato.Text = ""
            Btn_Contrato.Enabled = True
        End If
    End Sub

    Private Sub Btn_Contrato_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Contrato.Click
        Dim frm As New Lst_AyudaContratos
        If Txtcliente.Text <> "" Then
            frm.condicion = "WHERE cont_rutclie='" + QuitarCaracteres(LblCliente.Text) + "'"
        End If
        frm.ShowDialog(Frm_Principal)
        If Frm_Principal.buscavalor = "" Then
            t2contrato.Checked = True
            Exit Sub
        End If
        TxtContrato.Text = RetornaContrato(Frm_Principal.buscavalor.ToString())
        LblContrato.Text = Frm_Principal.buscavalor.ToString()
        Frm_Principal.buscavalor = ""
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
        If fnc.verificaExistencia("clientes", "Cli_rut", LblCliente.Text) = True Then
            frm.Condicion = "mae_clirut='" + QuitarCaracteres(LblCliente.Text) + "' "
        End If

        frm.ShowDialog(Frm_Principal)
        If Frm_Principal.buscavalor = "" Then
            T2producto.Checked = True
            Exit Sub
        End If

        LblProducto.Text = Frm_Principal.buscavalor.ToString()
        TxtProducto.Text = RetornaProducto(Frm_Principal.buscavalor.ToString())

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
        Dim WhereR As String = ""
        Dim WhereD As String = ""


        If t2contrato.Checked = False Then
            If TxtContrato.Text = "" Then
                t2contrato.Checked = True
            Else
                WhereR = WhereR + " AND drec_contcli='" + LblContrato.Text + "' "
                WhereD = WhereD + " AND ddes_contcli='" + LblContrato.Text + "' "
            End If

        End If

        If T2producto.Checked = False Then
            If TxtProducto.Text = "" Then
                T2producto.Checked = True
            Else
                WhereR = WhereR + "AND drec_codpro='" + LblProducto.Text + "' AND detarece.cod_bod='" + sucursalglo.Trim() + "' "
                WhereD = WhereD + "AND ddes_codpro='" + LblProducto.Text + "' AND detadespa.cod_bod='" + sucursalglo.Trim() + "' "
            End If

        End If

        Dim s As String = "SELECT drec_codpro, mae_descr, tenv_descr  FROM detarece, maeprod, tipoenv " +
                                                     "WHERE drec_codpro=mae_codi AND mae_tipenv=tenv_codi AND drec_rutcli='" + LblCliente.Text + "' " +
                                                     "" + WhereR + " and detarece.cod_bod ='" + sucursalglo + "'  GROUP BY drec_codpro, mae_descr, tenv_descr"

        Dim tabla As DataTable = fnc.ListarTablasSQL(s)

        ProgressBar1.Maximum = tabla.Rows.Count

        For i As Integer = 0 To tabla.Rows.Count - 1

            Dim SQl_RECEPCIONADO As String = "SELECT isnull(SUM(drec_pallet),0), isnull(SUM(drec_unidades),0), isnull(SUM(drec_peso),0) FROM detarece WHERE " +
                           "drec_codpro='" + tabla.Rows(i)(0).ToString() + "' AND drec_rutcli='" + LblCliente.Text + "' AND drec_fecrec<='" + devuelve_fecha(DtFecha.Value) + "' AND drec_codvig='0' " + WhereR

            Dim SQL_DESPACHADO As String = "SELECT isnull(SUM(ddes_pallet),0), isnull(SUM(ddes_unidades),0), isnull(SUM(ddes_peso),0) FROM detadespa WHERE " +
                "ddes_codpro='" + tabla.Rows(i)(0).ToString() + "' AND ddes_rutcli='" + LblCliente.Text + "' AND " +
                "ddes_fecha<='" + devuelve_fecha(DtFecha.Value) + "' " + WhereD


            Dim Tabla_Recepcionado As DataTable = fnc.ListarTablasSQL(SQl_RECEPCIONADO)
            Dim Tabla_Despachado As DataTable = fnc.ListarTablasSQL(SQL_DESPACHADO)

            If Val(Tabla_Recepcionado.Rows(0)(0).ToString()) - Val(Tabla_Despachado.Rows(0)(0).ToString()) <> 0 AndAlso Val(Tabla_Recepcionado.Rows(0)(1).ToString()) - Val(Tabla_Despachado.Rows(0)(1).ToString()) <> 0 _
                AndAlso Val(Tabla_Recepcionado.Rows(0)(2).ToString()) - Val(Tabla_Despachado.Rows(0)(2).ToString()) <> 0 Then

                DgvResultado.Rows.Add(tabla.Rows(i)(0).ToString(), tabla.Rows(i)(1).ToString(), tabla.Rows(i)(2).ToString(),
                                  Val(Tabla_Recepcionado.Rows(0)(0).ToString()) - Val(Tabla_Despachado.Rows(0)(0).ToString()),
                                  Val(Tabla_Recepcionado.Rows(0)(1).ToString()) - Val(Tabla_Despachado.Rows(0)(1).ToString()),
                                  Convert.ToDouble(Tabla_Recepcionado.Rows(0)(2).ToString()) - Convert.ToDouble(Tabla_Despachado.Rows(0)(2).ToString()))

            End If

            ProgressBar1.Increment(1)
        Next


        total()
        Threading.Thread.Sleep(1000)
        ProgressBar1.Value = 0
        btn_nuevo.Enabled = True
        btn_Imprimir.Enabled = True

    End Sub

    Sub total()
        Dim suma_sopo As Integer = 0
        Dim suma_cajas As Integer = 0
        Dim suma_kilos As Double = 0

        For Each row As DataGridViewRow In dgvResultado.Rows
            suma_sopo = suma_sopo + Val(row.Cells("SOP").Value.ToString())
            suma_cajas = suma_cajas + Val(row.Cells("Envases").Value.ToString())
            suma_kilos = suma_kilos + row.Cells("Kilos").Value.ToString()
        Next
        txtsopo.Text = FormatNumber(suma_sopo.ToString(), 0)
        txtcajas.Text = FormatNumber(suma_cajas.ToString(), 0)
        txtkilos.Text = FormatNumber(suma_kilos.ToString(), 2)
    End Sub

    Private Sub btn_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        Me.Btn_Calcular.Enabled = False
        btn_nuevo.Enabled = False
        Txtcliente.Text = ""
        TxtContrato.Text = ""
        TxtProducto.Text = ""
        btn_Imprimir.Enabled = False
        Me.GroupBox1.Enabled = True
        For i As Integer = 0 To DgvResultado.RowCount - 1
            DgvResultado.Rows.RemoveAt(0)
        Next
        txtsopo.Text = "0"
        txtcajas.Text = "0"
        txtkilos.Text = "0.00"
    End Sub

    Private Sub btn_Imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Imprimir.Click
        If DgvResultado.Rows.Count = 0 Then
            MsgBox("No existe información para mostrar", MsgBoxStyle.Critical, "Aviso")
            Exit Sub
        End If

        Dim tabla As DataTable = DgvResultado.DataSource
        documentoimp = DateTime.Now.ToString("MM-dd-yy") + "STOCKRESUMIDO"
        Dim frm As Frm_MuestraReporte = New Frm_MuestraReporte
        Dim report As New Rpt_ResumidoFecha

        Dim Ds As New Ds_Resumido

        For Each row As DataGridViewRow In DgvResultado.Rows
            Ds.Resumido.AddResumidoRow(row.Cells("codigo").Value.ToString(),
                                         row.Cells("prod").Value.ToString(),
                                         row.Cells("Envase").Value.ToString(),
                                         row.Cells("SOP").Value.ToString(),
                                         row.Cells("envases").Value.ToString(),
                                         row.Cells("kilos").Value.ToString())
        Next
        Dim crt As New Rpt_ResumidoFecha
        crt.SetDataSource(Ds)
        crt.SetParameterValue("FECHA", devuelve_fecha_Formato2(DtFecha.Value))
        crt.SetParameterValue("CLIENTE", Txtcliente.Text)
        crt.SetParameterValue("CONTRATO", TxtContrato.Text)
        crt.SetParameterValue("PRODUCTO", TxtProducto.Text)

        frm.Contenedor.ReportSource = crt
        frm.ShowDialog()
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

    Private Sub txtsopo_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtsopo.TextChanged

    End Sub
End Class
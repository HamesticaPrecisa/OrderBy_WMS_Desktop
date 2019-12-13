Public Class Frm_DocumentosEmitidos

    Dim fnc As New Funciones

    Sub listarDatos()
        Dim SQL As String = "SELECT frec_codi, 'RECEPCION' AS TIPO, ori_descr, descri,cli_nomb , frec_totsopo, frec_totunidad, frec_totpeso,CASE frec_RecepTunel WHEN '1' THEN 'NO' WHEN '2' THEN 'SI' END AS frec_RecepTunel  " +
                            "FROM FICHRECE INNER JOIN clientes ON cli_rut=frec_rutcli " +
                            "INNER JOIN origen ON ori_codi=frec_origen " +
                            "INNER JOIN Usuarios ON frec_codienca=usu_codigo " +
                            "WHERE frec_fecrec='" + devuelve_fecha(Dtfecha.Value) + "' " +
                            "AND frec_codvig='0'" +
                            "UNION ALL " +
                            "SELECT fdes_codi, 'DESPACHO' AS TIPO, ori_descr, descri, cli_nomb , fdes_totsopo, fdes_totunidad, fdes_totpeso,'' " +
                            "FROM Fichdespa INNER JOIN clientes ON cli_rut=fdes_rutcli " +
                            "INNER JOIN origen ON ori_codi=fdes_origen  " +
                            "INNER JOIN Usuarios ON fdes_codienca=usu_codigo " +
                            "WHERE fdes_fecha='" + devuelve_fecha(Dtfecha.Value) + "' " +
                            "AND fdes_codvig='0'" +
                            " ORDER BY frec_codi DESC "

        DgvEmitidos.DataSource = fnc.ListarTablasSQL(SQL)

        Dim SUMASOPO As Integer = 0
        Dim SUMAUNID As Integer = 0
        Dim SUMAPESO As Double = 0
        Dim SUMARECE As Integer = 0
        Dim SUMADESPA As Integer = 0

        For i As Integer = 0 To DgvEmitidos.Rows.Count - 1
            SUMASOPO = SUMASOPO + Val(DgvEmitidos.Rows(i).Cells("s").Value)
            SUMAUNID = SUMAUNID + Val(DgvEmitidos.Rows(i).Cells("u").Value)
            SUMAPESO = SUMAPESO + Convert.ToDouble(DgvEmitidos.Rows(i).Cells("k").Value)
            Dim str As String = DgvEmitidos.Rows(i).Cells(2).ToString()
            If DgvEmitidos.Rows(i).Cells("MOVIMIENTO").Value = "DESPACHO" Then
                SUMADESPA = SUMADESPA + Val(DgvEmitidos.Rows(i).Cells("s").Value)
                TextBox2.Text = SUMADESPA.ToString()
            End If
            If DgvEmitidos.Rows(i).Cells("MOVIMIENTO").Value = "RECEPCION" Then

                SUMARECE = SUMARECE + Val(DgvEmitidos.Rows(i).Cells("s").Value)
                TextBox1.Text = SUMARECE.ToString()

            End If
        Next

        ts.Text = FormatNumber(SUMASOPO.ToString(), 0)
        tu.Text = FormatNumber(SUMAUNID.ToString(), 0)
        tk.Text = FormatNumber(SUMAPESO.ToString(), 2)

        'Dtfecha.Enabled = False
        'btn_nuevo.Enabled = True
    End Sub

    Private Sub Btn_Calcular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Calcular.Click
        listarDatos()
    End Sub

    Private Sub btn_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        'Dtfecha.Enabled = True
        'For i As Integer = 0 To DgvEmitidos.RowCount - 1
        '    DgvEmitidos.Rows.RemoveAt(0)
        'Next
        'ts.Text = "0"
        'tu.Text = "0"
        'tk.Text = "0"
        Call GridAExcel(DgvEmitidos)


    End Sub

    Private Sub Btn_Salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Salir.Click
        Me.Close()
    End Sub

    Private Sub Frm_DocumentosEmitidos_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        f_emitidos = False
    End Sub

    Private Sub Frm_DocumentosEmitidos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ts.Text = "0"
        tu.Text = "0"
        tk.Text = "0"

        listarDatos()
        btn_nuevo.Enabled = True
    End Sub

    Private Sub DgvEmitidos_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvEmitidos.CellDoubleClick
        If e.RowIndex > -1 Then
            Dim codigo As String = DgvEmitidos.Rows(e.RowIndex).Cells("CODIGO").Value.ToString()
            If DgvEmitidos.Rows(e.RowIndex).Cells("MOVIMIENTO").Value.ToString() = "RECEPCION" Then
                visualiza_recepcion(codigo)
            Else
                visualiza_despacho(codigo)
            End If
        End If
    End Sub

    Sub visualiza_recepcion(ByVal codigo As String)
        Dim frm As Frm_MuestraReporte = New Frm_MuestraReporte
        frm.Text = "Asistente de informes - Guia Recepcion"

        Dim report As New Rpt_GuiaRecepcion

        report.SetDatabaseLogon(Usuario_ODBC, Pass_ODBC)
        report.SetParameterValue("codigo", codigo)

        frm.Contenedor.ReportSource = report
        frm.ShowDialog()
    End Sub

    Sub visualiza_despacho(ByVal codigo As String)
        Dim frm As Frm_MuestraReporte = New Frm_MuestraReporte
        frm.Text = "Asistente de informes - Guia guiaDespacho"

        Dim report As New Rpt_GuiaDespacho

        report.SetDatabaseLogon(Usuario_ODBC, Pass_ODBC)
        report.SetParameterValue("codigo", codigo)

        frm.Contenedor.ReportSource = report
        frm.ShowDialog()
    End Sub

    Private Sub Dtfecha_TextChanged(sender As Object, e As System.EventArgs) Handles Dtfecha.TextChanged
        listarDatos()
    End Sub
End Class
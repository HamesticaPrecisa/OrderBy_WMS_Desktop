Public Class TrazabilidadCaja

    Dim fnc As New Funciones


    Private Sub TrazabilidadCaja_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim MySource As New AutoCompleteStringCollection()

        'Dim SqlCaja As String = "SELECT Caj_cod FROM DetaReceCajas " 'WHERE Caj_cod LIKE '%" + TxtCodCaja.Text + "%' ORDER BY Caj_cod ASC"

        'Dim tabla As DataTable = fnc.ListarTablasSQL(SqlCaja)

        'Dim s = tabla.Rows.Count

        'For Each row As DataRow In tabla.Rows
        '    MySource.Add(Convert.ToString(row("Caj_cod")))
        'Next

        'With TxtCodCaja
        '    .AutoCompleteCustomSource = MySource
        '    .AutoCompleteMode = AutoCompleteMode.SuggestAppend
        '    .AutoCompleteSource = AutoCompleteSource.CustomSource
        'End With
    End Sub

    Private Sub TxtCodCaja_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCodCaja.TextChanged
        If TxtCodCaja.Text.Length > 5 Then
            Dim sql As String = "SELECT Caj_cod, Caj_Pcod, cli_nomb, drec_camara, drec_banda, drec_colum, drec_piso, drec_nivel, CASE ISNULL((SELECT racd_estado FROM rackdeta WHERE racd_codi=Caj_Pcod) ,'9') WHEN 9 THEN 'DESPACHADO' ELSE CASE isnull(Caj_ped,0) WHEN  0 THEN 'VIGENTE'  WHEN  1 THEN 'PEDIDO'  WHEN  2 THEN 'PRE - DESPACHADO'  WHEN  3 THEN 'DESPACHADO' END END AS ESTADO FROM  DetaReceCajas LEFT JOIN detapedcaja ON dpc_codcaja=caj_cod INNER JOIN detarece ON drec_codi=Caj_Pcod INNER JOIN clientes ON cli_rut=drec_rutcli WHERE Caj_cod LIKE '%" + TxtCodCaja.Text + "%' ORDER BY Caj_cod DESC "

            DgvCaja.DataSource = fnc.ListarTablasSQL(sql)
            Dim x = DgvCaja.Rows.Count
        Else
            Dim sql As String = "SELECT Caj_cod, Caj_Pcod, cli_nomb, drec_camara, drec_banda, drec_colum, drec_piso, drec_nivel, CASE ISNULL((SELECT racd_estado FROM rackdeta WHERE racd_codi=Caj_Pcod) ,'9') WHEN 9 THEN 'DESPACHADO' ELSE CASE isnull(Caj_ped,0) WHEN  0 THEN 'VIGENTE'  WHEN  1 THEN 'PEDIDO'  WHEN  2 THEN 'PRE - DESPACHADO'  WHEN  3 THEN 'DESPACHADO' END END AS ESTADO FROM  DetaReceCajas LEFT JOIN detapedcaja ON dpc_codcaja=caj_cod INNER JOIN detarece ON drec_codi=Caj_Pcod INNER JOIN clientes ON cli_rut=drec_rutcli WHERE Caj_cod LIKE 'x' ORDER BY Caj_cod DESC "

            DgvCaja.DataSource = fnc.ListarTablasSQL(sql)

        End If

    End Sub

    Private Sub DgvCaja_CellContentDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvCaja.CellContentDoubleClick
        If e.RowIndex > -1 Then
            TxtCodCaja.Text = DgvCaja.Rows(e.RowIndex).Cells(1).Value.ToString()
        End If
    End Sub

    Private Sub DgvCaja_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvCaja.CellClick
        If e.RowIndex > -1 AndAlso e.ColumnIndex = 0 Then
 
            Dim frm As Frm_MuestraReporte = New Frm_MuestraReporte
            frm.Text = "Asistente de informes - Informe de trazabilidad por caja"

            Dim report As New Rpt_TrababilidadCaja

            report.SetDatabaseLogon(Usuario_ODBC, Pass_ODBC)
            report.SetParameterValue("codigo", CerosAnteriorString(DgvCaja.Rows(e.RowIndex).Cells(2).Value.ToString(), 9))
            report.SetParameterValue("CC", DgvCaja.Rows(e.RowIndex).Cells(1).Value.ToString())
            report.SetParameterValue("EC", DgvCaja.Rows(e.RowIndex).Cells(9).Value.ToString())
            frm.Contenedor.ReportSource = report
            frm.ShowDialog()

        End If

    End Sub


End Class
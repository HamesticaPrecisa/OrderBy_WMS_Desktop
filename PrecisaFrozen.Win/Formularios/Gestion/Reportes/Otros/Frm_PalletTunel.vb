Public Class Frm_PalletTunel
    Dim fnc As New Funciones

    Private Sub Frm_PalletTunel_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        f_PalletTunel = False
    End Sub

    Private Sub Frm_PalletTunel_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        dtp_fecter.Value = Today
        dtp_fecini.Value = DateAdd(DateInterval.Day, -7, Today)
    End Sub

    Private Sub Btn_Salir_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Salir.Click
        Me.Close()
    End Sub

    Private Sub Btn_Buscar_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Buscar.Click
        Dim strSQL As String

        strSQL = "SELECT DISTINCT clientes.cli_nomb 'Cliente', " +
                 "       detarece.drec_codi 'Pallet', " +
                 "       detarece.drec_fecrec 'Fecha Recep.', " +
                 "       detarece.drec_hora 'Hora Recep.', " +
                 "       detarece.drec_sopocli 'Pallet Cliente', " +
                 "       movpallet.mov_fecha 'Fecha Ingreso Tunel', " +
                 "       movpallet.mov_hora 'Hora Ingreso Tunel', " +
                 "       SUBSTRING(detadespa.ddes_codi,4,4) 'Guia Despacho'," +
                 "       detadespa.ddes_fecha 'Fecha Despacho', " +
                 "       (DATEDIFF(dd,(SELECT MAX(convert(date,detarece2.drec_fecrec)) FROM detarece as detarece2 WHERE detarece2.drec_codi = detarece.drec_codi and movpallet.mov_fecha IS NULL),GETDATE())) 'Dias sin Tunel'" +
                 "  FROM detarece " +
                 " INNER JOIN fichrece ON detarece.frec_codi1 = fichrece.frec_codi " +
                 " INNER JOIN clientes ON detarece.drec_rutcli = clientes.cli_rut " +
                 "  LEFT JOIN movpallet ON detarece.drec_codi = movpallet.mov_folio AND mov_ca IN('62','61','63','64','85','86','87','88') " +
                 "  LEFT JOIN detadespa ON detarece.drec_codi = detadespa.ddes_codrece " +
                 " WHERE fichrece.frec_RecepTunel = 2 " +
                 "   AND CONVERT(DATE,detarece.drec_fecrec) BETWEEN '" + devuelve_fecha(dtp_fecini.Value) + "' AND '" + devuelve_fecha(dtp_fecter.Value) + "'" +
                 " ORDER BY [Fecha Recep.] ASC,[Hora Recep.] ASC"

        dgvMovimientos.DataSource = fnc.ListarTablasSQL(strSQL)

    End Sub

    Private Sub btnExcel_Click(sender As System.Object, e As System.EventArgs) Handles btnExcel.Click
        Call GridAExcel(dgvMovimientos)
    End Sub

    Private Sub btn_Imprimir_Click(sender As System.Object, e As System.EventArgs) Handles btn_Imprimir.Click

        documentoimp = DateTime.Now.ToString("MM-dd-yy") + "PalletSinTunel"
        Dim frm As Frm_MuestraReporte = New Frm_MuestraReporte
        frm.Text = "Asistente de informes - Informe de Soportantes Para Ingreso Túnel"

        Dim report As New Rpt_PalletTunel

        report.SetDatabaseLogon(Usuario_ODBC, Pass_ODBC)

        report.SetParameterValue("fecini", devuelve_fecha(dtp_fecini.Value))
        report.SetParameterValue("fecter", devuelve_fecha(dtp_fecter.Value))

        frm.Contenedor.ReportSource = report
        frm.ShowDialog()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)

    End Sub
End Class
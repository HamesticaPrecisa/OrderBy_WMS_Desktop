Public Class Frm_ListadoTuneles

    Dim fnc As New Funciones

    Private Sub Btn_Buscar_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Buscar.Click
        Dim strSQL As String
        If txtnumguia.Text = "" Then
            'strSQL = "SELECT frec_guia, " +
            '    "       SUBSTRING(frec_codi,11,9) frec_codi, " +
            '    "       fechora_ingreso, " +
            '    "       temp_ingreso, " +
            '    "       fechora_salida, " +
            '    "       temp_salida, " +
            '    "       DATEDIFF (hh,fechora_ingreso,fechora_salida ) horas_tunel " +
            '    "  FROM tuneles " +
            '    " WHERE CONVERT(DATE,fechora_ingreso) BETWEEN '" + devuelve_fecha(dtp_fecini.Value) + "' AND '" + devuelve_fecha(dtp_fecter.Value) + "' " +
            '    " ORDER BY fechora_ingreso, frec_codi "

            strSQL = "SELECT GUIA=a.frec_guia,'GUIA CLIENTE'=b.frec_guiades,CLIENTE=c.cli_nomb,CODIGO=drec_codpro,PRODUCTO=e.mae_descr,PALLET=SUBSTRING(a.frec_codi,11,9),'PALLET CLIENTE'=d.drec_sopocli,UNIDADES=d.drec_unidades,PESO=d.drec_peso,'FECHA RECEPCION'=convert(date,b.frec_fecrec),'FECHA PRODUCCION'=convert(date,d.drec_fecprod),'FECHA VENCIMIENTO'=convert(date,d.FechaVencimiento),'FECHA INGRESO'=convert(date,a.fechora_ingreso),'HORA INGRESO'=left(convert(varchar,a.fechora_ingreso,108),5),'T INGRESO'=a.temp_ingreso,'FECHA SALIDA'=convert(date,a.fechora_salida),'HORA SALIDA'=left(convert(varchar,a.fechora_salida,108),5),'T SALIDA'=a.temp_salida,'HORAS TUNEL'=DATEDIFF(hh,a.fechora_ingreso,a.fechora_salida) FROM tuneles a with(nolock) inner join fichrece b with(nolock) on(SUBSTRING(a.frec_codi,11,7)=b.frec_codi) inner join clientes c with(nolock) on(b.frec_rutcli=c.cli_rut) inner join detarece d with(nolock) on(SUBSTRING(a.frec_codi,11,9)=d.drec_codi) inner join maeprod e with(nolock) on(d.drec_codpro=e.mae_codi) WHERE CONVERT(DATE,a.fechora_ingreso) BETWEEN '" + devuelve_fecha(dtp_fecini.Value) + "' AND '" + devuelve_fecha(dtp_fecter.Value) + "' ORDER BY a.fechora_ingreso,a.frec_codi"

            dgvMovimientos.DataSource = fnc.ListarTablasSQL(strSQL)

        Else
            'strSQL = "SELECT frec_guia, " +
            '         "       SUBSTRING(frec_codi,11,9) frec_codi, " +
            '         "       fechora_ingreso, " +
            '         "       temp_ingreso, " +
            '         "       fechora_salida, " +
            '         "       temp_salida, " +
            '         "       DATEDIFF (hh,fechora_ingreso,fechora_salida ) horas_tunel " +
            '         "  FROM tuneles " +
            '         " WHERE CONVERT(DATE,fechora_ingreso) BETWEEN '" + devuelve_fecha(dtp_fecini.Value) + "' AND '" + devuelve_fecha(dtp_fecter.Value) + "' " +
            '         "  AND frec_guia = '" + CerosAnteriorString(txtnumguia.Text, 7) + "' ORDER BY fechora_ingreso, frec_codi "

            strSQL = "SELECT GUIA=a.frec_guia,'GUIA CLIENTE'=b.frec_guiades,CLIENTE=c.cli_nomb,CODIGO=drec_codpro,PRODUCTO=e.mae_descr,PALLET=SUBSTRING(a.frec_codi,11,9),'PALLET CLIENTE'=d.drec_sopocli,UNIDADES=d.drec_unidades,PESO=d.drec_peso,'FECHA RECEPCION'=convert(date,b.frec_fecrec),'FECHA PRODUCCION'=convert(date,d.drec_fecprod),'FECHA VENCIMIENTO'=convert(date,d.FechaVencimiento),'FECHA INGRESO'=convert(date,a.fechora_ingreso),'HORA INGRESO'=left(convert(varchar,a.fechora_ingreso,108),5),'T INGRESO'=a.temp_ingreso,'FECHA SALIDA'=convert(date,a.fechora_salida),'HORA SALIDA'=left(convert(varchar,a.fechora_salida,108),5),'T SALIDA'=a.temp_salida,'HORAS TUNEL'=DATEDIFF(hh,a.fechora_ingreso,a.fechora_salida) FROM tuneles a with(nolock) inner join fichrece b with(nolock) on(SUBSTRING(a.frec_codi,11,7)=b.frec_codi) inner join clientes c with(nolock) on(b.frec_rutcli=c.cli_rut) inner join detarece d with(nolock) on(SUBSTRING(a.frec_codi,11,9)=d.drec_codi) inner join maeprod e with(nolock) on(d.drec_codpro=e.mae_codi) WHERE CONVERT(DATE,a.fechora_ingreso) BETWEEN '" + devuelve_fecha(dtp_fecini.Value) + "' AND '" + devuelve_fecha(dtp_fecter.Value) + "' AND frec_guia = '" + CerosAnteriorString(txtnumguia.Text, 7) + "' ORDER BY a.fechora_ingreso,a.frec_codi"

            dgvMovimientos.DataSource = fnc.ListarTablasSQL(strSQL)
        End If
    End Sub

    Private Sub Btn_Salir_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Salir.Click
        Me.Close()
    End Sub

    Private Sub btnExcel_Click(sender As System.Object, e As System.EventArgs) Handles btnExcel.Click
        Call GridAExcel(dgvMovimientos)
    End Sub

    Private Sub Frm_ListadoTuneles_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        f_tuneles = False
    End Sub

    Private Sub Frm_ListadoTuneles_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
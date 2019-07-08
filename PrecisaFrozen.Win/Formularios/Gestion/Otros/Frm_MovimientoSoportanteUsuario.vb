Public Class Frm_MovimientoSoportanteUsuario

    Dim fnc As New Funciones

    Private Sub Btn_Buscar_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Buscar.Click
        Dim strSQL As String

        If chk_RadioFrecuencia.Checked Then
            strSQL = "SELECT * " +
                     "  FROM VG_MOVSOPUSU " +
                     " WHERE CONVERT(DATETIME,fechora,102) BETWEEN CONVERT(DATETIME,'" + devuelve_fecha(dtp_fecini.Value) + "' + ' ' + '" + dtp_horaini.Text + "',102) " +
                     "   AND CONVERT(DATETIME,'" + devuelve_fecha(dtp_fecter.Value) + "' + ' ' + ' " + dtp_horater.Text + " ',102) " +
                     " ORDER BY cod_usuario,fecha,hora"

        Else
            strSQL = "SELECT * " +
                     "  FROM VG_MOVSOPUSU " +
                     " WHERE CONVERT(DATETIME,fechora,102) BETWEEN CONVERT(DATETIME,'" + devuelve_fecha(dtp_fecini.Value) + "' + ' ' + '" + dtp_horaini.Text + "',102) " +
                     "   AND CONVERT(DATETIME,'" + devuelve_fecha(dtp_fecter.Value) + "' + ' ' + ' " + dtp_horater.Text + " ',102) " +
                     " ORDER BY cod_usuario,fecha,hora"

        End If
        
        dgvMovimientos.DataSource = fnc.ListarTablasSQL(strSQL)

    End Sub

    Private Sub btn_Imprimir_Click(sender As System.Object, e As System.EventArgs)
        Dim frm As Frm_MuestraReporte = New Frm_MuestraReporte
        frm.Text = "Asistente de informes - Informe de Movimientos de Soportantes por Usuario"

        Dim report As New Rpt_MovimientoSoportanteUsuario

        report.SetDatabaseLogon(Usuario_ODBC, Pass_ODBC)

        report.SetParameterValue("fecini", devuelve_fecha(dtp_fecini.Value))
        report.SetParameterValue("fecter", devuelve_fecha(dtp_fecter.Value))
        report.SetParameterValue("horaini", dtp_horaini.Text)
        report.SetParameterValue("horater", dtp_horater.Text)
        report.SetParameterValue("estado", chk_RadioFrecuencia.Checked)

        frm.Contenedor.ReportSource = report
        frm.ShowDialog()
    End Sub

    Private Sub Btn_Salir_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Salir.Click
        Me.Close()
    End Sub

    Private Sub Frm_MovimientoSoportanteUsuario_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        f_MovSopUsu = False
    End Sub

    Private Sub Frm_MovimientoSoportanteUsuario_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        dtp_horaini.Text = "22:00:00"
        dtp_horater.Text = "08:00:00"
        dtp_fecini.Value = DateAdd(DateInterval.Day, -1, Today)

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chk_RadioFrecuencia.CheckedChanged

    End Sub

    Private Sub btn_Imprimir_Click_1(sender As System.Object, e As System.EventArgs) Handles btn_Imprimir.Click
        Dim frm As Frm_MuestraReporte = New Frm_MuestraReporte
        frm.Text = "Asistente de informes - Informe de Movimientos de Soportantes por Usuario"

        Dim report As New Rpt_MovimientoSoportanteUsuario

        report.SetDatabaseLogon(Usuario_ODBC, Pass_ODBC)

        report.SetParameterValue("fecini", devuelve_fecha(dtp_fecini.Value))
        report.SetParameterValue("fecter", devuelve_fecha(dtp_fecter.Value))
        report.SetParameterValue("horaini", dtp_horaini.Text)
        report.SetParameterValue("horater", dtp_horater.Text)
        report.SetParameterValue("estado", chk_RadioFrecuencia.Checked)

        frm.Contenedor.ReportSource = report
        frm.ShowDialog()
    End Sub
End Class
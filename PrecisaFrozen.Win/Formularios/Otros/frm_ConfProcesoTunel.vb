Imports System.Data.SqlClient

'
'   VES OCT 2019
'   
'   FORMULARIO PARA MODIFICAR CONFIGURACIONES
'   RELATIVAS AL PROCESO DE TUNELES
'
Public Class Frm_ConfProcesoTunel

    Dim fnc As New Funciones()
    Dim reglasFCT As DataTable
    Dim reglasRCT As DataTable

    Private Sub Frm_ConfProcesoTunel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim prefs As DataTable = fnc.ListarTablasSQL("SELECT * FROM dbo.fnListPrefs('ptech.tunel.*')")
        For Each pref As DataRow In prefs.Rows
            Dim prfId = pref("prf_id").ToString().Trim()
            Dim prfValue = pref("prf_value").ToString().Trim()
            Select Case prfId
                Case "cantMuestrasRequeridas"
                    cboCantMuestras.Text = prfValue
                Case "cantFotosPorMuestra"
                    cboCantFotos.Text = prfValue
                Case "horaBaseRef"
                    txtHoraBase.Text = prfValue
                Case "permitirOTParcial"
                    chkPermitirGuiaParcial.Checked = If(prfValue = "True", True, False)
                Case "limAlertaInicioDemorado"
                    cboAlertaInicioDemorado.Text = prfValue
                Case "limAlertaDetencion"
                    cboAlertaDetencion.Text = prfValue
                Case "alertasInicioTunel1"
                    cboAlertasTunel1.Text = prfValue
                Case "alertasInicioTunel2"
                    cboAlertasTunel2.Text = prfValue
                Case "alertasInicioTunel3"
                    cboAlertasTunel3.Text = prfValue
                Case "maxPalletsPorTunel"
                    cboMaxPalletsPorTunel.Text = prfValue
            End Select
        Next
        requeryReglasFCT()
        requeryReglasRCT()
    End Sub

    Private Sub txtHoraBase_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHoraBase.KeyPress
        '
        '   SOLO SE PERMITEN NUMEROS, : y ENTER
        '
        If e.KeyChar <> ":" And e.KeyChar <> Chr(13) Then SoloNumeros(sender, e)
    End Sub


    Private Sub savePref(ByVal prfId As String, ByVal prfValue As String)
        '
        '   ACTUALIZAMOS EL VALOR DE LA PREFERENCIA
        '   INDICADA.  ESTE METODO SE INVOCA CADA
        '   VES QUE SE MODIFICA UN VALOR EN EL 
        '   FORULARIO
        '
        fnc.MovimientoSQL("EXEC spSetPref @prfId, @prfValue, @usrid",
                          New SqlParameter() {
                              New SqlParameter("@prfId", prfId),
                              New SqlParameter("@prfValue", prfValue),
                              New SqlParameter("@usrid", Frm_Principal.InfoUsuario.Text)
                          })
    End Sub

    Private Sub txtHoraBase_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtHoraBase.Validating
        '
        '   VALIDAMOS QUE LA HORA BASE INDICADA SIGA
        '   EL FORMATO HH:MM
        '
        Dim hora As String = txtHoraBase.Text.Trim()
        If hora.Length <> 5 Or hora(2) <> ":" Then
            e.Cancel = True
            Return
        End If

        Dim horas As Integer = CInt(hora.Substring(0, 2))
        Dim minutos As Integer = CInt(hora.Substring(3, 2))
        If horas > 23 Or minutos > 59 Then
            e.Cancel = True
            Return
        End If

    End Sub

    Private Sub txtHoraBase_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHoraBase.Validated
        savePref("ptech.tunel.horaBaseRef", txtHoraBase.Text.Trim())
    End Sub

    Private Sub chkPermitirGuiaParcial_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPermitirGuiaParcial.CheckedChanged
        savePref("ptech.tunel.permitirOTParcial", If(chkPermitirGuiaParcial.Checked, "True", "False"))
    End Sub

    Private Sub cboCantMuestras_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCantMuestras.SelectedIndexChanged
        savePref("ptech.tunel.cantMuestrasRequeridas", cboCantMuestras.Text)
    End Sub

    Private Sub cboCantFotos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCantFotos.SelectedIndexChanged
        savePref("ptech.tunel.cantFotosPorMuestra", cboCantFotos.Text)
    End Sub

    Private Sub requeryReglasFCT()
        Dim sql As String = "SELECT a.fct_id, ISNULL(b.fam_descr,CAST('(CUALQUIERA)' AS NVARCHAR(40))) AS fam_descr, " +
                            "       ISNULL(c.cli_nomb,CAST('(CUALQUIERA)' AS NVARCHAR(50))) AS cli_nomb, " +
                            "       a.fct_tmpini, a.fct_tmpfin, a.fct_horas, a.fct_kilos " +
                            "  FROM cnffct a " +
                            "  LEFT JOIN famprod b ON b.fam_unica = a.fam_unica " +
                            "  LEFT JOIN clientes c ON c.cli_rut = a.cli_rut " +
                            " WHERE fct_status = 'ACTIVA' " +
                            " ORDER BY a.fct_nivel, b.fam_descr, c.cli_nomb"
        reglasFCT = fnc.ListarTablasSQL(sql)
        dgrReglas.DataSource = reglasFCT
        btnEliminar.Visible = False
    End Sub


    Private Sub requeryReglasRCT()
        Dim sql As String = "SELECT a.rct_id, a.rct_desde, a.rct_hasta, a.rct_factor " +
                            "  FROM cnfrct a " +
                            " WHERE rct_status = 'ACTIVA' " +
                            " ORDER BY a.rct_desde"
        reglasRCT = fnc.ListarTablasSQL(sql)
        dgrRCT.DataSource = reglasRCT
        cmdDropRCT.Visible = False
    End Sub

    Private Sub btnIncluirRegla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIncluirRegla.Click
        Dim f As New frm_ReglaFCT
        f.ShowDialog()
        requeryReglasFCT()
    End Sub

    Private Sub dgrReglas_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgrReglas.SelectionChanged
        If dgrReglas.CurrentRow IsNot Nothing Then
            btnEliminar.Visible = If(dgrReglas.CurrentRow.Index > 0, True, False)
        Else
            btnEliminar.Visible = False
        End If
    End Sub

    Private Sub dgrReglas_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgrReglas.DoubleClick
        Dim regla As DataRow = reglasFCT.Rows(dgrReglas.CurrentRow.Index)
        Dim fct_id As Integer = CInt(regla("fct_id").ToString())
        Dim row As DataRow = fnc.sqlExecuteRow("SELECT * FROM cnffct WHERE fct_id = @p0", fct_id)
        Dim f As New frm_ReglaFCT
        f.regla = row
        f.ShowDialog()
        requeryReglasFCT()
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If Confirmar("Desea eliminar esta regla?") = False Then Return
        Dim regla As DataRow = reglasFCT.Rows(dgrReglas.CurrentRow.Index)
        Dim fct_id As Integer = CInt(regla("fct_id").ToString())
        Dim r As sqlCmdResult = fnc.runSQLCmd("UPDATE cnffct SET fct_status = 'ANULADA', fct_ultact=GETDATE(), fct_usucod=@user WHERE fct_id = @id",
                                              New SqlParameter() {
                                                  New SqlParameter("@user", Frm_Principal.InfoUsuario.Text),
                                                  New SqlParameter("@id", fct_id)
                                              })
        If r.result = False Then
            MsgBox(r.errorMsg, MsgBoxStyle.Critical, "Cuidado")
            Return
        End If
        requeryReglasFCT()
    End Sub

    Private Sub Frm_ConfProcesoTunel_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        f_confTunel = False
    End Sub


    Private Sub cboAlertaInicioDemorado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAlertaInicioDemorado.SelectedIndexChanged
        savePref("ptech.tunel.limAlertaInicioDemorado", cboAlertaInicioDemorado.Text)
    End Sub

    Private Sub cboAlertaDetencion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAlertaDetencion.SelectedIndexChanged
        savePref("ptech.tunel.limAlertaDetencion", cboAlertaInicioDemorado.Text)
    End Sub

    Private Sub cboAlertasTunel1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAlertasTunel1.SelectedIndexChanged
        savePref("ptech.tunel.alertasInicioTunel1", cboAlertasTunel1.Text)
    End Sub

    Private Sub cboAlertasTunel2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAlertasTunel2.SelectedIndexChanged
        savePref("ptech.tunel.alertasInicioTunel2", cboAlertasTunel2.Text)
    End Sub

    Private Sub cboAlertasTunel3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAlertasTunel3.SelectedIndexChanged
        savePref("ptech.tunel.alertasInicioTunel3", cboAlertasTunel3.Text)
    End Sub

    Private Sub cmdAddRCT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddRCT.Click
        Dim f As New frm_ReglaRCT
        f.ShowDialog()
        requeryReglasRCT()
    End Sub

    Private Sub cmdDropRCT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDropRCT.Click
        If Confirmar("Desea eliminar esta regla?") = False Then Return
        Dim regla As DataRow = reglasRCT.Rows(dgrRCT.CurrentRow.Index)
        Dim rct_id As Integer = CInt(regla("rct_id").ToString())
        Dim r As sqlCmdResult = fnc.runSQLCmd("UPDATE cnfrct SET rct_status = 'ANULADA', rct_ultact=GETDATE(), rct_usucod = @user WHERE fct_id = @id",
                                              New SqlParameter() {
                                                  New SqlParameter("@user", Frm_Principal.InfoUsuario.Text),
                                                  New SqlParameter("@id", rct_id)
                                              })
        If r.result = False Then
            MsgBox(r.errorMsg, MsgBoxStyle.Critical, "Cuidado")
            Return
        End If
        requeryReglasRCT()
    End Sub


    Private Sub dgrRCT_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgrRCT.DoubleClick
        Dim regla As DataRow = reglasRCT.Rows(dgrRCT.CurrentRow.Index)
        Dim rct_id As Integer = CInt(regla("rct_id").ToString())
        Dim row As DataRow = fnc.sqlExecuteRow("SELECT * FROM cnfrct WHERE rct_id = @p0", rct_id)
        Dim f As New frm_ReglaRCT
        f.regla = row
        f.ShowDialog()
        requeryReglasRCT()
    End Sub

    Private Sub dgrRCT_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgrRCT.SelectionChanged
        If dgrRCT.CurrentRow IsNot Nothing Then
            cmdDropRCT.Visible = True
        Else
            cmdDropRCt.Visible = False
        End If
    End Sub

    Private Sub cboMaxPalletsPorTunel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMaxPalletsPorTunel.SelectedIndexChanged
        savePref("ptech.tunel.maxPalletsPorTunel", cboMaxPalletsPorTunel.Text)
    End Sub
End Class
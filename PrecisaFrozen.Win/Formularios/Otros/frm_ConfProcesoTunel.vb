Imports System.Data.SqlClient

'
'   VES OCT 2019
'   
'   FORMULARIO PARA MODIFICAR CONFIGURACIONES
'   RELATIVAS AL PROCESO DE TUNELES
'
Public Class Frm_ConfProcesoTunel

    Dim fnc As New Funciones()
    Dim reglas As DataTable

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
                Case "frecCorreoStatusTuneles"
                    cboFrecCorreo.Text = prfValue
                Case "destinatariosCorreo"
                    txtDestinatariosCorreo.Text = prfValue.Replace(";", vbCrLf)
                Case "limAlertaInicioDemorado"
                    cboAlertaInicioDemorado.Text = prfValue
                Case "limAlertaDetencion"
                    cboAlertaDetencion.Text = prfValue
            End Select
        Next
        requeryReglas()
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

    Private Sub cboFrecCorreo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFrecCorreo.SelectedIndexChanged
        savePref("ptech.tunel.frecCorreoStatusTuneles", cboCantFotos.Text)
    End Sub

    Private Sub txtDestinatariosCorreo_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtDestinatariosCorreo.Validating
        '
        '   TODO: VALIDAR CORREOS INDIVIDUALES
        '
    End Sub

    Private Sub txtDestinatariosCorreo_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDestinatariosCorreo.Validated
        savePref("ptech.tunel.destinatariosCorreo", txtDestinatariosCorreo.Text.Replace(vbCrLf, ";"))
    End Sub


    Private Sub requeryReglas()
        Dim sql As String = "SELECT a.fct_id, ISNULL(b.fam_descr,CAST('(CUALQUIERA)' AS NVARCHAR(40))) AS fam_descr, " +
                            "       ISNULL(c.cli_nomb,CAST('(CUALQUIERA)' AS NVARCHAR(50))) AS cli_nomb, " +
                            "       a.fct_tmpini, a.fct_tmpfin, a.fct_horas, a.fct_kilos " +
                            "  FROM cnffct a " +
                            "  LEFT JOIN famprod b ON b.fam_unica = a.fam_unica " +
                            "  LEFT JOIN clientes c ON c.cli_rut = a.cli_rut " +
                            " WHERE fct_status = 'ACTIVA' " +
                            " ORDER BY a.fct_nivel, b.fam_descr, c.cli_nomb"
        reglas = fnc.ListarTablasSQL(sql)
        dgrReglas.DataSource = reglas
        btnEliminar.Visible = False
    End Sub


    Private Sub btnIncluirRegla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIncluirRegla.Click
        Dim f As New frm_ReglaFCT
        f.ShowDialog()
        requeryReglas()
    End Sub

    Private Sub dgrReglas_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgrReglas.SelectionChanged
        If dgrReglas.CurrentRow IsNot Nothing Then
            btnEliminar.Visible = If(dgrReglas.CurrentRow.Index > 0, True, False)
        Else
            btnEliminar.Visible = False
        End If
    End Sub

    Private Sub dgrReglas_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgrReglas.DoubleClick
        Dim regla As DataRow = reglas.Rows(dgrReglas.CurrentRow.Index)
        Dim fct_id As Integer = CInt(regla("fct_id").ToString())
        Dim row As DataRow = fnc.sqlExecuteRow("SELECT * FROM cnffct WHERE fct_id = @p0", fct_id)
        Dim f As New frm_ReglaFCT
        f.regla = row
        f.ShowDialog()
        requeryReglas()
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If Confirmar("Desea eliminar esta regla?") = False Then Return
        Dim regla As DataRow = reglas.Rows(dgrReglas.CurrentRow.Index)
        Dim fct_id As Integer = CInt(regla("fct_id").ToString())
        Dim r As sqlCmdResult = fnc.runSQLCmd("UPDATE cnffct SET fct_status = 'ANULADA' WHERE fct_id = @p0", fct_id)
        If r.result = False Then
            MsgBox(r.errorMsg, MsgBoxStyle.Critical, "Cuidado")
            Return
        End If
        requeryReglas()
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
End Class
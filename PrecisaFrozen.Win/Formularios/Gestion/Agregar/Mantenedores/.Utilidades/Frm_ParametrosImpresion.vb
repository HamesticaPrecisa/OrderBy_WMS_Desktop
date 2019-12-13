Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Windows.Forms

Public Class Frm_ParametrosImpresion

    Dim fnc As New Funciones
    Dim rpt As ReportDocument = Nothing
    Dim cr As New CrystalReportViewer

    Dim paginas As Integer = 0
    Dim copias As Integer = 1


    Private Sub Frm_ParametrosImpresion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cr.ReportSource = rpt
        paginas = cr.GetCurrentPageNumber
    End Sub

    Private Sub Btn_Imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Imprimir.Click

        'Dim tabla As DataTable = fnc.ListarTablasSQL("SELECT imp_inf FROM conf_impresora WHERE imp_comp='" + My.Computer.Name + "'")

        'If tabla.Rows.Count > 0 Then
        '    rpt.PrintOptions.PrinterName = tabla.Rows(0)(0).ToString()
        'End If

        If RbPaginas.Checked = True AndAlso IsNumeric(txtpagina.Text) Then
            If Val(txtpagina.Text) > cr.GetCurrentPageNumber Then
                MsgBox("No puede imprimir un numero de pagina que no existe", MsgBoxStyle.Critical, "Aviso")
                Exit Sub
            End If
        End If

        If RbTodo.Checked = True Then
            rpt.PrintToPrinter(DudCopias.Text, False, 1, cr.GetCurrentPageNumber)
        ElseIf RbPaginas.Checked = True Then
            rpt.PrintToPrinter(DudCopias.Text, False, Val(txtpagina.Text), Val(txtpagina.Text))
        End If
    End Sub

    Private Sub txtpagina_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpagina.KeyPress
        SoloNumeros(sender, e)
    End Sub
End Class
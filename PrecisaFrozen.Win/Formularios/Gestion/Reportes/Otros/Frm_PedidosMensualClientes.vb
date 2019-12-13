Public Class Frm_PedidosMensualClientes

    Dim fnc As New Funciones

    Private Sub CmboMes_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CmboMes.KeyPress
        e.Handled = True
    End Sub

    Private Sub btn_BuscaCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_BuscaCliente.Click
        Lst_AyudaClientes.ShowDialog(Frm_Principal)
        If Frm_Principal.buscavalor.ToString <> "" Then
            Txtcliente.Text = RetornaCliente(Frm_Principal.buscavalor.ToString())
            TxtClirut.Text = Frm_Principal.buscavalor.ToString()
            Frm_Principal.buscavalor = ""
        End If
    End Sub

    Private Sub t2contrato_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles t2contrato.CheckedChanged
        If t2contrato.Checked = True Then
            btn_BuscaCliente.Enabled = False
            TxtClirut.Text = ""
            Txtcliente.Text = ""
        Else
            btn_BuscaCliente.Enabled = True
        End If
    End Sub

    Private Sub Frm_PedidosMensualClientes_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        f_pedidosmensual = False
    End Sub

    Private Sub Frm_PedidosMensualClientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim mes = fnc.DevuelveFechaServidor().Month - 1
        Dim anio = fnc.DevuelveFechaServidor().Year - 1
        CmboMes.SelectedIndex = mes


        For i As Integer = 2018 To fnc.DevuelveFechaServidor().Year
            CmboAnio.Items.Add(i.ToString())
        Next
        CmboAnio.SelectedIndex = 0

    End Sub

    Private Sub btn_Imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Imprimir.Click
        If fnc.verificaExistencia("clientes", "cli_rut", TxtClirut.Text) = True Then

            Dim frm As Frm_MuestraReporte = New Frm_MuestraReporte
            frm.Text = "Asistente de informes - Guia Recepcion"

            Dim report As New Rpt_PedidosMensualClientes

            report.SetDatabaseLogon(Usuario_ODBC, Pass_ODBC)
            report.SetParameterValue("mes", CmboMes.SelectedIndex + 1)
            report.SetParameterValue("anio", CmboAnio.SelectedItem)
            report.SetParameterValue("cliente", TxtClirut.Text)
            frm.Contenedor.ReportSource = report
            frm.ShowDialog()

        Else
            Dim frm As Frm_MuestraReporte = New Frm_MuestraReporte
            frm.Text = "Asistente de informes - Guia Recepcion"

            Dim report As New Rpt_PedidosMensualCliente

            report.SetDatabaseLogon(Usuario_ODBC, Pass_ODBC)
            report.SetParameterValue("mes", CmboMes.SelectedIndex + 1)
            report.SetParameterValue("anio", CmboAnio.SelectedItem)
            frm.Contenedor.ReportSource = report
            frm.ShowDialog()
        End If
    End Sub
End Class
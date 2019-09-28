 
Imports CrystalDecisions.Shared

Public Class Frm_StockResumidoPar
#Region "Cliente"

   
    Private Sub Btn_cliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_cliente.Click
        Lst_AyudaClientes.ShowDialog(Frm_Principal)
        If Frm_Principal.buscavalor.ToString <> "" Then
            Txtcliente.Text = RetornaCliente(Frm_Principal.buscavalor.ToString())
            LblCliente.Text = Frm_Principal.buscavalor.ToString()
            Frm_Principal.buscavalor = ""
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

    Private Sub Btn_Imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Imprimir.Click
        If Txtcliente.Text = "" Then
            MsgBox("Debe elegir un cliente para generar el informe", MsgBoxStyle.Critical, "Aviso")
            Exit Sub
        End If

        'Imprimir Stock


        Dim frm As Frm_MuestraReporte = New Frm_MuestraReporte
        frm.Text = "Asistente de informes - Informe de Stock Resumido"
 
        Dim report As New Rpt_StockResumido
 
        report.SetDatabaseLogon(Usuario_ODBC, Pass_ODBC)

        report.SetParameterValue("codigo", Retorna_Where())
        report.SetParameterValue("cl", Txtcliente.Text)
        report.SetParameterValue("co", TxtContrato.Text)

        frm.Contenedor.ReportSource = report
        frm.ShowDialog()


    End Sub

    Function Retorna_Where() As String
        Dim where As String = ""

        If Txtcliente.Text <> "" Then
            where = where + "AND dr.drec_rutcli='" + LblCliente.Text + "' "
        End If

        If t2contrato.Checked = False Then
            If TxtContrato.Text = "" Then
                t2contrato.Checked = True
            Else
                where = where + " AND dr.drec_contcli='" + LblContrato.Text + "' "
            End If

        End If

        Return where
    End Function

    Private Sub Rpt_StockClienteResumidoPar_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        For Each c As CheckBox In Me.Controls.OfType(Of CheckBox)()
            If TypeOf c Is CheckBox Then
                c.Checked = True
            End If
        Next
    End Sub

    Private Sub Btn_Salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Salir.Click
        Me.Close()
    End Sub
End Class
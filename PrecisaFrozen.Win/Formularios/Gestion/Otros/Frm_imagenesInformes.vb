Public Class Frm_imagenesInformes

    Private Sub Frm_imagenesInformes_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim codigo As String = Frm_AddEnvioEmail.codigoInforme

        If (codigo = "1") Then
            pb_rdc.Visible = True
        End If

        If (codigo = "3") Then
            pb_documentosemitidos.Visible = True
        End If

        If (codigo = "4") Then
            pb_pedidosweb.Visible = True
        End If

        If (codigo = "5") Then
            pb_vencidos.Visible = True
        End If

        If (codigo = "7") Then
            pb_pedidospre.Visible = True
        End If

        If (codigo = "10") Then
            pb_posicionescamara.Visible = True
        End If

        If (codigo = "11") Then
            pb_semanal.Visible = True
        End If

        If (codigo = "12") Then
            pb_pedidoshora.Visible = True
        End If

        If (codigo = "13") Then
            pb_soportantes.Visible = True
        End If

        If (codigo = "14") Then
            pb_sintermino.Visible = True
        End If
    End Sub

    Private Sub Frm_imagenesInformes_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        pb_documentosemitidos.Visible = False
        pb_pedidosweb.Visible = False
        pb_vencidos.Visible = False
        pb_pedidospre.Visible = False
        pb_posicionescamara.Visible = False
        pb_semanal.Visible = False
        pb_pedidoshora.Visible = False
        pb_soportantes.Visible = False
        pb_sintermino.Visible = False
    End Sub
End Class
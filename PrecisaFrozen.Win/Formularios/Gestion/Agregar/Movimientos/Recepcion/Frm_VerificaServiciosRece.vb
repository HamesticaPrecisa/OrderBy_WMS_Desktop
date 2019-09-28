Public Class Frm_VerificaServiciosrece

    Private Sub btnno_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnno.Click
        Dim _formInterface As IForm = CType(Me.Owner, IForm)
        _formInterface.ChangeTextBoxText("NO")
        Me.Close()
    End Sub

    Private Sub btnsi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsi.Click
        If MsgBox("Seguro de finalizar la recepcion", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = vbYes Then
            Dim _formInterface As IForm = CType(Me.Owner, IForm)
            _formInterface.ChangeTextBoxText("SI")
            Me.Close()
        Else
            Dim _formInterface As IForm = CType(Me.Owner, IForm)
            _formInterface.ChangeTextBoxText("NO")
            Me.Close()
        End If
    End Sub

    Private Sub Frm_VerificaServiciosrece_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
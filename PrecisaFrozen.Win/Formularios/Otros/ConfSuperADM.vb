Public Class ConfSuperADM

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Application.Exit()
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Frm_MantenedorUsuarios.ShowDialog()
        primerusuario = "S"
        Me.Close()
    End Sub
End Class
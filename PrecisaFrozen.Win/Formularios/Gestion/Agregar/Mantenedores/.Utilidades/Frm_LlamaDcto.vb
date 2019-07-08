Public Class Frm_LlamaDcto

    Private Sub txtnum_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtnum.KeyPress
        If e.KeyChar = ChrW(13) Then
            Frm_Principal.buscavalor = txtnum.Text
            Me.Close()
        Else
            SoloNumeros(sender, e)
        End If

    End Sub
End Class
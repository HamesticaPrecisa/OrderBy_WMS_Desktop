Public Class ayudaNEW

    Private Sub ayudaNEW_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        AxAcroPDF1.LoadFile("\\192.168.1.164\Gestion\M.pdf")
    End Sub

    Private Sub ayudaNEW_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        f_manual = False
    End Sub
End Class
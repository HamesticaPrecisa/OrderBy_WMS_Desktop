Public Class AvisoPalletMalPos
    Dim fnc As New Funciones
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim sql As String = "Select * FROM VG_TMPPOS"

        DgvResultado.DataSource = fnc.ListarTablasSQL(sql)
    End Sub

    Private Sub AvisoPalletMalPos_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        f_avisopal = False
    End Sub
End Class
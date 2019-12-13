Imports System.ComponentModel

Public Class Frm_Calendario

    Dim clicks As Integer = 0
    Dim fecha As String = ""

    Private Sub Calendario_DateSelected(sender As Object, e As System.Windows.Forms.DateRangeEventArgs) Handles Calendario.DateSelected
        If Calendario.SelectionEnd.ToShortDateString() = fecha Then
            Frm_Principal.buscavalor = Calendario.SelectionEnd.ToShortDateString()
            Me.Close()
        End If
        fecha = Calendario.SelectionEnd.ToShortDateString()
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        fecha = ""
    End Sub

    Private Sub Frm_Calendario_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Timer1.Stop()
    End Sub

    Private Sub Frm_Calendario_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Timer1.Start()
    End Sub

End Class
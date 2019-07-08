Public Class Frm_detalleautosoportantes
    Dim fnc As New Funciones
    Private Sub Frm_detalleautosoportantes_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim sql2 As String = "select * from  vg_detalle_autosoportante"

        Dim tabla As DataTable = fnc.ListarTablasSQL(sql2)
        DgvResultado.DataSource = tabla
    End Sub
End Class
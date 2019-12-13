Public Class Frm_ListadoPorteria

    Dim fnc As New Funciones

    Private Sub Frm_ListadoPorteria_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim sql As String = "SELECT Cl_fol, cli_nomb, cho_nombre, Cl_pate, Cl_dessello, Cl_salGuia, Cl_Ting " +
            "FROM zCheckList INNER JOIN choferes ON Cl_chorut=cho_rut INNER JOIN clientes ON cli_rut=Cl_RutCli ORDER BY Cl_fol desc"
        DataGridView1.DataSource = fnc.ListarTablasSQL(sql)
    End Sub
End Class
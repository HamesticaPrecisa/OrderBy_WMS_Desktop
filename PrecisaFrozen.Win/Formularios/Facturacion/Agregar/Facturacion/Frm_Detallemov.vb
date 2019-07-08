Public Class Frm_Detallemov

    Public fecha As String = ""
    Public contrato As String = ""

    Dim fnc As New Funciones

    Private Sub Frm_Detallemov_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim sqlr As String = "SELECT CODIGO, ori_descr, SOPO, UNI, PES FROM GvwFactINOUT INNER JOIN origen ON ori_codi=origen WHERE FECHA='" + fecha + "' AND CONTRATO='" + contrato + "' AND TIPO='003'"
        DgvEntradas.DataSource = fnc.ListarTablasSQL(sqlr)

        Dim sqld As String = "SELECT CODIGO, ori_descr, SOPO, SOPO_SC , UNI, PES FROM GvwFactINOUT INNER JOIN origen ON ori_codi=origen WHERE FECHA='" + fecha + "' AND CONTRATO='" + contrato + "' AND TIPO='002'"
        DgvSalidas.DataSource = fnc.ListarTablasSQL(sqld)

    End Sub

End Class
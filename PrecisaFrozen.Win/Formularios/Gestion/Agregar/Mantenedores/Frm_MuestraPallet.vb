Public Class Frm_MuestraPallet
    Dim fnc As New Funciones
    Public PS As String = ""
    Public posicionre As String = ""
    Private Sub Frm_MuestraPallet_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        posicionre = s.posicioncreada
        Dim sql2 As String = ""
        If w.columnapublic.Trim() = "00" Then

            If valorpiso = "1" Then


                sql2 = "select soportante,cliente,producto,TipoPallet,unidades,ultimo,fecha,HR AS hora from  vg_rackdeta_2d WHERE racd_pi='00' AND racd_ca = '" + w.codigocamara.Trim() + "' and racd_ba = '" + w.bandapublic.Trim() + "' and racd_co='" + w.columnapublic + "'"




            End If
        Else
            sql2 = "select soportante,cliente,producto,TipoPallet,unidades,ultimo,fecha,HR AS hora from  vg_rackdeta_2d WHERE racd_pi='" + valorpiso.ToString() + "' AND racd_ca = '" + w.codigocamara.Trim() + "' and racd_ba = '" + w.bandapublic.Trim() + "' and racd_co='" + w.columnapublic + "'"
        End If



        Dim tabla As DataTable = fnc.ListarTablasSQL(sql2)
        DgvResultado.DataSource = tabla
    End Sub
End Class
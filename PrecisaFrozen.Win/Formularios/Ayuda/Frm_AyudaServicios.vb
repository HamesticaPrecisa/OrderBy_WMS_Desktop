Public Class Frm_AyudaServicios

    Dim fnc As New Funciones

    Public bloq_estado As Boolean = False
    Public ncontrato As String = ""

    Public tipo = 0
    '0 | Corresponde a servicios solo frigorifico
    '1 | Corresponde a servicios solo Administrativos

    Private Sub Frm_AyudaServicios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim sql As String
        If bloq_estado = True Then
            sql = "SELECT  Dcon_ServCod, Serv_Nom FROM ContratosDetalle INNER JOIN FacServicios " +
                           "ON Dcon_ServCod=Serv_Cod WHERE Dcon_Codigo='" + ncontrato + "' AND  Dcon_activo='1' AND  (Serv_Sec='" + (tipo + 1).ToString() + "' OR Serv_Sec='3') "
        Else
            sql = "SELECT Dcon_ServCod, Serv_Nom FROM ContratosDetalle INNER JOIN FacServicios " +
                           "ON Dcon_ServCod=Serv_Cod WHERE Dcon_Codigo='" + ncontrato + "' "
        End If

        DgvServicios.DataSource = fnc.ListarTablasSQL(sql)

    End Sub

    Private Sub DgvServicios_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvServicios.CellDoubleClick
        If e.RowIndex > -1 Then
            Dim _formInterface As IForm = CType(Me.Owner, IForm)
            _formInterface.ChangeTextBoxText(DgvServicios.Rows(e.RowIndex).Cells(0).Value.ToString())
            Me.Close()
        End If
    End Sub

    Private Sub txtbuscador_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtbuscador.TextChanged
        Dim sql As String
        If bloq_estado = True Then
            sql = "SELECT  Dcon_ServCod, Serv_Nom FROM ContratosDetalle INNER JOIN FacServicios " +
                           "ON Dcon_ServCod=Serv_Cod WHERE Dcon_Codigo='" + ncontrato + "' AND  Dcon_activo='1' " +
                           "AND serv_nom LIKE '%" + txtbuscador.Text + "%' AND  (Serv_Sec='" + (tipo + 1).ToString() + "' OR Serv_Sec='3')"
        Else
            sql = "SELECT Dcon_ServCod, Serv_Nom FROM ContratosDetalle INNER JOIN FacServicios " +
                           "ON Dcon_ServCod=Serv_Cod WHERE Dcon_Codigo='" + ncontrato + "' AND serv_nom LIKE '%" + txtbuscador.Text + "%'"
        End If

        DgvServicios.DataSource = fnc.ListarTablasSQL(sql)
    End Sub
End Class
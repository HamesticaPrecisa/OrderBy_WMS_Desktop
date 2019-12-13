Public Class Lst_AyudaProductos

    Dim fnc As New Funciones

    Public Condicion As String = ""
    Public IsRecepcion As Boolean = False
    Dim estado As String = ""

    Private Sub Lst_AyudaProductos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'IsRecepcion =   '1' Desde recepcion      '0' Desde el resto
        If IsRecepcion = True Then
            estado = "1"
        Else
            estado = "2"
        End If
        'estado = Convert.ToInt32(IsRecepcion).ToString()

        Dim sql As String = ""

        If Condicion = "" Then
            sql = "SELECT mae_codi, mae_descr, mae_codcli as CODCLI FROM maeprod WHERE mae_estado <>'" + estado + "'"
        Else
            sql = "SELECT mae_codi, mae_descr , mae_codcli as CODCLI FROM maeprod WHERE mae_estado <>'" + estado + "' AND " + Condicion
        End If

        DataGridView1.DataSource = fnc.ListarTablasSQL(sql)
    End Sub

    Private Sub txtbusca_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtbusca.KeyUp
        Dim sql As String
        If Condicion = "" Then
            sql = "SELECT mae_codi, mae_descr, mae_codcli FROM maeprod WHERE mae_estado <>'" + estado + "' AND  " + Condicion + " (mae_codi LIKE '%" + txtbusca.Text + "%'" +
           "OR mae_descr LIKE '%" + txtbusca.Text + "%' OR mae_codcli like '%" + txtbusca.Text + "%')"
        Else
            sql = "SELECT mae_codi, mae_descr , mae_codcli FROM maeprod WHERE mae_estado <>'" + estado + "' AND " + Condicion + " AND (mae_codi LIKE '%" + txtbusca.Text + "%' " +
           "OR mae_descr LIKE '%" + txtbusca.Text + "%' OR mae_codcli like '%" + txtbusca.Text + "%')"
        End If

        DataGridView1.DataSource = fnc.ListarTablasSQL(sql)
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        If e.RowIndex > -1 Then
            Dim _formInterface As IForm = CType(Me.Owner, IForm)
            _formInterface.ChangeTextBoxText(DataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString())
            Me.Close()
        End If
    End Sub
End Class
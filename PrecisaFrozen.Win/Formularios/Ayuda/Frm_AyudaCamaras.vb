Public Class Frm_AyudaCamaras
    Dim fnc As New Funciones

    ' Dim where As String = ""

    Dim modo As Integer = 0
    Private Sub Frm_AyudaCamaras_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim sql As String = ""


            sql = "SELECT camara, upper(NCamara) as ncamara FROM camaraconf "

        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

        If tabla.Rows.Count > 0 Then
            Me.DataGridView1.DataSource = tabla
        End If
    End Sub

    Private Sub DataGridView1_DoubleClick(sender As System.Object, e As System.EventArgs) Handles DataGridView1.DoubleClick
   

    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        If e.RowIndex > -1 Then
            Dim _formInterface As IForm = CType(Me.Owner, IForm)

            _formInterface.ChangeTextBoxText(DataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString())

            Me.Close()
        End If
    End Sub

    Private Sub txtbusca_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtbusca.TextChanged
        Dim sql As String = ""

        sql = "SELECT camara, upper(NCamara) as ncamara FROM camaraconf WHERE ncamara LIKE '%" + txtbusca.Text + "%'"



            Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

            If tabla.Rows.Count > 0 Then
                Me.DataGridView1.DataSource = tabla
            End If
    End Sub
End Class
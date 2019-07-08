Public Class Lst_AyudaClientes

    Dim fnc As New Funciones

    Public cliente As String = "NO"

    Private Sub DataGridView1_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        If e.RowIndex > -1 AndAlso e.ColumnIndex > -1 Then
            Dim _formInterface As IForm = CType(Me.Owner, IForm)
            _formInterface.ChangeTextBoxText(DataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString())
            Me.Close()
        End If
    End Sub

    Private Sub Lst_AyudaClientes_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        txtbusca.Text = ""
    End Sub

    Private Sub Lst_ClientesAyuda_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If clientesbusc = "SI" Then

            If cliente = "SI" Then
                DataGridView1.DataSource = New Funciones().ListarTablasSQL("SELECT cli_rut, cli_nomb,cli_estado as ESTADO FROM clientes   ORDER BY cli_nomb")

            ElseIf cliente = "NO" Then
                DataGridView1.DataSource = New Funciones().ListarTablasSQL("SELECT cli_rut, cli_nomb,cli_estado AS ESTADO  FROM clientes WHERE cli_codvig='0'  ORDER BY cli_nomb")



            End If


        Else
            If cliente = "SI" Then
                DataGridView1.DataSource = New Funciones().ListarTablasSQL("SELECT cli_rut, cli_nomb,cli_estado as ESTADO FROM clientes where cli_estado='A' ORDER BY cli_nomb")

            ElseIf cliente = "NO" Then
                DataGridView1.DataSource = New Funciones().ListarTablasSQL("SELECT cli_rut, cli_nomb,cli_estado AS ESTADO  FROM clientes WHERE cli_codvig='0' and cli_estado='A' ORDER BY cli_nomb")



            End If

        End If

    




    End Sub


    Private Sub txtbusca_KeyDown1(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtbusca.KeyDown
        If e.KeyCode = Keys.Enter Then
            If DataGridView1.Rows.Count = 1 Then
                Dim _formInterface As IForm = CType(Me.Owner, IForm)
                _formInterface.ChangeTextBoxText(DataGridView1.Rows(0).Cells(0).Value.ToString())
                Me.Close()
            End If
        End If
    End Sub

    Private Sub txtbusca_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtbusca.TextChanged
        If clientesbusc = "SI" Then
            If cliente = "SI" Then
                DataGridView1.DataSource = New Funciones().ListarTablasSQL("SELECT cli_rut, cli_nomb FROM clientes " +
                "WHERE (cli_rut LIKE '%" + txtbusca.Text + "%' OR cli_nomb LIKE '%" + txtbusca.Text + "%')   ORDER BY cli_nomb  ")
            ElseIf cliente = "NO" Then
                DataGridView1.DataSource = New Funciones().ListarTablasSQL("SELECT cli_rut, cli_nomb FROM clientes " +
                "WHERE cli_codvig='0' AND (cli_rut LIKE '%" + txtbusca.Text + "%' OR cli_nomb LIKE '%" + txtbusca.Text + "%')   ORDER BY cli_nomb  ")
            End If



        Else
            If cliente = "SI" Then
                DataGridView1.DataSource = New Funciones().ListarTablasSQL("SELECT cli_rut, cli_nomb FROM clientes " +
                "WHERE (cli_rut LIKE '%" + txtbusca.Text + "%' OR cli_nomb LIKE '%" + txtbusca.Text + "%') and cli_estado ='A' ORDER BY cli_nomb  ")
            ElseIf cliente = "NO" Then
                DataGridView1.DataSource = New Funciones().ListarTablasSQL("SELECT cli_rut, cli_nomb FROM clientes " +
                "WHERE cli_codvig='0' AND (cli_rut LIKE '%" + txtbusca.Text + "%' OR cli_nomb LIKE '%" + txtbusca.Text + "%') and cli_estado ='A' ORDER BY cli_nomb  ")
            End If


        End If


    End Sub

    Private Sub DataGridView1_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyUp
        txtbusca.Focus()
        txtbusca.Text = ChrW(e.KeyValue)
        txtbusca.Select(txtbusca.Text.Length, 0)
    End Sub
End Class
Public Class Frm_cuadraturaFichasDetalles

    Dim fnc As New Funciones

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        'VG_CUADRATURA_TOTAL_REC_DES
        Me.DgvResultado.DataSource = fnc.ListarTablasSQL("select cli_nomb AS CLIENTE ,REC_PALL AS PALLET_REC, REC_CAJ AS CAJAS_REC,DES_PALLET AS PALLET_DES,DES_CAJ AS CAJAS_DES,STOCK_PALLET ,STOCK_CAJ from VG_CUADRATURA_TOTAL_REC_DES ")
        pintagrilla()

    End Sub
    Private Sub pintagrilla()
        For i As Integer = 0 To DgvResultado.Rows.Count - 1
            Dim sql As String = "Select * from vg_control_predespachos where cli_nomb='" + Me.DgvResultado.Rows(i).Cells(0).Value.ToString() + "'"
            Dim tabla As DataTable = fnc.ListarTablasSQL(sql)
            If tabla.Rows.Count > 0 Then
                '      MsgBox("paso ")


                Me.DgvResultado.Rows(i).Cells(0).Style.BackColor = Color.Red
                Me.DgvResultado.Rows(i).Cells(1).Style.BackColor = Color.Red
                Me.DgvResultado.Rows(i).Cells(2).Style.BackColor = Color.Red
                Me.DgvResultado.Rows(i).Cells(3).Style.BackColor = Color.Red
                Me.DgvResultado.Rows(i).Cells(4).Style.BackColor = Color.Red
                Me.DgvResultado.Rows(i).Cells(5).Style.BackColor = Color.Red
                Me.DgvResultado.Rows(i).Cells(6).Style.BackColor = Color.Red
                Me.DgvResultado.Rows(i).Cells(0).Style.ForeColor = Color.White
                Me.DgvResultado.Rows(i).Cells(1).Style.ForeColor = Color.White
                Me.DgvResultado.Rows(i).Cells(2).Style.ForeColor = Color.White
                Me.DgvResultado.Rows(i).Cells(3).Style.ForeColor = Color.White
                Me.DgvResultado.Rows(i).Cells(4).Style.ForeColor = Color.White
                Me.DgvResultado.Rows(i).Cells(5).Style.ForeColor = Color.White
                Me.DgvResultado.Rows(i).Cells(6).Style.ForeColor = Color.White



            End If
        Next
    End Sub

    Private Sub DgvResultado_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvResultado.CellClick
        'Dim sql As String = "Select * from vg_control_predespachos where cli_nomb='" + Me.DgvResultado.Rows(e.RowIndex).Cells(0).Value.ToString() + "'"


        'Dim tabla As DataTable = fnc.ListarTablasSQL(sql)
        'If tabla.Rows.Count > 0 Then
        If e.RowIndex > 0 Then


            Me.DataGridView1.DataSource = fnc.ListarTablasSQL("Select Cli_rut as RUT_CLI,cli_nomb as CLIENTE, fpre_codi as PRE_DESPACHO from  vg_control_predespachos where cli_nomb='" + Me.DgvResultado.Rows(e.RowIndex).Cells(0).Value.ToString() + "'")
            'Else

        End If
    End Sub

    Private Sub Frm_cuadraturaFichasDetalles_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        f_Cuadratura = False

    End Sub

    Private Sub Frm_cuadraturaFichasDetalles_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Frm_Principal.buscavalor = ""
    End Sub

    Private Sub DgvResultado_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvResultado.CellContentClick

    End Sub
End Class
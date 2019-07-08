Public Class Frm_addRecepcionRecupera

    Dim fnc As New Funciones

    Private Sub Frm_addRecepcionRecupera_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Frm_addRecepcionRecupera_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim sql As String = "SELECT frec_codi, cli_nomb, cont_descr, frec_fecrec FROM tmpfichrece, clientes, contrato " +
            "WHERE cli_rut=frec_rutcli AND cont_codi=frec_contcli AND frec_usucre='" + Frm_Principal.InfoUsuario.Text + "' " +
            "AND frec_tablet='0'"
        DataGridView1.DataSource = fnc.ListarTablasSQL(sql)
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs)

        If e.RowIndex > -1 Then
            If e.ColumnIndex = 0 Then
                If MsgBox("Seguro de eliminar el archivo temporal de recepción", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbYes Then

                    Dim sqlEliminaTMP As String = "DELETE FROM TmpFichRece WHERE frec_codi='" + Me.DataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString() + "'"
                    fnc.MovimientoSQL(sqlEliminaTMP)

                    Dim sqlEliminaTMPDETA As String = "DELETE FROM TmpDetaRece WHERE frec_codi='" + Me.DataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString() + "'"
                    fnc.MovimientoSQL(sqlEliminaTMPDETA)

                    CancelaCorrelativo("006", Me.DataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString())
                    Frm_addRecepcionRecupera_Load(sender, e)

                End If
            End If
        End If

    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick, DataGridView1.CellClick
        If e.RowIndex > -1 Then
            Dim _formInterface As IForm = CType(Me.Owner, IForm)
            _formInterface.ChangeTextBoxText(DataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString())
            Me.Close()
        End If

    End Sub

End Class
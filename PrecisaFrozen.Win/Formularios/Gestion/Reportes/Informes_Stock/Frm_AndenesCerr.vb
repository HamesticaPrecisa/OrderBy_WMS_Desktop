Public Class Frm_AndenesCerr
    Dim fnc As New Funciones
    Private Sub Frm_AndenesCerr_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim sql As String = "SELECT cli_nomb as Cliente ,cho_nombre as Chofer,cl_fol as Folio,Anden,cl_rutcli as rut FROM VG_ANDENES_GRILLA where anden is not null"
        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)
        DgvResultado.DataSource = tabla


    End Sub

    Private Sub DgvResultado_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvResultado.CellDoubleClick
        txtcli.Text = ""
        txtcli2.Text = ""
        txtanden.Text = ""
        txtfolio.Text = ""
        txtusr.Text = ""
        obs.Text = ""


        If e.RowIndex > -1 AndAlso e.ColumnIndex <> 0 Then
            txtcli.Text = Me.DgvResultado.Rows(e.RowIndex).Cells(0).Value.ToString()
            txtcli2.Text = Me.DgvResultado.Rows(e.RowIndex).Cells(4).Value.ToString()
            txtanden.Text = Me.DgvResultado.Rows(e.RowIndex).Cells(3).Value.ToString()
            txtfolio.Text = Me.DgvResultado.Rows(e.RowIndex).Cells(2).Value.ToString()

            If txtcli.Text <> "" Then
                txtusr.Text = Frm_Principal.lblnombre.Text
            End If

        End If
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If txtfolio.Text <> "" Then
            If txtcli.Text <> "" Then

                Dim qry As String
                qry = "  INSERT INTO AndenesReg(folio,Anden,Cliente,tip_mov,fec_reg,usr_reg2,obs)"
                qry += " VALUES('" + txtfolio.Text + "','" + txtanden.Text + "','" + txtcli2.Text + "','CIERRE',getdate(),'" + txtusr.Text + "','" + obs.Text + "')"


                fnc.MovimientoSQL(qry)
                MsgBox("Grabación exitosa", MsgBoxStyle.Information, "Aviso")

            End If
        End If
    End Sub
End Class
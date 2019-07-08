Public Class Frm_AndenesAbrir
    Dim fnc As New Funciones
    Private Sub Frm_AndenesAbrir_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim sql As String = "SELECT cl_rutcli, cli_nomb,cho_nombre,cl_chorut,cl_fol,Anden FROM VG_ANDENES_GRILLA"
        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)
        DgvResultado.DataSource = tabla


        txtanden.DataSource = fnc.ListarTablasSQL("SELECT cam_codi, cam_descr FROM camaras WHERE cam_codi>='71' AND cam_codi<='80' ORDER BY cam_descr ASC")
        txtanden.ValueMember = "cam_codi"
        txtanden.DisplayMember = "cam_descr"

    End Sub

    Private Sub DgvResultado_CellContentDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvResultado.CellContentDoubleClick

    End Sub

    Private Sub DgvResultado_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvResultado.CellDoubleClick
        txtcli.Text = ""

        txtanden.Text = ""
        txtfolio.Text = ""
        txtusr.Text = ""
        obs.Text = ""


        If e.RowIndex > -1 AndAlso e.ColumnIndex <> 0 Then
            txtcli.Text = Me.DgvResultado.Rows(e.RowIndex).Cells(0).Value.ToString()

            ' txtanden.Text = Me.DgvResultado.Rows(e.RowIndex).Cells(3).Value.ToString()
            txtfolio.Text = Me.DgvResultado.Rows(e.RowIndex).Cells(4).Value.ToString()

            If txtcli.Text <> "" Then
                txtusr.Text = Frm_Principal.lblnombre.Text
            End If

        End If
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click

        Dim sql2 = "SELECT  * FROM AndenesReg WHERE folio='" + txtfolio.Text.Trim() + "'"

        Dim tabla2 As DataTable = fnc.ListarTablasSQL(sql2)

        If tabla2.Rows.Count > 0 Then

            MsgBox("Anden Ya se encuentra abierto ", MsgBoxStyle.Critical, "Aviso")
            Exit Sub

        End If

        Dim qry As String
        qry = "  INSERT INTO AndenesReg(folio,Anden,Cliente,tip_mov,fec_reg,usr_reg,obs)"
        qry += " VALUES('" + txtfolio.Text.Trim() + "','" + txtanden.Text.Trim() + "','" + txtcli.Text.Trim() + "','APERTURA',getdate(),'" + txtusr.Text.Trim() + "','" + obs.Text.Trim() + "')"


        fnc.MovimientoSQL(qry)
        MsgBox("Grabación exitosa", MsgBoxStyle.Information, "Aviso")

    End Sub
End Class
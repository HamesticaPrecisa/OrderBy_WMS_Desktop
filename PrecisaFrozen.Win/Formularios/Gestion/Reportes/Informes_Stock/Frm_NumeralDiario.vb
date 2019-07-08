Public Class FRM_NumeralDiario

    Dim fnc As New Funciones

    Private Sub FRM_NumeralDiario_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        txtCont.Text = "TODOS"
    End Sub

    Private Sub btnBusCli_Click(sender As System.Object, e As System.EventArgs) Handles btnBusCli.Click
        Lst_AyudaClientes.ShowDialog(Frm_Principal)
        If Frm_Principal.buscavalor.ToString <> "" Then
            txtCli.Text = RetornaCliente(Frm_Principal.buscavalor.ToString())
            lblCli.Text = Frm_Principal.buscavalor.ToString()
            Frm_Principal.buscavalor = ""
            btnBus.Enabled = True
        End If
    End Sub

    Private Sub btnNue_Click(sender As System.Object, e As System.EventArgs) Handles btnNue.Click
        limpiar()
    End Sub

    Sub limpiar()
        txtCli.Text = ""
        lblCli.Text = ""
        txtCont.Text = "TODOS"
        lblCont.Text = ""
        chkCont.Checked = True
        calFecIni.Text = Now.ToString("dd-MM-yyyy")
        btnBus.Enabled = False
        btnXls.Enabled = False

        Dim dt As New DataTable
        dt.Columns.Add("Fecha")
        dt.Columns.Add("Soportantes")
        dt.Columns.Add("Cajas")
        dt.Columns.Add("Peso")

        dgvNumDia.DataSource = dt
    End Sub

    Private Sub btnBusCont_Click(sender As System.Object, e As System.EventArgs) Handles btnBusCont.Click
        Dim frm As New Lst_AyudaContratos
        If txtCli.Text <> "" Then
            frm.condicion = "WHERE cont_rutclie='" + QuitarCaracteres(lblCli.Text) + "'"
        End If
        frm.ShowDialog(Frm_Principal)
        If Frm_Principal.buscavalor = "" Then
            chkCont.Checked = True
            Exit Sub
        End If
        txtCont.Text = RetornaContrato(Frm_Principal.buscavalor.ToString())
        lblCont.Text = Frm_Principal.buscavalor.ToString()
        Frm_Principal.buscavalor = ""
    End Sub

    Private Sub FRM_NumeralDiario_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        f_NumDia = False
    End Sub

    Private Sub chkCont_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkCont.CheckedChanged
        If chkCont.Checked = True Then
            txtCont.Text = "TODOS"
            btnBusCont.Enabled = False
        Else
            txtCont.Text = ""
            btnBusCont.Enabled = True
        End If
    End Sub

    Private Sub btnBus_Click(sender As System.Object, e As System.EventArgs) Handles btnBus.Click
        Try
            Dim Cli = lblCli.Text.Trim
            If (Cli = "") Then
                MessageBox.Show("Debe seleccionar un cliente.", "Información!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Dim Cont = lblCont.Text.Trim

            Dim FecIni = calFecIni.Text.Trim
            Dim FecIniAux = FecIni.Split("-")
            Dim FecIniFrm = FecIniAux(2) & FecIniAux(1) & FecIniAux(0)

            Dim FecFin = CalFecFin.Text.Trim
            Dim FecFinAux = FecFin.Split("-")
            Dim FecFinFrm = FecFinAux(2) & FecFinAux(1) & FecFinAux(0)

            Dim sql = "exec SP_Numeral_Diaro '" & Cli & "','" & Cont & "','" & FecIniFrm & "','" & FecFinFrm & "'"
            Dim dt As New DataTable
            dt = fnc.ListarTablasSQL(sql)

            If (dt.Rows.Count > 0) Then
                dgvNumDia.DataSource = dt

                btnXls.Enabled = True
            Else
                MessageBox.Show("No se encontro información asociada a este cliente o contrato.", "Información!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Ocurrio un error al buscar la información. Vuelva a intentar.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSal_Click(sender As System.Object, e As System.EventArgs) Handles btnSal.Click
        Me.Close()
    End Sub

    Private Sub btnXls_Click(sender As System.Object, e As System.EventArgs) Handles btnXls.Click
        If (dgvNumDia.RowCount > 0) Then
            Call GridAExcel(dgvNumDia)
        Else
            MessageBox.Show("No existe información para mostrar.", "Información!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
End Class
Public Class Frm_ListadoImpor

    Dim fnc As New Funciones

    Private Sub Frm_ListadoImpor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim sql As String = "SELECT pimp_codi, cli_nomb, pimp_codrece, pimp_fecha, pimp_totsopo, pimp_totunid, pimp_totpeso, pimp_reso " +
            "FROM proc_importaciones, clientes  WHERE pimp_rutcli=cli_rut ORDER BY pimp_codi DESC"
        DgvResultado.DataSource = fnc.ListarTablasSQL(sql)
    End Sub

    Private Sub CbT2Cliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CbT2Cliente.CheckedChanged
        If CbT2Cliente.Checked = True Then
            btn_BuscaCliente.Enabled = False
            txtclinom.Text = ""
            TxtClirut.Text = ""
        Else
            btn_BuscaCliente.Enabled = True
        End If
    End Sub

    Private Sub CbT2Fechas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CbT2Fechas.CheckedChanged
        If CbT2Fechas.Checked = True Then
            dtFinal.Enabled = False
            dtInicio.Enabled = False
        Else
            dtFinal.Enabled = True
            dtInicio.Enabled = True
        End If
    End Sub

    Private Sub btn_BuscaCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_BuscaCliente.Click
        Dim frm As New Lst_AyudaClientes
        frm.ShowDialog(Frm_Principal)
        Frm_Principal.buscavalor = Frm_Principal.buscavalor

        If Len(Frm_Principal.buscavalor) >= 9 Then
            TxtClirut.Text = Frm_Principal.buscavalor
            txtclinom.Text = RetornaCliente(Frm_Principal.buscavalor)
        End If
        Frm_Principal.buscavalor = ""
    End Sub

    Private Sub BtnAceptarFiltro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAceptarFiltro.Click
        If CbT2Cliente.Checked = True AndAlso CbT2Fechas.Checked = True Then
            MsgBox("Debe Agregar Un filtro ", MsgBoxStyle.Critical, "Aviso")
            Exit Sub
        End If

        Dim where As String = ""

        If CbT2Cliente.Checked = False AndAlso fnc.verificaExistencia("Clientes", "Cli_rut", TxtClirut.Text) = True Then
            where = where + " AND cli_rut='" + TxtClirut.Text + "' "
        End If

        If CbT2Fechas.Checked = False Then
            where = where + " AND pimp_fecha >='" + devuelve_fecha(dtInicio.Value) + "' AND pimp_fecha <='" + devuelve_fecha(dtFinal.Value) + "' "
        End If

        Dim sql As String = "SELECT pimp_codi, cli_nomb, pimp_fecha, pimp_totsopo, pimp_totunid, pimp_totpeso, pimp_reso " +
                            "FROM proc_importaciones, clientes  WHERE pimp_rutcli=cli_rut " + where + " ORDER BY pimp_codi DESC"
        DgvResultado.DataSource = fnc.ListarTablasSQL(sql)
    End Sub

    Private Sub BtnQuitarFiltro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnQuitarFiltro.Click
        Frm_ListadoImpor_Load(Nothing, Nothing)
        CbT2Cliente.Checked = True
        CbT2Fechas.Checked = True
    End Sub

    Private Sub DgvRecepciones_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvResultado.CellDoubleClick
        If e.RowIndex > -1 Then
            Dim _formInterface As IForm = CType(Me.Owner, IForm)
            _formInterface.ChangeTextBoxText(DgvResultado.Rows(e.RowIndex).Cells(0).Value.ToString())
            Me.Close()
        End If
    End Sub
End Class
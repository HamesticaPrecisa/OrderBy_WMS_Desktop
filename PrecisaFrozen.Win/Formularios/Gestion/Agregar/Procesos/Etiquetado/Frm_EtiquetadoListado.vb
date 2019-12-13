Public Class Frm_EtiquetadoListado

    Dim fnc As New Funciones

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

    Private Sub Frm_EtiquetadoListado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim sql As String = "SELECT ETIQ_CODI, cli_nomb, ETIQ_FECHA, ETIQ_TOTSOPO, ETIQ_TOTUNIDAD, ETIQ_TOTPESO FROM FICHETIQ   INNER JOIN clientes ON cli_rut=ETIQ_CLIRUT ORDER BY etiq_codi DESC"
        DgvResultado.DataSource = fnc.ListarTablasSQL(sql)
    End Sub

    Private Sub BtnQuitarFiltro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnQuitarFiltro.Click
        Dim sql As String = "SELECT ETIQ_CODI, cli_nomb, ETIQ_FECHA, ETIQ_TOTSOPO, ETIQ_TOTUNIDAD, ETIQ_TOTPESO FROM FICHETIQ   INNER JOIN clientes ON cli_rut=ETIQ_CLIRUT ORDER BY etiq_codi DESC"
        DgvResultado.DataSource = fnc.ListarTablasSQL(sql)
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
            where = where + " AND etiq_fecha >='" + devuelve_fecha(dtInicio.Value) + "' AND etiq_fecha <='" + devuelve_fecha(dtFinal.Value) + "' "
        End If

        Dim sql As String = "SELECT ETIQ_CODI, cli_nomb, ETIQ_FECHA, ETIQ_TOTSOPO, ETIQ_TOTUNIDAD, ETIQ_TOTPESO FROM FICHETIQ   INNER JOIN clientes ON cli_rut=ETIQ_CLIRUT " + where + " ORDER BY etiq_codi DESC"
        DgvResultado.DataSource = fnc.ListarTablasSQL(sql)
    End Sub

    Private Sub DgvResultado_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvResultado.CellDoubleClick
        If e.RowIndex > -1 Then
            Dim _formInterface As IForm = CType(Me.Owner, IForm)
            _formInterface.ChangeTextBoxText(DgvResultado.Rows(e.RowIndex).Cells(0).Value.ToString())
            Me.Close()
        End If
    End Sub

End Class
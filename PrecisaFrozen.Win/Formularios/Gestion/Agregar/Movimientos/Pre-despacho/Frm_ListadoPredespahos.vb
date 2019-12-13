Public Class Frm_ListadoPredespahos

    Dim fnc As New Funciones

    Private Sub Frm_ListadoPredespahos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If sucursalglo = "0" Then
            DgvPreDespachos.DataSource = fnc.ListarTablasSQL("SELECT TOP(100) fpre_codi, cli_nomb, fpre_fecdes, fpre_totsopo, " +
                                                    "fpre_totunidad, fpre_totpeso FROM fichpred, clientes WHERE cli_rut=fpre_rutcli " +
                                                    "ORDER BY fpre_codi DESC")
        Else
            DgvPreDespachos.DataSource = fnc.ListarTablasSQL("SELECT TOP(100) fpre_codi, cli_nomb, fpre_fecdes, fpre_totsopo, " +
                                                    "fpre_totunidad, fpre_totpeso FROM fichpred, clientes WHERE cli_rut=fpre_rutcli  and fichpred.cod_bod ='" + sucursalglo + "'" +
                                                    "ORDER BY fpre_codi DESC")


        End If
   
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If sucursalglo = "0" Then
            DgvPreDespachos.DataSource = fnc.ListarTablasSQL("SELECT fpre_codi, cli_nomb, fpre_fecdes, fpre_totsopo, " +
                                                           "fpre_totunidad, fpre_totpeso FROM fichpred, clientes WHERE cli_rut=fpre_rutcli " +
                                                           "ORDER BY fpre_codi DESC")
        Else
            DgvPreDespachos.DataSource = fnc.ListarTablasSQL("SELECT fpre_codi, cli_nomb, fpre_fecdes, fpre_totsopo, " +
                                                "fpre_totunidad, fpre_totpeso FROM fichpred, clientes WHERE cli_rut=fpre_rutcli and fichpred.cod_bod ='" + sucursalglo + "'" +
                                                "ORDER BY fpre_codi DESC")
        End If
    End Sub

    Private Sub DgvPreDespachos_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvPreDespachos.CellDoubleClick
        If e.RowIndex > -1 Then
            Dim _formInterface As IForm = CType(Me.Owner, IForm)

            _formInterface.ChangeTextBoxText(DgvPreDespachos.Rows(e.RowIndex).Cells(0).Value.ToString())

            Me.Close()
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
            where = where + " AND (fpre_fecdes >='" + devuelve_fecha(dtInicio.Value) + "' AND fpre_fecdes <='" + devuelve_fecha(dtFinal.Value) + "') "
        End If

        DgvPreDespachos.DataSource = fnc.ListarTablasSQL("SELECT fpre_codi, cli_nomb, fpre_fecdes, fpre_totsopo, " +
                                                        "fpre_totunidad, fpre_totpeso FROM fichpred, clientes WHERE cli_rut=fpre_rutcli " + where +
                                                        " ORDER BY fpre_codi DESC")

    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CbT2Cliente.CheckedChanged
        If CbT2Cliente.Checked = True Then
            btn_BuscaCliente.Enabled = False
            txtclinom.Text = ""
            TxtClirut.Text = ""
        Else
            btn_BuscaCliente.Enabled = True
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CbT2Fechas.CheckedChanged
        If CbT2Fechas.Checked = True Then
            dtFinal.Enabled = False
            dtInicio.Enabled = False
        Else
            dtFinal.Enabled = True
            dtInicio.Enabled = True
        End If
    End Sub

    Private Sub BtnQuitarFiltro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnQuitarFiltro.Click
        Frm_ListadoPredespahos_Load(Nothing, Nothing)
    End Sub
End Class
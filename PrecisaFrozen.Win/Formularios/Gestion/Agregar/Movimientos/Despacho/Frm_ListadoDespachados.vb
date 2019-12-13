Public Class Frm_ListadoDespachados

    Dim fnc As New Funciones

    Private Sub Frm_ListadoDespachados_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If sucursalglo = "0" Then
            Me.DgvDespachos.DataSource = fnc.ListarTablasSQL("SELECT TOP(100) fdes_codi, cli_nomb, Convert(datetime,fdes_fecha,111) as fdes_fecha, fdes_totsopo, fdes_totunidad, " +
                                                   "fdes_totpeso,fdes_codvig,vig_frm=case when fdes_codvig=0 then 'ACTIVO' else 'NULO' end FROM fichdespa, clientes WHERE cli_rut=fdes_rutcli and fdes_codvig<>'1' ORDER BY fdes_codi DESC")
        Else

            Me.DgvDespachos.DataSource = fnc.ListarTablasSQL("SELECT TOP(100) fdes_codi, cli_nomb, Convert(datetime,fdes_fecha,111) as fdes_fecha, fdes_totsopo, fdes_totunidad, " +
                                                   "fdes_totpeso,fdes_codvig,vig_frm=case when fdes_codvig=0 then 'ACTIVO' else 'NULO' end FROM fichdespa, clientes WHERE cli_rut=fdes_rutcli and fichdespa.cod_bod ='" + sucursalglo + "' and fdes_codvig<>'1' ORDER BY fdes_codi DESC")
        End If

        verificanulas()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If sucursalglo = "0" Then
            Me.DgvDespachos.DataSource = fnc.ListarTablasSQL("SELECT   fdes_codi, cli_nomb, fdes_fecha, fdes_totsopo, fdes_totunidad, " +
                                                    "fdes_totpeso,fdes_codvig,vig_frm=case when fdes_codvig=0 then 'ACTIVO' else 'NULO' end FROM fichdespa, clientes WHERE cli_rut=fdes_rutcli ORDER BY fdes_codi DESC")
        Else
            Me.DgvDespachos.DataSource = fnc.ListarTablasSQL("SELECT   fdes_codi, cli_nomb, fdes_fecha, fdes_totsopo, fdes_totunidad, " +
                                                    "fdes_totpeso,fdes_codvig,vig_frm=case when fdes_codvig=0 then 'ACTIVO' else 'NULO' end FROM fichdespa, clientes WHERE cli_rut=fdes_rutcli  and fichdespa.cod_bod ='" + sucursalglo + "' ORDER BY fdes_codi DESC")

        End If

        verificanulas()
    End Sub

    Private Sub DgvDespachos_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvDespachos.CellDoubleClick
        If e.RowIndex > -1 Then
            Dim _formInterface As IForm = CType(Me.Owner, IForm)

            _formInterface.ChangeTextBoxText(DgvDespachos.Rows(e.RowIndex).Cells(0).Value.ToString())

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
            where = where + " AND fdes_fecha >='" + devuelve_fecha(dtInicio.Value) + "' AND fdes_fecha <='" + devuelve_fecha(dtFinal.Value) + "' "
        End If

        Me.DgvDespachos.DataSource = fnc.ListarTablasSQL("SELECT fdes_codi, cli_nomb, fdes_fecha, fdes_totsopo, fdes_totunidad, " +
                                                           "fdes_totpeso,fdes_codvig,vig_frm=case when fdes_codvig=0 then 'ACTIVO' else 'NULO' end FROM fichdespa, clientes WHERE cli_rut=fdes_rutcli " + where + " ORDER BY fdes_codi DESC")

        verificanulas()
    End Sub

    Private Sub BtnQuitarFiltro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnQuitarFiltro.Click
        Frm_ListadoDespachados_Load(Nothing, Nothing)
        CbT2Cliente.Checked = True
        CbT2Fechas.Checked = True
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

    Sub verificanulas()

        For i = 0 To DgvDespachos.Rows.Count - 1

            If Convert.ToInt16(DgvDespachos.Rows(i).Cells(6).Value.ToString()) = 1 Then

                DgvDespachos.Rows(i).DefaultCellStyle.ForeColor = Color.Red
                DgvDespachos.Rows(i).Cells(6).Value = "1"
                DgvDespachos.Rows(i).Cells(7).Style.BackColor = Color.Red
                DgvDespachos.Rows(i).Cells(7).Style.ForeColor = Color.White
            Else
                DgvDespachos.Rows(i).Cells(7).Value = "ACTIVO"
            End If

            If DgvDespachos.Rows(i).Cells(6).Value.ToString() = "1" Then

                DgvDespachos.Rows(i).DefaultCellStyle.ForeColor = Color.Red
                DgvDespachos.Rows(i).Cells(7).Value = "NULO"
                DgvDespachos.Rows(i).Cells(7).Style.BackColor = Color.Red
                DgvDespachos.Rows(i).Cells(7).Style.ForeColor = Color.White
            Else
                DgvDespachos.Rows(i).Cells(7).Value = "ACTIVO"
            End If


        Next

    End Sub
End Class
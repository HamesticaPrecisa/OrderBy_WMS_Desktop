Public Class Frm_ListadoRecepcion

    Dim fnc As New Funciones


    Private Sub Frm_ListadoRecepciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim where As String = ""

        If CbT2Cliente.Checked = False AndAlso fnc.verificaExistencia("Clientes", "Cli_rut", TxtClirut.Text) = True Then
            where = where + " AND cli_rut='" + TxtClirut.Text + "' "
        End If

        If CbT2Fechas.Checked = False Then
            where = where + " AND frec_fecrec >='" + devuelve_fecha(dtInicio.Value) + "' AND frec_fecrec <='" + devuelve_fecha(dtFinal.Value) + "' "
        End If
        If sucursalglo = "0" Then
            DgvRecepciones.DataSource = fnc.ListarTablasSQL("SELECT frec_codi, cli_nomb, frec_fecrec, frec_totsopo, frec_totunidad, frec_totpeso, frec_codvig,cont_codi AS N,cont_descr as CONTRATO " +
                                                                   "FROM fichrece, clientes,contrato WHERE cli_rut=frec_rutcli and frec_contcli=cont_codi and fichrece.frec_codvig <>'1' and  " + where + " ORDER BY frec_codi DESC")
        Else
            Dim sql As String = "SELECT frec_codi, cli_nomb, frec_fecrec, frec_totsopo, frec_totunidad, frec_totpeso, frec_codvig,cont_codi AS N,cont_descr as CONTRATO FROM fichrece, clientes,contrato WHERE cli_rut=frec_rutcli and frec_contcli=cont_codi and fichrece.frec_codvig <>'1' and fichrece.cod_bod ='" + sucursalglo + "' " + where + " ORDER BY frec_codi DESC"
            DgvRecepciones.DataSource = fnc.ListarTablasSQL(sql)
        End If
       
        verificanulas()
    End Sub


    Private Sub DgvRecepciones_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvRecepciones.CellDoubleClick
        If e.RowIndex > -1 Then
            Dim _formInterface As IForm = CType(Me.Owner, IForm)

            _formInterface.ChangeTextBoxText(DgvRecepciones.Rows(e.RowIndex).Cells(0).Value.ToString())

            Me.Close()
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If sucursalglo = "0" Then
            DgvRecepciones.DataSource = fnc.ListarTablasSQL(" SELECT frec_codi, cli_nomb, frec_fecrec, frec_totsopo, frec_totunidad, frec_totpeso, frec_codvig ,cont_codi AS N,cont_descr as CONTRATO " +
                                                  " FROM fichrece, clientes,contrato WHERE cli_rut=frec_rutcli and frec_contcli=cont_codi ORDER BY frec_codi DESC")

        Else
            DgvRecepciones.DataSource = fnc.ListarTablasSQL(" SELECT frec_codi, cli_nomb, frec_fecrec, frec_totsopo, frec_totunidad, frec_totpeso, frec_codvig ,cont_codi AS N,cont_descr as CONTRATO " +
                                                  " FROM fichrece, clientes,contrato WHERE cli_rut=frec_rutcli and frec_contcli=cont_codi  and fichrece.cod_bod ='" + sucursalglo + "' ORDER BY frec_codi DESC")

        End If
   



        verificanulas()
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
            where = where + " AND frec_fecrec >='" + devuelve_fecha(dtInicio.Value) + "' AND frec_fecrec <='" + devuelve_fecha(dtFinal.Value) + "' "
        End If

        DgvRecepciones.DataSource = fnc.ListarTablasSQL("SELECT frec_codi, cli_nomb, frec_fecrec, frec_totsopo, frec_totunidad, frec_totpeso, frec_codvig,cont_codi AS N,cont_descr as CONTRATO " +
                                                        "FROM fichrece, clientes,contrato WHERE cli_rut=frec_rutcli and frec_contcli=cont_codi " + where + " ORDER BY frec_codi DESC")
        verificanulas()
    End Sub

    Private Sub BtnQuitarFiltro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnQuitarFiltro.Click
        Frm_ListadoRecepciones_Load(Nothing, Nothing)
        CbT2Cliente.Checked = True
        CbT2Fechas.Checked = True
    End Sub

    Sub verificanulas()

        For i = 0 To DgvRecepciones.Rows.Count - 1

            If Convert.ToInt16(DgvRecepciones.Rows(i).Cells(6).Value.ToString()) = 1 Then

                DgvRecepciones.Rows(i).DefaultCellStyle.ForeColor = Color.Red
                DgvRecepciones.Rows(i).Cells(6).Value = "NULA"
                DgvRecepciones.Rows(i).Cells(6).Style.BackColor = Color.Red
                DgvRecepciones.Rows(i).Cells(6).Style.ForeColor = Color.White
            Else
                DgvRecepciones.Rows(i).Cells(6).Value = "ACTIVA"
            End If
            If DgvRecepciones.Rows(i).Cells(6).Value.ToString() = "NULA" Then

                DgvRecepciones.Rows(i).DefaultCellStyle.ForeColor = Color.Red
                DgvRecepciones.Rows(i).Cells(6).Value = "NULA"
                DgvRecepciones.Rows(i).Cells(6).Style.BackColor = Color.Red
                DgvRecepciones.Rows(i).Cells(6).Style.ForeColor = Color.White
            Else
                DgvRecepciones.Rows(i).Cells(6).Value = "ACTIVA"
            End If


        Next

    End Sub

End Class
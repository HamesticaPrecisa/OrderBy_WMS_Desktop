Public Class Frm_ListadoVas

    Dim fnc As New Funciones
    Public tipo = 0

    Private Sub Frm_ListadoVas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If tipo = 0 Then
            Dim sql As String = "SELECT TOP(200) Vas_cod, cli_nomb, Vas_fecha, Vas_Dcto, Vas_guia, Sec_Desc " +
                                        "FROM FacVas INNER JOIN clientes ON cli_rut=Vas_Clirut INNER JOIN FacSeccion ON Sec_codi=Vas_Seccion WHERE Vas_Seccion<>'2' ORDER BY vas_cod DESC"
            DgvVas.DataSource = fnc.ListarTablasSQL(sql)
        Else
            Dim sql As String = "SELECT TOP(200) Vas_cod, cli_nomb, Vas_fecha, Vas_Dcto, Vas_guia, Sec_Desc " +
                            "FROM FacVas INNER JOIN clientes ON cli_rut=Vas_Clirut INNER JOIN FacSeccion ON Sec_codi=Vas_Seccion WHERE Vas_Seccion='" + (tipo + 1).ToString() + "' ORDER BY vas_cod DESC"
            DgvVas.DataSource = fnc.ListarTablasSQL(sql)
        End If

    End Sub

    Private Sub BtnTodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTodos.Click
        If tipo = 0 Then
            Dim sql As String = "SELECT Vas_cod, cli_nomb, Vas_fecha, Vas_Dcto, Vas_guia, Sec_Desc " +
                                        "FROM FacVas INNER JOIN clientes ON cli_rut=Vas_Clirut INNER JOIN FacSeccion ON Sec_codi=Vas_Seccion WHERE Vas_Seccion<>'2' ORDER BY vas_cod DESC"
            DgvVas.DataSource = fnc.ListarTablasSQL(sql)
        Else
            Dim sql As String = "SELECT Vas_cod, cli_nomb, Vas_fecha, Vas_Dcto, Vas_guia, Sec_Desc " +
                            "FROM FacVas INNER JOIN clientes ON cli_rut=Vas_Clirut INNER JOIN FacSeccion ON Sec_codi=Vas_Seccion WHERE Vas_Seccion='" + (tipo + 1).ToString() + "' ORDER BY vas_cod DESC"
            DgvVas.DataSource = fnc.ListarTablasSQL(sql)
        End If
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

    Private Sub BtnQuitarFiltro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnQuitarFiltro.Click
        Frm_ListadoVas_Load(Nothing, Nothing)
        CbT2Cliente.Checked = True
        CbT2Fechas.Checked = True
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
            where = where + " AND vas_fecha >='" + devuelve_fecha(dtInicio.Value) + "' AND vas_fecha <='" + devuelve_fecha(dtFinal.Value) + "' "
        End If

        If tipo = 0 Then
            DgvVas.DataSource = fnc.ListarTablasSQL("SELECT TOP(200) Vas_cod, cli_nomb, Vas_fecha, Vas_Dcto, Vas_guia, Sec_Desc " +
                                       "FROM FacVas INNER JOIN clientes ON cli_rut=Vas_Clirut INNER JOIN FacSeccion ON Sec_codi=facvas.Vas_Seccion WHERE Vas_Seccion<>'2' " + where + "  ORDER BY vas_cod DESC")
        Else
            DgvVas.DataSource = fnc.ListarTablasSQL("SELECT TOP(200) Vas_cod, cli_nomb, Vas_fecha, Vas_Dcto, Vas_guia, Sec_Desc " +
                               "FROM FacVas INNER JOIN clientes ON cli_rut=Vas_Clirut INNER JOIN FacSeccion ON Sec_codi=facvas.Vas_Seccion WHERE Vas_Seccion='" + (tipo + 1).ToString() + "' " + where + "  ORDER BY vas_cod DESC")
        End If
       
    End Sub

    Private Sub DgvVas_CellContentDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvVas.CellContentDoubleClick
        If e.RowIndex > -1 Then
            Dim _formInterface As IForm = CType(Me.Owner, IForm)

            _formInterface.ChangeTextBoxText(DgvVas.Rows(e.RowIndex).Cells(0).Value.ToString())

            Me.Close()
        End If
    End Sub
End Class
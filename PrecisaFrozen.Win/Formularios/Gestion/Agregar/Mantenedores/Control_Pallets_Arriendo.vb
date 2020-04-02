Public Class Control_Pallets_Arriendo

    Dim fnc As New Funciones
    Dim valorRecibido As String = ""

    Private Sub btn_BuscaCliente_Click(sender As System.Object, e As System.EventArgs) Handles btn_BuscaCliente.Click
        Dim frm As New Lst_AyudaClientes
        frm.ShowDialog(Frm_Principal)
        Me.valorRecibido = Frm_Principal.buscavalor

        If Len(valorRecibido) >= 9 Then

            Dim SqlBusca As String = "SELECT cli_nomb, cli_estado FROM clientes WHERE " +
                "cli_rut='" + valorRecibido + "'"

            Dim tabla As DataTable = fnc.ListarTablasSQL(SqlBusca)

            If tabla.Rows.Count > 0 Then
                If tabla.Rows(0)(1).ToString() = "N" Then
                    MsgBox("El cliente seleccionado se encuentra bloqueado", MsgBoxStyle.Critical, "Aviso")
                    Exit Sub
                End If

                TxtClirut.Text = valorRecibido
                txtclinom.Text = tabla.Rows(0)(0).ToString()
                Btn_BuscaContrato.Enabled = True
                Frm_Principal.buscavalor = ""

                txtcodcontrato.Text = ""
                txtnom_contrato.Text = ""
                TxtClirut.Enabled = False
            Else
                MsgBox("El rut ingresado no existe", MsgBoxStyle.Information, "Aviso")
            End If
        End If

        Frm_Principal.buscavalor = ""
    End Sub

    Private Sub Btn_BuscaContrato_Click(sender As System.Object, e As System.EventArgs) Handles Btn_BuscaContrato.Click
        Dim frm As New Lst_AyudaContratos
        frm.condicion = "WHERE  cont_rutclie='" + QuitarCaracteres(TxtClirut.Text) + "' AND cont_estado='0'"
        frm.ShowDialog(Frm_Principal)
        Me.valorRecibido = Frm_Principal.buscavalor

        Dim sql As String = "SELECT cont_descr, cont_tempcon, cont_tempgra, Hor_SRI, Hor_SRT, Hor_SDI, Hor_SDT, cont_bloqimp,cont_tipalm " +
            "FROM contrato, contratosHorarios WHERE cont_codi=Hor_Contcod AND cont_codi='" + valorRecibido.ToString() + "'"

        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

        If tabla.Rows.Count > 0 Then
            txtcodcontrato.Enabled = False
            txtcodcontrato.Text = valorRecibido.ToString
            txtnom_contrato.Text = tabla.Rows(0)(0).ToString()
        End If

        Frm_Principal.buscavalor = ""
    End Sub

    Private Sub Btn_buscasoportante_Click(sender As System.Object, e As System.EventArgs) Handles Btn_buscasoportante.Click
        Dim frm As New Lst_AyudaSoportantes
        frm.ShowDialog(Frm_Principal)
        txtsopcodi.Text = Frm_Principal.buscavalor
        Dim sql As String = "SELECT tsop_descr FROM tiposopo WHERE tsop_codi='" + txtsopcodi.Text + "'"

        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)
        If tabla.Rows.Count > 0 Then
            txtsopnombre.Text = tabla.Rows(0)(0)
            txtsopcodi.Enabled = False
        End If
        Frm_Principal.buscavalor = ""
    End Sub

    Sub limpiar()
        TxtClirut.Text = ""
        TxtClirut.Enabled = True
        btn_BuscaCliente.Enabled = True
        txtclinom.Text = ""
        txtclinom.Enabled = False
        txtcodcontrato.Text = ""
        txtcodcontrato.Enabled = True
        Btn_BuscaContrato.Enabled = True
        txtnom_contrato.Text = ""
        txtnom_contrato.Enabled = False
        txtsopcodi.Text = ""
        txtsopcodi.Enabled = True
        Btn_buscasoportante.Enabled = True
        txtsopnombre.Text = ""
        txtsopnombre.Enabled = False
        txtFec.Text = Now
        txtFecFin.Text = Now

        filtrar("1")

        btn_BuscaCliente.Focus()
    End Sub

    Private Sub btnLim_Click(sender As System.Object, e As System.EventArgs) Handles btnLim.Click
        limpiar()
    End Sub

    Private Sub btnSal_Click(sender As System.Object, e As System.EventArgs) Handles btnSal.Click
        Me.Close()
    End Sub

    Sub filtrar(Optional ByVal limpiar As String = "")
        Dim RutCli As String = TxtClirut.Text.Trim
        Dim CodCont As String = txtcodcontrato.Text.Trim
        Dim CodSopo As String = txtsopcodi.Text.Trim
        Dim FecIni As String = txtFec.Value.ToString("yyyyMMdd")
        Dim FecFin As String = txtFecFin.Value.ToString("yyyyMMdd")
        Dim Total As Integer = 0
        Dim sql As String = "select a.* from V_Control_Pallet_Arriendo a with(nolock) where a.Rut_Cliente like '%" & RutCli & "' and a.Codigo_Contrato like '%" & CodCont & "' and a.Codigo_Tipo_Soportante like'%" & CodSopo & "' and convert(date,a.Fecha_Inicio)>='" & FecIni & "' and (convert(date,a.Fecha_Termino)<='" & FecFin & "' or a.Fecha_Termino is null) order by a.Fecha_Inicio,a.Cliente,a.Contrato,a.Codigo_Soportante,a.Soportante asc"
        Dim dt As New DataTable

        dt = fnc.ListarTablasSQL(sql)

        If (dt.Rows.Count = 0 And limpiar = "") Then
            MsgBox("No se encontraton datos.", MsgBoxStyle.OkOnly, "Info")
        End If

        If (limpiar <> "") Then
            If (dt.Rows.Count = 0) Then
                gvMov.DataSource = dt
                Total = gvMov.RowCount
                TxtTotal.Text = Total
            Else
                Dim dtLim As New DataTable

                For i = 0 To dt.Columns.Count - 1
                    dtLim.Columns.Add(dt.Columns(i).ColumnName.ToString.Trim)
                Next

                gvMov.DataSource = dtLim
                Total = gvMov.RowCount
                TxtTotal.Text = Total
            End If
        Else
            gvMov.DataSource = dt
            Total = gvMov.RowCount
            TxtTotal.Text = Total
        End If
    End Sub

    Private Sub BtnTemp_Click(sender As System.Object, e As System.EventArgs) Handles BtnTemp.Click
        filtrar()
    End Sub

    Private Sub Control_Pallets_Arriendo_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        f_CtrPalletArr = False
    End Sub

    Private Sub btnImp_Click(sender As System.Object, e As System.EventArgs) Handles btnImp.Click
        If (gvMov.Rows.Count > 0) Then
            GridAExcel2(gvMov)
        Else
            MsgBox("No se encontraton datos.", MsgBoxStyle.OkOnly, "Info")
        End If
    End Sub
End Class
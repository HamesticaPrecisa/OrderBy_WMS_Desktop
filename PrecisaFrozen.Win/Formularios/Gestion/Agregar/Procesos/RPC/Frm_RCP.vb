Public Class Frm_Rcp

    Dim fnc As New Funciones

    Private Sub TxtGuiaPrecisa_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtGuiaPrecisa.KeyPress
        If e.KeyChar = ChrW(13) Then
            If TxtGuiaPrecisa.Text = "" Then
                MsgBox("Debe ingresar un codigo a buscar", MsgBoxStyle.Critical, "Aviso")
                Exit Sub
            End If

            Dim Valor As String = CerosAnteriorString(TxtGuiaPrecisa.Text, 7)

            If fnc.verificaExistencia("fichrece", "frec_codi", Valor) Then

                Dim sql As String = "SELECT frec_guiades, frec_rutcli, cli_nomb, frec_contcli, cont_descr, frec_fecrec,  frec_totsopo, frec_totunidad, frec_totpeso " +
                    "FROM fichrece INNER JOIN clientes ON cli_rut=frec_rutcli INNER JOIN contrato ON cont_codi=frec_contcli WHERE frec_codi='" + Valor + "'"

                Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

                If tabla.Rows.Count > 0 Then
                    TxtGuiaPrecisa.Text = Valor
                    TxtGuiaCliente.Text = tabla.Rows(0)(0).ToString()
                    TxtClirut.Text = tabla.Rows(0)(1).ToString()
                    txtclinom.Text = tabla.Rows(0)(2).ToString()
                    txtcodcontrato.Text = tabla.Rows(0)(3).ToString()
                    txtcontnom.Text = tabla.Rows(0)(4).ToString()
                    txtsoportantes.Text = tabla.Rows(0)(6).ToString()
                    txtcajas.Text = tabla.Rows(0)(7).ToString()
                    txtkilos.Text = tabla.Rows(0)(8).ToString()
                    TxtGuiaPrecisa.Enabled = False
                    TxtGuiaCliente.Enabled = False
                    BtnGuardar.Enabled = True
                    verificaRcpAct(tabla.Rows(0)(0).ToString())
                End If
            Else
                TxtGuiaPrecisa.Text = ""
                TxtGuiaCliente.Text = ""
                MsgBox("El codigo de guia ingresado no existe", MsgBoxStyle.Information, "Aviso")
            End If

        End If
    End Sub

    Private Sub TxtGuiaCliente_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtGuiaCliente.KeyPress
        If e.KeyChar = ChrW(13) Then
            If TxtGuiaCliente.Text = "" Then
                MsgBox("Debe ingresar un codigo a buscar", MsgBoxStyle.Critical, "Aviso")
                Exit Sub
            End If

            Dim Valor As String = TxtGuiaCliente.Text

            Dim sql As String = "SELECT frec_codi, frec_rutcli, cli_nomb, frec_contcli, cont_descr, frec_fecrec,  frec_totsopo, frec_totunidad, frec_totpeso " +
                "FROM fichrece INNER JOIN clientes ON cli_rut=frec_rutcli INNER JOIN contrato ON cont_codi=frec_contcli WHERE frec_guiades LIKE'%" + Valor + "%'"

            Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

            If tabla.Rows.Count = 1 Then

                TxtGuiaCliente.Text = Valor
                TxtGuiaPrecisa.Text = tabla.Rows(0)(0).ToString()
                TxtClirut.Text = tabla.Rows(0)(1).ToString()
                txtclinom.Text = tabla.Rows(0)(2).ToString()
                txtcodcontrato.Text = tabla.Rows(0)(3).ToString()
                txtcontnom.Text = tabla.Rows(0)(4).ToString()
                txtsoportantes.Text = tabla.Rows(0)(6).ToString()
                txtcajas.Text = tabla.Rows(0)(7).ToString()
                txtkilos.Text = tabla.Rows(0)(8).ToString()
                TxtGuiaPrecisa.Enabled = False
                TxtGuiaCliente.Enabled = False
                BtnGuardar.Enabled = True
                LlenaDetalle()
                verificaRcpAct(tabla.Rows(0)(0).ToString())
            ElseIf tabla.Rows.Count > 1 Then

                'Mas de un cliente 

                Dim sql_clientes As String = "SELECT frec_codi, cli_nomb, frec_guiades FROM clientes INNER JOIN fichrece ON cli_rut=frec_rutcli WHERE frec_guiades LIKE '%" + Valor + "%' "
                Dim tabla_clientes As DataTable = fnc.ListarTablasSQL(sql_clientes)

                If tabla_clientes.Rows.Count > 0 Then
                    DgvClientes.DataSource = tabla_clientes
                    Panel1.Visible = True

                End If
            Else
                TxtGuiaPrecisa.Text = ""
                TxtGuiaCliente.Text = ""
                MsgBox("El codigo de guia ingresado no existe", MsgBoxStyle.Information, "Aviso")
            End If


        End If

    End Sub

    Private Sub DgvClientes_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvClientes.CellDoubleClick
        If e.RowIndex > -1 Then

            Dim Valor As String = DgvClientes.Rows(e.RowIndex).Cells(0).Value.ToString()

            Dim sql As String = "SELECT frec_codi, frec_rutcli, cli_nomb, frec_contcli, cont_descr, frec_fecrec,  frec_totsopo, frec_totunidad, frec_totpeso " +
                "FROM fichrece INNER JOIN clientes ON cli_rut=frec_rutcli INNER JOIN contrato ON cont_codi=frec_contcli WHERE frec_codi ='" + Valor + "'"

            Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

            If tabla.Rows.Count = 1 Then
                TxtGuiaCliente.Text = DgvClientes.Rows(e.RowIndex).Cells(2).Value.ToString()
                TxtGuiaPrecisa.Text = tabla.Rows(0)(0).ToString()
                TxtClirut.Text = tabla.Rows(0)(1).ToString()
                txtclinom.Text = tabla.Rows(0)(2).ToString()
                txtcodcontrato.Text = tabla.Rows(0)(3).ToString()
                txtcontnom.Text = tabla.Rows(0)(4).ToString()
                txtsoportantes.Text = tabla.Rows(0)(6).ToString()
                txtcajas.Text = tabla.Rows(0)(7).ToString()
                txtkilos.Text = tabla.Rows(0)(8).ToString()
                TxtGuiaPrecisa.Enabled = False
                TxtGuiaCliente.Enabled = False
                LlenaDetalle()
                Panel1.Visible = False
                BtnGuardar.Enabled = True
                verificaRcpAct(tabla.Rows(0)(0).ToString())
            End If

        End If
    End Sub

    Sub LlenaDetalle()

        Dim sql As String = "SELECT drec_codi, drec_sopocli, mae_descr, drec_unidades, drec_peso " +
                            "FROM detarece INNER JOIN maeprod ON mae_codi=drec_codpro WHERE LEFT(drec_codi,7)='" + TxtGuiaPrecisa.Text + "'"
        DataGridView1.DataSource = fnc.ListarTablasSQL(sql)

    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Close()
    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If TxtRcp.Text.Length > 4 Then
            If MsgBox("Seguro de finalizar el ingreso", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbYes Then
                Dim sql As String = "UPDATE detarece SET drec_codsag='" + TxtRcp.Text + "' WHERE LEFT(drec_codi,7)='" + TxtGuiaPrecisa.Text + "'"

                If fnc.MovimientoSQL(sql) > 0 Then
                    MsgBox("Información agregada correctamente", MsgBoxStyle.Information, "Aviso")

                    If fnc.verificaExistencia("LOG_RCP", "LRCP_CODI", TxtGuiaPrecisa.Text) = False Then
                        Dim LOG As String = "INSERT  INTO LOG_RCP(LRCP_CODI, LRCP_FECHA, LRCP_HORA, LRCP_USUARIO, LRCP_PC, LRCP_CODSAG)" +
                                            "VALUES('" + TxtGuiaPrecisa.Text + "' ,'" + devuelve_fecha(fnc.DevuelveFechaServidor()) + "' ," +
                                            "'" + DevuelveHora() + "' , '" + Frm_Principal.InfoUsuario.Text + "','" + My.Computer.Name + "','" + TxtRcp.Text + "')"
                        fnc.MovimientoSQL(LOG)
                        BtnGuardar.Enabled = False
                        TxtRcp.Enabled = False
                    Else
                        Dim LOG As String = "UPDATE LOG_RCP SET LRCP_FECHA='" + devuelve_fecha(fnc.DevuelveFechaServidor()) + "', " +
                                            "LRCP_HORA='" + DevuelveHora() + "', LRCP_USUARIO='" + Frm_Principal.InfoUsuario.Text + "', " +
                                            "LRCP_PC='" + My.Computer.Name + "', LRCP_CODSAG='" + TxtRcp.Text + "' WHERE LRCP_CODI='" + TxtGuiaPrecisa.Text + "'"

                        fnc.MovimientoSQL(LOG)
                        BtnGuardar.Enabled = False
                        TxtRcp.Enabled = False
                    End If

                Else
                    MsgBox("Error al ingresar el certificado", MsgBoxStyle.Critical, "Aviso")
                End If

            End If
        Else
            MsgBox("El numero ingresado no corresponde", MsgBoxStyle.Critical, "Aviso")
        End If


    End Sub

    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        Dim f As New Frm_ListadoRCP
        f.ShowDialog(Frm_Principal)
        If Not Frm_Principal.buscavalor.ToString = "" Then
            Dim sql As String = "SELECT frec_codi, frec_rutcli, cli_nomb, frec_contcli, cont_descr, frec_fecrec,  frec_totsopo, frec_totunidad, frec_totpeso " +
           "FROM fichrece INNER JOIN clientes ON cli_rut=frec_rutcli INNER JOIN contrato ON cont_codi=frec_contcli WHERE frec_CODI ='" + Frm_Principal.buscavalor.ToString + "'"

            Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

            If tabla.Rows.Count = 1 Then

                TxtGuiaCliente.Text = Frm_Principal.buscavalor.ToString
                TxtGuiaPrecisa.Text = tabla.Rows(0)(0).ToString()
                TxtClirut.Text = tabla.Rows(0)(1).ToString()
                txtclinom.Text = tabla.Rows(0)(2).ToString()
                txtcodcontrato.Text = tabla.Rows(0)(3).ToString()
                txtcontnom.Text = tabla.Rows(0)(4).ToString()
                txtsoportantes.Text = tabla.Rows(0)(6).ToString()
                txtcajas.Text = tabla.Rows(0)(7).ToString()
                txtkilos.Text = tabla.Rows(0)(8).ToString()
                TxtGuiaPrecisa.Enabled = False
                TxtGuiaCliente.Enabled = False
                LlenaDetalle()
                BtnGuardar.Enabled = True
                verificaRcpAct(tabla.Rows(0)(0).ToString())
            End If

        End If
    End Sub

    Sub verificaRcpAct(ByVal cod_guia As String)

        Dim sql As String = "SELECT LRCP_CODSAG FROM LOG_RCP WHERE LRCP_CODI='" + cod_guia + "'"
        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)
        If tabla.Rows.Count > 0 Then
            TxtRcp.Text = tabla.Rows(0)(0).ToString()
            TxtRcp.Enabled = False
            BtnGuardar.Enabled = False
        End If

    End Sub

    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        If Panel1.Visible = True Then
            Panel1.Visible = False
            For i As Integer = 0 To DgvClientes.Rows.Count - 1
                DgvClientes.Rows.RemoveAt(0)
            Next
        End If

        TxtGuiaCliente.Text = ""
        TxtGuiaPrecisa.Text = ""
        TxtGuiaCliente.Enabled = True
        TxtGuiaPrecisa.Enabled = True
        TxtClirut.Text = ""
        txtclinom.Text = ""
        txtcontnom.Text = ""
        txtcodcontrato.Text = ""
        TxtRcp.Enabled = True
        TxtGuiaCliente.Focus()
        TxtRcp.Text = ""

        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            DataGridView1.Rows.RemoveAt(0)
        Next

    End Sub

    Private Sub BtnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImprimir.Click
        If TxtGuiaPrecisa.Enabled = True AndAlso TxtRcp.Enabled = True Then
            MsgBox("Debe guardar el formulario antes de imprimirlo", MsgBoxStyle.Critical, "Aviso")
        Else

            Dim frm As Frm_MuestraReporte = New Frm_MuestraReporte
            frm.Text = "Asistente de informes - Informe de RCP"

            Dim report As New Rpt_Rcp

            report.SetDatabaseLogon(Usuario_ODBC, Pass_ODBC)
            report.SetParameterValue("codigo", TxtGuiaCliente.Text)

            frm.Contenedor.ReportSource = report
            frm.ShowDialog()

        End If
    End Sub

    Private Sub Frm_Rcp_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F2 Then
            If MsgBox("Desea modificar el numero de RCP?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Aviso") = vbYes Then
                TxtRcp.Enabled = True
                BtnGuardar.Enabled = True
            End If

        End If
    End Sub

    Private Sub Frm_Rcp_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        f_rcp = False
    End Sub
End Class
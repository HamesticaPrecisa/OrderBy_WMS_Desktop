Imports System.Threading
Imports System.Data.SqlClient
Public Class Frm_GuiasPendTunel

    Dim fnc As New Funciones
    Dim thread As Thread
    Dim permRecargoTunel As Boolean = False

#Region "Cliente"


    Private Sub Btn_cliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_cliente.Click
        Lst_AyudaClientes.ShowDialog(Frm_Principal)
        If Frm_Principal.buscavalor.ToString <> "" Then
            Txtcliente.Text = RetornaCliente(Frm_Principal.buscavalor.ToString())
            LblCliente.Text = Frm_Principal.buscavalor.ToString()
            Frm_Principal.buscavalor = ""
        End If
    End Sub

#End Region

#Region "Producto"

    Private Sub T2producto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T2producto.CheckedChanged
        If T2producto.Checked = True Then
            TxtProducto.Text = "TODOS"
            Btn_Producto.Enabled = False
        Else
            TxtProducto.Text = ""
            Btn_Producto.Enabled = True
        End If
    End Sub

    Private Sub Btn_Producto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Producto.Click

        Dim frm As New Lst_AyudaProductos

        frm.ShowDialog(Frm_Principal)
        If Frm_Principal.buscavalor = "" Then
            T2producto.Checked = True
            Exit Sub
        End If

        LblProducto.Text = Frm_Principal.buscavalor.ToString()
        TxtProducto.Text = RetornaProducto(Frm_Principal.buscavalor.ToString())

    End Sub

#End Region


    Private Sub Frm_GuiasPendTunel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Frm_Principal.buscavalor = ""
        Btn_Calcular.Enabled = True
        lblLastUpd.Text = ""

        Dim permisos As DataTable = fnc.ListarTablasSQL("SELECT Spriv_Id, Spriv_PrivId " +
                                                        "  FROM UsuariosFunciones AS uf ,PrivilegiosSubSeccion AS us , Usuarios " +
                                                        " WHERE uf.Usu_Rut = Usuarios.usu_rut " +
                                                        "   AND uf.Usu_SprivId = us.Spriv_Id  " +
                                                        "   AND usu_codigo = @p0" +
                                                        "   AND us.spriv_id IN ('907')",
                                                        New SqlParameter() {
                                                            New SqlParameter("@p0", Frm_Principal.InfoUsuario.Text)
                                                        })
        For Each row As DataRow In permisos.Rows
            If row("spriv_id").ToString() = "907" Then
                permRecargoTunel = True
            End If
        Next

        DgvResultado.Columns(10).ReadOnly = (permRecargoTunel = False)

        Procesa()
        Btn_Calcular.Enabled = False
        btn_nuevo.Enabled = True
        Timer1.Enabled = True

    End Sub


    Private Sub Btn_Calcular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Calcular.Click
        CheckForIllegalCrossThreadCalls = False
        thread = New Thread(AddressOf Procesa)
        'Iniciamos el subproceso.
        thread.Start()
        Me.Btn_Calcular.Enabled = False
        Me.GroupBox1.Enabled = False
        Timer1.Enabled = True
    End Sub

    Sub Procesa()
        Dim WhereR As String = ""
        Dim WhereD As String = ""


        If T2producto.Checked = False Then
            If TxtProducto.Text = "" Then
                T2producto.Checked = True
            Else
                'WhereR = WhereR + "AND drec_codpro='" + LblProducto.Text + "' AND detarece.cod_bod='" + sucursalglo.Trim() + "' "
                'WhereD = WhereD + "AND ddes_codpro='" + LblProducto.Text + "' AND detadespa.cod_bod='" + sucursalglo.Trim() + "' "
            End If

        End If

        Dim sql As String = "SELECT frec_codi, cli_nomb, frec_fecrec, drec_fecprod, mer_nombre, numpallets, kilos, cajas, hpt, het" +
                            "  FROM vwGuiasPendTunel "
        If LblCliente.Text.Trim().Length > 0 Then
            WhereR = "frec_rutcli = @frec_rutcli"
        End If
        If T2producto.Checked = False And LblProducto.Text.Trim().Length > 0 Then
            WhereR = WhereR + IIf(WhereR.Length > 0, " AND ", "") +
                              " frec_codi IN (SELECT a.frec_codi1 " +
                              "                 FROM detarece a " +
                              "                INNER JOIN vwGuiasPendTunel b ON b.frec_codi = a.frec_codi1" +
                              "                WHERE a.drec_codpro = @drec_codpro)"
        End If
        If WhereR.Length > 0 Then sql = sql + " WHERE " + WhereR
        sql = sql + " ORDER BY hpt ASC, kilos DESC"

        Dim tabla As DataTable = fnc.ListarTablasSQL(sql, New SqlParameter() {
                                                        New SqlParameter("@frec_rutcli", LblCliente.Text.Trim()),
                                                        New SqlParameter("@drec_codpro", LblProducto.Text.Trim())
                                                     })

        'DgvResultado.DataSource = tabla
        ProgressBar1.Value = 0
        ProgressBar1.Maximum = tabla.Rows.Count
        For Each row As DataRow In tabla.Rows
            DgvResultado.Rows.Add(row(0), row(1), row(2), row(3), row(4), row(5), row(6), row(7), row(8), row(9))
            ProgressBar1.Increment(1)
        Next

        Threading.Thread.Sleep(1000)
        ProgressBar1.Value = 0
        DgvResultado.ReadOnly = False
        btn_nuevo.Enabled = True
        btn_Imprimir.Enabled = True
        lblLastUpd.Text = "Actualizado al " + DateTime.Now.ToString()
    End Sub


    Private Sub btn_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        LimpiarForm()
    End Sub

    Private Sub LimpiarForm()
        btn_nuevo.Enabled = False
        Txtcliente.Text = ""
        TxtProducto.Text = ""
        btn_Imprimir.Enabled = False
        Me.GroupBox1.Enabled = True
        For i As Integer = 0 To DgvResultado.RowCount - 1
            DgvResultado.Rows.RemoveAt(0)
        Next
        Btn_Calcular.Enabled = True
        Timer1.Enabled = False
    End Sub

    Private Sub btn_Imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Imprimir.Click
        If DgvResultado.Rows.Count = 0 Then
            MsgBox("No existe información para mostrar", MsgBoxStyle.Critical, "Aviso")
            Exit Sub
        End If


        Dim tabla As DataTable = DgvResultado.DataSource
        documentoimp = DateTime.Now.ToString("MM-dd-yy") + "GUIASPARATUNEL"
        Dim frm As Frm_MuestraReporte = New Frm_MuestraReporte
        Dim report As New Rpt_GuiasPendTunel

        Dim Ds As New Ds_GuiasPendTunel

        For Each row As DataGridViewRow In DgvResultado.Rows
            Ds.Dt_GuiasPendTunel.AddDt_GuiasPendTunelRow(row.Cells(0).Value.ToString(),
                                         row.Cells(1).Value.ToString(),
                                         row.Cells(4).Value.ToString(),
                                         row.Cells(5).Value.ToString(),
                                         row.Cells(6).Value.ToString(),
                                         row.Cells(7).Value.ToString(),
                                         row.Cells(2).Value.ToString(),
                                         row.Cells(9).Value.ToString())
        Next
        Dim crt As New Rpt_GuiasPendTunel()
        crt.SetDataSource(Ds)
        crt.SetParameterValue("CLIENTE", IIf(Txtcliente.Text.Trim().Length = 0, "TODOS", Txtcliente.Text))
        crt.SetParameterValue("PRODUCTO", TxtProducto.Text)

        frm.Contenedor.ReportSource = crt
        frm.ShowDialog()
    End Sub

    Private Sub Frm_GuiasPendTunel_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        f_guiasPendTunel = False
        Timer1.Enabled = False
    End Sub

    Private Sub Btn_Salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Salir.Click
        Close()
    End Sub


    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click

    End Sub

    Private Sub Label8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label8.Click

    End Sub

    Private Sub Label9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label9.Click

    End Sub

    Private Sub DgvResultado_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DgvResultado.DoubleClick

    End Sub

    Private Sub DgvResultado_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvResultado.CellContentClick
        Dim rowindex As Integer = e.RowIndex
        Dim colindex As Integer = e.ColumnIndex
        DgvResultado.CommitEdit(DataGridViewDataErrorContexts.Commit)
        Dim guia As String = DgvResultado.CurrentRow.Cells(0).Value
        Dim value As Object = DgvResultado.CurrentRow.Cells(colindex).Value
        fnc.MovimientoSQL("UPDATE fichrece SET frec_rtun=@value WHERE frec_codi=@guia",
                          New SqlParameter() {
                              New SqlParameter("@value", value),
                              New SqlParameter("@guia", guia)
                          })

        fnc.MovimientoSQL("INSERT INTO LOG_FICHRECE_DETALLE (" +
                          "        [Fecha],[Usuario],[frec_unica],[frec_codi],[frec_rutcli],[frec_rutproductor],[frec_contcli]," +
                          "        [frec_horalleg],[frec_horarec],[frec_horater],[frec_turnrec],[frec_fecproc],[frec_fecrec]," +
                          "		   [frec_fecter],[frec_guiades],[frec_tipentr],[frec_totsopo],[frec_totunidad],[frec_totpeso]," +
                          "	       [frec_temppro],[frec_rutcond],[frec_observ],[frec_tipdesc],[frec_codienca],[frec_origen]," +
                          "	       [frec_codvig],[frec_radio],[frec_tipo],[frec_RecepTunel],[frec_AspectoSanitario],[frec_CondGeneral]," +
                          "	       [frec_procedencia],[frec_paso],[frec_antecamara],[frec_numSello],[frec_termografo],[frec_tiporecepcion]," +
                          "	       [frec_observ2],[frec_tipoalmacenamiento],[frec_contenedor],[frec_patente],[frec_almac]," +
                          "	       [frec_empresa],[frec_olores],[frec_higiene],[frec_estiba],[frec_dañado],[frec_TS],[frec_TM]," +
                          "	       [frec_TI],[frec_clfol],[frec_Enviada],[frec_tablet],[frec_traq],[frec_emis],[frec_packinglist]," +
                          "	       [frec_ntunel],[frec_modificado],[cod_bod],[val_guia],[uni_guia],[kilos_guia],[frec_tippro]," +
                          "	       [frec_orirec],[frec_serv],[mer_id],[frec_rtun]) " +
                          " SELECT " +
                          "        GETDATE(),@p0,[frec_unica],[frec_codi],[frec_rutcli],[frec_rutproductor],[frec_contcli]," +
                          "        [frec_horalleg],[frec_horarec],[frec_horater],[frec_turnrec],[frec_fecproc],[frec_fecrec]," +
                          "	       [frec_fecter],[frec_guiades],[frec_tipentr],[frec_totsopo],[frec_totunidad],[frec_totpeso]," +
                          "	       [frec_temppro],[frec_rutcond],[frec_observ],[frec_tipdesc],[frec_codienca],[frec_origen]," +
                          "	       [frec_codvig],[frec_radio],[frec_tipo],[frec_RecepTunel],[frec_AspectoSanitario],[frec_CondGeneral]," +
                          "	       [frec_procedencia],[frec_paso],[frec_antecamara],[frec_numSello],[frec_termografo],[frec_tiporecepcion]," +
                          "	       [frec_observ2],[frec_tipoalmacenamiento],[frec_contenedor],[frec_patente],[frec_almac]," +
                          "	       [frec_empresa],[frec_olores],[frec_higiene],[frec_estiba],[frec_dañado],[frec_TS],[frec_TM]," +
                          "	       [frec_TI],[frec_clfol],[frec_Enviada],[frec_tablet],[frec_traq],[frec_emis],[frec_packinglist]," +
                          "	       [frec_ntunel],[frec_modificado],[cod_bod],[val_guia],[uni_guia],[kilos_guia],[frec_tippro]," +
                          "	       [frec_orirec],[frec_serv],[mer_id],[frec_rtun] " +
                          "  FROM fichrece" +
                          " WHERE frec_codi = @p1",
                          New SqlParameter() {
                              New SqlParameter("@p0", Frm_Principal.InfoUsuario.Text),
                              New SqlParameter("@p1", guia)
                          })
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        LimpiarForm()
        Procesa()
        Timer1.Enabled = True
    End Sub


End Class
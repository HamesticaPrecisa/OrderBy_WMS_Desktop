Imports CrystalDecisions.Shared

Public Class Rpt_StockDetallado

    Dim fnc As New Funciones
    Dim CODIGOBOD As String = ""

#Region "Cliente"


    Private Sub Btn_cliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_cliente.Click
        Lst_AyudaClientes.ShowDialog(Frm_Principal)
        If Frm_Principal.buscavalor.ToString <> "" Then
            Txtcliente.Text = RetornaCliente(Frm_Principal.buscavalor.ToString())
            LblCliente.Text = Frm_Principal.buscavalor.ToString()
            t2contrato.Enabled = True
        End If
    End Sub

#End Region

#Region "Contrato"

    Private Sub t2contrato_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles t2contrato.CheckedChanged
        If t2contrato.Checked = True Then
            TxtContrato.Text = "TODOS"
            Btn_Contrato.Enabled = False
        Else
            TxtContrato.Text = ""
            Btn_Contrato.Enabled = True
        End If
    End Sub

    Private Sub Btn_Contrato_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Contrato.Click
        Dim frm As New Lst_AyudaContratos
        If Txtcliente.Text <> "" Then
            frm.condicion = "WHERE cont_rutclie='" + QuitarCaracteres(LblCliente.Text) + "'"
        End If
        frm.ShowDialog(Frm_Principal)
        If Frm_Principal.buscavalor = "" Then
            t2contrato.Checked = True
            Exit Sub
        End If
        TxtContrato.Text = RetornaContrato(Frm_Principal.buscavalor.ToString())
        LblContrato.Text = Frm_Principal.buscavalor.ToString()
        Frm_Principal.buscavalor = ""
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
        If fnc.verificaExistencia("clientes", "Cli_rut", LblCliente.Text) = True Then
            frm.Condicion = "mae_clirut='" + QuitarCaracteres(LblCliente.Text) + "' "
        End If

        frm.ShowDialog(Frm_Principal)
        If Frm_Principal.buscavalor = "" Then
            T2producto.Checked = True
            Exit Sub
        End If

        LblProducto.Text = Frm_Principal.buscavalor.ToString()
        TxtProducto.Text = RetornaProducto(Frm_Principal.buscavalor.ToString())
        t2envase.Enabled = True
    End Sub

#End Region

#Region "Certificado Sag"

    Private Sub t2certsag_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles t2certsag.CheckedChanged
        If t2certsag.Checked = True Then
            Txtcertsag.Text = "TODOS"
            Txtcertsag.Enabled = False
        Else
            Txtcertsag.Text = ""
            Txtcertsag.Enabled = True
        End If
    End Sub

#End Region

#Region "Envase"
    Private Sub t2envase_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles t2envase.CheckedChanged
        If t2envase.Checked = True Then
            Txtenvase.Text = "TODOS"
            Btn_Envase.Enabled = False
        Else
            Txtenvase.Text = ""
            Btn_Envase.Enabled = True
        End If
    End Sub

    Private Sub Btn_Envase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Envase.Click
        Dim frm As New Lst_AyudaEnvases
        frm.ShowDialog(Frm_Principal)

        If Frm_Principal.buscavalor <> "" Then
            Lblenv.Text = Frm_Principal.buscavalor.ToString()
            Txtenvase.Text = RetornaEnvase(Frm_Principal.buscavalor.ToString())
            Frm_Principal.buscavalor = ""
        Else
            t2envase.Checked = True
        End If
    End Sub
#End Region

#Region "Fechas"

    Private Sub Btn_fecprod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_fecprod.Click
        Frm_Calendario.ShowDialog(Frm_Principal)
        If IsDate(Frm_Principal.buscavalor) Then
            TxtFechaProd.Text = Frm_Principal.buscavalor.ToString()
            Frm_Principal.buscavalor = ""
        Else
            TxtFechaProd.Text = ""
            t2fproduccion.Checked = True
        End If
    End Sub

    Private Sub t2fproduccion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles t2fproduccion.CheckedChanged
        If t2fproduccion.Checked = True Then
            Btn_fecprod.Enabled = False
            TxtFechaProd.Text = "TODOS"
        Else
            TxtFechaProd.Text = ""
            Btn_fecprod.Enabled = True
        End If
    End Sub


    Private Sub t2fecharece_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles t2fecharece.CheckedChanged
        If t2fecharece.Checked = True Then
            TxtFechaRece.Text = "TODOS"
            Btn_FecRec.Enabled = False
        Else
            TxtFechaRece.Text = ""
            Btn_FecRec.Enabled = True
        End If
    End Sub

    Private Sub Btn_FecRec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_FecRec.Click
        Frm_Calendario.ShowDialog(Frm_Principal)
        If IsDate(Frm_Principal.buscavalor) Then
            TxtFechaRece.Text = Frm_Principal.buscavalor.ToString()
            Frm_Principal.buscavalor = ""
        Else
            TxtFechaRece.Text = ""
            t2fecharece.Checked = True
        End If
    End Sub


    Private Sub t2fechavenc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T2fechavenc.CheckedChanged
        If T2fechavenc.Checked = True Then
            txtfechavenc.Text = "TODOS"
            Btn_FecVenc.Enabled = False
        Else
            txtfechavenc.Text = ""
            Btn_FecVenc.Enabled = True
        End If
    End Sub

    Private Sub Btn_FecVenc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_FecVenc.Click
        Frm_Calendario.ShowDialog(Frm_Principal)
        If IsDate(Frm_Principal.buscavalor) Then
            txtfechavenc.Text = Frm_Principal.buscavalor.ToString()
            Frm_Principal.buscavalor = ""
        Else
            txtfechavenc.Text = ""
            T2fechavenc.Checked = True
        End If
    End Sub

#End Region

#Region "Lote Cliente"

    Private Sub t2lotecli_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles t2lotecli.CheckedChanged
        If t2lotecli.Checked = True Then
            TxtLoteCliente.Text = "TODOS"
            TxtLoteCliente.Enabled = False
        Else
            TxtLoteCliente.Text = ""
            TxtLoteCliente.Enabled = True
        End If
    End Sub

#End Region


    Private Sub Btn_Salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Salir.Click
        Me.Close()
    End Sub

    Private Sub Rpt_StockClientePar_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        For Each c As CheckBox In Me.Panel1.Controls.OfType(Of CheckBox)()
            If TypeOf c Is CheckBox Then
                c.Checked = True
            End If
        Next
        f_detallado = False
    End Sub

    Private Sub Btn_Imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Imprimir.Click
        If Txtcliente.Text = "" Then
            MsgBox("Debe elegir un cliente para generar el informe", MsgBoxStyle.Critical, "Aviso")
            Exit Sub
        End If

        'Imprimir Stock
        documentoimp = DateTime.Now.ToString("MM-dd-yy") + "STOCKDETALLADO"

        Dim frm As Frm_MuestraReporte = New Frm_MuestraReporte
        frm.Text = "Asistente de informes - Informe de Stock Detallado"


        Dim report As New Rpt_StockCliente
        report.SetDatabaseLogon(Usuario_ODBC, Pass_ODBC)
        report.SetParameterValue("codigo", Retorna_Where())
        report.SetParameterValue("cl", Txtcliente.Text)
        report.SetParameterValue("co", TxtContrato.Text)
        report.SetParameterValue("pr", TxtProducto.Text)
        report.SetParameterValue("en", Txtenvase.Text)
        report.SetParameterValue("cs", Txtcertsag.Text)
        report.SetParameterValue("fp", TxtFechaProd.Text)
        report.SetParameterValue("fr", TxtFechaRece.Text)
        report.SetParameterValue("fv", txtfechavenc.Text)
        report.SetParameterValue("lc", TxtLoteCliente.Text)


        If cmbbodega.Text <> "TODOS" Then

            Dim sql As String = "SELECT cod_bodega from mae_bodega where des_bodega='" + cmbbodega.Text + "' "
            Dim tabla As DataTable = fnc.ListarTablasSQL(sql)



            If tabla.Rows.Count > 0 Then

                CODIGOBOD = tabla.Rows(0)(0).ToString().Trim()

            End If

            report.SetParameterValue("BODE", cmbbodega.Text)

        Else
            report.SetParameterValue("BODE", "TODAS")
        End If

        If T2Almac.Checked = True Then
            report.SetParameterValue("al", "TODOS")
        Else
            report.SetParameterValue("al", retorna_Almacenamiento(Cmbo_Almacenamiento.SelectedValue.ToString()))
        End If

        If T2Orig.Checked = True Then
            report.SetParameterValue("or", "TODOS")
        Else
            report.SetParameterValue("or", retorna_Origen(CmboOrigen.SelectedValue.ToString()))
        End If

        If T2Rece.Checked = True Then
            report.SetParameterValue("tr", "TODOS")
        Else
            report.SetParameterValue("tr", retorna_TipRece(Cmbotiporece.SelectedValue.ToString()))
        End If

        If T2TipoDes.Checked = True Then
            report.SetParameterValue("td", "TODOS")
        Else
            report.SetParameterValue("td", retorna_CargDesc(cmbo_descarga.SelectedValue.ToString()))
        End If

        Retorna_Where()

        frm.Contenedor.ReportSource = report
        frm.ShowDialog()

    End Sub

    Function Retorna_Where() As String
        Dim where As String = "where "

        If Txtcliente.Text <> "" Then
            If Txtcliente.Text <> "" Then
                where = where + " dr.drec_rutcli='" + LblCliente.Text + "' AND "
            End If
        End If

        If t2contrato.Checked = False Then

            If TxtContrato.Text = "" Then
                t2contrato.Checked = True
            Else
                where = where + "dr.drec_contcli='" + LblContrato.Text + "' AND "
            End If
        End If

        If T2producto.Checked = False Then
            If TxtProducto.Text = "" Then
                T2producto.Checked = True
            Else
                where = where + " mae_codi='" + LblProducto.Text + "' AND "
            End If
        End If
        If cmbbodega.Text <> "TODOS" Then

            Dim sql As String = "SELECT cod_bodega from mae_bodega where des_bodega='" + cmbbodega.Text + "' "
            Dim tabla3 As DataTable = fnc.ListarTablasSQL(sql)



            If tabla3.Rows.Count > 0 Then

                CODIGOBOD = tabla3.Rows(0)(0).ToString().Trim()

            End If



            where = where + "rd.cod_bod='" + CODIGOBOD + "' AND "


        End If
        If t2envase.Checked = False Then
            If Txtenvase.Text = "" Then
                t2envase.Checked = True
            Else
                where = where + "mae_tipenv='" + Lblenv.Text + "' AND "
            End If
        End If

        If T2estsop.Checked = False Then
            If cmboestadosop.Text = "TODOS" Then
                T2estsop.Checked = True
            Else

                where = where + "dr.Estpallet='" + cmboestadosop.Text + "' AND "

            End If

        Else

        End If


        If t2certsag.Checked = False Then
            If Txtcertsag.Text <> "" Then
                where = where + " dr.drec_codsag='" + Txtcertsag.Text + "' AND "
            Else
                t2certsag.Checked = True
            End If
        End If

        If t2fproduccion.Checked = False Then
            If TxtFechaProd.Text <> "" Then
                where = where + " dr.drec_fecprod='" + devuelve_fecha(TxtFechaProd.Text) + "' AND "
            Else
                t2fproduccion.Checked = True
            End If
        End If

        If t2fecharece.Checked = False Then
            If TxtFechaRece.Text <> "TODOS" Then
                where = where + "  dr.drec_fecrec='" + devuelve_fecha(TxtFechaRece.Text) + "' AND "
            Else
                t2fecharece.Checked = True
            End If
        End If

        If T2fechavenc.Checked = False Then
            If txtfechavenc.Text <> "TODOS" Then
                where += " dr.fechavencimiento='" + devuelve_fecha(txtfechavenc.Text) + "' AND "
            Else
                T2fechavenc.Checked = True
            End If
        End If

        If t2lotecli.Checked = False Then
            If TxtLoteCliente.Text <> "TODOS" Then
                where += " dr.LoteCliente='" + TxtLoteCliente.Text + "' AND "
            Else
                t2lotecli.Checked = True
            End If
        End If

        If T2Almac.Checked = False Then
            If Not IsNothing(Cmbo_Almacenamiento.SelectedValue) AndAlso Not Cmbo_Almacenamiento.Text = "TODOS" Then
                Dim almac As String = ""
                If Cmbo_Almacenamiento.SelectedValue = 1 Then
                    almac = "REFRIGERADO"
                ElseIf Cmbo_Almacenamiento.SelectedValue = 2 Then
                    almac = "CONGELADO"
                ElseIf Cmbo_Almacenamiento.SelectedValue = 3 Then
                    almac = "SECO"
                End If
                where += " fr.frec_tipoalmacenamiento='" + almac + "' AND "
            Else
                T2Almac.Checked = True
            End If
        End If

        If T2Rece.Checked = False Then
            If Not IsNothing(Cmbotiporece.SelectedValue) AndAlso Not Cmbotiporece.Text = "TODOS" Then
                where += " fr.frec_tiporecepcion='" + Cmbotiporece.SelectedValue.ToString() + "' AND "
            Else
                T2Rece.Checked = True
            End If
        End If

        If T2Orig.Checked = False Then
            If Not IsNothing(CmboOrigen.SelectedValue) AndAlso Not CmboOrigen.Text = "TODOS" Then
                where += " fr.frec_origen='" + CmboOrigen.SelectedValue.ToString() + "' AND "
            Else
                T2Orig.Checked = True
            End If
        End If

        If T2TipoDes.Checked = False Then
            If Not IsNothing(cmbo_descarga.SelectedValue) AndAlso Not cmbo_descarga.Text = "TODOS" Then
                where += " fr.frec_tipdesc='" + cmbo_descarga.SelectedValue.ToString() + "' AND "
            Else
                T2TipoDes.Checked = True
            End If
        End If
     




        If ChkPosicionado.Checked = True Then
            where += " (drec_camara<>'71' AND drec_camara<>'72' AND drec_camara<>'73' AND drec_camara<>'74' AND drec_camara<>'75' AND drec_camara<>'76' ) AND "
        End If

        If ChkSinPosicionar.Checked = True Then
            where += " (drec_camara='71' OR drec_camara='72' OR drec_camara='73' OR drec_camara='74' OR drec_camara='75' OR drec_camara='76' ) AND "
        End If

        If where.Length > 5 Then
            where = where.Remove(where.Length - 5, 4)
        End If

        Return where
    End Function

    Private Sub Excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Excel.Click
        Dim x As String = Retorna_Where()
        Dim sql As String = ""
        If x.Length > 0 Then
            'sql = "SELECT drec_codi, cli_nomb as cliente, mae_codi, mae_descr, drec_fecrec, drec_fecprod, dr.FechaVencimiento, cam_descr AS CAMARA, drec_banda, drec_colum, drec_piso, rd.cod_bod as BODEGA, " +
            '      "drec_nivel, drec_sopocli, racd_unidades, racd_peso , rd.lotecliente, drec_codsag AS CODIGO_SAG, DESCRIPCION, " +
            '      "CASE  WHEN isnull(drec_codcaja,0)='0' THEN 'SIN TRAQUEAR' ELSE ' TRAKEADO' END AS trakeado, " +
            '      "CASE  WHEN isnull(drec_camara,0)='71' OR isnull(drec_camara,0)='72' OR isnull(drec_camara,0)='73' OR  isnull(drec_camara,0)='74' OR  isnull(drec_camara,0)='75' OR  isnull(drec_camara,0)='76' THEN 'SIN POSICION' Else 'POSICIONADO' END AS Posicionado," +
            '      "isnull((SELECT TOP(1) ESTADO FROM AINVENTARIO WHERE PALLET=drec_codi),'NO INVENTARIADO') AS ESTADO_INVENTARIO, FECHA, " +
            '      "frec_guiades AS GUIA_CLIENTE, fr.frec_codi AS GUIA_PRECISA, frec_numSello AS SELLO, frec_contenedor AS CONTENEDOR, " +
            '      "CASE  WHEN frec_RecepTunel='2' THEN 'SI' ELSE 'NO' END AS TUNEL, CASE  WHEN frec_tipdesc='0' THEN 'MECANICA' ELSE 'MANUAL' END AS DESCARGA " +
            '      "FROM rackdeta AS rd INNER JOIN detarece AS dr ON racd_codi = drec_codi " +
            '      "INNER JOIN clientes ON cli_rut=drec_rutcli " +
            '      "INNER JOIN maeprod ON mae_codi=racd_codpro " +
            '      "INNER JOIN tipoenv ON mae_tipenv=tenv_codi " +
            '      "INNER JOIN RACKDETA_ESTADO ON racd_estado=CODIGO " +
            '      "INNER JOIN fichrece as fr ON fr.frec_codi=frec_codi1 " +
            '      "INNER JOIN camaras ON cam_codi=drec_camara " +
            '      "LEFT JOIN AINVENTARIO ON PALLET=racd_codi WHERE " + Retorna_Where() + " ORDER BY  mae_descr  ASC"
            sql = "SELECT drec_codi, cli_nomb as cliente, mae_codi, mae_descr, drec_fecrec=convert(varchar,convert(varchar,convert(date,drec_fecrec),105)), drec_fecprod=convert(varchar,convert(varchar,convert(date,drec_fecprod),105)),FechaVencimiento=convert(varchar,convert(varchar,convert(date,dr.FechaVencimiento),105)), NCamara AS CAMARA, drec_banda, drec_colum, drec_piso, rd.cod_bod as BODEGA, " +
                  "drec_nivel, drec_sopocli, racd_unidades, racd_peso , rd.lotecliente, drec_codsag AS CODIGO_SAG, DESCRIPCION, " +
                  "CASE  WHEN isnull(drec_codcaja,0)='0' THEN 'SIN TRAQUEAR' ELSE ' TRAKEADO' END AS trakeado, " +
                  "CASE  WHEN isnull(drec_camara,0)='71' OR isnull(drec_camara,0)='72' OR isnull(drec_camara,0)='73' OR  isnull(drec_camara,0)='74' OR  isnull(drec_camara,0)='75' OR  isnull(drec_camara,0)='76' THEN 'SIN POSICION' Else 'POSICIONADO' END AS Posicionado," +
                  "isnull((SELECT TOP(1) ESTADO FROM AINVENTARIO WHERE PALLET=drec_codi),'NO INVENTARIADO') AS ESTADO_INVENTARIO, FECHA, " +
                  "frec_guiades AS GUIA_CLIENTE, fr.frec_codi AS GUIA_PRECISA, frec_numSello AS SELLO, frec_contenedor AS CONTENEDOR, " +
                  "CASE  WHEN frec_RecepTunel='2' THEN 'SI' ELSE 'NO' END AS TUNEL, CASE  WHEN frec_tipdesc='0' THEN 'MECANICA' ELSE 'MANUAL' END AS DESCARGA " +
                  "FROM rackdeta AS rd INNER JOIN detarece AS dr ON racd_codi = drec_codi " +
                  "INNER JOIN clientes ON cli_rut=drec_rutcli " +
                  "INNER JOIN maeprod ON mae_codi=racd_codpro " +
                  "INNER JOIN tipoenv ON mae_tipenv=tenv_codi " +
                  "INNER JOIN RACKDETA_ESTADO ON racd_estado=CODIGO " +
                  "INNER JOIN fichrece as fr ON fr.frec_codi=frec_codi1 " +
                  "INNER JOIN CamaraConf ON Camara=drec_camara " +
                  "LEFT JOIN AINVENTARIO ON PALLET=racd_codi " + Retorna_Where() + " ORDER BY  mae_descr  ASC"
        Else
            'sql = "SELECT drec_codi, cli_nomb as cliente, mae_codi, mae_descr, drec_fecrec, drec_fecprod, dr.FechaVencimiento, cam_descr AS CAMARA, drec_banda, drec_colum, drec_piso, " +
            '      "drec_nivel, drec_sopocli, racd_unidades, racd_peso AS KILOS, rd.lotecliente, drec_codsag AS CODIGO_SAG, DESCRIPCION, " +
            '      "CASE  WHEN isnull(drec_codcaja,0)='0' THEN 'SIN TRAQUEAR' ELSE ' TRAKEADO' END AS trakeado, " +
            '      "CASE  WHEN isnull(drec_camara,0)='71' OR isnull(drec_camara,0)='72' OR isnull(drec_camara,0)='73' OR  isnull(drec_camara,0)='74' OR  isnull(drec_camara,0)='75' OR  isnull(drec_camara,0)='76' THEN 'SIN POSICION' Else 'POSICIONADO' END AS Posicionado," +
            '      "isnull((SELECT TOP(1) ESTADO FROM AINVENTARIO WHERE PALLET=drec_codi),'NO INVENTARIADO') AS ESTADO_INVENTARIO, FECHA, " +
            '      "frec_guiades AS GUIA_CLIENTE, fr.frec_codi AS GUIA_PRECISA, frec_numSello AS SELLO, frec_contenedor AS CONTENEDOR, " +
            '      "CASE  WHEN frec_RecepTunel='2' THEN 'SI' ELSE 'NO' END AS TUNEL, CASE  WHEN frec_tipdesc='0' THEN 'MECANICA' ELSE 'MANUAL' END AS DESCARGA " +
            '      "FROM rackdeta AS rd INNER JOIN detarece AS dr ON racd_codi = drec_codi " +
            '      "INNER JOIN clientes ON cli_rut=drec_rutcli " +
            '      "INNER JOIN maeprod ON mae_codi=racd_codpro " +
            '      "INNER JOIN tipoenv ON mae_tipenv=tenv_codi " +
            '      "INNER JOIN RACKDETA_ESTADO ON racd_estado=CODIGO " +
            '      "INNER JOIN fichrece as fr ON fr.frec_codi=frec_codi1 " +
            '      "INNER JOIN camaras ON cam_codi=drec_camara " +
            '      "LEFT JOIN AINVENTARIO ON PALLET=racd_codi ORDER BY  mae_descr  ASC"
            sql = "SELECT drec_codi, cli_nomb as cliente, mae_codi, mae_descr, drec_fecrec=convert(varchar,convert(varchar,convert(date,drec_fecrec),105)), drec_fecprod=convert(varchar,convert(varchar,convert(date,drec_fecprod),105)), FechaVencimiento=convert(varchar,convert(varchar,convert(date,dr.FechaVencimiento),105)), NCamara AS CAMARA, drec_banda, drec_colum, drec_piso, " +
                  "drec_nivel, drec_sopocli, racd_unidades, racd_peso AS KILOS, rd.lotecliente, drec_codsag AS CODIGO_SAG, DESCRIPCION, " +
                  "CASE  WHEN isnull(drec_codcaja,0)='0' THEN 'SIN TRAQUEAR' ELSE ' TRAKEADO' END AS trakeado, " +
                  "CASE  WHEN isnull(drec_camara,0)='71' OR isnull(drec_camara,0)='72' OR isnull(drec_camara,0)='73' OR  isnull(drec_camara,0)='74' OR  isnull(drec_camara,0)='75' OR  isnull(drec_camara,0)='76' THEN 'SIN POSICION' Else 'POSICIONADO' END AS Posicionado," +
                  "isnull((SELECT TOP(1) ESTADO FROM AINVENTARIO WHERE PALLET=drec_codi),'NO INVENTARIADO') AS ESTADO_INVENTARIO, FECHA, " +
                  "frec_guiades AS GUIA_CLIENTE, fr.frec_codi AS GUIA_PRECISA, frec_numSello AS SELLO, frec_contenedor AS CONTENEDOR, " +
                  "CASE  WHEN frec_RecepTunel='2' THEN 'SI' ELSE 'NO' END AS TUNEL, CASE  WHEN frec_tipdesc='0' THEN 'MECANICA' ELSE 'MANUAL' END AS DESCARGA " +
                  "FROM rackdeta AS rd INNER JOIN detarece AS dr ON racd_codi = drec_codi " +
                  "INNER JOIN clientes ON cli_rut=drec_rutcli " +
                  "INNER JOIN maeprod ON mae_codi=racd_codpro " +
                  "INNER JOIN tipoenv ON mae_tipenv=tenv_codi " +
                  "INNER JOIN RACKDETA_ESTADO ON racd_estado=CODIGO " +
                  "INNER JOIN fichrece as fr ON fr.frec_codi=frec_codi1 " +
                  "INNER JOIN CamaraConf ON Camara=drec_camara " +
                  "LEFT JOIN AINVENTARIO ON PALLET=racd_codi ORDER BY  mae_descr  ASC"

        End If

        Dim dt As New DataTable
        dt = fnc.ListarTablasSQL(sql)

        DGV.DataSource = dt
        GridAExcel(DGV)

    End Sub

    Private Sub T2Almac_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T2Almac.CheckedChanged
        If T2Almac.Checked = True Then
            Cmbo_Almacenamiento.Enabled = False
            Cmbo_Almacenamiento.Text = "TODOS"
        Else
            Cmbo_Almacenamiento.Enabled = True

        End If
    End Sub

    Private Sub T2Rece_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T2Rece.CheckedChanged
        If T2Rece.Checked = True Then
            Cmbotiporece.Enabled = False
            Cmbotiporece.Text = "TODOS"
        Else
            Cmbotiporece.Enabled = True

        End If
    End Sub

    Private Sub Rpt_StockClientePar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cmbotiporece.DataSource = fnc.ListarTablasSQL("SELECT IdRecepcion , DescripcionRecepcion FROM P_TipoRecepcion WHERE IdRecepcion <>'4' ORDER BY IdRecepcion DESC")
        Cmbotiporece.ValueMember = "IdRecepcion"
        Cmbotiporece.DisplayMember = "DescripcionRecepcion"

        Cmbo_Almacenamiento.DataSource = fnc.ListarTablasSQL("SELECT id, almacenamiento FROM P_tipoalmacenamiento WHERE id <>'0' ORDER BY id ASC")
        Cmbo_Almacenamiento.ValueMember = "id"
        Cmbo_Almacenamiento.DisplayMember = "almacenamiento"

        cmbo_descarga.DataSource = fnc.ListarTablasSQL("SELECT tcar_codi, tcar_descr FROM P_TipoCargaDescarga ORDER BY tcar_codi ASC")
        cmbo_descarga.ValueMember = "tcar_codi"
        cmbo_descarga.DisplayMember = "tcar_descr"

        CmboOrigen.DataSource = fnc.ListarTablasSQL("SELECT ori_codi, ori_descr FROM origen ORDER BY ori_codi ASC")
        CmboOrigen.ValueMember = "ori_codi"
        CmboOrigen.DisplayMember = "ori_descr"


        cmboestadosop.DataSource = fnc.ListarTablasSQL("select Estpallet from detarece where Estpallet is not null and Estpallet <>'' and Estpallet <>'-'  and Estpallet<>'N/C' group by Estpallet ")
        cmboestadosop.ValueMember = "Estpallet"
        cmboestadosop.DisplayMember = "Estpallet"



        If sucursalglo = "0" Then

            cmbbodega.DataSource = fnc.ListarTablasSQL("SELECT des_bodega FROM mae_bodega  where cod_bodega <>'0'ORDER BY cod_bodega ASC")
            cmbbodega.ValueMember = "des_bodega"
            cmbbodega.DisplayMember = "des_bodega"
        Else
            cmbbodega.DataSource = fnc.ListarTablasSQL("SELECT des_bodega FROM mae_bodega  where cod_bodega ='" + sucursalglo.Trim() + "' ORDER BY cod_bodega ASC")
            cmbbodega.ValueMember = "des_bodega"
            cmbbodega.DisplayMember = "des_bodega"



        End If
        
        cmboestadosop.Text = "TODOS"
        Cmbotiporece.Text = "TODOS"
        Cmbo_Almacenamiento.Text = "TODOS"
        cmbo_descarga.Text = "TODOS"
        CmboOrigen.Text = "TODOS"
        cmbbodega.Text = "TODOS"

    End Sub

    Private Sub Cmbo_Almacenamiento_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Cmbotiporece.KeyPress, CmboOrigen.KeyPress, cmbo_descarga.KeyPress, Cmbo_Almacenamiento.KeyPress
        e.Handled = True
    End Sub

    Private Sub T2Orig_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T2Orig.CheckedChanged
        If T2Orig.Checked = True Then
            CmboOrigen.Enabled = False
            CmboOrigen.Text = "TODOS"
        Else
            CmboOrigen.Enabled = True
        End If
    End Sub

    Private Sub T2TipoDes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T2TipoDes.CheckedChanged
        If T2TipoDes.Checked = True Then
            cmbo_descarga.Enabled = False
            cmbo_descarga.Text = "TODOS"
        Else
            cmbo_descarga.Enabled = True

        End If
    End Sub

    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        For Each _cont As Control In Panel1.Controls
            If TypeOf _cont Is CheckBox Then
                CType(_cont, CheckBox).Checked = True
            End If
        Next
        Txtcliente.Text = ""
        LblCliente.Text = ""
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            cmbbodega.Text = "TODOS"
            cmbbodega.Enabled = False
        Else

            cmbbodega.Enabled = True
        End If
    End Sub

    Private Sub T2estsop_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles T2estsop.CheckedChanged
        If T2estsop.Checked = True Then
            cmboestadosop.Enabled = False
            cmboestadosop.Text = "TODOS"
        Else
            cmboestadosop.Enabled = True

        End If
    End Sub
End Class
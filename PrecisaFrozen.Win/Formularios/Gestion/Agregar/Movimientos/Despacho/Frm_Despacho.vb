Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Imports System.IO

Public Class Frm_Despacho

    Dim fnc As New Funciones
    Dim LRAM As New LiberarMemoria
    Public foliopu As String = ""
    Public nomcli As String = ""

    Private Sub validapago()

        Dim rut As String = txtrutcli.Text
        Dim sqlped As String = "SELECT * FROM clientes where cli_rut='" + rut + "' and cli_blockges =1"
        'Dim sqlped As String = "SELECT * FROM detapedcajas where pc_numpal = '" + txtpallet.Text + "'"
        Dim tabla As DataTable = fnc.ListarTablasSQL(sqlped)

        If tabla.Rows.Count > 0 Then
            '"SELECT    CAJ_PCOD AS PALET,CAJ_COD as CAJA,CAJ_PED AS ESTADO FROM DetaReceCajas INNER JOIN rackdeta ON racd_codi=Caj_Pcod INNER JOIN detarece ON drec_codi=racd_codi WHERE CAJ_PCOD='" + txtpallet.Text + "'  "
            MsgBox("Este cliente se encuentra bloqueado por finanzas", MsgBoxStyle.Critical, "Aviso")
            limpiarformulario()
        End If
    End Sub

    Private Sub BtnGuia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuia.Click
        If RealizarAccion("003", "006") = False Then
            Exit Sub
        End If

        DataAdicionales.DataSource = fnc.ListarTablasSQL("SELECT 'False' AS Dvas_Est, Serv_Cod, Serv_Nom,'0' AS Dvas_Unid,'0' AS dvas_cajas,'0' AS dvas_kilos FROM FacServicios WHERE Serv_OrdD>0 ORDER BY Serv_ordd ASC")

        'DataAdicionales.DataSource = fnc.ListarTablasSQL("SELECT Serv_Cod, Serv_Nom,'0' AS Dvas_Unid,'0' AS dvas_cajas,'0' AS dvas_kilos FROM FacServicios WHERE Serv_Incluir = '2' OR Serv_Incluir = '3' ORDER BY Serv_ordd ASC")
        'Dim sqlad As String = "SELECT Serv_Cod, Serv_Nom FROM FacServicios WHERE Serv_Incluir = '2' OR Serv_Incluir = '3' ORDER BY Serv_ordd ASC"
        'DataAdicionales.DataSource = fnc.ListarTablasSQL(sqlad)

        Dim SQL As String = "SELECT fpre_codi FROM fichpred WHERE fpre_codvig='0' AND fpre_activa='0'"
        If fnc.ListarTablasSQL(SQL).Rows.Count = 1 Then
            RetornaInfoPreDespacho(fnc.ListarTablasSQL(SQL).Rows(0)(0).ToString())

            Exit Sub
        Else
            Frm_Principal.buscavalor = ""
            Dim frm As New Frm_ListadoPreDespachos
            frm.ShowDialog(Frm_Principal)
        End If

        If Frm_Principal.buscavalor.ToString() <> "" Then
            RetornaInfoPreDespacho(Frm_Principal.buscavalor.ToString())
            Frm_Principal.buscavalor = ""
        End If

        If txtrutcli.Text <> "" Then
            validapago()
        End If
    End Sub

    Sub RetornaInfoPreDespacho(ByVal codigo As String)
        Dim sqlFich As String = ""

        If sucursalglo = "0" Then
            sqlFich = "SELECT fpre_rutcli, carga, cincuenta, cli_nomb, fpre_sello, fpre_contenedor, fpre_rampla, " +
                      "fpre_destino, fpre_observacion, fpre_fechact, fpre_tem, fpre_totsopo, fpre_totunidad, " +
                      "fpre_totpeso, fpre_activa, fpre_horades, fpre_etiq, fpre_nped " +
                      "FROM FICHPRED INNER JOIN clientes ON fpre_rutcli=cli_rut inner join cincuenta ON folio=fpre_codi " +
                      "WHERE fpre_codvig='0' AND  fpre_codi='" + codigo + "' "
        Else
            sqlFich = "SELECT fpre_rutcli, carga, cincuenta, cli_nomb, fpre_sello, fpre_contenedor, fpre_rampla, " +
                        "fpre_destino, fpre_observacion, fpre_fechact, fpre_tem, fpre_totsopo, fpre_totunidad, " +
                        "fpre_totpeso, fpre_activa, fpre_horades, fpre_etiq, fpre_nped " +
                        "FROM FICHPRED INNER JOIN clientes ON fpre_rutcli=cli_rut inner join cincuenta ON folio=fpre_codi " +
                        "WHERE fpre_codvig='0' AND  fpre_codi='" + codigo + "' and fichpred.cod_bod ='" + sucursalglo + "' "
        End If



        Dim SqlTemperaturas As String = "SELECT TOP(1) mov_ts, mov_tm, mov_ti, ROUND((mov_ts + mov_tm + mov_ti)/3,2) FROM movpallet WHERE mov_doc='" + codigo + "' AND (mov_tipo='PD' OR mov_tipo='PR' OR mov_tipo='PT')"

        Dim tablaTemp As DataTable = fnc.ListarTablasSQL(SqlTemperaturas)

        If tablaTemp.Rows.Count > 0 Then
            t1.Text = tablaTemp.Rows(0)(0).ToString()
            t2.Text = tablaTemp.Rows(0)(1).ToString()
            t3.Text = tablaTemp.Rows(0)(2).ToString()
            tp.Text = tablaTemp.Rows(0)(3).ToString()
        End If


        Dim tabla As DataTable = fnc.ListarTablasSQL(sqlFich)

        If tabla.Rows.Count > 0 Then
            '***************************************************** Camiones en anden *****************************************************
            Dim f As New Frm_CamionesAndenDespacho
            f.ShowDialog(Frm_Principal)

            If fnc.verificaExistencia("zchecklist", "cl_fol", Frm_Principal.buscavalor.ToString()) = False Then
                If Frm_Principal.buscavalor.ToString() <> "NO" Then
                    MsgBox("No ha seleccionado un camion ", MsgBoxStyle.Critical, "Aviso")
                    Exit Sub
                Else
                    Horalleg.Text = tabla.Rows(0)(15).ToString()
                End If
            Else
                'Dim sqlcheck As String = "SELECT cl_chorut, cho_nombre, cl_pate, cl_choemp, cl_rutcli, right(convert(char(8),Cl_Lleg,8),8) AS HORA " +
                '    "FROM  zchecklist, choferes, clientes WHERE cli_rut=cl_rutcli AND cl_chorut=cho_rut " +
                '    "AND cl_fol='" + Frm_Principal.buscavalor.ToString() + "'"

                Dim sqlcheck As String = "SELECT a.cl_chorut,b.cho_nombre,a.cl_pate,a.cl_choemp,a.cl_rutcli,right(convert(char(8),a.Cl_Lleg,8),8) AS HORA,NroCont=isnull(d.NroCont,'') FROM zchecklist a with(nolock) inner join choferes b with(nolock) on(a.Cl_chorut=b.cho_rut) inner join clientes c with(nolock) on(a.Cl_RutCli=c.cli_rut) left outer join zCheckList_Contenedores d with(nolock) on(a.Cl_fol=d.Cl_fol) WHERE a.cl_fol='" + Frm_Principal.buscavalor.ToString() + "'"

                Dim TablaCheck As DataTable = fnc.ListarTablasSQL(sqlcheck)

                If TablaCheck.Rows.Count > 0 Then
                    TxtFolioPorteria.Text = Frm_Principal.buscavalor.ToString()
                    Txtchorut.Text = TablaCheck.Rows(0)(0).ToString().Remove(8)
                    txtchover.Text = TablaCheck.Rows(0)(0).ToString().Chars(8)
                    txtchonom.Text = TablaCheck.Rows(0)(1).ToString()
                    txtpatente.Text = TablaCheck.Rows(0)(2).ToString()
                    txtchoemp.Text = TablaCheck.Rows(0)(3).ToString()
                    Horalleg.Text = TablaCheck.Rows(0)(5).ToString()
                    TxtContenedor.Text = TablaCheck.Rows(0)(6).ToString().Trim
                    Frm_Principal.buscavalor = ""
                    'Cambio estado del checklist

                    'Actualización Cierre camiones carga y descarga. 07-06-19
                    'sqlcheck = "UPDATE zcheckList SET cl_estfrigo='1', cl_rutcli='" + tabla.Rows(0)(0).ToString() + "' " +
                    '           "WHERE cl_fol='" + TxtFolioPorteria.Text + "'"

                    'fnc.MovimientoSQL(sqlcheck)
                    'Fin actualización Cierre camiones carga y descarga. 07-06-19
                Else
                    Exit Sub
                End If
            End If

            ' Dim sql As String = "UPDATE fichpred SET fpre_activa='1' WHERE fpre_codi='" + codigo + "'"
            ' fnc.MovimientoSQL(Sql)

            If tabla.Rows(0)(14).ToString() = "1" Then
                MsgBox("El Pre-Despacho seleccionado se encuentra tomado por otro usuario", MsgBoxStyle.Critical, "Aviso")
                txtcodigo.Text = ""
                txtcodigo.Focus()
                Exit Sub
            End If
            txtcodigo.Text = codigo.ToString()
            txtrutcli.Text = tabla.Rows(0)(0).ToString()
            CbCarga.SelectedValue = Convert.ToInt32(tabla.Rows(0)(1).ToString())
            CbCarga.Enabled = False

            Dim tipCar As String = CbCarga.Text.Trim
            If (tipCar = "MECANICA") Then
                chkSalPallets.Checked = True
                chkSalPallets.Enabled = False
            Else
                chkSalPallets.Checked = False
                chkSalPallets.Enabled = True
            End If

            If tabla.Rows(0)(2).ToString() = "True" Then
                CbRecargo.Checked = True
            Else
                CbRecargo.Checked = False
            End If

            txtcliente.Text = tabla.Rows(0)(3).ToString()
            TxtSello.Text = tabla.Rows(0)(4).ToString()
            TxtContenedor.Text = tabla.Rows(0)(5).ToString()
            TxtRampla.Text = tabla.Rows(0)(6).ToString()
            TxtDestino.Text = tabla.Rows(0)(7).ToString()


            txttotsopo.Text = tabla.Rows(0)(11).ToString()
            txttotcajas.Text = tabla.Rows(0)(12).ToString()
            txttotkilos.Text = tabla.Rows(0)(13).ToString()

            ' VES ENE 2020
            txtSopAdic.Enabled = True
            Btn_buscasopadic.Enabled = True

            Panel1.Enabled = True
            GroupBox1.Enabled = True
            Me.BtnGuia.Enabled = False
            CargaGrillaPred()
            txtcodigo.Enabled = False
            btn_guardar.Enabled = True
            'lblcodigo.Text = BuscaCorrelativo("009")
            txtCodDesp.Text = BuscaCorrelativo("009")

            corregirCorrelativo()

            horaInic.Text = tabla.Rows(0)(15).ToString()

            'If tabla.Rows(0)(16).ToString() = "1" Then
            '    llamaChofer("222222222")
            '    Button3.Enabled = False
            'End If

            TimerAdicionales.Start()
            BtnBuscar.Enabled = False
            TabControl1.Enabled = True

            'Devuelve Horario
            If DetaDespa.RowCount > 0 Then
                Dim SqlHorario As String = "SELECT Hor_SDI, Hor_SDT, Hor_FDI, Hor_FDT, cont_diagracia FROM " +
                    "contratosHorarios, contrato WHERE cont_codi=hor_contcod AND Hor_Contcod='" + DetaDespa.Rows(0).Cells("COD_CONT").Value.ToString() + "' "
                Dim tablahorario As DataTable = fnc.ListarTablasSQL(SqlHorario)
                If tablahorario.Rows.Count > 0 Then
                    LV_horini.Text = tablahorario.Rows(0)(0).ToString()
                    LV_ter.Text = tablahorario.Rows(0)(1).ToString()
                    SA_HorIni.Text = tablahorario.Rows(0)(2).ToString()
                    Sab_HorTer.Text = tablahorario.Rows(0)(3).ToString()
                    txtderecho.Text = tablahorario.Rows(0)(4).ToString()
                End If
            End If

            'VALIDAR SOLICITUD MENOR A 24 HRS. HAmestica 27/07/2018
            Dim OrdenPedido = tabla.Rows(0).Item("fpre_nped").ToString.Trim

            If (OrdenPedido <> "" And OrdenPedido <> "1") Then
                Dim sqlValidOrdConjunta = "select OrdConjunta=case when ordenconjunta is null then '0' else '1' end from Pedidos_ficha where Orden='" & OrdenPedido & "'"
                Dim TabOrdCon As DataTable = fnc.ListarTablasSQL(sqlValidOrdConjunta)
                Dim OrdCon = CInt(TabOrdCon.Rows(0).Item(0).ToString.Trim)

                If (OrdCon = 0) Then
                    Dim sqlValid24Hrs = "select ExiPed=count(Orden) from Pedidos_24_Horas with(nolock) where Orden='" & OrdenPedido & "'"
                    Dim TabExiPed As DataTable = fnc.ListarTablasSQL(sqlValid24Hrs)
                    Dim ExiPed = CInt(TabExiPed.Rows(0).Item(0).ToString.Trim)
                    If (ExiPed > 0) Then
                        Dim sqlActPreDespMar = "update Pedidos_24_Horas set PreDesp_Marcado='1',Desp_Marcado='1' where Orden='" & OrdenPedido & "'"
                        fnc.MovimientoSQL(sqlActPreDespMar)

                        CbRecargo.Checked = True
                    Else
                        CbRecargo.Checked = False
                    End If
                End If
            End If
            'FIN VALIDAR SOLICITUD MENOR A 24 HRS. HAmestica 27/07/2018
        Else
            MsgBox("El codigo ingresado no existe o se encuentra anulado", MsgBoxStyle.Critical, "Aviso")
        End If
        If txtrutcli.Text <> "" Then
            validapago()
        End If
    End Sub

    Sub CargaGrillaPred()

        Dim sql = "SELECT dpre_folio, dpre_sopocli, dpre_codpro, mae_descr, dpre_unidades, dpre_peso, Convert(datetime,dpre_fecprod,111) AS dpre_fecprod, dpre_contcli, cont_descr, " +
            "dpre_codsopo, tsop_descr, dpre_pallet, dpre_camara, DATEDIFF(day,'19000101', GETDATE()-convert(datetime,drec_fecrec,111)) AS Estadia, Mov_Despacho, " +
            "Mov_Saldo FROM detapred , maeprod, tiposopo, contrato, detarece, movpallet WHERE mae_codi=dpre_codpro AND convert(int,tsop_codi)=dpre_codsopo " +
            "AND dpre_contcli=cont_codi AND drec_codi=dpre_folio AND dpre_folio=mov_folio AND dpre_codi LIKE '%" + txtcodigo.Text + "__%' AND (mov_tipo='PD' OR mov_tipo='PR') " +
            "AND mov_Doc='" + txtcodigo.Text + "'"

        Me.DetaDespa.DataSource = fnc.ListarTablasSQL(sql)

        If DetaDespa.Rows.Count <> txttotsopo.Text Then
            MsgBox("La cantidad de pallets no coinciden, comuniquese con informática", MsgBoxStyle.Critical, "Error")
            btn_nuevo_Click(Nothing, Nothing)
            'lblcodigo.Text = "0000000"
            txtCodDesp.Text = ""
        End If
    End Sub

    Public Sub Frm_Despacho_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'If lblcodigo.Text <> "0000000" Then
        If txtCodDesp.Text <> "0000000" And txtCodDesp.Text <> "" Then
            'If fnc.verificaExistencia("fichdespa", "fdes_codi", lblcodigo.Text) = False Then
            If fnc.verificaExistencia("fichdespa", "fdes_codi", txtCodDesp.Text) = False Then
                If MsgBox("Desea salir sin guardar lo ingresado", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbYes Then
                    'CancelaCorrelativo("009", lblcodigo.Text)
                    CancelaCorrelativo("009", txtCodDesp.Text)
                    f_addDespacho = False
                    Dim sql As String = "UPDATE fichpred SET fpre_activa='0' WHERE fpre_codi='" + txtcodigo.Text + "'"
                    fnc.MovimientoSQL(sql)
                Else
                    e.Cancel = True
                End If
            Else
                f_addDespacho = False
                Dim sql As String = "UPDATE fichpred SET fpre_activa='0' WHERE fpre_codi='" + txtcodigo.Text + "'"
                fnc.MovimientoSQL(sql)
            End If
        Else
            f_addDespacho = False
            Dim sql As String = "UPDATE fichpred SET fpre_activa='0' WHERE fpre_codi='" + txtcodigo.Text + "'"
            fnc.MovimientoSQL(sql)
        End If
    End Sub

    Public Function ByteArrayToImage(ByVal byteArrayIn As Byte()) As Image
        Dim ms As New MemoryStream(byteArrayIn)
        Return Image.FromStream(ms)
    End Function

    Private Sub cargaimg2()
        Dim sqlImagen As String = "SELECT foto from etiimg "

        Dim tablaimagen As DataTable = fnc.ListarTablasSQL(sqlImagen)

        If tablaimagen.Rows.Count > 0 Then

            'Imagen1
            If tablaimagen.Rows(0)(0).ToString() <> "" Then
                'PictureBox1.Image = Base64ToImage(tablaimagen.Rows(0)(0))
                pblogo.Image = ByteArrayToImage(DirectCast(tablaimagen.Rows(0)(0), Byte()))

            Else
                pblogo.Image = My.Resources.Resources.usuario_anonimo
            End If
        End If
    End Sub

    Private Sub Frm_Despacho_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Frm_Principal.buscavalor = ""

        cargaimg2()
        Dim sqlCombo As String = "SELECT tcar_codi, tcar_descr FROM P_TipoCargaDescarga ORDER BY tcar_codi asc"
        CbCarga.DataSource = fnc.ListarTablasSQL(sqlCombo)
        CbCarga.DisplayMember = "tcar_descr"
        CbCarga.ValueMember = "tcar_codi"
        txtResponsable.Text = fnc.DevuelveUsuario(Frm_Principal.InfoUsuario.Text)
        dt_fecha.Value = fnc.DevuelveFechaServidor()
        DataAdicionales.DataSource = fnc.ListarTablasSQL("SELECT 'False' AS Dvas_Est, Serv_Cod, Serv_Nom,'0' AS Dvas_Unid,'0' AS dvas_cajas,'0' AS dvas_kilos FROM FacServicios WHERE isnull(Serv_OrdD,0) >'0' ORDER BY Serv_ordd ASC")
        Rbsinguia.Checked = True
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim frm As New Lst_AyudaChoferes
        '  frm.where = txtrutcli.Text
        frm.ShowDialog(Frm_Principal)
        If Frm_Principal.buscavalor.ToString() <> "" Then
            llamaChofer(Frm_Principal.buscavalor.ToString())
        End If
    End Sub

    Sub llamaChofer(ByVal cho As String)
        Dim sqlConfValRut = "select valconf from CONF_GENERAL WHERE nombreconf='VALIDAR RUT'"
        Dim dtConfValRut As DataTable = fnc.ListarTablasSQL(sqlConfValRut)
        If (dtConfValRut.Rows.Count > 0) Then
            If (dtConfValRut.Rows(0).Item(0).ToString.Trim <> "0") Then
                If cho.Length < 8 Then
                    MsgBox("Debe agregar el rut completo", MsgBoxStyle.Information, "Aviso")
                    Exit Sub
                End If
            End If
        End If

        Dim sqlchofer As String = "SELECT cho_nombre, cho_patente, cho_empresa FROM choferes WHERE cho_rut='" + cho + "'"
        Dim tabla As DataTable = fnc.ListarTablasSQL(sqlchofer)
        If tabla.Rows.Count > 0 Then
            Txtchorut.Text = cho.ToString.Remove(cho.Length - 1)
            txtchover.Text = cho.ToString.Chars(cho.Length - 1)
            txtchonom.Text = tabla.Rows(0)(0).ToString()
            txtpatente.Text = tabla.Rows(0)(1).ToString()
            txtchoemp.Text = tabla.Rows(0)(2).ToString()
            Txtchorut.Enabled = False
            txtchover.Enabled = False
        Else
            MsgBox("El chofer ingresado no existe", MsgBoxStyle.Information, "Aviso")
        End If
        Frm_Principal.buscavalor = ""
    End Sub

    Private Sub BtnOrigen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOrigen.Click
        Dim frm As New Lst_AyudaOrigenes
        frm.ShowDialog(Frm_Principal)
        If Frm_Principal.buscavalor.ToString() <> "" Then
            txtorigen.Text = Frm_Principal.buscavalor
            txtorigend.Text = retorna_Origen(Frm_Principal.buscavalor.ToString())
            Frm_Principal.buscavalor = ""
        End If
    End Sub

    Private Sub CbSinGuia_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CbSinGuia.CheckedChanged
        If CbSinGuia.Checked = True Then
            txtGuiaCli.Text = "S/G"
            txtGuiaCli.Enabled = False
        Else
            txtGuiaCli.Text = ""
            txtGuiaCli.Enabled = True
            txtGuiaCli.Focus()
        End If
    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        Try
            'MMO ABRIL 2020
            LblTitulo1.Visible = True
            LblTitulo2.Visible = True
            LblProgreso.Text = "0%"
            LblProgreso.Visible = True
            LblAlerta.Visible = True
            LblProcesados.Visible = True
            LblTot.Visible = True

            'Liberar espacio en ram
            LRAM.Liberar_Memoria()

            ProgressBar_GuardarDespacho.Visible = True
            ProgressBar_GuardarDespacho.Maximum = 100
            ProgressBar_GuardarDespacho.Minimum = 0
            ProgressBar_GuardarDespacho.Value = 0

            ProgressBar_Pallets.Visible = True
            ProgressBar_Pallets.Maximum = DetaDespa.Rows.Count
            ProgressBar_Pallets.Minimum = 0
            ProgressBar_Pallets.Value = 0

            LblTot.Text = "/ " & DetaDespa.Rows.Count.ToString()

            Dim Ingreso As Integer = 0

            'If Not fnc.verificaExistencia("fichdespa", "fdes_codi", lblcodigo.Text) Then
            If Not fnc.verificaExistencia("fichdespa", "fdes_codi", txtCodDesp.Text) Then

                Dim p As Int32 = Math.Abs(100 - DetaDespa.Rows.Count)

                ProgressBar_GuardarDespacho.Increment(5)
                LblProgreso.Text = ProgressBar_GuardarDespacho.Value & ("%")

                Dim F_VALIDA As New Frm_VerificaServiciosDespa
                Dim dt_as As DataTable = New DataTable

                dt_as.Columns.Add("de")
                dt_as.Columns.Add("un")
                dt_as.Columns.Add("ca")
                dt_as.Columns.Add("ki")

                For i As Integer = 0 To DataAdicionales.RowCount - 1
                    If DataAdicionales.Rows(i).Cells("cb").Value = True Then
                        dt_as.Rows.Add(DataAdicionales.Rows(i).Cells("de").Value, _
                                       DataAdicionales.Rows(i).Cells("un").Value, _
                                       DataAdicionales.Rows(i).Cells("caj").Value, _
                                       DataAdicionales.Rows(i).Cells("ki").Value.replace(",", "."))
                    End If
                Next

                ProgressBar_GuardarDespacho.Increment(5)
                LblProgreso.Text = ProgressBar_GuardarDespacho.Value & ("%")

                F_VALIDA.DataAdicionales.DataSource = dt_as
                F_VALIDA.ShowDialog(Frm_Principal)

                If Frm_Principal.buscavalor = "NO" Or Frm_Principal.buscavalor = "" Then
                    ProgressBar_GuardarDespacho.Value = 0
                    ProgressBar_GuardarDespacho.Visible = False
                    LblProgreso.Visible = False
                    LblAlerta.Visible = False
                    Exit Sub
                End If


                ' VES ENE 2020
                Dim numSopAdic As String = "0" + txtSopAdic.Text
                Dim CodSopAdic As String = txtSopAdicCodi.Text


                If validacionIngreso() Then
                    ProgressBar_GuardarDespacho.Increment(5)
                    LblProgreso.Text = ProgressBar_GuardarDespacho.Value & ("%")

                    'Validacion codigo despacho vacio HAmestica 14/08/18
                    Dim CodDesp = txtCodDesp.Text.Trim
                    If (CodDesp = "" Or CodDesp = "0000000") Then
                        CodDesp = BuscaCorrelativo("009")
                        txtCodDesp.Text = CodDesp
                        MessageBox.Show("Se ha asignado el nro. " & CodDesp & " al despacho.", "Información!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                    ProgressBar_GuardarDespacho.Increment(5) '20
                    LblProgreso.Text = ProgressBar_GuardarDespacho.Value & ("%")

                    Dim temp As String = "Tº DESP. ºC: TºS: " + t1.Text + "    TºM: " + t2.Text + "     TºI: " + t3.Text + ""
                    Dim lleg As Date = Horalleg.Text
                    'Dim sql = "INSERT INTO fichdespa(fdes_codi, fdes_rutcli, fdes_horalleg, fdes_hora, fdes_fecha, fdes_codpred, fdes_totsopo, " +
                    '    "fdes_totunidad, fdes_totpeso, fdes_rutcond, fdes_patente, fdes_transporte, fdes_carro, fdes_sello, fdes_horometro, " +
                    '    "fdes_observ, fdes_tipcarga, fdes_codienca, fdes_codvig, fdes_origen, fdes_guiacliente, fdes_tempdespacho, fdes_destino, fdes_clfol, fdes_contenedor,cod_bod)" +
                    '    "VALUES('" + lblcodigo.Text + "','" + txtrutcli.Text + "','" + lleg.ToString("HH:mm") + "','" + DevuelveHora() + "','" + devuelve_fecha(dt_fecha.Value) + "'," +
                    '    "'" + txtcodigo.Text + "','" + txttotsopo.Text + "','" + txttotcajas.Text + "','" + txttotkilos.Text.Replace(",", ".") + "'," +
                    '    "'" + Txtchorut.Text + "" + txtchover.Text + "','" + txtpatente.Text + "','" + txtchoemp.Text + "'," +
                    '    "'" + TxtRampla.Text + "','" + TxtSello.Text + "','" + TxtHorometro.Text + "','" + TxtObs.Text + "', '" + CbCarga.SelectedValue.ToString() + "'," +
                    '    "'" + Frm_Principal.InfoUsuario.Text + "','0','" + txtorigen.Text + "','" + txtGuiaCli.Text + "','" + temp.ToString() + "'," +
                    '    "'" + TxtDestino.Text + "','" + TxtFolioPorteria.Text + "','" + TxtContenedor.Text + "','" + sucursalglo.Trim() + "')"

                    Dim sql = "INSERT INTO fichdespa(fdes_codi, fdes_rutcli, fdes_horalleg, fdes_hora, fdes_fecha, fdes_codpred, fdes_totsopo, " +
                        "fdes_totunidad, fdes_totpeso, fdes_rutcond, fdes_patente, fdes_transporte, fdes_carro, fdes_sello, fdes_horometro, " +
                        "fdes_observ, fdes_tipcarga, fdes_codienca, fdes_codvig, fdes_origen, fdes_guiacliente, fdes_tempdespacho, fdes_destino, " +
                        "fdes_clfol, fdes_contenedor,cod_bod,fdes_numsopadic,fdes_codsopadic)" +
                        "VALUES('" + txtCodDesp.Text + "','" + txtrutcli.Text + "','" + lleg.ToString("HH:mm") + "','" + DevuelveHora() + "','" + devuelve_fecha(dt_fecha.Value) + "'," +
                        "'" + txtcodigo.Text + "','" + txttotsopo.Text + "','" + txttotcajas.Text + "','" + txttotkilos.Text.Replace(",", ".") + "'," +
                        "'" + Txtchorut.Text + "" + txtchover.Text + "','" + txtpatente.Text + "','" + txtchoemp.Text + "'," +
                        "'" + TxtRampla.Text + "','" + TxtSello.Text + "','" + TxtHorometro.Text + "','" + TxtObs.Text + "', '" + CbCarga.SelectedValue.ToString() + "'," +
                        "'" + Frm_Principal.InfoUsuario.Text + "','0','" + txtorigen.Text + "','" + txtGuiaCli.Text + "','" + temp.ToString() + "'," +
                        "'" + TxtDestino.Text + "','" + TxtFolioPorteria.Text + "','" + TxtContenedor.Text + "','" + sucursalglo.Trim() + "'," + numSopAdic + ",'" + CodSopAdic + "')"

                    If fnc.MovimientoSQL(sql) > 0 Then

                        ProgressBar_GuardarDespacho.Increment(5)
                        LblProgreso.Text = ProgressBar_GuardarDespacho.Value & ("%")

                        'Actualización Cierre camiones carga y descarga. 07-06-19
                        Dim camionCargaDescarga As Boolean = False
                        Dim sqlValidCarDes As String = "select CarDes=case when a.Cl_Mov='3' then '1' else '0' end from zCheckList a with(nolock) where a.cl_fol='" + TxtFolioPorteria.Text.Trim + "'"
                        Dim dtCarDes As New DataTable
                        dtCarDes = fnc.ListarTablasSQL(sqlValidCarDes)

                        If (dtCarDes.Rows.Count > 0) Then
                            If (dtCarDes.Rows(0).Item(0).ToString.Trim = "1") Then
                                camionCargaDescarga = True
                            End If
                        End If

                        ProgressBar_GuardarDespacho.Increment(5)
                        LblProgreso.Text = ProgressBar_GuardarDespacho.Value & ("%")

                        If (camionCargaDescarga) Then
                            Dim sqlCarDes As String = "SP_Camiones_Carga_Descarga_Grabar '0','" & TxtFolioPorteria.Text.Trim & "','0','1','" & Frm_Principal.InfoUsuario.Text.Trim & "'"
                            fnc.MovimientoSQL(sqlCarDes)
                        Else
                            Dim sqlcheck As String = "UPDATE zcheckList SET cl_estfrigo='1' WHERE cl_fol='" + TxtFolioPorteria.Text + "'"

                            fnc.MovimientoSQL(sqlcheck)
                        End If
                        'Fin actualización Cierre camiones carga y descarga. 07-06-19

                        ProgressBar_GuardarDespacho.Increment(5)
                        LblProgreso.Text = ProgressBar_GuardarDespacho.Value & ("%")

                        'VAS Emisión guía Cliente y Excento Cobro Estadía. 25-06-19
                        Dim sqlVasEmiGui As String = ""
                        If (rbcliente.Checked) Then
                            sqlVasEmiGui = "SP_Despachos_Guia_Cliente_Grabar '" & txtCodDesp.Text.Trim & "','1','" & Frm_Principal.InfoUsuario.Text.Trim & "'"
                        Else
                            sqlVasEmiGui = "SP_Despachos_Guia_Cliente_Grabar '" & txtCodDesp.Text.Trim & "','0','" & Frm_Principal.InfoUsuario.Text.Trim & "'"
                        End If
                        fnc.MovimientoSQL(sqlVasEmiGui)

                        ProgressBar_GuardarDespacho.Increment(5)
                        LblProgreso.Text = ProgressBar_GuardarDespacho.Value & ("%")

                        Dim sqlCobEst As String = ""
                        If (chkSinCobEst.Checked) Then
                            sqlCobEst = "Despacho_Cobro_Estadia_Grabar '" & txtCodDesp.Text.Trim & "','" & Frm_Principal.InfoUsuario.Text.Trim & "','1'"
                        Else
                            sqlCobEst = "Despacho_Cobro_Estadia_Grabar '" & txtCodDesp.Text.Trim & "','" & Frm_Principal.InfoUsuario.Text.Trim & "','0'"
                        End If
                        fnc.MovimientoSQL(sqlCobEst)
                        'Fin VAS Emisión guía Cliente y Excento Cobro Estadía. 25-06-19

                        ProgressBar_GuardarDespacho.Increment(10)
                        LblProgreso.Text = ProgressBar_GuardarDespacho.Value & ("%")

                        Ingreso += 1
                        btn_guardar.Enabled = False

                        Dim sql_borra_saldos = "UPDATE movpallet SET mov_despacho='', mov_saldo='' WHERE mov_tipo='PD' AND mov_doc='" + txtcodigo.Text + "'"
                        fnc.MovimientoSQL(sql_borra_saldos)

                        ProgressBar_GuardarDespacho.Increment(10) '60
                        LblProgreso.Text = ProgressBar_GuardarDespacho.Value & ("%")

                        For i As Integer = 0 To DetaDespa.Rows.Count - 1

                            ProgressBar_Pallets.Increment(1)
                            LblProcesados.Text = Convert.ToString(i + 1)

                            Dim pallet As String = ""

                            Dim _ActualizaRackdeta = "SELECT racd_unidades, racd_peso FROM rackdeta WHERE racd_codi='" + DetaDespa.Rows(i).Cells(0).Value.ToString() + "'"
                            Dim _actualiza As DataTable = fnc.ListarTablasSQL(_ActualizaRackdeta)

                            If _actualiza.Rows.Count > 0 Then

                                If DetaDespa.Rows(i).Cells(4).Value.ToString() <> _actualiza.Rows(0)(0).ToString() Then

                                    Dim Unidades As Integer = _actualiza.Rows(0)(0).ToString()
                                    Dim peso As Double = _actualiza.Rows(0)(1).ToString()

                                    Dim Unidad_Final As Integer = Unidades - Val(DetaDespa.Rows(i).Cells(4).Value.ToString())
                                    Dim Peso_Final As Double = peso - Convert.ToDouble(DetaDespa.Rows(i).Cells(5).Value.ToString())

                                    Dim _Actualiza_Rack = "UPDATE rackdeta SET racd_unidades='" + Unidad_Final.ToString() + "' , " +
                                        "racd_peso='" + Peso_Final.ToString.Replace(",", ".") + "', racd_estado='0' WHERE racd_codi='" + DetaDespa.Rows(i).Cells(0).Value.ToString() + "'"
                                    pallet = "0"

                                    'Actualizar estados del detarececajas

                                    Dim sql_cjs As String = "UPDATE DetaReceCajas SET caj_ped='3' " +
                                                            "WHERE Caj_cod in(SELECT dpre_caja FROM DetaPredCajas " +
                                                            "WHERE dpre_npallet='" + DetaDespa.Rows(i).Cells(0).Value.ToString() + "') " +
                                                            "AND Caj_Pcod='" + DetaDespa.Rows(i).Cells(0).Value.ToString() + "'"

                                    fnc.MovimientoSQL(sql_cjs)

                                    If fnc.MovimientoSQL(_Actualiza_Rack) = 0 Then
                                        MsgBox("Ocurrio un error al actualizar las cantidades del soportante", MsgBoxStyle.Critical, "Aviso")
                                    End If

                                Else
                                    Dim _Delete As String = "DELETE FROM rackdeta WHERE racd_codi='" + DetaDespa.Rows(i).Cells(0).Value.ToString() + "'"
                                    fnc.MovimientoSQL(_Delete)
                                    pallet = "1"

                                    Dim SqlCambiaestado As String = "UPDATE DetaReceCajas SET caj_ped='3' WHERE caj_pcod='" + DetaDespa.Rows(i).Cells(0).Value.ToString() + "'"
                                    fnc.MovimientoSQL(SqlCambiaestado)
                                End If
                            Else
                                MsgBox("Error al capturar las cantidades del soportante", MsgBoxStyle.Information, "Aviso")
                            End If




                            'Dim _Sql As String = "INSERT INTO detadespa(ddes_codi, ddes_codpro, ddes_codsopo, ddes_sopocli, ddes_unidades, ddes_peso, " +
                            '    "ddes_fecprod, ddes_fecha, ddes_rutcli, ddes_contcli, ddes_camara, ddes_codpred, ddes_codrece, ddes_codvig, ddes_pallet, ddes_almacen,cod_bod)" +
                            '    "VALUES('" + lblcodigo.Text + "" + CerosAnteriorString(i + 1, 2) + "','" + DetaDespa.Rows(i).Cells(2).Value.ToString() + "'," +
                            '    "'" + DetaDespa.Rows(i).Cells(9).Value.ToString() + "'," +
                            '    "'" + DetaDespa.Rows(i).Cells(1).Value.ToString() + "','" + DetaDespa.Rows(i).Cells(4).Value.ToString() + "'," +
                            '    "'" + DetaDespa.Rows(i).Cells(5).Value.ToString().Replace(",", ".") + "','" + devuelve_fecha(DetaDespa.Rows(i).Cells(6).Value.ToString()) + "'," +
                            '    "'" + devuelve_fecha(dt_fecha.Value) + "','" + txtrutcli.Text + "','" + DetaDespa.Rows(i).Cells(7).Value.ToString() + "'," +
                            '    "'" + DetaDespa.Rows(i).Cells(12).Value.ToString() + "','" + txtcodigo.Text + "','" + DetaDespa.Rows(i).Cells(0).Value.ToString() + "'," +
                            '    "'0','" + pallet.ToString() + "','2','" + sucursalglo.Trim() + "')"

                            Dim _Sql As String = "INSERT INTO detadespa(ddes_codi, ddes_codpro, ddes_codsopo, ddes_sopocli, ddes_unidades, ddes_peso, " +
                                "ddes_fecprod, ddes_fecha, ddes_rutcli, ddes_contcli, ddes_camara, ddes_codpred, ddes_codrece, ddes_codvig, ddes_pallet, ddes_almacen,cod_bod)" +
                                "VALUES('" + txtCodDesp.Text + "" + CerosAnteriorString(i + 1, 2) + "','" + DetaDespa.Rows(i).Cells(2).Value.ToString() + "'," +
                                "'" + DetaDespa.Rows(i).Cells(9).Value.ToString() + "'," +
                                "'" + DetaDespa.Rows(i).Cells(1).Value.ToString() + "','" + DetaDespa.Rows(i).Cells(4).Value.ToString() + "'," +
                                "'" + DetaDespa.Rows(i).Cells(5).Value.ToString().Replace(",", ".") + "','" + devuelve_fecha(DetaDespa.Rows(i).Cells(6).Value.ToString()) + "'," +
                                "'" + devuelve_fecha(dt_fecha.Value) + "','" + txtrutcli.Text + "','" + DetaDespa.Rows(i).Cells(7).Value.ToString() + "'," +
                                "'" + DetaDespa.Rows(i).Cells(12).Value.ToString() + "','" + txtcodigo.Text + "','" + DetaDespa.Rows(i).Cells(0).Value.ToString() + "'," +
                                "'0','" + pallet.ToString() + "','2','" + sucursalglo.Trim() + "')"

                            fnc.MovimientoSQL(_Sql)


                            'Dim _MovPallet As String = "INSERT INTO movpallet(mov_folio, mov_codper, mov_fecha, mov_tipo, mov_hora, mov_doc, " +
                            '    "mov_chorut, mov_chonom, mov_chopat, mov_chotra, mov_despacho, mov_saldo)VALUES('" + DetaDespa.Rows(i).Cells(0).Value.ToString() + "'," +
                            '    "'" + Frm_Principal.InfoUsuario.Text + "','" + devuelve_fecha(dt_fecha.Value) + "','SA','" + DevuelveHora() + "','" + lblcodigo.Text + "'," +
                            '    "'" + Txtchorut.Text + "" + txtchover.Text + "','" + txtchonom.Text + "','" + txtpatente.Text + "','" + txtchoemp.Text + "', " +
                            '    "'" + DetaDespa.Rows(i).Cells(14).Value.ToString() + "','" + (Val(DetaDespa.Rows(i).Cells(15).Value.ToString())).ToString() + "')"

                            Dim _MovPallet As String = "INSERT INTO movpallet(mov_folio, mov_codper, mov_fecha, mov_tipo, mov_hora, mov_doc, " +
                                "mov_chorut, mov_chonom, mov_chopat, mov_chotra, mov_despacho, mov_saldo)VALUES('" + DetaDespa.Rows(i).Cells(0).Value.ToString() + "'," +
                                "'" + Frm_Principal.InfoUsuario.Text + "','" + devuelve_fecha(dt_fecha.Value) + "','SA','" + DevuelveHora() + "','" + txtCodDesp.Text + "'," +
                                "'" + Txtchorut.Text + "" + txtchover.Text + "','" + txtchonom.Text + "','" + txtpatente.Text + "','" + txtchoemp.Text + "', " +
                                "'" + DetaDespa.Rows(i).Cells(14).Value.ToString() + "','" + (Val(DetaDespa.Rows(i).Cells(15).Value.ToString())).ToString() + "')"

                            fnc.MovimientoSQL(_MovPallet)



                            'Inicio Modificación Custodia/Arriendo Pallets. HAmestica 24/10/19
                            Dim NumPal As String = DetaDespa.Rows(i).Cells(0).Value.ToString.Trim
                            Dim RutCli As String = txtrutcli.Text.Trim
                            Dim CodCont As String = DetaDespa.Rows(i).Cells(7).Value.ToString.Trim
                            Dim TipPal As String = "000" & DetaDespa.Rows(i).Cells(9).Value.ToString.Trim
                            Dim TipPalFrm As String = TipPal.Substring(TipPal.Length - 3, 3)
                            Dim DocAsoc As String = txtCodDesp.Text.Trim
                            Dim CantEnt As Integer = 0
                            Dim CantSal As Integer = 1
                            Dim Obs As String = "Despacho " & DocAsoc & ", Pallet " & NumPal & "."
                            Dim Est As String = "1"
                            Dim CodUsu As String = Frm_Principal.InfoUsuario.Text.Trim

                            Dim TipCar As String = ""

                            Dim sqlTipCar As String = "select a.tcar_descr from P_TipoCargaDescarga a with(nolock) inner join fichdespa b with(nolock) on(a.tcar_codi=b.fdes_tipcarga) where b.fdes_codi='" & DocAsoc & "'"
                            Dim dtTipCar As New DataTable

                            dtTipCar = fnc.ListarTablasSQL(sqlTipCar)

                            If (dtTipCar.Rows.Count > 0) Then
                                TipCar = dtTipCar.Rows(0).Item(0).ToString.Trim
                            End If

                            If (TipCar = "MECANICA") Then
                                Dim sqlEsArr As String = "select EsArr=count(ID) from Control_Pallet_Arriendo with(nolock) where Codigo_Soportante='" & NumPal & "' and Estado_Arriendo='A' and Fecha_Termino is null"
                                Dim dtEsArr As New DataTable

                                dtEsArr = fnc.ListarTablasSQL(sqlEsArr)

                                If (dtEsArr.Rows.Count > 0) Then
                                    Dim EsArr As Integer = CInt(dtEsArr.Rows(0).Item(0).ToString.Trim)

                                    If (EsArr > 0) Then
                                        'Validar Saldo stock pallets, si no tiene venta, de lo contrario descuento de custodia
                                        Dim sqlStockCust As String = "select a.Saldo,a.Contrato from Control_Pallet_Saldos a with(nolock) where a.Rut_Cliente='" & RutCli & "' and a.Tipo_Pallet='" & TipPalFrm & "' and a.Estado='1'"
                                        Dim dtStockCust As New DataTable

                                        dtStockCust = fnc.ListarTablasSQL(sqlStockCust)

                                        Dim ConSaldo As Boolean = False
                                        Dim ContratoPallet As String = ""

                                        If (dtStockCust.Rows.Count > 0) Then
                                            For j = 0 To dtStockCust.Rows.Count - 1
                                                Dim Saldo As Integer = CInt(dtStockCust.Rows(j).Item(0).ToString.Trim)
                                                ContratoPallet = dtStockCust.Rows(j).Item(1).ToString.Trim

                                                If (Saldo > 0) Then
                                                    ConSaldo = True
                                                    Exit For
                                                End If
                                            Next
                                        End If

                                        If (ConSaldo) Then
                                            Dim sqlMovCust As String = "SP_Control_Pallet_Grabar '','" & RutCli & "','" & ContratoPallet & "','" & Now.ToString("yyyyMMdd").Trim & "','" & TipPalFrm & "','" & DocAsoc & "','" & CantEnt & "','" & CantSal & "','" & Obs & "','" & Est & "','" & CodUsu & "'"
                                            Dim dtMovCust As New DataTable

                                            dtMovCust = fnc.ListarTablasSQL(sqlMovCust)

                                            If (dtMovCust.Rows.Count > 0) Then
                                                Dim RespMovCust As String = dtMovCust.Rows(0).Item(0).ToString.Trim

                                                If (RespMovCust = "-1") Then
                                                    MsgBox("Ocurrio un error al registrar movimiento de custodia de pallet.", MsgBoxStyle.Critical, "Error")
                                                End If
                                            Else
                                                MsgBox("Ocurrio un error al registrar movimiento de custodia de pallet.", MsgBoxStyle.Critical, "Error")
                                            End If
                                        Else
                                            Dim sqlVent As String = "SP_Control_Pallet_Venta_Grabar '','" & NumPal & "','D','" & DocAsoc & "','','','" & CodUsu & "'"
                                            Dim dtVent As New DataTable

                                            dtVent = fnc.ListarTablasSQL(sqlVent)
                                        End If

                                        Dim sqlMovArr As String = "SP_Control_Pallet_Arriendo_Grabar '','" & NumPal & "','','" & Now.ToString("yyyyMMdd") & "','','" & CodUsu & "'"
                                        Dim dtMovArr As New DataTable

                                        dtMovArr = fnc.ListarTablasSQL(sqlMovArr)
                                    End If
                                End If

                            ElseIf (TipCar = "MANUAL") Then
                                'Validar arriendo o propios
                                Dim EsArr As Boolean = False

                                Dim sqlEsArr As String = "select Cont=count(a.ID) from Control_Pallet_Arriendo a with(nolock) where a.Codigo_Soportante='" & NumPal & "' and a.Estado_Arriendo='A'"
                                Dim dtEsArr As New DataTable

                                dtEsArr = fnc.ListarTablasSQL(sqlEsArr)

                                If (dtEsArr.Rows.Count > 0) Then
                                    Dim RespEsArr As Integer = CInt(dtEsArr.Rows(0).Item(0).ToString.Trim)

                                    If (RespEsArr > 0) Then
                                        EsArr = True
                                    End If
                                End If

                                'Validar si se lleva los pallets
                                Dim LlevaPallets As Boolean = False

                                If (chkSalPallets.Checked) Then
                                    LlevaPallets = True
                                End If



                                If (Not EsArr) Then
                                    '   Propios: No se lleva pallets aumenta custodia, de lo contrario no pasa nada
                                    If (LlevaPallets = False) Then
                                        Dim sqlMovCust As String = "SP_Control_Pallet_Grabar '','" & RutCli & "','" & CodCont & "','" & Now.ToString("yyyyMMdd").Trim & "','" & TipPalFrm & "','" & DocAsoc & "','1','0','" & Obs & "','" & Est & "','" & CodUsu & "'"
                                        Dim dtMovCust As New DataTable

                                        dtMovCust = fnc.ListarTablasSQL(sqlMovCust)

                                        If (dtMovCust.Rows.Count > 0) Then
                                            Dim RespMovCust As String = dtMovCust.Rows(0).Item(0).ToString.Trim

                                            If (RespMovCust = "-1") Then
                                                MsgBox("Ocurrio un error al registrar movimiento de custodia de pallet.", MsgBoxStyle.Critical, "Error")
                                            End If
                                        Else
                                            MsgBox("Ocurrio un error al registrar movimiento de custodia de pallet.", MsgBoxStyle.Critical, "Error")
                                        End If
                                    End If
                                Else
                                    '   Arriendo: No se lleva pallets termina el arriendo, de lo contrario se vende
                                    If (LlevaPallets) Then
                                        Dim sqlVent As String = "SP_Control_Pallet_Venta_Grabar '','" & NumPal & "','D','" & DocAsoc & "','','','" & CodUsu & "'"
                                        Dim dtVent As New DataTable

                                        dtVent = fnc.ListarTablasSQL(sqlVent)
                                    End If

                                    Dim sqlMovArr As String = "SP_Control_Pallet_Arriendo_Grabar '','" & NumPal & "','','" & Now.ToString("yyyyMMdd") & "','','" & CodUsu & "'"
                                    Dim dtMovArr As New DataTable

                                    dtMovArr = fnc.ListarTablasSQL(sqlMovArr)
                                End If

                            End If
                            'Fin Modificación Custodia/Arriendo Pallets. HAmestica 24/10/19

                        Next

                        ProgressBar_GuardarDespacho.Increment(10)
                        LblProgreso.Text = ProgressBar_GuardarDespacho.Value & ("%")

                        '
                        ' VES ENE 2020
                        ' SI SE INDICARON PALLETS ADICIONALES EN EL DESPACHO, SE INTENTA SACARLOS DE LOS 
                        ' PALLETS EN CUSTODIA QUE TENGA EL CLIENTE. SI QUEDA ALGUN REMANENTE, SE LE VENDEN
                        '
                        If Not procesarPalletsCustodia() Then
                            ProgressBar_GuardarDespacho.Value = 0
                            ProgressBar_GuardarDespacho.Visible = False
                            LblProgreso.Visible = False
                            LblAlerta.Visible = False
                            Exit Sub
                        End If


                        'Dim _Cincuenta As String = "UPDATE cincuenta SET despacho='" + lblcodigo.Text + "', carga='" + CbCarga.SelectedValue.ToString() + "', " +
                        '                           "cincuenta='" + CbRecargo.Checked.ToString() + "' WHERE folio='" + txtcodigo.Text + "'"

                        Dim _Cincuenta As String = "UPDATE cincuenta SET despacho='" + txtCodDesp.Text + "', carga='" + CbCarga.SelectedValue.ToString() + "', " +
                                                   "cincuenta='" + CbRecargo.Checked.ToString() + "' WHERE folio='" + txtcodigo.Text + "'"

                        fnc.MovimientoSQL(_Cincuenta)

                        'Dim SQLPred As String = "UPDATE fichpred SET fpre_gdespa='" + lblcodigo.Text + "', " +
                        '    "fpre_codvig='2', fpre_activa='0' WHERE fpre_codi ='" + txtcodigo.Text + "'"

                        Dim SQLPred As String = "UPDATE fichpred SET fpre_gdespa='" + txtCodDesp.Text + "', " +
                            "fpre_codvig='2', fpre_activa='0' WHERE fpre_codi ='" + txtcodigo.Text + "'"

                        fnc.MovimientoSQL(SQLPred)

                        ProgressBar_GuardarDespacho.Increment(10)
                        LblProgreso.Text = ProgressBar_GuardarDespacho.Value & ("%")

                        Dim sqlPedCaja As String = "UPDATE pedcaja SET pc_estado='3' WHERE pc_codped=(SELECT fpre_nped FROM fichpred WHERE fpre_codi='" + txtcodigo.Text + "')"
                        fnc.MovimientoSQL(sqlPedCaja)

                        'Modificacion Liberar Pedidos 05-06-19

                        'Dim sqlfichpred As String = "UPDATE pedidos_ficha SET terminado='3' WHERE orden=(SELECT fpre_nped FROM fichpred WHERE fpre_codi='" + txtcodigo.Text + "')"
                        'Dim sqlfichpred As String = "update c set c.terminado='3' from Pedidos_ficha a with(nolock) inner join fichpred b with(nolock) on(a.Orden=b.fpre_nped) inner join Pedidos_ficha c with(nolock) on(c.ordenconjunta like '%'+convert(varchar,a.Orden)+'%') where b.fpre_codi='" + txtcodigo.Text + "'"
                        'Dim sqlfichpred As String = "update c set c.terminado='3' from fichpred a with(nolock) inner join(select Orden,ordenconjunta from Pedidos_ficha with(nolock)) b on(b.ordenconjunta like '%'+convert(varchar,a.fpre_nped)+'%') inner join Pedidos_ficha c with(nolock) on(b.Orden=c.Orden) where a.fpre_codi='" + txtcodigo.Text + "'"
                        Dim sqlGetOrden As String = "select fpre_nped from fichpred with(nolock) where fpre_codi='" & txtcodigo.Text.Trim & "'"
                        Dim dtOrden As New DataTable
                        dtOrden = fnc.ListarTablasSQL(sqlGetOrden)

                        If (dtOrden.Rows.Count > 0) Then
                            Dim Orden As String = dtOrden.Rows(0).Item(0).ToString.Trim

                            Dim sqlfichpred As String = "SP_Pedidos_Estados_Actualizar '" & Orden & "','D','3'"
                            fnc.MovimientoSQL(sqlfichpred)
                        Else
                            ProgressBar_GuardarDespacho.Value = 0
                            ProgressBar_GuardarDespacho.Visible = False
                            LblProgreso.Visible = False
                            LblAlerta.Visible = False
                            MsgBox("Ocurrió un error al liberar Orden Pedidos del Pre Despacho Nro. " & txtcodigo.Text.Trim & "." & vbCrLf & "Favor avisar a Informática para liberar Pedidos.", MsgBoxStyle.Critical, "Error")
                        End If

                        ProgressBar_GuardarDespacho.Increment(10)
                        LblProgreso.Text = ProgressBar_GuardarDespacho.Value & ("%")

                        'Fin modificacion Liberar Pedidos 05-06-19

                        Dim SqlCambiaestadocajas As String = "UPDATE DetaReceCajas SET caj_ped='3' WHERE caj_cod in (SELECT dpre_caja FROM detapredcajas WHERE dpc_nped=(SELECT fpre_nped FROM fichpred WHERE fpre_codi='" + txtcodigo.Text + "'))"
                        fnc.MovimientoSQL(SqlCambiaestadocajas)

                        'Dim Sqlmovc = "INSERT INTO movcajas(movc_fecha, movc_codcaja, movc_codrece, movc_tipo, movc_ndoc) " +
                        '              "SELECT GETDATE(),dpc_codcaja, dpc_numpal, 'SA', '" + lblcodigo.Text + "' FROM detapedcaja WHERE dpc_codped=(SELECT fpre_nped FROM fichpred WHERE fpre_codi='" + txtcodigo.Text + "')"

                        Dim Sqlmovc = "INSERT INTO movcajas(movc_fecha, movc_codcaja, movc_codrece, movc_tipo, movc_ndoc) " +
                                      "SELECT GETDATE(),dpc_codcaja, dpc_numpal, 'SA', '" + txtCodDesp.Text + "' FROM detapedcaja WHERE dpc_codped=(SELECT fpre_nped FROM fichpred WHERE fpre_codi='" + txtcodigo.Text + "')"

                        fnc.MovimientoSQL(Sqlmovc)

                        'vas Automatico
                        GuardaVasAutomatico()


                        BtnImprimir.Enabled = True

                        ProgressBar_GuardarDespacho.Increment(10)
                        LblProgreso.Text = ProgressBar_GuardarDespacho.Value & ("%")

                    Else
                        ProgressBar_GuardarDespacho.Value = 0
                        ProgressBar_GuardarDespacho.Visible = False
                        LblProgreso.Visible = False
                        LblAlerta.Visible = False
                        MsgBox("Ocurrio un error al intentar grabar el despacho: " + lastSqlError, MsgBoxStyle.Critical, "Aviso")
                    End If
                Else
                    ProgressBar_GuardarDespacho.Value = 0
                    ProgressBar_GuardarDespacho.Visible = False
                    LblProgreso.Visible = False
                    LblAlerta.Visible = False
                End If
            Else

                ProgressBar_GuardarDespacho.Increment(10)
                LblProgreso.Text = ProgressBar_GuardarDespacho.Value & ("%")

                Dim modificar As String = "0"
                If MsgBox("¿Enviar guia modificada al cliente?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbYes Then
                    modificar = "0"
                Else
                    modificar = "1"
                End If


                ' VES FEB 2020: Se reversan los movimientos de arriendo/custodia/venta asociados al documento
                If fnc.MovimientoSQL("spReversarArriendoCustodiaPallets NULL,'" + txtCodDesp.Text + "'") = 0 Then
                    ProgressBar_GuardarDespacho.Value = 0
                    ProgressBar_GuardarDespacho.Visible = False
                    LblProgreso.Visible = False
                    MsgBox("Ocurrio un error al intentar reversar movimientos de arriendo/custodia de pallets: " + lastSqlError, MsgBoxStyle.Critical, "Aviso")
                    Exit Sub
                End If

                'Dim sql As String = "UPDATE fichdespa SET fdes_fecha='" + devuelve_fecha(dt_fecha.Value) + "'," +
                '        "fdes_rutcond='" + Txtchorut.Text + "" + txtchover.Text + "', fdes_patente='" + txtpatente.Text + "', " +
                '        "fdes_transporte='" + txtchoemp.Text + "', fdes_carro='" + TxtRampla.Text + "', fdes_sello='" + TxtSello.Text + "', " +
                '        "fdes_horometro='" + TxtHorometro.Text + "', fdes_observ='" + TxtObs.Text + "', fdes_tipcarga='" + CbCarga.SelectedValue.ToString() + "', " +
                '        "fdes_origen='" + txtorigen.Text + "', fdes_guiacliente='" + txtGuiaCli.Text + "', " +
                '        "fdes_destino='" + TxtDestino.Text + "', fdes_contenedor='" + TxtContenedor.Text + "' WHERE fdes_codi='" + lblcodigo.Text + "' "

                Dim sql As String = "UPDATE fichdespa SET fdes_fecha='" + devuelve_fecha(dt_fecha.Value) + "'," +
                        "fdes_rutcond='" + Txtchorut.Text + "" + txtchover.Text + "', fdes_patente='" + txtpatente.Text + "', " +
                        "fdes_transporte='" + txtchoemp.Text + "', fdes_carro='" + TxtRampla.Text + "', fdes_sello='" + TxtSello.Text + "', " +
                        "fdes_horometro='" + TxtHorometro.Text + "', fdes_observ='" + TxtObs.Text + "', fdes_tipcarga='" + CbCarga.SelectedValue.ToString() + "', " +
                        "fdes_origen='" + txtorigen.Text + "', fdes_guiacliente='" + txtGuiaCli.Text + "', " +
                        "fdes_destino='" + TxtDestino.Text + "', fdes_contenedor='" + TxtContenedor.Text + "'"

                If (modificar = "0") Then
                    sql = sql & ",fdes_enviada='" + modificar + "',fdes_emis=getdate()"
                End If

                sql = sql & " WHERE fdes_codi='" + txtCodDesp.Text + "'"

                'Dim _Cincuenta As String = "UPDATE cincuenta SET despacho='" + lblcodigo.Text + "', carga='" + CbCarga.SelectedValue.ToString() + "', " +
                '                           "cincuenta='" + CbRecargo.Checked.ToString() + "' WHERE folio='" + txtcodigo.Text + "'"

                Dim _Cincuenta As String = "UPDATE cincuenta SET despacho='" + txtCodDesp.Text + "', carga='" + CbCarga.SelectedValue.ToString() + "', " +
                                           "cincuenta='" + CbRecargo.Checked.ToString() + "' WHERE folio='" + txtcodigo.Text + "'"

                fnc.MovimientoSQL(_Cincuenta)

                ProgressBar_GuardarDespacho.Increment(10) '20
                LblProgreso.Text = ProgressBar_GuardarDespacho.Value & ("%")

                'Dim fecha_detalle As String = "UPDATE detadespa SET ddes_fecha='" + devuelve_fecha(dt_fecha.Value) + "' WHERE ddes_codi LIKE '%" + lblcodigo.Text + "__%'"
                'fnc.MovimientoSQL(fecha_detalle)

                Dim fecha_detalle As String = "UPDATE detadespa SET ddes_fecha='" + devuelve_fecha(dt_fecha.Value) + "' WHERE ddes_codi LIKE '%" + txtCodDesp.Text + "__%'"
                fnc.MovimientoSQL(fecha_detalle)

                ProgressBar_GuardarDespacho.Increment(10)
                LblProgreso.Text = ProgressBar_GuardarDespacho.Value & ("%")

                If fnc.MovimientoSQL(sql) > 0 Then
                    'VAS Emisión guía Cliente y Excento Cobro Estadía. 25-06-19
                    Dim sqlVasEmiGui As String = ""
                    If (rbcliente.Checked) Then
                        sqlVasEmiGui = "SP_Despachos_Guia_Cliente_Grabar '" & txtCodDesp.Text.Trim & "','1','" & Frm_Principal.InfoUsuario.Text.Trim & "'"
                    Else
                        sqlVasEmiGui = "SP_Despachos_Guia_Cliente_Grabar '" & txtCodDesp.Text.Trim & "','0','" & Frm_Principal.InfoUsuario.Text.Trim & "'"
                    End If
                    fnc.MovimientoSQL(sqlVasEmiGui)

                    ProgressBar_GuardarDespacho.Increment(10)
                    LblProgreso.Text = ProgressBar_GuardarDespacho.Value & ("%")

                    Dim sqlCobEst As String = ""
                    If (chkSinCobEst.Checked) Then
                        sqlCobEst = "Despacho_Cobro_Estadia_Grabar '" & txtCodDesp.Text.Trim & "','" & Frm_Principal.InfoUsuario.Text.Trim & "','1'"
                    Else
                        sqlCobEst = "Despacho_Cobro_Estadia_Grabar '" & txtCodDesp.Text.Trim & "','" & Frm_Principal.InfoUsuario.Text.Trim & "','0'"
                    End If
                    fnc.MovimientoSQL(sqlCobEst)
                    'Fin VAS Emisión guía Cliente y Excento Cobro Estadía. 25-06-19

                    ProgressBar_GuardarDespacho.Increment(10) '50
                    LblProgreso.Text = ProgressBar_GuardarDespacho.Value & ("%")

                    'MsgBox("Guia Actualizada Correctamente", MsgBoxStyle.Information, "Aviso")

                    'LOG MODIFICO DESPACHO *************************************************************************************
                    'Dim _log As String = "INSERT INTO LOG_FICHDESPA(LFR_CODI, LFR_FECHA, LFR_HORA, LFR_USUARIO, LFR_PC)" +
                    '    "VALUES('" + lblcodigo.Text + "','" + devuelve_fecha(fnc.DevuelveFechaServidor()) + "'," +
                    '    "'" + DevuelveHora() + "','" + Frm_Principal.InfoUsuario.Text + "','" + My.Computer.Name.ToString() + "')"

                    Dim _log As String = "INSERT INTO LOG_FICHDESPA(LFR_CODI, LFR_FECHA, LFR_HORA, LFR_USUARIO, LFR_PC)" +
                        "VALUES('" + txtCodDesp.Text + "','" + devuelve_fecha(fnc.DevuelveFechaServidor()) + "'," +
                        "'" + DevuelveHora() + "','" + Frm_Principal.InfoUsuario.Text + "','" + My.Computer.Name.ToString() + "')"

                    fnc.MovimientoSQL(_log)
                    'LOG MODIFICO DESPACHO *************************************************************************************

                    ProgressBar_GuardarDespacho.Increment(10) '60
                    LblProgreso.Text = ProgressBar_GuardarDespacho.Value & ("%")

                    For i As Integer = 0 To DetaDespa.Rows.Count - 1
                        ProgressBar_Pallets.Increment(1)
                        LblProcesados.Text = Convert.ToString(i + 1)
                        Dim pallet As String = ""

                        'Inicio Modificación Custodia/Arriendo Pallets. HAmestica 24/10/19
                        Dim NumPal As String = DetaDespa.Rows(i).Cells(0).Value.ToString.Trim
                        Dim RutCli As String = txtrutcli.Text.Trim
                        Dim CodCont As String = DetaDespa.Rows(i).Cells(7).Value.ToString.Trim
                        Dim TipPal As String = "000" & DetaDespa.Rows(i).Cells(9).Value.ToString.Trim
                        Dim TipPalFrm As String = TipPal.Substring(TipPal.Length - 3, 3)
                        Dim DocAsoc As String = txtCodDesp.Text.Trim
                        Dim CantEnt As Integer = 0
                        Dim CantSal As Integer = 1
                        Dim Obs As String = "Despacho " & DocAsoc & ", Pallet " & NumPal & "."
                        Dim Est As String = "1"
                        Dim CodUsu As String = Frm_Principal.InfoUsuario.Text.Trim

                        Dim TipCar As String = ""

                        Dim sqlTipCar As String = "select a.tcar_descr from P_TipoCargaDescarga a with(nolock) inner join fichdespa b with(nolock) on(a.tcar_codi=b.fdes_tipcarga) where b.fdes_codi='" & DocAsoc & "'"
                        Dim dtTipCar As New DataTable

                        dtTipCar = fnc.ListarTablasSQL(sqlTipCar)

                        If (dtTipCar.Rows.Count > 0) Then
                            TipCar = dtTipCar.Rows(0).Item(0).ToString.Trim
                        End If



                        If (TipCar = "MECANICA") Then



                            Dim sqlEsArr As String = "select EsArr=count(ID) from Control_Pallet_Arriendo with(nolock) where Codigo_Soportante='" & NumPal & "' and Estado_Arriendo='A' and Fecha_Termino is null"
                            Dim dtEsArr As New DataTable

                            dtEsArr = fnc.ListarTablasSQL(sqlEsArr)



                            If (dtEsArr.Rows.Count > 0) Then
                                Dim EsArr As Integer = CInt(dtEsArr.Rows(0).Item(0).ToString.Trim)

                                If (EsArr > 0) Then
                                    'Validar Saldo stock pallets, si no tiene venta, de lo contrario descuento de custodia
                                    Dim sqlStockCust As String = "select a.Saldo,a.Contrato from Control_Pallet_Saldos a with(nolock) where a.Rut_Cliente='" & RutCli & "' and a.Tipo_Pallet='" & TipPalFrm & "' and a.Estado='1'"
                                    Dim dtStockCust As New DataTable

                                    dtStockCust = fnc.ListarTablasSQL(sqlStockCust)

                                    Dim ConSaldo As Boolean = False
                                    Dim ContratoPallet As String = ""

                                    If (dtStockCust.Rows.Count > 0) Then
                                        For j = 0 To dtStockCust.Rows.Count - 1
                                            Dim Saldo As Integer = CInt(dtStockCust.Rows(j).Item(0).ToString.Trim)
                                            ContratoPallet = dtStockCust.Rows(j).Item(1).ToString.Trim

                                            If (Saldo > 0) Then
                                                ConSaldo = True
                                                Exit For
                                            End If
                                        Next
                                    End If

                                    If (ConSaldo) Then
                                        Dim sqlMovCust As String = "SP_Control_Pallet_Grabar '','" & RutCli & "','" & ContratoPallet & "','" & Now.ToString("yyyyMMdd").Trim & "','" & TipPalFrm & "','" & DocAsoc & "','" & CantEnt & "','" & CantSal & "','" & Obs & "','" & Est & "','" & CodUsu & "'"
                                        Dim dtMovCust As New DataTable

                                        dtMovCust = fnc.ListarTablasSQL(sqlMovCust)

                                        If (dtMovCust.Rows.Count > 0) Then
                                            Dim RespMovCust As String = dtMovCust.Rows(0).Item(0).ToString.Trim

                                            If (RespMovCust = "-1") Then
                                                MsgBox("Ocurrio un error al registrar movimiento de custodia de pallet.", MsgBoxStyle.Critical, "Error")
                                            End If
                                        Else
                                            MsgBox("Ocurrio un error al registrar movimiento de custodia de pallet.", MsgBoxStyle.Critical, "Error")
                                        End If
                                    Else
                                        Dim sqlVent As String = "SP_Control_Pallet_Venta_Grabar '','" & NumPal & "','D','" & DocAsoc & "','','','" & CodUsu & "'"
                                        Dim dtVent As New DataTable

                                        dtVent = fnc.ListarTablasSQL(sqlVent)
                                    End If

                                    Dim sqlMovArr As String = "SP_Control_Pallet_Arriendo_Grabar '','" & NumPal & "','','" & Now.ToString("yyyyMMdd") & "','','" & CodUsu & "'"
                                    Dim dtMovArr As New DataTable

                                    dtMovArr = fnc.ListarTablasSQL(sqlMovArr)
                                End If
                            End If


                        ElseIf (TipCar = "MANUAL") Then


                            'Validar arriendo o propios
                            Dim EsArr As Boolean = False

                            Dim sqlEsArr As String = "select Cont=count(a.ID) from Control_Pallet_Arriendo a with(nolock) where a.Codigo_Soportante='" & NumPal & "' and a.Estado_Arriendo='A'"
                            Dim dtEsArr As New DataTable

                            dtEsArr = fnc.ListarTablasSQL(sqlEsArr)

                            If (dtEsArr.Rows.Count > 0) Then
                                Dim RespEsArr As Integer = CInt(dtEsArr.Rows(0).Item(0).ToString.Trim)

                                If (RespEsArr > 0) Then
                                    EsArr = True
                                End If
                            End If

                            'Validar si se lleva los pallets
                            Dim LlevaPallets As Boolean = False

                            If (chkSalPallets.Checked) Then
                                LlevaPallets = True
                            End If



                            If (Not EsArr) Then
                                '   Propios: No se lleva pallets aumenta custodia, de lo contrario no pasa nada
                                If (LlevaPallets = False) Then
                                    Dim sqlMovCust As String = "SP_Control_Pallet_Grabar '','" & RutCli & "','" & CodCont & "','" & Now.ToString("yyyyMMdd").Trim & "','" & TipPalFrm & "','" & DocAsoc & "','1','0','" & Obs & "','" & Est & "','" & CodUsu & "'"
                                    Dim dtMovCust As New DataTable

                                    dtMovCust = fnc.ListarTablasSQL(sqlMovCust)

                                    If (dtMovCust.Rows.Count > 0) Then
                                        Dim RespMovCust As String = dtMovCust.Rows(0).Item(0).ToString.Trim

                                        If (RespMovCust = "-1") Then
                                            MsgBox("Ocurrio un error al registrar movimiento de custodia de pallet.", MsgBoxStyle.Critical, "Error")
                                        End If
                                    Else
                                        MsgBox("Ocurrio un error al registrar movimiento de custodia de pallet.", MsgBoxStyle.Critical, "Error")
                                    End If
                                End If

                            Else
                                '   Arriendo: No se lleva pallets termina el arriendo, de lo contrario se vende
                                If (LlevaPallets) Then
                                    Dim sqlVent As String = "SP_Control_Pallet_Venta_Grabar '','" & NumPal & "','D','" & DocAsoc & "','','','" & CodUsu & "'"
                                    Dim dtVent As New DataTable

                                    dtVent = fnc.ListarTablasSQL(sqlVent)
                                End If

                                Dim sqlMovArr As String = "SP_Control_Pallet_Arriendo_Grabar '','" & NumPal & "','','" & Now.ToString("yyyyMMdd") & "','','" & CodUsu & "'"
                                Dim dtMovArr As New DataTable

                                dtMovArr = fnc.ListarTablasSQL(sqlMovArr)

                            End If
                        End If
                        'Fin Modificación Custodia/Arriendo Pallets. HAmestica 24/10/19

                    Next


                    '
                    ' VES ENE 2020
                    ' SI SE INDICARON PALLETS ADICIONALES EN EL DESPACHO, SE INTENTA SACARLOS DE LOS 
                    ' PALLETS EN CUSTODIA QUE TENGA EL CLIENTE. SI QUEDA ALGUN REMANENTE, SE LE VENDEN
                    '
                    If Not procesarPalletsCustodia() Then
                        ProgressBar_GuardarDespacho.Value = 0
                        ProgressBar_GuardarDespacho.Visible = False
                        LblProgreso.Visible = False
                        LblAlerta.Visible = False
                        Exit Sub
                    End If


                    'Actualiza V.A.S Automatico
                    GuardaVasAutomatico()
                    ProgressBar_GuardarDespacho.Increment(20)
                    LblProgreso.Text = ProgressBar_GuardarDespacho.Value & ("%")

                    'Busca_Despacho(lblcodigo.Text)
                    Busca_Despacho(txtCodDesp.Text)
                    ProgressBar_GuardarDespacho.Increment(20)
                    LblProgreso.Text = ProgressBar_GuardarDespacho.Value & ("%")
                Else
                    ProgressBar_GuardarDespacho.Value = 0
                    ProgressBar_GuardarDespacho.Visible = False
                    LblProgreso.Visible = False
                    LblAlerta.Visible = False
                    MsgBox("Error al actualizar documento", MsgBoxStyle.Critical, "Aviso")
                End If

            End If
            LblAlerta.Visible = False
            MsgBox("Información Agregada Correctamente", MsgBoxStyle.Information, "Aviso")

        Catch ex As Exception
            ProgressBar_GuardarDespacho.Value = 0
            ProgressBar_GuardarDespacho.Visible = False
            LblProgreso.Visible = False
            LblAlerta.Visible = False
            My.Application.Log.WriteException(ex, TraceEventType.Error, "Exception in ExceptionLogTest ")
        End Try

    End Sub



    '
    '  VES FEB 2020
    '  Procesar los pallets adicionales despachados
    '
    Private Function procesarPalletsCustodia() As Boolean

        Dim NumSopAdic As Integer
        NumSopAdic = CInt("0" + txtSopAdic.Text)
        If NumSopAdic > 0 And txtSopAdicCodi.Text = "" Then
            MessageBox.Show("Debe indicar el tipo de soportante para los pallets adicionales", "Cuidado!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            Return False
        End If
        If NumSopAdic = 0 Then Return True

        Dim RutCli As String = QuitarCaracteres(txtrutcli.Text.Trim(), "-")
        Dim CodCont As String = DetaDespa.Rows(0).Cells(7).Value.ToString.Trim()
        Dim Fec As String = Now.ToString("yyyyMMdd").Trim()
        Dim TipSop As String = txtSopAdicCodi.Text
        Dim DocAso As String = txtCodDesp.Text
        Dim CanIngFrm As String = "0"
        Dim CanSalFrm As String = "0"
        Dim Obs As String = "Soportantes adicionales en despacho #" + DocAso
        Dim Est As String = "1"

        '
        ' INTENTAMOS DESCONTAR LOS PALLETS ADICIONALES DE
        ' LOS PALLETS EN CUSTODIA DEL CLIENTE 
        '
        Dim saldo As Integer = CInt(numSopAdic)
        Dim sqlAdic As String = "SELECT contrato, saldo FROM vwSaldosPalletCustodia WHERE rut_cliente = @rut"
        Dim custodia As DataTable = fnc.ListarTablasSQL(sqlAdic, New SqlParameter() {New SqlParameter("@rut", SqlDbType.NVarChar) With {.Value = RutCli}})
        Dim errorMsg As String = ""
        For Each row As DataRow In custodia.Rows
            Dim saldoContrato As Integer = CInt(row("saldo"))
            Dim cant As Integer = saldo
            If cant > saldoContrato Then
                cant = saldoContrato
            End If
            CodCont = row("contrato").ToString()
            CanSalFrm = cant.ToString()

            sqlAdic = "SP_Control_Pallet_Grabar '','" & RutCli & "','" & CodCont & "','" & Fec & "','" & TipSop & "','" & DocAso & "','" & CanIngFrm & "','" & CanSalFrm & "','" & Obs & "','" & Est & "','" & Frm_Principal.InfoUsuario.Text.Trim & "'"
            If fnc.MovimientoSQL(sqlAdic) = 1 Then
                saldo = saldo - cant
            Else
                errorMsg = lastSqlError
            End If

            If errorMsg <> "" Or saldo <= 0 Then
                Exit For
            End If
        Next

        '
        ' SI QUEDO ALGUNA CANTIDAD REMANENTE QUE NO SE PUDO CUBRIR CON 
        ' PALLETS EN CUSTODIA, SE REGISTRA COMO UNA VENTA DE PALLETS
        '
        If errorMsg = "" And saldo > 0 Then
            Dim i As Integer
            Dim NumPal As String
            For i = 1 To saldo
                NumPal = DocAso + i.ToString().PadLeft(2, "0")
                sqlAdic = "SP_Control_Pallet_Venta_Grabar '','" & NumPal & "','D','" & DocAso & "','','','" & Frm_Principal.InfoUsuario.Text.Trim & "'"
                If fnc.MovimientoSQL(sqlAdic) = 0 Then
                    errorMsg = lastSqlError
                    Exit For
                End If
            Next
        End If

        If errorMsg <> "" Then
            MsgBox("Ocurrio un error al actualizar el control de soportantes adicionales: " + errorMsg, MsgBoxStyle.Critical, "Aviso")
        End If

        Return (errorMsg = "")
    End Function


    Sub corregirCorrelativo()
        Dim sqlCorrAct As String = "select a.cor_correact from correlat a with(nolock) where a.cor_codi='009'"
        Dim dtCorrAct As New DataTable
        dtCorrAct = fnc.ListarTablasSQL(sqlCorrAct)

        If (dtCorrAct.Rows.Count > 0) Then
            Dim Err As Boolean = False

            Dim CorrForm As String = txtCodDesp.Text.Trim
            Dim CorrFormFrm As Integer = 0

            Dim CorrAct As String = dtCorrAct.Rows(0).Item(0).ToString.Trim
            Dim CorrActFrm As Integer = CInt(CorrAct)

            If (Not Integer.TryParse(CorrForm, CorrFormFrm)) Then
                Err = True
            Else
                If ((CorrFormFrm - CorrActFrm) < -5 Or (CorrFormFrm - CorrActFrm) > 5) Then
                    Err = True
                End If
            End If

            If (CorrFormFrm.ToString.Length <> CorrActFrm.ToString.Length) Then
                Err = True
            End If

            If (Err) Then
                Dim sqlCorrLim As String = "delete from Correlat_salto where tmps_correl='009' and tmps_personal='" & Frm_Principal.InfoUsuario.Text.Trim & "'"
                fnc.MovimientoSQL(sqlCorrLim)

                Frm_Principal.buscavalor = ""
                txtCodDesp.Text = BuscaCorrelativo("009")
            End If
        End If
    End Sub

    Private Function validacionIngreso() As Boolean
        validacionIngreso = True

        Dim mensaje As String = ""

        If CbSinGuia.Checked = False Then
            If txtGuiaCli.Text = "" Then
                mensaje = mensaje + "- Guia de retiro del cliente" + vbCrLf
                validacionIngreso = False
            End If
        End If

        If fnc.verificaExistencia("choferes", "cho_rut", Txtchorut.Text + txtchover.Text) = False Then
            mensaje = mensaje + "- Chofer correcto" + vbCrLf
            validacionIngreso = False
        End If

        If TxtSello.Text = "" Then
            mensaje = mensaje + "- Debe ingresar sello " + vbCrLf
            validacionIngreso = False
        End If

        If CbCustodia.Checked = True Then
            If IsNumeric(TxtCustodia.Text) Then
                If Val(TxtCustodia.Text) > Val(txttotsopo.Text) Then
                    mensaje = mensaje + "- Debe ingresar cantidad de pallet de custodia menor al total" + vbCrLf
                    validacionIngreso = False
                End If
            Else
                mensaje = mensaje + "- Debe ingresar cantidad de pallet de custodia" + vbCrLf
                validacionIngreso = False
            End If
        End If

        If Cb_Postura.Checked = True Then
            If IsNumeric(TxtFilm.Text) Then
                If Val(TxtFilm.Text) > Val(txttotsopo.Text) Then
                    mensaje = mensaje + "- Debe ingresar cantidad de postura de film menor al total" + vbCrLf
                    validacionIngreso = False
                End If
            Else
                mensaje = mensaje + "- Debe ingresar cantidad de pallet de custodia" + vbCrLf
                validacionIngreso = False
            End If
        End If

        If validacionIngreso = False Then
            MsgBox("Debe Agregar lo siguiente antes de continuar" + vbCrLf + mensaje, MsgBoxStyle.Critical, "Aviso")
        End If

        Return validacionIngreso
    End Function

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub Txtchorut_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtchorut.KeyPress
        If e.KeyChar = ChrW(13) Then
            If Txtchorut.Text.Length = 8 Then
                txtchover.Focus()
            End If
        End If
    End Sub

    Private Sub txtchover_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtchover.KeyPress
        If e.KeyChar = ChrW(13) Then
            If txtchover.Text.Length = 1 Then
                llamaChofer(Txtchorut.Text + "" + txtchover.Text)
            End If
        End If
    End Sub

    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        Dim frm As New Frm_ListadoDespachados
        frm.ShowDialog(Frm_Principal)
        If Frm_Principal.buscavalor.ToString() <> "" Then
            Busca_Despacho(Frm_Principal.buscavalor.ToString())
        End If
    End Sub

    Private Sub Busca_Despacho(ByVal codigo_despacho As String)

        Dim CodDesp As String = CerosAnteriorString(codigo_despacho, 7)
        If (CodDesp = "0000000") Then
            Exit Sub
        End If

        Dim sql = "SELECT fdes_codi, fdes_rutcli, cli_nomb, fdes_fecha, fdes_codpred, fdes_totsopo, fdes_totunidad, fdes_totpeso, " +
                  "fdes_rutcond, fdes_patente, fdes_transporte, fdes_carro, fdes_sello, fdes_horometro, fdes_observ, fdes_tipcarga, " +
                  "fdes_origen, fdes_guiacliente, fdes_destino, cincuenta, fdes_contenedor, fdes_hora, fdes_clfol, fpre_horades, " +
                  "isnull(fdes_horalleg,fpre_horades), fdes_codienca,fdes_codvig,fdes_numsopadic,fdes_codsopadic " +
                  "FROM fichdespa, clientes, cincuenta, fichpred " +
                  "WHERE despacho=fdes_codi AND folio=fdes_codpred AND cli_rut=fdes_rutcli AND fpre_codi=fdes_codpred AND " +
                  "fdes_codi='" + CodDesp + "'"

        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

        If tabla.Rows.Count > 0 Then

            CbCustodia.CheckState = False
            TxtCustodia.Text = "0"
            CbRepa.CheckState = False
            TxtRepa.Text = "0"
            Cb_Postura.CheckState = False
            TxtFilm.Text = "0"

            'lblcodigo.Text = tabla.Rows(0)(0).ToString()
            txtCodDesp.Text = tabla.Rows(0)(0).ToString()
            txtCodDesp.Enabled = False
            txtrutcli.Text = tabla.Rows(0)(1).ToString()
            txtcliente.Text = tabla.Rows(0)(2).ToString()
            dt_fecha.Value = devuelve_fecha(tabla.Rows(0)(3).ToString())
            txtcodigo.Text = tabla.Rows(0)(4).ToString()
            Dim sqlTemp As String = "SELECT   TOP(1) mov_TS, mov_TM, mov_TI FROM movpallet WHERE mov_doc='" + tabla.Rows(0)(4).ToString() + "' AND (mov_tipo='PD' OR mov_tipo='PR')"
            Dim tablatemp As DataTable = fnc.ListarTablasSQL(sqlTemp)
            Dim a, b, c, d As Double

            If tablatemp.Rows.Count > 0 Then
                t1.Text = tablatemp.Rows(0)(0).ToString()
                t2.Text = tablatemp.Rows(0)(1).ToString()
                t3.Text = tablatemp.Rows(0)(2).ToString()

                a = t1.Text
                b = t2.Text
                c = t3.Text
                d = (a + b + c) / 3
            End If

            tp.Text = d.ToString().Replace(",", ".")
            TimerAdicionales.Stop()

            txttotsopo.Text = tabla.Rows(0)(5).ToString()
            txttotcajas.Text = tabla.Rows(0)(6).ToString()
            txttotkilos.Text = tabla.Rows(0)(7).ToString()
            Txtchorut.Text = tabla.Rows(0)(8).ToString().Remove(8)
            txtchover.Text = tabla.Rows(0)(8).ToString().Chars(8)
            llamaChofer(tabla.Rows(0)(8).ToString())
            txtpatente.Text = tabla.Rows(0)(9).ToString()
            txtchoemp.Text = tabla.Rows(0)(10).ToString()
            TxtRampla.Text = tabla.Rows(0)(11).ToString()
            TxtSello.Text = tabla.Rows(0)(12).ToString()
            TxtHorometro.Text = tabla.Rows(0)(13).ToString()
            TxtObs.Text = tabla.Rows(0)(14).ToString()
            CbCarga.SelectedValue = Val(tabla.Rows(0)(15).ToString())
            txtorigen.Text = tabla.Rows(0)(16).ToString()
            txtorigend.Text = retorna_Origen(tabla.Rows(0)(16).ToString())
            txtGuiaCli.Text = tabla.Rows(0)(17).ToString()

            If tabla.Rows(0)(17).ToString() = "S/G" Or tabla.Rows(0)(17).ToString() = "" Then
                CbSinGuia.Checked = True
            Else
                CbSinGuia.Checked = False
                txtGuiaCli.Text = tabla.Rows(0)(17).ToString()
            End If

            CbSinGuia.Enabled = False
            TxtDestino.Text = tabla.Rows(0)(18).ToString()
            CbRecargo.Checked = tabla.Rows(0)(19).ToString()
            TxtContenedor.Text = tabla.Rows(0)(20).ToString()
            HoraTerm.Text = tabla.Rows(0)(21).ToString()
            TxtFolioPorteria.Text = tabla.Rows(0)(22).ToString()
            horaInic.Text = tabla.Rows(0)(23).ToString()
            Horalleg.Text = tabla.Rows(0)(24).ToString()
            txtResponsable.Text = fnc.DevuelveUsuario(tabla.Rows(0)(25).ToString())
            Panel1.Enabled = False
            BtnGuia.Enabled = False
            BtnOrigen.Enabled = False
            txtGuiaCli.Enabled = False
            CargaGrillaPred()
            btn_guardar.Enabled = False
            GroupBox1.Enabled = False
            txtcodigo.Enabled = False
            TabControl1.Enabled = True
            CARGA_SERVICIOS_ADICIONALES()

            'busca horario
            If DetaDespa.RowCount > 0 Then
                Dim SqlHorario As String = "SELECT Hor_SDI, Hor_SDT, Hor_FDI, Hor_FDT, cont_diagracia FROM " +
                    "contratosHorarios, contrato WHERE cont_codi=hor_contcod AND Hor_Contcod='" + DetaDespa.Rows(0).Cells("COD_CONT").Value.ToString() + "' "
                Dim tablahorario As DataTable = fnc.ListarTablasSQL(SqlHorario)
                If tablahorario.Rows.Count > 0 Then
                    LV_horini.Text = tablahorario.Rows(0)(0).ToString()
                    LV_ter.Text = tablahorario.Rows(0)(1).ToString()
                    SA_HorIni.Text = tablahorario.Rows(0)(2).ToString()
                    Sab_HorTer.Text = tablahorario.Rows(0)(3).ToString()
                    txtderecho.Text = tablahorario.Rows(0)(4).ToString()
                End If

            End If

            BtnImprimir.Enabled = True
            BtnImpGuia.Enabled = True

            'Buscar excento cobro estadía
            Dim sqlExcEst As String = "select Cobro_Excento from V_Despacho_Cobro_Estadia with(nolock) where Codigo_Despacho='" & txtCodDesp.Text.Trim & "'"
            Dim dtExcEst As New DataTable
            dtExcEst = fnc.ListarTablasSQL(sqlExcEst)

            If (dtExcEst.Rows.Count > 0) Then
                Dim ExcEst As Integer = CInt(dtExcEst.Rows(0).Item(0).ToString.Trim)
                If (ExcEst = "1") Then
                    chkSinCobEst.Checked = True
                Else
                    chkSinCobEst.Checked = False
                End If
            Else
                chkSinCobEst.Checked = False
            End If

            Dim EstDesp As String = tabla.Rows(0).Item("fdes_codvig").ToString.Trim

            If (EstDesp = "1") Then
                Lbl_EstadoGuia.Text = "NULO"
                Lbl_EstadoGuia.ForeColor = Color.Red
            Else
                Lbl_EstadoGuia.Text = "ACTIVO"
                Lbl_EstadoGuia.ForeColor = Color.Blue
            End If

            ' VES ENE 202
            txtSopAdic.Text = tabla.Rows(0).Item("fdes_numsopadic").ToString().Trim()
            txtSopAdicCodi.Text = tabla.Rows(0).Item("fdes_codsopadic").ToString().Trim()
            Dim sqlAdic As String = "SELECT  tsop_descr FROM tiposopo WHERE tsop_codi='" + txtSopAdicCodi.Text + "'"
            Dim tablaAdic As DataTable = fnc.ListarTablasSQL(sql)
            If tablaAdic.Rows.Count > 0 Then
                txtsopadicnombre.Text = tablaAdic.Rows(0)(0)
            End If
        Else
            'MsgBox("El codigo de despacho ingresado no existe", MsgBoxStyle.Critical, "Aviso")
            'txtCodDesp.Text = ""
            'txtCodDesp.Enabled = True
            'txtCodDesp.Focus()

            Dim sqlVerifNul As String = "SP_Despachos_Nulos_Validar '" & txtCodDesp.Text.Trim & "'"
            Dim dtVerifNul As New DataTable
            dtVerifNul = fnc.ListarTablasSQL(sqlVerifNul)

            If (dtVerifNul.Rows.Count > 0) Then
                Dim RespVerifNul As Integer = CInt(dtVerifNul.Rows(0).Item(0).ToString.Trim)

                If (RespVerifNul = -2 Or RespVerifNul = -4) Then
                    MsgBox("El Despacho ingresado no existe", MsgBoxStyle.Critical, "Aviso")
                    txtCodDesp.Text = ""
                    txtCodDesp.Focus()
                ElseIf (RespVerifNul = -3) Then
                    MsgBox("Despacho con problemas. Favor avisar a informática.", MsgBoxStyle.Critical, "Aviso")
                    txtCodDesp.Text = ""
                    txtCodDesp.Focus()
                ElseIf (RespVerifNul = 1) Then
                    Busca_Despacho(txtCodDesp.Text.Trim)
                ElseIf (RespVerifNul = -1) Then
                    MsgBox("Ocurrió un error al buscar el Despacho.", MsgBoxStyle.Critical, "Aviso")
                    txtCodDesp.Text = ""
                    txtCodDesp.Focus()
                End If
            End If
        End If
    End Sub

    Sub CARGA_SERVICIOS_ADICIONALES()

        rbprecisa.Checked = False

        Dim sqlVasGui As String = "select top 1 Cobro_Guia=isnull(Cobro_Guia,0) from Despachos_Guia_Cliente with(nolock) where Codigo_Despacho='" & txtCodDesp.Text.Trim & "'"
        Dim dtVasGui As New DataTable
        dtVasGui = fnc.ListarTablasSQL(sqlVasGui)
        If (dtVasGui.Rows.Count > 0) Then
            If (dtVasGui.Rows(0).Item(0).ToString.Trim = "1") Then
                rbcliente.Checked = True
                Rbsinguia.Checked = False
            Else
                rbcliente.Checked = False
                Rbsinguia.Checked = True
            End If
        Else
            rbcliente.Checked = False
            Rbsinguia.Checked = True
        End If

        'DataAdicionales.DataSource = fnc.ListarTablasSQL("SELECT  'False' AS Dvas_Est, Serv_Cod, Serv_Nom,'0' AS Dvas_Unid,'0' AS dvas_cajas,'0' AS dvas_kilos FROM FacServicios WHERE Serv_Incluir = '2' OR Serv_Incluir = '3' ORDER BY Serv_ordd ASC")

        'Dim Cobros_Automaticos As String = "SELECT dvas_est, Serv_cod, Serv_Nom, Dvas_Unid, Dvas_Cajas, REPLACE(Dvas_Kilos,',','.') AS Dvas_Kilos  " +
        '            "FROM FacVas, FacVasDeta , FacServicios WHERE Dvas_ServCod=Serv_Cod AND Vas_cod=Dvas_VasCod AND Vas_dcto='" + lblcodigo.Text + "' AND " +
        '            "Vas_TipDoc='1' ORDER BY serv_OrdD ASC"

        'Dim sql_addview As String = "CREATE VIEW GESVW_SERVRECE " +
        '                    "AS " +
        '                    "SELECT Dvas_VasCod VAS, Serv_Cod SERV, Serv_Nom NOM,  Dvas_Unid UNID, Dvas_Cajas CAJAS, REPLACE(Dvas_Kilos,',','.')  AS KILOS " +
        '                    "FROM FacVasDeta RIGHT JOIN FacServicios ON Serv_Cod=Dvas_ServCod " +
        '                    "WHERE  Dvas_VasCod=(SELECT Vas_cod FROM FacVas WHERE Vas_Dcto='" + lblcodigo.Text + "' AND Vas_TipDoc='1') AND " +
        '                    "Serv_OrdD>0"

        Dim sql_addview As String = "CREATE VIEW GESVW_SERVRECE " +
                            "AS " +
                            "SELECT Dvas_VasCod VAS, Serv_Cod SERV, Serv_Nom NOM,  Dvas_Unid UNID, Dvas_Cajas CAJAS, REPLACE(Dvas_Kilos,',','.')  AS KILOS " +
                            "FROM FacVasDeta RIGHT JOIN FacServicios ON Serv_Cod=Dvas_ServCod " +
                            "WHERE  Dvas_VasCod=(SELECT Vas_cod FROM FacVas WHERE Vas_Dcto='" + txtCodDesp.Text + "' AND Vas_TipDoc='1') AND " +
                            "Serv_OrdD>0"

        Dim sql_selectserv As String = " SELECT CASE  WHEN isnull(UNID,0)= 0  AND isnull(UNID,0)=0  AND isnull(UNID,0)=0 THEN 'False'  ELSE 'True' END AS dvas_est, " +
                                       "Serv_Cod , Serv_Nom, isnull(UNID,0) dvas_unid, isnull(CAJAS,0) Dvas_Cajas, REPLACE(isnull(KILOS,0),',','.') Dvas_kilos " +
                                       "FROM GESVW_SERVRECE vw RIGHT JOIN FacServicios se ON se.Serv_Cod=serv " +
                                       "WHERE  Serv_OrdD>0 ORDER BY Serv_OrdD"

        Dim sql_borra_view As String = "DROP VIEW GESVW_SERVRECE"


        fnc.MovimientoSQL(sql_addview)
        DataAdicionales.DataSource = fnc.ListarTablasSQL(sql_selectserv)
        fnc.MovimientoSQL(sql_borra_view)



        If DataAdicionales.Rows.Count > 0 Then
            'DataAdicionales.DataSource = fnc.ListarTablasSQL(Cobros_Automaticos)

            For i As Integer = 0 To DataAdicionales.Rows.Count - 1

                If DataAdicionales.Rows(i).Cells("cb").Value = True Then

                    If DataAdicionales.Rows(i).Cells("se").Value = "018" Then
                        CbCustodia.Checked = True
                        TxtCustodia.Text = DataAdicionales.Rows(i).Cells("un").Value
                    End If

                    If DataAdicionales.Rows(i).Cells("se").Value = "019" Then
                        Cb_Postura.Checked = True
                        TxtFilm.Text = DataAdicionales.Rows(i).Cells("un").Value
                    End If
                    If DataAdicionales.Rows(i).Cells("se").Value = "015" Then
                        CbRepa.Checked = True
                        TxtRepa.Text = DataAdicionales.Rows(i).Cells("un").Value
                    End If

                    'If DataAdicionales.Rows(i).Cells("se").Value = "033" Then
                    '    rbcliente.Checked = True
                    'End If

                    'If DataAdicionales.Rows(i).Cells("se").Value = "034" Then
                    '    rbprecisa.Checked = True
                    'End If

                    If (DataAdicionales.Rows(i).Cells("se").Value = "034" And Rbsinguia.Checked) Then
                        DataAdicionales.Rows(i).Cells("cb").Value = False
                    End If
                Else
                    If (DataAdicionales.Rows(i).Cells("se").Value = "034" And rbcliente.Checked) Then
                        DataAdicionales.Rows(i).Cells("cb").Value = True
                    End If
                End If
            Next
        Else

        End If

        Dim sqlCobEst As String = "select isnull(a.Cobro_Excento,'0') from V_Despacho_Cobro_Estadia with(nolock) where Codigo_Despacho='" & txtCodDesp.Text.Trim & "'"
        Dim dtCobEst As New DataTable
        dtCobEst = fnc.ListarTablasSQL(sqlVasGui)
        If (dtCobEst.Rows.Count > 0) Then
            If (dtCobEst.Rows(0).Item(0).ToString.Trim = "1") Then
                chkSinCobEst.Checked = True
            Else
                chkSinCobEst.Checked = False
            End If
        Else
            chkSinCobEst.Checked = False
        End If
    End Sub

    Private Sub btn_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        If txtcodigo.Text <> "" AndAlso txtcodigo.Enabled = False Then
            'If fnc.verificaExistencia("fichdespa", "fdes_codi", lblcodigo.Text) = False Then
            If fnc.verificaExistencia("fichdespa", "fdes_codi", txtCodDesp.Text) = False Then
                If MsgBox("Seguro de salir del despacho", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbYes Then
                    'CancelaCorrelativo("009", lblcodigo.Text)
                    CancelaCorrelativo("009", txtCodDesp.Text)

                    Dim sql As String = "UPDATE fichpred SET fpre_activa='0' WHERE fpre_codi='" + txtcodigo.Text + "'"
                    fnc.MovimientoSQL(sql)

                    Dim sqlcheck As String = "UPDATE zcheckList SET cl_estfrigo='0' WHERE cl_fol='" + TxtFolioPorteria.Text + "'"
                    fnc.MovimientoSQL(sqlcheck)

                    limpiarformulario()
                Else
                    Exit Sub
                End If
            Else
                Dim sql As String = "UPDATE fichpred SET fpre_activa='0' WHERE fpre_codi='" + txtcodigo.Text + "'"
                fnc.MovimientoSQL(sql)
                limpiarformulario()

            End If
        Else
            Dim sql As String = "UPDATE fichpred SET fpre_activa='0' WHERE fpre_codi='" + txtcodigo.Text + "'"
            fnc.MovimientoSQL(sql)
            limpiarformulario()

        End If
    End Sub

    Private Sub limpiarformulario()
        LimpiarCajas(GroupBox2)
        LimpiarCajas(GroupBox1)
        txtcodigo.Enabled = True
        For i As Integer = 0 To DetaDespa.Rows.Count - 1
            DetaDespa.Rows.RemoveAt(0)
        Next
        txttotsopo.Text = "0"
        txttotcajas.Text = "0"
        txttotkilos.Text = "0"
        'lblcodigo.Text = "0000000"
        txtCodDesp.Text = ""
        txtCodDesp.Enabled = True
        BtnGuia.Enabled = True
        BtnOrigen.Enabled = True
        CbSinGuia.Enabled = True
        CbSinGuia.Checked = False
        txtGuiaCli.Enabled = True
        dt_fecha.Value = devuelve_fecha(fnc.DevuelveFechaServidor())
        TxtObs.Text = "NO CONSTITUYE VENTA SOLO TRASLADO"
        txtorigen.Text = "10"
        txtorigend.Text = "DESPACHO A CLIENTE"
        BtnBuscar.Enabled = True
        TabControl1.Enabled = False
        TabControl1.SelectedIndex = 0
        CbRecargo.Checked = False
        TxtFolioPorteria.Text = ""
        dt_fecha.Enabled = False
        BtnImprimir.Enabled = False
        Button3.Enabled = True
        DataAdicionales.DataSource = fnc.ListarTablasSQL("SELECT  'False' AS Dvas_Est, Serv_Cod, Serv_Nom,'0' AS Dvas_Unid,'0' AS dvas_cajas,'0' AS dvas_kilos FROM FacServicios WHERE Serv_OrdD>0 ORDER BY Serv_ordd ASC")
        'txtGuiaCli.Text = "S/G"
        'txtGuiaCli.Enabled = False
        txtGuiaCli.Text = ""
        BtnImpGuia.Enabled = False

        TxtContenedor.Text = ""

        Lbl_EstadoGuia.Text = "ACTIVO"
        Lbl_EstadoGuia.ForeColor = Color.Gold

        ' VES ENE 2020
        txtSopAdic.Text = ""
        txtSopAdicCodi.Text = ""
        txtsopadicnombre.Text = ""
        txtSopAdic.Enabled = True
        Btn_buscasopadic.Enabled = True

        'MMO ABRIL 2020
        LblTitulo1.Visible = False
        LblTitulo2.Visible = False
        ProgressBar_GuardarDespacho.Value = 0
        ProgressBar_GuardarDespacho.Visible = False
        ProgressBar_Pallets.Value = 0
        ProgressBar_Pallets.Visible = False
        LblProgreso.Text = "0%"
        LblProgreso.Visible = False
        LblAlerta.Visible = False
        LblProcesados.Text = "xx"
        LblTot.Text = "/xx"
        LblProcesados.Visible = False
        LblTot.Visible = False
    End Sub

    Private Sub BtnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImprimir.Click

        'If lblcodigo.Text = "0000000" Then
        If txtCodDesp.Text = "" Or txtCodDesp.Text = "0000000" Then
            MsgBox("Debe guardar el formulario antes de imprimirlo", MsgBoxStyle.Critical, "Aviso")
        Else

            'If File.Exists("C:\Imagenlogo.jpg") Then
            'Else
            '    pblogo.Image.Save("C:\Imagenlogo.jpg", Drawing.Imaging.ImageFormat.Jpeg)
            'End If
            'If File.Exists("C:\Windows\Imagenlogo.jpg") Then
            'Else
            '    Dim imagen As New Bitmap(New Bitmap("C:\Imagenlogo.jpg"), 295, 76)
            '    imagen.Save("C:\Windows\Imagenlogo.jpg", System.Drawing.Imaging.ImageFormat.Jpeg)
            'End If


            'documentoimp = DateTime.Now.ToString("MM-dd-yy") + "Documento" + lblcodigo.Text
            documentoimp = DateTime.Now.ToString("MM-dd-yy") + "Documento" + txtCodDesp.Text


            Dim frm As Frm_MuestraReporte = New Frm_MuestraReporte
            frm.Text = "Asistente de informes - Guia Despacho"

            Dim report As New Rpt_GuiaDespacho
            'pblogo.Image.Save("C:\Imagenlogo.jpg", Drawing.Imaging.ImageFormat.Jpeg)

            'Dim RutaImagen As String
            'RutaImagen = "C:\Imagenlogo.jpg"

            '  Dim RutaImagen As String
            ' RutaImagen = "C:\Windows\Imagenlogo.jpg"
            ' Ds2.imagen.AddimagenRow(ImageToByte(pblogo.Image))

            ' report.Subreports(0).SetDataSource(Ds2)

            '  report.SetParameterValue("RutaImagen", RutaImagen.ToString)

            '  report.SetParameterValue("RutaImagen", RutaImagen.ToString)

            report.SetDatabaseLogon(Usuario_ODBC, Pass_ODBC)
            'report.SetParameterValue("codigo", lblcodigo.Text)
            report.SetParameterValue("codigo", txtCodDesp.Text)

            frm.Contenedor.ReportSource = report
            frm.ShowDialog()
        End If

    End Sub

    Private Sub txtcodigo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcodigo.KeyPress

        If e.KeyChar = ChrW(13) Then
            If RealizarAccion("003", "006") = False Then
                txtcodigo.Text = ""
                Exit Sub
            End If
            RetornaInfoPreDespacho(CerosAnteriorString(txtcodigo.Text, 7))
            If txtcodigo.Enabled = False Then
                TimerAdicionales.Start()
                BtnBuscar.Enabled = False
                TabControl1.Enabled = True
            End If
        Else
            SoloNumeros(sender, e)
        End If
    End Sub

    Private Sub Frm_Despacho_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        'If e.KeyCode = Keys.F2 AndAlso fnc.verificaExistencia("fichdespa", "fdes_codi", lblcodigo.Text) = True Then
        If e.KeyCode = Keys.F2 AndAlso fnc.verificaExistencia("fichdespa", "fdes_codi", txtCodDesp.Text) = True Then

            'If devuelve_fecha(dt_fecha.Value) <> devuelve_fecha(fnc.DevuelveFechaServidor) Then
            '    If RealizarAccion("003", "007") = False Then
            '        Exit Sub
            '    End If
            'Else
            '    If RealizarAccion("003", "060") = False Then
            '        Exit Sub
            '    End If
            'End If

            Dim limite_modificar As DateTime = devuelve_fecha_Formato2(Convert.ToDateTime(dt_fecha.Value).AddDays(1)) + " 13:00:00"
            Dim fecha As DateTime = fnc.DevuelveFechaServidor()

            Dim validador As Integer = 0

            If devuelve_fecha(dt_fecha.Value) <> devuelve_fecha(fnc.DevuelveFechaServidor) Then
                'Full
                If RealizarAccion("003", "007") = True Then
                    validador += 1
                End If
            Else
                'POR EL DIA
                If RealizarAccion("003", "060", False) = True Then
                    validador += 1
                End If
            End If

            If (fecha < limite_modificar) Then
                If RealizarAccion("003", "063", False) = True Then
                    validador += 1
                End If
            End If

            If validador = 0 Then
                MsgBox("No podra modificar la guia", MsgBoxStyle.Critical, "Aviso")
                Exit Sub
            End If

            If MsgBox("Seguro de modificar la guía de despacho", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbYes Then
                GroupBox1.Enabled = True
                CbSinGuia.Enabled = True
                txtGuiaCli.Enabled = True
                BtnOrigen.Enabled = True
                btn_guardar.Enabled = True
                dt_fecha.Enabled = True
                TimerAdicionales.Start()
                Panel1.Enabled = True
            End If
        End If
    End Sub

    Sub activa_desactiva(ByVal i As Integer, ByVal true_false As Boolean)
        If true_false = True Then
            DataAdicionales.Rows(i).Cells("cb").Value = True
            DataAdicionales.Rows(i).Cells("un").Value = txttotsopo.Text
            DataAdicionales.Rows(i).Cells("caj").Value = txttotcajas.Text
            DataAdicionales.Rows(i).Cells("ki").Value = txttotkilos.Text
        Else
            DataAdicionales.Rows(i).Cells("cb").Value = False
            DataAdicionales.Rows(i).Cells("un").Value = "0"
            DataAdicionales.Rows(i).Cells("caj").Value = "0"
            DataAdicionales.Rows(i).Cells("ki").Value = "0"
        End If
    End Sub

    Sub activa_desactivaSolicitud(ByVal i As Integer, ByVal true_false As Boolean)
        Dim TraerSolicitud As String = "SELECT CAST(CONVERT(DATE,d.fpre_fecdes) As VARCHAR) fecha, " +
         "COUNT(*) AS pallet, MAX(d.fpre_totunidad) as unidad,MAX(d.fpre_totpeso) as peso,MAX(h.orden) as pedido " +
    "FROM Precisa.dbo.cincuenta a " +
   "INNER JOIN Precisa.dbo.fichpred d ON d.fpre_codi = a.folio " +
   "INNER JOIN Precisa.dbo.detapred e ON LEFT(e.dpre_codi,7) = d.fpre_codi " +
  " INNER JOIN Precisa.dbo.pedidos_ficha f ON f.orden = d.fpre_nped " +
  " INNER JOIN Precisa.dbo.pedidos_detalle g ON g.pallet = e.dpre_folio AND g.pedido IN (SELECT pedido " +
        "FROM precisa.dbo.pedidos_ficha" +
                         " WHERE (f.ordenconjunta IS NULL AND pedido = f.pedido) " +
                           " OR (f.ordenconjunta IS NOT NULL AND ordenconjunta = f.ordenconjunta)) " +
     " INNER JOIN Precisa.dbo.pedidos_ficha h ON h.pedido = g.pedido  " +
  " INNER JOIN Precisa.dbo.Pedidos_24_Horas i ON i.orden = h.orden " +
  " WHERE d.fpre_codi='" + txtcodigo.Text + "' group by d.fpre_fecdes"


        Dim tabla As DataTable = fnc.ListarTablasSQL(TraerSolicitud)

        If true_false = True Then
            DataAdicionales.Rows(i).Cells("cb").Value = True
            DataAdicionales.Rows(i).Cells("un").Value = tabla.Rows(0)(1).ToString()
            DataAdicionales.Rows(i).Cells("caj").Value = tabla.Rows(0)(2).ToString()
            DataAdicionales.Rows(i).Cells("ki").Value = tabla.Rows(0)(3).ToString()
        Else
            DataAdicionales.Rows(i).Cells("cb").Value = False
            DataAdicionales.Rows(i).Cells("un").Value = "0"
            DataAdicionales.Rows(i).Cells("caj").Value = "0"
            DataAdicionales.Rows(i).Cells("ki").Value = "0"
        End If
    End Sub

    Private Sub TimerAdicionales_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerAdicionales.Tick
        If txtcodigo.Enabled = False Then
            Try
                'If CbCarga.SelectedValue.ToString() = "1" Then
                '    activa_desactiva(3, True)
                'Else
                '    activa_desactiva(3, False)
                'End If

                'If CbRecargo.CheckState = CheckState.Checked Then
                '    activa_desactiva(6, True)
                'Else
                '    activa_desactiva(6, False)
                'End If

                'If CbCustodia.CheckState = CheckState.Checked Then
                '    If IsNumeric(TxtCustodia.Text) Then
                '        DataAdicionales.Rows(4).Cells("cb").Value = True
                '        DataAdicionales.Rows(4).Cells("un").Value = TxtCustodia.Text
                '        DataAdicionales.Rows(4).Cells("caj").Value = "0"
                '        DataAdicionales.Rows(4).Cells("ki").Value = "0"
                '    End If
                'Else
                '    activa_desactiva(4, False)
                'End If

                'If DataAdicionales.RowCount = 10 Then
                '    If CbRepa.Checked = True Then
                '        If IsNumeric(TxtRepa.Text) Then
                '            DataAdicionales.Rows(9).Cells("cb").Value = True
                '            DataAdicionales.Rows(9).Cells("un").Value = TxtRepa.Text
                '            DataAdicionales.Rows(9).Cells("caj").Value = "0"
                '            DataAdicionales.Rows(9).Cells("ki").Value = "0"
                '        Else
                '            activa_desactiva(9, False)
                '        End If
                '    Else
                '        activa_desactiva(9, False)
                '    End If
                'End If

                'If rbcliente.Checked = True Then
                '    DataAdicionales.Rows(7).Cells("cb").Value = True
                '    DataAdicionales.Rows(7).Cells("un").Value = "1"
                '    DataAdicionales.Rows(7).Cells("caj").Value = "0"
                '    DataAdicionales.Rows(7).Cells("ki").Value = "0"
                'Else
                '    activa_desactiva(7, False)
                'End If

                'If rbprecisa.Checked = True Then
                '    DataAdicionales.Rows(8).Cells("cb").Value = True
                '    DataAdicionales.Rows(8).Cells("un").Value = "1"
                '    DataAdicionales.Rows(8).Cells("caj").Value = "0"
                '    DataAdicionales.Rows(8).Cells("ki").Value = "0"
                'Else
                '    activa_desactiva(8, False)
                'End If

                'If Rbsinguia.Checked = True Then
                '    activa_desactiva(7, False)
                '    activa_desactiva(8, False)
                'End If

                'Dim suma_derecho As Integer = 0

                'For i As Integer = 0 To DetaDespa.Rows.Count - 1
                '    If IsNumeric(DetaDespa.Rows(i).Cells("dpre_estadia").Value.ToString()) Then
                '        If Val(DetaDespa.Rows(i).Cells("dpre_estadia").Value) < Val(txtderecho.Text) Then
                '            suma_derecho += 1
                '        End If
                '    End If
                'Next

                'If suma_derecho > 0 Then
                '    DataAdicionales.Rows(2).Cells("cb").Value = True
                '    DataAdicionales.Rows(2).Cells("un").Value = suma_derecho
                '    DataAdicionales.Rows(2).Cells("caj").Value = 0
                '    DataAdicionales.Rows(2).Cells("ki").Value = 0
                'Else
                '    activa_desactiva(2, False)
                'End If

                'If Cb_Postura.CheckState = CheckState.Checked Then
                '    If IsNumeric(TxtFilm.Text) Then
                '        DataAdicionales.Rows(5).Cells("cb").Value = True
                '        DataAdicionales.Rows(5).Cells("un").Value = TxtFilm.Text
                '        DataAdicionales.Rows(5).Cells("caj").Value = 0
                '        DataAdicionales.Rows(5).Cells("ki").Value = 0
                '    Else
                '        activa_desactiva(5, False)
                '    End If
                'Else
                '    activa_desactiva(5, False)
                'End If

                Dim CantPals As Integer = CInt(txttotsopo.Text.Trim)

                For i = 0 To DataAdicionales.RowCount - 1
                    Dim DescServ As String = DataAdicionales.Rows(i).Cells("de").Value.ToString.Trim

                    If (DescServ = "CARGA MANUAL") Then
                        If CbCarga.SelectedValue.ToString() = "1" Then
                            activa_desactiva(i, True)
                        Else
                            activa_desactiva(i, False)
                        End If
                    End If

                    If (DescServ = "SOLICITUD DE PRODUCTOS MENOR A 24 HORAS") Then
                        If CbRecargo.CheckState = CheckState.Checked Then
                            activa_desactivaSolicitud(i, True)
                        Else
                            activa_desactivaSolicitud(i, False)
                        End If
                    End If

                    If (DescServ = "ADMINISTRACION  DE PALLETS") Then
                        If CbCustodia.CheckState = CheckState.Checked Then
                            If IsNumeric(TxtCustodia.Text) Then
                                Dim CantCust As Integer = CInt(TxtCustodia.Text.Trim)

                                If (CantCust > CantPals) Then
                                    CantCust = CantPals
                                    TxtCustodia.Text = CantPals
                                End If

                                DataAdicionales.Rows(i).Cells("cb").Value = True
                                DataAdicionales.Rows(i).Cells("un").Value = CantCust
                                DataAdicionales.Rows(i).Cells("caj").Value = "0"
                                DataAdicionales.Rows(i).Cells("ki").Value = "0"
                            End If
                        Else
                            activa_desactiva(i, False)
                        End If
                    End If

                    If (DescServ = "REPALETIZADO") Then
                        If CbRepa.Checked = True Then
                            If (IsNumeric(TxtRepa.Text.Trim)) Then
                                Dim CantRepa As Integer = CInt(TxtRepa.Text.Trim)

                                If (CantRepa > CantPals) Then
                                    CantRepa = CantPals
                                    TxtRepa.Text = CantPals
                                End If

                                DataAdicionales.Rows(i).Cells("cb").Value = True
                                DataAdicionales.Rows(i).Cells("un").Value = CantRepa
                                DataAdicionales.Rows(i).Cells("caj").Value = "0"
                                DataAdicionales.Rows(i).Cells("ki").Value = "0"
                            Else
                                activa_desactiva(i, False)
                            End If
                        Else
                            activa_desactiva(i, False)
                        End If
                    End If

                    If (DescServ = "EMISION DE GUIAS DE DESPACHO CLIENTE") Then
                        If rbcliente.Checked = True Then
                            DataAdicionales.Rows(i).Cells("cb").Value = True
                            DataAdicionales.Rows(i).Cells("un").Value = "1"
                            DataAdicionales.Rows(i).Cells("caj").Value = "0"
                            DataAdicionales.Rows(i).Cells("ki").Value = "0"
                        Else
                            activa_desactiva(i, False)
                        End If
                    End If

                    If (DescServ = "DERECHO ENTRADA/ESTADIA (MENOR A 15 DIAS)") Then
                        Dim suma_derecho As Integer = 0

                        For j As Integer = 0 To DetaDespa.Rows.Count - 1
                            If IsNumeric(DetaDespa.Rows(j).Cells("dpre_estadia").Value.ToString()) Then
                                If Val(DetaDespa.Rows(j).Cells("dpre_estadia").Value) < Val(txtderecho.Text) Then
                                    suma_derecho += 1
                                End If
                            End If
                        Next

                        If suma_derecho > 0 And chkSinCobEst.Checked = False Then
                            DataAdicionales.Rows(i).Cells("cb").Value = True
                            DataAdicionales.Rows(i).Cells("un").Value = suma_derecho
                            DataAdicionales.Rows(i).Cells("caj").Value = 0
                            DataAdicionales.Rows(i).Cells("ki").Value = 0
                        Else
                            activa_desactiva(i, False)
                        End If
                    End If

                    If (DescServ = "POSTURA DE FILM") Then
                        If Cb_Postura.CheckState = CheckState.Checked Then
                            If IsNumeric(TxtFilm.Text) Then
                                Dim CantFilm As Integer = CInt(TxtFilm.Text.Trim)

                                If (CantFilm > CantPals) Then
                                    CantFilm = CantPals
                                    TxtFilm.Text = CantPals
                                End If

                                DataAdicionales.Rows(i).Cells("cb").Value = True
                                DataAdicionales.Rows(i).Cells("un").Value = CantFilm
                                DataAdicionales.Rows(i).Cells("caj").Value = 0
                                DataAdicionales.Rows(i).Cells("ki").Value = 0
                            Else
                                activa_desactiva(i, False)
                            End If
                        Else
                            activa_desactiva(i, False)
                        End If
                    End If
                Next







                '****************************************************** HORARIO HABILITACION *****************************************
                'Dim d As Integer = Weekday(fnc.DevuelveFechaServidor())

                'If d = 1 Then
                '    'Dia Domingo
                '    '  activa_desactiva(3, True)
                '    DataAdicionales.Rows(1).Cells("cb").Value = True
                '    DataAdicionales.Rows(1).Cells("un").Value = 1
                '    DataAdicionales.Rows(1).Cells("caj").Value = "0"
                '    DataAdicionales.Rows(1).Cells("ki").Value = "0"

                '    activa_desactiva(0, False)

                'ElseIf d = 7 Then
                '    'dia Sabado
                '    If Not (Convert.ToDateTime(Horalleg.Text) > Convert.ToDateTime(SA_HorIni.Text) AndAlso Convert.ToDateTime(Horalleg.Text) < Convert.ToDateTime(Sab_HorTer.Text)) Then
                '        DataAdicionales.Rows(1).Cells("cb").Value = True
                '        DataAdicionales.Rows(1).Cells("un").Value = 1
                '        DataAdicionales.Rows(1).Cells("caj").Value = "0"
                '        DataAdicionales.Rows(1).Cells("ki").Value = "0"
                '        activa_desactiva(0, False)
                '    End If
                'Else
                '    'Dia Semana
                '    If Not (Convert.ToDateTime(Horalleg.Text) > Convert.ToDateTime(LV_horini.Text) AndAlso Convert.ToDateTime(Horalleg.Text) < Convert.ToDateTime(LV_ter.Text)) Then
                '        DataAdicionales.Rows(0).Cells("cb").Value = True
                '        DataAdicionales.Rows(0).Cells("un").Value = 1
                '        DataAdicionales.Rows(0).Cells("caj").Value = "0"
                '        DataAdicionales.Rows(0).Cells("ki").Value = "0"
                '        activa_desactiva(1, False)
                '    End If
                'End If

            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub Cb_Postura_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cb_Postura.CheckedChanged
        If Cb_Postura.CheckState = CheckState.Checked Then
            TxtFilm.Visible = True
        Else
            TxtFilm.Visible = False
        End If
    End Sub

    Public Sub GuardaVasAutomatico()
        Dim cantidad As Integer = DataAdicionales.Rows.Count - 1
        Dim registros As Integer = 0

        If cantidad >= 0 Then
            'If fnc.verificaExistenciaCondicional("FacVas", "Vas_Dcto='" + lblcodigo.Text + "' AND Vas_TipDoc='1' ") = False Then
            If fnc.verificaExistenciaCondicional("FacVas", "Vas_Dcto='" + txtCodDesp.Text + "' AND Vas_TipDoc='1' ") = False Then

                Dim CODIGO_VAS As String = BuscaCorrelativo("012", 7)

                For i As Integer = 0 To cantidad
                    If DataAdicionales.Rows(i).Cells("un").Value.ToString() <> "0" Then
                        registros = registros + 1
                    End If
                Next
                If registros > 0 Then
                    'Dim sql As String = "INSERT INTO facvas(Vas_cod, vas_clirut, vas_cont, vas_dcto, vas_fecha, vas_guia, vas_estado, vas_seccion, vas_tipdoc, vas_emis, vas_usucod)" +
                    '                    "VALUES('" + CODIGO_VAS + "','" + txtrutcli.Text + "','" + DetaDespa.Rows(0).Cells("COD_CONT").Value.ToString() + "'," +
                    '                    "'" + lblcodigo.Text + "','" + devuelve_fecha(dt_fecha.Value) + "','" + txtGuiaCli.Text + "','0','0','1',GETDATE()," +
                    '                    "'" + Frm_Principal.InfoUsuario.Text + "')"

                    Dim sql As String = "INSERT INTO facvas(Vas_cod, vas_clirut, vas_cont, vas_dcto, vas_fecha, vas_guia, vas_estado, vas_seccion, vas_tipdoc, vas_emis, vas_usucod)" +
                                        "VALUES('" + CODIGO_VAS + "','" + txtrutcli.Text + "','" + DetaDespa.Rows(0).Cells("COD_CONT").Value.ToString() + "'," +
                                        "'" + txtCodDesp.Text + "','" + devuelve_fecha(dt_fecha.Value) + "','" + txtGuiaCli.Text + "','0','0','1',GETDATE()," +
                                        "'" + Frm_Principal.InfoUsuario.Text + "')"

                    If fnc.MovimientoSQL(sql) > 0 Then
                        For i As Integer = 0 To DataAdicionales.Rows.Count - 1
                            Dim DescServ As String = DataAdicionales.Rows(i).Cells("de").Value.ToString.Trim
                            If (DescServ <> "EMISION DE GUIAS DE DESPACHO CLIENTE" Or (DescServ = "EMISION DE GUIAS DE DESPACHO CLIENTE" And rbcliente.Checked)) Then
                                Dim true_false As Boolean = False

                                Dim Unidad1 As String = "0"
                                Dim Unidad2 As String = "0"
                                Dim Unidad3 As String = "0"

                                If Not IsNothing(DataAdicionales.Rows(i).Cells("un").Value) Then
                                    Unidad1 = DataAdicionales.Rows(i).Cells("un").Value.ToString().Replace(",", ".")
                                End If

                                If Not IsNothing(DataAdicionales.Rows(i).Cells("caj").Value) Then
                                    Unidad2 = DataAdicionales.Rows(i).Cells("caj").Value.ToString()
                                End If

                                If Not IsNothing(DataAdicionales.Rows(i).Cells("ki").Value) Then
                                    Unidad3 = DataAdicionales.Rows(i).Cells("ki").Value.ToString().Replace(",", ".")
                                End If
                                If Not IsNothing(DataAdicionales.Rows(i).Cells("cb").Value) Then
                                    true_false = DataAdicionales.Rows(i).Cells("cb").Value.ToString()
                                End If
                                If Unidad1 <> "0" Or Unidad2 <> "0" Or Unidad3 <> "0" Then
                                    Dim sqlDetalle As String = "INSERT INTO facVasDeta(Dvas_VasCod, dvas_est, Dvas_ServCod, Dvas_Unid, Dvas_Cajas, Dvas_Kilos, Dvas_cobrar)" +
                                                               "VALUES('" + CODIGO_VAS + "','" + true_false.ToString() + "','" + DataAdicionales.Rows(i).Cells("se").Value.ToString() + "'," +
                                                               "'" + Unidad1.ToString() + "','" + Unidad2.ToString() + "','" + Unidad3.ToString() + "','0')"

                                    fnc.MovimientoSQL(sqlDetalle)
                                End If
                            End If
                        Next
                    End If
                End If
            Else
                Dim CODIGO_VAS As String = ""

                For i As Integer = 0 To cantidad
                    If DataAdicionales.Rows(i).Cells("un").Value.ToString() <> "0" Then
                        registros = registros + 1
                    End If
                Next

                'Dim Consulta_Numero_Vas As String = "SELECT  Vas_cod  FROM FacVas WHERE Vas_Dcto='" + lblcodigo.Text + "' AND Vas_TipDoc='1'"
                Dim Consulta_Numero_Vas As String = "SELECT  Vas_cod  FROM FacVas WHERE Vas_Dcto='" + txtCodDesp.Text + "' AND Vas_TipDoc='1'"
                Dim tabla As DataTable = fnc.ListarTablasSQL(Consulta_Numero_Vas)

                If tabla.Rows.Count > 0 Then
                    CODIGO_VAS = tabla.Rows(0)(0).ToString()
                Else
                    CODIGO_VAS = BuscaCorrelativo("012", 7)
                End If


                If registros = 0 Then
                    Dim Elimina1 As String = "DELETE FROM FacVas WHERE vas_Cod='" + CODIGO_VAS + "' "
                    fnc.MovimientoSQL(Elimina1)
                    'Dim Elimina2 As String = "DELETE FROM FacVasDeta WHERE Dvas_VasCod='" + CODIGO_VAS + "' "
                    'fnc.MovimientoSQL(Elimina2)
                    'cancela correlativo
                    CancelaCorrelativo("012", CODIGO_VAS)
                    Exit Sub
                End If

                Dim Eliminar As String = "DELETE FROM FacVasDeta WHERE Dvas_VasCod='" + CODIGO_VAS + "' "
                fnc.MovimientoSQL(Eliminar)

                For i As Integer = 0 To DataAdicionales.Rows.Count - 1
                    Dim DescServ As String = DataAdicionales.Rows(i).Cells("de").Value.ToString.Trim
                    If (DescServ <> "EMISION DE GUIAS DE DESPACHO CLIENTE" Or (DescServ = "EMISION DE GUIAS DE DESPACHO CLIENTE" And rbcliente.Checked)) Then
                        Dim true_false As Boolean = False

                        Dim Unidad1 As String = "0"
                        Dim Unidad2 As String = "0"
                        Dim Unidad3 As String = "0"

                        If Not IsNothing(DataAdicionales.Rows(i).Cells("un").Value) Then
                            Unidad1 = DataAdicionales.Rows(i).Cells("un").Value.ToString().Replace(",", ".")
                        End If

                        If Not IsNothing(DataAdicionales.Rows(i).Cells("caj").Value) Then
                            Unidad2 = DataAdicionales.Rows(i).Cells("caj").Value.ToString()
                        End If

                        If Not IsNothing(DataAdicionales.Rows(i).Cells("ki").Value) Then
                            Unidad3 = DataAdicionales.Rows(i).Cells("ki").Value.ToString().Replace(",", ".")
                        End If

                        If Not IsNothing(DataAdicionales.Rows(i).Cells("cb").Value) Then
                            true_false = DataAdicionales.Rows(i).Cells("cb").Value.ToString()
                        End If

                        If Unidad1 <> "0" Or Unidad2 <> "0" Or Unidad3 <> "0" Then
                            Dim sqlDetalle As String = "INSERT INTO facVasDeta(Dvas_VasCod, dvas_est, Dvas_ServCod, Dvas_Unid, Dvas_Cajas, Dvas_Kilos, Dvas_cobrar)" +
                                                       "VALUES('" + CODIGO_VAS + "','" + true_false.ToString() + "','" + DataAdicionales.Rows(i).Cells("se").Value.ToString() + "'," +
                                                       "'" + Unidad1.ToString() + "','" + Unidad2.ToString() + "','" + Unidad3.ToString() + "','0')"

                            fnc.MovimientoSQL(sqlDetalle)
                        End If
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub Btn_AnulaGuia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_AnulaGuia.Click
        'If lblcodigo.Text <> "" Or lblcodigo.Text <> "0000000" Then
        If txtCodDesp.Text <> "" And txtCodDesp.Text <> "0000000" Then
            If (dt_fecha.Value = fnc.DevuelveFechaServidor()) Then
                If MsgBox("Seguro de volver el despacho a stock?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbYes Then

                End If

                ' VES FEB 2020: Se reversan los movimientos de arriendo/custodia/venta asociados al documento
                If fnc.MovimientoSQL("spReversarArriendoCustodiaPallets NULL,'" + txtCodDesp.Text + "'") = 0 Then
                    MsgBox("Ocurrio un error al intentar reversar movimientos de arriendo/custodia de pallets: " + lastSqlError, MsgBoxStyle.Critical, "Aviso")
                    Exit Sub
                End If
            Else
                MsgBox("Solo tiene un dia para realizar esta opcion", MsgBoxStyle.Information, "Aviso")
            End If
        End If
    End Sub

    Private Sub TxtCustodia_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCustodia.KeyPress,
        TxtRepa.KeyPress, TxtFilm.KeyPress
        SoloNumeros(sender, e)
    End Sub

    Private Sub CbArriendo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CbCustodia.CheckedChanged
        If CbCustodia.Checked = True Then
            TxtCustodia.Visible = True
        Else
            TxtCustodia.Visible = False
        End If
    End Sub

    Private Sub Cb_Repa_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CbRepa.CheckedChanged
        If CbRepa.CheckState = CheckState.Checked Then
            TxtRepa.Visible = True
        Else
            TxtRepa.Visible = False
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        DataAdicionales.DataSource = fnc.ListarTablasSQL("SELECT  'False' AS Dvas_Est, Serv_Cod, Serv_Nom,'0' AS Dvas_Unid,'0' AS dvas_cajas,'0' AS dvas_kilos FROM FacServicios WHERE Serv_OrdD>0 ORDER BY Serv_ordd ASC")
    End Sub

    Private Sub BtnImpGuia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImpGuia.Click
        If rbprecisa.Checked = True Then
            'Dim sql As String = "SELECT SUM(ddes_pallet) AS PALLET, mae_descr, SUM(ddes_unidades) AS Unidades, SUM(ddes_peso )AS peso " +
            '"FROM detadespa, maeprod WHERE ddes_codi LIKE '%" + lblcodigo.Text + "__%'  AND mae_codi=ddes_codpro GROUP BY mae_descr "

            Dim sql As String = "SELECT SUM(ddes_pallet) AS PALLET, mae_descr, SUM(ddes_unidades) AS Unidades, SUM(ddes_peso )AS peso " +
            "FROM detadespa, maeprod WHERE ddes_codi LIKE '%" + txtCodDesp.Text + "__%'  AND mae_codi=ddes_codpro GROUP BY mae_descr "

            Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

            If tabla.Rows.Count > 18 Then
                MsgBox("No se Puede Imprimir la guia ya que la cantidad de detalle sobrepasa el limite permitido (18)", MsgBoxStyle.Critical, "Aviso")
            Else
                ImprimirGuiaPrecisa()
            End If
        Else
            MsgBox("No esta seleccionada guia precisa en el despacho", MsgBoxStyle.Information, "Aviso")
        End If

    End Sub

    Sub ImprimirGuiaPrecisa()

        'Dim sql As String = "SELECT * FROM fichdespa WHERE fdes_codi='" + lblcodigo.Text + "'"

        Dim sql As String = "SELECT * FROM fichdespa WHERE fdes_codi='" + txtCodDesp.Text + "'"

        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

        If tabla.Rows.Count > 0 Then

            Dim frm As Frm_MuestraReporte = New Frm_MuestraReporte
            Dim report As New Rpt_GuiaPrecisa
            'report.SetParameterValue("codigo", lblcodigo.Text)
            report.SetParameterValue("codigo", txtCodDesp.Text)
            report.SetDatabaseLogon(Usuario_ODBC, Pass_ODBC)
            frm.Contenedor.ReportSource = report
            frm.ShowDialog()
        Else
            'MsgBox("La recepcion Nº " + lblcodigo.Text + " NO existe", MsgBoxStyle.Critical, "Aviso")
            MsgBox("La recepcion Nº " + txtCodDesp.Text + " NO existe", MsgBoxStyle.Critical, "Aviso")
        End If
    End Sub

    Private Sub btnAdjuntarFotos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdjuntarFotos.Click
        Dim frm As New Frm_AdjuntaFotoDespacho
        frm.Show()
        'frm.txtGuiaDespacho.Text = lblcodigo.Text
        frm.txtGuiaDespacho.Text = txtCodDesp.Text
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        'If lblcodigo.Text = "0000000" Then
        If txtCodDesp.Text = "" Or txtCodDesp.Text = "0000000" Then
        Else
            'foliopu = lblcodigo.Text
            foliopu = txtCodDesp.Text
            nomcli = txtcliente.Text
            Dim frm As New CreaInforme
            frm.ShowDialog(Frm_Principal)
        End If

        'If lblcodigo.Text = "0000000" Then
        '    MsgBox("Debe guardar el formulario antes de imprimirlo", MsgBoxStyle.Critical, "Aviso")
        'Else
        '    If txtrutcli.Text = "784836002" Or txtrutcli.Text = "799842408" Or txtrutcli.Text = "774763902" Or txtrutcli.Text = "79872410K" Then

        '        Dim frm As Frm_MuestraReporte = New Frm_MuestraReporte
        '        frm.Text = "Asistente de informes - Guia Despacho"

        '        Dim report As New AgrosuperDes

        '        report.SetDatabaseLogon(Usuario_ODBC, Pass_ODBC)
        '        report.SetParameterValue("codigo", lblcodigo.Text)

        '        frm.Contenedor.ReportSource = report
        '        frm.ShowDialog()

        '    End If
        'End If
    End Sub

    Private Sub txtcodigo_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtcodigo.KeyUp

    End Sub

    Private Sub DateTimeFormatInfo(ByVal p1 As Object)
        Throw New NotImplementedException
    End Sub

    Private Function fmt() As Object
        Throw New NotImplementedException
    End Function

    Private Sub GroupBox4_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox4.Enter

    End Sub

    'Private Sub txtCodDesp_GotFocus(sender As Object, e As System.EventArgs) Handles txtCodDesp.GotFocus
    '    Dim CodDesp = txtCodDesp.Text.Trim
    '    If (CodDesp = "0000000") Then
    '        txtCodDesp.Text = ""
    '    End If
    'End Sub

    Private Sub txtCodDesp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodDesp.KeyPress
        If e.KeyChar = ChrW(13) Then
            'txtCodDesp.Focus()
            Dim CodDesp = txtCodDesp.Text.Trim
            Busca_Despacho(CodDesp)
        End If
    End Sub

    'Private Sub txtCodDesp_LostFocus(sender As Object, e As System.EventArgs) Handles txtCodDesp.LostFocus
    '    Dim CodDesp = txtCodDesp.Text.Trim
    '    If (CodDesp = "") Then
    '        txtCodDesp.Text = "0000000"
    '    Else
    '        Busca_Despacho(CodDesp)
    '    End If
    'End Sub


    Private Sub txtSopAdic_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSopAdic.KeyPress
        SoloNumeros(sender, e)
    End Sub

    Private Sub Btn_buscasopadic_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_buscasopadic.Click
        Dim frm As New Lst_AyudaSoportantes
        frm.ShowDialog(Frm_Principal)
        txtSopAdicCodi.Text = Frm_Principal.buscavalor
        Dim sql As String = "SELECT tsop_descr FROM tiposopo WHERE tsop_codi='" + txtSopAdicCodi.Text + "'"

        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)
        If tabla.Rows.Count > 0 Then
            txtsopadicnombre.Text = tabla.Rows(0)(0)
        End If
        Frm_Principal.buscavalor = ""
    End Sub
End Class
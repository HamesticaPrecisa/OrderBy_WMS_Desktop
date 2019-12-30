Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Imports System.IO

Public Class Frm_GuiaPreDespachoAgregar

    Public palletcajas As String = ""
    Dim filaSeleccionada As String = ""
    Dim fnc As New Funciones
    '-----------------------

    Dim sumarono As String = ""
    Dim entro As String = ""
    Dim cliente As String = ""
    Dim estcheck As Boolean = True
    Dim ejec As String = "1"
    Dim olor As String = ""
    Dim hig As String = ""
    Dim cond As String = ""
    'Sub carga_pedidos()
    '    Dim sql As String = "SELECT * FROM Pedidos"
    'End Sub

    Function validacioningreso() As Boolean

        validacioningreso = True
        Dim mensaje As String = ""

        If txtrut.Text.Length <> 8 AndAlso verificador.Text.Length <> 1 Then
            mensaje = mensaje + "Ingresar rut cliente" + vbCrLf
            validacioningreso = False
        End If

        If IsNothing(CmboCarga.SelectedValue.ToString()) Then
            mensaje = mensaje + "Seleccionar tipo de carga" + vbCrLf
            validacioningreso = False
        End If

        If TxtSello.Text = "" Then
            mensaje = mensaje + "Ingresar sello" + vbCrLf
            validacioningreso = False
        End If
        If TxtContenedor.Text = "" Then
            mensaje = mensaje + "Ingresar Contenedor" + vbCrLf
            validacioningreso = False
        End If
        If Txtdestino.Text = "" Then
            mensaje = mensaje + "Ingresar Destino" + vbCrLf
            validacioningreso = False
        End If
        If Txtrampla.Text = "" Then
            mensaje = mensaje + "Ingresar Rampla" + vbCrLf
            validacioningreso = False
        End If


        If Not IsNumeric(Temp1.Text) Then
            mensaje = mensaje + "Ingresar temperatura 1 valida" + vbCrLf
            validacioningreso = False
        End If

        If Not IsNumeric(Temp1.Text) Then
            mensaje = mensaje + "Ingresar temperatura 2 valida" + vbCrLf
            validacioningreso = False
        End If

        If Not IsNumeric(Temp1.Text) Then
            mensaje = mensaje + "Ingresar temperatura 3 valida" + vbCrLf
            validacioningreso = False
        End If

        If Dgv.Rows.Count = 0 Then
            mensaje = mensaje + "Ingresar pallet al predespacho" + vbCrLf
            validacioningreso = False
        End If
        If olor = "" Then
            mensaje = mensaje + "Seleccione estado de camión (olor)" + vbCrLf
            validacioningreso = False
        End If
        If hig = "" Then
            mensaje = mensaje + "Seleccione estado de camión (higiene)" + vbCrLf
            validacioningreso = False
        End If
        If cond = "" Then
            mensaje = mensaje + "Seleccione estado de camión (condensación)" + vbCrLf
            validacioningreso = False
        End If
        'VALIDAR TODOS LOS SOPORTANTES DEL PEDIDO
        Dim tabla As DataTable = New DataTable
        'tabla = fnc.ListarTablasSQL("SELECT COUNT (*) FROM Pedidos_detalle pd INNER JOIN Pedidos_ficha pf ON pd.pedido=pf.pedido WHERE Orden='" + TxtNped.Text + "'")
        tabla = fnc.ListarTablasSQL("SELECT pallet FROM Pedidos_detalle pd INNER JOIN Pedidos_ficha pf ON pd.pedido=pf.pedido WHERE Orden='" + TxtNped.Text + "' group by pd.pallet")

        If tabla.Rows.Count > 0 Then
            'If Val(tabla.Rows(0)(0).ToString()) > Val(txtsoportantes.Text) Then
            If tabla.Rows.Count > Val(txtsoportantes.Text) Then
                MsgBox("Faltan agregar soportantes de este pedido", MsgBoxStyle.Critical, "Aviso")
                Return False
                Exit Function
            End If
        End If

        If validacioningreso = False Then
            MsgBox("Error al guardar debe ingresar " + vbCrLf + mensaje, MsgBoxStyle.Critical, "Aviso")
        End If

        Return validacioningreso
    End Function


    Private Sub olorextrañosub()

        If CheckBox3.Checked = True Then
            olor = "SI"
        ElseIf CheckBox2.Checked = True Then

            olor = "NO"
        End If

        If CheckBox5.Checked = True Then
            hig = "SI"
        ElseIf CheckBox4.Checked = True Then
            hig = "NO"
        End If


        If CheckBox7.Checked = True Then
            cond = "SI"
        ElseIf CheckBox6.Checked = True Then
            cond = "NO"
        End If

    End Sub


    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        Dim contadordetapred As Integer = 0
        olorextrañosub()

        If validacioningreso() = False Then
            Exit Sub
        End If
        If fnc.verificaExistencia("fichpred", "fpre_codi", lblcodigo.Text) = True Then
            MsgBox("El Pre-despacho ya esta grabado", MsgBoxStyle.Information, "Aviso")
            Exit Sub
        End If


        If MsgBox("¿Desea Terminar el pre-despacho?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbNo Then
            Exit Sub
        End If

        Dim con As New Conexion

        Try
            con.conectar()

            Dim _cmd As SqlCommand = New SqlCommand("PAG_INGPREDESPACHO", con.con)
            _cmd.CommandType = CommandType.StoredProcedure
            _cmd.Parameters.AddWithValue("@fpre_codi", lblcodigo.Text)
            _cmd.Parameters.AddWithValue("@fpre_rutcli", txtrut.Text + "" + verificador.Text)
            _cmd.Parameters.AddWithValue("@fpre_totsopo", txtsoportantes.Text)
            _cmd.Parameters.AddWithValue("@fpre_totunidad", txtcajas.Text)
            _cmd.Parameters.AddWithValue("@fpre_totpeso", txtkilos.Text.Replace(",", "."))
            _cmd.Parameters.AddWithValue("@fpre_codienca", Frm_Principal.InfoUsuario.Text)
            _cmd.Parameters.AddWithValue("@fpre_sello", TxtSello.Text)
            _cmd.Parameters.AddWithValue("@fpre_contenedor", TxtContenedor.Text)
            _cmd.Parameters.AddWithValue("@fpre_rampla", Txtrampla.Text)
            _cmd.Parameters.AddWithValue("@fpre_destino", Txtdestino.Text)
            _cmd.Parameters.AddWithValue("@fpre_observacion", TxtObs.Text)
            _cmd.Parameters.AddWithValue("@fpre_nped", TxtNped.Text)
            _cmd.Parameters.AddWithValue("@fpre_etiq", EstadoCheckBox(CbEtiq.CheckState))
            _cmd.Parameters.AddWithValue("@tipo", "PD")
            _cmd.Parameters.AddWithValue("@TS", Temp1.Text.Replace(",", "."))
            _cmd.Parameters.AddWithValue("@TM", Temp2.Text.Replace(",", "."))
            _cmd.Parameters.AddWithValue("@TI", Temp3.Text.Replace(",", "."))
            _cmd.Parameters.AddWithValue("@olor", olor)
            _cmd.Parameters.AddWithValue("@hig", hig)
            _cmd.Parameters.AddWithValue("@cond", cond)
            _cmd.Parameters.AddWithValue("@codbod", sucursalglo.Trim())
            Dim resp As Integer = 0
            Try
                resp = Convert.ToInt32(_cmd.ExecuteScalar())
            Catch ex As Exception
                resp = 1
            End Try

            If resp = 0 Then
                'Modificacion HAmestica Pedidos Locales 111218
                If (CbPedido.Checked) Then
                    Dim nped = TxtNped.Text.Trim
                    If (nped <> "0" And nped <> "") Then
                        Dim sqlConfirmPed As String = "SP_Pedido_Local_Confirmar '" & nped & "'"
                        If (fnc.MovimientoSQL(sqlConfirmPed) = 0) Then
                            MsgBox("Ocurrió un error al cerrar el Pedido Local.", MsgBoxStyle.Critical, "Error")
                        End If
                    End If
                End If
                'Fin modificacion HAmestica Pedidos Locales 111218


                '  Dim actualizacodbod As String = "UPDATE fichpred SET  cod_bod='" + sucursalglo + "' WHERE fpre_codi='" + lblcodigo.Text + "'"

                'fnc.MovimientoSQL(actualizacodbod)

                'VALIDAR SOLICITUD MENOR A 24 HRS. HAmestica 27/07/2018
                Dim sqlValid24Hrs = "select ExiPed=count(Orden) from Pedidos_24_Horas with(nolock) where Orden='" & TxtNped.Text.Trim & "'"
                Dim TabExiPed As DataTable = fnc.ListarTablasSQL(sqlValid24Hrs)
                Dim ExiPed = CInt(TabExiPed.Rows(0).Item(0).ToString.Trim)
                If (ExiPed > 0) Then
                    Dim sqlActPreDespMar = "update Pedidos_24_Horas set PreDesp_Marcado='1' where Orden='" & TxtNped.Text.Trim & "'"
                    fnc.MovimientoSQL(sqlActPreDespMar)

                    CBSI.Checked = True
                    Cb1.Checked = True

                    CBNO.Checked = False
                Else
                    CBSI.Checked = False
                    Cb1.Checked = False

                    CBNO.Checked = True
                End If
                'FIN VALIDAR SOLICITUD MENOR A 24 HRS. HAmestica 27/07/2018


                Dim cincuenta As String = ""
                If Cb1.Checked = True Then
                    cincuenta = "1"
                Else
                    cincuenta = "0"
                End If

                Dim sqlCincuenta As String = "SP_Cincuenta_Grabar '" & lblcodigo.Text.Trim & "','','" & txtrut.Text.Trim & verificador.Text.Trim & "','" & CmboCarga.SelectedValue.ToString.Trim & "','" & cincuenta & "','" & fnc.DevuelveFechaServidor().ToString.Trim & "'"
                fnc.MovimientoSQL(sqlCincuenta)

                'If fnc.verificaExistencia("cincuenta", "folio", lblcodigo.Text) = False Then

                '    Dim GuardaCincuenta As String = "INSERT INTO cincuenta(folio, despacho, cliente, carga, cincuenta, fecha)VALUES" & _
                '                                                   "('" + lblcodigo.Text + "','','" + txtrut.Text + "" + verificador.Text + "', " & _
                '                                                   "'" + CmboCarga.SelectedValue.ToString() + "','" + cincuenta + "','" + fnc.DevuelveFechaServidor().ToString() + "')"

                '    fnc.MovimientoSQL(GuardaCincuenta)
                'Else

                '    Dim ActualizaCincuenta As String = "UPDATE cincuenta SET  cliente='" + txtrut.Text + "" + verificador.Text + "', " & _
                '                                    "carga='" + CmboCarga.SelectedValue.ToString() + "', " & _
                '                                    "cincuenta='" + cincuenta + "' WHERE folio='" + lblcodigo.Text + "'"

                '    fnc.MovimientoSQL(ActualizaCincuenta)

                'End If

                MsgBox("Grabación exitosa", MsgBoxStyle.Information, "Aviso")
                txtpallet.Enabled = False
            ElseIf resp < 4 Then
                MsgBox("Error esperado al grabar la información", MsgBoxStyle.Critical, "Aviso")
            ElseIf resp = 4 Then
                MsgBox("El Pre-despacho ya esta grabado", MsgBoxStyle.Information, "Aviso")
            Else
                MsgBox("Error inesperado al grabar la información", MsgBoxStyle.Critical, "Aviso")
            End If
            con.cerrar()

        Catch ex As Exception
            MsgBox(ex.Message())
        End Try

    End Sub

    Public Sub Frm_GuiaPreDespachoAgregar_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs, Optional ByVal op As String = "") Handles MyBase.FormClosing
        Dim contador As Integer = 0
        If lblcodigo.Text = "" Then
            f_addPredespacho = False
            Exit Sub
        End If
        If fnc.verificaExistencia("fichpred", "fpre_codi", lblcodigo.Text) = False Then

            If MsgBox("Desea salir sin guardar el Predespacho?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = MsgBoxResult.No Then
                op = "NO"
            Else
                op = "SI"
                Timer1.Stop()
                Dim sqlDeta As String = "DELETE FROM TMPDETAPRED WHERE fpre_codi='" + lblcodigo.Text + "'"
                If fnc.MovimientoSQL(sqlDeta) > 0 Then
                    contador += 1
                End If

                Dim sqlFich As String = "DELETE FROM TMPFICHPRED WHERE fpre_codi='" + lblcodigo.Text + "'"
                If fnc.MovimientoSQL(sqlFich) > 0 Then
                    contador += 1
                End If

                Dim sqldetcaja As String = "DELETE FROM TMP_DETAPREDCAJAS WHERE folio='" + lblcodigo.Text + "'"
                If fnc.MovimientoSQL(sqldetcaja) > 0 Then
                    contador += 1
                End If
                If contador = 2 Then
                    If CbPedido.CheckState = 1 Then
                        'cambia estado pedcaja
                        'Dim sql_Actualiza As String = "UPDATE pedidos_ficha SET Ped_EstPred='0' " +
                        '                              "WHERE orden='" + TxtNped.Text + "'"
                        Dim sql_Actualiza As String = "SP_Pedidos_Estados_Actualizar '" & TxtNped.Text.Trim & "','P','0'"
                        fnc.MovimientoSQL(sql_Actualiza)

                    End If

                    'BLOQUEAR DE RACKDETA 
                    Dim _DESBLOQ_SOPORTANTE As String = "UPDATE rackdeta SET racd_estado='0', racd_pred='' WHERE racd_pred='" + lblcodigo.Text + "' "
                    fnc.MovimientoSQL(_DESBLOQ_SOPORTANTE)

                    If (TxtNped.Text <> "0") Then

                        Dim sqlMov As String = "DELETE FROM movcajas WHERE movc_codcaja in (SELECT dpre_caja FROM detapredcajas WHERE dpre_nped='" + TxtNped.Text + "') AND movc_tipo='PD'"
                        fnc.MovimientoSQL(sqlMov)

                        Dim sqlcajas As String = "DELETE FROM detapredcajas WHERE dpre_nped='" + TxtNped.Text + "'"
                        fnc.MovimientoSQL(sqlcajas)

                    End If


                    MsgBox("Temporales borrados exitosamente", MsgBoxStyle.Information, "Aviso")
                End If
            End If
        End If

        If op = "NO" Then
            e.Cancel = True
        ElseIf op = "SI" Then
            f_addPredespacho = False
            CancelaCorrelativo("007", lblcodigo.Text)
            Timer2.Stop()
        Else
            f_addPredespacho = False
        End If
    End Sub

    Private Sub btn_BuscaCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_BuscaCliente.Click
        Dim frm As New Lst_AyudaClientes
        frm.ShowDialog(Frm_Principal)

        If Frm_Principal.buscavalor.ToString <> "" Then
            Me.txtrut.Text = Frm_Principal.buscavalor.ToString.Remove(8)
            Me.verificador.Text = Frm_Principal.buscavalor.ToString().Chars(8)

            Dim SqlBusca As String = "SELECT cli_nomb, cli_estado FROM clientes WHERE " +
                "cli_rut='" + Frm_Principal.buscavalor.ToString() + "'"

            Dim tabla As DataTable = fnc.ListarTablasSQL(SqlBusca)

            If tabla.Rows.Count > 0 Then
                If tabla.Rows(0)(1).ToString() = "N" Then
                    MsgBox("El cliente seleccionado se encuentra bloqueado", MsgBoxStyle.Critical, "Aviso")
                    txtrut.Text = ""
                    verificador.Text = ""
                    Exit Sub
                End If
                CbPedido.Visible = True
                txtrut.Text = Frm_Principal.buscavalor.ToString().Remove(8)
                verificador.Text = Frm_Principal.buscavalor.ToString().Chars(8)
                txtclinombre.Text = tabla.Rows(0)(0).ToString()
                btn_BuscaCliente.Enabled = False
                txtrut.Enabled = False

                verificador.Enabled = False
            End If
        End If
        Frm_Principal.buscavalor = ""
        validapago()

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
    Private Sub Frm_GuiaPreDespacho_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Frm_Principal.buscavalor = ""

        cargaimg2()
        Dim sqlCombo As String = "SELECT  tcar_codi, tcar_descr FROM P_TipoCargaDescarga ORDER BY tcar_codi asc"
        CmboCarga.DataSource = fnc.ListarTablasSQL(sqlCombo)
        CmboCarga.DisplayMember = "tcar_descr"
        CmboCarga.ValueMember = "tcar_codi"
        Timer1.Start()
        Dt_fecha.Value = fnc.DevuelveFechaServidor()
        Timer2.Stop()

    End Sub

    Private Sub validarsiestapedido()

        Dim PCA As String = txtpallet.Text
        Dim pallet As String = PCA.Substring(1, PCA.Length - 1)
        Dim pallet2 As String = pallet.Substring(1, 18)
        Dim pallet3 As String = pallet2.Substring(1, 17)
        Dim pallet4 As String = pallet3.Substring(1, 16)
        Dim pallet5 As String = pallet4.Substring(1, 15)
        Dim pallet6 As String = pallet5.Substring(1, 14)
        Dim pallet7 As String = pallet6.Substring(1, 13)
        Dim pallet8 As String = pallet7.Substring(1, 12)
        Dim pallet9 As String = pallet8.Substring(1, 11)
        Dim pallet10 As String = pallet9.Substring(1, 9)

        Dim sqlped As String = "SELECT   CAJ_PCOD AS PALET,CAJ_COD as CAJA,CAJ_PED AS ESTADO FROM DetaReceCajas INNER JOIN rackdeta ON racd_codi=Caj_Pcod INNER JOIN detarece ON drec_codi=racd_codi WHERE CAJ_PCOD='" + pallet10 + "' and caj_ped='1' "
        'Dim sqlped As String = "SELECT * FROM detapedcajas where pc_numpal = '" + txtpallet.Text + "'"
        Dim tabla As DataTable = fnc.ListarTablasSQL(sqlped)

        If tabla.Rows.Count > 0 Then
            '"SELECT    CAJ_PCOD AS PALET,CAJ_COD as CAJA,CAJ_PED AS ESTADO FROM DetaReceCajas INNER JOIN rackdeta ON racd_codi=Caj_Pcod INNER JOIN detarece ON drec_codi=racd_codi WHERE CAJ_PCOD='" + txtpallet.Text + "'  "

            MsgBox("Este Pallet contiene cajas pedidas , Imposible PRe-Despachar")

        End If


    End Sub
    Private Sub validapago()

        Dim rut As String = txtrut.Text + verificador.Text
        Dim sqlped As String = "SELECT * FROM clientes where cli_rut='" + rut + "' and cli_blockges =1"
        'Dim sqlped As String = "SELECT * FROM detapedcajas where pc_numpal = '" + txtpallet.Text + "'"
        Dim tabla As DataTable = fnc.ListarTablasSQL(sqlped)

        If tabla.Rows.Count > 0 Then
            '"SELECT    CAJ_PCOD AS PALET,CAJ_COD as CAJA,CAJ_PED AS ESTADO FROM DetaReceCajas INNER JOIN rackdeta ON racd_codi=Caj_Pcod INNER JOIN detarece ON drec_codi=racd_codi WHERE CAJ_PCOD='" + txtpallet.Text + "'  "
            MsgBox("Este cliente se encuentra bloqueado por finanzas", MsgBoxStyle.Critical, "Aviso")
            limpiarformulario()

        End If
    End Sub
    Private Sub DataGridView1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv.CellClick

        If e.RowIndex > -1 AndAlso e.ColumnIndex = 0 AndAlso Lbl_EstadoGuia.Text <> "DESPACHADO" AndAlso _
            fnc.verificaExistenciaCondicional("TMPdetapred", "dpre_folio='" + Me.Dgv.Rows(e.RowIndex).Cells("pallet").Value.ToString() + "'") = True Then

            If MsgBox("Desea Eliminar el pallet seleccionado", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = MsgBoxResult.Yes Then

                Dim sql As String = "DELETE FROM TMPDETAPRED WHERE dpre_folio='" + Me.Dgv.Rows(e.RowIndex).Cells("pallet").Value.ToString() + "'"
                Dim sqldelet As String = "DELETE FROM tmp_detapredcajas WHERE pallet='" + Me.Dgv.Rows(e.RowIndex).Cells("pallet").Value.ToString() + "'"
                fnc.MovimientoSQL(sqldelet)
                If fnc.MovimientoSQL(sql) > 0 Then
                    MsgBox("Pallet eliminado", MsgBoxStyle.Information, "Aviso")

                    'BLOQUEAR DE RACKDETA 
                    Dim _DESBLOQ_SOPORTANTE As String = "UPDATE rackdeta SET racd_estado='0', racd_pred=''   WHERE racd_codi='" + Me.Dgv.Rows(e.RowIndex).Cells("pallet").Value.ToString() + "' "
                    fnc.MovimientoSQL(_DESBLOQ_SOPORTANTE)

                    filaSeleccionada = ""
                    CargaGrilla()
                End If
            End If
        End If
    End Sub

    Sub RescataTMPPreDespacho(ByVal codigopredespacho As String)

        Dim sqlFich As String = "SELECT fpre_rutcli, carga, cincuenta, cli_nomb, fpre_TS, fpre_TM, fpre_TI, fpre_sello, fpre_nped, fpre_etiq " & _
        "FROM TMPFICHPRED, clientes, cincuenta WHERE fpre_codi='" + codigopredespacho.ToString() + "' AND fpre_rutcli=cli_rut AND folio=fpre_codi"

        Dim tabla As DataTable = fnc.ListarTablasSQL(sqlFich)

        If tabla.Rows.Count > 0 Then
            lblcodigo.Text = codigopredespacho.ToString()
            txtrut.Text = tabla.Rows(0)(0).ToString().Remove(8, 1)
            verificador.Text = tabla.Rows(0)(0).ToString().Chars(8)
            CmboCarga.SelectedValue = Convert.ToInt32(tabla.Rows(0)(1).ToString())

            If tabla.Rows(0)(2).ToString() = "True" Then
                Cb1.Checked = True
            Else
                Cb1.Checked = False
            End If

            txtclinombre.Text = tabla.Rows(0)(3).ToString()
            Temp1.Text = tabla.Rows(0)(4).ToString()
            Temp2.Text = tabla.Rows(0)(5).ToString()
            Temp3.Text = tabla.Rows(0)(6).ToString()

            If Convert.ToInt32(tabla.Rows(0)(8).ToString()) > 0 Then
                estcheck = False
                CbPedido.Checked = True
                TxtNped.Text = tabla.Rows(0)(8).ToString()
                estcheck = True
            Else
                CbPedido.Checked = False
                TxtNped.Text = "0"
            End If

            If tabla.Rows(0)(9).ToString() = "1" Then
                CbEtiq.Checked = True
            End If

            CbPedido.Visible = True
            CbPedido.Enabled = False
            Timer1.Start()
            CargaGrilla()
            lblcodigo.Enabled = False
            GroupBox1.Enabled = True
            BtnGuardar.Enabled = True
        Else
            lblcodigo.Text = ""
            lblcodigo.Focus()
        End If

    End Sub

    Sub RescataPreDespacho(ByVal codigopredespacho As String)
        Dim sqlFich As String = ""

        If sucursalglo = "0" Then

            sqlFich = "SELECT fpre_rutcli, carga, cincuenta, cli_nomb, fpre_sello, fpre_contenedor, fpre_rampla, " +
    "fpre_destino, fpre_observacion, fpre_fecdes , mov_ts, mov_tm, mov_ti , fpre_tem, fpre_codvig, fpre_totsopo, fpre_totunidad, fpre_totpeso, fpre_nped " +
    "FROM FICHPRED, clientes, cincuenta , movpallet " +
    "WHERE fpre_rutcli=cli_rut AND folio=fpre_codi AND mov_doc=fpre_codi AND (mov_tipo='PD' OR mov_tipo='PR') AND fpre_codi='" + codigopredespacho + "' "
        Else

            sqlFich = "SELECT fpre_rutcli, carga, cincuenta, cli_nomb, fpre_sello, fpre_contenedor, fpre_rampla, " +
    "fpre_destino, fpre_observacion, fpre_fecdes , mov_ts, mov_tm, mov_ti , fpre_tem, fpre_codvig, fpre_totsopo, fpre_totunidad, fpre_totpeso, fpre_nped " +
    "FROM FICHPRED, clientes, cincuenta , movpallet " +
    "WHERE fpre_rutcli=cli_rut AND folio=fpre_codi AND mov_doc=fpre_codi AND (mov_tipo='PD' OR mov_tipo='PR') AND fpre_codi='" + codigopredespacho + "'  and fichpred.cod_bod=  '" + sucursalglo + "'"

        End If


        Dim tabla As DataTable = fnc.ListarTablasSQL(sqlFich)

        If tabla.Rows.Count > 0 Then

            lblcodigo.Text = codigopredespacho.ToString()
            txtrut.Text = tabla.Rows(0)(0).ToString().Remove(8, 1)
            verificador.Text = tabla.Rows(0)(0).ToString().Chars(8)
            CmboCarga.SelectedValue = Convert.ToInt32(tabla.Rows(0)(1).ToString())

            If tabla.Rows(0)(2).ToString() = "True" Then
                Cb1.Checked = True
            Else
                Cb1.Checked = False
            End If

            txtclinombre.Text = tabla.Rows(0)(3).ToString()
            TxtSello.Text = tabla.Rows(0)(4).ToString()
            TxtContenedor.Text = tabla.Rows(0)(5).ToString()
            Txtrampla.Text = tabla.Rows(0)(6).ToString()
            Txtdestino.Text = tabla.Rows(0)(7).ToString()
            TxtObs.Text = tabla.Rows(0)(8).ToString()

            If IsDate(tabla.Rows(0)(9).ToString()) Then
                Dt_fecha.Value = devuelve_fecha(tabla.Rows(0)(9).ToString())
            End If

            Temp1.Text = tabla.Rows(0)(10).ToString()
            Temp2.Text = tabla.Rows(0)(11).ToString()
            Temp3.Text = tabla.Rows(0)(12).ToString()
            tempprom.Text = tabla.Rows(0)(13).ToString()

            If tabla.Rows(0)(14).ToString() = "0" Then
                Lbl_EstadoGuia.Text = "ACTIVA"
                Lbl_EstadoGuia.ForeColor = Color.Blue
            ElseIf tabla.Rows(0)(14).ToString() = "1" Then
                Lbl_EstadoGuia.Text = "NULA"
                Lbl_EstadoGuia.ForeColor = Color.Red
            ElseIf tabla.Rows(0)(14).ToString() = "2" Then
                Lbl_EstadoGuia.Text = "DESPACHADO"
                Lbl_EstadoGuia.ForeColor = Color.Blue
            End If
            txtsoportantes.Text = tabla.Rows(0)(15).ToString()
            txtcajas.Text = tabla.Rows(0)(16).ToString()
            txtkilos.Text = tabla.Rows(0)(17).ToString()

            If Convert.ToInt32(tabla.Rows(0)(18).ToString()) > 0 Then
                estcheck = False
                CbPedido.Checked = True
                TxtNped.Text = tabla.Rows(0)(18).ToString()
                estcheck = True
            Else
                CbPedido.Checked = False
                TxtNped.Text = "0"
            End If

            CbPedido.Visible = True
            CbPedido.Enabled = False

            CargaGrillaPred()
            lblcodigo.Enabled = False
            txtpallet.Enabled = False
            BtnGuardar.Enabled = False
        Else
            MsgBox("El codigo ingresado no existe , comuníquese con informatica", MsgBoxStyle.Critical, "Aviso")
            lblcodigo.Text = ""
            lblcodigo.Focus()
        End If

    End Sub

    Private Sub txtcodigo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lblcodigo.KeyPress

        If e.KeyChar = ChrW(13) Then
            If lblcodigo.Text = "" Then
                If RealizarAccion("002", "004") = False Then
                    Exit Sub
                End If
                lblcodigo.Text = BuscaCorrelativo("007")

                Dim sqltemporal As String = "select top(1) tmps_codi, tmps_correl from Correlat_salto where tmps_correl='7' order by tmps_codi desc"
                Dim foliotemporal As New DataTable
                foliotemporal = fnc.ListarTablasSQL(sqltemporal)

                If foliotemporal.Rows.Count > 0 Then
                    Dim sqlcorrelat As String = "select a.cor_correact from correlat a with(nolock) where a.cor_codi='007'"
                    Dim correlat As New DataTable
                    correlat = fnc.ListarTablasSQL(sqlcorrelat)

                    Dim foliot As Integer = foliotemporal.Rows(0).Item(0)
                    Dim folioc As Integer = correlat.Rows(0).Item(0)

                    If foliot >= folioc Then
                        Dim sqlActualiza As String = "UPDATE correlat SET Cor_correact='" + (Convert.ToInt32(lblcodigo.Text) + 1).ToString() + "' " & _
                        "WHERE cor_codi='007'"
                        fnc.MovimientoSQL(sqlActualiza)
                    End If
                Else
                    Dim sqlActualiza As String = "UPDATE correlat SET Cor_correact='" + (Convert.ToInt32(lblcodigo.Text) + 1).ToString() + "' " & _
                        "WHERE cor_codi='007'"
                    fnc.MovimientoSQL(sqlActualiza)
                End If

                


                BtnBuscar.Enabled = False
                lblcodigo.Enabled = False
                GroupBox1.Enabled = True
                BtnGuardar.Enabled = True
                btn_BuscaCliente.Enabled = True
                CbPedido.Visible = False
            Else
                lblcodigo.Text = CerosAnteriorString(lblcodigo.Text, 7)
                If fnc.verificaExistencia("fichpred", "fpre_codi", lblcodigo.Text) = False Then
                    RescataTMPPreDespacho(lblcodigo.Text)
                Else
                    RescataPreDespacho(lblcodigo.Text)
                End If

            End If
        Else
            SoloNumeros(sender, e)
        End If
    End Sub

    Private Sub verificador_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles verificador.KeyPress
        If e.KeyChar = ChrW(13) Then
            If txtrut.Text.Length = 8 AndAlso verificador.Text.Length = 1 Then
                If fnc.verificaExistencia("clientes", "cli_rut", txtrut.Text + "" + verificador.Text) = True Then

                    Dim sql As String = "SELECT cli_nomb, cli_estado FROM clientes WHERE cli_rut='" + txtrut.Text + "" + verificador.Text + "'"
                    Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

                    If tabla.Rows.Count > 0 Then
                        If tabla.Rows(0)(1).ToString() = "N" Then
                            MsgBox("El rut ingresado se encuentra bloqueado", MsgBoxStyle.Critical, "Aviso")
                            Exit Sub
                        End If
                        txtclinombre.Text = tabla.Rows(0)(0).ToString()
                        txtrut.Enabled = False
                        verificador.Enabled = False
                        btn_BuscaCliente.Enabled = False
                        CbPedido.Visible = True
                    End If


                Else
                    MsgBox("El rut ingresado no esta ingresado", MsgBoxStyle.Critical, "Aviso")
                End If

            Else
                MsgBox("Rut incompleto", MsgBoxStyle.Information, "Aviso")

            End If
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        Try
            If Convert.ToInt32(TxtNped.Text) > 0 AndAlso GroupBox1.Enabled = True Then
                Label10.Visible = True
                Lblpalletsped.Visible = True
            Else
                Label10.Visible = False
                Lblpalletsped.Visible = False
            End If
        Catch ex As Exception

        End Try


        Try

            If txtrut.Text.Length >= 8 AndAlso verificador.Text.Length = 1 AndAlso CmboCarga.SelectedValue.ToString() <> Nothing _
            AndAlso IsNumeric(Temp1.Text) AndAlso IsNumeric(Temp2.Text) AndAlso IsNumeric(Temp3.Text) Then

                If fnc.verificaExistencia("fichpred", "fpre_codi", lblcodigo.Text) = True Then
                    Exit Sub
                End If

                'Dim cincuenta As String = ""
                'If Cb1.Checked = True Then
                '    cincuenta = "True"
                'Else
                '    cincuenta = "False"
                'End If

                'If fnc.verificaExistencia("cincuenta", "folio", lblcodigo.Text) = False Then

                '    Dim GuardaCincuenta As String = "INSERT INTO cincuenta(folio, despacho, cliente, carga, cincuenta, fecha)VALUES" & _
                '                                                   "('" + lblcodigo.Text + "','','" + txtrut.Text + "" + verificador.Text + "', " & _
                '                                                   "'" + CmboCarga.SelectedValue.ToString() + "','" + cincuenta + "','" + fnc.DevuelveFechaServidor().ToString() + "')"

                '    fnc.MovimientoSQL(GuardaCincuenta)
                'Else

                '    Dim ActualizaCincuenta As String = "UPDATE cincuenta SET  cliente='" + txtrut.Text + "" + verificador.Text + "', " & _
                '                                    "carga='" + CmboCarga.SelectedValue.ToString() + "', " & _
                '                                    "cincuenta='" + cincuenta + "' WHERE folio='" + lblcodigo.Text + "'"

                '    fnc.MovimientoSQL(ActualizaCincuenta)

                'End If


                If fnc.verificaExistencia("TMPFICHPRED", "fpre_codi", lblcodigo.Text) = False Then

                    Dim sql As String = "INSERT INTO TMPFICHPRED(fpre_codi, fpre_rutcli, fpre_horades, fpre_fecdes, " & _
                    "fpre_totsopo, fpre_totunidad, fpre_totpeso, fpre_codienca, fpre_activa, fpre_fechact, fpre_codvig, " & _
                    "fpre_radio, fpre_tipo, fpre_proceso, fpre_sello, fpre_tem, fpre_TS, fpre_TM, fpre_TI, fpre_rutcond, fpre_gdespa, fpre_anden, fpre_nped,estc_olor,estc_hig,estc_cond )" & _
                    "VALUES('" + lblcodigo.Text + "','" + txtrut.Text + "" + verificador.Text + "','" + DevuelveHora() + "', " & _
                    "'" + devuelve_fecha(fnc.DevuelveFechaServidor()) + "','" + txtsoportantes.Text + "','" + txtcajas.Text + "','" + txtkilos.Text.Replace(",", ".") + "', " & _
                    "'" + CerosAnteriorString(Frm_Principal.InfoUsuario.Text, 3) + "','1','" + devuelve_fecha(fnc.DevuelveFechaServidor()) + "','0','0','0','0','" + TxtSello.Text + "', " & _
                    "'" + tempprom.Text.Replace(",", ".") + "','" + Temp1.Text.Replace(",", ".") + "','" + Temp2.Text.Replace(",", ".") + "', " & _
                    "'" + Temp3.Text.Replace(",", ".") + "','000000000','0','0','" + TxtNped.Text + "','" + olor + "','" + hig + "','" + cond + "')"

                    fnc.MovimientoSQL(sql)

                Else

                    Dim SqlModifica As String = "UPDATE TMPFICHPRED SET  fpre_rutcli='" + txtrut.Text + "" + verificador.Text + "', " & _
                    "fpre_fecdes='" + devuelve_fecha(fnc.DevuelveFechaServidor()) + "', " & _
                    "fpre_totsopo='" + txtsoportantes.Text + "', fpre_totunidad='" + txtcajas.Text + "', fpre_totpeso='" + txtkilos.Text.Replace(",", ".") + "', " & _
                    "fpre_codienca='" + CerosAnteriorString(Frm_Principal.InfoUsuario.Text, 3) + "', fpre_sello='" + TxtSello.Text + "', fpre_tem='" + tempprom.Text.Replace(",", ".") + "', " & _
                    "fpre_TS='" + Temp1.Text.Replace(",", ".") + "', fpre_TM='" + Temp2.Text.Replace(",", ".") + "', fpre_TI='" + Temp3.Text.Replace(",", ".") + "', fpre_nped='" + TxtNped.Text + "', " +
                    "fpre_etiq='" + EstadoCheckBox(CbEtiq.CheckState) + "' ,estc_olor='" + olor + "',estc_hig='" + hig + "',estc_cond='" + cond + "' WHERE fpre_codi='" + lblcodigo.Text + "'"

                    If fnc.MovimientoSQL(SqlModifica) = 0 Then
                        ' MsgBox("No actualiza fichpred", MsgBoxStyle.Information, "Aviso")
                    End If
                End If

                txtpallet.Enabled = True

            End If


            'If IsNumeric(Temp1.Text) AndAlso IsNumeric(Temp2.Text) AndAlso IsNumeric(Temp3.Text) Then
            '    Try
            '        Dim Prom As Double = (
            '                           ((Convert.ToDouble(Temp1.Text.Replace(".", ","))) + (Convert.ToDouble(Temp2.Text.Replace(".", ","))) + (Convert.ToDouble(Temp3.Text.Replace(".", ",")))) / 3)


            '        tempprom.Text = Math.Round(Prom, 1)
            '    Catch ex As Exception

            '    End Try


            'End If

        Catch ex As Exception

        End Try



    End Sub

    Sub calcTempProm()
        Try
            Dim tem1 As String = Temp1.Text.Trim
            Dim tem1Frm As Double = 0
            If (Not Double.TryParse(tem1, tem1Frm)) Then
                tem1Frm = 0
            End If

            Dim tem2 As String = Temp2.Text.Trim
            Dim tem2Frm As Double = 0
            If (Not Double.TryParse(tem2, tem2Frm)) Then
                tem2Frm = 0
            End If

            Dim tem3 As String = Temp3.Text.Trim
            Dim tem3Frm As Double = 0
            If (Not Double.TryParse(tem3, tem3Frm)) Then
                tem3Frm = 0
            End If

            Dim temProm As Double = 0

            temProm = Math.Round(((tem1Frm + tem2Frm + tem3Frm) / 3), 1)

            tempprom.Text = temProm
            txtpallet.Enabled = True
        Catch ex As Exception

        End Try
    End Sub

    Sub CargaGrilla()
        Dim sql As String = "SELECT dpre_folio , dpre_codpro, mae_descr AS prod, dpre_unidades, dpre_peso, dpre_camara, " +
                            "dpre_banda, dpre_colum, dpre_piso, dpre_nivel FROM TMPDETAPRED, maeprod WHERE mae_codi=dpre_codpro AND " +
                            "fpre_codi='" + lblcodigo.Text + "'"

        'Dim sql As String = ""

        'If (txtrut.Text.Trim = "96999710" And CbCant.Checked = False) Then
        '    sql = "SELECT dpre_folio,dpre_codpro,mae_descr AS prod,dpre_unidades=COUNT(c.Pallet),dpre_peso=round(((dpre_peso/dpre_unidades)*COUNT(c.Pallet)),2),dpre_camara,dpre_banda,dpre_colum,dpre_piso,dpre_nivel FROM TMPDETAPRED a with(nolock) inner join maeprod b with(nolock) on(a.dpre_codpro=b.mae_codi) inner join tmp_detapredcajas c with(nolock) on(a.dpre_folio=c.Pallet) WHERE fpre_codi='" & lblcodigo.Text.Trim & "' group by dpre_folio,dpre_codpro,mae_descr,dpre_peso,dpre_camara,dpre_banda,dpre_colum,dpre_piso,dpre_nivel,dpre_unidades"
        'Else
        '    sql = "SELECT dpre_folio , dpre_codpro, mae_descr AS prod, dpre_unidades, dpre_peso, dpre_camara, " +
        '            "dpre_banda, dpre_colum, dpre_piso, dpre_nivel FROM TMPDETAPRED, maeprod WHERE mae_codi=dpre_codpro AND " +
        '            "fpre_codi='" + lblcodigo.Text + "'"
        'End If

        Dgv.DataSource = fnc.ListarTablasSQL(sql)

        Dim sqlTotales As String = "SELECT SUM(dpre_unidades) AS Unidades, SUM(dpre_peso) AS Peso FROM TMPDETAPRED WHERE fpre_codi='" + lblcodigo.Text + "'"

        'Dim sqlTotales As String = ""

        'If (txtrut.Text.Trim = "96999710" And CbCant.Checked = False) Then
        '    sqlTotales = "SELECT COUNT(b.Pallet) AS Unidades,round(((dpre_peso/dpre_unidades)*COUNT(b.Pallet)),2) AS Peso FROM TMPDETAPRED a with(nolock) inner join tmp_detapredcajas b with(nolock) on(a.dpre_folio=b.Pallet) WHERE fpre_codi='" & lblcodigo.Text.Trim & "' group by dpre_peso,dpre_unidades"
        'Else
        '    sqlTotales = "SELECT SUM(dpre_unidades) AS Unidades, SUM(dpre_peso) AS Peso FROM TMPDETAPRED WHERE fpre_codi='" + lblcodigo.Text + "'"
        'End If

        Dim tablatotales As DataTable = fnc.ListarTablasSQL(sqlTotales)

        If tablatotales.Rows.Count > 0 Then
            txtsoportantes.Text = Dgv.Rows.Count.ToString()
            txtcajas.Text = tablatotales.Rows(0)(0).ToString()
            txtkilos.Text = tablatotales.Rows(0)(1).ToString()

            'If (txtrut.Text.Trim = "96999710" And CbCant.Checked = False) Then
            '    Dim nroSop = 0
            '    Dim totCaj As Integer = 0
            '    Dim totKg As Double = 0

            '    For i = 0 To tablatotales.Rows.Count - 1
            '        nroSop += 1
            '        totCaj += CInt(tablatotales.Rows(i)(0).ToString())
            '        totKg += CDbl(tablatotales.Rows(i)(1).ToString())
            '    Next

            '    txtsoportantes.Text = nroSop
            '    txtcajas.Text = totCaj
            '    txtkilos.Text = totKg
            'Else
            '    txtsoportantes.Text = Dgv.Rows.Count.ToString()
            '    txtcajas.Text = tablatotales.Rows(0)(0).ToString()
            '    txtkilos.Text = tablatotales.Rows(0)(1).ToString()
            'End If

            txtpallet.Text = ""
            txtpallet.Focus()
        End If
    End Sub

    Sub CargaGrillaPred()
        Dim sql As String = "SELECT dpre_folio , dpre_codpro, mae_descr AS prod, dpre_unidades, dpre_peso, dpre_camara, " +
                            "dpre_banda, dpre_colum, dpre_piso, dpre_nivel FROM DETAPRED, maeprod WHERE mae_codi=dpre_codpro AND " +
                            "dpre_codi LIKE '%" + lblcodigo.Text + "__%'"

        Dgv.DataSource = fnc.ListarTablasSQL(sql)

        'Dim sqlTotales As String = "SELECT SUM(dpre_unidades) AS Unidades, SUM(dpre_peso) AS Peso FROM TMPDETAPRED WHERE fpre_codi='" + lblcodigo.Text + "'"
        'Dim tablatotales As DataTable = fnc.ListarTablasSQL(sqlTotales)

        'If tablatotales.Rows.Count > 0 Then
        '    txtsoportantes.Text = DataGridView1.Rows.Count.ToString()
        '    txtcajas.Text = tablatotales.Rows(0)(0).ToString()
        '    txtkilos.Text = tablatotales.Rows(0)(1).ToString()
        '    txtpallet.Text = ""
        '    txtpallet.Focus()
        'End If

    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub btn_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        Dim contador As Integer = 0
        Lbl_EstadoGuia.Text = "ACTIVA"
        If lblcodigo.Text = "" Then
            Exit Sub
        End If
        If fnc.verificaExistencia("fichpred", "fpre_codi", lblcodigo.Text) = False AndAlso lblcodigo.Enabled = False Then

            If MsgBox("Desea salir sin guardar el Predespacho?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = MsgBoxResult.Yes Then
                Dim sqlDeta As String = "DELETE FROM TMPDETAPRED WHERE fpre_codi='" + lblcodigo.Text + "'"

                If fnc.MovimientoSQL(sqlDeta) > 0 Then
                    contador += 1
                End If

                Dim sqlFich As String = "DELETE FROM TMPFICHPRED WHERE fpre_codi='" + lblcodigo.Text + "'"

                If fnc.MovimientoSQL(sqlFich) > 0 Then
                    contador += 1
                End If

                Dim sqldetacaja As String = "DELETE FROM tmp_detapredcajas WHERE folio='" + lblcodigo.Text + "'"

                If fnc.MovimientoSQL(sqldetacaja) > 0 Then
                    contador += 1
                End If

                If contador = 2 Then

                    If CbPedido.CheckState = 1 Then
                        'Dim sql_Actualiza As String = "UPDATE pedidos_ficha SET Ped_EstPred='0' WHERE orden='" + TxtNped.Text + "'"
                        Dim sql_Actualiza As String = "SP_Pedidos_Estados_Actualizar '" & TxtNped.Text.Trim & "','P','0'"
                        fnc.MovimientoSQL(sql_Actualiza)
                    End If

                    'DESBLOQUEAR DE RACKDETA 
                    Dim _DESBLOQ_SOPORTANTE As String = "UPDATE rackdeta SET racd_estado='0', racd_pred=''   WHERE racd_pred='" + lblcodigo.Text + "' "
                    fnc.MovimientoSQL(_DESBLOQ_SOPORTANTE)

                    If (TxtNped.Text <> "0") Then

                        Dim sqlMov As String = "DELETE FROM movcajas WHERE movc_codcaja in (SELECT dpre_caja FROM detapredcajas WHERE dpre_nped='" + TxtNped.Text + "') AND movc_tipo='PD'"
                        fnc.MovimientoSQL(sqlMov)

                        Dim sqlcajas As String = "DELETE FROM detapredcajas WHERE dpre_nped='" + TxtNped.Text + "'"
                        fnc.MovimientoSQL(sqlcajas)

                    End If

                    CancelaCorrelativo("007", lblcodigo.Text)
                    limpiarformulario()
                Else
                    CancelaCorrelativo("007", lblcodigo.Text)
                    limpiarformulario()
                End If
            End If
        Else
            limpiarformulario()
        End If
    End Sub

    Private Sub limpiarformulario()
        BtnBuscar.Enabled = True
        lblcodigo.Enabled = True
        lblcodigo.Text = ""
        txtrut.Text = ""
        verificador.Text = ""
        txtclinombre.Text = ""
        CmboCarga.SelectedValue = 0
        Temp1.Text = ""
        Temp2.Text = ""
        Temp3.Text = ""
        CheckBox2.Checked = False
        CheckBox3.Checked = False
        CheckBox4.Checked = False
        CheckBox5.Checked = False
        CheckBox6.Checked = False
        CheckBox7.Checked = False
        TxtContenedor.Text = ""
        Txtrampla.Text = ""
        TxtSello.Text = ""
        Txtdestino.Text = ""
        txtsoportantes.Text = "0"
        txtcajas.Text = "0"
        txtkilos.Text = "0"
        Cb1.Checked = False
        For i As Integer = 0 To Dgv.Rows.Count - 1
            Dgv.Rows.RemoveAt(0)
        Next
        Timer2.Stop()
        Label10.Text = "SOPORTANTES DEL PEDIDO   "
        'CmboPedido.DataSource = New DataTable
        CbPedido.Enabled = True
        CbPedido.CheckState = 0
        'For i As Integer = 0 To CmboPedido.Items.Count - 1
        '    CmboPedido.Items.RemoveAt(0)
        'Next
        CbCant.Checked = True
        Cant.Visible = False
        GroupBox1.Enabled = False
        TxtNped.Text = "0"
        CbEtiq.Enabled = True
        CbEtiq.Checked = False
        CbCant.Enabled = True

        CbPedido.Enabled = True

        lblcodigo.Focus()

    End Sub

    ' ---------------------------------------------------------------------------------------------
    ' |                                    VALIDADOR DE OBJETOS                                   |
    ' ---------------------------------------------------------------------------------------------


    Private Sub txtrut_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtrut.KeyPress
        If e.KeyChar = ChrW(13) Then
            If Len(txtrut.Text) = 8 Then
                verificador.Focus()
            End If
        End If
    End Sub

    Private Sub Temp1_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Temp1.KeyUp
        If IsNumeric(Temp1.Text) Then
            Try
                If Convert.ToDouble(Temp1.Text.Replace(".", ",")) <= 0 AndAlso Convert.ToDouble(Temp1.Text.Replace(".", ",")) >= -25 Then
                    Temp1.BackColor = Color.White
                Else
                    Temp1.BackColor = Color.Red
                End If
            Catch ex As Exception
                Temp1.BackColor = Color.Red
            End Try
        Else
            Temp1.BackColor = Color.Red
        End If
    End Sub

    Private Sub Temp2_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Temp2.KeyUp
        If IsNumeric(Temp2.Text) Then
            Try
                If Convert.ToDouble(Temp2.Text.Replace(".", ",")) <= 0 AndAlso Convert.ToDouble(Temp2.Text.Replace(".", ",")) >= -25 Then
                    Temp2.BackColor = Color.White
                Else
                    Temp2.BackColor = Color.Red
                End If
            Catch ex As Exception
                Temp2.BackColor = Color.Red
            End Try
        Else
            Temp2.BackColor = Color.Red
        End If
    End Sub

    Private Sub Temp3_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Temp3.KeyUp
        If IsNumeric(Temp3.Text) Then
            Try
                If Convert.ToDouble(Temp3.Text.Replace(".", ",")) <= 0 AndAlso Convert.ToDouble(Temp3.Text.Replace(".", ",")) >= -25 Then
                    Temp3.BackColor = Color.White
                Else
                    Temp3.BackColor = Color.Red
                End If
            Catch ex As Exception
                Temp3.BackColor = Color.Red
            End Try
        Else
            Temp3.BackColor = Color.Red
        End If
        Timer1.Start()
    End Sub

    Private Sub Temp1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Temp1.KeyPress, Temp2.KeyPress, Temp3.KeyPress
        If (e.KeyChar = "." Or e.KeyChar = "," Or e.KeyChar = "-") Then
            Exit Sub
        Else
            SoloNumeros(sender, e)
        End If
        Timer1.Start()

    End Sub


    Private Sub txtpallet_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpallet.KeyPress
        If TxtNped.Text = "0" Then
            MsgBox("Seleccione Pedido Antes de continuar", MsgBoxStyle.Critical, "Aviso")
            txtpallet.Text = ""
        Else
            If e.KeyChar = ChrW(13) Then
                If txtpallet.Text.Length <> 20 Then
                    MsgBox("Código incorrecto", MsgBoxStyle.Critical, "Aviso")
                    txtpallet.Text = ""
                    Exit Sub
                Else








                    Dim PCA As String = txtpallet.Text
                    Dim pallet As String = PCA.Substring(1, PCA.Length - 1)
                    Dim pallet2 As String = pallet.Substring(1, 18)
                    Dim pallet3 As String = pallet2.Substring(1, 17)
                    Dim pallet4 As String = pallet3.Substring(1, 16)
                    Dim pallet5 As String = pallet4.Substring(1, 15)
                    Dim pallet6 As String = pallet5.Substring(1, 14)
                    Dim pallet7 As String = pallet6.Substring(1, 13)
                    Dim pallet8 As String = pallet7.Substring(1, 12)
                    Dim pallet9 As String = pallet8.Substring(1, 11)
                    Dim pallet10 As String = pallet9.Substring(1, 9)


                    If TxtNped.Text = "1" Then
                        Dim sqlp As String = "SELECT  orden ,pallet from vg_pedidosactivos WHERE pallet='" + pallet10 + "'"
                        Dim tablap As DataTable = fnc.ListarTablasSQL(sqlp)
                        If tablap.Rows.Count > 0 Then


                            Dim ordensu As String = tablap.Rows(0)(0).ToString()
                            MsgBox("Pallet contenido en un pedido activo =" + " " + ordensu, MsgBoxStyle.Critical, "Aviso")
                            txtpallet.Text = ""
                            Exit Sub

                        End If
                    End If




                    Dim sqlped As String = "SELECT   CAJ_PCOD AS PALET,CAJ_COD as CAJA,CAJ_PED AS ESTADO FROM DetaReceCajas INNER JOIN rackdeta ON racd_codi=Caj_Pcod INNER JOIN detarece ON drec_codi=racd_codi WHERE CAJ_PCOD='" + pallet10 + "' and caj_ped='1' "
                    'Dim sqlped As String = "SELECT * FROM detapedcajas where pc_numpal = '" + txtpallet.Text + "'"
                    Dim tabla As DataTable = fnc.ListarTablasSQL(sqlped)


                    If tabla.Rows.Count > 0 Then
                        '"SELECT    CAJ_PCOD AS PALET,CAJ_COD as CAJA,CAJ_PED AS ESTADO FROM DetaReceCajas INNER JOIN rackdeta ON racd_codi=Caj_Pcod INNER JOIN detarece ON drec_codi=racd_codi WHERE CAJ_PCOD='" + txtpallet.Text + "'  "
                        Dim sqlped2 As String = "SELECT   CAJ_PCOD AS PALET,CAJ_COD as CAJA,CAJ_PED AS ESTADO FROM DetaReceCajas INNER JOIN rackdeta ON racd_codi=Caj_Pcod INNER JOIN detarece ON drec_codi=racd_codi WHERE CAJ_PCOD='" + pallet10 + "' and caj_ped='0' "
                        Dim tabla3 As DataTable = fnc.ListarTablasSQL(sqlped2)
                        If tabla3.Rows.Count > 0 Then
                            ejec = "2"
                        Else
                            ejec = "1"

                        End If


                        If (ejec = "2") Then

                        Else


                            Dim Sqlpedido As String = "select dpc_codped from detapedcaja where dpc_numpal= '" + pallet10 + "'"
                            Dim tabla2 As DataTable = fnc.ListarTablasSQL(Sqlpedido)

                            Dim pedidostr As String = tabla2.Rows(0)(0).ToString()
                            MsgBox("Este Pallet Esta Contenido en el pedido " + pedidostr + ", Imposible PRE-Despachar", MsgBoxStyle.Critical, "Aviso")

                            Exit Sub




                        End If



                    End If

                End If

                If (Dgv.Rows.Count = 120) Then
                    MsgBox("No puede pre-despachar más de 120 pallets", MsgBoxStyle.Critical, "Aviso")
                    txtpallet.Text = ""
                    txtpallet.Focus()
                    Return
                ElseIf Cant.Text.Trim = "0" Then
                    MsgBox("No puede pre-despachar 0 cajas", MsgBoxStyle.Critical, "Aviso")
                    txtpallet.Text = ""
                    txtpallet.Focus()
                    Return
                End If


                'numero pallet corto
                Dim valor_pallet As String = txtpallet.Text.Remove(0, 10)
                valor_pallet = valor_pallet.Remove(9, 1)

                CbCant.Enabled = True

                ' bloquea cmbopedido
                ' CmboPedido.Enabled = False

                If fnc.verificaExistencia("DetaRece", "drec_codi", valor_pallet) = True Then ' si el pallet existe

                    CbPedido.Enabled = False
                    CbEtiq.Enabled = False

                    Dim sql_esta_bloqueado As String = "SELECT racd_estado FROM rackdeta WHERE racd_codi='" + valor_pallet.ToString() + "'"
                    Dim tabla_bloqueado As DataTable = fnc.ListarTablasSQL(sql_esta_bloqueado)

                    If tabla_bloqueado.Rows.Count > 0 Then
                        If Convert.ToInt32(tabla_bloqueado.Rows(0)(0).ToString()) > 2 AndAlso CbEtiq.Checked = False AndAlso Convert.ToInt32(tabla_bloqueado.Rows(0)(0).ToString()) <> 7 Then
                            MsgBox("Este soportante se encuentra bloqueado", MsgBoxStyle.Critical, "Aviso")
                            txtpallet.Text = ""
                            txtpallet.Focus()
                            Exit Sub
                        End If
                    End If

                    If fnc.verificaExistencia("rackdeta", "racd_codi", valor_pallet.ToString()) = True Then ' si el pallet esta en el stock, si no esta es porque se despacho

                        If CbPedido.CheckState = 1 Then
                            Dim esdelpedido As String = ""
                            If ordemconj.Text = "" Then

                                esdelpedido = "SELECT parcial, pd.pedido FROM pedidos_detalle AS pd INNER JOIN Pedidos_ficha AS pf ON " +
                                                            "pf.pedido=pd.pedido WHERE pallet='" + valor_pallet.ToString() + "' AND orden='" + TxtNped.Text + "'"
                            Else
                                esdelpedido = "SELECT parcial, pd.pedido FROM pedidos_detalle AS pd INNER JOIN Pedidos_ficha AS pf ON " +
                                                       "pf.pedido=pd.pedido WHERE pallet='" + valor_pallet.ToString() + "' AND ordenconjunta='" + ordemconj.Text + "'"

                            End If

                            'Dim esdelpedido As String = "SELECT parcial, pd.pedido FROM pedidos_detalle AS pd INNER JOIN Pedidos_ficha AS pf ON " +
                            '                            "pf.pedido=pd.pedido WHERE pallet='" + valor_pallet.ToString() + "' AND orden='" + TxtNped.Text + "'"

                            Dim tablacompleto As DataTable = fnc.ListarTablasSQL(esdelpedido)

                            ' mayor a 0 corresponde al pedido
                            If tablacompleto.Rows.Count > 0 Then

                                If tablacompleto.Rows(0)(0).ToString() = "1" Then

                                    'Verifica si corresponde al pedido de cajas
                                    Dim sql_veri As String = "SELECT pf.pedido, cajas, pc_tpoped FROM Pedidos_detalle pd INNER JOIN Pedidos_ficha pf ON pf.pedido=pd.pedido " +
                                                             "INNER JOIN pedcaja ON pd.pallet=pc_numpal AND pf.orden= pc_codped WHERE Orden='" + TxtNped.Text + "' AND pd.pallet='" + valor_pallet.ToString() + "'"

                                    Dim tabla_veri As DataTable = fnc.ListarTablasSQL(sql_veri)

                                    If tabla_veri.Rows.Count > 0 Then
                                        'caja normal
                                        If tabla_veri.Rows(0)(2).ToString() = "2" Then
                                            CbCant.CheckState = 0
                                            Cant.Text = tabla_veri.Rows(0)(1).ToString()
                                        ElseIf tabla_veri.Rows(0)(2).ToString() = "3" Then
                                            'caja especifica
                                            If fnc.verificaExistenciaCondicional("TMPDETAPRED", "dpre_folio='" + valor_pallet.ToString() + "' AND dpre_codvig='0' AND fpre_codi='" + lblcodigo.Text + "' AND dpre_CodPer='" + Frm_Principal.InfoUsuario.Text + "'") = True Then
                                                MsgBox("El pallet seleccionado se encuentra agregado a este pre-despacho", MsgBoxStyle.Critical, "Aviso")
                                                txtpallet.Text = ""
                                                Exit Sub
                                            End If

                                            Dim f As New Frm_CajasPedido
                                            f.numero_pedido = Convert.ToInt32(TxtNped.Text)
                                            f.numero_pallet = valor_pallet.ToString()
                                            f.ShowDialog(Frm_Principal)
                                            Dim numerocajas As String = Frm_Principal.buscavalor.ToString()

                                            If numerocajas = "" Then
                                                MsgBox("Debe registrar las cajas del soportante", MsgBoxStyle.Critical, "Aviso")
                                                Dim sqlElimina As String = "DELETE FROM detapredcajas WHERE dpre_npallet='" + valor_pallet.ToString() + "' AND dpre_nped='" + TxtNped.Text + "'"
                                                fnc.MovimientoSQL(sqlElimina)
                                                txtpallet.Text = ""
                                                Exit Sub
                                            Else
                                                CbCant.CheckState = 0
                                                Cant.Text = numerocajas.ToString()
                                            End If
                                        End If

                                    End If
                                End If
                            Else
                                'else no corresponde al pedido

                                'Preguntar si el pallet esta en otro pedido

                                Dim sql As String = "SELECT 'EN STOCK' AS MOV, racd_unidades FROM rackdeta WHERE  racd_codi='" + valor_pallet + "' " +
                                                     "UNION ALL " +
                                                     "SELECT 'PEDIDOS' AS MOV, isnull(SUM(cajas),0) AS CAJAS FROM Pedidos_detalle pd INNER JOIN Pedidos_ficha pf ON pd.pedido=pf.pedido WHERE codvig='0'  AND pallet='" + valor_pallet + "' AND Ped_EstPred!=3 AND orden<>'" + TxtNped.Text + "' AND terminado!=3 " +
                                                     "UNION ALL " +
                                                     "SELECT 'TEMPORAL' AS MOV, isnull(SUM(dpre_unidades),0) AS CAJAS  FROM TMPDETAPRED WHERE dpre_folio='" + valor_pallet + "' " +
                                                     "UNION ALL  " +
                                                     "SELECT 'PREDESPACHADOS' AS MOV, isnull(SUM(dpre_unidades),0) AS CAJAS  FROM detapred INNER JOIN fichpred ON fpre_codi=LEFT(dpre_codi,7) WHERE dpre_folio='" + valor_pallet + "' AND fpre_codvig<>'2'"


                                Dim tabla_consulta As DataTable = fnc.ListarTablasSQL(sql)


                                Dim cantidad_disponible As Integer = Convert.ToInt32(tabla_consulta.Rows(0)(1).ToString()) - (Convert.ToInt32(tabla_consulta.Rows(1)(1).ToString()) + Convert.ToInt32(tabla_consulta.Rows(2)(1).ToString()) + Convert.ToInt32(tabla_consulta.Rows(3)(1).ToString()))

                                If cantidad_disponible <= 0 Then
                                    MsgBox("El soportante no tiene cajas disponibles." + Environment.NewLine +
                                       "Stock " + tabla_consulta.Rows(0)(1).ToString() + Environment.NewLine +
                                       "Pedidos " + tabla_consulta.Rows(1)(1).ToString() + Environment.NewLine +
                                       "Temporal " + tabla_consulta.Rows(2)(1).ToString() + Environment.NewLine +
                                       "Pre-Despachados " + tabla_consulta.Rows(3)(1).ToString() + Environment.NewLine, MsgBoxStyle.Critical, "Aviso")
                                    txtpallet.Text = ""
                                    txtpallet.Focus()
                                    Exit Sub
                                Else

                                    If CbCant.Checked = True Then

                                        'Valido si existe en el pre-despacho
                                        If fnc.verificaExistenciaCondicional("TMPDETAPRED", "dpre_folio='" + valor_pallet.ToString() + "' AND dpre_codvig='0' AND dpre_CodPer='" + Frm_Principal.InfoUsuario.Text + "'") = True Then

                                            If fnc.verificaExistenciaCondicional("TMPDETAPRED", "dpre_folio='" + valor_pallet.ToString() + "' AND dpre_codvig='0' AND fpre_codi='" + lblcodigo.Text + "' AND dpre_CodPer='" + Frm_Principal.InfoUsuario.Text + "'") = True Then
                                                MsgBox("El pallet seleccionado se encuentra agregado a este pre-despacho", MsgBoxStyle.Critical, "Aviso")
                                                txtpallet.Text = ""
                                            Else
                                                MsgBox("El pallet seleccionado se encuentra agregado a un pre-despacho", MsgBoxStyle.Critical, "Aviso")
                                                txtpallet.Text = ""
                                            End If
                                            CbCant.CheckState = 1
                                            Exit Sub
                                        End If
                                        If TxtNped.Text = "1" Then

                                        Else
                                            MsgBox("El soportante no corresponde al pedido", MsgBoxStyle.Critical, "Aviso")
                                            txtpallet.Text = ""
                                            Exit Sub
                                        End If

                                        'If MsgBox("¿El soportante no corresponde al pedido pero tiene " + cantidad_disponible.ToString() + " cajas disponibles, las desea agregar?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbYes Then
                                        '    CbCant.Checked = False
                                        '    Cant.Text = cantidad_disponible.ToString()
                                        'Else
                                        '    CbCant.Checked = True
                                        '    txtpallet.Text = ""
                                        '    txtpallet.Focus()
                                        '    Exit Sub
                                        'End If
                                    Else
                                        'parte de cajas
                                        If IsNumeric(Cant.Text) Then
                                            If Convert.ToInt32(Cant.Text) > cantidad_disponible Then
                                                If MsgBox("¿El soportante tiene " + cantidad_disponible.ToString() + " cajas disponibles, las desea agregar?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbYes Then
                                                    CbCant.Checked = False
                                                    Cant.Text = cantidad_disponible.ToString()
                                                Else
                                                    CbCant.Checked = False
                                                    txtpallet.Text = ""
                                                    txtpallet.Focus()
                                                    Exit Sub
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        Else
                            'cantidad del pallet que tiene disponible
                            Dim omitir As Integer = 0

                            Dim sql As String = "SELECT 'EN STOCK' AS MOV, racd_unidades FROM rackdeta WHERE  racd_codi='" + valor_pallet + "' " +
                             "UNION ALL " +
                             "SELECT 'PEDIDOS' AS MOV, isnull(SUM(cajas),0) AS CAJAS FROM Pedidos_detalle pd INNER JOIN Pedidos_ficha pf ON pd.pedido=pf.pedido WHERE codvig='0'  AND pallet='  ' AND Ped_EstPred!=3 AND orden<>'" + TxtNped.Text + "' AND terminado!=3" +
                             "UNION ALL " +
                             "SELECT 'TEMPORAL' AS MOV, isnull(SUM(dpre_unidades),0) AS CAJAS  FROM TMPDETAPRED WHERE dpre_folio='" + valor_pallet + "' " +
                             "UNION ALL  " +
                             "SELECT 'PREDESPACHADOS' AS MOV, isnull(SUM(dpre_unidades),0) AS CAJAS  FROM detapred INNER JOIN fichpred ON fpre_codi=LEFT(dpre_codi,7) WHERE dpre_folio='" + valor_pallet + "' AND fpre_codvig<>'2'"



                            Dim tabla_consulta As DataTable = fnc.ListarTablasSQL(sql)

                            Dim cantidad_disponible As Integer = Convert.ToInt32(tabla_consulta.Rows(0)(1).ToString()) - (Convert.ToInt32(tabla_consulta.Rows(1)(1).ToString()) + Convert.ToInt32(tabla_consulta.Rows(2)(1).ToString()) + Convert.ToInt32(tabla_consulta.Rows(3)(1).ToString()))
                            'cantidad_disponible = cantidad_disponible * -1
                            If cantidad_disponible <= 0 Then

                                MsgBox("El soportante no tiene cajas disponibles." + Environment.NewLine +
                                       "Stock " + tabla_consulta.Rows(0)(1).ToString() + Environment.NewLine +
                                       "Pedidos " + tabla_consulta.Rows(1)(1).ToString() + Environment.NewLine +
                                       "Temporal " + tabla_consulta.Rows(2)(1).ToString() + Environment.NewLine +
                                       "Pre-Despachados " + tabla_consulta.Rows(3)(1).ToString() + Environment.NewLine, MsgBoxStyle.Critical, "Aviso")

                                txtpallet.Text = ""
                                txtpallet.Focus()
                                Exit Sub
                            Else
                                If CbCant.Checked = True Then

                                    'Valido si existe en el pre-despacho
                                    If fnc.verificaExistenciaCondicional("TMPDETAPRED", "dpre_folio='" + valor_pallet.ToString() + "' AND dpre_codvig='0' AND dpre_CodPer='" + Frm_Principal.InfoUsuario.Text + "'") = True Then

                                        If fnc.verificaExistenciaCondicional("TMPDETAPRED", "dpre_folio='" + valor_pallet.ToString() + "' AND dpre_codvig='0' AND fpre_codi='" + lblcodigo.Text + "' AND dpre_CodPer='" + Frm_Principal.InfoUsuario.Text + "'") = True Then
                                            MsgBox("El pallet seleccionado se encuentra agregado a este pre-despacho", MsgBoxStyle.Critical, "Aviso")
                                            txtpallet.Text = ""
                                            CbCant.CheckState = 1
                                            Exit Sub
                                        End If
                                    End If

                                    If cantidad_disponible <> tabla_consulta.Rows(0)(1).ToString() Then
                                        If MsgBox("¿El soportante tiene " + cantidad_disponible.ToString() + " cajas disponibles, las desea agregar?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbYes Then
                                            CbCant.Checked = False
                                            Cant.Text = cantidad_disponible.ToString()
                                        Else
                                            CbCant.Checked = True
                                            txtpallet.Text = ""
                                            txtpallet.Focus()
                                            Exit Sub
                                        End If
                                    End If

                                Else
                                    'parte de cajas
                                    If IsNumeric(Cant.Text) Then
                                        If Convert.ToInt32(Cant.Text) > cantidad_disponible Then
                                            If MsgBox("¿El soportante tiene " + cantidad_disponible.ToString() + " cajas disponibles, las desea agregar?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbYes Then
                                                CbCant.Checked = False
                                                Cant.Text = cantidad_disponible.ToString()
                                            Else
                                                CbCant.Checked = True
                                                txtpallet.Text = ""
                                                txtpallet.Focus()
                                                Exit Sub
                                            End If
                                        End If
                                    End If
                                End If

                                'If MsgBox("¿El soportante tiene " + cantidad_disponible.ToString() + " cajas disponibles, las desea agregar?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbYes Then
                                '    CbCant.Checked = False
                                '    Cant.Text = cantidad_disponible.ToString()
                                'Else
                                '    CbCant.Checked = False
                                '    txtpallet.Text = ""
                                '    txtpallet.Focus()
                                '    Exit Sub
                                'End If

                            End If
                        End If

                        '10017800000-0000158028

                        'selecciono el pallet , si existe y esta en stock consulto si corresponde al cliente
                        Dim sqlvalidapallet As String = "SELECT drec_codpro, drec_codsopo, drec_sopocli, racd_unidades, racd_peso, drec_rutcli, drec_contcli, " +
                            "drec_fecprod, drec_camara, drec_banda, drec_colum, drec_piso, drec_nivel, drec_almacen, drec_dcaja " +
                            "FROM detarece, rackdeta WHERE drec_codi=racd_codi AND drec_codi= '" + valor_pallet + "' AND drec_rutcli='" + txtrut.Text + verificador.Text + "'"

                        Dim cantidadEnPredespacho As Integer = 0 ' cantidad de cajas que estan en pre-despachos activos

                        Dim tabla_can As DataTable = fnc.ListarTablasSQL("SELECT SUM(dpre_unidades) FROM detapred, fichpred  " +
                                                                         "WHERE dpre_folio='" + valor_pallet + "' AND left(dpre_codi,7)=fpre_codi AND Fpre_codvig='0' ")

                        If tabla_can.Rows.Count > 0 Then
                            If IsNumeric(tabla_can.Rows(0)(0).ToString()) Then
                                cantidadEnPredespacho = tabla_can.Rows(0)(0).ToString()
                            End If
                        End If


                        Dim tabla As DataTable = fnc.ListarTablasSQL(sqlvalidapallet)

                        If tabla.Rows.Count > 0 Then 'si corresponde al cliente pasa el if **********************

                            If CbCant.Checked = False Then ' parte del pallet ***********************
                                If IsNumeric(Cant.Text) Then
                                    If Val(Cant.Text) <= Val(tabla.Rows(0)(3).ToString() - cantidadEnPredespacho) Then


                                        Dim kilosUnitario As Double = Convert.ToDouble(tabla.Rows(0)(4).ToString()) / Convert.ToDouble(tabla.Rows(0)(3).ToString())
                                        Dim Kilos As Double = FormatNumber(kilosUnitario * Convert.ToDouble(Cant.Text), 2)


                                        Dim sqlNumero As String = "SELECT MAX( CONVERT(NUMERIC(18,0),dpre_codi)) FROM TMPDETAPRED WHERE fpre_codi='" + lblcodigo.Text + "'"
                                        Dim tablaNumero As DataTable = fnc.ListarTablasSQL(sqlNumero)

                                        Dim numeropallet As String = "01"

                                        If IsNumeric(tablaNumero.Rows(0)(0).ToString()) Then
                                            numeropallet = (Convert.ToInt32(tablaNumero.Rows(0)(0).ToString()) + 1).ToString()
                                        End If


                                        If fnc.verificaExistenciaCondicional("TMPDETAPRED", "dpre_folio='" + valor_pallet.ToString() + "' AND dpre_codvig='0' AND dpre_CodPer='" + Frm_Principal.InfoUsuario.Text + "'") = True Then

                                            If fnc.verificaExistenciaCondicional("TMPDETAPRED", "dpre_folio='" + valor_pallet.ToString() + "' AND dpre_codvig='0' AND fpre_codi='" + lblcodigo.Text + "' AND dpre_CodPer='" + Frm_Principal.InfoUsuario.Text + "'") = True Then
                                                MsgBox("El pallet seleccionado se encuentra agregado a este pre-despacho", MsgBoxStyle.Critical, "Aviso")
                                                txtpallet.Text = ""
                                                'Else
                                                '    MsgBox("El pallet seleccionado se encuentra agregado a un pre-despacho", MsgBoxStyle.Critical, "Aviso")
                                                '    txtpallet.Text = ""
                                                CbCant.CheckState = 1
                                                Exit Sub
                                            End If

                                        End If
                                        Dim pallet_cod As String = "0"

                                        If Cant.Text = Val(tabla.Rows(0)(3).ToString() - cantidadEnPredespacho) Then
                                            pallet_cod = "1"
                                        End If

                                        If TxtNped.Text <> "1" Then

                                            Dim SQLCAJAS As String = "SELECT * " +
                                            "FROM VG_PEDIDODETALLE WHERE  pallet= '" + valor_pallet + "' AND orden='" + TxtNped.Text + "'"

                                            Dim CANTID As Integer = 0 ' cantidad de cajas que estan en pre-despachos activos

                                            Dim tabla_caj As DataTable = fnc.ListarTablasSQL(SQLCAJAS)

                                            If tabla_caj.Rows.Count > 0 Then

                                                CANTID = tabla_caj.Rows(0)(2).ToString()
                                                If Cant.Text > CANTID Then
                                                    MsgBox("La cantidad es mayor a la solicitada en pedido ", MsgBoxStyle.Critical, "Aviso")
                                                    txtpallet.Text = ""
                                                    Exit Sub

                                                End If

                                                If Cant.Text < CANTID Then
                                                    MsgBox("La cantidad de cajas es menor a las del pedido ", MsgBoxStyle.Information, "Aviso")
                                                    sumarono = "NO"

                                                End If
                                            End If

                                        End If

                                        If sumarono = "NO" Then
                                        Else

                                            confirmacant()
                                        End If





                                        Dim sql As String = "INSERT INTO TMPDETAPRED (fpre_codi, dpre_codi, dpre_codpro, dpre_codsopo, dpre_sopocli, " & _
                                                            "dpre_unidades, dpre_peso, dpre_fecdes, dpre_rutcli, dpre_contcli, dpre_fecprod, " & _
                                                            "dpre_camara, dpre_banda, dpre_colum, dpre_piso, dpre_nivel, dpre_almacen, " & _
                                                            "dpre_folio, dpre_activa, dpre_radio, dpre_track, dpre_codvig, dpre_pallet, " & _
                                                            "dpre_slot, dpre_TS, dpre_TM, dpre_TI, dpre_Ptr, dpre_Pick, dpre_CodPer, dpre_Hora, " & _
                                                            "dpre_fecn, dpre_ActUni, dpre_TotUni)" & _
                                                            "VALUES('" + lblcodigo.Text + "','" + CerosAnteriorString(numeropallet.ToString(), 2).ToString() + "','" + tabla.Rows(0)(0).ToString() + "'," & _
                                                            "'" + Val(tabla.Rows(0)(1).ToString()).ToString() + "','" + tabla.Rows(0)(2).ToString() + "','" + Cant.Text() + "', " & _
                                                            "'" + Kilos.ToString().Replace(",", ".") + "','" + devuelve_fecha(fnc.DevuelveFechaServidor()) + "','" + tabla.Rows(0)(5).ToString() + "', " & _
                                                            "'" + tabla.Rows(0)(6).ToString() + "','" + tabla.Rows(0)(7).ToString() + "','" + tabla.Rows(0)(8).ToString() + "', " & _
                                                            "'" + tabla.Rows(0)(9).ToString() + "','" + tabla.Rows(0)(10).ToString() + "','" + tabla.Rows(0)(11).ToString() + "', " & _
                                                            "'" + tabla.Rows(0)(12).ToString() + "','" + tabla.Rows(0)(13).ToString() + "','" + valor_pallet.ToString() + "', " & _
                                                            "'0','0','0','0','" + pallet_cod.ToString() + "','000','0','0','0','" + Val(numeropallet).ToString + "','0','" + Frm_Principal.InfoUsuario.Text + "','" + DevuelveHora() + "','" + devuelve_fecha(fnc.DevuelveFechaServidor()) + "'," & _
                                                            "'" + Cant.Text + "','" + Val(tabla.Rows(0)(3).ToString() - (cantidadEnPredespacho + Val(Cant.Text))).ToString() + "')"

                                        If fnc.MovimientoSQL(sql) > 0 Then
                                            CargaGrilla()
                                            txtpallet.Text = ""
                                            CbCant.CheckState = 1
                                            Cant.Text = ""
                                            Cant.Visible = False

                                            'BLOQUEAR DE RACKDETA 
                                            Dim _BLOQUEA_SOPORTANTE As String = "UPDATE rackdeta SET racd_estado='7', racd_pred='" + lblcodigo.Text + "' WHERE racd_codi='" + valor_pallet + "'"
                                            fnc.MovimientoSQL(_BLOQUEA_SOPORTANTE)

                                        End If
                                    Else
                                        MsgBox("La cantidad de cajas ingresadas es mayor a las disponibles en stock (" + _
                                               Val(tabla.Rows(0)(3).ToString() - cantidadEnPredespacho).ToString() + ")", MsgBoxStyle.Critical, "Aviso")
                                        txtpallet.Text = ""
                                    End If
                                Else
                                    MsgBox("Debe ingresar un número de cajas", MsgBoxStyle.Critical, "Aviso")
                                    txtpallet.Text = ""
                                End If
                            Else
                                'Pallet completo *******************************************

                                Dim CajasRestantes As Integer = Val(tabla.Rows(0)(3).ToString() - cantidadEnPredespacho)
                                Dim KilosRestantes As Double = CajasRestantes * (tabla.Rows(0)(4).ToString() / tabla.Rows(0)(3).ToString())

                                If CajasRestantes <= 0 Then
                                    MsgBox("No tiene cajas disponibles este soportante", MsgBoxStyle.Critical, "Aviso")
                                    txtpallet.Text = ""
                                    CbCant.CheckState = 1
                                    Exit Sub
                                End If

                                Dim sqlNumero As String = "SELECT MAX( CONVERT(NUMERIC(18,0),dpre_codi)) FROM TMPDETAPRED WHERE fpre_codi='" + lblcodigo.Text + "'"
                                Dim tablaNumero As DataTable = fnc.ListarTablasSQL(sqlNumero)

                                Dim numeropallet As String = "01"

                                If IsNumeric(tablaNumero.Rows(0)(0).ToString()) Then
                                    numeropallet = (Convert.ToInt32(tablaNumero.Rows(0)(0).ToString()) + 1).ToString()
                                End If

                                Dim usu_cod As String = Frm_Principal.InfoUsuario.Text

                                If fnc.verificaExistenciaCondicional("TMPDETAPRED", "dpre_folio='" + valor_pallet.ToString() + "' AND dpre_codvig='0'") = True Then
                                    If fnc.verificaExistenciaCondicional("TMPDETAPRED", "dpre_folio='" + valor_pallet.ToString() + "' AND dpre_codvig='0' AND fpre_codi='" + lblcodigo.Text + "'") = True Then
                                        MsgBox("El pallet seleccionado se encuentra agregado a este pre-despacho", MsgBoxStyle.Critical, "Aviso")
                                        txtpallet.Text = ""
                                        'Else
                                        '    MsgBox("El pallet seleccionado se encuentra agregado a un pre-despacho", MsgBoxStyle.Critical, "Aviso")
                                        '    txtpallet.Text = ""
                                    Else
                                        Dim sqlValidTmp As String = "select fpre_codi from TMPDETAPRED where dpre_folio='" + valor_pallet.ToString() + "'"
                                        Dim dtValidTmp As New DataTable
                                        dtValidTmp = fnc.ListarTablasSQL(sqlValidTmp)

                                        If (dtValidTmp.Rows.Count > 0) Then
                                            MsgBox("El pallet seleccionado se encuentra en pre-despacho " & dtValidTmp.Rows(0).Item(0).ToString.Trim & "", MsgBoxStyle.Critical, "Aviso")
                                        End If
                                    End If
                                    CbCant.CheckState = 1
                                    Exit Sub
                                End If

                                If TxtNped.Text <> "1" Then

                                    'Dim SQLCAJAS2 As String = "SELECT * " +
                                    '"FROM VG_PEDIDODETALLE  WHERE  pallet= '" + valor_pallet + "' AND orden='" + TxtNped.Text + "'"
                                    Dim SQLCAJAS2 As String = "SELECT * FROM VG_PEDIDODETALLE WHERE pallet='" + valor_pallet + "' AND (case when ordenconjunta is not null then ordenconjunta else convert(varchar,Orden) end) like '%" + TxtNped.Text.Trim + "%'"

                                    Dim CANTID2 As Integer = 0 ' cantidad de cajas que estan en pre-despachos activos

                                    Dim tabla_caj2 As DataTable = fnc.ListarTablasSQL(SQLCAJAS2)

                                    If tabla_caj2.Rows.Count > 0 Then

                                        CANTID2 = tabla_caj2.Rows(0)(2).ToString()


                                        If CANTID2 = CajasRestantes Then
                                        Else
                                            MsgBox("Pallet contiene picking sin lectura", MsgBoxStyle.Information, "Aviso")
                                            Dim kilosUnitario As Double = Convert.ToDouble(tabla.Rows(0)(4).ToString()) / Convert.ToDouble(tabla.Rows(0)(3).ToString())
                                            KilosRestantes = FormatNumber(kilosUnitario * CANTID2)

                                        End If
                                        CajasRestantes = CANTID2

                                    End If

                                End If
                                confirmacant()


                                If entro = "1" Then
                                    CajasRestantes = Cant.Text

                                End If




                                Dim sql As String = "INSERT INTO TMPDETAPRED (fpre_codi, dpre_codi, dpre_codpro, dpre_codsopo, dpre_sopocli, " & _
                                                    "dpre_unidades, dpre_peso, dpre_fecdes, dpre_rutcli, dpre_contcli, dpre_fecprod, " & _
                                                    "dpre_camara, dpre_banda, dpre_colum, dpre_piso, dpre_nivel, dpre_almacen, " & _
                                                    "dpre_folio, dpre_activa, dpre_radio, dpre_track, dpre_codvig, dpre_pallet, " & _
                                                    "dpre_slot, dpre_TS, dpre_TM, dpre_TI, dpre_Ptr, dpre_Pick, dpre_CodPer, dpre_Hora, " & _
                                                    "dpre_fecn, dpre_ActUni, dpre_TotUni)" & _
                                                    "VALUES('" + lblcodigo.Text + "','" + CerosAnteriorString(numeropallet.ToString(), 2).ToString() + "','" + tabla.Rows(0)(0).ToString() + "'," & _
                                                    "'" + Val(tabla.Rows(0)(1).ToString()).ToString() + "','" + tabla.Rows(0)(2).ToString() + "','" + CajasRestantes.ToString() + "', " & _
                                                    "'" + KilosRestantes.ToString().Replace(",", ".") + "','" + devuelve_fecha(fnc.DevuelveFechaServidor()) + "','" + tabla.Rows(0)(5).ToString() + "', " & _
                                                    "'" + tabla.Rows(0)(6).ToString() + "','" + tabla.Rows(0)(7).ToString() + "','" + tabla.Rows(0)(8).ToString() + "', " & _
                                                    "'" + tabla.Rows(0)(9).ToString() + "','" + tabla.Rows(0)(10).ToString() + "','" + tabla.Rows(0)(11).ToString() + "', " & _
                                                    "'" + tabla.Rows(0)(12).ToString() + "','" + tabla.Rows(0)(13).ToString() + "','" + valor_pallet.ToString() + "', " & _
                                                    "'0','0','0','0','1','000','0','0','0','" + Val(numeropallet).ToString + "','0','" + usu_cod + "','" + DevuelveHora() + "','" + devuelve_fecha(fnc.DevuelveFechaServidor()) + "'," & _
                                                    "'" + CajasRestantes.ToString + "','0')"

                                If fnc.MovimientoSQL(sql) > 0 Then
                                    CargaGrilla()
                                    txtpallet.Text = ""

                                    'BLOQUEAR DE RACKDETA 
                                    Dim _BLOQUEA_SOPORTANTE As String = "UPDATE rackdeta SET racd_estado='7', racd_pred='" + lblcodigo.Text + "' WHERE racd_codi='" + valor_pallet + "'"
                                    fnc.MovimientoSQL(_BLOQUEA_SOPORTANTE)

                                End If
                                'FINNNNNN *****************************************
                            End If
                        Else
                            MsgBox("El pallet ingresado no es del cliente seleccionado", MsgBoxStyle.Critical, "Aviso")
                            txtpallet.Text = ""
                        End If
                    Else
                        MsgBox("El pallet ya se despacho con anterioridad", MsgBoxStyle.Critical, "Aviso")
                        txtpallet.Text = ""
                    End If
                Else
                    MsgBox("El número de pallet no existe", MsgBoxStyle.Critical, "Aviso")
                    txtpallet.Text = ""
                End If

                If CbEtiq.Enabled = False AndAlso CbEtiq.Checked = True Then
                    CbCant.Enabled = False
                    Cant.Visible = False
                End If

                CbCant.CheckState = 1
            Else
                SoloNumeros(sender, e)
            End If

        End If

    End Sub
    Private Sub confirmacant()

        Dim PCA As String = txtpallet.Text
        Dim pallet As String = PCA.Substring(1, PCA.Length - 1)
        Dim pallet2 As String = pallet.Substring(1, 18)
        Dim pallet3 As String = pallet2.Substring(1, 17)
        Dim pallet4 As String = pallet3.Substring(1, 16)
        Dim pallet5 As String = pallet4.Substring(1, 15)
        Dim pallet6 As String = pallet5.Substring(1, 14)
        Dim pallet7 As String = pallet6.Substring(1, 13)
        Dim pallet8 As String = pallet7.Substring(1, 12)
        Dim pallet9 As String = pallet8.Substring(1, 11)
        Dim pallet10 As String = pallet9.Substring(1, 9)

        Dim sqlcajaa As String = "select ordenconjunta from Pedidos_ficha where orden ='" + TxtNped.Text.Trim() + "' "
        Dim tabla_cajaa As DataTable = fnc.ListarTablasSQL(sqlcajaa)

        If tabla_cajaa.Rows.Count > 0 Then

            'VG_PEDIDOSUNIDOSCANT

            Dim CONJ As String = tabla_cajaa.Rows(0)(0).ToString()


            Dim sqlconjunto As String = "select sumacant from VG_PEDIDOSUNIDOSCANT where ordenconjunta ='" + CONJ + "' and pallet ='" + pallet10 + "' "
            Dim tabla_conj As DataTable = fnc.ListarTablasSQL(sqlconjunto)

            If tabla_conj.Rows.Count > 0 Then


                Cant.Text = tabla_conj.Rows(0)(0).ToString()
                entro = "1"
            Else


                entro = ""

            End If

        End If
    End Sub
    Private Sub Cant_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Cant.KeyPress
        SoloNumeros(sender, e)
    End Sub

    Private Sub CbCant_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CbCant.CheckedChanged


        If txtrut.Text = "96999710" Then
            If txtpallet.Text <> "" Then


                If txtpallet.Text.Length <> 20 Then
                    MsgBox("Código incorrecto", MsgBoxStyle.Critical, "Aviso")
                    txtpallet.Text = ""
                    CbCant.Checked = True
                    Exit Sub
                Else
                    palletcajas = txtpallet.Text.Substring(10, 9)
                    Dim frm As Frm_MatrisCajas = New Frm_MatrisCajas

                    frm.ShowDialog()

                End If
            End If
        Else
            If CbCant.Checked = True Then
                If CbEtiq.Enabled = True Then
                    Cant.Visible = False
                    Cant.Text = ""
                Else
                    Cant.Visible = False
                End If
            Else
                Cant.Visible = True
                sumarono = "NO"


            End If

        End If







    End Sub

    Private Sub BtnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImprimir.Click
        If lblcodigo.Text = "" Then
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


            documentoimp = DateTime.Now.ToString("MM-dd-yy") + "Documento" + lblcodigo.Text
            Dim frm As Frm_MuestraReporte = New Frm_MuestraReporte
            frm.Text = "Asistente de informes - Guia Pre - Despacho"

            Dim report As New Rpt_PreDespacho
            'pblogo.Image.Save("C:\Imagenlogo.jpg", Drawing.Imaging.ImageFormat.Jpeg)

            'Dim RutaImagen As String
            'RutaImagen = "C:\Imagenlogo.jpg"



            'Dim RutaImagen As String
            'RutaImagen = "C:\Windows\Imagenlogo.jpg"
            '' Ds2.imagen.AddimagenRow(ImageToByte(pblogo.Image))

            '' report.Subreports(0).SetDataSource(Ds2)

            'report.SetParameterValue("RutaImagen", RutaImagen.ToString)
            report.SetDatabaseLogon(Usuario_ODBC, Pass_ODBC)
            report.SetParameterValue("codigo", lblcodigo.Text)

            frm.Contenedor.ReportSource = report
            frm.ShowDialog()

        End If
    End Sub

    Private Sub Frm_GuiaPreDespachoAgregar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F1 Then
            If RealizarAccion("002", "004") = False Then
                Exit Sub
            End If
            Dim frm As New Frm_GuiaPreDespachoRecupera
            frm.ShowDialog(Frm_Principal)
            If Frm_Principal.buscavalor <> "" Then
                Me.lblcodigo.Text = Frm_Principal.buscavalor.ToString()
                RescataTMPPreDespacho(lblcodigo.Text)
                btn_BuscaCliente.Enabled = False
                CbEtiq.Enabled = False
                Frm_Principal.buscavalor = ""
                BtnBuscar.Enabled = False
            End If
        End If
    End Sub

    Private Sub Btn_AnulaGuia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_AnulaGuia.Click

        If RealizarAccion("002", "005") = False Then
            Exit Sub
        End If

        Dim tabla As DataTable = fnc.ListarTablasSQL("SELECT fpre_codvig, fpre_activa FROM fichpred WHERE fpre_codi='" + lblcodigo.Text + "'")

        If tabla.Rows.Count > 0 Then
            If tabla.Rows(0)(0).ToString() = "0" Then
                If tabla.Rows(0)(1).ToString() = "1" Then
                    MsgBox("No puede anular un pre-despacho que esta siendo utilizado por otro usuario", MsgBoxStyle.Critical, "Aviso")
                Else
                    If MsgBox("Seguro de anular la guia ", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbYes Then

                        If MsgBox("¿Desea anular el pre-despacho?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbNo Then
                            Exit Sub
                        End If

                        Dim con As New Conexion

                        Try
                            con.conectar()

                            Dim _cmd As SqlCommand = New SqlCommand("PAG_ElimPreDespacho", con.con)
                            _cmd.CommandType = CommandType.StoredProcedure
                            _cmd.Parameters.AddWithValue("@cod_pred", lblcodigo.Text)
                            _cmd.Parameters.AddWithValue("@cod_ped", TxtNped.Text)

                            Dim resp As Integer = 0
                            Try
                                resp = Convert.ToInt32(_cmd.ExecuteScalar())
                            Catch ex As Exception
                                resp = 1
                            End Try

                            If resp = 0 Then
                                MsgBox("Grabación exitosa", MsgBoxStyle.Information, "Aviso")
                            Else
                                MsgBox("Error esperado al grabar la información", MsgBoxStyle.Critical, "Aviso")
                            End If

                            con.cerrar()

                            limpiarformulario()

                        Catch ex As Exception
                            MsgBox("Error esperado al grabar la información", MsgBoxStyle.Critical, "Aviso")
                        End Try

                    End If
                End If

            ElseIf tabla.Rows(0)(0).ToString() = "2" Then
                MsgBox("No se puede anular el pre-despacho ya que se encuentra despachado", MsgBoxStyle.Critical, "Aviso")

            Else
                MsgBox("El documento ya se encuentra anulado", MsgBoxStyle.Critical, "Aviso")
            End If
        End If
    End Sub

    Private Sub CmboCarga_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CmboCarga.KeyPress
        e.Handled = True
    End Sub

    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        Dim f As New Frm_ListadoPredespahos
        f.ShowDialog(Frm_Principal)
        If Frm_Principal.buscavalor.ToString() <> "" Then
            RescataPreDespacho(Frm_Principal.buscavalor.ToString())
            Frm_Principal.buscavalor = ""
        End If
    End Sub

    Dim _retornoficha As String

    Private Sub CbPedido_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CbPedido.CheckedChanged

        If sender.CheckState = 1 AndAlso estcheck = True Then

            Dim sql As String = "SELECT Orden, pedido, fecha, Destino FROM  Pedidos_ficha WHERE cliente='" + txtrut.Text + "" + verificador.Text + "' AND fecha>=convert(date, getdate()) AND Ped_EstPred='0' ORDER BY Orden desc "
            Dim tabla_pedidos As DataTable = fnc.ListarTablasSQL(sql)

            If tabla_pedidos.Rows.Count = 0 Then
                CbPedido.Enabled = False
            End If

            Dim f As New Frm_ListadoPedidos
            f.rutcli = txtrut.Text + "" + verificador.Text
            f.ShowDialog(Frm_Principal)

            '----------------
            'valor de retorno
            '----------------

            If Frm_Principal.buscavalor.ToString() <> "" Then
                Console.WriteLine(Frm_Principal.buscavalor.ToString())
                Dim _mm As String() = Frm_Principal.buscavalor.ToString().Split(Convert.ToChar(","))

                TxtNped.Text = _mm(0).ToString()
                _retornoficha = _mm(1).ToString()
                Txtdestino.Text = _mm(2).ToString()
                txtdestino2.Text = _mm(3).ToString()
                txtdestino3.Text = _mm(4).ToString()

                'Modificacion Pedidos Locales HAmestica 04-12-18
                Dim sqlEstPedLoc As String = "SP_Pedidos_Locales_Estados_Pedido '" & _mm(0).ToString() & "'"
                Dim respEstPedLoc As DataTable = fnc.ListarTablasSQL(sqlEstPedLoc)

                If (respEstPedLoc.Rows.Count > 0) Then
                    Dim errEstPedLoc As Boolean = False

                    If (respEstPedLoc.Rows.Count = 1) Then
                        If (respEstPedLoc.Rows(0).Item(0).ToString.Trim = "T") Then
                            errEstPedLoc = True
                        End If
                    End If

                    If (errEstPedLoc) Then
                        Dim sqlDatPedLoc As String = "SP_Pedidos_Locales_Obtener_Datos_Consolidar '" & _mm(0).ToString() & "'"
                        Dim dtRespDatPedLoc As DataTable = fnc.ListarTablasSQL(sqlDatPedLoc)

                        If (dtRespDatPedLoc.Rows.Count > 0) Then
                            Dim DpreCodi As Integer = 1

                            For i = 0 To dtRespDatPedLoc.Rows.Count - 1
                                Dim NroPal = dtRespDatPedLoc.Rows(i).Item(0).ToString.Trim
                                Dim Uni = dtRespDatPedLoc.Rows(i).Item(1).ToString.Trim

                                Dim sqlPedLocCons As String = "SP_Pedidos_Locales_Consolidar '" & lblcodigo.Text.Trim & "','" & NroPal & "','" & Uni & "','" & Frm_Principal.InfoUsuario.Text & "','" & DpreCodi & "'"
                                Dim RespCons = fnc.MovimientoSQL(sqlPedLocCons)

                                DpreCodi += 1
                            Next

                            CargaGrilla()
                        End If
                    Else
                        MsgBox("El Pedido Local seleccionado no esta preparado.", MsgBoxStyle.Critical, "Pedido Local Incompleto")
                    End If
                End If
                'Fin modificacion Pedidos Locales HAmestica 04-12-18

                'ordemconj.Text = _mm(4).ToString()
                If _retornoficha = 1 Then
                    LlenaPallets(_retornoficha)
                End If

                'Dim sql_Actualiza As String = "UPDATE pedidos_ficha SET Ped_EstPred='1' WHERE orden='" + Frm_Principal.buscavalor.ToString() + "'"
                Dim sql_Actualiza As String = "SP_Pedidos_Estados_Actualizar '" & _mm(0).ToString.Trim & "','P','1'"
                fnc.MovimientoSQL(sql_Actualiza)

                'select ordenconjunta from Pedidos_ficha
                Dim conjunto As String = "select ordenconjunta from Pedidos_ficha" +
                  " WHERE Orden='" + TxtNped.Text + "'  "
                Dim TABLAconj As DataTable = fnc.ListarTablasSQL(conjunto)
                ordemconj.Text = TABLAconj.Rows(0)(0).ToString()

                If ordemconj.Text = "" Then
                    'VALIDAR SOLICITUD MENOR A 24 HRS. HAmestica 27/07/2018
                    Dim sqlValid24Hrs = "select ExiPed=count(Orden) from Pedidos_24_Horas with(nolock) where Orden='" & _mm(0).ToString.Trim & "'"
                    Dim TabExiPed As DataTable = fnc.ListarTablasSQL(sqlValid24Hrs)
                    Dim ExiPed = CInt(TabExiPed.Rows(0).Item(0).ToString.Trim)
                    If (ExiPed > 0) Then
                        Dim sqlActPreDespMar = "update Pedidos_24_Horas set PreDesp_Marcado='1' where Orden='" & _mm(0).ToString.Trim & "'"
                        fnc.MovimientoSQL(sqlActPreDespMar)

                        CBSI.Checked = True
                        Cb1.Checked = True

                        CBNO.Checked = False
                    Else
                        CBSI.Checked = False
                        Cb1.Checked = False

                        CBNO.Checked = True
                    End If
                    'FIN VALIDAR SOLICITUD MENOR A 24 HRS. HAmestica 27/07/2018



                    Dim PALLETS As String = "SELECT  pd.pallet FALTAN  FROM Pedidos_detalle pd INNER JOIN Pedidos_ficha pf ON pd.pedido=pf.pedido " +
                        "WHERE Orden='" + TxtNped.Text + "' ORDER BY pd.pallet "
                    Dim TABLA As DataTable = fnc.ListarTablasSQL(PALLETS)

                    Dim stringpallets As String = ""

                    Label10.Text = Label10.Text + "(" + (TABLA.Rows.Count).ToString() + ")"

                    For i As Integer = 0 To TABLA.Rows.Count - 1
                        stringpallets = stringpallets + "  -  " + TABLA.Rows(i)(0).ToString()
                    Next

                    Lblpalletsped.Text = stringpallets
                    Lblpalletsped.Visible = True
                    Timer2.Start()
                Else
                    MsgBox("Este Pedido se encuentra unido " + ordemconj.Text, MsgBoxStyle.Information, "Aviso")
                    Dim PALLETS As String = "SELECT  pd.pallet FALTAN  FROM Pedidos_detalle pd INNER JOIN Pedidos_ficha pf ON pd.pedido=pf.pedido " +
                      "WHERE ordenconjunta='" + ordemconj.Text + "' ORDER BY pd.pallet "
                    Dim TABLA As DataTable = fnc.ListarTablasSQL(PALLETS)

                    Dim stringpallets As String = ""

                    Label10.Text = Label10.Text + "(" + (TABLA.Rows.Count).ToString() + ")"

                    For i As Integer = 0 To TABLA.Rows.Count - 1
                        stringpallets = stringpallets + "  -  " + TABLA.Rows(i)(0).ToString()
                    Next

                    Lblpalletsped.Text = stringpallets
                    Lblpalletsped.Visible = True
                    Timer2.Start()


                End If
            Else
                TxtNped.Text = "0"
                CbPedido.Enabled = False
                CbPedido.Checked = False
            End If
        End If
        CbPedido.Enabled = False
    End Sub


    Public Sub LlenaPallets(ByVal cod As Integer)

        Dim con As New Conexion

        Try
            con.conectar()

            Dim _cmd As SqlCommand = New SqlCommand("PAG_CARGASELECCION", con.con)
            _cmd.CommandType = CommandType.StoredProcedure
            _cmd.Parameters.AddWithValue("@codpred", lblcodigo.Text)
            _cmd.Parameters.AddWithValue("@codped", TxtNped.Text)
            _cmd.Parameters.AddWithValue("@codusu", Frm_Principal.InfoUsuario.Text)

            Dim resp As Integer = 0
            Try
                resp = Convert.ToInt32(_cmd.ExecuteScalar())
            Catch ex As Exception
                resp = 1
            End Try

            If resp = 0 Then
                CargaGrilla()
                MsgBox("Información cargada correctamente", MsgBoxStyle.Information, "Aviso")
                CbPedido.Enabled = False
                CbEtiq.Enabled = False
            ElseIf resp = 1 Then
                MsgBox("Error esperado al grabar la información", MsgBoxStyle.Critical, "Aviso")
            End If
            con.cerrar()

        Catch ex As Exception
            Console.WriteLine(ex.Message)
            con.cerrar()
        End Try


    End Sub




    Private Sub CmboPedido_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.Handled = True
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        If Lblpalletsped.Text.Length > 50 Then
            Dim TEXTO As String = Lblpalletsped.Text
            TEXTO = Lblpalletsped.Text.Remove(0, 1) + "" + Lblpalletsped.Text.Chars(0)
            Lblpalletsped.Text = TEXTO
        End If

    End Sub

    Private Sub CbEtiq_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CbEtiq.CheckedChanged
        If CbEtiq.Checked = True Then
            CbEtiq.Enabled = False
            CbCant.Enabled = False
        End If
    End Sub

    Private Sub txtpallet_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpallet.TextChanged

    End Sub

    Private Sub Lblpalletsped_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Lblpalletsped.Click

    End Sub

    Private Sub Cb1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles Cb1.CheckedChanged

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If TxtNped.Text = "0" Then
            TxtNped.Text = "1"
        End If

    End Sub

    Private Sub CheckBox3_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox3.CheckedChanged
        If CheckBox3.Checked = True Then
            CheckBox2.Checked = False

        Else
            CheckBox2.Checked = True

        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = True Then
            CheckBox3.Checked = False

        Else
            CheckBox3.Checked = True

        End If
    End Sub

    Private Sub CheckBox5_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox5.CheckedChanged
        If CheckBox5.Checked = True Then
            CheckBox4.Checked = False
        Else
            CheckBox4.Checked = True
        End If
    End Sub

    Private Sub CheckBox4_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox4.CheckedChanged
        If CheckBox4.Checked = True Then
            CheckBox5.Checked = False
        Else
            CheckBox5.Checked = True
        End If
    End Sub

    Private Sub CheckBox7_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox7.CheckedChanged
        If CheckBox7.Checked = True Then
            CheckBox6.Checked = False
        Else
            CheckBox6.Checked = True
        End If
    End Sub

    Private Sub CheckBox6_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox6.CheckedChanged
        If CheckBox6.Checked = True Then
            CheckBox7.Checked = False
        Else
            CheckBox7.Checked = True
        End If
    End Sub

    Private Sub TxtNped_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtNped.TextChanged

    End Sub


    ' Validacion pendiente formato de temperaturas
    'Private Sub Temp1_LostFocus(sender As Object, e As System.EventArgs) Handles Temp1.LostFocus
    '    Dim Temp = Temp1.Text.Trim
    '    If (Temp <> "") Then
    '        If (formatearTemp(Temp) = "-1") Then
    '            Temp1.Text = ""
    '            Temp1.Focus()
    '        Else
    '            Temp1.Text = formatearTemp(Temp)
    '        End If
    '    End If
    'End Sub

    'Function formatearTemp(ByVal Temp As String) As String
    '    Dim Resp = "-1"

    '    Try
    '        Dim TempAux As Double
    '        If (Double.TryParse(Temp, TempAux) = False) Then
    '            MessageBox.Show("La temperatura ingresada no es valida", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        Else
    '            Resp = TempAux.ToString("F1")
    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show("Ocurrio un error al formatear Temperatura", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try

    '    Return Resp
    'End Function

    Private Sub Temp1_TextChanged(sender As Object, e As System.EventArgs) Handles Temp1.TextChanged
        calcTempProm()
    End Sub

    Private Sub Temp2_TextChanged(sender As Object, e As System.EventArgs) Handles Temp2.TextChanged
        calcTempProm()
    End Sub

    Private Sub Temp3_TextChanged(sender As System.Object, e As System.EventArgs) Handles Temp3.TextChanged
        calcTempProm()
    End Sub
End Class
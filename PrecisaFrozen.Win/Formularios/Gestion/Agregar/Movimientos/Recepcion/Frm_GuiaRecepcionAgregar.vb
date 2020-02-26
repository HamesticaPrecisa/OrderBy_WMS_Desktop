Imports System.Data
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports System.Drawing.Printing
Imports CrystalDecisions.Shared
Imports System.Drawing.Imaging
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration

Public Class Frm_GuiaRecepcionAgregar

    Dim fuente As Font
    Dim fnc As New Funciones
    Dim COM1 As New ImpresionCOM1
    Dim modifi As String = ""
    Dim NumeroPallet As String = ""
    Dim valorRecibido As String = ""
    Public mensaje As String = ""
    Dim fila_grilladetalle As Integer = -1
    Dim OBSERVACION_VAS As String = ""
    Dim datosguia As String = "0"
    Dim modificacion As Boolean = False
    Dim pesopa As Integer = 0
    Dim TxtNpallets As String = "0"
    Dim TxtPromTemp As String = "0"
    Dim DiasVenc As Integer = 0
    Dim DiasVenc2 As Integer = 0
    Dim camttemp As String = "0"

    Public cliF3 As String = ""
    Public productoF3 = ""
    Dim folio_clienteF3 = ""
    Dim unidadesF3 = ""
    Dim kilosF3 = ""
    Dim fproduccionF3 = ""
    Dim fvenciF3 = ""
    Dim numero_palletF3 = ""
    Dim tipo_alamacenF3 = ""


#Region "Eventos Formulario"

    Public Sub Frm_AddRecepcion_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If TxtCodRece.Text <> "" AndAlso TxtCodRece.Enabled = False Then
            If fnc.verificaExistencia("fichrece", "frec_codi", CerosAnteriorString(TxtCodRece.Text, 7)) = False Then

                If fnc.verificaExistencia("fichrece", "frec_codi", TxtCodRece.Text) = False Then

                    If MsgBox("Esta seguro de salir sin guardar la información", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbNo Then
                        e.Cancel = True
                    Else
                        f_addrecepcion = False
                        CancelaCorrelativo("006", TxtCodRece.Text)

                        'libero estado del checklist
                        Dim sql As String = "UPDATE zcheckList SET cl_estfrigo='0' WHERE cl_fol='" + TxtFolioPorteria.Text + "'"
                        fnc.MovimientoSQL(sql)

                        Dim SqlEliminaTMPDETA As String = "DELETE FROM TmpDetaRece WHERE frec_codi='" + TxtCodRece.Text + "'"
                        fnc.MovimientoSQL(SqlEliminaTMPDETA)

                        sql = "DELETE FROM TmpFichrece WHERE frec_codi='" + TxtCodRece.Text + "'"
                        fnc.MovimientoSQL(sql)

                        sql = "DELETE FROM chk_imagesopo WHERE LEFT(id_pallets,7)='" + TxtCodRece.Text + "' "
                        fnc.MovimientoSQL(sql)

                        sql = "DELETE FROM detareceestado WHERE LEFT(rtraq_codi,7)='" + TxtCodRece.Text + "'"
                        fnc.MovimientoSQL(sql)

                        sql = "DELETE FROM detarececajas WHERE LEFT(caj_Pcod,7)='" + TxtCodRece.Text + "'"
                        fnc.MovimientoSQL(sql)

                        TimeAdicionales.Stop()
                    End If
                Else
                    f_addrecepcion = False
                    TimeAdicionales.Stop()
                End If
            Else
                f_addrecepcion = False
                TimeAdicionales.Stop()
            End If
        Else
            f_addrecepcion = False
            TimeAdicionales.Stop()
        End If
    End Sub

    Private Sub pro()



      
    End Sub

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



    Private Sub Frm_AddRecepcion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Frm_Principal.buscavalor = ""

        cargaimg()
        cargaimg2()
        CMBESTPA.SelectedIndex = 0
        cboProductotip.SelectedIndex = 0
        CargarCombobox()
        txtResponsable.Text = fnc.DevuelveUsuario(Frm_Principal.InfoUsuario.Text)
        fecharece.Value = fnc.DevuelveFechaServidor()
        DataAdicionales.DataSource = fnc.ListarTablasSQL("SELECT 'False' AS Dvas_Est ,Serv_Cod, Serv_Nom,'0' AS Dvas_Unid, " +
                                                         "'0' AS dvas_cajas,'0' AS dvas_kilos FROM FacServicios WHERE " +
                                                         "isnull(Serv_OrdR,0) >'0' ORDER BY Serv_ordr ASC")
        TxtCodRece.Focus()


        cbonumtun.Text = ""
        Me.AutoScroll = True


        Dim sql4 As String = "SELECT * from conf_impcant "

        Dim tabla4 As DataTable = fnc.ListarTablasSQL(sql4)
        If tabla4.Rows.Count > 0 Then
            TXTCANTIMP.Text = tabla4.Rows(0)(0).ToString()


        End If
    End Sub

    Private Sub Frm_AddRecepcion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F1 AndAlso TxtCodRece.Enabled = True Then
            Dim sqlLimFols = "SP_TMPFICHRECE_Limpiar"
            fnc.MovimientoSQL(sqlLimFols)

            If RealizarAccion("001", "001") = False Then
                Exit Sub
            End If
            Dim frm As New Frm_addRecepcionRecupera
            frm.ShowDialog(Frm_Principal)
            Me.TxtCodRece.Text = Frm_Principal.buscavalor.ToString()
            Frm_Principal.buscavalor = ""
            buscaReceTmp(TxtCodRece.Text)
            CargaGrillaDetalle()
            TimeAdicionales.Start()
            BtnBuscar.Enabled = False
        ElseIf e.KeyCode = Keys.F2 AndAlso TxtCodRece.Enabled = False Then

            If fnc.verificaExistencia("fichrece", "frec_codi", TxtCodRece.Text) = False Then
                MsgBox("Se necesita Guardar Recepcion antes de modificar", MsgBoxStyle.Critical, "Aviso")
                Exit Sub
            End If

            Dim limite_modificar As DateTime = devuelve_fecha_Formato2(Convert.ToDateTime(fecharece.Value).AddDays(1)) + " 13:00:00"
            Dim fecha As DateTime = fnc.DevuelveFechaServidor()

            Dim validador As Integer = 0
         
            If devuelve_fecha(fecharece.Value) <> devuelve_fecha(fnc.DevuelveFechaServidor) Then
                'Full
                If RealizarAccion("001", "003", False) = True Then
                    validador += 1
                End If
            Else
                'POR EL DIA
                If RealizarAccion("001", "059", False) = True Then
                    validador += 1
                End If
            End If

            If (fecha < limite_modificar) Then
                If RealizarAccion("001", "061", False) = True Then
                    validador += 1
                End If
            End If


            If validador = 0 Then
                MsgBox("No podra modificar la guia", MsgBoxStyle.Critical, "Aviso")
                Exit Sub
            End If

             
            Dim sqltmp As String = "select * from tmpdetapred where dpre_folio LIKE '%" + TxtCodRece.Text.Trim() + "%'"

            Dim tabla2 As DataTable = fnc.ListarTablasSQL(sqltmp)

            If tabla2.Rows.Count > 0 Then

                MsgBox("Imposible modificar esta recepcion ya que existen soportantes que se despachan en este momento  ", MsgBoxStyle.Critical, "Aviso")
                Exit Sub

            End If

            'Inicio validar Guia no esté en Pre-Despacho
            Dim CodRec As String = TxtCodRece.Text.Trim
            Dim SqlValidPred As String = "select a.fpre_codi from fichpred a with(nolock) inner join detapred b with(nolock) on(b.dpre_codi like a.fpre_codi+'%') where a.fpre_codvig<>'2' and b.dpre_folio like '" & CodRec & "%'"
            Dim dtValidPred As DataTable = fnc.ListarTablasSQL(SqlValidPred)

            If (dtValidPred.Rows.Count > 0) Then
                Dim strPred As String = ""

                For i = 0 To dtValidPred.Rows.Count - 1
                    If (i > 0) Then
                        strPred = strPred & vbCrLf
                    End If
                    strPred = strPred & " - " & dtValidPred.Rows(i).Item(0).ToString.Trim
                Next

                strPred = strPred & vbCrLf & vbCrLf & "Termine o Elimine los Pre-Despachos indicados para poder modificar la Recepción."

                MsgBox("No se puede modificar esta Recepción ya que existen Pre-Despachos asociados sin finalizar:" & vbCrLf & strPred, MsgBoxStyle.Critical, "Aviso")
                Exit Sub
            End If
            'Fin validar Guia no esté en Pre-Despacho

            If MsgBox("¿Habilitar modificacion de guia?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbYes Then
                lbladv.Visible = True
                pbadvertencia.Visible = True
                btn_guardar.Enabled = True
                Gb_Encabezado.Enabled = True
                Panel5.Enabled = True
                fecharece.Enabled = True
                btn_BuscaCliente.Enabled = True
                Btn_BuscaContrato.Enabled = True
                TxtClirut.Enabled = True
                txtcodcontrato.Enabled = True
                Btn_BuscaChofer.Enabled = True
                txtrutchofer.Enabled = True
                TimeAdicionales.Start()
                CmboTuneles.Enabled = False
                cbonumtun.Enabled = False
                produa.Enabled = False
                fvencimiento.Enabled = False

                If (RealizarAccion("001", "119", False)) Then
                    CmboTuneles.Enabled = True
                    cbonumtun.Enabled = True
                    produa.Enabled = True
                    lbladv.Visible = False
                    pbadvertencia.Visible = False
                Else
                    CmboTuneles.Enabled = False
                    cbonumtun.Enabled = False
                    produa.Enabled = False
                    lbladv.Visible = True
                    pbadvertencia.Visible = True
                End If

                modificacion = True
            End If

        ElseIf e.KeyCode = Keys.F3 AndAlso TxtCodRece.Enabled = False Then
            If MsgBox("¿Seguro de imprimir las etiquetas de los soportantes de la recepcion?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbYes Then


                Dim PrintDocumentF3 As New PrintDocument

                PrintDocumentF3.PrinterSettings = prtsettings

                Dim sql_Impresora As String = "SELECT imp_etiq, imp_COM1 FROM conf_impresora WHERE imp_comp='" + My.Computer.Name + "'"
                Dim tabla_conf As DataTable = fnc.ListarTablasSQL(sql_Impresora)

                If tabla_conf.Rows.Count > 0 Then

                    If tabla_conf.Rows(0)(1).ToString() = "COM1" Then

                        If chksecimp.Checked = True Then
                            For i As Integer = 0 To DetaRece.Rows.Count - 1


                                For X As Integer = 0 To Convert.ToInt32(TXTCANTIMP.Text.Trim()) - 1

                                    Dim cop As String = "COPIA"
                                    COM1.Impresion(txtclinom.Text, _
                                                   Me.DetaRece.Rows(i).Cells("Nombre_Producto").Value.ToString(), _
                                                   Me.DetaRece.Rows(i).Cells("SopCliente").Value.ToString(), _
                                                   Me.DetaRece.Rows(i).Cells("Cant_Pallets").Value.ToString(), _
                                                   Me.DetaRece.Rows(i).Cells("Peso").Value.ToString(), _
                                                   Me.DetaRece.Rows(i).Cells("Elaboracion").Value.ToString(), _
                                                   Me.DetaRece.Rows(i).Cells("Vencimiento").Value.ToString(), _
                                                   Me.DetaRece.Rows(i).Cells("Cod_Pallet").Value.ToString(), _
                                                   "1780000000" + Me.DetaRece.Rows(i).Cells("Cod_Pallet").Value.ToString(), fecharece.Value, cop)
                                    Threading.Thread.Sleep(500)
                                Next
                            Next

                        Else

                            For X As Integer = 0 To Convert.ToInt32(TXTCANTIMP.Text.Trim()) - 1

                                For i As Integer = 0 To DetaRece.Rows.Count - 1




                                    Dim cop As String = "COPIA"
                                    COM1.Impresion(txtclinom.Text, _
                                                   Me.DetaRece.Rows(i).Cells("Nombre_Producto").Value.ToString(), _
                                                   Me.DetaRece.Rows(i).Cells("SopCliente").Value.ToString(), _
                                                   Me.DetaRece.Rows(i).Cells("Cant_Pallets").Value.ToString(), _
                                                   Me.DetaRece.Rows(i).Cells("Peso").Value.ToString(), _
                                                   Me.DetaRece.Rows(i).Cells("Elaboracion").Value.ToString(), _
                                                   Me.DetaRece.Rows(i).Cells("Vencimiento").Value.ToString(), _
                                                   Me.DetaRece.Rows(i).Cells("Cod_Pallet").Value.ToString(), _
                                                   "1780000000" + Me.DetaRece.Rows(i).Cells("Cod_Pallet").Value.ToString(), fecharece.Value, cop)
                                    Threading.Thread.Sleep(500)




                                Next


                            Next






                        End If





                    Else
                        If chksecimp.Checked = True Then
                            For i As Integer = 0 To DetaRece.Rows.Count - 1


                                For X As Integer = 0 To Convert.ToInt32(TXTCANTIMP.Text.Trim()) - 1

                                    Dim cop As String = "COPIA"
                                    cliF3 = txtclinom.Text
                                    productoF3 = Me.DetaRece.Rows(i).Cells("Nombre_Producto").Value.ToString()
                                    folio_clienteF3 = Me.DetaRece.Rows(i).Cells("SopCliente").Value.ToString()
                                    unidadesF3 = Me.DetaRece.Rows(i).Cells("Cant_Pallets").Value.ToString()
                                    kilosF3 = Me.DetaRece.Rows(i).Cells("Peso").Value.ToString()
                                    fproduccionF3 = Me.DetaRece.Rows(i).Cells("Elaboracion").Value.ToString()
                                    fvenciF3 = Me.DetaRece.Rows(i).Cells("Vencimiento").Value.ToString()
                                    numero_palletF3 = Me.DetaRece.Rows(i).Cells("Cod_Pallet").Value.ToString()
                                    tipo_alamacenF3 = ""
                                    AddHandler PrintDocumentF3.PrintPage, AddressOf print_PrintPageF3
                                    PrintDocumentF3.PrinterSettings.PrinterName = tabla_conf.Rows(0)(0).ToString()
                                    PrintDocumentF3.Print()
                                Next
                            Next

                        Else

                            For X As Integer = 0 To Convert.ToInt32(TXTCANTIMP.Text.Trim()) - 1

                                For i As Integer = 0 To DetaRece.Rows.Count - 1




                                    Dim cop As String = "COPIA"
                                    cliF3 = txtclinom.Text
                                    productoF3 = Me.DetaRece.Rows(i).Cells("Nombre_Producto").Value.ToString()
                                    folio_clienteF3 = Me.DetaRece.Rows(i).Cells("SopCliente").Value.ToString()
                                    unidadesF3 = Me.DetaRece.Rows(i).Cells("Cant_Pallets").Value.ToString()
                                    kilosF3 = Me.DetaRece.Rows(i).Cells("Peso").Value.ToString()
                                    fproduccionF3 = Me.DetaRece.Rows(i).Cells("Elaboracion").Value.ToString()
                                    fvenciF3 = Me.DetaRece.Rows(i).Cells("Vencimiento").Value.ToString()
                                    numero_palletF3 = Me.DetaRece.Rows(i).Cells("Cod_Pallet").Value.ToString()
                                    tipo_alamacenF3 = ""
                                    AddHandler PrintDocumentF3.PrintPage, AddressOf print_PrintPageF3
                                    PrintDocumentF3.PrinterSettings.PrinterName = tabla_conf.Rows(0)(0).ToString()
                                    PrintDocumentF3.Print()



                                Next


                            Next






                        End If

                    End If

                Else
                    MsgBox("Debe seleccionar la impresora antes de imprimir una etiqueta", MsgBoxStyle.Critical, "Aviso")
                    Exit Sub
                End If
                'cliF3 = txtclinom.Text
                'productoF3 = Me.DetaRece.Rows(0).Cells("Nombre_Producto").Value.ToString()
                'folio_clienteF3 = Me.DetaRece.Rows(0).Cells("SopCliente").Value.ToString()
                'unidadesF3 = Me.DetaRece.Rows(0).Cells("Cant_Pallets").Value.ToString()
                'kilosF3 = Me.DetaRece.Rows(0).Cells("Peso").Value.ToString()
                'fproduccionF3 = Me.DetaRece.Rows(0).Cells("Elaboracion").Value.ToString()
                'fvenciF3 = Me.DetaRece.Rows(0).Cells("Vencimiento").Value.ToString()
                'numero_palletF3 = Me.DetaRece.Rows(0).Cells("Cod_Pallet").Value.ToString()
                'tipo_alamacenF3 = ""
                'AddHandler PrintDocumentF3.PrintPage, AddressOf print_PrintPageF3
                'PrintDocumentF3.PrinterSettings.PrinterName = tabla_conf.Rows(0)(0).ToString()
                'PrintDocumentF3.Print()



         

              

            End If
        ElseIf (e.KeyCode = Keys.F5 And TxtCodRece.Text.Trim <> "") Then
            Dim sqlCorrAct As String = "select a.cor_correact from correlat a with(nolock) where a.cor_codi='006'"
            Dim dtCorrAct As New DataTable
            dtCorrAct = fnc.ListarTablasSQL(sqlCorrAct)

            If (dtCorrAct.Rows.Count > 0) Then
                Dim Err As Boolean = False

                Dim CorrForm As String = TxtCodRece.Text.Trim
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
                    If (MsgBox("¿Desea limpiar este correlativo erróneo?", MsgBoxStyle.YesNo, "Confirmar") = MsgBoxResult.Yes) Then
                        Dim sqlCorrLim As String = "delete from Correlat_salto where tmps_correl='006' and tmps_personal='" & Frm_Principal.InfoUsuario.Text.Trim & "'"
                        fnc.MovimientoSQL(sqlCorrLim)

                        Frm_Principal.buscavalor = ""
                        TxtCodRece.Text = BuscaCorrelativo("006")
                    End If
                End If
            End If
        End If
    End Sub

    Sub corregirCorrelativo()
        Dim sqlCorrAct As String = "select a.cor_correact from correlat a with(nolock) where a.cor_codi='006'"
        Dim dtCorrAct As New DataTable
        dtCorrAct = fnc.ListarTablasSQL(sqlCorrAct)

        If (dtCorrAct.Rows.Count > 0) Then
            Dim Err As Boolean = False

            Dim CorrForm As String = TxtCodRece.Text.Trim
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
                Dim sqlCorrLim As String = "delete from Correlat_salto where tmps_correl='006' and tmps_personal='" & Frm_Principal.InfoUsuario.Text.Trim & "'"
                fnc.MovimientoSQL(sqlCorrLim)

                Frm_Principal.buscavalor = ""
                TxtCodRece.Text = BuscaCorrelativo("006")
            End If
        End If
    End Sub

#End Region

#Region "Validadores de ingreso"

    Function validacion() As Integer
        Dim numero As Integer = 0
        If Cmbotiporece.SelectedIndex = 2 Then


            If CHKEMB.Checked = True Then
                If TxtContenedor.Text = "" Then
                    mensaje = mensaje & vbCrLf & "- Debe ingresar un numero de Embarque valido"
                    numero += 1

                End If
            Else

                If (TxtContenedor.Text = "" Or ValidadorContenedor(TxtContenedor.Text.Trim) = False) Then
                    mensaje = mensaje & vbCrLf & "- Debe ingresar un numero de contenedor valido"
                    numero += 1
                End If
            End If
        End If
        If Cmbo_Almacenamiento.SelectedValue = 0 Then
            mensaje = mensaje & vbCrLf & "- Tipo de almacenamiento "
            numero += 1
        End If

        If Cmbotiporece.SelectedValue = 4 Then
            mensaje = mensaje & vbCrLf & "- Tipo de recepción "
            numero += 1
        End If

        If txtorigen.Text = "" Then
            mensaje = mensaje & vbCrLf & "- Tipo de Origen "
            numero += 1
        End If
        If cbonumtun.Enabled = True And cbonumtun.SelectedText.Trim = "A TUNEL" Then
            If cbonumtun.Text = "" Then
                mensaje = mensaje & vbCrLf & "- Numero de Tunel"

                numero += 1
            End If
        End If
        If datosguia = "1" Then
            If txtenvguia.Text = "" Then
                mensaje = mensaje & vbCrLf & "- Envases de guia "
                numero += 1

            End If
            If txtkilguia.Text = "" Then
                mensaje = mensaje & vbCrLf & "- Kilos de guia "
                numero += 1


            End If
        End If
        If ValidarHora(horainic.Text) = False Then
            mensaje = mensaje & vbCrLf & "- Hora de inicio correcta "
            numero += 1
        End If

        If txtclinom.Text = "" Then
            mensaje = mensaje & vbCrLf & "- Seleccionar un cliente"
            numero += 1
        End If

        If txtnom_contrato.Text = "" Then
            mensaje = mensaje & vbCrLf & "- Contrato correspondiente al cliente"
            numero += 1
        End If

        If txtcodcontrato.Text = "" Then
            mensaje = mensaje & vbCrLf & "- Contrato correspondiente al cliente"
            numero += 1
        End If

        'If Cb_tunel.Checked = True Then
        '    If CmboTuneles.SelectedValue = 0 Then
        '        mensaje = mensaje & vbCrLf & "Seleccione el tunel al cual ingresara la recepcion"
        '        numero += 1
        '    End If

        'End If

        If txtnombrechofer.Text = "" Then
            mensaje = mensaje & vbCrLf & "- Chofer "
            numero += 1
        End If

        If txtguia.Text = "" Then
            mensaje = mensaje & vbCrLf & "- Guia cliente no ingresada"
            numero += 1
        End If

        If IsNothing(cmbo_descarga.SelectedValue) Then
            mensaje = mensaje & vbCrLf & "- Tipo de descarga "
            numero += 1
        End If

        'If temp1.Text = "" Or temp2.Text = "" Or temp3.Text = "" Then
        '    mensaje = mensaje & vbCrLf & "- Temperaturas no ingresadas"
        '    numero += 1
        'Else

        '    If Convert.ToDecimal(temp1.Text.Replace(".", ",")) <= -40 Then
        '        mensaje = mensaje & vbCrLf & "- Temperatura 1 es inferior al limite de -40° "
        '        numero += 1
        '    End If

        '    If Convert.ToDecimal(temp1.Text.Replace(".", ",")) >= 40 Then
        '        mensaje = mensaje & vbCrLf & "- Temperatura 1 es superior al limite de 40° "
        '        numero += 1
        '    End If

        '    If Convert.ToDecimal(temp2.Text.Replace(".", ",")) <= -40 Then
        '        mensaje = mensaje & vbCrLf & "- Temperatura 2 es inferior al limite de -40° "
        '        numero += 1
        '    End If

        '    If Convert.ToDecimal(temp2.Text.Replace(".", ",")) >= 40 Then
        '        mensaje = mensaje & vbCrLf & "- Temperatura 2 es superior al limite de 40° "
        '        numero += 1
        '    End If

        '    If Convert.ToDecimal(temp3.Text.Replace(".", ",")) <= -40 Then
        '        mensaje = mensaje & vbCrLf & "- Temperatura 3 es inferior al limite de -40° "
        '        numero += 1
        '    End If

        '    If Convert.ToDecimal(temp3.Text.Replace(".", ",")) >= 40 Then
        '        mensaje = mensaje & vbCrLf & "- Temperatura 3 es superior al limite de 40° "
        '        numero += 1
        '    End If

        'End If

        If txtsello.Text = "" Then
            mensaje = mensaje & vbCrLf & "- N° de sello"
            numero += 1
        End If

        If Rb_higieneB.Checked = False AndAlso Rb_higieneM.Checked = False Then
            mensaje = mensaje & vbCrLf & "- Estado de higiene"
            numero += 1
        End If

        If Rb_EstibaB.Checked = False AndAlso Rb_EstibaM.Checked = False Then
            mensaje = mensaje & vbCrLf & "- Estado de la estiba"
            numero += 1
        End If

        If Cb_OloresExtraños.Checked = True AndAlso Rb_EstibaM.Checked = True AndAlso Rb_higieneM.Checked = True AndAlso cbdañado.Checked = True Then
            mensaje = mensaje & vbCrLf & "- Este Producto Estaria Rechazado por su estado (Olores, Producto dañado, Higiene malo, etc.)"
            numero += 1
        End If

        If IsNumeric(TxtFilm.Text) AndAlso IsNumeric(txtsoportantes.Text) Then
            If Val(TxtFilm.Text) > Val(txtsoportantes.Text) Then
                mensaje = mensaje & vbCrLf & "- Cantidad de postura de film es mayor al total de recepcion"
                numero += 1
            End If
        End If

        If IsNumeric(TxtArriendo.Text) AndAlso IsNumeric(txtsoportantes.Text) Then
            If Val(TxtArriendo.Text) > Val(txtsoportantes.Text) Then
                mensaje = mensaje & vbCrLf & "- Cantidad de pallets agregados al arriendo " + vbCrLf +
                    "es mayor al total de pallets de la recepcion"
                numero += 1
            End If
        End If

        If IsNumeric(TxtRepa.Text) AndAlso IsNumeric(txtsoportantes.Text) Then
            If Val(TxtRepa.Text) > Val(txtsoportantes.Text) Then
                mensaje = mensaje & vbCrLf & "- Cantidad de repaletizados agregados  " + vbCrLf +
                    "es mayor al total de pallets de la recepcion"
                numero += 1
            End If
        End If
        If CHKEMB.Checked = True Then
            If TxtContenedor.Text = "" Then
                mensaje = mensaje & vbCrLf & "- Debe ingresar un numero de Embarque valido"
                numero += 1

            End If
        Else
            'If (TxtContenedor.Text = "" Or ValidadorContenedor(TxtContenedor.Text.Trim) = False) AndAlso Cmbotiporece.Enabled = False Then
            '    mensaje = mensaje & vbCrLf & "- Debe ingresar un numero de contenedor valido"
            '    numero += 1
            'End If
        End If


        If numero > 0 Then
            MsgBox(mensaje, MsgBoxStyle.Critical, "Aviso")
        End If


        mensaje = ""

        Return numero
    End Function

    Function validacionDetalle() As Integer
        Dim valor As Integer = 0

        Dim mensaje As String = "Debe ingresar lo siguiente antes de agregar el pallet " & vbCrLf

    


        If txtprodcod.Text = "" Then
            mensaje = mensaje + "- Producto " & vbCrLf
            valor += 1
        End If

        If txtsopcodi.Text = "" Then
            mensaje = mensaje + "- Soportante actual " & vbCrLf
            valor += 1
        End If

        If chkpretrack.Checked = True Then
            If txttrackprev.Text = "" Then

                mensaje = mensaje + "- Ingrese etiqueta de traqueo previo " & vbCrLf
                valor += 1
            Else
                Dim sqltra As String = "SELECT * from detarececajas WHERE val_pretrack='" + txttrackprev.Text.Trim() + "'"
                Dim tablatra As DataTable = fnc.ListarTablasSQL(sqltra)

                If tablatra.Rows.Count > 0 Then
                    mensaje = mensaje + "- Etiqueta de traqueo previo ya usada  " & vbCrLf
                    valor += 1
                End If

            End If
        End If
        If chkpretrack.Checked = True Then
            Dim sql As String = "Select etiquetacompleta from t_tracking where IdEtiquetaAutoIncrement='" + txttrackprev.Text.Trim() + "'"
            Dim tabla As DataTable = fnc.ListarTablasSQLetiqueta(sql)

            If tabla.Rows.Count > 0 Then

                Dim sql2 As String = "Select cantidad,peso from t_tracking2 where IdEtiquetaAutoIncrement='" + txttrackprev.Text.Trim() + "'"
                Dim tabla2 As DataTable = fnc.ListarTablasSQLetiqueta(sql2)
                If tabla2.Rows.Count > 0 Then

                    If tabla2.Rows(0)(0).ToString() = txtunid.Text.Trim() Then
                    Else
                        'mensaje = mensaje + "- La cantidad de unidades traqueadas no coincide con las agregadas al pallet  " & vbCrLf
                        'valor += 1
                        txtunid.Text = tabla2.Rows(0)(0).ToString().Trim()


                    End If
                    If tabla2.Rows(1)(0).ToString() = txtkilos.Text.Trim() Then
                    Else
                        'mensaje = mensaje + "- La cantidad de unidades traqueadas no coincide con las agregadas al pallet  " & vbCrLf
                        'valor += 1
                        kg.Text = tabla2.Rows(0)(1).ToString().Trim()


                    End If
                End If

            Else
                mensaje = mensaje + "- Etiqueta de traqueo previo No existe  " & vbCrLf
                valor += 1
            End If

        End If

        If txtsopclie.Text = "" Then

        Else
            Dim sqlNumero As String = "SELECT * from TMPDETARECE where drec_sopocli='" + txtsopclie.Text + "'"
            Dim tablaNumero As DataTable = fnc.ListarTablasSQL(sqlNumero)

            If tablaNumero.Rows.Count > 0 Then

                If modifi = "OK" Then
                    modifi = ""
                Else
                    mensaje = mensaje + "- Soportante cliente ya existe en esta recepcion " & vbCrLf
                    valor += 1
                    modifi = ""
                End If

            End If


        End If



        'If txtsopclie.Text = "" Then
        '    mensaje = mensaje + "- Numero de soportante del cliente" & vbCrLf
        '    valor += 1
        'End If

        If felaboracion.Value > fvencimiento.Value Then
            mensaje = mensaje + "- Fecha de vencimiento mayor a la fecha de elaboración " & vbCrLf
            valor += 1
        End If
        If CMBESTPA.SelectedIndex = 0 Then
            mensaje = mensaje + "Seleccione Estado Calidad " & vbCrLf
            valor += 1

        End If

        If chkpretrack.Checked = True Then

        Else
            If txtunid.Text = "" Then
                mensaje = mensaje + "- unidades (cajas, contenedores, recipientes, etc.) " & vbCrLf
                valor += 1
            End If



            If kg.Text = "" Then
                mensaje = mensaje + "- Kilogramos del pallet " & vbCrLf
                valor += 1
            End If


        End If

        If txtunid.Text = "0" Then
            mensaje = mensaje + "- unidades Mayor a 0 " & vbCrLf
            valor += 1
        End If

        If kg.Text = "0" Then
            mensaje = mensaje + "- kilos mayor a 0 " & vbCrLf
            valor += 1
        End If

        If IsNumeric(kg.Text) Then

            Dim sql3 As String = "SELECT * from conf_limitkilo "
            Dim kilomax As String = "0"
            Dim tabla3 As DataTable = fnc.ListarTablasSQL(sql3)
            If tabla3.Rows.Count > 0 Then
                kilomax = tabla3.Rows(0)(0).ToString()


            End If
            If Val(kg.Text) > kilomax Then
                mensaje = mensaje + "- kilos menor a " + kilomax + "KG " & vbCrLf
                valor += 1



            End If





        End If

        If fvencimiento.Value <= fnc.DevuelveFechaServidor() Then
            mensaje = mensaje + "- No puede ingresar productos vencidos, o que la fecha de vencimiento sea durante el día " & vbCrLf
            valor += 1
        End If

        'If (TxtContenedor.Text = "" Or ValidadorContenedor(TxtContenedor.Text.Trim) = False) AndAlso Cmbotiporece.Enabled = False Then
        If (Cmbotiporece.Enabled And Cmbotiporece.SelectedValue = "2") Then
            If (TxtContenedor.Text = "" Or ValidadorContenedor(TxtContenedor.Text.Trim) = False) Then
                mensaje = mensaje & vbCrLf & "- Debe ingresar un numero de contenedor valido"
                valor += 1
            End If
        End If
        
        'If CMBESTPA.SelectedIndex <> 0 Then
        '    mensaje = mensaje & vbCrLf & "- Debe ingresar estado de calidad"
        '    valor += 1
        'End If
        If valor > 0 Then
            MsgBox(mensaje, MsgBoxStyle.Critical, "Aviso")
        End If
        mensaje = ""
        Return valor
    End Function

#End Region

#Region "buscadores"

    Private Sub btn_BuscaCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_BuscaCliente.Click
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

                If horainic.Text.Trim = ":" Then
                    horainic.Text = DevuelveHora()
                End If
                txtcodcontrato.Text = ""
                txtnom_contrato.Text = ""
                TxtClirut.Enabled = False
            Else
                MsgBox("El rut ingresado no existe", MsgBoxStyle.Information, "Aviso")
            End If
        End If
        Frm_Principal.buscavalor = ""
    End Sub

    Private Sub Btn_BuscaChofer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_BuscaChofer.Click
        Dim frm As New Lst_AyudaChoferes
        ' frm.where = TxtClirut.Text
        frm.ShowDialog(Frm_Principal)

        Me.valorRecibido = Frm_Principal.buscavalor

        'If Len(valorRecibido) >= 9 Then

        Dim SqlBusca As String = "SELECT cho_nombre, cho_patente, cho_empresa  FROM Choferes WHERE " +
            "cho_rut='" + valorRecibido + "'"

        Dim tablaBuscaChofer As DataTable = fnc.ListarTablasSQL(SqlBusca)

        If tablaBuscaChofer.Rows.Count > 0 Then
            txtrutchofer.Text = valorRecibido
            txtnombrechofer.Text = tablaBuscaChofer.Rows(0)(0).ToString()
            txtpatente.Text = tablaBuscaChofer.Rows(0)(1).ToString()
            txtempresa.Text = tablaBuscaChofer.Rows(0)(2).ToString()
            txtrutchofer.Enabled = False
        End If

        'End If
        Frm_Principal.buscavalor = ""
    End Sub

    Private Sub Btn_BuscaContrato_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_BuscaContrato.Click

        Dim frm As New Lst_AyudaContratos
        frm.condicion = "WHERE  cont_rutclie='" + QuitarCaracteres(TxtClirut.Text) + "' AND cont_estado='0'"
        frm.ShowDialog(Frm_Principal)
        Me.valorRecibido = Frm_Principal.buscavalor

        Dim sql As String = "SELECT cont_descr, cont_tempcon, cont_tempgra, Hor_SRI, Hor_SRT, Hor_SDI, Hor_SDT, cont_bloqimp,cont_tipalm " +
            "FROM contrato, contratosHorarios WHERE cont_codi=Hor_Contcod AND cont_codi='" + valorRecibido.ToString() + "'"

        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

        If tabla.Rows.Count > 0 Then

            If tabla.Rows(0)(8).ToString().Trim() = Cmbo_Almacenamiento.Text.Trim() Then
                txtcodcontrato.Enabled = False
                txtcodcontrato.Text = valorRecibido.ToString
                txtnom_contrato.Text = tabla.Rows(0)(0).ToString()
                TxtTemp.Text = tabla.Rows(0)(1).ToString()
                TxtTempGracia.Text = tabla.Rows(0)(2).ToString()
                LV_horini.Text = tabla.Rows(0)(3).ToString()
                LV_ter.Text = tabla.Rows(0)(4).ToString()
                SA_HorIni.Text = tabla.Rows(0)(5).ToString()
                Sab_HorTer.Text = tabla.Rows(0)(6).ToString()

                If tabla.Rows(0)(7).ToString() = "1" Then
                    Cmbotiporece.SelectedValue = 2
                    Cmbotiporece.Enabled = False
                Else
                    Cmbotiporece.Enabled = True
                End If
            Else

                If tabla.Rows(0)(8).ToString().Trim() = "" Then
                    txtcodcontrato.Enabled = False
                    txtcodcontrato.Text = valorRecibido.ToString
                    txtnom_contrato.Text = tabla.Rows(0)(0).ToString()
                    TxtTemp.Text = tabla.Rows(0)(1).ToString()
                    TxtTempGracia.Text = tabla.Rows(0)(2).ToString()
                    LV_horini.Text = tabla.Rows(0)(3).ToString()
                    LV_ter.Text = tabla.Rows(0)(4).ToString()
                    SA_HorIni.Text = tabla.Rows(0)(5).ToString()
                    Sab_HorTer.Text = tabla.Rows(0)(6).ToString()

                    If tabla.Rows(0)(7).ToString() = "1" Then
                        Cmbotiporece.SelectedValue = 2
                        Cmbotiporece.Enabled = False
                    Else
                        Cmbotiporece.Enabled = True
                    End If
                Else
                    MsgBox("El Contrato no pertenece a este tipo de almacenamiento", MsgBoxStyle.Critical, "Aviso")
                End If




            End If


       

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

    Private Sub TxtClirut_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtClirut.KeyPress
        If e.KeyChar = ChrW(13) Then
            If TxtClirut.Text.Length >= 9 Then
                Dim SqlBusca As String = "SELECT cli_estado FROM clientes WHERE cli_rut='" + TxtClirut.Text + "'"
                Dim tabla As DataTable = fnc.ListarTablasSQL(SqlBusca)

                If tabla.Rows.Count > 0 Then
                    If tabla.Rows(0)(0).ToString() = "N" Then
                        MsgBox("El cliente seleccionado se encuentra bloqueado", MsgBoxStyle.Critical, "Aviso")
                        TxtClirut.Text = ""
                        Exit Sub
                    End If
                End If
                txtclinom.Text = RetornaCliente(TxtClirut.Text)
                Btn_BuscaContrato.Enabled = True
                TxtClirut.Enabled = False
                If horainic.Text.Trim = ":" Then
                    horainic.Text = DevuelveHora()
                End If
            End If
        End If
    End Sub

    Private Sub txtcodcontrato_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcodcontrato.KeyPress
        If e.KeyChar = ChrW(13) Then
            Dim sql As String = "SELECT cont_descr, cont_tempcon, cont_tempgra, Hor_SRI, Hor_SRT, Hor_SDI, Hor_SDT FROM contrato, contratosHorarios " +
                "WHERE cont_codi=Hor_Contcod AND cont_rutclie='" + TxtClirut.Text + "' AND cont_codi='" + CerosAnteriorString(txtcodcontrato.Text, 7) + "'"
            Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

            If tabla.Rows.Count > 0 Then
                txtcodcontrato.Enabled = False
                txtcodcontrato.Text = CerosAnteriorString(txtcodcontrato.Text, 7)
                txtnom_contrato.Text = tabla.Rows(0)(0).ToString()
                TxtTemp.Text = tabla.Rows(0)(1).ToString()
                TxtTempGracia.Text = tabla.Rows(0)(2).ToString()
                LV_horini.Text = tabla.Rows(0)(3).ToString()
                LV_ter.Text = tabla.Rows(0)(4).ToString()
                SA_HorIni.Text = tabla.Rows(0)(5).ToString()
                Sab_HorTer.Text = tabla.Rows(0)(6).ToString()
            Else
                MsgBox("El numero ingresado no existe o no corresponde a este cliente", MsgBoxStyle.Critical, "Aviso")
            End If
        End If
    End Sub

    Private Sub BtnTemp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTemp.Click

        Dim frm As New Frm_Temperaturas
        If fnc.verificaExistencia("FICHRECE", "FREC_CODI", TxtCodRece.Text) = True Then

            Dim sql As String = "SELECT drec_codi AS sopo, isnull(drec_temp,'0.00') FROM detarece  WHERE frec_codi1='" + TxtCodRece.Text + "' ORDER BY drec_codi "
            Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

            For i As Integer = 0 To tabla.Rows.Count - 1
                frm.DgvTemp.Rows.Add(tabla.Rows(i)(0).ToString(), tabla.Rows(i)(1).ToString())
                frm.temperatura_gracia = Val(TxtTemp.Text) + Val(TxtTempGracia.Text)
                frm.fecha_rece = fecharece.Value
            Next

            frm.DgvTemp.Enabled = False
            frm.Modalidad = "AGREGADA"
            frm.ShowDialog(Frm_Principal)
            TxtNpallets = Val(Frm_Principal.buscavalor.ToString().Chars(0) + Frm_Principal.buscavalor.ToString().Chars(1))
            TxtPromTemp = Frm_Principal.buscavalor.ToString().Remove(0, 2)
            BuscaDetalleRecepcionCompleta()
        Else
            Dim sql As String = "SELECT frec_codi+drec_codi AS sopo, isnull(drec_temp,'0.00') FROM TMPDETARECE  WHERE frec_codi='" + TxtCodRece.Text + "' ORDER BY drec_codi "
            Dim tabla As DataTable = fnc.ListarTablasSQL(sql)
            For i As Integer = 0 To tabla.Rows.Count - 1
                frm.DgvTemp.Rows.Add(tabla.Rows(i)(0).ToString(), tabla.Rows(i)(1).ToString())
                frm.temperatura_gracia = Val(TxtTemp.Text) + Val(TxtTempGracia.Text)
            Next
            frm.Modalidad = "TEMPORAL"
            frm.DgvTemp.Enabled = True
            frm.ShowDialog(Frm_Principal)

            TxtNpallets = Val(Frm_Principal.buscavalor.ToString().Chars(0) + Frm_Principal.buscavalor.ToString().Chars(1))
            TxtPromTemp = Frm_Principal.buscavalor.ToString().Remove(0, 2)
            CargaGrillaDetalle()
        End If

    End Sub

#End Region

#Region "Detalle recepcion -------------------------------------------------------------------> "
    Private Sub calcularpesocial()

        Dim sqlNumero As String = "select mae_pcaja from maeprod where mae_descr='" + txtprodnom.Text + "'"
        Dim tablaNumero As DataTable = fnc.ListarTablasSQL(sqlNumero)

        If tablaNumero.Rows.Count > 0 Then
            Dim var0 As String = tablaNumero.Rows(0)(0).ToString().Trim()
            If var0 = "" Then
                var0 = "0"
            End If

            Dim peso1 As Double = Convert.ToDouble(var0)
            Dim pes As Double = 0

            pes = peso1 * txtunid.Text
            kg.Text = Replace(kg.Text, ".", ",")
            pes = Convert.ToDecimal(kg.Text) - (peso1 * txtunid.Text)
            pes = pes - pesopa
            kg.Text = pes.ToString()

        Else
        End If

    End Sub
    Private Sub traepesopallet()
        Dim sqlNumero As String = "select pesoPallet from tiposopo where tsop_codi='" + txtsopcodi.Text + "'"
        Dim tablaNumero As DataTable = fnc.ListarTablasSQL(sqlNumero)

        If tablaNumero.Rows.Count > 0 Then
            pesopa = tablaNumero.Rows(0)(0).ToString()

        Else
        End If
    End Sub

    Sub regTagPall(ByVal NumPal As String)
        Try
            Dim RutCli = QuitarCaracteres(TxtClirut.Text.Trim)

            Dim sql = "select Estado from Clientes_TAGs where Rut_Cliente='" & RutCli & "'"
            Dim dt As New DataTable
            dt = fnc.ListarTablasSQL(sql)

            If (dt.Rows.Count > 0) Then
                If (dt.Rows(0).Item(0).ToString.Trim = "1") Then
                    Dim RespTag = MessageBox.Show("¿Registrar TAG RFID del pallet?", "Pregunta!", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    If (RespTag = Windows.Forms.DialogResult.Yes) Then
                        Dim NumPalAux = "00000000000000" & NumPal
                        Dim NumPalAux2 = "B" & NumPalAux.Substring(NumPalAux.Length - 14, 14) & "B"
                        fnc.writeTag(NumPalAux2)
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Ocurrio un error al registrar el TAG del pallet.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Btn_GuardaDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_GuardaDetalle.Click

        If validacionDetalle() = 0 Then
            modifi = ""
            If TxtPallet.Text = "" Then
                If fnc.verificaExistencia("fichrece", "frec_codi", TxtCodRece.Text) = True Then
                    MsgBox("No puede ingresar pallets a la recepción", MsgBoxStyle.Critical, "Aviso")
                    LimpiarCajas(Panel5)
                    Exit Sub
                End If

                Dim sqlNumero As String = "SELECT MAX(drec_codi) FROM TMPDETARECE WHERE frec_codi='" + TxtCodRece.Text + "'"
                Dim tablaNumero As DataTable = fnc.ListarTablasSQL(sqlNumero)

                If tablaNumero.Rows.Count > 0 Then
                    NumeroPallet = CerosAnteriorString(Val(tablaNumero.Rows(0)(0).ToString()) + 1, 2)
                Else
                    MsgBox("Error al recatar el Correlativo del pallet", MsgBoxStyle.Critical, "Aviso")
                End If

                If TxtClirut.Text = "766236200++" Then
                    traepesopallet()
                    calcularpesocial()
                    'AÑADIR REPLACE , POR * EN KG.TEXT
                    If Convert.ToInt32(kg.Text) < 0 Then
                        MsgBox("Kilos menor a 0 ", MsgBoxStyle.Critical, "Aviso")
                        Exit Sub
                    End If
                End If

                'Inicio Modificación Custodia/Arriendo Pallets. HAmestica 25/10/19
                Dim EsArr As String = "0"

                If (CheckArriendo.Checked Or chkCambioPallet.Checked) Then
                    EsArr = "1"
                End If

                Dim EstCamb As String = "I"

                If (chkCambioPallet.Checked) Then
                    EstCamb = "A"
                End If

                Dim sqlCamb As String = "SP_Control_Pallet_TMP_Recepcion_Dañado_Grabar '','" & TxtCodRece.Text.Trim & NumeroPallet.ToString.Trim & "','" & EstCamb & "','" & Frm_Principal.InfoUsuario.Text.Trim & "'"
                Dim dtCamb As New DataTable

                dtCamb = fnc.ListarTablasSQL(sqlCamb)
                'Fin Modificación Custodia/Arriendo Pallets. HAmestica 25/10/19

                Dim sqlGuardar As String = "INSERT INTO TMPDETARECE(frec_codi, drec_codi, drec_codpro, drec_origen,  drec_codsopo, drec_sopocli, drec_unidades, drec_peso, " +
                    "drec_fecrec, drec_rutcli, drec_contcli, drec_fecprod, drec_camara, drec_banda, drec_colum,  drec_piso,  drec_nivel, " +
                    "drec_tunel, drec_pallet, drec_nrosopo, drec_dtgracia,  drec_codsag, drec_tipo, FechaVencimiento, LoteCliente, drec_codper, drec_hora, drec_arriendo,estpallet) VALUES(" +
                    "'" + TxtCodRece.Text + "','" + NumeroPallet.ToString() + "','" + txtprodcod.Text + "','" + txtorigen.Text + "'," +
                    "'" + Val(txtsopcodi.Text).ToString() + "', '" + txtsopclie.Text + "','" + txtunid.Text + "','" + kg.Text + "', " +
                    "'" + devuelve_fecha(fecharece.Value) + "', '" + QuitarCaracteres(TxtClirut.Text) + "','" + txtcodcontrato.Text + "'," +
                    "'" + devuelve_fecha(felaboracion.Value) + "','71','00','00','00','0', '" + CmboTuneles.SelectedValue.ToString() + "','0'," +
                    "'0','" + TxtTemp.Text + "','" + txtcodsag.Text + "', '0', " +
                    "'" + devuelve_fecha(fvencimiento.Value) + "','" + loteclie.Text + "','" + Frm_Principal.InfoUsuario.Text + "','" + DevuelveHora() + "','" + EsArr + "','" + CMBESTPA.Text + "')"

                If fnc.MovimientoSQL(sqlGuardar) > 0 Then
                    Dim NumPallet As String = TxtCodRece.Text + NumeroPallet.ToString()

                    regTagPall(NumPallet)

                    MsgBox("Pallet agregado correctamente a la recepción", MsgBoxStyle.Information, "Aviso")
                    If chkpretrack.Checked = True Then
                        insertadetarececajas()
                    End If

                    CargaGrillaDetalle()

                    TxtPallet.Text = NumPallet

                    For i As Integer = 0 To Convert.ToInt32(TXTCANTIMP.Text.Trim()) - 1
                        Imprimir()
                    Next
                    LimpiarProductoIngreso()


                Else
                    MsgBox("Error al agregar el pallet a la recepción", MsgBoxStyle.Critical, "Aviso")
                End If

            Else
                'modifica tmprece
                'If validacionDetalle() = 0 Then

                'End If
                If fnc.verificaExistencia("detarece", "drec_codi", TxtPallet.Text) = False Then
                    If TxtClirut.Text = "801863000" Then
                        traepesopallet()
                        calcularpesocial()
                        If Convert.ToInt32(kg.Text) < 0 Then
                            MsgBox("Kilos menor a 0 ", MsgBoxStyle.Critical, "Aviso")
                            Exit Sub

                        End If

                    End If

                    'Inicio Modificación Custodia/Arriendo Pallets. HAmestica 25/10/19
                    Dim EsArr As String = "0"

                    If (CheckArriendo.Checked Or chkCambioPallet.Checked) Then
                        EsArr = "1"
                    End If

                    Dim EstCamb As String = "I"

                    If (chkCambioPallet.Checked) Then
                        EstCamb = "A"
                    End If

                    Dim sqlCamb As String = "SP_Control_Pallet_TMP_Recepcion_Dañado_Grabar '','" & TxtPallet.Text.Trim & "','" & EstCamb & "','" & Frm_Principal.InfoUsuario.Text.Trim & "'"
                    Dim dtCamb As New DataTable

                    dtCamb = fnc.ListarTablasSQL(sqlCamb)
                    'Fin Modificación Custodia/Arriendo Pallets. HAmestica 25/10/19


                    Dim sql As String = "UPDATE TMPDETARECE SET drec_codpro='" + txtprodcod.Text + "', " +
                                      "drec_origen='" + txtorigen.Text + "', drec_codsopo='" + Val(txtsopcodi.Text).ToString() + "', " +
                                      "drec_sopocli='" + txtsopclie.Text + "', drec_unidades='" + txtunid.Text + "', drec_peso='" + kg.Text.Replace(",", ".") + "', " +
                                      "drec_fecprod='" + devuelve_fecha(felaboracion.Value) + "', FechaVencimiento='" + devuelve_fecha(fvencimiento.Value) + "', " +
                                      "LoteCliente='" + loteclie.Text + "', drec_codsag='" + txtcodsag.Text + "', drec_arriendo='" + EsArr + "' , estpallet='" + CMBESTPA.Text + "' " +
                                      "WHERE frec_codi='" + TxtCodRece.Text + "' AND drec_codi='" + TxtPallet.Text.Remove(0, 7) + "'"

                    If fnc.MovimientoSQL(sql) > 0 Then
                        Dim NumPallet = TxtPallet.Text.Remove(0, 7)

                        regTagPall(TxtPallet.Text.Trim)

                        MsgBox("Pallet actualizado ", MsgBoxStyle.Information, "Aviso")
                        CargaGrillaDetalle()
                    Else
                        MsgBox("Error al actualizar el pallet ", MsgBoxStyle.Critical, "Aviso")
                    End If
                Else
                    'modifica recepcion
                    If TxtClirut.Text = "801863000" Then
                        traepesopallet()
                        calcularpesocial()
                        If Convert.ToInt32(kg.Text) < 0 Then
                            MsgBox("Kilos menor a 0 ", MsgBoxStyle.Critical, "Aviso")
                            Exit Sub

                        End If

                    End If

                    If (txtsopclie.Text.Trim() <> "") Then
                        Dim sqlNumero As String = "SELECT * from DETARECE where DREC_CODI <> '" + TxtPallet.Text.Trim() + "' and drec_sopocli ='" + txtsopclie.Text.Trim() + "' and frec_codi1 ='" + TxtCodRece.Text.Trim() + "'"
                        Dim tablaNumero As DataTable = fnc.ListarTablasSQL(sqlNumero)

                        If tablaNumero.Rows.Count > 0 Then

                            MsgBox("Error al actualizar el pallet, Sop. cliente duplicado ", MsgBoxStyle.Critical, "Aviso")
                            Exit Sub
                        End If
                    End If


                    ''Inicio Modificación Custodia/Arriendo Pallets. HAmestica 25/10/19
                    'Dim EsArr As String = "0"

                    'If (CheckArriendo.Checked Or chkCambioPallet.Checked) Then
                    '    EsArr = "1"
                    'End If

                    'Dim EstCamb As String = "I"

                    'If (chkCambioPallet.Checked) Then
                    '    EstCamb = "A"
                    'End If

                    'Dim sqlCamb As String = "SP_Control_Pallet_TMP_Recepcion_Dañado_Grabar '','" & TxtCodRece.Text.Trim & NumeroPallet.ToString.Trim & "','" & EstCamb & "','" & Frm_Principal.InfoUsuario.Text.Trim & "'"
                    'Dim dtCamb As New DataTable

                    'dtCamb = fnc.ListarTablasSQL(sqlCamb)
                    ''Fin Modificación Custodia/Arriendo Pallets. HAmestica 25/10/19



                    Dim sql As String = "UPDATE DETARECE SET drec_codpro='" + txtprodcod.Text + "', " +
                                     "drec_origen='" + txtorigen.Text + "', drec_codsopo='" + Val(txtsopcodi.Text).ToString() + "', " +
                                     "drec_sopocli='" + txtsopclie.Text + "', drec_unidades='" + txtunid.Text + "', drec_peso='" + kg.Text.Replace(",", ".") + "', " +
                                     "drec_fecprod='" + devuelve_fecha(felaboracion.Value) + "', FechaVencimiento='" + devuelve_fecha_Formato2(devuelve_fecha(fvencimiento.Value)) + "', Estpallet = '" + CMBESTPA.Text + "', " +
                                     "LoteCliente='" + loteclie.Text + "', drec_codsag='" + txtcodsag.Text + "', drec_arriendo='" + EstadoCheckBox(CheckArriendo.CheckState) + "' " +
                                     "WHERE drec_codi='" + TxtPallet.Text + "'"

                    If fnc.MovimientoSQL(sql) > 0 Then
                        Dim NumPallet = TxtPallet.Text.Trim

                        regTagPall(NumPallet)

                        MsgBox("Pallet actualizado ", MsgBoxStyle.Information, "Aviso")
                        modifi = ""
                        guardaVasAutomatico()
                        'LOG MODIFICO RECEPCION *************************************************************************************
                        Dim _log As String = "INSERT INTO LOG_FichRece(LFR_CODI, LFR_FECHA, LFR_HORA, LFR_USUARIO, LFR_PC)" +
                            "VALUES('" + TxtCodRece.Text + "','" + devuelve_fecha(fnc.DevuelveFechaServidor()) + "'," +
                            "'" + DevuelveHora() + "','" + Frm_Principal.InfoUsuario.Text + "','" + My.Computer.Name.ToString() + "')"
                        fnc.MovimientoSQL(_log)
                        'LOG MODIFICO RECEPCION *************************************************************************************

                        BuscaDetalleRecepcionCompleta()
                        SumaTotalPallets()
                        ' modifica rackdeta

                        Dim SQL_RACKDETA As String = "UPDATE rackdeta SET  racd_codpro='" + txtprodcod.Text + "', " +
                            "racd_unidades='" + txtunid.Text + "', racd_peso='" + kg.Text.Replace(",", ".") + "', racd_fecpro='" + devuelve_fecha(felaboracion.Value) + "', " +
                           "fechavencimiento='" + devuelve_fecha_Formato2(devuelve_fecha(fvencimiento.Value)) + "', lotecliente='" + loteclie.Text + "' WHERE racd_codi='" + TxtPallet.Text + "'"

                        fnc.MovimientoSQL(SQL_RACKDETA)

                        'modifica encabezado
                        Dim SqlFich As String = "UPDATE fichrece SET frec_totsopo='" + txtsoportantes.Text + "', frec_totunidad='" + txtcajas.Text + "', " +
                               "frec_totpeso='" + txtkilos.Text + "' WHERE frec_codi='" + TxtCodRece.Text + "'"
                        fnc.MovimientoSQL(SqlFich)

                        'modifica movpallet
                        Dim SqlMovpallet As String = "UPDATE movpallet SET mov_doc='" + TxtCodRece.Text + "', mov_saldo='" + txtunid.Text + "' WHERE  mov_folio='" + TxtPallet.Text + "' "
                        fnc.MovimientoSQL(SqlMovpallet)
                        Imprimir()
                        LimpiarProductoIngreso()
                        BuscaRecepcionCompleta()
                        CheckArriendo.Checked = False
                        txtsopclie.Focus()

                        If Me.DetaRece.RowCount > 0 Then
                            Me.DetaRece.ClearSelection()
                            Me.DetaRece.CurrentCell = Me.DetaRece.Rows(Me.DetaRece.RowCount - 1).Cells(0)
                            Me.DetaRece.Refresh()
                        End If
                        Exit Sub
                    Else
                        MsgBox("error al actualizar el pallet ", MsgBoxStyle.Information, "Aviso")
                    End If

                End If
                Imprimir()
                LimpiarProductoIngreso()
            End If
        End If
        txtsopclie.Focus()

        If Me.DetaRece.RowCount > 0 Then
            Me.DetaRece.ClearSelection()
            Me.DetaRece.CurrentCell = Me.DetaRece.Rows(Me.DetaRece.RowCount - 1).Cells(0)
            Me.DetaRece.Refresh()
        End If
        modifi = ""
    End Sub

#End Region

#Region "Validador de Temperaturas"

    Private Sub temp1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim x As TextBox = sender
        If Not IsNumeric(e) Then
            If e.KeyChar = "." Or e.KeyChar = ChrW(8) Or e.KeyChar = "-" Then

                For i As Integer = 0 To x.Text.Length - 1
                    If x.Text.Chars(i) = e.KeyChar Then
                        If Not (x.SelectionStart = 0 AndAlso x.SelectionLength = x.Text.Length) Then
                            SoloNumeros(sender, e)
                        End If
                    ElseIf x.Text.Chars(i) = e.KeyChar Then
                        SoloNumeros(sender, e)
                    ElseIf x.Text.Chars(i) = e.KeyChar Then
                        SoloNumeros(sender, e)
                    End If
                Next
            Else
                SoloNumeros(sender, e)
            End If
        End If
    End Sub

    'Private Sub temp1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Dim x As TextBox = sender
    '    If Not IsNumeric(x.Text) Then
    '        temp1.Text = "0"
    '        sender.SelectAll()
    '    Else
    '        If x.Text.Chars(x.TextLength - 1) = "," Or x.Text.Chars(x.TextLength - 1) = "." Or x.Text.Chars(x.TextLength - 1) = "-" Then
    '            temp1.Text = temp1.Text.Remove(x.TextLength - 1)
    '        End If
    '    End If
    '    PromedioTemperaturas()
    'End Sub

    'Private Sub temp2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Dim x As TextBox = sender
    '    If Not IsNumeric(x.Text) Then
    '        temp2.Text = "0"
    '        sender.SelectAll()
    '    Else
    '        If x.Text.Chars(x.TextLength - 1) = "," Or x.Text.Chars(x.TextLength - 1) = "." Or x.Text.Chars(x.TextLength - 1) = "-" Then
    '            temp2.Text = temp2.Text.Remove(x.TextLength - 1)
    '        End If
    '    End If
    '    PromedioTemperaturas()
    'End Sub

    'Private Sub temp3_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Dim x As TextBox = sender
    '    If Not IsNumeric(x.Text) Then
    '        temp3.Text = "0"
    '        sender.SelectAll()
    '    Else
    '        If x.Text.Chars(x.TextLength - 1) = "," Or x.Text.Chars(x.TextLength - 1) = "." Or x.Text.Chars(x.TextLength - 1) = "-" Then
    '            temp3.Text = temp3.Text.Remove(x.TextLength - 1)
    '        End If
    '    End If
    '    PromedioTemperaturas()
    'End Sub

    'Sub PromedioTemperaturas()

    '    If Not IsNumeric(temp1.Text) Then
    '        temp1.Text = "0"
    '    ElseIf Not IsNumeric(temp2.Text) Then
    '        temp2.Text = "0"
    '    ElseIf Not IsNumeric(temp3.Text) Then
    '        temp3.Text = "0"
    '    End If

    '    If IsNumeric(temp1.Text) AndAlso IsNumeric(temp2.Text) AndAlso IsNumeric(temp3.Text) Then
    '        Try
    '            Dim a As Decimal = temp1.Text.Replace(".", ",")
    '            Dim b As Decimal = temp2.Text.Replace(".", ",")
    '            Dim c As Decimal = temp3.Text.Replace(".", ",")

    '            Dim d As Double = ((a + b + c) / 3)
    '            d = d.ToString("##,##0.0")

    '            temppromedio.Text = d.ToString().Replace(",", ".")

    '        Catch ex As Exception

    '        End Try
    '    End If

    'End Sub

#End Region

#Region "Imprimir etiqueta  Pallet recepcionado"

    Private Sub Imprimir()
        ' imprimir ZEBRA

        Try

            Dim PrintDocument1 As New PrintDocument

            PrintDocument1.PrinterSettings = prtsettings
            AddHandler PrintDocument1.PrintPage, AddressOf print_PrintPage

            Dim sql_Impresora As String = "SELECT imp_etiq, imp_COM1 FROM conf_impresora WHERE imp_comp='" + My.Computer.Name + "'"
            Dim tabla_conf As DataTable = fnc.ListarTablasSQL(sql_Impresora)

            If tabla_conf.Rows.Count > 0 Then
                If tabla_conf.Rows(0)(1).ToString() = "COM1" Then
                    Dim cli = txtclinom.Text
                    Dim producto = txtprodnom.Text
                    Dim folio_cliente = txtsopclie.Text
                    Dim unidades = txtunid.Text
                    Dim kilos = kg.Text
                    Dim fproduccion = Convert.ToDateTime(felaboracion.Value).ToShortDateString()
                    Dim fvenci = Convert.ToDateTime(fvencimiento.Value).ToShortDateString()
                    Dim numero_pallet = TxtPallet.Text
                    Dim numero_pallet_Completo = DigitoVerificadorEAN128UCC("1780000000" + CerosAnteriorString(CerosAnteriorString(numero_pallet, 2), 7))
                    Dim cop As String = ""

                    COM1.Impresion(cli, producto, folio_cliente, unidades, kilos, fproduccion, fvenci, numero_pallet, "1780000000" + CerosAnteriorString(CerosAnteriorString(numero_pallet, 2), 7), fecharece.Value, cop)

                    Exit Sub
                Else
                    PrintDocument1.PrinterSettings.PrinterName = tabla_conf.Rows(0)(0).ToString()
                End If
            Else
                MsgBox("Debe seleccionar la impresora antes de imprimir una etiqueta", MsgBoxStyle.Critical, "Aviso")
                Exit Sub
            End If

            'PrintDocument1.PrinterSettings.PrinterName = "ZDesigner 105SL 203DPI"
            PrintDocument1.Print()

        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub

    Dim prtsettings = New PrinterSettings()
    Public Function ByteArrayToImage(ByVal byteArrayIn As Byte()) As Image
        Dim ms As New MemoryStream(byteArrayIn)
        Return Image.FromStream(ms)
    End Function
    Private Sub cargaimg()

        Dim sqlImagen As String = "SELECT foto from etiimg "

        Dim tablaimagen As DataTable = fnc.ListarTablasSQL(sqlImagen)

        If tablaimagen.Rows.Count > 0 Then

            'Imagen1
            If tablaimagen.Rows(0)(0).ToString() <> "" Then
                'PictureBox1.Image = Base64ToImage(tablaimagen.Rows(0)(0))
                PictureBox1.Image = ByteArrayToImage(DirectCast(tablaimagen.Rows(0)(0), Byte()))

            Else
                PictureBox1.Image = My.Resources.Resources.usuario_anonimo
            End If

        End If

    End Sub


    Public Sub print_PrintPageF3(ByVal sender As Object, ByVal e As PrintPageEventArgs)


        Dim cli = cliF3
        Dim producto = productoF3
        Dim folio_cliente = folio_clienteF3
        Dim unidades = unidadesF3
        Dim kilos = kilosF3
        Dim fproduccion = fproduccionF3
        Dim fvenci = fvenciF3
        Dim numero_pallet = numero_palletF3

        Dim nroLote = ""

        Dim sqlLot = "select top 1 LoteCliente=isnull(LoteCliente,'') from detarece with(nolock) where drec_codi='" & numero_pallet & "'"
        Dim dtLot As DataTable = fnc.ListarTablasSQL(sqlLot)
        If (dtLot.Rows.Count > 0) Then
            nroLote = dtLot.Rows(0).Item(0).ToString.Trim
        End If

        Dim tipo_alamacen = Cmbo_Almacenamiento.Text.Trim()
        tipo_alamacen = tipo_alamacen.Substring(0, 1)
        ' 01 - 02 - 03 - 04 - 05 
        Dim numero_pallet_Completo = DigitoVerificadorEAN128UCC("1780000000" + CerosAnteriorString(CerosAnteriorString(numero_palletF3, 2), 7))

        Dim sql As String = "SELECT racd_unidades FROM rackdeta WHERE racd_codi='" + numero_pallet + "'"

        Dim dt As DataTable = fnc.ListarTablasSQL(sql)
        Dim stock As String = "0"

        If dt.Rows.Count > 0 Then
            stock = dt.Rows(0)(0).ToString()
        ElseIf Convert.ToDateTime(fnc.DevuelveFechaServidor()).ToShortDateString() = Convert.ToDateTime(fecharece.Value).ToShortDateString() Then
            stock = unidades
        End If
        ' imprimimos la cadena en el margen izquierdo
        Dim xPos As Single = e.MarginBounds.Left

        ' Las fuentes a usar
        Dim prFont As New Font("Arial", 8, FontStyle.Bold)
        Dim Titulo As New Font("Arial", 18, FontStyle.Bold)
        Dim Titulo2 As New Font("Arial", 34, FontStyle.Bold)
        ' dibuja rectangulo
        '    e.Graphics.DrawRectangle(Pens.Black, New Rectangle(3, 8, 375, 385))
        Dim x As Single = 115.0F
        Dim y As Single = 135.0F
        Dim width As Single = 250.0F
        Dim height As Single = 25.0F
        Dim drawRect As New RectangleF(x, y, width, height)
        cargaimg()
        ' imprimir logo -----------------------------------------------
        Dim img_logo As New PictureBox
        img_logo.Image = PictureBox1.Image
        e.Graphics.DrawImage(img_logo.Image, 80, 10, 220, 70)
        '--------------------------------------------------------------
        e.Graphics.DrawString(tipo_alamacen, Titulo2, Brushes.Black, 300, 10)
        'e.Graphics.DrawString("       PRECISA FROZEN     ", Titulo, Brushes.Black, 10, 50)

        e.Graphics.DrawString("www.precisafrozen.cl - FONO: +56 72 2 585680", prFont, Brushes.Black, 55, 80)
        e.Graphics.DrawString("Longitudinal sur KM 95.5 Requinoa VI Región, Chile.", prFont, Brushes.Black, 47, 95)
        e.Graphics.DrawString("------------------------------------------------------------------------------------", prFont, Brushes.Black, 30, 105)

        e.Graphics.DrawString("CLIENTE", prFont, Brushes.Black, 10, 120)
        e.Graphics.DrawString(": " + cli, prFont, Brushes.Black, 105, 120)

        e.Graphics.DrawString("PRODUCTO", prFont, Brushes.Black, 10, 135)
        e.Graphics.DrawString(": ", prFont, Brushes.Black, 105, 135)
        e.Graphics.DrawString(producto, prFont, Brushes.Black, drawRect)

        e.Graphics.DrawString("FOLIO CLIENTE", prFont, Brushes.Black, 10, 160)
        e.Graphics.DrawString(": " + folio_cliente + " UND: " + stock + " / " + unidades + "   KG: " + kilos, prFont, Brushes.Black, 105, 160)

        e.Graphics.DrawString("F. PRODUCCION", prFont, Brushes.Black, 10, 180)
        e.Graphics.DrawString(": " + fproduccion + "   F. VENCIMIENTO: " + fvenci, prFont, Brushes.Black, 105, 180)

        e.Graphics.DrawString("LOTE", prFont, Brushes.Black, 10, 200)
        e.Graphics.DrawString(": " + nroLote, prFont, Brushes.Black, 105, 200)

        'e.Graphics.DrawString("PALLET: ", New Font("Arial", 18, FontStyle.Bold), Brushes.Black, 10, 180)

        '  e.Graphics.DrawString(numero_pallet, New Font("Franklin Gothic Demi Cond", 60, FontStyle.Bold), Brushes.Black, 0, 200)
        e.Graphics.DrawString(numero_pallet, New Font("Arial", 55, FontStyle.Bold), Brushes.Black, 0, 210)

        '                                                                                          TRUE o FALSE Muestra los numeros bajo el codigo de barras
        Dim bm As Bitmap = BarCode.Code128(numero_pallet_Completo, BarCode.Code128SubTypes.CODE128_UCC, False, 0.0)
        Dim picturebox As New PictureBox

        picturebox.Image = bm

        e.Graphics.DrawImage(picturebox.Image, 10, 290, 350, 50)
        'codigo de barras ------>
        e.Graphics.DrawString(numero_pallet_Completo, New Font("Arial", 16, FontStyle.Bold), Brushes.Black, 50, 350)

        e.HasMorePages = False

    End Sub











    Public Sub print_PrintPage(ByVal sender As Object, ByVal e As PrintPageEventArgs)


        Dim cli = txtclinom.Text
        Dim producto = txtprodnom.Text
        Dim folio_cliente = txtsopclie.Text
        Dim unidades = txtunid.Text
        Dim kilos = kg.Text
        Dim fproduccion = Convert.ToDateTime(felaboracion.Value).ToShortDateString()
        Dim fvenci = Convert.ToDateTime(fvencimiento.Value).ToShortDateString()
        Dim numero_pallet = TxtPallet.Text

        Dim nroLote = ""

        Dim sqlLot = "select top 1 LoteCliente=isnull(LoteCliente,'') from detarece with(nolock) where drec_codi='" & numero_pallet & "'"
        Dim dtLot As DataTable = fnc.ListarTablasSQL(sqlLot)
        If (dtLot.Rows.Count > 0) Then
            nroLote = dtLot.Rows(0).Item(0).ToString.Trim
        End If

        Dim tipo_alamacen = Cmbo_Almacenamiento.Text.Trim()
        tipo_alamacen = tipo_alamacen.Substring(0, 1)
        ' 01 - 02 - 03 - 04 - 05 
        Dim numero_pallet_Completo = DigitoVerificadorEAN128UCC("1780000000" + CerosAnteriorString(CerosAnteriorString(numero_pallet, 2), 7))

        Dim sql As String = "SELECT racd_unidades FROM rackdeta WHERE racd_codi='" + numero_pallet + "'"

        Dim dt As DataTable = fnc.ListarTablasSQL(sql)
        Dim stock As String = "0"

        If dt.Rows.Count > 0 Then
            stock = dt.Rows(0)(0).ToString()
        ElseIf Convert.ToDateTime(fnc.DevuelveFechaServidor()).ToShortDateString() = Convert.ToDateTime(fecharece.Value).ToShortDateString() Then
            stock = unidades
        End If
        ' imprimimos la cadena en el margen izquierdo
        Dim xPos As Single = e.MarginBounds.Left

        ' Las fuentes a usar
        Dim prFont As New Font("Arial", 8, FontStyle.Bold)
        Dim Titulo As New Font("Arial", 18, FontStyle.Bold)
        Dim Titulo2 As New Font("Arial", 34, FontStyle.Bold)
        ' dibuja rectangulo
        '    e.Graphics.DrawRectangle(Pens.Black, New Rectangle(3, 8, 375, 385))
        Dim x As Single = 115.0F
        Dim y As Single = 135.0F
        Dim width As Single = 250.0F
        Dim height As Single = 25.0F
        Dim drawRect As New RectangleF(x, y, width, height)
        cargaimg()
        ' imprimir logo -----------------------------------------------
        Dim img_logo As New PictureBox
        img_logo.Image = PictureBox1.Image
        e.Graphics.DrawImage(img_logo.Image, 80, 10, 220, 70)
        '--------------------------------------------------------------
        e.Graphics.DrawString(tipo_alamacen, Titulo2, Brushes.Black, 300, 10)
        'e.Graphics.DrawString("PRECISA FROZEN", Titulo, Brushes.Black, 10, 50)

        e.Graphics.DrawString("www.precisafrozen.cl - FONO: +56 72 2 585680", prFont, Brushes.Black, 55, 80)
        e.Graphics.DrawString("Longitudinal sur KM 95.5 Requinoa VI Región, Chile.", prFont, Brushes.Black, 47, 95)
        e.Graphics.DrawString("------------------------------------------------------------------------------------", prFont, Brushes.Black, 30, 105)

        e.Graphics.DrawString("CLIENTE", prFont, Brushes.Black, 10, 120)
        e.Graphics.DrawString(": " + cli, prFont, Brushes.Black, 105, 120)

        e.Graphics.DrawString("PRODUCTO", prFont, Brushes.Black, 10, 135)
        e.Graphics.DrawString(": ", prFont, Brushes.Black, 105, 135)
        e.Graphics.DrawString(producto, prFont, Brushes.Black, drawRect)

        e.Graphics.DrawString("FOLIO CLIENTE", prFont, Brushes.Black, 10, 160)
        e.Graphics.DrawString(": " + folio_cliente + " UND: " + stock + " / " + unidades + "   KG: " + kilos, prFont, Brushes.Black, 105, 160)

        e.Graphics.DrawString("F. PRODUCCION", prFont, Brushes.Black, 10, 180)
        e.Graphics.DrawString(": " + fproduccion + "   F. VENCIMIENTO: " + fvenci, prFont, Brushes.Black, 105, 180)

        e.Graphics.DrawString("LOTE", prFont, Brushes.Black, 10, 200)
        e.Graphics.DrawString(": " + nroLote, prFont, Brushes.Black, 105, 200)

        'e.Graphics.DrawString("PALLET: ", New Font("Arial", 18, FontStyle.Bold), Brushes.Black, 10, 180)

        '  e.Graphics.DrawString(numero_pallet, New Font("Franklin Gothic Demi Cond", 60, FontStyle.Bold), Brushes.Black, 0, 200)
        e.Graphics.DrawString(numero_pallet, New Font("Arial", 55, FontStyle.Bold), Brushes.Black, 0, 210)

        '                                                                                          TRUE o FALSE Muestra los numeros bajo el codigo de barras
        Dim bm As Bitmap = BarCode.Code128(numero_pallet_Completo, BarCode.Code128SubTypes.CODE128_UCC, False, 0.0)
        Dim picturebox As New PictureBox

        picturebox.Image = bm

        e.Graphics.DrawImage(picturebox.Image, 10, 290, 350, 50)
        'codigo de barras ------>
        e.Graphics.DrawString(numero_pallet_Completo, New Font("Arial", 16, FontStyle.Bold), Brushes.Black, 50, 350)

        e.HasMorePages = False

    End Sub

    Private Function seleccionarImpresora() As Boolean
        'Public prtDialog As New PrintDialog
        'If prtSettings Is Nothing Then
        'End If
        Dim Dialog As New PrintDialog

        With Dialog
            .AllowPrintToFile = False
            .AllowSelection = False
            .AllowSomePages = False
            .PrintToFile = False
            .ShowHelp = False
            .ShowNetwork = True

            .PrinterSettings = prtsettings

            If .ShowDialog() = DialogResult.OK Then
                prtsettings = .PrinterSettings
            Else
                Return False
            End If
        End With
        Return True
    End Function

    Private Sub SubImprime()
        ' ejemplo simple para imprimir en .NET
        ' Usamos una clase del tipo PrintDocument

        Dim printDoc As New PrintDocument
        If seleccionarImpresora() = True Then
            printDoc.PrinterSettings = prtsettings()

            ' asignamos el método de evento para cada página a imprimir()
            AddHandler printDoc.PrintPage, AddressOf print_PrintPage
            ' indicamos que queremos imprimir
            printDoc.Print()
        End If
    End Sub

    Public Sub DrawPointsHelper(ByVal e As PaintEventArgs, ByVal pathPoints() As PointF, ByVal xOffset As Integer)
        Dim y As Integer = 20
        Dim myFont As New Font("Arial", 8)
        Dim i As Integer
        For i = 0 To pathPoints.Length - 1
            e.Graphics.DrawString(pathPoints(i).X.ToString() + _
            ", " + pathPoints(i).Y.ToString(), myFont, Brushes.Black, _
            xOffset, y)
            y += 20
        Next i
    End Sub
    Private Sub IMPREANTIGUA()

    End Sub
    Private Sub IMPRIMIRETIQUETAToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IMPRIMIRETIQUETAToolStripMenuItem.Click
        If fila_grilladetalle > -1 Then
            TxtPallet.Text = Me.DetaRece.Rows(fila_grilladetalle).Cells("Cod_Pallet").Value.ToString()
            txtprodcod.Text = Me.DetaRece.Rows(fila_grilladetalle).Cells("Cod_Producto").Value.ToString()
            txtprodnom.Text = Me.DetaRece.Rows(fila_grilladetalle).Cells("Nombre_Producto").Value.ToString()
            txtsopcodi.Text = Me.DetaRece.Rows(fila_grilladetalle).Cells("CodSopo").Value.ToString()
            txtsopnombre.Text = Me.DetaRece.Rows(fila_grilladetalle).Cells("NomSopo").Value.ToString()
            txtunid.Text = Me.DetaRece.Rows(fila_grilladetalle).Cells("Cant_Pallets").Value.ToString()
            kg.Text = Me.DetaRece.Rows(fila_grilladetalle).Cells("Peso").Value.ToString()
            felaboracion.Value = devuelve_fecha(Me.DetaRece.Rows(fila_grilladetalle).Cells("Elaboracion").Value.ToString())
            fvencimiento.Value = devuelve_fecha(Me.DetaRece.Rows(fila_grilladetalle).Cells("Vencimiento").Value.ToString())
            loteclie.Text = Me.DetaRece.Rows(fila_grilladetalle).Cells("Lote").Value.ToString()
            txtcodsag.Text = Me.DetaRece.Rows(fila_grilladetalle).Cells("Codsag").Value.ToString()
            txtsopclie.Text = Me.DetaRece.Rows(fila_grilladetalle).Cells("SopCliente").Value.ToString()
            Imprimir()
            LimpiarProductoIngreso()
            fila_grilladetalle = -1
        End If
    End Sub
#End Region

#Region "Eventos de validacion "

    Private Sub horaini_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles horainic.Click
        horainic.SelectAll()
    End Sub

    Private Sub hora_ter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles horaterm.Click
        horaterm.SelectAll()
    End Sub

    Private Sub Add_year_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        fvencimiento.Value = fvencimiento.Value.AddYears(+1)
    End Sub

    Private Sub txtsopclie_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
         Handles TxtFilm.KeyPress, TxtArriendo.KeyPress
        SoloNumeros(sender, e)
    End Sub

    Private Sub kg_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles kg.KeyPress

        If e.KeyChar = ChrW(13) Then
            loteclie.Focus()
        Else
            Dim KeyAscii As Short = Asc(e.KeyChar)
            If Not ((KeyAscii >= System.Windows.Forms.Keys.D0 And KeyAscii <= System.Windows.Forms.Keys.D9) Or
                    (KeyAscii = System.Windows.Forms.Keys.Back) Or Chr(KeyAscii) = "." Or (Chr(KeyAscii) Like "[ ]")) Then
                KeyAscii = 0
                kg.Focus()
            End If
            If KeyAscii = 0 Then
                e.Handled = True
            End If

            If kg.Text.IndexOf(".") >= 0 And e.KeyChar = "." Then
                e.Handled = True
            End If

            If kg.Text.IndexOf(".") > 0 Then
                If kg.SelectionStart > kg.Text.IndexOf(".") Then
                    If kg.Text.Length - kg.Text.IndexOf(".") = 3 Then
                        e.Handled = True
                    End If
                End If
            End If
        End If

    End Sub

    Private Sub txtcodigo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodRece.KeyPress, TxtArriendo.KeyPress
        If e.KeyChar = ChrW(13) Then
            buscarRece()
        Else
            SoloNumeros(sender, e)
        End If
    End Sub

    Sub buscarRece()
        Try
            If TxtCodRece.Text = "" Then
                If RealizarAccion("001", "001") = False Then
                    Exit Sub
                End If

                TxtCodRece.Text = BuscaCorrelativo("006")

                corregirCorrelativo()

                'If TxtCodRece.Text.Substring(0, 3) = "000" Then
                '    Dim stttt As String = TxtCodRece.Text.Substring(0, 3)

                '    stttt = stttt



                'Else
                '    TxtCodRece.Text = ""
                '    Dim sql_log As String = "INSERT INTO LOG_SALTOCORR(tmps_codi, tmps_correl, tmps_personal, tmps_fecha, tmps_gestion)VALUES( " +
                ' "'SI','006','" + Frm_Principal.InfoUsuario.Text + "','" + fnc.DevuelveFechaServidor() + "','SALTO GRABADO OTRO LADO')"
                '    fnc.MovimientoSQL(sql_log)


                '    TxtCodRece.Text = BuscaCorrelativo("006")

                'End If

                If TxtCodRece.Text.Trim = "SI" Or TxtCodRece.Text = "0003880" Then

                    Dim sql_log As String = "INSERT INTO LOG_SALTOCORR(tmps_codi, tmps_correl, tmps_personal, tmps_fecha, tmps_gestion)VALUES( " +
                   "'SI','006','" + Frm_Principal.InfoUsuario.Text + "','" + fnc.DevuelveFechaServidor() + "','SALTO GRABADO OTRO LADO')"
                    fnc.MovimientoSQL(sql_log)



                End If


                Dim f = New Frm_CamionesAndenRecepcion
                f.ShowDialog(Frm_Principal)

                If fnc.verificaExistencia("zchecklist", "cl_fol", Frm_Principal.buscavalor.ToString()) = False Then
                    Console.WriteLine(Frm_Principal.buscavalor.ToString())
                    If Frm_Principal.buscavalor.ToString() <> "NO" Then
                        MsgBox("No ha seleccionado un camion ", MsgBoxStyle.Critical, "Aviso")
                        CancelaCorrelativo("006", TxtCodRece.Text)
                        TxtCodRece.Text = ""
                        TxtCodRece.Focus()
                        Exit Sub
                    Else
                        Frm_Principal.buscavalor = ""
                        TxtCodRece.Enabled = False
                        btn_guardar.Enabled = True
                        Gb_Encabezado.Enabled = True
                        Tab_Detalle.Enabled = True
                        Lbl_EstadoGuia.Text = "ACTIVA"
                        Lbl_EstadoGuia.ForeColor = Color.Blue
                        txtrutchofer.Enabled = False
                        TxtClirut.Enabled = False
                        horalleg.Text = DevuelveHora()
                        TimeAdicionales.Start()
                    End If
                Else
                    Dim sql As String = "SELECT cl_rutcli, cli_nomb, cl_chorut, cho_nombre, cl_pate, cl_choemp,  " +
                                        "right(convert(char(8),Cl_Lleg,8),8) AS HORA, Cl_Ting  FROM  zchecklist, choferes, clientes  " +
                                        "WHERE cli_rut=cl_rutcli AND cl_chorut=cho_rut  AND  cl_fol='" + Frm_Principal.buscavalor.ToString() + "'"

                    Dim TablaCheck As DataTable = fnc.ListarTablasSQL(sql)

                    If TablaCheck.Rows.Count > 0 Then
                        TxtFolioPorteria.Text = Frm_Principal.buscavalor.ToString()
                        TxtClirut.Text = TablaCheck.Rows(0)(0).ToString()
                        txtclinom.Text = TablaCheck.Rows(0)(1).ToString()
                        txtrutchofer.Text = TablaCheck.Rows(0)(2).ToString()
                        txtnombrechofer.Text = TablaCheck.Rows(0)(3).ToString()
                        txtpatente.Text = TablaCheck.Rows(0)(4).ToString()
                        txtempresa.Text = TablaCheck.Rows(0)(5).ToString()
                        horalleg.Text = TablaCheck.Rows(0)(6).ToString()
                        txtTempTermo.Text = TablaCheck.Rows(0)(7).ToString()

                        'Actualizacion Camiones Carga Descarga tomados. 07-06-19
                        'cambio estado del checklist
                        'sql = "UPDATE zcheckList SET cl_estfrigo='1' WHERE cl_fol='" + Frm_Principal.buscavalor.ToString() + "'"
                        'fnc.MovimientoSQL(sql)
                        'Fin Actualizacion Camiones Carga Descarga tomados. 07-06-19

                    Else
                        CancelaCorrelativo("006", TxtCodRece.Text)
                        TxtCodRece.Text = ""
                        TxtCodRece.Focus()
                        Exit Sub
                    End If

                    Frm_Principal.buscavalor = ""
                    TxtCodRece.Enabled = False
                    btn_guardar.Enabled = True
                    Gb_Encabezado.Enabled = True
                    Tab_Detalle.Enabled = True
                    Lbl_EstadoGuia.Text = "ACTIVA"
                    Lbl_EstadoGuia.ForeColor = Color.Blue
                    txtrutchofer.Enabled = False
                    TxtClirut.Enabled = False
                    TimeAdicionales.Start()
                End If

                btn_BuscaCliente.Enabled = True
                Btn_BuscaContrato.Enabled = True
                Btn_BuscaChofer.Enabled = True
                BtnBuscar.Enabled = False

                If horainic.Text.Trim = ":" Then
                    horainic.Text = DevuelveHora()
                End If
            Else
                If fnc.verificaExistencia("fichrece", "frec_codi", CerosAnteriorString(TxtCodRece.Text, 7)) = True Then
                    BuscaRecepcionCompleta()
                    Tab_Detalle.Enabled = True
                Else
                    'MsgBox("La recepción ingresada no existe", MsgBoxStyle.Critical, "Aviso")
                    'TxtCodRece.Text = ""
                    'TxtCodRece.Focus()

                    If MsgBox("Esta guia de recepcion puede estar llamada en un temporal, si la llama ahora es posible que quede en estado nulo. ¿Desea Continuar ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbYes Then
                        Dim sqlVerifNul As String = "SP_Recepciones_Nulas_Validar '" & TxtCodRece.Text.Trim & "'"
                        Dim dtVerifNul As New DataTable
                        dtVerifNul = fnc.ListarTablasSQL(sqlVerifNul)

                        If (dtVerifNul.Rows.Count > 0) Then
                            Dim RespVerifNul As Integer = CInt(dtVerifNul.Rows(0).Item(0).ToString.Trim)

                            If (RespVerifNul = -2 Or RespVerifNul = -4) Then
                                MsgBox("La Recepción ingresada no existe", MsgBoxStyle.Critical, "Aviso")
                                TxtCodRece.Text = ""
                                TxtCodRece.Focus()
                            ElseIf (RespVerifNul = -3) Then
                                MsgBox("Recepción con problemas. Favor avisar a informática.", MsgBoxStyle.Critical, "Aviso")
                                TxtCodRece.Text = ""
                                TxtCodRece.Focus()
                            ElseIf (RespVerifNul = 1) Then
                                buscarRece()
                            ElseIf (RespVerifNul = -1) Then
                                MsgBox("Ocurrió un error al buscar la Recepción.", MsgBoxStyle.Critical, "Aviso")
                                TxtCodRece.Text = ""
                                TxtCodRece.Focus()
                            End If
                        End If
                    Else
                        TxtCodRece.Text = ""
                        TxtCodRece.Focus()
                        Exit Sub

                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtsopclie_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtsopclie.KeyDown
        If e.KeyCode = Keys.Enter Then
            felaboracion.Focus()
        End If
    End Sub

    Private Sub felaboracion_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles felaboracion.KeyDown
        If e.KeyCode = Keys.Enter Then
            fvencimiento.Focus()
        End If
    End Sub

    Private Sub fvencimiento_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles fvencimiento.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtunid.Focus()
        End If
    End Sub

    Private Sub txtunid_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtunid.KeyDown
        If e.KeyCode = Keys.Enter Then
            kg.Focus()
        End If
    End Sub

    Private Sub kg_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles kg.KeyDown
        If e.KeyCode = Keys.Enter Then
            loteclie.Focus()
        End If
    End Sub

    Private Sub loteclie_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles loteclie.KeyDown

        If e.KeyCode = Keys.Enter Then
            txtcodsag.Focus()
        End If
    End Sub

    Private Sub txtcodsag_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtcodsag.KeyDown
        If e.KeyCode = Keys.Enter Then
            Btn_GuardaDetalle.Focus()
        End If
    End Sub

    Private Sub txtcodcontrato_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtcodcontrato.KeyDown
        If e.KeyCode = Keys.F1 Then
            Btn_BuscaContrato_Click(sender, e)
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        fvencimiento.Value = fvencimiento.Value.AddYears(-1)
    End Sub

    Private Sub txtguia_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
        Handles txtunid.KeyPress
        SoloNumeros(sender, e)
    End Sub

    Private Sub Cmbo_Almacenamiento_KeyPress(ByVal sender As System.Object, _
                                             ByVal e As System.Windows.Forms.KeyPressEventArgs) _
                                                Handles Cmbo_Almacenamiento.KeyPress,
                                                cmbo_descarga.KeyPress,
                                                Cmbotiporece.KeyPress, CmboTuneles.KeyPress
        e.Handled = True
    End Sub

    Private Sub Txtobs_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtobs.KeyPress
        If Txtobs.Lines.Count > 3 Then
            If Asc(e.KeyChar) <> "8" Then
                e.Handled = True
            End If
        End If
    End Sub

#End Region

#Region "Cobros Automaticos"

    Private Sub CbArriendo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CbArriendo.CheckedChanged
        If CbArriendo.CheckState = CheckState.Checked Then
            TxtArriendo.Visible = True
        Else
            TxtArriendo.Visible = False
        End If
    End Sub

    Private Sub Cb_Repa_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cb_Repa.CheckedChanged
        If Cb_Repa.CheckState = CheckState.Checked Then
            TxtRepa.Visible = True
            TxtRepa.SelectAll()
        Else
            TxtRepa.Visible = False
            TxtRepa.Text = "0"
        End If
    End Sub

    Private Sub TxtRepa_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtRepa.KeyPress
        SoloNumeros(sender, e)
    End Sub

    Private Sub Cb_Postura_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cb_Postura.CheckedChanged
        If Cb_Postura.CheckState = CheckState.Checked Then
            TxtFilm.Visible = True
            TxtFilm.SelectAll()
        Else
            TxtFilm.Visible = False
            TxtFilm.Text = "0"
        End If
    End Sub

    Sub activa_desactiva(ByVal i As Integer, ByVal true_false As Boolean)
        If true_false = True Then
            DataAdicionales.Rows(i).Cells("cb").Value = True
            DataAdicionales.Rows(i).Cells("un").Value = txtsoportantes.Text
            DataAdicionales.Rows(i).Cells("ca").Value = txtcajas.Text
            DataAdicionales.Rows(i).Cells("ki").Value = txtkilos.Text
        Else
            DataAdicionales.Rows(i).Cells("cb").Value = False
            DataAdicionales.Rows(i).Cells("un").Value = "0"
            DataAdicionales.Rows(i).Cells("ca").Value = "0"
            DataAdicionales.Rows(i).Cells("ki").Value = "0"
        End If
    End Sub

    Dim b_impr As Boolean = False

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimeAdicionales.Tick

        If b_impr = False Then
            If fnc.verificaExistencia("fichrece", "frec_codi", TxtCodRece.Text) = True Then
                BtnImprimir.Enabled = True
            Else
                BtnImprimir.Enabled = False
            End If
            b_impr = True
        End If

        If TxtCodRece.Enabled = True Then
            Exit Sub
        End If

        Try
            OBSERVACION_VAS = ""
            'If Cb_tunel.Checked = True Then
            If CmboTuneles.SelectedValue = 1 Then
                activa_desactiva(1, False)
                activa_desactiva(4, False)
                activa_desactiva(0, False)
                activa_desactiva(7, False)
            ElseIf CmboTuneles.SelectedValue = 2 Then
                'tunel congelado 
                activa_desactiva(0, True)
                activa_desactiva(7, True)
                activa_desactiva(1, False)
                activa_desactiva(4, False)
            ElseIf CmboTuneles.SelectedValue = 3 Then
                'congelado en camara 
                activa_desactiva(1, True)
                activa_desactiva(7, False)
                activa_desactiva(0, False)
                activa_desactiva(4, False)
            ElseIf CmboTuneles.SelectedValue = 4 Then
                'proceso de ecualizacion
                activa_desactiva(4, True)
                activa_desactiva(7, False)
                activa_desactiva(0, False)
                activa_desactiva(1, False)
            End If

            If CbSinPostura.Checked = True Then
                activa_desactiva(7, False)
            End If
            If cmbo_descarga.SelectedValue.ToString() = "1" Then
                activa_desactiva(5, True)
            Else
                activa_desactiva(5, False)
            End If

            activa_desactiva(2, False)
            activa_desactiva(3, False)

            'arriendo pallets

            If BtnImprimir.Enabled = True Then
                'existe
                Dim sql As String = " SELECT SUM(Convert(integer,isnull(drec_arriendo,0))) AS drec_arriendo  FROM detarece WHERE frec_codi1='" + TxtCodRece.Text + "'"
                Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

                If tabla.Rows.Count > 0 Then
                    If tabla.Rows(0)(0).ToString() <> "0" Then
                        TxtArriendo.Text = tabla.Rows(0)(0).ToString()
                        CbArriendo.Checked = True
                    Else
                        TxtArriendo.Text = "0"
                        CbArriendo.Checked = False
                    End If

                Else
                    TxtArriendo.Text = "0"
                    CbArriendo.Checked = False
                End If

            Else
                'no existe tmp
                Dim sql As String = "SELECT SUM(Convert(integer,isnull(drec_arriendo,0))) AS drec_arriendo FROM TMPDETARECE WHERE frec_codi='" + TxtCodRece.Text + "'"
                Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

                If tabla.Rows.Count > 0 Then
                    If tabla.Rows(0)(0).ToString() <> "0" Then

                        'Inicio Modificación Custodia/Arriendo Pallets. HAmestica 24/10/19
                        Dim CodRece As String = TxtCodRece.Text.Trim
                        Dim RutCli As String = QuitarCaracteres(TxtClirut.Text, "-")
                        Dim CodCont As String = txtcodcontrato.Text.Trim

                        Dim sqlDetArr As String = "select TipPal=right('000'+drec_codsopo,3),Cant_Arriendo=count(frec_codi) from TMPDETARECE with(nolock) where frec_codi='" & CodRece & "' and drec_arriendo='1' group by drec_codsopo"
                        Dim dtDetArr As New DataTable

                        dtDetArr = fnc.ListarTablasSQL(sqlDetArr)

                        Dim CantArrReal As Integer = 0

                        If (dtDetArr.Rows.Count > 0) Then
                            For i = 0 To dtDetArr.Rows.Count - 1
                                Dim Saldo As Integer = 0

                                Dim TipPalFrm As String = dtDetArr.Rows(i).Item(0).ToString.Trim
                                Dim CantArrTMP As Integer = CInt(dtDetArr.Rows(i).Item(1).ToString.Trim)

                                Dim CantArr As Integer = 0

                                'Dim sqlValidCust As String = "select top 1 Saldo from Control_Pallet a with(nolock) where a.Rut_Cliente='" & RutCli & "' and a.Contrato='" & CodCont & "' and a.Tipo_Pallet='" & TipPalFrm & "' and Estado='1' order by convert(date,a.Fecha) desc,a.ID desc"
                                Dim sqlValidCust As String = "select Saldo=sum(a.Saldo) from Control_Pallet_Saldos a with(nolock) where a.Rut_Cliente='" & RutCli & "' and a.Tipo_Pallet='" & TipPalFrm & "' and a.Estado='1'"
                                Dim dtValidCust As New DataTable

                                dtValidCust = fnc.ListarTablasSQL(sqlValidCust)

                                If (dtValidCust.Rows.Count > 0) Then
                                    Saldo = CInt(dtValidCust.Rows(0).Item(0).ToString.Trim)
                                End If

                                CantArr = CantArrTMP - Saldo

                                If (CantArr < 0) Then
                                    CantArr = 0
                                End If

                                CantArrReal += CantArr
                            Next
                        End If

                        If (CantArrReal > 0) Then
                            TxtArriendo.Text = CantArrReal.ToString.Trim
                            CbArriendo.Checked = True
                        Else
                            TxtArriendo.Text = "0"
                            CbArriendo.Checked = False
                        End If
                        'Fin Modificación Custodia/Arriendo Pallets. HAmestica 24/10/19

                    Else
                        TxtArriendo.Text = "0"
                        CbArriendo.Checked = False
                    End If

                Else
                    TxtArriendo.Text = "0"
                    CbArriendo.Checked = False
                End If

            End If

            If CbArriendo.CheckState = CheckState.Checked Then
                If IsNumeric(TxtArriendo.Text) Then
                    DataAdicionales.Rows(6).Cells("cb").Value = True
                    DataAdicionales.Rows(6).Cells("un").Value = TxtArriendo.Text
                    DataAdicionales.Rows(6).Cells("ca").Value = "0"
                    DataAdicionales.Rows(6).Cells("ki").Value = "0"
                Else
                    activa_desactiva(6, False)
                End If
            Else
                activa_desactiva(6, False)
            End If

            If DataAdicionales.Rows.Count = 11 Then
                If Cb_Repa.Checked = True Then
                    If IsNumeric(TxtRepa.Text) Then
                        DataAdicionales.Rows(9).Cells("cb").Value = True
                        DataAdicionales.Rows(9).Cells("un").Value = TxtRepa.Text
                        DataAdicionales.Rows(9).Cells("ca").Value = "0"
                        DataAdicionales.Rows(9).Cells("ki").Value = "0"
                    Else
                        activa_desactiva(9, False)
                    End If
                Else
                    activa_desactiva(9, False)
                End If
            End If

            If Cb_Postura.CheckState = CheckState.Checked Then
                If IsNumeric(TxtFilm.Text) Then
                    DataAdicionales.Rows(8).Cells("cb").Value = True
                    DataAdicionales.Rows(8).Cells("un").Value = TxtFilm.Text
                    DataAdicionales.Rows(8).Cells("ca").Value = "0"
                    DataAdicionales.Rows(8).Cells("ki").Value = "0"
                Else
                    activa_desactiva(8, False)
                End If
            Else
                activa_desactiva(8, False)
            End If

            If Cb_Repa.CheckState = CheckState.Checked Then
                If IsNumeric(TxtRepa.Text) Then
                    DataAdicionales.Rows(9).Cells("cb").Value = True
                    DataAdicionales.Rows(9).Cells("un").Value = TxtRepa.Text
                    DataAdicionales.Rows(9).Cells("ca").Value = "0"
                    DataAdicionales.Rows(9).Cells("ki").Value = "0"
                Else
                    activa_desactiva(9, False)
                End If
            Else
                activa_desactiva(9, False)
            End If

            '****************************************************** HORARIO HABILITACION *****************************************
            'Dim d As Integer = Weekday(fnc.DevuelveFechaServidor())

            'If d = 1 Then
            '    'Dia Domingo
            '    '  activa_desactiva(3, True)
            '    DataAdicionales.Rows(3).Cells("cb").Value = True
            '    DataAdicionales.Rows(3).Cells("un").Value = 1
            '    DataAdicionales.Rows(3).Cells("ca").Value = "0"
            '    DataAdicionales.Rows(3).Cells("ki").Value = "0"

            '    activa_desactiva(2, False)
            'ElseIf d = 7 Then
            '    'dia Sabado 'Convert.ToDateTime(horalleg.Text) > Convert.ToDateTime(SA_HorIni.Text) AndAlso
            '    If Not (Convert.ToDateTime(horalleg.Text) < Convert.ToDateTime(Sab_HorTer.Text)) Then
            '        DataAdicionales.Rows(2).Cells("cb").Value = True
            '        DataAdicionales.Rows(2).Cells("un").Value = 1
            '        DataAdicionales.Rows(2).Cells("ca").Value = "0"
            '        DataAdicionales.Rows(2).Cells("ki").Value = "0"
            '        activa_desactiva(3, False)
            '    End If
            'Else
            '    'Dia Semana ' Convert.ToDateTime(horainic.Text) > Convert.ToDateTime(LV_horini.Text) AndAlso
            '    If Not (Convert.ToDateTime(horainic.Text) < Convert.ToDateTime(LV_ter.Text)) Then
            '        DataAdicionales.Rows(2).Cells("cb").Value = True
            '        DataAdicionales.Rows(2).Cells("un").Value = 1
            '        DataAdicionales.Rows(2).Cells("ca").Value = "0"
            '        DataAdicionales.Rows(2).Cells("ki").Value = "0"
            '        activa_desactiva(3, False)
            '    End If
            'End If

            '*********************************************************************************************************************
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region "Buscadores"

    Private Sub txtrutchofer_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtrutchofer.KeyDown
        If e.KeyCode = Keys.F1 Then
            Btn_BuscaChofer_Click(sender, e)
        ElseIf e.KeyCode = Keys.Enter Then
            Me.valorRecibido = QuitarCaracteres(Me.txtrutchofer.Text)
            If Len(valorRecibido) >= 9 Then
                Dim SqlBusca As String = "SELECT cho_nombre, cho_patente, cho_empresa  FROM Choferes WHERE " +
                    "cho_rut='" + valorRecibido + "'"

                Dim tablaBuscaChofer As DataTable = fnc.ListarTablasSQL(SqlBusca)
                If tablaBuscaChofer.Rows.Count > 0 Then
                    txtrutchofer.Text = valorRecibido
                    txtnombrechofer.Text = tablaBuscaChofer.Rows(0)(0).ToString()
                    txtpatente.Text = tablaBuscaChofer.Rows(0)(1).ToString()
                    txtempresa.Text = tablaBuscaChofer.Rows(0)(2).ToString()
                    txtrutchofer.Enabled = False
                End If
            End If
        End If
    End Sub

    Private Sub Btn_buscaProducto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_buscaProducto.Click
        Dim frm As New Lst_AyudaProductos
        frm.Condicion = "mae_clirut='" + QuitarCaracteres(TxtClirut.Text) + "' "
        frm.IsRecepcion = True
        frm.ShowDialog(Frm_Principal)

        If Frm_Principal.buscavalor <> "" Then
            Me.txtprodcod.Text = Frm_Principal.buscavalor

            Dim sqlBusca = "SELECT mae_descr, mae_diasv,IsNull(sum_dias, 0) as sum_dias FROM maeprod WHERE mae_codi='" + txtprodcod.Text + "'"

            Dim tabla As DataTable = fnc.ListarTablasSQL(sqlBusca)
            If tabla.Rows.Count > 0 Then
                txtprodnom.Text = tabla.Rows(0)(0).ToString()

                If Convert.ToInt32(tabla.Rows(0)(1).ToString()) > 0 Then
                    fvencimiento.Value = DateAdd(DateInterval.Month, Convert.ToInt32(tabla.Rows(0)(1).ToString()), felaboracion.Value)
                    DiasVenc = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    DiasVenc2 = Convert.ToInt32(tabla.Rows(0)(2).ToString())

                    fvencimiento.Value = DateAdd(DateInterval.Day, Convert.ToInt32(tabla.Rows(0)(2).ToString()), fvencimiento.Value)
                    fvencimiento.Enabled = False
                Else
                    fvencimiento.Enabled = True
                End If

            End If

        End If
        Frm_Principal.buscavalor = ""
    End Sub

    Private Sub Btn_buscasoportante_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_buscasoportante.Click
        Dim frm As New Lst_AyudaSoportantes
        frm.ShowDialog(Frm_Principal)
        txtsopcodi.Text = Frm_Principal.buscavalor
        Dim sql As String = "SELECT  tsop_descr FROM tiposopo WHERE tsop_codi='" + txtsopcodi.Text + "'"

        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)
        If tabla.Rows.Count > 0 Then
            txtsopnombre.Text = tabla.Rows(0)(0)
        End If
        Frm_Principal.buscavalor = ""
    End Sub

    Sub llenavalgui()


        Dim sqlEncabezado2 = "SELECT val_guia,uni_guia,kilos_guia FROM fichrece WHERE frec_codi='" + CerosAnteriorString(TxtCodRece.Text, 7) + "' "




        Dim tabla2 As DataTable = fnc.ListarTablasSQL(sqlEncabezado2)

        If tabla2.Rows.Count > 0 Then
            If tabla2.Rows(0)(0).ToString().Trim() = "1" Then
                chkdatosguia.Checked = True
                txtenvguia.Text = tabla2.Rows(0)(1).ToString().Trim()
                txtkilguia.Text = tabla2.Rows(0)(2).ToString().Trim()
                lblenvguia.Visible = True
                lblkilguia.Visible = True
                txtenvguia.Visible = True
                txtkilguia.Visible = True
                datosguia = "1"
            End If
        End If


    End Sub

    Sub BuscaRecepcionCompleta()
        Dim sqlEncabezado As String = ""

        If sucursalglo = "0" Then
            sqlEncabezado = "SELECT frec_rutcli, cli_nomb, frec_contcli, frec_horarec, frec_horater, frec_turnrec, frec_fecrec, " +
                "frec_guiades, frec_totsopo,  frec_totunidad, frec_totpeso, frec_temppro, frec_rutcond, cho_nombre, cho_patente, " +
                "cho_empresa, frec_observ, frec_tipdesc, frec_origen, frec_receptunel, frec_numsello, frec_tiporecepcion, " +
                "frec_tipoalmacenamiento, frec_TS, frec_TM, frec_TI , cont_descr, frec_codvig , frec_antecamara, frec_dañado, " +
                "cont_tempcon, cont_tempgra, frec_olores, frec_higiene, frec_estiba, frec_dañado, Hor_SRI, Hor_SRT, Hor_SDI, Hor_SDT, " +
                "frec_clfol, frec_contenedor , isnull(frec_horalleg ,frec_horarec) AS frec_horalleg, cont_bloqimp,frec_codienca ,frec_ntunel,frec_serv " +
                "FROM fichrece, clientes, contrato , choferes, contratosHorarios " +
                "WHERE cont_codi=frec_contcli AND cli_rut=frec_rutcli and cho_rut= frec_rutcond AND cont_codi=hor_contcod " +
                "AND frec_codi='" + CerosAnteriorString(TxtCodRece.Text, 7) + "'"
        Else

            sqlEncabezado = "SELECT frec_rutcli, cli_nomb, frec_contcli, frec_horarec, frec_horater, frec_turnrec, frec_fecrec, " +
    "frec_guiades, frec_totsopo,  frec_totunidad, frec_totpeso, frec_temppro, frec_rutcond, cho_nombre, cho_patente, " +
    "cho_empresa, frec_observ, frec_tipdesc, frec_origen, frec_receptunel, frec_numsello, frec_tiporecepcion, " +
    "frec_tipoalmacenamiento, frec_TS, frec_TM, frec_TI , cont_descr, frec_codvig , frec_antecamara, frec_dañado, " +
    "cont_tempcon, cont_tempgra, frec_olores, frec_higiene, frec_estiba, frec_dañado, Hor_SRI, Hor_SRT, Hor_SDI, Hor_SDT, " +
    "frec_clfol, frec_contenedor , isnull(frec_horalleg ,frec_horarec) AS frec_horalleg, cont_bloqimp,frec_codienca ,frec_ntunel,frec_serv " +
    "FROM fichrece, clientes, contrato , choferes, contratosHorarios " +
    "WHERE cont_codi=frec_contcli AND cli_rut=frec_rutcli and cho_rut= frec_rutcond AND cont_codi=hor_contcod " +
    "AND frec_codi='" + CerosAnteriorString(TxtCodRece.Text, 7) + "' and fichrece.cod_bod ='" + sucursalglo + "'"
        End If




        Dim tabla As DataTable = fnc.ListarTablasSQL(sqlEncabezado)

        If tabla.Rows.Count > 0 Then

            txtResponsable.Text = fnc.DevuelveUsuario(tabla.Rows(0)(44).ToString())
            TxtCodRece.Text = CerosAnteriorString(TxtCodRece.Text, 7)
            TxtClirut.Text = tabla.Rows(0)(0).ToString()
            txtclinom.Text = tabla.Rows(0)(1).ToString()
            txtcodcontrato.Text = tabla.Rows(0)(2).ToString()
            horainic.Text = tabla.Rows(0)(3).ToString
            horaterm.Text = tabla.Rows(0)(4).ToString
            ' txtturno.Text = tabla.Rows(0)(5).ToString()
            fecharece.Value = devuelve_fecha(tabla.Rows(0)(6))
            txtguia.Text = tabla.Rows(0)(7).ToString()
            txtsoportantes.Text = tabla.Rows(0)(8).ToString()
            txtcajas.Text = tabla.Rows(0)(9).ToString()
            txtkilos.Text = tabla.Rows(0)(10).ToString().Replace(",", ".")
            TxtPromTemp = tabla.Rows(0)(11).ToString()
            txtrutchofer.Text = tabla.Rows(0)(12).ToString()
            txtnombrechofer.Text = tabla.Rows(0)(13).ToString()
            txtpatente.Text = tabla.Rows(0)(14).ToString()
            txtempresa.Text = tabla.Rows(0)(15).ToString()
            Txtobs.Text = tabla.Rows(0)(16).ToString()
            cmbo_descarga.SelectedValue = Val(tabla.Rows(0)(17).ToString())
            txtorigen.Text = tabla.Rows(0)(18).ToString()
            txtorigend.Text = retorna_Origen(txtorigen.Text)
            cbonumtun.Text = tabla.Rows(0)(45).ToString()
            lbladv.Visible = False
            pbadvertencia.Visible = False
            If tabla.Rows(0)(19).ToString() <> "" Then
                CmboTuneles.SelectedValue = tabla.Rows(0)(19).ToString()
            End If

            txtsello.Text = tabla.Rows(0)(20)
            Cmbotiporece.SelectedValue = tabla.Rows(0)(21)
            If tabla.Rows(0)(22) = "CONGELADO" Then
                Cmbo_Almacenamiento.SelectedValue = 2
            ElseIf tabla.Rows(0)(22) = "REFRIGERADO" Then
                Cmbo_Almacenamiento.SelectedValue = 1
            ElseIf IsNumeric(tabla.Rows(0)(22)) Then
                Cmbo_Almacenamiento.SelectedValue = tabla.Rows(0)(22).ToString()
            End If

            'temp1.Text = tabla.Rows(0)(23).ToString.Replace(",", ".")
            'temp2.Text = tabla.Rows(0)(24).ToString.Replace(",", ".")
            'temp3.Text = tabla.Rows(0)(25).ToString().Replace(",", ".")
            txtnom_contrato.Text = tabla.Rows(0)(26).ToString()

            If tabla.Rows(0)(27).ToString() = "1" Then
                Lbl_EstadoGuia.Text = "NULA"
                Lbl_EstadoGuia.ForeColor = Color.Red
                Btn_AnulaGuia.Enabled = False
            Else
                Lbl_EstadoGuia.Text = "ACTIVA"
                Lbl_EstadoGuia.ForeColor = Color.Blue
                Btn_AnulaGuia.Enabled = True
            End If

            If IsNumeric(tabla.Rows(0)(28).ToString()) Then
                cmbAnden.SelectedValue = Convert.ToInt16(tabla.Rows(0)(28).ToString())
            End If

            cbdañado.CheckState = tabla.Rows(0)(29).ToString()
            TxtTemp.Text = tabla.Rows(0)(30).ToString()
            'TxtHorini.Text = tabla.Rows(0)(31).ToString()
            'TxtHorTer.Text = tabla.Rows(0)(32).ToString()
            TxtTempGracia.Text = tabla.Rows(0)(31).ToString()

            'frec_olores, frec_higiene, frec_estiba, frec_dañado

            Cb_OloresExtraños.Checked = tabla.Rows(0)(32).ToString()

            If tabla.Rows(0)(33).ToString() = 1 Then
                Rb_higieneB.Checked = True
            Else
                Rb_higieneM.Checked = True
            End If

            If tabla.Rows(0)(34).ToString() = 1 Then
                Rb_EstibaB.Checked = True
            Else
                Rb_EstibaM.Checked = True
            End If

            cbdañado.Checked = tabla.Rows(0)(35).ToString()
            LV_horini.Text = tabla.Rows(0)(36).ToString()
            LV_ter.Text = tabla.Rows(0)(37).ToString()
            SA_HorIni.Text = tabla.Rows(0)(38).ToString()
            Sab_HorTer.Text = tabla.Rows(0)(39).ToString()
            TxtFolioPorteria.Text = tabla.Rows(0)(40).ToString()
            TxtContenedor.Text = tabla.Rows(0)(41).ToString()
            horalleg.Text = tabla.Rows(0)(42).ToString()

            If tabla.Rows(0)(43).ToString() = "1" Then
                Cmbotiporece.Enabled = False
            End If

            Dim servicio As String = tabla.Rows(0)(46).ToString()

            If servicio = "" Then
                produa.SelectedIndex = 0
            Else
                produa.Text = servicio
            End If

            TxtCodRece.Enabled = False
            BuscaDetalleRecepcionCompleta()
            If modificacion = False Then
                Panel5.Enabled = False
            Else
                LimpiarCajas(Panel5)
            End If

            btn_guardar.Enabled = False

            btn_BuscaCliente.Enabled = False
            Btn_BuscaContrato.Enabled = False
            TxtClirut.Enabled = False
            txtcodcontrato.Enabled = False
            Btn_BuscaChofer.Enabled = False
            txtrutchofer.Enabled = False
            BtnImprimir.Enabled = True
            'Tab_Detalle.TabPages(2)
            'busca cobros automaticos



            '''''''IHC'''''''
            Dim sqlTermo As String = "SELECT Cl_Ting FROM zchecklist WHERE cl_fol = '" + TxtFolioPorteria.Text.ToString() + "'"

            Dim tablaTermo As DataTable = fnc.ListarTablasSQL(sqlTermo)

            If tablaTermo.Rows.Count > 0 Then
                txtTempTermo.Text = tablaTermo.Rows(0)(0).ToString()
            Else
                txtTempTermo.Text = ""
            End If
            '''''''IHC'''''''

            LLENA_GRILLA_AUTOMATICOS()
            llenavalgui()
        Else
            MsgBox("Error al rescatar la recepción", MsgBoxStyle.Critical, "Aviso")
        End If
    End Sub

    Sub BuscaDetalleRecepcionCompleta()

        Dim sql As String = "SELECT drec_codi AS pallet, drec_codpro, mae_descr , drec_codsopo, tsop_descr, drec_unidades, " +
            "drec_peso, CONVERT(datetime,drec_fecprod,111) AS drec_fecprod, REPLACE(FechaVencimiento,'/','-') AS FechaVencimiento, LoteCliente,  drec_codsag, drec_sopocli, drec_temp, isnull(drec_arriendo,0) as drec_arriendo,estpallet " +
            "FROM DetaRece, maeprod, tiposopo  WHERE mae_codi=drec_codpro AND drec_codsopo=convert(int,tsop_codi) " +
            "AND frec_codi1 ='" + CerosAnteriorString(TxtCodRece.Text, 7) + "' ORDER BY drec_codi ASC"

        DetaRece.DataSource = fnc.ListarTablasSQL(sql)

    End Sub

#End Region

#Region " BOTONES CRUTE, INGRESO DE TEMPORALES"

    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        ' Dim f As 
        Frm_ListadoRecepcion.ShowDialog(Frm_Principal)
        modificacion = False
        If Frm_Principal.buscavalor.ToString() <> "" Then
            TxtCodRece.Text = Frm_Principal.buscavalor.ToString()
            TxtCodRece.Enabled = False
            BuscaRecepcionCompleta()
            Tab_Detalle.Enabled = True
            Frm_Principal.buscavalor = ""
        End If

    End Sub

    Private Sub BtnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImprimir.Click



        'If File.Exists("C:\Imagenlogo.jpg") Then
        'Else
        '    pblogo.Image.Save("C:\Imagenlogo.jpg", Drawing.Imaging.ImageFormat.Jpeg)
        'End If
        'If File.Exists("C:\Windows\Imagenlogo.jpg") Then
        'Else
        '    Dim imagen As New Bitmap(New Bitmap("C:\Imagenlogo.jpg"), 295, 76)
        '    imagen.Save("C:\Windows\Imagenlogo.jpg", System.Drawing.Imaging.ImageFormat.Jpeg)
        'End If

        Dim ac As Byte()
        If TxtCodRece.Text = "" Then
            MsgBox("Debe guardar el formulario antes de imprimirlo", MsgBoxStyle.Critical, "Aviso")
        Else
            documentoimp = DateTime.Now.ToString("MM-dd-yy") + "Documento" + TxtCodRece.Text
            Dim frm As Frm_MuestraReporte = New Frm_MuestraReporte
            frm.Text = "Asistente de informes - Guia Recepcion"

            Dim report As New Rpt_GuiaRecepcion

            'Dim PictureBox1 As New PictureBox
            'Dim PictureBox2 As New PictureBox
            'Dim PictureBox3 As New PictureBox


            Dim PictureBoximg As New PictureBox

            Dim SqlImagen2 As String = "SELECT  Convert(varchar(max),Convert(Varbinary(MAX),foto2))  from etiimg "


            Dim tablaimagen2 As DataTable = fnc.ListarTablasSQL(SqlImagen2)

            If tablaimagen2.Rows.Count > 0 Then

                'Imagen1

                PictureBoximg.Image = Base64ToImage(tablaimagen2.Rows(0)(0).ToString())
            End If
            Dim SqlImagen As String = "SELECT  Convert(varchar(max),Convert(Varbinary(MAX),cl_imgtem)) , " +
                                              "Convert(varchar(max),Convert(Varbinary(MAX), cl_imgsel)) , " +
                                              "Convert(varchar(max),Convert(Varbinary(MAX),cl_imgpat)), id_pallets FROM chk_imagesopo WHERE LEFT(id_pallets,7)='" + TxtCodRece.Text + "'"
            'Dim SqlImagen As String = "SELECT  Convert(varchar(max),Convert(Varbinary(MAX),cl_imgtem)) , Convert(varchar(max),Convert(Varbinary(MAX),cl_imgsel)) ,  Convert(varchar(max),Convert(Varbinary(MAX),cl_imgpat)) FROM chk_images WHERE id_chk='2350'"

            Dim tablaimagen As DataTable = fnc.ListarTablasSQL(SqlImagen)

            Dim Ds As New Ds_ImagenesRece

            If tablaimagen.Rows.Count > 0 Then
                For i As Integer = 0 To tablaimagen.Rows.Count - 1

                    Dim a As Byte() = ImageToByte(Base64ToImage(tablaimagen.Rows(i)(0).ToString()))
                    Dim b As Byte() = ImageToByte(Base64ToImage(tablaimagen.Rows(i)(1).ToString()))
                    Dim c As Byte() = ImageToByte(Base64ToImage(tablaimagen.Rows(i)(2).ToString()))

                    Ds.Img.AddImgRow(a, b, c, tablaimagen.Rows(i)(3).ToString())
                Next
                'report.SetDatabaseLogon(Usuario_ODBC, Pass_ODBC)
            End If

            'Dim RutaImagen As String
            'RutaImagen = "C:\Windows\Imagenlogo.jpg"
            '' Ds2.imagen.AddimagenRow(ImageToByte(pblogo.Image))

            '' report.Subreports(0).SetDataSource(Ds2)

            'report.SetParameterValue("RutaImagen", RutaImagen.ToString)


            ' report.Subreports(0).SetDataSource(Ds2)
            report.SetDatabaseLogon(Usuario_ODBC, Pass_ODBC)
            report.SetParameterValue("codigo", TxtCodRece.Text)
            frm.Contenedor.ReportSource = report
            frm.ShowDialog()
        End If
    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        If validacion() = 0 Then
            If fnc.verificaExistencia("fichrece", "frec_codi", TxtCodRece.Text) = False Then

                '********************** VALIDADOR DE TEMPERATURAS *************************
                Dim sql2 As String = "SELECT * from conf_temp "

                Dim tabla2 As DataTable = fnc.ListarTablasSQL(sql2)
                If tabla2.Rows.Count > 0 Then
                    camttemp = tabla2.Rows(0)(0).ToString()
                End If

                Dim Gracia As Integer = Val(TxtTemp.Text) + Val(TxtTempGracia.Text)
                Dim sqltemp As String = "SELECT frec_codi+drec_codi AS sopo, isnull(drec_temp,'0.00') FROM TMPDETARECE WHERE frec_codi='" + TxtCodRece.Text + "' " +
                    "AND drec_temp>'" + Gracia.ToString() + "' AND drec_temp<>0 ORDER BY drec_codi "

                Dim tabla As DataTable = fnc.ListarTablasSQL(sqltemp)

                If tabla.Rows.Count > 0 Then
                    If Val(txtsoportantes.Text) > Val(TxtNpallets) Then
                        mensaje = mensaje + "- Debe Ingresar todas las temperaturas de los soportantes"
                    End If
                ElseIf Val(TxtNpallets) < camttemp Then
                    If Val(txtsoportantes.Text) > Val(TxtNpallets) AndAlso Val(txtsoportantes.Text) >= camttemp Then   'TxtNpallets hace referencia a los pallets con temperatura.-
                        mensaje = mensaje + "-Debe Ingresar MINIMO " + camttemp + " temperaturas"
                    ElseIf Val(txtsoportantes.Text) <> Val(TxtNpallets) Then
                        mensaje = mensaje + "-Debe Ingresar MINIMO " + txtsoportantes.Text + " temperaturas"
                    End If
                End If

                If mensaje.Length > 0 Then
                    MsgBox(mensaje, MsgBoxStyle.Critical, "Aviso")
                    Exit Sub
                End If
                '**************************************************************************
                '********************** VALIDADOR DE FOTOGRAFIAS* *************************
                Dim sqlFoto As String = "SELECT rimg_imagen,rimg_num,rimg_rececodi FROM receimagen WHERE rimg_rececodi = '" + TxtCodRece.Text + "'"

                Dim tablaFoto As DataTable = fnc.ListarTablasSQL(sqlFoto)

                If tablaFoto.Rows.Count = 0 Then
                    mensaje = mensaje + "- Debe Ingresar MINIMO una Fotografía"
                End If

                If mensaje.Length > 0 Then
                    MsgBox(mensaje, MsgBoxStyle.Critical, "Aviso")
                    Exit Sub
                End If
                '**************************************************************************

                Dim F_VALIDA As New Frm_VerificaServiciosrece
                Dim dt_as As DataTable = New DataTable

                dt_as.Columns.Add("de")
                dt_as.Columns.Add("un")
                dt_as.Columns.Add("ca")
                dt_as.Columns.Add("ki")

                For i As Integer = 0 To DataAdicionales.RowCount - 1
                    If DataAdicionales.Rows(i).Cells("cb").Value = True Then
                        dt_as.Rows.Add(DataAdicionales.Rows(i).Cells("de").Value, _
                                       DataAdicionales.Rows(i).Cells("un").Value, _
                                       DataAdicionales.Rows(i).Cells("ca").Value, _
                                       DataAdicionales.Rows(i).Cells("ki").Value.replace(",", "."))
                    End If
                Next

                F_VALIDA.DataAdicionales.DataSource = dt_as
                F_VALIDA.ShowDialog(Frm_Principal)

                If Frm_Principal.buscavalor = "NO" Or Frm_Principal.buscavalor = "" Then
                    Exit Sub
                End If


                If DetaRece.Rows.Count = 0 Then
                    MsgBox("Debe ingresar un detalle de recepcion", MsgBoxStyle.Critical, "Aviso")
                    Tab_Detalle.SelectedIndex = 1
                    Exit Sub
                End If

                'Guarda Encabezado
                TimeAdicionales.Stop()

                horaterm.Text = DevuelveHora()

                Dim turno As String = ""
                If Convert.ToDateTime("08:00:00") > DevuelveHora() AndAlso DevuelveHora() <= Convert.ToDateTime("19:59:59") Then
                    turno = "1"
                Else
                    turno = "2"
                End If

                'ACTUALIZA CHECKLIST
                If IsNumeric(TxtFolioPorteria.Text) Then
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

                    If (camionCargaDescarga) Then
                        Dim sqlCarDes As String = "SP_Camiones_Carga_Descarga_Grabar '0','" & TxtFolioPorteria.Text.Trim & "','1','0','" & Frm_Principal.InfoUsuario.Text.Trim & "'"
                        fnc.MovimientoSQL(sqlCarDes)
                    Else
                        Dim sqlActualizaChecklist = "UPDATE zchecklist SET Cl_RutCli='" + TxtClirut.Text + "',Cl_Estfrigo='1' " +
                                                "WHERE cl_fol='" + TxtFolioPorteria.Text + "'"
                        fnc.MovimientoSQL(sqlActualizaChecklist)
                    End If
                    'Fin actualización Cierre camiones carga y descarga. 07-06-19
                End If

                Dim SERV As String = ""
                If produa.Text = "SELECCIONAR" Then

                    SERV = ""
                Else

                    SERV = produa.Text
                End If

                Dim sqlGuarda As String = "INSERT INTO fichrece(frec_codi, frec_rutcli, frec_contcli, frec_horalleg, frec_horarec, frec_horater, frec_turnrec, frec_fecrec, frec_guiades, frec_totsopo, " +
                                    "frec_totunidad, frec_totpeso, frec_temppro, frec_rutcond, frec_observ, frec_tipdesc, frec_codienca, frec_origen, frec_codvig, frec_receptunel, " +
                                    "frec_numsello, frec_tiporecepcion, frec_tipoalmacenamiento, frec_olores, frec_higiene, frec_estiba, frec_dañado, frec_antecamara, frec_clfol, frec_contenedor,frec_ntunel,cod_bod,val_guia,uni_guia,kilos_guia,frec_tippro,frec_serv )VALUES" +
                                    "('" + TxtCodRece.Text + "','" + QuitarCaracteres(TxtClirut.Text, "-") + "','" + txtcodcontrato.Text + "','" + horalleg.Text + "','" + horainic.Text + "'," +
                                    "'" + horaterm.Text + "','" + turno + "','" + devuelve_fecha(fecharece.Value) + "','" + txtguia.Text + "'," +
                                    "'" + txtsoportantes.Text + "','" + txtcajas.Text + "','" + txtkilos.Text.Replace(",", ".") + "','" + TxtPromTemp.Replace(",", ".") + "'," +
                                    "'" + QuitarCaracteres(txtrutchofer.Text, "-") + "','" + Txtobs.Text + "','" + cmbo_descarga.SelectedValue.ToString() + "','" + Frm_Principal.InfoUsuario.Text + "'," +
                                    "'" + txtorigen.Text + "','0','" + CmboTuneles.SelectedValue.ToString() + "'," +
                                    "'" + txtsello.Text + "','" + Cmbotiporece.SelectedValue.ToString() + "','" + Cmbo_Almacenamiento.Text.ToString() + "','" + EstadoCheckBox(Cb_OloresExtraños.CheckState) + "'," +
                                    "'" + (Convert.ToInt16(Rb_higieneB.Checked)).ToString() + "','" + (Convert.ToInt16(Rb_EstibaB.Checked)).ToString() + "','" + EstadoCheckBox(cbdañado.CheckState).ToString() + "', " +
                                    "'" + cmbAnden.SelectedValue.ToString() + "','" + TxtFolioPorteria.Text + "','" + TxtContenedor.Text + "','" + cbonumtun.Text + "','" + sucursalglo + "','" + datosguia.Trim() + "','" + txtenvguia.Text.Trim() + "','" + txtkilguia.Text.Trim() + "','" + cboProductotip.Text.Trim() + "','" + SERV + "')"


                If fnc.MovimientoSQL(sqlGuarda) > 0 Then
                    MsgBox("Guia ingresada correctamente", MsgBoxStyle.Information, "Aviso")

                    Dim cantidadDetalle As Integer = 0

                    'Guarda Detalle
                    For i As Integer = 0 To DetaRece.Rows.Count - 1
                        Dim estado_traqueo As String = "0"
                        Dim sqls As String = DetaRece.Rows(i).Cells(16).Value.ToString()
                        CargaGrillaDetalle()
                        Dim tabla_traqueo As DataTable = fnc.ListarTablasSQL("SELECT isnull(drec_codcaja,0) FROM TMPDETARECE WHERE frec_codi+drec_codi='" + DetaRece.Rows(i).Cells(2).Value.ToString() + "'")

                        If tabla_traqueo.Rows.Count > 0 Then
                            estado_traqueo = tabla_traqueo.Rows(0)(0).ToString()
                        End If

                        'Inicio Modificación Custodia/Arriendo Pallets. HAmestica 24/10/19
                        Dim EsArriendo As Integer = 0

                        If (DetaRece.Rows(i).Cells(15).Value.ToString.Trim = "1") Then
                            Dim NumPal As String = DetaRece.Rows(i).Cells(2).Value.ToString.Trim
                            Dim RutCli As String = QuitarCaracteres(TxtClirut.Text, "-")
                            Dim CodCont As String = txtcodcontrato.Text.Trim
                            Dim TipPal As String = "000" & DetaRece.Rows(i).Cells(5).Value.ToString.Trim
                            Dim TipPalFrm As String = TipPal.Substring(TipPal.Length - 3, 3)
                            Dim DocAsoc As String = TxtCodRece.Text.Trim
                            Dim CantEnt As Integer = 0
                            Dim CantSal As Integer = 1
                            Dim Obs As String = "Recepcion " & DocAsoc & ", Pallet " & NumPal & "."
                            Dim Est As String = "1"
                            Dim CodUsu As String = Frm_Principal.InfoUsuario.Text.Trim

                            'Dim sqlValidCust As String = "select top 1 Saldo from Control_Pallet a with(nolock) where a.Rut_Cliente='" & RutCli & "' and a.Contrato='" & CodCont & "' and a.Tipo_Pallet='" & TipPalFrm & "' and a.Estado='1' and convert(date,a.Fecha)<='" & fecharece.Value.ToString("yyyyMMdd") & "' order by convert(date,a.Fecha) desc,a.ID desc"
                            Dim sqlValidCust As String = "select a.Saldo,a.Contrato from Control_Pallet_Saldos a with(nolock) where a.Rut_Cliente='" & RutCli & "' and a.Tipo_Pallet='" & TipPalFrm & "' and a.Estado='1'"
                            Dim dtValidCust As New DataTable

                            dtValidCust = fnc.ListarTablasSQL(sqlValidCust)

                            Dim ContratoPallet As String = ""

                            If (dtValidCust.Rows.Count > 0) Then
                                Dim SinSaldo As Boolean = False

                                For j = 0 To dtValidCust.Rows.Count - 1
                                    Dim Saldo As Integer = CInt(dtValidCust.Rows(j).Item(0).ToString.Trim)
                                    ContratoPallet = dtValidCust.Rows(j).Item(1).ToString.Trim

                                    If (Saldo > 0) Then
                                        SinSaldo = False
                                        Exit For
                                    Else
                                        SinSaldo = True
                                    End If
                                Next

                                If (SinSaldo) Then
                                    EsArriendo = 1
                                End If
                            Else
                                EsArriendo = 1
                            End If

                            If (EsArriendo = 0) Then
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
                                Dim sqlValidVentDir As String = "select Estado from Control_Pallet_Cliente_Venta_Directa with(nolock) where Rut_Cliente='" & RutCli & "'"
                                Dim dtValidVentDir As New DataTable

                                dtValidVentDir = fnc.ListarTablasSQL(sqlValidVentDir)

                                Dim EsVenDir As String = "0"

                                If (dtValidVentDir.Rows.Count > 0) Then
                                    Dim RespDt As String = dtValidVentDir.Rows(0).Item(0).ToString.Trim

                                    If (RespDt <> "-1") Then
                                        EsVenDir = RespDt
                                    End If
                                End If

                                If (EsVenDir = "1") Then
                                    Dim sqlVent As String = "SP_Control_Pallet_Venta_Grabar '','" & NumPal & "','R','" & DocAsoc & "','Venta Directa','','" & CodUsu & "'"
                                    Dim dtVent As New DataTable

                                    dtVent = fnc.ListarTablasSQL(sqlVent)
                                Else
                                    Dim sqlMovArr As String = "SP_Control_Pallet_Arriendo_Grabar '','" & NumPal & "','" & Now.ToString("yyyyMMdd") & "','','','" & CodUsu & "'"
                                    Dim dtMovArr As New DataTable

                                    dtMovArr = fnc.ListarTablasSQL(sqlMovArr)

                                    If (dtMovArr.Rows.Count > 0) Then
                                        Dim RespMovArr As String = dtMovArr.Rows(0).Item(0).ToString.Trim

                                        If (RespMovArr = "-1") Then
                                            MsgBox("Ocurrio un error al registrar movimiento de arriendo de pallet.", MsgBoxStyle.Critical, "Error")
                                        End If
                                    Else
                                        MsgBox("Ocurrio un error al registrar movimiento de arriendo de pallet.", MsgBoxStyle.Critical, "Error")
                                    End If
                                End If
                            End If

                            Dim sqlValidCambPall As String = "select CantCamb=count(ID) from Control_Pallet_TMP_Recepcion_Dañado with(nolock) where Codigo_Soportante='" & NumPal & "' and Estado='A'"
                            Dim dtValidCambPall As New DataTable

                            dtValidCambPall = fnc.ListarTablasSQL(sqlValidCambPall)

                            Dim EsCamb As Integer = 0

                            If (dtValidCambPall.Rows.Count > 0) Then
                                EsCamb = CInt(dtValidCambPall.Rows(0).Item(0).ToString.Trim)
                            End If

                            If (EsCamb > 0) Then
                                Dim sqlCambPall As String = "SP_Control_Pallet_Grabar '','" & RutCli & "','" & CodCont & "','" & Now.ToString("yyyyMMdd").Trim & "','" & TipPalFrm & "','" & DocAsoc & "','1','0','" & Obs & " Cambio Pallet Dañado.','2','" & CodUsu & "'"
                                Dim dtCambPall As New DataTable

                                dtCambPall = fnc.ListarTablasSQL(sqlCambPall)
                            End If
                        End If
                        'Fin Modificación Custodia/Arriendo Pallets. HAmestica 24/10/19

                        Dim sqlGuardaDetalle As String = "INSERT INTO detarece(drec_codi, drec_codcaja, drec_codpro, drec_codsopo, drec_sopocli, drec_unidades, drec_peso, " +
                            "drec_fecrec, drec_rutcli, drec_contcli, drec_fecprod, drec_camara, drec_banda, drec_colum, drec_piso, drec_nivel, drec_codvig, " +
                            "drec_codsag, fechaVencimiento, LoteCliente, drec_receptunel, drec_codper, drec_hora, drec_etiqueta, frec_codi1, drec_pallet, drec_almacen, drec_temp, drec_arriendo,Estpallet,cod_bod) " +
                            "VALUES('" + DetaRece.Rows(i).Cells(2).Value.ToString() + "','" + estado_traqueo + "','" + DetaRece.Rows(i).Cells(3).Value.ToString() + "', " +
                            "'" + DetaRece.Rows(i).Cells(5).Value.ToString() + "','" + DetaRece.Rows(i).Cells(13).Value.ToString() + "', " +
                            "'" + DetaRece.Rows(i).Cells(7).Value.ToString() + "','" + DetaRece.Rows(i).Cells(8).Value.ToString().Replace(",", ".") + "'," +
                            "'" + devuelve_fecha(fecharece.Value) + "','" + QuitarCaracteres(TxtClirut.Text, "-") + "','" + txtcodcontrato.Text + "', " +
                            "'" + devuelve_fecha(DetaRece.Rows(i).Cells(9).Value.ToString()) + "','" + cmbAnden.SelectedValue.ToString() + "','00','00','00','0','0','" + DetaRece.Rows(i).Cells(12).Value.ToString() + "'," +
                            "'" + devuelve_fecha_Formato2(DetaRece.Rows(i).Cells(10).Value.ToString()) + "','" + DetaRece.Rows(i).Cells(11).Value.ToString().Trim + "','" + CmboTuneles.SelectedValue.ToString() + "', " +
                            "'" + Frm_Principal.InfoUsuario.Text + "','" + horainic.Text + "'," +
                            "'" + DigitoVerificadorEAN128UCC("1780000000" + CerosAnteriorString(DetaRece.Rows(i).Cells(2).Value.ToString(), 7)) + "'," +
                            "'" + TxtCodRece.Text + "','1','2','" + DetaRece.Rows(i).Cells(14).Value.ToString().Replace(",", ".") + "','" + EsArriendo.ToString.Trim + "','" + DetaRece.Rows(i).Cells(16).Value.ToString() + "','" + sucursalglo + "') "

                        If fnc.MovimientoSQL(sqlGuardaDetalle) > 0 Then
                            cantidadDetalle += 1
                        End If

                        'Guarda Movpallet
                        Dim SqlMovpallet As String = "INSERT INTO movpallet(mov_folio, mov_codper, mov_ca, mov_ba, mov_co, mov_pi, mov_ni, mov_fecha, mov_tipo, mov_hora, mov_doc, mov_saldo,  mov_anden, mov_TS)" +
                                                     "VALUES('" + DetaRece.Rows(i).Cells(2).Value.ToString() + "','" + Frm_Principal.InfoUsuario.Text + "','" + cmbAnden.SelectedValue.ToString() + "'," +
                                                     "'00','00','00','0','" + devuelve_fecha(fecharece.Value) + "','EN','" + DevuelveHora() + "','" + TxtCodRece.Text + "','" + DetaRece.Rows(i).Cells(7).Value.ToString() + "'," +
                                                     "'" + cmbAnden.SelectedValue.ToString() + "','" + DetaRece.Rows(i).Cells(14).Value.ToString().Replace(",", ".") + "')"

                        fnc.MovimientoSQL(SqlMovpallet)

                        ' Guarda Rackdeta

                        'BLOQUEA IMPORTACION
                        Dim ESTADO As String = "0"

                        Dim sql As String = "SELECT cont_bloqimp FROM contrato WHERE cont_codi='" + txtcodcontrato.Text + "'"
                        Dim tablaEstado As DataTable = fnc.ListarTablasSQL(sql)

                        If tablaEstado.Rows.Count > 0 Then

                            If tablaEstado.Rows(0)(0).ToString() = "1" Then

                                ' verifico si debo ingresar el etiquetado bloqueado
                                If QuitarCaracteres(txtrutchofer.Text) = "222222222" Then

                                    Dim tabla_contenedor As DataTable = fnc.ListarTablasSQL("SELECT frec_codi, frec_contenedor FROM Proc_Importaciones INNER JOIN fichrece ON frec_codi=pimp_codrece " +
                                                                                            "WHERE LTRIM(frec_contenedor) LIKE '%" + DetaRece.Rows(i).Cells(11).Value.ToString().Trim + "%'")

                                    If tabla_contenedor.Rows.Count > 0 Then
                                        ESTADO = "0"
                                    Else
                                        ESTADO = "5"
                                    End If
                                Else
                                    ESTADO = "5"
                                End If

                            End If

                        End If

                        If Cmbotiporece.Text.Trim = "A PROCESO" Then
                            ESTADO = "5"
                        End If

                        Dim esttunel As String = "0"

                        If CmboTuneles.Text = "A TUNEL" Then
                            esttunel = "1"

                        End If
                        Dim SQL_RACKDETA As String = " INSERT INTO rackdeta (racd_codi, racd_ca, racd_ba, racd_co, racd_pi, racd_ni, racd_codpro, racd_unidades, racd_peso, racd_fecpro, " +
                            "fechavencimiento, lotecliente, racd_pedido, racd_estadopallet, racd_solicitado, racd_correo, racd_picking, racd_estado , cod_bod ,est_tunel)" +
                            "VALUES('" + DetaRece.Rows(i).Cells(2).Value.ToString() + "','" + cmbAnden.SelectedValue.ToString() + "','00','00','00','0','" + DetaRece.Rows(i).Cells(3).Value.ToString() + "'," +
                            "'" + DetaRece.Rows(i).Cells(7).Value.ToString() + "','" + DetaRece.Rows(i).Cells(8).Value.ToString().Replace(",", ".") + "','" + devuelve_fecha(DetaRece.Rows(i).Cells(10).Value.ToString()) + "'," +
                            "'" + devuelve_fecha_Formato2(DetaRece.Rows(i).Cells(10).Value.ToString()) + "','" + DetaRece.Rows(i).Cells(11).Value.ToString().Trim + "','0','0','0','0','0','" + ESTADO.ToString() + "','" + sucursalglo + "','" + esttunel + "')"

                        fnc.MovimientoSQL(SQL_RACKDETA)

                    Next

                    guardaVasAutomatico()

                    If cantidadDetalle = DetaRece.Rows.Count Then
                        Dim SqlEliminaTMPDETA As String = "DELETE FROM TmpDetaRece WHERE frec_codi='" + TxtCodRece.Text + "'"
                        fnc.MovimientoSQL(SqlEliminaTMPDETA)

                        Dim sql As String = "DELETE FROM TmpFichrece WHERE frec_codi='" + TxtCodRece.Text + "'"
                        fnc.MovimientoSQL(sql)

                        Dim imagenes As String = "INSERT into chk_imagesopo (id_pallets, cl_imgtem, cl_imgsel, cl_imgpat, cl_fecha) " +
                                                 "SELECT id_pallets, cl_imgtem, cl_imgsel, cl_imgpat, cl_fecha FROM chk_imagestmp WHERE LEFT(id_pallets,7)='" + TxtCodRece.Text + "'"
                        fnc.MovimientoSQL(imagenes)
                    End If

                Else
                    MsgBox("Ocurrio un error al ingresar la recepcion", MsgBoxStyle.Critical, "Aviso")
                End If
                BuscaRecepcionCompleta()
            Else
                ' -------------------------------------------------------------------------- MODIFICA RECEPCION -------------------------------------------------------------------------
                Dim modificar As String = "0"
                If MsgBox("¿Enviar guia modificada al cliente?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbYes Then
                    modificar = "1"
                Else
                    modificar = "0"
                End If


                For i As Integer = 0 To DetaRece.RowCount - 1
                    Dim codpro As String = DetaRece.Rows(i).Cells("Cod_Producto").Value





                    Dim tabla As DataTable = fnc.ListarTablasSQL("SELECT mae_codi FROM maeprod WHERE mae_clirut='" + TxtClirut.Text + "' and mae_codi ='" + codpro + "'")
                    If tabla.Rows.Count > 0 Then




                    Else

                        MsgBox("Existen Soportantes donde el producto no pertenece a el cliente", MsgBoxStyle.Critical, "Aviso")
                        Exit Sub

                    End If
                Next


                Dim ServActualizado = produa.Text.Trim
                If (ServActualizado = "SELECCIONAR") Then
                    ServActualizado = ""
                End If

                'Guardar log con detalle de actualizacion de recepción

                'Dim sqlLogDetFichrece = "insert into LOG_FICHRECE_DETALLE select  GETDATE(),'" & Frm_Principal.InfoUsuario.Text & "',* from fichrece where frec_codi='" + TxtCodRece.Text + "'"
                'fnc.MovimientoSQL(sqlLogDetFichrece)

                Dim SQL_ModificaRecepcion = "UPDATE fichrece SET frec_rutcli='" + QuitarCaracteres(TxtClirut.Text, "-") + "', frec_contcli='" + txtcodcontrato.Text + "', " +
                    "frec_fecrec='" + devuelve_fecha(fecharece.Value) + "', frec_guiades='" + txtguia.Text + "', frec_totsopo='" + txtsoportantes.Text + "', " +
                    "frec_totunidad='" + txtcajas.Text + "', frec_totpeso='" + txtkilos.Text.Replace(",", ".") + "', frec_temppro='" + TxtPromTemp.Replace(",", ".") + "', " +
                    "frec_rutcond='" + QuitarCaracteres(txtrutchofer.Text, "-") + "', frec_observ='" + Txtobs.Text + "', frec_tipdesc='" + cmbo_descarga.SelectedValue.ToString() + "', " +
                    "frec_origen='" + txtorigen.Text + "', frec_receptunel='" + CmboTuneles.SelectedValue.ToString() + "', " +
                    "frec_numsello='" + txtsello.Text + "', frec_tiporecepcion='" + Cmbotiporece.SelectedValue.ToString() + "', frec_tipoalmacenamiento='" + Cmbo_Almacenamiento.Text.ToString() + "', " +
                    "frec_olores='" + EstadoCheckBox(Cb_OloresExtraños.CheckState) + "', frec_higiene='" + (Convert.ToInt16(Rb_higieneB.Checked)).ToString() + "', frec_estiba='" + (Convert.ToInt16(Rb_EstibaB.Checked)).ToString() + "', " +
                    "frec_dañado='" + EstadoCheckBox(cbdañado.CheckState) + "', frec_antecamara='" + cmbAnden.SelectedValue.ToString() + "', frec_contenedor='" + TxtContenedor.Text + "',frec_ntunel='" + cbonumtun.Text + "',frec_enviada='0',frec_modificado='" + modificar + "',frec_tippro='" + cboProductotip.Text.Trim() + "',val_guia='" + datosguia.Trim() + "',uni_guia='" + txtenvguia.Text.Trim() + "',kilos_guia='" + txtkilguia.Text + "',frec_serv='" & ServActualizado & "' WHERE frec_codi='" + TxtCodRece.Text + "'"
                lbladv.Visible = False
                pbadvertencia.Visible = False
                'BLOQUEA IMPORTACION

                Dim ESTADO As String = "0"

                Dim sqlbloq As String = "SELECT cont_bloqimp FROM contrato WHERE cont_codi='" + txtcodcontrato.Text + "'"
                Dim tablaEstado As DataTable = fnc.ListarTablasSQL(sqlbloq)

                If tablaEstado.Rows.Count > 0 Then
                    If tablaEstado.Rows(0)(0).ToString() = "1" Then

                        Dim SQL_BLOQ = "SELECT * FROM Proc_Importaciones WHERE pimp_codrece='" + TxtCodRece.Text + "' "
                        Dim tablabloq As DataTable = fnc.ListarTablasSQL(SQL_BLOQ)

                        If tablabloq.Rows.Count > 0 Then
                            ESTADO = "0"
                        Else
                            ESTADO = "5"
                        End If

                        'Dim SQL_IMPORTACION = "UPDATE RACKDETA SET racd_estado='" + ESTADO + "',est_tunel='" & esttunel & "'  where racd_codi like '" + TxtCodRece.Text + "__%' "
                        Dim SQL_IMPORTACION = "UPDATE RACKDETA SET racd_estado='" + ESTADO + "'  where racd_codi like '" + TxtCodRece.Text + "__%' "
                        fnc.MovimientoSQL(SQL_IMPORTACION)

                        'Else
                        '    ESTADO = "0"
                        '    Dim SQL_IMPORTACION = "UPDATE RACKDETA SET est_tunel='" & esttunel & "'  where racd_codi like '" + TxtCodRece.Text + "__%' "
                        '    fnc.MovimientoSQL(SQL_IMPORTACION)
                    End If
                Else
                    ESTADO = "0"
                End If

                Dim sqlEstTun As String = ""
                If CmboTuneles.Text <> "A TUNEL" Then
                    sqlEstTun = "update rackdeta set est_tunel='0' where racd_codi like '" & TxtCodRece.Text.Trim & "%'"
                    fnc.MovimientoSQL(sqlEstTun)
                Else
                    sqlEstTun = "update rackdeta set est_tunel='1' where racd_codi like '" & TxtCodRece.Text.Trim & "%'"
                    fnc.MovimientoSQL(sqlEstTun)
                End If


                Dim sql As String = "UPDATE detarece SET drec_fecrec='" + devuelve_fecha(fecharece.Value) + "', drec_contcli='" + txtcodcontrato.Text + "', " +
                    "drec_rutcli='" + QuitarCaracteres(TxtClirut.Text) + "', drec_RecepTunel='" + CmboTuneles.SelectedValue.ToString() + "'  WHERE frec_codi1='" + TxtCodRece.Text + "'"
                Dim x As Integer = fnc.MovimientoSQL(sql)

                'actualiza si se despacharon pallets 
                Dim sqlDespachos As String = "UPDATE detadespa SET ddes_contcli='" + txtcodcontrato.Text + "'   WHERE ddes_codrece LIKE '%" + TxtCodRece.Text + "__%'"
                fnc.MovimientoSQL(sqlDespachos)

                'actualiza si se predespacharon pallets
                Dim sqlPreDespachos As String = "UPDATE detapred SET dpre_contcli='" + txtcodcontrato.Text + "'   WHERE dpre_folio LIKE '%" + TxtCodRece.Text + "__%'"
                fnc.MovimientoSQL(sqlPreDespachos)

                If fnc.MovimientoSQL(SQL_ModificaRecepcion) > 0 Then
                    MsgBox("Guia recepcion modificada correctamente", MsgBoxStyle.Information, "Aviso")

                    'LOG MODIFICO RECEPCION *************************************************************************************
                    Dim _log As String = "INSERT INTO LOG_FichRece(LFR_CODI, LFR_FECHA, LFR_HORA, LFR_USUARIO, LFR_PC)" +
                        "VALUES('" + TxtCodRece.Text + "','" + devuelve_fecha(fnc.DevuelveFechaServidor()) + "'," +
                        "'" + DevuelveHora() + "','" + Frm_Principal.InfoUsuario.Text + "','" + My.Computer.Name.ToString() + "')"
                    fnc.MovimientoSQL(_log)

                    Dim sqlLogDetFichrece = "insert into LOG_FICHRECE_DETALLE select  GETDATE(),'" & Frm_Principal.InfoUsuario.Text & "',* from fichrece where frec_codi='" + TxtCodRece.Text + "'"
                    fnc.MovimientoSQL(sqlLogDetFichrece)
                    'LOG MODIFICO RECEPCION *************************************************************************************

                    guardaVasAutomatico()
                Else
                    MsgBox("Error al modificar guia", MsgBoxStyle.Critical, "Aviso")
                End If
            End If
        End If
    End Sub


    Sub RecorreGrilla()


        For i As Integer = 0 To DetaRece.RowCount - 1
            Dim codpro As String = DetaRece.Rows(i).Cells("Cod_Producto").Value





            Dim tabla As DataTable = fnc.ListarTablasSQL("SELECT mae_codi FROM maeprod WHERE mae_clirut='" + TxtClirut.Text + "' and mae_codi ='" + codpro + "'")
            If tabla.Rows.Count > 0 Then




            Else

                MsgBox("Existen Soportantes donde el producto no pertenece a el cliente", MsgBoxStyle.Critical, "Aviso")
                Exit Sub

            End If
        Next

    End Sub


    Private Sub btn_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        ' si existe 
        If TxtCodRece.Text <> "" Then
            If fnc.verificaExistencia("fichrece", "frec_codi", TxtCodRece.Text) = False Then
                If TxtCodRece.Enabled = False Then
                    If MsgBox("Desea salir del Proceso de recepcion" + vbCrLf + "-Si abandona esta recepcion perderá todo lo ingresado", _
                              MsgBoxStyle.Question + MsgBoxStyle.YesNoCancel, "Aviso") = vbYes Then
                        CancelaCorrelativo("006", TxtCodRece.Text)

                        'libero estado del checklist
                        Dim sql As String = "UPDATE zcheckList SET cl_estfrigo='0' WHERE cl_fol='" + TxtFolioPorteria.Text + "'"
                        fnc.MovimientoSQL(sql)


                        Dim SqlEliminaTMPDETA As String = "DELETE FROM TmpDetaRece WHERE frec_codi='" + TxtCodRece.Text + "'"
                        fnc.MovimientoSQL(SqlEliminaTMPDETA)


                        sql = "DELETE FROM TmpFichrece WHERE frec_codi='" + TxtCodRece.Text + "'"
                        fnc.MovimientoSQL(sql)

                        sql = "DELETE FROM chk_imagesopo WHERE LEFT(id_pallets,7)='" + TxtCodRece.Text + "'"
                        fnc.MovimientoSQL(sql)

                        sql = "DELETE FROM detarececajas WHERE LEFT(caj_Pcod,7)='" + TxtCodRece.Text + "'"
                        fnc.MovimientoSQL(sql)

                        sql = "DELETE FROM detareceestado WHERE LEFT(rtraq_codi,7)='" + TxtCodRece.Text + "'"
                        fnc.MovimientoSQL(sql)

                        limpiarFormulario()
                        fecharece.Value = fnc.DevuelveFechaServidor()
                        TimeAdicionales.Stop()
                    End If
                Else
                    limpiarFormulario()
                    TimeAdicionales.Stop()
                End If
            Else
                limpiarFormulario()
                TimeAdicionales.Stop()
            End If
        Else
            TxtCodRece.Focus()
            TimeAdicionales.Stop()
        End If
    End Sub

    Private Sub Btn_AnulaGuia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_AnulaGuia.Click
        If RealizarAccion("001", "002") = False Then
            Exit Sub
        End If

        Dim tabla As DataTable = fnc.ListarTablasSQL("SELECT frec_codvig FROM fichrece WHERE frec_codi='" + TxtCodRece.Text + "'")
        If tabla.Rows.Count > 0 Then
            If tabla.Rows(0)(0).ToString() = "0" Then
                Dim tablaOut As DataTable = fnc.ListarTablasSQL("SELECT * FROM detapred WHERE dpre_folio LIKE '%" + TxtCodRece.Text + "__%'")
                If tablaOut.Rows.Count > 0 Then
                    MsgBox("Operacion Denegada, ya se encuentran pallet despachados de esta recepcion", MsgBoxStyle.Critical, "Aviso")
                    Exit Sub
                End If
                If MsgBox("Seguro de anular la guia ", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbYes Then
                    Dim sql As String = "UPDATE fichrece SET frec_codvig='1' WHERE frec_codi='" + TxtCodRece.Text + "'"
                    If fnc.MovimientoSQL(sql) > 0 Then
                        MsgBox("Documento Anulado", MsgBoxStyle.Information, "Aviso")

                        Dim sql_cambia_detalle As String = "UPDATE detarece SET drec_pallet='0', drec_codvig='1' WHERE drec_codi LIKE '" + TxtCodRece.Text + "__%'"
                        fnc.MovimientoSQL(sql_cambia_detalle)

                        Dim Sql_Elimina_Rackdeta As String = "DELETE FROM rackdeta WHERE racd_codi LIKE '" + TxtCodRece.Text + "__%'"
                        fnc.MovimientoSQL(Sql_Elimina_Rackdeta)

                        'libero estado del checklist
                        Dim sqlCl As String = "UPDATE zcheckList SET cl_estfrigo='0' WHERE cl_fol='" + TxtFolioPorteria.Text + "'"
                        fnc.MovimientoSQL(sqlCl)

                        BuscaRecepcionCompleta()
                    End If
                End If
            Else
                MsgBox("El documento ya se encuentra anulado", MsgBoxStyle.Critical, "Aviso")
            End If
        End If
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub Tab_separador_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tab_Detalle.SelectedIndexChanged
        If fnc.verificaExistencia("fichrece", "frec_codi", CerosAnteriorString(TxtCodRece.Text, 7)) = True Then
            Exit Sub
        End If

        If Tab_Detalle.SelectedIndex = 1 Then
            mensaje = "Debe ingresar lo siguiente antes de agregar el detalle"
            If validacion() > 0 Then
                Tab_Detalle.SelectedIndex = 0
                mensaje = ""
            Else
                'guarda TMPFICHRECE
                If fnc.verificaExistencia("TMPFICHRECE", "frec_codi", TxtCodRece.Text) = True Then

                    Dim SqlTemporal As String = "UPDATE TMPFICHRECE SET frec_rutcli='" + QuitarCaracteres(TxtClirut.Text) + "', " +
                        "frec_contcli='" + txtcodcontrato.Text + "', " +
                        "frec_fecproc='" + devuelve_fecha(fecharece.Value) + "', " +
                        "frec_fecrec='" + devuelve_fecha(fecharece.Value) + "', " +
                        "frec_guiades='" + txtguia.Text + "', " +
                        "frec_totsopo='0', frec_totunidad='0', frec_totpeso='0', " +
                        "frec_temppro='" + TxtPromTemp.ToString().Replace(",", ".") + "', frec_rutcond='" + QuitarCaracteres(txtrutchofer.Text) + "', " +
                        "frec_observ='" + Txtobs.Text.Trim + "', frec_tipdesc='" + cmbo_descarga.SelectedValue.ToString() + "', frec_origen='" + txtorigen.Text + "', " +
                        "frec_codvig='0', frec_radio='0', frec_tipo='" + Cmbotiporece.SelectedValue.ToString() + "', " +
                        "frec_RecepTunel='" + CmboTuneles.SelectedValue.ToString() + "', frec_AspectoSanitario='" + retornasanitario() + "', frec_CondGeneral='0', " +
                        "Est_Codi='0',frec_UsuCre='" + Frm_Principal.InfoUsuario.Text + "', " +
                        "FREC_NUMSELLO='" + txtsello.Text + "', frec_tipoalmacenamiento='" + Cmbo_Almacenamiento.Text.ToString() + "', frec_contenedor='" + TxtContenedor.Text + "' " +
                        "where frec_codi='" + TxtCodRece.Text + "'"

                    fnc.MovimientoSQL(SqlTemporal)
                    If Cmbotiporece.Enabled = False Then
                        txtcodsag.Text = TxtContenedor.Text
                    End If

                    If cmbo_descarga.SelectedValue.ToString() = "1" Then
                        CheckArriendo.Checked = True
                    Else
                        CheckArriendo.Checked = False
                    End If
                Else


                    Dim SqlTemporal As String = "INSERT INTO TMPFICHRECE (frec_codi, frec_rutcli, frec_contcli, frec_horalleg, frec_horarec, " +
                        "frec_fecrec, frec_guiades, frec_totsopo, frec_totunidad, frec_totpeso, " +
                        "frec_temppro, frec_rutcond, frec_observ, frec_tipdesc, frec_origen, frec_tipo, " +
                        "frec_RecepTunel, frec_AspectoSanitario, Est_Codi, frec_FecCre, frec_UsuCre, frec_FecMod, " +
                        "FREC_NUMSELLO, frec_tipoalmacenamiento, frec_clfol, frec_contenedor)" +
                        "VALUES('" + TxtCodRece.Text + "','" + QuitarCaracteres(TxtClirut.Text) + "','" + txtcodcontrato.Text + "' ,'" + horalleg.Text + "' ," +
                        "'" + horainic.Text + "','" + devuelve_fecha(fecharece.Value) + "', " +
                        "'" + txtguia.Text + "' ,'0' ,'0' ,'0' ,'" + TxtPromTemp.ToString().Replace(",", ".") + "' ,'" + QuitarCaracteres(txtrutchofer.Text) + "' ,'" + Txtobs.Text.Trim + "' ," +
                        "'" + cmbo_descarga.SelectedValue.ToString() + "' ,'" + txtorigen.Text + "','" + Cmbotiporece.SelectedValue.ToString() + "' ," +
                        "'" + CmboTuneles.SelectedValue.ToString() + "' ,'" + retornasanitario() + "','0','" + fnc.DevuelveFechaServidor() + "','" + Frm_Principal.InfoUsuario.Text + "'," +
                        "'" + fnc.DevuelveFechaServidor() + "','" + txtsello.Text + "','" + Cmbo_Almacenamiento.Text.ToString() + "','" + TxtFolioPorteria.Text + "','" + TxtContenedor.Text + "')"


                    fnc.MovimientoSQL(SqlTemporal)

                    If Cmbotiporece.Enabled = False Then
                        txtcodsag.Text = TxtContenedor.Text
                    End If
                End If
                btn_BuscaCliente.Enabled = False
            End If

        End If
    End Sub

#End Region

#Region "GRILLAS "
    Private Sub volveralpeso()
        Dim sqlNumero As String = "select mae_pcaja from maeprod where mae_descr='" + txtprodnom.Text + "'"
        Dim tablaNumero As DataTable = fnc.ListarTablasSQL(sqlNumero)

        If tablaNumero.Rows.Count > 0 Then
            Dim peso1 As Double = Convert.ToDouble(tablaNumero.Rows(0)(0).ToString())
            Dim pes As Integer = 0

            pes = peso1 * txtunid.Text
            pes = kg.Text + (peso1 * txtunid.Text)
            pes = pes + pesopa
            kg.Text = pes.ToString()

        Else

        End If
    End Sub

    Private Sub DetaRece_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DetaRece.CellDoubleClick
        modifi = "OK"
        If Panel5.Enabled = True Then
            If e.RowIndex > -1 AndAlso e.ColumnIndex <> 0 Then

                If fnc.verificaExistencia("detadespa", "ddes_codrece", Me.DetaRece.Rows(e.RowIndex).Cells("Cod_Pallet").Value.ToString()) = True Then
                    MsgBox("No puede modificar un pallet ya despachado", MsgBoxStyle.Critical, "Aviso")
                    LimpiarProductoIngreso()
                    LimpiarCajas(Panel5)
                    Exit Sub
                End If
                If fila_grilladetalle = -1 Then
                    Exit Sub
                End If
                TxtPallet.Text = Me.DetaRece.Rows(fila_grilladetalle).Cells("Cod_Pallet").Value.ToString()
                txtprodcod.Text = Me.DetaRece.Rows(fila_grilladetalle).Cells("Cod_Producto").Value.ToString()
                txtprodnom.Text = Me.DetaRece.Rows(fila_grilladetalle).Cells("Nombre_Producto").Value.ToString()
                txtsopcodi.Text = "00" + Me.DetaRece.Rows(fila_grilladetalle).Cells("CodSopo").Value.ToString()

                txtsopnombre.Text = Me.DetaRece.Rows(fila_grilladetalle).Cells("NomSopo").Value.ToString()
                txtunid.Text = Me.DetaRece.Rows(fila_grilladetalle).Cells("Cant_Pallets").Value.ToString()

                kg.Text = Me.DetaRece.Rows(fila_grilladetalle).Cells("Peso").Value.ToString()
                If TxtClirut.Text = "801863000" Then
                    traepesopallet()
                    volveralpeso()
                    Dim sqlNumero As String = "SELECT * from detarececajas where caj_pcod='" + TxtPallet.Text.Trim() + "' and val_pretrack is not null"
                    Dim tablaNumero As DataTable = fnc.ListarTablasSQL(sqlNumero)

                    If tablaNumero.Rows.Count > 0 Then

                        txtunid.Enabled = False
                        kg.Enabled = False
                    Else


                        txtunid.Enabled = True
                        kg.Enabled = True
                    End If


                End If

                felaboracion.Value = devuelve_fecha(Me.DetaRece.Rows(fila_grilladetalle).Cells("Elaboracion").Value.ToString())
                fvencimiento.Value = devuelve_fecha(Me.DetaRece.Rows(fila_grilladetalle).Cells("Vencimiento").Value.ToString())
                loteclie.Text = Me.DetaRece.Rows(fila_grilladetalle).Cells("Lote").Value.ToString().Trim()
                txtcodsag.Text = Me.DetaRece.Rows(fila_grilladetalle).Cells("Codsag").Value.ToString()
                txtsopclie.Text = Me.DetaRece.Rows(fila_grilladetalle).Cells("SopCliente").Value.ToString()

                'Inicio Modificación Custodia/Arriendo Pallets. HAmestica 24/10/19
                Dim EstArr As String = Me.DetaRece.Rows(fila_grilladetalle).Cells("arriendo").Value.ToString()
                Dim EstCambPall As String = "0"

                If (EstArr = "1") Then
                    Dim sqlValidCambPall As String = "select Cont=COUNT(ID) from Control_Pallet_TMP_Recepcion_Dañado with(nolock) where Codigo_Soportante='" & TxtPallet.Text.Trim() & "' and Estado='A'"
                    Dim dtValidCambPall As New DataTable

                    dtValidCambPall = fnc.ListarTablasSQL(sqlValidCambPall)

                    If (dtValidCambPall.Rows.Count > 0) Then
                        Dim RespValidCambPall As Integer = CInt(dtValidCambPall.Rows(0).Item(0).ToString.Trim)

                        If (RespValidCambPall > 0) Then
                            EstCambPall = "1"
                        End If
                    End If

                    If (EstCambPall = "1") Then
                        CheckArriendo.Checked = False
                        chkCambioPallet.Checked = True
                    Else
                        CheckArriendo.Checked = True
                        chkCambioPallet.Checked = False
                    End If
                Else
                    If (cmbo_descarga.Text.ToString = "MANUAL") Then
                        CheckArriendo.Checked = True
                    Else
                        CheckArriendo.Checked = False
                    End If

                    chkCambioPallet.Checked = False
                End If
                'Fin Modificación Custodia/Arriendo Pallets. HAmestica 24/10/19


                CMBESTPA.Text = Me.DetaRece.Rows(fila_grilladetalle).Cells("estpallet").Value.ToString()

                Dim sqlBusca = "SELECT mae_descr, mae_diasv,IsNull(sum_dias, 0) as sum_dias FROM maeprod WHERE mae_codi='" + txtprodcod.Text + "'"

                Dim tabla As DataTable = fnc.ListarTablasSQL(sqlBusca)
                If tabla.Rows.Count > 0 Then
                    txtprodnom.Text = tabla.Rows(0)(0).ToString()

                    If Convert.ToInt32(tabla.Rows(0)(1).ToString()) > 0 Then
                        DiasVenc = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                        DiasVenc2 = Convert.ToInt32(tabla.Rows(0)(2).ToString())
                        fvencimiento.Enabled = False
                    Else
                        fvencimiento.Enabled = True
                    End If

                End If
            End If
        End If
    End Sub

    Private Sub DetaRece_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DetaRece.CellClick
        If e.RowIndex > -1 AndAlso e.ColumnIndex = 0 Then
            If Panel5.Enabled = True Then
                If fnc.verificaExistencia("detarece", "drec_codi", Me.DetaRece.Rows(e.RowIndex).Cells("Cod_Pallet").Value.ToString()) = True Then
                    If RealizarAccion("001", "003") = False Then
                        Exit Sub
                    End If
                    If MsgBox("¿Seguro de eliminar el pallet seleccionado de la recepcion y del stock del cliente?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbYes Then
                        If MsgBox("Esta por eliminar un soportante de stock, ¿ desea continuar?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Aviso") = vbYes Then

                            Dim SqlDetaRece As String = "DELETE FROM detarece WHERE drec_codi='" + Me.DetaRece.Rows(e.RowIndex).Cells("Cod_Pallet").Value.ToString() + "'"
                            fnc.MovimientoSQL(SqlDetaRece)

                            Dim sqlRackDeta As String = "DELETE FROM rackdeta WHERE racd_codi='" + Me.DetaRece.Rows(e.RowIndex).Cells("Cod_Pallet").Value.ToString() + "'"
                            fnc.MovimientoSQL(sqlRackDeta)

                            Dim sqlMovPallet As String = "DELETE FROM movpallet WHERE mov_folio='" + Me.DetaRece.Rows(e.RowIndex).Cells("Cod_Pallet").Value.ToString() + "'"
                            fnc.MovimientoSQL(sqlMovPallet)

                            BuscaRecepcionCompleta()
                            SumaTotalPallets()
                            Dim SqlFich As String = "UPDATE fichrece SET frec_totsopo='" + txtsoportantes.Text + "', frec_totunidad='" + txtcajas.Text + "', " +
                                "frec_totpeso='" + txtkilos.Text.Replace(",", ".") + "' WHERE frec_codi='" + TxtCodRece.Text + "'"
                            fnc.MovimientoSQL(SqlFich)
                            MsgBox("Registro eliminado correctamente", MsgBoxStyle.Information, "Aviso")
                        End If
                    End If
                Else
                    If MsgBox("¿Seguro de eliminar el pallet seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbYes Then
                        Dim sql As String = "DELETE FROM TMPDETARECE  WHERE frec_codi='" + Me.DetaRece.Rows(e.RowIndex).Cells("Cod_Pallet").Value.ToString().Remove(7, 2) + "' AND drec_codi='" + Me.DetaRece.Rows(e.RowIndex).Cells("Cod_Pallet").Value.ToString().Remove(0, 7) + "'"
                        Dim sql_DEL As String = "DELETE FROM detarececajas WHERE caj_pcod='" + Me.DetaRece.Rows(e.RowIndex).Cells("Cod_Pallet").Value.ToString() + "'"
                        If fnc.MovimientoSQL(sql) > 0 Then
                            MsgBox("Registro eliminado", MsgBoxStyle.Information, "Aviso")
                            fnc.MovimientoSQL(sql_DEL)
                            CargaGrillaDetalle()
                        End If
                    End If
                End If
            End If
        ElseIf e.RowIndex > -1 Then
            fila_grilladetalle = e.RowIndex.ToString()
        End If
    End Sub

    Private Sub DataAdicionales_CellContentClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) _
        Handles DataAdicionales.CellClick

        '
        ' Detecta si se ha seleccionado el header de la grilla
        '
        If e.RowIndex = -1 Or e.ColumnIndex = -1 Then
            Return
        End If

        If DataAdicionales.Columns(e.ColumnIndex).Name = "cb" Then

            '
            ' Se toma la fila seleccionada
            '
            Dim row As DataGridViewRow = DataAdicionales.Rows(e.RowIndex)

            '
            ' Se selecciona la celda del checkbox
            '
            Dim cellSelecion As DataGridViewCheckBoxCell = TryCast(row.Cells("cb"), DataGridViewCheckBoxCell)

            'If Convert.ToBoolean(cellSelecion.Value) Then
            '    row.DefaultCellStyle.BackColor = Color.White
            'Else
            '    row.DefaultCellStyle.BackColor = Color.Gray
            'End If

        End If
    End Sub

    Private Sub DataAdicionales_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DataAdicionales.CurrentCellDirtyStateChanged
        If DataAdicionales.IsCurrentCellDirty Then
            DataAdicionales.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

#End Region

    Public Sub CargarCombobox()

        Cmbotiporece.DataSource = fnc.ListarTablasSQL("SELECT IdRecepcion , DescripcionRecepcion FROM P_TipoRecepcion ORDER BY IdRecepcion DESC")
        Cmbotiporece.ValueMember = "IdRecepcion"
        Cmbotiporece.DisplayMember = "DescripcionRecepcion"

        Cmbo_Almacenamiento.DataSource = fnc.ListarTablasSQL("SELECT id, almacenamiento FROM P_tipoalmacenamiento ORDER BY id ASC")
        Cmbo_Almacenamiento.ValueMember = "id"
        Cmbo_Almacenamiento.DisplayMember = "almacenamiento"

        cmbo_descarga.DataSource = fnc.ListarTablasSQL("SELECT tcar_codi, tcar_descr FROM P_TipoCargaDescarga ORDER BY tcar_codi ASC")
        cmbo_descarga.ValueMember = "tcar_codi"
        cmbo_descarga.DisplayMember = "tcar_descr"

        CmboTuneles.DataSource = fnc.ListarTablasSQL("SELECT IdTunel, Tunel FROM P_TipoTunel ORDER BY idTunel ASC")
        CmboTuneles.ValueMember = "IdTunel"
        CmboTuneles.DisplayMember = "Tunel"

        cmbAnden.DataSource = fnc.ListarTablasSQL("SELECT cam_codi, cam_descr FROM camaras WHERE cam_codi>='71' AND cam_codi<='80' ORDER BY cam_descr ASC")
        cmbAnden.ValueMember = "cam_codi"
        cmbAnden.DisplayMember = "cam_descr"

        cbonumtun.DataSource = fnc.ListarTablasSQL("select Ncamara from camaraCONf where Ncamara  like'TUNEL%'")
        cbonumtun.ValueMember = "ncamara"
        cbonumtun.DisplayMember = "ncamara"

        produa.DataSource = fnc.ListarTablasSQL("select productoa from producto_a")
        produa.ValueMember = "productoa"
        produa.DisplayMember = "productoa"
    End Sub

    Sub mostrarChkPalProp()
        Try
            Dim tipcar As String = cmbo_descarga.Text.ToString.Trim

            If (tipcar = "MANUAL") Then
                CheckArriendo.Checked = True
                chkCambioPallet.Checked = False
                chkCambioPallet.Enabled = False

                If (DetaRece.Rows.Count > 0) Then
                    cambiarEstArrGrilla(tipcar)
                End If
            End If

            If (tipcar = "MECANICA") Then
                CheckArriendo.Checked = False
                chkCambioPallet.Enabled = True

                If (DetaRece.Rows.Count > 0) Then
                    MsgBox("Debe actualizar cambio de pallets dañados de soportantes ingresados.", MsgBoxStyle.Information, "Aviso")
                    cambiarEstArrGrilla(tipcar)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Sub cambiarEstArrGrilla(ByVal TipCar As String)
        Try
            Dim EstArr As String = "0"
            Dim EstCamb As String = "I"

            If (TipCar = "MANUAL") Then
                EstArr = "1"
            End If

            Dim sqlUpdPalls As String = "update TMPDETARECE set drec_arriendo='" & EstArr & "' where frec_codi='" & TxtCodRece.Text.Trim & "'"
            fnc.MovimientoSQL(sqlUpdPalls)

            Dim sqlUpdPallsCamb As String = "update Control_Pallet_TMP_Recepcion_Dañado set Estado='" & EstCamb & "' where Codigo_Soportante like '" & TxtCodRece.Text.Trim & "%'"
            fnc.MovimientoSQL(sqlUpdPallsCamb)

            For i = 0 To DetaRece.Rows.Count - 1
                DetaRece.Rows(i).Cells("arriendo").Value = EstArr
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SumaTotalPallets()
        ' 6 cajas 7 kilos

        Dim SumaCajas As Integer = 0
        Dim SumaKilos As Double = 0.0

        For i As Integer = 0 To DetaRece.Rows.Count - 1
            SumaCajas = SumaCajas + DetaRece.Rows(i).Cells("Cant_Pallets").Value.ToString()
            SumaKilos = SumaKilos + Convert.ToDouble(DetaRece.Rows(i).Cells("Peso").Value.ToString())
        Next

        txtsoportantes.Text = DetaRece.Rows.Count
        txtcajas.Text = SumaCajas.ToString
        txtkilos.Text = SumaKilos.ToString().Replace(",", ".")

    End Sub

    Private Sub LimpiarProductoIngreso()

        'txtsopclie.Text = ""
        txtsopclie.SelectAll()
        txtunid.Text = ""
        kg.Text = ""
        TxtPallet.Text = ""
        CMBESTPA.SelectedIndex = 0
        'CheckArriendo.Checked = False
    End Sub

    Sub LLENA_GRILLA_AUTOMATICOS()


        Dim sql_addview As String = "CREATE VIEW GESVW_SERVRECE " +
                                    "AS " +
                                    "SELECT Dvas_VasCod VAS, Serv_Cod SERV, Serv_Nom NOM,  Dvas_Unid UNID, Dvas_Cajas CAJAS, REPLACE(Dvas_Kilos,',','.')  AS KILOS " +
                                    "FROM FacVasDeta RIGHT JOIN FacServicios ON Serv_Cod=Dvas_ServCod " +
                                    "WHERE  Dvas_VasCod=(SELECT Vas_cod FROM FacVas WHERE Vas_Dcto='" + TxtCodRece.Text + "' AND Vas_TipDoc='0') AND " +
                                    "Serv_OrdR>0"

        Dim sql_selectserv As String = " SELECT CASE  WHEN isnull(UNID,0)= 0  AND isnull(UNID,0)=0  AND isnull(UNID,0)=0 THEN 'False'  ELSE 'True' END AS dvas_est, " +
                                       "Serv_Cod , Serv_Nom, isnull(UNID,0) dvas_unid, isnull(CAJAS,0) Dvas_Cajas, REPLACE(isnull(KILOS,0),',','.') Dvas_kilos " +
                                       "FROM GESVW_SERVRECE vw RIGHT JOIN FacServicios se ON se.Serv_Cod=serv " +
                                       "WHERE  Serv_OrdR>0 ORDER BY Serv_OrdR"

        Dim sql_borra_view As String = "DROP VIEW GESVW_SERVRECE"


        fnc.MovimientoSQL(sql_addview)
        DataAdicionales.DataSource = fnc.ListarTablasSQL(sql_selectserv)
        fnc.MovimientoSQL(sql_borra_view)

        For i As Integer = 0 To DataAdicionales.Rows.Count - 1
            If DataAdicionales.Rows(i).Cells("se").Value = "013" Then
                CbArriendo.Checked = DataAdicionales.Rows(i).Cells("cb").Value
                TxtArriendo.Text = DataAdicionales.Rows(i).Cells("un").Value
            End If

            If DataAdicionales.Rows(i).Cells("se").Value = "019" Then
                Cb_Postura.Checked = DataAdicionales.Rows(i).Cells("cb").Value
                TxtFilm.Text = DataAdicionales.Rows(i).Cells("un").Value
            End If

            If DataAdicionales.Rows(i).Cells("se").Value = "015" Then
                Cb_Repa.Checked = DataAdicionales.Rows(i).Cells("cb").Value
                TxtRepa.Text = DataAdicionales.Rows(i).Cells("un").Value
            End If

        Next


        'Dim Cobros_Automaticos As String = "SELECT dvas_est, Serv_cod, Serv_Nom, Dvas_Unid, Dvas_Cajas, REPLACE(Dvas_Kilos,',','.') AS Dvas_Kilos  FROM FacVas, FacVasDeta , " +
        '                                   "FacServicios WHERE Dvas_ServCod=Serv_Cod AND Vas_cod=Dvas_VasCod " +
        '                                   "AND Vas_dcto='" + TxtCodRece.Text + "' AND Vas_TipDoc='0' ORDER BY serv_OrdR ASC"




    End Sub

    Public Sub buscaReceTmp(ByVal CodigoRece As String)

        Dim sql As String = "SELECT frec_codi, frec_rutcli, cli_nomb, frec_contcli, cont_descr, frec_horarec, frec_turnrec, " +
                  "frec_fecrec, frec_guiades, frec_totsopo, frec_totunidad, frec_totpeso, " +
                  "frec_temppro, frec_rutcond, cho_nombre, frec_observ, frec_origen, frec_tipo, " +
                  "frec_RecepTunel, frec_AspectoSanitario, frec_TS, frec_TM, frec_TI," +
                  "FREC_NUMSELLO, frec_tipoalmacenamiento, frec_tipdesc, cont_tempgra, cont_tempcon, cho_patente, " +
                  "cho_empresa, Hor_SRI, Hor_SRT, Hor_SDI, Hor_SDT , frec_clfol, frec_contenedor, frec_horalleg, " +
                  "(SELECT COUNT(*) as count FROM TMPDETARECE WHERE isnull(drec_temp,0) <0 AND frec_codi= frec_codi) AS Total, " +
                  "(SELECT SUM(drec_temp) FROM TMPDETARECE WHERE drec_temp<>0 AND frec_codi= frec_codi)/ " +
                  "(SELECT COUNT(*) as count FROM TMPDETARECE WHERE isnull(drec_temp,0) <0 AND frec_codi= frec_codi) AS Promedio " +
                  "FROM tmpfichrece, clientes, choferes, contrato, contratosHorarios WHERE cli_rut=frec_rutcli AND hor_contcod=cont_codi AND " +
                  "frec_contcli=cont_codi AND cho_rut=frec_rutcond AND frec_codi='" + CodigoRece.ToString() + "'"

        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

        If tabla.Rows.Count > 0 Then
            TxtCodRece.Enabled = False
            TxtCodRece.Text = tabla.Rows(0)(0).ToString()
            TxtClirut.Text = tabla.Rows(0)(1).ToString()
            txtclinom.Text = tabla.Rows(0)(2).ToString()
            txtcodcontrato.Text = tabla.Rows(0)(3).ToString()
            txtnom_contrato.Text = tabla.Rows(0)(4).ToString()
            horainic.Text = tabla.Rows(0)(5).ToString()
            fecharece.Value = devuelve_fecha(tabla.Rows(0)(7).ToString())
            txtguia.Text = tabla.Rows(0)(8).ToString()
            txtsoportantes.Text = tabla.Rows(0)(9).ToString()
            txtcajas.Text = tabla.Rows(0)(10).ToString()
            txtkilos.Text = tabla.Rows(0)(11).ToString()
            TxtPromTemp = tabla.Rows(0)(12).ToString()
            txtrutchofer.Text = tabla.Rows(0)(13).ToString()
            txtnombrechofer.Text = tabla.Rows(0)(14).ToString()
            Txtobs.Text = tabla.Rows(0)(15).ToString()
            txtorigen.Text = CerosAnteriorString(tabla.Rows(0)(16).ToString(), 2)
            txtorigend.Text = retorna_Origen(txtorigen.Text)
            Cmbotiporece.SelectedValue = tabla.Rows(0)(17).ToString()
            'Cb_tunel.CheckState = tabla.Rows(0)(18).ToString()

            'sanitarios'
            Dim x As String = tabla.Rows(0)(19).ToString().Chars(4)
            If tabla.Rows(0)(19).ToString().Chars(1) = "0" Then
                Cb_OloresExtraños.Checked = False
            Else
                Cb_OloresExtraños.Checked = True
            End If


            If tabla.Rows(0)(19).ToString().Chars(4) = "0" Then
                Rb_higieneB.Checked = True
            ElseIf tabla.Rows(0)(19).ToString().Chars(4) = "1" Then
                Rb_higieneM.Checked = True
            End If

            If tabla.Rows(0)(19).ToString().Chars(7) = "0" Then
                Rb_EstibaB.Checked = True
            ElseIf tabla.Rows(0)(19).ToString().Chars(7) = "1" Then
                Rb_EstibaM.Checked = True
            End If

            '-----'
            'temp1.Text = tabla.Rows(0)(20).ToString().Replace(",", ".")
            'temp2.Text = tabla.Rows(0)(21).ToString().Replace(",", ".")
            'temp3.Text = tabla.Rows(0)(22).ToString().Replace(",", ".")

            txtsello.Text = tabla.Rows(0)(23).ToString()

            Cmbo_Almacenamiento.Text = tabla.Rows(0)(24).ToString()
            cmbo_descarga.SelectedValue = tabla.Rows(0)(25).ToString()
            TxtTemp.Text = tabla.Rows(0)(26).ToString()
            TxtTempGracia.Text = tabla.Rows(0)(27).ToString()
            txtpatente.Text = tabla.Rows(0)(28).ToString()
            txtempresa.Text = tabla.Rows(0)(29).ToString()
            LV_horini.Text = tabla.Rows(0)(30).ToString()
            LV_ter.Text = tabla.Rows(0)(31).ToString()
            SA_HorIni.Text = tabla.Rows(0)(32).ToString()
            Sab_HorTer.Text = tabla.Rows(0)(33).ToString()
            TxtFolioPorteria.Text = tabla.Rows(0)(34).ToString()
            TxtContenedor.Text = tabla.Rows(0)(35).ToString()
            horalleg.Text = tabla.Rows(0)(36).ToString()
            TxtNpallets = tabla.Rows(0)(37).ToString()
            TxtPromTemp = tabla.Rows(0)(38).ToString()

            btn_guardar.Enabled = True
            Gb_Encabezado.Enabled = True
            Tab_Detalle.Enabled = True

            txtrutchofer.Enabled = False
            TxtClirut.Enabled = False
            txtcodcontrato.Enabled = False
            SumaTotalPallets()

            TxtClirut.Enabled = False
            btn_BuscaCliente.Enabled = False

        End If



    End Sub

    Private Sub CargaGrillaDetalle()
        Dim sql As String = "SELECT frec_codi+''+drec_codi AS Pallet, drec_codPro, mae_descr, " +
            "drec_codsopo, tsop_descr, drec_unidades, drec_peso, CONVERT(datetime,drec_fecprod,111) AS drec_fecprod, " +
            "CONVERT(datetime,fechavencimiento,111) AS fechavencimiento, LoteCliente, drec_codsag, drec_sopocli, isnull(drec_temp,'0') as drec_temp, drec_arriendo,estpallet " +
            "FROM TMPDETARECE, tiposopo, maeprod " +
            "WHERE drec_codpro=mae_codi AND convert(int,tsop_codi)=convert(int,drec_codsopo) AND frec_codi='" + TxtCodRece.Text + "' ORDER BY drec_codi ASC"
        DetaRece.DataSource = fnc.ListarTablasSQL(sql)
        SumaTotalPallets()
    End Sub

    Function retornasanitario() As String
        retornasanitario = ""

        If Cb_OloresExtraños.CheckState = CheckState.Checked Then
            retornasanitario = retornasanitario & "11,"
        Else
            retornasanitario = retornasanitario & "10,"
        End If

        If Rb_higieneB.Checked = True Then
            retornasanitario = retornasanitario & "20,"
        Else
            retornasanitario = retornasanitario & "21,"
        End If

        If Rb_EstibaB.Checked = True Then
            retornasanitario = retornasanitario & "30"
        Else
            retornasanitario = retornasanitario & "31"
        End If

        Return retornasanitario

    End Function

    Public Sub limpiarFormulario()
        BtnBuscar.Enabled = True
        LimpiarCajas(Gb_Cliente)
        LimpiarCajas(Panel5)
        txtResponsable.Text = fnc.DevuelveUsuario(Frm_Principal.InfoUsuario.Text)
        BtnImprimir.Enabled = False
        For i As Integer = 0 To DetaRece.Rows.Count - 1
            DetaRece.Rows.RemoveAt(0)
        Next
        CargarCombobox()
        txtrutchofer.Enabled = True
        txtrutchofer.Text = ""
        cbonumtun.Text = ""
        cbonumtun.Enabled = False
        txtsoportantes.Text = "0"
        txtcajas.Text = "0"
        txtkilos.Text = "0"
        TxtPromTemp = "0"

        'Cb_tunel.CheckState = 0
        Cb_OloresExtraños.CheckState = 0
        cbdañado.CheckState = 0

        Rb_higieneB.Checked = False
        Rb_higieneM.Checked = False
        lblenvguia.Visible = False
        lblkilguia.Visible = False
        txtenvguia.Visible = False
        txtkilguia.Visible = False
        datosguia = "0"
        chkdatosguia.Checked = False
        Rb_EstibaB.Checked = False
        Rb_EstibaM.Checked = False

        horainic.Text = ""
        horaterm.Text = ""
        horalleg.Text = ""

        fecharece.Value = fnc.DevuelveFechaServidor()
        Gb_Encabezado.Enabled = False

        Tab_Detalle.Enabled = False
        Tab_Detalle.SelectedIndex = 0

        btn_guardar.Enabled = False
        Panel5.Enabled = True

        TxtCodRece.Text = ""
        TxtCodRece.Enabled = True
        TxtCodRece.Focus()
        Txtobs.Text = ""

        BtnBuscar.Enabled = True

        TxtClirut.Text = ""
        TxtClirut.Enabled = True
        txtcodcontrato.Enabled = True
        TxtFolioPorteria.Text = ""
        LimpiarCajas(Panel5)
        Cmbotiporece.Enabled = True
        TxtPallet.Text = ""
        b_impr = False
        BtnImprimir.Enabled = False
        TxtNpallets = "0"
        TxtPromTemp = "0"

        cmbo_descarga.Enabled = True
    End Sub

    Sub guardaVasAutomatico()

        Dim cantidad As Integer = DataAdicionales.Rows.Count - 1
        Dim registros As Integer = 0

        If cantidad >= 0 Then
            If fnc.verificaExistenciaCondicional("FacVas", "Vas_Dcto='" + TxtCodRece.Text + "' AND Vas_TipDoc='0' ") = False Then
                Dim CODIGO_VAS As String = BuscaCorrelativo("012", 7)
                For i As Integer = 0 To cantidad
                    If DataAdicionales.Rows(i).Cells("un").Value.ToString() <> "0" Then
                        registros = registros + 1
                    End If
                Next
                If registros > 0 Then
                    Dim sql As String = "INSERT INTO facvas(Vas_cod, vas_clirut, vas_cont, vas_dcto, vas_fecha, vas_guia, vas_estado, vas_seccion, vas_tipdoc, Vas_Obs, vas_emis, vas_usucod)" +
                                                       "VALUES('" + CODIGO_VAS + "','" + TxtClirut.Text + "','" + txtcodcontrato.Text + "','" + TxtCodRece.Text + "'," +
                                                       "'" + devuelve_fecha(fecharece.Value) + "','" + txtguia.Text + "','0','0','0','" + OBSERVACION_VAS.ToString() + "'," +
                                                       "GETDATE(),'" + Frm_Principal.InfoUsuario.Text + "')"
                    If fnc.MovimientoSQL(sql) > 0 Then
                        For i As Integer = 0 To DataAdicionales.Rows.Count - 1

                            Dim true_false As Boolean = False

                            Dim Unidad1 As String = "0"
                            Dim Unidad2 As String = "0"
                            Dim Unidad3 As String = "0"

                            If Not IsNothing(DataAdicionales.Rows(i).Cells("un").Value) Then
                                Unidad1 = DataAdicionales.Rows(i).Cells("un").Value.ToString().Replace(",", ".")
                            End If
                            If Not IsNothing(DataAdicionales.Rows(i).Cells("ca").Value) Then
                                Unidad2 = DataAdicionales.Rows(i).Cells("ca").Value.ToString()
                            End If
                            If Not IsNothing(DataAdicionales.Rows(i).Cells("ki").Value) Then
                                Unidad3 = DataAdicionales.Rows(i).Cells("ki").Value.ToString()
                            End If
                            If Not IsNothing(DataAdicionales.Rows(i).Cells("cb").Value) Then
                                true_false = DataAdicionales.Rows(i).Cells("cb").Value.ToString()
                            End If

                            If Unidad1 <> "0" Or Unidad2 <> "0" Or Unidad2 <> "0" Then
                                Dim sqlDetalle As String = "INSERT INTO facVasDeta(Dvas_VasCod, dvas_est, Dvas_ServCod, Dvas_Unid, Dvas_Cajas, Dvas_Kilos, Dvas_cobrar)" +
                                                                                    "VALUES('" + CODIGO_VAS + "','" + true_false.ToString() + "','" + DataAdicionales.Rows(i).Cells("se").Value.ToString() + "'," +
                                                                                    "'" + Unidad1.ToString() + "','" + Unidad2.ToString() + "','" + Unidad3.ToString() + "','0')"

                                fnc.MovimientoSQL(sqlDetalle)
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
                Dim Consulta_Numero_Vas As String = "SELECT  Vas_cod  FROM    FacVas WHERE Vas_Dcto='" + TxtCodRece.Text + "' AND Vas_TipDoc='0' "
                Dim tabla As DataTable = fnc.ListarTablasSQL(Consulta_Numero_Vas)
                If tabla.Rows.Count > 0 Then
                    CODIGO_VAS = tabla.Rows(0)(0).ToString()
                Else
                    CODIGO_VAS = BuscaCorrelativo("012", 7)
                End If
                If registros = 0 Then
                    Dim Elimina1 As String = "DELETE FROM FacVas WHERE vas_Cod='" + CODIGO_VAS + "' "
                    Dim Elimina2 As String = "DELETE FROM FacVasDeta WHERE Dvas_VasCod='" + CODIGO_VAS + "' "
                    fnc.MovimientoSQL(Elimina1)
                    fnc.MovimientoSQL(Elimina2)
                    'cancela correlativo
                    'CancelaCorrelativo("012", CODIGO_VAS)

                    Exit Sub
                End If
                Dim sql As String = "UPDATE facvas SET  vas_clirut='" + TxtClirut.Text + "', vas_cont='" + txtcodcontrato.Text + "', " +
                    "vas_dcto='" + TxtCodRece.Text + "', vas_fecha='" + devuelve_fecha(fecharece.Value) + "', vas_guia='" + txtguia.Text + "', " +
                    "Vas_Obs ='" + OBSERVACION_VAS.ToString() + "' WHERE Vas_cod='" + CODIGO_VAS + "'"
                fnc.MovimientoSQL(sql)

                Dim Eliminar As String = "DELETE FROM FacVasDeta WHERE Dvas_VasCod='" + CODIGO_VAS + "' "
                fnc.MovimientoSQL(Eliminar)

                For i As Integer = 0 To DataAdicionales.Rows.Count - 1

                    Dim true_false As Boolean = False

                    Dim Unidad1 As String = "0"
                    Dim Unidad2 As String = "0"
                    Dim Unidad3 As String = "0"

                    If Not IsNothing(DataAdicionales.Rows(i).Cells("un").Value) Then
                        Unidad1 = DataAdicionales.Rows(i).Cells("un").Value.ToString().Replace(",", ".")
                    End If

                    If Not IsNothing(DataAdicionales.Rows(i).Cells("ca").Value) Then
                        Unidad2 = DataAdicionales.Rows(i).Cells("ca").Value.ToString()
                    End If

                    If Not IsNothing(DataAdicionales.Rows(i).Cells("ki").Value) Then
                        Unidad3 = DataAdicionales.Rows(i).Cells("ki").Value.ToString()
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

                Next
            End If
        End If
    End Sub

    Private Sub DESBLOQUEARTRAQUEODESOPORTANTEToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DESBLOQUEARTRAQUEODESOPORTANTEToolStripMenuItem.Click
        If RealizarAccion("001", "064", False) = False Then
            MsgBox("No Puede Desbloquear este soportante", MsgBoxStyle.Critical, "Aviso")
            Exit Sub
        End If
        Dim sql As String = "SELECT isnull(drec_codcaja,0) AS drec_codcaja FROM detarece WHERE drec_codi='" + Me.DetaRece.Rows(fila_grilladetalle).Cells(1).Value.ToString() + "'"
        Dim TablaEstado As DataTable = fnc.ListarTablasSQL(sql)

        If Convert.ToInt32(TablaEstado.Rows(0)(0).ToString()) = 1 Then
            sql = "UPDATE detarece SET drec_codcaja='0' WHERE drec_codi='" + Me.DetaRece.Rows(fila_grilladetalle).Cells(1).Value.ToString() + "'"
            If fnc.MovimientoSQL(sql) > 0 Then
                MsgBox("Soportante Desbloqueado", MsgBoxStyle.Information, "Aviso")
            End If
        End If


    End Sub

    Private Sub ETIQUETASDECAJASToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ETIQUETASDECAJASToolStripMenuItem.Click

        If MsgBox("¿Seguro de imprimir las etiquetas de las cajas que se generaron de este soportante? ", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbYes Then
            Dim sql As String = "SELECT Caj_cod  FROM DetaReceCajas WHERE Caj_Pcod='" + Me.DetaRece.Rows(fila_grilladetalle).Cells(1).Value.ToString() + "' AND Caj_Est='1'"
            Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

            If tabla.Rows.Count > 0 Then
                For i As Integer = 0 To tabla.Rows.Count - 1
                    System.Console.WriteLine(txtclinom.Text + "    " + Me.DetaRece.Rows(fila_grilladetalle).Cells(1).Value.ToString() + "    " +
                                       tabla.Rows(i)(0).ToString() + "    " + CType(tabla.Rows(i)(0).ToString().Remove(0, 5).Remove(5, 10), String))

                    COM1.ImpresionCaja(txtclinom.Text, Me.DetaRece.Rows(fila_grilladetalle).Cells(1).Value.ToString() + " - " + Me.DetaRece.Rows(fila_grilladetalle).Cells(3).Value.ToString(),
                                       "" + CType(tabla.Rows(i)(0).ToString(), String), CType(tabla.Rows(i)(0).ToString().Remove(0, 5).Remove(5, 10), String))
                Next
            Else
                MsgBox("El soportante seleccionado no tiene etiquetas para imprimir", MsgBoxStyle.Critical, "Aviso")
            End If


        End If
    End Sub

    Private Sub felaboracion_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
    Handles felaboracion.KeyPress

        If e.KeyChar <> ChrW(13) Then
            e.Handled = True
        Else
            If fvencimiento.Enabled = False Then
                txtunid.Focus()
            Else
                fvencimiento.Focus()
            End If
        End If
    End Sub

    Private Sub felaboracion_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles felaboracion.ValueChanged
        If fvencimiento.Enabled = False Then
            fvencimiento.Value = felaboracion.Value.AddMonths(DiasVenc)
            fvencimiento.Value = fvencimiento.Value.AddDays(DiasVenc2)
        End If
    End Sub

    Private Sub fvencimiento_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles fvencimiento.KeyPress
        txtunid.Focus()
    End Sub


    Private Sub DetaRece_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DetaRece.CellContentClick

    End Sub

    Private Sub loteclie_TextChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub btnAdjuntarFotos_Click(sender As System.Object, e As System.EventArgs) Handles btnAdjuntarFotos.Click
        Dim frm As New Frm_AdjuntaFotoRecepcion
        frm.Show()
        frm.txtGuiaRecepcion.Text = TxtCodRece.Text
    End Sub

    Private Sub CmboTuneles_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles CmboTuneles.SelectedIndexChanged
        If CmboTuneles.SelectedIndex = 1 Then

            cbonumtun.Enabled = True
            'cbonumtun.SelectedIndex = 0
        Else
            cbonumtun.Enabled = False
            cbonumtun.SelectedIndex = 0
            cbonumtun.Text = ""
        End If
        'If CmboTuneles.SelectedIndex = 0 Then

        '    cbonumtun.Enabled = False
        '    cbonumtun.SelectedIndex = 0
        '    cbonumtun.Text = ""

        'End If
    End Sub

    Private Sub txtprodnom_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtprodnom.TextChanged

    End Sub

    Private Sub Label19_Click(sender As System.Object, e As System.EventArgs) Handles Label19.Click

    End Sub

    Private Sub txtprodcod_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtprodcod.TextChanged

    End Sub

    Private Sub TxtCodRece_KeyUp(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtCodRece.KeyUp

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkdatosguia.CheckedChanged
        If chkdatosguia.Checked = True Then

            lblenvguia.Visible = True
            lblkilguia.Visible = True
            txtenvguia.Visible = True
            txtkilguia.Visible = True
            datosguia = "1"
        Else
            lblenvguia.Visible = False
            lblkilguia.Visible = False
            txtenvguia.Visible = False
            txtkilguia.Visible = False
            datosguia = "0"
        End If
    End Sub

    Private Sub txtkilguia_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtkilguia.TextChanged

    End Sub

    Private Sub txtkilguia_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtkilguia.KeyPress
        If e.KeyChar = ChrW(13) Then
            ' loteclie.Focus()
        Else
            Dim KeyAscii As Short = Asc(e.KeyChar)
            If Not ((KeyAscii >= System.Windows.Forms.Keys.D0 And KeyAscii <= System.Windows.Forms.Keys.D9) Or
                    (KeyAscii = System.Windows.Forms.Keys.Back) Or Chr(KeyAscii) = "." Or (Chr(KeyAscii) Like "[ ]")) Then
                KeyAscii = 0
                kg.Focus()
            End If
            If KeyAscii = 0 Then
                e.Handled = True
            End If

            If kg.Text.IndexOf(".") >= 0 And e.KeyChar = "." Then
                e.Handled = True
            End If

            If kg.Text.IndexOf(".") > 0 Then
                If kg.SelectionStart > kg.Text.IndexOf(".") Then
                    If kg.Text.Length - kg.Text.IndexOf(".") = 3 Then
                        e.Handled = True
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub txtenvguia_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtenvguia.KeyPress
        '
        SoloNumeros(sender, e)
    End Sub
    Private Sub insertadetarececajas()

        Dim query As String = ""

        Dim sql As String = "Select etiquetacompleta from t_tracking where IdEtiquetaAutoIncrement='" + txttrackprev.Text.Trim() + "'"
        Dim tabla As DataTable = fnc.ListarTablasSQLetiqueta(sql)

        If tabla.Rows.Count > 0 Then



            For i As Integer = 0 To tabla.Rows.Count - 1


                query = "INSERT INTO DetareceCajas (Caj_Pcod, Caj_cod, caj_codenca,val_pretrack)VALUES('" + TxtCodRece.Text.Trim() + NumeroPallet.ToString() + "','" + tabla.Rows(i)(0).ToString() + "','" + Frm_Principal.InfoUsuario.Text.Trim() + "','" + txttrackprev.Text.Trim() + "')"
                fnc.MovimientoSQL(query)
            Next

        Else

            MsgBox("El Codigo De Pretraqueo No existe, No se añadio traqueo automatico", MsgBoxStyle.Critical, "Aviso")

        End If

        '

        'For i As Integer = 0 To ListBox1.Items.Count - 1
        '    If (i = ListBox1.Items.Count - 1) Then
        '        valores &= "('" + tpal.Text.ToUpper + "','" + ListBox1.Items(i).ToString() + "','" + CerosAnteriorString(codigo_usuario, 3) + "')"
        '    Else
        '        valores &= "('" + tpal.Text.ToUpper + "','" + ListBox1.Items(i).ToString() + "','" + CerosAnteriorString(codigo_usuario, 3) + "'),"
        '    End If
        'Next

        '            query = "INSERT INTO DetareceCajas (Caj_Pcod, Caj_cod, caj_codenca)VALUES" & _
        ''For i As Integer = 0 To ListBox1.Items.Count - 1
        '    If (i = ListBox1.Items.Count - 1) Then
        '        valores &= "('" + tpal.Text.ToUpper + "','" + ListBox1.Items(i).ToString() + "','" + CerosAnteriorString(codigo_usuario, 3) + "')"
        '    Else
        '        valores &= "('" + tpal.Text.ToUpper + "','" + ListBox1.Items(i).ToString() + "','" + CerosAnteriorString(codigo_usuario, 3) + "'),"
        '    End If
        'Next

    End Sub
    Private Sub chkpretrack_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkpretrack.CheckedChanged
        If chkpretrack.Checked = True Then
            txttrackprev.Text = ""
            txttrackprev.Enabled = True
            txttrackprev.Focus()
            txtunid.Enabled = False
            kg.Enabled = False
        ElseIf chkpretrack.Checked = False Then
            txttrackprev.Text = ""
            txttrackprev.Enabled = False
            txtunid.Enabled = True
            kg.Enabled = True
        End If
    End Sub

    Private Sub txttrackprev_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txttrackprev.KeyPress
        SoloNumeros(sender, e)
    End Sub

    Private Sub CheckArriendo_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckArriendo.CheckedChanged
        If (CheckArriendo.Checked) Then
            chkCambioPallet.Checked = False
        End If
    End Sub

    Private Sub cbonumtun_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbonumtun.SelectedIndexChanged

    End Sub

    Private Sub OpcionImprimir_Opening(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles OpcionImprimir.Opening

    End Sub

    Private Sub btnExcel_Click(sender As System.Object, e As System.EventArgs) Handles btnExcel.Click
        Dim sql As String = "Select * from vg_cajas_recepcion_peso where RECEPCION='" + TxtCodRece.Text.Trim() + "' order by PESO DESC"
        DgvResultado.DataSource = fnc.ListarTablasSQL(sql)
        If DgvResultado.Rows.Count = 0 Then
            MsgBox("No existen Cajas para mostrar en esta recepción ", MsgBoxStyle.Critical, "Aviso")
            Exit Sub

        Else
            GridAExcel(DgvResultado)

        End If

    End Sub

    Private Sub TxtCodRece_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtCodRece.TextChanged

    End Sub

    Private Sub chkCambioPallet_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkCambioPallet.CheckedChanged
        If (chkCambioPallet.Checked) Then
            CheckArriendo.Checked = False
        End If
    End Sub

    Private Sub cmbo_descarga_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cmbo_descarga.SelectedIndexChanged
        mostrarChkPalProp()
    End Sub
End Class
Public Class Frm_Etiquetado

    Dim fnc As New Funciones
    Dim i As Integer = 0
    Dim temp As String = ""

    Private Sub Txtfolio_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtfolio.KeyPress
        If e.KeyChar = ChrW(13) Then
            If Txtfolio.Text = "" Then
                'If RealizarAccion("020", "054", True) = False Then
                '    Exit Sub
                'End If
                Txtfolio.Text = BuscaCorrelativo("014", 5)
                Txtfolio.Enabled = False
                GroupBox2.Enabled = True
                txthorini.Text = DevuelveHora()
                BtnBuscar.Enabled = False
                BtnImprimir.Enabled = False
                TimerAdicionales.Start()
                BtnLectura.Enabled = True
                DgvEtiquetado.Enabled = True
            Else
                RescataProceso(CerosAnteriorString(Txtfolio.Text, 5))
            End If
        Else
            SoloNumeros(sender, e)
        End If
    End Sub

    Sub RescataProceso(ByVal codigo As String)

        Dim sql As String = "SELECT etiq_clirut, cli_nomb, cont_codi, cont_descr, ETIQ_FECHA, ETIQ_HORINI, ETIQ_HORTER, usu_nombre+' '+ usu_ap AS Usuario " +
                            "FROM FICHETIQ INNER JOIN clientes ON cli_rut=ETIQ_CLIRUT INNER JOIN contrato ON cont_codi=ETIQ_CODCONT INNER JOIN usuarios ON usu_codigo=ETIQ_CODENCA WHERE ETIQ_CODI='" + codigo + "'"

        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)
        If tabla.Rows.Count > 0 Then

            Txtfolio.Text = codigo
            Txtfolio.Enabled = False

            TxtClirut.Text = tabla.Rows(0)(0).ToString()
            txtclinom.Text = tabla.Rows(0)(1).ToString()

            txtcodcontrato.Text = tabla.Rows(0)(2).ToString()
            txtcontnom.Text = tabla.Rows(0)(3).ToString()

            Dtfecha.Value = tabla.Rows(0)(4).ToString()
            txthorini.Text = tabla.Rows(0)(5).ToString()
            TxtHorter.Text = tabla.Rows(0)(6).ToString()
            Txtresp.Text = tabla.Rows(0)(7).ToString()


            Dim sql2 As String = "SELECT drec_fecprod AS ETIQ_FECPROD, FechaVencimiento AS ETIQ_FECVENC, ETIQ_SOPOPRE, isnull(ETIQ_NSOPOCLI,ETIQ_SOPOCLI) AS ETIQ_SOPOCLI1, ETIQ_CODPRO, " +
                "MAE_DESCR, ETIQ_CAJAS, ETIQ_KILOS, ETIQ_SOPOCLI  FROM DETAETIQ INNER JOIN MAEPROD ON ETIQ_CODPRO=mae_codi INNER JOIN detarece ON drec_codi=ETIQ_SOPOPRE " +
                "WHERE   ETIQ_CODI='" + Txtfolio.Text + "'"


            Dim _dt As DataTable = fnc.ListarTablasSQL(sql2)
            DgvEtiquetado.DataSource = _dt

            Dim sql_totales = "SELECT COUNT(*), ISNULL(SUM(ETIQ_CAJAS),0), ISNULL(SUM(ETIQ_KILOS),0) from DETAETIQ where ETIQ_CODI='" + Txtfolio.Text + "'"
            Dim tabla2 As DataTable = fnc.ListarTablasSQL(sql_totales)
            txtpallets.Text = tabla2.Rows(0)(0).ToString()
            txtcajas.Text = tabla2.Rows(0)(1).ToString()
            txtkilos.Text = tabla2.Rows(0)(2).ToString()
            BtnLectura.Enabled = False
            DgvEtiquetado.Enabled = False

            VAS_AUTOMATICO()

        Else
            MsgBox("El codigo ingresado no existe", MsgBoxStyle.Information, "Aviso")
        End If

    End Sub

    Sub VAS_AUTOMATICO()
        Dim Cobros_Automaticos As String = "SELECT dvas_est, Serv_cod, Serv_Nom, Dvas_Unid, Dvas_Cajas, REPLACE(Dvas_Kilos,',','.') AS Dvas_Kilos  FROM FacVas, FacVasDeta , " +
                                           "FacServicios WHERE Dvas_ServCod=Serv_Cod AND Vas_cod=Dvas_VasCod AND Vas_dcto='" + Txtfolio.Text + "' AND Vas_TipDoc='2' ORDER BY serv_OrdR ASC"

        If fnc.ListarTablasSQL(Cobros_Automaticos).Rows.Count > 0 Then
            DataAdicionales.DataSource = fnc.ListarTablasSQL(Cobros_Automaticos)

            For i As Integer = 0 To DataAdicionales.Rows.Count - 1
                If DataAdicionales.Rows(i).Cells("se").Value = "020" Then
                    CBIMPRESION.Checked = DataAdicionales.Rows(i).Cells("cb").Value
                End If

                If DataAdicionales.Rows(i).Cells("se").Value = "021" Then
                    RBETIQESPEC.Checked = DataAdicionales.Rows(i).Cells("cb").Value
                End If

                If DataAdicionales.Rows(i).Cells("se").Value = "022" Then
                    RBETIQGENE.Checked = DataAdicionales.Rows(i).Cells("cb").Value
                End If

                If DataAdicionales.Rows(i).Cells("se").Value = "023" Then
                    CBRETIROETIQ.Checked = DataAdicionales.Rows(i).Cells("cb").Value
                End If

                If DataAdicionales.Rows(i).Cells("se").Value = "026" Then
                    CBMOVEXT.Checked = DataAdicionales.Rows(i).Cells("cb").Value
                End If

                If DataAdicionales.Rows(i).Cells("se").Value = "015" Then
                    CBREPA.Checked = DataAdicionales.Rows(i).Cells("cb").Value
                    txtrepa.Text = DataAdicionales.Rows(i).Cells("un").Value
                End If

            Next
        Else

        End If

    End Sub

    Private Sub TxtClirut_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtClirut.KeyPress
        If e.KeyChar = ChrW(13) Then
            If TxtClirut.Text.Length >= 9 Then
                txtclinom.Text = RetornaCliente(TxtClirut.Text)
                Btn_BuscaContrato.Enabled = True
                TxtClirut.Enabled = False
                GroupBox1.Enabled = True
                BtnImprimir.Enabled = False
            Else
                MsgBox("El rut ingresado no existe", MsgBoxStyle.Critical, "Aviso")
            End If
        End If
    End Sub

    Private Sub txtcodcontrato_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcodcontrato.KeyPress
        If e.KeyChar = ChrW(13) Then
            Dim sql As String = "SELECT cont_descr, cont_tempcon, cont_tempgra, Hor_SRI, Hor_SRT, Hor_FRI, Hor_FRT FROM contrato, contratosHorarios " +
                "WHERE cont_codi=Hor_Contcod AND cont_rutclie='" + TxtClirut.Text + "' AND cont_codi='" + CerosAnteriorString(txtcodcontrato.Text, 7) + "'"
            Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

            If tabla.Rows.Count > 0 Then
                txtcodcontrato.Enabled = False
                txtcodcontrato.Text = CerosAnteriorString(txtcodcontrato.Text, 7)
                txtcontnom.Text = tabla.Rows(0)(0).ToString()
            Else
                MsgBox("El numero ingresado no existe o no corresponde a este cliente", MsgBoxStyle.Critical, "Aviso")
            End If
        End If
    End Sub

    Private Sub btn_BuscaCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_BuscaCliente.Click

        Dim frm As New Lst_AyudaClientes
        frm.ShowDialog(Frm_Principal)
        Dim RUT As String = Frm_Principal.buscavalor

        If RUT.ToString.Length > 0 Then

            If Len(RUT) >= 9 Then
                TxtClirut.Text = RUT
                txtclinom.Text = RetornaCliente(RUT)
                Btn_BuscaContrato.Enabled = True
                txtcodcontrato.Text = ""
                txtcontnom.Text = ""
                TxtClirut.Enabled = False

            Else
                MsgBox("El rut ingresado no existe", MsgBoxStyle.Information, "Aviso")
            End If
        End If

    End Sub

    Private Sub Btn_BuscaContrato_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_BuscaContrato.Click
        Dim frm As New Lst_AyudaContratos
        frm.condicion = "WHERE  cont_rutclie='" + QuitarCaracteres(TxtClirut.Text) + "'"
        frm.ShowDialog(Frm_Principal)

        Dim cod_cont As String = Frm_Principal.buscavalor

        If cod_cont.Length > 0 Then
            txtcodcontrato.Enabled = False
            txtcodcontrato.Text = cod_cont.ToString()
            txtcontnom.Text = RetornaContrato(cod_cont)
        End If


    End Sub

    Private Sub BuscaSoportantes_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BuscaSoportantes.Tick
        carga_grilla()
    End Sub

    Private Sub BtnLectura_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLectura.Click

        If fnc.verificaExistencia("CLIENTES", "CLI_RUT", TxtClirut.Text) = False Then
            MsgBox("Falta cliente por ingresar", MsgBoxStyle.Critical, "Aviso")

        ElseIf fnc.verificaExistencia("CONTRATO", "CONT_CODI", txtcodcontrato.Text) = False Then
            MsgBox("Falta contrato por ingresar", MsgBoxStyle.Critical, "Aviso")

        Else

            If BtnLectura.Text = "HABILITAR LECTURA POR R.F." Then
                If fnc.verificaExistencia("TMPFICHETIQ", "ETIQ_CODI", Txtfolio.Text) = False Then

                    Dim sql As String = "INSERT INTO tmpfichetiq(etiq_codi, etiq_clirut, etiq_codcont, etiq_fecha, etiq_horini, etiq_codenca, etiq_est)" +
                               "VALUES('" + Txtfolio.Text + "','" + TxtClirut.Text + "','" + txtcodcontrato.Text + "','" + devuelve_fecha(Dtfecha.Value) + "'," +
                               "'" + txthorini.Text + "','" + Frm_Principal.InfoUsuario.Text + "','0')"

                    If fnc.MovimientoSQL(sql) > 0 Then
                        BuscaSoportantes.Start()
                        btn_BuscaCliente.Enabled = False
                        Btn_BuscaContrato.Enabled = False
                        btn_guardar.Enabled = True
                    End If

                Else
                    BuscaSoportantes.Start()
                End If
                BtnLectura.Text = "DESHABILITAR LECTURA PARA R.F."
                BtnLectura.ForeColor = Color.Red

            ElseIf BtnLectura.Text = "DESHABILITAR LECTURA PARA R.F." Then
                BtnLectura.Text = "HABILITAR LECTURA POR R.F."
                BtnLectura.ForeColor = Color.Black
                BuscaSoportantes.Stop()
            End If

        End If
    End Sub

    Private Sub Frm_Etiquetado_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F1 Then
            Dim f As New Frm_RecuperaEtiq
            f.ShowDialog(Frm_Principal)
            If Frm_Principal.buscavalor.ToString <> "" Then
                RecuperaEtiquetadoTMP(Frm_Principal.buscavalor.ToString())
            End If
        End If
    End Sub

    Private Sub Frm_Etiquetado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Frm_Principal.buscavalor = ""

        Txtresp.Text = Frm_Principal.lblnombre.Text
        DataAdicionales.DataSource = fnc.ListarTablasSQL("SELECT Serv_Cod, Serv_Nom, '0' AS Dvas_Unid,'0' AS dvas_cajas,'0' AS dvas_kilos " +
                                                         "FROM FacServicios WHERE ISNULL(serv_orde,0)>0 ORDER BY serv_orde ASC")
    End Sub

    Private Sub DgvEtiquetado_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles DgvEtiquetado.CellBeginEdit
        temp = CStr(DgvEtiquetado.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString())
    End Sub

    'Private Sub DgvEtiquetado_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DgvEtiquetado.EditingControlShowing

    '    ' obtener indice de la columna   
    '    Dim columna As Integer = DgvEtiquetado.CurrentCell.ColumnIndex

    '    ' comprobar si la celda en edición corresponde a la columna 6 
    '    If (columna = 1) Then

    '        ' referencia a la celda   
    '        Dim validar As TextBox = CType(e.Control, TextBox)

    '        ' agregar el controlador de eventos para el KeyPress   
    '        If validar.Text <> "" Then
    '            AddHandler validar.KeyPress, AddressOf SoloNumeros
    '        Else
    '            validar.Text = "0"
    '        End If
    '    End If
    'End Sub

    Private Sub DgvEtiquetado_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvEtiquetado.CellEndEdit
        Dim dgv As DataGridView = sender

        If e.RowIndex > -1 AndAlso e.ColumnIndex > -1 Then
            If e.ColumnIndex = dgv.Columns("SC").Index Then
                If Me.DgvEtiquetado.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString() = "" Then
                    DgvEtiquetado.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = "0"

                End If

                Dim sql As String = "UPDATE TMPDETAETIQ SET ETIQ_NSOPOCLI='" + DgvEtiquetado.Rows(e.RowIndex).Cells(e.ColumnIndex).Value + "' " +
                    "WHERE ETIQ_SOPOPRE='" + DgvEtiquetado.Rows(e.RowIndex).Cells("SP").Value + "'"

                fnc.MovimientoSQL(sql)

            ElseIf e.ColumnIndex = dgv.Columns("CPROD").Index Then

                Dim sql As String = "SELECT mae_descr FROM maeprod WHERE mae_clirut='" + TxtClirut.Text + "' AND  " +
                    "mae_codi='" + DgvEtiquetado.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString() + "'"
                Dim tabla As DataTable = fnc.ListarTablasSQL(sql)
                If tabla.Rows.Count > 0 Then
                    DgvEtiquetado.Rows(e.RowIndex).Cells("PROD").Value = tabla.Rows(0)(0).ToString()

                    Dim sql_actualiza As String = "UPDATE TMPDETAETIQ SET ETIQ_CODPRO='" + DgvEtiquetado.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString() + "' " +
                    "WHERE ETIQ_SOPOPRE='" + DgvEtiquetado.Rows(e.RowIndex).Cells("SP").Value + "'"

                    fnc.MovimientoSQL(sql_actualiza)
                Else
                    DgvEtiquetado.Rows(e.RowIndex).Cells("PROD").Value = temp
                End If

            ElseIf e.ColumnIndex = dgv.Columns("FV").Index Or e.ColumnIndex = dgv.Columns("FP").Index Then

                Dim sql As String = "UPDATE TMPDETAETIQ SET ETIQ_FECPROD='" + devuelve_fecha(DgvEtiquetado.Rows(e.RowIndex).Cells("FP").Value) + "', " +
                    "ETIQ_FECVENC='" + devuelve_fecha(DgvEtiquetado.Rows(e.RowIndex).Cells("FV").Value) + "' " +
                    "WHERE ETIQ_SOPOPRE='" + DgvEtiquetado.Rows(e.RowIndex).Cells("SP").Value + "'"

                fnc.MovimientoSQL(sql)

            End If

        End If
    End Sub

    Sub RecuperaEtiquetadoTMP(ByVal codigo_TMP As String)

        Dim sql As String = "SELECT ETIQ_CODI, ETIQ_CLIRUT, cli_nomb, cont_codi, cont_descr, usu_nombre+' '+usu_ap AS Usuario " +
            "FROM TMPFICHETIQ INNER JOIN clientes ON cli_rut=ETIQ_CLIRUT INNER JOIN contrato  ON cont_codi=ETIQ_CODCONT INNER JOIN USUARIOS ON " +
            "usu_codigo=ETIQ_CODENCA WHERE ETIQ_CODI='" + codigo_TMP + "'"

        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

        If tabla.Rows.Count > 0 Then

            Txtfolio.Text = tabla.Rows(0)(0).ToString()
            Txtfolio.Enabled = False

            TxtClirut.Text = tabla.Rows(0)(1).ToString()
            txtclinom.Text = tabla.Rows(0)(2).ToString()
            btn_BuscaCliente.Enabled = False
            TxtClirut.Enabled = False

            txtcodcontrato.Text = tabla.Rows(0)(3).ToString()
            txtcontnom.Text = tabla.Rows(0)(4).ToString()
            txtcodcontrato.Enabled = False
            Btn_BuscaContrato.Enabled = False

            Txtresp.Text = tabla.Rows(0)(5).ToString()
            carga_grilla()
            TimerAdicionales.Start()
            BtnBuscar.Enabled = False
            BtnImprimir.Enabled = False
            btn_guardar.Enabled = True
            BtnLectura.Enabled = True
            DgvEtiquetado.Enabled = True
        End If

    End Sub

    Sub carga_grilla()
        Dim sql As String = "SELECT Convert(datetime,ETIQ_FECPROD) AS ETIQ_FECPROD, ETIQ_FECVENC, ETIQ_SOPOPRE, isnull(ETIQ_NSOPOCLI,ETIQ_SOPOCLI) AS ETIQ_SOPOCLI1, " +
            "ETIQ_CODPRO, MAE_DESCR, ETIQ_CAJAS, ETIQ_KILOS, ETIQ_SOPOCLI " +
            "FROM TMPDETAETIQ, MAEPROD WHERE MAE_CODI=ETIQ_CODPRO AND ETIQ_CODI='" + Txtfolio.Text + "'"


        DgvEtiquetado.DataSource = fnc.ListarTablasSQL(sql)

        Dim sql_totales = "SELECT COUNT(*), ISNULL(SUM(ETIQ_CAJAS),0), ISNULL(SUM(ETIQ_KILOS),0) from TMPDETAETIQ where ETIQ_CODI='" + Txtfolio.Text + "'"
        Dim tabla As DataTable = fnc.ListarTablasSQL(sql_totales)
        txtpallets.Text = tabla.Rows(0)(0).ToString()
        txtcajas.Text = tabla.Rows(0)(1).ToString()
        txtkilos.Text = tabla.Rows(0)(2).ToString()
    End Sub

    Private Sub CBREPA_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBREPA.CheckedChanged
        If CBREPA.Checked = True Then
            txtrepa.Visible = True
        Else
            txtrepa.Visible = False
        End If
    End Sub

    Private Sub TimerAdicionales_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerAdicionales.Tick

        activa_desactiva(0, True)

        If CBIMPRESION.Checked = True Then
            activa_desactiva(1, True)
        Else
            activa_desactiva(1, False)
        End If

        If RBETIQESPEC.Checked = True Then
            activa_desactiva(2, True)
            activa_desactiva(3, False)
        Else
            activa_desactiva(2, False)
            activa_desactiva(3, True)
        End If

        If CBRETIROETIQ.Checked = True Then
            activa_desactiva(4, True)
        Else
            activa_desactiva(4, False)
        End If

        If CBMOVEXT.Checked = True Then
            activa_desactiva(5, True)
        Else
            activa_desactiva(5, False)
        End If

        If CBREPA.Checked = True AndAlso IsNumeric(txtrepa.Text) Then
            DataAdicionales.Rows(6).Cells("cb").Value = True
            DataAdicionales.Rows(6).Cells("un").Value = txtrepa.Text
            DataAdicionales.Rows(6).Cells("ca").Value = "0"
            DataAdicionales.Rows(6).Cells("ki").Value = "0"
        Else
            DataAdicionales.Rows(6).Cells("cb").Value = False
            DataAdicionales.Rows(6).Cells("un").Value = "0"
            DataAdicionales.Rows(6).Cells("ca").Value = "0"
            DataAdicionales.Rows(6).Cells("ki").Value = "0"
        End If

    End Sub

    Sub activa_desactiva(ByVal i As Integer, ByVal true_false As Boolean)
        If true_false = True Then
            DataAdicionales.Rows(i).Cells("cb").Value = True
            DataAdicionales.Rows(i).Cells("un").Value = txtpallets.Text
            DataAdicionales.Rows(i).Cells("ca").Value = txtcajas.Text
            DataAdicionales.Rows(i).Cells("ki").Value = txtkilos.Text
        Else
            DataAdicionales.Rows(i).Cells("cb").Value = False
            DataAdicionales.Rows(i).Cells("un").Value = "0"
            DataAdicionales.Rows(i).Cells("ca").Value = "0"
            DataAdicionales.Rows(i).Cells("ki").Value = "0"
        End If
    End Sub

    Private Sub txtrepa_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtrepa.KeyPress
        SoloNumeros(sender, e)
    End Sub

    Public Sub Frm_Etiquetado_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If Txtfolio.Text <> "" AndAlso Txtfolio.Enabled = False Then
            If fnc.verificaExistencia("FICHETIQ", "ETIQ_CODI", Txtfolio.Text) = False Then
                If MsgBox("Esta seguro de salir sin guardar la información", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbNo Then
                    e.Cancel = True
                Else
                    CancelaCorrelativo("014", Txtfolio.Text)
                    f_etiquetado = False
                    Dim SQL_ELIM_FICH As String = "DELETE  FROM TMPFICHETIQ WHERE ETIQ_CODI='" + Txtfolio.Text + "'"
                    fnc.MovimientoSQL(SQL_ELIM_FICH)

                    Dim SQL_ELIM_DETA As String = "DELETE FROM TMPDETAETIQ WHERE ETIQ_CODI='" + Txtfolio.Text + "'"
                    fnc.MovimientoSQL(SQL_ELIM_DETA)
                    TimerAdicionales.Stop()
                End If
            Else
                f_etiquetado = False
            End If
        Else
            f_etiquetado = False
        End If
    End Sub

    Private Sub btn_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        If Txtfolio.Text <> "" Then
            If fnc.verificaExistencia("FICHETIQ", "ETIQ_CODI", Txtfolio.Text) = False Then
                If Txtfolio.Enabled = False Then
                    If MsgBox("Desea salir del ingreso", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbYes Then
                        CancelaCorrelativo("014", Txtfolio.Text)
                        Dim SQL_ELIM_FICH As String = "DELETE  FROM TMPFICHETIQ WHERE ETIQ_CODI='" + Txtfolio.Text + "'"
                        fnc.MovimientoSQL(SQL_ELIM_FICH)

                        Dim SQL_ELIM_DETA As String = "DELETE FROM TMPDETAETIQ WHERE ETIQ_CODI='" + Txtfolio.Text + "'"
                        fnc.MovimientoSQL(SQL_ELIM_DETA)
                        limpiarFormulario()
                    End If
                Else
                    limpiarFormulario()
                End If
            Else
                limpiarFormulario()
            End If
        Else
            Txtfolio.Focus()
        End If
    End Sub

    Sub limpiarFormulario()
        Txtfolio.Text = ""
        Txtfolio.Enabled = True

        TxtClirut.Text = ""
        txtclinom.Text = ""
        TxtClirut.Enabled = True
        btn_BuscaCliente.Enabled = True

        Dtfecha.Value = fnc.DevuelveFechaServidor()
        txthorini.Text = "0000"
        TxtHorter.Text = "0000"

        txtcodcontrato.Enabled = False
        txtcodcontrato.Text = ""
        Btn_BuscaContrato.Enabled = False
        txtcontnom.Text = ""

        Txtresp.Text = Frm_Principal.lblnombre.Text

        For i As Integer = 0 To DgvEtiquetado.RowCount - 1
            DgvEtiquetado.Rows.RemoveAt(0)
        Next

        'DataAdicionales.DataSource = fnc.ListarTablasSQL("SELECT 'False' AS  Serv_Cod, Serv_Nom, '0' AS Dvas_Unid,'0' AS dvas_cajas,'0' AS dvas_kilos " +
        '                                                "FROM FacServicios WHERE ISNULL(serv_orde,0)>0 ORDER BY serv_orde ASC")
        CBIMPRESION.Checked = False
        CBMOVEXT.Checked = False
        CBREPA.Checked = False
        txtrepa.Text = "0"
        CBRETIROETIQ.Checked = False
        TimerAdicionales.Stop()
        BtnBuscar.Enabled = True
        BtnImprimir.Enabled = True
        btn_guardar.Enabled = False
        BtnLectura.Enabled = False
        BtnLectura.ForeColor = Color.Black
        BtnLectura.Text = "HABILITAR LECTURA POR R.F."
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        If validacion() = True Then
            If MsgBox("Seguro de finalizar el proceso", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbYes Then

                If fnc.verificaExistencia("FICHETIQ", "ETIQ_CODI", Txtfolio.Text) = False Then

                    Dim sql As String = "INSERT INTO fichetiq(ETIQ_CODI, ETIQ_CLIRUT, ETIQ_CODCONT, ETIQ_FECHA, ETIQ_HORINI, " +
                                        "ETIQ_CODENCA, ETIQ_EST, ETIQ_HORTER, ETIQ_TOTSOPO, ETIQ_TOTUNIDAD, ETIQ_TOTPESO)" +
                                        "VALUES('" + Txtfolio.Text + "','" + TxtClirut.Text + "','" + txtcodcontrato.Text + "','" + devuelve_fecha(Dtfecha.Value) + "'," +
                                        "'" + txthorini.Text + "','" + Frm_Principal.InfoUsuario.Text + "','0','" + DevuelveHora() + "','" + txtpallets.Text + "'," +
                                        "'" + txtcajas.Text + "','" + txtkilos.Text.Replace(",", ".") + "')"

                    If fnc.MovimientoSQL(sql) > 0 Then
                        MsgBox("información agregada correctamente", MsgBoxStyle.Information, "Aviso")

                        For i As Integer = 0 To DgvEtiquetado.RowCount - 1

                            Dim sql_detalle As String = "INSERT INTO  DETAETIQ(ETIQ_CODI, ETIQ_DCOD, ETIQ_SOPOPRE, ETIQ_SOPOCLI, ETIQ_CODPRO, " +
                                                        "ETIQ_CAJAS, ETIQ_KILOS, ETIQ_SOPOCLIANT)VALUES(" +
                                                        "'" + Txtfolio.Text + "','" + CerosAnteriorString((i + 1), 2) + "','" + DgvEtiquetado.Rows(i).Cells("SP").Value.ToString() + "'," +
                                                        "'" + DgvEtiquetado.Rows(i).Cells("SC").Value.ToString() + "','" + DgvEtiquetado.Rows(i).Cells("CPROD").Value.ToString() + "'," +
                                                        "'" + DgvEtiquetado.Rows(i).Cells("cjs").Value.ToString() + "','" + DgvEtiquetado.Rows(i).Cells("peso").Value.ToString.Replace(",", ".") + "'," +
                                                        "'" + DgvEtiquetado.Rows(i).Cells("COD_ANT").Value.ToString() + "')"

                            fnc.MovimientoSQL(sql_detalle)

                            'Actualiza mov_pallet
                            Dim sql_movpallet As String = "INSERT INTO movpallet (mov_folio, mov_codper, mov_fecha, mov_tipo, mov_hora, mov_doc)" +
                                "VALUES('" + DgvEtiquetado.Rows(i).Cells("SP").Value.ToString() + "','" + Frm_Principal.InfoUsuario.Text + "'," +
                                "'" + devuelve_fecha(fnc.DevuelveFechaServidor()) + "', 'ET','" + DevuelveHora() + "','" + Txtfolio.Text + "')"
                            fnc.MovimientoSQL(sql_movpallet)
                            'Actualiza detarece

                            Dim SQL_DETARECE As String = "UPDATE DETARECE SET drec_sopocli='" + DgvEtiquetado.Rows(i).Cells("SC").Value.ToString() + "', " +
                                                         "drec_codpro='" + DgvEtiquetado.Rows(i).Cells("CPROD").Value.ToString() + "', " +
                                                         "drec_fecprod='" + devuelve_fecha(DgvEtiquetado.Rows(i).Cells("FP").Value.ToString()) + "'," +
                                                         "fechavencimiento='" + devuelve_fecha_Formato2(DgvEtiquetado.Rows(i).Cells("FV").Value.ToString()) + "' " +
                                                         "WHERE drec_codi='" + DgvEtiquetado.Rows(i).Cells("SP").Value.ToString() + "'"

                            fnc.MovimientoSQL(SQL_DETARECE)



                            Dim SQL_RACKDETA As String = "UPDATE RACKDETA SET racd_codpro='" + DgvEtiquetado.Rows(i).Cells("CPROD").Value.ToString() + "', " +
                                                         "racd_fecpro='" + devuelve_fecha(DgvEtiquetado.Rows(i).Cells("FP").Value.ToString()) + "'," +
                                                         "fechavencimiento='" + devuelve_fecha_Formato2(DgvEtiquetado.Rows(i).Cells("FV").Value.ToString()) + "' " +
                                                         "WHERE racd_codi='" + DgvEtiquetado.Rows(i).Cells("SP").Value.ToString() + "'"

                            fnc.MovimientoSQL(SQL_RACKDETA)


                        Next

                        guardaVasAutomatico()

                        'ELIMINAR TEMPORALES DE ETIQUETADO

                        Dim SQL_ELIM_FICH As String = "DELETE  FROM TMPFICHETIQ WHERE ETIQ_CODI='" + Txtfolio.Text + "'"
                        fnc.MovimientoSQL(SQL_ELIM_FICH)

                        Dim SQL_ELIM_DETA As String = "DELETE FROM TMPDETAETIQ WHERE ETIQ_CODI='" + Txtfolio.Text + "'"
                        fnc.MovimientoSQL(SQL_ELIM_DETA)

                        TimerAdicionales.Stop()
                        BtnImprimir.Enabled = True
                    Else
                        MsgBox("Error al ingresar la información al sistema", MsgBoxStyle.Critical, "Aviso")
                    End If
                Else
                    'MODIFICAR ETIQUETADO


                End If
            End If
        End If

    End Sub

    Function validacion() As Boolean
        validacion = True
        Dim Mensaje As String = ""

        If DgvEtiquetado.RowCount = 0 Then
            validacion = False
            Mensaje = "- Debe ingresar un detalle de etiquetado"
        End If

        If IsNumeric(txtrepa.Text) Then
            If Val(txtrepa.Text) > txtpallets.Text Then
                validacion = False
                Mensaje = "- La cantidad de repaletizado es mayor al total de soportantes"
            End If
        End If


        If Mensaje.Length > 0 Then
            MsgBox(Mensaje, MsgBoxStyle.Critical, "Aviso")
        End If

        Return validacion
    End Function

    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        Dim f As New Frm_EtiquetadoListado
        f.ShowDialog(Frm_Principal)
        If Frm_Principal.buscavalor.ToString() <> "" Then
            RescataProceso(Frm_Principal.buscavalor.ToString())
        End If
    End Sub

    Sub guardaVasAutomatico()
        Dim cantidad As Integer = DataAdicionales.Rows.Count - 1

        If cantidad > 0 Then
            If fnc.verificaExistenciaCondicional("FacVas", "Vas_Dcto='" + Txtfolio.Text + "' AND Vas_TipDoc='2' ") = False Then

                Dim CODIGO_VAS As String = BuscaCorrelativo("012", 6)

                Dim sql As String = "INSERT INTO facvas(Vas_cod, vas_clirut, vas_cont, vas_dcto, vas_fecha, vas_estado, vas_seccion, vas_tipdoc, vas_guia)" +
                                    "VALUES('" + CODIGO_VAS + "','" + TxtClirut.Text + "','" + txtcodcontrato.Text + "','" + Txtfolio.Text + "'," +
                                    "'" + devuelve_fecha(Dtfecha.Value) + "','0','0','2','0')"

                If fnc.MovimientoSQL(sql) > 0 Then
                    For i As Integer = 0 To DataAdicionales.Rows.Count - 1

                        Dim true_false As Boolean = False

                        Dim Unidad1 As String = "0"
                        Dim Unidad2 As String = "0"
                        Dim Unidad3 As String = "0"

                        If Not IsNothing(DataAdicionales.Rows(i).Cells("un").Value) Then
                            Unidad1 = DataAdicionales.Rows(i).Cells("un").Value.ToString()
                        End If

                        If Not IsNothing(DataAdicionales.Rows(i).Cells("ca").Value) Then
                            Unidad2 = DataAdicionales.Rows(i).Cells("ca").Value.ToString()
                        End If

                        If Not IsNothing(DataAdicionales.Rows(i).Cells("ki").Value) Then
                            Unidad3 = DataAdicionales.Rows(i).Cells("ki").Value.ToString().Replace(",", ".")
                        End If
                        If Not IsNothing(DataAdicionales.Rows(i).Cells("cb").Value) Then
                            true_false = DataAdicionales.Rows(i).Cells("cb").Value.ToString()
                        End If


                        Dim sqlDetalle As String = "INSERT INTO facVasDeta(Dvas_VasCod, dvas_est, Dvas_ServCod, Dvas_Unid, Dvas_Cajas, Dvas_Kilos, Dvas_cobrar)" +
                                                   "VALUES('" + CODIGO_VAS + "','" + true_false.ToString() + "','" + DataAdicionales.Rows(i).Cells("se").Value.ToString() + "'," +
                                                   "'" + Unidad1.ToString() + "','" + Unidad2.ToString() + "','" + Unidad3.ToString() + "','0')"

                        fnc.MovimientoSQL(sqlDetalle)

                    Next

                End If
            Else
                Dim CODIGO_VAS As String = ""

                Dim Consulta_Numero_Vas As String = "SELECT  Vas_cod  FROM    FacVas WHERE Vas_Dcto='" + Txtfolio.Text + "' AND Vas_TipDoc='2'"
                Dim tabla As DataTable = fnc.ListarTablasSQL(Consulta_Numero_Vas)

                If tabla.Rows.Count > 0 Then
                    CODIGO_VAS = tabla.Rows(0)(0).ToString()
                Else
                    CODIGO_VAS = BuscaCorrelativo("012", 6)
                End If

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
                        Unidad3 = DataAdicionales.Rows(i).Cells("ki").Value.ToString.Replace(",", ".")
                    End If

                    If Not IsNothing(DataAdicionales.Rows(i).Cells("cb").Value) Then
                        true_false = DataAdicionales.Rows(i).Cells("cb").Value.ToString()
                    End If

                    Dim sqlDetalle As String = "INSERT INTO facVasDeta(Dvas_VasCod, dvas_est, Dvas_ServCod, Dvas_Unid, Dvas_Cajas, Dvas_Kilos, Dvas_cobrar)" +
                                               "VALUES('" + CODIGO_VAS + "','" + true_false.ToString() + "','" + DataAdicionales.Rows(i).Cells("se").Value.ToString() + "'," +
                                               "'" + Unidad1.ToString() + "','" + Unidad2.ToString() + "','" + Unidad3.ToString() + "','0')"

                    fnc.MovimientoSQL(sqlDetalle)
                Next
            End If
        End If

    End Sub

    Private Sub BtnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImprimir.Click
        If Txtfolio.Text = "" Then
            MsgBox("Debe guardar el formulario antes de imprimirlo", MsgBoxStyle.Critical, "Aviso")
        Else

            Dim frm As Frm_MuestraReporte = New Frm_MuestraReporte
            frm.Text = "Asistente de informes - Informe de etiquetado"

            Dim report As New Rpt_Etiquetado

            report.SetDatabaseLogon(Usuario_ODBC, Pass_ODBC)
            report.SetParameterValue("codigo", Txtfolio.Text)

            frm.Contenedor.ReportSource = report
            frm.ShowDialog()

        End If
    End Sub

End Class
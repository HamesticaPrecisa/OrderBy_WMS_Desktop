Imports CrystalDecisions.Shared

Public Class Frm_Trazabilidad

    Dim fnc As New Funciones

    Dim CODIGO_DE_SOPORTANTE As String = ""

    Sub BuscaSoportanteCliente(ByVal soportante_cliente As String, ByVal tipo_sopo As Integer)
        'tipo_sopo 
        '0-Busca Soportante Precisa
        '1-Busca Soportante Cliente
        Dim sql As String = ""
        If tipo_sopo = 0 Then

            Dim sqls1 As String = "	select drec_temp from detarece where drec_codi='" + soportante_cliente.Trim + "' "
            Dim tablatem As DataTable = fnc.ListarTablasSQL(sqls1)
            If tablatem.Rows.Count > 0 Then

                If tablatem.Rows(0)(0).ToString() = "0" Then

                    '             sql = "Select mov_fecha, mov_hora, mov_doc, descri, mov_tipo, CONVERT(INTEGER,mov_despacho)  mov_despacho, " +
                    '"CONVERT(INTEGER, mov_saldo ) mov_saldo,   (select frec_temppro from fichrece where frec_codi ='" + soportante_cliente.Substring(0, 7) + "' AND mov_tipo='EN') as mov_TS , mov_ca, mov_ba, mov_co, mov_pi, mov_ni " +
                    '"FROM movpallet, usuarios WHERE convert(integer,mov_codper)=convert(integer,personal) AND mov_folio='" + soportante_cliente.Trim + "' " +
                    '"ORDER BY mov_fecha, mov_hora ASC"

                    sql = "select a.mov_fecha,a.mov_hora,a.mov_doc,b.descri,a.mov_tipo,mov_despacho=CONVERT(INTEGER,a.mov_despacho),mov_saldo=CONVERT(INTEGER,a.mov_saldo),mov_TS=(select frec_temppro from fichrece where frec_codi ='" + soportante_cliente.Substring(0, 7) + "'),Nombre_Camara=c.NCamara,a.mov_ca,a.mov_ba,a.mov_co,a.mov_pi,a.mov_ni from movpallet a with(nolock) inner join usuarios b with(nolock) on(convert(integer,a.mov_codper)=convert(integer,b.personal)) left outer join CamaraConf c with(nolock) on(a.mov_ca=c.Camara) where a.mov_folio='" + soportante_cliente.Trim + "' order by convert(date,a.mov_fecha),a.mov_hora asc"


                Else
                    '    sql = "Select mov_fecha, mov_hora, mov_doc, descri, mov_tipo, CONVERT(INTEGER,mov_despacho)  mov_despacho, " +
                    '"CONVERT(INTEGER, mov_saldo ) mov_saldo, (select drec_temp from detarece where drec_codi='" + soportante_cliente.Trim + "' AND mov_tipo='EN' ) as mov_TS, mov_ca, mov_ba, mov_co, mov_pi, mov_ni " +
                    '"FROM movpallet, usuarios WHERE convert(integer,mov_codper)=convert(integer,personal) AND mov_folio='" + soportante_cliente.Trim + "' " +
                    '"ORDER BY mov_fecha, mov_hora ASC"

                    sql = "select a.mov_fecha,a.mov_hora,a.mov_doc,b.descri,a.mov_tipo,mov_despacho=CONVERT(INTEGER,a.mov_despacho),mov_saldo=CONVERT(INTEGER,a.mov_saldo),mov_TS=(select drec_temp from detarece where drec_codi='" + soportante_cliente.Trim + "'),Nombre_Camara=c.NCamara,a.mov_ca,a.mov_ba,a.mov_co,a.mov_pi,a.mov_ni from movpallet a with(nolock) inner join usuarios b with(nolock) on(convert(integer,a.mov_codper)=convert(integer,b.personal)) left outer join CamaraConf c with(nolock) on(a.mov_ca=c.Camara) where a.mov_folio='" + soportante_cliente.Trim + "' order by convert(date,a.mov_fecha),a.mov_hora asc"

                End If



           

            End If


            ' Dim sql As String = "Select mov_fecha, mov_hora, mov_doc, descri, mov_tipo, CONVERT(INTEGER,mov_despacho)  mov_despacho, " +
            '       "CONVERT(INTEGER, mov_saldo ) mov_saldo, mov_TS, mov_ca, mov_ba, mov_co, mov_pi, mov_ni " +
            '      "FROM movpallet, usuarios WHERE convert(integer,mov_codper)=convert(integer,personal) AND mov_folio='" + soportante_cliente.Trim + "' " +
            '      "ORDER BY mov_fecha, mov_hora ASC"


            DataGridView1.DataSource = fnc.ListarTablasSQL(sql)

            If DataGridView1.Rows.Count = 0 Then
                btn_nuevo_Click(Nothing, Nothing)
                MsgBox("El numero de pallet ingresado no existe", MsgBoxStyle.Critical, "Aviso")
            End If

        ElseIf tipo_sopo = 1 Then

            Dim sopo As String = "Select drec_codi FROM detarece WHERE  drec_sopocli='" + soportante_cliente.Trim + "' AND drec_rutcli='" + TxtClirut.Text + "'"
            Dim tabla As DataTable = fnc.ListarTablasSQL(sopo)
            If tabla.Rows.Count > 0 Then
                btn_nuevo_Click(Nothing, Nothing)
                TxtSopoPrecisa.Text = tabla.Rows(0)(0).ToString()
            End If

            'sql = "Select mov_fecha, mov_hora, mov_doc, descri, mov_tipo, CONVERT(INTEGER,mov_despacho)  mov_despacho, " +
            '    "CONVERT(INTEGER, mov_saldo ) mov_saldo, mov_TS, mov_ca, mov_ba, mov_co, mov_pi, mov_ni " +
            '    "FROM movpallet, usuarios, detarece WHERE convert(integer,mov_codper)=convert(integer,personal)  AND drec_codi=mov_folio AND " +
            '    "drec_sopocli='" + soportante_cliente.Trim + "' AND drec_rutcli='" + TxtClirut.Text + "' ORDER BY mov_fecha, mov_hora ASC"

            sql = "select a.mov_fecha, a.mov_hora, a.mov_Doc, b.descri, a.mov_tipo,mov_Despacho = Convert(Int, a.Mov_Despacho),mov_saldo = Convert(Int, a.Mov_Saldo), a.mov_TS,Nombre_Camara = d.NCamara, a.mov_ca,a.mov_ba, a.mov_co, a.mov_pi, a.mov_ni from movpallet a with(nolock) inner join usuarios b with(nolock) on(convert(integer,a.mov_codper)=convert(integer,b.personal)) inner join detarece c with(nolock) on(a.mov_folio=c.drec_codi) left outer join CamaraConf d with(nolock) on(a.mov_ca=d.Camara) where c.drec_sopocli='" + soportante_cliente.Trim + "' and c.drec_rutcli='" + TxtClirut.Text + "' order by convert(date,a.mov_fecha),mov_hora asc"

            DataGridView1.DataSource = fnc.ListarTablasSQL(sql)

            If DataGridView1.Rows.Count = 0 Then
                btn_nuevo_Click(Nothing, Nothing)
                MsgBox("El numero de pallet ingresado no existe", MsgBoxStyle.Critical, "Aviso")

            End If

        End If

        If DataGridView1.Rows.Count > 0 Then
            TxtSopoPrecisa.Enabled = False
            TxtSopoCliente.Enabled = False
            btn_nuevo.Focus()
        End If

    End Sub

    Private Sub TxtClirut_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtClirut.KeyPress
        If e.KeyChar = ChrW(13) Then
            If TxtClirut.Text.Length >= 9 Then
                txtclinom.Text = RetornaCliente(TxtClirut.Text)
                TxtClirut.Enabled = False
            Else
                MsgBox("El rut ingresado no existe", MsgBoxStyle.Critical, "Aviso")
            End If
        End If
    End Sub

    Private Sub btn_BuscaCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_BuscaCliente.Click
        Dim frm As New Lst_AyudaClientes
        frm.ShowDialog(Frm_Principal)
        If Len(Frm_Principal.buscavalor) >= 9 Then
            TxtClirut.Text = Frm_Principal.buscavalor
            txtclinom.Text = RetornaCliente(Frm_Principal.buscavalor)
            TxtClirut.Enabled = False
        End If
        Frm_Principal.buscavalor = ""
    End Sub

    Private Sub BtnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImprimir.Click

        If fnc.verificaExistencia("detarece", "drec_codi", CerosAnteriorString(TxtSopoPrecisa.Text, 9)) Then
            documentoimp = DateTime.Now.ToString("MM-dd-yy") + "Trazabilidad"
            Dim frm As Frm_MuestraReporte = New Frm_MuestraReporte
            frm.Text = "Asistente de informes - Informe de trazabilidad"

            Dim report As New Rpt_TrababilidadPallet

            report.SetDatabaseLogon(Usuario_ODBC, Pass_ODBC)
            report.SetParameterValue("codigo", CerosAnteriorString(TxtSopoPrecisa.Text, 9))

            frm.Contenedor.ReportSource = report
            frm.ShowDialog()
        Else
            MsgBox("El N° ingresado no existe", MsgBoxStyle.Critical, "Aviso")
        End If

    End Sub

    Private Sub TxtSopoPrecisa_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtSopoPrecisa.KeyPress
        If e.KeyChar = ChrW(13) Then
            If TxtSopoPrecisa.Text = "" Then
                MsgBox("Ingrese un N° de soportante", MsgBoxStyle.Critical, "Aviso")

            ElseIf fnc.verificaExistencia("movpallet", "mov_folio", CerosAnteriorString(TxtSopoPrecisa.Text, 9)) = False Then


                MsgBox("El numero de soportante ingresado no existe", MsgBoxStyle.Critical, "Aviso")
            Else

                Dim sql As String = "SELECT cod_bod from detarece where drec_codi='" + CerosAnteriorString(TxtSopoPrecisa.Text, 9) + "' "
                Dim tabla As DataTable = fnc.ListarTablasSQL(sql)



                If tabla.Rows.Count > 0 Then

                    '  CODIGOBOD = 
                    If sucursalglo = tabla.Rows(0)(0).ToString().Trim() Then
                        TxtSopoPrecisa.Text = CerosAnteriorString(TxtSopoPrecisa.Text, 9)
                        BuscaSoportanteCliente(CerosAnteriorString(TxtSopoPrecisa.Text, 9), 0)
                        validarestado()
                    Else


                        MsgBox("El numero de soportante ingresado no pertenece a esta bodega ", MsgBoxStyle.Critical, "Aviso")

                    End If




                End If
            End If
        End If
    End Sub
    Private Sub validarestado()


        Dim sopo As String = "select drec_codvig from detarece where drec_codvig='0' and drec_codi='" + TxtSopoPrecisa.Text + "' "
        Dim tabla As DataTable = fnc.ListarTablasSQL(sopo)
        If tabla.Rows.Count > 0 Then
            Lbl_EstadoGuia.Text = "ACTIVO"
            Lbl_EstadoGuia.ForeColor = Color.Blue
        Else
            Lbl_EstadoGuia.Text = "NULO"
            Lbl_EstadoGuia.ForeColor = Color.Red
        End If


    End Sub
 
    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click

        If RbPrecisa.Checked = True Then
            If TxtSopoPrecisa.Text = "" Then
                MsgBox("Ingrese un N° de soportante", MsgBoxStyle.Critical, "Aviso")



            ElseIf fnc.verificaExistencia("movpallet", "mov_folio", TxtSopoPrecisa.Text) = False Then



                MsgBox("El numero de soportante ingresado no existe", MsgBoxStyle.Critical, "Aviso")
            Else


                BuscaSoportanteCliente(TxtSopoCliente.Text, 0)
            End If
        ElseIf RbSoportante.Checked = True Then
            If TxtSopoCliente.Text = "" Then
                MsgBox("Ingrese un N° de soportante", MsgBoxStyle.Critical, "Aviso")
            ElseIf fnc.verificaExistencia("Clientes", "Cli_rut", TxtClirut.Text) = False Then
                MsgBox("Ingrese un cliente", MsgBoxStyle.Critical, "Aviso")
            Else
                BuscaSoportanteCliente(TxtSopoCliente.Text, 1)
            End If
        End If

    End Sub

    Private Sub btn_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click, TxtSopoPrecisa.Click
        TxtSopoPrecisa.Text = ""
        TxtSopoCliente.Text = ""
        TxtSopoPrecisa.Enabled = True
        TxtSopoCliente.Enabled = True
        Lbl_EstadoGuia.Text = "ACTIVO"
        Lbl_EstadoGuia.ForeColor = Color.Blue
        If RbPrecisa.Checked = True Then
            TxtSopoPrecisa.Focus()
        Else
            TxtSopoCliente.Focus()
        End If

        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            DataGridView1.Rows.RemoveAt(0)
        Next

    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub Frm_Trazabilidad_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        f_trazabilidad = False
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim f As New TrazabilidadCaja
        f.ShowDialog()
    End Sub

    Private Sub TxtSopoCliente_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtSopoCliente.KeyPress
        If e.KeyChar = ChrW(13) Then
            If TxtSopoCliente.Text <> "" AndAlso TxtClirut.Text <> "" Then
                BtnBuscar.Focus()
            Else
                btn_BuscaCliente.Focus()
            End If
        End If
    End Sub

    Private Sub TxtSopoPrecisa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        RbPrecisa.Checked = True
    End Sub

    Private Sub TxtSopoCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtSopoCliente.Click
        RbSoportante.Checked = True
    End Sub

    Private Sub Frm_Trazabilidad_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Frm_Principal.buscavalor = ""
    End Sub

    Private Sub TxtSopoPrecisa_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtSopoPrecisa.TextChanged

    End Sub
    Private Sub llenarcliente()

        Dim SqlCaja As String = "SELECT rut_cli,nombre_cli from vg_ayudasopcli where sop_cli='" + TxtSopoCliente.Text + "' "
        Dim tabla As DataTable = fnc.ListarTablasSQL(SqlCaja)
        If tabla.Rows.Count > 0 Then
            TxtClirut.Text = tabla.Rows(0)(0).ToString()
            txtclinom.Text = tabla.Rows(0)(1).ToString()
        End If
    End Sub
    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Dim frm As New Lst_AyudaSopCli
        frm.ShowDialog(Frm_Principal)
        If Len(Frm_Principal.buscavalor) >= 9 Then
            TxtSopoCliente.Text = Frm_Principal.buscavalor
            llenarcliente()

        End If
        Frm_Principal.buscavalor = ""
    End Sub
End Class
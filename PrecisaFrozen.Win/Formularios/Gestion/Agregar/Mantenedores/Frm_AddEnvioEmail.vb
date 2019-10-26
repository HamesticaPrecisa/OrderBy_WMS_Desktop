Imports System.Drawing.Color

Public Class Frm_AddEnvioEmail
    Inherits System.Windows.Forms.Form
    Public RutCliente As String = ""
    Public codigoInforme As String = "0"
    Public Lu, Ma, Mi, Ju, Vi, Sa, Dom As String
    Public CHEC As String = ""
    Dim fnc As New Funciones
    Private _vem1 As Integer = -1


    Private Sub Btn_BuscaCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_BuscaCliente.Click
        CHEC = "0"
        Dim frm As New Lst_AyudaClientes
        frm.cliente = "SI"
        frm.ShowDialog(Frm_Principal)
        If Frm_Principal.buscavalor <> "" Then
            Me.txtrut.Text = Frm_Principal.buscavalor
            BUSCA_CLIENTE(Frm_Principal.buscavalor)
            Frm_Principal.buscavalor = ""
        End If
    End Sub

    Sub BUSCA_CLIENTE(ByVal rut_completo)

        Btn_Nuevo.PerformClick()

        Dim sqlBuscaCliente = "SELECT cli_rut, cli_nomb, cli_rubro FROM Clientes WHERE cli_rut='" + rut_completo + "'"

        Dim tabla As DataTable = fnc.ListarTablasSQL(sqlBuscaCliente)
        If tabla.Rows.Count > 0 Then

            txtrut.Text = tabla.Rows(0)(0).ToString()
            RutCliente = tabla.Rows(0)(0).ToString()
            txtrsocial.Text = tabla.Rows(0)(1).ToString()
            txtgiro.Text = tabla.Rows(0)(2).ToString()




            btn_agregarmail.Enabled = True
            btn_quitarmail.Enabled = True
            _em1.Enabled = True
            Btn_Guardar.Enabled = True
            txtrut.Enabled = False
            GroupBox3.Enabled = True
            btn_informes.Enabled = False
            btn_imagenes.Enabled = True
        Else
            If RutDigito(txtrut.Text.ToUpper()) = True Then
                If RealizarAccion("004", "008") = False Then
                    Exit Sub
                End If
                txtrut.Enabled = False
                GroupBox3.Enabled = True
                Btn_Guardar.Enabled = True
            Else
                MsgBox("El R.U.T ingresado no es valido", MsgBoxStyle.Critical, "Aviso")
            End If
        End If

        llenarCombo("Externo")
        cargarItems()
    End Sub

    Sub llenarCombo(ByVal tipo As String)
        cboinformes.DataSource = Nothing
        Dim sqlInformes = "SELECT inf_cod, inf_nom FROM informes WHERE inf_emp ='" + tipo + "' AND inf_est ='Habilitado'"
        cboinformes.DataSource = fnc.ListarTablasSQL(sqlInformes)
        cboinformes.ValueMember = "inf_cod"
        cboinformes.DisplayMember = "inf_nom"
        cboinformes.Enabled = True
        btn_informes.Enabled = False


        If tipo <> "Externo" Then
            chktodos.Enabled = True
            chklunes.Enabled = True
            chkmartes.Enabled = True
            chkmiercoles.Enabled = True
            chkjueves.Enabled = True
            chkviernes.Enabled = True
            chksabado.Enabled = True
            chkdomingo.Enabled = True
            txthora.Enabled = True
        End If

    End Sub

    Public Sub LlamarCorreos(ByVal correos As String, ByVal dgv As DataGridView, Optional ByVal isemail As Boolean = True, Optional ByVal _char As String = ";")

        If correos.Length > 0 Then
            If isemail = True Then
                correos = correos.ToLower()
            End If

            Dim _corr() = correos.Split(Convert.ToChar(_char))

            For i As Integer = 0 To _corr.Length - 1
                dgv.Rows.Add(_corr(i))
            Next

        End If

    End Sub

    Public Function RetornaCorreos(ByVal dgv As DataGridView, Optional ByVal _char As String = ";") As String

        Dim _corr As String = ""

        If dgv.Rows.Count > 0 Then

            For i As Integer = 0 To dgv.Rows.Count - 1
                _corr += dgv.Rows(i).Cells(0).Value + _char
            Next
            _corr = _corr.Remove(_corr.Length - 1, 1)
        End If
        Return _corr
    End Function

    Private Sub Btn_Nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Nuevo.Click
        txtgiro.Text = ""
        txtrsocial.Text = ""
        txtrut.Text = ""
        txthora.Text = ""
        cboinformes.Enabled = False
        cboinformes.Text = ""
        txthora.Enabled = False
        chktodos.Checked = False
        chklunes.Checked = False
        chkmartes.Checked = False
        chkmiercoles.Checked = False
        chkjueves.Checked = False
        chkviernes.Checked = False
        chksabado.Checked = False
        chkdomingo.Checked = False
        chktodos.Enabled = False
        chklunes.Enabled = False
        chkmartes.Enabled = False
        chkmiercoles.Enabled = False
        chkjueves.Enabled = False
        chkviernes.Enabled = False
        chksabado.Enabled = False
        chkdomingo.Enabled = False
        chkinterno.Checked = False
        rdiactivado.Enabled = False
        rdidesactivado.Enabled = False
        rdiactivado.Checked = False
        rdidesactivado.Checked = False
        dtgcorreos.DataSource = ""
        dtgcorreos.DataSource = Nothing
        btn_agregarmail.Enabled = False
        btn_quitarmail.Enabled = False
        _em1.Enabled = False
        _em1.Text = ""
        btn_informes.Enabled = True
        btn_imagenes.Enabled = False
        grptiempo.Visible = False
        grptiempo.Enabled = False
        txtminutos.Enabled = False

        ' VES ODCT 2019
        rbtFrecManual.Enabled = True
        rbtFrecRepetir.Enabled = True
        rbtFrecManual.Checked = False
        rbtFrecRepetir.Checked = True
        txtFrec.Text = "1"
        cboInterv.SelectedIndex = 0
        txthora.Text = "08:00"
        txtHoraH.Text = "08:00"

        txtFrec.Enabled = True
        cboInterv.Enabled = True
        txtHoraH.Enabled = True
        actualizarUIFrecuencia()

    End Sub

    Private Sub Btn_Salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Salir.Click
        Close()
    End Sub

    Private Sub chkinterno_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkinterno.CheckedChanged
        If chkinterno.Checked = True Then
            txtrsocial.Text = "INTERNO"
            txtgiro.Text = "ALMACENAMIENTO Y DEPOSITOS"
            txtrut.Text = "774486305"
            cboinformes.Text = ""
            cboinformes.Enabled = True
            llenarCombo("Interno")
            chktodos.Enabled = True
            chklunes.Enabled = True
            chkmartes.Enabled = True
            chkmiercoles.Enabled = True
            chkjueves.Enabled = True
            chkviernes.Enabled = True
            chksabado.Enabled = True
            chkdomingo.Enabled = True
            txthora.Enabled = True
            rdiactivado.Enabled = True
            rdidesactivado.Enabled = True
            RutCliente = "774486305"
            cargarItems()
            btn_agregarmail.Enabled = True
            btn_quitarmail.Enabled = True
            _em1.Enabled = True
            btn_informes.Enabled = False
            btn_imagenes.Enabled = True

            ' VES ODCT 2019
            rbtFrecManual.Enabled = True
            rbtFrecRepetir.Enabled = True
            txtFrec.Enabled = True
            cboInterv.Enabled = True
            txtHoraH.Enabled = True
            actualizarUIFrecuencia()
        Else
            txtgiro.Text = ""
            txtrsocial.Text = ""
            txtrut.Text = ""
            txthora.Text = ""
            cboinformes.Enabled = False
            cboinformes.DataSource = Nothing
            cboinformes.Text = ""
            txthora.Enabled = False
            chktodos.Checked = False
            chklunes.Checked = False
            chkmartes.Checked = False
            chkmiercoles.Checked = False
            chkjueves.Checked = False
            chkviernes.Checked = False
            chksabado.Checked = False
            chkdomingo.Checked = False
            chktodos.Enabled = False
            chklunes.Enabled = False
            chkmartes.Enabled = False
            chkmiercoles.Enabled = False
            chkjueves.Enabled = False
            chkviernes.Enabled = False
            chksabado.Enabled = False
            chkdomingo.Enabled = False
            rdiactivado.Enabled = False
            rdidesactivado.Enabled = False
            rdiactivado.Checked = False
            rdidesactivado.Checked = False
            dtgcorreos.DataSource = ""
            dtgcorreos.DataSource = Nothing
            btn_agregarmail.Enabled = False
            btn_quitarmail.Enabled = False
            _em1.Text = ""
            _em1.Enabled = False
            btn_informes.Enabled = True
            btn_imagenes.Enabled = False
            grptiempo.Visible = False
            grptiempo.Enabled = False
            txtminutos.Enabled = False

            ' VES ODCT 2019
            rbtFrecManual.Enabled = False
            rbtFrecRepetir.Enabled = False
            txtFrec.Enabled = False
            cboInterv.Enabled = False
            txtHoraH.Enabled = False
        End If
    End Sub

    Private Sub chktodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chktodos.CheckedChanged
        If chktodos.Checked = True Then
            chklunes.Checked = True
            chkmartes.Checked = True
            chkmiercoles.Checked = True
            chkjueves.Checked = True
            chkviernes.Checked = True
            chksabado.Checked = True
            chkdomingo.Checked = True
        Else
            chklunes.Checked = False
            chkmartes.Checked = False
            chkmiercoles.Checked = False
            chkjueves.Checked = False
            chkviernes.Checked = False
            chksabado.Checked = False
            chkdomingo.Checked = False
        End If
    End Sub

    Private Sub cboinformes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboinformes.SelectedIndexChanged

        Try
            If cboinformes.SelectedValue.ToString() <> "System.Data.DataRowView" Then
                cargarItems()
            End If
        Catch ex As NullReferenceException

        End Try

    End Sub

    Sub cargarItems()
        Try
            chktodos.Checked = False
            chklunes.Checked = False
            chkmartes.Checked = False
            chkmiercoles.Checked = False
            chkjueves.Checked = False
            chkviernes.Checked = False
            chksabado.Checked = False
            chkdomingo.Checked = False
            dtgcorreos.DataSource = ""
            dtgcorreos.DataSource = Nothing
            Dim campo As String = ""
            Dim tabl As String = ""
            Dim id_informes As String = ""
            If cboinformes.SelectedValue.ToString() <> "System.Data.DataRowView" Then
                id_informes = cboinformes.SelectedValue.ToString()
                codigoInforme = id_informes

                'COMPRUEBO SI EL INFORME ES PEDIDOS POR HORAS, DE ESA FORMA PROGRAMOLOS MINUTOS A MEDIR 
                If (id_informes = "12") Then
                    grptiempo.Visible = True
                    grptiempo.Enabled = True
                    txtminutos.Enabled = True
                Else
                    grptiempo.Visible = False
                    grptiempo.Enabled = False
                    txtminutos.Enabled = False
                End If

            End If
            Dim sqlCorreos = ""

            If chkinterno.Checked = False Then
                tabl = "Clientes"
                If id_informes = "4" Then
                    campo = "cli_mail" 'PEDIDOS WEB
                ElseIf id_informes = "1" Then
                    campo = "CLI_CRYD" 'RECEPCION CHEKLIST DESPACHO
                ElseIf id_informes = "7" Then
                    campo = "Mail2" 'PEDIDOS PRE DESPACHO
                ElseIf id_informes = "5" Then
                    campo = "CLI_PVENC" 'VENCIDOS
                Else
                    campo = "cli_mail"
                End If
                sqlCorreos = "SELECT " + campo + " FROM " + tabl + " WHERE cli_rut='" + RutCliente + "'"
            Else
                tabl = "informes_programa"
                sqlCorreos = "SELECT prg_mail FROM " + tabl + " WHERE prg_rut_cli='" + RutCliente + "' AND prg_inf_cod='" + id_informes + "'"
            End If



            Dim tabla As DataTable = fnc.ListarTablasSQL(sqlCorreos)
            If tabla.Rows.Count > 0 Then
                LlamarCorreos(tabla.Rows(0)(0).ToString(), dtgcorreos)
            End If

            Dim sqlRdi = "SELECT prg_estado FROM informes_programa WHERE prg_rut_cli='" + RutCliente + "' AND prg_inf_cod='" + id_informes + "'"
            Dim tablardi As DataTable = fnc.ListarTablasSQL(sqlRdi)


            Try
                rdiactivado.Enabled = True
                rdidesactivado.Enabled = True

                If tablardi.Rows(0)(0).ToString = "Activado" Then
                    rdiactivado.Checked = True
                    rdidesactivado.Checked = False
                ElseIf tablardi.Rows(0)(0).ToString = "Desactivado" Then
                    rdidesactivado.Checked = True
                    rdiactivado.Checked = False
                Else
                    rdidesactivado.Checked = False
                    rdiactivado.Checked = False
                End If
            Catch ex As IndexOutOfRangeException
                rdidesactivado.Checked = False
                rdiactivado.Checked = False
            End Try

            Dim sqlChk = "SELECT prg_Lunes,prg_martes,prg_miercoles,prg_jueves,prg_viernes, prg_sabado, prg_domingo, prg_hora, prg_emp, prg_min, prg_frec, prg_interv, prg_horah" +
                         " FROM informes_programa WHERE prg_rut_cli='" + RutCliente + "' AND prg_inf_cod='" + id_informes + "'"
            Dim tablachk As DataTable = fnc.ListarTablasSQL(sqlChk)
            Dim contador As Integer = 0

            Try
                ' VES ODCT 2019
                Dim intervalo As Integer
                intervalo = CInt(tablachk(0)(11))
                txtFrec.Text = tablachk.Rows(0)(10)
                cboInterv.SelectedIndex = IIf(intervalo < 4, intervalo, 0)
                txtHoraH.Text = tablachk.Rows(0)(12)
                rbtFrecRepetir.Checked = (intervalo < 4)
                rbtFrecManual.Checked = (intervalo = 4)

                If tablachk.Rows(0)(0) = "si" Then 'Lunes
                    chklunes.Checked = True
                    contador = contador + 1
                End If
                If tablachk.Rows(0)(1) = "si" Then 'Martes
                    chkmartes.Checked = True
                    contador = contador + 1
                End If
                If tablachk.Rows(0)(2) = "si" Then 'Miercoles
                    chkmiercoles.Checked = True
                    contador = contador + 1
                End If
                If tablachk.Rows(0)(3) = "si" Then 'Jueves
                    chkjueves.Checked = True
                    contador = contador + 1
                End If
                If tablachk.Rows(0)(4) = "si" Then 'Viernes
                    chkviernes.Checked = True
                    contador = contador + 1
                End If
                If tablachk.Rows(0)(5) = "si" Then 'Sabado
                    chksabado.Checked = True
                    contador = contador + 1
                End If
                If tablachk.Rows(0)(6) = "si" Then 'Domingo
                    chkdomingo.Checked = True
                    contador = contador + 1
                End If
                If chkinterno.Checked = True Then
                    If tablachk.Rows(0)(7) <> "" Then 'Hora
                        txthora.Text = tablachk.Rows(0)(7)
                    End If
                End If


                If contador = 7 Then 'Todos los dias
                    chktodos.Checked = True
                End If

                If tablachk.Rows(0)(8) = "3" Then 'Valido si el informe es igual a 3 bloqueo el resto de casillas
                    txthora.Text = "00:00"
                    chklunes.Checked = True
                    chkmartes.Checked = True
                    chkmiercoles.Checked = True
                    chkjueves.Checked = True
                    chkviernes.Checked = True
                    chksabado.Checked = True
                    chkdomingo.Checked = True
                    chktodos.Checked = True

                    chklunes.Enabled = False
                    chkmartes.Enabled = False
                    chkmiercoles.Enabled = False
                    chkjueves.Enabled = False
                    chkviernes.Enabled = False
                    chksabado.Enabled = False
                    chkdomingo.Enabled = False
                    txthora.Enabled = False
                    chktodos.Enabled = False
                    btn_imagenes.Enabled = False
                    rdiactivado.Enabled = False
                    rdidesactivado.Enabled = False

                    ' VES ODCT 2019
                    txtFrec.Enabled = False
                    cboInterv.Enabled = False
                    txtHoraH.Text = "23:59"
                Else
                    chklunes.Enabled = True
                    chkmartes.Enabled = True
                    chkmiercoles.Enabled = True
                    chkjueves.Enabled = True
                    chkviernes.Enabled = True
                    chksabado.Enabled = True
                    chkdomingo.Enabled = True
                    txthora.Enabled = True
                    chktodos.Enabled = True
                    btn_imagenes.Enabled = True
                    rdiactivado.Enabled = True
                    rdidesactivado.Enabled = True

                    ' VES ODCT 2019
                    txtFrec.Enabled = True
                    cboInterv.Enabled = True
                End If

                If id_informes = "12" Then
                    txtminutos.Text = tablachk.Rows(0)(9)
                End If


            Catch ex As IndexOutOfRangeException
                chktodos.Checked = False
                txthora.Text = ""
            End Try


        Catch ex As NullReferenceException
            dtgcorreos.DataSource = ""
            dtgcorreos.DataSource = Nothing
        End Try
    End Sub

    Sub GuardarCliente()

        If validarEntrada() = 0 Then
            Dim sqlGuardar As String = ""
            Dim estado As String

            verificarDias()
            verificarHora(txthora)
            verificarHora(txtHoraH)

            If rdiactivado.Checked = True Then
                estado = "Activado"
            Else
                estado = "Desactivado"
            End If

            Dim intervalo As Integer
            intervalo = cboInterv.SelectedIndex
            If rbtFrecManual.Checked = True Then
                intervalo = 4  '' Manual
            End If


            If chkinterno.Checked = True Then
                sqlGuardar = " INSERT INTO informes_programa " +
               "(prg_rut_cli, prg_inf_cod, prg_emp, prg_hora, prg_mail, prg_lunes, prg_martes, prg_miercoles, prg_jueves, prg_viernes, prg_sabado, prg_domingo, prg_estado, prg_min, prg_frec, prg_interv, prg_horah) " +
               " VALUES ('" + RutCliente + "','" + codigoInforme + "','0','" + txthora.Text + "','" + RetornaCorreos(dtgcorreos) + "','" + Lu + "','" + Ma + "','" + Mi + "','" + Ju + "','" + Vi + "','" + Sa +
               "','" + Dom + "','" + estado + "','" + txtminutos.Text + "'," + txtFrec.Text + "," + intervalo.ToString() + ",'" + txtHoraH.Text + "')"
            Else
                sqlGuardar = " INSERT INTO informes_programa " +
             "(prg_rut_cli, prg_inf_cod, prg_emp, prg_lunes, prg_martes, prg_miercoles, prg_jueves, prg_viernes, prg_sabado, prg_domingo, prg_estado, prg_min, prg_frec, prg_interv, prg_horah) " +
             " VALUES ('" + RutCliente + "','" + codigoInforme + "','1','" + Lu + "','" + Ma + "','" + Mi + "','" + Ju + "','" + Vi + "','" + Sa +
             "','" + Dom + "','" + estado + "','" + txtminutos.Text + "'," + txtFrec.Text + "," + intervalo.ToString() + ",'" + txtHoraH.Text + "')"
            End If

            If fnc.MovimientoSQL(sqlGuardar) > 0 Then
                MsgBox("Registro Guardado Correctamente")
            Else
                MsgBox("Error al ingresar la información:" & vbCrLf & "- Verifique que los campos son correctos" & vbCrLf & "- Contactese con su administrador")
            End If

        End If
    End Sub

    Sub verificarDias()
        If chklunes.Checked = True Then
            Lu = "si"
        Else
            Lu = "no"
        End If

        If chkmartes.Checked = True Then
            Ma = "si"
        Else
            Ma = "no"
        End If

        If chkmiercoles.Checked = True Then
            Mi = "si"
        Else
            Mi = "no"
        End If

        If chkjueves.Checked = True Then
            Ju = "si"
        Else
            Ju = "no"
        End If

        If chkviernes.Checked = True Then
            Vi = "si"
        Else
            Vi = "no"
        End If

        If chksabado.Checked = True Then
            Sa = "si"
        Else
            Sa = "no"
        End If

        If chkdomingo.Checked = True Then
            Dom = "si"
        Else
            Dom = "no"
        End If

    End Sub

    Sub verificarHora(ByRef sender As MaskedTextBox)
        Try
            If Trim(sender.Text).Length = 5 Then
                Dim hora As String = Replace(sender.Text, ":", "")
                Dim H As Integer = Convert.ToInt32(hora.Substring(0, 2))
                Dim M As Integer = Convert.ToInt32(hora.Substring(2, 2))

                If ((H < 0 Or H > 23) Or (M < 0 Or M > 59)) Then
                    sender.Text = "21:00"
                End If

            Else
                sender.Text = "00:00"
            End If
        Catch ex As FormatException
            sender.Text = "00:00"
            MsgBox(sender.Text)
        End Try



    End Sub

    Sub modificarCliente()

        If validarEntrada() = 0 Then
            Dim sqlGuardar As String = ""
            Dim estado As String
            Dim campo As String
            verificarDias()
            verificarHora(txthora)
            verificarHora(txtHoraH)


            If rdiactivado.Checked = True Then
                estado = "Activado"
            Else
                estado = "Desactivado"
            End If

            Dim intervalo As Integer
            intervalo = cboInterv.SelectedIndex
            If rbtFrecManual.Checked = True Then
                intervalo = 4  '' Manual
            End If


            If chkinterno.Checked = True Then
                sqlGuardar = "  UPDATE informes_programa SET prg_hora='" + txthora.Text + "' , prg_mail='" + RetornaCorreos(dtgcorreos) + "', prg_lunes='" + Lu + "', prg_martes='" + Ma + "'," +
                         "prg_miercoles='" + Mi + "', prg_jueves='" + Ju + "', prg_viernes='" + Vi + "', prg_sabado='" + Sa + "', prg_domingo='" + Dom + "', prg_estado='" + estado + "', prg_min='" +
                         txtminutos.Text + "', prg_frec=" + txtFrec.Text + ", prg_interv=" + intervalo.ToString() + ", prg_horah='" + txtHoraH.Text + "'" +
                         "WHERE prg_rut_cli='" + RutCliente + "' AND prg_inf_cod='" + codigoInforme + "'"
            Else

                If codigoInforme = "4" Then
                    campo = "cli_mail" 'PEDIDOS WEB
                ElseIf codigoInforme = "1" Then
                    campo = "CLI_CRYD" 'RECEPCION CHEKLIST DESPACHO
                ElseIf codigoInforme = "7" Then
                    campo = "Mail2" 'PEDIDOS PRE DESPACHO
                ElseIf codigoInforme = "5" Then
                    campo = "CLI_PVENC" 'VENCIDOS
                Else
                    campo = "cli_mail"
                End If

                sqlGuardar = "  UPDATE informes_programa SET prg_estado='" + estado + "' WHERE prg_rut_cli='" + RutCliente + "' AND prg_inf_cod='" + codigoInforme + "';" +
                             "UPDATE Clientes SET " + campo + "='" + RetornaCorreos(dtgcorreos) + "' WHERE cli_rut='" + RutCliente + "';"
            End If

            If fnc.MovimientoSQL(sqlGuardar) > 0 Then
                MsgBox("Registro Guardado Correctamente")
            Else
                MsgBox("Error al ingresar la información:" & vbCrLf & "- Verifique que los campos son correctos" & vbCrLf & "- Contactese con su administrador")
            End If

        End If
    End Sub

    Function validarEntrada()
        Dim valor = 0
        If chkinterno.Checked = True Then

            If rbtFrecRepetir.Checked = True And chklunes.Checked = False And chkmartes.Checked = False And chkmiercoles.Checked = False And chkjueves.Checked = False And
               chkviernes.Checked = False And chksabado.Checked = False And chkdomingo.Checked = False Then
                MsgBox("Debe ingresar a lo menos 1 día", MsgBoxStyle.Critical, "Aviso")
                valor += 1
                Return valor
                Exit Function
            ElseIf txthora.Text = "" Or Trim(txthora.Text) = ":" Then
                MsgBox("Debe ingresar una hora", MsgBoxStyle.Critical, "Aviso")
                valor += 1
                Return valor
                Exit Function
            ElseIf rdiactivado.Checked = False And rdidesactivado.Checked = False Then
                MsgBox("Debe ingresar un estado", MsgBoxStyle.Critical, "Aviso")
                valor += 1
                Return valor
                Exit Function
            End If

        Else
            If rdiactivado.Checked = False And rdidesactivado.Checked = False Then
                MsgBox("Debe ingresar un estado", MsgBoxStyle.Critical, "Aviso")
                valor += 1
                Return valor
                Exit Function
            End If

        End If

        Return valor
    End Function

    Sub buscarRegistro()

        Dim sqlBuscaCliente = "SELECT inf_rut_cli FROM informes WHERE "

        Dim tabla As DataTable = fnc.ListarTablasSQL(sqlBuscaCliente)
        If tabla.Rows.Count > 0 Then

        End If


    End Sub
    Private Sub Btn_Guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Guardar.Click

        If verificarPrograma(codigoInforme) = False Then
            'MsgBox("Se guardara")
            GuardarCliente()
        Else
            'MsgBox("Se Modificara")
            modificarCliente()
        End If

    End Sub

    Private Function verificarPrograma(ByVal inf_cod As String) As Boolean

        Dim _RegistroExiste As Boolean = False
        Try
            Dim sqlRegistro = "SELECT prg_rut_cli FROM informes_programa WHERE prg_rut_cli='" + RutCliente + "' AND prg_inf_cod='" + inf_cod + "'"
            Dim tabla As DataTable = fnc.ListarTablasSQL(sqlRegistro)


            If tabla.Rows.Count = 0 Then
                _RegistroExiste = False
            Else
                _RegistroExiste = True
            End If

        Catch ex As Exception
            MsgBox(ex.Message())
        End Try

        Return _RegistroExiste

    End Function

    Private Sub Frm_AddEnvioEmail_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        f_envioemail = False
    End Sub

    Private Sub btn_agregarmail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agregarmail.Click
        If validar_Mail(_em1.Text) = True Then
            If _vem1 > -1 Then
                dtgcorreos.Rows(_vem1).Cells(0).Value = _em1.Text
                _vem1 = -1
                _em1.Text = ""
            Else
                dtgcorreos.Rows.Add(_em1.Text)
                _vem1 = -1
                _em1.Text = ""
            End If
            btn_agregarmail.Focus()
        Else
            MsgBox("El correo ingresado no es valido", MsgBoxStyle.Critical, "Aviso")
        End If
    End Sub

    Private Sub btn_quitarmail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_quitarmail.Click
        _vem1 = -1
        _em1.Text = ""
        _em1.Focus()
    End Sub

    Private Sub dtgcorreos_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgcorreos.CellClick
        If e.RowIndex > -1 AndAlso e.ColumnIndex = 1 Then
            dtgcorreos.Rows.RemoveAt(e.RowIndex)
        End If
    End Sub

    Private Sub btn_informes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_informes.Click
        Dim f As Form
        f = Lst_Informes
        f.ShowDialog()
    End Sub

    Private Sub btn_imagenes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_imagenes.Click
        Dim f As Form
        f = Frm_imagenesInformes
        f.ShowDialog()
    End Sub

    Private Sub btn_pdf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_pdf.Click

        If txtrsocial.Text = "" Then

            Dim frm As Frm_MuestraReporte = New Frm_MuestraReporte
            frm.Text = "Informe de Envío de Correos"

            Dim report As New Rpt_EnvioCorreosExterno

            report.SetDatabaseLogon(Usuario_ODBC, Pass_ODBC)

            frm.Contenedor.ReportSource = report
            frm.ShowDialog()

        Else
            Dim frm As Frm_MuestraReporte = New Frm_MuestraReporte

            If (chkinterno.Checked = False) Then

                frm.Text = "Informe de Envío de Correos"

                Dim report As New Rpt_EnvioCorreos

                report.SetDatabaseLogon(Usuario_ODBC, Pass_ODBC)

                report.SetParameterValue("codigo", RutCliente)

                frm.Contenedor.ReportSource = report
                frm.ShowDialog()

            Else
                frm.Text = "Informe de Envío de Correos"

                Dim report As New Rpt_EnvioCorreosInterno

                report.SetDatabaseLogon(Usuario_ODBC, Pass_ODBC)

                frm.Contenedor.ReportSource = report
                frm.ShowDialog()

            End If
        End If


    End Sub

    Private Sub Frm_AddEnvioEmail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub rdidesactivado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdidesactivado.CheckedChanged

    End Sub

    Private Sub lblhora_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub


    '
    '       VES OCT 2019
    '       ACTUALIZA LA UI DE FRECUENCIA EN BASE A LAS
    '       LAS OPCIONES SELECCIONADAS
    '
    Private Sub actualizarUIFrecuencia()
        txtFrec.Visible = IIf(rbtFrecRepetir.Checked = True, True, False)
        cboInterv.Visible = txtFrec.Visible
        lblHoraD.Visible = txtFrec.Visible
        txthora.Visible = txtFrec.Visible
        lblHoraH.Visible = txtFrec.Visible
        txtHoraH.Visible = txtFrec.Visible
        chktodos.Visible = txtFrec.Visible
        chklunes.Visible = txtFrec.Visible
        chkmartes.Visible = txtFrec.Visible
        chkmiercoles.Visible = txtFrec.Visible
        chkjueves.Visible = txtFrec.Visible
        chkviernes.Visible = txtFrec.Visible
        chksabado.Visible = txtFrec.Visible
        chkdomingo.Visible = txtFrec.Visible

        If rbtFrecRepetir.Checked = True Then
            Dim diario As Boolean
            diario = IIf(cboInterv.SelectedIndex > 0 Or txtFrec.Text = "1", True, False)
            chktodos.Visible = diario
            chklunes.Visible = diario
            chkmartes.Visible = diario
            chkmiercoles.Visible = diario
            chkjueves.Visible = diario
            chkviernes.Visible = diario
            chksabado.Visible = diario
            chkdomingo.Visible = diario
            If diario = False Then
                chktodos.Checked = True
            End If
            If cboInterv.SelectedIndex = 0 Then
                lblHoraH.Visible = False
                txtHoraH.Visible = False
                lblHoraD.Text = "a las"
            Else
                lblHoraH.Visible = True
                txtHoraH.Visible = True
                lblHoraD.Text = "entre las"
            End If
        End If


    End Sub

    Private Sub rbtRepetitivo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtFrecRepetir.CheckedChanged
        actualizarUIFrecuencia()
    End Sub

    Private Sub rbtFrecManual_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtFrecManual.CheckedChanged
        actualizarUIFrecuencia()
    End Sub

    Private Sub txtFrec_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFrec.TextChanged
        actualizarUIFrecuencia()
    End Sub

    Private Sub cboInterv_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboInterv.SelectedIndexChanged
        actualizarUIFrecuencia()
    End Sub
End Class
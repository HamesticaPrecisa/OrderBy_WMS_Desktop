Imports System.Data.SqlClient

Public Class Frm_PosicionamientoManual
    Dim fnc As New Funciones
    Dim con As New Conexion
    Dim TIPOALAMACEN As String = ""

    Dim camara As String = ""
    Dim banda As String = ""
    Dim columna As String = ""
    Dim piso As String = ""
    Dim nivel As String = ""


    Public usuario As String = ""
    Public cargo As String = ""
    Public perfil As String = ""
    Public codigo As String = ""
    Dim codigo_pallet As String = ""

    Public accion As Integer = 0

    Private Sub txtpallet_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpallet.KeyPress
        If e.KeyChar = ChrW(13) Then

            If txtpallet.Text = "" Then
                Exit Sub
            End If
            txtpallet.Text = CerosAnteriorString(txtpallet.Text, 9)
            Dim Busca_posicion As String = "SELECT racd_ca, racd_Ba, racd_Co, racd_Pi, racd_Ni , cli_nomb " +
                                           "FROM rackdeta, clientes, detarece WHERE drec_codi=racd_codi AND " +
                                           "drec_rutcli=cli_rut AND racd_codi='" + txtpallet.Text + "'"

            Dim tabla As DataTable = fnc.ListarTablasSQL(Busca_posicion)
            If tabla.Rows.Count > 0 Then
                txtcliente.Text = tabla.Rows(0)(5).ToString()
                txtpallet.Enabled = False
                ca.Text = tabla.Rows(0)(0).ToString()
                ba.Text = tabla.Rows(0)(1).ToString()
                co.Text = tabla.Rows(0)(2).ToString()
                pi.Text = tabla.Rows(0)(3).ToString()
                ni.Text = tabla.Rows(0)(4).ToString()
                btn_guardar.Enabled = True
                tca.Focus()
            Else
                txtpallet.Text = ""
                txtpallet.Enabled = True
                txtpallet.Focus()
                MsgBox("El N° de pallet no existe o se encuentra despachado", MsgBoxStyle.Critical, "Aviso")
            End If
        Else
            SoloNumeros(sender, e)
        End If
    End Sub

    Private Sub tca_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tca.KeyPress
        If e.KeyChar = ChrW(13) Then
            If tca.Text <> "" Then
                Me.tca.Text = CerosAnteriorString(Me.tca.Text, 2)
                If fnc.verificaExistencia("camaras", "cam_codi", CerosAnteriorString(Me.tca.Text, 2)) = True Then
                    If tca.Text = "05" Or tca.Text = "06" Then
                        'tpi.Enabled = False
                        'tni.Enabled = False
                    End If
                    tba.Focus()
                Else
                    MsgBox("La camara ingresada no existe", MsgBoxStyle.Critical, "Aviso")
                End If
            End If
        Else
            SoloNumeros(sender, e)
        End If
    End Sub

    Private Sub tba_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tba.KeyPress
        If e.KeyChar = ChrW(13) Then
            If tba.Text <> "" Then
                Me.tba.Text = CerosAnteriorString(Me.tba.Text, 2)
                tco.Focus()
            End If
        Else
            SoloNumeros(sender, e)
        End If
    End Sub

    Private Sub tco_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tco.KeyPress
        If e.KeyChar = ChrW(13) Then
            If tco.Text <> "" Then
                Me.tco.Text = CerosAnteriorString(Me.tco.Text, 2)
                tpi.Focus()
            End If
        Else
            SoloNumeros(sender, e)
        End If
    End Sub

    Private Sub tpi_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tpi.KeyPress
        If e.KeyChar = ChrW(13) Then
            If tpi.Text <> "" Then
                If tca.Text = "05" Or tca.Text = "06" Then
                    btn_guardar.Focus()
                    Exit Sub
                End If
                Me.tpi.Text = CerosAnteriorString(Me.tpi.Text, 2)
                tni.Focus()
                tni.SelectAll()
            End If
        Else
            SoloNumeros(sender, e)
        End If
    End Sub
    Private Sub pos()



        If fnc.verificaExistencia("rackdeta", "racd_codi", CerosAnteriorString(txtpallet.Text, 9)) = True Then

            If verificarPosicion() = True Then
                If ca.Text = tca.Text AndAlso ba.Text = tba.Text AndAlso co.Text = tco.Text AndAlso pi.Text = tpi.Text AndAlso ni.Text = tni.Text Then
                    MsgBox("Esta guardando el pallet en la misma posicion", MsgBoxStyle.Critical, "Aviso")
                End If
                Dim fecha As String = devuelve_fecha(fnc.DevuelveFechaServidor())
                Dim hora As String = (fnc.DevuelveFechaServidor()).ToString("HH:mm")
                Dim SqlTrazabilidad As String = "INSERT INTO movpallet(mov_folio, mov_codper, mov_ca, " & _
                                      "mov_ba, mov_co, mov_pi, mov_ni, mov_fecha, mov_tipo, mov_hora)" & _
                                      "VALUES('" + CerosAnteriorString(txtpallet.Text, 9) + "','" + CerosAnteriorString(Frm_Principal.InfoUsuario.Text, 3) + "', " & _
                                      "'" + tca.Text + "','" + tba.Text + "','" + tco.Text + "'," & _
                                      "'" + Convert.ToInt32(tpi.Text).ToString() + "','" + tni.Text.ToUpper() + "'," & _
                                      "'" + fecha.ToString() + "','RM','" + hora.ToString() + "')"
                If fnc.MovimientoSQL(SqlTrazabilidad) > 0 Then
                    Dim sql As String = "UPDATE rackdeta SET racd_ca='" + tca.Text + "', racd_ba='" + tba.Text + "', " & _
                    "racd_co='" + tco.Text + "', racd_pi='" + Convert.ToInt32(tpi.Text).ToString() + "', " & _
                    "racd_ni='" + tni.Text + "' WHERE racd_codi='" + CerosAnteriorString(txtpallet.Text, 9) + "'"

                    If fnc.MovimientoSQL(sql) > 0 Then
                        Dim sqlDetarece As String = "UPDATE detarece SET drec_camara='" + tca.Text + "',  drec_banda='" + tba.Text + "', " & _
                                                "drec_colum='" + tco.Text + "', drec_piso='" + Convert.ToInt32(tpi.Text).ToString() + "', " & _
                                                "drec_nivel='" + tni.Text + "' WHERE drec_codi='" + CerosAnteriorString(txtpallet.Text, 9) + "'"

                        fnc.MovimientoSQL(sqlDetarece)
                        MsgBox("Posicion actualizada", MsgBoxStyle.Information, "Aviso")

                    End If
                End If
            End If
        Else
            MsgBox("El pallet ingresado no existe", MsgBoxStyle.MsgBoxHelp, "Aviso")
        End If
    End Sub
    Private Sub tni_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tni.KeyPress
        If e.KeyChar = ChrW(13) Then
            If tni.Text <> "" Then
                btn_guardar.Focus()
            End If
            'ElseIf e.KeyChar = "F" Or e.KeyChar = "f" Or e.KeyChar = "1" Or e.KeyChar = "2" _
            '        Or e.KeyChar = "3" Or e.KeyChar = "4" Or e.KeyChar = "5" Or e.KeyChar = "6" _
            '        Or e.KeyChar = ChrW(8) Or e.KeyChar = ChrW(127) Then

        ElseIf ("0123456789fF".Contains(e.KeyChar)) Then







        Else
            e.Handled = True
        End If








    End Sub

    Public Function verificarPosicion() As Boolean
        Dim retorno As Boolean = False

        'Dim sql As String = "SELECT * FROM rackdeta WHERE convert(integer,racd_ca)='" + Val(tca.Text).ToString() + "' AND convert(integer,racd_ba)='" + Val(tba.Text).ToString() + "' AND " & _
        '"convert(integer,racd_co)='" + Val(tco.Text).ToString() + "' AND convert(integer,racd_pi)='" + Val(tpi.Text).ToString() + "' AND racd_ni='" + Val(tni.Text).ToString() + "' AND racd_codi<>'" + txtpallet.Text + "'"

        Dim Sql_Ocupada As String = "SELECT racd_ni, racd_codi FROM rackdeta WHERE convert(integer,racd_ca)='" + Val(tca.Text).ToString() + "' AND convert(integer,racd_ba)='" + Val(tba.Text).ToString() + "' AND " & _
        "convert(integer,racd_co)='" + Val(tco.Text).ToString() + "' AND convert(integer,racd_pi)='" + Val(tpi.Text).ToString() + "' AND racd_codi<>'" + txtpallet.Text + "' "

        'Dim tabla As DataTable = fnc.ListarTablasSQL(sql)
        Dim tabla_ocupada As DataTable = fnc.ListarTablasSQL(Sql_Ocupada)

        If tabla_ocupada.Rows.Count > 0 Then
            If tabla_ocupada.Rows(0)(0).ToString() = "F" Or tabla_ocupada.Rows(0)(0).ToString() = "f" Then
                MsgBox("Posicion ocupada", MsgBoxStyle.Critical, "Aviso")
                retorno = False
            ElseIf tabla_ocupada.Rows(0)(0).ToString() = "1" AndAlso tni.Text = "1" Then
                MsgBox("Posicion ocupada", MsgBoxStyle.Critical, "Aviso")
                retorno = False
            ElseIf tabla_ocupada.Rows(0)(0).ToString() = "2" AndAlso tni.Text = "2" Then
                MsgBox("Posicion ocupada", MsgBoxStyle.Critical, "Aviso")
                retorno = False
            ElseIf tabla_ocupada.Rows(0)(0).ToString() = "" Then
                MsgBox("Posicion ocupada", MsgBoxStyle.Critical, "Aviso")
                retorno = False
            Else
                Return True
                Exit Function
            End If
        Else
            retorno = True
            ' MsgBox("Posicion ocupada por el pallet Nº " + tabla.Rows(0)(1).ToString(), MsgBoxStyle.Critical, "Aviso")
        End If

        If tabla_ocupada.Rows.Count > 0 Then
            If tca.Text = "71" Or tca.Text = "72" _
                                  Or tca.Text = "73" Or tca.Text = "74" _
                                  Or tca.Text = "61" Or tca.Text = "62" Then
                retorno = True
            Else
                MsgBox("Posicion ocupada por el pallet Nº " + tabla_ocupada.Rows(0)(1).ToString(), MsgBoxStyle.Critical, "Aviso")
                retorno = False
            End If
        End If

        Return retorno

    End Function

    Private Sub posss()


        If tca.Text = "" Or tpi.Text = "" Or (tni.Text = "" AndAlso tco.Enabled = False) Then
            ' lmensaje.Text = "LLene todos los campos"
            MsgBox("LLene todos los campos", MsgBoxStyle.MsgBoxHelp, "Aviso")
        Else
            If fnc.verificaExistencia("rackdeta", "racd_codi", CerosAnteriorString(txtpallet.Text, 9)) = True Then

                If verificarPosicion() = True Then

                    Try

                        con.conectar()

                        Dim _cmd As SqlCommand = New SqlCommand("PAG_POSICIONAR", con.con)
                        _cmd.CommandType = CommandType.StoredProcedure
                        _cmd.Parameters.AddWithValue("@pallet", txtpallet.Text)
                        _cmd.Parameters.AddWithValue("@camara", tca.Text)
                        _cmd.Parameters.AddWithValue("@banda", tba.Text)
                        _cmd.Parameters.AddWithValue("@columna", tco.Text)
                        _cmd.Parameters.AddWithValue("@piso", tpi.Text)
                        _cmd.Parameters.AddWithValue("@nivel", tni.Text)
                        _cmd.Parameters.AddWithValue("@tipo", "RM")
                        _cmd.Parameters.AddWithValue("@encargado", CerosAnteriorString(Frm_Principal.InfoUsuario.Text, 3))

                        Dim resp As Integer = 0

                        Try
                            resp = Convert.ToInt32(_cmd.ExecuteScalar())
                        Catch ex As Exception
                            resp = 1
                        End Try

                        If resp = 0 Then
                            borratemp()

                            'lmensaje.Text = "Grabación exitosa"
                            MsgBox("Grabación exitosa", MsgBoxStyle.Information, "Aviso")
                        ElseIf resp < 4 AndAlso resp <> 0 Then
                            'lmensaje.Text = "Error al actualizar" + resp.ToString()
                            MsgBox("Error al actualizar", MsgBoxStyle.Information, "Aviso")
                        ElseIf resp = 4 Then
                            'lmensaje.Text = "El pallet no existe"
                            MsgBox("El pallet no existe", MsgBoxStyle.Information, "Aviso")
                        End If
                        con.cerrar()

                    Catch ex As Exception

                    End Try
                    LimpiarCajas(Me.GroupBox1)
                    tni.Text = "F"
                    txtpallet.Text = ""
                    tba.Enabled = True
                    tco.Enabled = True
                    tpi.Enabled = True
                    tni.Enabled = True
                    ckpasillo.CheckState = CheckState.Unchecked
                    txtpallet.Enabled = True
                    txtpallet.Focus()

                    If accion = 1 Then
                        Me.Close()
                    End If
                End If
            Else
                MsgBox("El pallet ingresado no existe", MsgBoxStyle.MsgBoxHelp, "Aviso")
            End If
        End If

    End Sub
    Private Sub borratemp()

        Dim sqlEliminas As String = "DELETE FROM TMP_POS WHERE pallet='" + txtpallet.Text + "'"
        fnc.MovimientoSQL(sqlEliminas)
    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        tni.Text = tni.Text.ToUpper()

        Dim pisoa As String = tpi.Text.Trim.ToUpper
        Dim pisoValid As Integer = 0
        If (Integer.TryParse(pisoa, pisoValid) = False) Then
            tpi.Text = ""
            MsgBox("Debe ingresar un piso valido.", MsgBoxStyle.Information, "Piso erroneo!")
            tpi.Focus()
            Exit Sub
            'Else
            '    If (pisoa.Length = 1) Then
            '        pisoa = "0" & pisoa
            '    End If
        End If

        Dim Sql_tip As String = "SELECT * FROM camaraMantenedor WHERE camara='" + tca.Text.Trim() + "' and banda='" + tba.Text.Trim() + "' and columna ='" + tco.Text.Trim() + "' and convert(int,piso)='" + pisoa + "'"

        Dim tablatip As DataTable = fnc.ListarTablasSQL(Sql_tip)

        If tablatip.Rows.Count > 0 Then

            Dim sqlHabil = "SELECT * FROM camaraMantenedor WHERE camara='" + tca.Text.Trim() + "' and banda='" + tba.Text.Trim() + "' and columna ='" + tco.Text.Trim() + "' and piso='" + pisoa + "' and (estado<>'0' or aestado<>'0')"
            Dim dtHabil As DataTable = fnc.ListarTablasSQL(sqlHabil)
            If (dtHabil.Rows.Count > 0) Then
                Dim sqlHabil2 = "SELECT * FROM camaraMantenedor WHERE camara='" + tca.Text.Trim() + "' and banda='" + tba.Text.Trim() + "' and columna ='" + tco.Text.Trim() + "' and piso='" + pisoa + "' and estado<>'0'"
                Dim dtHabil2 As DataTable = fnc.ListarTablasSQL(sqlHabil2)
                If (dtHabil2.Rows.Count > 0) Then
                    MsgBox("El piso seleccionado se encuentra deshabilitado.", MsgBoxStyle.Information, "Piso Deshabilitado!")
                Else
                    MsgBox("El piso seleccionado se encuentra deshabilitado por diseño.", MsgBoxStyle.Information, "Piso Deshabilitado!")
                End If

                Exit Sub
            End If

            ''aquuuuuuuuuuuuuui
            Dim sql As String = "SELECT RACD_CODI,RACD_CA,frec_tipoalmacenamiento,pro_var FROM " & _
                        "VG_TIPOALMACEN_PALLET  WHERE racd_codi='" + txtpallet.Text.Trim() + "'"

            Dim tabla As DataTable = fnc.ListarTablasSQL(sql)


            If tabla.Rows.Count > 0 Then
                TIPOALAMACEN = tabla.Rows(0)(2).ToString()
                '            camara = tabla.Rows(0)(0).ToString()
                Dim sql3 As String = "SELECT tipo_Almacen FROM " & _
                        "CAMARACONF  WHERE CAMARA='" + tca.Text.Trim() + "'"

                Dim tabla3 As DataTable = fnc.ListarTablasSQL(sql3)


                If tabla3.Rows.Count > 0 Then


                    If TIPOALAMACEN.Trim() = tabla3.Rows(0)(0).ToString().Trim() Then
                        posss()
                    Else


                        If tabla.Rows(0)(3).ToString().Trim() = "SI" Then

                            posss()

                        Else

                            ' lmensaje.Text = ""
                            MsgBox("Camara definida para otro tipo de almacen", MsgBoxStyle.Critical, "Aviso")
                            Exit Sub


                        End If







                    End If

                End If



            End If






        Else
            ' lmensaje.Text = ""
            MsgBox("Esta Posicion No Se Encuentra Creada", MsgBoxStyle.Critical, "Aviso")
        End If
        'If fnc.verificaExistencia("camaraconf", "camara", CerosAnteriorString(Me.tca.Text, 2)) = True Then
        '    If tca.Text = "" Or tba.Text = "" Or tco.Text = "" Or tpi.Text = "" Then
        '        If tca.Text <> "05" AndAlso ckpasillo.CheckState = CheckState.Unchecked Then
        '            If tni.Text = "" Then
        '                MsgBox("Ingrese la posición completa", MsgBoxStyle.Critical, "Aviso")
        '                Exit Sub
        '            End If
        '        ElseIf ckpasillo.CheckState = CheckState.Checked Then
        '            If IsNumeric(tca.Text) Then
        '                If Convert.ToInt16(tca.Text) > 6 Or Convert.ToInt16(tca.Text) < 0 Then
        '                    MsgBox("El número de cámara no es correcto", MsgBoxStyle.Critical, "Aviso")
        '                Else
        '                    Dim pasillo_max As Integer = 0

        '                    If Convert.ToInt16(tca.Text) = 1 Or Convert.ToInt16(tca.Text) = 2 Then
        '                        pasillo_max = 4
        '                    ElseIf Convert.ToInt16(tca.Text) = 3 Or Convert.ToInt16(tca.Text) = 4 Then
        '                        pasillo_max = 6
        '                    ElseIf Convert.ToInt16(tca.Text) = 5 Or Convert.ToInt16(tca.Text) = 6 Then
        '                        pasillo_max = 1
        '                    Else
        '                        MsgBox("Pasillo incorrecto", MsgBoxStyle.Critical, "Aviso")
        '                        Exit Sub
        '                    End If


        '                    If Convert.ToInt16(tpas.Text) <= pasillo_max Then

        '                        'posicionar
        '                        Dim camara As String = Convert.ToInt16(tca.Text).ToString() + Convert.ToInt16(tpas.Text).ToString()

        '                        Dim fecha As String = devuelve_fecha(fnc.DevuelveFechaServidor())
        '                        Dim hora As String = (fnc.DevuelveFechaServidor()).ToString("HH:mm")



        '                        Dim TIPOALAMACEN As String = ""


        '                        Dim sql9 As String = "SELECT RACD_CODI,RACD_CA,frec_tipoalmacenamiento,pro_var FROM " & _
        '                   "VG_TIPOALMACEN_PALLET  WHERE racd_codi='" + txtpallet.Text.Trim() + "'"

        '                        Dim tabla As DataTable = fnc.ListarTablasSQL(sql9)


        '                        If tabla.Rows.Count > 0 Then
        '                            TIPOALAMACEN = tabla.Rows(0)(2).ToString()
        '                            '            camara = tabla.Rows(0)(0).ToString()
        '                            Dim sql3 As String = "SELECT tipo_Almacen FROM " & _
        '                                    "CAMARACONF  WHERE CAMARA='" + tca.Text.Trim() + "'"

        '                            Dim tabla3 As DataTable = fnc.ListarTablasSQL(sql3)


        '                            If tabla3.Rows.Count > 0 Then


        '                                If TIPOALAMACEN.Trim() <> tabla3.Rows(0)(0).ToString().Trim() Then

        '                                    If tabla.Rows(0)(3).ToString().Trim() = "SI" Then



        '                                    Else

        '                                        MsgBox("Camara definida para otro tipo de almace", MsgBoxStyle.Critical, "Aviso")
        '                                        Exit Sub


        '                                    End If

        '                                Else









        '                                End If

        '                            End If



        '                        End If








        '                        Dim SqlTrazabilidad As String = "INSERT INTO movpallet(mov_folio, mov_codper, mov_ca, mov_ba, mov_co, mov_pi, mov_ni, mov_fecha, mov_tipo, mov_hora)" & _
        '                                              "VALUES('" + CerosAnteriorString(txtpallet.Text, 9) + "','" + CerosAnteriorString(Frm_Principal.InfoUsuario.Text, 3) + "', " & _
        '                                              "'" + camara + "','00','00','00','0','" + fecha.ToString() + "','RM','" + hora.ToString() + "')"

        '                        If fnc.MovimientoSQL(SqlTrazabilidad) > 0 Then
        '                            Dim sql As String = "UPDATE rackdeta SET racd_ca='" + camara + "', racd_ba='00', racd_co='00', racd_pi='00', racd_ni='0' WHERE racd_codi='" + CerosAnteriorString(txtpallet.Text, 9) + "'"

        '                            If fnc.MovimientoSQL(sql) > 0 Then
        '                                Dim sqlDetarece As String = "UPDATE detarece SET drec_camara='" + camara + "',  drec_banda='00', drec_colum='00', drec_piso='00', drec_nivel='0' WHERE drec_codi='" + CerosAnteriorString(txtpallet.Text, 9) + "'"

        '                                fnc.MovimientoSQL(sqlDetarece)
        '                                MsgBox("Posicion actualizada", MsgBoxStyle.Information, "Aviso")
        '                                btn_nuevo_Click(sender, e)
        '                            End If
        '                        End If

        '                    Else
        '                        MsgBox("Pasillo incorrecto", MsgBoxStyle.Critical, "Aviso")
        '                        tpas.Focus()
        '                        tpas.SelectAll()
        '                        Exit Sub
        '                    End If

        '                End If
        '            Else
        '                MsgBox("Posición incorrecta", MsgBoxStyle.Critical, "Aviso")
        '            End If
        '        Else
        '            MsgBox("Ingrese la posición completa", MsgBoxStyle.Critical, "Aviso")
        '        End If
        '    Else
        '        If fnc.verificaExistencia("rackdeta", "racd_codi", CerosAnteriorString(txtpallet.Text, 9)) = True Then

        '            If verificarPosicion() = True Then
        '                If ca.Text = tca.Text AndAlso ba.Text = tba.Text AndAlso co.Text = tco.Text AndAlso pi.Text = tpi.Text AndAlso ni.Text = tni.Text Then
        '                    MsgBox("Esta guardando el pallet en la misma posicion", MsgBoxStyle.Critical, "Aviso")
        '                End If
        '                Dim fecha As String = devuelve_fecha(fnc.DevuelveFechaServidor())
        '                Dim hora As String = (fnc.DevuelveFechaServidor()).ToString("HH:mm")
        '                Dim SqlTrazabilidad As String = "INSERT INTO movpallet(mov_folio, mov_codper, mov_ca, " & _
        '                                      "mov_ba, mov_co, mov_pi, mov_ni, mov_fecha, mov_tipo, mov_hora)" & _
        '                                      "VALUES('" + CerosAnteriorString(txtpallet.Text, 9) + "','" + CerosAnteriorString(Frm_Principal.InfoUsuario.Text, 3) + "', " & _
        '                                      "'" + tca.Text + "','" + tba.Text + "','" + tco.Text + "'," & _
        '                                      "'" + Convert.ToInt32(tpi.Text).ToString() + "','" + tni.Text.ToUpper() + "'," & _
        '                                      "'" + fecha.ToString() + "','RM','" + hora.ToString() + "')"
        '                If fnc.MovimientoSQL(SqlTrazabilidad) > 0 Then
        '                    Dim sql As String = "UPDATE rackdeta SET racd_ca='" + tca.Text + "', racd_ba='" + tba.Text + "', " & _
        '                    "racd_co='" + tco.Text + "', racd_pi='" + Convert.ToInt32(tpi.Text).ToString() + "', " & _
        '                    "racd_ni='" + tni.Text + "' WHERE racd_codi='" + CerosAnteriorString(txtpallet.Text, 9) + "'"

        '                    If fnc.MovimientoSQL(sql) > 0 Then
        '                        Dim sqlDetarece As String = "UPDATE detarece SET drec_camara='" + tca.Text + "',  drec_banda='" + tba.Text + "', " & _
        '                                                "drec_colum='" + tco.Text + "', drec_piso='" + Convert.ToInt32(tpi.Text).ToString() + "', " & _
        '                                                "drec_nivel='" + tni.Text + "' WHERE drec_codi='" + CerosAnteriorString(txtpallet.Text, 9) + "'"

        '                        fnc.MovimientoSQL(sqlDetarece)
        '                        MsgBox("Posicion actualizada", MsgBoxStyle.Information, "Aviso")
        '                        btn_nuevo_Click(sender, e)
        '                    End If
        '                End If
        '            End If
        '        Else
        '            MsgBox("El pallet ingresado no existe", MsgBoxStyle.MsgBoxHelp, "Aviso")
        '        End If
        '    End If
        'Else
        '    MsgBox("La camara ingresada no existe", MsgBoxStyle.Critical, "Aviso")
        'End If
        ''btn_nuevo.Focus()






    End Sub

    Private Sub btn_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        LimpiarCajas(Me.GroupBox1)
        tni.Text = "F"
        txtpallet.Text = ""
        tba.Enabled = True
        tco.Enabled = True
        tpi.Enabled = True
        tni.Enabled = True
        ckpasillo.CheckState = CheckState.Unchecked
        txtpallet.Enabled = True
        txtpallet.Focus()
    End Sub

    Private Sub Frm_PosicionamientoManual_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        f_posicionamientomanual = False
    End Sub

    Private Sub ckpasillo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckpasillo.CheckedChanged
        If ckpasillo.CheckState = CheckState.Checked Then
            'Bloquea posicionamiento
            tba.Enabled = False
            tco.Enabled = False
            tpi.Enabled = False
            tni.Enabled = False
            tpas.Enabled = True
            tpas.Focus()
        Else
            'Activa posicionamiento
            tba.Enabled = True
            tco.Enabled = True
            tpi.Enabled = True
            tni.Enabled = True
            tpas.Enabled = False
            tba.Focus()
        End If
    End Sub

    Private Sub tpas_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tpas.KeyPress
        If e.KeyChar = ChrW(13) Then
            If tpas.Text <> "" Then
                Me.tpas.Text = CerosAnteriorString(Me.tpas.Text, 2)
                btn_guardar.Focus()
            End If
        Else
            SoloNumeros(sender, e)
        End If
    End Sub

    Private Sub Frm_PosicionamientoManual_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            btn_nuevo_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub tca_TextChanged(sender As System.Object, e As System.EventArgs) Handles tca.TextChanged




        If tca.Text = "1" Then
            tca.Text = "01"
        End If
        If tca.Text = "2" Then
            tca.Text = "02"
        End If

        If tca.Text = "3" Then
            tca.Text = "03"
        End If

        If tca.Text = "4" Then
            tca.Text = "04"
        End If

        If tca.Text = "5" Then
            tca.Text = "05"
        End If

        If tca.Text = "6" Then
            tca.Text = "06"
        End If

        If tca.Text = "7" Then
            tca.Text = "07"
        End If

        If tca.Text = "8" Then
            tca.Text = "08"
        End If

        If tca.Text = "9" Then
            tca.Text = "09"
        End If

        tca.Select(tca.Text.Length, 0)


        If tca.TextLength = 3 Then
            Dim camara As String
            Dim sscamara As String
            camara = tca.Text
            Dim str3 As String = camara.Substring(1, 2)
            tca.Text = str3

        End If

    End Sub

    Private Sub Frm_PosicionamientoManual_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        tca.MaxLength = 3
        tba.MaxLength = 3
        tco.MaxLength = 3

    End Sub

    Private Sub tba_TextChanged(sender As System.Object, e As System.EventArgs) Handles tba.TextChanged
        If tba.Text = "1" Then
            tba.Text = "01"
        End If
        If tba.Text = "2" Then
            tba.Text = "02"
        End If

        If tba.Text = "3" Then
            tba.Text = "03"
        End If

        If tba.Text = "4" Then
            tba.Text = "04"
        End If

        If tba.Text = "5" Then
            tba.Text = "05"
        End If

        If tba.Text = "6" Then
            tba.Text = "06"
        End If

        If tba.Text = "7" Then
            tba.Text = "07"
        End If

        If tba.Text = "8" Then
            tba.Text = "08"
        End If

        If tba.Text = "9" Then
            tba.Text = "09"
        End If

        tba.Select(tba.Text.Length, 0)


        If tba.TextLength = 3 Then
            Dim camara As String
            Dim sscamara As String
            camara = tba.Text
            Dim str3 As String = camara.Substring(1, 2)
            tba.Text = str3

        End If
    End Sub

    Private Sub tco_TextChanged(sender As System.Object, e As System.EventArgs) Handles tco.TextChanged
        If tco.Text = "1" Then
            tco.Text = "01"
        End If
        If tco.Text = "2" Then
            tco.Text = "02"
        End If

        If tco.Text = "3" Then
            tco.Text = "03"
        End If

        If tco.Text = "4" Then
            tco.Text = "04"
        End If

        If tco.Text = "5" Then
            tco.Text = "05"
        End If

        If tco.Text = "6" Then
            tco.Text = "06"
        End If

        If tco.Text = "7" Then
            tco.Text = "07"
        End If

        If tco.Text = "8" Then
            tco.Text = "08"
        End If

        If tco.Text = "9" Then
            tco.Text = "09"
        End If

        tco.Select(tco.Text.Length, 0)


        If tco.TextLength = 3 Then
            Dim camara As String
            Dim sscamara As String
            camara = tco.Text
            Dim str3 As String = camara.Substring(1, 2)
            tco.Text = str3

        End If
    End Sub

    Private Sub tpi_TextChanged(sender As Object, e As System.EventArgs) Handles tpi.TextChanged
        Try
            Dim Piso As String = tpi.Text.Trim
            Dim PisoFrm As Integer = 0
            If (Piso <> "") Then
                If (Not Integer.TryParse(Piso, PisoFrm)) Then
                    MsgBox("Debe ingresar un piso numerico.", MsgBoxStyle.Critical, "Error")

                    tpi.Text = ""
                    tpi.Focus()
                Else
                    tpi.Text = PisoFrm
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
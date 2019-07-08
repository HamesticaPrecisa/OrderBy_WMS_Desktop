Public Class Frm_ContratosDetalleEscala


    Dim fnc As New Funciones

    Function tramoIncom(ByVal num As Integer) As String
        Return "- Tramo " + num.ToString() + " la escala no corresponde" + vbNewLine
    End Function

    Function tramoIncor(ByVal num As Integer) As String
        Return "- Tramo " + num.ToString() + " incorrecto" + vbNewLine
    End Function

    Function tramoMay(ByVal num1 As Integer, ByVal num2 As Integer) As String
        Return "- El Tramo " + num1.ToString() + " es menor o igual al Tramo " + num2.ToString() + "" + vbNewLine
    End Function

    Function validacion()
        Dim mensaje As String = ""


        ' Valida Escala 1
        '=================
        If IsNumeric(escd1.Text) AndAlso IsNumeric(esch1.Text) Then
            If Convert.ToDouble(escd1.Text) >= Convert.ToDouble(esch1.Text) Then
                mensaje = mensaje + tramoIncom(1)
            End If
        Else
            mensaje = mensaje + tramoIncor(1)
        End If


        ' Valida Escala 2
        '=================
        If IsNumeric(escd2.Text) AndAlso IsNumeric(esch2.Text) Then
            If Convert.ToDouble(escd2.Text) >= Convert.ToDouble(esch2.Text) Then
                mensaje = mensaje + tramoIncom(2)
            End If
        Else
            mensaje = mensaje + tramoIncor(2)
        End If


        ' Valida Escala 3
        '=================
        If cbEscalas.SelectedValue >= 3 Then
            If IsNumeric(escd3.Text) AndAlso IsNumeric(esch3.Text) Then
                If Convert.ToDouble(escd3.Text) >= Convert.ToDouble(esch3.Text) Then
                    mensaje = mensaje + tramoIncom(3)
                End If
            Else
                mensaje = mensaje + tramoIncor(3)
            End If
        End If


        ' Valida Escala 4
        '=================
        If cbEscalas.SelectedValue >= 4 Then
            If IsNumeric(escd4.Text) AndAlso IsNumeric(esch4.Text) Then
                If Convert.ToDouble(escd4.Text) >= Convert.ToDouble(esch4.Text) Then
                    mensaje = mensaje + tramoIncom(4)
                End If
            Else
                mensaje = mensaje + tramoIncor(4)
            End If
        End If


        ' Valida Escala 5
        '=================
        If cbEscalas.SelectedValue >= 5 Then
            If IsNumeric(escd5.Text) AndAlso IsNumeric(esch5.Text) Then
                If Convert.ToDouble(escd5.Text) >= Convert.ToDouble(esch5.Text) Then
                    mensaje = mensaje + tramoIncom(5)
                End If
            Else
                mensaje = mensaje + tramoIncor(5)
            End If
        End If


        ' Valida Escala 6
        '=================
        If cbEscalas.SelectedValue >= 6 Then
            If IsNumeric(escd6.Text) AndAlso IsNumeric(esch6.Text) Then
                If Convert.ToDouble(escd6.Text) >= Convert.ToDouble(esch6.Text) Then
                    mensaje = mensaje + tramoIncom(6)
                End If
            Else
                mensaje = mensaje + tramoIncor(6)
            End If
        End If


        ' Valida Escala 7
        '=================
        If cbEscalas.SelectedValue >= 7 Then
            If IsNumeric(escd7.Text) AndAlso IsNumeric(esch7.Text) Then
                If Convert.ToDouble(escd7.Text) >= Convert.ToDouble(esch7.Text) Then
                    mensaje = mensaje + tramoIncom(7)
                End If
            Else
                mensaje = mensaje + tramoIncor(7)
            End If
        End If

        ' Valida Escala 8
        '=================
        If cbEscalas.SelectedValue >= 8 Then
            If IsNumeric(escd8.Text) AndAlso IsNumeric(esch8.Text) Then
                If Convert.ToDouble(escd8.Text) >= Convert.ToDouble(esch8.Text) Then
                    mensaje = mensaje + tramoIncom(8)
                End If
            Else
                mensaje = mensaje + tramoIncor(8)
            End If
        End If

        ' Valida Escala 9
        '=================
        If cbEscalas.SelectedValue >= 9 Then
            If IsNumeric(escd9.Text) AndAlso IsNumeric(esch9.Text) Then
                If Convert.ToDouble(escd9.Text) >= Convert.ToDouble(esch9.Text) Then
                    mensaje = mensaje + tramoIncom(9)
                End If
            Else
                mensaje = mensaje + tramoIncor(9)
            End If
        End If

        ' Valida Escala 10
        '=================
        If cbEscalas.SelectedValue >= 10 Then
            If IsNumeric(escd10.Text) AndAlso IsNumeric(esch10.Text) Then
                If Convert.ToDouble(escd10.Text) >= Convert.ToDouble(esch10.Text) Then
                    mensaje = mensaje + tramoIncom(10)
                End If
            Else
                mensaje = mensaje + tramoIncor(10)
            End If
        End If

        If mensaje.Length > 0 Then
            MsgBox("Falta lo siguiente antes de guardar" + vbNewLine + mensaje, MsgBoxStyle.Critical, "Aviso")
            Return False
            Exit Function
        End If

        ' Valida Escala 1 / 2
        If IsNumeric(esch1.Text) AndAlso IsNumeric(escd2.Text) Then
            If Convert.ToDouble(esch1.Text) >= Convert.ToDouble(escd2.Text) Then
                mensaje = mensaje + tramoMay(1, 2)
            End If
        Else
            mensaje = mensaje + tramoIncom(2)
        End If


        ' Valida Escala 2 / 3
        If cbEscalas.SelectedValue >= 3 Then
            If IsNumeric(esch2.Text) AndAlso IsNumeric(escd3.Text) Then
                If Convert.ToDouble(esch2.Text) >= Convert.ToDouble(escd3.Text) Then
                    mensaje = mensaje + tramoMay(2, 3)
                End If
            Else
                mensaje = mensaje + tramoIncom(3)
            End If
        End If


        ' Valida Escala 3 / 4
        If cbEscalas.SelectedValue >= 4 Then
            If IsNumeric(esch3.Text) AndAlso IsNumeric(escd4.Text) Then
                If Convert.ToDouble(esch3.Text) >= Convert.ToDouble(escd4.Text) Then
                    mensaje = mensaje + tramoMay(3, 4)
                End If
            Else
                mensaje = mensaje + tramoIncom(4)
            End If
        End If

        ' Valida Escala 4 / 5
        If cbEscalas.SelectedValue >= 5 Then
            If IsNumeric(esch4.Text) AndAlso IsNumeric(escd5.Text) Then
                If Convert.ToDouble(esch4.Text) >= Convert.ToDouble(escd5.Text) Then
                    mensaje = mensaje + tramoMay(4, 5)
                End If
            Else
                mensaje = mensaje + tramoIncom(5)
            End If
        End If

        ' Valida Escala 5 / 6
        If cbEscalas.SelectedValue >= 6 Then
            If IsNumeric(esch5.Text) AndAlso IsNumeric(escd6.Text) Then
                If Convert.ToDouble(esch5.Text) >= Convert.ToDouble(escd6.Text) Then
                    mensaje = mensaje + tramoMay(5, 6)
                End If
            Else
                mensaje = mensaje + tramoIncom(6)
            End If
        End If

        ' Valida Escala 6 / 7
        If cbEscalas.SelectedValue >= 7 Then
            If IsNumeric(esch6.Text) AndAlso IsNumeric(escd7.Text) Then
                If Convert.ToDouble(esch6.Text) >= Convert.ToDouble(escd7.Text) Then
                    mensaje = mensaje + tramoMay(6, 7)
                End If
            Else
                mensaje = mensaje + tramoIncom(7)
            End If
        End If

        ' Valida Escala 7 / 8
        If cbEscalas.SelectedValue >= 8 Then
            If IsNumeric(esch7.Text) AndAlso IsNumeric(escd8.Text) Then
                If Convert.ToDouble(esch7.Text) >= Convert.ToDouble(escd8.Text) Then
                    mensaje = mensaje + tramoMay(7, 8)
                End If
            Else
                mensaje = mensaje + tramoIncom(8)
            End If
        End If

        ' Valida Escala 8 / 9
        If cbEscalas.SelectedValue >= 9 Then
            If IsNumeric(esch8.Text) AndAlso IsNumeric(escd9.Text) Then
                If Convert.ToDouble(esch8.Text) >= Convert.ToDouble(escd9.Text) Then
                    mensaje = mensaje + tramoMay(8, 9)
                End If
            Else
                mensaje = mensaje + tramoIncom(9)
            End If
        End If

        ' Valida Escala 9 / 10
        If cbEscalas.SelectedValue >= 10 Then
            If IsNumeric(esch9.Text) AndAlso IsNumeric(escd10.Text) Then
                If Convert.ToDouble(esch9.Text) >= Convert.ToDouble(escd10.Text) Then
                    mensaje = mensaje + tramoMay(9, 10)
                End If
            Else
                mensaje = mensaje + tramoIncom(10)
            End If
        End If


        If mensaje = "" Then
            Return True
        Else
            MsgBox("Debe normalizar lo siguiente antes de continuar" + vbNewLine + mensaje, MsgBoxStyle.Critical, "Aviso")
            Return False
        End If
    End Function

    Private Sub Btn_Guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Guardar.Click

        'Primero valido

        If validacion() = False Then
            Exit Sub
        End If



        Dim sqlVeri As String = "SELECT * FROM FacEscalas WHERE esc_contr='" + txtcontratocod.Text + "' AND esc_servi='" + txtcodservicio.Text + "'"
        Dim tabla As DataTable = fnc.ListarTablasSQL(sqlVeri)


        If tabla.Rows.Count > 0 Then
            'Existe

            Dim sql As String = "UPDATE FacEscalas SET esc_ntramos='" + cbEscalas.SelectedValue.ToString() + "', " +
                               "esc_dtramo1='" + ValidaCero(escd1.Text) + "', esc_htramo1='" + ValidaCero(esch1.Text) + "', esc_valor1='" + ValidaCero(escv1.Text) + "', " +
                               "esc_dtramo2='" + ValidaCero(escd2.Text) + "', esc_htramo2='" + ValidaCero(esch2.Text) + "', esc_valor2='" + ValidaCero(escv2.Text) + "', " +
                               "esc_dtramo3='" + ValidaCero(escd3.Text) + "', esc_htramo3='" + ValidaCero(esch3.Text) + "', esc_valor3='" + ValidaCero(escv3.Text) + "', " +
                               "esc_dtramo4='" + ValidaCero(escd4.Text) + "', esc_htramo4='" + ValidaCero(esch4.Text) + "', esc_valor4='" + ValidaCero(escv4.Text) + "', " +
                               "esc_dtramo5='" + ValidaCero(escd5.Text) + "', esc_htramo5='" + ValidaCero(esch5.Text) + "', esc_valor5='" + ValidaCero(escv5.Text) + "', " +
                               "esc_dtramo6='" + ValidaCero(escd6.Text) + "', esc_htramo6='" + ValidaCero(esch6.Text) + "', esc_valor6='" + ValidaCero(escv6.Text) + "', " +
                               "esc_dtramo7='" + ValidaCero(escd7.Text) + "', esc_htramo7='" + ValidaCero(esch7.Text) + "', esc_valor7='" + ValidaCero(escv7.Text) + "', " +
                               "esc_dtramo8='" + ValidaCero(escd8.Text) + "', esc_htramo8='" + ValidaCero(esch8.Text) + "', esc_valor8='" + ValidaCero(escv8.Text) + "', " +
                               "esc_dtramo9='" + ValidaCero(escd9.Text) + "', esc_htramo9='" + ValidaCero(esch9.Text) + "', esc_valor9='" + ValidaCero(escv9.Text) + "', " +
                               "esc_dtramo10='" + ValidaCero(escd10.Text) + "', esc_htramo10='" + ValidaCero(esch10.Text) + "', esc_valor10='" + ValidaCero(escv10.Text) + "' " +
                               "WHERE esc_contr='" + txtcontratocod.Text + "' AND esc_servi='" + txtcodservicio.Text + "'"

            If fnc.MovimientoSQL(sql) > 0 Then
                MsgBox("Grabación Exitosa", MsgBoxStyle.Information, "Aviso")
            Else
                MsgBox("Error al grabar la información", MsgBoxStyle.Critical, "Aviso")
            End If

        Else
            'No Existe

            Dim sql As String = "INSERT INTO FacEscalas(esc_contr, esc_servi, esc_ntramos, " +
                                "esc_dtramo1, esc_htramo1, esc_valor1, esc_dtramo2, esc_htramo2, esc_valor2, esc_dtramo3, esc_htramo3, esc_valor3, " +
                                "esc_dtramo4, esc_htramo4, esc_valor4, esc_dtramo5, esc_htramo5, esc_valor5, esc_dtramo6, esc_htramo6, esc_valor6, " +
                                "esc_dtramo7, esc_htramo7, esc_valor7, esc_dtramo8, esc_htramo8, esc_valor8, esc_dtramo9, esc_htramo9, esc_valor9, " +
                                "esc_dtramo10, esc_htramo10, esc_valor10)VALUES('" + txtcontratocod.Text + "','" + txtcodservicio.Text + "','" + cbEscalas.SelectedValue.ToString() + "'," +
                                "'" + ValidaCero(escd1.Text) + "','" + ValidaCero(esch1.Text) + "','" + ValidaCero(escv1.Text) + "'," +
                                "'" + ValidaCero(escd2.Text) + "','" + ValidaCero(esch2.Text) + "','" + ValidaCero(escv2.Text) + "', " +
                                "'" + ValidaCero(escd3.Text) + "','" + ValidaCero(esch3.Text) + "','" + ValidaCero(escv3.Text) + "', " +
                                "'" + ValidaCero(escd4.Text) + "','" + ValidaCero(esch4.Text) + "','" + ValidaCero(escv4.Text) + "', " +
                                "'" + ValidaCero(escd5.Text) + "','" + ValidaCero(esch5.Text) + "','" + ValidaCero(escv5.Text) + "', " +
                                "'" + ValidaCero(escd6.Text) + "','" + ValidaCero(esch6.Text) + "','" + ValidaCero(escv6.Text) + "', " +
                                "'" + ValidaCero(escd7.Text) + "','" + ValidaCero(esch7.Text) + "','" + ValidaCero(escv7.Text) + "', " +
                                "'" + ValidaCero(escd8.Text) + "','" + ValidaCero(esch8.Text) + "','" + ValidaCero(escv8.Text) + "', " +
                                "'" + ValidaCero(escd9.Text) + "','" + ValidaCero(esch9.Text) + "','" + ValidaCero(escv9.Text) + "', " +
                                "'" + ValidaCero(escd10.Text) + "','" + ValidaCero(esch10.Text) + "','" + ValidaCero(escv10.Text) + "') "

            If fnc.MovimientoSQL(sql) > 0 Then
                MsgBox("Grabación Exitosa", MsgBoxStyle.Information, "Aviso")
            Else
                MsgBox("Error al grabar la información", MsgBoxStyle.Critical, "Aviso")
            End If

        End If
    End Sub

    Function ValidaCero(ByVal codigo As String) As String
        ValidaCero = "0"
        If IsNumeric(codigo.Trim) Then
            ValidaCero = codigo
        End If
        Return ValidaCero
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub Frm_ContratosDetalleEscala_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim dt As New DataTable
        dt.Columns.Add("cod")
        dt.Columns.Add("desc")

        For i = 2 To 10
            dt.Rows.Add(i.ToString(), CerosAnteriorString(i.ToString(), 2))
        Next

        cbEscalas.DataSource = dt
        cbEscalas.DisplayMember = "desc"
        cbEscalas.ValueMember = "cod"
        cbEscalas.SelectedValue = 2

        Dim sql As String = "SELECT esc_ntramos, esc_dtramo1, esc_htramo1, esc_valor1, esc_dtramo2, esc_htramo2, esc_valor2, esc_dtramo3, esc_htramo3, esc_valor3, esc_dtramo4, esc_htramo4, esc_valor4, esc_dtramo5, esc_htramo5, esc_valor5, esc_dtramo6, esc_htramo6, esc_valor6, esc_dtramo7, esc_htramo7, esc_valor7, esc_dtramo8, esc_htramo8, esc_valor8, esc_dtramo9, esc_htramo9, esc_valor9, esc_dtramo10, esc_htramo10, esc_valor10, cont_descr, Serv_descr FROM FacEscalas INNER JOIN contrato ON cont_codi=esc_contr INNER JOIN FacServicios ON Serv_Cod=esc_servi WHERE cont_codi='" + txtcontratocod.Text + "' AND esc_servi='" + txtcodservicio.Text + "'"

        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

        If tabla.Rows.Count > 0 Then

            cbEscalas.SelectedValue = tabla.Rows(0)(0).ToString()

            escd1.Text = tabla.Rows(0)(1).ToString()
            esch1.Text = tabla.Rows(0)(2).ToString()
            escv1.Text = tabla.Rows(0)(3).ToString()

            escd2.Text = tabla.Rows(0)(4).ToString()
            esch2.Text = tabla.Rows(0)(5).ToString()
            escv2.Text = tabla.Rows(0)(6).ToString()

            escd3.Text = tabla.Rows(0)(7).ToString()
            esch3.Text = tabla.Rows(0)(8).ToString()
            escv3.Text = tabla.Rows(0)(9).ToString()

            escd4.Text = tabla.Rows(0)(10).ToString()
            esch4.Text = tabla.Rows(0)(11).ToString()
            escv4.Text = tabla.Rows(0)(12).ToString()

            escd5.Text = tabla.Rows(0)(13).ToString()
            esch5.Text = tabla.Rows(0)(14).ToString()
            escv5.Text = tabla.Rows(0)(15).ToString()

            escd6.Text = tabla.Rows(0)(16).ToString()
            esch6.Text = tabla.Rows(0)(17).ToString()
            escv6.Text = tabla.Rows(0)(18).ToString()

            escd7.Text = tabla.Rows(0)(19).ToString()
            esch7.Text = tabla.Rows(0)(20).ToString()
            escv7.Text = tabla.Rows(0)(21).ToString()

            escd8.Text = tabla.Rows(0)(22).ToString()
            esch8.Text = tabla.Rows(0)(23).ToString()
            escv8.Text = tabla.Rows(0)(24).ToString()

            escd9.Text = tabla.Rows(0)(25).ToString()
            esch9.Text = tabla.Rows(0)(26).ToString()
            escv9.Text = tabla.Rows(0)(27).ToString()

            escd10.Text = tabla.Rows(0)(28).ToString()
            esch10.Text = tabla.Rows(0)(29).ToString()
            escv10.Text = tabla.Rows(0)(30).ToString()


        End If

    End Sub

    Private Sub t1valor_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        SoloKilos(sender, e)
    End Sub

    Private Sub cbEscalas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbEscalas.SelectedIndexChanged

        If Not IsNumeric(cbEscalas.SelectedValue) Then
            Exit Sub
        End If

        Dim i As Integer = 1
        For Each row As Control In GroupBox2.Controls
            Dim tb As Control

            tb = DirectCast(GetReference("Panel" + (i).ToString()), Panel)
            tb.Enabled = True

            If i > cbEscalas.SelectedValue Then
                tb.Enabled = False
                For Each r As Control In tb.Controls
                    If TypeOf r Is TextBox Then
                        r.Text = "0"
                    End If

                Next
            End If
            i += 1
            If i > 10 Then
                Exit For
            End If
        Next

    End Sub

    Private Function GetReference(ByVal nombreControl As String) As Control

        ' Recorremos la colección de controles del formulario
        '
        For Each ctrl As Control In Me.GroupBox2.Controls
            If ctrl.Name.ToLower = nombreControl.ToLower Then
                ' Devolvemos la referencia y abandonamos la función
                Return ctrl
            End If
        Next
        Return Nothing
    End Function

    Private Sub soloNum(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles escv9.KeyPress, escv8.KeyPress, escv7.KeyPress, escv6.KeyPress, escv5.KeyPress, escv4.KeyPress, escv3.KeyPress, escv2.KeyPress, escv10.KeyPress, escv1.KeyPress, esch9.KeyPress, esch8.KeyPress, esch7.KeyPress, esch6.KeyPress, esch5.KeyPress, esch4.KeyPress, esch3.KeyPress, esch2.KeyPress, esch10.KeyPress, esch1.KeyPress, escd9.KeyPress, escd8.KeyPress, escd7.KeyPress, escd6.KeyPress, escd5.KeyPress, escd4.KeyPress, escd3.KeyPress, escd2.KeyPress, escd10.KeyPress, escd1.KeyPress
        If " " = e.KeyChar Then
            e.Handled = True
        End If
        SoloKilos(sender, e)
    End Sub

    Private Sub Frm_ContratosDetalleEscala_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F5 Then
            Btn_Guardar.PerformClick()
        ElseIf e.KeyCode = Keys.Escape Then
            Btn_Salir.PerformClick()
        End If
    End Sub

    Private Sub Btn_Salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Salir.Click
        Close()
    End Sub
End Class
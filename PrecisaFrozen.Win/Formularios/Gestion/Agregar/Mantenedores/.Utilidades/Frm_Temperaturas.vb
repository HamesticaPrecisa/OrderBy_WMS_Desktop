Public Class Frm_Temperaturas

    Public temperatura_gracia As Integer = 0
    Public Modalidad As String = ""

    Dim fnc As New Funciones
    Public fecha_rece As Date
    Dim canttemp As String = "0"
    Dim rangoxcong As String = "0"
    Dim rangoycong As String = "0"
    Dim rangoxrefri As String = "0"
    Dim rangoyrefri As String = "0"
    Dim rangoxseco As String = "0"
    Dim rangoyseco As String = "0"



    Private Sub DataGridView1_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvTemp.CellEndEdit
        If Not IsNothing(Me.DgvTemp.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) Then
            If Modalidad = "AGREGADA" Then
                'If RealizarAccion("001", "058", True) = False Then
                '    Exit Sub
                'End If
                If Not IsNumeric(Me.DgvTemp.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString()) Then
                    Me.DgvTemp.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = 0.0
                End If

                Dim PROM As Double = 0
                Dim TOTAL As Integer = 0
                For i As Integer = 0 To DgvTemp.Rows.Count - 1
                    If Not Me.DgvTemp.Rows(i).Cells(e.ColumnIndex).Value = 0.0 Then
                        PROM = PROM + Convert.ToDouble(DgvTemp.Rows(i).Cells("TEMP").Value.ToString().Replace(".", ","))
                        TOTAL = TOTAL + 1
                    End If
                Next

                Dim rece As String = DgvTemp.CurrentRow.Cells(0).Value.ToString.Remove(7, 2)
                Dim pallet As String = DgvTemp.CurrentRow.Cells(0).Value.ToString.Remove(0, 7)

                'Log Temperatura Recepcion 28-05-19
                Dim sqlTempLog As String = "SP_Log_Temperaturas_Grabar '" & DgvTemp.CurrentRow.Cells(e.ColumnIndex - 1).Value.ToString() & "','" & DgvTemp.CurrentRow.Cells(e.ColumnIndex).Value.ToString.Replace(",", ".") & "','" & Frm_Principal.InfoUsuario.Text.Trim & "'"
                fnc.MovimientoSQL(sqlTempLog)
                'Fin log Temperatura Recepcion 28-05-19


                Dim sql As String = "UPDATE DETARECE SET drec_temp='" + DgvTemp.CurrentRow.Cells(e.ColumnIndex).Value.ToString.Replace(",", ".") + "' " +
                    "WHERE drec_codi='" + DgvTemp.CurrentRow.Cells(e.ColumnIndex - 1).Value.ToString() + "'"
                fnc.MovimientoSQL(sql)
                If Frm_GuiaRecepcionAgregar.Cmbo_Almacenamiento.Text.Trim() = "CONGELADO" Then
                    If Frm_GuiaRecepcionAgregar.CmboTuneles.Text.Trim() = "A TUNEL" Then
                    Else
                        If Convert.ToDouble(DgvTemp.CurrentRow.Cells(e.ColumnIndex).Value.ToString.Replace(".", ",")) > temperatura_gracia Then
                            DgvTemp.CurrentRow.Cells(1).Style.ForeColor = Color.Red
                        Else
                            DgvTemp.CurrentRow.Cells(1).Style.ForeColor = Color.Black
                        End If
                    End If
                End If
                If TOTAL > 0 Then
                    Promedio.Text = (PROM / TOTAL)
                    Promedio.Text = FormatNumber(Promedio.Text, 2).Replace(",", ".")
                    Cant.Text = TOTAL.ToString()
                Else
                    Promedio.Text = "0.00"
                    Cant.Text = "0"
                End If

            ElseIf Modalidad = "TEMPORAL" Then
                If Not IsNumeric(Me.DgvTemp.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString()) Then
                    Me.DgvTemp.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = 0.0
                End If
                If Frm_GuiaRecepcionAgregar.Cmbo_Almacenamiento.Text.Trim() = "CONGELADO" Then

                    If Frm_GuiaRecepcionAgregar.CmboTuneles.Text.Trim() = "A TUNEL" Then
                    Else

                        If Me.DgvTemp.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString.Replace(".", ",") <= Convert.ToInt32(rangoxcong) Or Me.DgvTemp.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString.Replace(".", ",") > Convert.ToInt32(rangoycong) Then
                            MsgBox("Debe ingresar un rango de temperatura entre " + rangoxcong + " y " + rangoycong, MsgBoxStyle.Critical, "Aviso")
                            Me.DgvTemp.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = 0.0
                            Exit Sub
                        End If
                    End If
                End If
                If Frm_GuiaRecepcionAgregar.Cmbo_Almacenamiento.Text.Trim() = "REFRIGERADO" Then
                    If Me.DgvTemp.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString.Replace(".", ",") <= Convert.ToInt32(rangoxrefri) Or Me.DgvTemp.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString.Replace(".", ",") > Convert.ToInt32(rangoyrefri) Then
                        MsgBox("Debe ingresar un rango de temperatura entre " + rangoxrefri + " y " + rangoyrefri, MsgBoxStyle.Critical, "Aviso")
                        Me.DgvTemp.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = 0.0
                        Exit Sub
                    End If
                End If

                If Frm_GuiaRecepcionAgregar.Cmbo_Almacenamiento.Text.Trim() = "SECO" Then
                    If Me.DgvTemp.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString.Replace(".", ",") <= Convert.ToInt32(rangoxseco) Or Me.DgvTemp.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString.Replace(".", ",") > Convert.ToInt32(rangoyseco) Then
                        MsgBox("Debe ingresar un rango de temperatura entre " + rangoxseco + " y " + rangoyseco, MsgBoxStyle.Critical, "Aviso")
                        Me.DgvTemp.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = 0.0
                        Exit Sub
                    End If
                End If



                Dim PROM As Double = 0
                Dim TOTAL As Integer = 0
                For i As Integer = 0 To DgvTemp.Rows.Count - 1
                    If Not Me.DgvTemp.Rows(i).Cells(e.ColumnIndex).Value = 0.0 Then
                        PROM = PROM + Convert.ToDouble(DgvTemp.Rows(i).Cells("TEMP").Value.ToString().Replace(".", ","))
                        TOTAL = TOTAL + 1
                    End If
                Next

                Dim rece As String = DgvTemp.CurrentRow.Cells(0).Value.ToString.Remove(7, 2)
                Dim pallet As String = DgvTemp.CurrentRow.Cells(0).Value.ToString.Remove(0, 7)

                'Log Temperatura Recepcion 28-05-19
                Dim sqlTempLog As String = "SP_Log_Temperaturas_Grabar '" & pallet & "','" & DgvTemp.CurrentRow.Cells(e.ColumnIndex).Value.ToString.Replace(",", ".") & "','" & Frm_Principal.InfoUsuario.Text.Trim & "'"
                fnc.MovimientoSQL(sqlTempLog)
                'Fin log Temperatura Recepcion 28-05-19


                Dim sql As String = "UPDATE TMPDETARECE SET drec_temp='" + DgvTemp.CurrentRow.Cells(e.ColumnIndex).Value.ToString.Replace(",", ".") + "' " +
                    "WHERE frec_codi='" + rece + "' AND drec_codi='" + pallet + "'"
                fnc.MovimientoSQL(sql)
                If Frm_GuiaRecepcionAgregar.Cmbo_Almacenamiento.Text.Trim() = "CONGELADO" Then

                    If Frm_GuiaRecepcionAgregar.CmboTuneles.Text.Trim() = "A TUNEL" Then
                    Else

                        If Convert.ToDouble(DgvTemp.CurrentRow.Cells(e.ColumnIndex).Value.ToString.Replace(".", ",")) > temperatura_gracia Then
                            DgvTemp.CurrentRow.Cells(1).Style.ForeColor = Color.Red
                        Else
                            DgvTemp.CurrentRow.Cells(1).Style.ForeColor = Color.Black
                        End If
                    End If
                End If
                If TOTAL > 0 Then
                    Promedio.Text = (PROM / TOTAL)
                    Promedio.Text = FormatNumber(Promedio.Text, 2).Replace(",", ".")
                    Cant.Text = TOTAL.ToString()
                Else
                    Promedio.Text = "0.00"
                    Cant.Text = "0"
                End If
            Else
                Me.DgvTemp.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = 0.0
            End If
        End If
    End Sub

    Private Sub DataGridView1_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DgvTemp.EditingControlShowing
        ' referencia a la celda  
        Dim validar As TextBox = CType(e.Control, TextBox)

        ' agregar el controlador de eventos para el KeyPress  
        AddHandler validar.KeyPress, AddressOf validar_Keypress
    End Sub

    Private Sub validar_Keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        ' evento Keypress  
        ' obtener indice de la columna  
        Dim columna As Integer = DgvTemp.CurrentCell.ColumnIndex
        ' comprobar si la celda en edición corresponde a la columna 1 o 2
        If columna = 1 Or columna = 2 Then
            ' Obtener caracter  
            ' Dim x As Char = e.KeyChar
            Dim x As TextBox = CType(sender, TextBox)
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
        End If
    End Sub

    Private Sub DataGridView1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DgvTemp.KeyPress
        'Dim x As TextBox = sender
        'If Not IsNumeric(e) Then
        '    If e.KeyChar = "." Or e.KeyChar = ChrW(8) Or e.KeyChar = "-" Then
        '        For i As Integer = 0 To x.Text.Length - 1
        '            If x.Text.Chars(i) = e.KeyChar Then
        '                SoloNumeros(sender, e)
        '            ElseIf x.Text.Chars(i) = e.KeyChar Then
        '                SoloNumeros(sender, e)
        '            ElseIf x.Text.Chars(i) = e.KeyChar Then
        '                SoloNumeros(sender, e)
        '            End If
        '        Next
        '    Else
        '        SoloNumeros(sender, e)
        '    End If
        'End If
    End Sub

    Private Sub Frm_Temperaturas_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim valores As String = CerosAnteriorString(Cant.Text, 2) + "" + Promedio.Text.Replace(",", ".")
        Dim _formInterface As IForm = CType(Me.Owner, IForm)
        _formInterface.ChangeTextBoxText(valores)
    End Sub

    Private Sub Frm_Temperaturas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F2 Then

            Dim limite_modificar As DateTime = devuelve_fecha_Formato2(Convert.ToDateTime(fecha_rece).AddDays(1)) + " 13:00:00"
            Dim fecha As DateTime = fnc.DevuelveFechaServidor()

            Dim validador As Integer = 0

            If devuelve_fecha(fecha_rece) <> devuelve_fecha(fecha) Then
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
            Else
                DgvTemp.Enabled = True
            End If

        End If
    End Sub

    Private Sub Frm_Temperaturas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim PROM As Double = 0
        Dim TOTAL As Integer = 0
        For i As Integer = 0 To DgvTemp.Rows.Count - 1

            If Frm_GuiaRecepcionAgregar.Cmbo_Almacenamiento.Text.Trim() = "CONGELADO" Then
                If Frm_GuiaRecepcionAgregar.CmboTuneles.Text.Trim() = "A TUNEL" Then
                Else
                    If DgvTemp.Rows(i).Cells(1).Value.ToString() > temperatura_gracia Then
                        DgvTemp.Rows(i).Cells(1).Style.ForeColor = Color.Red
                    Else
                        DgvTemp.Rows(i).Cells(1).Style.ForeColor = Color.Black
                    End If
                End If
            End If


            If Not Me.DgvTemp.Rows(i).Cells(1).Value = 0.0 Then
                PROM = PROM + Convert.ToDouble(DgvTemp.Rows(i).Cells("TEMP").Value.ToString().Replace(".", ","))
                TOTAL = TOTAL + 1
            End If
        Next
        If TOTAL > 0 Then
            Promedio.Text = (PROM / TOTAL)
            Promedio.Text = FormatNumber(Promedio.Text, 1).Replace(",", ".")
            Cant.Text = TOTAL.ToString()
        Else
            Promedio.Text = "0"
            Cant.Text = "0.00"
        End If

        Dim sql2 As String = "SELECT * from conf_temp "

        Dim tabla2 As DataTable = fnc.ListarTablasSQL(sql2)
        If tabla2.Rows.Count > 0 Then
            canttemp = tabla2.Rows(0)(0).ToString()
            rangoxcong = tabla2.Rows(0)(1).ToString()
            rangoycong = tabla2.Rows(0)(2).ToString()
            rangoxrefri = tabla2.Rows(0)(3).ToString()
            rangoyrefri = tabla2.Rows(0)(4).ToString()
            rangoxseco = tabla2.Rows(0)(5).ToString()
            rangoyseco = tabla2.Rows(0)(6).ToString()





        End If






    End Sub
End Class
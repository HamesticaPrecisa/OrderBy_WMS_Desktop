Public Class Frm_AddPedidosxTramo
    Dim fnc As New Funciones
    Private Sub Frm_AddPedidosxTramo_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'Dim sql As String = "SELECT * from maetramos "
        Dim sql As String = "select distinct b.Descripcion,a.Cantidad,b.Duracion from m_horario a with(nolock) inner join m_tipo_carga b with(nolock) on(a.IdTipoCarga=b.IdTipoCarga)"
        Dim tsbls As DataTable = fnc.ListarTablasSQL(sql)

        If tsbls.Rows.Count > 0 Then
            'TextBox1.Text = tsbls.Rows(0)(0).ToString()
            'TextBox2.Text = tsbls.Rows(0)(1).ToString()

            For i = 0 To tsbls.Rows.Count - 1
                Dim Carga As String = tsbls.Rows(i).Item(0).ToString.Trim
                Dim Cantidad As String = tsbls.Rows(i).Item(1).ToString.Trim
                Dim Minutos As String = tsbls.Rows(i).Item(2).ToString.Trim

                If (Carga = "Manual") Then
                    txtCamMan.Text = Cantidad
                    cboMinMan.SelectedItem = Minutos
                End If

                If (Carga = "Mecanica") Then
                    txtCamMec.Text = Cantidad
                    cboMinMec.SelectedItem = Minutos
                End If

                If (Carga = "Levantar") Then
                    txtCamLev.Text = Cantidad
                    cboMinLev.SelectedItem = Minutos
                End If
            Next

            'Dim strString(cboMinMan.Items.Count - 1) As String
            'Dim valor As String = ""
            'Dim valor2 As String = tsbls.Rows(0)(2).ToString().Trim()
            'For i As Integer = 0 To cboMinMan.Items.Count - 1
            '    cboMinMan.SelectedIndex = i
            '    strString(i) = cboMinMan.Text
            '    valor = cboMinMan.Text
            '    If valor = tsbls.Rows(0)(2).ToString().Trim() Then
            '        Exit For
            '    End If

            'Next
            'For i As Integer = 0 To cboMinMec.Items.Count - 1
            '    cboMinMec.SelectedIndex = i
            '    strString(i) = cboMinMec.Text
            '    valor = cboMinMec.Text
            '    If valor = tsbls.Rows(0)(3).ToString().Trim() Then
            '        Exit For
            '    End If

            'Next


        End If
    End Sub

    Private Sub TextBox1_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCamMan.KeyPress
        SoloNumeros(sender, e)
    End Sub

    Private Sub TextBox2_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCamMec.KeyPress
        SoloNumeros(sender, e)
    End Sub

    Private Sub btn_guardar_Click(sender As System.Object, e As System.EventArgs) Handles btn_guardar.Click
        'If txtCamMan.Text = "" Or txtCamMec.Text = "" Then

        '    MsgBox("Debe ingresar todos los datos ", MsgBoxStyle.Critical, "Aviso")
        'Else
        '    Dim sqltramo As String = "UPDATE maetramos SET manual_camiones='" + txtCamMan.Text.Trim() + "', meca_camiones='" + txtCamMec.Text.Trim() + "' ,manual_tramo ='" + cboMinMan.Text.Trim() + "',meca_tramo ='" + cboMinMec.Text.Trim() + "' "
        '    fnc.MovimientoSQL(sqltramo)
        '    MsgBox("Actualizado correctamente", MsgBoxStyle.Information, "Aviso")

        '    Dim sqllogtramo As String = "INSERT INTO log_maetramos(manual_camiones, Meca_Camiones, Manual_Tramo, Meca_Tramo, fecha_modificado, usr_mod, pc_mod)" +
        '                                           "VALUES('" + txtCamMan.Text.Trim() + "','" + txtCamMec.Text.Trim() + "','" + cboMinMan.Text.Trim() + "','" + cboMinMec.Text.Trim() + "','" + devuelve_fecha(fnc.DevuelveFechaServidor()) + "'," +
        '                "'" + Frm_Principal.InfoUsuario.Text + "','" + My.Computer.Name.ToString() + "')"

        '    fnc.MovimientoSQL(sqllogtramo)

        'End If

        Try
            Dim ErrMsj As String = "Errores encontrados:" & vbCrLf
            Dim ErrCoun As Integer = 0

            Dim MinLev As String = cboMinLev.SelectedItem
            If (MinLev = "") Then
                ErrMsj &= "Debe ingresar cantidad de minutos de carga levantar." & vbCrLf
                ErrCoun += 1
                cboMinLev.Focus()
            End If

            Dim CamLev As String = txtCamLev.Text.Trim
            If (CamLev = "") Then
                ErrMsj &= "Debe ingresar cantidad de camiones de carga levantar." & vbCrLf
                ErrCoun += 1
                txtCamLev.Focus()
            Else
                Dim CamLevFrm As Integer = 0
                If (Not Integer.TryParse(CamLev, CamLevFrm)) Then
                    ErrMsj &= "Debe ingresar cantidad valida de camiones de carga levantar." & vbCrLf
                    ErrCoun += 1
                    txtCamLev.Text = ""
                    txtCamLev.Focus()
                End If
            End If

            Dim MinMec As String = cboMinMec.SelectedItem
            If (MinMec = "") Then
                ErrMsj &= "Debe ingresar cantidad de minutos de carga mecánica." & vbCrLf
                ErrCoun += 1
                cboMinMec.Focus()
            End If

            Dim CamMec As String = txtCamMec.Text.Trim
            If (CamMec = "") Then
                ErrMsj &= "Debe ingresar cantidad de camiones de carga mecánica." & vbCrLf
                ErrCoun += 1
                txtCamMec.Focus()
            Else
                Dim CamMecFrm As Integer = 0
                If (Not Integer.TryParse(CamMec, CamMecFrm)) Then
                    ErrMsj &= "Debe ingresar cantidad valida de camiones de carga mecánica." & vbCrLf
                    ErrCoun += 1
                    txtCamMec.Text = ""
                    txtCamMec.Focus()
                End If
            End If

            Dim MinMan As String = cboMinMan.SelectedItem
            If (MinMan = "") Then
                ErrMsj &= "Debe ingresar cantidad de minutos de carga manual." & vbCrLf
                ErrCoun += 1
                cboMinMan.Focus()
            End If

            Dim CamMan As String = txtCamMan.Text.Trim
            If (CamMan = "") Then
                ErrMsj &= "Debe ingresar cantidad de camiones de carga manual." & vbCrLf
                ErrCoun += 1
                txtCamMan.Focus()
            Else
                Dim CamManFrm As Integer = 0
                If (Not Integer.TryParse(CamMan, CamManFrm)) Then
                    ErrMsj &= "Debe ingresar cantidad valida de camiones de carga manual." & vbCrLf
                    ErrCoun += 1
                    txtCamMan.Text = ""
                    txtCamMan.Focus()
                End If
            End If

            If (ErrCoun <> 0) Then
                MsgBox(ErrMsj, MsgBoxStyle.Critical, "Aviso")
            Else
                Dim sql As String = ""

                For i = 1 To 3
                    If (i = 1) Then
                        sql = "update m_tipo_carga set Duracion='" & MinMan & "' where Descripcion='Manual';update m_horario set Cantidad='" & CamMan & "' where IdTipoCarga='2';"
                    ElseIf (i = 2) Then
                        sql = "update m_tipo_carga set Duracion='" & MinMec & "' where Descripcion='Mecanica';update m_horario set Cantidad='" & CamMec & "' where IdTipoCarga='1';"
                    ElseIf (i = 3) Then
                        sql = "update m_tipo_carga set Duracion='" & MinLev & "' where Descripcion='Levantar';update m_horario set Cantidad='" & CamLev & "' where IdTipoCarga='3';"
                    End If

                    fnc.MovimientoSQL(sql)
                Next

                If (ErrCoun <> 0) Then
                    MsgBox(ErrMsj, MsgBoxStyle.Critical, "Aviso")
                Else
                    MsgBox("Datos guardados con éxito.", MsgBoxStyle.Information, "Aviso")
                End If
            End If
        Catch ex As Exception
            MsgBox("Ocurrió un error al guardar los datos.", MsgBoxStyle.Critical, "Aviso")
        End Try
    End Sub

    Private Sub Frm_AddPedidosxTramo_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        f_tramos = False
    End Sub

    Private Sub txtCamLev_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCamLev.KeyPress
        SoloNumeros(sender, e)
    End Sub
End Class
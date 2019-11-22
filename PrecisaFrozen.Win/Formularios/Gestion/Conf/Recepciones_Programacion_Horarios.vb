Public Class Recepciones_Programacion_Horarios

    Dim fnc As New Funciones
    Dim valorRecibido As String = ""

    Private Sub Recepciones_Programacion_Horarios_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        f_ConfigHrsRece = False
    End Sub

    Private Sub Recepciones_Programacion_Horarios_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        cargarTipoDias()
        limpiar()
    End Sub

    Sub cargarTipoDias()
        Try
            Dim dt As New DataTable

            dt.Columns.Add("Tipo_Dia")
            dt.Columns.Add("Tipo_Dia_Frm")

            Dim row As DataRow = dt.NewRow
            row(0) = "H"
            row(1) = "Hábil (Lun. a Vie.)"
            dt.Rows.Add(row)

            Dim row1 As DataRow = dt.NewRow
            row1(0) = "I"
            row1(1) = "Inhábil (Sáb.)"
            dt.Rows.Add(row1)

            cboTipDia.DataSource = dt
            cboTipDia.ValueMember = "Tipo_Dia"
            cboTipDia.DisplayMember = "Tipo_Dia_Frm"
        Catch ex As Exception
            MsgBox("Ocurrió un error al cargar tipo días.", MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Sub cargarDatos()
        Try
            Dim TipDia As String = cboTipDia.SelectedValue.ToString.Trim

            Dim sql As String = "select Hora_Inicio,Hora_Fin,Minutos_Bloques from Recepciones_Programacion_Horarios with(nolock) where Tipo_Dia='" & TipDia & "'"
            Dim dt As New DataTable

            dt = fnc.ListarTablasSQL(sql)

            If (dt.Rows.Count > 0) Then
                txtHraIni.Text = dt.Rows(0).Item(0).ToString.Trim
                txtHraFin.Text = dt.Rows(0).Item(1).ToString.Trim
                txtMinBloq.Text = dt.Rows(0).Item(2).ToString.Trim
            End If

            txtHraIni.Focus()
        Catch ex As Exception
            MsgBox("Ocurrió un error al cargar datos.", MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub cboTipDia_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboTipDia.SelectedIndexChanged
        cargarDatos()
    End Sub

    Sub limpiar()
        cboTipDia.SelectedIndex = 0
        cargarDatos()
    End Sub

    Private Sub btnLim_Click(sender As System.Object, e As System.EventArgs) Handles btnLim.Click
        limpiar()
    End Sub

    Private Sub btnSal_Click(sender As System.Object, e As System.EventArgs) Handles btnSal.Click
        Me.Close()
    End Sub

    Sub grabar()
        Try
            Dim CantErr As Integer = 0
            Dim MsjErr As String = "Errores encontrados:"

            Dim MinBloq As String = txtMinBloq.Text.Trim
            Dim MinBloqFrm As Integer = 0
            If (MinBloq = "") Then
                CantErr += 1
                MsjErr &= vbCrLf & "- Debe ingresar duración de los bloques."

                txtMinBloq.Focus()
            Else
                If (Not Integer.TryParse(MinBloq, MinBloqFrm)) Then
                    CantErr += 1
                    MsjErr &= vbCrLf & "- Debe ingresar duración de los bloques válida."

                    txtMinBloq.Text = ""
                    txtMinBloq.Focus()
                End If
            End If

            Dim HraFin As String = txtHraFin.Text.Trim
            Dim HraFinFrm As DateTime = Now
            If (HraFin = "") Then
                CantErr += 1
                MsjErr &= vbCrLf & "- Debe ingresar una hora de término."

                txtHraFin.Focus()
            Else
                If (Not DateTime.TryParse(HraFin, HraFinFrm)) Then
                    CantErr += 1
                    MsjErr &= vbCrLf & "- Debe ingresar una hora de término válida."

                    txtHraFin.Text = ""
                    txtHraFin.Focus()
                End If
            End If

            Dim HraIni As String = txtHraIni.Text.Trim
            Dim HraIniFrm As DateTime = Now
            If (HraIni = "") Then
                CantErr += 1
                MsjErr &= vbCrLf & "- Debe ingresar una hora de inicio."

                txtHraIni.Focus()
            Else
                If (Not DateTime.TryParse(HraIni, HraIniFrm)) Then
                    CantErr += 1
                    MsjErr &= vbCrLf & "- Debe ingresar una hora de inicio válida."

                    txtHraIni.Text = ""
                    txtHraIni.Focus()
                End If
            End If

            If (CantErr = 0) Then
                If (HraIniFrm >= HraFinFrm) Then
                    CantErr += 1
                    MsjErr &= vbCrLf & "- La hora de inicio debe ser menor a la hora de término."

                    txtHraIni.Focus()
                Else
                    Dim DifHra As Integer = DateDiff(DateInterval.Minute, HraIniFrm, HraFinFrm)

                    If (DifHra Mod MinBloq <> 0) Then
                        CantErr += 1
                        MsjErr &= vbCrLf & "- La diferencia entre la hora de inicio y la hora de término no cuadra con los minutos de cada bloque."

                        txtHraIni.Focus()
                    End If
                End If
            End If

            Dim TipDia As String = cboTipDia.SelectedValue.ToString.Trim

            If (CantErr > 0) Then
                MsgBox(MsjErr, MsgBoxStyle.Critical, "Error")
            Else
                Dim sql As String = "Recepciones_Programacion_Horarios_Grabar '','" & TipDia & "','" & HraIni & "','" & HraFin & "','" & MinBloq & "','" & Frm_Principal.InfoUsuario.Text.Trim & "'"
                Dim dt As New DataTable

                dt = fnc.ListarTablasSQL(sql)

                If (dt.Rows.Count > 0) Then
                    Dim Resp As String = dt.Rows(0).Item(0).ToString.Trim

                    If (Resp <> "-1") Then
                        MsgBox("Configuración registrada exitosamente.", MsgBoxStyle.Information, "Éxito!")
                    Else
                        MsgBox("Ocurrió un error al guardar configuración.", MsgBoxStyle.Critical, "Error")
                    End If
                Else
                    MsgBox("Ocurrió un error al guardar configuración.", MsgBoxStyle.Critical, "Error")
                End If
            End If
        Catch ex As Exception
            MsgBox("Ocurrió un error al registrar configuración.", MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnGra_Click(sender As System.Object, e As System.EventArgs) Handles btnGra.Click
        grabar()
    End Sub
End Class
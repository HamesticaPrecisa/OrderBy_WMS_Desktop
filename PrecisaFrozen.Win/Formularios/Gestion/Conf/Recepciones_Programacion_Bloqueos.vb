Public Class Recepciones_Programacion_Bloqueos

    Dim fnc As New Funciones
    Dim valorRecibido As String = ""

    Private Sub Recepciones_Programacion_Bloqueos_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        f_ConfigBloqHrsRece = False
    End Sub

    Private Sub Recepciones_Programacion_Bloqueos_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        cargarTipoDia()
        limpiar()
    End Sub

    Sub cargarTipoDia()
        Try
            Dim dt As New DataTable

            dt.Columns.Add("Tipo_Dia")
            dt.Columns.Add("Tipo_Dia_Frm")

            Dim row0 As DataRow = dt.NewRow
            row0(0) = ""
            row0(1) = "Todos"
            dt.Rows.Add(row0)

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

    Sub cargarBloqueos()
        Try
            Dim sql As String = "select * from V_Recepciones_Programacion_Horarios_Bloqueos with(nolock) order by ID asc"
            Dim dt As New DataTable

            dt = fnc.ListarTablasSQL(sql)

            gvBloq.DataSource = dt
        Catch ex As Exception
            MsgBox("Ocurrió un error al cargar los bloqueos registrados.", MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Sub limpiar()
        txtID.Text = ""
        cboTipDia.SelectedIndex = 0
        txtHraIni.Text = ""
        txtHraFin.Text = ""
        chkLimFec.Checked = False
        txtFecIni.Value = Now
        txtFecIni.Enabled = False
        txtFecFin.Value = Now
        txtFecFin.Enabled = False

        cargarBloqueos()

        cboTipDia.Focus()
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

            Dim FecTer As String = ""
            Dim FecIni As String = ""

            Dim conFec As Boolean = chkLimFec.Checked
            If (conFec) Then
                FecTer = txtFecFin.Value.ToString("yyyyMMdd").Trim
                FecIni = txtFecIni.Value.ToString("yyyyMMdd").Trim

                If (txtFecIni.Value > txtFecFin.Value) Then
                    CantErr += 1
                    MsjErr &= vbCrLf & "- La fecha de inicio debe ser mayor o igual a la de término."

                    txtFecIni.Focus()
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
                End If
            End If

            Dim TipDia As String = cboTipDia.SelectedValue.ToString.Trim

            Dim ID As String = txtID.Text.Trim

            If (CantErr > 0) Then
                MsgBox(MsjErr, MsgBoxStyle.Critical, "Error")
            Else
                Dim sql As String = "Recepciones_Programacion_Horarios_Bloqueos_Grabar '" & ID & "','" & TipDia & "','" & HraIni & "','" & HraFin & "','" & FecIni & "','" & FecTer & "','','','" & Frm_Principal.InfoUsuario.Text.Trim & "'"
                Dim dt As New DataTable

                dt = fnc.ListarTablasSQL(sql)

                If (dt.Rows.Count > 0) Then
                    Dim Resp As String = dt.Rows(0).Item(0).ToString.Trim

                    If (Resp <> -1) Then
                        MsgBox("Bloqueo registrado exitosamente.", MsgBoxStyle.Information, "Éxito!")
                        limpiar()
                    Else
                        MsgBox("Ocurrió un error al registrar bloqueo.", MsgBoxStyle.Critical, "Error")
                    End If
                Else
                    MsgBox("Ocurrió un error al registrar bloqueo.", MsgBoxStyle.Critical, "Error")
                End If
            End If
        Catch ex As Exception
            MsgBox("Ocurrió un error al registrar bloqueo.", MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnGra_Click(sender As System.Object, e As System.EventArgs) Handles btnGra.Click
        grabar()
    End Sub

    Private Sub chkLimFec_CheckedChanged(sender As Object, e As System.EventArgs) Handles chkLimFec.CheckedChanged
        If (chkLimFec.Checked) Then
            txtFecIni.Enabled = True
            txtFecFin.Enabled = True
        Else
            txtFecIni.Value = Now
            txtFecFin.Value = Now

            txtFecIni.Enabled = False
            txtFecFin.Enabled = False
        End If
    End Sub

    Private Sub gvBloq_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gvBloq.CellClick
        Try
            If (e.RowIndex > -1) Then
                Dim ID As String = gvBloq.Rows(e.RowIndex).Cells("ID").Value.ToString.Trim

                If (gvBloq.Columns(e.ColumnIndex).Name = "btnCli") Then
                    Recepciones_Programacion_Bloqueos_Clientes.txtIDBloq.Text = ID
                    Recepciones_Programacion_Bloqueos_Clientes.ShowDialog()
                ElseIf (gvBloq.Columns(e.ColumnIndex).Name = "btnDes") Then
                    Dim RespEst As MsgBoxResult = MsgBox("¿Está seguro de cambiar el estado de este bloqueo?.", MsgBoxStyle.YesNo, "Pregunta")

                    If (RespEst = MsgBoxResult.Yes) Then
                        Dim Est As String = gvBloq.Rows(e.RowIndex).Cells("Estado").Value.ToString.Trim
                        If (Est = "1") Then
                            Est = "0"
                        Else
                            Est = "1"
                        End If

                        Dim sql As String = "Recepciones_Programacion_Horarios_Bloqueos_Grabar '" & ID & "','','','','','','','" & Est & "','" & Frm_Principal.InfoUsuario.Text.Trim & "'"
                        Dim dt As New DataTable

                        dt = fnc.ListarTablasSQL(sql)

                        If (dt.Rows.Count > 0) Then
                            Dim Resp As String = dt.Rows(0).Item(0).ToString.Trim

                            If (Resp <> "-1") Then
                                MsgBox("Bloqueo desactivado exitosamente.", MsgBoxStyle.Information, "Éxito!")
                                cargarBloqueos()
                            Else
                                MsgBox("Ocurrió un error al desactivar bloqueo.", MsgBoxStyle.Critical, "Error")
                            End If
                        Else
                            MsgBox("Ocurrió un error al desactivar bloqueo.", MsgBoxStyle.Critical, "Error")
                        End If
                    End If
                ElseIf (gvBloq.Columns(e.ColumnIndex).Name = "btnEli") Then
                    Dim RespEli As MsgBoxResult = MsgBox("¿Está seguro de eliminar este bloqueo?.", MsgBoxStyle.YesNo, "Pregunta")

                    If (RespEli = MsgBoxResult.Yes) Then
                        Dim sql As String = "Recepciones_Programacion_Horarios_Bloqueos_Eliminar '" & ID & "','" & Frm_Principal.InfoUsuario.Text.Trim & "'"
                        Dim dt As New DataTable

                        dt = fnc.ListarTablasSQL(sql)

                        If (dt.Rows.Count > 0) Then
                            Dim Resp As String = dt.Rows(0).Item(0).ToString.Trim

                            If (Resp <> "-1") Then
                                MsgBox("Bloqueo eliminado exitosamente.", MsgBoxStyle.Information, "Éxito!")
                                cargarBloqueos()
                            Else
                                MsgBox("Ocurrió un error al eliminar bloqueo.", MsgBoxStyle.Critical, "Error")
                            End If
                        Else
                            MsgBox("Ocurrió un error al eliminar bloqueo.", MsgBoxStyle.Critical, "Error")
                        End If
                    End If
                Else
                    Dim TipDia As String = gvBloq.Rows(e.RowIndex).Cells("Tipo_Dia").Value.ToString.Trim
                    Dim HraIni As String = gvBloq.Rows(e.RowIndex).Cells("Hora_Inicio").Value.ToString.Trim
                    Dim HraFin As String = gvBloq.Rows(e.RowIndex).Cells("Hora_Fin").Value.ToString.Trim
                    Dim FecIni As String = gvBloq.Rows(e.RowIndex).Cells("Fecha_Inicio").Value.ToString.Trim
                    Dim FecFin As String = gvBloq.Rows(e.RowIndex).Cells("Fecha_Fin").Value.ToString.Trim

                    txtID.Text = ID
                    cboTipDia.SelectedValue = TipDia
                    txtHraIni.Text = HraIni
                    txtHraFin.Text = HraFin

                    If (FecIni <> "") Then
                        txtFecIni.Value = FecIni
                        txtFecFin.Value = FecFin
                        chkLimFec.Checked = True
                    Else
                        txtFecIni.Value = Now
                        txtFecFin.Value = Now
                        chkLimFec.Checked = False
                    End If

                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
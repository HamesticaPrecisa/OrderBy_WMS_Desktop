Public Class Recepciones_Programacion_Cargas

    Dim fnc As New Funciones
    Dim valorRecibido As String = ""

    Sub cargarCargas()
        Try
            Dim sql As String = "select * from CARGA_DESCARGA with(nolock)"
            Dim dt As New DataTable

            dt = fnc.ListarTablasSQL(sql)

            cboTipCar.ValueMember = "Codigo"
            cboTipCar.DisplayMember = "Desc"
            cboTipCar.DataSource = dt
        Catch ex As Exception
            MsgBox("Ocurrió un error al cargar tipos de carga.", MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Sub cargarDatosCarga()
        Try
            Dim TipCar As String = cboTipCar.SelectedValue.ToString.Trim

            Dim sql As String = "select * from Recepciones_Programacion_Horarios_Bloques_Carga with(nolock) where Tipo_Carga='" & TipCar & "'"
            Dim dt As New DataTable

            dt = fnc.ListarTablasSQL(sql)

            If (dt.Rows.Count > 0) Then
                txtMinCar.Text = dt.Rows(0).Item(2).ToString.Trim
                txtCapSim.Text = dt.Rows(0).Item(3).ToString.Trim
            End If
        Catch ex As Exception
            MsgBox("Ocurrió un error al cargar datos.", MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnSal_Click(sender As System.Object, e As System.EventArgs) Handles btnSal.Click
        Me.Close()
    End Sub

    Sub limpiar()
        cboTipCar.SelectedIndex = 0
        txtMinCar.Text = ""
        txtCapSim.Text = ""

        cargarDatosCarga()

        cboTipCar.Focus()
    End Sub

    Private Sub btnLim_Click(sender As System.Object, e As System.EventArgs) Handles btnLim.Click
        limpiar()
    End Sub

    Sub grabar()
        Try
            Dim CantErr As Integer = 0
            Dim MsjErr As String = "Errores encontrados:"

            Dim CapSim As String = txtCapSim.Text.Trim
            Dim CapSimFrm As Integer = 0
            If (CapSim = "") Then
                CantErr += 1
                MsjErr &= vbCrLf & "- Debe ingresar la capacidad simultanea de carga."

                txtCapSim.Focus()
            Else
                If (Not Integer.TryParse(CapSim, CapSimFrm)) Then
                    CantErr += 1
                    MsjErr &= vbCrLf & "- Debe ingresar la capacidad simultanea de carga válida."

                    txtCapSim.Text = ""
                    txtCapSim.Focus()
                Else
                    If (CapSim = "0") Then
                        CantErr += 1
                        MsjErr &= vbCrLf & "- La capacidad simultanea de carga debe ser mayor a cero."

                        txtCapSim.Focus()
                    End If
                End If
            End If

            Dim MinCar As String = txtMinCar.Text.Trim
            Dim MinCarFrm As Integer = 0
            If (MinCar = "") Then
                CantErr += 1
                MsjErr &= vbCrLf & "- Debe ingresar minutos por carga."

                txtMinCar.Focus()
            Else
                If (Not Integer.TryParse(MinCar, MinCarFrm)) Then
                    CantErr += 1
                    MsjErr &= vbCrLf & "- Debe ingresar minutos por carga válidos."

                    txtMinCar.Text = ""
                    txtMinCar.Focus()
                Else
                    If (MinCar = "0") Then
                        CantErr += 1
                        MsjErr &= vbCrLf & "- Los minutos por carga deben ser mayor a cero."

                        txtMinCar.Focus()
                    End If
                End If
            End If

            Dim TipCar As String = cboTipCar.SelectedValue.ToString.Trim

            If (CantErr > 0) Then
                MsgBox(MsjErr, MsgBoxStyle.Critical, "Error")
            Else
                Dim sql As String = "Recepciones_Programacion_Horarios_Bloques_Carga_Grabar '','" & TipCar & "','" & MinCar & "','" & CapSim & "','" & Frm_Principal.InfoUsuario.Text.Trim & "'"
                Dim dt As New DataTable

                dt = fnc.ListarTablasSQL(sql)

                If (dt.Rows.Count > 0) Then
                    Dim Resp As String = dt.Rows(0).Item(0).ToString.Trim

                    If (Resp <> "-1") Then
                        MsgBox("Datos registrados exitosamente.", MsgBoxStyle.Information, "Éxito!")
                        limpiar()
                    Else
                        MsgBox("Ocurrió un error al registrar datos.", MsgBoxStyle.Critical, "Error")
                    End If
                Else
                    MsgBox("Ocurrió un error al registrar datos.", MsgBoxStyle.Critical, "Error")
                End If
            End If
        Catch ex As Exception
            MsgBox("Ocurrió un error al registrar datos.", MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnGra_Click(sender As System.Object, e As System.EventArgs) Handles btnGra.Click
        grabar()
    End Sub

    Private Sub Recepciones_Programacion_Cargas_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        f_ConfigBloqCargas = False
    End Sub

    Private Sub Recepciones_Programacion_Cargas_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        cargarCargas()
        limpiar()
    End Sub

    Private Sub cboTipCar_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboTipCar.SelectedIndexChanged
        cargarDatosCarga()
    End Sub
End Class
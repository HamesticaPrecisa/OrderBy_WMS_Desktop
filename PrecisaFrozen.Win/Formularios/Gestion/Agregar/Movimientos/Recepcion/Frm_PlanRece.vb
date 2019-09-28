Public Class Frm_PlanRece
    Dim fnc As New Funciones

    Private Sub Frm_PlanRece_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        F_PlanRece = False
    End Sub

    Private Sub Frm_PlanRece_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        cargarCboJornada()
        limpiarForm()
    End Sub

    Sub cargarCboJornada()
        Try
            Dim dtCbo As New DataTable
            dtCbo.Columns.Add("Jornada")

            Dim Jornadas As String() = {"Día", "Tarde", "Noche"}

            For i = 0 To Jornadas.Length - 1
                Dim row As DataRow = dtCbo.NewRow
                row(0) = Jornadas(i)
                dtCbo.Rows.Add(row)
            Next

            cboJor.DataSource = dtCbo
            cboJor.DisplayMember = "Jornada"
            cboJor.ValueMember = "Jornada"
        Catch ex As Exception
            MsgBox("Ocurrió un error al cargar las Jornadas.", MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btn_BuscaCliente_Click(sender As System.Object, e As System.EventArgs) Handles btn_BuscaCliente.Click
        Dim frm As New Lst_AyudaClientes
        frm.ShowDialog(Frm_Principal)
        Dim valorRecibido As String = Frm_Principal.buscavalor

        If Len(valorRecibido) >= 9 Then

            Dim SqlBusca As String = "SELECT cli_nomb, cli_estado FROM clientes WHERE " +
                "cli_rut='" + valorRecibido + "'"

            Dim tabla As DataTable = fnc.ListarTablasSQL(SqlBusca)

            If tabla.Rows.Count > 0 Then
                If tabla.Rows(0)(1).ToString() = "N" Then
                    MsgBox("El cliente seleccionado se encuentra bloqueado", MsgBoxStyle.Critical, "Aviso")
                    Exit Sub
                End If

                TxtClirut.Text = valorRecibido
                txtclinom.Text = tabla.Rows(0)(0).ToString()
                Frm_Principal.buscavalor = ""

                TxtClirut.Enabled = False
            Else
                MsgBox("El rut ingresado no existe", MsgBoxStyle.Information, "Aviso")
            End If
        End If
        Frm_Principal.buscavalor = ""
    End Sub

    Sub cargarGrilla()
        Try
            Dim Fec As String = fecharece.Value.ToString("yyyyMMdd").Trim

            Dim sql As String = "select ID,Fecha_Frm,Rut_Cliente,Nombre_Cliente,Jornada,Cantidad_Pallets,Observacion,Usuario from V_Recepciones_Planificacion with(nolock) where Fecha>='" & Fec & "' order by Fecha asc"
            Dim dt As New DataTable
            dt = fnc.ListarTablasSQL(sql)

            gvDet.DataSource = dt
        Catch ex As Exception
            MsgBox("Ocurrió un error al cargar las Recepciones planificadas.", MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Sub limpiarForm()
        Try
            TxtClirut.Text = ""
            TxtClirut.Enabled = True
            txtclinom.Text = ""
            fecharece.Value = fnc.DevuelveFechaServidor()
            cboJor.SelectedIndex = 0
            txtCanPal.Text = ""
            Txtobs.Text = ""
            cargarGrilla()
            btn_BuscaCliente.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btn_nuevo_Click(sender As System.Object, e As System.EventArgs) Handles btn_nuevo.Click
        limpiarForm()
    End Sub

    Private Sub btn_salir_Click(sender As System.Object, e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub btn_guardar_Click(sender As System.Object, e As System.EventArgs) Handles btn_guardar.Click
        grabar()
    End Sub

    Sub grabar()
        Try
            Dim canErr As Integer = 0
            Dim msgErr As String = "Errores encontrados:"

            Dim Obs As String = Txtobs.Text.Trim

            Dim CanPal As String = txtCanPal.Text.Trim
            Dim CanPalAux As Integer = 0
            If (CanPal = "") Then
                CanPal = "0"
            End If
            If (Not Integer.TryParse(CanPal, CanPalAux)) Then
                canErr += 1
                msgErr &= vbCrLf & "- Debe ingresar una cantidad de Pallets valida."
                txtCanPal.Text = ""
                txtCanPal.Focus()
            End If

            Dim Jor As String = cboJor.SelectedValue.ToString.Trim

            Dim FecFrm As String = fecharece.Value.ToString("yyyyMMdd").Trim
            Dim Fec As Date = fecharece.Value
            If (DateDiff(DateInterval.Day, fnc.DevuelveFechaServidor, Fec) < 0) Then
                canErr += 1
                msgErr &= vbCrLf & "- Debe seleccionar una Fecha mayor o igual a la actual."
                fecharece.Value = fnc.DevuelveFechaServidor
                fecharece.Focus()
            End If

            Dim Rut As String = TxtClirut.Text.Trim
            If (Rut = "") Then
                canErr += 1
                msgErr &= vbCrLf & "- Debe seleccionar un Cliente."
                btn_BuscaCliente.Focus()
            End If

            If (canErr > 0) Then
                MsgBox(msgErr, MsgBoxStyle.Critical, "Error")
            Else
                Dim sql As String = "SP_Recepciones_Planificacion_Grabar '" & FecFrm & "','" & Rut & "','" & Jor & "','" & CanPal & "','" & Obs & "','" & Frm_Principal.InfoUsuario.Text.Trim & "'"
                Dim dt As New DataTable
                dt = fnc.ListarTablasSQL(sql)
                If (dt.Rows.Count > 0) Then
                    Dim Resp As String = dt.Rows(0).Item(0).ToString.Trim

                    If (Resp = "1") Then
                        MsgBox("Planificación de Recepción registrada exitosamente.", MsgBoxStyle.Information, "Info")
                        limpiarForm()
                    Else
                        MsgBox("Ocurrió un error al grabar la planificación de Recepción.", MsgBoxStyle.Critical, "Error")
                    End If
                Else
                    MsgBox("Ocurrió un error al grabar la planificación de Recepción.", MsgBoxStyle.Critical, "Error")
                End If
            End If
        Catch ex As Exception
            MsgBox("Ocurrió un error al grabar la planificación de Recepción.", MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub Btn_AnulaGuia_Click(sender As System.Object, e As System.EventArgs) Handles Btn_AnulaGuia.Click
        Try
            Dim dtSel As New DataTable
            dtSel.Columns.Add("ID")

            For i = 0 To gvDet.Rows.Count - 1
                If (gvDet.Rows(i).Selected) Then
                    Dim row As DataRow = dtSel.NewRow
                    row(0) = gvDet.Rows(i).Cells("ID").Value.ToString.Trim
                    dtSel.Rows.Add(row)
                End If
            Next

            If (dtSel.Rows.Count > 0) Then
                Dim msgResp As MsgBoxResult = MsgBox("¿Está seguro de eliminar las planificaciones seleccionadas?", MsgBoxStyle.YesNo, "Pregunta")
                If (msgResp = MsgBoxResult.Yes) Then
                    For j = 0 To dtSel.Rows.Count - 1
                        Dim IDPla As String = dtSel.Rows(j).Item(0).ToString.Trim

                        Dim sql As String = "SP_Recepciones_Planificacion_Eliminar '" & IDPla & "','" & Frm_Principal.InfoUsuario.Text.Trim & "'"
                        fnc.MovimientoSQL(sql)

                        'Dim dt As New DataTable
                        'dt = fnc.ListarTablasSQL(sql)

                        'If (dt.Rows.Count > 0) Then
                        '    Dim Resp As String = dt.Rows(0).Item(0).ToString.Trim

                        '    If (Resp = "1") Then
                        '        MsgBox("Planificación de Recepción eliminada exitosamente.", MsgBoxStyle.Information, "Info")
                        '        limpiarForm()
                        '    Else
                        '        MsgBox("Ocurrió un error al eliminar la planificación de Recepción.", MsgBoxStyle.Critical, "Error")
                        '    End If
                        'Else
                        '    MsgBox("Ocurrió un error al eliminar la planificación de Recepción.", MsgBoxStyle.Critical, "Error")
                        'End If
                    Next

                    MsgBox("Planificaciones de Recepción eliminadas exitosamente.", MsgBoxStyle.Information, "Info")
                    limpiarForm()
                End If
            Else
                MsgBox("Debe seleccionar las planificaciones que desea Eliminar.", MsgBoxStyle.Critical, "Error")
            End If
        Catch ex As Exception
            MsgBox("Ocurrió un error al eliminar la planificación de Recepción.", MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnExcel_Click(sender As System.Object, e As System.EventArgs) Handles btnExcel.Click
        Try
            Dim dt As New DataTable
            dt.Columns.Add("Fecha_Str")
            dt.Columns.Add("Rut_Cliente")
            dt.Columns.Add("Cliente")
            dt.Columns.Add("Jornada")
            dt.Columns.Add("Pallets")
            dt.Columns.Add("Observacion")
            dt.Columns.Add("Usuario")

            For i = 0 To gvDet.Rows.Count - 1
                If (gvDet.Rows(i).Selected) Then
                    Dim row As DataRow = dt.NewRow
                    row(0) = gvDet.Rows(i).Cells("Fecha_Frm").Value.ToString.Trim
                    row(1) = gvDet.Rows(i).Cells("rut_cliente").Value.ToString.Trim
                    row(2) = gvDet.Rows(i).Cells("nombre_cliente").Value.ToString.Trim
                    row(3) = gvDet.Rows(i).Cells("Jornada").Value.ToString.Trim
                    row(4) = gvDet.Rows(i).Cells("Cantidad_Pallets").Value.ToString.Trim
                    row(5) = gvDet.Rows(i).Cells("Observacion").Value.ToString.Trim
                    row(6) = gvDet.Rows(i).Cells("Usuario").Value.ToString.Trim
                    dt.Rows.Add(row)
                End If
            Next

            If (dt.Rows.Count > 0) Then
                fnc.dtToExcel(dt)
            Else
                MsgBox("Debe seleccionar las Planificaciones a exportar.", MsgBoxStyle.Information, "Info")
            End If
        Catch ex As Exception
            MsgBox("Ocurrió un error al exportal listado de planificaciones a Excel.", MsgBoxStyle.Critical, "Aviso")
        End Try
    End Sub
End Class
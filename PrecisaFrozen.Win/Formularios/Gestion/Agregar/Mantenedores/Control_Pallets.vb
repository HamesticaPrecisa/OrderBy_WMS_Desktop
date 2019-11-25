Public Class Control_Pallets

    Dim fnc As New Funciones
    Dim valorRecibido As String = ""

    Private Sub btn_BuscaCliente_Click(sender As System.Object, e As System.EventArgs) Handles btn_BuscaCliente.Click
        Dim frm As New Lst_AyudaClientes
        frm.ShowDialog(Frm_Principal)
        Me.valorRecibido = Frm_Principal.buscavalor

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
                Btn_BuscaContrato.Enabled = True
                Frm_Principal.buscavalor = ""

                txtcodcontrato.Text = ""
                txtnom_contrato.Text = ""
                TxtClirut.Enabled = False
            Else
                MsgBox("El rut ingresado no existe", MsgBoxStyle.Information, "Aviso")
            End If
        End If

        Frm_Principal.buscavalor = ""
    End Sub

    Private Sub Btn_BuscaContrato_Click(sender As System.Object, e As System.EventArgs) Handles Btn_BuscaContrato.Click
        Dim frm As New Lst_AyudaContratos
        frm.condicion = "WHERE  cont_rutclie='" + QuitarCaracteres(TxtClirut.Text) + "' AND cont_estado='0'"
        frm.ShowDialog(Frm_Principal)
        Me.valorRecibido = Frm_Principal.buscavalor

        Dim sql As String = "SELECT cont_descr, cont_tempcon, cont_tempgra, Hor_SRI, Hor_SRT, Hor_SDI, Hor_SDT, cont_bloqimp,cont_tipalm " +
            "FROM contrato, contratosHorarios WHERE cont_codi=Hor_Contcod AND cont_codi='" + valorRecibido.ToString() + "'"

        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

        If tabla.Rows.Count > 0 Then
            txtcodcontrato.Enabled = False
            txtcodcontrato.Text = valorRecibido.ToString
            txtnom_contrato.Text = tabla.Rows(0)(0).ToString()
        End If

        Frm_Principal.buscavalor = ""
    End Sub

    Private Sub Btn_buscasoportante_Click(sender As System.Object, e As System.EventArgs) Handles Btn_buscasoportante.Click
        Dim frm As New Lst_AyudaSoportantes
        frm.ShowDialog(Frm_Principal)
        txtsopcodi.Text = Frm_Principal.buscavalor
        Dim sql As String = "SELECT tsop_descr FROM tiposopo WHERE tsop_codi='" + txtsopcodi.Text + "'"

        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)
        If tabla.Rows.Count > 0 Then
            txtsopnombre.Text = tabla.Rows(0)(0)
            txtsopcodi.Enabled = False
        End If
        Frm_Principal.buscavalor = ""
    End Sub

    Sub cargarEstados()
        Try
            Dim sql As String = "select ID,Nombre_Estado from Control_Pallet_Estados with(nolock)"
            Dim dt As New DataTable

            dt = fnc.ListarTablasSQL(sql)

            cboEst.ValueMember = "ID"
            cboEst.DisplayMember = "Nombre_Estado"
            cboEst.DataSource = dt
        Catch ex As Exception
            MsgBox("Ocurrió un error al cargar estados de pallets.", MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnLim_Click(sender As System.Object, e As System.EventArgs) Handles btnLim.Click
        limpiar()
    End Sub

    Sub limpiar()
        txtID.Text = ""
        TxtClirut.Text = ""
        TxtClirut.Enabled = True
        btn_BuscaCliente.Enabled = True
        txtclinom.Text = ""
        txtclinom.Enabled = False
        txtcodcontrato.Text = ""
        txtcodcontrato.Enabled = True
        Btn_BuscaContrato.Enabled = True
        txtnom_contrato.Text = ""
        txtnom_contrato.Enabled = False
        txtsopcodi.Text = ""
        txtsopcodi.Enabled = True
        Btn_buscasoportante.Enabled = True
        txtsopnombre.Text = ""
        txtsopnombre.Enabled = False
        cboEst.SelectedIndex = 0
        txtFec.Text = Now
        txtDoc.Text = ""
        txtIng.Text = ""
        txtSal.Text = ""
        txtObs.Text = ""
        btn_BuscaCliente.Focus()
    End Sub

    Private Sub Control_Pallets_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        f_CtrPallet = False
    End Sub

    Private Sub btnSal_Click(sender As System.Object, e As System.EventArgs) Handles btnSal.Click
        Me.Close()
    End Sub

    Sub grabar()
        Try
            Dim CantErr As Integer = 0
            Dim MsjErr As String = "Errores encontrados:" & vbCrLf

            Dim Obs As String = txtObs.Text.Trim

            Dim Est As String = cboEst.SelectedValue

            Dim CantSal As String = txtSal.Text.Trim
            Dim CanSalFrm As Integer = 0
            If (CantSal <> "") Then
                If (Not Integer.TryParse(CantSal, CanSalFrm)) Then
                    CantErr += 1
                    MsjErr &= "- Debe ingresar cantidad de pallet válida." & vbCrLf

                    txtSal.Text = ""
                    txtSal.Focus()
                End If
            End If

            Dim CantIng As String = txtIng.Text.Trim
            Dim CanIngFrm As Integer = 0
            If (CantIng <> "") Then
                If (Not Integer.TryParse(CantIng, CanIngFrm)) Then
                    CantErr += 1
                    MsjErr &= "- Debe ingresar cantidad de pallet válida." & vbCrLf

                    txtIng.Text = ""
                    txtIng.Focus()
                End If
            End If

            If (CanIngFrm = 0 And CanSalFrm = 0) Then
                CantErr += 1
                MsjErr &= "- Debe ingresar pallets de ingreso o salida." & vbCrLf

                txtIng.Focus()
            End If

            Dim DocAso As String = txtDoc.Text.Trim
            If (DocAso = "") Then
                CantErr += 1
                MsjErr &= "- Debe ingresar nro. documento asociado." & vbCrLf

                txtDoc.Focus()
            End If

            Dim Fec As String = CDate(txtFec.Text.Trim).ToString("yyyyMMdd")

            Dim TipSop As String = txtsopcodi.Text.Trim
            If (TipSop = "") Then
                CantErr += 1
                MsjErr &= "- Debe seleccionar tipo soportante." & vbCrLf

                Btn_buscasoportante.Focus()
            End If

            Dim CodCont As String = txtcodcontrato.Text.Trim
            If (CodCont = "") Then
                CantErr += 1
                MsjErr &= "- Debe seleccionar contrato." & vbCrLf

                Btn_BuscaContrato.Focus()
            End If

            Dim RutCli As String = TxtClirut.Text.Trim
            If (RutCli = "") Then
                CantErr += 1
                MsjErr &= "- Debe seleccionar cliente." & vbCrLf

                btn_BuscaCliente.Focus()
            End If

            Dim ID As String = txtID.Text.Trim

            If (CantErr > 0) Then
                MsgBox(MsjErr, MsgBoxStyle.Critical, "Error")
            Else
                Dim sql As String = "SP_Control_Pallet_Grabar '" & ID & "','" & RutCli & "','" & CodCont & "','" & Fec & "','" & TipSop & "','" & DocAso & "','" & CanIngFrm & "','" & CanSalFrm & "','" & Obs & "','" & Est & "','" & Frm_Principal.InfoUsuario.Text.Trim & "'"
                Dim dt As New DataTable

                dt = fnc.ListarTablasSQL(sql)

                If (dt.Rows.Count > 0) Then
                    Dim Resp As Integer = CInt(dt.Rows(0).Item(0).ToString.Trim)

                    If (Resp <> -1) Then
                        txtID.Text = Resp

                        MsgBox("Movimiento registrado exitosamente.", MsgBoxStyle.Information, "Aviso")

                        limpiar2()
                    Else
                        MsgBox("Ocurrió un error al registrar movimiento.", MsgBoxStyle.Critical, "Error")
                    End If
                Else
                    MsgBox("Ocurrió un error al registrar movimiento.", MsgBoxStyle.Critical, "Error")
                End If
            End If
        Catch ex As Exception
            MsgBox("Ocurrió un error al registrar movimiento.", MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnGra_Click(sender As System.Object, e As System.EventArgs) Handles btnGra.Click
        grabar()
    End Sub

    Private Sub Control_Pallets_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        cargarEstados()
        limpiar()
    End Sub

    Private Sub btnImp_Click(sender As System.Object, e As System.EventArgs) Handles btnImp.Click

    End Sub

    Sub cargarGrilla()
        Try
            Dim RutCli As String = TxtClirut.Text.Trim
            Dim CodCont As String = txtcodcontrato.Text.Trim
            Dim TipSop As String = txtsopcodi.Text.Trim
            Dim Est As String = cboEst.SelectedValue.ToString.Trim

            Dim sql As String = "select a.* from V_Control_Pallet a with(nolock) where a.Rut_Cliente='" & RutCli & "' and a.Contrato='" & CodCont & "' and a.Tipo_Pallet='" & TipSop & "' and a.Estado='" & Est & "' order by a.Fecha,a.ID asc"
            Dim dt As New DataTable

            dt = fnc.ListarTablasSQL(sql)

            gvMov.DataSource = dt
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtClirut_TextChanged(sender As Object, e As System.EventArgs) Handles TxtClirut.TextChanged
        cargarGrilla()
    End Sub

    Private Sub txtcodcontrato_TextChanged(sender As Object, e As System.EventArgs) Handles txtcodcontrato.TextChanged
        cargarGrilla()
    End Sub

    Private Sub txtsopcodi_TextChanged(sender As Object, e As System.EventArgs) Handles txtsopcodi.TextChanged
        cargarGrilla()
    End Sub

    Sub limpiar2()
        txtID.Text = ""
        txtFec.Text = Now
        txtDoc.Text = ""
        txtIng.Text = ""
        txtSal.Text = ""
        txtObs.Text = ""

        cargarGrilla()

        txtFec.Focus()
    End Sub

    Private Sub gvMov_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gvMov.CellClick
        Try
            If (e.RowIndex > -1) Then
                Dim ID As String = gvMov.Rows(e.RowIndex).Cells("ID").Value.ToString.Trim

                If (gvMov.Columns(e.ColumnIndex).Name = "Fotos") Then
                    Control_Pallets_Fotos.txtID.Text = ID
                    Control_Pallets_Fotos.ShowDialog()
                ElseIf (gvMov.Columns(e.ColumnIndex).Name = "Eliminar") Then
                    Dim Resp As MsgBoxResult = MsgBox("¿Está seguro de eliminar este movimiento?", MsgBoxStyle.YesNo, "Pregunta")

                    If (Resp = MsgBoxResult.Yes) Then
                        Dim sql As String = "Control_Pallet_Eliminar '" & ID & "','" & Frm_Principal.InfoUsuario.Text.Trim & "'"
                        Dim dt As New DataTable

                        dt = fnc.ListarTablasSQL(sql)

                        If (dt.Rows.Count > 0) Then
                            Dim RespSql As Integer = CInt(dt.Rows(0).Item(0).ToString.Trim)

                            If (RespSql = 1) Then
                                MsgBox("Movimiento eliminado exitosamente.", MsgBoxStyle.Information, "Aviso")
                                cargarGrilla()
                            ElseIf (RespSql = -2) Then
                                MsgBox("No se puede eliminar movimiento, mantiene fotos asociadas.", MsgBoxStyle.Information, "Aviso")
                            ElseIf (RespSql = -1) Then
                                MsgBox("Ocurrió un error al eliminar el movimiento.", MsgBoxStyle.Critical, "Error")
                            End If
                        Else
                            MsgBox("Ocurrió un error al eliminar el movimiento.", MsgBoxStyle.Critical, "Error")
                        End If
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Label2_Click(sender As System.Object, e As System.EventArgs) Handles Label2.Click

    End Sub

    Private Sub txtclinom_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtclinom.TextChanged

    End Sub

    Private Sub cboEst_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboEst.SelectedIndexChanged
        cargarGrilla()
    End Sub
End Class
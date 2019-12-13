Public Class Limite_Pedidos_Exportacion

    Dim fnc As New Funciones
    Dim valorRecibido As String = ""

    Private Sub Limite_Pedidos_Exportacion_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        f_LimPedExp = False
    End Sub

    Private Sub Limite_Pedidos_Exportacion_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            txtNomLim.Focus()
        Catch ex As Exception
            MsgBox("Ocurrió un error al cargar el formulario.", MsgBoxStyle.OkOnly, "Error")
        End Try
    End Sub

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
                Frm_Principal.buscavalor = ""

                TxtClirut.Enabled = False
            Else
                MsgBox("El rut ingresado no existe", MsgBoxStyle.Information, "Aviso")
            End If
        End If
        Frm_Principal.buscavalor = ""
    End Sub

    Sub limpiar()
        Try
            txtNomLim.Text = ""
            txtIDLim.Text = ""
            txtLimDia.Text = ""

            txtclinom.Text = ""
            TxtClirut.Text = ""
            TxtClirut.Enabled = True

            Dim dt As New DataTable
            dt.Columns.Add("Rut_Cliente")
            dt.Columns.Add("Nombre_Cliente")

            gvDet.DataSource = dt
            txtNomLim.Focus()
        Catch ex As Exception
            MsgBox("Ocurrió un error al limpiar el formulario.", MsgBoxStyle.OkOnly, "Error")
        End Try
    End Sub

    Private Sub btnLim_Click(sender As System.Object, e As System.EventArgs) Handles btnLim.Click
        limpiar()
    End Sub

    Private Sub btnVol_Click(sender As System.Object, e As System.EventArgs) Handles btnVol.Click
        Me.Close()
    End Sub

    Private Sub btnGra_Click(sender As System.Object, e As System.EventArgs) Handles btnGra.Click
        Try
            Dim CantErr As Integer = 0
            Dim MsjErr As String = "Errores Encontrados:"

            Dim LimDia As String = txtLimDia.Text.Trim
            Dim LimDiaFrm As Integer = 0
            If (LimDia = "") Then
                CantErr += 1
                MsjErr &= vbCrLf & "- Debe ingresar un límite diario de pedidos exportación."
                txtLimDia.Focus()
            Else
                If (Not Integer.TryParse(LimDia, LimDiaFrm)) Then
                    CantErr += 1
                    MsjErr &= vbCrLf & "- Debe ingresar un límite diario de pedidos exportación válido."
                    txtLimDia.Text = ""
                    txtLimDia.Focus()
                End If
            End If

            Dim NomLim As String = txtNomLim.Text.Trim
            If (NomLim = "") Then
                CantErr += 1
                MsjErr &= vbCrLf & "- Debe ingresar un nombre de límite."
                txtNomLim.Focus()
            End If

            Dim IDLim As String = txtIDLim.Text.Trim

            If (gvDet.Rows.Count = 0) Then
                CantErr += 1
                MsjErr &= vbCrLf & "- Debe asignar a lo menos un cliente."
                btn_BuscaCliente.Focus()
            End If

            If (CantErr > 0) Then
                MsgBox(MsjErr, MsgBoxStyle.OkOnly, "Error")
            Else
                Dim IDExi As Integer = validLimExi(NomLim)

                If (IDExi <> -1) Then
                    Dim Resp As MsgBoxResult = MsgBox("Ya existe un límite con este nombre. ¿Desea actualizarlo con estos datos?", MsgBoxStyle.YesNo, "Pregunta")

                    If (Resp = MsgBoxResult.Yes) Then
                        IDLim = IDExi
                    Else
                        txtNomLim.Focus()
                        Exit Sub
                    End If
                End If

                Dim sql As String = "SP_Pedidos_Tipo_Exportacion_Limites_Grupo_Grabar '" & IDLim & "','" & NomLim & "','" & LimDia & "','" & Frm_Principal.InfoUsuario.Text.Trim & "'"
                Dim dt As New DataTable
                dt = fnc.ListarTablasSQL(sql)

                If (dt.Rows.Count > 0) Then
                    Dim Resp As String = dt.Rows(0).Item(0).ToString.Trim

                    If (Resp <> "-1") Then
                        IDLim = Resp
                        If (grabarClientesLimite(IDLim)) Then
                            CantErr += 1
                        End If
                    Else
                        CantErr += 1
                    End If
                Else
                    CantErr += 1
                End If

                If (CantErr > 0) Then
                    MsgBox("Ocurrió un error al registrar los datos.", MsgBoxStyle.OkOnly, "Error")
                Else
                    txtIDLim.Text = IDLim
                    MsgBox("Limite registrado exitosamente.", MsgBoxStyle.OkOnly, "Info.")
                End If
            End If
        Catch ex As Exception
            MsgBox("Ocurrió un error al registrar los datos.", MsgBoxStyle.OkOnly, "Error")
        End Try
    End Sub

    Function validLimExi(ByVal NomLim As String) As Integer
        Dim Resp As Integer = -1

        Try
            Dim sql As String = "select a.ID from Pedidos_Tipo_Exportacion_Limites_Grupo a with(nolock) where a.Nombre='" & NomLim & "'"
            Dim dt As New DataTable

            dt = fnc.ListarTablasSQL(sql)

            If (dt.Rows.Count > 0) Then
                Dim RespSql As Integer = CInt(dt.Rows(0).Item(0).ToString.Trim)

                If (RespSql <> -1) Then
                    Resp = RespSql
                End If
            End If
        Catch ex As Exception
            MsgBox("Ocurrió un error al validar límite existente.", MsgBoxStyle.OkOnly, "Error")
        End Try

        Return Resp
    End Function


    Function grabarClientesLimite(ByVal IDLim As String) As Boolean
        Dim Resp As Boolean = True

        Try
            Dim Err As Boolean = False

            Dim sqlEli As String = "Pedidos_Tipo_Exportacion_Limites_Grupo_Clientes_Eliminar '" & IDLim & "','" & Frm_Principal.InfoUsuario.Text.Trim & "'"
            fnc.MovimientoSQL(sqlEli)

            For i = 0 To gvDet.Rows.Count - 1
                Dim RutCli As String = gvDet.Rows(i).Cells("Rut_Cliente").Value.ToString.Trim

                Dim sql As String = "SP_Pedidos_Tipo_Exportacion_Limites_Grupo_Clientes_Grabar '" & IDLim & "','" & RutCli & "','" & Frm_Principal.InfoUsuario.Text.Trim & "'"
                Dim dt As New DataTable
                dt = fnc.ListarTablasSQL(sql)

                If (dt.Rows.Count > 0) Then
                    If (dt.Rows(0).Item(0).ToString.Trim = "-1") Then
                        Err = True
                    End If
                End If
            Next

            Resp = Err
        Catch ex As Exception

        End Try

        Return Resp
    End Function

    Private Sub btnAddCli_Click(sender As System.Object, e As System.EventArgs) Handles btnAddCli.Click
        Try
            Dim RutCli As String = TxtClirut.Text.Trim
            If (RutCli = "") Then
                btn_BuscaCliente.Focus()
                Exit Sub
            End If

            Dim NomCli As String = txtclinom.Text.Trim

            Dim dtDet As New DataTable
            dtDet.Columns.Add("Rut_Cliente")
            dtDet.Columns.Add("Nombre_Cliente")

            Dim NoExi As Boolean = True

            For i = 0 To gvDet.Rows.Count - 1
                Dim RutCliDet As String = gvDet.Rows(i).Cells("Rut_Cliente").Value.ToString.Trim
                Dim NomCliDet As String = gvDet.Rows(i).Cells("Nom_Cliente").Value.ToString.Trim

                Dim row As DataRow = dtDet.NewRow
                row(0) = RutCliDet
                row(1) = NomCliDet
                dtDet.Rows.Add(row)

                If (RutCli = RutCliDet) Then
                    NoExi = False
                End If
            Next

            If (NoExi) Then
                Dim row2 As DataRow = dtDet.NewRow
                row2(0) = RutCli
                row2(1) = NomCli
                dtDet.Rows.Add(row2)
            End If

            If (dtDet.Rows.Count > 0) Then
                gvDet.DataSource = dtDet
            End If

            TxtClirut.Text = ""
            txtclinom.Text = ""
            btn_BuscaCliente.Focus()
        Catch ex As Exception
            MsgBox("Ocurrió un error al asignar cliente.", MsgBoxStyle.OkOnly, "Error")
        End Try
    End Sub

    Private Sub gvDet_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gvDet.CellClick
        If e.RowIndex > -1 AndAlso e.ColumnIndex = 0 Then
            Dim Resp As MsgBoxResult = MsgBox("¿Está seguro de quitar este cliente?", MsgBoxStyle.YesNo, "Pregunta")

            If (Resp = MsgBoxResult.Yes) Then
                Dim dtDet As New DataTable
                dtDet.Columns.Add("Rut_Cliente")
                dtDet.Columns.Add("Nombre_Cliente")

                For i = 0 To gvDet.Rows.Count - 1
                    If (e.RowIndex <> i) Then
                        Dim row As DataRow = dtDet.NewRow
                        row(0) = gvDet.Rows(i).Cells("Rut_Cliente").Value.ToString.Trim
                        row(1) = gvDet.Rows(i).Cells("Nom_Cliente").Value.ToString.Trim
                        dtDet.Rows.Add(row)
                    End If
                Next

                gvDet.DataSource = dtDet
            End If
        End If
    End Sub

    Private Sub btnEli_Click(sender As System.Object, e As System.EventArgs) Handles btnEli.Click
        Try
            Dim IDLim As String = txtIDLim.Text.Trim
            If (IDLim <> "") Then
                Dim Resp As MsgBoxResult = MsgBox("¿Está seguro de eliminar este límite?", MsgBoxStyle.YesNo, "Pregunta")

                If (Resp = MsgBoxResult.Yes) Then
                    Dim sql As String = "Pedidos_Tipo_Exportacion_Limites_Grupo_Clientes_Eliminar '" & IDLim & "','" & Frm_Principal.InfoUsuario.Text.Trim & "'"
                    fnc.MovimientoSQL(sql)

                    sql = "SP_Pedidos_Tipo_Exportacion_Limites_Grupo_Eliminar '" & IDLim & "','" & Frm_Principal.InfoUsuario.Text.Trim & "'"
                    fnc.MovimientoSQL(sql)

                    MsgBox("Limite eliminado exitosamente.", MsgBoxStyle.OkOnly, "Info.")
                    limpiar()
                End If
            End If
        Catch ex As Exception
            MsgBox("Ocurrió un error al eliminar los datos.", MsgBoxStyle.OkOnly, "Error")
        End Try
    End Sub

    Sub buscarLimite()
        Try
            Dim NomLim As String = txtNomLim.Text.Trim

            If (NomLim <> "") Then
                Dim sql As String = "select a.ID,a.Nombre,a.Limite_Diario from Pedidos_Tipo_Exportacion_Limites_Grupo a with(nolock) where a.Nombre='" & NomLim & "'"
                Dim dt As New DataTable
                dt = fnc.ListarTablasSQL(sql)

                If (dt.Rows.Count > 0) Then
                    Dim IDLim As String = dt.Rows(0).Item(0).ToString.Trim

                    txtIDLim.Text = IDLim
                    txtNomLim.Text = dt.Rows(0).Item(1).ToString.Trim
                    txtLimDia.Text = dt.Rows(0).Item(2).ToString.Trim

                    buscarDetLimite(IDLim)
                End If
            End If
        Catch ex As Exception
            MsgBox("Ocurrió un error al buscar los datos del límite.", MsgBoxStyle.OkOnly, "Error")
        End Try
    End Sub

    Sub buscarDetLimite(ByVal IDLim As String)
        Try
            Dim sql As String = "select a.Rut_Cliente,Nombre_Cliente=b.cli_nomb from Pedidos_Tipo_Exportacion_Limites_Grupo_Clientes a with(nolock) inner join clientes b with(nolock) on(a.Rut_Cliente=b.cli_rut) where a.ID_Limite_Grupo='" & IDLim & "'"
            Dim dt As New DataTable
            dt = fnc.ListarTablasSQL(sql)

            gvDet.DataSource = dt

            btn_BuscaCliente.Focus()
        Catch ex As Exception
            MsgBox("Ocurrió un error al buscar los clientes del límite.", MsgBoxStyle.OkOnly, "Error")
        End Try
    End Sub

    Private Sub txtNomLim_LostFocus(sender As Object, e As System.EventArgs) Handles txtNomLim.LostFocus
        buscarLimite()
    End Sub

    Private Sub btnBusLim_Click(sender As System.Object, e As System.EventArgs) Handles btnBusLim.Click
        Try
            Dim frm As New Limite_Pedidos_Exportacion_Buscar
            frm.ShowDialog(Frm_Principal)

            txtNomLim.Text = Frm_Principal.buscavalor

            buscarLimite()
        Catch ex As Exception
            MsgBox("Ocurrió un error al buscar los límites de pedidos exportación.", MsgBoxStyle.OkOnly, "Error")
        End Try
    End Sub
End Class
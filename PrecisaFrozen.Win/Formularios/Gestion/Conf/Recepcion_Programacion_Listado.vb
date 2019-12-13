Public Class Recepcion_Programacion_Listado

    Dim fnc As New Funciones
    Dim valorRecibido As String = ""

    Private Sub btnSal_Click(sender As System.Object, e As System.EventArgs) Handles btnSal.Click
        Me.Close()
    End Sub

    Private Sub Recepcion_Programacion_Listado_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        f_ReceProgList = False
        tmrAct.Stop()
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
        txtclinom.Text = ""
        TxtClirut.Text = ""
        btn_BuscaCliente.Enabled = True
        chkLimFec.Checked = False
        txtFecIni.Value = Now
        txtFecIni.Enabled = False
        txtFecFin.Value = Now
        txtFecFin.Enabled = False
        cboTun.SelectedIndex = 0
        cboTipCar.SelectedIndex = 0
        cboTipExp.SelectedIndex = 0
        cboEst.SelectedIndex = 0

        cargarRecepciones()

        btn_BuscaCliente.Focus()
    End Sub

    Private Sub btnLim_Click(sender As System.Object, e As System.EventArgs) Handles btnLim.Click
        limpiar()
    End Sub

    Sub cargarCargas()
        Try
            Dim sql As String = "select * from CARGA_DESCARGA with(nolock)"
            Dim dt As New DataTable

            dt = fnc.ListarTablasSQL(sql)

            Dim row As DataRow = dt.NewRow
            row(0) = ""
            row(1) = "Seleccione"
            dt.Rows.InsertAt(row, 0)

            cboTipCar.ValueMember = "Codigo"
            cboTipCar.DisplayMember = "Desc"
            cboTipCar.DataSource = dt
        Catch ex As Exception
            MsgBox("Ocurrió un error al cargar tipos de carga.", MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Sub cargarTipoExportacion()
        Try
            Dim sql As String = "select ID,Tipo from Pedidos_Tipo_Exportacion with(nolock)"
            Dim dt As New DataTable

            dt = fnc.ListarTablasSQL(sql)

            Dim row As DataRow = dt.NewRow
            row(0) = "-1"
            row(1) = "Seleccione"
            dt.Rows.InsertAt(row, 0)

            cboTipExp.ValueMember = "ID"
            cboTipExp.DisplayMember = "Tipo"
            cboTipExp.DataSource = dt
        Catch ex As Exception
            MsgBox("Ocurrió un error al cargar tipos de exportación.", MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Sub cargarTunel()
        Try
            Dim dt As New DataTable

            dt.Columns.Add("ID")
            dt.Columns.Add("Tunel")

            Dim row0 As DataRow = dt.NewRow
            row0(0) = ""
            row0(1) = "Seleccione"
            dt.Rows.Add(row0)

            Dim row As DataRow = dt.NewRow
            row(0) = "0"
            row(1) = "No"
            dt.Rows.Add(row)

            Dim row1 As DataRow = dt.NewRow
            row1(0) = "1"
            row1(1) = "Si"
            dt.Rows.Add(row1)

            cboTun.ValueMember = "ID"
            cboTun.DisplayMember = "Tunel"
            cboTun.DataSource = dt
        Catch ex As Exception
            MsgBox("Ocurrió un error al cargar estado túnel.", MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Sub cargarEstados()
        Try
            Dim dt As New DataTable

            dt.Columns.Add("ID")
            dt.Columns.Add("Estado")

            Dim row0 As DataRow = dt.NewRow
            row0(0) = ""
            row0(1) = "Seleccione"
            dt.Rows.Add(row0)

            Dim row As DataRow = dt.NewRow
            row(0) = "P"
            row(1) = "Pendientes"
            dt.Rows.Add(row)

            Dim row1 As DataRow = dt.NewRow
            row1(0) = "R"
            row1(1) = "Registrados"
            dt.Rows.Add(row1)

            cboEst.ValueMember = "ID"
            cboEst.DisplayMember = "Estado"
            cboEst.DataSource = dt
        Catch ex As Exception
            MsgBox("Ocurrió un error al cargar estados tickets.", MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Sub cargarRecepciones()
        Try
            Dim CantErr As Integer = 0
            Dim MsjErr As String = "Errores encontrados:"

            Dim RutCli As String = TxtClirut.Text.Trim

            Dim FecIni As String = ""
            Dim FecFin As String = ""

            If (chkLimFec.Checked) Then
                If (txtFecIni.Value > txtFecFin.Value) Then
                    CantErr += 1
                    MsjErr &= vbCrLf & "- La fecha inicial debe ser menor o igual a la de término."
                Else
                    FecIni = txtFecIni.Value.ToString("yyyyMMdd").Trim
                    FecFin = txtFecFin.Value.ToString("yyyyMMdd").Trim
                End If
            End If

            Dim Tun As String = cboTun.SelectedValue.ToString.Trim

            Dim TipCar As String = cboTipCar.SelectedValue.ToString.Trim

            Dim TipExp As String = cboTipExp.SelectedValue.ToString.Trim
            If (TipExp = "-1") Then
                TipExp = ""
            End If

            Dim Est As String = cboEst.SelectedValue.ToString.Trim

            If (CantErr > 0) Then
                MsgBox(MsjErr, MsgBoxStyle.Critical, "Error")
            Else
                Dim sql As String = "select * from V_Recepciones_Programacion with(nolock) where Rut_Cliente like '" & RutCli & "%'"

                If (FecIni <> "") Then
                    sql &= " and convert(date,Fecha)>='" & FecIni & "'"
                End If

                If (FecFin <> "") Then
                    sql &= " and convert(date,Fecha)<='" & FecFin & "'"
                End If

                sql &= " and Tipo_Carga like '" & TipCar & "%'"
                sql &= " and Tipo_Exportacion like '" & TipExp & "%'"
                sql &= " and Tunel like '" & Tun & "%'"
                sql &= " and Estado like '" & Est & "%'"
                sql &= " order by convert(date,Fecha),Hora_Inicio asc"

                Dim dt As New DataTable

                dt = fnc.ListarTablasSQL(sql)

                'gvRece.Columns("ID").DisplayIndex = 0
                'gvRece.Columns("Fecha").DisplayIndex = 1
                'gvRece.Columns("Fecha_Frm").DisplayIndex = 2
                'gvRece.Columns("Hora_Inicio").DisplayIndex = 3
                'gvRece.Columns("Hora_Termino").DisplayIndex = 4
                'gvRece.Columns("Rut_Cliente").DisplayIndex = 5
                'gvRece.Columns("Cliente").DisplayIndex = 6
                'gvRece.Columns("Tipo_Carga").DisplayIndex = 7
                'gvRece.Columns("Tipo_Carga_Frm").DisplayIndex = 8
                'gvRece.Columns("Tipo_Exportacion").DisplayIndex = 9
                'gvRece.Columns("Tipo_Exportacion_Frm").DisplayIndex = 10
                'gvRece.Columns("Tunel").DisplayIndex = 11
                'gvRece.Columns("Tunel_Frm").DisplayIndex = 12
                'gvRece.Columns("Total_Soportantes").DisplayIndex = 13
                'gvRece.Columns("Total_Peso").DisplayIndex = 14
                'gvRece.Columns("Observaciones").DisplayIndex = 15
                'gvRece.Columns("btnEli").DisplayIndex = 16

                gvRece.DataSource = dt
            End If
        Catch ex As Exception
            MsgBox("Ocurrió un error al cargar las recepciones programadas.", MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub Recepcion_Programacion_Listado_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        cargarTunel()
        cargarCargas()
        cargarTipoExportacion()
        cargarEstados()
        limpiar()
        tmrAct.Interval = 120000
        tmrAct.Start()
    End Sub

    Private Sub btnFil_Click(sender As System.Object, e As System.EventArgs) Handles btnFil.Click
        cargarRecepciones()
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

    Private Sub gvRece_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gvRece.CellClick
        Try
            If (e.RowIndex > -1) Then
                Dim ID As String = gvRece.Rows(e.RowIndex).Cells("ID").Value.ToString.Trim
                Dim Est As String = gvRece.Rows(e.RowIndex).Cells("Estado").Value.ToString.Trim

                If (gvRece.Columns(e.ColumnIndex).Name = "btnEli") Then
                    If (Est = "P") Then
                        Dim RespMsj As MsgBoxResult = MsgBox("¿Seguro de eliminar esta programación de recepción?", MsgBoxStyle.YesNo, "Pregunta")

                        If (RespMsj = MsgBoxResult.Yes) Then
                            Dim sql As String = "Recepciones_Programacion_Eliminar '" & ID & "','" & Frm_Principal.InfoUsuario.Text.Trim & "'"
                            Dim dt As New DataTable

                            dt = fnc.ListarTablasSQL(sql)

                            If (dt.Rows.Count > 0) Then
                                Dim Resp As String = dt.Rows(0).Item(0).ToString.Trim

                                If (Resp <> "-1") Then
                                    MsgBox("Programación eliminada exitosamente.", MsgBoxStyle.Information, "Éxito")
                                    cargarRecepciones()
                                Else
                                    MsgBox("Ocurrió un error al eliminar programación reserva.", MsgBoxStyle.Critical, "Error")
                                End If
                            Else
                                MsgBox("Ocurrió un error al eliminar programación reserva.", MsgBoxStyle.Critical, "Error")
                            End If
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("Ocurrió un error al eliminar programación reserva.", MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub tmrAct_Tick(sender As Object, e As System.EventArgs) Handles tmrAct.Tick
        cargarRecepciones()
    End Sub
End Class
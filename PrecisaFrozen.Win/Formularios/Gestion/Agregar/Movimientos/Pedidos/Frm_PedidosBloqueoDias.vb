Public Class Frm_PedidosBloqueoDias
    Dim fnc As New Funciones

    Private Sub Frm_PedidosBloqueoDias_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        f_bloqDias = False
    End Sub

    Private Sub Frm_PedidosBloqueoDias_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        loadCboTipoCarga()
        loadDgvBloq()
        loadDgvRes()
        txtUsuCod.Text = Frm_Principal.InfoUsuario.Text.Trim
        txtUsuRes.Text = Frm_Principal.InfoUsuario.Text.Trim
    End Sub

    Sub loadCboTipoCarga()
        Try
            Dim dtCbo As New DataTable

            dtCbo.Columns.Add("IdTipoCarga")
            dtCbo.Columns.Add("Descripcion")

            'Dim row As DataRow = dtCbo.NewRow
            'row(0) = "-1"
            'row(1) = "Seleccione"
            'dtCbo.Rows.Add(row)

            Dim sql = "select IdTipoCarga,Descripcion from m_tipo_carga with(nolock)"
            Dim dt As New DataTable
            dt = fnc.ListarTablasSQL(sql)

            If (dt.Rows.Count > 0) Then
                For i = 0 To dt.Rows.Count - 1
                    Dim row2 As DataRow = dtCbo.NewRow
                    row2(0) = dt.Rows(i).Item(0).ToString.Trim
                    row2(1) = dt.Rows(i).Item(1).ToString.Trim
                    dtCbo.Rows.Add(row2)
                Next
            End If

            cboTipCar.DataSource = dtCbo
            cboTipCar.ValueMember = "IdTipoCarga"
            cboTipCar.DisplayMember = "Descripcion"
        Catch ex As Exception
            MessageBox.Show("Ocurrio un error al cargar los tipos de carga", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub loadDgvBloq()
        Try
            Dim sql = "select IdRestriccionBloq=IdRestriccion,IdUsuarioBloq=IdUsuario,FechaRestriccionBloq=convert(varchar,FechaRestriccion,103),HoraInicioBloq=left(HoraInicio,5),HoraTerminoBloq=left(HoraTermino,5),MotivoBloq=Motivo,FechaIngresoBloq=FechaIngreso from m_restriccion with(nolock) order by convert(date,FechaRestriccion) desc, HoraInicio desc"
            Dim dt As New DataTable
            dt = fnc.ListarTablasSQL(sql)

            If (dt.Rows.Count > 0) Then
                dgvBloq.DataSource = dt
            End If
        Catch ex As Exception
            MessageBox.Show("Ocurrio un error al cargar los Bloqueos Fecha/Horas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub loadDgvRes()
        Try
            Dim sql = "select IdRestriccionRes=a.IdRestriccionService,IdUsuarioRes=a.IdUsuario,IdTipoCargaRes=a.TipoCarga,TipoCargaRes=b.Descripcion,HoraInicioRes=a.HoraInicio,HoraTerminoRes=a.HoraTermino,HoraLimiteRes=a.HoraLimite,FechaIngresoRes=a.FechaIngreso from m_restriccion_service a with(nolock) inner join m_tipo_carga b with(nolock) on(a.TipoCarga=b.IdTipoCarga) order by IdRestriccionRes desc"
            Dim dt As New DataTable
            dt = fnc.ListarTablasSQL(sql)

            If (dt.Rows.Count > 0) Then
                dgvRes.DataSource = dt
            End If
        Catch ex As Exception
            MessageBox.Show("Ocurrio un error al cargar las Reservas de Precisa Service", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvBloq_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvBloq.CellDoubleClick
        Try
            Dim IdRes = dgvBloq.Rows(e.RowIndex).Cells.Item(0).Value.ToString.Trim
            Dim IdUsu = dgvBloq.Rows(e.RowIndex).Cells.Item(1).Value.ToString.Trim
            Dim FecRes = dgvBloq.Rows(e.RowIndex).Cells.Item(2).Value.ToString.Trim
            Dim HraIni = dgvBloq.Rows(e.RowIndex).Cells.Item(3).Value.ToString.Trim
            Dim HraFin = dgvBloq.Rows(e.RowIndex).Cells.Item(4).Value.ToString.Trim
            Dim Mot = dgvBloq.Rows(e.RowIndex).Cells.Item(5).Value.ToString.Trim
            Dim FecIng = dgvBloq.Rows(e.RowIndex).Cells.Item(6).Value.ToString.Trim

            txtIdBloq.Text = IdRes
            'txtUsuCod.Text = IdUsu
            calFecBloq.Text = FecRes
            txtHraIniBloq.Text = HraIni
            txtHraFinBloq.Text = HraFin
            txtMotBloq.Text = Mot
            txtFecIngBloq.Text = FecIng
        Catch ex As Exception
            MessageBox.Show("Ocurrio un error al intentar modificar este registro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub limpiarBloq()
        txtIdBloq.Text = ""
        txtUsuCod.Text = Frm_Principal.InfoUsuario.Text.Trim
        calFecBloq.Text = Date.Now.ToString()
        txtHraIniBloq.Text = ""
        txtHraFinBloq.Text = ""
        txtMotBloq.Text = ""
        txtFecIngBloq.Text = ""
        loadDgvBloq()
    End Sub

    Sub limpiarRes()
        txtIdRes.Text = ""
        txtUsuRes.Text = Frm_Principal.InfoUsuario.Text.Trim
        cboTipCar.SelectedIndex = 0
        txtHraIniRes.Text = ""
        txtHraTerRes.Text = ""
        txtHraLimRes.Text = ""
        txtFecIngRes.Text = ""
        loadDgvRes()
    End Sub

    Private Sub dgvRes_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRes.CellDoubleClick
        Try
            Dim IdRes = dgvRes.Rows(e.RowIndex).Cells.Item(0).Value.ToString.Trim
            Dim IdUsu = dgvRes.Rows(e.RowIndex).Cells.Item(1).Value.ToString.Trim
            Dim IdTipCar = dgvRes.Rows(e.RowIndex).Cells.Item(2).Value.ToString.Trim
            Dim TipCar = dgvRes.Rows(e.RowIndex).Cells.Item(3).Value.ToString.Trim
            Dim HraIni = dgvRes.Rows(e.RowIndex).Cells.Item(4).Value.ToString.Trim
            Dim HraFin = dgvRes.Rows(e.RowIndex).Cells.Item(5).Value.ToString.Trim
            Dim HraLim = dgvRes.Rows(e.RowIndex).Cells.Item(6).Value.ToString.Trim
            Dim FecIng = dgvRes.Rows(e.RowIndex).Cells.Item(7).Value.ToString.Trim

            txtIdRes.Text = IdRes
            'txtUsuRes.Text = IdUsu
            cboTipCar.SelectedValue = IdTipCar
            txtHraIniRes.Text = HraIni
            txtHraTerRes.Text = HraFin
            txtHraLimRes.Text = HraLim
            txtFecIngRes.Text = FecIng
        Catch ex As Exception
            MessageBox.Show("Ocurrio un error al intentar modificar este registro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnGraBloq_Click(sender As System.Object, e As System.EventArgs) Handles btnGraBloq.Click
        Try
            Dim IdRes = txtIdBloq.Text.Trim
            Dim IdUsu = txtUsuCod.Text.Trim
            Dim FecRes = CDate(calFecBloq.Text.Trim).ToString("yyyyMMdd")
            Dim HraIni = txtHraIniBloq.Text.Trim
            Dim HraFin = txtHraFinBloq.Text.Trim
            Dim Mot = txtMotBloq.Text.Trim

            Dim sql = "SP_m_restriccion_grabar '" & IdRes & "','" & IdUsu & "','" & FecRes & "','" & HraIni & "','" & HraFin & "','" & Mot & "'"
            Dim dt As New DataTable
            dt = fnc.ListarTablasSQL(sql)

            If (dt.Rows.Count > 0) Then
                If (dt.Rows(0).Item(0).ToString.Trim = "0") Then
                    MessageBox.Show("Registro exitoso", "Info!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    limpiarBloq()
                Else
                    MessageBox.Show("Ocurrio un error al guardar este registro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("Ocurrio un error al guardar este registro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Ocurrio un error al guardar este registro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnGraRes_Click(sender As Object, e As System.EventArgs) Handles btnGraRes.Click
        Try
            Dim IdRes = txtIdRes.Text.Trim
            Dim IdUsu = txtUsuRes.Text.Trim
            Dim TipCar = cboTipCar.SelectedValue.ToString.Trim
            Dim HraIni = txtHraIniRes.Text.Trim
            Dim HraFin = txtHraTerRes.Text.Trim
            Dim HraLim = txtHraLimRes.Text.Trim

            Dim sql = "SP_m_restriccion_service_grabar '" & IdRes & "','" & IdUsu & "','" & TipCar & "','" & HraIni & "','" & HraFin & "','" & HraLim & "'"
            Dim dt As New DataTable
            dt = fnc.ListarTablasSQL(sql)

            If (dt.Rows.Count > 0) Then
                If (dt.Rows(0).Item(0).ToString.Trim = "0") Then
                    MessageBox.Show("Registro exitoso", "Info!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    limpiarRes()
                Else
                    MessageBox.Show("Ocurrio un error al guardar este registro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("Ocurrio un error al guardar este registro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Ocurrio un error al guardar este registro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnLimBloq_Click(sender As System.Object, e As System.EventArgs) Handles btnLimBloq.Click
        limpiarBloq()
    End Sub

    Private Sub btnLimRes_Click(sender As System.Object, e As System.EventArgs) Handles btnLimRes.Click
        limpiarRes()
    End Sub

    Private Sub btnEliBloq_Click(sender As System.Object, e As System.EventArgs) Handles btnEliBloq.Click
        Try
            Dim IdRes = txtIdBloq.Text.Trim
            Dim IdUsu = txtUsuCod.Text.Trim

            If (IdRes <> "") Then
                Dim resp = MessageBox.Show("¿Esta seguro de eliminiar este registro?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If (resp = Windows.Forms.DialogResult.Yes) Then
                    Dim sql = "SP_m_restriccion_Eliminar '" & IdRes & "','" & IdUsu & "'"
                    Dim dt As New DataTable
                    dt = fnc.ListarTablasSQL(sql)

                    If (dt.Rows.Count > 0) Then
                        If (dt.Rows(0).Item(0).ToString.Trim = "0") Then
                            MessageBox.Show("Registro eliminado", "Info!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            MessageBox.Show("Ocurrio un error al intentar eliminar este registro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    Else
                        MessageBox.Show("Ocurrio un error al intentar eliminar este registro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            End If

            limpiarBloq()
        Catch ex As Exception
            MessageBox.Show("Ocurrio un error al intentar eliminar este registro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnEliRes_Click(sender As System.Object, e As System.EventArgs) Handles btnEliRes.Click
        Try
            Dim IdRes = txtIdRes.Text.Trim
            Dim IdUsu = txtUsuRes.Text.Trim

            If (IdRes <> "") Then
                Dim resp = MessageBox.Show("¿Esta seguro de eliminiar este registro?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If (resp = Windows.Forms.DialogResult.Yes) Then
                    Dim sql = "SP_m_restriccion_service_Eliminar '" & IdRes & "','" & IdUsu & "'"
                    Dim dt As New DataTable
                    dt = fnc.ListarTablasSQL(sql)

                    If (dt.Rows.Count > 0) Then
                        If (dt.Rows(0).Item(0).ToString.Trim = "0") Then
                            MessageBox.Show("Registro eliminado", "Info!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            MessageBox.Show("Ocurrio un error al intentar eliminar este registro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    Else
                        MessageBox.Show("Ocurrio un error al intentar eliminar este registro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            End If

            limpiarRes()
        Catch ex As Exception
            MessageBox.Show("Ocurrio un error al intentar eliminar este registro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
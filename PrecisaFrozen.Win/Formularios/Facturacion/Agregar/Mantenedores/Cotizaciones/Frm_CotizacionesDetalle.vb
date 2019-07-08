Public Class Frm_CotizacionesDetalle

    Dim fnc As New Funciones

    Public Cotizacion As String = ""
    Public CotizacionNombre As String = ""

    Public rut As String = ""
    Public nombre_cliente As String = ""


    Sub LlenaCombos()

        Dim dgv_CmbMoneda As DataGridViewComboBoxColumn = dgv_servicios.Columns("Dgv_Moneda")
        dgv_CmbMoneda.DataSource = fnc.ListarTablasSQL("SELECT mon_codi, mon_descr FROM monedas WHERE mon_est='0'")
        dgv_CmbMoneda.ValueMember = "mon_codi"
        dgv_CmbMoneda.DisplayMember = "mon_descr"

        CbMonedas.DataSource = fnc.ListarTablasSQL("SELECT mon_codi, mon_descr FROM monedas WHERE mon_est='0'")
        CbMonedas.ValueMember = "mon_codi"
        CbMonedas.DisplayMember = "mon_descr"

        Dim dgv_CmbMedida As DataGridViewComboBoxColumn = dgv_servicios.Columns("Dgv_Medida")
        dgv_CmbMedida.DataSource = fnc.ListarTablasSQL("SELECT med_codi, med_descr FROM medidas")
        dgv_CmbMedida.ValueMember = "med_codi"
        dgv_CmbMedida.DisplayMember = "med_descr"

    End Sub

    Private Sub Frm_ContratosDetalle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LlenaCombos()

        Dim tablaservicios As DataTable = fnc.ListarTablasSQL("SELECT Dcot_activo, Dcot_ServCod, Serv_Nom, CONVERT(varchar(7), Dcot_Valor) AS Dcot_Valor, Dcot_Moneda, Dcot_Medida, Serv_Esc " +
                                                              "FROM CotizacionesDetalle INNER JOIN FacServicios ON Dcot_ServCod=Serv_Cod WHERE Dcot_Codigo='" + Cotizacion + "'")

        dgv_servicios.AutoGenerateColumns = False
        dgv_servicios.DataSource = tablaservicios

        For i As Integer = 0 To dgv_servicios.Rows.Count - 1
            For Each fila As DataGridViewRow In dgv_servicios.Rows
                Dim s As String = fila.Cells(7).Value.ToString()

                Select Case s
                    Case "1"
                        fila.Cells(6).Value = ImageList1.Images(1)
                    Case "0"
                        fila.Cells(6).Value = ImageList1.Images(0)
                End Select
            Next
        Next
        tcliente.Text = nombre_cliente
        tcontrato.Text = CotizacionNombre

    End Sub


    '------------------------------------------------------------------------------------------------------->
    'Eventos Dgv ------------------------------------------------------------------------------------------->
    '------------------------------------------------------------------------------------------------------->

    Private Sub dgv_servicios_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As EventArgs) Handles dgv_servicios.CurrentCellDirtyStateChanged
        If dgv_servicios.IsCurrentCellDirty Then
            dgv_servicios.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub dgv_servicios_CellContentClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgv_servicios.CellClick
        '
        ' Detecta si se ha seleccionado el header de la grilla
        '

        If e.RowIndex = -1 Or e.ColumnIndex = -1 Then
            Return
        End If

        If dgv_servicios.Columns(e.ColumnIndex).Name = "Dgv_Estado" Then

            '
            ' Se toma la fila seleccionada
            '
            Dim row As DataGridViewRow = dgv_servicios.Rows(e.RowIndex)

            '
            ' Se selecciona la celda del checkbox
            '
            Dim cellSelecion As DataGridViewCheckBoxCell = TryCast(row.Cells("Dgv_Estado"), DataGridViewCheckBoxCell)

            If dgv_servicios.Rows(e.RowIndex).Cells("Dgv_Estado").Value = False Then
                dgv_servicios.Rows(e.RowIndex).Cells("Dgv_Estado").Value = True
            Else
                dgv_servicios.Rows(e.RowIndex).Cells("Dgv_Estado").Value = False

            End If
            dgv_servicios_CellEndEdit(sender, e)

        ElseIf dgv_servicios.Columns(e.ColumnIndex).Name = "Dgv_Medida" Then

            '
            ' se obtiene el valor seleccionado en el combo
            '
            Dim combo As DataGridViewComboBoxCell = TryCast(dgv_servicios.Rows(e.RowIndex).Cells(e.ColumnIndex), DataGridViewComboBoxCell)

        ElseIf dgv_servicios.Columns(e.ColumnIndex).Name = "Detalle" Then

            If dgv_servicios.Rows(e.RowIndex).Cells(7).Value = "0" Then
                Exit Sub
            End If

            Dim frm As New Frm_ContratosDetalleEscala
            frm.txtcodservicio.Text = dgv_servicios.Rows(e.RowIndex).Cells("Codigo").Value.ToString()
            frm.txtservicionom.Text = dgv_servicios.Rows(e.RowIndex).Cells("Nombre").Value.ToString()
            frm.txtcontratocod.Text = Cotizacion.ToString
            frm.txtcontratonom.Text = CotizacionNombre.ToString()



            'Dim sql As String = "SELECT  esc_dtramo1, esc_htramo1, esc_valor1, " +
            '    "esc_dtramo2, esc_htramo2, esc_valor2, esc_dtramo3, esc_htramo3, esc_valor3, " +
            '    "esc_dtramo4, esc_htramo4, esc_valor4 " +
            '    "FROM FacEscalas WHERE esc_contr='" + contrato.ToString() + "' AND esc_servi='" + Me.dgv_servicios.Rows(e.RowIndex).Cells("Codigo").Value.ToString() + "'"

            'Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

            'If tabla.Rows.Count > 0 Then

            '    If tabla.Rows(0)(0) <> 0 Then
            '        frm.t1desde.Text = tabla.Rows(0)(0)
            '        frm.t1hasta.Text = tabla.Rows(0)(1)
            '        frm.t1valor.Text = tabla.Rows(0)(2)
            '        frm.Rb_tramo1.Checked = True
            '    End If

            '    If tabla.Rows(0)(3) <> 0 Then
            '        frm.t2desde.Text = tabla.Rows(0)(3)
            '        frm.t2hasta.Text = tabla.Rows(0)(4)
            '        frm.t2valor.Text = tabla.Rows(0)(5)
            '        frm.Rb_tramo2.Checked = True
            '    End If

            '    If tabla.Rows(0)(6) <> 0 Then
            '        frm.t3desde.Text = tabla.Rows(0)(6)
            '        frm.t3hasta.Text = tabla.Rows(0)(7)
            '        frm.t3valor.Text = tabla.Rows(0)(8)
            '        frm.Rb_tramo3.Checked = True
            '    End If

            '    If tabla.Rows(0)(9) <> 0 Then
            '        frm.t4desde.Text = tabla.Rows(0)(9)
            '        frm.t4hasta.Text = tabla.Rows(0)(10)
            '        frm.t4valor.Text = tabla.Rows(0)(11)
            '        frm.Rb_tramo4.Checked = True
            '    End If
            'End If
            frm.ShowDialog(Me)

        End If
    End Sub

    Private Sub dgv_servicios_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgv_servicios.EditingControlShowing
        ' obtener indice de la columna   
        Dim columna As Integer = dgv_servicios.CurrentCell.ColumnIndex

        ' comprobar si la celda en edición corresponde a la columna 6 
        If (columna = 3) Then

            ' referencia a la celda   
            Dim validar As TextBox = CType(e.Control, TextBox)

            ' agregar el controlador de eventos para el KeyPress   
            If validar.Text <> "" Then
                AddHandler validar.KeyPress, AddressOf SoloKilos
            Else
                validar.Text = "0"
            End If

        End If
    End Sub

    Private Sub dgv_servicios_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_servicios.CellEndEdit

        If e.RowIndex > -1 AndAlso e.ColumnIndex > -1 Then
            If Me.dgv_servicios.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString() = "" Then
                dgv_servicios.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = "0"
            End If
            If Convert.ToInt32(Me.dgv_servicios.Rows(e.RowIndex).Cells("Valor").Value.ToString() > 0) Then
                dgv_servicios.Rows(e.RowIndex).Cells("Dgv_Estado").Value = True
            End If
            Dim Actualiza As String = "UPDATE CotizacionesDetalle SET Dcot_activo='" + Convert.ToInt32(Me.dgv_servicios.Rows(e.RowIndex).Cells("Dgv_Estado").Value).ToString() + "' ," +
                                      "Dcot_Valor='" + Me.dgv_servicios.Rows(e.RowIndex).Cells("Valor").Value.ToString() + "', " +
                                      "Dcot_Moneda='" + Me.dgv_servicios.Rows(e.RowIndex).Cells("Dgv_Moneda").Value.ToString() + "', " +
                                      "Dcot_Medida='" + Me.dgv_servicios.Rows(e.RowIndex).Cells("Dgv_Medida").Value.ToString() + "'  " +
                                      "WHERE Dcot_Codigo='" + Cotizacion.ToString() + "' AND Dcot_ServCod='" + Me.dgv_servicios.Rows(e.RowIndex).Cells("Codigo").Value.ToString() + "'"

            fnc.MovimientoSQL(Actualiza)
        End If

    End Sub

    Private Sub CbMonedas_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CbMonedas.KeyPress
        e.Handled = True
    End Sub

    Private Sub BtnAsignar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAsignar.Click
        If MsgBox("Esta Seguro de actualizar toda la información", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbYes Then
            Dim sql As String = "UPDATE CotizacionesDetalle SET Dcot_moneda='" + CbMonedas.SelectedValue.ToString() + "' WHERE Dcot_codigo='" + Cotizacion + "'"
            If fnc.MovimientoSQL(sql) > 0 Then
                MsgBox("Moneda actualizada correctamente", MsgBoxStyle.Information, "Aviso")

                'reload datagrid
                Dim tablaservicios As DataTable = fnc.ListarTablasSQL("SELECT Dcot_activo, Dcot_ServCod, Serv_Nom, CONVERT(varchar(7), Dcot_Valor) AS Dcot_Valor, Dcot_Moneda, Dcot_Medida, Serv_Esc " +
                                                      "FROM CotizacionesDetalle, FacServicios  WHERE Dcot_ServCod=Serv_Cod AND Dcot_Codigo='" + Cotizacion + "'")

                dgv_servicios.AutoGenerateColumns = False
                dgv_servicios.DataSource = tablaservicios


                For i As Integer = 0 To dgv_servicios.Rows.Count - 1
                    For Each fila As DataGridViewRow In dgv_servicios.Rows
                        Dim s As String = fila.Cells(7).Value.ToString()

                        Select Case s
                            Case "1"
                                fila.Cells(6).Value = ImageList1.Images(1)
                            Case "0"
                                fila.Cells(6).Value = ImageList1.Images(0)
                        End Select
                    Next
                Next
            End If
        End If
    End Sub

    Private Sub Frm_ContratosDetalle_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class
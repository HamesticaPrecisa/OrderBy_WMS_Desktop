Public Class Lst_Origenes

    Dim fnc As New Funciones

    Private Sub Lst_Origenes_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        f_LstOrigen = False
    End Sub

    Private Sub Lst_Origenes_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'Dim sql = "SELECT  ori_codi, ori_descr FROM Origen ORDER BY ori_codi ASC"
        Dim sql = "select a.ori_codi,a.ori_descr,Ori_In=isnull(b.Ori_In,0),Ori_Out=isnull(b.Ori_Out,0),Ori_Estadia=isnull(b.Ori_Estadia,0) from Origen a with(nolock) left join Origen_Cobro_Tracking b with(nolock) on(a.ori_codi=b.Ori_Codi) order by a.ori_codi asc"
        BindingSource1.DataSource = fnc.ListarTablasSQL(sql)
        BindingNavigator1.BindingSource = BindingSource1
        DataGridView1.DataSource = BindingSource1
    End Sub

    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.Click
        GridAExcel(Me.DataGridView1)
    End Sub

    Private Sub txtbusca_Click(sender As System.Object, e As System.EventArgs) Handles txtbusca.Click
        'Dim sql = "SELECT  ori_codi, ori_descr FROM Origen WHERE (ori_codi LIKE " +
        '    "'" + txtbusca.Text + "' OR ori_descr LIKE '" + txtbusca.Text + "') " +
        '    "ORDER BY ori_codi ASC"

        Dim sql = "select a.ori_codi,a.ori_descr,Ori_In=isnull(b.Ori_In,0),Ori_Out=isnull(b.Ori_Out,0),Ori_Estadia=isnull(b.Ori_Estadia,0) from Origen a with(nolock) left join Origen_Cobro_Tracking b with(nolock) on(a.ori_codi=b.Ori_Codi) where a.ori_codi='" & txtbusca.Text & "' or a.ori_descr like '%" & txtbusca.Text & "%' order by a.ori_codi asc"

        BindingSource1.DataSource = fnc.ListarTablasSQL(sql)
        BindingNavigator1.BindingSource = BindingSource1
        DataGridView1.DataSource = BindingSource1
    End Sub

    Private Sub Rb_Codigo_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles Rb_Codigo.CheckedChanged
        Lst_Origenes_Load(sender, e)
    End Sub

    Private Sub Rb_Descripción_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles Rb_Descripción.CheckedChanged
        'Dim sql = "SELECT  ori_codi, ori_descr FROM Origen WHERE (ori_codi LIKE " +
        '    "'" + txtbusca.Text + "' OR ori_descr LIKE '%" + txtbusca.Text + "%') " +
        '    "ORDER BY ori_descr ASC"

        Dim sql = "select a.ori_codi,a.ori_descr,Ori_In=isnull(b.Ori_In,0),Ori_Out=isnull(b.Ori_Out,0),Ori_Estadia=isnull(b.Ori_Estadia,0) from Origen a with(nolock) left join Origen_Cobro_Tracking b with(nolock) on(a.ori_codi=b.Ori_Codi) where a.ori_codi='" & txtbusca.Text & "' or a.ori_descr like '%" & txtbusca.Text & "%' order by a.ori_descr asc"

        BindingSource1.DataSource = fnc.ListarTablasSQL(sql)
        BindingNavigator1.BindingSource = BindingSource1
        DataGridView1.DataSource = BindingSource1
    End Sub

    Private Sub ToolStripButton2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton2.Click

        Dim frm As New Frm_AddOrigenes
        frm.ShowDialog()
        Rb_Codigo_CheckedChanged(sender, e)
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Try
            If (e.RowIndex > -1) Then
                Dim NomCol = DataGridView1.CurrentCell.OwningColumn.Name.ToString.Trim
                If (NomCol = "Entrada" Or NomCol = "Salida" Or NomCol = "EstDias") Then
                    Dim chk = Convert.ToBoolean(DataGridView1.CurrentCell.Value)
                    If (chk) Then
                        DataGridView1.CurrentCell.Value = False
                    Else
                        DataGridView1.CurrentCell.Value = True
                    End If

                    grabarCobroTracking(e.RowIndex)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Ocurrio un error al controlar el checkbox de la grilla.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub grabarCobroTracking(ByVal RowIdx As Integer)
        Try
            Dim ColIdxIn = 0
            Dim ColIdxOut = 0
            Dim ColIdxEstDia = 0
            Dim ColIdxCodi = 0

            For i = 0 To DataGridView1.ColumnCount - 1
                Dim ColName = DataGridView1.Rows(RowIdx).Cells(i).OwningColumn.Name.ToString.Trim
                If (ColName = "Entrada") Then
                    ColIdxIn = i
                End If
                If (ColName = "Salida") Then
                    ColIdxOut = i
                End If
                If (ColName = "EstDias") Then
                    ColIdxEstDia = i
                End If
                If (ColName = "DataGridViewTextBoxColumn1") Then
                    ColIdxCodi = i
                End If
            Next

            Dim ValIn As Integer = 0
            Dim ValOut As Integer = 0
            Dim ValEstDia As Integer = 0

            If (Convert.ToBoolean(DataGridView1.Rows(RowIdx).Cells.Item(ColIdxIn).Value)) Then
                ValIn = 1
            Else
                ValIn = 0
            End If
            If (Convert.ToBoolean(DataGridView1.Rows(RowIdx).Cells.Item(ColIdxOut).Value)) Then
                ValOut = 1
            Else
                ValOut = 0
            End If
            If (Convert.ToBoolean(DataGridView1.Rows(RowIdx).Cells.Item(ColIdxEstDia).Value)) Then
                ValEstDia = 1
            Else
                ValEstDia = 0
            End If
            Dim Ori_Codi = DataGridView1.Rows(RowIdx).Cells.Item(ColIdxCodi).Value

            Dim sql = "SP_Origen_Cobro_Tracking_Grabar '" & Ori_Codi & "','" & ValIn & "','" & ValOut & "','" & ValEstDia & "'"
            If (fnc.MovimientoSQL(sql) <> 1) Then
                MessageBox.Show("Ocurrio un error al grabar detalle de cobro tracking.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Ocurrio un error al grabar detalle de cobro tracking.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Dim frm As New Frm_AddOrigenes
        frm.txtcodigo.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString()
        frm.txtdesc.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString()
        frm.txtcodigo.Enabled = False

        frm.ShowDialog()
        Rb_Codigo_CheckedChanged(sender, e)
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If MsgBox("Seguro de eliminar el origen seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbYes Then
            If MsgBox("Está seguro de eliminar el origen", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Aviso") = vbYes Then

                Dim Elimina As String = "DELETE FROM origen WHERE " +
                    "ori_codi='" + Me.DataGridView1.Rows(Val(pos.Text) - 1).Cells(0).Value.ToString() + "'"

                If fnc.MovimientoSQL(Elimina) > 0 Then
                    MsgBox("Registro Eliminado", MsgBoxStyle.Information, "Aviso")
                    Rb_Codigo_CheckedChanged(sender, e)
                End If


            End If
        End If

    End Sub
End Class
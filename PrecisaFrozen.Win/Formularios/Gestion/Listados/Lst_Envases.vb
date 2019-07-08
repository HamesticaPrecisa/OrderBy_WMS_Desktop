Public Class Lst_Envases

    Dim fnc As New Funciones

    Function DevuelveSinCeros(ByVal cadena As String) As String
        Dim cadenaVacia = ""
        Dim i As Integer = 0
        For s = i To cadena.Length - 1
            If cadena.Chars(i) = "0" Then
                i += 1
            Else
                For a = i To cadena.Length - 1
                    cadenaVacia = cadenaVacia + cadena.Chars(a)
                Next

                Return cadenaVacia
                Exit Function
            End If
        Next
        Return cadenaVacia
    End Function

    Private Sub ToolStripButton2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton2.Click
        Frm_AddEnvases.ShowDialog()
        Rb_codigo_CheckedChanged(sender, e)
        If RealizarAccion("005", "011") = False Then
            Exit Sub
        End If
    End Sub

    Private Sub Lst_Envases_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        f_LstEnvases = False
    End Sub

    Private Sub Lst_Envases_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        BindingSource1.DataSource = fnc.ListarTablasSQL("SELECT tenv_codi, tenv_descr, tenv_mater FROM tipoenv " +
                                                        "ORDER BY tenv_codi ASC")
        BindingNavigator1.BindingSource = BindingSource1
        DataGridView1.DataSource = BindingSource1
    End Sub

    Private Sub Rb_codigo_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles Rb_codigo.CheckedChanged
        Lst_Envases_Load(sender, e)
    End Sub

    Private Sub Rb_descrip_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles Rb_descrip.CheckedChanged
        BindingSource1.DataSource = fnc.ListarTablasSQL("SELECT tenv_codi, tenv_descr, tenv_mater FROM tipoenv " +
                                                "ORDER BY tenv_descr ASC")
        BindingNavigator1.BindingSource = BindingSource1
        DataGridView1.DataSource = BindingSource1
    End Sub

    Private Sub Rb_Mater_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles Rb_Mater.CheckedChanged
        BindingSource1.DataSource = fnc.ListarTablasSQL("SELECT tenv_codi, tenv_descr, tenv_mater FROM tipoenv " +
                                                        "ORDER BY tenv_mater ASC")
        BindingNavigator1.BindingSource = BindingSource1
        DataGridView1.DataSource = BindingSource1
    End Sub


    Private Sub DataGridView1_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick

        Dim frm As New Frm_AddEnvases

        Dim palabra As String = Me.DataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString()


        palabra = DevuelveSinCeros(palabra)
        frm.txtcodigo.Text = palabra
        frm.txtdesc.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString()
        frm.txtmaterial.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(2).Value.ToString()
        frm.txtcodigo.Enabled = False
        frm.txtdesc.Enabled = True
        frm.txtmaterial.Enabled = True
        frm.ShowDialog()
        Rb_codigo_CheckedChanged(sender, e)

    End Sub

    Private Sub txtbusca_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtbusca.KeyUp
        BindingSource1.DataSource = fnc.ListarTablasSQL("SELECT tenv_codi, tenv_descr, tenv_mater FROM tipoenv WHERE " +
                                                        "(tenv_codi LIKE '%" + txtbusca.Text + "%' OR tenv_descr LIKE '%" + txtbusca.Text + "%') " +
                                                        "ORDER BY tenv_mater ASC")
        BindingNavigator1.BindingSource = BindingSource1
        DataGridView1.DataSource = BindingSource1
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If RealizarAccion("005", "013") = False Then
            Exit Sub
        End If
        If MsgBox("Esta seguro de eliminar la información seleccionada", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbYes Then
            If MsgBox("Esta por eliminar la información, desea continuar?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo, "Aviso") = vbYes Then

                Dim sql = "DELETE FROM tipoenv WHERE tenv_codi='" + Me.DataGridView1.Rows(Val(posi.Text) - 1).Cells(0).Value.ToString() + "'"

                If fnc.MovimientoSQL(sql) > 0 Then
                    MsgBox("Registro eliminado", MsgBoxStyle.Information, "Aviso")
                    Rb_codigo_CheckedChanged(sender, e)

                End If
            End If

        End If
    End Sub

    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.Click
        GridAExcel(Me.DataGridView1)
    End Sub
End Class
Imports System.Data.SqlClient
Public Class Lst_Informes
    Dim fnc As New Funciones
    Private SqA As SqlDataAdapter

    Private Sub Lst_Informes_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        BindingSource1.DataSource = New Funciones().ListarTablasSQL("SELECT inf_cod As Codigo, inf_nom As Informe, inf_est As Estado, inf_emp As Tipo FROM informes")
        tbl_informes.DataSource = BindingSource1
    End Sub

    Private Sub tbl_informes_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles tbl_informes.CellClick
        Dim codigo As String
        codigo = Convert.ToString(tbl_informes.CurrentRow.Cells(0).Value)
        If tbl_informes.Rows(e.RowIndex).Cells(4).Value.ToString = "" Then

            tbl_informes.Rows(e.RowIndex).Cells(4).Value = "Deshabilitado"

        ElseIf tbl_informes.Rows(e.RowIndex).Cells(4).Value.ToString = "Habilitado" Then

            tbl_informes.Rows(e.RowIndex).Cells(4).Value = "Deshabilitado"

        ElseIf tbl_informes.Rows(e.RowIndex).Cells(4).Value.ToString = "Deshabilitado" Then

            tbl_informes.Rows(e.RowIndex).Cells(4).Value = "Habilitado"

        End If
    End Sub

    Private Sub Rb_Codigo_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles Rb_Codigo.CheckedChanged
        Lst_Informes_Load(sender, e)
    End Sub

    Private Sub Rb_nombre_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles Rb_nombre.CheckedChanged
        BindingSource1.DataSource = New Funciones().ListarTablasSQL("SELECT inf_cod As Codigo, inf_nom As Informe, inf_est As Estado, inf_emp As Tipo FROM informes ORDER BY Informe ASC")
        tbl_informes.DataSource = BindingSource1
    End Sub

    Private Sub Rb_estado_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles Rb_estado.CheckedChanged
        BindingSource1.DataSource = New Funciones().ListarTablasSQL("SELECT inf_cod As Codigo, inf_nom As Informe, inf_est As Estado, inf_emp As Tipo FROM informes ORDER BY Estado ASC")
        tbl_informes.DataSource = BindingSource1
    End Sub

    Private Sub Btn_Guardar_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Guardar.Click
        actualizarInformes()
    End Sub

    Private Sub actualizarinformes()

        Try
            Dim Codigo As String
            Dim Estado As String

            If tbl_informes.Rows.Count > 0 Then

                For i As Integer = 0 To tbl_informes.Rows.Count - 1
                    Codigo = tbl_informes.Rows(i).Cells(0).Value

                    If tbl_informes.Rows(i).Cells(4).Value = "Deshabilitado" Then
                        Estado = "Deshabilitado"
                    ElseIf tbl_informes.Rows(i).Cells(4).Value = "Habilitado" Then
                        Estado = "Habilitado"
                    Else
                        Estado = "Deshabilitado"
                    End If

                    Dim sqlRegistro = "UPDATE informes SET inf_est = '" + Estado + "' WHERE inf_cod='" + Codigo + "'"
                    Dim tabla As DataTable = fnc.ListarTablasSQL(sqlRegistro)

                Next
                MsgBox("Se guardo correctamente")

            End If
        Catch ex As Exception
            MsgBox("Error en guardar")
        End Try

    End Sub

    Private Sub Rb_tipo_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles Rb_tipo.CheckedChanged
        BindingSource1.DataSource = New Funciones().ListarTablasSQL("SELECT inf_cod As Codigo, inf_nom As Informe, inf_est As Estado, inf_emp As Tipo FROM informes ORDER BY inf_emp ASC")
        tbl_informes.DataSource = BindingSource1
    End Sub
End Class
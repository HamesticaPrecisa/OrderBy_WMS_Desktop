Public Class Limite_Pedidos_Exportacion_Buscar

    Dim fnc As New Funciones

    Private Sub Limite_Pedidos_Exportacion_Buscar_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Try
            buscarDatosLimite()
        Catch ex As Exception

        End Try
    End Sub

    Sub buscarDatosLimite()
        Try
            Dim sql As String = "select a.* from V_Pedidos_Tipo_Exportacion_Limites_Grupo a with(nolock) where a.Nombre like '%" & txtNomLim.Text.Trim & "%'"
            Dim dt As New DataTable
            dt = fnc.ListarTablasSQL(sql)

            gvDet.DataSource = dt
        Catch ex As Exception
            MsgBox("Ocurrió un error al buscar los límites de pedidos de exportación.", MsgBoxStyle.OkOnly, "Error")
        End Try
    End Sub

    Private Sub txtNomLim_TextChanged(sender As Object, e As System.EventArgs) Handles txtNomLim.TextChanged
        buscarDatosLimite()
    End Sub

    Private Sub gvDet_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gvDet.CellDoubleClick
        Try
            If (e.RowIndex <> -1) Then
                Dim NomLim As String = gvDet.Rows(e.RowIndex).Cells("Nombre").Value.ToString.Trim
                Frm_Principal.buscavalor = NomLim
                Me.Close()
            End If
        Catch ex As Exception
            MsgBox("Ocurrió un error al retornar datos de límite seleccionado.", MsgBoxStyle.OkOnly, "Error")
        End Try
    End Sub
End Class
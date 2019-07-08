Public Class FRM_ACT_WMS
    Dim fnc As New Funciones

    Private Sub FRM_ACT_WMS_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        f_actWms = False
    End Sub

    Private Sub FRM_ACT_WMS_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        loadDgvAct()
    End Sub

    Sub loadDgvAct()
        Try
            Dim sql = "select a.ID_Actualizacion,Fecha=convert(varchar,a.Fecha,103),a.Nro_Version,a.Usu_Codigo,Usuario=b.usu_nombre+' '+b.usu_ap,a.Descripcion from Log_Actualizaciones_WMS a with(nolock) inner join Usuarios b with(nolock) on(a.Usu_Codigo=b.usu_codigo) order by convert(date,a.Fecha) desc"
            Dim dt As New DataTable
            dt = fnc.ListarTablasSQL(sql)

            dgvAct.DataSource = dt
        Catch ex As Exception
            MessageBox.Show("", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
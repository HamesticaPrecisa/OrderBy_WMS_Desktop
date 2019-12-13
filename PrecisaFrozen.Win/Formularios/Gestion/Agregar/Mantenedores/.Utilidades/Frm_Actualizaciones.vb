Public Class Frm_Actualizaciones
    Dim fnc As New Funciones

    Private Sub Frm_Actualizaciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim tabla As DataTable = fnc.ListarTablasSQL("SELECT TOP(5) Act_Version, Act_Descripcion, Act_Fecha FROM Actualizaciones ORDER BY act_codi desc")
        DataGridView1.DataSource = tabla

        If Frm_Principal.InfoUsuario.Text = "001" Then
            GroupBox1.Visible = True
        End If
    End Sub

    Private Sub Frm_Actualizaciones_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If Frm_Principal.InfoUsuario.Text = "001" Then
            If e.KeyCode = Keys.F1 Then
                GroupBox1.Visible = True
            ElseIf e.KeyCode = Keys.F2 Then
                GroupBox1.Visible = False
            End If
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim sql As String = "INSERT INTO ACTUALIZACIONES (ACT_VERSION, ACT_FECHA, ACT_DESCRIPCION)VALUES('" + txtversion.Text + "','" + devuelve_fecha_Formato2(fnc.DevuelveFechaServidor()) + "','" + txtdescri.Text + "')"
        If fnc.MovimientoSQL(sql) > 0 Then
            MsgBox("Actualizado", MsgBoxStyle.Information, "Aviso")
            txtdescri.Text = ""
            txtversion.Text = ""
            GroupBox1.Visible = False
            Dim tabla As DataTable = fnc.ListarTablasSQL("SELECT TOP(8) Act_Version, Act_Descripcion FROM Actualizaciones ORDER BY act_codi desc")
            DataGridView1.DataSource = tabla
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        System.Diagnostics.Process.Start("http://192.168.1.7:70/gestion/setup.exe")
    End Sub
End Class
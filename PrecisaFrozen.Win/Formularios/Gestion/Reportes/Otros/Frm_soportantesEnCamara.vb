Public Class Frm_soportantesEnCamara
    Dim fnc As New Funciones
    Public TOTAL As Integer = 0
    Private Sub Btn_Calcular_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Calcular.Click


        If txtclinombre.Text = "" Then

            If ComboBox1.Text = "" Then

                Dim SQL As String = "SELECT * FROM VG_POSENCAMARA  "

                DgvResultado.DataSource = fnc.ListarTablasSQL(SQL)
                TOTAL = DgvResultado.Rows.Count
                TextBox1.Text = TOTAL.ToString()
            Else
                Dim SQL As String = "SELECT * FROM VG_POSENCAMARA WHERE nCAMARA ='" + ComboBox1.Text + "' "
                DgvResultado.DataSource = fnc.ListarTablasSQL(SQL)
                TOTAL = DgvResultado.Rows.Count
                TextBox1.Text = TOTAL.ToString()
            End If






        Else
            If ComboBox1.Text = "" Then
                Dim SQL As String = "SELECT * FROM VG_POSENCAMARA WHERE  CLIENTE = '" + txtclinombre.Text + "'"

                DgvResultado.DataSource = fnc.ListarTablasSQL(SQL)
                TOTAL = DgvResultado.Rows.Count
                TextBox1.Text = TOTAL.ToString()
            Else
                Dim SQL As String = "SELECT * FROM VG_POSENCAMARA WHERE nCAMARA ='" + ComboBox1.Text + "' AND CLIENTE = '" + txtclinombre.Text + "'"

                DgvResultado.DataSource = fnc.ListarTablasSQL(SQL)
                TOTAL = DgvResultado.Rows.Count
                TextBox1.Text = TOTAL.ToString()
            End If

        End If
      
    End Sub

    Private Sub btnExcel_Click(sender As System.Object, e As System.EventArgs) Handles btnExcel.Click
        Call GridAExcel(DgvResultado)
    End Sub

    Private Sub btn_BuscaCliente_Click(sender As System.Object, e As System.EventArgs) Handles btn_BuscaCliente.Click
        Dim frm As New Lst_AyudaClientes
        frm.ShowDialog(Frm_Principal)
        Frm_Principal.buscavalor = Frm_Principal.buscavalor

        If Len(Frm_Principal.buscavalor) >= 9 Then
            txtrut.Text = Frm_Principal.buscavalor
            txtclinombre.Text = RetornaCliente(Frm_Principal.buscavalor)
        End If
        Frm_Principal.buscavalor = ""
    End Sub

    Private Sub btn_nuevo_Click(sender As System.Object, e As System.EventArgs) Handles btn_nuevo.Click
        txtrut.Text = ""
        txtclinombre.Text = ""
        ComboBox1.SelectedIndex = 0
        If txtclinombre.Text = "" Then
            Dim SQL As String = "SELECT * FROM VG_POSENCAMARA WHERE CAMARA ='" + ComboBox1.Text + "' "

            DgvResultado.DataSource = fnc.ListarTablasSQL(SQL)


        Else

            Dim SQL As String = "SELECT * FROM VG_POSENCAMARA WHERE CAMARA ='" + ComboBox1.Text + "' AND CLIENTE = '" + txtclinombre.Text + "'"

            DgvResultado.DataSource = fnc.ListarTablasSQL(SQL)
        End If
    End Sub

    Private Sub Frm_soportantesEnCamara_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Frm_Principal.buscavalor = ""

        ComboBox1.DataSource = fnc.ListarTablasSQL("select Ncamara from camaraCONf")
        ComboBox1.ValueMember = "ncamara"
        ComboBox1.DisplayMember = "ncamara"

    End Sub

    Private Sub Frm_soportantesEnCamara_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        f_sopcam = False
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub
End Class
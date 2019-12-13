Public Class Frm_CruceDESREC
    Dim fnc As New Funciones
    Private ds As New DataSet
    Private Sub Frm_CruceDESREC_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        crucelimp()


    End Sub

    Private Sub cruce()
        If txtpedido.Text <> "" Then
            If txtrecep.Text <> "" Then
                Dim str As String = "000" + txtrecep.Text

                Me.DgvResultado.DataSource = fnc.ListarTablasSQL("Select caj_pcod as Pallet ,caj_cod as Caja, dpc_codped as Pedido from vg_cruceinf01 where caj_pcod like'" + str + "%' and dpc_codped='" + txtpedido.Text + "' ")
                Dim A As String = "Select caj_pcod as Pallet ,caj_cod as Caja, dpc_codped as Pedido from vg_cruceinf01 where caj_pcod like'" + str + "%' and dpc_codped='" + str + "' "
            End If
        End If
    End Sub
    Private Sub crucelimp()
        If txtpedido.Text = "" Then
            If txtrecep.Text = "" Then
                Dim str As String = "000000"

                Me.DgvResultado.DataSource = fnc.ListarTablasSQL("Select caj_pcod as Pallet ,caj_cod as Caja, dpc_codped as Pedido from vg_cruceinf01 where caj_pcod like'" + str + "%' and dpc_codped='" + str + "' ")

            End If
        End If
    End Sub

    Private Sub Btn_Calcular_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Calcular.Click
        cruce()

    End Sub

    Private Sub txtpedido_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtpedido.KeyPress
        If e.KeyChar = ChrW(13) Then
            cruce()

        End If
    End Sub

    Private Sub txtrecep_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtrecep.KeyPress
        If e.KeyChar = ChrW(13) Then
            cruce()

        End If
    End Sub

    Private Sub btnExcel_Click(sender As System.Object, e As System.EventArgs) Handles btnExcel.Click
        Call GridAExcel(DgvResultado)
    End Sub

    Private Sub btn_nuevo_Click(sender As System.Object, e As System.EventArgs) Handles btn_nuevo.Click
        txtpedido.Text = ""
        txtrecep.Text = ""
        crucelimp()
        txtpedido.Focus()


    End Sub

    Private Sub Frm_CruceDESREC_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        f_cruce = False
    End Sub
End Class
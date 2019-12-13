Public Class Frm_PackingList
    Dim fnc As New Funciones
    Private Sub btnExcel_Click(sender As System.Object, e As System.EventArgs) Handles btnExcel.Click
        Call GridAExcel(DgvResultado)
    End Sub

    Private Sub Btn_Calcular_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Calcular.Click
        Me.DgvResultado.DataSource = fnc.ListarTablasSQL("Select dpc_codped as Pedido,dpc_numpal as Pallet,dpc_codcaja as Caja,caj_calidad as Calidad,caj_calibre as Calibre,caj_felab as FechaElab,caj_fvenc as FechaVenc ,Caj_unid as Unidad,caj_kg as Kilos,caj_lote as Lote from VG_PACKINGLIST where dpc_codped='" + TextBox1.Text + "' ")

    End Sub

    Private Sub Frm_PackingList_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btn_nuevo_Click(sender As System.Object, e As System.EventArgs) Handles btn_nuevo.Click
        TextBox1.Text = "0000"
        Me.DgvResultado.DataSource = fnc.ListarTablasSQL("Select dpc_codped as Pedido,dpc_numpal as Pallet,dpc_codcaja as Caja,caj_calidad as Calidad,caj_calibre as Calibre,caj_felab as FechaElab,caj_fvenc as FechaVenc ,Caj_unid as Unidad,caj_kg as Kilos,caj_lote as Lote from VG_PACKINGLIST where dpc_codped='" + TextBox1.Text + "' ")
        TextBox1.Text = ""
    End Sub

    Private Sub Frm_PackingList_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        f_plist = False
    End Sub
End Class
Public Class Frm_ControlCamionRec

    Dim fnc As New Funciones
    Private Sub Btn_Calcular_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Calcular.Click
        For i As Integer = 0 To DgvResultado.RowCount - 1
            DgvResultado.Rows.RemoveAt(0)
        Next

        Dim SQL As String = "SELECT Cl_fol as FOLIO, cli_nomb AS CLIENTE,cho_nombre AS CHOFER,Cl_pate AS PATENTE,Cl_estpor AS ESTADO ,Cl_Lleg AS FECHA,frec_codi AS RECEPCION from vg_control_camion_recep " +
                        "WHERE convert(date,Cl_Lleg)='" + devuelve_fecha(Dtfecha.Value) + "' ORDER BY Cl_Lleg DESC "

        DgvResultado.DataSource = fnc.ListarTablasSQL(SQL)
        pintagrilla()
        llenarecepdiarias()

        For i As Integer = 0 To DataGridView2.RowCount - 1
            DataGridView2.Rows.RemoveAt(0)
        Next

        Dim SQL2 As String = "SELECT Cl_fol as FOLIO, cli_nomb AS CLIENTE,cho_nombre AS CHOFER,Cl_pate AS PATENTE,Cl_Estpor AS ESTADO ,Cl_Lleg AS FECHA,fdes_codi AS DESPACHO from vg_control_camion_despa " +
                        "WHERE convert(date,Cl_Lleg)='" + devuelve_fecha(Dtfecha.Value) + "' ORDER BY Cl_Lleg DESC "

        DataGridView2.DataSource = fnc.ListarTablasSQL(SQL2)
        pintagrilla2()
        llenarecepdiarias2()

    End Sub
    Private Sub llenarecepdiarias()

        Dim SQL As String = "SELECT frec_codi as RECEPCION,frec_fecrec AS FECHA , cli_nomb AS CLIENTE , cho_nombre AS CHOFER, cho_patente AS PATENTE ,usu_nombre AS USUARIO FROM VG_FICHRECE_CONT  " +
                        "WHERE frec_fecrec='" + devuelve_fecha(Dtfecha.Value) + "' ORDER BY frec_fecrec DESC "

        DataGridView1.DataSource = fnc.ListarTablasSQL(SQL)



    End Sub


    Private Sub llenarecepdiarias2()

        Dim SQL As String = "SELECT fdes_codi as DESPACHO,fdes_fecha AS FECHA , cli_nomb AS CLIENTE , cho_nombre AS CHOFER, cho_patente AS PATENTE ,usu_nombre AS USUARIO FROM VG_FICHDESPA_CONT  " +
                        "WHERE fdes_fecha='" + devuelve_fecha(Dtfecha.Value) + "' ORDER BY fdes_fecha DESC "

        DataGridView3.DataSource = fnc.ListarTablasSQL(SQL)



    End Sub
    Private Sub Frm_ControlCamionRec_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
    Private Sub pintagrilla()
        For i As Integer = 0 To DgvResultado.Rows.Count - 1
          
                '      MsgBox("paso ")
                If Me.DgvResultado.Rows(i).Cells(6).Value.ToString() = "" Then

                Dim SQL As String = "select * from tmpfichrece where frec_clfol = '" + Me.DgvResultado.Rows(i).Cells(0).Value.ToString() + "'"
                Dim tabla As DataTable = fnc.ListarTablasSQL(SQL)
                If tabla.Rows.Count > 0 Then
                    Me.DgvResultado.Rows(i).Cells(6).Style.BackColor = Color.Green
                    Me.DgvResultado.Rows(i).Cells(6).Value = "EN PROCESO"
                    Me.DgvResultado.Rows(i).Cells(6).Style.ForeColor = Color.White
                Else
                    Me.DgvResultado.Rows(i).Cells(6).Style.BackColor = Color.Red
                    Me.DgvResultado.Rows(i).Cells(6).Value = "NO ASOCIADO"
                    Me.DgvResultado.Rows(i).Cells(6).Style.ForeColor = Color.White

                End If
                'DataGridView3.DataSource = fnc.ListarTablasSQL(SQL)


              

            End If

            'If Me.DgvResultado.Rows(i).Cells(4).Value.ToString() = "1" Then
            '    Me.DgvResultado.Rows(i).Cells(4).Value = "INGRESADO"
            'End If
            'If Me.DgvResultado.Rows(i).Cells(4).Value.ToString() = "0" Then
            '    Me.DgvResultado.Rows(i).Cells(4).Value = "REGISTRADO"
            'End If
        Next
    End Sub
    Private Sub pintagrilla2()
        For i As Integer = 0 To DataGridView2.Rows.Count - 1

            '      MsgBox("paso ")
            If Me.DataGridView2.Rows(i).Cells(6).Value.ToString() = "" Then



                Me.DataGridView2.Rows(i).Cells(6).Style.BackColor = Color.Red
                Me.DataGridView2.Rows(i).Cells(6).Value = "NO ASOCIADO"
                Me.DataGridView2.Rows(i).Cells(6).Style.ForeColor = Color.White

            End If


        Next
    End Sub

    Private Sub Label2_Click(sender As System.Object, e As System.EventArgs) Handles Label2.Click

    End Sub

    Private Sub Frm_ControlCamionRec_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        f_control = False
    End Sub

    Private Sub DgvResultado_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvResultado.CellContentClick

    End Sub

    Private Sub Dtfecha_ValueChanged(sender As System.Object, e As System.EventArgs) Handles Dtfecha.ValueChanged

    End Sub
End Class
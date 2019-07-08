Imports CrystalDecisions.Shared

Public Class Frm_PosicionesSopo

    Dim fnc As New Funciones


    Private Sub TxtSoportante_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtSoportante.KeyPress
        If e.KeyChar = ChrW(13) Then

            Dim sql As String = " SELECT racd_codi, cli_nomb, racd_codpro+' -  '+mae_descr AS producto, racd_ca, racd_ba, racd_co, racd_pi, racd_ni, racd_unidades, racd_peso " +
                                "FROM rackdeta INNER JOIN maeprod ON mae_codi=racd_codpro INNER JOIN clientes ON cli_rut=mae_clirut WHERE racd_codi ='" + CerosAnteriorString(TxtSoportante.Text, 9) + "'"

            Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

            If tabla.Rows.Count > 0 Then
                If esta(CerosAnteriorString(TxtSoportante.Text, 9)) = False Then
                    DgvPosiciones.Rows.Add(tabla.Rows(0)(0).ToString(), tabla.Rows(0)(1).ToString(),
                                                          tabla.Rows(0)(2).ToString(), tabla.Rows(0)(3).ToString(),
                                                          tabla.Rows(0)(4).ToString(), tabla.Rows(0)(5).ToString(),
                                                          tabla.Rows(0)(6).ToString(), tabla.Rows(0)(7).ToString(),
                                                          tabla.Rows(0)(8).ToString(), tabla.Rows(0)(9).ToString())
                    TxtSoportante.Text = ""
                    TxtSoportante.Focus()
                End If
            Else
                MsgBox("El soportante ingresado no existe", MsgBoxStyle.Critical, "Aviso")
                TxtSoportante.Text = ""
            End If
        End If
    End Sub

    Private Sub DgvPosiciones_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvPosiciones.CellClick
        If e.RowIndex > -1 AndAlso e.ColumnIndex = 10 Then
            If MsgBox("Seguro de eliminar el soportante N° " + DgvPosiciones.Rows(e.RowIndex).Cells(0).Value.ToString(), MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbYes Then
                DgvPosiciones.Rows.RemoveAt(e.RowIndex)
            End If
        End If
    End Sub

    Private Sub btn_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        For i = 0 To DgvPosiciones.Rows.Count - 1
            DgvPosiciones.Rows.RemoveAt(0)
        Next
    End Sub

    Private Sub Btn_Salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Salir.Click
        Close()
    End Sub


    Function esta(ByVal cod As String) As Boolean

        For i As Integer = 0 To DgvPosiciones.Rows.Count - 1

            If DgvPosiciones.Rows(i).Cells(0).Value.ToString() = cod Then
                TxtSoportante.Text = ""
                TxtSoportante.Focus()
                Return True
                Exit Function
            End If
        Next
        Return False
    End Function

    Private Sub btn_Imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Imprimir.Click
        If DgvPosiciones.Rows.Count = 0 Then
            MsgBox("No existe información para mostrar", MsgBoxStyle.Critical, "Aviso")
            Exit Sub
        End If

        Dim tabla As DataTable = DgvPosiciones.DataSource
        documentoimp = DateTime.Now.ToString("MM-dd-yy") + "SOP" + TxtSoportante.Text
        Dim frm As Frm_MuestraReporte = New Frm_MuestraReporte
        Dim report As New Rpt_PosicionesSopo


        Dim Ds As New Ds_Posiciones

        For Each row As DataGridViewRow In DgvPosiciones.Rows
            Ds.TABLA.AddTABLARow(row.Cells("CODIGO").Value.ToString(),
                                row.Cells("CLIENTE").Value.ToString(),
                                row.Cells("PRODUCTO").Value.ToString(),
                                row.Cells("CA").Value.ToString(),
                                row.Cells("BA").Value.ToString(),
                                row.Cells("CO").Value.ToString(),
                                row.Cells("PI").Value.ToString(),
                                row.Cells("NI").Value.ToString(),
                                row.Cells("CAJAS").Value.ToString(),
                                row.Cells("KILOS").Value.ToString())
        Next
        Dim crt As New Rpt_PosicionesSopo
        crt.SetDataSource(Ds)

        frm.Contenedor.ReportSource = crt
        frm.ShowDialog()
    End Sub

    Private Sub Frm_PosicionesSopo_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        f_posicionsopo = False
    End Sub

    Private Sub Frm_PosicionesSopo_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
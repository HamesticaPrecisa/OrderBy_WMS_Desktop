Public Class frm_PedidosPalletAdd

    Dim activa As Boolean = False
    Dim fnc As New Funciones

    Private Sub frm_PedidosPalletAdd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Size = New Size(338, 161)
    End Sub

    Private Sub cbtodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbtodos.CheckedChanged
        If cbtodos.Checked = True Then
            marca(True)
            lblseleccionadas.Text = DgvCajas.Rows.Count
        Else
            marca(False)
            lblseleccionadas.Text = "0"
        End If
    End Sub

    Sub marca(ByVal op As Boolean)
        If activa = False Then
            For i As Integer = 0 To DgvCajas.Rows.Count - 1
                DgvCajas.Rows(i).Cells(0).Value = op
            Next
        End If
    End Sub

 
    Private Sub txtpallet_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpallet.KeyPress
        'maximizado 757, 609

        'minimizado 338, 161


        If e.KeyChar = ChrW(13) Then
            If txtpallet.Text.Trim() <> "" Then
                txtpallet.Text = CerosAnteriorString(txtpallet.Text, 9)

                Dim sql As String = "SELECT racd_codi, racd_estado, DESCRIPCION, racd_unidades, racd_peso, CASE WHEN cliente is null THEN 'NO' ELSE 'SI' END as cliente " +
                                    "FROM rackdeta INNER JOIN RACKDETA_ESTADO ON racd_estado=CODIGO INNER JOIN detarece ON drec_codi=racd_codi LEFT JOIN Pedidos_ficha ON cliente=drec_rutcli AND Orden='1832' " +
                                    "WHERE racd_codi='" + txtpallet.Text + "'"

                Dim dt As DataTable = fnc.ListarTablasSQL(sql)

                If dt.Rows.Count > 0 Then

                    If dt.Rows(0)(5).ToString() = "NO" Then
                        MsgBox("El número ingresado no corresponde al cliente", MsgBoxStyle.Critical, "Aviso")
                        txtpallet.Text = ""
                        txtpallet.Focus()
                        Return
                    End If

                    If Convert.ToInt32(dt.Rows(0)(1).ToString()) > 2 Then
                        MsgBox("El número ingresado se encuentra bloqueado", MsgBoxStyle.Critical, "Aviso")
                        txtpallet.Text = ""
                        txtpallet.Focus()
                        Return
                    End If

                    txtpallet.Enabled = False

                    'si tiene traqueo 
                    Dim sql_cajas As String = "SELECT 1 as cb, caj_cod, caj_calidad, caj_calibre, caj_lote, caj_felab FROM detarececajas WHERE caj_pcod='" + txtpallet.Text + "' AND caj_ped='0' "

                    Dim dtb As DataTable = fnc.ListarTablasSQL(sql_cajas)

                    If dtb.Rows.Count = 0 Then
                        MsgBox("El número ingresado no tiene cajas disponibles", MsgBoxStyle.Critical, "Aviso")
                        txtpallet.Text = ""
                        txtpallet.Focus()
                        Return
                    End If

                    lblcantidad.Text = "El soportante tiene " + dt.Rows(0)(3).ToString() + " cajas disponibles "
                    Me.Size = New Size(757, 609)
                    DgvCajas.DataSource = dtb
                    cbtodos.Checked = True

                Else
                    MsgBox("El número ingresado no existe", MsgBoxStyle.Critical, "Aviso")
                    txtpallet.Text = ""
                    txtpallet.Focus()
                End If
            Else
                txtpallet.Text = ""
                txtpallet.Focus()
            End If
        End If


    End Sub

    Private Sub DgvCajas_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvCajas.CellClick, DgvCajas.CellDoubleClick

        If e.RowIndex > -1 AndAlso e.ColumnIndex = 0 Then
            If Convert.ToBoolean(DgvCajas.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) = True Then
                DgvCajas.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = False
                lblseleccionadas.Text = Convert.ToInt32(lblseleccionadas.Text) - 1
            Else
                DgvCajas.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = True
                lblseleccionadas.Text = Convert.ToInt32(lblseleccionadas.Text) + 1
            End If
        End If

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        txtpallet.Text = ""
    End Sub

End Class
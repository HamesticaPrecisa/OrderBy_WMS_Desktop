Public Class Frm_CajasPedido

    Public numero_pedido As Integer = 0
    Public numero_pallet As String = ""

    Dim fnc As New Funciones

    Private Sub Frm_CajasPedido_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim sql As String = "SELECT dpc_codcaja AS CAJA FROM detapedcaja WHERE dpc_numpal='" + numero_pallet.ToString() + "' " +
                            "AND dpc_codped='" + numero_pedido.ToString() + "'"

        DgvCajas.DataSource = fnc.ListarTablasSQL(sql)
        Label2.Text = DgvCajas.Rows.Count
    End Sub

    Private Sub txtlectorcaja_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtlectorcaja.KeyPress

        If e.KeyChar = ChrW(13) Then
            'If txtlectorcaja.Text = "" AndAlso Frm_Principal.InfoUsuario.Text = "001" Then
            '    Dim SqlDeta As String = "INSERT INTO detapredcajas(dpre_npallet, dpre_caja, dpre_nped)VALUES('" + numero_pallet.ToString() + "','" + txtlectorcaja.Text + "','" + numero_pedido.ToString() + "')"
            '    fnc.MovimientoSQL(SqlDeta)

            '    txtlectorcaja.Text = ""
            '    If Label2.Text = "0" Then
            '        Frm_Principal.buscavalor = DgvCajas.Rows.Count
            '        Me.Close()
            '    End If
            'End If

            Dim sql As String = "SELECT caj_ped FROM DetaReceCajas WHERE caj_ped='1' AND caj_pcod='" + numero_pallet.ToString() + "' AND caj_cod='" + txtlectorcaja.Text + "'"
            Dim tabla As DataTable = fnc.ListarTablasSQL(sql)
            If tabla.Rows.Count = 0 Then
                MsgBox("La caja leida no existe o no corresponde al cliente", MsgBoxStyle.Critical, "Aviso")
                txtlectorcaja.Text = ""
            Else
                If tabla.Rows(0)(0).ToString() > 1 Then
                    MsgBox("La caja leida ya se despacho con anterioridad", MsgBoxStyle.Critical, "Aviso")
                Else
                    For Each dgv As DataGridViewRow In DgvCajas.Rows
                        If dgv.Cells(0).Value.ToString() = txtlectorcaja.Text Then
                            If dgv.Cells(0).Style.ForeColor = Color.Green Then
                                MsgBox("La caja ya se encuentra leida", MsgBoxStyle.Information, "Aviso")
                                txtlectorcaja.Text = ""
                                Exit Sub
                            Else
                                Dim val = Convert.ToInt32(Label2.Text)
                                Label2.Text = (val - 1).ToString()
                                dgv.Cells(0).Style.ForeColor = Color.Green

                                'Guarda DetaPredCajas

                                Dim SqlDeta As String = "INSERT INTO detapredcajas(dpre_npallet, dpre_caja, dpre_nped)VALUES('" + numero_pallet.ToString() + "','" + txtlectorcaja.Text + "','" + numero_pedido.ToString() + "')"
                                fnc.MovimientoSQL(SqlDeta)

                                txtlectorcaja.Text = ""
                                If Label2.Text = "0" Then
                                    Frm_Principal.buscavalor = DgvCajas.Rows.Count
                                    Me.Close()
                                    Exit For
                                End If
                            End If
                        End If
                    Next
                End If
            End If
        End If

    End Sub

    Private Sub DgvCajas_CellContentDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvCajas.CellContentDoubleClick
        txtlectorcaja.Text = ""

        txtlectorcaja.Text = Me.DgvCajas.Rows(e.RowIndex).Cells(0).Value.ToString()
        txtlectorcaja.Focus()

    End Sub
End Class
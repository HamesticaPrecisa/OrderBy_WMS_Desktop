Imports System.Data.SqlClient

Public Class Frm_CambiarPallet

    Public cajas = 0
    Public rutcliente = ""

    Dim activa As Boolean = False
    Public modo As String = ""
    Dim fnc As New Funciones
    Dim con As New Conexion

    Private Sub Frm_CambiarPallet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If cajas.ToString() = "1" Then
            titulo.Text = "Seleccione la caja a cambiar"
        Else
            titulo.Text = "Seleccione las " + cajas.ToString() + " a cambiar"
        End If


    End Sub

    Private Sub txtnuevopallet_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnuevopallet.KeyPress

        If e.KeyChar = ChrW(13) Then

            If txtnuevopallet.Text = txtacambiar.Text Then
                MsgBox("El número de pallet ingresado no se encuentra disponible", MsgBoxStyle.Critical, "Aviso")
                txtnuevopallet.Text = ""
                Return
            End If

            Dim sql_detalle As String = "SELECT * FROM Pedidos_detalle WHERE pedido=(SELECT pedido FROM pedidos_ficha WHERE orden='" + txtpedido.Text + "') AND pallet='" + CerosAnteriorString(txtnuevopallet.Text, 9) + "'"

            Dim dtb As DataTable = fnc.ListarTablasSQL(sql_detalle)
            If dtb.Rows.Count > 0 Then
                MsgBox("El pallet ingresado se encuentra en el pedido", MsgBoxStyle.Critical, "Aviso")
                BtnCancela_Click(Nothing, Nothing)
                Return
            End If

            Dim sql As String = "SELECT racd_codi,  drec_sopocli , mae_descr, racd_unidades, racd_peso, racd_ca, racd_ba, racd_co, racd_pi, racd_ni " +
                               "FROM rackdeta, maeprod, detarece WHERE racd_codi=drec_codi AND mae_codi=racd_codpro AND drec_rutcli='" + rutcliente + "' " +
                               "AND racd_estado<>'2' AND racd_codi='" + CerosAnteriorString(txtnuevopallet.Text, 9) + "'"

            Dim dt As DataTable = fnc.ListarTablasSQL(sql)

            If dt.Rows.Count > 0 Then
                txtnuevopallet.Text = CerosAnteriorString(txtnuevopallet.Text, 9)

                Dim _qry As String = "SELECT 'False' AS sel, Caj_cod FROM DetaReceCajas WHERE Caj_Pcod='" + txtnuevopallet.Text + "' and caj_ped='0'"
                DgvCajas.DataSource = fnc.ListarTablasSQL(_qry)

                If DgvCajas.Rows.Count = 0 Then
                    MsgBox("El numero de pallet ingresado no tiene tiene cajas leidas", MsgBoxStyle.Critical, "Aviso")
                    txtnuevopallet.Text = ""
                    Return
                ElseIf DgvCajas.Rows.Count < cajas Then
                    MsgBox("El numero de pallet ingresado tiene menos de " + cajas.ToString() + " cajas", MsgBoxStyle.Critical, "Aviso")
                    BtnCancela_Click(Nothing, Nothing)
                    Return
                End If
                txtnuevopallet.Enabled = False
            Else
                MsgBox("El número de pallet ingresado no se encuentra disponible", MsgBoxStyle.Critical, "Aviso")
                txtnuevopallet.Text = ""
                Return
            End If

        End If
    End Sub

    Private Sub DgvCajas_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvCajas.CellClick
        If e.RowIndex > -1 AndAlso e.ColumnIndex = 0 Then
            If Convert.ToBoolean(DgvCajas.Rows(e.RowIndex).Cells(0).Value) = True Then
                DgvCajas.Rows(e.RowIndex).Cells(0).Value = False
            Else
                DgvCajas.Rows(e.RowIndex).Cells(0).Value = True
            End If
            verificaTodos()
        End If
    End Sub

    Private Sub BtnCancela_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancela.Click
        While (DgvCajas.Rows.Count > 0)
            DgvCajas.Rows.RemoveAt(0)
        End While
        txtnuevopallet.Enabled = True
        txtnuevopallet.Text = ""
        txtnuevopallet.Focus()
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

    Sub verificaTodos()
        Dim count As Integer
        For i As Integer = 0 To DgvCajas.Rows.Count - 1
            If Convert.ToBoolean(DgvCajas.Rows(i).Cells(0).Value) = True Then
                count += 1
            End If
        Next

        If count = DgvCajas.Rows.Count Then
            cbtodos.Checked = True
        Else
            activa = True
            cbtodos.Checked = False
            activa = False
        End If
        lblseleccionadas.Text = count.ToString()
    End Sub

    Private Sub DgvCajas_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvCajas.CellDoubleClick
        If e.RowIndex > -1 AndAlso e.ColumnIndex = 0 Then
            If Convert.ToBoolean(DgvCajas.Rows(e.RowIndex).Cells(0).Value) = True Then
                DgvCajas.Rows(e.RowIndex).Cells(0).Value = False
            Else
                DgvCajas.Rows(e.RowIndex).Cells(0).Value = True
            End If
            verificaTodos()
        End If
    End Sub

    Private Sub BtnCambiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCambiar.Click
        If cajas <> Val(lblseleccionadas.Text) Then
            MsgBox("Debe seleccionar las " + cajas.ToString() + " cajas", MsgBoxStyle.Critical, "Aviso")
            Return
        End If

        If MsgBox("Seguro de cambiar por el soportante seleccionado", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbNo Then
            Return
        End If

        'Operacion de cambio de cajas
        Dim sql_cajas As String = "SELECT dpc_codcaja  FROM detapedcaja WHERE dpc_codped='" + txtpedido.Text + "' AND dpc_numpal='" + txtacambiar.Text + "'"

        Dim dt As DataTable = fnc.ListarTablasSQL(sql_cajas)

        If dt.Rows.Count > 0 Then

            For Each row As DataRow In dt.Rows
                Console.Write(row.Item(0) + "\n")
            Next


            ' Agrego cajas temporal
            For Each row As DataGridViewRow In DgvCajas.Rows
                If row.Cells(0).Value = True Then
                    Dim _agrecajas As String = "INSERT INTO TMPCAMBIOPALLET(CAJA, PEDIDO, PALLET)VALUES('" + row.Cells(1).Value.ToString() + "','" + txtpedido.Text + "','" + txtnuevopallet.Text + "')"
                    If fnc.MovimientoSQL(_agrecajas) = 0 Then
                        MsgBox("Ocurrio un error , Intente nuevamente", MsgBoxStyle.Critical, "Aviso")
                        fnc.MovimientoSQL("DELETE FROM TMPCAMBIOPALLET")
                        Return
                    End If

                End If
            Next


            Try
                con.conectar()

                Dim _cmd As SqlCommand = New SqlCommand("PAG_CAMBIARPALLET", con.con)
                _cmd.CommandType = CommandType.StoredProcedure
                _cmd.Parameters.AddWithValue("@codped", txtpedido.Text)
                _cmd.Parameters.AddWithValue("@pallet_antiguo", txtacambiar.Text)
                _cmd.Parameters.AddWithValue("@pallet_nuevo", txtnuevopallet.Text)
                _cmd.Parameters.AddWithValue("@cajas_cambiar", lblseleccionadas.Text)

                Dim resp As Integer = 0
                Try
                    resp = Convert.ToInt32(_cmd.ExecuteScalar())
                Catch ex As Exception
                    resp = 1
                End Try

                If resp = 0 Then
                    MsgBox("Soportante cambiado exitosamente", MsgBoxStyle.Information, "Aviso")
                    Me.Close()
                ElseIf resp < 4 Then
                    MsgBox("Error esperado al grabar la información" + resp.ToString(), MsgBoxStyle.Critical, "Aviso")
                Else
                    MsgBox("Error inesperado al grabar la información" + resp.ToString(), MsgBoxStyle.Critical, "Aviso")
                End If
                con.cerrar()

            Catch ex As Exception
                MsgBox(ex.Message())
            End Try
        End If

    End Sub
End Class
Public Class FrmPedidosUsuarios
    Dim fnc As New Funciones
    Dim IsOperaciones As Boolean = False
    Sub busca_usuario(ByVal rut As String)

        Dim where As String = ""


        '   where = "AND Usu_SecCod='2'"


        Dim SqlBusca = "SELECT usu_nombre, usu_ap, usu_am, usu_email, usu_anexo, usu_teleme, usu_usuario, usu_pass, " +
                                   "radio, usu_codvig, Usu_SecCod, usu_codigo FROM Usuarios WHERE usu_rut='" + rut + "' " + where

        Dim tabla As DataTable = fnc.ListarTablasSQL(SqlBusca)

        If tabla.Rows.Count > 0 Then

            TxtNom1.Text = tabla.Rows(0)(0).ToString()

            txtcodigo.Text = tabla.Rows(0)(11).ToString()
            TxtAp.Text = tabla.Rows(0)(1).ToString()


            'txtrut.Enabled = False
            'txtrutv.Enabled = False
            'Btn_BuscaUsuarios.Enabled = False


            '  Dim SqlFunciones As String = "SELECT Usu_sprivId, Usu_Fnc FROM UsuariosFunciones WHERE usu_rut='" + txtrut.Text + txtrutv.Text + "'"

        Else

        End If
    End Sub
    Private Sub Btn_BuscaUsuarios_Click(sender As System.Object, e As System.EventArgs) Handles Btn_BuscaUsuarios.Click
        Dim f As New Frm_ListadoUsuarios
        f.ShowDialog(Frm_Principal)
        If Frm_Principal.buscavalor.ToString() <> "" Then
            txtrut.Text = Frm_Principal.buscavalor.ToString().Remove(8)
            txtrutv.Text = Frm_Principal.buscavalor.ToString().Chars(8)
            busca_usuario(Frm_Principal.buscavalor.ToString())
        End If
    End Sub

    Private Sub Btn_Buscar_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Buscar.Click
        'For i As Integer = 0 To DgvResultado.RowCount - 1
        '    DgvResultado.Rows.RemoveAt(0)
        'Next
        txtok.Text = ""
        txtnc.Text = ""
        lblefe.Text = "0"
        Dim CONT1 As Integer = 0
        Dim CONT2 As Integer = 0
        Dim SQL As String = "SELECT * FROM vg_pedidos_encargado " +
                        "WHERE COD = '" + txtcodigo.Text + "'  " +
                         "   AND CONVERT(DATE,TERMINO) BETWEEN '" + devuelve_fecha(dtp_fecini.Value) + "' AND '" + devuelve_fecha(dtp_fecter.Value) + "'"

        DgvResultado.DataSource = fnc.ListarTablasSQL(SQL)

        Dim tabla As DataTable = fnc.ListarTablasSQL(SQL)
        If tabla.Rows.Count > 0 Then
            For i As Integer = 0 To DgvResultado.Rows.Count - 2
                Me.DgvResultado.Rows(i).Cells(10).Value = "OK"
                Dim hora As String = Me.DgvResultado.Rows(i).Cells(5).Value.ToString

                Dim solohora As String = hora.Substring(0, 2)
                Dim solomin As String = hora.Substring(3, 2)

                If solohora >= 1 Then
                    Me.DgvResultado.Rows(i).Cells(0).Style.BackColor = Color.Red
                    Me.DgvResultado.Rows(i).Cells(1).Style.BackColor = Color.Red
                    Me.DgvResultado.Rows(i).Cells(2).Style.BackColor = Color.Red
                    Me.DgvResultado.Rows(i).Cells(3).Style.BackColor = Color.Red
                    Me.DgvResultado.Rows(i).Cells(4).Style.BackColor = Color.Red
                    Me.DgvResultado.Rows(i).Cells(5).Style.BackColor = Color.Red
                    Me.DgvResultado.Rows(i).Cells(6).Style.BackColor = Color.Red
                    Me.DgvResultado.Rows(i).Cells(7).Style.BackColor = Color.Red
                    Me.DgvResultado.Rows(i).Cells(8).Style.BackColor = Color.Red
                    Me.DgvResultado.Rows(i).Cells(9).Style.BackColor = Color.Red
                    Me.DgvResultado.Rows(i).Cells(10).Style.BackColor = Color.Red
                    Me.DgvResultado.Rows(i).Cells(10).Value = "N/C"
                    Me.DgvResultado.Rows(i).Cells(0).Style.ForeColor = Color.White
                    Me.DgvResultado.Rows(i).Cells(1).Style.ForeColor = Color.White
                    Me.DgvResultado.Rows(i).Cells(2).Style.ForeColor = Color.White
                    Me.DgvResultado.Rows(i).Cells(3).Style.ForeColor = Color.White
                    Me.DgvResultado.Rows(i).Cells(4).Style.ForeColor = Color.White
                    Me.DgvResultado.Rows(i).Cells(5).Style.ForeColor = Color.White
                    Me.DgvResultado.Rows(i).Cells(6).Style.ForeColor = Color.White
                    Me.DgvResultado.Rows(i).Cells(7).Style.ForeColor = Color.White
                    Me.DgvResultado.Rows(i).Cells(8).Style.ForeColor = Color.White
                    Me.DgvResultado.Rows(i).Cells(9).Style.ForeColor = Color.White
                    Me.DgvResultado.Rows(i).Cells(10).Style.ForeColor = Color.White
                    CONT1 = CONT1 + 1
                Else

                    If solomin > ComboBox1.Text Then
                        Me.DgvResultado.Rows(i).Cells(0).Style.BackColor = Color.Red
                        Me.DgvResultado.Rows(i).Cells(1).Style.BackColor = Color.Red
                        Me.DgvResultado.Rows(i).Cells(2).Style.BackColor = Color.Red
                        Me.DgvResultado.Rows(i).Cells(3).Style.BackColor = Color.Red
                        Me.DgvResultado.Rows(i).Cells(4).Style.BackColor = Color.Red
                        Me.DgvResultado.Rows(i).Cells(5).Style.BackColor = Color.Red
                        Me.DgvResultado.Rows(i).Cells(6).Style.BackColor = Color.Red
                        Me.DgvResultado.Rows(i).Cells(7).Style.BackColor = Color.Red
                        Me.DgvResultado.Rows(i).Cells(8).Style.BackColor = Color.Red
                        Me.DgvResultado.Rows(i).Cells(9).Style.BackColor = Color.Red
                        Me.DgvResultado.Rows(i).Cells(10).Style.BackColor = Color.Red
                        Me.DgvResultado.Rows(i).Cells(10).Value = "N/C"
                        Me.DgvResultado.Rows(i).Cells(0).Style.ForeColor = Color.White
                        Me.DgvResultado.Rows(i).Cells(1).Style.ForeColor = Color.White
                        Me.DgvResultado.Rows(i).Cells(2).Style.ForeColor = Color.White
                        Me.DgvResultado.Rows(i).Cells(3).Style.ForeColor = Color.White
                        Me.DgvResultado.Rows(i).Cells(4).Style.ForeColor = Color.White
                        Me.DgvResultado.Rows(i).Cells(5).Style.ForeColor = Color.White
                        Me.DgvResultado.Rows(i).Cells(6).Style.ForeColor = Color.White
                        Me.DgvResultado.Rows(i).Cells(7).Style.ForeColor = Color.White
                        Me.DgvResultado.Rows(i).Cells(8).Style.ForeColor = Color.White
                        Me.DgvResultado.Rows(i).Cells(9).Style.ForeColor = Color.White
                        Me.DgvResultado.Rows(i).Cells(10).Style.ForeColor = Color.White
                        CONT1 = CONT1 + 1
                    Else
                        Me.DgvResultado.Rows(i).Cells(0).Style.BackColor = Color.Green
                        Me.DgvResultado.Rows(i).Cells(1).Style.BackColor = Color.Green
                        Me.DgvResultado.Rows(i).Cells(2).Style.BackColor = Color.Green
                        Me.DgvResultado.Rows(i).Cells(3).Style.BackColor = Color.Green
                        Me.DgvResultado.Rows(i).Cells(4).Style.BackColor = Color.Green
                        Me.DgvResultado.Rows(i).Cells(5).Style.BackColor = Color.Green
                        Me.DgvResultado.Rows(i).Cells(6).Style.BackColor = Color.Green
                        Me.DgvResultado.Rows(i).Cells(7).Style.BackColor = Color.Green
                        Me.DgvResultado.Rows(i).Cells(8).Style.BackColor = Color.Green
                        Me.DgvResultado.Rows(i).Cells(9).Style.BackColor = Color.Green
                        Me.DgvResultado.Rows(i).Cells(10).Style.BackColor = Color.Green
                        Me.DgvResultado.Rows(i).Cells(10).Value = "OK"
                        Me.DgvResultado.Rows(i).Cells(0).Style.ForeColor = Color.White
                        Me.DgvResultado.Rows(i).Cells(1).Style.ForeColor = Color.White
                        Me.DgvResultado.Rows(i).Cells(2).Style.ForeColor = Color.White
                        Me.DgvResultado.Rows(i).Cells(3).Style.ForeColor = Color.White
                        Me.DgvResultado.Rows(i).Cells(4).Style.ForeColor = Color.White
                        Me.DgvResultado.Rows(i).Cells(5).Style.ForeColor = Color.White
                        Me.DgvResultado.Rows(i).Cells(6).Style.ForeColor = Color.White
                        Me.DgvResultado.Rows(i).Cells(7).Style.ForeColor = Color.White
                        Me.DgvResultado.Rows(i).Cells(8).Style.ForeColor = Color.White
                        Me.DgvResultado.Rows(i).Cells(9).Style.ForeColor = Color.White
                        Me.DgvResultado.Rows(i).Cells(10).Style.ForeColor = Color.White
                        CONT2 = CONT2 + 1

                    End If



                End If



            Next


        End If
        '      MsgBox("paso ")
        txtok.Text = CONT2.ToString
        txtnc.Text = CONT1.ToString
        Dim cien As Integer = CONT1 + CONT2
        lblefe.Text = Math.Round(CONT2 * 100 / cien, 2)

    End Sub

    Private Sub FrmPedidosUsuarios_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Frm_Principal.buscavalor = ""

        ComboBox1.SelectedIndex = 2
    End Sub

    Private Sub FrmPedidosUsuarios_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        f_pusu = False
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click

    End Sub
End Class
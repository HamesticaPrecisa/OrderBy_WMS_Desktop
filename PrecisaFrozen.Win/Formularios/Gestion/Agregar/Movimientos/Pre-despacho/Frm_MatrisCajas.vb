Public Class Frm_MatrisCajas
    Dim fnc As New Funciones
    Public count As Integer = 0
    Private Sub Frm_MatrisCajas_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim pallet As String = Frm_GuiaPreDespachoAgregar.palletcajas
        Dim sql2 As String = "select Caj_cod from  detarececajas where caj_pcod='" + pallet + "' and caj_ped='0' "

        Dim tabla As DataTable = fnc.ListarTablasSQL(sql2)
        DgvResultado.DataSource = tabla


        If tabla.Rows.Count > 0 Then
            For i As Integer = 0 To DgvResultado.Rows.Count - 2

                DgvResultado.Rows(i).Cells(0).Value = True
                DgvResultado.Columns(1).Width = 230




            Next

        End If



    End Sub

    Private Sub grabartem()
        count = 0
        Dim pt As String = Frm_GuiaPreDespachoAgregar.palletcajas
        Dim cj As String = ""

        For i As Integer = 0 To DgvResultado.Rows.Count - 2

            If DgvResultado.Rows(i).Cells(0).Value = True Then

                cj = Me.DgvResultado.Rows(i).Cells(1).Value.ToString()
                Dim guarda As String = "INSERT INTO tmp_detapredcajas(folio, pallet, caja )VALUES('" + Frm_GuiaPreDespachoAgregar.lblcodigo.Text + "','" + pt + "','" + cj + "')"
                count = count + 1
                fnc.MovimientoSQL(guarda)

            End If
        Next
        MsgBox("Grabación exitosa", MsgBoxStyle.Information, "Aviso")
        Frm_GuiaPreDespachoAgregar.Cant.Text = count.ToString()
    End Sub
    Private Sub Frm_MatrisCajas_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        'Frm_GuiaPreDespachoAgregar.CbCant.Checked = True

    End Sub

    Private Sub BtnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles BtnGuardar.Click
        grabartem()
    End Sub

    Private Sub TextBox1_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = ChrW(13) Then
            For i As Integer = 0 To DgvResultado.Rows.Count - 2


                If DgvResultado.Rows(i).Cells(1).Value = TextBox1.Text Then

                    DgvResultado.Rows(i).Cells(0).Value = False

                End If





            Next



        End If
    End Sub
End Class
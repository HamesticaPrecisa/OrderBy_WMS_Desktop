Public Class Frm_AddPosiciones
    Dim fnc As New Funciones
    Private Sub Frm_AddPosiciones_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        GroupBox2.Enabled = False
        Dim sql As String = "SELECT * FROM VG_POSICIONES"

        DgvResultado.DataSource = fnc.ListarTablasSQL(sql)
    End Sub

    Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtca.TextChanged
        Dim sql As String = "SELECT * FROM VG_POSICIONES where CA like'" + txtca.Text + "%'"

        DgvResultado.DataSource = fnc.ListarTablasSQL(sql)
    End Sub

    Private Sub DgvResultado_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvResultado.CellDoubleClick
        If e.RowIndex >= 0 Then
            txtca.Text = Me.DgvResultado.Rows(e.RowIndex).Cells(0).Value.ToString()
            txtba.Text = Me.DgvResultado.Rows(e.RowIndex).Cells(1).Value.ToString()
            txtco.Text = Me.DgvResultado.Rows(e.RowIndex).Cells(2).Value.ToString()
            txtpi.Text = Me.DgvResultado.Rows(e.RowIndex).Cells(3).Value.ToString()
            txtaltura.Text = Me.DgvResultado.Rows(e.RowIndex).Cells(5).Value.ToString()
            Dim BLOQ As String = Me.DgvResultado.Rows(e.RowIndex).Cells(4).Value.ToString()


            If BLOQ.Trim() = "NO" Then
                txtbloq.Text = "HABILITADA"
                txtbloq.BackColor = Color.Green
                txtbloq.ForeColor = Color.White

            Else
                txtbloq.Text = "BLOQUEADA"
                txtbloq.BackColor = Color.Red
                txtbloq.ForeColor = Color.White
            End If

        End If
    End Sub

    Private Sub Btn_AnulaGuia_Click(sender As System.Object, e As System.EventArgs) Handles Btn_AnulaGuia.Click
        If txtca.Text = "" Then
            MsgBox("Ingrese camara", MsgBoxStyle.Critical, "Aviso")
        Else
            If txtba.Text = "" Then

                MsgBox("Ingrese banda", MsgBoxStyle.Critical, "Aviso")
            Else
                If txtco.Text = "" Then

                    MsgBox("Ingrese columna", MsgBoxStyle.Critical, "Aviso")
                Else

                    If txtpi.Text = "" Then

                        MsgBox("Ingrese piso", MsgBoxStyle.Critical, "Aviso")

                    Else
                        Dim tabla As DataTable = New DataTable
                        tabla = fnc.ListarTablasSQL("SELECT * from vg_posiciones where ca = '" + txtca.Text + "' and ba='" + txtba.Text + "' and co='" + txtco.Text + "' and pi='" + txtpi.Text + "'")

                        If tabla.Rows.Count > 0 Then
                            MsgBox("Posicion ya existe", MsgBoxStyle.Critical, "Aviso")
                        Else

                            Dim sql = "INSERT INTO rack_altura(camara , rack_ba, rack_co, rack_pi,bloqueo,rack_altura)VALUES " +
                                             "('" + txtca.Text + "','" + txtba.Text + "','" + txtco.Text + "','" + txtpi.Text + "','NO','" + txtaltura.Text + "')"

                            If fnc.MovimientoSQL(sql) > 0 Then
                                MsgBox("Soportante agregado correctamente", MsgBoxStyle.Information, "Aviso")
                                LIMPIAR()
                            Else
                                'MsgBox("POSICION DISPONIBLE", MsgBoxStyle.Critical, "Aviso")
                            End If
                        End If
                    End If


                End If


            End If
        End If







    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If txtca.Text = "" Then
            MsgBox("Ingrese camara", MsgBoxStyle.Critical, "Aviso")
        Else
            If txtba.Text = "" Then

                MsgBox("Ingrese banda", MsgBoxStyle.Critical, "Aviso")
            Else
                If txtco.Text = "" Then

                    MsgBox("Ingrese columna", MsgBoxStyle.Critical, "Aviso")
                Else

                    If txtpi.Text = "" Then

                        MsgBox("Ingrese piso", MsgBoxStyle.Critical, "Aviso")

                    Else
                        Dim sql = "UPDATE rack_altura SET bloqueo='SI' " +
                   "where camara  = '" + txtca.Text + "' and rack_ba='" + txtba.Text + "' and rack_co='" + txtco.Text + "' and rack_pi='" + txtpi.Text + "'"
                        If fnc.MovimientoSQL(sql) > 0 Then
                            MsgBox("Estado Modificado correctamente", MsgBoxStyle.Information, "Aviso")
                            LIMPIAR()
                        Else
                            ' MsgBox("Ingrese ok", MsgBoxStyle.Critical, "Aviso")
                        End If

                    End If


                End If


            End If
        End If
    End Sub
    Private Sub LIMPIAR()
        txtaltura.Text = ""
        txtbloq.Text = ""
        txtbloq.ForeColor = Color.Black
        txtbloq.BackColor = Color.White
        txtca.Text = ""
        txtba.Text = ""
        txtco.Text = ""
        txtpi.Text = ""
        Dim sql As String = "SELECT * FROM VG_POSICIONES"
        GroupBox2.Enabled = False
        DgvResultado.DataSource = fnc.ListarTablasSQL(sql)
        txtBaFinal.Text = ""
        txtbanda.Text = ""
        txtcamara.Text = ""
        txtcolumna.Text = ""
        TxtCoFinal.Text = ""
        txtca.Focus()
    End Sub
    Private Sub btn_nuevo_Click(sender As System.Object, e As System.EventArgs) Handles btn_nuevo.Click
        LIMPIAR()

    End Sub

    Private Sub Frm_AddPosiciones_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        f_manpos = False
    End Sub

    Private Sub btn_informes_Click(sender As System.Object, e As System.EventArgs) Handles btn_informes.Click
        If txtca.Text = "" Then
            MsgBox("Ingrese camara", MsgBoxStyle.Critical, "Aviso")
        Else
            If txtba.Text = "" Then

                MsgBox("Ingrese banda", MsgBoxStyle.Critical, "Aviso")
            Else
                If txtco.Text = "" Then

                    MsgBox("Ingrese columna", MsgBoxStyle.Critical, "Aviso")
                Else

                    If txtpi.Text = "" Then

                        MsgBox("Ingrese piso", MsgBoxStyle.Critical, "Aviso")

                    Else
                        Dim sql = "UPDATE rack_altura SET bloqueo='NO' " +
                   "where camara  = '" + txtca.Text + "' and rack_ba='" + txtba.Text + "' and rack_co='" + txtco.Text + "' and rack_pi='" + txtpi.Text + "'"
                        If fnc.MovimientoSQL(sql) > 0 Then
                            MsgBox("Estado Modificado correctamente", MsgBoxStyle.Information, "Aviso")
                            LIMPIAR()
                        Else
                            ' MsgBox("Ingrese ok", MsgBoxStyle.Critical, "Aviso")
                        End If

                    End If


                End If


            End If
        End If
    End Sub

    Private Sub RbRangos_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RbRangos.CheckedChanged
        If RbRangos.Checked = True Then
            GroupBox2.Enabled = True
        Else
            GroupBox2.Enabled = False

        End If
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click


        If txtcamara.Text = "" Then
            MsgBox("Ingrese camara", MsgBoxStyle.Critical, "Aviso")
        Else
            If txtbanda.Text = "" Then

                MsgBox("Ingrese banda", MsgBoxStyle.Critical, "Aviso")
            Else
                If txtcolumna.Text = "" Then

                    MsgBox("Ingrese columna", MsgBoxStyle.Critical, "Aviso")
                Else

                    If txtBaFinal.Text = "" Then
                        txtBaFinal.Text = "1"
                    End If
                    If TxtCoFinal.Text = "" Then
                        TxtCoFinal.Text = "1"
                    End If
                    Dim ijxd As Integer = 0
                    Dim columna = Val(txtcolumna.Text)
                    If RbRangos.Checked = True Then
                        For i As Integer = Val(txtbanda.Text) To Convert.ToInt32(txtBaFinal.Text)

                            For j As Integer = columna To Convert.ToInt32(TxtCoFinal.Text)

                                txtbanda.Text = CerosAnteriorString(i, 2)
                                txtcolumna.Text = CerosAnteriorString(j, 2)
                                Dim piso As String = "1"

                                System.Console.WriteLine(txtcamara.Text + " " + txtbanda.Text + " " + txtcolumna.Text)
                                'proceso

                                Dim sql = "INSERT INTO rack_altura(camara , rack_ba, rack_co, rack_pi,bloqueo,rack_altura)VALUES " +
                                         "('" + txtcamara.Text + "','" + txtbanda.Text + "','" + txtcolumna.Text + "','" + piso + "','NO','" + altura.Text + "')"


                                If fnc.MovimientoSQL(sql) > 0 Then


                                    '  MsgBox("Soportante agregado correctamente", MsgBoxStyle.Information, "Aviso")

                                Else
                                    'MsgBox("POSICION DISPONIBLE", MsgBoxStyle.Critical, "Aviso")
                                End If

                                ijxd = ijxd + 1



                            Next

                        Next
                        MsgBox("Soportantes agregados correctamente", MsgBoxStyle.Information, "Aviso")

                        LIMPIAR()
                    Else
                    End If




                End If


            End If
        End If





    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        If txtcamara.Text = "" Then
            MsgBox("Ingrese camara", MsgBoxStyle.Critical, "Aviso")
        Else
            If txtbanda.Text = "" Then

                MsgBox("Ingrese banda", MsgBoxStyle.Critical, "Aviso")
            Else
                If txtcolumna.Text = "" Then

                    MsgBox("Ingrese columna", MsgBoxStyle.Critical, "Aviso")
                Else
                    Dim ijxd As Integer = 0
                    Dim columna = Val(txtcolumna.Text)
                    If RbRangos.Checked = True Then
                        For i As Integer = Val(txtbanda.Text) To Convert.ToInt32(txtBaFinal.Text)

                            For j As Integer = columna To Convert.ToInt32(TxtCoFinal.Text)

                                txtbanda.Text = CerosAnteriorString(i, 2)
                                txtcolumna.Text = CerosAnteriorString(j, 2)
                                Dim piso As String = "1"

                                System.Console.WriteLine(txtcamara.Text + " " + txtbanda.Text + " " + txtcolumna.Text)
                                'proceso


                                Dim sql = "UPDATE rack_altura SET bloqueo='SI' " +
                  "where camara  = '" + txtcamara.Text + "' and rack_ba='" + txtbanda.Text + "' and rack_co='" + txtcolumna.Text + "'"
                                If fnc.MovimientoSQL(sql) > 0 Then


                                    '  MsgBox("Soportante agregado correctamente", MsgBoxStyle.Information, "Aviso")

                                Else
                                    'MsgBox("POSICION DISPONIBLE", MsgBoxStyle.Critical, "Aviso")
                                End If

                                ijxd = ijxd + 1



                            Next

                        Next
                        MsgBox("Soportantes Bloqueados correctamente", MsgBoxStyle.Information, "Aviso")

                        LIMPIAR()
                    Else
                    End If




                End If


            End If
        End If
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        If txtcamara.Text = "" Then
            MsgBox("Ingrese camara", MsgBoxStyle.Critical, "Aviso")
        Else
            If txtbanda.Text = "" Then

                MsgBox("Ingrese banda", MsgBoxStyle.Critical, "Aviso")
            Else
                If txtcolumna.Text = "" Then

                    MsgBox("Ingrese columna", MsgBoxStyle.Critical, "Aviso")
                Else
                    Dim ijxd As Integer = 0
                    Dim columna = Val(txtcolumna.Text)
                    If RbRangos.Checked = True Then
                        For i As Integer = Val(txtbanda.Text) To Convert.ToInt32(txtBaFinal.Text)

                            For j As Integer = columna To Convert.ToInt32(TxtCoFinal.Text)

                                txtbanda.Text = CerosAnteriorString(i, 2)
                                txtcolumna.Text = CerosAnteriorString(j, 2)
                                Dim piso As String = "1"

                                System.Console.WriteLine(txtcamara.Text + " " + txtbanda.Text + " " + txtcolumna.Text)
                                'proceso


                                Dim sql = "UPDATE rack_altura SET bloqueo='NO' " +
                  "where camara  = '" + txtcamara.Text + "' and rack_ba='" + txtbanda.Text + "' and rack_co='" + txtcolumna.Text + "'"
                                If fnc.MovimientoSQL(sql) > 0 Then


                                    '  MsgBox("Soportante agregado correctamente", MsgBoxStyle.Information, "Aviso")

                                Else
                                    'MsgBox("POSICION DISPONIBLE", MsgBoxStyle.Critical, "Aviso")
                                End If

                                ijxd = ijxd + 1



                            Next

                        Next
                        MsgBox("Soportantes Desbloqueados correctamente", MsgBoxStyle.Information, "Aviso")

                        LIMPIAR()
                    Else
                    End If




                End If


            End If
        End If
    End Sub
End Class
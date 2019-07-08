Public Class Frm_AddPicking
    Dim fnc As New Funciones
    Dim valorRecibido As String = ""
    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        If txtcamara.Text = "" Then
            MsgBox("Ingrese camara", MsgBoxStyle.Critical, "Aviso")
        Else
            If chktlc.Checked = True Then
                Dim sql2 = "select * from  CamaraMantenedor  " +
       "where camara  = '" + txtcamara.Text + "'"
                If fnc.MovimientoSQL(sql2) > 0 Then


                    DgvResultado.DataSource = fnc.ListarTablasSQL(sql2)

                End If
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


                            '  txtbanda.Text = CerosAnteriorString(i, 2)
                            '  txtcolumna.Text = CerosAnteriorString(j, 2)
                            Dim piso As String = "1"

                            System.Console.WriteLine(txtcamara.Text + " " + txtbanda.Text + " " + txtcolumna.Text)
                            'proceso


                            Dim sql = "select * from  CamaraMantenedor  " +
              "where camara  = '" + txtcamara.Text + "' and banda >='" + txtbanda.Text + "' and banda <= '" + txtBaFinal.Text + "' and columna >='" + txtcolumna.Text + "' AND columna <='" + TxtCoFinal.Text + "' and piso ='" + txtpiso.Text + "' "
                            If fnc.MovimientoSQL(sql) > 0 Then


                                DgvResultado.DataSource = fnc.ListarTablasSQL(sql)
                                '  MsgBox("Soportante agregado correctamente", MsgBoxStyle.Information, "Aviso")

                            Else
                                'MsgBox("POSICION DISPONIBLE", MsgBoxStyle.Critical, "Aviso")
                            End If

                            ijxd = ijxd + 1




                            '  MsgBox("Soportantes Desbloqueados correctamente", MsgBoxStyle.Information, "Aviso")


                        Else
                        End If




                    End If


                End If
            End If
        End If
    End Sub
    Private Sub recarga()


        If txtcamara.Text = "" Then
            MsgBox("Ingrese camara", MsgBoxStyle.Critical, "Aviso")
        Else
            If chktlc.Checked = True Then
                Dim sql2 = "select * from  CamaraMantenedor  " +
       "where camara  = '" + txtcamara.Text + "'"
                If fnc.MovimientoSQL(sql2) > 0 Then


                    DgvResultado.DataSource = fnc.ListarTablasSQL(sql2)

                End If
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


                            '  txtbanda.Text = CerosAnteriorString(i, 2)
                            '  txtcolumna.Text = CerosAnteriorString(j, 2)
                            Dim piso As String = "1"

                            System.Console.WriteLine(txtcamara.Text + " " + txtbanda.Text + " " + txtcolumna.Text)
                            'proceso


                            Dim sql = "select * from  CamaraMantenedor  " +
              "where camara  = '" + txtcamara.Text + "' and banda >='" + txtbanda.Text + "' and banda <= '" + txtBaFinal.Text + "' and columna >='" + txtcolumna.Text + "' AND columna <='" + TxtCoFinal.Text + "' and piso ='" + txtpiso.Text + "' "
                            If fnc.MovimientoSQL(sql) > 0 Then


                                DgvResultado.DataSource = fnc.ListarTablasSQL(sql)
                                '  MsgBox("Soportante agregado correctamente", MsgBoxStyle.Information, "Aviso")

                            Else
                                'MsgBox("POSICION DISPONIBLE", MsgBoxStyle.Critical, "Aviso")
                            End If

                            ijxd = ijxd + 1




                            '  MsgBox("Soportantes Desbloqueados correctamente", MsgBoxStyle.Information, "Aviso")


                        Else
                        End If




                    End If


                End If
            End If
        End If
        Dim sql4 = "select camara,banda,columna,pi as piso,unidades  from  vg_pos_pick  "
        If fnc.MovimientoSQL(sql4) > 0 Then


            dgpick.DataSource = fnc.ListarTablasSQL(sql4)

        End If
    End Sub

    Private Sub Frm_AddReservas_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        RbRangos.Checked = True


        Dim sql4 = "select camara,banda,columna,pi as piso,unidades  from  vg_pos_pick  "
        If fnc.MovimientoSQL(sql4) > 0 Then


            dgpick.DataSource = fnc.ListarTablasSQL(sql4)

        End If
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub Btn_buscaProducto_Click(sender As System.Object, e As System.EventArgs) Handles Btn_buscaProducto.Click
        Dim frm As New Lst_AyudaProductos
        frm.Condicion = ""
        frm.IsRecepcion = True
        frm.ShowDialog(Frm_Principal)

        If Frm_Principal.buscavalor <> "" Then
            Me.txtprodcod.Text = Frm_Principal.buscavalor

            Dim sqlBusca = "SELECT mae_descr, mae_diasv FROM maeprod WHERE mae_codi='" + txtprodcod.Text + "'"

            Dim tabla As DataTable = fnc.ListarTablasSQL(sqlBusca)
            If tabla.Rows.Count > 0 Then
                txtprodnom.Text = tabla.Rows(0)(0).ToString()

                If Convert.ToInt32(tabla.Rows(0)(1).ToString()) > 0 Then
                    ' fvencimiento.Value = DateAdd(DateInterval.Month, Convert.ToInt32(tabla.Rows(0)(1).ToString()), felaboracion.Value)
                    ''  DiasVenc = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    'fvencimiento.Enabled = False
                Else
                    ' fvencimiento.Enabled = True
                End If

            End If

        End If
        Frm_Principal.buscavalor = ""
    End Sub

    Private Sub btn_BuscaCliente_Click(sender As System.Object, e As System.EventArgs) Handles btn_BuscaCliente.Click
        Dim frm As New Lst_AyudaClientes
        frm.ShowDialog(Frm_Principal)
        Me.valorRecibido = Frm_Principal.buscavalor

        If Len(valorRecibido) >= 9 Then

            Dim SqlBusca As String = "SELECT cli_nomb, cli_estado FROM clientes WHERE " +
                "cli_rut='" + valorRecibido + "'"

            Dim tabla As DataTable = fnc.ListarTablasSQL(SqlBusca)

            If tabla.Rows.Count > 0 Then
                If tabla.Rows(0)(1).ToString() = "N" Then
                    MsgBox("El cliente seleccionado se encuentra bloqueado", MsgBoxStyle.Critical, "Aviso")
                    Exit Sub
                End If

                TxtClirut.Text = valorRecibido
                txtclinom.Text = tabla.Rows(0)(0).ToString()
                ' Btn_BuscaContrato.Enabled = True
                Frm_Principal.buscavalor = ""

                '
                TxtClirut.Enabled = False
            Else
                MsgBox("El rut ingresado no existe", MsgBoxStyle.Information, "Aviso")
            End If
        End If
        Frm_Principal.buscavalor = ""
    End Sub

    Private Sub btn_guardar_Click(sender As System.Object, e As System.EventArgs) Handles btn_guardar.Click

        Dim sql As String = ""
        If RadioButton1.Checked = True Then
            sql = "UPDATE CamaraMantenedor SET  Pos_Picking='" + RadioButton1.Text + "' " +
                                        "where camara  = '" + txtcamara.Text + "' and banda >='" + txtbanda.Text + "' and banda <= '" + txtBaFinal.Text + "' and columna >='" + txtcolumna.Text + "' AND columna <='" + TxtCoFinal.Text + "'"
        End If
        If RadioButton2.Checked = True Then
            sql = "UPDATE CamaraMantenedor SET  Pos_Picking='" + RadioButton2.Text + "' " +
                                        "where camara  = '" + txtcamara.Text + "' and banda >='" + txtbanda.Text + "' and banda <= '" + txtBaFinal.Text + "' and columna >='" + txtcolumna.Text + "' AND columna <='" + TxtCoFinal.Text + "'"
        End If


        If fnc.MovimientoSQL(sql) > 0 Then
            MsgBox("Posiciones Reservadas ", MsgBoxStyle.Information, "Aviso")
            recarga()
        End If
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If txtprodcod.Text <> "" Then



            Dim sql As String = ""
            sql = "UPDATE CamaraMantenedor SET  Reserva_Producto='" + txtprodcod.Text + "' " +
                                          "where camara  = '" + txtcamara.Text + "' and banda >='" + txtbanda.Text + "' and banda <= '" + txtBaFinal.Text + "' and columna >='" + txtcolumna.Text + "' "
            If fnc.MovimientoSQL(sql) > 0 Then
                MsgBox("Posiciones Reservadas ", MsgBoxStyle.Information, "Aviso")
            End If

        End If
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        If TxtClirut.Text <> "" Then



            Dim sql As String = ""
            sql = "UPDATE CamaraMantenedor SET  Reserva_cliente='" + TxtClirut.Text + "' " +
                                          "where camara  = '" + txtcamara.Text + "' and banda >='" + txtbanda.Text + "' and banda <= '" + txtBaFinal.Text + "' and columna >='" + txtcolumna.Text + "' "
            If fnc.MovimientoSQL(sql) > 0 Then
                MsgBox("Posiciones Reservadas ", MsgBoxStyle.Information, "Aviso")
            End If

        End If
    End Sub

    Private Sub Frm_AddReservas_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        f_picking = False
    End Sub
End Class
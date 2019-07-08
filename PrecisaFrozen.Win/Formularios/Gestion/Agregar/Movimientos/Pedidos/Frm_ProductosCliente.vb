Public Class Frm_ProductosCliente

    Public cliente As String = ""
    Public Numero_Pallet As Integer = 0
    Public Rut_Cliente As String = ""
    Public Orden As String = ""

    Dim fnc As New Funciones

    Private Sub Frm_ProductosCliente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim sql As String = "SELECT racd_codi,  drec_sopocli , mae_descr, racd_unidades, racd_peso, racd_ca, racd_ba, racd_co, racd_pi, racd_ni " +
        '"FROM rackdeta, maeprod, detarece WHERE racd_codi=drec_codi AND mae_codi=racd_codpro AND drec_rutcli='" + Rut_Cliente + "' AND racd_estado<>'2'"

        Dim sql As String = "select a.racd_codi,b.drec_sopocli,c.mae_descr,a.racd_unidades,a.racd_peso,a.racd_ca,a.racd_ba,a.racd_co,a.racd_pi,a.racd_ni from rackdeta a with(nolock) inner join detarece b with(nolock) on(a.racd_codi=b.drec_codi) inner join maeprod c with(nolock) on(a.racd_codpro=c.mae_codi) inner join fichrece d with(nolock) on(b.frec_codi1=d.frec_codi) where b.drec_rutcli='" + Rut_Cliente + "' and a.racd_estado<>'2' and a.est_tunel='0' and d.frec_serv=''"

        Data_Productos.DataSource = fnc.ListarTablasSQL(sql)

        Dim sql_combo As String = "SELECT mae_codi, mae_descr FROM maeprod WHERE mae_clirut='" + Rut_Cliente + "'"
        Dim tabla As DataTable = fnc.ListarTablasSQL(sql_combo)
        tabla.Rows.Add("-1", "-- TODOS LOS PRODUCTOS --")
        Cmbo_Producto.DataSource = tabla
        Cmbo_Producto.DisplayMember = "mae_descr"
        Cmbo_Producto.ValueMember = "mae_codi"
        Cmbo_Producto.SelectedValue = -1
    End Sub

    Private Sub Cmbo_Producto_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles Cmbo_Producto.SelectedValueChanged
        If Cmbo_Producto.SelectedValue.ToString() = "-1" Then

            'Dim sql As String = "SELECT racd_codi,  drec_sopocli , mae_descr, racd_unidades, racd_peso, racd_ca, racd_ba, racd_co, racd_pi, racd_ni " +
            '             "FROM rackdeta, maeprod, detarece WHERE  racd_estado<>'2' AND racd_codi=drec_codi AND mae_codi=racd_codpro AND drec_rutcli='" + Rut_Cliente + "'"

            Dim sql As String = "select a.racd_codi,b.drec_sopocli,c.mae_descr,a.racd_unidades,a.racd_peso,a.racd_ca,a.racd_ba,a.racd_co,a.racd_pi,a.racd_ni from rackdeta a with(nolock) inner join detarece b with(nolock) on(a.racd_codi=b.drec_codi) inner join maeprod c with(nolock) on(a.racd_codpro=c.mae_codi) inner join fichrece d with(nolock) on(b.frec_codi1=d.frec_codi) where b.drec_rutcli='" + Rut_Cliente + "' and a.racd_estado<>'2' and a.est_tunel='0' and d.frec_serv=''"

            Data_Productos.DataSource = fnc.ListarTablasSQL(sql)

        Else
            'Dim sql As String = "SELECT racd_codi,  drec_sopocli , mae_descr, racd_unidades, racd_peso, racd_ca, racd_ba, racd_co, racd_pi, racd_ni " +
            '                   "FROM rackdeta, maeprod, detarece WHERE racd_codi=drec_codi AND mae_codi=racd_codpro " +
            '                   "AND drec_rutcli='" + Rut_Cliente + "' AND mae_codi='" + Cmbo_Producto.SelectedValue.ToString() + "' AND racd_estado<>'2'"

            Dim sql As String = "select a.racd_codi,b.drec_sopocli,c.mae_descr,a.racd_unidades,a.racd_peso,a.racd_ca,a.racd_ba,a.racd_co,a.racd_pi,a.racd_ni from rackdeta a with(nolock) inner join detarece b with(nolock) on(a.racd_codi=b.drec_codi) inner join maeprod c with(nolock) on(a.racd_codpro=c.mae_codi) inner join fichrece d with(nolock) on(b.frec_codi1=d.frec_codi) where b.drec_rutcli='" + Rut_Cliente + "' and a.racd_estado<>'2' and a.est_tunel='0' and d.frec_serv='' and mae_codi='" + Cmbo_Producto.SelectedValue.ToString() + "'"

            Data_Productos.DataSource = fnc.ListarTablasSQL(sql)
        End If


    End Sub

    Private Sub Txt_Soportante_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Soportante.KeyPress

        If e.KeyChar = ChrW(13) Then
            'Dim sql As String = "SELECT racd_codi,  drec_sopocli , mae_descr, racd_unidades, racd_peso, racd_ca, racd_ba, racd_co, racd_pi, racd_ni " +
            '       "FROM rackdeta, maeprod, detarece WHERE racd_codi=drec_codi AND mae_codi=racd_codpro AND racd_estado<>'2' " +
            '       "AND drec_rutcli='" + Rut_Cliente + "' " +
            '       "AND (racd_codi LIKE'%" + Txt_Soportante.Text + "%' OR drec_sopocli LIKE'%" + Txt_Soportante.Text + "%')"

            Dim sql As String = "select a.racd_codi,b.drec_sopocli,c.mae_descr,a.racd_unidades,a.racd_peso,a.racd_ca,a.racd_ba,a.racd_co,a.racd_pi,a.racd_ni from rackdeta a with(nolock) inner join detarece b with(nolock) on(a.racd_codi=b.drec_codi) inner join maeprod c with(nolock) on(a.racd_codpro=c.mae_codi) inner join fichrece d with(nolock) on(b.frec_codi1=d.frec_codi) where b.drec_rutcli='" + Rut_Cliente + "' and a.racd_estado<>'2' and a.est_tunel='0' and d.frec_serv='' and (a.racd_codi LIKE'%" + Txt_Soportante.Text + "%' OR b.drec_sopocli LIKE'%" + Txt_Soportante.Text + "%')"

            Data_Productos.DataSource = fnc.ListarTablasSQL(sql)
        End If

    End Sub

    Private Sub Btn_Todos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim sql As String = "SELECT racd_codi,  drec_sopocli , mae_descr, racd_unidades, racd_peso, racd_ca, racd_ba, racd_co, racd_pi, racd_ni " +
        '                   "FROM rackdeta, maeprod, detarece WHERE  racd_estado<>'2' AND racd_codi=drec_codi AND mae_codi=racd_codpro AND drec_rutcli='" + Rut_Cliente + "'"

        Dim sql As String = "select a.racd_codi,b.drec_sopocli,c.mae_descr,a.racd_unidades,a.racd_peso,a.racd_ca,a.racd_ba,a.racd_co,a.racd_pi,a.racd_ni from rackdeta a with(nolock) inner join detarece b with(nolock) on(a.racd_codi=b.drec_codi) inner join maeprod c with(nolock) on(a.racd_codpro=c.mae_codi) inner join fichrece d with(nolock) on(b.frec_codi1=d.frec_codi) where b.drec_rutcli='" + Rut_Cliente + "' and a.racd_estado<>'2' and a.est_tunel='0' and d.frec_serv=''"

        Data_Productos.DataSource = fnc.ListarTablasSQL(sql)
    End Sub

    Public Sub Cambia_Pallet_pedido(ByVal Pallet_Nuevo As String, ByVal Pallet_antiguo As String, ByVal cajas As String, ByVal kilos As String, ByVal posicion As String)
        Dim sqlselecciona As String = "SELECT linea, pedido FROM pedidos_detalle WHERE pallet='" + Pallet_antiguo + "'"
        Dim tabla As DataTable = fnc.ListarTablasSQL(sqlselecciona)

        If tabla.Rows.Count > 0 Then
            Dim sql As String = "DELETE FROM pedidos_detalle WHERE pallet='" + Pallet_antiguo + "'"

            Dim sql2 As String = "INSERT INTO pedidos_detalle(pedido, linea, pallet, cajas, kilos, posicion, est) " +
                "VALUES('" + tabla.Rows(0)(1).ToString() + "','" + tabla.Rows(0)(0).ToString() + "', '" + Pallet_Nuevo.ToString() + "'," +
                "'" + cajas + "','" + kilos.Replace(",", ".") + "','" + posicion + "','0')"
            If fnc.MovimientoSQL(sql) > 0 Then
                'Dim sqlBorrarDetPalLoc = "SP_Pedidos_Locales_Eliminar_Pallet '" & Orden & "','" & Pallet_antiguo & "'"
                'Dim sqlBorrarDetPalLoc = "SP_Pedidos_Locales_Eliminar_Pallet '" & Orden & "','" & Pallet_antiguo & "'"
                'fnc.MovimientoSQL(sqlBorrarDetPalLoc)

                Console.WriteLine("OK")
            End If
            If fnc.MovimientoSQL(sql2) Then
                Console.WriteLine("OK")
            End If

            Dim sql3 As String = "update a set a.Pallet='" & Pallet_Nuevo.ToString.Trim & "',a.linea='" & tabla.Rows(0)(0).ToString() & "',a.Cajas_Marcadas='0',a.Estado='P' from Pedidos_Local a inner join Pedidos_ficha on(a.Orden=b.Orden) where b.Pedido='" & tabla.Rows(0)(1).ToString() & "' and a.Pallet='" & Pallet_antiguo & "'"
            If fnc.MovimientoSQL(sql3) Then
                Console.WriteLine("OK")
            End If
        End If
    End Sub

    Private Sub Cmbo_Producto_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Cmbo_Producto.KeyPress
        e.Handled = True
    End Sub

    Private Sub Data_Productos_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Data_Productos.CellDoubleClick
        Dim sqlValidProd = "SP_Pedidos_Locales_Cambiar_Validar_Producto '',''"
        Dim dtRespProd As DataTable = fnc.ListarTablasSQL(sqlValidProd)
        If (dtRespProd.Rows.Count > 0) Then
            Dim Resp = dtRespProd.Rows(0).Item(0).ToString.Trim
            If (Resp = "0") Then
                MsgBox("Este Pallet corresponde a un Producto diferente.", MsgBoxStyle.Information, "Aviso")
            End If
        End If

        If MsgBox("Seguro de cambiar por este pallet", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbYes Then
            Dim sqlTipPed As String = "SP_Pedidos_Locales_Tipo_Pedido '" & Orden & "'"
            Dim dtTipPed As DataTable = fnc.ListarTablasSQL(sqlTipPed)

            Dim RespCambioLocal = -1

            If (dtTipPed.Rows.Count > 0) Then
                Dim TipPed = dtTipPed.Rows(0).Item(0).ToString.Trim
                If (TipPed = "L") Then
                    Dim sqlselecciona As String = "SELECT linea, pedido FROM pedidos_detalle WHERE pallet='" + CerosAnteriorString(Numero_Pallet.ToString(), 9) + "'"
                    Dim tabla As DataTable = fnc.ListarTablasSQL(sqlselecciona)

                    Dim f As New FRM_ProductosClienteLocal
                    f.Cliente = Rut_Cliente
                    f.Orden = Orden
                    f.Linea = tabla.Rows(0)(0).ToString()
                    f.SopoAnt = CerosAnteriorString(Numero_Pallet.ToString(), 9)
                    f.Sopo = Me.Data_Productos.Rows(e.RowIndex).Cells(0).Value.ToString()
                    f.Prod = Me.Data_Productos.Rows(e.RowIndex).Cells(2).Value.ToString()
                    f.Cajas = Me.Data_Productos.Rows(e.RowIndex).Cells(3).Value.ToString()

                    If (f.ShowDialog = Windows.Forms.DialogResult.OK) Then
                        RespCambioLocal = 2
                    End If
                Else
                    RespCambioLocal = 1
                End If
            End If

            If (RespCambioLocal <> -1) Then
                'Cambia el pallet por
                Dim sql As String = "UPDATE rackdeta SET racd_estado='0' WHERE racd_codi='" + CerosAnteriorString(Numero_Pallet.ToString(), 9) + "'"

                If fnc.MovimientoSQL(sql) > 0 Then
                    Dim sql2 As String = "UPDATE rackdeta SET racd_estado='2' WHERE racd_codi='" + Me.Data_Productos.Rows(e.RowIndex).Cells(0).Value.ToString() + "'"
                    If fnc.MovimientoSQL(sql2) > 0 Then
                        MsgBox("Pallet Cambiado del pedido", MsgBoxStyle.Information, "Aviso")

                        If (RespCambioLocal = 2) Then
                            Dim sqlCajsPed = "select sum(Cajas_Pedidas) from Pedidos_Local where Orden='" & Orden & "' and Pallet like '%" & Me.Data_Productos.Rows(e.RowIndex).Cells(0).Value.ToString() & "%'"
                            Dim dtCajsPed As DataTable = fnc.ListarTablasSQL(sqlCajsPed)

                            If (dtCajsPed.Rows.Count > 0) Then
                                Dim cantCajs = dtCajsPed.Rows(0).Item(0).ToString.Trim

                                Cambia_Pallet_pedido(Me.Data_Productos.Rows(e.RowIndex).Cells(0).Value.ToString(), CerosAnteriorString(Numero_Pallet.ToString(), 9) _
                                             , cantCajs, Me.Data_Productos.Rows(e.RowIndex).Cells(4).Value.ToString() _
                                             , Me.Data_Productos.Rows(e.RowIndex).Cells(5).Value.ToString() + "-" + Me.Data_Productos.Rows(e.RowIndex).Cells(6).Value.ToString() + "-" + _
                                             Me.Data_Productos.Rows(e.RowIndex).Cells(7).Value.ToString() + "-" + Me.Data_Productos.Rows(e.RowIndex).Cells(8).Value.ToString() + "-" + _
                                             Me.Data_Productos.Rows(e.RowIndex).Cells(9).Value.ToString())
                            End If
                        Else
                            Cambia_Pallet_pedido(Me.Data_Productos.Rows(e.RowIndex).Cells(0).Value.ToString(), CerosAnteriorString(Numero_Pallet.ToString(), 9) _
                                             , Me.Data_Productos.Rows(e.RowIndex).Cells(3).Value.ToString(), Me.Data_Productos.Rows(e.RowIndex).Cells(4).Value.ToString() _
                                             , Me.Data_Productos.Rows(e.RowIndex).Cells(5).Value.ToString() + "-" + Me.Data_Productos.Rows(e.RowIndex).Cells(6).Value.ToString() + "-" + _
                                             Me.Data_Productos.Rows(e.RowIndex).Cells(7).Value.ToString() + "-" + Me.Data_Productos.Rows(e.RowIndex).Cells(8).Value.ToString() + "-" + _
                                             Me.Data_Productos.Rows(e.RowIndex).Cells(9).Value.ToString())
                        End If

                        Me.Close()
                    End If
                End If
            Else
                MsgBox("No se ha registrado detalle de Locales del Soportante a cambiar.", MsgBoxStyle.Information, "Info")
            End If
        End If
    End Sub

End Class
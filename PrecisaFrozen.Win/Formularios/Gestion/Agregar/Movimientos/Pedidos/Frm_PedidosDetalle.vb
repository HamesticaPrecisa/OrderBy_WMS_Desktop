Imports System.IO

Public Class Frm_PedidosDetalle

    Public CODIGO_PEDIDO As String
    Public CODIGO_CHICO As String
    Public cliente As String

    Dim fila = -1

    Dim fnc As New Funciones


    Private Sub Frm_PedidosDetalle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F1 Then
            Me.Close()
        End If
    End Sub

    Private Sub Frm_PedidosDetalle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ActualizaDetalle()

        'Sumar()

        txtcodorden.Text = CODIGO_CHICO
        txtnsolicitud.Text = CODIGO_PEDIDO

        Dim _sql As String = "SELECT  destino, fecha, observacion, cli_nomb, hora FROM Pedidos_ficha INNER JOIN clientes ON cli_rut=cliente WHERE Orden='" + CODIGO_CHICO + "'"
        Dim dt As DataTable = fnc.ListarTablasSQL(_sql)

        If dt.Rows.Count > 0 Then
            txtdestino.Text = dt.Rows(0)(0).ToString()
            'dtfecha.Value = Convert.ToDateTime(dt.Rows(0)(1).ToString())
            dtfecha.Value = DateTime.ParseExact(dt.Rows(0)(1).ToString(), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture)
            txtobs.Text = dt.Rows(0)(2).ToString()
            txtcliente.Text = dt.Rows(0)(3).ToString()
            txtHra.Text = dt.Rows(0)(4).ToString()
        End If

    End Sub

    Sub Sumar()
        If DgvDetalle.Rows.Count > 0 Then
            Dim suma_cajas As Integer = 0
            Dim suma_kilos As Double = 0.0

            For i As Integer = 0 To DgvDetalle.Rows.Count - 1
                suma_cajas = suma_cajas + Convert.ToInt32(DgvDetalle.Rows(i).Cells(6).Value.ToString())
                suma_kilos = suma_kilos + Convert.ToDouble(DgvDetalle.Rows(i).Cells(7).Value.ToString())
            Next

            txtsopo.Text = DgvDetalle.Rows.Count
            txtcajas.Text = suma_cajas.ToString()
            txtkilos.Text = suma_kilos.ToString()

        End If
    End Sub

    Private Sub DgvDetalle_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvDetalle.CellDoubleClick
        If e.RowIndex = -1 Then
            Return
        End If

        Dim info As String = "SELECT distinct dpc_codcaja, isnull(scaj_codcaja,0) op FROM detapedcaja LEFT JOIN TMP_SELECCIONCAJAS ON scaj_codcaja=dpc_codcaja WHERE dpc_codped='" + CODIGO_CHICO + "' AND dpc_numpal='" + DgvDetalle.Rows(e.RowIndex).Cells(3).Value.ToString() + "'"
        Dim dt As DataTable = fnc.ListarTablasSQL(info)

        If dt.Rows.Count = 0 Then
            MsgBox("El soportante no tiene detalle de cajas", MsgBoxStyle.Critical, "Aviso")
        Else
            Dim _modificar As Boolean = True

            If RealizarAccion("022", "095", False) = False Then
                _modificar = False
            End If

            Dim f = New Frm_PedidosDetalleCajas()
            f.qry = info
            f.codped = CODIGO_CHICO
            f.val_cliente = cliente
            f.codped = CODIGO_CHICO
            f._modificar = _modificar
            f.val_pallet = DgvDetalle.Rows(e.RowIndex).Cells("Folio_precisa").Value.ToString()
            f.ShowDialog()

            ActualizaDetalle()
            'Sumar()

        End If

    End Sub


    Public Sub ActualizaDetalle()

        'Dim sql As String = "SELECT pallet, drec_sopocli, mae_descr, cajas, kilos, racd_ca, racd_ba, racd_co, racd_pi, racd_ni, isnull(cant,0) cant " +
        '                    "FROM Pedidos_ficha pf INNER JOIN Pedidos_detalle pd ON pf.pedido=pd.pedido INNER JOIN rackdeta ON pallet = racd_codi " +
        '                    "INNER JOIN detarece ON drec_codi=racd_codi INNER JOIN maeprod ON mae_codi=racd_codpro LEFT JOIN GvwSeleccionCajas ON numpal=pallet AND npedido=orden  " +
        '                    "WHERE  Orden= '" + CODIGO_CHICO.ToString() + "' "

        'Me.DgvDetalle.DataSource = fnc.ListarTablasSQL(sql)

        Dim sql As String = "select a.pallet,c.drec_sopocli,d.mae_descr,cajas=sum(isnull(a.cajas,0)),kilos=round(sum(isnull(a.kilos,0)),2),racd_ca=case when e.racd_ca is not null then e.racd_ca else '00' end,racd_ba=case when e.racd_ba is not null then e.racd_ba else '00' end,racd_co=case when e.racd_co is not null then e.racd_co else '00' end,racd_pi=case when e.racd_pi is not null then e.racd_pi else '00' end,racd_ni=case when e.racd_ni is not null then e.racd_ni else '00' end,cant=isnull(f.cant,0) from Pedidos_detalle a with(nolock) inner join Pedidos_ficha b with(nolock) on(a.pedido=b.pedido) inner join detarece c with(nolock) on(a.pallet=c.drec_codi) inner join maeprod d with(nolock) on(c.drec_codpro=d.mae_codi) left outer join rackdeta e with(nolock) on(a.pallet=e.racd_codi) left outer join GvwSeleccionCajas f with(nolock) on(a.pallet=f.numpal) where b.Orden='" + CODIGO_CHICO.ToString.Trim + "' group by a.pallet,c.drec_sopocli,d.mae_descr,e.racd_ca,e.racd_ba,e.racd_co,e.racd_pi,e.racd_ni,f.cant"
        Dim dtResp As DataTable = fnc.ListarTablasSQL(sql)

        If (dtResp.Rows.Count > 0) Then
            Dim CantPals As Integer = dtResp.Rows.Count
            Dim CantCajs As Integer = 0
            Dim CantKgs As Double = 0

            For i = 0 To dtResp.Rows.Count - 1
                CantCajs += CInt(dtResp.Rows(i).Item(3).ToString.Trim)
                CantKgs += CDbl(dtResp.Rows(i).Item(4).ToString.Trim)
            Next

            txtsopo.Text = CantPals
            txtcajas.Text = CantCajs
            txtkilos.Text = CantKgs

            Me.DgvDetalle.DataSource = fnc.ListarTablasSQL(sql)
        End If

    End Sub

    Private Sub DgvDetalle_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvDetalle.CellClick

        If e.ColumnIndex = -1 Then
            Return
        End If

        If e.RowIndex > -1 Then

            If e.ColumnIndex = 1 Then

                'CAMBIO DE PALLET 

                If RealizarAccion("022", "066", False) = False Then
                    Exit Sub
                End If


                If DgvDetalle.Rows(e.RowIndex).Cells(13).Value.ToString() = "0" Then
                    Dim info As String = "SELECT dpc_codcaja, isnull(scaj_codcaja,0) op FROM detapedcaja LEFT JOIN TMP_SELECCIONCAJAS ON scaj_codcaja=dpc_codcaja WHERE dpc_codped='" + CODIGO_CHICO + "' AND dpc_numpal='" + DgvDetalle.Rows(e.RowIndex).Cells(3).Value.ToString() + "'"
                    Dim dt As DataTable = fnc.ListarTablasSQL(info)

                    If dt.Rows.Count > 0 Then

                        Dim Frm As New Frm_CambiarPallet
                        Frm.txtacambiar.Text = DgvDetalle.Rows(e.RowIndex).Cells(3).Value.ToString()
                        Frm.txtpedido.Text = CODIGO_CHICO
                        Frm.cajas = DgvDetalle.Rows(e.RowIndex).Cells(6).Value.ToString()
                        Frm.rutcliente = cliente.ToString()
                        Frm.ShowDialog()

                        ActualizaDetalle()
                        'Sumar()

                        Return
                    End If

                ElseIf Convert.ToInt32(DgvDetalle.Rows(e.RowIndex).Cells(13).Value) > "0" AndAlso DgvDetalle.Rows(e.RowIndex).Cells(13).Value.ToString() <> DgvDetalle.Rows(e.RowIndex).Cells(6).Value.ToString() Then
                    MsgBox("El soportante no se puede cambiar, ya comenzó la selección de cajas", MsgBoxStyle.Critical, "Aviso")
                    Return
                Else
                    MsgBox("El soportante no se puede cambiar, ya finalizo la selección de cajas", MsgBoxStyle.Critical, "Aviso")
                    Return
                End If

                If DgvDetalle.Rows(e.RowIndex).Cells(8).Value.ToString() = "91" Or DgvDetalle.Rows(e.RowIndex).Cells(8).Value.ToString() = "92" Or DgvDetalle.Rows(e.RowIndex).Cells(8).Value.ToString() = "93" Then
                    MsgBox("No puede cambiar el pallet, ya se encuentra en la cámara pulmón", MsgBoxStyle.Information, "Aviso")
                    fila = -1
                Else
                    If MsgBox("Seguro de cambiar el pallet " + DgvDetalle.Rows(e.RowIndex).Cells(3).Value.ToString() + "", _
                               MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbYes Then

                        Dim Frm As New Frm_ProductosCliente
                        Frm.Numero_Pallet = DgvDetalle.Rows(e.RowIndex).Cells(3).Value.ToString()
                        Frm.Rut_Cliente = cliente.ToString()
                        Frm.Orden = txtcodorden.Text.Trim
                        Frm.ShowDialog()

                        ActualizaDetalle()
                        'Sumar()
                    End If
                End If
            ElseIf e.ColumnIndex = 2 Then
                If RealizarAccion("022", "067", True) = False Then
                    Exit Sub
                End If

                'If Convert.ToInt32(DgvDetalle.Rows(e.RowIndex).Cells(13).Value) > "0" AndAlso DgvDetalle.Rows(e.RowIndex).Cells(13).Value.ToString() <> DgvDetalle.Rows(e.RowIndex).Cells(6).Value.ToString() Then
                '    MsgBox("El soportante no se puede eliminar, ya comenzó la selección de cajas", MsgBoxStyle.Critical, "Aviso")
                '    Return
                'Else
                '    MsgBox("El soportante no se puede eliminar, ya finalizo la selección de cajas", MsgBoxStyle.Critical, "Aviso")
                '    Return
                'End If


                If MsgBox("Seguro de eliminar el soportante seleccionado del pedido", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Aviso") = vbYes Then

                    Dim _pallet As String = DgvDetalle.Rows(e.RowIndex).Cells(3).Value.ToString()

                    'Consultar si el pallet comenzo la seleccion de cajas

                    Dim _consulta As String = "SELECT  COUNT(scaj_codcaja) FROM detapedcaja LEFT JOIN TMP_SELECCIONCAJAS ON dpc_codcaja=scaj_codcaja WHERE dpc_numpal='" + _pallet + "' AND dpc_codped='" + CODIGO_CHICO + "'"
                    Dim _dtb As DataTable = fnc.ListarTablasSQL(_consulta)

                    If _dtb.Rows.Count > 0 Then

                        If Convert.ToInt32(_dtb.Rows(0)(0).ToString()) > 0 Then
                            MsgBox("El soportante ya comenzó la seleccion de cajas, no se puede eliminar", MsgBoxStyle.Critical, "Aviso")
                            Exit Sub
                        End If

                        'Eliminar 
                        Dim sql_deta As String = "DELETE FROM pedidos_detalle WHERE pedido='" + CODIGO_PEDIDO + "' AND pallet='" + _pallet + "'"
                        fnc.MovimientoSQL(sql_deta)

                        Dim sql_pedc As String = "DELETE FROM pedcaja WHERE pc_codped='" + CODIGO_CHICO + "' AND pc_numpal='" + _pallet + "'"
                        fnc.MovimientoSQL(sql_pedc)

                        Dim sql_detarece As String = "UPDATE DetaReceCajas SET caj_ped ='0' FROM DetaReceCajas INNER JOIN detapedcaja ON dpc_codcaja = Caj_cod and dpc_numpal = caj_Pcod WHERE dpc_codped='" + CODIGO_PEDIDO + "'"
                        fnc.MovimientoSQL(sql_detarece)

                        Dim sql_dpedc As String = "DELETE FROM detapedcaja WHERE dpc_codped='" + CODIGO_CHICO + "' AND dpc_numpal='" + _pallet + "'"
                        fnc.MovimientoSQL(sql_dpedc)

                        Dim sql As String = "UPDATE rackdeta SET racd_estado='0' WHERE racd_codi='" + _pallet + "'"
                        fnc.MovimientoSQL(sql)

                        Dim sqlPedLoc As String = "delete from Pedidos_Local where Orden='" + CODIGO_CHICO + "' and Pallet='" + _pallet + "'"
                        fnc.MovimientoSQL(sqlPedLoc)

                        Dim sqlPedLocCaj As String = "delete from Pedidos_Locales_Trackeo_Cajas where Orden='" & CODIGO_CHICO & "' and Pallet='" & _pallet & "'"
                        fnc.MovimientoSQL(sqlPedLocCaj)

                        MsgBox("Soportante eliminado correctamente", MsgBoxStyle.Information, "Aviso")

                        ActualizaDetalle()
                        'Sumar()
                    Else
                        MsgBox("No puede realizar esta acción", MsgBoxStyle.Critical, "Aviso")
                    End If
                End If
            End If

        End If
    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If RealizarAccion("022", "095", True) = False Then
            Return
        End If

        Dim Hora As String = txtHra.Text.Trim
        Dim HoraFrm As DateTime
        If (Not DateTime.TryParse(Hora, HoraFrm)) Then
            MsgBox("La hora ingresada no es válida.", MsgBoxStyle.Critical, "Aviso")
            txtHra.Text = ""
            txtHra.Focus()
            Exit Sub
        End If

        '
        '   VES FEB 2020
        '   SE INCLUYO LA LISTA DE COLUMNAS EXPLICITAMENTE PARA
        '   EVITAR ERRORES POR DESINCRONIZACION ENTRE LA TABLA
        '   LOG Y LA ORIGINAL
        '
        Dim sqlLogUpd As String = "insert into Pedidos_Ficha_Log_Modificaciones " & _
                                  "  ([Orden],[pedido],[cliente],[transporte],[fecha],[hora],[destino],[observacion],[mail],[codvig],[terminado],[Encargado],[fechapedido],[fechaTermino],[ped_estpred],[ped_revision],[packinglist],[ordenconjunta],[cod_bod],[ped_enviado],[ped_carga],[ped_host],[destino_rut],[destino_dir],[fecha_modificacion],[usuario_modificacion])" & _
                                  " select [Orden],[pedido],[cliente],[transporte],[fecha],[hora],[destino],[observacion],[mail],[codvig],[terminado],[Encargado],[fechapedido],[fechaTermino],[ped_estpred],[ped_revision],[packinglist],[ordenconjunta],[cod_bod],[ped_enviado],[ped_carga],[ped_host],[destino_rut],[destino_dir],GETDATE(),'" & Frm_Principal.InfoUsuario.Text & "'" & _
                                  "   from pedidos_ficha " & _
                                  "  where orden = '" & txtcodorden.Text.Trim() & "'"
        If fnc.MovimientoSQL(sqlLogUpd) <= 0 Then
            MsgBox("Error al actualizar la información: " + lastSqlError, MsgBoxStyle.Critical, "Aviso")
            Exit Sub
        End If

        Dim _update As String = "UPDATE pedidos_ficha SET destino='" + txtdestino.Text + "', fecha='" + devuelve_fecha_Formato2(dtfecha.Value) + "', observacion='" + txtobs.Text + "', hora='" & Hora & "' WHERE orden='" + txtcodorden.Text + "'  "

        If fnc.MovimientoSQL(_update) > 0 Then
            MsgBox("Información actualizada correctamente", MsgBoxStyle.Information, "Aviso")
        Else
            MsgBox("Error al actualizar la información", MsgBoxStyle.Critical, "Aviso")
        End If

    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub DgvDetalle_ColumnAdded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewColumnEventArgs) Handles DgvDetalle.ColumnAdded
        e.Column.SortMode = DataGridViewColumnSortMode.NotSortable
    End Sub

    Private Sub DgvDetalle_DataBindingComplete(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles DgvDetalle.DataBindingComplete

        For Each fila As DataGridViewRow In DgvDetalle.Rows
            Dim s As String = fila.Cells(7).Value.ToString()

            If (fila.Cells(13).Value.ToString() = fila.Cells(6).Value.ToString()) Then
                fila.Cells(0).Value = ImageList1.Images(0)
            ElseIf (Convert.ToInt32(fila.Cells(13).Value.ToString()) > 0) Then
                fila.Cells(0).Value = ImageList1.Images(2)
            Else
                fila.Cells(0).Value = ImageList1.Images(1)
            End If

        Next

    End Sub

    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click

        Dim sql As String = "SELECT * FROM fichpred WHERE fpre_nped='" + txtcodorden.Text + "'"
        Dim dt As DataTable = fnc.ListarTablasSQL(sql)

        If dt.Rows.Count = 0 Then

            Dim frm As New frm_PedidosPalletAdd
            'frm.modo = "AGREGAR"
            frm.txtpedido.Text = txtcodorden.Text
            frm.ShowDialog()

        Else
            MsgBox("El pedido seleccionado ya se encuentra despachado", MsgBoxStyle.Critical, "Aviso")
        End If

    End Sub

    
End Class
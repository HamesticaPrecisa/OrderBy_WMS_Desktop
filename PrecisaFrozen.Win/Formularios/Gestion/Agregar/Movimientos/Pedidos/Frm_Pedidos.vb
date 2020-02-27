Imports System.Data.SqlClient

Public Class Frm_Pedidos

    Dim fnc As New Funciones
    Dim con As New Conexion

    Private Sub Frm_Pedidos_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Timer1.Stop()
        f_pedidos = False
    End Sub

    Private Sub Frm_Pedidos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F1 Then
            Me.Close()
        End If
    End Sub

    Private Sub Frm_Pedidos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim tb As DataTable = New DataTable
        tb.Columns.Add("Cod")
        tb.Columns.Add("Descri")

        tb.Rows.Add("1", "Pendientes")
        tb.Rows.Add("2", "Ultimos terminados")
        tb.Rows.Add("3", "Ultimos registrados")

        cbtipo.DataSource = tb
        cbtipo.ValueMember = "Cod"
        cbtipo.DisplayMember = "Descri"

        Timer1.Interval = 120000
        Timer1.Start()
        'carga_pedidos()

        ordenarGrilla()
    End Sub

    Private Sub DgvPedidos_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvPedidos.CellClick

        If e.RowIndex > -1 AndAlso e.ColumnIndex = 0 Then
            Dim frm As New Frm_PedidosDetalle
            frm.CODIGO_PEDIDO = Me.DgvPedidos.Rows(e.RowIndex).Cells(4).Value.ToString()
            frm.CODIGO_CHICO = Me.DgvPedidos.Rows(e.RowIndex).Cells(5).Value.ToString()
            frm.cliente = Me.DgvPedidos.Rows(e.RowIndex).Cells(4).Value.ToString().Remove(0, 14)
            frm.ShowDialog()
        ElseIf e.RowIndex > -1 AndAlso e.ColumnIndex = 1 Then
            If RealizarAccion("022", "067", True) = False Then
                Exit Sub
            End If
       
            If MsgBox("Seguro de eliminar el pedido seleccionado", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbNo Then
                Exit Sub
            Else
                If cbtipo.SelectedIndex = 0 Then
                Else
                    MsgBox("Solo se puede eliminar pedidos pendientes", MsgBoxStyle.Critical, "Aviso")
                    Exit Sub

                End If

            End If

            Dim NPEDIDO As String = Me.DgvPedidos.Rows(e.RowIndex).Cells(5).Value.ToString()

            '
            '   VES FEB 2020
            '   DETERMINAMOS LA CANTIDAD DE PALLETS ASOCIADOS AL PEDIDO
            '
            Dim Pallets As Integer = CInt(Me.DgvPedidos.Rows(e.RowIndex).Cells(10).Value.ToString().Split("/")(1).Trim())


            Try
                con.conectar()

                Dim _cmd As SqlCommand = New SqlCommand("PAG_EliminaPedido", con.con)
                _cmd.CommandType = CommandType.StoredProcedure
                _cmd.CommandTimeout = 0


                _cmd.Parameters.AddWithValue("@codped", NPEDIDO)

                Dim resp As Integer = 0
                Try
                    resp = Convert.ToInt32(_cmd.ExecuteScalar())
                Catch ex As Exception
                    resp = 1
                End Try

                If resp = 0 Then
                    MsgBox("Pedido Eliminado Correctamente", MsgBoxStyle.Information, "Aviso")
                ElseIf resp < 4 Then
                    MsgBox("Error esperado al grabar la información" + resp.ToString(), MsgBoxStyle.Critical, "Aviso")
                Else
                    MsgBox("Error inesperado al grabar la información" + resp.ToString(), MsgBoxStyle.Critical, "Aviso")
                End If

                con.cerrar()

                '
                '  VES FEB 2020
                '  SE GRABA LA CANTIDAD DE PALLETS ASOCIADOS AL PEDIDO ELIMINADO. ESTO ES NECESARIO PORQUE
                '  UNA VEZ ELIMINADO EL PEDIDO, YA NO HAY FORMA DE SABER CUANTOS PALLETS TENIA
                '
                fnc.MovimientoSQL("INSERT INTO LOG_PEDIDOSELIMINADOS (LEM_CODI, LEM_FECHA, LEM_HORA, LEM_USU, LEM_PC, LEM_TIPO, LEM_SOP)" +
                                  "VALUES('" + NPEDIDO + "','" + devuelve_fecha_Formato2(fnc.DevuelveFechaServidor()) + "','" + DevuelveHora() + "'," +
                                  "'" + Frm_Principal.InfoUsuario.Text + "','" + My.Computer.Name.ToString() + "','SI'," + Pallets.ToString() + ")")
                fnc.MovimientoSQL("DELETE FROM Pedido_Est WHERE pedido ='" + Me.DgvPedidos.Rows(e.RowIndex).Cells(5).Value.ToString() + "'")
                Dim sqll As String = ("DELETE FROM Pedido_Est WHERE pedido ='" + Me.DgvPedidos.Rows(e.RowIndex).Cells(5).Value.ToString() + "'")
                MsgBox("Pedido anulado correctamente", MsgBoxStyle.Information, "Aviso")
                cargarDatos()
            Catch ex As Exception
                MsgBox(ex.Message())
            End Try

        ElseIf e.RowIndex > -1 AndAlso e.ColumnIndex = 2 Then
            documentoimp = "Reporte_Pedido_" & Me.DgvPedidos.Rows(e.RowIndex).Cells(5).Value.ToString()

            Dim frm As Frm_MuestraReporte = New Frm_MuestraReporte
            frm.Text = "Asistente de informes - Informe de pedidos"

            Dim report As New Rpt_Pedidos

            report.SetDatabaseLogon(Usuario_ODBC, Pass_ODBC)
            report.SetParameterValue("codigo", Me.DgvPedidos.Rows(e.RowIndex).Cells(5).Value.ToString())

            frm.Contenedor.ReportSource = report
            frm.ShowDialog()

        ElseIf e.RowIndex > -1 AndAlso e.ColumnIndex = 3 Then

            Dim dt As DataTable = fnc.ListarTablasSQL("SELECT * FROM detapedcaja WHERE dpc_codped='" + Me.DgvPedidos.Rows(e.RowIndex).Cells(5).Value.ToString() + "'")
            If (dt.Rows.Count > 0) Then

                documentoimp = "Reporte_Pedido_Saldos_" & Me.DgvPedidos.Rows(e.RowIndex).Cells(5).Value.ToString()

                Dim frm As Frm_MuestraReporte = New Frm_MuestraReporte
                frm.Text = "Asistente de informes - Informe de Saldos"

                Dim report As New Rpt_PedidosSaldos

                report.SetDatabaseLogon(Usuario_ODBC, Pass_ODBC)
                report.SetParameterValue("codigo", Me.DgvPedidos.Rows(e.RowIndex).Cells(5).Value.ToString())

                frm.Contenedor.ReportSource = report
                frm.ShowDialog()

            Else
                MsgBox("El pedido seleccionado no tiene saldo disponible", MsgBoxStyle.Critical, "Aviso")
            End If
        End If
    End Sub

    'Sub carga_pedidos()

    '    Dim sql As String = "SELECT  pedido, Orden, cliente+ '  '+ cli_nomb AS cliente, fecha, hora, destino, destino AS sopo, codvig " +
    '                        "FROM pedidos_ficha, clientes " +
    '                        "WHERE cli_rut=cliente AND terminado<>'3' AND codvig='0' ORDER BY orden DESC"
    '    ' 
    '    Dim Data As DataTable = fnc.ListarTablasSQL(sql)

    '    For i As Integer = 0 To Data.Rows.Count - 1

    '        Dim sqlTotal As String = "SELECT COUNT(*) FROM pedidos_detalle WHERE pedido='" + Data.Rows(i)(0).ToString() + "'"
    '        Dim tablatotal As DataTable = fnc.ListarTablasSQL(sqlTotal)

    '        Dim sqlTotal2 As String = "SELECT COUNT(*) FROM pedidos_detalle WHERE pedido='" + Data.Rows(i)(0).ToString() + "' AND est='1'"
    '        Dim tablatotal2 As DataTable = fnc.ListarTablasSQL(sqlTotal2)

    '        If tablatotal.Rows.Count > 0 AndAlso tablatotal2.Rows.Count > 0 Then
    '            Dim todos As String = tablatotal.Rows(0)(0).ToString()
    '            Dim de As String = tablatotal2.Rows(0)(0).ToString()
    '            Data.Rows(i)(6) = (de + " / " + todos).ToString()
    '        End If
    '    Next

    '    DgvPedidos.DataSource = Data

    '    For i = 0 To DgvPedidos.Rows.Count - 1
    '        If Convert.ToInt16(DgvPedidos.Rows(i).Cells(10).Value.ToString()) = 1 Then
    '            DgvPedidos.Rows(i).DefaultCellStyle.ForeColor = Color.Red
    '        End If
    '    Next
    'End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If cbtipo.SelectedValue.ToString() = "1" Then
            'Modificacion HAmestica 071218. Actualizacion Pedidos Locales

            'Dim sql As String = "SELECT  pedido, Orden, cliente+ '  '+ cli_nomb AS cliente, fecha, hora, destino, destino AS sopo, codvig " +
            '               "FROM pedidos_ficha, clientes " +
            '               "WHERE cli_rut=cliente AND terminado <>'3' AND Ped_estpred<>'3' AND codvig='0' AND Orden not in(SELECT fpre_nped FROM fichpred)  ORDER BY orden DESC"
            ''AND Dateadd(day,2,Convert(date,fecha,103))>Convert(date,GETDATE(),103)

            'Dim sql As String = "select a.pedido,a.Orden,a.cliente+' '+b.cli_nomb AS cliente,a.fecha,a.hora,destino=isnull(a.destino,''),sopo=isnull(a.destino,''),a.codvig,'' AS Cajas,Tipo=case when c.Orden is null then 'NORMAL' else 'LOCAL' end from pedidos_ficha a with(nolock) inner join clientes b with(nolock) on(b.cli_rut=a.cliente) left outer join(select distinct Orden from Pedidos_Local with(nolock)) c on(a.Orden=c.Orden) where a.terminado <>'3' AND a.Ped_estpred<>'3' AND a.codvig='0' AND a.Orden not in(select fpre_nped from fichpred) order by a.orden desc"
            'Dim sql As String = "select distinct a.pedido,a.Orden,a.cliente+' '+b.cli_nomb AS cliente,a.fecha,a.hora,destino=isnull(a.destino,''),sopo=isnull(a.destino,''),a.codvig,'' AS Cajas,Tipo=case when c.Orden is null then 'NORMAL' else 'LOCAL' end,Tipo_Carga=isnull(a.ped_carga,''),Tipo_Exportacion=isnull(e.Tipo,'Nacional'),Nro_Sol_Sag=isnull(d.Nro_Sol_SAG,''),Etiquetado_Adicional=case when isnull(d.Etiquetado_Adicional,0)=0 then 'No' else 'Si' end from pedidos_ficha a with(nolock) inner join clientes b with(nolock) on(b.cli_rut=a.cliente) left outer join(select distinct Orden from Pedidos_Local with(nolock)) c on(a.Orden=c.Orden) left outer join Pedidos_Tipo_Exportacion_Creados d with(nolock) on(a.Orden=d.Orden_Pedido) left outer join Pedidos_Tipo_Exportacion e with(nolock) on(d.ID_Tipo_Exportacion=e.ID) where a.terminado <>'3' AND a.Ped_estpred<>'3' AND a.codvig='0' AND a.Orden not in(select fpre_nped from fichpred) order by a.orden desc"
            'Dim sql As String = "select distinct a.pedido,a.Orden,a.cliente+' '+b.cli_nomb AS cliente,a.fecha,a.hora,destino=isnull(a.destino,''),sopo=isnull(a.destino,''),a.codvig,'' AS Cajas,Tipo=case when c.Orden is null then 'NORMAL' else 'LOCAL' end,Tipo_Carga=isnull(a.ped_carga,''),Tipo_Exportacion=isnull(e.Tipo,'Nacional'),Nro_Sol_Sag=isnull(d.Nro_Sol_SAG,''),Etiquetado_Adicional=case when isnull(d.Etiquetado_Adicional,0)=0 then 'No' else 'Si' end,Fecha_Frm=convert(date,a.fecha) from pedidos_ficha a with(nolock) inner join clientes b with(nolock) on(b.cli_rut=a.cliente) left outer join(select distinct Orden from Pedidos_Local with(nolock)) c on(a.Orden=c.Orden) left outer join Pedidos_Tipo_Exportacion_Creados d with(nolock) on(a.Orden=d.Orden_Pedido) left outer join Pedidos_Tipo_Exportacion e with(nolock) on(d.ID_Tipo_Exportacion=e.ID) where a.terminado <>'3' AND a.Ped_estpred<>'3' AND a.codvig='0' AND a.Orden not in(select fpre_nped from fichpred) order by convert(date,a.fecha),a.hora asc"
            Dim sql As String = "WITH data AS (" & _
                                "SELECT DISTINCT a.pedido,a.Orden,b.cli_nomb AS cliente,a.fecha,a.hora,destino=isnull(a.destino,'')," & _
                                "                sopo=isnull(a.destino,''),a.codvig,'' AS Cajas," & _
                                "                Tipo=case when c.Orden is null then 'NORMAL' else 'LOCAL' end,Tipo_Carga=isnull(a.ped_carga,'')," & _
                                "                Tipo_Exportacion=isnull(e.Tipo,'Nacional'),Nro_Sol_Sag=isnull(d.Nro_Sol_SAG,'')," & _
                                "                Etiquetado_Adicional=case when isnull(d.Etiquetado_Adicional,0)=0 then 'No' else 'Si' end," & _
                                "                Fecha_Frm=convert(date,a.fecha,103),Kilos=f.kilos " & _
                                "  FROM pedidos_ficha a with(nolock) " & _
                                " INNER JOIN clientes b with(nolock) on (b.cli_rut=a.cliente) " & _
                                "  LEFT OUTER JOIN (select distinct Orden from Pedidos_Local with(nolock)) c on(a.Orden=c.Orden) " & _
                                "  LEFT OUTER JOIN Pedidos_Tipo_Exportacion_Creados d with(nolock) on(a.Orden=d.Orden_Pedido) " & _
                                "  LEFT OUTER JOIN Pedidos_Tipo_Exportacion e with(nolock) on(d.ID_Tipo_Exportacion=e.ID) " & _
                                " INNER JOIN (select a.pedido,kilos=round(sum(a.kilos),0) from Pedidos_detalle a with(nolock) group by a.pedido) f on(a.pedido=f.pedido) " & _
                                " WHERE a.terminado <>'3' " & _
                                "   AND a.Ped_estpred<>'3' " & _
                                "   AND a.codvig='0' " & _
                                "   AND a.Orden not in(select fpre_nped from fichpred) " & _
                                ")" & _
                                "SELECT * FROM data ORDER BY convert(date,fecha),hora asc"

            Dim Data As DataTable = fnc.ListarTablasSQL(sql)

            For i As Integer = 0 To Data.Rows.Count - 1
                Dim sqlDetsPed As String = "select distinct a.pallet,Cajas=SUM(isnull(Cajas,0)),Cajas_Marcadas=case when a.est='0' then sum(isnull(b.Cajas_Marcadas,0)) else a.cajas end from pedidos_detalle a with(nolock) left outer join(select d.Pedido,c.Pallet,Cajas_Marcadas=sum(isnull(c.Cajas_Marcadas,0)) from Pedidos_Local c with(nolock) inner join Pedidos_Ficha d with(nolock) on(c.Orden=d.Orden) where d.pedido='" + Data.Rows(i)(0).ToString() + "' group by d.Pedido,c.Pallet) b on(a.pallet=b.Pallet) WHERE a.pedido='" + Data.Rows(i)(0).ToString() + "' group by a.pallet,a.est,a.cajas"
                'Dim sqlDetsPed As String = "select a.pallet,Cajas=SUM(isnull(Cajas,0)),Cajas_Marcadas=case when a.est='0' then sum(isnull(b.Cajas_Marcadas,0)) else a.cajas end from pedidos_detalle a with(nolock) left outer join(select d.Pedido,c.Pallet,Cajas_Marcadas=sum(isnull(c.Cajas_Marcadas,0)) from Pedidos_Local c with(nolock) inner join Pedidos_Ficha d with(nolock) on(c.Orden=d.Orden) where d.pedido='" + Data.Rows(i)(0).ToString() + "' group by d.Pedido,c.Pallet) b on(a.pallet=b.Pallet) WHERE a.pedido='" + Data.Rows(i)(0).ToString() + "' group by a.pallet,a.est,a.cajas"
                Dim dtDetsPed As DataTable = fnc.ListarTablasSQL(sqlDetsPed)

                Dim CantPalls As Integer = 0
                Dim CantPallsMarcs As Integer = 0
                Dim CantCajs As Integer = 0
                Dim CantCajsMarcs As Integer = 0

                If (dtDetsPed.Rows.Count > 0) Then
                    For j = 0 To dtDetsPed.Rows.Count - 1
                        CantPalls += 1
                        CantCajs += CInt(dtDetsPed.Rows(j).Item(1).ToString.Trim)
                        CantCajsMarcs += CInt(dtDetsPed.Rows(j).Item(2).ToString.Trim)

                        If (CInt(dtDetsPed.Rows(j).Item(1).ToString.Trim) = CInt(dtDetsPed.Rows(j).Item(2).ToString.Trim)) Then
                            CantPallsMarcs += 1
                        End If
                    Next
                End If

                Data.Rows(i)(6) = (CStr(CantPallsMarcs) & " / " & CStr(CantPalls)).ToString()
                Data.Rows(i)(8) = (CStr(CantCajsMarcs) & " / " & CStr(CantCajs)).ToString()

                'Dim sqlTotal As String = "SELECT COUNT(*) FROM pedidos_detalle WHERE pedido='" + Data.Rows(i)(0).ToString() + "'"
                'Dim tablatotal As DataTable = fnc.ListarTablasSQL(sqlTotal)

                'Dim sqlTotal2 As String = "SELECT COUNT(*) FROM pedidos_detalle WHERE pedido='" + Data.Rows(i)(0).ToString() + "' AND est='1'"
                'Dim tablatotal2 As DataTable = fnc.ListarTablasSQL(sqlTotal2)

                'If tablatotal.Rows.Count > 0 AndAlso tablatotal2.Rows.Count > 0 Then
                '    Dim todos As String = tablatotal.Rows(0)(0).ToString()
                '    Dim de As String = tablatotal2.Rows(0)(0).ToString()
                '    Data.Rows(i)(6) = (de + " / " + todos).ToString()
                'End If
            Next
            'Fin modificacion HAmestica 071218. Actualizacion Pedidos Locales

            DgvPedidos.DataSource = Data

            For i = 0 To DgvPedidos.Rows.Count - 1
                If Convert.ToInt16(DgvPedidos.Rows(i).Cells(11).Value.ToString()) = 1 Then
                    DgvPedidos.Rows(i).DefaultCellStyle.ForeColor = Color.Red
                End If
            Next

        ElseIf cbtipo.SelectedValue.ToString() = "2" Then
            'Modificacion HAmestica 071218. Actualizacion Pedidos Locales

            'Dim sql As String = "SELECT TOP(10) pedido, Orden, cliente+'  '+ cli_nomb AS cliente, fecha, hora, destino, destino AS sopo, codvig " +
            '                   "FROM pedidos_ficha, clientes " +
            '                   "WHERE cli_rut=cliente AND terminado<>'0' AND codvig='0' ORDER BY orden DESC"

            'Dim sql As String = "SELECT TOP(10) a.pedido,a.Orden,a.cliente+' '+b.cli_nomb AS cliente,a.fecha,a.hora,a.destino,a.destino AS sopo,a.codvig,'' AS Cajas,Tipo=case when c.Cajas_Marcadas is null then 'NORMAL' else 'LOCAL' end FROM pedidos_ficha a with(nolock) inner join clientes b with(nolock) on(b.cli_rut=a.cliente) left outer join(select d.Orden,c.Pallet,Cajas_Marcadas=sum(isnull(c.Cajas_Marcadas,0)) from Pedidos_Local c with(nolock) inner join Pedidos_Ficha d with(nolock) on(c.Orden=d.Orden) group by d.Orden,c.Pallet) c on(a.Orden=c.Orden) WHERE a.terminado <>'0' AND a.codvig='0' ORDER BY a.orden DESC"
            'Dim sql As String = "SELECT TOP(10) a.pedido,a.Orden,a.cliente+' '+b.cli_nomb AS cliente,a.fecha,a.hora,a.destino,a.destino AS sopo,a.codvig,'' AS Cajas, Tipo=case when c.Orden is null then 'NORMAL' else 'LOCAL' end FROM pedidos_ficha a with(nolock) inner join clientes b with(nolock) on(b.cli_rut=a.cliente) left outer join(select distinct Orden from Pedidos_Local with(nolock)) c on(a.Orden=c.Orden) WHERE a.terminado <>'0' AND a.codvig='0' ORDER BY a.orden DESC"
            'Dim sql As String = "SELECT DISTINCT TOP(10) a.pedido,a.Orden,a.cliente+' '+b.cli_nomb AS cliente,a.fecha,a.hora,a.destino,a.destino AS sopo,a.codvig,'' AS Cajas, Tipo=case when c.Orden is null then 'NORMAL' else 'LOCAL' end,Tipo_Carga=isnull(a.ped_carga,''),Tipo_Exportacion=isnull(e.Tipo,'Nacional'),Nro_Sol_Sag=isnull(d.Nro_Sol_SAG,''),Etiquetado_Adicional=case when isnull(d.Etiquetado_Adicional,0)=0 then 'No' else 'Si' end FROM pedidos_ficha a with(nolock) inner join clientes b with(nolock) on(b.cli_rut=a.cliente) left outer join(select distinct Orden from Pedidos_Local with(nolock)) c on(a.Orden=c.Orden) left outer join Pedidos_Tipo_Exportacion_Creados d with(nolock) on(a.Orden=d.Orden_Pedido) left outer join Pedidos_Tipo_Exportacion e with(nolock) on(d.ID_Tipo_Exportacion=e.ID) WHERE a.terminado <>'0' AND a.codvig='0' ORDER BY a.orden DESC"
            'Dim sql As String = "SELECT DISTINCT TOP(10) a.pedido,a.Orden,a.cliente+' '+b.cli_nomb AS cliente,a.fecha,a.hora,a.destino,a.destino AS sopo,a.codvig,'' AS Cajas, Tipo=case when c.Orden is null then 'NORMAL' else 'LOCAL' end,Tipo_Carga=isnull(a.ped_carga,''),Tipo_Exportacion=isnull(e.Tipo,'Nacional'),Nro_Sol_Sag=isnull(d.Nro_Sol_SAG,''),Etiquetado_Adicional=case when isnull(d.Etiquetado_Adicional,0)=0 then 'No' else 'Si' end,Fecha_Frm=convert(date,a.fecha) FROM pedidos_ficha a with(nolock) inner join clientes b with(nolock) on(b.cli_rut=a.cliente) left outer join(select distinct Orden from Pedidos_Local with(nolock)) c on(a.Orden=c.Orden) left outer join Pedidos_Tipo_Exportacion_Creados d with(nolock) on(a.Orden=d.Orden_Pedido) left outer join Pedidos_Tipo_Exportacion e with(nolock) on(d.ID_Tipo_Exportacion=e.ID) WHERE a.terminado <>'0' AND a.codvig='0' order by convert(date,a.fecha) desc,a.hora asc"
            Dim sql As String = "SELECT DISTINCT TOP(10) a.pedido,a.Orden,b.cli_nomb AS cliente,a.fecha,a.hora,a.destino,a.destino AS sopo,a.codvig,'' AS Cajas, Tipo=case when c.Orden is null then 'NORMAL' else 'LOCAL' end,Tipo_Carga=isnull(a.ped_carga,''),Tipo_Exportacion=isnull(e.Tipo,'Nacional'),Nro_Sol_Sag=isnull(d.Nro_Sol_SAG,''),Etiquetado_Adicional=case when isnull(d.Etiquetado_Adicional,0)=0 then 'No' else 'Si' end,Fecha_Frm=convert(date,a.fecha),Kilos=f.kilos FROM pedidos_ficha a with(nolock) inner join clientes b with(nolock) on(b.cli_rut=a.cliente) left outer join(select distinct Orden from Pedidos_Local with(nolock)) c on(a.Orden=c.Orden) left outer join Pedidos_Tipo_Exportacion_Creados d with(nolock) on(a.Orden=d.Orden_Pedido) left outer join Pedidos_Tipo_Exportacion e with(nolock) on(d.ID_Tipo_Exportacion=e.ID) inner join (select a.pedido,kilos=round(sum(a.kilos),0) from Pedidos_detalle a with(nolock) group by a.pedido) f on(a.pedido=f.pedido) WHERE a.terminado <>'0' AND a.codvig='0' order by convert(date,a.fecha) desc,a.hora asc"

            Dim Data As DataTable = fnc.ListarTablasSQL(sql)

            For i As Integer = 0 To Data.Rows.Count - 1
                Dim sqlDetsPed As String = "select distinct a.pallet,Cajas=SUM(isnull(Cajas,0)),Cajas_Marcadas=case when a.est='0' then sum(isnull(b.Cajas_Marcadas,0)) else a.cajas end from pedidos_detalle a with(nolock) left outer join(select d.Pedido,c.Pallet,Cajas_Marcadas=sum(isnull(c.Cajas_Marcadas,0)) from Pedidos_Local c with(nolock) inner join Pedidos_Ficha d with(nolock) on(c.Orden=d.Orden) where d.pedido='" + Data.Rows(i)(0).ToString() + "' group by d.Pedido,c.Pallet) b on(a.pallet=b.Pallet) WHERE a.pedido='" + Data.Rows(i)(0).ToString() + "' group by a.pallet,a.est,a.cajas"
                Dim dtDetsPed As DataTable = fnc.ListarTablasSQL(sqlDetsPed)

                Dim CantPalls As Integer = 0
                Dim CantPallsMarcs As Integer = 0
                Dim CantCajs As Integer = 0
                Dim CantCajsMarcs As Integer = 0

                If (dtDetsPed.Rows.Count > 0) Then
                    For j = 0 To dtDetsPed.Rows.Count - 1
                        CantPalls += 1
                        CantCajs += CInt(dtDetsPed.Rows(j).Item(1).ToString.Trim)
                        CantCajsMarcs += CInt(dtDetsPed.Rows(j).Item(2).ToString.Trim)

                        If (CInt(dtDetsPed.Rows(j).Item(1).ToString.Trim) = CInt(dtDetsPed.Rows(j).Item(2).ToString.Trim)) Then
                            CantPallsMarcs += 1
                        End If
                    Next
                End If

                Data.Rows(i)(6) = (CStr(CantPallsMarcs) & " / " & CStr(CantPalls)).ToString()
                Data.Rows(i)(8) = (CStr(CantCajsMarcs) & " / " & CStr(CantCajs)).ToString()

                'Dim sqlTotal As String = "SELECT COUNT(*) FROM pedidos_detalle WHERE pedido='" + Data.Rows(i)(0).ToString() + "'"
                'Dim tablatotal As DataTable = fnc.ListarTablasSQL(sqlTotal)

                'Dim sqlTotal2 As String = "SELECT COUNT(*) FROM pedidos_detalle WHERE pedido='" + Data.Rows(i)(0).ToString() + "' AND est='1'"
                'Dim tablatotal2 As DataTable = fnc.ListarTablasSQL(sqlTotal2)

                'If tablatotal.Rows.Count > 0 AndAlso tablatotal2.Rows.Count > 0 Then
                '    Dim todos As String = tablatotal.Rows(0)(0).ToString()
                '    Dim de As String = tablatotal2.Rows(0)(0).ToString()
                '    Data.Rows(i)(6) = (de + " / " + todos).ToString()
                'End If
            Next
            'Fin modificacion HAmestica 071218. Actualizacion Pedidos Locales

            DgvPedidos.DataSource = Data

            For i = 0 To DgvPedidos.Rows.Count - 1
                If Convert.ToInt16(DgvPedidos.Rows(i).Cells(11).Value.ToString()) = 1 Then
                    DgvPedidos.Rows(i).DefaultCellStyle.ForeColor = Color.Red
                End If
            Next

        ElseIf cbtipo.SelectedValue.ToString() = "3" Then
            'Modificacion HAmestica 071218. Actualizacion Pedidos Locales

            'Dim sql As String = "SELECT TOP(100) pedido, Orden, cliente+ '  '+ cli_nomb AS cliente, fecha, hora, destino, destino AS sopo, codvig " +
            '                  "FROM pedidos_ficha, clientes " +
            '                  "WHERE cli_rut=cliente AND codvig='0' ORDER BY orden DESC"

            'Dim sql As String = "SELECT TOP(100) a.pedido,a.Orden,a.cliente+' '+b.cli_nomb AS cliente,a.fecha,a.hora,a.destino,a.destino AS sopo,a.codvig,'' AS Cajas,Tipo=case when c.Cajas_Marcadas is null then 'NORMAL' else 'LOCAL' end FROM pedidos_ficha a with(nolock) inner join clientes b with(nolock) on(b.cli_rut=a.cliente) left outer join(select d.Orden,c.Pallet,Cajas_Marcadas=sum(isnull(c.Cajas_Marcadas,0)) from Pedidos_Local c with(nolock) inner join Pedidos_Ficha d with(nolock) on(c.Orden=d.Orden) group by d.Orden,c.Pallet) c on(a.Orden=c.Orden) WHERE a.codvig='0'ORDER BY a.orden DESC"
            'Dim sql As String = "SELECT TOP(100) a.pedido,a.Orden,a.cliente+' '+b.cli_nomb AS cliente,a.fecha,a.hora,a.destino,a.destino AS sopo,a.codvig,'' AS Cajas,Tipo=case when c.Orden is null then 'NORMAL' else 'LOCAL' end FROM pedidos_ficha a with(nolock) inner join clientes b with(nolock) on(b.cli_rut=a.cliente) left outer join(select distinct Orden from Pedidos_Local with(nolock)) c on(a.Orden=c.Orden) WHERE a.codvig='0' ORDER BY a.orden DESC"
            'Dim sql As String = "SELECT DISTINCT TOP(100) a.pedido,a.Orden,a.cliente+' '+b.cli_nomb AS cliente,a.fecha,a.hora,a.destino,a.destino AS sopo,a.codvig,'' AS Cajas,Tipo=case when c.Orden is null then 'NORMAL' else 'LOCAL' end,Tipo_Carga=isnull(a.ped_carga,''),Tipo_Exportacion=isnull(e.Tipo,'Nacional'),Nro_Sol_Sag=isnull(d.Nro_Sol_SAG,''),Etiquetado_Adicional=case when isnull(d.Etiquetado_Adicional,0)=0 then 'No' else 'Si' end FROM pedidos_ficha a with(nolock) inner join clientes b with(nolock) on(b.cli_rut=a.cliente) left outer join(select distinct Orden from Pedidos_Local with(nolock)) c on(a.Orden=c.Orden) left outer join Pedidos_Tipo_Exportacion_Creados d with(nolock) on(a.Orden=d.Orden_Pedido) left outer join Pedidos_Tipo_Exportacion e with(nolock) on(d.ID_Tipo_Exportacion=e.ID) WHERE a.codvig='0' ORDER BY a.orden DESC"
            'Dim sql As String = "SELECT DISTINCT TOP(100) a.pedido,a.Orden,a.cliente+' '+b.cli_nomb AS cliente,a.fecha,a.hora,a.destino,a.destino AS sopo,a.codvig,'' AS Cajas,Tipo=case when c.Orden is null then 'NORMAL' else 'LOCAL' end,Tipo_Carga=isnull(a.ped_carga,''),Tipo_Exportacion=isnull(e.Tipo,'Nacional'),Nro_Sol_Sag=isnull(d.Nro_Sol_SAG,''),Etiquetado_Adicional=case when isnull(d.Etiquetado_Adicional,0)=0 then 'No' else 'Si' end,Fecha_Frm=convert(date,a.fecha) FROM pedidos_ficha a with(nolock) inner join clientes b with(nolock) on(b.cli_rut=a.cliente) left outer join(select distinct Orden from Pedidos_Local with(nolock)) c on(a.Orden=c.Orden) left outer join Pedidos_Tipo_Exportacion_Creados d with(nolock) on(a.Orden=d.Orden_Pedido) left outer join Pedidos_Tipo_Exportacion e with(nolock) on(d.ID_Tipo_Exportacion=e.ID) WHERE a.codvig='0' order by convert(date,a.fecha) desc,a.hora asc"
            Dim sql As String = "SELECT DISTINCT TOP(100) a.pedido,a.Orden,b.cli_nomb AS cliente,a.fecha,a.hora,a.destino,a.destino AS sopo,a.codvig,'' AS Cajas,Tipo=case when c.Orden is null then 'NORMAL' else 'LOCAL' end,Tipo_Carga=isnull(a.ped_carga,''),Tipo_Exportacion=isnull(e.Tipo,'Nacional'),Nro_Sol_Sag=isnull(d.Nro_Sol_SAG,''),Etiquetado_Adicional=case when isnull(d.Etiquetado_Adicional,0)=0 then 'No' else 'Si' end,Fecha_Frm=convert(date,a.fecha),Kilos=f.kilos FROM pedidos_ficha a with(nolock) inner join clientes b with(nolock) on(b.cli_rut=a.cliente) left outer join(select distinct Orden from Pedidos_Local with(nolock)) c on(a.Orden=c.Orden) left outer join Pedidos_Tipo_Exportacion_Creados d with(nolock) on(a.Orden=d.Orden_Pedido) left outer join Pedidos_Tipo_Exportacion e with(nolock) on(d.ID_Tipo_Exportacion=e.ID) inner join (select a.pedido,kilos=round(sum(a.kilos),0) from Pedidos_detalle a with(nolock) group by a.pedido) f on(a.pedido=f.pedido) WHERE a.codvig='0' order by convert(date,a.fecha) desc,a.hora asc"

            Dim Data As DataTable = fnc.ListarTablasSQL(sql)

            For i As Integer = 0 To Data.Rows.Count - 1
                Dim sqlDetsPed As String = "select distinct a.pallet,Cajas=SUM(isnull(Cajas,0)),Cajas_Marcadas=case when a.est='0' then sum(isnull(b.Cajas_Marcadas,0)) else a.cajas end from pedidos_detalle a with(nolock) left outer join(select d.Pedido,c.Pallet,Cajas_Marcadas=sum(isnull(c.Cajas_Marcadas,0)) from Pedidos_Local c with(nolock) inner join Pedidos_Ficha d with(nolock) on(c.Orden=d.Orden) where d.pedido='" + Data.Rows(i)(0).ToString() + "' group by d.Pedido,c.Pallet) b on(a.pallet=b.Pallet) WHERE a.pedido='" + Data.Rows(i)(0).ToString() + "' group by a.pallet,a.est,a.cajas"
                Dim dtDetsPed As DataTable = fnc.ListarTablasSQL(sqlDetsPed)

                Dim CantPalls As Integer = 0
                Dim CantPallsMarcs As Integer = 0
                Dim CantCajs As Integer = 0
                Dim CantCajsMarcs As Integer = 0

                If (dtDetsPed.Rows.Count > 0) Then
                    For j = 0 To dtDetsPed.Rows.Count - 1
                        CantPalls += 1
                        CantCajs += CInt(dtDetsPed.Rows(j).Item(1).ToString.Trim)
                        CantCajsMarcs += CInt(dtDetsPed.Rows(j).Item(2).ToString.Trim)

                        If (CInt(dtDetsPed.Rows(j).Item(1).ToString.Trim) = CInt(dtDetsPed.Rows(j).Item(2).ToString.Trim)) Then
                            CantPallsMarcs += 1
                        End If
                    Next
                End If

                Data.Rows(i)(6) = (CStr(CantPallsMarcs) & " / " & CStr(CantPalls)).ToString()
                Data.Rows(i)(8) = (CStr(CantCajsMarcs) & " / " & CStr(CantCajs)).ToString()

                'Dim sqlTotal As String = "SELECT COUNT(*) FROM pedidos_detalle WHERE pedido='" + Data.Rows(i)(0).ToString() + "'"
                'Dim tablatotal As DataTable = fnc.ListarTablasSQL(sqlTotal)

                'Dim sqlTotal2 As String = "SELECT COUNT(*) FROM pedidos_detalle WHERE pedido='" + Data.Rows(i)(0).ToString() + "' AND est='1'"
                'Dim tablatotal2 As DataTable = fnc.ListarTablasSQL(sqlTotal2)

                'If tablatotal.Rows.Count > 0 AndAlso tablatotal2.Rows.Count > 0 Then
                '    Dim todos As String = tablatotal.Rows(0)(0).ToString()
                '    Dim de As String = tablatotal2.Rows(0)(0).ToString()
                '    Data.Rows(i)(6) = (de + " / " + todos).ToString()
                'End If
            Next
            'Fin modificacion HAmestica 071218. Actualizacion Pedidos Locales

            DgvPedidos.DataSource = Data

            For i = 0 To DgvPedidos.Rows.Count - 1
                If Convert.ToInt16(DgvPedidos.Rows(i).Cells(11).Value.ToString()) = 1 Then
                    DgvPedidos.Rows(i).DefaultCellStyle.ForeColor = Color.Red
                End If
            Next
        End If


    End Sub

    Sub cargarDatos()
        If cbtipo.SelectedValue.ToString() = "1" Then
            'Modificacion HAmestica 071218. Actualizacion Pedidos Locales

            'Dim sql As String = "SELECT  pedido, Orden, cliente+ '  '+ cli_nomb AS cliente, fecha, hora, destino, destino AS sopo, codvig " +
            '               "FROM pedidos_ficha, clientes " +
            '               "WHERE cli_rut=cliente AND terminado <>'3' AND Ped_estpred<>'3' AND codvig='0' AND Orden not in(SELECT fpre_nped FROM fichpred)  ORDER BY orden DESC"
            ''AND Dateadd(day,2,Convert(date,fecha,103))>Convert(date,GETDATE(),103)

            'Dim sql As String = "select a.pedido,a.Orden,a.cliente+' '+b.cli_nomb AS cliente,a.fecha,a.hora,destino=isnull(a.destino,''),sopo=isnull(a.destino,''),a.codvig,'' AS Cajas,Tipo=case when c.Orden is null then 'NORMAL' else 'LOCAL' end from pedidos_ficha a with(nolock) inner join clientes b with(nolock) on(b.cli_rut=a.cliente) left outer join(select distinct Orden from Pedidos_Local with(nolock)) c on(a.Orden=c.Orden) where a.terminado <>'3' AND a.Ped_estpred<>'3' AND a.codvig='0' AND a.Orden not in(select fpre_nped from fichpred) order by a.orden desc"
            'Dim sql As String = "select distinct a.pedido,a.Orden,a.cliente+' '+b.cli_nomb AS cliente,a.fecha,a.hora,destino=isnull(a.destino,''),sopo=isnull(a.destino,''),a.codvig,'' AS Cajas,Tipo=case when c.Orden is null then 'NORMAL' else 'LOCAL' end,Tipo_Carga=isnull(a.ped_carga,''),Tipo_Exportacion=isnull(e.Tipo,'Nacional'),Nro_Sol_Sag=isnull(d.Nro_Sol_SAG,''),Etiquetado_Adicional=case when isnull(d.Etiquetado_Adicional,0)=0 then 'No' else 'Si' end from pedidos_ficha a with(nolock) inner join clientes b with(nolock) on(b.cli_rut=a.cliente) left outer join(select distinct Orden from Pedidos_Local with(nolock)) c on(a.Orden=c.Orden) left outer join Pedidos_Tipo_Exportacion_Creados d with(nolock) on(a.Orden=d.Orden_Pedido) left outer join Pedidos_Tipo_Exportacion e with(nolock) on(d.ID_Tipo_Exportacion=e.ID) where a.terminado <>'3' AND a.Ped_estpred<>'3' AND a.codvig='0' AND a.Orden not in(select fpre_nped from fichpred) order by a.orden desc"
            'Dim sql As String = "select distinct a.pedido,a.Orden,a.cliente+' '+b.cli_nomb AS cliente,a.fecha,a.hora,destino=isnull(a.destino,''),sopo=isnull(a.destino,''),a.codvig,'' AS Cajas,Tipo=case when c.Orden is null then 'NORMAL' else 'LOCAL' end,Tipo_Carga=isnull(a.ped_carga,''),Tipo_Exportacion=isnull(e.Tipo,'Nacional'),Nro_Sol_Sag=isnull(d.Nro_Sol_SAG,''),Etiquetado_Adicional=case when isnull(d.Etiquetado_Adicional,0)=0 then 'No' else 'Si' end,Fecha_Frm=convert(date,a.fecha) from pedidos_ficha a with(nolock) inner join clientes b with(nolock) on(b.cli_rut=a.cliente) left outer join(select distinct Orden from Pedidos_Local with(nolock)) c on(a.Orden=c.Orden) left outer join Pedidos_Tipo_Exportacion_Creados d with(nolock) on(a.Orden=d.Orden_Pedido) left outer join Pedidos_Tipo_Exportacion e with(nolock) on(d.ID_Tipo_Exportacion=e.ID) where a.terminado <>'3' AND a.Ped_estpred<>'3' AND a.codvig='0' AND a.Orden not in(select fpre_nped from fichpred) order by convert(date,a.fecha),a.hora asc"
            Dim sql As String = "select distinct a.pedido,a.Orden,b.cli_nomb AS cliente,a.fecha,a.hora,destino=isnull(a.destino,''),sopo=isnull(a.destino,''),a.codvig,'' AS Cajas,Tipo=case when c.Orden is null then 'NORMAL' else 'LOCAL' end,Tipo_Carga=isnull(a.ped_carga,''),Tipo_Exportacion=isnull(e.Tipo,'Nacional'),Nro_Sol_Sag=isnull(d.Nro_Sol_SAG,''),Etiquetado_Adicional=case when isnull(d.Etiquetado_Adicional,0)=0 then 'No' else 'Si' end,Fecha_Frm=convert(date,a.fecha),Kilos=f.kilos from pedidos_ficha a with(nolock) inner join clientes b with(nolock) on(b.cli_rut=a.cliente) left outer join(select distinct Orden from Pedidos_Local with(nolock)) c on(a.Orden=c.Orden) left outer join Pedidos_Tipo_Exportacion_Creados d with(nolock) on(a.Orden=d.Orden_Pedido) left outer join Pedidos_Tipo_Exportacion e with(nolock) on(d.ID_Tipo_Exportacion=e.ID) inner join (select a.pedido,kilos=round(sum(a.kilos),0) from Pedidos_detalle a with(nolock) group by a.pedido) f on(a.pedido=f.pedido) where a.terminado <>'3' AND a.Ped_estpred<>'3' AND a.codvig='0' AND a.Orden not in(select fpre_nped from fichpred) order by convert(date,a.fecha),a.hora asc"

            Dim Data As DataTable = fnc.ListarTablasSQL(sql)

            For i As Integer = 0 To Data.Rows.Count - 1
                Dim sqlDetsPed As String = "select distinct a.pallet,Cajas=SUM(isnull(Cajas,0)),Cajas_Marcadas=case when a.est='0' then sum(isnull(b.Cajas_Marcadas,0)) else a.cajas end from pedidos_detalle a with(nolock) left outer join(select d.Pedido,c.Pallet,Cajas_Marcadas=sum(isnull(c.Cajas_Marcadas,0)) from Pedidos_Local c with(nolock) inner join Pedidos_Ficha d with(nolock) on(c.Orden=d.Orden) where d.pedido='" + Data.Rows(i)(0).ToString() + "' group by d.Pedido,c.Pallet) b on(a.pallet=b.Pallet) WHERE a.pedido='" + Data.Rows(i)(0).ToString() + "' group by a.pallet,a.est,a.cajas"
                Dim dtDetsPed As DataTable = fnc.ListarTablasSQL(sqlDetsPed)

                Dim CantPalls As Integer = 0
                Dim CantPallsMarcs As Integer = 0
                Dim CantCajs As Integer = 0
                Dim CantCajsMarcs As Integer = 0

                If (dtDetsPed.Rows.Count > 0) Then
                    For j = 0 To dtDetsPed.Rows.Count - 1
                        CantPalls += 1
                        CantCajs += CInt(dtDetsPed.Rows(j).Item(1).ToString.Trim)
                        CantCajsMarcs += CInt(dtDetsPed.Rows(j).Item(2).ToString.Trim)

                        If (CInt(dtDetsPed.Rows(j).Item(1).ToString.Trim) = CInt(dtDetsPed.Rows(j).Item(2).ToString.Trim)) Then
                            CantPallsMarcs += 1
                        End If
                    Next
                End If

                Data.Rows(i)(6) = (CStr(CantPallsMarcs) & " / " & CStr(CantPalls)).ToString()
                Data.Rows(i)(8) = (CStr(CantCajsMarcs) & " / " & CStr(CantCajs)).ToString()

                'Dim sqlTotal As String = "SELECT COUNT(*) FROM pedidos_detalle WHERE pedido='" + Data.Rows(i)(0).ToString() + "'"
                'Dim tablatotal As DataTable = fnc.ListarTablasSQL(sqlTotal)

                'Dim sqlTotal2 As String = "SELECT COUNT(*) FROM pedidos_detalle WHERE pedido='" + Data.Rows(i)(0).ToString() + "' AND est='1'"
                'Dim tablatotal2 As DataTable = fnc.ListarTablasSQL(sqlTotal2)

                'If tablatotal.Rows.Count > 0 AndAlso tablatotal2.Rows.Count > 0 Then
                '    Dim todos As String = tablatotal.Rows(0)(0).ToString()
                '    Dim de As String = tablatotal2.Rows(0)(0).ToString()
                '    Data.Rows(i)(6) = (de + " / " + todos).ToString()
                'End If
            Next
            'Fin modificacion HAmestica 071218. Actualizacion Pedidos Locales

            DgvPedidos.DataSource = Data

            For i = 0 To DgvPedidos.Rows.Count - 1
                If Convert.ToInt16(DgvPedidos.Rows(i).Cells(11).Value.ToString()) = 1 Then
                    DgvPedidos.Rows(i).DefaultCellStyle.ForeColor = Color.Red
                End If
            Next

        ElseIf cbtipo.SelectedValue.ToString() = "2" Then
            'Modificacion HAmestica 071218. Actualizacion Pedidos Locales

            'Dim sql As String = "SELECT TOP(10) pedido, Orden, cliente+ '  '+ cli_nomb AS cliente, fecha, hora, destino, destino AS sopo, codvig " +
            '                   "FROM pedidos_ficha, clientes " +
            '                   "WHERE cli_rut=cliente AND terminado<>'0' AND codvig='0' ORDER BY orden DESC"

            'Dim sql As String = "SELECT TOP(10) a.pedido,a.Orden,a.cliente+' '+b.cli_nomb AS cliente,a.fecha,a.hora,a.destino,a.destino AS sopo,a.codvig,'' AS Cajas, Tipo=case when c.Orden is null then 'NORMAL' else 'LOCAL' end FROM pedidos_ficha a with(nolock) inner join clientes b with(nolock) on(b.cli_rut=a.cliente) left outer join(select distinct Orden from Pedidos_Local with(nolock)) c on(a.Orden=c.Orden) WHERE a.terminado <>'0' AND a.codvig='0' ORDER BY a.orden DESC"
            'Dim sql As String = "SELECT DISTINCT TOP(10) a.pedido,a.Orden,a.cliente+' '+b.cli_nomb AS cliente,a.fecha,a.hora,a.destino,a.destino AS sopo,a.codvig,'' AS Cajas, Tipo=case when c.Orden is null then 'NORMAL' else 'LOCAL' end,Tipo_Carga=isnull(a.ped_carga,''),Tipo_Exportacion=isnull(e.Tipo,'Nacional'),Nro_Sol_Sag=isnull(d.Nro_Sol_SAG,''),Etiquetado_Adicional=case when isnull(d.Etiquetado_Adicional,0)=0 then 'No' else 'Si' end FROM pedidos_ficha a with(nolock) inner join clientes b with(nolock) on(b.cli_rut=a.cliente) left outer join(select distinct Orden from Pedidos_Local with(nolock)) c on(a.Orden=c.Orden) left outer join Pedidos_Tipo_Exportacion_Creados d with(nolock) on(a.Orden=d.Orden_Pedido) left outer join Pedidos_Tipo_Exportacion e with(nolock) on(d.ID_Tipo_Exportacion=e.ID) WHERE a.terminado <>'0' AND a.codvig='0' ORDER BY a.orden DESC"
            'Dim sql As String = "SELECT DISTINCT TOP(10) a.pedido,a.Orden,a.cliente+' '+b.cli_nomb AS cliente,a.fecha,a.hora,a.destino,a.destino AS sopo,a.codvig,'' AS Cajas, Tipo=case when c.Orden is null then 'NORMAL' else 'LOCAL' end,Tipo_Carga=isnull(a.ped_carga,''),Tipo_Exportacion=isnull(e.Tipo,'Nacional'),Nro_Sol_Sag=isnull(d.Nro_Sol_SAG,''),Etiquetado_Adicional=case when isnull(d.Etiquetado_Adicional,0)=0 then 'No' else 'Si' end,Fecha_Frm=convert(date,a.fecha) FROM pedidos_ficha a with(nolock) inner join clientes b with(nolock) on(b.cli_rut=a.cliente) left outer join(select distinct Orden from Pedidos_Local with(nolock)) c on(a.Orden=c.Orden) left outer join Pedidos_Tipo_Exportacion_Creados d with(nolock) on(a.Orden=d.Orden_Pedido) left outer join Pedidos_Tipo_Exportacion e with(nolock) on(d.ID_Tipo_Exportacion=e.ID) WHERE a.terminado <>'0' AND a.codvig='0' order by convert(date,a.fecha) desc,a.hora asc"
            Dim sql As String = "SELECT DISTINCT TOP(10) a.pedido,a.Orden,b.cli_nomb AS cliente,a.fecha,a.hora,a.destino,a.destino AS sopo,a.codvig,'' AS Cajas, Tipo=case when c.Orden is null then 'NORMAL' else 'LOCAL' end,Tipo_Carga=isnull(a.ped_carga,''),Tipo_Exportacion=isnull(e.Tipo,'Nacional'),Nro_Sol_Sag=isnull(d.Nro_Sol_SAG,''),Etiquetado_Adicional=case when isnull(d.Etiquetado_Adicional,0)=0 then 'No' else 'Si' end,Fecha_Frm=convert(date,a.fecha),Kilos=f.kilos FROM pedidos_ficha a with(nolock) inner join clientes b with(nolock) on(b.cli_rut=a.cliente) left outer join(select distinct Orden from Pedidos_Local with(nolock)) c on(a.Orden=c.Orden) left outer join Pedidos_Tipo_Exportacion_Creados d with(nolock) on(a.Orden=d.Orden_Pedido) left outer join Pedidos_Tipo_Exportacion e with(nolock) on(d.ID_Tipo_Exportacion=e.ID) inner join (select a.pedido,kilos=round(sum(a.kilos),0) from Pedidos_detalle a with(nolock) group by a.pedido) f on(a.pedido=f.pedido) WHERE a.terminado <>'0' AND a.codvig='0' order by convert(date,a.fecha) desc,a.hora asc"

            Dim Data As DataTable = fnc.ListarTablasSQL(sql)

            For i As Integer = 0 To Data.Rows.Count - 1
                Dim sqlDetsPed As String = "select distinct a.pallet,Cajas=SUM(isnull(Cajas,0)),Cajas_Marcadas=case when a.est='0' then sum(isnull(b.Cajas_Marcadas,0)) else a.cajas end from pedidos_detalle a with(nolock) left outer join(select d.Pedido,c.Pallet,Cajas_Marcadas=sum(isnull(c.Cajas_Marcadas,0)) from Pedidos_Local c with(nolock) inner join Pedidos_Ficha d with(nolock) on(c.Orden=d.Orden) where d.pedido='" + Data.Rows(i)(0).ToString() + "' group by d.Pedido,c.Pallet) b on(a.pallet=b.Pallet) WHERE a.pedido='" + Data.Rows(i)(0).ToString() + "' group by a.pallet,a.est,a.cajas"
                Dim dtDetsPed As DataTable = fnc.ListarTablasSQL(sqlDetsPed)

                Dim CantPalls As Integer = 0
                Dim CantPallsMarcs As Integer = 0
                Dim CantCajs As Integer = 0
                Dim CantCajsMarcs As Integer = 0

                If (dtDetsPed.Rows.Count > 0) Then
                    For j = 0 To dtDetsPed.Rows.Count - 1
                        CantPalls += 1
                        CantCajs += CInt(dtDetsPed.Rows(j).Item(1).ToString.Trim)
                        CantCajsMarcs += CInt(dtDetsPed.Rows(j).Item(2).ToString.Trim)

                        If (CInt(dtDetsPed.Rows(j).Item(1).ToString.Trim) = CInt(dtDetsPed.Rows(j).Item(2).ToString.Trim)) Then
                            CantPallsMarcs += 1
                        End If
                    Next
                End If

                Data.Rows(i)(6) = (CStr(CantPallsMarcs) & " / " & CStr(CantPalls)).ToString()
                Data.Rows(i)(8) = (CStr(CantCajsMarcs) & " / " & CStr(CantCajs)).ToString()

                'Dim sqlTotal As String = "SELECT COUNT(*) FROM pedidos_detalle WHERE pedido='" + Data.Rows(i)(0).ToString() + "'"
                'Dim tablatotal As DataTable = fnc.ListarTablasSQL(sqlTotal)

                'Dim sqlTotal2 As String = "SELECT COUNT(*) FROM pedidos_detalle WHERE pedido='" + Data.Rows(i)(0).ToString() + "' AND est='1'"
                'Dim tablatotal2 As DataTable = fnc.ListarTablasSQL(sqlTotal2)

                'If tablatotal.Rows.Count > 0 AndAlso tablatotal2.Rows.Count > 0 Then
                '    Dim todos As String = tablatotal.Rows(0)(0).ToString()
                '    Dim de As String = tablatotal2.Rows(0)(0).ToString()
                '    Data.Rows(i)(6) = (de + " / " + todos).ToString()
                'End If
            Next
            'Fin modificacion HAmestica 071218. Actualizacion Pedidos Locales

            DgvPedidos.DataSource = Data

            For i = 0 To DgvPedidos.Rows.Count - 1
                If Convert.ToInt16(DgvPedidos.Rows(i).Cells(11).Value.ToString()) = 1 Then
                    DgvPedidos.Rows(i).DefaultCellStyle.ForeColor = Color.Red
                End If
            Next

        ElseIf cbtipo.SelectedValue.ToString() = "3" Then
            'Modificacion HAmestica 071218. Actualizacion Pedidos Locales

            'Dim sql As String = "SELECT TOP(100) pedido, Orden, cliente+ '  '+ cli_nomb AS cliente, fecha, hora, destino, destino AS sopo, codvig " +
            '                  "FROM pedidos_ficha, clientes " +
            '                  "WHERE cli_rut=cliente AND codvig='0' ORDER BY orden DESC"

            'Dim sql As String = "SELECT TOP(100) a.pedido,a.Orden,a.cliente+' '+b.cli_nomb AS cliente,a.fecha,a.hora,a.destino,a.destino AS sopo,a.codvig,'' AS Cajas,Tipo=case when c.Orden is null then 'NORMAL' else 'LOCAL' end FROM pedidos_ficha a with(nolock) inner join clientes b with(nolock) on(b.cli_rut=a.cliente) left outer join(select distinct Orden from Pedidos_Local with(nolock)) c on(a.Orden=c.Orden) WHERE a.codvig='0' ORDER BY a.orden DESC"
            'Dim sql As String = "SELECT DISTINCT TOP(100) a.pedido,a.Orden,a.cliente+' '+b.cli_nomb AS cliente,a.fecha,a.hora,a.destino,a.destino AS sopo,a.codvig,'' AS Cajas,Tipo=case when c.Orden is null then 'NORMAL' else 'LOCAL' end,Tipo_Carga=isnull(a.ped_carga,''),Tipo_Exportacion=isnull(e.Tipo,'Nacional'),Nro_Sol_Sag=isnull(d.Nro_Sol_SAG,''),Etiquetado_Adicional=case when isnull(d.Etiquetado_Adicional,0)=0 then 'No' else 'Si' end FROM pedidos_ficha a with(nolock) inner join clientes b with(nolock) on(b.cli_rut=a.cliente) left outer join(select distinct Orden from Pedidos_Local with(nolock)) c on(a.Orden=c.Orden) left outer join Pedidos_Tipo_Exportacion_Creados d with(nolock) on(a.Orden=d.Orden_Pedido) left outer join Pedidos_Tipo_Exportacion e with(nolock) on(d.ID_Tipo_Exportacion=e.ID) WHERE a.codvig='0' ORDER BY a.orden DESC"
            'Dim sql As String = "SELECT DISTINCT TOP(100) a.pedido,a.Orden,a.cliente+' '+b.cli_nomb AS cliente,a.fecha,a.hora,a.destino,a.destino AS sopo,a.codvig,'' AS Cajas,Tipo=case when c.Orden is null then 'NORMAL' else 'LOCAL' end,Tipo_Carga=isnull(a.ped_carga,''),Tipo_Exportacion=isnull(e.Tipo,'Nacional'),Nro_Sol_Sag=isnull(d.Nro_Sol_SAG,''),Etiquetado_Adicional=case when isnull(d.Etiquetado_Adicional,0)=0 then 'No' else 'Si' end,Fecha_Frm=convert(date,a.fecha) FROM pedidos_ficha a with(nolock) inner join clientes b with(nolock) on(b.cli_rut=a.cliente) left outer join(select distinct Orden from Pedidos_Local with(nolock)) c on(a.Orden=c.Orden) left outer join Pedidos_Tipo_Exportacion_Creados d with(nolock) on(a.Orden=d.Orden_Pedido) left outer join Pedidos_Tipo_Exportacion e with(nolock) on(d.ID_Tipo_Exportacion=e.ID) WHERE a.codvig='0' order by convert(date,a.fecha) desc,a.hora asc"
            Dim sql As String = "SELECT DISTINCT TOP(100) a.pedido,a.Orden,b.cli_nomb AS cliente,a.fecha,a.hora,a.destino,a.destino AS sopo,a.codvig,'' AS Cajas,Tipo=case when c.Orden is null then 'NORMAL' else 'LOCAL' end,Tipo_Carga=isnull(a.ped_carga,''),Tipo_Exportacion=isnull(e.Tipo,'Nacional'),Nro_Sol_Sag=isnull(d.Nro_Sol_SAG,''),Etiquetado_Adicional=case when isnull(d.Etiquetado_Adicional,0)=0 then 'No' else 'Si' end,Fecha_Frm=convert(date,a.fecha),Kilos=f.kilos FROM pedidos_ficha a with(nolock) inner join clientes b with(nolock) on(b.cli_rut=a.cliente) left outer join(select distinct Orden from Pedidos_Local with(nolock)) c on(a.Orden=c.Orden) left outer join Pedidos_Tipo_Exportacion_Creados d with(nolock) on(a.Orden=d.Orden_Pedido) left outer join Pedidos_Tipo_Exportacion e with(nolock) on(d.ID_Tipo_Exportacion=e.ID) inner join (select a.pedido,kilos=round(sum(a.kilos),0) from Pedidos_detalle a with(nolock) group by a.pedido) f on(a.pedido=f.pedido) WHERE a.codvig='0' order by convert(date,a.fecha) desc,a.hora asc"

            Dim Data As DataTable = fnc.ListarTablasSQL(sql)

            For i As Integer = 0 To Data.Rows.Count - 1
                Dim sqlDetsPed As String = "select distinct a.pallet,Cajas=SUM(isnull(Cajas,0)),Cajas_Marcadas=case when a.est='0' then sum(isnull(b.Cajas_Marcadas,0)) else a.cajas end from pedidos_detalle a with(nolock) left outer join(select d.Pedido,c.Pallet,Cajas_Marcadas=sum(isnull(c.Cajas_Marcadas,0)) from Pedidos_Local c with(nolock) inner join Pedidos_Ficha d with(nolock) on(c.Orden=d.Orden) where d.pedido='" + Data.Rows(i)(0).ToString() + "' group by d.Pedido,c.Pallet) b on(a.pallet=b.Pallet) WHERE a.pedido='" + Data.Rows(i)(0).ToString() + "' group by a.pallet,a.est,a.cajas"
                Dim dtDetsPed As DataTable = fnc.ListarTablasSQL(sqlDetsPed)

                Dim CantPalls As Integer = 0
                Dim CantPallsMarcs As Integer = 0
                Dim CantCajs As Integer = 0
                Dim CantCajsMarcs As Integer = 0

                If (dtDetsPed.Rows.Count > 0) Then
                    For j = 0 To dtDetsPed.Rows.Count - 1
                        CantPalls += 1
                        CantCajs += CInt(dtDetsPed.Rows(j).Item(1).ToString.Trim)
                        CantCajsMarcs += CInt(dtDetsPed.Rows(j).Item(2).ToString.Trim)

                        If (CInt(dtDetsPed.Rows(j).Item(1).ToString.Trim) = CInt(dtDetsPed.Rows(j).Item(2).ToString.Trim)) Then
                            CantPallsMarcs += 1
                        End If
                    Next
                End If

                Data.Rows(i)(6) = (CStr(CantPallsMarcs) & " / " & CStr(CantPalls)).ToString()
                Data.Rows(i)(8) = (CStr(CantCajsMarcs) & " / " & CStr(CantCajs)).ToString()

                'Dim sqlTotal As String = "SELECT COUNT(*) FROM pedidos_detalle WHERE pedido='" + Data.Rows(i)(0).ToString() + "'"
                'Dim tablatotal As DataTable = fnc.ListarTablasSQL(sqlTotal)

                'Dim sqlTotal2 As String = "SELECT COUNT(*) FROM pedidos_detalle WHERE pedido='" + Data.Rows(i)(0).ToString() + "' AND est='1'"
                'Dim tablatotal2 As DataTable = fnc.ListarTablasSQL(sqlTotal2)

                'If tablatotal.Rows.Count > 0 AndAlso tablatotal2.Rows.Count > 0 Then
                '    Dim todos As String = tablatotal.Rows(0)(0).ToString()
                '    Dim de As String = tablatotal2.Rows(0)(0).ToString()
                '    Data.Rows(i)(6) = (de + " / " + todos).ToString()
                'End If
            Next
            'Fin modificacion HAmestica 071218. Actualizacion Pedidos Locales

            DgvPedidos.DataSource = Data

            For i = 0 To DgvPedidos.Rows.Count - 1
                If Convert.ToInt16(DgvPedidos.Rows(i).Cells(11).Value.ToString()) = 1 Then
                    DgvPedidos.Rows(i).DefaultCellStyle.ForeColor = Color.Red
                End If
            Next
        End If


    End Sub

    Private Sub cbtipo_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbtipo.SelectedValueChanged
        If cbtipo.SelectedValue.ToString() = "1" Then
            Timer1.Start()
            lblbus.Visible = False
            txtbus.Visible = False

            'Modificacion HAmestica 071218. Actualizacion Pedidos Locales

            'Dim sql As String = "SELECT  pedido, Orden, cliente+ '  '+ cli_nomb AS cliente, fecha, hora, destino, destino AS sopo, codvig " +
            '               "FROM pedidos_ficha, clientes " +
            '               "WHERE cli_rut=cliente AND terminado<>'3' AND codvig='0' AND Orden not in(SELECT fpre_nped FROM fichpred)  ORDER BY orden DESC"
            ''AND Dateadd(day,2,Convert(date,fecha,103))>Convert(date,GETDATE(),103)

            'Dim sql As String = "select a.pedido,a.Orden,a.cliente+' '+b.cli_nomb AS cliente,a.fecha,a.hora,destino=isnull(a.destino,''),sopo=isnull(a.destino,''),a.codvig,'' AS Cajas,Tipo=case when c.Orden is null then 'NORMAL' else 'LOCAL' end from pedidos_ficha a with(nolock) inner join clientes b with(nolock) on(b.cli_rut=a.cliente) left outer join(select distinct Orden from Pedidos_Local with(nolock)) c on(a.Orden=c.Orden) where a.terminado <>'3' AND a.Ped_estpred<>'3' AND a.codvig='0' AND a.Orden not in(select fpre_nped from fichpred) order by a.orden desc"
            'Dim sql As String = "select distinct a.pedido,a.Orden,a.cliente+' '+b.cli_nomb AS cliente,a.fecha,a.hora,destino=isnull(a.destino,''),sopo=isnull(a.destino,''),a.codvig,'' AS Cajas,Tipo=case when c.Orden is null then 'NORMAL' else 'LOCAL' end,Tipo_Carga=isnull(a.ped_carga,''),Tipo_Exportacion=isnull(e.Tipo,'Nacional'),Nro_Sol_Sag=isnull(d.Nro_Sol_SAG,''),Etiquetado_Adicional=case when isnull(d.Etiquetado_Adicional,0)=0 then 'No' else 'Si' end from pedidos_ficha a with(nolock) inner join clientes b with(nolock) on(b.cli_rut=a.cliente) left outer join(select distinct Orden from Pedidos_Local with(nolock)) c on(a.Orden=c.Orden) left outer join Pedidos_Tipo_Exportacion_Creados d with(nolock) on(a.Orden=d.Orden_Pedido) left outer join Pedidos_Tipo_Exportacion e with(nolock) on(d.ID_Tipo_Exportacion=e.ID) where a.terminado <>'3' AND a.Ped_estpred<>'3' AND a.codvig='0' AND a.Orden not in(select fpre_nped from fichpred) order by a.orden desc"
            'Dim sql As String = "select distinct a.pedido,a.Orden,a.cliente+' '+b.cli_nomb AS cliente,a.fecha,a.hora,destino=isnull(a.destino,''),sopo=isnull(a.destino,''),a.codvig,'' AS Cajas,Tipo=case when c.Orden is null then 'NORMAL' else 'LOCAL' end,Tipo_Carga=isnull(a.ped_carga,''),Tipo_Exportacion=isnull(e.Tipo,'Nacional'),Nro_Sol_Sag=isnull(d.Nro_Sol_SAG,''),Etiquetado_Adicional=case when isnull(d.Etiquetado_Adicional,0)=0 then 'No' else 'Si' end,Fecha_Frm=convert(date,a.fecha) from pedidos_ficha a with(nolock) inner join clientes b with(nolock) on(b.cli_rut=a.cliente) left outer join(select distinct Orden from Pedidos_Local with(nolock)) c on(a.Orden=c.Orden) left outer join Pedidos_Tipo_Exportacion_Creados d with(nolock) on(a.Orden=d.Orden_Pedido) left outer join Pedidos_Tipo_Exportacion e with(nolock) on(d.ID_Tipo_Exportacion=e.ID) where a.terminado <>'3' AND a.Ped_estpred<>'3' AND a.codvig='0' AND a.Orden not in(select fpre_nped from fichpred) order by convert(date,a.fecha),a.hora asc"
            Dim sql As String = "select distinct a.pedido,a.Orden,b.cli_nomb AS cliente,a.fecha,a.hora,destino=isnull(a.destino,''),sopo=isnull(a.destino,''),a.codvig,'' AS Cajas,Tipo=case when c.Orden is null then 'NORMAL' else 'LOCAL' end,Tipo_Carga=isnull(a.ped_carga,''),Tipo_Exportacion=isnull(e.Tipo,'Nacional'),Nro_Sol_Sag=isnull(d.Nro_Sol_SAG,''),Etiquetado_Adicional=case when isnull(d.Etiquetado_Adicional,0)=0 then 'No' else 'Si' end,Fecha_Frm=convert(date,a.fecha,103),Kilos=f.kilos from pedidos_ficha a with(nolock) inner join clientes b with(nolock) on(b.cli_rut=a.cliente) left outer join(select distinct Orden from Pedidos_Local with(nolock)) c on(a.Orden=c.Orden) left outer join Pedidos_Tipo_Exportacion_Creados d with(nolock) on(a.Orden=d.Orden_Pedido) left outer join Pedidos_Tipo_Exportacion e with(nolock) on(d.ID_Tipo_Exportacion=e.ID) inner join (select a.pedido,kilos=round(sum(a.kilos),0) from Pedidos_detalle a with(nolock) group by a.pedido) f on(a.pedido=f.pedido) where a.terminado <>'3' AND a.Ped_estpred<>'3' AND a.codvig='0' AND a.Orden not in(select fpre_nped from fichpred) order by convert(date,a.fecha,103),a.hora asc"

            Dim Data As DataTable = fnc.ListarTablasSQL(sql)

            For i As Integer = 0 To Data.Rows.Count - 1
                Dim sqlDetsPed As String = "select distinct a.pallet,Cajas=SUM(isnull(Cajas,0)),Cajas_Marcadas=case when a.est='0' then sum(isnull(b.Cajas_Marcadas,0)) else a.cajas end from pedidos_detalle a with(nolock) left outer join(select d.Pedido,c.Pallet,Cajas_Marcadas=sum(isnull(c.Cajas_Marcadas,0)) from Pedidos_Local c with(nolock) inner join Pedidos_Ficha d with(nolock) on(c.Orden=d.Orden) where d.pedido='" + Data.Rows(i)(0).ToString() + "' group by d.Pedido,c.Pallet) b on(a.pallet=b.Pallet) WHERE a.pedido='" + Data.Rows(i)(0).ToString() + "' group by a.pallet,a.est,a.cajas"
                Dim dtDetsPed As DataTable = fnc.ListarTablasSQL(sqlDetsPed)

                Dim CantPalls As Integer = 0
                Dim CantPallsMarcs As Integer = 0
                Dim CantCajs As Integer = 0
                Dim CantCajsMarcs As Integer = 0

                If (dtDetsPed.Rows.Count > 0) Then
                    For j = 0 To dtDetsPed.Rows.Count - 1
                        CantPalls += 1
                        CantCajs += CInt(dtDetsPed.Rows(j).Item(1).ToString.Trim)
                        CantCajsMarcs += CInt(dtDetsPed.Rows(j).Item(2).ToString.Trim)

                        If (CInt(dtDetsPed.Rows(j).Item(1).ToString.Trim) = CInt(dtDetsPed.Rows(j).Item(2).ToString.Trim)) Then
                            CantPallsMarcs += 1
                        End If
                    Next
                End If

                Data.Rows(i)(6) = (CStr(CantPallsMarcs) & " / " & CStr(CantPalls)).ToString()
                Data.Rows(i)(8) = (CStr(CantCajsMarcs) & " / " & CStr(CantCajs)).ToString()

                'Dim sqlTotal As String = "SELECT COUNT(*) FROM pedidos_detalle WHERE pedido='" + Data.Rows(i)(0).ToString() + "'"
                'Dim tablatotal As DataTable = fnc.ListarTablasSQL(sqlTotal)

                'Dim sqlTotal2 As String = "SELECT COUNT(*) FROM pedidos_detalle WHERE pedido='" + Data.Rows(i)(0).ToString() + "' AND est='1'"
                'Dim tablatotal2 As DataTable = fnc.ListarTablasSQL(sqlTotal2)

                'If tablatotal.Rows.Count > 0 AndAlso tablatotal2.Rows.Count > 0 Then
                '    Dim todos As String = tablatotal.Rows(0)(0).ToString()
                '    Dim de As String = tablatotal2.Rows(0)(0).ToString()
                '    Data.Rows(i)(6) = (de + " / " + todos).ToString()
                'End If
            Next
            'Fin modificacion HAmestica 071218. Actualizacion Pedidos Locales

            DgvPedidos.DataSource = Data

            For i = 0 To DgvPedidos.Rows.Count - 1
                If Convert.ToInt16(DgvPedidos.Rows(i).Cells(11).Value.ToString()) = 1 Then
                    DgvPedidos.Rows(i).DefaultCellStyle.ForeColor = Color.Red
                End If
            Next

        ElseIf cbtipo.SelectedValue.ToString() = "2" Then
            Timer1.Start()
            lblbus.Visible = False
            txtbus.Visible = False

            'Modificacion HAmestica 071218. Actualizacion Pedidos Locales

            'Dim sql As String = "SELECT TOP(10) pedido, Orden, cliente+ '  '+ cli_nomb AS cliente, fecha, hora, destino, destino AS sopo, codvig " +
            '                   "FROM pedidos_ficha, clientes " +
            '                   "WHERE cli_rut=cliente AND terminado<>'0' AND codvig='0' ORDER BY orden DESC"

            'Dim sql As String = "SELECT TOP(10) a.pedido,a.Orden,a.cliente+' '+b.cli_nomb AS cliente,a.fecha,a.hora,a.destino,a.destino AS sopo,a.codvig,'' AS Cajas, Tipo=case when c.Orden is null then 'NORMAL' else 'LOCAL' end FROM pedidos_ficha a with(nolock) inner join clientes b with(nolock) on(b.cli_rut=a.cliente) left outer join(select distinct Orden from Pedidos_Local with(nolock)) c on(a.Orden=c.Orden) WHERE a.terminado <>'0' AND a.codvig='0' ORDER BY a.orden DESC"
            'Dim sql As String = "SELECT DISTINCT TOP(10) a.pedido,a.Orden,a.cliente+' '+b.cli_nomb AS cliente,a.fecha,a.hora,a.destino,a.destino AS sopo,a.codvig,'' AS Cajas, Tipo=case when c.Orden is null then 'NORMAL' else 'LOCAL' end,Tipo_Carga=isnull(a.ped_carga,''),Tipo_Exportacion=isnull(e.Tipo,'Nacional'),Nro_Sol_Sag=isnull(d.Nro_Sol_SAG,''),Etiquetado_Adicional=case when isnull(d.Etiquetado_Adicional,0)=0 then 'No' else 'Si' end FROM pedidos_ficha a with(nolock) inner join clientes b with(nolock) on(b.cli_rut=a.cliente) left outer join(select distinct Orden from Pedidos_Local with(nolock)) c on(a.Orden=c.Orden) left outer join Pedidos_Tipo_Exportacion_Creados d with(nolock) on(a.Orden=d.Orden_Pedido) left outer join Pedidos_Tipo_Exportacion e with(nolock) on(d.ID_Tipo_Exportacion=e.ID) WHERE a.terminado <>'0' AND a.codvig='0' ORDER BY a.orden DESC"
            'Dim sql As String = "SELECT DISTINCT TOP(10) a.pedido,a.Orden,a.cliente+' '+b.cli_nomb AS cliente,a.fecha,a.hora,a.destino,a.destino AS sopo,a.codvig,'' AS Cajas, Tipo=case when c.Orden is null then 'NORMAL' else 'LOCAL' end,Tipo_Carga=isnull(a.ped_carga,''),Tipo_Exportacion=isnull(e.Tipo,'Nacional'),Nro_Sol_Sag=isnull(d.Nro_Sol_SAG,''),Etiquetado_Adicional=case when isnull(d.Etiquetado_Adicional,0)=0 then 'No' else 'Si' end,Fecha_Frm=convert(date,a.fecha) FROM pedidos_ficha a with(nolock) inner join clientes b with(nolock) on(b.cli_rut=a.cliente) left outer join(select distinct Orden from Pedidos_Local with(nolock)) c on(a.Orden=c.Orden) left outer join Pedidos_Tipo_Exportacion_Creados d with(nolock) on(a.Orden=d.Orden_Pedido) left outer join Pedidos_Tipo_Exportacion e with(nolock) on(d.ID_Tipo_Exportacion=e.ID) WHERE a.terminado <>'0' AND a.codvig='0' order by convert(date,a.fecha) desc,a.hora asc"
            Dim sql As String = "SELECT DISTINCT TOP(10) a.pedido,a.Orden,b.cli_nomb AS cliente,a.fecha,a.hora,a.destino,a.destino AS sopo,a.codvig,'' AS Cajas, Tipo=case when c.Orden is null then 'NORMAL' else 'LOCAL' end,Tipo_Carga=isnull(a.ped_carga,''),Tipo_Exportacion=isnull(e.Tipo,'Nacional'),Nro_Sol_Sag=isnull(d.Nro_Sol_SAG,''),Etiquetado_Adicional=case when isnull(d.Etiquetado_Adicional,0)=0 then 'No' else 'Si' end,Fecha_Frm=convert(date,a.fecha),Kilos=f.kilos FROM pedidos_ficha a with(nolock) inner join clientes b with(nolock) on(b.cli_rut=a.cliente) left outer join(select distinct Orden from Pedidos_Local with(nolock)) c on(a.Orden=c.Orden) left outer join Pedidos_Tipo_Exportacion_Creados d with(nolock) on(a.Orden=d.Orden_Pedido) left outer join Pedidos_Tipo_Exportacion e with(nolock) on(d.ID_Tipo_Exportacion=e.ID) inner join (select a.pedido,kilos=round(sum(a.kilos),0) from Pedidos_detalle a with(nolock) group by a.pedido) f on(a.pedido=f.pedido) WHERE a.terminado <>'0' AND a.codvig='0' order by convert(date,a.fecha) desc,a.hora asc"

            Dim Data As DataTable = fnc.ListarTablasSQL(sql)

            For i As Integer = 0 To Data.Rows.Count - 1
                Dim sqlDetsPed As String = "select distinct a.pallet,Cajas=SUM(isnull(Cajas,0)),Cajas_Marcadas=case when a.est='0' then sum(isnull(b.Cajas_Marcadas,0)) else a.cajas end from pedidos_detalle a with(nolock) left outer join(select d.Pedido,c.Pallet,Cajas_Marcadas=sum(isnull(c.Cajas_Marcadas,0)) from Pedidos_Local c with(nolock) inner join Pedidos_Ficha d with(nolock) on(c.Orden=d.Orden) where d.pedido='" + Data.Rows(i)(0).ToString() + "' group by d.Pedido,c.Pallet) b on(a.pallet=b.Pallet) WHERE a.pedido='" + Data.Rows(i)(0).ToString() + "' group by a.pallet,a.est,a.cajas"
                Dim dtDetsPed As DataTable = fnc.ListarTablasSQL(sqlDetsPed)

                Dim CantPalls As Integer = 0
                Dim CantPallsMarcs As Integer = 0
                Dim CantCajs As Integer = 0
                Dim CantCajsMarcs As Integer = 0

                If (dtDetsPed.Rows.Count > 0) Then
                    For j = 0 To dtDetsPed.Rows.Count - 1
                        CantPalls += 1
                        CantCajs += CInt(dtDetsPed.Rows(j).Item(1).ToString.Trim)
                        CantCajsMarcs += CInt(dtDetsPed.Rows(j).Item(2).ToString.Trim)

                        If (CInt(dtDetsPed.Rows(j).Item(1).ToString.Trim) = CInt(dtDetsPed.Rows(j).Item(2).ToString.Trim)) Then
                            CantPallsMarcs += 1
                        End If
                    Next
                End If

                Data.Rows(i)(6) = (CStr(CantPallsMarcs) & " / " & CStr(CantPalls)).ToString()
                Data.Rows(i)(8) = (CStr(CantCajsMarcs) & " / " & CStr(CantCajs)).ToString()

                'Dim sqlTotal As String = "SELECT COUNT(*) FROM pedidos_detalle WHERE pedido='" + Data.Rows(i)(0).ToString() + "'"
                'Dim tablatotal As DataTable = fnc.ListarTablasSQL(sqlTotal)

                'Dim sqlTotal2 As String = "SELECT COUNT(*) FROM pedidos_detalle WHERE pedido='" + Data.Rows(i)(0).ToString() + "' AND est='1'"
                'Dim tablatotal2 As DataTable = fnc.ListarTablasSQL(sqlTotal2)

                'If tablatotal.Rows.Count > 0 AndAlso tablatotal2.Rows.Count > 0 Then
                '    Dim todos As String = tablatotal.Rows(0)(0).ToString()
                '    Dim de As String = tablatotal2.Rows(0)(0).ToString()
                '    Data.Rows(i)(6) = (de + " / " + todos).ToString()
                'End If
            Next
            'Fin modificacion HAmestica 071218. Actualizacion Pedidos Locales

            DgvPedidos.DataSource = Data

            For i = 0 To DgvPedidos.Rows.Count - 1
                If Convert.ToInt16(DgvPedidos.Rows(i).Cells(11).Value.ToString()) = 1 Then
                    DgvPedidos.Rows(i).DefaultCellStyle.ForeColor = Color.Red
                End If
            Next

        ElseIf cbtipo.SelectedValue.ToString() = "3" Then
            Timer1.Stop()

            lblbus.Visible = True
            txtbus.Visible = True

            'Modificacion HAmestica 071218. Actualizacion Pedidos Locales

            'Dim sql As String = "SELECT TOP(100) pedido, Orden, cliente+ '  '+ cli_nomb AS cliente, fecha, hora, destino, destino AS sopo, codvig " +
            '                  "FROM pedidos_ficha, clientes " +
            '                  "WHERE cli_rut=cliente AND codvig='0' ORDER BY orden DESC"

            'Dim sql As String = "SELECT TOP(100) a.pedido,a.Orden,a.cliente+' '+b.cli_nomb AS cliente,a.fecha,a.hora,a.destino,a.destino AS sopo,a.codvig,'' AS Cajas,Tipo=case when c.Orden is null then 'NORMAL' else 'LOCAL' end FROM pedidos_ficha a with(nolock) inner join clientes b with(nolock) on(b.cli_rut=a.cliente) left outer join(select distinct Orden from Pedidos_Local with(nolock)) c on(a.Orden=c.Orden) WHERE a.codvig='0' ORDER BY a.orden DESC"
            'Dim sql As String = "SELECT DISTINCT TOP(100) a.pedido,a.Orden,a.cliente+' '+b.cli_nomb AS cliente,a.fecha,a.hora,a.destino,a.destino AS sopo,a.codvig,'' AS Cajas,Tipo=case when c.Orden is null then 'NORMAL' else 'LOCAL' end,Tipo_Carga=isnull(a.ped_carga,''),Tipo_Exportacion=isnull(e.Tipo,'Nacional'),Nro_Sol_Sag=isnull(d.Nro_Sol_SAG,''),Etiquetado_Adicional=case when isnull(d.Etiquetado_Adicional,0)=0 then 'No' else 'Si' end FROM pedidos_ficha a with(nolock) inner join clientes b with(nolock) on(b.cli_rut=a.cliente) left outer join(select distinct Orden from Pedidos_Local with(nolock)) c on(a.Orden=c.Orden) left outer join Pedidos_Tipo_Exportacion_Creados d with(nolock) on(a.Orden=d.Orden_Pedido) left outer join Pedidos_Tipo_Exportacion e with(nolock) on(d.ID_Tipo_Exportacion=e.ID) WHERE a.codvig='0' ORDER BY a.orden DESC"
            'Dim sql As String = "SELECT DISTINCT TOP(100) a.pedido,a.Orden,a.cliente+' '+b.cli_nomb AS cliente,a.fecha,a.hora,a.destino,a.destino AS sopo,a.codvig,'' AS Cajas,Tipo=case when c.Orden is null then 'NORMAL' else 'LOCAL' end,Tipo_Carga=isnull(a.ped_carga,''),Tipo_Exportacion=isnull(e.Tipo,'Nacional'),Nro_Sol_Sag=isnull(d.Nro_Sol_SAG,''),Etiquetado_Adicional=case when isnull(d.Etiquetado_Adicional,0)=0 then 'No' else 'Si' end,Fecha_Frm=convert(date,a.fecha) FROM pedidos_ficha a with(nolock) inner join clientes b with(nolock) on(b.cli_rut=a.cliente) left outer join(select distinct Orden from Pedidos_Local with(nolock)) c on(a.Orden=c.Orden) left outer join Pedidos_Tipo_Exportacion_Creados d with(nolock) on(a.Orden=d.Orden_Pedido) left outer join Pedidos_Tipo_Exportacion e with(nolock) on(d.ID_Tipo_Exportacion=e.ID) WHERE a.codvig='0' order by convert(date,a.fecha) desc,a.hora asc"
            Dim sql As String = "SELECT DISTINCT TOP(100) a.pedido,a.Orden,b.cli_nomb AS cliente,a.fecha,a.hora,a.destino,a.destino AS sopo,a.codvig,'' AS Cajas,Tipo=case when c.Orden is null then 'NORMAL' else 'LOCAL' end,Tipo_Carga=isnull(a.ped_carga,''),Tipo_Exportacion=isnull(e.Tipo,'Nacional'),Nro_Sol_Sag=isnull(d.Nro_Sol_SAG,''),Etiquetado_Adicional=case when isnull(d.Etiquetado_Adicional,0)=0 then 'No' else 'Si' end,Fecha_Frm=convert(date,a.fecha),Kilos=f.kilos FROM pedidos_ficha a with(nolock) inner join clientes b with(nolock) on(b.cli_rut=a.cliente) left outer join(select distinct Orden from Pedidos_Local with(nolock)) c on(a.Orden=c.Orden) left outer join Pedidos_Tipo_Exportacion_Creados d with(nolock) on(a.Orden=d.Orden_Pedido) left outer join Pedidos_Tipo_Exportacion e with(nolock) on(d.ID_Tipo_Exportacion=e.ID) inner join (select a.pedido,kilos=round(sum(a.kilos),0) from Pedidos_detalle a with(nolock) group by a.pedido) f on(a.pedido=f.pedido) WHERE a.codvig='0' order by convert(date,a.fecha) desc,a.hora asc"

            Dim Data As DataTable = fnc.ListarTablasSQL(sql)

            For i As Integer = 0 To Data.Rows.Count - 1
                Dim sqlDetsPed As String = "select distinct a.pallet,Cajas=SUM(isnull(Cajas,0)),Cajas_Marcadas=case when a.est='0' then sum(isnull(b.Cajas_Marcadas,0)) else a.cajas end from pedidos_detalle a with(nolock) left outer join(select d.Pedido,c.Pallet,Cajas_Marcadas=sum(isnull(c.Cajas_Marcadas,0)) from Pedidos_Local c with(nolock) inner join Pedidos_Ficha d with(nolock) on(c.Orden=d.Orden) where d.pedido='" + Data.Rows(i)(0).ToString() + "' group by d.Pedido,c.Pallet) b on(a.pallet=b.Pallet) WHERE a.pedido='" + Data.Rows(i)(0).ToString() + "' group by a.pallet,a.est,a.cajas"
                Dim dtDetsPed As DataTable = fnc.ListarTablasSQL(sqlDetsPed)

                Dim CantPalls As Integer = 0
                Dim CantPallsMarcs As Integer = 0
                Dim CantCajs As Integer = 0
                Dim CantCajsMarcs As Integer = 0

                If (dtDetsPed.Rows.Count > 0) Then
                    For j = 0 To dtDetsPed.Rows.Count - 1
                        CantPalls += 1
                        CantCajs += CInt(dtDetsPed.Rows(j).Item(1).ToString.Trim)
                        CantCajsMarcs += CInt(dtDetsPed.Rows(j).Item(2).ToString.Trim)

                        If (CInt(dtDetsPed.Rows(j).Item(1).ToString.Trim) = CInt(dtDetsPed.Rows(j).Item(2).ToString.Trim)) Then
                            CantPallsMarcs += 1
                        End If
                    Next
                End If

                Data.Rows(i)(6) = (CStr(CantPallsMarcs) & " / " & CStr(CantPalls)).ToString()
                Data.Rows(i)(8) = (CStr(CantCajsMarcs) & " / " & CStr(CantCajs)).ToString()

                'Dim sqlTotal As String = "SELECT COUNT(*) FROM pedidos_detalle WHERE pedido='" + Data.Rows(i)(0).ToString() + "'"
                'Dim tablatotal As DataTable = fnc.ListarTablasSQL(sqlTotal)

                'Dim sqlTotal2 As String = "SELECT COUNT(*) FROM pedidos_detalle WHERE pedido='" + Data.Rows(i)(0).ToString() + "' AND est='1'"
                'Dim tablatotal2 As DataTable = fnc.ListarTablasSQL(sqlTotal2)

                'If tablatotal.Rows.Count > 0 AndAlso tablatotal2.Rows.Count > 0 Then
                '    Dim todos As String = tablatotal.Rows(0)(0).ToString()
                '    Dim de As String = tablatotal2.Rows(0)(0).ToString()
                '    Data.Rows(i)(6) = (de + " / " + todos).ToString()
                'End If
            Next
            'Fin modificacion HAmestica 071218. Actualizacion Pedidos Locales

            DgvPedidos.DataSource = Data

            For i = 0 To DgvPedidos.Rows.Count - 1
                If Convert.ToInt16(DgvPedidos.Rows(i).Cells(11).Value.ToString()) = 1 Then
                    DgvPedidos.Rows(i).DefaultCellStyle.ForeColor = Color.Red
                End If
            Next

        End If


    End Sub

    Private Sub cbtipo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbtipo.KeyPress
        e.Handled = True
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim frm As Frm_UnirPedidos = New Frm_UnirPedidos

        frm.ShowDialog()
    End Sub

    Private Sub txtbus_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtbus.TextChanged
        'Modificacion HAmestica 071218. Actualizacion Pedidos Locales

        'Dim sql As String = "SELECT TOP(100) pedido, Orden, cliente+ '  '+ cli_nomb AS cliente, fecha, hora, destino, destino AS sopo, codvig " +
        '                  "FROM pedidos_ficha, clientes " +
        '                  "WHERE cli_rut=cliente AND codvig='0' and  orden LIKE '" + txtbus.Text + "%'  ORDER BY orden DESC"

        'Dim sql As String = "SELECT TOP(100) a.pedido,a.Orden,a.cliente+' '+b.cli_nomb AS cliente,a.fecha,a.hora,a.destino,a.destino AS sopo,a.codvig,'' AS Cajas,Tipo=case when c.Orden is null then 'NORMAL' else 'LOCAL' end FROM pedidos_ficha a with(nolock) inner join clientes b with(nolock) on(b.cli_rut=a.cliente) left outer join(select distinct Orden from Pedidos_Local with(nolock)) c on(a.Orden=c.Orden) WHERE a.codvig='0' and a.Orden like '" & txtbus.Text.Trim & "%' ORDER BY a.orden DESC"
        'Dim sql As String = "SELECT DISTINCT TOP(100) a.pedido,a.Orden,a.cliente+' '+b.cli_nomb AS cliente,a.fecha,a.hora,a.destino,a.destino AS sopo,a.codvig,'' AS Cajas,Tipo=case when c.Orden is null then 'NORMAL' else 'LOCAL' end,Tipo_Carga=isnull(a.ped_carga,''),Tipo_Exportacion=isnull(e.Tipo,'Nacional'),Nro_Sol_Sag=isnull(d.Nro_Sol_SAG,''),Etiquetado_Adicional=case when isnull(d.Etiquetado_Adicional,0)=0 then 'No' else 'Si' end FROM pedidos_ficha a with(nolock) inner join clientes b with(nolock) on(b.cli_rut=a.cliente) left outer join(select distinct Orden from Pedidos_Local with(nolock)) c on(a.Orden=c.Orden) left outer join Pedidos_Tipo_Exportacion_Creados d with(nolock) on(a.Orden=d.Orden_Pedido) left outer join Pedidos_Tipo_Exportacion e with(nolock) on(d.ID_Tipo_Exportacion=e.ID) WHERE a.codvig='0' and a.Orden like '" & txtbus.Text.Trim & "%' ORDER BY a.orden DESC"
        'Dim sql As String = "SELECT DISTINCT TOP(100) a.pedido,a.Orden,a.cliente+' '+b.cli_nomb AS cliente,a.fecha,a.hora,a.destino,a.destino AS sopo,a.codvig,'' AS Cajas,Tipo=case when c.Orden is null then 'NORMAL' else 'LOCAL' end,Tipo_Carga=isnull(a.ped_carga,''),Tipo_Exportacion=isnull(e.Tipo,'Nacional'),Nro_Sol_Sag=isnull(d.Nro_Sol_SAG,''),Etiquetado_Adicional=case when isnull(d.Etiquetado_Adicional,0)=0 then 'No' else 'Si' end,Fecha_Frm=convert(date,a.fecha) FROM pedidos_ficha a with(nolock) inner join clientes b with(nolock) on(b.cli_rut=a.cliente) left outer join(select distinct Orden from Pedidos_Local with(nolock)) c on(a.Orden=c.Orden) left outer join Pedidos_Tipo_Exportacion_Creados d with(nolock) on(a.Orden=d.Orden_Pedido) left outer join Pedidos_Tipo_Exportacion e with(nolock) on(d.ID_Tipo_Exportacion=e.ID) WHERE a.codvig='0' and a.Orden like '" & txtbus.Text.Trim & "%' order by convert(date,a.fecha) desc,a.hora asc"
        Dim sql As String = "SELECT DISTINCT TOP(100) a.pedido,a.Orden,b.cli_nomb AS cliente,a.fecha,a.hora,a.destino,a.destino AS sopo,a.codvig,'' AS Cajas,Tipo=case when c.Orden is null then 'NORMAL' else 'LOCAL' end,Tipo_Carga=isnull(a.ped_carga,''),Tipo_Exportacion=isnull(e.Tipo,'Nacional'),Nro_Sol_Sag=isnull(d.Nro_Sol_SAG,''),Etiquetado_Adicional=case when isnull(d.Etiquetado_Adicional,0)=0 then 'No' else 'Si' end,Fecha_Frm=convert(date,a.fecha),Kilos=f.kilos FROM pedidos_ficha a with(nolock) inner join clientes b with(nolock) on(b.cli_rut=a.cliente) left outer join(select distinct Orden from Pedidos_Local with(nolock)) c on(a.Orden=c.Orden) left outer join Pedidos_Tipo_Exportacion_Creados d with(nolock) on(a.Orden=d.Orden_Pedido) left outer join Pedidos_Tipo_Exportacion e with(nolock) on(d.ID_Tipo_Exportacion=e.ID) inner join (select a.pedido,kilos=round(sum(a.kilos),0) from Pedidos_detalle a with(nolock) group by a.pedido) f on(a.pedido=f.pedido) WHERE a.codvig='0' and a.Orden like '" & txtbus.Text.Trim & "%' order by convert(date,a.fecha) desc,a.hora asc"

        Dim Data As DataTable = fnc.ListarTablasSQL(sql)

        For i As Integer = 0 To Data.Rows.Count - 1
            Dim sqlDetsPed As String = "select distinct a.pallet,Cajas=SUM(isnull(Cajas,0)),Cajas_Marcadas=case when a.est='0' then sum(isnull(b.Cajas_Marcadas,0)) else a.cajas end from pedidos_detalle a with(nolock) left outer join(select d.Pedido,c.Pallet,Cajas_Marcadas=sum(isnull(c.Cajas_Marcadas,0)) from Pedidos_Local c with(nolock) inner join Pedidos_Ficha d with(nolock) on(c.Orden=d.Orden) where d.pedido='" + Data.Rows(i)(0).ToString() + "' group by d.Pedido,c.Pallet) b on(a.pallet=b.Pallet) WHERE a.pedido='" + Data.Rows(i)(0).ToString() + "' group by a.pallet,a.est,a.cajas"
            Dim dtDetsPed As DataTable = fnc.ListarTablasSQL(sqlDetsPed)

            Dim CantPalls As Integer = 0
            Dim CantPallsMarcs As Integer = 0
            Dim CantCajs As Integer = 0
            Dim CantCajsMarcs As Integer = 0

            If (dtDetsPed.Rows.Count > 0) Then
                For j = 0 To dtDetsPed.Rows.Count - 1
                    CantPalls += 1
                    CantCajs += CInt(dtDetsPed.Rows(j).Item(1).ToString.Trim)
                    CantCajsMarcs += CInt(dtDetsPed.Rows(j).Item(2).ToString.Trim)

                    If (CInt(dtDetsPed.Rows(j).Item(1).ToString.Trim) = CInt(dtDetsPed.Rows(j).Item(2).ToString.Trim)) Then
                        CantPallsMarcs += 1
                    End If
                Next
            End If

            Data.Rows(i)(6) = (CStr(CantPallsMarcs) & " / " & CStr(CantPalls)).ToString()
            Data.Rows(i)(8) = (CStr(CantCajsMarcs) & " / " & CStr(CantCajs)).ToString()

            'Dim sqlTotal As String = "SELECT COUNT(*) FROM pedidos_detalle WHERE pedido='" + Data.Rows(i)(0).ToString() + "'"
            'Dim tablatotal As DataTable = fnc.ListarTablasSQL(sqlTotal)

            'Dim sqlTotal2 As String = "SELECT COUNT(*) FROM pedidos_detalle WHERE pedido='" + Data.Rows(i)(0).ToString() + "' AND est='1'"
            'Dim tablatotal2 As DataTable = fnc.ListarTablasSQL(sqlTotal2)

            'If tablatotal.Rows.Count > 0 AndAlso tablatotal2.Rows.Count > 0 Then
            '    Dim todos As String = tablatotal.Rows(0)(0).ToString()
            '    Dim de As String = tablatotal2.Rows(0)(0).ToString()
            '    Data.Rows(i)(6) = (de + " / " + todos).ToString()
            'End If
        Next
        'Fin modificacion HAmestica 071218. Actualizacion Pedidos Locales

        DgvPedidos.DataSource = Data

        For i = 0 To DgvPedidos.Rows.Count - 1
            If Convert.ToInt16(DgvPedidos.Rows(i).Cells(11).Value.ToString()) = 1 Then
                DgvPedidos.Rows(i).DefaultCellStyle.ForeColor = Color.Red
            End If
        Next


    End Sub

    Private Sub btnXls_Click(sender As System.Object, e As System.EventArgs) Handles btnXls.Click
        Try
            Dim dtSel As New DataTable
            dtSel.Columns.Add("Orden")
            dtSel.Columns.Add("Cliente")
            dtSel.Columns.Add("Fecha")
            dtSel.Columns.Add("Hora")
            dtSel.Columns.Add("Destino")
            dtSel.Columns.Add("Sopo._Str")
            dtSel.Columns.Add("Cajas_Str")
            dtSel.Columns.Add("Kilos_Str")
            dtSel.Columns.Add("Carga")
            dtSel.Columns.Add("Exp._Str")
            dtSel.Columns.Add("Sol._SAG_Str")
            dtSel.Columns.Add("Etiq._Adi.")
            Dim PedSel As Boolean = False
            Dim Resp As MsgBoxResult = MsgBox("¿Exportar SOLO Pedidos seleccionados? (No: Exporta todos los Pedidos)", MsgBoxStyle.YesNoCancel, "Pregunta")
            If (Resp = MsgBoxResult.Yes) Then
                PedSel = True
            ElseIf (Resp = MsgBoxResult.Cancel) Then
                Exit Sub
            End If

            For i = 0 To DgvPedidos.RowCount - 1
                If ((PedSel And DgvPedidos.Rows(i).Selected) Or Not PedSel) Then
                    Dim row As DataRow = dtSel.NewRow
                    row(0) = DgvPedidos.Rows(i).Cells("Orden").Value.ToString.Trim
                    row(1) = DgvPedidos.Rows(i).Cells("Cliente").Value.ToString.Trim
                    row(2) = DgvPedidos.Rows(i).Cells("Fecha").Value.ToString.Trim
                    row(3) = DgvPedidos.Rows(i).Cells("Hora").Value.ToString.Trim
                    row(4) = DgvPedidos.Rows(i).Cells("Destino").Value.ToString.Trim
                    row(5) = DgvPedidos.Rows(i).Cells("sopo").Value.ToString.Trim
                    row(6) = DgvPedidos.Rows(i).Cells("Cajas").Value.ToString.Trim
                    row(7) = DgvPedidos.Rows(i).Cells("Kilos").Value.ToString.Trim
                    row(8) = DgvPedidos.Rows(i).Cells("Tipo_Carga").Value.ToString.Trim
                    row(9) = DgvPedidos.Rows(i).Cells("Exportacion").Value.ToString.Trim
                    row(10) = DgvPedidos.Rows(i).Cells("Nro_Sol_Sag").Value.ToString.Trim
                    row(11) = DgvPedidos.Rows(i).Cells("Etiq_Adi").Value.ToString.Trim

                    dtSel.Rows.Add(row)
                End If
            Next

            If (dtSel.Rows.Count > 0) Then
                fnc.dtToExcel(dtSel)
            Else
                MsgBox("Debe seleccionar los Pedidos que desea exportar a Excel (Ctrl + Click).", MsgBoxStyle.Critical, "Aviso")
            End If
        Catch ex As Exception
            MsgBox("Ocurrió un error al exportal Listado de Pedidos a Excel.", MsgBoxStyle.Critical, "Aviso")
        End Try
    End Sub

    Sub ordenarGrilla()
        Try
            DgvPedidos.Columns("Codigo").DisplayIndex = 1
            DgvPedidos.Columns("Orden").DisplayIndex = 2
            DgvPedidos.Columns("Cliente").DisplayIndex = 3
            DgvPedidos.Columns("Fecha").DisplayIndex = 4
            DgvPedidos.Columns("Hora").DisplayIndex = 5
            DgvPedidos.Columns("Destino").DisplayIndex = 6
            DgvPedidos.Columns("Sopo").DisplayIndex = 7
            DgvPedidos.Columns("Cajas").DisplayIndex = 8
            DgvPedidos.Columns("Kilos").DisplayIndex = 9
            DgvPedidos.Columns("detalle").DisplayIndex = 10
            DgvPedidos.Columns("ELIM").DisplayIndex = 11
            DgvPedidos.Columns("PRINT").DisplayIndex = 12
            DgvPedidos.Columns("SALDOS").DisplayIndex = 13
            DgvPedidos.Columns("Est").DisplayIndex = 14
            DgvPedidos.Columns("Exportacion").DisplayIndex = 15
            DgvPedidos.Columns("Nro_Sol_Sag").DisplayIndex = 16
            DgvPedidos.Columns("Etiq_Adi").DisplayIndex = 17
            DgvPedidos.Columns("Fecha_Frm").DisplayIndex = 18
            DgvPedidos.Columns("Tipo_Carga").DisplayIndex = 19
            DgvPedidos.Columns("Tipo").DisplayIndex = 20
        Catch ex As Exception

        End Try
    End Sub
End Class
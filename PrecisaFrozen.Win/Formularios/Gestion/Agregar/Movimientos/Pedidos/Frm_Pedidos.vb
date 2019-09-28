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

        Timer1.Start()
        'carga_pedidos()
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

                fnc.MovimientoSQL("INSERT INTO LOG_PEDIDOSELIMINADOS (LEM_CODI, LEM_FECHA, LEM_HORA, LEM_USU, LEM_PC, LEM_TIPO)" +
                                  "VALUES('" + NPEDIDO + "','" + devuelve_fecha_Formato2(fnc.DevuelveFechaServidor()) + "','" + DevuelveHora() + "'," +
                                  "'" + Frm_Principal.InfoUsuario.Text + "','" + My.Computer.Name.ToString() + "','SI')")
                fnc.MovimientoSQL("DELETE FROM Pedido_Est WHERE pedido ='" + Me.DgvPedidos.Rows(e.RowIndex).Cells(5).Value.ToString() + "'")
                Dim sqll As String = ("DELETE FROM Pedido_Est WHERE pedido ='" + Me.DgvPedidos.Rows(e.RowIndex).Cells(5).Value.ToString() + "'")
                MsgBox("Pedido anulado correctamente", MsgBoxStyle.Information, "Aviso")
                cargarDatos()
            Catch ex As Exception
                MsgBox(ex.Message())
            End Try

        ElseIf e.RowIndex > -1 AndAlso e.ColumnIndex = 2 Then
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

            Dim sql As String = "select a.pedido,a.Orden,a.cliente+' '+b.cli_nomb AS cliente,a.fecha,a.hora,destino=isnull(a.destino,''),sopo=isnull(a.destino,''),a.codvig,'' AS Cajas,Tipo=case when c.Orden is null then 'NORMAL' else 'LOCAL' end from pedidos_ficha a with(nolock) inner join clientes b with(nolock) on(b.cli_rut=a.cliente) left outer join(select distinct Orden from Pedidos_Local with(nolock)) c on(a.Orden=c.Orden) where a.terminado <>'3' AND a.Ped_estpred<>'3' AND a.codvig='0' AND a.Orden not in(select fpre_nped from fichpred) order by a.orden desc"

            Dim Data As DataTable = fnc.ListarTablasSQL(sql)

            For i As Integer = 0 To Data.Rows.Count - 1
                Dim sqlDetsPed As String = "select a.pallet,Cajas=SUM(isnull(Cajas,0)),Cajas_Marcadas=case when a.est='0' then sum(isnull(b.Cajas_Marcadas,0)) else a.cajas end from pedidos_detalle a with(nolock) left outer join(select d.Pedido,c.Pallet,Cajas_Marcadas=sum(isnull(c.Cajas_Marcadas,0)) from Pedidos_Local c with(nolock) inner join Pedidos_Ficha d with(nolock) on(c.Orden=d.Orden) where d.pedido='" + Data.Rows(i)(0).ToString() + "' group by d.Pedido,c.Pallet) b on(a.pallet=b.Pallet) WHERE a.pedido='" + Data.Rows(i)(0).ToString() + "' group by a.pallet,a.est,a.cajas"
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
            Dim sql As String = "SELECT TOP(10) a.pedido,a.Orden,a.cliente+' '+b.cli_nomb AS cliente,a.fecha,a.hora,a.destino,a.destino AS sopo,a.codvig,'' AS Cajas, Tipo=case when c.Orden is null then 'NORMAL' else 'LOCAL' end FROM pedidos_ficha a with(nolock) inner join clientes b with(nolock) on(b.cli_rut=a.cliente) left outer join(select distinct Orden from Pedidos_Local with(nolock)) c on(a.Orden=c.Orden) WHERE a.terminado <>'0' AND a.codvig='0' ORDER BY a.orden DESC"

            Dim Data As DataTable = fnc.ListarTablasSQL(sql)

            For i As Integer = 0 To Data.Rows.Count - 1
                Dim sqlDetsPed As String = "select a.pallet,Cajas=SUM(isnull(Cajas,0)),Cajas_Marcadas=case when a.est='0' then sum(isnull(b.Cajas_Marcadas,0)) else a.cajas end from pedidos_detalle a with(nolock) left outer join(select d.Pedido,c.Pallet,Cajas_Marcadas=sum(isnull(c.Cajas_Marcadas,0)) from Pedidos_Local c with(nolock) inner join Pedidos_Ficha d with(nolock) on(c.Orden=d.Orden) where d.pedido='" + Data.Rows(i)(0).ToString() + "' group by d.Pedido,c.Pallet) b on(a.pallet=b.Pallet) WHERE a.pedido='" + Data.Rows(i)(0).ToString() + "' group by a.pallet,a.est,a.cajas"
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
            Dim sql As String = "SELECT TOP(100) a.pedido,a.Orden,a.cliente+' '+b.cli_nomb AS cliente,a.fecha,a.hora,a.destino,a.destino AS sopo,a.codvig,'' AS Cajas,Tipo=case when c.Orden is null then 'NORMAL' else 'LOCAL' end FROM pedidos_ficha a with(nolock) inner join clientes b with(nolock) on(b.cli_rut=a.cliente) left outer join(select distinct Orden from Pedidos_Local with(nolock)) c on(a.Orden=c.Orden) WHERE a.codvig='0' ORDER BY a.orden DESC"

            Dim Data As DataTable = fnc.ListarTablasSQL(sql)

            For i As Integer = 0 To Data.Rows.Count - 1
                Dim sqlDetsPed As String = "select a.pallet,Cajas=SUM(isnull(Cajas,0)),Cajas_Marcadas=case when a.est='0' then sum(isnull(b.Cajas_Marcadas,0)) else a.cajas end from pedidos_detalle a with(nolock) left outer join(select d.Pedido,c.Pallet,Cajas_Marcadas=sum(isnull(c.Cajas_Marcadas,0)) from Pedidos_Local c with(nolock) inner join Pedidos_Ficha d with(nolock) on(c.Orden=d.Orden) where d.pedido='" + Data.Rows(i)(0).ToString() + "' group by d.Pedido,c.Pallet) b on(a.pallet=b.Pallet) WHERE a.pedido='" + Data.Rows(i)(0).ToString() + "' group by a.pallet,a.est,a.cajas"
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

            Dim sql As String = "select a.pedido,a.Orden,a.cliente+' '+b.cli_nomb AS cliente,a.fecha,a.hora,destino=isnull(a.destino,''),sopo=isnull(a.destino,''),a.codvig,'' AS Cajas,Tipo=case when c.Orden is null then 'NORMAL' else 'LOCAL' end from pedidos_ficha a with(nolock) inner join clientes b with(nolock) on(b.cli_rut=a.cliente) left outer join(select distinct Orden from Pedidos_Local with(nolock)) c on(a.Orden=c.Orden) where a.terminado <>'3' AND a.Ped_estpred<>'3' AND a.codvig='0' AND a.Orden not in(select fpre_nped from fichpred) order by a.orden desc"

            Dim Data As DataTable = fnc.ListarTablasSQL(sql)

            For i As Integer = 0 To Data.Rows.Count - 1
                Dim sqlDetsPed As String = "select a.pallet,Cajas=SUM(isnull(Cajas,0)),Cajas_Marcadas=case when a.est='0' then sum(isnull(b.Cajas_Marcadas,0)) else a.cajas end from pedidos_detalle a with(nolock) left outer join(select d.Pedido,c.Pallet,Cajas_Marcadas=sum(isnull(c.Cajas_Marcadas,0)) from Pedidos_Local c with(nolock) inner join Pedidos_Ficha d with(nolock) on(c.Orden=d.Orden) where d.pedido='" + Data.Rows(i)(0).ToString() + "' group by d.Pedido,c.Pallet) b on(a.pallet=b.Pallet) WHERE a.pedido='" + Data.Rows(i)(0).ToString() + "' group by a.pallet,a.est,a.cajas"
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

            Dim sql As String = "SELECT TOP(10) a.pedido,a.Orden,a.cliente+' '+b.cli_nomb AS cliente,a.fecha,a.hora,a.destino,a.destino AS sopo,a.codvig,'' AS Cajas, Tipo=case when c.Orden is null then 'NORMAL' else 'LOCAL' end FROM pedidos_ficha a with(nolock) inner join clientes b with(nolock) on(b.cli_rut=a.cliente) left outer join(select distinct Orden from Pedidos_Local with(nolock)) c on(a.Orden=c.Orden) WHERE a.terminado <>'0' AND a.codvig='0' ORDER BY a.orden DESC"

            Dim Data As DataTable = fnc.ListarTablasSQL(sql)

            For i As Integer = 0 To Data.Rows.Count - 1
                Dim sqlDetsPed As String = "select a.pallet,Cajas=SUM(isnull(Cajas,0)),Cajas_Marcadas=case when a.est='0' then sum(isnull(b.Cajas_Marcadas,0)) else a.cajas end from pedidos_detalle a with(nolock) left outer join(select d.Pedido,c.Pallet,Cajas_Marcadas=sum(isnull(c.Cajas_Marcadas,0)) from Pedidos_Local c with(nolock) inner join Pedidos_Ficha d with(nolock) on(c.Orden=d.Orden) where d.pedido='" + Data.Rows(i)(0).ToString() + "' group by d.Pedido,c.Pallet) b on(a.pallet=b.Pallet) WHERE a.pedido='" + Data.Rows(i)(0).ToString() + "' group by a.pallet,a.est,a.cajas"
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

            Dim sql As String = "SELECT TOP(100) a.pedido,a.Orden,a.cliente+' '+b.cli_nomb AS cliente,a.fecha,a.hora,a.destino,a.destino AS sopo,a.codvig,'' AS Cajas,Tipo=case when c.Orden is null then 'NORMAL' else 'LOCAL' end FROM pedidos_ficha a with(nolock) inner join clientes b with(nolock) on(b.cli_rut=a.cliente) left outer join(select distinct Orden from Pedidos_Local with(nolock)) c on(a.Orden=c.Orden) WHERE a.codvig='0' ORDER BY a.orden DESC"

            Dim Data As DataTable = fnc.ListarTablasSQL(sql)

            For i As Integer = 0 To Data.Rows.Count - 1
                Dim sqlDetsPed As String = "select a.pallet,Cajas=SUM(isnull(Cajas,0)),Cajas_Marcadas=case when a.est='0' then sum(isnull(b.Cajas_Marcadas,0)) else a.cajas end from pedidos_detalle a with(nolock) left outer join(select d.Pedido,c.Pallet,Cajas_Marcadas=sum(isnull(c.Cajas_Marcadas,0)) from Pedidos_Local c with(nolock) inner join Pedidos_Ficha d with(nolock) on(c.Orden=d.Orden) where d.pedido='" + Data.Rows(i)(0).ToString() + "' group by d.Pedido,c.Pallet) b on(a.pallet=b.Pallet) WHERE a.pedido='" + Data.Rows(i)(0).ToString() + "' group by a.pallet,a.est,a.cajas"
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

            Dim sql As String = "select a.pedido,a.Orden,a.cliente+' '+b.cli_nomb AS cliente,a.fecha,a.hora,destino=isnull(a.destino,''),sopo=isnull(a.destino,''),a.codvig,'' AS Cajas,Tipo=case when c.Orden is null then 'NORMAL' else 'LOCAL' end from pedidos_ficha a with(nolock) inner join clientes b with(nolock) on(b.cli_rut=a.cliente) left outer join(select distinct Orden from Pedidos_Local with(nolock)) c on(a.Orden=c.Orden) where a.terminado <>'3' AND a.Ped_estpred<>'3' AND a.codvig='0' AND a.Orden not in(select fpre_nped from fichpred) order by a.orden desc"

            Dim Data As DataTable = fnc.ListarTablasSQL(sql)

            For i As Integer = 0 To Data.Rows.Count - 1
                Dim sqlDetsPed As String = "select a.pallet,Cajas=SUM(isnull(Cajas,0)),Cajas_Marcadas=case when a.est='0' then sum(isnull(b.Cajas_Marcadas,0)) else a.cajas end from pedidos_detalle a with(nolock) left outer join(select d.Pedido,c.Pallet,Cajas_Marcadas=sum(isnull(c.Cajas_Marcadas,0)) from Pedidos_Local c with(nolock) inner join Pedidos_Ficha d with(nolock) on(c.Orden=d.Orden) where d.pedido='" + Data.Rows(i)(0).ToString() + "' group by d.Pedido,c.Pallet) b on(a.pallet=b.Pallet) WHERE a.pedido='" + Data.Rows(i)(0).ToString() + "' group by a.pallet,a.est,a.cajas"
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

            Dim sql As String = "SELECT TOP(10) a.pedido,a.Orden,a.cliente+' '+b.cli_nomb AS cliente,a.fecha,a.hora,a.destino,a.destino AS sopo,a.codvig,'' AS Cajas, Tipo=case when c.Orden is null then 'NORMAL' else 'LOCAL' end FROM pedidos_ficha a with(nolock) inner join clientes b with(nolock) on(b.cli_rut=a.cliente) left outer join(select distinct Orden from Pedidos_Local with(nolock)) c on(a.Orden=c.Orden) WHERE a.terminado <>'0' AND a.codvig='0' ORDER BY a.orden DESC"

            Dim Data As DataTable = fnc.ListarTablasSQL(sql)

            For i As Integer = 0 To Data.Rows.Count - 1
                Dim sqlDetsPed As String = "select a.pallet,Cajas=SUM(isnull(Cajas,0)),Cajas_Marcadas=case when a.est='0' then sum(isnull(b.Cajas_Marcadas,0)) else a.cajas end from pedidos_detalle a with(nolock) left outer join(select d.Pedido,c.Pallet,Cajas_Marcadas=sum(isnull(c.Cajas_Marcadas,0)) from Pedidos_Local c with(nolock) inner join Pedidos_Ficha d with(nolock) on(c.Orden=d.Orden) where d.pedido='" + Data.Rows(i)(0).ToString() + "' group by d.Pedido,c.Pallet) b on(a.pallet=b.Pallet) WHERE a.pedido='" + Data.Rows(i)(0).ToString() + "' group by a.pallet,a.est,a.cajas"
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

            Dim sql As String = "SELECT TOP(100) a.pedido,a.Orden,a.cliente+' '+b.cli_nomb AS cliente,a.fecha,a.hora,a.destino,a.destino AS sopo,a.codvig,'' AS Cajas,Tipo=case when c.Orden is null then 'NORMAL' else 'LOCAL' end FROM pedidos_ficha a with(nolock) inner join clientes b with(nolock) on(b.cli_rut=a.cliente) left outer join(select distinct Orden from Pedidos_Local with(nolock)) c on(a.Orden=c.Orden) WHERE a.codvig='0' ORDER BY a.orden DESC"

            Dim Data As DataTable = fnc.ListarTablasSQL(sql)

            For i As Integer = 0 To Data.Rows.Count - 1
                Dim sqlDetsPed As String = "select a.pallet,Cajas=SUM(isnull(Cajas,0)),Cajas_Marcadas=case when a.est='0' then sum(isnull(b.Cajas_Marcadas,0)) else a.cajas end from pedidos_detalle a with(nolock) left outer join(select d.Pedido,c.Pallet,Cajas_Marcadas=sum(isnull(c.Cajas_Marcadas,0)) from Pedidos_Local c with(nolock) inner join Pedidos_Ficha d with(nolock) on(c.Orden=d.Orden) where d.pedido='" + Data.Rows(i)(0).ToString() + "' group by d.Pedido,c.Pallet) b on(a.pallet=b.Pallet) WHERE a.pedido='" + Data.Rows(i)(0).ToString() + "' group by a.pallet,a.est,a.cajas"
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

        Dim sql As String = "SELECT TOP(100) a.pedido,a.Orden,a.cliente+' '+b.cli_nomb AS cliente,a.fecha,a.hora,a.destino,a.destino AS sopo,a.codvig,'' AS Cajas,Tipo=case when c.Orden is null then 'NORMAL' else 'LOCAL' end FROM pedidos_ficha a with(nolock) inner join clientes b with(nolock) on(b.cli_rut=a.cliente) left outer join(select distinct Orden from Pedidos_Local with(nolock)) c on(a.Orden=c.Orden) WHERE a.codvig='0' and a.Orden like '" & txtbus.Text.Trim & "%' ORDER BY a.orden DESC"

        Dim Data As DataTable = fnc.ListarTablasSQL(sql)

        For i As Integer = 0 To Data.Rows.Count - 1
            Dim sqlDetsPed As String = "select a.pallet,Cajas=SUM(isnull(Cajas,0)),Cajas_Marcadas=case when a.est='0' then sum(isnull(b.Cajas_Marcadas,0)) else a.cajas end from pedidos_detalle a with(nolock) left outer join(select d.Pedido,c.Pallet,Cajas_Marcadas=sum(isnull(c.Cajas_Marcadas,0)) from Pedidos_Local c with(nolock) inner join Pedidos_Ficha d with(nolock) on(c.Orden=d.Orden) where d.pedido='" + Data.Rows(i)(0).ToString() + "' group by d.Pedido,c.Pallet) b on(a.pallet=b.Pallet) WHERE a.pedido='" + Data.Rows(i)(0).ToString() + "' group by a.pallet,a.est,a.cajas"
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
            dtSel.Columns.Add("Fecha_Carga")
            dtSel.Columns.Add("Hora_Carga")
            dtSel.Columns.Add("Destino")
            dtSel.Columns.Add("Soportantes_Str")
            dtSel.Columns.Add("Cajas_Str")

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
End Class
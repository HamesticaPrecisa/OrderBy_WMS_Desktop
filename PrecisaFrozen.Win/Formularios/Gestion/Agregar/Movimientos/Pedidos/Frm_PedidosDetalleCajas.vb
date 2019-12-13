Imports System.Data.SqlClient
Imports System.Data


Public Class Frm_PedidosDetalleCajas

    Public qry As String = ""
    Public codped As Integer = 0
    Public val_cliente As String = ""
    Public val_pallet As String = ""
    Public _modificar = False

    Dim fnc As New Funciones
    Dim con As New Conexion


    Public Sub Verifica()

        If _modificar = True Then
            BtnAgregar.Enabled = True
            BtnCambiar.Enabled = True
            BtnEliminar.Enabled = True
            TxtCodCaja.Enabled = True
        Else
            BtnAgregar.Enabled = False
            BtnCambiar.Enabled = False
            BtnEliminar.Enabled = False
            TxtCodCaja.Enabled = False
        End If

    End Sub

    Private Sub Frm_PedidosDetalleCajas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DgvCaja.DataSource = fnc.ListarTablasSQL(qry)
        txtsopo.Text = DgvCaja.Rows.Count.ToString()
        tpedido.Text = codped
        txtpallet_1.Text = val_pallet

        'cargo cajas disponibles

        Dim sql_disponibles As String = "SELECT 0 op, caj_cod FROM detarececajas WHERE caj_pcod='" + txtpallet_1.Text + "' AND caj_ped='0'"
        Dim dt As DataTable = fnc.ListarTablasSQL(sql_disponibles)

        If dt.Rows.Count > 0 Then
            DgvCajasadd.DataSource = dt
        Else
            Verifica()
            BtnAgregar.Enabled = False
        End If
        Verifica()
    End Sub

    Private Sub DgvCaja_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvCaja.CellClick
        If _modificar = True Then
            If DgvCaja.Rows(DgvCaja.CurrentRow.Index).Cells(1).Value.ToString() <> DgvCaja.Rows(DgvCaja.CurrentRow.Index).Cells(2).Value.ToString() Then
                tcaja.Text = DgvCaja.Rows(DgvCaja.CurrentRow.Index).Cells(1).Value.ToString()
                TxtCodCaja.Text = ""
                TxtCodCaja.Enabled = True
                TxtCodCaja.Focus()
            Else
                tcaja.Text = ""
            End If
        End If
    End Sub

    Private Sub TxtCodCaja_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCodCaja.TextChanged
        If TxtCodCaja.Text.Length > 4 Then
            Dim sql As String = "SELECT Caj_cod, Caj_Pcod, cli_nomb, drec_camara, drec_banda, drec_colum, drec_piso, drec_nivel, CASE ISNULL((SELECT racd_estado FROM rackdeta WHERE racd_codi=Caj_Pcod) ,'9') WHEN 9 THEN 'DESPACHADO' ELSE CASE isnull(Caj_ped,0)  WHEN  0 THEN 'VIGENTE'  WHEN  1 THEN 'PEDIDO'  WHEN  2 THEN 'PRE - DESPACHADO'  WHEN  3 THEN 'DESPACHADO' END END AS ESTADO " +
                "FROM  DetaReceCajas LEFT JOIN detapedcaja ON dpc_codcaja=caj_cod INNER JOIN detarece ON drec_codi=Caj_Pcod INNER JOIN clientes ON cli_rut=drec_rutcli WHERE Caj_cod LIKE '%" + TxtCodCaja.Text + "%' AND caj_ped='0' AND drec_rutcli='" + val_cliente + "' ORDER BY Caj_cod DESC "
            DgvInfoCaja.DataSource = fnc.ListarTablasSQL(sql)
            Dim x = DgvCaja.Rows.Count
            If DgvInfoCaja.Rows.Count = 1 Then
                txtpallet_2.Text = DgvInfoCaja.Rows(0).Cells(1).Value.ToString()
            End If
        Else
            Dim sql As String = "SELECT Caj_cod, Caj_Pcod, cli_nomb, drec_camara, drec_banda, drec_colum, drec_piso, drec_nivel, CASE ISNULL((SELECT racd_estado FROM rackdeta WHERE racd_codi=Caj_Pcod) ,'9') WHEN 9 THEN 'DESPACHADO' ELSE CASE isnull(Caj_ped,0) WHEN  0 THEN 'VIGENTE'  WHEN  1 THEN 'PEDIDO'  WHEN  2 THEN 'PRE - DESPACHADO'  WHEN  3 THEN 'DESPACHADO' END END AS ESTADO " +
                "FROM  DetaReceCajas LEFT JOIN detapedcaja ON dpc_codcaja=caj_cod INNER JOIN detarece ON drec_codi=Caj_Pcod INNER JOIN clientes ON cli_rut=drec_rutcli WHERE Caj_cod LIKE 'x' AND caj_ped='0' AND drec_rutcli='" + val_cliente + "' ORDER BY Caj_cod DESC "
            DgvInfoCaja.DataSource = fnc.ListarTablasSQL(sql)
        End If
    End Sub

 
    Private Sub BtnCambiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCambiar.Click
        'Revisa Pedido
        Dim sql As String = "SELECT * FROM DetaPredCajas  WHERE dpre_nped='" + codped.ToString() + "' AND dpre_caja='" + tcaja.Text + "' "

        Dim dt As DataTable = fnc.ListarTablasSQL(sql)

        If dt.Rows.Count > 0 Then
            MsgBox("La caja no puede ser cambiada porque se encuentra en el pedido", MsgBoxStyle.Critical, "Aviso")
            Return
        End If

        If txtpallet_2.Text = txtpallet_1.Text Then
            MsgBox("No puede cambiar cajas del mismo pallet", MsgBoxStyle.Critical, "Aviso")
            Return
        End If

        If txtpallet_2.Text = "" Then
            MsgBox("Debe seleccionar la caja", MsgBoxStyle.Critical, "Aviso")
            Return
        End If

        If TxtCodCaja.Enabled = True Then
            MsgBox("Seleccione el número de caja que remplazará", MsgBoxStyle.Critical, "Aviso")
            Return
        End If

        If tcaja.Text.Trim() = "" Then
            MsgBox("Seleccione el número de caja que cambiará", MsgBoxStyle.Critical, "Aviso")
            Return
        End If

        If MsgBox("¿Seguro de cambiar la caja seleccionada?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Aviso") = vbNo Then
            Return
        End If


        Try
            con.conectar()

            Dim _cmd As SqlCommand = New SqlCommand("PAG_CambioCaja", con.con)
            _cmd.CommandType = CommandType.StoredProcedure
            _cmd.Parameters.AddWithValue("@codped", codped.ToString())
            _cmd.Parameters.AddWithValue("@caj_inici", tcaja.Text)
            _cmd.Parameters.AddWithValue("@caj_final", TxtCodCaja.Text)
            _cmd.Parameters.AddWithValue("@pal_inici", txtpallet_1.Text)
            _cmd.Parameters.AddWithValue("@pal_final", txtpallet_2.Text)

            Dim resp As Integer = 0
            Try
                resp = Convert.ToInt32(_cmd.ExecuteScalar())
            Catch ex As Exception
                resp = 1
            End Try

            If resp = 0 Then
                MsgBox("Caja cambiada exitosamente", MsgBoxStyle.Information, "Aviso")
                LimpiarCajas(Me)
                Frm_PedidosDetalleCajas_Load(Nothing, Nothing)
            ElseIf resp < 4 Then
                MsgBox("Error esperado al grabar la información", MsgBoxStyle.Critical, "Aviso")
            Else
                MsgBox("Error inesperado al grabar la información", MsgBoxStyle.Critical, "Aviso")
            End If
            con.cerrar()

        Catch ex As Exception
            MsgBox(ex.Message())
        End Try

    End Sub

    Private Sub DgvInfoCaja_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvInfoCaja.CellDoubleClick

        If e.RowIndex > -1 Then
            Dim codcaja As String = DgvInfoCaja.Rows(e.RowIndex).Cells(0).Value.ToString()
            Dim codpallet As String = DgvInfoCaja.Rows(e.RowIndex).Cells(1).Value.ToString()

            TxtCodCaja.Text = codcaja
            txtpallet_2.Text = codpallet
            TxtCodCaja.Enabled = False
        End If

    End Sub

    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        Dim sql As String = "SELECT * FROM DetaPredCajas  WHERE dpre_nped='" + codped.ToString() + "' AND dpre_caja='" + tcaja.Text + "' "

        Dim dt As DataTable = fnc.ListarTablasSQL(sql)

        If dt.Rows.Count > 0 Then
            MsgBox("La caja no puede ser eliminada porque se encuentra en el pedido", MsgBoxStyle.Critical, "Aviso")
            Return
        End If

        sql = "SELECT * FROM DetaPredCajas  WHERE dpre_nped='" + codped.ToString() + "' AND dpre_npallet='" + txtpallet_1.Text + "' "

        dt = fnc.ListarTablasSQL(sql)

        If dt.Rows.Count > 0 Then
            MsgBox("La caja no puede ser eliminada porque se encuentra leída en el PRE-DESPACHO", MsgBoxStyle.Critical, "Aviso")
            Return
        End If

        If tcaja.Text = "" Then
            MsgBox("Seleccione la caja a eliminar", MsgBoxStyle.Critical, "Aviso")
            Return
        End If

        If MsgBox("¿Seguro de eliminar la caja seleccionada?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Aviso") = vbNo Then
            Return
        End If

        Try
            con.conectar()

            Dim _cmd As SqlCommand = New SqlCommand("PAG_EliminaCaja", con.con)
            _cmd.CommandType = CommandType.StoredProcedure
            _cmd.Parameters.AddWithValue("@codped", codped.ToString())
            _cmd.Parameters.AddWithValue("@pallet", txtpallet_1.Text)
            _cmd.Parameters.AddWithValue("@codcaja", tcaja.Text)

            Dim resp As Integer = 0

            Try
                resp = Convert.ToInt32(_cmd.ExecuteScalar())
            Catch ex As Exception
                resp = 1
            End Try

            If resp = 0 Then
                MsgBox("Caja eliminada exitosamente", MsgBoxStyle.Information, "Aviso")
                LimpiarCajas(Me)
                Frm_PedidosDetalleCajas_Load(Nothing, Nothing)
                BtnAgregar.Enabled = True
            ElseIf resp < 4 Then
                MsgBox("Error esperado al grabar la información", MsgBoxStyle.Critical, "Aviso")
            Else
                MsgBox("Error inesperado al grabar la información", MsgBoxStyle.Critical, "Aviso")
            End If
            con.cerrar()

        Catch ex As Exception
            MsgBox(ex.Message())
        End Try

    End Sub

    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        Panel1.Visible = True
        BtnEliminar.Enabled = False
        BtnCambiar.Enabled = False
        TxtCodCaja.Enabled = False
        DgvCaja.Enabled = False
    End Sub

     
    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Panel1.Visible = False
        BtnEliminar.Enabled = True
        BtnCambiar.Enabled = True
        TxtCodCaja.Enabled = True
        DgvCaja.Enabled = True

        For Each row As DataGridViewRow In DgvCajasadd.Rows
            row.Cells(0).Value = False
        Next
    End Sub

    Private Sub DgvCajasadd_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvCajasadd.CellClick, DgvCajasadd.CellDoubleClick

        If e.RowIndex > -1 AndAlso e.ColumnIndex = 0 Then
            If Convert.ToBoolean(DgvCajasadd.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) = True Then
                DgvCajasadd.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = False
            Else
                DgvCajasadd.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = True
            End If
        End If

    End Sub

    Private Sub BtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAceptar.Click

        Dim sql As String = "SELECT * FROM DetaPredCajas  WHERE dpre_nped='" + codped.ToString() + "' AND dpre_npallet='" + txtpallet_1.Text + "' "

        Dim dt As DataTable = fnc.ListarTablasSQL(sql)

        If dt.Rows.Count > 0 Then
            MsgBox("La caja no puede ser agregar porque el pallet ya esta leído", MsgBoxStyle.Critical, "Aviso")
            Return
        End If

        Dim cajas_agregar As String = ""

        For Each row As DataGridViewRow In DgvCajasadd.Rows
            If Convert.ToBoolean(row.Cells(0).Value) = True Then
                cajas_agregar += row.Cells(1).Value.ToString() + ","
            End If
        Next

        If cajas_agregar.Length = 0 Then
            MsgBox("Debe seleccionar una caja para agregarla al pedido", MsgBoxStyle.Critical, "Aviso")
            Return
        Else
            cajas_agregar = cajas_agregar.Remove(cajas_agregar.Length - 1, 1)
        End If


        Dim c() As String = cajas_agregar.Split(",")
        Dim cambiadas As Integer = 0


        If MsgBox("¿Seguro de Agregar lo seleccionado?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Aviso") = vbNo Then
            Return
        End If

        Dim _ultimo As String = "1"

        If DgvCajasadd.Rows.Count = c.Length Then
            _ultimo = "0"
        End If


        For i As Integer = 0 To c.Length - 1

            If c(i) <> "" Then

                Try
                    con.conectar()

                    Dim _cmd As SqlCommand = New SqlCommand("PAG_AgregaCaja", con.con)
                    _cmd.CommandType = CommandType.StoredProcedure
                    _cmd.Parameters.AddWithValue("@codped", codped.ToString())
                    _cmd.Parameters.AddWithValue("@pallet", txtpallet_1.Text)
                    _cmd.Parameters.AddWithValue("@caja", c(i))
                    _cmd.Parameters.AddWithValue("@ultimo", _ultimo)

                    Dim resp As Integer = 0

                    Try
                        resp = Convert.ToInt32(_cmd.ExecuteScalar())
                    Catch ex As Exception
                        resp = 1
                    End Try

                    If resp = 0 Then
                        cambiadas += 1
                    End If
                    con.cerrar()

                Catch ex As Exception

                End Try

            End If

        Next

        If cambiadas > 0 Then
            MsgBox("Se agregaron exitosamente " + cambiadas.ToString() + " cajas", 64, "Aviso")
        Else
            MsgBox("Error al intentar agregar las cajas seleccionadas, intente nuevamente", 16, "Aviso")
        End If

        'Cargar Todo actualizado

        Panel1.Visible = False
        BtnEliminar.Enabled = True
        BtnCambiar.Enabled = True
        TxtCodCaja.Enabled = True
        DgvCaja.Enabled = True

        LimpiarCajas(Me)
        Frm_PedidosDetalleCajas_Load(Nothing, Nothing)

        Dim sql_disponibles As String = "SELECT 0 op, caj_cod FROM detarececajas WHERE caj_pcod='" + txtpallet_1.Text + "' AND caj_ped='0'"
        Dim dtb As DataTable = fnc.ListarTablasSQL(sql_disponibles)

        If dtb.Rows.Count > 0 Then
            DgvCajasadd.DataSource = dtb
        Else
            BtnAgregar.Enabled = False
        End If

    End Sub

    Private Sub DgvDetalle_DataBindingComplete(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles DgvCaja.DataBindingComplete

        For Each fila As DataGridViewRow In DgvCaja.Rows

            If fila.Cells(2).Value.ToString() <> "0" Then
                fila.Cells(0).Value = ImageList1.Images(0)
            Else
                fila.Cells(0).Value = ImageList1.Images(1)
            End If

        Next

    End Sub
End Class
Public Class FRM_ProductosClienteLocal
    Public Cliente As String = ""
    Public Orden As String = ""
    Public Sopo As String = ""
    Public Prod As String = ""
    Public Cajas As String = ""
    Public SopoAnt As String = ""
    Public Linea As String = ""

    Dim fnc As New Funciones

    Private Sub FRM_ProductosClienteLocal_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        lblOrd.Text = Orden
        lblPal.Text = Sopo
        lblPro.Text = Prod
        lblCaj.Text = Cajas

        txtCajsAsig.Text = "0"

        cargarCboLocales()
    End Sub

    Sub cargarCboLocales()
        Try
            Dim sqlLocs As String = "SP_Pedidos_Archivos_Locales_Cliente '" & Cliente & "'"
            Dim dtLocs As DataTable = fnc.ListarTablasSQL(sqlLocs)

            Dim dtCbo As New DataTable
            dtCbo.Columns.Add("ID")
            dtCbo.Columns.Add("Nom")

            Dim row As DataRow = dtCbo.NewRow
            row(0) = "-1"
            row(1) = "Seleccione"
            dtCbo.Rows.Add(row)

            For i = 0 To dtLocs.Rows.Count - 1
                Dim row2 As DataRow = dtCbo.NewRow
                row2(0) = dtLocs.Rows(i).Item(0).ToString.Trim
                row2(1) = dtLocs.Rows(i).Item(2).ToString.Trim
                dtCbo.Rows.Add(row2)
            Next

            cboLocs.DataSource = dtCbo
            cboLocs.ValueMember = "ID"
            cboLocs.DisplayMember = "Nom"
        Catch ex As Exception
            MsgBox("Ocurrió un error al cargar los Locales del Cliente.", MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub cboLocs_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboLocs.SelectedIndexChanged
        Dim Loc As String = cboLocs.SelectedValue.ToString.Trim
        If (Loc <> "-1") Then
            txtCajs.Text = ""
            txtCajs.Focus()
        End If
    End Sub

    Sub agregarCajas()
        Try
            Dim Local As String = cboLocs.SelectedValue.ToString.Trim
            Dim NomLoc As String = cboLocs.Text.Trim
            If (Local = "-1") Then
                MsgBox("Debe seleccionar un Local.", MsgBoxStyle.Information, "Info")
                cboLocs.Focus()
                Exit Sub
            End If

            Dim Cajs As String = txtCajs.Text.Trim
            If (Cajs = "") Then
                MsgBox("Debe ingresar cantidad de Cajas asignadas al Local.", MsgBoxStyle.Information, "Info")
                txtCajs.Focus()
                Exit Sub
            End If
            Dim CajsFrm As Integer = 0
            If (Integer.TryParse(Cajs, CajsFrm) = False) Then
                MsgBox("Debe ingresar cantidad de Cajas valida.", MsgBoxStyle.Information, "Info")
                txtCajs.Text = ""
                txtCajs.Focus()
                Exit Sub
            End If

            Dim DetNue As Boolean = True
            Dim CantCajsTot As Integer = 0

            Dim dtRow As New DataTable
            dtRow.Columns.Add("IDLoc")
            dtRow.Columns.Add("Local")
            dtRow.Columns.Add("CantCajas")

            For i = 0 To dgvDet.Rows.Count - 1
                Dim row As DataRow = dtRow.NewRow
                
                Dim IDLoc = dgvDet.Rows(i).Cells("IDLoc").Value.ToString.Trim
                Dim NomLocDet = dgvDet.Rows(i).Cells("Local").Value.ToString.Trim
                Dim CajsDet As Integer = CInt(dgvDet.Rows(i).Cells("CantCajas").Value.ToString.Trim)

                row(0) = IDLoc
                row(1) = NomLocDet
                row(2) = CajsDet

                If (IDLoc = Local) Then
                    DetNue = False
                    CajsDet += CajsFrm
                    row(2) = CajsDet
                End If

                dtRow.Rows.Add(row)

                CantCajsTot += CajsDet
            Next

            If (DetNue) Then
                Dim row2 As DataRow = dtRow.NewRow
                row2(0) = Local
                row2(1) = NomLoc
                row2(2) = CajsFrm
                dtRow.Rows.Add(row2)

                CantCajsTot += CajsFrm
            End If

            dgvDet.DataSource = dtRow

            txtCajsAsig.Text = CantCajsTot

            cboLocs.SelectedIndex = 0
            txtCajs.Text = ""
            cboLocs.Focus()
        Catch ex As Exception
            MsgBox("Ocurrió un error al agregar las Cajas al Local.", MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnAgrCaj_Click(sender As System.Object, e As System.EventArgs) Handles btnAgrCaj.Click
        agregarCajas()
    End Sub

    Private Sub txtCajs_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCajs.KeyPress
        If (e.KeyChar = ChrW(13)) Then
            agregarCajas()
        End If
    End Sub

    Private Sub btnGra_Click(sender As System.Object, e As System.EventArgs) Handles btnGra.Click
        Try
            Dim CajsAsig As Integer = CInt(txtCajsAsig.Text.Trim)
            If (CajsAsig > Cajas) Then
                MsgBox("Las Cajas asignadas superan la cantidad disponible.", MsgBoxStyle.Information, "Info")
                Exit Sub
            End If

            If (dgvDet.Rows.Count > 0) Then
                For i = 0 To dgvDet.Rows.Count - 1
                    Dim IDLoc = dgvDet.Rows(i).Cells("IDLoc").Value.ToString.Trim
                    Dim CanCaj = dgvDet.Rows(i).Cells("CantCajas").Value.ToString.Trim

                    Dim sqlDetPed = "SP_Pedidos_Locales_Actualizar '" & Orden & "','" & Linea & "','" & SopoAnt & "','" & Sopo & "','" & IDLoc & "','" & CanCaj & "'"
                    fnc.MovimientoSQL(sqlDetPed)
                Next
                MsgBox("Detalle del pedido actualizado exitosamente.", MsgBoxStyle.Information, "Exito")

                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            Else
                MsgBox("Debe seleccionar al menos un Local para el Pedido.", MsgBoxStyle.Information, "Ingrese Detalle Pedido")
            End If
        Catch ex As Exception
            MsgBox("Ocurrió un error al grabar el Detalle del Pedido.", MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub dgvDet_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDet.CellClick
        Try
            If (e.RowIndex <> -1) Then
                If (e.ColumnIndex = 0) Then
                    Dim respMsg = MsgBox("¿Está seguro de eliminar esta asignación?", MsgBoxStyle.YesNo, "Confirmar")
                    If (respMsg = MsgBoxResult.Yes) Then
                        Dim dtDgv As DataTable = CType(dgvDet.DataSource, DataTable)
                        dtDgv.Rows(e.RowIndex).Delete()

                        dgvDet.DataSource = dtDgv

                        Dim totCajs As Integer = 0

                        For i = 0 To dtDgv.Rows.Count - 1
                            Dim CanCajs As Integer = CInt(dtDgv.Rows(i).Item("CantCajas").ToString.Trim)

                            totCajs += CanCajs
                        Next

                        txtCajsAsig.Text = totCajs

                        cboLocs.SelectedIndex = 0
                        txtCajs.Text = ""
                        cboLocs.Focus()
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("Ocurrió un error al eliminar el Detalle seleccionado.", MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
End Class
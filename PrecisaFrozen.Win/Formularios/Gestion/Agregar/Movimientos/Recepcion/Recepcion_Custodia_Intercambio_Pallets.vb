Public Class Recepcion_Custodia_Intercambio_Pallets

    Dim fnc As New Funciones

    Private Sub Recepcion_Custodia_Intercambio_Pallets_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        cargarCboPallet()
        cargarCboCont()
        limpiar()
    End Sub

    Private Sub btnSal_Click(sender As System.Object, e As System.EventArgs) Handles btnSal.Click
        Me.Close()
    End Sub

    Sub limpiar()
        cboPall.SelectedIndex = 0
        cboCont.SelectedIndex = 0

        cargarIntercambios()

        cboPall.Focus()
    End Sub

    Private Sub btnLim_Click(sender As System.Object, e As System.EventArgs) Handles btnLim.Click
        limpiar()
    End Sub

    Sub cargarCboPallet()
        Try
            Dim CodRece As String = txtCodRece.Text.Trim
            Dim TipPal As String = txtTipPal.Text.Trim

            Dim sqlPalsRece As String = "select drec_codi=a.frec_codi+a.drec_codi from TMPDETARECE a with(nolock) where a.frec_codi='" & CodRece & "' and a.drec_codsopo='" & TipPal & "'"
            Dim dtPalsRece As New DataTable

            dtPalsRece = fnc.ListarTablasSQL(sqlPalsRece)

            Dim row As DataRow = dtPalsRece.NewRow
            row(0) = "Seleccione"
            dtPalsRece.Rows.InsertAt(row, 0)

            cboPall.DataSource = dtPalsRece
        Catch ex As Exception
            MsgBox("Ocurrió un error al cargar los pallets", MsgBoxStyle.Critical, "Error!")
        End Try
    End Sub

    Sub cargarCboCont()
        Try
            Dim CodRece As String = txtCodRece.Text.Trim
            Dim TipPal As String = txtTipPal.Text.Trim

            Dim sqlContsCli As String = "select Contrato=b.cont_descr,a.Saldo from Control_Pallet_Saldos a with(nolock) inner join contrato b with(nolock) on(a.Contrato=b.cont_codi) where a.Rut_Cliente='' and a.Contrato<>''"
            Dim dtContsCli As New DataTable

            dtContsCli = fnc.ListarTablasSQL(sqlContsCli)

            Dim row As DataRow = dtContsCli.NewRow
            row(0) = "Seleccione"
            dtContsCli.Rows.InsertAt(row, 0)

            cboCont.DataSource = dtContsCli
        Catch ex As Exception
            MsgBox("Ocurrió un error al cargar los pallets contratos", MsgBoxStyle.Critical, "Error!")
        End Try
    End Sub

    Sub cargarIntercambios()
        Try

        Catch ex As Exception
            MsgBox("Ocurrió un error al cargar los intercambios", MsgBoxStyle.Critical, "Error!")
        End Try
    End Sub
End Class
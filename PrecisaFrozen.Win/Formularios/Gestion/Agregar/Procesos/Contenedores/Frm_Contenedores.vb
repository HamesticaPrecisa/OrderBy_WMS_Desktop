Imports Microsoft.Office.Interop

Class Frm_Contenedores

    Dim fnc As New Funciones
    Dim fila As Integer = -1

    Sub Dt()

        Dim tabla As DataTable = New DataTable
        tabla.Columns.Add("cod")
        tabla.Columns.Add("desc")
        tabla.Rows.Add("0", "-- TODOS --")
        tabla.Rows.Add("1", "Pendientes")
        tabla.Rows.Add("2", "Despachados")

        ComboEstado.DataSource = tabla
        ComboEstado.DisplayMember = "desc"
        ComboEstado.ValueMember = "cod"

    End Sub

    Private Sub Frm_Contenedores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Frm_Principal.buscavalor = ""

        Dt()
        ComboEstado.SelectedValue = 1
        BtnFiltrar_Click(Nothing, Nothing)
        RecorreGrilla()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btn_BuscaCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_BuscaCliente.Click
        Dim frm As New Lst_AyudaClientes
        frm.ShowDialog(Frm_Principal)
        If Frm_Principal.buscavalor <> "" Then
            rutcli.Text = Frm_Principal.buscavalor
            nomcli.Text = RetornaCliente(Frm_Principal.buscavalor)
        End If
    End Sub

    Private Sub CbCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CbCliente.CheckedChanged
        If CbCliente.Checked = True Then
            btn_BuscaCliente.Enabled = False
            rutcli.Text = ""
            nomcli.Text = ""
        Else
            btn_BuscaCliente.Enabled = True
        End If
    End Sub

    Public Sub filtro()

        Dim sql As String = "SELECT frec_codi, frec_contenedor, cli_nomb,  cont_descr, BLOQ, REV, ETIQ FROM GvwContFinal2 " +
            "WHERE frec_clirut='" + rutcli.Text + "'" + " ORDER BY frec_codi"

        DgvContenedores.DataSource = fnc.ListarTablasSQL(sql)
        RecorreGrilla()
    End Sub

    Private Sub BtnFiltrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFiltrar.Click
        Dim WHERE = ""

        If CbCliente.Checked = False AndAlso rutcli.Text <> "" Then
            WHERE = "frec_rutcli='" + rutcli.Text + "' "
        End If


        If ComboEstado.SelectedValue > 0 Then
            Dim caracter = ""
            If ComboEstado.SelectedValue = 1 Then
                caracter = "<>"
            ElseIf ComboEstado.SelectedValue = 2 Then
                caracter = "="
            End If

            If WHERE.Length = 0 Then
                WHERE = WHERE + " SUMRECE" + caracter + "SUMDESPA "
            Else
                WHERE = WHERE + "AND SUMRECE" + caracter + "SUMDESPA"
            End If

        End If

        If WHERE.Length > 0 Then
            WHERE = "WHERE " + WHERE
        End If
        Dim sql As String = "SELECT frec_codi, frec_contenedor, cli_nomb, cont_descr, BLOQ, ETIQ, REV FROM GvwContFinal2 " + WHERE + " ORDER BY frec_codi"

        DgvContenedores.DataSource = fnc.ListarTablasSQL(sql)
        RecorreGrilla()
    End Sub

    Private Sub Btn_BuscaContrato_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim f As New Lst_AyudaContratos
        f.condicion = "WHERE cont_clirut='" + rutcli.Text + "'"
        f.ShowDialog()
    End Sub

    Private Sub ComboEstado_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboEstado.KeyPress
        e.Handled = True
    End Sub

    Sub RecorreGrilla()

        For Each Val As DataGridViewRow In DgvContenedores.Rows

            If Val.Cells("bcod").Value = "0" Then
                Val.Cells(2).Value = My.Resources.cont_ok
            ElseIf Val.Cells("bcod").Value = "1" Then
                Val.Cells(2).Value = My.Resources.cont_no
            End If

            If Val.Cells("ecod").Value = "0" Then
                Val.Cells(0).Value = My.Resources.cont_no
            ElseIf Val.Cells("ecod").Value = "1" Then
                Val.Cells(0).Value = My.Resources.cont_medio
            ElseIf Val.Cells("ecod").Value = "2" Then
                Val.Cells(0).Value = My.Resources.cont_ok
            End If

            If Val.Cells("rcod").Value = "0" Then
                Val.Cells(1).Value = My.Resources.cont_no
            ElseIf Val.Cells("rcod").Value = "1" Then
                Val.Cells(1).Value = My.Resources.cont_medio
            ElseIf Val.Cells("rcod").Value = "2" Then
                Val.Cells(1).Value = My.Resources.cont_ok
            End If

        Next

    End Sub

    Private Sub DgvContenedores_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvContenedores.CellDoubleClick
        If e.RowIndex > -1 Then

            Dim f As New Frm_ContDeta

            f.nomcli.Text = DgvContenedores.Rows(e.RowIndex).Cells("CLIENTE").Value.ToString()
            f.guia.Text = DgvContenedores.Rows(e.RowIndex).Cells("RECEPCION").Value.ToString()
            f.contenedor.Text = DgvContenedores.Rows(e.RowIndex).Cells("CONTENEDOR").Value.ToString()
            f.ShowDialog()

            BtnFiltrar_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub Frm_Contenedores_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        f_contenedores = False
    End Sub

    Private Sub DgvContenedores_DataBindingComplete(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles DgvContenedores.DataBindingComplete
        RecorreGrilla()
    End Sub

    Private Sub BtnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExportar.Click


        Dim parametro As String = ""

        If CbSeleccion.Checked = True AndAlso fila > -1 AndAlso fila < DgvContenedores.Rows.Count Then
            parametro = " WHERE fr.frec_contenedor='" + DgvContenedores.Rows(fila).Cells("CONTENEDOR").Value.ToString() + "'"
        End If

        If ComboEstado.SelectedValue = 1 Then
            If parametro = "" Then
                parametro = "WHERE SUMRECE<>SUMDESPA "
            Else
                parametro = parametro + " AND SUMRECE<>SUMDESPA "
            End If

        ElseIf ComboEstado.SelectedValue = 2 Then
            If parametro = "" Then
                parametro = " WHERE SUMRECE=SUMDESPA "
            Else
                parametro = parametro + " AND SUMRECE=SUMDESPA "
            End If
        End If

        If CbCliente.Checked = False AndAlso rutcli.Text <> "" Then
            If parametro = "" Then
                parametro = " WHERE fr.frec_rutcli='" + rutcli.Text + "' "
            Else
                parametro &= " AND fr.frec_rutcli='" + rutcli.Text + "' "
            End If

        End If
        documentoimp = DateTime.Now.ToString("MM-dd-yy") + "CONTENEDORES"
        Dim frm As Frm_MuestraReporte = New Frm_MuestraReporte
        frm.Text = "Asistente de informes - Informe de contenedores"

        Dim report As New RptContenedores

        report.SetDatabaseLogon(Usuario_ODBC, Pass_ODBC)
        report.SetParameterValue("parametro", parametro)

        frm.Contenedor.ReportSource = report
        frm.ShowDialog()


    End Sub

    Private Sub DgvContenedores_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvContenedores.CellClick
        fila = e.RowIndex
    End Sub
End Class


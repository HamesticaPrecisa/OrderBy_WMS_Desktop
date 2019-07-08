Public Class Frm_Revisiones

    Dim fnc As New Funciones

    Private Sub Frm_Revisiones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim dt As New DataTable
        dt.Columns.Add("cod")
        dt.Columns.Add("descri")
        dt.Rows.Add(1, "REDE A FRIGORIFICO")
        dt.Rows.Add(2, "FRIGORIFICO A REDE")

        movimiento.DataSource = dt
        movimiento.DisplayMember = "descri"
        movimiento.ValueMember = "cod"


        Dim sql As String = "SELECT drec_codi, drec_sopocli, mae_descr, descri, drec_unidades " +
                            "FROM LOG_RevisionPallets  INNER JOIN usuarios ON usu_codigo=rev_codenca " +
                            "INNER JOIN detarece ON drec_codi=rev_codpallet INNER JOIN maeprod ON mae_codi=drec_codpro " +
                            "WHERE CONVERT(varchar(10),rev_fecha,103)='" + devuelve_fecha_Formato2(dtrevision.Value) + "' ORDER BY drec_codi ASC"

        DgvResumen.DataSource = fnc.ListarTablasSQL(sql)

    End Sub

    Private Sub Frm_Revisiones_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        f_revisiones = False
    End Sub

    Private Sub BtnFiltrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFiltrar.Click
        'filtro de la información
        Dim where As String = ""
        Dim isrece As Boolean = False

        If txtcodrece.Text <> "" Then
            txtcodrece.Text = CerosAnteriorString(txtcodrece.Text, 7)
            where = where + "AND LEFT(drec_codi,7)='" + txtcodrece.Text + "' "
            isrece = True
        End If
        If isrece = False Then
            If cb1.Checked = False Then
                where = where + "AND drec_fecrec='" + devuelve_fecha(dtrece.Value) + "' "
            End If
            If cb2.Checked = False Then
                where = where + "AND CONVERT(varchar(10),rev_fecha,103)='" + devuelve_fecha_Formato2(dtrevision.Value) + "' "
            End If
            If cb3.Checked = False Then
                where = where + "AND isnull(rev_tipo,1)='" + movimiento.SelectedValue.ToString() + "' "
            End If
        Else
            cb1.Checked = True
            cb2.Checked = True
            cb3.Checked = True
        End If

        If where.Length > 0 Then
            where = "WHERE " + where.Remove(0, 4)
        End If

        Console.WriteLine(where)

        Dim sql As String = "SELECT drec_codi, drec_sopocli, mae_descr, descri, drec_unidades " +
                           "FROM LOG_RevisionPallets  INNER JOIN usuarios ON usu_codigo=rev_codenca " +
                           "INNER JOIN detarece ON drec_codi=rev_codpallet INNER JOIN maeprod ON mae_codi=drec_codpro " +
                           "" + where + "ORDER BY drec_codi ASC"
        DgvResumen.DataSource = fnc.ListarTablasSQL(sql)

        If DgvResumen.Rows.Count = 0 Then
            MsgBox("No existe información para mostrar", MsgBoxStyle.Critical, "Aviso")
            BtnNuevo_Click(Nothing, Nothing)
            Exit Sub
        End If

        txtcodrece.Enabled = False
        cb1.Enabled = False
        cb2.Enabled = False
        cb3.Enabled = False
        BtnImprimir.Enabled = True
        BtnFiltrar.Enabled = False
        BtnNuevo.Focus()
    End Sub

    Private Sub cb3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb3.CheckedChanged
        If cb3.Checked = True Then
            movimiento.Enabled = False
        Else
            movimiento.Enabled = True
        End If
    End Sub

    Private Sub cb2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb2.CheckedChanged
        If cb2.Checked = True Then
            dtrevision.Enabled = False
        Else
            dtrevision.Enabled = True
        End If
    End Sub

    Private Sub cb1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb1.CheckedChanged
        If cb1.Checked = True Then
            dtrece.Enabled = False
        Else
            dtrece.Enabled = True
        End If
    End Sub

    Private Sub txtproducto_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcodrece.KeyPress
        If e.KeyChar = ChrW(13) Then
            If txtcodrece.Text.Length > 0 Then
                BtnFiltrar_Click(Nothing, Nothing)
            End If
        End If
    End Sub

    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        txtcodrece.Enabled = True
        txtcodrece.Text = ""
        cb1.Enabled = True
        cb2.Enabled = True
        cb3.Enabled = True
        BtnImprimir.Enabled = False
        BtnFiltrar.Enabled = True
        While (DgvResumen.Rows.Count > 0)
            DgvResumen.Rows.RemoveAt(0)
        End While
        txtcodrece.Focus()
    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Close()
    End Sub

    Private Sub BtnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImprimir.Click

        Dim tabla As DataTable = DgvResumen.DataSource
        documentoimp = DateTime.Now.ToString("MM-dd-yy") + "Revision"
        Dim frm As Frm_MuestraReporte = New Frm_MuestraReporte
        Dim report As New Rpt_ResumidoFecha

        Dim Ds As New Ds_Revisiones

        For Each row As DataGridViewRow In DgvResumen.Rows
            Ds.DsDetalleRevisiones.AddDsDetalleRevisionesRow(row.Cells("nprecisa").Value.ToString(),
                                         row.Cells("ncliente").Value.ToString(),
                                         row.Cells("producto").Value.ToString(),
                                         row.Cells("RESPONSABLE").Value.ToString(),
                                         row.Cells("CANTIDAD").Value.ToString())
        Next

        Dim crt As New Rpt_Revisiones
        crt.SetDataSource(Ds)
        If txtcodrece.Text = "" Then

        End If
        crt.SetParameterValue("recepcion", txtcodrece.Text)
        If cb1.Checked = False Then
            crt.SetParameterValue("frecepcion", devuelve_fecha(dtrece.Value))
        Else
            crt.SetParameterValue("frecepcion", "TODOS")
        End If

        If cb2.Checked = False Then
            crt.SetParameterValue("frevision", devuelve_fecha(dtrevision.Value))
        Else
            crt.SetParameterValue("frevision", "TODOS")
        End If

        If cb3.Checked = False Then
            crt.SetParameterValue("movimiento", movimiento.Text)
        Else
            crt.SetParameterValue("movimiento", "TODOS")
        End If

        frm.Contenedor.ReportSource = crt
        frm.ShowDialog()
    End Sub

End Class
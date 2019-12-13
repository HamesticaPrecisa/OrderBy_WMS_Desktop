Public Class Frm_TrazabilidadGuia

    Dim fnc As New Funciones

    Private Sub TxtGuiaRecepcionPrecisa_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtGuiaRecepcionPrecisa.KeyPress
        If e.KeyChar = ChrW(13) Then
            If RbRecepcionPrecisa.Checked Then
                If TxtGuiaRecepcionPrecisa.Text = "" Then
                    MsgBox("Ingrese un N° de Guia", MsgBoxStyle.Critical, "Aviso")
                Else
                    TxtGuiaRecepcionPrecisa.Text = CerosAnteriorString(TxtGuiaRecepcionPrecisa.Text, 7)
                    BuscaSoportantesCliente(CerosAnteriorString(TxtGuiaRecepcionPrecisa.Text, 7), 0)
                End If
            End If
        End If
    End Sub

    Private Sub TxtGuiaDespachoPrecisa_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtGuiaDespachoPrecisa.KeyPress
        If e.KeyChar = ChrW(13) Then
            If RbDespachoPrecisa.Checked Then
                If TxtGuiaDespachoPrecisa.Text = "" Then
                    MsgBox("Ingrese un N° de Guia", MsgBoxStyle.Critical, "Aviso")
                Else
                    TxtGuiaDespachoPrecisa.Text = CerosAnteriorString(TxtGuiaDespachoPrecisa.Text, 7)
                    BuscaSoportantesCliente(CerosAnteriorString(TxtGuiaDespachoPrecisa.Text, 7), 1)
                End If
            End If
        End If
    End Sub

    Private Sub RbRecepcionPrecisa_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RbRecepcionPrecisa.CheckedChanged
        If RbRecepcionPrecisa.Checked Then
            TxtGuiaRecepcionPrecisa.Focus()
        End If
    End Sub

    Private Sub RbDespachoPrecisa_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RbDespachoPrecisa.CheckedChanged
        If RbDespachoPrecisa.Checked Then
            TxtGuiaDespachoPrecisa.Focus()
        End If
    End Sub

    Private Sub TxtGuiaRecepcionPrecisa_Click(sender As Object, e As System.EventArgs) Handles TxtGuiaRecepcionPrecisa.Click
        RbRecepcionPrecisa.Checked = True
        TxtGuiaDespachoPrecisa.Text = ""
    End Sub

    Private Sub TxtGuiaDespachoPrecisa_Click(sender As Object, e As System.EventArgs) Handles TxtGuiaDespachoPrecisa.Click
        RbDespachoPrecisa.Checked = True
        TxtGuiaRecepcionPrecisa.Text = ""
    End Sub

    Sub BuscaSoportantesCliente(ByVal guia_recepcion As String, ByVal tipo_sopo As Integer)
        If tipo_sopo = 0 Then

            'Dim sql As String = "SELECT mov_folio,drec_sopocli,mov_fecha, mov_hora, mov_doc, descri, mov_tipo, CONVERT(INTEGER,mov_despacho) mov_despacho, " +
            '                    "       CONVERT(INTEGER, mov_saldo) mov_saldo, mov_TS, mov_ca, mov_ba, mov_co, mov_pi, mov_ni " +
            '                    "  FROM movpallet, usuarios, detarece " +
            '                    " WHERE CONVERT(INTEGER,mov_codper) = CONVERT(INTEGER,personal) AND SUBSTRING(mov_folio,0,8) ='" + guia_recepcion.Trim + "' " +
            '                    "   AND movpallet.mov_folio = detarece.drec_codi " +
            '                    " ORDER BY mov_folio, mov_fecha, mov_hora"

            Dim sql As String = "select a.mov_folio, c.drec_sopocli, a.mov_fecha, a.mov_hora, a.mov_doc,b.descri, a.mov_tipo, mov_despacho = Convert(Int, a.mov_despacho),mov_saldo = Convert(Int, a.mov_saldo), a.mov_TS,Nombre_Camara = d.NCamara, a.mov_ca,a.mov_ba, a.mov_co, a.mov_pi, a.mov_ni from movpallet a with(nolock) inner join usuarios b with(nolock) on(convert(integer,a.mov_codper)=convert(integer,b.personal)) inner join detarece c with(nolock) on(a.mov_folio=c.drec_codi) left join CamaraConf d with(nolock) on(a.mov_ca=d.Camara) where SUBSTRING(a.mov_folio,0,8)='" + guia_recepcion.Trim + "' order by a.mov_folio,convert(date,a.mov_fecha),a.mov_hora asc"

            dgvTrazabilidad.DataSource = fnc.ListarTablasSQL(sql)

            If dgvTrazabilidad.Rows.Count = 0 Then
                MsgBox("El numero de Guia ingresado no existe", MsgBoxStyle.Critical, "Aviso")
            End If

        Else
            'Dim sql As String = "SELECT mov_folio,drec_sopocli,mov_fecha, mov_hora, mov_doc, descri, mov_tipo, CONVERT(INTEGER,mov_despacho) mov_despacho, " +
            '                    "       CONVERT(INTEGER, mov_saldo) mov_saldo, mov_TS, mov_ca, mov_ba, mov_co, mov_pi, mov_ni " +
            '                    "  FROM movpallet, usuarios, detarece " +
            '                    " WHERE CONVERT(INTEGER,mov_codper) = CONVERT(INTEGER,personal) AND mov_folio IN (SELECT DISTINCT mov_folio " +
            '                    "                                                                                   FROM movpallet " +
            '                    "                                                                                  WHERE mov_doc = '" + guia_recepcion.Trim + "'" +
            '                    "                                                                                    AND mov_tipo = 'SA') " +
            '                    "   AND movpallet.mov_folio = detarece.drec_codi " +
            '                    " ORDER BY mov_folio, mov_fecha, mov_hora "

            Dim sql As String = "select a.mov_folio, c.drec_sopocli, a.mov_fecha, a.mov_hora, a.mov_doc,b.descri, a.mov_tipo, mov_despacho = Convert(Int, a.mov_despacho),mov_saldo = Convert(Int, a.mov_saldo), a.mov_TS,Nombre_Camara = d.NCamara, a.mov_ca,a.mov_ba, a.mov_co, a.mov_pi, a.mov_ni from movpallet a with(nolock) inner join usuarios b with(nolock) on(convert(integer,a.mov_codper)=convert(integer,b.personal)) inner join detarece c with(nolock) on(a.mov_folio=c.drec_codi) left outer join CamaraConf d with(nolock) on(a.mov_ca=d.Camara) inner join (select mov_folio from movpallet with(nolock) where mov_tipo='SA' and mov_Doc='" + guia_recepcion.Trim + "')e on(a.mov_folio=e.mov_folio) order by a.mov_folio,convert(date,a.mov_fecha),a.mov_hora asc"

            dgvTrazabilidad.DataSource = fnc.ListarTablasSQL(sql)

            If dgvTrazabilidad.Rows.Count = 0 Then
                MsgBox("El Numero de Guia ingresado no existe", MsgBoxStyle.Critical, "Aviso")
                End If

        End If

    End Sub

    Private Sub btnExcel_Click(sender As System.Object, e As System.EventArgs) Handles btnExcel.Click
        Call GridAExcel(dgvTrazabilidad)
    End Sub

    Private Sub Frm_TrazabilidadGuia_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        f_TrazGuia = False
    End Sub

    Private Sub Frm_TrazabilidadGuia_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
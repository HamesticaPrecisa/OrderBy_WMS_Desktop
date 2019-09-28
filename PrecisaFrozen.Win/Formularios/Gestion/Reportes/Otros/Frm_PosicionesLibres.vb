Public Class Frm_PosicionesLibres

    Dim fnc As New Funciones
    Dim where As String = ""
    Dim where2 As String = ""

    Private Sub Frm_PosicionesLibres_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        f_poslibres = False
    End Sub

    Private Sub Frm_PosicionesLibres_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim sql As String = "select camara,nombre from nvg_posicioneslibres group by camara,nombre order by nombre"

        cbcamaras.DataSource = fnc.ListarTablasSQL(sql)
        cbcamaras.DisplayMember = "nombre"
        cbcamaras.ValueMember = "camara"

        ' cbcamaras.Items.Add("TODO")
        'cbcamaras.Text = "TODO"
    End Sub

    Private Sub cbcamaras_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbcamaras.SelectedValueChanged
        If IsNumeric(cbcamaras.SelectedValue.ToString()) Then

            Dim camara As String = CerosAnteriorString(cbcamaras.SelectedValue.ToString(), 2)

            Dim whCam = ""

            If cbcamaras.Text = "TODO" Then
                where = ""
            Else
                where = " where camara='" + camara + "' "

                whCam = " and a.Camara='" + camara + "'"
            End If




            'Dim sql = "SELECT rack_ca, rack_ba, rack_co, rack_pi " +
            '          "FROM rackdeta RIGHT JOIN rack ON racd_ca+racd_ba+racd_co+racd_pi=LEFT(rack_codi,6)+convert(varchar(1),Convert(integer,rack_pi)) " +
            '          "WHERE racd_codi Is null " + where
            'Dim sql = "SELECT * FROM NVG_POSICIONESLIBRES" + where
            Dim sql = "select Nombre=b.NombreCamara,b.Camara,b.Banda,b.Columna,pi=b.Piso from CamaraConf a with(nolock) inner join CamaraMantenedor b with(nolock) on(a.NCamara=b.NombreCamara) left outer join rackdeta c with(nolock) on( b.Camara=c.racd_ca and b.Banda=c.racd_ba and b.Columna=c.racd_co and convert(int,b.Piso)=convert(int,c.racd_pi) ) where a.trans='0' and (b.estado='0' or b.estado is null) and (b.Aestado='0' or b.Aestado is null) and c.racd_codi is null" & whCam & " order by b.Camara asc, b.Banda asc, b.Columna asc, b.Piso asc"


            data.DataSource = fnc.ListarTablasSQL(sql)

            'Dim sql2 = "SELECT * FROM VG_ALTURA_CAMARAS" + where2
            'data2.DataSource = fnc.ListarTablasSQL(sql2)
            data2.DataSource = fnc.ListarTablasSQL(sql)
            txttotal.Text = data.Rows.Count.ToString()

        End If
    End Sub

    Private Sub Btn_Salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Salir.Click
        Close()
    End Sub

    Private Sub btn_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        Call GridAExcel(data)
    End Sub

    Private Sub btn_Imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Imprimir.Click
        Dim frm As Frm_MuestraReporte = New Frm_MuestraReporte
        frm.Text = "Asistente de informes - Informe de Posiciones Libres"

        Dim report As New Rpt_PosicionesLibres
        report.SetDatabaseLogon(Usuario_ODBC, Pass_ODBC)
        report.SetParameterValue("where", where)
        frm.Contenedor.ReportSource = report
        frm.ShowDialog()

    End Sub

    Private Sub cbcamaras_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbcamaras.SelectedIndexChanged

    End Sub
End Class
Imports System.Windows.Forms.DataVisualization.Charting

Public Class FrmPosicionestotales
    Dim fnc As New Funciones
    Dim VA1 As String = ""
    Dim VA2 As String = ""
    Dim VA3 As String = ""

    Dim VA4 As String = ""
    Private Sub FrmPosicionestotales_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'Dim strSQL As String = "select camara as CODIGO , Nombre as NOMBRE , CACRE AS [CANT. CREADA], CADIS AS [CANT. DISPONIBLE] , BLOQUEADOS AS BLOQUEADOS , OCU AS UTILIZADO ,LIBRES, PORCEN AS [%] , Util as SOPORTANTES , enrack as [EN RACK],APISO AS [A PISO]    from vg_camaratotales2 order by camara"
        Dim strSQL As String = "select camara as CODIGO,Nombre as NOMBRE,CACRE AS [CANT. CREADA],CADIS AS [CANT. DISPONIBLE],BLOQUEADOS AS BLOQUEADOS,OCU AS UTILIZADO,LIBRES,PORCEN AS [%],Util as SOPORTANTES,enrack as [EN RACK],APISO AS [A PISO] from V_Camaras_Informe_Posiciones with(nolock) order by camara asc"
        DgvResultado.DataSource = fnc.ListarTablasSQL(strSQL)
        Dim strSQL2 As String = "select * from vg_transitocantidad"
        DgvResultado2.DataSource = fnc.ListarTablasSQL(strSQL2)
        'Dim SqlBusca As String = "SELECT totdis,totuti,totlib,totbloq FROM vg_PORCEFINAL "
        Dim SqlBusca As String = "select totdis=sum(CACRE),totuti=sum(OCU),totlib=sum(LIBRES),totbloq=sum(BLOQUEADOS) from V_Camaras_Informe_Posiciones with(nolock)"

        Dim tablapor As DataTable = fnc.ListarTablasSQL(SqlBusca)

        If tablapor.Rows.Count > 0 Then

            VA1 = tablapor.Rows(0)(0).ToString()
            VA2 = tablapor.Rows(0)(1).ToString()
            VA3 = tablapor.Rows(0)(2).ToString()
            VA4 = tablapor.Rows(0)(3).ToString()
        End If

        Dim SUM1 As Int32 = 0
        'Dim SQLSUM1 As String = "SELECT SUM(util) AS encamara FROM VG_CAMARATOTALES2"
        Dim SQLSUM1 As String = "select sum(Util) from V_Camaras_Informe_Posiciones with(nolock)"
        Dim TABLASUM1 As DataTable = fnc.ListarTablasSQL(SQLSUM1)

        If TABLASUM1.Rows.Count > 0 Then

            SUM1 = TABLASUM1.Rows(0)(0).ToString()
            txtencamara.Text = SUM1.ToString()
        End If

        Dim SUM2 As Int32 = 0
        Dim SQLSUM2 As String = "SELECT        SUM(CANTIDAD) AS ENTRANS FROM dbo.VG_TRANSITOCANTIDAD"
        Dim TABLASUM2 As DataTable = fnc.ListarTablasSQL(SQLSUM2)

        If TABLASUM2.Rows.Count > 0 Then

            SUM2 = TABLASUM2.Rows(0)(0).ToString()
            txtentransito.Text = SUM2.ToString()
        End If

        txtototal.Text = SUM1 + SUM2





        Chart1.Series(0).ChartType = SeriesChartType.Pie
        Chart1.ChartAreas(0).Area3DStyle.Enable3D = True

        Chart1.Series(0).Points.AddY(0.0)
        Chart1.Series(0).Points.AddY(0.0)
        Chart1.Series(0).Points.AddY(0.0)

        'Chart1.Series.Add("UTILIZADO" + " " + VA2)
        'Chart1.Series.Add("LIBRE" + " " + VA3)
        'Chart1.Series.Add("BLOQUEADO" + " " + VA4)


        Chart1.Series(0).Points(0).LegendText = "UTILIZADO" + " " + VA2
        Chart1.Series(0).Points(1).LegendText = "LIBRE" + " " + VA3
        Chart1.Series(0).Points(2).LegendText = "BLOQUEADO" + " " + VA4




        Chart1.Series(0).Label = "#VAL" + "%"



     
        '   Chart1.Series(0).Font.Size(14






        ' Dim valo1 As String = 100.ToString
        ' Dim valo2 As String = 35.8.ToString
        Dim val1 As Decimal
        Dim val2 As Decimal
        Dim val3 As Decimal
        Dim val4 As Decimal

        val1 = Decimal.Round(System.Convert.ToDecimal(VA1), 2)
        val2 = Decimal.Round(System.Convert.ToDecimal(VA2), 2)
        val3 = Decimal.Round(System.Convert.ToDecimal(VA3), 3)
        val4 = Decimal.Round(System.Convert.ToDecimal(VA4), 4)
        ' Decimal.TryParse(VA1, val1)
        ' Decimal.TryParse(VA2, val2)
        ' Decimal.TryParse(VA3, val3)
        'Decimal.TryParse(VA4, val4)

        Chart1.Series(0).Points(0).SetValueY(Decimal.Round(val2 * 100 / val1, 2))
        Chart1.Series(0).Points(1).SetValueY(Decimal.Round(val3 * 100 / val1, 2))
        Chart1.Series(0).Points(2).SetValueY(Decimal.Round(val4 * 100 / val1, 2))




        Chart1.Series.Invalidate()


    End Sub

    Private Sub FrmPosicionestotales_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        f_possss = False
    End Sub
End Class
Public Class Frm_InformeTunel
    Dim fnc As New Funciones
    Private Sub Btn_Calcular_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Calcular.Click


        Dim suma As Double = 0
        Dim unidades As Integer = 0
        Dim st As String = ""
        Dim sk As String = ""
        Dim str As String = ""
        Dim str2 As String = ""
        Dim str3 As String = ""
        Dim u As Integer = 0
        Dim un As Integer = 0
        Dim k As Double = 0
        Dim val As String = ""
        Dim t As Double = 0
        If TxtClirut.Text = "" Then

            Dim SQL As String = "   SELECT    dbo.fichrece.frec_rutcli AS RUTCLIENTE, dbo.clientes.cli_nomb AS NOMBRECLIENTE, SUM(dbo.fichrece.frec_totsopo)AS SOPORTANTES ,CAST(SUM(dbo.fichrece.frec_totunidad)AS VARCHAR(10)) AS UNIDADES, CAST(SUM(dbo.fichrece.frec_totpeso) AS VARCHAR(10)) AS KILOS,CAST(SUM(dbo.fichrece.frec_totpeso) /1000 AS VARCHAR(10)) as TON " +
               "FROM            dbo.fichrece INNER JOIN dbo.clientes ON dbo.fichrece.frec_rutcli = dbo.clientes.cli_rut" +
               "   WHERE CONVERT(DATE,frec_fecrec) BETWEEN '" + devuelve_fecha(dtInicio.Value) + "' AND '" + devuelve_fecha(dtFinal.Value) + "' and dbo.fichrece.frec_RecepTunel = 2 GROUP BY dbo.fichrece.frec_rutcli, dbo.clientes.cli_nomb"



            DgvResultado.DataSource = fnc.ListarTablasSQL(SQL)
       
        Else

            Dim SQL As String = "   SELECT    dbo.fichrece.frec_rutcli AS RUTCLIENTE, dbo.clientes.cli_nomb AS NOMBRECLIENTE, SUM(dbo.fichrece.frec_totsopo) AS SOPORTANTES, CAST(SUM(dbo.fichrece.frec_totunidad)AS VARCHAR(10)) AS UNIDADES, CAST(SUM(dbo.fichrece.frec_totpeso) AS VARCHAR(10)) AS KILOS,CAST(SUM(dbo.fichrece.frec_totpeso) /1000 AS VARCHAR(10)) as TON " +
                      "FROM            dbo.fichrece INNER JOIN dbo.clientes ON dbo.fichrece.frec_rutcli = dbo.clientes.cli_rut" +
                      " WHERE frec_rutcli = '" + TxtClirut.Text + "'  " +
                  "   AND CONVERT(DATE,frec_fecrec) BETWEEN '" + devuelve_fecha(dtInicio.Value) + "' AND '" + devuelve_fecha(dtFinal.Value) + "' and dbo.fichrece.frec_RecepTunel = 2 GROUP BY dbo.fichrece.frec_rutcli, dbo.clientes.cli_nomb"

            DgvResultado.DataSource = fnc.ListarTablasSQL(SQL)
 
        End If


        txtkilos.Text = "0"
        For i As Integer = 0 To DgvResultado.Rows.Count - 1
            'CALCULA TOTAL DE TONELADAS
            val = Me.DgvResultado.Rows(i).Cells(5).Value
            val = val.Replace(".", ",")
            Me.DgvResultado.Rows(i).Cells(5).Value = Math.Round(Convert.ToDecimal(val), 1)
            val = Math.Round(Convert.ToDecimal(val), 1)
            suma = CDbl(val.ToString) + suma
            '''''''''''''''''''''''''''''''''''''''''

            'TRANSFORMAR KILOS 


            st = Me.DgvResultado.Rows(i).Cells(4).Value.ToString
            st = st.Replace(".", ",")
            st = Math.Round(Convert.ToDecimal(st), 0).ToString
            st = Format(Convert.ToInt32(st), "##,##00").ToString
            Me.DgvResultado.Rows(i).Cells(4).Value = st



            ' k = Convert.ToDecimal(st)

            un = Convert.ToInt32(Me.DgvResultado.Rows(i).Cells(3).Value)


            sk = Me.DgvResultado.Rows(i).Cells(5).Value.ToString.Replace(".", ",")



            t = Convert.ToDecimal(sk)

            str = Format(un, "##,##00").ToString
       
            Me.DgvResultado.Rows(i).Cells(3).Value = str
         
        Next
        txtkilos.Text = suma
    End Sub

    Private Sub btn_BuscaCliente_Click(sender As System.Object, e As System.EventArgs) Handles btn_BuscaCliente.Click
        Dim frm As New Lst_AyudaClientes
        frm.ShowDialog(Frm_Principal)
        Frm_Principal.buscavalor = Frm_Principal.buscavalor

        If Len(Frm_Principal.buscavalor) >= 9 Then
            TxtClirut.Text = Frm_Principal.buscavalor
            txtclinom.Text = RetornaCliente(Frm_Principal.buscavalor)
        End If
        Frm_Principal.buscavalor = ""
    End Sub

    Private Sub Frm_InformeTunel_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        f_tuneleskilos = False
    End Sub

    Private Sub btn_nuevo_Click(sender As System.Object, e As System.EventArgs) Handles btn_nuevo.Click
        txtclinom.Text = ""
        TxtClirut.Text = ""
        While (DgvResultado.Rows.Count > 0)
            DgvResultado.Rows.RemoveAt(0)
        End While
        txtkilos.Text = ""
    End Sub

    Private Sub Frm_InformeTunel_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Frm_Principal.buscavalor = ""
    End Sub
End Class
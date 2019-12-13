Public Class Frm_CamionesAndenDespacho

    Private fnc As New Funciones


    Private Sub Frm_CamionesAnden_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'DgvCamiones.DataSource = fnc.ListarTablasSQL("SELECT cl_fol, cl_rutcli, cli_nomb, cl_chorut, cho_nombre " +
        '                                             "FROM clientes, choferes, zchecklist WHERE cl_rutcli=cli_rut AND cl_chorut=cho_rut AND cl_estpor<>'0' AND " +
        '                                             "cl_estfrigo='0' AND cl_mov<>'2' AND (cl_des is null OR convert(date,Cl_Lleg,103)>=convert(date,DATEADD(day,-1,GETDATE()),103) AND Cl_Estfrigo=0)")

        DgvCamiones.DataSource = fnc.ListarTablasSQL("select a.cl_fol,a.cl_rutcli,b.cli_nomb,a.cl_chorut,c.cho_nombre from zCheckList a with(nolock) inner join clientes b with(nolock) on(a.Cl_RutCli=b.cli_rut) inner join choferes c with(nolock) on(a.Cl_chorut=c.cho_rut) left outer join Camiones_Carga_Descarga d with(nolock) on(a.Cl_fol=d.Folio_Camion) where a.Cl_EstPor<>'0' and a.Cl_Estfrigo='0' and a.Cl_Mov<>'2' and(a.Cl_Des is null OR (convert(date,a.Cl_Lleg,103)>=convert(date,DATEADD(day,-1,GETDATE()),103) AND a.Cl_Estfrigo=0)) and ISNULL(d.Estado_Despacho,0)=0")

    End Sub

    Private Sub DgvCamiones_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvCamiones.CellDoubleClick
        If e.RowIndex > -1 Then
            Dim _formInterface As IForm = CType(Me.Owner, IForm)
            _formInterface.ChangeTextBoxText(DgvCamiones.Rows(e.RowIndex).Cells(0).Value.ToString())
            Me.Close()
        End If
    End Sub

    Private Sub CbNoSeEncuentra_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CbNoSeEncuentra.CheckedChanged
        If CbNoSeEncuentra.Checked = True Then
            If MsgBox("Comenzar la recepcion con un camion no registrado", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Aviso") = vbYes Then
                Dim _formInterface As IForm = CType(Me.Owner, IForm)
                _formInterface.ChangeTextBoxText("NO")
                Me.Close()
            End If
            CbNoSeEncuentra.Checked = False
        End If
    End Sub
End Class
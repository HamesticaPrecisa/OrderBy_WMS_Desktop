Public Class Frm_ModificaSAG

    Dim fuente As Font
    Dim fnc As New Funciones
    Dim COM1 As New ImpresionCOM1
    Dim modifi As String = ""
    Dim NumeroPallet As String = ""
    Dim valorRecibido As String = ""
    Public mensaje As String = ""
    Dim fila_grilladetalle As Integer = -1
    Dim OBSERVACION_VAS As String = ""

    Dim modificacion As Boolean = False
    Dim pesopa As Integer = 0
    Dim TxtNpallets As String = "0"
    Dim TxtPromTemp As String = "0"
    Dim DiasVenc As Integer = 0
    Private Sub BtnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles BtnBuscar.Click
        ' Dim f As 
        Frm_ListadoRecepcion.ShowDialog(Frm_Principal)
        'modificacion = False
        If Frm_Principal.buscavalor.ToString() <> "" Then
            TxtCodRece.Text = Frm_Principal.buscavalor.ToString()
            TxtCodRece.Enabled = False
            BuscaRecepcionCompleta()
            'Tab_Detalle.Enabled = True
            Frm_Principal.buscavalor = ""
        End If
    End Sub
    Sub BuscaRecepcionCompleta()
        Dim sql As String = "SELECT drec_codi AS pallet, drec_codpro, mae_descr , drec_codsopo, tsop_descr, drec_unidades, " +
              "drec_peso, CONVERT(datetime,drec_fecprod,111) AS drec_fecprod, REPLACE(FechaVencimiento,'/','-') AS FechaVencimiento, LoteCliente,  drec_codsag, drec_sopocli, drec_temp, isnull(drec_arriendo,0) as drec_arriendo,estpallet " +
              "FROM DetaRece, maeprod, tiposopo  WHERE mae_codi=drec_codpro AND drec_codsopo=convert(int,tsop_codi) " +
              "AND frec_codi1 ='" + CerosAnteriorString(TxtCodRece.Text, 7) + "' ORDER BY drec_codi ASC"

        DetaRece.DataSource = fnc.ListarTablasSQL(sql)
     
         
    End Sub

    Private Sub DetaRece_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DetaRece.CellDoubleClick
        Label2.Text = Me.DetaRece.Rows(e.RowIndex).Cells("Cod_Pallet").Value.ToString()
      
        txtcodsag.Text = Me.DetaRece.Rows(e.RowIndex).Cells("Codsag").Value.ToString()
        btn_guardar.Enabled = True

    End Sub

    Private Sub btn_guardar_Click(sender As System.Object, e As System.EventArgs) Handles btn_guardar.Click
        If CheckBox1.Checked = False Then


            Dim sql As String = "UPDATE DETARECE SET  drec_codsag='" + txtcodsag.Text + "' " +
                                        "WHERE drec_codi='" + Label2.Text + "'"

            If fnc.MovimientoSQL(sql) > 0 Then
                MsgBox("Pallet actualizado ", MsgBoxStyle.Information, "Aviso")
                BuscaRecepcionCompleta()
                btn_guardar.Enabled = False
                Label2.Text = ""
                txtcodsag.Text = ""
                Dim _log As String = "INSERT INTO LOG_FichRece(LFR_CODI, LFR_FECHA, LFR_HORA, LFR_USUARIO, LFR_PC)" +
                                "VALUES('" + TxtCodRece.Text + "','" + devuelve_fecha(fnc.DevuelveFechaServidor()) + "'," +
                                "'" + DevuelveHora() + "','" + Frm_Principal.InfoUsuario.Text + "','" + My.Computer.Name.ToString() + "')"
                fnc.MovimientoSQL(_log)


            End If
        End If
        If CheckBox1.Checked = True Then


            Dim sql2 As String = "UPDATE DETARECE SET  drec_codsag='" + txtcodsag.Text + "' " +
                                        "WHERE frec_codi1='" + TxtCodRece.Text + "'"

            If fnc.MovimientoSQL(sql2) > 0 Then
                MsgBox("Recepcion actualizada ", MsgBoxStyle.Information, "Aviso")
                BuscaRecepcionCompleta()
                btn_guardar.Enabled = False
                Label2.Text = ""
                txtcodsag.Text = ""
                Dim _log As String = "INSERT INTO LOG_FichRece(LFR_CODI, LFR_FECHA, LFR_HORA, LFR_USUARIO, LFR_PC)" +
                                "VALUES('" + TxtCodRece.Text + "','" + devuelve_fecha(fnc.DevuelveFechaServidor()) + "'," +
                                "'" + DevuelveHora() + "','" + Frm_Principal.InfoUsuario.Text + "','" + My.Computer.Name.ToString() + "')"
                fnc.MovimientoSQL(_log)
                CheckBox1.Checked = False
                Label1.Visible = True
                Label2.Visible = True
                btn_guardar.Enabled = False
            End If


        End If

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            Label1.Visible = False
            Label2.Visible = False
            btn_guardar.Enabled = True
        End If
        If CheckBox1.Checked = False Then
            Label1.Visible = True
            Label2.Visible = True
            btn_guardar.Enabled = False
        End If
    End Sub

    Private Sub Frm_ModificaSAG_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        CheckBox1.Checked = False
    End Sub

    Private Sub Frm_ModificaSAG_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        f_rcp = False
    End Sub
End Class
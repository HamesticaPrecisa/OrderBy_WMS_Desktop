Public Class Frm_ContDeta

    Dim fnc As New Funciones
    Dim check As Boolean = False
    Dim ModDatos = True

    Private Sub Frm_ContDeta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RevisaGrabado()

        '-----------------
        llenaResolucion()
        llenaEtiquetado()
        llenaRevision()
        '-----------------

        Dim s = "SELECT * FROM detacont WHERE dcon_cont='" + contenedor.Text + "'"
        Dim stable As DataTable = fnc.ListarTablasSQL(s)

        If stable.Rows.Count = 0 Then
            Dim SQL_DETA = "SELECT drec_codi FROM detarece INNER JOIN fichrece fr ON fr.frec_codi=LEFT(drec_codi,7) WHERE " +
                        "frec_contenedor='" + contenedor.Text + "' AND fr.frec_codi='" + guia.Text + "' "
            Dim tabla As DataTable = fnc.ListarTablasSQL(SQL_DETA)

            If tabla.Rows.Count > 0 Then
                For i As Integer = 0 To tabla.Rows.Count - 1
                    Dim SQL As String = "INSERT INTO detacont(dcon_cont, dcon_folio, dcon_este, dcon_estr)" +
                                   "VALUES('" + contenedor.Text + "','" + tabla.Rows(i)(0).ToString + "','0','0')"
                    fnc.MovimientoSQL(SQL)
                Next
            End If
        End If
        If RealizarAccion("024", "073", False) = False Then
            BtnGuardarEtiq.Enabled = False
            BtnGuardarRev.Enabled = False
            ModDatos = False
        End If
        SumaTotales()
    End Sub

    Sub SumaTotales()
        Dim suma_envases As Integer = 0
        Dim suma_peso As Integer = 0
        For Each row As DataGridViewRow In DgvEtiq.Rows
            suma_envases = suma_envases + row.Cells("caj1").Value
            suma_peso = suma_peso + row.Cells("kil1").Value
        Next

        TotSopoEtiq.Text = DgvEtiq.Rows.Count
        TotEnvEtiq.Text = suma_envases.ToString()
        TotPesoEtiq.Text = suma_peso.ToString()

        TotSopoRev.Text = DgvEtiq.Rows.Count
        TotEnvRev.Text = suma_envases.ToString()
        TotPesoRev.Text = suma_peso.ToString()

    End Sub

    Sub llenaResolucion()

        Dim sql As String = "SELECT pimp_reso, pimp_fecha, pimp_hora, descri, pimp_totsopo, pimp_totunid, pimp_totpeso " +
                            "FROM Proc_Importaciones INNER JOIN usuarios ON usu_codigo=pimp_usucod " +
                            "WHERE pimp_ncont='" + contenedor.Text + "' OR pimp_codrece='" + guia.Text + "'"

        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

        If tabla.Rows.Count > 0 Then
            txtreso.Text = tabla.Rows(0)(0).ToString()
            txtfecha.Text = devuelve_fecha_Formato2(tabla.Rows(0)(1).ToString())
            txthora.Text = tabla.Rows(0)(2).ToString().Remove(5, 3)
            responsable.Text = tabla.Rows(0)(3).ToString()
            txtsopo.Text = tabla.Rows(0)(4).ToString()
            txtenvases.Text = tabla.Rows(0)(5).ToString()
            txtkilos.Text = tabla.Rows(0)(6).ToString()

            Label14.Text = "INFORMACION DE LA RESOLUCION"
            Panel1.Visible = True
        Else
            Label14.Text = "EL CONTENEDOR SE ENCUENTRA BLOQUEADO"
            Panel1.Visible = False
        End If

    End Sub

    Sub llenaEtiquetado()

        Dim sql As String = "SELECT isnull(dcon_este,0) Est, drec_codi, mae_codi, mae_descr, drec_unidades, drec_peso, dcon_fet " +
                            "FROM detarece LEFT JOIN  detacont ON drec_codi=dcon_folio INNER JOIN maeprod ON mae_codi=drec_codpro " +
                            "WHERE  LEFT(drec_codi,7)='" + guia.Text + "' ORDER BY drec_codi"

        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

        If tabla.Rows.Count = 0 Then

            sql = "SELECT isnull(dcon_est,0) Est, drec_codi, mae_codi, mae_descr, drec_unidades, drec_peso " +
                    "FROM detarece LEFT JOIN  detacont ON drec_codi=dcon_folio INNER JOIN maeprod ON mae_codi=drec_codpro " +
                    "WHERE  LEFT(drec_codi,7)='" + guia.Text + "'  ORDER BY drec_codi"
            tabla = fnc.ListarTablasSQL(sql)
            DgvEtiq.DataSource = tabla

        Else
            DgvEtiq.DataSource = tabla

        End If

    End Sub

    Sub llenaRevision()

        Dim sql As String = "SELECT isnull(dcon_estr,0) Est, drec_codi, mae_codi, mae_descr, drec_unidades, drec_peso, dcon_fre, dcon_dr " +
                            "FROM detarece LEFT JOIN  detacont ON drec_codi=dcon_folio INNER JOIN maeprod ON mae_codi=drec_codpro " +
                            "WHERE  LEFT(drec_codi,7)='" + guia.Text + "'  ORDER BY drec_codi"

        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

        If tabla.Rows.Count = 0 Then
            sql = "SELECT isnull(dcon_est,0) Est, drec_codi, mae_codi, mae_descr, drec_unidades, drec_peso " +
                    "FROM detarece LEFT JOIN  detacont ON drec_codi=dcon_folio INNER JOIN maeprod ON mae_codi=drec_codpro " +
                    "WHERE  LEFT(drec_codi,7)='" + guia.Text + "'  ORDER BY drec_codi"

            tabla = fnc.ListarTablasSQL(sql)
            DgvRev.DataSource = tabla

        Else
            DgvRev.DataSource = tabla

        End If

    End Sub

    Sub RevisaGrabado()

        Dim sqlReg As String = "SELECT frec_rutcli, frec_contcli FROM fichrece WHERE frec_contenedor='" + contenedor.Text + "'"
        Dim tabla As DataTable = fnc.ListarTablasSQL(sqlReg)

        If tabla.Rows.Count > 0 Then
            Dim sql As String = "SELECT * FROM fichcont WHERE fcon_cont='" + contenedor.Text + "'"
            Dim tabla2 As DataTable = fnc.ListarTablasSQL(sql)
            If tabla2.Rows.Count = 0 Then
                sql = "INSERT INTO fichcont (fcon_cont, fcon_rutcli, fcon_contcli, fcon_fec, fcon_enca, fcon_est, fcon_petiq, fcon_prev)" +
                      "VALUES('" + contenedor.Text + "', '" + tabla.Rows(0)(0).ToString() + "', '" + tabla.Rows(0)(1).ToString() + "', GETDATE(), '" + Frm_Principal.InfoUsuario.Text + "', '0', '0', '0')"
                fnc.MovimientoSQL(sql)
            End If
        End If


    End Sub

    Private Sub DgvEtiq_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvEtiq.CellClick
        If e.RowIndex = -1 Or e.ColumnIndex = -1 Then
            Return
        End If
        If ModDatos = False Then
            Exit Sub
        End If
        If DgvEtiq.Columns(e.ColumnIndex).Name = "EST" Then
            Dim row As DataGridViewRow = DgvEtiq.Rows(e.RowIndex)
            Dim cellSelecion As DataGridViewCheckBoxCell = TryCast(row.Cells("EST"), DataGridViewCheckBoxCell)

            If cellSelecion.Value = 1 Then
                check = True
                cellSelecion.Value = 0
                row.Cells("FECHAE").Value = DBNull.Value
                CbEtiq.Checked = False
                check = False
            Else
                cellSelecion.Value = 1
            End If
        End If
    End Sub

    Private Sub CbEtiq_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CbEtiq.CheckStateChanged
        If ModDatos = False Then
            CbEtiq.Checked = False
            Exit Sub
        End If
        If check = False Then
            For Each row As DataGridViewRow In DgvEtiq.Rows
                If CbEtiq.Checked = True Then
                    row.Cells("EST").Value = 1
                Else
                    If row.Cells("FECHAE").Value.ToString() = "" Then
                        row.Cells("EST").Value = 0
                        row.Cells("FECHAE").Value = DBNull.Value
                    End If
                End If
            Next
        End If
    End Sub

    Private Sub DgvRev_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvRev.CellClick
        If ModDatos = False Then
            Exit Sub
        End If
        If e.RowIndex = -1 Or e.ColumnIndex = -1 Then
            Return
        End If
        If DgvRev.Columns(e.ColumnIndex).Name = "cb1" Then
            Dim row As DataGridViewRow = DgvRev.Rows(e.RowIndex)
            Dim cellSelecion As DataGridViewCheckBoxCell = TryCast(row.Cells("cb1"), DataGridViewCheckBoxCell)

            If cellSelecion.Value = 1 Then
                check = True
                cellSelecion.Value = 0
                row.Cells("FECHAR").Value = DBNull.Value
                CbRev.Checked = False
                check = False
            Else
                cellSelecion.Value = 1
            End If
        End If
    End Sub

    Private Sub CbRev_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CbRev.CheckStateChanged
        If ModDatos = False Then
            CbRev.Checked = False
            Exit Sub
        End If
        If check = False Then
            For Each row As DataGridViewRow In DgvRev.Rows
                If CbRev.Checked = True Then
                    row.Cells("cb1").Value = 1
                Else
                    If row.Cells("FECHAR").Value.ToString() = "" Then
                        row.Cells("cb1").Value = 0
                        row.Cells("FECHAR").Value = DBNull.Value
                    End If
                End If
            Next
        End If
    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardarEtiq.Click
        Dim contador As Integer = 0
        For Each row As DataGridViewRow In DgvEtiq.Rows
            If row.Cells("EST").Value.ToString() = "1" AndAlso Not row.Cells("FECHAE").Value.ToString() = "" Then

                Dim SQL As String = "UPDATE detacont SET dcon_usue='" + Frm_Principal.InfoUsuario.Text + "', dcon_fet='" + row.Cells("FECHAE").Value.ToString() + "', dcon_este='1' " +
                                               "WHERE dcon_cont='" + contenedor.Text + "' AND dcon_folio='" + row.Cells("pal1").Value.ToString() + "' AND dcon_este='0'"
                fnc.MovimientoSQL(SQL)
                contador += 1
            Else
                Dim SQL As String = "UPDATE detacont SET dcon_usue=null, dcon_fet=null, dcon_este='0' " +
                               "WHERE dcon_cont='" + contenedor.Text + "' AND dcon_folio='" + row.Cells("pal1").Value.ToString() + "' AND dcon_este='1'"
                fnc.MovimientoSQL(SQL)
            End If


        Next
        Dim SQL_LOG = "INSERT INTO LOG_CONTENEDORES(LCON_CONT, LCON_FECHA, LCON_USUCOD, LCON_TIPO, LCON_PC)" +
            "VALUES('" + contenedor.Text + "',GETDATE(),'" + Frm_Principal.InfoUsuario.Text + "','ETIQUETADO','" + My.Computer.Name.ToString() + "')"
        fnc.MovimientoSQL(SQL_LOG)

        Dim x As String = ""
        If contador = 0 Then
            x = "0"
        ElseIf contador = DgvEtiq.Rows.Count Then
            x = "2"
        Else
            x = "1"
        End If

        Dim query As String = "UPDATE fichcont SET fcon_petiq='" + x + "' WHERE fcon_cont='" + contenedor.Text + "'"
        fnc.MovimientoSQL(query)

        MsgBox("Información Actualizada", MsgBoxStyle.Information, "Aviso")
        llenaEtiquetado()
    End Sub

    Private Sub BtnFecha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFecha.Click
        If Convert.ToDateTime(fnc.DevuelveFechaServidor().ToShortDateString()) < Convert.ToDateTime(DateTimePicker1.Value.ToShortDateString()) Then
            MsgBox("No puede seleccionar una fecha superior al dia de hoy", MsgBoxStyle.Critical, "Aviso")
            Exit Sub
        End If
        For Each row As DataGridViewRow In DgvEtiq.Rows
            If row.Cells("EST").Value.ToString() = "1" Then
                If row.Cells("FECHAE").Value.ToString() = "" Then
                    row.Cells("FECHAE").Value = DateTimePicker1.Value
                End If
            End If
        Next
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If Convert.ToDateTime(fnc.DevuelveFechaServidor().ToShortDateString()) < Convert.ToDateTime(DateTimePicker2.Value.ToShortDateString()) Then
            MsgBox("No puede seleccionar una fecha superior al dia de hoy", MsgBoxStyle.Critical, "Aviso")
            Exit Sub

        ElseIf TxtDoc.Text = "" Then
            MsgBox("Debe agregar el nombre del doctor", MsgBoxStyle.Critical, "Aviso")
            Exit Sub
        End If

        For Each row As DataGridViewRow In DgvRev.Rows
            If row.Cells("cb1").Value.ToString() = "1" Then
                If row.Cells("FECHAR").Value.ToString() = "" Then
                    row.Cells("FECHAR").Value = DateTimePicker2.Value
                    row.Cells("DOCTOR").Value = TxtDoc.Text
                End If
            End If
        Next
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardarRev.Click
        Dim contador As Integer = 0


        For Each row As DataGridViewRow In DgvRev.Rows
            If row.Cells("cb1").Value.ToString() = "1" AndAlso Not row.Cells("FECHAR").Value.ToString() = "" Then
                Dim SQL As String = "UPDATE detacont SET dcon_usur='" + Frm_Principal.InfoUsuario.Text + "', dcon_fre='" + row.Cells("FECHAR").Value.ToString() + "', " +
                                    "dcon_estr='1', dcon_dr='" + row.Cells("DOCTOR").Value.ToString() + "' " +
                                    "WHERE dcon_cont='" + contenedor.Text + "' AND dcon_folio='" + row.Cells("pal2").Value.ToString() + "' AND dcon_estr='0'"
                fnc.MovimientoSQL(SQL)
                contador += 1
            Else
                Dim SQL As String = "UPDATE detacont SET dcon_usur=null, dcon_fre=null, dcon_estr='0' " +
                               "WHERE dcon_cont='" + contenedor.Text + "' AND dcon_folio='" + row.Cells("pal2").Value.ToString() + "' AND dcon_estr='1'"
                fnc.MovimientoSQL(SQL)
            End If

        Next
        Dim SQL_LOG = "INSERT INTO LOG_CONTENEDORES(LCON_CONT, LCON_FECHA, LCON_USUCOD, LCON_TIPO, LCON_PC)" +
            "VALUES('" + contenedor.Text + "',GETDATE(),'" + Frm_Principal.InfoUsuario.Text + "','REVISION','" + My.Computer.Name.ToString() + "')"
        fnc.MovimientoSQL(SQL_LOG)

        Dim x As String = ""
        If contador = 0 Then
            x = "0"
        ElseIf contador = DgvEtiq.Rows.Count Then
            x = "2"
        Else
            x = "1"
        End If

        Dim query As String = "UPDATE fichcont SET fcon_prev='" + x + "' WHERE fcon_cont='" + contenedor.Text + "'"
        fnc.MovimientoSQL(query)
        MsgBox("Información Actualizada", MsgBoxStyle.Information, "Aviso")
        llenaRevision()

    End Sub

    Private Sub BtnDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDetalle.Click
 
        Dim frm As Frm_MuestraReporte = New Frm_MuestraReporte
        frm.Text = "Asistente de informes - Informe de contenedores detallado"

        Dim report As New RptContenedoresDetallado

        report.SetDatabaseLogon(Usuario_ODBC, Pass_ODBC)
        report.SetParameterValue("codigo", contenedor.Text)

        frm.Contenedor.ReportSource = report
        frm.ShowDialog()

    End Sub

End Class
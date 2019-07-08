Public Class GeneraAuditoria
    Dim fnc As New Funciones
    Dim totalrack As Integer = 0
    Dim porcen As Integer = 0
    Dim toptop As Integer = 0
    Dim idauditoria As String = ""

    Private Sub GeneraAuditoria_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        TXTCANT.Text = "0"
        CBOCAMARAEX.DataSource = fnc.ListarTablasSQL("SELECT ncamara FROM camarasoperativas")
        CBOCAMARAEX.ValueMember = "ncamara"
        CBOCAMARAEX.DisplayMember = "ncamara"


        CHK1.Checked = True
        CHK2.Checked = True
        CHK3.Checked = True
        CHK4.Checked = True
        CHK5.Checked = True
        CHK6.Checked = True



    End Sub

    Private Sub Btn_GuardaDetalle_Click(sender As System.Object, e As System.EventArgs) Handles Btn_GuardaDetalle.Click
        If txtdes.Text = "" Then


         
        Else

            Dim sql = "SELECT  * FROM ficha_auditoria WHERE descripcion='" + txtdes.Text.Trim() + "'"

            Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

            If tabla.Rows.Count > 0 Then

                MsgBox("Ya existe una auditoria con este nombre", MsgBoxStyle.Critical, "Aviso")
                Exit Sub
            End If





            If CHK1.Checked = False And CHK2.Checked = False And CHK3.Checked = False And CHK4.Checked = False And CHK5.Checked = False And CHK6.Checked = False Then




            Else




                If CHK1.Checked = True And CHK2.Checked = True And CHK3.Checked = True And CHK4.Checked = True And CHK5.Checked = True And CHK6.Checked = True Then

                    Dim sql2 = "SELECT  COUNT(*) FROM rackdeta"

                    Dim tabla2 As DataTable = fnc.ListarTablasSQL(sql2)

                    If tabla2.Rows.Count > 0 Then
                        txtdes.Enabled = False
                        txtporcentaje.Enabled = False
                        CBOCAMARAEX.Enabled = False
                        totalrack = Convert.ToInt32(tabla2.Rows(0)(0).ToString())
                        porcen = Convert.ToInt32(txtporcentaje.Value)

                        toptop = porcen * totalrack / 100
                        TXTCANT.Text = toptop.ToString()
                        Dim sql3 As String = "select TOP  " + TXTCANT.Text.Trim() + "  racd_codi as PALLET,racd_ca as CAMARA,racd_ba AS BANDA,racd_co AS COLUMNA,racd_pi AS PISO,racd_ni AS NIVEL from rackdeta ORDER BY NEWID() "
                        Dim tabla3 As DataTable = fnc.ListarTablasSQL(sql3)
                        DgvResultado.DataSource = tabla3

                    End If
                Else

                    Dim _where As String = "  AND ( racd_ca =''   "

                    If CHK1.Checked = True Then

                        _where = _where + " or racd_ca ='" + CHK1.Text.Trim() + "' "

                    End If
                    If CHK2.Checked = True Then

                        _where = _where + " or racd_ca ='" + CHK2.Text.Trim() + "' "

                    End If
                    If CHK3.Checked = True Then

                        _where = _where + " or racd_ca ='" + CHK3.Text.Trim() + "' "

                    End If
                    If CHK4.Checked = True Then

                        _where = _where + " or racd_ca ='" + CHK4.Text.Trim() + "' "

                    End If
                    If CHK5.Checked = True Then

                        _where = _where + " or racd_ca ='" + CHK5.Text.Trim() + "' "

                    End If
                    If CHK6.Checked = True Then

                        _where = _where + " or racd_ca ='" + CHK6.Text.Trim() + "' "

                    End If

                    Dim sql2 = "SELECT  COUNT(*) FROM rackdeta WHERE racd_ca <>''" + _where + ")"

                    Dim tabla2 As DataTable = fnc.ListarTablasSQL(sql2)

                    If tabla2.Rows.Count > 0 Then
                        txtdes.Enabled = False
                        txtporcentaje.Enabled = False
                        CBOCAMARAEX.Enabled = False
                        totalrack = Convert.ToInt32(tabla2.Rows(0)(0).ToString())
                        porcen = Convert.ToInt32(txtporcentaje.Value)

                        toptop = porcen * totalrack / 100

                        TXTCANT.Text = toptop.ToString()

                        Dim sql3 As String = "select TOP  " + TXTCANT.Text.Trim() + "  racd_codi as PALLET,racd_ca as CAMARA,racd_ba AS BANDA,racd_co AS COLUMNA,racd_pi AS PISO,racd_ni AS NIVEL from  rackdeta   WHERE racd_codi <>''" + _where + ")" + "ORDER BY NEWID() "
                        Dim tabla3 As DataTable = fnc.ListarTablasSQL(sql3)
                        DgvResultado.DataSource = tabla3

                    End If

                End If

















            End If


        End If
    End Sub

    Private Sub GeneraAuditoria_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        f_auditoria = False
    End Sub

    Private Sub btn_nuevo_Click(sender As System.Object, e As System.EventArgs) Handles btn_nuevo.Click
        txtdes.Enabled = True
        CBOCAMARAEX.Enabled = True
        txtporcentaje.Value = 0
        txtporcentaje.Enabled = True
        TXTCANT.Text = "0"
        Dim sql3 As String = "select  racd_codi as PALLET,racd_ca as CAMARA,racd_ba AS BANDA,racd_co AS COLUMNA,racd_pi AS PISO,racd_ni AS NIVEL from rackdeta WHERE RACD_CODI ='1' ORDER BY NEWID() "
        Dim tabla3 As DataTable = fnc.ListarTablasSQL(sql3)
        DgvResultado.DataSource = tabla3
        CHK1.Checked = True
        CHK2.Checked = True
        CHK3.Checked = True
        CHK4.Checked = True
        CHK5.Checked = True
        CHK6.Checked = True
        txtdes.Text = ""
        txtdes.Focus()
        idauditoria = ""
    End Sub

    Private Sub btn_guardar_Click(sender As System.Object, e As System.EventArgs) Handles btn_guardar.Click
        If idauditoria = "" Then
        Else

            Exit Sub
        End If

        If TXTCANT.Text = "0" Then
            MsgBox("No existe lista a auditar", MsgBoxStyle.Critical, "Aviso")
        Else

            Dim ins As String = "INSERT INTO ficha_auditoria(Descripcion, ingreso, cantidad, porcentaje, usuario,tipo,estado) " +
                      "VALUES('" + txtdes.Text.Trim() + "',GETDATE()," +
                      "'" + TXTCANT.Text + "','" + txtporcentaje.Value.ToString() + "','" + Frm_Principal.InfoUsuario.Text + "','N','A')"
            fnc.MovimientoSQL(ins)

            Dim FOLIO As String = ""

            Dim TABLAS As DataTable = fnc.ListarTablasSQL("SELECT Idauditoriaficha FROM ficha_auditoria WHERE descripcion ='" + txtdes.Text.Trim() + "'")

            If TABLAS.Rows.Count > 0 Then
                FOLIO = TABLAS.Rows(0)(0).ToString()
            End If


            For i As Integer = 0 To DgvResultado.Rows.Count - 2

                Dim detalle As String = "INSERT INTO detalle_auditoria(idauditoriaficha, soportante, camara, banda, columna,piso,nivel,estado)" +
               "VALUES('" + FOLIO + "','" + DgvResultado.Rows(i).Cells(0).Value.ToString() + "'," +
               "'" + DgvResultado.Rows(i).Cells(1).Value.ToString() + "','" + DgvResultado.Rows(i).Cells(2).Value.ToString() + "','" + DgvResultado.Rows(i).Cells(3).Value.ToString() + "','" + DgvResultado.Rows(i).Cells(4).Value.ToString() + "','" + DgvResultado.Rows(i).Cells(5).Value.ToString() + "' , 'SL')"
                fnc.MovimientoSQL(detalle)


            Next
            MsgBox("Auditoria Generada Correctamente", MsgBoxStyle.Information, "Aviso")

        End If
    End Sub

    Private Sub ficha()



    End Sub

    Private Sub btnExcel_Click(sender As System.Object, e As System.EventArgs) Handles btnExcel.Click
        Call GridAExcel(DgvResultado)
    End Sub
    Private Sub traeauditoria()

        Dim tabla As DataTable = fnc.ListarTablasSQL("SELECT descripcion FROM ficha_auditoria " +
                                                        "WHERE IdAuditoriaFicha='" + idauditoria + "'")

        If tabla.Rows.Count > 0 Then
            txtdes.Text = tabla.Rows(0)(0)

        End If
        Dim sql3 As String = "select soportante as PALLET,camara as CÁMARA,banda AS BANDA,columna AS COLUMNA,piso AS PISO,nivel AS NIVEL,'POSICIÓN FÍSICA'=isnull(PosicionReal,''),OBSERVACIÓN=isnull(Observacion,''),'ÚLTIMO MOVIMIENTO'=isnull(ResponsableUltima,''),estado as ESTADO from DETALLE_AUDITORIA  WHERE IdAuditoriaFicha = '" + idauditoria + "'  ORDER BY CAMARA "
        Dim tabla3 As DataTable = fnc.ListarTablasSQL(sql3)
        DgvResultado.DataSource = tabla3

    End Sub
    Private Sub Btn_cliente_Click(sender As System.Object, e As System.EventArgs) Handles Btn_cliente.Click
        Dim frm As New Lst_AyudaAuditoria

        frm.ShowDialog(Frm_Principal)
        If Frm_Principal.buscavalor <> "" Then
            idauditoria = Frm_Principal.buscavalor.ToString()
            traeauditoria()

        End If
    End Sub
End Class
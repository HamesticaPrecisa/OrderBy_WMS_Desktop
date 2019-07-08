Public Class Frm_AddFormatoEtiqueta
    Dim fnc As New Funciones
    Dim valorRecibido As String = ""
    Dim largo As Int32 = 0
    Private Sub btn_BuscaCliente_Click(sender As System.Object, e As System.EventArgs) Handles btn_BuscaCliente.Click
        Dim frm As New Lst_AyudaClientes
        frm.ShowDialog(Frm_Principal)
        Me.valorRecibido = Frm_Principal.buscavalor

        If Len(valorRecibido) >= 9 Then

            Dim SqlBusca As String = "SELECT cli_nomb, cli_estado FROM clientes WHERE " +
                "cli_rut='" + valorRecibido + "'"

            Dim tabla As DataTable = fnc.ListarTablasSQL(SqlBusca)

            If tabla.Rows.Count > 0 Then
                If tabla.Rows(0)(1).ToString() = "N" Then
                    MsgBox("El cliente seleccionado se encuentra bloqueado", MsgBoxStyle.Critical, "Aviso")
                    Exit Sub
                End If

                TxtClirut.Text = valorRecibido
                txtclinom.Text = tabla.Rows(0)(0).ToString()

           
                CBOETIQUETA.DataSource = fnc.ListarTablasSQL("SELECT etiq_descripcion FROM EtiquetaCliente  where etiq_rutclie='" + TxtClirut.Text + "' ORDER BY etiq_descripcion DESC")
                CBOETIQUETA.ValueMember = "etiq_descripcion"
                CBOETIQUETA.DisplayMember = "etiq_descripcion"
                CBOETIQUETA.Text = ""
                TXTDESCRIP.Text = ""
                TXTLARGO.Text = ""
                TXTMUESTRA.Text = ""
                CBOETIQUETA.Text = ""
                TXTINI.Text = ""
                TXTINI2.Text = ""
                TXTINI3.Text = ""
                TXTINI4.Text = ""
                TXTINI5.Text = ""
                TXTINI6.Text = ""
                TXTINI7.Text = ""
                TXTINI8.Text = ""
                TXTFIN.Text = ""
                TXTFIN2.Text = ""
                TXTFIN3.Text = ""
                TXTFIN4.Text = ""
                TXTFIN5.Text = ""
                TXTFIN6.Text = ""
                TXTFIN7.Text = ""
                TXTFIN8.Text = ""
                TXTPUNTO.Text = ""
                TXTINI9.Text = ""
                TXTFIN9.Text = ""

                Frm_Principal.buscavalor = ""

                '
                TxtClirut.Enabled = False
            Else
                MsgBox("El rut ingresado no existe", MsgBoxStyle.Information, "Aviso")
            End If
        End If
        Frm_Principal.buscavalor = ""
    End Sub

    Private Sub Frm_AddFormatoEtiqueta_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Frm_Principal.buscavalor = ""

        CBODETARECE.DataSource = fnc.ListarTablasSQL("SELECT detalle_rece FROM detalle_rece ORDER BY detalle_rece DESC")
        CBODETARECE.ValueMember = "detalle_rece"
        CBODETARECE.DisplayMember = "detalle_rece"
    End Sub

    Private Sub TXTINI_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TXTINI.KeyPress
        SoloNumeros(sender, e)
    End Sub

    Private Sub TXTFIN_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TXTFIN.KeyPress
        SoloNumeros(sender, e)
    End Sub

    Private Sub Frm_AddFormatoEtiqueta_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        f_eticli = False
    End Sub

    Private Sub btn_guardar_Click(sender As System.Object, e As System.EventArgs) Handles btn_guardar.Click


        If TXTDESCRIP.Text = "" Then
            MsgBox("No Existe Descripcion", MsgBoxStyle.Critical, "Aviso")
            Exit Sub
        End If
        If TXTLARGO.Text = "" Then
            MsgBox("No Existe largo", MsgBoxStyle.Critical, "Aviso")
            Exit Sub
        Else
            largo = Convert.ToInt32(TXTLARGO.Text.Trim())
        End If
        If TXTMUESTRA.Text = "" Then
            MsgBox("No Existe Muestra", MsgBoxStyle.Critical, "Aviso")
            Exit Sub
        End If


        If TXTINI.Text <> "" Then
            If Convert.ToInt32(TXTINI.Text.Trim) > largo Then

                MsgBox("Numero fuera de rango ", MsgBoxStyle.Critical, "Aviso")
                Exit Sub
            End If



        End If
        If TXTINI2.Text <> "" Then
            If Convert.ToInt32(TXTINI2.Text.Trim) > largo Then

                MsgBox("Numero fuera de rango ", MsgBoxStyle.Critical, "Aviso")
                Exit Sub
            End If



        End If
        If TXTINI3.Text <> "" Then
            If Convert.ToInt32(TXTINI3.Text.Trim) > largo Then

                MsgBox("Numero fuera de rango ", MsgBoxStyle.Critical, "Aviso")
                Exit Sub
            End If



        End If
        If TXTINI4.Text <> "" Then
            If Convert.ToInt32(TXTINI4.Text.Trim) > largo Then

                MsgBox("Numero fuera de rango ", MsgBoxStyle.Critical, "Aviso")
                Exit Sub
            End If



        End If
        If TXTINI5.Text <> "" Then
            If Convert.ToInt32(TXTINI5.Text.Trim) > largo Then

                MsgBox("Numero fuera de rango ", MsgBoxStyle.Critical, "Aviso")
                Exit Sub
            End If



        End If
        If TXTINI6.Text <> "" Then
            If Convert.ToInt32(TXTINI6.Text.Trim) > largo Then

                MsgBox("Numero fuera de rango ", MsgBoxStyle.Critical, "Aviso")
                Exit Sub
            End If



        End If
        If TXTINI7.Text <> "" Then
            If Convert.ToInt32(TXTINI7.Text.Trim) > largo Then

                MsgBox("Numero fuera de rango ", MsgBoxStyle.Critical, "Aviso")
                Exit Sub
            End If



        End If
        If TXTINI8.Text <> "" Then
            If Convert.ToInt32(TXTINI8.Text.Trim) > largo Then

                MsgBox("Numero fuera de rango ", MsgBoxStyle.Critical, "Aviso")
                Exit Sub
            End If

            Dim val1 As Int32 = Convert.ToInt32(TXTINI8.Text.Trim())
            Dim val2 As Int32 = Convert.ToInt32(TXTFIN8.Text.Trim()) + Convert.ToInt32(TXTINI8.Text.Trim())

            If TXTPUNTO.Text.Trim = "" Then

            Else

                Dim val As Int32 = Convert.ToInt32(TXTPUNTO.Text.Trim())

                If val > val1 And val < val2 Then


                Else
                    MsgBox("Decimal fuera de rango ", MsgBoxStyle.Critical, "Aviso")
                    Exit Sub

                End If

            End If
        End If
        If TXTFIN.Text <> "" Then
            If Convert.ToInt32(TXTFIN.Text.Trim) > largo Then

                MsgBox("Numero fuera de rango ", MsgBoxStyle.Critical, "Aviso")
                Exit Sub
            End If



        End If
        If TXTFIN2.Text <> "" Then
            If Convert.ToInt32(TXTFIN2.Text.Trim) > largo Then

                MsgBox("Numero fuera de rango ", MsgBoxStyle.Critical, "Aviso")
                Exit Sub
            End If



        End If
        If TXTFIN3.Text <> "" Then
            If Convert.ToInt32(TXTFIN3.Text.Trim) > largo Then

                MsgBox("Numero fuera de rango ", MsgBoxStyle.Critical, "Aviso")
                Exit Sub
            End If



        End If
        If TXTFIN4.Text <> "" Then
            If Convert.ToInt32(TXTFIN4.Text.Trim) > largo Then

                MsgBox("Numero fuera de rango ", MsgBoxStyle.Critical, "Aviso")
                Exit Sub
            End If



        End If
        If TXTFIN5.Text <> "" Then
            If Convert.ToInt32(TXTFIN5.Text.Trim) > largo Then

                MsgBox("Numero fuera de rango ", MsgBoxStyle.Critical, "Aviso")
                Exit Sub
            End If



        End If
        If TXTFIN6.Text <> "" Then
            If Convert.ToInt32(TXTFIN6.Text.Trim) > largo Then

                MsgBox("Numero fuera de rango ", MsgBoxStyle.Critical, "Aviso")
                Exit Sub
            End If



        End If
        If TXTFIN7.Text <> "" Then
            If Convert.ToInt32(TXTFIN7.Text.Trim) > largo Then

                MsgBox("Numero fuera de rango ", MsgBoxStyle.Critical, "Aviso")
                Exit Sub




            End If



        End If
        If TXTFIN8.Text <> "" Then
            If Convert.ToInt32(TXTFIN8.Text.Trim) > largo Then

                MsgBox("Numero fuera de rango ", MsgBoxStyle.Critical, "Aviso")
                Exit Sub
            End If



        End If


        If TXTFIN9.Text <> "" Then
            If Convert.ToInt32(TXTFIN9.Text.Trim) > largo Then

                MsgBox("Numero fuera de rango ", MsgBoxStyle.Critical, "Aviso")
                Exit Sub
            End If



        End If



        Dim sqlBusca = "SELECT * FROM EtiquetaCliente WHERE etiq_rutclie='" + TxtClirut.Text + "' and etiq_descripcion ='" + TXTDESCRIP.Text.Trim + "'"

        Dim tabla As DataTable = fnc.ListarTablasSQL(sqlBusca)
        If tabla.Rows.Count > 0 Then
            If TXTFIN.Text = "" Then
                TXTFIN.Text = "0"

            End If
            If TXTFIN2.Text = "" Then
                TXTFIN2.Text = "0"

            End If
            If TXTFIN3.Text = "" Then
                TXTFIN3.Text = "0"

            End If
            If TXTFIN4.Text = "" Then
                TXTFIN4.Text = "0"

            End If
            If TXTFIN5.Text = "" Then
                TXTFIN5.Text = "0"

            End If
            If TXTFIN6.Text = "" Then
                TXTFIN6.Text = "0"

            End If
            If TXTFIN7.Text = "" Then
                TXTFIN7.Text = "0"

            End If
            If TXTFIN8.Text = "" Then
                TXTFIN8.Text = "0"

            End If
            If TXTFIN9.Text = "" Then
                TXTFIN9.Text = "0"

            End If
            'MODIFICO


            Dim SQL_Modifica = "UPDATE EtiquetaCliente SET etiq_producto_inicio='" + TXTINI.Text.Trim() + "', etiq_producto_fin='" + TXTFIN.Text.Trim() + "', " +
              "etiq_soportante_inicio='" + TXTINI2.Text.Trim() + "', etiq_soportante_fin='" + TXTFIN2.Text.Trim() + "', etiq_felaboracion_inicio='" + TXTINI3.Text.Trim() + "', " +
              "etiq_felaboracion_fin='" + TXTFIN3.Text.Trim() + "', etiq_felaboracion_orden='" + cboela.Text + "', etiq_fvencimiento_inicio='" + TXTINI4.Text.Trim() + "', " +
              "etiq_fvencimiento_fin='" + TXTFIN4.Text.Trim() + "', etiq_fvencimiento_orden='" + cboven.Text + "', etiq_sopoclie_inicio='" + TXTINI5.Text.Trim() + "', " +
              "etiq_sopoclie_fin='" + TXTFIN5.Text.Trim() + "', etiq_lote_inicio='" + TXTINI9.Text.Trim() + "', " +
              "etiq_lote_fin='" + TXTFIN9.Text.Trim() + "', etiq_codsag_inicio='" + TXTINI6.Text.Trim() + "', etiq_codsag_fin='" + TXTFIN6.Text.Trim() + "', " +
              "etiq_unidades_inicio='" + TXTINI7.Text.Trim() + "', etiq_unidades_fin='" + TXTFIN7.Text.Trim() + "', etiq_kilos_inicio='" + TXTINI8.Text.Trim() + "', " +
              "etiq_kilos_fin='" + TXTFIN8.Text.Trim() + "', etiq_kilos_punto='" + TXTPUNTO.Text.Trim() + "' WHERE etiq_rutclie='" + TxtClirut.Text + "' and etiq_descripcion ='" + TXTDESCRIP.Text.Trim + "'"
            fnc.MovimientoSQL(SQL_Modifica)

            If fnc.MovimientoSQL(SQL_Modifica) > 0 Then
                MsgBox("Etiqueta modificada correctamente", MsgBoxStyle.Information, "Aviso")
            End If






        Else
            If TXTFIN.Text = "" Then
                TXTFIN.Text = "0"

            End If
            If TXTFIN2.Text = "" Then
                TXTFIN2.Text = "0"

            End If
            If TXTFIN3.Text = "" Then
                TXTFIN3.Text = "0"

            End If
            If TXTFIN4.Text = "" Then
                TXTFIN4.Text = "0"

            End If
            If TXTFIN5.Text = "" Then
                TXTFIN5.Text = "0"

            End If
            If TXTFIN6.Text = "" Then
                TXTFIN6.Text = "0"

            End If
            If TXTFIN7.Text = "" Then
                TXTFIN7.Text = "0"

            End If
            If TXTFIN8.Text = "" Then
                TXTFIN8.Text = "0"

            End If
            If TXTFIN9.Text = "" Then
                TXTFIN9.Text = "0"

            End If
            'AGREGO
            Dim sqlGuarda As String = "INSERT INTO EtiquetaCliente(etiq_rutclie,etiq_descripcion ,etiq_muestra ,etiq_largo,etiq_producto_inicio,etiq_producto_fin,etiq_soportante_inicio,etiq_soportante_fin,etiq_felaboracion_inicio,etiq_felaboracion_fin, " +
                   " etiq_felaboracion_orden,etiq_fvencimiento_inicio,etiq_fvencimiento_fin,etiq_fvencimiento_orden,etiq_sopoclie_inicio,etiq_sopoclie_fin,etiq_lote_inicio,etiq_lote_fin,etiq_codsag_inicio,etiq_codsag_fin, " +
                   " etiq_unidades_inicio,etiq_unidades_fin,etiq_kilos_inicio,etiq_kilos_fin,etiq_kilos_punto )VALUES" +
                   "('" + TxtClirut.Text + "','" + TXTDESCRIP.Text.Trim() + "','" + TXTMUESTRA.Text.Trim() + "','" + TXTLARGO.Text.Trim() + "','" + TXTINI.Text.Trim() + "'," +
                   "'" + TXTFIN.Text.Trim() + "','" + TXTINI2.Text.Trim() + "','" + TXTFIN2.Text.Trim() + "','" + TXTINI3.Text.Trim() + "','" + TXTFIN3.Text.Trim + "'," +
                   "'" + cboela.Text + "','" + TXTINI4.Text.Trim() + "','" + TXTFIN4.Text.Trim() + "','" + cboven.Text + "'," +
                   "'" + TXTINI5.Text.Trim() + "','" + TXTFIN5.Text.Trim() + "','" + TXTINI9.Text.Trim() + "','" + TXTFIN9.Text.Trim() + "'," +
                   "'" + TXTINI6.Text.Trim() + "','" + TXTFIN6.Text.Trim() + "'," +
                   "'" + TXTINI7.Text.Trim() + "','" + TXTFIN7.Text.Trim() + "','" + TXTINI8.Text.Trim() + "','" + TXTFIN8.Text.Trim() + "'," +
                   "'" + TXTPUNTO.Text.Trim() + "')"


            If fnc.MovimientoSQL(sqlGuarda) > 0 Then
                MsgBox("Etiqueta ingresada correctamente", MsgBoxStyle.Information, "Aviso")

                CBOETIQUETA.DataSource = fnc.ListarTablasSQL("SELECT etiq_descripcion FROM EtiquetaCliente  where etiq_rutclie='" + TxtClirut.Text + "' ORDER BY etiq_descripcion DESC")
                CBOETIQUETA.ValueMember = "etiq_descripcion"
                CBOETIQUETA.DisplayMember = "etiq_descripcion"
                CBOETIQUETA.Text = ""
                TXTDESCRIP.Text = ""
                TXTLARGO.Text = ""
                TXTMUESTRA.Text = ""
                CBOETIQUETA.Text = ""
                TXTINI.Text = ""
                TXTINI2.Text = ""
                TXTINI3.Text = ""
                TXTINI4.Text = ""
                TXTINI5.Text = ""
                TXTINI6.Text = ""
                TXTINI7.Text = ""
                TXTINI8.Text = ""
                TXTFIN.Text = ""
                TXTFIN2.Text = ""
                TXTFIN3.Text = ""
                TXTFIN4.Text = ""
                TXTFIN5.Text = ""
                TXTFIN6.Text = ""
                TXTFIN7.Text = ""
                TXTFIN8.Text = ""
                TXTPUNTO.Text = ""
                TXTINI9.Text = ""
                TXTFIN9.Text = ""
                TXTDESCRIP.Enabled = False
                TXTLARGO.Enabled = False
                TXTMUESTRA.Enabled = False
            End If
        End If


    End Sub
   
    Private Sub TXTINI2_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TXTINI2.KeyPress
        SoloNumeros(sender, e)
    End Sub

    Private Sub TXTINI3_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TXTINI3.KeyPress
        SoloNumeros(sender, e)
     
    End Sub

    Private Sub TXTINI4_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TXTINI4.KeyPress
        SoloNumeros(sender, e)
      
    End Sub

    Private Sub TXTINI5_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TXTINI5.KeyPress
        SoloNumeros(sender, e)
    End Sub

    Private Sub TXTINI6_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TXTINI6.KeyPress
        SoloNumeros(sender, e)
    End Sub

    Private Sub TXTINI7_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TXTINI7.KeyPress
        SoloNumeros(sender, e)
    End Sub

    Private Sub TXTINI8_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TXTINI8.KeyPress
        SoloNumeros(sender, e)
    End Sub

    Private Sub TXTFIN2_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TXTFIN2.KeyPress
        SoloNumeros(sender, e)
    End Sub

    Private Sub TXTFIN3_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TXTFIN3.KeyPress
        SoloNumeros(sender, e)
    End Sub

    Private Sub TXTFIN4_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TXTFIN4.KeyPress
        SoloNumeros(sender, e)
    End Sub

    Private Sub TXTFIN5_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TXTFIN5.KeyPress
        SoloNumeros(sender, e)
    End Sub

    Private Sub TXTFIN6_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TXTFIN6.KeyPress
        SoloNumeros(sender, e)
    End Sub

    Private Sub TXTFIN7_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TXTFIN7.KeyPress
        SoloNumeros(sender, e)
    End Sub

    Private Sub TXTFIN8_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TXTFIN8.KeyPress
        SoloNumeros(sender, e)
    End Sub

    Private Sub TextBox15_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TXTPUNTO.KeyPress
        SoloNumeros(sender, e)
    End Sub

    Private Sub TXTLARGO_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TXTLARGO.KeyPress
        SoloNumeros(sender, e)
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        TXTDESCRIP.Enabled = True
        TXTLARGO.Enabled = True
        TXTMUESTRA.Enabled = True
        TXTDESCRIP.Text = ""
        TXTLARGO.Text = ""
        TXTMUESTRA.Text = ""
        CBOETIQUETA.Text = ""
        TXTINI.Text = ""
        TXTINI2.Text = ""
        TXTINI3.Text = ""
        TXTINI4.Text = ""
        TXTINI5.Text = ""
        TXTINI6.Text = ""
        TXTINI7.Text = ""
        TXTINI8.Text = ""
        TXTFIN.Text = ""
        TXTFIN2.Text = ""
        TXTFIN3.Text = ""
        TXTFIN4.Text = ""
        TXTFIN5.Text = ""
        TXTFIN6.Text = ""
        TXTFIN7.Text = ""
        TXTFIN8.Text = ""
        TXTPUNTO.Text = ""
        TXTINI9.Text = ""
        TXTFIN9.Text = ""
        TXTDESCRIP.Focus()
    End Sub

    Private Sub CBOETIQUETA_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles CBOETIQUETA.SelectedIndexChanged
        Dim sqlBusca = "SELECT * FROM EtiquetaCliente WHERE etiq_rutclie='" + TxtClirut.Text + "' and etiq_descripcion ='" + CBOETIQUETA.Text.Trim + "'"

        Dim tabla As DataTable = fnc.ListarTablasSQL(sqlBusca)
        If tabla.Rows.Count > 0 Then
            TXTDESCRIP.Text = tabla.Rows(0)(2).ToString()
            TXTLARGO.Text = tabla.Rows(0)(4).ToString()
            largo = Convert.ToInt32(TXTLARGO.Text.Trim())
            TXTMUESTRA.Text = tabla.Rows(0)(3).ToString()

            TXTLARGO.Enabled = False
            TXTDESCRIP.Enabled = False
            TXTMUESTRA.Enabled = False

            TXTINI.Text = tabla.Rows(0)(5).ToString()
            TXTFIN.Text = tabla.Rows(0)(6).ToString()

            TXTINI2.Text = tabla.Rows(0)(7).ToString()
            TXTFIN2.Text = tabla.Rows(0)(8).ToString()

            TXTINI3.Text = tabla.Rows(0)(9).ToString()
            TXTFIN3.Text = tabla.Rows(0)(10).ToString()
            cboela.Text = tabla.Rows(0)(11).ToString()

            TXTINI4.Text = tabla.Rows(0)(12).ToString()
            TXTFIN4.Text = tabla.Rows(0)(13).ToString()
            cboven.Text = tabla.Rows(0)(14).ToString()

            TXTINI5.Text = tabla.Rows(0)(15).ToString()
            TXTFIN5.Text = tabla.Rows(0)(16).ToString()

            TXTINI9.Text = tabla.Rows(0)(17).ToString()
            TXTFIN9.Text = tabla.Rows(0)(18).ToString()

            TXTINI6.Text = tabla.Rows(0)(19).ToString()
            TXTFIN6.Text = tabla.Rows(0)(20).ToString()

            TXTINI7.Text = tabla.Rows(0)(21).ToString()
            TXTFIN7.Text = tabla.Rows(0)(22).ToString()

            TXTINI8.Text = tabla.Rows(0)(23).ToString()
            TXTFIN8.Text = tabla.Rows(0)(24).ToString()
            TXTPUNTO.Text = tabla.Rows(0)(25).ToString()

        End If
    End Sub

    Private Sub TXTINI9_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TXTINI9.KeyPress
        SoloNumeros(sender, e)
    End Sub

    Private Sub TXTFIN9_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TXTFIN9.KeyPress
        SoloNumeros(sender, e)
    End Sub

    Private Sub TXTINI3_TextChanged(sender As System.Object, e As System.EventArgs) Handles TXTINI3.TextChanged
        If TXTINI3.Text.Trim() = "" Then
            TXTFIN3.Text = "0"
        Else
            TXTFIN3.Text = "8"
        End If
    End Sub

    Private Sub TXTINI4_TextChanged(sender As System.Object, e As System.EventArgs) Handles TXTINI4.TextChanged
        If TXTINI4.Text.Trim() = "" Then
            TXTFIN4.Text = "0"
        Else
            TXTFIN4.Text = "8"
        End If
    End Sub
End Class
Public Class Frm_ConfInicialCamaras
    Dim fnc As New Funciones
    Dim cap As String = ""
    Dim cpb As String = ""
    Dim crs As String = ""
    Dim cdi As String = ""
    Dim clb As String = ""
    Dim entrada As String = ""
    Dim transito As String = ""
    Dim zonap As String = ""
    Private Sub TxtCodCamara_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodCamara.KeyPress
        SoloNumeros(sender, e)
        If e.KeyChar = ChrW(13) Then
            If TxtCodCamara.Text = "" Then
                MsgBox("Debe ingresar el numero de camara", MsgBoxStyle.Critical, "Aviso")
                Exit Sub
            Else
                TxtCodCamara.Text = CerosAnteriorString(TxtCodCamara.Text, 2)
            End If


            Dim sql = "SELECT Ncamara,columnas,bandas,alturap,pisosp,apiso,rack_sel,push_back,drivein,libre,entrada,prefpos,trans,zonap from camaraconf where camara='" + TxtCodCamara.Text + " '"

            Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

            If tabla.Rows.Count > 0 Then

                txtNombreCam.Text = tabla.Rows(0)(0).ToString()
                txtCol.Text = tabla.Rows(0)(1).ToString()
                TxtBand.Text = tabla.Rows(0)(2).ToString()
                txtalturap.Text = tabla.Rows(0)(3).ToString()
                txtpisomax.Text = tabla.Rows(0)(4).ToString()
                If tabla.Rows(0)(10).ToString().Trim() = "P1" Then

                    p1.Checked = True

                End If
                If tabla.Rows(0)(10).ToString().Trim() = "P2" Then

                    p2.Checked = True

                End If
                If tabla.Rows(0)(10).ToString().Trim() = "P3" Then

                    p3.Checked = True

                End If
                If tabla.Rows(0)(10).ToString().Trim() = "P4" Then

                    p4.Checked = True

                End If
                If tabla.Rows(0)(10).ToString().Trim() = "P5" Then

                    p5.Checked = True

                End If
                If tabla.Rows(0)(10).ToString().Trim() = "P6" Then

                    p6.Checked = True

                End If
                If tabla.Rows(0)(10).ToString().Trim() = "P7" Then

                    p7.Checked = True

                End If
                If tabla.Rows(0)(10).ToString().Trim() = "P8" Then

                    p8.Checked = True

                End If

                If tabla.Rows(0)(12).ToString() = "1" Then


                    chktransito.Checked = True
                Else
                    chktransito.Checked = False

                End If
                If tabla.Rows(0)(13).ToString() = "1" Then


                    chkzonaped.Checked = True
                Else

                    chkzonaped.Checked = False
                End If
                cboprefpos.Text = tabla.Rows(0)(11).ToString.Trim()
                If tabla.Rows(0)(5).ToString().Trim() = "SI" Then

                    chk_apiso.Checked = True
                Else
                    chk_apiso.Checked = False
                End If
                If tabla.Rows(0)(6).ToString().Trim() = "SI" Then

                    chk_rackselect.Checked = True
                Else
                    chk_rackselect.Checked = False
                End If
                If tabla.Rows(0)(7).ToString().Trim() = "SI" Then

                    chk_pushback.Checked = True
                Else
                    chk_pushback.Checked = False
                End If
                If tabla.Rows(0)(8).ToString().Trim() = "SI" Then

                    chk_drivein.Checked = True
                Else
                    chk_drivein.Checked = False
                End If
                If tabla.Rows(0)(9).ToString().Trim() = "SI" Then

                    chk_libre.Checked = True
                Else
                    chk_libre.Checked = False
                End If
            Else
     
                txtNombreCam.Text = ""
                txtCol.Text = ""
                TxtBand.Text = ""
                txtalturap.Text = ""
                txtpisomax.Text = ""
                chk_apiso.Checked = False
                chk_drivein.Checked = False
                chk_pushback.Checked = False
                chk_rackselect.Checked = False
                chk_libre.Checked = False




            End If

        End If
    End Sub
    Private Sub llenatipopos()
        cap = ""
        cpb = ""
        crs = ""
        cdi = ""
        clb = ""
        If chk_apiso.Checked = True Then
            cap = "SI"
        Else
            cap = ""
        End If
        If chk_pushback.Checked = True Then
            cpb = "SI"
        Else
            cpb = ""
        End If

        If chk_rackselect.Checked = True Then
            crs = "SI"
        Else
            crs = ""
        End If

        If chk_drivein.Checked = True Then
            cdi = "SI"
        Else
            cdi = ""
        End If

        If chk_libre.Checked = True Then
            clb = "SI"
        Else
            clb = ""
        End If





    End Sub
    Private Sub btn_guardar_Click(sender As System.Object, e As System.EventArgs) Handles btn_guardar.Click
        Dim tipoalma As String = ""
        If TxtCodCamara.Text = "" Then
            Exit Sub

        End If


        If Convert.ToInt32(txtpisomax.Text.Trim()) > 7 Then

         
            MsgBox("El maximo de pisos es de 7 favor rectificar", MsgBoxStyle.Critical, "Aviso")
            Exit Sub

            End If

        llenatipopos()
        If chkzonaped.Checked = True Then
            zonap = "1"
        Else
            zonap = "0"

        End If
        If rb_C.Checked = True Then
            tipoalma = "C"

        End If
        If rb_R.Checked = True Then
            tipoalma = "R"

        End If
        If rb_S.Checked = True Then
            tipoalma = "S"

        End If

        If chktransito.Checked = True Then
            transito = "1"
        Else
            transito = "0"
        End If
        If fnc.verificaExistencia("CamaraConf", "camara", TxtCodCamara.Text) = True Then
            'modificar
            If RealizarAccion("012", "034") = False Then
                Exit Sub
            End If
            Dim sql As String = "UPDATE CamaraConf SET  Ncamara='" + txtNombreCam.Text + "' , columnas='" + txtCol.Text + "',bandas='" + TxtBand.Text + "',alturap='" + txtalturap.Text + "',Pisosp='" + txtpisomax.Text + "' ,apiso='" + cap + "' ,rack_sel='" + crs + "',push_back='" + cpb + "',drivein='" + cdi + "',libre='" + clb + "' , entrada ='" + entrada + "',Prefpos='" + cboprefpos.Text.Trim() + "',tipo_almacen='" + tipoalma + "',trans='" + transito + "',zonap ='" + zonap.Trim() + "'  WHERE camara='" + CerosAnteriorString(TxtCodCamara.Text, 2) + "'"




            If fnc.MovimientoSQL(sql) > 0 Then

                MsgBox("Camara actualizada correctamente", MsgBoxStyle.Information, "Aviso")

                Dim sql2 As String = "UPDATE CamaraMantenedor SET  NombreCamara='" + txtNombreCam.Text + "'  WHERE camara='" + CerosAnteriorString(TxtCodCamara.Text, 2) + "'"
                fnc.MovimientoSQL(sql2)
            Else
                MsgBox("Error al actualizar La camara  ", MsgBoxStyle.Critical, "Aviso")
            End If

        Else

            'Insertar

            Dim sql As String = "INSERT INTO CamaraConf ( camara,Ncamara,columnas,bandas,alturap,pisosp,apiso,rack_sel,push_back,drivein,libre,entrada,prefpos,tipo_almacen,trans,zonap)VALUES('" + TxtCodCamara.Text + "'," +
                    "'" + txtNombreCam.Text + "','" + txtCol.Text + "','" + TxtBand.Text + "','" + txtalturap.Text + "','" + txtpisomax.Text + "','" + cap + "','" + crs + "','" + cpb + "','" + cdi + "','" + clb + "','" + entrada + "','" + cboprefpos.Text + "','" + tipoalma + "','" + transito + "','" + zonap.Trim() + "')"

            If fnc.MovimientoSQL(sql) > 0 Then

                MsgBox("Camara agregada correctamente", MsgBoxStyle.Information, "Aviso")
            Else
                MsgBox("Error al agregar La camara  ", MsgBoxStyle.Critical, "Aviso")
            End If

        End If
    End Sub

    Private Sub txtCol_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCol.KeyPress
        SoloNumeros(sender, e)
    End Sub

    Private Sub TxtBand_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBand.KeyPress
        SoloNumeros(sender, e)
    End Sub

    Private Sub txtpisomax_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtpisomax.KeyPress
        SoloNumeros(sender, e)
    End Sub

    Private Sub Frm_ConfInicialCamaras_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Frm_Principal.buscavalor = ""

        TxtCodCamara.Focus()
        rb_C.Checked = True
        cboprefpos.SelectedIndex = 0
    End Sub

    Private Sub Frm_ConfInicialCamaras_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        f_confcam = False
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chk_libre.CheckedChanged

    End Sub

    Private Sub p1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles p1.CheckedChanged
        entrada = "P1"
    End Sub

    Private Sub p2_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles p2.CheckedChanged
        entrada = "P2"
    End Sub

    Private Sub p3_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles p3.CheckedChanged
        entrada = "P3"
    End Sub

    Private Sub p4_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles p4.CheckedChanged
        entrada = "P4"
    End Sub

    Private Sub p5_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles p5.CheckedChanged
        entrada = "P5"
    End Sub

    Private Sub p6_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles p6.CheckedChanged
        entrada = "P6"
    End Sub

    Private Sub p7_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles p7.CheckedChanged
        entrada = "P7"
    End Sub

    Private Sub p8_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles p8.CheckedChanged
        entrada = "P8"
    End Sub

    Private Sub chkzonaped_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkzonaped.CheckedChanged
      
    End Sub

    Private Sub BtnOrigen_Click(sender As System.Object, e As System.EventArgs) Handles BtnOrigen.Click
        Dim frm As New Frm_AyudaCamaras
        frm.ShowDialog(Frm_Principal)
        If Frm_Principal.buscavalor.ToString() <> "" Then
            TxtCodCamara.Text = Frm_Principal.buscavalor
            Dim sql = "SELECT Ncamara,columnas,bandas,alturap,pisosp,apiso,rack_sel,push_back,drivein,libre,entrada,prefpos,trans,zonap from camaraconf where camara='" + TxtCodCamara.Text + " '"

            Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

            If tabla.Rows.Count > 0 Then

                txtNombreCam.Text = tabla.Rows(0)(0).ToString()
                txtCol.Text = tabla.Rows(0)(1).ToString()
                TxtBand.Text = tabla.Rows(0)(2).ToString()
                txtalturap.Text = tabla.Rows(0)(3).ToString()
                txtpisomax.Text = tabla.Rows(0)(4).ToString()
                If tabla.Rows(0)(10).ToString().Trim() = "P1" Then

                    p1.Checked = True

                End If
                If tabla.Rows(0)(10).ToString().Trim() = "P2" Then

                    p2.Checked = True

                End If
                If tabla.Rows(0)(10).ToString().Trim() = "P3" Then

                    p3.Checked = True

                End If
                If tabla.Rows(0)(10).ToString().Trim() = "P4" Then

                    p4.Checked = True

                End If
                If tabla.Rows(0)(10).ToString().Trim() = "P5" Then

                    p5.Checked = True

                End If
                If tabla.Rows(0)(10).ToString().Trim() = "P6" Then

                    p6.Checked = True

                End If
                If tabla.Rows(0)(10).ToString().Trim() = "P7" Then

                    p7.Checked = True

                End If
                If tabla.Rows(0)(10).ToString().Trim() = "P8" Then

                    p8.Checked = True

                End If

                If tabla.Rows(0)(12).ToString() = "1" Then


                    chktransito.Checked = True
                Else
                    chktransito.Checked = False

                End If
                If tabla.Rows(0)(13).ToString() = "1" Then


                    chkzonaped.Checked = True
                Else

                    chkzonaped.Checked = False
                End If
                cboprefpos.Text = tabla.Rows(0)(11).ToString.Trim()
                If tabla.Rows(0)(5).ToString().Trim() = "SI" Then

                    chk_apiso.Checked = True
                Else
                    chk_apiso.Checked = False
                End If
                If tabla.Rows(0)(6).ToString().Trim() = "SI" Then

                    chk_rackselect.Checked = True
                Else
                    chk_rackselect.Checked = False
                End If
                If tabla.Rows(0)(7).ToString().Trim() = "SI" Then

                    chk_pushback.Checked = True
                Else
                    chk_pushback.Checked = False
                End If
                If tabla.Rows(0)(8).ToString().Trim() = "SI" Then

                    chk_drivein.Checked = True
                Else
                    chk_drivein.Checked = False
                End If
                If tabla.Rows(0)(9).ToString().Trim() = "SI" Then

                    chk_libre.Checked = True
                Else
                    chk_libre.Checked = False
                End If
            Else

                txtNombreCam.Text = ""
                txtCol.Text = ""
                TxtBand.Text = ""
                txtalturap.Text = ""
                txtpisomax.Text = ""
                chk_apiso.Checked = False
                chk_drivein.Checked = False
                chk_pushback.Checked = False
                chk_rackselect.Checked = False
                chk_libre.Checked = False




            End If
            Frm_Principal.buscavalor = ""
        End If
    End Sub
End Class
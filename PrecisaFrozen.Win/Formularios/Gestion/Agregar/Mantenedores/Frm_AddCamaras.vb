Public Class Frm_AddCamaras

    Dim fnc As New Funciones


    Function valida()
        Dim valor As Integer = 0
        If txtdescr.Text = "" Then
            valor += 1
        ElseIf txtcol.Text = "" Then
            valor += 1
        ElseIf txtpis.Text = "" Then
            valor += 1
        ElseIf txtniv.Text = "" Then
            valor += 1
        ElseIf txttemp.Text = "" Then
            valor += 1
        ElseIf txthum.Text = "" Then
            valor += 1
        ElseIf mts3.Text = "" Then
            valor += 1
        ElseIf txtbdaini.Text = "" Then
            valor += 1
        ElseIf txtbdafin.Text = "" Then
            valor += 1
        ElseIf capacidad.Text.Trim = "" Then
            valor += 1
        ElseIf IsNumeric(capacidad) Then
            valor += 1
        End If

        Return valor
    End Function

    Private Sub Frm_AddCamaras_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        f_addcamaras = False
        btn_nuevo_Click(sender, e)
    End Sub

    Private Sub btn_guardar_Click(sender As System.Object, e As System.EventArgs) Handles btn_guardar.Click
        If valida() = 0 Then

            If fnc.verificaExistencia("camaras", "cam_codi", txtcodigo.Text) = False Then
                Dim sql = "INSERT INTO camaras(cam_codi, cam_descr, cam_numcol, cam_numpiso, cam_numnive, cam_temper, cam_humed, cam_capm3, cam_baninic, cam_banfin, cam_capa)" +
                    "VALUES('" + txtcodigo.Text + "','" + txtdescr.Text + "','" + txtcol.Text + "','" + txtpis.Text + "','" + txtniv.Text + "','" + txttemp.Text + "'," +
                    "'" + txthum.Text + "','" + mts3.Text + "','" + txtbdaini.Text + "','" + txtbdafin.Text + "','" + capacidad.Text + "')"

                If fnc.MovimientoSQL(sql) > 0 Then
                    MsgBox("Camara almacenada correctamente", MsgBoxStyle.Information, "Aviso")
                Else
                    MsgBox("Error al ingresar la camara", MsgBoxStyle.Critical, "Aviso")
                End If

            Else
                'actualizar
                If RealizarAccion("006", "015") = False Then
                    Exit Sub
                End If
                Dim sql = "UPDATE camaras SET cam_descr='" + txtdescr.Text + "', cam_numcol='" + txtcol.Text + "', " +
                    "cam_numpiso='" + txtpis.Text + "', cam_numnive='" + txtniv.Text + "', cam_temper='" + txttemp.Text + "', cam_humed='" + txthum.Text + "', " +
                    "cam_capm3='" + mts3.Text + "', cam_baninic='" + txtbdaini.Text + "', cam_banfin='" + txtbdafin.Text + "', cam_capa='" + capacidad.Text + "' " +
                    "WHERE cam_codi='" + txtcodigo.Text + "'"

                If fnc.MovimientoSQL(sql) > 0 Then
                    MsgBox("Camara actualizada correctamente", MsgBoxStyle.Information, "Aviso")
                Else
                    MsgBox("Error al actualizar la camara", MsgBoxStyle.Critical, "Aviso")
                End If

            End If
        Else

            MsgBox("Todos los campos son requeridos", MsgBoxStyle.Critical, "Aviso")

        End If
    End Sub

    Private Sub btn_nuevo_Click(sender As System.Object, e As System.EventArgs) Handles btn_nuevo.Click

        LimpiarCajas(GroupBox3)
        txtcodigo.Enabled = True

        txtdescr.Enabled = False
        txtcodigo.Focus()
    End Sub

    Private Sub btn_salir_Click(sender As System.Object, e As System.EventArgs) Handles btn_salir.Click
        Close()
    End Sub

    Private Sub btn_eliminar_Click(sender As System.Object, e As System.EventArgs) Handles btn_eliminar.Click

        If RealizarAccion("006", "016") = False Then
            Exit Sub
        End If
        If MsgBox("Esta seguro de eliminar la información seleccionada", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbYes Then
            If MsgBox("Esta por eliminar la información, desea continuar?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbYes Then

                Dim sql = "DELETE FROM camaras WHERE cam_codi='" + txtcodigo.Text + "'"
                If fnc.MovimientoSQL(sql) > 0 Then
                    MsgBox("Registro eliminado", MsgBoxStyle.Information, "Aviso")
                End If
            End If

        End If
    End Sub

    Private Sub txtcodigo_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtcodigo.KeyPress
        SoloNumeros(sender, e)
        If e.KeyChar = ChrW(13) Then
            If txtcodigo.Text = "" Then
                MsgBox("Debe ingresar el numero de camara", MsgBoxStyle.Critical, "Aviso")
                Exit Sub
            Else
                txtcodigo.Text = CerosAnteriorString(txtcodigo.Text, 2)
            End If


            Dim sql = "SELECT cam_descr, cam_numcol, cam_numpiso, cam_numnive, cam_temper, cam_humed, cam_capm3, " +
                 "cam_baninic, cam_banfin, cam_capa FROM camaras WHERE cam_codi='" + txtcodigo.Text + "'"

            Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

            If tabla.Rows.Count > 0 Then

                txtdescr.Text = tabla.Rows(0)(0).ToString()
                txtcol.Text = tabla.Rows(0)(1).ToString()
                txtpis.Text = tabla.Rows(0)(2).ToString()
                txtniv.Text = tabla.Rows(0)(3).ToString()
                txttemp.Text = tabla.Rows(0)(4).ToString()
                txthum.Text = tabla.Rows(0)(5).ToString()
                mts3.Text = tabla.Rows(0)(6).ToString()
                txtbdaini.Text = tabla.Rows(0)(7).ToString()
                txtbdafin.Text = tabla.Rows(0)(8).ToString()
                capacidad.Text = tabla.Rows(0)(9).ToString()
                txtdescr.Enabled = True
            Else
                
                If RealizarAccion("006", "014") = False Then
                    Exit Sub
                End If
                txtdescr.Focus()

                txtdescr.Enabled = True


            End If
            txtcodigo.Enabled = False
        End If
    End Sub

    Private Sub Frm_AddCamaras_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        txtcodigo.Focus()
    End Sub
 
    Private Sub txtcol_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtpis.KeyPress, txtniv.KeyPress, txtcol.KeyPress, txtbdaini.KeyPress, txtbdafin.KeyPress
        SoloNumeros(sender, e)
    End Sub


    Private Sub s(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles capacidad.KeyPress
        SoloNumeros(sender, e)
    End Sub
End Class
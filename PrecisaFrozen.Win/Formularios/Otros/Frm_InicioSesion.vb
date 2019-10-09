Imports System.Text.RegularExpressions
Imports System.Data.SqlClient

'
' VES OCT 2019
'
' EL CODIGO PARA LOGIN, QUE ORIGINALMENTE ESTABA REPETIDO TANTO EN EL EVENTO KEYPRESS DE TXTPASS COMO EN
' EVENTO CLICK DE BUTTON1, FUE CENTRALIZADO EN EL METODO INICIARSESION, Y EL CODIGO EN LOS MENCIONADOS 
' EVENTOS FUE MODIFICADO PARA INVOCAR EL NUEVO METODO
'

Public Class Frm_InicioSesion

    Dim fnc As New Funciones

    Private Sub Frm_InicioSesion_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        End
    End Sub

    Private Sub txtusu_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtusu.KeyPress
        If e.KeyChar = ChrW(13) Then
            txtpass.Focus()
        End If
    End Sub
    Private Function RemoveSpecialCharacters(ByVal str As String) As String
        Return Regex.Replace(str, "[^a-zA-Z0-9_.- ]+", "", RegexOptions.Compiled)
    End Function

    Private Sub txtpass_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpass.KeyPress
        '   Me.Hide()
        If e.KeyChar = ChrW(13) Then
            If txtusu.Text = "" Then
                txtpass.Focus()
            Else
                iniciarSesion()

                '        'busca usuario
                '        Dim sql As String = "SELECT usu_codigo, usu_nombre+' '+ usu_ap, sec_descr FROM usuarios, secciones " +
                '        "WHERE usu_usuario='" + txtusu.Text + "' AND usu_pass='" + Encriptar(txtpass.Text) + "' AND usu_seccod=sec_id  AND usu_codvig='1'"

                '        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)
                '        If tabla.Rows.Count > 0 Then


                '            Dim sql2 As String = "SELECT usu_codigo, usu_nombre+' '+ usu_ap, sec_descr FROM usuarios, secciones " +
                '           "WHERE usu_usuario='" + txtusu.Text + "' AND usu_pass='" + Encriptar(txtpass.Text) + "' AND usu_seccod=sec_id  AND usu_codvig='1' AND des_bodega='" + cbodesbod.Text + "'"

                '            Dim tabla2 As DataTable = fnc.ListarTablasSQL(sql2)
                '            If tabla2.Rows.Count > 0 Then
                '                Frm_Principal.InfoUsuario.Text = tabla.Rows(0)(0).ToString()
                '                Frm_Principal.lblnombre.Text = tabla.Rows(0)(1).ToString()
                '                Frm_Principal.lblseccion.Text = tabla.Rows(0)(2).ToString()
                '                Frm_Principal.Panel2.Visible = True
                '                Frm_Principal.LblNombre2.Text = tabla.Rows(0)(1).ToString()


                '                Dim sql3 As String = "select cod_bodega from mae_bodega where des_bodega='" + cbodesbod.Text + "'"

                '                Dim tabla3 As DataTable = fnc.ListarTablasSQL(sql3)
                '                If tabla3.Rows.Count > 0 Then
                '                    sucursalglo = tabla3.Rows(0)(0).ToString()
                '                    _wherepublic = " and (cod_bod='" + sucursalglo + "' or cod_bod is null)"
                '                End If
                '                Me.Hide()


                '            Else

                '                MsgBox("Usuario ingresado no Tiene Permisos en esta sucursal", MsgBoxStyle.Critical, "Aviso")
                '                txtpass.Text = ""


                '            End If








                '        Else
                '            MsgBox("Usuario ingresado no existe, o se encuentra bloqueado", MsgBoxStyle.Critical, "Aviso")
                '            txtpass.Text = ""
                '        End If

                '        '    Dim sql As String = "SELECT usu_codigo, usu_nombre+' '+ usu_ap, sec_descr FROM usuarios, secciones " +
                '        '        "WHERE usu_usuario='" + txtusu.Text + "' AND usu_pass='" + Encriptar(txtpass.Text) + "' AND usu_seccod=sec_id AND usu_codvig='1' "

                '        '    Dim tabla As DataTable = fnc.ListarTablasSQL(sql)
                '        '    If tabla.Rows.Count > 0 Then
                '        '        Frm_Principal.InfoUsuario.Text = tabla.Rows(0)(0).ToString()
                '        '        Frm_Principal.lblnombre.Text = tabla.Rows(0)(1).ToString()
                '        '        Frm_Principal.lblseccion.Text = tabla.Rows(0)(2).ToString()
                '        '        Frm_Principal.Panel2.Visible = True
                '        '        Frm_Principal.LblNombre2.Text = tabla.Rows(0)(1).ToString()
                '        '        Me.Hide()




                '        '    Else
                '        '        MsgBox("Usuario ingresado no existe, o se encuentra bloqueado", MsgBoxStyle.Critical, "Aviso")
                '        '        txtpass.Text = ""
                '        '    End If
                '        'End If
            End If
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        iniciarSesion()
    End Sub

    Private Sub txtusu_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtusu.LostFocus
        If txtusu.Text = "" Then
            txtusu.Text = "Nombre de usuario"
            txtusu.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub txtusu_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtusu.GotFocus
        If txtusu.Text = "Nombre de usuario" Then
            txtusu.Text = ""
            txtusu.ForeColor = Color.Black
            txtusu.PasswordChar = ""
        End If
    End Sub

    Private Sub Login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtpass.Text = "Contraseña"
        txtpass.ForeColor = Color.Silver
        ' txtusu.Text = "Nombre de usuario"
        txtusu.ForeColor = Color.Silver
        txtpass.PasswordChar = ""
        rlocal.Checked = True

        ' BtnSalir.Focus()
        txtusu.Focus()
        ' llenacom()
        ' cbodesbod.SelectedIndex = 1
        'cbodesbod.Enabled = False
        'rlocal.Checked = True

    End Sub

    Private Sub llenacom()


        cbodesbod.DataSource = fnc.ListarTablasSQL8("SELECT des_bodega  FROM mae_bodega ORDER BY Cod_Bodega ASC")
        If validacone = "NC" Then
            MsgBox("No existe una conexion habilitada ", MsgBoxStyle.Critical, "Aviso")
        Else
            cbodesbod.ValueMember = "des_bodega"
            cbodesbod.DisplayMember = "des_bodega"
        End If


    End Sub

    Private Sub txtpass_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtpass.LostFocus
        If txtpass.Text = "" Then
            txtpass.Text = "Contraseña"
            txtpass.ForeColor = Color.Gray
            txtpass.PasswordChar = ""
        End If
    End Sub

    Private Sub txtpass_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtpass.GotFocus
        If txtpass.Text = "Contraseña" Then
            txtpass.Text = ""
            txtpass.ForeColor = Color.Black
            txtpass.PasswordChar = "*"
        End If
    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub rlocal_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rlocal.CheckedChanged
        If rlocal.Checked = True Then
            validacone = ""
            CONECTARVARI = "LOCAL"
            'ip = "192.168.1.90"
            ip = CONFIG.lanIP ' VES Sep 2019


            llenacom()
            cbodesbod.SelectedIndex = 1
            txtusu.Focus()
        End If


    End Sub

    Private Sub rwlan_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rwlan.CheckedChanged
        If rwlan.Checked = True Then
            validacone = ""
            CONECTARVARI = "WLAN"
            'ip = "186.67.106.109"
            'ip = "192.168.1.68"
            ip = CONFIG.wlanIP  ' VES Sep 2019

            llenacom()


        End If
    End Sub

    Private Sub cbodesbod_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbodesbod.SelectedIndexChanged

    End Sub

    Private Sub iniciarSesion()
        If CONECTARVARI = "" Then

            MsgBox("Seleccione el tipo de red al que conectara", MsgBoxStyle.Critical, "Aviso")
            txtpass.Text = ""
            Exit Sub

        End If
        If txtusu.Text = "" Then
            txtpass.Focus()
        Else
            'busca usuario

            '
            ' VES OCT 2019
            '
            ' SE MODIFICO EL CODIGO PARA EVITAR EL SQL INJECTION, MEDIANTE EL USO
            ' DE CONSULTAS PARAMETRIZADAS
            '
            ' CODIGO ORIGINAL:
            ' Dim sql As String = "SELECT usu_codigo, usu_nombre+' '+ usu_ap, sec_descr FROM usuarios, secciones " +
            '     "WHERE usu_usuario='" + txtusu.Text + "' AND usu_pass='" + Encriptar(txtpass.Text.Trim()) + "' AND usu_seccod=sec_id  AND usu_codvig='1'"
            ' Dim tabla As DataTable = fnc.ListarTablasSQL(sql)
            '
            Dim sql As String = "SELECT usu_codigo, usu_nombre+' '+ usu_ap, sec_descr FROM usuarios, secciones " +
                "WHERE usu_usuario=@usu_usuario AND usu_pass=@usu_pass AND usu_seccod=sec_id  AND usu_codvig='1'"
            Dim tabla As DataTable = fnc.ListarTablasSQL(sql, _
                                                         New SqlParameter() { _
                                                             New SqlParameter("@usu_usuario", txtusu.Text.Trim()), _
                                                             New SqlParameter("@usu_pass", Encriptar(txtpass.Text.Trim())) _
                                                         })
            If tabla.Rows.Count > 0 Then


                '
                ' VES OCT 2019
                '
                ' SE MODIFICO EL CODIGO PARA EVITAR EL SQL INJECTION, MEDIANTE EL USO
                ' DE CONSULTAS PARAMETRIZADAS
                '
                ' CODIGO ORIGINAL:
                ' Dim sql2 As String = "SELECT usu_codigo, usu_nombre+' '+ usu_ap, sec_descr FROM usuarios, secciones " +
                ' "WHERE usu_usuario='" + txtusu.Text + "' AND usu_pass='" + Encriptar(txtpass.Text.Trim()) + "' AND usu_seccod=sec_id  AND usu_codvig='1' AND des_bodega='" + cbodesbod.Text + "'"
                ' Dim tabla2 As DataTable = fnc.ListarTablasSQL(sql2)
                '
                Dim sql2 As String = "SELECT usu_codigo, usu_nombre+' '+ usu_ap, sec_descr FROM usuarios, secciones " +
                "WHERE usu_usuario=@usu_usuario AND usu_pass=@usu_pass AND usu_seccod=sec_id  AND usu_codvig='1' AND des_bodega=@des_bodega"
                Dim tabla2 As DataTable = fnc.ListarTablasSQL(sql, _
                                                             New SqlParameter() { _
                                                                 New SqlParameter("@usu_usuario", txtusu.Text.Trim()), _
                                                                 New SqlParameter("@usu_pass", Encriptar(txtpass.Text.Trim())), _
                                                                 New SqlParameter("@des_bodega", cbodesbod.Text) _
                                                             })

                If tabla2.Rows.Count > 0 Then
                    Frm_Principal.InfoUsuario.Text = tabla.Rows(0)(0).ToString()
                    Frm_Principal.lblnombre.Text = tabla.Rows(0)(1).ToString()
                    Frm_Principal.lblseccion.Text = tabla.Rows(0)(2).ToString()
                    Frm_Principal.Panel2.Visible = True
                    Frm_Principal.LblNombre2.Text = tabla.Rows(0)(1).ToString()


                    '
                    ' VES OCT 2019
                    ' SE MODIFICO EL CODIGO PARA EVITAR EL SQL INJECTION, MEDIANTE EL USO
                    ' DE CONSULTAS PARAMETRIZADAS
                    '
                    ' CODIGO ORIGINAL:
                    ' Dim sql3 As String = "select cod_bodega from mae_bodega where des_bodega='" + cbodesbod.Text + "'"
                    ' Dim tabla3 As DataTable = fnc.ListarTablasSQL(sql3)
                    '
                    Dim sql3 As String = "select cod_bodega from mae_bodega where des_bodega=@des_bodega"
                    Dim tabla3 As DataTable = fnc.ListarTablasSQL(sql3, New SqlParameter() {New SqlParameter("@des_bodega", cbodesbod.Text)})
                    If tabla3.Rows.Count > 0 Then
                        sucursalglo = tabla3.Rows(0)(0).ToString()
                        _wherepublic = " and (cod_bod='" + sucursalglo + "' or cod_bod is null)"
                        sucudes = cbodesbod.Text
                    End If
                    Frm_Principal.verificaPrivilegios()
                    Frm_Principal.Timer1.Start()
                    Me.Hide()


                Else
                    MsgBox("Usuario ingresado no Tiene Permisos en esta sucursal", MsgBoxStyle.Critical, "Aviso")
                End If
            Else
                txtpass.Clear()
                MsgBox("Usuario ingresado no existe, o se encuentra bloqueado", MsgBoxStyle.Critical, "Aviso")
            End If
        End If
    End Sub
End Class
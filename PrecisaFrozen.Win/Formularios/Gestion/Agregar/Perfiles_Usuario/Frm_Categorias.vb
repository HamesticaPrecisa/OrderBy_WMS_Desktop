Public Class Frm_Categorias

    Dim fnc As New Funciones

    Private Sub txtcodigo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcodigo.KeyPress
        If e.KeyChar = ChrW(13) Then
            If txtcodigo.Text = "" Then
                txtcodigo.Text = BuscaCorrelativo("002", 3)
                txtcodigo.Enabled = False
                btn_guardar.Enabled = True
                GroupBox2.Enabled = True
                txtnombre.Focus()
                Btn_BuscaFamilia.Enabled = False
            Else
                If fnc.verificaExistencia("PrivilegiosSeccion", "Priv_Id", CerosAnteriorString(txtcodigo.Text, 3)) = True Then
                    Dim sql As String = "SELECT Priv_Nombre FROM PrivilegiosSeccion WHERE priv_id='" + CerosAnteriorString(txtcodigo.Text, 3) + "'"
                    Dim tabla As DataTable = fnc.ListarTablasSQL(sql)
                    If tabla.Rows.Count > 0 Then
                        txtcodigo.Enabled = False
                        txtcodigo.Text = CerosAnteriorString(txtcodigo.Text, 3)
                        txtnombre.Text = tabla.Rows(0)(0).ToString()
                        txtnombre.Focus()
                        txtnombre.SelectAll()
                    End If
                Else
                    MsgBox("El codigo ingresado no existe", MsgBoxStyle.Critical, "Aviso")
                End If
            End If
        End If
    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        If validacion() = True Then
            If fnc.verificaExistencia("PrivilegiosSeccion", "Priv_Id", txtcodigo.Text) = False Then
                Dim sql As String = "INSERT INTO PrivilegiosSeccion(Priv_Id, Priv_Nombre)VALUES('" + txtcodigo.Text + "','" + txtnombre.Text + "')"
                If fnc.MovimientoSQL(sql) > 0 Then
                    MsgBox("Seccion Agregada Correctamente", MsgBoxStyle.Information, "Aviso")
                    btn_guardar.Enabled = False
                Else
                    MsgBox("Error al ingresar la información", MsgBoxStyle.Critical, "Aviso")
                End If
            Else
                Dim sql As String = "UPDATE PrivilegiosSeccion SET  Priv_Nombre='" + txtnombre.Text + "' WHERE Priv_Id='" + txtcodigo.Text + "'"
                If fnc.MovimientoSQL(sql) > 0 Then
                    MsgBox("Seccion Actualizada Correctamente", MsgBoxStyle.Information, "Aviso")
                Else
                    MsgBox("Error al Actualizar la información", MsgBoxStyle.Critical, "Aviso")
                End If
            End If
        End If
    End Sub

    Function validacion()

        Dim mensaje As String = ""

        If Not IsNumeric(txtcodigo.Text) Then
            mensaje = mensaje + "- Codigo mal ingresado" + vbCrLf
        End If

        If txtnombre.Text.Trim = "" Then
            mensaje = mensaje + "- Nombre no ingresado"
        End If

        If mensaje <> "" Then
            MsgBox("Error al ingresar Seccion" + vbCrLf + mensaje, MsgBoxStyle.Information, "Aviso")
            Return False
            Exit Function
        End If
        Return True
    End Function

    Private Sub Frm_Categorias_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If txtcodigo.Enabled = False Then
            If fnc.verificaExistencia("PrivilegiosSeccion", "Priv_Id", txtcodigo.Text) = False Then
                CancelaCorrelativo("002", txtcodigo.Text)
                pf_categorias = False
            Else
                pf_categorias = False
            End If
        Else
            pf_categorias = False
        End If
    End Sub

    Private Sub btn_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        If txtcodigo.Text <> "" Then
            If fnc.verificaExistencia("PrivilegiosSeccion", "Priv_Id", txtcodigo.Text) = True Then
                txtcodigo.Enabled = True
                txtcodigo.Text = ""
                txtnombre.Text = ""
                GroupBox2.Enabled = False
                Btn_BuscaFamilia.Enabled = True
                txtcodigo.Focus()
            Else
                If MsgBox("Desea salir sin guardar la categoria", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbYes Then
                    CancelaCorrelativo("002", txtcodigo.Text)
                    limpiar()
                End If
            End If
        End If
    End Sub

    Sub limpiar()
        txtcodigo.Enabled = True
        txtnombre.Text = ""
        txtcodigo.Text = ""
        txtcodigo.Focus()
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub Btn_BuscaFamilia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_BuscaFamilia.Click
        Dim f As New Frm_CategoriasAyuda
        f.ShowDialog(Frm_Principal)
        If Frm_Principal.buscavalor.ToString() <> "" Then
            BuscaCategoria(Frm_Principal.buscavalor)
            Frm_Principal.buscavalor = ""
        End If
    End Sub

    Sub BuscaCategoria(ByVal cat_codigo As String)

        Dim sql As String = "SELECT Priv_Id, Priv_Nombre FROM  PrivilegiosSeccion WHERE Priv_Id='" + cat_codigo + "'"
        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

        If tabla.Rows.Count > 0 Then
            txtcodigo.Text = tabla.Rows(0)(0).ToString()
            txtnombre.Text = tabla.Rows(0)(1).ToString()
            txtcodigo.Enabled = False
        End If

    End Sub


End Class
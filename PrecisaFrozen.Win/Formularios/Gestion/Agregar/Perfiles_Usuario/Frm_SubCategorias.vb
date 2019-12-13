Public Class Frm_SubCategorias

    Dim fnc As New Funciones

    Private Sub txtcodigo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcodigo.KeyPress
        If e.KeyChar = ChrW(13) Then
            If txtcodigo.Text = "" Then
                txtcodigo.Text = BuscaCorrelativo("003", 3)
                txtcodigo.Enabled = False
                txtnombre.Focus()
                Btn_Categoria.Enabled = True
                btn_guardar.Enabled = True
                GroupBox2.Enabled = True
                Btn_BuscaFamilia.Enabled = False
            Else
                'busca
                BuscaSubCategoria(CerosAnteriorString(txtcodigo.Text, 3))
            End If
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Categoria.Click
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
            txtcatcod.Text = tabla.Rows(0)(0).ToString()
            txtcatdesc.Text = tabla.Rows(0)(1).ToString()
        End If

    End Sub

    Private Sub Frm_SubCategorias_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If txtcodigo.Enabled = False Then
            If fnc.verificaExistencia("PrivilegiosSubSeccion", "SPriv_Id", txtcodigo.Text) = False Then
                CancelaCorrelativo("003", txtcodigo.Text)
                pf_SubCategorias = False
            Else
                pf_SubCategorias = False
            End If
        Else
            pf_SubCategorias = False
        End If
    End Sub

    Private Sub Btn_BuscaFamilia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_BuscaFamilia.Click
        Dim f As New Frm_SubcategoriasAyuda
        f.ShowDialog(Frm_Principal)
        If Frm_Principal.buscavalor <> "" Then
            BuscaSubCategoria(Frm_Principal.buscavalor)
        End If
    End Sub

    Sub BuscaSubCategoria(ByVal codigo As String)
        Dim sql As String = "SELECT Spriv_Id, Spriv_nombre, Spriv_PrivId, Priv_nombre FROM PrivilegiosSeccion, PrivilegiosSubSeccion " +
            "WHERE Spriv_privId=Priv_Id AND SPriv_Id='" + CerosAnteriorString(codigo, 3) + "'"

        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

        If tabla.Rows.Count > 0 Then
            txtcodigo.Text = tabla.Rows(0)(0).ToString()
            txtnombre.Text = tabla.Rows(0)(1).ToString()
            txtcatcod.Text = tabla.Rows(0)(2).ToString()
            txtcatdesc.Text = tabla.Rows(0)(3).ToString()
            txtcodigo.Enabled = False
        Else
            MsgBox("El Codigo Seleccionado no existe", MsgBoxStyle.Critical, "Aviso")
        End If
    End Sub

    Private Sub btn_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        If txtcodigo.Text <> "" Then
            If fnc.verificaExistencia("PrivilegiosSubSeccion", "Spriv_Id", txtcodigo.Text) = False Then
                CancelaCorrelativo("003", txtcodigo.Text)
            End If
            limpiaform()
        End If
    End Sub
    Sub limpiaform()
        GroupBox2.Enabled = False
        txtcodigo.Text = ""
        txtcatcod.Text = ""
        txtcatdesc.Text = ""
        txtnombre.Text = ""
        txtcodigo.Enabled = True
        Btn_BuscaFamilia.Enabled = True
        txtcodigo.Focus()
    End Sub
    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        If validaIngreso() = True Then
            Dim sql As String = "INSERT INTO PrivilegiosSubSeccion VALUES('" + txtcodigo.Text + "','" + txtnombre.Text + "','" + txtcatcod.Text + "','0')"
            If fnc.MovimientoSQL(sql) > 0 Then
                MsgBox("SubCategoria Agregada Correctamente", MsgBoxStyle.Information, "Aviso")
                btn_guardar.Enabled = False
            Else
                MsgBox("Error al ingresar la información", MsgBoxStyle.Critical, "Aviso")
            End If
        End If
    End Sub

    Function validaIngreso() As Boolean
        validaIngreso = True
        Dim mensaje As String = ""

        If txtnombre.Text.Trim = "" Then
            mensaje = mensaje + "- Nombre Sub-Categoria" + vbCrLf
            validaIngreso = False
        End If

        If txtcatcod.Text = "" Then
            mensaje = mensaje + "- Categoria Asociada"
            validaIngreso = False
        End If

        If mensaje <> "" Then
            MsgBox("Debe ingresar lo siguiente antes de guardar" + vbCrLf + mensaje, MsgBoxStyle.Critical, "Aviso")
        End If

        ' Return validaIngreso
    End Function


    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Close()
    End Sub

    Private Sub Frm_SubCategorias_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Frm_Principal.buscavalor = ""
    End Sub
End Class
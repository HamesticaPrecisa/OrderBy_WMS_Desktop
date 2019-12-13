Public Class Frm_moneda


    Dim fnc As New Funciones

    Private Sub frm_monedas_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'Dim sql As String = "SELECT C.cont_codigo, c.cont_mon, cont_UltUSD, c.cont_nombre, cli_rut, cont_cobcod, cont_codigo2, cli_rut2, cont_gracia, DC.Cont_servValor " +
        '           "FROM contratos AS C INNER JOIN clientesActivos ON Cont_clirut=cli_rut INNER JOIN DetaContratos AS DC " +
        '           "ON DC.Cont_codigo=C.cont_codigo WHERE  cli_rut<>'11111112' AND cli_rut<>'11609532' AND DC.Cont_ServCod='9' AND cont_bloq='0' AND c.cont_mon<>'1' " +
        '           "ORDER BY cont_codigo ASC "

        'Dim tabla As DataTable = fnc.ListarTablasSQL(sql)


        'Dim codigo As Integer = 0
        'Dim moneda As Double = 0
        'Dim cancel As Boolean = False

        'If tabla.Rows.Count > 0 Then

        '    For i As Integer = 0 To tabla.Rows.Count - 1
        '        Dim sql_dolar As String = "SELECT mon_valor FROM monedas WHERE mon_codi='" + tabla.Rows(i)(1).ToString() + "'"

        '        Dim TablaDolar As DataTable = fnc.ListarTablasSQL(sql_dolar)

        '        moneda = Convert.ToDouble(TablaDolar.Rows(0)(0).ToString())

        '        codigo = tabla.Rows(i)(0).ToString()

        '        Dim Detalle As DataTable = fnc.ListarTablasSQL("SELECT Cont_ServCod, isnull(cont_USD,0) FROM DetaContratos WHERE Cont_codigo='" + codigo.ToString + "' AND isnull(cont_USD,0)<>'0'")
        '        'If tabla.Rows(i)(2).ToString() = moneda.ToString() Then
        '        '    If MsgBox("El contrato " + tabla.Rows(i)(3).ToString() + " Se encuentra actualizado, ¿Desea Volver a Actualizar sus tarifas?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbNo Then
        '        '        cancel = True
        '        '    End If
        '        'End If

        '        If cancel = False Then
        '            For j As Integer = 0 To Detalle.Rows.Count - 1
        '                Dim valor As Integer = Math.Round(Convert.ToDouble(Detalle.Rows(j)(1).ToString()) * Convert.ToDouble(moneda))
        '                Console.WriteLine(Convert.ToDouble(Detalle.Rows(j)(1)).ToString() + "  |  " + Convert.ToDouble(moneda).ToString() + "   |  " + valor.ToString())
        '                Dim sql_det As String = "UPDATE Detacontratos SET Cont_servValor='" + valor.ToString() + "' WHERE cont_codigo='" + codigo.ToString() + "' AND Cont_ServCod='" + Detalle.Rows(j)(0).ToString() + "'"
        '                fnc.MovimientoSQL(sql_det)
        '            Next
        '        End If
        '        cancel = False
        '    Next
        'End If
    End Sub

    Private Sub frm_monedas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        codigo.Text = CerosAnteriorString(fnc.ValorMaximo("Monedas", "mon_codi", 1), 2)
    End Sub

    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        Dim f As New Frm_monedasAyuda
        f.ShowDialog(Frm_Principal)

        If Frm_Principal.buscavalor.ToString() <> "" Then
            monedas(Frm_Principal.buscavalor.ToString())
        End If
    End Sub


    Sub monedas(ByVal moneda)

        Dim sql As String = "SELECT mon_descr, mon_valor, mon_est FROM monedas WHERE mon_codi='" + moneda + "'"

        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

        If tabla.Rows.Count > 0 Then
            codigo.Text = moneda
            descripcion.Text = tabla.Rows(0)(0).ToString()
            valor.Text = tabla.Rows(0)(1).ToString().Replace(",", ".")

            If tabla.Rows(0)(2).ToString() = "0" Then
                CbEstado.Checked = False
            Else
                CbEstado.Checked = True
            End If

            Btn_Eliminar.Enabled = True
        Else
            MsgBox("La moneda seleccionada no existe", MsgBoxStyle.Critical, "Aviso")
        End If

    End Sub

    Private Sub Btn_Guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Guardar.Click

        If validador() = True Then
            Dim sql As String = ""
            If fnc.verificaExistencia("Monedas", "mon_codi", codigo.Text) = True Then

                sql = "UPDATE monedas SET mon_descr='" + descripcion.Text + "', mon_valor='" + valor.Text.Replace(",", ".") + "', " +
                      "mon_est='" + Convert.ToInt32(CbEstado.CheckState).ToString() + "' WHERE mon_codi='" + codigo.Text + "'"

            Else
                sql = "INSERT INTO monedas (mon_codi, mon_descr, mon_valor, mon_est)VALUES('" + codigo.Text + "'," +
                    "'" + descripcion.Text + "','" + valor.Text.Replace(",", ".") + "','" + Convert.ToInt32(CbEstado.CheckState).ToString() + "')"
            End If

            If fnc.MovimientoSQL(sql) > 0 Then
                MsgBox("Grabación exitosa", MsgBoxStyle.Information, "Aviso")
            Else
                MsgBox("Error al grabar la información", MsgBoxStyle.Critical, "Aviso")
            End If
        End If

    End Sub

    Function validador() As Boolean

        If descripcion.Text.Trim = "" Then
            MsgBox("Falta descripción", MsgBoxStyle.Information, "Aviso")
            Return False
        End If

        If valor.Text.Trim = "" Or Not IsNumeric(valor.Text) Then

            If Not IsNumeric(valor.Text) Then
                MsgBox("Debe ingresar un valor numerico ", MsgBoxStyle.Information, "Aviso")
            Else
                MsgBox("falta valor de servicio", MsgBoxStyle.Information, "Aviso")
            End If

            Return False
        End If

        Return True
    End Function

    Private Sub Btn_Nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Nuevo.Click
        codigo.Text = CerosAnteriorString(fnc.ValorMaximo("Monedas", "mon_codi", 1), 2)
        descripcion.Text = ""
        valor.Text = ""
        CbEstado.CheckState = False
        Btn_Eliminar.Enabled = False
    End Sub

    Private Sub valor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles valor.KeyPress
        SoloKilos(sender, e)
    End Sub

    Private Sub Btn_Salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Salir.Click
        Close()
    End Sub

    Private Sub Frm_moneda_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F5 Then
            Btn_Guardar.PerformClick()
        ElseIf e.KeyCode = Keys.F6 Then
            Btn_Nuevo.PerformClick()
        ElseIf e.KeyCode = Keys.F7 Then
            Btn_Eliminar.PerformClick()
        ElseIf e.KeyCode = Keys.F8 Then
            Btn_Salir.PerformClick()
        End If
    End Sub

    Private Sub Btn_Eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Eliminar.Click
        If MsgBox("¿Seguro de eliminar la moneda seleccionada?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbYes Then
            Dim sql As String = "DELETE FROM monedas WHERE mon_codi='" + codigo.Text + "'"
            If fnc.MovimientoSQL(sql) > 0 Then
                MsgBox("moneda eliminada correctamente", MsgBoxStyle.Information, "Aviso")
                Btn_Nuevo.PerformClick()
            Else
                MsgBox("Error al eliminar la moneda, tiene registros relacionados", 16, "Aviso")
            End If
        End If
    End Sub
End Class
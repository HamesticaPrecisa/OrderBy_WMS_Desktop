Imports CrystalDecisions.Shared

Public Class Frm_ImprimirGuia
    Implements IForm

    Dim fnc As New Funciones

    Private Sub TextBox3_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = ChrW(13) Then

        Else
            SoloNumeros(sender, e)
        End If
    End Sub


    Private Sub BtnAyudaCliente_Click(sender As System.Object, e As System.EventArgs) Handles BtnAyudaCliente.Click
        Dim frm As New Frm_ImprimirGuiaAyudaCli
        frm.ShowDialog(Me)

        If txtrut.Text = "799842408" Or txtrut.Text = "784836002" Then
            Rb_Agrosuper.Checked = True
        Else
            RbPrecisa.Checked = True
        End If


        Dim sql As String = "SELECT fdes_codi, fdes_codi AS Nom FROM fichdespa WHERE fdes_fecha='" + devuelve_fecha(DateTimePicker1.Value) + "'  " +
            "AND fdes_rutcli='" + txtrut.Text + "'"

        Dim tabla As DataTable = fnc.ListarTablasSQLSERVIDOR(sql)

        If tabla.Rows.Count > 0 Then
            ComboBox1.DataSource = tabla
            ComboBox1.ValueMember = "fdes_codi"
            ComboBox1.DisplayMember = "nom"
            ComboBox1.Enabled = True
        Else
            ComboBox1.Enabled = False
        End If
    End Sub

    Public Sub ChangeTextBoxText(text As String) Implements IForm.ChangeTextBoxText
        If Len(text) >= 9 Then

            Dim SqlBusca As String = "SELECT cli_nomb FROM clientes WHERE " +
                "cli_rut='" + text + "'"

            Dim tabla As DataTable = fnc.ListarTablasSQLSERVIDOR(SqlBusca)

            If tabla.Rows.Count > 0 Then
                txtrut.Text = text
                txtnombre.Text = tabla.Rows(0)(0).ToString()
            End If

        End If

    End Sub

    Sub ImprimirGuiaPrecisa()

        Dim sql As String = "SELECT * FROM fichdespa WHERE fdes_codi='" + ComboBox1.Text + "'"
        Dim tabla As DataTable = fnc.ListarTablasSQLSERVIDOR(sql)

        If tabla.Rows.Count > 0 Then

            ' Creo el parametro y asigno el nombre

            Dim param As New ParameterField()
            param.ParameterFieldName = "codigo"

            '
            ' creo el valor que se asignara al parametro
            '
            Dim discreteValue As New ParameterDiscreteValue()
            discreteValue.Value = CerosAnteriorString(ComboBox1.Text, 7)
            param.CurrentValues.Add(discreteValue)

            '
            ' Asigno el paramametro a la coleccion
            '
            Dim paramFiels As New ParameterFields()
            paramFiels.Add(param)

            '
            ' Asigno la coleccion de parametros al Crystal Viewer
            '

            Dim frm As Rpt_GuiaPrecisaForm = New Rpt_GuiaPrecisaForm

            frm.Contenedor.ParameterFieldInfo = paramFiels

            '
            ' Creo la instancia del reporte
            '
            Dim report As New Rpt_GuiaPrecisa



            '
            ' Asigno el reporte a visor
            '
            report.SetDatabaseLogon("sa", "precisa")
            frm.Contenedor.ReportSource = report
            frm.ShowDialog()

        Else
            MsgBox("La recepcion Nº " + ComboBox1.Text + " NO existe", MsgBoxStyle.Critical, "Aviso")
        End If
    End Sub

    Private Sub BtnImprimir_Click(sender As System.Object, e As System.EventArgs) Handles BtnImprimir.Click
        If ComboBox1.Enabled = True Then
            If RbPrecisa.Checked = True Then
                Dim sql As String = "SELECT SUM(ddes_pallet) AS PALLET, mae_descr, SUM(ddes_unidades) AS Unidades, SUM(ddes_peso )AS peso " +
                "FROM detadespa, maeprod WHERE ddes_codi LIKE '%" + ComboBox1.Text + "%'  AND mae_codi=ddes_codpro GROUP BY mae_descr "
                Dim tabla As DataTable = fnc.ListarTablasSQLSERVIDOR(sql)

                If tabla.Rows.Count > 9 Then
                    MsgBox("No se Puede Imprimir la guia ya que la cantidad de detalle sobrepasa el limite permitido" + tabla.Rows.Count.ToString(), MsgBoxStyle.Critical, "Aviso")
                Else
                    ImprimirGuiaPrecisa()
                End If

            End If
        Else
            MsgBox("No Existe Guia Seleccionada", MsgBoxStyle.Information, "Aviso")
        End If

    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As System.Object, e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        Dim sql As String = "SELECT fdes_codi, fdes_codi AS Nom FROM fichdespa WHERE fdes_fecha='" + devuelve_fecha(DateTimePicker1.Value) + "'  " +
          "AND fdes_rutcli='" + txtrut.Text + "'"

        Dim tabla As DataTable = fnc.ListarTablasSQLSERVIDOR(sql)

        If tabla.Rows.Count > 0 Then
            ComboBox1.DataSource = tabla
            ComboBox1.ValueMember = "fdes_codi"
            ComboBox1.DisplayMember = "nom"
            ComboBox1.Enabled = True
        Else
            ComboBox1.Enabled = False
        End If
    End Sub
End Class
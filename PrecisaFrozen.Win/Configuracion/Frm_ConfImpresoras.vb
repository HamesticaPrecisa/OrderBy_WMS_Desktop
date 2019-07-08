Imports System.Drawing.Printing

Public Class Frm_ConfImpresoras

    Dim fnc As New Funciones

    Private Sub Frm_ConfImpresoras_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            Dim pd As New PrintDocument
            Dim Impresoras As String

            ' Default printer      
            Dim s_Default_Printer As String = pd.PrinterSettings.PrinterName

            ' recorre las impresoras instaladas  
            For Each Impresoras In PrinterSettings.InstalledPrinters
                ComboBox1.Items.Add(Impresoras.ToString)
                ComboBox2.Items.Add(Impresoras.ToString)
            Next
            lblcomputador.Text = My.Computer.Name.ToString()
            If fnc.verificaExistencia("Conf_Impresora", "Imp_Comp", lblcomputador.Text) = True Then

                Dim sql As String = "SELECT imp_etiq, imp_inf, imp_com1 FROM Conf_Impresora WHERE Imp_Comp='" + lblcomputador.Text + "'"
                Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

                If tabla.Rows.Count > 0 Then
                    ComboBox1.SelectedItem = tabla.Rows(0)(0).ToString()
                    ComboBox2.SelectedItem = tabla.Rows(0)(1).ToString()
                    If tabla.Rows(0)(2).ToString() = "COM1" Then
                        CheckBox1.Checked = True
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try

    End Sub

    Private Sub Guardar_Click(sender As System.Object, e As System.EventArgs) Handles Guardar.Click

        If ComboBox1.SelectedItem = Nothing Or ComboBox2.SelectedItem = Nothing Then
            MsgBox("Debe seleccionar las dos impresoras para guardar los cambios", MsgBoxStyle.Critical, "Aviso")
            Exit Sub
        End If
        Dim com1 As String = ""
        If CheckBox1.Checked = True Then
            com1 = "COM1"
        End If

        If fnc.verificaExistencia("Conf_Impresora", "Imp_Comp", lblcomputador.Text) = False Then

            Dim SqlGuarda As String = "INSERT INTO Conf_Impresora(Imp_comp, Imp_Etiq, Imp_Inf, Imp_FecConf, Imp_COM1)" +
                "VALUES('" + lblcomputador.Text + "','" + ComboBox1.SelectedItem.ToString() + "'," +
                "'" + ComboBox2.SelectedItem.ToString() + "','" + fnc.DevuelveFechaServidor() + "','" + com1 + "')"

            If fnc.MovimientoSQL(SqlGuarda) > 0 Then
                MsgBox("Registro Agregado Correctamente", MsgBoxStyle.Information, "Aviso")
                Me.Close()
            Else
                MsgBox("Error al agregar la configuracion", MsgBoxStyle.Critical, "Aviso")
            End If

        Else

            Dim SqlActualiza As String = "UPDATE Conf_Impresora SET  Imp_Etiq='" + ComboBox1.SelectedItem.ToString() + "', " +
                "Imp_Inf='" + ComboBox2.SelectedItem.ToString() + "', Imp_FecConf='" + fnc.DevuelveFechaServidor() + "', imp_com1='" + com1 + "' WHERE " +
                "Imp_comp='" + lblcomputador.Text + "'"

            If fnc.MovimientoSQL(SqlActualiza) > 0 Then
                MsgBox("Registro Actualizado", MsgBoxStyle.Information, "Aviso")
                Me.Close()
            Else
                MsgBox("Error al Actualizar la configuracion", MsgBoxStyle.Critical, "Aviso")
            End If

        End If
    End Sub

    Private Sub ComboBox2_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox2.KeyPress, ComboBox1.KeyPress
        e.Handled = True
    End Sub

    Private Sub Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancelar.Click
        Me.Close()
    End Sub
End Class
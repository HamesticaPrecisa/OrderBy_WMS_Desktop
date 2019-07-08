Imports System.IO.Ports
Imports ReaderB
Imports System.IO

Public Class Frm_Usuarios_Registrar_TAG

    Private Sub Frm_Usuarios_Registrar_TAG_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim SerialPort As New SerialPort()
        Dim PuertosDisp = SerialPort.GetPortNames

        Dim dt As New DataTable

        dt.Columns.Add("NumPue")
        dt.Columns.Add("NomPue")

        Dim row As DataRow = dt.NewRow
        row(0) = "-1"
        row(1) = "Seleccione"
        dt.Rows.Add(row)

        For i = 0 To PuertosDisp.Length - 1
            Dim NomPueAct = PuertosDisp(i).ToString.Trim

            Dim row2 As DataRow = dt.NewRow
            row2(0) = NomPueAct.Replace("COM", "")
            row2(1) = NomPueAct
            dt.Rows.Add(row2)
        Next

        cboPue.DataSource = dt
        cboPue.ValueMember = "NumPue"
        cboPue.DisplayMember = "NomPue"
    End Sub

    Private Sub cboPue_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboPue.SelectedIndexChanged
        Try
            Dim NumPue As Integer = CInt(cboPue.SelectedValue.ToString.Trim)

            If (NumPue <> -1) Then
                Dim ComAddr As Byte = Convert.ToByte(255)
                Dim Baud As Byte = Convert.ToByte(5)
                Dim PortHand As Integer = 0

                Dim OpenRes As Integer = -1
                OpenRes = StaticClassReaderB.OpenComPort(NumPue, ComAddr, Baud, PortHand)
                If (OpenRes = 0) Then
                    Dim Alarm As Integer = StaticClassReaderB.BuzzerAndLEDControl(ComAddr, Convert.ToByte(4), Convert.ToByte(2), Convert.ToByte(3), PortHand)
                    StaticClassReaderB.CloseComPort()
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnGra_Click(sender As System.Object, e As System.EventArgs) Handles btnGra.Click
        Try
            Dim NumPue = CInt(cboPue.SelectedValue.ToString.Trim)
            If (NumPue = -1) Then
                MessageBox.Show("Debe seleccionar un puerto.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Dim NomPue = "COM" & NumPue

            Dim PueOk As Boolean = True

            Dim ComAddr As Byte = Convert.ToByte(255)
            Dim Baud As Byte = Convert.ToByte(5)
            Dim PortHand As Integer = 0

            Dim OpenRes As Integer = -1
            OpenRes = StaticClassReaderB.OpenComPort(NumPue, ComAddr, Baud, PortHand)
            If (OpenRes = 0) Then
                StaticClassReaderB.CloseComPort()
                PueOk = False
            End If

            If (PueOk) Then
                MessageBox.Show("El puerto seleccionado no es el correcto.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Dim pathCOM = Directory.GetCurrentDirectory.Trim & "\RFIDCOMPORT.txt"

            If (File.Exists(pathCOM)) Then
                Dim TextArch As String = ""

                Using reader As New StreamReader(pathCOM)
                    TextArch = reader.ReadLine().Trim
                End Using

                If (TextArch <> NomPue) Then
                    Dim fs As FileStream = Nothing
                    Try
                        fs = New FileStream(pathCOM, FileMode.Truncate)
                        Using writer As StreamWriter = New StreamWriter(fs)
                            writer.Write(NomPue)
                        End Using
                    Finally
                        If Not fs Is Nothing Then
                            fs.Dispose()
                        End If
                    End Try
                End If
            Else
                Dim fs As FileStream = Nothing
                Try
                    fs = New FileStream(pathCOM, FileMode.CreateNew)
                    Using writer As StreamWriter = New StreamWriter(fs)
                        writer.Write(NomPue)
                    End Using
                Finally
                    If Not fs Is Nothing Then
                        fs.Dispose()
                    End If
                End Try
            End If

            Frm_Principal.PuertoRFID = NomPue
            MessageBox.Show("Puerto guardado.", "Información!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Ocurrio un error al guardar el puerto seleccionado.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
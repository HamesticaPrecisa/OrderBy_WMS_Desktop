Imports System.Drawing.Drawing2D
Imports System.Drawing.Printing

Public Class Frm_UtilidadImprEtRack
    Dim fnc As New Funciones
    Public marca As String

   
#Region "Imprimir Pallet -------------------------------->"

    Private Sub Imprimir()
        ' imprimir ZEBRA
        Dim PrintDocument1 As New PrintDocument


        PrintDocument1.PrinterSettings = prtsettings
        AddHandler PrintDocument1.PrintPage, AddressOf print_PrintPage_10x10

        Dim sql_Impresora As String = "SELECT imp_etiq FROM conf_impresora WHERE imp_comp='" + My.Computer.Name + "'"
        Dim tabla_conf As DataTable = fnc.ListarTablasSQL(sql_Impresora)
        If tabla_conf.Rows.Count > 0 Then
            PrintDocument1.PrinterSettings.PrinterName = tabla_conf.Rows(0)(0).ToString()
        Else
            MsgBox("Debe seleccionar la impresora antes de imprimir una etiqueta", MsgBoxStyle.Critical, "Aviso")
            Exit Sub
        End If

        PrintDocument1.Print()


    End Sub

    Dim prtsettings = New PrinterSettings()
#Region "Procedimientos"
    Public Sub print_PrintPage_10x10(ByVal sender As Object, ByVal e As PrintPageEventArgs)

        Dim numero_posicion = ""

        If RbAnden.Checked = True Then
            Dim i As String = DigitoVerificadorEAN13("999999" & "7" & Convert.ToInt32(txtcamara.Text) & "0000")
            numero_posicion = "999999" + "7" + Convert.ToInt32(txtcamara.Text).ToString() + txtbanda.Text + txtcolumna.Text + "" + i
        ElseIf Rb_Tunel.Checked Or rbPreFrio.Checked Or rbSalaProceso.Checked Then
            Dim i As String = DigitoVerificadorEAN13("999999" & "6" & Convert.ToInt32(txtcamara.Text) & "0000")
            numero_posicion = "999999" + "6" + Convert.ToInt32(txtcamara.Text).ToString() + txtbanda.Text + txtcolumna.Text + "" + i
        ElseIf rbPuerta.Checked Then
            Dim i As String = DigitoVerificadorEAN13("999999" & "8" & Convert.ToInt32(txtcamara.Text) & "0000")
            numero_posicion = "999999" + "8" + Convert.ToInt32(txtcamara.Text).ToString() + txtbanda.Text + txtcolumna.Text + "" + i
        Else
            Dim i As String = DigitoVerificadorEAN13("999999" & txtcamara.Text & txtbanda.Text & txtcolumna.Text)
            numero_posicion = "999999" + txtcamara.Text + txtbanda.Text + txtcolumna.Text + "" + i
        End If

        ' imprimimos la cadena en el margen izquierdo
        Dim xPos As Single = e.MarginBounds.Left

        ' Las fuentes a usar
        Dim prFont As New Font("Arial", 8, FontStyle.Bold)
        Dim Titulo As New Font("Arial", 18, FontStyle.Bold)

        ' dibuja rectangulo
        e.Graphics.DrawRectangle(Pens.Black, New Rectangle(30, 10, 365, 375))

        ' imprimir logo -----------------------------------------------
        Dim img_logo As New PictureBox
        img_logo.Image = My.Resources.img_logoZEBRA
        e.Graphics.DrawImage(img_logo.Image, 80, 10, 220, 70)
        '--------------------------------------------------------------

        e.Graphics.DrawString("Posicion", New Font("Arial", 24, FontStyle.Bold), Brushes.Black, 30, 90)
        If rdbpasillo.Checked = True Then

            e.Graphics.DrawString("CA - PASILLO", New Font("Arial", 32, FontStyle.Bold), Brushes.Black, 30, 130)
            e.Graphics.DrawString(txtcamara.Text + " - " + txtbanda.Text, New Font("Arial", 36, FontStyle.Bold), Brushes.Black, 30, 170)
        End If
        If RbPiso.Checked = True Then

            e.Graphics.DrawString("CA - BA", New Font("Arial", 32, FontStyle.Bold), Brushes.Black, 30, 130)
            e.Graphics.DrawString(txtcamara.Text + " - " + txtbanda.Text, New Font("Arial", 36, FontStyle.Bold), Brushes.Black, 30, 170)
        ElseIf rbPuerta.Checked Then
            Select Case cbEstados.SelectedIndex
                Case 1
                    e.Graphics.DrawString("CONTROL IN " + txtcamara.Text, New Font("Arial", 28, FontStyle.Bold), Brushes.Black, 30, 130)
                Case 2
                    e.Graphics.DrawString("CONTROL OUT " + txtcamara.Text, New Font("Arial", 28, FontStyle.Bold), Brushes.Black, 30, 130)
            End Select
        ElseIf rbSalaProceso.Checked Then
            Select Case cbEstados.SelectedIndex
                Case 1
                    e.Graphics.DrawString("SALA PROCESO 01", New Font("Arial", 22, FontStyle.Bold), Brushes.Black, 30, 130)
                Case 2
                    e.Graphics.DrawString("SALA PROCESO 02", New Font("Arial", 22, FontStyle.Bold), Brushes.Black, 30, 130)
            End Select
        ElseIf rbPreFrio.Checked Then
            Select Case cbEstados.SelectedIndex
                Case 1
                    e.Graphics.DrawString("PRE - FRIO 01", New Font("Arial", 28, FontStyle.Bold), Brushes.Black, 30, 130)
                Case 2
                    e.Graphics.DrawString("PRE - FRIO 02", New Font("Arial", 28, FontStyle.Bold), Brushes.Black, 30, 130)
            End Select
        ElseIf rdzonap.Checked = True Then

            Dim ZONAPSTR As String = txtcamara.Text.Substring(1, 1)

            e.Graphics.DrawString("ZONA PEDIDO 0" + ZONAPSTR, New Font("Arial", 28, FontStyle.Bold), Brushes.Black, 30, 130)
            e.Graphics.DrawString("BA " + txtbanda.Text + " - CO " + txtcolumna.Text, New Font("Arial", 36, FontStyle.Bold), Brushes.Black, 30, 170)

        ElseIf rdslot.Checked = True Then

            Dim ZONAPSTR As String = txtcamara.Text.Substring(1, 1)

            e.Graphics.DrawString("SLOT" + ZONAPSTR, New Font("Arial", 28, FontStyle.Bold), Brushes.Black, 30, 130)
            e.Graphics.DrawString("BA " + txtbanda.Text + " - CO " + txtcolumna.Text, New Font("Arial", 36, FontStyle.Bold), Brushes.Black, 30, 170)
        ElseIf RbRack.Checked = True Then



            e.Graphics.DrawString("CA - BA - CO", New Font("Arial", 32, FontStyle.Bold), Brushes.Black, 30, 130)


            e.Graphics.DrawString(txtcamara.Text + " - " + txtbanda.Text + " - " + txtcolumna.Text, New Font("Arial", 36, FontStyle.Bold), Brushes.Black, 30, 170)
        ElseIf RbAnden.Checked = True Then
            e.Graphics.DrawString("ANDEN " + txtcamara.Text, New Font("Arial", 36, FontStyle.Bold), Brushes.Black, 30, 130)
        ElseIf Rb_Tunel.Checked = True Then
            e.Graphics.DrawString("TUNEL " + txtcamara.Text, New Font("Arial", 36, FontStyle.Bold), Brushes.Black, 30, 130)
        ElseIf Rb_Pulmon.Checked = True Then
            Dim pulmon As String = ""
            If txtcamara.Text = "91" Then
                pulmon = "01"
            ElseIf txtcamara.Text = "92" Then
                pulmon = "02"
            ElseIf txtcamara.Text = "93" Then
                pulmon = "03"
            End If
            e.Graphics.DrawString("PULMON " + pulmon, New Font("Arial", 36, FontStyle.Bold), Brushes.Black, 30, 130)

   
        End If

        '  TRUE o FALSE Muestra los numeros bajo el codigo de barras
        Dim bm As Bitmap = BarCode.CodeEAN13(numero_posicion, False, 0.0)
        Dim picturebox As New PictureBox

        picturebox.Image = bm

        e.Graphics.DrawImage(picturebox.Image, 50, 250, 320, 100)

        'codigo de barras ------>
        e.Graphics.DrawString(numero_posicion, New Font("Arial", 16, FontStyle.Bold), Brushes.Black, 90, 350)

        e.HasMorePages = False
       

    End Sub

    Public Sub print_PrintPage_10x10pasillo(ByVal sender As Object, ByVal e As PrintPageEventArgs)

        Dim numero_posicion = ""

        If RbAnden.Checked = True Then
            Dim i As String = DigitoVerificadorEAN13("999999" & "7" & Convert.ToInt32(txtcamara.Text) & "0000")
            numero_posicion = "999999" + "7" + Convert.ToInt32(txtcamara.Text).ToString() + txtbanda.Text + txtcolumna.Text + "" + i
        ElseIf Rb_Tunel.Checked Or rbPreFrio.Checked Or rbSalaProceso.Checked Then
            Dim i As String = DigitoVerificadorEAN13("999999" & "6" & Convert.ToInt32(txtcamara.Text) & "0000")
            numero_posicion = "999999" + "6" + Convert.ToInt32(txtcamara.Text).ToString() + txtbanda.Text + txtcolumna.Text + "" + i
        ElseIf rbPuerta.Checked Then
            Dim i As String = DigitoVerificadorEAN13("999999" & "8" & Convert.ToInt32(txtcamara.Text) & "0000")
            numero_posicion = "999999" + "8" + Convert.ToInt32(txtcamara.Text).ToString() + txtbanda.Text + txtcolumna.Text + "" + i
        Else
            Dim i As String = DigitoVerificadorEAN13("999999" & txtcamara.Text & txtbanda.Text & txtcolumna.Text)
            numero_posicion = "999999" + txtcamara.Text + txtbanda.Text + txtcolumna.Text + "" + i
        End If

        ' imprimimos la cadena en el margen izquierdo
        Dim xPos As Single = e.MarginBounds.Left

        ' Las fuentes a usar
        Dim prFont As New Font("Arial", 8, FontStyle.Bold)
        Dim Titulo As New Font("Arial", 18, FontStyle.Bold)

        ' dibuja rectangulo
        e.Graphics.DrawRectangle(Pens.Black, New Rectangle(30, 10, 365, 375))

        ' imprimir logo -----------------------------------------------
        Dim img_logo As New PictureBox
        img_logo.Image = My.Resources.img_logoZEBRA
        e.Graphics.DrawImage(img_logo.Image, 80, 10, 220, 70)
        '--------------------------------------------------------------

        e.Graphics.DrawString("Posicion", New Font("Arial", 24, FontStyle.Bold), Brushes.Black, 30, 90)

        If RbPiso.Checked = True Then
            e.Graphics.DrawString("CA - BA", New Font("Arial", 32, FontStyle.Bold), Brushes.Black, 30, 130)
            e.Graphics.DrawString(txtcamara.Text + " - " + txtbanda.Text, New Font("Arial", 36, FontStyle.Bold), Brushes.Black, 30, 170)
        ElseIf rbPuerta.Checked Then
            Select Case cbEstados.SelectedIndex
                Case 1
                    e.Graphics.DrawString("CONTROL IN " + txtcamara.Text, New Font("Arial", 28, FontStyle.Bold), Brushes.Black, 30, 130)
                Case 2
                    e.Graphics.DrawString("CONTROL OUT " + txtcamara.Text, New Font("Arial", 28, FontStyle.Bold), Brushes.Black, 30, 130)
            End Select
        ElseIf rbSalaProceso.Checked Then
            Select Case cbEstados.SelectedIndex
                Case 1
                    e.Graphics.DrawString("SALA PROCESO 01", New Font("Arial", 22, FontStyle.Bold), Brushes.Black, 30, 130)
                Case 2
                    e.Graphics.DrawString("SALA PROCESO 02", New Font("Arial", 22, FontStyle.Bold), Brushes.Black, 30, 130)
            End Select
        ElseIf rbPreFrio.Checked Then
            Select Case cbEstados.SelectedIndex
                Case 1
                    e.Graphics.DrawString("PRE - FRIO 01", New Font("Arial", 28, FontStyle.Bold), Brushes.Black, 30, 130)
                Case 2
                    e.Graphics.DrawString("PRE - FRIO 02", New Font("Arial", 28, FontStyle.Bold), Brushes.Black, 30, 130)
            End Select
        ElseIf RbRack.Checked = True Then
            e.Graphics.DrawString("CA - BA - CO", New Font("Arial", 32, FontStyle.Bold), Brushes.Black, 30, 130)
            e.Graphics.DrawString(txtcamara.Text + " - " + txtbanda.Text + " - " + txtcolumna.Text, New Font("Arial", 36, FontStyle.Bold), Brushes.Black, 30, 170)
        ElseIf RbAnden.Checked = True Then
            e.Graphics.DrawString("ANDEN " + txtcamara.Text, New Font("Arial", 36, FontStyle.Bold), Brushes.Black, 30, 130)
        ElseIf Rb_Tunel.Checked = True Then
            e.Graphics.DrawString("TUNEL " + txtcamara.Text, New Font("Arial", 36, FontStyle.Bold), Brushes.Black, 30, 130)
        ElseIf Rb_Pulmon.Checked = True Then
            Dim pulmon As String = ""
            If txtcamara.Text = "91" Then
                pulmon = "01"
            ElseIf txtcamara.Text = "92" Then
                pulmon = "02"
            ElseIf txtcamara.Text = "93" Then
                pulmon = "03"
            End If
            e.Graphics.DrawString("PULMON " + pulmon, New Font("Arial", 36, FontStyle.Bold), Brushes.Black, 30, 130)
        End If

        '  TRUE o FALSE Muestra los numeros bajo el codigo de barras
        Dim bm As Bitmap = BarCode.CodeEAN13(numero_posicion, False, 0.0)
        Dim picturebox As New PictureBox

        picturebox.Image = bm

        e.Graphics.DrawImage(picturebox.Image, 50, 250, 320, 100)

        'codigo de barras ------>
        e.Graphics.DrawString(numero_posicion, New Font("Arial", 16, FontStyle.Bold), Brushes.Black, 90, 350)

        e.HasMorePages = False

    End Sub
    Public Sub print_PrintPage_10x07(ByVal sender As Object, ByVal e As PrintPageEventArgs)


        Dim numero_posicion = ""
        If RbAnden.Checked = True Then
            Dim i As String = DigitoVerificadorEAN13("999999" & "7" & Convert.ToInt32(txtcamara.Text) & "0000")
            numero_posicion = "999999" + "7" + Convert.ToInt32(txtcamara.Text).ToString() + txtbanda.Text + txtcolumna.Text + "" + i
        ElseIf Rb_Tunel.Checked = True Then

            Dim i As String = DigitoVerificadorEAN13("999999" & "6" & Convert.ToInt32(txtcamara.Text) & "0000")
            numero_posicion = "999999" + "6" + Convert.ToInt32(txtcamara.Text).ToString() + txtbanda.Text + txtcolumna.Text + "" + i
        Else
            Dim i As String = DigitoVerificadorEAN13("999999" & txtcamara.Text & txtbanda.Text & txtcolumna.Text)
            numero_posicion = "999999" + txtcamara.Text + txtbanda.Text + txtcolumna.Text + "" + i
        End If


        ' imprimimos la cadena en el margen izquierdo
        Dim xPos As Single = e.MarginBounds.Left

        ' Las fuentes a usar
        Dim prFont As New Font("Arial", 8, FontStyle.Bold)
        Dim Titulo As New Font("Arial", 18, FontStyle.Bold)
        ' dibuja rectangulo
        e.Graphics.DrawRectangle(Pens.Black, New Rectangle(2, 8, 375, 250))

        ' imprimir logo -----------------------------------------------
        'Dim img_logo As New PictureBox
        'img_logo.Image = My.Resources.img_logoZEBRA
        'e.Graphics.DrawImage(img_logo.Image, 80, 10, 220, 70)
        ''--------------------------------------------------------------

        'e.Graphics.DrawString("       PRECISA FROZEN     ", Titulo, Brushes.Black, 10, 50)
        e.Graphics.DrawString("Posicion", New Font("Arial", 24, FontStyle.Bold), Brushes.Black, 10, 10)

        If RbPiso.Checked = True Then
            e.Graphics.DrawString("CA - BA", New Font("Arial", 32, FontStyle.Bold), Brushes.Black, 10, 40)
            e.Graphics.DrawString(txtcamara.Text + " - " + txtbanda.Text, New Font("Arial", 36, FontStyle.Bold), Brushes.Black, 10, 80)
        ElseIf RbRack.Checked = True Then
            e.Graphics.DrawString("CA - BA - CO", New Font("Arial", 32, FontStyle.Bold), Brushes.Black, 10, 40)
            e.Graphics.DrawString(txtcamara.Text + " - " + txtbanda.Text + " - " + txtcolumna.Text, New Font("Arial", 36, FontStyle.Bold), Brushes.Black, 10, 80)
        ElseIf RbAnden.Checked = True Then
            e.Graphics.DrawString("ANDEN " + txtcamara.Text, New Font("Arial", 36, FontStyle.Bold), Brushes.Black, 10, 40)
        ElseIf Rb_Tunel.Checked = True Then
            e.Graphics.DrawString("TUNEL " + txtcamara.Text, New Font("Arial", 36, FontStyle.Bold), Brushes.Black, 10, 40)
        ElseIf Rb_Pulmon.Checked = True Then

            Dim pulmon As String = ""
            If txtcamara.Text = "91" Then
                pulmon = "01"
            ElseIf txtcamara.Text = "92" Then
                pulmon = "02"
            ElseIf txtcamara.Text = "93" Then
                pulmon = "03"
            End If
            e.Graphics.DrawString("PULMON " + pulmon, New Font("Arial", 36, FontStyle.Bold), Brushes.Black, 10, 40)
        End If



        '                                                    TRUE o FALSE Muestra los numeros bajo el codigo de barras
        Dim bm As Bitmap = BarCode.CodeEAN13(numero_posicion, False, 0.0)
        Dim picturebox As New PictureBox

        picturebox.Image = bm

        e.Graphics.DrawImage(picturebox.Image, 30, 150, 320, 50)
        'codigo de barras ------>
        e.Graphics.DrawString(numero_posicion, New Font("Arial", 16, FontStyle.Bold), Brushes.Black, 90, 200)

        e.HasMorePages = False

    End Sub
    Private Function seleccionarImpresora() As Boolean

        Dim Dialog As New PrintDialog

        With Dialog
            .AllowPrintToFile = False
            .AllowSelection = False
            .AllowSomePages = False
            .PrintToFile = False
            .ShowHelp = False
            .ShowNetwork = True

            .PrinterSettings = prtsettings

            If .ShowDialog() = DialogResult.OK Then
                prtsettings = .PrinterSettings
            Else
                Return False
            End If
        End With
        Return True
    End Function
    Private Sub SubImprime()
        ' ejemplo simple para imprimir en .NET
        ' Usamos una clase del tipo PrintDocument

        Dim printDoc As New PrintDocument
        If seleccionarImpresora() = True Then
            printDoc.PrinterSettings = prtsettings()

            ' asignamos el método de evento para cada página a imprimir()
            AddHandler printDoc.PrintPage, AddressOf print_PrintPage_10x10
            ' indicamos que queremos imprimir
            printDoc.Print()
        End If
    End Sub
    Public Sub GraphicsPathResetExample(ByVal e As PaintEventArgs)
        Dim myFont As New Font("Arial", 8)
        ' Create a path and add a line, an ellipse, and an arc.
        Dim myPath As New GraphicsPath()
        myPath.AddLine(New Point(0, 0), New Point(100, 100))
        myPath.AddEllipse(100, 100, 200, 250)
        myPath.AddArc(300, 250, 100, 100, 0, 90)
        ' Draw the pre-reset points array to the screen.
        DrawPointsHelper(e, myPath.PathPoints, 20)
        ' Reset the path.
        myPath.Reset()
        ' See if any points remain.
        If myPath.PointCount > 0 Then
            ' Draw the post-reset points array to the screen.
            DrawPointsHelper(e, myPath.PathPoints, 150)
            ' If there are no points, say so.
        Else
            e.Graphics.DrawString("No Points", myFont, Brushes.Black, _
            150, 20)
        End If
    End Sub
    Public Sub DrawPointsHelper(ByVal e As PaintEventArgs, ByVal pathPoints() As PointF, ByVal xOffset As Integer)
        Dim y As Integer = 20
        Dim myFont As New Font("Arial", 8)
        Dim i As Integer
        For i = 0 To pathPoints.Length - 1
            e.Graphics.DrawString(pathPoints(i).X.ToString() + _
            ", " + pathPoints(i).Y.ToString(), myFont, Brushes.Black, _
            xOffset, y)
            y += 20
        Next i
    End Sub
#End Region

#End Region

#Region "Eventos"
    Private Sub RbEtiqueta_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbEtiqueta.CheckedChanged, RbRangos.CheckedChanged
        If RbEtiqueta.Checked = False Then
            Label4.Enabled = True
            Label5.Enabled = True
            txtBaFinal.Enabled = True

            If RbRack.Checked = True Then
                TxtCoFinal.Enabled = True
            End If
        Else
            Label4.Enabled = False
            Label5.Enabled = False
            txtBaFinal.Enabled = False
            TxtCoFinal.Enabled = False
        End If
    End Sub
    Private Sub RbPiso_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbPiso.CheckedChanged
        If RbPiso.Checked Then
            Label1.Text = "Camara"
            Label2.Text = "Banda"
            txtcolumna.Enabled = False
            TxtCoFinal.Enabled = False
            txtbanda.Enabled = True
            txtBaFinal.Enabled = True
            txtcamara.Enabled = True
            RbRangos.Enabled = True
        End If

        txtbanda.Text = "00"
        txtBaFinal.Text = "00"

        txtcolumna.Text = "00"
        TxtCoFinal.Text = "00"

        txtcamara.Text = "00"

        cbEstados.Visible = False

        RbEtiqueta_CheckedChanged(sender, e)
    End Sub
    Private Sub rbPreFrio_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbPreFrio.CheckedChanged
        If rbPreFrio.Checked Then  'Agregado por Isaac Hernandez C.
            Label1.Text = "Pre Frio"
            Label2.Text = "Numero"
            txtcolumna.Enabled = False
            TxtCoFinal.Enabled = False
            txtbanda.Enabled = False
            txtBaFinal.Enabled = False
            txtcamara.Enabled = False
            RbRangos.Enabled = False
        End If

        txtbanda.Text = "00"
        txtBaFinal.Text = "00"

        txtcolumna.Text = "00"
        TxtCoFinal.Text = "00"

        txtcamara.Text = "00"

        cbEstados.Items.Clear()
        cbEstados.ResetText()
        cbEstados.Items.Insert(0, "")
        cbEstados.Items.Insert(1, "Pre - Frio 1")
        cbEstados.Items.Insert(2, "Pre - Frio 2")

        cbEstados.Visible = True

        RbEtiqueta_CheckedChanged(sender, e)
    End Sub
    Private Sub rbPuerta_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbPuerta.CheckedChanged
        If rbPuerta.Checked Then  'Agregado por Isaac Hernandez C.
            Label1.Text = "Control"
            Label2.Text = "Numero"
            txtcolumna.Enabled = False
            TxtCoFinal.Enabled = False
            txtbanda.Enabled = False
            txtBaFinal.Enabled = False
            txtcamara.Enabled = False
            RbRangos.Enabled = False
        End If

        txtbanda.Text = "00"
        txtBaFinal.Text = "00"

        txtcolumna.Text = "00"
        TxtCoFinal.Text = "00"

        txtcamara.Text = "00"

        cbEstados.Items.Clear()
        cbEstados.ResetText()
        cbEstados.Items.Insert(0, "")
        cbEstados.Items.Insert(1, "Control IN")
        cbEstados.Items.Insert(2, "Control OUT")

        cbEstados.Visible = True

        RbEtiqueta_CheckedChanged(sender, e)
    End Sub
    Private Sub rbSalaProceso_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSalaProceso.CheckedChanged
        If rbSalaProceso.Checked Then  'Agregado por Isaac Hernandez C.
            Label1.Text = "Sala Proceso"
            Label2.Text = "Numero"
            txtcolumna.Enabled = False
            TxtCoFinal.Enabled = False
            txtcamara.Enabled = False
            txtbanda.Enabled = False
            txtBaFinal.Enabled = False
            RbRangos.Enabled = False
        End If
        txtbanda.Text = "00"
        txtBaFinal.Text = "00"

        txtcolumna.Text = "00"
        TxtCoFinal.Text = "00"

        txtcamara.Text = "00"

        cbEstados.Items.Clear()
        cbEstados.ResetText()
        cbEstados.Items.Insert(0, "")
        cbEstados.Items.Insert(1, "Sala Proceso 1")
        cbEstados.Items.Insert(2, "Sala Proceso 2")

        cbEstados.SelectedItem = 0

        cbEstados.Visible = True

        RbEtiqueta_CheckedChanged(sender, e)
    End Sub
    Private Sub RbRack_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbRack.CheckedChanged
        If RbRack.Checked Then
            Label1.Text = "Camara"
            Label2.Text = "Banda"
            txtcolumna.Enabled = True
            TxtCoFinal.Enabled = True
            txtbanda.Enabled = True
            txtBaFinal.Enabled = True
            txtcamara.Enabled = True
            RbRangos.Enabled = True
        End If
        txtbanda.Text = "00"
        txtBaFinal.Text = "00"

        txtcolumna.Text = "00"
        TxtCoFinal.Text = "00"

        txtcamara.Text = "00"

        cbEstados.Visible = False

        RbEtiqueta_CheckedChanged(sender, e)
    End Sub
    Private Sub RbAnden_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbAnden.CheckedChanged
        If RbAnden.Checked Then
            Label1.Text = "Anden"
            Label2.Text = "Banda"
            RbRangos.Enabled = False
            txtcolumna.Enabled = False
            TxtCoFinal.Enabled = False
            txtbanda.Enabled = False
            txtBaFinal.Enabled = False
            txtcamara.Enabled = True
        End If
        txtbanda.Text = "00"
        txtBaFinal.Text = "00"

        txtcolumna.Text = "00"
        TxtCoFinal.Text = "00"

        txtcamara.Text = "00"

        cbEstados.Visible = False

        RbEtiqueta_CheckedChanged(sender, e)
    End Sub
    Private Sub Rb_Tunel_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rb_Tunel.CheckedChanged
        If Rb_Tunel.Checked Then
            Label1.Text = "Tunel"
            Label2.Text = "Banda"
            RbRangos.Enabled = False
            txtcolumna.Enabled = False
            TxtCoFinal.Enabled = False
            txtbanda.Enabled = False
            txtBaFinal.Enabled = False
            txtcamara.Enabled = True
        End If
        txtbanda.Text = "00"
        txtBaFinal.Text = "00"

        txtcolumna.Text = "00"
        TxtCoFinal.Text = "00"

        txtcamara.Text = "00"

        cbEstados.Visible = False

        RbEtiqueta_CheckedChanged(sender, e)
    End Sub
    Private Sub Rb_Pulmon_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rb_Pulmon.CheckedChanged
        If Rb_Pulmon.Checked Then
            Label1.Text = "Pulmon"
            Label2.Text = "Banda"
            RbRangos.Enabled = False
            txtcolumna.Enabled = False
            TxtCoFinal.Enabled = False
            txtbanda.Enabled = False
            txtBaFinal.Enabled = False
            txtcamara.Enabled = True
        End If
        txtbanda.Text = "00"
        txtBaFinal.Text = "00"

        txtcolumna.Text = "00"
        TxtCoFinal.Text = "00"

        txtcamara.Text = "00"

        cbEstados.Visible = False

        RbEtiqueta_CheckedChanged(sender, e)
    End Sub
    Private Sub cbEstados_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbEstados.SelectedIndexChanged
        If rbPuerta.Checked Then
            Select Case cbEstados.SelectedIndex
                Case 1
                    txtcamara.Text = "01"
                    txtbanda.Text = "00"
                Case 2
                    txtcamara.Text = "02"
                    txtbanda.Text = "00"
                Case Else
                    txtcamara.Text = "00"
                    txtbanda.Text = "00"
            End Select
        End If
        If rbSalaProceso.Checked Then
            Select Case cbEstados.SelectedIndex
                Case 1
                    txtcamara.Text = "07"
                    txtbanda.Text = "00"
                Case 2
                    txtcamara.Text = "08"
                    txtbanda.Text = "00"
                Case Else
                    txtcamara.Text = "00"
                    txtbanda.Text = "00"
            End Select
        End If
        If rbPreFrio.Checked Then
            Select Case cbEstados.SelectedIndex
                Case 1
                    txtcamara.Text = "05"
                    txtbanda.Text = "00"
                Case 2
                    txtcamara.Text = "06"
                    txtbanda.Text = "00"
                Case Else
                    txtcamara.Text = "00"
                    txtbanda.Text = "00"
            End Select
        End If

    End Sub
    Private Sub SoloNumeros_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcamara.KeyPress, txtbanda.KeyPress, txtcolumna.KeyPress
        SoloNumeros(sender, e)
    End Sub
    Private Sub txtcamara_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcamara.LostFocus
        txtcamara.Text = CerosAnteriorString(txtcamara.Text, 2)
    End Sub
    Private Sub txtbanda_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtbanda.LostFocus
        txtbanda.Text = CerosAnteriorString(txtbanda.Text, 2)
    End Sub
    Private Sub txtcolumna_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcolumna.LostFocus
        txtcolumna.Text = CerosAnteriorString(txtcolumna.Text, 2)
    End Sub
    Private Sub BtnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImprimir.Click
        If rdbpasillo.Checked = True Then
            marca = "SI"
        Else
            marca = "NO"
        End If
        Dim ijxd As Integer = 0
        Dim columna = Val(txtcolumna.Text)
        If RbRangos.Checked = True Then
            For i As Integer = Val(txtbanda.Text) To Convert.ToInt32(txtBaFinal.Text)
                For j As Integer = columna To Convert.ToInt32(TxtCoFinal.Text)
                    If RbPiso.Checked = True Then
                        txtbanda.Text = CerosAnteriorString(i, 2)
                        txtcolumna.Text = CerosAnteriorString(j, 2)

                        System.Console.WriteLine(txtcamara.Text + " " + txtbanda.Text + " " + txtcolumna.Text)
                        Imprimir()
                    Else
                        txtbanda.Text = CerosAnteriorString(i, 2)
                        txtcolumna.Text = CerosAnteriorString(j, 2)

                        System.Console.WriteLine(txtcamara.Text + " " + txtbanda.Text + " " + txtcolumna.Text)
                        Imprimir()
                        ijxd = ijxd + 1
                    End If

                Next

            Next
        ElseIf RbEtiqueta.Checked = True Then
            ' Solo una etiqueta
            Imprimir()
        End If
        System.Console.WriteLine(ijxd)
    End Sub
#End Region

    Private Sub RadioButton1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rdbpasillo.CheckedChanged
        If rdbpasillo.Checked Then
            Label1.Text = "Camara"
            Label2.Text = "Pasillo"
            txtcolumna.Enabled = False
            TxtCoFinal.Enabled = True
            txtbanda.Enabled = True
            txtBaFinal.Enabled = True
            txtcamara.Enabled = True
            RbRangos.Enabled = True
        End If
        txtbanda.Text = "00"
        txtBaFinal.Text = "00"

        txtcolumna.Text = "00"
        TxtCoFinal.Text = "00"

        txtcamara.Text = "00"

        cbEstados.Visible = False

        RbEtiqueta_CheckedChanged(sender, e)
    End Sub

    Private Sub RadioButton1_CheckedChanged_1(sender As System.Object, e As System.EventArgs) Handles rdzonap.CheckedChanged
        If rdzonap.Checked Then
            Label1.Text = "Zona de pedido"
            Label2.Text = "Banda"
            txtcolumna.Enabled = True
            TxtCoFinal.Enabled = True
            txtbanda.Enabled = True
            txtBaFinal.Enabled = True
            txtcamara.Enabled = True
            RbRangos.Enabled = True
        End If
        txtbanda.Text = "00"
        txtBaFinal.Text = "00"

        txtcolumna.Text = "00"
        TxtCoFinal.Text = "00"

        txtcamara.Text = "00"

        cbEstados.Visible = False

        RbEtiqueta_CheckedChanged(sender, e)
    End Sub

    Private Sub rdslot_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rdslot.CheckedChanged
        If rdslot.Checked Then
            Label1.Text = "Slot"
            Label2.Text = "Banda"
            txtcolumna.Enabled = True
            TxtCoFinal.Enabled = True
            txtbanda.Enabled = True
            txtBaFinal.Enabled = True
            txtcamara.Enabled = True
            RbRangos.Enabled = True
        End If
        txtbanda.Text = "00"
        txtBaFinal.Text = "00"

        txtcolumna.Text = "00"
        TxtCoFinal.Text = "00"

        txtcamara.Text = "00"

        cbEstados.Visible = False

        RbEtiqueta_CheckedChanged(sender, e)
    End Sub

    Private Sub Frm_UtilidadImprEtRack_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
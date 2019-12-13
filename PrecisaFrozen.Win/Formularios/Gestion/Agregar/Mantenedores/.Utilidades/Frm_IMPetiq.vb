Imports System.Drawing.Drawing2D
Imports System.Drawing.Printing
Public Class Frm_IMPetiq
    Dim fnc As New Funciones
    Dim transito As String = ""
    Private Sub BtnOrigen_Click(sender As System.Object, e As System.EventArgs) Handles BtnOrigen.Click
        Dim frm As New Frm_AyudaCamaras
        frm.ShowDialog(Frm_Principal)
        If Frm_Principal.buscavalor.ToString() <> "" Then
            TxtCodCamara.Text = Frm_Principal.buscavalor
            Dim sql = "SELECT Ncamara,columnas,bandas,alturap,pisosp,apiso,rack_sel,push_back,drivein,libre,entrada,prefpos,trans,zonap from camaraconf where camara='" + TxtCodCamara.Text + " '"

            Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

            If tabla.Rows.Count > 0 Then

                txtNombreCam.Text = tabla.Rows(0)(0).ToString()
                txtcamara.Text = TxtCodCamara.Text


                If tabla.Rows(0)(12).ToString() = "1" Then


                    transito = "1"
                    txtbanda.Text = "00"
                    txtbanda.Enabled = False
                    txtcolumna.Text = "00"
                    txtcolumna.Enabled = False
                Else
                    transito = ""
                    txtbanda.Text = ""
                    txtbanda.Enabled = True
                    txtcolumna.Text = ""
                    txtcolumna.Enabled = True

                End If



            Else

                txtNombreCam.Text = ""



            End If
            Frm_Principal.buscavalor = ""
        End If
    End Sub

    Private Sub RbRangos_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RbRangos.CheckedChanged
        If RbEtiqueta.Checked = False Then
            Label4.Enabled = True
            Label5.Enabled = True
            txtBaFinal.Enabled = True

        Else
            Label4.Enabled = False
            Label5.Enabled = False
            txtBaFinal.Enabled = False
            TxtCoFinal.Enabled = False
        End If
    End Sub

    Private Sub RbEtiqueta_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RbEtiqueta.CheckedChanged
        If RbEtiqueta.Checked = False Then
            Label4.Enabled = True
            Label5.Enabled = True
            txtBaFinal.Enabled = True

        Else
            Label4.Enabled = False
            Label5.Enabled = False
            txtBaFinal.Enabled = False
            TxtCoFinal.Enabled = False
        End If
    End Sub
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

    Public Sub print_PrintPage_10x10(ByVal sender As Object, ByVal e As PrintPageEventArgs)

        Dim numero_posicion = ""
        Dim i As String
        If transito = "1" Then
            ' i = DigitoVerificadorEAN13("999999" & "8" & Convert.ToInt32(txtcamara.Text.Trim()) & "0000")


            i = DigitoVerificadorEAN13("999999" & txtcamara.Text.Trim() & "0000")
            numero_posicion = "999999" + txtcamara.Text.ToString().Trim() + txtbanda.Text.Trim() + txtcolumna.Text.Trim() + "" + i


        Else
            ' i = DigitoVerificadorEAN13("999999" & txtcamara.Text.Trim() & txtbanda.Text.Trim() & txtcolumna.Text.Trim())

            i = DigitoVerificadorEAN13("999999" & txtcamara.Text.Trim() & txtbanda.Text.Trim() & txtcolumna.Text.Trim())
            numero_posicion = "999999" + txtcamara.Text.Trim() + txtbanda.Text.Trim() + txtcolumna.Text.Trim() + "" + i

        End If

        'numero_posicion = "999999" + txtcamara.Text.Trim() + txtbanda.Text + txtcolumna.Text + "" + i

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
        If chkpas.Checked = True Then
            e.Graphics.DrawString("Posicion PASILLO", New Font("Arial", 24, FontStyle.Bold), Brushes.Black, 30, 90)

        Else

            e.Graphics.DrawString("Posicion", New Font("Arial", 24, FontStyle.Bold), Brushes.Black, 30, 90)


        End If
  
        e.Graphics.DrawString(txtNombreCam.Text.Trim(), New Font("Arial", 28, FontStyle.Bold), Brushes.Black, 30, 130)

        If transito = "1" Then

        Else
            e.Graphics.DrawString("BA " + txtbanda.Text + " - CO " + txtcolumna.Text, New Font("Arial", 36, FontStyle.Bold), Brushes.Black, 30, 170)

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





    Private Sub BtnImprimir_Click(sender As System.Object, e As System.EventArgs) Handles BtnImprimir.Click
        Dim Sql_tip As String = "SELECT * FROM camaraMantenedor WHERE camara='" + txtcamara.Text.Trim() + "' and banda='" + txtbanda.Text.Trim() + "' and columna ='" + txtcolumna.Text.Trim() + "'"

        Dim tablatip As DataTable = fnc.ListarTablasSQL(Sql_tip)
        If chkpas.Checked = True Then
            Imprimir()
        Else
            If tablatip.Rows.Count > 0 Then


                Imprimir()

            Else


                If transito = "1" Then
                    Imprimir()
                Else



                    MsgBox("Esta Posicion No Se Encuentra Creada", MsgBoxStyle.Critical, "Aviso")

                End If


            End If

        End If
     
    End Sub

    Private Sub Frm_IMPetiq_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Frm_Principal.buscavalor = ""
    End Sub

    Private Sub chkpas_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkpas.CheckedChanged

    End Sub
End Class

Imports System.Data
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports System.Drawing.Printing
Imports CrystalDecisions.Shared
Public Class Frm_ProcesoBolsa
    Dim fnc As New Funciones
    Dim COM1 As New ImpresionCOM1
    Dim kilosfinal As String = ""
    Dim unidadesfinales As String = ""
    Dim cliente As String = ""
    Dim sdetarecbo As String = ""
    Dim Srack As String = ""

    Private Sub txtcodrece_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtcodrece.KeyPress
        If e.KeyChar = ChrW(13) Then
            Dim sql As String = "Select drec_codi as PALLET FROM detarece where frec_codi1 ='" + txtcodrece.Text + "'"

            DgvResultado.DataSource = fnc.ListarTablasSQL(sql)

            Dim sql2 As String = "Select frec_guiades  FROM fichrece where frec_codi ='" + txtcodrece.Text + "'"

            Dim tabla2 As DataTable = fnc.ListarTablasSQL(sql2)
            If tabla2.Rows.Count > 0 Then
                txtlote.Text = tabla2.Rows(0)(0).ToString

            End If


        End If
    End Sub
    Private Sub modificaficha()
 



        Dim SQL As String = "select sum(kilosbol) as kilosbolsa,count(pallet) as unidades from detarecbolsa where codrece='" + txtcodrece.Text + "'  "



        Dim tabla As DataTable = fnc.ListarTablasSQL(SQL)
        If tabla.Rows.Count > 0 Then
            Dim kiloficha As String = ""
            Dim unidadesficha As String = ""
            kiloficha = tabla.Rows(0)(0).ToString
            unidadesficha = tabla.Rows(0)(1).ToString

            Dim _update As String = "UPDATE fichrece SET frec_totunidad='" + unidadesficha + "', frec_totpeso ='" + kiloficha + "' WHERE frec_codi='" + txtcodrece.Text + "'  "

            If fnc.MovimientoSQL(_update) > 0 Then
                'MsgBox("Información actualizada correctamente", MsgBoxStyle.Information, "Aviso")
            Else
                MsgBox("Error al actualizar la información", MsgBoxStyle.Critical, "Aviso")
            End If




        End If

    End Sub
    Private Sub DgvResultado_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvResultado.CellDoubleClick

        Dim codigopro As String = ""
        If e.RowIndex > -1 Then

            Dim SQL10 As String = "select * from detarecbolsa where pallet='" + Me.DgvResultado.Rows(e.RowIndex).Cells(0).Value.ToString() + "'  and estado='1' "
            Dim tabla10 As DataTable = fnc.ListarTablasSQL(SQL10)
            If tabla10.Rows.Count > 0 Then
                MsgBox("Pallet Cerrado Imposible Procesar ", MsgBoxStyle.Critical, "Aviso")
            Else


                Dim SQL As String = "select drec_codi, drec_unidades,drec_peso,drec_codpro from detarece where drec_codi ='" + Me.DgvResultado.Rows(e.RowIndex).Cells(0).Value.ToString() + "' "



                Dim tabla As DataTable = fnc.ListarTablasSQL(SQL)
                If tabla.Rows.Count > 0 Then
                    txtpallet.Text = Me.DgvResultado.Rows(e.RowIndex).Cells(0).Value.ToString()
                    txtbandejas.Text = tabla.Rows(0)(1).ToString
                    txtkilos.Text = tabla.Rows(0)(2).ToString
                    codigopro = tabla.Rows(0)(3).ToString

                    Dim SQL3 As String = "select mae_descr from maeprod where mae_codi='" + codigopro + "'"

                    Dim tabla4 As DataTable = fnc.ListarTablasSQL(SQL3)
                    If tabla4.Rows.Count > 0 Then
                        txtproducto.Text = tabla4.Rows(0)(0).ToString
                    End If

                    Dim sql4 As String = "select max(codbolsa) + 1 from detarecbolsa where pallet='" + txtpallet.Text + "'"
                    Dim tabla5 As DataTable = fnc.ListarTablasSQL(sql4)
                    If tabla5.Rows.Count > 0 Then
                        txtcodigo.Text = tabla5.Rows(0)(0).ToString


                        Dim sql6 As String = "Select codbolsa as BOLSA FROM DETARECBOLSA where pallet ='" + txtpallet.Text + "'"

                        DataGridView1.DataSource = fnc.ListarTablasSQL(sql6)
                        traefinales()




                        If txtcodigo.Text = "" Then
                            txtcodigo.Text = txtpallet.Text.Substring(3, 6) + "01"

                            Dim sql7 As String = "Select codbolsa as BOLSA FROM DETARECBOLSA where pallet ='" + txtpallet.Text + "'"

                            DataGridView1.DataSource = fnc.ListarTablasSQL(sql7)
                            traefinales()
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub Frm_ProcesoBolsa_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If txtpallet.Text = "" Then
            MsgBox("Seleccione Un Pallet", MsgBoxStyle.Critical, "Aviso")

        Else

            If txtkiloetiq.Text = "" Then

                MsgBox("Ingrese Kilos De Bolsa", MsgBoxStyle.Critical, "Aviso")
            Else

                If MsgBox("¿Seguro de imprimir las etiqueta?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbYes Then

                    'Dim cop As String = "COPIA"
                    'COM1.Impresion(txtlote.Text, _
                    '               txtproducto.Text, _
                    '               txtpallet.Text, _
                    '               txtlote.Text, _
                    '              txtkiloetiq.Text, _
                    '               dtp_fecini.Value.ToString(), _
                    '               dtp_fecter.Value.ToString(), _
                    '               txtcodigo.Text, _
                    '               "1780000000" + txtcodigo.Text, dtp_fecini.Value, cop)
                    'Threading.Thread.Sleep(500)
                    Imprimir()

                    proceso()

                    traefinales()

                    txtkiloetiq.Text = ""
                    txtkilos.Focus()



                End If

            End If

        End If


    End Sub


    Private Sub proceso()
        Dim sqp As String = "INSERT INTO detarecbolsa(codrece, lote, pallet, bandejas, kilos,producto,fecha_ela,fecha_ven,kilosbol,codbolsa)" +
                    " VALUES('" + txtcodrece.Text + "','" + txtlote.Text + "','" + txtpallet.Text + "','" + txtbandejas.Text + "','" + txtkilos.Text + "','" + txtproducto.Text + "','" + dtp_fecini.Value + "','" + dtp_fecter.Value + "','" + txtkiloetiq.Text + "','" + txtcodigo.Text + "')"


        fnc.MovimientoSQL(sqp)


        Dim sql6 As String = "Select codbolsa as BOLSA FROM DETARECBOLSA where pallet ='" + txtpallet.Text + "'"

        DataGridView1.DataSource = fnc.ListarTablasSQL(sql6)



        Dim sql4 As String = "select max(codbolsa) + 1 from detarecbolsa where pallet='" + txtpallet.Text + "'"
        Dim tabla5 As DataTable = fnc.ListarTablasSQL(sql4)
        If tabla5.Rows.Count > 0 Then
            txtcodigo.Text = tabla5.Rows(0)(0).ToString


            Dim sql8 As String = "Select codbolsa as BOLSA FROM DETARECBOLSA where pallet ='" + txtpallet.Text + "'"

            DataGridView1.DataSource = fnc.ListarTablasSQL(sql8)
        End If

    End Sub
    Private Sub txtkiloetiq_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtkiloetiq.KeyPress

    End Sub

    Private Sub Frm_ProcesoBolsa_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        f_jibia = False
    End Sub

    Private Sub traefinales()

        Dim SQL As String = "SELECT KILOS,BOLSAS,CLIENTE,ELA,VEN FROM PROCESO_BOLSA_SALDO WHERE PALLET='" + txtpallet.Text + "' "



        Dim tabla As DataTable = fnc.ListarTablasSQL(SQL)
        If tabla.Rows.Count > 0 Then
            txtsacos.Text = tabla.Rows(0)(1).ToString
            txtkilosn.Text = tabla.Rows(0)(0).ToString
            cliente = tabla.Rows(0)(2).ToString
            felaboracion.Value = tabla.Rows(0)(3).ToString
            fvencimiento.Value = tabla.Rows(0)(4).ToString
        End If
    End Sub


#Region "Imprimir etiqueta  Pallet recepcionado"

    Private Sub Imprimir()
        ' imprimir ZEBRA

        Try

            Dim PrintDocument1 As New PrintDocument

            PrintDocument1.PrinterSettings = prtsettings
            AddHandler PrintDocument1.PrintPage, AddressOf print_PrintPage

            Dim sql_Impresora As String = "SELECT imp_etiq, imp_COM1 FROM conf_impresora WHERE imp_comp='" + My.Computer.Name + "'"
            Dim tabla_conf As DataTable = fnc.ListarTablasSQL(sql_Impresora)

            If tabla_conf.Rows.Count > 0 Then

                If tabla_conf.Rows(0)(1).ToString() = "COM1" Then
                    Dim cli = txtlote.Text
                    Dim producto = txtproducto.Text
                    Dim folio_cliente = txtpallet.Text
                    Dim unidades = txtbandejas.Text
                    Dim kilos = txtkiloetiq.Text
                    Dim fproduccion = Convert.ToDateTime(dtp_fecini.Value).ToShortDateString()
                    Dim fvenci = Convert.ToDateTime(dtp_fecter.Value).ToShortDateString()
                    Dim numero_pallet = txtcodigo.Text
                    Dim numero_pallet_Completo = DigitoVerificadorEAN128UCC("17800000" + CerosAnteriorString(CerosAnteriorString(numero_pallet, 2), 7))
                    Dim cop As String = ""

                    COM1.Impresion(cli, producto, folio_cliente, unidades, kilos, fproduccion, fvenci, numero_pallet, "1780000000" + CerosAnteriorString(CerosAnteriorString(numero_pallet, 2), 7), dtp_fecini.Value, cop)

                    Exit Sub
                Else
                    PrintDocument1.PrinterSettings.PrinterName = tabla_conf.Rows(0)(0).ToString()




                End If

            Else
                MsgBox("Debe seleccionar la impresora antes de imprimir una etiqueta", MsgBoxStyle.Critical, "Aviso")
                Exit Sub
            End If

            'PrintDocument1.PrinterSettings.PrinterName = "ZDesigner 105SL 203DPI"
            PrintDocument1.Print()

        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub

    Dim prtsettings = New PrinterSettings()
    Public Sub print_PrintPage(ByVal sender As Object, ByVal e As PrintPageEventArgs)


        Dim cli = txtlote.Text
        Dim producto = txtproducto.Text
        Dim folio_cliente = txtpallet.Text
        Dim unidades = ""
        Dim kilos = txtkiloetiq.Text
        Dim fproduccion = Convert.ToDateTime(dtp_fecini.Value).ToShortDateString()
        Dim fvenci = Convert.ToDateTime(dtp_fecter.Value).ToShortDateString()
        Dim numero_pallet = txtcodigo.Text
        Dim Loo As String = TXTLOCAL.Text
        ' 01 - 02 - 03 - 04 - 05 
        Dim numero_pallet_Completo = DigitoVerificadorEAN128UCC("17800000" + CerosAnteriorString(CerosAnteriorString(numero_pallet, 2), 7))

        Dim sql As String = "SELECT racd_unidades FROM rackdeta WHERE racd_codi='" + numero_pallet + "'"

        Dim dt As DataTable = fnc.ListarTablasSQL(sql)
        Dim stock As String = "0"

        If dt.Rows.Count > 0 Then
            stock = dt.Rows(0)(0).ToString()
        ElseIf Convert.ToDateTime(fnc.DevuelveFechaServidor()).ToShortDateString() = Convert.ToDateTime(dtp_fecini.Value).ToShortDateString() Then
            stock = unidades
        End If
        ' imprimimos la cadena en el margen izquierdo
        Dim xPos As Single = e.MarginBounds.Left

        ' Las fuentes a usar
        Dim prFont As New Font("Arial", 8, FontStyle.Bold)
        Dim Titulo As New Font("Arial", 18, FontStyle.Bold)

        ' dibuja rectangulo
        '    e.Graphics.DrawRectangle(Pens.Black, New Rectangle(3, 8, 375, 385))

        ' imprimir logo -----------------------------------------------
        Dim img_logo As New PictureBox
        img_logo.Image = My.Resources.img_logoZEBRA
        e.Graphics.DrawImage(img_logo.Image, 80, 10, 220, 70)
        '--------------------------------------------------------------

        'e.Graphics.DrawString("       PRECISA FROZEN     ", Titulo, Brushes.Black, 10, 50)
        e.Graphics.DrawString("LOTE", prFont, Brushes.Black, 10, 100)
        e.Graphics.DrawString(": " + cli, prFont, Brushes.Black, 105, 100)

        e.Graphics.DrawString("PRODUCTO", prFont, Brushes.Black, 10, 120)
        e.Graphics.DrawString(": " + producto, prFont, Brushes.Black, 105, 120)

        e.Graphics.DrawString("FOLIO CLIENTE", prFont, Brushes.Black, 10, 140)
        e.Graphics.DrawString(": " + folio_cliente + " LOCAL: " + Loo + " " + stock + " / " + unidades + "   KG: " + kilos, prFont, Brushes.Black, 105, 140)

        e.Graphics.DrawString("F. ELABORACION", prFont, Brushes.Black, 10, 160)
        e.Graphics.DrawString(": " + fproduccion + "   F. VENCIMIENTO: " + fvenci, prFont, Brushes.Black, 105, 160)

        e.Graphics.DrawString("BOLSA: ", New Font("Arial", 18, FontStyle.Bold), Brushes.Black, 10, 180)

        '  e.Graphics.DrawString(numero_pallet, New Font("Franklin Gothic Demi Cond", 60, FontStyle.Bold), Brushes.Black, 0, 200)
        e.Graphics.DrawString(numero_pallet, New Font("Arial", 30, FontStyle.Bold), Brushes.Black, 0, 200)

        '                                                                                          TRUE o FALSE Muestra los numeros bajo el codigo de barras
        Dim bm As Bitmap = BarCode.Code128(numero_pallet_Completo, BarCode.Code128SubTypes.CODE128_UCC, False, 0.0)
        Dim picturebox As New PictureBox

        picturebox.Image = bm

        e.Graphics.DrawImage(picturebox.Image, 10, 290, 350, 50)
        'codigo de barras ------>
        e.Graphics.DrawString(numero_pallet_Completo, New Font("Arial", 16, FontStyle.Bold), Brushes.Black, 50, 350)

        e.HasMorePages = False

    End Sub

    Private Function seleccionarImpresora2() As Boolean
        'Public prtDialog As New PrintDialog
        'If prtSettings Is Nothing Then
        'End If
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

    Private Sub SubImprime2()
        ' ejemplo simple para imprimir en .NET
        ' Usamos una clase del tipo PrintDocument

        Dim printDoc As New PrintDocument
        If seleccionarImpresora() = True Then
            printDoc.PrinterSettings = prtsettings()

            ' asignamos el método de evento para cada página a imprimir()
            AddHandler printDoc.PrintPage, AddressOf print_PrintPage
            ' indicamos que queremos imprimir
            printDoc.Print()
        End If
    End Sub

    Public Sub DrawPointsHelper2(ByVal e As PaintEventArgs, ByVal pathPoints() As PointF, ByVal xOffset As Integer)
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



    'TxtPallet.Text = Me.DetaRece.Rows(fila_grilladetalle).Cells("Cod_Pallet").Value.ToString()
    'txtprodcod.Text = Me.DetaRece.Rows(fila_grilladetalle).Cells("Cod_Producto").Value.ToString()
    'txtprodnom.Text = Me.DetaRece.Rows(fila_grilladetalle).Cells("Nombre_Producto").Value.ToString()
    'txtsopcodi.Text = Me.DetaRece.Rows(fila_grilladetalle).Cells("CodSopo").Value.ToString()
    'txtsopnombre.Text = Me.DetaRece.Rows(fila_grilladetalle).Cells("NomSopo").Value.ToString()
    'txtunid.Text = Me.DetaRece.Rows(fila_grilladetalle).Cells("Cant_Pallets").Value.ToString()
    'kg.Text = Me.DetaRece.Rows(fila_grilladetalle).Cells("Peso").Value.ToString()
    'felaboracion.Value = devuelve_fecha(Me.DetaRece.Rows(fila_grilladetalle).Cells("Elaboracion").Value.ToString())
    'fvencimiento.Value = devuelve_fecha(Me.DetaRece.Rows(fila_grilladetalle).Cells("Vencimiento").Value.ToString())
    'loteclie.Text = Me.DetaRece.Rows(fila_grilladetalle).Cells("Lote").Value.ToString()
    'txtcodsag.Text = Me.DetaRece.Rows(fila_grilladetalle).Cells("Codsag").Value.ToString()
    'txtsopclie.Text = Me.DetaRece.Rows(fila_grilladetalle).Cells("SopCliente").Value.ToString()




#End Region
    

    Private Sub insertmovpallet()

        Dim resta As Integer = 0
        resta = Convert.ToInt32(txtbandejas.Text) - Convert.ToInt32(txtsacos.Text)
        Srack = resta.ToString


        Dim SqlMovpallet As String = "INSERT INTO movpallet(mov_folio, mov_codper, mov_ca, mov_ba, mov_co, mov_pi, mov_ni, mov_fecha, mov_tipo, mov_hora, mov_doc, mov_saldo,  mov_anden, mov_TS,mov_despacho)" +
                                                    "VALUES('" + txtpallet.Text + "','" + Frm_Principal.InfoUsuario.Text + "','00'," +
                                                    "'00','00','00','0','" + devuelve_fecha(dtp_fecini.Value) + "','SP','" + DevuelveHora() + "','" + txtcodrece.Text + "','" + txtsacos.Text + "'," +
                                                    "'','','" + Srack + "')"

        fnc.MovimientoSQL(SqlMovpallet)
    End Sub

    Private Sub limpia()

        txtproducto.Text = ""
        txtcodigo.Text = ""
        txtkiloetiq.Text = ""
        txtsacos.Text = ""
        txtkilosn.Text = ""
        txtpallet.Text = ""
        txtbandejas.Text = ""
        txtkilos.Text = ""

        Dim sql6 As String = "Select codbolsa as BOLSA FROM DETARECBOLSA where pallet ='" + txtpallet.Text + "'"

        DataGridView1.DataSource = fnc.ListarTablasSQL(sql6)

    End Sub


    Private Sub DataGridView1_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick

        If e.RowIndex > -1 AndAlso e.ColumnIndex = 0 Then
            If MsgBox("¿Seguro de eliminar el pallet seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbYes Then
                Dim sql9 As String = "DELETE FROM detarecbolsa  WHERE codbolsa='" + DataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString() + "'"

                If fnc.MovimientoSQL(sql9) > 0 Then
                    MsgBox("Registro eliminado", MsgBoxStyle.Information, "Aviso")


                    Dim sql8 As String = "Select codbolsa as BOLSA FROM DETARECBOLSA where pallet ='" + txtpallet.Text + "'"

                    DataGridView1.DataSource = fnc.ListarTablasSQL(sql8)
                    traefinales()
                End If
            End If
        End If
    End Sub


    Private Sub modificadetalle()
        Dim _update As String = "UPDATE detarece SET drec_unidades='" + txtsacos.Text + "', drec_peso='" + txtkilosn.Text + "' WHERE drec_codi='" + txtpallet.Text + "'  "

        If fnc.MovimientoSQL(_update) > 0 Then
            'MsgBox("Información actualizada correctamente", MsgBoxStyle.Information, "Aviso")
        Else
            MsgBox("Error al actualizar la información", MsgBoxStyle.Critical, "Aviso")
        End If
    End Sub

    Private Sub modificarackdeta()
        Dim _update As String = "UPDATE rackdeta SET racd_unidades='" + txtsacos.Text + "', racd_peso='" + txtkilosn.Text + "' WHERE racd_codi='" + txtpallet.Text + "'  "

        If fnc.MovimientoSQL(_update) > 0 Then
            'MsgBox("Información actualizada correctamente", MsgBoxStyle.Information, "Aviso")
        Else
            MsgBox("Error al actualizar la información", MsgBoxStyle.Critical, "Aviso")
        End If
    End Sub
    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        If MsgBox("¿Seguro de Cerrar el pallet seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbYes Then
            Dim estad As String = "1"
            Dim _update As String = "UPDATE detarecbolsa SET estado='" + estad + "' WHERE pallet='" + txtpallet.Text + "'  "

            If fnc.MovimientoSQL(_update) > 0 Then
                MsgBox("Pallet Cerrado correctamente", MsgBoxStyle.Information, "Aviso")
                traefinales()

                Imprimir2()
                modificadetalle()
                modificaficha()
                modificarackdeta()
                insertmovpallet()
                limpia()


            Else

            End If
        End If



    End Sub


#Region "Imprimir etiqueta  Pallet recepcionado2"

    Private Sub Imprimir2()
        ' imprimir ZEBRA

        Try

            Dim PrintDocument1 As New PrintDocument

            PrintDocument1.PrinterSettings = prtsettings
            AddHandler PrintDocument1.PrintPage, AddressOf print_PrintPage2

            Dim sql_Impresora As String = "SELECT imp_etiq, imp_COM1 FROM conf_impresora WHERE imp_comp='" + My.Computer.Name + "'"
            Dim tabla_conf As DataTable = fnc.ListarTablasSQL(sql_Impresora)

            If tabla_conf.Rows.Count > 0 Then

                If tabla_conf.Rows(0)(1).ToString() = "COM1" Then
                    Dim cli = cliente
                    Dim producto = txtproducto.Text
                    Dim folio_cliente = txtpallet.Text
                    Dim unidades = txtsacos.Text
                    Dim kilos = txtkilosn.Text
                    Dim fproduccion = Convert.ToDateTime(felaboracion.Value).ToShortDateString()
                    Dim fvenci = Convert.ToDateTime(fvencimiento.Value).ToShortDateString()
                    Dim numero_pallet = txtpallet.Text
                    Dim numero_pallet_Completo = DigitoVerificadorEAN128UCC("1780000000" + CerosAnteriorString(CerosAnteriorString(numero_pallet, 2), 7))
                    Dim cop As String = ""

                    COM1.Impresion(cli, producto, folio_cliente, unidades, kilos, fproduccion, fvenci, numero_pallet, "1780000000" + CerosAnteriorString(CerosAnteriorString(numero_pallet, 2), 7), dtp_fecini.Value, cop)

                    Exit Sub
                Else
                    PrintDocument1.PrinterSettings.PrinterName = tabla_conf.Rows(0)(0).ToString()




                End If

            Else
                MsgBox("Debe seleccionar la impresora antes de imprimir una etiqueta", MsgBoxStyle.Critical, "Aviso")
                Exit Sub
            End If

            'PrintDocument1.PrinterSettings.PrinterName = "ZDesigner 105SL 203DPI"
            PrintDocument1.Print()

        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub

    Dim prtsettings2 = New PrinterSettings()
    Public Sub print_PrintPage2(ByVal sender As Object, ByVal e As PrintPageEventArgs)


        Dim cli = cliente
        Dim producto = txtproducto.Text
        Dim folio_cliente = txtpallet.Text
        Dim unidades = txtsacos.Text
        Dim kilos = txtkilosn.Text
        Dim fproduccion = Convert.ToDateTime(felaboracion.Value).ToShortDateString()
        Dim fvenci = Convert.ToDateTime(fvencimiento.Value).ToShortDateString()
        Dim numero_pallet = txtpallet.Text

        ' 01 - 02 - 03 - 04 - 05 
        Dim numero_pallet_Completo = DigitoVerificadorEAN128UCC("1780000000" + CerosAnteriorString(CerosAnteriorString(numero_pallet, 2), 7))

        Dim sql As String = "SELECT racd_unidades FROM rackdeta WHERE racd_codi='" + numero_pallet + "'"

        Dim dt As DataTable = fnc.ListarTablasSQL(sql)
        Dim stock As String = "0"

        If dt.Rows.Count > 0 Then
            stock = dt.Rows(0)(0).ToString()
        ElseIf Convert.ToDateTime(fnc.DevuelveFechaServidor()).ToShortDateString() = Convert.ToDateTime(dtp_fecini.Value).ToShortDateString() Then
            stock = unidades
        End If
        ' imprimimos la cadena en el margen izquierdo
        Dim xPos As Single = e.MarginBounds.Left

        ' Las fuentes a usar
        Dim prFont As New Font("Arial", 8, FontStyle.Bold)
        Dim Titulo As New Font("Arial", 18, FontStyle.Bold)

        ' dibuja rectangulo
        '    e.Graphics.DrawRectangle(Pens.Black, New Rectangle(3, 8, 375, 385))

        ' imprimir logo -----------------------------------------------
        Dim img_logo As New PictureBox
        img_logo.Image = My.Resources.img_logoZEBRA
        e.Graphics.DrawImage(img_logo.Image, 80, 10, 220, 70)
        '--------------------------------------------------------------

        'e.Graphics.DrawString("       PRECISA FROZEN     ", Titulo, Brushes.Black, 10, 50)
        e.Graphics.DrawString("CLIENTE", prFont, Brushes.Black, 10, 100)
        e.Graphics.DrawString(": " + cli, prFont, Brushes.Black, 105, 100)

        e.Graphics.DrawString("PRODUCTO", prFont, Brushes.Black, 10, 120)
        e.Graphics.DrawString(": " + producto, prFont, Brushes.Black, 105, 120)

        e.Graphics.DrawString("FOLIO CLIENTE", prFont, Brushes.Black, 10, 140)
        e.Graphics.DrawString(": " + folio_cliente + " UND: " + stock + " / " + unidades + "   KG: " + kilos, prFont, Brushes.Black, 105, 140)

        e.Graphics.DrawString("F. PRODUCCION", prFont, Brushes.Black, 10, 160)
        e.Graphics.DrawString(": " + fproduccion + "   F. VENCIMIENTO: " + fvenci, prFont, Brushes.Black, 105, 160)

        e.Graphics.DrawString("PALLET: ", New Font("Arial", 18, FontStyle.Bold), Brushes.Black, 10, 180)

        '  e.Graphics.DrawString(numero_pallet, New Font("Franklin Gothic Demi Cond", 60, FontStyle.Bold), Brushes.Black, 0, 200)
        e.Graphics.DrawString(numero_pallet, New Font("Arial", 50, FontStyle.Bold), Brushes.Black, 0, 200)

        '                                                                                          TRUE o FALSE Muestra los numeros bajo el codigo de barras
        Dim bm As Bitmap = BarCode.Code128(numero_pallet_Completo, BarCode.Code128SubTypes.CODE128_UCC, False, 0.0)
        Dim picturebox As New PictureBox

        picturebox.Image = bm

        e.Graphics.DrawImage(picturebox.Image, 10, 290, 350, 50)
        'codigo de barras ------>
        e.Graphics.DrawString(numero_pallet_Completo, New Font("Arial", 16, FontStyle.Bold), Brushes.Black, 50, 350)

        e.HasMorePages = False

    End Sub

    Private Function seleccionarImpresora() As Boolean
        'Public prtDialog As New PrintDialog
        'If prtSettings Is Nothing Then
        'End If
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
            AddHandler printDoc.PrintPage, AddressOf print_PrintPage
            ' indicamos que queremos imprimir
            printDoc.Print()
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
    Private Sub IMPREANTIGUA()

    End Sub


#End Region


End Class
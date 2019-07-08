Imports System.Net.NetworkInformation
Imports System.Text
Imports System.Net.Mail
Imports System.Net.Mime
Imports System.Net
Imports System.IO
Imports System.Reflection
Imports System.Collections.Generic
Imports System.Environment
Imports CrystalDecisions.Windows.Forms
Imports System.Configuration
Imports System.Security.Cryptography
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient

Public Class Frm_ServiciosREC
    Dim fnc As New Funciones
    Dim film As String
    Dim con As New Conexion
    Dim repa As String
    Dim retiro As String
    Dim etique As String
    Dim carga As String
    Dim descarga As String
    Private Sub Frm_ServiciosREC_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load


        Dim SqlBusca As String = "SELECT TOP 9 FREC_CODI FROM fichrece ORDER BY FREC_CODI DESC"

        Dim tablarece As DataTable = fnc.ListarTablasSQL(SqlBusca)

        If tablarece.Rows.Count > 0 Then

            txtrece1.Text = tablarece.Rows(0)(0).ToString()
            txtrece2.Text = tablarece.Rows(1)(0).ToString()
            txtrece3.Text = tablarece.Rows(2)(0).ToString()
            txtrece4.Text = tablarece.Rows(3)(0).ToString()
            txtrece5.Text = tablarece.Rows(4)(0).ToString()
            txtrece6.Text = tablarece.Rows(5)(0).ToString()
            txtrece7.Text = tablarece.Rows(6)(0).ToString()
            txtrece8.Text = tablarece.Rows(7)(0).ToString()
            txtrece9.Text = tablarece.Rows(8)(0).ToString()
            pintarece1()
            pintarece2()
            pintarece3()
            pintarece4()
            pintarece5()
            pintarece6()
            pintarece7()
            pintarece8()
            pintarece9()

        End If
        txtrece0.Focus()
    End Sub
    Private Sub pintagrilla()
        For i As Integer = 0 To DgvResultado.Rows.Count - 1
            Dim sql As String = "Select * from detaservicios where pallet='" + Me.DgvResultado.Rows(i).Cells(0).Value.ToString() + "'"
            Dim tabla As DataTable = fnc.ListarTablasSQL(sql)
            If tabla.Rows.Count > 0 Then
                '      MsgBox("paso ")


                Me.DgvResultado.Rows(i).Cells(0).Style.BackColor = Color.MediumSeaGreen


                Me.DgvResultado.Rows(i).Cells(0).Style.ForeColor = Color.White




            End If
        Next
    End Sub
    Private Sub pintarece1()

        Dim SqlBusca As String = "SELECT * FROM DETASERVICIOS where recepcion= '" + txtrece1.Text + "'"

        Dim tablarece As DataTable = fnc.ListarTablasSQL(SqlBusca)

        If tablarece.Rows.Count > 0 Then
            If tablarece.Rows(0)(9).ToString() = "OK" Then
                txtrece1.BackColor = Color.Green
                txtrece1.ForeColor = Color.White
            Else
                txtrece1.BackColor = Color.Yellow
                txtrece1.ForeColor = Color.Black

            End If
        End If


    End Sub
    Private Sub pintarece2()

        Dim SqlBusca As String = "SELECT * FROM DETASERVICIOS where recepcion= '" + txtrece2.Text + "'"

        Dim tablarece As DataTable = fnc.ListarTablasSQL(SqlBusca)

        If tablarece.Rows.Count > 0 Then
            If tablarece.Rows(0)(9).ToString() = "OK" Then
                txtrece2.BackColor = Color.Green
                txtrece2.ForeColor = Color.White
            Else
                txtrece2.BackColor = Color.Yellow
                txtrece2.ForeColor = Color.Black

            End If
        End If


    End Sub
    Private Sub pintarece3()

        Dim SqlBusca As String = "SELECT * FROM DETASERVICIOS where recepcion= '" + txtrece3.Text + "'"

        Dim tablarece As DataTable = fnc.ListarTablasSQL(SqlBusca)

        If tablarece.Rows.Count > 0 Then
            If tablarece.Rows(0)(9).ToString() = "OK" Then
                txtrece3.BackColor = Color.Green
                txtrece3.ForeColor = Color.White
            Else
                txtrece3.BackColor = Color.Yellow
                txtrece3.ForeColor = Color.Black

            End If
        End If


    End Sub
    Private Sub pintarece4()

        Dim SqlBusca As String = "SELECT * FROM DETASERVICIOS where recepcion= '" + txtrece4.Text + "'"

        Dim tablarece As DataTable = fnc.ListarTablasSQL(SqlBusca)

        If tablarece.Rows.Count > 0 Then
            If tablarece.Rows(0)(9).ToString() = "OK" Then
                txtrece4.BackColor = Color.Green
                txtrece4.ForeColor = Color.White
            Else
                txtrece4.BackColor = Color.Yellow
                txtrece4.ForeColor = Color.Black

            End If
        End If


    End Sub
    Private Sub pintarece5()

        Dim SqlBusca As String = "SELECT * FROM DETASERVICIOS where recepcion= '" + txtrece5.Text + "'"

        Dim tablarece As DataTable = fnc.ListarTablasSQL(SqlBusca)

        If tablarece.Rows.Count > 0 Then
            If tablarece.Rows(0)(9).ToString() = "OK" Then
                txtrece5.BackColor = Color.Green
                txtrece5.ForeColor = Color.White
            Else
                txtrece5.BackColor = Color.Yellow
                txtrece5.ForeColor = Color.Black

            End If
        End If


    End Sub
    Private Sub pintarece6()

        Dim SqlBusca As String = "SELECT * FROM DETASERVICIOS where recepcion= '" + txtrece6.Text + "'"

        Dim tablarece As DataTable = fnc.ListarTablasSQL(SqlBusca)

        If tablarece.Rows.Count > 0 Then
            If tablarece.Rows(0)(9).ToString() = "OK" Then
                txtrece6.BackColor = Color.Green
                txtrece6.ForeColor = Color.White
            Else
                txtrece6.BackColor = Color.Yellow
                txtrece6.ForeColor = Color.Black

            End If
        End If


    End Sub
    Private Sub pintarece7()

        Dim SqlBusca As String = "SELECT * FROM DETASERVICIOS where recepcion= '" + txtrece7.Text + "'"

        Dim tablarece As DataTable = fnc.ListarTablasSQL(SqlBusca)

        If tablarece.Rows.Count > 0 Then
            If tablarece.Rows(0)(9).ToString() = "OK" Then
                txtrece7.BackColor = Color.Green
                txtrece7.ForeColor = Color.White
            Else
                txtrece7.BackColor = Color.Yellow
                txtrece7.ForeColor = Color.Black

            End If
        End If


    End Sub
    Private Sub pintarece8()

        Dim SqlBusca As String = "SELECT * FROM DETASERVICIOS where recepcion= '" + txtrece8.Text + "'"

        Dim tablarece As DataTable = fnc.ListarTablasSQL(SqlBusca)

        If tablarece.Rows.Count > 0 Then
            If tablarece.Rows(0)(9).ToString() = "OK" Then
                txtrece8.BackColor = Color.Green
                txtrece8.ForeColor = Color.White
            Else
                txtrece8.BackColor = Color.Yellow
                txtrece8.ForeColor = Color.Black

            End If
        End If


    End Sub
    Private Sub pintarece9()

        Dim SqlBusca As String = "SELECT * FROM DETASERVICIOS where recepcion= '" + txtrece9.Text + "'"

        Dim tablarece As DataTable = fnc.ListarTablasSQL(SqlBusca)

        If tablarece.Rows.Count > 0 Then
            If tablarece.Rows(0)(9).ToString() = "OK" Then
                txtrece9.BackColor = Color.Green
                txtrece9.ForeColor = Color.White
            Else
                txtrece9.BackColor = Color.Yellow
                txtrece9.ForeColor = Color.Black

            End If
        End If


    End Sub
    Private Sub txtrece1_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtrece1.TextChanged

    End Sub

    Private Sub txtrece1_DoubleClick(sender As System.Object, e As System.EventArgs) Handles txtrece1.DoubleClick
        Dim strSQL As String
        If txtrece1.BackColor = Color.Green Then
        Else

            If ComboBox1.Text = "RECEPCION" Then
                strSQL = "SELECT drec_codi As PALLETS from detarece where drec_codi like '" + txtrece1.Text + "%" + "'"
                DgvResultado.DataSource = fnc.ListarTablasSQL(strSQL)
                lblrece.Text = txtrece1.Text
            Else
                strSQL = "SELECT ddes_codrece As PALLETS from detadespa where ddes_codi like '" + txtrece1.Text + "%" + "'"
                DgvResultado.DataSource = fnc.ListarTablasSQL(strSQL)
                lblrece.Text = txtrece1.Text
            End If
            
        End If
        pintagrilla()
    End Sub

    Private Sub txtrece2_DoubleClick(sender As System.Object, e As System.EventArgs) Handles txtrece2.DoubleClick
        Dim strSQL As String
        If txtrece2.BackColor = Color.Green Then
        Else

            If ComboBox1.Text = "RECEPCION" Then
                strSQL = "SELECT drec_codi As PALLETS from detarece where drec_codi like '" + txtrece2.Text + "%" + "'"
                DgvResultado.DataSource = fnc.ListarTablasSQL(strSQL)
                lblrece.Text = txtrece2.Text
            Else
                strSQL = "SELECT ddes_codrece As PALLETS from detadespa where ddes_codi like '" + txtrece2.Text + "%" + "'"
                DgvResultado.DataSource = fnc.ListarTablasSQL(strSQL)
                lblrece.Text = txtrece2.Text
            End If
           
        End If
        pintagrilla()

    End Sub

    Private Sub txtrece3_DoubleClick(sender As System.Object, e As System.EventArgs) Handles txtrece3.DoubleClick
        Dim strSQL As String
        If txtrece3.BackColor = Color.Green Then
        Else
            If ComboBox1.Text = "RECEPCION" Then
                strSQL = "SELECT drec_codi As PALLETS from detarece where drec_codi like '" + txtrece3.Text + "%" + "'"
                DgvResultado.DataSource = fnc.ListarTablasSQL(strSQL)
                lblrece.Text = txtrece3.Text
            Else
                strSQL = "SELECT ddes_codrece As PALLETS from detadespa where ddes_codi like '" + txtrece3.Text + "%" + "'"
                DgvResultado.DataSource = fnc.ListarTablasSQL(strSQL)
                lblrece.Text = txtrece3.Text
            End If

            
        End If
        pintagrilla()

    End Sub

    Private Sub txtrece4_DoubleClick(sender As System.Object, e As System.EventArgs) Handles txtrece4.DoubleClick
        Dim strSQL As String
        If txtrece4.BackColor = Color.Green Then
        Else

            If ComboBox1.Text = "RECEPCION" Then

                strSQL = "SELECT drec_codi As PALLETS from detarece where drec_codi like '" + txtrece4.Text + "%" + "'"
                DgvResultado.DataSource = fnc.ListarTablasSQL(strSQL)
                lblrece.Text = txtrece4.Text
            Else
                strSQL = "SELECT ddes_codrece As PALLETS from detadespa where ddes_codi like '" + txtrece4.Text + "%" + "'"
                DgvResultado.DataSource = fnc.ListarTablasSQL(strSQL)
                lblrece.Text = txtrece4.Text
            End If
            
        End If
        pintagrilla()

    End Sub

    Private Sub txtrece5_DoubleClick(sender As System.Object, e As System.EventArgs) Handles txtrece5.DoubleClick
        Dim strSQL As String
        If txtrece5.BackColor = Color.Green Then
        Else

            If ComboBox1.Text = "RECEPCION" Then
                strSQL = "SELECT drec_codi As PALLETS from detarece where drec_codi like '" + txtrece5.Text + "%" + "'"
                DgvResultado.DataSource = fnc.ListarTablasSQL(strSQL)
                lblrece.Text = txtrece5.Text
            Else
                strSQL = "SELECT ddes_codrece As PALLETS from detadespa where ddes_codi like '" + txtrece5.Text + "%" + "'"
                DgvResultado.DataSource = fnc.ListarTablasSQL(strSQL)
                lblrece.Text = txtrece5.Text
            End If
          
        End If
        pintagrilla()

    End Sub

    Private Sub txtrece6_DoubleClick(sender As System.Object, e As System.EventArgs) Handles txtrece6.DoubleClick
        Dim strSQL As String
        If txtrece6.BackColor = Color.Green Then
        Else
            If ComboBox1.Text = "RECEPCION" Then

                strSQL = "SELECT drec_codi As PALLETS from detarece where drec_codi like '" + txtrece6.Text + "%" + "'"
                DgvResultado.DataSource = fnc.ListarTablasSQL(strSQL)
                lblrece.Text = txtrece6.Text
            Else

                strSQL = "SELECT ddes_codrece As PALLETS from detadespa where ddes_codi like '" + txtrece6.Text + "%" + "'"
                DgvResultado.DataSource = fnc.ListarTablasSQL(strSQL)
                lblrece.Text = txtrece6.Text
            End If

        End If
        pintagrilla()

    End Sub

    Private Sub txtrece7_DoubleClick(sender As System.Object, e As System.EventArgs) Handles txtrece7.DoubleClick
        Dim strSQL As String
        If txtrece7.BackColor = Color.Green Then
        Else
            If ComboBox1.Text = "RECEPCION" Then
                strSQL = "SELECT drec_codi As PALLETS from detarece where drec_codi like '" + txtrece7.Text + "%" + "'"
                DgvResultado.DataSource = fnc.ListarTablasSQL(strSQL)
                lblrece.Text = txtrece7.Text
            Else
                strSQL = "SELECT ddes_codrece As PALLETS from detadespa where ddes_codi like '" + txtrece7.Text + "%" + "'"
                DgvResultado.DataSource = fnc.ListarTablasSQL(strSQL)
                lblrece.Text = txtrece7.Text

            End If

         
        End If
        pintagrilla()

    End Sub

    Private Sub txtrece8_DoubleClick(sender As System.Object, e As System.EventArgs) Handles txtrece8.DoubleClick
        Dim strSQL As String
        If txtrece8.BackColor = Color.Green Then
        Else

            If ComboBox1.Text = "RECEPCION" Then
                strSQL = "SELECT drec_codi As PALLETS from detarece where drec_codi like '" + txtrece8.Text + "%" + "'"
                DgvResultado.DataSource = fnc.ListarTablasSQL(strSQL)
                lblrece.Text = txtrece8.Text
            Else

                strSQL = "SELECT ddes_codrece As PALLETS from detadespa where ddes_codi like '" + txtrece8.Text + "%" + "'"
                DgvResultado.DataSource = fnc.ListarTablasSQL(strSQL)
                lblrece.Text = txtrece8.Text
            End If
       
        End If
        pintagrilla()

    End Sub


    Private Sub txtrece9_DoubleClick(sender As System.Object, e As System.EventArgs) Handles txtrece9.DoubleClick
        Dim strSQL As String
        If txtrece9.BackColor = Color.Green Then
        Else
            If ComboBox1.Text = "RECEPCION" Then

                strSQL = "SELECT drec_codi As PALLETS from detarece where drec_codi like '" + txtrece9.Text + "%" + "'"
                DgvResultado.DataSource = fnc.ListarTablasSQL(strSQL)
                lblrece.Text = txtrece9.Text
            Else

                strSQL = "SELECT ddes_codrece As PALLETS from detadespa where ddes_codi like '" + txtrece9.Text + "%" + "'"
                DgvResultado.DataSource = fnc.ListarTablasSQL(strSQL)
                lblrece.Text = txtrece9.Text

            End If

        End If
        pintagrilla()

    End Sub

    Private Sub btn_guardar_Click(sender As System.Object, e As System.EventArgs) Handles btn_guardar.Click
        If lblpallet.Text = "000000000" Then

        Else

            Dim SqlBusca As String = "SELECT * FROM detaservicios where pallet = '" + lblpallet.Text + "' "

            Dim tablarece As DataTable = fnc.ListarTablasSQL(SqlBusca)

            If tablarece.Rows.Count > 0 Then
                modificar()

            Else
                GRABARPALLET()

                pintagrilla()


            End If
        End If
    End Sub
    Public Function ListarTablasSQL(ByVal Consulta_sql As String)
        Dim tabla As DataTable = New DataTable
        Try
            con.conectar()

            Dim Listado As SqlDataAdapter = New SqlDataAdapter(Consulta_sql, con.con)

            Listado.Fill(tabla)

            con.cerrar()
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
        'retornar tabla con datos
        Return tabla

    End Function
    Private Sub GRABARPALLET()
        validaserv()
        Dim SqlBusca As String = "SELECT * FROM detaservicios where recepcion = '" + lblrece.Text + "' and est_fin='OK' "

        Dim tablarece As DataTable = fnc.ListarTablasSQL(SqlBusca)

        If tablarece.Rows.Count > 0 Then

            MsgBox("Imposible modificar recepciones finalizadas", MsgBoxStyle.Exclamation, "Aviso")
        Else

            Dim qry As String
            qry = "  INSERT INTO detaservicios(RECEPCION,PALLET,FILM,REPA,RETIRO,ETIQUETADO,CARGAAPISO,DESCARGA,OBS,RESPONSABLE)"
            qry += " VALUES('" + lblrece.Text + "','" + lblpallet.Text + "','" + film + "','" + repa + "','" + retiro + "','" + etique + "','" + carga + "','" + descarga + "','" + Txtobs.Text + "','" + Frm_Principal.InfoUsuario.Text + "')"

            MsgBox("Servicios Guardados", MsgBoxStyle.Information, "Aviso")
            fnc.MovimientoSQL(qry)

        End If
    End Sub
    Private Sub modificar()
        validaserv()

        Dim SqlBusca As String = "SELECT * FROM detaservicios where recepcion = '" + lblrece.Text + "' and est_fin='OK' "

        Dim tablarece As DataTable = fnc.ListarTablasSQL(SqlBusca)

        If tablarece.Rows.Count > 0 Then

            MsgBox("Imposible modificar recepciones finalizadas", MsgBoxStyle.Exclamation, "Aviso")
        Else

            Dim sqlActualizaChecklist = "UPDATE detaservicios SET FILM='" + film + "',repa='" + repa + "',retiro='" + retiro + "',etiquetado='" + etique + "',cargaapiso='" + carga + "',descarga='" + descarga + "',obs='" + Txtobs.Text + "' " +
                                                  "WHERE pallet='" + lblpallet.Text + "'"

            MsgBox("Servicios Actualizados", MsgBoxStyle.Information, "Aviso")
            fnc.MovimientoSQL(sqlActualizaChecklist)

        End If
    End Sub
    Private Sub validaserv()

        If chkfilm.Checked = True Then
            film = "SI"
        Else
            film = "NO"
        End If
        If chkrepa.Checked = True Then
            repa = "SI"
        Else
            repa = "NO"
        End If
        If chkretiro.Checked = True Then
            retiro = "SI"
        Else
            retiro = "NO"
        End If
        If chketiquetado.Checked = True Then
            etique = "SI"
        Else
            etique = "NO"
        End If
        If chkcargaapiso.Checked = True Then
            carga = "SI"
        Else
            carga = "NO"
        End If
        If chkdescarga.Checked = True Then
            descarga = "SI"
        Else
            descarga = "NO"
        End If
    End Sub
    Private Sub limpiaservicios()
        film = "NO"
        repa = "NO"
        retiro = "NO"
        etique = "NO"
        carga = "NO"
        descarga = "NO"
        Txtobs.Text = ""
        llenacheck()
        lblpallet.Text = "000000000"
        lblestado.Text = "."
    End Sub
    Private Sub DgvResultado_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvResultado.CellDoubleClick
        limpiaservicios()

        If e.RowIndex >= 0 Then
            lblpallet.Text = Me.DgvResultado.Rows(e.RowIndex).Cells(0).Value.ToString()
            TRAEPALLET()
        End If

    End Sub
    Private Sub TRAEPALLET()
        Dim SqlBusca As String = "SELECT * FROM detaservicios where pallet = '" + lblpallet.Text + "' "

        Dim tablarece As DataTable = fnc.ListarTablasSQL(SqlBusca)

        If tablarece.Rows.Count > 0 Then
            Txtobs.Text = tablarece.Rows(0)(8).ToString()
            film = tablarece.Rows(0)(2).ToString()
            repa = tablarece.Rows(0)(3).ToString()
            retiro = tablarece.Rows(0)(4).ToString()
            etique = tablarece.Rows(0)(5).ToString()
            carga = tablarece.Rows(0)(6).ToString()
            descarga = tablarece.Rows(0)(7).ToString()
            llenacheck()
        End If
    End Sub
    Private Sub btn_nuevo_Click(sender As System.Object, e As System.EventArgs) Handles btn_nuevo.Click
        limpiaservicios()
        lblpallet.Text = "000000000"
        lblrece.Text = "0000000"
        lblestado.Text = "."
        Dim strSQL As String

        strSQL = "SELECT drec_codi As PALLETS from detarece where drec_codi like '" + lblrece.Text + "%" + "'"
        DgvResultado.DataSource = fnc.ListarTablasSQL(strSQL)
        txtrece0.Focus()

    End Sub
    Private Sub llenacheck()
        If film = "SI" Then
            chkfilm.Checked = True

        Else
            chkfilm.Checked = False
        End If
        If repa = "SI" Then
            chkrepa.Checked = True

        Else
            chkrepa.Checked = False
        End If
        If retiro = "SI" Then
            chkretiro.Checked = True

        Else
            chkretiro.Checked = False
        End If
        If etique = "SI" Then
            chketiquetado.Checked = True

        Else
            chketiquetado.Checked = False
        End If
        If carga = "SI" Then
            chkcargaapiso.Checked = True

        Else
            chkcargaapiso.Checked = False
        End If
        If descarga = "SI" Then
            chkdescarga.Checked = True

        Else
            chkdescarga.Checked = False
        End If
    End Sub
    Private Sub chkrepa_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkrepa.CheckedChanged

    End Sub

    Private Sub txtrece0_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtrece0.KeyPress
        If e.KeyChar = ChrW(13) Then
            If txtrece0.TextLength = 7 Then



                limpiaservicios()

                Dim strSQL As String
                If ComboBox1.Text = "RECEPCION" Then
                    strSQL = "SELECT drec_codi As PALLETS from detarece where drec_codi like '" + txtrece0.Text + "%" + "'"
                    DgvResultado.DataSource = fnc.ListarTablasSQL(strSQL)
                    lblrece.Text = txtrece0.Text

                Else
                    strSQL = "SELECT ddes_codrece As PALLETS from detadespa where ddes_codi like '" + txtrece0.Text + "%" + "'"
                    DgvResultado.DataSource = fnc.ListarTablasSQL(strSQL)
                    lblrece.Text = txtrece0.Text


                End If
            



                pintagrilla()
                Dim SqlBusca As String = "SELECT * FROM detaservicios where recepcion = '" + lblrece.Text + "' "

                Dim tablarece As DataTable = fnc.ListarTablasSQL(SqlBusca)

                If tablarece.Rows.Count > 0 Then
                    lblestado.Text = tablarece.Rows(0)(9).ToString()
                End If
            End If
        End If
    End Sub

    Private Sub Btn_AnulaGuia_Click(sender As System.Object, e As System.EventArgs) Handles Btn_AnulaGuia.Click
        cerrarrece()
        MsgBox("Recepcion Cerrada", MsgBoxStyle.Information, "Aviso")
    End Sub
    Private Sub cerrarrece()
        Dim sqlActualizaChecklist = "UPDATE detaservicios SET est_fin='OK' " +
                                              "WHERE recepcion='" + lblrece.Text + "'"
        fnc.MovimientoSQL(sqlActualizaChecklist)

        Enviarcorreo()

    End Sub
    Function ArchivoAString(ByVal ruta As String) As String
        Dim objReader As New StreamReader(ruta)
        Dim sLine As String = ""
        Dim Texto As String = ""
        Do
            sLine = objReader.ReadLine()
            If Not sLine Is Nothing Then
                Texto = Texto + sLine + vbNewLine
            End If
        Loop Until sLine Is Nothing
        objReader.Close()
        Return Texto
    End Function
    Private Function BodyDisponibilidad() As AlternateView

        Dim archivo As String = ArchivoAString((My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\Disponibles.txt"))

        Dim htmlView As AlternateView = AlternateView.CreateAlternateViewFromString(archivo, Encoding.UTF8, MediaTypeNames.Text.Html)
        Dim img As LinkedResource = New LinkedResource(My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\img_ma.jpg", MediaTypeNames.Image.Jpeg)
        img.ContentId = "MedioAmbiente"

        Dim htmlView2 As AlternateView = AlternateView.CreateAlternateViewFromString(archivo, Encoding.UTF8, MediaTypeNames.Text.Html)
        Dim cabecera As LinkedResource = New LinkedResource(My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\titulocamaras.jpg", MediaTypeNames.Image.Jpeg)
        cabecera.ContentId = "titulo"

        htmlView.LinkedResources.Add(cabecera)
        htmlView.LinkedResources.Add(img)


        Return htmlView

    End Function

    Public Function Enviarcorreo() As Boolean

        Dim smtp As New System.Net.Mail.SmtpClient
        Dim correo As New System.Net.Mail.MailMessage
        Dim adjunto As System.Net.Mail.Attachment

        With smtp
            .Port = 25
            .Host = "mail.precisafrozen.cl"
            .Credentials = New System.Net.NetworkCredential("info@precisafrozen.cl", "info2013")
            .EnableSsl = False
        End With

        With correo
            Dim sql As String = "SELECT cli_nomb, cli_cryd FROM clientes_vista WHERE frec_codi='" + lblrece.Text + "'"

            Dim tablaCliente As DataTable = ListarTablasSQL(sql)
            Dim NombreCliente As String = ""
            If tablaCliente.Rows.Count > 0 Then
                NombreCliente = tablaCliente.Rows(0)(0).ToString()
            End If

            .From = New System.Net.Mail.MailAddress("info@precisafrozen.cl")

            Dim uu As String = tablaCliente.Rows(0)(1).ToString().Trim

            If QuitarCaracteres(uu.ToString()).Length < uu.ToString().Length Then
                Dim correo_electronico As String = ""
                For i As Integer = 0 To uu.Length - 1
                    If uu.Chars(i) <> ";" Then
                        correo_electronico = correo_electronico + uu.Chars(i)
                    Else
                        .To.Add(correo_electronico)
                        correo_electronico = ""
                    End If
                Next
                .To.Add(correo_electronico)
            End If

            .Bcc.Add("despinoza@precisafrozen.cl")
            .Bcc.Add("pmartinez@precisafrozen.cl")
            .Bcc.Add("mlopez@precisafrozen.cl")
            .Bcc.Add("jhernandez@precisafrozen.cl")
            .Bcc.Add("efuenzalida@precisafrozen.cl")
            .Bcc.Add("vlomuscio@precisafrozen.cl")

            If ComboBox1.Text = "RECEPCION" Then
                .Subject = "Servicios Extraordinarios Recepcion"
            Else
                .Subject = "Servicios Extraordinarios Despacho"
            End If


            .IsBodyHtml = True
            .AlternateViews.Add(BodyDisponibilidad())
            .BodyEncoding = System.Text.Encoding.UTF8

            Dim ruta As String = Retorna_Ruta_ArchivoDisponibilidad(lblrece.Text)
            If ruta = "" Then
                Return True
                Exit Function
            End If
            adjunto = New System.Net.Mail.Attachment(ruta)
            .Attachments.Add(adjunto)
        End With

        Try
            smtp.Send(correo)



            Enviarcorreo = True
        Catch ex As Exception
            Enviarcorreo = False
        End Try

        Return Enviarcorreo

    End Function
    Function Retorna_Ruta_ArchivoDisponibilidad(ByVal codigo As String) As String

        Dim x = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\serviciosrece" + lblrece.Text + ".Pdf"
        If Not File.Exists(My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\serviciosrece" + lblrece.Text + ".Pdf") Then
            Dim report As New Rpt_ServiciosRec
            Dim PictureBox1 As New PictureBox
            Dim PictureBox2 As New PictureBox
            Dim PictureBox3 As New PictureBox
            Dim valcan As Integer = 0


            Dim SqlImagen As String = "SELECT  Convert(varchar(max),Convert(Varbinary(MAX),rimg_imagen2))  " +
                                      "   FROM serimagen " +
                                      "  WHERE rimg_rececodi = '" + lblrece.Text.ToString() + "'"

            Dim tablaimagen As DataTable = fnc.ListarTablasSQL(SqlImagen)



            Dim sqlval As String = "select count(*) FROM serimagen   WHERE rimg_rececodi = '" + lblrece.Text.ToString() + "'"

            Dim tablaval As DataTable = fnc.ListarTablasSQL(sqlval)
            If tablaval.Rows.Count > 0 Then

                valcan = Convert.ToInt32(tablaval.Rows(0)(0).ToString())

            End If




            If tablaimagen.Rows.Count > 0 Then

                'Imagen1
                If valcan = 1 Then
                    If tablaimagen.Rows(0)(0).ToString() <> "" Then
                        PictureBox1.Image = Base64ToImage(tablaimagen.Rows(0)(0).ToString())
                    Else
                        PictureBox1.Image = My.Resources.blanco
                    End If
                End If

                PictureBox3.Image = My.Resources.blanco
                PictureBox2.Image = My.Resources.blanco
                If valcan = 2 Then

                    If tablaimagen.Rows(0)(0).ToString() <> "" Then
                        PictureBox1.Image = Base64ToImage(tablaimagen.Rows(0)(0).ToString())
                    Else
                        PictureBox1.Image = My.Resources.blanco
                    End If

                    'Imagen2
                    If tablaimagen.Rows(1)(0).ToString() <> "" Then
                        PictureBox2.Image = Base64ToImage(tablaimagen.Rows(1)(0).ToString())
                    Else
                        PictureBox2.Image = My.Resources.blanco
                    End If
                    PictureBox3.Image = My.Resources.blanco
                End If
                If valcan = 3 Then

                    If tablaimagen.Rows(0)(0).ToString() <> "" Then
                        PictureBox1.Image = Base64ToImage(tablaimagen.Rows(0)(0).ToString())
                    Else
                        PictureBox1.Image = My.Resources.blanco
                    End If

                    'Imagen2
                    If tablaimagen.Rows(1)(0).ToString() <> "" Then
                        PictureBox2.Image = Base64ToImage(tablaimagen.Rows(1)(0).ToString())
                    Else
                        PictureBox2.Image = My.Resources.blanco
                    End If

                    'Imagen3
                    If tablaimagen.Rows(2)(0).ToString() <> "" Then
                        PictureBox3.Image = Base64ToImage(tablaimagen.Rows(2)(0).ToString())
                    Else
                        PictureBox3.Image = My.Resources.blanco
                    End If
                End If



            Else
                PictureBox1.Image = My.Resources.blanco
                PictureBox2.Image = My.Resources.blanco
                PictureBox3.Image = My.Resources.blanco

            End If

            Dim Ds As New Imag

            Ds.Imagenes.AddImagenesRow(ImageToByte(PictureBox1.Image), ImageToByte(PictureBox2.Image), ImageToByte(PictureBox3.Image))
            report.Subreports(0).SetDataSource(Ds)
            report.SetDatabaseLogon(Usuario_ODBC, Pass_ODBC)
            report.SetParameterValue("codigo", lblrece.Text)
            'report.SetDatabaseLogon("sa", "precisa")
            'report.SetParameterValue("codigo", codigo)
            Try
                Dim CrExportOptions As ExportOptions
                Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions()
                Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions()

                CrDiskFileDestinationOptions.DiskFileName = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\serviciosrece" + lblrece.Text + ".Pdf"
                CrExportOptions = report.ExportOptions
                With CrExportOptions
                    .ExportDestinationType = ExportDestinationType.DiskFile
                    .ExportFormatType = ExportFormatType.PortableDocFormat
                    .DestinationOptions = CrDiskFileDestinationOptions
                    .FormatOptions = CrFormatTypeOptions
                End With
                report.Export()
                report.Dispose()
                Return My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\serviciosrece" + lblrece.Text + ".Pdf"
                Exit Function
            Catch ex As Exception
                Return ""
                Exit Function
            End Try
        End If
        Return ""

    End Function


    Private Sub BtnImprimir_Click(sender As System.Object, e As System.EventArgs) Handles BtnImprimir.Click

        If lblrece.Text = "0000000" Then


        Else
            If lblestado.Text = "." Then
            Else
                Dim frm As Frm_MuestraReporte = New Frm_MuestraReporte
                frm.Text = "Asistente de informes - Detalles Servicios"

                Dim report As New Rpt_ServiciosRec
                '  cargaimg()

                Dim PictureBox1 As New PictureBox
                Dim PictureBox2 As New PictureBox
                Dim PictureBox3 As New PictureBox
                Dim valcan As Integer = 0


                Dim SqlImagen As String = "SELECT  Convert(varchar(max),Convert(Varbinary(MAX),rimg_imagen2))  " +
                                          "   FROM serimagen " +
                                          "  WHERE rimg_rececodi = '" + lblrece.Text.ToString() + "'"

                Dim tablaimagen As DataTable = fnc.ListarTablasSQL(SqlImagen)



                Dim sqlval As String = "select count(*) FROM serimagen   WHERE rimg_rececodi = '" + lblrece.Text.ToString() + "'"

                Dim tablaval As DataTable = fnc.ListarTablasSQL(sqlval)
                If tablaval.Rows.Count > 0 Then

                    valcan = Convert.ToInt32(tablaval.Rows(0)(0).ToString())

                End If




                If tablaimagen.Rows.Count > 0 Then

                    'Imagen1
                    If valcan = 1 Then
                        If tablaimagen.Rows(0)(0).ToString() <> "" Then
                            PictureBox1.Image = Base64ToImage(tablaimagen.Rows(0)(0).ToString())
                        Else
                            PictureBox1.Image = My.Resources.blanco
                        End If
                    End If

                    PictureBox3.Image = My.Resources.blanco
                    PictureBox2.Image = My.Resources.blanco
                    If valcan = 2 Then

                        If tablaimagen.Rows(0)(0).ToString() <> "" Then
                            PictureBox1.Image = Base64ToImage(tablaimagen.Rows(0)(0).ToString())
                        Else
                            PictureBox1.Image = My.Resources.blanco
                        End If

                        'Imagen2
                        If tablaimagen.Rows(1)(0).ToString() <> "" Then
                            PictureBox2.Image = Base64ToImage(tablaimagen.Rows(1)(0).ToString())
                        Else
                            PictureBox2.Image = My.Resources.blanco
                        End If
                        PictureBox3.Image = My.Resources.blanco
                    End If
                    If valcan = 3 Then

                        If tablaimagen.Rows(0)(0).ToString() <> "" Then
                            PictureBox1.Image = Base64ToImage(tablaimagen.Rows(0)(0).ToString())
                        Else
                            PictureBox1.Image = My.Resources.blanco
                        End If

                        'Imagen2
                        If tablaimagen.Rows(1)(0).ToString() <> "" Then
                            PictureBox2.Image = Base64ToImage(tablaimagen.Rows(1)(0).ToString())
                        Else
                            PictureBox2.Image = My.Resources.blanco
                        End If

                        'Imagen3
                        If tablaimagen.Rows(2)(0).ToString() <> "" Then
                            PictureBox3.Image = Base64ToImage(tablaimagen.Rows(2)(0).ToString())
                        Else
                            PictureBox3.Image = My.Resources.blanco
                        End If
                    End If
                  


                Else
                    PictureBox1.Image = My.Resources.blanco
                    PictureBox2.Image = My.Resources.blanco
                    PictureBox3.Image = My.Resources.blanco

                End If

                Dim Ds As New Imag

                Ds.Imagenes.AddImagenesRow(ImageToByte(PictureBox1.Image), ImageToByte(PictureBox2.Image), ImageToByte(PictureBox3.Image))
                report.Subreports(0).SetDataSource(Ds)
                report.SetDatabaseLogon(Usuario_ODBC, Pass_ODBC)
                report.SetParameterValue("codigo", lblrece.Text)
                frm.Contenedor.ReportSource = report
                frm.ShowDialog()
            End If


        End If
    End Sub

    Private Sub cargaimg()

      

        Dim PictureBox1 As New PictureBox
        Dim PictureBox2 As New PictureBox
        Dim PictureBox3 As New PictureBox


        Dim SqlImagen As String = "SELECT  Convert(varchar(max),Convert(Varbinary(MAX),rimg_imagen)) , " +
                                  "   FROM serimagen " +
                                  "  WHERE rimg_rececodi = '" + Convert.ToInt32(lblrece.Text).ToString() + "'"

        Dim tablaimagen As DataTable = fnc.ListarTablasSQL(SqlImagen)

        If tablaimagen.Rows.Count > 0 Then

            'Imagen1
            If tablaimagen.Rows(0)(0).ToString() <> "" Then
                PictureBox1.Image = Base64ToImage(tablaimagen.Rows(0)(0).ToString())
            Else
                PictureBox1.Image = My.Resources.blanco
            End If

            'Imagen2
            If tablaimagen.Rows(0)(1).ToString() <> "" Then
                PictureBox2.Image = Base64ToImage(tablaimagen.Rows(1)(0).ToString())
            Else
                PictureBox2.Image = My.Resources.blanco
            End If

            'Imagen3
            If tablaimagen.Rows(0)(2).ToString() <> "" Then
                PictureBox3.Image = Base64ToImage(tablaimagen.Rows(2)(0).ToString())
            Else
                PictureBox3.Image = My.Resources.blanco
            End If


        Else
            PictureBox1.Image = My.Resources.blanco
            PictureBox2.Image = My.Resources.blanco
            PictureBox3.Image = My.Resources.blanco
       
        End If

        Dim Ds As New Imag

        Ds.Imagenes.AddImagenesRow(ImageToByte(PictureBox1.Image), ImageToByte(PictureBox2.Image), ImageToByte(PictureBox3.Image))
        ' report.Subreports(0).SetDataSource(Ds)

     
    End Sub



    Private Sub Frm_ServiciosREC_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        f_servicios = False
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.Text = "RECEPCION" Then
            Dim SqlBusca As String = "SELECT TOP 9 FREC_CODI FROM fichrece ORDER BY FREC_CODI DESC"

            Dim tablarece As DataTable = fnc.ListarTablasSQL(SqlBusca)

            If tablarece.Rows.Count > 0 Then

                txtrece1.Text = tablarece.Rows(0)(0).ToString()
                txtrece2.Text = tablarece.Rows(1)(0).ToString()
                txtrece3.Text = tablarece.Rows(2)(0).ToString()
                txtrece4.Text = tablarece.Rows(3)(0).ToString()
                txtrece5.Text = tablarece.Rows(4)(0).ToString()
                txtrece6.Text = tablarece.Rows(5)(0).ToString()
                txtrece7.Text = tablarece.Rows(6)(0).ToString()
                txtrece8.Text = tablarece.Rows(7)(0).ToString()
                txtrece9.Text = tablarece.Rows(8)(0).ToString()
                pintarece1()
                pintarece2()
                pintarece3()
                pintarece4()
                pintarece5()
                pintarece6()
                pintarece7()
                pintarece8()
                pintarece9()

            End If
            txtrece0.Focus()
        Else
            Dim SqlBusca As String = "SELECT TOP 9 Fdes_CODI FROM fichdespa ORDER BY Fdes_CODI DESC"

            Dim tablarece As DataTable = fnc.ListarTablasSQL(SqlBusca)

            If tablarece.Rows.Count > 0 Then

                txtrece1.Text = tablarece.Rows(0)(0).ToString()
                txtrece2.Text = tablarece.Rows(1)(0).ToString()
                txtrece3.Text = tablarece.Rows(2)(0).ToString()
                txtrece4.Text = tablarece.Rows(3)(0).ToString()
                txtrece5.Text = tablarece.Rows(4)(0).ToString()
                txtrece6.Text = tablarece.Rows(5)(0).ToString()
                txtrece7.Text = tablarece.Rows(6)(0).ToString()
                txtrece8.Text = tablarece.Rows(7)(0).ToString()
                txtrece9.Text = tablarece.Rows(8)(0).ToString()
                pintarece1()
                pintarece2()
                pintarece3()
                pintarece4()
                pintarece5()
                pintarece6()
                pintarece7()
                pintarece8()
                pintarece9()

            End If
            txtrece0.Focus()
        End If
    End Sub

    Private Sub txtrece2_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtrece2.TextChanged

    End Sub

    Private Sub btnAdjuntarFotos_Click(sender As System.Object, e As System.EventArgs) Handles btnAdjuntarFotos.Click
        Dim frm As New FrmFotosServicios
        frm.Show()
        frm.txtGuiaRecepcion.Text = lblrece.Text
    End Sub
End Class
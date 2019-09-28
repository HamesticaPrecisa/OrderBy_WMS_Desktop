Imports System.Drawing.Drawing2D
Imports System.Drawing.Printing
'Imports MSCommLib
Imports System.Threading
Imports System.Text.RegularExpressions
Imports System.IO
Imports System.Configuration
Imports System.Drawing.Imaging
Imports System.Data.SqlClient


Public Class CreaInforme
    Dim fnc As New Funciones
    Dim COM1 As New ImpresionCOM1
    Dim valorRecibido As String = ""
    Dim prtsettings = New PrinterSettings()
    Dim x As Int32 = 111
    Dim y As Int32 = 56

    Dim traecantidad As Int32 = 0
    'Private Sub btn_BuscaCliente_Click(sender As System.Object, e As System.EventArgs)
    '    Dim frm As New Lst_AyudaClientes
    '    frm.ShowDialog(Frm_Principal)
    '    Me.valorRecibido = Frm_Principal.buscavalor

    '    If Len(valorRecibido) >= 9 Then

    '        Dim SqlBusca As String = "SELECT cli_nomb, cli_estado FROM clientes WHERE " +
    '            "cli_rut='" + valorRecibido + "'"

    '        Dim tabla As DataTable = fnc.ListarTablasSQL(SqlBusca)

    '        If tabla.Rows.Count > 0 Then
    '            If tabla.Rows(0)(1).ToString() = "N" Then
    '                MsgBox("El cliente seleccionado se encuentra bloqueado", MsgBoxStyle.Critical, "Aviso")
    '                Exit Sub
    '            End If

    '            TxtClirut.Text = valorRecibido
    '            txtclinom.Text = tabla.Rows(0)(0).ToString()

    '            Frm_Principal.buscavalor = ""


    '            TxtClirut.Enabled = False
    '        Else
    '            MsgBox("El rut ingresado no existe", MsgBoxStyle.Information, "Aviso")
    '        End If
    '    End If
    '    Frm_Principal.buscavalor = ""
    'End Sub.

    Private Sub CreaInforme_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        txtfolio.Text = Frm_Despacho.foliopu
        TxtClirut.Text = Frm_Despacho.txtrutcli.Text
        txtclinom.Text = Frm_Despacho.txtcliente.Text
        cargaimg()
        traecanti()
        Dim sql As String = "SELECT x,y,rutcli,dato from datos_informes where rutcli= '" + TxtClirut.Text + "' "

        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

        If tabla.Rows.Count > 0 Then


            For i As Integer = 0 To tabla.Rows.Count - 1

                Dim dato As String = tabla.Rows(i)(3).ToString()
                If dato = "Despacho" Then
                    lbldespacho.Text = txtfolio.Text
                    lbldespacho.Visible = True
                    x = Convert.ToInt32(tabla.Rows(i)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(i)(1).ToString())
                    lbldespacho.Location = New Point(x, y)
                End If
                If dato = "Rut cliente" Then
                    If (TxtClirut.Text = "799842408") Then
                        lblrutcli.Text = "78408440K"
                    Else
                        lblrutcli.Text = TxtClirut.Text
                    End If

                    lblrutcli.Visible = True
                    x = Convert.ToInt32(tabla.Rows(i)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(i)(1).ToString())
                    lblrutcli.Location = New Point(x, y)
                End If
                If dato = "Nombre cliente" Then
                    lblnomcli.Text = txtclinom.Text
                    lblnomcli.Visible = True
                    x = Convert.ToInt32(tabla.Rows(i)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(i)(1).ToString())
                    lblnomcli.Location = New Point(x, y)
                End If
                If dato = "Fecha" Then
                    lblfecha.Text = Frm_Despacho.dt_fecha.Text.Trim()
                    lblfecha.Visible = True
                    x = Convert.ToInt32(tabla.Rows(i)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(i)(1).ToString())
                    lblfecha.Location = New Point(x, y)
                End If
                If dato = "Nombre chofer" Then
                    lblnomcho.Text = Frm_Despacho.txtchonom.Text.Trim()
                    lblnomcho.Visible = True
                    x = Convert.ToInt32(tabla.Rows(i)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(i)(1).ToString())
                    lblnomcho.Location = New Point(x, y)
                End If
                If dato = "Rut chofer" Then
                    lblrutcho.Text = Frm_Despacho.Txtchorut.Text.Trim()
                    lblrutcho.Visible = True
                    x = Convert.ToInt32(tabla.Rows(i)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(i)(1).ToString())
                    lblrutcho.Location = New Point(x, y)
                End If
                If dato = "Patente" Then
                    lblpatente.Text = Frm_Despacho.txtpatente.Text.Trim()
                    lblpatente.Visible = True
                    x = Convert.ToInt32(tabla.Rows(i)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(i)(1).ToString())
                    lblpatente.Location = New Point(x, y)
                End If
                If dato = "Observacion" Then
                    lblobs.Text = Frm_Despacho.TxtObs.Text.Trim()
                    lblobs.Visible = True
                    x = Convert.ToInt32(tabla.Rows(i)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(i)(1).ToString())
                    lblobs.Location = New Point(x, y)
                End If
                If dato = "Destino" Then



                    Dim sql2 As String = "SELECT destino,destino_rut,destino_dir from vg_despachos_destinos where fdes_codi= '" + txtfolio.Text + "'  "

                    Dim tabla2 As DataTable = fnc.ListarTablasSQL(sql2)

                    If tabla2.Rows.Count > 0 Then

                        lbldestino.Text = tabla2.Rows(0)(0).ToString()
                        lbldestino2.Text = tabla2.Rows(0)(1).ToString()
                        lbldestino3.Text = tabla2.Rows(0)(2).ToString()
                    End If


                    lbldestino.Visible = True
                    lbldestino2.Visible = True
                    lbldestino3.Visible = True
                    x = Convert.ToInt32(tabla.Rows(i)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(i)(1).ToString())
                    lbldestino.Location = New Point(x, y)
                    lbldestino2.Location = New Point(x, y + 15)
                    lbldestino3.Location = New Point(x, y + 30)
                End If

                If dato = "Giro" Then
                    Dim sql2 As String = "SELECT cli_rubro from clientes where cli_rut= '" + TxtClirut.Text + "'  "
                    Dim tabla2 As DataTable = fnc.ListarTablasSQL(sql2)
                    If tabla2.Rows.Count > 0 Then
                        lblgiro.Text = tabla2.Rows(0)(0).ToString()
                    End If
                    lblgiro.Visible = True
                    x = Convert.ToInt32(tabla.Rows(i)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(i)(1).ToString())
                    lblgiro.Location = New Point(x, y)
                End If
                If dato = "Direccion" Then
                    Dim sql2 As String = "SELECT cli_direcc from clientes where cli_rut= '" + TxtClirut.Text + "'  "
                    Dim tabla2 As DataTable = fnc.ListarTablasSQL(sql2)
                    If tabla2.Rows.Count > 0 Then
                        lbldireccion.Text = tabla2.Rows(0)(0).ToString()
                    End If
                    lbldireccion.Visible = True
                    x = Convert.ToInt32(tabla.Rows(i)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(i)(1).ToString())
                    lbldireccion.Location = New Point(x, y)
                End If
                If dato = "Comuna" Then
                    Dim sql2 As String = "SELECT cli_comuna from clientes where cli_rut= '" + TxtClirut.Text + "'  "
                    Dim tabla2 As DataTable = fnc.ListarTablasSQL(sql2)
                    If tabla2.Rows.Count > 0 Then
                        lblcomuna.Text = tabla2.Rows(0)(0).ToString()
                    End If
                    lblcomuna.Visible = True
                    x = Convert.ToInt32(tabla.Rows(i)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(i)(1).ToString())
                    lblcomuna.Location = New Point(x, y)
                End If







                If dato = "Codigo producto" Then


                    Dim sql2 As String = "SELECT drec_codpro from rpt_despacho_informe where ddes_rutcli= '" + TxtClirut.Text + "' and despacho = '" + txtfolio.Text.Trim() + "' "

                    Dim tabla2 As DataTable = fnc.ListarTablasSQL(sql2)

                    If tabla2.Rows.Count > 0 Then
                        x = Convert.ToInt32(tabla.Rows(i)(0).ToString())
                        y = Convert.ToInt32(tabla.Rows(i)(1).ToString())

                        'For j = 0 To tabla2.Rows.Count - 1
                        '    Dim lblCodProdGen As System.Windows.Forms.Label
                        '    lblCodProdGen = New Label

                        '    lblCodProdGen.Location = New Point(x, y)
                        '    lblCodProdGen.Name = "lblCodProd" & j.ToString.Trim
                        '    lblCodProdGen.Size = New Size(50, 13)
                        '    lblCodProdGen.Visible = True
                        '    lblCodProdGen.ForeColor = Color.Black
                        '    lblCodProdGen.BackColor = Color.White
                        '    Me.Controls.Add(lblCodProdGen)
                        '    lblCodProdGen.AutoSize = True
                        '    lblCodProdGen.Text = tabla2.Rows(j)(0).ToString()
                        '    y += 15
                        'Next


                        If traecantidad = 1 Then
                            lblcodpro.Text = tabla2.Rows(0)(0).ToString()
                            lblcodpro.Visible = True
                        End If
                        If traecantidad = 2 Then
                            lblcodpro.Text = tabla2.Rows(0)(0).ToString()
                            lblcodpro2.Text = tabla2.Rows(1)(0).ToString()
                            lblcodpro.Visible = True
                            lblcodpro2.Visible = True
                        End If
                        If traecantidad = 3 Then
                            lblcodpro.Text = tabla2.Rows(0)(0).ToString()
                            lblcodpro2.Text = tabla2.Rows(1)(0).ToString()
                            lblcodpro3.Text = tabla2.Rows(2)(0).ToString()
                            lblcodpro.Visible = True
                            lblcodpro2.Visible = True
                            lblcodpro3.Visible = True
                        End If
                        If traecantidad = 4 Then
                            lblcodpro.Text = tabla2.Rows(0)(0).ToString()
                            lblcodpro2.Text = tabla2.Rows(1)(0).ToString()
                            lblcodpro3.Text = tabla2.Rows(2)(0).ToString()
                            lblcodpro4.Text = tabla2.Rows(3)(0).ToString()
                            lblcodpro.Visible = True
                            lblcodpro2.Visible = True
                            lblcodpro3.Visible = True
                            lblcodpro4.Visible = True
                        End If
                        If traecantidad = 5 Then
                            lblcodpro.Text = tabla2.Rows(0)(0).ToString()
                            lblcodpro2.Text = tabla2.Rows(1)(0).ToString()
                            lblcodpro3.Text = tabla2.Rows(2)(0).ToString()
                            lblcodpro4.Text = tabla2.Rows(3)(0).ToString()
                            lblcodpro5.Text = tabla2.Rows(4)(0).ToString()
                            lblcodpro.Visible = True
                            lblcodpro2.Visible = True
                            lblcodpro3.Visible = True
                            lblcodpro4.Visible = True
                            lblcodpro5.Visible = True
                        End If
                        If traecantidad = 6 Then
                            lblcodpro.Text = tabla2.Rows(0)(0).ToString()
                            lblcodpro2.Text = tabla2.Rows(1)(0).ToString()
                            lblcodpro3.Text = tabla2.Rows(2)(0).ToString()
                            lblcodpro4.Text = tabla2.Rows(3)(0).ToString()
                            lblcodpro5.Text = tabla2.Rows(4)(0).ToString()
                            lblcodpro6.Text = tabla2.Rows(5)(0).ToString()
                            lblcodpro.Visible = True
                            lblcodpro2.Visible = True
                            lblcodpro3.Visible = True
                            lblcodpro4.Visible = True
                            lblcodpro5.Visible = True
                            lblcodpro6.Visible = True
                        End If
                        If traecantidad = 7 Then
                            lblcodpro.Text = tabla2.Rows(0)(0).ToString()
                            lblcodpro2.Text = tabla2.Rows(1)(0).ToString()
                            lblcodpro3.Text = tabla2.Rows(2)(0).ToString()
                            lblcodpro4.Text = tabla2.Rows(3)(0).ToString()
                            lblcodpro5.Text = tabla2.Rows(4)(0).ToString()
                            lblcodpro6.Text = tabla2.Rows(5)(0).ToString()
                            lblcodpro7.Text = tabla2.Rows(6)(0).ToString()
                            lblcodpro.Visible = True
                            lblcodpro2.Visible = True
                            lblcodpro3.Visible = True
                            lblcodpro4.Visible = True
                            lblcodpro5.Visible = True
                            lblcodpro6.Visible = True
                            lblcodpro7.Visible = True
                        End If
                        If traecantidad = 8 Then
                            lblcodpro.Text = tabla2.Rows(0)(0).ToString()
                            lblcodpro2.Text = tabla2.Rows(1)(0).ToString()
                            lblcodpro3.Text = tabla2.Rows(2)(0).ToString()
                            lblcodpro4.Text = tabla2.Rows(3)(0).ToString()
                            lblcodpro5.Text = tabla2.Rows(4)(0).ToString()
                            lblcodpro6.Text = tabla2.Rows(5)(0).ToString()
                            lblcodpro7.Text = tabla2.Rows(6)(0).ToString()
                            lblcodpro8.Text = tabla2.Rows(7)(0).ToString()
                            lblcodpro.Visible = True
                            lblcodpro2.Visible = True
                            lblcodpro3.Visible = True
                            lblcodpro4.Visible = True
                            lblcodpro5.Visible = True
                            lblcodpro6.Visible = True
                            lblcodpro7.Visible = True
                            lblcodpro8.Visible = True
                        End If
                        If traecantidad = 9 Then
                            lblcodpro.Text = tabla2.Rows(0)(0).ToString()
                            lblcodpro2.Text = tabla2.Rows(1)(0).ToString()
                            lblcodpro3.Text = tabla2.Rows(2)(0).ToString()
                            lblcodpro4.Text = tabla2.Rows(3)(0).ToString()
                            lblcodpro5.Text = tabla2.Rows(4)(0).ToString()
                            lblcodpro6.Text = tabla2.Rows(5)(0).ToString()
                            lblcodpro7.Text = tabla2.Rows(6)(0).ToString()
                            lblcodpro8.Text = tabla2.Rows(7)(0).ToString()
                            lblcodpro9.Text = tabla2.Rows(8)(0).ToString()
                            lblcodpro.Visible = True
                            lblcodpro2.Visible = True
                            lblcodpro3.Visible = True
                            lblcodpro4.Visible = True
                            lblcodpro5.Visible = True
                            lblcodpro6.Visible = True
                            lblcodpro7.Visible = True
                            lblcodpro8.Visible = True
                            lblcodpro9.Visible = True
                        End If
                        If traecantidad = 10 Then
                            lblcodpro.Text = tabla2.Rows(0)(0).ToString()
                            lblcodpro2.Text = tabla2.Rows(1)(0).ToString()
                            lblcodpro3.Text = tabla2.Rows(2)(0).ToString()
                            lblcodpro4.Text = tabla2.Rows(3)(0).ToString()
                            lblcodpro5.Text = tabla2.Rows(4)(0).ToString()
                            lblcodpro6.Text = tabla2.Rows(5)(0).ToString()
                            lblcodpro7.Text = tabla2.Rows(6)(0).ToString()
                            lblcodpro8.Text = tabla2.Rows(7)(0).ToString()
                            lblcodpro9.Text = tabla2.Rows(8)(0).ToString()
                            lblcodpro10.Text = tabla2.Rows(9)(0).ToString()
                            lblcodpro.Visible = True
                            lblcodpro2.Visible = True
                            lblcodpro3.Visible = True
                            lblcodpro4.Visible = True
                            lblcodpro5.Visible = True
                            lblcodpro6.Visible = True
                            lblcodpro7.Visible = True
                            lblcodpro8.Visible = True
                            lblcodpro9.Visible = True
                            lblcodpro10.Visible = True
                        End If
                        If traecantidad = 11 Then
                            lblcodpro.Text = tabla2.Rows(0)(0).ToString()
                            lblcodpro2.Text = tabla2.Rows(1)(0).ToString()
                            lblcodpro3.Text = tabla2.Rows(2)(0).ToString()
                            lblcodpro4.Text = tabla2.Rows(3)(0).ToString()
                            lblcodpro5.Text = tabla2.Rows(4)(0).ToString()
                            lblcodpro6.Text = tabla2.Rows(5)(0).ToString()
                            lblcodpro7.Text = tabla2.Rows(6)(0).ToString()
                            lblcodpro8.Text = tabla2.Rows(7)(0).ToString()
                            lblcodpro9.Text = tabla2.Rows(8)(0).ToString()
                            lblcodpro10.Text = tabla2.Rows(9)(0).ToString()
                            lblcodpro11.Text = tabla2.Rows(10)(0).ToString()
                            lblcodpro.Visible = True
                            lblcodpro2.Visible = True
                            lblcodpro3.Visible = True
                            lblcodpro4.Visible = True
                            lblcodpro5.Visible = True
                            lblcodpro6.Visible = True
                            lblcodpro7.Visible = True
                            lblcodpro8.Visible = True
                            lblcodpro9.Visible = True
                            lblcodpro10.Visible = True
                            lblcodpro11.Visible = True
                        End If
                        If traecantidad = 12 Then
                            lblcodpro.Text = tabla2.Rows(0)(0).ToString()
                            lblcodpro2.Text = tabla2.Rows(1)(0).ToString()
                            lblcodpro3.Text = tabla2.Rows(2)(0).ToString()
                            lblcodpro4.Text = tabla2.Rows(3)(0).ToString()
                            lblcodpro5.Text = tabla2.Rows(4)(0).ToString()
                            lblcodpro6.Text = tabla2.Rows(5)(0).ToString()
                            lblcodpro7.Text = tabla2.Rows(6)(0).ToString()
                            lblcodpro8.Text = tabla2.Rows(7)(0).ToString()
                            lblcodpro9.Text = tabla2.Rows(8)(0).ToString()
                            lblcodpro10.Text = tabla2.Rows(9)(0).ToString()
                            lblcodpro11.Text = tabla2.Rows(10)(0).ToString()
                            lblcodpro12.Text = tabla2.Rows(11)(0).ToString()
                            lblcodpro.Visible = True
                            lblcodpro2.Visible = True
                            lblcodpro3.Visible = True
                            lblcodpro4.Visible = True
                            lblcodpro5.Visible = True
                            lblcodpro6.Visible = True
                            lblcodpro7.Visible = True
                            lblcodpro8.Visible = True
                            lblcodpro9.Visible = True
                            lblcodpro10.Visible = True
                            lblcodpro11.Visible = True
                            lblcodpro12.Visible = True
                        End If

                        If traecantidad = 1 Then
                            lblcodpro.Location = New Point(x, y)
                        End If

                        If traecantidad = 2 Then
                            lblcodpro.Location = New Point(x, y)
                            lblcodpro2.Location = New Point(x, y + 15)
                        End If
                        If traecantidad = 3 Then
                            lblcodpro.Location = New Point(x, y)
                            lblcodpro2.Location = New Point(x, y + 15)
                            lblcodpro3.Location = New Point(x, y + 30)

                        End If
                        If traecantidad = 4 Then
                            lblcodpro.Location = New Point(x, y)
                            lblcodpro2.Location = New Point(x, y + 15)
                            lblcodpro3.Location = New Point(x, y + 30)
                            lblcodpro4.Location = New Point(x, y + 45)
                        End If
                        If traecantidad = 5 Then
                            lblcodpro.Location = New Point(x, y)
                            lblcodpro2.Location = New Point(x, y + 15)
                            lblcodpro3.Location = New Point(x, y + 30)
                            lblcodpro4.Location = New Point(x, y + 45)
                            lblcodpro5.Location = New Point(x, y + 60)
                        End If
                        If traecantidad = 6 Then
                            lblcodpro.Location = New Point(x, y)
                            lblcodpro2.Location = New Point(x, y + 15)
                            lblcodpro3.Location = New Point(x, y + 30)
                            lblcodpro4.Location = New Point(x, y + 45)
                            lblcodpro5.Location = New Point(x, y + 60)
                            lblcodpro6.Location = New Point(x, y + 75)
                        End If
                        If traecantidad = 7 Then
                            lblcodpro.Location = New Point(x, y)
                            lblcodpro2.Location = New Point(x, y + 15)
                            lblcodpro3.Location = New Point(x, y + 30)
                            lblcodpro4.Location = New Point(x, y + 45)
                            lblcodpro5.Location = New Point(x, y + 60)
                            lblcodpro6.Location = New Point(x, y + 75)
                            lblcodpro7.Location = New Point(x, y + 90)
                        End If
                        If traecantidad = 8 Then
                            lblcodpro.Location = New Point(x, y)
                            lblcodpro2.Location = New Point(x, y + 15)
                            lblcodpro3.Location = New Point(x, y + 30)
                            lblcodpro4.Location = New Point(x, y + 45)
                            lblcodpro5.Location = New Point(x, y + 60)
                            lblcodpro6.Location = New Point(x, y + 75)
                            lblcodpro7.Location = New Point(x, y + 90)
                            lblcodpro8.Location = New Point(x, y + 105)
                        End If
                        If traecantidad = 9 Then
                            lblcodpro.Location = New Point(x, y)
                            lblcodpro2.Location = New Point(x, y + 15)
                            lblcodpro3.Location = New Point(x, y + 30)
                            lblcodpro4.Location = New Point(x, y + 45)
                            lblcodpro5.Location = New Point(x, y + 60)
                            lblcodpro6.Location = New Point(x, y + 75)
                            lblcodpro7.Location = New Point(x, y + 90)
                            lblcodpro8.Location = New Point(x, y + 105)
                            lblcodpro9.Location = New Point(x, y + 120)
                        End If
                        If traecantidad = 10 Then
                            lblcodpro.Location = New Point(x, y)
                            lblcodpro2.Location = New Point(x, y + 15)
                            lblcodpro3.Location = New Point(x, y + 30)
                            lblcodpro4.Location = New Point(x, y + 45)
                            lblcodpro5.Location = New Point(x, y + 60)
                            lblcodpro6.Location = New Point(x, y + 75)
                            lblcodpro7.Location = New Point(x, y + 90)
                            lblcodpro8.Location = New Point(x, y + 105)
                            lblcodpro9.Location = New Point(x, y + 120)
                            lblcodpro10.Location = New Point(x, y + 135)
                        End If
                        If traecantidad = 11 Then
                            lblcodpro.Location = New Point(x, y)
                            lblcodpro2.Location = New Point(x, y + 15)
                            lblcodpro3.Location = New Point(x, y + 30)
                            lblcodpro4.Location = New Point(x, y + 45)
                            lblcodpro5.Location = New Point(x, y + 60)
                            lblcodpro6.Location = New Point(x, y + 75)
                            lblcodpro7.Location = New Point(x, y + 90)
                            lblcodpro8.Location = New Point(x, y + 105)
                            lblcodpro9.Location = New Point(x, y + 120)
                            lblcodpro10.Location = New Point(x, y + 135)
                            lblcodpro11.Location = New Point(x, y + 150)
                        End If
                        If traecantidad = 12 Then
                            lblcodpro.Location = New Point(x, y)
                            lblcodpro2.Location = New Point(x, y + 15)
                            lblcodpro3.Location = New Point(x, y + 30)
                            lblcodpro4.Location = New Point(x, y + 45)
                            lblcodpro5.Location = New Point(x, y + 60)
                            lblcodpro6.Location = New Point(x, y + 75)
                            lblcodpro7.Location = New Point(x, y + 90)
                            lblcodpro8.Location = New Point(x, y + 105)
                            lblcodpro9.Location = New Point(x, y + 120)
                            lblcodpro10.Location = New Point(x, y + 135)
                            lblcodpro11.Location = New Point(x, y + 150)
                            lblcodpro11.Location = New Point(x, y + 165)
                        End If
                    End If
                End If


                If dato = "Nombre producto" Then


                    Dim sql2 As String = "SELECT mae_descr=SUBSTRING(mae_descr,1,30) from rpt_despacho_informe where ddes_rutcli= '" + TxtClirut.Text + "' and despacho = '" + txtfolio.Text.Trim() + "' "

                    Dim tabla2 As DataTable = fnc.ListarTablasSQL(sql2)

                    If tabla2.Rows.Count > 0 Then

                        If traecantidad = 1 Then
                            lblnompro.Text = tabla2.Rows(0)(0).ToString()
                            lblnompro.Visible = True
                        End If
                        If traecantidad = 2 Then
                            lblnompro.Text = tabla2.Rows(0)(0).ToString()
                            lblnompro2.Text = tabla2.Rows(1)(0).ToString()
                            lblnompro.Visible = True
                            lblnompro2.Visible = True
                        End If
                        If traecantidad = 3 Then
                            lblnompro.Text = tabla2.Rows(0)(0).ToString()
                            lblnompro2.Text = tabla2.Rows(1)(0).ToString()
                            lblnompro3.Text = tabla2.Rows(2)(0).ToString()
                            lblnompro.Visible = True
                            lblnompro2.Visible = True
                            lblnompro3.Visible = True
                        End If
                        If traecantidad = 4 Then
                            lblnompro.Text = tabla2.Rows(0)(0).ToString()
                            lblnompro2.Text = tabla2.Rows(1)(0).ToString()
                            lblnompro3.Text = tabla2.Rows(2)(0).ToString()
                            lblnompro4.Text = tabla2.Rows(3)(0).ToString()
                            lblnompro.Visible = True
                            lblnompro2.Visible = True
                            lblnompro3.Visible = True
                            lblnompro4.Visible = True
                        End If
                        If traecantidad = 5 Then
                            lblnompro.Text = tabla2.Rows(0)(0).ToString()
                            lblnompro2.Text = tabla2.Rows(1)(0).ToString()
                            lblnompro3.Text = tabla2.Rows(2)(0).ToString()
                            lblnompro4.Text = tabla2.Rows(3)(0).ToString()
                            lblnompro5.Text = tabla2.Rows(4)(0).ToString()
                            lblnompro.Visible = True
                            lblnompro2.Visible = True
                            lblnompro3.Visible = True
                            lblnompro4.Visible = True
                            lblnompro5.Visible = True
                        End If
                        If traecantidad = 6 Then
                            lblnompro.Text = tabla2.Rows(0)(0).ToString()
                            lblnompro2.Text = tabla2.Rows(1)(0).ToString()
                            lblnompro3.Text = tabla2.Rows(2)(0).ToString()
                            lblnompro4.Text = tabla2.Rows(3)(0).ToString()
                            lblnompro5.Text = tabla2.Rows(4)(0).ToString()
                            lblnompro6.Text = tabla2.Rows(5)(0).ToString()
                            lblnompro.Visible = True
                            lblnompro2.Visible = True
                            lblnompro3.Visible = True
                            lblnompro4.Visible = True
                            lblnompro5.Visible = True
                            lblnompro6.Visible = True
                        End If
                        If traecantidad = 7 Then
                            lblnompro.Text = tabla2.Rows(0)(0).ToString()
                            lblnompro2.Text = tabla2.Rows(1)(0).ToString()
                            lblnompro3.Text = tabla2.Rows(2)(0).ToString()
                            lblnompro4.Text = tabla2.Rows(3)(0).ToString()
                            lblnompro5.Text = tabla2.Rows(4)(0).ToString()
                            lblnompro6.Text = tabla2.Rows(5)(0).ToString()
                            lblnompro7.Text = tabla2.Rows(6)(0).ToString()
                            lblnompro.Visible = True
                            lblnompro2.Visible = True
                            lblnompro3.Visible = True
                            lblnompro4.Visible = True
                            lblnompro5.Visible = True
                            lblnompro6.Visible = True
                            lblnompro7.Visible = True
                        End If
                        If traecantidad = 8 Then
                            lblnompro.Text = tabla2.Rows(0)(0).ToString()
                            lblnompro2.Text = tabla2.Rows(1)(0).ToString()
                            lblnompro3.Text = tabla2.Rows(2)(0).ToString()
                            lblnompro4.Text = tabla2.Rows(3)(0).ToString()
                            lblnompro5.Text = tabla2.Rows(4)(0).ToString()
                            lblnompro6.Text = tabla2.Rows(5)(0).ToString()
                            lblnompro7.Text = tabla2.Rows(6)(0).ToString()
                            lblnompro8.Text = tabla2.Rows(7)(0).ToString()
                            lblnompro.Visible = True
                            lblnompro2.Visible = True
                            lblnompro3.Visible = True
                            lblnompro4.Visible = True
                            lblnompro5.Visible = True
                            lblnompro6.Visible = True
                            lblnompro7.Visible = True
                            lblnompro8.Visible = True
                        End If
                        If traecantidad = 9 Then
                            lblnompro.Text = tabla2.Rows(0)(0).ToString()
                            lblnompro2.Text = tabla2.Rows(1)(0).ToString()
                            lblnompro3.Text = tabla2.Rows(2)(0).ToString()
                            lblnompro4.Text = tabla2.Rows(3)(0).ToString()
                            lblnompro5.Text = tabla2.Rows(4)(0).ToString()
                            lblnompro6.Text = tabla2.Rows(5)(0).ToString()
                            lblnompro7.Text = tabla2.Rows(6)(0).ToString()
                            lblnompro8.Text = tabla2.Rows(7)(0).ToString()
                            lblnompro9.Text = tabla2.Rows(8)(0).ToString()
                            lblnompro.Visible = True
                            lblnompro2.Visible = True
                            lblnompro3.Visible = True
                            lblnompro4.Visible = True
                            lblnompro5.Visible = True
                            lblnompro6.Visible = True
                            lblnompro7.Visible = True
                            lblnompro8.Visible = True
                            lblnompro9.Visible = True
                        End If
                        If traecantidad = 10 Then
                            lblnompro.Text = tabla2.Rows(0)(0).ToString()
                            lblnompro2.Text = tabla2.Rows(1)(0).ToString()
                            lblnompro3.Text = tabla2.Rows(2)(0).ToString()
                            lblnompro4.Text = tabla2.Rows(3)(0).ToString()
                            lblnompro5.Text = tabla2.Rows(4)(0).ToString()
                            lblnompro6.Text = tabla2.Rows(5)(0).ToString()
                            lblnompro7.Text = tabla2.Rows(6)(0).ToString()
                            lblnompro8.Text = tabla2.Rows(7)(0).ToString()
                            lblnompro9.Text = tabla2.Rows(8)(0).ToString()
                            lblnompro10.Text = tabla2.Rows(9)(0).ToString()
                            lblnompro.Visible = True
                            lblnompro2.Visible = True
                            lblnompro3.Visible = True
                            lblnompro4.Visible = True
                            lblnompro5.Visible = True
                            lblnompro6.Visible = True
                            lblnompro7.Visible = True
                            lblnompro8.Visible = True
                            lblnompro9.Visible = True
                            lblnompro10.Visible = True
                        End If
                        If traecantidad = 11 Then
                            lblnompro.Text = tabla2.Rows(0)(0).ToString()
                            lblnompro2.Text = tabla2.Rows(1)(0).ToString()
                            lblnompro3.Text = tabla2.Rows(2)(0).ToString()
                            lblnompro4.Text = tabla2.Rows(3)(0).ToString()
                            lblnompro5.Text = tabla2.Rows(4)(0).ToString()
                            lblnompro6.Text = tabla2.Rows(5)(0).ToString()
                            lblnompro7.Text = tabla2.Rows(6)(0).ToString()
                            lblnompro8.Text = tabla2.Rows(7)(0).ToString()
                            lblnompro9.Text = tabla2.Rows(8)(0).ToString()
                            lblnompro10.Text = tabla2.Rows(9)(0).ToString()
                            lblnompro11.Text = tabla2.Rows(10)(0).ToString()
                            lblnompro.Visible = True
                            lblnompro2.Visible = True
                            lblnompro3.Visible = True
                            lblnompro4.Visible = True
                            lblnompro5.Visible = True
                            lblnompro6.Visible = True
                            lblnompro7.Visible = True
                            lblnompro8.Visible = True
                            lblnompro9.Visible = True
                            lblnompro10.Visible = True
                            lblnompro11.Visible = True
                        End If
                        If traecantidad = 12 Then
                            lblnompro.Text = tabla2.Rows(0)(0).ToString()
                            lblnompro2.Text = tabla2.Rows(1)(0).ToString()
                            lblnompro3.Text = tabla2.Rows(2)(0).ToString()
                            lblnompro4.Text = tabla2.Rows(3)(0).ToString()
                            lblnompro5.Text = tabla2.Rows(4)(0).ToString()
                            lblnompro6.Text = tabla2.Rows(5)(0).ToString()
                            lblnompro7.Text = tabla2.Rows(6)(0).ToString()
                            lblnompro8.Text = tabla2.Rows(7)(0).ToString()
                            lblnompro9.Text = tabla2.Rows(8)(0).ToString()
                            lblnompro10.Text = tabla2.Rows(9)(0).ToString()
                            lblnompro11.Text = tabla2.Rows(10)(0).ToString()
                            lblnompro12.Text = tabla2.Rows(11)(0).ToString()
                            lblnompro.Visible = True
                            lblnompro2.Visible = True
                            lblnompro3.Visible = True
                            lblnompro4.Visible = True
                            lblnompro5.Visible = True
                            lblnompro6.Visible = True
                            lblnompro7.Visible = True
                            lblnompro8.Visible = True
                            lblnompro9.Visible = True
                            lblnompro10.Visible = True
                            lblnompro11.Visible = True
                            lblnompro12.Visible = True
                        End If




                    End If

                    x = Convert.ToInt32(tabla.Rows(i)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(i)(1).ToString())

                    If traecantidad = 1 Then
                        lblnompro.Location = New Point(x, y)
                    End If

                    If traecantidad = 2 Then
                        lblnompro.Location = New Point(x, y)
                        lblnompro2.Location = New Point(x, y + 15)
                    End If
                    If traecantidad = 3 Then
                        lblnompro.Location = New Point(x, y)
                        lblnompro2.Location = New Point(x, y + 15)
                        lblnompro3.Location = New Point(x, y + 30)

                    End If
                    If traecantidad = 4 Then
                        lblnompro.Location = New Point(x, y)
                        lblnompro2.Location = New Point(x, y + 15)
                        lblnompro3.Location = New Point(x, y + 30)
                        lblnompro4.Location = New Point(x, y + 45)
                    End If
                    If traecantidad = 5 Then
                        lblnompro.Location = New Point(x, y)
                        lblnompro2.Location = New Point(x, y + 15)
                        lblnompro3.Location = New Point(x, y + 30)
                        lblnompro4.Location = New Point(x, y + 45)
                        lblnompro5.Location = New Point(x, y + 60)
                    End If
                    If traecantidad = 6 Then
                        lblnompro.Location = New Point(x, y)
                        lblnompro2.Location = New Point(x, y + 15)
                        lblnompro3.Location = New Point(x, y + 30)
                        lblnompro4.Location = New Point(x, y + 45)
                        lblnompro5.Location = New Point(x, y + 60)
                        lblnompro6.Location = New Point(x, y + 75)
                    End If
                    If traecantidad = 7 Then
                        lblnompro.Location = New Point(x, y)
                        lblnompro2.Location = New Point(x, y + 15)
                        lblnompro3.Location = New Point(x, y + 30)
                        lblnompro4.Location = New Point(x, y + 45)
                        lblnompro5.Location = New Point(x, y + 60)
                        lblnompro6.Location = New Point(x, y + 75)
                        lblnompro7.Location = New Point(x, y + 90)
                    End If
                    If traecantidad = 8 Then
                        lblnompro.Location = New Point(x, y)
                        lblnompro2.Location = New Point(x, y + 15)
                        lblnompro3.Location = New Point(x, y + 30)
                        lblnompro4.Location = New Point(x, y + 45)
                        lblnompro5.Location = New Point(x, y + 60)
                        lblnompro6.Location = New Point(x, y + 75)
                        lblnompro7.Location = New Point(x, y + 90)
                        lblnompro8.Location = New Point(x, y + 105)
                    End If
                    If traecantidad = 9 Then
                        lblnompro.Location = New Point(x, y)
                        lblnompro2.Location = New Point(x, y + 15)
                        lblnompro3.Location = New Point(x, y + 30)
                        lblnompro4.Location = New Point(x, y + 45)
                        lblnompro5.Location = New Point(x, y + 60)
                        lblnompro6.Location = New Point(x, y + 75)
                        lblnompro7.Location = New Point(x, y + 90)
                        lblnompro8.Location = New Point(x, y + 105)
                        lblnompro9.Location = New Point(x, y + 120)
                    End If
                    If traecantidad = 10 Then
                        lblnompro.Location = New Point(x, y)
                        lblnompro2.Location = New Point(x, y + 15)
                        lblnompro3.Location = New Point(x, y + 30)
                        lblnompro4.Location = New Point(x, y + 45)
                        lblnompro5.Location = New Point(x, y + 60)
                        lblnompro6.Location = New Point(x, y + 75)
                        lblnompro7.Location = New Point(x, y + 90)
                        lblnompro8.Location = New Point(x, y + 105)
                        lblnompro9.Location = New Point(x, y + 120)
                        lblnompro10.Location = New Point(x, y + 135)
                    End If
                    If traecantidad = 11 Then
                        lblnompro.Location = New Point(x, y)
                        lblnompro2.Location = New Point(x, y + 15)
                        lblnompro3.Location = New Point(x, y + 30)
                        lblnompro4.Location = New Point(x, y + 45)
                        lblnompro5.Location = New Point(x, y + 60)
                        lblnompro6.Location = New Point(x, y + 75)
                        lblnompro7.Location = New Point(x, y + 90)
                        lblnompro8.Location = New Point(x, y + 105)
                        lblnompro9.Location = New Point(x, y + 120)
                        lblnompro10.Location = New Point(x, y + 135)
                        lblnompro11.Location = New Point(x, y + 150)
                    End If
                    If traecantidad = 12 Then
                        lblnompro.Location = New Point(x, y)
                        lblnompro2.Location = New Point(x, y + 15)
                        lblnompro3.Location = New Point(x, y + 30)
                        lblnompro4.Location = New Point(x, y + 45)
                        lblnompro5.Location = New Point(x, y + 60)
                        lblnompro6.Location = New Point(x, y + 75)
                        lblnompro7.Location = New Point(x, y + 90)
                        lblnompro8.Location = New Point(x, y + 105)
                        lblnompro9.Location = New Point(x, y + 120)
                        lblnompro10.Location = New Point(x, y + 135)
                        lblnompro11.Location = New Point(x, y + 150)
                        lblnompro12.Location = New Point(x, y + 165)
                    End If
                End If
                If dato = "Unidades" Then


                    Dim sql2 As String = "SELECT unidades from rpt_despacho_informe where ddes_rutcli= '" + TxtClirut.Text + "' and despacho = '" + txtfolio.Text.Trim() + "' "

                    Dim tabla2 As DataTable = fnc.ListarTablasSQL(sql2)

                    If tabla2.Rows.Count > 0 Then

                        If traecantidad = 1 Then
                            lbluni.Text = tabla2.Rows(0)(0).ToString()
                            lbluni.Visible = True
                        End If
                        If traecantidad = 2 Then
                            lbluni.Text = tabla2.Rows(0)(0).ToString()
                            lbluni2.Text = tabla2.Rows(1)(0).ToString()
                            lbluni.Visible = True
                            lbluni2.Visible = True
                        End If
                        If traecantidad = 3 Then
                            lbluni.Text = tabla2.Rows(0)(0).ToString()
                            lbluni2.Text = tabla2.Rows(1)(0).ToString()
                            lbluni3.Text = tabla2.Rows(2)(0).ToString()
                            lbluni.Visible = True
                            lbluni2.Visible = True
                            lbluni3.Visible = True
                        End If
                        If traecantidad = 4 Then
                            lbluni.Text = tabla2.Rows(0)(0).ToString()
                            lbluni2.Text = tabla2.Rows(1)(0).ToString()
                            lbluni3.Text = tabla2.Rows(2)(0).ToString()
                            lbluni4.Text = tabla2.Rows(3)(0).ToString()
                            lbluni.Visible = True
                            lbluni2.Visible = True
                            lbluni3.Visible = True
                            lbluni4.Visible = True
                        End If
                        If traecantidad = 5 Then
                            lbluni.Text = tabla2.Rows(0)(0).ToString()
                            lbluni2.Text = tabla2.Rows(1)(0).ToString()
                            lbluni3.Text = tabla2.Rows(2)(0).ToString()
                            lbluni4.Text = tabla2.Rows(3)(0).ToString()
                            lbluni5.Text = tabla2.Rows(4)(0).ToString()
                            lbluni.Visible = True
                            lbluni2.Visible = True
                            lbluni3.Visible = True
                            lbluni4.Visible = True
                            lbluni5.Visible = True
                        End If
                        If traecantidad = 6 Then
                            lbluni.Text = tabla2.Rows(0)(0).ToString()
                            lbluni2.Text = tabla2.Rows(1)(0).ToString()
                            lbluni3.Text = tabla2.Rows(2)(0).ToString()
                            lbluni4.Text = tabla2.Rows(3)(0).ToString()
                            lbluni5.Text = tabla2.Rows(4)(0).ToString()
                            lbluni6.Text = tabla2.Rows(5)(0).ToString()
                            lbluni.Visible = True
                            lbluni2.Visible = True
                            lbluni3.Visible = True
                            lbluni4.Visible = True
                            lbluni5.Visible = True
                            lbluni6.Visible = True
                        End If
                        If traecantidad = 7 Then
                            lbluni.Text = tabla2.Rows(0)(0).ToString()
                            lbluni2.Text = tabla2.Rows(1)(0).ToString()
                            lbluni3.Text = tabla2.Rows(2)(0).ToString()
                            lbluni4.Text = tabla2.Rows(3)(0).ToString()
                            lbluni5.Text = tabla2.Rows(4)(0).ToString()
                            lbluni6.Text = tabla2.Rows(5)(0).ToString()
                            lbluni7.Text = tabla2.Rows(6)(0).ToString()
                            lbluni.Visible = True
                            lbluni2.Visible = True
                            lbluni3.Visible = True
                            lbluni4.Visible = True
                            lbluni5.Visible = True
                            lbluni6.Visible = True
                            lbluni7.Visible = True
                        End If
                        If traecantidad = 8 Then
                            lbluni.Text = tabla2.Rows(0)(0).ToString()
                            lbluni2.Text = tabla2.Rows(1)(0).ToString()
                            lbluni3.Text = tabla2.Rows(2)(0).ToString()
                            lbluni4.Text = tabla2.Rows(3)(0).ToString()
                            lbluni5.Text = tabla2.Rows(4)(0).ToString()
                            lbluni6.Text = tabla2.Rows(5)(0).ToString()
                            lbluni7.Text = tabla2.Rows(6)(0).ToString()
                            lbluni8.Text = tabla2.Rows(7)(0).ToString()
                            lbluni.Visible = True
                            lbluni2.Visible = True
                            lbluni3.Visible = True
                            lbluni4.Visible = True
                            lbluni5.Visible = True
                            lbluni6.Visible = True
                            lbluni7.Visible = True
                            lbluni8.Visible = True
                        End If
                        If traecantidad = 9 Then
                            lbluni.Text = tabla2.Rows(0)(0).ToString()
                            lbluni2.Text = tabla2.Rows(1)(0).ToString()
                            lbluni3.Text = tabla2.Rows(2)(0).ToString()
                            lbluni4.Text = tabla2.Rows(3)(0).ToString()
                            lbluni5.Text = tabla2.Rows(4)(0).ToString()
                            lbluni6.Text = tabla2.Rows(5)(0).ToString()
                            lbluni7.Text = tabla2.Rows(6)(0).ToString()
                            lbluni8.Text = tabla2.Rows(7)(0).ToString()
                            lbluni9.Text = tabla2.Rows(8)(0).ToString()
                            lbluni.Visible = True
                            lbluni2.Visible = True
                            lbluni3.Visible = True
                            lbluni4.Visible = True
                            lbluni5.Visible = True
                            lbluni6.Visible = True
                            lbluni7.Visible = True
                            lbluni8.Visible = True
                            lbluni9.Visible = True
                        End If
                        If traecantidad = 10 Then
                            lbluni.Text = tabla2.Rows(0)(0).ToString()
                            lbluni2.Text = tabla2.Rows(1)(0).ToString()
                            lbluni3.Text = tabla2.Rows(2)(0).ToString()
                            lbluni4.Text = tabla2.Rows(3)(0).ToString()
                            lbluni5.Text = tabla2.Rows(4)(0).ToString()
                            lbluni6.Text = tabla2.Rows(5)(0).ToString()
                            lbluni7.Text = tabla2.Rows(6)(0).ToString()
                            lbluni8.Text = tabla2.Rows(7)(0).ToString()
                            lbluni9.Text = tabla2.Rows(8)(0).ToString()
                            lbluni10.Text = tabla2.Rows(9)(0).ToString()
                            lbluni.Visible = True
                            lbluni2.Visible = True
                            lbluni3.Visible = True
                            lbluni4.Visible = True
                            lbluni5.Visible = True
                            lbluni6.Visible = True
                            lbluni7.Visible = True
                            lbluni8.Visible = True
                            lbluni9.Visible = True
                            lbluni10.Visible = True
                        End If
                        If traecantidad = 11 Then
                            lbluni.Text = tabla2.Rows(0)(0).ToString()
                            lbluni2.Text = tabla2.Rows(1)(0).ToString()
                            lbluni3.Text = tabla2.Rows(2)(0).ToString()
                            lbluni4.Text = tabla2.Rows(3)(0).ToString()
                            lbluni5.Text = tabla2.Rows(4)(0).ToString()
                            lbluni6.Text = tabla2.Rows(5)(0).ToString()
                            lbluni7.Text = tabla2.Rows(6)(0).ToString()
                            lbluni8.Text = tabla2.Rows(7)(0).ToString()
                            lbluni9.Text = tabla2.Rows(8)(0).ToString()
                            lbluni10.Text = tabla2.Rows(9)(0).ToString()
                            lbluni11.Text = tabla2.Rows(10)(0).ToString()
                            lbluni.Visible = True
                            lbluni2.Visible = True
                            lbluni3.Visible = True
                            lbluni4.Visible = True
                            lbluni5.Visible = True
                            lbluni6.Visible = True
                            lbluni7.Visible = True
                            lbluni8.Visible = True
                            lbluni9.Visible = True
                            lbluni10.Visible = True
                            lbluni11.Visible = True
                        End If
                        If traecantidad = 12 Then
                            lbluni.Text = tabla2.Rows(0)(0).ToString()
                            lbluni2.Text = tabla2.Rows(1)(0).ToString()
                            lbluni3.Text = tabla2.Rows(2)(0).ToString()
                            lbluni4.Text = tabla2.Rows(3)(0).ToString()
                            lbluni5.Text = tabla2.Rows(4)(0).ToString()
                            lbluni6.Text = tabla2.Rows(5)(0).ToString()
                            lbluni7.Text = tabla2.Rows(6)(0).ToString()
                            lbluni8.Text = tabla2.Rows(7)(0).ToString()
                            lbluni9.Text = tabla2.Rows(8)(0).ToString()
                            lbluni10.Text = tabla2.Rows(9)(0).ToString()
                            lbluni11.Text = tabla2.Rows(10)(0).ToString()
                            lbluni12.Text = tabla2.Rows(11)(0).ToString()
                            lbluni.Visible = True
                            lbluni2.Visible = True
                            lbluni3.Visible = True
                            lbluni4.Visible = True
                            lbluni5.Visible = True
                            lbluni6.Visible = True
                            lbluni7.Visible = True
                            lbluni8.Visible = True
                            lbluni9.Visible = True
                            lbluni10.Visible = True
                            lbluni11.Visible = True
                            lbluni12.Visible = True
                        End If
                    End If

                    x = Convert.ToInt32(tabla.Rows(i)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(i)(1).ToString())

                    If traecantidad = 1 Then
                        lbluni.Location = New Point(x, y)
                    End If

                    If traecantidad = 2 Then
                        lbluni.Location = New Point(x, y)
                        lbluni2.Location = New Point(x, y + 15)
                    End If
                    If traecantidad = 3 Then
                        lbluni.Location = New Point(x, y)
                        lbluni2.Location = New Point(x, y + 15)
                        lbluni3.Location = New Point(x, y + 30)

                    End If
                    If traecantidad = 4 Then
                        lbluni.Location = New Point(x, y)
                        lbluni2.Location = New Point(x, y + 15)
                        lbluni3.Location = New Point(x, y + 30)
                        lbluni4.Location = New Point(x, y + 45)
                    End If
                    If traecantidad = 5 Then
                        lbluni.Location = New Point(x, y)
                        lbluni2.Location = New Point(x, y + 15)
                        lbluni3.Location = New Point(x, y + 30)
                        lbluni4.Location = New Point(x, y + 45)
                        lbluni5.Location = New Point(x, y + 60)
                    End If
                    If traecantidad = 6 Then
                        lbluni.Location = New Point(x, y)
                        lbluni2.Location = New Point(x, y + 15)
                        lbluni3.Location = New Point(x, y + 30)
                        lbluni4.Location = New Point(x, y + 45)
                        lbluni5.Location = New Point(x, y + 60)
                        lbluni6.Location = New Point(x, y + 75)
                    End If
                    If traecantidad = 7 Then
                        lbluni.Location = New Point(x, y)
                        lbluni2.Location = New Point(x, y + 15)
                        lbluni3.Location = New Point(x, y + 30)
                        lbluni4.Location = New Point(x, y + 45)
                        lbluni5.Location = New Point(x, y + 60)
                        lbluni6.Location = New Point(x, y + 75)
                        lbluni7.Location = New Point(x, y + 90)
                    End If
                    If traecantidad = 8 Then
                        lbluni.Location = New Point(x, y)
                        lbluni2.Location = New Point(x, y + 15)
                        lbluni3.Location = New Point(x, y + 30)
                        lbluni4.Location = New Point(x, y + 45)
                        lbluni5.Location = New Point(x, y + 60)
                        lbluni6.Location = New Point(x, y + 75)
                        lbluni7.Location = New Point(x, y + 90)
                        lbluni8.Location = New Point(x, y + 105)
                    End If
                    If traecantidad = 9 Then
                        lbluni.Location = New Point(x, y)
                        lbluni2.Location = New Point(x, y + 15)
                        lbluni3.Location = New Point(x, y + 30)
                        lbluni4.Location = New Point(x, y + 45)
                        lbluni5.Location = New Point(x, y + 60)
                        lbluni6.Location = New Point(x, y + 75)
                        lbluni7.Location = New Point(x, y + 90)
                        lbluni8.Location = New Point(x, y + 105)
                        lbluni9.Location = New Point(x, y + 120)
                    End If
                    If traecantidad = 10 Then
                        lbluni.Location = New Point(x, y)
                        lbluni2.Location = New Point(x, y + 15)
                        lbluni3.Location = New Point(x, y + 30)
                        lbluni4.Location = New Point(x, y + 45)
                        lbluni5.Location = New Point(x, y + 60)
                        lbluni6.Location = New Point(x, y + 75)
                        lbluni7.Location = New Point(x, y + 90)
                        lbluni8.Location = New Point(x, y + 105)
                        lbluni9.Location = New Point(x, y + 120)
                        lbluni10.Location = New Point(x, y + 135)
                    End If
                    If traecantidad = 11 Then
                        lbluni.Location = New Point(x, y)
                        lbluni2.Location = New Point(x, y + 15)
                        lbluni3.Location = New Point(x, y + 30)
                        lbluni4.Location = New Point(x, y + 45)
                        lbluni5.Location = New Point(x, y + 60)
                        lbluni6.Location = New Point(x, y + 75)
                        lbluni7.Location = New Point(x, y + 90)
                        lbluni8.Location = New Point(x, y + 105)
                        lbluni9.Location = New Point(x, y + 120)
                        lbluni10.Location = New Point(x, y + 135)
                        lbluni11.Location = New Point(x, y + 150)
                    End If
                    If traecantidad = 12 Then
                        lbluni.Location = New Point(x, y)
                        lbluni2.Location = New Point(x, y + 15)
                        lbluni3.Location = New Point(x, y + 30)
                        lbluni4.Location = New Point(x, y + 45)
                        lbluni5.Location = New Point(x, y + 60)
                        lbluni6.Location = New Point(x, y + 75)
                        lbluni7.Location = New Point(x, y + 90)
                        lbluni8.Location = New Point(x, y + 105)
                        lbluni9.Location = New Point(x, y + 120)
                        lbluni10.Location = New Point(x, y + 135)
                        lbluni11.Location = New Point(x, y + 150)
                        lbluni12.Location = New Point(x, y + 165)
                    End If
                End If

                If dato = "Kilos" Then


                    Dim sql2 As String = "SELECT kilos=cast(kilos as decimal(10,1)) from rpt_despacho_informe where ddes_rutcli= '" + TxtClirut.Text + "' and despacho = '" + txtfolio.Text.Trim() + "' "

                    Dim tabla2 As DataTable = fnc.ListarTablasSQL(sql2)

                    If tabla2.Rows.Count > 0 Then

                        If traecantidad = 1 Then
                            lblkil.Text = tabla2.Rows(0)(0).ToString()
                            lblkil.Visible = True
                        End If
                        If traecantidad = 2 Then
                            lblkil.Text = tabla2.Rows(0)(0).ToString()
                            lblkil2.Text = tabla2.Rows(1)(0).ToString()
                            lblkil.Visible = True
                            lblkil2.Visible = True
                        End If
                        If traecantidad = 3 Then
                            lblkil.Text = tabla2.Rows(0)(0).ToString()
                            lblkil2.Text = tabla2.Rows(1)(0).ToString()
                            lblkil3.Text = tabla2.Rows(2)(0).ToString()
                            lblkil.Visible = True
                            lblkil2.Visible = True
                            lblkil3.Visible = True
                        End If
                        If traecantidad = 4 Then
                            lblkil.Text = tabla2.Rows(0)(0).ToString()
                            lblkil2.Text = tabla2.Rows(1)(0).ToString()
                            lblkil3.Text = tabla2.Rows(2)(0).ToString()
                            lblkil4.Text = tabla2.Rows(3)(0).ToString()
                            lblkil.Visible = True
                            lblkil2.Visible = True
                            lblkil3.Visible = True
                            lblkil4.Visible = True
                        End If
                        If traecantidad = 5 Then
                            lblkil.Text = tabla2.Rows(0)(0).ToString()
                            lblkil2.Text = tabla2.Rows(1)(0).ToString()
                            lblkil3.Text = tabla2.Rows(2)(0).ToString()
                            lblkil4.Text = tabla2.Rows(3)(0).ToString()
                            lblkil5.Text = tabla2.Rows(4)(0).ToString()
                            lblkil.Visible = True
                            lblkil2.Visible = True
                            lblkil3.Visible = True
                            lblkil4.Visible = True
                            lblkil5.Visible = True
                        End If
                        If traecantidad = 6 Then
                            lblkil.Text = tabla2.Rows(0)(0).ToString()
                            lblkil2.Text = tabla2.Rows(1)(0).ToString()
                            lblkil3.Text = tabla2.Rows(2)(0).ToString()
                            lblkil4.Text = tabla2.Rows(3)(0).ToString()
                            lblkil5.Text = tabla2.Rows(4)(0).ToString()
                            lblkil6.Text = tabla2.Rows(5)(0).ToString()
                            lblkil.Visible = True
                            lblkil2.Visible = True
                            lblkil3.Visible = True
                            lblkil4.Visible = True
                            lblkil5.Visible = True
                            lblkil6.Visible = True
                        End If
                        If traecantidad = 7 Then
                            lblkil.Text = tabla2.Rows(0)(0).ToString()
                            lblkil2.Text = tabla2.Rows(1)(0).ToString()
                            lblkil3.Text = tabla2.Rows(2)(0).ToString()
                            lblkil4.Text = tabla2.Rows(3)(0).ToString()
                            lblkil5.Text = tabla2.Rows(4)(0).ToString()
                            lblkil6.Text = tabla2.Rows(5)(0).ToString()
                            lblkil7.Text = tabla2.Rows(6)(0).ToString()
                            lblkil.Visible = True
                            lblkil2.Visible = True
                            lblkil3.Visible = True
                            lblkil4.Visible = True
                            lblkil5.Visible = True
                            lblkil6.Visible = True
                            lblkil7.Visible = True
                        End If
                        If traecantidad = 8 Then
                            lblkil.Text = tabla2.Rows(0)(0).ToString()
                            lblkil2.Text = tabla2.Rows(1)(0).ToString()
                            lblkil3.Text = tabla2.Rows(2)(0).ToString()
                            lblkil4.Text = tabla2.Rows(3)(0).ToString()
                            lblkil5.Text = tabla2.Rows(4)(0).ToString()
                            lblkil6.Text = tabla2.Rows(5)(0).ToString()
                            lblkil7.Text = tabla2.Rows(6)(0).ToString()
                            lblkil8.Text = tabla2.Rows(7)(0).ToString()
                            lblkil.Visible = True
                            lblkil2.Visible = True
                            lblkil3.Visible = True
                            lblkil4.Visible = True
                            lblkil5.Visible = True
                            lblkil6.Visible = True
                            lblkil7.Visible = True
                            lblkil8.Visible = True
                        End If
                        If traecantidad = 9 Then
                            lblkil.Text = tabla2.Rows(0)(0).ToString()
                            lblkil2.Text = tabla2.Rows(1)(0).ToString()
                            lblkil3.Text = tabla2.Rows(2)(0).ToString()
                            lblkil4.Text = tabla2.Rows(3)(0).ToString()
                            lblkil5.Text = tabla2.Rows(4)(0).ToString()
                            lblkil6.Text = tabla2.Rows(5)(0).ToString()
                            lblkil7.Text = tabla2.Rows(6)(0).ToString()
                            lblkil8.Text = tabla2.Rows(7)(0).ToString()
                            lblkil9.Text = tabla2.Rows(8)(0).ToString()
                            lblkil.Visible = True
                            lblkil2.Visible = True
                            lblkil3.Visible = True
                            lblkil4.Visible = True
                            lblkil5.Visible = True
                            lblkil6.Visible = True
                            lblkil7.Visible = True
                            lblkil8.Visible = True
                            lblkil9.Visible = True
                        End If
                        If traecantidad = 10 Then
                            lblkil.Text = tabla2.Rows(0)(0).ToString()
                            lblkil2.Text = tabla2.Rows(1)(0).ToString()
                            lblkil3.Text = tabla2.Rows(2)(0).ToString()
                            lblkil4.Text = tabla2.Rows(3)(0).ToString()
                            lblkil5.Text = tabla2.Rows(4)(0).ToString()
                            lblkil6.Text = tabla2.Rows(5)(0).ToString()
                            lblkil7.Text = tabla2.Rows(6)(0).ToString()
                            lblkil8.Text = tabla2.Rows(7)(0).ToString()
                            lblkil9.Text = tabla2.Rows(8)(0).ToString()
                            lblkil10.Text = tabla2.Rows(9)(0).ToString()
                            lblkil.Visible = True
                            lblkil2.Visible = True
                            lblkil3.Visible = True
                            lblkil4.Visible = True
                            lblkil5.Visible = True
                            lblkil6.Visible = True
                            lblkil7.Visible = True
                            lblkil8.Visible = True
                            lblkil9.Visible = True
                            lblkil10.Visible = True
                        End If
                        If traecantidad = 11 Then
                            lblkil.Text = tabla2.Rows(0)(0).ToString()
                            lblkil2.Text = tabla2.Rows(1)(0).ToString()
                            lblkil3.Text = tabla2.Rows(2)(0).ToString()
                            lblkil4.Text = tabla2.Rows(3)(0).ToString()
                            lblkil5.Text = tabla2.Rows(4)(0).ToString()
                            lblkil6.Text = tabla2.Rows(5)(0).ToString()
                            lblkil7.Text = tabla2.Rows(6)(0).ToString()
                            lblkil8.Text = tabla2.Rows(7)(0).ToString()
                            lblkil9.Text = tabla2.Rows(8)(0).ToString()
                            lblkil10.Text = tabla2.Rows(9)(0).ToString()
                            lblkil11.Text = tabla2.Rows(10)(0).ToString()
                            lblkil.Visible = True
                            lblkil2.Visible = True
                            lblkil3.Visible = True
                            lblkil4.Visible = True
                            lblkil5.Visible = True
                            lblkil6.Visible = True
                            lblkil7.Visible = True
                            lblkil8.Visible = True
                            lblkil9.Visible = True
                            lblkil10.Visible = True
                            lblkil11.Visible = True
                        End If
                        If traecantidad = 12 Then
                            lblkil.Text = tabla2.Rows(0)(0).ToString()
                            lblkil2.Text = tabla2.Rows(1)(0).ToString()
                            lblkil3.Text = tabla2.Rows(2)(0).ToString()
                            lblkil4.Text = tabla2.Rows(3)(0).ToString()
                            lblkil5.Text = tabla2.Rows(4)(0).ToString()
                            lblkil6.Text = tabla2.Rows(5)(0).ToString()
                            lblkil7.Text = tabla2.Rows(6)(0).ToString()
                            lblkil8.Text = tabla2.Rows(7)(0).ToString()
                            lblkil9.Text = tabla2.Rows(8)(0).ToString()
                            lblkil10.Text = tabla2.Rows(9)(0).ToString()
                            lblkil11.Text = tabla2.Rows(10)(0).ToString()
                            lblkil12.Text = tabla2.Rows(11)(0).ToString()
                            lblkil.Visible = True
                            lblkil2.Visible = True
                            lblkil3.Visible = True
                            lblkil4.Visible = True
                            lblkil5.Visible = True
                            lblkil6.Visible = True
                            lblkil7.Visible = True
                            lblkil8.Visible = True
                            lblkil9.Visible = True
                            lblkil10.Visible = True
                            lblkil11.Visible = True
                            lblkil12.Visible = True
                        End If
                    End If

                    x = Convert.ToInt32(tabla.Rows(i)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(i)(1).ToString())

                    If traecantidad = 1 Then
                        lblkil.Location = New Point(x, y)
                    End If

                    If traecantidad = 2 Then
                        lblkil.Location = New Point(x, y)
                        lblkil2.Location = New Point(x, y + 15)
                    End If
                    If traecantidad = 3 Then
                        lblkil.Location = New Point(x, y)
                        lblkil2.Location = New Point(x, y + 15)
                        lblkil3.Location = New Point(x, y + 30)

                    End If
                    If traecantidad = 4 Then
                        lblkil.Location = New Point(x, y)
                        lblkil2.Location = New Point(x, y + 15)
                        lblkil3.Location = New Point(x, y + 30)
                        lblkil4.Location = New Point(x, y + 45)
                    End If
                    If traecantidad = 5 Then
                        lblkil.Location = New Point(x, y)
                        lblkil2.Location = New Point(x, y + 15)
                        lblkil3.Location = New Point(x, y + 30)
                        lblkil4.Location = New Point(x, y + 45)
                        lblkil5.Location = New Point(x, y + 60)
                    End If
                    If traecantidad = 6 Then
                        lblkil.Location = New Point(x, y)
                        lblkil2.Location = New Point(x, y + 15)
                        lblkil3.Location = New Point(x, y + 30)
                        lblkil4.Location = New Point(x, y + 45)
                        lblkil5.Location = New Point(x, y + 60)
                        lblkil6.Location = New Point(x, y + 75)
                    End If
                    If traecantidad = 7 Then
                        lblkil.Location = New Point(x, y)
                        lblkil2.Location = New Point(x, y + 15)
                        lblkil3.Location = New Point(x, y + 30)
                        lblkil4.Location = New Point(x, y + 45)
                        lblkil5.Location = New Point(x, y + 60)
                        lblkil6.Location = New Point(x, y + 75)
                        lblkil7.Location = New Point(x, y + 90)
                    End If
                    If traecantidad = 8 Then
                        lblkil.Location = New Point(x, y)
                        lblkil2.Location = New Point(x, y + 15)
                        lblkil3.Location = New Point(x, y + 30)
                        lblkil4.Location = New Point(x, y + 45)
                        lblkil5.Location = New Point(x, y + 60)
                        lblkil6.Location = New Point(x, y + 75)
                        lblkil7.Location = New Point(x, y + 90)
                        lblkil8.Location = New Point(x, y + 105)
                    End If
                    If traecantidad = 9 Then
                        lblkil.Location = New Point(x, y)
                        lblkil2.Location = New Point(x, y + 15)
                        lblkil3.Location = New Point(x, y + 30)
                        lblkil4.Location = New Point(x, y + 45)
                        lblkil5.Location = New Point(x, y + 60)
                        lblkil6.Location = New Point(x, y + 75)
                        lblkil7.Location = New Point(x, y + 90)
                        lblkil8.Location = New Point(x, y + 105)
                        lblkil9.Location = New Point(x, y + 120)
                    End If
                    If traecantidad = 10 Then
                        lblkil.Location = New Point(x, y)
                        lblkil2.Location = New Point(x, y + 15)
                        lblkil3.Location = New Point(x, y + 30)
                        lblkil4.Location = New Point(x, y + 45)
                        lblkil5.Location = New Point(x, y + 60)
                        lblkil6.Location = New Point(x, y + 75)
                        lblkil7.Location = New Point(x, y + 90)
                        lblkil8.Location = New Point(x, y + 105)
                        lblkil9.Location = New Point(x, y + 120)
                        lblkil10.Location = New Point(x, y + 135)
                    End If
                    If traecantidad = 11 Then
                        lblkil.Location = New Point(x, y)
                        lblkil2.Location = New Point(x, y + 15)
                        lblkil3.Location = New Point(x, y + 30)
                        lblkil4.Location = New Point(x, y + 45)
                        lblkil5.Location = New Point(x, y + 60)
                        lblkil6.Location = New Point(x, y + 75)
                        lblkil7.Location = New Point(x, y + 90)
                        lblkil8.Location = New Point(x, y + 105)
                        lblkil9.Location = New Point(x, y + 120)
                        lblkil10.Location = New Point(x, y + 135)
                        lblkil11.Location = New Point(x, y + 150)
                    End If
                    If traecantidad = 12 Then
                        lblkil.Location = New Point(x, y)
                        lblkil2.Location = New Point(x, y + 15)
                        lblkil3.Location = New Point(x, y + 30)
                        lblkil4.Location = New Point(x, y + 45)
                        lblkil5.Location = New Point(x, y + 60)
                        lblkil6.Location = New Point(x, y + 75)
                        lblkil7.Location = New Point(x, y + 90)
                        lblkil8.Location = New Point(x, y + 105)
                        lblkil9.Location = New Point(x, y + 120)
                        lblkil10.Location = New Point(x, y + 135)
                        lblkil11.Location = New Point(x, y + 150)
                        lblkil12.Location = New Point(x, y + 165)
                    End If
                End If

            Next
        End If
    End Sub

    Private Sub btn_BuscaCliente_Click(sender As System.Object, e As System.EventArgs)

    End Sub
    Public Function ByteArrayToImage(ByVal byteArrayIn As Byte()) As Image
        Dim ms As New MemoryStream(byteArrayIn)
        Return Image.FromStream(ms)
    End Function
    Private Sub cargaimg()

        Dim sqlImagen As String = "SELECT foto from clienteimageninf where id= '" + TxtClirut.Text + "'"

        Dim tablaimagen As DataTable = fnc.ListarTablasSQL(sqlImagen)

        If tablaimagen.Rows.Count > 0 Then

            'Imagen1
            If tablaimagen.Rows(0)(0).ToString() <> "" Then
                'PictureBox1.Image = Base64ToImage(tablaimagen.Rows(0)(0))
                Panel1.BackgroundImage = ByteArrayToImage(DirectCast(tablaimagen.Rows(0)(0), Byte()))

            Else
                Panel1.BackgroundImage = Nothing
            End If

        End If

    End Sub
    Private Sub Graposicion()

        Dim sql As String = "SELECT x,y from datos_informes where rutcli= '" + TxtClirut.Text + "' and dato = '" + cbodatos.Text.Trim() + "' "

        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

        If tabla.Rows.Count > 0 Then


            Dim SqlMovpallet As String = "UPDATE datos_informes SET x='" + x.ToString() + "', y='" + y.ToString() + "' where rutcli= '" + TxtClirut.Text + "' and dato = '" + cbodatos.Text.Trim() + "' "
            fnc.MovimientoSQL(SqlMovpallet)


        Else

            Dim _log As String = "INSERT INTO datos_informes(dato, rutcli, x, y)" +
                                      "VALUES('" + cbodatos.Text.Trim() + "','" + TxtClirut.Text.Trim() + "'," +
                                      "'" + x.ToString() + "','" + y.ToString() + "')"
            fnc.MovimientoSQL(_log)

        End If


    End Sub

    Private Sub traecanti()

        Dim sql As String = "SELECT cantpro from rpt_cant_prod where ddes_rutcli= '" + TxtClirut.Text + "' and despacho = '" + txtfolio.Text.Trim() + "' "

        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

        If tabla.Rows.Count > 0 Then
            traecantidad = Convert.ToInt32(tabla.Rows(0)(0).ToString())
        End If

    End Sub
    Private Sub editar()
       

    End Sub
    Private Sub Btn_Calcular_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Calcular.Click
        ''111+56
        If cbodatos.Text.Trim = "Despacho" Then

            Dim sql As String = "SELECT x,y from datos_informes where rutcli= '" + TxtClirut.Text + "' and dato = '" + cbodatos.Text.Trim() + "'  "

            Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

            If tabla.Rows.Count > 0 Then


                lbldespacho.Visible = True
                x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                lbldespacho.Location = New Point(x, y)
            Else

                lbldespacho.Visible = True
                x = 111
                y = 56
                lbldespacho.Location = New Point(111, 56)

            End If

            If cbodatos.Text.Trim = "Despacho" Then
                lbldespacho.Text = txtfolio.Text

            End If
        End If
        If cbodatos.Text.Trim = "Fecha" Then

            Dim sql As String = "SELECT x,y from datos_informes where rutcli= '" + TxtClirut.Text + "' and dato = '" + cbodatos.Text.Trim() + "'  "

            Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

            If tabla.Rows.Count > 0 Then


                lblfecha.Visible = True
                x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                lblfecha.Location = New Point(x, y)
            Else

                lblfecha.Visible = True
                x = 111
                y = 56
                lblfecha.Location = New Point(111, 56)

            End If

            If cbodatos.Text.Trim = "Fecha" Then
                lblfecha.Text = Frm_Despacho.dt_fecha.Text.Trim()

            End If
        End If
        If cbodatos.Text.Trim = "Nombre chofer" Then

            Dim sql As String = "SELECT x,y from datos_informes where rutcli= '" + TxtClirut.Text + "' and dato = '" + cbodatos.Text.Trim() + "'  "

            Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

            If tabla.Rows.Count > 0 Then


                lblnomcho.Visible = True
                x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                lblnomcho.Location = New Point(x, y)
            Else

                lblnomcho.Visible = True
                x = 111
                y = 56
                lblnomcho.Location = New Point(111, 56)

            End If

            If cbodatos.Text.Trim = "Nombre chofer" Then
                lblnomcho.Text = Frm_Despacho.txtchonom.Text.Trim()

            End If
        End If
        If cbodatos.Text.Trim = "Rut chofer" Then

            Dim sql As String = "SELECT x,y from datos_informes where rutcli= '" + TxtClirut.Text + "' and dato = '" + cbodatos.Text.Trim() + "'  "

            Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

            If tabla.Rows.Count > 0 Then


                lblrutcho.Visible = True
                x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                lblrutcho.Location = New Point(x, y)
            Else

                lblrutcho.Visible = True
                x = 111
                y = 56
                lblrutcho.Location = New Point(111, 56)

            End If

            If cbodatos.Text.Trim = "Rut chofer" Then
                lblrutcho.Text = Frm_Despacho.Txtchorut.Text.Trim()

            End If
        End If

        If cbodatos.Text.Trim = "Patente" Then

            Dim sql As String = "SELECT x,y from datos_informes where rutcli= '" + TxtClirut.Text + "' and dato = '" + cbodatos.Text.Trim() + "'  "

            Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

            If tabla.Rows.Count > 0 Then


                lblpatente.Visible = True
                x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                lblpatente.Location = New Point(x, y)
            Else

                lblpatente.Visible = True
                x = 111
                y = 56
                lblpatente.Location = New Point(111, 56)

            End If

            If cbodatos.Text.Trim = "Patente" Then
                lblpatente.Text = Frm_Despacho.txtpatente.Text.Trim()

            End If
        End If
        If cbodatos.Text.Trim = "Observacion" Then

            Dim sql As String = "SELECT x,y from datos_informes where rutcli= '" + TxtClirut.Text + "' and dato = '" + cbodatos.Text.Trim() + "'  "

            Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

            If tabla.Rows.Count > 0 Then


                lblobs.Visible = True
                x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                lblobs.Location = New Point(x, y)
            Else

                lblobs.Visible = True
                x = 111
                y = 56
                lblobs.Location = New Point(111, 56)

            End If

            If cbodatos.Text.Trim = "Observacion" Then
                lblobs.Text = Frm_Despacho.TxtObs.Text.Trim()

            End If
        End If

        If cbodatos.Text.Trim = "Destino" Then

            Dim sql As String = "SELECT x,y from datos_informes where rutcli= '" + TxtClirut.Text + "' and dato = '" + cbodatos.Text.Trim() + "'  "

            Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

            If tabla.Rows.Count > 0 Then


                lbldestino.Visible = True
                x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                lbldestino.Location = New Point(x, y)
            Else

                lbldestino.Visible = True
                x = 111
                y = 56
                lbldestino.Location = New Point(111, 56)

            End If

            If cbodatos.Text.Trim = "Destino" Then
                ' lbldestino.Text = Frm_Despacho.TxtDestino.Text.Trim()

                Dim sql2 As String = "SELECT destino,destino_rut,destino_dir from vg_despachos_destinos where fdes_codi= '" + txtfolio.Text + "'  "

                Dim tabla2 As DataTable = fnc.ListarTablasSQL(sql2)

                If tabla2.Rows.Count > 0 Then

                    lbldestino.Text = tabla2.Rows(0)(0).ToString()
                    lbldestino2.Text = tabla2.Rows(0)(1).ToString()
                    lbldestino3.Text = tabla2.Rows(0)(2).ToString()
                End If


            End If
        End If
        If cbodatos.Text.Trim = "Giro" Then

            Dim sql As String = "SELECT x,y from datos_informes where rutcli= '" + TxtClirut.Text + "' and dato = '" + cbodatos.Text.Trim() + "'  "

            Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

            If tabla.Rows.Count > 0 Then


                lblgiro.Visible = True
                x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                lblgiro.Location = New Point(x, y)
            Else

                lblgiro.Visible = True
                x = 111
                y = 56
                lblgiro.Location = New Point(111, 56)

            End If

            If cbodatos.Text.Trim = "Giro" Then

                Dim sql2 As String = "SELECT cli_rubro from clientes where cli_rut= '" + TxtClirut.Text + "'  "

                Dim tabla2 As DataTable = fnc.ListarTablasSQL(sql2)

                If tabla2.Rows.Count > 0 Then

                    lblgiro.Text = tabla2.Rows(0)(0).ToString()
                End If


            End If
        End If
        If cbodatos.Text.Trim = "Direccion" Then

            Dim sql As String = "SELECT x,y from datos_informes where rutcli= '" + TxtClirut.Text + "' and dato = '" + cbodatos.Text.Trim() + "'  "

            Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

            If tabla.Rows.Count > 0 Then


                lbldireccion.Visible = True
                x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                lbldireccion.Location = New Point(x, y)
            Else

                lbldireccion.Visible = True
                x = 111
                y = 56
                lbldireccion.Location = New Point(111, 56)

            End If

            If cbodatos.Text.Trim = "Direccion" Then

                Dim sql2 As String = "SELECT cli_direcc from clientes where cli_rut= '" + TxtClirut.Text + "'  "

                Dim tabla2 As DataTable = fnc.ListarTablasSQL(sql2)

                If tabla2.Rows.Count > 0 Then

                    lbldireccion.Text = tabla2.Rows(0)(0).ToString()
                End If


            End If
        End If
        If cbodatos.Text.Trim = "Comuna" Then

            Dim sql As String = "SELECT x,y from datos_informes where rutcli= '" + TxtClirut.Text + "' and dato = '" + cbodatos.Text.Trim() + "'  "

            Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

            If tabla.Rows.Count > 0 Then


                lblcomuna.Visible = True
                x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                lblcomuna.Location = New Point(x, y)
            Else

                lblcomuna.Visible = True
                x = 111
                y = 56
                lblcomuna.Location = New Point(111, 56)

            End If

            If cbodatos.Text.Trim = "Comuna" Then

                Dim sql2 As String = "SELECT cli_comuna from clientes where cli_rut= '" + TxtClirut.Text + "'  "

                Dim tabla2 As DataTable = fnc.ListarTablasSQL(sql2)

                If tabla2.Rows.Count > 0 Then

                    lblcomuna.Text = tabla2.Rows(0)(0).ToString()
                End If


            End If
        End If

        ''Rut cliente
        If cbodatos.Text.Trim = "Rut cliente" Then

            Dim sql As String = "SELECT x,y from datos_informes where rutcli= '" + TxtClirut.Text + "' and dato = '" + cbodatos.Text.Trim() + "' "

            Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

            If tabla.Rows.Count > 0 Then


                lblrutcli.Visible = True
                x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                lblrutcli.Location = New Point(x, y)
            Else

                lblrutcli.Visible = True
                x = 111
                y = 56
                lblrutcli.Location = New Point(111, 56)

            End If

            If cbodatos.Text.Trim = "Rut cliente" Then
                lblrutcli.Text = TxtClirut.Text

            End If
        End If
        If cbodatos.Text.Trim = "Nombre cliente" Then

            Dim sql As String = "SELECT x,y from datos_informes where rutcli= '" + TxtClirut.Text + "' and dato = '" + cbodatos.Text.Trim() + "' "

            Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

            If tabla.Rows.Count > 0 Then


                lblnomcli.Visible = True
                x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                lblnomcli.Location = New Point(x, y)
            Else

                lblnomcli.Visible = True
                x = 111
                y = 56
                lblnomcli.Location = New Point(111, 56)

            End If

            If cbodatos.Text.Trim = "Nombre cliente" Then
                lblnomcli.Text = txtclinom.Text

            End If
        End If
        If cbodatos.Text.Trim = "Codigo producto" Then
            traecanti()
            Dim sql As String = "SELECT x,y from datos_informes where rutcli= '" + TxtClirut.Text + "' and dato = '" + cbodatos.Text.Trim() + "' "

            Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

            If tabla.Rows.Count > 0 Then
                If traecantidad = 1 Then
                    lblcodpro.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblcodpro.Location = New Point(x, y)



                End If

                If traecantidad = 2 Then
                    lblcodpro.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblcodpro.Location = New Point(x, y)
                    lblcodpro2.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblcodpro2.Location = New Point(x, y + 15)



                End If


                If traecantidad = 3 Then
                    lblcodpro.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblcodpro.Location = New Point(x, y)
                    lblcodpro2.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblcodpro2.Location = New Point(x, y + 15)
                    lblcodpro3.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblcodpro3.Location = New Point(x, y + 30)



                End If

                If traecantidad = 4 Then
                    lblcodpro.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblcodpro.Location = New Point(x, y)
                    lblcodpro2.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblcodpro2.Location = New Point(x, y + 15)
                    lblcodpro3.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblcodpro3.Location = New Point(x, y + 30)
                    lblcodpro4.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblcodpro4.Location = New Point(x, y + 45)


                End If
                If traecantidad = 5 Then
                    lblcodpro.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblcodpro.Location = New Point(x, y)
                    lblcodpro2.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblcodpro2.Location = New Point(x, y + 15)
                    lblcodpro3.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblcodpro3.Location = New Point(x, y + 30)
                    lblcodpro4.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblcodpro4.Location = New Point(x, y + 45)
                    lblcodpro5.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblcodpro5.Location = New Point(x, y + 60)


                End If
                If traecantidad = 6 Then
                    lblcodpro.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblcodpro.Location = New Point(x, y)
                    lblcodpro2.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblcodpro2.Location = New Point(x, y + 15)
                    lblcodpro3.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblcodpro3.Location = New Point(x, y + 30)
                    lblcodpro4.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblcodpro4.Location = New Point(x, y + 45)
                    lblcodpro5.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblcodpro5.Location = New Point(x, y + 60)
                    lblcodpro6.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblcodpro6.Location = New Point(x, y + 75)

                End If

            Else

                x = 111
                y = 56


                If traecantidad = 1 Then
                    lblcodpro.Visible = True
                    lblcodpro.Location = New Point(x, y)
                End If
                If traecantidad = 2 Then
                    lblcodpro.Visible = True
                    lblcodpro.Location = New Point(x, y)
                    lblcodpro2.Visible = True
                    lblcodpro2.Location = New Point(x, y + 15)
                End If
                If traecantidad = 3 Then
                    lblcodpro.Visible = True
                    lblcodpro.Location = New Point(x, y)
                    lblcodpro2.Visible = True
                    lblcodpro2.Location = New Point(x, y + 15)
                    lblcodpro3.Visible = True
                    lblcodpro3.Location = New Point(x, y + 30)

                End If
                If traecantidad = 4 Then
                    lblcodpro.Visible = True
                    lblcodpro.Location = New Point(x, y)
                    lblcodpro2.Visible = True
                    lblcodpro2.Location = New Point(x, y + 15)
                    lblcodpro3.Visible = True
                    lblcodpro3.Location = New Point(x, y + 30)
                    lblcodpro4.Visible = True
                    lblcodpro4.Location = New Point(x, y + 45)
                End If
                If traecantidad = 5 Then
                    lblcodpro.Visible = True
                    lblcodpro.Location = New Point(x, y)
                    lblcodpro2.Visible = True
                    lblcodpro2.Location = New Point(x, y + 15)
                    lblcodpro3.Visible = True
                    lblcodpro3.Location = New Point(x, y + 30)
                    lblcodpro4.Visible = True
                    lblcodpro4.Location = New Point(x, y + 45)
                    lblcodpro5.Visible = True
                    lblcodpro5.Location = New Point(x, y + 60)
                End If
                If traecantidad = 6 Then
                    lblcodpro.Visible = True
                    lblcodpro.Location = New Point(x, y)
                    lblcodpro2.Visible = True
                    lblcodpro2.Location = New Point(x, y + 15)
                    lblcodpro3.Visible = True
                    lblcodpro3.Location = New Point(x, y + 30)
                    lblcodpro4.Visible = True
                    lblcodpro4.Location = New Point(x, y + 45)
                    lblcodpro5.Visible = True
                    lblcodpro5.Location = New Point(x, y + 60)
                    lblcodpro6.Visible = True
                    lblcodpro6.Location = New Point(x, y + 75)
                End If










            End If

            If cbodatos.Text.Trim = "Codigo producto" Then
                'lblrutcli.Text = TxtClirut.Text


                Dim sql2 As String = "SELECT drec_codpro from rpt_despacho_informe where ddes_rutcli= '" + TxtClirut.Text + "' and despacho = '" + txtfolio.Text.Trim() + "' "

                Dim tabla2 As DataTable = fnc.ListarTablasSQL(sql2)

                If tabla2.Rows.Count > 0 Then

                    If traecantidad = 1 Then
                        lblcodpro.Text = tabla2.Rows(0)(0).ToString()

                    End If
                    If traecantidad = 2 Then
                        lblcodpro.Text = tabla2.Rows(0)(0).ToString()
                        lblcodpro2.Text = tabla2.Rows(1)(0).ToString()
                    End If
                    If traecantidad = 3 Then
                        lblcodpro.Text = tabla2.Rows(0)(0).ToString()
                        lblcodpro2.Text = tabla2.Rows(1)(0).ToString()
                        lblcodpro3.Text = tabla2.Rows(2)(0).ToString()
                    End If
                    If traecantidad = 4 Then
                        lblcodpro.Text = tabla2.Rows(0)(0).ToString()
                        lblcodpro2.Text = tabla2.Rows(1)(0).ToString()
                        lblcodpro3.Text = tabla2.Rows(2)(0).ToString()
                        lblcodpro4.Text = tabla2.Rows(3)(0).ToString()
                    End If
                    If traecantidad = 5 Then
                        lblcodpro.Text = tabla2.Rows(0)(0).ToString()
                        lblcodpro2.Text = tabla2.Rows(1)(0).ToString()
                        lblcodpro3.Text = tabla2.Rows(2)(0).ToString()
                        lblcodpro4.Text = tabla2.Rows(3)(0).ToString()
                        lblcodpro5.Text = tabla2.Rows(4)(0).ToString()
                    End If
                    If traecantidad = 6 Then
                        lblcodpro.Text = tabla2.Rows(0)(0).ToString()
                        lblcodpro2.Text = tabla2.Rows(1)(0).ToString()
                        lblcodpro3.Text = tabla2.Rows(2)(0).ToString()
                        lblcodpro4.Text = tabla2.Rows(3)(0).ToString()
                        lblcodpro5.Text = tabla2.Rows(4)(0).ToString()
                        lblcodpro6.Text = tabla2.Rows(5)(0).ToString()
                    End If




                End If






            End If
        End If
        If cbodatos.Text.Trim = "Nombre producto" Then
            traecanti()
            Dim sql As String = "SELECT x,y from datos_informes where rutcli= '" + TxtClirut.Text + "' and dato = '" + cbodatos.Text.Trim() + "' "

            Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

            If tabla.Rows.Count > 0 Then
                If traecantidad = 1 Then
                    lblnompro.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblnompro.Location = New Point(x, y)



                End If

                If traecantidad = 2 Then
                    lblnompro.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblnompro.Location = New Point(x, y)
                    lblnompro2.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblnompro2.Location = New Point(x, y + 15)



                End If


                If traecantidad = 3 Then
                    lblnompro.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblnompro.Location = New Point(x, y)
                    lblnompro2.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblnompro2.Location = New Point(x, y + 15)
                    lblnompro3.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblnompro3.Location = New Point(x, y + 30)



                End If

                If traecantidad = 4 Then
                    lblnompro.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblnompro.Location = New Point(x, y)
                    lblnompro2.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblnompro2.Location = New Point(x, y + 15)
                    lblnompro3.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblnompro3.Location = New Point(x, y + 30)
                    lblnompro4.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblnompro4.Location = New Point(x, y + 45)


                End If
                If traecantidad = 5 Then
                    lblnompro.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblnompro.Location = New Point(x, y)
                    lblnompro2.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblnompro2.Location = New Point(x, y + 15)
                    lblnompro3.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblnompro3.Location = New Point(x, y + 30)
                    lblnompro4.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblnompro4.Location = New Point(x, y + 45)
                    lblnompro5.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblnompro5.Location = New Point(x, y + 60)


                End If
                If traecantidad = 6 Then
                    lblnompro.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblnompro.Location = New Point(x, y)
                    lblnompro2.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblnompro2.Location = New Point(x, y + 15)
                    lblnompro3.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblnompro3.Location = New Point(x, y + 30)
                    lblnompro4.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblnompro4.Location = New Point(x, y + 45)
                    lblnompro5.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblnompro5.Location = New Point(x, y + 60)
                    lblnompro6.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblnompro6.Location = New Point(x, y + 75)

                End If

            Else

                x = 111
                y = 56


                If traecantidad = 1 Then
                    lblnompro.Visible = True
                    lblnompro.Location = New Point(x, y)
                End If
                If traecantidad = 2 Then
                    lblnompro.Visible = True
                    lblnompro.Location = New Point(x, y)
                    lblnompro2.Visible = True
                    lblnompro2.Location = New Point(x, y + 15)
                End If
                If traecantidad = 3 Then
                    lblnompro.Visible = True
                    lblnompro.Location = New Point(x, y)
                    lblnompro2.Visible = True
                    lblnompro2.Location = New Point(x, y + 15)
                    lblnompro3.Visible = True
                    lblnompro3.Location = New Point(x, y + 30)

                End If
                If traecantidad = 4 Then
                    lblnompro.Visible = True
                    lblnompro.Location = New Point(x, y)
                    lblnompro2.Visible = True
                    lblnompro2.Location = New Point(x, y + 15)
                    lblnompro3.Visible = True
                    lblnompro3.Location = New Point(x, y + 30)
                    lblnompro4.Visible = True
                    lblnompro4.Location = New Point(x, y + 45)
                End If
                If traecantidad = 5 Then
                    lblnompro.Visible = True
                    lblnompro.Location = New Point(x, y)
                    lblnompro2.Visible = True
                    lblnompro2.Location = New Point(x, y + 15)
                    lblnompro3.Visible = True
                    lblnompro3.Location = New Point(x, y + 30)
                    lblnompro4.Visible = True
                    lblnompro4.Location = New Point(x, y + 45)
                    lblnompro5.Visible = True
                    lblnompro5.Location = New Point(x, y + 60)
                End If
                If traecantidad = 6 Then
                    lblnompro.Visible = True
                    lblnompro.Location = New Point(x, y)
                    lblnompro2.Visible = True
                    lblnompro2.Location = New Point(x, y + 15)
                    lblnompro3.Visible = True
                    lblnompro3.Location = New Point(x, y + 30)
                    lblnompro4.Visible = True
                    lblnompro4.Location = New Point(x, y + 45)
                    lblnompro5.Visible = True
                    lblnompro5.Location = New Point(x, y + 60)
                    lblnompro6.Visible = True
                    lblnompro6.Location = New Point(x, y + 75)
                End If










            End If

            If cbodatos.Text.Trim = "Nombre producto" Then
                'lblrutcli.Text = TxtClirut.Text


                Dim sql2 As String = "SELECT mae_descr from rpt_despacho_informe where ddes_rutcli= '" + TxtClirut.Text + "' and despacho = '" + txtfolio.Text.Trim() + "' "

                Dim tabla2 As DataTable = fnc.ListarTablasSQL(sql2)

                If tabla2.Rows.Count > 0 Then

                    If traecantidad = 1 Then
                        lblnompro.Text = tabla2.Rows(0)(0).ToString()

                    End If
                    If traecantidad = 2 Then
                        lblnompro.Text = tabla2.Rows(0)(0).ToString()
                        lblnompro2.Text = tabla2.Rows(1)(0).ToString()
                    End If
                    If traecantidad = 3 Then
                        lblnompro.Text = tabla2.Rows(0)(0).ToString()
                        lblnompro2.Text = tabla2.Rows(1)(0).ToString()
                        lblnompro3.Text = tabla2.Rows(2)(0).ToString()
                    End If
                    If traecantidad = 4 Then
                        lblnompro.Text = tabla2.Rows(0)(0).ToString()
                        lblnompro2.Text = tabla2.Rows(1)(0).ToString()
                        lblnompro3.Text = tabla2.Rows(2)(0).ToString()
                        lblnompro4.Text = tabla2.Rows(3)(0).ToString()
                    End If
                    If traecantidad = 5 Then
                        lblnompro.Text = tabla2.Rows(0)(0).ToString()
                        lblnompro2.Text = tabla2.Rows(1)(0).ToString()
                        lblnompro3.Text = tabla2.Rows(2)(0).ToString()
                        lblnompro4.Text = tabla2.Rows(3)(0).ToString()
                        lblnompro5.Text = tabla2.Rows(4)(0).ToString()
                    End If
                    If traecantidad = 6 Then
                        lblnompro.Text = tabla2.Rows(0)(0).ToString()
                        lblnompro2.Text = tabla2.Rows(1)(0).ToString()
                        lblnompro3.Text = tabla2.Rows(2)(0).ToString()
                        lblnompro4.Text = tabla2.Rows(3)(0).ToString()
                        lblnompro5.Text = tabla2.Rows(4)(0).ToString()
                        lblnompro6.Text = tabla2.Rows(5)(0).ToString()
                    End If




                End If






            End If
        End If
        If cbodatos.Text.Trim = "Unidades" Then
            traecanti()
            Dim sql As String = "SELECT x,y from datos_informes where rutcli= '" + TxtClirut.Text + "' and dato = '" + cbodatos.Text.Trim() + "' "

            Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

            If tabla.Rows.Count > 0 Then
                If traecantidad = 1 Then
                    lbluni.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lbluni.Location = New Point(x, y)



                End If

                If traecantidad = 2 Then
                    lbluni.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lbluni.Location = New Point(x, y)
                    lbluni2.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lbluni2.Location = New Point(x, y + 15)



                End If


                If traecantidad = 3 Then
                    lbluni.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lbluni.Location = New Point(x, y)
                    lbluni2.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lbluni2.Location = New Point(x, y + 15)
                    lbluni3.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lbluni3.Location = New Point(x, y + 30)



                End If

                If traecantidad = 4 Then
                    lbluni.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lbluni.Location = New Point(x, y)
                    lbluni2.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lbluni2.Location = New Point(x, y + 15)
                    lbluni3.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lbluni3.Location = New Point(x, y + 30)
                    lbluni4.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lbluni4.Location = New Point(x, y + 45)


                End If
                If traecantidad = 5 Then
                    lbluni.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lbluni.Location = New Point(x, y)
                    lbluni2.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lbluni2.Location = New Point(x, y + 15)
                    lbluni3.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lbluni3.Location = New Point(x, y + 30)
                    lbluni4.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lbluni4.Location = New Point(x, y + 45)
                    lbluni5.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lbluni5.Location = New Point(x, y + 60)


                End If
                If traecantidad = 6 Then
                    lbluni.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lbluni.Location = New Point(x, y)
                    lbluni2.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lbluni2.Location = New Point(x, y + 15)
                    lbluni3.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lbluni3.Location = New Point(x, y + 30)
                    lbluni4.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lbluni4.Location = New Point(x, y + 45)
                    lbluni5.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lbluni5.Location = New Point(x, y + 60)
                    lbluni6.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lbluni6.Location = New Point(x, y + 75)

                End If

            Else

                x = 111
                y = 56


                If traecantidad = 1 Then
                    lbluni.Visible = True
                    lbluni.Location = New Point(x, y)
                End If
                If traecantidad = 2 Then
                    lbluni.Visible = True
                    lbluni.Location = New Point(x, y)
                    lbluni2.Visible = True
                    lbluni2.Location = New Point(x, y + 15)
                End If
                If traecantidad = 3 Then
                    lbluni.Visible = True
                    lbluni.Location = New Point(x, y)
                    lbluni2.Visible = True
                    lbluni2.Location = New Point(x, y + 15)
                    lbluni3.Visible = True
                    lbluni3.Location = New Point(x, y + 30)

                End If
                If traecantidad = 4 Then
                    lbluni.Visible = True
                    lbluni.Location = New Point(x, y)
                    lbluni2.Visible = True
                    lbluni2.Location = New Point(x, y + 15)
                    lbluni3.Visible = True
                    lbluni3.Location = New Point(x, y + 30)
                    lbluni4.Visible = True
                    lbluni4.Location = New Point(x, y + 45)
                End If
                If traecantidad = 5 Then
                    lbluni.Visible = True
                    lbluni.Location = New Point(x, y)
                    lbluni2.Visible = True
                    lbluni2.Location = New Point(x, y + 15)
                    lbluni3.Visible = True
                    lbluni3.Location = New Point(x, y + 30)
                    lbluni4.Visible = True
                    lbluni4.Location = New Point(x, y + 45)
                    lbluni5.Visible = True
                    lbluni5.Location = New Point(x, y + 60)
                End If
                If traecantidad = 6 Then
                    lbluni.Visible = True
                    lbluni.Location = New Point(x, y)
                    lbluni2.Visible = True
                    lbluni2.Location = New Point(x, y + 15)
                    lbluni3.Visible = True
                    lbluni3.Location = New Point(x, y + 30)
                    lbluni4.Visible = True
                    lbluni4.Location = New Point(x, y + 45)
                    lbluni5.Visible = True
                    lbluni5.Location = New Point(x, y + 60)
                    lbluni6.Visible = True
                    lbluni6.Location = New Point(x, y + 75)
                End If










            End If

            If cbodatos.Text.Trim = "Unidades" Then
                'lblrutcli.Text = TxtClirut.Text


                Dim sql2 As String = "SELECT unidades from rpt_despacho_informe where ddes_rutcli= '" + TxtClirut.Text + "' and despacho = '" + txtfolio.Text.Trim() + "' "

                Dim tabla2 As DataTable = fnc.ListarTablasSQL(sql2)

                If tabla2.Rows.Count > 0 Then

                    If traecantidad = 1 Then
                        lbluni.Text = tabla2.Rows(0)(0).ToString()

                    End If
                    If traecantidad = 2 Then
                        lbluni.Text = tabla2.Rows(0)(0).ToString()
                        lbluni2.Text = tabla2.Rows(1)(0).ToString()
                    End If
                    If traecantidad = 3 Then
                        lbluni.Text = tabla2.Rows(0)(0).ToString()
                        lbluni2.Text = tabla2.Rows(1)(0).ToString()
                        lbluni3.Text = tabla2.Rows(2)(0).ToString()
                    End If
                    If traecantidad = 4 Then
                        lbluni.Text = tabla2.Rows(0)(0).ToString()
                        lbluni2.Text = tabla2.Rows(1)(0).ToString()
                        lbluni3.Text = tabla2.Rows(2)(0).ToString()
                        lbluni4.Text = tabla2.Rows(3)(0).ToString()
                    End If
                    If traecantidad = 5 Then
                        lbluni.Text = tabla2.Rows(0)(0).ToString()
                        lbluni2.Text = tabla2.Rows(1)(0).ToString()
                        lbluni3.Text = tabla2.Rows(2)(0).ToString()
                        lbluni4.Text = tabla2.Rows(3)(0).ToString()
                        lbluni5.Text = tabla2.Rows(4)(0).ToString()
                    End If
                    If traecantidad = 6 Then
                        lbluni.Text = tabla2.Rows(0)(0).ToString()
                        lbluni2.Text = tabla2.Rows(1)(0).ToString()
                        lbluni3.Text = tabla2.Rows(2)(0).ToString()
                        lbluni4.Text = tabla2.Rows(3)(0).ToString()
                        lbluni5.Text = tabla2.Rows(4)(0).ToString()
                        lbluni6.Text = tabla2.Rows(5)(0).ToString()
                    End If




                End If






            End If
        End If
        If cbodatos.Text.Trim = "Kilos" Then
            traecanti()
            Dim sql As String = "SELECT x,y from datos_informes where rutcli= '" + TxtClirut.Text + "' and dato = '" + cbodatos.Text.Trim() + "' "

            Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

            If tabla.Rows.Count > 0 Then
                If traecantidad = 1 Then
                    lblkil.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblkil.Location = New Point(x, y)



                End If

                If traecantidad = 2 Then
                    lblkil.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblkil.Location = New Point(x, y)
                    lblkil2.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblkil2.Location = New Point(x, y + 15)



                End If


                If traecantidad = 3 Then
                    lblkil.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblkil.Location = New Point(x, y)
                    lblkil2.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblkil2.Location = New Point(x, y + 15)
                    lblkil3.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblkil3.Location = New Point(x, y + 30)



                End If

                If traecantidad = 4 Then
                    lblkil.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblkil.Location = New Point(x, y)
                    lblkil2.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblkil2.Location = New Point(x, y + 15)
                    lblkil3.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblkil3.Location = New Point(x, y + 30)
                    lblkil4.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblkil4.Location = New Point(x, y + 45)


                End If
                If traecantidad = 5 Then
                    lblkil.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblkil.Location = New Point(x, y)
                    lblkil2.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblkil2.Location = New Point(x, y + 15)
                    lblkil3.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblkil3.Location = New Point(x, y + 30)
                    lblkil4.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblkil4.Location = New Point(x, y + 45)
                    lblkil5.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblkil5.Location = New Point(x, y + 60)


                End If
                If traecantidad = 6 Then
                    lblkil.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblkil.Location = New Point(x, y)
                    lblkil2.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblkil2.Location = New Point(x, y + 15)
                    lblkil3.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblkil3.Location = New Point(x, y + 30)
                    lblkil4.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblkil4.Location = New Point(x, y + 45)
                    lblkil5.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblkil5.Location = New Point(x, y + 60)
                    lblkil6.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblkil6.Location = New Point(x, y + 75)

                End If

            Else

                x = 111
                y = 56


                If traecantidad = 1 Then
                    lblkil.Visible = True
                    lblkil.Location = New Point(x, y)
                End If
                If traecantidad = 2 Then
                    lblkil.Visible = True
                    lblkil.Location = New Point(x, y)
                    lblkil2.Visible = True
                    lblkil2.Location = New Point(x, y + 15)
                End If
                If traecantidad = 3 Then
                    lblkil.Visible = True
                    lblkil.Location = New Point(x, y)
                    lblkil2.Visible = True
                    lblkil2.Location = New Point(x, y + 15)
                    lblkil3.Visible = True
                    lblkil3.Location = New Point(x, y + 30)

                End If
                If traecantidad = 4 Then
                    lblkil.Visible = True
                    lblkil.Location = New Point(x, y)
                    lblkil2.Visible = True
                    lblkil2.Location = New Point(x, y + 15)
                    lblkil3.Visible = True
                    lblkil3.Location = New Point(x, y + 30)
                    lblkil4.Visible = True
                    lblkil4.Location = New Point(x, y + 45)
                End If
                If traecantidad = 5 Then
                    lblkil.Visible = True
                    lblkil.Location = New Point(x, y)
                    lblkil2.Visible = True
                    lblkil2.Location = New Point(x, y + 15)
                    lblkil3.Visible = True
                    lblkil3.Location = New Point(x, y + 30)
                    lblkil4.Visible = True
                    lblkil4.Location = New Point(x, y + 45)
                    lblkil5.Visible = True
                    lblkil5.Location = New Point(x, y + 60)
                End If
                If traecantidad = 6 Then
                    lblkil.Visible = True
                    lblkil.Location = New Point(x, y)
                    lblkil2.Visible = True
                    lblkil2.Location = New Point(x, y + 15)
                    lblkil3.Visible = True
                    lblkil3.Location = New Point(x, y + 30)
                    lblkil4.Visible = True
                    lblkil4.Location = New Point(x, y + 45)
                    lblkil5.Visible = True
                    lblkil5.Location = New Point(x, y + 60)
                    lblkil6.Visible = True
                    lblkil6.Location = New Point(x, y + 75)
                End If










            End If

            If cbodatos.Text.Trim = "Kilos" Then
                'lblrutcli.Text = TxtClirut.Text


                Dim sql2 As String = "SELECT kilos from rpt_despacho_informe where ddes_rutcli= '" + TxtClirut.Text + "' and despacho = '" + txtfolio.Text.Trim() + "' "

                Dim tabla2 As DataTable = fnc.ListarTablasSQL(sql2)

                If tabla2.Rows.Count > 0 Then

                    If traecantidad = 1 Then
                        lblkil.Text = tabla2.Rows(0)(0).ToString()

                    End If
                    If traecantidad = 2 Then
                        lblkil.Text = tabla2.Rows(0)(0).ToString()
                        lblkil2.Text = tabla2.Rows(1)(0).ToString()
                    End If
                    If traecantidad = 3 Then
                        lblkil.Text = tabla2.Rows(0)(0).ToString()
                        lblkil2.Text = tabla2.Rows(1)(0).ToString()
                        lblkil3.Text = tabla2.Rows(2)(0).ToString()
                    End If
                    If traecantidad = 4 Then
                        lblkil.Text = tabla2.Rows(0)(0).ToString()
                        lblkil2.Text = tabla2.Rows(1)(0).ToString()
                        lblkil3.Text = tabla2.Rows(2)(0).ToString()
                        lblkil4.Text = tabla2.Rows(3)(0).ToString()
                    End If
                    If traecantidad = 5 Then
                        lblkil.Text = tabla2.Rows(0)(0).ToString()
                        lblkil2.Text = tabla2.Rows(1)(0).ToString()
                        lblkil3.Text = tabla2.Rows(2)(0).ToString()
                        lblkil4.Text = tabla2.Rows(3)(0).ToString()
                        lblkil5.Text = tabla2.Rows(4)(0).ToString()
                    End If
                    If traecantidad = 6 Then
                        lblkil.Text = tabla2.Rows(0)(0).ToString()
                        lblkil2.Text = tabla2.Rows(1)(0).ToString()
                        lblkil3.Text = tabla2.Rows(2)(0).ToString()
                        lblkil4.Text = tabla2.Rows(3)(0).ToString()
                        lblkil5.Text = tabla2.Rows(4)(0).ToString()
                        lblkil6.Text = tabla2.Rows(5)(0).ToString()
                    End If




                End If






            End If
        End If

    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        If y >= 56 Then

            If cbodatos.Text.Trim = "Despacho" Then

                y = y - 1
                lbldespacho.Location = New Point(x, y)
                Graposicion()

            End If
            If cbodatos.Text.Trim = "Rut cliente" Then

                y = y - 1
                lblrutcli.Location = New Point(x, y)
                Graposicion()

            End If
            If cbodatos.Text.Trim = "Nombre cliente" Then

                y = y - 1
                lblnomcli.Location = New Point(x, y)
                Graposicion()

            End If
            If cbodatos.Text.Trim = "Fecha" Then

                y = y - 1
                lblfecha.Location = New Point(x, y)
                Graposicion()

            End If
            If cbodatos.Text.Trim = "Giro" Then

                y = y - 1
                lblgiro.Location = New Point(x, y)
                Graposicion()

            End If
            If cbodatos.Text.Trim = "Direccion" Then

                y = y - 1
                lbldireccion.Location = New Point(x, y)
                Graposicion()

            End If
            If cbodatos.Text.Trim = "Comuna" Then

                y = y - 1
                lblcomuna.Location = New Point(x, y)
                Graposicion()

            End If
            If cbodatos.Text.Trim = "Nombre chofer" Then

                y = y - 1
                lblnomcho.Location = New Point(x, y)
                Graposicion()

            End If
            If cbodatos.Text.Trim = "Rut chofer" Then

                y = y - 1
                lblrutcho.Location = New Point(x, y)
                Graposicion()

            End If
            If cbodatos.Text.Trim = "Patente" Then

                y = y - 1
                lblpatente.Location = New Point(x, y)
                Graposicion()

            End If
            If cbodatos.Text.Trim = "Observacion" Then

                y = y - 1
                lblobs.Location = New Point(x, y)
                Graposicion()

            End If
            If cbodatos.Text.Trim = "Destino" Then

                y = y - 1
                lbldestino.Location = New Point(x, y)
                lbldestino2.Location = New Point(x, y + 15)
                lbldestino3.Location = New Point(x, y + 30)
                Graposicion()

            End If
            If cbodatos.Text.Trim = "Codigo producto" Then

                y = y - 1


                If traecantidad = 1 Then

                    lblcodpro.Location = New Point(x, y)
                    Graposicion()
                End If
                If traecantidad = 2 Then

                    lblcodpro.Location = New Point(x, y)
                    lblcodpro2.Location = New Point(x, y + 15)
                    Graposicion()
                End If
                If traecantidad = 3 Then

                    lblcodpro.Location = New Point(x, y)
                    lblcodpro2.Location = New Point(x, y + 15)
                    lblcodpro3.Location = New Point(x, y + 30)
                    Graposicion()
                End If

                If traecantidad = 4 Then

                    lblcodpro.Location = New Point(x, y)
                    lblcodpro2.Location = New Point(x, y + 15)
                    lblcodpro3.Location = New Point(x, y + 30)
                    lblcodpro4.Location = New Point(x, y + 45)
                    Graposicion()
                End If
                If traecantidad = 5 Then

                    lblcodpro.Location = New Point(x, y)
                    lblcodpro2.Location = New Point(x, y + 15)
                    lblcodpro3.Location = New Point(x, y + 30)
                    lblcodpro4.Location = New Point(x, y + 45)
                    lblcodpro5.Location = New Point(x, y + 60)
                    Graposicion()
                End If
                If traecantidad = 6 Then

                    lblcodpro.Location = New Point(x, y)
                    lblcodpro2.Location = New Point(x, y + 15)
                    lblcodpro3.Location = New Point(x, y + 30)
                    lblcodpro4.Location = New Point(x, y + 45)
                    lblcodpro5.Location = New Point(x, y + 60)
                    lblcodpro6.Location = New Point(x, y + 75)
                    Graposicion()
                End If
                If traecantidad = 7 Then
                    lblcodpro.Location = New Point(x, y)
                    lblcodpro2.Location = New Point(x, y + 15)
                    lblcodpro3.Location = New Point(x, y + 30)
                    lblcodpro4.Location = New Point(x, y + 45)
                    lblcodpro5.Location = New Point(x, y + 60)
                    lblcodpro6.Location = New Point(x, y + 75)
                    lblcodpro7.Location = New Point(x, y + 90)
                    Graposicion()
                End If
                If traecantidad = 8 Then
                    lblcodpro.Location = New Point(x, y)
                    lblcodpro2.Location = New Point(x, y + 15)
                    lblcodpro3.Location = New Point(x, y + 30)
                    lblcodpro4.Location = New Point(x, y + 45)
                    lblcodpro5.Location = New Point(x, y + 60)
                    lblcodpro6.Location = New Point(x, y + 75)
                    lblcodpro7.Location = New Point(x, y + 90)
                    lblcodpro8.Location = New Point(x, y + 105)
                    Graposicion()
                End If
                If traecantidad = 9 Then
                    lblcodpro.Location = New Point(x, y)
                    lblcodpro2.Location = New Point(x, y + 15)
                    lblcodpro3.Location = New Point(x, y + 30)
                    lblcodpro4.Location = New Point(x, y + 45)
                    lblcodpro5.Location = New Point(x, y + 60)
                    lblcodpro6.Location = New Point(x, y + 75)
                    lblcodpro7.Location = New Point(x, y + 90)
                    lblcodpro8.Location = New Point(x, y + 105)
                    lblcodpro9.Location = New Point(x, y + 120)
                    Graposicion()
                End If
                If traecantidad = 10 Then
                    lblcodpro.Location = New Point(x, y)
                    lblcodpro2.Location = New Point(x, y + 15)
                    lblcodpro3.Location = New Point(x, y + 30)
                    lblcodpro4.Location = New Point(x, y + 45)
                    lblcodpro5.Location = New Point(x, y + 60)
                    lblcodpro6.Location = New Point(x, y + 75)
                    lblcodpro7.Location = New Point(x, y + 90)
                    lblcodpro8.Location = New Point(x, y + 105)
                    lblcodpro9.Location = New Point(x, y + 120)
                    lblcodpro10.Location = New Point(x, y + 135)
                    Graposicion()
                End If
                If traecantidad = 11 Then
                    lblcodpro.Location = New Point(x, y)
                    lblcodpro2.Location = New Point(x, y + 15)
                    lblcodpro3.Location = New Point(x, y + 30)
                    lblcodpro4.Location = New Point(x, y + 45)
                    lblcodpro5.Location = New Point(x, y + 60)
                    lblcodpro6.Location = New Point(x, y + 75)
                    lblcodpro7.Location = New Point(x, y + 90)
                    lblcodpro8.Location = New Point(x, y + 105)
                    lblcodpro9.Location = New Point(x, y + 120)
                    lblcodpro10.Location = New Point(x, y + 135)
                    lblcodpro11.Location = New Point(x, y + 150)
                    Graposicion()
                End If
                If traecantidad = 12 Then
                    lblcodpro.Location = New Point(x, y)
                    lblcodpro2.Location = New Point(x, y + 15)
                    lblcodpro3.Location = New Point(x, y + 30)
                    lblcodpro4.Location = New Point(x, y + 45)
                    lblcodpro5.Location = New Point(x, y + 60)
                    lblcodpro6.Location = New Point(x, y + 75)
                    lblcodpro7.Location = New Point(x, y + 90)
                    lblcodpro8.Location = New Point(x, y + 105)
                    lblcodpro9.Location = New Point(x, y + 120)
                    lblcodpro10.Location = New Point(x, y + 135)
                    lblcodpro11.Location = New Point(x, y + 150)
                    lblcodpro12.Location = New Point(x, y + 165)
                    Graposicion()
                End If
            End If

            If cbodatos.Text.Trim = "Nombre producto" Then

                y = y - 1


                If traecantidad = 1 Then

                    lblnompro.Location = New Point(x, y)
                    Graposicion()
                End If
                If traecantidad = 2 Then

                    lblnompro.Location = New Point(x, y)
                    lblnompro2.Location = New Point(x, y + 15)
                    Graposicion()
                End If
                If traecantidad = 3 Then

                    lblnompro.Location = New Point(x, y)
                    lblnompro2.Location = New Point(x, y + 15)
                    lblnompro3.Location = New Point(x, y + 30)
                    Graposicion()
                End If

                If traecantidad = 4 Then

                    lblnompro.Location = New Point(x, y)
                    lblnompro2.Location = New Point(x, y + 15)
                    lblnompro3.Location = New Point(x, y + 30)
                    lblnompro4.Location = New Point(x, y + 45)
                    Graposicion()
                End If
                If traecantidad = 5 Then

                    lblnompro.Location = New Point(x, y)
                    lblnompro2.Location = New Point(x, y + 15)
                    lblnompro3.Location = New Point(x, y + 30)
                    lblnompro4.Location = New Point(x, y + 45)
                    lblnompro5.Location = New Point(x, y + 60)
                    Graposicion()
                End If
                If traecantidad = 6 Then

                    lblnompro.Location = New Point(x, y)
                    lblnompro2.Location = New Point(x, y + 15)
                    lblnompro3.Location = New Point(x, y + 30)
                    lblnompro4.Location = New Point(x, y + 45)
                    lblnompro5.Location = New Point(x, y + 60)
                    lblnompro6.Location = New Point(x, y + 75)
                    Graposicion()
                End If
                If traecantidad = 7 Then
                    lblnompro.Location = New Point(x, y)
                    lblnompro2.Location = New Point(x, y + 15)
                    lblnompro3.Location = New Point(x, y + 30)
                    lblnompro4.Location = New Point(x, y + 45)
                    lblnompro5.Location = New Point(x, y + 60)
                    lblnompro6.Location = New Point(x, y + 75)
                    lblnompro7.Location = New Point(x, y + 90)
                    Graposicion()
                End If
                If traecantidad = 8 Then
                    lblnompro.Location = New Point(x, y)
                    lblnompro2.Location = New Point(x, y + 15)
                    lblnompro3.Location = New Point(x, y + 30)
                    lblnompro4.Location = New Point(x, y + 45)
                    lblnompro5.Location = New Point(x, y + 60)
                    lblnompro6.Location = New Point(x, y + 75)
                    lblnompro7.Location = New Point(x, y + 90)
                    lblnompro8.Location = New Point(x, y + 105)
                    Graposicion()
                End If
                If traecantidad = 9 Then
                    lblnompro.Location = New Point(x, y)
                    lblnompro2.Location = New Point(x, y + 15)
                    lblnompro3.Location = New Point(x, y + 30)
                    lblnompro4.Location = New Point(x, y + 45)
                    lblnompro5.Location = New Point(x, y + 60)
                    lblnompro6.Location = New Point(x, y + 75)
                    lblnompro7.Location = New Point(x, y + 90)
                    lblnompro8.Location = New Point(x, y + 105)
                    lblnompro9.Location = New Point(x, y + 120)
                    Graposicion()
                End If
                If traecantidad = 10 Then
                    lblnompro.Location = New Point(x, y)
                    lblnompro2.Location = New Point(x, y + 15)
                    lblnompro3.Location = New Point(x, y + 30)
                    lblnompro4.Location = New Point(x, y + 45)
                    lblnompro5.Location = New Point(x, y + 60)
                    lblnompro6.Location = New Point(x, y + 75)
                    lblnompro7.Location = New Point(x, y + 90)
                    lblnompro8.Location = New Point(x, y + 105)
                    lblnompro9.Location = New Point(x, y + 120)
                    lblnompro10.Location = New Point(x, y + 135)
                    Graposicion()
                End If
                If traecantidad = 11 Then
                    lblnompro.Location = New Point(x, y)
                    lblnompro2.Location = New Point(x, y + 15)
                    lblnompro3.Location = New Point(x, y + 30)
                    lblnompro4.Location = New Point(x, y + 45)
                    lblnompro5.Location = New Point(x, y + 60)
                    lblnompro6.Location = New Point(x, y + 75)
                    lblnompro7.Location = New Point(x, y + 90)
                    lblnompro8.Location = New Point(x, y + 105)
                    lblnompro9.Location = New Point(x, y + 120)
                    lblnompro10.Location = New Point(x, y + 135)
                    lblnompro11.Location = New Point(x, y + 150)
                    Graposicion()
                End If
                If traecantidad = 12 Then
                    lblnompro.Location = New Point(x, y)
                    lblnompro2.Location = New Point(x, y + 15)
                    lblnompro3.Location = New Point(x, y + 30)
                    lblnompro4.Location = New Point(x, y + 45)
                    lblnompro5.Location = New Point(x, y + 60)
                    lblnompro6.Location = New Point(x, y + 75)
                    lblnompro7.Location = New Point(x, y + 90)
                    lblnompro8.Location = New Point(x, y + 105)
                    lblnompro9.Location = New Point(x, y + 120)
                    lblnompro10.Location = New Point(x, y + 135)
                    lblnompro11.Location = New Point(x, y + 150)
                    lblnompro12.Location = New Point(x, y + 165)
                    Graposicion()
                End If
            End If

            If cbodatos.Text.Trim = "Unidades" Then

                y = y - 1


                If traecantidad = 1 Then

                    lbluni.Location = New Point(x, y)
                    Graposicion()
                End If
                If traecantidad = 2 Then

                    lbluni.Location = New Point(x, y)
                    lbluni2.Location = New Point(x, y + 15)
                    Graposicion()
                End If
                If traecantidad = 3 Then

                    lbluni.Location = New Point(x, y)
                    lbluni2.Location = New Point(x, y + 15)
                    lbluni3.Location = New Point(x, y + 30)
                    Graposicion()
                End If

                If traecantidad = 4 Then

                    lbluni.Location = New Point(x, y)
                    lbluni2.Location = New Point(x, y + 15)
                    lbluni3.Location = New Point(x, y + 30)
                    lbluni4.Location = New Point(x, y + 45)
                    Graposicion()
                End If
                If traecantidad = 5 Then

                    lbluni.Location = New Point(x, y)
                    lbluni2.Location = New Point(x, y + 15)
                    lbluni3.Location = New Point(x, y + 30)
                    lbluni4.Location = New Point(x, y + 45)
                    lbluni5.Location = New Point(x, y + 60)
                    Graposicion()
                End If
                If traecantidad = 6 Then

                    lbluni.Location = New Point(x, y)
                    lbluni2.Location = New Point(x, y + 15)
                    lbluni3.Location = New Point(x, y + 30)
                    lbluni4.Location = New Point(x, y + 45)
                    lbluni5.Location = New Point(x, y + 60)
                    lbluni6.Location = New Point(x, y + 75)
                    Graposicion()
                End If
                If traecantidad = 7 Then
                    lbluni.Location = New Point(x, y)
                    lbluni2.Location = New Point(x, y + 15)
                    lbluni3.Location = New Point(x, y + 30)
                    lbluni4.Location = New Point(x, y + 45)
                    lbluni5.Location = New Point(x, y + 60)
                    lbluni6.Location = New Point(x, y + 75)
                    lbluni7.Location = New Point(x, y + 90)
                    Graposicion()
                End If
                If traecantidad = 8 Then
                    lbluni.Location = New Point(x, y)
                    lbluni2.Location = New Point(x, y + 15)
                    lbluni3.Location = New Point(x, y + 30)
                    lbluni4.Location = New Point(x, y + 45)
                    lbluni5.Location = New Point(x, y + 60)
                    lbluni6.Location = New Point(x, y + 75)
                    lbluni7.Location = New Point(x, y + 90)
                    lbluni8.Location = New Point(x, y + 105)
                    Graposicion()
                End If
                If traecantidad = 9 Then
                    lbluni.Location = New Point(x, y)
                    lbluni2.Location = New Point(x, y + 15)
                    lbluni3.Location = New Point(x, y + 30)
                    lbluni4.Location = New Point(x, y + 45)
                    lbluni5.Location = New Point(x, y + 60)
                    lbluni6.Location = New Point(x, y + 75)
                    lbluni7.Location = New Point(x, y + 90)
                    lbluni8.Location = New Point(x, y + 105)
                    lbluni9.Location = New Point(x, y + 120)
                    Graposicion()
                End If
                If traecantidad = 10 Then
                    lbluni.Location = New Point(x, y)
                    lbluni2.Location = New Point(x, y + 15)
                    lbluni3.Location = New Point(x, y + 30)
                    lbluni4.Location = New Point(x, y + 45)
                    lbluni5.Location = New Point(x, y + 60)
                    lbluni6.Location = New Point(x, y + 75)
                    lbluni7.Location = New Point(x, y + 90)
                    lbluni8.Location = New Point(x, y + 105)
                    lbluni9.Location = New Point(x, y + 120)
                    lbluni10.Location = New Point(x, y + 120)
                    Graposicion()
                End If
                If traecantidad = 11 Then
                    lbluni.Location = New Point(x, y)
                    lbluni2.Location = New Point(x, y + 15)
                    lbluni3.Location = New Point(x, y + 30)
                    lbluni4.Location = New Point(x, y + 45)
                    lbluni5.Location = New Point(x, y + 60)
                    lbluni6.Location = New Point(x, y + 75)
                    lbluni7.Location = New Point(x, y + 90)
                    lbluni8.Location = New Point(x, y + 105)
                    lbluni9.Location = New Point(x, y + 120)
                    lbluni10.Location = New Point(x, y + 120)
                    lbluni11.Location = New Point(x, y + 120)
                    Graposicion()
                End If
                If traecantidad = 12 Then
                    lbluni.Location = New Point(x, y)
                    lbluni2.Location = New Point(x, y + 15)
                    lbluni3.Location = New Point(x, y + 30)
                    lbluni4.Location = New Point(x, y + 45)
                    lbluni5.Location = New Point(x, y + 60)
                    lbluni6.Location = New Point(x, y + 75)
                    lbluni7.Location = New Point(x, y + 90)
                    lbluni8.Location = New Point(x, y + 105)
                    lbluni9.Location = New Point(x, y + 120)
                    lbluni10.Location = New Point(x, y + 120)
                    lbluni11.Location = New Point(x, y + 120)
                    lbluni12.Location = New Point(x, y + 120)
                    Graposicion()
                End If
            End If
            If cbodatos.Text.Trim = "Kilos" Then

                y = y - 1


                If traecantidad = 1 Then

                    lblkil.Location = New Point(x, y)
                    Graposicion()
                End If
                If traecantidad = 2 Then

                    lblkil.Location = New Point(x, y)
                    lblkil2.Location = New Point(x, y + 15)
                    Graposicion()
                End If
                If traecantidad = 3 Then

                    lblkil.Location = New Point(x, y)
                    lblkil2.Location = New Point(x, y + 15)
                    lblkil3.Location = New Point(x, y + 30)
                    Graposicion()
                End If

                If traecantidad = 4 Then

                    lblkil.Location = New Point(x, y)
                    lblkil2.Location = New Point(x, y + 15)
                    lblkil3.Location = New Point(x, y + 30)
                    lblkil4.Location = New Point(x, y + 45)
                    Graposicion()
                End If
                If traecantidad = 5 Then

                    lblkil.Location = New Point(x, y)
                    lblkil2.Location = New Point(x, y + 15)
                    lblkil3.Location = New Point(x, y + 30)
                    lblkil4.Location = New Point(x, y + 45)
                    lblkil5.Location = New Point(x, y + 60)
                    Graposicion()
                End If
                If traecantidad = 6 Then

                    lblkil.Location = New Point(x, y)
                    lblkil2.Location = New Point(x, y + 15)
                    lblkil3.Location = New Point(x, y + 30)
                    lblkil4.Location = New Point(x, y + 45)
                    lblkil5.Location = New Point(x, y + 60)
                    lblkil6.Location = New Point(x, y + 75)
                    Graposicion()
                End If
                If traecantidad = 7 Then
                    lblkil.Location = New Point(x, y)
                    lblkil2.Location = New Point(x, y + 15)
                    lblkil3.Location = New Point(x, y + 30)
                    lblkil4.Location = New Point(x, y + 45)
                    lblkil5.Location = New Point(x, y + 60)
                    lblkil6.Location = New Point(x, y + 75)
                    lblkil7.Location = New Point(x, y + 90)
                    Graposicion()
                End If
                If traecantidad = 8 Then
                    lblkil.Location = New Point(x, y)
                    lblkil2.Location = New Point(x, y + 15)
                    lblkil3.Location = New Point(x, y + 30)
                    lblkil4.Location = New Point(x, y + 45)
                    lblkil5.Location = New Point(x, y + 60)
                    lblkil6.Location = New Point(x, y + 75)
                    lblkil7.Location = New Point(x, y + 90)
                    lblkil8.Location = New Point(x, y + 105)
                    Graposicion()
                End If
                If traecantidad = 9 Then
                    lblkil.Location = New Point(x, y)
                    lblkil2.Location = New Point(x, y + 15)
                    lblkil3.Location = New Point(x, y + 30)
                    lblkil4.Location = New Point(x, y + 45)
                    lblkil5.Location = New Point(x, y + 60)
                    lblkil6.Location = New Point(x, y + 75)
                    lblkil7.Location = New Point(x, y + 90)
                    lblkil8.Location = New Point(x, y + 105)
                    lblkil9.Location = New Point(x, y + 120)
                    Graposicion()
                End If
                If traecantidad = 10 Then
                    lblkil.Location = New Point(x, y)
                    lblkil2.Location = New Point(x, y + 15)
                    lblkil3.Location = New Point(x, y + 30)
                    lblkil4.Location = New Point(x, y + 45)
                    lblkil5.Location = New Point(x, y + 60)
                    lblkil6.Location = New Point(x, y + 75)
                    lblkil7.Location = New Point(x, y + 90)
                    lblkil8.Location = New Point(x, y + 105)
                    lblkil9.Location = New Point(x, y + 120)
                    lblkil10.Location = New Point(x, y + 135)
                    Graposicion()
                End If
                If traecantidad = 11 Then
                    lblkil.Location = New Point(x, y)
                    lblkil2.Location = New Point(x, y + 15)
                    lblkil3.Location = New Point(x, y + 30)
                    lblkil4.Location = New Point(x, y + 45)
                    lblkil5.Location = New Point(x, y + 60)
                    lblkil6.Location = New Point(x, y + 75)
                    lblkil7.Location = New Point(x, y + 90)
                    lblkil8.Location = New Point(x, y + 105)
                    lblkil9.Location = New Point(x, y + 120)
                    lblkil10.Location = New Point(x, y + 135)
                    lblkil11.Location = New Point(x, y + 150)
                    Graposicion()
                End If
                If traecantidad = 12 Then
                    lblkil.Location = New Point(x, y)
                    lblkil2.Location = New Point(x, y + 15)
                    lblkil3.Location = New Point(x, y + 30)
                    lblkil4.Location = New Point(x, y + 45)
                    lblkil5.Location = New Point(x, y + 60)
                    lblkil6.Location = New Point(x, y + 75)
                    lblkil7.Location = New Point(x, y + 90)
                    lblkil8.Location = New Point(x, y + 105)
                    lblkil9.Location = New Point(x, y + 120)
                    lblkil10.Location = New Point(x, y + 135)
                    lblkil11.Location = New Point(x, y + 150)
                    lblkil12.Location = New Point(x, y + 165)
                    Graposicion()
                End If
            End If

        End If

    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        If y <= 848 Then

            If cbodatos.Text.Trim = "Despacho" Then

                y = y + 1
                lbldespacho.Location = New Point(x, y)
                Graposicion()

            End If
            If cbodatos.Text.Trim = "Rut cliente" Then

                y = y + 1
                lblrutcli.Location = New Point(x, y)
                Graposicion()

            End If
            If cbodatos.Text.Trim = "Nombre cliente" Then

                y = y + 1
                lblnomcli.Location = New Point(x, y)
                Graposicion()

            End If
            If cbodatos.Text.Trim = "Fecha" Then

                y = y + 1
                lblfecha.Location = New Point(x, y)
                Graposicion()

            End If
            If cbodatos.Text.Trim = "Giro" Then

                y = y + 1
                lblgiro.Location = New Point(x, y)
                Graposicion()

            End If
            If cbodatos.Text.Trim = "Direccion" Then

                y = y + 1
                lbldireccion.Location = New Point(x, y)
                Graposicion()

            End If
            If cbodatos.Text.Trim = "Comuna" Then

                y = y + 1
                lblcomuna.Location = New Point(x, y)
                Graposicion()

            End If
            If cbodatos.Text.Trim = "Nombre chofer" Then

                y = y + 1
                lblnomcho.Location = New Point(x, y)
                Graposicion()

            End If
            If cbodatos.Text.Trim = "Rut chofer" Then

                y = y + 1
                lblrutcho.Location = New Point(x, y)
                Graposicion()

            End If
            If cbodatos.Text.Trim = "Patente" Then

                y = y + 1
                lblpatente.Location = New Point(x, y)
                Graposicion()

            End If
            If cbodatos.Text.Trim = "Observacion" Then

                y = y + 1
                lblobs.Location = New Point(x, y)
                Graposicion()

            End If
            If cbodatos.Text.Trim = "Destino" Then

                y = y + 1
                lbldestino.Location = New Point(x, y)
                lbldestino2.Location = New Point(x, y + 15)
                lbldestino3.Location = New Point(x, y + 30)
                Graposicion()
            End If

            If cbodatos.Text.Trim = "Codigo producto" Then

                y = y + 1


                If traecantidad = 1 Then
                    lblcodpro.Location = New Point(x, y)
                    Graposicion()
                End If

                If traecantidad = 2 Then
                    lblcodpro.Location = New Point(x, y)
                    lblcodpro2.Location = New Point(x, y + 15)
                    Graposicion()
                End If

                If traecantidad = 3 Then
                    lblcodpro.Location = New Point(x, y)
                    lblcodpro2.Location = New Point(x, y + 15)
                    lblcodpro3.Location = New Point(x, y + 30)
                    Graposicion()
                End If
                If traecantidad = 4 Then
                    lblcodpro.Location = New Point(x, y)
                    lblcodpro2.Location = New Point(x, y + 15)
                    lblcodpro3.Location = New Point(x, y + 30)
                    lblcodpro4.Location = New Point(x, y + 45)
                    Graposicion()
                End If
                If traecantidad = 5 Then
                    lblcodpro.Location = New Point(x, y)
                    lblcodpro2.Location = New Point(x, y + 15)
                    lblcodpro3.Location = New Point(x, y + 30)
                    lblcodpro4.Location = New Point(x, y + 45)
                    lblcodpro5.Location = New Point(x, y + 60)
                    Graposicion()
                End If

                If traecantidad = 6 Then
                    lblcodpro.Location = New Point(x, y)
                    lblcodpro2.Location = New Point(x, y + 15)
                    lblcodpro3.Location = New Point(x, y + 30)
                    lblcodpro4.Location = New Point(x, y + 45)
                    lblcodpro5.Location = New Point(x, y + 60)
                    lblcodpro6.Location = New Point(x, y + 75)
                    Graposicion()
                End If

                If traecantidad = 7 Then
                    lblcodpro.Location = New Point(x, y)
                    lblcodpro2.Location = New Point(x, y + 15)
                    lblcodpro3.Location = New Point(x, y + 30)
                    lblcodpro4.Location = New Point(x, y + 45)
                    lblcodpro5.Location = New Point(x, y + 60)
                    lblcodpro6.Location = New Point(x, y + 75)
                    lblcodpro7.Location = New Point(x, y + 90)
                    Graposicion()
                End If

                If traecantidad = 8 Then
                    lblcodpro.Location = New Point(x, y)
                    lblcodpro2.Location = New Point(x, y + 15)
                    lblcodpro3.Location = New Point(x, y + 30)
                    lblcodpro4.Location = New Point(x, y + 45)
                    lblcodpro5.Location = New Point(x, y + 60)
                    lblcodpro6.Location = New Point(x, y + 75)
                    lblcodpro7.Location = New Point(x, y + 90)
                    lblcodpro8.Location = New Point(x, y + 105)
                    Graposicion()
                End If

                If traecantidad = 9 Then
                    lblcodpro.Location = New Point(x, y)
                    lblcodpro2.Location = New Point(x, y + 15)
                    lblcodpro3.Location = New Point(x, y + 30)
                    lblcodpro4.Location = New Point(x, y + 45)
                    lblcodpro5.Location = New Point(x, y + 60)
                    lblcodpro6.Location = New Point(x, y + 75)
                    lblcodpro7.Location = New Point(x, y + 90)
                    lblcodpro8.Location = New Point(x, y + 105)
                    lblcodpro9.Location = New Point(x, y + 120)
                    Graposicion()
                End If

                If traecantidad = 10 Then
                    lblcodpro.Location = New Point(x, y)
                    lblcodpro2.Location = New Point(x, y + 15)
                    lblcodpro3.Location = New Point(x, y + 30)
                    lblcodpro4.Location = New Point(x, y + 45)
                    lblcodpro5.Location = New Point(x, y + 60)
                    lblcodpro6.Location = New Point(x, y + 75)
                    lblcodpro7.Location = New Point(x, y + 90)
                    lblcodpro8.Location = New Point(x, y + 105)
                    lblcodpro9.Location = New Point(x, y + 120)
                    lblcodpro10.Location = New Point(x, y + 135)
                    Graposicion()
                End If

                If traecantidad = 11 Then
                    lblcodpro.Location = New Point(x, y)
                    lblcodpro2.Location = New Point(x, y + 15)
                    lblcodpro3.Location = New Point(x, y + 30)
                    lblcodpro4.Location = New Point(x, y + 45)
                    lblcodpro5.Location = New Point(x, y + 60)
                    lblcodpro6.Location = New Point(x, y + 75)
                    lblcodpro7.Location = New Point(x, y + 90)
                    lblcodpro8.Location = New Point(x, y + 105)
                    lblcodpro9.Location = New Point(x, y + 120)
                    lblcodpro10.Location = New Point(x, y + 135)
                    lblcodpro11.Location = New Point(x, y + 150)
                    Graposicion()
                End If

                If traecantidad = 12 Then
                    lblcodpro.Location = New Point(x, y)
                    lblcodpro2.Location = New Point(x, y + 15)
                    lblcodpro3.Location = New Point(x, y + 30)
                    lblcodpro4.Location = New Point(x, y + 45)
                    lblcodpro5.Location = New Point(x, y + 60)
                    lblcodpro6.Location = New Point(x, y + 75)
                    lblcodpro7.Location = New Point(x, y + 90)
                    lblcodpro8.Location = New Point(x, y + 105)
                    lblcodpro9.Location = New Point(x, y + 120)
                    lblcodpro10.Location = New Point(x, y + 135)
                    lblcodpro11.Location = New Point(x, y + 150)
                    lblcodpro12.Location = New Point(x, y + 165)
                    Graposicion()
                End If




            End If

            If cbodatos.Text.Trim = "Nombre producto" Then

                y = y + 1
                If traecantidad = 1 Then

                    lblnompro.Location = New Point(x, y)
                    Graposicion()
                End If
                If traecantidad = 2 Then

                    lblnompro.Location = New Point(x, y)
                    lblnompro2.Location = New Point(x, y + 15)
                    Graposicion()
                End If
                If traecantidad = 3 Then

                    lblnompro.Location = New Point(x, y)
                    lblnompro2.Location = New Point(x, y + 15)
                    lblnompro3.Location = New Point(x, y + 30)
                    Graposicion()
                End If

                If traecantidad = 4 Then

                    lblnompro.Location = New Point(x, y)
                    lblnompro2.Location = New Point(x, y + 15)
                    lblnompro3.Location = New Point(x, y + 30)
                    lblnompro4.Location = New Point(x, y + 45)
                    Graposicion()
                End If
                If traecantidad = 5 Then

                    lblnompro.Location = New Point(x, y)
                    lblnompro2.Location = New Point(x, y + 15)
                    lblnompro3.Location = New Point(x, y + 30)
                    lblnompro4.Location = New Point(x, y + 45)
                    lblnompro5.Location = New Point(x, y + 60)
                    Graposicion()
                End If
                If traecantidad = 6 Then

                    lblnompro.Location = New Point(x, y)
                    lblnompro2.Location = New Point(x, y + 15)
                    lblnompro3.Location = New Point(x, y + 30)
                    lblnompro4.Location = New Point(x, y + 45)
                    lblnompro5.Location = New Point(x, y + 60)
                    lblnompro6.Location = New Point(x, y + 75)
                    Graposicion()
                End If

                If traecantidad = 7 Then
                    lblnompro.Location = New Point(x, y)
                    lblnompro2.Location = New Point(x, y + 15)
                    lblnompro3.Location = New Point(x, y + 30)
                    lblnompro4.Location = New Point(x, y + 45)
                    lblnompro5.Location = New Point(x, y + 60)
                    lblnompro6.Location = New Point(x, y + 75)
                    lblnompro7.Location = New Point(x, y + 90)
                    Graposicion()
                End If
                If traecantidad = 8 Then
                    lblnompro.Location = New Point(x, y)
                    lblnompro2.Location = New Point(x, y + 15)
                    lblnompro3.Location = New Point(x, y + 30)
                    lblnompro4.Location = New Point(x, y + 45)
                    lblnompro5.Location = New Point(x, y + 60)
                    lblnompro6.Location = New Point(x, y + 75)
                    lblnompro7.Location = New Point(x, y + 90)
                    lblnompro8.Location = New Point(x, y + 105)
                    Graposicion()
                End If
                If traecantidad = 9 Then
                    lblnompro.Location = New Point(x, y)
                    lblnompro2.Location = New Point(x, y + 15)
                    lblnompro3.Location = New Point(x, y + 30)
                    lblnompro4.Location = New Point(x, y + 45)
                    lblnompro5.Location = New Point(x, y + 60)
                    lblnompro6.Location = New Point(x, y + 75)
                    lblnompro7.Location = New Point(x, y + 90)
                    lblnompro8.Location = New Point(x, y + 105)
                    lblnompro9.Location = New Point(x, y + 120)
                    Graposicion()
                End If
                If traecantidad = 10 Then
                    lblnompro.Location = New Point(x, y)
                    lblnompro2.Location = New Point(x, y + 15)
                    lblnompro3.Location = New Point(x, y + 30)
                    lblnompro4.Location = New Point(x, y + 45)
                    lblnompro5.Location = New Point(x, y + 60)
                    lblnompro6.Location = New Point(x, y + 75)
                    lblnompro7.Location = New Point(x, y + 90)
                    lblnompro8.Location = New Point(x, y + 105)
                    lblnompro9.Location = New Point(x, y + 120)
                    lblnompro10.Location = New Point(x, y + 135)
                    Graposicion()
                End If
                If traecantidad = 11 Then
                    lblnompro.Location = New Point(x, y)
                    lblnompro2.Location = New Point(x, y + 15)
                    lblnompro3.Location = New Point(x, y + 30)
                    lblnompro4.Location = New Point(x, y + 45)
                    lblnompro5.Location = New Point(x, y + 60)
                    lblnompro6.Location = New Point(x, y + 75)
                    lblnompro7.Location = New Point(x, y + 90)
                    lblnompro8.Location = New Point(x, y + 105)
                    lblnompro9.Location = New Point(x, y + 120)
                    lblnompro10.Location = New Point(x, y + 135)
                    lblnompro11.Location = New Point(x, y + 150)
                    Graposicion()
                End If
                If traecantidad = 12 Then
                    lblnompro.Location = New Point(x, y)
                    lblnompro2.Location = New Point(x, y + 15)
                    lblnompro3.Location = New Point(x, y + 30)
                    lblnompro4.Location = New Point(x, y + 45)
                    lblnompro5.Location = New Point(x, y + 60)
                    lblnompro6.Location = New Point(x, y + 75)
                    lblnompro7.Location = New Point(x, y + 90)
                    lblnompro8.Location = New Point(x, y + 105)
                    lblnompro9.Location = New Point(x, y + 120)
                    lblnompro10.Location = New Point(x, y + 135)
                    lblnompro11.Location = New Point(x, y + 150)
                    lblnompro12.Location = New Point(x, y + 165)
                    Graposicion()
                End If
            End If
            If cbodatos.Text.Trim = "Unidades" Then

                y = y + 1


                If traecantidad = 1 Then

                    lbluni.Location = New Point(x, y)
                    Graposicion()
                End If
                If traecantidad = 2 Then

                    lbluni.Location = New Point(x, y)
                    lbluni2.Location = New Point(x, y + 15)
                    Graposicion()
                End If
                If traecantidad = 3 Then

                    lbluni.Location = New Point(x, y)
                    lbluni2.Location = New Point(x, y + 15)
                    lbluni3.Location = New Point(x, y + 30)
                    Graposicion()
                End If

                If traecantidad = 4 Then

                    lbluni.Location = New Point(x, y)
                    lbluni2.Location = New Point(x, y + 15)
                    lbluni3.Location = New Point(x, y + 30)
                    lbluni4.Location = New Point(x, y + 45)
                    Graposicion()
                End If
                If traecantidad = 5 Then

                    lbluni.Location = New Point(x, y)
                    lbluni2.Location = New Point(x, y + 15)
                    lbluni3.Location = New Point(x, y + 30)
                    lbluni4.Location = New Point(x, y + 45)
                    lbluni5.Location = New Point(x, y + 60)
                    Graposicion()
                End If
                If traecantidad = 6 Then

                    lbluni.Location = New Point(x, y)
                    lbluni2.Location = New Point(x, y + 15)
                    lbluni3.Location = New Point(x, y + 30)
                    lbluni4.Location = New Point(x, y + 45)
                    lbluni5.Location = New Point(x, y + 60)
                    lbluni6.Location = New Point(x, y + 75)
                    Graposicion()
                End If

                If traecantidad = 7 Then
                    lbluni.Location = New Point(x, y)
                    lbluni2.Location = New Point(x, y + 15)
                    lbluni3.Location = New Point(x, y + 30)
                    lbluni4.Location = New Point(x, y + 45)
                    lbluni5.Location = New Point(x, y + 60)
                    lbluni6.Location = New Point(x, y + 75)
                    lbluni7.Location = New Point(x, y + 90)
                    Graposicion()
                End If
                If traecantidad = 8 Then
                    lbluni.Location = New Point(x, y)
                    lbluni2.Location = New Point(x, y + 15)
                    lbluni3.Location = New Point(x, y + 30)
                    lbluni4.Location = New Point(x, y + 45)
                    lbluni5.Location = New Point(x, y + 60)
                    lbluni6.Location = New Point(x, y + 75)
                    lbluni7.Location = New Point(x, y + 90)
                    lbluni8.Location = New Point(x, y + 105)
                    Graposicion()
                End If
                If traecantidad = 9 Then
                    lbluni.Location = New Point(x, y)
                    lbluni2.Location = New Point(x, y + 15)
                    lbluni3.Location = New Point(x, y + 30)
                    lbluni4.Location = New Point(x, y + 45)
                    lbluni5.Location = New Point(x, y + 60)
                    lbluni6.Location = New Point(x, y + 75)
                    lbluni7.Location = New Point(x, y + 90)
                    lbluni8.Location = New Point(x, y + 105)
                    lbluni9.Location = New Point(x, y + 120)
                    Graposicion()
                End If
                If traecantidad = 10 Then
                    lbluni.Location = New Point(x, y)
                    lbluni2.Location = New Point(x, y + 15)
                    lbluni3.Location = New Point(x, y + 30)
                    lbluni4.Location = New Point(x, y + 45)
                    lbluni5.Location = New Point(x, y + 60)
                    lbluni6.Location = New Point(x, y + 75)
                    lbluni7.Location = New Point(x, y + 90)
                    lbluni8.Location = New Point(x, y + 105)
                    lbluni9.Location = New Point(x, y + 120)
                    lbluni10.Location = New Point(x, y + 135)
                    Graposicion()
                End If
                If traecantidad = 11 Then
                    lbluni.Location = New Point(x, y)
                    lbluni2.Location = New Point(x, y + 15)
                    lbluni3.Location = New Point(x, y + 30)
                    lbluni4.Location = New Point(x, y + 45)
                    lbluni5.Location = New Point(x, y + 60)
                    lbluni6.Location = New Point(x, y + 75)
                    lbluni7.Location = New Point(x, y + 90)
                    lbluni8.Location = New Point(x, y + 105)
                    lbluni9.Location = New Point(x, y + 120)
                    lbluni10.Location = New Point(x, y + 135)
                    lbluni11.Location = New Point(x, y + 150)
                    Graposicion()
                End If
                If traecantidad = 12 Then
                    lbluni.Location = New Point(x, y)
                    lbluni2.Location = New Point(x, y + 15)
                    lbluni3.Location = New Point(x, y + 30)
                    lbluni4.Location = New Point(x, y + 45)
                    lbluni5.Location = New Point(x, y + 60)
                    lbluni6.Location = New Point(x, y + 75)
                    lbluni7.Location = New Point(x, y + 90)
                    lbluni8.Location = New Point(x, y + 105)
                    lbluni9.Location = New Point(x, y + 120)
                    lbluni10.Location = New Point(x, y + 135)
                    lbluni11.Location = New Point(x, y + 150)
                    lbluni12.Location = New Point(x, y + 165)
                    Graposicion()
                End If
            End If
            If cbodatos.Text.Trim = "Kilos" Then

                y = y + 1


                If traecantidad = 1 Then

                    lblkil.Location = New Point(x, y)
                    Graposicion()
                End If
                If traecantidad = 2 Then

                    lblkil.Location = New Point(x, y)
                    lblkil2.Location = New Point(x, y + 15)
                    Graposicion()
                End If
                If traecantidad = 3 Then

                    lblkil.Location = New Point(x, y)
                    lblkil2.Location = New Point(x, y + 15)
                    lblkil3.Location = New Point(x, y + 30)
                    Graposicion()
                End If

                If traecantidad = 4 Then

                    lblkil.Location = New Point(x, y)
                    lblkil2.Location = New Point(x, y + 15)
                    lblkil3.Location = New Point(x, y + 30)
                    lblkil4.Location = New Point(x, y + 45)
                    Graposicion()
                End If
                If traecantidad = 5 Then

                    lblkil.Location = New Point(x, y)
                    lblkil2.Location = New Point(x, y + 15)
                    lblkil3.Location = New Point(x, y + 30)
                    lblkil4.Location = New Point(x, y + 45)
                    lblkil5.Location = New Point(x, y + 60)
                    Graposicion()
                End If
                If traecantidad = 6 Then

                    lblkil.Location = New Point(x, y)
                    lblkil2.Location = New Point(x, y + 15)
                    lblkil3.Location = New Point(x, y + 30)
                    lblkil4.Location = New Point(x, y + 45)
                    lblkil5.Location = New Point(x, y + 60)
                    lblkil6.Location = New Point(x, y + 75)
                    Graposicion()
                End If

                If traecantidad = 7 Then
                    lblkil.Location = New Point(x, y)
                    lblkil2.Location = New Point(x, y + 15)
                    lblkil3.Location = New Point(x, y + 30)
                    lblkil4.Location = New Point(x, y + 45)
                    lblkil5.Location = New Point(x, y + 60)
                    lblkil6.Location = New Point(x, y + 75)
                    lblkil7.Location = New Point(x, y + 90)
                    Graposicion()
                End If
                If traecantidad = 8 Then
                    lblkil.Location = New Point(x, y)
                    lblkil2.Location = New Point(x, y + 15)
                    lblkil3.Location = New Point(x, y + 30)
                    lblkil4.Location = New Point(x, y + 45)
                    lblkil5.Location = New Point(x, y + 60)
                    lblkil6.Location = New Point(x, y + 75)
                    lblkil7.Location = New Point(x, y + 90)
                    lblkil8.Location = New Point(x, y + 105)
                    Graposicion()
                End If
                If traecantidad = 9 Then
                    lblkil.Location = New Point(x, y)
                    lblkil2.Location = New Point(x, y + 15)
                    lblkil3.Location = New Point(x, y + 30)
                    lblkil4.Location = New Point(x, y + 45)
                    lblkil5.Location = New Point(x, y + 60)
                    lblkil6.Location = New Point(x, y + 75)
                    lblkil7.Location = New Point(x, y + 90)
                    lblkil8.Location = New Point(x, y + 105)
                    lblkil9.Location = New Point(x, y + 120)
                    Graposicion()
                End If
                If traecantidad = 10 Then
                    lblkil.Location = New Point(x, y)
                    lblkil2.Location = New Point(x, y + 15)
                    lblkil3.Location = New Point(x, y + 30)
                    lblkil4.Location = New Point(x, y + 45)
                    lblkil5.Location = New Point(x, y + 60)
                    lblkil6.Location = New Point(x, y + 75)
                    lblkil7.Location = New Point(x, y + 90)
                    lblkil8.Location = New Point(x, y + 105)
                    lblkil9.Location = New Point(x, y + 120)
                    lblkil10.Location = New Point(x, y + 135)
                    Graposicion()
                End If
                If traecantidad = 11 Then
                    lblkil.Location = New Point(x, y)
                    lblkil2.Location = New Point(x, y + 15)
                    lblkil3.Location = New Point(x, y + 30)
                    lblkil4.Location = New Point(x, y + 45)
                    lblkil5.Location = New Point(x, y + 60)
                    lblkil6.Location = New Point(x, y + 75)
                    lblkil7.Location = New Point(x, y + 90)
                    lblkil8.Location = New Point(x, y + 105)
                    lblkil9.Location = New Point(x, y + 120)
                    lblkil10.Location = New Point(x, y + 135)
                    lblkil11.Location = New Point(x, y + 150)
                    Graposicion()
                End If
                If traecantidad = 12 Then
                    lblkil.Location = New Point(x, y)
                    lblkil2.Location = New Point(x, y + 15)
                    lblkil3.Location = New Point(x, y + 30)
                    lblkil4.Location = New Point(x, y + 45)
                    lblkil5.Location = New Point(x, y + 60)
                    lblkil6.Location = New Point(x, y + 75)
                    lblkil7.Location = New Point(x, y + 90)
                    lblkil8.Location = New Point(x, y + 105)
                    lblkil9.Location = New Point(x, y + 120)
                    lblkil10.Location = New Point(x, y + 135)
                    lblkil11.Location = New Point(x, y + 150)
                    lblkil12.Location = New Point(x, y + 165)
                    Graposicion()
                End If
            End If


        End If
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If x >= 111 Then

            If cbodatos.Text.Trim = "Despacho" Then

                x = x - 1
                lbldespacho.Location = New Point(x, y)
                Graposicion()

            End If
            If cbodatos.Text.Trim = "Rut cliente" Then

                x = x - 1
                lblrutcli.Location = New Point(x, y)
                Graposicion()

            End If
            If cbodatos.Text.Trim = "Nombre cliente" Then

                x = x - 1
                lblnomcli.Location = New Point(x, y)
                Graposicion()

            End If
            If cbodatos.Text.Trim = "Fecha" Then

                x = x - 1
                lblfecha.Location = New Point(x, y)
                Graposicion()

            End If
            If cbodatos.Text.Trim = "Giro" Then

                x = x - 1
                lblgiro.Location = New Point(x, y)
                Graposicion()

            End If
            If cbodatos.Text.Trim = "Direccion" Then

                x = x - 1
                lbldireccion.Location = New Point(x, y)
                Graposicion()

            End If
            If cbodatos.Text.Trim = "Comuna" Then

                x = x - 1
                lblcomuna.Location = New Point(x, y)
                Graposicion()

            End If
            If cbodatos.Text.Trim = "Nombre chofer" Then

                x = x - 1
                lblnomcho.Location = New Point(x, y)
                Graposicion()

            End If
            If cbodatos.Text.Trim = "Rut chofer" Then

                x = x - 1
                lblrutcho.Location = New Point(x, y)
                Graposicion()

            End If
            If cbodatos.Text.Trim = "Patente" Then

                x = x - 1
                lblpatente.Location = New Point(x, y)
                Graposicion()

            End If
            If cbodatos.Text.Trim = "Observacion" Then

                x = x - 1
                lblobs.Location = New Point(x, y)
                Graposicion()

            End If
            If cbodatos.Text.Trim = "Destino" Then

                x = x - 1
                lbldestino.Location = New Point(x, y)
                lbldestino2.Location = New Point(x, y + 15)
                lbldestino3.Location = New Point(x, y + 30)
                Graposicion()

            End If
            If cbodatos.Text.Trim = "Codigo producto" Then

                x = x - 1

                If traecantidad = 1 Then
                    lblcodpro.Location = New Point(x, y)
                    Graposicion()
                End If
                If traecantidad = 2 Then
                    lblcodpro.Location = New Point(x, y)
                    lblcodpro2.Location = New Point(x, y + 15)
                    Graposicion()
                End If
                If traecantidad = 3 Then
                    lblcodpro.Location = New Point(x, y)
                    lblcodpro2.Location = New Point(x, y + 15)
                    lblcodpro3.Location = New Point(x, y + 30)
                    Graposicion()
                End If
                If traecantidad = 4 Then
                    lblcodpro.Location = New Point(x, y)
                    lblcodpro2.Location = New Point(x, y + 15)
                    lblcodpro3.Location = New Point(x, y + 30)
                    lblcodpro4.Location = New Point(x, y + 45)
                    Graposicion()
                End If
                If traecantidad = 5 Then
                    lblcodpro.Location = New Point(x, y)
                    lblcodpro2.Location = New Point(x, y + 15)
                    lblcodpro3.Location = New Point(x, y + 30)
                    lblcodpro4.Location = New Point(x, y + 45)
                    lblcodpro5.Location = New Point(x, y + 60)
                    Graposicion()
                End If
                If traecantidad = 6 Then
                    lblcodpro.Location = New Point(x, y)
                    lblcodpro2.Location = New Point(x, y + 15)
                    lblcodpro3.Location = New Point(x, y + 30)
                    lblcodpro4.Location = New Point(x, y + 45)
                    lblcodpro5.Location = New Point(x, y + 60)
                    lblcodpro6.Location = New Point(x, y + 75)
                    Graposicion()
                End If

                If traecantidad = 7 Then
                    lblcodpro.Location = New Point(x, y)
                    lblcodpro2.Location = New Point(x, y + 15)
                    lblcodpro3.Location = New Point(x, y + 30)
                    lblcodpro4.Location = New Point(x, y + 45)
                    lblcodpro5.Location = New Point(x, y + 60)
                    lblcodpro6.Location = New Point(x, y + 75)
                    lblcodpro7.Location = New Point(x, y + 90)
                    Graposicion()
                End If
                If traecantidad = 8 Then
                    lblcodpro.Location = New Point(x, y)
                    lblcodpro2.Location = New Point(x, y + 15)
                    lblcodpro3.Location = New Point(x, y + 30)
                    lblcodpro4.Location = New Point(x, y + 45)
                    lblcodpro5.Location = New Point(x, y + 60)
                    lblcodpro6.Location = New Point(x, y + 75)
                    lblcodpro7.Location = New Point(x, y + 90)
                    lblcodpro8.Location = New Point(x, y + 105)
                    Graposicion()
                End If
                If traecantidad = 9 Then
                    lblcodpro.Location = New Point(x, y)
                    lblcodpro2.Location = New Point(x, y + 15)
                    lblcodpro3.Location = New Point(x, y + 30)
                    lblcodpro4.Location = New Point(x, y + 45)
                    lblcodpro5.Location = New Point(x, y + 60)
                    lblcodpro6.Location = New Point(x, y + 75)
                    lblcodpro7.Location = New Point(x, y + 90)
                    lblcodpro8.Location = New Point(x, y + 105)
                    lblcodpro9.Location = New Point(x, y + 120)
                    Graposicion()
                End If
                If traecantidad = 10 Then
                    lblcodpro.Location = New Point(x, y)
                    lblcodpro2.Location = New Point(x, y + 15)
                    lblcodpro3.Location = New Point(x, y + 30)
                    lblcodpro4.Location = New Point(x, y + 45)
                    lblcodpro5.Location = New Point(x, y + 60)
                    lblcodpro6.Location = New Point(x, y + 75)
                    lblcodpro7.Location = New Point(x, y + 90)
                    lblcodpro8.Location = New Point(x, y + 105)
                    lblcodpro9.Location = New Point(x, y + 120)
                    lblcodpro10.Location = New Point(x, y + 135)
                    Graposicion()
                End If
                If traecantidad = 11 Then
                    lblcodpro.Location = New Point(x, y)
                    lblcodpro2.Location = New Point(x, y + 15)
                    lblcodpro3.Location = New Point(x, y + 30)
                    lblcodpro4.Location = New Point(x, y + 45)
                    lblcodpro5.Location = New Point(x, y + 60)
                    lblcodpro6.Location = New Point(x, y + 75)
                    lblcodpro7.Location = New Point(x, y + 90)
                    lblcodpro8.Location = New Point(x, y + 105)
                    lblcodpro9.Location = New Point(x, y + 120)
                    lblcodpro10.Location = New Point(x, y + 135)
                    lblcodpro11.Location = New Point(x, y + 150)
                    Graposicion()
                End If
                If traecantidad = 12 Then
                    lblcodpro.Location = New Point(x, y)
                    lblcodpro2.Location = New Point(x, y + 15)
                    lblcodpro3.Location = New Point(x, y + 30)
                    lblcodpro4.Location = New Point(x, y + 45)
                    lblcodpro5.Location = New Point(x, y + 60)
                    lblcodpro6.Location = New Point(x, y + 75)
                    lblcodpro7.Location = New Point(x, y + 90)
                    lblcodpro8.Location = New Point(x, y + 105)
                    lblcodpro9.Location = New Point(x, y + 120)
                    lblcodpro10.Location = New Point(x, y + 135)
                    lblcodpro11.Location = New Point(x, y + 150)
                    lblcodpro12.Location = New Point(x, y + 165)
                    Graposicion()
                End If



            End If

            If cbodatos.Text.Trim = "Nombre producto" Then
                x = x - 1

                If traecantidad = 1 Then

                    lblnompro.Location = New Point(x, y)
                    Graposicion()
                End If
                If traecantidad = 2 Then

                    lblnompro.Location = New Point(x, y)
                    lblnompro2.Location = New Point(x, y + 15)
                    Graposicion()
                End If
                If traecantidad = 3 Then

                    lblnompro.Location = New Point(x, y)
                    lblnompro2.Location = New Point(x, y + 15)
                    lblnompro3.Location = New Point(x, y + 30)
                    Graposicion()
                End If

                If traecantidad = 4 Then

                    lblnompro.Location = New Point(x, y)
                    lblnompro2.Location = New Point(x, y + 15)
                    lblnompro3.Location = New Point(x, y + 30)
                    lblnompro4.Location = New Point(x, y + 45)
                    Graposicion()
                End If
                If traecantidad = 5 Then

                    lblnompro.Location = New Point(x, y)
                    lblnompro2.Location = New Point(x, y + 15)
                    lblnompro3.Location = New Point(x, y + 30)
                    lblnompro4.Location = New Point(x, y + 45)
                    lblnompro5.Location = New Point(x, y + 60)
                    Graposicion()
                End If
                If traecantidad = 6 Then

                    lblnompro.Location = New Point(x, y)
                    lblnompro2.Location = New Point(x, y + 15)
                    lblnompro3.Location = New Point(x, y + 30)
                    lblnompro4.Location = New Point(x, y + 45)
                    lblnompro5.Location = New Point(x, y + 60)
                    lblnompro6.Location = New Point(x, y + 75)
                    Graposicion()
                End If

                If traecantidad = 7 Then
                    lblnompro.Location = New Point(x, y)
                    lblnompro2.Location = New Point(x, y + 15)
                    lblnompro3.Location = New Point(x, y + 30)
                    lblnompro4.Location = New Point(x, y + 45)
                    lblnompro5.Location = New Point(x, y + 60)
                    lblnompro6.Location = New Point(x, y + 75)
                    lblnompro7.Location = New Point(x, y + 90)
                    Graposicion()
                End If
                If traecantidad = 8 Then
                    lblnompro.Location = New Point(x, y)
                    lblnompro2.Location = New Point(x, y + 15)
                    lblnompro3.Location = New Point(x, y + 30)
                    lblnompro4.Location = New Point(x, y + 45)
                    lblnompro5.Location = New Point(x, y + 60)
                    lblnompro6.Location = New Point(x, y + 75)
                    lblnompro7.Location = New Point(x, y + 90)
                    lblnompro8.Location = New Point(x, y + 105)
                    Graposicion()
                End If
                If traecantidad = 9 Then
                    lblnompro.Location = New Point(x, y)
                    lblnompro2.Location = New Point(x, y + 15)
                    lblnompro3.Location = New Point(x, y + 30)
                    lblnompro4.Location = New Point(x, y + 45)
                    lblnompro5.Location = New Point(x, y + 60)
                    lblnompro6.Location = New Point(x, y + 75)
                    lblnompro7.Location = New Point(x, y + 90)
                    lblnompro8.Location = New Point(x, y + 105)
                    lblnompro9.Location = New Point(x, y + 120)
                    Graposicion()
                End If
                If traecantidad = 10 Then
                    lblnompro.Location = New Point(x, y)
                    lblnompro2.Location = New Point(x, y + 15)
                    lblnompro3.Location = New Point(x, y + 30)
                    lblnompro4.Location = New Point(x, y + 45)
                    lblnompro5.Location = New Point(x, y + 60)
                    lblnompro6.Location = New Point(x, y + 75)
                    lblnompro7.Location = New Point(x, y + 90)
                    lblnompro8.Location = New Point(x, y + 105)
                    lblnompro9.Location = New Point(x, y + 120)
                    lblnompro10.Location = New Point(x, y + 135)
                    Graposicion()
                End If
                If traecantidad = 11 Then
                    lblnompro.Location = New Point(x, y)
                    lblnompro2.Location = New Point(x, y + 15)
                    lblnompro3.Location = New Point(x, y + 30)
                    lblnompro4.Location = New Point(x, y + 45)
                    lblnompro5.Location = New Point(x, y + 60)
                    lblnompro6.Location = New Point(x, y + 75)
                    lblnompro7.Location = New Point(x, y + 90)
                    lblnompro8.Location = New Point(x, y + 105)
                    lblnompro9.Location = New Point(x, y + 120)
                    lblnompro10.Location = New Point(x, y + 135)
                    lblnompro11.Location = New Point(x, y + 150)
                    Graposicion()
                End If
                If traecantidad = 12 Then
                    lblnompro.Location = New Point(x, y)
                    lblnompro2.Location = New Point(x, y + 15)
                    lblnompro3.Location = New Point(x, y + 30)
                    lblnompro4.Location = New Point(x, y + 45)
                    lblnompro5.Location = New Point(x, y + 60)
                    lblnompro6.Location = New Point(x, y + 75)
                    lblnompro7.Location = New Point(x, y + 90)
                    lblnompro8.Location = New Point(x, y + 105)
                    lblnompro9.Location = New Point(x, y + 120)
                    lblnompro10.Location = New Point(x, y + 135)
                    lblnompro11.Location = New Point(x, y + 150)
                    lblnompro12.Location = New Point(x, y + 165)
                    Graposicion()
                End If



            End If
            If cbodatos.Text.Trim = "Unidades" Then

                x = x - 1


                If traecantidad = 1 Then

                    lbluni.Location = New Point(x, y)
                    Graposicion()
                End If
                If traecantidad = 2 Then

                    lbluni.Location = New Point(x, y)
                    lbluni2.Location = New Point(x, y + 15)
                    Graposicion()
                End If
                If traecantidad = 3 Then

                    lbluni.Location = New Point(x, y)
                    lbluni2.Location = New Point(x, y + 15)
                    lbluni3.Location = New Point(x, y + 30)
                    Graposicion()
                End If

                If traecantidad = 4 Then

                    lbluni.Location = New Point(x, y)
                    lbluni2.Location = New Point(x, y + 15)
                    lbluni3.Location = New Point(x, y + 30)
                    lbluni4.Location = New Point(x, y + 45)
                    Graposicion()
                End If
                If traecantidad = 5 Then

                    lbluni.Location = New Point(x, y)
                    lbluni2.Location = New Point(x, y + 15)
                    lbluni3.Location = New Point(x, y + 30)
                    lbluni4.Location = New Point(x, y + 45)
                    lbluni5.Location = New Point(x, y + 60)
                    Graposicion()
                End If
                If traecantidad = 6 Then

                    lbluni.Location = New Point(x, y)
                    lbluni2.Location = New Point(x, y + 15)
                    lbluni3.Location = New Point(x, y + 30)
                    lbluni4.Location = New Point(x, y + 45)
                    lbluni5.Location = New Point(x, y + 60)
                    lbluni6.Location = New Point(x, y + 75)
                    Graposicion()
                End If

                If traecantidad = 7 Then
                    lbluni.Location = New Point(x, y)
                    lbluni2.Location = New Point(x, y + 15)
                    lbluni3.Location = New Point(x, y + 30)
                    lbluni4.Location = New Point(x, y + 45)
                    lbluni5.Location = New Point(x, y + 60)
                    lbluni6.Location = New Point(x, y + 75)
                    lbluni7.Location = New Point(x, y + 90)
                    Graposicion()
                End If
                If traecantidad = 8 Then
                    lbluni.Location = New Point(x, y)
                    lbluni2.Location = New Point(x, y + 15)
                    lbluni3.Location = New Point(x, y + 30)
                    lbluni4.Location = New Point(x, y + 45)
                    lbluni5.Location = New Point(x, y + 60)
                    lbluni6.Location = New Point(x, y + 75)
                    lbluni7.Location = New Point(x, y + 90)
                    lbluni8.Location = New Point(x, y + 105)
                    Graposicion()
                End If
                If traecantidad = 9 Then
                    lbluni.Location = New Point(x, y)
                    lbluni2.Location = New Point(x, y + 15)
                    lbluni3.Location = New Point(x, y + 30)
                    lbluni4.Location = New Point(x, y + 45)
                    lbluni5.Location = New Point(x, y + 60)
                    lbluni6.Location = New Point(x, y + 75)
                    lbluni7.Location = New Point(x, y + 90)
                    lbluni8.Location = New Point(x, y + 105)
                    lbluni9.Location = New Point(x, y + 120)
                    Graposicion()
                End If
                If traecantidad = 10 Then
                    lbluni.Location = New Point(x, y)
                    lbluni2.Location = New Point(x, y + 15)
                    lbluni3.Location = New Point(x, y + 30)
                    lbluni4.Location = New Point(x, y + 45)
                    lbluni5.Location = New Point(x, y + 60)
                    lbluni6.Location = New Point(x, y + 75)
                    lbluni7.Location = New Point(x, y + 90)
                    lbluni8.Location = New Point(x, y + 105)
                    lbluni9.Location = New Point(x, y + 120)
                    lbluni10.Location = New Point(x, y + 135)
                    Graposicion()
                End If
                If traecantidad = 11 Then
                    lbluni.Location = New Point(x, y)
                    lbluni2.Location = New Point(x, y + 15)
                    lbluni3.Location = New Point(x, y + 30)
                    lbluni4.Location = New Point(x, y + 45)
                    lbluni5.Location = New Point(x, y + 60)
                    lbluni6.Location = New Point(x, y + 75)
                    lbluni7.Location = New Point(x, y + 90)
                    lbluni8.Location = New Point(x, y + 105)
                    lbluni9.Location = New Point(x, y + 120)
                    lbluni10.Location = New Point(x, y + 135)
                    lbluni11.Location = New Point(x, y + 150)
                    Graposicion()
                End If
                If traecantidad = 12 Then
                    lbluni.Location = New Point(x, y)
                    lbluni2.Location = New Point(x, y + 15)
                    lbluni3.Location = New Point(x, y + 30)
                    lbluni4.Location = New Point(x, y + 45)
                    lbluni5.Location = New Point(x, y + 60)
                    lbluni6.Location = New Point(x, y + 75)
                    lbluni7.Location = New Point(x, y + 90)
                    lbluni8.Location = New Point(x, y + 105)
                    lbluni9.Location = New Point(x, y + 120)
                    lbluni10.Location = New Point(x, y + 135)
                    lbluni11.Location = New Point(x, y + 150)
                    lbluni12.Location = New Point(x, y + 165)
                    Graposicion()
                End If
            End If
            If cbodatos.Text.Trim = "Kilos" Then

                x = x - 1


                If traecantidad = 1 Then

                    lblkil.Location = New Point(x, y)
                    Graposicion()
                End If
                If traecantidad = 2 Then

                    lblkil.Location = New Point(x, y)
                    lblkil2.Location = New Point(x, y + 15)
                    Graposicion()
                End If
                If traecantidad = 3 Then

                    lblkil.Location = New Point(x, y)
                    lblkil2.Location = New Point(x, y + 15)
                    lblkil3.Location = New Point(x, y + 30)
                    Graposicion()
                End If

                If traecantidad = 4 Then

                    lblkil.Location = New Point(x, y)
                    lblkil2.Location = New Point(x, y + 15)
                    lblkil3.Location = New Point(x, y + 30)
                    lblkil4.Location = New Point(x, y + 45)
                    Graposicion()
                End If
                If traecantidad = 5 Then

                    lblkil.Location = New Point(x, y)
                    lblkil2.Location = New Point(x, y + 15)
                    lblkil3.Location = New Point(x, y + 30)
                    lblkil4.Location = New Point(x, y + 45)
                    lblkil5.Location = New Point(x, y + 60)
                    Graposicion()
                End If
                If traecantidad = 6 Then

                    lblkil.Location = New Point(x, y)
                    lblkil2.Location = New Point(x, y + 15)
                    lblkil3.Location = New Point(x, y + 30)
                    lblkil4.Location = New Point(x, y + 45)
                    lblkil5.Location = New Point(x, y + 60)
                    lblkil6.Location = New Point(x, y + 75)
                    Graposicion()
                End If

                If traecantidad = 7 Then
                    lblkil.Location = New Point(x, y)
                    lblkil2.Location = New Point(x, y + 15)
                    lblkil3.Location = New Point(x, y + 30)
                    lblkil4.Location = New Point(x, y + 45)
                    lblkil5.Location = New Point(x, y + 60)
                    lblkil6.Location = New Point(x, y + 75)
                    lblkil7.Location = New Point(x, y + 90)
                    Graposicion()
                End If
                If traecantidad = 8 Then
                    lblkil.Location = New Point(x, y)
                    lblkil2.Location = New Point(x, y + 15)
                    lblkil3.Location = New Point(x, y + 30)
                    lblkil4.Location = New Point(x, y + 45)
                    lblkil5.Location = New Point(x, y + 60)
                    lblkil6.Location = New Point(x, y + 75)
                    lblkil7.Location = New Point(x, y + 90)
                    lblkil8.Location = New Point(x, y + 105)
                    Graposicion()
                End If
                If traecantidad = 9 Then
                    lblkil.Location = New Point(x, y)
                    lblkil2.Location = New Point(x, y + 15)
                    lblkil3.Location = New Point(x, y + 30)
                    lblkil4.Location = New Point(x, y + 45)
                    lblkil5.Location = New Point(x, y + 60)
                    lblkil6.Location = New Point(x, y + 75)
                    lblkil7.Location = New Point(x, y + 90)
                    lblkil8.Location = New Point(x, y + 105)
                    lblkil9.Location = New Point(x, y + 120)
                    Graposicion()
                End If
                If traecantidad = 10 Then
                    lblkil.Location = New Point(x, y)
                    lblkil2.Location = New Point(x, y + 15)
                    lblkil3.Location = New Point(x, y + 30)
                    lblkil4.Location = New Point(x, y + 45)
                    lblkil5.Location = New Point(x, y + 60)
                    lblkil6.Location = New Point(x, y + 75)
                    lblkil7.Location = New Point(x, y + 90)
                    lblkil8.Location = New Point(x, y + 105)
                    lblkil9.Location = New Point(x, y + 120)
                    lblkil10.Location = New Point(x, y + 135)
                    Graposicion()
                End If
                If traecantidad = 11 Then
                    lblkil.Location = New Point(x, y)
                    lblkil2.Location = New Point(x, y + 15)
                    lblkil3.Location = New Point(x, y + 30)
                    lblkil4.Location = New Point(x, y + 45)
                    lblkil5.Location = New Point(x, y + 60)
                    lblkil6.Location = New Point(x, y + 75)
                    lblkil7.Location = New Point(x, y + 90)
                    lblkil8.Location = New Point(x, y + 105)
                    lblkil9.Location = New Point(x, y + 120)
                    lblkil10.Location = New Point(x, y + 135)
                    lblkil11.Location = New Point(x, y + 150)
                    Graposicion()
                End If
                If traecantidad = 12 Then
                    lblkil.Location = New Point(x, y)
                    lblkil2.Location = New Point(x, y + 15)
                    lblkil3.Location = New Point(x, y + 30)
                    lblkil4.Location = New Point(x, y + 45)
                    lblkil5.Location = New Point(x, y + 60)
                    lblkil6.Location = New Point(x, y + 75)
                    lblkil7.Location = New Point(x, y + 90)
                    lblkil8.Location = New Point(x, y + 105)
                    lblkil9.Location = New Point(x, y + 120)
                    lblkil10.Location = New Point(x, y + 135)
                    lblkil11.Location = New Point(x, y + 150)
                    lblkil12.Location = New Point(x, y + 165)
                    Graposicion()
                End If
            End If

        End If
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        If x <= 723 Then

            If cbodatos.Text.Trim = "Despacho" Then

                x = x + 1
                lbldespacho.Location = New Point(x, y)
                Graposicion()

            End If
            If cbodatos.Text.Trim = "Rut cliente" Then

                x = x + 1
                lblrutcli.Location = New Point(x, y)
                Graposicion()

            End If

            If cbodatos.Text.Trim = "Nombre cliente" Then

                x = x + 1
                lblnomcli.Location = New Point(x, y)
                Graposicion()

            End If
            If cbodatos.Text.Trim = "Fecha" Then

                x = x + 1
                lblfecha.Location = New Point(x, y)
                Graposicion()

            End If
            If cbodatos.Text.Trim = "Giro" Then

                x = x + 1
                lblgiro.Location = New Point(x, y)
                Graposicion()

            End If
            If cbodatos.Text.Trim = "Direccion" Then

                x = x + 1
                lbldireccion.Location = New Point(x, y)
                Graposicion()

            End If
            If cbodatos.Text.Trim = "Comuna" Then

                x = x + 1
                lblcomuna.Location = New Point(x, y)
                Graposicion()

            End If
            If cbodatos.Text.Trim = "Nombre chofer" Then

                x = x + 1
                lblnomcho.Location = New Point(x, y)
                Graposicion()

            End If
            If cbodatos.Text.Trim = "Rut chofer" Then

                x = x + 1
                lblrutcho.Location = New Point(x, y)
                Graposicion()

            End If
            If cbodatos.Text.Trim = "Patente" Then

                x = x + 1
                lblpatente.Location = New Point(x, y)
                Graposicion()

            End If
            If cbodatos.Text.Trim = "Observacion" Then

                x = x + 1
                lblobs.Location = New Point(x, y)
                Graposicion()

            End If
            If cbodatos.Text.Trim = "Destino" Then

                x = x + 1
                lbldestino.Location = New Point(x, y)
                lbldestino2.Location = New Point(x, y + 15)
                lbldestino3.Location = New Point(x, y + 30)
                Graposicion()

            End If
            If cbodatos.Text.Trim = "Codigo producto" Then
                x = x + 1
                If traecantidad = 1 Then
                    lblcodpro.Location = New Point(x, y)
                    Graposicion()
                End If
                If traecantidad = 2 Then
                    lblcodpro.Location = New Point(x, y)
                    lblcodpro2.Location = New Point(x, y + 15)
                    Graposicion()
                End If
                If traecantidad = 3 Then
                    lblcodpro.Location = New Point(x, y)
                    lblcodpro2.Location = New Point(x, y + 15)
                    lblcodpro3.Location = New Point(x, y + 30)
                    Graposicion()
                End If
                If traecantidad = 4 Then
                    lblcodpro.Location = New Point(x, y)
                    lblcodpro2.Location = New Point(x, y + 15)
                    lblcodpro3.Location = New Point(x, y + 30)
                    lblcodpro4.Location = New Point(x, y + 45)
                    Graposicion()
                End If
                If traecantidad = 5 Then
                    lblcodpro.Location = New Point(x, y)
                    lblcodpro2.Location = New Point(x, y + 15)
                    lblcodpro3.Location = New Point(x, y + 30)
                    lblcodpro4.Location = New Point(x, y + 45)
                    lblcodpro5.Location = New Point(x, y + 60)
                    Graposicion()
                End If
                If traecantidad = 6 Then
                    lblcodpro.Location = New Point(x, y)
                    lblcodpro2.Location = New Point(x, y + 15)
                    lblcodpro3.Location = New Point(x, y + 30)
                    lblcodpro4.Location = New Point(x, y + 45)
                    lblcodpro5.Location = New Point(x, y + 60)
                    lblcodpro6.Location = New Point(x, y + 75)
                    Graposicion()
                End If
                If traecantidad = 7 Then
                    lblcodpro.Location = New Point(x, y)
                    lblcodpro2.Location = New Point(x, y + 15)
                    lblcodpro3.Location = New Point(x, y + 30)
                    lblcodpro4.Location = New Point(x, y + 45)
                    lblcodpro5.Location = New Point(x, y + 60)
                    lblcodpro6.Location = New Point(x, y + 75)
                    lblcodpro7.Location = New Point(x, y + 90)
                    Graposicion()
                End If
                If traecantidad = 8 Then
                    lblcodpro.Location = New Point(x, y)
                    lblcodpro2.Location = New Point(x, y + 15)
                    lblcodpro3.Location = New Point(x, y + 30)
                    lblcodpro4.Location = New Point(x, y + 45)
                    lblcodpro5.Location = New Point(x, y + 60)
                    lblcodpro6.Location = New Point(x, y + 75)
                    lblcodpro7.Location = New Point(x, y + 90)
                    lblcodpro8.Location = New Point(x, y + 105)
                    Graposicion()
                End If
                If traecantidad = 9 Then
                    lblcodpro.Location = New Point(x, y)
                    lblcodpro2.Location = New Point(x, y + 15)
                    lblcodpro3.Location = New Point(x, y + 30)
                    lblcodpro4.Location = New Point(x, y + 45)
                    lblcodpro5.Location = New Point(x, y + 60)
                    lblcodpro6.Location = New Point(x, y + 75)
                    lblcodpro7.Location = New Point(x, y + 90)
                    lblcodpro8.Location = New Point(x, y + 105)
                    lblcodpro9.Location = New Point(x, y + 120)
                    Graposicion()
                End If
                If traecantidad = 10 Then
                    lblcodpro.Location = New Point(x, y)
                    lblcodpro2.Location = New Point(x, y + 15)
                    lblcodpro3.Location = New Point(x, y + 30)
                    lblcodpro4.Location = New Point(x, y + 45)
                    lblcodpro5.Location = New Point(x, y + 60)
                    lblcodpro6.Location = New Point(x, y + 75)
                    lblcodpro7.Location = New Point(x, y + 90)
                    lblcodpro8.Location = New Point(x, y + 105)
                    lblcodpro9.Location = New Point(x, y + 120)
                    lblcodpro10.Location = New Point(x, y + 135)
                    Graposicion()
                End If
                If traecantidad = 11 Then
                    lblcodpro.Location = New Point(x, y)
                    lblcodpro2.Location = New Point(x, y + 15)
                    lblcodpro3.Location = New Point(x, y + 30)
                    lblcodpro4.Location = New Point(x, y + 45)
                    lblcodpro5.Location = New Point(x, y + 60)
                    lblcodpro6.Location = New Point(x, y + 75)
                    lblcodpro7.Location = New Point(x, y + 90)
                    lblcodpro8.Location = New Point(x, y + 105)
                    lblcodpro9.Location = New Point(x, y + 120)
                    lblcodpro10.Location = New Point(x, y + 135)
                    lblcodpro11.Location = New Point(x, y + 150)
                    Graposicion()
                End If
                If traecantidad = 12 Then
                    lblcodpro.Location = New Point(x, y)
                    lblcodpro2.Location = New Point(x, y + 15)
                    lblcodpro3.Location = New Point(x, y + 30)
                    lblcodpro4.Location = New Point(x, y + 45)
                    lblcodpro5.Location = New Point(x, y + 60)
                    lblcodpro6.Location = New Point(x, y + 75)
                    lblcodpro7.Location = New Point(x, y + 90)
                    lblcodpro8.Location = New Point(x, y + 105)
                    lblcodpro9.Location = New Point(x, y + 120)
                    lblcodpro10.Location = New Point(x, y + 135)
                    lblcodpro11.Location = New Point(x, y + 150)
                    lblcodpro12.Location = New Point(x, y + 165)
                    Graposicion()
                End If


            End If

            If cbodatos.Text.Trim = "Nombre producto" Then

                x = x + 1
                If traecantidad = 1 Then

                    lblnompro.Location = New Point(x, y)
                    Graposicion()
                End If
                If traecantidad = 2 Then

                    lblnompro.Location = New Point(x, y)
                    lblnompro2.Location = New Point(x, y + 15)
                    Graposicion()
                End If
                If traecantidad = 3 Then

                    lblnompro.Location = New Point(x, y)
                    lblnompro2.Location = New Point(x, y + 15)
                    lblnompro3.Location = New Point(x, y + 30)
                    Graposicion()
                End If

                If traecantidad = 4 Then

                    lblnompro.Location = New Point(x, y)
                    lblnompro2.Location = New Point(x, y + 15)
                    lblnompro3.Location = New Point(x, y + 30)
                    lblnompro4.Location = New Point(x, y + 45)
                    Graposicion()
                End If
                If traecantidad = 5 Then

                    lblnompro.Location = New Point(x, y)
                    lblnompro2.Location = New Point(x, y + 15)
                    lblnompro3.Location = New Point(x, y + 30)
                    lblnompro4.Location = New Point(x, y + 45)
                    lblnompro5.Location = New Point(x, y + 60)
                    Graposicion()
                End If
                If traecantidad = 6 Then

                    lblnompro.Location = New Point(x, y)
                    lblnompro2.Location = New Point(x, y + 15)
                    lblnompro3.Location = New Point(x, y + 30)
                    lblnompro4.Location = New Point(x, y + 45)
                    lblnompro5.Location = New Point(x, y + 60)
                    lblnompro6.Location = New Point(x, y + 75)
                    Graposicion()
                End If

                If traecantidad = 7 Then
                    lblnompro.Location = New Point(x, y)
                    lblnompro2.Location = New Point(x, y + 15)
                    lblnompro3.Location = New Point(x, y + 30)
                    lblnompro4.Location = New Point(x, y + 45)
                    lblnompro5.Location = New Point(x, y + 60)
                    lblnompro6.Location = New Point(x, y + 75)
                    lblnompro7.Location = New Point(x, y + 90)
                    Graposicion()
                End If
                If traecantidad = 8 Then
                    lblnompro.Location = New Point(x, y)
                    lblnompro2.Location = New Point(x, y + 15)
                    lblnompro3.Location = New Point(x, y + 30)
                    lblnompro4.Location = New Point(x, y + 45)
                    lblnompro5.Location = New Point(x, y + 60)
                    lblnompro6.Location = New Point(x, y + 75)
                    lblnompro7.Location = New Point(x, y + 90)
                    lblnompro8.Location = New Point(x, y + 105)
                    Graposicion()
                End If
                If traecantidad = 9 Then
                    lblnompro.Location = New Point(x, y)
                    lblnompro2.Location = New Point(x, y + 15)
                    lblnompro3.Location = New Point(x, y + 30)
                    lblnompro4.Location = New Point(x, y + 45)
                    lblnompro5.Location = New Point(x, y + 60)
                    lblnompro6.Location = New Point(x, y + 75)
                    lblnompro7.Location = New Point(x, y + 90)
                    lblnompro8.Location = New Point(x, y + 105)
                    lblnompro9.Location = New Point(x, y + 120)
                    Graposicion()
                End If
                If traecantidad = 10 Then
                    lblnompro.Location = New Point(x, y)
                    lblnompro2.Location = New Point(x, y + 15)
                    lblnompro3.Location = New Point(x, y + 30)
                    lblnompro4.Location = New Point(x, y + 45)
                    lblnompro5.Location = New Point(x, y + 60)
                    lblnompro6.Location = New Point(x, y + 75)
                    lblnompro7.Location = New Point(x, y + 90)
                    lblnompro8.Location = New Point(x, y + 105)
                    lblnompro9.Location = New Point(x, y + 120)
                    lblnompro10.Location = New Point(x, y + 135)
                    Graposicion()
                End If
                If traecantidad = 11 Then
                    lblnompro.Location = New Point(x, y)
                    lblnompro2.Location = New Point(x, y + 15)
                    lblnompro3.Location = New Point(x, y + 30)
                    lblnompro4.Location = New Point(x, y + 45)
                    lblnompro5.Location = New Point(x, y + 60)
                    lblnompro6.Location = New Point(x, y + 75)
                    lblnompro7.Location = New Point(x, y + 90)
                    lblnompro8.Location = New Point(x, y + 105)
                    lblnompro9.Location = New Point(x, y + 120)
                    lblnompro10.Location = New Point(x, y + 135)
                    lblnompro11.Location = New Point(x, y + 150)
                    Graposicion()
                End If
                If traecantidad = 12 Then
                    lblnompro.Location = New Point(x, y)
                    lblnompro2.Location = New Point(x, y + 15)
                    lblnompro3.Location = New Point(x, y + 30)
                    lblnompro4.Location = New Point(x, y + 45)
                    lblnompro5.Location = New Point(x, y + 60)
                    lblnompro6.Location = New Point(x, y + 75)
                    lblnompro7.Location = New Point(x, y + 90)
                    lblnompro8.Location = New Point(x, y + 105)
                    lblnompro9.Location = New Point(x, y + 120)
                    lblnompro10.Location = New Point(x, y + 135)
                    lblnompro11.Location = New Point(x, y + 150)
                    lblnompro12.Location = New Point(x, y + 165)
                    Graposicion()
                End If


            End If
            If cbodatos.Text.Trim = "Unidades" Then

                x = x + 1


                If traecantidad = 1 Then

                    lbluni.Location = New Point(x, y)
                    Graposicion()
                End If
                If traecantidad = 2 Then

                    lbluni.Location = New Point(x, y)
                    lbluni2.Location = New Point(x, y + 15)
                    Graposicion()
                End If
                If traecantidad = 3 Then

                    lbluni.Location = New Point(x, y)
                    lbluni2.Location = New Point(x, y + 15)
                    lbluni3.Location = New Point(x, y + 30)
                    Graposicion()
                End If

                If traecantidad = 4 Then

                    lbluni.Location = New Point(x, y)
                    lbluni2.Location = New Point(x, y + 15)
                    lbluni3.Location = New Point(x, y + 30)
                    lbluni4.Location = New Point(x, y + 45)
                    Graposicion()
                End If
                If traecantidad = 5 Then

                    lbluni.Location = New Point(x, y)
                    lbluni2.Location = New Point(x, y + 15)
                    lbluni3.Location = New Point(x, y + 30)
                    lbluni4.Location = New Point(x, y + 45)
                    lbluni5.Location = New Point(x, y + 60)
                    Graposicion()
                End If
                If traecantidad = 6 Then

                    lbluni.Location = New Point(x, y)
                    lbluni2.Location = New Point(x, y + 15)
                    lbluni3.Location = New Point(x, y + 30)
                    lbluni4.Location = New Point(x, y + 45)
                    lbluni5.Location = New Point(x, y + 60)
                    lbluni6.Location = New Point(x, y + 75)
                    Graposicion()
                End If

                If traecantidad = 7 Then
                    lbluni.Location = New Point(x, y)
                    lbluni2.Location = New Point(x, y + 15)
                    lbluni3.Location = New Point(x, y + 30)
                    lbluni4.Location = New Point(x, y + 45)
                    lbluni5.Location = New Point(x, y + 60)
                    lbluni6.Location = New Point(x, y + 75)
                    lbluni7.Location = New Point(x, y + 90)
                    Graposicion()
                End If
                If traecantidad = 8 Then
                    lbluni.Location = New Point(x, y)
                    lbluni2.Location = New Point(x, y + 15)
                    lbluni3.Location = New Point(x, y + 30)
                    lbluni4.Location = New Point(x, y + 45)
                    lbluni5.Location = New Point(x, y + 60)
                    lbluni6.Location = New Point(x, y + 75)
                    lbluni7.Location = New Point(x, y + 90)
                    lbluni8.Location = New Point(x, y + 105)
                    Graposicion()
                End If
                If traecantidad = 9 Then
                    lbluni.Location = New Point(x, y)
                    lbluni2.Location = New Point(x, y + 15)
                    lbluni3.Location = New Point(x, y + 30)
                    lbluni4.Location = New Point(x, y + 45)
                    lbluni5.Location = New Point(x, y + 60)
                    lbluni6.Location = New Point(x, y + 75)
                    lbluni7.Location = New Point(x, y + 90)
                    lbluni8.Location = New Point(x, y + 105)
                    lbluni9.Location = New Point(x, y + 120)
                    Graposicion()
                End If
                If traecantidad = 10 Then
                    lbluni.Location = New Point(x, y)
                    lbluni2.Location = New Point(x, y + 15)
                    lbluni3.Location = New Point(x, y + 30)
                    lbluni4.Location = New Point(x, y + 45)
                    lbluni5.Location = New Point(x, y + 60)
                    lbluni6.Location = New Point(x, y + 75)
                    lbluni7.Location = New Point(x, y + 90)
                    lbluni8.Location = New Point(x, y + 105)
                    lbluni9.Location = New Point(x, y + 120)
                    lbluni10.Location = New Point(x, y + 135)
                    Graposicion()
                End If
                If traecantidad = 11 Then
                    lbluni.Location = New Point(x, y)
                    lbluni2.Location = New Point(x, y + 15)
                    lbluni3.Location = New Point(x, y + 30)
                    lbluni4.Location = New Point(x, y + 45)
                    lbluni5.Location = New Point(x, y + 60)
                    lbluni6.Location = New Point(x, y + 75)
                    lbluni7.Location = New Point(x, y + 90)
                    lbluni8.Location = New Point(x, y + 105)
                    lbluni9.Location = New Point(x, y + 120)
                    lbluni10.Location = New Point(x, y + 135)
                    lbluni11.Location = New Point(x, y + 150)
                    Graposicion()
                End If
                If traecantidad = 12 Then
                    lbluni.Location = New Point(x, y)
                    lbluni2.Location = New Point(x, y + 15)
                    lbluni3.Location = New Point(x, y + 30)
                    lbluni4.Location = New Point(x, y + 45)
                    lbluni5.Location = New Point(x, y + 60)
                    lbluni6.Location = New Point(x, y + 75)
                    lbluni7.Location = New Point(x, y + 90)
                    lbluni8.Location = New Point(x, y + 105)
                    lbluni9.Location = New Point(x, y + 120)
                    lbluni10.Location = New Point(x, y + 135)
                    lbluni11.Location = New Point(x, y + 150)
                    lbluni12.Location = New Point(x, y + 165)
                    Graposicion()
                End If
            End If
            If cbodatos.Text.Trim = "Kilos" Then

                x = x + 1


                If traecantidad = 1 Then

                    lblkil.Location = New Point(x, y)
                    Graposicion()
                End If
                If traecantidad = 2 Then

                    lblkil.Location = New Point(x, y)
                    lblkil2.Location = New Point(x, y + 15)
                    Graposicion()
                End If
                If traecantidad = 3 Then

                    lblkil.Location = New Point(x, y)
                    lblkil2.Location = New Point(x, y + 15)
                    lblkil3.Location = New Point(x, y + 30)
                    Graposicion()
                End If

                If traecantidad = 4 Then

                    lblkil.Location = New Point(x, y)
                    lblkil2.Location = New Point(x, y + 15)
                    lblkil3.Location = New Point(x, y + 30)
                    lblkil4.Location = New Point(x, y + 45)
                    Graposicion()
                End If
                If traecantidad = 5 Then

                    lblkil.Location = New Point(x, y)
                    lblkil2.Location = New Point(x, y + 15)
                    lblkil3.Location = New Point(x, y + 30)
                    lblkil4.Location = New Point(x, y + 45)
                    lblkil5.Location = New Point(x, y + 60)
                    Graposicion()
                End If
                If traecantidad = 6 Then

                    lblkil.Location = New Point(x, y)
                    lblkil2.Location = New Point(x, y + 15)
                    lblkil3.Location = New Point(x, y + 30)
                    lblkil4.Location = New Point(x, y + 45)
                    lblkil5.Location = New Point(x, y + 60)
                    lblkil6.Location = New Point(x, y + 75)
                    Graposicion()
                End If

                If traecantidad = 7 Then
                    lblkil.Location = New Point(x, y)
                    lblkil2.Location = New Point(x, y + 15)
                    lblkil3.Location = New Point(x, y + 30)
                    lblkil4.Location = New Point(x, y + 45)
                    lblkil5.Location = New Point(x, y + 60)
                    lblkil6.Location = New Point(x, y + 75)
                    lblkil7.Location = New Point(x, y + 90)
                    Graposicion()
                End If
                If traecantidad = 8 Then
                    lblkil.Location = New Point(x, y)
                    lblkil2.Location = New Point(x, y + 15)
                    lblkil3.Location = New Point(x, y + 30)
                    lblkil4.Location = New Point(x, y + 45)
                    lblkil5.Location = New Point(x, y + 60)
                    lblkil6.Location = New Point(x, y + 75)
                    lblkil7.Location = New Point(x, y + 90)
                    lblkil8.Location = New Point(x, y + 105)
                    Graposicion()
                End If
                If traecantidad = 9 Then
                    lblkil.Location = New Point(x, y)
                    lblkil2.Location = New Point(x, y + 15)
                    lblkil3.Location = New Point(x, y + 30)
                    lblkil4.Location = New Point(x, y + 45)
                    lblkil5.Location = New Point(x, y + 60)
                    lblkil6.Location = New Point(x, y + 75)
                    lblkil7.Location = New Point(x, y + 90)
                    lblkil8.Location = New Point(x, y + 105)
                    lblkil9.Location = New Point(x, y + 120)
                    Graposicion()
                End If
                If traecantidad = 10 Then
                    lblkil.Location = New Point(x, y)
                    lblkil2.Location = New Point(x, y + 15)
                    lblkil3.Location = New Point(x, y + 30)
                    lblkil4.Location = New Point(x, y + 45)
                    lblkil5.Location = New Point(x, y + 60)
                    lblkil6.Location = New Point(x, y + 75)
                    lblkil7.Location = New Point(x, y + 90)
                    lblkil8.Location = New Point(x, y + 105)
                    lblkil9.Location = New Point(x, y + 120)
                    lblkil10.Location = New Point(x, y + 135)
                    Graposicion()
                End If
                If traecantidad = 11 Then
                    lblkil.Location = New Point(x, y)
                    lblkil2.Location = New Point(x, y + 15)
                    lblkil3.Location = New Point(x, y + 30)
                    lblkil4.Location = New Point(x, y + 45)
                    lblkil5.Location = New Point(x, y + 60)
                    lblkil6.Location = New Point(x, y + 75)
                    lblkil7.Location = New Point(x, y + 90)
                    lblkil8.Location = New Point(x, y + 105)
                    lblkil9.Location = New Point(x, y + 120)
                    lblkil10.Location = New Point(x, y + 135)
                    lblkil11.Location = New Point(x, y + 150)
                    Graposicion()
                End If
                If traecantidad = 12 Then
                    lblkil.Location = New Point(x, y)
                    lblkil2.Location = New Point(x, y + 15)
                    lblkil3.Location = New Point(x, y + 30)
                    lblkil4.Location = New Point(x, y + 45)
                    lblkil5.Location = New Point(x, y + 60)
                    lblkil6.Location = New Point(x, y + 75)
                    lblkil7.Location = New Point(x, y + 90)
                    lblkil8.Location = New Point(x, y + 105)
                    lblkil9.Location = New Point(x, y + 120)
                    lblkil10.Location = New Point(x, y + 135)
                    lblkil11.Location = New Point(x, y + 150)
                    lblkil12.Location = New Point(x, y + 165)
                    Graposicion()
                End If
            End If

        End If
    End Sub

    Private Sub TextBox2_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txty.KeyPress

        If txtx.Text = "" Or txty.Text = "" Then

            Exit Sub
        End If


        If e.KeyChar = ChrW(13) Then
            If cbodatos.Text.Trim = "Despacho" Then

                x = Convert.ToInt32(txtx.Text) + 111
                y = Convert.ToInt32(txty.Text) + 56



                lbldespacho.Location = New Point(x, y)
                Graposicion()

            End If

            If cbodatos.Text.Trim = "Rut cliente" Then

                x = Convert.ToInt32(txtx.Text) + 111
                y = Convert.ToInt32(txty.Text) + 56



                lblrutcli.Location = New Point(x, y)
                Graposicion()

            End If

            If cbodatos.Text.Trim = "Nombre cliente" Then

                x = Convert.ToInt32(txtx.Text) + 111
                y = Convert.ToInt32(txty.Text) + 56



                lblnomcli.Location = New Point(x, y)
                Graposicion()

            End If

            If cbodatos.Text.Trim = "Fecha" Then


                x = Convert.ToInt32(txtx.Text) + 111
                y = Convert.ToInt32(txty.Text) + 56

                lblfecha.Location = New Point(x, y)
                Graposicion()

            End If
            If cbodatos.Text.Trim = "Giro" Then


                x = Convert.ToInt32(txtx.Text) + 111
                y = Convert.ToInt32(txty.Text) + 56

                lblgiro.Location = New Point(x, y)
                Graposicion()

            End If
            If cbodatos.Text.Trim = "Direccion" Then


                x = Convert.ToInt32(txtx.Text) + 111
                y = Convert.ToInt32(txty.Text) + 56

                lbldireccion.Location = New Point(x, y)
                Graposicion()

            End If
            If cbodatos.Text.Trim = "Comuna" Then


                x = Convert.ToInt32(txtx.Text) + 111
                y = Convert.ToInt32(txty.Text) + 56

                lblcomuna.Location = New Point(x, y)
                Graposicion()

            End If
            If cbodatos.Text.Trim = "Nombre chofer" Then


                x = Convert.ToInt32(txtx.Text) + 111
                y = Convert.ToInt32(txty.Text) + 56

                lblnomcho.Location = New Point(x, y)
                Graposicion()

            End If
            If cbodatos.Text.Trim = "Rut chofer" Then


                x = Convert.ToInt32(txtx.Text) + 111
                y = Convert.ToInt32(txty.Text) + 56

                lblrutcho.Location = New Point(x, y)
                Graposicion()

            End If
            If cbodatos.Text.Trim = "Patente" Then


                x = Convert.ToInt32(txtx.Text) + 111
                y = Convert.ToInt32(txty.Text) + 56

                lblpatente.Location = New Point(x, y)
                Graposicion()

            End If
            If cbodatos.Text.Trim = "Observacion" Then


                x = Convert.ToInt32(txtx.Text) + 111
                y = Convert.ToInt32(txty.Text) + 56

                lblobs.Location = New Point(x, y)
                Graposicion()

            End If
            If cbodatos.Text.Trim = "Destino" Then


                x = Convert.ToInt32(txtx.Text) + 111
                y = Convert.ToInt32(txty.Text) + 56

                lbldestino.Location = New Point(x, y)
                lbldestino2.Location = New Point(x, y + 15)
                lbldestino3.Location = New Point(x, y + 30)
                Graposicion()

            End If
            If cbodatos.Text.Trim = "Codigo producto" Then


                x = Convert.ToInt32(txtx.Text) + 111
                y = Convert.ToInt32(txty.Text) + 56



                If traecantidad = 1 Then
                    lblcodpro.Location = New Point(x, y)
                    Graposicion()
                End If
                If traecantidad = 2 Then
                    lblcodpro.Location = New Point(x, y)
                    lblcodpro2.Location = New Point(x, y + 15)
                    Graposicion()
                End If
                If traecantidad = 3 Then
                    lblcodpro.Location = New Point(x, y)
                    lblcodpro2.Location = New Point(x, y + 15)
                    lblcodpro3.Location = New Point(x, y + 30)
                    Graposicion()
                End If
                If traecantidad = 4 Then
                    lblcodpro.Location = New Point(x, y)
                    lblcodpro2.Location = New Point(x, y + 15)
                    lblcodpro3.Location = New Point(x, y + 30)
                    lblcodpro4.Location = New Point(x, y + 45)
                    Graposicion()
                End If
                If traecantidad = 5 Then
                    lblcodpro.Location = New Point(x, y)
                    lblcodpro2.Location = New Point(x, y + 15)
                    lblcodpro3.Location = New Point(x, y + 30)
                    lblcodpro4.Location = New Point(x, y + 45)
                    lblcodpro5.Location = New Point(x, y + 60)
                    Graposicion()
                End If
                If traecantidad = 6 Then
                    lblcodpro.Location = New Point(x, y)
                    lblcodpro2.Location = New Point(x, y + 15)
                    lblcodpro3.Location = New Point(x, y + 30)
                    lblcodpro4.Location = New Point(x, y + 45)
                    lblcodpro5.Location = New Point(x, y + 60)
                    lblcodpro6.Location = New Point(x, y + 75)
                    Graposicion()
                End If
            End If

            If cbodatos.Text.Trim = "Nombre producto" Then


                x = Convert.ToInt32(txtx.Text) + 111
                y = Convert.ToInt32(txty.Text) + 56



                If traecantidad = 1 Then
                    lblnompro.Location = New Point(x, y)
                    Graposicion()
                End If
                If traecantidad = 2 Then
                    lblnompro.Location = New Point(x, y)
                    lblnompro2.Location = New Point(x, y + 15)
                    Graposicion()
                End If
                If traecantidad = 3 Then
                    lblnompro.Location = New Point(x, y)
                    lblnompro2.Location = New Point(x, y + 15)
                    lblnompro3.Location = New Point(x, y + 30)
                    Graposicion()
                End If
                If traecantidad = 4 Then
                    lblnompro.Location = New Point(x, y)
                    lblnompro2.Location = New Point(x, y + 15)
                    lblnompro3.Location = New Point(x, y + 30)
                    lblnompro4.Location = New Point(x, y + 45)
                    Graposicion()
                End If
                If traecantidad = 5 Then
                    lblnompro.Location = New Point(x, y)
                    lblnompro2.Location = New Point(x, y + 15)
                    lblnompro3.Location = New Point(x, y + 30)
                    lblnompro4.Location = New Point(x, y + 45)
                    lblnompro5.Location = New Point(x, y + 60)
                    Graposicion()
                End If
                If traecantidad = 6 Then
                    lblnompro.Location = New Point(x, y)
                    lblnompro2.Location = New Point(x, y + 15)
                    lblnompro3.Location = New Point(x, y + 30)
                    lblnompro4.Location = New Point(x, y + 45)
                    lblnompro5.Location = New Point(x, y + 60)
                    lblnompro6.Location = New Point(x, y + 75)
                    Graposicion()
                End If
            End If
            If cbodatos.Text.Trim = "Unidades" Then


                x = Convert.ToInt32(txtx.Text) + 111
                y = Convert.ToInt32(txty.Text) + 56


                If traecantidad = 1 Then

                    lbluni.Location = New Point(x, y)
                    Graposicion()
                End If
                If traecantidad = 2 Then

                    lbluni.Location = New Point(x, y)
                    lbluni2.Location = New Point(x, y + 15)
                    Graposicion()
                End If
                If traecantidad = 3 Then

                    lbluni.Location = New Point(x, y)
                    lbluni2.Location = New Point(x, y + 15)
                    lbluni3.Location = New Point(x, y + 30)
                    Graposicion()
                End If

                If traecantidad = 4 Then

                    lbluni.Location = New Point(x, y)
                    lbluni2.Location = New Point(x, y + 15)
                    lbluni3.Location = New Point(x, y + 30)
                    lbluni4.Location = New Point(x, y + 45)
                    Graposicion()
                End If
                If traecantidad = 5 Then

                    lbluni.Location = New Point(x, y)
                    lbluni2.Location = New Point(x, y + 15)
                    lbluni3.Location = New Point(x, y + 30)
                    lbluni4.Location = New Point(x, y + 45)
                    lbluni5.Location = New Point(x, y + 60)
                    Graposicion()
                End If
                If traecantidad = 6 Then

                    lbluni.Location = New Point(x, y)
                    lbluni2.Location = New Point(x, y + 15)
                    lbluni3.Location = New Point(x, y + 30)
                    lbluni4.Location = New Point(x, y + 45)
                    lbluni5.Location = New Point(x, y + 60)
                    lbluni6.Location = New Point(x, y + 75)
                    Graposicion()
                End If
            End If

            If cbodatos.Text.Trim = "Kilos" Then

                x = Convert.ToInt32(txtx.Text) + 111
                y = Convert.ToInt32(txty.Text) + 56

                If traecantidad = 1 Then

                    lblkil.Location = New Point(x, y)
                    Graposicion()
                End If
                If traecantidad = 2 Then

                    lblkil.Location = New Point(x, y)
                    lblkil2.Location = New Point(x, y + 15)
                    Graposicion()
                End If
                If traecantidad = 3 Then

                    lblkil.Location = New Point(x, y)
                    lblkil2.Location = New Point(x, y + 15)
                    lblkil3.Location = New Point(x, y + 30)
                    Graposicion()
                End If

                If traecantidad = 4 Then

                    lblkil.Location = New Point(x, y)
                    lblkil2.Location = New Point(x, y + 15)
                    lblkil3.Location = New Point(x, y + 30)
                    lblkil4.Location = New Point(x, y + 45)
                    Graposicion()
                End If
                If traecantidad = 5 Then

                    lblkil.Location = New Point(x, y)
                    lblkil2.Location = New Point(x, y + 15)
                    lblkil3.Location = New Point(x, y + 30)
                    lblkil4.Location = New Point(x, y + 45)
                    lblkil5.Location = New Point(x, y + 60)
                    Graposicion()
                End If
                If traecantidad = 6 Then

                    lblkil.Location = New Point(x, y)
                    lblkil2.Location = New Point(x, y + 15)
                    lblkil3.Location = New Point(x, y + 30)
                    lblkil4.Location = New Point(x, y + 45)
                    lblkil5.Location = New Point(x, y + 60)
                    lblkil6.Location = New Point(x, y + 75)
                    Graposicion()
                End If
            End If


        Else
            SoloNumeros(sender, e)


        End If



    End Sub

    Private Sub txtx_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtx.KeyPress
        SoloNumeros(sender, e)
    End Sub

    Private Sub CreaInforme_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Up AndAlso cbodatos.Text <> "" Then
            If y >= 56 Then

                If cbodatos.Text.Trim = "Despacho" Then

                    y = y - 1
                    lbldespacho.Location = New Point(x, y)


                End If


            End If
        End If
    End Sub

    Private Sub CreaInforme_PreviewKeyDown(sender As System.Object, e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles MyBase.PreviewKeyDown
        If e.KeyCode = Keys.Up AndAlso cbodatos.Text <> "" Then
            If y >= 56 Then

                If cbodatos.Text.Trim = "Despacho" Then

                    y = y - 1
                    lbldespacho.Location = New Point(x, y)


                End If


            End If
        End If
    End Sub

  
    Private Sub CreaInforme_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress

    End Sub

    Private Sub carga()
        Dim sql As String = "SELECT x,y,rutcli,dato from datos_informes where rutcli= '" + TxtClirut.Text + "' "

        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

        If tabla.Rows.Count > 0 Then


            For i As Integer = 0 To tabla.Rows.Count - 1

                Dim dato As String = tabla.Rows(i)(3).ToString()
                If dato = "Despacho" Then
                    lbldespacho.Text = txtfolio.Text
                    lbldespacho.Visible = True
                    x = Convert.ToInt32(tabla.Rows(i)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(i)(1).ToString())
                    lbldespacho.Location = New Point(x, y)
                End If
                If dato = "Rut cliente" Then
                    If (TxtClirut.Text = "799842408") Then
                        lblrutcli.Text = "78408440K"
                    Else
                        lblrutcli.Text = TxtClirut.Text
                    End If
                    lblrutcli.Visible = True
                    x = Convert.ToInt32(tabla.Rows(i)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(i)(1).ToString())
                    lblrutcli.Location = New Point(x, y)
                End If
                If dato = "Nombre cliente" Then
                    lblnomcli.Text = txtclinom.Text
                    lblnomcli.Visible = True
                    x = Convert.ToInt32(tabla.Rows(i)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(i)(1).ToString())
                    lblnomcli.Location = New Point(x, y)
                End If
                If dato = "Codigo producto" Then


                    Dim sql2 As String = "SELECT drec_codpro from rpt_despacho_informe where ddes_rutcli= '" + TxtClirut.Text + "' and despacho = '" + txtfolio.Text.Trim() + "' "

                    Dim tabla2 As DataTable = fnc.ListarTablasSQL(sql2)

                    If tabla2.Rows.Count > 0 Then

                        If traecantidad = 1 Then
                            lblcodpro.Text = tabla2.Rows(0)(0).ToString()
                            lblcodpro.Visible = True
                        End If
                        If traecantidad = 2 Then
                            lblcodpro.Text = tabla2.Rows(0)(0).ToString()
                            lblcodpro2.Text = tabla2.Rows(1)(0).ToString()
                            lblcodpro.Visible = True
                            lblcodpro2.Visible = True
                        End If
                        If traecantidad = 3 Then
                            lblcodpro.Text = tabla2.Rows(0)(0).ToString()
                            lblcodpro2.Text = tabla2.Rows(1)(0).ToString()
                            lblcodpro3.Text = tabla2.Rows(2)(0).ToString()
                            lblcodpro.Visible = True
                            lblcodpro2.Visible = True
                            lblcodpro3.Visible = True
                        End If
                        If traecantidad = 4 Then
                            lblcodpro.Text = tabla2.Rows(0)(0).ToString()
                            lblcodpro2.Text = tabla2.Rows(1)(0).ToString()
                            lblcodpro3.Text = tabla2.Rows(2)(0).ToString()
                            lblcodpro4.Text = tabla2.Rows(3)(0).ToString()
                            lblcodpro.Visible = True
                            lblcodpro2.Visible = True
                            lblcodpro3.Visible = True
                            lblcodpro4.Visible = True
                        End If
                        If traecantidad = 5 Then
                            lblcodpro.Text = tabla2.Rows(0)(0).ToString()
                            lblcodpro2.Text = tabla2.Rows(1)(0).ToString()
                            lblcodpro3.Text = tabla2.Rows(2)(0).ToString()
                            lblcodpro4.Text = tabla2.Rows(3)(0).ToString()
                            lblcodpro5.Text = tabla2.Rows(4)(0).ToString()
                            lblcodpro.Visible = True
                            lblcodpro2.Visible = True
                            lblcodpro3.Visible = True
                            lblcodpro4.Visible = True
                            lblcodpro5.Visible = True
                        End If
                        If traecantidad = 6 Then
                            lblcodpro.Text = tabla2.Rows(0)(0).ToString()
                            lblcodpro2.Text = tabla2.Rows(1)(0).ToString()
                            lblcodpro3.Text = tabla2.Rows(2)(0).ToString()
                            lblcodpro4.Text = tabla2.Rows(3)(0).ToString()
                            lblcodpro5.Text = tabla2.Rows(4)(0).ToString()
                            lblcodpro6.Text = tabla2.Rows(5)(0).ToString()
                            lblcodpro.Visible = True
                            lblcodpro2.Visible = True
                            lblcodpro3.Visible = True
                            lblcodpro4.Visible = True
                            lblcodpro5.Visible = True
                            lblcodpro6.Visible = True
                        End If




                    End If

                    x = Convert.ToInt32(tabla.Rows(i)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(i)(1).ToString())

                    If traecantidad = 1 Then
                        lblcodpro.Location = New Point(x, y)
                    End If

                    If traecantidad = 2 Then
                        lblcodpro.Location = New Point(x, y)
                        lblcodpro2.Location = New Point(x, y + 15)
                    End If
                    If traecantidad = 3 Then
                        lblcodpro.Location = New Point(x, y)
                        lblcodpro2.Location = New Point(x, y + 15)
                        lblcodpro3.Location = New Point(x, y + 30)

                    End If
                    If traecantidad = 4 Then
                        lblcodpro.Location = New Point(x, y)
                        lblcodpro2.Location = New Point(x, y + 15)
                        lblcodpro3.Location = New Point(x, y + 30)
                        lblcodpro4.Location = New Point(x, y + 45)
                    End If
                    If traecantidad = 5 Then
                        lblcodpro.Location = New Point(x, y)
                        lblcodpro2.Location = New Point(x, y + 15)
                        lblcodpro3.Location = New Point(x, y + 30)
                        lblcodpro4.Location = New Point(x, y + 45)
                        lblcodpro5.Location = New Point(x, y + 60)
                    End If
                    If traecantidad = 6 Then
                        lblcodpro.Location = New Point(x, y)
                        lblcodpro2.Location = New Point(x, y + 15)
                        lblcodpro3.Location = New Point(x, y + 30)
                        lblcodpro4.Location = New Point(x, y + 45)
                        lblcodpro5.Location = New Point(x, y + 60)
                        lblcodpro6.Location = New Point(x, y + 75)




                    End If
                End If


                If dato = "Nombre producto" Then


                    Dim sql2 As String = "SELECT mae_descr from rpt_despacho_informe where ddes_rutcli= '" + TxtClirut.Text + "' and despacho = '" + txtfolio.Text.Trim() + "' "

                    Dim tabla2 As DataTable = fnc.ListarTablasSQL(sql2)

                    If tabla2.Rows.Count > 0 Then

                        If traecantidad = 1 Then
                            lblnompro.Text = tabla2.Rows(0)(0).ToString()
                            lblnompro.Visible = True
                        End If
                        If traecantidad = 2 Then
                            lblnompro.Text = tabla2.Rows(0)(0).ToString()
                            lblnompro2.Text = tabla2.Rows(1)(0).ToString()
                            lblnompro.Visible = True
                            lblnompro2.Visible = True
                        End If
                        If traecantidad = 3 Then
                            lblnompro.Text = tabla2.Rows(0)(0).ToString()
                            lblnompro2.Text = tabla2.Rows(1)(0).ToString()
                            lblnompro3.Text = tabla2.Rows(2)(0).ToString()
                            lblnompro.Visible = True
                            lblnompro2.Visible = True
                            lblnompro3.Visible = True
                        End If
                        If traecantidad = 4 Then
                            lblnompro.Text = tabla2.Rows(0)(0).ToString()
                            lblnompro2.Text = tabla2.Rows(1)(0).ToString()
                            lblnompro3.Text = tabla2.Rows(2)(0).ToString()
                            lblnompro4.Text = tabla2.Rows(3)(0).ToString()
                            lblnompro.Visible = True
                            lblnompro2.Visible = True
                            lblnompro3.Visible = True
                            lblnompro4.Visible = True
                        End If
                        If traecantidad = 5 Then
                            lblnompro.Text = tabla2.Rows(0)(0).ToString()
                            lblnompro2.Text = tabla2.Rows(1)(0).ToString()
                            lblnompro3.Text = tabla2.Rows(2)(0).ToString()
                            lblnompro4.Text = tabla2.Rows(3)(0).ToString()
                            lblnompro5.Text = tabla2.Rows(4)(0).ToString()
                            lblnompro.Visible = True
                            lblnompro2.Visible = True
                            lblnompro3.Visible = True
                            lblnompro4.Visible = True
                            lblnompro5.Visible = True
                        End If
                        If traecantidad = 6 Then
                            lblnompro.Text = tabla2.Rows(0)(0).ToString()
                            lblnompro2.Text = tabla2.Rows(1)(0).ToString()
                            lblnompro3.Text = tabla2.Rows(2)(0).ToString()
                            lblnompro4.Text = tabla2.Rows(3)(0).ToString()
                            lblnompro5.Text = tabla2.Rows(4)(0).ToString()
                            lblnompro6.Text = tabla2.Rows(5)(0).ToString()
                            lblnompro.Visible = True
                            lblnompro2.Visible = True
                            lblnompro3.Visible = True
                            lblnompro4.Visible = True
                            lblnompro5.Visible = True
                            lblnompro6.Visible = True
                        End If




                    End If

                    x = Convert.ToInt32(tabla.Rows(i)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(i)(1).ToString())

                    If traecantidad = 1 Then
                        lblnompro.Location = New Point(x, y)
                    End If

                    If traecantidad = 2 Then
                        lblnompro.Location = New Point(x, y)
                        lblnompro2.Location = New Point(x, y + 15)
                    End If
                    If traecantidad = 3 Then
                        lblnompro.Location = New Point(x, y)
                        lblnompro2.Location = New Point(x, y + 15)
                        lblnompro3.Location = New Point(x, y + 30)

                    End If
                    If traecantidad = 4 Then
                        lblnompro.Location = New Point(x, y)
                        lblnompro2.Location = New Point(x, y + 15)
                        lblnompro3.Location = New Point(x, y + 30)
                        lblnompro4.Location = New Point(x, y + 45)
                    End If
                    If traecantidad = 5 Then
                        lblnompro.Location = New Point(x, y)
                        lblnompro2.Location = New Point(x, y + 15)
                        lblnompro3.Location = New Point(x, y + 30)
                        lblnompro4.Location = New Point(x, y + 45)
                        lblnompro5.Location = New Point(x, y + 60)
                    End If
                    If traecantidad = 6 Then
                        lblnompro.Location = New Point(x, y)
                        lblnompro2.Location = New Point(x, y + 15)
                        lblnompro3.Location = New Point(x, y + 30)
                        lblnompro4.Location = New Point(x, y + 45)
                        lblnompro5.Location = New Point(x, y + 60)
                        lblnompro6.Location = New Point(x, y + 75)




                    End If
                End If
                If dato = "Unidades" Then


                    Dim sql2 As String = "SELECT unidades from rpt_despacho_informe where ddes_rutcli= '" + TxtClirut.Text + "' and despacho = '" + txtfolio.Text.Trim() + "' "

                    Dim tabla2 As DataTable = fnc.ListarTablasSQL(sql2)

                    If tabla2.Rows.Count > 0 Then

                        If traecantidad = 1 Then
                            lbluni.Text = tabla2.Rows(0)(0).ToString()
                            lbluni.Visible = True
                        End If
                        If traecantidad = 2 Then
                            lbluni.Text = tabla2.Rows(0)(0).ToString()
                            lbluni2.Text = tabla2.Rows(1)(0).ToString()
                            lbluni.Visible = True
                            lbluni2.Visible = True
                        End If
                        If traecantidad = 3 Then
                            lbluni.Text = tabla2.Rows(0)(0).ToString()
                            lbluni2.Text = tabla2.Rows(1)(0).ToString()
                            lbluni3.Text = tabla2.Rows(2)(0).ToString()
                            lbluni.Visible = True
                            lbluni2.Visible = True
                            lbluni3.Visible = True
                        End If
                        If traecantidad = 4 Then
                            lbluni.Text = tabla2.Rows(0)(0).ToString()
                            lbluni2.Text = tabla2.Rows(1)(0).ToString()
                            lbluni3.Text = tabla2.Rows(2)(0).ToString()
                            lbluni4.Text = tabla2.Rows(3)(0).ToString()
                            lbluni.Visible = True
                            lbluni2.Visible = True
                            lbluni3.Visible = True
                            lbluni4.Visible = True
                        End If
                        If traecantidad = 5 Then
                            lbluni.Text = tabla2.Rows(0)(0).ToString()
                            lbluni2.Text = tabla2.Rows(1)(0).ToString()
                            lbluni3.Text = tabla2.Rows(2)(0).ToString()
                            lbluni4.Text = tabla2.Rows(3)(0).ToString()
                            lbluni5.Text = tabla2.Rows(4)(0).ToString()
                            lbluni.Visible = True
                            lbluni2.Visible = True
                            lbluni3.Visible = True
                            lbluni4.Visible = True
                            lbluni5.Visible = True
                        End If
                        If traecantidad = 6 Then
                            lbluni.Text = tabla2.Rows(0)(0).ToString()
                            lbluni2.Text = tabla2.Rows(1)(0).ToString()
                            lbluni3.Text = tabla2.Rows(2)(0).ToString()
                            lbluni4.Text = tabla2.Rows(3)(0).ToString()
                            lbluni5.Text = tabla2.Rows(4)(0).ToString()
                            lbluni6.Text = tabla2.Rows(5)(0).ToString()
                            lbluni.Visible = True
                            lbluni2.Visible = True
                            lbluni3.Visible = True
                            lbluni4.Visible = True
                            lbluni5.Visible = True
                            lbluni6.Visible = True
                        End If




                    End If

                    x = Convert.ToInt32(tabla.Rows(i)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(i)(1).ToString())

                    If traecantidad = 1 Then
                        lbluni.Location = New Point(x, y)
                    End If

                    If traecantidad = 2 Then
                        lbluni.Location = New Point(x, y)
                        lbluni2.Location = New Point(x, y + 15)
                    End If
                    If traecantidad = 3 Then
                        lbluni.Location = New Point(x, y)
                        lbluni2.Location = New Point(x, y + 15)
                        lbluni3.Location = New Point(x, y + 30)

                    End If
                    If traecantidad = 4 Then
                        lbluni.Location = New Point(x, y)
                        lbluni2.Location = New Point(x, y + 15)
                        lbluni3.Location = New Point(x, y + 30)
                        lbluni4.Location = New Point(x, y + 45)
                    End If
                    If traecantidad = 5 Then
                        lbluni.Location = New Point(x, y)
                        lbluni2.Location = New Point(x, y + 15)
                        lbluni3.Location = New Point(x, y + 30)
                        lbluni4.Location = New Point(x, y + 45)
                        lbluni5.Location = New Point(x, y + 60)
                    End If
                    If traecantidad = 6 Then
                        lbluni.Location = New Point(x, y)
                        lbluni2.Location = New Point(x, y + 15)
                        lbluni3.Location = New Point(x, y + 30)
                        lbluni4.Location = New Point(x, y + 45)
                        lbluni5.Location = New Point(x, y + 60)
                        lbluni6.Location = New Point(x, y + 75)




                    End If
                End If

                If dato = "Kilos" Then


                    Dim sql2 As String = "SELECT kilos from rpt_despacho_informe where ddes_rutcli= '" + TxtClirut.Text + "' and despacho = '" + txtfolio.Text.Trim() + "' "

                    Dim tabla2 As DataTable = fnc.ListarTablasSQL(sql2)

                    If tabla2.Rows.Count > 0 Then

                        If traecantidad = 1 Then
                            lblkil.Text = tabla2.Rows(0)(0).ToString()
                            lblkil.Visible = True
                        End If
                        If traecantidad = 2 Then
                            lblkil.Text = tabla2.Rows(0)(0).ToString()
                            lblkil2.Text = tabla2.Rows(1)(0).ToString()
                            lblkil.Visible = True
                            lblkil2.Visible = True
                        End If
                        If traecantidad = 3 Then
                            lblkil.Text = tabla2.Rows(0)(0).ToString()
                            lblkil2.Text = tabla2.Rows(1)(0).ToString()
                            lblkil3.Text = tabla2.Rows(2)(0).ToString()
                            lblkil.Visible = True
                            lblkil2.Visible = True
                            lblkil3.Visible = True
                        End If
                        If traecantidad = 4 Then
                            lblkil.Text = tabla2.Rows(0)(0).ToString()
                            lblkil2.Text = tabla2.Rows(1)(0).ToString()
                            lblkil3.Text = tabla2.Rows(2)(0).ToString()
                            lblkil4.Text = tabla2.Rows(3)(0).ToString()
                            lblkil.Visible = True
                            lblkil2.Visible = True
                            lblkil3.Visible = True
                            lblkil4.Visible = True
                        End If
                        If traecantidad = 5 Then
                            lblkil.Text = tabla2.Rows(0)(0).ToString()
                            lblkil2.Text = tabla2.Rows(1)(0).ToString()
                            lblkil3.Text = tabla2.Rows(2)(0).ToString()
                            lblkil4.Text = tabla2.Rows(3)(0).ToString()
                            lblkil5.Text = tabla2.Rows(4)(0).ToString()
                            lblkil.Visible = True
                            lblkil2.Visible = True
                            lblkil3.Visible = True
                            lblkil4.Visible = True
                            lblkil5.Visible = True
                        End If
                        If traecantidad = 6 Then
                            lblkil.Text = tabla2.Rows(0)(0).ToString()
                            lblkil2.Text = tabla2.Rows(1)(0).ToString()
                            lblkil3.Text = tabla2.Rows(2)(0).ToString()
                            lblkil4.Text = tabla2.Rows(3)(0).ToString()
                            lblkil5.Text = tabla2.Rows(4)(0).ToString()
                            lblkil6.Text = tabla2.Rows(5)(0).ToString()
                            lblkil.Visible = True
                            lblkil2.Visible = True
                            lblkil3.Visible = True
                            lblkil4.Visible = True
                            lblkil5.Visible = True
                            lblkil6.Visible = True
                        End If




                    End If

                    x = Convert.ToInt32(tabla.Rows(i)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(i)(1).ToString())

                    If traecantidad = 1 Then
                        lblkil.Location = New Point(x, y)
                    End If

                    If traecantidad = 2 Then
                        lblkil.Location = New Point(x, y)
                        lblkil2.Location = New Point(x, y + 15)
                    End If
                    If traecantidad = 3 Then
                        lblkil.Location = New Point(x, y)
                        lblkil2.Location = New Point(x, y + 15)
                        lblkil3.Location = New Point(x, y + 30)

                    End If
                    If traecantidad = 4 Then
                        lblkil.Location = New Point(x, y)
                        lblkil2.Location = New Point(x, y + 15)
                        lblkil3.Location = New Point(x, y + 30)
                        lblkil4.Location = New Point(x, y + 45)
                    End If
                    If traecantidad = 5 Then
                        lblkil.Location = New Point(x, y)
                        lblkil2.Location = New Point(x, y + 15)
                        lblkil3.Location = New Point(x, y + 30)
                        lblkil4.Location = New Point(x, y + 45)
                        lblkil5.Location = New Point(x, y + 60)
                    End If
                    If traecantidad = 6 Then
                        lblkil.Location = New Point(x, y)
                        lblkil2.Location = New Point(x, y + 15)
                        lblkil3.Location = New Point(x, y + 30)
                        lblkil4.Location = New Point(x, y + 45)
                        lblkil5.Location = New Point(x, y + 60)
                        lblkil6.Location = New Point(x, y + 75)




                    End If
                End If

            Next

        End If
    End Sub





    Private Sub BtnImprimir_Click(sender As System.Object, e As System.EventArgs) Handles BtnImprimir.Click
        Imprimir()
    End Sub
    Public Sub print_PrintPage_10x08(ByVal sender As Object, ByVal e As PrintPageEventArgs)

        Dim direccion As String
        Dim producido As String
        Dim producto As String
        Dim codigoreferencia As String
        Dim clasificacion As String
        Dim pesoneto As String
        Dim vencimiento As String
     
        Dim xPos As Single = e.MarginBounds.Left

        ' Las fuentes a usar
        Dim prFont As New Font("Arial", 8, FontStyle.Bold)
        Dim Titulo As New Font("Arial", 18, FontStyle.Bold)
        Dim sql As String = "SELECT x,y,rutcli,dato from datos_informes where rutcli= '" + TxtClirut.Text + "' "

        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

        If tabla.Rows.Count > 0 Then


            For i As Integer = 0 To tabla.Rows.Count - 1

                Dim dato As String = tabla.Rows(i)(3).ToString()
                If dato = "Despacho" Then
                    lbldespacho.Text = txtfolio.Text
                    lbldespacho.Visible = True
                    x = Convert.ToInt32(tabla.Rows(i)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(i)(1).ToString())
                    'lbldespacho.Location = New Point(x, y)
                    Dim valxdes As Int32 = x - 111
                    Dim valydes As Int32 = y - 56
                    e.Graphics.DrawString(lbldespacho.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxdes, valydes)
                End If
                If dato = "Rut cliente" Then
                    If (TxtClirut.Text = "799842408") Then
                        lblrutcli.Text = "78408440K"
                    Else
                        lblrutcli.Text = TxtClirut.Text
                    End If
                    lblrutcli.Visible = True
                    x = Convert.ToInt32(tabla.Rows(i)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(i)(1).ToString())
                    'lblrutcli.Location = New Point(x, y)
                    Dim valxrutcli As Int32 = x - 111
                    Dim valyrutcli As Int32 = y - 56
                    e.Graphics.DrawString(lblrutcli.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxrutcli, valyrutcli)
                End If
                If dato = "Nombre cliente" Then
                    lblnomcli.Text = txtclinom.Text
                    lblnomcli.Visible = True
                    x = Convert.ToInt32(tabla.Rows(i)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(i)(1).ToString())
                    ' lblnomcli.Location = New Point(x, y)
                    Dim valxnomcli As Int32 = x - 111
                    Dim valynomcli As Int32 = y - 56
                    e.Graphics.DrawString(lblnomcli.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxnomcli, valynomcli)


                End If
                If dato = "Fecha" Then

                    x = Convert.ToInt32(tabla.Rows(i)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(i)(1).ToString())
                    ' lblnomcli.Location = New Point(x, y)
                    Dim valxfecha As Int32 = x - 111
                    Dim valyfecha As Int32 = y - 56
                    e.Graphics.DrawString(lblfecha.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxfecha, valyfecha)


                End If
                If dato = "Giro" Then

                    x = Convert.ToInt32(tabla.Rows(i)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(i)(1).ToString())
                    ' lblnomcli.Location = New Point(x, y)
                    Dim valxgiro As Int32 = x - 111
                    Dim valygiro As Int32 = y - 56
                    e.Graphics.DrawString(lblgiro.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxgiro, valygiro)


                End If
                If dato = "Direccion" Then

                    x = Convert.ToInt32(tabla.Rows(i)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(i)(1).ToString())
                    ' lblnomcli.Location = New Point(x, y)
                    Dim valxdir As Int32 = x - 111
                    Dim valydir As Int32 = y - 56
                    e.Graphics.DrawString(lbldireccion.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxdir, valydir)


                End If
                If dato = "Comuna" Then

                    x = Convert.ToInt32(tabla.Rows(i)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(i)(1).ToString())
                    ' lblnomcli.Location = New Point(x, y)
                    Dim valxcomu As Int32 = x - 111
                    Dim valycomu As Int32 = y - 56
                    e.Graphics.DrawString(lblcomuna.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxcomu, valycomu)


                End If

                If dato = "Nombre chofer" Then

                    x = Convert.ToInt32(tabla.Rows(i)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(i)(1).ToString())
                    ' lblnomcli.Location = New Point(x, y)
                    Dim valxnomcho As Int32 = x - 111
                    Dim valynomcho As Int32 = y - 56
                    e.Graphics.DrawString(lblnomcho.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxnomcho, valynomcho)


                End If

                If dato = "Rut chofer" Then

                    x = Convert.ToInt32(tabla.Rows(i)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(i)(1).ToString())
                    ' lblnomcli.Location = New Point(x, y)
                    Dim valxrutcho As Int32 = x - 111
                    Dim valyrutcho As Int32 = y - 56
                    e.Graphics.DrawString(lblrutcho.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxrutcho, valyrutcho)


                End If

                If dato = "Patente" Then

                    x = Convert.ToInt32(tabla.Rows(i)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(i)(1).ToString())
                    ' lblnomcli.Location = New Point(x, y)
                    Dim valxpat As Int32 = x - 111
                    Dim valypat As Int32 = y - 56
                    e.Graphics.DrawString(lblpatente.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxpat, valypat)


                End If
                If dato = "Observacion" Then

                    x = Convert.ToInt32(tabla.Rows(i)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(i)(1).ToString())
                    ' lblnomcli.Location = New Point(x, y)
                    Dim valxobs As Int32 = x - 111
                    Dim valyobs As Int32 = y - 56
                    e.Graphics.DrawString(lblobs.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxobs, valyobs)


                End If
                If dato = "Destino" Then

                    x = Convert.ToInt32(tabla.Rows(i)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(i)(1).ToString())
                    ' lblnomcli.Location = New Point(x, y)
                    Dim valxdes As Int32 = x - 111
                    Dim valydes As Int32 = y - 56
                    e.Graphics.DrawString(lbldestino.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxdes, valydes)
                    Dim valxdes2 As Int32 = x - 111
                    Dim valydes2 As Int32 = y - 56 + 15
                    e.Graphics.DrawString(lbldestino2.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxdes2, valydes2)
                    Dim valxdes3 As Int32 = x - 111
                    Dim valydes3 As Int32 = y - 56 + 30
                    e.Graphics.DrawString(lbldestino3.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxdes3, valydes3)


                End If
                If dato = "Codigo producto" Then


                    

                    x = Convert.ToInt32(tabla.Rows(i)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(i)(1).ToString())

                    If traecantidad = 1 Then
                        'lblcodpro.Location = New Point(x, y)
                        Dim valxcod1 As Int32 = x - 111
                        Dim valycod1 As Int32 = y - 56
                        e.Graphics.DrawString(lblcodpro.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxcod1, valycod1)
                    End If

                    If traecantidad = 2 Then
                        'lblcodpro.Location = New Point(x, y)
                        'lblcodpro2.Location = New Point(x, y + 15)
                        Dim valxcod1 As Int32 = x - 111
                        Dim valycod1 As Int32 = y - 56
                        e.Graphics.DrawString(lblcodpro.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxcod1, valycod1)
                        Dim valxcod2 As Int32 = x - 111
                        Dim valycod2 As Int32 = y - 56 + 15
                        e.Graphics.DrawString(lblcodpro2.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxcod2, valycod2)
                    End If
                    If traecantidad = 3 Then
                        'lblcodpro.Location = New Point(x, y)
                        'lblcodpro2.Location = New Point(x, y + 15)
                        'lblcodpro3.Location = New Point(x, y + 30)
                        Dim valxcod1 As Int32 = x - 111
                        Dim valycod1 As Int32 = y - 56
                        e.Graphics.DrawString(lblcodpro.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxcod1, valycod1)
                        Dim valxcod2 As Int32 = x - 111
                        Dim valycod2 As Int32 = y - 56 + 15
                        e.Graphics.DrawString(lblcodpro2.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxcod2, valycod2)
                        Dim valxcod3 As Int32 = x - 111
                        Dim valycod3 As Int32 = y - 56 + 30
                        e.Graphics.DrawString(lblcodpro3.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxcod3, valycod3)


                    End If
                    If traecantidad = 4 Then
                        'lblcodpro.Location = New Point(x, y)
                        'lblcodpro2.Location = New Point(x, y + 15)
                        'lblcodpro3.Location = New Point(x, y + 30)
                        'lblcodpro4.Location = New Point(x, y + 45)
                        Dim valxcod1 As Int32 = x - 111
                        Dim valycod1 As Int32 = y - 56
                        e.Graphics.DrawString(lblcodpro.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxcod1, valycod1)
                        Dim valxcod2 As Int32 = x - 111
                        Dim valycod2 As Int32 = y - 56 + 15
                        e.Graphics.DrawString(lblcodpro2.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxcod2, valycod2)
                        Dim valxcod3 As Int32 = x - 111
                        Dim valycod3 As Int32 = y - 56 + 30
                        e.Graphics.DrawString(lblcodpro3.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxcod3, valycod3)
                        Dim valxcod4 As Int32 = x - 111
                        Dim valycod4 As Int32 = y - 56 + 45
                        e.Graphics.DrawString(lblcodpro4.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxcod4, valycod4)




                    End If
                    If traecantidad = 5 Then
                        'lblcodpro.Location = New Point(x, y)
                        'lblcodpro2.Location = New Point(x, y + 15)
                        'lblcodpro3.Location = New Point(x, y + 30)
                        'lblcodpro4.Location = New Point(x, y + 45)
                        'lblcodpro5.Location = New Point(x, y + 60)
                        Dim valxcod1 As Int32 = x - 111
                        Dim valycod1 As Int32 = y - 56
                        e.Graphics.DrawString(lblcodpro.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxcod1, valycod1)
                        Dim valxcod2 As Int32 = x - 111
                        Dim valycod2 As Int32 = y - 56 + 15
                        e.Graphics.DrawString(lblcodpro2.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxcod2, valycod2)
                        Dim valxcod3 As Int32 = x - 111
                        Dim valycod3 As Int32 = y - 56 + 30
                        e.Graphics.DrawString(lblcodpro3.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxcod3, valycod3)
                        Dim valxcod4 As Int32 = x - 111
                        Dim valycod4 As Int32 = y - 56 + 45
                        e.Graphics.DrawString(lblcodpro4.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxcod4, valycod4)
                        Dim valxcod5 As Int32 = x - 111
                        Dim valycod5 As Int32 = y - 56 + 60
                        e.Graphics.DrawString(lblcodpro5.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxcod5, valycod5)




                    End If
                    If traecantidad = 6 Then
                        'lblcodpro.Location = New Point(x, y)
                        'lblcodpro2.Location = New Point(x, y + 15)
                        'lblcodpro3.Location = New Point(x, y + 30)
                        'lblcodpro4.Location = New Point(x, y + 45)
                        'lblcodpro5.Location = New Point(x, y + 60)
                        'lblcodpro6.Location = New Point(x, y + 75)
                        Dim valxcod1 As Int32 = x - 111
                        Dim valycod1 As Int32 = y - 56
                        e.Graphics.DrawString(lblcodpro.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxcod1, valycod1)
                        Dim valxcod2 As Int32 = x - 111
                        Dim valycod2 As Int32 = y - 56 + 15
                        e.Graphics.DrawString(lblcodpro2.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxcod2, valycod2)
                        Dim valxcod3 As Int32 = x - 111
                        Dim valycod3 As Int32 = y - 56 + 30
                        e.Graphics.DrawString(lblcodpro3.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxcod3, valycod3)
                        Dim valxcod4 As Int32 = x - 111
                        Dim valycod4 As Int32 = y - 56 + 45
                        e.Graphics.DrawString(lblcodpro4.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxcod4, valycod4)
                        Dim valxcod5 As Int32 = x - 111
                        Dim valycod5 As Int32 = y - 56 + 60
                        e.Graphics.DrawString(lblcodpro5.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxcod5, valycod5)
                        Dim valxcod6 As Int32 = x - 111
                        Dim valycod6 As Int32 = y - 56 + 75
                        e.Graphics.DrawString(lblcodpro6.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxcod6, valycod6)


                    End If


                    If traecantidad = 7 Then
                        Dim valxcod1 As Int32 = x - 111
                        Dim valycod1 As Int32 = y - 56
                        e.Graphics.DrawString(lblcodpro.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxcod1, valycod1)
                        Dim valxcod2 As Int32 = x - 111
                        Dim valycod2 As Int32 = y - 56 + 15
                        e.Graphics.DrawString(lblcodpro2.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxcod2, valycod2)
                        Dim valxcod3 As Int32 = x - 111
                        Dim valycod3 As Int32 = y - 56 + 30
                        e.Graphics.DrawString(lblcodpro3.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxcod3, valycod3)
                        Dim valxcod4 As Int32 = x - 111
                        Dim valycod4 As Int32 = y - 56 + 45
                        e.Graphics.DrawString(lblcodpro4.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxcod4, valycod4)
                        Dim valxcod5 As Int32 = x - 111
                        Dim valycod5 As Int32 = y - 56 + 60
                        e.Graphics.DrawString(lblcodpro5.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxcod5, valycod5)
                        Dim valxcod6 As Int32 = x - 111
                        Dim valycod6 As Int32 = y - 56 + 75
                        e.Graphics.DrawString(lblcodpro6.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxcod6, valycod6)
                        Dim valxcod7 As Int32 = x - 111
                        Dim valycod7 As Int32 = y - 56 + 90
                        e.Graphics.DrawString(lblcodpro7.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxcod7, valycod7)
                    End If
                    If traecantidad = 8 Then
                        Dim valxcod1 As Int32 = x - 111
                        Dim valycod1 As Int32 = y - 56
                        e.Graphics.DrawString(lblcodpro.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxcod1, valycod1)
                        Dim valxcod2 As Int32 = x - 111
                        Dim valycod2 As Int32 = y - 56 + 15
                        e.Graphics.DrawString(lblcodpro2.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxcod2, valycod2)
                        Dim valxcod3 As Int32 = x - 111
                        Dim valycod3 As Int32 = y - 56 + 30
                        e.Graphics.DrawString(lblcodpro3.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxcod3, valycod3)
                        Dim valxcod4 As Int32 = x - 111
                        Dim valycod4 As Int32 = y - 56 + 45
                        e.Graphics.DrawString(lblcodpro4.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxcod4, valycod4)
                        Dim valxcod5 As Int32 = x - 111
                        Dim valycod5 As Int32 = y - 56 + 60
                        e.Graphics.DrawString(lblcodpro5.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxcod5, valycod5)
                        Dim valxcod6 As Int32 = x - 111
                        Dim valycod6 As Int32 = y - 56 + 75
                        e.Graphics.DrawString(lblcodpro6.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxcod6, valycod6)
                        Dim valxcod7 As Int32 = x - 111
                        Dim valycod7 As Int32 = y - 56 + 90
                        e.Graphics.DrawString(lblcodpro7.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxcod7, valycod7)
                        Dim valxcod8 As Int32 = x - 111
                        Dim valycod8 As Int32 = y - 56 + 105
                        e.Graphics.DrawString(lblcodpro8.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxcod8, valycod8)
                    End If
                    If traecantidad = 9 Then
                        Dim valxcod1 As Int32 = x - 111
                        Dim valycod1 As Int32 = y - 56
                        e.Graphics.DrawString(lblcodpro.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxcod1, valycod1)
                        Dim valxcod2 As Int32 = x - 111
                        Dim valycod2 As Int32 = y - 56 + 15
                        e.Graphics.DrawString(lblcodpro2.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxcod2, valycod2)
                        Dim valxcod3 As Int32 = x - 111
                        Dim valycod3 As Int32 = y - 56 + 30
                        e.Graphics.DrawString(lblcodpro3.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxcod3, valycod3)
                        Dim valxcod4 As Int32 = x - 111
                        Dim valycod4 As Int32 = y - 56 + 45
                        e.Graphics.DrawString(lblcodpro4.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxcod4, valycod4)
                        Dim valxcod5 As Int32 = x - 111
                        Dim valycod5 As Int32 = y - 56 + 60
                        e.Graphics.DrawString(lblcodpro5.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxcod5, valycod5)
                        Dim valxcod6 As Int32 = x - 111
                        Dim valycod6 As Int32 = y - 56 + 75
                        e.Graphics.DrawString(lblcodpro6.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxcod6, valycod6)
                        Dim valxcod7 As Int32 = x - 111
                        Dim valycod7 As Int32 = y - 56 + 90
                        e.Graphics.DrawString(lblcodpro7.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxcod7, valycod7)
                        Dim valxcod8 As Int32 = x - 111
                        Dim valycod8 As Int32 = y - 56 + 105
                        e.Graphics.DrawString(lblcodpro8.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxcod8, valycod8)
                        Dim valxcod9 As Int32 = x - 111
                        Dim valycod9 As Int32 = y - 56 + 120
                        e.Graphics.DrawString(lblcodpro9.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxcod9, valycod9)
                    End If
                    If traecantidad = 10 Then
                        Dim valxcod1 As Int32 = x - 111
                        Dim valycod1 As Int32 = y - 56
                        e.Graphics.DrawString(lblcodpro.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxcod1, valycod1)
                        Dim valxcod2 As Int32 = x - 111
                        Dim valycod2 As Int32 = y - 56 + 15
                        e.Graphics.DrawString(lblcodpro2.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxcod2, valycod2)
                        Dim valxcod3 As Int32 = x - 111
                        Dim valycod3 As Int32 = y - 56 + 30
                        e.Graphics.DrawString(lblcodpro3.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxcod3, valycod3)
                        Dim valxcod4 As Int32 = x - 111
                        Dim valycod4 As Int32 = y - 56 + 45
                        e.Graphics.DrawString(lblcodpro4.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxcod4, valycod4)
                        Dim valxcod5 As Int32 = x - 111
                        Dim valycod5 As Int32 = y - 56 + 60
                        e.Graphics.DrawString(lblcodpro5.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxcod5, valycod5)
                        Dim valxcod6 As Int32 = x - 111
                        Dim valycod6 As Int32 = y - 56 + 75
                        e.Graphics.DrawString(lblcodpro6.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxcod6, valycod6)
                        Dim valxcod7 As Int32 = x - 111
                        Dim valycod7 As Int32 = y - 56 + 90
                        e.Graphics.DrawString(lblcodpro7.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxcod7, valycod7)
                        Dim valxcod8 As Int32 = x - 111
                        Dim valycod8 As Int32 = y - 56 + 105
                        e.Graphics.DrawString(lblcodpro8.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxcod8, valycod8)
                        Dim valxcod9 As Int32 = x - 111
                        Dim valycod9 As Int32 = y - 56 + 120
                        e.Graphics.DrawString(lblcodpro9.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxcod9, valycod9)
                        Dim valxcod10 As Int32 = x - 111
                        Dim valycod10 As Int32 = y - 56 + 135
                        e.Graphics.DrawString(lblcodpro10.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxcod10, valycod10)
                    End If
                    If traecantidad = 11 Then
                        Dim valxcod1 As Int32 = x - 111
                        Dim valycod1 As Int32 = y - 56
                        e.Graphics.DrawString(lblcodpro.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxcod1, valycod1)
                        Dim valxcod2 As Int32 = x - 111
                        Dim valycod2 As Int32 = y - 56 + 15
                        e.Graphics.DrawString(lblcodpro2.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxcod2, valycod2)
                        Dim valxcod3 As Int32 = x - 111
                        Dim valycod3 As Int32 = y - 56 + 30
                        e.Graphics.DrawString(lblcodpro3.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxcod3, valycod3)
                        Dim valxcod4 As Int32 = x - 111
                        Dim valycod4 As Int32 = y - 56 + 45
                        e.Graphics.DrawString(lblcodpro4.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxcod4, valycod4)
                        Dim valxcod5 As Int32 = x - 111
                        Dim valycod5 As Int32 = y - 56 + 60
                        e.Graphics.DrawString(lblcodpro5.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxcod5, valycod5)
                        Dim valxcod6 As Int32 = x - 111
                        Dim valycod6 As Int32 = y - 56 + 75
                        e.Graphics.DrawString(lblcodpro6.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxcod6, valycod6)
                        Dim valxcod7 As Int32 = x - 111
                        Dim valycod7 As Int32 = y - 56 + 90
                        e.Graphics.DrawString(lblcodpro7.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxcod7, valycod7)
                        Dim valxcod8 As Int32 = x - 111
                        Dim valycod8 As Int32 = y - 56 + 105
                        e.Graphics.DrawString(lblcodpro8.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxcod8, valycod8)
                        Dim valxcod9 As Int32 = x - 111
                        Dim valycod9 As Int32 = y - 56 + 120
                        e.Graphics.DrawString(lblcodpro9.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxcod9, valycod9)
                        Dim valxcod10 As Int32 = x - 111
                        Dim valycod10 As Int32 = y - 56 + 135
                        e.Graphics.DrawString(lblcodpro10.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxcod10, valycod10)
                        Dim valxcod11 As Int32 = x - 111
                        Dim valycod11 As Int32 = y - 56 + 150
                        e.Graphics.DrawString(lblcodpro11.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxcod11, valycod11)
                    End If
                    If traecantidad = 12 Then
                        Dim valxcod1 As Int32 = x - 111
                        Dim valycod1 As Int32 = y - 56
                        e.Graphics.DrawString(lblcodpro.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxcod1, valycod1)
                        Dim valxcod2 As Int32 = x - 111
                        Dim valycod2 As Int32 = y - 56 + 15
                        e.Graphics.DrawString(lblcodpro2.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxcod2, valycod2)
                        Dim valxcod3 As Int32 = x - 111
                        Dim valycod3 As Int32 = y - 56 + 30
                        e.Graphics.DrawString(lblcodpro3.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxcod3, valycod3)
                        Dim valxcod4 As Int32 = x - 111
                        Dim valycod4 As Int32 = y - 56 + 45
                        e.Graphics.DrawString(lblcodpro4.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxcod4, valycod4)
                        Dim valxcod5 As Int32 = x - 111
                        Dim valycod5 As Int32 = y - 56 + 60
                        e.Graphics.DrawString(lblcodpro5.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxcod5, valycod5)
                        Dim valxcod6 As Int32 = x - 111
                        Dim valycod6 As Int32 = y - 56 + 75
                        e.Graphics.DrawString(lblcodpro6.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxcod6, valycod6)
                        Dim valxcod7 As Int32 = x - 111
                        Dim valycod7 As Int32 = y - 56 + 90
                        e.Graphics.DrawString(lblcodpro7.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxcod7, valycod7)
                        Dim valxcod8 As Int32 = x - 111
                        Dim valycod8 As Int32 = y - 56 + 105
                        e.Graphics.DrawString(lblcodpro8.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxcod8, valycod8)
                        Dim valxcod9 As Int32 = x - 111
                        Dim valycod9 As Int32 = y - 56 + 120
                        e.Graphics.DrawString(lblcodpro9.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxcod9, valycod9)
                        Dim valxcod10 As Int32 = x - 111
                        Dim valycod10 As Int32 = y - 56 + 135
                        e.Graphics.DrawString(lblcodpro10.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxcod10, valycod10)
                        Dim valxcod11 As Int32 = x - 111
                        Dim valycod11 As Int32 = y - 56 + 150
                        e.Graphics.DrawString(lblcodpro11.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxcod11, valycod11)
                        Dim valxcod12 As Int32 = x - 111
                        Dim valycod12 As Int32 = y - 56 + 165
                        e.Graphics.DrawString(lblcodpro12.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxcod12, valycod12)
                    End If
                End If

                If dato = "Nombre producto" Then
                    x = Convert.ToInt32(tabla.Rows(i)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(i)(1).ToString())

                    If traecantidad = 1 Then
                        'lblnompro.Location = New Point(x, y)
                        Dim valxnp1 As Int32 = x - 111
                        Dim valynp1 As Int32 = y - 56
                        e.Graphics.DrawString(lblnompro.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxnp1, valynp1)
                    End If

                    If traecantidad = 2 Then
                        'lblnompro.Location = New Point(x, y)
                        'lblnompro2.Location = New Point(x, y + 15)

                        Dim valxnp1 As Int32 = x - 111
                        Dim valynp1 As Int32 = y - 56
                        e.Graphics.DrawString(lblnompro.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxnp1, valynp1)
                        Dim valxnp2 As Int32 = x - 111
                        Dim valynp2 As Int32 = y - 56 + 15
                        e.Graphics.DrawString(lblnompro2.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxnp2, valynp2)

                    End If
                    If traecantidad = 3 Then
                        'lblnompro.Location = New Point(x, y)
                        'lblnompro2.Location = New Point(x, y + 15)
                        'lblnompro3.Location = New Point(x, y + 30)
                        Dim valxnp1 As Int32 = x - 111
                        Dim valynp1 As Int32 = y - 56
                        e.Graphics.DrawString(lblnompro.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxnp1, valynp1)
                        Dim valxnp2 As Int32 = x - 111
                        Dim valynp2 As Int32 = y - 56 + 15
                        e.Graphics.DrawString(lblnompro2.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxnp2, valynp2)
                        Dim valxnp3 As Int32 = x - 111
                        Dim valynp3 As Int32 = y - 56 + 30
                        e.Graphics.DrawString(lblnompro3.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxnp3, valynp3)
                    End If
                    If traecantidad = 4 Then
                        'lblnompro.Location = New Point(x, y)
                        'lblnompro2.Location = New Point(x, y + 15)
                        'lblnompro3.Location = New Point(x, y + 30)
                        'lblnompro4.Location = New Point(x, y + 45)
                        Dim valxnp1 As Int32 = x - 111
                        Dim valynp1 As Int32 = y - 56
                        e.Graphics.DrawString(lblnompro.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxnp1, valynp1)
                        Dim valxnp2 As Int32 = x - 111
                        Dim valynp2 As Int32 = y - 56 + 15
                        e.Graphics.DrawString(lblnompro2.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxnp2, valynp2)
                        Dim valxnp3 As Int32 = x - 111
                        Dim valynp3 As Int32 = y - 56 + 30
                        e.Graphics.DrawString(lblnompro3.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxnp3, valynp3)
                        Dim valxnp4 As Int32 = x - 111
                        Dim valynp4 As Int32 = y - 56 + 45
                        e.Graphics.DrawString(lblnompro4.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxnp4, valynp4)

                    End If
                    If traecantidad = 5 Then
                        'lblnompro.Location = New Point(x, y)
                        'lblnompro2.Location = New Point(x, y + 15)
                        'lblnompro3.Location = New Point(x, y + 30)
                        'lblnompro4.Location = New Point(x, y + 45)
                        'lblnompro5.Location = New Point(x, y + 60)
                        Dim valxnp1 As Int32 = x - 111
                        Dim valynp1 As Int32 = y - 56
                        e.Graphics.DrawString(lblnompro.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxnp1, valynp1)
                        Dim valxnp2 As Int32 = x - 111
                        Dim valynp2 As Int32 = y - 56 + 15
                        e.Graphics.DrawString(lblnompro2.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxnp2, valynp2)
                        Dim valxnp3 As Int32 = x - 111
                        Dim valynp3 As Int32 = y - 56 + 30
                        e.Graphics.DrawString(lblnompro3.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxnp3, valynp3)
                        Dim valxnp4 As Int32 = x - 111
                        Dim valynp4 As Int32 = y - 56 + 45
                        e.Graphics.DrawString(lblnompro4.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxnp4, valynp4)
                        Dim valxnp5 As Int32 = x - 111
                        Dim valynp5 As Int32 = y - 56 + 60
                        e.Graphics.DrawString(lblnompro5.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxnp5, valynp5)
                    End If
                    If traecantidad = 6 Then
                        'lblnompro.Location = New Point(x, y)
                        'lblnompro2.Location = New Point(x, y + 15)
                        'lblnompro3.Location = New Point(x, y + 30)
                        'lblnompro4.Location = New Point(x, y + 45)
                        'lblnompro5.Location = New Point(x, y + 60)
                        'lblnompro6.Location = New Point(x, y + 75)
                        Dim valxnp1 As Int32 = x - 111
                        Dim valynp1 As Int32 = y - 56
                        e.Graphics.DrawString(lblnompro.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxnp1, valynp1)
                        Dim valxnp2 As Int32 = x - 111
                        Dim valynp2 As Int32 = y - 56 + 15
                        e.Graphics.DrawString(lblnompro2.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxnp2, valynp2)
                        Dim valxnp3 As Int32 = x - 111
                        Dim valynp3 As Int32 = y - 56 + 30
                        e.Graphics.DrawString(lblnompro3.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxnp3, valynp3)
                        Dim valxnp4 As Int32 = x - 111
                        Dim valynp4 As Int32 = y - 56 + 45
                        e.Graphics.DrawString(lblnompro4.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxnp4, valynp4)
                        Dim valxnp5 As Int32 = x - 111
                        Dim valynp5 As Int32 = y - 56 + 60
                        e.Graphics.DrawString(lblnompro5.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxnp5, valynp5)
                        Dim valxnp6 As Int32 = x - 111
                        Dim valynp6 As Int32 = y - 56 + 75
                        e.Graphics.DrawString(lblnompro6.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxnp6, valynp6)


                    End If

                    If traecantidad = 7 Then
                        Dim valxnp1 As Int32 = x - 111
                        Dim valynp1 As Int32 = y - 56
                        e.Graphics.DrawString(lblnompro.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxnp1, valynp1)
                        Dim valxnp2 As Int32 = x - 111
                        Dim valynp2 As Int32 = y - 56 + 15
                        e.Graphics.DrawString(lblnompro2.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxnp2, valynp2)
                        Dim valxnp3 As Int32 = x - 111
                        Dim valynp3 As Int32 = y - 56 + 30
                        e.Graphics.DrawString(lblnompro3.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxnp3, valynp3)
                        Dim valxnp4 As Int32 = x - 111
                        Dim valynp4 As Int32 = y - 56 + 45
                        e.Graphics.DrawString(lblnompro4.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxnp4, valynp4)
                        Dim valxnp5 As Int32 = x - 111
                        Dim valynp5 As Int32 = y - 56 + 60
                        e.Graphics.DrawString(lblnompro5.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxnp5, valynp5)
                        Dim valxnp6 As Int32 = x - 111
                        Dim valynp6 As Int32 = y - 56 + 75
                        e.Graphics.DrawString(lblnompro6.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxnp6, valynp6)
                        Dim valxnp7 As Int32 = x - 111
                        Dim valynp7 As Int32 = y - 56 + 90
                        e.Graphics.DrawString(lblnompro7.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxnp7, valynp7)
                    End If
                    If traecantidad = 8 Then
                        Dim valxnp1 As Int32 = x - 111
                        Dim valynp1 As Int32 = y - 56
                        e.Graphics.DrawString(lblnompro.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxnp1, valynp1)
                        Dim valxnp2 As Int32 = x - 111
                        Dim valynp2 As Int32 = y - 56 + 15
                        e.Graphics.DrawString(lblnompro2.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxnp2, valynp2)
                        Dim valxnp3 As Int32 = x - 111
                        Dim valynp3 As Int32 = y - 56 + 30
                        e.Graphics.DrawString(lblnompro3.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxnp3, valynp3)
                        Dim valxnp4 As Int32 = x - 111
                        Dim valynp4 As Int32 = y - 56 + 45
                        e.Graphics.DrawString(lblnompro4.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxnp4, valynp4)
                        Dim valxnp5 As Int32 = x - 111
                        Dim valynp5 As Int32 = y - 56 + 60
                        e.Graphics.DrawString(lblnompro5.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxnp5, valynp5)
                        Dim valxnp6 As Int32 = x - 111
                        Dim valynp6 As Int32 = y - 56 + 75
                        e.Graphics.DrawString(lblnompro6.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxnp6, valynp6)
                        Dim valxnp7 As Int32 = x - 111
                        Dim valynp7 As Int32 = y - 56 + 90
                        e.Graphics.DrawString(lblnompro7.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxnp7, valynp7)
                        Dim valxnp8 As Int32 = x - 111
                        Dim valynp8 As Int32 = y - 56 + 105
                        e.Graphics.DrawString(lblnompro8.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxnp8, valynp8)
                    End If
                    If traecantidad = 9 Then
                        Dim valxnp1 As Int32 = x - 111
                        Dim valynp1 As Int32 = y - 56
                        e.Graphics.DrawString(lblnompro.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxnp1, valynp1)
                        Dim valxnp2 As Int32 = x - 111
                        Dim valynp2 As Int32 = y - 56 + 15
                        e.Graphics.DrawString(lblnompro2.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxnp2, valynp2)
                        Dim valxnp3 As Int32 = x - 111
                        Dim valynp3 As Int32 = y - 56 + 30
                        e.Graphics.DrawString(lblnompro3.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxnp3, valynp3)
                        Dim valxnp4 As Int32 = x - 111
                        Dim valynp4 As Int32 = y - 56 + 45
                        e.Graphics.DrawString(lblnompro4.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxnp4, valynp4)
                        Dim valxnp5 As Int32 = x - 111
                        Dim valynp5 As Int32 = y - 56 + 60
                        e.Graphics.DrawString(lblnompro5.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxnp5, valynp5)
                        Dim valxnp6 As Int32 = x - 111
                        Dim valynp6 As Int32 = y - 56 + 75
                        e.Graphics.DrawString(lblnompro6.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxnp6, valynp6)
                        Dim valxnp7 As Int32 = x - 111
                        Dim valynp7 As Int32 = y - 56 + 90
                        e.Graphics.DrawString(lblnompro7.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxnp7, valynp7)
                        Dim valxnp8 As Int32 = x - 111
                        Dim valynp8 As Int32 = y - 56 + 105
                        e.Graphics.DrawString(lblnompro8.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxnp8, valynp8)
                        Dim valxnp9 As Int32 = x - 111
                        Dim valynp9 As Int32 = y - 56 + 120
                        e.Graphics.DrawString(lblnompro9.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxnp9, valynp9)
                    End If
                    If traecantidad = 10 Then
                        Dim valxnp1 As Int32 = x - 111
                        Dim valynp1 As Int32 = y - 56
                        e.Graphics.DrawString(lblnompro.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxnp1, valynp1)
                        Dim valxnp2 As Int32 = x - 111
                        Dim valynp2 As Int32 = y - 56 + 15
                        e.Graphics.DrawString(lblnompro2.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxnp2, valynp2)
                        Dim valxnp3 As Int32 = x - 111
                        Dim valynp3 As Int32 = y - 56 + 30
                        e.Graphics.DrawString(lblnompro3.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxnp3, valynp3)
                        Dim valxnp4 As Int32 = x - 111
                        Dim valynp4 As Int32 = y - 56 + 45
                        e.Graphics.DrawString(lblnompro4.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxnp4, valynp4)
                        Dim valxnp5 As Int32 = x - 111
                        Dim valynp5 As Int32 = y - 56 + 60
                        e.Graphics.DrawString(lblnompro5.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxnp5, valynp5)
                        Dim valxnp6 As Int32 = x - 111
                        Dim valynp6 As Int32 = y - 56 + 75
                        e.Graphics.DrawString(lblnompro6.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxnp6, valynp6)
                        Dim valxnp7 As Int32 = x - 111
                        Dim valynp7 As Int32 = y - 56 + 90
                        e.Graphics.DrawString(lblnompro7.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxnp7, valynp7)
                        Dim valxnp8 As Int32 = x - 111
                        Dim valynp8 As Int32 = y - 56 + 105
                        e.Graphics.DrawString(lblnompro8.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxnp8, valynp8)
                        Dim valxnp9 As Int32 = x - 111
                        Dim valynp9 As Int32 = y - 56 + 120
                        e.Graphics.DrawString(lblnompro9.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxnp9, valynp9)
                        Dim valxnp10 As Int32 = x - 111
                        Dim valynp10 As Int32 = y - 56 + 135
                        e.Graphics.DrawString(lblnompro10.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxnp10, valynp10)
                    End If
                    If traecantidad = 11 Then
                        Dim valxnp1 As Int32 = x - 111
                        Dim valynp1 As Int32 = y - 56
                        e.Graphics.DrawString(lblnompro.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxnp1, valynp1)
                        Dim valxnp2 As Int32 = x - 111
                        Dim valynp2 As Int32 = y - 56 + 15
                        e.Graphics.DrawString(lblnompro2.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxnp2, valynp2)
                        Dim valxnp3 As Int32 = x - 111
                        Dim valynp3 As Int32 = y - 56 + 30
                        e.Graphics.DrawString(lblnompro3.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxnp3, valynp3)
                        Dim valxnp4 As Int32 = x - 111
                        Dim valynp4 As Int32 = y - 56 + 45
                        e.Graphics.DrawString(lblnompro4.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxnp4, valynp4)
                        Dim valxnp5 As Int32 = x - 111
                        Dim valynp5 As Int32 = y - 56 + 60
                        e.Graphics.DrawString(lblnompro5.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxnp5, valynp5)
                        Dim valxnp6 As Int32 = x - 111
                        Dim valynp6 As Int32 = y - 56 + 75
                        e.Graphics.DrawString(lblnompro6.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxnp6, valynp6)
                        Dim valxnp7 As Int32 = x - 111
                        Dim valynp7 As Int32 = y - 56 + 90
                        e.Graphics.DrawString(lblnompro7.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxnp7, valynp7)
                        Dim valxnp8 As Int32 = x - 111
                        Dim valynp8 As Int32 = y - 56 + 105
                        e.Graphics.DrawString(lblnompro8.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxnp8, valynp8)
                        Dim valxnp9 As Int32 = x - 111
                        Dim valynp9 As Int32 = y - 56 + 120
                        e.Graphics.DrawString(lblnompro9.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxnp9, valynp9)
                        Dim valxnp10 As Int32 = x - 111
                        Dim valynp10 As Int32 = y - 56 + 135
                        e.Graphics.DrawString(lblnompro10.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxnp10, valynp10)
                        Dim valxnp11 As Int32 = x - 111
                        Dim valynp11 As Int32 = y - 56 + 150
                        e.Graphics.DrawString(lblnompro11.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxnp11, valynp11)
                    End If
                    If traecantidad = 12 Then
                        Dim valxnp1 As Int32 = x - 111
                        Dim valynp1 As Int32 = y - 56
                        e.Graphics.DrawString(lblnompro.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxnp1, valynp1)
                        Dim valxnp2 As Int32 = x - 111
                        Dim valynp2 As Int32 = y - 56 + 15
                        e.Graphics.DrawString(lblnompro2.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxnp2, valynp2)
                        Dim valxnp3 As Int32 = x - 111
                        Dim valynp3 As Int32 = y - 56 + 30
                        e.Graphics.DrawString(lblnompro3.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxnp3, valynp3)
                        Dim valxnp4 As Int32 = x - 111
                        Dim valynp4 As Int32 = y - 56 + 45
                        e.Graphics.DrawString(lblnompro4.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxnp4, valynp4)
                        Dim valxnp5 As Int32 = x - 111
                        Dim valynp5 As Int32 = y - 56 + 60
                        e.Graphics.DrawString(lblnompro5.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxnp5, valynp5)
                        Dim valxnp6 As Int32 = x - 111
                        Dim valynp6 As Int32 = y - 56 + 75
                        e.Graphics.DrawString(lblnompro6.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxnp6, valynp6)
                        Dim valxnp7 As Int32 = x - 111
                        Dim valynp7 As Int32 = y - 56 + 90
                        e.Graphics.DrawString(lblnompro7.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxnp7, valynp7)
                        Dim valxnp8 As Int32 = x - 111
                        Dim valynp8 As Int32 = y - 56 + 105
                        e.Graphics.DrawString(lblnompro8.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxnp8, valynp8)
                        Dim valxnp9 As Int32 = x - 111
                        Dim valynp9 As Int32 = y - 56 + 120
                        e.Graphics.DrawString(lblnompro9.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxnp9, valynp9)
                        Dim valxnp10 As Int32 = x - 111
                        Dim valynp10 As Int32 = y - 56 + 135
                        e.Graphics.DrawString(lblnompro10.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxnp10, valynp10)
                        Dim valxnp11 As Int32 = x - 111
                        Dim valynp11 As Int32 = y - 56 + 150
                        e.Graphics.DrawString(lblnompro11.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxnp11, valynp11)
                        Dim valxnp12 As Int32 = x - 111
                        Dim valynp12 As Int32 = y - 56 + 165
                        e.Graphics.DrawString(lblnompro12.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxnp12, valynp12)
                    End If

                End If
                If dato = "Unidades" Then


                   

                    x = Convert.ToInt32(tabla.Rows(i)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(i)(1).ToString())

                    If traecantidad = 1 Then
                        '  lbluni.Location = New Point(x, y)

                        Dim valxu1 As Int32 = x - 111
                        Dim valyu1 As Int32 = y - 56
                        e.Graphics.DrawString(lbluni.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxu1, valyu1)
                    End If

                    If traecantidad = 2 Then
                        'lbluni.Location = New Point(x, y)
                        'lbluni2.Location = New Point(x, y + 15)
                        Dim valxu1 As Int32 = x - 111
                        Dim valyu1 As Int32 = y - 56
                        e.Graphics.DrawString(lbluni.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxu1, valyu1)
                        Dim valxu2 As Int32 = x - 111
                        Dim valyu2 As Int32 = y - 56 + 15
                        e.Graphics.DrawString(lbluni2.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxu2, valyu2)
                    End If
                    If traecantidad = 3 Then
                        'lbluni.Location = New Point(x, y)
                        'lbluni2.Location = New Point(x, y + 15)
                        'lbluni3.Location = New Point(x, y + 30)
                        Dim valxu1 As Int32 = x - 111
                        Dim valyu1 As Int32 = y - 56
                        e.Graphics.DrawString(lbluni.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxu1, valyu1)
                        Dim valxu2 As Int32 = x - 111
                        Dim valyu2 As Int32 = y - 56 + 15
                        e.Graphics.DrawString(lbluni2.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxu2, valyu2)
                        Dim valxu3 As Int32 = x - 111
                        Dim valyu3 As Int32 = y - 56 + 30
                        e.Graphics.DrawString(lbluni3.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxu3, valyu3)

                    End If
                    If traecantidad = 4 Then
                        'lbluni.Location = New Point(x, y)
                        'lbluni2.Location = New Point(x, y + 15)
                        'lbluni3.Location = New Point(x, y + 30)
                        'lbluni4.Location = New Point(x, y + 45)
                        Dim valxu1 As Int32 = x - 111
                        Dim valyu1 As Int32 = y - 56
                        e.Graphics.DrawString(lbluni.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxu1, valyu1)
                        Dim valxu2 As Int32 = x - 111
                        Dim valyu2 As Int32 = y - 56 + 15
                        e.Graphics.DrawString(lbluni2.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxu2, valyu2)
                        Dim valxu3 As Int32 = x - 111
                        Dim valyu3 As Int32 = y - 56 + 30
                        e.Graphics.DrawString(lbluni3.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxu3, valyu3)
                        Dim valxu4 As Int32 = x - 111
                        Dim valyu4 As Int32 = y - 56 + 45
                        e.Graphics.DrawString(lbluni4.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxu4, valyu4)
                    End If
                    If traecantidad = 5 Then
                        'lbluni.Location = New Point(x, y)
                        'lbluni2.Location = New Point(x, y + 15)
                        'lbluni3.Location = New Point(x, y + 30)
                        'lbluni4.Location = New Point(x, y + 45)
                        'lbluni5.Location = New Point(x, y + 60)

                        Dim valxu1 As Int32 = x - 111
                        Dim valyu1 As Int32 = y - 56
                        e.Graphics.DrawString(lbluni.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxu1, valyu1)
                        Dim valxu2 As Int32 = x - 111
                        Dim valyu2 As Int32 = y - 56 + 15
                        e.Graphics.DrawString(lbluni2.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxu2, valyu2)
                        Dim valxu3 As Int32 = x - 111
                        Dim valyu3 As Int32 = y - 56 + 30
                        e.Graphics.DrawString(lbluni3.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxu3, valyu3)
                        Dim valxu4 As Int32 = x - 111
                        Dim valyu4 As Int32 = y - 56 + 45
                        e.Graphics.DrawString(lbluni4.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxu4, valyu4)
                        Dim valxu5 As Int32 = x - 111
                        Dim valyu5 As Int32 = y - 56 + 60
                        e.Graphics.DrawString(lbluni5.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxu5, valyu5)
                    End If
                    If traecantidad = 6 Then
                        'lbluni.Location = New Point(x, y)
                        'lbluni2.Location = New Point(x, y + 15)
                        'lbluni3.Location = New Point(x, y + 30)
                        'lbluni4.Location = New Point(x, y + 45)
                        'lbluni5.Location = New Point(x, y + 60)
                        'lbluni6.Location = New Point(x, y + 75)
                        Dim valxu1 As Int32 = x - 111
                        Dim valyu1 As Int32 = y - 56
                        e.Graphics.DrawString(lbluni.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxu1, valyu1)
                        Dim valxu2 As Int32 = x - 111
                        Dim valyu2 As Int32 = y - 56 + 15
                        e.Graphics.DrawString(lbluni2.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxu2, valyu2)
                        Dim valxu3 As Int32 = x - 111
                        Dim valyu3 As Int32 = y - 56 + 30
                        e.Graphics.DrawString(lbluni3.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxu3, valyu3)
                        Dim valxu4 As Int32 = x - 111
                        Dim valyu4 As Int32 = y - 56 + 45
                        e.Graphics.DrawString(lbluni4.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxu4, valyu4)
                        Dim valxu5 As Int32 = x - 111
                        Dim valyu5 As Int32 = y - 56 + 60
                        e.Graphics.DrawString(lbluni5.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxu5, valyu5)
                        Dim valxu6 As Int32 = x - 111
                        Dim valyu6 As Int32 = y - 56 + 75
                        e.Graphics.DrawString(lbluni6.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxu6, valyu6)



                    End If

                    If traecantidad = 7 Then
                        Dim valxu1 As Int32 = x - 111
                        Dim valyu1 As Int32 = y - 56
                        e.Graphics.DrawString(lbluni.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxu1, valyu1)
                        Dim valxu2 As Int32 = x - 111
                        Dim valyu2 As Int32 = y - 56 + 15
                        e.Graphics.DrawString(lbluni2.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxu2, valyu2)
                        Dim valxu3 As Int32 = x - 111
                        Dim valyu3 As Int32 = y - 56 + 30
                        e.Graphics.DrawString(lbluni3.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxu3, valyu3)
                        Dim valxu4 As Int32 = x - 111
                        Dim valyu4 As Int32 = y - 56 + 45
                        e.Graphics.DrawString(lbluni4.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxu4, valyu4)
                        Dim valxu5 As Int32 = x - 111
                        Dim valyu5 As Int32 = y - 56 + 60
                        e.Graphics.DrawString(lbluni5.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxu5, valyu5)
                        Dim valxu6 As Int32 = x - 111
                        Dim valyu6 As Int32 = y - 56 + 75
                        e.Graphics.DrawString(lbluni6.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxu6, valyu6)
                        Dim valxu7 As Int32 = x - 111
                        Dim valyu7 As Int32 = y - 56 + 90
                        e.Graphics.DrawString(lbluni7.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxu7, valyu7)
                    End If
                    If traecantidad = 8 Then
                        Dim valxu1 As Int32 = x - 111
                        Dim valyu1 As Int32 = y - 56
                        e.Graphics.DrawString(lbluni.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxu1, valyu1)
                        Dim valxu2 As Int32 = x - 111
                        Dim valyu2 As Int32 = y - 56 + 15
                        e.Graphics.DrawString(lbluni2.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxu2, valyu2)
                        Dim valxu3 As Int32 = x - 111
                        Dim valyu3 As Int32 = y - 56 + 30
                        e.Graphics.DrawString(lbluni3.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxu3, valyu3)
                        Dim valxu4 As Int32 = x - 111
                        Dim valyu4 As Int32 = y - 56 + 45
                        e.Graphics.DrawString(lbluni4.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxu4, valyu4)
                        Dim valxu5 As Int32 = x - 111
                        Dim valyu5 As Int32 = y - 56 + 60
                        e.Graphics.DrawString(lbluni5.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxu5, valyu5)
                        Dim valxu6 As Int32 = x - 111
                        Dim valyu6 As Int32 = y - 56 + 75
                        e.Graphics.DrawString(lbluni6.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxu6, valyu6)
                        Dim valxu7 As Int32 = x - 111
                        Dim valyu7 As Int32 = y - 56 + 90
                        e.Graphics.DrawString(lbluni7.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxu7, valyu7)
                        Dim valxu8 As Int32 = x - 111
                        Dim valyu8 As Int32 = y - 56 + 105
                        e.Graphics.DrawString(lbluni8.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxu8, valyu8)
                    End If
                    If traecantidad = 9 Then
                        Dim valxu1 As Int32 = x - 111
                        Dim valyu1 As Int32 = y - 56
                        e.Graphics.DrawString(lbluni.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxu1, valyu1)
                        Dim valxu2 As Int32 = x - 111
                        Dim valyu2 As Int32 = y - 56 + 15
                        e.Graphics.DrawString(lbluni2.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxu2, valyu2)
                        Dim valxu3 As Int32 = x - 111
                        Dim valyu3 As Int32 = y - 56 + 30
                        e.Graphics.DrawString(lbluni3.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxu3, valyu3)
                        Dim valxu4 As Int32 = x - 111
                        Dim valyu4 As Int32 = y - 56 + 45
                        e.Graphics.DrawString(lbluni4.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxu4, valyu4)
                        Dim valxu5 As Int32 = x - 111
                        Dim valyu5 As Int32 = y - 56 + 60
                        e.Graphics.DrawString(lbluni5.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxu5, valyu5)
                        Dim valxu6 As Int32 = x - 111
                        Dim valyu6 As Int32 = y - 56 + 75
                        e.Graphics.DrawString(lbluni6.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxu6, valyu6)
                        Dim valxu7 As Int32 = x - 111
                        Dim valyu7 As Int32 = y - 56 + 90
                        e.Graphics.DrawString(lbluni7.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxu7, valyu7)
                        Dim valxu8 As Int32 = x - 111
                        Dim valyu8 As Int32 = y - 56 + 105
                        e.Graphics.DrawString(lbluni8.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxu8, valyu8)
                        Dim valxu9 As Int32 = x - 111
                        Dim valyu9 As Int32 = y - 56 + 120
                        e.Graphics.DrawString(lbluni9.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxu9, valyu9)
                    End If
                    If traecantidad = 10 Then
                        Dim valxu1 As Int32 = x - 111
                        Dim valyu1 As Int32 = y - 56
                        e.Graphics.DrawString(lbluni.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxu1, valyu1)
                        Dim valxu2 As Int32 = x - 111
                        Dim valyu2 As Int32 = y - 56 + 15
                        e.Graphics.DrawString(lbluni2.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxu2, valyu2)
                        Dim valxu3 As Int32 = x - 111
                        Dim valyu3 As Int32 = y - 56 + 30
                        e.Graphics.DrawString(lbluni3.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxu3, valyu3)
                        Dim valxu4 As Int32 = x - 111
                        Dim valyu4 As Int32 = y - 56 + 45
                        e.Graphics.DrawString(lbluni4.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxu4, valyu4)
                        Dim valxu5 As Int32 = x - 111
                        Dim valyu5 As Int32 = y - 56 + 60
                        e.Graphics.DrawString(lbluni5.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxu5, valyu5)
                        Dim valxu6 As Int32 = x - 111
                        Dim valyu6 As Int32 = y - 56 + 75
                        e.Graphics.DrawString(lbluni6.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxu6, valyu6)
                        Dim valxu7 As Int32 = x - 111
                        Dim valyu7 As Int32 = y - 56 + 90
                        e.Graphics.DrawString(lbluni7.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxu7, valyu7)
                        Dim valxu8 As Int32 = x - 111
                        Dim valyu8 As Int32 = y - 56 + 105
                        e.Graphics.DrawString(lbluni8.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxu8, valyu8)
                        Dim valxu9 As Int32 = x - 111
                        Dim valyu9 As Int32 = y - 56 + 120
                        e.Graphics.DrawString(lbluni9.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxu9, valyu9)
                        Dim valxu10 As Int32 = x - 111
                        Dim valyu10 As Int32 = y - 56 + 135
                        e.Graphics.DrawString(lbluni10.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxu10, valyu10)
                    End If
                    If traecantidad = 11 Then
                        Dim valxu1 As Int32 = x - 111
                        Dim valyu1 As Int32 = y - 56
                        e.Graphics.DrawString(lbluni.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxu1, valyu1)
                        Dim valxu2 As Int32 = x - 111
                        Dim valyu2 As Int32 = y - 56 + 15
                        e.Graphics.DrawString(lbluni2.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxu2, valyu2)
                        Dim valxu3 As Int32 = x - 111
                        Dim valyu3 As Int32 = y - 56 + 30
                        e.Graphics.DrawString(lbluni3.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxu3, valyu3)
                        Dim valxu4 As Int32 = x - 111
                        Dim valyu4 As Int32 = y - 56 + 45
                        e.Graphics.DrawString(lbluni4.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxu4, valyu4)
                        Dim valxu5 As Int32 = x - 111
                        Dim valyu5 As Int32 = y - 56 + 60
                        e.Graphics.DrawString(lbluni5.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxu5, valyu5)
                        Dim valxu6 As Int32 = x - 111
                        Dim valyu6 As Int32 = y - 56 + 75
                        e.Graphics.DrawString(lbluni6.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxu6, valyu6)
                        Dim valxu7 As Int32 = x - 111
                        Dim valyu7 As Int32 = y - 56 + 90
                        e.Graphics.DrawString(lbluni7.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxu7, valyu7)
                        Dim valxu8 As Int32 = x - 111
                        Dim valyu8 As Int32 = y - 56 + 105
                        e.Graphics.DrawString(lbluni8.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxu8, valyu8)
                        Dim valxu9 As Int32 = x - 111
                        Dim valyu9 As Int32 = y - 56 + 120
                        e.Graphics.DrawString(lbluni9.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxu9, valyu9)
                        Dim valxu10 As Int32 = x - 111
                        Dim valyu10 As Int32 = y - 56 + 135
                        e.Graphics.DrawString(lbluni10.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxu10, valyu10)
                        Dim valxu11 As Int32 = x - 111
                        Dim valyu11 As Int32 = y - 56 + 150
                        e.Graphics.DrawString(lbluni11.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxu11, valyu11)
                    End If
                    If traecantidad = 12 Then
                        Dim valxu1 As Int32 = x - 111
                        Dim valyu1 As Int32 = y - 56
                        e.Graphics.DrawString(lbluni.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxu1, valyu1)
                        Dim valxu2 As Int32 = x - 111
                        Dim valyu2 As Int32 = y - 56 + 15
                        e.Graphics.DrawString(lbluni2.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxu2, valyu2)
                        Dim valxu3 As Int32 = x - 111
                        Dim valyu3 As Int32 = y - 56 + 30
                        e.Graphics.DrawString(lbluni3.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxu3, valyu3)
                        Dim valxu4 As Int32 = x - 111
                        Dim valyu4 As Int32 = y - 56 + 45
                        e.Graphics.DrawString(lbluni4.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxu4, valyu4)
                        Dim valxu5 As Int32 = x - 111
                        Dim valyu5 As Int32 = y - 56 + 60
                        e.Graphics.DrawString(lbluni5.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxu5, valyu5)
                        Dim valxu6 As Int32 = x - 111
                        Dim valyu6 As Int32 = y - 56 + 75
                        e.Graphics.DrawString(lbluni6.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxu6, valyu6)
                        Dim valxu7 As Int32 = x - 111
                        Dim valyu7 As Int32 = y - 56 + 90
                        e.Graphics.DrawString(lbluni7.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxu7, valyu7)
                        Dim valxu8 As Int32 = x - 111
                        Dim valyu8 As Int32 = y - 56 + 105
                        e.Graphics.DrawString(lbluni8.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxu8, valyu8)
                        Dim valxu9 As Int32 = x - 111
                        Dim valyu9 As Int32 = y - 56 + 120
                        e.Graphics.DrawString(lbluni9.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxu9, valyu9)
                        Dim valxu10 As Int32 = x - 111
                        Dim valyu10 As Int32 = y - 56 + 135
                        e.Graphics.DrawString(lbluni10.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxu10, valyu10)
                        Dim valxu11 As Int32 = x - 111
                        Dim valyu11 As Int32 = y - 56 + 150
                        e.Graphics.DrawString(lbluni11.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxu11, valyu11)
                        Dim valxu12 As Int32 = x - 111
                        Dim valyu12 As Int32 = y - 56 + 165
                        e.Graphics.DrawString(lbluni12.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxu12, valyu12)
                    End If

                End If

                If dato = "Kilos" Then


                

                    x = Convert.ToInt32(tabla.Rows(i)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(i)(1).ToString())

                    If traecantidad = 1 Then
                        'lblkil.Location = New Point(x, y)
                        Dim valxk1 As Int32 = x - 111
                        Dim valyk1 As Int32 = y - 56
                        e.Graphics.DrawString(lblkil.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxk1, valyk1)
                    End If

                    If traecantidad = 2 Then
                        'lblkil.Location = New Point(x, y)
                        'lblkil2.Location = New Point(x, y + 15)
                        Dim valxk1 As Int32 = x - 111
                        Dim valyk1 As Int32 = y - 56
                        e.Graphics.DrawString(lblkil.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxk1, valyk1)
                        Dim valxk2 As Int32 = x - 111
                        Dim valyk2 As Int32 = y - 56 + 15
                        e.Graphics.DrawString(lblkil2.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxk2, valyk2)
                    End If
                    If traecantidad = 3 Then
                        'lblkil.Location = New Point(x, y)
                        'lblkil2.Location = New Point(x, y + 15)
                        'lblkil3.Location = New Point(x, y + 30)
                        Dim valxk1 As Int32 = x - 111
                        Dim valyk1 As Int32 = y - 56
                        e.Graphics.DrawString(lblkil.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxk1, valyk1)
                        Dim valxk2 As Int32 = x - 111
                        Dim valyk2 As Int32 = y - 56 + 15
                        e.Graphics.DrawString(lblkil2.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxk2, valyk2)
                        Dim valxk3 As Int32 = x - 111
                        Dim valyk3 As Int32 = y - 56 + 30
                        e.Graphics.DrawString(lblkil3.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxk3, valyk3)
                    End If
                    If traecantidad = 4 Then
                        'lblkil.Location = New Point(x, y)
                        'lblkil2.Location = New Point(x, y + 15)
                        'lblkil3.Location = New Point(x, y + 30)
                        'lblkil4.Location = New Point(x, y + 45)
                        Dim valxk1 As Int32 = x - 111
                        Dim valyk1 As Int32 = y - 56
                        e.Graphics.DrawString(lblkil.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxk1, valyk1)
                        Dim valxk2 As Int32 = x - 111
                        Dim valyk2 As Int32 = y - 56 + 15
                        e.Graphics.DrawString(lblkil2.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxk2, valyk2)
                        Dim valxk3 As Int32 = x - 111
                        Dim valyk3 As Int32 = y - 56 + 30
                        e.Graphics.DrawString(lblkil3.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxk3, valyk3)
                        Dim valxk4 As Int32 = x - 111
                        Dim valyk4 As Int32 = y - 56 + 45
                        e.Graphics.DrawString(lblkil4.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxk4, valyk4)
                    End If
                    If traecantidad = 5 Then
                        'lblkil.Location = New Point(x, y)
                        'lblkil2.Location = New Point(x, y + 15)
                        'lblkil3.Location = New Point(x, y + 30)
                        'lblkil4.Location = New Point(x, y + 45)
                        'lblkil5.Location = New Point(x, y + 60)
                        Dim valxk1 As Int32 = x - 111
                        Dim valyk1 As Int32 = y - 56
                        e.Graphics.DrawString(lblkil.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxk1, valyk1)
                        Dim valxk2 As Int32 = x - 111
                        Dim valyk2 As Int32 = y - 56 + 15
                        e.Graphics.DrawString(lblkil2.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxk2, valyk2)
                        Dim valxk3 As Int32 = x - 111
                        Dim valyk3 As Int32 = y - 56 + 30
                        e.Graphics.DrawString(lblkil3.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxk3, valyk3)
                        Dim valxk4 As Int32 = x - 111
                        Dim valyk4 As Int32 = y - 56 + 45
                        e.Graphics.DrawString(lblkil4.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxk4, valyk4)
                        Dim valxk5 As Int32 = x - 111
                        Dim valyk5 As Int32 = y - 56 + 60
                        e.Graphics.DrawString(lblkil5.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxk5, valyk5)
                    End If
                    If traecantidad = 6 Then
                        'lblkil.Location = New Point(x, y)
                        'lblkil2.Location = New Point(x, y + 15)
                        'lblkil3.Location = New Point(x, y + 30)
                        'lblkil4.Location = New Point(x, y + 45)
                        'lblkil5.Location = New Point(x, y + 60)
                        'lblkil6.Location = New Point(x, y + 75)
                        Dim valxk1 As Int32 = x - 111
                        Dim valyk1 As Int32 = y - 56
                        e.Graphics.DrawString(lblkil.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxk1, valyk1)
                        Dim valxk2 As Int32 = x - 111
                        Dim valyk2 As Int32 = y - 56 + 15
                        e.Graphics.DrawString(lblkil2.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxk2, valyk2)
                        Dim valxk3 As Int32 = x - 111
                        Dim valyk3 As Int32 = y - 56 + 30
                        e.Graphics.DrawString(lblkil3.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxk3, valyk3)
                        Dim valxk4 As Int32 = x - 111
                        Dim valyk4 As Int32 = y - 56 + 45
                        e.Graphics.DrawString(lblkil4.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxk4, valyk4)
                        Dim valxk5 As Int32 = x - 111
                        Dim valyk5 As Int32 = y - 56 + 60
                        e.Graphics.DrawString(lblkil5.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxk5, valyk5)
                        Dim valxk6 As Int32 = x - 111
                        Dim valyk6 As Int32 = y - 56 + 75
                        e.Graphics.DrawString(lblkil6.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxk6, valyk6)



                    End If

                    If traecantidad = 7 Then
                        Dim valxk1 As Int32 = x - 111
                        Dim valyk1 As Int32 = y - 56
                        e.Graphics.DrawString(lblkil.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxk1, valyk1)
                        Dim valxk2 As Int32 = x - 111
                        Dim valyk2 As Int32 = y - 56 + 15
                        e.Graphics.DrawString(lblkil2.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxk2, valyk2)
                        Dim valxk3 As Int32 = x - 111
                        Dim valyk3 As Int32 = y - 56 + 30
                        e.Graphics.DrawString(lblkil3.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxk3, valyk3)
                        Dim valxk4 As Int32 = x - 111
                        Dim valyk4 As Int32 = y - 56 + 45
                        e.Graphics.DrawString(lblkil4.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxk4, valyk4)
                        Dim valxk5 As Int32 = x - 111
                        Dim valyk5 As Int32 = y - 56 + 60
                        e.Graphics.DrawString(lblkil5.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxk5, valyk5)
                        Dim valxk6 As Int32 = x - 111
                        Dim valyk6 As Int32 = y - 56 + 75
                        e.Graphics.DrawString(lblkil6.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxk6, valyk6)
                        Dim valxk7 As Int32 = x - 111
                        Dim valyk7 As Int32 = y - 56 + 90
                        e.Graphics.DrawString(lblkil7.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxk7, valyk7)
                    End If
                    If traecantidad = 8 Then
                        Dim valxk1 As Int32 = x - 111
                        Dim valyk1 As Int32 = y - 56
                        e.Graphics.DrawString(lblkil.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxk1, valyk1)
                        Dim valxk2 As Int32 = x - 111
                        Dim valyk2 As Int32 = y - 56 + 15
                        e.Graphics.DrawString(lblkil2.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxk2, valyk2)
                        Dim valxk3 As Int32 = x - 111
                        Dim valyk3 As Int32 = y - 56 + 30
                        e.Graphics.DrawString(lblkil3.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxk3, valyk3)
                        Dim valxk4 As Int32 = x - 111
                        Dim valyk4 As Int32 = y - 56 + 45
                        e.Graphics.DrawString(lblkil4.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxk4, valyk4)
                        Dim valxk5 As Int32 = x - 111
                        Dim valyk5 As Int32 = y - 56 + 60
                        e.Graphics.DrawString(lblkil5.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxk5, valyk5)
                        Dim valxk6 As Int32 = x - 111
                        Dim valyk6 As Int32 = y - 56 + 75
                        e.Graphics.DrawString(lblkil6.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxk6, valyk6)
                        Dim valxk7 As Int32 = x - 111
                        Dim valyk7 As Int32 = y - 56 + 90
                        e.Graphics.DrawString(lblkil7.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxk7, valyk7)
                        Dim valxk8 As Int32 = x - 111
                        Dim valyk8 As Int32 = y - 56 + 105
                        e.Graphics.DrawString(lblkil8.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxk8, valyk8)
                    End If
                    If traecantidad = 9 Then
                        Dim valxk1 As Int32 = x - 111
                        Dim valyk1 As Int32 = y - 56
                        e.Graphics.DrawString(lblkil.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxk1, valyk1)
                        Dim valxk2 As Int32 = x - 111
                        Dim valyk2 As Int32 = y - 56 + 15
                        e.Graphics.DrawString(lblkil2.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxk2, valyk2)
                        Dim valxk3 As Int32 = x - 111
                        Dim valyk3 As Int32 = y - 56 + 30
                        e.Graphics.DrawString(lblkil3.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxk3, valyk3)
                        Dim valxk4 As Int32 = x - 111
                        Dim valyk4 As Int32 = y - 56 + 45
                        e.Graphics.DrawString(lblkil4.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxk4, valyk4)
                        Dim valxk5 As Int32 = x - 111
                        Dim valyk5 As Int32 = y - 56 + 60
                        e.Graphics.DrawString(lblkil5.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxk5, valyk5)
                        Dim valxk6 As Int32 = x - 111
                        Dim valyk6 As Int32 = y - 56 + 75
                        e.Graphics.DrawString(lblkil6.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxk6, valyk6)
                        Dim valxk7 As Int32 = x - 111
                        Dim valyk7 As Int32 = y - 56 + 90
                        e.Graphics.DrawString(lblkil7.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxk7, valyk7)
                        Dim valxk8 As Int32 = x - 111
                        Dim valyk8 As Int32 = y - 56 + 105
                        e.Graphics.DrawString(lblkil8.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxk8, valyk8)
                        Dim valxk9 As Int32 = x - 111
                        Dim valyk9 As Int32 = y - 56 + 120
                        e.Graphics.DrawString(lblkil9.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxk9, valyk9)
                    End If
                    If traecantidad = 10 Then
                        Dim valxk1 As Int32 = x - 111
                        Dim valyk1 As Int32 = y - 56
                        e.Graphics.DrawString(lblkil.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxk1, valyk1)
                        Dim valxk2 As Int32 = x - 111
                        Dim valyk2 As Int32 = y - 56 + 15
                        e.Graphics.DrawString(lblkil2.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxk2, valyk2)
                        Dim valxk3 As Int32 = x - 111
                        Dim valyk3 As Int32 = y - 56 + 30
                        e.Graphics.DrawString(lblkil3.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxk3, valyk3)
                        Dim valxk4 As Int32 = x - 111
                        Dim valyk4 As Int32 = y - 56 + 45
                        e.Graphics.DrawString(lblkil4.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxk4, valyk4)
                        Dim valxk5 As Int32 = x - 111
                        Dim valyk5 As Int32 = y - 56 + 60
                        e.Graphics.DrawString(lblkil5.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxk5, valyk5)
                        Dim valxk6 As Int32 = x - 111
                        Dim valyk6 As Int32 = y - 56 + 75
                        e.Graphics.DrawString(lblkil6.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxk6, valyk6)
                        Dim valxk7 As Int32 = x - 111
                        Dim valyk7 As Int32 = y - 56 + 90
                        e.Graphics.DrawString(lblkil7.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxk7, valyk7)
                        Dim valxk8 As Int32 = x - 111
                        Dim valyk8 As Int32 = y - 56 + 105
                        e.Graphics.DrawString(lblkil8.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxk8, valyk8)
                        Dim valxk9 As Int32 = x - 111
                        Dim valyk9 As Int32 = y - 56 + 120
                        e.Graphics.DrawString(lblkil9.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxk9, valyk9)
                        Dim valxk10 As Int32 = x - 111
                        Dim valyk10 As Int32 = y - 56 + 135
                        e.Graphics.DrawString(lblkil10.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxk10, valyk10)
                    End If
                    If traecantidad = 11 Then
                        Dim valxk1 As Int32 = x - 111
                        Dim valyk1 As Int32 = y - 56
                        e.Graphics.DrawString(lblkil.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxk1, valyk1)
                        Dim valxk2 As Int32 = x - 111
                        Dim valyk2 As Int32 = y - 56 + 15
                        e.Graphics.DrawString(lblkil2.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxk2, valyk2)
                        Dim valxk3 As Int32 = x - 111
                        Dim valyk3 As Int32 = y - 56 + 30
                        e.Graphics.DrawString(lblkil3.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxk3, valyk3)
                        Dim valxk4 As Int32 = x - 111
                        Dim valyk4 As Int32 = y - 56 + 45
                        e.Graphics.DrawString(lblkil4.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxk4, valyk4)
                        Dim valxk5 As Int32 = x - 111
                        Dim valyk5 As Int32 = y - 56 + 60
                        e.Graphics.DrawString(lblkil5.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxk5, valyk5)
                        Dim valxk6 As Int32 = x - 111
                        Dim valyk6 As Int32 = y - 56 + 75
                        e.Graphics.DrawString(lblkil6.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxk6, valyk6)
                        Dim valxk7 As Int32 = x - 111
                        Dim valyk7 As Int32 = y - 56 + 90
                        e.Graphics.DrawString(lblkil7.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxk7, valyk7)
                        Dim valxk8 As Int32 = x - 111
                        Dim valyk8 As Int32 = y - 56 + 105
                        e.Graphics.DrawString(lblkil8.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxk8, valyk8)
                        Dim valxk9 As Int32 = x - 111
                        Dim valyk9 As Int32 = y - 56 + 120
                        e.Graphics.DrawString(lblkil9.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxk9, valyk9)
                        Dim valxk10 As Int32 = x - 111
                        Dim valyk10 As Int32 = y - 56 + 135
                        e.Graphics.DrawString(lblkil10.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxk10, valyk10)
                        Dim valxk11 As Int32 = x - 111
                        Dim valyk11 As Int32 = y - 56 + 150
                        e.Graphics.DrawString(lblkil11.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxk11, valyk11)
                    End If
                    If traecantidad = 12 Then
                        Dim valxk1 As Int32 = x - 111
                        Dim valyk1 As Int32 = y - 56
                        e.Graphics.DrawString(lblkil.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxk1, valyk1)
                        Dim valxk2 As Int32 = x - 111
                        Dim valyk2 As Int32 = y - 56 + 15
                        e.Graphics.DrawString(lblkil2.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxk2, valyk2)
                        Dim valxk3 As Int32 = x - 111
                        Dim valyk3 As Int32 = y - 56 + 30
                        e.Graphics.DrawString(lblkil3.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxk3, valyk3)
                        Dim valxk4 As Int32 = x - 111
                        Dim valyk4 As Int32 = y - 56 + 45
                        e.Graphics.DrawString(lblkil4.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxk4, valyk4)
                        Dim valxk5 As Int32 = x - 111
                        Dim valyk5 As Int32 = y - 56 + 60
                        e.Graphics.DrawString(lblkil5.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxk5, valyk5)
                        Dim valxk6 As Int32 = x - 111
                        Dim valyk6 As Int32 = y - 56 + 75
                        e.Graphics.DrawString(lblkil6.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxk6, valyk6)
                        Dim valxk7 As Int32 = x - 111
                        Dim valyk7 As Int32 = y - 56 + 90
                        e.Graphics.DrawString(lblkil7.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxk7, valyk7)
                        Dim valxk8 As Int32 = x - 111
                        Dim valyk8 As Int32 = y - 56 + 105
                        e.Graphics.DrawString(lblkil8.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxk8, valyk8)
                        Dim valxk9 As Int32 = x - 111
                        Dim valyk9 As Int32 = y - 56 + 120
                        e.Graphics.DrawString(lblkil9.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxk9, valyk9)
                        Dim valxk10 As Int32 = x - 111
                        Dim valyk10 As Int32 = y - 56 + 135
                        e.Graphics.DrawString(lblkil10.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxk10, valyk10)
                        Dim valxk11 As Int32 = x - 111
                        Dim valyk11 As Int32 = y - 56 + 150
                        e.Graphics.DrawString(lblkil11.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxk11, valyk11)
                        Dim valxk12 As Int32 = x - 111
                        Dim valyk12 As Int32 = y - 56 + 165
                        e.Graphics.DrawString(lblkil12.Text, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, valxk12, valyk12)
                    End If

                End If

            Next
        End If






        ' DIBUJA RECTANGULO PRINCIPAL
        'e.Graphics.DrawRectangle(Pens.Black, New Rectangle(1, 1, 370, 265))



        'CLASIFICACION
        'e.Graphics.DrawString(clasificacion, New Font("Arial", 8, FontStyle.Bold), Brushes.Black, 295, 3)

        ''PESO NETO
        'e.Graphics.DrawString("Peso Neto", New Font("Arial", 11, FontStyle.Bold), Brushes.Black, 265, 40)
        'e.Graphics.DrawString(pesoneto, New Font("Arial", 19, FontStyle.Bold), Brushes.Black, 235, 52)

        ''VENCIMIENTO
        'e.Graphics.DrawString("Vence el", New Font("Arial", 11, FontStyle.Bold), Brushes.Black, 265, 75)
        'e.Graphics.DrawString(vencimiento, New Font("Arial", 19, FontStyle.Bold), Brushes.Black, 235, 90)

        ''PRODUCTO
        'e.Graphics.DrawString(producto, New Font("Arial", 9, FontStyle.Bold), Brushes.Black, 10, 10)

        ''CODIGO DE REFERENCIA
        'e.Graphics.DrawString(codigoreferencia, New Font("Arial", 6, FontStyle.Bold), Brushes.Black, 10, 28)

        ''PRODUCIDO
        'e.Graphics.DrawString(producido, New Font("Arial", 5, FontStyle.Bold), Brushes.Black, 10, 40)

        ''DIRECCION
        'e.Graphics.DrawString(direccion, New Font("Arial", 5, FontStyle.Bold), Brushes.Black, 10, 70)



        ''LOTE TRAZABLE
        'e.Graphics.DrawString("Lote Trazable", New Font("Arial", 5, FontStyle.Bold), Brushes.Black, 10, 120)
        ''e.Graphics.DrawString(txtlotetrazable.Text, New Font("Arial", 5, FontStyle.Bold), Brushes.Black, 14, 128)

        ''FECHA DE ELABORACION
        'e.Graphics.DrawString("Fecha de Elaboración", New Font("Arial", 5, FontStyle.Bold), Brushes.Black, 89, 120)
        ''e.Graphics.DrawString(FechaElaboracion, New Font("Arial", 5, FontStyle.Bold), Brushes.Black, 99, 128)

        ''NUMERO DE PLANTA
        'e.Graphics.DrawString("N° Planta", New Font("Arial", 5, FontStyle.Bold), Brushes.Black, 199, 120)
        ''e.Graphics.DrawString(txtnplanta.Text, New Font("Arial", 5, FontStyle.Bold), Brushes.Black, 206, 128)

        'Dim rdi As String



        ''NACIONAL O IMPORTACION
        'e.Graphics.DrawString(rdi, New Font("Arial", 7, FontStyle.Bold), Brushes.Black, 265, 123)


        ''SAP
        'e.Graphics.DrawString("SAP", New Font("Arial", 8, FontStyle.Bold), Brushes.Black, 315, 150)


        'OBSERVACIÓN
        '    e.Graphics.DrawString(observacion, New Font("Arial", 5, FontStyle.Bold), Brushes.Black, 10, 140)

        '  TRUE o FALSE Muestra los numeros bajo el codigo de barras



        'codigo de barras ------>


    End Sub
    Private Sub Imprimir()
        ' imprimir ZEBRA
        Dim PrintDocument1 As New PrintDocument


        PrintDocument1.PrinterSettings = prtsettings
        AddHandler PrintDocument1.PrintPage, AddressOf print_PrintPage_10x08

        Dim queryImpresora As String = "SELECT imp_etiq FROM Conf_Impresora WHERE Imp_Comp='" + My.Computer.Name + "'"
        Dim tabla_conf As DataTable = fnc.ListarTablasSQL(queryImpresora)
        If tabla_conf.Rows.Count > 0 Then
            PrintDocument1.PrinterSettings.PrinterName = tabla_conf.Rows(0)(0).ToString()
        Else
            MsgBox("Debe seleccionar la impresora antes de imprimir una etiqueta", MsgBoxStyle.Critical, "Aviso")
            Exit Sub
        End If
        PrintDocument1.Print()


    End Sub

    Private Sub cbodatos_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbodatos.SelectedIndexChanged
        ''111+56
        If cbodatos.Text.Trim = "Despacho" Then

            Dim sql As String = "SELECT x,y from datos_informes where rutcli= '" + TxtClirut.Text + "' and dato = '" + cbodatos.Text.Trim() + "'  "

            Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

            If tabla.Rows.Count > 0 Then


                lbldespacho.Visible = True
                x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                lbldespacho.Location = New Point(x, y)
            Else

                lbldespacho.Visible = True
                x = 111
                y = 56
                lbldespacho.Location = New Point(111, 56)

            End If

            If cbodatos.Text.Trim = "Despacho" Then
                lbldespacho.Text = txtfolio.Text

            End If
        End If
        If cbodatos.Text.Trim = "Fecha" Then

            Dim sql As String = "SELECT x,y from datos_informes where rutcli= '" + TxtClirut.Text + "' and dato = '" + cbodatos.Text.Trim() + "'  "

            Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

            If tabla.Rows.Count > 0 Then


                lblfecha.Visible = True
                x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                lblfecha.Location = New Point(x, y)
            Else

                lblfecha.Visible = True
                x = 111
                y = 56
                lblfecha.Location = New Point(111, 56)

            End If

            If cbodatos.Text.Trim = "Fecha" Then
                lblfecha.Text = Frm_Despacho.dt_fecha.Text.Trim()

            End If
        End If
        If cbodatos.Text.Trim = "Nombre chofer" Then

            Dim sql As String = "SELECT x,y from datos_informes where rutcli= '" + TxtClirut.Text + "' and dato = '" + cbodatos.Text.Trim() + "'  "

            Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

            If tabla.Rows.Count > 0 Then


                lblnomcho.Visible = True
                x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                lblnomcho.Location = New Point(x, y)
            Else

                lblnomcho.Visible = True
                x = 111
                y = 56
                lblnomcho.Location = New Point(111, 56)

            End If

            If cbodatos.Text.Trim = "Nombre chofer" Then
                lblnomcho.Text = Frm_Despacho.txtchonom.Text.Trim()

            End If
        End If
        If cbodatos.Text.Trim = "Rut chofer" Then

            Dim sql As String = "SELECT x,y from datos_informes where rutcli= '" + TxtClirut.Text + "' and dato = '" + cbodatos.Text.Trim() + "'  "

            Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

            If tabla.Rows.Count > 0 Then


                lblrutcho.Visible = True
                x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                lblrutcho.Location = New Point(x, y)
            Else

                lblrutcho.Visible = True
                x = 111
                y = 56
                lblrutcho.Location = New Point(111, 56)

            End If

            If cbodatos.Text.Trim = "Rut chofer" Then
                lblrutcho.Text = Frm_Despacho.Txtchorut.Text.Trim()

            End If
        End If

        If cbodatos.Text.Trim = "Patente" Then

            Dim sql As String = "SELECT x,y from datos_informes where rutcli= '" + TxtClirut.Text + "' and dato = '" + cbodatos.Text.Trim() + "'  "

            Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

            If tabla.Rows.Count > 0 Then


                lblpatente.Visible = True
                x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                lblpatente.Location = New Point(x, y)
            Else

                lblpatente.Visible = True
                x = 111
                y = 56
                lblpatente.Location = New Point(111, 56)

            End If

            If cbodatos.Text.Trim = "Patente" Then
                lblpatente.Text = Frm_Despacho.txtpatente.Text.Trim()

            End If
        End If
        If cbodatos.Text.Trim = "Observacion" Then

            Dim sql As String = "SELECT x,y from datos_informes where rutcli= '" + TxtClirut.Text + "' and dato = '" + cbodatos.Text.Trim() + "'  "

            Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

            If tabla.Rows.Count > 0 Then


                lblobs.Visible = True
                x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                lblobs.Location = New Point(x, y)
            Else

                lblobs.Visible = True
                x = 111
                y = 56
                lblobs.Location = New Point(111, 56)

            End If

            If cbodatos.Text.Trim = "Observacion" Then
                lblobs.Text = Frm_Despacho.TxtObs.Text.Trim()

            End If
        End If

        If cbodatos.Text.Trim = "Destino" Then

            Dim sql As String = "SELECT x,y from datos_informes where rutcli= '" + TxtClirut.Text + "' and dato = '" + cbodatos.Text.Trim() + "'  "

            Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

            If tabla.Rows.Count > 0 Then


                lbldestino.Visible = True
                x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                lbldestino.Location = New Point(x, y)
            Else

                lbldestino.Visible = True
                x = 111
                y = 56
                lbldestino.Location = New Point(111, 56)

            End If

            If cbodatos.Text.Trim = "Destino" Then
                Dim sql2 As String = "SELECT destino,destino_rut,destino_dir from vg_despachos_destinos where fdes_codi= '" + txtfolio.Text + "'  "

                Dim tabla2 As DataTable = fnc.ListarTablasSQL(sql2)

                If tabla2.Rows.Count > 0 Then

                    lbldestino.Text = tabla2.Rows(0)(0).ToString()
                    lbldestino2.Text = tabla2.Rows(0)(1).ToString()
                    lbldestino3.Text = tabla2.Rows(0)(2).ToString()
                End If

            End If
        End If
        If cbodatos.Text.Trim = "Giro" Then

            Dim sql As String = "SELECT x,y from datos_informes where rutcli= '" + TxtClirut.Text + "' and dato = '" + cbodatos.Text.Trim() + "'  "

            Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

            If tabla.Rows.Count > 0 Then


                lblgiro.Visible = True
                x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                lblgiro.Location = New Point(x, y)
            Else

                lblgiro.Visible = True
                x = 111
                y = 56
                lblgiro.Location = New Point(111, 56)

            End If

            If cbodatos.Text.Trim = "Giro" Then

                Dim sql2 As String = "SELECT cli_rubro from clientes where cli_rut= '" + TxtClirut.Text + "'  "

                Dim tabla2 As DataTable = fnc.ListarTablasSQL(sql2)

                If tabla2.Rows.Count > 0 Then

                    lblgiro.Text = tabla2.Rows(0)(0).ToString()
                End If


            End If
        End If
        If cbodatos.Text.Trim = "Direccion" Then

            Dim sql As String = "SELECT x,y from datos_informes where rutcli= '" + TxtClirut.Text + "' and dato = '" + cbodatos.Text.Trim() + "'  "

            Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

            If tabla.Rows.Count > 0 Then


                lbldireccion.Visible = True
                x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                lbldireccion.Location = New Point(x, y)
            Else

                lbldireccion.Visible = True
                x = 111
                y = 56
                lbldireccion.Location = New Point(111, 56)

            End If

            If cbodatos.Text.Trim = "Direccion" Then

                Dim sql2 As String = "SELECT cli_direcc from clientes where cli_rut= '" + TxtClirut.Text + "'  "

                Dim tabla2 As DataTable = fnc.ListarTablasSQL(sql2)

                If tabla2.Rows.Count > 0 Then

                    lbldireccion.Text = tabla2.Rows(0)(0).ToString()
                End If


            End If
        End If
        If cbodatos.Text.Trim = "Comuna" Then

            Dim sql As String = "SELECT x,y from datos_informes where rutcli= '" + TxtClirut.Text + "' and dato = '" + cbodatos.Text.Trim() + "'  "

            Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

            If tabla.Rows.Count > 0 Then


                lblcomuna.Visible = True
                x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                lblcomuna.Location = New Point(x, y)
            Else

                lblcomuna.Visible = True
                x = 111
                y = 56
                lblcomuna.Location = New Point(111, 56)

            End If

            If cbodatos.Text.Trim = "Comuna" Then

                Dim sql2 As String = "SELECT cli_comuna from clientes where cli_rut= '" + TxtClirut.Text + "'  "

                Dim tabla2 As DataTable = fnc.ListarTablasSQL(sql2)

                If tabla2.Rows.Count > 0 Then

                    lblcomuna.Text = tabla2.Rows(0)(0).ToString()
                End If


            End If
        End If

        ''Rut cliente
        If cbodatos.Text.Trim = "Rut cliente" Then

            Dim sql As String = "SELECT x,y from datos_informes where rutcli= '" + TxtClirut.Text + "' and dato = '" + cbodatos.Text.Trim() + "' "

            Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

            If tabla.Rows.Count > 0 Then


                lblrutcli.Visible = True
                x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                lblrutcli.Location = New Point(x, y)
            Else

                lblrutcli.Visible = True
                x = 111
                y = 56
                lblrutcli.Location = New Point(111, 56)

            End If

            If cbodatos.Text.Trim = "Rut cliente" Then
                lblrutcli.Text = TxtClirut.Text

            End If
        End If
        If cbodatos.Text.Trim = "Nombre cliente" Then

            Dim sql As String = "SELECT x,y from datos_informes where rutcli= '" + TxtClirut.Text + "' and dato = '" + cbodatos.Text.Trim() + "' "

            Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

            If tabla.Rows.Count > 0 Then


                lblnomcli.Visible = True
                x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                lblnomcli.Location = New Point(x, y)
            Else

                lblnomcli.Visible = True
                x = 111
                y = 56
                lblnomcli.Location = New Point(111, 56)

            End If

            If cbodatos.Text.Trim = "Nombre cliente" Then
                lblnomcli.Text = txtclinom.Text

            End If
        End If
        If cbodatos.Text.Trim = "Codigo producto" Then
            traecanti()
            Dim sql As String = "SELECT x,y from datos_informes where rutcli= '" + TxtClirut.Text + "' and dato = '" + cbodatos.Text.Trim() + "' "

            Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

            If tabla.Rows.Count > 0 Then
                If traecantidad = 1 Then
                    lblcodpro.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblcodpro.Location = New Point(x, y)



                End If

                If traecantidad = 2 Then
                    lblcodpro.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblcodpro.Location = New Point(x, y)
                    lblcodpro2.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblcodpro2.Location = New Point(x, y + 15)



                End If


                If traecantidad = 3 Then
                    lblcodpro.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblcodpro.Location = New Point(x, y)
                    lblcodpro2.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblcodpro2.Location = New Point(x, y + 15)
                    lblcodpro3.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblcodpro3.Location = New Point(x, y + 30)



                End If

                If traecantidad = 4 Then
                    lblcodpro.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblcodpro.Location = New Point(x, y)
                    lblcodpro2.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblcodpro2.Location = New Point(x, y + 15)
                    lblcodpro3.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblcodpro3.Location = New Point(x, y + 30)
                    lblcodpro4.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblcodpro4.Location = New Point(x, y + 45)


                End If
                If traecantidad = 5 Then
                    lblcodpro.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblcodpro.Location = New Point(x, y)
                    lblcodpro2.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblcodpro2.Location = New Point(x, y + 15)
                    lblcodpro3.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblcodpro3.Location = New Point(x, y + 30)
                    lblcodpro4.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblcodpro4.Location = New Point(x, y + 45)
                    lblcodpro5.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblcodpro5.Location = New Point(x, y + 60)


                End If
                If traecantidad = 6 Then
                    lblcodpro.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblcodpro.Location = New Point(x, y)
                    lblcodpro2.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblcodpro2.Location = New Point(x, y + 15)
                    lblcodpro3.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblcodpro3.Location = New Point(x, y + 30)
                    lblcodpro4.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblcodpro4.Location = New Point(x, y + 45)
                    lblcodpro5.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblcodpro5.Location = New Point(x, y + 60)
                    lblcodpro6.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblcodpro6.Location = New Point(x, y + 75)

                End If

            Else

                x = 111
                y = 56


                If traecantidad = 1 Then
                    lblcodpro.Visible = True
                    lblcodpro.Location = New Point(x, y)
                End If
                If traecantidad = 2 Then
                    lblcodpro.Visible = True
                    lblcodpro.Location = New Point(x, y)
                    lblcodpro2.Visible = True
                    lblcodpro2.Location = New Point(x, y + 15)
                End If
                If traecantidad = 3 Then
                    lblcodpro.Visible = True
                    lblcodpro.Location = New Point(x, y)
                    lblcodpro2.Visible = True
                    lblcodpro2.Location = New Point(x, y + 15)
                    lblcodpro3.Visible = True
                    lblcodpro3.Location = New Point(x, y + 30)

                End If
                If traecantidad = 4 Then
                    lblcodpro.Visible = True
                    lblcodpro.Location = New Point(x, y)
                    lblcodpro2.Visible = True
                    lblcodpro2.Location = New Point(x, y + 15)
                    lblcodpro3.Visible = True
                    lblcodpro3.Location = New Point(x, y + 30)
                    lblcodpro4.Visible = True
                    lblcodpro4.Location = New Point(x, y + 45)
                End If
                If traecantidad = 5 Then
                    lblcodpro.Visible = True
                    lblcodpro.Location = New Point(x, y)
                    lblcodpro2.Visible = True
                    lblcodpro2.Location = New Point(x, y + 15)
                    lblcodpro3.Visible = True
                    lblcodpro3.Location = New Point(x, y + 30)
                    lblcodpro4.Visible = True
                    lblcodpro4.Location = New Point(x, y + 45)
                    lblcodpro5.Visible = True
                    lblcodpro5.Location = New Point(x, y + 60)
                End If
                If traecantidad = 6 Then
                    lblcodpro.Visible = True
                    lblcodpro.Location = New Point(x, y)
                    lblcodpro2.Visible = True
                    lblcodpro2.Location = New Point(x, y + 15)
                    lblcodpro3.Visible = True
                    lblcodpro3.Location = New Point(x, y + 30)
                    lblcodpro4.Visible = True
                    lblcodpro4.Location = New Point(x, y + 45)
                    lblcodpro5.Visible = True
                    lblcodpro5.Location = New Point(x, y + 60)
                    lblcodpro6.Visible = True
                    lblcodpro6.Location = New Point(x, y + 75)
                End If










            End If

            If cbodatos.Text.Trim = "Codigo producto" Then
                'lblrutcli.Text = TxtClirut.Text


                Dim sql2 As String = "SELECT drec_codpro from rpt_despacho_informe where ddes_rutcli= '" + TxtClirut.Text + "' and despacho = '" + txtfolio.Text.Trim() + "' "

                Dim tabla2 As DataTable = fnc.ListarTablasSQL(sql2)

                If tabla2.Rows.Count > 0 Then

                    If traecantidad = 1 Then
                        lblcodpro.Text = tabla2.Rows(0)(0).ToString()

                    End If
                    If traecantidad = 2 Then
                        lblcodpro.Text = tabla2.Rows(0)(0).ToString()
                        lblcodpro2.Text = tabla2.Rows(1)(0).ToString()
                    End If
                    If traecantidad = 3 Then
                        lblcodpro.Text = tabla2.Rows(0)(0).ToString()
                        lblcodpro2.Text = tabla2.Rows(1)(0).ToString()
                        lblcodpro3.Text = tabla2.Rows(2)(0).ToString()
                    End If
                    If traecantidad = 4 Then
                        lblcodpro.Text = tabla2.Rows(0)(0).ToString()
                        lblcodpro2.Text = tabla2.Rows(1)(0).ToString()
                        lblcodpro3.Text = tabla2.Rows(2)(0).ToString()
                        lblcodpro4.Text = tabla2.Rows(3)(0).ToString()
                    End If
                    If traecantidad = 5 Then
                        lblcodpro.Text = tabla2.Rows(0)(0).ToString()
                        lblcodpro2.Text = tabla2.Rows(1)(0).ToString()
                        lblcodpro3.Text = tabla2.Rows(2)(0).ToString()
                        lblcodpro4.Text = tabla2.Rows(3)(0).ToString()
                        lblcodpro5.Text = tabla2.Rows(4)(0).ToString()
                    End If
                    If traecantidad = 6 Then
                        lblcodpro.Text = tabla2.Rows(0)(0).ToString()
                        lblcodpro2.Text = tabla2.Rows(1)(0).ToString()
                        lblcodpro3.Text = tabla2.Rows(2)(0).ToString()
                        lblcodpro4.Text = tabla2.Rows(3)(0).ToString()
                        lblcodpro5.Text = tabla2.Rows(4)(0).ToString()
                        lblcodpro6.Text = tabla2.Rows(5)(0).ToString()
                    End If




                End If






            End If
        End If
        If cbodatos.Text.Trim = "Nombre producto" Then
            traecanti()
            Dim sql As String = "SELECT x,y from datos_informes where rutcli= '" + TxtClirut.Text + "' and dato = '" + cbodatos.Text.Trim() + "' "

            Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

            If tabla.Rows.Count > 0 Then
                If traecantidad = 1 Then
                    lblnompro.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblnompro.Location = New Point(x, y)



                End If

                If traecantidad = 2 Then
                    lblnompro.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblnompro.Location = New Point(x, y)
                    lblnompro2.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblnompro2.Location = New Point(x, y + 15)



                End If


                If traecantidad = 3 Then
                    lblnompro.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblnompro.Location = New Point(x, y)
                    lblnompro2.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblnompro2.Location = New Point(x, y + 15)
                    lblnompro3.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblnompro3.Location = New Point(x, y + 30)



                End If

                If traecantidad = 4 Then
                    lblnompro.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblnompro.Location = New Point(x, y)
                    lblnompro2.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblnompro2.Location = New Point(x, y + 15)
                    lblnompro3.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblnompro3.Location = New Point(x, y + 30)
                    lblnompro4.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblnompro4.Location = New Point(x, y + 45)


                End If
                If traecantidad = 5 Then
                    lblnompro.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblnompro.Location = New Point(x, y)
                    lblnompro2.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblnompro2.Location = New Point(x, y + 15)
                    lblnompro3.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblnompro3.Location = New Point(x, y + 30)
                    lblnompro4.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblnompro4.Location = New Point(x, y + 45)
                    lblnompro5.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblnompro5.Location = New Point(x, y + 60)


                End If
                If traecantidad = 6 Then
                    lblnompro.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblnompro.Location = New Point(x, y)
                    lblnompro2.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblnompro2.Location = New Point(x, y + 15)
                    lblnompro3.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblnompro3.Location = New Point(x, y + 30)
                    lblnompro4.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblnompro4.Location = New Point(x, y + 45)
                    lblnompro5.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblnompro5.Location = New Point(x, y + 60)
                    lblnompro6.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblnompro6.Location = New Point(x, y + 75)

                End If

            Else

                x = 111
                y = 56


                If traecantidad = 1 Then
                    lblnompro.Visible = True
                    lblnompro.Location = New Point(x, y)
                End If
                If traecantidad = 2 Then
                    lblnompro.Visible = True
                    lblnompro.Location = New Point(x, y)
                    lblnompro2.Visible = True
                    lblnompro2.Location = New Point(x, y + 15)
                End If
                If traecantidad = 3 Then
                    lblnompro.Visible = True
                    lblnompro.Location = New Point(x, y)
                    lblnompro2.Visible = True
                    lblnompro2.Location = New Point(x, y + 15)
                    lblnompro3.Visible = True
                    lblnompro3.Location = New Point(x, y + 30)

                End If
                If traecantidad = 4 Then
                    lblnompro.Visible = True
                    lblnompro.Location = New Point(x, y)
                    lblnompro2.Visible = True
                    lblnompro2.Location = New Point(x, y + 15)
                    lblnompro3.Visible = True
                    lblnompro3.Location = New Point(x, y + 30)
                    lblnompro4.Visible = True
                    lblnompro4.Location = New Point(x, y + 45)
                End If
                If traecantidad = 5 Then
                    lblnompro.Visible = True
                    lblnompro.Location = New Point(x, y)
                    lblnompro2.Visible = True
                    lblnompro2.Location = New Point(x, y + 15)
                    lblnompro3.Visible = True
                    lblnompro3.Location = New Point(x, y + 30)
                    lblnompro4.Visible = True
                    lblnompro4.Location = New Point(x, y + 45)
                    lblnompro5.Visible = True
                    lblnompro5.Location = New Point(x, y + 60)
                End If
                If traecantidad = 6 Then
                    lblnompro.Visible = True
                    lblnompro.Location = New Point(x, y)
                    lblnompro2.Visible = True
                    lblnompro2.Location = New Point(x, y + 15)
                    lblnompro3.Visible = True
                    lblnompro3.Location = New Point(x, y + 30)
                    lblnompro4.Visible = True
                    lblnompro4.Location = New Point(x, y + 45)
                    lblnompro5.Visible = True
                    lblnompro5.Location = New Point(x, y + 60)
                    lblnompro6.Visible = True
                    lblnompro6.Location = New Point(x, y + 75)
                End If










            End If

            If cbodatos.Text.Trim = "Nombre producto" Then
                'lblrutcli.Text = TxtClirut.Text


                Dim sql2 As String = "SELECT mae_descr from rpt_despacho_informe where ddes_rutcli= '" + TxtClirut.Text + "' and despacho = '" + txtfolio.Text.Trim() + "' "

                Dim tabla2 As DataTable = fnc.ListarTablasSQL(sql2)

                If tabla2.Rows.Count > 0 Then

                    If traecantidad = 1 Then
                        lblnompro.Text = tabla2.Rows(0)(0).ToString()

                    End If
                    If traecantidad = 2 Then
                        lblnompro.Text = tabla2.Rows(0)(0).ToString()
                        lblnompro2.Text = tabla2.Rows(1)(0).ToString()
                    End If
                    If traecantidad = 3 Then
                        lblnompro.Text = tabla2.Rows(0)(0).ToString()
                        lblnompro2.Text = tabla2.Rows(1)(0).ToString()
                        lblnompro3.Text = tabla2.Rows(2)(0).ToString()
                    End If
                    If traecantidad = 4 Then
                        lblnompro.Text = tabla2.Rows(0)(0).ToString()
                        lblnompro2.Text = tabla2.Rows(1)(0).ToString()
                        lblnompro3.Text = tabla2.Rows(2)(0).ToString()
                        lblnompro4.Text = tabla2.Rows(3)(0).ToString()
                    End If
                    If traecantidad = 5 Then
                        lblnompro.Text = tabla2.Rows(0)(0).ToString()
                        lblnompro2.Text = tabla2.Rows(1)(0).ToString()
                        lblnompro3.Text = tabla2.Rows(2)(0).ToString()
                        lblnompro4.Text = tabla2.Rows(3)(0).ToString()
                        lblnompro5.Text = tabla2.Rows(4)(0).ToString()
                    End If
                    If traecantidad = 6 Then
                        lblnompro.Text = tabla2.Rows(0)(0).ToString()
                        lblnompro2.Text = tabla2.Rows(1)(0).ToString()
                        lblnompro3.Text = tabla2.Rows(2)(0).ToString()
                        lblnompro4.Text = tabla2.Rows(3)(0).ToString()
                        lblnompro5.Text = tabla2.Rows(4)(0).ToString()
                        lblnompro6.Text = tabla2.Rows(5)(0).ToString()
                    End If




                End If






            End If
        End If
        If cbodatos.Text.Trim = "Unidades" Then
            traecanti()
            Dim sql As String = "SELECT x,y from datos_informes where rutcli= '" + TxtClirut.Text + "' and dato = '" + cbodatos.Text.Trim() + "' "

            Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

            If tabla.Rows.Count > 0 Then
                If traecantidad = 1 Then
                    lbluni.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lbluni.Location = New Point(x, y)



                End If

                If traecantidad = 2 Then
                    lbluni.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lbluni.Location = New Point(x, y)
                    lbluni2.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lbluni2.Location = New Point(x, y + 15)



                End If


                If traecantidad = 3 Then
                    lbluni.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lbluni.Location = New Point(x, y)
                    lbluni2.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lbluni2.Location = New Point(x, y + 15)
                    lbluni3.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lbluni3.Location = New Point(x, y + 30)



                End If

                If traecantidad = 4 Then
                    lbluni.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lbluni.Location = New Point(x, y)
                    lbluni2.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lbluni2.Location = New Point(x, y + 15)
                    lbluni3.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lbluni3.Location = New Point(x, y + 30)
                    lbluni4.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lbluni4.Location = New Point(x, y + 45)


                End If
                If traecantidad = 5 Then
                    lbluni.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lbluni.Location = New Point(x, y)
                    lbluni2.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lbluni2.Location = New Point(x, y + 15)
                    lbluni3.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lbluni3.Location = New Point(x, y + 30)
                    lbluni4.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lbluni4.Location = New Point(x, y + 45)
                    lbluni5.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lbluni5.Location = New Point(x, y + 60)


                End If
                If traecantidad = 6 Then
                    lbluni.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lbluni.Location = New Point(x, y)
                    lbluni2.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lbluni2.Location = New Point(x, y + 15)
                    lbluni3.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lbluni3.Location = New Point(x, y + 30)
                    lbluni4.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lbluni4.Location = New Point(x, y + 45)
                    lbluni5.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lbluni5.Location = New Point(x, y + 60)
                    lbluni6.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lbluni6.Location = New Point(x, y + 75)

                End If

            Else

                x = 111
                y = 56


                If traecantidad = 1 Then
                    lbluni.Visible = True
                    lbluni.Location = New Point(x, y)
                End If
                If traecantidad = 2 Then
                    lbluni.Visible = True
                    lbluni.Location = New Point(x, y)
                    lbluni2.Visible = True
                    lbluni2.Location = New Point(x, y + 15)
                End If
                If traecantidad = 3 Then
                    lbluni.Visible = True
                    lbluni.Location = New Point(x, y)
                    lbluni2.Visible = True
                    lbluni2.Location = New Point(x, y + 15)
                    lbluni3.Visible = True
                    lbluni3.Location = New Point(x, y + 30)

                End If
                If traecantidad = 4 Then
                    lbluni.Visible = True
                    lbluni.Location = New Point(x, y)
                    lbluni2.Visible = True
                    lbluni2.Location = New Point(x, y + 15)
                    lbluni3.Visible = True
                    lbluni3.Location = New Point(x, y + 30)
                    lbluni4.Visible = True
                    lbluni4.Location = New Point(x, y + 45)
                End If
                If traecantidad = 5 Then
                    lbluni.Visible = True
                    lbluni.Location = New Point(x, y)
                    lbluni2.Visible = True
                    lbluni2.Location = New Point(x, y + 15)
                    lbluni3.Visible = True
                    lbluni3.Location = New Point(x, y + 30)
                    lbluni4.Visible = True
                    lbluni4.Location = New Point(x, y + 45)
                    lbluni5.Visible = True
                    lbluni5.Location = New Point(x, y + 60)
                End If
                If traecantidad = 6 Then
                    lbluni.Visible = True
                    lbluni.Location = New Point(x, y)
                    lbluni2.Visible = True
                    lbluni2.Location = New Point(x, y + 15)
                    lbluni3.Visible = True
                    lbluni3.Location = New Point(x, y + 30)
                    lbluni4.Visible = True
                    lbluni4.Location = New Point(x, y + 45)
                    lbluni5.Visible = True
                    lbluni5.Location = New Point(x, y + 60)
                    lbluni6.Visible = True
                    lbluni6.Location = New Point(x, y + 75)
                End If










            End If

            If cbodatos.Text.Trim = "Unidades" Then
                'lblrutcli.Text = TxtClirut.Text


                Dim sql2 As String = "SELECT unidades from rpt_despacho_informe where ddes_rutcli= '" + TxtClirut.Text + "' and despacho = '" + txtfolio.Text.Trim() + "' "

                Dim tabla2 As DataTable = fnc.ListarTablasSQL(sql2)

                If tabla2.Rows.Count > 0 Then

                    If traecantidad = 1 Then
                        lbluni.Text = tabla2.Rows(0)(0).ToString()

                    End If
                    If traecantidad = 2 Then
                        lbluni.Text = tabla2.Rows(0)(0).ToString()
                        lbluni2.Text = tabla2.Rows(1)(0).ToString()
                    End If
                    If traecantidad = 3 Then
                        lbluni.Text = tabla2.Rows(0)(0).ToString()
                        lbluni2.Text = tabla2.Rows(1)(0).ToString()
                        lbluni3.Text = tabla2.Rows(2)(0).ToString()
                    End If
                    If traecantidad = 4 Then
                        lbluni.Text = tabla2.Rows(0)(0).ToString()
                        lbluni2.Text = tabla2.Rows(1)(0).ToString()
                        lbluni3.Text = tabla2.Rows(2)(0).ToString()
                        lbluni4.Text = tabla2.Rows(3)(0).ToString()
                    End If
                    If traecantidad = 5 Then
                        lbluni.Text = tabla2.Rows(0)(0).ToString()
                        lbluni2.Text = tabla2.Rows(1)(0).ToString()
                        lbluni3.Text = tabla2.Rows(2)(0).ToString()
                        lbluni4.Text = tabla2.Rows(3)(0).ToString()
                        lbluni5.Text = tabla2.Rows(4)(0).ToString()
                    End If
                    If traecantidad = 6 Then
                        lbluni.Text = tabla2.Rows(0)(0).ToString()
                        lbluni2.Text = tabla2.Rows(1)(0).ToString()
                        lbluni3.Text = tabla2.Rows(2)(0).ToString()
                        lbluni4.Text = tabla2.Rows(3)(0).ToString()
                        lbluni5.Text = tabla2.Rows(4)(0).ToString()
                        lbluni6.Text = tabla2.Rows(5)(0).ToString()
                    End If




                End If






            End If
        End If
        If cbodatos.Text.Trim = "Kilos" Then
            traecanti()
            Dim sql As String = "SELECT x,y from datos_informes where rutcli= '" + TxtClirut.Text + "' and dato = '" + cbodatos.Text.Trim() + "' "

            Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

            If tabla.Rows.Count > 0 Then
                If traecantidad = 1 Then
                    lblkil.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblkil.Location = New Point(x, y)



                End If

                If traecantidad = 2 Then
                    lblkil.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblkil.Location = New Point(x, y)
                    lblkil2.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblkil2.Location = New Point(x, y + 15)



                End If


                If traecantidad = 3 Then
                    lblkil.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblkil.Location = New Point(x, y)
                    lblkil2.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblkil2.Location = New Point(x, y + 15)
                    lblkil3.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblkil3.Location = New Point(x, y + 30)



                End If

                If traecantidad = 4 Then
                    lblkil.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblkil.Location = New Point(x, y)
                    lblkil2.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblkil2.Location = New Point(x, y + 15)
                    lblkil3.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblkil3.Location = New Point(x, y + 30)
                    lblkil4.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblkil4.Location = New Point(x, y + 45)


                End If
                If traecantidad = 5 Then
                    lblkil.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblkil.Location = New Point(x, y)
                    lblkil2.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblkil2.Location = New Point(x, y + 15)
                    lblkil3.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblkil3.Location = New Point(x, y + 30)
                    lblkil4.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblkil4.Location = New Point(x, y + 45)
                    lblkil5.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblkil5.Location = New Point(x, y + 60)


                End If
                If traecantidad = 6 Then
                    lblkil.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblkil.Location = New Point(x, y)
                    lblkil2.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblkil2.Location = New Point(x, y + 15)
                    lblkil3.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblkil3.Location = New Point(x, y + 30)
                    lblkil4.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblkil4.Location = New Point(x, y + 45)
                    lblkil5.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblkil5.Location = New Point(x, y + 60)
                    lblkil6.Visible = True
                    x = Convert.ToInt32(tabla.Rows(0)(0).ToString())
                    y = Convert.ToInt32(tabla.Rows(0)(1).ToString())
                    lblkil6.Location = New Point(x, y + 75)

                End If

            Else

                x = 111
                y = 56


                If traecantidad = 1 Then
                    lblkil.Visible = True
                    lblkil.Location = New Point(x, y)
                End If
                If traecantidad = 2 Then
                    lblkil.Visible = True
                    lblkil.Location = New Point(x, y)
                    lblkil2.Visible = True
                    lblkil2.Location = New Point(x, y + 15)
                End If
                If traecantidad = 3 Then
                    lblkil.Visible = True
                    lblkil.Location = New Point(x, y)
                    lblkil2.Visible = True
                    lblkil2.Location = New Point(x, y + 15)
                    lblkil3.Visible = True
                    lblkil3.Location = New Point(x, y + 30)

                End If
                If traecantidad = 4 Then
                    lblkil.Visible = True
                    lblkil.Location = New Point(x, y)
                    lblkil2.Visible = True
                    lblkil2.Location = New Point(x, y + 15)
                    lblkil3.Visible = True
                    lblkil3.Location = New Point(x, y + 30)
                    lblkil4.Visible = True
                    lblkil4.Location = New Point(x, y + 45)
                End If
                If traecantidad = 5 Then
                    lblkil.Visible = True
                    lblkil.Location = New Point(x, y)
                    lblkil2.Visible = True
                    lblkil2.Location = New Point(x, y + 15)
                    lblkil3.Visible = True
                    lblkil3.Location = New Point(x, y + 30)
                    lblkil4.Visible = True
                    lblkil4.Location = New Point(x, y + 45)
                    lblkil5.Visible = True
                    lblkil5.Location = New Point(x, y + 60)
                End If
                If traecantidad = 6 Then
                    lblkil.Visible = True
                    lblkil.Location = New Point(x, y)
                    lblkil2.Visible = True
                    lblkil2.Location = New Point(x, y + 15)
                    lblkil3.Visible = True
                    lblkil3.Location = New Point(x, y + 30)
                    lblkil4.Visible = True
                    lblkil4.Location = New Point(x, y + 45)
                    lblkil5.Visible = True
                    lblkil5.Location = New Point(x, y + 60)
                    lblkil6.Visible = True
                    lblkil6.Location = New Point(x, y + 75)
                End If










            End If

            If cbodatos.Text.Trim = "Kilos" Then
                'lblrutcli.Text = TxtClirut.Text


                Dim sql2 As String = "SELECT kilos from rpt_despacho_informe where ddes_rutcli= '" + TxtClirut.Text + "' and despacho = '" + txtfolio.Text.Trim() + "' "

                Dim tabla2 As DataTable = fnc.ListarTablasSQL(sql2)

                If tabla2.Rows.Count > 0 Then

                    If traecantidad = 1 Then
                        lblkil.Text = tabla2.Rows(0)(0).ToString()

                    End If
                    If traecantidad = 2 Then
                        lblkil.Text = tabla2.Rows(0)(0).ToString()
                        lblkil2.Text = tabla2.Rows(1)(0).ToString()
                    End If
                    If traecantidad = 3 Then
                        lblkil.Text = tabla2.Rows(0)(0).ToString()
                        lblkil2.Text = tabla2.Rows(1)(0).ToString()
                        lblkil3.Text = tabla2.Rows(2)(0).ToString()
                    End If
                    If traecantidad = 4 Then
                        lblkil.Text = tabla2.Rows(0)(0).ToString()
                        lblkil2.Text = tabla2.Rows(1)(0).ToString()
                        lblkil3.Text = tabla2.Rows(2)(0).ToString()
                        lblkil4.Text = tabla2.Rows(3)(0).ToString()
                    End If
                    If traecantidad = 5 Then
                        lblkil.Text = tabla2.Rows(0)(0).ToString()
                        lblkil2.Text = tabla2.Rows(1)(0).ToString()
                        lblkil3.Text = tabla2.Rows(2)(0).ToString()
                        lblkil4.Text = tabla2.Rows(3)(0).ToString()
                        lblkil5.Text = tabla2.Rows(4)(0).ToString()
                    End If
                    If traecantidad = 6 Then
                        lblkil.Text = tabla2.Rows(0)(0).ToString()
                        lblkil2.Text = tabla2.Rows(1)(0).ToString()
                        lblkil3.Text = tabla2.Rows(2)(0).ToString()
                        lblkil4.Text = tabla2.Rows(3)(0).ToString()
                        lblkil5.Text = tabla2.Rows(4)(0).ToString()
                        lblkil6.Text = tabla2.Rows(5)(0).ToString()
                    End If




                End If






            End If
        End If
    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        If cbodatos.Text = "" Then


        Else
            Dim SqlElimina As String = "DELETE FROM datos_informes where rutcli= '" + TxtClirut.Text + "' and dato = '" + cbodatos.Text.Trim() + "'  "
            fnc.MovimientoSQL(SqlElimina)


        End If
    End Sub
End Class
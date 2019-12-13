Imports System.Xml
Imports System.IO

Public Class Frm_Facturacion

    Dim fnc As New Funciones
    'PARAMETROS
    'Dim Multiplicador 'Dolar, Uf, Peso, etc.
    'Dim INOUT_VAL As String = "" '0 SOPORTANTE 3 TONELADA  
    'Dim valor_dolar As Integer = 0

    Dim DIA_GRACIA As Integer = 0
    Dim ALMAC_VAL As String = "" '0 SOPORTANTE 3 TONELADA
    Dim TipNum As Integer = 0 '1 Normal     2 Escala por Periodo    3 Escala Diaria  
    Dim ValAlmac As Integer = 0
    Dim CobroManual As Boolean
    Dim lecturaCajas As Boolean = False


    Private Sub btn_BuscaCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_BuscaCliente.Click
        Dim frm As New Lst_AyudaClientes
        frm.ShowDialog(Frm_Principal)
        txtclirut.Text = Frm_Principal.buscavalor
        txtclinom.Text = RetornaCliente(QuitarCaracteres(txtclirut.Text))
        txtclirut.Enabled = False
        txtcodcontrato.Enabled = True
        txtnom_contrato.Text = ""
        txtcodcontrato.Text = ""
        Frm_Principal.buscavalor = ""
        txtcodcontrato.Focus()
        Btn_BuscaContrato.Enabled = True

    End Sub

    Private Sub Btn_BuscaContrato_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_BuscaContrato.Click
        Dim frm As New Lst_AyudaContratos
        frm.condicion = "WHERE  cont_rutclie='" + QuitarCaracteres(txtclirut.Text) + "'"
        frm.ShowDialog(Frm_Principal)

        If Frm_Principal.buscavalor.ToString() = "" Then
            Exit Sub
        End If

        Console.Write(Frm_Principal.buscavalor.ToString())
        Dim sql As String = "SELECT cont_descr, cont_tunelG, cont_tipAlmc, Dcon_Medida, ROUND(Dcon_Valor*mon_valor,0), cont_manual, Dcon_Valor, mon_valor, cont_diagracia, cont_lectura " +
            "FROM contrato INNER JOIN ContratosDetalle ON Dcon_Codigo=cont_codi INNER JOIN monedas ON mon_codi=Dcon_Moneda " +
            "WHERE cont_codi='" + Frm_Principal.buscavalor.ToString() + "' AND Dcon_ServCod='001'"

        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)
        If tabla.Rows.Count > 0 Then
            txtcodcontrato.Text = Frm_Principal.buscavalor
            txtnom_contrato.Text = tabla.Rows(0)(0).ToString()
            DIA_GRACIA = Convert.ToInt32(tabla.Rows(0)(1).ToString())
            TipNum = tabla.Rows(0)(2).ToString()
            ALMAC_VAL = tabla.Rows(0)(3).ToString()
            ValAlmac = tabla.Rows(0)(4).ToString()

            If tabla.Rows(0)(9).ToString() = "1" Then
                lecturaCajas = True
            Else
                lecturaCajas = False
            End If
        End If

        txtcodcontrato.Enabled = False
    End Sub

    Private Sub Btn_Factura_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Factura.Click

        If inicio.Value > termino.Value Then
            MsgBox("La fecha de inicio no puede ser mayor a la de término", MsgBoxStyle.Information, "Aviso")
            Exit Sub
        End If

        If Alm_In_Out() = False Then
            MsgBox("Ocurrio un error al calcular los numerales Almacenamiento, In y Out", MsgBoxStyle.Critical, "Aviso")
            Exit Sub
        End If

        If Tunel() = False Then
            MsgBox("Ocurrio un error al calcular el Tunel Congelado", MsgBoxStyle.Critical, "Aviso")
            Exit Sub
        End If
        If Arriendo() = False Then
            MsgBox("Ocurrio un error al calcular el Arriendo", MsgBoxStyle.Critical, "Aviso")
            Exit Sub
        End If

        Seguro()
        diferencial()
        LecturaDeEnvases()
        EstadiaMenor15Dias()
        CobroPicking()
        CobroCargaManual()
        CobroDescargaManual()
        CobrosVas()
        Custodia()
        SumaTotales()

    End Sub

    Function Alm_In_Out() As Boolean

        Dim TipNumCod As Integer = 0
        Dim multiplicador As Double = 1

        Dim moneda As String = "SELECT Dcon_Moneda, Dcon_valor FROM ContratosDetalle WHERE Dcon_Codigo='" + txtcodcontrato.Text + "' AND Dcon_ServCod='001'"

        Dim tbmoneda As DataTable = fnc.ListarTablasSQL(moneda)
        If tbmoneda.Rows.Count > 0 Then
            multiplicador = MultiplicadorMonedas(tbmoneda.Rows(0)(0).ToString())
        End If

        'llena almacenamiento
        Dim Alm As String = "SELECT * FROM dbo.QRY_KARDEXCONGRACIA('" + inicio.Value + "', '" + termino.Value + "', '" + txtcodcontrato.Text + "','" + DIA_GRACIA.ToString() + "','0')"
        DgvKardex.DataSource = fnc.ListarTablasSQL(Alm)
        Dim diff As Integer = DateDiff(DateInterval.Day, CType(devuelve_fecha_Formato2(inicio.Value), Date), CType(devuelve_fecha_Formato2(termino.Value), Date))

        If TipNum = 1 Then
            'sin escala

            Dim sql As String = "SELECT isnull(SUM(SALDO),0), isnull(SUM(S2KIL),0) FROM dbo.QRY_KARDEXCONGRACIA('" + inicio.Value + "', '" + termino.Value + "', '" + txtcodcontrato.Text + "','" + DIA_GRACIA.ToString() + "','0')"
            Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

            If tabla.Rows.Count = 0 Then
                MsgBox("Ocurrio un error al capturar el numeral", MsgBoxStyle.Critical, "Aviso")
                Return False
                Exit Function
            End If

            If ALMAC_VAL = "001" Then 'SOPORTANTE
                DgvFactDeta.Rows.Add("001", NombreServicio("001"), tabla.Rows(0)(0).ToString(), "0", "0", tbmoneda.Rows(0)(1).ToString(), ValAlmac, ValAlmac * CInt(tabla.Rows(0)(0).ToString()), ALMAC_VAL)
            ElseIf ALMAC_VAL = "003" Then  'TONELADA
                DgvFactDeta.Rows.Add("001", NombreServicio("001"), Math.Round(Convert.ToDouble(tabla.Rows(0)(1).ToString()) / 1000, 3), "0", "0", tbmoneda.Rows(0)(1).ToString(), ValAlmac, Math.Round(ValAlmac * Convert.ToDouble(tabla.Rows(0)(1).ToString()) / 1000, 0), ALMAC_VAL)
            Else
                MsgBox("El servicio Almacenamiento solo se puede cobrar por tonelada o soportantes", MsgBoxStyle.Critical, "Aviso")
                Return False
                Exit Function
            End If

        ElseIf TipNum = 2 Then   'Escala por periodo

            'Seleccionar tramos
            Dim sqlEsc As String = "SELECT esc_ntramos, esc_dtramo1, esc_htramo1, esc_valor1, esc_dtramo2, esc_htramo2, esc_valor2, esc_dtramo3, esc_htramo3, esc_valor3, " +
                                    "esc_dtramo4, esc_htramo4, esc_valor4, esc_dtramo5, esc_htramo5, esc_valor5, esc_dtramo6, esc_htramo6, esc_valor6, " +
                                    "esc_dtramo7, esc_htramo7, esc_valor7, esc_dtramo8, esc_htramo8, esc_valor8, esc_dtramo9, esc_htramo9, esc_valor9, " +
                                    "esc_dtramo10, esc_htramo10, esc_valor10 " +
                                    "FROM FacEscalas WHERE esc_contr='" + txtcodcontrato.Text + "' AND esc_servi='001'"

            Dim TbEsc As DataTable = fnc.ListarTablasSQL(sqlEsc)

            If TbEsc.Rows.Count > 0 Then
                'Dim ntramos As Integer = CInt(TbEsc.Rows(0)(0).ToString())

                Dim ValTot As Double = 0
                Dim nsopo As Double = 0

                Dim totsopo As Integer = 0
                Dim totsopok As Double = 0

                For i As Integer = 0 To DgvKardex.Rows.Count - 1

                    Dim TotDia As Double = 0

                    If ALMAC_VAL = "001" Then 'SOPORTANTE
                        TotDia = DgvKardex.Rows(i).Cells("SALDO").Value.ToString()
                        If TotDia >= CDbl(TbEsc.Rows(0)(1).ToString()) AndAlso TotDia <= CDbl(TbEsc.Rows(0)(2).ToString()) Then
                            ValTot = ValTot + (TotDia * CDbl(TbEsc.Rows(0)(3).ToString() * multiplicador))
                        ElseIf TotDia >= CDbl(TbEsc.Rows(0)(4).ToString()) AndAlso TotDia <= CDbl(TbEsc.Rows(0)(5).ToString()) Then
                            ValTot = ValTot + (TotDia * CDbl(TbEsc.Rows(0)(6).ToString() * multiplicador))
                        ElseIf TotDia >= CDbl(TbEsc.Rows(0)(7).ToString()) AndAlso TotDia <= CDbl(TbEsc.Rows(0)(8).ToString()) Then
                            ValTot = ValTot + (TotDia * CDbl(TbEsc.Rows(0)(9).ToString() * multiplicador))
                        ElseIf TotDia >= CDbl(TbEsc.Rows(0)(10).ToString()) AndAlso TotDia <= CDbl(TbEsc.Rows(0)(11).ToString()) Then
                            ValTot = ValTot + (TotDia * CDbl(TbEsc.Rows(0)(12).ToString() * multiplicador))
                        ElseIf TotDia >= CDbl(TbEsc.Rows(0)(13).ToString()) AndAlso TotDia <= CDbl(TbEsc.Rows(0)(14).ToString()) Then
                            ValTot = ValTot + (TotDia * CDbl(TbEsc.Rows(0)(15).ToString() * multiplicador))
                        ElseIf TotDia >= CDbl(TbEsc.Rows(0)(16).ToString()) AndAlso TotDia <= CDbl(TbEsc.Rows(0)(17).ToString()) Then
                            ValTot = ValTot + (TotDia * CDbl(TbEsc.Rows(0)(18).ToString() * multiplicador))
                        ElseIf TotDia >= CDbl(TbEsc.Rows(0)(19).ToString()) AndAlso TotDia <= CDbl(TbEsc.Rows(0)(20).ToString()) Then
                            ValTot = ValTot + (TotDia * CDbl(TbEsc.Rows(0)(21).ToString() * multiplicador))
                        ElseIf TotDia >= CDbl(TbEsc.Rows(0)(22).ToString()) AndAlso TotDia <= CDbl(TbEsc.Rows(0)(23).ToString()) Then
                            ValTot = ValTot + (TotDia * CDbl(TbEsc.Rows(0)(24).ToString() * multiplicador))
                        ElseIf TotDia >= CDbl(TbEsc.Rows(0)(25).ToString()) AndAlso TotDia <= CDbl(TbEsc.Rows(0)(26).ToString()) Then
                            ValTot = ValTot + (TotDia * CDbl(TbEsc.Rows(0)(27).ToString() * multiplicador))
                        ElseIf TotDia >= CDbl(TbEsc.Rows(0)(28).ToString()) AndAlso TotDia <= CDbl(TbEsc.Rows(0)(29).ToString()) Then
                            ValTot = ValTot + (TotDia * CDbl(TbEsc.Rows(0)(30).ToString() * multiplicador))
                        End If
                        nsopo = nsopo + TotDia
                    ElseIf ALMAC_VAL = "003" Then  'TONELADA
                        TotDia = DgvKardex.Rows(i).Cells("SALDOKIL").Value.ToString()
                        If TotDia >= CDbl(TbEsc.Rows(0)(1).ToString()) AndAlso TotDia <= CDbl(TbEsc.Rows(0)(2).ToString()) Then
                            ValTot = ValTot + Math.Round((TotDia / 1000) * Convert.ToDouble(TbEsc.Rows(0)(3).ToString() * multiplicador), 2)
                        ElseIf TotDia >= CDbl(TbEsc.Rows(0)(4).ToString()) AndAlso TotDia <= CDbl(TbEsc.Rows(0)(5).ToString()) Then
                            ValTot = ValTot + Math.Round((TotDia / 1000) * Convert.ToDouble(TbEsc.Rows(0)(6).ToString() * multiplicador), 2)
                        ElseIf TotDia >= CDbl(TbEsc.Rows(0)(7).ToString()) AndAlso TotDia <= CDbl(TbEsc.Rows(0)(8).ToString()) Then
                            ValTot = ValTot + Math.Round((TotDia / 1000) * Convert.ToDouble(TbEsc.Rows(0)(9).ToString() * multiplicador), 2)
                        ElseIf TotDia >= CDbl(TbEsc.Rows(0)(10).ToString()) AndAlso TotDia <= CDbl(TbEsc.Rows(0)(11).ToString()) Then
                            ValTot = ValTot + Math.Round((TotDia / 1000) * Convert.ToDouble(TbEsc.Rows(0)(12).ToString() * multiplicador), 2)
                        ElseIf TotDia >= CDbl(TbEsc.Rows(0)(13).ToString()) AndAlso TotDia <= CDbl(TbEsc.Rows(0)(14).ToString()) Then
                            ValTot = ValTot + Math.Round((TotDia / 1000) * Convert.ToDouble(TbEsc.Rows(0)(15).ToString() * multiplicador), 2)
                        ElseIf TotDia >= CDbl(TbEsc.Rows(0)(16).ToString()) AndAlso TotDia <= CDbl(TbEsc.Rows(0)(17).ToString()) Then
                            ValTot = ValTot + Math.Round((TotDia / 1000) * Convert.ToDouble(TbEsc.Rows(0)(18).ToString() * multiplicador), 2)
                        ElseIf TotDia >= CDbl(TbEsc.Rows(0)(19).ToString()) AndAlso TotDia <= CDbl(TbEsc.Rows(0)(20).ToString()) Then
                            ValTot = ValTot + Math.Round((TotDia / 1000) * Convert.ToDouble(TbEsc.Rows(0)(21).ToString() * multiplicador), 2)
                        ElseIf TotDia >= CDbl(TbEsc.Rows(0)(22).ToString()) AndAlso TotDia <= CDbl(TbEsc.Rows(0)(23).ToString()) Then
                            ValTot = ValTot + Math.Round((TotDia / 1000) * Convert.ToDouble(TbEsc.Rows(0)(24).ToString() * multiplicador), 2)
                        ElseIf TotDia >= CDbl(TbEsc.Rows(0)(25).ToString()) AndAlso TotDia <= CDbl(TbEsc.Rows(0)(26).ToString()) Then
                            ValTot = ValTot + Math.Round((TotDia / 1000) * Convert.ToDouble(TbEsc.Rows(0)(27).ToString() * multiplicador), 2)
                        ElseIf TotDia >= CDbl(TbEsc.Rows(0)(28).ToString()) AndAlso TotDia <= CDbl(TbEsc.Rows(0)(29).ToString()) Then
                            ValTot = ValTot + Math.Round((TotDia / 1000) * Convert.ToDouble(TbEsc.Rows(0)(30).ToString() * multiplicador), 2)
                        End If
                        nsopo = nsopo + Math.Round(TotDia / 1000, 3)
                    End If
                    totsopo = totsopo + DgvKardex.Rows(i).Cells("SALDO").Value.ToString()
                    totsopok = totsopok + DgvKardex.Rows(i).Cells("SALDOKIL").Value.ToString()
                Next

                DgvFactDeta.Rows.Add("001", NombreServicio("001"), nsopo, "0", "0", Multiplicador, 0, Math.Round(ValTot, 0), ALMAC_VAL)
            Else
                MsgBox("El contrato no tiene escala, debe cambiar la config. del contrato o agregar la escala que corresponda", MsgBoxStyle.Critical, "Aviso")
                Return False
                Exit Function
            End If
        ElseIf TipNum = 3 Then 'Escala promedio periodo a facturar

            Dim sql As String = "SELECT isnull(SUM(SALDO),0), isnull(SUM(S2KIL),0) FROM dbo.QRY_KARDEXCONGRACIA('" + inicio.Value + "', '" + termino.Value + "', '" + txtcodcontrato.Text + "','" + DIA_GRACIA.ToString() + "','0')"
            Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

            Dim sqlEsc As String = "SELECT esc_ntramos, esc_dtramo1, esc_htramo1, esc_valor1, esc_dtramo2, esc_htramo2, esc_valor2, esc_dtramo3, esc_htramo3, esc_valor3, " +
                                    "esc_dtramo4, esc_htramo4, esc_valor4, esc_dtramo5, esc_htramo5, esc_valor5, esc_dtramo6, esc_htramo6, esc_valor6, " +
                                    "esc_dtramo7, esc_htramo7, esc_valor7, esc_dtramo8, esc_htramo8, esc_valor8, esc_dtramo9, esc_htramo9, esc_valor9, " +
                                    "esc_dtramo10, esc_htramo10, esc_valor10 " +
                                    "FROM FacEscalas WHERE esc_contr='" + txtcodcontrato.Text + "' AND esc_servi='001'"

            Dim TbEsc As DataTable = fnc.ListarTablasSQL(sqlEsc)
            Dim TotDia As Double = 0
            Dim tarifa As Double = 0

            If ALMAC_VAL = "001" Then 'SOPORTANTE

                TotDia = Convert.ToDouble(tabla.Rows(0)(0).ToString()) / diff

                If TotDia >= CDbl(TbEsc.Rows(0)(1).ToString()) AndAlso TotDia <= CDbl(TbEsc.Rows(0)(2).ToString()) Then
                    tarifa = CDbl(TbEsc.Rows(0)(3).ToString())
                ElseIf TotDia >= CDbl(TbEsc.Rows(0)(4).ToString()) AndAlso TotDia <= CDbl(TbEsc.Rows(0)(5).ToString()) Then
                    tarifa = CDbl(TbEsc.Rows(0)(6).ToString())
                ElseIf TotDia >= CDbl(TbEsc.Rows(0)(7).ToString()) AndAlso TotDia <= CDbl(TbEsc.Rows(0)(8).ToString()) Then
                    tarifa = CDbl(TbEsc.Rows(0)(9).ToString())
                ElseIf TotDia >= CDbl(TbEsc.Rows(0)(10).ToString()) AndAlso TotDia <= CDbl(TbEsc.Rows(0)(11).ToString()) Then
                    tarifa = CDbl(TbEsc.Rows(0)(12).ToString())
                ElseIf TotDia >= CDbl(TbEsc.Rows(0)(13).ToString()) AndAlso TotDia <= CDbl(TbEsc.Rows(0)(14).ToString()) Then
                    tarifa = CDbl(TbEsc.Rows(0)(15).ToString())
                ElseIf TotDia >= CDbl(TbEsc.Rows(0)(16).ToString()) AndAlso TotDia <= CDbl(TbEsc.Rows(0)(17).ToString()) Then
                    tarifa = CDbl(TbEsc.Rows(0)(18).ToString())
                ElseIf TotDia >= CDbl(TbEsc.Rows(0)(19).ToString()) AndAlso TotDia <= CDbl(TbEsc.Rows(0)(20).ToString()) Then
                    tarifa = CDbl(TbEsc.Rows(0)(21).ToString())
                ElseIf TotDia >= CDbl(TbEsc.Rows(0)(22).ToString()) AndAlso TotDia <= CDbl(TbEsc.Rows(0)(23).ToString()) Then
                    tarifa = CDbl(TbEsc.Rows(0)(24).ToString())
                ElseIf TotDia >= CDbl(TbEsc.Rows(0)(25).ToString()) AndAlso TotDia <= CDbl(TbEsc.Rows(0)(26).ToString()) Then
                    tarifa = CDbl(TbEsc.Rows(0)(27).ToString())
                ElseIf TotDia >= CDbl(TbEsc.Rows(0)(28).ToString()) AndAlso TotDia <= CDbl(TbEsc.Rows(0)(29).ToString()) Then
                    tarifa = CDbl(TbEsc.Rows(0)(30).ToString())
                End If

            ElseIf ALMAC_VAL = "003" Then  'TONELADA

                TotDia = Convert.ToDouble(tabla.Rows(0)(1).ToString()) / DateDiff(DateInterval.Day, inicio, termino)

                If TotDia >= CDbl(TbEsc.Rows(0)(1).ToString()) AndAlso TotDia <= CDbl(TbEsc.Rows(0)(2).ToString()) Then
                    tarifa = Convert.ToDouble(TbEsc.Rows(0)(3).ToString())
                ElseIf TotDia >= CDbl(TbEsc.Rows(0)(4).ToString()) AndAlso TotDia <= CDbl(TbEsc.Rows(0)(5).ToString()) Then
                    tarifa = Convert.ToDouble(TbEsc.Rows(0)(6).ToString())
                ElseIf TotDia >= CDbl(TbEsc.Rows(0)(7).ToString()) AndAlso TotDia <= CDbl(TbEsc.Rows(0)(8).ToString()) Then
                    tarifa = Convert.ToDouble(TbEsc.Rows(0)(9).ToString())
                ElseIf TotDia >= CDbl(TbEsc.Rows(0)(10).ToString()) AndAlso TotDia <= CDbl(TbEsc.Rows(0)(11).ToString()) Then
                    tarifa = Convert.ToDouble(TbEsc.Rows(0)(12).ToString())
                ElseIf TotDia >= CDbl(TbEsc.Rows(0)(13).ToString()) AndAlso TotDia <= CDbl(TbEsc.Rows(0)(14).ToString()) Then
                    tarifa = Convert.ToDouble(TbEsc.Rows(0)(15).ToString())
                ElseIf TotDia >= CDbl(TbEsc.Rows(0)(16).ToString()) AndAlso TotDia <= CDbl(TbEsc.Rows(0)(17).ToString()) Then
                    tarifa = Convert.ToDouble(TbEsc.Rows(0)(18).ToString())
                ElseIf TotDia >= CDbl(TbEsc.Rows(0)(19).ToString()) AndAlso TotDia <= CDbl(TbEsc.Rows(0)(20).ToString()) Then
                    tarifa = Convert.ToDouble(TbEsc.Rows(0)(21).ToString())
                ElseIf TotDia >= CDbl(TbEsc.Rows(0)(22).ToString()) AndAlso TotDia <= CDbl(TbEsc.Rows(0)(23).ToString()) Then
                    tarifa = Convert.ToDouble(TbEsc.Rows(0)(24).ToString())
                ElseIf TotDia >= CDbl(TbEsc.Rows(0)(25).ToString()) AndAlso TotDia <= CDbl(TbEsc.Rows(0)(26).ToString()) Then
                    tarifa = Convert.ToDouble(TbEsc.Rows(0)(27).ToString())
                ElseIf TotDia >= CDbl(TbEsc.Rows(0)(28).ToString()) AndAlso TotDia <= CDbl(TbEsc.Rows(0)(29).ToString()) Then
                    tarifa = Convert.ToDouble(TbEsc.Rows(0)(30).ToString())
                End If

            End If

            If ALMAC_VAL = "001" Then 'SOPORTANTE
                DgvFactDeta.Rows.Add("001", NombreServicio("001"), tabla.Rows(0)(0).ToString(), "0", "0", tarifa, (multiplicador * tarifa), (multiplicador * tarifa) * CInt(tabla.Rows(0)(0).ToString()), ALMAC_VAL)
            ElseIf ALMAC_VAL = "003" Then  'TONELADA
                DgvFactDeta.Rows.Add("001", NombreServicio("001"), Math.Round(Convert.ToDouble(tabla.Rows(0)(1).ToString()) / 1000, 3), "0", "0", tarifa, ValAlmac, Math.Round(tarifa * Convert.ToDouble(tabla.Rows(0)(1).ToString()) / 1000, 0), tarifa)
            Else
                MsgBox("El servicio Almacenamiento solo se puede cobrar por tonelada o soportantes", MsgBoxStyle.Critical, "Aviso")
                Return False
                Exit Function
            End If

        End If


        'CONSULTO TIPO NUMERAL

        '------------------------------------------------------------ SELECCIONAR INGRESO X TIPO COBRO ------------------------------------------------------------------------------------------------------'
        Dim add As String = ""
        'If CobroManual = False Then
        '    add = " AND CAR_DESC='0' "
        'End If

        moneda = "SELECT Dcon_Moneda FROM ContratosDetalle WHERE Dcon_Codigo='" + txtcodcontrato.Text + "' AND Dcon_ServCod='003'"
        tbmoneda = fnc.ListarTablasSQL(moneda)

        If tbmoneda.Rows.Count > 0 Then
            multiplicador = MultiplicadorMonedas(tbmoneda.Rows(0)(0).ToString())
        End If

        Dim QryIn As String = "SELECT Dcon_Valor, Dcon_Medida , isnull(SUM(SOPO_SC),0)AS UNID, ROUND(isnull(SUM(PES_SC),0),2) AS PES FROM GvwfactINOUT INNER JOIN ContratosDetalle ON Dcon_Codigo=CONTRATO " +
        "WHERE tipo='003' AND FECHA>='" + devuelve_fecha(inicio.Value) + "' AND FECHA<='" + devuelve_fecha(termino.Value) + "' AND CONTRATO='" + txtcodcontrato.Text + "'  AND Dcon_ServCod='003' " +
        "AND ORIGEN='25' GROUP BY Dcon_Valor, Dcon_Medida "

        Dim tablaIn As DataTable = fnc.ListarTablasSQL(QryIn)



        If tablaIn.Rows.Count > 0 Then
            If tablaIn.Rows(0)(1).ToString() = "001" Then

                DgvFactDeta.Rows.Add("003", NombreServicio("003"), tablaIn.Rows(0)(2).ToString(), "0", "0", tablaIn.Rows(0)(0).ToString(), Math.Round(multiplicador * tablaIn.Rows(0)(0).ToString(), 0),
                                     Math.Round(multiplicador * tablaIn.Rows(0)(0).ToString(), 0) * tablaIn.Rows(0)(2).ToString(), tablaIn.Rows(0)(1).ToString())

            ElseIf tablaIn.Rows(0)(1).ToString() = "003" Then

                DgvFactDeta.Rows.Add("003", NombreServicio("003"), Math.Round(Convert.ToDouble(tablaIn.Rows(0)(3).ToString()) / 1000, 3), "0", "0", tablaIn.Rows(0)(0).ToString(), Math.Round(multiplicador * tablaIn.Rows(0)(0).ToString(), 0),
                                     Math.Round(multiplicador * tablaIn.Rows(0)(0).ToString(), 0) * Math.Round(Convert.ToDouble(tablaIn.Rows(0)(3).ToString()) / 1000, 3), tablaIn.Rows(0)(1).ToString())

            Else
                MsgBox("El servicio IN solo se puede cobrar por tonelada o soportantes", MsgBoxStyle.Critical, "Aviso")
                Return False
                Exit Function
            End If
        End If

        moneda = "SELECT Dcon_Moneda FROM ContratosDetalle WHERE Dcon_Codigo='" + txtcodcontrato.Text + "' AND Dcon_ServCod='002'"
        tbmoneda = fnc.ListarTablasSQL(moneda)

        If tbmoneda.Rows.Count > 0 Then
            multiplicador = MultiplicadorMonedas(tbmoneda.Rows(0)(0).ToString())
        End If

        Dim QryOut As String = "SELECT Dcon_Valor, Dcon_Medida , isnull(SUM(SOPO_SC),0)AS UNID, ROUND(isnull(SUM(PES_SC),0),2) AS PES FROM GvwfactINOUT INNER JOIN ContratosDetalle ON Dcon_Codigo=CONTRATO " +
        "WHERE tipo='002' AND FECHA>='" + devuelve_fecha(inicio.Value) + "' AND FECHA<='" + devuelve_fecha(termino.Value) + "' AND CONTRATO='" + txtcodcontrato.Text + "' AND Dcon_ServCod='002' AND ORIGEN='10' " +
        "GROUP BY Dcon_Valor, Dcon_Medida "

        Dim tablaOut As DataTable = fnc.ListarTablasSQL(QryOut)


        If tablaOut.Rows.Count > 0 Then
            If tablaOut.Rows(0)(1).ToString() = "001" Then

                DgvFactDeta.Rows.Add("002", NombreServicio("002"), tablaOut.Rows(0)(2).ToString(), "0", "0", tablaOut.Rows(0)(0).ToString(), Math.Round(multiplicador * tablaOut.Rows(0)(0).ToString(), 0),
                                     Math.Round(multiplicador * tablaOut.Rows(0)(0).ToString(), 0) * tablaOut.Rows(0)(2).ToString(), tablaOut.Rows(0)(1).ToString())

            ElseIf tablaOut.Rows(0)(1).ToString() = "003" Then

                DgvFactDeta.Rows.Add("002", NombreServicio("002"), Math.Round(Convert.ToDouble(tablaOut.Rows(0)(3).ToString()) / 1000, 3), "0", "0", tablaOut.Rows(0)(0).ToString(), Math.Round(multiplicador * tablaOut.Rows(0)(0).ToString(), 0),
                                     Math.Round(multiplicador * tablaOut.Rows(0)(0).ToString(), 0) * Math.Round(Convert.ToDouble(tablaOut.Rows(0)(3).ToString()) / 1000, 3), tablaOut.Rows(0)(1).ToString())

            Else
                MsgBox("El servicio OUT solo se puede cobrar por tonelada o soportantes", MsgBoxStyle.Critical, "Aviso")
                Return False
                Exit Function
            End If
        End If

        Return True
    End Function

    Function Tunel() As Boolean

        Dim QryTnl As String = "SELECT SUM(SOPO_TUN), SUM(UNI_TUN), SUM(PES_TUN), Dcon_Valor, Dcon_Medida,  mon_valor " +
                               "FROM GvwFactINOUT INNER JOIN ContratosDetalle ON Dcon_Codigo=CONTRATO INNER JOIN monedas ON mon_codi=Dcon_Moneda " +
                               "WHERE FECHA>='" + devuelve_fecha(inicio.Value) + "' AND FECHA<='" + devuelve_fecha(termino.Value) + "' AND CONTRATO='" + txtcodcontrato.Text + "' " +
                               "AND Dcon_ServCod='004' GROUP BY Dcon_Valor, Dcon_Medida, Dcon_moneda, mon_valor "

        Dim TablaTnl As DataTable = fnc.ListarTablasSQL(QryTnl)

        Dim sql As String = "SELECT esc_ntramos, esc_dtramo1, esc_htramo1, esc_valor1, esc_dtramo2, esc_htramo2, esc_valor2, esc_dtramo3, esc_htramo3, esc_valor3, esc_dtramo4, esc_htramo4, esc_valor4 FROM FacEscalas " +
                            "WHERE esc_contr='" + txtcodcontrato.Text + "' AND esc_servi='004'"

        Dim tablaEsc As DataTable = fnc.ListarTablasSQL(sql)

        If tablaEsc.Rows.Count > 0 Then 'Tiene escala
            Dim TotMens As Double
            Dim TotCobro As Double
            Dim TotValor As Double

            If TablaTnl.Rows(0)(4).ToString() = "001" Then
                TotMens = Convert.ToDouble(TablaTnl.Rows(0)(0).ToString())

                If TotMens >= CDbl(tablaEsc.Rows(0)(1).ToString()) AndAlso TotMens <= CDbl(tablaEsc.Rows(0)(2).ToString()) Then
                    TotCobro = TotMens * CDbl(tablaEsc.Rows(0)(3).ToString() * tablaEsc.Rows(0)(5).ToString())
                ElseIf TotMens >= CDbl(tablaEsc.Rows(0)(4).ToString()) AndAlso TotMens <= CDbl(tablaEsc.Rows(0)(5).ToString()) Then
                    TotCobro = TotMens * CDbl(tablaEsc.Rows(0)(6).ToString() * tablaEsc.Rows(0)(5).ToString())
                ElseIf TotMens >= CDbl(tablaEsc.Rows(0)(7).ToString()) AndAlso TotMens <= CDbl(tablaEsc.Rows(0)(8).ToString()) Then
                    TotCobro = TotMens * CDbl(tablaEsc.Rows(0)(9).ToString() * tablaEsc.Rows(0)(5).ToString())
                ElseIf TotMens >= CDbl(tablaEsc.Rows(0)(10).ToString()) AndAlso TotMens <= CDbl(tablaEsc.Rows(0)(11).ToString()) Then
                    TotCobro = TotMens * CDbl(tablaEsc.Rows(0)(12).ToString() * tablaEsc.Rows(0)(5).ToString())
                End If

                DgvFactDeta.Rows.Add("004", "TUNEL CONGELADO", TotMens, "0", "0", tablaEsc.Rows(0)(5).ToString(), TotMens * tablaEsc.Rows(0)(5).ToString(), TotCobro, TablaTnl.Rows(0)(4).ToString())

            ElseIf TablaTnl.Rows(0)(4).ToString() = "003" Then
                TotMens = Convert.ToDouble(TablaTnl.Rows(0)(2).ToString())

                If TotMens >= CDbl(tablaEsc.Rows(0)(1).ToString()) AndAlso TotMens <= CDbl(tablaEsc.Rows(0)(2).ToString()) Then
                    TotCobro = Math.Round(Math.Round(TotMens / 1000, 3) * CDbl(tablaEsc.Rows(0)(3).ToString() * tablaEsc.Rows(0)(5).ToString()), 3)
                    TotValor = CDbl(tablaEsc.Rows(0)(3).ToString())
                ElseIf TotMens >= CDbl(tablaEsc.Rows(0)(4).ToString()) AndAlso TotMens <= CDbl(tablaEsc.Rows(0)(5).ToString()) Then
                    TotCobro = Math.Round(Math.Round(TotMens / 1000, 3) * CDbl(tablaEsc.Rows(0)(6).ToString() * tablaEsc.Rows(0)(5).ToString()), 3)
                    TotValor = CDbl(tablaEsc.Rows(0)(6).ToString())
                ElseIf TotMens >= CDbl(tablaEsc.Rows(0)(7).ToString()) AndAlso TotMens <= CDbl(tablaEsc.Rows(0)(8).ToString()) Then
                    TotCobro = Math.Round(Math.Round(TotMens / 1000, 3) * CDbl(tablaEsc.Rows(0)(9).ToString() * tablaEsc.Rows(0)(5).ToString()), 3)
                    TotValor = CDbl(tablaEsc.Rows(0)(9).ToString())
                ElseIf TotMens >= CDbl(tablaEsc.Rows(0)(10).ToString()) AndAlso TotMens <= CDbl(tablaEsc.Rows(0)(11).ToString()) Then
                    TotCobro = Math.Round(Math.Round(TotMens / 1000, 3) * CDbl(tablaEsc.Rows(0)(12).ToString() * tablaEsc.Rows(0)(5).ToString()), 3)
                    TotValor = CDbl(tablaEsc.Rows(0)(12).ToString())
                End If
                DgvFactDeta.Rows.Add("004", "TUNEL CONGELADO", Math.Round(TotMens / 1000, 3), "0", "0", TotValor, TotValor * tablaEsc.Rows(0)(5).ToString(), TotCobro, TablaTnl.Rows(0)(4).ToString())
            Else
                MsgBox("El servicio tunel congelado solo se puede cobrar por tonelada o soportantes", MsgBoxStyle.Critical, "Aviso")
                Return False
                Exit Function
            End If

        Else ' No tiene escala

            If TablaTnl.Rows.Count > 0 Then
                If TablaTnl.Rows(0)(4).ToString() = "001" Then
                    If Convert.ToDouble(TablaTnl.Rows(0)(0).ToString()) > 0 Then
                        DgvFactDeta.Rows.Add("004", "TUNEL CONGELADO", TablaTnl.Rows(0)(0).ToString(), "0", "0", TablaTnl.Rows(0)(3).ToString(), Math.Round(TablaTnl.Rows(0)(5).ToString() * TablaTnl.Rows(0)(3).ToString(), 2),
                                             Math.Round(TablaTnl.Rows(0)(5).ToString() * TablaTnl.Rows(0)(3).ToString(), 2) * Convert.ToDouble(TablaTnl.Rows(0)(0).ToString()), TablaTnl.Rows(0)(4).ToString())
                    End If
                ElseIf TablaTnl.Rows(0)(4).ToString() = "003" Then
                    DgvFactDeta.Rows.Add("004", "TUNEL CONGELADO", Math.Round(Convert.ToDouble(TablaTnl.Rows(0)(2).ToString() / 1000), 3), "0", "0", TablaTnl.Rows(0)(3).ToString(), Math.Round(TablaTnl.Rows(0)(3).ToString() * TablaTnl.Rows(0)(5).ToString(), 2),
                                         Convert.ToInt32(TablaTnl.Rows(0)(3).ToString()) * Math.Round(Convert.ToDouble(TablaTnl.Rows(0)(2).ToString() / 1000), 3), TablaTnl.Rows(0)(4).ToString())
                End If
            End If
        End If
        Return True
    End Function

    Function Arriendo() As Boolean
        'Consulta Saldo mes anterior 
        Dim multiplicador As Double = 1
        Dim moneda As String = "SELECT Dcon_Moneda FROM ContratosDetalle WHERE Dcon_Codigo='" + txtcodcontrato.Text + "' AND Dcon_ServCod='013'"
        Dim tbmoneda As DataTable = fnc.ListarTablasSQL(moneda)

        If tbmoneda.Rows.Count > 0 Then
            multiplicador = MultiplicadorMonedas(tbmoneda.Rows(0)(0).ToString())
        End If


        Dim Ingresos As String = "SELECT SUM(isnull(drec_pallet,0)) FROM detarece WHERE drec_arriendo='1'  AND drec_codvig='0' AND drec_fecrec<'" + devuelve_fecha(inicio.Value) + "' AND drec_contcli='" + txtcodcontrato.Text + "' "

        Dim Salidas As String = "SELECT SUM(isnull(ddes_pallet,0)) FROM  detadespa INNER JOIN detarece ON ddes_codrece=drec_codi  WHERE ddes_pallet='1' AND ddes_contcli='" + txtcodcontrato.Text + "'  AND drec_arriendo='1' AND ddes_fecha<'" + devuelve_fecha(inicio.Value) + "' "

        Dim tbingresos As DataTable = fnc.ListarTablasSQL(Ingresos)
        Dim tbsalidas As DataTable = fnc.ListarTablasSQL(Salidas)

        Dim ent As Integer = 0
        Dim sal As Integer = 0

        Dim sumaarriendo As Integer = 0


        If tbingresos.Rows.Count > 0 Then
            If tbingresos.Rows(0)(0).ToString() = "" Then
                ent = 0
            Else
                ent = tbingresos.Rows(0)(0).ToString()
            End If
        End If

        If tbsalidas.Rows.Count > 0 Then
            If tbsalidas.Rows(0)(0).ToString() = "" Then
                sal = 0
            Else
                sal = tbsalidas.Rows(0)(0).ToString()
            End If
        End If

        DgvArriendo.Rows.Add(devuelve_fecha_Formato2(inicio.Value.AddDays(-1)), "0", "0", (ent - sal))

        Dim desde As Date = inicio.Value.ToShortDateString()
        Dim hasta As Date = termino.Value.ToShortDateString()
        Dim contador As Integer = 0
        ' recorre saldos de la quincena
        While (desde <= termino.Value.ToShortDateString())
            Dim traerEnt As String = "SELECT SUM(isnull(drec_pallet,0)) FROM detarece WHERE drec_arriendo='1'  AND drec_codvig='0' AND drec_fecrec='" + devuelve_fecha(desde) + "' AND drec_contcli='" + txtcodcontrato.Text + "'"
            Dim traerSal As String = "SELECT SUM(isnull(ddes_pallet,0)) FROM  detadespa INNER JOIN detarece ON ddes_codrece=drec_codi  WHERE ddes_pallet='1' AND drec_arriendo='1' AND ddes_fecha='" + devuelve_fecha(desde) + "' AND ddes_contcli='" + txtcodcontrato.Text + "'"
            Dim tbEntDiaria As DataTable = fnc.ListarTablasSQL(traerEnt)
            Dim tbSalDiaria As DataTable = fnc.ListarTablasSQL(traerSal)

            If tbEntDiaria.Rows.Count > 0 Then
                If tbEntDiaria.Rows(0)(0).ToString() = "" Then
                    ent = 0
                Else
                    ent = tbEntDiaria.Rows(0)(0).ToString()
                End If
            Else
                ent = 0
            End If

            If tbSalDiaria.Rows.Count > 0 Then
                If tbSalDiaria.Rows(0)(0).ToString() = "" Then
                    sal = 0
                Else
                    sal = tbSalDiaria.Rows(0)(0).ToString()
                End If
            Else
                sal = 0
            End If
            'variable que rescata el valor del arriendo
            sumaarriendo = sumaarriendo + (ent - sal) + Convert.ToInt32(DgvArriendo.Rows(contador).Cells(3).Value.ToString())

            DgvArriendo.Rows.Add(devuelve_fecha_Formato2(desde), ent, sal, (ent - sal) + Convert.ToInt32(DgvArriendo.Rows(contador).Cells(3).Value.ToString()))
            contador += 1
            desde = desde.AddDays(1)
        End While

        Dim SqlTarifa As String = "SELECT Dcon_Valor, Dcon_Moneda FROM ContratosDetalle WHERE Dcon_Codigo='" + txtcodcontrato.Text + "' AND Dcon_ServCod='013'"
        Dim tbtarifa As DataTable = fnc.ListarTablasSQL(SqlTarifa)
        Dim tarifa As Double = 0

        If tbtarifa.Rows.Count > 0 Then
            If tbtarifa.Rows(0)(0).ToString() = "" Then
                tarifa = 0
            Else
                tarifa = Convert.ToDouble(tbtarifa.Rows(0)(0).ToString())
            End If
        Else
            tarifa = 0
        End If

        DgvFactDeta.Rows.Add("013", NombreServicio("013"), sumaarriendo, "0", "0", tarifa, Math.Round(multiplicador * tarifa, 0),
                                    Math.Round(multiplicador * tarifa, 0) * Math.Round(Convert.ToDouble(sumaarriendo), 3), "001")
        Return True
    End Function

    Function Seguro() As Boolean

        Dim SqlTarifa As String = "SELECT Dcon_Valor, Dcon_Moneda, Dcon_Medida FROM ContratosDetalle WHERE Dcon_Codigo='" + txtcodcontrato.Text + "' AND Dcon_ServCod='029'"
        Dim tbtarifa As DataTable = fnc.ListarTablasSQL(SqlTarifa)
        Dim tarifa As Double = 0
        Dim medida As String = tbtarifa.Rows(0)(2).ToString()
        Dim multiplicador As Double = MultiplicadorMonedas(tbtarifa.Rows(0)(1).ToString())
         
        Dim ValTot As Double = 0
        Dim nsopo As Double = 0

        Dim totsopo As Integer = 0
        Dim totsopok As Double = 0
         
        Dim sqlEsc As String = "SELECT esc_ntramos, esc_dtramo1, esc_htramo1, esc_valor1, esc_dtramo2, esc_htramo2, esc_valor2, esc_dtramo3, esc_htramo3, esc_valor3, " +
                                   "esc_dtramo4, esc_htramo4, esc_valor4, esc_dtramo5, esc_htramo5, esc_valor5, esc_dtramo6, esc_htramo6, esc_valor6, " +
                                   "esc_dtramo7, esc_htramo7, esc_valor7, esc_dtramo8, esc_htramo8, esc_valor8, esc_dtramo9, esc_htramo9, esc_valor9, " +
                                   "esc_dtramo10, esc_htramo10, esc_valor10 " +
                                   "FROM FacEscalas WHERE esc_contr='" + txtcodcontrato.Text + "' AND esc_servi='029'"

        Dim TbEsc As DataTable = fnc.ListarTablasSQL(sqlEsc)

        If TbEsc.Rows.Count > 0 Then
            'For i As Integer = 0 To DgvKardex.Rows.Count - 1
            '    Dim TotDia As Double = 0
            '    If medida = "001" Then 'SOPORTANTE
            '        TotDia = DgvKardex.Rows(i).Cells("SALDO").Value.ToString()
            '        If TotDia >= CDbl(TbEsc.Rows(0)(1).ToString()) AndAlso TotDia <= CDbl(TbEsc.Rows(0)(2).ToString()) Then
            '            ValTot = ValTot + (TotDia * CDbl(TbEsc.Rows(0)(3).ToString() * multiplicador))
            '        ElseIf TotDia >= CDbl(TbEsc.Rows(0)(4).ToString()) AndAlso TotDia <= CDbl(TbEsc.Rows(0)(5).ToString()) Then
            '            ValTot = ValTot + (TotDia * CDbl(TbEsc.Rows(0)(6).ToString() * multiplicador))
            '        ElseIf TotDia >= CDbl(TbEsc.Rows(0)(7).ToString()) AndAlso TotDia <= CDbl(TbEsc.Rows(0)(8).ToString()) Then
            '            ValTot = ValTot + (TotDia * CDbl(TbEsc.Rows(0)(9).ToString() * multiplicador))
            '        ElseIf TotDia >= CDbl(TbEsc.Rows(0)(10).ToString()) AndAlso TotDia <= CDbl(TbEsc.Rows(0)(11).ToString()) Then
            '            ValTot = ValTot + (TotDia * CDbl(TbEsc.Rows(0)(12).ToString() * multiplicador))
            '        ElseIf TotDia >= CDbl(TbEsc.Rows(0)(13).ToString()) AndAlso TotDia <= CDbl(TbEsc.Rows(0)(14).ToString()) Then
            '            ValTot = ValTot + (TotDia * CDbl(TbEsc.Rows(0)(15).ToString() * multiplicador))
            '        ElseIf TotDia >= CDbl(TbEsc.Rows(0)(16).ToString()) AndAlso TotDia <= CDbl(TbEsc.Rows(0)(17).ToString()) Then
            '            ValTot = ValTot + (TotDia * CDbl(TbEsc.Rows(0)(18).ToString() * multiplicador))
            '        ElseIf TotDia >= CDbl(TbEsc.Rows(0)(19).ToString()) AndAlso TotDia <= CDbl(TbEsc.Rows(0)(20).ToString()) Then
            '            ValTot = ValTot + (TotDia * CDbl(TbEsc.Rows(0)(21).ToString() * multiplicador))
            '        ElseIf TotDia >= CDbl(TbEsc.Rows(0)(22).ToString()) AndAlso TotDia <= CDbl(TbEsc.Rows(0)(23).ToString()) Then
            '            ValTot = ValTot + (TotDia * CDbl(TbEsc.Rows(0)(24).ToString() * multiplicador))
            '        ElseIf TotDia >= CDbl(TbEsc.Rows(0)(25).ToString()) AndAlso TotDia <= CDbl(TbEsc.Rows(0)(26).ToString()) Then
            '            ValTot = ValTot + (TotDia * CDbl(TbEsc.Rows(0)(27).ToString() * multiplicador))
            '        ElseIf TotDia >= CDbl(TbEsc.Rows(0)(28).ToString()) AndAlso TotDia <= CDbl(TbEsc.Rows(0)(29).ToString()) Then
            '            ValTot = ValTot + (TotDia * CDbl(TbEsc.Rows(0)(30).ToString() * multiplicador))
            '        End If
            '        nsopo = nsopo + TotDia
            '    ElseIf ALMAC_VAL = "003" Then  'TONELADA
            '        TotDia = DgvKardex.Rows(i).Cells("SALDOKIL").Value.ToString()
            '        If TotDia >= CDbl(TbEsc.Rows(0)(1).ToString()) AndAlso TotDia <= CDbl(TbEsc.Rows(0)(2).ToString()) Then
            '            ValTot = ValTot + Math.Round((TotDia / 1000) * Convert.ToDouble(TbEsc.Rows(0)(3).ToString() * multiplicador), 2)
            '        ElseIf TotDia >= CDbl(TbEsc.Rows(0)(4).ToString()) AndAlso TotDia <= CDbl(TbEsc.Rows(0)(5).ToString()) Then
            '            ValTot = ValTot + Math.Round((TotDia / 1000) * Convert.ToDouble(TbEsc.Rows(0)(6).ToString() * multiplicador), 2)
            '        ElseIf TotDia >= CDbl(TbEsc.Rows(0)(7).ToString()) AndAlso TotDia <= CDbl(TbEsc.Rows(0)(8).ToString()) Then
            '            ValTot = ValTot + Math.Round((TotDia / 1000) * Convert.ToDouble(TbEsc.Rows(0)(9).ToString() * multiplicador), 2)
            '        ElseIf TotDia >= CDbl(TbEsc.Rows(0)(10).ToString()) AndAlso TotDia <= CDbl(TbEsc.Rows(0)(11).ToString()) Then
            '            ValTot = ValTot + Math.Round((TotDia / 1000) * Convert.ToDouble(TbEsc.Rows(0)(12).ToString() * multiplicador), 2)
            '        ElseIf TotDia >= CDbl(TbEsc.Rows(0)(13).ToString()) AndAlso TotDia <= CDbl(TbEsc.Rows(0)(14).ToString()) Then
            '            ValTot = ValTot + Math.Round((TotDia / 1000) * Convert.ToDouble(TbEsc.Rows(0)(15).ToString() * multiplicador), 2)
            '        ElseIf TotDia >= CDbl(TbEsc.Rows(0)(16).ToString()) AndAlso TotDia <= CDbl(TbEsc.Rows(0)(17).ToString()) Then
            '            ValTot = ValTot + Math.Round((TotDia / 1000) * Convert.ToDouble(TbEsc.Rows(0)(18).ToString() * multiplicador), 2)
            '        ElseIf TotDia >= CDbl(TbEsc.Rows(0)(19).ToString()) AndAlso TotDia <= CDbl(TbEsc.Rows(0)(20).ToString()) Then
            '            ValTot = ValTot + Math.Round((TotDia / 1000) * Convert.ToDouble(TbEsc.Rows(0)(21).ToString() * multiplicador), 2)
            '        ElseIf TotDia >= CDbl(TbEsc.Rows(0)(22).ToString()) AndAlso TotDia <= CDbl(TbEsc.Rows(0)(23).ToString()) Then
            '            ValTot = ValTot + Math.Round((TotDia / 1000) * Convert.ToDouble(TbEsc.Rows(0)(24).ToString() * multiplicador), 2)
            '        ElseIf TotDia >= CDbl(TbEsc.Rows(0)(25).ToString()) AndAlso TotDia <= CDbl(TbEsc.Rows(0)(26).ToString()) Then
            '            ValTot = ValTot + Math.Round((TotDia / 1000) * Convert.ToDouble(TbEsc.Rows(0)(27).ToString() * multiplicador), 2)
            '        ElseIf TotDia >= CDbl(TbEsc.Rows(0)(28).ToString()) AndAlso TotDia <= CDbl(TbEsc.Rows(0)(29).ToString()) Then
            '            ValTot = ValTot + Math.Round((TotDia / 1000) * Convert.ToDouble(TbEsc.Rows(0)(30).ToString() * multiplicador), 2)
            '        End If
            '        nsopo = nsopo + Math.Round(TotDia / 1000, 3)
            '    End If
            'Next
        Else
            'Sin escala

        End If
       
        'Seleccionar tipo de seguro



        If tbtarifa.Rows.Count > 0 Then
            If tbtarifa.Rows(0)(0).ToString() = "" Then
                tarifa = 0
            Else
                tarifa = Convert.ToDouble(tbtarifa.Rows(0)(0).ToString())
            End If
        Else
            tarifa = 0
        End If

        Dim suma As Double = 0.0

        For i As Integer = 0 To DgvKardex.Rows.Count - 1

            If medida = "001" Then
                suma = suma + Convert.ToDouble(DgvKardex.Rows(i).Cells(3).Value.ToString.Replace(".", ","))
            ElseIf medida = "003" Then
                suma = suma + Convert.ToDouble(DgvKardex.Rows(i).Cells(6).Value.ToString.Replace(".", ","))
            Else
                MsgBox("Tiene una medida no esperada en el seguro, se cancelará la facturación", MsgBoxStyle.Critical, "Aviso")
                Return False
                Exit Function
            End If
        Next

        If medida = "003" Then
            suma = Math.Round(Convert.ToDouble(suma) / 1000, 3)
        End If

        DgvFactDeta.Rows.Add("029", NombreServicio("029"), suma, "0", "0", tarifa, Math.Round(multiplicador * tarifa, 0), Math.Round(multiplicador * tarifa, 0) * suma, medida)

        Return True
    End Function

    Function diferencial() As Boolean

        Dim SqlTarifa As String = "SELECT Dcon_Valor, Dcon_Moneda, Dcon_Medida FROM ContratosDetalle WHERE Dcon_Codigo='" + txtcodcontrato.Text + "' AND Dcon_ServCod='009'"
        Dim tbtarifa As DataTable = fnc.ListarTablasSQL(SqlTarifa)

        Dim tarifa As Double = 0
        Dim medida As String = tbtarifa.Rows(0)(2).ToString()
        Dim multiplicador As Double = MultiplicadorMonedas(tbtarifa.Rows(0)(1).ToString())

        If tbtarifa.Rows(0)(2).ToString() <> "003" Then
            MsgBox("Tiene una tarifa incorrecta en el diferencial de temperatura", MsgBoxStyle.Critical, "Aviso")
            Return False
        End If
        If tbtarifa.Rows.Count > 0 Then
            If tbtarifa.Rows(0)(0).ToString() = "" Then
                tarifa = 0
            Else
                tarifa = Convert.ToDouble(tbtarifa.Rows(0)(0).ToString())
            End If
        Else
            tarifa = 0
        End If

        Dim SqlDiferencial As String = "SELECT drec_codi, drec_temp,  drec_peso, '" + Math.Round(tarifa * multiplicador, 0).ToString() + "' AS dcon_valor,(cont_tempcon+cont_tempgra)As temp, " +
                                "CONVERT(DECIMAL(10,1),((cont_tempcon+cont_tempgra)-drec_temp)) AS DIF, " +
                                "ROUND((((drec_peso/1000))*'" + Math.Round(tarifa * multiplicador, 0).ToString() + "' * CONVERT(DECIMAL(10,1),((cont_tempcon+cont_tempgra)-drec_temp))*-1),0) AS VALOR_A_COBRAR  " +
                                "FROM detarece INNER JOIN contrato ON cont_codi=drec_contcli WHERE drec_temp>(cont_tempcon+cont_tempgra) AND drec_temp<>0 AND " +
                               "drec_contcli='" + txtcodcontrato.Text + "' AND  drec_fecrec>='" + devuelve_fecha(inicio.Value) + "' " +
                               "AND drec_fecrec<='" + devuelve_fecha(termino.Value) + "' AND drec_RecepTunel='1'"

        Dim tablaDiferencial As DataTable = fnc.ListarTablasSQL(SqlDiferencial)
        If tablaDiferencial.Rows.Count > 0 Then
            DgvDiferencial.DataSource = tablaDiferencial

            Dim SUMA_DIF As Double = 0.0
            Dim SUMA_PESOS As Integer = 0

            For i As Integer = 0 To tablaDiferencial.Rows.Count - 1
                SUMA_DIF = SUMA_DIF + tablaDiferencial.Rows(i)(5).ToString()
                SUMA_PESOS = SUMA_PESOS + tablaDiferencial.Rows(i)(6).ToString()
            Next

            DgvFactDeta.Rows.Add("009", NombreServicio("009"), (SUMA_DIF * -1).ToString(), "0", "0", tarifa, Math.Round(multiplicador * tarifa, 0), SUMA_PESOS, medida)
        End If

        Return True
    End Function

    Function LecturaDeEnvases() As Boolean

        If lecturaCajas = True Then
            'capturo la tarifa
            Dim SqlTarifa As String = "SELECT Dcon_Valor, Dcon_Moneda, Dcon_Medida FROM ContratosDetalle WHERE Dcon_Codigo='" + txtcodcontrato.Text + "' AND Dcon_ServCod='068'"
            Dim tbtarifa As DataTable = fnc.ListarTablasSQL(SqlTarifa)

            Dim tarifa As Double = 0
            If tbtarifa.Rows.Count = 0 Then
                MsgBox("El servicio traqueo no esta agregado al contrato", MsgBoxStyle.Critical, "Aviso")
                Return False
                Exit Function
            End If
            Dim medida As String = tbtarifa.Rows(0)(2).ToString()
            Dim multiplicador As Double = MultiplicadorMonedas(tbtarifa.Rows(0)(1).ToString())  'variable que guarda el multiplicador uf, dolar, peso, etc.
            tarifa = tbtarifa.Rows(0)(0).ToString()
            'Dim tablaservicio As DataTable

            'Captura de información traqueo entrada
            Dim SQLTRAQUEO As String = "SELECT isnull(SUM(drec_unidades),0) AS TOTAL, SUM(drec_pallet) FROM detarece INNER JOIN fichrece fr ON LEFT(drec_codi,7)=fr.frec_codi " +
                                       "WHERE drec_contcli='" + txtcodcontrato.Text + "' AND (frec_origen='25' OR frec_origen='20') AND drec_fecrec>='" + devuelve_fecha(inicio.Value) + "' AND drec_fecrec<='" + devuelve_fecha(termino.Value) + "' "

            Dim tablaTrakeo As DataTable = fnc.ListarTablasSQL(SQLTRAQUEO)

            If medida = "001" Then
                DgvFactDeta.Rows.Add("068", NombreServicio("068"), Convert.ToInt32(tablaTrakeo.Rows(0)(1).ToString()), "0", "0", tarifa, Math.Round(multiplicador * tarifa, 0), Convert.ToInt32(tablaTrakeo.Rows(0)(1).ToString()) * Math.Round(multiplicador * tarifa, 0), medida)
            ElseIf medida = "002" Then
                DgvFactDeta.Rows.Add("068", NombreServicio("068"), "0", Convert.ToInt32(tablaTrakeo.Rows(0)(0).ToString()), "0", tarifa, Math.Round(multiplicador * tarifa, 0), Convert.ToInt32(tablaTrakeo.Rows(0)(0).ToString()) * Math.Round(multiplicador * tarifa, 0), medida)
            End If

            'TRAQUEO SALIDA
            SqlTarifa = "SELECT Dcon_Valor, Dcon_Moneda, Dcon_Medida FROM ContratosDetalle WHERE Dcon_Codigo='" + txtcodcontrato.Text + "' AND Dcon_ServCod='068'"
            tbtarifa = fnc.ListarTablasSQL(SqlTarifa)

            If tbtarifa.Rows.Count = 0 Then
                MsgBox("El servicio traqueo no esta agregado al contrato", MsgBoxStyle.Critical, "Aviso")
                Return False
                Exit Function
            End If

            medida = tbtarifa.Rows(0)(2).ToString()
            multiplicador = MultiplicadorMonedas(tbtarifa.Rows(0)(1).ToString())  'variable que guarda el multiplicador uf, dolar, peso, etc.
            tarifa = tbtarifa.Rows(0)(0).ToString()
            Dim traqueo_out As String = "SELECT isnull(SUM(ddes_unidades),0), SUM(ddes_pallet) FROM detadespa INNER JOIN fichdespa ON LEFT(ddes_codi,7)=fdes_codi " +
                "WHERE ddes_contcli='" + txtcodcontrato.Text + "' AND ddes_fecha>='" + devuelve_fecha(inicio.Value) + "' AND ddes_fecha<='" + devuelve_fecha(termino.Value) + "' AND (fdes_origen='10' OR fdes_origen='20') "
            Dim tabla_tout As DataTable = fnc.ListarTablasSQL(traqueo_out)

            If medida = "001" Then
                DgvFactDeta.Rows.Add("069", NombreServicio("069"), Convert.ToInt32(tabla_tout.Rows(0)(1).ToString()), "0", "0", tarifa, Math.Round(multiplicador * tarifa, 0), Convert.ToInt32(tabla_tout.Rows(0)(1).ToString()) * Math.Round(multiplicador * tarifa, 0), medida)
            ElseIf medida = "002" Then
                DgvFactDeta.Rows.Add("069", NombreServicio("069"), "0", Convert.ToInt32(tabla_tout.Rows(0)(0).ToString()), "0", tarifa, Math.Round(multiplicador * tarifa, 0), Convert.ToInt32(tabla_tout.Rows(0)(0).ToString()) * Math.Round(multiplicador * tarifa, 0), medida)
            Else
                MsgBox("Tiene una medida distinta para el cobro traqueo", MsgBoxStyle.Information, "Aviso")
                Return False
                Exit Function
            End If

        End If
        Return True
    End Function

    Function EstadiaMenor15Dias()
        'capturo la tarifa
        Dim SqlTarifa As String = "SELECT Dcon_Valor, Dcon_Moneda, Dcon_Medida FROM ContratosDetalle WHERE Dcon_Codigo='" + txtcodcontrato.Text + "' AND Dcon_ServCod='008'"
        Dim tbtarifa As DataTable = fnc.ListarTablasSQL(SqlTarifa)

        Dim tarifa As Double = 0
        If tbtarifa.Rows.Count = 0 Then
            MsgBox("El servicio estadia no esta agregado al contrato", MsgBoxStyle.Critical, "Aviso")
            Return False
            Exit Function
        End If
        Dim medida As String = tbtarifa.Rows(0)(2).ToString()
        Dim multiplicador As Double = MultiplicadorMonedas(tbtarifa.Rows(0)(1).ToString())  'variable que guarda el multiplicador uf, dolar, peso, etc.
        tarifa = tbtarifa.Rows(0)(0).ToString()
        Dim sql_estadia As String = "SELECT COUNT(*) FROM detadespa INNER JOIN detarece ON drec_codi=ddes_codrece INNER JOIN contrato ON cont_codi=ddes_contcli INNER JOIN " +
              "maeprod ON ddes_codpro=mae_codi INNER JOIN tipoenv ON tenv_codi=mae_tipenv INNER JOIN fichdespa ON fdes_codi=LEFT(ddes_codi,7) INNER JOIN fichrece fr ON fr.frec_codi=LEFT(drec_codi,7) WHERE ddes_contcli='" + txtcodcontrato.Text + "' AND   DATEDIFF(day, CONVERT(Datetime,drec_fecrec,120), " +
              "CONVERT(Datetime,ddes_fecha,120) )<=cont_diagracia AND ddes_fecha>='" + devuelve_fecha(inicio.Value) + "' AND ddes_fecha<='" + devuelve_fecha(termino.Value) + "'  AND fdes_origen='10' AND frec_RecepTunel='1'"

        Dim tabla_estadia As DataTable = fnc.ListarTablasSQL(sql_estadia)
        Dim cantidad_estadia As Integer = 0
        Dim valor_servicio As Integer = 0


        If tabla_estadia.Rows.Count > 0 Then

            If Convert.ToInt32(tabla_estadia.Rows(0)(0).ToString()) > 0 Then
                cantidad_estadia = Convert.ToInt32(tabla_estadia.Rows(0)(0).ToString())
                DgvFactDeta.Rows.Add("008", NombreServicio("008"), cantidad_estadia, "0", "0", tarifa, Math.Round(multiplicador * tarifa, 0), cantidad_estadia * Math.Round(multiplicador * tarifa, 0), medida)
            End If
        End If
        Return True
    End Function

    Function CobroPicking() As Boolean
        'capturo la tarifa
        Dim SqlTarifa As String = "SELECT Dcon_Valor, Dcon_Moneda, Dcon_Medida FROM ContratosDetalle WHERE Dcon_Codigo='" + txtcodcontrato.Text + "' AND Dcon_ServCod='070'"
        Dim tbtarifa As DataTable = fnc.ListarTablasSQL(SqlTarifa)

        Dim tarifa As Double = 0
        If tbtarifa.Rows.Count = 0 Then
            MsgBox("El servicio estadia no esta agregado al contrato", MsgBoxStyle.Critical, "Aviso")
            Return False
            Exit Function
        End If
        Dim medida As String = tbtarifa.Rows(0)(2).ToString()
        Dim multiplicador As Double = MultiplicadorMonedas(tbtarifa.Rows(0)(1).ToString())  'variable que guarda el multiplicador uf, dolar, peso, etc.
        tarifa = tbtarifa.Rows(0)(0).ToString()


        'Seleccionar la cantidad de soportantes que salieron sin cajas
        Dim Picking As String = "SELECT isnull(SUM(ddes_unidades),0) FROM detadespa INNER JOIN fichdespa ON fdes_codi=LEFT(ddes_codi,7) WHERE ddes_pallet=0 AND ddes_contcli='" + txtcodcontrato.Text + "' AND " +
            "ddes_fecha>='" + devuelve_fecha(inicio.Value) + "' AND ddes_fecha<='" + devuelve_fecha(termino.Value) + "' AND fdes_origen<>'90'"

        Dim tablaPicking As DataTable = fnc.ListarTablasSQL(Picking)

        Dim cantidad_Picking As Integer = 0

        If tablaPicking.Rows.Count > 0 Then
            If IsNumeric(tablaPicking.Rows(0)(0).ToString()) Then
                cantidad_Picking = tablaPicking.Rows(0)(0).ToString()
            End If
        End If


        'Valor de Picking
        If cantidad_Picking > 0 Then
            DgvFactDeta.Rows.Add("070", NombreServicio("070"), "0", cantidad_Picking, "0", tarifa, Math.Round(multiplicador * tarifa, 0), cantidad_Picking * Math.Round(multiplicador * tarifa, 0), medida)
        End If


        Return False
    End Function

    Function CobroCargaManual() As Boolean

        Dim sql As String = "SELECT Dcon_Valor, Dcon_Medida, Dcon_Moneda, isnull(SUM(SOPO_SC),0)AS UNID, ROUND(isnull(SUM(PES_SC),0),2) AS PES FROM GvwfactINOUT INNER JOIN ContratosDetalle ON Dcon_Codigo=CONTRATO " +
            "WHERE tipo='002' AND FECHA>='" + devuelve_fecha(inicio.Value) + "' AND FECHA<='" + devuelve_fecha(termino.Value) + "' AND CONTRATO='" + txtcodcontrato.Text + "' AND Dcon_ServCod='011' AND ORIGEN='10' " +
            "AND CAR_DESC='1' GROUP BY Dcon_Valor, Dcon_Medida, Dcon_Moneda "

        Dim tbmanual As DataTable = fnc.ListarTablasSQL(sql)

        If tbmanual.Rows.Count > 0 Then

            Dim medida As String = tbmanual.Rows(0)(1).ToString()
            Dim multiplicador As Double = MultiplicadorMonedas(tbmanual.Rows(0)(2).ToString())  'variable que guarda el multiplicador uf, dolar, peso, etc.
            Dim tarifa As Double = tbmanual.Rows(0)(0).ToString()

            If medida = "001" Then
                DgvFactDeta.Rows.Add("011", NombreServicio("011"), "0", tbmanual.Rows(0)(3).ToString(), "0", tarifa, Math.Round(multiplicador * tarifa, 0), tbmanual.Rows(0)(3).ToString() * Math.Round(multiplicador * tarifa, 0), medida)
            ElseIf medida = "003" Then
                DgvFactDeta.Rows.Add("011", NombreServicio("011"), Math.Round(Convert.ToDouble(tbmanual.Rows(0)(4).ToString()) / 1000, 3), "0", "0", tarifa, Math.Round(multiplicador * tarifa, 0), Math.Round(Convert.ToDouble(tbmanual.Rows(0)(4).ToString()) / 1000, 3) * Math.Round(multiplicador * tarifa, 0), medida)
            End If

        End If
        Return True
    End Function

    Function CobroDescargaManual() As Boolean

        Dim sql As String = "SELECT Dcon_Valor, Dcon_Medida, Dcon_Moneda, isnull(SUM(SOPO_SC),0)AS UNID, ROUND(isnull(SUM(PES_SC),0),2) AS PES FROM GvwfactINOUT INNER JOIN ContratosDetalle ON Dcon_Codigo=CONTRATO " +
            "WHERE tipo='003' AND FECHA>='" + devuelve_fecha(inicio.Value) + "' AND FECHA<='" + devuelve_fecha(termino.Value) + "' AND CONTRATO='" + txtcodcontrato.Text + "' AND Dcon_ServCod='012' AND ORIGEN='25' " +
            "AND CAR_DESC='1' GROUP BY Dcon_Valor, Dcon_Medida, Dcon_Moneda "

        Dim tbmanual As DataTable = fnc.ListarTablasSQL(sql)

        If tbmanual.Rows.Count > 0 Then

            Dim medida As String = tbmanual.Rows(0)(1).ToString()
            Dim multiplicador As Double = MultiplicadorMonedas(tbmanual.Rows(0)(2).ToString())  'variable que guarda el multiplicador uf, dolar, peso, etc.
            Dim tarifa As Double = tbmanual.Rows(0)(0).ToString()

            If medida = "001" Then
                DgvFactDeta.Rows.Add("012", NombreServicio("012"), "0", tbmanual.Rows(0)(3).ToString(), "0", tarifa, Math.Round(multiplicador * tarifa, 0), tbmanual.Rows(0)(3).ToString() * Math.Round(multiplicador * tarifa, 0), medida)
            ElseIf medida = "003" Then
                DgvFactDeta.Rows.Add("012", NombreServicio("012"), Math.Round(Convert.ToDouble(tbmanual.Rows(0)(4).ToString()) / 1000, 3), "0", "0", tarifa, Math.Round(multiplicador * tarifa, 0), Math.Round(Convert.ToDouble(tbmanual.Rows(0)(4).ToString()) / 1000, 3) * Math.Round(multiplicador * tarifa, 0), medida)
            End If

        End If
        Return True
    End Function

    Function CobrosVas()

        Dim sql As String = "SELECT Dvas_ServCod, Serv_Nom, SUM(Dvas_unid) AS Unidades, SUM(dvas_cajas) AS envases, SUM(dvas_kilos) AS Kilos, dcon_valor, ROUND(dcon_valor*mon_valor,0) AS Tarifa, " +
                            "CASE " +
                            "WHEN med_codi='001' OR med_codi='006'  THEN ROUND(dcon_valor*mon_valor*SUM(Dvas_Unid),0) " +
                            "WHEN med_codi='002' THEN ROUND(dcon_valor*mon_valor*SUM(Dvas_Cajas),0) " +
                            "WHEN med_codi='003' THEN ROUND(dcon_valor*mon_valor*(SUM(Dvas_kilos/1000)),0) " +
                            "WHEN med_codi='004' THEN ROUND(((SUM(Dvas_Unid)*24)+SUM(Dvas_Cajas)+(SUM(Dvas_Kilos)/60))*(Dcon_Valor*mon_valor),0) " +
                            "END AS Total, " +
                            "med_codi, mon_codi " +
                            "FROM GvwDetalleVas WHERE Vas_fecha>='" + devuelve_fecha(inicio.Value) + "' AND Vas_fecha<='" + devuelve_fecha(termino.Value) + "' AND Vas_Cont='" + txtcodcontrato.Text + "'  " +
                            "AND Vas_Seccion='1' " +
                            "GROUP BY Dvas_ServCod, Serv_Nom, med_codi, mon_codi, dcon_valor, mon_valor " +
                            "UNION ALL   " +
                            "SELECT Dvas_ServCod, Serv_Nom, SUM(Dvas_Unid) AS Unidades, 0 AS envases, 0 AS Kilos, 0 as tarifa, ROUND(SUM(Dvas_ValTot)/SUM(Dvas_Unid),0) AS Dvas_ValUni, SUM(Dvas_ValTot) AS Tarifa,  " +
                            "med_codi, mon_codi  " +
                            "FROM GvwDetalleVas WHERE Vas_fecha>='" + devuelve_fecha(inicio.Value) + "' AND Vas_fecha<='" + devuelve_fecha(termino.Value) + "' AND Vas_Cont='" + txtcodcontrato.Text + "'  " +
                            "AND Vas_Seccion='2'  " +
                            "GROUP BY Dvas_ServCod, Serv_Nom, med_codi, mon_codi, dcon_valor, mon_valor  " +
                            "UNION ALL   " +
                            "SELECT Dvas_ServCod, Serv_Nom, SUM(Dvas_unid) AS Unidades, SUM(dvas_cajas) AS envases, SUM(dvas_kilos) AS Kilos, dcon_valor, ROUND(dcon_valor*mon_valor,0) AS Tarifa,  " +
                            "CASE  " +
                            "WHEN med_codi='001' OR med_codi='006'  THEN ROUND(dcon_valor*mon_valor*SUM(Dvas_Unid),0)  " +
                            "WHEN med_codi='002' THEN ROUND(dcon_valor*mon_valor*SUM(Dvas_Cajas),0)  " +
                            "WHEN med_codi='003' THEN ROUND(dcon_valor*mon_valor*(SUM(Dvas_kilos/1000)),0)   " +
                            "WHEN med_codi='004' THEN ROUND(((SUM(Dvas_Unid)*24)+SUM(Dvas_Cajas)+(SUM(Dvas_Kilos)/60))*(Dcon_Valor*mon_valor),0)  " +
                            "END AS Total,   " +
                            "med_codi, mon_codi  " +
                            "FROM GvwDetalleVas WHERE Vas_fecha>='" + devuelve_fecha(inicio.Value) + "' AND Vas_fecha<='" + devuelve_fecha(termino.Value) + "' AND Vas_Cont='" + txtcodcontrato.Text + "' " +
                            "AND Vas_Seccion='0' AND (Dvas_ServCod<>'004' AND Dvas_ServCod<>'008' AND Dvas_ServCod<>'011' AND Dvas_ServCod<>'012' AND Dvas_ServCod<>'013')  " +
                            "GROUP BY Dvas_ServCod, Serv_Nom, med_codi, mon_codi, dcon_valor, mon_valor  "

        Dim dt As DataTable = fnc.ListarTablasSQL(sql)

        For i As Integer = 0 To dt.Rows.Count - 1
            DgvFactDeta.Rows.Add(dt.Rows(i)(0).ToString(), dt.Rows(i)(1).ToString(), Convert.ToDouble(dt.Rows(i)(2).ToString()), Convert.ToInt32(dt.Rows(i)(3).ToString()), Convert.ToDouble(dt.Rows(i)(4).ToString()), Convert.ToDouble(dt.Rows(i)(5).ToString()),
                                 Convert.ToInt32(dt.Rows(i)(6).ToString()), Convert.ToInt32(dt.Rows(i)(7).ToString()), dt.Rows(i)(8).ToString())
        Next
    End Function

    Function Custodia() As Boolean

        'pregunto el stock de pallets que existe hasta un dia del inicio de la quincena

        Dim sql As String = "SELECT  CASE WHEN Dvas_entsal=0 THEN SUM(Dvas_Unid) ELSE 0 END, CASE WHEN Dvas_entsal=1 THEN SUM(Dvas_Unid) ELSE 0 END FROM GvwDetalleVas " +
                            "WHERE Dvas_ServCod = 018  AND Vas_fecha<'" + devuelve_fecha(inicio.Value).Replace("/", "-") + "' AND Vas_Cont='" + txtcodcontrato.Text + "' GROUP BY Dvas_entsal"


        Dim dt As DataTable = fnc.ListarTablasSQL(sql)

        Dim ent As Integer = 0
        Dim sal As Integer = 0
        Dim saldoAnterior As Integer = 0

        For i As Integer = 0 To dt.Rows.Count - 1
            ent = ent + dt.Rows(i)(0).ToString()
            sal = sal + dt.Rows(i)(1).ToString()
        Next

        'almaceno saldo de pallets
        saldoAnterior = ent - sal


        DgvCustodia.Rows.Add(devuelve_fecha_Formato2(inicio.Value.AddDays(-1)), 0, 0, saldoAnterior)

        Dim recorriendo As DateTime = inicio.Value

        While (recorriendo <= termino.Value)


            Dim sqldiario As String = "SELECT  CASE WHEN Dvas_entsal=0 THEN SUM(Dvas_Unid) ELSE 0 END, CASE WHEN Dvas_entsal=1 THEN SUM(Dvas_Unid) ELSE 0 END FROM GvwDetalleVas " +
                            "WHERE Dvas_ServCod = 018  AND Vas_fecha='" + devuelve_fecha(recorriendo).Replace("/", "-") + "' AND Vas_Cont='" + txtcodcontrato.Text + "' GROUP BY Dvas_entsal"

            dt = fnc.ListarTablasSQL(sqldiario)
            ent = 0
            sal = 0

            For i As Integer = 0 To dt.Rows.Count - 1
                ent = ent + dt.Rows(i)(0).ToString()
                sal = sal + dt.Rows(i)(1).ToString()
            Next

            'Almaceno saldo de pallets

            DgvCustodia.Rows.Add(devuelve_fecha_Formato2(recorriendo), ent, sal, (saldoAnterior + ent) - sal)
            saldoAnterior = (saldoAnterior + ent) - sal
            recorriendo = recorriendo.AddDays(1)

        End While


        Dim suma_administracion = 0

        For i As Integer = 0 To DgvArriendo.Rows.Count - 1
            suma_administracion = suma_administracion + Convert.ToInt32(DgvCustodia.Rows(i).Cells(3).Value.ToString())
        Next


        'capturo la tarifa
        Dim SqlTarifa As String = "SELECT Dcon_Valor, Dcon_Moneda, Dcon_Medida FROM ContratosDetalle WHERE Dcon_Codigo='" + txtcodcontrato.Text + "' AND Dcon_ServCod='018'"
        Dim tbtarifa As DataTable = fnc.ListarTablasSQL(SqlTarifa)

        Dim tarifa As Double = 0
        If tbtarifa.Rows.Count = 0 Then
            MsgBox("El servicio Administracion de pallets no esta agregado al contrato", MsgBoxStyle.Critical, "Aviso")
            Return False
            Exit Function
        End If
        Dim medida As String = tbtarifa.Rows(0)(2).ToString()
        Dim multiplicador As Double = MultiplicadorMonedas(tbtarifa.Rows(0)(1).ToString())  'variable que guarda el multiplicador uf, dolar, peso, etc.
        tarifa = tbtarifa.Rows(0)(0).ToString()

        DgvFactDeta.Rows.Add("018", NombreServicio("018"), suma_administracion, "0", "0", tarifa, Math.Round(multiplicador * tarifa, 0), suma_administracion * Math.Round(multiplicador * tarifa, 0), "001")

        Return True
    End Function




    Private Sub Frm_Facturacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim sql As String = "SELECT mon_codi, mon_descr, mon_valor FROM monedas WHERE mon_est='0'"
        DgvMonedas.DataSource = fnc.ListarTablasSQL(sql)

        inicio.Value = fnc.DevuelveFechaServidor()
        termino.Value = inicio.Value

    End Sub

    Private Sub Frm_Facturacion_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        f_addfacturacion = False
    End Sub

    Private Function NombreServicio(ByVal codigo As String) As String
        Dim sql As String = "SELECT Serv_Nom FROM FacServicios WHERE Serv_Cod='" + codigo + "'"
        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)
        If tabla.Rows.Count > 0 Then
            Return tabla.Rows(0)(0).ToString()
        Else
            Return ""
        End If
    End Function

    Function MultiplicadorMonedas(ByVal codigo As String) As Double
        MultiplicadorMonedas = 1
        For i As Integer = 0 To DgvMonedas.Rows.Count - 1
            If codigo = DgvMonedas.Rows(0).Cells(0).Value.ToString() Then
                MultiplicadorMonedas = DgvMonedas.Rows(0).Cells(2).Value.ToString()
                Exit For
            End If
        Next
        Return MultiplicadorMonedas
    End Function

    Sub SumaTotales()
        Dim neto As Integer = 0
        Dim iva As Double = 0

        For i As Integer = 0 To DgvFactDeta.Rows.Count - 1
            neto = neto + Convert.ToInt32(Fix(DgvFactDeta.Rows(i).Cells("VALORFINAL").Value.ToString()))
        Next

        iva = Math.Round((neto / 100) * retorna_iva(), 0)
        Dim t As Integer = iva + neto

        txtneto.Text = neto.ToString()
        txtiva.Text = iva.ToString()
        txttotal.Text = t.ToString()

    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        While (DgvDiferencial.Rows.Count > 0)
            DgvDiferencial.Rows.RemoveAt(0)
        End While

        While (DgvKardex.Rows.Count > 0)
            DgvKardex.Rows.RemoveAt(0)
        End While

        While (DgvArriendo.Rows.Count > 0)
            DgvArriendo.Rows.RemoveAt(0)
        End While

        While (DgvFactDeta.Rows.Count > 0)
            DgvFactDeta.Rows.RemoveAt(0)
        End While

        While (DgvCustodia.Rows.Count > 0)
            DgvCustodia.Rows.RemoveAt(0)
        End While

    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click

        Dim dt As DataTable = fnc.ListarTablasSQL("SELECT isnull(MAX(fac_codi),0)+1 FROM fichfact")

        'Si rescata bien el codigo continua....
        If dt.Rows.Count = 0 Then
            MsgBox("Ocurrio un error al rescatar el código de la facturación", MsgBoxStyle.Critical, "Aviso")
            Exit Sub
        End If

        Dim codigo As String = dt.Rows(0)(0).ToString()


        Dim sql As String = "INSERT INTO fichfact(fac_codi, fac_clirut, fac_contcli, fac_feci, fac_fect, fac_neto, fac_iva, fac_total, fac_enca)" +
            "VALUES('" + codigo + "','" + txtclirut.Text + "','" + txtcodcontrato.Text + "','" + devuelve_fecha_Formato2(inicio.Value) + "'," +
            "'" + devuelve_fecha_Formato2(termino.Value) + "','" + txtneto.Text + "','" + txtiva.Text + "','" + txttotal.Text + "','" + Frm_Principal.InfoUsuario.Text + "')"


        Dim sql_detalle As String = "INSERT INTO fichfactdeta(dfac_codi, dfac_codserv "


    End Sub

    Private Sub DgvKardex_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvKardex.CellDoubleClick
        If e.RowIndex > -1 Then

            Dim f As New Frm_Detallemov
            f.contrato = txtcodcontrato.Text
            f.fecha = DgvKardex.Rows(e.RowIndex).Cells(0).Value.ToString()
            f.ShowDialog()

        End If
    End Sub

    Private Sub txtclirut_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtclirut.KeyPress
        If e.KeyChar = ChrW(13) Then

        End If
    End Sub
End Class
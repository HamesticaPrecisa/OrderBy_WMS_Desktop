Public Class Frm_UnirPedidos
    Dim fnc As New Funciones
    Dim con As New Conexion
    Dim ped As String = ""
    Dim pedido1 As String = ""
    Dim pedido2 As String = ""
    Dim pedido3 As String = ""
    Dim pedido4 As String = ""
    Dim pedido5 As String = ""

    Private Sub Frm_UnirPedidos_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        actu()

        Dim sqlCombo As String = "SELECT  Orden " +
                           "FROM pedidos_ficha, clientes " +
                           "WHERE cli_rut=cliente AND terminado <>'3' AND Ped_estpred<>'3' AND codvig='0' AND Orden not in(SELECT fpre_nped FROM fichpred) AND Dateadd(day,2,Convert(date,fecha,103))>Convert(date,GETDATE(),103) ORDER BY orden DESC"



        ComboBox1.DataSource = fnc.ListarTablasSQL(sqlCombo)
        ComboBox1.DisplayMember = "Orden"
        ComboBox1.ValueMember = "Orden"
    End Sub
    Private Sub actu()

        Dim sql2 As String = "select ordenconjunta as PedidosUnidos from Pedidos_ficha where ordenconjunta is not null  AND terminado <>'3' AND Ped_estpred<>'3' AND codvig='0'  AND Dateadd(day,2,Convert(date,fecha,103))>Convert(date,GETDATE(),103) group by  ordenconjunta ORDER BY ordenconjunta DESC  "
       


        Dim tabla As DataTable = fnc.ListarTablasSQL(sql2)
        DgvResultado.DataSource = tabla


    End Sub
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
      


        If ComboBox1.Text = pedido1 Or ComboBox1.Text = pedido2 Or ComboBox1.Text = pedido3 Or ComboBox1.Text = pedido4 Or ComboBox1.Text = pedido5 Then

            MsgBox("Este pedido ya fue seleccionado", MsgBoxStyle.Information, "Aviso")

        Else




            If txtcodpednew.Text = "" Then

                txtcodpednew.Text = ComboBox1.Text
                ped = ComboBox1.Text
                pedido1 = ComboBox1.Text
            Else
                'ped = ComboBox1.Text
                'txtcodpednew.Text = txtcodpednew.Text + "-" + ComboBox1.Text


                If pedido2 = "" Then
                    pedido2 = ComboBox1.Text
                    txtcodpednew.Text = txtcodpednew.Text + "-" + ComboBox1.Text
                Else

                    If pedido3 = "" Then
                        pedido3 = ComboBox1.Text
                        txtcodpednew.Text = txtcodpednew.Text + "-" + ComboBox1.Text
                    Else

                        If pedido4 = "" Then
                            pedido4 = ComboBox1.Text
                            txtcodpednew.Text = txtcodpednew.Text + "-" + ComboBox1.Text

                        Else

                            If pedido5 = "" Then
                                pedido5 = ComboBox1.Text
                                txtcodpednew.Text = txtcodpednew.Text + "-" + ComboBox1.Text


                            Else

                                MsgBox("El Numero Maximo De Pedidos Es 5", MsgBoxStyle.Information, "Aviso")

                            End If
                        End If
                    End If
                End If



            End If

        End If

    End Sub

    Private Sub BtnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles BtnGuardar.Click
        If pedido1 = "" Then
        Else
            Dim qry As String
            qry = "UPDATE Pedidos_ficha SET ordenconjunta='" + txtcodpednew.Text + "'   WHERE orden='" + pedido1 + "' "
          
            fnc.MovimientoSQL(qry)


        End If
        If pedido2 = "" Then
        Else
            Dim qry As String
            qry = "UPDATE Pedidos_ficha SET ordenconjunta='" + txtcodpednew.Text + "'   WHERE orden='" + pedido2 + "' "
            fnc.MovimientoSQL(qry)


        End If
        If pedido3 = "" Then
        Else
            Dim qry As String
            qry = "UPDATE Pedidos_ficha SET ordenconjunta='" + txtcodpednew.Text + "'   WHERE orden='" + pedido3 + "' "
            fnc.MovimientoSQL(qry)


        End If

        If pedido4 = "" Then
        Else
            Dim qry As String
            qry = "UPDATE Pedidos_ficha SET ordenconjunta='" + txtcodpednew.Text + "'   WHERE orden='" + pedido4 + "' " '"
            fnc.MovimientoSQL(qry)


        End If
        If pedido5 = "" Then
        Else
            Dim qry As String
            qry = "UPDATE Pedidos_ficha SET ordenconjunta='" + txtcodpednew.Text + "'   WHERE orden='" + pedido5 + "' "
            fnc.MovimientoSQL(qry)


        End If
        If pedido1 = "" Then
        Else

            MsgBox("Grabación exitosa", MsgBoxStyle.Information, "Aviso")
        End If
        actu()

    End Sub

    Private Sub DgvResultado_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvResultado.CellDoubleClick
        If MsgBox("Seguro de eliminar esta union de pedidos", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Aviso") = vbYes Then

            Dim union As String = DgvResultado.Rows(e.RowIndex).Cells(0).Value.ToString()
            Dim qry As String
            qry = "UPDATE Pedidos_ficha SET ordenconjunta=NULL   WHERE ordenconjunta='" + union + "' "
            fnc.MovimientoSQL(qry)
            MsgBox("Union de pedidos eliminada", MsgBoxStyle.Information, "Aviso")

            fnc.MovimientoSQL("INSERT INTO LOG_DESUNEPEDIDOS (LEM_ORDENCONJ, LEM_FECHA, LEM_HORA, LEM_USU, LEM_PC, LEM_TIPO)" +
                              "VALUES('" + union + "','" + devuelve_fecha_Formato2(fnc.DevuelveFechaServidor()) + "','" + DevuelveHora() + "'," +
                              "'" + Frm_Principal.InfoUsuario.Text + "','" + My.Computer.Name.ToString() + "','SI')")
            Dim SQLMOV As String = ("INSERT INTO LOG_DESUNEPEDIDOS (LEM_ORDENCONJ, LEM_FECHA, LEM_HORA, LEM_USU, LEM_PC, LEM_TIPO)" +
                              "VALUES('" + union + "','" + devuelve_fecha_Formato2(fnc.DevuelveFechaServidor()) + "','" + DevuelveHora() + "'," +
                              "'" + Frm_Principal.InfoUsuario.Text + "','" + My.Computer.Name.ToString() + "','SI')")

            actu()
        Else


        End If
    End Sub
End Class
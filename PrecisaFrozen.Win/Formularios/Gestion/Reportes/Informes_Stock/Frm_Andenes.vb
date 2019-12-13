Public Class Frm_Andenes
    Dim fnc As New Funciones
    Private Sub btnExcel_Click(sender As System.Object, e As System.EventArgs) Handles btnExcel.Click
        Call GridAExcel(DgvResultado)
    End Sub

    Private Sub BtnAyuda_Click(sender As System.Object, e As System.EventArgs) Handles BtnAyuda.Click
        Dim f As New Frm_CheckListAyuda
        f.ShowDialog(Frm_Principal)
        If Frm_Principal.buscavalor.ToString() <> "" Then
            RescataCheckList(Frm_Principal.buscavalor.ToString())
        End If
    End Sub
    Sub RescataCheckList(ByVal folio As String)
        DgvResultado.Rows.Clear()

        Dim sql As String = "SELECT Cl_RutCli, cli_nomb, Cl_chorut, cho_nombre, Cl_ChoEmp, Cl_Ting, Cl_Cont, Cl_Mov, Cl_DesTemp, " +
            "cl_pate, Cl_Ram, cl_obs, cl_ori, isnull(Cl_Lleg,0) AS Cl_Lleg, isnull(Cl_ing,0) AS Cl_ing, isnull(Cl_Des,0) AS Cl_Des " +
            "FROM zchecklist, clientes, choferes WHERE cho_rut=cl_chorut " +
            "AND cli_rut=cl_rutcli AND cl_fol='" + folio + "'"

        Dim tabla2 As DataTable = fnc.ListarTablasSQL(sql)

        If tabla2.Rows.Count > 0 Then
            Txtfolio.Text = folio

            ' Me.DgvResultado.DataSource = fnc.ListarTablasSQL("Select Folio ,Cliente ,Cli_nomb as Nombre,Anden, Tip_mov as Movimiento1,fec_reg as Apertura,usr_reg as UsuarioAper, Mov_cie as Movimiento2, fec_cie as Cierre, usr_reg2 as UsuarioCierr,DIFF AS Diferencia from Vg_Andenes_fin_fin where folio='" + folio + "'")
            Dim sql2 As String = "Select Folio ,Cliente ,Cli_nomb as Nombre,Anden, Tip_mov as Movimiento1,fec_reg as Apertura,usr_reg as UsuarioAper, Mov_cie as Movimiento2, fec_cie as Cierre, usr_reg2 as UsuarioCierr,DIFF AS Diferencia from Vg_Andenes_fin_fin2 where folio='" + folio + "'"

            Dim tabla As DataTable = fnc.ListarTablasSQL(sql2)

            'Me.DgvResultado.DataSource = fnc.ListarTablasSQL("")

       
            For i As Integer = 0 To tabla.Rows.Count - 1


                If Not tabla.Rows(i)(10).ToString() = "" Then
                    Dim vv As String = tabla.Rows(i)(10).ToString()
                    Dim parte1 As String = "00"
                    Dim parte2 As String = "00"


                    Dim valorfinal As String = ""

                    If Convert.ToInt32(vv) < 60 Then
                        valorfinal = "00:" + vv
                        DgvResultado.Rows.Add()
                        DgvResultado.Rows(i).Cells(0).Value = tabla.Rows(i)(0).ToString()
                        DgvResultado.Rows(i).Cells(1).Value = tabla.Rows(i)(1).ToString()
                        DgvResultado.Rows(i).Cells(2).Value = tabla.Rows(i)(2).ToString()
                        DgvResultado.Rows(i).Cells(3).Value = tabla.Rows(i)(3).ToString()
                        DgvResultado.Rows(i).Cells(4).Value = tabla.Rows(i)(4).ToString()
                        DgvResultado.Rows(i).Cells(5).Value = tabla.Rows(i)(5).ToString()
                        DgvResultado.Rows(i).Cells(6).Value = tabla.Rows(i)(6).ToString()
                        DgvResultado.Rows(i).Cells(7).Value = tabla.Rows(i)(7).ToString()
                        DgvResultado.Rows(i).Cells(8).Value = tabla.Rows(i)(8).ToString()
                        DgvResultado.Rows(i).Cells(9).Value = tabla.Rows(i)(9).ToString()
                        ' DgvResultado.Rows(i).Cells(10).Value = tabla.Rows(i)(10).ToString()

                        DgvResultado.Rows(i).Cells(10).Value = valorfinal 'no funca



                    End If
                    If Convert.ToInt32(vv) = 60 Or Convert.ToInt32(vv) = 120 Or Convert.ToInt32(vv) = 180 Or Convert.ToInt32(vv) = 240 Then

                        Dim cal As Integer = Convert.ToInt32(vv) / 60
                        valorfinal = cal.ToString() + ":00"
                        DgvResultado.Rows.Add()
                        DgvResultado.Rows(i).Cells(0).Value = tabla.Rows(i)(0).ToString()
                        DgvResultado.Rows(i).Cells(1).Value = tabla.Rows(i)(1).ToString()
                        DgvResultado.Rows(i).Cells(2).Value = tabla.Rows(i)(2).ToString()
                        DgvResultado.Rows(i).Cells(3).Value = tabla.Rows(i)(3).ToString()
                        DgvResultado.Rows(i).Cells(4).Value = tabla.Rows(i)(4).ToString()
                        DgvResultado.Rows(i).Cells(5).Value = tabla.Rows(i)(5).ToString()
                        DgvResultado.Rows(i).Cells(6).Value = tabla.Rows(i)(6).ToString()
                        DgvResultado.Rows(i).Cells(7).Value = tabla.Rows(i)(7).ToString()
                        DgvResultado.Rows(i).Cells(8).Value = tabla.Rows(i)(8).ToString()
                        DgvResultado.Rows(i).Cells(9).Value = tabla.Rows(i)(9).ToString()
                        ' DgvResultado.Rows(i).Cells(10).Value = tabla.Rows(i)(10).ToString()

                        DgvResultado.Rows(i).Cells(10).Value = valorfinal 'no funca

                    End If

                    If Convert.ToInt32(vv) > 60 Then
                        Dim cal As Integer = Convert.ToInt32(vv) \ 60
                        Dim calmod As Integer = Convert.ToInt32(vv) Mod 60
                        valorfinal = cal.ToString() + ":" + calmod.ToString()
                        DgvResultado.Rows.Add()
                        DgvResultado.Rows(i).Cells(0).Value = tabla.Rows(i)(0).ToString()
                        DgvResultado.Rows(i).Cells(1).Value = tabla.Rows(i)(1).ToString()
                        DgvResultado.Rows(i).Cells(2).Value = tabla.Rows(i)(2).ToString()
                        DgvResultado.Rows(i).Cells(3).Value = tabla.Rows(i)(3).ToString()
                        DgvResultado.Rows(i).Cells(4).Value = tabla.Rows(i)(4).ToString()
                        DgvResultado.Rows(i).Cells(5).Value = tabla.Rows(i)(5).ToString()
                        DgvResultado.Rows(i).Cells(6).Value = tabla.Rows(i)(6).ToString()
                        DgvResultado.Rows(i).Cells(7).Value = tabla.Rows(i)(7).ToString()
                        DgvResultado.Rows(i).Cells(8).Value = tabla.Rows(i)(8).ToString()
                        DgvResultado.Rows(i).Cells(9).Value = tabla.Rows(i)(9).ToString()
                        ' DgvResultado.Rows(i).Cells(10).Value = tabla.Rows(i)(10).ToString()

                        DgvResultado.Rows(i).Cells(10).Value = valorfinal 'no funca
                    End If


                Else
                    DgvResultado.Rows.Add()
                    DgvResultado.Rows(i).Cells(0).Value = tabla.Rows(i)(0).ToString()
                    DgvResultado.Rows(i).Cells(1).Value = tabla.Rows(i)(1).ToString()
                    DgvResultado.Rows(i).Cells(2).Value = tabla.Rows(i)(2).ToString()
                    DgvResultado.Rows(i).Cells(3).Value = tabla.Rows(i)(3).ToString()
                    DgvResultado.Rows(i).Cells(4).Value = tabla.Rows(i)(4).ToString()
                    DgvResultado.Rows(i).Cells(5).Value = tabla.Rows(i)(5).ToString()
                    DgvResultado.Rows(i).Cells(6).Value = tabla.Rows(i)(6).ToString()
                    DgvResultado.Rows(i).Cells(7).Value = tabla.Rows(i)(7).ToString()
                    DgvResultado.Rows(i).Cells(8).Value = tabla.Rows(i)(8).ToString()
                    DgvResultado.Rows(i).Cells(9).Value = tabla.Rows(i)(9).ToString()
                End If
                'DgvResultado.Rows.Add()
            Next
        End If


    End Sub

    Private Sub Frm_Andenes_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Frm_Principal.buscavalor = ""

        Dim sql2 As String = "Select Folio ,Cliente ,Cli_nomb as Nombre,Anden, Tip_mov as Movimiento1,fec_reg as Apertura,usr_reg as UsuarioAper, Mov_cie as Movimiento2, fec_cie as Cierre, usr_reg2 as UsuarioCierr,DIFF AS Diferencia from Vg_Andenes_fin_fin2 order by folio desc"

        Dim tabla As DataTable = fnc.ListarTablasSQL(sql2)

        '    Me.DgvResultado.DataSource = fnc.ListarTablasSQL("Select Folio ,Cliente ,Cli_nomb as Nombre,Anden, Tip_mov as Movimiento1,fec_reg as Apertura,usr_reg as UsuarioAper, Mov_cie as Movimiento2, fec_cie as Cierre, usr_reg2 as UsuarioCierr,DIFF AS Diferencia from Vg_Andenes_fin_fin2")

        Dim column11 As New DataGridViewTextBoxColumn
        Dim column0 As New DataGridViewTextBoxColumn
        Dim column1 As New DataGridViewTextBoxColumn
        Dim column2 As New DataGridViewTextBoxColumn
        Dim column3 As New DataGridViewTextBoxColumn
        Dim column4 As New DataGridViewTextBoxColumn
        Dim column5 As New DataGridViewTextBoxColumn
        Dim column6 As New DataGridViewTextBoxColumn
        Dim column7 As New DataGridViewTextBoxColumn
        Dim column8 As New DataGridViewTextBoxColumn
        Dim column9 As New DataGridViewTextBoxColumn
        Dim column10 As New DataGridViewTextBoxColumn

        With column0
            .Name = "Folio"
            .HeaderText = "Folio"
        End With
        With column1
            .Name = "Cliente"
            .HeaderText = "Cliente"
        End With
        With column2
            .Name = "Nombre"
            .HeaderText = "Nombre"
        End With
        With column3
            .Name = "Anden"
            .HeaderText = "Anden"
        End With
        With column4
            .Name = "Movimiento1"
            .HeaderText = "Movimiento1"
        End With
        With column5
            .Name = "Apertura"
            .HeaderText = "Apertura"
        End With
        With column6
            .Name = "UsuarioAper"
            .HeaderText = "UsuarioAper"
        End With
        With column7
            .Name = "Movimiento2"
            .HeaderText = "Movimiento2"
        End With
        With column8
            .Name = "Cierre"
            .HeaderText = "Cierre"
        End With
        With column9
            .Name = "UsuarioCierr"
            .HeaderText = "UsuarioCierr"
        End With
        With column10
            .Name = "DIF"
            .HeaderText = "DIF"
        End With

        ' Añadimos la columna la cual aparecerá en la primera posición
        DgvResultado.Columns.Insert(0, column0)
        DgvResultado.Columns.Insert(1, column1)
        DgvResultado.Columns.Insert(2, column2)
        DgvResultado.Columns.Insert(3, column3)
        DgvResultado.Columns.Insert(4, column4)
        DgvResultado.Columns.Insert(5, column5)
        DgvResultado.Columns.Insert(6, column6)
        DgvResultado.Columns.Insert(7, column7)
        DgvResultado.Columns.Insert(8, column8)
        DgvResultado.Columns.Insert(9, column9)
        DgvResultado.Columns.Insert(10, column10)
        For i As Integer = 0 To tabla.Rows.Count - 1


            If Not tabla.Rows(i)(10).ToString() = "" Then
                Dim vv As String = tabla.Rows(i)(10).ToString()
                Dim parte1 As String = "00"
                Dim parte2 As String = "00"


                Dim valorfinal As String = ""

                If Convert.ToInt32(vv) < 60 Then
                    valorfinal = "00:" + vv
                    DgvResultado.Rows.Add()
                    DgvResultado.Rows(i).Cells(0).Value = tabla.Rows(i)(0).ToString()
                    DgvResultado.Rows(i).Cells(1).Value = tabla.Rows(i)(1).ToString()
                    DgvResultado.Rows(i).Cells(2).Value = tabla.Rows(i)(2).ToString()
                    DgvResultado.Rows(i).Cells(3).Value = tabla.Rows(i)(3).ToString()
                    DgvResultado.Rows(i).Cells(4).Value = tabla.Rows(i)(4).ToString()
                    DgvResultado.Rows(i).Cells(5).Value = tabla.Rows(i)(5).ToString()
                    DgvResultado.Rows(i).Cells(6).Value = tabla.Rows(i)(6).ToString()
                    DgvResultado.Rows(i).Cells(7).Value = tabla.Rows(i)(7).ToString()
                    DgvResultado.Rows(i).Cells(8).Value = tabla.Rows(i)(8).ToString()
                    DgvResultado.Rows(i).Cells(9).Value = tabla.Rows(i)(9).ToString()
                    ' DgvResultado.Rows(i).Cells(10).Value = tabla.Rows(i)(10).ToString()

                    DgvResultado.Rows(i).Cells(10).Value = valorfinal 'no funca



                End If
                If Convert.ToInt32(vv) = 60 Or Convert.ToInt32(vv) = 120 Or Convert.ToInt32(vv) = 180 Or Convert.ToInt32(vv) = 240 Then

                    Dim cal As Integer = Convert.ToInt32(vv) / 60
                    valorfinal = cal.ToString() + ":00"
                    DgvResultado.Rows.Add()
                    DgvResultado.Rows(i).Cells(0).Value = tabla.Rows(i)(0).ToString()
                    DgvResultado.Rows(i).Cells(1).Value = tabla.Rows(i)(1).ToString()
                    DgvResultado.Rows(i).Cells(2).Value = tabla.Rows(i)(2).ToString()
                    DgvResultado.Rows(i).Cells(3).Value = tabla.Rows(i)(3).ToString()
                    DgvResultado.Rows(i).Cells(4).Value = tabla.Rows(i)(4).ToString()
                    DgvResultado.Rows(i).Cells(5).Value = tabla.Rows(i)(5).ToString()
                    DgvResultado.Rows(i).Cells(6).Value = tabla.Rows(i)(6).ToString()
                    DgvResultado.Rows(i).Cells(7).Value = tabla.Rows(i)(7).ToString()
                    DgvResultado.Rows(i).Cells(8).Value = tabla.Rows(i)(8).ToString()
                    DgvResultado.Rows(i).Cells(9).Value = tabla.Rows(i)(9).ToString()
                    ' DgvResultado.Rows(i).Cells(10).Value = tabla.Rows(i)(10).ToString()

                    DgvResultado.Rows(i).Cells(10).Value = valorfinal 'no funca

                End If

                If Convert.ToInt32(vv) > 60 Then
                    Dim cal As Integer = Convert.ToInt32(vv) \ 60
                    Dim calmod As Integer = Convert.ToInt32(vv) Mod 60
                    valorfinal = cal.ToString() + ":" + calmod.ToString()
                    DgvResultado.Rows.Add()
                    DgvResultado.Rows(i).Cells(0).Value = tabla.Rows(i)(0).ToString()
                    DgvResultado.Rows(i).Cells(1).Value = tabla.Rows(i)(1).ToString()
                    DgvResultado.Rows(i).Cells(2).Value = tabla.Rows(i)(2).ToString()
                    DgvResultado.Rows(i).Cells(3).Value = tabla.Rows(i)(3).ToString()
                    DgvResultado.Rows(i).Cells(4).Value = tabla.Rows(i)(4).ToString()
                    DgvResultado.Rows(i).Cells(5).Value = tabla.Rows(i)(5).ToString()
                    DgvResultado.Rows(i).Cells(6).Value = tabla.Rows(i)(6).ToString()
                    DgvResultado.Rows(i).Cells(7).Value = tabla.Rows(i)(7).ToString()
                    DgvResultado.Rows(i).Cells(8).Value = tabla.Rows(i)(8).ToString()
                    DgvResultado.Rows(i).Cells(9).Value = tabla.Rows(i)(9).ToString()
                    ' DgvResultado.Rows(i).Cells(10).Value = tabla.Rows(i)(10).ToString()

                    DgvResultado.Rows(i).Cells(10).Value = valorfinal 'no funca
                End If


            Else
                DgvResultado.Rows.Add()
                DgvResultado.Rows(i).Cells(0).Value = tabla.Rows(i)(0).ToString()
                DgvResultado.Rows(i).Cells(1).Value = tabla.Rows(i)(1).ToString()
                DgvResultado.Rows(i).Cells(2).Value = tabla.Rows(i)(2).ToString()
                DgvResultado.Rows(i).Cells(3).Value = tabla.Rows(i)(3).ToString()
                DgvResultado.Rows(i).Cells(4).Value = tabla.Rows(i)(4).ToString()
                DgvResultado.Rows(i).Cells(5).Value = tabla.Rows(i)(5).ToString()
                DgvResultado.Rows(i).Cells(6).Value = tabla.Rows(i)(6).ToString()
                DgvResultado.Rows(i).Cells(7).Value = tabla.Rows(i)(7).ToString()
                DgvResultado.Rows(i).Cells(8).Value = tabla.Rows(i)(8).ToString()
                DgvResultado.Rows(i).Cells(9).Value = tabla.Rows(i)(9).ToString()
            End If
            'DgvResultado.Rows.Add()
        Next



    End Sub

    Private Sub btn_nuevo_Click(sender As System.Object, e As System.EventArgs) Handles btn_nuevo.Click
        Txtfolio.Text = ""
        'Me.DgvResultado.DataSource = fnc.ListarTablasSQL("Select Folio ,Cliente ,Cli_nomb as Nombre,Anden, Tip_mov as Movimiento1,fec_reg as Apertura,usr_reg as UsuarioAper, Mov_cie as Movimiento2, fec_cie as Cierre, usr_reg2 as UsuarioCierr,DIFF AS Diferencia from Vg_Andenes_fin_fin")
        Dim sql2 As String = "Select Folio ,Cliente ,Cli_nomb as Nombre,Anden, Tip_mov as Movimiento1,fec_reg as Apertura,usr_reg as UsuarioAper, Mov_cie as Movimiento2, fec_cie as Cierre, usr_reg2 as UsuarioCierr,DIFF AS Diferencia from Vg_Andenes_fin_fin2"

        Dim tabla As DataTable = fnc.ListarTablasSQL(sql2)

        '    Me.DgvResultado.DataSource = fnc.ListarTablasSQL("Select Folio ,Cliente ,Cli_nomb as Nombre,Anden, Tip_mov as Mo   vimiento1,fec_reg as Apertura,usr_reg as UsuarioAper, Mov_cie as Movimiento2, fec_cie as Cierre, usr_reg2 as UsuarioCierr,DIFF AS Diferencia from Vg_Andenes_fin_fin2")

       
        For i As Integer = 0 To tabla.Rows.Count - 1


            If Not tabla.Rows(i)(10).ToString() = "" Then
                Dim vv As String = tabla.Rows(i)(10).ToString()
                Dim parte1 As String = "00"
                Dim parte2 As String = "00"


                Dim valorfinal As String = ""

                If Convert.ToInt32(vv) < 60 Then
                    valorfinal = "00:" + vv
                    DgvResultado.Rows.Add()
                    DgvResultado.Rows(i).Cells(0).Value = tabla.Rows(i)(0).ToString()
                    DgvResultado.Rows(i).Cells(1).Value = tabla.Rows(i)(1).ToString()
                    DgvResultado.Rows(i).Cells(2).Value = tabla.Rows(i)(2).ToString()
                    DgvResultado.Rows(i).Cells(3).Value = tabla.Rows(i)(3).ToString()
                    DgvResultado.Rows(i).Cells(4).Value = tabla.Rows(i)(4).ToString()
                    DgvResultado.Rows(i).Cells(5).Value = tabla.Rows(i)(5).ToString()
                    DgvResultado.Rows(i).Cells(6).Value = tabla.Rows(i)(6).ToString()
                    DgvResultado.Rows(i).Cells(7).Value = tabla.Rows(i)(7).ToString()
                    DgvResultado.Rows(i).Cells(8).Value = tabla.Rows(i)(8).ToString()
                    DgvResultado.Rows(i).Cells(9).Value = tabla.Rows(i)(9).ToString()
                    ' DgvResultado.Rows(i).Cells(10).Value = tabla.Rows(i)(10).ToString()

                    DgvResultado.Rows(i).Cells(10).Value = valorfinal 'no funca



                End If
                If Convert.ToInt32(vv) = 60 Or Convert.ToInt32(vv) = 120 Or Convert.ToInt32(vv) = 180 Or Convert.ToInt32(vv) = 240 Then

                    Dim cal As Integer = Convert.ToInt32(vv) / 60
                    valorfinal = cal.ToString() + ":00"
                    DgvResultado.Rows.Add()
                    DgvResultado.Rows(i).Cells(0).Value = tabla.Rows(i)(0).ToString()
                    DgvResultado.Rows(i).Cells(1).Value = tabla.Rows(i)(1).ToString()
                    DgvResultado.Rows(i).Cells(2).Value = tabla.Rows(i)(2).ToString()
                    DgvResultado.Rows(i).Cells(3).Value = tabla.Rows(i)(3).ToString()
                    DgvResultado.Rows(i).Cells(4).Value = tabla.Rows(i)(4).ToString()
                    DgvResultado.Rows(i).Cells(5).Value = tabla.Rows(i)(5).ToString()
                    DgvResultado.Rows(i).Cells(6).Value = tabla.Rows(i)(6).ToString()
                    DgvResultado.Rows(i).Cells(7).Value = tabla.Rows(i)(7).ToString()
                    DgvResultado.Rows(i).Cells(8).Value = tabla.Rows(i)(8).ToString()
                    DgvResultado.Rows(i).Cells(9).Value = tabla.Rows(i)(9).ToString()
                    ' DgvResultado.Rows(i).Cells(10).Value = tabla.Rows(i)(10).ToString()

                    DgvResultado.Rows(i).Cells(10).Value = valorfinal 'no funca

                End If

                If Convert.ToInt32(vv) > 60 Then
                    Dim cal As Integer = Convert.ToInt32(vv) \ 60
                    Dim calmod As Integer = Convert.ToInt32(vv) Mod 60
                    valorfinal = cal.ToString() + ":" + calmod.ToString()
                    DgvResultado.Rows.Add()
                    DgvResultado.Rows(i).Cells(0).Value = tabla.Rows(i)(0).ToString()
                    DgvResultado.Rows(i).Cells(1).Value = tabla.Rows(i)(1).ToString()
                    DgvResultado.Rows(i).Cells(2).Value = tabla.Rows(i)(2).ToString()
                    DgvResultado.Rows(i).Cells(3).Value = tabla.Rows(i)(3).ToString()
                    DgvResultado.Rows(i).Cells(4).Value = tabla.Rows(i)(4).ToString()
                    DgvResultado.Rows(i).Cells(5).Value = tabla.Rows(i)(5).ToString()
                    DgvResultado.Rows(i).Cells(6).Value = tabla.Rows(i)(6).ToString()
                    DgvResultado.Rows(i).Cells(7).Value = tabla.Rows(i)(7).ToString()
                    DgvResultado.Rows(i).Cells(8).Value = tabla.Rows(i)(8).ToString()
                    DgvResultado.Rows(i).Cells(9).Value = tabla.Rows(i)(9).ToString()
                    ' DgvResultado.Rows(i).Cells(10).Value = tabla.Rows(i)(10).ToString()

                    DgvResultado.Rows(i).Cells(10).Value = valorfinal 'no funca
                End If


            Else
                DgvResultado.Rows.Add()
                DgvResultado.Rows(i).Cells(0).Value = tabla.Rows(i)(0).ToString()
                DgvResultado.Rows(i).Cells(1).Value = tabla.Rows(i)(1).ToString()
                DgvResultado.Rows(i).Cells(2).Value = tabla.Rows(i)(2).ToString()
                DgvResultado.Rows(i).Cells(3).Value = tabla.Rows(i)(3).ToString()
                DgvResultado.Rows(i).Cells(4).Value = tabla.Rows(i)(4).ToString()
                DgvResultado.Rows(i).Cells(5).Value = tabla.Rows(i)(5).ToString()
                DgvResultado.Rows(i).Cells(6).Value = tabla.Rows(i)(6).ToString()
                DgvResultado.Rows(i).Cells(7).Value = tabla.Rows(i)(7).ToString()
                DgvResultado.Rows(i).Cells(8).Value = tabla.Rows(i)(8).ToString()
                DgvResultado.Rows(i).Cells(9).Value = tabla.Rows(i)(9).ToString()
            End If
            'DgvResultado.Rows.Add()
        Next


    End Sub

    Private Sub Frm_Andenes_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        f_Andenes = False
    End Sub


    Private Sub transformarHora()



    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim frm As Frm_AndenesCerr = New Frm_AndenesCerr
       
        frm.ShowDialog()
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Dim frm As Frm_AndenesAbrir = New Frm_AndenesAbrir

        frm.ShowDialog()
    End Sub
End Class
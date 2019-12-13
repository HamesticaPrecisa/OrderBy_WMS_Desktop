Imports System.Security.Cryptography
Imports System.Text
Public Class s

    Public CORDI As String = ""
    Public posicioncreada As String = ""
    Dim fnc As New Funciones




    Private Sub Frm_AddColumna_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        CORDI = w.COR

        Dim numeropisos As Integer = w.pis3
 
        If numeropisos = 7 Then



        End If
        If numeropisos = 6 Then
 
            CheckPiso7.Visible = False
            GroupBoxpiso7.Visible = False

            ACheckPiso7.Visible = False

        End If

        If numeropisos = 5 Then
 
            GroupBoxpiso6.Visible = False
            CheckPiso6.Visible = False
            CheckPiso7.Visible = False
            ACheckPiso6.Visible = False
            ACheckPiso7.Visible = False
            GroupBoxpiso7.Visible = False



        End If
        If numeropisos = 4 Then
    
            CheckPiso5.Visible = False

            ACheckPiso5.Visible = False
            GroupBoxpiso5.Visible = False
            GroupBoxpiso6.Visible = False
            CheckPiso6.Visible = False
            CheckPiso7.Visible = False
            ACheckPiso6.Visible = False
            ACheckPiso7.Visible = False
            GroupBoxpiso7.Visible = False


        End If
        If numeropisos = 3 Then
        
            CheckPiso4.Visible = False
            ACheckPiso4.Visible = False
            GroupBoxpiso4.Visible = False
            CheckPiso5.Visible = False
            ACheckPiso5.Visible = False
            GroupBoxpiso5.Visible = False
            GroupBoxpiso6.Visible = False
            CheckPiso6.Visible = False
            CheckPiso7.Visible = False
            ACheckPiso6.Visible = False
            ACheckPiso7.Visible = False
            GroupBoxpiso7.Visible = False


        End If
        If numeropisos = 2 Then
      
            CheckPiso3.Visible = False
            ACheckPiso3.Visible = False
            GroupBoxpiso3.Visible = False
            CheckPiso4.Visible = False
            ACheckPiso4.Visible = False
            GroupBoxpiso4.Visible = False
            CheckPiso5.Visible = False
            ACheckPiso5.Visible = False
            GroupBoxpiso5.Visible = False
            GroupBoxpiso6.Visible = False
            CheckPiso6.Visible = False
            CheckPiso7.Visible = False
            ACheckPiso6.Visible = False
            ACheckPiso7.Visible = False
            GroupBoxpiso7.Visible = False


        End If
        If numeropisos = 1 Then

            CheckPiso2.Visible = False
            ACheckPiso2.Visible = False
            GroupBoxpiso2.Visible = False
            CheckPiso3.Visible = False
            ACheckPiso3.Visible = False
            GroupBoxpiso3.Visible = False
            CheckPiso4.Visible = False
            ACheckPiso4.Visible = False
            GroupBoxpiso4.Visible = False
            CheckPiso5.Visible = False
            ACheckPiso5.Visible = False
            GroupBoxpiso5.Visible = False
            GroupBoxpiso6.Visible = False
            CheckPiso6.Visible = False
            CheckPiso7.Visible = False
            ACheckPiso6.Visible = False
            ACheckPiso7.Visible = False
            GroupBoxpiso7.Visible = False
            llenafotos0()

        End If
        Dim sql As String = "SELECT estado,piso from camaramantenedor where cordenada ='" + CORDI.Trim() + "'  and camara ='" + w.codigocamara + "'"
        Dim tabla As DataTable = fnc.ListarTablasSQL(Sql)

        For i As Integer = 0 To tabla.Rows.Count - 1

            If tabla.Rows(i)(1).ToString().Trim() = "01" Then

                If tabla.Rows(i)(0).ToString().Trim() = "1" Then

                    CheckPiso1.Checked = False
                    GroupBoxpiso1.Enabled = False
                Else
                    CheckPiso1.Checked = True
                    GroupBoxpiso1.Enabled = True

                End If


            ElseIf tabla.Rows(i)(1).ToString().Trim() = "02" Then

                If tabla.Rows(i)(0).ToString().Trim() = "1" Then

                    CheckPiso2.Checked = False
                    GroupBoxpiso2.Enabled = False
                Else
                    CheckPiso2.Checked = True
                    GroupBoxpiso2.Enabled = True

                End If

            ElseIf tabla.Rows(i)(1).ToString().Trim() = "03" Then

                If tabla.Rows(i)(0).ToString().Trim() = "1" Then

                    CheckPiso3.Checked = False
                    GroupBoxpiso3.Enabled = False
                Else
                    CheckPiso3.Checked = True
                    GroupBoxpiso3.Enabled = True

                End If

            ElseIf tabla.Rows(i)(1).ToString().Trim() = "04" Then

                If tabla.Rows(i)(0).ToString().Trim() = "1" Then

                    CheckPiso4.Checked = False
                    GroupBoxpiso4.Enabled = False
                Else
                    CheckPiso4.Checked = True
                    GroupBoxpiso4.Enabled = True

                End If

            ElseIf tabla.Rows(i)(1).ToString().Trim() = "05" Then
                If tabla.Rows(i)(0).ToString().Trim() = "1" Then

                    CheckPiso5.Checked = False
                    GroupBoxpiso5.Enabled = False
                Else
                    CheckPiso5.Checked = True
                    GroupBoxpiso5.Enabled = True

                End If

            ElseIf tabla.Rows(i)(1).ToString().Trim() = "06" Then

                If tabla.Rows(i)(0).ToString().Trim() = "1" Then

                    CheckPiso6.Checked = False
                    GroupBoxpiso6.Enabled = False
                Else
                    CheckPiso6.Checked = True
                    GroupBoxpiso6.Enabled = True

                End If

            ElseIf tabla.Rows(i)(1).ToString().Trim() = "07" Then

                If tabla.Rows(i)(0).ToString().Trim() = "1" Then

                    CheckPiso7.Checked = False
                    GroupBoxpiso7.Enabled = False
                Else
                    CheckPiso7.Checked = True
                    GroupBoxpiso7.Enabled = True

                End If

            End If


        Next


        Dim sql2 As String = "SELECT Aestado,piso from camaramantenedor where cordenada ='" + CORDI.Trim() + "'  and camara ='" + w.codigocamara + "'"
        Dim tabla2 As DataTable = fnc.ListarTablasSQL(sql2)

        For i As Integer = 0 To tabla2.Rows.Count - 1

            If tabla2.Rows(i)(1).ToString().Trim() = "01" Then

                If tabla2.Rows(i)(0).ToString().Trim() = "1" Then

                    ACheckPiso1.Checked = False
                    GroupBoxpiso1.Enabled = False
                Else
                    ACheckPiso1.Checked = True
                    GroupBoxpiso1.Enabled = True

                End If


            ElseIf tabla2.Rows(i)(1).ToString().Trim() = "02" Then

                If tabla2.Rows(i)(0).ToString().Trim() = "1" Then

                    ACheckPiso2.Checked = False
                    GroupBoxpiso2.Enabled = False
                Else
                    ACheckPiso2.Checked = True
                    GroupBoxpiso2.Enabled = True

                End If

            ElseIf tabla2.Rows(i)(1).ToString().Trim() = "03" Then

                If tabla2.Rows(i)(0).ToString().Trim() = "1" Then

                    ACheckPiso3.Checked = False
                    GroupBoxpiso3.Enabled = False
                Else
                    ACheckPiso3.Checked = True
                    GroupBoxpiso3.Enabled = True

                End If

            ElseIf tabla2.Rows(i)(1).ToString().Trim() = "04" Then

                If tabla2.Rows(i)(0).ToString().Trim() = "1" Then

                    ACheckPiso4.Checked = False
                    GroupBoxpiso4.Enabled = False
                Else
                    ACheckPiso4.Checked = True
                    GroupBoxpiso4.Enabled = True

                End If

            ElseIf tabla2.Rows(i)(1).ToString().Trim() = "05" Then
                If tabla2.Rows(i)(0).ToString().Trim() = "1" Then

                    ACheckPiso5.Checked = False
                    GroupBoxpiso5.Enabled = False
                Else
                    ACheckPiso5.Checked = True
                    GroupBoxpiso5.Enabled = True

                End If

            ElseIf tabla2.Rows(i)(1).ToString().Trim() = "06" Then

                If tabla2.Rows(i)(0).ToString().Trim() = "1" Then

                    ACheckPiso6.Checked = False
                    GroupBoxpiso6.Enabled = False
                Else
                    ACheckPiso6.Checked = True
                    GroupBoxpiso6.Enabled = True

                End If

            ElseIf tabla2.Rows(i)(1).ToString().Trim() = "07" Then

                If tabla2.Rows(i)(0).ToString().Trim() = "1" Then

                    ACheckPiso7.Checked = False
                    GroupBoxpiso7.Enabled = False
                Else
                    ACheckPiso7.Checked = True
                    GroupBoxpiso7.Enabled = True

                End If

            End If


        Next





        'llenafotos1()
        llenafotosfinal()
        traeralturas()

        w.ProgressBar2.Value = w.ProgressBar2.Maximum

    End Sub

   
    Private Sub llenafotosfinal()
        w.ProgressBar2.Value = 0

        w.ProgressBar2.Maximum = 8
        w.ProgressBar2.Value += 1
        For i As Integer = 1 To 7

            Dim sql As String = "SELECT * from FOTOSPIC('" + w.codigocamara + "','" + w.COR + "','" + i.ToString().Trim() + "'  ) "
            Dim tabla As DataTable = fnc.ListarTablasSQL(sql)
            If tabla.Rows.Count > 0 Then

                If tabla.Rows(0)(2).ToString().Trim() = "0" Then

                Else
                    If tabla.Rows(0)(0).ToString().Trim() = "BINS MADERA" Or tabla.Rows(0)(0).ToString().Trim() = "BINS ESPECIAL" Then
                        If tabla.Rows(0)(1).ToString().Trim() = "1" Then
                            PictureBox1.Image = My.Resources._110binsmadera
                        ElseIf tabla.Rows(0)(1).ToString().Trim() = "2" Then
                            PictureBox2.Image = My.Resources._110binsmadera
                        ElseIf tabla.Rows(0)(1).ToString().Trim() = "3" Then
                            PictureBox3.Image = My.Resources._110binsmadera
                        ElseIf tabla.Rows(0)(1).ToString().Trim() = "4" Then
                            PictureBox4.Image = My.Resources._110binsmadera
                        ElseIf tabla.Rows(0)(1).ToString().Trim() = "5" Then
                            PictureBox5.Image = My.Resources._110binsmadera

                        ElseIf tabla.Rows(0)(1).ToString().Trim() = "6" Then
                            PictureBox6.Image = My.Resources._110binsmadera
                        ElseIf tabla.Rows(0)(1).ToString().Trim() = "7" Then
                            PictureBox7.Image = My.Resources._110binsmadera
                        End If
                    End If
                    If tabla.Rows(0)(0).ToString().Trim() = "PALLETS CON TACO" Or tabla.Rows(0)(0).ToString().Trim() = "PALLETS YUGO" Or tabla.Rows(0)(0).ToString().Trim() = "PALLET PLASTICO" Then


                        If tabla.Rows(0)(1).ToString().Trim() = "1" Then
                            PictureBox1.Image = My.Resources._110rack
                        ElseIf tabla.Rows(0)(1).ToString().Trim() = "2" Then
                            PictureBox2.Image = My.Resources._110rack
                        ElseIf tabla.Rows(0)(1).ToString().Trim() = "3" Then
                            PictureBox3.Image = My.Resources._110rack
                        ElseIf tabla.Rows(0)(1).ToString().Trim() = "4" Then
                            PictureBox4.Image = My.Resources._110rack
                        ElseIf tabla.Rows(0)(1).ToString().Trim() = "5" Then
                            PictureBox5.Image = My.Resources._110rack

                        ElseIf tabla.Rows(0)(1).ToString().Trim() = "6" Then
                            PictureBox6.Image = My.Resources._110rack
                        ElseIf tabla.Rows(0)(1).ToString().Trim() = "7" Then
                            PictureBox7.Image = My.Resources._110rack
                        End If

                    End If

                    If tabla.Rows(0)(0).ToString().Trim() = "BINS PLASTICOS" Then


                        If tabla.Rows(0)(1).ToString().Trim() = "1" Then
                            PictureBox1.Image = My.Resources._110binsplastico
                        ElseIf tabla.Rows(0)(1).ToString().Trim() = "2" Then
                            PictureBox2.Image = My.Resources._110binsplastico
                        ElseIf tabla.Rows(0)(1).ToString().Trim() = "3" Then
                            PictureBox3.Image = My.Resources._110binsplastico
                        ElseIf tabla.Rows(0)(1).ToString().Trim() = "4" Then
                            PictureBox4.Image = My.Resources._110binsplastico
                        ElseIf tabla.Rows(0)(1).ToString().Trim() = "5" Then
                            PictureBox5.Image = My.Resources._110binsplastico

                        ElseIf tabla.Rows(0)(1).ToString().Trim() = "6" Then
                            PictureBox6.Image = My.Resources._110binsplastico
                        ElseIf tabla.Rows(0)(1).ToString().Trim() = "7" Then
                            PictureBox7.Image = My.Resources._110binsplastico
                        End If
                    End If
                    If tabla.Rows(0)(0).ToString().Trim() = "TOTE" Then


                        If tabla.Rows(0)(1).ToString().Trim() = "1" Then
                            PictureBox1.Image = My.Resources._110bloque
                        ElseIf tabla.Rows(0)(1).ToString().Trim() = "2" Then
                            PictureBox2.Image = My.Resources._110bloque
                        ElseIf tabla.Rows(0)(1).ToString().Trim() = "3" Then
                            PictureBox3.Image = My.Resources._110bloque
                        ElseIf tabla.Rows(0)(1).ToString().Trim() = "4" Then
                            PictureBox4.Image = My.Resources._110bloque
                        ElseIf tabla.Rows(0)(1).ToString().Trim() = "5" Then
                            PictureBox5.Image = My.Resources._110bloque

                        ElseIf tabla.Rows(0)(1).ToString().Trim() = "6" Then
                            PictureBox6.Image = My.Resources._110bloque
                        ElseIf tabla.Rows(0)(1).ToString().Trim() = "7" Then
                            PictureBox7.Image = My.Resources._110bloque
                        End If

                    End If
                    If tabla.Rows(0)(0).ToString().Trim() = "PALLET P/TAMBOR" Then


                        If tabla.Rows(0)(1).ToString().Trim() = "1" Then
                            PictureBox1.Image = My.Resources._110tambor
                        ElseIf tabla.Rows(0)(1).ToString().Trim() = "2" Then
                            PictureBox2.Image = My.Resources._110tambor
                        ElseIf tabla.Rows(0)(1).ToString().Trim() = "3" Then
                            PictureBox3.Image = My.Resources._110tambor
                        ElseIf tabla.Rows(0)(1).ToString().Trim() = "4" Then
                            PictureBox4.Image = My.Resources._110tambor
                        ElseIf tabla.Rows(0)(1).ToString().Trim() = "5" Then
                            PictureBox5.Image = My.Resources._110tambor

                        ElseIf tabla.Rows(0)(1).ToString().Trim() = "6" Then
                            PictureBox6.Image = My.Resources._110tambor
                        ElseIf tabla.Rows(0)(1).ToString().Trim() = "7" Then
                            PictureBox7.Image = My.Resources._110tambor
                        End If

                    End If

                    If tabla.Rows(0)(1).ToString().Trim() = "1" Then
                        TextBox1.Text = tabla.Rows(0)(2).ToString().Trim() + "  SOPORTANTE'S"
                    ElseIf tabla.Rows(0)(1).ToString().Trim() = "2" Then
                        TextBox2.Text = tabla.Rows(0)(2).ToString().Trim() + "  SOPORTANTE'S"
                    ElseIf tabla.Rows(0)(1).ToString().Trim() = "3" Then
                        TextBox3.Text = tabla.Rows(0)(2).ToString().Trim() + "  SOPORTANTE'S"
                    ElseIf tabla.Rows(0)(1).ToString().Trim() = "4" Then
                        TextBox4.Text = tabla.Rows(0)(2).ToString().Trim() + "  SOPORTANTE'S"
                    ElseIf tabla.Rows(0)(1).ToString().Trim() = "5" Then
                        TextBox5.Text = tabla.Rows(0)(2).ToString().Trim() + "  SOPORTANTE'S"

                    ElseIf tabla.Rows(0)(1).ToString().Trim() = "6" Then
                        TextBox6.Text = tabla.Rows(0)(2).ToString().Trim() + "  SOPORTANTE'S"
                    ElseIf tabla.Rows(0)(1).ToString().Trim() = "7" Then
                        TextBox7.Text = tabla.Rows(0)(2).ToString().Trim() + "  SOPORTANTE'S"
                    End If


                End If


            End If
            w.ProgressBar2.Value += 1
        Next

    End Sub

    Private Sub llenafotos0()
        Dim sql As String = "SELECT * from VG_PARAFOTO  where racd_ca='" + w.codigocamara + "' and cordenada='" + w.COR + "' AND racd_pi='00' "
        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)



        If tabla.Rows.Count > 0 Then


            If tabla.Rows(0)(5).ToString().Trim() = "00" Then

                If tabla.Rows(0)(1).ToString().Trim() = "BINS MADERA" Then

                    PictureBox1.Image = My.Resources._110binsmadera

                End If
                If tabla.Rows(0)(1).ToString().Trim() = "BINS ESPECIAL" Then

                    PictureBox1.Image = My.Resources._110binsmadera

                End If
                If tabla.Rows(0)(1).ToString().Trim() = "PALLETS CON TACO" Then

                    PictureBox1.Image = My.Resources._110rack

                End If
                If tabla.Rows(0)(1).ToString().Trim() = "PALLETS YUGO" Then

                    PictureBox1.Image = My.Resources._110rack

                End If
                If tabla.Rows(0)(1).ToString().Trim() = "PALLET PLASTICO" Then

                    PictureBox1.Image = My.Resources._110rack

                End If
                If tabla.Rows(0)(1).ToString().Trim() = "BINS PLASTICOS" Then

                    PictureBox1.Image = My.Resources._110binsplastico

                End If
                If tabla.Rows(0)(1).ToString().Trim() = "TOTE" Then

                    PictureBox1.Image = My.Resources._110bloque

                End If
                If tabla.Rows(0)(1).ToString().Trim() = "PALLET P/TAMBOR" Then

                    PictureBox1.Image = My.Resources._110tambor

                End If

                TextBox1.Text = tabla.Rows.Count.ToString() + "  SOPORTANTE'S"




            End If



        End If
    End Sub

    Private Sub llenafotos1()
        Dim sql As String = "SELECT * from FOTOSPISOS('" + w.codigocamara + "','" + w.COR + "'  ) "
        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)





        For i As Integer = 0 To tabla.Rows.Count - 1

            If tabla.Rows(i)(2).ToString().Trim() = "0" Then

            Else

                If tabla.Rows(i)(0).ToString().Trim() = "BINS MADERA" Or tabla.Rows(i)(0).ToString().Trim() = "BINS ESPECIAL" Then
                    If tabla.Rows(i)(1).ToString().Trim() = "1" Then
                        PictureBox1.Image = My.Resources._110binsmadera
                    ElseIf tabla.Rows(i)(1).ToString().Trim() = "2" Then
                        PictureBox2.Image = My.Resources._110binsmadera
                    ElseIf tabla.Rows(i)(1).ToString().Trim() = "3" Then
                        PictureBox3.Image = My.Resources._110binsmadera
                    ElseIf tabla.Rows(i)(1).ToString().Trim() = "4" Then
                        PictureBox4.Image = My.Resources._110binsmadera
                    ElseIf tabla.Rows(i)(1).ToString().Trim() = "5" Then
                        PictureBox5.Image = My.Resources._110binsmadera

                    ElseIf tabla.Rows(i)(1).ToString().Trim() = "6" Then
                        PictureBox6.Image = My.Resources._110binsmadera
                    ElseIf tabla.Rows(i)(1).ToString().Trim() = "7" Then
                        PictureBox7.Image = My.Resources._110binsmadera
                    End If
                End If
                If tabla.Rows(i)(0).ToString().Trim() = "PALLETS CON TACO" Or tabla.Rows(i)(0).ToString().Trim() = "PALLETS YUGO" Or tabla.Rows(i)(0).ToString().Trim() = "PALLET PLASTICO" Then


                    If tabla.Rows(i)(1).ToString().Trim() = "1" Then
                        PictureBox1.Image = My.Resources._110rack
                    ElseIf tabla.Rows(i)(1).ToString().Trim() = "2" Then
                        PictureBox2.Image = My.Resources._110rack
                    ElseIf tabla.Rows(i)(1).ToString().Trim() = "3" Then
                        PictureBox3.Image = My.Resources._110rack
                    ElseIf tabla.Rows(i)(1).ToString().Trim() = "4" Then
                        PictureBox4.Image = My.Resources._110rack
                    ElseIf tabla.Rows(i)(1).ToString().Trim() = "5" Then
                        PictureBox5.Image = My.Resources._110rack

                    ElseIf tabla.Rows(i)(1).ToString().Trim() = "6" Then
                        PictureBox6.Image = My.Resources._110rack
                    ElseIf tabla.Rows(i)(1).ToString().Trim() = "7" Then
                        PictureBox7.Image = My.Resources._110rack
                    End If

                End If

                If tabla.Rows(i)(0).ToString().Trim() = "BINS PLASTICOS" Then


                    If tabla.Rows(i)(1).ToString().Trim() = "1" Then
                        PictureBox1.Image = My.Resources._110binsplastico
                    ElseIf tabla.Rows(i)(1).ToString().Trim() = "2" Then
                        PictureBox2.Image = My.Resources._110binsplastico
                    ElseIf tabla.Rows(i)(1).ToString().Trim() = "3" Then
                        PictureBox3.Image = My.Resources._110binsplastico
                    ElseIf tabla.Rows(i)(1).ToString().Trim() = "4" Then
                        PictureBox4.Image = My.Resources._110binsplastico
                    ElseIf tabla.Rows(i)(1).ToString().Trim() = "5" Then
                        PictureBox5.Image = My.Resources._110binsplastico

                    ElseIf tabla.Rows(i)(1).ToString().Trim() = "6" Then
                        PictureBox6.Image = My.Resources._110binsplastico
                    ElseIf tabla.Rows(i)(1).ToString().Trim() = "7" Then
                        PictureBox7.Image = My.Resources._110binsplastico
                    End If
                End If
                If tabla.Rows(i)(0).ToString().Trim() = "TOTE" Then


                    If tabla.Rows(i)(1).ToString().Trim() = "1" Then
                        PictureBox1.Image = My.Resources._110bloque
                    ElseIf tabla.Rows(i)(1).ToString().Trim() = "2" Then
                        PictureBox2.Image = My.Resources._110bloque
                    ElseIf tabla.Rows(i)(1).ToString().Trim() = "3" Then
                        PictureBox3.Image = My.Resources._110bloque
                    ElseIf tabla.Rows(i)(1).ToString().Trim() = "4" Then
                        PictureBox4.Image = My.Resources._110bloque
                    ElseIf tabla.Rows(i)(1).ToString().Trim() = "5" Then
                        PictureBox5.Image = My.Resources._110bloque

                    ElseIf tabla.Rows(i)(1).ToString().Trim() = "6" Then
                        PictureBox6.Image = My.Resources._110bloque
                    ElseIf tabla.Rows(i)(1).ToString().Trim() = "7" Then
                        PictureBox7.Image = My.Resources._110bloque
                    End If

                End If
                If tabla.Rows(i)(0).ToString().Trim() = "PALLET P/TAMBOR" Then


                    If tabla.Rows(i)(1).ToString().Trim() = "1" Then
                        PictureBox1.Image = My.Resources._110tambor
                    ElseIf tabla.Rows(i)(1).ToString().Trim() = "2" Then
                        PictureBox2.Image = My.Resources._110tambor
                    ElseIf tabla.Rows(i)(1).ToString().Trim() = "3" Then
                        PictureBox3.Image = My.Resources._110tambor
                    ElseIf tabla.Rows(i)(1).ToString().Trim() = "4" Then
                        PictureBox4.Image = My.Resources._110tambor
                    ElseIf tabla.Rows(i)(1).ToString().Trim() = "5" Then
                        PictureBox5.Image = My.Resources._110tambor

                    ElseIf tabla.Rows(i)(1).ToString().Trim() = "6" Then
                        PictureBox6.Image = My.Resources._110tambor
                    ElseIf tabla.Rows(i)(1).ToString().Trim() = "7" Then
                        PictureBox7.Image = My.Resources._110tambor
                    End If

                End If

                If tabla.Rows(i)(1).ToString().Trim() = "1" Then
                    TextBox1.Text = tabla.Rows(i)(2).ToString().Trim() + "  SOPORTANTE'S"
                ElseIf tabla.Rows(i)(1).ToString().Trim() = "2" Then
                    TextBox2.Text = tabla.Rows(i)(2).ToString().Trim() + "  SOPORTANTE'S"
                ElseIf tabla.Rows(i)(1).ToString().Trim() = "3" Then
                    TextBox3.Text = tabla.Rows(i)(2).ToString().Trim() + "  SOPORTANTE'S"
                ElseIf tabla.Rows(i)(1).ToString().Trim() = "4" Then
                    TextBox4.Text = tabla.Rows(i)(2).ToString().Trim() + "  SOPORTANTE'S"
                ElseIf tabla.Rows(i)(1).ToString().Trim() = "5" Then
                    TextBox5.Text = tabla.Rows(i)(2).ToString().Trim() + "  SOPORTANTE'S"

                ElseIf tabla.Rows(i)(1).ToString().Trim() = "6" Then
                    TextBox6.Text = tabla.Rows(i)(2).ToString().Trim() + "  SOPORTANTE'S"
                ElseIf tabla.Rows(i)(1).ToString().Trim() = "7" Then
                    TextBox7.Text = tabla.Rows(i)(2).ToString().Trim() + "  SOPORTANTE'S"
                End If





            End If












        Next





    End Sub
    Private Sub llenafotos2()
        Dim sql As String = "SELECT * from VG_PARAFOTO  where racd_ca='" + w.codigocamara + "' and cordenada='" + w.COR + "' AND racd_pi='2' "
        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)



        If tabla.Rows.Count > 0 Then



            If tabla.Rows(0)(1).ToString().Trim() = "BINS MADERA" Then

                PictureBox2.Image = My.Resources._110binsmadera

            End If
            If tabla.Rows(0)(1).ToString().Trim() = "BINS ESPECIAL" Then

                PictureBox2.Image = My.Resources._110binsmadera

            End If
            If tabla.Rows(0)(1).ToString().Trim() = "PALLETS CON TACO" Then

                PictureBox2.Image = My.Resources._110rack

            End If
            If tabla.Rows(0)(1).ToString().Trim() = "PALLETS YUGO" Then

                PictureBox2.Image = My.Resources._110rack

            End If
            If tabla.Rows(0)(1).ToString().Trim() = "PALLET PLASTICO" Then

                PictureBox2.Image = My.Resources._110rack

            End If
            If tabla.Rows(0)(1).ToString().Trim() = "BINS PLASTICOS" Then

                PictureBox2.Image = My.Resources._110binsplastico

            End If
            If tabla.Rows(0)(1).ToString().Trim() = "TOTE" Then

                PictureBox2.Image = My.Resources._110bloque

            End If
            If tabla.Rows(0)(1).ToString().Trim() = "PALLET P/TAMBOR" Then

                PictureBox2.Image = My.Resources._110tambor

            End If

            TextBox2.Text = tabla.Rows.Count.ToString() + "  SOPORTANTE'S"








        End If
    End Sub
    Private Sub llenafotos3()
        Dim sql As String = "SELECT * from VG_PARAFOTO  where racd_ca='" + w.codigocamara + "' and cordenada='" + w.COR + "' AND racd_pi='3' "
        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)



        If tabla.Rows.Count > 0 Then




            If tabla.Rows(0)(1).ToString().Trim() = "BINS MADERA" Then

                PictureBox3.Image = My.Resources._110binsmadera

            End If
            If tabla.Rows(0)(1).ToString().Trim() = "BINS ESPECIAL" Then

                PictureBox3.Image = My.Resources._110binsmadera

            End If
            If tabla.Rows(0)(1).ToString().Trim() = "PALLETS CON TACO" Then

                PictureBox3.Image = My.Resources._110rack

            End If
            If tabla.Rows(0)(1).ToString().Trim() = "PALLETS YUGO" Then

                PictureBox3.Image = My.Resources._110rack

            End If
            If tabla.Rows(0)(1).ToString().Trim() = "PALLET PLASTICO" Then

                PictureBox3.Image = My.Resources._110rack

            End If
            If tabla.Rows(0)(1).ToString().Trim() = "BINS PLASTICOS" Then

                PictureBox3.Image = My.Resources._110binsplastico

            End If
            If tabla.Rows(0)(1).ToString().Trim() = "TOTE" Then

                PictureBox3.Image = My.Resources._110bloque

            End If
            If tabla.Rows(0)(1).ToString().Trim() = "PALLET P/TAMBOR" Then

                PictureBox3.Image = My.Resources._110tambor

            End If

            TextBox3.Text = tabla.Rows.Count.ToString() + "  SOPORTANTE'S"








        End If
    End Sub
    Private Sub llenafotos4()
        Dim sql As String = "SELECT * from VG_PARAFOTO  where racd_ca='" + w.codigocamara + "' and cordenada='" + w.COR + "' AND racd_pi='4' "
        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)



        If tabla.Rows.Count > 0 Then




            If tabla.Rows(0)(1).ToString().Trim() = "BINS MADERA" Then

                PictureBox4.Image = My.Resources._110binsmadera

            End If
            If tabla.Rows(0)(1).ToString().Trim() = "BINS ESPECIAL" Then

                PictureBox4.Image = My.Resources._110binsmadera

            End If
            If tabla.Rows(0)(1).ToString().Trim() = "PALLETS CON TACO" Then

                PictureBox4.Image = My.Resources._110rack

            End If
            If tabla.Rows(0)(1).ToString().Trim() = "PALLETS YUGO" Then

                PictureBox4.Image = My.Resources._110rack

            End If
            If tabla.Rows(0)(1).ToString().Trim() = "PALLET PLASTICO" Then

                PictureBox4.Image = My.Resources._110rack

            End If
            If tabla.Rows(0)(1).ToString().Trim() = "BINS PLASTICOS" Then

                PictureBox4.Image = My.Resources._110binsplastico

            End If
            If tabla.Rows(0)(1).ToString().Trim() = "TOTE" Then

                PictureBox4.Image = My.Resources._110bloque

            End If
            If tabla.Rows(0)(1).ToString().Trim() = "PALLET P/TAMBOR" Then

                PictureBox4.Image = My.Resources._110tambor

            End If

            TextBox4.Text = tabla.Rows.Count.ToString() + "  SOPORTANTE'S"








        End If
    End Sub
    Private Sub llenafotos5()
        Dim sql As String = "SELECT * from VG_PARAFOTO  where racd_ca='" + w.codigocamara + "' and cordenada='" + w.COR + "' AND racd_pi='5' "
        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)



        If tabla.Rows.Count > 0 Then



            If tabla.Rows(0)(1).ToString().Trim() = "BINS MADERA" Then

                PictureBox5.Image = My.Resources._110binsmadera

            End If
            If tabla.Rows(0)(1).ToString().Trim() = "BINS ESPECIAL" Then

                PictureBox5.Image = My.Resources._110binsmadera

            End If
            If tabla.Rows(0)(1).ToString().Trim() = "PALLETS CON TACO" Then

                PictureBox5.Image = My.Resources._110rack

            End If
            If tabla.Rows(0)(1).ToString().Trim() = "PALLETS YUGO" Then

                PictureBox5.Image = My.Resources._110rack

            End If
            If tabla.Rows(0)(1).ToString().Trim() = "PALLET PLASTICO" Then

                PictureBox5.Image = My.Resources._110rack

            End If
            If tabla.Rows(0)(1).ToString().Trim() = "BINS PLASTICOS" Then

                PictureBox5.Image = My.Resources._110binsplastico

            End If
            If tabla.Rows(0)(1).ToString().Trim() = "TOTE" Then

                PictureBox5.Image = My.Resources._110bloque

            End If
            If tabla.Rows(0)(1).ToString().Trim() = "PALLET P/TAMBOR" Then

                PictureBox5.Image = My.Resources._110tambor

            End If

            TextBox5.Text = tabla.Rows.Count.ToString() + "  SOPORTANTE'S"








        End If
    End Sub
    Private Sub llenafotos6()
        Dim sql As String = "SELECT * from VG_PARAFOTO  where racd_ca='" + w.codigocamara + "' and cordenada='" + w.COR + "' AND racd_pi='6' "
        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)



        If tabla.Rows.Count > 0 Then



            If tabla.Rows(0)(1).ToString().Trim() = "BINS MADERA" Then

                PictureBox6.Image = My.Resources._110binsmadera

            End If
            If tabla.Rows(0)(1).ToString().Trim() = "BINS ESPECIAL" Then

                PictureBox6.Image = My.Resources._110binsmadera

            End If
            If tabla.Rows(0)(1).ToString().Trim() = "PALLETS CON TACO" Then

                PictureBox6.Image = My.Resources._110rack

            End If
            If tabla.Rows(0)(1).ToString().Trim() = "PALLETS YUGO" Then

                PictureBox6.Image = My.Resources._110rack

            End If
            If tabla.Rows(0)(1).ToString().Trim() = "PALLET PLASTICO" Then

                PictureBox6.Image = My.Resources._110rack

            End If
            If tabla.Rows(0)(1).ToString().Trim() = "BINS PLASTICOS" Then

                PictureBox6.Image = My.Resources._110binsplastico

            End If
            If tabla.Rows(0)(1).ToString().Trim() = "TOTE" Then

                PictureBox6.Image = My.Resources._110bloque

            End If
            If tabla.Rows(0)(1).ToString().Trim() = "PALLET P/TAMBOR" Then

                PictureBox6.Image = My.Resources._110tambor

            End If

            TextBox6.Text = tabla.Rows.Count.ToString() + "  SOPORTANTE'S"








        End If
    End Sub
    Private Sub llenafotos7()
        Dim sql As String = "SELECT * from VG_PARAFOTO  where racd_ca='" + w.codigocamara + "' and cordenada='" + w.COR + "' AND racd_pi='7' "
        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)



        If tabla.Rows.Count > 0 Then




            If tabla.Rows(0)(1).ToString().Trim() = "BINS MADERA" Then

                PictureBox7.Image = My.Resources._110binsmadera

            End If
            If tabla.Rows(0)(1).ToString().Trim() = "BINS ESPECIAL" Then

                PictureBox7.Image = My.Resources._110binsmadera

            End If
            If tabla.Rows(0)(1).ToString().Trim() = "PALLETS CON TACO" Then

                PictureBox7.Image = My.Resources._110rack

            End If
            If tabla.Rows(0)(1).ToString().Trim() = "PALLETS YUGO" Then

                PictureBox7.Image = My.Resources._110rack

            End If
            If tabla.Rows(0)(1).ToString().Trim() = "PALLET PLASTICO" Then

                PictureBox7.Image = My.Resources._110rack

            End If
            If tabla.Rows(0)(1).ToString().Trim() = "BINS PLASTICOS" Then

                PictureBox7.Image = My.Resources._110binsplastico

            End If
            If tabla.Rows(0)(1).ToString().Trim() = "TOTE" Then

                PictureBox7.Image = My.Resources._110bloque

            End If
            If tabla.Rows(0)(1).ToString().Trim() = "PALLET P/TAMBOR" Then

                PictureBox7.Image = My.Resources._110tambor

            End If

            TextBox7.Text = tabla.Rows.Count.ToString() + "  SOPORTANTE'S"








        End If
    End Sub
    Private Sub traeralturas()




        Dim sql As String = "SELECT Altura,piso FROM camaraMantenedor where Cordenada='" + w.COR + "' AND  camara = '" + w.codigocamara + "' ORDER BY PISO " '"
        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)


        Dim wa As Integer = w.pis
        If tabla.Rows.Count > 0 Then
            For i As Integer = 0 To w.pis - 1


                Dim AL As String = tabla.Rows(i)(0).ToString()
                Dim pi As String = tabla.Rows(i)(1).ToString()

                If pi.Trim() = "01" Then
                    txtaltura1.Text = AL

                End If
                If pi.Trim() = "00" Then
                    txtaltura1.Text = AL
                    Exit Sub
                End If
                If pi.Trim() = "02" Then
                    txtaltura2.Text = AL

                End If
                If pi.Trim() = "03" Then
                    txtaltura3.Text = AL

                End If
                If pi.Trim() = "04" Then
                    txtaltura4.Text = AL

                End If
                If pi.Trim() = "05" Then
                    txtaltura5.Text = AL

                End If
                If pi.Trim() = "06" Then
                    txtaltura6.Text = AL

                End If
                If pi.Trim() = "07" Then
                    txtaltura7.Text = AL

                End If

            Next
        End If



    End Sub
    Private Sub CheckPiso1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckPiso1.CheckedChanged
        If ACheckPiso1.Checked = False And CheckPiso1.Checked = False Then
            CheckPiso1.Checked = True
            GroupBoxpiso1.Enabled = False
            MsgBox("Imposible desactivar piso que ya tiene un bloqueo", MsgBoxStyle.Information, "Aviso")
      
            Exit Sub


        End If

        Dim sql4 As String = "SELECT * FROM RACKDETA WHERE  racd_ca = '" + w.codigocamara + "' and racd_pi='1' and racd_ba = '" + w.bandapublic + "' and racd_co='" + w.columnapublic + "'"
        Dim tabla As DataTable = fnc.ListarTablasSQL(sql4)


        If tabla.Rows.Count > 0 Then

            If CheckPiso1.Checked = False Then
                CheckPiso1.Checked = True
                MsgBox("Imposible desactivar piso ya que esta posicion se encuentra ocupada", MsgBoxStyle.Information, "Aviso")

                Exit Sub

            End If





        End If

        If CheckPiso1.Checked = False Then
            Dim SqlElimina As String = "UPDATE CamaraMantenedor SET estado = '1' WHERE cordenada='" + w.COR + "' and camara = '" + w.codigocamara + "' and piso='01' "
            fnc.MovimientoSQL(SqlElimina)
            CheckPiso1.Checked = False
            GroupBoxpiso1.Enabled = False

        End If

        If CheckPiso1.Checked = True Then
            Dim SqlElimina As String = "UPDATE CamaraMantenedor SET estado = '0' WHERE cordenada='" + w.COR + "' and camara = '" + w.codigocamara + "' and piso='01' "
            fnc.MovimientoSQL(SqlElimina)
            CheckPiso1.Checked = True
            GroupBoxpiso1.Enabled = True

        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtaltura1.TextChanged

    End Sub

    Private Sub TextBox2_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtaltura2.TextChanged

    End Sub

    Private Sub btn_guardar_Click(sender As System.Object, e As System.EventArgs) Handles btn_guardar.Click


        If CheckPiso1.Visible = True Then

            If CheckBox1.Checked = True Then
                Dim sql3 As String = "UPDATE camaraMantenedor SET altura='" + txtaltura1.Text + "' WHERE  piso ='01' AND  camara = '" + w.codigocamara + "'"
                fnc.MovimientoSQL(sql3)

            Else

                Dim sql3 As String = "UPDATE camaraMantenedor SET altura='" + txtaltura1.Text + "' WHERE Cordenada='" + w.COR + "' AND piso ='01' AND  camara = '" + w.codigocamara + "'"
                fnc.MovimientoSQL(sql3)
            End If


        End If
        If CheckPiso2.Visible = True Then

            If CheckBox2.Checked = True Then
                Dim sql3 As String = "UPDATE camaraMantenedor SET altura='" + txtaltura2.Text + "' WHERE  piso ='02' AND  camara = '" + w.codigocamara + "'"
                fnc.MovimientoSQL(sql3)

            Else

                Dim sql3 As String = "UPDATE camaraMantenedor SET altura='" + txtaltura2.Text + "' WHERE Cordenada='" + w.COR + "' AND piso ='02' AND  camara = '" + w.codigocamara + "'"
                fnc.MovimientoSQL(sql3)

            End If
        End If
        If CheckPiso3.Visible = True Then

            If CheckBox3.Checked = True Then
                Dim sql3 As String = "UPDATE camaraMantenedor SET altura='" + txtaltura3.Text + "' WHERE  piso ='03' AND  camara = '" + w.codigocamara + "'"
                fnc.MovimientoSQL(sql3)

            Else


                Dim sql3 As String = "UPDATE camaraMantenedor SET altura='" + txtaltura3.Text + "' WHERE Cordenada='" + w.COR + "' AND piso ='03' AND  camara = '" + w.codigocamara + "'"
                fnc.MovimientoSQL(sql3)
            End If

        End If
        If CheckPiso4.Visible = True Then

            If CheckBox4.Checked = True Then
                Dim sql3 As String = "UPDATE camaraMantenedor SET altura='" + txtaltura4.Text + "' WHERE  piso ='04' AND  camara = '" + w.codigocamara + "'"
                fnc.MovimientoSQL(sql3)

            Else

                Dim sql3 As String = "UPDATE camaraMantenedor SET altura='" + txtaltura4.Text + "' WHERE Cordenada='" + w.COR + "' AND piso ='04' AND  camara = '" + w.codigocamara + "'"
                fnc.MovimientoSQL(sql3)
            End If
        End If
        If CheckPiso5.Visible = True Then
            If CheckBox5.Checked = True Then
                Dim sql3 As String = "UPDATE camaraMantenedor SET altura='" + txtaltura5.Text + "' WHERE  piso ='05' AND  camara = '" + w.codigocamara + "'"
                fnc.MovimientoSQL(sql3)

            Else

                Dim sql3 As String = "UPDATE camaraMantenedor SET altura='" + txtaltura5.Text + "' WHERE Cordenada='" + w.COR + "' AND piso ='05' AND  camara = '" + w.codigocamara + "'"
                fnc.MovimientoSQL(sql3)
            End If
        End If
        If CheckPiso6.Visible = True Then

            If CheckBox6.Checked = True Then
                Dim sql3 As String = "UPDATE camaraMantenedor SET altura='" + txtaltura6.Text + "' WHERE  piso ='06' AND  camara = '" + w.codigocamara + "'"
                fnc.MovimientoSQL(sql3)

            Else

                Dim sql3 As String = "UPDATE camaraMantenedor SET altura='" + txtaltura6.Text + "' WHERE Cordenada='" + w.COR + "' AND piso ='06' AND  camara = '" + w.codigocamara + "'"
                fnc.MovimientoSQL(sql3)
            End If
        End If
        If CheckPiso7.Visible = True Then

            If CheckBox7.Checked = True Then
                Dim sql3 As String = "UPDATE camaraMantenedor SET altura='" + txtaltura7.Text + "' WHERE  piso ='07' AND  camara = '" + w.codigocamara + "'"
                fnc.MovimientoSQL(sql3)
            End If
        Else

            Dim sql3 As String = "UPDATE camaraMantenedor SET altura='" + txtaltura7.Text + "' WHERE Cordenada='" + w.COR + "' AND piso ='07' AND  camara = '" + w.codigocamara + "'"
            fnc.MovimientoSQL(sql3)
        End If
    End Sub

    Private Sub CheckPiso7_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckPiso7.CheckedChanged

        If ACheckPiso7.Checked = False And CheckPiso7.Checked = False Then
            CheckPiso7.Checked = True
            GroupBoxpiso7.Enabled = False
            MsgBox("Imposible desactivar piso que ya tiene un bloqueo", MsgBoxStyle.Information, "Aviso")

            Exit Sub


        End If


        Dim sql4 As String = "SELECT * FROM RACKDETA WHERE  racd_ca = '" + w.codigocamara + "' and racd_pi='7' and racd_ba = '" + w.bandapublic + "' and racd_co='" + w.columnapublic + "'"
        Dim tabla As DataTable = fnc.ListarTablasSQL(sql4)



        If tabla.Rows.Count > 0 Then

            If CheckPiso7.Checked = False Then
                CheckPiso7.Checked = True
                MsgBox("Imposible desactivar piso ya que esta posicion se encuentra ocupada", MsgBoxStyle.Information, "Aviso")

                Exit Sub

            End If





        End If

        If CheckPiso7.Checked = False Then
            Dim SqlElimina As String = "UPDATE CamaraMantenedor SET estado = '1' WHERE cordenada='" + w.COR + "' and camara = '" + w.codigocamara + "' and piso='07' "
            fnc.MovimientoSQL(SqlElimina)
            CheckPiso7.Checked = False
            GroupBoxpiso7.Enabled = False

        End If

        If CheckPiso7.Checked = True Then
            Dim SqlElimina As String = "UPDATE CamaraMantenedor SET estado = '0' WHERE cordenada='" + w.COR + "' and camara = '" + w.codigocamara + "' and piso='07' "
            fnc.MovimientoSQL(SqlElimina)
            CheckPiso7.Checked = True
            GroupBoxpiso7.Enabled = True

        End If
    End Sub

    Private Sub CheckPiso6_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckPiso6.CheckedChanged

        If ACheckPiso6.Checked = False And CheckPiso6.Checked = False Then
            CheckPiso6.Checked = True
            GroupBoxpiso6.Enabled = False
            MsgBox("Imposible desactivar piso que ya tiene un bloqueo", MsgBoxStyle.Information, "Aviso")

            Exit Sub


        End If

        Dim sql4 As String = "SELECT * FROM RACKDETA WHERE  racd_ca = '" + w.codigocamara + "' and racd_pi='6' and racd_ba = '" + w.bandapublic + "' and racd_co='" + w.columnapublic + "'"
        Dim tabla As DataTable = fnc.ListarTablasSQL(sql4)


        If tabla.Rows.Count > 0 Then

            If CheckPiso6.Checked = False Then
                CheckPiso6.Checked = True
                MsgBox("Imposible desactivar piso ya que esta posicion se encuentra ocupada", MsgBoxStyle.Information, "Aviso")

                Exit Sub

            End If





        End If

        If CheckPiso6.Checked = False Then
            Dim SqlElimina As String = "UPDATE CamaraMantenedor SET estado = '1' WHERE cordenada='" + w.COR + "' and camara = '" + w.codigocamara + "' and piso='06' "
            fnc.MovimientoSQL(SqlElimina)
            CheckPiso6.Checked = False
            GroupBoxpiso6.Enabled = False

        End If

        If CheckPiso6.Checked = True Then
            Dim SqlElimina As String = "UPDATE CamaraMantenedor SET estado = '0' WHERE cordenada='" + w.COR + "' and camara = '" + w.codigocamara + "' and piso='06' "
            fnc.MovimientoSQL(SqlElimina)
            CheckPiso6.Checked = True
            GroupBoxpiso6.Enabled = True

        End If
    End Sub

    Private Sub CheckPiso5_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckPiso5.CheckedChanged
        If ACheckPiso5.Checked = False And CheckPiso5.Checked = False Then
            CheckPiso5.Checked = True
            GroupBoxpiso5.Enabled = False
            MsgBox("Imposible desactivar piso que ya tiene un bloqueo", MsgBoxStyle.Information, "Aviso")

            Exit Sub


        End If

     

        Dim sql4 As String = "SELECT * FROM RACKDETA WHERE  racd_ca = '" + w.codigocamara + "' and racd_pi='5' and racd_ba = '" + w.bandapublic + "' and racd_co='" + w.columnapublic + "'"
        Dim tabla As DataTable = fnc.ListarTablasSQL(sql4)



        If tabla.Rows.Count > 0 Then

            If CheckPiso5.Checked = False Then
                CheckPiso5.Checked = True
                MsgBox("Imposible desactivar piso ya que esta posicion se encuentra ocupada", MsgBoxStyle.Information, "Aviso")

                Exit Sub

            End If

        



        End If

        If CheckPiso5.Checked = False Then
            Dim SqlElimina As String = "UPDATE CamaraMantenedor SET estado = '1' WHERE cordenada='" + w.COR + "' and camara = '" + w.codigocamara + "' and piso='05' "
            fnc.MovimientoSQL(SqlElimina)
            CheckPiso5.Checked = False
            GroupBoxpiso5.Enabled = False

        End If

        If CheckPiso5.Checked = True Then
            Dim SqlElimina As String = "UPDATE CamaraMantenedor SET estado = '0' WHERE cordenada='" + w.COR + "' and camara = '" + w.codigocamara + "' and piso='05' "
            fnc.MovimientoSQL(SqlElimina)
            CheckPiso5.Checked = True
            GroupBoxpiso5.Enabled = True

        End If
    End Sub

    Private Sub CheckPiso4_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckPiso4.CheckedChanged

        If ACheckPiso4.Checked = False And CheckPiso4.Checked = False Then
            CheckPiso4.Checked = True
            GroupBoxpiso4.Enabled = False
            MsgBox("Imposible desactivar piso que ya tiene un bloqueo", MsgBoxStyle.Information, "Aviso")

            Exit Sub


        End If

        Dim sql4 As String = "SELECT * FROM RACKDETA WHERE  racd_ca = '" + w.codigocamara + "' and racd_pi='4' and racd_ba = '" + w.bandapublic + "' and racd_co='" + w.columnapublic + "'"
        Dim tabla As DataTable = fnc.ListarTablasSQL(sql4)




        If tabla.Rows.Count > 0 Then

            If CheckPiso4.Checked = False Then
                CheckPiso4.Checked = True
                MsgBox("Imposible desactivar piso ya que esta posicion se encuentra ocupada", MsgBoxStyle.Information, "Aviso")

                Exit Sub

            End If





        End If

        If CheckPiso4.Checked = False Then
            Dim SqlElimina As String = "UPDATE CamaraMantenedor SET estado = '1' WHERE cordenada='" + w.COR + "' and camara = '" + w.codigocamara + "' and piso='04' "
            fnc.MovimientoSQL(SqlElimina)
            CheckPiso4.Checked = False
            GroupBoxpiso4.Enabled = False

        End If

        If CheckPiso4.Checked = True Then
            Dim SqlElimina As String = "UPDATE CamaraMantenedor SET estado = '0' WHERE cordenada='" + w.COR + "' and camara = '" + w.codigocamara + "' and piso='04' "
            fnc.MovimientoSQL(SqlElimina)
            CheckPiso4.Checked = True
            GroupBoxpiso4.Enabled = True

        End If
    End Sub

    Private Sub CheckPiso3_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckPiso3.CheckedChanged
        If ACheckPiso3.Checked = False And CheckPiso3.Checked = False Then
            CheckPiso3.Checked = True
            GroupBoxpiso3.Enabled = False
            MsgBox("Imposible desactivar piso que ya tiene un bloqueo", MsgBoxStyle.Information, "Aviso")

            Exit Sub


        End If


        Dim sql4 As String = "SELECT * FROM RACKDETA WHERE  racd_ca = '" + w.codigocamara + "' and racd_pi='3' and racd_ba = '" + w.bandapublic + "' and racd_co='" + w.columnapublic + "'"
        Dim tabla As DataTable = fnc.ListarTablasSQL(sql4)




        If tabla.Rows.Count > 0 Then

            If CheckPiso3.Checked = False Then
                CheckPiso3.Checked = True
                MsgBox("Imposible desactivar piso ya que esta posicion se encuentra ocupada", MsgBoxStyle.Information, "Aviso")

                Exit Sub

            End If





        End If

        If CheckPiso3.Checked = False Then
            Dim SqlElimina As String = "UPDATE CamaraMantenedor SET estado = '1' WHERE cordenada='" + w.COR + "' and camara = '" + w.codigocamara + "' and piso='03' "
            fnc.MovimientoSQL(SqlElimina)
            CheckPiso3.Checked = False
            GroupBoxpiso3.Enabled = False

        End If

        If CheckPiso3.Checked = True Then
            Dim SqlElimina As String = "UPDATE CamaraMantenedor SET estado = '0' WHERE cordenada='" + w.COR + "' and camara = '" + w.codigocamara + "' and piso='03' "
            fnc.MovimientoSQL(SqlElimina)
            CheckPiso3.Checked = True
            GroupBoxpiso3.Enabled = True

        End If
    End Sub

    Private Sub CheckPiso2_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckPiso2.CheckedChanged

        If ACheckPiso2.Checked = False And CheckPiso2.Checked = False Then
            CheckPiso2.Checked = True
            GroupBoxpiso2.Enabled = False
            MsgBox("Imposible desactivar piso que ya tiene un bloqueo", MsgBoxStyle.Information, "Aviso")

            Exit Sub


        End If

        Dim sql4 As String = "SELECT * FROM RACKDETA WHERE  racd_ca = '" + w.codigocamara + "' and racd_pi='2' and racd_ba = '" + w.bandapublic + "' and racd_co='" + w.columnapublic + "'"
        Dim tabla As DataTable = fnc.ListarTablasSQL(sql4)


        If tabla.Rows.Count > 0 Then

            If CheckPiso2.Checked = False Then
                CheckPiso2.Checked = True
                MsgBox("Imposible desactivar piso ya que esta posicion se encuentra ocupada", MsgBoxStyle.Information, "Aviso")

                Exit Sub

            End If





        End If

        If CheckPiso2.Checked = False Then
            Dim SqlElimina As String = "UPDATE CamaraMantenedor SET estado = '1' WHERE cordenada='" + w.COR + "' and camara = '" + w.codigocamara + "' and piso='02' "
            fnc.MovimientoSQL(SqlElimina)
            CheckPiso2.Checked = False
            GroupBoxpiso2.Enabled = False

        End If

        If CheckPiso2.Checked = True Then
            Dim SqlElimina As String = "UPDATE CamaraMantenedor SET estado = '0' WHERE cordenada='" + w.COR + "' and camara = '" + w.codigocamara + "' and piso='02' "
            fnc.MovimientoSQL(SqlElimina)
            CheckPiso2.Checked = True
            GroupBoxpiso2.Enabled = True

        End If
    End Sub

    Private Sub BtnOrigen_Click(sender As System.Object, e As System.EventArgs) Handles BtnOrigen.Click
        Dim strr As String = "1"
        Frm_MuestraPallet.PS = "1"
        valorpiso = 1

        posicioncreada = strr
        Dim frm As Frm_MuestraPallet = New Frm_MuestraPallet
        frm.ShowDialog()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        posicioncreada = "2"
        valorpiso = 2
        Frm_MuestraPallet.PS = "2"
        Dim frm As Frm_MuestraPallet = New Frm_MuestraPallet
        frm.ShowDialog()
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        posicioncreada = "3"
        valorpiso = 3
        Frm_MuestraPallet.PS = "3"
        Dim frm As Frm_MuestraPallet = New Frm_MuestraPallet
        frm.ShowDialog()
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        posicioncreada = "4"
        valorpiso = 4
        Frm_MuestraPallet.PS = "4"
        Dim frm As Frm_MuestraPallet = New Frm_MuestraPallet
        frm.ShowDialog()
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        posicioncreada = "5"
        valorpiso = 5
        Frm_MuestraPallet.PS = "5"
        Dim frm As Frm_MuestraPallet = New Frm_MuestraPallet
        frm.ShowDialog()
    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        posicioncreada = "6"
        valorpiso = 6
        Frm_MuestraPallet.PS = "6"
        Dim frm As Frm_MuestraPallet = New Frm_MuestraPallet
        frm.ShowDialog()
    End Sub

    Private Sub Button6_Click(sender As System.Object, e As System.EventArgs) Handles Button6.Click
        Dim strr As String = "1"

        posicioncreada = "7"
        valorpiso = 7

        Frm_MuestraPallet.PS = "7"
        Dim frm As Frm_MuestraPallet = New Frm_MuestraPallet
        frm.ShowDialog()
    End Sub

    Private Sub ACheckPiso5_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ACheckPiso5.CheckedChanged


        If CheckPiso5.Checked = False And ACheckPiso5.Checked = False Then
            ACheckPiso5.Checked = True
            GroupBoxpiso5.Enabled = False
            MsgBox("Imposible desactivar piso que ya tiene un bloqueo", MsgBoxStyle.Information, "Aviso")

            Exit Sub


        End If


        Dim sql4 As String = "SELECT * FROM RACKDETA WHERE  racd_ca = '" + w.codigocamara + "' and racd_pi='5' and racd_ba = '" + w.bandapublic + "' and racd_co='" + w.columnapublic + "'"
        Dim tabla As DataTable = fnc.ListarTablasSQL(sql4)



        If tabla.Rows.Count > 0 Then

            If ACheckPiso5.Checked = False Then
                ACheckPiso5.Checked = True
                MsgBox("Imposible desactivar piso ya que esta posicion se encuentra ocupada", MsgBoxStyle.Information, "Aviso")

                Exit Sub

            End If





        End If

        If ACheckPiso5.Checked = False Then
            Dim SqlElimina As String = "UPDATE CamaraMantenedor SET Aestado = '1' WHERE cordenada='" + w.COR + "' and camara = '" + w.codigocamara + "' and piso='05' "
            fnc.MovimientoSQL(SqlElimina)
            ACheckPiso5.Checked = False
            GroupBoxpiso5.Enabled = False

        End If

        If ACheckPiso5.Checked = True Then
            Dim SqlElimina As String = "UPDATE CamaraMantenedor SET Aestado = '0' WHERE cordenada='" + w.COR + "' and camara = '" + w.codigocamara + "' and piso='05' "
            fnc.MovimientoSQL(SqlElimina)
            ACheckPiso5.Checked = True
            GroupBoxpiso5.Enabled = True

        End If
    End Sub

    Private Sub ACheckPiso4_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ACheckPiso4.CheckedChanged

        If CheckPiso4.Checked = False And ACheckPiso4.Checked = False Then
            ACheckPiso4.Checked = True
            GroupBoxpiso4.Enabled = False
            MsgBox("Imposible desactivar piso que ya tiene un bloqueo", MsgBoxStyle.Information, "Aviso")

            Exit Sub


        End If



        Dim sql4 As String = "SELECT * FROM RACKDETA WHERE  racd_ca = '" + w.codigocamara + "' and racd_pi='4' and racd_ba = '" + w.bandapublic + "' and racd_co='" + w.columnapublic + "'"
        Dim tabla As DataTable = fnc.ListarTablasSQL(sql4)




        If tabla.Rows.Count > 0 Then

            If ACheckPiso4.Checked = False Then
                ACheckPiso4.Checked = True
                MsgBox("Imposible desactivar piso ya que esta posicion se encuentra ocupada", MsgBoxStyle.Information, "Aviso")

                Exit Sub

            End If





        End If

        If ACheckPiso4.Checked = False Then
            Dim SqlElimina As String = "UPDATE CamaraMantenedor SET Aestado = '1' WHERE cordenada='" + w.COR + "' and camara = '" + w.codigocamara + "' and piso='04' "
            fnc.MovimientoSQL(SqlElimina)
            ACheckPiso4.Checked = False
            GroupBoxpiso4.Enabled = False

        End If

        If ACheckPiso4.Checked = True Then
            Dim SqlElimina As String = "UPDATE CamaraMantenedor SET Aestado = '0' WHERE cordenada='" + w.COR + "' and camara = '" + w.codigocamara + "' and piso='04' "
            fnc.MovimientoSQL(SqlElimina)
            ACheckPiso4.Checked = True
            GroupBoxpiso4.Enabled = True

        End If
    End Sub

    Private Sub ACheckPiso3_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ACheckPiso3.CheckedChanged


        If CheckPiso3.Checked = False And ACheckPiso3.Checked = False Then
            ACheckPiso3.Checked = True
            GroupBoxpiso3.Enabled = False
            MsgBox("Imposible desactivar piso que ya tiene un bloqueo", MsgBoxStyle.Information, "Aviso")

            Exit Sub


        End If


        Dim sql4 As String = "SELECT * FROM RACKDETA WHERE  racd_ca = '" + w.codigocamara + "' and racd_pi='3' and racd_ba = '" + w.bandapublic + "' and racd_co='" + w.columnapublic + "'"
        Dim tabla As DataTable = fnc.ListarTablasSQL(sql4)




        If tabla.Rows.Count > 0 Then

            If ACheckPiso3.Checked = False Then
                ACheckPiso1.Checked = True
                MsgBox("Imposible desactivar piso ya que esta posicion se encuentra ocupada", MsgBoxStyle.Information, "Aviso")

                Exit Sub

            End If





        End If

        If ACheckPiso3.Checked = False Then
            Dim SqlElimina As String = "UPDATE CamaraMantenedor SET Aestado = '1' WHERE cordenada='" + w.COR + "' and camara = '" + w.codigocamara + "' and piso='03' "
            fnc.MovimientoSQL(SqlElimina)
            ACheckPiso3.Checked = False
            GroupBoxpiso3.Enabled = False

        End If

        If ACheckPiso3.Checked = True Then
            Dim SqlElimina As String = "UPDATE CamaraMantenedor SET Aestado = '0' WHERE cordenada='" + w.COR + "' and camara = '" + w.codigocamara + "' and piso='03' "
            fnc.MovimientoSQL(SqlElimina)
            ACheckPiso3.Checked = True
            GroupBoxpiso3.Enabled = True

        End If
    End Sub

    Private Sub ACheckPiso2_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ACheckPiso2.CheckedChanged

        If CheckPiso2.Checked = False And ACheckPiso2.Checked = False Then
            ACheckPiso2.Checked = True
            GroupBoxpiso2.Enabled = False
            MsgBox("Imposible desactivar piso que ya tiene un bloqueo", MsgBoxStyle.Information, "Aviso")

            Exit Sub


        End If



        Dim sql4 As String = "SELECT * FROM RACKDETA WHERE  racd_ca = '" + w.codigocamara + "' and racd_pi='2' and racd_ba = '" + w.bandapublic + "' and racd_co='" + w.columnapublic + "'"
        Dim tabla As DataTable = fnc.ListarTablasSQL(sql4)


        If tabla.Rows.Count > 0 Then

            If ACheckPiso2.Checked = False Then
                ACheckPiso2.Checked = True
                MsgBox("Imposible desactivar piso ya que esta posicion se encuentra ocupada", MsgBoxStyle.Information, "Aviso")

                Exit Sub

            End If





        End If

        If ACheckPiso2.Checked = False Then
            Dim SqlElimina As String = "UPDATE CamaraMantenedor SET Aestado = '1' WHERE cordenada='" + w.COR + "' and camara = '" + w.codigocamara + "' and piso='02' "
            fnc.MovimientoSQL(SqlElimina)
            ACheckPiso2.Checked = False
            GroupBoxpiso2.Enabled = False

        End If

        If ACheckPiso2.Checked = True Then
            Dim SqlElimina As String = "UPDATE CamaraMantenedor SET Aestado = '0' WHERE cordenada='" + w.COR + "' and camara = '" + w.codigocamara + "' and piso='02' "
            fnc.MovimientoSQL(SqlElimina)
            ACheckPiso2.Checked = True
            GroupBoxpiso2.Enabled = True

        End If
    End Sub

    Private Sub ACheckPiso1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ACheckPiso1.CheckedChanged

        If CheckPiso1.Checked = False And ACheckPiso1.Checked = False Then
            ACheckPiso1.Checked = True
            GroupBoxpiso1.Enabled = False
            MsgBox("Imposible desactivar piso que ya tiene un bloqueo", MsgBoxStyle.Information, "Aviso")

            Exit Sub


        End If


        Dim sql4 As String = "SELECT * FROM RACKDETA WHERE  racd_ca = '" + w.codigocamara + "' and racd_pi='1' and racd_ba = '" + w.bandapublic + "' and racd_co='" + w.columnapublic + "'"
        Dim tabla As DataTable = fnc.ListarTablasSQL(sql4)


        If tabla.Rows.Count > 0 Then

            If ACheckPiso1.Checked = False Then
                ACheckPiso1.Checked = True
                MsgBox("Imposible desactivar piso ya que esta posicion se encuentra ocupada", MsgBoxStyle.Information, "Aviso")

                Exit Sub

            End If





        End If

        If ACheckPiso1.Checked = False Then
            Dim SqlElimina As String = "UPDATE CamaraMantenedor SET Aestado = '1' WHERE cordenada='" + w.COR + "' and camara = '" + w.codigocamara + "' and piso='01' "
            fnc.MovimientoSQL(SqlElimina)
            ACheckPiso1.Checked = False
            GroupBoxpiso1.Enabled = False

        End If

        If ACheckPiso1.Checked = True Then
            Dim SqlElimina As String = "UPDATE CamaraMantenedor SET Aestado = '0' WHERE cordenada='" + w.COR + "' and camara = '" + w.codigocamara + "' and piso='01' "
            fnc.MovimientoSQL(SqlElimina)
            ACheckPiso1.Checked = True
            GroupBoxpiso1.Enabled = True

        End If
    End Sub

    Private Sub ACheckPiso7_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ACheckPiso7.CheckedChanged

        If CheckPiso7.Checked = False And ACheckPiso7.Checked = False Then
            ACheckPiso7.Checked = True
            GroupBoxpiso7.Enabled = False
            MsgBox("Imposible desactivar piso que ya tiene un bloqueo", MsgBoxStyle.Information, "Aviso")

            Exit Sub


        End If


        Dim sql4 As String = "SELECT * FROM RACKDETA WHERE  racd_ca = '" + w.codigocamara + "' and racd_pi='7' and racd_ba = '" + w.bandapublic + "' and racd_co='" + w.columnapublic + "'"
        Dim tabla As DataTable = fnc.ListarTablasSQL(sql4)



        If tabla.Rows.Count > 0 Then

            If ACheckPiso7.Checked = False Then
                ACheckPiso7.Checked = True
                MsgBox("Imposible desactivar piso ya que esta posicion se encuentra ocupada", MsgBoxStyle.Information, "Aviso")

                Exit Sub

            End If





        End If

        If ACheckPiso7.Checked = False Then
            Dim SqlElimina As String = "UPDATE CamaraMantenedor SET Aestado = '1' WHERE cordenada='" + w.COR + "' and camara = '" + w.codigocamara + "' and piso='07' "
            fnc.MovimientoSQL(SqlElimina)
            ACheckPiso7.Checked = False
            GroupBoxpiso7.Enabled = False

        End If

        If ACheckPiso7.Checked = True Then
            Dim SqlElimina As String = "UPDATE CamaraMantenedor SET Aestado = '0' WHERE cordenada='" + w.COR + "' and camara = '" + w.codigocamara + "' and piso='07' "
            fnc.MovimientoSQL(SqlElimina)
            ACheckPiso7.Checked = True
            GroupBoxpiso7.Enabled = True

        End If
    End Sub

    Private Sub ACheckPiso6_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ACheckPiso6.CheckedChanged


        If CheckPiso6.Checked = False And ACheckPiso6.Checked = False Then
            ACheckPiso6.Checked = True
            GroupBoxpiso6.Enabled = False
            MsgBox("Imposible desactivar piso que ya tiene un bloqueo", MsgBoxStyle.Information, "Aviso")

            Exit Sub


        End If


        Dim sql4 As String = "SELECT * FROM RACKDETA WHERE  racd_ca = '" + w.codigocamara + "' and racd_pi='6' and racd_ba = '" + w.bandapublic + "' and racd_co='" + w.columnapublic + "'"
        Dim tabla As DataTable = fnc.ListarTablasSQL(sql4)


        If tabla.Rows.Count > 0 Then

            If ACheckPiso6.Checked = False Then
                ACheckPiso6.Checked = True
                MsgBox("Imposible desactivar piso ya que esta posicion se encuentra ocupada", MsgBoxStyle.Information, "Aviso")

                Exit Sub

            End If





        End If

        If ACheckPiso6.Checked = False Then
            Dim SqlElimina As String = "UPDATE CamaraMantenedor SET Aestado = '1' WHERE cordenada='" + w.COR + "' and camara = '" + w.codigocamara + "' and piso='06' "
            fnc.MovimientoSQL(SqlElimina)
            ACheckPiso6.Checked = False
            GroupBoxpiso6.Enabled = False

        End If

        If ACheckPiso6.Checked = True Then
            Dim SqlElimina As String = "UPDATE CamaraMantenedor SET Aestado = '0' WHERE cordenada='" + w.COR + "' and camara = '" + w.codigocamara + "' and piso='06' "
            fnc.MovimientoSQL(SqlElimina)
            ACheckPiso6.Checked = True
            GroupBoxpiso6.Enabled = True

        End If
    End Sub
End Class
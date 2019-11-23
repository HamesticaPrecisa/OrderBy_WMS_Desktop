'
'   VES OCT 2019
'
'   ESTE FORM PERMITE CREAR O MODIFICAR REGLAS
'   PARA EL CALCULO DEL FACTOR DE CONGELAMIENTO
'   EN TUNELES
'
Imports System.Data.SqlClient

Public Class frm_ReglaFCT

    Dim fnc As New Funciones()

    Public regla As DataRow = Nothing
    Private familias As DataTable

    Private Sub frm_ReglaFCT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Text = If(regla Is Nothing, "Nueva regla", "Modificar regla")

        '
        '   CARGAMOS LA LISTA DE FAMILIAS DEFINIDAS
        '   INCLUYENDO UNA PRIMERA OPCION DE "CUALQUIERA"
        '
        Dim sql As String = "SELECT 0 AS orden, '0000000' AS fam_codi, NEWID() AS fam_unica, CAST('(CUALQUIERA)' AS NVARCHAR(40)) AS fam_descr" +
                            " UNION " +
                            "SELECT 1 AS orden, fam_codi, fam_unica, fam_descr " +
                            "  FROM famprod " +
                            " ORDER BY fam_descr"
        familias = fnc.ListarTablasSQL(sql)
        cboFamProd.DataSource = familias
        cboFamProd.DisplayMember = "fam_descr"
        cboFamProd.ValueMember = "fam_unica"
        cboFamProd.SelectedIndex = 0


        '
        '   SI ESTAMOS EDITANDO UNA REGLA, SE CARGAN LOS VALORES
        '   ACTUALES EN EL FORM
        '
        If regla IsNot Nothing Then
            Dim famprod As Object = regla("fam_unica")
            If famprod IsNot Nothing Then
                cboFamProd.SelectedValue = famprod
            End If
            TxtClirut.Text = regla("cli_rut").ToString.Trim()
            validarCliente(TxtClirut.Text)

            If CInt(regla("fct_tmpini")) = 0 Then
                rbtFijo.Checked = True
                txtHorasF.Text = regla("fct_horas").ToString().Trim()
            Else
                rbtDinamico.Checked = True
                txtTmpIni.Text = regla("fct_tmpini").ToString().Trim()
                txttmpFin.Text = regla("fct_tmpfin").ToString().Trim()
                txtHorasD.Text = regla("fct_horas").ToString().Trim()
                txtKilos.Text = regla("fct_kilos").ToString().Trim()
                txtHorasF.Enabled = False
            End If


            cboFamProd.Enabled = False
            TxtClirut.Enabled = False
            btn_BuscaCliente.Enabled = False
        End If

    End Sub


    Private Function validarCliente(ByVal rut As String) As Boolean
        Dim row As DataRow = fnc.sqlExecuteRow("SELECT cli_nomb FROM clientes WHERE cli_rut = @p0", TxtClirut.Text().Trim())
        Dim ok As Boolean = False
        If row IsNot Nothing Then
            txtclinom.Text = row("cli_nomb").ToString()
            ok = True
        Else
            txtclinom.Text = ""
        End If
        Return ok
    End Function

    Private Sub btn_BuscaCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_BuscaCliente.Click
        Dim frm As New Lst_AyudaClientes
        frm.ShowDialog(Frm_Principal)
        TxtClirut.Text = Frm_Principal.buscavalor
        TxtClirut.Focus()
        SendKeys.Send(Chr(Keys.Enter))
    End Sub

    Private Sub txtTmpIni_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTmpIni.KeyPress
        soloTemperatura(sender, e)
    End Sub

    Private Sub txttmpFin_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttmpFin.KeyPress
        soloTemperatura(sender, e)
    End Sub

    Private Sub txtHoras_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHorasD.KeyPress
        SoloNumeros(sender, e)
    End Sub

    Private Sub txtKilos_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtKilos.KeyPress
        SoloNumeros(sender, e)
    End Sub

    Private Function Valida() As Boolean

        '
        '   VALIDAMOS LOS CAMPOS OBLIGATORIOS
        '
        Dim falta As Control = Nothing
        If cboFamProd.SelectedIndex = 0 And IsEmpty(TxtClirut) And TxtClirut.Enabled Then
            falta = TxtClirut
        ElseIf rbtDinamico.Checked = True And IsEmpty(txtTmpIni) Then
            falta = txtTmpIni
        ElseIf rbtDinamico.Checked = True And IsEmpty(txttmpFin) Then
            falta = txttmpFin
        ElseIf rbtDinamico.Checked = True And IsEmpty(txtHorasD) Or IsEmpty(CInt("0" + txtHorasD.Text)) Then
            falta = txtHorasD
        ElseIf rbtDinamico.Checked = True And IsEmpty(txtKilos) Or IsEmpty(CInt("0" + txtKilos.Text)) Then
            falta = txtKilos
        ElseIf rbtFijo.Checked = True And (IsEmpty(txtHorasF) Or IsEmpty(CInt("0" + txtHorasF.Text))) Then
            falta = txtHorasF
        End If
        If falta IsNot Nothing Then
            MsgBox("Faltan valores obligatorios:" + falta.Name, MsgBoxStyle.Exclamation, "Aviso")
            falta.Focus()
            Return False
        End If


        '
        '   VERIFICAMOS LA INTEGRIDAD DE LOS DATOS
        '   INTRODUCIDOS
        '
        If rbtDinamico.Checked = True And CInt(txttmpFin.Text) > CInt(txtTmpIni.Text) Then
            MsgBox("La temperatura final debe ser menor que la inicial", MsgBoxStyle.Exclamation, "Aviso")
            txttmpFin.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub grabarSalir()
        If Valida() = False Then Return
        If Confirmar("Desea grabar los cambios realizados?", Text) = False Then Return


        Dim fct_id As Integer = If(regla Is Nothing, 0, CInt(regla("fct_id").ToString()))

        '
        '   SI ESTAMOS CREANDO UNA NUEVA REGLA, VERIFICAMOS SI
        '   YA EXISTE UNA REGLA PARA LA FAMILIA Y CLIENTE 
        '   INDICADOS. SI ES ASI, SE SOBREESCRIBE ESA REGLA EN 
        '   LUGAR DE CREAR UNA NUEVA
        '
        Dim famprod As Object = If(cboFamProd.SelectedIndex > 0, cboFamProd.SelectedValue, System.DBNull.Value)
        Dim clirut As Object = If(IsEmpty(txtclinom), System.DBNull.Value, TxtClirut.Text)
        Dim nivel As Integer = 1
        If clirut IsNot System.DBNull.Value Then nivel = nivel + 1
        If famprod IsNot System.DBNull.Value Then nivel = nivel + 1

        If fct_id = 0 Then
            Dim row As DataRow = fnc.sqlExecuteRow("SELECT fct_id FROM cnffct WHERE fam_unica = @fam_unica AND cli_rut = @cli_rut AND fct_status = 'ACTIVA'",
                                                   New SqlParameter() {
                                                       New SqlParameter("@fam_unica", SqlDbType.UniqueIdentifier) With {.Value = famprod},
                                                       New SqlParameter("@cli_rut", clirut)
                                                   })
            If row IsNot Nothing Then fct_id = CInt(row("fct_id").ToString())
        End If

        Dim sql As String = "INSERT INTO cnffct (fct_nivel, fam_unica, cli_rut, fct_tmpini, fct_tmpfin, fct_horas, fct_kilos, fct_ultact, fct_usucod) " +
                            "      VALUES (@fct_nivel, @fam_unica, @cli_rut, @fct_tmpini, @fct_tmpfin, @fct_horas, @fct_kilos, GETDATE(), @fct_usucod) "
        If fct_id > 0 Then
            sql = "UPDATE cnffct " +
                  "   SET fct_tmpini = @fct_tmpini," +
                  "       fct_tmpfin = @fct_tmpfin," +
                  "       fct_horas = @fct_horas," +
                  "       fct_kilos = @fct_kilos," +
                  "       fct_nivel = @fct_nivel," +
                  "       fct_ultact = GETDATE()," +
                  "       fct_usucod = @fct_usucod " +
                  " WHERE fct_id = @fct_id"
        End If

        Dim result As sqlCmdResult
        Dim tmpini As Integer = IIf(rbtDinamico.Checked = True, CInt(txtTmpIni.Text), 0)
        Dim tmpfin As Integer = IIf(rbtDinamico.Checked = True, CInt(txttmpFin.Text), 0)
        Dim horas As Integer = IIf(rbtDinamico.Checked = True, CInt("0" + txtHorasD.Text), CInt("0" + txtHorasF.Text))
        Dim kilos As Integer = IIf(rbtDinamico.Checked = True, CInt("0" + txtKilos.Text), 0)

        result = fnc.runSQLCmd(sql, New SqlParameter() {
                                    New SqlParameter("@fam_unica", SqlDbType.UniqueIdentifier) With {.Value = famprod},
                                    New SqlParameter("@cli_rut", clirut),
                                    New SqlParameter("@fct_tmpini", tmpini),
                                    New SqlParameter("@fct_tmpfin", tmpfin),
                                    New SqlParameter("@fct_horas", horas),
                                    New SqlParameter("@fct_kilos", kilos),
                                    New SqlParameter("@fct_nivel", nivel),
                                    New SqlParameter("@fct_usucod", Frm_Principal.InfoUsuario.Text),
                                    New SqlParameter("@fct_id", fct_id)
                               })
        If result.result = False Then
            MsgBox(result.errorMsg, MsgBoxStyle.Critical, "Cuidado")
            Return
        End If

        Me.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        grabarSalir()
    End Sub

    Private Sub TxtClirut_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtClirut.Validating
        If IsEmpty(TxtClirut) = True Then
            txtclinom.Text = ""
            e.Cancel = False
        ElseIf validarCliente(TxtClirut.Text.Trim()) = False Then
            e.Cancel = True
        End If
    End Sub

    Private Sub TxtClirut_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtClirut.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            If validarCliente(TxtClirut.Text.Trim()) = True Then
                txtTmpIni.Focus()
            Else
                e.Handled = True
            End If
        Else
            SoloNumeros(sender, e)
        End If
    End Sub



    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click

    End Sub


    Private Sub rbtFijo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtFijo.CheckedChanged
        If rbtFijo.Checked = True Then
            txtHorasF.Enabled = True
            txtHorasF.Focus()
        Else
            txtHorasF.Enabled = False
        End If
    End Sub

    Private Sub rbtDinamico_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtDinamico.CheckedChanged
        If rbtDinamico.Checked = True Then
            txtTmpIni.Enabled = True
            txttmpFin.Enabled = True
            txtHorasD.Enabled = True
            txtKilos.Enabled = True
            txtHorasD.Focus()
        Else
            txtTmpIni.Enabled = False
            txttmpFin.Enabled = False
            txtHorasD.Enabled = False
            txtKilos.Enabled = False
        End If
    End Sub
End Class
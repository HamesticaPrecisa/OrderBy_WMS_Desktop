'
'   VES NOV 2019
'
'   ESTE FORM PERMITE CREAR O MODIFICAR REGLAS
'   PARA EL RECARGO POR RECEPCION TARDIA EN 
'   TUNELES
'
Imports System.Data.SqlClient

Public Class frm_ReglaRCT

    Dim fnc As New Funciones()

    Public regla As DataRow = Nothing

    Private Sub frm_ReclaRCT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Text = If(regla Is Nothing, "Nuevo recargo", "Modificar recargo")


        '
        '   SI ESTAMOS EDITANDO UNA REGLA, SE CARGAN LOS VALORES
        '   ACTUALES EN EL FORM
        '
        If regla IsNot Nothing Then
            txtDesde.Text = regla("rct_desde").ToString().Trim()
            txtHasta.Text = regla("rct_hasta").ToString().Trim()
            txtFactor.Text = regla("rct_factor").ToString().Trim()
        End If


    End Sub



    Private Function Valida() As Boolean

        '
        '   VALIDAMOS LOS CAMPOS OBLIGATORIOS
        '
        Dim falta As Control = Nothing
        If IsEmpty(txtDesde) Then
            falta = txtDesde
        ElseIf IsEmpty(txtHasta) Then
            falta = txtHasta
        ElseIf IsEmpty(txtFactor) Then
            falta = txtFactor
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
        If CInt(txtDesde.Text) > CInt(txtHasta.Text) Then
            MsgBox("El rango de horas es incorrecto", MsgBoxStyle.Exclamation, "Aviso")
            txtDesde.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub grabarSalir()
        If Valida() = False Then Return
        If Confirmar("Desea grabar los cambios realizados?", Text) = False Then Return


        Dim rct_id As Integer = If(regla Is Nothing, 0, CInt(regla("rct_id").ToString()))

    

        Dim sql As String = "INSERT INTO cnfrct (rct_desde, rct_hasta, rct_factor, rct_ultact, rct_usucod) " +
                            "      VALUES (@desde, @hasta, @factor, GETDATE(), @rct_usucod) "
        If rct_id > 0 Then
            sql = "UPDATE cnfrct " +
                  "   SET rct_desde = @desde," +
                  "       rct_hasta = @hasta," +
                  "       rct_factor = @factor," +
                  "       rct_ultact = GETDATE()," +
                  "       rct_usucod = @rct_usucod " +
                  " WHERE rct_id = @rct_id"
        End If

        Dim result As sqlCmdResult
        result = fnc.runSQLCmd(sql, New SqlParameter() {
                                    New SqlParameter("@desde", CInt(txtDesde.Text)),
                                    New SqlParameter("@hasta", CInt(txtHasta.Text)),
                                    New SqlParameter("@factor", CDec(txtFactor.Text)),
                                    New SqlParameter("@rct_usucod", Frm_Principal.InfoUsuario.Text),
                                    New SqlParameter("@rct_id", rct_id)
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


    Private Sub txtDesde_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDesde.KeyPress
        SoloNumeros(sender, e)
    End Sub

    Private Sub txtHasta_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHasta.KeyPress
        SoloNumeros(sender, e)
    End Sub

    Private Sub txtFactor_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFactor.KeyPress
        SoloNumeros(sender, e, True)
    End Sub

    Private Sub txtFactor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFactor.TextChanged

    End Sub
End Class
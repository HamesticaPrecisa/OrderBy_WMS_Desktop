Public Class FrmAddReglas
    Dim fnc As New Funciones
    Private Sub Label1_Click(sender As System.Object, e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub FrmAddReglas_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim sql2 As String = "Select f1 as FAMILIA1,F2 as FAMILIA2,fecha_bloq AS FECHA FROM maereglas"
        Dim tabla As DataTable = fnc.ListarTablasSQL(sql2)
        DgvResultado.DataSource = tabla

        CboFamilia1.DataSource = fnc.ListarTablasSQL("SELECT fam_codi, fam_descr FROM famprod ORDER BY fam_codi ASC")
        CboFamilia1.ValueMember = "fam_codi"
        CboFamilia1.DisplayMember = "fam_descr"
        CboFamilia2.DataSource = fnc.ListarTablasSQL("SELECT fam_codi, fam_descr FROM famprod ORDER BY fam_codi ASC")
        CboFamilia2.ValueMember = "fam_codi"
        CboFamilia2.DisplayMember = "fam_descr"

    End Sub

    Private Sub FrmAddReglas_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        f_reglas = False
    End Sub

    Private Sub Btn_GuardaDetalle_Click(sender As System.Object, e As System.EventArgs) Handles Btn_GuardaDetalle.Click
        If CboFamilia1.Text = CboFamilia2.Text Then


        Else
            Dim fecha As String = DateTime.Now.ToString("dd/MM/yyyy")
            Dim sql = "INSERT INTO maereglas(f1, f2, fecha_bloq, usr_bloq)VALUES " +
                                            "('" + CboFamilia1.Text.Trim() + "','" + CboFamilia2.Text.Trim() + "','" + devuelve_fecha(DateTime.Now).ToString() + "','" + Frm_Principal.InfoUsuario.Text + "')"

            If fnc.MovimientoSQL(sql) > 0 Then
                MsgBox("Regla agregada correctamente", MsgBoxStyle.Information, "Aviso")

                Dim sql2 As String = "Select f1 as FAMILIA1,F2 as FAMILIA2,fecha_bloq AS FECHA FROM maereglas"
                Dim tabla As DataTable = fnc.ListarTablasSQL(sql2)
                DgvResultado.DataSource = tabla
            Else
                'MsgBox("POSICION DISPONIBLE", MsgBoxStyle.Critical, "Aviso")
            End If
        End If
      
    End Sub

    Private Sub DgvResultado_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvResultado.CellDoubleClick
        Dim SqlDeta As String = "DELETE FROM maereglas WHERE f1='" + Me.DgvResultado.Rows(e.RowIndex).Cells(0).Value.ToString() + "' and f2='" + Me.DgvResultado.Rows(e.RowIndex).Cells(1).Value.ToString() + "' "
        fnc.MovimientoSQL(SqlDeta)
        Dim sql2 As String = "Select f1 as FAMILIA1,F2 as FAMILIA2,fecha_bloq AS FECHA FROM maereglas"
        Dim tabla As DataTable = fnc.ListarTablasSQL(sql2)
        DgvResultado.DataSource = tabla
    End Sub

    Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox1.TextChanged
        Dim sql2 As String = "Select f1 as FAMILIA1,F2 as FAMILIA2,fecha_bloq AS FECHA FROM maereglas where f1  like'" + TextBox1.Text.Trim() + "%'"
        Dim tabla As DataTable = fnc.ListarTablasSQL(sql2)
        DgvResultado.DataSource = tabla
    End Sub

    Private Sub Label3_Click(sender As System.Object, e As System.EventArgs) Handles Label3.Click

    End Sub
End Class
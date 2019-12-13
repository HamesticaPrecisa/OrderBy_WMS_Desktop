Public Class Frm_ListadoUsuarios

    Dim fnc As New Funciones

    Private Sub Frm_ListadoUsuarios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If RealizarAccion("014", "089", False) = True AndAlso RealizarAccion("014", "036", False) = False Then
            'DgvUsuarios.DataSource = fnc.ListarTablasSQL("SELECT usu_codigo, usu_rut,  usu_nombre+' '+usu_ap+' '+usu_am AS Usuario , usu_usuario FROM usuarios WHERE usu_seccod='2'")
            DgvUsuarios.DataSource = fnc.ListarTablasSQL("select usu_codigo,usu_rut,Usuario=ltrim(rtrim(usu_nombre))+' '+ltrim(rtrim(usu_ap))+' '+ltrim(rtrim(usu_am)),usu_usuario,Estado=case usu_codvig when 1 then 'Activo' else 'Inactivo' end from Usuarios with(nolock) where usu_seccod='2' order by 3 asc")
        Else
            'DgvUsuarios.DataSource = fnc.ListarTablasSQL("SELECT usu_codigo, usu_rut,  usu_nombre+' '+usu_ap+' '+usu_am AS Usuario , usu_usuario FROM usuarios")
            DgvUsuarios.DataSource = fnc.ListarTablasSQL("select usu_codigo,usu_rut,Usuario=ltrim(rtrim(usu_nombre))+' '+ltrim(rtrim(usu_ap))+' '+ltrim(rtrim(usu_am)),usu_usuario,Estado=case usu_codvig when 1 then 'Activo' else 'Inactivo' end from Usuarios with(nolock) order by 3 asc")
        End If

    End Sub

    Private Sub DgvUsuarios_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvUsuarios.CellDoubleClick
        If e.RowIndex > -1 Then
            Dim _formInterface As IForm = CType(Me.Owner, IForm)

            _formInterface.ChangeTextBoxText(DgvUsuarios.Rows(e.RowIndex).Cells(1).Value.ToString())

            Me.Close()
        End If
    End Sub

    Private Sub TxtBuscador_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBuscador.TextChanged
        If RealizarAccion("014", "089", False) = True AndAlso RealizarAccion("014", "036", False) = False Then
            'DgvUsuarios.DataSource = fnc.ListarTablasSQL("SELECT usu_codigo, usu_rut,  usu_nombre+' '+usu_ap+' '+usu_am AS Usuario , " +
            '                                                  "usu_usuario FROM usuarios WHERE usu_seccod='2' AND usu_nombre LIKE'%" + TxtBuscador.Text + "%'")
            DgvUsuarios.DataSource = fnc.ListarTablasSQL("select usu_codigo,usu_rut,Usuario=ltrim(rtrim(usu_nombre))+' '+ltrim(rtrim(usu_ap))+' '+ltrim(rtrim(usu_am)),usu_usuario,Estado=case usu_codvig when 1 then 'Activo' else 'Inactivo' end from Usuarios with(nolock) where usu_nombre like '%" + TxtBuscador.Text + "%' and usu_seccod='2' order by 3 asc")
        Else
            'DgvUsuarios.DataSource = fnc.ListarTablasSQL("SELECT usu_codigo, usu_rut,  usu_nombre+' '+usu_ap+' '+usu_am AS Usuario , " +
            '                                                   "usu_usuario FROM usuarios WHERE usu_nombre LIKE'%" + TxtBuscador.Text + "%'")
            DgvUsuarios.DataSource = fnc.ListarTablasSQL("select usu_codigo,usu_rut,Usuario=ltrim(rtrim(usu_nombre))+' '+ltrim(rtrim(usu_ap))+' '+ltrim(rtrim(usu_am)),usu_usuario,Estado=case usu_codvig when 1 then 'Activo' else 'Inactivo' end from Usuarios with(nolock) where usu_nombre like '%" + TxtBuscador.Text + "%' order by 3 asc")
        End If

    End Sub
End Class
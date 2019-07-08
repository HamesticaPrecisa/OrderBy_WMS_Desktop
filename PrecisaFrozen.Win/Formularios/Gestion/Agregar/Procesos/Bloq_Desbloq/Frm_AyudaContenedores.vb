Public Class Frm_AyudaContenedores

    Public contrato As String = ""
    Dim fnc As New Funciones

    Private Sub Frm_AyudaContenedores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim SQL As String = "SELECT ISNULL(frec_contenedor,0) as frec_contenedor, frec_guiades, frec_codi  " +
        '    "FROM fichrece LEFT JOIN proc_importaciones ON frec_codi=pimp_codrece INNER JOIN contrato ON frec_contcli=cont_codi " +
        '    "WHERE  frec_contcli='" + contrato.ToString() + "' AND pimp_codrece is null AND frec_tiporecepcion='2' AND  cont_BloqImp='1' AND frec_rutcond='222222222'"


        Dim QUERY As String = "SELECT LEFT(racd_codi,7) as frec_codi, frec_contenedor, frec_guiades  FROM rackdeta INNER JOIN detarece ON drec_codi=racd_codi INNER JOIN fichrece fr ON fr.frec_codi=frec_codi1 " +
                                "WHERE drec_contcli='" + contrato.ToString() + "' AND racd_estado='5' GROUP BY LEFT(racd_codi,7) , frec_contenedor, frec_guiades"

        dgvResultado.DataSource = fnc.ListarTablasSQL(QUERY)
    End Sub

    Private Sub dgvResultado_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvResultado.CellDoubleClick
        If e.RowIndex > -1 Then
            Dim _formInterface As IForm = CType(Me.Owner, IForm)
            _formInterface.ChangeTextBoxText(dgvResultado.Rows(e.RowIndex).Cells(0).Value.ToString())
            Me.Close()
        End If
    End Sub

    Private Sub txtbusca_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtbusca.TextChanged
        'Dim SQL As String = "SELECT ISNULL(frec_contenedor,0) as frec_contenedor, frec_guiades, frec_codi  " +
        '                    "FROM fichrece LEFT JOIN proc_importaciones ON frec_codi=pimp_codrece " +
        '                    "WHERE  frec_contcli='" + contrato.ToString() + "' AND pimp_codrece is null AND " +
        '                    "frec_tiporecepcion='2' AND (frec_contenedor LIKE '%" + txtbusca.Text + "%' OR " +
        '                    "frec_guiades LIKE '%" + txtbusca.Text + "%' OR frec_codi LIKE '%" + txtbusca.Text + "%' )"

        Dim QUERY As String = "SELECT LEFT(racd_codi,7) as frec_codi, frec_contenedor, frec_guiades  FROM rackdeta INNER JOIN detarece ON drec_codi=racd_codi INNER JOIN fichrece fr ON fr.frec_codi=frec_codi1 " +
                              "WHERE drec_contcli='" + contrato.ToString() + "' AND racd_estado='5' " +
                              "AND  frec_tiporecepcion='2' AND (frec_contenedor LIKE '%" + txtbusca.Text + "%' OR " +
                              "frec_guiades LIKE '%" + txtbusca.Text + "%' OR frec_codi LIKE '%" + txtbusca.Text + "%' )" +
                              "GROUP BY LEFT(racd_codi,7) , frec_contenedor, frec_guiades"


        dgvResultado.DataSource = fnc.ListarTablasSQL(QUERY)
    End Sub
End Class
Imports System.Data.SqlClient
Imports System.IO
Imports System.Windows.Documents
Imports System.Globalization

Public Class Frm_IngresoServicios

    Dim fnc As New Funciones
    Dim valor As String = ""

    Sub LlenaCombos()

        cmbo_moneda.DataSource = fnc.ListarTablasSQL("SELECT mon_codi, mon_descr FROM monedas ORDER BY mon_codi DESC")
        cmbo_moneda.ValueMember = "mon_codi"
        cmbo_moneda.DisplayMember = "mon_descr"

        cmbo_medida.DataSource = fnc.ListarTablasSQL("SELECT med_codi, med_descr FROM medidas")
        cmbo_medida.ValueMember = "med_codi"
        cmbo_medida.DisplayMember = "med_descr"

        cmbo_seccion.DataSource = fnc.ListarTablasSQL("SELECT   Tdoc_codi, Tdoc_desc FROM FacLugar ORDER BY Tdoc_codi")
        cmbo_seccion.DisplayMember = "Tdoc_desc"
        cmbo_seccion.ValueMember = "Tdoc_codi"

    End Sub

    Private Sub Codigo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtcodigo.KeyPress
        If e.KeyChar = ChrW(13) Then
            If Txtcodigo.Text = "" Then
                Txtcodigo.Text = BuscaCorrelativo("011", 3)
                Txtcodigo.Enabled = False
                GroupBox1.Enabled = True
                cbrece.Enabled = True
                cbdesp.Enabled = True
                cbetiq.Enabled = True
                Btn_BuscaServicio.Enabled = False
                cbesc.Enabled = True
                txtnombre.Focus()
            Else
                Txtcodigo.Text = CerosAnteriorString(Txtcodigo.Text, 3)
                BuscaServicio(Txtcodigo.Text)
            End If
            Btn_Guardar.Enabled = True
        Else
            SoloNumeros(sender, e)
        End If
    End Sub

    Public Sub Frm_IngresoServicios_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Txtcodigo.Enabled = False Then
            If fnc.verificaExistencia("facServicios", "serv_cod", Txtcodigo.Text) = False Then
                If MsgBox("Desea salir sin agregar el servicio", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbYes Then
                    CancelaCorrelativo("011", Txtcodigo.Text)
                Else
                    e.Cancel = True
                End If
            End If
        End If
        f_addservicios = False
    End Sub

    Private Sub Frm_IngresoServicios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LlenaCombos()
        'SpellChecker.Dictionary = CultureInfo.Name
    End Sub

    Private Sub cmbo_medida_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbo_moneda.KeyPress, cmbo_medida.KeyPress
        e.Handled = True
    End Sub

    Private Sub Btn_Nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Nuevo.Click
        If Txtcodigo.Enabled = False Then
            If fnc.verificaExistencia("facServicios", "serv_cod", Txtcodigo.Text) = False Then
                If MsgBox("Desea salir sin agregar el servicio", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbYes Then
                    CancelaCorrelativo("011", Txtcodigo.Text)
                    Limpiar()
                End If
            Else
                Limpiar()
            End If
        Else
            Limpiar()
        End If
    End Sub

    Private Sub Btn_Guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Guardar.Click
        If Validacion() = True Then

            Dim con As New Conexion

            Try
                con.conectar()

                Dim _cmd As SqlCommand = New SqlCommand("PAG_ING_SEGUROS", con.con)
                _cmd.CommandType = CommandType.StoredProcedure
                _cmd.Parameters.AddWithValue("@Serv_Cod", Txtcodigo.Text)
                _cmd.Parameters.AddWithValue("@serv_nom", txtnombre.Text)
                _cmd.Parameters.AddWithValue("@serv_medpred", cmbo_medida.SelectedValue)
                _cmd.Parameters.AddWithValue("@serv_monpred", cmbo_moneda.SelectedValue)
                _cmd.Parameters.AddWithValue("@serv_desc", txtdesc.Rtf)
                _cmd.Parameters.AddWithValue("@rece", cbrece.CheckState)
                _cmd.Parameters.AddWithValue("@desp", cbdesp.CheckState)
                _cmd.Parameters.AddWithValue("@etiq", cbetiq.CheckState)
                _cmd.Parameters.AddWithValue("@serv_esc", cbesc.CheckState)
                _cmd.Parameters.AddWithValue("@serv_sec", cmbo_seccion.SelectedValue)

                Dim resp As Integer = 0
                Try
                    resp = Convert.ToInt32(_cmd.ExecuteScalar())
                Catch ex As Exception
                    resp = 1
                End Try

                If resp = 0 Then
                    MsgBox("Grabación exitosa", MsgBoxStyle.Information, "Aviso")
                    Btn_Eliminar.Enabled = True
                Else
                    MsgBox("Error inesperado al grabar la información", MsgBoxStyle.Critical, "Aviso")
                End If
                con.cerrar()

            Catch ex As Exception
                MsgBox(ex.Message())
            End Try

        End If
    End Sub

    Private Sub Btn_Salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Salir.Click
        Me.Close()
    End Sub

    Function Validacion() As Boolean
        Dim Mensaje As String = ""
        Validacion = True

        If Txtcodigo.Enabled = True Then
            Mensaje = Mensaje + "- Ingresar el codigo " + vbCrLf
            Validacion = False
        End If

        If txtnombre.Text = "" Then
            Mensaje = Mensaje + "- Ingresar el nombre del servicio " + vbCrLf
            Validacion = False
        End If

        If Mensaje.Length > 0 Then
            MsgBox("Debe completar lo siguiente antes de agregar el servicio" + Mensaje, MsgBoxStyle.Critical, "Aviso")
        End If

    End Function

    Sub Limpiar()
        Txtcodigo.Text = ""
        Txtcodigo.Enabled = True
        cbrece.Checked = False
        cbdesp.Checked = False
        cbetiq.Checked = False
        LimpiarCajas(GroupBox1)
        txtdesc.Rtf = ""
        GroupBox1.Enabled = False
        cbesc.Checked = False
        Btn_BuscaServicio.Enabled = True
        Btn_Eliminar.Enabled = False
        cbesc.Enabled = False
        Txtcodigo.Focus()
    End Sub

    Private Sub Btn_BuscaServicio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_BuscaServicio.Click
        Dim f As New Frm_IngresoServiciosAyuda
        f.ShowDialog(Frm_Principal)

        If Frm_Principal.buscavalor <> "" Then
            BuscaServicio(Frm_Principal.buscavalor)
        End If

    End Sub

    Private Sub BuscaServicio(ByVal codigo)
        Txtcodigo.Text = Frm_Principal.buscavalor.ToString()
        Dim sql As String = "SELECT Serv_Nom, Serv_MedPred, Serv_MonPred, Serv_Descr, Serv_Esc, Serv_Sec, Serv_OrdR, Serv_OrdD, Serv_OrdE  FROM facServicios WHERE serv_cod='" + codigo + "'"
        Dim tabla As DataTable = fnc.ListarTablasSQL(sql)

        If tabla.Rows.Count > 0 Then
            Txtcodigo.Enabled = False
            Txtcodigo.Text = codigo
            txtnombre.Text = tabla.Rows(0)(0).ToString()
            cmbo_medida.SelectedValue = tabla.Rows(0)(1).ToString()
            cmbo_moneda.SelectedValue = tabla.Rows(0)(2).ToString()

            txtdesc.Rtf = tabla.Rows(0)(3).ToString()

            cbesc.Checked = tabla.Rows(0)(4).ToString()
            cmbo_seccion.SelectedValue = tabla.Rows(0)(5).ToString()
            Txtcodigo.Enabled = False
            GroupBox1.Enabled = True

            If tabla.Rows(0)(6).ToString() <> "" Then
                cbrece.Checked = True
            End If

            If tabla.Rows(0)(7).ToString() <> "" Then
                cbdesp.Checked = True
            End If

            If tabla.Rows(0)(8).ToString() <> "" Then
                cbetiq.Checked = True
            End If

            cbrece.Enabled = False
            cbdesp.Enabled = False
            cbetiq.Enabled = False
            Btn_Guardar.Enabled = True
            Btn_Eliminar.Enabled = True
            cbesc.Enabled = True
            txtnombre.Focus()

        Else
            MsgBox("El número ingresado no existe", MsgBoxStyle.Critical, "Aviso")
            Txtcodigo.Text = ""
            Txtcodigo.Focus()
        End If
    End Sub

    Private Sub Frm_IngresoServicios_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F1 Then
            Btn_BuscaServicio.PerformClick()
        ElseIf e.KeyCode = Keys.F5 Then
            Btn_Guardar.PerformClick()
        ElseIf e.KeyCode = Keys.F6 Then
            Btn_Nuevo.PerformClick()
        ElseIf e.KeyCode = Keys.F7 Then
            Btn_Eliminar.PerformClick()
        ElseIf e.KeyCode = Keys.Escape Then
            Btn_Salir.PerformClick()
        End If
    End Sub

    Private Sub Btn_Eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Eliminar.Click
        If MsgBox("¿Seguro de eliminar el servicio seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Aviso") = vbYes Then
            Dim sql As String = "DELETE FROM FacServicios WHERE Serv_Cod='" + Txtcodigo.Text + "'"

            If fnc.MovimientoSQL(sql) > 0 Then
                CancelaCorrelativo("011", Txtcodigo.Text)
                MsgBox("Servicio eliminado correctamente", MsgBoxStyle.Information, "Aviso")
                Limpiar()
            Else
                MsgBox("Error al eliminar el servicio, tiene registros relacionados", 16, "Aviso")
            End If
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Console.WriteLine(txtdesc.Rtf)
    End Sub

    Public Function sRTF_To_HTML(ByVal sRTF As String) As String
        'Declare a Word Application Object and a Word WdSaveOptions object
        Dim MyWord As Microsoft.Office.Interop.Word.Application
        Dim oDoNotSaveChanges As Object = _
             Microsoft.Office.Interop.Word.WdSaveOptions.wdDoNotSaveChanges
        'Declare two strings to handle the data
        Dim sReturnString As String = ""
        Dim sConvertedString As String = ""
        Try
            'Instantiate the Word application,

            MyWord = CreateObject("Word.application")
            MyWord.Visible = False
            MyWord.Documents.Add()
            'Create a DataObject to hold the Rich Text
            'and copy it to the clipboard
            Dim doRTF As New System.Windows.Forms.DataObject
            doRTF.SetData("Rich Text Format", sRTF)
            Clipboard.SetDataObject(doRTF)
            'Paste the contents of the clipboard to the empty,
            'hidden Word Document
            MyWord.Windows(1).Selection.Paste()
            'â€¦then, select the entire contents of the document
            'and copy back to the clipboard
            MyWord.Windows(1).Selection.WholeStory()
            MyWord.Windows(1).Selection.Copy()
            'Now retrieve the HTML property of the DataObject
            'stored on the clipboard
            sConvertedString = _
                 Clipboard.GetData(System.Windows.Forms.DataFormats.Html)
            'Remove some leading text that shows up in some instances
            '(like when you insert it into an email in Outlook
            sConvertedString = _
                 sConvertedString.Substring(sConvertedString.IndexOf("<html"))
            'Also remove multiple Ã‚ characters that somehow end up in there
            sConvertedString = sConvertedString.Replace("Ã‚", "")
            'â€¦and you're done.
            sReturnString = sConvertedString
            If Not MyWord Is Nothing Then
                MyWord.Quit(oDoNotSaveChanges)
                MyWord = Nothing
            End If
        Catch ex As Exception
            If Not MyWord Is Nothing Then
                MyWord.Quit(oDoNotSaveChanges)
                MyWord = Nothing
            End If
            MsgBox("Error converting Rich Text to HTML")
        End Try
        Return sReturnString
    End Function


    ''Configuracion del texto

    ' Handles when user chooses to delete in spell cehck
    Private Sub SpellChecker_DeletedWord(ByVal sender As Object, ByVal e As NetSpell.SpellChecker.SpellingEventArgs) Handles SpellChecker.DeletedWord
        'save existing selecting
        Dim start As Integer = txtdesc.SelectionStart
        Dim length As Integer = txtdesc.SelectionLength

        'select word for this event
        txtdesc.Select(e.TextIndex, e.Word.Length)

        'delete word
        txtdesc.SelectedText = ""

        If ((start + length) > txtdesc.Text.Length) Then
            length = 0
        End If

        'restore selection
        txtdesc.Select(start, length)

    End Sub

    ' Handles replacing a word from spell checking
    Private Sub SpellChecker_ReplacedWord(ByVal sender As Object, ByVal e As NetSpell.SpellChecker.ReplaceWordEventArgs) Handles SpellChecker.ReplacedWord
        'save existing selecting
        Dim start As Integer = txtdesc.SelectionStart
        Dim length As Integer = txtdesc.SelectionLength

        'select word for this event
        txtdesc.Select(e.TextIndex, e.Word.Length)

        'replace word
        txtdesc.SelectedText = e.ReplacementWord

        If ((start + length) > txtdesc.Text.Length) Then
            length = 0
        End If

        'restore selection
        txtdesc.Select(start, length)
    End Sub

    ' Update buttons when text is selected
    Private Sub rtb_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtdesc.SelectionChanged
        ' see which buttons should be checked or unchecked
        BoldToolStripButton.Checked = txtdesc.SelectionFont.Bold
        UnderlineToolStripButton.Checked = txtdesc.SelectionFont.Underline
        LeftToolStripButton.Checked = IIf(txtdesc.SelectionAlignment = System.Windows.Forms.HorizontalAlignment.Left, True, False)
        CenterToolStripButton.Checked = IIf(txtdesc.SelectionAlignment = System.Windows.Forms.HorizontalAlignment.Center, True, False)
        RightToolStripButton.Checked = IIf(txtdesc.SelectionAlignment = System.Windows.Forms.HorizontalAlignment.Right, True, False)
        BulletsToolStripButton.Checked = txtdesc.SelectionBullet

        'cmbFontName.Text = rtb.SelectionFont.Name
        'cmbFontSize.Text = rtb.SelectionFont.SizeInPoints

    End Sub

    Private Sub checkBullets()
        If txtdesc.SelectionBullet = True Then
            BulletsToolStripButton.Checked = True
        Else
            BulletsToolStripButton.Checked = False
        End If
    End Sub

    Private Sub FontToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FontToolStripButton.Click
        If FontDlg.ShowDialog() <> Windows.Forms.DialogResult.Cancel Then
            txtdesc.SelectionFont = FontDlg.Font
        End If
    End Sub

    Private Sub FontColorToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FontColorToolStripButton.Click
        If ColorDlg.ShowDialog() <> Windows.Forms.DialogResult.Cancel Then
            txtdesc.SelectionColor = ColorDlg.Color
        End If
    End Sub

    Private Sub BoldToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BoldToolStripButton.Click
        ' Switch Bold
        Dim currentFont As System.Drawing.Font = txtdesc.SelectionFont
        Dim newFontStyle As System.Drawing.FontStyle
        If txtdesc.SelectionFont.Bold = True Then
            newFontStyle = currentFont.Style - Drawing.FontStyle.Bold
        Else
            newFontStyle = currentFont.Style + Drawing.FontStyle.Bold
        End If
        txtdesc.SelectionFont = New Drawing.Font(currentFont.FontFamily, currentFont.Size, newFontStyle)

        ' Check/Uncheck Bold button
        BoldToolStripButton.Checked = IIf(txtdesc.SelectionFont.Bold, True, False)
    End Sub

    Private Sub UnderlineToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnderlineToolStripButton.Click
        ' Switch Underline
        Dim currentFont As System.Drawing.Font = txtdesc.SelectionFont
        Dim newFontStyle As System.Drawing.FontStyle
        If txtdesc.SelectionFont.Underline = True Then
            newFontStyle = currentFont.Style - Drawing.FontStyle.Underline
        Else
            newFontStyle = currentFont.Style + Drawing.FontStyle.Underline
        End If
        txtdesc.SelectionFont = New Drawing.Font(currentFont.FontFamily, currentFont.Size, newFontStyle)

        ' Check/Uncheck Underline button
        UnderlineToolStripButton.Checked = IIf(txtdesc.SelectionFont.Underline, True, False)
    End Sub

    Private Sub LeftToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LeftToolStripButton.Click
        txtdesc.SelectionAlignment = HorizontalAlignment.Left
    End Sub

    Private Sub CenterToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CenterToolStripButton.Click
        txtdesc.SelectionAlignment = HorizontalAlignment.Center
    End Sub

    Private Sub RightToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RightToolStripButton.Click
        txtdesc.SelectionAlignment = HorizontalAlignment.Right
    End Sub

    Private Sub BulletsToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BulletsToolStripButton.Click
        txtdesc.SelectionBullet = Not txtdesc.SelectionBullet
        BulletsToolStripButton.Checked = txtdesc.SelectionBullet
    End Sub

End Class
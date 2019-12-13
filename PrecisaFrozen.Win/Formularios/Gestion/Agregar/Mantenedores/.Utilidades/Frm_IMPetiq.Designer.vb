<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_IMPetiq
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtCodCamara = New System.Windows.Forms.TextBox()
        Me.BtnOrigen = New System.Windows.Forms.Button()
        Me.txtNombreCam = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RbRangos = New System.Windows.Forms.RadioButton()
        Me.RbEtiqueta = New System.Windows.Forms.RadioButton()
        Me.cbEstados = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtCoFinal = New System.Windows.Forms.TextBox()
        Me.txtBaFinal = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtcolumna = New System.Windows.Forms.TextBox()
        Me.txtbanda = New System.Windows.Forms.TextBox()
        Me.txtcamara = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.BtnImprimir = New System.Windows.Forms.Button()
        Me.chkpas = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label2.Location = New System.Drawing.Point(20, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 2043
        Me.Label2.Text = "Camara"
        '
        'TxtCodCamara
        '
        Me.TxtCodCamara.Enabled = False
        Me.TxtCodCamara.Location = New System.Drawing.Point(122, 24)
        Me.TxtCodCamara.Name = "TxtCodCamara"
        Me.TxtCodCamara.Size = New System.Drawing.Size(35, 20)
        Me.TxtCodCamara.TabIndex = 2042
        '
        'BtnOrigen
        '
        Me.BtnOrigen.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.buscar_24
        Me.BtnOrigen.Location = New System.Drawing.Point(351, 22)
        Me.BtnOrigen.Name = "BtnOrigen"
        Me.BtnOrigen.Size = New System.Drawing.Size(23, 23)
        Me.BtnOrigen.TabIndex = 2044
        Me.BtnOrigen.UseVisualStyleBackColor = True
        '
        'txtNombreCam
        '
        Me.txtNombreCam.Enabled = False
        Me.txtNombreCam.Location = New System.Drawing.Point(159, 24)
        Me.txtNombreCam.Name = "txtNombreCam"
        Me.txtNombreCam.Size = New System.Drawing.Size(186, 20)
        Me.txtNombreCam.TabIndex = 2045
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RbRangos)
        Me.GroupBox1.Controls.Add(Me.RbEtiqueta)
        Me.GroupBox1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(18, 51)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.GroupBox1.Size = New System.Drawing.Size(358, 59)
        Me.GroupBox1.TabIndex = 2047
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Tipo Impresion"
        '
        'RbRangos
        '
        Me.RbRangos.Location = New System.Drawing.Point(157, 22)
        Me.RbRangos.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.RbRangos.Name = "RbRangos"
        Me.RbRangos.Size = New System.Drawing.Size(109, 31)
        Me.RbRangos.TabIndex = 1
        Me.RbRangos.TabStop = True
        Me.RbRangos.Text = "Por Rangos "
        Me.RbRangos.UseVisualStyleBackColor = True
        Me.RbRangos.Visible = False
        '
        'RbEtiqueta
        '
        Me.RbEtiqueta.Checked = True
        Me.RbEtiqueta.Location = New System.Drawing.Point(40, 22)
        Me.RbEtiqueta.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.RbEtiqueta.Name = "RbEtiqueta"
        Me.RbEtiqueta.Size = New System.Drawing.Size(101, 31)
        Me.RbEtiqueta.TabIndex = 0
        Me.RbEtiqueta.TabStop = True
        Me.RbEtiqueta.Text = "Etiqueta"
        Me.RbEtiqueta.UseVisualStyleBackColor = True
        '
        'cbEstados
        '
        Me.cbEstados.FormattingEnabled = True
        Me.cbEstados.Location = New System.Drawing.Point(364, 378)
        Me.cbEstados.Name = "cbEstados"
        Me.cbEstados.Size = New System.Drawing.Size(184, 21)
        Me.cbEstados.TabIndex = 2056
        Me.cbEstados.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(361, 350)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(35, 13)
        Me.Label7.TabIndex = 2061
        Me.Label7.Text = "Hasta"
        Me.Label7.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(68, 130)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 13)
        Me.Label6.TabIndex = 2060
        Me.Label6.Text = "Desde"
        '
        'TxtCoFinal
        '
        Me.TxtCoFinal.Location = New System.Drawing.Point(364, 454)
        Me.TxtCoFinal.Name = "TxtCoFinal"
        Me.TxtCoFinal.Size = New System.Drawing.Size(52, 20)
        Me.TxtCoFinal.TabIndex = 2055
        Me.TxtCoFinal.Visible = False
        '
        'txtBaFinal
        '
        Me.txtBaFinal.Location = New System.Drawing.Point(364, 414)
        Me.txtBaFinal.Name = "txtBaFinal"
        Me.txtBaFinal.Size = New System.Drawing.Size(52, 20)
        Me.txtBaFinal.TabIndex = 2053
        Me.txtBaFinal.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(321, 458)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(10, 13)
        Me.Label5.TabIndex = 2059
        Me.Label5.Text = "-"
        Me.Label5.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(321, 418)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(10, 13)
        Me.Label4.TabIndex = 2058
        Me.Label4.Text = "-"
        Me.Label4.Visible = False
        '
        'txtcolumna
        '
        Me.txtcolumna.Location = New System.Drawing.Point(71, 230)
        Me.txtcolumna.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtcolumna.MaxLength = 2
        Me.txtcolumna.Name = "txtcolumna"
        Me.txtcolumna.Size = New System.Drawing.Size(66, 20)
        Me.txtcolumna.TabIndex = 2054
        '
        'txtbanda
        '
        Me.txtbanda.Location = New System.Drawing.Point(71, 194)
        Me.txtbanda.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtbanda.MaxLength = 2
        Me.txtbanda.Name = "txtbanda"
        Me.txtbanda.Size = New System.Drawing.Size(66, 20)
        Me.txtbanda.TabIndex = 2052
        '
        'txtcamara
        '
        Me.txtcamara.Enabled = False
        Me.txtcamara.Location = New System.Drawing.Point(71, 158)
        Me.txtcamara.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtcamara.MaxLength = 2
        Me.txtcamara.Name = "txtcamara"
        Me.txtcamara.Size = New System.Drawing.Size(66, 20)
        Me.txtcamara.TabIndex = 2049
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(15, 238)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 13)
        Me.Label3.TabIndex = 2051
        Me.Label3.Text = "Columna"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(15, 201)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(38, 13)
        Me.Label8.TabIndex = 2050
        Me.Label8.Text = "Banda"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(15, 165)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(43, 13)
        Me.Label9.TabIndex = 2048
        Me.Label9.Text = "Camara"
        '
        'BtnImprimir
        '
        Me.BtnImprimir.FlatAppearance.BorderSize = 0
        Me.BtnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnImprimir.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_impresora
        Me.BtnImprimir.Location = New System.Drawing.Point(311, 194)
        Me.BtnImprimir.Name = "BtnImprimir"
        Me.BtnImprimir.Size = New System.Drawing.Size(63, 63)
        Me.BtnImprimir.TabIndex = 2062
        Me.BtnImprimir.UseVisualStyleBackColor = True
        '
        'chkpas
        '
        Me.chkpas.AutoSize = True
        Me.chkpas.ForeColor = System.Drawing.Color.White
        Me.chkpas.Location = New System.Drawing.Point(311, 116)
        Me.chkpas.Name = "chkpas"
        Me.chkpas.Size = New System.Drawing.Size(70, 17)
        Me.chkpas.TabIndex = 2063
        Me.chkpas.Text = "PASILLO"
        Me.chkpas.UseVisualStyleBackColor = True
        '
        'Frm_IMPetiq
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(381, 262)
        Me.Controls.Add(Me.chkpas)
        Me.Controls.Add(Me.BtnImprimir)
        Me.Controls.Add(Me.cbEstados)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TxtCoFinal)
        Me.Controls.Add(Me.txtBaFinal)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtcolumna)
        Me.Controls.Add(Me.txtbanda)
        Me.Controls.Add(Me.txtcamara)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtNombreCam)
        Me.Controls.Add(Me.BtnOrigen)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtCodCamara)
        Me.Name = "Frm_IMPetiq"
        Me.Text = "Frm_IMPetiq"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BtnOrigen As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtCodCamara As System.Windows.Forms.TextBox
    Friend WithEvents txtNombreCam As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RbRangos As System.Windows.Forms.RadioButton
    Friend WithEvents RbEtiqueta As System.Windows.Forms.RadioButton
    Friend WithEvents cbEstados As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtCoFinal As System.Windows.Forms.TextBox
    Friend WithEvents txtBaFinal As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtcolumna As System.Windows.Forms.TextBox
    Friend WithEvents txtbanda As System.Windows.Forms.TextBox
    Friend WithEvents txtcamara As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents BtnImprimir As System.Windows.Forms.Button
    Friend WithEvents chkpas As System.Windows.Forms.CheckBox
End Class

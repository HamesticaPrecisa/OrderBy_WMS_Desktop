<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_UtilidadImprEtRack
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtcamara = New System.Windows.Forms.TextBox()
        Me.txtbanda = New System.Windows.Forms.TextBox()
        Me.txtcolumna = New System.Windows.Forms.TextBox()
        Me.BtnImprimir = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RbRangos = New System.Windows.Forms.RadioButton()
        Me.RbEtiqueta = New System.Windows.Forms.RadioButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rdslot = New System.Windows.Forms.RadioButton()
        Me.rdzonap = New System.Windows.Forms.RadioButton()
        Me.rdbpasillo = New System.Windows.Forms.RadioButton()
        Me.rbPreFrio = New System.Windows.Forms.RadioButton()
        Me.rbSalaProceso = New System.Windows.Forms.RadioButton()
        Me.rbPuerta = New System.Windows.Forms.RadioButton()
        Me.Rb_Pulmon = New System.Windows.Forms.RadioButton()
        Me.Rb_Tunel = New System.Windows.Forms.RadioButton()
        Me.RbAnden = New System.Windows.Forms.RadioButton()
        Me.RbPiso = New System.Windows.Forms.RadioButton()
        Me.RbRack = New System.Windows.Forms.RadioButton()
        Me.txtBaFinal = New System.Windows.Forms.TextBox()
        Me.TxtCoFinal = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cbEstados = New System.Windows.Forms.ComboBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(109, 259)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Camara"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(109, 295)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 17)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Banda"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(109, 335)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 17)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Columna"
        '
        'txtcamara
        '
        Me.txtcamara.Location = New System.Drawing.Point(277, 252)
        Me.txtcamara.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtcamara.MaxLength = 2
        Me.txtcamara.Name = "txtcamara"
        Me.txtcamara.Size = New System.Drawing.Size(49, 24)
        Me.txtcamara.TabIndex = 1
        '
        'txtbanda
        '
        Me.txtbanda.Location = New System.Drawing.Point(277, 288)
        Me.txtbanda.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtbanda.MaxLength = 2
        Me.txtbanda.Name = "txtbanda"
        Me.txtbanda.Size = New System.Drawing.Size(49, 24)
        Me.txtbanda.TabIndex = 2
        '
        'txtcolumna
        '
        Me.txtcolumna.Location = New System.Drawing.Point(277, 328)
        Me.txtcolumna.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtcolumna.MaxLength = 2
        Me.txtcolumna.Name = "txtcolumna"
        Me.txtcolumna.Size = New System.Drawing.Size(49, 24)
        Me.txtcolumna.TabIndex = 4
        '
        'BtnImprimir
        '
        Me.BtnImprimir.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.printer
        Me.BtnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnImprimir.Location = New System.Drawing.Point(452, 292)
        Me.BtnImprimir.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.BtnImprimir.Name = "BtnImprimir"
        Me.BtnImprimir.Size = New System.Drawing.Size(127, 73)
        Me.BtnImprimir.TabIndex = 10
        Me.BtnImprimir.Text = "Imprimir  "
        Me.BtnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnImprimir.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.Barcode
        Me.PictureBox1.Location = New System.Drawing.Point(11, 33)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(142, 106)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 11
        Me.PictureBox1.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RbRangos)
        Me.GroupBox1.Controls.Add(Me.RbEtiqueta)
        Me.GroupBox1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(157, 145)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.GroupBox1.Size = New System.Drawing.Size(358, 59)
        Me.GroupBox1.TabIndex = 12
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
        Me.RbEtiqueta.Text = "1 Etiqueta"
        Me.RbEtiqueta.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(339, 292)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(15, 17)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "-"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(339, 332)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(15, 17)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "-"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rdslot)
        Me.GroupBox2.Controls.Add(Me.rdzonap)
        Me.GroupBox2.Controls.Add(Me.rdbpasillo)
        Me.GroupBox2.Controls.Add(Me.rbPreFrio)
        Me.GroupBox2.Controls.Add(Me.rbSalaProceso)
        Me.GroupBox2.Controls.Add(Me.rbPuerta)
        Me.GroupBox2.Controls.Add(Me.Rb_Pulmon)
        Me.GroupBox2.Controls.Add(Me.Rb_Tunel)
        Me.GroupBox2.Controls.Add(Me.RbAnden)
        Me.GroupBox2.Controls.Add(Me.RbPiso)
        Me.GroupBox2.Controls.Add(Me.RbRack)
        Me.GroupBox2.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(157, 12)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.GroupBox2.Size = New System.Drawing.Size(440, 127)
        Me.GroupBox2.TabIndex = 13
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Tipo Camara"
        '
        'rdslot
        '
        Me.rdslot.AutoSize = True
        Me.rdslot.Location = New System.Drawing.Point(167, 92)
        Me.rdslot.Name = "rdslot"
        Me.rdslot.Size = New System.Drawing.Size(61, 20)
        Me.rdslot.TabIndex = 10
        Me.rdslot.TabStop = True
        Me.rdslot.Text = "SLOT"
        Me.rdslot.UseVisualStyleBackColor = True
        '
        'rdzonap
        '
        Me.rdzonap.AutoSize = True
        Me.rdzonap.Location = New System.Drawing.Point(33, 92)
        Me.rdzonap.Name = "rdzonap"
        Me.rdzonap.Size = New System.Drawing.Size(128, 20)
        Me.rdzonap.TabIndex = 9
        Me.rdzonap.TabStop = True
        Me.rdzonap.Text = "Zona de pedido"
        Me.rdzonap.UseVisualStyleBackColor = True
        '
        'rdbpasillo
        '
        Me.rdbpasillo.AutoSize = True
        Me.rdbpasillo.Location = New System.Drawing.Point(258, 58)
        Me.rdbpasillo.Name = "rdbpasillo"
        Me.rdbpasillo.Size = New System.Drawing.Size(66, 20)
        Me.rdbpasillo.TabIndex = 8
        Me.rdbpasillo.TabStop = True
        Me.rdbpasillo.Text = "Pasillo"
        Me.rdbpasillo.UseVisualStyleBackColor = True
        '
        'rbPreFrio
        '
        Me.rbPreFrio.AutoSize = True
        Me.rbPreFrio.Location = New System.Drawing.Point(332, 58)
        Me.rbPreFrio.Name = "rbPreFrio"
        Me.rbPreFrio.Size = New System.Drawing.Size(88, 20)
        Me.rbPreFrio.TabIndex = 7
        Me.rbPreFrio.TabStop = True
        Me.rbPreFrio.Text = "Pre - Frio"
        Me.rbPreFrio.UseVisualStyleBackColor = True
        '
        'rbSalaProceso
        '
        Me.rbSalaProceso.AutoSize = True
        Me.rbSalaProceso.Location = New System.Drawing.Point(113, 59)
        Me.rbSalaProceso.Name = "rbSalaProceso"
        Me.rbSalaProceso.Size = New System.Drawing.Size(139, 20)
        Me.rbSalaProceso.TabIndex = 6
        Me.rbSalaProceso.TabStop = True
        Me.rbSalaProceso.Text = "Sala de Procesos"
        Me.rbSalaProceso.UseVisualStyleBackColor = True
        '
        'rbPuerta
        '
        Me.rbPuerta.AutoSize = True
        Me.rbPuerta.Location = New System.Drawing.Point(33, 59)
        Me.rbPuerta.Name = "rbPuerta"
        Me.rbPuerta.Size = New System.Drawing.Size(73, 20)
        Me.rbPuerta.TabIndex = 5
        Me.rbPuerta.TabStop = True
        Me.rbPuerta.Text = "Control"
        Me.rbPuerta.UseVisualStyleBackColor = True
        '
        'Rb_Pulmon
        '
        Me.Rb_Pulmon.Location = New System.Drawing.Point(332, 21)
        Me.Rb_Pulmon.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Rb_Pulmon.Name = "Rb_Pulmon"
        Me.Rb_Pulmon.Size = New System.Drawing.Size(84, 31)
        Me.Rb_Pulmon.TabIndex = 4
        Me.Rb_Pulmon.Text = "Pulmon"
        Me.Rb_Pulmon.UseVisualStyleBackColor = True
        '
        'Rb_Tunel
        '
        Me.Rb_Tunel.Location = New System.Drawing.Point(259, 21)
        Me.Rb_Tunel.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Rb_Tunel.Name = "Rb_Tunel"
        Me.Rb_Tunel.Size = New System.Drawing.Size(69, 31)
        Me.Rb_Tunel.TabIndex = 3
        Me.Rb_Tunel.Text = "Tunel"
        Me.Rb_Tunel.UseVisualStyleBackColor = True
        '
        'RbAnden
        '
        Me.RbAnden.Location = New System.Drawing.Point(177, 21)
        Me.RbAnden.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.RbAnden.Name = "RbAnden"
        Me.RbAnden.Size = New System.Drawing.Size(69, 31)
        Me.RbAnden.TabIndex = 2
        Me.RbAnden.Text = "Anden"
        Me.RbAnden.UseVisualStyleBackColor = True
        '
        'RbPiso
        '
        Me.RbPiso.Location = New System.Drawing.Point(113, 22)
        Me.RbPiso.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.RbPiso.Name = "RbPiso"
        Me.RbPiso.Size = New System.Drawing.Size(69, 31)
        Me.RbPiso.TabIndex = 1
        Me.RbPiso.Text = "Piso"
        Me.RbPiso.UseVisualStyleBackColor = True
        '
        'RbRack
        '
        Me.RbRack.Checked = True
        Me.RbRack.Location = New System.Drawing.Point(33, 22)
        Me.RbRack.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.RbRack.Name = "RbRack"
        Me.RbRack.Size = New System.Drawing.Size(69, 31)
        Me.RbRack.TabIndex = 0
        Me.RbRack.TabStop = True
        Me.RbRack.Text = "Rack"
        Me.RbRack.UseVisualStyleBackColor = True
        '
        'txtBaFinal
        '
        Me.txtBaFinal.Location = New System.Drawing.Point(364, 288)
        Me.txtBaFinal.Name = "txtBaFinal"
        Me.txtBaFinal.Size = New System.Drawing.Size(52, 24)
        Me.txtBaFinal.TabIndex = 3
        '
        'TxtCoFinal
        '
        Me.TxtCoFinal.Location = New System.Drawing.Point(364, 328)
        Me.TxtCoFinal.Name = "TxtCoFinal"
        Me.TxtCoFinal.Size = New System.Drawing.Size(52, 24)
        Me.TxtCoFinal.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(274, 224)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 17)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "Desde"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(361, 224)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(48, 17)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "Hasta"
        '
        'cbEstados
        '
        Me.cbEstados.FormattingEnabled = True
        Me.cbEstados.Location = New System.Drawing.Point(364, 252)
        Me.cbEstados.Name = "cbEstados"
        Me.cbEstados.Size = New System.Drawing.Size(151, 24)
        Me.cbEstados.TabIndex = 7
        Me.cbEstados.Visible = False
        '
        'Frm_UtilidadImprEtRack
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(613, 489)
        Me.Controls.Add(Me.cbEstados)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TxtCoFinal)
        Me.Controls.Add(Me.txtBaFinal)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.BtnImprimir)
        Me.Controls.Add(Me.txtcolumna)
        Me.Controls.Add(Me.txtbanda)
        Me.Controls.Add(Me.txtcamara)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Verdana", 10.0!)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_UtilidadImprEtRack"
        Me.Text = "Impresion Etiquetas Rack"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtcamara As System.Windows.Forms.TextBox
    Friend WithEvents txtbanda As System.Windows.Forms.TextBox
    Friend WithEvents txtcolumna As System.Windows.Forms.TextBox
    Friend WithEvents BtnImprimir As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RbRangos As System.Windows.Forms.RadioButton
    Friend WithEvents RbEtiqueta As System.Windows.Forms.RadioButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents RbPiso As System.Windows.Forms.RadioButton
    Friend WithEvents RbRack As System.Windows.Forms.RadioButton
    Friend WithEvents txtBaFinal As System.Windows.Forms.TextBox
    Friend WithEvents TxtCoFinal As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents RbAnden As System.Windows.Forms.RadioButton
    Friend WithEvents Rb_Tunel As System.Windows.Forms.RadioButton
    Friend WithEvents Rb_Pulmon As System.Windows.Forms.RadioButton
    Friend WithEvents rbSalaProceso As System.Windows.Forms.RadioButton
    Friend WithEvents rbPuerta As System.Windows.Forms.RadioButton
    Friend WithEvents cbEstados As System.Windows.Forms.ComboBox
    Friend WithEvents rbPreFrio As System.Windows.Forms.RadioButton
    Friend WithEvents rdbpasillo As System.Windows.Forms.RadioButton
    Friend WithEvents rdzonap As System.Windows.Forms.RadioButton
    Friend WithEvents rdslot As System.Windows.Forms.RadioButton
End Class

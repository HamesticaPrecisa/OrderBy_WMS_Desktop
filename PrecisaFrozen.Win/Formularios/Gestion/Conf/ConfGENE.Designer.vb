<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConfGENE
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.rdno = New System.Windows.Forms.RadioButton()
        Me.rdsi = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtcodigo = New System.Windows.Forms.TextBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.txtcanttemp = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtrangoyseco = New System.Windows.Forms.TextBox()
        Me.txtrangoxseco = New System.Windows.Forms.TextBox()
        Me.txtrangoyrefri = New System.Windows.Forms.TextBox()
        Me.txtranngoxrefri = New System.Windows.Forms.TextBox()
        Me.txtrangoycong = New System.Windows.Forms.TextBox()
        Me.txtrangoxcong = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtmaxkil = New System.Windows.Forms.TextBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TXTCANTIMP = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.rdno)
        Me.GroupBox1.Controls.Add(Me.rdsi)
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.GroupBox1.Location = New System.Drawing.Point(12, 22)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(406, 108)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Validar Rut"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_guardar2
        Me.Button1.Location = New System.Drawing.Point(319, 19)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(80, 78)
        Me.Button1.TabIndex = 120
        Me.Button1.UseVisualStyleBackColor = False
        '
        'rdno
        '
        Me.rdno.AutoSize = True
        Me.rdno.Location = New System.Drawing.Point(74, 47)
        Me.rdno.Name = "rdno"
        Me.rdno.Size = New System.Drawing.Size(41, 17)
        Me.rdno.TabIndex = 1
        Me.rdno.TabStop = True
        Me.rdno.Text = "NO"
        Me.rdno.UseVisualStyleBackColor = True
        '
        'rdsi
        '
        Me.rdsi.AutoSize = True
        Me.rdsi.Location = New System.Drawing.Point(24, 47)
        Me.rdsi.Name = "rdsi"
        Me.rdsi.Size = New System.Drawing.Size(35, 17)
        Me.rdsi.TabIndex = 0
        Me.rdsi.TabStop = True
        Me.rdsi.Text = "SI"
        Me.rdsi.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtcodigo)
        Me.GroupBox2.Controls.Add(Me.Button3)
        Me.GroupBox2.Controls.Add(Me.PictureBox1)
        Me.GroupBox2.Controls.Add(Me.Button2)
        Me.GroupBox2.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.GroupBox2.Location = New System.Drawing.Point(12, 136)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(406, 282)
        Me.GroupBox2.TabIndex = 121
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Logo etiquetas "
        '
        'txtcodigo
        '
        Me.txtcodigo.Location = New System.Drawing.Point(319, 125)
        Me.txtcodigo.Name = "txtcodigo"
        Me.txtcodigo.Size = New System.Drawing.Size(18, 20)
        Me.txtcodigo.TabIndex = 123
        Me.txtcodigo.Text = "1"
        Me.txtcodigo.Visible = False
        '
        'Button3
        '
        Me.Button3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Button3.Location = New System.Drawing.Point(183, 222)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(117, 31)
        Me.Button3.TabIndex = 122
        Me.Button3.Text = "Examinar"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.PrecisaFrozen.Win.My.Resources.Resources._1391547217_File___Image_256x256_32
        Me.PictureBox1.Location = New System.Drawing.Point(24, 29)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(276, 187)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 121
        Me.PictureBox1.TabStop = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Transparent
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_guardar2
        Me.Button2.Location = New System.Drawing.Point(306, 138)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(80, 78)
        Me.Button2.TabIndex = 120
        Me.Button2.UseVisualStyleBackColor = False
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.Button4)
        Me.GroupBox3.Controls.Add(Me.txtcanttemp)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.txtrangoyseco)
        Me.GroupBox3.Controls.Add(Me.txtrangoxseco)
        Me.GroupBox3.Controls.Add(Me.txtrangoyrefri)
        Me.GroupBox3.Controls.Add(Me.txtranngoxrefri)
        Me.GroupBox3.Controls.Add(Me.txtrangoycong)
        Me.GroupBox3.Controls.Add(Me.txtrangoxcong)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.ForeColor = System.Drawing.Color.White
        Me.GroupBox3.Location = New System.Drawing.Point(12, 424)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(406, 154)
        Me.GroupBox3.TabIndex = 122
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Rango temperaturas"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(226, 23)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(27, 13)
        Me.Label7.TabIndex = 126
        Me.Label7.Text = "Max"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(152, 23)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(27, 13)
        Me.Label6.TabIndex = 125
        Me.Label6.Text = "Min."
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.Transparent
        Me.Button4.FlatAppearance.BorderSize = 0
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_guardar2
        Me.Button4.Location = New System.Drawing.Point(320, 64)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(80, 78)
        Me.Button4.TabIndex = 124
        Me.Button4.UseVisualStyleBackColor = False
        '
        'txtcanttemp
        '
        Me.txtcanttemp.Location = New System.Drawing.Point(251, 122)
        Me.txtcanttemp.Name = "txtcanttemp"
        Me.txtcanttemp.Size = New System.Drawing.Size(46, 20)
        Me.txtcanttemp.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(21, 129)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(224, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "CANTIDAD DE TEMPERATURAS A TOMAR"
        '
        'txtrangoyseco
        '
        Me.txtrangoyseco.Location = New System.Drawing.Point(229, 85)
        Me.txtrangoyseco.Name = "txtrangoyseco"
        Me.txtrangoyseco.Size = New System.Drawing.Size(68, 20)
        Me.txtrangoyseco.TabIndex = 8
        '
        'txtrangoxseco
        '
        Me.txtrangoxseco.Location = New System.Drawing.Point(155, 85)
        Me.txtrangoxseco.Name = "txtrangoxseco"
        Me.txtrangoxseco.Size = New System.Drawing.Size(68, 20)
        Me.txtrangoxseco.TabIndex = 7
        '
        'txtrangoyrefri
        '
        Me.txtrangoyrefri.Location = New System.Drawing.Point(229, 62)
        Me.txtrangoyrefri.Name = "txtrangoyrefri"
        Me.txtrangoyrefri.Size = New System.Drawing.Size(68, 20)
        Me.txtrangoyrefri.TabIndex = 6
        '
        'txtranngoxrefri
        '
        Me.txtranngoxrefri.Location = New System.Drawing.Point(155, 62)
        Me.txtranngoxrefri.Name = "txtranngoxrefri"
        Me.txtranngoxrefri.Size = New System.Drawing.Size(68, 20)
        Me.txtranngoxrefri.TabIndex = 5
        '
        'txtrangoycong
        '
        Me.txtrangoycong.Location = New System.Drawing.Point(229, 39)
        Me.txtrangoycong.Name = "txtrangoycong"
        Me.txtrangoycong.Size = New System.Drawing.Size(68, 20)
        Me.txtrangoycong.TabIndex = 4
        '
        'txtrangoxcong
        '
        Me.txtrangoxcong.Location = New System.Drawing.Point(155, 39)
        Me.txtrangoxcong.Name = "txtrangoxcong"
        Me.txtrangoxcong.Size = New System.Drawing.Size(68, 20)
        Me.txtrangoxcong.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(21, 88)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "SECO"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(21, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "REFRIGERADO"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "CONGELADO"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Button5)
        Me.GroupBox4.Controls.Add(Me.Label5)
        Me.GroupBox4.Controls.Add(Me.txtmaxkil)
        Me.GroupBox4.ForeColor = System.Drawing.Color.White
        Me.GroupBox4.Location = New System.Drawing.Point(424, 22)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(406, 108)
        Me.GroupBox4.TabIndex = 123
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "KILOS MAXIMOS RECEPCION"
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.Transparent
        Me.Button5.FlatAppearance.BorderSize = 0
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_guardar2
        Me.Button5.Location = New System.Drawing.Point(326, 25)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(80, 78)
        Me.Button5.TabIndex = 125
        Me.Button5.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(21, 39)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 13)
        Me.Label5.TabIndex = 125
        Me.Label5.Text = "PESO MAX"
        '
        'txtmaxkil
        '
        Me.txtmaxkil.Location = New System.Drawing.Point(23, 55)
        Me.txtmaxkil.Name = "txtmaxkil"
        Me.txtmaxkil.Size = New System.Drawing.Size(83, 20)
        Me.txtmaxkil.TabIndex = 125
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Label8)
        Me.GroupBox5.Controls.Add(Me.TXTCANTIMP)
        Me.GroupBox5.Controls.Add(Me.Button6)
        Me.GroupBox5.ForeColor = System.Drawing.Color.White
        Me.GroupBox5.Location = New System.Drawing.Point(424, 136)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(406, 110)
        Me.GroupBox5.TabIndex = 124
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "CANTIDAD DE ETIQUETAS SOPORTANTES A IMPRIMIR"
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.Color.Transparent
        Me.Button6.FlatAppearance.BorderSize = 0
        Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button6.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_guardar2
        Me.Button6.Location = New System.Drawing.Point(320, 19)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(80, 78)
        Me.Button6.TabIndex = 126
        Me.Button6.UseVisualStyleBackColor = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(20, 29)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(36, 13)
        Me.Label8.TabIndex = 127
        Me.Label8.Text = "CANT"
        '
        'TXTCANTIMP
        '
        Me.TXTCANTIMP.Location = New System.Drawing.Point(22, 45)
        Me.TXTCANTIMP.Name = "TXTCANTIMP"
        Me.TXTCANTIMP.Size = New System.Drawing.Size(83, 20)
        Me.TXTCANTIMP.TabIndex = 126
        '
        'ConfGENE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(895, 733)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "ConfGENE"
        Me.Text = "Configuraciones Generales "
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rdno As System.Windows.Forms.RadioButton
    Friend WithEvents rdsi As System.Windows.Forms.RadioButton
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents txtcodigo As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents txtcanttemp As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtrangoyseco As System.Windows.Forms.TextBox
    Friend WithEvents txtrangoxseco As System.Windows.Forms.TextBox
    Friend WithEvents txtrangoyrefri As System.Windows.Forms.TextBox
    Friend WithEvents txtranngoxrefri As System.Windows.Forms.TextBox
    Friend WithEvents txtrangoycong As System.Windows.Forms.TextBox
    Friend WithEvents txtrangoxcong As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtmaxkil As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TXTCANTIMP As System.Windows.Forms.TextBox
    Friend WithEvents Button6 As System.Windows.Forms.Button
End Class

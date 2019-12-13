<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_ConfInicialCamaras
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
        Me.txtNombreCam = New System.Windows.Forms.TextBox()
        Me.TxtCodCamara = New System.Windows.Forms.TextBox()
        Me.txtCol = New System.Windows.Forms.TextBox()
        Me.TxtBand = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.chk_drivein = New System.Windows.Forms.CheckBox()
        Me.chk_rackselect = New System.Windows.Forms.CheckBox()
        Me.chk_pushback = New System.Windows.Forms.CheckBox()
        Me.chk_apiso = New System.Windows.Forms.CheckBox()
        Me.RS = New System.Windows.Forms.Button()
        Me.PB = New System.Windows.Forms.Button()
        Me.DI = New System.Windows.Forms.Button()
        Me.APISO = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chk_libre = New System.Windows.Forms.CheckBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtpisomax = New System.Windows.Forms.TextBox()
        Me.txtalturap = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.p1 = New System.Windows.Forms.RadioButton()
        Me.p3 = New System.Windows.Forms.RadioButton()
        Me.p6 = New System.Windows.Forms.RadioButton()
        Me.p8 = New System.Windows.Forms.RadioButton()
        Me.p2 = New System.Windows.Forms.RadioButton()
        Me.p7 = New System.Windows.Forms.RadioButton()
        Me.p5 = New System.Windows.Forms.RadioButton()
        Me.p4 = New System.Windows.Forms.RadioButton()
        Me.cboprefpos = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rb_S = New System.Windows.Forms.RadioButton()
        Me.rb_C = New System.Windows.Forms.RadioButton()
        Me.rb_R = New System.Windows.Forms.RadioButton()
        Me.chktransito = New System.Windows.Forms.CheckBox()
        Me.chkzonaped = New System.Windows.Forms.CheckBox()
        Me.BtnOrigen = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btn_guardar = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtNombreCam
        '
        Me.txtNombreCam.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombreCam.Location = New System.Drawing.Point(122, 60)
        Me.txtNombreCam.Name = "txtNombreCam"
        Me.txtNombreCam.Size = New System.Drawing.Size(179, 20)
        Me.txtNombreCam.TabIndex = 0
        '
        'TxtCodCamara
        '
        Me.TxtCodCamara.Location = New System.Drawing.Point(122, 30)
        Me.TxtCodCamara.Name = "TxtCodCamara"
        Me.TxtCodCamara.Size = New System.Drawing.Size(100, 20)
        Me.TxtCodCamara.TabIndex = 1
        '
        'txtCol
        '
        Me.txtCol.Location = New System.Drawing.Point(122, 90)
        Me.txtCol.Name = "txtCol"
        Me.txtCol.Size = New System.Drawing.Size(48, 20)
        Me.txtCol.TabIndex = 2
        '
        'TxtBand
        '
        Me.TxtBand.Location = New System.Drawing.Point(122, 119)
        Me.TxtBand.Name = "TxtBand"
        Me.TxtBand.Size = New System.Drawing.Size(48, 20)
        Me.TxtBand.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label1.Location = New System.Drawing.Point(12, 67)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Descripción"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label2.Location = New System.Drawing.Point(12, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(18, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "ID"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label3.Location = New System.Drawing.Point(12, 97)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Columnas"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label4.Location = New System.Drawing.Point(12, 126)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Bandas"
        '
        'chk_drivein
        '
        Me.chk_drivein.AutoSize = True
        Me.chk_drivein.Location = New System.Drawing.Point(82, 147)
        Me.chk_drivein.Name = "chk_drivein"
        Me.chk_drivein.Size = New System.Drawing.Size(73, 17)
        Me.chk_drivein.TabIndex = 2019
        Me.chk_drivein.Text = "DRIVE IN"
        Me.chk_drivein.UseVisualStyleBackColor = True
        '
        'chk_rackselect
        '
        Me.chk_rackselect.AutoSize = True
        Me.chk_rackselect.Location = New System.Drawing.Point(82, 101)
        Me.chk_rackselect.Name = "chk_rackselect"
        Me.chk_rackselect.Size = New System.Drawing.Size(99, 17)
        Me.chk_rackselect.TabIndex = 2018
        Me.chk_rackselect.Text = "RACK SELECT"
        Me.chk_rackselect.UseVisualStyleBackColor = True
        '
        'chk_pushback
        '
        Me.chk_pushback.AutoSize = True
        Me.chk_pushback.Location = New System.Drawing.Point(82, 217)
        Me.chk_pushback.Name = "chk_pushback"
        Me.chk_pushback.Size = New System.Drawing.Size(87, 17)
        Me.chk_pushback.TabIndex = 2017
        Me.chk_pushback.Text = "PUSH BACK"
        Me.chk_pushback.UseVisualStyleBackColor = True
        Me.chk_pushback.Visible = False
        '
        'chk_apiso
        '
        Me.chk_apiso.AutoSize = True
        Me.chk_apiso.Location = New System.Drawing.Point(82, 55)
        Me.chk_apiso.Name = "chk_apiso"
        Me.chk_apiso.Size = New System.Drawing.Size(61, 17)
        Me.chk_apiso.TabIndex = 2016
        Me.chk_apiso.Text = "A PISO"
        Me.chk_apiso.UseVisualStyleBackColor = True
        '
        'RS
        '
        Me.RS.BackColor = System.Drawing.Color.Orange
        Me.RS.Enabled = False
        Me.RS.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RS.Location = New System.Drawing.Point(36, 88)
        Me.RS.Name = "RS"
        Me.RS.Size = New System.Drawing.Size(40, 40)
        Me.RS.TabIndex = 2015
        Me.RS.UseVisualStyleBackColor = False
        '
        'PB
        '
        Me.PB.BackColor = System.Drawing.Color.Pink
        Me.PB.Enabled = False
        Me.PB.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.PB.Location = New System.Drawing.Point(36, 204)
        Me.PB.Name = "PB"
        Me.PB.Size = New System.Drawing.Size(40, 40)
        Me.PB.TabIndex = 2014
        Me.PB.UseVisualStyleBackColor = False
        Me.PB.Visible = False
        '
        'DI
        '
        Me.DI.BackColor = System.Drawing.Color.Blue
        Me.DI.Enabled = False
        Me.DI.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.DI.Location = New System.Drawing.Point(36, 134)
        Me.DI.Name = "DI"
        Me.DI.Size = New System.Drawing.Size(40, 40)
        Me.DI.TabIndex = 2013
        Me.DI.UseVisualStyleBackColor = False
        '
        'APISO
        '
        Me.APISO.BackColor = System.Drawing.Color.Yellow
        Me.APISO.Enabled = False
        Me.APISO.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.APISO.Location = New System.Drawing.Point(36, 42)
        Me.APISO.Name = "APISO"
        Me.APISO.Size = New System.Drawing.Size(40, 40)
        Me.APISO.TabIndex = 2012
        Me.APISO.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chk_libre)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.APISO)
        Me.GroupBox1.Controls.Add(Me.chk_drivein)
        Me.GroupBox1.Controls.Add(Me.DI)
        Me.GroupBox1.Controls.Add(Me.chk_rackselect)
        Me.GroupBox1.Controls.Add(Me.PB)
        Me.GroupBox1.Controls.Add(Me.chk_pushback)
        Me.GroupBox1.Controls.Add(Me.RS)
        Me.GroupBox1.Controls.Add(Me.chk_apiso)
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.GroupBox1.Location = New System.Drawing.Point(15, 216)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(210, 263)
        Me.GroupBox1.TabIndex = 2020
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Tipo"
        '
        'chk_libre
        '
        Me.chk_libre.AutoSize = True
        Me.chk_libre.Location = New System.Drawing.Point(82, 194)
        Me.chk_libre.Name = "chk_libre"
        Me.chk_libre.Size = New System.Drawing.Size(57, 17)
        Me.chk_libre.TabIndex = 2021
        Me.chk_libre.Text = "LIBRE"
        Me.chk_libre.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.White
        Me.Button1.Enabled = False
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(36, 181)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(40, 40)
        Me.Button1.TabIndex = 2020
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label5.Location = New System.Drawing.Point(12, 183)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 13)
        Me.Label5.TabIndex = 2025
        Me.Label5.Text = "Pisos Maximos"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label6.Location = New System.Drawing.Point(12, 154)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(81, 13)
        Me.Label6.TabIndex = 2024
        Me.Label6.Text = "Altura Promedio"
        '
        'txtpisomax
        '
        Me.txtpisomax.Location = New System.Drawing.Point(122, 176)
        Me.txtpisomax.Name = "txtpisomax"
        Me.txtpisomax.Size = New System.Drawing.Size(48, 20)
        Me.txtpisomax.TabIndex = 2023
        '
        'txtalturap
        '
        Me.txtalturap.Location = New System.Drawing.Point(122, 147)
        Me.txtalturap.Name = "txtalturap"
        Me.txtalturap.Size = New System.Drawing.Size(48, 20)
        Me.txtalturap.TabIndex = 2022
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label7.Location = New System.Drawing.Point(334, 37)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(83, 13)
        Me.Label7.TabIndex = 2027
        Me.Label7.Text = "Entrada Camara"
        '
        'p1
        '
        Me.p1.AutoSize = True
        Me.p1.Location = New System.Drawing.Point(337, 70)
        Me.p1.Name = "p1"
        Me.p1.Size = New System.Drawing.Size(14, 13)
        Me.p1.TabIndex = 2028
        Me.p1.TabStop = True
        Me.p1.UseVisualStyleBackColor = True
        '
        'p3
        '
        Me.p3.AutoSize = True
        Me.p3.Location = New System.Drawing.Point(753, 70)
        Me.p3.Name = "p3"
        Me.p3.Size = New System.Drawing.Size(14, 13)
        Me.p3.TabIndex = 2029
        Me.p3.TabStop = True
        Me.p3.UseVisualStyleBackColor = True
        '
        'p6
        '
        Me.p6.AutoSize = True
        Me.p6.Location = New System.Drawing.Point(337, 555)
        Me.p6.Name = "p6"
        Me.p6.Size = New System.Drawing.Size(14, 13)
        Me.p6.TabIndex = 2030
        Me.p6.TabStop = True
        Me.p6.UseVisualStyleBackColor = True
        '
        'p8
        '
        Me.p8.AutoSize = True
        Me.p8.Location = New System.Drawing.Point(753, 555)
        Me.p8.Name = "p8"
        Me.p8.Size = New System.Drawing.Size(14, 13)
        Me.p8.TabIndex = 2031
        Me.p8.TabStop = True
        Me.p8.UseVisualStyleBackColor = True
        '
        'p2
        '
        Me.p2.AutoSize = True
        Me.p2.Location = New System.Drawing.Point(543, 70)
        Me.p2.Name = "p2"
        Me.p2.Size = New System.Drawing.Size(14, 13)
        Me.p2.TabIndex = 2032
        Me.p2.TabStop = True
        Me.p2.UseVisualStyleBackColor = True
        '
        'p7
        '
        Me.p7.AutoSize = True
        Me.p7.Location = New System.Drawing.Point(543, 555)
        Me.p7.Name = "p7"
        Me.p7.Size = New System.Drawing.Size(14, 13)
        Me.p7.TabIndex = 2033
        Me.p7.TabStop = True
        Me.p7.UseVisualStyleBackColor = True
        '
        'p5
        '
        Me.p5.AutoSize = True
        Me.p5.Location = New System.Drawing.Point(773, 315)
        Me.p5.Name = "p5"
        Me.p5.Size = New System.Drawing.Size(14, 13)
        Me.p5.TabIndex = 2034
        Me.p5.TabStop = True
        Me.p5.UseVisualStyleBackColor = True
        '
        'p4
        '
        Me.p4.AutoSize = True
        Me.p4.Location = New System.Drawing.Point(317, 315)
        Me.p4.Name = "p4"
        Me.p4.Size = New System.Drawing.Size(14, 13)
        Me.p4.TabIndex = 2035
        Me.p4.TabStop = True
        Me.p4.UseVisualStyleBackColor = True
        '
        'cboprefpos
        '
        Me.cboprefpos.FormattingEnabled = True
        Me.cboprefpos.Items.AddRange(New Object() {"ASCENDENTE", "DESCENDENTE"})
        Me.cboprefpos.Location = New System.Drawing.Point(629, 605)
        Me.cboprefpos.Name = "cboprefpos"
        Me.cboprefpos.Size = New System.Drawing.Size(138, 21)
        Me.cboprefpos.TabIndex = 2036
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label8.Location = New System.Drawing.Point(626, 589)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(141, 13)
        Me.Label8.TabIndex = 2037
        Me.Label8.Text = "Preferencia Posicionamiento"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rb_S)
        Me.GroupBox2.Controls.Add(Me.rb_C)
        Me.GroupBox2.Controls.Add(Me.rb_R)
        Me.GroupBox2.ForeColor = System.Drawing.Color.White
        Me.GroupBox2.Location = New System.Drawing.Point(15, 555)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(210, 138)
        Me.GroupBox2.TabIndex = 2038
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Tipo Almacenamiento"
        '
        'rb_S
        '
        Me.rb_S.AutoSize = True
        Me.rb_S.Location = New System.Drawing.Point(19, 97)
        Me.rb_S.Name = "rb_S"
        Me.rb_S.Size = New System.Drawing.Size(54, 17)
        Me.rb_S.TabIndex = 2
        Me.rb_S.TabStop = True
        Me.rb_S.Text = "SECO"
        Me.rb_S.UseVisualStyleBackColor = True
        '
        'rb_C
        '
        Me.rb_C.AutoSize = True
        Me.rb_C.Location = New System.Drawing.Point(19, 34)
        Me.rb_C.Name = "rb_C"
        Me.rb_C.Size = New System.Drawing.Size(92, 17)
        Me.rb_C.TabIndex = 1
        Me.rb_C.TabStop = True
        Me.rb_C.Text = "CONGELADO"
        Me.rb_C.UseVisualStyleBackColor = True
        '
        'rb_R
        '
        Me.rb_R.AutoSize = True
        Me.rb_R.Location = New System.Drawing.Point(19, 66)
        Me.rb_R.Name = "rb_R"
        Me.rb_R.Size = New System.Drawing.Size(103, 17)
        Me.rb_R.TabIndex = 0
        Me.rb_R.TabStop = True
        Me.rb_R.Text = "REFRIGERADO"
        Me.rb_R.UseVisualStyleBackColor = True
        '
        'chktransito
        '
        Me.chktransito.AutoSize = True
        Me.chktransito.ForeColor = System.Drawing.Color.White
        Me.chktransito.Location = New System.Drawing.Point(15, 500)
        Me.chktransito.Name = "chktransito"
        Me.chktransito.Size = New System.Drawing.Size(147, 17)
        Me.chktransito.TabIndex = 2039
        Me.chktransito.Text = "CAMARA EN TRANSITO"
        Me.chktransito.UseVisualStyleBackColor = True
        '
        'chkzonaped
        '
        Me.chkzonaped.AutoSize = True
        Me.chkzonaped.ForeColor = System.Drawing.Color.White
        Me.chkzonaped.Location = New System.Drawing.Point(15, 523)
        Me.chkzonaped.Name = "chkzonaped"
        Me.chkzonaped.Size = New System.Drawing.Size(128, 17)
        Me.chkzonaped.TabIndex = 2040
        Me.chkzonaped.Text = "ZONA DE PEDIDOS "
        Me.chkzonaped.UseVisualStyleBackColor = True
        '
        'BtnOrigen
        '
        Me.BtnOrigen.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.buscar_24
        Me.BtnOrigen.Location = New System.Drawing.Point(228, 28)
        Me.BtnOrigen.Name = "BtnOrigen"
        Me.BtnOrigen.Size = New System.Drawing.Size(23, 23)
        Me.BtnOrigen.TabIndex = 2041
        Me.BtnOrigen.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.camara
        Me.PictureBox1.Location = New System.Drawing.Point(337, 89)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(430, 460)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 2026
        Me.PictureBox1.TabStop = False
        '
        'btn_guardar
        '
        Me.btn_guardar.FlatAppearance.BorderSize = 0
        Me.btn_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_guardar.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_guardar2
        Me.btn_guardar.Location = New System.Drawing.Point(704, 662)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(63, 63)
        Me.btn_guardar.TabIndex = 2021
        Me.btn_guardar.UseVisualStyleBackColor = True
        '
        'Frm_ConfInicialCamaras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(811, 737)
        Me.Controls.Add(Me.BtnOrigen)
        Me.Controls.Add(Me.chkzonaped)
        Me.Controls.Add(Me.chktransito)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cboprefpos)
        Me.Controls.Add(Me.p4)
        Me.Controls.Add(Me.p5)
        Me.Controls.Add(Me.p7)
        Me.Controls.Add(Me.p2)
        Me.Controls.Add(Me.p8)
        Me.Controls.Add(Me.p6)
        Me.Controls.Add(Me.p3)
        Me.Controls.Add(Me.p1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtpisomax)
        Me.Controls.Add(Me.txtalturap)
        Me.Controls.Add(Me.btn_guardar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtBand)
        Me.Controls.Add(Me.txtCol)
        Me.Controls.Add(Me.TxtCodCamara)
        Me.Controls.Add(Me.txtNombreCam)
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Name = "Frm_ConfInicialCamaras"
        Me.Text = "Configuracion Inicial Camaras"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtNombreCam As System.Windows.Forms.TextBox
    Friend WithEvents TxtCodCamara As System.Windows.Forms.TextBox
    Friend WithEvents txtCol As System.Windows.Forms.TextBox
    Friend WithEvents TxtBand As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents chk_drivein As System.Windows.Forms.CheckBox
    Friend WithEvents chk_rackselect As System.Windows.Forms.CheckBox
    Friend WithEvents chk_pushback As System.Windows.Forms.CheckBox
    Friend WithEvents chk_apiso As System.Windows.Forms.CheckBox
    Friend WithEvents RS As System.Windows.Forms.Button
    Friend WithEvents PB As System.Windows.Forms.Button
    Friend WithEvents DI As System.Windows.Forms.Button
    Friend WithEvents APISO As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtpisomax As System.Windows.Forms.TextBox
    Friend WithEvents txtalturap As System.Windows.Forms.TextBox
    Friend WithEvents chk_libre As System.Windows.Forms.CheckBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents p1 As System.Windows.Forms.RadioButton
    Friend WithEvents p3 As System.Windows.Forms.RadioButton
    Friend WithEvents p6 As System.Windows.Forms.RadioButton
    Friend WithEvents p8 As System.Windows.Forms.RadioButton
    Friend WithEvents p2 As System.Windows.Forms.RadioButton
    Friend WithEvents p7 As System.Windows.Forms.RadioButton
    Friend WithEvents p5 As System.Windows.Forms.RadioButton
    Friend WithEvents p4 As System.Windows.Forms.RadioButton
    Friend WithEvents cboprefpos As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rb_S As System.Windows.Forms.RadioButton
    Friend WithEvents rb_C As System.Windows.Forms.RadioButton
    Friend WithEvents rb_R As System.Windows.Forms.RadioButton
    Friend WithEvents chktransito As System.Windows.Forms.CheckBox
    Friend WithEvents chkzonaped As System.Windows.Forms.CheckBox
    Friend WithEvents BtnOrigen As System.Windows.Forms.Button
End Class

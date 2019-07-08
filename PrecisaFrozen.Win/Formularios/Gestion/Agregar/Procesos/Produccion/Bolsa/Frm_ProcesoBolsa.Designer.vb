<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_ProcesoBolsa
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.ELIM = New System.Windows.Forms.DataGridViewImageColumn()
        Me.txtcodrece = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblcliente = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtpallet = New System.Windows.Forms.TextBox()
        Me.txtlote = New System.Windows.Forms.TextBox()
        Me.DgvResultado = New System.Windows.Forms.DataGridView()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtbandejas = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtkilos = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TXTLOCAL = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtcodigo = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtkiloetiq = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.dtp_fecter = New System.Windows.Forms.DateTimePicker()
        Me.txtproducto = New System.Windows.Forms.TextBox()
        Me.dtp_fecini = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.txtkilosn = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtsacos = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.fvencimiento = New System.Windows.Forms.DateTimePicker()
        Me.felaboracion = New System.Windows.Forms.DateTimePicker()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.DgvResultado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ELIM})
        Me.DataGridView1.Location = New System.Drawing.Point(6, 240)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(228, 262)
        Me.DataGridView1.TabIndex = 109
        '
        'ELIM
        '
        Me.ELIM.HeaderText = "ELIMINAR"
        Me.ELIM.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.Eliminar_16
        Me.ELIM.Name = "ELIM"
        Me.ELIM.ReadOnly = True
        Me.ELIM.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ELIM.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.ELIM.Width = 65
        '
        'txtcodrece
        '
        Me.txtcodrece.Location = New System.Drawing.Point(134, 64)
        Me.txtcodrece.MaxLength = 7
        Me.txtcodrece.Name = "txtcodrece"
        Me.txtcodrece.Size = New System.Drawing.Size(97, 20)
        Me.txtcodrece.TabIndex = 111
        Me.txtcodrece.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(15, 63)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 20)
        Me.Label1.TabIndex = 110
        Me.Label1.Text = "RECEPCION"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(295, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 13)
        Me.Label2.TabIndex = 112
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Panel1.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.barra
        Me.Panel1.Controls.Add(Me.lblcliente)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Location = New System.Drawing.Point(-6, 10)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(626, 37)
        Me.Panel1.TabIndex = 113
        '
        'lblcliente
        '
        Me.lblcliente.AutoSize = True
        Me.lblcliente.Location = New System.Drawing.Point(444, 13)
        Me.lblcliente.Name = "lblcliente"
        Me.lblcliente.Size = New System.Drawing.Size(0, 13)
        Me.lblcliente.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(18, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "PROCESO JIBIA "
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(15, 442)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 20)
        Me.Label4.TabIndex = 114
        Me.Label4.Text = "PALLET"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(15, 93)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 20)
        Me.Label5.TabIndex = 115
        Me.Label5.Text = "LOTE"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtpallet
        '
        Me.txtpallet.Enabled = False
        Me.txtpallet.Location = New System.Drawing.Point(134, 442)
        Me.txtpallet.MaxLength = 7
        Me.txtpallet.Name = "txtpallet"
        Me.txtpallet.Size = New System.Drawing.Size(97, 20)
        Me.txtpallet.TabIndex = 116
        Me.txtpallet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtlote
        '
        Me.txtlote.Enabled = False
        Me.txtlote.Location = New System.Drawing.Point(134, 91)
        Me.txtlote.MaxLength = 7
        Me.txtlote.Name = "txtlote"
        Me.txtlote.Size = New System.Drawing.Size(97, 20)
        Me.txtlote.TabIndex = 117
        Me.txtlote.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'DgvResultado
        '
        Me.DgvResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvResultado.Location = New System.Drawing.Point(12, 117)
        Me.DgvResultado.Name = "DgvResultado"
        Me.DgvResultado.Size = New System.Drawing.Size(219, 307)
        Me.DgvResultado.TabIndex = 108
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(15, 502)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(71, 20)
        Me.Label6.TabIndex = 120
        Me.Label6.Text = "KILOS"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbandejas
        '
        Me.txtbandejas.Enabled = False
        Me.txtbandejas.Location = New System.Drawing.Point(134, 473)
        Me.txtbandejas.MaxLength = 7
        Me.txtbandejas.Name = "txtbandejas"
        Me.txtbandejas.Size = New System.Drawing.Size(97, 20)
        Me.txtbandejas.TabIndex = 119
        Me.txtbandejas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(15, 472)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(71, 20)
        Me.Label7.TabIndex = 118
        Me.Label7.Text = "BANDEJAS"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtkilos
        '
        Me.txtkilos.Enabled = False
        Me.txtkilos.Location = New System.Drawing.Point(134, 502)
        Me.txtkilos.MaxLength = 7
        Me.txtkilos.Name = "txtkilos"
        Me.txtkilos.Size = New System.Drawing.Size(97, 20)
        Me.txtkilos.TabIndex = 121
        Me.txtkilos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(6, 198)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(228, 38)
        Me.Button1.TabIndex = 122
        Me.Button1.Text = "ETIQUETAR"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.TXTLOCAL)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.txtcodigo)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.txtkiloetiq)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.dtp_fecter)
        Me.GroupBox1.Controls.Add(Me.txtproducto)
        Me.GroupBox1.Controls.Add(Me.dtp_fecini)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.DataGridView1)
        Me.GroupBox1.Location = New System.Drawing.Point(264, 64)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(251, 508)
        Me.GroupBox1.TabIndex = 123
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Etiquetado"
        '
        'TXTLOCAL
        '
        Me.TXTLOCAL.Location = New System.Drawing.Point(127, 171)
        Me.TXTLOCAL.Name = "TXTLOCAL"
        Me.TXTLOCAL.Size = New System.Drawing.Size(96, 20)
        Me.TXTLOCAL.TabIndex = 143
        '
        'Label15
        '
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label15.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Transparent
        Me.Label15.Location = New System.Drawing.Point(8, 171)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(71, 20)
        Me.Label15.TabIndex = 142
        Me.Label15.Text = "LOCAL"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtcodigo
        '
        Me.txtcodigo.Enabled = False
        Me.txtcodigo.Location = New System.Drawing.Point(127, 143)
        Me.txtcodigo.MaxLength = 11
        Me.txtcodigo.Name = "txtcodigo"
        Me.txtcodigo.Size = New System.Drawing.Size(97, 20)
        Me.txtcodigo.TabIndex = 141
        Me.txtcodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label12.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Transparent
        Me.Label12.Location = New System.Drawing.Point(8, 114)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(71, 20)
        Me.Label12.TabIndex = 140
        Me.Label12.Text = "KILOS"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Transparent
        Me.Label11.Location = New System.Drawing.Point(8, 143)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(71, 20)
        Me.Label11.TabIndex = 139
        Me.Label11.Text = "CODIGO"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtkiloetiq
        '
        Me.txtkiloetiq.Location = New System.Drawing.Point(126, 114)
        Me.txtkiloetiq.MaxLength = 7
        Me.txtkiloetiq.Name = "txtkiloetiq"
        Me.txtkiloetiq.Size = New System.Drawing.Size(97, 20)
        Me.txtkiloetiq.TabIndex = 138
        Me.txtkiloetiq.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Transparent
        Me.Label10.Location = New System.Drawing.Point(8, 87)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(71, 20)
        Me.Label10.TabIndex = 137
        Me.Label10.Text = "FECHA VEN"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtp_fecter
        '
        Me.dtp_fecter.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecter.Location = New System.Drawing.Point(127, 87)
        Me.dtp_fecter.Name = "dtp_fecter"
        Me.dtp_fecter.Size = New System.Drawing.Size(96, 20)
        Me.dtp_fecter.TabIndex = 136
        '
        'txtproducto
        '
        Me.txtproducto.Enabled = False
        Me.txtproducto.Location = New System.Drawing.Point(127, 29)
        Me.txtproducto.MaxLength = 7
        Me.txtproducto.Name = "txtproducto"
        Me.txtproducto.Size = New System.Drawing.Size(97, 20)
        Me.txtproducto.TabIndex = 125
        Me.txtproducto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dtp_fecini
        '
        Me.dtp_fecini.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_fecini.Location = New System.Drawing.Point(127, 58)
        Me.dtp_fecini.Name = "dtp_fecini"
        Me.dtp_fecini.Size = New System.Drawing.Size(96, 20)
        Me.dtp_fecini.TabIndex = 135
        '
        'Label8
        '
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(8, 58)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(71, 20)
        Me.Label8.TabIndex = 126
        Me.Label8.Text = "FECHA ELA"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(8, 28)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(71, 20)
        Me.Label9.TabIndex = 124
        Me.Label9.Text = "PRODUCTO"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(428, 648)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(70, 45)
        Me.Button2.TabIndex = 142
        Me.Button2.Text = "CERRAR"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'txtkilosn
        '
        Me.txtkilosn.Enabled = False
        Me.txtkilosn.Location = New System.Drawing.Point(401, 610)
        Me.txtkilosn.MaxLength = 7
        Me.txtkilosn.Name = "txtkilosn"
        Me.txtkilosn.Size = New System.Drawing.Size(97, 20)
        Me.txtkilosn.TabIndex = 146
        Me.txtkilosn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label13.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(282, 610)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(71, 20)
        Me.Label13.TabIndex = 145
        Me.Label13.Text = "KILOS N"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtsacos
        '
        Me.txtsacos.Enabled = False
        Me.txtsacos.Location = New System.Drawing.Point(401, 581)
        Me.txtsacos.MaxLength = 7
        Me.txtsacos.Name = "txtsacos"
        Me.txtsacos.Size = New System.Drawing.Size(97, 20)
        Me.txtsacos.TabIndex = 144
        Me.txtsacos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label14.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(282, 580)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(71, 20)
        Me.Label14.TabIndex = 143
        Me.Label14.Text = "SACOS"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'fvencimiento
        '
        Me.fvencimiento.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.fvencimiento.Location = New System.Drawing.Point(123, 552)
        Me.fvencimiento.Name = "fvencimiento"
        Me.fvencimiento.Size = New System.Drawing.Size(108, 20)
        Me.fvencimiento.TabIndex = 148
        Me.fvencimiento.Visible = False
        '
        'felaboracion
        '
        Me.felaboracion.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.felaboracion.Location = New System.Drawing.Point(123, 528)
        Me.felaboracion.Name = "felaboracion"
        Me.felaboracion.Size = New System.Drawing.Size(108, 20)
        Me.felaboracion.TabIndex = 147
        Me.felaboracion.Visible = False
        '
        'Frm_ProcesoBolsa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(540, 713)
        Me.Controls.Add(Me.fvencimiento)
        Me.Controls.Add(Me.felaboracion)
        Me.Controls.Add(Me.txtkilosn)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtsacos)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtkilos)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtbandejas)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtlote)
        Me.Controls.Add(Me.txtpallet)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtcodrece)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DgvResultado)
        Me.Name = "Frm_ProcesoBolsa"
        Me.Text = "PROCESO JIBIA"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DgvResultado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents txtcodrece As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtpallet As System.Windows.Forms.TextBox
    Friend WithEvents txtlote As System.Windows.Forms.TextBox
    Friend WithEvents DgvResultado As System.Windows.Forms.DataGridView
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtbandejas As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtkilos As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtcodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtkiloetiq As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents dtp_fecter As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_fecini As System.Windows.Forms.DateTimePicker
    Private WithEvents txtproducto As System.Windows.Forms.TextBox
    Friend WithEvents ELIM As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents txtkilosn As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtsacos As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lblcliente As System.Windows.Forms.Label
    Friend WithEvents fvencimiento As System.Windows.Forms.DateTimePicker
    Friend WithEvents felaboracion As System.Windows.Forms.DateTimePicker
    Friend WithEvents TXTLOCAL As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
End Class

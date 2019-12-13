<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPedidosUsuarios
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
        Me.DgvResultado = New System.Windows.Forms.DataGridView()
        Me.txtcodigo = New System.Windows.Forms.TextBox()
        Me.TxtNom1 = New System.Windows.Forms.TextBox()
        Me.Btn_BuscaUsuarios = New System.Windows.Forms.Button()
        Me.txtrutv = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtrut = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Btn_Buscar = New System.Windows.Forms.Button()
        Me.TxtAp = New System.Windows.Forms.TextBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtnc = New System.Windows.Forms.TextBox()
        Me.txtok = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblefe = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.dtp_fecter = New System.Windows.Forms.DateTimePicker()
        Me.dtp_fecini = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        CType(Me.DgvResultado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DgvResultado
        '
        Me.DgvResultado.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark
        Me.DgvResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvResultado.Location = New System.Drawing.Point(12, 102)
        Me.DgvResultado.Name = "DgvResultado"
        Me.DgvResultado.Size = New System.Drawing.Size(1060, 410)
        Me.DgvResultado.TabIndex = 107
        '
        'txtcodigo
        '
        Me.txtcodigo.Location = New System.Drawing.Point(248, 34)
        Me.txtcodigo.Name = "txtcodigo"
        Me.txtcodigo.ReadOnly = True
        Me.txtcodigo.Size = New System.Drawing.Size(69, 20)
        Me.txtcodigo.TabIndex = 114
        '
        'TxtNom1
        '
        Me.TxtNom1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNom1.Location = New System.Drawing.Point(99, 60)
        Me.TxtNom1.Name = "TxtNom1"
        Me.TxtNom1.Size = New System.Drawing.Size(99, 20)
        Me.TxtNom1.TabIndex = 112
        '
        'Btn_BuscaUsuarios
        '
        Me.Btn_BuscaUsuarios.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.buscar_24
        Me.Btn_BuscaUsuarios.Location = New System.Drawing.Point(204, 32)
        Me.Btn_BuscaUsuarios.Name = "Btn_BuscaUsuarios"
        Me.Btn_BuscaUsuarios.Size = New System.Drawing.Size(26, 22)
        Me.Btn_BuscaUsuarios.TabIndex = 113
        Me.Btn_BuscaUsuarios.UseVisualStyleBackColor = True
        '
        'txtrutv
        '
        Me.txtrutv.Location = New System.Drawing.Point(175, 33)
        Me.txtrutv.MaxLength = 1
        Me.txtrutv.Name = "txtrutv"
        Me.txtrutv.Size = New System.Drawing.Size(23, 20)
        Me.txtrutv.TabIndex = 111
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(12, 63)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 13)
        Me.Label2.TabIndex = 109
        Me.Label2.Text = "NOMBRE"
        '
        'txtrut
        '
        Me.txtrut.Location = New System.Drawing.Point(99, 33)
        Me.txtrut.MaxLength = 8
        Me.txtrut.Name = "txtrut"
        Me.txtrut.Size = New System.Drawing.Size(70, 20)
        Me.txtrut.TabIndex = 110
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(12, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 108
        Me.Label1.Text = "RUT"
        '
        'Btn_Buscar
        '
        Me.Btn_Buscar.BackColor = System.Drawing.Color.Transparent
        Me.Btn_Buscar.FlatAppearance.BorderSize = 0
        Me.Btn_Buscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_Buscar.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_soportante
        Me.Btn_Buscar.Location = New System.Drawing.Point(1078, 99)
        Me.Btn_Buscar.Name = "Btn_Buscar"
        Me.Btn_Buscar.Size = New System.Drawing.Size(63, 63)
        Me.Btn_Buscar.TabIndex = 115
        Me.Btn_Buscar.UseVisualStyleBackColor = False
        '
        'TxtAp
        '
        Me.TxtAp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtAp.Location = New System.Drawing.Point(204, 60)
        Me.TxtAp.Name = "TxtAp"
        Me.TxtAp.Size = New System.Drawing.Size(113, 20)
        Me.TxtAp.TabIndex = 116
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"10", "20", "30", "40", "45", "50", "59"})
        Me.ComboBox1.Location = New System.Drawing.Point(623, 59)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(77, 21)
        Me.ComboBox1.TabIndex = 117
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(706, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(148, 13)
        Me.Label3.TabIndex = 118
        Me.Label3.Text = "MINUTOS DE EFECTIVIDAD"
        '
        'txtnc
        '
        Me.txtnc.Location = New System.Drawing.Point(998, 544)
        Me.txtnc.Name = "txtnc"
        Me.txtnc.ReadOnly = True
        Me.txtnc.Size = New System.Drawing.Size(69, 20)
        Me.txtnc.TabIndex = 119
        '
        'txtok
        '
        Me.txtok.Location = New System.Drawing.Point(998, 524)
        Me.txtok.Name = "txtok"
        Me.txtok.ReadOnly = True
        Me.txtok.Size = New System.Drawing.Size(69, 20)
        Me.txtok.TabIndex = 120
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(889, 528)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 13)
        Me.Label4.TabIndex = 121
        Me.Label4.Text = "CONFORMES"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(889, 548)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(99, 13)
        Me.Label5.TabIndex = 122
        Me.Label5.Text = "NO/ CONFORMES"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.ForeColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(889, 566)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(77, 13)
        Me.Label6.TabIndex = 123
        Me.Label6.Text = "EFECTIVIDAD"
        '
        'lblefe
        '
        Me.lblefe.AutoSize = True
        Me.lblefe.BackColor = System.Drawing.Color.Transparent
        Me.lblefe.ForeColor = System.Drawing.Color.White
        Me.lblefe.Location = New System.Drawing.Point(1011, 566)
        Me.lblefe.Name = "lblefe"
        Me.lblefe.Size = New System.Drawing.Size(13, 13)
        Me.lblefe.TabIndex = 124
        Me.lblefe.Text = "0"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(1054, 567)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(15, 13)
        Me.Label7.TabIndex = 125
        Me.Label7.Text = "%"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.Enabled = False
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_impresora
        Me.Button1.Location = New System.Drawing.Point(1078, 162)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(63, 63)
        Me.Button1.TabIndex = 126
        Me.Button1.UseVisualStyleBackColor = False
        '
        'dtp_fecter
        '
        Me.dtp_fecter.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecter.Location = New System.Drawing.Point(456, 61)
        Me.dtp_fecter.Name = "dtp_fecter"
        Me.dtp_fecter.Size = New System.Drawing.Size(96, 20)
        Me.dtp_fecter.TabIndex = 134
        '
        'dtp_fecini
        '
        Me.dtp_fecini.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_fecini.Location = New System.Drawing.Point(456, 32)
        Me.dtp_fecini.Name = "dtp_fecini"
        Me.dtp_fecini.Size = New System.Drawing.Size(96, 20)
        Me.dtp_fecini.TabIndex = 133
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.ForeColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(356, 34)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 13)
        Me.Label8.TabIndex = 129
        Me.Label8.Text = "Fecha Inicio"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.ForeColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(440, 64)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(10, 13)
        Me.Label9.TabIndex = 132
        Me.Label9.Text = ":"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.ForeColor = System.Drawing.Color.Transparent
        Me.Label10.Location = New System.Drawing.Point(356, 64)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(78, 13)
        Me.Label10.TabIndex = 130
        Me.Label10.Text = "Fecha Término"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.ForeColor = System.Drawing.Color.Transparent
        Me.Label11.Location = New System.Drawing.Point(440, 34)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(10, 13)
        Me.Label11.TabIndex = 131
        Me.Label11.Text = ":"
        '
        'FrmPedidosUsuarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(1161, 606)
        Me.Controls.Add(Me.dtp_fecter)
        Me.Controls.Add(Me.dtp_fecini)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lblefe)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtok)
        Me.Controls.Add(Me.txtnc)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.TxtAp)
        Me.Controls.Add(Me.Btn_Buscar)
        Me.Controls.Add(Me.txtcodigo)
        Me.Controls.Add(Me.TxtNom1)
        Me.Controls.Add(Me.Btn_BuscaUsuarios)
        Me.Controls.Add(Me.txtrutv)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtrut)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DgvResultado)
        Me.Name = "FrmPedidosUsuarios"
        Me.Text = "Pedidos Por Usuario"
        CType(Me.DgvResultado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DgvResultado As System.Windows.Forms.DataGridView
    Friend WithEvents txtcodigo As System.Windows.Forms.TextBox
    Friend WithEvents TxtNom1 As System.Windows.Forms.TextBox
    Friend WithEvents Btn_BuscaUsuarios As System.Windows.Forms.Button
    Friend WithEvents txtrutv As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtrut As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Btn_Buscar As System.Windows.Forms.Button
    Friend WithEvents TxtAp As System.Windows.Forms.TextBox
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtnc As System.Windows.Forms.TextBox
    Friend WithEvents txtok As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblefe As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents dtp_fecter As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_fecini As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
End Class

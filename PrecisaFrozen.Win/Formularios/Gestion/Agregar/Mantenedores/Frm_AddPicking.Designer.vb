<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_AddPicking
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_AddPicking))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtpiso = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chktlc = New System.Windows.Forms.CheckBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.TxtCoFinal = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtBaFinal = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtcamara = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtbanda = New System.Windows.Forms.TextBox()
        Me.txtcolumna = New System.Windows.Forms.TextBox()
        Me.DgvResultado = New System.Windows.Forms.DataGridView()
        Me.RbRangos = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.btn_guardar = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtprodcod = New System.Windows.Forms.TextBox()
        Me.Btn_buscaProducto = New System.Windows.Forms.Button()
        Me.txtprodnom = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.TxtClirut = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.btn_BuscaCliente = New System.Windows.Forms.Button()
        Me.txtclinom = New System.Windows.Forms.TextBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.dgpick = New System.Windows.Forms.DataGridView()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DgvResultado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.dgpick, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.txtpiso)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.chktlc)
        Me.GroupBox2.Controls.Add(Me.Button4)
        Me.GroupBox2.Controls.Add(Me.TxtCoFinal)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.txtBaFinal)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.txtcamara)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.txtbanda)
        Me.GroupBox2.Controls.Add(Me.txtcolumna)
        Me.GroupBox2.Location = New System.Drawing.Point(38, 33)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(337, 154)
        Me.GroupBox2.TabIndex = 122
        Me.GroupBox2.TabStop = False
        '
        'txtpiso
        '
        Me.txtpiso.Location = New System.Drawing.Point(127, 107)
        Me.txtpiso.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtpiso.MaxLength = 2
        Me.txtpiso.Name = "txtpiso"
        Me.txtpiso.Size = New System.Drawing.Size(49, 20)
        Me.txtpiso.TabIndex = 122
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(17, 114)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 13)
        Me.Label1.TabIndex = 121
        Me.Label1.Text = "Piso"
        '
        'chktlc
        '
        Me.chktlc.AutoSize = True
        Me.chktlc.ForeColor = System.Drawing.Color.White
        Me.chktlc.Location = New System.Drawing.Point(214, 25)
        Me.chktlc.Name = "chktlc"
        Me.chktlc.Size = New System.Drawing.Size(100, 17)
        Me.chktlc.TabIndex = 120
        Me.chktlc.Text = "Toda la camara"
        Me.chktlc.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.cont_ok
        Me.Button4.Location = New System.Drawing.Point(287, 108)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(27, 24)
        Me.Button4.TabIndex = 115
        Me.Button4.UseVisualStyleBackColor = True
        '
        'TxtCoFinal
        '
        Me.TxtCoFinal.Location = New System.Drawing.Point(214, 79)
        Me.TxtCoFinal.Name = "TxtCoFinal"
        Me.TxtCoFinal.Size = New System.Drawing.Size(52, 20)
        Me.TxtCoFinal.TabIndex = 117
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(17, 26)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(43, 13)
        Me.Label11.TabIndex = 109
        Me.Label11.Text = "Camara"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(17, 53)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(38, 13)
        Me.Label10.TabIndex = 110
        Me.Label10.Text = "Banda"
        '
        'txtBaFinal
        '
        Me.txtBaFinal.Location = New System.Drawing.Point(214, 50)
        Me.txtBaFinal.Name = "txtBaFinal"
        Me.txtBaFinal.Size = New System.Drawing.Size(52, 20)
        Me.txtBaFinal.TabIndex = 115
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(17, 82)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(48, 13)
        Me.Label9.TabIndex = 114
        Me.Label9.Text = "Columna"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(189, 83)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(10, 13)
        Me.Label7.TabIndex = 119
        Me.Label7.Text = "-"
        '
        'txtcamara
        '
        Me.txtcamara.Location = New System.Drawing.Point(127, 23)
        Me.txtcamara.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtcamara.MaxLength = 2
        Me.txtcamara.Name = "txtcamara"
        Me.txtcamara.Size = New System.Drawing.Size(49, 20)
        Me.txtcamara.TabIndex = 111
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(189, 54)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(10, 13)
        Me.Label8.TabIndex = 118
        Me.Label8.Text = "-"
        '
        'txtbanda
        '
        Me.txtbanda.Location = New System.Drawing.Point(127, 50)
        Me.txtbanda.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtbanda.MaxLength = 2
        Me.txtbanda.Name = "txtbanda"
        Me.txtbanda.Size = New System.Drawing.Size(49, 20)
        Me.txtbanda.TabIndex = 113
        '
        'txtcolumna
        '
        Me.txtcolumna.Location = New System.Drawing.Point(127, 79)
        Me.txtcolumna.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtcolumna.MaxLength = 2
        Me.txtcolumna.Name = "txtcolumna"
        Me.txtcolumna.Size = New System.Drawing.Size(49, 20)
        Me.txtcolumna.TabIndex = 116
        '
        'DgvResultado
        '
        Me.DgvResultado.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark
        Me.DgvResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvResultado.Location = New System.Drawing.Point(38, 193)
        Me.DgvResultado.Name = "DgvResultado"
        Me.DgvResultado.Size = New System.Drawing.Size(337, 225)
        Me.DgvResultado.TabIndex = 121
        '
        'RbRangos
        '
        Me.RbRangos.AutoSize = True
        Me.RbRangos.BackColor = System.Drawing.Color.Transparent
        Me.RbRangos.ForeColor = System.Drawing.Color.White
        Me.RbRangos.Location = New System.Drawing.Point(38, 12)
        Me.RbRangos.Name = "RbRangos"
        Me.RbRangos.Size = New System.Drawing.Size(82, 17)
        Me.RbRangos.TabIndex = 122
        Me.RbRangos.Text = "Por Rangos"
        Me.RbRangos.UseVisualStyleBackColor = False
        Me.RbRangos.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.RadioButton2)
        Me.GroupBox1.Controls.Add(Me.RadioButton1)
        Me.GroupBox1.Controls.Add(Me.btn_guardar)
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.GroupBox1.Location = New System.Drawing.Point(38, 424)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(337, 99)
        Me.GroupBox1.TabIndex = 123
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Posiciones De Picking"
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(88, 42)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(41, 17)
        Me.RadioButton2.TabIndex = 32
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "NO"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(47, 42)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(35, 17)
        Me.RadioButton1.TabIndex = 31
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "SI"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'btn_guardar
        '
        Me.btn_guardar.FlatAppearance.BorderSize = 0
        Me.btn_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_guardar.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_guardar2
        Me.btn_guardar.Location = New System.Drawing.Point(252, 19)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(79, 63)
        Me.btn_guardar.TabIndex = 30
        Me.btn_guardar.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.Label19)
        Me.GroupBox3.Controls.Add(Me.txtprodcod)
        Me.GroupBox3.Controls.Add(Me.Btn_buscaProducto)
        Me.GroupBox3.Controls.Add(Me.txtprodnom)
        Me.GroupBox3.Controls.Add(Me.Button1)
        Me.GroupBox3.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.GroupBox3.Location = New System.Drawing.Point(820, 775)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(13, 99)
        Me.GroupBox3.TabIndex = 124
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Sugerencia por producto"
        Me.GroupBox3.Visible = False
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(28, 48)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(68, 13)
        Me.Label19.TabIndex = 31
        Me.Label19.Text = "PRODUCTO"
        '
        'txtprodcod
        '
        Me.txtprodcod.Enabled = False
        Me.txtprodcod.Location = New System.Drawing.Point(106, 41)
        Me.txtprodcod.MaxLength = 7
        Me.txtprodcod.Name = "txtprodcod"
        Me.txtprodcod.Size = New System.Drawing.Size(82, 20)
        Me.txtprodcod.TabIndex = 32
        '
        'Btn_buscaProducto
        '
        Me.Btn_buscaProducto.Image = CType(resources.GetObject("Btn_buscaProducto.Image"), System.Drawing.Image)
        Me.Btn_buscaProducto.Location = New System.Drawing.Point(192, 39)
        Me.Btn_buscaProducto.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Btn_buscaProducto.Name = "Btn_buscaProducto"
        Me.Btn_buscaProducto.Size = New System.Drawing.Size(21, 22)
        Me.Btn_buscaProducto.TabIndex = 33
        Me.Btn_buscaProducto.UseVisualStyleBackColor = True
        '
        'txtprodnom
        '
        Me.txtprodnom.Enabled = False
        Me.txtprodnom.Location = New System.Drawing.Point(219, 41)
        Me.txtprodnom.Name = "txtprodnom"
        Me.txtprodnom.Size = New System.Drawing.Size(380, 20)
        Me.txtprodnom.TabIndex = 34
        '
        'Button1
        '
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_guardar2
        Me.Button1.Location = New System.Drawing.Point(667, 19)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(79, 63)
        Me.Button1.TabIndex = 30
        Me.Button1.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.TxtClirut)
        Me.GroupBox4.Controls.Add(Me.Button2)
        Me.GroupBox4.Controls.Add(Me.Label43)
        Me.GroupBox4.Controls.Add(Me.btn_BuscaCliente)
        Me.GroupBox4.Controls.Add(Me.txtclinom)
        Me.GroupBox4.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.GroupBox4.Location = New System.Drawing.Point(742, 787)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(10, 99)
        Me.GroupBox4.TabIndex = 124
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Sugerencia Por Cliente"
        Me.GroupBox4.Visible = False
        '
        'TxtClirut
        '
        Me.TxtClirut.Location = New System.Drawing.Point(106, 41)
        Me.TxtClirut.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TxtClirut.MaxLength = 8
        Me.TxtClirut.Name = "TxtClirut"
        Me.TxtClirut.Size = New System.Drawing.Size(82, 20)
        Me.TxtClirut.TabIndex = 128
        '
        'Button2
        '
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_guardar2
        Me.Button2.Location = New System.Drawing.Point(667, 20)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(79, 63)
        Me.Button2.TabIndex = 30
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label43
        '
        Me.Label43.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label43.Location = New System.Drawing.Point(7, 40)
        Me.Label43.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(78, 21)
        Me.Label43.TabIndex = 127
        Me.Label43.Text = "CLIENTE"
        Me.Label43.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btn_BuscaCliente
        '
        Me.btn_BuscaCliente.Image = CType(resources.GetObject("btn_BuscaCliente.Image"), System.Drawing.Image)
        Me.btn_BuscaCliente.Location = New System.Drawing.Point(194, 40)
        Me.btn_BuscaCliente.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btn_BuscaCliente.Name = "btn_BuscaCliente"
        Me.btn_BuscaCliente.Size = New System.Drawing.Size(21, 22)
        Me.btn_BuscaCliente.TabIndex = 125
        Me.btn_BuscaCliente.UseVisualStyleBackColor = True
        '
        'txtclinom
        '
        Me.txtclinom.Enabled = False
        Me.txtclinom.Location = New System.Drawing.Point(223, 41)
        Me.txtclinom.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtclinom.Name = "txtclinom"
        Me.txtclinom.Size = New System.Drawing.Size(380, 20)
        Me.txtclinom.TabIndex = 126
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox5.Controls.Add(Me.dgpick)
        Me.GroupBox5.ForeColor = System.Drawing.Color.Black
        Me.GroupBox5.Location = New System.Drawing.Point(38, 529)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(337, 225)
        Me.GroupBox5.TabIndex = 124
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Picking"
        '
        'dgpick
        '
        Me.dgpick.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgpick.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark
        Me.dgpick.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgpick.Location = New System.Drawing.Point(6, 19)
        Me.dgpick.Name = "dgpick"
        Me.dgpick.RowHeadersWidth = 20
        Me.dgpick.Size = New System.Drawing.Size(325, 200)
        Me.dgpick.TabIndex = 125
        '
        'Frm_AddPicking
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(416, 777)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.RbRangos)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.DgvResultado)
        Me.Name = "Frm_AddPicking"
        Me.Text = "Reservas para Picking"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.DgvResultado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        CType(Me.dgpick, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents TxtCoFinal As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtBaFinal As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtcamara As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtbanda As System.Windows.Forms.TextBox
    Friend WithEvents txtcolumna As System.Windows.Forms.TextBox
    Friend WithEvents DgvResultado As System.Windows.Forms.DataGridView
    Friend WithEvents RbRangos As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents TxtClirut As System.Windows.Forms.TextBox
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents btn_BuscaCliente As System.Windows.Forms.Button
    Friend WithEvents txtclinom As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtprodcod As System.Windows.Forms.TextBox
    Friend WithEvents Btn_buscaProducto As System.Windows.Forms.Button
    Friend WithEvents txtprodnom As System.Windows.Forms.TextBox
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents chktlc As System.Windows.Forms.CheckBox
    Friend WithEvents txtpiso As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents dgpick As System.Windows.Forms.DataGridView
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_AddPosiciones
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
        Me.txtca = New System.Windows.Forms.TextBox()
        Me.DgvResultado = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtbloq = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtaltura = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtpi = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtco = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtba = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtCoFinal = New System.Windows.Forms.TextBox()
        Me.txtBaFinal = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtcolumna = New System.Windows.Forms.TextBox()
        Me.txtbanda = New System.Windows.Forms.TextBox()
        Me.txtcamara = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.altura = New System.Windows.Forms.TextBox()
        Me.RbRangos = New System.Windows.Forms.CheckBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.btn_informes = New System.Windows.Forms.Button()
        Me.btn_nuevo = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Btn_AnulaGuia = New System.Windows.Forms.Button()
        CType(Me.DgvResultado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtca
        '
        Me.txtca.Location = New System.Drawing.Point(46, 30)
        Me.txtca.Name = "txtca"
        Me.txtca.Size = New System.Drawing.Size(43, 20)
        Me.txtca.TabIndex = 0
        '
        'DgvResultado
        '
        Me.DgvResultado.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark
        Me.DgvResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvResultado.Location = New System.Drawing.Point(12, 357)
        Me.DgvResultado.Name = "DgvResultado"
        Me.DgvResultado.Size = New System.Drawing.Size(817, 309)
        Me.DgvResultado.TabIndex = 107
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.btn_informes)
        Me.GroupBox1.Controls.Add(Me.btn_nuevo)
        Me.GroupBox1.Controls.Add(Me.txtbloq)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtaltura)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.Btn_AnulaGuia)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtpi)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtco)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtba)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtca)
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(12, 28)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(817, 138)
        Me.GroupBox1.TabIndex = 108
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Agregar/Bloquear"
        '
        'txtbloq
        '
        Me.txtbloq.Location = New System.Drawing.Point(63, 108)
        Me.txtbloq.Name = "txtbloq"
        Me.txtbloq.ReadOnly = True
        Me.txtbloq.Size = New System.Drawing.Size(97, 20)
        Me.txtbloq.TabIndex = 114
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 116)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(51, 13)
        Me.Label6.TabIndex = 113
        Me.Label6.Text = "ESTADO"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(291, 37)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(50, 13)
        Me.Label5.TabIndex = 112
        Me.Label5.Text = "ALTURA"
        '
        'txtaltura
        '
        Me.txtaltura.Location = New System.Drawing.Point(347, 30)
        Me.txtaltura.Name = "txtaltura"
        Me.txtaltura.Size = New System.Drawing.Size(53, 20)
        Me.txtaltura.TabIndex = 111
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(19, 69)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(17, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "PI"
        '
        'txtpi
        '
        Me.txtpi.Location = New System.Drawing.Point(46, 62)
        Me.txtpi.Name = "txtpi"
        Me.txtpi.Size = New System.Drawing.Size(43, 20)
        Me.txtpi.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(200, 37)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(22, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "CO"
        '
        'txtco
        '
        Me.txtco.Location = New System.Drawing.Point(227, 30)
        Me.txtco.Name = "txtco"
        Me.txtco.Size = New System.Drawing.Size(43, 20)
        Me.txtco.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(112, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(21, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "BA"
        '
        'txtba
        '
        Me.txtba.Location = New System.Drawing.Point(139, 30)
        Me.txtba.Name = "txtba"
        Me.txtba.Size = New System.Drawing.Size(43, 20)
        Me.txtba.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(21, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "CA"
        '
        'TxtCoFinal
        '
        Me.TxtCoFinal.Location = New System.Drawing.Point(216, 89)
        Me.TxtCoFinal.Name = "TxtCoFinal"
        Me.TxtCoFinal.Size = New System.Drawing.Size(52, 20)
        Me.TxtCoFinal.TabIndex = 117
        '
        'txtBaFinal
        '
        Me.txtBaFinal.Location = New System.Drawing.Point(216, 60)
        Me.txtBaFinal.Name = "txtBaFinal"
        Me.txtBaFinal.Size = New System.Drawing.Size(52, 20)
        Me.txtBaFinal.TabIndex = 115
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(191, 93)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(10, 13)
        Me.Label7.TabIndex = 119
        Me.Label7.Text = "-"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(191, 64)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(10, 13)
        Me.Label8.TabIndex = 118
        Me.Label8.Text = "-"
        '
        'txtcolumna
        '
        Me.txtcolumna.Location = New System.Drawing.Point(129, 89)
        Me.txtcolumna.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtcolumna.MaxLength = 2
        Me.txtcolumna.Name = "txtcolumna"
        Me.txtcolumna.Size = New System.Drawing.Size(49, 20)
        Me.txtcolumna.TabIndex = 116
        '
        'txtbanda
        '
        Me.txtbanda.Location = New System.Drawing.Point(129, 60)
        Me.txtbanda.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtbanda.MaxLength = 2
        Me.txtbanda.Name = "txtbanda"
        Me.txtbanda.Size = New System.Drawing.Size(49, 20)
        Me.txtbanda.TabIndex = 113
        '
        'txtcamara
        '
        Me.txtcamara.Location = New System.Drawing.Point(129, 33)
        Me.txtcamara.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtcamara.MaxLength = 2
        Me.txtcamara.Name = "txtcamara"
        Me.txtcamara.Size = New System.Drawing.Size(49, 20)
        Me.txtcamara.TabIndex = 111
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(19, 92)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(48, 13)
        Me.Label9.TabIndex = 114
        Me.Label9.Text = "Columna"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(19, 63)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(38, 13)
        Me.Label10.TabIndex = 110
        Me.Label10.Text = "Banda"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(19, 36)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(43, 13)
        Me.Label11.TabIndex = 109
        Me.Label11.Text = "Camara"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.Button4)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Button2)
        Me.GroupBox2.Controls.Add(Me.altura)
        Me.GroupBox2.Controls.Add(Me.Button3)
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
        Me.GroupBox2.Location = New System.Drawing.Point(12, 209)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(817, 142)
        Me.GroupBox2.TabIndex = 120
        Me.GroupBox2.TabStop = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(291, 26)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(50, 13)
        Me.Label12.TabIndex = 116
        Me.Label12.Text = "ALTURA"
        '
        'altura
        '
        Me.altura.Location = New System.Drawing.Point(347, 19)
        Me.altura.Name = "altura"
        Me.altura.Size = New System.Drawing.Size(53, 20)
        Me.altura.TabIndex = 115
        '
        'RbRangos
        '
        Me.RbRangos.AutoSize = True
        Me.RbRangos.BackColor = System.Drawing.Color.Transparent
        Me.RbRangos.ForeColor = System.Drawing.Color.White
        Me.RbRangos.Location = New System.Drawing.Point(12, 186)
        Me.RbRangos.Name = "RbRangos"
        Me.RbRangos.Size = New System.Drawing.Size(82, 17)
        Me.RbRangos.TabIndex = 121
        Me.RbRangos.Text = "Por Rangos"
        Me.RbRangos.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.cont_ok
        Me.Button4.Location = New System.Drawing.Point(373, 85)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(27, 24)
        Me.Button4.TabIndex = 115
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.cruzzzz
        Me.Button2.Location = New System.Drawing.Point(745, 73)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(63, 63)
        Me.Button2.TabIndex = 116
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.tick
        Me.Button3.Location = New System.Drawing.Point(679, 73)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(63, 63)
        Me.Button3.TabIndex = 115
        Me.Button3.UseVisualStyleBackColor = True
        '
        'btn_informes
        '
        Me.btn_informes.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_informes.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.cont_ok
        Me.btn_informes.Location = New System.Drawing.Point(175, 105)
        Me.btn_informes.Name = "btn_informes"
        Me.btn_informes.Size = New System.Drawing.Size(27, 24)
        Me.btn_informes.TabIndex = 109
        Me.btn_informes.UseVisualStyleBackColor = True
        '
        'btn_nuevo
        '
        Me.btn_nuevo.FlatAppearance.BorderSize = 0
        Me.btn_nuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_nuevo.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_hojanueva
        Me.btn_nuevo.Location = New System.Drawing.Point(611, 62)
        Me.btn_nuevo.Name = "btn_nuevo"
        Me.btn_nuevo.Size = New System.Drawing.Size(63, 63)
        Me.btn_nuevo.TabIndex = 109
        Me.btn_nuevo.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.cruzzzz
        Me.Button1.Location = New System.Drawing.Point(745, 62)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(63, 63)
        Me.Button1.TabIndex = 110
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Btn_AnulaGuia
        '
        Me.Btn_AnulaGuia.FlatAppearance.BorderSize = 0
        Me.Btn_AnulaGuia.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_AnulaGuia.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.tick
        Me.Btn_AnulaGuia.Location = New System.Drawing.Point(679, 62)
        Me.Btn_AnulaGuia.Name = "Btn_AnulaGuia"
        Me.Btn_AnulaGuia.Size = New System.Drawing.Size(63, 63)
        Me.Btn_AnulaGuia.TabIndex = 109
        Me.Btn_AnulaGuia.UseVisualStyleBackColor = True
        '
        'Frm_AddPosiciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(862, 678)
        Me.Controls.Add(Me.RbRangos)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.DgvResultado)
        Me.Name = "Frm_AddPosiciones"
        Me.Text = "Mantenedor De Posiciones"
        CType(Me.DgvResultado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtca As System.Windows.Forms.TextBox
    Friend WithEvents DgvResultado As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtpi As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtco As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtba As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Btn_AnulaGuia As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtaltura As System.Windows.Forms.TextBox
    Friend WithEvents txtbloq As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btn_nuevo As System.Windows.Forms.Button
    Friend WithEvents btn_informes As System.Windows.Forms.Button
    Friend WithEvents TxtCoFinal As System.Windows.Forms.TextBox
    Friend WithEvents txtBaFinal As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtcolumna As System.Windows.Forms.TextBox
    Friend WithEvents txtbanda As System.Windows.Forms.TextBox
    Friend WithEvents txtcamara As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents RbRangos As System.Windows.Forms.CheckBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents altura As System.Windows.Forms.TextBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GeneraAuditoria
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GeneraAuditoria))
        Me.txtdes = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CBOCAMARAEX = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtporcentaje = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DgvResultado = New System.Windows.Forms.DataGridView()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TXTCANT = New System.Windows.Forms.TextBox()
        Me.CHK1 = New System.Windows.Forms.CheckBox()
        Me.CHK2 = New System.Windows.Forms.CheckBox()
        Me.CHK3 = New System.Windows.Forms.CheckBox()
        Me.CHK4 = New System.Windows.Forms.CheckBox()
        Me.CHK5 = New System.Windows.Forms.CheckBox()
        Me.CHK6 = New System.Windows.Forms.CheckBox()
        Me.btnExcel = New System.Windows.Forms.Button()
        Me.Btn_cliente = New System.Windows.Forms.Button()
        Me.btn_nuevo = New System.Windows.Forms.Button()
        Me.Btn_GuardaDetalle = New System.Windows.Forms.Button()
        Me.btn_guardar = New System.Windows.Forms.Button()
        CType(Me.txtporcentaje, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgvResultado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtdes
        '
        Me.txtdes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtdes.Location = New System.Drawing.Point(158, 36)
        Me.txtdes.Name = "txtdes"
        Me.txtdes.Size = New System.Drawing.Size(301, 20)
        Me.txtdes.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(10, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(142, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "DESCRIPCION AUDITORIA"
        '
        'CBOCAMARAEX
        '
        Me.CBOCAMARAEX.FormattingEnabled = True
        Me.CBOCAMARAEX.Location = New System.Drawing.Point(548, 62)
        Me.CBOCAMARAEX.Name = "CBOCAMARAEX"
        Me.CBOCAMARAEX.Size = New System.Drawing.Size(10, 21)
        Me.CBOCAMARAEX.TabIndex = 2
        Me.CBOCAMARAEX.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(10, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(113, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "CAMARA A AUDITAR" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'txtporcentaje
        '
        Me.txtporcentaje.Location = New System.Drawing.Point(339, 89)
        Me.txtporcentaje.Name = "txtporcentaje"
        Me.txtporcentaje.Size = New System.Drawing.Size(120, 20)
        Me.txtporcentaje.TabIndex = 122
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(10, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 13)
        Me.Label3.TabIndex = 123
        Me.Label3.Text = "MUESTRA"
        '
        'DgvResultado
        '
        Me.DgvResultado.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvResultado.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DgvResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvResultado.DefaultCellStyle = DataGridViewCellStyle2
        Me.DgvResultado.Location = New System.Drawing.Point(13, 154)
        Me.DgvResultado.Name = "DgvResultado"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvResultado.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DgvResultado.Size = New System.Drawing.Size(840, 330)
        Me.DgvResultado.TabIndex = 124
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(465, 89)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(23, 20)
        Me.Label4.TabIndex = 126
        Me.Label4.Text = "%"
        '
        'TXTCANT
        '
        Me.TXTCANT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTCANT.Enabled = False
        Me.TXTCANT.Location = New System.Drawing.Point(13, 490)
        Me.TXTCANT.Name = "TXTCANT"
        Me.TXTCANT.Size = New System.Drawing.Size(147, 20)
        Me.TXTCANT.TabIndex = 128
        '
        'CHK1
        '
        Me.CHK1.AutoSize = True
        Me.CHK1.ForeColor = System.Drawing.Color.White
        Me.CHK1.Location = New System.Drawing.Point(158, 66)
        Me.CHK1.Name = "CHK1"
        Me.CHK1.Size = New System.Drawing.Size(38, 17)
        Me.CHK1.TabIndex = 130
        Me.CHK1.Text = "01"
        Me.CHK1.UseVisualStyleBackColor = True
        '
        'CHK2
        '
        Me.CHK2.AutoSize = True
        Me.CHK2.ForeColor = System.Drawing.Color.White
        Me.CHK2.Location = New System.Drawing.Point(202, 66)
        Me.CHK2.Name = "CHK2"
        Me.CHK2.Size = New System.Drawing.Size(38, 17)
        Me.CHK2.TabIndex = 131
        Me.CHK2.Text = "02"
        Me.CHK2.UseVisualStyleBackColor = True
        '
        'CHK3
        '
        Me.CHK3.AutoSize = True
        Me.CHK3.ForeColor = System.Drawing.Color.White
        Me.CHK3.Location = New System.Drawing.Point(246, 66)
        Me.CHK3.Name = "CHK3"
        Me.CHK3.Size = New System.Drawing.Size(38, 17)
        Me.CHK3.TabIndex = 132
        Me.CHK3.Text = "03"
        Me.CHK3.UseVisualStyleBackColor = True
        '
        'CHK4
        '
        Me.CHK4.AutoSize = True
        Me.CHK4.ForeColor = System.Drawing.Color.White
        Me.CHK4.Location = New System.Drawing.Point(290, 66)
        Me.CHK4.Name = "CHK4"
        Me.CHK4.Size = New System.Drawing.Size(38, 17)
        Me.CHK4.TabIndex = 133
        Me.CHK4.Text = "04"
        Me.CHK4.UseVisualStyleBackColor = True
        '
        'CHK5
        '
        Me.CHK5.AutoSize = True
        Me.CHK5.ForeColor = System.Drawing.Color.White
        Me.CHK5.Location = New System.Drawing.Point(334, 66)
        Me.CHK5.Name = "CHK5"
        Me.CHK5.Size = New System.Drawing.Size(38, 17)
        Me.CHK5.TabIndex = 134
        Me.CHK5.Text = "05"
        Me.CHK5.UseVisualStyleBackColor = True
        '
        'CHK6
        '
        Me.CHK6.AutoSize = True
        Me.CHK6.ForeColor = System.Drawing.Color.White
        Me.CHK6.Location = New System.Drawing.Point(378, 66)
        Me.CHK6.Name = "CHK6"
        Me.CHK6.Size = New System.Drawing.Size(38, 17)
        Me.CHK6.TabIndex = 135
        Me.CHK6.Text = "06"
        Me.CHK6.UseVisualStyleBackColor = True
        '
        'btnExcel
        '
        Me.btnExcel.BackColor = System.Drawing.Color.Transparent
        Me.btnExcel.FlatAppearance.BorderSize = 0
        Me.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExcel.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_xls
        Me.btnExcel.Location = New System.Drawing.Point(646, 502)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(63, 63)
        Me.btnExcel.TabIndex = 137
        Me.btnExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExcel.UseVisualStyleBackColor = False
        '
        'Btn_cliente
        '
        Me.Btn_cliente.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.buscar_24
        Me.Btn_cliente.Location = New System.Drawing.Point(466, 34)
        Me.Btn_cliente.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Btn_cliente.Name = "Btn_cliente"
        Me.Btn_cliente.Size = New System.Drawing.Size(21, 22)
        Me.Btn_cliente.TabIndex = 136
        Me.Btn_cliente.UseVisualStyleBackColor = True
        '
        'btn_nuevo
        '
        Me.btn_nuevo.FlatAppearance.BorderSize = 0
        Me.btn_nuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_nuevo.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_hojanueva
        Me.btn_nuevo.Location = New System.Drawing.Point(715, 502)
        Me.btn_nuevo.Name = "btn_nuevo"
        Me.btn_nuevo.Size = New System.Drawing.Size(63, 63)
        Me.btn_nuevo.TabIndex = 129
        Me.btn_nuevo.UseVisualStyleBackColor = True
        '
        'Btn_GuardaDetalle
        '
        Me.Btn_GuardaDetalle.Image = CType(resources.GetObject("Btn_GuardaDetalle.Image"), System.Drawing.Image)
        Me.Btn_GuardaDetalle.Location = New System.Drawing.Point(796, 108)
        Me.Btn_GuardaDetalle.Name = "Btn_GuardaDetalle"
        Me.Btn_GuardaDetalle.Size = New System.Drawing.Size(57, 40)
        Me.Btn_GuardaDetalle.TabIndex = 127
        Me.Btn_GuardaDetalle.UseVisualStyleBackColor = True
        '
        'btn_guardar
        '
        Me.btn_guardar.FlatAppearance.BorderSize = 0
        Me.btn_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_guardar.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_guardar2
        Me.btn_guardar.Location = New System.Drawing.Point(774, 502)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(79, 63)
        Me.btn_guardar.TabIndex = 125
        Me.btn_guardar.UseVisualStyleBackColor = True
        '
        'GeneraAuditoria
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(1084, 586)
        Me.Controls.Add(Me.btnExcel)
        Me.Controls.Add(Me.Btn_cliente)
        Me.Controls.Add(Me.CHK6)
        Me.Controls.Add(Me.CHK5)
        Me.Controls.Add(Me.CHK4)
        Me.Controls.Add(Me.CHK3)
        Me.Controls.Add(Me.CHK2)
        Me.Controls.Add(Me.CHK1)
        Me.Controls.Add(Me.btn_nuevo)
        Me.Controls.Add(Me.TXTCANT)
        Me.Controls.Add(Me.Btn_GuardaDetalle)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btn_guardar)
        Me.Controls.Add(Me.DgvResultado)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtporcentaje)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.CBOCAMARAEX)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtdes)
        Me.Name = "GeneraAuditoria"
        Me.Text = "GeneraAuditoria"
        CType(Me.txtporcentaje, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgvResultado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtdes As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CBOCAMARAEX As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtporcentaje As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DgvResultado As System.Windows.Forms.DataGridView
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Btn_GuardaDetalle As System.Windows.Forms.Button
    Friend WithEvents TXTCANT As System.Windows.Forms.TextBox
    Friend WithEvents btn_nuevo As System.Windows.Forms.Button
    Friend WithEvents CHK1 As System.Windows.Forms.CheckBox
    Friend WithEvents CHK2 As System.Windows.Forms.CheckBox
    Friend WithEvents CHK3 As System.Windows.Forms.CheckBox
    Friend WithEvents CHK4 As System.Windows.Forms.CheckBox
    Friend WithEvents CHK5 As System.Windows.Forms.CheckBox
    Friend WithEvents CHK6 As System.Windows.Forms.CheckBox
    Friend WithEvents Btn_cliente As System.Windows.Forms.Button
    Friend WithEvents btnExcel As System.Windows.Forms.Button
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_soportantesEnCamara
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
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btn_BuscaCliente = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtrut = New System.Windows.Forms.TextBox()
        Me.txtclinombre = New System.Windows.Forms.TextBox()
        Me.verificador = New System.Windows.Forms.TextBox()
        Me.DgvResultado = New System.Windows.Forms.DataGridView()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.btnExcel = New System.Windows.Forms.Button()
        Me.Btn_Calcular = New System.Windows.Forms.Button()
        Me.btn_nuevo = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DgvResultado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'ComboBox1
        '
        Me.ComboBox1.AutoCompleteCustomSource.AddRange(New String() {"TODAS", "01", "02", "03", "04", "05", "06"})
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(387, 63)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(195, 21)
        Me.ComboBox1.TabIndex = 120
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(22, 63)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 13)
        Me.Label1.TabIndex = 119
        Me.Label1.Text = "CAMARA"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.btn_BuscaCliente)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.ComboBox1)
        Me.GroupBox1.Controls.Add(Me.txtrut)
        Me.GroupBox1.Controls.Add(Me.txtclinombre)
        Me.GroupBox1.Controls.Add(Me.verificador)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 14)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1136, 100)
        Me.GroupBox1.TabIndex = 121
        Me.GroupBox1.TabStop = False
        '
        'btn_BuscaCliente
        '
        Me.btn_BuscaCliente.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.buscar_24
        Me.btn_BuscaCliente.Location = New System.Drawing.Point(231, 30)
        Me.btn_BuscaCliente.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btn_BuscaCliente.Name = "btn_BuscaCliente"
        Me.btn_BuscaCliente.Size = New System.Drawing.Size(24, 24)
        Me.btn_BuscaCliente.TabIndex = 278
        Me.btn_BuscaCliente.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(22, 34)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(52, 13)
        Me.Label15.TabIndex = 274
        Me.Label15.Text = "CLIENTE"
        '
        'txtrut
        '
        Me.txtrut.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtrut.Location = New System.Drawing.Point(125, 31)
        Me.txtrut.MaxLength = 8
        Me.txtrut.Name = "txtrut"
        Me.txtrut.Size = New System.Drawing.Size(77, 21)
        Me.txtrut.TabIndex = 275
        '
        'txtclinombre
        '
        Me.txtclinombre.Enabled = False
        Me.txtclinombre.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtclinombre.Location = New System.Drawing.Point(258, 32)
        Me.txtclinombre.Name = "txtclinombre"
        Me.txtclinombre.Size = New System.Drawing.Size(324, 21)
        Me.txtclinombre.TabIndex = 277
        '
        'verificador
        '
        Me.verificador.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.verificador.Location = New System.Drawing.Point(209, 31)
        Me.verificador.MaxLength = 1
        Me.verificador.Name = "verificador"
        Me.verificador.Size = New System.Drawing.Size(19, 21)
        Me.verificador.TabIndex = 276
        '
        'DgvResultado
        '
        Me.DgvResultado.AllowUserToAddRows = False
        Me.DgvResultado.AllowUserToDeleteRows = False
        Me.DgvResultado.BackgroundColor = System.Drawing.Color.Gray
        Me.DgvResultado.ColumnHeadersHeight = 28
        Me.DgvResultado.Location = New System.Drawing.Point(12, 138)
        Me.DgvResultado.Name = "DgvResultado"
        Me.DgvResultado.ReadOnly = True
        Me.DgvResultado.Size = New System.Drawing.Size(1136, 397)
        Me.DgvResultado.TabIndex = 122
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.btnExcel)
        Me.GroupBox4.Controls.Add(Me.Btn_Calcular)
        Me.GroupBox4.Controls.Add(Me.btn_nuevo)
        Me.GroupBox4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(1154, 131)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(75, 206)
        Me.GroupBox4.TabIndex = 123
        Me.GroupBox4.TabStop = False
        '
        'btnExcel
        '
        Me.btnExcel.FlatAppearance.BorderSize = 0
        Me.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExcel.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_xls
        Me.btnExcel.Location = New System.Drawing.Point(5, 136)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(63, 63)
        Me.btnExcel.TabIndex = 124
        Me.btnExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExcel.UseVisualStyleBackColor = True
        '
        'Btn_Calcular
        '
        Me.Btn_Calcular.FlatAppearance.BorderSize = 0
        Me.Btn_Calcular.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_Calcular.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_soportante
        Me.Btn_Calcular.Location = New System.Drawing.Point(5, 12)
        Me.Btn_Calcular.Name = "Btn_Calcular"
        Me.Btn_Calcular.Size = New System.Drawing.Size(63, 63)
        Me.Btn_Calcular.TabIndex = 110
        Me.Btn_Calcular.UseVisualStyleBackColor = True
        '
        'btn_nuevo
        '
        Me.btn_nuevo.FlatAppearance.BorderSize = 0
        Me.btn_nuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_nuevo.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_hojanueva
        Me.btn_nuevo.Location = New System.Drawing.Point(5, 74)
        Me.btn_nuevo.Name = "btn_nuevo"
        Me.btn_nuevo.Size = New System.Drawing.Size(63, 63)
        Me.btn_nuevo.TabIndex = 30
        Me.btn_nuevo.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Enabled = False
        Me.TextBox1.Location = New System.Drawing.Point(1048, 541)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox1.TabIndex = 124
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(988, 548)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 13)
        Me.Label2.TabIndex = 279
        Me.Label2.Text = "PALLETS"
        '
        'Frm_soportantesEnCamara
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(1243, 581)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.DgvResultado)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Frm_soportantesEnCamara"
        Me.Text = "Posiciones en Camara"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DgvResultado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_BuscaCliente As System.Windows.Forms.Button
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtrut As System.Windows.Forms.TextBox
    Friend WithEvents txtclinombre As System.Windows.Forms.TextBox
    Friend WithEvents verificador As System.Windows.Forms.TextBox
    Friend WithEvents DgvResultado As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Btn_Calcular As System.Windows.Forms.Button
    Friend WithEvents btn_nuevo As System.Windows.Forms.Button
    Friend WithEvents btnExcel As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class

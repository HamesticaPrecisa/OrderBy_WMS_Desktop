<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_InformeTunel
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
        Me.dtFinal = New System.Windows.Forms.DateTimePicker()
        Me.dtInicio = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtClirut = New System.Windows.Forms.TextBox()
        Me.txtclinom = New System.Windows.Forms.TextBox()
        Me.btn_BuscaCliente = New System.Windows.Forms.Button()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.btn_nuevo = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Btn_Calcular = New System.Windows.Forms.Button()
        Me.DgvResultado = New System.Windows.Forms.DataGridView()
        Me.txtkilos = New System.Windows.Forms.TextBox()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.GroupBox4.SuspendLayout()
        CType(Me.DgvResultado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtFinal
        '
        Me.dtFinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFinal.Location = New System.Drawing.Point(393, 61)
        Me.dtFinal.Name = "dtFinal"
        Me.dtFinal.Size = New System.Drawing.Size(103, 20)
        Me.dtFinal.TabIndex = 61
        '
        'dtInicio
        '
        Me.dtInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtInicio.Location = New System.Drawing.Point(131, 61)
        Me.dtInicio.Name = "dtInicio"
        Me.dtInicio.Size = New System.Drawing.Size(103, 20)
        Me.dtInicio.TabIndex = 60
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(290, 65)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 13)
        Me.Label2.TabIndex = 59
        Me.Label2.Text = "FECHA FINAL"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(13, 65)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 13)
        Me.Label1.TabIndex = 58
        Me.Label1.Text = "FECHA INICIAL"
        '
        'TxtClirut
        '
        Me.TxtClirut.Location = New System.Drawing.Point(77, 23)
        Me.TxtClirut.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TxtClirut.MaxLength = 8
        Me.TxtClirut.Name = "TxtClirut"
        Me.TxtClirut.ReadOnly = True
        Me.TxtClirut.Size = New System.Drawing.Size(82, 20)
        Me.TxtClirut.TabIndex = 57
        '
        'txtclinom
        '
        Me.txtclinom.Enabled = False
        Me.txtclinom.Location = New System.Drawing.Point(187, 23)
        Me.txtclinom.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtclinom.Name = "txtclinom"
        Me.txtclinom.ReadOnly = True
        Me.txtclinom.Size = New System.Drawing.Size(309, 20)
        Me.txtclinom.TabIndex = 56
        '
        'btn_BuscaCliente
        '
        Me.btn_BuscaCliente.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.buscar_24
        Me.btn_BuscaCliente.Location = New System.Drawing.Point(162, 22)
        Me.btn_BuscaCliente.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btn_BuscaCliente.Name = "btn_BuscaCliente"
        Me.btn_BuscaCliente.Size = New System.Drawing.Size(21, 22)
        Me.btn_BuscaCliente.TabIndex = 55
        Me.btn_BuscaCliente.UseVisualStyleBackColor = True
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.BackColor = System.Drawing.Color.Transparent
        Me.Label43.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label43.ForeColor = System.Drawing.Color.White
        Me.Label43.Location = New System.Drawing.Point(13, 27)
        Me.Label43.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(56, 13)
        Me.Label43.TabIndex = 62
        Me.Label43.Text = "CLIENTE"
        '
        'btn_nuevo
        '
        Me.btn_nuevo.FlatAppearance.BorderSize = 0
        Me.btn_nuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_nuevo.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_hojanueva
        Me.btn_nuevo.Location = New System.Drawing.Point(6, 74)
        Me.btn_nuevo.Name = "btn_nuevo"
        Me.btn_nuevo.Size = New System.Drawing.Size(63, 63)
        Me.btn_nuevo.TabIndex = 30
        Me.btn_nuevo.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.Btn_Calcular)
        Me.GroupBox4.Controls.Add(Me.btn_nuevo)
        Me.GroupBox4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(916, 93)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(75, 143)
        Me.GroupBox4.TabIndex = 63
        Me.GroupBox4.TabStop = False
        '
        'Btn_Calcular
        '
        Me.Btn_Calcular.FlatAppearance.BorderSize = 0
        Me.Btn_Calcular.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_Calcular.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_soportante
        Me.Btn_Calcular.Location = New System.Drawing.Point(6, 15)
        Me.Btn_Calcular.Name = "Btn_Calcular"
        Me.Btn_Calcular.Size = New System.Drawing.Size(63, 63)
        Me.Btn_Calcular.TabIndex = 110
        Me.Btn_Calcular.UseVisualStyleBackColor = True
        '
        'DgvResultado
        '
        Me.DgvResultado.AllowUserToAddRows = False
        Me.DgvResultado.AllowUserToDeleteRows = False
        Me.DgvResultado.BackgroundColor = System.Drawing.Color.Gray
        Me.DgvResultado.ColumnHeadersHeight = 28
        Me.DgvResultado.Location = New System.Drawing.Point(16, 93)
        Me.DgvResultado.Name = "DgvResultado"
        Me.DgvResultado.ReadOnly = True
        Me.DgvResultado.Size = New System.Drawing.Size(882, 349)
        Me.DgvResultado.TabIndex = 108
        '
        'txtkilos
        '
        Me.txtkilos.Enabled = False
        Me.txtkilos.Location = New System.Drawing.Point(830, 459)
        Me.txtkilos.Name = "txtkilos"
        Me.txtkilos.Size = New System.Drawing.Size(68, 20)
        Me.txtkilos.TabIndex = 110
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.BackColor = System.Drawing.Color.Transparent
        Me.Label40.ForeColor = System.Drawing.Color.White
        Me.Label40.Location = New System.Drawing.Point(735, 462)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(72, 13)
        Me.Label40.TabIndex = 109
        Me.Label40.Text = "TONELADAS"
        '
        'Frm_InformeTunel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(1019, 491)
        Me.Controls.Add(Me.txtkilos)
        Me.Controls.Add(Me.Label40)
        Me.Controls.Add(Me.DgvResultado)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.Label43)
        Me.Controls.Add(Me.dtFinal)
        Me.Controls.Add(Me.dtInicio)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtClirut)
        Me.Controls.Add(Me.btn_BuscaCliente)
        Me.Controls.Add(Me.txtclinom)
        Me.Name = "Frm_InformeTunel"
        Me.Text = "Informe Ingreso Tuneles"
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.DgvResultado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtClirut As System.Windows.Forms.TextBox
    Friend WithEvents btn_BuscaCliente As System.Windows.Forms.Button
    Friend WithEvents txtclinom As System.Windows.Forms.TextBox
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents btn_nuevo As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Btn_Calcular As System.Windows.Forms.Button
    Friend WithEvents DgvResultado As System.Windows.Forms.DataGridView
    Friend WithEvents txtkilos As System.Windows.Forms.TextBox
    Friend WithEvents Label40 As System.Windows.Forms.Label
End Class

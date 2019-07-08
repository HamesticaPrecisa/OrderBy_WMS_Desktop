<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_AddSugerenciaPos
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
        Me.btn_BuscaCliente = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtrut = New System.Windows.Forms.TextBox()
        Me.txtclinombre = New System.Windows.Forms.TextBox()
        Me.verificador = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btn_BuscaCliente
        '
        Me.btn_BuscaCliente.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.buscar_24
        Me.btn_BuscaCliente.Location = New System.Drawing.Point(245, 42)
        Me.btn_BuscaCliente.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btn_BuscaCliente.Name = "btn_BuscaCliente"
        Me.btn_BuscaCliente.Size = New System.Drawing.Size(24, 24)
        Me.btn_BuscaCliente.TabIndex = 309
        Me.btn_BuscaCliente.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(36, 46)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(52, 13)
        Me.Label15.TabIndex = 305
        Me.Label15.Text = "CLIENTE"
        '
        'txtrut
        '
        Me.txtrut.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtrut.Location = New System.Drawing.Point(139, 43)
        Me.txtrut.MaxLength = 8
        Me.txtrut.Name = "txtrut"
        Me.txtrut.Size = New System.Drawing.Size(77, 21)
        Me.txtrut.TabIndex = 306
        '
        'txtclinombre
        '
        Me.txtclinombre.Enabled = False
        Me.txtclinombre.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtclinombre.Location = New System.Drawing.Point(272, 44)
        Me.txtclinombre.Name = "txtclinombre"
        Me.txtclinombre.Size = New System.Drawing.Size(324, 21)
        Me.txtclinombre.TabIndex = 308
        '
        'verificador
        '
        Me.verificador.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.verificador.Location = New System.Drawing.Point(223, 43)
        Me.verificador.MaxLength = 1
        Me.verificador.Name = "verificador"
        Me.verificador.Size = New System.Drawing.Size(19, 21)
        Me.verificador.TabIndex = 307
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(214, 46)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(10, 13)
        Me.Label8.TabIndex = 310
        Me.Label8.Text = "-"
        '
        'Frm_AddSugerenciaPos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(649, 407)
        Me.Controls.Add(Me.btn_BuscaCliente)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtrut)
        Me.Controls.Add(Me.txtclinombre)
        Me.Controls.Add(Me.verificador)
        Me.Controls.Add(Me.Label8)
        Me.Name = "Frm_AddSugerenciaPos"
        Me.Text = "Sugerencias De Posicionamiento"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_BuscaCliente As System.Windows.Forms.Button
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtrut As System.Windows.Forms.TextBox
    Friend WithEvents txtclinombre As System.Windows.Forms.TextBox
    Friend WithEvents verificador As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
End Class

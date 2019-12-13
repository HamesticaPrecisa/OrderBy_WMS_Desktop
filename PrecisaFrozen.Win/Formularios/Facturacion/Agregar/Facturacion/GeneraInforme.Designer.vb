<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GeneraInforme
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
        Me.Button2 = New System.Windows.Forms.Button()
        Me.btnExcel = New System.Windows.Forms.Button()
        Me.DgvResultado = New System.Windows.Forms.DataGridView()
        CType(Me.DgvResultado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Transparent
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_lupa
        Me.Button2.Location = New System.Drawing.Point(12, 30)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(63, 63)
        Me.Button2.TabIndex = 111
        Me.Button2.UseVisualStyleBackColor = False
        '
        'btnExcel
        '
        Me.btnExcel.BackColor = System.Drawing.Color.Transparent
        Me.btnExcel.FlatAppearance.BorderSize = 0
        Me.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExcel.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_xls
        Me.btnExcel.Location = New System.Drawing.Point(721, 321)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(63, 63)
        Me.btnExcel.TabIndex = 110
        Me.btnExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExcel.UseVisualStyleBackColor = False
        '
        'DgvResultado
        '
        Me.DgvResultado.BackgroundColor = System.Drawing.SystemColors.GrayText
        Me.DgvResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvResultado.Location = New System.Drawing.Point(12, 99)
        Me.DgvResultado.Name = "DgvResultado"
        Me.DgvResultado.Size = New System.Drawing.Size(772, 216)
        Me.DgvResultado.TabIndex = 121
        '
        'GeneraInforme
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(796, 394)
        Me.Controls.Add(Me.DgvResultado)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.btnExcel)
        Me.Name = "GeneraInforme"
        Me.Text = "GeneraInforme"
        CType(Me.DgvResultado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents btnExcel As System.Windows.Forms.Button
    Friend WithEvents DgvResultado As System.Windows.Forms.DataGridView
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_ParametrosImpresion
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtpagina = New System.Windows.Forms.TextBox()
        Me.Btn_Imprimir = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.RbPaginas = New System.Windows.Forms.RadioButton()
        Me.RbTodo = New System.Windows.Forms.RadioButton()
        Me.DudCopias = New System.Windows.Forms.NumericUpDown()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DudCopias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.DudCopias)
        Me.GroupBox1.Controls.Add(Me.txtpagina)
        Me.GroupBox1.Controls.Add(Me.Btn_Imprimir)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.RbPaginas)
        Me.GroupBox1.Controls.Add(Me.RbTodo)
        Me.GroupBox1.Location = New System.Drawing.Point(25, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(367, 135)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Intervalo de páginas"
        '
        'txtpagina
        '
        Me.txtpagina.Location = New System.Drawing.Point(91, 83)
        Me.txtpagina.Name = "txtpagina"
        Me.txtpagina.Size = New System.Drawing.Size(44, 21)
        Me.txtpagina.TabIndex = 7
        '
        'Btn_Imprimir
        '
        Me.Btn_Imprimir.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.printer
        Me.Btn_Imprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btn_Imprimir.Location = New System.Drawing.Point(221, 84)
        Me.Btn_Imprimir.Name = "Btn_Imprimir"
        Me.Btn_Imprimir.Size = New System.Drawing.Size(120, 40)
        Me.Btn_Imprimir.TabIndex = 5
        Me.Btn_Imprimir.Text = "&Imprimir  "
        Me.Btn_Imprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Btn_Imprimir.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(176, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(110, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Número de c&opias"
        '
        'RbPaginas
        '
        Me.RbPaginas.AutoSize = True
        Me.RbPaginas.Location = New System.Drawing.Point(22, 84)
        Me.RbPaginas.Name = "RbPaginas"
        Me.RbPaginas.Size = New System.Drawing.Size(63, 17)
        Me.RbPaginas.TabIndex = 1
        Me.RbPaginas.Text = "Pá&gina"
        Me.RbPaginas.UseVisualStyleBackColor = True
        '
        'RbTodo
        '
        Me.RbTodo.AutoSize = True
        Me.RbTodo.Checked = True
        Me.RbTodo.Location = New System.Drawing.Point(22, 36)
        Me.RbTodo.Name = "RbTodo"
        Me.RbTodo.Size = New System.Drawing.Size(53, 17)
        Me.RbTodo.TabIndex = 0
        Me.RbTodo.TabStop = True
        Me.RbTodo.Text = "&Todo"
        Me.RbTodo.UseVisualStyleBackColor = True
        '
        'DudCopias
        '
        Me.DudCopias.Location = New System.Drawing.Point(296, 36)
        Me.DudCopias.Name = "DudCopias"
        Me.DudCopias.Size = New System.Drawing.Size(45, 21)
        Me.DudCopias.TabIndex = 1
        '
        'Frm_ParametrosImpresion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(415, 183)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "Frm_ParametrosImpresion"
        Me.Text = "Parametros de impresión"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DudCopias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RbPaginas As System.Windows.Forms.RadioButton
    Friend WithEvents RbTodo As System.Windows.Forms.RadioButton
    Friend WithEvents Btn_Imprimir As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtpagina As System.Windows.Forms.TextBox
    Friend WithEvents DudCopias As System.Windows.Forms.NumericUpDown
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_CategoriasAyuda
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.cat_cod = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cat_nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cat_cod, Me.cat_nombre})
        Me.DataGridView1.Location = New System.Drawing.Point(14, 12)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(540, 247)
        Me.DataGridView1.TabIndex = 0
        '
        'cat_cod
        '
        Me.cat_cod.DataPropertyName = "Priv_id"
        Me.cat_cod.HeaderText = "Codigo"
        Me.cat_cod.Name = "cat_cod"
        Me.cat_cod.ReadOnly = True
        Me.cat_cod.Width = 60
        '
        'cat_nombre
        '
        Me.cat_nombre.DataPropertyName = "Priv_Nombre"
        Me.cat_nombre.HeaderText = "Descripción"
        Me.cat_nombre.Name = "cat_nombre"
        Me.cat_nombre.ReadOnly = True
        Me.cat_nombre.Width = 400
        '
        'Frm_CategoriasAyuda
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.fondo_completo
        Me.ClientSize = New System.Drawing.Size(568, 271)
        Me.Controls.Add(Me.DataGridView1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "Frm_CategoriasAyuda"
        Me.ShowIcon = False
        Me.Text = "Listado de Categorias"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents cat_cod As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cat_nombre As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

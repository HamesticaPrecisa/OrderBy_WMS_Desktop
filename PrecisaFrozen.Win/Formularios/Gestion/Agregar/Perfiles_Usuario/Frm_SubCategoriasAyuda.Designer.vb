<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_SubcategoriasAyuda
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
        Me.Cat_codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CAt_descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark
        Me.DataGridView1.ColumnHeadersHeight = 28
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cat_cod, Me.cat_nombre, Me.Cat_codigo, Me.CAt_descripcion})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(10, 10)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(729, 249)
        Me.DataGridView1.TabIndex = 1
        '
        'cat_cod
        '
        Me.cat_cod.DataPropertyName = "SPriv_id"
        Me.cat_cod.HeaderText = "Codigo"
        Me.cat_cod.Name = "cat_cod"
        Me.cat_cod.ReadOnly = True
        Me.cat_cod.Width = 60
        '
        'cat_nombre
        '
        Me.cat_nombre.DataPropertyName = "SPriv_Nombre"
        Me.cat_nombre.HeaderText = "Descripción"
        Me.cat_nombre.Name = "cat_nombre"
        Me.cat_nombre.ReadOnly = True
        Me.cat_nombre.Width = 400
        '
        'Cat_codigo
        '
        Me.Cat_codigo.DataPropertyName = "Spriv_PrivId"
        Me.Cat_codigo.HeaderText = "CodCat"
        Me.Cat_codigo.MinimumWidth = 2
        Me.Cat_codigo.Name = "Cat_codigo"
        Me.Cat_codigo.ReadOnly = True
        Me.Cat_codigo.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Cat_codigo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Cat_codigo.Width = 2
        '
        'CAt_descripcion
        '
        Me.CAt_descripcion.DataPropertyName = "Priv_nombre"
        Me.CAt_descripcion.HeaderText = "Categoria"
        Me.CAt_descripcion.Name = "CAt_descripcion"
        Me.CAt_descripcion.ReadOnly = True
        Me.CAt_descripcion.Width = 200
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "SPriv_id"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Codigo"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 60
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "SPriv_Nombre"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Descripción"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 400
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "Spriv_PrivId"
        Me.DataGridViewTextBoxColumn3.HeaderText = "CodCat"
        Me.DataGridViewTextBoxColumn3.MinimumWidth = 2
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn3.Width = 2
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "Priv_nombre"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Categoria"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Width = 200
        '
        'Frm_SubcategoriasAyuda
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(749, 269)
        Me.Controls.Add(Me.DataGridView1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "Frm_SubcategoriasAyuda"
        Me.Padding = New System.Windows.Forms.Padding(10)
        Me.Text = "Listado de SubCategorias"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents cat_cod As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cat_nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cat_codigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CAt_descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

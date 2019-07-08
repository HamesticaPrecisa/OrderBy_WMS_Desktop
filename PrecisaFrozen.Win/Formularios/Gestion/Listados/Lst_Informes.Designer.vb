<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Lst_Informes
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
        Me.components = New System.ComponentModel.Container()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Btn_Guardar = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Rb_tipo = New System.Windows.Forms.RadioButton()
        Me.Rb_estado = New System.Windows.Forms.RadioButton()
        Me.Rb_nombre = New System.Windows.Forms.RadioButton()
        Me.Rb_Codigo = New System.Windows.Forms.RadioButton()
        Me.tbl_informes = New System.Windows.Forms.DataGridView()
        Me.Codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Columnas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chkact = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.tbl_informes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Btn_Guardar)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.tbl_informes)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(12, 60, 12, 40)
        Me.GroupBox1.Size = New System.Drawing.Size(807, 513)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        '
        'Btn_Guardar
        '
        Me.Btn_Guardar.FlatAppearance.BorderSize = 0
        Me.Btn_Guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_Guardar.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.barra
        Me.Btn_Guardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btn_Guardar.Location = New System.Drawing.Point(667, 17)
        Me.Btn_Guardar.Name = "Btn_Guardar"
        Me.Btn_Guardar.Size = New System.Drawing.Size(125, 50)
        Me.Btn_Guardar.TabIndex = 54
        Me.Btn_Guardar.Text = "           Guardar"
        Me.Btn_Guardar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btn_Guardar.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.Rb_tipo)
        Me.GroupBox2.Controls.Add(Me.Rb_estado)
        Me.GroupBox2.Controls.Add(Me.Rb_nombre)
        Me.GroupBox2.Controls.Add(Me.Rb_Codigo)
        Me.GroupBox2.ForeColor = System.Drawing.Color.White
        Me.GroupBox2.Location = New System.Drawing.Point(15, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(422, 53)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Ordenar por"
        '
        'Rb_tipo
        '
        Me.Rb_tipo.AutoSize = True
        Me.Rb_tipo.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rb_tipo.Location = New System.Drawing.Point(198, 20)
        Me.Rb_tipo.Name = "Rb_tipo"
        Me.Rb_tipo.Size = New System.Drawing.Size(51, 18)
        Me.Rb_tipo.TabIndex = 4
        Me.Rb_tipo.Text = "Tipo"
        Me.Rb_tipo.UseVisualStyleBackColor = True
        '
        'Rb_estado
        '
        Me.Rb_estado.AutoSize = True
        Me.Rb_estado.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rb_estado.Location = New System.Drawing.Point(285, 20)
        Me.Rb_estado.Name = "Rb_estado"
        Me.Rb_estado.Size = New System.Drawing.Size(69, 18)
        Me.Rb_estado.TabIndex = 3
        Me.Rb_estado.Text = "Estado"
        Me.Rb_estado.UseVisualStyleBackColor = True
        '
        'Rb_nombre
        '
        Me.Rb_nombre.AutoSize = True
        Me.Rb_nombre.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rb_nombre.Location = New System.Drawing.Point(105, 19)
        Me.Rb_nombre.Name = "Rb_nombre"
        Me.Rb_nombre.Size = New System.Drawing.Size(74, 18)
        Me.Rb_nombre.TabIndex = 2
        Me.Rb_nombre.Text = "Nombre"
        Me.Rb_nombre.UseVisualStyleBackColor = True
        '
        'Rb_Codigo
        '
        Me.Rb_Codigo.AutoSize = True
        Me.Rb_Codigo.Checked = True
        Me.Rb_Codigo.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rb_Codigo.Location = New System.Drawing.Point(17, 19)
        Me.Rb_Codigo.Name = "Rb_Codigo"
        Me.Rb_Codigo.Size = New System.Drawing.Size(69, 18)
        Me.Rb_Codigo.TabIndex = 0
        Me.Rb_Codigo.TabStop = True
        Me.Rb_Codigo.Text = "Codigo"
        Me.Rb_Codigo.UseVisualStyleBackColor = True
        '
        'tbl_informes
        '
        Me.tbl_informes.AllowUserToAddRows = False
        Me.tbl_informes.AllowUserToDeleteRows = False
        Me.tbl_informes.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark
        Me.tbl_informes.ColumnHeadersHeight = 25
        Me.tbl_informes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Codigo, Me.Descripcion, Me.Tipo, Me.Columnas, Me.chkact})
        Me.tbl_informes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbl_informes.Location = New System.Drawing.Point(12, 73)
        Me.tbl_informes.MultiSelect = False
        Me.tbl_informes.Name = "tbl_informes"
        Me.tbl_informes.ReadOnly = True
        Me.tbl_informes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.tbl_informes.Size = New System.Drawing.Size(783, 400)
        Me.tbl_informes.TabIndex = 1
        '
        'Codigo
        '
        Me.Codigo.DataPropertyName = "Codigo"
        Me.Codigo.HeaderText = "Codigo"
        Me.Codigo.Name = "Codigo"
        Me.Codigo.ReadOnly = True
        Me.Codigo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Descripcion
        '
        Me.Descripcion.DataPropertyName = "Informe"
        Me.Descripcion.HeaderText = "Informe"
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.ReadOnly = True
        Me.Descripcion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Descripcion.Width = 250
        '
        'Tipo
        '
        Me.Tipo.DataPropertyName = "Tipo"
        Me.Tipo.HeaderText = "Tipo"
        Me.Tipo.Name = "Tipo"
        Me.Tipo.ReadOnly = True
        '
        'Columnas
        '
        Me.Columnas.DataPropertyName = "Estado"
        Me.Columnas.HeaderText = "Estado"
        Me.Columnas.Name = "Columnas"
        Me.Columnas.ReadOnly = True
        Me.Columnas.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Columnas.Width = 180
        '
        'chkact
        '
        Me.chkact.DataPropertyName = "Estado"
        Me.chkact.FalseValue = "Deshabilitado"
        Me.chkact.HeaderText = "Activar/Desactivar"
        Me.chkact.Name = "chkact"
        Me.chkact.ReadOnly = True
        Me.chkact.TrueValue = "Habilitado"
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "inf_cod"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Codigo"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "inf_nom"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Informe"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn2.Width = 250
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "inf_estado"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Estado"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn3.Width = 180
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "Estado"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Estado"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn4.Width = 180
        '
        'Lst_Informes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(807, 513)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Lst_Informes"
        Me.Text = "Activar/Desactivar"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.tbl_informes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents tbl_informes As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Rb_nombre As System.Windows.Forms.RadioButton
    Friend WithEvents Rb_Codigo As System.Windows.Forms.RadioButton
    Friend WithEvents BindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Btn_Guardar As System.Windows.Forms.Button
    Friend WithEvents Codigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Columnas As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chkact As System.Windows.Forms.DataGridViewCheckBoxColumn
    Public WithEvents Rb_tipo As System.Windows.Forms.RadioButton
    Public WithEvents Rb_estado As System.Windows.Forms.RadioButton
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

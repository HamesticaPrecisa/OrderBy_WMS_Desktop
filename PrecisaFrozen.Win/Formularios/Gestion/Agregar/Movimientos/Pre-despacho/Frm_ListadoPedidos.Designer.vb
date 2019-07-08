<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_ListadoPedidos
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
        Me.components = New System.ComponentModel.Container()
        Me.DgvPedidos = New System.Windows.Forms.DataGridView()
        Me.CODIGO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CLIENTE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECHA_SOLICITUD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SOP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SELECCION = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ORDENCONJUNTA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DgvPedidos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DgvPedidos
        '
        Me.DgvPedidos.AllowUserToAddRows = False
        Me.DgvPedidos.AllowUserToDeleteRows = False
        Me.DgvPedidos.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark
        Me.DgvPedidos.ColumnHeadersHeight = 28
        Me.DgvPedidos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CODIGO, Me.CLIENTE, Me.FECHA_SOLICITUD, Me.SOP, Me.SELECCION, Me.ORDENCONJUNTA})
        Me.DgvPedidos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvPedidos.Location = New System.Drawing.Point(10, 19)
        Me.DgvPedidos.Name = "DgvPedidos"
        Me.DgvPedidos.ReadOnly = True
        Me.DgvPedidos.RowHeadersWidth = 15
        Me.DgvPedidos.Size = New System.Drawing.Size(840, 236)
        Me.DgvPedidos.TabIndex = 0
        '
        'CODIGO
        '
        Me.CODIGO.DataPropertyName = "orden"
        Me.CODIGO.HeaderText = "CODIGO"
        Me.CODIGO.Name = "CODIGO"
        Me.CODIGO.ReadOnly = True
        Me.CODIGO.Width = 80
        '
        'CLIENTE
        '
        Me.CLIENTE.DataPropertyName = "pedido"
        Me.CLIENTE.HeaderText = "N° SOLICITUD"
        Me.CLIENTE.Name = "CLIENTE"
        Me.CLIENTE.ReadOnly = True
        Me.CLIENTE.Width = 250
        '
        'FECHA_SOLICITUD
        '
        Me.FECHA_SOLICITUD.DataPropertyName = "fecha"
        Me.FECHA_SOLICITUD.HeaderText = "F. SOLICITUD"
        Me.FECHA_SOLICITUD.Name = "FECHA_SOLICITUD"
        Me.FECHA_SOLICITUD.ReadOnly = True
        Me.FECHA_SOLICITUD.Width = 110
        '
        'SOP
        '
        Me.SOP.DataPropertyName = "destino"
        Me.SOP.HeaderText = "SOPORTANTES"
        Me.SOP.Name = "SOP"
        Me.SOP.ReadOnly = True
        '
        'SELECCION
        '
        Me.SELECCION.DataPropertyName = "caj"
        Me.SELECCION.HeaderText = "SELECCION"
        Me.SELECCION.Name = "SELECCION"
        Me.SELECCION.ReadOnly = True
        Me.SELECCION.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.SELECCION.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'ORDENCONJUNTA
        '
        Me.ORDENCONJUNTA.DataPropertyName = "ordenconjunta"
        Me.ORDENCONJUNTA.HeaderText = "ORDENCONJUNTA"
        Me.ORDENCONJUNTA.Name = "ORDENCONJUNTA"
        Me.ORDENCONJUNTA.ReadOnly = True
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.DgvPedidos)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(10, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(10, 5, 10, 10)
        Me.GroupBox1.Size = New System.Drawing.Size(860, 265)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'Timer1
        '
        Me.Timer1.Interval = 1500
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "orden"
        Me.DataGridViewTextBoxColumn1.HeaderText = "CODIGO"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 80
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "pedido"
        Me.DataGridViewTextBoxColumn2.HeaderText = "N° SOLICITUD"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 200
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "fecha"
        Me.DataGridViewTextBoxColumn3.HeaderText = "F. SOLICITUD"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 110
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "destino"
        Me.DataGridViewTextBoxColumn4.HeaderText = "SOPORTANTES"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'Frm_ListadoPedidos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(880, 281)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "Frm_ListadoPedidos"
        Me.Padding = New System.Windows.Forms.Padding(10, 6, 10, 10)
        Me.ShowIcon = False
        Me.Text = "LISTADO DE PEDIDOS PENDIENTES"
        CType(Me.DgvPedidos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DgvPedidos As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODIGO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CLIENTE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECHA_SOLICITUD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SOP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SELECCION As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ORDENCONJUNTA As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

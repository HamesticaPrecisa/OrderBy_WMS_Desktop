<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Lst_Pedidos_Clientes
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
        Me.Dgvclientespedidos = New System.Windows.Forms.DataGridView()
        Me.RUT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PERSONAL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.Dgvclientespedidos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Dgvclientespedidos
        '
        Me.Dgvclientespedidos.AllowUserToAddRows = False
        Me.Dgvclientespedidos.AllowUserToDeleteRows = False
        Me.Dgvclientespedidos.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Dgvclientespedidos.ColumnHeadersHeight = 30
        Me.Dgvclientespedidos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.RUT, Me.PERSONAL})
        Me.Dgvclientespedidos.Location = New System.Drawing.Point(12, 12)
        Me.Dgvclientespedidos.Name = "Dgvclientespedidos"
        Me.Dgvclientespedidos.ReadOnly = True
        Me.Dgvclientespedidos.Size = New System.Drawing.Size(353, 337)
        Me.Dgvclientespedidos.TabIndex = 4
        '
        'RUT
        '
        Me.RUT.DataPropertyName = "ID"
        Me.RUT.HeaderText = "Id"
        Me.RUT.Name = "RUT"
        Me.RUT.ReadOnly = True
        Me.RUT.Width = 50
        '
        'PERSONAL
        '
        Me.PERSONAL.DataPropertyName = "Nombre"
        Me.PERSONAL.HeaderText = "Nombre Cliente"
        Me.PERSONAL.Name = "PERSONAL"
        Me.PERSONAL.ReadOnly = True
        Me.PERSONAL.Width = 250
        '
        'Lst_Pedidos_Clientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(387, 405)
        Me.Controls.Add(Me.Dgvclientespedidos)
        Me.Name = "Lst_Pedidos_Clientes"
        Me.Text = "Lst_Pedidos_Clientes"
        CType(Me.Dgvclientespedidos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Dgvclientespedidos As System.Windows.Forms.DataGridView
    Friend WithEvents RUT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PERSONAL As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Lst_Pedidos_Fecha
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
        Me.DgvLimiteFechas = New System.Windows.Forms.DataGridView()
        Me.RUT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PERSONAL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DgvLimiteFechas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DgvLimiteFechas
        '
        Me.DgvLimiteFechas.AllowUserToAddRows = False
        Me.DgvLimiteFechas.AllowUserToDeleteRows = False
        Me.DgvLimiteFechas.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark
        Me.DgvLimiteFechas.ColumnHeadersHeight = 30
        Me.DgvLimiteFechas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.RUT, Me.PERSONAL})
        Me.DgvLimiteFechas.Location = New System.Drawing.Point(0, 0)
        Me.DgvLimiteFechas.Name = "DgvLimiteFechas"
        Me.DgvLimiteFechas.ReadOnly = True
        Me.DgvLimiteFechas.Size = New System.Drawing.Size(631, 257)
        Me.DgvLimiteFechas.TabIndex = 3
        '
        'RUT
        '
        Me.RUT.DataPropertyName = "Fecha"
        Me.RUT.HeaderText = "Fecha Con Limite"
        Me.RUT.Name = "RUT"
        Me.RUT.ReadOnly = True
        Me.RUT.Width = 200
        '
        'PERSONAL
        '
        Me.PERSONAL.DataPropertyName = "Limite"
        Me.PERSONAL.HeaderText = "Limite Maximo"
        Me.PERSONAL.Name = "PERSONAL"
        Me.PERSONAL.ReadOnly = True
        Me.PERSONAL.Width = 300
        '
        'Lst_Pedidos_Fecha
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(656, 295)
        Me.Controls.Add(Me.DgvLimiteFechas)
        Me.Name = "Lst_Pedidos_Fecha"
        Me.Text = "Lst_Pedidos_Fecha"
        CType(Me.DgvLimiteFechas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DgvLimiteFechas As System.Windows.Forms.DataGridView
    Friend WithEvents RUT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PERSONAL As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

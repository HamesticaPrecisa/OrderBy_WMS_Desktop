<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_ListadoUsuarios
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
        Me.DgvUsuarios = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtBuscador = New System.Windows.Forms.TextBox()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RUT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PERSONAL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.USUARIO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DgvUsuarios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DgvUsuarios
        '
        Me.DgvUsuarios.AllowUserToAddRows = False
        Me.DgvUsuarios.AllowUserToDeleteRows = False
        Me.DgvUsuarios.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark
        Me.DgvUsuarios.ColumnHeadersHeight = 30
        Me.DgvUsuarios.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.COD, Me.RUT, Me.PERSONAL, Me.USUARIO, Me.Estado})
        Me.DgvUsuarios.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvUsuarios.Location = New System.Drawing.Point(23, 20)
        Me.DgvUsuarios.Name = "DgvUsuarios"
        Me.DgvUsuarios.ReadOnly = True
        Me.DgvUsuarios.Size = New System.Drawing.Size(758, 238)
        Me.DgvUsuarios.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(27, 270)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "BUSCADOR"
        '
        'TxtBuscador
        '
        Me.TxtBuscador.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtBuscador.Location = New System.Drawing.Point(107, 267)
        Me.TxtBuscador.MaxLength = 30
        Me.TxtBuscador.Name = "TxtBuscador"
        Me.TxtBuscador.Size = New System.Drawing.Size(436, 21)
        Me.TxtBuscador.TabIndex = 0
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "usu_codigo"
        Me.DataGridViewTextBoxColumn1.HeaderText = "COD"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 50
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "usu_rut"
        Me.DataGridViewTextBoxColumn2.HeaderText = "RUT"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 90
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "usuario"
        Me.DataGridViewTextBoxColumn3.HeaderText = "PERSONAL"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 250
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "usu_usuario"
        Me.DataGridViewTextBoxColumn4.HeaderText = "USUARIO"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 140
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "Estado"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Estado"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'COD
        '
        Me.COD.DataPropertyName = "usu_codigo"
        Me.COD.HeaderText = "COD"
        Me.COD.Name = "COD"
        Me.COD.ReadOnly = True
        Me.COD.Width = 50
        '
        'RUT
        '
        Me.RUT.DataPropertyName = "usu_rut"
        Me.RUT.HeaderText = "CODIGO"
        Me.RUT.Name = "RUT"
        Me.RUT.ReadOnly = True
        Me.RUT.Width = 90
        '
        'PERSONAL
        '
        Me.PERSONAL.DataPropertyName = "usuario"
        Me.PERSONAL.HeaderText = "PERSONAL"
        Me.PERSONAL.Name = "PERSONAL"
        Me.PERSONAL.ReadOnly = True
        Me.PERSONAL.Width = 250
        '
        'USUARIO
        '
        Me.USUARIO.DataPropertyName = "usu_usuario"
        Me.USUARIO.HeaderText = "USUARIO"
        Me.USUARIO.Name = "USUARIO"
        Me.USUARIO.ReadOnly = True
        Me.USUARIO.Width = 140
        '
        'Estado
        '
        Me.Estado.DataPropertyName = "Estado"
        Me.Estado.HeaderText = "ESTADO"
        Me.Estado.Name = "Estado"
        Me.Estado.ReadOnly = True
        '
        'Frm_ListadoUsuarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(804, 293)
        Me.Controls.Add(Me.TxtBuscador)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DgvUsuarios)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "Frm_ListadoUsuarios"
        Me.Padding = New System.Windows.Forms.Padding(23, 20, 23, 35)
        Me.ShowIcon = False
        Me.Text = "Usuarios del sistema"
        CType(Me.DgvUsuarios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DgvUsuarios As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtBuscador As System.Windows.Forms.TextBox
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RUT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PERSONAL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents USUARIO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Estado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

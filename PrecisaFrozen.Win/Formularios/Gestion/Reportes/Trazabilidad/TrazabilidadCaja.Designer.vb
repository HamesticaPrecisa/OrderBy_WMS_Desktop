<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TrazabilidadCaja
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DgvCaja = New System.Windows.Forms.DataGridView()
        Me.printer = New System.Windows.Forms.DataGridViewImageColumn()
        Me.CODIGO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PALLET = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CLIENTE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PI = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NI = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ESTADO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TxtCodCaja = New System.Windows.Forms.TextBox()
        Me.DataGridViewImageColumn1 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DgvCaja, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(15, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "CODIGO"
        '
        'DgvCaja
        '
        Me.DgvCaja.AllowUserToAddRows = False
        Me.DgvCaja.AllowUserToDeleteRows = False
        Me.DgvCaja.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark
        Me.DgvCaja.ColumnHeadersHeight = 28
        Me.DgvCaja.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.printer, Me.CODIGO, Me.PALLET, Me.CLIENTE, Me.CA, Me.BA, Me.CO, Me.PI, Me.NI, Me.ESTADO})
        Me.DgvCaja.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvCaja.Location = New System.Drawing.Point(8, 17)
        Me.DgvCaja.Name = "DgvCaja"
        Me.DgvCaja.ReadOnly = True
        Me.DgvCaja.Size = New System.Drawing.Size(890, 319)
        Me.DgvCaja.TabIndex = 2
        '
        'printer
        '
        Me.printer.HeaderText = ""
        Me.printer.Image = Global.PrecisaFrozen.Win.My.Resources.Resources._1375930470_print
        Me.printer.Name = "printer"
        Me.printer.ReadOnly = True
        Me.printer.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.printer.Width = 30
        '
        'CODIGO
        '
        Me.CODIGO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.CODIGO.DataPropertyName = "Caj_cod"
        Me.CODIGO.HeaderText = "CAJA"
        Me.CODIGO.Name = "CODIGO"
        Me.CODIGO.ReadOnly = True
        Me.CODIGO.Width = 62
        '
        'PALLET
        '
        Me.PALLET.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.PALLET.DataPropertyName = "caj_pcod"
        Me.PALLET.HeaderText = "PALLET"
        Me.PALLET.Name = "PALLET"
        Me.PALLET.ReadOnly = True
        Me.PALLET.Width = 73
        '
        'CLIENTE
        '
        Me.CLIENTE.DataPropertyName = "cli_nomb"
        Me.CLIENTE.HeaderText = "CLIENTE"
        Me.CLIENTE.Name = "CLIENTE"
        Me.CLIENTE.ReadOnly = True
        Me.CLIENTE.Width = 250
        '
        'CA
        '
        Me.CA.DataPropertyName = "drec_camara"
        Me.CA.HeaderText = "CA"
        Me.CA.Name = "CA"
        Me.CA.ReadOnly = True
        Me.CA.Width = 35
        '
        'BA
        '
        Me.BA.DataPropertyName = "drec_banda"
        Me.BA.HeaderText = "BA"
        Me.BA.Name = "BA"
        Me.BA.ReadOnly = True
        Me.BA.Width = 35
        '
        'CO
        '
        Me.CO.DataPropertyName = "drec_colum"
        Me.CO.HeaderText = "CO"
        Me.CO.Name = "CO"
        Me.CO.ReadOnly = True
        Me.CO.Width = 35
        '
        'PI
        '
        Me.PI.DataPropertyName = "drec_piso"
        Me.PI.HeaderText = "PI"
        Me.PI.Name = "PI"
        Me.PI.ReadOnly = True
        Me.PI.Width = 35
        '
        'NI
        '
        Me.NI.DataPropertyName = "drec_nivel"
        Me.NI.HeaderText = "NI"
        Me.NI.Name = "NI"
        Me.NI.ReadOnly = True
        Me.NI.Width = 35
        '
        'ESTADO
        '
        Me.ESTADO.DataPropertyName = "estado"
        Me.ESTADO.HeaderText = "ESTADO"
        Me.ESTADO.Name = "ESTADO"
        Me.ESTADO.ReadOnly = True
        Me.ESTADO.Width = 130
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.DgvCaja)
        Me.GroupBox1.Location = New System.Drawing.Point(18, 58)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(8, 3, 8, 8)
        Me.GroupBox1.Size = New System.Drawing.Size(906, 344)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        '
        'TxtCodCaja
        '
        Me.TxtCodCaja.Location = New System.Drawing.Point(78, 16)
        Me.TxtCodCaja.Name = "TxtCodCaja"
        Me.TxtCodCaja.Size = New System.Drawing.Size(361, 21)
        Me.TxtCodCaja.TabIndex = 3
        '
        'DataGridViewImageColumn1
        '
        Me.DataGridViewImageColumn1.HeaderText = ""
        Me.DataGridViewImageColumn1.Image = Global.PrecisaFrozen.Win.My.Resources.Resources._1375930470_print
        Me.DataGridViewImageColumn1.Name = "DataGridViewImageColumn1"
        Me.DataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewImageColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "caj_pcod"
        Me.DataGridViewTextBoxColumn1.HeaderText = "PALLET"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "cli_nomb"
        Me.DataGridViewTextBoxColumn2.HeaderText = "CLIENTE"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "drec_camara"
        Me.DataGridViewTextBoxColumn3.HeaderText = "CA"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 50
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "drec_banda"
        Me.DataGridViewTextBoxColumn4.HeaderText = "BA"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 50
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "drec_colum"
        Me.DataGridViewTextBoxColumn5.HeaderText = "CO"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 50
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "drec_piso"
        Me.DataGridViewTextBoxColumn6.HeaderText = "PI"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Width = 50
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "drec_nivel"
        Me.DataGridViewTextBoxColumn7.HeaderText = "NI"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Width = 50
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "estado"
        Me.DataGridViewTextBoxColumn8.HeaderText = "ESTADO"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Width = 120
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "estado"
        Me.DataGridViewTextBoxColumn9.HeaderText = "ESTADO"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        Me.DataGridViewTextBoxColumn9.Width = 130
        '
        'TrazabilidadCaja
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(956, 419)
        Me.Controls.Add(Me.TxtCodCaja)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "TrazabilidadCaja"
        Me.Text = "Trazabilidad de envases"
        CType(Me.DgvCaja, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DgvCaja As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TxtCodCaja As System.Windows.Forms.TextBox
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewImageColumn1 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents printer As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents CODIGO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PALLET As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CLIENTE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PI As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NI As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ESTADO As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

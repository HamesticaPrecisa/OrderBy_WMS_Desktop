<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_RecuperaEtiq
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
        Me.DgvEtiq = New System.Windows.Forms.DataGridView()
        Me.FOLIO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CLIENTE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CONTRATO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DgvEtiq, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DgvEtiq
        '
        Me.DgvEtiq.AllowUserToAddRows = False
        Me.DgvEtiq.AllowUserToDeleteRows = False
        Me.DgvEtiq.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark
        Me.DgvEtiq.ColumnHeadersHeight = 28
        Me.DgvEtiq.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FOLIO, Me.CLIENTE, Me.CONTRATO})
        Me.DgvEtiq.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvEtiq.Location = New System.Drawing.Point(10, 10)
        Me.DgvEtiq.Name = "DgvEtiq"
        Me.DgvEtiq.ReadOnly = True
        Me.DgvEtiq.RowHeadersWidth = 30
        Me.DgvEtiq.Size = New System.Drawing.Size(722, 246)
        Me.DgvEtiq.TabIndex = 0
        '
        'FOLIO
        '
        Me.FOLIO.DataPropertyName = "etiq_codi"
        Me.FOLIO.HeaderText = "FOLIO"
        Me.FOLIO.Name = "FOLIO"
        Me.FOLIO.ReadOnly = True
        Me.FOLIO.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.FOLIO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.FOLIO.Width = 80
        '
        'CLIENTE
        '
        Me.CLIENTE.DataPropertyName = "cli_nomb"
        Me.CLIENTE.HeaderText = "CLIENTE"
        Me.CLIENTE.Name = "CLIENTE"
        Me.CLIENTE.ReadOnly = True
        Me.CLIENTE.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.CLIENTE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.CLIENTE.Width = 250
        '
        'CONTRATO
        '
        Me.CONTRATO.DataPropertyName = "cont_descr"
        Me.CONTRATO.HeaderText = "CONTRATO"
        Me.CONTRATO.Name = "CONTRATO"
        Me.CONTRATO.ReadOnly = True
        Me.CONTRATO.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.CONTRATO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.CONTRATO.Width = 200
        '
        'Frm_RecuperaEtiq
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(742, 266)
        Me.Controls.Add(Me.DgvEtiq)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(758, 304)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(758, 304)
        Me.Name = "Frm_RecuperaEtiq"
        Me.Padding = New System.Windows.Forms.Padding(10)
        Me.Text = "Seleccione el etiquetado a recuperar"
        CType(Me.DgvEtiq, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DgvEtiq As System.Windows.Forms.DataGridView
    Friend WithEvents FOLIO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CLIENTE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CONTRATO As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

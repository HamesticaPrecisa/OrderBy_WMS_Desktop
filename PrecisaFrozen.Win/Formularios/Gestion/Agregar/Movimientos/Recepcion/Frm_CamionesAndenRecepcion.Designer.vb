<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_CamionesAndenRecepcion
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.DgvCamiones = New System.Windows.Forms.DataGridView()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CbNoSeEncuentra = New System.Windows.Forms.CheckBox()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Folio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rutcho = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Rutcli = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chofer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DgvCamiones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(790, 346)
        Me.Panel1.TabIndex = 0
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.GroupBox1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 40)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Padding = New System.Windows.Forms.Padding(12, 10, 12, 10)
        Me.Panel3.Size = New System.Drawing.Size(790, 306)
        Me.Panel3.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.DgvCamiones)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(12, 10)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(10, 6, 10, 10)
        Me.GroupBox1.Size = New System.Drawing.Size(766, 286)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'DgvCamiones
        '
        Me.DgvCamiones.AllowUserToAddRows = False
        Me.DgvCamiones.AllowUserToDeleteRows = False
        Me.DgvCamiones.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark
        Me.DgvCamiones.ColumnHeadersHeight = 30
        Me.DgvCamiones.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Folio, Me.rutcho, Me.Cliente, Me.Rutcli, Me.chofer})
        Me.DgvCamiones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvCamiones.Location = New System.Drawing.Point(10, 20)
        Me.DgvCamiones.Name = "DgvCamiones"
        Me.DgvCamiones.ReadOnly = True
        Me.DgvCamiones.Size = New System.Drawing.Size(746, 256)
        Me.DgvCamiones.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.barra
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(790, 40)
        Me.Panel2.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Verdana", 10.75!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(786, 36)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "LISTADO DE CAMIONES EN ANDEN"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CbNoSeEncuentra
        '
        Me.CbNoSeEncuentra.AutoSize = True
        Me.CbNoSeEncuentra.BackColor = System.Drawing.Color.Transparent
        Me.CbNoSeEncuentra.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbNoSeEncuentra.ForeColor = System.Drawing.Color.White
        Me.CbNoSeEncuentra.Location = New System.Drawing.Point(22, 351)
        Me.CbNoSeEncuentra.Name = "CbNoSeEncuentra"
        Me.CbNoSeEncuentra.Size = New System.Drawing.Size(318, 17)
        Me.CbNoSeEncuentra.TabIndex = 2
        Me.CbNoSeEncuentra.Text = "EL CAMION NO SE ENCUENTRA EN ESTA LISTA"
        Me.CbNoSeEncuentra.UseVisualStyleBackColor = False
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "cl_fol"
        Me.DataGridViewTextBoxColumn1.HeaderText = "FOLIO"
        Me.DataGridViewTextBoxColumn1.MinimumWidth = 2
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 85
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "cl_rutcli"
        Me.DataGridViewTextBoxColumn2.HeaderText = "R.U.T"
        Me.DataGridViewTextBoxColumn2.MinimumWidth = 2
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn2.Width = 2
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "cli_nomb"
        Me.DataGridViewTextBoxColumn3.HeaderText = "CLIENTE"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 300
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "cl_chorut"
        Me.DataGridViewTextBoxColumn4.HeaderText = "R.U.T"
        Me.DataGridViewTextBoxColumn4.MinimumWidth = 85
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn4.Width = 85
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "cho_nombre"
        Me.DataGridViewTextBoxColumn5.HeaderText = "CHOFER"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 200
        '
        'Folio
        '
        Me.Folio.DataPropertyName = "cl_fol"
        Me.Folio.HeaderText = "FOLIO"
        Me.Folio.MinimumWidth = 2
        Me.Folio.Name = "Folio"
        Me.Folio.ReadOnly = True
        Me.Folio.Width = 85
        '
        'rutcho
        '
        Me.rutcho.DataPropertyName = "cl_rutcli"
        Me.rutcho.HeaderText = "R.U.T"
        Me.rutcho.MinimumWidth = 2
        Me.rutcho.Name = "rutcho"
        Me.rutcho.ReadOnly = True
        Me.rutcho.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.rutcho.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.rutcho.Width = 2
        '
        'Cliente
        '
        Me.Cliente.DataPropertyName = "cli_nomb"
        Me.Cliente.HeaderText = "CLIENTE"
        Me.Cliente.Name = "Cliente"
        Me.Cliente.ReadOnly = True
        Me.Cliente.Width = 300
        '
        'Rutcli
        '
        Me.Rutcli.DataPropertyName = "cl_chorut"
        Me.Rutcli.HeaderText = "CODIGO"
        Me.Rutcli.MinimumWidth = 85
        Me.Rutcli.Name = "Rutcli"
        Me.Rutcli.ReadOnly = True
        Me.Rutcli.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Rutcli.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Rutcli.Width = 85
        '
        'chofer
        '
        Me.chofer.DataPropertyName = "cho_nombre"
        Me.chofer.HeaderText = "CHOFER"
        Me.chofer.Name = "chofer"
        Me.chofer.ReadOnly = True
        Me.chofer.Width = 200
        '
        'Frm_CamionesAndenRecepcion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(790, 371)
        Me.Controls.Add(Me.CbNoSeEncuentra)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(744, 402)
        Me.Name = "Frm_CamionesAndenRecepcion"
        Me.Padding = New System.Windows.Forms.Padding(0, 0, 0, 25)
        Me.Text = "Listado de camiones en espera de descarga"
        Me.Panel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.DgvCamiones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents DgvCamiones As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CbNoSeEncuentra As System.Windows.Forms.CheckBox
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Folio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rutcho As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Rutcli As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chofer As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_AyudaServicios
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
        Me.txtbuscador = New System.Windows.Forms.TextBox()
        Me.DgvServicios = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DES = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DgvServicios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtbuscador
        '
        Me.txtbuscador.Location = New System.Drawing.Point(89, 3)
        Me.txtbuscador.Name = "txtbuscador"
        Me.txtbuscador.Size = New System.Drawing.Size(409, 21)
        Me.txtbuscador.TabIndex = 0
        '
        'DgvServicios
        '
        Me.DgvServicios.AllowUserToAddRows = False
        Me.DgvServicios.AllowUserToDeleteRows = False
        Me.DgvServicios.ColumnHeadersHeight = 28
        Me.DgvServicios.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.COD, Me.DES})
        Me.DgvServicios.Location = New System.Drawing.Point(12, 12)
        Me.DgvServicios.Name = "DgvServicios"
        Me.DgvServicios.ReadOnly = True
        Me.DgvServicios.Size = New System.Drawing.Size(484, 300)
        Me.DgvServicios.TabIndex = 3
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.txtbuscador)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 327)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(511, 29)
        Me.Panel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "BUSQUEDA"
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "COD"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 70
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "DESCRIPCION"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 350
        '
        'COD
        '
        Me.COD.DataPropertyName = "Dcon_servcod"
        Me.COD.HeaderText = "CODIGO"
        Me.COD.Name = "COD"
        Me.COD.ReadOnly = True
        Me.COD.Width = 70
        '
        'DES
        '
        Me.DES.DataPropertyName = "serv_nom"
        Me.DES.HeaderText = "DESCRIPCION"
        Me.DES.Name = "DES"
        Me.DES.ReadOnly = True
        Me.DES.Width = 350
        '
        'Frm_AyudaServicios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(511, 356)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.DgvServicios)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximumSize = New System.Drawing.Size(527, 394)
        Me.MinimumSize = New System.Drawing.Size(527, 394)
        Me.Name = "Frm_AyudaServicios"
        Me.Text = "LISTADO SERVICIOS"
        CType(Me.DgvServicios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtbuscador As System.Windows.Forms.TextBox
    Friend WithEvents DgvServicios As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DES As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

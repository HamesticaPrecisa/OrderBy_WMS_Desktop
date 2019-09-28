<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_ProductosCliente
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Data_Productos = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Txt_Soportante = New System.Windows.Forms.TextBox()
        Me.Cmbo_Producto = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CAMBIARPORESTEPALLETToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
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
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Folio_precisa = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FOLIO_CLIENTE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRODUCTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cajas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Kilos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CAMARA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BANDA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COLUMNA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PISO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NIVEL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        CType(Me.Data_Productos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.Data_Productos)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(892, 525)
        Me.Panel1.TabIndex = 0
        '
        'Data_Productos
        '
        Me.Data_Productos.AllowUserToAddRows = False
        Me.Data_Productos.AllowUserToDeleteRows = False
        Me.Data_Productos.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Data_Productos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Data_Productos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Folio_precisa, Me.FOLIO_CLIENTE, Me.PRODUCTO, Me.Cajas, Me.Kilos, Me.CAMARA, Me.BANDA, Me.COLUMNA, Me.PISO, Me.NIVEL})
        Me.Data_Productos.Location = New System.Drawing.Point(14, 78)
        Me.Data_Productos.Name = "Data_Productos"
        Me.Data_Productos.ReadOnly = True
        Me.Data_Productos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Data_Productos.Size = New System.Drawing.Size(853, 435)
        Me.Data_Productos.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Txt_Soportante)
        Me.GroupBox1.Controls.Add(Me.Cmbo_Producto)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(14, 10)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(853, 51)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "FILTRAR"
        '
        'Txt_Soportante
        '
        Me.Txt_Soportante.Location = New System.Drawing.Point(660, 18)
        Me.Txt_Soportante.Name = "Txt_Soportante"
        Me.Txt_Soportante.Size = New System.Drawing.Size(105, 21)
        Me.Txt_Soportante.TabIndex = 3
        '
        'Cmbo_Producto
        '
        Me.Cmbo_Producto.FormattingEnabled = True
        Me.Cmbo_Producto.Location = New System.Drawing.Point(109, 18)
        Me.Cmbo_Producto.Name = "Cmbo_Producto"
        Me.Cmbo_Producto.Size = New System.Drawing.Size(414, 21)
        Me.Cmbo_Producto.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(569, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "SOPORTANTE"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "PRODUCTO"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CAMBIARPORESTEPALLETToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(224, 26)
        '
        'CAMBIARPORESTEPALLETToolStripMenuItem
        '
        Me.CAMBIARPORESTEPALLETToolStripMenuItem.Name = "CAMBIARPORESTEPALLETToolStripMenuItem"
        Me.CAMBIARPORESTEPALLETToolStripMenuItem.Size = New System.Drawing.Size(223, 22)
        Me.CAMBIARPORESTEPALLETToolStripMenuItem.Text = "CAMBIAR POR ESTE PALLET"
        '
        'DataGridViewImageColumn1
        '
        Me.DataGridViewImageColumn1.HeaderText = "OK"
        Me.DataGridViewImageColumn1.Name = "DataGridViewImageColumn1"
        Me.DataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewImageColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewImageColumn1.Width = 40
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "racd_codi"
        Me.DataGridViewTextBoxColumn1.HeaderText = "FOLIO PRECISA"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "drec_sopocli"
        Me.DataGridViewTextBoxColumn2.HeaderText = "FOLIO CLIENTE"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "mae_descr"
        Me.DataGridViewTextBoxColumn3.HeaderText = "PRODUCTO"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 250
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "racd_unidades"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Cajas"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 80
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "racd_peso"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Kilos"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 80
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "racd_ca"
        Me.DataGridViewTextBoxColumn6.HeaderText = "CA"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Width = 60
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "racd_ba"
        Me.DataGridViewTextBoxColumn7.HeaderText = "BA"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Width = 60
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "racd_co"
        Me.DataGridViewTextBoxColumn8.HeaderText = "CO"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Width = 60
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "racd_pi"
        Me.DataGridViewTextBoxColumn9.HeaderText = "PI"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        Me.DataGridViewTextBoxColumn9.Width = 60
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "racd_ni"
        Me.DataGridViewTextBoxColumn10.HeaderText = "NI"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        Me.DataGridViewTextBoxColumn10.Width = 60
        '
        'Folio_precisa
        '
        Me.Folio_precisa.DataPropertyName = "racd_codi"
        Me.Folio_precisa.HeaderText = "FOLIO "
        Me.Folio_precisa.Name = "Folio_precisa"
        Me.Folio_precisa.ReadOnly = True
        '
        'FOLIO_CLIENTE
        '
        Me.FOLIO_CLIENTE.DataPropertyName = "drec_sopocli"
        Me.FOLIO_CLIENTE.HeaderText = "FOLIO CLIENTE"
        Me.FOLIO_CLIENTE.Name = "FOLIO_CLIENTE"
        Me.FOLIO_CLIENTE.ReadOnly = True
        '
        'PRODUCTO
        '
        Me.PRODUCTO.DataPropertyName = "mae_descr"
        Me.PRODUCTO.HeaderText = "PRODUCTO"
        Me.PRODUCTO.Name = "PRODUCTO"
        Me.PRODUCTO.ReadOnly = True
        Me.PRODUCTO.Width = 250
        '
        'Cajas
        '
        Me.Cajas.DataPropertyName = "racd_unidades"
        Me.Cajas.HeaderText = "Cajas"
        Me.Cajas.Name = "Cajas"
        Me.Cajas.ReadOnly = True
        Me.Cajas.Width = 80
        '
        'Kilos
        '
        Me.Kilos.DataPropertyName = "racd_peso"
        Me.Kilos.HeaderText = "Peso"
        Me.Kilos.Name = "Kilos"
        Me.Kilos.ReadOnly = True
        Me.Kilos.Width = 80
        '
        'CAMARA
        '
        Me.CAMARA.DataPropertyName = "racd_ca"
        Me.CAMARA.HeaderText = "CA"
        Me.CAMARA.Name = "CAMARA"
        Me.CAMARA.ReadOnly = True
        Me.CAMARA.Width = 35
        '
        'BANDA
        '
        Me.BANDA.DataPropertyName = "racd_ba"
        Me.BANDA.HeaderText = "BA"
        Me.BANDA.Name = "BANDA"
        Me.BANDA.ReadOnly = True
        Me.BANDA.Width = 35
        '
        'COLUMNA
        '
        Me.COLUMNA.DataPropertyName = "racd_co"
        Me.COLUMNA.HeaderText = "CO"
        Me.COLUMNA.Name = "COLUMNA"
        Me.COLUMNA.ReadOnly = True
        Me.COLUMNA.Width = 35
        '
        'PISO
        '
        Me.PISO.DataPropertyName = "racd_pi"
        Me.PISO.HeaderText = "PI"
        Me.PISO.Name = "PISO"
        Me.PISO.ReadOnly = True
        Me.PISO.Width = 35
        '
        'NIVEL
        '
        Me.NIVEL.DataPropertyName = "racd_ni"
        Me.NIVEL.HeaderText = "NI"
        Me.NIVEL.Name = "NIVEL"
        Me.NIVEL.ReadOnly = True
        Me.NIVEL.Width = 35
        '
        'Frm_ProductosCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(892, 525)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "Frm_ProductosCliente"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Listado de pallet por cliente"
        Me.Panel1.ResumeLayout(False)
        CType(Me.Data_Productos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Data_Productos As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Txt_Soportante As System.Windows.Forms.TextBox
    Friend WithEvents Cmbo_Producto As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CAMBIARPORESTEPALLETToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DataGridViewImageColumn1 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Folio_precisa As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FOLIO_CLIENTE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRODUCTO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cajas As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Kilos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CAMARA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BANDA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COLUMNA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PISO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NIVEL As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

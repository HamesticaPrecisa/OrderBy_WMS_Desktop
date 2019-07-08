<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Pedidos
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DgvPedidos = New System.Windows.Forms.DataGridView()
        Me.detalle = New System.Windows.Forms.DataGridViewImageColumn()
        Me.ELIM = New System.Windows.Forms.DataGridViewImageColumn()
        Me.PRINT = New System.Windows.Forms.DataGridViewImageColumn()
        Me.SALDOS = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DataGridViewImageColumn1 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.cbtipo = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.DataGridViewImageColumn2 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.DataGridViewImageColumn3 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.DataGridViewImageColumn4 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.DataGridViewImageColumn5 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.txtbus = New System.Windows.Forms.TextBox()
        Me.lblbus = New System.Windows.Forms.Label()
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
        Me.Codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Orden = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Hora = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Destino = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Sopo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cajas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EST = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnXls = New System.Windows.Forms.Button()
        CType(Me.DgvPedidos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DgvPedidos
        '
        Me.DgvPedidos.AllowUserToAddRows = False
        Me.DgvPedidos.AllowUserToDeleteRows = False
        Me.DgvPedidos.ColumnHeadersHeight = 30
        Me.DgvPedidos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Codigo, Me.Orden, Me.Cliente, Me.Fecha, Me.Hora, Me.Destino, Me.Sopo, Me.Cajas, Me.Tipo, Me.EST, Me.detalle, Me.ELIM, Me.PRINT, Me.SALDOS})
        Me.DgvPedidos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvPedidos.Location = New System.Drawing.Point(9, 43)
        Me.DgvPedidos.Name = "DgvPedidos"
        Me.DgvPedidos.ReadOnly = True
        Me.DgvPedidos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvPedidos.Size = New System.Drawing.Size(1281, 358)
        Me.DgvPedidos.TabIndex = 0
        '
        'detalle
        '
        Me.detalle.HeaderText = "DETALLE"
        Me.detalle.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.detalle
        Me.detalle.Name = "detalle"
        Me.detalle.ReadOnly = True
        Me.detalle.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.detalle.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.detalle.Width = 55
        '
        'ELIM
        '
        Me.ELIM.HeaderText = "ELIMINAR"
        Me.ELIM.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.Eliminar_16
        Me.ELIM.Name = "ELIM"
        Me.ELIM.ReadOnly = True
        Me.ELIM.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ELIM.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.ELIM.Width = 65
        '
        'PRINT
        '
        Me.PRINT.HeaderText = "PEDIDO"
        Me.PRINT.Image = Global.PrecisaFrozen.Win.My.Resources.Resources._1375930470_print
        Me.PRINT.Name = "PRINT"
        Me.PRINT.ReadOnly = True
        Me.PRINT.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.PRINT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.PRINT.Width = 55
        '
        'SALDOS
        '
        Me.SALDOS.HeaderText = "SALDOS"
        Me.SALDOS.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.Ficha
        Me.SALDOS.Name = "SALDOS"
        Me.SALDOS.ReadOnly = True
        Me.SALDOS.Width = 60
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(10, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(260, 28)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "LISTADO DE PEDIDOS PENDIENTES"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DataGridViewImageColumn1
        '
        Me.DataGridViewImageColumn1.HeaderText = "Detalle"
        Me.DataGridViewImageColumn1.Name = "DataGridViewImageColumn1"
        Me.DataGridViewImageColumn1.ReadOnly = True
        Me.DataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewImageColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewImageColumn1.Width = 60
        '
        'Timer1
        '
        Me.Timer1.Interval = 60000
        '
        'cbtipo
        '
        Me.cbtipo.FormattingEnabled = True
        Me.cbtipo.Location = New System.Drawing.Point(276, 7)
        Me.cbtipo.Name = "cbtipo"
        Me.cbtipo.Size = New System.Drawing.Size(189, 22)
        Me.cbtipo.TabIndex = 7
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(1007, 6)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(102, 34)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "UNIR PEDIDOS"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'DataGridViewImageColumn2
        '
        Me.DataGridViewImageColumn2.HeaderText = "DETALLE"
        Me.DataGridViewImageColumn2.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.detalle
        Me.DataGridViewImageColumn2.Name = "DataGridViewImageColumn2"
        Me.DataGridViewImageColumn2.ReadOnly = True
        Me.DataGridViewImageColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewImageColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewImageColumn2.Width = 55
        '
        'DataGridViewImageColumn3
        '
        Me.DataGridViewImageColumn3.HeaderText = "ELIMINAR"
        Me.DataGridViewImageColumn3.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.Eliminar_16
        Me.DataGridViewImageColumn3.Name = "DataGridViewImageColumn3"
        Me.DataGridViewImageColumn3.ReadOnly = True
        Me.DataGridViewImageColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewImageColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.DataGridViewImageColumn3.Width = 65
        '
        'DataGridViewImageColumn4
        '
        Me.DataGridViewImageColumn4.HeaderText = "PEDIDO"
        Me.DataGridViewImageColumn4.Image = Global.PrecisaFrozen.Win.My.Resources.Resources._1375930470_print
        Me.DataGridViewImageColumn4.Name = "DataGridViewImageColumn4"
        Me.DataGridViewImageColumn4.ReadOnly = True
        Me.DataGridViewImageColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewImageColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewImageColumn4.Width = 55
        '
        'DataGridViewImageColumn5
        '
        Me.DataGridViewImageColumn5.HeaderText = "SALDOS"
        Me.DataGridViewImageColumn5.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.Ficha
        Me.DataGridViewImageColumn5.Name = "DataGridViewImageColumn5"
        Me.DataGridViewImageColumn5.ReadOnly = True
        Me.DataGridViewImageColumn5.Width = 60
        '
        'txtbus
        '
        Me.txtbus.Location = New System.Drawing.Point(536, 8)
        Me.txtbus.Name = "txtbus"
        Me.txtbus.Size = New System.Drawing.Size(100, 22)
        Me.txtbus.TabIndex = 9
        Me.txtbus.Visible = False
        '
        'lblbus
        '
        Me.lblbus.AutoSize = True
        Me.lblbus.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblbus.Location = New System.Drawing.Point(487, 17)
        Me.lblbus.Name = "lblbus"
        Me.lblbus.Size = New System.Drawing.Size(43, 14)
        Me.lblbus.TabIndex = 10
        Me.lblbus.Text = "Buscar"
        Me.lblbus.Visible = False
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "pedido"
        Me.DataGridViewTextBoxColumn1.HeaderText = "CODIGO"
        Me.DataGridViewTextBoxColumn1.MinimumWidth = 2
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn1.Width = 2
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Orden"
        Me.DataGridViewTextBoxColumn2.HeaderText = "ORDEN"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 80
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "cliente"
        Me.DataGridViewTextBoxColumn3.HeaderText = "CLIENTE"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 300
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "fecha"
        Me.DataGridViewTextBoxColumn4.HeaderText = "FECHA CARGA"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "hora"
        Me.DataGridViewTextBoxColumn5.HeaderText = "HORA CARGA"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "destino"
        Me.DataGridViewTextBoxColumn6.HeaderText = "DESTINO"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "sopo"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridViewTextBoxColumn7.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewTextBoxColumn7.HeaderText = "SOPORTANTES"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "codvig"
        Me.DataGridViewTextBoxColumn8.HeaderText = "EST"
        Me.DataGridViewTextBoxColumn8.MinimumWidth = 20
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn8.Width = 20
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "codvig"
        Me.DataGridViewTextBoxColumn9.HeaderText = "EST"
        Me.DataGridViewTextBoxColumn9.MinimumWidth = 2
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        Me.DataGridViewTextBoxColumn9.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn9.Width = 2
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "codvig"
        Me.DataGridViewTextBoxColumn10.HeaderText = "EST"
        Me.DataGridViewTextBoxColumn10.MinimumWidth = 2
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn10.Width = 2
        '
        'Codigo
        '
        Me.Codigo.DataPropertyName = "pedido"
        Me.Codigo.HeaderText = "CODIGO"
        Me.Codigo.MinimumWidth = 2
        Me.Codigo.Name = "Codigo"
        Me.Codigo.ReadOnly = True
        Me.Codigo.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Codigo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Codigo.Width = 2
        '
        'Orden
        '
        Me.Orden.DataPropertyName = "Orden"
        Me.Orden.HeaderText = "ORDEN"
        Me.Orden.Name = "Orden"
        Me.Orden.ReadOnly = True
        Me.Orden.Width = 80
        '
        'Cliente
        '
        Me.Cliente.DataPropertyName = "cliente"
        Me.Cliente.HeaderText = "CLIENTE"
        Me.Cliente.Name = "Cliente"
        Me.Cliente.ReadOnly = True
        Me.Cliente.Width = 300
        '
        'Fecha
        '
        Me.Fecha.DataPropertyName = "fecha"
        Me.Fecha.HeaderText = "FECHA CARGA"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.ReadOnly = True
        '
        'Hora
        '
        Me.Hora.DataPropertyName = "hora"
        Me.Hora.HeaderText = "HORA CARGA"
        Me.Hora.Name = "Hora"
        Me.Hora.ReadOnly = True
        '
        'Destino
        '
        Me.Destino.DataPropertyName = "destino"
        Me.Destino.HeaderText = "DESTINO"
        Me.Destino.Name = "Destino"
        Me.Destino.ReadOnly = True
        '
        'Sopo
        '
        Me.Sopo.DataPropertyName = "sopo"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Sopo.DefaultCellStyle = DataGridViewCellStyle1
        Me.Sopo.HeaderText = "SOPORTANTES"
        Me.Sopo.Name = "Sopo"
        Me.Sopo.ReadOnly = True
        '
        'Cajas
        '
        Me.Cajas.DataPropertyName = "Cajas"
        Me.Cajas.HeaderText = "CAJAS"
        Me.Cajas.Name = "Cajas"
        Me.Cajas.ReadOnly = True
        '
        'Tipo
        '
        Me.Tipo.DataPropertyName = "Tipo"
        Me.Tipo.HeaderText = "TIPO"
        Me.Tipo.Name = "Tipo"
        Me.Tipo.ReadOnly = True
        '
        'EST
        '
        Me.EST.DataPropertyName = "codvig"
        Me.EST.HeaderText = "EST"
        Me.EST.MinimumWidth = 2
        Me.EST.Name = "EST"
        Me.EST.ReadOnly = True
        Me.EST.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.EST.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.EST.Width = 2
        '
        'btnXls
        '
        Me.btnXls.Location = New System.Drawing.Point(1115, 6)
        Me.btnXls.Name = "btnXls"
        Me.btnXls.Size = New System.Drawing.Size(102, 34)
        Me.btnXls.TabIndex = 11
        Me.btnXls.Text = "EXPORTAR EXCEL"
        Me.btnXls.UseVisualStyleBackColor = True
        '
        'Frm_Pedidos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(1299, 423)
        Me.Controls.Add(Me.btnXls)
        Me.Controls.Add(Me.lblbus)
        Me.Controls.Add(Me.txtbus)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.cbtipo)
        Me.Controls.Add(Me.DgvPedidos)
        Me.Controls.Add(Me.Label2)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "Frm_Pedidos"
        Me.Padding = New System.Windows.Forms.Padding(9, 43, 9, 22)
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Listado de pedidos"
        CType(Me.DgvPedidos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DgvPedidos As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewImageColumn1 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cbtipo As System.Windows.Forms.ComboBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents DataGridViewImageColumn2 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents DataGridViewImageColumn3 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents DataGridViewImageColumn4 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents DataGridViewImageColumn5 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents txtbus As System.Windows.Forms.TextBox
    Friend WithEvents lblbus As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Codigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Orden As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Hora As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Destino As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Sopo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cajas As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EST As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents detalle As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents ELIM As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents PRINT As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents SALDOS As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnXls As System.Windows.Forms.Button
End Class

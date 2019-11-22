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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DgvPedidos = New System.Windows.Forms.DataGridView()
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
        Me.btnXls = New System.Windows.Forms.Button()
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
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Orden = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Hora = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Destino = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Sopo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cajas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Kilos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EST = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tipo_Carga = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Exportacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nro_Sol_Sag = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Etiq_Adi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.detalle = New System.Windows.Forms.DataGridViewImageColumn()
        Me.ELIM = New System.Windows.Forms.DataGridViewImageColumn()
        Me.PRINT = New System.Windows.Forms.DataGridViewImageColumn()
        Me.SALDOS = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Fecha_Frm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DgvPedidos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DgvPedidos
        '
        Me.DgvPedidos.AllowUserToAddRows = False
        Me.DgvPedidos.AllowUserToDeleteRows = False
        Me.DgvPedidos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.DgvPedidos.ColumnHeadersHeight = 30
        Me.DgvPedidos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Codigo, Me.Orden, Me.Cliente, Me.Fecha, Me.Hora, Me.Destino, Me.Sopo, Me.Cajas, Me.Kilos, Me.EST, Me.Tipo_Carga, Me.Exportacion, Me.Nro_Sol_Sag, Me.Etiq_Adi, Me.detalle, Me.ELIM, Me.PRINT, Me.SALDOS, Me.Fecha_Frm, Me.Tipo})
        Me.DgvPedidos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvPedidos.Location = New System.Drawing.Point(9, 43)
        Me.DgvPedidos.Name = "DgvPedidos"
        Me.DgvPedidos.ReadOnly = True
        Me.DgvPedidos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvPedidos.Size = New System.Drawing.Size(1906, 605)
        Me.DgvPedidos.TabIndex = 0
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
        'btnXls
        '
        Me.btnXls.Location = New System.Drawing.Point(1115, 6)
        Me.btnXls.Name = "btnXls"
        Me.btnXls.Size = New System.Drawing.Size(102, 34)
        Me.btnXls.TabIndex = 11
        Me.btnXls.Text = "EXPORTAR EXCEL"
        Me.btnXls.UseVisualStyleBackColor = True
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "pedido"
        Me.DataGridViewTextBoxColumn1.Frozen = True
        Me.DataGridViewTextBoxColumn1.HeaderText = "CODIGO"
        Me.DataGridViewTextBoxColumn1.MinimumWidth = 2
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn1.Visible = False
        Me.DataGridViewTextBoxColumn1.Width = 2
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Orden"
        Me.DataGridViewTextBoxColumn2.Frozen = True
        Me.DataGridViewTextBoxColumn2.HeaderText = "ORDEN"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 71
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "cliente"
        Me.DataGridViewTextBoxColumn3.Frozen = True
        Me.DataGridViewTextBoxColumn3.HeaderText = "CLIENTE"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 300
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "fecha"
        Me.DataGridViewTextBoxColumn4.Frozen = True
        Me.DataGridViewTextBoxColumn4.HeaderText = "FECHA CARGA"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 103
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "hora"
        Me.DataGridViewTextBoxColumn5.Frozen = True
        Me.DataGridViewTextBoxColumn5.HeaderText = "HORA CARGA"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 103
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "destino"
        Me.DataGridViewTextBoxColumn6.Frozen = True
        Me.DataGridViewTextBoxColumn6.HeaderText = "DESTINO"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Width = 78
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "sopo"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridViewTextBoxColumn7.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewTextBoxColumn7.Frozen = True
        Me.DataGridViewTextBoxColumn7.HeaderText = "SOPORTANTES"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Width = 105
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "codvig"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridViewTextBoxColumn8.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewTextBoxColumn8.Frozen = True
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
        Me.DataGridViewTextBoxColumn9.Frozen = True
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
        Me.DataGridViewTextBoxColumn10.Frozen = True
        Me.DataGridViewTextBoxColumn10.HeaderText = "EST"
        Me.DataGridViewTextBoxColumn10.MinimumWidth = 2
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        Me.DataGridViewTextBoxColumn10.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn10.Visible = False
        Me.DataGridViewTextBoxColumn10.Width = 2
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "codvig"
        Me.DataGridViewTextBoxColumn11.Frozen = True
        Me.DataGridViewTextBoxColumn11.HeaderText = "EST"
        Me.DataGridViewTextBoxColumn11.MinimumWidth = 2
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        Me.DataGridViewTextBoxColumn11.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn11.Visible = False
        Me.DataGridViewTextBoxColumn11.Width = 2
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "Tipo_Exportacion"
        Me.DataGridViewTextBoxColumn12.Frozen = True
        Me.DataGridViewTextBoxColumn12.HeaderText = "EXPORTACIÓN"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.ReadOnly = True
        Me.DataGridViewTextBoxColumn12.Width = 94
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.DataPropertyName = "Nro_Sol_Sag"
        Me.DataGridViewTextBoxColumn13.Frozen = True
        Me.DataGridViewTextBoxColumn13.HeaderText = "Nº SOL. SAG"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.ReadOnly = True
        Me.DataGridViewTextBoxColumn13.Width = 103
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.DataPropertyName = "Etiquetado_Adicional"
        Me.DataGridViewTextBoxColumn14.Frozen = True
        Me.DataGridViewTextBoxColumn14.HeaderText = "ETIQ. ADICIONAL"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.ReadOnly = True
        Me.DataGridViewTextBoxColumn14.Width = 94
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.DataPropertyName = "Etiquetado_Adicional"
        Me.DataGridViewTextBoxColumn15.Frozen = True
        Me.DataGridViewTextBoxColumn15.HeaderText = "ETIQ. ADICIONAL"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        Me.DataGridViewTextBoxColumn15.ReadOnly = True
        Me.DataGridViewTextBoxColumn15.Visible = False
        Me.DataGridViewTextBoxColumn15.Width = 119
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.DataPropertyName = "Fecha_Frm"
        Me.DataGridViewTextBoxColumn16.Frozen = True
        Me.DataGridViewTextBoxColumn16.HeaderText = "Fecha_Frm"
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        Me.DataGridViewTextBoxColumn16.ReadOnly = True
        Me.DataGridViewTextBoxColumn16.Visible = False
        Me.DataGridViewTextBoxColumn16.Width = 90
        '
        'Codigo
        '
        Me.Codigo.DataPropertyName = "pedido"
        Me.Codigo.Frozen = True
        Me.Codigo.HeaderText = "CODIGO"
        Me.Codigo.MinimumWidth = 2
        Me.Codigo.Name = "Codigo"
        Me.Codigo.ReadOnly = True
        Me.Codigo.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Codigo.Visible = False
        Me.Codigo.Width = 74
        '
        'Orden
        '
        Me.Orden.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Orden.DataPropertyName = "Orden"
        Me.Orden.Frozen = True
        Me.Orden.HeaderText = "ORDEN"
        Me.Orden.Name = "Orden"
        Me.Orden.ReadOnly = True
        Me.Orden.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Orden.Width = 69
        '
        'Cliente
        '
        Me.Cliente.DataPropertyName = "cliente"
        Me.Cliente.Frozen = True
        Me.Cliente.HeaderText = "CLIENTE"
        Me.Cliente.Name = "Cliente"
        Me.Cliente.ReadOnly = True
        Me.Cliente.Width = 73
        '
        'Fecha
        '
        Me.Fecha.DataPropertyName = "fecha"
        Me.Fecha.Frozen = True
        Me.Fecha.HeaderText = "FECHA"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.ReadOnly = True
        Me.Fecha.Width = 65
        '
        'Hora
        '
        Me.Hora.DataPropertyName = "hora"
        Me.Hora.Frozen = True
        Me.Hora.HeaderText = "HORA"
        Me.Hora.Name = "Hora"
        Me.Hora.ReadOnly = True
        Me.Hora.Width = 62
        '
        'Destino
        '
        Me.Destino.DataPropertyName = "destino"
        Me.Destino.Frozen = True
        Me.Destino.HeaderText = "DESTINO"
        Me.Destino.Name = "Destino"
        Me.Destino.ReadOnly = True
        Me.Destino.Width = 78
        '
        'Sopo
        '
        Me.Sopo.DataPropertyName = "sopo"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Sopo.DefaultCellStyle = DataGridViewCellStyle1
        Me.Sopo.Frozen = True
        Me.Sopo.HeaderText = "SOPO."
        Me.Sopo.Name = "Sopo"
        Me.Sopo.ReadOnly = True
        Me.Sopo.Width = 63
        '
        'Cajas
        '
        Me.Cajas.DataPropertyName = "Cajas"
        Me.Cajas.Frozen = True
        Me.Cajas.HeaderText = "CAJAS"
        Me.Cajas.Name = "Cajas"
        Me.Cajas.ReadOnly = True
        Me.Cajas.Width = 62
        '
        'Kilos
        '
        Me.Kilos.DataPropertyName = "Kilos"
        Me.Kilos.Frozen = True
        Me.Kilos.HeaderText = "KILOS"
        Me.Kilos.Name = "Kilos"
        Me.Kilos.ReadOnly = True
        Me.Kilos.Width = 61
        '
        'EST
        '
        Me.EST.DataPropertyName = "codvig"
        Me.EST.Frozen = True
        Me.EST.HeaderText = "EST"
        Me.EST.MinimumWidth = 2
        Me.EST.Name = "EST"
        Me.EST.ReadOnly = True
        Me.EST.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.EST.Visible = False
        Me.EST.Width = 50
        '
        'Tipo_Carga
        '
        Me.Tipo_Carga.DataPropertyName = "Tipo_Carga"
        Me.Tipo_Carga.Frozen = True
        Me.Tipo_Carga.HeaderText = "CARGA"
        Me.Tipo_Carga.Name = "Tipo_Carga"
        Me.Tipo_Carga.ReadOnly = True
        Me.Tipo_Carga.Width = 67
        '
        'Exportacion
        '
        Me.Exportacion.DataPropertyName = "Tipo_Exportacion"
        Me.Exportacion.Frozen = True
        Me.Exportacion.HeaderText = "EXP."
        Me.Exportacion.Name = "Exportacion"
        Me.Exportacion.ReadOnly = True
        Me.Exportacion.Width = 51
        '
        'Nro_Sol_Sag
        '
        Me.Nro_Sol_Sag.DataPropertyName = "Nro_Sol_Sag"
        Me.Nro_Sol_Sag.Frozen = True
        Me.Nro_Sol_Sag.HeaderText = "SOL. SAG"
        Me.Nro_Sol_Sag.Name = "Nro_Sol_Sag"
        Me.Nro_Sol_Sag.ReadOnly = True
        Me.Nro_Sol_Sag.Width = 78
        '
        'Etiq_Adi
        '
        Me.Etiq_Adi.DataPropertyName = "Etiquetado_Adicional"
        Me.Etiq_Adi.Frozen = True
        Me.Etiq_Adi.HeaderText = "ETIQ. ADI."
        Me.Etiq_Adi.Name = "Etiq_Adi"
        Me.Etiq_Adi.ReadOnly = True
        Me.Etiq_Adi.Width = 84
        '
        'detalle
        '
        Me.detalle.Frozen = True
        Me.detalle.HeaderText = "DET."
        Me.detalle.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.detalle
        Me.detalle.Name = "detalle"
        Me.detalle.ReadOnly = True
        Me.detalle.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.detalle.Width = 35
        '
        'ELIM
        '
        Me.ELIM.Frozen = True
        Me.ELIM.HeaderText = "ELIM."
        Me.ELIM.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.Eliminar_16
        Me.ELIM.Name = "ELIM"
        Me.ELIM.ReadOnly = True
        Me.ELIM.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ELIM.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.ELIM.Width = 60
        '
        'PRINT
        '
        Me.PRINT.Frozen = True
        Me.PRINT.HeaderText = "PEDIDO"
        Me.PRINT.Image = Global.PrecisaFrozen.Win.My.Resources.Resources._1375930470_print
        Me.PRINT.Name = "PRINT"
        Me.PRINT.ReadOnly = True
        Me.PRINT.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.PRINT.Width = 53
        '
        'SALDOS
        '
        Me.SALDOS.Frozen = True
        Me.SALDOS.HeaderText = "SALDOS"
        Me.SALDOS.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.Ficha
        Me.SALDOS.Name = "SALDOS"
        Me.SALDOS.ReadOnly = True
        Me.SALDOS.Width = 53
        '
        'Fecha_Frm
        '
        Me.Fecha_Frm.DataPropertyName = "Fecha_Frm"
        Me.Fecha_Frm.Frozen = True
        Me.Fecha_Frm.HeaderText = "Fecha_Frm"
        Me.Fecha_Frm.Name = "Fecha_Frm"
        Me.Fecha_Frm.ReadOnly = True
        Me.Fecha_Frm.Visible = False
        Me.Fecha_Frm.Width = 90
        '
        'Tipo
        '
        Me.Tipo.DataPropertyName = "Tipo"
        Me.Tipo.Frozen = True
        Me.Tipo.HeaderText = "TIPO"
        Me.Tipo.Name = "Tipo"
        Me.Tipo.ReadOnly = True
        Me.Tipo.Width = 56
        '
        'Frm_Pedidos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(1924, 670)
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
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnXls As System.Windows.Forms.Button
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Codigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Orden As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Hora As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Destino As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Sopo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cajas As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Kilos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EST As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tipo_Carga As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Exportacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nro_Sol_Sag As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Etiq_Adi As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents detalle As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents ELIM As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents PRINT As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents SALDOS As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents Fecha_Frm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tipo As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

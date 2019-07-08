<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_ModificaSAG
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.BtnBuscar = New System.Windows.Forms.Button()
        Me.btn_guardar = New System.Windows.Forms.Button()
        Me.DetaRece = New System.Windows.Forms.DataGridView()
        Me.txtcodsag = New System.Windows.Forms.TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtCodRece = New System.Windows.Forms.TextBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
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
        Me.Cod_Pallet = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cod_Producto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nombre_Producto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodSopo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NomSopo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cant_Pallets = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Peso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Elaboracion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Vencimiento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Lote = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodSag = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SopCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Temperatura = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.arriendo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmbest = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DetaRece, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnBuscar
        '
        Me.BtnBuscar.BackColor = System.Drawing.Color.Transparent
        Me.BtnBuscar.FlatAppearance.BorderSize = 0
        Me.BtnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnBuscar.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_lupa1
        Me.BtnBuscar.Location = New System.Drawing.Point(12, 12)
        Me.BtnBuscar.Name = "BtnBuscar"
        Me.BtnBuscar.Size = New System.Drawing.Size(63, 63)
        Me.BtnBuscar.TabIndex = 75
        Me.BtnBuscar.UseVisualStyleBackColor = False
        '
        'btn_guardar
        '
        Me.btn_guardar.BackColor = System.Drawing.Color.Transparent
        Me.btn_guardar.Enabled = False
        Me.btn_guardar.FlatAppearance.BorderSize = 0
        Me.btn_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_guardar.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_guardar2
        Me.btn_guardar.Location = New System.Drawing.Point(780, 333)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(63, 63)
        Me.btn_guardar.TabIndex = 74
        Me.btn_guardar.UseVisualStyleBackColor = False
        '
        'DetaRece
        '
        Me.DetaRece.AllowUserToAddRows = False
        Me.DetaRece.AllowUserToDeleteRows = False
        Me.DetaRece.BackgroundColor = System.Drawing.Color.DarkSlateGray
        Me.DetaRece.ColumnHeadersHeight = 28
        Me.DetaRece.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Cod_Pallet, Me.Cod_Producto, Me.Nombre_Producto, Me.CodSopo, Me.NomSopo, Me.Cant_Pallets, Me.Peso, Me.Elaboracion, Me.Vencimiento, Me.Lote, Me.CodSag, Me.SopCliente, Me.Temperatura, Me.arriendo, Me.cmbest})
        Me.DetaRece.Location = New System.Drawing.Point(12, 81)
        Me.DetaRece.MultiSelect = False
        Me.DetaRece.Name = "DetaRece"
        Me.DetaRece.ReadOnly = True
        Me.DetaRece.RowHeadersWidth = 10
        Me.DetaRece.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DetaRece.Size = New System.Drawing.Size(831, 239)
        Me.DetaRece.TabIndex = 76
        '
        'txtcodsag
        '
        Me.txtcodsag.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcodsag.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcodsag.Location = New System.Drawing.Point(359, 360)
        Me.txtcodsag.MaxLength = 20
        Me.txtcodsag.Name = "txtcodsag"
        Me.txtcodsag.Size = New System.Drawing.Size(129, 29)
        Me.txtcodsag.TabIndex = 77
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.BackColor = System.Drawing.Color.Transparent
        Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label33.Location = New System.Drawing.Point(373, 333)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(100, 24)
        Me.Label33.TabIndex = 78
        Me.Label33.Text = "COD. SAG"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(7, 333)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 25)
        Me.Label1.TabIndex = 79
        Me.Label1.Text = "PALLET"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(7, 358)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 25)
        Me.Label2.TabIndex = 80
        '
        'TxtCodRece
        '
        Me.TxtCodRece.Location = New System.Drawing.Point(469, 12)
        Me.TxtCodRece.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TxtCodRece.MaxLength = 7
        Me.TxtCodRece.Name = "TxtCodRece"
        Me.TxtCodRece.Size = New System.Drawing.Size(111, 20)
        Me.TxtCodRece.TabIndex = 81
        Me.TxtCodRece.Visible = False
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.BackColor = System.Drawing.Color.Transparent
        Me.CheckBox1.ForeColor = System.Drawing.Color.White
        Me.CheckBox1.Location = New System.Drawing.Point(694, 58)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(149, 17)
        Me.CheckBox1.TabIndex = 82
        Me.CheckBox1.Text = "RECEPCION COMPLETA"
        Me.CheckBox1.UseVisualStyleBackColor = False
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "Pallet"
        Me.DataGridViewTextBoxColumn1.HeaderText = "N PRECISA"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn1.Width = 75
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "drec_codpro"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Cod. Producto"
        Me.DataGridViewTextBoxColumn2.MinimumWidth = 2
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn2.Width = 2
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "mae_descr"
        Me.DataGridViewTextBoxColumn3.HeaderText = "PRODUCTO"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn3.Width = 200
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "drec_codsopo"
        Me.DataGridViewTextBoxColumn4.HeaderText = "CodSopo"
        Me.DataGridViewTextBoxColumn4.MinimumWidth = 2
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn4.Width = 2
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "tsop_descr"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Soportante"
        Me.DataGridViewTextBoxColumn5.MinimumWidth = 2
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn5.Width = 2
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "drec_unidades"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewTextBoxColumn6.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridViewTextBoxColumn6.HeaderText = "ENV."
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn6.Width = 40
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "drec_peso"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.DataGridViewTextBoxColumn7.DefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridViewTextBoxColumn7.HeaderText = "KILOS"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn7.Width = 55
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "drec_fecprod"
        DataGridViewCellStyle7.Format = "d"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.DataGridViewTextBoxColumn8.DefaultCellStyle = DataGridViewCellStyle7
        Me.DataGridViewTextBoxColumn8.HeaderText = "ELABORACION"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn8.Width = 89
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "Fechavencimiento"
        DataGridViewCellStyle8.Format = "d"
        DataGridViewCellStyle8.NullValue = Nothing
        Me.DataGridViewTextBoxColumn9.DefaultCellStyle = DataGridViewCellStyle8
        Me.DataGridViewTextBoxColumn9.HeaderText = "VENCIMIENTO"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        Me.DataGridViewTextBoxColumn9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn9.Width = 87
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "lotecliente"
        Me.DataGridViewTextBoxColumn10.HeaderText = "LOTE"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        Me.DataGridViewTextBoxColumn10.Width = 60
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "drec_codsag"
        Me.DataGridViewTextBoxColumn11.HeaderText = "SAG"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        Me.DataGridViewTextBoxColumn11.Width = 60
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "drec_sopocli"
        Me.DataGridViewTextBoxColumn12.HeaderText = "N CLIENTE"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.ReadOnly = True
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.DataPropertyName = "drec_temp"
        Me.DataGridViewTextBoxColumn13.HeaderText = "TEMP"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.ReadOnly = True
        Me.DataGridViewTextBoxColumn13.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn13.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.DataGridViewTextBoxColumn13.Width = 40
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.DataPropertyName = "drec_arriendo"
        Me.DataGridViewTextBoxColumn14.HeaderText = "arriendo"
        Me.DataGridViewTextBoxColumn14.MinimumWidth = 2
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.ReadOnly = True
        Me.DataGridViewTextBoxColumn14.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn14.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn14.Width = 2
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.HeaderText = "cmbest"
        Me.DataGridViewTextBoxColumn15.MinimumWidth = 2
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        Me.DataGridViewTextBoxColumn15.ReadOnly = True
        Me.DataGridViewTextBoxColumn15.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn15.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn15.Width = 2
        '
        'Cod_Pallet
        '
        Me.Cod_Pallet.DataPropertyName = "Pallet"
        Me.Cod_Pallet.HeaderText = "FOLIO"
        Me.Cod_Pallet.Name = "Cod_Pallet"
        Me.Cod_Pallet.ReadOnly = True
        Me.Cod_Pallet.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Cod_Pallet.Width = 75
        '
        'Cod_Producto
        '
        Me.Cod_Producto.DataPropertyName = "drec_codpro"
        Me.Cod_Producto.HeaderText = "Cod. Producto"
        Me.Cod_Producto.MinimumWidth = 2
        Me.Cod_Producto.Name = "Cod_Producto"
        Me.Cod_Producto.ReadOnly = True
        Me.Cod_Producto.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Cod_Producto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Cod_Producto.Width = 2
        '
        'Nombre_Producto
        '
        Me.Nombre_Producto.DataPropertyName = "mae_descr"
        Me.Nombre_Producto.HeaderText = "PRODUCTO"
        Me.Nombre_Producto.Name = "Nombre_Producto"
        Me.Nombre_Producto.ReadOnly = True
        Me.Nombre_Producto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Nombre_Producto.Width = 200
        '
        'CodSopo
        '
        Me.CodSopo.DataPropertyName = "drec_codsopo"
        Me.CodSopo.HeaderText = "CodSopo"
        Me.CodSopo.MinimumWidth = 2
        Me.CodSopo.Name = "CodSopo"
        Me.CodSopo.ReadOnly = True
        Me.CodSopo.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.CodSopo.Width = 2
        '
        'NomSopo
        '
        Me.NomSopo.DataPropertyName = "tsop_descr"
        Me.NomSopo.HeaderText = "Soportante"
        Me.NomSopo.MinimumWidth = 2
        Me.NomSopo.Name = "NomSopo"
        Me.NomSopo.ReadOnly = True
        Me.NomSopo.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.NomSopo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.NomSopo.Width = 2
        '
        'Cant_Pallets
        '
        Me.Cant_Pallets.DataPropertyName = "drec_unidades"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Cant_Pallets.DefaultCellStyle = DataGridViewCellStyle1
        Me.Cant_Pallets.HeaderText = "ENV."
        Me.Cant_Pallets.Name = "Cant_Pallets"
        Me.Cant_Pallets.ReadOnly = True
        Me.Cant_Pallets.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Cant_Pallets.Width = 40
        '
        'Peso
        '
        Me.Peso.DataPropertyName = "drec_peso"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.Peso.DefaultCellStyle = DataGridViewCellStyle2
        Me.Peso.HeaderText = "PESO"
        Me.Peso.Name = "Peso"
        Me.Peso.ReadOnly = True
        Me.Peso.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Peso.Width = 55
        '
        'Elaboracion
        '
        Me.Elaboracion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.Elaboracion.DataPropertyName = "drec_fecprod"
        DataGridViewCellStyle3.Format = "d"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.Elaboracion.DefaultCellStyle = DataGridViewCellStyle3
        Me.Elaboracion.HeaderText = "ELABORACION"
        Me.Elaboracion.Name = "Elaboracion"
        Me.Elaboracion.ReadOnly = True
        Me.Elaboracion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Elaboracion.Width = 89
        '
        'Vencimiento
        '
        Me.Vencimiento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.Vencimiento.DataPropertyName = "Fechavencimiento"
        DataGridViewCellStyle4.Format = "d"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.Vencimiento.DefaultCellStyle = DataGridViewCellStyle4
        Me.Vencimiento.HeaderText = "VENCIMIENTO"
        Me.Vencimiento.Name = "Vencimiento"
        Me.Vencimiento.ReadOnly = True
        Me.Vencimiento.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Vencimiento.Width = 87
        '
        'Lote
        '
        Me.Lote.DataPropertyName = "lotecliente"
        Me.Lote.HeaderText = "LOTE"
        Me.Lote.Name = "Lote"
        Me.Lote.ReadOnly = True
        Me.Lote.Width = 60
        '
        'CodSag
        '
        Me.CodSag.DataPropertyName = "drec_codsag"
        Me.CodSag.HeaderText = "SAG"
        Me.CodSag.Name = "CodSag"
        Me.CodSag.ReadOnly = True
        Me.CodSag.Width = 60
        '
        'SopCliente
        '
        Me.SopCliente.DataPropertyName = "drec_sopocli"
        Me.SopCliente.HeaderText = "N CLIENTE"
        Me.SopCliente.Name = "SopCliente"
        Me.SopCliente.ReadOnly = True
        '
        'Temperatura
        '
        Me.Temperatura.DataPropertyName = "drec_temp"
        Me.Temperatura.HeaderText = "TEMP"
        Me.Temperatura.Name = "Temperatura"
        Me.Temperatura.ReadOnly = True
        Me.Temperatura.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Temperatura.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.Temperatura.Width = 40
        '
        'arriendo
        '
        Me.arriendo.DataPropertyName = "drec_arriendo"
        Me.arriendo.HeaderText = "arriendo"
        Me.arriendo.MinimumWidth = 2
        Me.arriendo.Name = "arriendo"
        Me.arriendo.ReadOnly = True
        Me.arriendo.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.arriendo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.arriendo.Width = 2
        '
        'cmbest
        '
        Me.cmbest.HeaderText = "cmbest"
        Me.cmbest.MinimumWidth = 2
        Me.cmbest.Name = "cmbest"
        Me.cmbest.ReadOnly = True
        Me.cmbest.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.cmbest.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.cmbest.Width = 2
        '
        'Frm_ModificaSAG
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(855, 436)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.TxtCodRece)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtcodsag)
        Me.Controls.Add(Me.Label33)
        Me.Controls.Add(Me.DetaRece)
        Me.Controls.Add(Me.BtnBuscar)
        Me.Controls.Add(Me.btn_guardar)
        Me.Name = "Frm_ModificaSAG"
        Me.Text = "Modificar RCP"
        CType(Me.DetaRece, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BtnBuscar As System.Windows.Forms.Button
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents DetaRece As System.Windows.Forms.DataGridView
    Friend WithEvents txtcodsag As System.Windows.Forms.TextBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtCodRece As System.Windows.Forms.TextBox
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
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Cod_Pallet As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cod_Producto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nombre_Producto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CodSopo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NomSopo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cant_Pallets As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Peso As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Elaboracion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Vencimiento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Lote As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CodSag As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SopCliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Temperatura As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents arriendo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmbest As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

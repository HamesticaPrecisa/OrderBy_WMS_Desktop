<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_PedidosDetalleCajas
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_PedidosDetalleCajas))
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DgvCaja = New System.Windows.Forms.DataGridView()
        Me.ICON = New System.Windows.Forms.DataGridViewImageColumn()
        Me.ncaja = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.op = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtsopo = New System.Windows.Forms.TextBox()
        Me.BtnCambiar = New System.Windows.Forms.Button()
        Me.tpedido = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tcaja = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtCodCaja = New System.Windows.Forms.TextBox()
        Me.txtpallet_1 = New System.Windows.Forms.TextBox()
        Me.txtpallet_2 = New System.Windows.Forms.TextBox()
        Me.DgvInfoCaja = New System.Windows.Forms.DataGridView()
        Me.CODIGO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PALLET = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CLIENTE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PI = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NI = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ESTADO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BtnEliminar = New System.Windows.Forms.Button()
        Me.BtnAgregar = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.DgvCajasadd = New System.Windows.Forms.DataGridView()
        Me.CB = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.CAJA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BtnCancelar = New System.Windows.Forms.Button()
        Me.BtnAceptar = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
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
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.DgvCaja, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgvInfoCaja, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.DgvCajasadd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DgvCaja
        '
        Me.DgvCaja.AllowUserToAddRows = False
        Me.DgvCaja.AllowUserToDeleteRows = False
        Me.DgvCaja.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark
        Me.DgvCaja.ColumnHeadersHeight = 28
        Me.DgvCaja.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ICON, Me.ncaja, Me.op})
        Me.DgvCaja.Location = New System.Drawing.Point(12, 49)
        Me.DgvCaja.Name = "DgvCaja"
        Me.DgvCaja.ReadOnly = True
        Me.DgvCaja.RowHeadersWidth = 25
        Me.DgvCaja.Size = New System.Drawing.Size(425, 428)
        Me.DgvCaja.TabIndex = 0
        '
        'ICON
        '
        Me.ICON.HeaderText = ""
        Me.ICON.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.point_red
        Me.ICON.Name = "ICON"
        Me.ICON.ReadOnly = True
        Me.ICON.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ICON.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.ICON.Width = 20
        '
        'ncaja
        '
        Me.ncaja.DataPropertyName = "dpc_codcaja"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ncaja.DefaultCellStyle = DataGridViewCellStyle1
        Me.ncaja.HeaderText = "            NUMERO DE CAJA"
        Me.ncaja.Name = "ncaja"
        Me.ncaja.ReadOnly = True
        Me.ncaja.Width = 350
        '
        'op
        '
        Me.op.DataPropertyName = "op"
        Me.op.HeaderText = "op"
        Me.op.MinimumWidth = 2
        Me.op.Name = "op"
        Me.op.ReadOnly = True
        Me.op.Width = 2
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.LightGray
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(425, 20)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "DETALLE DE CAJAS"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(280, 480)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 23)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "CAJAS"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtsopo
        '
        Me.txtsopo.Location = New System.Drawing.Point(382, 480)
        Me.txtsopo.Name = "txtsopo"
        Me.txtsopo.ReadOnly = True
        Me.txtsopo.Size = New System.Drawing.Size(55, 23)
        Me.txtsopo.TabIndex = 14
        '
        'BtnCambiar
        '
        Me.BtnCambiar.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCambiar.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.actualizar
        Me.BtnCambiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCambiar.Location = New System.Drawing.Point(1034, 41)
        Me.BtnCambiar.Name = "BtnCambiar"
        Me.BtnCambiar.Size = New System.Drawing.Size(127, 32)
        Me.BtnCambiar.TabIndex = 49
        Me.BtnCambiar.Text = "       CAMBIAR CAJA"
        Me.BtnCambiar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCambiar.UseVisualStyleBackColor = True
        '
        'tpedido
        '
        Me.tpedido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tpedido.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tpedido.Location = New System.Drawing.Point(613, 26)
        Me.tpedido.MaxLength = 20
        Me.tpedido.Name = "tpedido"
        Me.tpedido.ReadOnly = True
        Me.tpedido.Size = New System.Drawing.Size(91, 23)
        Me.tpedido.TabIndex = 47
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(446, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(160, 21)
        Me.Label2.TabIndex = 46
        Me.Label2.Text = "     N° PEDIDO"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tcaja
        '
        Me.tcaja.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tcaja.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tcaja.Location = New System.Drawing.Point(710, 54)
        Me.tcaja.MaxLength = 20
        Me.tcaja.Name = "tcaja"
        Me.tcaja.ReadOnly = True
        Me.tcaja.Size = New System.Drawing.Size(302, 23)
        Me.tcaja.TabIndex = 45
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(446, 54)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(160, 21)
        Me.Label3.TabIndex = 44
        Me.Label3.Text = "     N° A CAMBIAR"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(446, 82)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(160, 21)
        Me.Label6.TabIndex = 40
        Me.Label6.Text = "     N° A REMPLAZAR"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtCodCaja
        '
        Me.TxtCodCaja.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCodCaja.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCodCaja.Location = New System.Drawing.Point(710, 82)
        Me.TxtCodCaja.MaxLength = 20
        Me.TxtCodCaja.Name = "TxtCodCaja"
        Me.TxtCodCaja.Size = New System.Drawing.Size(302, 23)
        Me.TxtCodCaja.TabIndex = 41
        '
        'txtpallet_1
        '
        Me.txtpallet_1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtpallet_1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpallet_1.Location = New System.Drawing.Point(613, 54)
        Me.txtpallet_1.MaxLength = 20
        Me.txtpallet_1.Name = "txtpallet_1"
        Me.txtpallet_1.ReadOnly = True
        Me.txtpallet_1.Size = New System.Drawing.Size(91, 23)
        Me.txtpallet_1.TabIndex = 51
        '
        'txtpallet_2
        '
        Me.txtpallet_2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtpallet_2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpallet_2.Location = New System.Drawing.Point(613, 82)
        Me.txtpallet_2.MaxLength = 20
        Me.txtpallet_2.Name = "txtpallet_2"
        Me.txtpallet_2.ReadOnly = True
        Me.txtpallet_2.Size = New System.Drawing.Size(91, 23)
        Me.txtpallet_2.TabIndex = 50
        '
        'DgvInfoCaja
        '
        Me.DgvInfoCaja.AllowUserToAddRows = False
        Me.DgvInfoCaja.AllowUserToDeleteRows = False
        Me.DgvInfoCaja.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark
        Me.DgvInfoCaja.ColumnHeadersHeight = 28
        Me.DgvInfoCaja.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CODIGO, Me.PALLET, Me.CLIENTE, Me.CA, Me.BA, Me.CO, Me.PI, Me.NI, Me.ESTADO})
        Me.DgvInfoCaja.Location = New System.Drawing.Point(446, 118)
        Me.DgvInfoCaja.Name = "DgvInfoCaja"
        Me.DgvInfoCaja.ReadOnly = True
        Me.DgvInfoCaja.RowHeadersWidth = 20
        Me.DgvInfoCaja.Size = New System.Drawing.Size(715, 359)
        Me.DgvInfoCaja.TabIndex = 52
        '
        'CODIGO
        '
        Me.CODIGO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.CODIGO.DataPropertyName = "Caj_cod"
        Me.CODIGO.HeaderText = "CAJA"
        Me.CODIGO.Name = "CODIGO"
        Me.CODIGO.ReadOnly = True
        Me.CODIGO.Width = 60
        '
        'PALLET
        '
        Me.PALLET.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.PALLET.DataPropertyName = "caj_pcod"
        Me.PALLET.HeaderText = "PALLET"
        Me.PALLET.Name = "PALLET"
        Me.PALLET.ReadOnly = True
        Me.PALLET.Width = 72
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
        Me.ESTADO.Width = 110
        '
        'BtnEliminar
        '
        Me.BtnEliminar.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEliminar.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.cont_no
        Me.BtnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnEliminar.Location = New System.Drawing.Point(1034, 74)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(127, 32)
        Me.BtnEliminar.TabIndex = 53
        Me.BtnEliminar.Text = "       ELIMINAR CAJA"
        Me.BtnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnEliminar.UseVisualStyleBackColor = True
        '
        'BtnAgregar
        '
        Me.BtnAgregar.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAgregar.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.ok_16
        Me.BtnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnAgregar.Location = New System.Drawing.Point(1034, 8)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(127, 32)
        Me.BtnAgregar.TabIndex = 54
        Me.BtnAgregar.Text = "       AGREGAR CAJA"
        Me.BtnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnAgregar.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.DgvCajasadd)
        Me.Panel1.Controls.Add(Me.BtnCancelar)
        Me.Panel1.Controls.Add(Me.BtnAceptar)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Location = New System.Drawing.Point(593, 155)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(331, 315)
        Me.Panel1.TabIndex = 55
        Me.Panel1.Visible = False
        '
        'DgvCajasadd
        '
        Me.DgvCajasadd.AllowUserToAddRows = False
        Me.DgvCajasadd.AllowUserToDeleteRows = False
        Me.DgvCajasadd.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark
        Me.DgvCajasadd.ColumnHeadersHeight = 28
        Me.DgvCajasadd.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CB, Me.CAJA})
        Me.DgvCajasadd.Location = New System.Drawing.Point(3, 24)
        Me.DgvCajasadd.Name = "DgvCajasadd"
        Me.DgvCajasadd.ReadOnly = True
        Me.DgvCajasadd.RowHeadersWidth = 15
        Me.DgvCajasadd.Size = New System.Drawing.Size(321, 253)
        Me.DgvCajasadd.TabIndex = 3
        '
        'CB
        '
        Me.CB.DataPropertyName = "op"
        Me.CB.HeaderText = ""
        Me.CB.Name = "CB"
        Me.CB.ReadOnly = True
        Me.CB.Width = 30
        '
        'CAJA
        '
        Me.CAJA.DataPropertyName = "caj_cod"
        Me.CAJA.HeaderText = "NUMERO DE CAJA"
        Me.CAJA.Name = "CAJA"
        Me.CAJA.ReadOnly = True
        Me.CAJA.Width = 250
        '
        'BtnCancelar
        '
        Me.BtnCancelar.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.BtnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCancelar.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCancelar.Location = New System.Drawing.Point(194, 283)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(95, 24)
        Me.BtnCancelar.TabIndex = 2
        Me.BtnCancelar.Text = "CANCELAR"
        Me.BtnCancelar.UseVisualStyleBackColor = False
        '
        'BtnAceptar
        '
        Me.BtnAceptar.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.BtnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnAceptar.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAceptar.Location = New System.Drawing.Point(55, 283)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Size = New System.Drawing.Size(95, 24)
        Me.BtnAceptar.TabIndex = 1
        Me.BtnAceptar.Text = "ACEPTAR"
        Me.BtnAceptar.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.LightGray
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(0, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(327, 21)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "CAJAS DISPONIBLES"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "point_green.png")
        Me.ImageList1.Images.SetKeyName(1, "point_red.png")
        Me.ImageList1.Images.SetKeyName(2, "point_yellow.png")
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "dpc_codcaja"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewTextBoxColumn1.HeaderText = "N° CAJA"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 400
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Caj_cod"
        Me.DataGridViewTextBoxColumn2.HeaderText = "CAJA"
        Me.DataGridViewTextBoxColumn2.MinimumWidth = 2
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "drec_camara"
        Me.DataGridViewTextBoxColumn3.HeaderText = "CA"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "drec_banda"
        Me.DataGridViewTextBoxColumn4.HeaderText = "BA"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "drec_colum"
        Me.DataGridViewTextBoxColumn5.HeaderText = "CO"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 35
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "drec_piso"
        Me.DataGridViewTextBoxColumn6.HeaderText = "PI"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Width = 35
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "drec_nivel"
        Me.DataGridViewTextBoxColumn7.HeaderText = "NI"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Width = 35
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "estado"
        Me.DataGridViewTextBoxColumn8.HeaderText = "ESTADO"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Width = 130
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "drec_nivel"
        Me.DataGridViewTextBoxColumn9.HeaderText = "NI"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        Me.DataGridViewTextBoxColumn9.Width = 35
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "estado"
        Me.DataGridViewTextBoxColumn10.HeaderText = "ESTADO"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        Me.DataGridViewTextBoxColumn10.Width = 130
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "caj_cod"
        Me.DataGridViewTextBoxColumn11.HeaderText = "NUMERO DE CAJA"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        Me.DataGridViewTextBoxColumn11.Width = 270
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "caj_cod"
        Me.DataGridViewTextBoxColumn12.HeaderText = "NUMERO DE CAJA"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.ReadOnly = True
        Me.DataGridViewTextBoxColumn12.Width = 250
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(149, 6)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(75, 15)
        Me.Label13.TabIndex = 61
        Me.Label13.Text = "Sin selección"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(39, 6)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(77, 15)
        Me.Label11.TabIndex = 59
        Me.Label11.Text = "Seleccionado"
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.point_red
        Me.PictureBox3.Location = New System.Drawing.Point(125, 4)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(20, 20)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 58
        Me.PictureBox3.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.point_green
        Me.PictureBox1.Location = New System.Drawing.Point(14, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(20, 20)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 56
        Me.PictureBox1.TabStop = False
        '
        'Frm_PedidosDetalleCajas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(1170, 507)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.BtnAgregar)
        Me.Controls.Add(Me.BtnEliminar)
        Me.Controls.Add(Me.DgvInfoCaja)
        Me.Controls.Add(Me.txtpallet_1)
        Me.Controls.Add(Me.txtpallet_2)
        Me.Controls.Add(Me.BtnCambiar)
        Me.Controls.Add(Me.tpedido)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tcaja)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TxtCodCaja)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtsopo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DgvCaja)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_PedidosDetalleCajas"
        Me.Padding = New System.Windows.Forms.Padding(12, 34, 700, 41)
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        CType(Me.DgvCaja, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgvInfoCaja, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.DgvCajasadd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DgvCaja As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtsopo As System.Windows.Forms.TextBox
    Friend WithEvents BtnCambiar As System.Windows.Forms.Button
    Friend WithEvents tpedido As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tcaja As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtCodCaja As System.Windows.Forms.TextBox
    Friend WithEvents txtpallet_1 As System.Windows.Forms.TextBox
    Friend WithEvents txtpallet_2 As System.Windows.Forms.TextBox
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DgvInfoCaja As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODIGO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PALLET As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CLIENTE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PI As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NI As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ESTADO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BtnEliminar As System.Windows.Forms.Button
    Friend WithEvents BtnAgregar As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DgvCajasadd As System.Windows.Forms.DataGridView
    Friend WithEvents BtnCancelar As System.Windows.Forms.Button
    Friend WithEvents BtnAceptar As System.Windows.Forms.Button
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CB As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents CAJA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ICON As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents ncaja As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents op As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class

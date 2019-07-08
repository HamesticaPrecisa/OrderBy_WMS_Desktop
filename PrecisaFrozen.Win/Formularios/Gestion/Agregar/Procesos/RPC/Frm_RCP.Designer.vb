<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Rcp
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
        Me.TxtGuiaPrecisa = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtGuiaCliente = New System.Windows.Forms.TextBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.NPRECISA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NCLIENTE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PROD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CAJAS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KILOS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtClirut = New System.Windows.Forms.TextBox()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.txtcodcontrato = New System.Windows.Forms.TextBox()
        Me.txtclinom = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtcontnom = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txtkilos = New System.Windows.Forms.TextBox()
        Me.txtcajas = New System.Windows.Forms.TextBox()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.txtsoportantes = New System.Windows.Forms.TextBox()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.DgvClientes = New System.Windows.Forms.DataGridView()
        Me.RECEPCION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CLIENTE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GUIA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TxtRcp = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.BtnBuscar = New System.Windows.Forms.Button()
        Me.BtnImprimir = New System.Windows.Forms.Button()
        Me.BtnGuardar = New System.Windows.Forms.Button()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.BtnNuevo = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.DgvClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TxtGuiaPrecisa
        '
        Me.TxtGuiaPrecisa.Location = New System.Drawing.Point(112, 27)
        Me.TxtGuiaPrecisa.Name = "TxtGuiaPrecisa"
        Me.TxtGuiaPrecisa.Size = New System.Drawing.Size(135, 21)
        Me.TxtGuiaPrecisa.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "GUÍA PRECISA"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(313, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "GUÍA CLIENTE"
        '
        'TxtGuiaCliente
        '
        Me.TxtGuiaCliente.Location = New System.Drawing.Point(426, 27)
        Me.TxtGuiaCliente.Name = "TxtGuiaCliente"
        Me.TxtGuiaCliente.Size = New System.Drawing.Size(139, 21)
        Me.TxtGuiaCliente.TabIndex = 2
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeight = 28
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NPRECISA, Me.NCLIENTE, Me.PROD, Me.CAJAS, Me.KILOS})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Left
        Me.DataGridView1.Location = New System.Drawing.Point(10, 225)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(687, 400)
        Me.DataGridView1.TabIndex = 5
        '
        'NPRECISA
        '
        Me.NPRECISA.DataPropertyName = "drec_codi"
        Me.NPRECISA.HeaderText = "N° PRECISA"
        Me.NPRECISA.Name = "NPRECISA"
        Me.NPRECISA.ReadOnly = True
        '
        'NCLIENTE
        '
        Me.NCLIENTE.DataPropertyName = "drec_sopocli"
        Me.NCLIENTE.HeaderText = "N° CLIENTE"
        Me.NCLIENTE.Name = "NCLIENTE"
        Me.NCLIENTE.ReadOnly = True
        '
        'PROD
        '
        Me.PROD.DataPropertyName = "mae_descr"
        Me.PROD.HeaderText = "PRODUCTO"
        Me.PROD.Name = "PROD"
        Me.PROD.ReadOnly = True
        Me.PROD.Width = 300
        '
        'CAJAS
        '
        Me.CAJAS.DataPropertyName = "drec_unidades"
        Me.CAJAS.HeaderText = "CAJAS"
        Me.CAJAS.Name = "CAJAS"
        Me.CAJAS.ReadOnly = True
        Me.CAJAS.Width = 70
        '
        'KILOS
        '
        Me.KILOS.DataPropertyName = "drec_peso"
        Me.KILOS.HeaderText = "KILOS"
        Me.KILOS.Name = "KILOS"
        Me.KILOS.ReadOnly = True
        Me.KILOS.Width = 70
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.TxtClirut)
        Me.GroupBox1.Controls.Add(Me.Label43)
        Me.GroupBox1.Controls.Add(Me.txtcodcontrato)
        Me.GroupBox1.Controls.Add(Me.txtclinom)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtcontnom)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.TxtGuiaPrecisa)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.TxtGuiaCliente)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 15)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(579, 155)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.Label3.Location = New System.Drawing.Point(9, 51)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(553, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "______________________________________________________________________________"
        '
        'TxtClirut
        '
        Me.TxtClirut.Enabled = False
        Me.TxtClirut.Location = New System.Drawing.Point(112, 83)
        Me.TxtClirut.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TxtClirut.MaxLength = 9
        Me.TxtClirut.Name = "TxtClirut"
        Me.TxtClirut.Size = New System.Drawing.Size(72, 21)
        Me.TxtClirut.TabIndex = 59
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label43.Location = New System.Drawing.Point(13, 86)
        Me.Label43.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(56, 13)
        Me.Label43.TabIndex = 58
        Me.Label43.Text = "CLIENTE"
        '
        'txtcodcontrato
        '
        Me.txtcodcontrato.Enabled = False
        Me.txtcodcontrato.Location = New System.Drawing.Point(112, 113)
        Me.txtcodcontrato.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtcodcontrato.MaxLength = 7
        Me.txtcodcontrato.Name = "txtcodcontrato"
        Me.txtcodcontrato.Size = New System.Drawing.Size(72, 21)
        Me.txtcodcontrato.TabIndex = 55
        '
        'txtclinom
        '
        Me.txtclinom.Enabled = False
        Me.txtclinom.Location = New System.Drawing.Point(197, 83)
        Me.txtclinom.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtclinom.Name = "txtclinom"
        Me.txtclinom.Size = New System.Drawing.Size(368, 21)
        Me.txtclinom.TabIndex = 54
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(13, 117)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 13)
        Me.Label7.TabIndex = 56
        Me.Label7.Text = "CONTRATO"
        '
        'txtcontnom
        '
        Me.txtcontnom.Enabled = False
        Me.txtcontnom.Location = New System.Drawing.Point(197, 113)
        Me.txtcontnom.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtcontnom.Name = "txtcontnom"
        Me.txtcontnom.Size = New System.Drawing.Size(367, 21)
        Me.txtcontnom.TabIndex = 57
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(269, 9)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(93, 13)
        Me.Label27.TabIndex = 66
        Me.Label27.Text = "SOPORTANTES"
        '
        'txtkilos
        '
        Me.txtkilos.Enabled = False
        Me.txtkilos.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtkilos.Location = New System.Drawing.Point(594, 6)
        Me.txtkilos.Name = "txtkilos"
        Me.txtkilos.ReadOnly = True
        Me.txtkilos.Size = New System.Drawing.Size(93, 21)
        Me.txtkilos.TabIndex = 71
        Me.txtkilos.Text = "0"
        Me.txtkilos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtcajas
        '
        Me.txtcajas.Enabled = False
        Me.txtcajas.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcajas.Location = New System.Drawing.Point(474, 6)
        Me.txtcajas.Name = "txtcajas"
        Me.txtcajas.ReadOnly = True
        Me.txtcajas.Size = New System.Drawing.Size(54, 21)
        Me.txtcajas.TabIndex = 69
        Me.txtcajas.Text = "0"
        Me.txtcajas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.Location = New System.Drawing.Point(545, 9)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(43, 13)
        Me.Label40.TabIndex = 70
        Me.Label40.Text = "KILOS"
        '
        'txtsoportantes
        '
        Me.txtsoportantes.Enabled = False
        Me.txtsoportantes.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsoportantes.Location = New System.Drawing.Point(368, 6)
        Me.txtsoportantes.Name = "txtsoportantes"
        Me.txtsoportantes.ReadOnly = True
        Me.txtsoportantes.Size = New System.Drawing.Size(33, 21)
        Me.txtsoportantes.TabIndex = 67
        Me.txtsoportantes.Text = "0"
        Me.txtsoportantes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.Location = New System.Drawing.Point(423, 9)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(45, 13)
        Me.Label39.TabIndex = 68
        Me.Label39.Text = "CAJAS"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(28, 196)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(110, 14)
        Me.Label5.TabIndex = 74
        Me.Label5.Text = "N° RESOLUCIÓN"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.DgvClientes)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(714, 694)
        Me.Panel1.TabIndex = 75
        Me.Panel1.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(180, 146)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(306, 14)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "CODIGOS QUE COINCIDEN CON LO INGRESADO"
        '
        'DgvClientes
        '
        Me.DgvClientes.AllowUserToAddRows = False
        Me.DgvClientes.AllowUserToDeleteRows = False
        Me.DgvClientes.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark
        Me.DgvClientes.ColumnHeadersHeight = 28
        Me.DgvClientes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.RECEPCION, Me.CLIENTE, Me.GUIA})
        Me.DgvClientes.Location = New System.Drawing.Point(66, 173)
        Me.DgvClientes.Name = "DgvClientes"
        Me.DgvClientes.ReadOnly = True
        Me.DgvClientes.Size = New System.Drawing.Size(549, 278)
        Me.DgvClientes.TabIndex = 0
        '
        'RECEPCION
        '
        Me.RECEPCION.DataPropertyName = "frec_codi"
        Me.RECEPCION.HeaderText = "RECEPCION"
        Me.RECEPCION.Name = "RECEPCION"
        Me.RECEPCION.ReadOnly = True
        '
        'CLIENTE
        '
        Me.CLIENTE.DataPropertyName = "cli_nomb"
        Me.CLIENTE.HeaderText = "CLIENTE"
        Me.CLIENTE.Name = "CLIENTE"
        Me.CLIENTE.ReadOnly = True
        Me.CLIENTE.Width = 300
        '
        'GUIA
        '
        Me.GUIA.DataPropertyName = "frec_guiades"
        Me.GUIA.HeaderText = "GUIA"
        Me.GUIA.Name = "GUIA"
        Me.GUIA.ReadOnly = True
        '
        'TxtRcp
        '
        Me.TxtRcp.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRcp.Location = New System.Drawing.Point(164, 180)
        Me.TxtRcp.MaxLength = 20
        Me.TxtRcp.Name = "TxtRcp"
        Me.TxtRcp.Size = New System.Drawing.Size(339, 33)
        Me.TxtRcp.TabIndex = 77
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.BtnBuscar)
        Me.GroupBox4.Controls.Add(Me.BtnImprimir)
        Me.GroupBox4.Controls.Add(Me.BtnGuardar)
        Me.GroupBox4.Controls.Add(Me.BtnSalir)
        Me.GroupBox4.Controls.Add(Me.BtnNuevo)
        Me.GroupBox4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(735, 162)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(85, 340)
        Me.GroupBox4.TabIndex = 78
        Me.GroupBox4.TabStop = False
        '
        'BtnBuscar
        '
        Me.BtnBuscar.FlatAppearance.BorderSize = 0
        Me.BtnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnBuscar.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_lupa
        Me.BtnBuscar.Location = New System.Drawing.Point(10, 20)
        Me.BtnBuscar.Name = "BtnBuscar"
        Me.BtnBuscar.Size = New System.Drawing.Size(63, 63)
        Me.BtnBuscar.TabIndex = 73
        Me.BtnBuscar.UseVisualStyleBackColor = True
        '
        'BtnImprimir
        '
        Me.BtnImprimir.FlatAppearance.BorderSize = 0
        Me.BtnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnImprimir.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_impresora
        Me.BtnImprimir.Location = New System.Drawing.Point(10, 83)
        Me.BtnImprimir.Name = "BtnImprimir"
        Me.BtnImprimir.Size = New System.Drawing.Size(63, 63)
        Me.BtnImprimir.TabIndex = 32
        Me.BtnImprimir.UseVisualStyleBackColor = True
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Enabled = False
        Me.BtnGuardar.FlatAppearance.BorderSize = 0
        Me.BtnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnGuardar.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_guardar2
        Me.BtnGuardar.Location = New System.Drawing.Point(10, 146)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(63, 63)
        Me.BtnGuardar.TabIndex = 29
        Me.BtnGuardar.UseVisualStyleBackColor = True
        '
        'BtnSalir
        '
        Me.BtnSalir.FlatAppearance.BorderSize = 0
        Me.BtnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSalir.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_salida
        Me.BtnSalir.Location = New System.Drawing.Point(10, 270)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(63, 63)
        Me.BtnSalir.TabIndex = 31
        Me.BtnSalir.UseVisualStyleBackColor = True
        '
        'BtnNuevo
        '
        Me.BtnNuevo.FlatAppearance.BorderSize = 0
        Me.BtnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnNuevo.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_hojanueva
        Me.BtnNuevo.Location = New System.Drawing.Point(10, 208)
        Me.BtnNuevo.Name = "BtnNuevo"
        Me.BtnNuevo.Size = New System.Drawing.Size(63, 63)
        Me.BtnNuevo.TabIndex = 30
        Me.BtnNuevo.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label27)
        Me.Panel2.Controls.Add(Me.Label39)
        Me.Panel2.Controls.Add(Me.txtsoportantes)
        Me.Panel2.Controls.Add(Me.Label40)
        Me.Panel2.Controls.Add(Me.txtcajas)
        Me.Panel2.Controls.Add(Me.txtkilos)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(10, 625)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(911, 33)
        Me.Panel2.TabIndex = 79
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "drec_codi"
        Me.DataGridViewTextBoxColumn1.HeaderText = "N° PRECISA"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "drec_sopocli"
        Me.DataGridViewTextBoxColumn2.HeaderText = "N° CLIENTE"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "mae_descr"
        Me.DataGridViewTextBoxColumn3.HeaderText = "PRODUCTO"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 300
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "drec_unidades"
        Me.DataGridViewTextBoxColumn4.HeaderText = "CAJAS"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 70
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "drec_peso"
        Me.DataGridViewTextBoxColumn5.HeaderText = "KILOS"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 70
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "cli_nomb"
        Me.DataGridViewTextBoxColumn6.HeaderText = "CLIENTE"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Width = 300
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "frec_guiades"
        Me.DataGridViewTextBoxColumn7.HeaderText = "GUIA"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        '
        'Frm_Rcp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(921, 698)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.TxtRcp)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel2)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "Frm_Rcp"
        Me.Padding = New System.Windows.Forms.Padding(10, 225, 0, 40)
        Me.Text = "Proceso de ingreso de RPC"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DgvClientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtGuiaPrecisa As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtGuiaCliente As System.Windows.Forms.TextBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtClirut As System.Windows.Forms.TextBox
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents txtcodcontrato As System.Windows.Forms.TextBox
    Friend WithEvents txtclinom As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtcontnom As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txtkilos As System.Windows.Forms.TextBox
    Friend WithEvents txtcajas As System.Windows.Forms.TextBox
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents txtsoportantes As System.Windows.Forms.TextBox
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents DgvClientes As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TxtRcp As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnBuscar As System.Windows.Forms.Button
    Friend WithEvents BtnImprimir As System.Windows.Forms.Button
    Friend WithEvents BtnGuardar As System.Windows.Forms.Button
    Friend WithEvents BtnSalir As System.Windows.Forms.Button
    Friend WithEvents BtnNuevo As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents NPRECISA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NCLIENTE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PROD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CAJAS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KILOS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RECEPCION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CLIENTE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GUIA As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

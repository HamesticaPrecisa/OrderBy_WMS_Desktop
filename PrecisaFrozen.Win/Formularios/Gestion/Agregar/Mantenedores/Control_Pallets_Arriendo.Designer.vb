<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Control_Pallets_Arriendo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Control_Pallets_Arriendo))
        Me.DataGridViewImageColumn1 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.DataGridViewImageColumn2 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.gvMov = New System.Windows.Forms.DataGridView()
        Me.Rut_Cliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Codigo_Contrato = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Contrato = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Codigo_Soportante = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Recepcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Codigo_Tipo_Soportante = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Soportante = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha_Inicio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha_Inicio_Frm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha_Termino = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha_Termino_Frm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Despacho = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.btnImp = New System.Windows.Forms.Button()
        Me.btnSal = New System.Windows.Forms.Button()
        Me.btnLim = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.BtnTemp = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtFecFin = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtFec = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtsopcodi = New System.Windows.Forms.TextBox()
        Me.Btn_buscasoportante = New System.Windows.Forms.Button()
        Me.txtsopnombre = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtcodcontrato = New System.Windows.Forms.TextBox()
        Me.Btn_BuscaContrato = New System.Windows.Forms.Button()
        Me.txtnom_contrato = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtClirut = New System.Windows.Forms.TextBox()
        Me.btn_BuscaCliente = New System.Windows.Forms.Button()
        Me.txtclinom = New System.Windows.Forms.TextBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.GroupBox2.SuspendLayout()
        CType(Me.gvMov, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridViewImageColumn1
        '
        Me.DataGridViewImageColumn1.Frozen = True
        Me.DataGridViewImageColumn1.HeaderText = "FOTOS"
        Me.DataGridViewImageColumn1.Image = CType(resources.GetObject("DataGridViewImageColumn1.Image"), System.Drawing.Image)
        Me.DataGridViewImageColumn1.Name = "DataGridViewImageColumn1"
        '
        'DataGridViewImageColumn2
        '
        Me.DataGridViewImageColumn2.Frozen = True
        Me.DataGridViewImageColumn2.HeaderText = "ELIMINAR"
        Me.DataGridViewImageColumn2.Image = CType(resources.GetObject("DataGridViewImageColumn2.Image"), System.Drawing.Image)
        Me.DataGridViewImageColumn2.Name = "DataGridViewImageColumn2"
        Me.DataGridViewImageColumn2.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.gvMov)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 326)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1092, 331)
        Me.GroupBox2.TabIndex = 62
        Me.GroupBox2.TabStop = False
        '
        'gvMov
        '
        Me.gvMov.AllowUserToAddRows = False
        Me.gvMov.AllowUserToDeleteRows = False
        Me.gvMov.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvMov.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Rut_Cliente, Me.Cliente, Me.Codigo_Contrato, Me.Contrato, Me.Codigo_Soportante, Me.Recepcion, Me.Codigo_Tipo_Soportante, Me.Soportante, Me.Fecha_Inicio, Me.Fecha_Inicio_Frm, Me.Fecha_Termino, Me.Fecha_Termino_Frm, Me.Despacho})
        Me.gvMov.Location = New System.Drawing.Point(6, 19)
        Me.gvMov.Name = "gvMov"
        Me.gvMov.ReadOnly = True
        Me.gvMov.Size = New System.Drawing.Size(1080, 306)
        Me.gvMov.TabIndex = 0
        '
        'Rut_Cliente
        '
        Me.Rut_Cliente.DataPropertyName = "Rut_Cliente"
        Me.Rut_Cliente.Frozen = True
        Me.Rut_Cliente.HeaderText = "RUT"
        Me.Rut_Cliente.Name = "Rut_Cliente"
        Me.Rut_Cliente.ReadOnly = True
        Me.Rut_Cliente.Visible = False
        '
        'Cliente
        '
        Me.Cliente.DataPropertyName = "Cliente"
        Me.Cliente.Frozen = True
        Me.Cliente.HeaderText = "CLIENTE"
        Me.Cliente.Name = "Cliente"
        Me.Cliente.ReadOnly = True
        '
        'Codigo_Contrato
        '
        Me.Codigo_Contrato.DataPropertyName = "Codigo_Contrato"
        Me.Codigo_Contrato.Frozen = True
        Me.Codigo_Contrato.HeaderText = "CODIGO CONTRATO"
        Me.Codigo_Contrato.Name = "Codigo_Contrato"
        Me.Codigo_Contrato.ReadOnly = True
        Me.Codigo_Contrato.Visible = False
        '
        'Contrato
        '
        Me.Contrato.DataPropertyName = "Contrato"
        Me.Contrato.Frozen = True
        Me.Contrato.HeaderText = "CONTRATO"
        Me.Contrato.Name = "Contrato"
        Me.Contrato.ReadOnly = True
        '
        'Codigo_Soportante
        '
        Me.Codigo_Soportante.DataPropertyName = "Codigo_Soportante"
        Me.Codigo_Soportante.Frozen = True
        Me.Codigo_Soportante.HeaderText = "CODIGO SOPORTANTE"
        Me.Codigo_Soportante.Name = "Codigo_Soportante"
        Me.Codigo_Soportante.ReadOnly = True
        '
        'Recepcion
        '
        Me.Recepcion.DataPropertyName = "Recepcion"
        Me.Recepcion.Frozen = True
        Me.Recepcion.HeaderText = "RECEPCIÓN"
        Me.Recepcion.Name = "Recepcion"
        Me.Recepcion.ReadOnly = True
        '
        'Codigo_Tipo_Soportante
        '
        Me.Codigo_Tipo_Soportante.DataPropertyName = "Codigo_Tipo_Soportante"
        Me.Codigo_Tipo_Soportante.Frozen = True
        Me.Codigo_Tipo_Soportante.HeaderText = "CODIGO_TIPO_SOPORTANTE"
        Me.Codigo_Tipo_Soportante.Name = "Codigo_Tipo_Soportante"
        Me.Codigo_Tipo_Soportante.ReadOnly = True
        Me.Codigo_Tipo_Soportante.Visible = False
        '
        'Soportante
        '
        Me.Soportante.DataPropertyName = "Soportante"
        Me.Soportante.Frozen = True
        Me.Soportante.HeaderText = "SOPORTANTE"
        Me.Soportante.Name = "Soportante"
        Me.Soportante.ReadOnly = True
        '
        'Fecha_Inicio
        '
        Me.Fecha_Inicio.DataPropertyName = "Fecha_Inicio"
        Me.Fecha_Inicio.Frozen = True
        Me.Fecha_Inicio.HeaderText = "FECHA INICIO"
        Me.Fecha_Inicio.Name = "Fecha_Inicio"
        Me.Fecha_Inicio.ReadOnly = True
        Me.Fecha_Inicio.Visible = False
        '
        'Fecha_Inicio_Frm
        '
        Me.Fecha_Inicio_Frm.DataPropertyName = "Fecha_Inicio_Frm"
        Me.Fecha_Inicio_Frm.Frozen = True
        Me.Fecha_Inicio_Frm.HeaderText = "FECHA INICIO"
        Me.Fecha_Inicio_Frm.Name = "Fecha_Inicio_Frm"
        Me.Fecha_Inicio_Frm.ReadOnly = True
        '
        'Fecha_Termino
        '
        Me.Fecha_Termino.DataPropertyName = "Fecha_Termino"
        Me.Fecha_Termino.Frozen = True
        Me.Fecha_Termino.HeaderText = "FECHA TERMINO"
        Me.Fecha_Termino.Name = "Fecha_Termino"
        Me.Fecha_Termino.ReadOnly = True
        Me.Fecha_Termino.Visible = False
        '
        'Fecha_Termino_Frm
        '
        Me.Fecha_Termino_Frm.DataPropertyName = "Fecha_Termino_Frm"
        Me.Fecha_Termino_Frm.Frozen = True
        Me.Fecha_Termino_Frm.HeaderText = "FECHA TERMINO"
        Me.Fecha_Termino_Frm.Name = "Fecha_Termino_Frm"
        Me.Fecha_Termino_Frm.ReadOnly = True
        '
        'Despacho
        '
        Me.Despacho.DataPropertyName = "DESPACHO"
        Me.Despacho.Frozen = True
        Me.Despacho.HeaderText = "DESPACHO"
        Me.Despacho.Name = "Despacho"
        Me.Despacho.ReadOnly = True
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.btnImp)
        Me.GroupBox4.Controls.Add(Me.btnSal)
        Me.GroupBox4.Controls.Add(Me.btnLim)
        Me.GroupBox4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(1110, 12)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(75, 308)
        Me.GroupBox4.TabIndex = 61
        Me.GroupBox4.TabStop = False
        '
        'btnImp
        '
        Me.btnImp.FlatAppearance.BorderSize = 0
        Me.btnImp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImp.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.excel_2
        Me.btnImp.Location = New System.Drawing.Point(6, 21)
        Me.btnImp.Name = "btnImp"
        Me.btnImp.Size = New System.Drawing.Size(63, 63)
        Me.btnImp.TabIndex = 14
        Me.btnImp.UseVisualStyleBackColor = True
        '
        'btnSal
        '
        Me.btnSal.FlatAppearance.BorderSize = 0
        Me.btnSal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSal.Image = CType(resources.GetObject("btnSal.Image"), System.Drawing.Image)
        Me.btnSal.Location = New System.Drawing.Point(6, 159)
        Me.btnSal.Name = "btnSal"
        Me.btnSal.Size = New System.Drawing.Size(63, 61)
        Me.btnSal.TabIndex = 17
        Me.btnSal.UseVisualStyleBackColor = True
        '
        'btnLim
        '
        Me.btnLim.FlatAppearance.BorderSize = 0
        Me.btnLim.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLim.Image = CType(resources.GetObject("btnLim.Image"), System.Drawing.Image)
        Me.btnLim.Location = New System.Drawing.Point(6, 90)
        Me.btnLim.Name = "btnLim"
        Me.btnLim.Size = New System.Drawing.Size(63, 63)
        Me.btnLim.TabIndex = 15
        Me.btnLim.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.BtnTemp)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtFecFin)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtFec)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtsopcodi)
        Me.GroupBox1.Controls.Add(Me.Btn_buscasoportante)
        Me.GroupBox1.Controls.Add(Me.txtsopnombre)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtcodcontrato)
        Me.GroupBox1.Controls.Add(Me.Btn_BuscaContrato)
        Me.GroupBox1.Controls.Add(Me.txtnom_contrato)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.TxtClirut)
        Me.GroupBox1.Controls.Add(Me.btn_BuscaCliente)
        Me.GroupBox1.Controls.Add(Me.txtclinom)
        Me.GroupBox1.Controls.Add(Me.Label35)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1092, 308)
        Me.GroupBox1.TabIndex = 60
        Me.GroupBox1.TabStop = False
        '
        'BtnTemp
        '
        Me.BtnTemp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTemp.ForeColor = System.Drawing.Color.Black
        Me.BtnTemp.Location = New System.Drawing.Point(10, 268)
        Me.BtnTemp.Name = "BtnTemp"
        Me.BtnTemp.Size = New System.Drawing.Size(91, 21)
        Me.BtnTemp.TabIndex = 9
        Me.BtnTemp.Text = "FILTRAR"
        Me.BtnTemp.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(7, 234)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(97, 13)
        Me.Label4.TabIndex = 99
        Me.Label4.Text = "FECHA HASTA :"
        '
        'txtFecFin
        '
        Me.txtFecFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtFecFin.Location = New System.Drawing.Point(135, 228)
        Me.txtFecFin.Name = "txtFecFin"
        Me.txtFecFin.Size = New System.Drawing.Size(108, 20)
        Me.txtFecFin.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(7, 197)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(98, 13)
        Me.Label5.TabIndex = 89
        Me.Label5.Text = "FECHA DESDE :"
        '
        'txtFec
        '
        Me.txtFec.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtFec.Location = New System.Drawing.Point(135, 191)
        Me.txtFec.Name = "txtFec"
        Me.txtFec.Size = New System.Drawing.Size(108, 20)
        Me.txtFec.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(7, 157)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(94, 13)
        Me.Label3.TabIndex = 85
        Me.Label3.Text = "SOPORTANTE :"
        '
        'txtsopcodi
        '
        Me.txtsopcodi.Enabled = False
        Me.txtsopcodi.Location = New System.Drawing.Point(135, 154)
        Me.txtsopcodi.MaxLength = 4
        Me.txtsopcodi.Name = "txtsopcodi"
        Me.txtsopcodi.Size = New System.Drawing.Size(82, 20)
        Me.txtsopcodi.TabIndex = 4
        '
        'Btn_buscasoportante
        '
        Me.Btn_buscasoportante.Image = CType(resources.GetObject("Btn_buscasoportante.Image"), System.Drawing.Image)
        Me.Btn_buscasoportante.Location = New System.Drawing.Point(225, 152)
        Me.Btn_buscasoportante.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Btn_buscasoportante.Name = "Btn_buscasoportante"
        Me.Btn_buscasoportante.Size = New System.Drawing.Size(21, 22)
        Me.Btn_buscasoportante.TabIndex = 5
        Me.Btn_buscasoportante.UseVisualStyleBackColor = True
        '
        'txtsopnombre
        '
        Me.txtsopnombre.Enabled = False
        Me.txtsopnombre.Location = New System.Drawing.Point(254, 154)
        Me.txtsopnombre.Name = "txtsopnombre"
        Me.txtsopnombre.Size = New System.Drawing.Size(192, 20)
        Me.txtsopnombre.TabIndex = 84
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(6, 117)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 13)
        Me.Label1.TabIndex = 80
        Me.Label1.Text = "CONTRATO :"
        '
        'txtcodcontrato
        '
        Me.txtcodcontrato.Location = New System.Drawing.Point(135, 114)
        Me.txtcodcontrato.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtcodcontrato.MaxLength = 7
        Me.txtcodcontrato.Name = "txtcodcontrato"
        Me.txtcodcontrato.Size = New System.Drawing.Size(82, 20)
        Me.txtcodcontrato.TabIndex = 2
        '
        'Btn_BuscaContrato
        '
        Me.Btn_BuscaContrato.Image = CType(resources.GetObject("Btn_BuscaContrato.Image"), System.Drawing.Image)
        Me.Btn_BuscaContrato.Location = New System.Drawing.Point(225, 112)
        Me.Btn_BuscaContrato.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Btn_BuscaContrato.Name = "Btn_BuscaContrato"
        Me.Btn_BuscaContrato.Size = New System.Drawing.Size(21, 22)
        Me.Btn_BuscaContrato.TabIndex = 3
        Me.Btn_BuscaContrato.UseVisualStyleBackColor = True
        '
        'txtnom_contrato
        '
        Me.txtnom_contrato.Enabled = False
        Me.txtnom_contrato.Location = New System.Drawing.Point(254, 114)
        Me.txtnom_contrato.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtnom_contrato.Name = "txtnom_contrato"
        Me.txtnom_contrato.Size = New System.Drawing.Size(380, 20)
        Me.txtnom_contrato.TabIndex = 78
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(7, 78)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 13)
        Me.Label2.TabIndex = 75
        Me.Label2.Text = "CLIENTE :"
        '
        'TxtClirut
        '
        Me.TxtClirut.Location = New System.Drawing.Point(135, 75)
        Me.TxtClirut.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TxtClirut.MaxLength = 8
        Me.TxtClirut.Name = "TxtClirut"
        Me.TxtClirut.Size = New System.Drawing.Size(82, 20)
        Me.TxtClirut.TabIndex = 0
        '
        'btn_BuscaCliente
        '
        Me.btn_BuscaCliente.Image = CType(resources.GetObject("btn_BuscaCliente.Image"), System.Drawing.Image)
        Me.btn_BuscaCliente.Location = New System.Drawing.Point(225, 73)
        Me.btn_BuscaCliente.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btn_BuscaCliente.Name = "btn_BuscaCliente"
        Me.btn_BuscaCliente.Size = New System.Drawing.Size(21, 22)
        Me.btn_BuscaCliente.TabIndex = 1
        Me.btn_BuscaCliente.UseVisualStyleBackColor = True
        '
        'txtclinom
        '
        Me.txtclinom.Enabled = False
        Me.txtclinom.Location = New System.Drawing.Point(254, 75)
        Me.txtclinom.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtclinom.Name = "txtclinom"
        Me.txtclinom.Size = New System.Drawing.Size(380, 20)
        Me.txtclinom.TabIndex = 72
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.BackColor = System.Drawing.Color.Transparent
        Me.Label35.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.ForeColor = System.Drawing.Color.White
        Me.Label35.Location = New System.Drawing.Point(6, 16)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(164, 14)
        Me.Label35.TabIndex = 70
        Me.Label35.Text = "ARRIENDO DE PALLETS"
        '
        'Control_Pallets_Arriendo
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(1201, 671)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Control_Pallets_Arriendo"
        Me.Text = "Control_Pallets_Arriendo"
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.gvMov, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridViewImageColumn1 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents DataGridViewImageColumn2 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents gvMov As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btnImp As System.Windows.Forms.Button
    Friend WithEvents btnSal As System.Windows.Forms.Button
    Friend WithEvents btnLim As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtFec As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtsopcodi As System.Windows.Forms.TextBox
    Friend WithEvents Btn_buscasoportante As System.Windows.Forms.Button
    Friend WithEvents txtsopnombre As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtcodcontrato As System.Windows.Forms.TextBox
    Friend WithEvents Btn_BuscaContrato As System.Windows.Forms.Button
    Friend WithEvents txtnom_contrato As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtClirut As System.Windows.Forms.TextBox
    Friend WithEvents btn_BuscaCliente As System.Windows.Forms.Button
    Friend WithEvents txtclinom As System.Windows.Forms.TextBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtFecFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents BtnTemp As System.Windows.Forms.Button
    Friend WithEvents Rut_Cliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Codigo_Contrato As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Contrato As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Codigo_Soportante As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Recepcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Codigo_Tipo_Soportante As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Soportante As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha_Inicio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha_Inicio_Frm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha_Termino As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha_Termino_Frm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Despacho As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

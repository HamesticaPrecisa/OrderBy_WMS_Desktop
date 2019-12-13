<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Recepcion_Programacion_Listado
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Recepcion_Programacion_Listado))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboTun = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboTipExp = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboTipCar = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtFecFin = New System.Windows.Forms.DateTimePicker()
        Me.txtFecIni = New System.Windows.Forms.DateTimePicker()
        Me.chkLimFec = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtClirut = New System.Windows.Forms.TextBox()
        Me.btn_BuscaCliente = New System.Windows.Forms.Button()
        Me.txtclinom = New System.Windows.Forms.TextBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.btnFil = New System.Windows.Forms.Button()
        Me.btnSal = New System.Windows.Forms.Button()
        Me.btnLim = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.gvRece = New System.Windows.Forms.DataGridView()
        Me.tmrAct = New System.Windows.Forms.Timer(Me.components)
        Me.cboEst = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
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
        Me.DataGridViewTextBoxColumn17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn18 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn19 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn20 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn21 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn22 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Estado_Frm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Folio_Camion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Hora_Registro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha_Frm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Hora_Inicio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Hora_Termino = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Rut_Cliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tipo_Carga = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tipo_Carga_Frm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tipo_Exportacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tipo_Exportacion_Frm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tunel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tunel_Frm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Total_Soportantes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Total_Peso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Observaciones = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Mail_Enviado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Mail_Enviado_Frm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnEli = New System.Windows.Forms.DataGridViewImageColumn()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.gvRece, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboEst)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.cboTun)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.cboTipExp)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cboTipCar)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtFecFin)
        Me.GroupBox1.Controls.Add(Me.txtFecIni)
        Me.GroupBox1.Controls.Add(Me.chkLimFec)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.TxtClirut)
        Me.GroupBox1.Controls.Add(Me.btn_BuscaCliente)
        Me.GroupBox1.Controls.Add(Me.txtclinom)
        Me.GroupBox1.Controls.Add(Me.Label35)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(642, 247)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'cboTun
        '
        Me.cboTun.FormattingEnabled = True
        Me.cboTun.Location = New System.Drawing.Point(151, 208)
        Me.cboTun.Name = "cboTun"
        Me.cboTun.Size = New System.Drawing.Size(105, 21)
        Me.cboTun.TabIndex = 6
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(7, 211)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 13)
        Me.Label7.TabIndex = 98
        Me.Label7.Text = "TÚNEL : "
        '
        'cboTipExp
        '
        Me.cboTipExp.FormattingEnabled = True
        Me.cboTipExp.Location = New System.Drawing.Point(460, 171)
        Me.cboTipExp.Name = "cboTipExp"
        Me.cboTipExp.Size = New System.Drawing.Size(105, 21)
        Me.cboTipExp.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(309, 174)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(137, 13)
        Me.Label3.TabIndex = 96
        Me.Label3.Text = "TIPO EXPORTACIÓN : "
        '
        'cboTipCar
        '
        Me.cboTipCar.FormattingEnabled = True
        Me.cboTipCar.Location = New System.Drawing.Point(460, 134)
        Me.cboTipCar.Name = "cboTipCar"
        Me.cboTipCar.Size = New System.Drawing.Size(105, 21)
        Me.cboTipCar.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(309, 137)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(118, 13)
        Me.Label1.TabIndex = 94
        Me.Label1.Text = "TIPO DESCARGA : "
        '
        'txtFecFin
        '
        Me.txtFecFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtFecFin.Location = New System.Drawing.Point(151, 168)
        Me.txtFecFin.Name = "txtFecFin"
        Me.txtFecFin.Size = New System.Drawing.Size(108, 20)
        Me.txtFecFin.TabIndex = 5
        '
        'txtFecIni
        '
        Me.txtFecIni.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtFecIni.Location = New System.Drawing.Point(151, 131)
        Me.txtFecIni.Name = "txtFecIni"
        Me.txtFecIni.Size = New System.Drawing.Size(108, 20)
        Me.txtFecIni.TabIndex = 4
        '
        'chkLimFec
        '
        Me.chkLimFec.AutoSize = True
        Me.chkLimFec.Location = New System.Drawing.Point(151, 100)
        Me.chkLimFec.Name = "chkLimFec"
        Me.chkLimFec.Size = New System.Drawing.Size(15, 14)
        Me.chkLimFec.TabIndex = 3
        Me.chkLimFec.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(7, 100)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(118, 13)
        Me.Label6.TabIndex = 92
        Me.Label6.Text = "LÍMITAR FECHAS : "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(7, 174)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(115, 13)
        Me.Label4.TabIndex = 91
        Me.Label4.Text = "FECHA TÉRMINO : "
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(7, 137)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(103, 13)
        Me.Label5.TabIndex = 90
        Me.Label5.Text = "FECHA INICIO : "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(7, 63)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 13)
        Me.Label2.TabIndex = 86
        Me.Label2.Text = "CLIENTE :"
        '
        'TxtClirut
        '
        Me.TxtClirut.Location = New System.Drawing.Point(151, 60)
        Me.TxtClirut.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TxtClirut.MaxLength = 8
        Me.TxtClirut.Name = "TxtClirut"
        Me.TxtClirut.Size = New System.Drawing.Size(82, 20)
        Me.TxtClirut.TabIndex = 0
        '
        'btn_BuscaCliente
        '
        Me.btn_BuscaCliente.Image = CType(resources.GetObject("btn_BuscaCliente.Image"), System.Drawing.Image)
        Me.btn_BuscaCliente.Location = New System.Drawing.Point(241, 58)
        Me.btn_BuscaCliente.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btn_BuscaCliente.Name = "btn_BuscaCliente"
        Me.btn_BuscaCliente.Size = New System.Drawing.Size(21, 22)
        Me.btn_BuscaCliente.TabIndex = 1
        Me.btn_BuscaCliente.UseVisualStyleBackColor = True
        '
        'txtclinom
        '
        Me.txtclinom.Enabled = False
        Me.txtclinom.Location = New System.Drawing.Point(270, 60)
        Me.txtclinom.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtclinom.Name = "txtclinom"
        Me.txtclinom.Size = New System.Drawing.Size(346, 20)
        Me.txtclinom.TabIndex = 2
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.BackColor = System.Drawing.Color.Transparent
        Me.Label35.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.ForeColor = System.Drawing.Color.White
        Me.Label35.Location = New System.Drawing.Point(6, 16)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(277, 14)
        Me.Label35.TabIndex = 82
        Me.Label35.Text = "LISTADO RECEPCIONES PROGRAMADAS"
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.btnFil)
        Me.GroupBox4.Controls.Add(Me.btnSal)
        Me.GroupBox4.Controls.Add(Me.btnLim)
        Me.GroupBox4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(660, 12)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(75, 247)
        Me.GroupBox4.TabIndex = 64
        Me.GroupBox4.TabStop = False
        '
        'btnFil
        '
        Me.btnFil.FlatAppearance.BorderSize = 0
        Me.btnFil.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFil.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_lupa
        Me.btnFil.Location = New System.Drawing.Point(6, 24)
        Me.btnFil.Name = "btnFil"
        Me.btnFil.Size = New System.Drawing.Size(63, 63)
        Me.btnFil.TabIndex = 10
        Me.btnFil.UseVisualStyleBackColor = True
        '
        'btnSal
        '
        Me.btnSal.FlatAppearance.BorderSize = 0
        Me.btnSal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSal.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_salida
        Me.btnSal.Location = New System.Drawing.Point(6, 162)
        Me.btnSal.Name = "btnSal"
        Me.btnSal.Size = New System.Drawing.Size(63, 61)
        Me.btnSal.TabIndex = 12
        Me.btnSal.UseVisualStyleBackColor = True
        '
        'btnLim
        '
        Me.btnLim.FlatAppearance.BorderSize = 0
        Me.btnLim.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLim.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_hojanueva
        Me.btnLim.Location = New System.Drawing.Point(6, 93)
        Me.btnLim.Name = "btnLim"
        Me.btnLim.Size = New System.Drawing.Size(63, 63)
        Me.btnLim.TabIndex = 11
        Me.btnLim.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.gvRece)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 265)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1498, 410)
        Me.GroupBox2.TabIndex = 65
        Me.GroupBox2.TabStop = False
        '
        'gvRece
        '
        Me.gvRece.AllowUserToAddRows = False
        Me.gvRece.AllowUserToDeleteRows = False
        Me.gvRece.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvRece.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.Estado, Me.Estado_Frm, Me.Folio_Camion, Me.Hora_Registro, Me.Fecha, Me.Fecha_Frm, Me.Hora_Inicio, Me.Hora_Termino, Me.Rut_Cliente, Me.Cliente, Me.Tipo_Carga, Me.Tipo_Carga_Frm, Me.Tipo_Exportacion, Me.Tipo_Exportacion_Frm, Me.Tunel, Me.Tunel_Frm, Me.Total_Soportantes, Me.Total_Peso, Me.Observaciones, Me.Mail_Enviado, Me.Mail_Enviado_Frm, Me.btnEli})
        Me.gvRece.Location = New System.Drawing.Point(6, 10)
        Me.gvRece.Name = "gvRece"
        Me.gvRece.ReadOnly = True
        Me.gvRece.Size = New System.Drawing.Size(1486, 394)
        Me.gvRece.TabIndex = 13
        '
        'tmrAct
        '
        '
        'cboEst
        '
        Me.cboEst.FormattingEnabled = True
        Me.cboEst.Location = New System.Drawing.Point(460, 208)
        Me.cboEst.Name = "cboEst"
        Me.cboEst.Size = New System.Drawing.Size(105, 21)
        Me.cboEst.TabIndex = 9
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(309, 211)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(68, 13)
        Me.Label8.TabIndex = 100
        Me.Label8.Text = "ESTADO : "
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "ID"
        Me.DataGridViewTextBoxColumn1.Frozen = True
        Me.DataGridViewTextBoxColumn1.HeaderText = "ID"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Fecha"
        Me.DataGridViewTextBoxColumn2.Frozen = True
        Me.DataGridViewTextBoxColumn2.HeaderText = "FECHA"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Visible = False
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "Fecha_Frm"
        Me.DataGridViewTextBoxColumn3.Frozen = True
        Me.DataGridViewTextBoxColumn3.HeaderText = "FECHA"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "Hora_Inicio"
        Me.DataGridViewTextBoxColumn4.Frozen = True
        Me.DataGridViewTextBoxColumn4.HeaderText = "HORA INICIO"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Visible = False
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "Hora_Termino"
        Me.DataGridViewTextBoxColumn5.Frozen = True
        Me.DataGridViewTextBoxColumn5.HeaderText = "HORA TERMINO"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "Rut_Cliente"
        Me.DataGridViewTextBoxColumn6.Frozen = True
        Me.DataGridViewTextBoxColumn6.HeaderText = "RUT CLIENTE"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Visible = False
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "Cliente"
        Me.DataGridViewTextBoxColumn7.Frozen = True
        Me.DataGridViewTextBoxColumn7.HeaderText = "CLIENTE"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "Tipo_Carga"
        Me.DataGridViewTextBoxColumn8.Frozen = True
        Me.DataGridViewTextBoxColumn8.HeaderText = "TIPO CARGA"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Visible = False
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "Tipo_Carga_Frm"
        Me.DataGridViewTextBoxColumn9.Frozen = True
        Me.DataGridViewTextBoxColumn9.HeaderText = "TIPO CARGA"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        Me.DataGridViewTextBoxColumn9.Visible = False
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "Tipo_Exportacion"
        Me.DataGridViewTextBoxColumn10.Frozen = True
        Me.DataGridViewTextBoxColumn10.HeaderText = "EXPORTACIÓN"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        Me.DataGridViewTextBoxColumn10.Visible = False
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "Tipo_Exportacion_Frm"
        Me.DataGridViewTextBoxColumn11.Frozen = True
        Me.DataGridViewTextBoxColumn11.HeaderText = "TÚNEL"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        Me.DataGridViewTextBoxColumn11.Visible = False
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "Tunel"
        Me.DataGridViewTextBoxColumn12.Frozen = True
        Me.DataGridViewTextBoxColumn12.HeaderText = "TÚNEL"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.ReadOnly = True
        Me.DataGridViewTextBoxColumn12.Visible = False
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.DataPropertyName = "Tunel_Fm"
        Me.DataGridViewTextBoxColumn13.Frozen = True
        Me.DataGridViewTextBoxColumn13.HeaderText = "SOPORTANTES"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.ReadOnly = True
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.DataPropertyName = "Total_Soportantes"
        Me.DataGridViewTextBoxColumn14.Frozen = True
        Me.DataGridViewTextBoxColumn14.HeaderText = "PESO"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.ReadOnly = True
        Me.DataGridViewTextBoxColumn14.Visible = False
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.DataPropertyName = "Total_Peso"
        Me.DataGridViewTextBoxColumn15.Frozen = True
        Me.DataGridViewTextBoxColumn15.HeaderText = "PESO"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        Me.DataGridViewTextBoxColumn15.ReadOnly = True
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.DataPropertyName = "Observaciones"
        Me.DataGridViewTextBoxColumn16.Frozen = True
        Me.DataGridViewTextBoxColumn16.HeaderText = "OBSERVACIONES"
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        Me.DataGridViewTextBoxColumn16.ReadOnly = True
        Me.DataGridViewTextBoxColumn16.Visible = False
        '
        'DataGridViewTextBoxColumn17
        '
        Me.DataGridViewTextBoxColumn17.DataPropertyName = "Mail_Enviado"
        Me.DataGridViewTextBoxColumn17.Frozen = True
        Me.DataGridViewTextBoxColumn17.HeaderText = "MAIL ENVIADO"
        Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
        Me.DataGridViewTextBoxColumn17.ReadOnly = True
        Me.DataGridViewTextBoxColumn17.Visible = False
        '
        'DataGridViewTextBoxColumn18
        '
        Me.DataGridViewTextBoxColumn18.DataPropertyName = "Mail_Enviado_Frm"
        Me.DataGridViewTextBoxColumn18.Frozen = True
        Me.DataGridViewTextBoxColumn18.HeaderText = "MAIL ENVIADO"
        Me.DataGridViewTextBoxColumn18.Name = "DataGridViewTextBoxColumn18"
        Me.DataGridViewTextBoxColumn18.ReadOnly = True
        Me.DataGridViewTextBoxColumn18.Visible = False
        '
        'DataGridViewTextBoxColumn19
        '
        Me.DataGridViewTextBoxColumn19.DataPropertyName = "Mail_Enviado"
        Me.DataGridViewTextBoxColumn19.Frozen = True
        Me.DataGridViewTextBoxColumn19.HeaderText = "MAIL ENVIADO"
        Me.DataGridViewTextBoxColumn19.Name = "DataGridViewTextBoxColumn19"
        Me.DataGridViewTextBoxColumn19.ReadOnly = True
        Me.DataGridViewTextBoxColumn19.Visible = False
        '
        'DataGridViewTextBoxColumn20
        '
        Me.DataGridViewTextBoxColumn20.DataPropertyName = "Mail_Enviado_Frm"
        Me.DataGridViewTextBoxColumn20.Frozen = True
        Me.DataGridViewTextBoxColumn20.HeaderText = "MAIL ENVIADO"
        Me.DataGridViewTextBoxColumn20.Name = "DataGridViewTextBoxColumn20"
        Me.DataGridViewTextBoxColumn20.ReadOnly = True
        Me.DataGridViewTextBoxColumn20.Visible = False
        '
        'DataGridViewTextBoxColumn21
        '
        Me.DataGridViewTextBoxColumn21.DataPropertyName = "Mail_Enviado"
        Me.DataGridViewTextBoxColumn21.Frozen = True
        Me.DataGridViewTextBoxColumn21.HeaderText = "MAIL ENVIADO"
        Me.DataGridViewTextBoxColumn21.Name = "DataGridViewTextBoxColumn21"
        Me.DataGridViewTextBoxColumn21.ReadOnly = True
        Me.DataGridViewTextBoxColumn21.Visible = False
        '
        'DataGridViewTextBoxColumn22
        '
        Me.DataGridViewTextBoxColumn22.DataPropertyName = "Mail_Enviado_Frm"
        Me.DataGridViewTextBoxColumn22.Frozen = True
        Me.DataGridViewTextBoxColumn22.HeaderText = "MAIL ENVIADO"
        Me.DataGridViewTextBoxColumn22.Name = "DataGridViewTextBoxColumn22"
        Me.DataGridViewTextBoxColumn22.ReadOnly = True
        Me.DataGridViewTextBoxColumn22.Visible = False
        '
        'ID
        '
        Me.ID.DataPropertyName = "ID"
        Me.ID.Frozen = True
        Me.ID.HeaderText = "NRO. TICKET"
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        '
        'Estado
        '
        Me.Estado.DataPropertyName = "Estado"
        Me.Estado.Frozen = True
        Me.Estado.HeaderText = "ESTADO"
        Me.Estado.Name = "Estado"
        Me.Estado.ReadOnly = True
        Me.Estado.Visible = False
        '
        'Estado_Frm
        '
        Me.Estado_Frm.DataPropertyName = "Estado_Frm"
        Me.Estado_Frm.Frozen = True
        Me.Estado_Frm.HeaderText = "ESTADO"
        Me.Estado_Frm.Name = "Estado_Frm"
        Me.Estado_Frm.ReadOnly = True
        '
        'Folio_Camion
        '
        Me.Folio_Camion.DataPropertyName = "Folio_Camion"
        Me.Folio_Camion.Frozen = True
        Me.Folio_Camion.HeaderText = "FOLIO CAMIÓN"
        Me.Folio_Camion.Name = "Folio_Camion"
        Me.Folio_Camion.ReadOnly = True
        '
        'Hora_Registro
        '
        Me.Hora_Registro.DataPropertyName = "Hora_Registro"
        Me.Hora_Registro.Frozen = True
        Me.Hora_Registro.HeaderText = "HORA REGISTRO"
        Me.Hora_Registro.Name = "Hora_Registro"
        Me.Hora_Registro.ReadOnly = True
        '
        'Fecha
        '
        Me.Fecha.DataPropertyName = "Fecha"
        Me.Fecha.Frozen = True
        Me.Fecha.HeaderText = "FECHA"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.ReadOnly = True
        Me.Fecha.Visible = False
        '
        'Fecha_Frm
        '
        Me.Fecha_Frm.DataPropertyName = "Fecha_Frm"
        Me.Fecha_Frm.Frozen = True
        Me.Fecha_Frm.HeaderText = "FECHA"
        Me.Fecha_Frm.Name = "Fecha_Frm"
        Me.Fecha_Frm.ReadOnly = True
        '
        'Hora_Inicio
        '
        Me.Hora_Inicio.DataPropertyName = "Hora_Inicio"
        Me.Hora_Inicio.Frozen = True
        Me.Hora_Inicio.HeaderText = "HORA PROGRAMADA"
        Me.Hora_Inicio.Name = "Hora_Inicio"
        Me.Hora_Inicio.ReadOnly = True
        '
        'Hora_Termino
        '
        Me.Hora_Termino.DataPropertyName = "Hora_Termino"
        Me.Hora_Termino.Frozen = True
        Me.Hora_Termino.HeaderText = "HORA TERMINO"
        Me.Hora_Termino.Name = "Hora_Termino"
        Me.Hora_Termino.ReadOnly = True
        Me.Hora_Termino.Visible = False
        '
        'Rut_Cliente
        '
        Me.Rut_Cliente.DataPropertyName = "Rut_Cliente"
        Me.Rut_Cliente.Frozen = True
        Me.Rut_Cliente.HeaderText = "RUT CLIENTE"
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
        'Tipo_Carga
        '
        Me.Tipo_Carga.DataPropertyName = "Tipo_Carga"
        Me.Tipo_Carga.Frozen = True
        Me.Tipo_Carga.HeaderText = "TIPO CARGA"
        Me.Tipo_Carga.Name = "Tipo_Carga"
        Me.Tipo_Carga.ReadOnly = True
        Me.Tipo_Carga.Visible = False
        '
        'Tipo_Carga_Frm
        '
        Me.Tipo_Carga_Frm.DataPropertyName = "Tipo_Carga_Frm"
        Me.Tipo_Carga_Frm.Frozen = True
        Me.Tipo_Carga_Frm.HeaderText = "TIPO DESCARGA"
        Me.Tipo_Carga_Frm.Name = "Tipo_Carga_Frm"
        Me.Tipo_Carga_Frm.ReadOnly = True
        '
        'Tipo_Exportacion
        '
        Me.Tipo_Exportacion.DataPropertyName = "Tipo_Exportacion"
        Me.Tipo_Exportacion.Frozen = True
        Me.Tipo_Exportacion.HeaderText = "EXPORTACIÓN"
        Me.Tipo_Exportacion.Name = "Tipo_Exportacion"
        Me.Tipo_Exportacion.ReadOnly = True
        Me.Tipo_Exportacion.Visible = False
        '
        'Tipo_Exportacion_Frm
        '
        Me.Tipo_Exportacion_Frm.DataPropertyName = "Tipo_Exportacion_Frm"
        Me.Tipo_Exportacion_Frm.Frozen = True
        Me.Tipo_Exportacion_Frm.HeaderText = "EXPORTACIÓN"
        Me.Tipo_Exportacion_Frm.Name = "Tipo_Exportacion_Frm"
        Me.Tipo_Exportacion_Frm.ReadOnly = True
        '
        'Tunel
        '
        Me.Tunel.DataPropertyName = "Tunel"
        Me.Tunel.Frozen = True
        Me.Tunel.HeaderText = "TÚNEL"
        Me.Tunel.Name = "Tunel"
        Me.Tunel.ReadOnly = True
        Me.Tunel.Visible = False
        '
        'Tunel_Frm
        '
        Me.Tunel_Frm.DataPropertyName = "Tunel_Frm"
        Me.Tunel_Frm.Frozen = True
        Me.Tunel_Frm.HeaderText = "TÚNEL"
        Me.Tunel_Frm.Name = "Tunel_Frm"
        Me.Tunel_Frm.ReadOnly = True
        '
        'Total_Soportantes
        '
        Me.Total_Soportantes.DataPropertyName = "Total_Soportantes"
        Me.Total_Soportantes.Frozen = True
        Me.Total_Soportantes.HeaderText = "SOPORTANTES"
        Me.Total_Soportantes.Name = "Total_Soportantes"
        Me.Total_Soportantes.ReadOnly = True
        '
        'Total_Peso
        '
        Me.Total_Peso.DataPropertyName = "Total_Peso"
        Me.Total_Peso.Frozen = True
        Me.Total_Peso.HeaderText = "PESO"
        Me.Total_Peso.Name = "Total_Peso"
        Me.Total_Peso.ReadOnly = True
        '
        'Observaciones
        '
        Me.Observaciones.DataPropertyName = "Observaciones"
        Me.Observaciones.Frozen = True
        Me.Observaciones.HeaderText = "OBSERVACIONES"
        Me.Observaciones.Name = "Observaciones"
        Me.Observaciones.ReadOnly = True
        Me.Observaciones.Visible = False
        '
        'Mail_Enviado
        '
        Me.Mail_Enviado.DataPropertyName = "Mail_Enviado"
        Me.Mail_Enviado.Frozen = True
        Me.Mail_Enviado.HeaderText = "MAIL ENVIADO"
        Me.Mail_Enviado.Name = "Mail_Enviado"
        Me.Mail_Enviado.ReadOnly = True
        Me.Mail_Enviado.Visible = False
        '
        'Mail_Enviado_Frm
        '
        Me.Mail_Enviado_Frm.DataPropertyName = "Mail_Enviado_Frm"
        Me.Mail_Enviado_Frm.Frozen = True
        Me.Mail_Enviado_Frm.HeaderText = "MAIL ENVIADO"
        Me.Mail_Enviado_Frm.Name = "Mail_Enviado_Frm"
        Me.Mail_Enviado_Frm.ReadOnly = True
        Me.Mail_Enviado_Frm.Visible = False
        '
        'btnEli
        '
        Me.btnEli.Frozen = True
        Me.btnEli.HeaderText = "ELIMINAR"
        Me.btnEli.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.button_cancel
        Me.btnEli.Name = "btnEli"
        Me.btnEli.ReadOnly = True
        '
        'Recepcion_Programacion_Listado
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(1522, 687)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Recepcion_Programacion_Listado"
        Me.Text = "Recepcion_Programacion_Listado"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.gvRece, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtClirut As System.Windows.Forms.TextBox
    Friend WithEvents btn_BuscaCliente As System.Windows.Forms.Button
    Friend WithEvents txtclinom As System.Windows.Forms.TextBox
    Friend WithEvents txtFecFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtFecIni As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkLimFec As System.Windows.Forms.CheckBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboTipCar As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboTipExp As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboTun As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btnFil As System.Windows.Forms.Button
    Friend WithEvents btnSal As System.Windows.Forms.Button
    Friend WithEvents btnLim As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents gvRece As System.Windows.Forms.DataGridView
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
    Friend WithEvents DataGridViewTextBoxColumn16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn18 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn19 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn20 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tmrAct As System.Windows.Forms.Timer
    Friend WithEvents DataGridViewTextBoxColumn21 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn22 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cboEst As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Estado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Estado_Frm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Folio_Camion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Hora_Registro As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha_Frm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Hora_Inicio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Hora_Termino As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Rut_Cliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tipo_Carga As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tipo_Carga_Frm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tipo_Exportacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tipo_Exportacion_Frm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tunel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tunel_Frm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Total_Soportantes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Total_Peso As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Observaciones As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Mail_Enviado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Mail_Enviado_Frm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnEli As System.Windows.Forms.DataGridViewImageColumn
End Class

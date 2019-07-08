<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_PedidosBloqueoDias
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GrBxFecHra = New System.Windows.Forms.GroupBox()
        Me.txtFecIngBloq = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnLimBloq = New System.Windows.Forms.Button()
        Me.btnGraBloq = New System.Windows.Forms.Button()
        Me.btnEliBloq = New System.Windows.Forms.Button()
        Me.txtIdBloq = New System.Windows.Forms.TextBox()
        Me.txtUsuCod = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtHraFinBloq = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtMotBloq = New System.Windows.Forms.TextBox()
        Me.calFecBloq = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtHraIniBloq = New System.Windows.Forms.TextBox()
        Me.dgvBloq = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtFecIngRes = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnLimRes = New System.Windows.Forms.Button()
        Me.btnGraRes = New System.Windows.Forms.Button()
        Me.btnEliRes = New System.Windows.Forms.Button()
        Me.dgvRes = New System.Windows.Forms.DataGridView()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cboTipCar = New System.Windows.Forms.ComboBox()
        Me.txtIdRes = New System.Windows.Forms.TextBox()
        Me.txtUsuRes = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtHraLimRes = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtHraTerRes = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtHraIniRes = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
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
        Me.IdRestriccionService = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdUsu = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdTipoCarga = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TipoCarga = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HraIni = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HraFin = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HraLim = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaIngresoRes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdRestriccion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdUsuario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaRestriccion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HoraInicio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HoraTermino = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Motivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaIngreso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GrBxFecHra.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvBloq, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgvRes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(22, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.Label1.Size = New System.Drawing.Size(473, 22)
        Me.Label1.TabIndex = 68
        Me.Label1.Text = "Bloqueos Fecha/Horas"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GrBxFecHra
        '
        Me.GrBxFecHra.BackColor = System.Drawing.Color.Transparent
        Me.GrBxFecHra.Controls.Add(Me.txtFecIngBloq)
        Me.GrBxFecHra.Controls.Add(Me.GroupBox2)
        Me.GrBxFecHra.Controls.Add(Me.txtIdBloq)
        Me.GrBxFecHra.Controls.Add(Me.txtUsuCod)
        Me.GrBxFecHra.Controls.Add(Me.Label5)
        Me.GrBxFecHra.Controls.Add(Me.txtHraFinBloq)
        Me.GrBxFecHra.Controls.Add(Me.Label6)
        Me.GrBxFecHra.Controls.Add(Me.txtMotBloq)
        Me.GrBxFecHra.Controls.Add(Me.calFecBloq)
        Me.GrBxFecHra.Controls.Add(Me.Label4)
        Me.GrBxFecHra.Controls.Add(Me.Label3)
        Me.GrBxFecHra.Controls.Add(Me.txtHraIniBloq)
        Me.GrBxFecHra.Controls.Add(Me.dgvBloq)
        Me.GrBxFecHra.ForeColor = System.Drawing.Color.White
        Me.GrBxFecHra.Location = New System.Drawing.Point(22, 54)
        Me.GrBxFecHra.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.GrBxFecHra.Name = "GrBxFecHra"
        Me.GrBxFecHra.Padding = New System.Windows.Forms.Padding(9, 2, 4, 4)
        Me.GrBxFecHra.Size = New System.Drawing.Size(473, 446)
        Me.GrBxFecHra.TabIndex = 69
        Me.GrBxFecHra.TabStop = False
        '
        'txtFecIngBloq
        '
        Me.txtFecIngBloq.Location = New System.Drawing.Point(274, 98)
        Me.txtFecIngBloq.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtFecIngBloq.MaxLength = 7
        Me.txtFecIngBloq.Name = "txtFecIngBloq"
        Me.txtFecIngBloq.Size = New System.Drawing.Size(52, 20)
        Me.txtFecIngBloq.TabIndex = 39
        Me.txtFecIngBloq.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnLimBloq)
        Me.GroupBox2.Controls.Add(Me.btnGraBloq)
        Me.GroupBox2.Controls.Add(Me.btnEliBloq)
        Me.GroupBox2.Location = New System.Drawing.Point(377, 11)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(81, 164)
        Me.GroupBox2.TabIndex = 38
        Me.GroupBox2.TabStop = False
        '
        'btnLimBloq
        '
        Me.btnLimBloq.FlatAppearance.BorderSize = 0
        Me.btnLimBloq.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLimBloq.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_hojanueva
        Me.btnLimBloq.Location = New System.Drawing.Point(17, 61)
        Me.btnLimBloq.Name = "btnLimBloq"
        Me.btnLimBloq.Size = New System.Drawing.Size(46, 38)
        Me.btnLimBloq.TabIndex = 5
        Me.btnLimBloq.UseVisualStyleBackColor = True
        '
        'btnGraBloq
        '
        Me.btnGraBloq.FlatAppearance.BorderSize = 0
        Me.btnGraBloq.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGraBloq.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_guardar2
        Me.btnGraBloq.Location = New System.Drawing.Point(17, 14)
        Me.btnGraBloq.Name = "btnGraBloq"
        Me.btnGraBloq.Size = New System.Drawing.Size(46, 38)
        Me.btnGraBloq.TabIndex = 4
        Me.btnGraBloq.UseVisualStyleBackColor = True
        '
        'btnEliBloq
        '
        Me.btnEliBloq.FlatAppearance.BorderSize = 0
        Me.btnEliBloq.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEliBloq.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_hojamenos
        Me.btnEliBloq.Location = New System.Drawing.Point(17, 109)
        Me.btnEliBloq.Name = "btnEliBloq"
        Me.btnEliBloq.Size = New System.Drawing.Size(46, 41)
        Me.btnEliBloq.TabIndex = 5
        Me.btnEliBloq.UseVisualStyleBackColor = True
        '
        'txtIdBloq
        '
        Me.txtIdBloq.Location = New System.Drawing.Point(274, 46)
        Me.txtIdBloq.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtIdBloq.MaxLength = 7
        Me.txtIdBloq.Name = "txtIdBloq"
        Me.txtIdBloq.Size = New System.Drawing.Size(52, 20)
        Me.txtIdBloq.TabIndex = 37
        Me.txtIdBloq.Visible = False
        '
        'txtUsuCod
        '
        Me.txtUsuCod.Location = New System.Drawing.Point(274, 72)
        Me.txtUsuCod.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtUsuCod.MaxLength = 7
        Me.txtUsuCod.Name = "txtUsuCod"
        Me.txtUsuCod.Size = New System.Drawing.Size(52, 20)
        Me.txtUsuCod.TabIndex = 36
        Me.txtUsuCod.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(20, 75)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(85, 13)
        Me.Label5.TabIndex = 35
        Me.Label5.Text = "Hora Termino"
        '
        'txtHraFinBloq
        '
        Me.txtHraFinBloq.Location = New System.Drawing.Point(142, 72)
        Me.txtHraFinBloq.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtHraFinBloq.MaxLength = 7
        Me.txtHraFinBloq.Name = "txtHraFinBloq"
        Me.txtHraFinBloq.Size = New System.Drawing.Size(52, 20)
        Me.txtHraFinBloq.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(20, 101)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(44, 13)
        Me.Label6.TabIndex = 31
        Me.Label6.Text = "Motivo"
        '
        'txtMotBloq
        '
        Me.txtMotBloq.Location = New System.Drawing.Point(142, 98)
        Me.txtMotBloq.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtMotBloq.MaxLength = 7
        Me.txtMotBloq.Name = "txtMotBloq"
        Me.txtMotBloq.Size = New System.Drawing.Size(115, 20)
        Me.txtMotBloq.TabIndex = 3
        '
        'calFecBloq
        '
        Me.calFecBloq.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.calFecBloq.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.calFecBloq.Location = New System.Drawing.Point(142, 18)
        Me.calFecBloq.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.calFecBloq.Name = "calFecBloq"
        Me.calFecBloq.Size = New System.Drawing.Size(138, 22)
        Me.calFecBloq.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(20, 25)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 13)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "Fecha"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(20, 49)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Hora Inicio"
        '
        'txtHraIniBloq
        '
        Me.txtHraIniBloq.Location = New System.Drawing.Point(142, 46)
        Me.txtHraIniBloq.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtHraIniBloq.MaxLength = 7
        Me.txtHraIniBloq.Name = "txtHraIniBloq"
        Me.txtHraIniBloq.Size = New System.Drawing.Size(52, 20)
        Me.txtHraIniBloq.TabIndex = 1
        '
        'dgvBloq
        '
        Me.dgvBloq.AllowUserToAddRows = False
        Me.dgvBloq.AllowUserToDeleteRows = False
        Me.dgvBloq.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBloq.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdRestriccion, Me.IdUsuario, Me.FechaRestriccion, Me.HoraInicio, Me.HoraTermino, Me.Motivo, Me.FechaIngreso})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvBloq.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgvBloq.Location = New System.Drawing.Point(14, 203)
        Me.dgvBloq.Name = "dgvBloq"
        Me.dgvBloq.ReadOnly = True
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        Me.dgvBloq.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvBloq.Size = New System.Drawing.Size(444, 236)
        Me.dgvBloq.TabIndex = 6
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.txtFecIngRes)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.dgvRes)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.cboTipCar)
        Me.GroupBox1.Controls.Add(Me.txtIdRes)
        Me.GroupBox1.Controls.Add(Me.txtUsuRes)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtHraLimRes)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtHraTerRes)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtHraIniRes)
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(531, 54)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(9, 2, 4, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(483, 446)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        '
        'txtFecIngRes
        '
        Me.txtFecIngRes.Location = New System.Drawing.Point(278, 98)
        Me.txtFecIngRes.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtFecIngRes.MaxLength = 7
        Me.txtFecIngRes.Name = "txtFecIngRes"
        Me.txtFecIngRes.Size = New System.Drawing.Size(52, 20)
        Me.txtFecIngRes.TabIndex = 40
        Me.txtFecIngRes.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnLimRes)
        Me.GroupBox3.Controls.Add(Me.btnGraRes)
        Me.GroupBox3.Controls.Add(Me.btnEliRes)
        Me.GroupBox3.Location = New System.Drawing.Point(383, 18)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(81, 164)
        Me.GroupBox3.TabIndex = 39
        Me.GroupBox3.TabStop = False
        '
        'btnLimRes
        '
        Me.btnLimRes.FlatAppearance.BorderSize = 0
        Me.btnLimRes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLimRes.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_hojanueva
        Me.btnLimRes.Location = New System.Drawing.Point(17, 62)
        Me.btnLimRes.Name = "btnLimRes"
        Me.btnLimRes.Size = New System.Drawing.Size(46, 38)
        Me.btnLimRes.TabIndex = 12
        Me.btnLimRes.UseVisualStyleBackColor = True
        '
        'btnGraRes
        '
        Me.btnGraRes.FlatAppearance.BorderSize = 0
        Me.btnGraRes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGraRes.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_guardar2
        Me.btnGraRes.Location = New System.Drawing.Point(17, 18)
        Me.btnGraRes.Name = "btnGraRes"
        Me.btnGraRes.Size = New System.Drawing.Size(46, 38)
        Me.btnGraRes.TabIndex = 11
        Me.btnGraRes.UseVisualStyleBackColor = True
        '
        'btnEliRes
        '
        Me.btnEliRes.FlatAppearance.BorderSize = 0
        Me.btnEliRes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEliRes.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_hojamenos
        Me.btnEliRes.Location = New System.Drawing.Point(17, 106)
        Me.btnEliRes.Name = "btnEliRes"
        Me.btnEliRes.Size = New System.Drawing.Size(46, 41)
        Me.btnEliRes.TabIndex = 12
        Me.btnEliRes.UseVisualStyleBackColor = True
        '
        'dgvRes
        '
        Me.dgvRes.AllowUserToAddRows = False
        Me.dgvRes.AllowUserToDeleteRows = False
        Me.dgvRes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdRestriccionService, Me.IdUsu, Me.IdTipoCarga, Me.TipoCarga, Me.HraIni, Me.HraFin, Me.HraLim, Me.FechaIngresoRes})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvRes.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvRes.Location = New System.Drawing.Point(21, 203)
        Me.dgvRes.Name = "dgvRes"
        Me.dgvRes.ReadOnly = True
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        Me.dgvRes.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvRes.Size = New System.Drawing.Size(443, 236)
        Me.dgvRes.TabIndex = 13
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(24, 25)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(70, 13)
        Me.Label11.TabIndex = 41
        Me.Label11.Text = "Tipo Carga"
        '
        'cboTipCar
        '
        Me.cboTipCar.BackColor = System.Drawing.Color.White
        Me.cboTipCar.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipCar.FormattingEnabled = True
        Me.cboTipCar.Location = New System.Drawing.Point(145, 22)
        Me.cboTipCar.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.cboTipCar.Name = "cboTipCar"
        Me.cboTipCar.Size = New System.Drawing.Size(115, 21)
        Me.cboTipCar.TabIndex = 7
        '
        'txtIdRes
        '
        Me.txtIdRes.Location = New System.Drawing.Point(278, 46)
        Me.txtIdRes.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtIdRes.MaxLength = 7
        Me.txtIdRes.Name = "txtIdRes"
        Me.txtIdRes.Size = New System.Drawing.Size(52, 20)
        Me.txtIdRes.TabIndex = 39
        Me.txtIdRes.Visible = False
        '
        'txtUsuRes
        '
        Me.txtUsuRes.Location = New System.Drawing.Point(278, 72)
        Me.txtUsuRes.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtUsuRes.MaxLength = 7
        Me.txtUsuRes.Name = "txtUsuRes"
        Me.txtUsuRes.Size = New System.Drawing.Size(52, 20)
        Me.txtUsuRes.TabIndex = 38
        Me.txtUsuRes.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(24, 104)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 13)
        Me.Label7.TabIndex = 37
        Me.Label7.Text = "Hora Limite"
        '
        'txtHraLimRes
        '
        Me.txtHraLimRes.Location = New System.Drawing.Point(145, 101)
        Me.txtHraLimRes.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtHraLimRes.MaxLength = 7
        Me.txtHraLimRes.Name = "txtHraLimRes"
        Me.txtHraLimRes.Size = New System.Drawing.Size(52, 20)
        Me.txtHraLimRes.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(24, 78)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 13)
        Me.Label2.TabIndex = 35
        Me.Label2.Text = "Hora Termino"
        '
        'txtHraTerRes
        '
        Me.txtHraTerRes.Location = New System.Drawing.Point(145, 75)
        Me.txtHraTerRes.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtHraTerRes.MaxLength = 7
        Me.txtHraTerRes.Name = "txtHraTerRes"
        Me.txtHraTerRes.Size = New System.Drawing.Size(52, 20)
        Me.txtHraTerRes.TabIndex = 9
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(24, 52)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(69, 13)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "Hora Inicio"
        '
        'txtHraIniRes
        '
        Me.txtHraIniRes.Location = New System.Drawing.Point(145, 49)
        Me.txtHraIniRes.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtHraIniRes.MaxLength = 7
        Me.txtHraIniRes.Name = "txtHraIniRes"
        Me.txtHraIniRes.Size = New System.Drawing.Size(52, 20)
        Me.txtHraIniRes.TabIndex = 8
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(531, 29)
        Me.Label10.Name = "Label10"
        Me.Label10.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.Label10.Size = New System.Drawing.Size(483, 22)
        Me.Label10.TabIndex = 70
        Me.Label10.Text = "Reservas Precisa Services"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "IdRestriccion"
        Me.DataGridViewTextBoxColumn1.HeaderText = "IdRestriccion"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "IdUsuario"
        Me.DataGridViewTextBoxColumn2.HeaderText = "IdUsuario"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Visible = False
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "FechaRestriccion"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Fecha"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "HoraInicio"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Hora Inicio"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "HoraTermino"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Hora Termino"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "Motivo"
        Me.DataGridViewTextBoxColumn6.HeaderText = "Motivo"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "IdRestriccionService"
        Me.DataGridViewTextBoxColumn7.HeaderText = "IdRestriccionService"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Visible = False
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "IdUsuario"
        Me.DataGridViewTextBoxColumn8.HeaderText = "IdUsu"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Visible = False
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "TipoCarga"
        Me.DataGridViewTextBoxColumn9.HeaderText = "IdTipoCarga"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        Me.DataGridViewTextBoxColumn9.Visible = False
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "TipoCargaDescr"
        Me.DataGridViewTextBoxColumn10.HeaderText = "Tipo Carga"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        Me.DataGridViewTextBoxColumn10.Visible = False
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "HoraInicio"
        Me.DataGridViewTextBoxColumn11.HeaderText = "Hora Inicio"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "HoraTermino"
        Me.DataGridViewTextBoxColumn12.HeaderText = "Hora Termino"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.ReadOnly = True
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.DataPropertyName = "HoraLimite"
        Me.DataGridViewTextBoxColumn13.HeaderText = "Hora Limite"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.ReadOnly = True
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.DataPropertyName = "HoraLimite"
        Me.DataGridViewTextBoxColumn14.HeaderText = "Hora Limite"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.ReadOnly = True
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.DataPropertyName = "FechaIngresoRes"
        Me.DataGridViewTextBoxColumn15.HeaderText = "Fecha Ingreso"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        Me.DataGridViewTextBoxColumn15.Visible = False
        '
        'IdRestriccionService
        '
        Me.IdRestriccionService.DataPropertyName = "IdRestriccionRes"
        Me.IdRestriccionService.HeaderText = "IdRestriccionService"
        Me.IdRestriccionService.Name = "IdRestriccionService"
        Me.IdRestriccionService.ReadOnly = True
        Me.IdRestriccionService.Visible = False
        '
        'IdUsu
        '
        Me.IdUsu.DataPropertyName = "IdUsuarioRes"
        Me.IdUsu.HeaderText = "IdUsu"
        Me.IdUsu.Name = "IdUsu"
        Me.IdUsu.ReadOnly = True
        Me.IdUsu.Visible = False
        '
        'IdTipoCarga
        '
        Me.IdTipoCarga.DataPropertyName = "IdTipoCargaRes"
        Me.IdTipoCarga.HeaderText = "IdTipoCarga"
        Me.IdTipoCarga.Name = "IdTipoCarga"
        Me.IdTipoCarga.ReadOnly = True
        Me.IdTipoCarga.Visible = False
        '
        'TipoCarga
        '
        Me.TipoCarga.DataPropertyName = "TipoCargaRes"
        Me.TipoCarga.HeaderText = "Tipo Carga"
        Me.TipoCarga.Name = "TipoCarga"
        Me.TipoCarga.ReadOnly = True
        '
        'HraIni
        '
        Me.HraIni.DataPropertyName = "HoraInicioRes"
        Me.HraIni.HeaderText = "Hora Inicio"
        Me.HraIni.Name = "HraIni"
        Me.HraIni.ReadOnly = True
        '
        'HraFin
        '
        Me.HraFin.DataPropertyName = "HoraTerminoRes"
        Me.HraFin.HeaderText = "Hora Termino"
        Me.HraFin.Name = "HraFin"
        Me.HraFin.ReadOnly = True
        '
        'HraLim
        '
        Me.HraLim.DataPropertyName = "HoraLimiteRes"
        Me.HraLim.HeaderText = "Hora Limite"
        Me.HraLim.Name = "HraLim"
        Me.HraLim.ReadOnly = True
        '
        'FechaIngresoRes
        '
        Me.FechaIngresoRes.DataPropertyName = "FechaIngresoRes"
        Me.FechaIngresoRes.HeaderText = "Fecha Ingreso"
        Me.FechaIngresoRes.Name = "FechaIngresoRes"
        Me.FechaIngresoRes.ReadOnly = True
        Me.FechaIngresoRes.Visible = False
        '
        'IdRestriccion
        '
        Me.IdRestriccion.DataPropertyName = "IdRestriccionBloq"
        Me.IdRestriccion.HeaderText = "IdRestriccion"
        Me.IdRestriccion.Name = "IdRestriccion"
        Me.IdRestriccion.ReadOnly = True
        Me.IdRestriccion.Visible = False
        '
        'IdUsuario
        '
        Me.IdUsuario.DataPropertyName = "IdUsuarioBloq"
        Me.IdUsuario.HeaderText = "IdUsuario"
        Me.IdUsuario.Name = "IdUsuario"
        Me.IdUsuario.ReadOnly = True
        Me.IdUsuario.Visible = False
        '
        'FechaRestriccion
        '
        Me.FechaRestriccion.DataPropertyName = "FechaRestriccionBloq"
        Me.FechaRestriccion.HeaderText = "Fecha"
        Me.FechaRestriccion.Name = "FechaRestriccion"
        Me.FechaRestriccion.ReadOnly = True
        '
        'HoraInicio
        '
        Me.HoraInicio.DataPropertyName = "HoraInicioBloq"
        Me.HoraInicio.HeaderText = "Hora Inicio"
        Me.HoraInicio.Name = "HoraInicio"
        Me.HoraInicio.ReadOnly = True
        '
        'HoraTermino
        '
        Me.HoraTermino.DataPropertyName = "HoraTerminoBloq"
        Me.HoraTermino.HeaderText = "Hora Termino"
        Me.HoraTermino.Name = "HoraTermino"
        Me.HoraTermino.ReadOnly = True
        '
        'Motivo
        '
        Me.Motivo.DataPropertyName = "MotivoBloq"
        Me.Motivo.HeaderText = "Motivo"
        Me.Motivo.Name = "Motivo"
        Me.Motivo.ReadOnly = True
        '
        'FechaIngreso
        '
        Me.FechaIngreso.DataPropertyName = "FechaIngresoBloq"
        Me.FechaIngreso.HeaderText = "FechaIngreso"
        Me.FechaIngreso.Name = "FechaIngreso"
        Me.FechaIngreso.ReadOnly = True
        Me.FechaIngreso.Visible = False
        '
        'Frm_PedidosBloqueoDias
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(1036, 521)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.GrBxFecHra)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Frm_PedidosBloqueoDias"
        Me.Text = "Bloqueos programación pedidos"
        Me.GrBxFecHra.ResumeLayout(False)
        Me.GrBxFecHra.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgvBloq, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.dgvRes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GrBxFecHra As System.Windows.Forms.GroupBox
    Friend WithEvents dgvBloq As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtHraIniBloq As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtMotBloq As System.Windows.Forms.TextBox
    Friend WithEvents calFecBloq As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtHraFinBloq As System.Windows.Forms.TextBox
    Friend WithEvents btnGraBloq As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtHraTerRes As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtHraIniRes As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtHraLimRes As System.Windows.Forms.TextBox
    Friend WithEvents txtIdBloq As System.Windows.Forms.TextBox
    Friend WithEvents txtUsuCod As System.Windows.Forms.TextBox
    Friend WithEvents txtIdRes As System.Windows.Forms.TextBox
    Friend WithEvents txtUsuRes As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cboTipCar As System.Windows.Forms.ComboBox
    Friend WithEvents btnEliBloq As System.Windows.Forms.Button
    Friend WithEvents dgvRes As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnGraRes As System.Windows.Forms.Button
    Friend WithEvents btnEliRes As System.Windows.Forms.Button
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
    Friend WithEvents txtFecIngBloq As System.Windows.Forms.TextBox
    Friend WithEvents txtFecIngRes As System.Windows.Forms.TextBox
    Friend WithEvents IdRestriccion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdUsuario As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaRestriccion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HoraInicio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HoraTermino As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Motivo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaIngreso As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdRestriccionService As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdUsu As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdTipoCarga As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TipoCarga As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HraIni As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HraFin As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HraLim As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaIngresoRes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnLimBloq As System.Windows.Forms.Button
    Friend WithEvents btnLimRes As System.Windows.Forms.Button
    Friend WithEvents DataGridViewTextBoxColumn15 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

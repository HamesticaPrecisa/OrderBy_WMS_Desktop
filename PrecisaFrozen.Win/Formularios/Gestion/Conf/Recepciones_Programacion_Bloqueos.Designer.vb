<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Recepciones_Programacion_Bloqueos
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
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.btnGra = New System.Windows.Forms.Button()
        Me.btnSal = New System.Windows.Forms.Button()
        Me.btnLim = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.txtFecFin = New System.Windows.Forms.DateTimePicker()
        Me.txtFecIni = New System.Windows.Forms.DateTimePicker()
        Me.chkLimFec = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtHraFin = New System.Windows.Forms.TextBox()
        Me.txtHraIni = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboTipDia = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.gvBloq = New System.Windows.Forms.DataGridView()
        Me.btnCli = New System.Windows.Forms.DataGridViewImageColumn()
        Me.btnDes = New System.Windows.Forms.DataGridViewImageColumn()
        Me.btnEli = New System.Windows.Forms.DataGridViewImageColumn()
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
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tipo_Dia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tipo_Dia_Frm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Hora_Inicio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Hora_Fin = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha_Inicio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha_Inicio_Frm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha_Fin = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha_Fin_Frm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Estado_Frm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Motivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.gvBloq, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.btnGra)
        Me.GroupBox4.Controls.Add(Me.btnSal)
        Me.GroupBox4.Controls.Add(Me.btnLim)
        Me.GroupBox4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(334, 12)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(75, 281)
        Me.GroupBox4.TabIndex = 61
        Me.GroupBox4.TabStop = False
        '
        'btnGra
        '
        Me.btnGra.FlatAppearance.BorderSize = 0
        Me.btnGra.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGra.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_guardar2
        Me.btnGra.Location = New System.Drawing.Point(6, 19)
        Me.btnGra.Name = "btnGra"
        Me.btnGra.Size = New System.Drawing.Size(63, 63)
        Me.btnGra.TabIndex = 6
        Me.btnGra.UseVisualStyleBackColor = True
        '
        'btnSal
        '
        Me.btnSal.FlatAppearance.BorderSize = 0
        Me.btnSal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSal.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_salida
        Me.btnSal.Location = New System.Drawing.Point(6, 157)
        Me.btnSal.Name = "btnSal"
        Me.btnSal.Size = New System.Drawing.Size(63, 61)
        Me.btnSal.TabIndex = 8
        Me.btnSal.UseVisualStyleBackColor = True
        '
        'btnLim
        '
        Me.btnLim.FlatAppearance.BorderSize = 0
        Me.btnLim.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLim.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_hojanueva
        Me.btnLim.Location = New System.Drawing.Point(6, 88)
        Me.btnLim.Name = "btnLim"
        Me.btnLim.Size = New System.Drawing.Size(63, 63)
        Me.btnLim.TabIndex = 7
        Me.btnLim.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtID)
        Me.GroupBox1.Controls.Add(Me.txtFecFin)
        Me.GroupBox1.Controls.Add(Me.txtFecIni)
        Me.GroupBox1.Controls.Add(Me.chkLimFec)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtHraFin)
        Me.GroupBox1.Controls.Add(Me.txtHraIni)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cboTipDia)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label35)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(316, 281)
        Me.GroupBox1.TabIndex = 60
        Me.GroupBox1.TabStop = False
        '
        'txtID
        '
        Me.txtID.Location = New System.Drawing.Point(173, 165)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(100, 20)
        Me.txtID.TabIndex = 85
        Me.txtID.Visible = False
        '
        'txtFecFin
        '
        Me.txtFecFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtFecFin.Location = New System.Drawing.Point(152, 236)
        Me.txtFecFin.Name = "txtFecFin"
        Me.txtFecFin.Size = New System.Drawing.Size(108, 20)
        Me.txtFecFin.TabIndex = 5
        '
        'txtFecIni
        '
        Me.txtFecIni.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtFecIni.Location = New System.Drawing.Point(152, 199)
        Me.txtFecIni.Name = "txtFecIni"
        Me.txtFecIni.Size = New System.Drawing.Size(108, 20)
        Me.txtFecIni.TabIndex = 4
        '
        'chkLimFec
        '
        Me.chkLimFec.AutoSize = True
        Me.chkLimFec.Location = New System.Drawing.Point(152, 168)
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
        Me.Label6.Location = New System.Drawing.Point(7, 168)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(118, 13)
        Me.Label6.TabIndex = 84
        Me.Label6.Text = "LÍMITAR FECHAS : "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(7, 242)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(115, 13)
        Me.Label4.TabIndex = 83
        Me.Label4.Text = "FECHA TÉRMINO : "
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(7, 205)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(103, 13)
        Me.Label5.TabIndex = 82
        Me.Label5.Text = "FECHA INICIO : "
        '
        'txtHraFin
        '
        Me.txtHraFin.Location = New System.Drawing.Point(152, 128)
        Me.txtHraFin.Name = "txtHraFin"
        Me.txtHraFin.Size = New System.Drawing.Size(108, 20)
        Me.txtHraFin.TabIndex = 2
        '
        'txtHraIni
        '
        Me.txtHraIni.Location = New System.Drawing.Point(152, 91)
        Me.txtHraIni.Name = "txtHraIni"
        Me.txtHraIni.Size = New System.Drawing.Size(108, 20)
        Me.txtHraIni.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(7, 131)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(110, 13)
        Me.Label3.TabIndex = 79
        Me.Label3.Text = "HORA TÉRMINO : "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(7, 94)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 13)
        Me.Label1.TabIndex = 78
        Me.Label1.Text = "HORA INICIO : "
        '
        'cboTipDia
        '
        Me.cboTipDia.FormattingEnabled = True
        Me.cboTipDia.Location = New System.Drawing.Point(152, 54)
        Me.cboTipDia.Name = "cboTipDia"
        Me.cboTipDia.Size = New System.Drawing.Size(108, 21)
        Me.cboTipDia.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(7, 57)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 13)
        Me.Label2.TabIndex = 76
        Me.Label2.Text = "TIPO DÍA : "
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.BackColor = System.Drawing.Color.Transparent
        Me.Label35.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.ForeColor = System.Drawing.Color.White
        Me.Label35.Location = New System.Drawing.Point(6, 16)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(275, 14)
        Me.Label35.TabIndex = 71
        Me.Label35.Text = "CONFIGURACIÓN BLOQUEOS HORARIO"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.gvBloq)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 299)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(997, 423)
        Me.GroupBox2.TabIndex = 62
        Me.GroupBox2.TabStop = False
        '
        'gvBloq
        '
        Me.gvBloq.AllowUserToAddRows = False
        Me.gvBloq.AllowUserToDeleteRows = False
        Me.gvBloq.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvBloq.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.Tipo_Dia, Me.Tipo_Dia_Frm, Me.Hora_Inicio, Me.Hora_Fin, Me.Fecha_Inicio, Me.Fecha_Inicio_Frm, Me.Fecha_Fin, Me.Fecha_Fin_Frm, Me.btnCli, Me.Estado, Me.Estado_Frm, Me.btnDes, Me.btnEli, Me.Motivo})
        Me.gvBloq.Location = New System.Drawing.Point(6, 12)
        Me.gvBloq.Name = "gvBloq"
        Me.gvBloq.ReadOnly = True
        Me.gvBloq.Size = New System.Drawing.Size(985, 405)
        Me.gvBloq.TabIndex = 0
        '
        'btnCli
        '
        Me.btnCli.Frozen = True
        Me.btnCli.HeaderText = "CLIENTES"
        Me.btnCli.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.Cliente
        Me.btnCli.Name = "btnCli"
        Me.btnCli.ReadOnly = True
        '
        'btnDes
        '
        Me.btnDes.Frozen = True
        Me.btnDes.HeaderText = "CAMB. ESTADO"
        Me.btnDes.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.Modificar_16
        Me.btnDes.Name = "btnDes"
        Me.btnDes.ReadOnly = True
        '
        'btnEli
        '
        Me.btnEli.Frozen = True
        Me.btnEli.HeaderText = "ELIMINAR"
        Me.btnEli.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.button_cancel
        Me.btnEli.Name = "btnEli"
        Me.btnEli.ReadOnly = True
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
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Tipo_Dia"
        Me.DataGridViewTextBoxColumn2.Frozen = True
        Me.DataGridViewTextBoxColumn2.HeaderText = "TIPO DIA"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Visible = False
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "Tipo_Dia_Frm"
        Me.DataGridViewTextBoxColumn3.Frozen = True
        Me.DataGridViewTextBoxColumn3.HeaderText = "TIPO DÍA"
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
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "Hora_Fin"
        Me.DataGridViewTextBoxColumn5.Frozen = True
        Me.DataGridViewTextBoxColumn5.HeaderText = "HORA TÉRMINO"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "Fecha_Inicio"
        Me.DataGridViewTextBoxColumn6.Frozen = True
        Me.DataGridViewTextBoxColumn6.HeaderText = "FECHA INICIO"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Visible = False
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "Fecha_Inicio_Frm"
        Me.DataGridViewTextBoxColumn7.Frozen = True
        Me.DataGridViewTextBoxColumn7.HeaderText = "FECHA INICIO"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "Fecha_Fin"
        Me.DataGridViewTextBoxColumn8.Frozen = True
        Me.DataGridViewTextBoxColumn8.HeaderText = "FECHA TÉRMINO"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Visible = False
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "Fecha_Fin_Frm"
        Me.DataGridViewTextBoxColumn9.Frozen = True
        Me.DataGridViewTextBoxColumn9.HeaderText = "FECHA TÉRMINO"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "Estado"
        Me.DataGridViewTextBoxColumn10.Frozen = True
        Me.DataGridViewTextBoxColumn10.HeaderText = "ESTADO"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        Me.DataGridViewTextBoxColumn10.Visible = False
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "Estado_Frm"
        Me.DataGridViewTextBoxColumn11.Frozen = True
        Me.DataGridViewTextBoxColumn11.HeaderText = "ESTADO"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "Motivo"
        Me.DataGridViewTextBoxColumn12.Frozen = True
        Me.DataGridViewTextBoxColumn12.HeaderText = "MOTIVO"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.ReadOnly = True
        Me.DataGridViewTextBoxColumn12.Visible = False
        '
        'ID
        '
        Me.ID.DataPropertyName = "ID"
        Me.ID.Frozen = True
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        Me.ID.Visible = False
        '
        'Tipo_Dia
        '
        Me.Tipo_Dia.DataPropertyName = "Tipo_Dia"
        Me.Tipo_Dia.Frozen = True
        Me.Tipo_Dia.HeaderText = "TIPO DIA"
        Me.Tipo_Dia.Name = "Tipo_Dia"
        Me.Tipo_Dia.ReadOnly = True
        Me.Tipo_Dia.Visible = False
        '
        'Tipo_Dia_Frm
        '
        Me.Tipo_Dia_Frm.DataPropertyName = "Tipo_Dia_Frm"
        Me.Tipo_Dia_Frm.Frozen = True
        Me.Tipo_Dia_Frm.HeaderText = "TIPO DÍA"
        Me.Tipo_Dia_Frm.Name = "Tipo_Dia_Frm"
        Me.Tipo_Dia_Frm.ReadOnly = True
        '
        'Hora_Inicio
        '
        Me.Hora_Inicio.DataPropertyName = "Hora_Inicio"
        Me.Hora_Inicio.Frozen = True
        Me.Hora_Inicio.HeaderText = "HORA INICIO"
        Me.Hora_Inicio.Name = "Hora_Inicio"
        Me.Hora_Inicio.ReadOnly = True
        '
        'Hora_Fin
        '
        Me.Hora_Fin.DataPropertyName = "Hora_Fin"
        Me.Hora_Fin.Frozen = True
        Me.Hora_Fin.HeaderText = "HORA TÉRMINO"
        Me.Hora_Fin.Name = "Hora_Fin"
        Me.Hora_Fin.ReadOnly = True
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
        'Fecha_Fin
        '
        Me.Fecha_Fin.DataPropertyName = "Fecha_Fin"
        Me.Fecha_Fin.Frozen = True
        Me.Fecha_Fin.HeaderText = "FECHA TÉRMINO"
        Me.Fecha_Fin.Name = "Fecha_Fin"
        Me.Fecha_Fin.ReadOnly = True
        Me.Fecha_Fin.Visible = False
        '
        'Fecha_Fin_Frm
        '
        Me.Fecha_Fin_Frm.DataPropertyName = "Fecha_Fin_Frm"
        Me.Fecha_Fin_Frm.Frozen = True
        Me.Fecha_Fin_Frm.HeaderText = "FECHA TÉRMINO"
        Me.Fecha_Fin_Frm.Name = "Fecha_Fin_Frm"
        Me.Fecha_Fin_Frm.ReadOnly = True
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
        'Motivo
        '
        Me.Motivo.DataPropertyName = "Motivo"
        Me.Motivo.Frozen = True
        Me.Motivo.HeaderText = "MOTIVO"
        Me.Motivo.Name = "Motivo"
        Me.Motivo.ReadOnly = True
        Me.Motivo.Visible = False
        '
        'Recepciones_Programacion_Bloqueos
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(1021, 734)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Recepciones_Programacion_Bloqueos"
        Me.Text = "Recepciones_Programacion_Bloqueos"
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.gvBloq, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btnGra As System.Windows.Forms.Button
    Friend WithEvents btnSal As System.Windows.Forms.Button
    Friend WithEvents btnLim As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtHraFin As System.Windows.Forms.TextBox
    Friend WithEvents txtHraIni As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents chkLimFec As System.Windows.Forms.CheckBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboTipDia As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtFecFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtFecIni As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents gvBloq As System.Windows.Forms.DataGridView
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
    Friend WithEvents txtID As System.Windows.Forms.TextBox
    Friend WithEvents ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tipo_Dia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tipo_Dia_Frm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Hora_Inicio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Hora_Fin As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha_Inicio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha_Inicio_Frm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha_Fin As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha_Fin_Frm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnCli As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents Estado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Estado_Frm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnDes As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents btnEli As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents Motivo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

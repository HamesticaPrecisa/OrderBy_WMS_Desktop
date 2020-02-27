<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LimiteFechaExportacionPedidos
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Checkhora = New System.Windows.Forms.CheckBox()
        Me.btnGrahor = New System.Windows.Forms.Button()
        Me.txthoralim = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btn_limpiar = New System.Windows.Forms.Button()
        Me.txtcodigo = New System.Windows.Forms.TextBox()
        Me.btnlst = New System.Windows.Forms.Button()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.fecha = New System.Windows.Forms.DateTimePicker()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtlimite = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cantidadlimit = New System.Windows.Forms.TextBox()
        Me.txtidfechalimit = New System.Windows.Forms.TextBox()
        Me.btnfechas = New System.Windows.Forms.Button()
        Me.fechalimit = New System.Windows.Forms.TextBox()
        Me.BtnClientes = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.txtidcliente = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.cliente = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.DgvLimiteClientes = New System.Windows.Forms.DataGridView()
        Me.ELIM = New System.Windows.Forms.DataGridViewImageColumn()
        Me.RUT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PERSONAL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Rut_Cliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.DgvLimiteClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Checkhora)
        Me.GroupBox1.Controls.Add(Me.btnGrahor)
        Me.GroupBox1.Controls.Add(Me.txthoralim)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(40, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(438, 89)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "HORA LÍMITE"
        '
        'Checkhora
        '
        Me.Checkhora.AutoSize = True
        Me.Checkhora.Location = New System.Drawing.Point(247, 27)
        Me.Checkhora.Name = "Checkhora"
        Me.Checkhora.Size = New System.Drawing.Size(64, 17)
        Me.Checkhora.TabIndex = 55
        Me.Checkhora.Text = "Cambiar"
        Me.Checkhora.UseVisualStyleBackColor = True
        '
        'btnGrahor
        '
        Me.btnGrahor.FlatAppearance.BorderSize = 0
        Me.btnGrahor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGrahor.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_guardar2
        Me.btnGrahor.Location = New System.Drawing.Point(345, 10)
        Me.btnGrahor.Name = "btnGrahor"
        Me.btnGrahor.Size = New System.Drawing.Size(68, 57)
        Me.btnGrahor.TabIndex = 54
        Me.btnGrahor.UseVisualStyleBackColor = True
        '
        'txthoralim
        '
        Me.txthoralim.Enabled = False
        Me.txthoralim.Location = New System.Drawing.Point(120, 24)
        Me.txthoralim.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txthoralim.MaxLength = 8
        Me.txthoralim.Name = "txthoralim"
        Me.txthoralim.Size = New System.Drawing.Size(106, 20)
        Me.txthoralim.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(60, 23)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(130, 21)
        Me.Label2.TabIndex = 53
        Me.Label2.Text = "HORA"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btn_limpiar)
        Me.GroupBox2.Controls.Add(Me.txtcodigo)
        Me.GroupBox2.Controls.Add(Me.btnlst)
        Me.GroupBox2.Controls.Add(Me.Label20)
        Me.GroupBox2.Controls.Add(Me.fecha)
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Controls.Add(Me.txtlimite)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.ForeColor = System.Drawing.Color.White
        Me.GroupBox2.Location = New System.Drawing.Point(40, 119)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(438, 174)
        Me.GroupBox2.TabIndex = 56
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "INGRESAR LIMITE EN FECHA"
        '
        'btn_limpiar
        '
        Me.btn_limpiar.FlatAppearance.BorderSize = 0
        Me.btn_limpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_limpiar.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_hojanueva
        Me.btn_limpiar.Location = New System.Drawing.Point(360, 92)
        Me.btn_limpiar.Name = "btn_limpiar"
        Me.btn_limpiar.Size = New System.Drawing.Size(63, 63)
        Me.btn_limpiar.TabIndex = 57
        Me.btn_limpiar.UseVisualStyleBackColor = True
        '
        'txtcodigo
        '
        Me.txtcodigo.Location = New System.Drawing.Point(232, 20)
        Me.txtcodigo.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtcodigo.MaxLength = 1
        Me.txtcodigo.Name = "txtcodigo"
        Me.txtcodigo.Size = New System.Drawing.Size(106, 20)
        Me.txtcodigo.TabIndex = 69
        Me.txtcodigo.Visible = False
        '
        'btnlst
        '
        Me.btnlst.ForeColor = System.Drawing.Color.Black
        Me.btnlst.Location = New System.Drawing.Point(122, 132)
        Me.btnlst.Name = "btnlst"
        Me.btnlst.Size = New System.Drawing.Size(189, 23)
        Me.btnlst.TabIndex = 68
        Me.btnlst.Text = "Listado de Limites"
        Me.btnlst.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.ForeColor = System.Drawing.Color.White
        Me.Label20.Location = New System.Drawing.Point(60, 100)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(42, 13)
        Me.Label20.TabIndex = 67
        Me.Label20.Text = "FECHA"
        '
        'fecha
        '
        Me.fecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.fecha.Location = New System.Drawing.Point(232, 94)
        Me.fecha.Name = "fecha"
        Me.fecha.Size = New System.Drawing.Size(103, 20)
        Me.fecha.TabIndex = 66
        '
        'Button1
        '
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_guardar2
        Me.Button1.Location = New System.Drawing.Point(360, 22)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(68, 57)
        Me.Button1.TabIndex = 54
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtlimite
        '
        Me.txtlimite.Location = New System.Drawing.Point(232, 46)
        Me.txtlimite.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtlimite.MaxLength = 1
        Me.txtlimite.Name = "txtlimite"
        Me.txtlimite.Size = New System.Drawing.Size(106, 20)
        Me.txtlimite.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(60, 40)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(130, 21)
        Me.Label1.TabIndex = 53
        Me.Label1.Text = "CANTIDAD LIMITE"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Button3)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.cantidadlimit)
        Me.GroupBox3.Controls.Add(Me.txtidfechalimit)
        Me.GroupBox3.Controls.Add(Me.btnfechas)
        Me.GroupBox3.Controls.Add(Me.fechalimit)
        Me.GroupBox3.Controls.Add(Me.BtnClientes)
        Me.GroupBox3.Controls.Add(Me.Button2)
        Me.GroupBox3.Controls.Add(Me.txtidcliente)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.Button4)
        Me.GroupBox3.Controls.Add(Me.cliente)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.ForeColor = System.Drawing.Color.White
        Me.GroupBox3.Location = New System.Drawing.Point(40, 324)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(438, 217)
        Me.GroupBox3.TabIndex = 57
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "INGRESAR LIMITE FECHA A CLIENTES"
        '
        'Button3
        '
        Me.Button3.ForeColor = System.Drawing.Color.Black
        Me.Button3.Location = New System.Drawing.Point(369, 19)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(54, 43)
        Me.Button3.TabIndex = 71
        Me.Button3.Text = "Info."
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(107, 131)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 13)
        Me.Label5.TabIndex = 75
        Me.Label5.Text = "LIMITE"
        '
        'cantidadlimit
        '
        Me.cantidadlimit.Enabled = False
        Me.cantidadlimit.Location = New System.Drawing.Point(192, 124)
        Me.cantidadlimit.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.cantidadlimit.MaxLength = 1
        Me.cantidadlimit.Name = "cantidadlimit"
        Me.cantidadlimit.Size = New System.Drawing.Size(106, 20)
        Me.cantidadlimit.TabIndex = 74
        '
        'txtidfechalimit
        '
        Me.txtidfechalimit.Enabled = False
        Me.txtidfechalimit.Location = New System.Drawing.Point(192, 72)
        Me.txtidfechalimit.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtidfechalimit.MaxLength = 1
        Me.txtidfechalimit.Name = "txtidfechalimit"
        Me.txtidfechalimit.Size = New System.Drawing.Size(106, 20)
        Me.txtidfechalimit.TabIndex = 73
        Me.txtidfechalimit.Visible = False
        '
        'btnfechas
        '
        Me.btnfechas.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.buscar_24
        Me.btnfechas.Location = New System.Drawing.Point(315, 95)
        Me.btnfechas.Name = "btnfechas"
        Me.btnfechas.Size = New System.Drawing.Size(23, 23)
        Me.btnfechas.TabIndex = 72
        Me.btnfechas.UseVisualStyleBackColor = True
        '
        'fechalimit
        '
        Me.fechalimit.Enabled = False
        Me.fechalimit.Location = New System.Drawing.Point(192, 98)
        Me.fechalimit.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.fechalimit.MaxLength = 1
        Me.fechalimit.Name = "fechalimit"
        Me.fechalimit.Size = New System.Drawing.Size(106, 20)
        Me.fechalimit.TabIndex = 71
        '
        'BtnClientes
        '
        Me.BtnClientes.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.buscar_24
        Me.BtnClientes.Location = New System.Drawing.Point(315, 44)
        Me.BtnClientes.Name = "BtnClientes"
        Me.BtnClientes.Size = New System.Drawing.Size(23, 23)
        Me.BtnClientes.TabIndex = 70
        Me.BtnClientes.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_hojanueva
        Me.Button2.Location = New System.Drawing.Point(360, 131)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(68, 70)
        Me.Button2.TabIndex = 57
        Me.Button2.UseVisualStyleBackColor = True
        '
        'txtidcliente
        '
        Me.txtidcliente.Location = New System.Drawing.Point(192, 19)
        Me.txtidcliente.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtidcliente.MaxLength = 1
        Me.txtidcliente.Name = "txtidcliente"
        Me.txtidcliente.Size = New System.Drawing.Size(106, 20)
        Me.txtidcliente.TabIndex = 69
        Me.txtidcliente.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(36, 100)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(113, 13)
        Me.Label3.TabIndex = 67
        Me.Label3.Text = "FECHA CON LIMITES"
        '
        'Button4
        '
        Me.Button4.FlatAppearance.BorderSize = 0
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_guardar2
        Me.Button4.Location = New System.Drawing.Point(360, 68)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(68, 57)
        Me.Button4.TabIndex = 54
        Me.Button4.UseVisualStyleBackColor = True
        '
        'cliente
        '
        Me.cliente.Enabled = False
        Me.cliente.Location = New System.Drawing.Point(192, 46)
        Me.cliente.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.cliente.MaxLength = 1
        Me.cliente.Name = "cliente"
        Me.cliente.Size = New System.Drawing.Size(106, 20)
        Me.cliente.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(19, 46)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(165, 21)
        Me.Label4.TabIndex = 53
        Me.Label4.Text = "CLIENTE CON LIMITES"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DgvLimiteClientes
        '
        Me.DgvLimiteClientes.AllowUserToAddRows = False
        Me.DgvLimiteClientes.AllowUserToDeleteRows = False
        Me.DgvLimiteClientes.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark
        Me.DgvLimiteClientes.ColumnHeadersHeight = 30
        Me.DgvLimiteClientes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ELIM, Me.RUT, Me.PERSONAL, Me.Rut_Cliente, Me.Nombre, Me.ID})
        Me.DgvLimiteClientes.Location = New System.Drawing.Point(511, 95)
        Me.DgvLimiteClientes.Name = "DgvLimiteClientes"
        Me.DgvLimiteClientes.ReadOnly = True
        Me.DgvLimiteClientes.Size = New System.Drawing.Size(801, 354)
        Me.DgvLimiteClientes.TabIndex = 58
        '
        'ELIM
        '
        Me.ELIM.HeaderText = "ELIM"
        Me.ELIM.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.button_cancel
        Me.ELIM.Name = "ELIM"
        Me.ELIM.ReadOnly = True
        Me.ELIM.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ELIM.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.ELIM.Width = 50
        '
        'RUT
        '
        Me.RUT.DataPropertyName = "Fecha"
        Me.RUT.HeaderText = "Fecha "
        Me.RUT.Name = "RUT"
        Me.RUT.ReadOnly = True
        Me.RUT.Width = 200
        '
        'PERSONAL
        '
        Me.PERSONAL.DataPropertyName = "Limite"
        Me.PERSONAL.HeaderText = "Limite "
        Me.PERSONAL.Name = "PERSONAL"
        Me.PERSONAL.ReadOnly = True
        Me.PERSONAL.Width = 50
        '
        'Rut_Cliente
        '
        Me.Rut_Cliente.DataPropertyName = "Rut_Cliente"
        Me.Rut_Cliente.HeaderText = "Rut Cliente"
        Me.Rut_Cliente.Name = "Rut_Cliente"
        Me.Rut_Cliente.ReadOnly = True
        Me.Rut_Cliente.Width = 200
        '
        'Nombre
        '
        Me.Nombre.DataPropertyName = "Nombre"
        Me.Nombre.HeaderText = "Nombre Cliente"
        Me.Nombre.Name = "Nombre"
        Me.Nombre.ReadOnly = True
        Me.Nombre.Width = 230
        '
        'ID
        '
        Me.ID.DataPropertyName = "Codigo"
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Snow
        Me.Label6.Location = New System.Drawing.Point(777, 40)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(287, 21)
        Me.Label6.TabIndex = 59
        Me.Label6.Text = "LISTADO PEDIDOS CON LIMITES CLIENTES"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "Codigo"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Id"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 50
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Fecha"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Fecha "
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 200
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "Limite"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Limite "
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 50
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "Rut_Cliente"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Rut Cliente"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 150
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "Nombre"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Nombre Cliente"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 150
        '
        'LimiteFechaExportacionPedidos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(1338, 553)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.DgvLimiteClientes)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "LimiteFechaExportacionPedidos"
        Me.Text = "LimiteFechaExportacionPedidos"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.DgvLimiteClientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txthoralim As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnGrahor As System.Windows.Forms.Button
    Friend WithEvents Checkhora As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtlimite As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents fecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnlst As System.Windows.Forms.Button
    Friend WithEvents txtcodigo As System.Windows.Forms.TextBox
    Friend WithEvents btn_limpiar As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents txtidcliente As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents cliente As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents fechalimit As System.Windows.Forms.TextBox
    Friend WithEvents BtnClientes As System.Windows.Forms.Button
    Friend WithEvents txtidfechalimit As System.Windows.Forms.TextBox
    Friend WithEvents btnfechas As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cantidadlimit As System.Windows.Forms.TextBox
    Friend WithEvents DgvLimiteClientes As System.Windows.Forms.DataGridView
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents ELIM As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents RUT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PERSONAL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Rut_Cliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ID As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

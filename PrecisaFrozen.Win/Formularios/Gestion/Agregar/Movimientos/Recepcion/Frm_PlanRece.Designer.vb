<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_PlanRece
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_PlanRece))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Gb_Encabezado = New System.Windows.Forms.GroupBox()
        Me.cboJor = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCanPal = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Txtobs = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.fecharece = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtClirut = New System.Windows.Forms.TextBox()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.btn_BuscaCliente = New System.Windows.Forms.Button()
        Me.txtclinom = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.btnExcel = New System.Windows.Forms.Button()
        Me.Btn_AnulaGuia = New System.Windows.Forms.Button()
        Me.btn_guardar = New System.Windows.Forms.Button()
        Me.btn_salir = New System.Windows.Forms.Button()
        Me.btn_nuevo = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.gvDet = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha_Frm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.jornada = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rut_cliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nombre_cliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cantidad_Pallets = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.observacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Usuario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Gb_Encabezado.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.gvDet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Gb_Encabezado
        '
        Me.Gb_Encabezado.BackColor = System.Drawing.Color.Transparent
        Me.Gb_Encabezado.Controls.Add(Me.cboJor)
        Me.Gb_Encabezado.Controls.Add(Me.Label2)
        Me.Gb_Encabezado.Controls.Add(Me.txtCanPal)
        Me.Gb_Encabezado.Controls.Add(Me.Label1)
        Me.Gb_Encabezado.Controls.Add(Me.Txtobs)
        Me.Gb_Encabezado.Controls.Add(Me.Label25)
        Me.Gb_Encabezado.Controls.Add(Me.fecharece)
        Me.Gb_Encabezado.Controls.Add(Me.Label3)
        Me.Gb_Encabezado.Controls.Add(Me.TxtClirut)
        Me.Gb_Encabezado.Controls.Add(Me.Label43)
        Me.Gb_Encabezado.Controls.Add(Me.btn_BuscaCliente)
        Me.Gb_Encabezado.Controls.Add(Me.txtclinom)
        Me.Gb_Encabezado.ForeColor = System.Drawing.Color.White
        Me.Gb_Encabezado.Location = New System.Drawing.Point(11, 12)
        Me.Gb_Encabezado.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Gb_Encabezado.Name = "Gb_Encabezado"
        Me.Gb_Encabezado.Padding = New System.Windows.Forms.Padding(9, 2, 4, 4)
        Me.Gb_Encabezado.Size = New System.Drawing.Size(922, 189)
        Me.Gb_Encabezado.TabIndex = 51
        Me.Gb_Encabezado.TabStop = False
        '
        'cboJor
        '
        Me.cboJor.FormattingEnabled = True
        Me.cboJor.Location = New System.Drawing.Point(294, 47)
        Me.cboJor.Name = "cboJor"
        Me.cboJor.Size = New System.Drawing.Size(115, 21)
        Me.cboJor.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(205, 46)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 21)
        Me.Label2.TabIndex = 62
        Me.Label2.Text = "JORNADA"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCanPal
        '
        Me.txtCanPal.Location = New System.Drawing.Point(492, 47)
        Me.txtCanPal.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtCanPal.MaxLength = 8
        Me.txtCanPal.Name = "txtCanPal"
        Me.txtCanPal.Size = New System.Drawing.Size(82, 20)
        Me.txtCanPal.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(426, 46)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 21)
        Me.Label1.TabIndex = 60
        Me.Label1.Text = "PALLETS"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Txtobs
        '
        Me.Txtobs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txtobs.Location = New System.Drawing.Point(12, 92)
        Me.Txtobs.MaxLength = 250
        Me.Txtobs.Multiline = True
        Me.Txtobs.Name = "Txtobs"
        Me.Txtobs.Size = New System.Drawing.Size(562, 83)
        Me.Txtobs.TabIndex = 6
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(9, 75)
        Me.Label25.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(94, 13)
        Me.Label25.TabIndex = 58
        Me.Label25.Text = "OBSERVACION"
        '
        'fecharece
        '
        Me.fecharece.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fecharece.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.fecharece.Location = New System.Drawing.Point(77, 43)
        Me.fecharece.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.fecharece.Name = "fecharece"
        Me.fecharece.Size = New System.Drawing.Size(115, 22)
        Me.fecharece.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(9, 50)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 50
        Me.Label3.Text = "FECHA"
        '
        'TxtClirut
        '
        Me.TxtClirut.Location = New System.Drawing.Point(77, 16)
        Me.TxtClirut.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TxtClirut.MaxLength = 8
        Me.TxtClirut.Name = "TxtClirut"
        Me.TxtClirut.Size = New System.Drawing.Size(82, 20)
        Me.TxtClirut.TabIndex = 0
        '
        'Label43
        '
        Me.Label43.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label43.Location = New System.Drawing.Point(9, 15)
        Me.Label43.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(58, 21)
        Me.Label43.TabIndex = 48
        Me.Label43.Text = "CLIENTE"
        Me.Label43.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btn_BuscaCliente
        '
        Me.btn_BuscaCliente.Image = CType(resources.GetObject("btn_BuscaCliente.Image"), System.Drawing.Image)
        Me.btn_BuscaCliente.Location = New System.Drawing.Point(165, 15)
        Me.btn_BuscaCliente.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btn_BuscaCliente.Name = "btn_BuscaCliente"
        Me.btn_BuscaCliente.Size = New System.Drawing.Size(21, 22)
        Me.btn_BuscaCliente.TabIndex = 1
        Me.btn_BuscaCliente.UseVisualStyleBackColor = True
        '
        'txtclinom
        '
        Me.txtclinom.Location = New System.Drawing.Point(194, 16)
        Me.txtclinom.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtclinom.Name = "txtclinom"
        Me.txtclinom.Size = New System.Drawing.Size(380, 20)
        Me.txtclinom.TabIndex = 2
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.Label60)
        Me.GroupBox4.Controls.Add(Me.btnExcel)
        Me.GroupBox4.Controls.Add(Me.Btn_AnulaGuia)
        Me.GroupBox4.Controls.Add(Me.btn_guardar)
        Me.GroupBox4.Controls.Add(Me.btn_salir)
        Me.GroupBox4.Controls.Add(Me.btn_nuevo)
        Me.GroupBox4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(940, 12)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(95, 365)
        Me.GroupBox4.TabIndex = 58
        Me.GroupBox4.TabStop = False
        '
        'Label60
        '
        Me.Label60.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label60.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label60.Location = New System.Drawing.Point(15, 457)
        Me.Label60.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(43, 17)
        Me.Label60.TabIndex = 67
        Me.Label60.Text = "CAJAS"
        Me.Label60.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnExcel
        '
        Me.btnExcel.BackColor = System.Drawing.Color.Transparent
        Me.btnExcel.FlatAppearance.BorderSize = 0
        Me.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExcel.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_xls
        Me.btnExcel.Location = New System.Drawing.Point(3, 80)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(89, 63)
        Me.btnExcel.TabIndex = 9
        Me.btnExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExcel.UseVisualStyleBackColor = False
        '
        'Btn_AnulaGuia
        '
        Me.Btn_AnulaGuia.FlatAppearance.BorderSize = 0
        Me.Btn_AnulaGuia.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_AnulaGuia.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_hojamenos
        Me.Btn_AnulaGuia.Location = New System.Drawing.Point(3, 222)
        Me.Btn_AnulaGuia.Name = "Btn_AnulaGuia"
        Me.Btn_AnulaGuia.Size = New System.Drawing.Size(89, 63)
        Me.Btn_AnulaGuia.TabIndex = 11
        Me.Btn_AnulaGuia.UseVisualStyleBackColor = True
        '
        'btn_guardar
        '
        Me.btn_guardar.FlatAppearance.BorderSize = 0
        Me.btn_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_guardar.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_guardar2
        Me.btn_guardar.Location = New System.Drawing.Point(3, 9)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(89, 63)
        Me.btn_guardar.TabIndex = 8
        Me.btn_guardar.UseVisualStyleBackColor = True
        '
        'btn_salir
        '
        Me.btn_salir.FlatAppearance.BorderSize = 0
        Me.btn_salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_salir.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_salida
        Me.btn_salir.Location = New System.Drawing.Point(3, 293)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(89, 63)
        Me.btn_salir.TabIndex = 12
        Me.btn_salir.UseVisualStyleBackColor = True
        '
        'btn_nuevo
        '
        Me.btn_nuevo.FlatAppearance.BorderSize = 0
        Me.btn_nuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_nuevo.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_hojanueva
        Me.btn_nuevo.Location = New System.Drawing.Point(3, 151)
        Me.btn_nuevo.Name = "btn_nuevo"
        Me.btn_nuevo.Size = New System.Drawing.Size(89, 63)
        Me.btn_nuevo.TabIndex = 10
        Me.btn_nuevo.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.gvDet)
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(11, 207)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(9, 2, 4, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(922, 410)
        Me.GroupBox1.TabIndex = 62
        Me.GroupBox1.TabStop = False
        '
        'gvDet
        '
        Me.gvDet.AllowUserToAddRows = False
        Me.gvDet.AllowUserToDeleteRows = False
        Me.gvDet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvDet.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.Fecha_Frm, Me.jornada, Me.rut_cliente, Me.nombre_cliente, Me.Cantidad_Pallets, Me.observacion, Me.Usuario})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gvDet.DefaultCellStyle = DataGridViewCellStyle1
        Me.gvDet.Location = New System.Drawing.Point(12, 18)
        Me.gvDet.Name = "gvDet"
        Me.gvDet.ReadOnly = True
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        Me.gvDet.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.gvDet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvDet.Size = New System.Drawing.Size(903, 385)
        Me.gvDet.TabIndex = 7
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "Fecha_Frm"
        Me.DataGridViewTextBoxColumn1.Frozen = True
        Me.DataGridViewTextBoxColumn1.HeaderText = "FECHA"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Jornada"
        Me.DataGridViewTextBoxColumn2.Frozen = True
        Me.DataGridViewTextBoxColumn2.HeaderText = "JORNADA"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "Rut"
        Me.DataGridViewTextBoxColumn3.Frozen = True
        Me.DataGridViewTextBoxColumn3.HeaderText = "RUT"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "Cliente"
        Me.DataGridViewTextBoxColumn4.Frozen = True
        Me.DataGridViewTextBoxColumn4.HeaderText = "CLIENTE"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "Pallets"
        Me.DataGridViewTextBoxColumn5.Frozen = True
        Me.DataGridViewTextBoxColumn5.HeaderText = "PALLETS"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "Observacion"
        Me.DataGridViewTextBoxColumn6.Frozen = True
        Me.DataGridViewTextBoxColumn6.HeaderText = "OBSERVACIÓN"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "Observacion"
        Me.DataGridViewTextBoxColumn7.Frozen = True
        Me.DataGridViewTextBoxColumn7.HeaderText = "OBSERVACIÓN"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "Usuario"
        Me.DataGridViewTextBoxColumn8.HeaderText = "USUARIO"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        '
        'ID
        '
        Me.ID.DataPropertyName = "ID"
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        Me.ID.Visible = False
        '
        'Fecha_Frm
        '
        Me.Fecha_Frm.DataPropertyName = "Fecha_Frm"
        Me.Fecha_Frm.HeaderText = "FECHA"
        Me.Fecha_Frm.Name = "Fecha_Frm"
        Me.Fecha_Frm.ReadOnly = True
        '
        'jornada
        '
        Me.jornada.DataPropertyName = "Jornada"
        Me.jornada.HeaderText = "JORNADA"
        Me.jornada.Name = "jornada"
        Me.jornada.ReadOnly = True
        '
        'rut_cliente
        '
        Me.rut_cliente.DataPropertyName = "Rut_Cliente"
        Me.rut_cliente.HeaderText = "RUT"
        Me.rut_cliente.Name = "rut_cliente"
        Me.rut_cliente.ReadOnly = True
        '
        'nombre_cliente
        '
        Me.nombre_cliente.DataPropertyName = "Nombre_Cliente"
        Me.nombre_cliente.HeaderText = "CLIENTE"
        Me.nombre_cliente.Name = "nombre_cliente"
        Me.nombre_cliente.ReadOnly = True
        '
        'Cantidad_Pallets
        '
        Me.Cantidad_Pallets.DataPropertyName = "Cantidad_Pallets"
        Me.Cantidad_Pallets.HeaderText = "PALLETS"
        Me.Cantidad_Pallets.Name = "Cantidad_Pallets"
        Me.Cantidad_Pallets.ReadOnly = True
        '
        'observacion
        '
        Me.observacion.DataPropertyName = "Observacion"
        Me.observacion.HeaderText = "OBSERVACIÓN"
        Me.observacion.Name = "observacion"
        Me.observacion.ReadOnly = True
        '
        'Usuario
        '
        Me.Usuario.DataPropertyName = "Usuario"
        Me.Usuario.HeaderText = "USUARIO"
        Me.Usuario.Name = "Usuario"
        Me.Usuario.ReadOnly = True
        '
        'Frm_PlanRece
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(1047, 629)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.Gb_Encabezado)
        Me.Name = "Frm_PlanRece"
        Me.Text = "Movimientos - Planificación de Recepciones"
        Me.Gb_Encabezado.ResumeLayout(False)
        Me.Gb_Encabezado.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.gvDet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Gb_Encabezado As System.Windows.Forms.GroupBox
    Friend WithEvents TxtClirut As System.Windows.Forms.TextBox
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents btn_BuscaCliente As System.Windows.Forms.Button
    Friend WithEvents txtclinom As System.Windows.Forms.TextBox
    Friend WithEvents fecharece As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Txtobs As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txtCanPal As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label60 As System.Windows.Forms.Label
    Friend WithEvents btnExcel As System.Windows.Forms.Button
    Friend WithEvents Btn_AnulaGuia As System.Windows.Forms.Button
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents btn_salir As System.Windows.Forms.Button
    Friend WithEvents btn_nuevo As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboJor As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents gvDet As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha_Frm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents jornada As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rut_cliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nombre_cliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cantidad_Pallets As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents observacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Usuario As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

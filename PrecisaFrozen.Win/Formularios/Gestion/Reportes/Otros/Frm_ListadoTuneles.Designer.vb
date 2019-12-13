<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_ListadoTuneles
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
        Me.dtp_fecter = New System.Windows.Forms.DateTimePicker()
        Me.dtp_fecini = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvMovimientos = New System.Windows.Forms.DataGridView()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnExcel = New System.Windows.Forms.Button()
        Me.Btn_Buscar = New System.Windows.Forms.Button()
        Me.Btn_Salir = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtnumguia = New System.Windows.Forms.TextBox()
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
        Me.GUIA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GUIA_CLIENTE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CLIENTE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODIGO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRODUCTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PALLET = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PALLET_CLIENTE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UNIDADES = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PESO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECHA_RECEPCION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECHA_PRODUCCION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECHA_VENCIMIENTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECHA_INGRESO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HORA_INGRESO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TEMP_NGRESO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECHA_SALIDA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HORA_SALIDA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TEMP_SALIDA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HORAS_TUNEL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvMovimientos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtp_fecter
        '
        Me.dtp_fecter.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecter.Location = New System.Drawing.Point(129, 50)
        Me.dtp_fecter.Name = "dtp_fecter"
        Me.dtp_fecter.Size = New System.Drawing.Size(96, 20)
        Me.dtp_fecter.TabIndex = 120
        '
        'dtp_fecini
        '
        Me.dtp_fecini.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_fecini.Location = New System.Drawing.Point(129, 21)
        Me.dtp_fecini.Name = "dtp_fecini"
        Me.dtp_fecini.Size = New System.Drawing.Size(96, 20)
        Me.dtp_fecini.TabIndex = 119
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(111, 53)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(10, 13)
        Me.Label6.TabIndex = 116
        Me.Label6.Text = ":"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(110, 23)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(10, 13)
        Me.Label5.TabIndex = 115
        Me.Label5.Text = ":"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(12, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 13)
        Me.Label2.TabIndex = 112
        Me.Label2.Text = "FECHA TÉRMINO"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(12, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 13)
        Me.Label1.TabIndex = 111
        Me.Label1.Text = "FECHA INICIO"
        '
        'dgvMovimientos
        '
        Me.dgvMovimientos.AllowDrop = True
        Me.dgvMovimientos.AllowUserToAddRows = False
        Me.dgvMovimientos.AllowUserToDeleteRows = False
        Me.dgvMovimientos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvMovimientos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvMovimientos.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark
        Me.dgvMovimientos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GUIA, Me.GUIA_CLIENTE, Me.CLIENTE, Me.CODIGO, Me.PRODUCTO, Me.PALLET, Me.PALLET_CLIENTE, Me.UNIDADES, Me.PESO, Me.FECHA_RECEPCION, Me.FECHA_PRODUCCION, Me.FECHA_VENCIMIENTO, Me.FECHA_INGRESO, Me.HORA_INGRESO, Me.TEMP_NGRESO, Me.FECHA_SALIDA, Me.HORA_SALIDA, Me.TEMP_SALIDA, Me.HORAS_TUNEL})
        Me.dgvMovimientos.Location = New System.Drawing.Point(12, 93)
        Me.dgvMovimientos.Name = "dgvMovimientos"
        Me.dgvMovimientos.ReadOnly = True
        Me.dgvMovimientos.RowHeadersVisible = False
        Me.dgvMovimientos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvMovimientos.Size = New System.Drawing.Size(1136, 456)
        Me.dgvMovimientos.TabIndex = 109
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.btnExcel)
        Me.GroupBox2.Controls.Add(Me.Btn_Buscar)
        Me.GroupBox2.Controls.Add(Me.Btn_Salir)
        Me.GroupBox2.Location = New System.Drawing.Point(1154, 93)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(76, 207)
        Me.GroupBox2.TabIndex = 110
        Me.GroupBox2.TabStop = False
        '
        'btnExcel
        '
        Me.btnExcel.FlatAppearance.BorderSize = 0
        Me.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExcel.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_xls
        Me.btnExcel.Location = New System.Drawing.Point(6, 76)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(63, 63)
        Me.btnExcel.TabIndex = 121
        Me.btnExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExcel.UseVisualStyleBackColor = True
        '
        'Btn_Buscar
        '
        Me.Btn_Buscar.FlatAppearance.BorderSize = 0
        Me.Btn_Buscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_Buscar.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_soportante
        Me.Btn_Buscar.Location = New System.Drawing.Point(6, 16)
        Me.Btn_Buscar.Name = "Btn_Buscar"
        Me.Btn_Buscar.Size = New System.Drawing.Size(63, 63)
        Me.Btn_Buscar.TabIndex = 90
        Me.Btn_Buscar.UseVisualStyleBackColor = True
        '
        'Btn_Salir
        '
        Me.Btn_Salir.FlatAppearance.BorderSize = 0
        Me.Btn_Salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_Salir.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_salida
        Me.Btn_Salir.Location = New System.Drawing.Point(6, 136)
        Me.Btn_Salir.Name = "Btn_Salir"
        Me.Btn_Salir.Size = New System.Drawing.Size(63, 63)
        Me.Btn_Salir.TabIndex = 89
        Me.Btn_Salir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Btn_Salir.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(231, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 13)
        Me.Label3.TabIndex = 121
        Me.Label3.Text = "N° GUIA "
        '
        'txtnumguia
        '
        Me.txtnumguia.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnumguia.Location = New System.Drawing.Point(289, 49)
        Me.txtnumguia.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtnumguia.MaxLength = 10
        Me.txtnumguia.Name = "txtnumguia"
        Me.txtnumguia.Size = New System.Drawing.Size(117, 21)
        Me.txtnumguia.TabIndex = 122
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "frec_guia"
        Me.DataGridViewTextBoxColumn1.HeaderText = "GUIA"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 58
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "frec_codi"
        Me.DataGridViewTextBoxColumn2.HeaderText = "PALLET"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 72
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "fechora_ingreso"
        Me.DataGridViewTextBoxColumn3.HeaderText = "FECHA INGRESO"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 119
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "temp_ingreso"
        Me.DataGridViewTextBoxColumn4.HeaderText = "T° INGRESO"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 95
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "fechora_salida"
        Me.DataGridViewTextBoxColumn5.HeaderText = "FECHA SALIDA"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 108
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "temp_salida"
        Me.DataGridViewTextBoxColumn6.HeaderText = "T° SALIDA"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Width = 84
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "horas_tunel"
        Me.DataGridViewTextBoxColumn7.HeaderText = "HORAS TUNEL"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Width = 109
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "Cliente"
        Me.DataGridViewTextBoxColumn8.HeaderText = "CLIENTE"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Width = 77
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "FECHA PRODUCCION"
        Me.DataGridViewTextBoxColumn9.HeaderText = "FECHA PRODUCCION"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        Me.DataGridViewTextBoxColumn9.Width = 142
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "FECHA VENCIMIENTO"
        Me.DataGridViewTextBoxColumn10.HeaderText = "FECHA VENCIMIENTO"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        Me.DataGridViewTextBoxColumn10.Width = 144
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "PALLET"
        Me.DataGridViewTextBoxColumn11.HeaderText = "PALLET"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        Me.DataGridViewTextBoxColumn11.Width = 72
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "FECHA INGRESO"
        Me.DataGridViewTextBoxColumn12.HeaderText = "FECHA INGRESO"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.ReadOnly = True
        Me.DataGridViewTextBoxColumn12.Width = 119
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.DataPropertyName = "T INGRESO"
        Me.DataGridViewTextBoxColumn13.HeaderText = "T° INGRESO"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.ReadOnly = True
        Me.DataGridViewTextBoxColumn13.Width = 95
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.DataPropertyName = "FECHA SALIDA"
        Me.DataGridViewTextBoxColumn14.HeaderText = "FECHA SALIDA"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.ReadOnly = True
        Me.DataGridViewTextBoxColumn14.Width = 108
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.DataPropertyName = "T SALIDA"
        Me.DataGridViewTextBoxColumn15.HeaderText = "T° SALIDA"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        Me.DataGridViewTextBoxColumn15.ReadOnly = True
        Me.DataGridViewTextBoxColumn15.Width = 84
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.DataPropertyName = "HORAS TUNEL"
        Me.DataGridViewTextBoxColumn16.HeaderText = "HORAS TUNEL"
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        Me.DataGridViewTextBoxColumn16.ReadOnly = True
        Me.DataGridViewTextBoxColumn16.Width = 109
        '
        'DataGridViewTextBoxColumn17
        '
        Me.DataGridViewTextBoxColumn17.DataPropertyName = "CLIENTE"
        Me.DataGridViewTextBoxColumn17.HeaderText = "CLIENTE"
        Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
        Me.DataGridViewTextBoxColumn17.ReadOnly = True
        Me.DataGridViewTextBoxColumn17.Width = 77
        '
        'GUIA
        '
        Me.GUIA.DataPropertyName = "GUIA"
        Me.GUIA.HeaderText = "GUIA"
        Me.GUIA.Name = "GUIA"
        Me.GUIA.ReadOnly = True
        Me.GUIA.Width = 58
        '
        'GUIA_CLIENTE
        '
        Me.GUIA_CLIENTE.DataPropertyName = "GUIA CLIENTE"
        Me.GUIA_CLIENTE.HeaderText = "GUIA CLIENTE"
        Me.GUIA_CLIENTE.Name = "GUIA_CLIENTE"
        Me.GUIA_CLIENTE.ReadOnly = True
        Me.GUIA_CLIENTE.Width = 106
        '
        'CLIENTE
        '
        Me.CLIENTE.DataPropertyName = "CLIENTE"
        Me.CLIENTE.HeaderText = "CLIENTE"
        Me.CLIENTE.Name = "CLIENTE"
        Me.CLIENTE.ReadOnly = True
        Me.CLIENTE.Width = 77
        '
        'CODIGO
        '
        Me.CODIGO.DataPropertyName = "CODIGO"
        Me.CODIGO.HeaderText = "CODIGO"
        Me.CODIGO.Name = "CODIGO"
        Me.CODIGO.ReadOnly = True
        Me.CODIGO.Width = 74
        '
        'PRODUCTO
        '
        Me.PRODUCTO.DataPropertyName = "PRODUCTO"
        Me.PRODUCTO.HeaderText = "PRODUCTO"
        Me.PRODUCTO.Name = "PRODUCTO"
        Me.PRODUCTO.ReadOnly = True
        Me.PRODUCTO.Width = 93
        '
        'PALLET
        '
        Me.PALLET.DataPropertyName = "PALLET"
        Me.PALLET.HeaderText = "PALLET"
        Me.PALLET.Name = "PALLET"
        Me.PALLET.ReadOnly = True
        Me.PALLET.Width = 72
        '
        'PALLET_CLIENTE
        '
        Me.PALLET_CLIENTE.DataPropertyName = "PALLET CLIENTE"
        Me.PALLET_CLIENTE.HeaderText = "PALLET CLIENTE"
        Me.PALLET_CLIENTE.Name = "PALLET_CLIENTE"
        Me.PALLET_CLIENTE.ReadOnly = True
        Me.PALLET_CLIENTE.Width = 120
        '
        'UNIDADES
        '
        Me.UNIDADES.DataPropertyName = "UNIDADES"
        Me.UNIDADES.HeaderText = "UNIDADES"
        Me.UNIDADES.Name = "UNIDADES"
        Me.UNIDADES.ReadOnly = True
        Me.UNIDADES.Width = 88
        '
        'PESO
        '
        Me.PESO.DataPropertyName = "PESO"
        Me.PESO.HeaderText = "PESO"
        Me.PESO.Name = "PESO"
        Me.PESO.ReadOnly = True
        Me.PESO.Width = 61
        '
        'FECHA_RECEPCION
        '
        Me.FECHA_RECEPCION.DataPropertyName = "FECHA RECEPCION"
        Me.FECHA_RECEPCION.HeaderText = "FECHA RECEPCION"
        Me.FECHA_RECEPCION.Name = "FECHA_RECEPCION"
        Me.FECHA_RECEPCION.ReadOnly = True
        Me.FECHA_RECEPCION.Width = 132
        '
        'FECHA_PRODUCCION
        '
        Me.FECHA_PRODUCCION.DataPropertyName = "FECHA PRODUCCION"
        Me.FECHA_PRODUCCION.HeaderText = "FECHA PRODUCCION"
        Me.FECHA_PRODUCCION.Name = "FECHA_PRODUCCION"
        Me.FECHA_PRODUCCION.ReadOnly = True
        Me.FECHA_PRODUCCION.Width = 142
        '
        'FECHA_VENCIMIENTO
        '
        Me.FECHA_VENCIMIENTO.DataPropertyName = "FECHA VENCIMIENTO"
        Me.FECHA_VENCIMIENTO.HeaderText = "FECHA VENCIMIENTO"
        Me.FECHA_VENCIMIENTO.Name = "FECHA_VENCIMIENTO"
        Me.FECHA_VENCIMIENTO.ReadOnly = True
        Me.FECHA_VENCIMIENTO.Width = 144
        '
        'FECHA_INGRESO
        '
        Me.FECHA_INGRESO.DataPropertyName = "FECHA INGRESO"
        Me.FECHA_INGRESO.HeaderText = "FECHA INGRESO"
        Me.FECHA_INGRESO.Name = "FECHA_INGRESO"
        Me.FECHA_INGRESO.ReadOnly = True
        Me.FECHA_INGRESO.Width = 119
        '
        'HORA_INGRESO
        '
        Me.HORA_INGRESO.DataPropertyName = "HORA INGRESO"
        Me.HORA_INGRESO.HeaderText = "HORA INGRESO"
        Me.HORA_INGRESO.Name = "HORA_INGRESO"
        Me.HORA_INGRESO.ReadOnly = True
        Me.HORA_INGRESO.Width = 115
        '
        'TEMP_NGRESO
        '
        Me.TEMP_NGRESO.DataPropertyName = "T INGRESO"
        Me.TEMP_NGRESO.HeaderText = "T° INGRESO"
        Me.TEMP_NGRESO.Name = "TEMP_NGRESO"
        Me.TEMP_NGRESO.ReadOnly = True
        Me.TEMP_NGRESO.Width = 95
        '
        'FECHA_SALIDA
        '
        Me.FECHA_SALIDA.DataPropertyName = "FECHA SALIDA"
        Me.FECHA_SALIDA.HeaderText = "FECHA SALIDA"
        Me.FECHA_SALIDA.Name = "FECHA_SALIDA"
        Me.FECHA_SALIDA.ReadOnly = True
        Me.FECHA_SALIDA.Width = 108
        '
        'HORA_SALIDA
        '
        Me.HORA_SALIDA.DataPropertyName = "HORA SALIDA"
        Me.HORA_SALIDA.HeaderText = "HORA SALIDA"
        Me.HORA_SALIDA.Name = "HORA_SALIDA"
        Me.HORA_SALIDA.ReadOnly = True
        Me.HORA_SALIDA.Width = 104
        '
        'TEMP_SALIDA
        '
        Me.TEMP_SALIDA.DataPropertyName = "T SALIDA"
        Me.TEMP_SALIDA.HeaderText = "T° SALIDA"
        Me.TEMP_SALIDA.Name = "TEMP_SALIDA"
        Me.TEMP_SALIDA.ReadOnly = True
        Me.TEMP_SALIDA.Width = 84
        '
        'HORAS_TUNEL
        '
        Me.HORAS_TUNEL.DataPropertyName = "HORAS TUNEL"
        Me.HORAS_TUNEL.HeaderText = "HORAS TUNEL"
        Me.HORAS_TUNEL.Name = "HORAS_TUNEL"
        Me.HORAS_TUNEL.ReadOnly = True
        Me.HORAS_TUNEL.Width = 109
        '
        'Frm_ListadoTuneles
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(1242, 561)
        Me.Controls.Add(Me.txtnumguia)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dtp_fecter)
        Me.Controls.Add(Me.dtp_fecini)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgvMovimientos)
        Me.Controls.Add(Me.GroupBox2)
        Me.Name = "Frm_ListadoTuneles"
        Me.Text = "Listado Tuneles"
        CType(Me.dgvMovimientos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtp_fecter As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_fecini As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvMovimientos As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Btn_Buscar As System.Windows.Forms.Button
    Friend WithEvents Btn_Salir As System.Windows.Forms.Button
    Friend WithEvents btnExcel As System.Windows.Forms.Button
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtnumguia As System.Windows.Forms.TextBox
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
    Friend WithEvents GUIA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GUIA_CLIENTE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CLIENTE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODIGO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRODUCTO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PALLET As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PALLET_CLIENTE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UNIDADES As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PESO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECHA_RECEPCION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECHA_PRODUCCION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECHA_VENCIMIENTO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECHA_INGRESO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HORA_INGRESO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TEMP_NGRESO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECHA_SALIDA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HORA_SALIDA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TEMP_SALIDA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HORAS_TUNEL As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

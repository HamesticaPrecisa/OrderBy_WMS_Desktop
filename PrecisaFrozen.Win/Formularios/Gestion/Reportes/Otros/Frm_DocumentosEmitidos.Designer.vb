<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_DocumentosEmitidos
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DgvEmitidos = New System.Windows.Forms.DataGridView()
        Me.CODIGO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CLIENTE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MOVIMIENTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ORIGEN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ENCARGADO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.S = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.U = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.K = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.L = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Dtfecha = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btn_nuevo = New System.Windows.Forms.Button()
        Me.Btn_Salir = New System.Windows.Forms.Button()
        Me.Btn_Calcular = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ts = New System.Windows.Forms.TextBox()
        Me.tu = New System.Windows.Forms.TextBox()
        Me.tk = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DgvEmitidos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'DgvEmitidos
        '
        Me.DgvEmitidos.AllowUserToAddRows = False
        Me.DgvEmitidos.AllowUserToDeleteRows = False
        Me.DgvEmitidos.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark
        Me.DgvEmitidos.ColumnHeadersHeight = 28
        Me.DgvEmitidos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CODIGO, Me.CLIENTE, Me.MOVIMIENTO, Me.ORIGEN, Me.ENCARGADO, Me.S, Me.U, Me.K, Me.L})
        Me.DgvEmitidos.Location = New System.Drawing.Point(14, 52)
        Me.DgvEmitidos.Name = "DgvEmitidos"
        Me.DgvEmitidos.ReadOnly = True
        Me.DgvEmitidos.Size = New System.Drawing.Size(889, 494)
        Me.DgvEmitidos.TabIndex = 0
        '
        'CODIGO
        '
        Me.CODIGO.DataPropertyName = "frec_codi"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.CODIGO.DefaultCellStyle = DataGridViewCellStyle1
        Me.CODIGO.HeaderText = "CODIGO"
        Me.CODIGO.Name = "CODIGO"
        Me.CODIGO.ReadOnly = True
        Me.CODIGO.Width = 60
        '
        'CLIENTE
        '
        Me.CLIENTE.DataPropertyName = "cli_nomb"
        Me.CLIENTE.HeaderText = "CLIENTE"
        Me.CLIENTE.Name = "CLIENTE"
        Me.CLIENTE.ReadOnly = True
        Me.CLIENTE.Width = 190
        '
        'MOVIMIENTO
        '
        Me.MOVIMIENTO.DataPropertyName = "tipo"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.MOVIMIENTO.DefaultCellStyle = DataGridViewCellStyle2
        Me.MOVIMIENTO.HeaderText = "MOVIMIENTO"
        Me.MOVIMIENTO.Name = "MOVIMIENTO"
        Me.MOVIMIENTO.ReadOnly = True
        Me.MOVIMIENTO.Width = 90
        '
        'ORIGEN
        '
        Me.ORIGEN.DataPropertyName = "ori_descr"
        Me.ORIGEN.HeaderText = "ORIGEN "
        Me.ORIGEN.Name = "ORIGEN"
        Me.ORIGEN.ReadOnly = True
        Me.ORIGEN.Width = 150
        '
        'ENCARGADO
        '
        Me.ENCARGADO.DataPropertyName = "descri"
        Me.ENCARGADO.HeaderText = "ENCARGADO"
        Me.ENCARGADO.Name = "ENCARGADO"
        Me.ENCARGADO.ReadOnly = True
        Me.ENCARGADO.Width = 150
        '
        'S
        '
        Me.S.DataPropertyName = "frec_totsopo"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.S.DefaultCellStyle = DataGridViewCellStyle3
        Me.S.HeaderText = "SOP."
        Me.S.Name = "S"
        Me.S.ReadOnly = True
        Me.S.Width = 45
        '
        'U
        '
        Me.U.DataPropertyName = "frec_totunidad"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N0"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.U.DefaultCellStyle = DataGridViewCellStyle4
        Me.U.HeaderText = "UNID."
        Me.U.Name = "U"
        Me.U.ReadOnly = True
        Me.U.Width = 60
        '
        'K
        '
        Me.K.DataPropertyName = "frec_totpeso"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.K.DefaultCellStyle = DataGridViewCellStyle5
        Me.K.HeaderText = "KG."
        Me.K.Name = "K"
        Me.K.ReadOnly = True
        Me.K.Width = 75
        '
        'L
        '
        Me.L.DataPropertyName = "frec_RecepTunel"
        Me.L.HeaderText = "TUNEL"
        Me.L.Name = "L"
        Me.L.ReadOnly = True
        '
        'Dtfecha
        '
        Me.Dtfecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtfecha.Location = New System.Drawing.Point(79, 16)
        Me.Dtfecha.Name = "Dtfecha"
        Me.Dtfecha.Size = New System.Drawing.Size(116, 21)
        Me.Dtfecha.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(26, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "FECHA "
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.btn_nuevo)
        Me.GroupBox2.Controls.Add(Me.Btn_Salir)
        Me.GroupBox2.Controls.Add(Me.Btn_Calcular)
        Me.GroupBox2.Location = New System.Drawing.Point(909, 52)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(71, 237)
        Me.GroupBox2.TabIndex = 98
        Me.GroupBox2.TabStop = False
        '
        'btn_nuevo
        '
        Me.btn_nuevo.Enabled = False
        Me.btn_nuevo.FlatAppearance.BorderSize = 0
        Me.btn_nuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_nuevo.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_xls
        Me.btn_nuevo.Location = New System.Drawing.Point(3, 91)
        Me.btn_nuevo.Name = "btn_nuevo"
        Me.btn_nuevo.Size = New System.Drawing.Size(63, 63)
        Me.btn_nuevo.TabIndex = 90
        Me.btn_nuevo.UseVisualStyleBackColor = True
        '
        'Btn_Salir
        '
        Me.Btn_Salir.FlatAppearance.BorderSize = 0
        Me.Btn_Salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_Salir.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_salida
        Me.Btn_Salir.Location = New System.Drawing.Point(3, 158)
        Me.Btn_Salir.Name = "Btn_Salir"
        Me.Btn_Salir.Size = New System.Drawing.Size(63, 63)
        Me.Btn_Salir.TabIndex = 89
        Me.Btn_Salir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Btn_Salir.UseVisualStyleBackColor = True
        '
        'Btn_Calcular
        '
        Me.Btn_Calcular.FlatAppearance.BorderSize = 0
        Me.Btn_Calcular.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_Calcular.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_soportante
        Me.Btn_Calcular.Location = New System.Drawing.Point(3, 23)
        Me.Btn_Calcular.Name = "Btn_Calcular"
        Me.Btn_Calcular.Size = New System.Drawing.Size(63, 63)
        Me.Btn_Calcular.TabIndex = 85
        Me.Btn_Calcular.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(358, 560)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 13)
        Me.Label2.TabIndex = 99
        Me.Label2.Text = "SOPORTANTES"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(526, 560)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 13)
        Me.Label3.TabIndex = 100
        Me.Label3.Text = "UNIDIDADES"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(713, 560)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 13)
        Me.Label4.TabIndex = 101
        Me.Label4.Text = "KILOGRAMOS"
        '
        'ts
        '
        Me.ts.Location = New System.Drawing.Point(457, 555)
        Me.ts.Name = "ts"
        Me.ts.ReadOnly = True
        Me.ts.Size = New System.Drawing.Size(54, 21)
        Me.ts.TabIndex = 102
        Me.ts.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tu
        '
        Me.tu.Location = New System.Drawing.Point(618, 556)
        Me.tu.Name = "tu"
        Me.tu.ReadOnly = True
        Me.tu.Size = New System.Drawing.Size(78, 21)
        Me.tu.TabIndex = 103
        Me.tu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tk
        '
        Me.tk.Location = New System.Drawing.Point(805, 556)
        Me.tk.Name = "tk"
        Me.tk.ReadOnly = True
        Me.tk.Size = New System.Drawing.Size(99, 21)
        Me.tk.TabIndex = 104
        Me.tk.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(358, 587)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 13)
        Me.Label5.TabIndex = 105
        Me.Label5.Text = "P/RECEP"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(457, 579)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(54, 21)
        Me.TextBox1.TabIndex = 106
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(526, 587)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(58, 13)
        Me.Label6.TabIndex = 107
        Me.Label6.Text = "P/DESPA"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(618, 579)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(54, 21)
        Me.TextBox2.TabIndex = 108
        Me.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "frec_codi"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridViewTextBoxColumn1.HeaderText = "CODIGO"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 85
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "cli_nomb"
        Me.DataGridViewTextBoxColumn2.HeaderText = "CLIENTE"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 180
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "tipo"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle7
        Me.DataGridViewTextBoxColumn3.HeaderText = "MOVIMIENTO"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 90
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "ori_desc"
        Me.DataGridViewTextBoxColumn4.HeaderText = "ORIGEN "
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 150
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "descri"
        Me.DataGridViewTextBoxColumn5.HeaderText = "ENCARGADO"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 150
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "frec_totsopo"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridViewTextBoxColumn6.DefaultCellStyle = DataGridViewCellStyle8
        Me.DataGridViewTextBoxColumn6.HeaderText = "SOP."
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Width = 75
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "frec_totunidad"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle9.Format = "N0"
        DataGridViewCellStyle9.NullValue = Nothing
        Me.DataGridViewTextBoxColumn7.DefaultCellStyle = DataGridViewCellStyle9
        Me.DataGridViewTextBoxColumn7.HeaderText = "UNID."
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Width = 90
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "frec_totpeso"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle10.Format = "N2"
        DataGridViewCellStyle10.NullValue = Nothing
        Me.DataGridViewTextBoxColumn8.DefaultCellStyle = DataGridViewCellStyle10
        Me.DataGridViewTextBoxColumn8.HeaderText = "KG."
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Width = 90
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.HeaderText = "TUNEL"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        '
        'Frm_DocumentosEmitidos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(1015, 618)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.tk)
        Me.Controls.Add(Me.tu)
        Me.Controls.Add(Me.ts)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Dtfecha)
        Me.Controls.Add(Me.DgvEmitidos)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "Frm_DocumentosEmitidos"
        Me.Text = "Documentos Emitidos"
        CType(Me.DgvEmitidos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DgvEmitidos As System.Windows.Forms.DataGridView
    Friend WithEvents Dtfecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_nuevo As System.Windows.Forms.Button
    Friend WithEvents Btn_Salir As System.Windows.Forms.Button
    Friend WithEvents Btn_Calcular As System.Windows.Forms.Button
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ts As System.Windows.Forms.TextBox
    Friend WithEvents tu As System.Windows.Forms.TextBox
    Friend WithEvents tk As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents CODIGO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CLIENTE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MOVIMIENTO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ORIGEN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ENCARGADO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents S As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents U As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents K As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents L As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

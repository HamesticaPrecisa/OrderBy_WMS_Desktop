<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_ListadoVas
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
        Me.BtnTodos = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.BtnQuitarFiltro = New System.Windows.Forms.Button()
        Me.BtnAceptarFiltro = New System.Windows.Forms.Button()
        Me.CbT2Fechas = New System.Windows.Forms.CheckBox()
        Me.dtFinal = New System.Windows.Forms.DateTimePicker()
        Me.dtInicio = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CbT2Cliente = New System.Windows.Forms.CheckBox()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.TxtClirut = New System.Windows.Forms.TextBox()
        Me.btn_BuscaCliente = New System.Windows.Forms.Button()
        Me.txtclinom = New System.Windows.Forms.TextBox()
        Me.DgvVas = New System.Windows.Forms.DataGridView()
        Me.Folio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CLIENTE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECHA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KILOS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NCLIENTE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SECCION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DgvVas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnTodos
        '
        Me.BtnTodos.BackColor = System.Drawing.Color.Silver
        Me.BtnTodos.Location = New System.Drawing.Point(762, 395)
        Me.BtnTodos.Name = "BtnTodos"
        Me.BtnTodos.Size = New System.Drawing.Size(250, 33)
        Me.BtnTodos.TabIndex = 3
        Me.BtnTodos.Text = "MOSTRAR TODOS LOS COBROS"
        Me.BtnTodos.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.BtnQuitarFiltro)
        Me.GroupBox1.Controls.Add(Me.BtnAceptarFiltro)
        Me.GroupBox1.Controls.Add(Me.CbT2Fechas)
        Me.GroupBox1.Controls.Add(Me.dtFinal)
        Me.GroupBox1.Controls.Add(Me.dtInicio)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.CbT2Cliente)
        Me.GroupBox1.Controls.Add(Me.Label43)
        Me.GroupBox1.Controls.Add(Me.TxtClirut)
        Me.GroupBox1.Controls.Add(Me.btn_BuscaCliente)
        Me.GroupBox1.Controls.Add(Me.txtclinom)
        Me.GroupBox1.Controls.Add(Me.DgvVas)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(10, 85, 10, 10)
        Me.GroupBox1.Size = New System.Drawing.Size(1010, 377)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'BtnQuitarFiltro
        '
        Me.BtnQuitarFiltro.Location = New System.Drawing.Point(605, 58)
        Me.BtnQuitarFiltro.Name = "BtnQuitarFiltro"
        Me.BtnQuitarFiltro.Size = New System.Drawing.Size(126, 25)
        Me.BtnQuitarFiltro.TabIndex = 57
        Me.BtnQuitarFiltro.Text = "ELIMINAR FILTRO"
        Me.BtnQuitarFiltro.UseVisualStyleBackColor = True
        '
        'BtnAceptarFiltro
        '
        Me.BtnAceptarFiltro.Location = New System.Drawing.Point(604, 23)
        Me.BtnAceptarFiltro.Name = "BtnAceptarFiltro"
        Me.BtnAceptarFiltro.Size = New System.Drawing.Size(126, 25)
        Me.BtnAceptarFiltro.TabIndex = 56
        Me.BtnAceptarFiltro.Text = "ACEPTAR FILTRO"
        Me.BtnAceptarFiltro.UseVisualStyleBackColor = True
        '
        'CbT2Fechas
        '
        Me.CbT2Fechas.AutoSize = True
        Me.CbT2Fechas.Checked = True
        Me.CbT2Fechas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CbT2Fechas.ForeColor = System.Drawing.Color.White
        Me.CbT2Fechas.Location = New System.Drawing.Point(507, 68)
        Me.CbT2Fechas.Name = "CbT2Fechas"
        Me.CbT2Fechas.Size = New System.Drawing.Size(68, 17)
        Me.CbT2Fechas.TabIndex = 55
        Me.CbT2Fechas.Text = "TODOS"
        Me.CbT2Fechas.UseVisualStyleBackColor = True
        '
        'dtFinal
        '
        Me.dtFinal.Enabled = False
        Me.dtFinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFinal.Location = New System.Drawing.Point(387, 65)
        Me.dtFinal.Name = "dtFinal"
        Me.dtFinal.Size = New System.Drawing.Size(103, 21)
        Me.dtFinal.TabIndex = 54
        '
        'dtInicio
        '
        Me.dtInicio.Enabled = False
        Me.dtInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtInicio.Location = New System.Drawing.Point(125, 65)
        Me.dtInicio.Name = "dtInicio"
        Me.dtInicio.Size = New System.Drawing.Size(103, 21)
        Me.dtInicio.TabIndex = 53
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(284, 69)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 13)
        Me.Label2.TabIndex = 52
        Me.Label2.Text = "FECHA FINAL"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(7, 69)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 13)
        Me.Label1.TabIndex = 51
        Me.Label1.Text = "FECHA INICIAL"
        '
        'CbT2Cliente
        '
        Me.CbT2Cliente.AutoSize = True
        Me.CbT2Cliente.Checked = True
        Me.CbT2Cliente.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CbT2Cliente.ForeColor = System.Drawing.Color.White
        Me.CbT2Cliente.Location = New System.Drawing.Point(507, 30)
        Me.CbT2Cliente.Name = "CbT2Cliente"
        Me.CbT2Cliente.Size = New System.Drawing.Size(68, 17)
        Me.CbT2Cliente.TabIndex = 50
        Me.CbT2Cliente.Text = "TODOS"
        Me.CbT2Cliente.UseVisualStyleBackColor = True
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label43.ForeColor = System.Drawing.Color.White
        Me.Label43.Location = New System.Drawing.Point(7, 31)
        Me.Label43.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(56, 13)
        Me.Label43.TabIndex = 49
        Me.Label43.Text = "CLIENTE"
        '
        'TxtClirut
        '
        Me.TxtClirut.Location = New System.Drawing.Point(71, 27)
        Me.TxtClirut.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TxtClirut.MaxLength = 8
        Me.TxtClirut.Name = "TxtClirut"
        Me.TxtClirut.ReadOnly = True
        Me.TxtClirut.Size = New System.Drawing.Size(82, 21)
        Me.TxtClirut.TabIndex = 48
        '
        'btn_BuscaCliente
        '
        Me.btn_BuscaCliente.Enabled = False
        Me.btn_BuscaCliente.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.buscar_24
        Me.btn_BuscaCliente.Location = New System.Drawing.Point(156, 26)
        Me.btn_BuscaCliente.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btn_BuscaCliente.Name = "btn_BuscaCliente"
        Me.btn_BuscaCliente.Size = New System.Drawing.Size(21, 22)
        Me.btn_BuscaCliente.TabIndex = 46
        Me.btn_BuscaCliente.UseVisualStyleBackColor = True
        '
        'txtclinom
        '
        Me.txtclinom.Enabled = False
        Me.txtclinom.Location = New System.Drawing.Point(181, 27)
        Me.txtclinom.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtclinom.Name = "txtclinom"
        Me.txtclinom.ReadOnly = True
        Me.txtclinom.Size = New System.Drawing.Size(309, 21)
        Me.txtclinom.TabIndex = 47
        '
        'DgvVas
        '
        Me.DgvVas.AllowUserToAddRows = False
        Me.DgvVas.AllowUserToDeleteRows = False
        Me.DgvVas.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark
        Me.DgvVas.ColumnHeadersHeight = 30
        Me.DgvVas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Folio, Me.CLIENTE, Me.FECHA, Me.KILOS, Me.NCLIENTE, Me.SECCION})
        Me.DgvVas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvVas.Location = New System.Drawing.Point(10, 99)
        Me.DgvVas.Name = "DgvVas"
        Me.DgvVas.ReadOnly = True
        Me.DgvVas.Size = New System.Drawing.Size(990, 268)
        Me.DgvVas.TabIndex = 0
        '
        'Folio
        '
        Me.Folio.DataPropertyName = "VAS_COD"
        Me.Folio.HeaderText = "FOLIO"
        Me.Folio.Name = "Folio"
        Me.Folio.ReadOnly = True
        Me.Folio.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Folio.Width = 85
        '
        'CLIENTE
        '
        Me.CLIENTE.DataPropertyName = "CLI_NOMB"
        Me.CLIENTE.HeaderText = "CLIENTE"
        Me.CLIENTE.Name = "CLIENTE"
        Me.CLIENTE.ReadOnly = True
        Me.CLIENTE.Width = 350
        '
        'FECHA
        '
        Me.FECHA.DataPropertyName = "VAS_FECHA"
        Me.FECHA.HeaderText = "FECHA"
        Me.FECHA.Name = "FECHA"
        Me.FECHA.ReadOnly = True
        '
        'KILOS
        '
        Me.KILOS.DataPropertyName = "VAS_GUIA"
        DataGridViewCellStyle1.Format = "N2"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.KILOS.DefaultCellStyle = DataGridViewCellStyle1
        Me.KILOS.HeaderText = "N° CLIENTE"
        Me.KILOS.Name = "KILOS"
        Me.KILOS.ReadOnly = True
        '
        'NCLIENTE
        '
        Me.NCLIENTE.DataPropertyName = "VAS_DCTO"
        Me.NCLIENTE.HeaderText = "N° PRECISA"
        Me.NCLIENTE.Name = "NCLIENTE"
        Me.NCLIENTE.ReadOnly = True
        '
        'SECCION
        '
        Me.SECCION.DataPropertyName = "Sec_Desc"
        Me.SECCION.HeaderText = "SECCION"
        Me.SECCION.Name = "SECCION"
        Me.SECCION.ReadOnly = True
        Me.SECCION.Width = 180
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "VAS_COD"
        Me.DataGridViewTextBoxColumn1.HeaderText = "FOLIO"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn1.Width = 85
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "CLI_NOMB"
        Me.DataGridViewTextBoxColumn2.HeaderText = "CLIENTE"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 350
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "VAS_FECHA"
        Me.DataGridViewTextBoxColumn3.HeaderText = "FECHA"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "VAS_GUIA"
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.DataGridViewTextBoxColumn4.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewTextBoxColumn4.HeaderText = "N. PRECISA"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "VAS_DCTO"
        Me.DataGridViewTextBoxColumn5.HeaderText = "N. CLIENTE"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "Sec_Desc"
        Me.DataGridViewTextBoxColumn6.HeaderText = "SECCION"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Width = 180
        '
        'Frm_ListadoVas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(1034, 436)
        Me.Controls.Add(Me.BtnTodos)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "Frm_ListadoVas"
        Me.Text = "Listado documentos emitidos"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DgvVas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BtnTodos As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnQuitarFiltro As System.Windows.Forms.Button
    Friend WithEvents BtnAceptarFiltro As System.Windows.Forms.Button
    Friend WithEvents CbT2Fechas As System.Windows.Forms.CheckBox
    Friend WithEvents dtFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CbT2Cliente As System.Windows.Forms.CheckBox
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents TxtClirut As System.Windows.Forms.TextBox
    Friend WithEvents btn_BuscaCliente As System.Windows.Forms.Button
    Friend WithEvents txtclinom As System.Windows.Forms.TextBox
    Friend WithEvents DgvVas As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Folio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CLIENTE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECHA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KILOS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NCLIENTE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SECCION As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

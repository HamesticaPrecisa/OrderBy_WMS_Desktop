﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_EtiquetadoListado
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
        Me.DgvResultado = New System.Windows.Forms.DataGridView()
        Me.Folio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CLIENTE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECHA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SOPO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CAJAS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KILOS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DgvResultado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.GroupBox1.Controls.Add(Me.DgvResultado)
        Me.GroupBox1.Location = New System.Drawing.Point(11, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(12, 85, 12, 10)
        Me.GroupBox1.Size = New System.Drawing.Size(925, 349)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'BtnQuitarFiltro
        '
        Me.BtnQuitarFiltro.Location = New System.Drawing.Point(663, 60)
        Me.BtnQuitarFiltro.Name = "BtnQuitarFiltro"
        Me.BtnQuitarFiltro.Size = New System.Drawing.Size(147, 25)
        Me.BtnQuitarFiltro.TabIndex = 57
        Me.BtnQuitarFiltro.Text = "ELIMINAR FILTRO"
        Me.BtnQuitarFiltro.UseVisualStyleBackColor = True
        '
        'BtnAceptarFiltro
        '
        Me.BtnAceptarFiltro.Location = New System.Drawing.Point(662, 25)
        Me.BtnAceptarFiltro.Name = "BtnAceptarFiltro"
        Me.BtnAceptarFiltro.Size = New System.Drawing.Size(147, 25)
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
        Me.CbT2Fechas.Location = New System.Drawing.Point(591, 68)
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
        Me.dtFinal.Location = New System.Drawing.Point(451, 65)
        Me.dtFinal.Name = "dtFinal"
        Me.dtFinal.Size = New System.Drawing.Size(119, 21)
        Me.dtFinal.TabIndex = 54
        '
        'dtInicio
        '
        Me.dtInicio.Enabled = False
        Me.dtInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtInicio.Location = New System.Drawing.Point(146, 65)
        Me.dtInicio.Name = "dtInicio"
        Me.dtInicio.Size = New System.Drawing.Size(119, 21)
        Me.dtInicio.TabIndex = 53
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(331, 69)
        Me.Label2.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
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
        Me.Label1.Location = New System.Drawing.Point(8, 69)
        Me.Label1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
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
        Me.CbT2Cliente.Location = New System.Drawing.Point(591, 30)
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
        Me.Label43.Location = New System.Drawing.Point(8, 31)
        Me.Label43.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(56, 13)
        Me.Label43.TabIndex = 49
        Me.Label43.Text = "CLIENTE"
        '
        'TxtClirut
        '
        Me.TxtClirut.Location = New System.Drawing.Point(83, 27)
        Me.TxtClirut.Margin = New System.Windows.Forms.Padding(5, 3, 5, 3)
        Me.TxtClirut.MaxLength = 8
        Me.TxtClirut.Name = "TxtClirut"
        Me.TxtClirut.ReadOnly = True
        Me.TxtClirut.Size = New System.Drawing.Size(95, 21)
        Me.TxtClirut.TabIndex = 48
        '
        'btn_BuscaCliente
        '
        Me.btn_BuscaCliente.Enabled = False
        Me.btn_BuscaCliente.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.buscar_24
        Me.btn_BuscaCliente.Location = New System.Drawing.Point(182, 26)
        Me.btn_BuscaCliente.Margin = New System.Windows.Forms.Padding(5, 3, 5, 3)
        Me.btn_BuscaCliente.Name = "btn_BuscaCliente"
        Me.btn_BuscaCliente.Size = New System.Drawing.Size(24, 22)
        Me.btn_BuscaCliente.TabIndex = 46
        Me.btn_BuscaCliente.UseVisualStyleBackColor = True
        '
        'txtclinom
        '
        Me.txtclinom.Enabled = False
        Me.txtclinom.Location = New System.Drawing.Point(211, 27)
        Me.txtclinom.Margin = New System.Windows.Forms.Padding(5, 3, 5, 3)
        Me.txtclinom.Name = "txtclinom"
        Me.txtclinom.ReadOnly = True
        Me.txtclinom.Size = New System.Drawing.Size(360, 21)
        Me.txtclinom.TabIndex = 47
        '
        'DgvResultado
        '
        Me.DgvResultado.AllowUserToAddRows = False
        Me.DgvResultado.AllowUserToDeleteRows = False
        Me.DgvResultado.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark
        Me.DgvResultado.ColumnHeadersHeight = 30
        Me.DgvResultado.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Folio, Me.CLIENTE, Me.FECHA, Me.SOPO, Me.CAJAS, Me.KILOS})
        Me.DgvResultado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvResultado.Location = New System.Drawing.Point(12, 99)
        Me.DgvResultado.Name = "DgvResultado"
        Me.DgvResultado.ReadOnly = True
        Me.DgvResultado.Size = New System.Drawing.Size(901, 240)
        Me.DgvResultado.TabIndex = 0
        '
        'Folio
        '
        Me.Folio.DataPropertyName = "ETIQ_CODI"
        Me.Folio.HeaderText = "FOLIO"
        Me.Folio.Name = "Folio"
        Me.Folio.ReadOnly = True
        Me.Folio.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Folio.Width = 85
        '
        'CLIENTE
        '
        Me.CLIENTE.DataPropertyName = "cli_nomb"
        Me.CLIENTE.HeaderText = "CLIENTE"
        Me.CLIENTE.Name = "CLIENTE"
        Me.CLIENTE.ReadOnly = True
        Me.CLIENTE.Width = 350
        '
        'FECHA
        '
        Me.FECHA.DataPropertyName = "ETIQ_FECHA"
        Me.FECHA.HeaderText = "FECHA"
        Me.FECHA.Name = "FECHA"
        Me.FECHA.ReadOnly = True
        '
        'SOPO
        '
        Me.SOPO.DataPropertyName = "ETIQ_TOTSOPO"
        DataGridViewCellStyle1.Format = "N0"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.SOPO.DefaultCellStyle = DataGridViewCellStyle1
        Me.SOPO.HeaderText = "SOPOR."
        Me.SOPO.Name = "SOPO"
        Me.SOPO.ReadOnly = True
        '
        'CAJAS
        '
        Me.CAJAS.DataPropertyName = "ETIQ_TOTUNIDAD"
        DataGridViewCellStyle2.Format = "N0"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.CAJAS.DefaultCellStyle = DataGridViewCellStyle2
        Me.CAJAS.HeaderText = "CAJAS"
        Me.CAJAS.Name = "CAJAS"
        Me.CAJAS.ReadOnly = True
        '
        'KILOS
        '
        Me.KILOS.DataPropertyName = "ETIQ_TOTPESO"
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.KILOS.DefaultCellStyle = DataGridViewCellStyle3
        Me.KILOS.HeaderText = "PESO"
        Me.KILOS.Name = "KILOS"
        Me.KILOS.ReadOnly = True
        '
        'Frm_EtiquetadoListado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(948, 360)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "Frm_EtiquetadoListado"
        Me.Text = "Listado de Etiquetados"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DgvResultado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
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
    Friend WithEvents DgvResultado As System.Windows.Forms.DataGridView
    Friend WithEvents Folio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CLIENTE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECHA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SOPO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CAJAS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KILOS As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
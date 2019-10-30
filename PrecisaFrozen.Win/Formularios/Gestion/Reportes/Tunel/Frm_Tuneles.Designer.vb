<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Tuneles
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboEstatus = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LblCliente = New System.Windows.Forms.Label()
        Me.Btn_cliente = New System.Windows.Forms.Button()
        Me.Txtcliente = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btn_nuevo = New System.Windows.Forms.Button()
        Me.Btn_Salir = New System.Windows.Forms.Button()
        Me.Btn_Calcular = New System.Windows.Forms.Button()
        Me.btn_Imprimir = New System.Windows.Forms.Button()
        Me.DgvResultado = New System.Windows.Forms.DataGridView()
        Me.cam_descr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.descr_estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.numots = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.numpallets = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.kilos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cajas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.het = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.hpt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.feclim = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ott_iniciotunel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ott_finaltunel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cli_nomb = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DgvResultado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.cboEstatus)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.LblCliente)
        Me.GroupBox1.Controls.Add(Me.Btn_cliente)
        Me.GroupBox1.Controls.Add(Me.Txtcliente)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(554, 91)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'cboEstatus
        '
        Me.cboEstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEstatus.FormattingEnabled = True
        Me.cboEstatus.Items.AddRange(New Object() {"CUALQUIERA", "DISPONIBLE", "CARGANDO", "POR INICIAR", "EN PROCESO", "DETENIDO"})
        Me.cboEstatus.Location = New System.Drawing.Point(134, 25)
        Me.cboEstatus.Name = "cboEstatus"
        Me.cboEstatus.Size = New System.Drawing.Size(300, 21)
        Me.cboEstatus.TabIndex = 80
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(23, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 79
        Me.Label1.Text = "ESTATUS"
        '
        'LblCliente
        '
        Me.LblCliente.AutoSize = True
        Me.LblCliente.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.LblCliente.Location = New System.Drawing.Point(118, 64)
        Me.LblCliente.Name = "LblCliente"
        Me.LblCliente.Size = New System.Drawing.Size(10, 13)
        Me.LblCliente.TabIndex = 78
        Me.LblCliente.Text = " "
        Me.LblCliente.Visible = False
        '
        'Btn_cliente
        '
        Me.Btn_cliente.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.buscar_24
        Me.Btn_cliente.Location = New System.Drawing.Point(452, 58)
        Me.Btn_cliente.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Btn_cliente.Name = "Btn_cliente"
        Me.Btn_cliente.Size = New System.Drawing.Size(21, 22)
        Me.Btn_cliente.TabIndex = 73
        Me.Btn_cliente.UseVisualStyleBackColor = True
        '
        'Txtcliente
        '
        Me.Txtcliente.Enabled = False
        Me.Txtcliente.Location = New System.Drawing.Point(134, 60)
        Me.Txtcliente.Name = "Txtcliente"
        Me.Txtcliente.Size = New System.Drawing.Size(300, 20)
        Me.Txtcliente.TabIndex = 71
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(23, 63)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 69
        Me.Label2.Text = "CLIENTE"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.btn_nuevo)
        Me.GroupBox2.Controls.Add(Me.Btn_Salir)
        Me.GroupBox2.Controls.Add(Me.Btn_Calcular)
        Me.GroupBox2.Controls.Add(Me.btn_Imprimir)
        Me.GroupBox2.Location = New System.Drawing.Point(927, 103)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(76, 285)
        Me.GroupBox2.TabIndex = 98
        Me.GroupBox2.TabStop = False
        '
        'btn_nuevo
        '
        Me.btn_nuevo.Enabled = False
        Me.btn_nuevo.FlatAppearance.BorderSize = 0
        Me.btn_nuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_nuevo.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_hojanueva
        Me.btn_nuevo.Location = New System.Drawing.Point(7, 148)
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
        Me.Btn_Salir.Location = New System.Drawing.Point(7, 212)
        Me.Btn_Salir.Name = "Btn_Salir"
        Me.Btn_Salir.Size = New System.Drawing.Size(63, 63)
        Me.Btn_Salir.TabIndex = 89
        Me.Btn_Salir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Btn_Salir.UseVisualStyleBackColor = True
        '
        'Btn_Calcular
        '
        Me.Btn_Calcular.Enabled = False
        Me.Btn_Calcular.FlatAppearance.BorderSize = 0
        Me.Btn_Calcular.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_Calcular.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_soportante
        Me.Btn_Calcular.Location = New System.Drawing.Point(7, 19)
        Me.Btn_Calcular.Name = "Btn_Calcular"
        Me.Btn_Calcular.Size = New System.Drawing.Size(63, 63)
        Me.Btn_Calcular.TabIndex = 85
        Me.Btn_Calcular.UseVisualStyleBackColor = True
        '
        'btn_Imprimir
        '
        Me.btn_Imprimir.Enabled = False
        Me.btn_Imprimir.FlatAppearance.BorderSize = 0
        Me.btn_Imprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Imprimir.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_impresora
        Me.btn_Imprimir.Location = New System.Drawing.Point(7, 84)
        Me.btn_Imprimir.Name = "btn_Imprimir"
        Me.btn_Imprimir.Size = New System.Drawing.Size(63, 63)
        Me.btn_Imprimir.TabIndex = 85
        Me.btn_Imprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Imprimir.UseVisualStyleBackColor = True
        '
        'DgvResultado
        '
        Me.DgvResultado.AllowUserToAddRows = False
        Me.DgvResultado.AllowUserToDeleteRows = False
        Me.DgvResultado.BackgroundColor = System.Drawing.Color.DimGray
        Me.DgvResultado.ColumnHeadersHeight = 28
        Me.DgvResultado.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cam_descr, Me.descr_estado, Me.numots, Me.numpallets, Me.kilos, Me.cajas, Me.het, Me.hpt, Me.feclim, Me.ott_iniciotunel, Me.ott_finaltunel, Me.cli_nomb})
        Me.DgvResultado.Location = New System.Drawing.Point(12, 109)
        Me.DgvResultado.Name = "DgvResultado"
        Me.DgvResultado.ReadOnly = True
        Me.DgvResultado.Size = New System.Drawing.Size(890, 323)
        Me.DgvResultado.TabIndex = 99
        '
        'cam_descr
        '
        Me.cam_descr.HeaderText = "TUNEL"
        Me.cam_descr.Name = "cam_descr"
        Me.cam_descr.ReadOnly = True
        Me.cam_descr.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'descr_estado
        '
        Me.descr_estado.HeaderText = "ESTATUS"
        Me.descr_estado.Name = "descr_estado"
        Me.descr_estado.ReadOnly = True
        Me.descr_estado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.descr_estado.Width = 200
        '
        'numots
        '
        DataGridViewCellStyle1.Format = "N0"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.numots.DefaultCellStyle = DataGridViewCellStyle1
        Me.numots.HeaderText = "OTS"
        Me.numots.Name = "numots"
        Me.numots.ReadOnly = True
        Me.numots.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.numots.Width = 45
        '
        'numpallets
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N0"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.numpallets.DefaultCellStyle = DataGridViewCellStyle2
        Me.numpallets.HeaderText = "SOP"
        Me.numpallets.Name = "numpallets"
        Me.numpallets.ReadOnly = True
        Me.numpallets.Width = 55
        '
        'kilos
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N1"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.kilos.DefaultCellStyle = DataGridViewCellStyle3
        Me.kilos.HeaderText = "KILOS"
        Me.kilos.Name = "kilos"
        Me.kilos.ReadOnly = True
        Me.kilos.Width = 65
        '
        'cajas
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N0"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.cajas.DefaultCellStyle = DataGridViewCellStyle4
        Me.cajas.HeaderText = "CAJAS"
        Me.cajas.Name = "cajas"
        Me.cajas.ReadOnly = True
        Me.cajas.Width = 55
        '
        'het
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.Format = "N0"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.het.DefaultCellStyle = DataGridViewCellStyle5
        Me.het.HeaderText = "HET"
        Me.het.Name = "het"
        Me.het.ReadOnly = True
        Me.het.Width = 45
        '
        'hpt
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.Format = "N0"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.hpt.DefaultCellStyle = DataGridViewCellStyle6
        Me.hpt.HeaderText = "THT"
        Me.hpt.Name = "hpt"
        Me.hpt.ReadOnly = True
        Me.hpt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.hpt.Width = 45
        '
        'feclim
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "N0"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.feclim.DefaultCellStyle = DataGridViewCellStyle7
        Me.feclim.HeaderText = "HFT"
        Me.feclim.Name = "feclim"
        Me.feclim.ReadOnly = True
        Me.feclim.Width = 45
        '
        'ott_iniciotunel
        '
        DataGridViewCellStyle8.Format = "g"
        DataGridViewCellStyle8.NullValue = Nothing
        Me.ott_iniciotunel.DefaultCellStyle = DataGridViewCellStyle8
        Me.ott_iniciotunel.HeaderText = "INICIO"
        Me.ott_iniciotunel.Name = "ott_iniciotunel"
        Me.ott_iniciotunel.ReadOnly = True
        Me.ott_iniciotunel.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ott_iniciotunel.Width = 130
        '
        'ott_finaltunel
        '
        DataGridViewCellStyle9.Format = "g"
        DataGridViewCellStyle9.NullValue = Nothing
        Me.ott_finaltunel.DefaultCellStyle = DataGridViewCellStyle9
        Me.ott_finaltunel.HeaderText = "TERMINO"
        Me.ott_finaltunel.Name = "ott_finaltunel"
        Me.ott_finaltunel.ReadOnly = True
        '
        'cli_nomb
        '
        Me.cli_nomb.HeaderText = "CLIENTE"
        Me.cli_nomb.Name = "cli_nomb"
        Me.cli_nomb.ReadOnly = True
        Me.cli_nomb.Width = 200
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(12, 453)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(353, 13)
        Me.ProgressBar1.TabIndex = 100
        '
        'Frm_Tuneles
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(1015, 483)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.DgvResultado)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Frm_Tuneles"
        Me.Text = "Estado de túneles"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.DgvResultado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents LblCliente As System.Windows.Forms.Label
    Friend WithEvents Btn_cliente As System.Windows.Forms.Button
    Friend WithEvents Txtcliente As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_nuevo As System.Windows.Forms.Button
    Friend WithEvents Btn_Salir As System.Windows.Forms.Button
    Friend WithEvents Btn_Calcular As System.Windows.Forms.Button
    Friend WithEvents btn_Imprimir As System.Windows.Forms.Button
    Friend WithEvents DgvResultado As System.Windows.Forms.DataGridView
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents cboEstatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cam_descr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents descr_estado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents numots As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents numpallets As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents kilos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cajas As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents het As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents hpt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents feclim As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ott_iniciotunel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ott_finaltunel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cli_nomb As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_GuiasPendTunel
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.LblProducto = New System.Windows.Forms.Label()
        Me.T2producto = New System.Windows.Forms.CheckBox()
        Me.Btn_Producto = New System.Windows.Forms.Button()
        Me.TxtProducto = New System.Windows.Forms.TextBox()
        Me.LblCliente = New System.Windows.Forms.Label()
        Me.Btn_cliente = New System.Windows.Forms.Button()
        Me.Txtcliente = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btn_nuevo = New System.Windows.Forms.Button()
        Me.Btn_Salir = New System.Windows.Forms.Button()
        Me.Btn_Calcular = New System.Windows.Forms.Button()
        Me.btn_Imprimir = New System.Windows.Forms.Button()
        Me.DgvResultado = New System.Windows.Forms.DataGridView()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.frec_guiades = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cli_nomb = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.frec_fecrec = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.drec_fecprod = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.mer_nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.hpt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.numpallets = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DgvResultado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.LblProducto)
        Me.GroupBox1.Controls.Add(Me.T2producto)
        Me.GroupBox1.Controls.Add(Me.Btn_Producto)
        Me.GroupBox1.Controls.Add(Me.TxtProducto)
        Me.GroupBox1.Controls.Add(Me.LblCliente)
        Me.GroupBox1.Controls.Add(Me.Btn_cliente)
        Me.GroupBox1.Controls.Add(Me.Txtcliente)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(554, 91)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'LblProducto
        '
        Me.LblProducto.AutoSize = True
        Me.LblProducto.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.LblProducto.Location = New System.Drawing.Point(118, 55)
        Me.LblProducto.Name = "LblProducto"
        Me.LblProducto.Size = New System.Drawing.Size(10, 13)
        Me.LblProducto.TabIndex = 84
        Me.LblProducto.Text = " "
        Me.LblProducto.Visible = False
        '
        'T2producto
        '
        Me.T2producto.AutoSize = True
        Me.T2producto.BackColor = System.Drawing.Color.Transparent
        Me.T2producto.Checked = True
        Me.T2producto.CheckState = System.Windows.Forms.CheckState.Checked
        Me.T2producto.ForeColor = System.Drawing.Color.White
        Me.T2producto.Location = New System.Drawing.Point(480, 54)
        Me.T2producto.Name = "T2producto"
        Me.T2producto.Size = New System.Drawing.Size(64, 17)
        Me.T2producto.TabIndex = 83
        Me.T2producto.Text = "TODOS"
        Me.T2producto.UseVisualStyleBackColor = False
        '
        'Btn_Producto
        '
        Me.Btn_Producto.Enabled = False
        Me.Btn_Producto.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.buscar_24
        Me.Btn_Producto.Location = New System.Drawing.Point(452, 49)
        Me.Btn_Producto.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Btn_Producto.Name = "Btn_Producto"
        Me.Btn_Producto.Size = New System.Drawing.Size(21, 22)
        Me.Btn_Producto.TabIndex = 82
        Me.Btn_Producto.UseVisualStyleBackColor = True
        '
        'TxtProducto
        '
        Me.TxtProducto.Enabled = False
        Me.TxtProducto.Location = New System.Drawing.Point(134, 50)
        Me.TxtProducto.Name = "TxtProducto"
        Me.TxtProducto.Size = New System.Drawing.Size(300, 20)
        Me.TxtProducto.TabIndex = 81
        '
        'LblCliente
        '
        Me.LblCliente.AutoSize = True
        Me.LblCliente.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.LblCliente.Location = New System.Drawing.Point(118, 26)
        Me.LblCliente.Name = "LblCliente"
        Me.LblCliente.Size = New System.Drawing.Size(10, 13)
        Me.LblCliente.TabIndex = 78
        Me.LblCliente.Text = " "
        Me.LblCliente.Visible = False
        '
        'Btn_cliente
        '
        Me.Btn_cliente.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.buscar_24
        Me.Btn_cliente.Location = New System.Drawing.Point(452, 20)
        Me.Btn_cliente.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Btn_cliente.Name = "Btn_cliente"
        Me.Btn_cliente.Size = New System.Drawing.Size(21, 22)
        Me.Btn_cliente.TabIndex = 73
        Me.Btn_cliente.UseVisualStyleBackColor = True
        '
        'Txtcliente
        '
        Me.Txtcliente.Enabled = False
        Me.Txtcliente.Location = New System.Drawing.Point(134, 22)
        Me.Txtcliente.Name = "Txtcliente"
        Me.Txtcliente.Size = New System.Drawing.Size(300, 20)
        Me.Txtcliente.TabIndex = 71
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(23, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 69
        Me.Label2.Text = "CLIENTE"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(23, 53)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 13)
        Me.Label4.TabIndex = 80
        Me.Label4.Text = "PRODUCTO"
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
        Me.DgvResultado.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.frec_guiades, Me.cli_nomb, Me.frec_fecrec, Me.drec_fecprod, Me.mer_nombre, Me.hpt, Me.numpallets})
        Me.DgvResultado.Location = New System.Drawing.Point(12, 109)
        Me.DgvResultado.Name = "DgvResultado"
        Me.DgvResultado.ReadOnly = True
        Me.DgvResultado.Size = New System.Drawing.Size(890, 323)
        Me.DgvResultado.TabIndex = 99
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(12, 453)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(353, 13)
        Me.ProgressBar1.TabIndex = 100
        '
        'frec_guiades
        '
        Me.frec_guiades.HeaderText = "GUIA #"
        Me.frec_guiades.Name = "frec_guiades"
        Me.frec_guiades.ReadOnly = True
        Me.frec_guiades.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.frec_guiades.Width = 60
        '
        'cli_nomb
        '
        Me.cli_nomb.HeaderText = "CLIENTE"
        Me.cli_nomb.Name = "cli_nomb"
        Me.cli_nomb.ReadOnly = True
        Me.cli_nomb.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.cli_nomb.Width = 250
        '
        'frec_fecrec
        '
        Me.frec_fecrec.HeaderText = "FECHA RECEP"
        Me.frec_fecrec.Name = "frec_fecrec"
        Me.frec_fecrec.ReadOnly = True
        Me.frec_fecrec.Width = 80
        '
        'drec_fecprod
        '
        DataGridViewCellStyle1.NullValue = Nothing
        Me.drec_fecprod.DefaultCellStyle = DataGridViewCellStyle1
        Me.drec_fecprod.HeaderText = "FECHA ELAB"
        Me.drec_fecprod.Name = "drec_fecprod"
        Me.drec_fecprod.ReadOnly = True
        Me.drec_fecprod.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.drec_fecprod.Width = 80
        '
        'mer_nombre
        '
        DataGridViewCellStyle2.NullValue = Nothing
        Me.mer_nombre.DefaultCellStyle = DataGridViewCellStyle2
        Me.mer_nombre.HeaderText = "MERCADO"
        Me.mer_nombre.Name = "mer_nombre"
        Me.mer_nombre.ReadOnly = True
        Me.mer_nombre.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'hpt
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N0"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.hpt.DefaultCellStyle = DataGridViewCellStyle3
        Me.hpt.HeaderText = "HPT"
        Me.hpt.Name = "hpt"
        Me.hpt.ReadOnly = True
        Me.hpt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.hpt.Width = 45
        '
        'numpallets
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N0"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.numpallets.DefaultCellStyle = DataGridViewCellStyle4
        Me.numpallets.HeaderText = "SOP"
        Me.numpallets.Name = "numpallets"
        Me.numpallets.ReadOnly = True
        Me.numpallets.Width = 55
        '
        'Frm_GuiasPendTunel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(1015, 483)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.DgvResultado)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Frm_GuiasPendTunel"
        Me.Text = "Informe de guias por entrar a tunel"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.DgvResultado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents LblProducto As System.Windows.Forms.Label
    Friend WithEvents T2producto As System.Windows.Forms.CheckBox
    Friend WithEvents Btn_Producto As System.Windows.Forms.Button
    Friend WithEvents TxtProducto As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
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
    Friend WithEvents frec_guiades As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cli_nomb As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents frec_fecrec As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents drec_fecprod As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents mer_nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents hpt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents numpallets As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

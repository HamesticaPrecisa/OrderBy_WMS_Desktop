<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_TrazProductos
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
        Me.TxtClirut = New System.Windows.Forms.TextBox()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.btn_BuscaCliente = New System.Windows.Forms.Button()
        Me.txtclinom = New System.Windows.Forms.TextBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.FECHA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ENTRADA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SALIDA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SALDO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ENTRADACAJAS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SALIDACAJAS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SALDOCAJAS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ENTRADAKG = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SALIDAKG = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SALDOKG = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtprodcod = New System.Windows.Forms.TextBox()
        Me.Btn_buscaProducto = New System.Windows.Forms.Button()
        Me.txtprodnom = New System.Windows.Forms.TextBox()
        Me.btn_acp = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtinicial = New System.Windows.Forms.DateTimePicker()
        Me.dtfinal = New System.Windows.Forms.DateTimePicker()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TxtClirut
        '
        Me.TxtClirut.Enabled = False
        Me.TxtClirut.Location = New System.Drawing.Point(134, 30)
        Me.TxtClirut.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TxtClirut.MaxLength = 8
        Me.TxtClirut.Name = "TxtClirut"
        Me.TxtClirut.Size = New System.Drawing.Size(82, 21)
        Me.TxtClirut.TabIndex = 53
        '
        'Label43
        '
        Me.Label43.BackColor = System.Drawing.Color.Transparent
        Me.Label43.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label43.ForeColor = System.Drawing.Color.White
        Me.Label43.Location = New System.Drawing.Point(20, 29)
        Me.Label43.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(78, 21)
        Me.Label43.TabIndex = 52
        Me.Label43.Text = "CLIENTE"
        Me.Label43.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btn_BuscaCliente
        '
        Me.btn_BuscaCliente.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.buscar_24
        Me.btn_BuscaCliente.Location = New System.Drawing.Point(220, 29)
        Me.btn_BuscaCliente.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btn_BuscaCliente.Name = "btn_BuscaCliente"
        Me.btn_BuscaCliente.Size = New System.Drawing.Size(21, 22)
        Me.btn_BuscaCliente.TabIndex = 46
        Me.btn_BuscaCliente.UseVisualStyleBackColor = True
        '
        'txtclinom
        '
        Me.txtclinom.Enabled = False
        Me.txtclinom.Location = New System.Drawing.Point(244, 30)
        Me.txtclinom.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtclinom.Name = "txtclinom"
        Me.txtclinom.Size = New System.Drawing.Size(432, 21)
        Me.txtclinom.TabIndex = 47
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark
        Me.DataGridView1.ColumnHeadersHeight = 28
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FECHA, Me.ENTRADA, Me.SALIDA, Me.SALDO, Me.ENTRADACAJAS, Me.SALIDACAJAS, Me.SALDOCAJAS, Me.ENTRADAKG, Me.SALIDAKG, Me.SALDOKG})
        Me.DataGridView1.Location = New System.Drawing.Point(23, 165)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(822, 383)
        Me.DataGridView1.TabIndex = 54
        '
        'FECHA
        '
        Me.FECHA.HeaderText = "FECHA"
        Me.FECHA.Name = "FECHA"
        Me.FECHA.ReadOnly = True
        Me.FECHA.Width = 120
        '
        'ENTRADA
        '
        Me.ENTRADA.HeaderText = "ENTRADA "
        Me.ENTRADA.Name = "ENTRADA"
        Me.ENTRADA.ReadOnly = True
        Me.ENTRADA.Width = 70
        '
        'SALIDA
        '
        Me.SALIDA.HeaderText = "SALIDA"
        Me.SALIDA.Name = "SALIDA"
        Me.SALIDA.ReadOnly = True
        Me.SALIDA.Width = 70
        '
        'SALDO
        '
        Me.SALDO.HeaderText = "SALDO"
        Me.SALDO.Name = "SALDO"
        Me.SALDO.ReadOnly = True
        Me.SALDO.Width = 70
        '
        'ENTRADACAJAS
        '
        Me.ENTRADACAJAS.HeaderText = "ENTRADA"
        Me.ENTRADACAJAS.Name = "ENTRADACAJAS"
        Me.ENTRADACAJAS.ReadOnly = True
        Me.ENTRADACAJAS.Width = 70
        '
        'SALIDACAJAS
        '
        Me.SALIDACAJAS.HeaderText = "SALIDA"
        Me.SALIDACAJAS.Name = "SALIDACAJAS"
        Me.SALIDACAJAS.ReadOnly = True
        Me.SALIDACAJAS.Width = 70
        '
        'SALDOCAJAS
        '
        Me.SALDOCAJAS.HeaderText = "SALDO"
        Me.SALDOCAJAS.Name = "SALDOCAJAS"
        Me.SALDOCAJAS.ReadOnly = True
        Me.SALDOCAJAS.Width = 70
        '
        'ENTRADAKG
        '
        Me.ENTRADAKG.HeaderText = "ENTRADA"
        Me.ENTRADAKG.Name = "ENTRADAKG"
        Me.ENTRADAKG.ReadOnly = True
        Me.ENTRADAKG.Width = 70
        '
        'SALIDAKG
        '
        Me.SALIDAKG.HeaderText = "SALIDA"
        Me.SALIDAKG.Name = "SALIDAKG"
        Me.SALIDAKG.ReadOnly = True
        Me.SALIDAKG.Width = 70
        '
        'SALDOKG
        '
        Me.SALDOKG.HeaderText = "SALDO"
        Me.SALDOKG.Name = "SALDOKG"
        Me.SALDOKG.ReadOnly = True
        Me.SALDOKG.Width = 70
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.ForeColor = System.Drawing.Color.White
        Me.Label19.Location = New System.Drawing.Point(20, 62)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(73, 13)
        Me.Label19.TabIndex = 55
        Me.Label19.Text = "PRODUCTO"
        '
        'txtprodcod
        '
        Me.txtprodcod.Enabled = False
        Me.txtprodcod.Location = New System.Drawing.Point(134, 59)
        Me.txtprodcod.MaxLength = 7
        Me.txtprodcod.Name = "txtprodcod"
        Me.txtprodcod.Size = New System.Drawing.Size(82, 21)
        Me.txtprodcod.TabIndex = 56
        '
        'Btn_buscaProducto
        '
        Me.Btn_buscaProducto.Enabled = False
        Me.Btn_buscaProducto.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.buscar_24
        Me.Btn_buscaProducto.Location = New System.Drawing.Point(220, 58)
        Me.Btn_buscaProducto.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Btn_buscaProducto.Name = "Btn_buscaProducto"
        Me.Btn_buscaProducto.Size = New System.Drawing.Size(21, 22)
        Me.Btn_buscaProducto.TabIndex = 57
        Me.Btn_buscaProducto.UseVisualStyleBackColor = True
        '
        'txtprodnom
        '
        Me.txtprodnom.Enabled = False
        Me.txtprodnom.Location = New System.Drawing.Point(244, 59)
        Me.txtprodnom.Name = "txtprodnom"
        Me.txtprodnom.Size = New System.Drawing.Size(432, 21)
        Me.txtprodnom.TabIndex = 58
        '
        'btn_acp
        '
        Me.btn_acp.Location = New System.Drawing.Point(579, 102)
        Me.btn_acp.Name = "btn_acp"
        Me.btn_acp.Size = New System.Drawing.Size(97, 35)
        Me.btn_acp.TabIndex = 59
        Me.btn_acp.Text = "Aceptar"
        Me.btn_acp.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(20, 114)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 13)
        Me.Label1.TabIndex = 60
        Me.Label1.Text = "FECHA INICIAL"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(320, 114)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(102, 13)
        Me.Label2.TabIndex = 61
        Me.Label2.Text = "FECHA TERMINO"
        '
        'dtinicial
        '
        Me.dtinicial.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtinicial.Location = New System.Drawing.Point(134, 109)
        Me.dtinicial.Name = "dtinicial"
        Me.dtinicial.Size = New System.Drawing.Size(109, 21)
        Me.dtinicial.TabIndex = 62
        '
        'dtfinal
        '
        Me.dtfinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtfinal.Location = New System.Drawing.Point(428, 109)
        Me.dtfinal.Name = "dtfinal"
        Me.dtfinal.Size = New System.Drawing.Size(109, 21)
        Me.dtfinal.TabIndex = 63
        '
        'Frm_TrazProductos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(867, 560)
        Me.Controls.Add(Me.dtfinal)
        Me.Controls.Add(Me.dtinicial)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btn_acp)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.txtprodcod)
        Me.Controls.Add(Me.Btn_buscaProducto)
        Me.Controls.Add(Me.txtprodnom)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.TxtClirut)
        Me.Controls.Add(Me.Label43)
        Me.Controls.Add(Me.btn_BuscaCliente)
        Me.Controls.Add(Me.txtclinom)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "Frm_TrazProductos"
        Me.Text = "Trazabilidad de productos"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtClirut As System.Windows.Forms.TextBox
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents btn_BuscaCliente As System.Windows.Forms.Button
    Friend WithEvents txtclinom As System.Windows.Forms.TextBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtprodcod As System.Windows.Forms.TextBox
    Friend WithEvents Btn_buscaProducto As System.Windows.Forms.Button
    Friend WithEvents txtprodnom As System.Windows.Forms.TextBox
    Friend WithEvents btn_acp As System.Windows.Forms.Button
    Friend WithEvents PRODUCTO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtinicial As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtfinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents FECHA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ENTRADA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SALIDA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SALDO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ENTRADACAJAS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SALIDACAJAS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SALDOCAJAS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ENTRADAKG As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SALIDAKG As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SALDOKG As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

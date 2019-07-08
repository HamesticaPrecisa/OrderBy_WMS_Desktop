<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_NewTRa
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.BtnBuscar = New System.Windows.Forms.Button()
        Me.RbPrecisa = New System.Windows.Forms.RadioButton()
        Me.RbSoportante = New System.Windows.Forms.RadioButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtClirut = New System.Windows.Forms.TextBox()
        Me.btn_BuscaCliente = New System.Windows.Forms.Button()
        Me.txtclinom = New System.Windows.Forms.TextBox()
        Me.TxtSopoCliente = New System.Windows.Forms.TextBox()
        Me.TxtSopoPrecisa = New System.Windows.Forms.TextBox()
        Me.Dgv = New System.Windows.Forms.DataGridView()
        Me.Eliminar = New System.Windows.Forms.DataGridViewImageColumn()
        Me.pallet = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pro_cod = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Producto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.unid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.peso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.camara = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.banda = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columna = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.piso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nivel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SALDO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.DataGridViewImageColumn1 = New System.Windows.Forms.DataGridViewImageColumn()
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
        Me.GroupBox1.SuspendLayout()
        CType(Me.Dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.BtnBuscar)
        Me.GroupBox1.Controls.Add(Me.RbPrecisa)
        Me.GroupBox1.Controls.Add(Me.RbSoportante)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.TxtClirut)
        Me.GroupBox1.Controls.Add(Me.btn_BuscaCliente)
        Me.GroupBox1.Controls.Add(Me.txtclinom)
        Me.GroupBox1.Controls.Add(Me.TxtSopoCliente)
        Me.GroupBox1.Controls.Add(Me.TxtSopoPrecisa)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(912, 119)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(315, 24)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(189, 23)
        Me.Button1.TabIndex = 68
        Me.Button1.Text = "  TRAZABILIDAD DE CAJAS"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.UseVisualStyleBackColor = True
        '
        'BtnBuscar
        '
        Me.BtnBuscar.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.buscar2
        Me.BtnBuscar.Location = New System.Drawing.Point(840, 44)
        Me.BtnBuscar.Name = "BtnBuscar"
        Me.BtnBuscar.Size = New System.Drawing.Size(50, 50)
        Me.BtnBuscar.TabIndex = 67
        Me.BtnBuscar.UseVisualStyleBackColor = True
        '
        'RbPrecisa
        '
        Me.RbPrecisa.AutoSize = True
        Me.RbPrecisa.Checked = True
        Me.RbPrecisa.Location = New System.Drawing.Point(16, 27)
        Me.RbPrecisa.Name = "RbPrecisa"
        Me.RbPrecisa.Size = New System.Drawing.Size(102, 17)
        Me.RbPrecisa.TabIndex = 66
        Me.RbPrecisa.TabStop = True
        Me.RbPrecisa.Text = "SOPORTANTE "
        Me.RbPrecisa.UseVisualStyleBackColor = True
        '
        'RbSoportante
        '
        Me.RbSoportante.AutoSize = True
        Me.RbSoportante.Location = New System.Drawing.Point(16, 79)
        Me.RbSoportante.Name = "RbSoportante"
        Me.RbSoportante.Size = New System.Drawing.Size(147, 17)
        Me.RbSoportante.TabIndex = 65
        Me.RbSoportante.Text = "SOPORTANTE CLIENTE"
        Me.RbSoportante.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(312, 81)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 64
        Me.Label3.Text = "CLIENTE"
        '
        'TxtClirut
        '
        Me.TxtClirut.Enabled = False
        Me.TxtClirut.Location = New System.Drawing.Point(372, 77)
        Me.TxtClirut.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TxtClirut.Name = "TxtClirut"
        Me.TxtClirut.Size = New System.Drawing.Size(82, 20)
        Me.TxtClirut.TabIndex = 63
        '
        'btn_BuscaCliente
        '
        Me.btn_BuscaCliente.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.buscar_24
        Me.btn_BuscaCliente.Location = New System.Drawing.Point(457, 76)
        Me.btn_BuscaCliente.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btn_BuscaCliente.Name = "btn_BuscaCliente"
        Me.btn_BuscaCliente.Size = New System.Drawing.Size(21, 22)
        Me.btn_BuscaCliente.TabIndex = 61
        Me.btn_BuscaCliente.UseVisualStyleBackColor = True
        '
        'txtclinom
        '
        Me.txtclinom.Enabled = False
        Me.txtclinom.Location = New System.Drawing.Point(486, 77)
        Me.txtclinom.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtclinom.Name = "txtclinom"
        Me.txtclinom.Size = New System.Drawing.Size(293, 20)
        Me.txtclinom.TabIndex = 62
        '
        'TxtSopoCliente
        '
        Me.TxtSopoCliente.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSopoCliente.Location = New System.Drawing.Point(181, 77)
        Me.TxtSopoCliente.MaxLength = 11
        Me.TxtSopoCliente.Name = "TxtSopoCliente"
        Me.TxtSopoCliente.Size = New System.Drawing.Size(98, 22)
        Me.TxtSopoCliente.TabIndex = 60
        '
        'TxtSopoPrecisa
        '
        Me.TxtSopoPrecisa.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSopoPrecisa.Location = New System.Drawing.Point(181, 25)
        Me.TxtSopoPrecisa.MaxLength = 9
        Me.TxtSopoPrecisa.Name = "TxtSopoPrecisa"
        Me.TxtSopoPrecisa.Size = New System.Drawing.Size(98, 22)
        Me.TxtSopoPrecisa.TabIndex = 2
        '
        'Dgv
        '
        Me.Dgv.AllowUserToAddRows = False
        Me.Dgv.AllowUserToDeleteRows = False
        Me.Dgv.ColumnHeadersHeight = 28
        Me.Dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Eliminar, Me.pallet, Me.pro_cod, Me.Producto, Me.unid, Me.peso, Me.camara, Me.banda, Me.columna, Me.piso, Me.nivel, Me.SALDO})
        Me.Dgv.Location = New System.Drawing.Point(17, 137)
        Me.Dgv.Name = "Dgv"
        Me.Dgv.ReadOnly = True
        Me.Dgv.RowHeadersWidth = 20
        Me.Dgv.Size = New System.Drawing.Size(359, 532)
        Me.Dgv.TabIndex = 3
        '
        'Eliminar
        '
        Me.Eliminar.HeaderText = "ELIM."
        Me.Eliminar.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.Eliminar_16
        Me.Eliminar.Name = "Eliminar"
        Me.Eliminar.ReadOnly = True
        Me.Eliminar.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Eliminar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Eliminar.Width = 45
        '
        'pallet
        '
        Me.pallet.DataPropertyName = "dpre_folio"
        Me.pallet.HeaderText = "PALLET"
        Me.pallet.Name = "pallet"
        Me.pallet.ReadOnly = True
        Me.pallet.Width = 70
        '
        'pro_cod
        '
        Me.pro_cod.DataPropertyName = "dpre_codpro"
        Me.pro_cod.HeaderText = ""
        Me.pro_cod.MinimumWidth = 2
        Me.pro_cod.Name = "pro_cod"
        Me.pro_cod.ReadOnly = True
        Me.pro_cod.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.pro_cod.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.pro_cod.Width = 2
        '
        'Producto
        '
        Me.Producto.DataPropertyName = "prod"
        Me.Producto.HeaderText = "PRODUCTO"
        Me.Producto.Name = "Producto"
        Me.Producto.ReadOnly = True
        Me.Producto.Width = 200
        '
        'unid
        '
        Me.unid.DataPropertyName = "dpre_unidades"
        DataGridViewCellStyle1.Format = "N0"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.unid.DefaultCellStyle = DataGridViewCellStyle1
        Me.unid.HeaderText = "UNID"
        Me.unid.Name = "unid"
        Me.unid.ReadOnly = True
        Me.unid.Width = 60
        '
        'peso
        '
        Me.peso.DataPropertyName = "dpre_peso"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N3"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.peso.DefaultCellStyle = DataGridViewCellStyle2
        Me.peso.HeaderText = "PESO"
        Me.peso.Name = "peso"
        Me.peso.ReadOnly = True
        Me.peso.Width = 60
        '
        'camara
        '
        Me.camara.DataPropertyName = "dpre_camara"
        Me.camara.HeaderText = "CA"
        Me.camara.Name = "camara"
        Me.camara.ReadOnly = True
        Me.camara.Width = 35
        '
        'banda
        '
        Me.banda.DataPropertyName = "dpre_banda"
        Me.banda.HeaderText = "BA"
        Me.banda.Name = "banda"
        Me.banda.ReadOnly = True
        Me.banda.Width = 35
        '
        'columna
        '
        Me.columna.DataPropertyName = "dpre_colum"
        Me.columna.HeaderText = "CO"
        Me.columna.Name = "columna"
        Me.columna.ReadOnly = True
        Me.columna.Width = 35
        '
        'piso
        '
        Me.piso.DataPropertyName = "dpre_piso"
        Me.piso.HeaderText = "PI"
        Me.piso.Name = "piso"
        Me.piso.ReadOnly = True
        Me.piso.Width = 35
        '
        'nivel
        '
        Me.nivel.DataPropertyName = "dpre_nivel"
        Me.nivel.HeaderText = "NI"
        Me.nivel.Name = "nivel"
        Me.nivel.ReadOnly = True
        Me.nivel.Width = 35
        '
        'SALDO
        '
        Me.SALDO.HeaderText = "SALDO"
        Me.SALDO.MinimumWidth = 2
        Me.SALDO.Name = "SALDO"
        Me.SALDO.ReadOnly = True
        Me.SALDO.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.SALDO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.SALDO.Width = 2
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeight = 28
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewImageColumn1, Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn9, Me.DataGridViewTextBoxColumn10, Me.DataGridViewTextBoxColumn11})
        Me.DataGridView1.Location = New System.Drawing.Point(382, 137)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersWidth = 20
        Me.DataGridView1.Size = New System.Drawing.Size(542, 220)
        Me.DataGridView1.TabIndex = 4
        '
        'DataGridViewImageColumn1
        '
        Me.DataGridViewImageColumn1.HeaderText = "ELIM."
        Me.DataGridViewImageColumn1.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.Eliminar_16
        Me.DataGridViewImageColumn1.Name = "DataGridViewImageColumn1"
        Me.DataGridViewImageColumn1.ReadOnly = True
        Me.DataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewImageColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewImageColumn1.Width = 45
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "dpre_folio"
        Me.DataGridViewTextBoxColumn1.HeaderText = "PALLET"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 70
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "dpre_codpro"
        Me.DataGridViewTextBoxColumn2.HeaderText = ""
        Me.DataGridViewTextBoxColumn2.MinimumWidth = 2
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn2.Width = 2
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "prod"
        Me.DataGridViewTextBoxColumn3.HeaderText = "PRODUCTO"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 200
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "dpre_unidades"
        DataGridViewCellStyle3.Format = "N0"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.DataGridViewTextBoxColumn4.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewTextBoxColumn4.HeaderText = "UNID"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 60
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "dpre_peso"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N3"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.DataGridViewTextBoxColumn5.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewTextBoxColumn5.HeaderText = "PESO"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 60
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "dpre_camara"
        Me.DataGridViewTextBoxColumn6.HeaderText = "CA"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Width = 35
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "dpre_banda"
        Me.DataGridViewTextBoxColumn7.HeaderText = "BA"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Width = 35
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "dpre_colum"
        Me.DataGridViewTextBoxColumn8.HeaderText = "CO"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Width = 35
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "dpre_piso"
        Me.DataGridViewTextBoxColumn9.HeaderText = "PI"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        Me.DataGridViewTextBoxColumn9.Width = 35
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "dpre_nivel"
        Me.DataGridViewTextBoxColumn10.HeaderText = "NI"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        Me.DataGridViewTextBoxColumn10.Width = 35
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.HeaderText = "SALDO"
        Me.DataGridViewTextBoxColumn11.MinimumWidth = 2
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        Me.DataGridViewTextBoxColumn11.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn11.Width = 2
        '
        'Frm_NewTRa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(939, 681)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Dgv)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Frm_NewTRa"
        Me.Text = "Trazabilidad"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.Dgv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents BtnBuscar As System.Windows.Forms.Button
    Friend WithEvents RbPrecisa As System.Windows.Forms.RadioButton
    Friend WithEvents RbSoportante As System.Windows.Forms.RadioButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtClirut As System.Windows.Forms.TextBox
    Friend WithEvents btn_BuscaCliente As System.Windows.Forms.Button
    Friend WithEvents txtclinom As System.Windows.Forms.TextBox
    Friend WithEvents TxtSopoCliente As System.Windows.Forms.TextBox
    Friend WithEvents TxtSopoPrecisa As System.Windows.Forms.TextBox
    Friend WithEvents Dgv As System.Windows.Forms.DataGridView
    Friend WithEvents Eliminar As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents pallet As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pro_cod As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Producto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents unid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents peso As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents camara As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents banda As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columna As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents piso As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nivel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SALDO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewImageColumn1 As System.Windows.Forms.DataGridViewImageColumn
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
End Class

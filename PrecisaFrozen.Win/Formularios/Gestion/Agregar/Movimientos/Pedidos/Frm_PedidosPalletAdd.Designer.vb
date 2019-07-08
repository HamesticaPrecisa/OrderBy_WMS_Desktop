<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_PedidosPalletAdd
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_PedidosPalletAdd))
        Me.txtpallet = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtpedido = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.DgvCajas = New System.Windows.Forms.DataGridView()
        Me.cb = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ncaja = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Calidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Calibre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Lote = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Felab = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblcantidad = New System.Windows.Forms.Label()
        Me.cbtodos = New System.Windows.Forms.CheckBox()
        Me.lblseleccionadas = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DgvCajas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtpallet
        '
        Me.txtpallet.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpallet.Location = New System.Drawing.Point(107, 52)
        Me.txtpallet.Margin = New System.Windows.Forms.Padding(4)
        Me.txtpallet.Name = "txtpallet"
        Me.txtpallet.Size = New System.Drawing.Size(90, 23)
        Me.txtpallet.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(13, 52)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 23)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "N° de pallet"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(13, 20)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 23)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "N° de pedido"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtpedido
        '
        Me.txtpedido.Enabled = False
        Me.txtpedido.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpedido.Location = New System.Drawing.Point(107, 20)
        Me.txtpedido.Margin = New System.Windows.Forms.Padding(4)
        Me.txtpedido.Name = "txtpedido"
        Me.txtpedido.Size = New System.Drawing.Size(75, 23)
        Me.txtpedido.TabIndex = 2
        '
        'Button1
        '
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(214, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.Button1.Size = New System.Drawing.Size(100, 30)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "        Agregar"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.Eliminar_16
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(214, 72)
        Me.Button2.Name = "Button2"
        Me.Button2.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.Button2.Size = New System.Drawing.Size(100, 30)
        Me.Button2.TabIndex = 5
        Me.Button2.Text = "        Cancelar"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.UseVisualStyleBackColor = True
        '
        'DgvCajas
        '
        Me.DgvCajas.AllowUserToAddRows = False
        Me.DgvCajas.AllowUserToDeleteRows = False
        Me.DgvCajas.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark
        Me.DgvCajas.ColumnHeadersHeight = 28
        Me.DgvCajas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cb, Me.ncaja, Me.Calidad, Me.Calibre, Me.Lote, Me.Felab})
        Me.DgvCajas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvCajas.Location = New System.Drawing.Point(5, 170)
        Me.DgvCajas.Name = "DgvCajas"
        Me.DgvCajas.ReadOnly = True
        Me.DgvCajas.RowHeadersWidth = 25
        Me.DgvCajas.Size = New System.Drawing.Size(312, 280)
        Me.DgvCajas.TabIndex = 6
        '
        'cb
        '
        Me.cb.DataPropertyName = "cb"
        Me.cb.HeaderText = ""
        Me.cb.Name = "cb"
        Me.cb.ReadOnly = True
        Me.cb.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.cb.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.cb.Width = 20
        '
        'ncaja
        '
        Me.ncaja.DataPropertyName = "caj_cod"
        Me.ncaja.HeaderText = "Número de caja"
        Me.ncaja.Name = "ncaja"
        Me.ncaja.ReadOnly = True
        Me.ncaja.Width = 250
        '
        'Calidad
        '
        Me.Calidad.DataPropertyName = "caj_calidad"
        Me.Calidad.HeaderText = "Calidad"
        Me.Calidad.Name = "Calidad"
        Me.Calidad.ReadOnly = True
        '
        'Calibre
        '
        Me.Calibre.DataPropertyName = "caj_calibre"
        Me.Calibre.HeaderText = "Calibre"
        Me.Calibre.Name = "Calibre"
        Me.Calibre.ReadOnly = True
        '
        'Lote
        '
        Me.Lote.DataPropertyName = "caj_lote"
        Me.Lote.HeaderText = "Lote"
        Me.Lote.Name = "Lote"
        Me.Lote.ReadOnly = True
        '
        'Felab
        '
        Me.Felab.DataPropertyName = "caj_felab"
        Me.Felab.HeaderText = "F Elaboración"
        Me.Felab.Name = "Felab"
        Me.Felab.ReadOnly = True
        '
        'lblcantidad
        '
        Me.lblcantidad.AutoSize = True
        Me.lblcantidad.Location = New System.Drawing.Point(10, 102)
        Me.lblcantidad.Name = "lblcantidad"
        Me.lblcantidad.Size = New System.Drawing.Size(32, 18)
        Me.lblcantidad.TabIndex = 7
        Me.lblcantidad.Text = "        "
        '
        'cbtodos
        '
        Me.cbtodos.BackColor = System.Drawing.Color.Transparent
        Me.cbtodos.ForeColor = System.Drawing.Color.White
        Me.cbtodos.Location = New System.Drawing.Point(13, 140)
        Me.cbtodos.Name = "cbtodos"
        Me.cbtodos.Size = New System.Drawing.Size(112, 23)
        Me.cbtodos.TabIndex = 8
        Me.cbtodos.Text = "Marcar Todos"
        Me.cbtodos.UseVisualStyleBackColor = False
        '
        'lblseleccionadas
        '
        Me.lblseleccionadas.Location = New System.Drawing.Point(697, 549)
        Me.lblseleccionadas.Name = "lblseleccionadas"
        Me.lblseleccionadas.Size = New System.Drawing.Size(34, 18)
        Me.lblseleccionadas.TabIndex = 13
        Me.lblseleccionadas.Text = "0"
        Me.lblseleccionadas.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(555, 549)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(136, 18)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Cajas seleccionadas :"
        '
        'Button3
        '
        Me.Button3.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.Nuevo_16
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button3.Location = New System.Drawing.Point(214, 38)
        Me.Button3.Name = "Button3"
        Me.Button3.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.Button3.Size = New System.Drawing.Size(100, 30)
        Me.Button3.TabIndex = 14
        Me.Button3.Text = "        Nuevo"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button3.UseVisualStyleBackColor = True
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "caj_cod"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Número de caja"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 250
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "caj_calidad"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Calidad"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "caj_calibre"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Calibre"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "caj_lote"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Lote"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "caj_felab"
        Me.DataGridViewTextBoxColumn5.HeaderText = "F Elaboración"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'frm_PedidosPalletAdd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(322, 475)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.lblseleccionadas)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblcantidad)
        Me.Controls.Add(Me.DgvCajas)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtpedido)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtpallet)
        Me.Controls.Add(Me.cbtodos)
        Me.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_PedidosPalletAdd"
        Me.Padding = New System.Windows.Forms.Padding(5, 170, 5, 25)
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Agregar nuevo pallet al pedido"
        CType(Me.DgvCajas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtpallet As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtpedido As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents DgvCajas As System.Windows.Forms.DataGridView
    Friend WithEvents lblcantidad As System.Windows.Forms.Label
    Friend WithEvents cbtodos As System.Windows.Forms.CheckBox
    Friend WithEvents lblseleccionadas As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents cb As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ncaja As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Calidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Calibre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Lote As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Felab As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

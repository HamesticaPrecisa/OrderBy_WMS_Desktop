<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_ContratosDetalle
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_ContratosDetalle))
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgv_servicios = New System.Windows.Forms.DataGridView()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CbMonedas = New System.Windows.Forms.ComboBox()
        Me.BtnAsignar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tcliente = New System.Windows.Forms.TextBox()
        Me.tcontrato = New System.Windows.Forms.TextBox()
        Me.Dgv_Estado = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Valor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Dgv_Moneda = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Dgv_Medida = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Detalle = New System.Windows.Forms.DataGridViewImageColumn()
        Me.ESCALA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgv_servicios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgv_servicios
        '
        Me.dgv_servicios.AllowUserToAddRows = False
        Me.dgv_servicios.AllowUserToOrderColumns = True
        Me.dgv_servicios.ColumnHeadersHeight = 25
        Me.dgv_servicios.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Dgv_Estado, Me.Codigo, Me.Nombre, Me.Valor, Me.Dgv_Moneda, Me.Dgv_Medida, Me.Detalle, Me.ESCALA})
        Me.dgv_servicios.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_servicios.Location = New System.Drawing.Point(6, 75)
        Me.dgv_servicios.MultiSelect = False
        Me.dgv_servicios.Name = "dgv_servicios"
        Me.dgv_servicios.RowHeadersWidth = 25
        Me.dgv_servicios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_servicios.Size = New System.Drawing.Size(877, 621)
        Me.dgv_servicios.TabIndex = 2
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "NO.png")
        Me.ImageList1.Images.SetKeyName(1, "SI.png")
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "dcon_servcod"
        Me.DataGridViewTextBoxColumn1.HeaderText = "CODIGO"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn1.Width = 65
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "serv_nom"
        Me.DataGridViewTextBoxColumn2.HeaderText = "DESCRIPCION"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn2.Width = 300
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "dcon_valor"
        DataGridViewCellStyle2.NullValue = "0"
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewTextBoxColumn3.HeaderText = "VALOR"
        Me.DataGridViewTextBoxColumn3.MaxInputLength = 7
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn3.Width = 85
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "Serv_Esc"
        Me.DataGridViewTextBoxColumn4.HeaderText = "ESCALA"
        Me.DataGridViewTextBoxColumn4.MinimumWidth = 20
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn4.Width = 20
        '
        'Label1
        '
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(466, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(242, 24)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Asignar moneda automática"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CbMonedas
        '
        Me.CbMonedas.FormattingEnabled = True
        Me.CbMonedas.Location = New System.Drawing.Point(466, 37)
        Me.CbMonedas.Name = "CbMonedas"
        Me.CbMonedas.Size = New System.Drawing.Size(207, 23)
        Me.CbMonedas.TabIndex = 4
        '
        'BtnAsignar
        '
        Me.BtnAsignar.Location = New System.Drawing.Point(679, 37)
        Me.BtnAsignar.Name = "BtnAsignar"
        Me.BtnAsignar.Size = New System.Drawing.Size(29, 24)
        Me.BtnAsignar.TabIndex = 5
        Me.BtnAsignar.Text = "..."
        Me.BtnAsignar.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(9, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 24)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Cliente"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(9, 38)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(101, 24)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Contrato"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tcliente
        '
        Me.tcliente.Location = New System.Drawing.Point(116, 8)
        Me.tcliente.Name = "tcliente"
        Me.tcliente.ReadOnly = True
        Me.tcliente.Size = New System.Drawing.Size(332, 21)
        Me.tcliente.TabIndex = 8
        '
        'tcontrato
        '
        Me.tcontrato.Location = New System.Drawing.Point(116, 38)
        Me.tcontrato.Name = "tcontrato"
        Me.tcontrato.ReadOnly = True
        Me.tcontrato.Size = New System.Drawing.Size(332, 21)
        Me.tcontrato.TabIndex = 9
        '
        'Dgv_Estado
        '
        Me.Dgv_Estado.DataPropertyName = "Dcon_activo"
        Me.Dgv_Estado.Frozen = True
        Me.Dgv_Estado.HeaderText = "Estado"
        Me.Dgv_Estado.Name = "Dgv_Estado"
        Me.Dgv_Estado.ReadOnly = True
        Me.Dgv_Estado.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Dgv_Estado.Width = 53
        '
        'Codigo
        '
        Me.Codigo.DataPropertyName = "dcon_servcod"
        Me.Codigo.Frozen = True
        Me.Codigo.HeaderText = "Código"
        Me.Codigo.Name = "Codigo"
        Me.Codigo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Codigo.Width = 65
        '
        'Nombre
        '
        Me.Nombre.DataPropertyName = "serv_nom"
        Me.Nombre.Frozen = True
        Me.Nombre.HeaderText = "Descripción"
        Me.Nombre.Name = "Nombre"
        Me.Nombre.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Nombre.Width = 300
        '
        'Valor
        '
        Me.Valor.DataPropertyName = "dcon_valor"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.NullValue = "0"
        Me.Valor.DefaultCellStyle = DataGridViewCellStyle1
        Me.Valor.Frozen = True
        Me.Valor.HeaderText = "Valor"
        Me.Valor.MaxInputLength = 7
        Me.Valor.Name = "Valor"
        Me.Valor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Valor.Width = 85
        '
        'Dgv_Moneda
        '
        Me.Dgv_Moneda.DataPropertyName = "dcon_moneda"
        Me.Dgv_Moneda.Frozen = True
        Me.Dgv_Moneda.HeaderText = "Moneda"
        Me.Dgv_Moneda.Name = "Dgv_Moneda"
        Me.Dgv_Moneda.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Dgv_Moneda.Width = 120
        '
        'Dgv_Medida
        '
        Me.Dgv_Medida.DataPropertyName = "dcon_medida"
        Me.Dgv_Medida.Frozen = True
        Me.Dgv_Medida.HeaderText = "Medida"
        Me.Dgv_Medida.Name = "Dgv_Medida"
        Me.Dgv_Medida.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Dgv_Medida.Width = 120
        '
        'Detalle
        '
        Me.Detalle.Frozen = True
        Me.Detalle.HeaderText = "Detalle"
        Me.Detalle.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.Modificar_16
        Me.Detalle.Name = "Detalle"
        Me.Detalle.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Detalle.Width = 60
        '
        'ESCALA
        '
        Me.ESCALA.DataPropertyName = "Serv_Esc"
        Me.ESCALA.HeaderText = "Escala"
        Me.ESCALA.MinimumWidth = 2
        Me.ESCALA.Name = "ESCALA"
        Me.ESCALA.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ESCALA.Width = 2
        '
        'Frm_ContratosDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(889, 702)
        Me.Controls.Add(Me.tcontrato)
        Me.Controls.Add(Me.tcliente)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.BtnAsignar)
        Me.Controls.Add(Me.CbMonedas)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgv_servicios)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "Frm_ContratosDetalle"
        Me.Padding = New System.Windows.Forms.Padding(6, 75, 6, 6)
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Detalle Contratos"
        CType(Me.dgv_servicios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgv_servicios As System.Windows.Forms.DataGridView
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CbMonedas As System.Windows.Forms.ComboBox
    Friend WithEvents BtnAsignar As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tcliente As System.Windows.Forms.TextBox
    Friend WithEvents tcontrato As System.Windows.Forms.TextBox
    Friend WithEvents Dgv_Estado As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Codigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Valor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Dgv_Moneda As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Dgv_Medida As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Detalle As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents ESCALA As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

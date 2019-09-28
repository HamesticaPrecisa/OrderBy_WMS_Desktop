<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Detallemov
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
        Me.DgvEntradas = New System.Windows.Forms.DataGridView()
        Me.DgvSalidas = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
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
        Me.CODIGOD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ORIGEND = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PALLETSD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PALLETS_C = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CAJASD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KILOSD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODIGO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ORIGENR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CANTIDAD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CAJAS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KILOS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DgvEntradas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgvSalidas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DgvEntradas
        '
        Me.DgvEntradas.AllowUserToAddRows = False
        Me.DgvEntradas.AllowUserToDeleteRows = False
        Me.DgvEntradas.ColumnHeadersHeight = 28
        Me.DgvEntradas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CODIGO, Me.ORIGENR, Me.CANTIDAD, Me.CAJAS, Me.KILOS})
        Me.DgvEntradas.Location = New System.Drawing.Point(12, 37)
        Me.DgvEntradas.Name = "DgvEntradas"
        Me.DgvEntradas.ReadOnly = True
        Me.DgvEntradas.RowHeadersWidth = 30
        Me.DgvEntradas.Size = New System.Drawing.Size(615, 160)
        Me.DgvEntradas.TabIndex = 0
        '
        'DgvSalidas
        '
        Me.DgvSalidas.AllowUserToAddRows = False
        Me.DgvSalidas.AllowUserToDeleteRows = False
        Me.DgvSalidas.ColumnHeadersHeight = 28
        Me.DgvSalidas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CODIGOD, Me.ORIGEND, Me.PALLETSD, Me.PALLETS_C, Me.CAJASD, Me.KILOSD})
        Me.DgvSalidas.Location = New System.Drawing.Point(12, 240)
        Me.DgvSalidas.Name = "DgvSalidas"
        Me.DgvSalidas.ReadOnly = True
        Me.DgvSalidas.RowHeadersWidth = 30
        Me.DgvSalidas.Size = New System.Drawing.Size(615, 160)
        Me.DgvSalidas.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(206, 23)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "MOVIMIENTOS DE ENTRADA "
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Location = New System.Drawing.Point(12, 211)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(206, 23)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "MOVIMIENTOS DE SALIDA"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "codigo"
        Me.DataGridViewTextBoxColumn1.HeaderText = "CODIGO"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "ori_descr"
        Me.DataGridViewTextBoxColumn2.HeaderText = "ORIGEN"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 200
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "sopo"
        Me.DataGridViewTextBoxColumn3.HeaderText = "PALLETS"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 80
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "uni"
        Me.DataGridViewTextBoxColumn4.HeaderText = "CAJAS"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 80
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "pes"
        Me.DataGridViewTextBoxColumn5.HeaderText = "KILOS"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 80
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "codigo"
        Me.DataGridViewTextBoxColumn6.HeaderText = "CODIGOD"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "ori_descr"
        Me.DataGridViewTextBoxColumn7.HeaderText = "ORIGEN"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Width = 200
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "sopo"
        Me.DataGridViewTextBoxColumn8.HeaderText = "PALLETS"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Width = 80
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "SOPO_SC"
        Me.DataGridViewTextBoxColumn9.HeaderText = "CAJAS"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.Width = 80
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "uni"
        Me.DataGridViewTextBoxColumn10.HeaderText = "KILOS"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        Me.DataGridViewTextBoxColumn10.Width = 80
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "pes"
        Me.DataGridViewTextBoxColumn11.HeaderText = "KILOS"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        Me.DataGridViewTextBoxColumn11.Width = 80
        '
        'CODIGOD
        '
        Me.CODIGOD.DataPropertyName = "codigo"
        Me.CODIGOD.HeaderText = "CODIGO"
        Me.CODIGOD.Name = "CODIGOD"
        Me.CODIGOD.ReadOnly = True
        '
        'ORIGEND
        '
        Me.ORIGEND.DataPropertyName = "ori_descr"
        Me.ORIGEND.HeaderText = "ORIGEN"
        Me.ORIGEND.Name = "ORIGEND"
        Me.ORIGEND.ReadOnly = True
        Me.ORIGEND.Width = 200
        '
        'PALLETSD
        '
        Me.PALLETSD.DataPropertyName = "sopo"
        Me.PALLETSD.HeaderText = "PALLETS"
        Me.PALLETSD.Name = "PALLETSD"
        Me.PALLETSD.ReadOnly = True
        Me.PALLETSD.Width = 60
        '
        'PALLETS_C
        '
        Me.PALLETS_C.DataPropertyName = "SOPO_SC"
        Me.PALLETS_C.HeaderText = "COM"
        Me.PALLETS_C.Name = "PALLETS_C"
        Me.PALLETS_C.ReadOnly = True
        Me.PALLETS_C.Width = 50
        '
        'CAJASD
        '
        Me.CAJASD.DataPropertyName = "uni"
        Me.CAJASD.HeaderText = "CAJAS"
        Me.CAJASD.Name = "CAJASD"
        Me.CAJASD.ReadOnly = True
        Me.CAJASD.Width = 80
        '
        'KILOSD
        '
        Me.KILOSD.DataPropertyName = "pes"
        Me.KILOSD.HeaderText = "KILOS"
        Me.KILOSD.Name = "KILOSD"
        Me.KILOSD.ReadOnly = True
        Me.KILOSD.Width = 80
        '
        'CODIGO
        '
        Me.CODIGO.DataPropertyName = "codigo"
        Me.CODIGO.HeaderText = "CODIGO"
        Me.CODIGO.Name = "CODIGO"
        Me.CODIGO.ReadOnly = True
        '
        'ORIGENR
        '
        Me.ORIGENR.DataPropertyName = "ori_descr"
        Me.ORIGENR.HeaderText = "ORIGEN"
        Me.ORIGENR.Name = "ORIGENR"
        Me.ORIGENR.ReadOnly = True
        Me.ORIGENR.Width = 200
        '
        'CANTIDAD
        '
        Me.CANTIDAD.DataPropertyName = "sopo"
        Me.CANTIDAD.HeaderText = "PALLETS"
        Me.CANTIDAD.Name = "CANTIDAD"
        Me.CANTIDAD.ReadOnly = True
        Me.CANTIDAD.Width = 110
        '
        'CAJAS
        '
        Me.CAJAS.DataPropertyName = "uni"
        Me.CAJAS.HeaderText = "CAJAS"
        Me.CAJAS.Name = "CAJAS"
        Me.CAJAS.ReadOnly = True
        Me.CAJAS.Width = 80
        '
        'KILOS
        '
        Me.KILOS.DataPropertyName = "pes"
        Me.KILOS.HeaderText = "KILOS"
        Me.KILOS.Name = "KILOS"
        Me.KILOS.ReadOnly = True
        Me.KILOS.Width = 80
        '
        'Frm_Detallemov
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(640, 412)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DgvSalidas)
        Me.Controls.Add(Me.DgvEntradas)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Detallemov"
        Me.ShowIcon = False
        Me.Text = "Detalle Movimiento"
        CType(Me.DgvEntradas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgvSalidas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DgvEntradas As System.Windows.Forms.DataGridView
    Friend WithEvents DgvSalidas As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
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
    Friend WithEvents CODIGOD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ORIGEND As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PALLETSD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PALLETS_C As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CAJASD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KILOSD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODIGO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ORIGENR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CANTIDAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CAJAS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KILOS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

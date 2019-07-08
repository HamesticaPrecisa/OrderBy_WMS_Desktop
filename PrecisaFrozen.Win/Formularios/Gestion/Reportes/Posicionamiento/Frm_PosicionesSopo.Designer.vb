<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_PosicionesSopo
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DgvPosiciones = New System.Windows.Forms.DataGridView()
        Me.CODIGO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CLIENTE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRODUCTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PI = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NI = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CAJAS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KILOS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EL = New System.Windows.Forms.DataGridViewImageColumn()
        Me.TxtSoportante = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btn_nuevo = New System.Windows.Forms.Button()
        Me.Btn_Salir = New System.Windows.Forms.Button()
        Me.btn_Imprimir = New System.Windows.Forms.Button()
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
        CType(Me.DgvPosiciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(12, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "N° SOPORTANTE"
        '
        'DgvPosiciones
        '
        Me.DgvPosiciones.AllowUserToAddRows = False
        Me.DgvPosiciones.AllowUserToDeleteRows = False
        Me.DgvPosiciones.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark
        Me.DgvPosiciones.ColumnHeadersHeight = 28
        Me.DgvPosiciones.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CODIGO, Me.CLIENTE, Me.PRODUCTO, Me.CA, Me.BA, Me.CO, Me.PI, Me.NI, Me.CAJAS, Me.KILOS, Me.EL})
        Me.DgvPosiciones.Location = New System.Drawing.Point(15, 51)
        Me.DgvPosiciones.Name = "DgvPosiciones"
        Me.DgvPosiciones.ReadOnly = True
        Me.DgvPosiciones.Size = New System.Drawing.Size(1064, 429)
        Me.DgvPosiciones.TabIndex = 1
        '
        'CODIGO
        '
        Me.CODIGO.DataPropertyName = "racd_codi"
        Me.CODIGO.HeaderText = "CODIGO"
        Me.CODIGO.Name = "CODIGO"
        Me.CODIGO.ReadOnly = True
        Me.CODIGO.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.CODIGO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'CLIENTE
        '
        Me.CLIENTE.DataPropertyName = "CLI_NOMB"
        Me.CLIENTE.HeaderText = "CLIENTE"
        Me.CLIENTE.Name = "CLIENTE"
        Me.CLIENTE.ReadOnly = True
        Me.CLIENTE.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.CLIENTE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.CLIENTE.Width = 250
        '
        'PRODUCTO
        '
        Me.PRODUCTO.DataPropertyName = "producto"
        Me.PRODUCTO.HeaderText = "PRODUCTO"
        Me.PRODUCTO.Name = "PRODUCTO"
        Me.PRODUCTO.ReadOnly = True
        Me.PRODUCTO.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.PRODUCTO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.PRODUCTO.Width = 250
        '
        'CA
        '
        Me.CA.DataPropertyName = "racd_ca"
        Me.CA.HeaderText = "CA"
        Me.CA.Name = "CA"
        Me.CA.ReadOnly = True
        Me.CA.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.CA.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.CA.Width = 40
        '
        'BA
        '
        Me.BA.DataPropertyName = "racd_ba"
        Me.BA.HeaderText = "BA"
        Me.BA.Name = "BA"
        Me.BA.ReadOnly = True
        Me.BA.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.BA.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.BA.Width = 40
        '
        'CO
        '
        Me.CO.DataPropertyName = "racd_co"
        Me.CO.HeaderText = "CO"
        Me.CO.Name = "CO"
        Me.CO.ReadOnly = True
        Me.CO.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.CO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.CO.Width = 40
        '
        'PI
        '
        Me.PI.DataPropertyName = "racd_pi"
        Me.PI.HeaderText = "PI"
        Me.PI.Name = "PI"
        Me.PI.ReadOnly = True
        Me.PI.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.PI.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.PI.Width = 40
        '
        'NI
        '
        Me.NI.DataPropertyName = "racd_ni"
        Me.NI.HeaderText = "NI"
        Me.NI.Name = "NI"
        Me.NI.ReadOnly = True
        Me.NI.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.NI.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.NI.Width = 40
        '
        'CAJAS
        '
        Me.CAJAS.DataPropertyName = "racd_unidades"
        Me.CAJAS.HeaderText = "CAJAS"
        Me.CAJAS.Name = "CAJAS"
        Me.CAJAS.ReadOnly = True
        Me.CAJAS.Width = 75
        '
        'KILOS
        '
        Me.KILOS.DataPropertyName = "racd_peso"
        Me.KILOS.HeaderText = "KILOS"
        Me.KILOS.Name = "KILOS"
        Me.KILOS.ReadOnly = True
        Me.KILOS.Width = 75
        '
        'EL
        '
        Me.EL.HeaderText = "ELIM"
        Me.EL.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.Eliminar_16
        Me.EL.Name = "EL"
        Me.EL.ReadOnly = True
        Me.EL.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.EL.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.EL.Width = 40
        '
        'TxtSoportante
        '
        Me.TxtSoportante.Location = New System.Drawing.Point(121, 14)
        Me.TxtSoportante.Name = "TxtSoportante"
        Me.TxtSoportante.Size = New System.Drawing.Size(120, 21)
        Me.TxtSoportante.TabIndex = 2
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.btn_nuevo)
        Me.GroupBox2.Controls.Add(Me.Btn_Salir)
        Me.GroupBox2.Controls.Add(Me.btn_Imprimir)
        Me.GroupBox2.Location = New System.Drawing.Point(1099, 156)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(76, 219)
        Me.GroupBox2.TabIndex = 94
        Me.GroupBox2.TabStop = False
        '
        'btn_nuevo
        '
        Me.btn_nuevo.FlatAppearance.BorderSize = 0
        Me.btn_nuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_nuevo.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_hojanueva
        Me.btn_nuevo.Location = New System.Drawing.Point(6, 83)
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
        Me.Btn_Salir.Location = New System.Drawing.Point(6, 150)
        Me.Btn_Salir.Name = "Btn_Salir"
        Me.Btn_Salir.Size = New System.Drawing.Size(63, 63)
        Me.Btn_Salir.TabIndex = 89
        Me.Btn_Salir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Btn_Salir.UseVisualStyleBackColor = True
        '
        'btn_Imprimir
        '
        Me.btn_Imprimir.FlatAppearance.BorderSize = 0
        Me.btn_Imprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Imprimir.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_impresora
        Me.btn_Imprimir.Location = New System.Drawing.Point(6, 17)
        Me.btn_Imprimir.Name = "btn_Imprimir"
        Me.btn_Imprimir.Size = New System.Drawing.Size(63, 63)
        Me.btn_Imprimir.TabIndex = 85
        Me.btn_Imprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Imprimir.UseVisualStyleBackColor = True
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "racd_codi"
        Me.DataGridViewTextBoxColumn1.HeaderText = "CODIGO"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "producto"
        Me.DataGridViewTextBoxColumn2.HeaderText = "PRODUCTO"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.DataGridViewTextBoxColumn2.Width = 400
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "racd_ca"
        Me.DataGridViewTextBoxColumn3.HeaderText = "CA"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn3.Width = 40
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "racd_ba"
        Me.DataGridViewTextBoxColumn4.HeaderText = "BA"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn4.Width = 40
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "racd_co"
        Me.DataGridViewTextBoxColumn5.HeaderText = "CO"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn5.Width = 40
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "racd_pi"
        Me.DataGridViewTextBoxColumn6.HeaderText = "PI"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn6.Width = 40
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "racd_ni"
        Me.DataGridViewTextBoxColumn7.HeaderText = "NI"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn7.Width = 40
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "racd_ni"
        Me.DataGridViewTextBoxColumn8.HeaderText = "NI"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn8.Width = 40
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "RACD_UNIDADES"
        Me.DataGridViewTextBoxColumn9.HeaderText = "CAJAS"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        Me.DataGridViewTextBoxColumn9.Width = 75
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "RACD_PESO"
        Me.DataGridViewTextBoxColumn10.HeaderText = "KILOS"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        Me.DataGridViewTextBoxColumn10.Width = 75
        '
        'Frm_PosicionesSopo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(1187, 508)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.TxtSoportante)
        Me.Controls.Add(Me.DgvPosiciones)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "Frm_PosicionesSopo"
        Me.Text = "Posiciones"
        CType(Me.DgvPosiciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DgvPosiciones As System.Windows.Forms.DataGridView
    Friend WithEvents TxtSoportante As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_nuevo As System.Windows.Forms.Button
    Friend WithEvents Btn_Salir As System.Windows.Forms.Button
    Friend WithEvents btn_Imprimir As System.Windows.Forms.Button
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODIGO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CLIENTE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRODUCTO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PI As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NI As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CAJAS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KILOS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EL As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

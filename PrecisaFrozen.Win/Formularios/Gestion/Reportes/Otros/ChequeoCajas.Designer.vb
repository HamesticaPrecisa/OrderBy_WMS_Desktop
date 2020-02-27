<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChequeoCajas
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.DgvResultado = New System.Windows.Forms.DataGridView()
        Me.LblCliente = New System.Windows.Forms.Label()
        Me.Btn_cliente = New System.Windows.Forms.Button()
        Me.Txtcliente = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btn_nuevo = New System.Windows.Forms.Button()
        Me.Btn_Salir = New System.Windows.Forms.Button()
        Me.Btn_Calcular = New System.Windows.Forms.Button()
        Me.txtbusca = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtrutcli = New System.Windows.Forms.TextBox()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Caja = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Duplicados = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pallet1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pallet2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Recepcion1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Recepcion2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CLIENTE1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cliente2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DgvResultado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(12, 520)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(390, 13)
        Me.ProgressBar1.TabIndex = 98
        '
        'DgvResultado
        '
        Me.DgvResultado.AllowUserToAddRows = False
        Me.DgvResultado.AllowUserToDeleteRows = False
        Me.DgvResultado.BackgroundColor = System.Drawing.Color.DimGray
        Me.DgvResultado.ColumnHeadersHeight = 28
        Me.DgvResultado.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Caja, Me.Duplicados, Me.Pallet1, Me.Pallet2, Me.Recepcion1, Me.Recepcion2, Me.CLIENTE1, Me.Cliente2})
        Me.DgvResultado.Location = New System.Drawing.Point(12, 106)
        Me.DgvResultado.Name = "DgvResultado"
        Me.DgvResultado.ReadOnly = True
        Me.DgvResultado.Size = New System.Drawing.Size(1118, 408)
        Me.DgvResultado.TabIndex = 97
        '
        'LblCliente
        '
        Me.LblCliente.AutoSize = True
        Me.LblCliente.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.LblCliente.Location = New System.Drawing.Point(134, 27)
        Me.LblCliente.Name = "LblCliente"
        Me.LblCliente.Size = New System.Drawing.Size(10, 13)
        Me.LblCliente.TabIndex = 102
        Me.LblCliente.Text = " "
        Me.LblCliente.Visible = False
        '
        'Btn_cliente
        '
        Me.Btn_cliente.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.buscar_24
        Me.Btn_cliente.Location = New System.Drawing.Point(468, 21)
        Me.Btn_cliente.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Btn_cliente.Name = "Btn_cliente"
        Me.Btn_cliente.Size = New System.Drawing.Size(21, 22)
        Me.Btn_cliente.TabIndex = 101
        Me.Btn_cliente.UseVisualStyleBackColor = True
        '
        'Txtcliente
        '
        Me.Txtcliente.Enabled = False
        Me.Txtcliente.Location = New System.Drawing.Point(150, 23)
        Me.Txtcliente.Name = "Txtcliente"
        Me.Txtcliente.Size = New System.Drawing.Size(300, 20)
        Me.Txtcliente.TabIndex = 100
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(34, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 99
        Me.Label2.Text = "CLIENTE"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.btn_nuevo)
        Me.GroupBox2.Controls.Add(Me.Btn_Salir)
        Me.GroupBox2.Controls.Add(Me.Btn_Calcular)
        Me.GroupBox2.Location = New System.Drawing.Point(1147, 75)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(76, 285)
        Me.GroupBox2.TabIndex = 105
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
        Me.Btn_Calcular.FlatAppearance.BorderSize = 0
        Me.Btn_Calcular.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_Calcular.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_soportante
        Me.Btn_Calcular.Location = New System.Drawing.Point(7, 19)
        Me.Btn_Calcular.Name = "Btn_Calcular"
        Me.Btn_Calcular.Size = New System.Drawing.Size(63, 63)
        Me.Btn_Calcular.TabIndex = 85
        Me.Btn_Calcular.UseVisualStyleBackColor = True
        '
        'txtbusca
        '
        Me.txtbusca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtbusca.Enabled = False
        Me.txtbusca.HideSelection = False
        Me.txtbusca.Location = New System.Drawing.Point(150, 68)
        Me.txtbusca.Name = "txtbusca"
        Me.txtbusca.Size = New System.Drawing.Size(517, 20)
        Me.txtbusca.TabIndex = 91
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(34, 68)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 13)
        Me.Label1.TabIndex = 106
        Me.Label1.Text = "BUSQUEDA CAJA"
        '
        'txtrutcli
        '
        Me.txtrutcli.Enabled = False
        Me.txtrutcli.Location = New System.Drawing.Point(516, 21)
        Me.txtrutcli.Name = "txtrutcli"
        Me.txtrutcli.Size = New System.Drawing.Size(300, 20)
        Me.txtrutcli.TabIndex = 107
        Me.txtrutcli.Visible = False
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "Caja"
        Me.DataGridViewTextBoxColumn1.HeaderText = "CODIGO"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn1.Width = 70
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Duplicados"
        Me.DataGridViewTextBoxColumn2.HeaderText = "PRODUCTO"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn2.Width = 300
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "Pallet1"
        Me.DataGridViewTextBoxColumn3.HeaderText = "ENVASE"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 180
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "Pallet2"
        DataGridViewCellStyle4.Format = "N0"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.DataGridViewTextBoxColumn4.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewTextBoxColumn4.HeaderText = "SOPOR."
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn4.Width = 80
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "Recepcion1"
        DataGridViewCellStyle5.Format = "N0"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.DataGridViewTextBoxColumn5.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridViewTextBoxColumn5.HeaderText = "ENVASES"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn5.Width = 90
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "Recepcion2"
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.DataGridViewTextBoxColumn6.DefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridViewTextBoxColumn6.HeaderText = "PESO"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "Cliente1"
        Me.DataGridViewTextBoxColumn7.HeaderText = "CLIENTE1"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Width = 150
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "Cliente2"
        Me.DataGridViewTextBoxColumn8.HeaderText = "CLIENTE2"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Width = 150
        '
        'Caja
        '
        Me.Caja.DataPropertyName = "Caja"
        Me.Caja.HeaderText = "N CAJA"
        Me.Caja.Name = "Caja"
        Me.Caja.ReadOnly = True
        Me.Caja.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Duplicados
        '
        Me.Duplicados.DataPropertyName = "Duplicados"
        Me.Duplicados.HeaderText = "CANT."
        Me.Duplicados.Name = "Duplicados"
        Me.Duplicados.ReadOnly = True
        Me.Duplicados.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Duplicados.Width = 50
        '
        'Pallet1
        '
        Me.Pallet1.DataPropertyName = "Pallet1"
        Me.Pallet1.HeaderText = "PALLET1"
        Me.Pallet1.Name = "Pallet1"
        Me.Pallet1.ReadOnly = True
        '
        'Pallet2
        '
        Me.Pallet2.DataPropertyName = "Pallet2"
        DataGridViewCellStyle1.Format = "N0"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.Pallet2.DefaultCellStyle = DataGridViewCellStyle1
        Me.Pallet2.HeaderText = "PALLET2"
        Me.Pallet2.Name = "Pallet2"
        Me.Pallet2.ReadOnly = True
        Me.Pallet2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Recepcion1
        '
        Me.Recepcion1.DataPropertyName = "Recepcion1"
        DataGridViewCellStyle2.Format = "N0"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.Recepcion1.DefaultCellStyle = DataGridViewCellStyle2
        Me.Recepcion1.HeaderText = "RECEPCION1"
        Me.Recepcion1.Name = "Recepcion1"
        Me.Recepcion1.ReadOnly = True
        Me.Recepcion1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Recepcion2
        '
        Me.Recepcion2.DataPropertyName = "Recepcion2"
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.Recepcion2.DefaultCellStyle = DataGridViewCellStyle3
        Me.Recepcion2.HeaderText = "RECEPCION2"
        Me.Recepcion2.Name = "Recepcion2"
        Me.Recepcion2.ReadOnly = True
        Me.Recepcion2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'CLIENTE1
        '
        Me.CLIENTE1.DataPropertyName = "Cliente1"
        Me.CLIENTE1.HeaderText = "CLIENTE1"
        Me.CLIENTE1.Name = "CLIENTE1"
        Me.CLIENTE1.ReadOnly = True
        Me.CLIENTE1.Width = 150
        '
        'Cliente2
        '
        Me.Cliente2.DataPropertyName = "Cliente2"
        Me.Cliente2.HeaderText = "CLIENTE2"
        Me.Cliente2.Name = "Cliente2"
        Me.Cliente2.ReadOnly = True
        Me.Cliente2.Width = 150
        '
        'ChequeoCajas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(1296, 586)
        Me.Controls.Add(Me.txtrutcli)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtbusca)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.LblCliente)
        Me.Controls.Add(Me.Btn_cliente)
        Me.Controls.Add(Me.Txtcliente)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.DgvResultado)
        Me.Name = "ChequeoCajas"
        Me.Text = "ChequeoCajas"
        CType(Me.DgvResultado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents DgvResultado As System.Windows.Forms.DataGridView
    Friend WithEvents LblCliente As System.Windows.Forms.Label
    Friend WithEvents Btn_cliente As System.Windows.Forms.Button
    Friend WithEvents Txtcliente As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_nuevo As System.Windows.Forms.Button
    Friend WithEvents Btn_Salir As System.Windows.Forms.Button
    Friend WithEvents Btn_Calcular As System.Windows.Forms.Button
    Friend WithEvents txtbusca As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtrutcli As System.Windows.Forms.TextBox
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Caja As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Duplicados As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Pallet1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Pallet2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Recepcion1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Recepcion2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CLIENTE1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cliente2 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

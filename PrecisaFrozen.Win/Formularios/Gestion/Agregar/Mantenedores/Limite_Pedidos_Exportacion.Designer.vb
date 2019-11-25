<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Limite_Pedidos_Exportacion
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Limite_Pedidos_Exportacion))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtLimDia = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtIDLim = New System.Windows.Forms.TextBox()
        Me.txtNomLim = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.gvDet = New System.Windows.Forms.DataGridView()
        Me.btnAddCli = New System.Windows.Forms.Button()
        Me.TxtClirut = New System.Windows.Forms.TextBox()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.txtclinom = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.DataGridViewImageColumn1 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.btnEli = New System.Windows.Forms.Button()
        Me.btnGra = New System.Windows.Forms.Button()
        Me.btnVol = New System.Windows.Forms.Button()
        Me.btnLim = New System.Windows.Forms.Button()
        Me.btnElim = New System.Windows.Forms.DataGridViewImageColumn()
        Me.btn_BuscaCliente = New System.Windows.Forms.Button()
        Me.btnBusLim = New System.Windows.Forms.Button()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Rut_Cliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nom_Cliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.gvDet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtLimDia)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtIDLim)
        Me.GroupBox1.Controls.Add(Me.txtNomLim)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.btnBusLim)
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(20, 18)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(565, 104)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "LÍMITE"
        '
        'txtLimDia
        '
        Me.txtLimDia.Location = New System.Drawing.Point(158, 49)
        Me.txtLimDia.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtLimDia.MaxLength = 8
        Me.txtLimDia.Name = "txtLimDia"
        Me.txtLimDia.Size = New System.Drawing.Size(67, 20)
        Me.txtLimDia.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(7, 48)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(130, 21)
        Me.Label1.TabIndex = 56
        Me.Label1.Text = "LÍMITE DIARIO"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtIDLim
        '
        Me.txtIDLim.Location = New System.Drawing.Point(319, 23)
        Me.txtIDLim.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtIDLim.MaxLength = 8
        Me.txtIDLim.Name = "txtIDLim"
        Me.txtIDLim.Size = New System.Drawing.Size(94, 20)
        Me.txtIDLim.TabIndex = 55
        Me.txtIDLim.Visible = False
        '
        'txtNomLim
        '
        Me.txtNomLim.Location = New System.Drawing.Point(158, 23)
        Me.txtNomLim.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtNomLim.MaxLength = 8
        Me.txtNomLim.Name = "txtNomLim"
        Me.txtNomLim.Size = New System.Drawing.Size(106, 20)
        Me.txtNomLim.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(7, 22)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(130, 21)
        Me.Label2.TabIndex = 53
        Me.Label2.Text = "NOMBRE LÍMITE"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.gvDet)
        Me.GroupBox2.Controls.Add(Me.btnAddCli)
        Me.GroupBox2.Controls.Add(Me.TxtClirut)
        Me.GroupBox2.Controls.Add(Me.Label43)
        Me.GroupBox2.Controls.Add(Me.btn_BuscaCliente)
        Me.GroupBox2.Controls.Add(Me.txtclinom)
        Me.GroupBox2.ForeColor = System.Drawing.Color.White
        Me.GroupBox2.Location = New System.Drawing.Point(20, 128)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(565, 449)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "CLIENTES"
        '
        'gvDet
        '
        Me.gvDet.AllowUserToAddRows = False
        Me.gvDet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvDet.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Rut_Cliente, Me.Nom_Cliente, Me.btnElim})
        Me.gvDet.Location = New System.Drawing.Point(10, 104)
        Me.gvDet.Name = "gvDet"
        Me.gvDet.ReadOnly = True
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        Me.gvDet.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.gvDet.Size = New System.Drawing.Size(549, 332)
        Me.gvDet.TabIndex = 6
        '
        'btnAddCli
        '
        Me.btnAddCli.ForeColor = System.Drawing.Color.Black
        Me.btnAddCli.Location = New System.Drawing.Point(158, 76)
        Me.btnAddCli.Name = "btnAddCli"
        Me.btnAddCli.Size = New System.Drawing.Size(151, 23)
        Me.btnAddCli.TabIndex = 5
        Me.btnAddCli.Text = "ASIGNAR CLIENTE"
        Me.btnAddCli.UseVisualStyleBackColor = True
        '
        'TxtClirut
        '
        Me.TxtClirut.Enabled = False
        Me.TxtClirut.Location = New System.Drawing.Point(158, 24)
        Me.TxtClirut.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TxtClirut.MaxLength = 8
        Me.TxtClirut.Name = "TxtClirut"
        Me.TxtClirut.Size = New System.Drawing.Size(104, 20)
        Me.TxtClirut.TabIndex = 3
        '
        'Label43
        '
        Me.Label43.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label43.Location = New System.Drawing.Point(7, 23)
        Me.Label43.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(110, 21)
        Me.Label43.TabIndex = 48
        Me.Label43.Text = "CLIENTE"
        Me.Label43.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtclinom
        '
        Me.txtclinom.Enabled = False
        Me.txtclinom.Location = New System.Drawing.Point(158, 50)
        Me.txtclinom.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtclinom.Name = "txtclinom"
        Me.txtclinom.Size = New System.Drawing.Size(211, 20)
        Me.txtclinom.TabIndex = 47
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.btnEli)
        Me.GroupBox4.Controls.Add(Me.btnGra)
        Me.GroupBox4.Controls.Add(Me.btnVol)
        Me.GroupBox4.Controls.Add(Me.btnLim)
        Me.GroupBox4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(591, 18)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(99, 290)
        Me.GroupBox4.TabIndex = 58
        Me.GroupBox4.TabStop = False
        '
        'DataGridViewImageColumn1
        '
        Me.DataGridViewImageColumn1.Frozen = True
        Me.DataGridViewImageColumn1.HeaderText = "ELIMINAR"
        Me.DataGridViewImageColumn1.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.Eliminar_16
        Me.DataGridViewImageColumn1.Name = "DataGridViewImageColumn1"
        '
        'btnEli
        '
        Me.btnEli.FlatAppearance.BorderSize = 0
        Me.btnEli.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEli.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_hojamenos
        Me.btnEli.Location = New System.Drawing.Point(6, 147)
        Me.btnEli.Name = "btnEli"
        Me.btnEli.Size = New System.Drawing.Size(87, 63)
        Me.btnEli.TabIndex = 9
        Me.btnEli.UseVisualStyleBackColor = True
        '
        'btnGra
        '
        Me.btnGra.FlatAppearance.BorderSize = 0
        Me.btnGra.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGra.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_guardar2
        Me.btnGra.Location = New System.Drawing.Point(6, 18)
        Me.btnGra.Name = "btnGra"
        Me.btnGra.Size = New System.Drawing.Size(87, 63)
        Me.btnGra.TabIndex = 7
        Me.btnGra.UseVisualStyleBackColor = True
        '
        'btnVol
        '
        Me.btnVol.FlatAppearance.BorderSize = 0
        Me.btnVol.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnVol.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_salida
        Me.btnVol.Location = New System.Drawing.Point(6, 211)
        Me.btnVol.Name = "btnVol"
        Me.btnVol.Size = New System.Drawing.Size(87, 61)
        Me.btnVol.TabIndex = 10
        Me.btnVol.UseVisualStyleBackColor = True
        '
        'btnLim
        '
        Me.btnLim.FlatAppearance.BorderSize = 0
        Me.btnLim.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLim.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_hojanueva
        Me.btnLim.Location = New System.Drawing.Point(6, 83)
        Me.btnLim.Name = "btnLim"
        Me.btnLim.Size = New System.Drawing.Size(87, 63)
        Me.btnLim.TabIndex = 8
        Me.btnLim.UseVisualStyleBackColor = True
        '
        'btnElim
        '
        Me.btnElim.Frozen = True
        Me.btnElim.HeaderText = "ELIMINAR"
        Me.btnElim.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.Eliminar_16
        Me.btnElim.Name = "btnElim"
        Me.btnElim.ReadOnly = True
        '
        'btn_BuscaCliente
        '
        Me.btn_BuscaCliente.Image = CType(resources.GetObject("btn_BuscaCliente.Image"), System.Drawing.Image)
        Me.btn_BuscaCliente.Location = New System.Drawing.Point(270, 23)
        Me.btn_BuscaCliente.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btn_BuscaCliente.Name = "btn_BuscaCliente"
        Me.btn_BuscaCliente.Size = New System.Drawing.Size(39, 22)
        Me.btn_BuscaCliente.TabIndex = 4
        Me.btn_BuscaCliente.UseVisualStyleBackColor = True
        '
        'btnBusLim
        '
        Me.btnBusLim.Image = CType(resources.GetObject("btnBusLim.Image"), System.Drawing.Image)
        Me.btnBusLim.Location = New System.Drawing.Point(272, 21)
        Me.btnBusLim.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnBusLim.Name = "btnBusLim"
        Me.btnBusLim.Size = New System.Drawing.Size(39, 22)
        Me.btnBusLim.TabIndex = 1
        Me.btnBusLim.UseVisualStyleBackColor = True
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "ID"
        Me.DataGridViewTextBoxColumn1.Frozen = True
        Me.DataGridViewTextBoxColumn1.HeaderText = "ID"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "ID_Limite_Grupo"
        Me.DataGridViewTextBoxColumn2.Frozen = True
        Me.DataGridViewTextBoxColumn2.HeaderText = "ID_Limite"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Visible = False
        '
        'Rut_Cliente
        '
        Me.Rut_Cliente.DataPropertyName = "Rut_Cliente"
        Me.Rut_Cliente.Frozen = True
        Me.Rut_Cliente.HeaderText = "RUT"
        Me.Rut_Cliente.Name = "Rut_Cliente"
        Me.Rut_Cliente.ReadOnly = True
        '
        'Nom_Cliente
        '
        Me.Nom_Cliente.DataPropertyName = "Nombre_Cliente"
        Me.Nom_Cliente.Frozen = True
        Me.Nom_Cliente.HeaderText = "CLIENTE"
        Me.Nom_Cliente.Name = "Nom_Cliente"
        Me.Nom_Cliente.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "Rut_Cliente"
        Me.DataGridViewTextBoxColumn3.Frozen = True
        Me.DataGridViewTextBoxColumn3.HeaderText = "RUT"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "Nombre_Cliente"
        Me.DataGridViewTextBoxColumn4.Frozen = True
        Me.DataGridViewTextBoxColumn4.HeaderText = "CLIENTE"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'Limite_Pedidos_Exportacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(702, 595)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Limite_Pedidos_Exportacion"
        Me.Text = "Límite Pedidos Exportación"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.gvDet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtLimDia As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtIDLim As System.Windows.Forms.TextBox
    Friend WithEvents txtNomLim As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnBusLim As System.Windows.Forms.Button
    Friend WithEvents TxtClirut As System.Windows.Forms.TextBox
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents btn_BuscaCliente As System.Windows.Forms.Button
    Friend WithEvents txtclinom As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btnEli As System.Windows.Forms.Button
    Friend WithEvents btnGra As System.Windows.Forms.Button
    Friend WithEvents btnVol As System.Windows.Forms.Button
    Friend WithEvents btnLim As System.Windows.Forms.Button
    Friend WithEvents gvDet As System.Windows.Forms.DataGridView
    Friend WithEvents btnAddCli As System.Windows.Forms.Button
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Rut_Cliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nom_Cliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnElim As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents DataGridViewImageColumn1 As System.Windows.Forms.DataGridViewImageColumn
End Class

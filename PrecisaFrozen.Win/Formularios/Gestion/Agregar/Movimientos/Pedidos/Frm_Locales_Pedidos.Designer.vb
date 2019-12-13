<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Locales_Pedidos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Locales_Pedidos))
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.txtIdLoc = New System.Windows.Forms.TextBox()
        Me.txtDir = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtNomLoc = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCodCli = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtrsocial = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Btn_BuscaCliente = New System.Windows.Forms.Button()
        Me.txtrut = New System.Windows.Forms.MaskedTextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.btnEli = New System.Windows.Forms.Button()
        Me.btnGra = New System.Windows.Forms.Button()
        Me.btnSal = New System.Windows.Forms.Button()
        Me.btnLim = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dgvLocs = New System.Windows.Forms.DataGridView()
        Me.ID_Local = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Codigo_Cliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nombre_Local = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Direccion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvLocs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label22)
        Me.GroupBox3.Location = New System.Drawing.Point(14, 13)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(728, 34)
        Me.GroupBox3.TabIndex = 76
        Me.GroupBox3.TabStop = False
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.White
        Me.Label22.Location = New System.Drawing.Point(308, 13)
        Me.Label22.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(112, 13)
        Me.Label22.TabIndex = 69
        Me.Label22.Text = "Locales Clientes"
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.Label21)
        Me.GroupBox6.Controls.Add(Me.txtIdLoc)
        Me.GroupBox6.Controls.Add(Me.txtDir)
        Me.GroupBox6.Controls.Add(Me.Label3)
        Me.GroupBox6.Controls.Add(Me.txtNomLoc)
        Me.GroupBox6.Controls.Add(Me.Label2)
        Me.GroupBox6.Controls.Add(Me.txtCodCli)
        Me.GroupBox6.Controls.Add(Me.Label1)
        Me.GroupBox6.Controls.Add(Me.txtrsocial)
        Me.GroupBox6.Controls.Add(Me.Label24)
        Me.GroupBox6.Controls.Add(Me.Btn_BuscaCliente)
        Me.GroupBox6.Controls.Add(Me.txtrut)
        Me.GroupBox6.Controls.Add(Me.Label7)
        Me.GroupBox6.Location = New System.Drawing.Point(14, 53)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(621, 208)
        Me.GroupBox6.TabIndex = 77
        Me.GroupBox6.TabStop = False
        '
        'txtIdLoc
        '
        Me.txtIdLoc.Location = New System.Drawing.Point(336, 20)
        Me.txtIdLoc.Name = "txtIdLoc"
        Me.txtIdLoc.Size = New System.Drawing.Size(155, 20)
        Me.txtIdLoc.TabIndex = 79
        Me.txtIdLoc.Visible = False
        '
        'txtDir
        '
        Me.txtDir.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDir.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDir.Location = New System.Drawing.Point(190, 129)
        Me.txtDir.MaxLength = 40
        Me.txtDir.Multiline = True
        Me.txtDir.Name = "txtDir"
        Me.txtDir.Size = New System.Drawing.Size(301, 50)
        Me.txtDir.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(12, 133)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 13)
        Me.Label3.TabIndex = 77
        Me.Label3.Text = "Dirección"
        '
        'txtNomLoc
        '
        Me.txtNomLoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNomLoc.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNomLoc.Location = New System.Drawing.Point(190, 102)
        Me.txtNomLoc.MaxLength = 40
        Me.txtNomLoc.Name = "txtNomLoc"
        Me.txtNomLoc.Size = New System.Drawing.Size(301, 21)
        Me.txtNomLoc.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(12, 106)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 13)
        Me.Label2.TabIndex = 75
        Me.Label2.Text = "* Nombre Local"
        '
        'txtCodCli
        '
        Me.txtCodCli.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodCli.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodCli.Location = New System.Drawing.Point(190, 75)
        Me.txtCodCli.MaxLength = 40
        Me.txtCodCli.Name = "txtCodCli"
        Me.txtCodCli.Size = New System.Drawing.Size(301, 21)
        Me.txtCodCli.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(12, 79)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(135, 13)
        Me.Label1.TabIndex = 73
        Me.Label1.Text = "* Codigo Local Cliente"
        '
        'txtrsocial
        '
        Me.txtrsocial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtrsocial.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtrsocial.Location = New System.Drawing.Point(190, 48)
        Me.txtrsocial.MaxLength = 40
        Me.txtrsocial.Name = "txtrsocial"
        Me.txtrsocial.ReadOnly = True
        Me.txtrsocial.Size = New System.Drawing.Size(301, 21)
        Me.txtrsocial.TabIndex = 2
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.White
        Me.Label24.Location = New System.Drawing.Point(12, 52)
        Me.Label24.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(80, 13)
        Me.Label24.TabIndex = 71
        Me.Label24.Text = "Razón Social"
        '
        'Btn_BuscaCliente
        '
        Me.Btn_BuscaCliente.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_BuscaCliente.Image = CType(resources.GetObject("Btn_BuscaCliente.Image"), System.Drawing.Image)
        Me.Btn_BuscaCliente.Location = New System.Drawing.Point(286, 18)
        Me.Btn_BuscaCliente.Name = "Btn_BuscaCliente"
        Me.Btn_BuscaCliente.Size = New System.Drawing.Size(24, 24)
        Me.Btn_BuscaCliente.TabIndex = 1
        Me.Btn_BuscaCliente.UseVisualStyleBackColor = True
        '
        'txtrut
        '
        Me.txtrut.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtrut.Location = New System.Drawing.Point(190, 19)
        Me.txtrut.Mask = "########-A"
        Me.txtrut.Name = "txtrut"
        Me.txtrut.Size = New System.Drawing.Size(90, 21)
        Me.txtrut.TabIndex = 0
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(12, 23)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(58, 13)
        Me.Label7.TabIndex = 68
        Me.Label7.Text = "* Cliente"
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.btnEli)
        Me.GroupBox4.Controls.Add(Me.btnGra)
        Me.GroupBox4.Controls.Add(Me.btnSal)
        Me.GroupBox4.Controls.Add(Me.btnLim)
        Me.GroupBox4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(641, 53)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(101, 327)
        Me.GroupBox4.TabIndex = 78
        Me.GroupBox4.TabStop = False
        '
        'btnEli
        '
        Me.btnEli.FlatAppearance.BorderSize = 0
        Me.btnEli.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEli.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_hojamenos
        Me.btnEli.Location = New System.Drawing.Point(6, 164)
        Me.btnEli.Name = "btnEli"
        Me.btnEli.Size = New System.Drawing.Size(89, 70)
        Me.btnEli.TabIndex = 9
        Me.btnEli.UseVisualStyleBackColor = True
        '
        'btnGra
        '
        Me.btnGra.FlatAppearance.BorderSize = 0
        Me.btnGra.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGra.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_guardar2
        Me.btnGra.Location = New System.Drawing.Point(6, 19)
        Me.btnGra.Name = "btnGra"
        Me.btnGra.Size = New System.Drawing.Size(89, 70)
        Me.btnGra.TabIndex = 7
        Me.btnGra.UseVisualStyleBackColor = True
        '
        'btnSal
        '
        Me.btnSal.FlatAppearance.BorderSize = 0
        Me.btnSal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSal.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_salida
        Me.btnSal.Location = New System.Drawing.Point(6, 240)
        Me.btnSal.Name = "btnSal"
        Me.btnSal.Size = New System.Drawing.Size(89, 68)
        Me.btnSal.TabIndex = 10
        Me.btnSal.UseVisualStyleBackColor = True
        '
        'btnLim
        '
        Me.btnLim.FlatAppearance.BorderSize = 0
        Me.btnLim.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLim.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_hojanueva
        Me.btnLim.Location = New System.Drawing.Point(6, 88)
        Me.btnLim.Name = "btnLim"
        Me.btnLim.Size = New System.Drawing.Size(89, 70)
        Me.btnLim.TabIndex = 8
        Me.btnLim.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dgvLocs)
        Me.GroupBox1.Location = New System.Drawing.Point(14, 267)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(621, 427)
        Me.GroupBox1.TabIndex = 79
        Me.GroupBox1.TabStop = False
        '
        'dgvLocs
        '
        Me.dgvLocs.AllowUserToAddRows = False
        Me.dgvLocs.AllowUserToDeleteRows = False
        Me.dgvLocs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLocs.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID_Local, Me.Codigo_Cliente, Me.Nombre_Local, Me.Direccion})
        Me.dgvLocs.Location = New System.Drawing.Point(5, 19)
        Me.dgvLocs.Name = "dgvLocs"
        Me.dgvLocs.ReadOnly = True
        Me.dgvLocs.Size = New System.Drawing.Size(610, 402)
        Me.dgvLocs.TabIndex = 6
        '
        'ID_Local
        '
        Me.ID_Local.DataPropertyName = "ID_Local"
        Me.ID_Local.Frozen = True
        Me.ID_Local.HeaderText = "ID_Local"
        Me.ID_Local.Name = "ID_Local"
        Me.ID_Local.ReadOnly = True
        Me.ID_Local.Visible = False
        '
        'Codigo_Cliente
        '
        Me.Codigo_Cliente.DataPropertyName = "Codigo_Cliente"
        Me.Codigo_Cliente.Frozen = True
        Me.Codigo_Cliente.HeaderText = "Codigo Cliente"
        Me.Codigo_Cliente.Name = "Codigo_Cliente"
        Me.Codigo_Cliente.ReadOnly = True
        '
        'Nombre_Local
        '
        Me.Nombre_Local.DataPropertyName = "Nombre_Local"
        Me.Nombre_Local.Frozen = True
        Me.Nombre_Local.HeaderText = "Nombre Local"
        Me.Nombre_Local.Name = "Nombre_Local"
        Me.Nombre_Local.ReadOnly = True
        '
        'Direccion
        '
        Me.Direccion.DataPropertyName = "Direccion"
        Me.Direccion.Frozen = True
        Me.Direccion.HeaderText = "Direccion"
        Me.Direccion.Name = "Direccion"
        Me.Direccion.ReadOnly = True
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Verdana", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.White
        Me.Label21.Location = New System.Drawing.Point(352, 185)
        Me.Label21.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(139, 13)
        Me.Label21.TabIndex = 115
        Me.Label21.Text = "* Datos Obligatorios"
        '
        'Frm_Locales_Pedidos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(754, 706)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox3)
        Me.Name = "Frm_Locales_Pedidos"
        Me.Text = "Frm_Locales_Pedidos"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgvLocs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents txtrsocial As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Btn_BuscaCliente As System.Windows.Forms.Button
    Friend WithEvents txtrut As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btnGra As System.Windows.Forms.Button
    Friend WithEvents btnSal As System.Windows.Forms.Button
    Friend WithEvents btnLim As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvLocs As System.Windows.Forms.DataGridView
    Friend WithEvents btnEli As System.Windows.Forms.Button
    Friend WithEvents txtDir As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtNomLoc As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCodCli As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtIdLoc As System.Windows.Forms.TextBox
    Friend WithEvents ID_Local As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Codigo_Cliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nombre_Local As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Direccion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label21 As System.Windows.Forms.Label
End Class

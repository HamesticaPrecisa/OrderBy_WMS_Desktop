<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Control_Pallets_Fotos
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtIDArch = New System.Windows.Forms.TextBox()
        Me.btnArch = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtNomArch = New System.Windows.Forms.TextBox()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.btnEli = New System.Windows.Forms.Button()
        Me.btnGra = New System.Windows.Forms.Button()
        Me.btnSal = New System.Windows.Forms.Button()
        Me.btnLim = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.gvArch = New System.Windows.Forms.DataGridView()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.picArch = New System.Windows.Forms.PictureBox()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descargar = New System.Windows.Forms.DataGridViewImageColumn()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.gvArch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.picArch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtIDArch)
        Me.GroupBox1.Controls.Add(Me.btnArch)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtNomArch)
        Me.GroupBox1.Controls.Add(Me.txtID)
        Me.GroupBox1.Controls.Add(Me.Label35)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 13)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(385, 109)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'txtIDArch
        '
        Me.txtIDArch.Location = New System.Drawing.Point(268, 14)
        Me.txtIDArch.Name = "txtIDArch"
        Me.txtIDArch.Size = New System.Drawing.Size(82, 20)
        Me.txtIDArch.TabIndex = 103
        Me.txtIDArch.Visible = False
        '
        'btnArch
        '
        Me.btnArch.Location = New System.Drawing.Point(263, 62)
        Me.btnArch.Name = "btnArch"
        Me.btnArch.Size = New System.Drawing.Size(75, 23)
        Me.btnArch.TabIndex = 102
        Me.btnArch.Text = "Examinar"
        Me.btnArch.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(7, 67)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(91, 13)
        Me.Label6.TabIndex = 101
        Me.Label6.Text = "FOTOGRAFÍA :"
        '
        'txtNomArch
        '
        Me.txtNomArch.Location = New System.Drawing.Point(105, 64)
        Me.txtNomArch.Name = "txtNomArch"
        Me.txtNomArch.Size = New System.Drawing.Size(152, 20)
        Me.txtNomArch.TabIndex = 100
        '
        'txtID
        '
        Me.txtID.Location = New System.Drawing.Point(180, 14)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(82, 20)
        Me.txtID.TabIndex = 99
        Me.txtID.Visible = False
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.BackColor = System.Drawing.Color.Transparent
        Me.Label35.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.ForeColor = System.Drawing.Color.White
        Me.Label35.Location = New System.Drawing.Point(6, 16)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(168, 14)
        Me.Label35.TabIndex = 71
        Me.Label35.Text = "FOTOGRAFÍAS PALLETS"
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
        Me.GroupBox4.Location = New System.Drawing.Point(407, 13)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(75, 302)
        Me.GroupBox4.TabIndex = 59
        Me.GroupBox4.TabStop = False
        '
        'btnEli
        '
        Me.btnEli.FlatAppearance.BorderSize = 0
        Me.btnEli.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEli.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_hojamenos
        Me.btnEli.Location = New System.Drawing.Point(6, 155)
        Me.btnEli.Name = "btnEli"
        Me.btnEli.Size = New System.Drawing.Size(63, 63)
        Me.btnEli.TabIndex = 16
        Me.btnEli.UseVisualStyleBackColor = True
        '
        'btnGra
        '
        Me.btnGra.FlatAppearance.BorderSize = 0
        Me.btnGra.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGra.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_guardar2
        Me.btnGra.Location = New System.Drawing.Point(6, 17)
        Me.btnGra.Name = "btnGra"
        Me.btnGra.Size = New System.Drawing.Size(63, 63)
        Me.btnGra.TabIndex = 13
        Me.btnGra.UseVisualStyleBackColor = True
        '
        'btnSal
        '
        Me.btnSal.FlatAppearance.BorderSize = 0
        Me.btnSal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSal.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_salida
        Me.btnSal.Location = New System.Drawing.Point(6, 224)
        Me.btnSal.Name = "btnSal"
        Me.btnSal.Size = New System.Drawing.Size(63, 61)
        Me.btnSal.TabIndex = 17
        Me.btnSal.UseVisualStyleBackColor = True
        '
        'btnLim
        '
        Me.btnLim.FlatAppearance.BorderSize = 0
        Me.btnLim.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLim.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_hojanueva
        Me.btnLim.Location = New System.Drawing.Point(6, 86)
        Me.btnLim.Name = "btnLim"
        Me.btnLim.Size = New System.Drawing.Size(63, 63)
        Me.btnLim.TabIndex = 15
        Me.btnLim.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.gvArch)
        Me.GroupBox2.Location = New System.Drawing.Point(16, 128)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(385, 295)
        Me.GroupBox2.TabIndex = 60
        Me.GroupBox2.TabStop = False
        '
        'gvArch
        '
        Me.gvArch.AllowUserToAddRows = False
        Me.gvArch.AllowUserToDeleteRows = False
        Me.gvArch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvArch.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.Nombre, Me.Descargar})
        Me.gvArch.Location = New System.Drawing.Point(6, 19)
        Me.gvArch.Name = "gvArch"
        Me.gvArch.ReadOnly = True
        Me.gvArch.Size = New System.Drawing.Size(373, 270)
        Me.gvArch.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.picArch)
        Me.GroupBox3.Location = New System.Drawing.Point(488, 13)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(420, 410)
        Me.GroupBox3.TabIndex = 61
        Me.GroupBox3.TabStop = False
        '
        'picArch
        '
        Me.picArch.Location = New System.Drawing.Point(6, 19)
        Me.picArch.Name = "picArch"
        Me.picArch.Size = New System.Drawing.Size(408, 385)
        Me.picArch.TabIndex = 0
        Me.picArch.TabStop = False
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
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Nombre"
        Me.DataGridViewTextBoxColumn2.Frozen = True
        Me.DataGridViewTextBoxColumn2.HeaderText = "NOMBRE"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'ID
        '
        Me.ID.DataPropertyName = "ID"
        Me.ID.Frozen = True
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        Me.ID.Visible = False
        '
        'Nombre
        '
        Me.Nombre.DataPropertyName = "Nombre"
        Me.Nombre.Frozen = True
        Me.Nombre.HeaderText = "NOMBRE"
        Me.Nombre.Name = "Nombre"
        Me.Nombre.ReadOnly = True
        '
        'Descargar
        '
        Me.Descargar.Frozen = True
        Me.Descargar.HeaderText = "DESCARGAR"
        Me.Descargar.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.Abajo
        Me.Descargar.Name = "Descargar"
        Me.Descargar.ReadOnly = True
        '
        'Control_Pallets_Fotos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(925, 437)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Control_Pallets_Fotos"
        Me.Text = "Control_Pallets_Fotos"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.gvArch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.picArch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btnEli As System.Windows.Forms.Button
    Friend WithEvents btnGra As System.Windows.Forms.Button
    Friend WithEvents btnSal As System.Windows.Forms.Button
    Friend WithEvents btnLim As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents txtID As System.Windows.Forms.TextBox
    Friend WithEvents btnArch As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtNomArch As System.Windows.Forms.TextBox
    Friend WithEvents gvArch As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents picArch As System.Windows.Forms.PictureBox
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtIDArch As System.Windows.Forms.TextBox
    Friend WithEvents ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descargar As System.Windows.Forms.DataGridViewImageColumn
End Class

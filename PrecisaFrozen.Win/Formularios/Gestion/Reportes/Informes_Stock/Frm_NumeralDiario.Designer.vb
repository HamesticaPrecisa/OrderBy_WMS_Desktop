<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_NumeralDiario
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
        Me.CalFecFin = New System.Windows.Forms.DateTimePicker()
        Me.calFecIni = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblCont = New System.Windows.Forms.Label()
        Me.lblCli = New System.Windows.Forms.Label()
        Me.chkCont = New System.Windows.Forms.CheckBox()
        Me.btnBusCont = New System.Windows.Forms.Button()
        Me.btnBusCli = New System.Windows.Forms.Button()
        Me.txtCont = New System.Windows.Forms.TextBox()
        Me.txtCli = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dgvNumDia = New System.Windows.Forms.DataGridView()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnNue = New System.Windows.Forms.Button()
        Me.btnXls = New System.Windows.Forms.Button()
        Me.btnBus = New System.Windows.Forms.Button()
        Me.btnSal = New System.Windows.Forms.Button()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Soportantes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cajas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Peso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvNumDia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.CalFecFin)
        Me.GroupBox1.Controls.Add(Me.calFecIni)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.lblCont)
        Me.GroupBox1.Controls.Add(Me.lblCli)
        Me.GroupBox1.Controls.Add(Me.chkCont)
        Me.GroupBox1.Controls.Add(Me.btnBusCont)
        Me.GroupBox1.Controls.Add(Me.btnBusCli)
        Me.GroupBox1.Controls.Add(Me.txtCont)
        Me.GroupBox1.Controls.Add(Me.txtCli)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(554, 112)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'CalFecFin
        '
        Me.CalFecFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.CalFecFin.Location = New System.Drawing.Point(279, 75)
        Me.CalFecFin.Name = "CalFecFin"
        Me.CalFecFin.Size = New System.Drawing.Size(118, 20)
        Me.CalFecFin.TabIndex = 88
        '
        'calFecIni
        '
        Me.calFecIni.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.calFecIni.Location = New System.Drawing.Point(134, 75)
        Me.calFecIni.Name = "calFecIni"
        Me.calFecIni.Size = New System.Drawing.Size(118, 20)
        Me.calFecIni.TabIndex = 87
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(26, 81)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 86
        Me.Label1.Text = "FECHAS"
        '
        'lblCont
        '
        Me.lblCont.AutoSize = True
        Me.lblCont.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblCont.Location = New System.Drawing.Point(118, 55)
        Me.lblCont.Name = "lblCont"
        Me.lblCont.Size = New System.Drawing.Size(10, 13)
        Me.lblCont.TabIndex = 79
        Me.lblCont.Text = " "
        Me.lblCont.Visible = False
        '
        'lblCli
        '
        Me.lblCli.AutoSize = True
        Me.lblCli.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblCli.Location = New System.Drawing.Point(118, 26)
        Me.lblCli.Name = "lblCli"
        Me.lblCli.Size = New System.Drawing.Size(10, 13)
        Me.lblCli.TabIndex = 78
        Me.lblCli.Text = " "
        Me.lblCli.Visible = False
        '
        'chkCont
        '
        Me.chkCont.AutoSize = True
        Me.chkCont.BackColor = System.Drawing.Color.Transparent
        Me.chkCont.Checked = True
        Me.chkCont.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkCont.ForeColor = System.Drawing.Color.White
        Me.chkCont.Location = New System.Drawing.Point(480, 52)
        Me.chkCont.Name = "chkCont"
        Me.chkCont.Size = New System.Drawing.Size(64, 17)
        Me.chkCont.TabIndex = 75
        Me.chkCont.Text = "TODOS"
        Me.chkCont.UseVisualStyleBackColor = False
        '
        'btnBusCont
        '
        Me.btnBusCont.Enabled = False
        Me.btnBusCont.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.buscar_24
        Me.btnBusCont.Location = New System.Drawing.Point(452, 48)
        Me.btnBusCont.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnBusCont.Name = "btnBusCont"
        Me.btnBusCont.Size = New System.Drawing.Size(21, 22)
        Me.btnBusCont.TabIndex = 74
        Me.btnBusCont.UseVisualStyleBackColor = True
        '
        'btnBusCli
        '
        Me.btnBusCli.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.buscar_24
        Me.btnBusCli.Location = New System.Drawing.Point(452, 20)
        Me.btnBusCli.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnBusCli.Name = "btnBusCli"
        Me.btnBusCli.Size = New System.Drawing.Size(21, 22)
        Me.btnBusCli.TabIndex = 73
        Me.btnBusCli.UseVisualStyleBackColor = True
        '
        'txtCont
        '
        Me.txtCont.Enabled = False
        Me.txtCont.Location = New System.Drawing.Point(134, 49)
        Me.txtCont.Name = "txtCont"
        Me.txtCont.Size = New System.Drawing.Size(300, 20)
        Me.txtCont.TabIndex = 72
        '
        'txtCli
        '
        Me.txtCli.Enabled = False
        Me.txtCli.Location = New System.Drawing.Point(134, 22)
        Me.txtCli.Name = "txtCli"
        Me.txtCli.Size = New System.Drawing.Size(300, 20)
        Me.txtCli.TabIndex = 71
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(26, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 69
        Me.Label2.Text = "CLIENTE"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(25, 54)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 13)
        Me.Label3.TabIndex = 70
        Me.Label3.Text = "CONTRATO"
        '
        'dgvNumDia
        '
        Me.dgvNumDia.AllowDrop = True
        Me.dgvNumDia.AllowUserToAddRows = False
        Me.dgvNumDia.AllowUserToDeleteRows = False
        Me.dgvNumDia.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvNumDia.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvNumDia.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark
        Me.dgvNumDia.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Fecha, Me.Soportantes, Me.Cajas, Me.Peso})
        Me.dgvNumDia.Location = New System.Drawing.Point(16, 130)
        Me.dgvNumDia.Name = "dgvNumDia"
        Me.dgvNumDia.ReadOnly = True
        Me.dgvNumDia.RowHeadersVisible = False
        Me.dgvNumDia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvNumDia.Size = New System.Drawing.Size(554, 308)
        Me.dgvNumDia.TabIndex = 110
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.btnNue)
        Me.GroupBox2.Controls.Add(Me.btnXls)
        Me.GroupBox2.Controls.Add(Me.btnBus)
        Me.GroupBox2.Controls.Add(Me.btnSal)
        Me.GroupBox2.Location = New System.Drawing.Point(576, 130)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(76, 308)
        Me.GroupBox2.TabIndex = 112
        Me.GroupBox2.TabStop = False
        '
        'btnNue
        '
        Me.btnNue.FlatAppearance.BorderSize = 0
        Me.btnNue.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNue.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_hojanueva
        Me.btnNue.Location = New System.Drawing.Point(7, 154)
        Me.btnNue.Name = "btnNue"
        Me.btnNue.Size = New System.Drawing.Size(63, 63)
        Me.btnNue.TabIndex = 123
        Me.btnNue.UseVisualStyleBackColor = True
        '
        'btnXls
        '
        Me.btnXls.Enabled = False
        Me.btnXls.FlatAppearance.BorderSize = 0
        Me.btnXls.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnXls.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_xls
        Me.btnXls.Location = New System.Drawing.Point(6, 85)
        Me.btnXls.Name = "btnXls"
        Me.btnXls.Size = New System.Drawing.Size(63, 63)
        Me.btnXls.TabIndex = 121
        Me.btnXls.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnXls.UseVisualStyleBackColor = True
        '
        'btnBus
        '
        Me.btnBus.Enabled = False
        Me.btnBus.FlatAppearance.BorderSize = 0
        Me.btnBus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBus.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_soportante
        Me.btnBus.Location = New System.Drawing.Point(6, 16)
        Me.btnBus.Name = "btnBus"
        Me.btnBus.Size = New System.Drawing.Size(63, 63)
        Me.btnBus.TabIndex = 90
        Me.btnBus.UseVisualStyleBackColor = True
        '
        'btnSal
        '
        Me.btnSal.FlatAppearance.BorderSize = 0
        Me.btnSal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSal.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_salida
        Me.btnSal.Location = New System.Drawing.Point(7, 223)
        Me.btnSal.Name = "btnSal"
        Me.btnSal.Size = New System.Drawing.Size(63, 63)
        Me.btnSal.TabIndex = 89
        Me.btnSal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSal.UseVisualStyleBackColor = True
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "Fecha"
        Me.DataGridViewTextBoxColumn1.HeaderText = "FECHA"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 67
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Soportantes"
        Me.DataGridViewTextBoxColumn2.HeaderText = "SOPORTANTES"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 113
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "Cajas"
        Me.DataGridViewTextBoxColumn3.HeaderText = "CAJAS"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 65
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "Peso"
        Me.DataGridViewTextBoxColumn4.HeaderText = "KILOS"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 63
        '
        'Fecha
        '
        Me.Fecha.DataPropertyName = "Fecha"
        Me.Fecha.HeaderText = "FECHA"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.ReadOnly = True
        Me.Fecha.Width = 67
        '
        'Soportantes
        '
        Me.Soportantes.DataPropertyName = "Soportantes"
        Me.Soportantes.HeaderText = "SOPORTANTES"
        Me.Soportantes.Name = "Soportantes"
        Me.Soportantes.ReadOnly = True
        Me.Soportantes.Width = 113
        '
        'Cajas
        '
        Me.Cajas.DataPropertyName = "Cajas"
        Me.Cajas.HeaderText = "CAJAS"
        Me.Cajas.Name = "Cajas"
        Me.Cajas.ReadOnly = True
        Me.Cajas.Width = 65
        '
        'Peso
        '
        Me.Peso.DataPropertyName = "Peso"
        Me.Peso.HeaderText = "KILOS"
        Me.Peso.Name = "Peso"
        Me.Peso.ReadOnly = True
        Me.Peso.Width = 63
        '
        'FRM_NumeralDiario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(668, 471)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.dgvNumDia)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FRM_NumeralDiario"
        Me.Text = "Numeral Diario"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvNumDia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents calFecIni As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblCont As System.Windows.Forms.Label
    Friend WithEvents lblCli As System.Windows.Forms.Label
    Friend WithEvents chkCont As System.Windows.Forms.CheckBox
    Friend WithEvents btnBusCont As System.Windows.Forms.Button
    Friend WithEvents btnBusCli As System.Windows.Forms.Button
    Friend WithEvents txtCont As System.Windows.Forms.TextBox
    Friend WithEvents txtCli As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CalFecFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents dgvNumDia As System.Windows.Forms.DataGridView
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Soportantes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cajas As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Peso As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnXls As System.Windows.Forms.Button
    Friend WithEvents btnBus As System.Windows.Forms.Button
    Friend WithEvents btnSal As System.Windows.Forms.Button
    Friend WithEvents btnNue As System.Windows.Forms.Button
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

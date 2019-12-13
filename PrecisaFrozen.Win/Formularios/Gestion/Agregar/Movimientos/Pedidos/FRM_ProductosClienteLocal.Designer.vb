<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_ProductosClienteLocal
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
        Me.lblOrd = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblCaj = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblPro = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblPal = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtCajsAsig = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnGra = New System.Windows.Forms.Button()
        Me.btnAgrCaj = New System.Windows.Forms.Button()
        Me.txtCajs = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboLocs = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dgvDet = New System.Windows.Forms.DataGridView()
        Me.Eliminar = New System.Windows.Forms.DataGridViewImageColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDLoc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Local = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CantCajas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvDet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblOrd)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.lblCaj)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.lblPro)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.lblPal)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(330, 126)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'lblOrd
        '
        Me.lblOrd.AutoSize = True
        Me.lblOrd.ForeColor = System.Drawing.Color.White
        Me.lblOrd.Location = New System.Drawing.Point(107, 16)
        Me.lblOrd.Name = "lblOrd"
        Me.lblOrd.Size = New System.Drawing.Size(16, 13)
        Me.lblOrd.TabIndex = 8
        Me.lblOrd.Text = "..."
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(6, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(46, 13)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "ORDEN"
        '
        'lblCaj
        '
        Me.lblCaj.AutoSize = True
        Me.lblCaj.ForeColor = System.Drawing.Color.White
        Me.lblCaj.Location = New System.Drawing.Point(107, 83)
        Me.lblCaj.Name = "lblCaj"
        Me.lblCaj.Size = New System.Drawing.Size(16, 13)
        Me.lblCaj.TabIndex = 6
        Me.lblCaj.Text = "..."
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(6, 83)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "CAJAS"
        '
        'lblPro
        '
        Me.lblPro.AutoSize = True
        Me.lblPro.ForeColor = System.Drawing.Color.White
        Me.lblPro.Location = New System.Drawing.Point(107, 59)
        Me.lblPro.Name = "lblPro"
        Me.lblPro.Size = New System.Drawing.Size(16, 13)
        Me.lblPro.TabIndex = 4
        Me.lblPro.Text = "..."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(6, 59)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "PRODUCTO"
        '
        'lblPal
        '
        Me.lblPal.AutoSize = True
        Me.lblPal.ForeColor = System.Drawing.Color.White
        Me.lblPal.Location = New System.Drawing.Point(107, 38)
        Me.lblPal.Name = "lblPal"
        Me.lblPal.Size = New System.Drawing.Size(16, 13)
        Me.lblPal.TabIndex = 2
        Me.lblPal.Text = "..."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(6, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "FOLIO"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtCajsAsig)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.btnGra)
        Me.GroupBox2.Controls.Add(Me.btnAgrCaj)
        Me.GroupBox2.Controls.Add(Me.txtCajs)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.cboLocs)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.dgvDet)
        Me.GroupBox2.Location = New System.Drawing.Point(13, 144)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(330, 334)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        '
        'txtCajsAsig
        '
        Me.txtCajsAsig.Location = New System.Drawing.Point(136, 307)
        Me.txtCajsAsig.Name = "txtCajsAsig"
        Me.txtCajsAsig.ReadOnly = True
        Me.txtCajsAsig.Size = New System.Drawing.Size(52, 20)
        Me.txtCajsAsig.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(6, 310)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(105, 13)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "CAJAS ASIGNADAS"
        '
        'btnGra
        '
        Me.btnGra.Location = New System.Drawing.Point(238, 305)
        Me.btnGra.Name = "btnGra"
        Me.btnGra.Size = New System.Drawing.Size(86, 23)
        Me.btnGra.TabIndex = 5
        Me.btnGra.Text = "Confirmar"
        Me.btnGra.UseVisualStyleBackColor = True
        '
        'btnAgrCaj
        '
        Me.btnAgrCaj.Location = New System.Drawing.Point(9, 75)
        Me.btnAgrCaj.Name = "btnAgrCaj"
        Me.btnAgrCaj.Size = New System.Drawing.Size(86, 23)
        Me.btnAgrCaj.TabIndex = 2
        Me.btnAgrCaj.Text = "Agregar Cajas"
        Me.btnAgrCaj.UseVisualStyleBackColor = True
        '
        'txtCajs
        '
        Me.txtCajs.Location = New System.Drawing.Point(110, 41)
        Me.txtCajs.Name = "txtCajs"
        Me.txtCajs.Size = New System.Drawing.Size(52, 20)
        Me.txtCajs.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(6, 44)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "CAJAS"
        '
        'cboLocs
        '
        Me.cboLocs.FormattingEnabled = True
        Me.cboLocs.Location = New System.Drawing.Point(110, 14)
        Me.cboLocs.Name = "cboLocs"
        Me.cboLocs.Size = New System.Drawing.Size(121, 21)
        Me.cboLocs.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(6, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "LOCAL"
        '
        'dgvDet
        '
        Me.dgvDet.AllowUserToAddRows = False
        Me.dgvDet.AllowUserToDeleteRows = False
        Me.dgvDet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDet.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IDLoc, Me.Local, Me.CantCajas, Me.Eliminar})
        Me.dgvDet.Location = New System.Drawing.Point(6, 104)
        Me.dgvDet.Name = "dgvDet"
        Me.dgvDet.ReadOnly = True
        Me.dgvDet.Size = New System.Drawing.Size(318, 195)
        Me.dgvDet.TabIndex = 3
        '
        'Eliminar
        '
        Me.Eliminar.HeaderText = "Eliminar"
        Me.Eliminar.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.Eliminar_16
        Me.Eliminar.Name = "Eliminar"
        Me.Eliminar.ReadOnly = True
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "IDLoc"
        Me.DataGridViewTextBoxColumn1.HeaderText = "IDLoc"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Local"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Local"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "CantCajas"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Cajas"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'IDLoc
        '
        Me.IDLoc.DataPropertyName = "IDLoc"
        Me.IDLoc.HeaderText = "IDLoc"
        Me.IDLoc.Name = "IDLoc"
        Me.IDLoc.ReadOnly = True
        Me.IDLoc.Visible = False
        '
        'Local
        '
        Me.Local.DataPropertyName = "Local"
        Me.Local.HeaderText = "Local"
        Me.Local.Name = "Local"
        Me.Local.ReadOnly = True
        '
        'CantCajas
        '
        Me.CantCajas.DataPropertyName = "CantCajas"
        Me.CantCajas.HeaderText = "Cajas"
        Me.CantCajas.Name = "CantCajas"
        Me.CantCajas.ReadOnly = True
        '
        'FRM_ProductosClienteLocal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(357, 490)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FRM_ProductosClienteLocal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "FRM_ProductosClienteLocal"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dgvDet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblPal As System.Windows.Forms.Label
    Friend WithEvents lblPro As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblCaj As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtCajs As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboLocs As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dgvDet As System.Windows.Forms.DataGridView
    Friend WithEvents lblOrd As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnAgrCaj As System.Windows.Forms.Button
    Friend WithEvents btnGra As System.Windows.Forms.Button
    Friend WithEvents txtCajsAsig As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDLoc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Local As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CantCajas As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Eliminar As System.Windows.Forms.DataGridViewImageColumn
End Class

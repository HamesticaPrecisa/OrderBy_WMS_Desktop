<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Revisiones
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
        Me.DgvResumen = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtcodrece = New System.Windows.Forms.TextBox()
        Me.dtrece = New System.Windows.Forms.DateTimePicker()
        Me.movimiento = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cb1 = New System.Windows.Forms.CheckBox()
        Me.cb3 = New System.Windows.Forms.CheckBox()
        Me.cb2 = New System.Windows.Forms.CheckBox()
        Me.dtrevision = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.BtnFiltrar = New System.Windows.Forms.Button()
        Me.BtnImprimir = New System.Windows.Forms.Button()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.BtnNuevo = New System.Windows.Forms.Button()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nprecisa = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ncliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRODUCTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RESPONSABLE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CANTIDAD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DgvResumen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DgvResumen
        '
        Me.DgvResumen.AllowUserToAddRows = False
        Me.DgvResumen.AllowUserToDeleteRows = False
        Me.DgvResumen.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark
        Me.DgvResumen.ColumnHeadersHeight = 28
        Me.DgvResumen.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.nprecisa, Me.ncliente, Me.PRODUCTO, Me.RESPONSABLE, Me.CANTIDAD})
        Me.DgvResumen.Location = New System.Drawing.Point(12, 115)
        Me.DgvResumen.Name = "DgvResumen"
        Me.DgvResumen.ReadOnly = True
        Me.DgvResumen.RowHeadersWidth = 35
        Me.DgvResumen.Size = New System.Drawing.Size(780, 447)
        Me.DgvResumen.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(12, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 20)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "RECEPCION"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(12, 76)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 20)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "FECHA RECEPCION"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(348, 76)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(103, 20)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "MOVIMIENTO"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtcodrece
        '
        Me.txtcodrece.Location = New System.Drawing.Point(131, 46)
        Me.txtcodrece.MaxLength = 7
        Me.txtcodrece.Name = "txtcodrece"
        Me.txtcodrece.Size = New System.Drawing.Size(129, 20)
        Me.txtcodrece.TabIndex = 4
        Me.txtcodrece.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dtrece
        '
        Me.dtrece.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtrece.Location = New System.Drawing.Point(131, 76)
        Me.dtrece.Name = "dtrece"
        Me.dtrece.Size = New System.Drawing.Size(129, 20)
        Me.dtrece.TabIndex = 5
        '
        'movimiento
        '
        Me.movimiento.FormattingEnabled = True
        Me.movimiento.Location = New System.Drawing.Point(467, 75)
        Me.movimiento.Name = "movimiento"
        Me.movimiento.Size = New System.Drawing.Size(129, 22)
        Me.movimiento.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(12, 10)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(780, 25)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "FILTRAR INFORMACION"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cb1
        '
        Me.cb1.AutoSize = True
        Me.cb1.BackColor = System.Drawing.Color.Transparent
        Me.cb1.Checked = True
        Me.cb1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cb1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb1.ForeColor = System.Drawing.Color.White
        Me.cb1.Location = New System.Drawing.Point(266, 78)
        Me.cb1.Name = "cb1"
        Me.cb1.Size = New System.Drawing.Size(62, 18)
        Me.cb1.TabIndex = 9
        Me.cb1.Text = "TODOS"
        Me.cb1.UseVisualStyleBackColor = False
        '
        'cb3
        '
        Me.cb3.AutoSize = True
        Me.cb3.BackColor = System.Drawing.Color.Transparent
        Me.cb3.Checked = True
        Me.cb3.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cb3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb3.ForeColor = System.Drawing.Color.White
        Me.cb3.Location = New System.Drawing.Point(604, 76)
        Me.cb3.Name = "cb3"
        Me.cb3.Size = New System.Drawing.Size(62, 18)
        Me.cb3.TabIndex = 10
        Me.cb3.Text = "TODOS"
        Me.cb3.UseVisualStyleBackColor = False
        '
        'cb2
        '
        Me.cb2.AutoSize = True
        Me.cb2.BackColor = System.Drawing.Color.Transparent
        Me.cb2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb2.ForeColor = System.Drawing.Color.White
        Me.cb2.Location = New System.Drawing.Point(604, 47)
        Me.cb2.Name = "cb2"
        Me.cb2.Size = New System.Drawing.Size(62, 18)
        Me.cb2.TabIndex = 13
        Me.cb2.Text = "TODOS"
        Me.cb2.UseVisualStyleBackColor = False
        '
        'dtrevision
        '
        Me.dtrevision.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtrevision.Location = New System.Drawing.Point(467, 46)
        Me.dtrevision.Name = "dtrevision"
        Me.dtrevision.Size = New System.Drawing.Size(129, 20)
        Me.dtrevision.TabIndex = 12
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(348, 45)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(103, 20)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "FECHA REVISION"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BtnFiltrar
        '
        Me.BtnFiltrar.FlatAppearance.BorderSize = 0
        Me.BtnFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFiltrar.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_soportante
        Me.BtnFiltrar.Location = New System.Drawing.Point(3, 19)
        Me.BtnFiltrar.Name = "BtnFiltrar"
        Me.BtnFiltrar.Size = New System.Drawing.Size(63, 63)
        Me.BtnFiltrar.TabIndex = 88
        Me.BtnFiltrar.UseVisualStyleBackColor = True
        '
        'BtnImprimir
        '
        Me.BtnImprimir.FlatAppearance.BorderSize = 0
        Me.BtnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnImprimir.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_impresora
        Me.BtnImprimir.Location = New System.Drawing.Point(3, 82)
        Me.BtnImprimir.Name = "BtnImprimir"
        Me.BtnImprimir.Size = New System.Drawing.Size(63, 63)
        Me.BtnImprimir.TabIndex = 87
        Me.BtnImprimir.UseVisualStyleBackColor = True
        '
        'BtnSalir
        '
        Me.BtnSalir.FlatAppearance.BorderSize = 0
        Me.BtnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSalir.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_salida
        Me.BtnSalir.Location = New System.Drawing.Point(3, 210)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(63, 63)
        Me.BtnSalir.TabIndex = 86
        Me.BtnSalir.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.BtnNuevo)
        Me.GroupBox1.Controls.Add(Me.BtnFiltrar)
        Me.GroupBox1.Controls.Add(Me.BtnImprimir)
        Me.GroupBox1.Controls.Add(Me.BtnSalir)
        Me.GroupBox1.Location = New System.Drawing.Point(807, 115)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(69, 282)
        Me.GroupBox1.TabIndex = 89
        Me.GroupBox1.TabStop = False
        '
        'BtnNuevo
        '
        Me.BtnNuevo.FlatAppearance.BorderSize = 0
        Me.BtnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnNuevo.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_hojanueva
        Me.BtnNuevo.Location = New System.Drawing.Point(3, 146)
        Me.BtnNuevo.Name = "BtnNuevo"
        Me.BtnNuevo.Size = New System.Drawing.Size(63, 63)
        Me.BtnNuevo.TabIndex = 89
        Me.BtnNuevo.UseVisualStyleBackColor = True
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "drec_codi"
        Me.DataGridViewTextBoxColumn1.HeaderText = "N° Precisa"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "drec_sopocli"
        Me.DataGridViewTextBoxColumn2.HeaderText = "N° Cliente"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "mae_descr"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Producto"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 200
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "personal"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Encargado"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 200
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "drec_unidades"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Envases"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'nprecisa
        '
        Me.nprecisa.DataPropertyName = "drec_codi"
        Me.nprecisa.HeaderText = "FOLIO"
        Me.nprecisa.Name = "nprecisa"
        Me.nprecisa.ReadOnly = True
        Me.nprecisa.Width = 80
        '
        'ncliente
        '
        Me.ncliente.DataPropertyName = "drec_sopocli"
        Me.ncliente.HeaderText = "N° CLIENTE"
        Me.ncliente.Name = "ncliente"
        Me.ncliente.ReadOnly = True
        '
        'PRODUCTO
        '
        Me.PRODUCTO.DataPropertyName = "mae_descr"
        Me.PRODUCTO.HeaderText = "PRODUCTO"
        Me.PRODUCTO.Name = "PRODUCTO"
        Me.PRODUCTO.ReadOnly = True
        Me.PRODUCTO.Width = 250
        '
        'RESPONSABLE
        '
        Me.RESPONSABLE.DataPropertyName = "descri"
        Me.RESPONSABLE.HeaderText = "ENCARGADO"
        Me.RESPONSABLE.Name = "RESPONSABLE"
        Me.RESPONSABLE.ReadOnly = True
        Me.RESPONSABLE.Width = 180
        '
        'CANTIDAD
        '
        Me.CANTIDAD.DataPropertyName = "drec_unidades"
        Me.CANTIDAD.HeaderText = "ENVASES"
        Me.CANTIDAD.Name = "CANTIDAD"
        Me.CANTIDAD.ReadOnly = True
        Me.CANTIDAD.Width = 80
        '
        'Frm_Revisiones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(901, 581)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cb2)
        Me.Controls.Add(Me.dtrevision)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cb3)
        Me.Controls.Add(Me.cb1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.movimiento)
        Me.Controls.Add(Me.dtrece)
        Me.Controls.Add(Me.txtcodrece)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DgvResumen)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "Frm_Revisiones"
        Me.ShowIcon = False
        Me.Text = "Revisiones de Productos"
        CType(Me.DgvResumen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DgvResumen As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtcodrece As System.Windows.Forms.TextBox
    Friend WithEvents dtrece As System.Windows.Forms.DateTimePicker
    Friend WithEvents movimiento As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cb1 As System.Windows.Forms.CheckBox
    Friend WithEvents cb3 As System.Windows.Forms.CheckBox
    Friend WithEvents cb2 As System.Windows.Forms.CheckBox
    Friend WithEvents dtrevision As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents BtnFiltrar As System.Windows.Forms.Button
    Friend WithEvents BtnImprimir As System.Windows.Forms.Button
    Friend WithEvents BtnSalir As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BtnNuevo As System.Windows.Forms.Button
    Friend WithEvents nprecisa As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ncliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRODUCTO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RESPONSABLE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CANTIDAD As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

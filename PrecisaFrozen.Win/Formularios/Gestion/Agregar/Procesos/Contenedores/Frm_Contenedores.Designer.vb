<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Contenedores
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
        Me.DgvContenedores = New System.Windows.Forms.DataGridView()
        Me.RECEPCION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CONTENEDOR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CLIENTE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CONTRATO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ECOD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ETIQUETADO = New System.Windows.Forms.DataGridViewImageColumn()
        Me.RCOD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.REVISION = New System.Windows.Forms.DataGridViewImageColumn()
        Me.BCOD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RESOLUCION = New System.Windows.Forms.DataGridViewImageColumn()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.BtnFiltrar = New System.Windows.Forms.Button()
        Me.CbCliente = New System.Windows.Forms.CheckBox()
        Me.ComboEstado = New System.Windows.Forms.ComboBox()
        Me.rutcli = New System.Windows.Forms.TextBox()
        Me.btn_BuscaCliente = New System.Windows.Forms.Button()
        Me.nomcli = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DataGridViewImageColumn1 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.CbSeleccion = New System.Windows.Forms.CheckBox()
        Me.BtnExportar = New System.Windows.Forms.Button()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DgvContenedores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DgvContenedores
        '
        Me.DgvContenedores.AllowUserToAddRows = False
        Me.DgvContenedores.AllowUserToDeleteRows = False
        Me.DgvContenedores.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark
        Me.DgvContenedores.ColumnHeadersHeight = 28
        Me.DgvContenedores.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.RECEPCION, Me.CONTENEDOR, Me.CLIENTE, Me.CONTRATO, Me.ECOD, Me.ETIQUETADO, Me.RCOD, Me.REVISION, Me.BCOD, Me.RESOLUCION})
        Me.DgvContenedores.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvContenedores.Location = New System.Drawing.Point(20, 100)
        Me.DgvContenedores.Name = "DgvContenedores"
        Me.DgvContenedores.ReadOnly = True
        Me.DgvContenedores.Size = New System.Drawing.Size(1003, 406)
        Me.DgvContenedores.TabIndex = 0
        '
        'RECEPCION
        '
        Me.RECEPCION.DataPropertyName = "frec_codi"
        Me.RECEPCION.HeaderText = "RECEPCION"
        Me.RECEPCION.Name = "RECEPCION"
        Me.RECEPCION.ReadOnly = True
        '
        'CONTENEDOR
        '
        Me.CONTENEDOR.DataPropertyName = "frec_contenedor"
        Me.CONTENEDOR.HeaderText = "CONTENEDOR"
        Me.CONTENEDOR.Name = "CONTENEDOR"
        Me.CONTENEDOR.ReadOnly = True
        Me.CONTENEDOR.Width = 120
        '
        'CLIENTE
        '
        Me.CLIENTE.DataPropertyName = "cli_nomb"
        Me.CLIENTE.HeaderText = "CLIENTE"
        Me.CLIENTE.Name = "CLIENTE"
        Me.CLIENTE.ReadOnly = True
        Me.CLIENTE.Width = 200
        '
        'CONTRATO
        '
        Me.CONTRATO.DataPropertyName = "cont_descr"
        Me.CONTRATO.HeaderText = "CONTRATO"
        Me.CONTRATO.Name = "CONTRATO"
        Me.CONTRATO.ReadOnly = True
        Me.CONTRATO.Width = 200
        '
        'ECOD
        '
        Me.ECOD.DataPropertyName = "ETIQ"
        Me.ECOD.HeaderText = "COD"
        Me.ECOD.MinimumWidth = 2
        Me.ECOD.Name = "ECOD"
        Me.ECOD.ReadOnly = True
        Me.ECOD.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ECOD.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ECOD.Width = 2
        '
        'ETIQUETADO
        '
        Me.ETIQUETADO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.ETIQUETADO.HeaderText = "ETIQUETADO"
        Me.ETIQUETADO.Name = "ETIQUETADO"
        Me.ETIQUETADO.ReadOnly = True
        Me.ETIQUETADO.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ETIQUETADO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.ETIQUETADO.Width = 108
        '
        'RCOD
        '
        Me.RCOD.DataPropertyName = "REV"
        Me.RCOD.HeaderText = "COD"
        Me.RCOD.MinimumWidth = 2
        Me.RCOD.Name = "RCOD"
        Me.RCOD.ReadOnly = True
        Me.RCOD.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.RCOD.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.RCOD.Width = 2
        '
        'REVISION
        '
        Me.REVISION.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.REVISION.HeaderText = "REVISION"
        Me.REVISION.Name = "REVISION"
        Me.REVISION.ReadOnly = True
        Me.REVISION.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.REVISION.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.REVISION.Width = 90
        '
        'BCOD
        '
        Me.BCOD.DataPropertyName = "BLOQ"
        Me.BCOD.HeaderText = "COD"
        Me.BCOD.MinimumWidth = 2
        Me.BCOD.Name = "BCOD"
        Me.BCOD.ReadOnly = True
        Me.BCOD.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.BCOD.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.BCOD.Width = 2
        '
        'RESOLUCION
        '
        Me.RESOLUCION.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.RESOLUCION.HeaderText = "RESOLUCION"
        Me.RESOLUCION.Name = "RESOLUCION"
        Me.RESOLUCION.ReadOnly = True
        Me.RESOLUCION.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.RESOLUCION.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.RESOLUCION.Width = 109
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.BtnFiltrar)
        Me.GroupBox1.Controls.Add(Me.CbCliente)
        Me.GroupBox1.Controls.Add(Me.ComboEstado)
        Me.GroupBox1.Controls.Add(Me.rutcli)
        Me.GroupBox1.Controls.Add(Me.btn_BuscaCliente)
        Me.GroupBox1.Controls.Add(Me.nomcli)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(20, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(585, 86)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'BtnFiltrar
        '
        Me.BtnFiltrar.ForeColor = System.Drawing.Color.Black
        Me.BtnFiltrar.Location = New System.Drawing.Point(383, 50)
        Me.BtnFiltrar.Name = "BtnFiltrar"
        Me.BtnFiltrar.Size = New System.Drawing.Size(117, 25)
        Me.BtnFiltrar.TabIndex = 56
        Me.BtnFiltrar.Text = "FILTRAR"
        Me.BtnFiltrar.UseVisualStyleBackColor = True
        '
        'CbCliente
        '
        Me.CbCliente.AutoSize = True
        Me.CbCliente.Checked = True
        Me.CbCliente.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CbCliente.Location = New System.Drawing.Point(507, 23)
        Me.CbCliente.Name = "CbCliente"
        Me.CbCliente.Size = New System.Drawing.Size(68, 17)
        Me.CbCliente.TabIndex = 53
        Me.CbCliente.Text = "TODOS"
        Me.CbCliente.UseVisualStyleBackColor = True
        '
        'ComboEstado
        '
        Me.ComboEstado.FormattingEnabled = True
        Me.ComboEstado.Location = New System.Drawing.Point(129, 52)
        Me.ComboEstado.Name = "ComboEstado"
        Me.ComboEstado.Size = New System.Drawing.Size(204, 21)
        Me.ComboEstado.TabIndex = 52
        '
        'rutcli
        '
        Me.rutcli.Location = New System.Drawing.Point(129, 21)
        Me.rutcli.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.rutcli.MaxLength = 8
        Me.rutcli.Name = "rutcli"
        Me.rutcli.ReadOnly = True
        Me.rutcli.Size = New System.Drawing.Size(82, 21)
        Me.rutcli.TabIndex = 51
        '
        'btn_BuscaCliente
        '
        Me.btn_BuscaCliente.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.buscar_24
        Me.btn_BuscaCliente.Location = New System.Drawing.Point(217, 20)
        Me.btn_BuscaCliente.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btn_BuscaCliente.Name = "btn_BuscaCliente"
        Me.btn_BuscaCliente.Size = New System.Drawing.Size(21, 22)
        Me.btn_BuscaCliente.TabIndex = 46
        Me.btn_BuscaCliente.UseVisualStyleBackColor = True
        '
        'nomcli
        '
        Me.nomcli.Enabled = False
        Me.nomcli.Location = New System.Drawing.Point(246, 21)
        Me.nomcli.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.nomcli.Name = "nomcli"
        Me.nomcli.ReadOnly = True
        Me.nomcli.Size = New System.Drawing.Size(254, 21)
        Me.nomcli.TabIndex = 47
        '
        'Label3
        '
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Location = New System.Drawing.Point(13, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(109, 21)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "ESTADO"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Location = New System.Drawing.Point(13, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(109, 21)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "CLIENTE"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DataGridViewImageColumn1
        '
        Me.DataGridViewImageColumn1.HeaderText = "DET"
        Me.DataGridViewImageColumn1.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.detalle
        Me.DataGridViewImageColumn1.Name = "DataGridViewImageColumn1"
        Me.DataGridViewImageColumn1.ReadOnly = True
        Me.DataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewImageColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewImageColumn1.Width = 40
        '
        'CbSeleccion
        '
        Me.CbSeleccion.AutoSize = True
        Me.CbSeleccion.BackColor = System.Drawing.Color.Transparent
        Me.CbSeleccion.ForeColor = System.Drawing.Color.White
        Me.CbSeleccion.Location = New System.Drawing.Point(831, 56)
        Me.CbSeleccion.Name = "CbSeleccion"
        Me.CbSeleccion.Size = New System.Drawing.Size(120, 17)
        Me.CbSeleccion.TabIndex = 2
        Me.CbSeleccion.Text = "SELECCIONADO"
        Me.CbSeleccion.UseVisualStyleBackColor = False
        '
        'BtnExportar
        '
        Me.BtnExportar.BackColor = System.Drawing.Color.Transparent
        Me.BtnExportar.FlatAppearance.BorderSize = 0
        Me.BtnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnExportar.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_impresora
        Me.BtnExportar.Location = New System.Drawing.Point(957, 18)
        Me.BtnExportar.Name = "BtnExportar"
        Me.BtnExportar.Size = New System.Drawing.Size(63, 63)
        Me.BtnExportar.TabIndex = 3
        Me.BtnExportar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnExportar.UseVisualStyleBackColor = False
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "RECEPCION"
        Me.DataGridViewTextBoxColumn1.HeaderText = "CLIENTE"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 200
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "frec_contenedor"
        Me.DataGridViewTextBoxColumn2.HeaderText = "CONTRATO"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 200
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "cli_nomb"
        Me.DataGridViewTextBoxColumn3.HeaderText = "CONTENEDOR"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 200
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "cont_desc"
        Me.DataGridViewTextBoxColumn4.HeaderText = "CONTRATO"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 200
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "BLOQ"
        Me.DataGridViewTextBoxColumn5.HeaderText = "COD"
        Me.DataGridViewTextBoxColumn5.MinimumWidth = 2
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn5.Width = 2
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "ETIQ"
        Me.DataGridViewTextBoxColumn6.HeaderText = "COD"
        Me.DataGridViewTextBoxColumn6.MinimumWidth = 2
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn6.Width = 2
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "REV"
        Me.DataGridViewTextBoxColumn7.HeaderText = "COD"
        Me.DataGridViewTextBoxColumn7.MinimumWidth = 2
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn7.Width = 2
        '
        'Frm_Contenedores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(1043, 526)
        Me.Controls.Add(Me.BtnExportar)
        Me.Controls.Add(Me.CbSeleccion)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.DgvContenedores)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "Frm_Contenedores"
        Me.Padding = New System.Windows.Forms.Padding(20, 100, 20, 20)
        Me.Text = "Contenedores pendientes"
        CType(Me.DgvContenedores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DgvContenedores As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ComboEstado As System.Windows.Forms.ComboBox
    Friend WithEvents rutcli As System.Windows.Forms.TextBox
    Friend WithEvents btn_BuscaCliente As System.Windows.Forms.Button
    Friend WithEvents nomcli As System.Windows.Forms.TextBox
    Friend WithEvents CbCliente As System.Windows.Forms.CheckBox
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BtnFiltrar As System.Windows.Forms.Button
    Friend WithEvents DataGridViewImageColumn1 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents CbSeleccion As System.Windows.Forms.CheckBox
    Friend WithEvents BtnExportar As System.Windows.Forms.Button
    Friend WithEvents RECEPCION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CONTENEDOR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CLIENTE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CONTRATO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ECOD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ETIQUETADO As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents RCOD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents REVISION As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents BCOD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RESOLUCION As System.Windows.Forms.DataGridViewImageColumn
End Class

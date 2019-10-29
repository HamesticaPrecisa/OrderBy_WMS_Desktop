<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_ConfProcesoTunel
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.dgrReglas = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fct_horas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fct_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnIncluirRegla = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chkPermitirGuiaParcial = New System.Windows.Forms.CheckBox()
        Me.txtHoraBase = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cboAlertaDetencion = New System.Windows.Forms.ComboBox()
        Me.cboAlertaInicioDemorado = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cboCantFotos = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboCantMuestras = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.cboAlertasTunel1 = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboAlertasTunel2 = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cboAlertasTunel3 = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgrReglas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnEliminar)
        Me.GroupBox1.Controls.Add(Me.dgrReglas)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.btnIncluirRegla)
        Me.GroupBox1.Location = New System.Drawing.Point(380, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(670, 524)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'btnEliminar
        '
        Me.btnEliminar.BackColor = System.Drawing.Color.Red
        Me.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEliminar.ForeColor = System.Drawing.Color.White
        Me.btnEliminar.Location = New System.Drawing.Point(9, 479)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(137, 29)
        Me.btnEliminar.TabIndex = 6
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = False
        '
        'dgrReglas
        '
        Me.dgrReglas.AllowUserToAddRows = False
        Me.dgrReglas.AllowUserToDeleteRows = False
        Me.dgrReglas.AllowUserToResizeRows = False
        Me.dgrReglas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgrReglas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.fct_horas, Me.Column6, Me.fct_id})
        Me.dgrReglas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgrReglas.Location = New System.Drawing.Point(9, 41)
        Me.dgrReglas.MultiSelect = False
        Me.dgrReglas.Name = "dgrReglas"
        Me.dgrReglas.ReadOnly = True
        Me.dgrReglas.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        Me.dgrReglas.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgrReglas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgrReglas.Size = New System.Drawing.Size(655, 428)
        Me.dgrReglas.TabIndex = 5
        '
        'Column1
        '
        Me.Column1.DataPropertyName = "fam_descr"
        Me.Column1.HeaderText = "Familia"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.DataPropertyName = "cli_nomb"
        Me.Column2.HeaderText = "Productor"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 230
        '
        'Column3
        '
        Me.Column3.DataPropertyName = "fct_tmpini"
        Me.Column3.HeaderText = "T. Ini"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 60
        '
        'Column4
        '
        Me.Column4.DataPropertyName = "fct_tmpfin"
        Me.Column4.HeaderText = "T. Fin"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 60
        '
        'fct_horas
        '
        Me.fct_horas.DataPropertyName = "fct_horas"
        Me.fct_horas.HeaderText = "Horas"
        Me.fct_horas.Name = "fct_horas"
        Me.fct_horas.ReadOnly = True
        Me.fct_horas.Width = 60
        '
        'Column6
        '
        Me.Column6.DataPropertyName = "fct_kilos"
        Me.Column6.HeaderText = "Kilos"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Width = 80
        '
        'fct_id
        '
        Me.fct_id.HeaderText = "Id"
        Me.fct_id.Name = "fct_id"
        Me.fct_id.ReadOnly = True
        Me.fct_id.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(110, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Factor Congelamiento"
        '
        'btnIncluirRegla
        '
        Me.btnIncluirRegla.ForeColor = System.Drawing.Color.Black
        Me.btnIncluirRegla.Location = New System.Drawing.Point(527, 479)
        Me.btnIncluirRegla.Name = "btnIncluirRegla"
        Me.btnIncluirRegla.Size = New System.Drawing.Size(137, 29)
        Me.btnIncluirRegla.TabIndex = 4
        Me.btnIncluirRegla.Text = "Agregar"
        Me.btnIncluirRegla.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "General"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkPermitirGuiaParcial)
        Me.GroupBox2.Controls.Add(Me.txtHoraBase)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Location = New System.Drawing.Point(23, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(341, 100)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        '
        'chkPermitirGuiaParcial
        '
        Me.chkPermitirGuiaParcial.AutoSize = True
        Me.chkPermitirGuiaParcial.Location = New System.Drawing.Point(23, 77)
        Me.chkPermitirGuiaParcial.Name = "chkPermitirGuiaParcial"
        Me.chkPermitirGuiaParcial.Size = New System.Drawing.Size(233, 17)
        Me.chkPermitirGuiaParcial.TabIndex = 5
        Me.chkPermitirGuiaParcial.Text = "PERMITIR GUIAS PARCIALES EN TUNEL"
        Me.chkPermitirGuiaParcial.UseVisualStyleBackColor = True
        '
        'txtHoraBase
        '
        Me.txtHoraBase.Location = New System.Drawing.Point(141, 41)
        Me.txtHoraBase.Name = "txtHoraBase"
        Me.txtHoraBase.Size = New System.Drawing.Size(65, 20)
        Me.txtHoraBase.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(20, 44)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(115, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "HORA BASE (HH:MM)"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cboAlertaDetencion)
        Me.GroupBox3.Controls.Add(Me.cboAlertaInicioDemorado)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.cboCantFotos)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.cboCantMuestras)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Location = New System.Drawing.Point(22, 118)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(341, 197)
        Me.GroupBox3.TabIndex = 9
        Me.GroupBox3.TabStop = False
        '
        'cboAlertaDetencion
        '
        Me.cboAlertaDetencion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAlertaDetencion.FormattingEnabled = True
        Me.cboAlertaDetencion.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "12", "24"})
        Me.cboAlertaDetencion.Location = New System.Drawing.Point(251, 143)
        Me.cboAlertaDetencion.Name = "cboAlertaDetencion"
        Me.cboAlertaDetencion.Size = New System.Drawing.Size(49, 21)
        Me.cboAlertaDetencion.TabIndex = 14
        '
        'cboAlertaInicioDemorado
        '
        Me.cboAlertaInicioDemorado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAlertaInicioDemorado.FormattingEnabled = True
        Me.cboAlertaInicioDemorado.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "12", "24"})
        Me.cboAlertaInicioDemorado.Location = New System.Drawing.Point(251, 116)
        Me.cboAlertaInicioDemorado.Name = "cboAlertaInicioDemorado"
        Me.cboAlertaInicioDemorado.Size = New System.Drawing.Size(49, 21)
        Me.cboAlertaInicioDemorado.TabIndex = 13
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(21, 146)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(206, 13)
        Me.Label12.TabIndex = 12
        Me.Label12.Text = "HORAS PARA ALERTA DE DETENCION"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(21, 120)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(223, 13)
        Me.Label11.TabIndex = 10
        Me.Label11.Text = "HORAS PARA ALERTA INICIO DEMORADO"
        '
        'cboCantFotos
        '
        Me.cboCantFotos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCantFotos.FormattingEnabled = True
        Me.cboCantFotos.Items.AddRange(New Object() {"1", "2", "3", "4", "5"})
        Me.cboCantFotos.Location = New System.Drawing.Point(167, 68)
        Me.cboCantFotos.Name = "cboCantFotos"
        Me.cboCantFotos.Size = New System.Drawing.Size(40, 21)
        Me.cboCantFotos.TabIndex = 9
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(21, 72)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(125, 13)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "FOTOS POR MUESTRA"
        '
        'cboCantMuestras
        '
        Me.cboCantMuestras.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCantMuestras.FormattingEnabled = True
        Me.cboCantMuestras.Items.AddRange(New Object() {"1", "2", "3", "4", "5"})
        Me.cboCantMuestras.Location = New System.Drawing.Point(167, 41)
        Me.cboCantMuestras.Name = "cboCantMuestras"
        Me.cboCantMuestras.Size = New System.Drawing.Size(40, 21)
        Me.cboCantMuestras.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(21, 45)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(141, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "MUESTRAS REQUERIDAS"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Calidad"
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "fam_descr"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Id"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "fam_descr"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Familia"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 230
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "cli_nomb"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Productor"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 250
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "fct_tmpini"
        Me.DataGridViewTextBoxColumn4.HeaderText = "T. Ini"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 60
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "fct_tmpfin"
        Me.DataGridViewTextBoxColumn5.HeaderText = "T. Fin"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 60
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "fct_horas"
        Me.DataGridViewTextBoxColumn6.HeaderText = "Horas"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Width = 60
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "fct_kilos"
        Me.DataGridViewTextBoxColumn7.HeaderText = "Kilos"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Visible = False
        Me.DataGridViewTextBoxColumn7.Width = 80
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label9)
        Me.GroupBox4.Controls.Add(Me.cboAlertasTunel3)
        Me.GroupBox4.Controls.Add(Me.Label15)
        Me.GroupBox4.Controls.Add(Me.Label5)
        Me.GroupBox4.Controls.Add(Me.cboAlertasTunel2)
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Controls.Add(Me.Label14)
        Me.GroupBox4.Controls.Add(Me.cboAlertasTunel1)
        Me.GroupBox4.Controls.Add(Me.Label10)
        Me.GroupBox4.Controls.Add(Me.Label13)
        Me.GroupBox4.Location = New System.Drawing.Point(22, 324)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(341, 197)
        Me.GroupBox4.TabIndex = 10
        Me.GroupBox4.TabStop = False
        '
        'cboAlertasTunel1
        '
        Me.cboAlertasTunel1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAlertasTunel1.FormattingEnabled = True
        Me.cboAlertasTunel1.Items.AddRange(New Object() {"24", "18", "12", "6", "3", "2", "1", "0"})
        Me.cboAlertasTunel1.Location = New System.Drawing.Point(140, 41)
        Me.cboAlertasTunel1.Name = "cboAlertasTunel1"
        Me.cboAlertasTunel1.Size = New System.Drawing.Size(40, 21)
        Me.cboAlertasTunel1.TabIndex = 7
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(21, 45)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(106, 13)
        Me.Label10.TabIndex = 6
        Me.Label10.Text = "1RA ALERTA A LAS"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(6, 16)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(127, 13)
        Me.Label13.TabIndex = 2
        Me.Label13.Text = "Alertas de Inicio de Tunel"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(186, 45)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(45, 13)
        Me.Label14.TabIndex = 15
        Me.Label14.Text = "HORAS"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(185, 72)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 13)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "HORAS"
        '
        'cboAlertasTunel2
        '
        Me.cboAlertasTunel2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAlertasTunel2.FormattingEnabled = True
        Me.cboAlertasTunel2.Items.AddRange(New Object() {"24", "18", "12", "6", "3", "2", "1", "0"})
        Me.cboAlertasTunel2.Location = New System.Drawing.Point(139, 68)
        Me.cboAlertasTunel2.Name = "cboAlertasTunel2"
        Me.cboAlertasTunel2.Size = New System.Drawing.Size(40, 21)
        Me.cboAlertasTunel2.TabIndex = 17
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(20, 72)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(106, 13)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "2DA ALERTA A LAS"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(186, 101)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(45, 13)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "HORAS"
        '
        'cboAlertasTunel3
        '
        Me.cboAlertasTunel3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAlertasTunel3.FormattingEnabled = True
        Me.cboAlertasTunel3.Items.AddRange(New Object() {"24", "18", "12", "6", "3", "2", "1", "0"})
        Me.cboAlertasTunel3.Location = New System.Drawing.Point(140, 97)
        Me.cboAlertasTunel3.Name = "cboAlertasTunel3"
        Me.cboAlertasTunel3.Size = New System.Drawing.Size(40, 21)
        Me.cboAlertasTunel3.TabIndex = 20
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(21, 101)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(106, 13)
        Me.Label15.TabIndex = 19
        Me.Label15.Text = "3RA ALERTA A LAS"
        '
        'Frm_ConfProcesoTunel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(1061, 555)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.ForeColor = System.Drawing.Color.White
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_ConfProcesoTunel"
        Me.Text = "Configuración Proceso de Túnel"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgrReglas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnIncluirRegla As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtHoraBase As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents chkPermitirGuiaParcial As System.Windows.Forms.CheckBox
    Friend WithEvents cboCantFotos As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboCantMuestras As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dgrReglas As System.Windows.Forms.DataGridView
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents fct_horas As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents fct_id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cboAlertaInicioDemorado As System.Windows.Forms.ComboBox
    Friend WithEvents cboAlertaDetencion As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cboAlertasTunel1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cboAlertasTunel3 As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboAlertasTunel2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
End Class

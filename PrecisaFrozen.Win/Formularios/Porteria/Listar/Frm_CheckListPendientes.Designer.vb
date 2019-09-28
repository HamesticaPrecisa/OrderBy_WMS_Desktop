<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_CheckListPendientes
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_CheckListPendientes))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblfolio = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.BtnCancelaSalida = New System.Windows.Forms.Button()
        Me.TxtTemp = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.BtnActualizaSalida = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Rb_SectorSur = New System.Windows.Forms.RadioButton()
        Me.TxtAnden = New System.Windows.Forms.TextBox()
        Me.btn_CancelaIngreso = New System.Windows.Forms.Button()
        Me.BtnActualizaIngreso = New System.Windows.Forms.Button()
        Me.RbContenedores = New System.Windows.Forms.RadioButton()
        Me.RbAndenes = New System.Windows.Forms.RadioButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.DgvContenedores = New System.Windows.Forms.DataGridView()
        Me.Folio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Patente_3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Movimiento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ingresar = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.DgvAndenes = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Patente_2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewImageColumn1 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.DgvRegistrados = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Patente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ing = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Mov = New System.Windows.Forms.Timer(Me.components)
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.DgvContenedores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel8.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        CType(Me.DgvAndenes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel7.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.DgvRegistrados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel6.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Panel1.Controls.Add(Me.lblfolio)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1107, 677)
        Me.Panel1.TabIndex = 0
        '
        'lblfolio
        '
        Me.lblfolio.AutoSize = True
        Me.lblfolio.Location = New System.Drawing.Point(914, 16)
        Me.lblfolio.Name = "lblfolio"
        Me.lblfolio.Size = New System.Drawing.Size(0, 13)
        Me.lblfolio.TabIndex = 5
        Me.lblfolio.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(856, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(51, 14)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "FOLIO"
        Me.Label6.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.BtnCancelaSalida)
        Me.GroupBox2.Controls.Add(Me.TxtTemp)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.BtnActualizaSalida)
        Me.GroupBox2.ForeColor = System.Drawing.Color.White
        Me.GroupBox2.Location = New System.Drawing.Point(850, 294)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(226, 116)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "SALIDA DE CAMION :"
        Me.GroupBox2.Visible = False
        '
        'BtnCancelaSalida
        '
        Me.BtnCancelaSalida.ForeColor = System.Drawing.Color.Black
        Me.BtnCancelaSalida.Location = New System.Drawing.Point(126, 70)
        Me.BtnCancelaSalida.Name = "BtnCancelaSalida"
        Me.BtnCancelaSalida.Size = New System.Drawing.Size(90, 28)
        Me.BtnCancelaSalida.TabIndex = 6
        Me.BtnCancelaSalida.Text = "[ Cancelar ]"
        Me.BtnCancelaSalida.UseVisualStyleBackColor = True
        '
        'TxtTemp
        '
        Me.TxtTemp.Location = New System.Drawing.Point(117, 36)
        Me.TxtTemp.MaxLength = 5
        Me.TxtTemp.Name = "TxtTemp"
        Me.TxtTemp.Size = New System.Drawing.Size(51, 21)
        Me.TxtTemp.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(23, 39)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "T°. SALIDA"
        '
        'BtnActualizaSalida
        '
        Me.BtnActualizaSalida.ForeColor = System.Drawing.Color.Black
        Me.BtnActualizaSalida.Location = New System.Drawing.Point(9, 70)
        Me.BtnActualizaSalida.Name = "BtnActualizaSalida"
        Me.BtnActualizaSalida.Size = New System.Drawing.Size(99, 28)
        Me.BtnActualizaSalida.TabIndex = 3
        Me.BtnActualizaSalida.Text = "[ Actualizar ]"
        Me.BtnActualizaSalida.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Rb_SectorSur)
        Me.GroupBox1.Controls.Add(Me.TxtAnden)
        Me.GroupBox1.Controls.Add(Me.btn_CancelaIngreso)
        Me.GroupBox1.Controls.Add(Me.BtnActualizaIngreso)
        Me.GroupBox1.Controls.Add(Me.RbContenedores)
        Me.GroupBox1.Controls.Add(Me.RbAndenes)
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(859, 56)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(217, 139)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "ENVIAR CAMION A :"
        Me.GroupBox1.Visible = False
        '
        'Rb_SectorSur
        '
        Me.Rb_SectorSur.AutoSize = True
        Me.Rb_SectorSur.Location = New System.Drawing.Point(17, 75)
        Me.Rb_SectorSur.Name = "Rb_SectorSur"
        Me.Rb_SectorSur.Size = New System.Drawing.Size(101, 17)
        Me.Rb_SectorSur.TabIndex = 9
        Me.Rb_SectorSur.TabStop = True
        Me.Rb_SectorSur.Text = "SECTOR SUR"
        Me.Rb_SectorSur.UseVisualStyleBackColor = True
        '
        'TxtAnden
        '
        Me.TxtAnden.Location = New System.Drawing.Point(108, 25)
        Me.TxtAnden.MaxLength = 2
        Me.TxtAnden.Name = "TxtAnden"
        Me.TxtAnden.Size = New System.Drawing.Size(29, 21)
        Me.TxtAnden.TabIndex = 8
        '
        'btn_CancelaIngreso
        '
        Me.btn_CancelaIngreso.ForeColor = System.Drawing.Color.Black
        Me.btn_CancelaIngreso.Location = New System.Drawing.Point(116, 101)
        Me.btn_CancelaIngreso.Name = "btn_CancelaIngreso"
        Me.btn_CancelaIngreso.Size = New System.Drawing.Size(90, 28)
        Me.btn_CancelaIngreso.TabIndex = 7
        Me.btn_CancelaIngreso.Text = "[ Cancelar ]"
        Me.btn_CancelaIngreso.UseVisualStyleBackColor = True
        '
        'BtnActualizaIngreso
        '
        Me.BtnActualizaIngreso.ForeColor = System.Drawing.Color.Black
        Me.BtnActualizaIngreso.Location = New System.Drawing.Point(8, 101)
        Me.BtnActualizaIngreso.Name = "BtnActualizaIngreso"
        Me.BtnActualizaIngreso.Size = New System.Drawing.Size(99, 28)
        Me.BtnActualizaIngreso.TabIndex = 3
        Me.BtnActualizaIngreso.Text = "[ Actualizar ]"
        Me.BtnActualizaIngreso.UseVisualStyleBackColor = True
        '
        'RbContenedores
        '
        Me.RbContenedores.AutoSize = True
        Me.RbContenedores.Location = New System.Drawing.Point(17, 50)
        Me.RbContenedores.Name = "RbContenedores"
        Me.RbContenedores.Size = New System.Drawing.Size(167, 17)
        Me.RbContenedores.TabIndex = 2
        Me.RbContenedores.TabStop = True
        Me.RbContenedores.Text = "CARGA CONTENEDORES"
        Me.RbContenedores.UseVisualStyleBackColor = True
        '
        'RbAndenes
        '
        Me.RbAndenes.AutoSize = True
        Me.RbAndenes.Location = New System.Drawing.Point(17, 25)
        Me.RbAndenes.Name = "RbAndenes"
        Me.RbAndenes.Size = New System.Drawing.Size(80, 17)
        Me.RbAndenes.TabIndex = 1
        Me.RbAndenes.TabStop = True
        Me.RbAndenes.Text = "ANDENES"
        Me.RbAndenes.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.fondo_completo
        Me.Panel2.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(797, 677)
        Me.Panel2.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.Panel5, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel4, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel3, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Button1, 0, 3)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(797, 677)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Transparent
        Me.Panel5.BackgroundImage = CType(resources.GetObject("Panel5.BackgroundImage"), System.Drawing.Image)
        Me.Panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel5.Controls.Add(Me.DgvContenedores)
        Me.Panel5.Controls.Add(Me.Panel8)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(3, 435)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(791, 210)
        Me.Panel5.TabIndex = 2
        '
        'DgvContenedores
        '
        Me.DgvContenedores.AllowUserToAddRows = False
        Me.DgvContenedores.AllowUserToDeleteRows = False
        Me.DgvContenedores.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark
        Me.DgvContenedores.ColumnHeadersHeight = 28
        Me.DgvContenedores.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Folio, Me.Cliente, Me.Patente_3, Me.Movimiento, Me.Ingresar})
        Me.DgvContenedores.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvContenedores.Location = New System.Drawing.Point(0, 40)
        Me.DgvContenedores.Name = "DgvContenedores"
        Me.DgvContenedores.ReadOnly = True
        Me.DgvContenedores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvContenedores.Size = New System.Drawing.Size(791, 170)
        Me.DgvContenedores.TabIndex = 5
        '
        'Folio
        '
        Me.Folio.DataPropertyName = "cl_fol"
        Me.Folio.HeaderText = "Folio"
        Me.Folio.Name = "Folio"
        Me.Folio.ReadOnly = True
        Me.Folio.Width = 65
        '
        'Cliente
        '
        Me.Cliente.DataPropertyName = "cli_nomb"
        Me.Cliente.HeaderText = "Cliente"
        Me.Cliente.Name = "Cliente"
        Me.Cliente.ReadOnly = True
        Me.Cliente.Width = 300
        '
        'Patente_3
        '
        Me.Patente_3.DataPropertyName = "cl_pate"
        Me.Patente_3.HeaderText = "Patente"
        Me.Patente_3.Name = "Patente_3"
        Me.Patente_3.ReadOnly = True
        '
        'Movimiento
        '
        Me.Movimiento.DataPropertyName = "mov_desc"
        Me.Movimiento.HeaderText = "Movimiento"
        Me.Movimiento.Name = "Movimiento"
        Me.Movimiento.ReadOnly = True
        Me.Movimiento.Width = 120
        '
        'Ingresar
        '
        Me.Ingresar.HeaderText = "Ingresar"
        Me.Ingresar.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.ok_16
        Me.Ingresar.Name = "Ingresar"
        Me.Ingresar.ReadOnly = True
        Me.Ingresar.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Ingresar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Ingresar.Width = 70
        '
        'Panel8
        '
        Me.Panel8.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.barra
        Me.Panel8.Controls.Add(Me.Label3)
        Me.Panel8.Controls.Add(Me.PictureBox1)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel8.Location = New System.Drawing.Point(0, 0)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(791, 40)
        Me.Panel8.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(46, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(303, 16)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "CAMIONES EN CARGA DE CONTENEDORES"
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Left
        Me.PictureBox1.Image = Global.PrecisaFrozen.Win.My.Resources.Resources._1391114862_battery_plug
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Transparent
        Me.Panel4.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.barra
        Me.Panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel4.Controls.Add(Me.DgvAndenes)
        Me.Panel4.Controls.Add(Me.Panel7)
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(3, 219)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(791, 210)
        Me.Panel4.TabIndex = 1
        '
        'DgvAndenes
        '
        Me.DgvAndenes.AllowUserToAddRows = False
        Me.DgvAndenes.AllowUserToDeleteRows = False
        Me.DgvAndenes.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark
        Me.DgvAndenes.ColumnHeadersHeight = 28
        Me.DgvAndenes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.Patente_2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewImageColumn1})
        Me.DgvAndenes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvAndenes.Location = New System.Drawing.Point(0, 40)
        Me.DgvAndenes.Name = "DgvAndenes"
        Me.DgvAndenes.ReadOnly = True
        Me.DgvAndenes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvAndenes.Size = New System.Drawing.Size(791, 170)
        Me.DgvAndenes.TabIndex = 2
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "cl_fol"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Folio"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 65
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "cli_nomb"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Cliente"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 300
        '
        'Patente_2
        '
        Me.Patente_2.DataPropertyName = "cl_pate"
        Me.Patente_2.HeaderText = "Patente"
        Me.Patente_2.Name = "Patente_2"
        Me.Patente_2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "mov_desc"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Movimiento"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 150
        '
        'DataGridViewImageColumn1
        '
        Me.DataGridViewImageColumn1.HeaderText = "Ingresar"
        Me.DataGridViewImageColumn1.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.ok_16
        Me.DataGridViewImageColumn1.Name = "DataGridViewImageColumn1"
        Me.DataGridViewImageColumn1.ReadOnly = True
        Me.DataGridViewImageColumn1.Width = 60
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.Label4)
        Me.Panel7.Controls.Add(Me.PictureBox4)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel7.Location = New System.Drawing.Point(0, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(791, 40)
        Me.Panel7.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(46, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(263, 16)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "CAMIONES  UBICADOS EN ANDENES"
        '
        'PictureBox4
        '
        Me.PictureBox4.Dock = System.Windows.Forms.DockStyle.Left
        Me.PictureBox4.Image = Global.PrecisaFrozen.Win.My.Resources.Resources._1391114767_sign_out
        Me.PictureBox4.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox4.TabIndex = 1
        Me.PictureBox4.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label2.Location = New System.Drawing.Point(46, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(161, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "CAMIONES EN ANDEN"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Transparent
        Me.Panel3.BackgroundImage = CType(resources.GetObject("Panel3.BackgroundImage"), System.Drawing.Image)
        Me.Panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel3.Controls.Add(Me.DgvRegistrados)
        Me.Panel3.Controls.Add(Me.Panel6)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(3, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(791, 210)
        Me.Panel3.TabIndex = 0
        '
        'DgvRegistrados
        '
        Me.DgvRegistrados.AllowUserToAddRows = False
        Me.DgvRegistrados.AllowUserToDeleteRows = False
        Me.DgvRegistrados.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark
        Me.DgvRegistrados.ColumnHeadersHeight = 28
        Me.DgvRegistrados.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.Patente, Me.DataGridViewTextBoxColumn6, Me.ing})
        Me.DgvRegistrados.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvRegistrados.Location = New System.Drawing.Point(0, 40)
        Me.DgvRegistrados.Name = "DgvRegistrados"
        Me.DgvRegistrados.ReadOnly = True
        Me.DgvRegistrados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvRegistrados.Size = New System.Drawing.Size(791, 170)
        Me.DgvRegistrados.TabIndex = 3
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "cl_fol"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Folio"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 65
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "cli_nomb"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Cliente"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 300
        '
        'Patente
        '
        Me.Patente.DataPropertyName = "cl_pate"
        Me.Patente.HeaderText = "Patente"
        Me.Patente.Name = "Patente"
        Me.Patente.ReadOnly = True
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "mov_desc"
        Me.DataGridViewTextBoxColumn6.HeaderText = "Movimiento"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Width = 150
        '
        'ing
        '
        Me.ing.HeaderText = "Ingresar"
        Me.ing.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.ok_16
        Me.ing.Name = "ing"
        Me.ing.ReadOnly = True
        Me.ing.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ing.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.ing.Width = 60
        '
        'Panel6
        '
        Me.Panel6.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.barra
        Me.Panel6.Controls.Add(Me.Label1)
        Me.Panel6.Controls.Add(Me.PictureBox3)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(791, 40)
        Me.Panel6.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(46, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(189, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "CAMIONES REGISTRADOS"
        '
        'PictureBox3
        '
        Me.PictureBox3.Dock = System.Windows.Forms.DockStyle.Left
        Me.PictureBox3.Image = Global.PrecisaFrozen.Win.My.Resources.Resources._1391114781_sign_in
        Me.PictureBox3.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox3.TabIndex = 1
        Me.PictureBox3.TabStop = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(3, 651)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(137, 23)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Listado ingresado"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Mov
        '
        Me.Mov.Interval = 5000
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "cl_pate"
        Me.DataGridViewTextBoxColumn7.HeaderText = "Patente"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "mov_desc"
        Me.DataGridViewTextBoxColumn8.HeaderText = "Movimiento"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.Width = 150
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "cl_fol"
        Me.DataGridViewTextBoxColumn9.HeaderText = "Folio"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.Width = 65
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "cli_nomb"
        Me.DataGridViewTextBoxColumn10.HeaderText = "Cliente"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.Width = 300
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "cl_pate"
        Me.DataGridViewTextBoxColumn11.HeaderText = "Patente"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "mov_desc"
        Me.DataGridViewTextBoxColumn12.HeaderText = "Movimiento"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.Width = 150
        '
        'Frm_CheckListPendientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(1107, 677)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "Frm_CheckListPendientes"
        Me.Text = "Listado de camiones pendientes"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        CType(Me.DgvContenedores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.DgvAndenes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        CType(Me.DgvRegistrados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents DgvContenedores As System.Windows.Forms.DataGridView
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents DgvAndenes As System.Windows.Forms.DataGridView
    Friend WithEvents DgvRegistrados As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnActualizaIngreso As System.Windows.Forms.Button
    Friend WithEvents RbContenedores As System.Windows.Forms.RadioButton
    Friend WithEvents RbAndenes As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtTemp As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents BtnActualizaSalida As System.Windows.Forms.Button
    Friend WithEvents BtnCancelaSalida As System.Windows.Forms.Button
    Friend WithEvents btn_CancelaIngreso As System.Windows.Forms.Button
    Friend WithEvents lblfolio As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Mov As System.Windows.Forms.Timer
    Friend WithEvents TxtAnden As System.Windows.Forms.TextBox
    Friend WithEvents Rb_SectorSur As System.Windows.Forms.RadioButton
    Friend WithEvents Folio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Patente_3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Movimiento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Ingresar As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Patente_2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewImageColumn1 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Patente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ing As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

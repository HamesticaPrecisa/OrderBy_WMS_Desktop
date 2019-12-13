<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_AddEnvioEmail
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
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.grptiempo = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtminutos = New System.Windows.Forms.TextBox()
        Me.btn_pdf = New System.Windows.Forms.Button()
        Me.btn_imagenes = New System.Windows.Forms.Button()
        Me.btn_informes = New System.Windows.Forms.Button()
        Me.cboinformes = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.rdidesactivado = New System.Windows.Forms.RadioButton()
        Me.rdiactivado = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbtFrecManual = New System.Windows.Forms.RadioButton()
        Me.rbtFrecRepetir = New System.Windows.Forms.RadioButton()
        Me.txtHoraH = New System.Windows.Forms.MaskedTextBox()
        Me.chktodos = New System.Windows.Forms.CheckBox()
        Me.lblHoraH = New System.Windows.Forms.Label()
        Me.chkdomingo = New System.Windows.Forms.CheckBox()
        Me.txthora = New System.Windows.Forms.MaskedTextBox()
        Me.chksabado = New System.Windows.Forms.CheckBox()
        Me.lblHoraD = New System.Windows.Forms.Label()
        Me.chkviernes = New System.Windows.Forms.CheckBox()
        Me.cboInterv = New System.Windows.Forms.ComboBox()
        Me.txtFrec = New System.Windows.Forms.TextBox()
        Me.chkjueves = New System.Windows.Forms.CheckBox()
        Me.chkmiercoles = New System.Windows.Forms.CheckBox()
        Me.chkmartes = New System.Windows.Forms.CheckBox()
        Me.chklunes = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btn_quitarmail = New System.Windows.Forms.Button()
        Me.dtgcorreos = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewImageColumn9 = New System.Windows.Forms.DataGridViewImageColumn()
        Me._em1 = New System.Windows.Forms.TextBox()
        Me.btn_agregarmail = New System.Windows.Forms.Button()
        Me.Btn_Salir = New System.Windows.Forms.Button()
        Me.Btn_Nuevo = New System.Windows.Forms.Button()
        Me.Btn_Guardar = New System.Windows.Forms.Button()
        Me.txtgiro = New System.Windows.Forms.TextBox()
        Me.txtrsocial = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtrut = New System.Windows.Forms.MaskedTextBox()
        Me.chkinterno = New System.Windows.Forms.CheckBox()
        Me.DataGridViewImageColumn1 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Btn_BuscaCliente = New System.Windows.Forms.Button()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox3.SuspendLayout()
        Me.grptiempo.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dtgcorreos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.grptiempo)
        Me.GroupBox3.Controls.Add(Me.btn_pdf)
        Me.GroupBox3.Controls.Add(Me.btn_imagenes)
        Me.GroupBox3.Controls.Add(Me.btn_informes)
        Me.GroupBox3.Controls.Add(Me.cboinformes)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.GroupBox5)
        Me.GroupBox3.Controls.Add(Me.GroupBox1)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.GroupBox2)
        Me.GroupBox3.Controls.Add(Me.Btn_Salir)
        Me.GroupBox3.Controls.Add(Me.Btn_Nuevo)
        Me.GroupBox3.Controls.Add(Me.Btn_Guardar)
        Me.GroupBox3.Controls.Add(Me.txtgiro)
        Me.GroupBox3.Controls.Add(Me.txtrsocial)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Location = New System.Drawing.Point(14, 44)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(740, 665)
        Me.GroupBox3.TabIndex = 38
        Me.GroupBox3.TabStop = False
        '
        'grptiempo
        '
        Me.grptiempo.Controls.Add(Me.Label3)
        Me.grptiempo.Controls.Add(Me.txtminutos)
        Me.grptiempo.Enabled = False
        Me.grptiempo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grptiempo.ForeColor = System.Drawing.Color.White
        Me.grptiempo.Location = New System.Drawing.Point(338, 237)
        Me.grptiempo.Name = "grptiempo"
        Me.grptiempo.Size = New System.Drawing.Size(187, 50)
        Me.grptiempo.TabIndex = 67
        Me.grptiempo.TabStop = False
        Me.grptiempo.Text = "Tiempo"
        Me.grptiempo.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(9, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 13)
        Me.Label3.TabIndex = 72
        Me.Label3.Text = "Minutos: "
        '
        'txtminutos
        '
        Me.txtminutos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtminutos.Enabled = False
        Me.txtminutos.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtminutos.Location = New System.Drawing.Point(67, 20)
        Me.txtminutos.MaxLength = 40
        Me.txtminutos.Name = "txtminutos"
        Me.txtminutos.Size = New System.Drawing.Size(33, 21)
        Me.txtminutos.TabIndex = 71
        Me.txtminutos.Text = "0"
        Me.txtminutos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btn_pdf
        '
        Me.btn_pdf.FlatAppearance.BorderSize = 0
        Me.btn_pdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_pdf.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_impresora
        Me.btn_pdf.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_pdf.Location = New System.Drawing.Point(644, 143)
        Me.btn_pdf.Name = "btn_pdf"
        Me.btn_pdf.Size = New System.Drawing.Size(63, 63)
        Me.btn_pdf.TabIndex = 70
        Me.btn_pdf.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_pdf.UseVisualStyleBackColor = True
        '
        'btn_imagenes
        '
        Me.btn_imagenes.Enabled = False
        Me.btn_imagenes.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_imagenes.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_de_jpg_355881
        Me.btn_imagenes.Location = New System.Drawing.Point(508, 78)
        Me.btn_imagenes.Name = "btn_imagenes"
        Me.btn_imagenes.Size = New System.Drawing.Size(27, 24)
        Me.btn_imagenes.TabIndex = 69
        Me.btn_imagenes.UseVisualStyleBackColor = True
        '
        'btn_informes
        '
        Me.btn_informes.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_informes.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.folder_add
        Me.btn_informes.Location = New System.Drawing.Point(475, 78)
        Me.btn_informes.Name = "btn_informes"
        Me.btn_informes.Size = New System.Drawing.Size(27, 24)
        Me.btn_informes.TabIndex = 57
        Me.btn_informes.UseVisualStyleBackColor = True
        '
        'cboinformes
        '
        Me.cboinformes.Enabled = False
        Me.cboinformes.FormattingEnabled = True
        Me.cboinformes.Location = New System.Drawing.Point(167, 79)
        Me.cboinformes.Name = "cboinformes"
        Me.cboinformes.Size = New System.Drawing.Size(303, 21)
        Me.cboinformes.TabIndex = 68
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(14, 118)
        Me.Label1.Name = "Label1"
        Me.Label1.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.Label1.Size = New System.Drawing.Size(511, 22)
        Me.Label1.TabIndex = 67
        Me.Label1.Text = "Seleccione Plan"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.rdidesactivado)
        Me.GroupBox5.Controls.Add(Me.rdiactivado)
        Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.ForeColor = System.Drawing.Color.White
        Me.GroupBox5.Location = New System.Drawing.Point(339, 144)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(187, 87)
        Me.GroupBox5.TabIndex = 66
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Estado"
        '
        'rdidesactivado
        '
        Me.rdidesactivado.Enabled = False
        Me.rdidesactivado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdidesactivado.Location = New System.Drawing.Point(18, 49)
        Me.rdidesactivado.Name = "rdidesactivado"
        Me.rdidesactivado.Size = New System.Drawing.Size(113, 21)
        Me.rdidesactivado.TabIndex = 1
        Me.rdidesactivado.Text = "Desactivado"
        Me.rdidesactivado.UseVisualStyleBackColor = True
        '
        'rdiactivado
        '
        Me.rdiactivado.Enabled = False
        Me.rdiactivado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdiactivado.Location = New System.Drawing.Point(18, 27)
        Me.rdiactivado.Name = "rdiactivado"
        Me.rdiactivado.Size = New System.Drawing.Size(126, 16)
        Me.rdiactivado.TabIndex = 0
        Me.rdiactivado.Text = "Activado"
        Me.rdiactivado.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbtFrecManual)
        Me.GroupBox1.Controls.Add(Me.rbtFrecRepetir)
        Me.GroupBox1.Controls.Add(Me.txtHoraH)
        Me.GroupBox1.Controls.Add(Me.chktodos)
        Me.GroupBox1.Controls.Add(Me.lblHoraH)
        Me.GroupBox1.Controls.Add(Me.chkdomingo)
        Me.GroupBox1.Controls.Add(Me.txthora)
        Me.GroupBox1.Controls.Add(Me.chksabado)
        Me.GroupBox1.Controls.Add(Me.lblHoraD)
        Me.GroupBox1.Controls.Add(Me.chkviernes)
        Me.GroupBox1.Controls.Add(Me.cboInterv)
        Me.GroupBox1.Controls.Add(Me.txtFrec)
        Me.GroupBox1.Controls.Add(Me.chkjueves)
        Me.GroupBox1.Controls.Add(Me.chkmiercoles)
        Me.GroupBox1.Controls.Add(Me.chkmartes)
        Me.GroupBox1.Controls.Add(Me.chklunes)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(14, 143)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(307, 215)
        Me.GroupBox1.TabIndex = 64
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Frecuencia"
        '
        'rbtFrecManual
        '
        Me.rbtFrecManual.AutoSize = True
        Me.rbtFrecManual.Enabled = False
        Me.rbtFrecManual.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtFrecManual.Location = New System.Drawing.Point(11, 23)
        Me.rbtFrecManual.Name = "rbtFrecManual"
        Me.rbtFrecManual.Size = New System.Drawing.Size(60, 17)
        Me.rbtFrecManual.TabIndex = 0
        Me.rbtFrecManual.Text = "Manual"
        Me.rbtFrecManual.UseVisualStyleBackColor = True
        '
        'rbtFrecRepetir
        '
        Me.rbtFrecRepetir.AutoSize = True
        Me.rbtFrecRepetir.Enabled = False
        Me.rbtFrecRepetir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtFrecRepetir.Location = New System.Drawing.Point(11, 51)
        Me.rbtFrecRepetir.Name = "rbtFrecRepetir"
        Me.rbtFrecRepetir.Size = New System.Drawing.Size(91, 17)
        Me.rbtFrecRepetir.TabIndex = 1
        Me.rbtFrecRepetir.Text = "Ejecutar cada"
        Me.rbtFrecRepetir.UseVisualStyleBackColor = True
        '
        'txtHoraH
        '
        Me.txtHoraH.Enabled = False
        Me.txtHoraH.Location = New System.Drawing.Point(207, 78)
        Me.txtHoraH.Mask = "99:99"
        Me.txtHoraH.Name = "txtHoraH"
        Me.txtHoraH.Size = New System.Drawing.Size(47, 20)
        Me.txtHoraH.TabIndex = 5
        '
        'chktodos
        '
        Me.chktodos.AutoSize = True
        Me.chktodos.Enabled = False
        Me.chktodos.Location = New System.Drawing.Point(121, 113)
        Me.chktodos.Name = "chktodos"
        Me.chktodos.Size = New System.Drawing.Size(112, 17)
        Me.chktodos.TabIndex = 6
        Me.chktodos.Text = "Todos los Días"
        Me.chktodos.UseVisualStyleBackColor = True
        '
        'lblHoraH
        '
        Me.lblHoraH.AutoSize = True
        Me.lblHoraH.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHoraH.Location = New System.Drawing.Point(173, 79)
        Me.lblHoraH.Name = "lblHoraH"
        Me.lblHoraH.Size = New System.Drawing.Size(28, 13)
        Me.lblHoraH.TabIndex = 76
        Me.lblHoraH.Text = "y las"
        '
        'chkdomingo
        '
        Me.chkdomingo.AutoSize = True
        Me.chkdomingo.Enabled = False
        Me.chkdomingo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkdomingo.Location = New System.Drawing.Point(206, 171)
        Me.chkdomingo.Name = "chkdomingo"
        Me.chkdomingo.Size = New System.Drawing.Size(68, 17)
        Me.chkdomingo.TabIndex = 13
        Me.chkdomingo.Text = "Domingo"
        Me.chkdomingo.UseVisualStyleBackColor = True
        '
        'txthora
        '
        Me.txthora.Enabled = False
        Me.txthora.Location = New System.Drawing.Point(122, 77)
        Me.txthora.Mask = "99:99"
        Me.txthora.Name = "txthora"
        Me.txthora.Size = New System.Drawing.Size(47, 20)
        Me.txthora.TabIndex = 4
        '
        'chksabado
        '
        Me.chksabado.AutoSize = True
        Me.chksabado.Enabled = False
        Me.chksabado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chksabado.Location = New System.Drawing.Point(206, 153)
        Me.chksabado.Name = "chksabado"
        Me.chksabado.Size = New System.Drawing.Size(63, 17)
        Me.chksabado.TabIndex = 12
        Me.chksabado.Text = "Sábado"
        Me.chksabado.UseVisualStyleBackColor = True
        '
        'lblHoraD
        '
        Me.lblHoraD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHoraD.Location = New System.Drawing.Point(39, 79)
        Me.lblHoraD.Name = "lblHoraD"
        Me.lblHoraD.Size = New System.Drawing.Size(65, 14)
        Me.lblHoraD.TabIndex = 75
        Me.lblHoraD.Text = "entre las"
        Me.lblHoraD.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'chkviernes
        '
        Me.chkviernes.AutoSize = True
        Me.chkviernes.Enabled = False
        Me.chkviernes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkviernes.Location = New System.Drawing.Point(206, 135)
        Me.chkviernes.Name = "chkviernes"
        Me.chkviernes.Size = New System.Drawing.Size(61, 17)
        Me.chkviernes.TabIndex = 11
        Me.chkviernes.Text = "Viernes"
        Me.chkviernes.UseVisualStyleBackColor = True
        '
        'cboInterv
        '
        Me.cboInterv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboInterv.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboInterv.FormattingEnabled = True
        Me.cboInterv.Items.AddRange(New Object() {"dias", "horas", "minutos"})
        Me.cboInterv.Location = New System.Drawing.Point(174, 50)
        Me.cboInterv.Name = "cboInterv"
        Me.cboInterv.Size = New System.Drawing.Size(86, 23)
        Me.cboInterv.TabIndex = 3
        '
        'txtFrec
        '
        Me.txtFrec.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFrec.Enabled = False
        Me.txtFrec.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFrec.Location = New System.Drawing.Point(122, 51)
        Me.txtFrec.MaxLength = 3
        Me.txtFrec.Name = "txtFrec"
        Me.txtFrec.Size = New System.Drawing.Size(46, 21)
        Me.txtFrec.TabIndex = 2
        Me.txtFrec.Text = "0"
        Me.txtFrec.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'chkjueves
        '
        Me.chkjueves.AutoSize = True
        Me.chkjueves.Enabled = False
        Me.chkjueves.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkjueves.Location = New System.Drawing.Point(121, 190)
        Me.chkjueves.Name = "chkjueves"
        Me.chkjueves.Size = New System.Drawing.Size(60, 17)
        Me.chkjueves.TabIndex = 10
        Me.chkjueves.Text = "Jueves"
        Me.chkjueves.UseVisualStyleBackColor = True
        '
        'chkmiercoles
        '
        Me.chkmiercoles.AutoSize = True
        Me.chkmiercoles.Enabled = False
        Me.chkmiercoles.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkmiercoles.Location = New System.Drawing.Point(121, 172)
        Me.chkmiercoles.Name = "chkmiercoles"
        Me.chkmiercoles.Size = New System.Drawing.Size(71, 17)
        Me.chkmiercoles.TabIndex = 9
        Me.chkmiercoles.Text = "Miércoles"
        Me.chkmiercoles.UseVisualStyleBackColor = True
        '
        'chkmartes
        '
        Me.chkmartes.AutoSize = True
        Me.chkmartes.Enabled = False
        Me.chkmartes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkmartes.Location = New System.Drawing.Point(121, 154)
        Me.chkmartes.Name = "chkmartes"
        Me.chkmartes.Size = New System.Drawing.Size(58, 17)
        Me.chkmartes.TabIndex = 8
        Me.chkmartes.Text = "Martes"
        Me.chkmartes.UseVisualStyleBackColor = True
        '
        'chklunes
        '
        Me.chklunes.AutoSize = True
        Me.chklunes.Enabled = False
        Me.chklunes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chklunes.Location = New System.Drawing.Point(120, 136)
        Me.chklunes.Name = "chklunes"
        Me.chklunes.Size = New System.Drawing.Size(55, 17)
        Me.chklunes.TabIndex = 7
        Me.chklunes.Text = "Lunes"
        Me.chklunes.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(14, 79)
        Me.Label2.Name = "Label2"
        Me.Label2.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.Label2.Size = New System.Drawing.Size(139, 21)
        Me.Label2.TabIndex = 63
        Me.Label2.Text = "Informes Disponibles"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.White
        Me.GroupBox2.Controls.Add(Me.btn_quitarmail)
        Me.GroupBox2.Controls.Add(Me.dtgcorreos)
        Me.GroupBox2.Controls.Add(Me._em1)
        Me.GroupBox2.Controls.Add(Me.btn_agregarmail)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 399)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(695, 255)
        Me.GroupBox2.TabIndex = 61
        Me.GroupBox2.TabStop = False
        '
        'btn_quitarmail
        '
        Me.btn_quitarmail.Enabled = False
        Me.btn_quitarmail.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_quitarmail.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.elimina
        Me.btn_quitarmail.Location = New System.Drawing.Point(394, 21)
        Me.btn_quitarmail.Name = "btn_quitarmail"
        Me.btn_quitarmail.Size = New System.Drawing.Size(27, 24)
        Me.btn_quitarmail.TabIndex = 58
        Me.btn_quitarmail.UseVisualStyleBackColor = True
        '
        'dtgcorreos
        '
        Me.dtgcorreos.AllowUserToAddRows = False
        Me.dtgcorreos.AllowUserToDeleteRows = False
        Me.dtgcorreos.BackgroundColor = System.Drawing.Color.White
        Me.dtgcorreos.ColumnHeadersHeight = 28
        Me.dtgcorreos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn10, Me.DataGridViewImageColumn9})
        Me.dtgcorreos.Location = New System.Drawing.Point(26, 57)
        Me.dtgcorreos.Name = "dtgcorreos"
        Me.dtgcorreos.ReadOnly = True
        Me.dtgcorreos.RowHeadersWidth = 30
        Me.dtgcorreos.Size = New System.Drawing.Size(663, 178)
        Me.dtgcorreos.TabIndex = 57
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.HeaderText = "                     Direcciones de correo electrónico"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        Me.DataGridViewTextBoxColumn10.Width = 340
        '
        'DataGridViewImageColumn9
        '
        Me.DataGridViewImageColumn9.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.Eliminar_16
        Me.DataGridViewImageColumn9.Name = "DataGridViewImageColumn9"
        Me.DataGridViewImageColumn9.ReadOnly = True
        Me.DataGridViewImageColumn9.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewImageColumn9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewImageColumn9.Width = 30
        '
        '_em1
        '
        Me._em1.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me._em1.Enabled = False
        Me._em1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._em1.Location = New System.Drawing.Point(26, 21)
        Me._em1.MaxLength = 300
        Me._em1.Name = "_em1"
        Me._em1.Size = New System.Drawing.Size(324, 22)
        Me._em1.TabIndex = 55
        '
        'btn_agregarmail
        '
        Me.btn_agregarmail.Enabled = False
        Me.btn_agregarmail.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_agregarmail.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.addcorreo
        Me.btn_agregarmail.Location = New System.Drawing.Point(364, 21)
        Me.btn_agregarmail.Name = "btn_agregarmail"
        Me.btn_agregarmail.Size = New System.Drawing.Size(27, 24)
        Me.btn_agregarmail.TabIndex = 56
        Me.btn_agregarmail.UseVisualStyleBackColor = True
        '
        'Btn_Salir
        '
        Me.Btn_Salir.FlatAppearance.BorderSize = 0
        Me.Btn_Salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_Salir.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_salida
        Me.Btn_Salir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btn_Salir.Location = New System.Drawing.Point(644, 205)
        Me.Btn_Salir.Name = "Btn_Salir"
        Me.Btn_Salir.Size = New System.Drawing.Size(63, 63)
        Me.Btn_Salir.TabIndex = 55
        Me.Btn_Salir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btn_Salir.UseVisualStyleBackColor = True
        '
        'Btn_Nuevo
        '
        Me.Btn_Nuevo.FlatAppearance.BorderSize = 0
        Me.Btn_Nuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_Nuevo.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_hojanueva
        Me.Btn_Nuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btn_Nuevo.Location = New System.Drawing.Point(644, 81)
        Me.Btn_Nuevo.Name = "Btn_Nuevo"
        Me.Btn_Nuevo.Size = New System.Drawing.Size(63, 63)
        Me.Btn_Nuevo.TabIndex = 54
        Me.Btn_Nuevo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btn_Nuevo.UseVisualStyleBackColor = True
        '
        'Btn_Guardar
        '
        Me.Btn_Guardar.FlatAppearance.BorderSize = 0
        Me.Btn_Guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_Guardar.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_guardar2
        Me.Btn_Guardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btn_Guardar.Location = New System.Drawing.Point(644, 19)
        Me.Btn_Guardar.Name = "Btn_Guardar"
        Me.Btn_Guardar.Size = New System.Drawing.Size(63, 63)
        Me.Btn_Guardar.TabIndex = 53
        Me.Btn_Guardar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btn_Guardar.UseVisualStyleBackColor = True
        '
        'txtgiro
        '
        Me.txtgiro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtgiro.Enabled = False
        Me.txtgiro.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtgiro.Location = New System.Drawing.Point(167, 49)
        Me.txtgiro.MaxLength = 30
        Me.txtgiro.Name = "txtgiro"
        Me.txtgiro.Size = New System.Drawing.Size(303, 21)
        Me.txtgiro.TabIndex = 3
        '
        'txtrsocial
        '
        Me.txtrsocial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtrsocial.Enabled = False
        Me.txtrsocial.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtrsocial.Location = New System.Drawing.Point(167, 19)
        Me.txtrsocial.MaxLength = 40
        Me.txtrsocial.Name = "txtrsocial"
        Me.txtrsocial.Size = New System.Drawing.Size(303, 21)
        Me.txtrsocial.TabIndex = 1
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(14, 374)
        Me.Label9.Name = "Label9"
        Me.Label9.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.Label9.Size = New System.Drawing.Size(451, 22)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "Direcciones de mensajería Asignadas al Informe"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(14, 49)
        Me.Label7.Name = "Label7"
        Me.Label7.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.Label7.Size = New System.Drawing.Size(139, 21)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Giro"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(14, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.Label4.Size = New System.Drawing.Size(139, 21)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Razon Social"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(23, 21)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(76, 21)
        Me.Label8.TabIndex = 35
        Me.Label8.Text = "Codigo"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtrut
        '
        Me.txtrut.Enabled = False
        Me.txtrut.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtrut.Location = New System.Drawing.Point(105, 21)
        Me.txtrut.Mask = "########-A"
        Me.txtrut.Name = "txtrut"
        Me.txtrut.Size = New System.Drawing.Size(90, 21)
        Me.txtrut.TabIndex = 34
        '
        'chkinterno
        '
        Me.chkinterno.AutoSize = True
        Me.chkinterno.BackColor = System.Drawing.Color.Transparent
        Me.chkinterno.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkinterno.ForeColor = System.Drawing.Color.White
        Me.chkinterno.Location = New System.Drawing.Point(234, 23)
        Me.chkinterno.Name = "chkinterno"
        Me.chkinterno.Size = New System.Drawing.Size(66, 19)
        Me.chkinterno.TabIndex = 40
        Me.chkinterno.Text = "Interno"
        Me.chkinterno.UseVisualStyleBackColor = False
        '
        'DataGridViewImageColumn1
        '
        Me.DataGridViewImageColumn1.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.Eliminar_16
        Me.DataGridViewImageColumn1.Name = "DataGridViewImageColumn1"
        Me.DataGridViewImageColumn1.ReadOnly = True
        Me.DataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewImageColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewImageColumn1.Width = 30
        '
        'Btn_BuscaCliente
        '
        Me.Btn_BuscaCliente.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_BuscaCliente.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.buscar_24
        Me.Btn_BuscaCliente.Location = New System.Drawing.Point(201, 20)
        Me.Btn_BuscaCliente.Name = "Btn_BuscaCliente"
        Me.Btn_BuscaCliente.Size = New System.Drawing.Size(24, 24)
        Me.Btn_BuscaCliente.TabIndex = 39
        Me.Btn_BuscaCliente.UseVisualStyleBackColor = True
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "                     Direcciones de correo electrónico"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 340
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(54, 54)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 13)
        Me.Label6.TabIndex = 75
        Me.Label6.Text = "entre las"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Frm_AddEnvioEmail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(893, 751)
        Me.Controls.Add(Me.chkinterno)
        Me.Controls.Add(Me.Btn_BuscaCliente)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtrut)
        Me.Name = "Frm_AddEnvioEmail"
        Me.Text = "Programar Envio de E-mail"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.grptiempo.ResumeLayout(False)
        Me.grptiempo.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dtgcorreos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Btn_BuscaCliente As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Btn_Salir As System.Windows.Forms.Button
    Friend WithEvents Btn_Nuevo As System.Windows.Forms.Button
    Friend WithEvents Btn_Guardar As System.Windows.Forms.Button
    Friend WithEvents txtgiro As System.Windows.Forms.TextBox
    Friend WithEvents txtrsocial As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtrut As System.Windows.Forms.MaskedTextBox
    Friend WithEvents chkinterno As System.Windows.Forms.CheckBox
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_quitarmail As System.Windows.Forms.Button
    Friend WithEvents dtgcorreos As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewImageColumn9 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents _em1 As System.Windows.Forms.TextBox
    Friend WithEvents btn_agregarmail As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txthora As System.Windows.Forms.MaskedTextBox
    Friend WithEvents chktodos As System.Windows.Forms.CheckBox
    Friend WithEvents chkdomingo As System.Windows.Forms.CheckBox
    Friend WithEvents chksabado As System.Windows.Forms.CheckBox
    Friend WithEvents chkviernes As System.Windows.Forms.CheckBox
    Friend WithEvents chkjueves As System.Windows.Forms.CheckBox
    Friend WithEvents chkmiercoles As System.Windows.Forms.CheckBox
    Friend WithEvents chkmartes As System.Windows.Forms.CheckBox
    Friend WithEvents chklunes As System.Windows.Forms.CheckBox
    Friend WithEvents rdidesactivado As System.Windows.Forms.RadioButton
    Friend WithEvents rdiactivado As System.Windows.Forms.RadioButton
    Friend WithEvents cboinformes As System.Windows.Forms.ComboBox
    Friend WithEvents btn_informes As System.Windows.Forms.Button
    Friend WithEvents DataGridViewImageColumn1 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents btn_imagenes As System.Windows.Forms.Button
    Friend WithEvents btn_pdf As System.Windows.Forms.Button
    Friend WithEvents grptiempo As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtminutos As System.Windows.Forms.TextBox
    Friend WithEvents txtHoraH As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lblHoraH As System.Windows.Forms.Label
    Friend WithEvents lblHoraD As System.Windows.Forms.Label
    Friend WithEvents cboInterv As System.Windows.Forms.ComboBox
    Friend WithEvents txtFrec As System.Windows.Forms.TextBox
    Friend WithEvents rbtFrecManual As System.Windows.Forms.RadioButton
    Friend WithEvents rbtFrecRepetir As System.Windows.Forms.RadioButton
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class

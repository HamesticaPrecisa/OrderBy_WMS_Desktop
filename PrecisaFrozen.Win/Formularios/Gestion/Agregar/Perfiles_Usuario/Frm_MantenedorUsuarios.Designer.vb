<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_MantenedorUsuarios
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtrut = New System.Windows.Forms.TextBox()
        Me.txtrutv = New System.Windows.Forms.TextBox()
        Me.TxtNom1 = New System.Windows.Forms.TextBox()
        Me.TxtAp = New System.Windows.Forms.TextBox()
        Me.Cmbo_Secciones = New System.Windows.Forms.ComboBox()
        Me.Lst_categorias = New System.Windows.Forms.ListBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Lst_SubCategorias = New System.Windows.Forms.ListBox()
        Me.Lst_Funciones = New System.Windows.Forms.ListBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtcodigo = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnTag = New System.Windows.Forms.Button()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.cbodesbod = New System.Windows.Forms.ComboBox()
        Me.TxtTelEme = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TxtAnexo = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TxtEmail = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TxtAm = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Cb_Activo = New System.Windows.Forms.CheckBox()
        Me.Btn_BuscaUsuarios = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.BtnContraseña = New System.Windows.Forms.Button()
        Me.Cb_Radio = New System.Windows.Forms.CheckBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TxtPass2 = New System.Windows.Forms.TextBox()
        Me.TxtPass = New System.Windows.Forms.TextBox()
        Me.TxtUsu = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.btn_Imprimir = New System.Windows.Forms.Button()
        Me.Btn_AnulaGuia = New System.Windows.Forms.Button()
        Me.BtnImprimir = New System.Windows.Forms.Button()
        Me.btn_guardar = New System.Windows.Forms.Button()
        Me.btn_salir = New System.Windows.Forms.Button()
        Me.btn_nuevo = New System.Windows.Forms.Button()
        Me.CmboPerfiles = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.DGVusuario = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGVusuario, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(25, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "CODIGO"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "NOMBRE"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "APELLIDO P."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 138)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "SECCION"
        '
        'txtrut
        '
        Me.txtrut.Location = New System.Drawing.Point(112, 22)
        Me.txtrut.MaxLength = 8
        Me.txtrut.Name = "txtrut"
        Me.txtrut.Size = New System.Drawing.Size(70, 21)
        Me.txtrut.TabIndex = 1
        '
        'txtrutv
        '
        Me.txtrutv.Location = New System.Drawing.Point(188, 22)
        Me.txtrutv.MaxLength = 1
        Me.txtrutv.Name = "txtrutv"
        Me.txtrutv.Size = New System.Drawing.Size(23, 21)
        Me.txtrutv.TabIndex = 2
        '
        'TxtNom1
        '
        Me.TxtNom1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNom1.Location = New System.Drawing.Point(102, 10)
        Me.TxtNom1.Name = "TxtNom1"
        Me.TxtNom1.Size = New System.Drawing.Size(271, 21)
        Me.TxtNom1.TabIndex = 3
        '
        'TxtAp
        '
        Me.TxtAp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtAp.Location = New System.Drawing.Point(104, 49)
        Me.TxtAp.Name = "TxtAp"
        Me.TxtAp.Size = New System.Drawing.Size(150, 21)
        Me.TxtAp.TabIndex = 5
        '
        'Cmbo_Secciones
        '
        Me.Cmbo_Secciones.FormattingEnabled = True
        Me.Cmbo_Secciones.Location = New System.Drawing.Point(104, 135)
        Me.Cmbo_Secciones.Name = "Cmbo_Secciones"
        Me.Cmbo_Secciones.Size = New System.Drawing.Size(163, 21)
        Me.Cmbo_Secciones.TabIndex = 9
        '
        'Lst_categorias
        '
        Me.Lst_categorias.FormattingEnabled = True
        Me.Lst_categorias.Location = New System.Drawing.Point(17, 313)
        Me.Lst_categorias.Name = "Lst_categorias"
        Me.Lst_categorias.Size = New System.Drawing.Size(238, 277)
        Me.Lst_categorias.TabIndex = 26
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(14, 292)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(119, 18)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "CATEGORIAS"
        '
        'Lst_SubCategorias
        '
        Me.Lst_SubCategorias.FormattingEnabled = True
        Me.Lst_SubCategorias.Location = New System.Drawing.Point(261, 313)
        Me.Lst_SubCategorias.Name = "Lst_SubCategorias"
        Me.Lst_SubCategorias.Size = New System.Drawing.Size(287, 277)
        Me.Lst_SubCategorias.TabIndex = 28
        '
        'Lst_Funciones
        '
        Me.Lst_Funciones.FormattingEnabled = True
        Me.Lst_Funciones.Location = New System.Drawing.Point(605, 313)
        Me.Lst_Funciones.Name = "Lst_Funciones"
        Me.Lst_Funciones.Size = New System.Drawing.Size(305, 277)
        Me.Lst_Funciones.TabIndex = 29
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(602, 292)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(217, 18)
        Me.Label6.TabIndex = 30
        Me.Label6.Text = "FUNCIONES AGREGADAS"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.txtcodigo)
        Me.GroupBox1.Controls.Add(Me.Panel1)
        Me.GroupBox1.Controls.Add(Me.Cb_Activo)
        Me.GroupBox1.Controls.Add(Me.Btn_BuscaUsuarios)
        Me.GroupBox1.Controls.Add(Me.txtrutv)
        Me.GroupBox1.Controls.Add(Me.txtrut)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(553, 277)
        Me.GroupBox1.TabIndex = 36
        Me.GroupBox1.TabStop = False
        '
        'txtcodigo
        '
        Me.txtcodigo.Location = New System.Drawing.Point(261, 23)
        Me.txtcodigo.Name = "txtcodigo"
        Me.txtcodigo.ReadOnly = True
        Me.txtcodigo.Size = New System.Drawing.Size(69, 21)
        Me.txtcodigo.TabIndex = 63
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnTag)
        Me.Panel1.Controls.Add(Me.Label19)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.cbodesbod)
        Me.Panel1.Controls.Add(Me.TxtTelEme)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.TxtAnexo)
        Me.Panel1.Controls.Add(Me.TxtNom1)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.TxtAp)
        Me.Panel1.Controls.Add(Me.TxtEmail)
        Me.Panel1.Controls.Add(Me.Cmbo_Secciones)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.TxtAm)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Enabled = False
        Me.Panel1.Location = New System.Drawing.Point(10, 49)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(526, 209)
        Me.Panel1.TabIndex = 62
        '
        'btnTag
        '
        Me.btnTag.Enabled = False
        Me.btnTag.ForeColor = System.Drawing.Color.Black
        Me.btnTag.Location = New System.Drawing.Point(379, 169)
        Me.btnTag.Name = "btnTag"
        Me.btnTag.Size = New System.Drawing.Size(138, 23)
        Me.btnTag.TabIndex = 66
        Me.btnTag.Text = "Registrar TAG"
        Me.btnTag.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.ForeColor = System.Drawing.Color.White
        Me.Label19.Location = New System.Drawing.Point(15, 179)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(70, 13)
        Me.Label19.TabIndex = 65
        Me.Label19.Text = "SUCURSAL"
        '
        'cbodesbod
        '
        Me.cbodesbod.FormattingEnabled = True
        Me.cbodesbod.Location = New System.Drawing.Point(102, 171)
        Me.cbodesbod.Name = "cbodesbod"
        Me.cbodesbod.Size = New System.Drawing.Size(224, 21)
        Me.cbodesbod.TabIndex = 64
        '
        'TxtTelEme
        '
        Me.TxtTelEme.Location = New System.Drawing.Point(379, 135)
        Me.TxtTelEme.Name = "TxtTelEme"
        Me.TxtTelEme.Size = New System.Drawing.Size(138, 21)
        Me.TxtTelEme.TabIndex = 10
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(307, 138)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(66, 13)
        Me.Label11.TabIndex = 32
        Me.Label11.Text = "TELEFONO"
        '
        'TxtAnexo
        '
        Me.TxtAnexo.Location = New System.Drawing.Point(465, 92)
        Me.TxtAnexo.Name = "TxtAnexo"
        Me.TxtAnexo.Size = New System.Drawing.Size(52, 21)
        Me.TxtAnexo.TabIndex = 8
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(417, 95)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(47, 13)
        Me.Label10.TabIndex = 30
        Me.Label10.Text = "ANEXO"
        '
        'TxtEmail
        '
        Me.TxtEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtEmail.Location = New System.Drawing.Point(104, 92)
        Me.TxtEmail.Name = "TxtEmail"
        Me.TxtEmail.Size = New System.Drawing.Size(308, 21)
        Me.TxtEmail.TabIndex = 7
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(15, 95)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(47, 13)
        Me.Label9.TabIndex = 28
        Me.Label9.Text = "E-MAIL"
        '
        'TxtAm
        '
        Me.TxtAm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtAm.Location = New System.Drawing.Point(367, 49)
        Me.TxtAm.Name = "TxtAm"
        Me.TxtAm.Size = New System.Drawing.Size(150, 21)
        Me.TxtAm.TabIndex = 6
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(270, 52)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(81, 13)
        Me.Label8.TabIndex = 27
        Me.Label8.Text = "APELLIDO M."
        '
        'Cb_Activo
        '
        Me.Cb_Activo.AutoSize = True
        Me.Cb_Activo.Checked = True
        Me.Cb_Activo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Cb_Activo.Location = New System.Drawing.Point(455, 23)
        Me.Cb_Activo.Name = "Cb_Activo"
        Me.Cb_Activo.Size = New System.Drawing.Size(72, 17)
        Me.Cb_Activo.TabIndex = 0
        Me.Cb_Activo.Text = "ACTIVO"
        Me.Cb_Activo.UseVisualStyleBackColor = True
        '
        'Btn_BuscaUsuarios
        '
        Me.Btn_BuscaUsuarios.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.buscar_24
        Me.Btn_BuscaUsuarios.Location = New System.Drawing.Point(217, 21)
        Me.Btn_BuscaUsuarios.Name = "Btn_BuscaUsuarios"
        Me.Btn_BuscaUsuarios.Size = New System.Drawing.Size(26, 22)
        Me.Btn_BuscaUsuarios.TabIndex = 22
        Me.Btn_BuscaUsuarios.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.BtnContraseña)
        Me.GroupBox2.Controls.Add(Me.Cb_Radio)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.TxtPass2)
        Me.GroupBox2.Controls.Add(Me.TxtPass)
        Me.GroupBox2.Controls.Add(Me.TxtUsu)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.ForeColor = System.Drawing.Color.White
        Me.GroupBox2.Location = New System.Drawing.Point(605, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(221, 275)
        Me.GroupBox2.TabIndex = 37
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "AUTENTIFICACION"
        '
        'BtnContraseña
        '
        Me.BtnContraseña.Location = New System.Drawing.Point(195, 101)
        Me.BtnContraseña.Name = "BtnContraseña"
        Me.BtnContraseña.Size = New System.Drawing.Size(20, 23)
        Me.BtnContraseña.TabIndex = 62
        Me.BtnContraseña.Text = "?"
        Me.BtnContraseña.UseVisualStyleBackColor = True
        '
        'Cb_Radio
        '
        Me.Cb_Radio.AutoSize = True
        Me.Cb_Radio.Location = New System.Drawing.Point(13, 193)
        Me.Cb_Radio.Name = "Cb_Radio"
        Me.Cb_Radio.Size = New System.Drawing.Size(169, 17)
        Me.Cb_Radio.TabIndex = 14
        Me.Cb_Radio.Text = "ACCESO A RADIO FREC."
        Me.Cb_Radio.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Verdana", 6.25!)
        Me.Label17.Location = New System.Drawing.Point(115, 87)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(79, 12)
        Me.Label17.TabIndex = 37
        Me.Label17.Text = "(min. 4 caract)"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Verdana", 6.25!)
        Me.Label16.Location = New System.Drawing.Point(115, 35)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(79, 12)
        Me.Label16.TabIndex = 36
        Me.Label16.Text = "(min. 6 caract)"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(16, 87)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(87, 13)
        Me.Label15.TabIndex = 35
        Me.Label15.Text = "CONTRASEÑA"
        '
        'TxtPass2
        '
        Me.TxtPass2.Location = New System.Drawing.Point(13, 154)
        Me.TxtPass2.Name = "TxtPass2"
        Me.TxtPass2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtPass2.Size = New System.Drawing.Size(181, 21)
        Me.TxtPass2.TabIndex = 13
        '
        'TxtPass
        '
        Me.TxtPass.Location = New System.Drawing.Point(13, 103)
        Me.TxtPass.Name = "TxtPass"
        Me.TxtPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtPass.Size = New System.Drawing.Size(181, 21)
        Me.TxtPass.TabIndex = 12
        '
        'TxtUsu
        '
        Me.TxtUsu.Location = New System.Drawing.Point(13, 51)
        Me.TxtUsu.Name = "TxtUsu"
        Me.TxtUsu.Size = New System.Drawing.Size(181, 21)
        Me.TxtUsu.TabIndex = 11
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(10, 138)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(140, 13)
        Me.Label14.TabIndex = 2
        Me.Label14.Text = "CONFIR. CONTRASEÑA"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(12, 89)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(0, 13)
        Me.Label13.TabIndex = 1
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(10, 35)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(61, 13)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "USUARIO"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(262, 292)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(158, 18)
        Me.Label7.TabIndex = 37
        Me.Label7.Text = "SUB CATEGORIAS"
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.btn_Imprimir)
        Me.GroupBox4.Controls.Add(Me.Btn_AnulaGuia)
        Me.GroupBox4.Controls.Add(Me.BtnImprimir)
        Me.GroupBox4.Controls.Add(Me.btn_guardar)
        Me.GroupBox4.Controls.Add(Me.btn_salir)
        Me.GroupBox4.Controls.Add(Me.btn_nuevo)
        Me.GroupBox4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(966, 19)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(86, 406)
        Me.GroupBox4.TabIndex = 59
        Me.GroupBox4.TabStop = False
        '
        'btn_Imprimir
        '
        Me.btn_Imprimir.CausesValidation = False
        Me.btn_Imprimir.FlatAppearance.BorderSize = 0
        Me.btn_Imprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Imprimir.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_xls
        Me.btn_Imprimir.Location = New System.Drawing.Point(12, 328)
        Me.btn_Imprimir.Name = "btn_Imprimir"
        Me.btn_Imprimir.Size = New System.Drawing.Size(63, 63)
        Me.btn_Imprimir.TabIndex = 86
        Me.btn_Imprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Imprimir.UseVisualStyleBackColor = True
        '
        'Btn_AnulaGuia
        '
        Me.Btn_AnulaGuia.Enabled = False
        Me.Btn_AnulaGuia.FlatAppearance.BorderSize = 0
        Me.Btn_AnulaGuia.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_AnulaGuia.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_hojamenos
        Me.Btn_AnulaGuia.Location = New System.Drawing.Point(12, 205)
        Me.Btn_AnulaGuia.Name = "Btn_AnulaGuia"
        Me.Btn_AnulaGuia.Size = New System.Drawing.Size(63, 63)
        Me.Btn_AnulaGuia.TabIndex = 34
        Me.Btn_AnulaGuia.UseVisualStyleBackColor = True
        '
        'BtnImprimir
        '
        Me.BtnImprimir.Enabled = False
        Me.BtnImprimir.FlatAppearance.BorderSize = 0
        Me.BtnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnImprimir.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_impresora
        Me.BtnImprimir.Location = New System.Drawing.Point(12, 21)
        Me.BtnImprimir.Name = "BtnImprimir"
        Me.BtnImprimir.Size = New System.Drawing.Size(63, 63)
        Me.BtnImprimir.TabIndex = 32
        Me.BtnImprimir.UseVisualStyleBackColor = True
        '
        'btn_guardar
        '
        Me.btn_guardar.Enabled = False
        Me.btn_guardar.FlatAppearance.BorderSize = 0
        Me.btn_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_guardar.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_guardar2
        Me.btn_guardar.Location = New System.Drawing.Point(12, 82)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(63, 63)
        Me.btn_guardar.TabIndex = 29
        Me.btn_guardar.UseVisualStyleBackColor = True
        '
        'btn_salir
        '
        Me.btn_salir.FlatAppearance.BorderSize = 0
        Me.btn_salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_salir.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_salida
        Me.btn_salir.Location = New System.Drawing.Point(12, 266)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(63, 63)
        Me.btn_salir.TabIndex = 31
        Me.btn_salir.UseVisualStyleBackColor = True
        '
        'btn_nuevo
        '
        Me.btn_nuevo.FlatAppearance.BorderSize = 0
        Me.btn_nuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_nuevo.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_hojanueva
        Me.btn_nuevo.Location = New System.Drawing.Point(12, 143)
        Me.btn_nuevo.Name = "btn_nuevo"
        Me.btn_nuevo.Size = New System.Drawing.Size(63, 63)
        Me.btn_nuevo.TabIndex = 30
        Me.btn_nuevo.UseVisualStyleBackColor = True
        '
        'CmboPerfiles
        '
        Me.CmboPerfiles.FormattingEnabled = True
        Me.CmboPerfiles.Location = New System.Drawing.Point(166, 602)
        Me.CmboPerfiles.Name = "CmboPerfiles"
        Me.CmboPerfiles.Size = New System.Drawing.Size(325, 21)
        Me.CmboPerfiles.TabIndex = 60
        Me.CmboPerfiles.Visible = False
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.ForeColor = System.Drawing.Color.Transparent
        Me.Label18.Location = New System.Drawing.Point(14, 605)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(149, 13)
        Me.Label18.TabIndex = 61
        Me.Label18.Text = "COPIAR FUNCIONES DE "
        Me.Label18.Visible = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(826, 181)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(117, 31)
        Me.Button1.TabIndex = 63
        Me.Button1.Text = "Examinar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.usuario_anonimo
        Me.PictureBox1.Location = New System.Drawing.Point(826, 19)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(134, 155)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 64
        Me.PictureBox1.TabStop = False
        '
        'Button5
        '
        Me.Button5.Image = Global.PrecisaFrozen.Win.My.Resources.Resources._admin
        Me.Button5.Location = New System.Drawing.Point(552, 365)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(45, 45)
        Me.Button5.TabIndex = 35
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Image = Global.PrecisaFrozen.Win.My.Resources.Resources._Quitar_Todo
        Me.Button4.Location = New System.Drawing.Point(552, 314)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(45, 45)
        Me.Button4.TabIndex = 34
        Me.Button4.UseVisualStyleBackColor = True
        '
        'DGVusuario
        '
        Me.DGVusuario.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark
        Me.DGVusuario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVusuario.Enabled = False
        Me.DGVusuario.Location = New System.Drawing.Point(927, 475)
        Me.DGVusuario.Name = "DGVusuario"
        Me.DGVusuario.Size = New System.Drawing.Size(125, 100)
        Me.DGVusuario.TabIndex = 65
        Me.DGVusuario.Visible = False
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Codigo"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Nombre"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Apellido"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Depto"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "Funcion"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'Frm_MantenedorUsuarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(1064, 631)
        Me.Controls.Add(Me.DGVusuario)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.CmboPerfiles)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Lst_Funciones)
        Me.Controls.Add(Me.Lst_SubCategorias)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Lst_categorias)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "Frm_MantenedorUsuarios"
        Me.Text = "Mantenedor Usuarios"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGVusuario, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtrut As System.Windows.Forms.TextBox
    Friend WithEvents txtrutv As System.Windows.Forms.TextBox
    Friend WithEvents Btn_BuscaUsuarios As System.Windows.Forms.Button
    Friend WithEvents TxtNom1 As System.Windows.Forms.TextBox
    Friend WithEvents TxtAp As System.Windows.Forms.TextBox
    Friend WithEvents Cmbo_Secciones As System.Windows.Forms.ComboBox
    Friend WithEvents Lst_categorias As System.Windows.Forms.ListBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Lst_SubCategorias As System.Windows.Forms.ListBox
    Friend WithEvents Lst_Funciones As System.Windows.Forms.ListBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtPass2 As System.Windows.Forms.TextBox
    Friend WithEvents TxtPass As System.Windows.Forms.TextBox
    Friend WithEvents TxtUsu As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TxtTelEme As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TxtAnexo As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TxtEmail As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtAm As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Btn_AnulaGuia As System.Windows.Forms.Button
    Friend WithEvents BtnImprimir As System.Windows.Forms.Button
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents btn_salir As System.Windows.Forms.Button
    Friend WithEvents btn_nuevo As System.Windows.Forms.Button
    Friend WithEvents Cb_Radio As System.Windows.Forms.CheckBox
    Friend WithEvents Cb_Activo As System.Windows.Forms.CheckBox
    Friend WithEvents CmboPerfiles As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnContraseña As System.Windows.Forms.Button
    Friend WithEvents txtcodigo As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents cbodesbod As System.Windows.Forms.ComboBox
    Friend WithEvents btnTag As System.Windows.Forms.Button
    Friend WithEvents btn_Imprimir As System.Windows.Forms.Button
    Friend WithEvents DGVusuario As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

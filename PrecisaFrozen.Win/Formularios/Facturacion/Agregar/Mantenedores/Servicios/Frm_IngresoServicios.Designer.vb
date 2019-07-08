<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_IngresoServicios
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_IngresoServicios))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtnombre = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtdesc = New System.Windows.Forms.RichTextBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.NewToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.OpenToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.SaveToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.FontToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.FontColorToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.BoldToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.UnderlineToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.LeftToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.CenterToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.RightToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.BulletsToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.SpellcheckToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.CutToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.CopyToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.PasteToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.cbetiq = New System.Windows.Forms.CheckBox()
        Me.cbdesp = New System.Windows.Forms.CheckBox()
        Me.cbrece = New System.Windows.Forms.CheckBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbo_seccion = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbo_moneda = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbo_medida = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Btn_Salir = New System.Windows.Forms.Button()
        Me.Btn_Nuevo = New System.Windows.Forms.Button()
        Me.Btn_Guardar = New System.Windows.Forms.Button()
        Me.Txtcodigo = New System.Windows.Forms.TextBox()
        Me.Btn_BuscaServicio = New System.Windows.Forms.Button()
        Me.cbesc = New System.Windows.Forms.CheckBox()
        Me.Btn_Eliminar = New System.Windows.Forms.Button()
        Me.FontDlg = New System.Windows.Forms.FontDialog()
        Me.ColorDlg = New System.Windows.Forms.ColorDialog()
        Me.OpenFileDlg = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDlg = New System.Windows.Forms.SaveFileDialog()
        Me.SpellChecker = New NetSpell.SpellChecker.Spelling(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(25, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.Label1.Size = New System.Drawing.Size(98, 21)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Código"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtnombre
        '
        Me.txtnombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtnombre.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnombre.Location = New System.Drawing.Point(117, 21)
        Me.txtnombre.MaxLength = 50
        Me.txtnombre.Name = "txtnombre"
        Me.txtnombre.Size = New System.Drawing.Size(406, 21)
        Me.txtnombre.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(13, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.Label2.Size = New System.Drawing.Size(98, 21)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Nombre"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Panel1)
        Me.GroupBox1.Controls.Add(Me.cbetiq)
        Me.GroupBox1.Controls.Add(Me.cbdesp)
        Me.GroupBox1.Controls.Add(Me.cbrece)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.cmbo_seccion)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cmbo_moneda)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cmbo_medida)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtnombre)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Enabled = False
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 51)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(650, 458)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.txtdesc)
        Me.Panel1.Controls.Add(Me.ToolStrip1)
        Me.Panel1.Location = New System.Drawing.Point(13, 143)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(631, 242)
        Me.Panel1.TabIndex = 34
        '
        'txtdesc
        '
        Me.txtdesc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtdesc.Location = New System.Drawing.Point(0, 25)
        Me.txtdesc.Name = "txtdesc"
        Me.txtdesc.Size = New System.Drawing.Size(631, 217)
        Me.txtdesc.TabIndex = 3
        Me.txtdesc.Text = ""
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripButton, Me.OpenToolStripButton, Me.SaveToolStripButton, Me.PrintToolStripButton, Me.toolStripSeparator, Me.FontToolStripButton, Me.FontColorToolStripButton, Me.BoldToolStripButton, Me.UnderlineToolStripButton, Me.ToolStripSeparator4, Me.LeftToolStripButton, Me.CenterToolStripButton, Me.RightToolStripButton, Me.ToolStripSeparator3, Me.BulletsToolStripButton, Me.SpellcheckToolStripButton, Me.ToolStripSeparator2, Me.CutToolStripButton, Me.CopyToolStripButton, Me.PasteToolStripButton})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(631, 25)
        Me.ToolStrip1.TabIndex = 2
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'NewToolStripButton
        '
        Me.NewToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.NewToolStripButton.Image = CType(resources.GetObject("NewToolStripButton.Image"), System.Drawing.Image)
        Me.NewToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.NewToolStripButton.Name = "NewToolStripButton"
        Me.NewToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.NewToolStripButton.Text = "&New"
        Me.NewToolStripButton.Visible = False
        '
        'OpenToolStripButton
        '
        Me.OpenToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.OpenToolStripButton.Image = CType(resources.GetObject("OpenToolStripButton.Image"), System.Drawing.Image)
        Me.OpenToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.OpenToolStripButton.Name = "OpenToolStripButton"
        Me.OpenToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.OpenToolStripButton.Text = "&Open"
        Me.OpenToolStripButton.Visible = False
        '
        'SaveToolStripButton
        '
        Me.SaveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SaveToolStripButton.Image = CType(resources.GetObject("SaveToolStripButton.Image"), System.Drawing.Image)
        Me.SaveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveToolStripButton.Name = "SaveToolStripButton"
        Me.SaveToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.SaveToolStripButton.Text = "&Save"
        Me.SaveToolStripButton.Visible = False
        '
        'PrintToolStripButton
        '
        Me.PrintToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PrintToolStripButton.Image = CType(resources.GetObject("PrintToolStripButton.Image"), System.Drawing.Image)
        Me.PrintToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PrintToolStripButton.Name = "PrintToolStripButton"
        Me.PrintToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.PrintToolStripButton.Text = "&Print"
        Me.PrintToolStripButton.Visible = False
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        Me.toolStripSeparator.Visible = False
        '
        'FontToolStripButton
        '
        Me.FontToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.FontToolStripButton.Image = CType(resources.GetObject("FontToolStripButton.Image"), System.Drawing.Image)
        Me.FontToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.FontToolStripButton.Name = "FontToolStripButton"
        Me.FontToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.FontToolStripButton.Text = "Font"
        '
        'FontColorToolStripButton
        '
        Me.FontColorToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.FontColorToolStripButton.Image = CType(resources.GetObject("FontColorToolStripButton.Image"), System.Drawing.Image)
        Me.FontColorToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.FontColorToolStripButton.Name = "FontColorToolStripButton"
        Me.FontColorToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.FontColorToolStripButton.Text = "Font Color"
        '
        'BoldToolStripButton
        '
        Me.BoldToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BoldToolStripButton.Image = CType(resources.GetObject("BoldToolStripButton.Image"), System.Drawing.Image)
        Me.BoldToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BoldToolStripButton.Name = "BoldToolStripButton"
        Me.BoldToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.BoldToolStripButton.Text = "Bold"
        '
        'UnderlineToolStripButton
        '
        Me.UnderlineToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.UnderlineToolStripButton.Image = CType(resources.GetObject("UnderlineToolStripButton.Image"), System.Drawing.Image)
        Me.UnderlineToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.UnderlineToolStripButton.Name = "UnderlineToolStripButton"
        Me.UnderlineToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.UnderlineToolStripButton.Text = "Underline"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'LeftToolStripButton
        '
        Me.LeftToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.LeftToolStripButton.Image = CType(resources.GetObject("LeftToolStripButton.Image"), System.Drawing.Image)
        Me.LeftToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.LeftToolStripButton.Name = "LeftToolStripButton"
        Me.LeftToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.LeftToolStripButton.Text = "Left"
        '
        'CenterToolStripButton
        '
        Me.CenterToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.CenterToolStripButton.Image = CType(resources.GetObject("CenterToolStripButton.Image"), System.Drawing.Image)
        Me.CenterToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CenterToolStripButton.Name = "CenterToolStripButton"
        Me.CenterToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.CenterToolStripButton.Text = "Center"
        '
        'RightToolStripButton
        '
        Me.RightToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.RightToolStripButton.Image = CType(resources.GetObject("RightToolStripButton.Image"), System.Drawing.Image)
        Me.RightToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.RightToolStripButton.Name = "RightToolStripButton"
        Me.RightToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.RightToolStripButton.Text = "Right"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'BulletsToolStripButton
        '
        Me.BulletsToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BulletsToolStripButton.Image = CType(resources.GetObject("BulletsToolStripButton.Image"), System.Drawing.Image)
        Me.BulletsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BulletsToolStripButton.Name = "BulletsToolStripButton"
        Me.BulletsToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.BulletsToolStripButton.Text = "Bullets"
        Me.BulletsToolStripButton.Visible = False
        '
        'SpellcheckToolStripButton
        '
        Me.SpellcheckToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SpellcheckToolStripButton.Image = CType(resources.GetObject("SpellcheckToolStripButton.Image"), System.Drawing.Image)
        Me.SpellcheckToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SpellcheckToolStripButton.Name = "SpellcheckToolStripButton"
        Me.SpellcheckToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.SpellcheckToolStripButton.Text = "Spell Check"
        Me.SpellcheckToolStripButton.Visible = False
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        Me.ToolStripSeparator2.Visible = False
        '
        'CutToolStripButton
        '
        Me.CutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.CutToolStripButton.Image = CType(resources.GetObject("CutToolStripButton.Image"), System.Drawing.Image)
        Me.CutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CutToolStripButton.Name = "CutToolStripButton"
        Me.CutToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.CutToolStripButton.Text = "C&ut"
        Me.CutToolStripButton.Visible = False
        '
        'CopyToolStripButton
        '
        Me.CopyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.CopyToolStripButton.Image = CType(resources.GetObject("CopyToolStripButton.Image"), System.Drawing.Image)
        Me.CopyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CopyToolStripButton.Name = "CopyToolStripButton"
        Me.CopyToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.CopyToolStripButton.Text = "&Copy"
        Me.CopyToolStripButton.Visible = False
        '
        'PasteToolStripButton
        '
        Me.PasteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PasteToolStripButton.Image = CType(resources.GetObject("PasteToolStripButton.Image"), System.Drawing.Image)
        Me.PasteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PasteToolStripButton.Name = "PasteToolStripButton"
        Me.PasteToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.PasteToolStripButton.Text = "&Paste"
        Me.PasteToolStripButton.Visible = False
        '
        'cbetiq
        '
        Me.cbetiq.AutoSize = True
        Me.cbetiq.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbetiq.Location = New System.Drawing.Point(309, 424)
        Me.cbetiq.Name = "cbetiq"
        Me.cbetiq.Size = New System.Drawing.Size(86, 19)
        Me.cbetiq.TabIndex = 27
        Me.cbetiq.Text = "Etiquetado"
        Me.cbetiq.UseVisualStyleBackColor = True
        '
        'cbdesp
        '
        Me.cbdesp.AutoSize = True
        Me.cbdesp.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbdesp.Location = New System.Drawing.Point(214, 424)
        Me.cbdesp.Name = "cbdesp"
        Me.cbdesp.Size = New System.Drawing.Size(83, 19)
        Me.cbdesp.TabIndex = 26
        Me.cbdesp.Text = "Despacho"
        Me.cbdesp.UseVisualStyleBackColor = True
        '
        'cbrece
        '
        Me.cbrece.AutoSize = True
        Me.cbrece.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbrece.Location = New System.Drawing.Point(117, 424)
        Me.cbrece.Name = "cbrece"
        Me.cbrece.Size = New System.Drawing.Size(86, 19)
        Me.cbrece.TabIndex = 25
        Me.cbrece.Text = "Recepción"
        Me.cbrece.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(13, 391)
        Me.Label7.Name = "Label7"
        Me.Label7.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.Label7.Size = New System.Drawing.Size(98, 23)
        Me.Label7.TabIndex = 24
        Me.Label7.Text = "Emisión"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbo_seccion
        '
        Me.cmbo_seccion.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbo_seccion.FormattingEnabled = True
        Me.cmbo_seccion.Location = New System.Drawing.Point(117, 391)
        Me.cmbo_seccion.Name = "cmbo_seccion"
        Me.cmbo_seccion.Size = New System.Drawing.Size(205, 23)
        Me.cmbo_seccion.TabIndex = 23
        '
        'Label4
        '
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(13, 81)
        Me.Label4.Name = "Label4"
        Me.Label4.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.Label4.Size = New System.Drawing.Size(98, 23)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "Moneda"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbo_moneda
        '
        Me.cmbo_moneda.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbo_moneda.FormattingEnabled = True
        Me.cmbo_moneda.Location = New System.Drawing.Point(117, 81)
        Me.cmbo_moneda.Name = "cmbo_moneda"
        Me.cmbo_moneda.Size = New System.Drawing.Size(180, 23)
        Me.cmbo_moneda.TabIndex = 20
        '
        'Label3
        '
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(13, 421)
        Me.Label3.Name = "Label3"
        Me.Label3.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.Label3.Size = New System.Drawing.Size(98, 23)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Movimientos"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbo_medida
        '
        Me.cmbo_medida.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbo_medida.FormattingEnabled = True
        Me.cmbo_medida.Location = New System.Drawing.Point(117, 51)
        Me.cmbo_medida.Name = "cmbo_medida"
        Me.cmbo_medida.Size = New System.Drawing.Size(180, 23)
        Me.cmbo_medida.TabIndex = 14
        '
        'Label6
        '
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(13, 51)
        Me.Label6.Name = "Label6"
        Me.Label6.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.Label6.Size = New System.Drawing.Size(98, 23)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Medida"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(13, 114)
        Me.Label5.Name = "Label5"
        Me.Label5.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.Label5.Size = New System.Drawing.Size(98, 23)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Descripción"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Btn_Salir
        '
        Me.Btn_Salir.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.salir
        Me.Btn_Salir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btn_Salir.Location = New System.Drawing.Point(687, 318)
        Me.Btn_Salir.Name = "Btn_Salir"
        Me.Btn_Salir.Size = New System.Drawing.Size(125, 50)
        Me.Btn_Salir.TabIndex = 3
        Me.Btn_Salir.Text = "           Esc - Salir"
        Me.Btn_Salir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btn_Salir.UseVisualStyleBackColor = True
        '
        'Btn_Nuevo
        '
        Me.Btn_Nuevo.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.Nuevo
        Me.Btn_Nuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btn_Nuevo.Location = New System.Drawing.Point(687, 194)
        Me.Btn_Nuevo.Name = "Btn_Nuevo"
        Me.Btn_Nuevo.Size = New System.Drawing.Size(125, 50)
        Me.Btn_Nuevo.TabIndex = 1
        Me.Btn_Nuevo.Text = "           F6 - Nuevo"
        Me.Btn_Nuevo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btn_Nuevo.UseVisualStyleBackColor = True
        '
        'Btn_Guardar
        '
        Me.Btn_Guardar.Enabled = False
        Me.Btn_Guardar.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.Guardar
        Me.Btn_Guardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btn_Guardar.Location = New System.Drawing.Point(687, 132)
        Me.Btn_Guardar.Name = "Btn_Guardar"
        Me.Btn_Guardar.Size = New System.Drawing.Size(125, 50)
        Me.Btn_Guardar.TabIndex = 0
        Me.Btn_Guardar.Text = "           F5 - Guardar"
        Me.Btn_Guardar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btn_Guardar.UseVisualStyleBackColor = True
        '
        'Txtcodigo
        '
        Me.Txtcodigo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtcodigo.Location = New System.Drawing.Point(129, 26)
        Me.Txtcodigo.Name = "Txtcodigo"
        Me.Txtcodigo.Size = New System.Drawing.Size(53, 21)
        Me.Txtcodigo.TabIndex = 7
        '
        'Btn_BuscaServicio
        '
        Me.Btn_BuscaServicio.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.buscar_24
        Me.Btn_BuscaServicio.Location = New System.Drawing.Point(187, 24)
        Me.Btn_BuscaServicio.Name = "Btn_BuscaServicio"
        Me.Btn_BuscaServicio.Size = New System.Drawing.Size(24, 24)
        Me.Btn_BuscaServicio.TabIndex = 20
        Me.Btn_BuscaServicio.UseVisualStyleBackColor = True
        '
        'cbesc
        '
        Me.cbesc.AutoSize = True
        Me.cbesc.Enabled = False
        Me.cbesc.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbesc.Location = New System.Drawing.Point(346, 28)
        Me.cbesc.Name = "cbesc"
        Me.cbesc.Size = New System.Drawing.Size(137, 19)
        Me.cbesc.TabIndex = 21
        Me.cbesc.Text = "Servicio con escala"
        Me.cbesc.UseVisualStyleBackColor = True
        '
        'Btn_Eliminar
        '
        Me.Btn_Eliminar.Enabled = False
        Me.Btn_Eliminar.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.eliminar
        Me.Btn_Eliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btn_Eliminar.Location = New System.Drawing.Point(687, 256)
        Me.Btn_Eliminar.Name = "Btn_Eliminar"
        Me.Btn_Eliminar.Size = New System.Drawing.Size(125, 50)
        Me.Btn_Eliminar.TabIndex = 22
        Me.Btn_Eliminar.Text = "           F7 - Eliminar"
        Me.Btn_Eliminar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btn_Eliminar.UseVisualStyleBackColor = True
        '
        'FontDlg
        '
        Me.FontDlg.Color = System.Drawing.SystemColors.ControlText
        '
        'OpenFileDlg
        '
        Me.OpenFileDlg.FileName = "OpenFileDialog1"
        '
        'SpellChecker
        '
        Me.SpellChecker.Dictionary = Nothing
        Me.SpellChecker.IgnoreWordsWithDigits = True
        '
        'Frm_IngresoServicios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(833, 521)
        Me.Controls.Add(Me.Btn_Eliminar)
        Me.Controls.Add(Me.Btn_Salir)
        Me.Controls.Add(Me.cbesc)
        Me.Controls.Add(Me.Btn_Nuevo)
        Me.Controls.Add(Me.Btn_BuscaServicio)
        Me.Controls.Add(Me.Btn_Guardar)
        Me.Controls.Add(Me.Txtcodigo)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_IngresoServicios"
        Me.ShowIcon = False
        Me.Text = "Mantenedor de servicios"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtnombre As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Btn_Salir As System.Windows.Forms.Button
    Friend WithEvents Btn_Nuevo As System.Windows.Forms.Button
    Friend WithEvents Btn_Guardar As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbo_medida As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Txtcodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbo_moneda As System.Windows.Forms.ComboBox
    Friend WithEvents Btn_BuscaServicio As System.Windows.Forms.Button
    Friend WithEvents cbesc As System.Windows.Forms.CheckBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmbo_seccion As System.Windows.Forms.ComboBox
    Friend WithEvents cbetiq As System.Windows.Forms.CheckBox
    Friend WithEvents cbdesp As System.Windows.Forms.CheckBox
    Friend WithEvents cbrece As System.Windows.Forms.CheckBox
    Friend WithEvents Btn_Eliminar As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents NewToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents OpenToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents SaveToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents PrintToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents FontToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents FontColorToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents BoldToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents UnderlineToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents LeftToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents CenterToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents RightToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BulletsToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents SpellcheckToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CutToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents CopyToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents PasteToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtdesc As System.Windows.Forms.RichTextBox
    Friend WithEvents FontDlg As System.Windows.Forms.FontDialog
    Friend WithEvents ColorDlg As System.Windows.Forms.ColorDialog
    Friend WithEvents OpenFileDlg As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveFileDlg As System.Windows.Forms.SaveFileDialog
    Friend WithEvents SpellChecker As NetSpell.SpellChecker.Spelling
End Class

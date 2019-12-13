<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Cotizaciones
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
        Me.checklectura = New System.Windows.Forms.CheckBox()
        Me.CbNumerales = New System.Windows.Forms.ComboBox()
        Me.CbCarga = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CBBloquearfact = New System.Windows.Forms.CheckBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.CbImportaciones = New System.Windows.Forms.CheckBox()
        Me.TxtHor7 = New System.Windows.Forms.MaskedTextBox()
        Me.TxtHor8 = New System.Windows.Forms.MaskedTextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txttunel = New System.Windows.Forms.TextBox()
        Me.TxtHor5 = New System.Windows.Forms.MaskedTextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TxtHor6 = New System.Windows.Forms.MaskedTextBox()
        Me.txtcamaracerrada = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtpalletmin = New System.Windows.Forms.TextBox()
        Me.TxtHor3 = New System.Windows.Forms.MaskedTextBox()
        Me.TxtHor4 = New System.Windows.Forms.MaskedTextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtderecho = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txttempgracia = New System.Windows.Forms.TextBox()
        Me.TxtHor1 = New System.Windows.Forms.MaskedTextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TxtHor2 = New System.Windows.Forms.MaskedTextBox()
        Me.txttemp = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtfexpiracion = New System.Windows.Forms.DateTimePicker()
        Me.txtfcontrato = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtdescripcion = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtdescsopo = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.CbSeguros = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Btn_BuscaCliente = New System.Windows.Forms.Button()
        Me.TxtCliente = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Btn_BuscaContrato = New System.Windows.Forms.Button()
        Me.Txtrut = New System.Windows.Forms.MaskedTextBox()
        Me.txtcoti = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CheckEstado = New System.Windows.Forms.CheckBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.BtnImprimir = New System.Windows.Forms.Button()
        Me.btn_eliminar = New System.Windows.Forms.Button()
        Me.btn_guardar = New System.Windows.Forms.Button()
        Me.btn_salir = New System.Windows.Forms.Button()
        Me.btn_nuevo = New System.Windows.Forms.Button()
        Me.GroupBox2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'checklectura
        '
        Me.checklectura.AutoSize = True
        Me.checklectura.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checklectura.Location = New System.Drawing.Point(7, 287)
        Me.checklectura.Name = "checklectura"
        Me.checklectura.Size = New System.Drawing.Size(253, 20)
        Me.checklectura.TabIndex = 59
        Me.checklectura.Text = "Lectura de envases de entrada y salida"
        Me.checklectura.UseVisualStyleBackColor = True
        '
        'CbNumerales
        '
        Me.CbNumerales.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbNumerales.FormattingEnabled = True
        Me.CbNumerales.Location = New System.Drawing.Point(164, 141)
        Me.CbNumerales.Name = "CbNumerales"
        Me.CbNumerales.Size = New System.Drawing.Size(226, 24)
        Me.CbNumerales.TabIndex = 58
        '
        'CbCarga
        '
        Me.CbCarga.AutoSize = True
        Me.CbCarga.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbCarga.Location = New System.Drawing.Point(7, 235)
        Me.CbCarga.Name = "CbCarga"
        Me.CbCarga.Size = New System.Drawing.Size(330, 20)
        Me.CbCarga.TabIndex = 56
        Me.CbCarga.Text = "Cobrar In/Out al cargar o descargar de forma manual"
        Me.CbCarga.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(7, 141)
        Me.Label3.Name = "Label3"
        Me.Label3.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.Label3.Size = New System.Drawing.Size(152, 24)
        Me.Label3.TabIndex = 55
        Me.Label3.Text = "Tipo Numeral"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CBBloquearfact
        '
        Me.CBBloquearfact.AutoSize = True
        Me.CBBloquearfact.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBBloquearfact.Location = New System.Drawing.Point(7, 260)
        Me.CBBloquearfact.Name = "CBBloquearfact"
        Me.CBBloquearfact.Size = New System.Drawing.Size(145, 20)
        Me.CBBloquearfact.TabIndex = 36
        Me.CBBloquearfact.Text = "Bloquear facturación"
        Me.CBBloquearfact.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(0, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(491, 21)
        Me.Label9.TabIndex = 54
        Me.Label9.Text = "HORARIO ATENCION"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label21
        '
        Me.Label21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label21.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(310, 26)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(117, 20)
        Me.Label21.TabIndex = 53
        Me.Label21.Text = "DESPACHOS"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CbImportaciones
        '
        Me.CbImportaciones.AutoSize = True
        Me.CbImportaciones.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbImportaciones.Location = New System.Drawing.Point(7, 210)
        Me.CbImportaciones.Name = "CbImportaciones"
        Me.CbImportaciones.Size = New System.Drawing.Size(234, 20)
        Me.CbImportaciones.TabIndex = 36
        Me.CbImportaciones.Text = "Bloquear soportantes sin resolución"
        Me.CbImportaciones.UseVisualStyleBackColor = True
        '
        'TxtHor7
        '
        Me.TxtHor7.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtHor7.Location = New System.Drawing.Point(310, 85)
        Me.TxtHor7.Mask = "00:00"
        Me.TxtHor7.Name = "TxtHor7"
        Me.TxtHor7.Size = New System.Drawing.Size(48, 23)
        Me.TxtHor7.TabIndex = 50
        Me.TxtHor7.Text = "0900"
        Me.TxtHor7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TxtHor7.ValidatingType = GetType(Date)
        '
        'TxtHor8
        '
        Me.TxtHor8.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtHor8.Location = New System.Drawing.Point(379, 85)
        Me.TxtHor8.Mask = "00:00"
        Me.TxtHor8.Name = "TxtHor8"
        Me.TxtHor8.Size = New System.Drawing.Size(48, 23)
        Me.TxtHor8.TabIndex = 51
        Me.TxtHor8.Text = "1300"
        Me.TxtHor8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TxtHor8.ValidatingType = GetType(Date)
        '
        'Label13
        '
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label13.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(7, 88)
        Me.Label13.Name = "Label13"
        Me.Label13.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.Label13.Size = New System.Drawing.Size(152, 20)
        Me.Label13.TabIndex = 26
        Me.Label13.Text = "Tunel de Gracia"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txttunel
        '
        Me.txttunel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttunel.Location = New System.Drawing.Point(164, 88)
        Me.txttunel.MaxLength = 2
        Me.txttunel.Name = "txttunel"
        Me.txttunel.Size = New System.Drawing.Size(41, 22)
        Me.txttunel.TabIndex = 12
        Me.txttunel.Text = "0"
        Me.txttunel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtHor5
        '
        Me.TxtHor5.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtHor5.Location = New System.Drawing.Point(170, 85)
        Me.TxtHor5.Mask = "00:00"
        Me.TxtHor5.Name = "TxtHor5"
        Me.TxtHor5.Size = New System.Drawing.Size(48, 23)
        Me.TxtHor5.TabIndex = 45
        Me.TxtHor5.Text = "0830"
        Me.TxtHor5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TxtHor5.ValidatingType = GetType(Date)
        '
        'Label11
        '
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(216, 86)
        Me.Label11.Name = "Label11"
        Me.Label11.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.Label11.Size = New System.Drawing.Size(167, 22)
        Me.Label11.TabIndex = 24
        Me.Label11.Text = "Cámara Cerrada"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtHor6
        '
        Me.TxtHor6.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtHor6.Location = New System.Drawing.Point(239, 85)
        Me.TxtHor6.Mask = "00:00"
        Me.TxtHor6.Name = "TxtHor6"
        Me.TxtHor6.Size = New System.Drawing.Size(48, 23)
        Me.TxtHor6.TabIndex = 46
        Me.TxtHor6.Text = "1630"
        Me.TxtHor6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TxtHor6.ValidatingType = GetType(Date)
        '
        'txtcamaracerrada
        '
        Me.txtcamaracerrada.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcamaracerrada.Location = New System.Drawing.Point(388, 86)
        Me.txtcamaracerrada.MaxLength = 4
        Me.txtcamaracerrada.Name = "txtcamaracerrada"
        Me.txtcamaracerrada.Size = New System.Drawing.Size(41, 22)
        Me.txtcamaracerrada.TabIndex = 11
        Me.txtcamaracerrada.Text = "0"
        Me.txtcamaracerrada.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(7, 61)
        Me.Label12.Name = "Label12"
        Me.Label12.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.Label12.Size = New System.Drawing.Size(152, 20)
        Me.Label12.TabIndex = 22
        Me.Label12.Text = "Pallet Mínimo"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label20
        '
        Me.Label20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label20.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(170, 26)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(117, 20)
        Me.Label20.TabIndex = 44
        Me.Label20.Text = "RECEPCIONES"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtpalletmin
        '
        Me.txtpalletmin.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpalletmin.Location = New System.Drawing.Point(164, 61)
        Me.txtpalletmin.MaxLength = 2
        Me.txtpalletmin.Name = "txtpalletmin"
        Me.txtpalletmin.Size = New System.Drawing.Size(41, 22)
        Me.txtpalletmin.TabIndex = 10
        Me.txtpalletmin.Text = "0"
        Me.txtpalletmin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtHor3
        '
        Me.TxtHor3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtHor3.Location = New System.Drawing.Point(310, 54)
        Me.TxtHor3.Mask = "00:00"
        Me.TxtHor3.Name = "TxtHor3"
        Me.TxtHor3.Size = New System.Drawing.Size(48, 23)
        Me.TxtHor3.TabIndex = 41
        Me.TxtHor3.Text = "0900"
        Me.TxtHor3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TxtHor3.ValidatingType = GetType(Date)
        '
        'TxtHor4
        '
        Me.TxtHor4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtHor4.Location = New System.Drawing.Point(379, 54)
        Me.TxtHor4.Mask = "00:00"
        Me.TxtHor4.Name = "TxtHor4"
        Me.TxtHor4.Size = New System.Drawing.Size(48, 23)
        Me.TxtHor4.TabIndex = 42
        Me.TxtHor4.Text = "1700"
        Me.TxtHor4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TxtHor4.ValidatingType = GetType(Date)
        '
        'Label10
        '
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(7, 34)
        Me.Label10.Name = "Label10"
        Me.Label10.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.Label10.Size = New System.Drawing.Size(152, 22)
        Me.Label10.TabIndex = 18
        Me.Label10.Text = "Derecho de Entrada"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Gainsboro
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label17.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(20, 52)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(123, 23)
        Me.Label17.TabIndex = 40
        Me.Label17.Text = "LUNES A VIERNES"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtderecho
        '
        Me.txtderecho.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtderecho.Location = New System.Drawing.Point(164, 34)
        Me.txtderecho.MaxLength = 2
        Me.txtderecho.Name = "txtderecho"
        Me.txtderecho.Size = New System.Drawing.Size(41, 22)
        Me.txtderecho.TabIndex = 9
        Me.txtderecho.Text = "15"
        Me.txtderecho.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Gainsboro
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label16.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(20, 85)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(123, 22)
        Me.Label16.TabIndex = 39
        Me.Label16.Text = "SABADOS"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(216, 61)
        Me.Label8.Name = "Label8"
        Me.Label8.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.Label8.Size = New System.Drawing.Size(167, 22)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Temperatura de Gracia"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txttempgracia
        '
        Me.txttempgracia.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttempgracia.Location = New System.Drawing.Point(388, 61)
        Me.txttempgracia.MaxLength = 3
        Me.txttempgracia.Name = "txttempgracia"
        Me.txttempgracia.Size = New System.Drawing.Size(41, 22)
        Me.txttempgracia.TabIndex = 8
        Me.txttempgracia.Text = "2"
        Me.txttempgracia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtHor1
        '
        Me.TxtHor1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtHor1.Location = New System.Drawing.Point(170, 54)
        Me.TxtHor1.Mask = "00:00"
        Me.TxtHor1.Name = "TxtHor1"
        Me.TxtHor1.Size = New System.Drawing.Size(48, 23)
        Me.TxtHor1.TabIndex = 36
        Me.TxtHor1.Text = "0830"
        Me.TxtHor1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TxtHor1.ValidatingType = GetType(Date)
        '
        'Label7
        '
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(7, 7)
        Me.Label7.Name = "Label7"
        Me.Label7.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.Label7.Size = New System.Drawing.Size(152, 22)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Temperatura"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtHor2
        '
        Me.TxtHor2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtHor2.Location = New System.Drawing.Point(239, 54)
        Me.TxtHor2.Mask = "00:00"
        Me.TxtHor2.Name = "TxtHor2"
        Me.TxtHor2.Size = New System.Drawing.Size(48, 23)
        Me.TxtHor2.TabIndex = 37
        Me.TxtHor2.Text = "2130"
        Me.TxtHor2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TxtHor2.ValidatingType = GetType(Date)
        '
        'txttemp
        '
        Me.txttemp.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttemp.Location = New System.Drawing.Point(164, 7)
        Me.txttemp.MaxLength = 3
        Me.txttemp.Name = "txttemp"
        Me.txttemp.Size = New System.Drawing.Size(41, 22)
        Me.txttemp.TabIndex = 7
        Me.txttemp.Text = "-18"
        Me.txttemp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(216, 36)
        Me.Label5.Name = "Label5"
        Me.Label5.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.Label5.Size = New System.Drawing.Size(167, 20)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Fecha Término"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtfexpiracion
        '
        Me.txtfexpiracion.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtfexpiracion.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtfexpiracion.Location = New System.Drawing.Point(388, 36)
        Me.txtfexpiracion.Name = "txtfexpiracion"
        Me.txtfexpiracion.Size = New System.Drawing.Size(112, 22)
        Me.txtfexpiracion.TabIndex = 5
        '
        'txtfcontrato
        '
        Me.txtfcontrato.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtfcontrato.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtfcontrato.Location = New System.Drawing.Point(388, 7)
        Me.txtfcontrato.Name = "txtfcontrato"
        Me.txtfcontrato.Size = New System.Drawing.Size(112, 22)
        Me.txtfcontrato.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(216, 7)
        Me.Label4.Name = "Label4"
        Me.Label4.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.Label4.Size = New System.Drawing.Size(167, 22)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Fecha Inicio"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.detalle
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(391, 616)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(144, 35)
        Me.Button1.TabIndex = 35
        Me.Button1.Text = "        Detalle cotización"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtdescripcion
        '
        Me.txtdescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtdescripcion.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdescripcion.Location = New System.Drawing.Point(258, 73)
        Me.txtdescripcion.MaxLength = 50
        Me.txtdescripcion.Name = "txtdescripcion"
        Me.txtdescripcion.Size = New System.Drawing.Size(248, 22)
        Me.txtdescripcion.TabIndex = 3
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.txtdescsopo)
        Me.GroupBox2.Controls.Add(Me.Panel2)
        Me.GroupBox2.Controls.Add(Me.Btn_BuscaCliente)
        Me.GroupBox2.Controls.Add(Me.TxtCliente)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Btn_BuscaContrato)
        Me.GroupBox2.Controls.Add(Me.Txtrut)
        Me.GroupBox2.Controls.Add(Me.txtcoti)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.txtdescripcion)
        Me.GroupBox2.Controls.Add(Me.CheckEstado)
        Me.GroupBox2.Controls.Add(Me.Label26)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(523, 598)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        '
        'Label15
        '
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label15.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label15.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(10, 103)
        Me.Label15.Name = "Label15"
        Me.Label15.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.Label15.Size = New System.Drawing.Size(127, 22)
        Me.Label15.TabIndex = 72
        Me.Label15.Text = "Tipo Soportante"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtdescsopo
        '
        Me.txtdescsopo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtdescsopo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdescsopo.Location = New System.Drawing.Point(149, 103)
        Me.txtdescsopo.MaxLength = 60
        Me.txtdescsopo.Name = "txtdescsopo"
        Me.txtdescsopo.Size = New System.Drawing.Size(357, 22)
        Me.txtdescsopo.TabIndex = 71
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.CbSeguros)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.Panel1)
        Me.Panel2.Controls.Add(Me.checklectura)
        Me.Panel2.Controls.Add(Me.CbCarga)
        Me.Panel2.Controls.Add(Me.CBBloquearfact)
        Me.Panel2.Controls.Add(Me.CbImportaciones)
        Me.Panel2.Controls.Add(Me.CbNumerales)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.txtfcontrato)
        Me.Panel2.Controls.Add(Me.txtfexpiracion)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.txttemp)
        Me.Panel2.Controls.Add(Me.txttempgracia)
        Me.Panel2.Controls.Add(Me.Label13)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.txtderecho)
        Me.Panel2.Controls.Add(Me.txttunel)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.txtpalletmin)
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Controls.Add(Me.txtcamaracerrada)
        Me.Panel2.Controls.Add(Me.Label14)
        Me.Panel2.Enabled = False
        Me.Panel2.Location = New System.Drawing.Point(6, 143)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(511, 446)
        Me.Panel2.TabIndex = 70
        '
        'CbSeguros
        '
        Me.CbSeguros.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbSeguros.FormattingEnabled = True
        Me.CbSeguros.Location = New System.Drawing.Point(164, 171)
        Me.CbSeguros.Name = "CbSeguros"
        Me.CbSeguros.Size = New System.Drawing.Size(226, 24)
        Me.CbSeguros.TabIndex = 72
        '
        'Label6
        '
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(7, 171)
        Me.Label6.Name = "Label6"
        Me.Label6.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.Label6.Size = New System.Drawing.Size(152, 24)
        Me.Label6.TabIndex = 71
        Me.Label6.Text = "Tipo Seguro"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label21)
        Me.Panel1.Controls.Add(Me.TxtHor7)
        Me.Panel1.Controls.Add(Me.TxtHor8)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.Label20)
        Me.Panel1.Controls.Add(Me.TxtHor1)
        Me.Panel1.Controls.Add(Me.TxtHor5)
        Me.Panel1.Controls.Add(Me.TxtHor6)
        Me.Panel1.Controls.Add(Me.TxtHor2)
        Me.Panel1.Controls.Add(Me.TxtHor3)
        Me.Panel1.Controls.Add(Me.TxtHor4)
        Me.Panel1.Location = New System.Drawing.Point(7, 320)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(493, 117)
        Me.Panel1.TabIndex = 65
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.Label14.Location = New System.Drawing.Point(6, 113)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(491, 18)
        Me.Label14.TabIndex = 70
        Me.Label14.Text = "_____________________________________________________________________"
        '
        'Btn_BuscaCliente
        '
        Me.Btn_BuscaCliente.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_BuscaCliente.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.buscar_24
        Me.Btn_BuscaCliente.Location = New System.Drawing.Point(233, 16)
        Me.Btn_BuscaCliente.Name = "Btn_BuscaCliente"
        Me.Btn_BuscaCliente.Size = New System.Drawing.Size(24, 24)
        Me.Btn_BuscaCliente.TabIndex = 17
        Me.Btn_BuscaCliente.UseVisualStyleBackColor = True
        '
        'TxtCliente
        '
        Me.TxtCliente.Enabled = False
        Me.TxtCliente.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCliente.Location = New System.Drawing.Point(149, 43)
        Me.TxtCliente.MaxLength = 70
        Me.TxtCliente.Name = "TxtCliente"
        Me.TxtCliente.Size = New System.Drawing.Size(357, 22)
        Me.TxtCliente.TabIndex = 18
        '
        'Label2
        '
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(10, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.Label2.Size = New System.Drawing.Size(127, 22)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Descripción"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Btn_BuscaContrato
        '
        Me.Btn_BuscaContrato.Enabled = False
        Me.Btn_BuscaContrato.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_BuscaContrato.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.buscar_24
        Me.Btn_BuscaContrato.Location = New System.Drawing.Point(231, 72)
        Me.Btn_BuscaContrato.Name = "Btn_BuscaContrato"
        Me.Btn_BuscaContrato.Size = New System.Drawing.Size(24, 24)
        Me.Btn_BuscaContrato.TabIndex = 19
        Me.Btn_BuscaContrato.UseVisualStyleBackColor = True
        '
        'Txtrut
        '
        Me.Txtrut.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtrut.Location = New System.Drawing.Point(149, 17)
        Me.Txtrut.Mask = "########-A"
        Me.Txtrut.Name = "Txtrut"
        Me.Txtrut.Size = New System.Drawing.Size(80, 22)
        Me.Txtrut.TabIndex = 1
        '
        'txtcoti
        '
        Me.txtcoti.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcoti.Location = New System.Drawing.Point(149, 73)
        Me.txtcoti.Name = "txtcoti"
        Me.txtcoti.Size = New System.Drawing.Size(80, 22)
        Me.txtcoti.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(11, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.Label1.Size = New System.Drawing.Size(127, 22)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "R.u.t Cliente"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CheckEstado
        '
        Me.CheckEstado.AutoSize = True
        Me.CheckEstado.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckEstado.Location = New System.Drawing.Point(345, 17)
        Me.CheckEstado.Name = "CheckEstado"
        Me.CheckEstado.Size = New System.Drawing.Size(169, 20)
        Me.CheckEstado.TabIndex = 20
        Me.CheckEstado.Text = "Bloquear Movimientos"
        Me.CheckEstado.UseVisualStyleBackColor = True
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.Label26.Location = New System.Drawing.Point(0, 248)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(519, 18)
        Me.Label26.TabIndex = 64
        Me.Label26.Text = "_________________________________________________________________________"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.Label19.Location = New System.Drawing.Point(0, 119)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(519, 18)
        Me.Label19.TabIndex = 36
        Me.Label19.Text = "_________________________________________________________________________"
        '
        'BtnImprimir
        '
        Me.BtnImprimir.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.BtnImprimir.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.printer
        Me.BtnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnImprimir.Location = New System.Drawing.Point(561, 177)
        Me.BtnImprimir.Name = "BtnImprimir"
        Me.BtnImprimir.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.BtnImprimir.Size = New System.Drawing.Size(125, 50)
        Me.BtnImprimir.TabIndex = 33
        Me.BtnImprimir.Text = "           F4 - Imprimir"
        Me.BtnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnImprimir.UseVisualStyleBackColor = True
        '
        'btn_eliminar
        '
        Me.btn_eliminar.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.btn_eliminar.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.eliminar
        Me.btn_eliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_eliminar.Location = New System.Drawing.Point(561, 353)
        Me.btn_eliminar.Name = "btn_eliminar"
        Me.btn_eliminar.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.btn_eliminar.Size = New System.Drawing.Size(125, 50)
        Me.btn_eliminar.TabIndex = 32
        Me.btn_eliminar.Text = "           F7 - Eliminar"
        Me.btn_eliminar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_eliminar.UseVisualStyleBackColor = True
        '
        'btn_guardar
        '
        Me.btn_guardar.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.btn_guardar.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.Guardar
        Me.btn_guardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_guardar.Location = New System.Drawing.Point(561, 236)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.btn_guardar.Size = New System.Drawing.Size(125, 50)
        Me.btn_guardar.TabIndex = 29
        Me.btn_guardar.Text = "           F5 - Guardar"
        Me.btn_guardar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_guardar.UseVisualStyleBackColor = True
        '
        'btn_salir
        '
        Me.btn_salir.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.btn_salir.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.salir
        Me.btn_salir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_salir.Location = New System.Drawing.Point(561, 412)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.btn_salir.Size = New System.Drawing.Size(125, 50)
        Me.btn_salir.TabIndex = 31
        Me.btn_salir.Text = "           Esc - Salir"
        Me.btn_salir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_salir.UseVisualStyleBackColor = True
        '
        'btn_nuevo
        '
        Me.btn_nuevo.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.btn_nuevo.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.Nuevo
        Me.btn_nuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_nuevo.Location = New System.Drawing.Point(561, 294)
        Me.btn_nuevo.Name = "btn_nuevo"
        Me.btn_nuevo.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.btn_nuevo.Size = New System.Drawing.Size(125, 50)
        Me.btn_nuevo.TabIndex = 30
        Me.btn_nuevo.Text = "           F6 - Nuevo"
        Me.btn_nuevo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_nuevo.UseVisualStyleBackColor = True
        '
        'Frm_Cotizaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(703, 666)
        Me.Controls.Add(Me.BtnImprimir)
        Me.Controls.Add(Me.btn_eliminar)
        Me.Controls.Add(Me.btn_guardar)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btn_salir)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btn_nuevo)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "Frm_Cotizaciones"
        Me.ShowIcon = False
        Me.Text = "Mantenedor de Cotizaciones"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtdescripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Btn_BuscaContrato As System.Windows.Forms.Button
    Friend WithEvents Txtrut As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtcoti As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn_eliminar As System.Windows.Forms.Button
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents btn_salir As System.Windows.Forms.Button
    Friend WithEvents btn_nuevo As System.Windows.Forms.Button
    Friend WithEvents Btn_BuscaCliente As System.Windows.Forms.Button
    Friend WithEvents TxtCliente As System.Windows.Forms.TextBox
    Friend WithEvents CheckEstado As System.Windows.Forms.CheckBox
    Friend WithEvents BtnImprimir As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents CBBloquearfact As System.Windows.Forms.CheckBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents CbImportaciones As System.Windows.Forms.CheckBox
    Friend WithEvents TxtHor7 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents TxtHor8 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txttunel As System.Windows.Forms.TextBox
    Friend WithEvents TxtHor5 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TxtHor6 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtcamaracerrada As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtpalletmin As System.Windows.Forms.TextBox
    Friend WithEvents TxtHor3 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents TxtHor4 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtderecho As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txttempgracia As System.Windows.Forms.TextBox
    Friend WithEvents TxtHor1 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxtHor2 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txttemp As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtfexpiracion As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtfcontrato As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CbCarga As System.Windows.Forms.CheckBox
    Friend WithEvents CbNumerales As System.Windows.Forms.ComboBox
    Friend WithEvents checklectura As System.Windows.Forms.CheckBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents CbSeguros As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtdescsopo As System.Windows.Forms.TextBox
End Class

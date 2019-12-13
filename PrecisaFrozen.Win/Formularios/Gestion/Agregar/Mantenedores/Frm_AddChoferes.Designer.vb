<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_AddChoferes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_AddChoferes))
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lblmensaje = New System.Windows.Forms.Label()
        Me.clirut = New System.Windows.Forms.MaskedTextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.clinombre = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.emprut = New System.Windows.Forms.MaskedTextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.empnombre = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lblrutcho = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtrampla = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.chopatente = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.chorut = New System.Windows.Forms.MaskedTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chonombre = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btn_eliminar = New System.Windows.Forms.Button()
        Me.btn_guardar = New System.Windows.Forms.Button()
        Me.btn_salir = New System.Windows.Forms.Button()
        Me.btn_nuevo = New System.Windows.Forms.Button()
        Me.Bloquear = New System.Windows.Forms.GroupBox()
        Me.txtobservchofer = New System.Windows.Forms.TextBox()
        Me.txtobservpatente = New System.Windows.Forms.TextBox()
        Me.txtobservrampla = New System.Windows.Forms.TextBox()
        Me.chkchofer = New System.Windows.Forms.CheckBox()
        Me.chkpatente = New System.Windows.Forms.CheckBox()
        Me.chkrampla = New System.Windows.Forms.CheckBox()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Bloquear.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox5.Controls.Add(Me.Button1)
        Me.GroupBox5.Controls.Add(Me.lblmensaje)
        Me.GroupBox5.Controls.Add(Me.clirut)
        Me.GroupBox5.Controls.Add(Me.Label7)
        Me.GroupBox5.Controls.Add(Me.clinombre)
        Me.GroupBox5.Controls.Add(Me.Label8)
        Me.GroupBox5.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.ForeColor = System.Drawing.Color.White
        Me.GroupBox5.Location = New System.Drawing.Point(12, 415)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(427, 102)
        Me.GroupBox5.TabIndex = 20
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Cliente"
        '
        'Button1
        '
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(214, 29)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(26, 22)
        Me.Button1.TabIndex = 18
        Me.Button1.UseVisualStyleBackColor = True
        '
        'lblmensaje
        '
        Me.lblmensaje.AutoSize = True
        Me.lblmensaje.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblmensaje.ForeColor = System.Drawing.Color.Gold
        Me.lblmensaje.Location = New System.Drawing.Point(245, 33)
        Me.lblmensaje.Name = "lblmensaje"
        Me.lblmensaje.Size = New System.Drawing.Size(103, 14)
        Me.lblmensaje.TabIndex = 14
        Me.lblmensaje.Text = "No Encontrado"
        Me.lblmensaje.Visible = False
        '
        'clirut
        '
        Me.clirut.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.clirut.Location = New System.Drawing.Point(89, 29)
        Me.clirut.Mask = "########-A"
        Me.clirut.Name = "clirut"
        Me.clirut.Size = New System.Drawing.Size(123, 22)
        Me.clirut.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(22, 32)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(36, 14)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "R.u.t"
        '
        'clinombre
        '
        Me.clinombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.clinombre.Enabled = False
        Me.clinombre.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.clinombre.Location = New System.Drawing.Point(89, 61)
        Me.clinombre.Name = "clinombre"
        Me.clinombre.Size = New System.Drawing.Size(297, 22)
        Me.clinombre.TabIndex = 8
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(22, 64)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(59, 14)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "R. Social"
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.emprut)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Controls.Add(Me.empnombre)
        Me.GroupBox4.Controls.Add(Me.Label3)
        Me.GroupBox4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.GroupBox4.Location = New System.Drawing.Point(12, 306)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(427, 103)
        Me.GroupBox4.TabIndex = 19
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Empresa Transportista"
        '
        'emprut
        '
        Me.emprut.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.emprut.Location = New System.Drawing.Point(89, 29)
        Me.emprut.Mask = "########-A"
        Me.emprut.Name = "emprut"
        Me.emprut.Size = New System.Drawing.Size(123, 22)
        Me.emprut.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(22, 32)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(36, 14)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "R.u.t"
        '
        'empnombre
        '
        Me.empnombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.empnombre.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.empnombre.Location = New System.Drawing.Point(89, 61)
        Me.empnombre.Name = "empnombre"
        Me.empnombre.Size = New System.Drawing.Size(297, 22)
        Me.empnombre.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(22, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 14)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Nombre"
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.Bloquear)
        Me.GroupBox3.Controls.Add(Me.lblrutcho)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.txtrampla)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.chopatente)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.chorut)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.chonombre)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(427, 288)
        Me.GroupBox3.TabIndex = 18
        Me.GroupBox3.TabStop = False
        '
        'lblrutcho
        '
        Me.lblrutcho.AutoSize = True
        Me.lblrutcho.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblrutcho.ForeColor = System.Drawing.Color.Gold
        Me.lblrutcho.Location = New System.Drawing.Point(218, 28)
        Me.lblrutcho.Name = "lblrutcho"
        Me.lblrutcho.Size = New System.Drawing.Size(84, 14)
        Me.lblrutcho.TabIndex = 18
        Me.lblrutcho.Text = "Ingrese Rut"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(218, 138)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(185, 15)
        Me.Label10.TabIndex = 17
        Me.Label10.Text = "EJ: (AB-1234 / ABCD-12 / ABC-123)"
        '
        'txtrampla
        '
        Me.txtrampla.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtrampla.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtrampla.Location = New System.Drawing.Point(89, 135)
        Me.txtrampla.Name = "txtrampla"
        Me.txtrampla.Size = New System.Drawing.Size(123, 22)
        Me.txtrampla.TabIndex = 4
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(21, 138)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(53, 14)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "Rampla"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(218, 98)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(185, 15)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "EJ: (AB-1234 / ABCD-12 / ABC-123)"
        '
        'chopatente
        '
        Me.chopatente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.chopatente.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chopatente.Location = New System.Drawing.Point(89, 95)
        Me.chopatente.Name = "chopatente"
        Me.chopatente.Size = New System.Drawing.Size(123, 22)
        Me.chopatente.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(21, 99)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 14)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Patente"
        '
        'chorut
        '
        Me.chorut.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chorut.Location = New System.Drawing.Point(89, 25)
        Me.chorut.Mask = "########-A"
        Me.chorut.Name = "chorut"
        Me.chorut.Size = New System.Drawing.Size(123, 22)
        Me.chorut.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(22, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 14)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Codigo"
        '
        'chonombre
        '
        Me.chonombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.chonombre.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chonombre.Location = New System.Drawing.Point(89, 61)
        Me.chonombre.Name = "chonombre"
        Me.chonombre.Size = New System.Drawing.Size(297, 22)
        Me.chonombre.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(22, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 14)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Nombre"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.btn_eliminar)
        Me.GroupBox2.Controls.Add(Me.btn_guardar)
        Me.GroupBox2.Controls.Add(Me.btn_salir)
        Me.GroupBox2.Controls.Add(Me.btn_nuevo)
        Me.GroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox2.Location = New System.Drawing.Point(445, 13)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(85, 290)
        Me.GroupBox2.TabIndex = 33
        Me.GroupBox2.TabStop = False
        '
        'btn_eliminar
        '
        Me.btn_eliminar.FlatAppearance.BorderSize = 0
        Me.btn_eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_eliminar.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_hojamenos
        Me.btn_eliminar.Location = New System.Drawing.Point(11, 148)
        Me.btn_eliminar.Name = "btn_eliminar"
        Me.btn_eliminar.Size = New System.Drawing.Size(63, 63)
        Me.btn_eliminar.TabIndex = 32
        Me.btn_eliminar.UseVisualStyleBackColor = True
        '
        'btn_guardar
        '
        Me.btn_guardar.FlatAppearance.BorderSize = 0
        Me.btn_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_guardar.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_guardar2
        Me.btn_guardar.Location = New System.Drawing.Point(11, 21)
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
        Me.btn_salir.Location = New System.Drawing.Point(11, 211)
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
        Me.btn_nuevo.Location = New System.Drawing.Point(11, 85)
        Me.btn_nuevo.Name = "btn_nuevo"
        Me.btn_nuevo.Size = New System.Drawing.Size(63, 63)
        Me.btn_nuevo.TabIndex = 30
        Me.btn_nuevo.UseVisualStyleBackColor = True
        '
        'Bloquear
        '
        Me.Bloquear.Controls.Add(Me.chkrampla)
        Me.Bloquear.Controls.Add(Me.chkpatente)
        Me.Bloquear.Controls.Add(Me.chkchofer)
        Me.Bloquear.Controls.Add(Me.txtobservrampla)
        Me.Bloquear.Controls.Add(Me.txtobservpatente)
        Me.Bloquear.Controls.Add(Me.txtobservchofer)
        Me.Bloquear.ForeColor = System.Drawing.SystemColors.Window
        Me.Bloquear.Location = New System.Drawing.Point(25, 175)
        Me.Bloquear.Name = "Bloquear"
        Me.Bloquear.Size = New System.Drawing.Size(361, 100)
        Me.Bloquear.TabIndex = 20
        Me.Bloquear.TabStop = False
        Me.Bloquear.Text = "Bloquear"
        '
        'txtobservchofer
        '
        Me.txtobservchofer.Location = New System.Drawing.Point(23, 42)
        Me.txtobservchofer.MaxLength = 100
        Me.txtobservchofer.Multiline = True
        Me.txtobservchofer.Name = "txtobservchofer"
        Me.txtobservchofer.Size = New System.Drawing.Size(100, 46)
        Me.txtobservchofer.TabIndex = 0
        Me.txtobservchofer.Visible = False
        '
        'txtobservpatente
        '
        Me.txtobservpatente.Location = New System.Drawing.Point(132, 42)
        Me.txtobservpatente.MaxLength = 100
        Me.txtobservpatente.Multiline = True
        Me.txtobservpatente.Name = "txtobservpatente"
        Me.txtobservpatente.Size = New System.Drawing.Size(100, 46)
        Me.txtobservpatente.TabIndex = 1
        Me.txtobservpatente.Visible = False
        '
        'txtobservrampla
        '
        Me.txtobservrampla.Location = New System.Drawing.Point(240, 42)
        Me.txtobservrampla.MaxLength = 100
        Me.txtobservrampla.Multiline = True
        Me.txtobservrampla.Name = "txtobservrampla"
        Me.txtobservrampla.Size = New System.Drawing.Size(100, 46)
        Me.txtobservrampla.TabIndex = 2
        Me.txtobservrampla.Visible = False
        '
        'chkchofer
        '
        Me.chkchofer.AutoSize = True
        Me.chkchofer.Location = New System.Drawing.Point(23, 19)
        Me.chkchofer.Name = "chkchofer"
        Me.chkchofer.Size = New System.Drawing.Size(68, 18)
        Me.chkchofer.TabIndex = 3
        Me.chkchofer.Text = "Chofer"
        Me.chkchofer.UseVisualStyleBackColor = True
        '
        'chkpatente
        '
        Me.chkpatente.AutoSize = True
        Me.chkpatente.Location = New System.Drawing.Point(132, 19)
        Me.chkpatente.Name = "chkpatente"
        Me.chkpatente.Size = New System.Drawing.Size(76, 18)
        Me.chkpatente.TabIndex = 4
        Me.chkpatente.Text = "Patente"
        Me.chkpatente.UseVisualStyleBackColor = True
        '
        'chkrampla
        '
        Me.chkrampla.AutoSize = True
        Me.chkrampla.Location = New System.Drawing.Point(240, 19)
        Me.chkrampla.Name = "chkrampla"
        Me.chkrampla.Size = New System.Drawing.Size(72, 18)
        Me.chkrampla.TabIndex = 5
        Me.chkrampla.Text = "Rampla"
        Me.chkrampla.UseVisualStyleBackColor = True
        '
        'Frm_AddChoferes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(558, 529)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Name = "Frm_AddChoferes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Ingreso Choferes"
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.Bloquear.ResumeLayout(False)
        Me.Bloquear.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_eliminar As System.Windows.Forms.Button
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents btn_salir As System.Windows.Forms.Button
    Friend WithEvents btn_nuevo As System.Windows.Forms.Button
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents lblmensaje As System.Windows.Forms.Label
    Friend WithEvents clirut As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents clinombre As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents emprut As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents empnombre As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents lblrutcho As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtrampla As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents chopatente As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents chorut As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chonombre As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Bloquear As System.Windows.Forms.GroupBox
    Friend WithEvents chkrampla As System.Windows.Forms.CheckBox
    Friend WithEvents chkpatente As System.Windows.Forms.CheckBox
    Friend WithEvents chkchofer As System.Windows.Forms.CheckBox
    Friend WithEvents txtobservrampla As System.Windows.Forms.TextBox
    Friend WithEvents txtobservpatente As System.Windows.Forms.TextBox
    Friend WithEvents txtobservchofer As System.Windows.Forms.TextBox
End Class

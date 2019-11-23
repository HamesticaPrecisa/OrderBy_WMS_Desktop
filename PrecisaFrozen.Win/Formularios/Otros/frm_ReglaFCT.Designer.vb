<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_ReglaFCT
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_ReglaFCT))
        Me.btnOk = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtClirut = New System.Windows.Forms.TextBox()
        Me.btn_BuscaCliente = New System.Windows.Forms.Button()
        Me.txtclinom = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboFamProd = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtTmpIni = New System.Windows.Forms.TextBox()
        Me.txttmpFin = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtHorasD = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtKilos = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.rbtFijo = New System.Windows.Forms.RadioButton()
        Me.rbtDinamico = New System.Windows.Forms.RadioButton()
        Me.txtHorasF = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnOk
        '
        Me.btnOk.ForeColor = System.Drawing.Color.Black
        Me.btnOk.Location = New System.Drawing.Point(469, 241)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(100, 30)
        Me.btnOk.TabIndex = 9
        Me.btnOk.Text = "Aceptar"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(12, 50)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "CLIENTE"
        '
        'TxtClirut
        '
        Me.TxtClirut.Location = New System.Drawing.Point(76, 47)
        Me.TxtClirut.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TxtClirut.MaxLength = 8
        Me.TxtClirut.Name = "TxtClirut"
        Me.TxtClirut.Size = New System.Drawing.Size(82, 20)
        Me.TxtClirut.TabIndex = 1
        '
        'btn_BuscaCliente
        '
        Me.btn_BuscaCliente.Image = CType(resources.GetObject("btn_BuscaCliente.Image"), System.Drawing.Image)
        Me.btn_BuscaCliente.Location = New System.Drawing.Point(165, 46)
        Me.btn_BuscaCliente.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btn_BuscaCliente.Name = "btn_BuscaCliente"
        Me.btn_BuscaCliente.Size = New System.Drawing.Size(21, 22)
        Me.btn_BuscaCliente.TabIndex = 46
        Me.btn_BuscaCliente.UseVisualStyleBackColor = True
        '
        'txtclinom
        '
        Me.txtclinom.Enabled = False
        Me.txtclinom.Location = New System.Drawing.Point(194, 47)
        Me.txtclinom.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtclinom.Name = "txtclinom"
        Me.txtclinom.Size = New System.Drawing.Size(380, 20)
        Me.txtclinom.TabIndex = 47
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(12, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 49
        Me.Label1.Text = "FAMILIA"
        '
        'cboFamProd
        '
        Me.cboFamProd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFamProd.FormattingEnabled = True
        Me.cboFamProd.Location = New System.Drawing.Point(76, 18)
        Me.cboFamProd.Name = "cboFamProd"
        Me.cboFamProd.Size = New System.Drawing.Size(497, 21)
        Me.cboFamProd.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(304, 150)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(22, 13)
        Me.Label2.TabIndex = 51
        Me.Label2.Text = "DE"
        '
        'txtTmpIni
        '
        Me.txtTmpIni.Enabled = False
        Me.txtTmpIni.Location = New System.Drawing.Point(330, 170)
        Me.txtTmpIni.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtTmpIni.MaxLength = 8
        Me.txtTmpIni.Name = "txtTmpIni"
        Me.txtTmpIni.Size = New System.Drawing.Size(43, 20)
        Me.txtTmpIni.TabIndex = 7
        '
        'txttmpFin
        '
        Me.txttmpFin.Enabled = False
        Me.txttmpFin.Location = New System.Drawing.Point(330, 194)
        Me.txttmpFin.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txttmpFin.MaxLength = 8
        Me.txttmpFin.Name = "txttmpFin"
        Me.txttmpFin.Size = New System.Drawing.Size(43, 20)
        Me.txttmpFin.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(378, 197)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 13)
        Me.Label3.TabIndex = 53
        Me.Label3.Text = "GRADOS C."
        '
        'txtHorasD
        '
        Me.txtHorasD.Enabled = False
        Me.txtHorasD.Location = New System.Drawing.Point(330, 124)
        Me.txtHorasD.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtHorasD.MaxLength = 8
        Me.txtHorasD.Name = "txtHorasD"
        Me.txtHorasD.Size = New System.Drawing.Size(44, 20)
        Me.txtHorasD.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(380, 127)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(163, 13)
        Me.Label5.TabIndex = 55
        Me.Label5.Text = "HORAS PARA BAJAR LA TEMP"
        '
        'txtKilos
        '
        Me.txtKilos.Enabled = False
        Me.txtKilos.Location = New System.Drawing.Point(330, 147)
        Me.txtKilos.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtKilos.MaxLength = 8
        Me.txtKilos.Name = "txtKilos"
        Me.txtKilos.Size = New System.Drawing.Size(79, 20)
        Me.txtKilos.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(410, 150)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(120, 13)
        Me.Label6.TabIndex = 57
        Me.Label6.Text = "KILOS DE PRODUCTO"
        '
        'btnCancel
        '
        Me.btnCancel.ForeColor = System.Drawing.Color.Black
        Me.btnCancel.Location = New System.Drawing.Point(356, 241)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(100, 30)
        Me.btnCancel.TabIndex = 10
        Me.btnCancel.Text = "Cancelar"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'rbtFijo
        '
        Me.rbtFijo.AutoSize = True
        Me.rbtFijo.Checked = True
        Me.rbtFijo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtFijo.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.rbtFijo.Location = New System.Drawing.Point(15, 92)
        Me.rbtFijo.Name = "rbtFijo"
        Me.rbtFijo.Size = New System.Drawing.Size(50, 19)
        Me.rbtFijo.TabIndex = 2
        Me.rbtFijo.TabStop = True
        Me.rbtFijo.Text = "FIJO"
        Me.rbtFijo.UseVisualStyleBackColor = True
        '
        'rbtDinamico
        '
        Me.rbtDinamico.AutoSize = True
        Me.rbtDinamico.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtDinamico.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.rbtDinamico.Location = New System.Drawing.Point(262, 92)
        Me.rbtDinamico.Name = "rbtDinamico"
        Me.rbtDinamico.Size = New System.Drawing.Size(84, 19)
        Me.rbtDinamico.TabIndex = 3
        Me.rbtDinamico.Text = "DINAMICO"
        Me.rbtDinamico.UseVisualStyleBackColor = True
        '
        'txtHorasF
        '
        Me.txtHorasF.Location = New System.Drawing.Point(76, 122)
        Me.txtHorasF.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtHorasF.MaxLength = 8
        Me.txtHorasF.Name = "txtHorasF"
        Me.txtHorasF.Size = New System.Drawing.Size(46, 20)
        Me.txtHorasF.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(12, 127)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 13)
        Me.Label7.TabIndex = 62
        Me.Label7.Text = "REQUIERE"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(129, 127)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(77, 13)
        Me.Label8.TabIndex = 64
        Me.Label8.Text = "HORAS PARA"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(12, 150)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(185, 13)
        Me.Label9.TabIndex = 65
        Me.Label9.Text = "PARA LOGRAR LA TEMPERATURA"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(12, 174)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(74, 13)
        Me.Label10.TabIndex = 66
        Me.Label10.Text = "REQUERIDA."
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(263, 127)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(63, 13)
        Me.Label11.TabIndex = 67
        Me.Label11.Text = "REQUIERE"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(304, 174)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(22, 13)
        Me.Label12.TabIndex = 68
        Me.Label12.Text = "DE"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(378, 174)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(66, 13)
        Me.Label13.TabIndex = 69
        Me.Label13.Text = "GRADOS C."
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(312, 197)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(14, 13)
        Me.Label14.TabIndex = 70
        Me.Label14.Text = "A"
        '
        'frm_ReglaFCT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(582, 282)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtHorasF)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.rbtDinamico)
        Me.Controls.Add(Me.rbtFijo)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.txtKilos)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtHorasD)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txttmpFin)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtTmpIni)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboFamProd)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtClirut)
        Me.Controls.Add(Me.btn_BuscaCliente)
        Me.Controls.Add(Me.txtclinom)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnOk)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_ReglaFCT"
        Me.Text = "Regla Factor Congelamiento"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtClirut As System.Windows.Forms.TextBox
    Friend WithEvents btn_BuscaCliente As System.Windows.Forms.Button
    Friend WithEvents txtclinom As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboFamProd As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtTmpIni As System.Windows.Forms.TextBox
    Friend WithEvents txttmpFin As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtHorasD As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtKilos As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents rbtFijo As System.Windows.Forms.RadioButton
    Friend WithEvents rbtDinamico As System.Windows.Forms.RadioButton
    Friend WithEvents txtHorasF As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
End Class

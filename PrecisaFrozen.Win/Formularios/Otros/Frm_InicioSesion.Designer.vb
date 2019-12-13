<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_InicioSesion
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
        Me.txtusu = New System.Windows.Forms.TextBox()
        Me.txtpass = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.BtnSalir = New System.Windows.Forms.Button()
        Me.cbodesbod = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.rlocal = New System.Windows.Forms.RadioButton()
        Me.rwlan = New System.Windows.Forms.RadioButton()
        Me.SuspendLayout()
        '
        'txtusu
        '
        Me.txtusu.BackColor = System.Drawing.Color.White
        Me.txtusu.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtusu.Font = New System.Drawing.Font("Segoe Condensed", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtusu.ForeColor = System.Drawing.SystemColors.MenuText
        Me.txtusu.Location = New System.Drawing.Point(126, 131)
        Me.txtusu.Multiline = True
        Me.txtusu.Name = "txtusu"
        Me.txtusu.Size = New System.Drawing.Size(172, 28)
        Me.txtusu.TabIndex = 1
        '
        'txtpass
        '
        Me.txtpass.BackColor = System.Drawing.Color.White
        Me.txtpass.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtpass.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpass.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtpass.Location = New System.Drawing.Point(126, 189)
        Me.txtpass.Multiline = True
        Me.txtpass.Name = "txtpass"
        Me.txtpass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtpass.Size = New System.Drawing.Size(172, 28)
        Me.txtpass.TabIndex = 2
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.Gray
        Me.Button1.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.iniciar_secion
        Me.Button1.Location = New System.Drawing.Point(73, 279)
        Me.Button1.Margin = New System.Windows.Forms.Padding(0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(231, 37)
        Me.Button1.TabIndex = 3
        Me.Button1.UseVisualStyleBackColor = False
        '
        'BtnSalir
        '
        Me.BtnSalir.BackColor = System.Drawing.Color.Transparent
        Me.BtnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnSalir.Location = New System.Drawing.Point(314, 12)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(31, 23)
        Me.BtnSalir.TabIndex = 0
        Me.BtnSalir.Text = "X"
        Me.BtnSalir.UseVisualStyleBackColor = False
        '
        'cbodesbod
        '
        Me.cbodesbod.Enabled = False
        Me.cbodesbod.FormattingEnabled = True
        Me.cbodesbod.Location = New System.Drawing.Point(73, 255)
        Me.cbodesbod.Name = "cbodesbod"
        Me.cbodesbod.Size = New System.Drawing.Size(231, 21)
        Me.cbodesbod.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(70, 239)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Sucursal"
        '
        'rlocal
        '
        Me.rlocal.AutoSize = True
        Me.rlocal.BackColor = System.Drawing.Color.Transparent
        Me.rlocal.ForeColor = System.Drawing.Color.White
        Me.rlocal.Location = New System.Drawing.Point(244, 226)
        Me.rlocal.Name = "rlocal"
        Me.rlocal.Size = New System.Drawing.Size(59, 17)
        Me.rlocal.TabIndex = 6
        Me.rlocal.TabStop = True
        Me.rlocal.Text = "LOCAL"
        Me.rlocal.UseVisualStyleBackColor = False
        '
        'rwlan
        '
        Me.rwlan.AutoSize = True
        Me.rwlan.BackColor = System.Drawing.Color.Transparent
        Me.rwlan.ForeColor = System.Drawing.Color.White
        Me.rwlan.Location = New System.Drawing.Point(157, 226)
        Me.rwlan.Name = "rwlan"
        Me.rwlan.Size = New System.Drawing.Size(57, 17)
        Me.rwlan.TabIndex = 7
        Me.rwlan.TabStop = True
        Me.rwlan.Text = "WLAN"
        Me.rwlan.UseVisualStyleBackColor = False
        Me.rwlan.Visible = False
        '
        'Frm_InicioSesion
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Turquoise
        Me.BackgroundImage = Global.PrecisaFrozen.Win.My.Resources.Resources.ffffffffffffff3
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(374, 368)
        Me.Controls.Add(Me.rwlan)
        Me.Controls.Add(Me.rlocal)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbodesbod)
        Me.Controls.Add(Me.BtnSalir)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtusu)
        Me.Controls.Add(Me.txtpass)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Location = New System.Drawing.Point(80, 80)
        Me.Name = "Frm_InicioSesion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtusu As System.Windows.Forms.TextBox
    Friend WithEvents txtpass As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents BtnSalir As System.Windows.Forms.Button
    Friend WithEvents cbodesbod As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents rlocal As System.Windows.Forms.RadioButton
    Friend WithEvents rwlan As System.Windows.Forms.RadioButton
End Class

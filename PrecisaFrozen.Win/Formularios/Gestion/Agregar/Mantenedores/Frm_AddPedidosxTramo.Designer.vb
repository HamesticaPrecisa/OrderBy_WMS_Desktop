<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_AddPedidosxTramo
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboMinMan = New System.Windows.Forms.ComboBox()
        Me.txtCamMan = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCamMec = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboMinMec = New System.Windows.Forms.ComboBox()
        Me.btn_guardar = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtCamLev = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboMinLev = New System.Windows.Forms.ComboBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cboMinMan)
        Me.GroupBox1.Controls.Add(Me.txtCamMan)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 31)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(200, 228)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "CARGA MANUAL"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(36, 124)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Minutos"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(36, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Camiones "
        '
        'cboMinMan
        '
        Me.cboMinMan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMinMan.FormattingEnabled = True
        Me.cboMinMan.Items.AddRange(New Object() {"30", "60", "90", "120", "150", "180", "210", "240", "270", "300", "330", "390"})
        Me.cboMinMan.Location = New System.Drawing.Point(39, 140)
        Me.cboMinMan.Name = "cboMinMan"
        Me.cboMinMan.Size = New System.Drawing.Size(121, 21)
        Me.cboMinMan.TabIndex = 1
        '
        'txtCamMan
        '
        Me.txtCamMan.Location = New System.Drawing.Point(39, 63)
        Me.txtCamMan.Name = "txtCamMan"
        Me.txtCamMan.Size = New System.Drawing.Size(121, 20)
        Me.txtCamMan.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.txtCamMec)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.cboMinMec)
        Me.GroupBox2.Location = New System.Drawing.Point(218, 31)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(200, 228)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "CARGA MECANICA"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(34, 124)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Minutos"
        '
        'txtCamMec
        '
        Me.txtCamMec.Location = New System.Drawing.Point(37, 63)
        Me.txtCamMec.Name = "txtCamMec"
        Me.txtCamMec.Size = New System.Drawing.Size(121, 20)
        Me.txtCamMec.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(34, 47)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Camiones "
        '
        'cboMinMec
        '
        Me.cboMinMec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMinMec.Enabled = False
        Me.cboMinMec.FormattingEnabled = True
        Me.cboMinMec.Items.AddRange(New Object() {"30"})
        Me.cboMinMec.Location = New System.Drawing.Point(37, 140)
        Me.cboMinMec.Name = "cboMinMec"
        Me.cboMinMec.Size = New System.Drawing.Size(121, 21)
        Me.cboMinMec.TabIndex = 5
        '
        'btn_guardar
        '
        Me.btn_guardar.FlatAppearance.BorderSize = 0
        Me.btn_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_guardar.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_guardar2
        Me.btn_guardar.Location = New System.Drawing.Point(542, 263)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(82, 74)
        Me.btn_guardar.TabIndex = 30
        Me.btn_guardar.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cboMinLev)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.txtCamLev)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Location = New System.Drawing.Point(424, 31)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(200, 228)
        Me.GroupBox3.TabIndex = 8
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "CARGA LEVANTAR"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(34, 124)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 13)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Minutos"
        '
        'txtCamLev
        '
        Me.txtCamLev.Location = New System.Drawing.Point(37, 63)
        Me.txtCamLev.Name = "txtCamLev"
        Me.txtCamLev.Size = New System.Drawing.Size(121, 20)
        Me.txtCamLev.TabIndex = 4
        Me.txtCamLev.Text = " "
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(34, 47)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Camiones "
        '
        'cboMinLev
        '
        Me.cboMinLev.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMinLev.FormattingEnabled = True
        Me.cboMinLev.Items.AddRange(New Object() {"30", "60", "90", "120", "150", "180", "210", "240", "270", "300", "330", "390"})
        Me.cboMinLev.Location = New System.Drawing.Point(37, 140)
        Me.cboMinLev.Name = "cboMinLev"
        Me.cboMinLev.Size = New System.Drawing.Size(121, 21)
        Me.cboMinLev.TabIndex = 8
        '
        'Frm_AddPedidosxTramo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(649, 349)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.btn_guardar)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Frm_AddPedidosxTramo"
        Me.Text = "Camiones por tramos de tiempo"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboMinMan As System.Windows.Forms.ComboBox
    Friend WithEvents txtCamMan As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCamMec As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboMinMec As System.Windows.Forms.ComboBox
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtCamLev As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboMinLev As System.Windows.Forms.ComboBox
End Class

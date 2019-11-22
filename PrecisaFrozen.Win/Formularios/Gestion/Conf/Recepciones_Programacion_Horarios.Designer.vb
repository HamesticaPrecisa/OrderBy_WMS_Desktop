<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Recepciones_Programacion_Horarios
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
        Me.txtMinBloq = New System.Windows.Forms.TextBox()
        Me.txtHraFin = New System.Windows.Forms.TextBox()
        Me.txtHraIni = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboTipDia = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.btnGra = New System.Windows.Forms.Button()
        Me.btnSal = New System.Windows.Forms.Button()
        Me.btnLim = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtMinBloq)
        Me.GroupBox1.Controls.Add(Me.txtHraFin)
        Me.GroupBox1.Controls.Add(Me.txtHraIni)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cboTipDia)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label35)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 16)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(341, 236)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'txtMinBloq
        '
        Me.txtMinBloq.Location = New System.Drawing.Point(152, 165)
        Me.txtMinBloq.Name = "txtMinBloq"
        Me.txtMinBloq.Size = New System.Drawing.Size(109, 20)
        Me.txtMinBloq.TabIndex = 3
        '
        'txtHraFin
        '
        Me.txtHraFin.Location = New System.Drawing.Point(152, 128)
        Me.txtHraFin.Name = "txtHraFin"
        Me.txtHraFin.Size = New System.Drawing.Size(109, 20)
        Me.txtHraFin.TabIndex = 2
        '
        'txtHraIni
        '
        Me.txtHraIni.Location = New System.Drawing.Point(152, 91)
        Me.txtHraIni.Name = "txtHraIni"
        Me.txtHraIni.Size = New System.Drawing.Size(109, 20)
        Me.txtHraIni.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(7, 168)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(133, 13)
        Me.Label4.TabIndex = 80
        Me.Label4.Text = "MINUTOS BLOQUES : "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(7, 131)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(110, 13)
        Me.Label3.TabIndex = 79
        Me.Label3.Text = "HORA TÉRMINO : "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(7, 94)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 13)
        Me.Label1.TabIndex = 78
        Me.Label1.Text = "HORA INICIO : "
        '
        'cboTipDia
        '
        Me.cboTipDia.FormattingEnabled = True
        Me.cboTipDia.Location = New System.Drawing.Point(152, 54)
        Me.cboTipDia.Name = "cboTipDia"
        Me.cboTipDia.Size = New System.Drawing.Size(109, 21)
        Me.cboTipDia.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(7, 57)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 13)
        Me.Label2.TabIndex = 76
        Me.Label2.Text = "TIPO DÍA : "
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.BackColor = System.Drawing.Color.Transparent
        Me.Label35.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.ForeColor = System.Drawing.Color.White
        Me.Label35.Location = New System.Drawing.Point(6, 16)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(286, 14)
        Me.Label35.TabIndex = 71
        Me.Label35.Text = "CONFIGURACIÓN HORARIOS RECEPCIÓN"
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.btnGra)
        Me.GroupBox4.Controls.Add(Me.btnSal)
        Me.GroupBox4.Controls.Add(Me.btnLim)
        Me.GroupBox4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(359, 16)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(75, 236)
        Me.GroupBox4.TabIndex = 59
        Me.GroupBox4.TabStop = False
        '
        'btnGra
        '
        Me.btnGra.FlatAppearance.BorderSize = 0
        Me.btnGra.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGra.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_guardar2
        Me.btnGra.Location = New System.Drawing.Point(6, 19)
        Me.btnGra.Name = "btnGra"
        Me.btnGra.Size = New System.Drawing.Size(63, 63)
        Me.btnGra.TabIndex = 4
        Me.btnGra.UseVisualStyleBackColor = True
        '
        'btnSal
        '
        Me.btnSal.FlatAppearance.BorderSize = 0
        Me.btnSal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSal.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_salida
        Me.btnSal.Location = New System.Drawing.Point(6, 157)
        Me.btnSal.Name = "btnSal"
        Me.btnSal.Size = New System.Drawing.Size(63, 61)
        Me.btnSal.TabIndex = 6
        Me.btnSal.UseVisualStyleBackColor = True
        '
        'btnLim
        '
        Me.btnLim.FlatAppearance.BorderSize = 0
        Me.btnLim.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLim.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_hojanueva
        Me.btnLim.Location = New System.Drawing.Point(6, 88)
        Me.btnLim.Name = "btnLim"
        Me.btnLim.Size = New System.Drawing.Size(63, 63)
        Me.btnLim.TabIndex = 5
        Me.btnLim.UseVisualStyleBackColor = True
        '
        'Recepciones_Programacion_Horarios
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(446, 269)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Recepciones_Programacion_Horarios"
        Me.Text = "Recepciones_Programacion_Horarios"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboTipDia As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btnGra As System.Windows.Forms.Button
    Friend WithEvents btnSal As System.Windows.Forms.Button
    Friend WithEvents btnLim As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtMinBloq As System.Windows.Forms.TextBox
    Friend WithEvents txtHraFin As System.Windows.Forms.TextBox
    Friend WithEvents txtHraIni As System.Windows.Forms.TextBox
End Class

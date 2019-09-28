<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_AndenesCerr
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
        Me.txtcli = New System.Windows.Forms.TextBox()
        Me.txtanden = New System.Windows.Forms.TextBox()
        Me.txtusr = New System.Windows.Forms.TextBox()
        Me.DgvResultado = New System.Windows.Forms.DataGridView()
        Me.txtfolio = New System.Windows.Forms.TextBox()
        Me.obs = New System.Windows.Forms.TextBox()
        Me.txtcli2 = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.DgvResultado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtcli
        '
        Me.txtcli.Enabled = False
        Me.txtcli.Location = New System.Drawing.Point(12, 234)
        Me.txtcli.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtcli.Name = "txtcli"
        Me.txtcli.Size = New System.Drawing.Size(178, 20)
        Me.txtcli.TabIndex = 108
        '
        'txtanden
        '
        Me.txtanden.Enabled = False
        Me.txtanden.Location = New System.Drawing.Point(209, 234)
        Me.txtanden.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtanden.Name = "txtanden"
        Me.txtanden.Size = New System.Drawing.Size(131, 20)
        Me.txtanden.TabIndex = 109
        '
        'txtusr
        '
        Me.txtusr.Enabled = False
        Me.txtusr.Location = New System.Drawing.Point(348, 234)
        Me.txtusr.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtusr.Name = "txtusr"
        Me.txtusr.Size = New System.Drawing.Size(131, 20)
        Me.txtusr.TabIndex = 110
        '
        'DgvResultado
        '
        Me.DgvResultado.BackgroundColor = System.Drawing.SystemColors.GrayText
        Me.DgvResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvResultado.Location = New System.Drawing.Point(12, 12)
        Me.DgvResultado.Name = "DgvResultado"
        Me.DgvResultado.Size = New System.Drawing.Size(467, 216)
        Me.DgvResultado.TabIndex = 112
        '
        'txtfolio
        '
        Me.txtfolio.Enabled = False
        Me.txtfolio.Location = New System.Drawing.Point(13, 260)
        Me.txtfolio.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtfolio.Name = "txtfolio"
        Me.txtfolio.Size = New System.Drawing.Size(131, 20)
        Me.txtfolio.TabIndex = 113
        '
        'obs
        '
        Me.obs.Location = New System.Drawing.Point(13, 286)
        Me.obs.Multiline = True
        Me.obs.Name = "obs"
        Me.obs.Size = New System.Drawing.Size(410, 63)
        Me.obs.TabIndex = 114
        '
        'txtcli2
        '
        Me.txtcli2.Enabled = False
        Me.txtcli2.Location = New System.Drawing.Point(187, 260)
        Me.txtcli2.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtcli2.Name = "txtcli2"
        Me.txtcli2.Size = New System.Drawing.Size(131, 20)
        Me.txtcli2.TabIndex = 115
        Me.txtcli2.Visible = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.cruzzzz
        Me.Button1.Location = New System.Drawing.Point(427, 287)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(63, 63)
        Me.Button1.TabIndex = 111
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Frm_AndenesCerr
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(536, 391)
        Me.Controls.Add(Me.txtcli2)
        Me.Controls.Add(Me.obs)
        Me.Controls.Add(Me.txtfolio)
        Me.Controls.Add(Me.DgvResultado)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtusr)
        Me.Controls.Add(Me.txtanden)
        Me.Controls.Add(Me.txtcli)
        Me.Name = "Frm_AndenesCerr"
        Me.Text = "Cierre andenes "
        CType(Me.DgvResultado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtcli As System.Windows.Forms.TextBox
    Friend WithEvents txtanden As System.Windows.Forms.TextBox
    Friend WithEvents txtusr As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents DgvResultado As System.Windows.Forms.DataGridView
    Friend WithEvents txtfolio As System.Windows.Forms.TextBox
    Friend WithEvents obs As System.Windows.Forms.TextBox
    Friend WithEvents txtcli2 As System.Windows.Forms.TextBox
End Class

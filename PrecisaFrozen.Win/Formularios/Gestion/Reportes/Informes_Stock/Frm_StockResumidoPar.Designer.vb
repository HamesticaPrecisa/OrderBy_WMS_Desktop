<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_StockResumidoPar
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
        Me.LblContrato = New System.Windows.Forms.Label()
        Me.LblCliente = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.t2contrato = New System.Windows.Forms.CheckBox()
        Me.TxtContrato = New System.Windows.Forms.TextBox()
        Me.Txtcliente = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Btn_Contrato = New System.Windows.Forms.Button()
        Me.Btn_cliente = New System.Windows.Forms.Button()
        Me.Btn_Salir = New System.Windows.Forms.Button()
        Me.Btn_Imprimir = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'LblContrato
        '
        Me.LblContrato.AutoSize = True
        Me.LblContrato.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.LblContrato.Location = New System.Drawing.Point(149, 129)
        Me.LblContrato.Name = "LblContrato"
        Me.LblContrato.Size = New System.Drawing.Size(10, 13)
        Me.LblContrato.TabIndex = 68
        Me.LblContrato.Text = " "
        Me.LblContrato.Visible = False
        '
        'LblCliente
        '
        Me.LblCliente.AutoSize = True
        Me.LblCliente.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.LblCliente.Location = New System.Drawing.Point(149, 88)
        Me.LblCliente.Name = "LblCliente"
        Me.LblCliente.Size = New System.Drawing.Size(10, 13)
        Me.LblCliente.TabIndex = 67
        Me.LblCliente.Text = " "
        Me.LblCliente.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial Black", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(205, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(248, 23)
        Me.Label1.TabIndex = 65
        Me.Label1.Text = "Informe de stock detallado"
        '
        't2contrato
        '
        Me.t2contrato.AutoSize = True
        Me.t2contrato.BackColor = System.Drawing.Color.Transparent
        Me.t2contrato.Checked = True
        Me.t2contrato.CheckState = System.Windows.Forms.CheckState.Checked
        Me.t2contrato.ForeColor = System.Drawing.Color.White
        Me.t2contrato.Location = New System.Drawing.Point(460, 126)
        Me.t2contrato.Name = "t2contrato"
        Me.t2contrato.Size = New System.Drawing.Size(64, 17)
        Me.t2contrato.TabIndex = 63
        Me.t2contrato.Text = "TODOS"
        Me.t2contrato.UseVisualStyleBackColor = False
        '
        'TxtContrato
        '
        Me.TxtContrato.Enabled = False
        Me.TxtContrato.Location = New System.Drawing.Point(165, 124)
        Me.TxtContrato.Name = "TxtContrato"
        Me.TxtContrato.Size = New System.Drawing.Size(250, 20)
        Me.TxtContrato.TabIndex = 59
        '
        'Txtcliente
        '
        Me.Txtcliente.Enabled = False
        Me.Txtcliente.Location = New System.Drawing.Point(165, 84)
        Me.Txtcliente.Name = "Txtcliente"
        Me.Txtcliente.Size = New System.Drawing.Size(250, 20)
        Me.Txtcliente.TabIndex = 58
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(32, 87)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 56
        Me.Label2.Text = "CLIENTE"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(31, 128)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 13)
        Me.Label3.TabIndex = 57
        Me.Label3.Text = "CONTRATO"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(4, 19)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(511, 13)
        Me.Label11.TabIndex = 69
        Me.Label11.Text = "_________________________________________________________________________________" & _
    "___"
        Me.Label11.Visible = False
        '
        'Btn_Contrato
        '
        Me.Btn_Contrato.Enabled = False
        Me.Btn_Contrato.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.buscar_24
        Me.Btn_Contrato.Location = New System.Drawing.Point(432, 122)
        Me.Btn_Contrato.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Btn_Contrato.Name = "Btn_Contrato"
        Me.Btn_Contrato.Size = New System.Drawing.Size(21, 22)
        Me.Btn_Contrato.TabIndex = 61
        Me.Btn_Contrato.UseVisualStyleBackColor = True
        '
        'Btn_cliente
        '
        Me.Btn_cliente.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.buscar_24
        Me.Btn_cliente.Location = New System.Drawing.Point(432, 82)
        Me.Btn_cliente.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Btn_cliente.Name = "Btn_cliente"
        Me.Btn_cliente.Size = New System.Drawing.Size(21, 22)
        Me.Btn_cliente.TabIndex = 60
        Me.Btn_cliente.UseVisualStyleBackColor = True
        '
        'Btn_Salir
        '
        Me.Btn_Salir.BackColor = System.Drawing.Color.Transparent
        Me.Btn_Salir.FlatAppearance.BorderSize = 0
        Me.Btn_Salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_Salir.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_salida
        Me.Btn_Salir.Location = New System.Drawing.Point(542, 107)
        Me.Btn_Salir.Name = "Btn_Salir"
        Me.Btn_Salir.Size = New System.Drawing.Size(63, 63)
        Me.Btn_Salir.TabIndex = 66
        Me.Btn_Salir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Btn_Salir.UseVisualStyleBackColor = False
        '
        'Btn_Imprimir
        '
        Me.Btn_Imprimir.BackColor = System.Drawing.Color.Transparent
        Me.Btn_Imprimir.FlatAppearance.BorderSize = 0
        Me.Btn_Imprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_Imprimir.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_impresora
        Me.Btn_Imprimir.Location = New System.Drawing.Point(542, 43)
        Me.Btn_Imprimir.Name = "Btn_Imprimir"
        Me.Btn_Imprimir.Size = New System.Drawing.Size(63, 63)
        Me.Btn_Imprimir.TabIndex = 64
        Me.Btn_Imprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Btn_Imprimir.UseVisualStyleBackColor = False
        '
        'Frm_StockResumidoPar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(617, 187)
        Me.Controls.Add(Me.LblContrato)
        Me.Controls.Add(Me.LblCliente)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.t2contrato)
        Me.Controls.Add(Me.Btn_Contrato)
        Me.Controls.Add(Me.Btn_cliente)
        Me.Controls.Add(Me.TxtContrato)
        Me.Controls.Add(Me.Txtcliente)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Btn_Salir)
        Me.Controls.Add(Me.Btn_Imprimir)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_StockResumidoPar"
        Me.Text = "Informe de stock resumido"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LblContrato As System.Windows.Forms.Label
    Friend WithEvents LblCliente As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents t2contrato As System.Windows.Forms.CheckBox
    Friend WithEvents Btn_Contrato As System.Windows.Forms.Button
    Friend WithEvents Btn_cliente As System.Windows.Forms.Button
    Friend WithEvents TxtContrato As System.Windows.Forms.TextBox
    Friend WithEvents Txtcliente As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Btn_Salir As System.Windows.Forms.Button
    Friend WithEvents Btn_Imprimir As System.Windows.Forms.Button
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_PedidosMensualClientes
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
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtClirut = New System.Windows.Forms.TextBox()
        Me.btn_BuscaCliente = New System.Windows.Forms.Button()
        Me.Txtcliente = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CmboMes = New System.Windows.Forms.ComboBox()
        Me.t2contrato = New System.Windows.Forms.CheckBox()
        Me.Btn_Salir = New System.Windows.Forms.Button()
        Me.btn_Imprimir = New System.Windows.Forms.Button()
        Me.CmboAnio = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(27, 77)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 13)
        Me.Label3.TabIndex = 68
        Me.Label3.Text = "CLIENTE"
        '
        'TxtClirut
        '
        Me.TxtClirut.Enabled = False
        Me.TxtClirut.Location = New System.Drawing.Point(97, 73)
        Me.TxtClirut.Margin = New System.Windows.Forms.Padding(5, 3, 5, 3)
        Me.TxtClirut.Name = "TxtClirut"
        Me.TxtClirut.Size = New System.Drawing.Size(95, 21)
        Me.TxtClirut.TabIndex = 67
        '
        'btn_BuscaCliente
        '
        Me.btn_BuscaCliente.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.buscar_24
        Me.btn_BuscaCliente.Location = New System.Drawing.Point(200, 72)
        Me.btn_BuscaCliente.Margin = New System.Windows.Forms.Padding(5, 3, 5, 3)
        Me.btn_BuscaCliente.Name = "btn_BuscaCliente"
        Me.btn_BuscaCliente.Size = New System.Drawing.Size(24, 22)
        Me.btn_BuscaCliente.TabIndex = 65
        Me.btn_BuscaCliente.UseVisualStyleBackColor = True
        '
        'Txtcliente
        '
        Me.Txtcliente.Enabled = False
        Me.Txtcliente.Location = New System.Drawing.Point(230, 74)
        Me.Txtcliente.Margin = New System.Windows.Forms.Padding(5, 3, 5, 3)
        Me.Txtcliente.Name = "Txtcliente"
        Me.Txtcliente.Size = New System.Drawing.Size(291, 21)
        Me.Txtcliente.TabIndex = 66
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(27, 119)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 13)
        Me.Label1.TabIndex = 69
        Me.Label1.Text = "MES"
        '
        'CmboMes
        '
        Me.CmboMes.FormattingEnabled = True
        Me.CmboMes.Items.AddRange(New Object() {"ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SEPTIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE"})
        Me.CmboMes.Location = New System.Drawing.Point(97, 116)
        Me.CmboMes.Name = "CmboMes"
        Me.CmboMes.Size = New System.Drawing.Size(95, 21)
        Me.CmboMes.TabIndex = 70
        '
        't2contrato
        '
        Me.t2contrato.AutoSize = True
        Me.t2contrato.BackColor = System.Drawing.Color.Transparent
        Me.t2contrato.Checked = True
        Me.t2contrato.CheckState = System.Windows.Forms.CheckState.Checked
        Me.t2contrato.ForeColor = System.Drawing.Color.White
        Me.t2contrato.Location = New System.Drawing.Point(530, 76)
        Me.t2contrato.Name = "t2contrato"
        Me.t2contrato.Size = New System.Drawing.Size(68, 17)
        Me.t2contrato.TabIndex = 76
        Me.t2contrato.Text = "TODOS"
        Me.t2contrato.UseVisualStyleBackColor = False
        '
        'Btn_Salir
        '
        Me.Btn_Salir.BackColor = System.Drawing.Color.Transparent
        Me.Btn_Salir.FlatAppearance.BorderSize = 0
        Me.Btn_Salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_Salir.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_salida
        Me.Btn_Salir.Location = New System.Drawing.Point(615, 98)
        Me.Btn_Salir.Name = "Btn_Salir"
        Me.Btn_Salir.Size = New System.Drawing.Size(63, 63)
        Me.Btn_Salir.TabIndex = 91
        Me.Btn_Salir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Btn_Salir.UseVisualStyleBackColor = False
        '
        'btn_Imprimir
        '
        Me.btn_Imprimir.BackColor = System.Drawing.Color.Transparent
        Me.btn_Imprimir.FlatAppearance.BorderSize = 0
        Me.btn_Imprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Imprimir.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.icono_soportante
        Me.btn_Imprimir.Location = New System.Drawing.Point(615, 36)
        Me.btn_Imprimir.Name = "btn_Imprimir"
        Me.btn_Imprimir.Size = New System.Drawing.Size(63, 63)
        Me.btn_Imprimir.TabIndex = 90
        Me.btn_Imprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Imprimir.UseVisualStyleBackColor = False
        '
        'CmboAnio
        '
        Me.CmboAnio.FormattingEnabled = True
        Me.CmboAnio.Location = New System.Drawing.Point(265, 116)
        Me.CmboAnio.Name = "CmboAnio"
        Me.CmboAnio.Size = New System.Drawing.Size(95, 21)
        Me.CmboAnio.TabIndex = 93
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(227, 119)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 13)
        Me.Label2.TabIndex = 92
        Me.Label2.Text = "AÑO"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(26, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(361, 20)
        Me.Label4.TabIndex = 94
        Me.Label4.Text = "INFORME DE TIEMPOS DE PREPARACION DE PEDIDOS"
        '
        'Frm_PedidosMensualClientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(692, 208)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.CmboAnio)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Btn_Salir)
        Me.Controls.Add(Me.btn_Imprimir)
        Me.Controls.Add(Me.t2contrato)
        Me.Controls.Add(Me.CmboMes)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtClirut)
        Me.Controls.Add(Me.btn_BuscaCliente)
        Me.Controls.Add(Me.Txtcliente)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "Frm_PedidosMensualClientes"
        Me.Text = "Informe de Pedidos"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtClirut As System.Windows.Forms.TextBox
    Friend WithEvents btn_BuscaCliente As System.Windows.Forms.Button
    Friend WithEvents Txtcliente As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CmboMes As System.Windows.Forms.ComboBox
    Friend WithEvents t2contrato As System.Windows.Forms.CheckBox
    Friend WithEvents Btn_Salir As System.Windows.Forms.Button
    Friend WithEvents btn_Imprimir As System.Windows.Forms.Button
    Friend WithEvents CmboAnio As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class

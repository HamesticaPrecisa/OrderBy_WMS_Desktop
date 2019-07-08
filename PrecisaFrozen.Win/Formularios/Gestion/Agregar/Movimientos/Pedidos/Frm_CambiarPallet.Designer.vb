<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_CambiarPallet
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtacambiar = New System.Windows.Forms.TextBox()
        Me.txtpedido = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DgvCajas = New System.Windows.Forms.DataGridView()
        Me.sel = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.caj_cod = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtnuevopallet = New System.Windows.Forms.TextBox()
        Me.cbtodos = New System.Windows.Forms.CheckBox()
        Me.titulo = New System.Windows.Forms.Label()
        Me.BtnCancela = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblseleccionadas = New System.Windows.Forms.Label()
        Me.BtnCambiar = New System.Windows.Forms.Button()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DgvCajas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(12, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(109, 23)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "N° A CAMBIAR"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtacambiar
        '
        Me.txtacambiar.Enabled = False
        Me.txtacambiar.Location = New System.Drawing.Point(127, 42)
        Me.txtacambiar.Name = "txtacambiar"
        Me.txtacambiar.ReadOnly = True
        Me.txtacambiar.Size = New System.Drawing.Size(131, 23)
        Me.txtacambiar.TabIndex = 1
        Me.txtacambiar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtpedido
        '
        Me.txtpedido.Enabled = False
        Me.txtpedido.Location = New System.Drawing.Point(127, 71)
        Me.txtpedido.Name = "txtpedido"
        Me.txtpedido.ReadOnly = True
        Me.txtpedido.Size = New System.Drawing.Size(131, 23)
        Me.txtpedido.TabIndex = 3
        Me.txtpedido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(12, 71)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(109, 23)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "N° PEDIDO"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DgvCajas
        '
        Me.DgvCajas.AllowUserToAddRows = False
        Me.DgvCajas.AllowUserToDeleteRows = False
        Me.DgvCajas.ColumnHeadersHeight = 28
        Me.DgvCajas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.sel, Me.caj_cod})
        Me.DgvCajas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvCajas.Location = New System.Drawing.Point(10, 160)
        Me.DgvCajas.Name = "DgvCajas"
        Me.DgvCajas.ReadOnly = True
        Me.DgvCajas.RowHeadersWidth = 15
        Me.DgvCajas.Size = New System.Drawing.Size(359, 358)
        Me.DgvCajas.TabIndex = 4
        '
        'sel
        '
        Me.sel.DataPropertyName = "sel"
        Me.sel.HeaderText = ""
        Me.sel.Name = "sel"
        Me.sel.ReadOnly = True
        Me.sel.Width = 30
        '
        'caj_cod
        '
        Me.caj_cod.DataPropertyName = "caj_cod"
        Me.caj_cod.HeaderText = "N° Caja"
        Me.caj_cod.Name = "caj_cod"
        Me.caj_cod.ReadOnly = True
        Me.caj_cod.Width = 290
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(12, 99)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(109, 23)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "N° NUEVO"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtnuevopallet
        '
        Me.txtnuevopallet.Location = New System.Drawing.Point(127, 99)
        Me.txtnuevopallet.MaxLength = 9
        Me.txtnuevopallet.Name = "txtnuevopallet"
        Me.txtnuevopallet.Size = New System.Drawing.Size(131, 23)
        Me.txtnuevopallet.TabIndex = 6
        Me.txtnuevopallet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cbtodos
        '
        Me.cbtodos.BackColor = System.Drawing.Color.Transparent
        Me.cbtodos.ForeColor = System.Drawing.Color.White
        Me.cbtodos.Location = New System.Drawing.Point(11, 133)
        Me.cbtodos.Name = "cbtodos"
        Me.cbtodos.Size = New System.Drawing.Size(99, 23)
        Me.cbtodos.TabIndex = 7
        Me.cbtodos.Text = "Marcar Todos"
        Me.cbtodos.UseVisualStyleBackColor = False
        '
        'titulo
        '
        Me.titulo.BackColor = System.Drawing.Color.Transparent
        Me.titulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.titulo.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.titulo.ForeColor = System.Drawing.Color.White
        Me.titulo.Location = New System.Drawing.Point(10, 7)
        Me.titulo.Name = "titulo"
        Me.titulo.Size = New System.Drawing.Size(359, 30)
        Me.titulo.TabIndex = 8
        Me.titulo.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'BtnCancela
        '
        Me.BtnCancela.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.Eliminar_16
        Me.BtnCancela.Location = New System.Drawing.Point(264, 99)
        Me.BtnCancela.Name = "BtnCancela"
        Me.BtnCancela.Size = New System.Drawing.Size(23, 23)
        Me.BtnCancela.TabIndex = 9
        Me.BtnCancela.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(233, 524)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(117, 15)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Cajas seleccionadas :"
        '
        'lblseleccionadas
        '
        Me.lblseleccionadas.ForeColor = System.Drawing.Color.White
        Me.lblseleccionadas.Location = New System.Drawing.Point(349, 524)
        Me.lblseleccionadas.Name = "lblseleccionadas"
        Me.lblseleccionadas.Size = New System.Drawing.Size(20, 15)
        Me.lblseleccionadas.TabIndex = 11
        Me.lblseleccionadas.Text = "0"
        Me.lblseleccionadas.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BtnCambiar
        '
        Me.BtnCambiar.Location = New System.Drawing.Point(10, 530)
        Me.BtnCambiar.Name = "BtnCambiar"
        Me.BtnCambiar.Size = New System.Drawing.Size(122, 30)
        Me.BtnCambiar.TabIndex = 12
        Me.BtnCambiar.Text = "Cambiar Pallet"
        Me.BtnCambiar.UseVisualStyleBackColor = True
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "caj_cod"
        Me.DataGridViewTextBoxColumn1.HeaderText = "N° Caja"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 290
        '
        'Frm_CambiarPallet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(379, 568)
        Me.Controls.Add(Me.BtnCambiar)
        Me.Controls.Add(Me.lblseleccionadas)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.BtnCancela)
        Me.Controls.Add(Me.titulo)
        Me.Controls.Add(Me.cbtodos)
        Me.Controls.Add(Me.txtnuevopallet)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DgvCajas)
        Me.Controls.Add(Me.txtpedido)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtacambiar)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(395, 606)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(395, 606)
        Me.Name = "Frm_CambiarPallet"
        Me.Padding = New System.Windows.Forms.Padding(10, 160, 10, 50)
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Cambiar Pallet"
        CType(Me.DgvCajas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtacambiar As System.Windows.Forms.TextBox
    Friend WithEvents txtpedido As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DgvCajas As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtnuevopallet As System.Windows.Forms.TextBox
    Friend WithEvents cbtodos As System.Windows.Forms.CheckBox
    Friend WithEvents titulo As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sel As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents caj_cod As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BtnCancela As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblseleccionadas As System.Windows.Forms.Label
    Friend WithEvents BtnCambiar As System.Windows.Forms.Button
End Class

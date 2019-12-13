<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_VerificaServiciosDespa
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
        Me.DataAdicionales = New System.Windows.Forms.DataGridView()
        Me.btnno = New System.Windows.Forms.Button()
        Me.btnsi = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.de = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.un = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ca = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ki = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DataAdicionales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataAdicionales
        '
        Me.DataAdicionales.AllowUserToAddRows = False
        Me.DataAdicionales.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark
        Me.DataAdicionales.ColumnHeadersHeight = 30
        Me.DataAdicionales.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.de, Me.un, Me.ca, Me.ki})
        Me.DataAdicionales.Enabled = False
        Me.DataAdicionales.Location = New System.Drawing.Point(18, 31)
        Me.DataAdicionales.Name = "DataAdicionales"
        Me.DataAdicionales.Size = New System.Drawing.Size(582, 211)
        Me.DataAdicionales.TabIndex = 83
        '
        'btnno
        '
        Me.btnno.Location = New System.Drawing.Point(188, 248)
        Me.btnno.Name = "btnno"
        Me.btnno.Size = New System.Drawing.Size(202, 23)
        Me.btnno.TabIndex = 82
        Me.btnno.Text = "No, Faltan servicios por agregar"
        Me.btnno.UseVisualStyleBackColor = True
        '
        'btnsi
        '
        Me.btnsi.Location = New System.Drawing.Point(396, 248)
        Me.btnsi.Name = "btnsi"
        Me.btnsi.Size = New System.Drawing.Size(205, 23)
        Me.btnsi.TabIndex = 81
        Me.btnsi.Text = "Si, Estan correctos los servicios"
        Me.btnsi.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, CType((System.Drawing.FontStyle.Italic Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(15, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(351, 14)
        Me.Label1.TabIndex = 80
        Me.Label1.Text = "LISTADO DE SERVICIOS INCLUIDOS EN ESTE DESPACHO"
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "de"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Descripcion"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn1.Width = 240
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "un"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Unidades"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn2.Width = 70
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "ca"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Cajas"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn3.Width = 80
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "ki"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Kilos"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'de
        '
        Me.de.DataPropertyName = "de"
        Me.de.HeaderText = "Descripcion"
        Me.de.Name = "de"
        Me.de.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.de.Width = 240
        '
        'un
        '
        Me.un.DataPropertyName = "un"
        Me.un.HeaderText = "Unidades"
        Me.un.Name = "un"
        Me.un.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.un.Width = 70
        '
        'ca
        '
        Me.ca.DataPropertyName = "ca"
        Me.ca.HeaderText = "Cajas"
        Me.ca.Name = "ca"
        Me.ca.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ca.Width = 80
        '
        'ki
        '
        Me.ki.DataPropertyName = "ki"
        Me.ki.HeaderText = "Peso"
        Me.ki.Name = "ki"
        Me.ki.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Frm_VerificaServiciosDespa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(617, 280)
        Me.Controls.Add(Me.DataAdicionales)
        Me.Controls.Add(Me.btnno)
        Me.Controls.Add(Me.btnsi)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(623, 304)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(623, 304)
        Me.Name = "Frm_VerificaServiciosDespa"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Listado de servicios"
        CType(Me.DataAdicionales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataAdicionales As System.Windows.Forms.DataGridView
    Friend WithEvents btnno As System.Windows.Forms.Button
    Friend WithEvents btnsi As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents de As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents un As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ca As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ki As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

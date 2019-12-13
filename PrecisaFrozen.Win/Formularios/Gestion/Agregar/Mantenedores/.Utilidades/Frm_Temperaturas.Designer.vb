<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Temperaturas
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DgvTemp = New System.Windows.Forms.DataGridView()
        Me.Promedio = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Cant = New System.Windows.Forms.TextBox()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.DataGridViewImageColumn1 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.DataGridViewImageColumn2 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.SOPORTANTE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TEMP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Term = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Man = New System.Windows.Forms.DataGridViewImageColumn()
        CType(Me.DgvTemp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'DgvTemp
        '
        Me.DgvTemp.AllowUserToAddRows = False
        Me.DgvTemp.AllowUserToDeleteRows = False
        Me.DgvTemp.BackgroundColor = System.Drawing.SystemColors.ActiveCaption
        Me.DgvTemp.ColumnHeadersHeight = 30
        Me.DgvTemp.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SOPORTANTE, Me.TEMP, Me.Term, Me.Man})
        Me.DgvTemp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvTemp.Location = New System.Drawing.Point(0, 0)
        Me.DgvTemp.Name = "DgvTemp"
        Me.DgvTemp.Size = New System.Drawing.Size(331, 608)
        Me.DgvTemp.TabIndex = 0
        '
        'Promedio
        '
        Me.Promedio.Location = New System.Drawing.Point(191, 6)
        Me.Promedio.Name = "Promedio"
        Me.Promedio.ReadOnly = True
        Me.Promedio.Size = New System.Drawing.Size(76, 21)
        Me.Promedio.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(99, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "PROMEDIO T°"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "CANT."
        '
        'Cant
        '
        Me.Cant.Location = New System.Drawing.Point(57, 6)
        Me.Cant.Name = "Cant"
        Me.Cant.ReadOnly = True
        Me.Cant.Size = New System.Drawing.Size(28, 21)
        Me.Cant.TabIndex = 3
        Me.Cant.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "SOPORTANTE"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn2
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = "0.00"
        Me.DataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewTextBoxColumn2.HeaderText = "T ° ."
        Me.DataGridViewTextBoxColumn2.MaxInputLength = 5
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Promedio)
        Me.Panel1.Controls.Add(Me.Cant)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(10, 618)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(331, 32)
        Me.Panel1.TabIndex = 5
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.DgvTemp)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(10, 10)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(331, 608)
        Me.Panel2.TabIndex = 6
        '
        'DataGridViewImageColumn1
        '
        Me.DataGridViewImageColumn1.HeaderText = "TERM"
        Me.DataGridViewImageColumn1.Image = Global.PrecisaFrozen.Win.My.Resources.Resources._1413851891_700103_icon_69_thermometer_half_20
        Me.DataGridViewImageColumn1.Name = "DataGridViewImageColumn1"
        Me.DataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewImageColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewImageColumn1.Width = 24
        '
        'DataGridViewImageColumn2
        '
        Me.DataGridViewImageColumn2.HeaderText = "MAN"
        Me.DataGridViewImageColumn2.Image = Global.PrecisaFrozen.Win.My.Resources.Resources._1413851841_icon_22_one_finger_20
        Me.DataGridViewImageColumn2.Name = "DataGridViewImageColumn2"
        Me.DataGridViewImageColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewImageColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewImageColumn2.Width = 24
        '
        'SOPORTANTE
        '
        Me.SOPORTANTE.HeaderText = "SOPORTANTE"
        Me.SOPORTANTE.Name = "SOPORTANTE"
        Me.SOPORTANTE.ReadOnly = True
        Me.SOPORTANTE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'TEMP
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.Format = "N2"
        DataGridViewCellStyle1.NullValue = "0.00"
        Me.TEMP.DefaultCellStyle = DataGridViewCellStyle1
        Me.TEMP.HeaderText = "T ° ."
        Me.TEMP.MaxInputLength = 5
        Me.TEMP.Name = "TEMP"
        Me.TEMP.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Term
        '
        Me.Term.HeaderText = ""
        Me.Term.Image = Global.PrecisaFrozen.Win.My.Resources.Resources._1413851891_700103_icon_69_thermometer_half_20
        Me.Term.Name = "Term"
        Me.Term.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Term.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Term.Width = 24
        '
        'Man
        '
        Me.Man.HeaderText = ""
        Me.Man.Image = Global.PrecisaFrozen.Win.My.Resources.Resources._1413851841_icon_22_one_finger_20
        Me.Man.Name = "Man"
        Me.Man.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Man.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Man.Width = 24
        '
        'Frm_Temperaturas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(351, 660)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Temperaturas"
        Me.Padding = New System.Windows.Forms.Padding(10)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Ingreso de Temperaturas"
        CType(Me.DgvTemp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DgvTemp As System.Windows.Forms.DataGridView
    Friend WithEvents Promedio As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Cant As System.Windows.Forms.TextBox
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents DataGridViewImageColumn1 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents DataGridViewImageColumn2 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents SOPORTANTE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TEMP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Term As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents Man As System.Windows.Forms.DataGridViewImageColumn
End Class

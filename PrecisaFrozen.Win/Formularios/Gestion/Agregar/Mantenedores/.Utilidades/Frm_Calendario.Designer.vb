<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Calendario
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Calendario))
        Me.Calendario = New System.Windows.Forms.MonthCalendar()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'Calendario
        '
        Me.Calendario.BackColor = System.Drawing.Color.Blue
        Me.Calendario.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Calendario.Location = New System.Drawing.Point(0, 0)
        Me.Calendario.Name = "Calendario"
        Me.Calendario.ShowToday = False
        Me.Calendario.TabIndex = 0
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'Frm_Calendario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(225, 161)
        Me.Controls.Add(Me.Calendario)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(241, 199)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(241, 199)
        Me.Name = "Frm_Calendario"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "                 Calendario"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Calendario As System.Windows.Forms.MonthCalendar
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
End Class

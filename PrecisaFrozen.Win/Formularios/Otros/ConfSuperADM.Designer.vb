<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConfSuperADM
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConfSuperADM))
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'ListBox1
        '
        Me.ListBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.HorizontalScrollbar = True
        Me.ListBox1.ItemHeight = 25
        Me.ListBox1.Items.AddRange(New Object() {resources.GetString("ListBox1.Items"), "", resources.GetString("ListBox1.Items1"), resources.GetString("ListBox1.Items2"), "Usted podrá reproducir y usar solo una (1) copia del Software.", "3. DERECHOS DE AUTORÍA. El Software es propiedad exclusiva de PrecisaTech, y está" & _
                " protegido por la legislación sobre derechos de autor y cualquier legislación ap" & _
                "licable en el Estado de Chile.", "4. INSTALACIÓN. El Software Order By WMS versión 1.0 será instalado en el equipo " & _
                "del Cliente", "Por una duración de 3 meses.", resources.GetString("ListBox1.Items3"), resources.GetString("ListBox1.Items4"), resources.GetString("ListBox1.Items5"), "8. MODIFICACIÓN y ACTUALIZACIÓN DE VERSIONES. PrecisaTech podrá modificar o reins" & _
                "talar el Software bajo los términos y condiciones incluidos en el presente, reem" & _
                "plazándolo por versiones actualizadas.", resources.GetString("ListBox1.Items6"), "10. ROBO, PERDIDA, O CAMBIO DE ORDENADOR PERSONAL.", "En caso de robo, pérdida o cambio de su ordenador personal, PrecisaTech no se res" & _
                "ponsabiliza, como tampoco generará ni autorizará ni otorgará otra licencia de us" & _
                "o."})
        Me.ListBox1.Location = New System.Drawing.Point(12, 12)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.ScrollAlwaysVisible = True
        Me.ListBox1.Size = New System.Drawing.Size(726, 304)
        Me.ListBox1.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(271, 367)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(94, 34)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "CANCELAR"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(388, 367)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(94, 34)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "DE ACUERDO"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'ConfSuperADM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(755, 428)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ListBox1)
        Me.Name = "ConfSuperADM"
        Me.Text = "Configuración Inicial"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
End Class

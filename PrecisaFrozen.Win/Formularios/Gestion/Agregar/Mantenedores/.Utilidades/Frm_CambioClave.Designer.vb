﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_CambioClave
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtnueva = New System.Windows.Forms.TextBox()
        Me.txtanterior = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtrepetir = New System.Windows.Forms.TextBox()
        Me.Btn_Aceptar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(109, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "CLAVE ANTERIOR"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "CLAVE NUEVA"
        '
        'txtnueva
        '
        Me.txtnueva.Location = New System.Drawing.Point(127, 59)
        Me.txtnueva.Name = "txtnueva"
        Me.txtnueva.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtnueva.Size = New System.Drawing.Size(147, 21)
        Me.txtnueva.TabIndex = 1
        '
        'txtanterior
        '
        Me.txtanterior.Location = New System.Drawing.Point(127, 22)
        Me.txtanterior.Name = "txtanterior"
        Me.txtanterior.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtanterior.Size = New System.Drawing.Size(147, 21)
        Me.txtanterior.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 102)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "REPETIR CLAVE"
        '
        'txtrepetir
        '
        Me.txtrepetir.Location = New System.Drawing.Point(127, 99)
        Me.txtrepetir.Name = "txtrepetir"
        Me.txtrepetir.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtrepetir.Size = New System.Drawing.Size(147, 21)
        Me.txtrepetir.TabIndex = 2
        '
        'Btn_Aceptar
        '
        Me.Btn_Aceptar.Image = Global.PrecisaFrozen.Win.My.Resources.Resources.ok_16
        Me.Btn_Aceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btn_Aceptar.Location = New System.Drawing.Point(179, 140)
        Me.Btn_Aceptar.Name = "Btn_Aceptar"
        Me.Btn_Aceptar.Size = New System.Drawing.Size(95, 23)
        Me.Btn_Aceptar.TabIndex = 4
        Me.Btn_Aceptar.Text = "ACEPTAR  "
        Me.Btn_Aceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Btn_Aceptar.UseVisualStyleBackColor = True
        '
        'Frm_CambioClave
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(301, 176)
        Me.Controls.Add(Me.txtrepetir)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Btn_Aceptar)
        Me.Controls.Add(Me.txtanterior)
        Me.Controls.Add(Me.txtnueva)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "Frm_CambioClave"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Cambiar Clave"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtnueva As System.Windows.Forms.TextBox
    Friend WithEvents txtanterior As System.Windows.Forms.TextBox
    Friend WithEvents Btn_Aceptar As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtrepetir As System.Windows.Forms.TextBox
End Class

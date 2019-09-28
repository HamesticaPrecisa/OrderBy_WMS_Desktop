Public Class Frm_UtilidadChoferes

 
    Private Sub ListBox1_DoubleClick(sender As System.Object, e As System.EventArgs) Handles ListBox1.DoubleClick
        Dim _formInterface As IForm = CType(Me.Owner, IForm)
        _formInterface.ChangeTextBoxText(ListBox1.SelectedValue.ToString())
        Me.Close()
    End Sub

End Class
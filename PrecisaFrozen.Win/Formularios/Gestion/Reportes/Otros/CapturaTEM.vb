Public Class CapturaTEM

    Private Sub CapturaTEM_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
   
        'Dim obj As Object
        'Dim archivo As Object
        'obj = CreateObject("Scripting.FileSystemObject")
        'archivo = obj.CreateTextFile("C:\temp\ORLANDOORELLANA_instrument2_512044608.wdf")
        'archivo.WriteLine("esta en linea 1")
        'archivo.WriteLine("esta en linea 2")
        'archivo.close()

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim texto As String
        texto = My.Computer.FileSystem.ReadAllText("\\192.168.1.164\archivos\temp\ORLANDOORELLANA_instrument2_512044608.wdf")
        TextBox1.Text = texto.Substring(279, 4)
    End Sub

    Private Sub CapturaTEM_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        f_demo = False
    End Sub
End Class
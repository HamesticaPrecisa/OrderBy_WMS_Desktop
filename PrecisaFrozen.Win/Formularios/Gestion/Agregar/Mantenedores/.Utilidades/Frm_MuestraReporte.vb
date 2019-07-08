Imports System.Environment
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports


Public Class Frm_MuestraReporte

    Dim cryRpt As New ReportDocument
    Dim fnc As New Funciones

    Dim PAGE_INI As Integer = 0
    Dim PAGE_FIN As Integer = 0
    Dim len As Int32 = 0
    Dim slen As String = ""
    Dim slen2 As String = ""
  


    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Try
            cryRpt = Me.Contenedor.ReportSource
            Dim CrExportOptions As ExportOptions
            Dim CrDiskFileDestinationOptions As New  _
            DiskFileDestinationOptions()
            Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions()
            CrDiskFileDestinationOptions.DiskFileName = Environment.GetFolderPath(SpecialFolder.DesktopDirectory) + "\" + Me.Contenedor.ReportSource.ToString() + ".Pdf"
            CrExportOptions = cryRpt.ExportOptions
            With CrExportOptions
                .ExportDestinationType = ExportDestinationType.DiskFile
                .ExportFormatType = ExportFormatType.PortableDocFormat
                .DestinationOptions = CrDiskFileDestinationOptions
                .FormatOptions = CrFormatTypeOptions
            End With
            cryRpt.Export()
            MsgBox("Archivo exportado en el escritorio de su ordenador", MsgBoxStyle.Information, "Aviso")
            Dim OldName, NewName As String
            NewName = documentoimp
            OldName = Environment.GetFolderPath(SpecialFolder.DesktopDirectory) + "\" + Me.Contenedor.ReportSource.ToString() + ".Pdf"
            NewName = Environment.GetFolderPath(SpecialFolder.DesktopDirectory) + "\" + NewName + ".Pdf"
            ' Move and rename file.
            Rename(OldName, NewName)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Try
            cryRpt = Me.Contenedor.ReportSource
            Dim CrExportOptions As ExportOptions
            Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions()
            Dim CrFormatTypeOptions As New ExcelFormatOptions()
            CrDiskFileDestinationOptions.DiskFileName = Environment.GetFolderPath(SpecialFolder.DesktopDirectory) + "\" + Me.Contenedor.ReportSource.ToString() + ".xls"
            CrExportOptions = cryRpt.ExportOptions

            With CrExportOptions
                .ExportDestinationType = ExportDestinationType.DiskFile
                .ExportFormatType = ExportFormatType.Excel
                .DestinationOptions = CrDiskFileDestinationOptions
            End With

            cryRpt.Export()
            MsgBox("Archivo exportado en el escritorio de su ordenador", MsgBoxStyle.Information, "Aviso")
            Dim OldName, NewName As String
            NewName = documentoimp
            OldName = Environment.GetFolderPath(SpecialFolder.DesktopDirectory) + "\" + Me.Contenedor.ReportSource.ToString() + ".xls"
            NewName = Environment.GetFolderPath(SpecialFolder.DesktopDirectory) + "\" + NewName + ".xls"
            ' Move and rename file.
            Rename(OldName, NewName)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Try
            cryRpt = Me.Contenedor.ReportSource
            Dim CrExportOptions As ExportOptions
            Dim CrDiskFileDestinationOptions As New  _
            DiskFileDestinationOptions()
            Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions
            CrDiskFileDestinationOptions.DiskFileName = Environment.GetFolderPath(SpecialFolder.DesktopDirectory) + "\" + Me.Contenedor.ReportSource.ToString() + ".doc"
            CrExportOptions = cryRpt.ExportOptions
            With CrExportOptions
                .ExportDestinationType = ExportDestinationType.DiskFile
                .ExportFormatType = ExportFormatType.WordForWindows
                .DestinationOptions = CrDiskFileDestinationOptions
                .FormatOptions = CrFormatTypeOptions
            End With
            cryRpt.Export()
            MsgBox("Archivo exportado en el escritorio de su ordenador", MsgBoxStyle.Information, "Aviso")


            Dim OldName, NewName As String
            NewName = documentoimp
            OldName = Environment.GetFolderPath(SpecialFolder.DesktopDirectory) + "\" + Me.Contenedor.ReportSource.ToString() + ".doc"
            NewName = Environment.GetFolderPath(SpecialFolder.DesktopDirectory) + "\" + NewName + ".doc"
            ' Move and rename file.
            Rename(OldName, NewName)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        'Dim x As Integer = 0
        'x = Me.Contenedor.GetCurrentPageNumber

        'Me.Contenedor.ShowFirstPage()
        'PAGE_INI = Me.Contenedor.GetCurrentPageNumber

        'Me.Contenedor.ShowLastPage()
        'PAGE_FIN = Me.Contenedor.GetCurrentPageNumber

        'Me.Contenedor.ShowNthPage(x)


        'Dim rpt As New ReportDocument
        'rpt = Me.Contenedor.ReportSource
        'Dim tabla As DataTable = fnc.ListarTablasSQL("SELECT imp_inf FROM conf_impresora WHERE imp_comp='" + My.Computer.Name + "'")
        'If tabla.Rows.Count > 0 Then
        '    rpt.PrintOptions.PrinterName = tabla.Rows(0)(0).ToString()
        '    rpt.PrintToPrinter(1, False, 1, PAGE_FIN)
        'End If
        Me.Contenedor.PrintReport()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub Contenedor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Contenedor.Load

    End Sub

    Private Sub Frm_MuestraReporte_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Frm_Principal.buscavalor = ""

        len = Me.Contenedor.ReportSource.ToString().Length - 18
        slen = Me.Contenedor.ReportSource.ToString()
        slen2 = slen.Substring(18, len)
    End Sub
End Class
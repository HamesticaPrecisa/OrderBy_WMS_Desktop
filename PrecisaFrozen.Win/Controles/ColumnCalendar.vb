Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports System.Runtime.InteropServices
Imports System.Drawing



Public Class CalendarColumn
    Inherits DataGridViewColumn
    Public Sub New()
        MyBase.New(New CalendarCell())
    End Sub

    Public Overrides Property CellTemplate() As DataGridViewCell
        Get
            Return MyBase.CellTemplate
        End Get
        Set(ByVal value As DataGridViewCell)
            ' Ensure that the cell used for the template is a CalendarCell.
            If value IsNot Nothing AndAlso Not value.[GetType]().IsAssignableFrom(GetType(CalendarCell)) Then
                Throw New InvalidCastException("Must be a CalendarCell")
            End If
            MyBase.CellTemplate = value
        End Set
    End Property
End Class

Public Class CalendarCell
    Inherits DataGridViewTextBoxCell

    Public Sub New()
        MyBase.New()
        ' Use the short date format.
        Me.Style.Format = "d"
    End Sub

    Public Overrides Sub InitializeEditingControl(ByVal rowIndex As Integer, ByVal initialFormattedValue As Object, ByVal dataGridViewCellStyle As DataGridViewCellStyle)
        ' Set the value of the editing control to the current cell value.
        MyBase.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle)
        Dim ctl As CalendarEditingControl = TryCast(DataGridView.EditingControl, CalendarEditingControl)
        If Not (TypeOf Me.Value Is DBNull) Then
            ctl.Value = CType(Me.Value, DateTime)
        End If
    End Sub

    Public Overrides ReadOnly Property EditType() As Type
        Get
            ' Return the type of the editing contol that CalendarCell uses.
            Return GetType(CalendarEditingControl)
        End Get
    End Property

    Public Overrides ReadOnly Property ValueType() As Type
        Get
            ' Return the type of the value that CalendarCell contains.
            Return GetType(DateTime)
        End Get
    End Property

    Public Overrides ReadOnly Property DefaultNewRowValue() As Object
        Get
            ' Use the current date and time as the default value.
            'sknake
            Return DBNull.Value
        End Get
    End Property
End Class

Public Class CalendarEditingControl
    Inherits DateTimePicker
    Implements IDataGridViewEditingControl
    Private dataGridView As DataGridView
    Private valueChanged As Boolean = False
    Private rowIndex As Integer

    Public Sub New()
        Me.Format = DateTimePickerFormat.[Short]
    End Sub

    ' Implements the IDataGridViewEditingControl.EditingControlFormattedValue 
    ' property.
    Public Property EditingControlFormattedValue() As Object Implements IDataGridViewEditingControl.EditingControlFormattedValue
        Get
            Return Me.Value.ToShortDateString()
        End Get
        Set(ByVal value As Object)
            If TypeOf value Is [String] Then
                Me.Value = DateTime.Parse(DirectCast(value, [String]))
            End If
        End Set
    End Property

    ' Implements the 
    ' IDataGridViewEditingControl.GetEditingControlFormattedValue method.
    Public Function GetEditingControlFormattedValue(ByVal context As DataGridViewDataErrorContexts) As Object Implements IDataGridViewEditingControl.GetEditingControlFormattedValue
        Return EditingControlFormattedValue
    End Function

    ' Implements the 
    ' IDataGridViewEditingControl.ApplyCellStyleToEditingControl method.
    Public Sub ApplyCellStyleToEditingControl(ByVal dataGridViewCellStyle As DataGridViewCellStyle) Implements IDataGridViewEditingControl.ApplyCellStyleToEditingControl
        Me.Font = dataGridViewCellStyle.Font
        Me.CalendarForeColor = dataGridViewCellStyle.ForeColor
        Me.CalendarMonthBackground = dataGridViewCellStyle.BackColor
    End Sub

    ' Implements the IDataGridViewEditingControl.EditingControlRowIndex 
    ' property.
    Public Property EditingControlRowIndex() As Integer Implements IDataGridViewEditingControl.EditingControlRowIndex
        Get
            Return rowIndex
        End Get
        Set(ByVal value As Integer)
            rowIndex = value
        End Set
    End Property

    ' Implements the IDataGridViewEditingControl.EditingControlWantsInputKey 
    ' method.
    Public Function EditingControlWantsInputKey(ByVal key As Keys, ByVal dataGridViewWantsInputKey As Boolean) As Boolean Implements IDataGridViewEditingControl.EditingControlWantsInputKey
        ' Let the DateTimePicker handle the keys listed.
        Select Case key And Keys.KeyCode
            Case Keys.Left, Keys.Up, Keys.Down, Keys.Right, Keys.Home, Keys.[End], _
             Keys.PageDown, Keys.PageUp
                Return True
            Case Else
                Return Not dataGridViewWantsInputKey
        End Select
    End Function

    ' Implements the IDataGridViewEditingControl.PrepareEditingControlForEdit 
    ' method.
    Public Sub PrepareEditingControlForEdit(ByVal selectAll As Boolean) Implements IDataGridViewEditingControl.PrepareEditingControlForEdit
        If dataGridView.EditingControl Is Me Then
            Dim rect As Rectangle = dataGridView.GetCellDisplayRectangle(dataGridView.CurrentCell.ColumnIndex, rowIndex, True)
            Dim mi As New MouseInfo(Control.MouseButtons)
            Dim mousePos As Point = dataGridView.PointToClient(Control.MousePosition)
            If rect.Contains(mousePos) AndAlso (((rect.Left + rect.Width) - mousePos.X) <= 15) Then
                'Me.ShowDropDown(New DateTimePicker)
            End If
        End If
    End Sub

    ' Implements the IDataGridViewEditingControl
    ' .RepositionEditingControlOnValueChange property.
    Public ReadOnly Property RepositionEditingControlOnValueChange() As Boolean Implements IDataGridViewEditingControl.RepositionEditingControlOnValueChange
        Get
            Return False
        End Get
    End Property

    ' Implements the IDataGridViewEditingControl
    ' .EditingControlDataGridView property.
    Public Property EditingControlDataGridView() As DataGridView Implements IDataGridViewEditingControl.EditingControlDataGridView
        Get
            Return dataGridView
        End Get
        Set(ByVal value As DataGridView)
            dataGridView = value
        End Set
    End Property

    ' Implements the IDataGridViewEditingControl
    ' .EditingControlValueChanged property.
    Public Property EditingControlValueChanged() As Boolean Implements IDataGridViewEditingControl.EditingControlValueChanged
        Get
            Return valueChanged
        End Get
        Set(ByVal value As Boolean)
            valueChanged = value
        End Set
    End Property

    ' Implements the IDataGridViewEditingControl
    ' .EditingPanelCursor property.
    Public ReadOnly Property EditingPanelCursor() As Cursor Implements IDataGridViewEditingControl.EditingPanelCursor
        Get
            Return MyBase.Cursor
        End Get
    End Property

    Protected Overrides Sub OnValueChanged(ByVal eventargs As EventArgs)
        ' Notify the DataGridView that the contents of the cell
        ' have changed.
        valueChanged = True
        Me.EditingControlDataGridView.NotifyCurrentCellDirty(True)
        MyBase.OnValueChanged(eventargs)
    End Sub


    'Public Sub ShowDropDown(ByVal dtPicker As DateTimePicker)

    '    Dim x As Integer = dtPicker.Width - 10
    '    Dim y As Integer = dtPicker.Height / 2
    '    Dim lParam As Integer = x + y * &H10000
    '    InteropStuff.SendMessage(dtPicker.Handle, InteropStuff.WM_LBUTTONDOWN, 1, lParam)
    '    'DateTimePicker

    'End Sub

    'Public Sub ShowDropDown(ByVal dtPicker As CalendarEditingControl)
    '    ShowDropDown(New DateTimePicker)
    'End Sub
End Class
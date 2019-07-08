Imports System.Windows.Forms


Public Structure MouseInfo
    Private _ctrlStatus As Integer
    Private _left As Boolean
    Private _middle As Boolean
    Private _right As Boolean
    Private _leftAndRight As Boolean

    Public ReadOnly Property ControlStatus() As Integer
        Get
            Return _ctrlStatus
        End Get
    End Property
    Public ReadOnly Property Left() As Boolean
        Get
            Return _left
        End Get
    End Property
    Public ReadOnly Property Right() As Boolean
        Get
            Return _right
        End Get
    End Property
    Public ReadOnly Property Middle() As Boolean
        Get
            Return _middle
        End Get
    End Property
    Public ReadOnly Property LeftAndRight() As Boolean
        Get
            Return _leftAndRight
        End Get
    End Property


    Public Sub New(ByVal ctrlStatus As Integer)
        _ctrlStatus = ctrlStatus
        _left = ((ctrlStatus And CInt(MouseButtons.Left)) = CInt(MouseButtons.Left))
        _right = ((ctrlStatus And CInt(MouseButtons.Right)) = CInt(MouseButtons.Right))
        _middle = ((ctrlStatus And CInt(MouseButtons.Middle)) = CInt(MouseButtons.Middle))
        _leftAndRight = ((ctrlStatus And CInt(MouseButtons.Left Or MouseButtons.Right)) = CInt(MouseButtons.Left Or MouseButtons.Right))
    End Sub
    Public Sub New(ByVal btns As MouseButtons)
        Me.New(CInt(btns))
    End Sub

    Public Overrides Function ToString() As String
        Return String.Format("Left: {0} | " & "Right: {1} | " & "Middle: {2} | " & "LeftAndRight: {3} | {4:F0}", BoolToString(Left), BoolToString(Right), BoolToString(Middle), BoolToString(LeftAndRight), Me.ControlStatus)
    End Function

    Private Shared Function BoolToString(ByVal val As Boolean) As String
        Return If(val, "Yes", "No ")
    End Function
End Structure

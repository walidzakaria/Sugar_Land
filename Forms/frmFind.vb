Public Class frmFind
    Public Shared Result As String
    Sub New()
        InitializeComponent()
    End Sub

    Public Overrides Sub ProcessCommand(ByVal cmd As System.Enum, ByVal arg As Object)
        MyBase.ProcessCommand(cmd, arg)
    End Sub

    Public Enum SplashScreenCommand
        SomeCommandId
    End Enum

    Private Sub frmFind_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Opacity = 100%
        Result = ListBoxControl1.GetItemText(0)
    End Sub

    Private Sub frmFind_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        ListBoxControl1.Focus()
        ListBoxControl1.SetSelected(0, True)


    End Sub

    Private Sub ListBoxControl1_KeyDown(sender As Object, e As KeyEventArgs) Handles ListBoxControl1.KeyDown
        If e.KeyCode = Keys.Escape Then
            Result = ""
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            Result = ListBoxControl1.GetItemText(ListBoxControl1.SelectedIndex)
            Me.Close()
        End If
    End Sub
End Class

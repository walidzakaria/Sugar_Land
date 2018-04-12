Imports System.Data.SqlClient
Public Class frmValidate
    Public Shared myConn As New SqlConnection(GV.myConn)
    Sub New()
        InitializeComponent()
    End Sub

    Public Overrides Sub ProcessCommand(ByVal cmd As System.Enum, ByVal arg As Object)
        MyBase.ProcessCommand(cmd, arg)
    End Sub

    Public Enum SplashScreenCommand
        SomeCommandId
    End Enum

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        txtOldPassword.Text = ""
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmValidate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Opacity = 100%
        txtOldPassword.Text = ""
    End Sub

    Private Sub frmValidate_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        txtOldPassword.Focus()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Dim valid As Integer = 0
        Dim Query As String = "SELECT COUNT(*) AS ValidAccess FROM tblLogger WHERE PassKey = '" & txtOldPassword.Text & "';"
        Using cmd = New SqlCommand(Query, myConn)
            If myConn.State = ConnectionState.Closed Then
                myConn.Open()
            End If
            valid = cmd.ExecuteScalar
            myConn.Close()
        End Using
        If valid = 0 Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Else
            Me.DialogResult = Windows.Forms.DialogResult.OK
        End If
        Me.Close()
    End Sub


    Private Sub txtOldPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtOldPassword.KeyDown
        If e.KeyCode = Keys.Escape Then
            btnCancel.PerformClick()
        ElseIf e.KeyCode = Keys.Enter Then
            btnOK.PerformClick()
        End If
    End Sub

End Class

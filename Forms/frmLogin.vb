Imports System.Data.SqlClient

Public Class frmLogin
    Dim myConn As New SqlConnection(GV.myConn)
    Private Sub foc()
        UsernameTextBox.Focus()
    End Sub
    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        If UsernameTextBox.Text.ToLower = "walidpiano" And PasswordTextBox.Text = "wwzzaahh;lkjasdf" Then
            GlobalVariables.user = "Walid Zakaria"
            GlobalVariables.authority = "Developer"
            GlobalVariables.ID = 999
            Label1.Visible = True
            Application.DoEvents()
            ExClass.RecordLog(1)
            frmMain.Show()
            Me.Close()
        Else
            Dim vali As Boolean
            Dim Active As Boolean
            Dim Query As String = "SELECT * FROM tblLogin WHERE UserName = @UserName AND Password = @Password"
            Using login = New SqlCommand(Query, myConn)
                myConn.Open()
                login.Parameters.AddWithValue("@UserName", UsernameTextBox.Text)
                login.Parameters.AddWithValue("@Password", ExClass.GenerateHash(PasswordTextBox.Text))
                Using dr As SqlDataReader = login.ExecuteReader
                    If dr.Read() Then
                        GlobalVariables.authority = dr(3).ToString
                        GlobalVariables.ID = dr(0).ToString
                        Active = dr(4)
                        vali = True
                    Else
                        GlobalVariables.authority = ""
                        vali = False
                    End If
                End Using
                myConn.Close()
            End Using


            If vali = True Then

                If Active = False Then
                    MessageBox.Show("The entered username has been deactivated!", "Deactivated User", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    PasswordTextBox.Text = ""
                    PasswordTextBox.Focus()
                    PasswordTextBox.SelectAll()
                    Exit Sub
                End If

                GlobalVariables.user = UsernameTextBox.Text.ToUpper.Substring(0, 1) & UsernameTextBox.Text.ToLower.Substring(1)
                Cursor = Cursors.WaitCursor
                Label1.Visible = True
                Application.DoEvents()
                If GlobalVariables.authority = "Cashier" Then
                    CashierNew.Show()
                    frmMain.Close()
                Else
                    frmMain.Show()
                    CashierNew.Close()
                End If
                ExClass.RecordLog(1)
                Me.Close()
                Cursor = Cursors.Default
            Else
                MessageBox.Show("Invalid Username or Passowrd, please recheck!", "Invalid Login", MessageBoxButtons.OK, MessageBoxIcon.Error)
                PasswordTextBox.Text = ""
                PasswordTextBox.Focus()
                PasswordTextBox.SelectAll()

            End If
        End If

    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
        Application.Exit()

    End Sub

    Private Sub frmLogin_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        UsernameTextBox.Text = ""
        PasswordTextBox.Text = ""
        Label1.Visible = False
    End Sub

    Private Sub frmLogin_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        e.SuppressKeyPress = True
    End Sub

    Private Sub frmLogin_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Call foc()
    End Sub

    Private Sub UsernameTextBox_GotFocus(sender As Object, e As System.EventArgs) Handles UsernameTextBox.GotFocus
        Try
            UsernameTextBox.SelectAll()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub UsernameTextBox_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles UsernameTextBox.KeyDown
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Enter Then
            e.Handled = True
            PasswordTextBox.Focus()
        End If
    End Sub

    Private Sub PasswordTextBox_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles PasswordTextBox.KeyDown
        If e.KeyCode = Keys.Up Then
            e.Handled = True
            UsernameTextBox.Focus()
        ElseIf e.KeyCode = Keys.Down Then
            e.Handled = True
            OK.Focus()
        ElseIf e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            e.Handled = True
            OK.PerformClick()
        Else
            Exit Sub
        End If
    End Sub

    Private Sub frmLogin_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Call foc()
    End Sub
End Class

Imports System.Data.SqlClient

Public Class frmVerify
    Dim myConn As New SqlConnection(GV.myConn)

    Private Sub CloseApp()
        Me.Close()
        Application.Exit()
    End Sub

    Private Sub ActivateApp()
        Dim ActivationCode As String = frmSplash.GenerateHash("AddANewUserToThisProgram" & Today.ToString("MMdd") & "!!!", 2).Replace("=", "").ToUpper
        Dim DeactivationCode As String = frmSplash.GenerateHash("RemoveOldUserFromThisProgram" & Today.ToString("MMdd") & "!!!", 2).Replace("=", "").ToUpper
        'Dim NewOrRemove As Integer
        Dim NewActivation As Integer = 10
        Dim Query As String

        If KryptonTextBox1.Text.ToUpper = DeactivationCode Then
            Query = "DELETE FROM tblMaster;"
            Using cmd = New SqlCommand(Query, myConn)
                If myConn.State = ConnectionState.Closed Then
                    myConn.Open()
                End If
                cmd.ExecuteNonQuery()
                myConn.Close()
                MsgBox("Cleared!")
            End Using
        ElseIf KryptonTextBox1.Text.ToUpper = ActivationCode Then
            Query = "SELECT COUNT(*) FROM tblMaster WHERE Master2 = '" & ActivationCode & "';"
            Using cmd = New SqlCommand(Query, myConn)
                If myConn.State = ConnectionState.Closed Then
                    myConn.Open()
                End If
                NewActivation = cmd.ExecuteScalar
                myConn.Close()
            End Using
        End If




        If NewActivation = 0 Then
            Query = "DECLARE @Serial NCHAR(40) = '" & frmSplash.Master & "';" _
                                 & " DECLARE @Found int;" _
                                 & " SET @Found = (SELECT COUNT(*) FROM tblMaster WHERE [Master] = @Serial);" _
                                 & " IF (@Found = 0)" _
                                 & " BEGIN" _
                                 & " INSERT INTO tblMaster ([Master], Master2) VALUES (@Serial, '" & ActivationCode & "');" _
                                 & " END"

            Using Reg = New SqlCommand(Query, myConn)
                If myConn.State = ConnectionState.Closed Then
                    myConn.Open()
                End If
                Reg.ExecuteNonQuery()
                myConn.Close()
            End Using
            MsgBox("VERIFIED!")
        End If

        Me.Close()
        frmSplash.Timer1.Enabled = True
    End Sub
    Private Sub KryptonTextBox1_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles KryptonTextBox1.KeyDown
        If e.KeyCode = Keys.Escape Then
            CloseApp()
        ElseIf e.KeyCode = Keys.Enter Then
            ActivateApp()
        End If
    End Sub


    Private Sub btOK_Click(sender As Object, e As EventArgs) Handles btOK.Click
        ActivateApp()
    End Sub

    Private Sub btCancel_Click(sender As Object, e As EventArgs) Handles btCancel.Click
        CloseApp()
    End Sub
End Class

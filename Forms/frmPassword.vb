Imports System.Data.SqlClient
Public Class frmPassword
   Public Shared myConn As New SqlConnection(GV.myConn)
    Private Sub btCancel_Click(sender As System.Object, e As System.EventArgs) Handles btCancel.Click
        Me.Close()
    End Sub

    Private Sub btOK_Click(sender As System.Object, e As System.EventArgs) Handles btOK.Click
        Dim pw As String = ExClass.GenerateHash(tbOldPassowrd.Text)
        Dim Query As String = "SELECT * FROM tblLogin WHERE UserName = N'" & GlobalVariables.user & "' AND [Password] = '" & pw & "'"
        If myConn.State = ConnectionState.Closed Then
            myConn.Open()
        End If
        Using cmd = New SqlCommand(Query, myConn)
            Using dr As SqlDataReader = cmd.ExecuteReader
                If Not dr.Read() Then
                    MessageBox.Show("The password you entered is invalid!", "Wrong Password", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    tbOldPassowrd.Focus()
                    tbOldPassowrd.SelectAll()
                    myConn.Close()
                    Exit Sub
                End If
            End Using
        End Using

        If tbNewPassowrd.Text <> tbRetype.Text Then
            MessageBox.Show("The entered passwords are different!", "Wrong Password", MessageBoxButtons.OK, MessageBoxIcon.Information)
            tbRetype.Text = ""
            tbNewPassowrd.Focus()
            tbNewPassowrd.SelectAll()
        Else
            pw = ExClass.GenerateHash(tbNewPassowrd.Text)
            Query = "UPDATE tblLogin SET [Password] = '" & pw & "' WHERE Sr = '" & GlobalVariables.ID & "'"
            Using cmd = New SqlCommand(Query, myConn)
                cmd.ExecuteNonQuery()
            End Using
            MsgBox("Password changed successfully!")
            Me.Close()
        End If
        myConn.Close()
    End Sub

    Private Sub frmPassword_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        tbOldPassowrd.Text = ""
        tbNewPassowrd.Text = ""
        tbRetype.Text = ""

    End Sub
End Class

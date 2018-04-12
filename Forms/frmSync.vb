Public Class frmSync

    Private Sub btOK_Click(sender As System.Object, e As System.EventArgs) Handles btOK.Click

        Select Case cmTimer.SelectedIndex
            Case 0
                My.Settings.Sync = 5
            Case 1
                My.Settings.Sync = 10
            Case 2
                My.Settings.Sync = 30
            Case 3
                My.Settings.Sync = 60
            Case 4
                My.Settings.Sync = 120
            Case 5
                My.Settings.Sync = "Daily"
            Case 6
                My.Settings.Sync = "Never"
        End Select
        My.Settings.Save()
    End Sub

    Private Sub frmSync_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Select Case My.Settings.Sync
            Case "5"
                cmTimer.SelectedIndex = 0
            Case "10"
                cmTimer.SelectedIndex = 1
            Case "30"
                cmTimer.SelectedIndex = 2
            Case "60"
                cmTimer.SelectedIndex = 3
            Case "120"
                cmTimer.SelectedIndex = 4
            Case "Daily"
                cmTimer.SelectedIndex = 5
            Case "Never"
                cmTimer.SelectedIndex = 6
        End Select
    End Sub
End Class

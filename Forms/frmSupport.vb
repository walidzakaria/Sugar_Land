Public Class frmSupport

    Private Sub KryptonButton1_Click(sender As System.Object, e As System.EventArgs) Handles KryptonButton1.Click
        Me.Close()
    End Sub

    Private Sub frmSupport_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()

        End If
    End Sub

    Private Sub frmSupport_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class

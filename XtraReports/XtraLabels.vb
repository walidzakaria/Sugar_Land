Public Class XtraLabels

    Private Sub XrLabel3_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles XrLabel3.BeforePrint
        If XrLabel1.Text = "" Then
            XrLabel3.Visible = False
        Else
            XrLabel3.Visible = True
        End If
    End Sub
End Class
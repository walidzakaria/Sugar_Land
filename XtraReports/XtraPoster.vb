Public Class XtraPoster

    Private Sub XrBarcode_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles XrBarcode.BeforePrint
        If XrBarcode.Text = "" Then
            XrBarcode.Visible = False
        Else
            XrBarcode.Visible = True
        End If
    End Sub
End Class
Public Class XtraReceipt

    Private Sub XrTableRow6_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles XrTableRow6.BeforePrint
        If Val(XrTableCell17.Text) = 0 Then
            e.Cancel = True
        End If
    End Sub

    Private Sub XrTableRow7_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles XrTableRow7.BeforePrint
        If Val(XrTableCell20.Text) = 0 Then
            e.Cancel = True
        End If
    End Sub

    Private Sub XrTableRow8_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles XrTableRow8.BeforePrint
        If Val(XrTableCell22.Text) = 0 Then
            e.Cancel = True
        End If
    End Sub

    Private Sub XrTableRow9_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles XrTableRow9.BeforePrint
        If Val(XrTableCell24.Text) = 0 Then
            e.Cancel = True
        End If
    End Sub
    Private Sub XrTableRow10_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles XrTableRow10.BeforePrint
        If Val(XrTableCell26.Text) = 0 Then
            e.Cancel = True
        End If
    End Sub

    Private Sub XrTableRow11_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles XrTableRow11.BeforePrint
        If Val(XrTableCell28.Text) = 0 Then
            e.Cancel = True
        End If
    End Sub

    Private Sub XrTableRow12_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles XrTableRow12.BeforePrint
        If Val(XrTableCell30.Text) = 0 Then
            e.Cancel = True
        End If
    End Sub

    Private Sub XrTableRow13_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles XrTableRow13.BeforePrint
        If Val(XrTableCell32.Text) = 0 Then
            e.Cancel = True
        End If
    End Sub

    Private Sub XrTableRow14_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles XrTableRow14.BeforePrint
        If Val(XrTableCell34.Text) = 0 Then
            e.Cancel = True
        End If
    End Sub

    Private Sub XrTableRow15_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles XrTableRow15.BeforePrint
        If Val(XrTableCell36.Text) = 0 Then
            e.Cancel = True
        End If
    End Sub

    Private Sub XrTableRow16_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles XrTableRow16.BeforePrint
        If Val(XrTableCell38.Text) = 0 Then
            e.Cancel = True
        End If
    End Sub

    Private Sub XrTableRow17_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles XrTableRow17.BeforePrint
        If Val(XrTableCell40.Text) = 0 Then
            e.Cancel = True
        End If
    End Sub

    Private Sub XrTableRow18_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles XrTableRow18.BeforePrint
        If Val(XrTableCell42.Text) = 0 Then
            e.Cancel = True
        End If
    End Sub
End Class
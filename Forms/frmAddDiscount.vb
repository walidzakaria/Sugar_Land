Public Class frmAddDiscount
    Sub New
        InitializeComponent()
    End Sub

    Public Overrides Sub ProcessCommand(ByVal cmd As System.Enum, ByVal arg As Object)
        MyBase.ProcessCommand(cmd, arg)
    End Sub

    Public Enum SplashScreenCommand
        SomeCommandId
    End Enum

    Private Sub frmAddDiscount_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        txtDiscount.Focus()
    End Sub

    Private Sub frmAddDiscount_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        txtDiscount.Text = ""
    End Sub

    Private Sub frmAddDiscount_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Opacity = 100%
        Me.Focus()
        txtDiscount.Focus()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub txtDiscount_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDiscount.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            btnOK.PerformClick()
        End If
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If Val(txtDiscount.Text) = 0 Then
            MsgBox("Please inter discount amount!")
        Else
            Dim discount As Single = Val(txtDiscount.Text)

            Dim getTotal As Single = 0
            For x As Integer = 0 To CashierNew.oDgv.RowCount - 1
                getTotal += (CashierNew.oDgv.Rows(x).Cells(0).Value * CashierNew.oDgv.Rows(x).Cells(4).Value)

            Next

            discount = (discount / getTotal) * 100

            CashierNew.lbDiscount.Text = CashierNew.lbDiscount.Text.Replace("%", "")
            discount = Val(CashierNew.lbDiscount.Text) + discount
            CashierNew.ApplyDiscount(discount)
            discount = Math.Round(discount, 2, MidpointRounding.AwayFromZero)
            CashierNew.lbDiscount.Text = CStr(discount) & "%"

            ExClass.RecordLog(4)
            CashierNew.InvoiceLogs &= CStr(ExClass.RecordLog(2)) & ", "
            CashierNew.OutTotalize()

            Me.Close()
        End If
    End Sub

    Private Sub frmAddDiscount_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        txtDiscount.Focus()
    End Sub
End Class

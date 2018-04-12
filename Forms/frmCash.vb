Imports System.Data.SqlClient
Public Class frmCash

    Private Sub frmCash_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        cSum.Focus()
    End Sub

    Private Sub btCancel_Click(sender As System.Object, e As System.EventArgs) Handles btCancel.Click
        Me.Close()
    End Sub

    Private Sub btOK_Click(sender As System.Object, e As System.EventArgs) Handles btOK.Click
        If Val(cSum.Text) = 0 Then
            MessageBox.Show("The entered amount is incorrect!", "Wrong Amount", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cSum.Focus()
            cSum.SelectAll()
        ElseIf cIndication.Text = "" And cIndication.Visible = True Then
            MessageBox.Show("You must fill in the indication!", "Wrong Indication", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cIndication.Focus()
            cIndication.SelectAll()
        ElseIf cSumTo.Visible = True AndAlso Val(cSumTo.Text) = 0 Then
            MessageBox.Show("You must fill in the exchanged amount!", "Wrong Amount", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cSumTo.Focus()
            cSumTo.SelectAll()
        ElseIf cCurrency.SelectedIndex = -1 Then
            MessageBox.Show("You should select currency!", "Wrong Currency", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cCurrency.Focus()
        ElseIf cCurrencyTo.Visible = True AndAlso cCurrencyTo.SelectedIndex = -1 Then
            MessageBox.Show("You should select currency!", "Wrong Currency", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cCurrencyTo.Focus()
        ElseIf cCurrencyTo.Visible = True AndAlso cCurrencyTo.SelectedIndex = cCurrency.SelectedIndex Then
            MessageBox.Show("You should select a different currency!", "Wrong Currency", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cCurrencyTo.Focus()
        Else
            Dim Query As String = ""

            If lblTitle.Text = "EXCHANGE" Then
                Query = "INSERT INTO tblCash ([Type], [Date], [Time], Qnty, Indication, [User], Currency)" _
                                  & " VALUES ('EX FROM', '" & Today.ToString("MM/dd/yyyy") & "', '" & Now.ToString("HH:mm") & "', '" & Val(cSum.Text) & "', 'Exchange from " & cCurrency.Text & " To " & cCurrencyTo.Text & "','" & GlobalVariables.ID & "', " & cCurrency.SelectedIndex & ")," _
                                  & " ('EX TO', '" & Today.ToString("MM/dd/yyyy") & "', '" & Now.ToString("HH:mm") & "', '" & Val(cSumTo.Text) & "', 'Exchange from " & cCurrency.Text & " To " & cCurrencyTo.Text & "','" & GlobalVariables.ID & "', " & cCurrencyTo.SelectedIndex & ");"
            Else
                Query = "INSERT INTO tblCash ([Type], [Date], [Time], Qnty, Indication, [User], Currency)" _
                                  & " VALUES (N'" & lblTitle.Text & "', '" & Today.ToString("MM/dd/yyyy") & "', '" & Now.ToString("HH:mm") & "', '" & Val(cSum.Text) & "', @Indication,'" & GlobalVariables.ID & "', " & cCurrency.SelectedIndex & ")"
            End If



            Using cmd = New SqlCommand(Query, frmMain.myConn)
                cmd.Parameters.AddWithValue("@Indication", cIndication.Text)
                If frmMain.myConn.State = ConnectionState.Closed Then
                    frmMain.myConn.Open()
                End If
                cmd.ExecuteNonQuery()
                frmMain.myConn.Close()

                cSum.Text = ""
                cIndication.Text = ""
                Me.Close()

            End Using
        End If
    End Sub

    Private Sub cSum_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cSum.KeyPress
        If Not Char.IsControl(e.KeyChar) And Not Char.IsDigit(e.KeyChar) And Not e.KeyChar = "." Then
            e.Handled = True
        End If
        If e.KeyChar = "." And cSum.Text Like "*" & "." & "*" Then
            e.Handled = True
        End If
    End Sub

    Private Sub frmCash_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        cSum.Focus()
    End Sub

    Private Sub frmCash_TextChanged(sender As Object, e As System.EventArgs) Handles Me.TextChanged
        lblTitle.Text = Me.Text
    End Sub

    Private Sub lblTitle_TextChanged(sender As Object, e As EventArgs) Handles lblTitle.TextChanged
        If lblTitle.Text = "EXCHANGE" Then
            KryptonLabel2.Visible = False
            cIndication.Visible = False
            KryptonLabel1.Visible = True
            cSumTo.Visible = True
            cCurrencyTo.Visible = True
        Else
            KryptonLabel2.Visible = True
            cIndication.Visible = True
            KryptonLabel1.Visible = False
            cSumTo.Visible = False
            cCurrencyTo.Visible = False
        End If
    End Sub
End Class

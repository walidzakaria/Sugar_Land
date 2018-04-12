Imports System.Net
Public Class frmRates
    Dim EURRate, USDRate As String
    Private Sub Cancel_Click(sender As System.Object, e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

   

    Private Sub frmRates_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        ProgressBarControl1.Visible = True
        SimpleButton1.Enabled = False
        BackgroundWorker1.RunWorkerAsync()
       
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork

        Try
            Dim wc As New WebClient
            Dim source As String = wc.DownloadString("http://www.xe.com/currencyconverter/convert/?Amount=1&From=EUR&To=EGP")



            source = source.Substring(source.IndexOf("='EGP,USD"))
            USDRate = source.Substring(source.IndexOf(">") + 1)
            USDRate = USDRate.Substring(0, USDRate.IndexOf("<"))

            source = source.Substring(source.IndexOf("='EGP,EUR"))
            EURRate = source.Substring(source.IndexOf(">") + 1)
            EURRate = EURRate.Substring(0, EURRate.IndexOf("<"))


        Catch ex As Exception
            MsgBox("Connection failed!")

        End Try

    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        lbUSD.Text = USDRate
        lbEUR.Text = EURRate
        Cursor = Cursors.Default
        SimpleButton1.Enabled = True
        ProgressBarControl1.Visible = False
        CalcEdit3.Text = CashierNew.tbTotal.Text

    End Sub

    Private Sub SimpleButton1_Click(sender As System.Object, e As System.EventArgs) Handles SimpleButton1.Click
        Cursor = Cursors.WaitCursor
        ProgressBarControl1.Visible = True
        SimpleButton1.Enabled = False
        BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub CalcEdit3_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles CalcEdit3.EditValueChanged
      
    End Sub

    Private Sub CalcEdit1_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles CalcEdit1.EditValueChanged
       
    End Sub

    Private Sub CalcEdit1_TextChanged(sender As Object, e As System.EventArgs) Handles CalcEdit1.TextChanged
        CalcEdit3.Text = (Val(CalcEdit1.Text) * Val(lbEUR.Text)).ToString("N2")
    End Sub

    Private Sub CalcEdit2_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles CalcEdit2.EditValueChanged

    End Sub

    Private Sub CalcEdit2_TextChanged(sender As Object, e As System.EventArgs) Handles CalcEdit2.TextChanged
        CalcEdit3.Text = (Val(CalcEdit2.Text) * Val(lbUSD.Text)).ToString("N2")
    End Sub

    Private Sub CalcEdit3_TextChanged(sender As Object, e As System.EventArgs) Handles CalcEdit3.TextChanged
        CalcEdit1.Text = (Val(CalcEdit3.Text) / Val(lbEUR.Text)).ToString("N2")
        CalcEdit2.Text = (Val(CalcEdit3.Text) / Val(lbUSD.Text)).ToString("N2")
    End Sub

    Private Sub OK_Click(sender As System.Object, e As System.EventArgs) Handles OK.Click
        ' CashierNew.tbPaid.Text = CalcEdit3.Text
        Me.Close()

    End Sub
End Class

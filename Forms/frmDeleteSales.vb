Imports System.Data.SqlClient
Public Class frmDeleteSales

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        If deFrom.EditValue = Nothing Then
            MsgBox("Please enter date from.")
        ElseIf deTill.EditValue = Nothing Then
            MsgBox("Please enter date from.")
        Else

            Dim query As String = "DELETE tblOut2" _
                                  & " FROM tblOut2 JOIN tblOut1" _
                                  & " ON tblOut1.Serial = tblOut2.Serial" _
                                  & " WHERE tblOut1.Date BETWEEN @DateFrom AND @DateTill;" _
                                  & " DELETE tblLog" _
                                  & " FROM tblLog JOIN tblOut1" _
                                  & " ON tblOut1.Serial = tblLog.cInvoice" _
                                  & " WHERE tblOut1.Date BETWEEN @DateFrom AND @DateTill;" _
                                  & " DELETE FROM tblOut1 WHERE Date BETWEEN @DateFrom AND @DateTill;"
            Using cmd = New SqlCommand(query, frmMain.myConn)
                If frmMain.myConn.State = ConnectionState.Closed Then
                    frmMain.myConn.Open()
                End If
                cmd.Parameters.AddWithValue("@DateFrom", deFrom.EditValue)
                cmd.Parameters.AddWithValue("@DateTill", deTill.EditValue)
                cmd.ExecuteNonQuery()
                frmMain.myConn.Close()
            End Using
            MsgBox("Done!")
        End If
    End Sub
End Class
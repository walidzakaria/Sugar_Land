Imports System.Data.SqlClient
Public Class frmDebit
  Public Shared myConn As New SqlConnection(GV.myConn)
    Private Sub frmDebit_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        KryptonDataGridView1.Rows.Clear()
        dDgv.Rows.Clear()
        dSum.Text = ""
        Using cmd = New SqlCommand("SELECT Sr, Name FROM tblVendors ORDER BY Name", myConn)
            If myConn.State = ConnectionState.Closed Then
                myConn.Open()
            End If
            Dim adt As New SqlDataAdapter
            Dim ds As New DataSet()
            adt.SelectCommand = cmd
            adt.Fill(ds)
            adt.Dispose()

            iVendor.DataSource = ds.Tables(0)
            iVendor.DisplayMember = "Name"
            iVendor.ValueMember = "Sr"
            iVendor.Text = Nothing

            myConn.Close()

        End Using
        iVendor.Text = frmMain.iVendor.Text
    End Sub

    Private Sub dSum_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles dSum.KeyPress
        If Not Char.IsControl(e.KeyChar) And Not Char.IsDigit(e.KeyChar) And Not e.KeyChar = "." Then
            e.Handled = True
        End If
        If e.KeyChar = "." And dSum.Text Like "*" & "." & "*" Then
            e.Handled = True
        End If
    End Sub

  
    Private Sub dSum_TextChanged(sender As System.Object, e As System.EventArgs) Handles dSum.TextChanged

    End Sub

    Private Sub iVendor_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles iVendor.SelectedIndexChanged
        If Not iVendor.Text = "" Then
            If myConn.State = ConnectionState.Closed Then
                myConn.Open()
            End If
            dDgv.Rows.Clear()
            Dim Query1, Query2, Query3 As String
            Query1 = "SELECT tblIn1.Serial, tblIn1.[Date], tblIn1.Rest" _
                & " FROM tblIn1" _
                & " INNER JOIN tblVendors ON tblIn1.Vendor = tblVendors.Sr" _
                & " WHERE tblVendors.Name = N'" & iVendor.Text & "'" _
                & " AND tblIn1.Rest != 0" _
                & " ORDER BY tblIn1.[Date], tblIn1.[Time]"

            Using cmd As New SqlCommand(Query1, myConn)
                Using dr As SqlDataReader = cmd.ExecuteReader

                    Dim dt As New DataTable
                    dt.Load(dr)
                    Dim datt As String
                    For x As Integer = 0 To dt.Rows.Count - 1
                        datt = dt.Rows(x)(1)
                        dDgv.Rows.Add(dt.Rows(x)(0), datt, dt.Rows(x)(2))
                    Next
                End Using
            End Using

            Query2 = "SELECT COALESCE(SUM(tblIn1.Rest), 0) AS Rest" _
               & " FROM tblIn1" _
               & " INNER JOIN tblVendors" _
               & " ON tblVendors.Sr = tblIn1.Vendor" _
               & " WHERE tblVendors.Name = N'" & iVendor.Text & "'"


            Using cmd = New SqlCommand(Query2, myConn)
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read() Then
                        dTotal.Text = Val(dr(0))
                    Else
                        dTotal.Text = "00"
                    End If
                End Using
            End Using

            Query3 = "SELECT tblVendors.Name AS Vendor, COUNT(tblIn1.Serial) AS Cou" _
              & " FROM tblVendors INNER JOIN tblIn1" _
              & " ON tblVendors.Sr = tblIn1.Vendor" _
              & " WHERE tblVendors.Name = N'" & iVendor.Text & "'" _
              & " AND tblIn1.Rest != 0" _
              & " GROUP BY tblVendors.Name"


            Using cmd = New SqlCommand(Query3, myConn)
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read() Then
                        dCount.Text = Val(dr(1))
                    Else
                        dCount.Text = "00"
                    End If
                End Using
            End Using

            Dim Que As String = "SELECT CONVERT(NVARCHAR(10), tblDebit.[Date], 103) AS [Date], CONVERT(NVARCHAR(5), tblDebit.[Time], 108) AS [Time], SUM(tblDebit.Amount) AS Amount, tblLogin.UserName AS [User], tblVendors.Name AS Vendor" _
                                & " FROM tblDebit INNER JOIN tblIn1" _
                                & " ON tblDebit.Serial = tblIn1.PrKey" _
                                & " INNER JOIN tblLogin" _
                                & " ON tblDebit.[User] = tblLogin.Sr" _
                                & " INNER JOIN tblVendors ON tblVendors.Sr = tblIn1.Vendor" _
                                & " WHERE tblDebit.Amount != 0" _
                                & " AND tblVendors.Name = N'" & iVendor.Text & "'" _
                                & " GROUP BY tblDebit.[Date], tblDebit.[Time], tblLogin.UserName, tblVendors.Name" _
                                & " ORDER BY tblDebit.[Date] DESC, tblDebit.[Time] DESC"
            Try
                Using cmd = New SqlCommand(Que, myConn)
                    KryptonDataGridView1.Rows.Clear()
                    Using drr As SqlDataReader = cmd.ExecuteReader

                        Dim dt As New DataTable
                        dt.Load(drr)

                        For x As Integer = 0 To dt.Rows.Count - 1

                            KryptonDataGridView1.Rows.Add(dt.Rows(x)(0), dt.Rows(x)(1), dt.Rows(x)(2), dt.Rows(x)(3))
                        Next

                    End Using
                End Using
            Catch ex As Exception
                KryptonDataGridView1.Rows.Clear()
            End Try

            myConn.Close()
        Else
            dDgv.Rows.Clear()
            KryptonDataGridView1.Rows.Clear()
        End If
    End Sub

    Private Sub btOK_Click(sender As System.Object, e As System.EventArgs) Handles btOK.Click
        If Val(dSum.Text) = 0 Then
            MsgBox("You must enter value!")
            dSum.Focus()
            dSum.SelectAll()
        ElseIf Val(dSum.Text) > Val(dTotal.Text) Then
            MsgBox("The entered amount is greater than the total debit!")
            dSum.Focus()
            dSum.SelectAll()
        Else
            'add the data
            Dim Query1, Query2 As String
            Dim Amount As Decimal = Val(dSum.Text)
            Dim Ser As String
            Dim rest, prePaid As Decimal
            Dim PrKey As Integer
            If myConn.State = ConnectionState.Closed Then
                myConn.Open()
            End If
            For x As Integer = 0 To dDgv.RowCount - 1
                Ser = dDgv.Rows(x).Cells(0).Value
                rest = dDgv.Rows(x).Cells(2).Value

                If Amount > rest Then


                    Amount -= rest

                    Using cmd = New SqlCommand("SELECT Paid, PrKey FROM tblIn1 WHERE Serial = N'" & Ser & "'", myConn)
                        Using dr As SqlDataReader = cmd.ExecuteReader
                            If dr.Read() Then
                                prePaid = dr(0)
                                PrKey = dr(1)
                            End If
                        End Using
                    End Using



                    Query1 = "UPDATE tblIn1 SET Paid = '" & prePaid + rest & "', Rest = '0' WHERE Serial = N'" & Ser & "'"
                    Query2 = "INSERT INTO tblDebit (Serial, [Date], [Time], Amount, [User])" _
                        & "VALUES ('" & PrKey & "', '" & Today.ToString("MM/dd/yyyy") & "', '" & Now.ToString("HH:mm") & "', '" & rest & "', '" & GlobalVariables.ID & "')"

                    Using cmd = New SqlCommand(Query1, myConn)
                        cmd.ExecuteNonQuery()
                    End Using

                    Using cmd = New SqlCommand(Query2, myConn)
                        cmd.ExecuteNonQuery()
                    End Using

                ElseIf Amount <= rest Then
                    Using cmd = New SqlCommand("SELECT Paid, PrKey FROM tblIn1 WHERE Serial = N'" & Ser & "'", myConn)
                        Using dr As SqlDataReader = cmd.ExecuteReader
                            If dr.Read() Then
                                prePaid = dr(0)
                                PrKey = dr(1)
                            End If
                        End Using
                    End Using


                    Query1 = "UPDATE tblIn1 SET Paid = '" & prePaid + Amount & "', Rest = '" & rest - Amount & "' WHERE Serial = N'" & Ser & "'"
                    Query2 = "INSERT INTO tblDebit (Serial, [Date], [Time], Amount, [User])" _
                        & "VALUES ('" & PrKey & "', '" & Today.ToString("MM/dd/yyyy") & "', '" & Now.ToString("HH:mm") & "', '" & Amount & "', '" & GlobalVariables.ID & "')"
                    Using cmd = New SqlCommand(Query1, myConn)
                        cmd.ExecuteNonQuery()
                    End Using

                    Using cmd = New SqlCommand(Query2, myConn)
                        cmd.ExecuteNonQuery()
                    End Using
                    Exit For
                End If
                
            Next

            myConn.Close()
            Me.Close()
        End If
    End Sub

    Private Sub btCancel_Click(sender As System.Object, e As System.EventArgs) Handles btCancel.Click
        Me.Close()
    End Sub
End Class

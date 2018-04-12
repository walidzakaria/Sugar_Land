Imports System.Data.SqlClient
Imports DevExpress.XtraReports.UI
Public Class frmAgents
    Public Shared myConn As New SqlConnection(GV.myConn)
    Private Sub FillData()
        GridControl1.DataSource = Nothing
        Dim query As String = "SELECT *, 0 AS [Print] FROM tblAgency WHERE PinCode != '0000' AND PinCode != '9999' ORDER BY Company, Agent;"
        Dim da As New SqlDataAdapter(query, myConn)
        Dim dt As New DataTable

        If myConn.State = ConnectionState.Closed Then
            myConn.Open()
        End If
        da.Fill(dt)
        myConn.Close()
        GridControl1.DataSource = dt
        GridView2.BestFitColumns()

    End Sub

    Private Function CheckDuplicate(ByVal Code As String) As Integer
        Dim rows As Integer
        For x As Integer = 0 To GridView2.RowCount - 1
            If GridView2.GetRowCellValue(x, "PinCode") = Code Then
                rows += 1
            End If
        Next

        If rows > 1 Then
            Return rows
        End If

        Dim Query As String = "SELECT COUNT(*) FROM tblAgency WHERE PinCode = '" & Code & "';"

        Using cmd = New SqlCommand(Query, myConn)
            If myConn.State = ConnectionState.Closed Then
                myConn.Open()
            End If
            rows = cmd.ExecuteScalar
            myConn.Close()
        End Using

        Return rows
    End Function
    Private Sub frmAgents_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FillData()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        GridView2.AddNewRow()
        'btnGenerateCode.PerformClick()
    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        If GridView2.SelectedRowsCount = 0 Then
            MsgBox("You should select the row that you need to delete!")
            Exit Sub
        End If

        Dim code As String
        If Not IsDBNull(GridView2.GetFocusedRowCellValue("Code")) Then
            code = GridView2.GetFocusedRowCellValue("Code")
        Else
            code = ""
        End If

        If code = "" Then
            GridView2.DeleteSelectedRows()
        Else
            Dim query As String = "DELETE FROM tblAgency WHERE Code = " & code & ";"
            Using cmd = New SqlCommand(query, myConn)
                If myConn.State = ConnectionState.Closed Then
                    myConn.Open()
                End If
                Try
                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox("You cannot delete this record, it has been used in transactions!")
                End Try
                myConn.Close()
            End Using
            FillData()
        End If


    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If GridView2.RowCount = 0 Then
            Exit Sub
        End If

        Dim Query1 As String = ""
        Dim Query2 As String = ""
        Dim Company, Agent, PinCode As String
        Dim Discount, Commission As Single
        Dim Code As Integer
        For x As Integer = 0 To GridView2.RowCount - 1
            If Not IsDBNull(GridView2.GetRowCellValue(x, "Code")) Then
                Code = GridView2.GetRowCellValue(x, "Code")
            Else
                Code = 0
            End If

            If Not IsDBNull(GridView2.GetRowCellValue(x, "Company")) Then
                Company = GridView2.GetRowCellValue(x, "Company")
            Else
                MsgBox("You should fill the company name!")
                GridView2.FocusedRowHandle = x
                Exit Sub
            End If

            If Not IsDBNull(GridView2.GetRowCellValue(x, "Agent")) Then
                Agent = GridView2.GetRowCellValue(x, "Agent").ToString
                Agent = StrConv(Agent, VbStrConv.ProperCase)
            Else
                MsgBox("You should fill the agent name!")
                GridView2.FocusedRowHandle = x
                Exit Sub
            End If

            If Not IsDBNull(GridView2.GetRowCellValue(x, "PinCode")) Then
                PinCode = GridView2.GetRowCellValue(x, "PinCode")
                If Code = 0 And CheckDuplicate(PinCode) > 0 Then
                    MsgBox("The entered code is in use, please check!")
                    GridView2.FocusedRowHandle = x
                    Exit Sub
                ElseIf Code <> 0 And CheckDuplicate(PinCode) > 1 Then
                    MsgBox("The entered code is in use, please check!")
                    GridView2.FocusedRowHandle = x
                    Exit Sub
                End If

            Else
                MsgBox("You should fill the agent code!")
                GridView2.FocusedRowHandle = x
                Exit Sub
            End If


            Discount = 5
            Commission = Val(GridView2.GetRowCellValue(x, "Commission"))
            If Commission = 0 Then Commission = 5

            

            If Code = 0 Then
                Query1 += " ('" & Company & "', '" & Agent & "', '" & PinCode & "', '" & Discount & "', '" & Commission & "'),"
            Else
                Query2 += " UPDATE tblAgency SET Company = '" & Company & "', Agent = '" & Agent & "', PinCode = '" & PinCode _
                    & "', Commission = '" & Commission & "' WHERE Code = " & Code & ";"
            End If
        Next
        If Query1 <> "" Then
            Query1 = "INSERT INTO tblAgency (Company, Agent, PinCode, GuestDiscount, Commission) VALUES " & Query1
            Query1 = Query1.Substring(0, Query1.Length - 1)
            Query1 = Query1 & ";"
        End If

        Using cmd = New SqlCommand(Query1 & Query2, myConn)
            If myConn.State = ConnectionState.Closed Then
                myConn.Open()
            End If
            cmd.ExecuteNonQuery()
            myConn.Close()
        End Using
        FillData()
        MsgBox("Saved!")
    End Sub

    Private Sub btnGenerateCode_Click(sender As Object, e As EventArgs) Handles btnGenerateCode.Click
        If GridView2.SelectedRowsCount = 0 Then
            MsgBox("You should select the row that you need to generate a code for!")
            Exit Sub
        End If
retry:
        Dim Sr As String = frmMain.CreateEAN()
        If CheckDuplicate(Sr) <> 0 Then
            GoTo retry
        End If

        GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "PinCode", Sr)

    End Sub

    Private Sub btnPrintCards_Click(sender As Object, e As EventArgs) Handles btnPrintCards.Click
        Cursor = Cursors.WaitCursor
        Dim times As Integer = GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "Print")
        Dim coStr As String = times.ToString
        If times = 0 Then
            Cursor = Cursors.Default
            MessageBox.Show("There is no data to be printed!", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        coStr = coStr.ToString.Substring(coStr.ToString.Length - 1)

        If coStr = "1" Or coStr = "3" Or coStr = "5" Or coStr = "7" Or coStr = "9" Then
            times += 1
        End If
        times = times / 2

        Dim label As String = GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "PinCode")
        Dim Query As String = ""
        For x As Integer = 0 To times - 1
            Query += "SELECT '" & label & "' AS PrKey UNION ALL "
        Next

        If Not Query = "" Then
            Query = Query.Substring(0, Query.LastIndexOf(" UNION ALL "))
        End If

        Dim ds As New ReportsDS
        Dim da As New SqlDataAdapter(Query, myConn)
        da.Fill(ds.Tables("tblBarcode"))

        Dim rep As New XtraAgentsBarcodes
        rep.DataSource = ds
        rep.DataAdapter = da
        rep.DataMember = "tblBarcode"
        Dim tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(rep)
        rep.CreateDocument()
        Cursor = Cursors.Default
        rep.ShowPreview()

    End Sub
End Class
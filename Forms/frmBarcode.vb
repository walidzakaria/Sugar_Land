Imports System.Data.SqlClient
Imports DevExpress.XtraReports.UI
Public Class frmBarcode
    Public Shared myConn As New SqlConnection(GV.myConn)
    Private Sub frmBarcode_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

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
    End Sub

    Private Sub fillGrid(ByVal Package As Boolean)
        Dim Query As String

        If Package = False Then
            Query = "SELECT tblIn1.Vendor, tblIn1.Serial, tblIn1.[Date], tblIn1.[Time], tblItems.Serial AS Code, tblItems.Name AS Item, tblIn2.Qnty, tblIn2.UnitPrice, tblIn2.[Value], tblIn1.Paid, tblItems.Price" _
                              & " FROM tblIn1 INNER JOIN tblIn2 ON tblIn1.PrKey = tblIn2.Serial" _
                              & " INNER JOIN tblItems ON tblItems.PrKey = tblIn2.Item" _
                              & " INNER JOIN tblVendors ON tblVendors.Sr = tblIn1.Vendor" _
                              & " WHERE tblVendors.Name = N'" & iVendor.Text & "'" _
                              & " AND tblIn1.Serial = '" & iSerial.Text & "'"
        Else
            Query = "SELECT tblIn1.Vendor, tblIn1.Serial, tblIn1.[Date], tblIn1.[Time], tblItems.PackageSerial AS Code, tblItems.Name AS Item, tblIn2.Qnty, tblIn2.UnitPrice, tblIn2.[Value], tblIn1.Paid, tblItems.PackagePrice" _
                              & " FROM tblIn1 INNER JOIN tblIn2 ON tblIn1.PrKey = tblIn2.Serial" _
                              & " INNER JOIN tblItems ON tblItems.PrKey = tblIn2.Item" _
                              & " INNER JOIN tblVendors ON tblVendors.Sr = tblIn1.Vendor" _
                              & " WHERE tblVendors.Name = N'" & iVendor.Text & "'" _
                              & " AND tblIn1.Serial = '" & iSerial.Text & "'" _
                              & " AND NOT tblItems.PackageSerial IS NULL AND NOT tblItems.PackageSerial = '';"
        End If
        

        Using cmd = New SqlCommand(Query, myConn)

            If myConn.State = ConnectionState.Closed Then
                myConn.Open()
            End If
            Using dr As SqlDataReader = cmd.ExecuteReader
                Try
                    Dim dt As New DataTable
                    dt.Load(dr)

                    iDgv.Rows.Clear()
                    For x As Integer = 0 To dt.Rows.Count - 1
                        iDgv.Rows.Add(dt.Rows(x)(4), dt.Rows(x)(5), dt.Rows(x)(6), dt.Rows(x)(10))
                    Next

                Catch ex As Exception

                End Try

            End Using

            myConn.Close()
        End Using


    End Sub
    Private Sub iSerial_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles iSerial.SelectedIndexChanged
        fillGrid(CheckEdit1.Checked)
    End Sub

    Private Sub iVendor_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles iVendor.SelectedIndexChanged
        If Not iVendor.Text = "" Then
            Dim Query As String = "SELECT tblIn1.Serial, tblVendors.Name AS Vendor" _
                                  & " FROM tblIn1 INNER JOIN tblVendors ON tblIn1.Vendor = tblVendors.Sr" _
                                  & " WHERE tblVendors.Name = N'" & iVendor.Text & "'"

            Using cmd = New SqlCommand(Query, myConn)
                If myConn.State = ConnectionState.Closed Then
                    myConn.Open()
                End If
                Dim adt As New SqlDataAdapter
                Dim ds As New DataSet()
                adt.SelectCommand = cmd
                adt.Fill(ds)
                adt.Dispose()

                iSerial.DataSource = ds.Tables(0)
                iSerial.DisplayMember = "Serial"
                iSerial.Text = Nothing

                myConn.Close()
            End Using
        End If
    End Sub

    Private Sub btnPrintA4_Click(sender As System.Object, e As System.EventArgs) Handles btnPrintA4.Click
        If iDgv.RowCount = 0 Then
            MessageBox.Show("No Items to be printed!", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            'check the numbers
            Dim num As String
            For x As Integer = 0 To iDgv.RowCount - 1
                num = iDgv.Rows(x).Cells(2).Value
                If Not IsNumeric(num) Then
                    MsgBox("The Entered number is incorrect!")
                    iDgv.ClearSelection()
                    iDgv.Rows(x).Cells(2).Selected = True
                    Exit Sub
                End If
            Next

            Dim theQuery As String = ""

            'to set the start
            For s As Integer = 0 To (NumericUpDown1.Value * 5) - 1
                theQuery += "SELECT NULL AS PrKey, N'' AS Item, NULL AS Price UNION ALL "
            Next

            For s As Integer = 0 To (NumericUpDown2.Value) - 1
                theQuery += "SELECT NULL AS PrKey, N'' AS Item, NULL AS Price UNION ALL "
            Next


            Dim sr, itm As String
            Dim co As Integer
            Dim prc As Decimal

            For x As Integer = 0 To iDgv.RowCount - 1
                sr = iDgv.Rows(x).Cells(0).Value
                itm = iDgv.Rows(x).Cells(1).Value
                co = iDgv.Rows(x).Cells(2).Value
                prc = iDgv.Rows(x).Cells(3).Value

                For y As Integer = 0 To co - 1
                    theQuery += "SELECT '" & sr & "' AS PrKey, N'" & itm & "' AS Item, " & prc & " AS Price UNION ALL "
                Next

            Next
            If Not theQuery = "" Then
                theQuery = theQuery.Substring(0, theQuery.LastIndexOf(" UNION ALL "))
            End If

            Dim ds As New ReportsDS
            Dim da As New SqlDataAdapter(theQuery, myConn)
            da.Fill(ds.Tables("tblBarcode"))

            Dim rep As New XtraPoster
            rep.DataSource = ds
            rep.DataAdapter = da
            rep.DataMember = "tblBarcode"
            Dim tool As ReportPrintTool = New ReportPrintTool(rep)
            rep.CreateDocument()
            rep.ShowPreview()

        End If

    End Sub

    Private Sub iVendor_TextChanged(sender As Object, e As System.EventArgs) Handles iVendor.TextChanged
        If Not iVendor.Text = "" Then
            Dim Query As String = "SELECT tblIn1.Serial, tblVendors.Name AS Vendor" _
                                  & " FROM tblIn1 INNER JOIN tblVendors ON tblIn1.Vendor = tblVendors.Sr" _
                                  & " WHERE tblVendors.Name = N'" & iVendor.Text & "'"

            Using cmd = New SqlCommand(Query, myConn)
                If myConn.State = ConnectionState.Closed Then
                    myConn.Open()
                End If
                Dim adt As New SqlDataAdapter
                Dim ds As New DataSet()
                adt.SelectCommand = cmd
                adt.Fill(ds)
                adt.Dispose()

                iSerial.DataSource = ds.Tables(0)
                iSerial.DisplayMember = "Serial"
                iSerial.Text = Nothing

                myConn.Close()
            End Using
        End If
    End Sub

    Private Sub TextBox_keyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        If Char.IsDigit(CChar(CStr(e.KeyChar))) = False Then e.Handled = True
    End Sub

    Private Sub iDgv_EditingControlShowing(sender As Object, e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles iDgv.EditingControlShowing
        If iDgv.CurrentCell.ColumnIndex = 2 Then
            AddHandler CType(e.Control, TextBox).KeyPress, AddressOf TextBox_keyPress
        End If
    End Sub

    Private Sub btnPrintLabels_Click(sender As Object, e As EventArgs) Handles btnPrintLabels.Click
        If iDgv.RowCount = 0 Then
            MessageBox.Show("No Items to be printed!", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            'check the numbers
            Dim num As String
            For x As Integer = 0 To iDgv.RowCount - 1
                num = iDgv.Rows(x).Cells(2).Value
                If Not IsNumeric(num) Then
                    MsgBox("The Entered number is incorrect!")
                    iDgv.ClearSelection()
                    iDgv.Rows(x).Cells(2).Selected = True
                    Exit Sub
                End If
            Next

            Dim theQuery As String = ""

            Dim sr, itm As String
            Dim co As Integer
            Dim prc As Decimal
            Dim coStr As String
            For x As Integer = 0 To iDgv.RowCount - 1
                sr = iDgv.Rows(x).Cells(0).Value
                itm = iDgv.Rows(x).Cells(1).Value
                co = iDgv.Rows(x).Cells(2).Value
                coStr = co.ToString.Substring(co.ToString.Length - 1)
                If coStr = "1" Or coStr = "3" Or coStr = "5" Or coStr = "7" Or coStr = "9" Then
                    co += 1
                End If
                co = co / 2

                prc = iDgv.Rows(x).Cells(3).Value

                For y As Integer = 0 To co - 1
                    theQuery += "SELECT '" & sr & "' AS PrKey, N'" & itm & "' AS Item, " & prc & " AS Price UNION ALL "
                Next
            Next
            If Not theQuery = "" Then
                theQuery = theQuery.Substring(0, theQuery.LastIndexOf(" UNION ALL "))
            End If

            Dim ds As New ReportsDS
            Dim da As New SqlDataAdapter(theQuery, myConn)
            da.Fill(ds.Tables("tblBarcode"))

            Dim rep As New XtraNewBarcode
            rep.DataSource = ds
            rep.DataAdapter = da
            rep.DataMember = "tblBarcode"
            Dim tool As ReportPrintTool = New ReportPrintTool(rep)
            rep.CreateDocument()
            rep.ShowPreview()

        End If

    End Sub

    Private Sub btnPrintBadge_Click(sender As Object, e As EventArgs) Handles btnPrintBadge.Click
        If iDgv.RowCount = 0 Then
            MessageBox.Show("No Items to be printed!", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            'check the numbers
            Dim num As String
            For x As Integer = 0 To iDgv.RowCount - 1
                num = iDgv.Rows(x).Cells(2).Value
                If Not IsNumeric(num) Then
                    MsgBox("The Entered number is incorrect!")
                    iDgv.ClearSelection()
                    iDgv.Rows(x).Cells(2).Selected = True
                    Exit Sub
                End If
            Next

            Dim theQuery As String = ""

            'to set the start
            For s As Integer = 0 To (NumericUpDown1.Value * 3) - 1
                theQuery += "SELECT N'' AS Item, NULL AS Price UNION ALL "
            Next

            For s As Integer = 0 To (NumericUpDown2.Value) - 1
                theQuery += "SELECT N'' AS Item, NULL AS Price UNION ALL "
            Next


            Dim itm, prc As String
            Dim co As Integer
            For x As Integer = 0 To iDgv.RowCount - 1
                itm = iDgv.Rows(x).Cells(1).Value
                co = iDgv.Rows(x).Cells(2).Value
                prc = iDgv.Rows(x).Cells(3).Value
                For y As Integer = 0 To co - 1
                    theQuery += "SELECT N'" & itm & "' AS Item, '" & prc & "' AS Price UNION ALL "
                Next

            Next
            If Not theQuery = "" Then
                theQuery = theQuery.Substring(0, theQuery.LastIndexOf(" UNION ALL "))
            End If

            Dim ds As New ReportsDS
            Dim da As New SqlDataAdapter(theQuery, myConn)
            da.Fill(ds.Tables("tblBarcode"))

            Dim rep As New XtraLabels
            rep.DataSource = ds
            rep.DataAdapter = da
            rep.DataMember = "tblBarcode"
            rep.XrLabel3.Text = GV.MarketName
            Dim tool As ReportPrintTool = New ReportPrintTool(rep)
            rep.CreateDocument()
            rep.ShowPreview()
        End If

    End Sub

    Private Sub CheckEdit1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEdit1.CheckedChanged
        fillGrid(CheckEdit1.Checked)
    End Sub
End Class

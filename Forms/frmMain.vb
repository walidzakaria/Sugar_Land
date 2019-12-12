Imports System.Text
Imports System.Security.Cryptography
Imports System.Net
Imports System.IO
Imports System.Text.RegularExpressions
Imports DevExpress.XtraReports.UI
Imports System.Data.SqlClient
Imports System.Globalization

Public Class frmMain
    'Public Shared appDemo As Boolean = True
    'Public Shared myConn As New SqlConnection(My.Settings.DBConnectionString)
    Public Shared myConn As New SqlConnection(GV.myConn)
    Dim counter As Integer = 0
    Dim ValidQnty As Boolean = False

    'to convert numbers to letters

    Public Sub FillCategories()
        'fill the items search
        Dim FillQuery As String = "SELECT ID, Category FROM tblCategory ORDER BY Category;"

        Using cmd = New SqlCommand(FillQuery, myConn)
            If myConn.State = ConnectionState.Closed Then
                myConn.Open()
            End If
            Dim adt As New SqlDataAdapter
            Dim ds As New DataSet()
            adt.SelectCommand = cmd
            adt.Fill(ds)
            adt.Dispose()

            iiCategory.DataSource = ds.Tables(0)
            iiCategory.DisplayMember = "Category"
            iiCategory.ValueMember = "ID"
            iiCategory.SelectedIndex = -1

            myConn.Close()

        End Using

    End Sub

    Public Function AmountInWords(ByVal nAmount As String, Optional ByVal wAmount _
                   As String = vbNullString, Optional ByVal nSet As Object = Nothing) As String
        'Let's make sure entered value is numeric
        If Not IsNumeric(nAmount) Then Return "Please enter numeric values only."

        Dim tempDecValue As String = String.Empty : If InStr(nAmount, ".") Then _
            tempDecValue = nAmount.Substring(nAmount.IndexOf("."))
        nAmount = Replace(nAmount, tempDecValue, String.Empty)

        Try
            Dim intAmount As Long = nAmount
            If intAmount > 0 Then
                nSet = IIf((intAmount.ToString.Trim.Length / 3) _
                 > (CLng(intAmount.ToString.Trim.Length / 3)), _
                  CLng(intAmount.ToString.Trim.Length / 3) + 1, _
                   CLng(intAmount.ToString.Trim.Length / 3))
                Dim eAmount As Long = Microsoft.VisualBasic.Left(intAmount.ToString.Trim, _
                  (intAmount.ToString.Trim.Length - ((nSet - 1) * 3)))
                Dim multiplier As Long = 10 ^ (((nSet - 1) * 3))

                Dim Ones() As String = _
                {"", "One", "Two", "Three", _
                  "Four", "Five", _
                  "Six", "Seven", "Eight", "Nine"}
                Dim Teens() As String = {"", _
                "Eleven", "Twelve", "Thirteen", _
                  "Fourteen", "Fifteen", _
                  "Sixteen", "Seventeen", "Eighteen", "Nineteen"}
                Dim Tens() As String = {"", "Ten", _
                "Twenty", "Thirty", _
                  "Forty", "Fifty", "Sixty", _
                  "Seventy", "Eighty", "Ninety"}
                Dim HMBT() As String = {"", "", _
                "Thousand", "Million", _
                  "Billion", "Trillion", _
                  "Quadrillion", "Quintillion"}

                intAmount = eAmount

                Dim nHundred As Integer = intAmount \ 100 : intAmount = intAmount Mod 100
                Dim nTen As Integer = intAmount \ 10 : intAmount = intAmount Mod 10
                Dim nOne As Integer = intAmount \ 1

                If nHundred > 0 Then wAmount = wAmount & _
                Ones(nHundred) & " Hundred " 'This is for hundreds                
                If nTen > 0 Then 'This is for tens and teens
                    If nTen = 1 And nOne > 0 Then 'This is for teens 
                        wAmount = wAmount & Teens(nOne) & " "
                    Else 'This is for tens, 10 to 90
                        wAmount = wAmount & Tens(nTen) & IIf(nOne > 0, "-", " ")
                        If nOne > 0 Then wAmount = wAmount & Ones(nOne) & " "
                    End If
                Else 'This is for ones, 1 to 9
                    If nOne > 0 Then wAmount = wAmount & Ones(nOne) & " "
                End If
                wAmount = wAmount & HMBT(nSet) & " "
                wAmount = AmountInWords(CStr(CLng(nAmount) - _
                  (eAmount * multiplier)).Trim & tempDecValue, wAmount, nSet - 1)
            Else
                If Val(nAmount) = 0 Then nAmount = nAmount & _
                tempDecValue : tempDecValue = String.Empty
                If (Math.Round(Val(nAmount), 2) * 100) > 0 Then wAmount = _
                  Trim(AmountInWords(CStr(Math.Round(Val(nAmount), 2) * 100), _
                  wAmount.Trim & " Pesos And ", 1)) & " Cents"
            End If
        Catch ex As Exception
            MessageBox.Show("Error Encountered: " & ex.Message, _
              "Convert Numbers To Words", _
              MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return "!#ERROR_ENCOUNTERED"
        End Try

        'Trap null values
        If IsNothing(wAmount) = True Then wAmount = String.Empty Else wAmount = _
          IIf(InStr(wAmount.Trim.ToLower, "pesos"), _
          wAmount.Trim, wAmount.Trim & " Pesos")

        'Display the result
        Return wAmount
    End Function

    Public Function CreateEAN() As String
        Dim Sr As String = RandomString(5, 5)
        Sr = "3000000" & Sr
        Dim ssr() As Char = Sr.ToCharArray()
        Dim CheckSum As Integer = 0
        CheckSum += Val(ssr(0))
        CheckSum += Val(ssr(1)) * 3
        CheckSum += Val(ssr(2))
        CheckSum += Val(ssr(3)) * 3
        CheckSum += Val(ssr(4))
        CheckSum += Val(ssr(5)) * 3
        CheckSum += Val(ssr(6))
        CheckSum += Val(ssr(7)) * 3
        CheckSum += Val(ssr(8))
        CheckSum += Val(ssr(9)) * 3
        CheckSum += Val(ssr(10))
        CheckSum += Val(ssr(11)) * 3

        If CheckSum > 9 Then
            CheckSum = CheckSum.ToString.Substring(CheckSum.ToString.Length - 2)
        End If


        Select Case CheckSum
            Case 0 To 10
                CheckSum = 10 - CheckSum
            Case 11 To 20
                CheckSum = 20 - CheckSum
            Case 21 To 30
                CheckSum = 30 - CheckSum
            Case 31 To 40
                CheckSum = 40 - CheckSum
            Case 41 To 50
                CheckSum = 50 - CheckSum
            Case 51 To 60
                CheckSum = 60 - CheckSum
            Case 61 To 70
                CheckSum = 70 - CheckSum
            Case 71 To 80
                CheckSum = 80 - CheckSum
            Case 81 To 90
                CheckSum = 90 - CheckSum
            Case Else
                CheckSum = 100 - CheckSum
        End Select

        Return Sr & CheckSum.ToString
    End Function

    Public Function FindSerial(ByVal Serial As String) As String
        Dim result As String = ""
        Dim Query As String = "SELECT Serial FROM tblItems WHERE Serial LIKE '%" & Serial & "%'" _
                              & " UNION ALL" _
                              & " SELECT PackageSerial AS Serial FROM tblItems WHERE PackageSerial LIKE '%" & Serial & "%'" _
                              & " UNION ALL" _
                              & " SELECT Code AS Serial FROM tblMultiCodes WHERE Code LIKE '%" & Serial & "%'" _
                              & " ORDER BY Serial;"

        Using cmd = New SqlCommand(Query, myConn)
            If myConn.State = ConnectionState.Closed Then
                myConn.Open()
            End If
            Dim adt As New SqlDataAdapter
            Dim ds As New DataSet()
            adt.SelectCommand = cmd
            adt.Fill(ds)
            adt.Dispose()

            frmFind.ListBoxControl1.DataSource = ds.Tables(0)
            frmFind.ListBoxControl1.DisplayMember = "Serial"
            myConn.Close()

            If frmFind.ListBoxControl1.ItemCount = 1 Then
                result = frmFind.ListBoxControl1.GetItemText(0)
            ElseIf frmFind.ListBoxControl1.ItemCount > 1 Then
                frmFind.ShowDialog()
                result = frmFind.Result
            End If
            Return result
        End Using
    End Function
    Private Sub Authorize()
        Dim Kind As String = GlobalVariables.authority
        Select Case Kind
            Case "Admin", "Developer"
                KryptonPage1.Visible = True
                KryptonPage3.Visible = True
                KryptonPage4.Visible = True
                KryptonPage5.Visible = True
                KryptonPage6.Visible = True
                KryptonPage7.Visible = True
                KryptonPage8.Visible = True
                KryptonPage10.Visible = True
                dailyMonitor.Visible = False
                KryptonRibbonGroupButton8.Visible = True
                '   KryptonPage9.Visible = True
                KryptonPage10.Visible = True
                KryptonPage11.Visible = True
                KryptonRibbonGroupLines1.Visible = True

                KryptonRibbonGroupButton14.Visible = True
                KryptonRibbonGroupButton15.Visible = True
                KryptonRibbonGroupButton16.Visible = True
                KryptonRibbonGroupButton17.Visible = True
                KryptonRibbonGroupButton1.Visible = True
                ' KryptonRibbonGroupButton2.Visible = True
                KryptonRibbonGroupButton3.Visible = True
                KryptonRibbonGroupButton4.Visible = True
                KryptonRibbonGroupButton5.Visible = True
                itemReport.Visible = True
                outReport.Visible = True
                inReport.Visible = True
                itemMonitor.Visible = True
                ' totalMonitor.Visible = True
                dailyMonitor.Visible = True
                KryptonRibbonGroupButton2.Visible = True
                KryptonRibbonGroupButton6.Visible = True
                krpBarcode.Visible = True
                btnPassKey.Visible = True
                frmReception.btnRemove.Visible = True
            Case "Receptionist"
                KryptonPage1.Visible = False
                KryptonPage3.Visible = False
                KryptonPage4.Visible = False
                KryptonPage5.Visible = False
                KryptonPage6.Visible = False
                KryptonPage7.Visible = False
                KryptonPage8.Visible = False
                KryptonPage10.Visible = False
                dailyMonitor.Visible = False
                KryptonRibbonGroupButton8.Visible = False
                KryptonRibbonGroupButton1.Visible = False
                KryptonRibbonGroupLines1.Visible = False
                '     KryptonPage9.Visible = False
                'KryptonPage10.Visible = False
                KryptonPage11.Visible = False

                KryptonRibbonGroupButton14.Visible = False
                KryptonRibbonGroupButton15.Visible = False
                KryptonRibbonGroupButton16.Visible = False
                KryptonRibbonGroupButton17.Visible = False

                ' KryptonRibbonGroupButton2.Visible = False
                KryptonRibbonGroupButton3.Visible = False
                KryptonRibbonGroupButton4.Visible = False
                KryptonRibbonGroupButton5.Visible = False
                itemReport.Visible = False
                outReport.Visible = False
                inReport.Visible = False
                itemMonitor.Visible = False
                KryptonRibbonGroupButton2.Visible = False
                KryptonRibbonGroupButton6.Visible = False
                krpBarcode.Visible = False
                btnPassKey.Visible = False
                '    totalMonitor.Visible = False
                'dailyMonitor.Visible = False
                frmReception.btnRemove.Visible = False
            Case "Cashier"
                '   KryptonPage2.Visible = False
                KryptonPage3.Visible = False
                KryptonPage4.Visible = False
                KryptonPage5.Visible = False
                KryptonPage6.Visible = False
                KryptonPage7.Visible = False
                KryptonPage8.Visible = False
                '     KryptonPage9.Visible = False
                'KryptonPage10.Visible = False
                KryptonPage11.Visible = False

                KryptonRibbonGroupButton14.Visible = False
                KryptonRibbonGroupButton15.Visible = False
                KryptonRibbonGroupButton16.Visible = False
                KryptonRibbonGroupButton17.Visible = False

                ' KryptonRibbonGroupButton2.Visible = False
                KryptonRibbonGroupButton3.Visible = False
                KryptonRibbonGroupButton4.Visible = False
                KryptonRibbonGroupButton5.Visible = False
                itemReport.Visible = False
                outReport.Visible = False
                inReport.Visible = False
                itemMonitor.Visible = False
                KryptonRibbonGroupButton2.Visible = False
                '    totalMonitor.Visible = False
                'dailyMonitor.Visible = False
                btnPassKey.Visible = False
                frmReception.btnRemove.Visible = False
        End Select
    End Sub

    'to auto fill the rate
    Public Sub AutoRate(ByVal Dat As Date)

        'check if the rate is found
        Dim rateFound As Boolean
        Using cmd = New SqlCommand("SELECT * FROM tblRate WHERE [Day] = '" & Dat.ToString("MM/dd/yyyy") & "'", myConn)
            If myConn.State = ConnectionState.Closed Then
                myConn.Open()
            End If
            Using dr As SqlDataReader = cmd.ExecuteReader
                If dr.Read() Then
                    rateFound = True
                Else
                    rateFound = False
                End If
            End Using
        End Using
        If rateFound = False Then
            Using cmd = New SqlCommand("INSERT INTO tblRate (Day, Rate) VALUES ('" & Dat.ToString("MM/dd/yyyy") & "', '9')", frmMain.myConn)
                cmd.ExecuteNonQuery()
            End Using
        End If
        myConn.Close()
    End Sub

    '' TO SUPRESS THE TEXT IN DATAGRIDS
    Sub TextNumberKeypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        'Put the validations for your cell
        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) And Not e.KeyChar = "." Then
            e.Handled = True
        End If
    End Sub
    Private Sub RibbonClear()
        KryptonRibbonGroupButton1.Checked = False
        KryptonRibbonGroupButton3.Checked = False
        KryptonRibbonGroupButton4.Checked = False
        KryptonRibbonGroupButton5.Checked = False
        itemReport.Checked = False
        outReport.Checked = False
        inReport.Checked = False
        itemMonitor.Checked = False
        totalMonitor.Checked = False
        dailyMonitor.Checked = False
    End Sub

    Private Sub AlterCodes(ByVal Code As String, ByVal Codes As String)

        Codes = Codes.Replace(vbNewLine, "")
        Codes = Codes.Trim
        If Codes <> "" Then
            If Codes.Substring(Codes.Length - 1, 1) = ";" Then
                Codes = Codes.Substring(0, Codes.Length - 1)
            End If
        End If
        Dim CodesRange As String = "'" & Codes.Replace(";", "', '") & "'"
        Dim CheckQuery1 As String = "SELECT COUNT(*) FROM tblItems WHERE Serial IN (" & CodesRange & ");"
        Dim CheckQuery2 As String = "SELECT COUNT(*) FROM tblMultiCodes WHERE Code IN (" & CodesRange & ") " _
                                    & " AND NOT Item = (SELECT PrKey FROM tblItems WHERE Serial = '" & Code & "')"
        Dim Query As String = "DECLARE @PrKey INT = (SELECT PrKey FROM tblItems WHERE Serial = '" & Code & "');" _
                              & " DELETE FROM tblMultiCodes WHERE Item = @PrKey; "

        Dim rng() As String = Codes.Split(";")
        If rng.Count <> 0 And Not Codes = "" Then
            Query += "INSERT INTO tblMultiCodes (Item, Code) VALUES"

            For x As Integer = 0 To rng.Count - 1
                If rng(x).Trim <> "" Then
                    Query += " (@PrKey, '" & rng(x).Trim & "'),"
                End If
            Next
            Query = Query.Substring(0, Query.Length - 1)
            Query += ";"
        End If

        Using cmd = New SqlCommand(CheckQuery1, myConn)
            If myConn.State = ConnectionState.Closed Then
                myConn.Open()
            End If
            If cmd.ExecuteScalar <> 0 Then
                MsgBox("Some codes are in use!")
                myConn.Close()
                Exit Sub
            End If
            cmd.CommandText = CheckQuery2
            If cmd.ExecuteScalar <> 0 Then
                MsgBox("Some codes are in use!")
                myConn.Close()
                Exit Sub
            End If

            cmd.CommandText = Query
            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox("Failed to add additional codes!")
            End Try
            myConn.Close()
        End Using

    End Sub

    Private Sub SearchCash()
        If myConn.State = ConnectionState.Closed Then
            myConn.Open()
        End If
        Dim Query As String = "SELECT tblCash.PrKey, tblCash.[Type], CONVERT(NVARCHAR(12), tblCash.[Date], 103) AS [Date], CONVERT(NVARCHAR(5), tblCash.[Time], 108) AS [Time], tblCash.Qnty, tblCash.Indication, tblLogin.UserName AS [User]" _
                              & " FROM tblCash LEFT OUTER JOIN tblLogin" _
                              & " ON tblCash.[User] = tblLogin.Sr" _
                              & " WHERE tblCash.[Date] = '" & DateTimePicker1.Value.ToString("MM/dd/yyyy") & "'" _
                              & " ORDER BY tblCash.[Date], tblCash.[Time]"
        CashDGV.Rows.Clear()
        Using cmd = New SqlCommand(Query, myConn)
            Using dr As SqlDataReader = cmd.ExecuteReader

                Using dt As New DataTable
                    dt.Load(dr)
                    For x As Integer = 0 To dt.Rows.Count - 1
                        CashDGV.Rows.Add(dt.Rows(x)(0), dt.Rows(x)(1), dt.Rows(x)(2), dt.Rows(x)(3), dt.Rows(x)(4), dt.Rows(x)(5), dt.Rows(x)(6))

                    Next
                End Using

            End Using
        End Using
        myConn.Close()
    End Sub

    Private Sub inTotalize()
        'for the discount
        Dim discount As Single = Val(iDiscount.Text)
        discount = 100 - discount
        discount = discount / 100


        For Each line As DataGridViewRow In iDgv.Rows
            line.Cells(3).Value = Math.Round(discount * line.Cells(5).Value, 2, MidpointRounding.AwayFromZero)
            line.Cells(4).Value = Math.Round(line.Cells(2).Value * line.Cells(3).Value, 2, MidpointRounding.AwayFromZero)
        Next

        'for the totals
        Dim tSales As Decimal = 0
        For x As Integer = 0 To iDgv.RowCount - 1
            tSales += iDgv.Rows(x).Cells(4).Value
        Next

        iTotalSales.Text = tSales
        iRest.Text = (tSales - Val(itPaid.Text))
    End Sub


    Private Sub VendorsName()
        Using cmd = New SqlCommand("SELECT Name FROM tblVendors ORDER BY Name", myConn)
            If myConn.State = ConnectionState.Closed Then
                myConn.Open()
            End If
            Dim adt As New SqlDataAdapter
            Dim ds As New DataSet()
            adt.SelectCommand = cmd
            adt.Fill(ds)
            adt.Dispose()

            vSearch.DataSource = ds.Tables(0)
            vSearch.DisplayMember = "Name"
            vSearch.Text = Nothing

            myConn.Close()

        End Using
    End Sub

    Private Sub Notification(ByVal Notify As String)
        Timer1.Enabled = False
        counter = 0
        lbMonitor.Text = Notify

        lbMonitor.Visible = True
        Timer1.Enabled = True

    End Sub


    Private Sub frmMain_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.Control = True AndAlso e.KeyCode = Keys.S AndAlso KryptonDockableNavigator1.SelectedIndex = 0 Then
            Dim str As String = ""
            str = iVendor.SelectedIndex.ToString & ";" & iSerial.Text & ";" & itPaid.Text & ";" & iDiscount.Text & "$"

            For x As Integer = 0 To iDgv.RowCount - 1
                
                str += iDgv.Rows(x).Cells(0).Value & ";" & iDgv.Rows(x).Cells(1).Value & ";" & iDgv.Rows(x).Cells(2).Value & ";" _
                    & iDgv.Rows(x).Cells(3).Value & ";" & iDgv.Rows(x).Cells(4).Value & ";" & Val(iDgv.Rows(x).Cells(5).Value) & "$"
            Next
            My.Settings.InTemp = str
            My.Settings.InTempDate = ieDate.Value
            My.Settings.InTempTime = ieTime.Value
            My.Settings.Save()
        ElseIf e.Control = True AndAlso e.KeyCode = Keys.R AndAlso My.Settings.InTemp <> "" Then
            Dim str As String = My.Settings.InTemp
            ieDate.Value = My.Settings.InTempDate
            ieTime.Value = My.Settings.InTempTime

            Dim data() As String = str.Split("$")
            Dim data2() As String
            iDgv.Rows.Clear()
            For x As Integer = 0 To data.Count - 2
                data2 = data(x).Split(";")
                If x = 0 Then
                    iVendor.SelectedIndex = data2(0)
                    iSerial.Text = data2(1)
                    itPaid.Text = data2(2)
                    iDiscount.Text = data2(3)
                Else
                    iDgv.Rows.Add(data2(0), data2(1), data2(2), data2(3), data2(4), data2(5))
                End If
            Next
            inTotalize()
        End If

        ' for sales deletion
        If GlobalVariables.authority = "Admin" And e.Control And e.Shift And e.KeyCode = Keys.D Then
            frmDeleteSales.ShowDialog()
        End If
    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        iDgv.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        iDgv.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        iDgv.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        iDgv.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        iDgv.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        iDgv.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        
        'Dim validWindow As Date = #3/23/2017#

        CashierNew.SplashScreenManager1.ShowWaitForm()
        KryptonDockableNavigator1.SelectedIndex = 0
        

        If GV.AppDemo = True Then
            Dim invNu As Integer
            Dim query As String = "SELECT COUNT(*) FROM tblOut1"
            Using cmd = New SqlCommand(query, myConn)
                myConn.Open()
                invNu = cmd.ExecuteScalar
                myConn.Close()
            End Using

            If invNu > GV.InvoiceLimits Then
                MsgBox("Date backup failed!")
                Application.Exit()
            Else
                Dim mxDate As Date
                query = "SELECT MAX([Date]) FROM tblOut1;"
                Using cmd = New SqlCommand(query, myConn)
                    If myConn.State = ConnectionState.Closed Then
                        myConn.Open()
                    End If
                    Try
                        mxDate = cmd.ExecuteScalar
                    Catch ex As Exception
                        mxDate = Today
                    End Try

                    myConn.Close()
                End Using
                If mxDate > GV.DemoDate Then
                    MsgBox("Error 778: Data backup failed!")
                    Application.Exit()
                ElseIf mxDate > GV.DemoDate.AddDays(-GV.BackupDays) Then
                    MsgBox("Please note, system backup is needed!")
                End If
            End If
        End If

        ToolStripStatusLabel3.Text = GlobalVariables.user

        If KryptonDockableNavigator1.SelectedIndex = 0 Then
            Using cmd = New SqlCommand("SELECT Name, Sr FROM tblVendors ORDER BY Name", myConn)
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

                iVendor.Focus()
                myConn.Close()

            End Using
        End If
        'clear the customers combobox


        'fill the invoice combobox

        Using cmd = New SqlCommand("SELECT DISTINCT TOP(200) Serial FROM tblOut1 ORDER BY Serial DESC", myConn)
            If myConn.State = ConnectionState.Closed Then
                myConn.Open()
            End If
            Dim adt As New SqlDataAdapter
            Dim ds As New DataSet()
            adt.SelectCommand = cmd
            adt.Fill(ds)
            adt.Dispose()

            krSerial.DataSource = ds.Tables(0)
            krSerial.DisplayMember = "Serial"
            krSerial.Text = Nothing

            myConn.Close()

        End Using

        'load the virtual rate
        Call AutoRate(Today)
        RadioGroup1.SelectedIndex = 0

        Call Authorize()
        CashierNew.SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub KryptonRibbonGroupButton13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KryptonRibbonGroupButton13.Click
        frmLogin.Close()
        frmLogin.UsernameTextBox.Text = Nothing
        frmLogin.PasswordTextBox.Text = Nothing
        frmLogin.ShowDialog()
        ToolStripStatusLabel3.Text = GlobalVariables.user
        Call Authorize()
    End Sub

    Private Sub KryptonRibbonGroupButton14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KryptonRibbonGroupButton14.Click
        frmSignup.Show()
    End Sub

    Private Sub KryptonRibbonGroupButton15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KryptonRibbonGroupButton15.Click
        frmManageUsers.Show()
    End Sub

    Private Sub KryptonRibbonGroupButton16_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles KryptonRibbonGroupButton16.Click
        'Dim Dialog = New FolderBrowserDialog()
        'Dialog.SelectedPath = My.Settings.Path
        'Dim Path As String
        'If DialogResult.OK = Dialog.ShowDialog() Then
        '    My.Settings.Path = Dialog.SelectedPath
        '    My.Settings.Save()
        '    Path = Dialog.SelectedPath
        '    If Not Path Like "*" & "\" Then
        '        Path = Path & "\"
        '    End If
        '    Path = Path & "MasterPro " & Today.ToString("ddMMyy") & ".bak"

        '    ExClass.Backup(Path)
        'End If
        ExClass.Backup("E:\Backup\MasterPro" & Today.ToString("ddMMyy"))

    End Sub

    Private Sub KryptonRibbonGroupButton17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KryptonRibbonGroupButton17.Click
        frmImport.Show()

    End Sub

    Private Sub KryptonRibbonGroupButton18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KryptonRibbonGroupButton18.Click
        frmSupport.Show()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If counter < 7 Then
            If lbMonitor.Visible = True Then
                lbMonitor.Visible = False
            Else
                lbMonitor.Visible = True
            End If
            counter += 1
        Else
            lbMonitor.Visible = False
        End If
    End Sub

    Private Sub KryptonButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles vClear.Click
        vName.Text = Nothing
        vPhone1.Clear()
        vPhone2.Clear()
        vEmail.Text = Nothing
        vAddress.Text = Nothing
        vNotes.Text = Nothing
        vName.Focus()

        Call Notification("Cleared!")
    End Sub

    Private Sub rdVAddNew_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdVAddNew.CheckedChanged
        If rdVAddNew.Checked = True Then
            vAdd.Text = "SAVE"
            vSearch.Visible = False

        ElseIf rdVModify.Checked = True Then
            vAdd.Text = "EDIT"
            vSearch.Visible = True
        Else
            vAdd.Text = "DELETE"
            vSearch.Visible = True
        End If

    End Sub

    Private Sub rdVModify_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdVModify.CheckedChanged
        If rdVAddNew.Checked = True Then
            vAdd.Text = "SAVE"
            vSearch.Visible = False

        ElseIf rdVModify.Checked = True Then
            vAdd.Text = "EDIT"
            vSearch.Visible = True
        Else
            vAdd.Text = "DELETE"
            vSearch.Visible = True
        End If

    End Sub

    Private Sub rdVDelete_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdVDelete.CheckedChanged
        If rdVAddNew.Checked = True Then
            vAdd.Text = "SAVE"
            vSearch.Visible = False

        ElseIf rdVModify.Checked = True Then
            vAdd.Text = "EDIT"
            vSearch.Visible = True
        Else
            vAdd.Text = "DELETE"
            vSearch.Visible = True
        End If

    End Sub

    Private Sub mstSPhone1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mstSPhone1.Click
        vPhone1.Clear()
        vPhone1.Focus()

    End Sub

    Private Sub ButtonSpecAny1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSpecAny1.Click
        vPhone2.Clear()
        vPhone2.Focus()
    End Sub

    Private Sub vName_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles vName.PreviewKeyDown
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            vPhone1.Focus()
            vPhone1.SelectAll()
        End If
    End Sub

    Private Sub vEmail_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles vEmail.PreviewKeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Down Or e.KeyCode = Keys.Tab Then
            vAddress.Focus()
            vAddress.SelectAll()
        ElseIf e.KeyCode = Keys.Up Then
            vPhone2.Focus()
            vPhone2.SelectAll()
        End If
    End Sub

    Private Sub vAddress_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles vAddress.PreviewKeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Down Or e.KeyCode = Keys.Tab Then
            vNotes.Focus()
            vNotes.SelectAll()
        ElseIf e.KeyCode = Keys.Up Then
            vEmail.Focus()
            vEmail.SelectAll()
        End If
    End Sub

    Private Sub vNotes_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles vNotes.PreviewKeyDown
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Tab Then
            vAdd.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            vAddress.Focus()
            vAddress.SelectAll()

        End If
    End Sub
    Private Sub vAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles vAdd.Click
        If vAdd.Text = "SAVE" Then
            'check if the name is duplicate
            Dim dup As Boolean

            Using cmd = New SqlCommand("SELECT * FROM tblVendors WHERE Name = N'" & vName.Text & "'", myConn)
                If myConn.State = ConnectionState.Closed Then
                    myConn.Open()
                End If
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read() Then
                        dup = True
                    Else
                        dup = False
                    End If
                End Using

                myConn.Close()

            End Using

            If vName.Text = "" Then

                MessageBox.Show("You must enter vendor name!", "Empty Name", MessageBoxButtons.OK, MessageBoxIcon.Information)
                vName.Focus()
            ElseIf dup = True Then
                MessageBox.Show("The entered name already exists!", "Duplicate Name", MessageBoxButtons.OK, MessageBoxIcon.Information)
                vName.Focus()
                vName.SelectAll()

            Else

                'Save new record

                Dim query As String
                Dim ph As String = vPhone1.Text.Replace("(", "").Trim.Replace(")", "").Replace("-", "").Replace(" ", "")
                If ph.Length <> 0 Then
                    ph = vPhone1.Text
                End If

                Dim ph2 As String = vPhone2.Text.Replace("(", "").Trim.Replace(")", "").Replace("-", "").Replace(" ", "")
                If ph2.Length <> 0 Then
                    ph2 = vPhone2.Text
                End If

                query = "INSERT INTO tblVendors (Name, Phone1, Phone2, [E-mail], Address, Notes)" _
                    & " VALUES (N'" & vName.Text & "', '" & ph & "', '" & ph2 & "', '" & vEmail.Text & "','" & vAddress.Text & "', '" & vNotes.Text & "')"
                Using cmd = New SqlCommand(query, myConn)
                    If myConn.State = ConnectionState.Closed Then
                        myConn.Open()
                    End If
                    cmd.ExecuteNonQuery()
                    myConn.Close()

                End Using
                Call Notification("'" & vName.Text & " ' added!")
                vName.Text = Nothing
                vPhone1.Clear()
                vPhone2.Clear()
                vEmail.Text = Nothing
                vAddress.Text = Nothing
                vNotes.Text = Nothing
                vName.Focus()
            End If
        ElseIf vAdd.Text = "EDIT" Then
            'check if the name is duplicate
            Dim dup As Boolean

            Using cmd = New SqlCommand("SELECT * FROM tblVendors WHERE Name = N'" & vName.Text & "'", myConn)
                If myConn.State = ConnectionState.Closed Then
                    myConn.Open()
                End If
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read() Then
                        dup = True
                    Else
                        dup = False
                    End If
                End Using

                myConn.Close()

            End Using

            If vName.Text = "" Then
                MessageBox.Show("You must enter vendor name!", "Empty Name", MessageBoxButtons.OK, MessageBoxIcon.Information)
                vName.Focus()
            ElseIf dup = True And vName.Text <> vSearch.Text Then
                MessageBox.Show("The entered name already exists!", "Duplicate Name", MessageBoxButtons.OK, MessageBoxIcon.Information)
                vName.Focus()
                vName.SelectAll()

            Else

                'Modify new record

                Dim query As String

                Dim ph As String = vPhone1.Text.Replace("(", "").Trim.Replace(")", "").Replace("-", "").Replace(" ", "")
                If ph.Length <> 0 Then
                    ph = vPhone1.Text
                End If

                Dim ph2 As String = vPhone2.Text.Replace("(", "").Trim.Replace(")", "").Replace("-", "").Replace(" ", "")
                If ph2.Length <> 0 Then
                    ph2 = vPhone2.Text
                End If

                query = "UPDATE tblVendors SET Name = N'" & vName.Text & "', Phone1 = '" & ph & "', Phone2 = '" & ph2 & "', [E-mail] = '" & vEmail.Text & "', Address = '" & vAddress.Text & "', Notes = '" & vNotes.Text & "'" _
                    & " WHERE Name = N'" & vSearch.Text & "'"

                Using cmd = New SqlCommand(query, myConn)
                    If myConn.State = ConnectionState.Closed Then
                        myConn.Open()
                    End If
                    cmd.ExecuteNonQuery()
                    myConn.Close()

                End Using
                Call Notification("'" & vName.Text & " ' modified!")
                Call VendorsName()
            End If
        ElseIf vAdd.Text = "DELETE" Then
            Dim dia As DialogResult
            dia = MessageBox.Show("Are you sure you want to delete '" & vSearch.Text & "'?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If dia = Windows.Forms.DialogResult.Yes Then
                Try
                    Using cmd = New SqlCommand("DELETE FROM tblVendors WHERE Name = N'" & vSearch.Text & "'", myConn)
                        If myConn.State = ConnectionState.Closed Then
                            myConn.Open()
                        End If
                        cmd.ExecuteNonQuery()

                        myConn.Close()

                    End Using

                    Call Notification("'" & vSearch.Text & "' deleted!")
                    Call VendorsName()
                Catch ex As Exception
                    MsgBox("This vendor cannot be deleted as it has been used in other transactions!")
                End Try
            End If

        End If
    End Sub

    Private Sub vSearch_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles vSearch.SelectedIndexChanged
        If vSearch.Text <> "" Then
            Using cmd = New SqlCommand("SELECT * FROM tblVendors WHERE Name = N'" & vSearch.Text & "'", myConn)
                If myConn.State = ConnectionState.Closed Then
                    myConn.Open()
                End If
                Dim ds As New DataSet()
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(ds, "tblVendors")
                Dim dt As New DataTable
                dt = ds.Tables(0)
                Try
                    vName.Text = dt.Rows(0)(1).ToString
                    vPhone1.Text = dt.Rows(0)(2).ToString
                    vPhone2.Text = dt.Rows(0)(3).ToString
                    vEmail.Text = dt.Rows(0)(4).ToString
                    vAddress.Text = dt.Rows(0)(6).ToString
                    vNotes.Text = dt.Rows(0)(5).ToString
                Catch ex As Exception

                End Try

                myConn.Close()
            End Using
        Else
            vName.Text = Nothing
            vPhone1.Clear()
            vPhone2.Clear()
            vEmail.Text = Nothing
            vAddress.Text = Nothing
            vNotes.Text = Nothing
        End If
    End Sub

    Private Sub vSearch_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles vSearch.VisibleChanged
        If vSearch.Visible = True Then
            Call VendorsName()
        End If
    End Sub

    Private Sub KryptonDockableNavigator1_SelectedPageChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles KryptonDockableNavigator1.SelectedPageChanged
        Call RibbonClear()
        If KryptonDockableNavigator1.SelectedIndex = 0 Then

            KryptonRibbonGroupButton1.Checked = True
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

            'fill the serials and items combos
            Try
                Dim FillQuery As String = "SELECT PrKey, Serial, Name FROM tblItems" _
                                                          & " UNION ALL" _
                                                          & " SELECT tblItems.PrKey, tblMultiCodes.Code AS Serial, tblItems.Name" _
                                                          & " FROM tblMultiCodes INNER JOIN tblItems ON tblMultiCodes.Item = tblItems.PrKey" _
                                                          & " ORDER BY Name;"

                Using cmd = New SqlCommand(FillQuery, myConn)
                    If myConn.State = ConnectionState.Closed Then
                        myConn.Open()
                    End If
                    Dim adt As New SqlDataAdapter
                    Dim ds As New DataSet()
                    adt.SelectCommand = cmd
                    adt.Fill(ds)
                    adt.Dispose()

                    iItem.DataSource = ds.Tables(0)
                    iItem.DisplayMember = "Serial"
                    iItem.ValueMember = "PrKey"

                    iItemName.DataSource = ds.Tables(0)
                    iItemName.DisplayMember = "Name"
                    iItemName.Text = Nothing

                    myConn.Close()

                End Using
            Catch ex As Exception

            End Try
            iItemName.Text = ""
            iItem.Text = ""
        ElseIf KryptonDockableNavigator1.SelectedIndex = 1 Then

        ElseIf KryptonDockableNavigator1.SelectedIndex = 2 Then
            KryptonRibbonGroupButton3.Checked = True

        ElseIf KryptonDockableNavigator1.SelectedIndex = 3 Then
            KryptonRibbonGroupButton4.Checked = True
            FillCategories()

            'fill the items search
            Dim FillQuery As String = "SELECT PrKey, Serial, Name FROM tblItems" _
                                                          & " UNION ALL" _
                                                          & " SELECT tblItems.PrKey, tblMultiCodes.Code AS Serial, tblItems.Name" _
                                                          & " FROM tblMultiCodes INNER JOIN tblItems ON tblMultiCodes.Item = tblItems.PrKey" _
                                                          & " ORDER BY Name;"

            Using cmd = New SqlCommand(FillQuery, myConn)
                If myConn.State = ConnectionState.Closed Then
                    myConn.Open()
                End If
                Dim adt As New SqlDataAdapter
                Dim ds As New DataSet()
                adt.SelectCommand = cmd
                adt.Fill(ds)
                adt.Dispose()

                iiSearch.DataSource = ds.Tables(0)
                iiSearch.DisplayMember = "Serial"
                iiSearch.ValueMember = "PrKey"
                iiSearch.Text = Nothing

                myConn.Close()

            End Using

        ElseIf KryptonDockableNavigator1.SelectedIndex = 4 Then
            KryptonRibbonGroupButton5.Checked = True
            cSum.Focus()
        ElseIf KryptonDockableNavigator1.SelectedIndex = 5 Then
            inReport.Checked = True
            Using cmd = New SqlCommand("SELECT Name, Sr FROM tblVendors ORDER BY Name", myConn)
                If myConn.State = ConnectionState.Closed Then
                    myConn.Open()
                End If
                Dim adt As New SqlDataAdapter
                Dim ds As New DataSet()
                adt.SelectCommand = cmd
                adt.Fill(ds)
                adt.Dispose()

                isVendor.DataSource = ds.Tables(0)
                isVendor.DisplayMember = "Name"
                isVendor.ValueMember = "Sr"
                isVendor.Text = Nothing
                isVendor.Focus()

                myConn.Close()

            End Using
        ElseIf KryptonDockableNavigator1.SelectedIndex = 6 Then
            outReport.Checked = True

            'fill agents names
            Using cmd = New SqlCommand("SELECT Code, Agent FROM tblAgency ORDER BY PinCode", myConn)
                If myConn.State = ConnectionState.Closed Then
                    myConn.Open()
                End If
                Dim adt As New SqlDataAdapter
                Dim ds As New DataSet()
                adt.SelectCommand = cmd
                adt.Fill(ds)
                adt.Dispose()

                ossAgent.DataSource = ds.Tables(0)
                ossAgent.DisplayMember = "Agent"
                ossAgent.ValueMember = "Code"
                ossAgent.Text = Nothing

                myConn.Close()
            End Using

            'fill companies names
            Using cmd = New SqlCommand("SELECT DISTINCT Company FROM tblAgency ORDER BY Company", myConn)
                If myConn.State = ConnectionState.Closed Then
                    myConn.Open()
                End If
                Dim adt As New SqlDataAdapter
                Dim ds As New DataSet()
                adt.SelectCommand = cmd
                adt.Fill(ds)
                adt.Dispose()

                ossCompany.DataSource = ds.Tables(0)
                ossCompany.DisplayMember = "Company"
                ossCompany.Text = Nothing

                myConn.Close()
            End Using

            osTimeFrom.Value = Today & " 00:00"
            osTimeTill.Value = Today & " 23:59"

            ossTimeFrom.Value = Today & " 00:00"
            ossTimeTill.Value = Today & " 23:59"

            deTimeFrom.Value = Today & " 00:00"
            deTimeTill.Value = Today & " 23:59"

            'load item names
            Using cmd = New SqlCommand("SELECT Name FROM tblItems ORDER BY Name", myConn)
                If myConn.State = ConnectionState.Closed Then
                    myConn.Open()
                End If
                Dim adt As New SqlDataAdapter
                Dim ds As New DataSet()
                adt.SelectCommand = cmd
                adt.Fill(ds)
                adt.Dispose()

                osItem.DataSource = ds.Tables(0)
                osItem.DisplayMember = "Name"
                osItem.Text = Nothing

                myConn.Close()

            End Using


            'load item codes
            Using cmd = New SqlCommand("SELECT Serial FROM tblItems ORDER BY Serial", myConn)
                If myConn.State = ConnectionState.Closed Then
                    myConn.Open()
                End If
                Dim adt As New SqlDataAdapter
                Dim ds As New DataSet()
                adt.SelectCommand = cmd
                adt.Fill(ds)
                adt.Dispose()

                osCode.DataSource = ds.Tables(0)
                osCode.DisplayMember = "Serial"
                osCode.Text = Nothing

                myConn.Close()

            End Using

        ElseIf KryptonDockableNavigator1.SelectedIndex = 7 Then
            itemReport.Checked = True

            'fil the vendors list
            Using cmd = New SqlCommand("SELECT Name, PrKey FROM tblItems ORDER BY Name", myConn)
                If myConn.State = ConnectionState.Closed Then
                    myConn.Open()
                End If
                Dim adt As New SqlDataAdapter
                Dim ds As New DataSet()
                adt.SelectCommand = cmd
                adt.Fill(ds)
                adt.Dispose()

                siItem.DataSource = ds.Tables(0)
                siItem.DisplayMember = "Name"
                siItem.ValueMember = "PrKey"
                siItem.Focus()

                myConn.Close()
                siItem.Text = ""
            End Using
        ElseIf KryptonDockableNavigator1.SelectedIndex = 8 Then
            itemMonitor.Checked = True
            'fill the items
            Dim FillQuery As String = "SELECT PrKey, Serial, Name FROM tblItems" _
                                                          & " UNION ALL" _
                                                          & " SELECT tblItems.PrKey, tblMultiCodes.Code AS Serial, tblItems.Name" _
                                                          & " FROM tblMultiCodes INNER JOIN tblItems ON tblMultiCodes.Item = tblItems.PrKey" _
                                                          & " ORDER BY Name;"

            Using cmd = New SqlCommand(FillQuery, myConn)
                If myConn.State = ConnectionState.Closed Then
                    myConn.Open()
                End If
                Dim adt As New SqlDataAdapter
                Dim ds As New DataSet()
                adt.SelectCommand = cmd
                adt.Fill(ds)
                adt.Dispose()

                monItem.DataSource = ds.Tables(0)
                monItem.DisplayMember = "Name"
                monItem.ValueMember = "PrKey"
                monItem.Text = Nothing
                monItem.Focus()

                myConn.Close()

            End Using

        ElseIf KryptonDockableNavigator1.SelectedIndex = 9 Then
            totalMonitor.Checked = True
        ElseIf KryptonDockableNavigator1.SelectedIndex = 10 Then
            dailyMonitor.Checked = True

            Dim FillQuery As String = "SELECT UserName FROM tblLogin;"

            Using cmd = New SqlCommand(FillQuery, myConn)
                If myConn.State = ConnectionState.Closed Then
                    myConn.Open()
                End If
                Dim adt As New SqlDataAdapter
                Dim ds As New DataSet()
                adt.SelectCommand = cmd
                adt.Fill(ds)
                adt.Dispose()

                cbCashiers.DataSource = ds.Tables(0)
                cbCashiers.DisplayMember = "UserName"
                'cbCashiers.ValueMember = "PrKey"
                cbCashiers.Text = Nothing
                cbCashiers.Focus()
                myConn.Close()

            End Using
            tmFrom.Value = Today & " 00:00"
            tmTill.Value = Today & " 23:59"

        End If
    End Sub

    Private Sub iItem_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles iItem.KeyDown

        If Not iItem.Text = "" And e.KeyCode = Keys.Enter Then

            Dim ne As Boolean
            Dim NQuery2 As String = "SELECT tblItems.Name, tblItems.Price FROM tblItems LEFT OUTER JOIN tblMultiCodes ON tblItems.PrKey = tblMultiCodes.Item" _
                                      & " WHERE tblItems.Serial = '" & iItem.Text & "' OR tblMultiCodes.Code = '" & iItem.Text & "';"

            Using cmd = New SqlCommand(NQuery2, myConn)
                If myConn.State = ConnectionState.Closed Then
                    myConn.Open()
                End If
                Using dt As SqlDataReader = cmd.ExecuteReader
                    If dt.Read() Then
                        ne = False
                        iItemName.Text = dt(0).ToString
                        KryptonPanel22.Visible = False
                        lblSellingPrice.Text = "Selling Price: " & dt(1)
                        lblSellingPrice.Visible = True
                    Else
                        ne = True
                        KryptonPanel22.Visible = True
                        iItemName.Text = ""
                        lblSellingPrice.Visible = False
                    End If
                End Using
                myConn.Close()
            End Using
        Else
            lblSellingPrice.Visible = False
        End If

        'check if the grid has the same item

        If e.KeyCode = Keys.Enter Then
            'check if the grid has the same item
            For x As Integer = 0 To iDgv.RowCount - 1
                If (iDgv.Rows(x).Cells(0).Value.ToString.ToUpper = iItem.Text.ToUpper) AndAlso (iDgv.Rows(x).Cells(1).Value.ToString.ToUpper = iItemName.Text.ToUpper) Then
                    MessageBox.Show("This item already exists in the invoice!", "Duplicate Item", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    iDgv.ClearSelection()
                    iDgv.Rows(x).Selected = True
                    iItem.Focus()
                    iItem.SelectAll()
                End If
            Next
        End If

        If e.Control = True And e.KeyCode = Keys.K And Not iItem.Text = "" Then
            iItem.Text = FindSerial(iItem.Text)
        End If
    End Sub

    Private Sub iItem_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles iItem.LostFocus

        If Not iItem.Text = "" Then
            Dim ne As Boolean
            Dim NQuery2 As String = "SELECT tblItems.Name, tblItems.Price FROM tblItems LEFT OUTER JOIN tblMultiCodes ON tblItems.PrKey = tblMultiCodes.Item" _
                                      & " WHERE tblItems.Serial = '" & iItem.Text & "' OR tblMultiCodes.Code = '" & iItem.Text & "';"

            Using cmd = New SqlCommand(NQuery2, myConn)
                If myConn.State = ConnectionState.Closed Then
                    myConn.Open()
                End If
                Using dt As SqlDataReader = cmd.ExecuteReader
                    If dt.Read() Then
                        ne = False
                        iItemName.Text = dt(0).ToString
                        KryptonPanel22.Visible = False
                        lblSellingPrice.Visible = True
                    Else
                        ne = True
                        KryptonPanel22.Visible = True
                        iItemName.Text = ""
                        lblSellingPrice.Visible = False
                    End If
                End Using
                myConn.Close()
            End Using

        Else
            lblSellingPrice.Visible = False
        End If

    End Sub

    Private Sub iItem_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles iItem.PreviewKeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            iItemName.Focus()
        End If
    End Sub

    Private Sub iItemName_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles iItemName.LostFocus
        iItemName.Text = iItemName.Text.ToUpper
        If Not iItemName.Text = "" Then
            Dim ne As Boolean
            Using cmd = New SqlCommand("SELECT Serial FROM tblItems WHERE Name = N'" & iItemName.Text & "'", myConn)
                If myConn.State = ConnectionState.Closed Then
                    myConn.Open()
                End If
                Using dt As SqlDataReader = cmd.ExecuteReader
                    If dt.Read() Then
                        ne = False
                        iItem.Text = dt(0).ToString
                        KryptonPanel22.Visible = False
                    Else
                        ne = True
                        KryptonPanel22.Visible = True
                    End If
                End Using
                myConn.Close()

            End Using
        End If
    End Sub

    Private Sub iItemName_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles iItemName.PreviewKeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            If nEnglishName.Visible = True Then
                nEnglishName.Focus()
            Else
                iQnty.Focus()
            End If
        End If
    End Sub

    Private Sub iQnty_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles iQnty.GotFocus
        iQnty.SelectAll()
    End Sub

    Private Sub iQnty_KeyDown(sender As Object, e As KeyEventArgs) Handles iQnty.KeyDown
        If e.KeyCode = Keys.Enter And Not iQnty.Text = "" Then
            Dim SC As New MSScriptControl.ScriptControl
            Dim Formula As String = iQnty.Text
            SC.Language = "VBSCRIPT"
            Try
                Dim result As Single = Convert.ToSingle(SC.Eval(Formula))
                iQnty.Text = result
            Catch ex As Exception
                iQnty.Text = "0"
            End Try
        End If
    End Sub

    Private Sub iQnty_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles iQnty.KeyPress

        If Not Char.IsControl(e.KeyChar) And Not Char.IsDigit(e.KeyChar) And Not e.KeyChar = "." And Not Char.IsPunctuation(e.KeyChar) Then
            e.Handled = True
        End If
        If e.KeyChar = "." And iQnty.Text Like "*" & "." & "*" Then
            e.Handled = True
        End If

    End Sub

    Private Sub iQnty_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles iQnty.LostFocus
        If Not iQnty.Text = "" Then
            Dim SC As New MSScriptControl.ScriptControl
            Dim Formula As String = iQnty.Text
            SC.Language = "VBSCRIPT"
            Try
                Dim result As Single = Convert.ToSingle(SC.Eval(Formula))
                iQnty.Text = result
            Catch ex As Exception
                iQnty.Text = "0"
            End Try
        End If
        iValue.Text = Val(iQnty.Text) * Val(iUnitPrice.Text)
    End Sub

    Private Sub iQnty_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles iQnty.PreviewKeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Or e.KeyCode = Keys.Down Then
            iUnitPrice.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            iItem.Focus()
            iItem.SelectAll()
        End If
    End Sub

    Private Sub iUnitPrice_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles iUnitPrice.GotFocus
        iUnitPrice.SelectAll()
    End Sub

    Private Sub iUnitPrice_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles iUnitPrice.KeyPress

        If e.KeyChar = "." AndAlso iUnitPrice.Text = "" Then
            iUnitPrice.Text = "0."
            iUnitPrice.Select(2, 0)

        End If

        If Not Char.IsControl(e.KeyChar) And Not Char.IsDigit(e.KeyChar) And Not e.KeyChar = "." Then
            e.Handled = True
        End If
        If e.KeyChar = "." And iUnitPrice.Text Like "*" & "." & "*" Then
            e.Handled = True
        End If

    End Sub

    Private Sub iUnitPrice_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles iUnitPrice.PreviewKeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Or e.KeyCode = Keys.Down Then
            iValue.Focus()
            iValue.SelectAll()
        ElseIf e.KeyCode = Keys.Up Then
            iQnty.Focus()
            iQnty.SelectAll()
        End If
    End Sub

    Private Sub iValue_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles iValue.GotFocus
        iValue.SelectAll()
    End Sub

    Private Sub iValue_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles iValue.KeyPress
        If e.KeyChar = "." AndAlso iUnitPrice.Text = "" Then
            iUnitPrice.Text = "0."
            iUnitPrice.Select(2, 0)

        End If

        If Not Char.IsControl(e.KeyChar) And Not Char.IsDigit(e.KeyChar) And Not e.KeyChar = "." Then
            e.Handled = True
        End If
        If e.KeyChar = "." And iValue.Text Like "*" & "." & "*" Then
            e.Handled = True
        End If

    End Sub

    Private Sub iValue_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles iValue.PreviewKeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Or e.KeyCode = Keys.Down Then
            iItemAdd.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            iUnitPrice.Focus()
            iUnitPrice.SelectAll()
        End If
    End Sub


    Private Sub iItemAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles iItemAdd.Click
        If iItem.Text = "" Then
            MessageBox.Show("You must enter item code!", "Invalid Item", MessageBoxButtons.OK, MessageBoxIcon.Information)
            iItem.Focus()
        ElseIf iItemName.Text = "" Then
            MessageBox.Show("You must enter item name!", "Invalid Item", MessageBoxButtons.OK, MessageBoxIcon.Information)
            iItemName.Focus()
        ElseIf Val(iQnty.Text) = 0 Then
            MessageBox.Show("You must enter a valid quantity!", "Invalid Qnty", MessageBoxButtons.OK, MessageBoxIcon.Information)
            iQnty.Focus()
            iQnty.SelectAll()
        ElseIf Val(iUnitPrice.Text) = 0 Then
            MessageBox.Show("The entered unit price is invalid!", "Invalid Unit Price", MessageBoxButtons.OK, MessageBoxIcon.Information)
            iUnitPrice.Focus()
            iUnitPrice.SelectAll()
        ElseIf Val(iValue.Text) = 0 Then
            MessageBox.Show("The entered value is invalid!", "Invalid Value", MessageBoxButtons.OK, MessageBoxIcon.Information)
            iValue.Focus()
            iValue.SelectAll()
        Else

            'check if the item doesn't exist
            Dim old As Boolean
            Dim NQuery As String = "SELECT tblItems.* FROM tblItems LEFT OUTER JOIN tblMultiCodes ON tblItems.PrKey = tblMultiCodes.Item" _
                                      & " WHERE tblItems.Serial = '" & iItem.Text & "' OR tblMultiCodes.Code = '" & iItem.Text & "';"

            Using cmd = New SqlCommand(NQuery, myConn)
                If myConn.State = ConnectionState.Closed Then
                    myConn.Open()
                End If
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read() Then
                        old = True
                    Else
                        old = False
                    End If
                End Using

                myConn.Close()

            End Using

            If old = False Then
                Dim dia As DialogResult = MessageBox.Show("The entered item name doesn't exist, do you really want to save it?", "New Item", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If dia = Windows.Forms.DialogResult.Yes Then
                    'check if the serial is dup
                    Dim dupSr As Boolean
                    Dim NQuery2 As String = "SELECT tblItems.* FROM tblItems LEFT OUTER JOIN tblMultiCodes ON tblItems.PrKey = tblMultiCodes.Item" _
                                      & " WHERE tblItems.Serial = '" & iItem.Text & "' OR tblMultiCodes.Code = '" & iItem.Text & "' OR tblItems.PackageSerial = '" & iItem.Text & "';"

                    Using cmd = New SqlCommand(NQuery2, myConn)
                        If myConn.State = ConnectionState.Closed Then
                            myConn.Open()
                        End If
                        Using dr As SqlDataReader = cmd.ExecuteReader
                            If dr.Read() Then
                                dupSr = True
                            Else
                                dupSr = False
                            End If
                        End Using
                        myConn.Close()
                    End Using

                    If dupSr = True Then
                        MessageBox.Show("The entered Code is used for another item!", "Invalid Code", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        iItem.Focus()
                        iItem.SelectAll()
                    ElseIf Val(nItemPrice.Text) = 0 Then
                        MessageBox.Show("You must enter the unit price!", "Empty Price", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        nItemPrice.Focus()
                        nItemPrice.SelectAll()
                    Else

                        'check if itemname is dup
                        Using cmd = New SqlCommand("SELECT * FROM tblItems WHERE Name = N'" & iItemName.Text & "'", myConn)
                            If myConn.State = ConnectionState.Closed Then
                                myConn.Open()
                            End If
                            Using dr As SqlDataReader = cmd.ExecuteReader
                                If dr.Read() Then
                                    MessageBox.Show("The entered item name already exists with code '" & dr(1) & "'!", "Invalid Item Name", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    iItemName.Focus()
                                    iItemName.SelectAll()
                                    Exit Sub
                                End If
                            End Using
                            myConn.Close()
                        End Using

                        ' Add new Item to tblItems
                        Dim Query As String = "INSERT INTO tblItems (Serial, Name, Price, [Minimum], EnglishName) VALUES ('" & iItem.Text.ToUpper & "', N'" & iItemName.Text.ToUpper & "', '" & Val(nItemPrice.Text) & "', '" & Val(KryptonTextBox1.Text) & "', N'" & nEnglishName.Text & "')"
                        Using cmd = New SqlCommand(Query, myConn)
                            If myConn.State = ConnectionState.Closed Then
                                myConn.Open()
                            End If
                            cmd.ExecuteNonQuery()

                            myConn.Close()

                        End Using
                        KryptonPanel22.Visible = False

                        Dim serlll, itmmmm As String
                        serlll = iItem.Text.ToUpper
                        itmmmm = iItemName.Text.ToUpper
                        'fill the serials and items combos
                        Try
                            Dim FillQuery As String = "SELECT PrKey, Serial, Name FROM tblItems" _
                                                      & " UNION ALL" _
                                                      & " SELECT tblItems.PrKey, tblMultiCodes.Code AS Serial, tblItems.Name" _
                                                      & " FROM tblMultiCodes INNER JOIN tblItems ON tblMultiCodes.Item = tblItems.PrKey" _
                                                      & " ORDER BY Name;"

                            Using cmd = New SqlCommand(FillQuery, myConn)
                                If myConn.State = ConnectionState.Closed Then
                                    myConn.Open()
                                End If
                                Dim adt As New SqlDataAdapter
                                Dim ds As New DataSet()
                                adt.SelectCommand = cmd
                                adt.Fill(ds)
                                adt.Dispose()

                                iItem.DataSource = ds.Tables(0)
                                iItem.DisplayMember = "Serial"
                                iItem.ValueMember = "PrKey"

                                iItemName.DataSource = ds.Tables(0)
                                iItemName.DisplayMember = "Name"
                                iItemName.Text = Nothing

                                myConn.Close()

                            End Using
                        Catch ex As Exception

                        End Try
                        iItem.Text = serlll
                        iItemName.Text = itmmmm

                        GoTo record

                    End If

                End If
            Else
record:


                'check if the grid has the same item
                For x As Integer = 0 To iDgv.RowCount - 1
                    If (iDgv.Rows(x).Cells(0).Value.ToString.ToUpper = iItem.Text.ToUpper) AndAlso (iDgv.Rows(x).Cells(1).Value.ToString.ToUpper = iItemName.Text.ToUpper) Then
                        MessageBox.Show("This item has been entered before!", "Duplicate Item", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        iDgv.ClearSelection()
                        iDgv.Rows(x).Selected = True
                        iItem.Focus()
                        iItem.SelectAll()
                        Return
                    End If
                Next



                'Add a new record to the datagrid
                'iVendor.Enabled = False

                Dim theRow As String()
                theRow = New String() {iItem.Text.ToUpper, iItemName.Text.ToUpper, Val(iQnty.Text), Math.Round(Val(iUnitPrice.Text), 2, MidpointRounding.AwayFromZero), Math.Round(Val(iValue.Text), 2, MidpointRounding.AwayFromZero), Math.Round(Val(iUnitPrice.Text), 2, MidpointRounding.AwayFromZero)}

                iDgv.Rows.Add(theRow)

                iDgv.FirstDisplayedScrollingRowIndex = iDgv.RowCount - 1
                iDgv.ClearSelection()

                iDgv.Rows(iDgv.RowCount - 1).Selected = True

                iItem.Text = Nothing
                iItemName.Text = Nothing
                iQnty.Text = Nothing
                iDiscount.Text = ""
                iUnitPrice.Text = Nothing
                iValue.Text = Nothing

                iItem.Focus()
                Call Notification("New row added!")

            End If

        End If
    End Sub

    Private Sub iItemRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles iItemRemove.Click
        If Not iDgv.RowCount = 0 Then
            Dim dia As DialogResult
            dia = MessageBox.Show("Are you sure you want to remove this row?", "Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If dia = Windows.Forms.DialogResult.Yes Then
                'check if the item can be removed
                Dim CanRemove As Boolean = False
                Dim itemKey As String
                If Not iDgv.CurrentRow.Cells(6).Value Is Nothing Then
                    itemKey = iDgv.CurrentRow.Cells(6).Value

                    Dim Query As String = "DELETE FROM tblIn2 WHERE PrKey = @PrKey;"
                    Dim Query2 As String = "UPDATE tblIn1 SET Amount = '" & Val(iTotalSales.Text) & "', Paid = '" & Val(itPaid.Text) & "', Rest = '" & Val(iRest.Text) & "', Discount = '" & Val(iDiscount.Text) & "'" _
                                    & " WHERE PrKey = (SELECT PrKey FROM tblIn1 WHERE Serial = N'" & iSearch.Text & "')"
                    Using cmd = New SqlCommand(Query, myConn)
                        cmd.Parameters.AddWithValue("@PrKey", itemKey)
                        If myConn.State = ConnectionState.Closed Then
                            myConn.Open()
                        End If
                        Try
                            cmd.ExecuteNonQuery()
                            CanRemove = True
                        Catch ex As Exception
                            CanRemove = False
                        End Try
                        myConn.Close()
                    End Using
                Else
                    CanRemove = True
                End If


                If CanRemove = True Then
                    iDgv.Rows.Remove(iDgv.CurrentRow)
                    Notification("Current row removed!")
                Else
                    MsgBox("This item cannot be removed, as there are items sold from it!")
                End If

                
            End If
        End If
    End Sub

    Private Sub iDgv_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles iDgv.CellClick

        Try
            iDgv.CurrentRow.Selected = True

            iItem.Text = iDgv.CurrentRow.Cells(0).Value
            iItemName.Text = iDgv.CurrentRow.Cells(1).Value
            iQnty.Text = iDgv.CurrentRow.Cells(2).Value
            iUnitPrice.Text = iDgv.CurrentRow.Cells(3).Value
            iValue.Text = iDgv.CurrentRow.Cells(4).Value

        Catch ex As Exception

        End Try
    End Sub

    Private Sub iItemEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles iItemEdit.Click

        If iItem.Text = "" Then
            MessageBox.Show("You must enter Item code!", "Invalid Item", MessageBoxButtons.OK, MessageBoxIcon.Information)
            iItem.Focus()
        ElseIf iItemName.Text = "" Then
            MessageBox.Show("You must enter item name!", "Invalid Item", MessageBoxButtons.OK, MessageBoxIcon.Information)
            iItemName.Focus()
        ElseIf Val(iQnty.Text) = 0 Then
            MessageBox.Show("You must enter a valid quantity!", "Invalid Qnty", MessageBoxButtons.OK, MessageBoxIcon.Information)
            iQnty.Focus()
            iQnty.SelectAll()
        ElseIf Val(iUnitPrice.Text) = 0 Then
            MessageBox.Show("The entered unit price is invalid!", "Invalid Unit Price", MessageBoxButtons.OK, MessageBoxIcon.Information)
            iUnitPrice.Focus()
            iUnitPrice.SelectAll()
        ElseIf Val(iValue.Text) = 0 Then
            MessageBox.Show("The entered value is invalid!", "Invalid Value", MessageBoxButtons.OK, MessageBoxIcon.Information)
            iValue.Focus()
            iValue.SelectAll()
        Else

            'check if the item doesn't exist
            Dim old As Boolean
            Dim NQuery As String = "SELECT tblItems.* FROM tblItems LEFT OUTER JOIN tblMultiCodes ON tblItems.PrKey = tblMultiCodes.Item" _
                                  & " WHERE tblItems.Serial = '" & iItem.Text & "' OR tblMultiCodes.Code = '" & iItem.Text & "' OR tblItems.PackageSerial = '" & iItem.Text & "';"


            Using cmd = New SqlCommand(NQuery, myConn)
                If myConn.State = ConnectionState.Closed Then
                    myConn.Open()
                End If
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read() Then
                        old = True
                    Else
                        old = False
                    End If
                End Using

                myConn.Close()

            End Using

            If old = False Then
                Dim dia As DialogResult = MessageBox.Show("The entered item name doesn't exist, do you really want to save it?", "New Item", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If dia = Windows.Forms.DialogResult.Yes Then
                    'check if the serial is dup
                    Dim dupSr As Boolean
                    Using cmd = New SqlCommand(NQuery, myConn)
                        If myConn.State = ConnectionState.Closed Then
                            myConn.Open()
                        End If
                        Using dr As SqlDataReader = cmd.ExecuteReader
                            If dr.Read() Then
                                dupSr = True
                            Else
                                dupSr = False
                            End If
                        End Using
                        myConn.Close()
                    End Using

                    If dupSr = True Then
                        MessageBox.Show("The entered Code is used for another item!", "Invalid Code", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        iItem.Focus()
                        iItem.SelectAll()
                    ElseIf Val(nItemPrice.Text) = 0 Then
                        MessageBox.Show("You must enter the unit price!", "Empty Price", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        nItemPrice.Focus()
                        nItemPrice.SelectAll()
                    Else

                        'check if itemname is dup
                        Using cmd = New SqlCommand("SELECT * FROM tblItems WHERE Name = N'" & iItemName.Text & "'", myConn)
                            If myConn.State = ConnectionState.Closed Then
                                myConn.Open()
                            End If
                            Using dr As SqlDataReader = cmd.ExecuteReader
                                If dr.Read() Then
                                    MessageBox.Show("The entered item name already exists with code '" & dr(1) & "'!", "Invalid Item Name", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    iItemName.Focus()
                                    iItemName.SelectAll()
                                    Exit Sub
                                End If
                            End Using
                            myConn.Close()
                        End Using

                        ' Add new Item to tblItems
                        Dim Query As String = "INSERT INTO tblItems (Serial, Name, Price, [Minimum]) VALUES ('" & iItem.Text.ToUpper & "', N'" & iItemName.Text.ToUpper & "', '" & Val(nItemPrice.Text) & "', '" & Val(KryptonTextBox1.Text) & "')"
                        Using cmd = New SqlCommand(Query, myConn)
                            If myConn.State = ConnectionState.Closed Then
                                myConn.Open()
                            End If
                            cmd.ExecuteNonQuery()

                            myConn.Close()

                        End Using
                        KryptonPanel22.Visible = False

                        Dim serlll, itmmmm As String
                        serlll = iItem.Text.ToUpper
                        itmmmm = iItemName.Text.ToUpper
                        'fill the serials and items combos
                        Try
                            Dim FillQuery As String = "SELECT PrKey, Serial, Name FROM tblItems" _
                                                      & " UNION ALL" _
                                                      & " SELECT tblItems.PrKey, tblMultiCodes.Code AS Serial, tblItems.Name" _
                                                      & " FROM tblMultiCodes INNER JOIN tblItems ON tblMultiCodes.Item = tblItems.PrKey" _
                                                      & " ORDER BY Name;"

                            Using cmd = New SqlCommand(FillQuery, myConn)
                                If myConn.State = ConnectionState.Closed Then
                                    myConn.Open()
                                End If
                                Dim adt As New SqlDataAdapter
                                Dim ds As New DataSet()
                                adt.SelectCommand = cmd
                                adt.Fill(ds)
                                adt.Dispose()

                                iItem.DataSource = ds.Tables(0)
                                iItem.DisplayMember = "Serial"
                                iItem.ValueMember = "PrKey"

                                iItemName.DataSource = ds.Tables(0)
                                iItemName.DisplayMember = "Name"
                                iItemName.Text = Nothing

                                myConn.Close()

                            End Using
                        Catch ex As Exception

                        End Try
                        iItem.Text = serlll
                        iItemName.Text = itmmmm

                        GoTo record

                    End If

                End If
            Else
record:


                'check if the grid has the same item
                Dim cr As Integer = iDgv.CurrentRow.Index

                For x As Integer = 0 To iDgv.RowCount - 1
                    If Not x = cr Then
                        If (iDgv.Rows(x).Cells(0).Value.ToString.ToUpper = iItem.Text.ToUpper) AndAlso (iDgv.Rows(x).Cells(1).Value.ToString.ToUpper = iItemName.Text.ToUpper) Then
                            MessageBox.Show("This item has been entered before!", "Duplicate Item", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            iDgv.ClearSelection()
                            iDgv.Rows(x).Selected = True
                            iItem.Focus()
                            iItem.SelectAll()
                            Return
                        End If
                    End If
                Next



                'modify the record of the datagrid
                'iVendor.Enabled = False

                Dim theRow As String()

                theRow = New String() {iItem.Text.ToUpper, iItemName.Text.ToUpper, Val(iQnty.Text), Math.Round(Val(iUnitPrice.Text), 2, MidpointRounding.AwayFromZero), Math.Round(Val(iValue.Text), 2, MidpointRounding.AwayFromZero), Math.Round(Val(iUnitPrice.Text), 2, MidpointRounding.AwayFromZero)}

                iDgv.CurrentRow.SetValues(theRow)
                'iDgv.Rows.Add(theRow)

                iDgv.FirstDisplayedScrollingRowIndex = iDgv.RowCount - 1
                iDgv.ClearSelection()

                iDgv.Rows(iDgv.RowCount - 1).Selected = True

                iItem.Text = Nothing
                iItemName.Text = Nothing
                iQnty.Text = Nothing
                iDiscount.Text = ""
                iUnitPrice.Text = Nothing
                iValue.Text = Nothing

                iItem.Focus()
                Call Notification("Row Modified!")

            End If

        End If
    End Sub

    Private Sub iDgv_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles iDgv.CellValueChanged
        Call inTotalize()
    End Sub

    Private Sub iDgv_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles iDgv.RowHeaderMouseClick
        iDgv.CurrentRow.Selected = True

        iItem.Text = iDgv.CurrentRow.Cells(0).Value
        iItemName.Text = iDgv.CurrentRow.Cells(1).Value
        iQnty.Text = iDgv.CurrentRow.Cells(2).Value
        iUnitPrice.Text = iDgv.CurrentRow.Cells(3).Value
        iValue.Text = iDgv.CurrentRow.Cells(4).Value
    End Sub

    Private Sub iSerial_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles iSerial.PreviewKeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Or e.KeyCode = Keys.Down Then
            ieDate.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            iVendor.Focus()
            iVendor.SelectAll()
        End If
    End Sub

    Private Sub iClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles iClear.Click
        Dim dia As DialogResult
        dia = MessageBox.Show("Are you sure you want to clear all the data without saving?", "Clear", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If dia = Windows.Forms.DialogResult.Yes Then
            iDgv.Rows.Clear()
            iVendor.Text = Nothing
            ' iVendor.Enabled = True
            itPaid.Text = ""
            iSerial.Text = Nothing
            iItem.Text = Nothing
            iItemName.Text = Nothing
            iQnty.Text = Nothing
            iDiscount.Text = ""
            iUnitPrice.Text = Nothing
            iValue.Text = Nothing
            iDiscount.Text = ""
            ieDate.Value = Today
            ieTime.Value = Now
            'iItemEdit.Text = "ÊÕÍíÍ"
            iItemAdd.Enabled = True
            iItemRemove.Enabled = True
            Call Notification("Items cleared!")
        End If

    End Sub

    Private Sub iDgv_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles iDgv.RowsAdded
        Call inTotalize()
    End Sub

    Private Sub iDgv_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles iDgv.RowsRemoved
        Call inTotalize()
    End Sub

    Private Sub iDate_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles ieDate.PreviewKeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            ieTime.Focus()
        End If
    End Sub

    Private Sub iTime_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles ieTime.PreviewKeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            iItem.Focus()
        End If
    End Sub

    Private Sub rdiAdd_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdiAdd.CheckedChanged
        If rdiAdd.Checked = True Then
            iAdd.Text = "SAVE"
            iSearch.Visible = False


            'clear the items
            iDgv.Rows.Clear()
            iVendor.Text = Nothing
            ' iVendor.Enabled = True
            iSerial.Text = Nothing
            iItem.Text = Nothing
            iItemName.Text = Nothing
            iQnty.Text = Nothing
            iDiscount.Text = ""
            iUnitPrice.Text = Nothing
            iValue.Text = Nothing
            iDiscount.Text = ""

            ieDate.Value = Today
            ieTime.Value = Now
        ElseIf rdiModify.Checked = True Then
            iAdd.Text = "EDIT"
            iSearch.Visible = True

            'fill the combobox
            Using cmd = New SqlCommand("SELECT Serial FROM tblIn1 WHERE Vendor = '" & iVendor.SelectedValue & "' ORDER BY Serial DESC", myConn)
                If myConn.State = ConnectionState.Closed Then
                    myConn.Open()
                End If
                Dim adt As New SqlDataAdapter
                Dim ds As New DataSet()
                adt.SelectCommand = cmd
                adt.Fill(ds)
                adt.Dispose()

                iSearch.DataSource = ds.Tables(0)
                iSearch.DisplayMember = "Serial"
                iSearch.Text = Nothing


                myConn.Close()

            End Using


        Else
            iAdd.Text = "DELETE"
            iSearch.Visible = True

            Using cmd = New SqlCommand("SELECT Serial FROM tblIn1 WHERE Vendor = '" & iVendor.SelectedValue & "' ORDER BY Serial DESC", myConn)
                If myConn.State = ConnectionState.Closed Then
                    myConn.Open()
                End If
                Dim adt As New SqlDataAdapter
                Dim ds As New DataSet()
                adt.SelectCommand = cmd
                adt.Fill(ds)
                adt.Dispose()

                iSearch.DataSource = ds.Tables(0)
                iSearch.DisplayMember = "Serial"
                iSearch.Text = Nothing

                myConn.Close()


            End Using

        End If
    End Sub

    Private Sub iAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles iAdd.Click
        ''''''''''''''''
        'for demo
        If GV.AppDemo = True Then
            Using cmd = New SqlCommand("SELECT COUNT(Serial) FROM tblIn1", myConn)
                If myConn.State = ConnectionState.Closed Then
                    myConn.Open()
                End If
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read() Then
                        If dr(0) > GV.InvoiceLimits Then
                            Exit Sub
                        End If
                    End If
                End Using

                myConn.Close()
            End Using
        End If
        '''''''''''''''''''
        If iAdd.Text = "SAVE" Then
restart:

            If iVendor.Text = "" Then
                MessageBox.Show("You must select vendor name!", "Vendor", MessageBoxButtons.OK)
                iVendor.Focus()
            ElseIf iSerial.Text = "" Then
                MessageBox.Show("You must enter invoice serial!", "Invoice Serial", MessageBoxButtons.OK)
                iSerial.Focus() '
            ElseIf iDgv.RowCount = 0 Then
                MessageBox.Show("No data to be saved!", "No Items", MessageBoxButtons.OK)
                iItem.Focus()
            ElseIf Val(iRest.Text) < 0 Then
                MessageBox.Show("The paid amount is invalid!", "Wrong Amoun", MessageBoxButtons.OK)
                itPaid.Focus()
                itPaid.SelectAll()
            ElseIf Val(iDiscount.Text) > 50 Then
                MessageBox.Show("The entered discount is invalid!", "Wrong Discount", MessageBoxButtons.OK)
                iDiscount.Focus()
                iDiscount.SelectAll()
            Else


                'Check if it's debit invoice
                If Val(itPaid.Text) = 0 Or Val(itPaid.Text) < Val(iTotalSales.Text) Then
                    Dim dia As DialogResult
                    dia = MessageBox.Show("The invoice due amount is not fully paid, do you want to save it as credit?", "Unpaid Invoice", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    If dia = Windows.Forms.DialogResult.No Then
                        itPaid.Focus()
                        itPaid.SelectAll()
                        Exit Sub
                    End If
                End If

                'check if the rate is found
                Dim rateFound As Boolean
                Using cmd = New SqlCommand("SELECT * FROM tblRate WHERE [Day] = '" & ieDate.Value.ToString("MM/dd/yyyy") & "'", myConn)
                    If myConn.State = ConnectionState.Closed Then
                        myConn.Open()
                    End If
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read() Then
                            rateFound = True
                        Else
                            rateFound = False
                        End If
                    End Using

                    myConn.Close()
                End Using

                If rateFound = False Then
                    Call AutoRate(ieDate.Value)
                    GoTo restart
                Else

                    'check if the vendor exists
                    Dim existingVendor As Boolean
                    Using cmd = New SqlCommand("SELECT Name FROM tblVendors WHERE Name = N'" & iVendor.Text & "'", myConn)
                        If myConn.State = ConnectionState.Closed Then
                            myConn.Open()
                        End If
                        Using dr As SqlDataReader = cmd.ExecuteReader
                            If Not dr.Read() Then
                                existingVendor = True
                            Else
                                existingVendor = False
                            End If
                        End Using

                        myConn.Close()
                    End Using

                    If existingVendor = False Then
                        'check if the serial is unique
                        Dim unSer As Boolean
                        Using cmd = New SqlCommand("SELECT * FROM tblIn1 WHERE Serial = N'" & iSerial.Text & "'", myConn)
                            If myConn.State = ConnectionState.Closed Then
                                myConn.Open()
                            End If
                            Using dr As SqlDataReader = cmd.ExecuteReader
                                If dr.Read() Then
                                    unSer = False
                                Else
                                    unSer = True
                                End If
                            End Using

                            myConn.Close()
                        End Using

                        If unSer = False Then
                            MessageBox.Show("The entered invoice serial has been entered before!", "Duplicate Serial", MessageBoxButtons.OK)
                            iSerial.Focus()
                            iSerial.SelectAll()
                        Else
                            'start adding the invoice
                            Dim vndr, sril, timm As String
                            Dim usr As Integer
                            Dim qntity, untpric, vlu, before As Single
                            Dim datt As Date
                            vndr = iVendor.SelectedValue
                            'sril = iSerial.Text
                            datt = ieDate.Value
                            timm = ieTime.Value.ToString("HH:mm")
                            'temporary
                            usr = GlobalVariables.ID

                            If myConn.State = ConnectionState.Closed Then
                                myConn.Open()
                            End If


                            Dim Query1, Query2, Query3 As String
                            'insert into the first tblIn1

                            Query1 = "INSERT INTO tblIn1 (Serial, [Date], [Time], Amount, Paid, Rest, [User], Vendor, Discount)" _
                                & " VALUES (N'" & iSerial.Text.ToUpper & "','" & datt.ToString("MM/dd/yyyy") & "', '" & timm & "', '" & Val(iTotalSales.Text) & "', '" & Val(itPaid.Text) & "', '" & Val(iRest.Text) & "', '" & usr & "', '" & vndr & "', '" & Val(iDiscount.Text) & "')"

                            Using cmd = New SqlCommand(Query1, myConn)
                                cmd.ExecuteNonQuery()
                            End Using
                            Dim InvSerial As Integer = 0
                            Using cmd = New SqlCommand("SELECT PrKey FROM tblIn1 WHERE Serial = N'" & iSerial.Text.ToUpper & "'", myConn)
                                Using dr As SqlDataReader = cmd.ExecuteReader
                                    If dr.Read() Then
                                        InvSerial = dr(0)
                                    Else
                                        MsgBox("Error")
                                    End If
                                End Using
                            End Using

                            For x As Integer = 0 To iDgv.RowCount - 1
                                'get the item prKey
                                Dim QQuery As String = "SELECT tblItems.PrKey FROM tblItems" _
                                                       & " LEFT OUTER JOIN tblMultiCodes ON tblItems.PrKey = tblMultiCodes.Item" _
                                                       & " WHERE tblItems.Serial = '" & iDgv.Rows(x).Cells(0).Value & "' OR tblMultiCodes.Code = '" & iDgv.Rows(x).Cells(0).Value & "';"
                                Using cmd = New SqlCommand(QQuery, myConn)
                                    Using dr As SqlDataReader = cmd.ExecuteReader
                                        If dr.Read() Then
                                            sril = dr(0)
                                        Else
                                            sril = ""
                                        End If
                                    End Using
                                End Using

                                'compose the query string

                                qntity = iDgv.Rows(x).Cells(2).Value
                                untpric = iDgv.Rows(x).Cells(3).Value
                                vlu = iDgv.Rows(x).Cells(4).Value
                                before = iDgv.Rows(x).Cells(5).Value


                                Query2 = "INSERT INTO tblIn2 (Serial, Sr, Item, Qnty, Sold, UnitPrice, [Value], Before)" _
                                    & " VALUES ('" & InvSerial & "', '" & x + 1 & "', '" & sril & "', '" & qntity & "', '0', '" & untpric & "', '" & vlu & "', '" & before & "')"


                                Using cmd = New SqlCommand(Query2, myConn)
                                    cmd.ExecuteNonQuery()
                                End Using

                            Next

                            'inter the paid value
                            Query3 = "INSERT INTO tblDebit (Serial, Amount, [Date], [Time], [User])" _
                                & " VALUES ('" & InvSerial & "', '" & Val(itPaid.Text) & "', '" & datt.ToString("MM/dd/yyyy") & "', '" & timm & "', '" & usr & "')"

                            Using cmd = New SqlCommand(Query3, myConn)
                                cmd.ExecuteNonQuery()
                            End Using


                            myConn.Close()

                            Call Notification("Invoice added")

                            'clear the items
                            iDgv.Rows.Clear()
                            iVendor.Text = Nothing
                            'iVendor.Enabled = True
                            itPaid.Text = ""
                            iSerial.Text = Nothing
                            iItem.Text = Nothing
                            iItemName.Text = Nothing
                            iQnty.Text = Nothing
                            iDiscount.Text = ""
                            iUnitPrice.Text = Nothing
                            iValue.Text = Nothing
                            ieDate.Value = Today
                            ieTime.Value = Now
                        End If
                    Else
                        MessageBox.Show("The entered vendor name is incorrect!", "Invalid Vendor", MessageBoxButtons.OK)
                        iVendor.Focus()
                        iVendor.SelectAll()
                    End If

                End If
            End If
        ElseIf iAdd.Text = "EDIT" Then
            If GlobalVariables.authority = "Cashier" Or GlobalVariables.authority = "User" Then
                MsgBox("You don't have permissions to edit the invoice!")
                Exit Sub
            End If
restart2:

            Dim dia As DialogResult
            dia = MessageBox.Show("Are you sure you want to edit the current invoice?", "Edit", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If dia = Windows.Forms.DialogResult.Yes Then
                If iVendor.Text = "" Then
                    MessageBox.Show("You must select vendor name!", "Vendor", MessageBoxButtons.OK)
                    iVendor.Focus()
                ElseIf iSerial.Text = "" Then
                    MessageBox.Show("You must enter invoice serial!", "Invoice Serial", MessageBoxButtons.OK)
                    iSerial.Focus() '
                ElseIf iDgv.RowCount = 0 Then
                    MessageBox.Show("No data to be save!", "No Items", MessageBoxButtons.OK)
                    iItem.Focus()
                ElseIf Val(iRest.Text) < 0 Then
                    MessageBox.Show("No data to be saved!", "No Items", MessageBoxButtons.OK)
                    itPaid.Focus()
                    itPaid.SelectAll()
                ElseIf Val(iDiscount.Text) > 50 Then
                    MessageBox.Show("The entered discount is invalid!", "Wrong Discount", MessageBoxButtons.OK)
                    iDiscount.Focus()
                    iDiscount.SelectAll()
                Else

                    'check if the rate is found
                    Dim rateFound As Boolean
                    Using cmd = New SqlCommand("SELECT * FROM tblRate WHERE [Day] = '" & ieDate.Value.ToString("MM/dd/yyyy") & "'", myConn)
                        If myConn.State = ConnectionState.Closed Then
                            myConn.Open()
                        End If
                        Using dr As SqlDataReader = cmd.ExecuteReader
                            If dr.Read() Then
                                rateFound = True
                            Else
                                rateFound = False
                            End If
                        End Using

                        myConn.Close()

                    End Using

                    If rateFound = False Then
                        Call AutoRate(ieDate.Value)
                        GoTo restart2
                    Else

                        'check if the vendor exists
                        Dim existingVendor As Boolean
                        Using cmd = New SqlCommand("SELECT Name FROM tblVendors WHERE Name = N'" & iVendor.Text & "'", myConn)
                            If myConn.State = ConnectionState.Closed Then
                                myConn.Open()
                            End If
                            Using dr As SqlDataReader = cmd.ExecuteReader
                                If Not dr.Read() Then
                                    existingVendor = True
                                Else
                                    existingVendor = False
                                End If
                            End Using

                            myConn.Close()

                        End Using

                        If existingVendor = False Then


                            'check if the serial is unique
                            Dim unSer As Boolean
                            Using cmd = New SqlCommand("SELECT * FROM tblIn1 WHERE Serial = N'" & iSerial.Text & "'", myConn)
                                If myConn.State = ConnectionState.Closed Then
                                    myConn.Open()
                                End If
                                Using dr As SqlDataReader = cmd.ExecuteReader
                                    If dr.Read() Then
                                        unSer = False
                                    Else
                                        unSer = True
                                    End If
                                End Using

                                myConn.Close()
                            End Using

                            If unSer = False And iSerial.Text <> iSearch.Text Then
                                MessageBox.Show("The entered invoice serial has been entered before!", "Duplicate Serial", MessageBoxButtons.OK)
                                iSerial.Focus()
                                iSerial.SelectAll()
                            Else

                                'Check if the invoice has a paid debits
                                Dim Query1 As String = "SELECT tblIn1.Serial, COUNT(tblDebit.Amount) AS COU " _
                                                       & " FROM tblDebit INNER JOIN tblIn1" _
                                                       & " ON tblIn1.PrKey = tblDebit.Serial" _
                                                       & " WHERE tblIn1.Serial = N'" & iSearch.Text & "'" _
                                                       & " GROUP BY tblIn1.Serial"
                                Using cmd = New SqlCommand(Query1, myConn)
                                    If myConn.State = ConnectionState.Closed Then
                                        myConn.Open()
                                    End If
                                    Using dr As SqlDataReader = cmd.ExecuteReader
                                        If dr.Read() Then
                                            If dr(1) <> 1 Then
                                                MessageBox.Show("The invoice cannot be edited as there are other transactions based on it!", "Can't Modify", MessageBoxButtons.OK)
                                                iSearch.Focus()
                                                iSearch.SelectAll()
                                                Exit Sub
                                            End If
                                        Else
                                            MsgBox("Error")
                                        End If
                                    End Using
                                    myConn.Close()
                                End Using

                                'start adding the invoice
                                Dim vndr, sril, datt, timm As String
                                Dim usr As Integer
                                Dim qntity, untpric, vlu, before As Single

                                vndr = iVendor.SelectedValue
                                'sril = iSerial.Text
                                datt = ieDate.Value.ToString("MM/dd/yyyy")
                                timm = ieTime.Value.ToString("HH:mm")
                                'temporary
                                usr = GlobalVariables.ID

                                If myConn.State = ConnectionState.Closed Then
                                    myConn.Open()
                                End If

                                'remove the old data
                                Dim invoSer As Integer
                                Using cmd = New SqlCommand("SELECT PrKey FROM tblIn1 WHERE Serial = N'" & iSearch.Text & "'", myConn)
                                    If myConn.State = ConnectionState.Closed Then
                                        myConn.Open()
                                    End If
                                    Using dr As SqlDataReader = cmd.ExecuteReader
                                        If dr.Read() Then
                                            invoSer = dr(0)
                                        Else
                                            MsgBox("Error")
                                        End If
                                    End Using

                                End Using
                                'Using cmd = New SqlCommand("DELETE FROM tblIn2 WHERE Serial = '" & invoSer & "'", myConn)
                                '    cmd.ExecuteNonQuery()
                                'End Using

                                'Dim Query2, Query3 As String
                                'Dim Qquery As String = ""
                                Dim QUpdate As String = ""
                                Dim QAdd As String = ""
                                Dim inPrKey As String = ""
                                Dim ItemSerialID As String = ""
                                For x As Integer = 0 To iDgv.RowCount - 1
                                    'get the item prKey
                                    If Not IsDBNull(iDgv.Rows(x).Cells(6).Value) Then
                                        inPrKey = iDgv.Rows(x).Cells(6).Value
                                    End If

                                    qntity = iDgv.Rows(x).Cells(2).Value
                                    untpric = iDgv.Rows(x).Cells(3).Value
                                    vlu = iDgv.Rows(x).Cells(4).Value
                                    before = iDgv.Rows(x).Cells(5).Value

                                    ItemSerialID = "(SELECT tblItems.PrKey FROM tblItems" _
                                        & " LEFT OUTER JOIN tblMultiCodes ON tblItems.PrKey = tblMultiCodes.Item" _
                                        & " WHERE tblItems.Serial = '" & iDgv.Rows(x).Cells(0).Value & "' OR tblMultiCodes.Code = '" & iDgv.Rows(x).Cells(0).Value & "')"

                                    If inPrKey = "" Then
                                        QAdd &= " INSERT INTO tblIn2 (Serial, Sr, Item, Qnty, Sold, UnitPrice, [Value], Before)" _
                                            & " VALUES ('" & invoSer & "', '" & x + 1 & "', " & ItemSerialID & ", '" & qntity & "', '0', '" & untpric & "', '" & vlu & "', '" & before & "');"
                                    Else
                                        QUpdate &= " UPDATE tblIn2 SET Serial = '" & invoSer & "', Sr = '" & x + 1 & "', Item = " & ItemSerialID _
                                            & ", Qnty = '" & qntity & "', UnitPrice = '" & untpric & "', [Value] = '" & vlu & "', Before = '" & before & "'" _
                                            & " WHERE PrKey = " & inPrKey & ";"
                                    End If

                                Next


                                'Update the tblIn1, and tblDebit
                                Dim fullQuery As String = ""
                                fullQuery = QAdd & QUpdate
                                fullQuery &= " UPDATE tblIn1 SET [Date] = '" & datt & "', [Time] = '" & timm & "', Amount = '" & Val(iTotalSales.Text) & "', Paid = '" & Val(itPaid.Text) & "', Rest = '" & Val(iRest.Text) & "', [User] = '" & usr & "', Vendor = '" & vndr & "', Discount = '" & Val(iDiscount.Text) & "'" _
                                    & " WHERE PrKey = N'" & invoSer & "';"
                                fullQuery &= " UPDATE tblDebit SET Amount = '" & Val(itPaid.Text) & "', [Date] = '" & datt & "', [Time] = '" & timm & "', [User] = '" & usr & "'" _
                                    & " WHERE Serial = N'" & invoSer & "';"

                                Using cmd = New SqlCommand(fullQuery, myConn)
                                    cmd.ExecuteNonQuery()
                                End Using

                                myConn.Close()

                                Call Notification("Invoice Modified")

                                'clear the items
                                iDgv.Rows.Clear()
                                iVendor.Text = Nothing
                                'iVendor.Enabled = True
                                itPaid.Text = ""
                                iSerial.Text = Nothing
                                iItem.Text = Nothing
                                iItemName.Text = Nothing
                                iQnty.Text = Nothing
                                iDiscount.Text = ""
                                iUnitPrice.Text = Nothing
                                iValue.Text = Nothing
                                ieDate.Value = Today
                                ieTime.Value = Now
                            End If
                        Else
                            MessageBox.Show("The entered vendor name is incorrect!", "Invalid Vendor", MessageBoxButtons.OK)
                            iVendor.Focus()
                            iVendor.SelectAll()
                        End If

                    End If

                End If
            End If
        ElseIf iAdd.Text = "DELETE" Then

            If GlobalVariables.authority = "Cashier" Or GlobalVariables.authority = "User" Then
                MsgBox("You don't have permissions to delete the invoice!")
                Exit Sub
            End If

            Dim dia As DialogResult
            dia = MessageBox.Show("Do you really want to permanently delete the current invoice?!", "Invoice Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If dia = Windows.Forms.DialogResult.Yes Then


                Dim invoSer As Integer
                Using cmd = New SqlCommand("SELECT PrKey FROM tblIn1 WHERE Serial = N'" & iSearch.Text & "'", myConn)
                    If myConn.State = ConnectionState.Closed Then
                        myConn.Open()
                    End If
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read() Then
                            invoSer = dr(0)
                        Else
                            MsgBox("Error")
                        End If
                    End Using

                End Using

                'Check if the invoice has a paid debits
                Dim Query1 As String = "SELECT tblIn1.Serial, COUNT(tblDebit.Amount) AS COU " _
                                       & " FROM tblDebit INNER JOIN tblIn1" _
                                       & " ON tblIn1.PrKey = tblDebit.Serial" _
                                       & " WHERE tblIn1.Serial = N'" & iSearch.Text & "'" _
                                       & " GROUP BY tblIn1.Serial"
                Using cmd = New SqlCommand(Query1, myConn)
                    If myConn.State = ConnectionState.Closed Then
                        myConn.Open()
                    End If
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read() Then
                            If dr(1) <> 1 Then
                                MessageBox.Show("The current invoice cannot be deleted as there are other transactions based on it!", "Can't Delete", MessageBoxButtons.OK)
                                iSearch.Focus()
                                iSearch.SelectAll()
                                Exit Sub
                            End If
                        Else
                            MsgBox("Error")
                        End If
                    End Using
                    myConn.Close()
                End Using

                'strrt deleting

                If myConn.State = ConnectionState.Closed Then
                    myConn.Open()
                End If
                Dim cmdString As String = ""
                Dim itemsSold As Single = 0
                Using cmd = New SqlCommand("SELECT SUM(Sold) FROM tblIn2 WHERE Serial = '" & invoSer & "'; ", myConn)
                    Try
                        itemsSold = cmd.ExecuteScalar
                    Catch ex As Exception

                    End Try
                End Using

                If itemsSold <> 0 Then
                    myConn.Close()
                    MsgBox("Cannot delete this invoice, some items sold!")
                    Exit Sub
                End If

                Dim FcmdString As String = "DELETE FROM tblDebit WHERE Serial = '" & invoSer & "'; "
                Dim scmdString As String = "DELETE FROM tblIn2 WHERE Serial = '" & invoSer & "'; "
                Dim TcmdString As String = "DELETE FROM tblIn1 WHERE PrKey = '" & invoSer & "';"


                Using cmd = New SqlCommand(FcmdString, myConn)
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = scmdString
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = TcmdString
                    cmd.ExecuteNonQuery()
                End Using
                myConn.Close()

                'clear the items
                iDgv.Rows.Clear()
                iVendor.Text = Nothing
                'iVendor.Enabled = True
                iSerial.Text = Nothing
                iItem.Text = Nothing
                iItemName.Text = Nothing
                iQnty.Text = Nothing
                iDiscount.Text = ""
                iUnitPrice.Text = Nothing
                iValue.Text = Nothing
                ieDate.Value = Today
                ieTime.Value = Now

                Call Notification("Invoice Deleted!")
            End If

            End If
    End Sub

    Private Sub rdiModify_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdiModify.CheckedChanged
        If rdiAdd.Checked = True Then
            iAdd.Text = "SAVE"
            iSearch.Visible = False

            'clear the items
            iDgv.Rows.Clear()
            iVendor.Text = Nothing
            'iVendor.Enabled = True
            iSerial.Text = Nothing
            iItem.Text = Nothing
            iItemName.Text = Nothing
            iQnty.Text = Nothing
            iDiscount.Text = ""
            iUnitPrice.Text = Nothing
            iValue.Text = Nothing

        ElseIf rdiModify.Checked = True Then
            iAdd.Text = "EDIT"
            iSearch.Visible = True

            'fill the combobox
            Using cmd = New SqlCommand("SELECT Serial FROM tblIn1 WHERE Vendor = '" & iVendor.SelectedValue & "' ORDER BY Serial DESC", myConn)
                If myConn.State = ConnectionState.Closed Then
                    myConn.Open()
                End If
                Dim adt As New SqlDataAdapter
                Dim ds As New DataSet()
                adt.SelectCommand = cmd
                adt.Fill(ds)
                adt.Dispose()

                iSearch.DataSource = ds.Tables(0)
                iSearch.DisplayMember = "Serial"
                iSearch.Text = Nothing

                myConn.Close()
            End Using

        Else
            iAdd.Text = "DELETE"
            iSearch.Visible = True

            Using cmd = New SqlCommand("SELECT Serial FROM tblIn1 WHERE Vendor = '" & iVendor.SelectedValue & "' ORDER BY Serial DESC", myConn)
                If myConn.State = ConnectionState.Closed Then
                    myConn.Open()
                End If
                Dim adt As New SqlDataAdapter
                Dim ds As New DataSet()
                adt.SelectCommand = cmd
                adt.Fill(ds)
                adt.Dispose()

                iSearch.DataSource = ds.Tables(0)
                iSearch.DisplayMember = "Serial"
                iSearch.Text = Nothing

                myConn.Close()

            End Using

        End If
    End Sub

    Private Sub rdiDelete_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdiDelete.CheckedChanged
        If rdiAdd.Checked = True Then
            iAdd.Text = "SAVE"
            iSearch.Visible = False

            'clear the items
            iDgv.Rows.Clear()
            iVendor.Text = Nothing
            'iVendor.Enabled = True
            iSerial.Text = Nothing
            iItem.Text = Nothing
            iItemName.Text = Nothing
            iQnty.Text = Nothing
            iDiscount.Text = ""
            iUnitPrice.Text = Nothing
            iValue.Text = Nothing

        ElseIf rdiModify.Checked = True Then
            iAdd.Text = "EDIT"
            iSearch.Visible = True

            'fill the combobox
            Using cmd = New SqlCommand("SELECT Serial FROM tblIn1 WHERE Vendor = '" & iVendor.SelectedValue & "' ORDER BY Serial DESC", myConn)
                If myConn.State = ConnectionState.Closed Then
                    myConn.Open()
                End If
                Dim adt As New SqlDataAdapter
                Dim ds As New DataSet()
                adt.SelectCommand = cmd
                adt.Fill(ds)
                adt.Dispose()

                iSearch.DataSource = ds.Tables(0)
                iSearch.DisplayMember = "Serial"
                iSearch.Text = Nothing

                myConn.Close()

            End Using

        Else
            iAdd.Text = "DELETE"
            iSearch.Visible = True

            Using cmd = New SqlCommand("SELECT Serial FROM tblIn1 WHERE Vendor = '" & iVendor.SelectedValue & "' ORDER BY Serial DESC", myConn)
                If myConn.State = ConnectionState.Closed Then
                    myConn.Open()
                End If
                Dim adt As New SqlDataAdapter
                Dim ds As New DataSet()
                adt.SelectCommand = cmd
                adt.Fill(ds)
                adt.Dispose()

                iSearch.DataSource = ds.Tables(0)
                iSearch.DisplayMember = "Serial"
                iSearch.Text = Nothing

                myConn.Close()


            End Using

        End If
    End Sub

    Private Sub recallIn()
        Dim Query As String
        Query = "SELECT tblIn1.Vendor, tblIn1.Serial, tblIn1.[Date], tblIn1.[Time], tblItems.Serial AS Item, tblItems.Name, tblIn2.Qnty, tblIn2.UnitPrice, tblIn2.[Value], tblIn1.Paid, tblIn1.Discount, tblIn2.Before, tblIn2.PrKey" _
            & " FROM tblIn1 INNER JOIN" _
            & " tblIn2 ON tblIn1.PrKey = tblIn2.Serial" _
            & " INNER JOIN tblItems" _
            & " ON tblIn2.Item = tblItems.PrKey" _
            & " WHERE tblIn1.Vendor = '" & iVendor.SelectedValue & "' AND tblIn1.Serial = N'" & iSearch.Text & "'"

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
                        iDgv.Rows.Add(dt.Rows(x)(4), dt.Rows(x)(5), dt.Rows(x)(6), dt.Rows(x)(7), dt.Rows(x)(8), dt.Rows(x)(11), dt.Rows(x)(12))
                    Next

                    iSerial.Text = dt.Rows(0)(1).ToString
                    ieDate.Value = dt.Rows(0)(2)
                    ieTime.Value = dt.Rows(0)(3)
                    iDiscount.Text = dt.Rows(0)(10)

                Catch ex As Exception

                End Try

            End Using


            myConn.Close()
            inTotalize()
        End Using

    End Sub
    Private Sub iSearch_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles iSearch.LostFocus
        recallIn()
    End Sub

    Private Sub iSearch_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles iSearch.SelectedIndexChanged
        recallIn()
    End Sub

    Private Sub iVendor_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles iVendor.LostFocus


        If Not iVendor.Text = "" Then
            If iSearch.Visible = True Then
                Using cmd = New SqlCommand("SELECT Serial FROM tblIn1 WHERE Vendor = '" & iVendor.SelectedValue & "' ORDER BY Serial DESC", myConn)
                    If myConn.State = ConnectionState.Closed Then
                        myConn.Open()
                    End If
                    Dim adt As New SqlDataAdapter
                    Dim ds As New DataSet()
                    adt.SelectCommand = cmd
                    adt.Fill(ds)
                    adt.Dispose()

                    iSearch.DataSource = ds.Tables(0)
                    iSearch.DisplayMember = "Serial"
                    iSearch.Text = Nothing


                    myConn.Close()

                End Using
            End If

        End If
    End Sub

    Private Sub ComboBox1_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles iVendor.PreviewKeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            iSerial.Focus()
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles iVendor.SelectedIndexChanged
        If Not iVendor.Text = "" Then

            If iSearch.Visible = True Then
                Using cmd = New SqlCommand("SELECT Serial FROM tblIn1 WHERE Vendor = '" & iVendor.SelectedValue & "' ORDER BY Serial DESC", myConn)
                    If myConn.State = ConnectionState.Closed Then
                        myConn.Open()
                    End If
                    Dim adt As New SqlDataAdapter
                    Dim ds As New DataSet()
                    adt.SelectCommand = cmd
                    adt.Fill(ds)
                    adt.Dispose()

                    iSearch.DataSource = ds.Tables(0)
                    iSearch.DisplayMember = "Serial"
                    iSearch.Text = Nothing

                End Using
            End If

            If myConn.State = ConnectionState.Closed Then
                myConn.Open()
            End If
            'get the vendor's details:
            Dim Q1, Q2 As String

            Q1 = "SELECT COALESCE(SUM(tblIn1.Rest), 0) AS Rest" _
                & " FROM tblIn1" _
                & " INNER JOIN tblVendors" _
                & " ON tblVendors.Sr = tblIn1.Vendor" _
                & " WHERE tblVendors.Name = N'" & iVendor.Text & "'"


            Using cmd = New SqlCommand(Q1, myConn)
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read() Then
                        KryptonLabel20.Text = Val(dr(0))
                    Else
                        KryptonLabel20.Text = "00"
                    End If
                End Using
            End Using

            Q2 = "SELECT TOP(1) [Date] FROM tblIn1" _
                & " INNER JOIN tblVendors" _
                & " ON tblIn1.Vendor = tblVendors.Sr" _
                & " WHERE tblVendors.Name = N'" & iVendor.Text & "'" _
                & " ORDER BY tblIn1.[Date], tblIn1.[Time] DESC"

            Using cmd = New SqlCommand(Q2, myConn)
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read() Then
                        KryptonLabel38.Text = dr(0)
                    Else
                        KryptonLabel38.Text = ""
                    End If
                End Using
            End Using
            myConn.Close()
            KryptonPanel7.Visible = True
        Else
            KryptonLabel38.Text = ""
            KryptonLabel20.Text = "00"
            KryptonPanel7.Visible = False
        End If
    End Sub

    Private Sub iVendor_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles iVendor.TextChanged
        If Not iVendor.Text = "" Then

            If iSearch.Visible = True Then
                Using cmd = New SqlCommand("SELECT Serial FROM tblIn1 WHERE Vendor = '" & iVendor.SelectedValue & "' ORDER BY Serial DESC", myConn)
                    If myConn.State = ConnectionState.Closed Then
                        myConn.Open()
                    End If
                    Dim adt As New SqlDataAdapter
                    Dim ds As New DataSet()
                    adt.SelectCommand = cmd
                    adt.Fill(ds)
                    adt.Dispose()

                    iSearch.DataSource = ds.Tables(0)
                    iSearch.DisplayMember = "Serial"
                    iSearch.Text = Nothing

                End Using
            End If

            If myConn.State = ConnectionState.Closed Then
                myConn.Open()
            End If
            'get the vendor's details:
            Dim Q1, Q2 As String

            Q1 = "SELECT COALESCE(SUM(tblIn1.Rest), 0) AS Rest" _
                & " FROM tblIn1" _
                & " INNER JOIN tblVendors" _
                & " ON tblVendors.Sr = tblIn1.Vendor" _
                & " WHERE tblVendors.Name = N'" & iVendor.Text & "'"

            Using cmd = New SqlCommand(Q1, myConn)
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read() Then
                        KryptonLabel20.Text = Val(dr(0))
                    Else
                        KryptonLabel20.Text = "00"
                    End If
                End Using
            End Using

            Q2 = "SELECT TOP(1) [Date] FROM tblIn1" _
                & " INNER JOIN tblVendors" _
                & " ON tblIn1.Vendor = tblVendors.Sr" _
                & " WHERE tblVendors.Name = N'" & iVendor.Text & "'" _
                & " ORDER BY tblIn1.[Date], tblIn1.[Time] DESC"

            Using cmd = New SqlCommand(Q2, myConn)
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read() Then
                        KryptonLabel38.Text = dr(0)
                    Else
                        KryptonLabel38.Text = ""
                    End If
                End Using
            End Using
            myConn.Close()
            KryptonPanel7.Visible = True
        Else
            KryptonLabel38.Text = ""
            KryptonLabel20.Text = "00"
            KryptonPanel7.Visible = False
        End If
    End Sub

    Private Sub iItemAdd_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles iItemAdd.PreviewKeyDown
        If e.KeyCode = Keys.Down Then
            iItemEdit.Focus()
        End If
    End Sub

    Private Sub iItemEdit_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles iItemEdit.PreviewKeyDown
        If e.KeyCode = Keys.Down Then
            iItemRemove.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            iItemAdd.Focus()
        End If
    End Sub

    Private Sub iItemRemove_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles iItemRemove.PreviewKeyDown
        If e.KeyCode = Keys.Up Then
            iItemEdit.Focus()
        End If
    End Sub

    Private Sub vPhone1_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles vPhone1.PreviewKeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Down Or e.KeyCode = Keys.Tab Then
            vPhone2.Focus()
            vPhone2.SelectAll()
        ElseIf e.KeyCode = Keys.Up Then
            vName.Focus()
            vName.SelectAll()

        End If
    End Sub

    Private Sub vPhone2_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles vPhone2.PreviewKeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Down Or e.KeyCode = Keys.Tab Then
            vEmail.Focus()
            vEmail.SelectAll()
        ElseIf e.KeyCode = Keys.Up Then
            vPhone1.Focus()
            vPhone1.SelectAll()

        End If
    End Sub

    Private Sub vAdd_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles vAdd.PreviewKeyDown
        If e.KeyCode = Keys.Left Then
            vNotes.Focus()
            vNotes.SelectAll()
        ElseIf e.KeyCode = Keys.Right Then
            iClear.Focus()
        End If
    End Sub

    Private Sub KryptonRibbonGroupButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '  Call AmountInWords("122", "123", Me.Text)

    End Sub

    Private Sub nItemPrice_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles nItemPrice.KeyPress
        If Not Char.IsControl(e.KeyChar) And Not Char.IsDigit(e.KeyChar) And Not e.KeyChar = "." Then
            e.Handled = True
        End If
        If e.KeyChar = "." And nItemPrice.Text Like "*" & "." & "*" Then
            e.Handled = True
        End If
    End Sub

    Private Sub nItemPrice_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles nItemPrice.PreviewKeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Or e.KeyCode = Keys.Down Then
            KryptonTextBox1.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            nEnglishName.Focus()
        End If
    End Sub

    Private Sub iiPrice_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles iiPrice.KeyPress
        If Not Char.IsControl(e.KeyChar) And Not Char.IsDigit(e.KeyChar) And Not e.KeyChar = "." Then
            e.Handled = True
        End If
        If e.KeyChar = "." And iiPrice.Text Like "*" & "." & "*" Then
            e.Handled = True
        End If
    End Sub

    Private Sub iiPrice_PreviewKeyDown(sender As Object, e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles iiPrice.PreviewKeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Down Or e.KeyCode = Keys.Tab Then
            If e.KeyCode = Keys.Shift Then
                iiEnglishName.Focus()
            Else
                iiMinimumQnty.Focus()
            End If
        ElseIf e.KeyCode = Keys.Up Then
            iiEnglishName.Focus()
        End If
    End Sub

    Private Sub iiRdNew_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles iiRdNew.CheckedChanged
        If iiRdNew.Checked Then
            iiAdd.Text = "SAVE"
            iiSearch.Visible = False
        ElseIf iiRdModify.Checked = True Then
            iiAdd.Text = "EDIT"
            iiSearch.Visible = True
            iiSearch.Text = Nothing
        ElseIf iiRdDelete.Checked = True Then
            iiAdd.Text = "DELETE"
            iiSearch.Visible = True
            iiSearch.Text = Nothing
        End If
    End Sub

    Private Sub iiAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles iiAdd.Click
        If iiAdd.Text = "SAVE" Then
            If iiSerial.Text = "" Then
                MessageBox.Show("You must enter code!", "Empty Code", MessageBoxButtons.OK, MessageBoxIcon.Information)
                iiSerial.Focus()
            ElseIf iiItem.Text = "" Then
                MessageBox.Show("You must enter item name!", "Empty Item", MessageBoxButtons.OK, MessageBoxIcon.Information)
                iiItem.Focus()
            ElseIf Val(iiPrice.Text) = 0 Then
                MessageBox.Show("You must enter selling price!", "Invalid Price", MessageBoxButtons.OK, MessageBoxIcon.Information)
                iiPrice.Focus()
            ElseIf iiSerial2.Text <> "" And (Val(iiGroupPrice.Text) = 0 Or Val(iiUnitNumber.Text) = 0) Then
                If Val(iiGroupPrice.Text) = 0 Then
                    MessageBox.Show("You must enter package price!", "Invalid Price", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    iiGroupPrice.Focus()
                Else
                    MessageBox.Show("You must enter package units!", "Invalid Units", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    iiUnitNumber.Focus()
                End If
            ElseIf (Val(iiUnitNumber.Text) <> 0 AndAlso Val(iiGroupPrice.Text) = 0) Or (Val(iiUnitNumber.Text) = 0 AndAlso Val(iiGroupPrice.Text) <> 0) Then
                MessageBox.Show("You must enter package price!", "Invalid Price", MessageBoxButtons.OK, MessageBoxIcon.Information)
                iiGroupPrice.Focus()
            ElseIf (Val(iiPrice.Text) > Val(iiGroupPrice.Text)) And Not Val(iiGroupPrice.Text) = 0 Then
                MessageBox.Show("Package price must be greater than unit price!", "Invalid Price", MessageBoxButtons.OK, MessageBoxIcon.Information)
                iiGroupPrice.Focus()
            ElseIf (Val(iiGroupPrice.Text) / Val(iiUnitNumber.Text)) >= Val(iiPrice.Text) Then
                MessageBox.Show("Unit price in package must be less than unit price!", "Invalid Price", MessageBoxButtons.OK, MessageBoxIcon.Information)
                iiGroupPrice.Focus()
            Else

                'check duplicate serial

                Dim NQuery As String = "SELECT tblItems.PrKey FROM tblItems " _
                                       & " LEFT OUTER JOIN tblMultiCodes ON tblItems.PrKey = tblMultiCodes.Item" _
                                       & " WHERE tblItems.Serial = N'" & iiSerial.Text & "' OR tblMultiCodes.Code = N'" & iiSerial.Text & "'"
                Using cmd = New SqlCommand(NQuery, myConn)
                    If myConn.State = ConnectionState.Closed Then
                        myConn.Open()
                    End If

                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read() Then
                            myConn.Close()
                            MessageBox.Show("The entered item name already exists!", "Invalid Name", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            iiSerial.Focus()
                            iiSerial.SelectAll()
                            Exit Sub
                        End If
                    End Using

                    myConn.Close()

                End Using

                'check duplicate names
                Using cmd = New SqlCommand("SELECT Serial FROM tblItems WHERE Name = N'" & iiItem.Text & "'", myConn)
                    If myConn.State = ConnectionState.Closed Then
                        myConn.Open()
                    End If

                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read() Then
                            myConn.Close()
                            MessageBox.Show("The entered package code already exists!", "Invalid Code", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            iItem.Focus()
                            iItem.SelectAll()
                            Exit Sub
                        End If
                    End Using

                    myConn.Close()

                End Using

                'check duplicate package serial2
                Dim CheckQuery3 As String = "SELECT Name FROM tblItems WHERE PackageSerial = N'" & iiSerial2.Text & "' AND PackageSerial IS NOT NULL AND PackageSerial != ''"
                Using cmd = New SqlCommand(CheckQuery3, myConn)
                    If myConn.State = ConnectionState.Closed Then
                        myConn.Open()
                    End If

                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read() Then
                            myConn.Close()
                            MessageBox.Show("The entered package code already exists!", "Invalid Code", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            iiSerial2.Focus()
                            iiSerial2.SelectAll()
                            Exit Sub
                        End If
                    End Using

                    myConn.Close()

                End Using


                ' Add new Item to tblItems
                Dim category As String = iiCategory.SelectedValue
                If category = Nothing Then
                    category = "NULL"
                End If

                Dim Query As String = "INSERT INTO tblItems (Serial, Name, Price, [Minimum], PackageSerial, PackagePrice, PackageUnits, EnglishName, Category)" _
                                      & " VALUES ('" & iiSerial.Text.ToUpper & "', N'" & iiItem.Text.ToUpper & "', '" _
                                      & Val(iiPrice.Text) & "', '" & Val(iiMinimumQnty.Text) & "', N'" & iiSerial2.Text & "', '" & iiGroupPrice.Text _
                                      & "', '" & iiUnitNumber.Text & "', N'" & iiEnglishName.Text & "', " & category & ")"

                Using cmd = New SqlCommand(Query, myConn)
                    If myConn.State = ConnectionState.Closed Then
                        myConn.Open()
                    End If
                    cmd.ExecuteNonQuery()

                    myConn.Close()

                End Using

                Call AlterCodes(iiSerial.Text, iiAlterCodes.Text)


                'iiVendor.Text = Nothing
                iiSerial.Text = Nothing
                iiItem.Text = Nothing
                iiPrice.Text = Nothing
                iiSerial2.Text = Nothing
                iiGroupPrice.Text = Nothing
                iiUnitNumber.Text = Nothing
                iiAlterCodes.Text = Nothing
                iiMinimumQnty.Text = Nothing
                iiCategory.SelectedIndex = -1
                iiEnglishName.Text = ""
                iiSerial.Focus()
                'refill the items search

                Dim FillQuery As String = "SELECT PrKey, Serial, Name FROM tblItems" _
                                                          & " UNION ALL" _
                                                          & " SELECT tblItems.PrKey, tblMultiCodes.Code AS Serial, tblItems.Name" _
                                                          & " FROM tblMultiCodes INNER JOIN tblItems ON tblMultiCodes.Item = tblItems.PrKey" _
                                                          & " ORDER BY Name;"

                Using cmd = New SqlCommand(FillQuery, myConn)
                    If myConn.State = ConnectionState.Closed Then
                        myConn.Open()
                    End If
                    Dim adt As New SqlDataAdapter
                    Dim ds As New DataSet()
                    adt.SelectCommand = cmd
                    adt.Fill(ds)
                    adt.Dispose()

                    iiSearch.DataSource = ds.Tables(0)
                    iiSearch.DisplayMember = "Serial"
                    iiSearch.ValueMember = "PrKey"
                    iiSearch.Text = Nothing

                    myConn.Close()

                End Using

                Call Notification("Item Added!")

            End If
        ElseIf iiAdd.Text = "EDIT" Then
            If iiSerial.Text = "" Then
                MessageBox.Show("You must enter code!", "Empty Code", MessageBoxButtons.OK, MessageBoxIcon.Information)
                iiSerial.Focus()
            ElseIf iiItem.Text = "" Then
                MessageBox.Show("You must enter item name!", "Empty Item", MessageBoxButtons.OK, MessageBoxIcon.Information)
                iiItem.Focus()
            ElseIf Val(iiPrice.Text) = 0 Then
                MessageBox.Show("You must enter selling price!", "Invalid Price", MessageBoxButtons.OK, MessageBoxIcon.Information)
                iiPrice.Focus()
            ElseIf iiSerial2.Text <> "" And (Val(iiGroupPrice.Text) = 0 Or Val(iiUnitNumber.Text) = 0) Then
                If Val(iiGroupPrice.Text) = 0 Then
                    MessageBox.Show("You must enter package price!", "Invalid Price", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    iiGroupPrice.Focus()
                Else
                    MessageBox.Show("You must enter package units!", "Invalid Units", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    iiUnitNumber.Focus()
                End If
            ElseIf (Val(iiUnitNumber.Text) <> 0 AndAlso Val(iiGroupPrice.Text) = 0) Or (Val(iiUnitNumber.Text) = 0 AndAlso Val(iiGroupPrice.Text) <> 0) Then
                MessageBox.Show("You must enter package price!", "Invalid Price", MessageBoxButtons.OK, MessageBoxIcon.Information)
                iiGroupPrice.Focus()
            ElseIf (Val(iiPrice.Text) > Val(iiGroupPrice.Text)) And Not Val(iiGroupPrice.Text) = 0 Then
                MessageBox.Show("Package price must be greater than unit price!", "Invalid Price", MessageBoxButtons.OK, MessageBoxIcon.Information)
                iiGroupPrice.Focus()
            ElseIf (Val(iiGroupPrice.Text) / Val(iiUnitNumber.Text)) >= Val(iiPrice.Text) Then
                MessageBox.Show("Unit price in package must be less than unit price!", "Invalid Price", MessageBoxButtons.OK, MessageBoxIcon.Information)
                iiGroupPrice.Focus()

            Else


                'check duplicate serial
                Dim NQuery As String = "SELECT COUNT(*) FROM tblItems WHERE Serial = '" & iiSerial.Text & "' " _
                                       & " AND NOT tblItems.PrKey IN (" _
                                       & " SELECT tblItems.PrKey" _
                                       & " FROM tblItems LEFT OUTER JOIN tblMultiCodes" _
                                       & " ON tblItems.PrKey = tblMultiCodes.Item" _
                                       & " WHERE tblItems.Serial = '" & iiSearch.Text & "' OR tblMultiCodes.Code = '" & iiSearch.Text & "');"

                Using cmd = New SqlCommand(NQuery, myConn)
                    If myConn.State = ConnectionState.Closed Then
                        myConn.Open()
                    End If

                    'Using dr As SqlDataReader = cmd.ExecuteReader
                    If cmd.ExecuteScalar <> 0 Then
                        myConn.Close()
                        MessageBox.Show("The entered item name already exists!", "Invalid Name", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        iiSerial.Focus()
                        iiSerial.SelectAll()
                        Exit Sub
                    End If
                    'End Using

                    myConn.Close()

                End Using

                'check duplicate names
                Using cmd = New SqlCommand("SELECT Serial FROM tblItems WHERE Name = N'" & iiItem.Text & "' " _
                                           & " AND NOT tblItems.PrKey = (SELECT tblItems.PrKey FROM tblMultiCodes RIGHT OUTER JOIN tblItems ON tblMultiCodes.Item = tblItems.PrKey WHERE tblMultiCodes.Code = N'" & iiSearch.Text & "')", myConn)
                    If myConn.State = ConnectionState.Closed Then
                        myConn.Open()
                    End If

                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read() Then
                            myConn.Close()
                            MessageBox.Show("The entered item name already exists!", "Invalid Name", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            iItemName.Focus()
                            iItemName.SelectAll()
                            Exit Sub
                        End If
                    End Using

                    myConn.Close()

                End Using

                'check duplicate package serial2
                Dim CheckQuery3 As String = "SELECT Name FROM tblItems" _
                                            & " WHERE PackageSerial = N'" & iiSerial2.Text & "'" _
                                            & " AND PackageSerial IS NOT NULL" _
                                            & " AND PackageSerial != ''" _
                                            & " AND NOT PrKey = (" _
                                            & " SELECT tblItems.PrKey" _
                                            & " FROM tblMultiCodes RIGHT OUTER JOIN tblItems" _
                                            & " ON tblMultiCodes.Item = tblItems.PrKey" _
                                            & " WHERE tblMultiCodes.Code = N'" & iiSearch.Text & "' OR tblItems.Serial = N'" & iiSearch.Text & "')"
                Using cmd = New SqlCommand(CheckQuery3, myConn)
                    If myConn.State = ConnectionState.Closed Then
                        myConn.Open()
                    End If

                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read() Then
                            myConn.Close()
                            MessageBox.Show("The entered package code already exists!", "Invalid Code", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            iiSerial2.Focus()
                            iiSerial2.SelectAll()
                            Exit Sub
                        End If
                    End Using

                    myConn.Close()

                End Using





                ' Add new Item to tblItems
                Dim category As String = iiCategory.SelectedValue
                If category = Nothing Then
                    category = "NULL"
                End If

                Dim Query As String = "UPDATE tblItems SET Serial = '" & iiSerial.Text & "', Name = N'" & iiItem.Text _
                                      & "', Price = " & iiPrice.Text & ", [Minimum] = " & Val(iiMinimumQnty.Text) _
                                      & ", PackageSerial= N'" & iiSerial2.Text & "', PackagePrice = " & Val(iiGroupPrice.Text) _
                                      & ", PackageUnits = " & Val(iiUnitNumber.Text) & ", EnglishName = N'" & iiEnglishName.Text & "'" _
                                      & " , Category = " & category _
                                      & " WHERE PrKey IN (" _
                                      & " SELECT tblItems.PrKey FROM tblItems LEFT OUTER JOIN tblMultiCodes ON tblItems.PrKey = tblMultiCodes.Item" _
                                      & " WHERE tblItems.Serial = '" & iiSearch.Text & "' OR tblMultiCodes.Code = '" & iiSearch.Text & "');"

                Using cmd = New SqlCommand(Query, myConn)
                    If myConn.State = ConnectionState.Closed Then
                        myConn.Open()
                    End If
                    cmd.ExecuteNonQuery()
                    myConn.Close()

                End Using

                Call AlterCodes(iiSerial.Text, iiAlterCodes.Text)

                iiSearch.Text = iiSerial.Text
                iiSerial.Text = Nothing
                iiItem.Text = Nothing
                iiPrice.Text = Nothing
                iiMinimumQnty.Text = Nothing
                iiSerial2.Text = Nothing
                iiGroupPrice.Text = Nothing
                iiUnitNumber.Text = Nothing
                iiAlterCodes.Text = Nothing
                iiEnglishName.Text = Nothing
                iiCategory.SelectedIndex = -1
                iiSearch.Focus()
                iiSearch.SelectAll()

                'fill the items search
                Dim FillQuery As String = "SELECT PrKey, Serial, Name FROM tblItems" _
                                                  & " UNION ALL" _
                                                  & " SELECT tblItems.PrKey, tblMultiCodes.Code AS Serial, tblItems.Name" _
                                                  & " FROM tblMultiCodes INNER JOIN tblItems ON tblMultiCodes.Item = tblItems.PrKey" _
                                                  & " ORDER BY Name;"

                Using cmd = New SqlCommand(FillQuery, myConn)
                    If myConn.State = ConnectionState.Closed Then
                        myConn.Open()
                    End If
                    Dim adt As New SqlDataAdapter
                    Dim ds As New DataSet()
                    adt.SelectCommand = cmd
                    adt.Fill(ds)
                    adt.Dispose()

                    iiSearch.DataSource = ds.Tables(0)
                    iiSearch.DisplayMember = "Serial"
                    iiSearch.ValueMember = "PrKey"
                    iiSearch.Text = Nothing

                    myConn.Close()

                End Using
                Call Notification("Item Updated!")

            End If
        ElseIf iiAdd.Text = "DELETE" Then
            Dim dia As DialogResult
            dia = MessageBox.Show("Are you sure you want to delete the current item?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If dia = Windows.Forms.DialogResult.Yes Then
                Dim DelQuery As String = "DECLARE @PrKey INT;" _
                                         & " SET @prkey = (SELECT tblItems.PrKey FROM tblItems LEFT OUTER JOIN tblMultiCodes ON tblItems.PrKey = tblMultiCodes.Item" _
                                         & " WHERE tblItems.Serial = '" & iiSearch.Text & "' OR tblMultiCodes.Code = '" & iiSearch.Text & "');" _
                                         & " DELETE FROM tblMultiCodes WHERE Item = @PrKey;" _
                                         & " DELETE FROM tblItems WHERE PrKey = @PrKey"

                Using cmd = New SqlCommand(DelQuery, myConn)
                    If myConn.State = ConnectionState.Closed Then
                        myConn.Open()
                    End If
                    Try
                        cmd.ExecuteNonQuery()
                    Catch ex As Exception
                        MsgBox("The current item cannot be deleted as it's used in other transactions!")
                    End Try

                    myConn.Close()

                End Using
                'Call AlterCodes(iiSerial.Text, iiAlterCodes.Text)

                iiSerial.Text = Nothing
                iiItem.Text = Nothing
                iiPrice.Text = Nothing
                iiMinimumQnty.Text = Nothing
                iiSerial2.Text = Nothing
                iiGroupPrice.Text = Nothing
                iiUnitNumber.Text = Nothing
                iiAlterCodes.Text = Nothing
                iiEnglishName.Text = ""
                'fill the items search
                Dim FillQuery As String = "SELECT PrKey, Serial, Name FROM tblItems" _
                                                          & " UNION ALL" _
                                                          & " SELECT tblItems.PrKey, tblMultiCodes.Code AS Serial, tblItems.Name" _
                                                          & " FROM tblMultiCodes INNER JOIN tblItems ON tblMultiCodes.Item = tblItems.PrKey" _
                                                          & " ORDER BY Name;"

                Using cmd = New SqlCommand(FillQuery, myConn)
                    If myConn.State = ConnectionState.Closed Then
                        myConn.Open()
                    End If
                    Dim adt As New SqlDataAdapter
                    Dim ds As New DataSet()
                    adt.SelectCommand = cmd
                    adt.Fill(ds)
                    adt.Dispose()

                    iiSearch.DataSource = ds.Tables(0)
                    iiSearch.DisplayMember = "Serial"
                    iiSearch.ValueMember = "PrKey"
                    iiSearch.Text = Nothing

                    myConn.Close()
                End Using

                Call Notification("Item Deleted!")

            End If
        End If
    End Sub

    Private Sub iiClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles iiClear.Click

        iiSerial.Text = Nothing
        iiItem.Text = Nothing
        iiPrice.Text = Nothing
        iiMinimumQnty.Text = Nothing
        iiSerial2.Text = Nothing
        iiGroupPrice.Text = Nothing
        iiUnitNumber.Text = Nothing
        iiAlterCodes.Text = Nothing
        iiEnglishName.Text = Nothing
        iiCategory.SelectedIndex = -1
        Call Notification("Record Cleared!")

    End Sub

    Private Sub iiSearch_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles iiSearch.SelectedIndexChanged
        If iiSearch.Text <> "" Then
            Dim NQuery As String = "SELECT tblItems.* FROM tblItems LEFT OUTER JOIN tblMultiCodes ON tblItems.PrKey = tblMultiCodes.Item" _
                                      & " WHERE tblItems.Serial = '" & iiSearch.Text & "' OR tblMultiCodes.Code = '" & iiSearch.Text & "';"
            Using cmd = New SqlCommand(NQuery, myConn)
                If myConn.State = ConnectionState.Closed Then
                    myConn.Open()
                End If

                Dim ds As New DataSet()
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(ds, "tblItems")
                Dim dt As New DataTable
                dt = ds.Tables(0)

                Try
                    iiSerial.Text = dt.Rows(0)(1).ToString
                    iiItem.Text = dt.Rows(0)(2).ToString
                    iiPrice.Text = dt.Rows(0)(3).ToString
                    If Not IsDBNull(dt.Rows(0)(4)) Then
                        iiCategory.SelectedValue = dt.Rows(0)(4)
                    Else
                        iiCategory.SelectedIndex = -1
                    End If
                    iiMinimumQnty.Text = dt.Rows(0)(5).ToString
                    iiSerial2.Text = dt.Rows(0)(6).ToString
                    iiGroupPrice.Text = dt.Rows(0)(7).ToString
                    iiUnitNumber.Text = dt.Rows(0)(8).ToString
                    iiEnglishName.Text = dt.Rows(0)(9).ToString

                Catch ex As Exception

                End Try


                Try
                    cmd.CommandText = "SELECT Code + ';' FROM tblMultiCodes WHERE Item = " & dt(0)(0).ToString & " FOR XML PATH('');"
                    iiAlterCodes.Text = cmd.ExecuteScalar
                Catch ex As Exception
                    iiAlterCodes.Text = ""
                End Try
                myConn.Close()
            End Using
        Else
            iiSerial.Text = Nothing
            iiItem.Text = Nothing
            iiPrice.Text = Nothing
            iiSerial2.Text = Nothing
            iiGroupPrice.Text = Nothing
            iiUnitNumber.Text = Nothing
            iiAlterCodes.Text = Nothing
            iiEnglishName.Text = Nothing
            iiMinimumQnty.Text = Nothing
            iiCategory.SelectedIndex = -1
        End If
    End Sub

    Private Sub iiRdModify_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles iiRdModify.CheckedChanged
        If iiRdNew.Checked Then
            iiAdd.Text = "SAVE"
            iiSearch.Visible = False
        ElseIf iiRdModify.Checked = True Then
            iiAdd.Text = "EDIT"
            iiSearch.Visible = True
            iiSearch.Text = Nothing
        ElseIf iiRdDelete.Checked = True Then
            iiAdd.Text = "DELETE"
            iiSearch.Visible = True
            iiSearch.Text = Nothing
        End If
    End Sub

    Private Sub iiRdDelete_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles iiRdDelete.CheckedChanged
        If iiRdNew.Checked Then
            iiAdd.Text = "SAVE"
            iiSearch.Visible = False
        ElseIf iiRdModify.Checked = True Then
            iiAdd.Text = "EDIT"
            iiSearch.Visible = True
            iiSearch.Text = Nothing
        ElseIf iiRdDelete.Checked = True Then
            iiAdd.Text = "DELETE"
            iiSearch.Visible = True
            iiSearch.Text = Nothing
        End If
    End Sub


    Private Sub KryptonRibbonGroupButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KryptonRibbonGroupButton1.Click
        Call RibbonClear()
        KryptonRibbonGroupButton1.Checked = True
        KryptonDockableNavigator1.SelectedIndex = 0
    End Sub

    Private Sub KryptonRibbonGroupButton8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KryptonRibbonGroupButton8.Click
        frmCurrency.ShowDialog()
    End Sub

    Private Sub KryptonRibbonGroupButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KryptonRibbonGroupButton3.Click
        Call RibbonClear()
        KryptonRibbonGroupButton3.Checked = True
        KryptonDockableNavigator1.SelectedIndex = 2
    End Sub

    Private Sub KryptonRibbonGroupButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KryptonRibbonGroupButton4.Click
        Call RibbonClear()
        KryptonRibbonGroupButton4.Checked = True
        KryptonDockableNavigator1.SelectedIndex = 3
    End Sub

    Private Sub krInvoice_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles krInvoice.Click
        ExClass.Invoice(krSerial.Text, False)
    End Sub

    Private Sub krPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles krPrint.Click
        ExClass.Invoice(krSerial.Text, True)
    End Sub

    Private Sub isSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles isSearch.Click
        Cursor = Cursors.WaitCursor
        Dim fDate, SDate As String
        If isDateFrom.Checked = True Then
            fDate = isDateFrom.Value.ToString("MM/dd/yyyy")
        Else
            fDate = "01/01/1999"
        End If
        If isDateTill.Checked = True Then
            SDate = isDateTill.Value.ToString("MM/dd/yyyy")
        Else
            SDate = "01/01/2500"
        End If

        Dim Vndr As String
        If isVendor.Text = "" Then
            Vndr = ""
        Else
            Vndr = " AND tblIn1.Vendor = '" & isVendor.SelectedValue & "'"
        End If

        'Dim Query As String = "SELECT tblVendors.Name AS Vendor, tblItems.Serial, tblItems.Name AS Item, SUM(tblIn2.Qnty) AS Qnty, AVG(tblIn2.UnitPrice) AS UnitAverage, SUM(tblIn2.[Value]) AS [Value]" _
        '                      & " FROM tblItems INNER JOIN tblIn2 ON tblItems.PrKey = tblIn2.Item" _
        '                      & " INNER JOIN tblIn1 ON tblIn1.PrKey = tblIn2.Serial" _
        '                      & " INNER JOIN tblVendors ON tblin1.Vendor = tblVendors.Sr" _
        '                      & " WHERE (tblIn1.[Date] BETWEEN '" & fDate & "' AND '" & SDate & "')" _
        '                      & Vndr _
        '                      & " GROUP BY tblvendors.Name, tblItems.Serial, tblItems.Name" _
        '                      & " ORDER BY tblItems.Name"

        Dim Query As String = "SELECT tblItems.Serial AS Code, tblItems.Name AS Item, SUM(tblIn2.Qnty) AS Qnty, SUM(tblIn2.Sold) AS Sold, tblIn2.UnitPrice AS Price, SUM(tblIn2.[Value]) AS [Value]" _
            & " FROM tblIn2" _
            & " INNER JOIN tblItems ON tblIn2.Item = tblItems.PrKey" _
            & " INNER JOIN tblIn1 ON tblIn2.Serial = tblIn1.PrKey" _
            & " INNER JOIN tblVendors ON tblVendors.Sr = tblIn1.Vendor" _
            & " WHERE (tblIn1.[Date] BETWEEN '" & fDate & "' AND '" & SDate & "')" _
            & Vndr _
            & " GROUP BY tblItems.Serial, tblItems.Name, tblIn2.UnitPrice" _
            & " ORDER BY tblItems.Name;"

        Dim ds As New ReportsDS
        Dim da As New SqlDataAdapter(Query, myConn)
        da.Fill(ds.Tables("tblIn"))

        Dim Report As New XtraIn
        Report.DataSource = ds
        Report.DataAdapter = da
        Report.DataMember = "tblIn"


        If isVendor.Text = "" Then
            Report.XrVendor.Text = ""
            Report.XrVendorName.Text = ""
        Else
            Report.XrVendor.Text = "Vendor:"
            Report.XrVendorName.Text = isVendor.Text
        End If

        If isDateFrom.Checked = True Then
            Report.XrFrom.Text = "From:"
            Report.XrFromDate.Text = isDateFrom.Value.ToString("dd/MM/yyyy")
        Else
            Report.XrFrom.Text = ""
            Report.XrFromDate.Text = ""
        End If
        If isDateTill.Checked = True Then
            Report.XrHeader.Text = "Till:"
            Report.XrTillDate.Text = isDateTill.Value.ToString("dd/MM/yyyy")
        Else
            Report.XrTill.Text = ""
            Report.XrTillDate.Text = ""
        End If

        Report.CreateDocument()
        Cursor = Cursors.Default
        Report.ShowPreview()


    End Sub

    Private Sub KryptonButton9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KryptonButton9.Click
        Cursor = Cursors.WaitCursor
        Dim fDate, SDate As String

        If osDateFrom.Checked = True Then
            fDate = osDateFrom.Value.ToString("MM/dd/yyyy") & " " & osTimeFrom.Value.ToString("HH:mm") & ":00.000"
        Else
            fDate = "01/01/1999 00:00:00.000"
        End If
        If osDateTill.Checked = True Then
            SDate = osDateTill.Value.ToString("MM/dd/yyyy") & " " & osTimeTill.Value.ToString("HH:mm") & ":00.000"
        Else
            SDate = "01/01/2500 23:59:59.999"
        End If

        Dim exp As String
        If KryptonCheckBox2.Checked = False Then
            exp = " AND tblOut2.Price != 0 "
        Else
            exp = " AND tblOut2.Price = 0 "
        End If

        Dim itmm As String = ""
        If osItem.Text <> "" Then
            itmm = " AND tblItems.Name LIKE N'%" & osItem.Text & "%'"
        Else
            If osCode.Text <> "" Then
                itmm = " AND tblItems.Serial LIKE N'%" & osCode.Text & "%'"
            End If
        End If



        Dim Query As String = "SELECT tblItems.Serial AS Code, tblItems.Name AS Item, tblOut2.CostPrice AS Cost, (tblOut2.Price / tblOut2.Qnty) AS Selling," _
            & " SUM(tblOut2.Qnty) AS Sold, SUM(tblOut2.Price) AS [ValueUSD], SUM(tblOut2.Price * dbo.curCurrency(tblOut1.[Date], tblOut1.[Time])) AS [ValueEGP]," _
            & " dbo.curCurrency(tblOut1.[Date], tblOut1.[Time]) AS Rate," _
            & " SUM(tblOut2.Price * dbo.curCurrency(tblOut1.[Date], tblOut1.[Time]) - (tblOut2.CostPrice * tblOut2.Qnty)) AS Profit" _
            & " FROM tblOut2" _
            & " INNER JOIN tblItems ON tblOut2.Item = tblItems.PrKey" _
            & " INNER JOIN tblOut1 ON tblOut2.Serial = tblOut1.Serial" _
            & " WHERE (tblOut1.[Date] + tblOut1.[Time]) BETWEEN '" & fDate & "' AND '" & SDate & "'" _
            & exp & itmm _
            & " GROUP BY tblItems.Serial, tblItems.Name, tblOut2.CostPrice, (tblOut2.Price / tblOut2.Qnty), dbo.curCurrency(tblOut1.[Date], tblOut1.[Time])" _
            & " ORDER BY tblItems.Name;"

        Query = "SELECT tblItems.Serial AS Code, tblItems.Name AS Item, tblIn2.UnitPrice AS CostEGP, dbo.CurCurrency(tblOut1.[Date], tblOut1.[Time]) AS Rate," _
            & " (tblIn2.UnitPrice / dbo.CurCurrency(tblOut1.[Date], tblOut1.[Time])) AS Cost, SUM(tblOut2.Qnty) AS Sold," _
            & " (tblOut2.Price / tblOut2.Qnty) AS Selling, SUM(tblOut2.Price) AS Value, (SUM(tblOut2.Price) * 0.65) AS Deduction," _
            & " ((SUM(tblOut2.Price) * 0.65) - (tblIn2.UnitPrice / dbo.CurCurrency(tblOut1.[Date], tblOut1.[Time]) * SUM(tblOut2.Qnty))) AS Profit" _
            & " FROM tblOut2" _
            & " INNER JOIN tblItems ON tblOut2.Item = tblItems.PrKey" _
            & " INNER JOIN tblIn2 ON tblOut2.SoldItem = tblIn2.PrKey" _
            & " INNER JOIN tblOut1 ON tblOut2.Serial = tblOut1.Serial" _
            & " WHERE (tblOut1.[Date] + tblOut1.[Time]) BETWEEN '" & fDate & "' AND '" & SDate & "'" _
            & exp & itmm _
            & " GROUP BY tblItems.Serial, tblItems.Name, tblIn2.UnitPrice, dbo.CurCurrency(tblOut1.[Date], tblOut1.[Time])," _
            & " (tblIn2.UnitPrice / dbo.CurCurrency(tblOut1.[Date], tblOut1.[Time])), (tblOut2.Price / tblOut2.Qnty)" _
            & " ORDER BY tblItems.Name;"

        Dim ds As New ReportsDS
        Dim da As New SqlDataAdapter(Query, myConn)
        da.Fill(ds.Tables("tblOut"))

        Dim Report As New XtraOut
        Report.DataSource = ds
        Report.DataAdapter = da
        Report.DataMember = "tblOut"


        If ossAgent.Text = Nothing Then
            Report.XrCustomer.Text = ""
            Report.XrCustomerName.Text = ""
        Else
            Report.XrCustomer.Text = "Cusomter:"
            Report.XrCustomerName.Text = ossAgent.Text.ToUpper
        End If

        If osDateFrom.Checked = True Then
            Report.XrFrom.Text = "From:"
            Report.XrFromDate.Text = osDateFrom.Value.ToString("yyyy/MM/dd") & " " & osTimeFrom.Value.ToString("HH:mm")
        Else
            Report.XrFrom.Text = ""
            Report.XrFromDate.Text = ""
        End If
        If osDateTill.Checked = True Then
            Report.XrTill.Text = "Till:"
            Report.XrTillDate.Text = osDateTill.Value.ToString("yyyy/MM/dd") & " " & osTimeTill.Value.ToString("HH:mm")
        Else
            Report.XrTill.Text = ""
            Report.XrTillDate.Text = ""
        End If
        Report.CreateDocument()
        Cursor = Cursors.Default

        Report.ShowPreview()


    End Sub

    Private Sub siSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles siSearch.Click
        Cursor = Cursors.WaitCursor
        Dim fDate, SDate As String
        If siDateFrom.Checked = True Then
            fDate = siDateFrom.Value.ToString("MM/dd/yyyy")
        Else
            fDate = "01/01/1999"
        End If
        If siDateTill.Checked = True Then
            SDate = siDateTill.Value.ToString("MM/dd/yyyy")
        Else
            SDate = "01/01/2500"
        End If

        Dim qnty1, qnty2 As Double
        qnty1 = Val(siQntyFrom.Text)
        qnty2 = Val(siQntyTill.Text)

        Dim quan As String = ""

        If siQntyFrom.Text <> "" And siQntyTill.Text <> "" Then
            quan = "AND (TIn.QIn - COALESCE(TOut.QOut, 0) BETWEEN '" & qnty1 & "' AND '" & qnty2 & "')"
        ElseIf siQntyFrom.Text <> "" And siQntyTill.Text = "" Then
            quan = "AND (TIn.QIn - COALESCE(TOut.QOut, 0) >= '" & qnty1 & "')"
        ElseIf siQntyFrom.Text = "" And siQntyTill.Text <> "" Then
            quan = "AND (TIn.QIn - COALESCE(TOut.QOut, 0) <= '" & qnty2 & "')"
        Else
            quan = ""
        End If

        Dim itm As String

        If siItem.Text = "" Then
            itm = ""
        Else
            itm = " AND (tblItems.Name LIKE N'%" & siItem.Text & "%')"
        End If

        Dim needed As String
        If KryptonCheckBox1.Checked = False Then
            needed = ""
        Else
            needed = " AND (TIn.QIn - COALESCE(TOut.QOut, 0) < tblItems.[Minimum])"
        End If



        If quan <> "" And itm <> "" Then
            MessageBox.Show("If you want to check a definite item, you should clear the quantity!", "Wrong Criteria", MessageBoxButtons.OK, MessageBoxIcon.Information)
            siItem.Focus()
            Exit Sub
        End If

        Dim Query As String = "SELECT tblItems.Serial, tblItems.Name AS Item, tblItems.Price, tblItems.[Minimum], TIn.QIn AS T_In, COALESCE(TOut.QOut, 0) AS T_Out, TIn.QIn - COALESCE(TOut.QOut, 0) AS Net, (CASE WHEN ( TIn.QIn - COALESCE(TOut.QOut, 0)) < tblItems.[Minimum] THEN 'Yes' ELSE 'No' END) as [Needed], (tblItems.Price * (TIn.QIn - COALESCE(TOut.QOut, 0))) AS tValue" _
                              & " FROM tblItems" _
                              & " INNER Join" _
                              & " (" _
                              & " SELECT tblIn2.Item, SUM(tblIn2.Qnty) AS QIn" _
                              & " FROM tblIn2 INNER JOIN tblIn1" _
                              & " ON tblIn2.Serial = tblIn1.PrKey" _
                              & " WHERE tblIn1.[Date] BETWEEN '" & fDate & "' AND '" & SDate & "'" _
                              & " GROUP BY tblIn2.Item" _
                              & " ) TIn" _
                              & " ON TIn.Item = tblItems.PrKey" _
                              & " LEFT OUTER JOIN" _
                              & " (" _
                              & " SELECT tblOut2.Item, SUM(tblOut2.Qnty) AS QOut" _
                              & " FROM tblOut2 INNER JOIN tblOut1" _
                              & " ON tblOut2.Serial = tblOut1.Serial" _
                              & " WHERE tblOut1.[Date] BETWEEN '" & fDate & "' AND '" & SDate & "'" _
                              & " GROUP BY tblOut2.Item" _
                              & " ) TOut" _
                              & " ON TOut.Item = tblItems.PrKey WHERE 1=1 " _
                              & quan & itm & needed _
                              & " ORDER BY tblItems.Name"


        Dim ds As New ReportsDS
        Dim da As New SqlDataAdapter(Query, myConn)
        da.Fill(ds.Tables("tblItems"))

        Dim Report As New XtraItems
        Report.DataSource = ds
        Report.DataAdapter = da
        Report.DataMember = "tblItems"



        If siDateFrom.Checked = True Then
            Report.XrFrom.Text = "From:"
            Report.XrFromDate.Text = siDateFrom.Value.ToString("yyyy/MM/dd")
        Else
            Report.XrFrom.Text = ""
            Report.XrFromDate.Text = ""
        End If
        If siDateTill.Checked = True Then
            Report.XrTill.Text = "Till:"
            Report.XrTillDate.Text = siDateTill.Value.ToString("yyyy/MM/dd")
        Else
            Report.XrTill.Text = ""
            Report.XrTillDate.Text = ""
        End If
        Report.CreateDocument()
        Cursor = Cursors.Default

        Report.ShowPreview()


    End Sub

    Private Sub monSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles monSearch.Click
        If monItem.Text = "" Then
            MessageBox.Show("You should choose item name!", "No Item", MessageBoxButtons.OK, MessageBoxIcon.Information)
            monItem.Focus()
        Else
            Dim Que As String
            Cursor = Cursors.WaitCursor
            Que = "SELECT tblIn1.[Date], 'PURCHASE' AS [Type], CONVERT(NVARCHAR(5), tblIn1.[Time], 108) AS Time, tblIn2.Item, tblIn2.Qnty, tblIn2.UnitPrice, tblIn2.[Value]" _
                & " FROM tblIn2 INNER JOIN tblIn1 ON tblIn2.Serial = tblIn1.PrKey" _
                & " INNER JOIN tblItems ON tblItems.PrKey = tblIn2.Item" _
                & " WHERE tblItems.Name = N'" & monItem.Text & "'" _
                & " AND  tblIn1.[Date] BETWEEN '" & monDateFrom.Value.ToString("MM/dd/yyyy") & "' AND '" & monDateTill.Value.ToString("MM/dd/yyyy") & "'" _
                & " UNION ALL" _
                & " SELECT tblOut1.[Date], 'SELLING' AS [Type], CONVERT(NVARCHAR(5), tblOut1.[Time], 108) AS [Time], tblOut2.Item, tblOut2.Qnty, tblOut2.UnitPrice, tblOut2.Price AS [Value]" _
                & " FROM tblOut2 INNER JOIN tblOut1 ON tblOut2.Serial = tblOut1.Serial" _
                & " INNER JOIN tblItems ON tblItems.PrKey = tblOut2.Item" _
                & " WHERE tblItems.Name LIKE N'%" & monItem.Text & "%'" _
                & " AND  tblOut1.[Date] BETWEEN '" & monDateFrom.Value.ToString("MM/dd/yyyy") & "' AND '" & monDateTill.Value.ToString("MM/dd/yyyy") & "'" _
                & " ORDER BY [Date], [Time]"



            Dim ds As New ReportsDS
            Dim da As New SqlDataAdapter(Que, myConn)
            da.Fill(ds.Tables("tblItemMonitor"))
            myConn.Close()

            Dim Report As New XtraItemMonitor
            Report.DataSource = ds
            Report.DataAdapter = da
            Report.DataMember = "tblItemMonitor"


            Report.XrFromDate.Text = monDateFrom.Value.ToString("yyyy/MM/dd")
            Report.XrTillDate.Text = monDateTill.Value.ToString("yyyy/MM/dd")

            Report.XrLabel1.Text = monItem.Text

            Report.CreateDocument()
            Cursor = Cursors.Default

            Report.ShowPreview()


        End If
    End Sub

    Private Sub dailySearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dailySearch.Click

        If cbSelling.Checked = False AndAlso cbBuying.Checked = False AndAlso cbCash.Checked = False AndAlso cbPayment.Checked = False Then
            MsgBox("Please select at least one field to get the report!")
            cbSelling.Focus()
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor

        Dim Cashier As String = ""
        If cbCashiers.Text <> "" Then
            Cashier = " AND (tblLogin.UserName = N'" & cbCashiers.Text & "')"
        End If

        Dim timFrom, timTill As String
        timFrom = dailyDateFrom.Value.ToString("MM/dd/yyyy") & " " & tmFrom.Value.ToString("HH:mm") & ":00.000"
        timTill = dailyDateTill.Value.ToString("MM/dd/yyyy") & " " & tmTill.Value.ToString("HH:mm") & ":59.999"

        Dim qSelling As String = ""
        Dim qBuying As String = ""
        Dim qPayment As String = ""
        Dim qCash As String = ""

        If cbSelling.Checked Then
            qSelling = " SELECT tblOut1.[Date], CONVERT(NVARCHAR(5), tblOut1.[Time], 108) AS [Time]," _
                & " CONVERT(NVARCHAR(20), tblOut1.Serial) AS Indication, 'SELLING' AS [Type]," _
                & " tblOut1.pUSD - tblOut1.cUSD AS USD, tblOut1.pEGP - tblOut1.cEGP AS EGP, tblOut1.pRUB - tblOut1.cRUB AS RUB," _
                & " tblOut1.pEUR - tblOut1.cEUR AS EUR, tblOut1.pUAH - tblOut1.cUAH AS UAH, tblOut1.pGBP - tblOut1.cGBP AS GBP," _
                & " tblOut1.pVisa AS Visa, tblLogin.UserName AS [User]" _
                & " FROM tblOut1 INNER JOIN tblLogin ON tblLogin.Sr = tblOut1.[User]" _
                & " WHERE (tblOut1.[Date] + tblOut1.[Time] BETWEEN '" & timFrom & "' AND '" & timTill & "')" & Cashier _
                & " UNION ALL "
        End If

        If cbBuying.Checked Then
            qBuying = " SELECT tblIn1.[Date], CONVERT(NVARCHAR(5), tblIn1.[Time], 108) AS [Time]," _
                & " tblIn1.Serial AS Indication, 'PURCHASE' AS [Type], 0 AS USD, 0 - tblDebit.Amount AS EGP, 0 AS RUB, 0 AS EUR, 0 AS UAH, 0 AS GBP, 0 AS Visa," _
                & " tblLogin.UserName AS [User]" _
                & " FROM tblIn1 INNER JOIN tblDebit ON tblDebit.Serial = tblIn1.PrKey" _
                & " AND tblDebit.[Date] = tblIn1.[Date] AND tblIn1.[Time] = tblDebit.[Time]" _
                & " INNER JOIN tblLogin ON tblLogin.Sr = tblIn1.[User]" _
                & " WHERE (tblIn1.[Date] + tblIn1.[Time] BETWEEN '" & timFrom & "' AND '" & timTill & "')" & Cashier _
                & " UNION ALL "
        End If

        If cbPayment.Checked Then
            qPayment = " SELECT tblDebit.[Date], CONVERT(NVARCHAR(5), tblDebit.[Time], 108) AS [Time]," _
                & " tblIn1.Serial AS Indication, 'PAYMENT' AS [Type], 0 AS USD, 0 - tblDebit.Amount AS EGP, 0 AS RUB, 0 AS EUR, 0 AS UAH, 0 AS GBP, 0 AS Visa," _
                & " tblLogin.UserName AS [User]" _
                & " FROM tblDebit RIGHT OUTER JOIN tblIn1 ON tblDebit.Serial = tblIn1.PrKey" _
                & " INNER JOIN tblLogin ON tblLogin.Sr = tblDebit.[User]" _
                & " WHERE (tblDebit.[Date] != tblIn1.[Date] OR tblDebit.[Time] != tblIn1.[Time])" _
                & " AND (tblDebit.[Date] + tblDebit.[Time] BETWEEN '" & timFrom & "' AND '" & timTill & "')" & Cashier _
                & " UNION ALL "
        End If

        If cbCash.Checked Then
            qCash = " SELECT tblCash.[Date] AS [Date], CONVERT(NVARCHAR(5), tblCash.[Time], 108) AS [Time], tblCash.Indication, tblCash.[Type]," _
                & " (CASE WHEN tblCash.Currency = 0	AND (tblCash.[Type] = 'IMPORTS' OR tblCash.[Type] = 'EX TO') THEN tblCash.Qnty WHEN tblCash.Currency = 0 AND tblCash.[Type] != 'IMPORTS' AND tblCash.[Type] != 'EX TO' THEN - tblCash.Qnty ELSE 0 END) AS USD, " _
                & " (CASE WHEN tblCash.Currency = 2	AND (tblCash.[Type] = 'IMPORTS' OR tblCash.[Type] = 'EX TO') THEN tblCash.Qnty WHEN tblCash.Currency = 2 AND tblCash.[Type] != 'IMPORTS' AND tblCash.[Type] != 'EX TO' THEN - tblCash.Qnty ELSE 0 END) AS EGP, " _
                & " (CASE WHEN tblCash.Currency = 4	AND (tblCash.[Type] = 'IMPORTS' OR tblCash.[Type] = 'EX TO') THEN tblCash.Qnty WHEN tblCash.Currency = 4 AND tblCash.[Type] != 'IMPORTS' AND tblCash.[Type] != 'EX TO' THEN - tblCash.Qnty ELSE 0 END) AS RUB, " _
                & " (CASE WHEN tblCash.Currency = 1	AND (tblCash.[Type] = 'IMPORTS' OR tblCash.[Type] = 'EX TO') THEN tblCash.Qnty WHEN tblCash.Currency = 1 AND tblCash.[Type] != 'IMPORTS' AND tblCash.[Type] != 'EX TO' THEN - tblCash.Qnty ELSE 0 END) AS EUR, " _
                & " (CASE WHEN tblCash.Currency = 5	AND (tblCash.[Type] = 'IMPORTS' OR tblCash.[Type] = 'EX TO') THEN tblCash.Qnty WHEN tblCash.Currency = 5 AND tblCash.[Type] != 'IMPORTS' AND tblCash.[Type] != 'EX TO' THEN - tblCash.Qnty ELSE 0 END) AS UAH, " _
                & " (CASE WHEN tblCash.Currency = 3	AND (tblCash.[Type] = 'IMPORTS' OR tblCash.[Type] = 'EX TO') THEN tblCash.Qnty WHEN tblCash.Currency = 3 AND tblCash.[Type] != 'IMPORTS' AND tblCash.[Type] != 'EX TO' THEN - tblCash.Qnty ELSE 0 END) AS GBP, " _
                & " 0 AS Visa, tblLogin.UserName AS [User]" _
                & " FROM tblCash INNER JOIN tblLogin ON tblCash.[User] = tblLogin.Sr" _
                & " WHERE (tblCash.[Date] + tblCash.[Time] BETWEEN '" & timFrom & "' AND '" & timTill & "')" & Cashier _
                & " UNION ALL "
        End If

        Dim Query As String = "(" & qSelling & qBuying & qPayment & qCash
        Query = Query.Substring(0, Query.Length - 11)
        Query &= " ) ORDER BY [Date], [Time]"
        
        Dim ds As New ReportsDS
        Dim da As New SqlDataAdapter(Query, myConn)
        da.Fill(ds.Tables("tblDaily"))

        Dim Report As New XtraDaily
        Report.DataSource = ds
        Report.DataAdapter = da
        Report.DataMember = "tblDaily"



        Report.XrFromDate.Text = dailyDateFrom.Value.ToString("yyyy/MM/dd") & " " & tmFrom.Value.ToString("HH:mm")
        Report.XrTillDate.Text = dailyDateTill.Value.ToString("yyyy/MM/dd") & " " & tmTill.Value.ToString("HH:mm")
        If cbCashiers.Text = "" Then
            Report.XrCashier.Text = ""
            Report.XrCashierName.Text = ""
        Else
            Report.XrCashier.Text = "Cashier:"
            Report.XrCashierName.Text = cbCashiers.Text
        End If
        Report.CreateDocument()
        Cursor = Cursors.Default

        Report.ShowPreview()
    End Sub

    Private Sub inReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles inReport.Click
        Call RibbonClear()
        inReport.Checked = True
        KryptonDockableNavigator1.SelectedIndex = 5
    End Sub

    Private Sub outReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles outReport.Click
        Call RibbonClear()
        outReport.Checked = True
        KryptonDockableNavigator1.SelectedIndex = 6
    End Sub

    Private Sub itemReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles itemReport.Click
        Call RibbonClear()
        itemReport.Checked = True
        KryptonDockableNavigator1.SelectedIndex = 7
    End Sub

    Private Sub itemMonitor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles itemMonitor.Click
        Call RibbonClear()
        itemMonitor.Checked = True
        KryptonDockableNavigator1.SelectedIndex = 8
    End Sub

    Private Sub totalMonitor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles totalMonitor.Click
        Call RibbonClear()
        totalMonitor.Checked = True
        KryptonDockableNavigator1.SelectedIndex = 9
    End Sub

    Private Sub dailyMonitor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dailyMonitor.Click
        Call RibbonClear()
        dailyMonitor.Checked = True
        KryptonDockableNavigator1.SelectedIndex = 10
    End Sub

    Private Sub btnChangePassword_Click(sender As System.Object, e As System.EventArgs) Handles btnChangePassword.Click
        frmPassword.ShowDialog()
    End Sub

    Private Sub kryptonContextMenuItem1_Click(sender As Object, e As System.EventArgs) Handles kryptonContextMenuItem1.Click
        Application.Exit()
    End Sub

    Private Sub cSave_Click(sender As System.Object, e As System.EventArgs) Handles cSave.Click
        If Val(cSum.Text) = 0 Then
            MessageBox.Show("You have entered invalid amount!", "Wrong Amount", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cSum.Focus()
            cSum.SelectAll()
        ElseIf cIndication.Text = "" AndAlso cIndication.Visible = True Then
            MessageBox.Show("You must fill in indication!", "Wrong Indication", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cIndication.Focus()
            cIndication.SelectAll()
        ElseIf cSumTo.Visible = True AndAlso Val(cSumTo.Text) = 0 Then
            MessageBox.Show("You must fill in the exchanged amount!", "Wrong Amount", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cSumTo.Focus()
            cSumTo.SelectAll()
        ElseIf cCurrencyTo.Visible = True AndAlso cCurrencyTo.SelectedIndex = cCurrency.SelectedIndex Then
            MessageBox.Show("You should select a different currency!", "Wrong Currency", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cCurrencyTo.Focus()
        Else
            Dim tp As String
            If RadioGroup1.SelectedIndex = 0 Then
                tp = "IMPORTS"
            ElseIf RadioGroup1.SelectedIndex = 1 Then
                tp = "EXPORTS"
            Else
                tp = "EXCHANGE"
            End If
            Dim Query As String
            If tp = "EXCHANGE" Then
                Query = "INSERT INTO tblCash ([Type], [Date], [Time], Qnty, Indication, [User], Currency)" _
                                  & " VALUES ('EX FROM', '" & Today.ToString("MM/dd/yyyy") & "', '" & Now.ToString("HH:mm") & "', '" & Val(cSum.Text) & "', 'Exchange from " & cCurrency.Text & " To " & cCurrencyTo.Text & "','" & GlobalVariables.ID & "', " & cCurrency.SelectedIndex & ")," _
                                  & " ('EX TO', '" & Today.ToString("MM/dd/yyyy") & "', '" & Now.ToString("HH:mm") & "', '" & Val(cSumTo.Text) & "', 'Exchange from " & cCurrency.Text & " To " & cCurrencyTo.Text & "','" & GlobalVariables.ID & "', " & cCurrencyTo.SelectedIndex & ");"
            Else
                Query = "INSERT INTO tblCash ([Type], [Date], [Time], Qnty, Indication, [User], Currency)" _
                                  & " VALUES (N'" & tp & "', '" & Today.ToString("MM/dd/yyyy") & "', '" & Now.ToString("HH:mm") & "', '" & Val(cSum.Text) & "', @Indication,'" & GlobalVariables.ID & "', " & cCurrency.SelectedIndex & ")"
            End If

            Using cmd = New SqlCommand(Query, myConn)
                cmd.Parameters.AddWithValue("@Indication", cIndication.Text)
                If myConn.State = ConnectionState.Closed Then
                    myConn.Open()
                End If
                cmd.ExecuteNonQuery()
                myConn.Close()

                cSum.Text = ""
                cIndication.Text = ""
                cSum.Focus()
                Call SearchCash()
            End Using
        End If
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As System.Object, e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        Call SearchCash()
    End Sub

    Private Sub cEdit_Click(sender As System.Object, e As System.EventArgs) Handles cEdit.Click
        Dim dia As DialogResult = MessageBox.Show("Are you sure you want to modify this record?", "Modify", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If dia = Windows.Forms.DialogResult.Yes Then

            If Val(cSum.Text) = 0 Then
                MessageBox.Show("You have entered invalid amount!", "Wrong Amount", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cSum.Focus()
                cSum.SelectAll()
            ElseIf cIndication.Text = "" AndAlso cIndication.Visible = True Then
                MessageBox.Show("You must fill in indication!", "Wrong Indication", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cIndication.Focus()
                cIndication.SelectAll()
            Else

                Dim tp As String
                If RadioGroup1.SelectedIndex = 0 Then
                    tp = "IMPORTS"
                ElseIf RadioGroup1.SelectedIndex = 1 Then
                    tp = "EXPORTS"
                Else
                    MsgBox("You cannot edit exchange transactions, you should delete it and add a new transaction!")
                    Exit Sub
                End If

                Dim PrKey As Integer = CashDGV.CurrentRow.Cells(0).Value
                Dim Query As String = "UPDATE tblCash SET [Type] = N'" & tp & "', Qnty = '" & Val(cSum.Text) & "', Indication = N'" & cIndication.Text & "', [User] = '" & GlobalVariables.ID & "' WHERE PrKey = '" & PrKey & "'"
                Using cmd = New SqlCommand(Query, myConn)
                    If myConn.State = ConnectionState.Closed Then
                        myConn.Open()
                    End If
                    cmd.ExecuteNonQuery()
                    myConn.Close()
                End Using
            End If
            SearchCash()
        End If
    End Sub

    Private Sub cDelete_Click(sender As System.Object, e As System.EventArgs) Handles cDelete.Click
        Dim dia As DialogResult = MessageBox.Show("Are you sure you want to delete this record?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If dia = Windows.Forms.DialogResult.Yes Then

            If myConn.State = ConnectionState.Closed Then
                myConn.Open()
            End If
            Dim PrKey As Integer = CashDGV.CurrentRow.Cells(0).Value
            Dim Query As String = "DELETE FROM tblCash WHERE PrKey = '" & PrKey & "'"
            Using cmd = New SqlCommand(Query, myConn)
                cmd.ExecuteNonQuery()
            End Using
            myConn.Close()
            SearchCash()
        End If
    End Sub

    Private Sub CashDGV_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles CashDGV.CellClick
        CashDGV.ClearSelection()

        Try
            CashDGV.CurrentRow.Selected = True
            cSum.Text = CashDGV.CurrentRow.Cells(4).Value
            If CashDGV.CurrentRow.Cells(1).Value = "IMPORTS" Then
                RadioGroup1.SelectedIndex = 0
            ElseIf CashDGV.CurrentRow.Cells(1).Value = "EXPORTS" Then
                RadioGroup1.SelectedIndex = 1
            Else
                RadioGroup1.SelectedIndex = 3
            End If
            cIndication.Text = CashDGV.CurrentRow.Cells(5).Value

        Catch ex As Exception

        End Try
    End Sub

    Private Sub KryptonRibbonGroupButton5_Click(sender As System.Object, e As System.EventArgs) Handles KryptonRibbonGroupButton5.Click
        Call RibbonClear()
        inReport.Checked = True
        KryptonDockableNavigator1.SelectedIndex = 4
    End Sub

    Private Sub itPaid_KeyDown(sender As Object, e As KeyEventArgs) Handles itPaid.KeyDown
        If e.KeyCode = Keys.Enter Then
            iAdd.PerformClick()
        End If
    End Sub

    Private Sub itPaid_TextChanged(sender As System.Object, e As System.EventArgs) Handles itPaid.TextChanged
        Call inTotalize()
    End Sub

    Private Sub krpBarcode_Click(sender As System.Object, e As System.EventArgs) Handles krpBarcode.Click
        frmBarcode.Show()
    End Sub

    'to get a random serial
    Function RandomString(minCharacters As Integer, maxCharacters As Integer)
        Dim s As String = "0123456789"
        Static r As New Random
        Dim chactersInString As Integer = r.Next(minCharacters, maxCharacters)
        Dim sb As New StringBuilder
        For i As Integer = 1 To chactersInString
            Dim idx As Integer = r.Next(0, s.Length)
            sb.Append(s.Substring(idx, 1))
        Next
        Return sb.ToString()
    End Function


    Private Sub SimpleButton2_Click(sender As System.Object, e As System.EventArgs) Handles SimpleButton2.Click
retry:
        'Dim Sr As String = RandomString(6, 6)
        'Sr = "3000000" & Sr
        ''Me.Text = Sr
        Dim Sr As String = CreateEAN()

        Dim NQuery As String = "SELECT tblItems.* FROM tblItems LEFT OUTER JOIN tblMultiCodes ON tblItems.PrKey = tblMultiCodes.Item" _
                                      & " WHERE tblItems.Serial = '" & Sr & "' OR tblMultiCodes.Code = '" & Sr & "';"

        Using cmd = New SqlCommand(NQuery, myConn)
            If myConn.State = ConnectionState.Closed Then
                myConn.Open()
            End If
            Using dr As SqlDataReader = cmd.ExecuteReader
                If dr.Read() Then
                    GoTo retry
                Else
                    iItem.Text = Sr
                End If
            End Using
            myConn.Close()
        End Using
        iItemName.Focus()
        iItemName.SelectAll()
    End Sub

    Private Sub SimpleButton3_Click(sender As System.Object, e As System.EventArgs) Handles SimpleButton3.Click
retry:
        'Dim Sr As String = RandomString(6, 6)
        'Sr = "3000000" & Sr
        Dim Sr As String = CreateEAN()

        Dim NQuery As String = "SELECT tblItems.* FROM tblItems LEFT OUTER JOIN tblMultiCodes ON tblItems.PrKey = tblMultiCodes.Item" _
                                             & " WHERE tblItems.Serial = '" & Sr & "' OR tblMultiCodes.Code = '" & Sr & "';"

        Using cmd = New SqlCommand(NQuery, myConn)
            If myConn.State = ConnectionState.Closed Then
                myConn.Open()
            End If
            Using dr As SqlDataReader = cmd.ExecuteReader
                If dr.Read() Then
                    GoTo retry
                Else
                    iiSerial.Text = Sr
                End If
            End Using
            myConn.Close()
        End Using

    End Sub

    Private Sub KryptonRibbonGroupButton6_Click(sender As System.Object, e As System.EventArgs) Handles KryptonRibbonGroupButton6.Click
        CashierNew.Show()
        Me.Close()
    End Sub

    Private Sub KryptonTextBox1_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles KryptonTextBox1.KeyPress
        If Not Char.IsControl(e.KeyChar) And Not Char.IsDigit(e.KeyChar) And Not e.KeyChar = "." Then
            e.Handled = True
        End If
        If e.KeyChar = "." And KryptonTextBox1.Text Like "*" & "." & "*" Then
            e.Handled = True
        End If
    End Sub

    Private Sub KryptonTextBox1_PreviewKeyDown(sender As Object, e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles KryptonTextBox1.PreviewKeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Or e.KeyCode = Keys.Down Then
            iQnty.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            nItemPrice.Focus()
        End If
    End Sub

    Private Sub KryptonTextBox2_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles iiMinimumQnty.KeyPress
        If Not Char.IsControl(e.KeyChar) And Not Char.IsDigit(e.KeyChar) And Not e.KeyChar = "." Then
            e.Handled = True
        End If
        If e.KeyChar = "." And iiMinimumQnty.Text Like "*" & "." & "*" Then
            e.Handled = True
        End If
    End Sub

    Private Sub KryptonTextBox2_PreviewKeyDown(sender As Object, e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles iiMinimumQnty.PreviewKeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Down Or e.KeyCode = Keys.Tab Then
            If e.KeyCode = Keys.Shift Then
                iiPrice.Focus()
            Else
                iiSerial2.Focus()
            End If
        ElseIf e.KeyCode = Keys.Up Then
            iiPrice.Focus()
        End If
    End Sub

    Private Sub KryptonPanel22_VisibleChanged(sender As Object, e As System.EventArgs) Handles KryptonPanel22.VisibleChanged
        If KryptonPanel22.Visible = False Then
            nItemPrice.Text = ""
            KryptonTextBox1.Text = ""
            nEnglishName.Text = ""
            lblSellingPrice.Visible = False
        Else
            lblSellingPrice.Visible = True
        End If
    End Sub

    Private Sub iItem_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles iItem.SelectedIndexChanged
        'iItem.Text = iItem.Text.ToUpper
        If Not iItem.Text = "" Then
            Dim ne As Boolean
            Dim NQuery As String = "SELECT tblItems.* FROM tblItems LEFT OUTER JOIN tblMultiCodes ON tblItems.PrKey = tblMultiCodes.Item" _
                                      & " WHERE tblItems.Serial = '" & iItem.Text & "' OR tblMultiCodes.Code = '" & iItem.Text & "';"
            Using cmd = New SqlCommand(NQuery, myConn)
                If myConn.State = ConnectionState.Closed Then
                    myConn.Open()
                End If
                Try
                    Using dt As SqlDataReader = cmd.ExecuteReader
                        If dt.Read() Then
                            ne = False
                            iItemName.Text = dt(2).ToString
                            KryptonPanel22.Visible = False
                            lblSellingPrice.Text = "Selling Price: " & dt(3)
                            lblSellingPrice.Visible = True
                        Else
                            ne = True
                            KryptonPanel22.Visible = True
                            iItemName.Text = ""
                            lblSellingPrice.Visible = False
                        End If
                    End Using
                Catch ex As Exception
                    ' lblSellingPrice.Visible = False
                End Try
                myConn.Close()
            End Using
        Else
            lblSellingPrice.Visible = False
        End If
    End Sub

    Private Sub SimpleButton1_Click(sender As System.Object, e As System.EventArgs) Handles SimpleButton1.Click
        frmDebit.ShowDialog()
    End Sub

    Private Sub cSum_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cSum.KeyPress
        If Not Char.IsControl(e.KeyChar) And Not Char.IsDigit(e.KeyChar) And Not e.KeyChar = "." Then
            e.Handled = True
        End If
        If e.KeyChar = "." And cSum.Text Like "*" & "." & "*" Then
            e.Handled = True
        End If
    End Sub

    Private Sub iiSerial_PreviewKeyDown(sender As Object, e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles iiSerial.PreviewKeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Down Or e.KeyCode = Keys.Tab Then
            If Not e.KeyCode = Keys.Shift Then
                iiItem.Focus()
            End If
        End If
    End Sub

    Private Sub iiItem_PreviewKeyDown(sender As Object, e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles iiItem.PreviewKeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Down Or e.KeyCode = Keys.Tab Then
            If e.KeyCode = Keys.Shift Then
                iiSerial.Focus()
            Else
                iiEnglishName.Focus()
            End If
        ElseIf e.KeyCode = Keys.Up Then
            iiSerial.Focus()
        End If
    End Sub

    Private Sub lblSellingPrice_Click(sender As System.Object, e As System.EventArgs) Handles lblSellingPrice.Click
        If iItem.Text <> "" And iItemName.Text <> "" Then
            If GlobalVariables.authority = "Admin" Or GlobalVariables.authority = "Developer" Then
                frmPriceChange.ShowDialog()
                iQnty.Focus()
            Else
                MsgBox("You dont have permission to edit the item price!")
            End If
        End If
    End Sub

    Private Sub KryptonRibbonGroupButton7_Click(sender As System.Object, e As System.EventArgs) Handles KryptonRibbonGroupButton7.Click
        Shell("Calc", AppWinStyle.NormalFocus, True)

    End Sub

    Private Sub KryptonRibbonGroupButton9_Click(sender As System.Object, e As System.EventArgs) Handles KryptonRibbonGroupButton9.Click
        frmSync.ShowDialog()
    End Sub


    Private Sub iUnitPrice_EditValueChanged(sender As Object, e As EventArgs) Handles iUnitPrice.EditValueChanged

        iValue.Text = Val(iQnty.Text) * Val(iUnitPrice.Text)

    End Sub

    Private Sub iValue_EditValueChanged(sender As Object, e As EventArgs) Handles iValue.EditValueChanged
        iUnitPrice.Text = Val(iValue.Text) / Val(iQnty.Text)
    End Sub


    Private Sub iiSerial2_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles iiSerial2.PreviewKeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Down Or e.KeyCode = Keys.Tab Then
            If e.KeyCode = Keys.Shift Then
                iiMinimumQnty.Focus()
            Else
                iiGroupPrice.Focus()
            End If
        ElseIf e.KeyCode = Keys.Up Then
            iiMinimumQnty.Focus()
        End If
    End Sub

    Private Sub iiGroupPrice_KeyPress(sender As Object, e As KeyPressEventArgs) Handles iiGroupPrice.KeyPress
        If Not Char.IsControl(e.KeyChar) And Not Char.IsDigit(e.KeyChar) And Not e.KeyChar = "." Then
            e.Handled = True
        End If
        If e.KeyChar = "." And iiGroupPrice.Text Like "*" & "." & "*" Then
            e.Handled = True
        End If
    End Sub

    Private Sub iiGroupPrice_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles iiGroupPrice.PreviewKeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Down Or e.KeyCode = Keys.Tab Then
            If e.KeyCode = Keys.Shift Then
                iiSerial2.Focus()
            Else
                iiUnitNumber.Focus()
            End If
        ElseIf e.KeyCode = Keys.Up Then
            iiSerial2.Focus()
        End If
    End Sub

    Private Sub iiUnitNumber_KeyPress(sender As Object, e As KeyPressEventArgs) Handles iiUnitNumber.KeyPress
        If Not Char.IsControl(e.KeyChar) And Not Char.IsDigit(e.KeyChar) And Not e.KeyChar = "." Then
            e.Handled = True
        End If
        If e.KeyChar = "." And iiUnitNumber.Text Like "*" & "." & "*" Then
            e.Handled = True
        End If
    End Sub

    Private Sub iiUnitNumber_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles iiUnitNumber.PreviewKeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Down Or e.KeyCode = Keys.Tab Then
            If e.KeyCode = Keys.Shift Then
                iiGroupPrice.Focus()
            Else
                iiAlterCodes.Focus()
            End If
        ElseIf e.KeyCode = Keys.Up Then
            iiGroupPrice.Focus()
        End If
    End Sub

    Private Sub LabelControl1_Click(sender As Object, e As EventArgs) Handles LabelControl1.Click
        itPaid.Text = iTotalSales.Text
        itPaid.Focus()
        itPaid.SelectAll()
    End Sub

    Private Sub iSearch_VisibleChanged(sender As Object, e As EventArgs) Handles iSearch.VisibleChanged
        If iSearch.Visible = True Then
            iSerial.Visible = False
        Else
            iSerial.Visible = True
        End If
    End Sub

    Private Sub iiAlterCodes_KeyDown(sender As Object, e As KeyEventArgs) Handles iiAlterCodes.KeyDown
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Tab Then
            If e.KeyCode = Keys.Shift Then
                iiUnitNumber.Focus()
            Else
                iiAdd.Focus()
            End If
        ElseIf e.KeyCode = Keys.Up Then
            iiUnitNumber.Focus()
        End If

        If e.KeyCode = Keys.Enter And Not iiAlterCodes.Text = "" Then
            e.Handled = True
            iiAlterCodes.Text += ";"
            iiAlterCodes.Text = iiAlterCodes.Text.Replace(vbNewLine, "")
            iiAlterCodes.Select(iiAlterCodes.Text.Length, 0)

        End If
    End Sub

    Private Sub iiEnglishName_GotFocus(sender As Object, e As EventArgs) Handles iiEnglishName.GotFocus
        InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(CultureInfo.GetCultureInfo("AR-EG"))
    End Sub

    Private Sub iiEnglishName_LostFocus(sender As Object, e As EventArgs) Handles iiEnglishName.LostFocus
        InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(CultureInfo.GetCultureInfo("EN-US"))
    End Sub

    Private Sub iiEnglishName_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles iiEnglishName.PreviewKeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Down Or e.KeyCode = Keys.Tab Then
            If e.KeyCode = Keys.Shift Then
                iiItem.Focus()
            Else
                iiPrice.Focus()
            End If
        ElseIf e.KeyCode = Keys.Up Then
            iiItem.Focus()
        End If
    End Sub

    Private Sub nEnglishName_GotFocus(sender As Object, e As EventArgs) Handles nEnglishName.GotFocus
        InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(CultureInfo.GetCultureInfo("AR-EG"))

    End Sub

    Private Sub nEnglishName_LostFocus(sender As Object, e As EventArgs) Handles nEnglishName.LostFocus
        InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(CultureInfo.GetCultureInfo("EN-US"))
    End Sub

    Private Sub nEnglishName_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles nEnglishName.PreviewKeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Or e.KeyCode = Keys.Down Then
            nItemPrice.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            iItemName.Focus()
        End If
    End Sub

    Private Sub KryptonRibbonGroupButton2_Click_1(sender As Object, e As EventArgs) Handles KryptonRibbonGroupButton2.Click
        frmAgents.ShowDialog()

    End Sub

    Private Sub ossSubmit_Click(sender As Object, e As EventArgs) Handles btnCommissions.Click
        Cursor = Cursors.WaitCursor
        Dim fDate, SDate As String
        If ossDateFrom.Checked = True Then
            fDate = ossDateFrom.Value.ToString("MM/dd/yyyy") & " " & ossTimeFrom.Value.ToString("HH:mm")
        Else
            fDate = "01/01/1999 00:00:00.000"
        End If
        If ossDateTill.Checked = True Then
            SDate = ossDateTill.Value.ToString("MM/dd/yyyy") & " " & ossTimeTill.Value.ToString("HH:mm")
        Else
            SDate = "01/01/2500 23:59:59.999"
        End If

        Dim company As String = ""
        Dim agent As String = ""
        If ossCompany.Text <> "" Then
            company = " AND tblAgency.Company = '" & ossCompany.Text & "'"
        End If
        If ossAgent.Text <> "" Then
            agent = " AND tblAgency.Agent = '" & ossAgent.Text & "'"
        End If

        Dim Query As String = "SELECT tblOut1.[Date], tblAgency.Company, tblAgency.Agent, (SUM([dbo].[RealPayment](tblOut1.Serial)) * tblAgency.Commission / 100) AS Commission, SUM([dbo].[RealPayment](tblOut1.Serial)) AS Amount" _
                              & " FROM tblOut1 INNER JOIN tblAgency ON tblOut1.Agent = tblAgency.Code" _
                              & " WHERE (tblOut1.[Date] + tblOut1.[Time]) BETWEEN '" & fDate & "' AND '" & SDate & "'" _
                              & company & agent _
                              & " GROUP BY tblOut1.[Date], tblAgency.Company, tblAgency.Agent, tblAgency.Commission" _
                              & " ORDER BY tblAgency.Company, tblAgency.Agent, tblOut1.[Date]"


        Dim ds As New ReportsDS
        Dim da As New SqlDataAdapter(Query, myConn)
        da.Fill(ds.Tables("tblAgents"))

        Dim Report As New XtraAgents
        Report.DataSource = ds
        Report.DataAdapter = da
        Report.DataMember = "tblAgents"


        If ossCompany.Text = Nothing Then
            Report.XrCompany.Text = ""
            Report.XrCompanyName.Text = ""
        Else
            Report.XrCompany.Text = "Company:"
            Report.XrCompanyName.Text = ossCompany.Text.ToUpper
        End If

        If ossDateFrom.Checked = True Then
            Report.XrFrom.Text = "From:"
            Report.XrFromDate.Text = ossDateFrom.Value.ToString("yyyy/MM/dd") & " " & ossTimeFrom.Value.ToString("HH:mm")
        Else
            Report.XrFrom.Text = ""
            Report.XrFromDate.Text = ""
        End If
        If ossDateTill.Checked = True Then
            Report.XrTill.Text = "Till:"
            Report.XrTillDate.Text = ossDateTill.Value.ToString("yyyy/MM/dd") & " " & ossTimeTill.Value.ToString("HH:mm")
        Else
            Report.XrTill.Text = ""
            Report.XrTillDate.Text = ""
        End If
        Report.CreateDocument()
        Cursor = Cursors.Default

        Report.ShowPreview()

    End Sub

    Private Sub RadioGroup1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadioGroup1.SelectedIndexChanged
        If RadioGroup1.SelectedIndex = 2 Then
            KryptonLabel30.Visible = False
            cIndication.Visible = False
            KryptonLabel18.Visible = True
            cSumTo.Visible = True
            cCurrencyTo.Visible = True
        Else
            KryptonLabel30.Visible = True
            cIndication.Visible = True
            KryptonLabel18.Visible = False
            cSumTo.Visible = False
            cCurrencyTo.Visible = False
        End If
    End Sub

    Private Sub btnReception_Click(sender As Object, e As EventArgs) Handles btnReception.Click
        frmReception.ShowDialog()
    End Sub

    Private Sub iDiscount_KeyPress(sender As Object, e As KeyPressEventArgs) Handles iDiscount.KeyPress

        If e.KeyChar = "." AndAlso iDiscount.Text = "" Then
            iUnitPrice.Text = "0."
            iUnitPrice.Select(2, 0)

        End If

        If Not Char.IsControl(e.KeyChar) And Not Char.IsDigit(e.KeyChar) And Not e.KeyChar = "." Then
            e.Handled = True
        End If
        If e.KeyChar = "." And iDiscount.Text Like "*" & "." & "*" Then
            e.Handled = True
        End If

    End Sub

    Private Sub iDiscount_TextChanged(sender As Object, e As EventArgs) Handles iDiscount.TextChanged
        inTotalize()
    End Sub

    Private Sub btnPassKey_Click(sender As Object, e As EventArgs) Handles btnPassKey.Click
        frmPassKey.ShowDialog()
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Cursor = Cursors.WaitCursor
        Dim fDate, SDate As String
        If deDateFrom.Checked = True Then
            fDate = deDateFrom.Value.ToString("MM/dd/yyyy") & " " & deTimeFrom.Value.ToString("HH:mm")
        Else
            fDate = "01/01/1999 00:00:00.000"
        End If
        If deDateTill.Checked = True Then
            SDate = deDateTill.Value.ToString("MM/dd/yyyy") & " " & deTimeTill.Value.ToString("HH:mm")
        Else
            SDate = "01/01/2500 23:59:59.999"
        End If

        Dim LogType As String = ""

        If cbLogType.Text <> "" Then
            LogType = " AND (tblLog.cType = '" & cbLogType.Text & "')"
        End If
        
        Dim Query As String = "SELECT tblLog.cDate AS [Date], tblLog.cTime AS [Time], tblLogin.UserName AS [User]," _
                              & " tblLog.cType AS [Type], (CASE WHEN tblLog.cInvoice IS NULL THEN tblLog.cDetails ELSE 'Invoice# ' + CONVERT(NVARCHAR(10), tblLog.cInvoice)" _
                              & " + CHAR(10) + tblLog.cDetails END) AS Details" _
                              & " FROM tblLog" _
                              & " INNER JOIN tblLogin ON tblLogin.Sr = tblLog.cUser" _
                              & " WHERE ((tblLog.[cDate] + tblLog.cTime) BETWEEN '" & fDate & "' AND '" & SDate & "')" _
                              & LogType _
                              & " ORDER BY tblLog.cDate, tblLog.cTime;"

        Dim ds As New ReportsDS
        Dim da As New SqlDataAdapter(Query, myConn)
        da.Fill(ds.Tables("dtLogs"))

        Dim Report As New XtraLogs
        Report.DataSource = ds
        Report.DataAdapter = da
        Report.DataMember = "dtLogs"


        If cbLogType.Text = Nothing Then
            Report.XrLogType.Text = ""
            Report.XrLogTypeData.Text = ""
        Else
            Report.XrLogType.Text = "Log Type:"
            Report.XrLogTypeData.Text = cbLogType.Text.ToUpper
        End If

        If deDateFrom.Checked = True Then
            Report.XrFrom.Text = "From:"
            Report.XrFromDate.Text = deDateFrom.Value.ToString("yyyy/MM/dd") & " " & deTimeFrom.Value.ToString("HH:mm")
        Else
            Report.XrFrom.Text = ""
            Report.XrFromDate.Text = ""
        End If
        If deDateTill.Checked = True Then
            Report.XrTill.Text = "Till:"
            Report.XrTillDate.Text = deDateTill.Value.ToString("yyyy/MM/dd") & " " & deTimeTill.Value.ToString("HH:mm")
        Else
            Report.XrTill.Text = ""
            Report.XrTillDate.Text = ""
        End If
        Report.CreateDocument()
        Cursor = Cursors.Default

        Report.ShowPreview()

    End Sub

    Private Sub btnTracker_Click(sender As Object, e As EventArgs) Handles btnTracker.Click
        frmTracker.Show()
    End Sub

    Private Sub btnPaxNumbers_Click(sender As Object, e As EventArgs) Handles btnPaxNumbers.Click
    Cursor = Cursors.WaitCursor
        Dim fDate, SDate As String
        If ossDateFrom.Checked = True Then
            fDate = ossDateFrom.Value.ToString("MM/dd/yyyy") & " " & ossTimeFrom.Value.ToString("HH:mm")
        Else
            fDate = "01/01/1999 00:00:00.000"
        End If
        If ossDateTill.Checked = True Then
            SDate = ossDateTill.Value.ToString("MM/dd/yyyy") & " " & ossTimeTill.Value.ToString("HH:mm")
        Else
            SDate = "01/01/2500 23:59:59.999"
        End If

        Dim company As String = ""
        Dim agent As String = ""
        If ossCompany.Text <> "" Then
            company = " AND tblAgency.Company = '" & ossCompany.Text & "'"
        End If
        If ossAgent.Text <> "" Then
            agent = " AND tblAgency.Agent = '" & ossAgent.Text & "'"
        End If

        'Dim Query As String = "SELECT [Date], Company, Agent, SUM(ADT) AS ADT, SUM(CHD) AS CHD, SUM(INF) AS INF, SUM(Driver) AS Driver, Sales " _
        '                      & " FROM" _
        '                      & " (" _
        '                      & " SELECT tblRegistery.[Date], tblAgency.Company, tblAgency.Agent, tblRegistery.ADT, tblRegistery.CHD," _
        '                      & " tblRegistery.INF, tblRegistery.Driver, SUM(COALESCE(tblOut1.Total, 0)) AS Sales" _
        '                      & " FROM tblRegistery" _
        '                      & " INNER JOIN tblAgency ON tblRegistery.Agent = tblAgency.Code" _
        '                      & " LEFT OUTER JOIN tblOut1 ON tblOut1.Agent = tblAgency.Code AND tblOut1.[Date] = tblRegistery.[Date]" _
        '                      & " WHERE (tblRegistery.[Date] + tblRegistery.[Time]) BETWEEN '" & fDate & "' AND '" & SDate & "'" _
        '                      & company & agent _
        '                      & " GROUP BY tblRegistery.[Date], tblAgency.Company, tblAgency.Agent, tblRegistery.ADT, tblRegistery.CHD," _
        '                      & " tblRegistery.INF, tblRegistery.Driver" _
        '                      & " ) AA" _
        '                      & " GROUP BY [Date], Company, Agent, Sales;"

        Dim query As String = "SELECT tblRegistery.[Date], tblAgency.Company, tblAgency.Agent, SUM(tblRegistery.ADT) AS ADT," _
                              & " SUM(tblRegistery.CHD) AS CHD, SUM(tblRegistery.INF) AS INF, SUM(tblRegistery.Driver) AS Driver, AVG(dbo.AgentSales(tblAgency.Code, tblRegistery.Date)) AS Sales" _
                              & " FROM tblRegistery" _
                              & " JOIN tblAgency ON tblRegistery.Agent = tblAgency.Code" _
                              & " WHERE (tblRegistery.[Date] + tblRegistery.[Time]) BETWEEN '" & fDate & "' AND '" & SDate & "'" _
                              & company & agent _
                              & " GROUP BY tblRegistery.[Date], tblAgency.Company, tblAgency.Agent"

        Dim ds As New ReportsDS
        Dim da As New SqlDataAdapter(Query, myConn)
        da.Fill(ds.Tables("tblRegistery"))

        Dim Report As New XtraPaxNo
        Report.DataSource = ds
        Report.DataAdapter = da
        Report.DataMember = "tblRegistery"


        If ossCompany.Text = Nothing Then
            Report.XrCompany.Text = ""
            Report.XrCompanyName.Text = ""
        Else
            Report.XrCompany.Text = "Company:"
            Report.XrCompanyName.Text = ossCompany.Text.ToUpper
        End If

        If ossDateFrom.Checked = True Then
            Report.XrFrom.Text = "From:"
            Report.XrFromDate.Text = ossDateFrom.Value.ToString("yyyy/MM/dd") & " " & ossTimeFrom.Value.ToString("HH:mm")
        Else
            Report.XrFrom.Text = ""
            Report.XrFromDate.Text = ""
        End If
        If ossDateTill.Checked = True Then
            Report.XrTill.Text = "Till:"
            Report.XrTillDate.Text = ossDateTill.Value.ToString("yyyy/MM/dd") & " " & ossTimeTill.Value.ToString("HH:mm")
        Else
            Report.XrTill.Text = ""
            Report.XrTillDate.Text = ""
        End If
        Report.CreateDocument()
        Cursor = Cursors.Default

        Report.ShowPreview()

    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        frmCategory.ShowDialog()
    End Sub

    Private Sub osDateFrom_CheckedChanged(sender As Object, e As EventArgs) Handles osDateFrom.CheckedChanged
        If osDateFrom.Checked Then
            osTimeFrom.Visible = True
        Else
            osTimeFrom.Visible = False
            osTimeFrom.Value = Today & " 00:00"
        End If
    End Sub

    Private Sub osDateTill_CheckedChanged(sender As Object, e As EventArgs) Handles osDateTill.CheckedChanged
        If osDateTill.Checked Then
            osTimeTill.Visible = True
        Else
            osTimeTill.Visible = False
            osTimeTill.Value = Today & " 23:59"
        End If
    End Sub

    Private Sub ossDateFrom_CheckedChanged(sender As Object, e As EventArgs) Handles ossDateFrom.CheckedChanged
        If ossDateFrom.Checked Then
            ossTimeFrom.Visible = True
        Else
            ossTimeFrom.Visible = False
            ossTimeFrom.Value = Today & " 00:00"
        End If
    End Sub

    Private Sub ossDateTill_CheckedChanged(sender As Object, e As EventArgs) Handles ossDateTill.CheckedChanged
        If ossDateTill.Checked Then
            ossTimeTill.Visible = True
        Else
            ossTimeTill.Visible = False
            ossTimeTill.Value = Today & " 23:59"
        End If
    End Sub

    Private Sub deDateFrom_CheckedChanged(sender As Object, e As EventArgs) Handles deDateFrom.CheckedChanged
        If deDateFrom.Checked Then
            deTimeFrom.Visible = True
        Else
            deTimeFrom.Visible = False
            deTimeFrom.Value = Today & " 00:00"
        End If
    End Sub

    Private Sub deDateTill_CheckedChanged(sender As Object, e As EventArgs) Handles deDateTill.CheckedChanged
        If deDateTill.Checked Then
            deTimeTill.Visible = True
        Else
            deTimeTill.Visible = False
            deTimeTill.Value = Today & " 23:59"
        End If
    End Sub

    
End Class

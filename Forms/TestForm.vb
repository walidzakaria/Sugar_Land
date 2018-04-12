Imports System.Net.NetworkInformation
Imports System.Data.SqlClient
Imports System.Management
Imports DevExpress.XtraReports.UI

Public Class TestForm
    Public Shared myMac As String
    Public Shared HDD_Serial, MB_Serial As String
    Public Shared Master As String

    Private Function getMacAddress() As String
        Try
            Dim adapters As NetworkInterface() = NetworkInterface.GetAllNetworkInterfaces()
            Dim adapter As NetworkInterface
            Dim myMac As String = String.Empty

            For Each adapter In adapters
                Select Case adapter.NetworkInterfaceType
                    'Exclude Tunnels, Loopbacks and PPP
                    Case NetworkInterfaceType.Tunnel, NetworkInterfaceType.Loopback, NetworkInterfaceType.Ppp
                    Case Else
                        If Not adapter.GetPhysicalAddress.ToString = String.Empty And Not adapter.GetPhysicalAddress.ToString = "00000000000000E0" Then
                            myMac = adapter.GetPhysicalAddress.ToString
                            Exit For ' Got a mac so exit for
                        End If
                End Select
            Next adapter

            Return myMac
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function

    Private Function getMotherSerial() As String
        Dim mBoard As New ManagementObjectSearcher("SELECT * FROM win32_BaseBoard")
        For Each MB In mBoard.Get
            MB_Serial = MB("SerialNumber")
        Next
        Return MB_Serial
    End Function

    Private Function getHDDSerial() As String
        Dim Sniper1 As New ManagementObjectSearcher("SELECT * FROM win32_DiskDrive")
        For Each HD In Sniper1.Get
            HDD_Serial = HD("SerialNumber")
        Next
        Return HDD_Serial
    End Function
    Private Sub TestForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label4.Text = My.Settings.tMac
        Label5.Text = My.Settings.tMB
        Label6.Text = My.Settings.tHDD
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Label1.Text = getMacAddress()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Label2.Text = getMotherSerial()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Label3.Text = getHDDSerial()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        My.Settings.tMac = Label1.Text
        My.Settings.tMB = Label2.Text
        My.Settings.tHDD = Label3.Text
        My.Settings.Save()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Cursor = Cursors.WaitCursor
        Dim Cashier As String = ""
        If cbCashiers.Text <> "" Then
            Cashier = " AND (tblLogin.UserName = N'" & cbCashiers.Text & "')"
        End If

        Dim timFrom, timTill As String
        timFrom = dailyDateFrom.Value.ToString("MM/dd/yyyy") & " " & tmFrom.Value.ToString("HH:mm") & ":00.000"
        timTill = dailyDateTill.Value.ToString("MM/dd/yyyy") & " " & tmTill.Value.ToString("HH:mm") & ":59.999"

        Dim Query As String = "( " _
                              & " SELECT tblIn1.[Date], CONVERT(NVARCHAR(5), tblIn1.[Time], 108) AS [Time], tblIn1.Serial AS Indication, 'PURCHASE' AS [Type], " _
                              & " tblDebit.Amount, 'USD' AS Currency, tblLogin.UserName AS [User]" _
                              & " FROM tblIn1 INNER JOIN tblDebit ON tblDebit.Serial = tblIn1.PrKey" _
                              & " AND tblDebit.[Date] = tblIn1.[Date]" _
                              & " AND tblIn1.[Time] = tblDebit.[Time]" _
                              & " INNER JOIN tblLogin ON tblLogin.Sr = tblIn1.[User]" _
                              & " WHERE (tblIn1.[Date] + tblIn1.[Time] BETWEEN '" & timFrom & "' AND '" & timTill & "')" & Cashier _
                              & " UNION ALL" _
                              & " SELECT tblDebit.[Date], CONVERT(NVARCHAR(5), tblDebit.[Time], 108) AS [Time], tblIn1.Serial AS Indication, 'PAYMENT' AS [Type]," _
                              & " tblDebit.Amount, 'USD' AS Currency, tblLogin.UserName AS [User]" _
                              & " FROM tblDebit RIGHT OUTER JOIN tblIn1 ON tblDebit.Serial = tblIn1.PrKey" _
                              & " INNER JOIN tblLogin ON tblLogin.Sr = tblDebit.[User]" _
                              & " WHERE (tblDebit.[Date] != tblIn1.[Date] OR tblDebit.[Time] != tblIn1.[Time])" _
                              & " AND (tblDebit.[Date] + tblDebit.[Time] BETWEEN '" & timFrom & "' AND '" & timTill & "')" & Cashier _
                              & " UNION ALL" _
                              & " SELECT tblOut1.[Date], CONVERT(NVARCHAR(5), tblOut1.[Time], 108) AS [Time], CONVERT(NVARCHAR(20), tblOut1.Serial) AS Indication," _
                              & " 'SELLING' AS [Type], tblOut1.SubTotal AS Amount," _
                              & " (CASE WHEN tblOut1.Currency = 0 THEN 'USD' WHEN tblOut1.Currency = 1 THEN 'EUR' WHEN tblOut1.Currency = 2 THEN 'EGP'" _
                              & " WHEN tblOut1.Currency = 3 THEN 'GBP' WHEN tblOut1.Currency = 4 THEN 'RUB' ELSE 'UAH' END) AS Currency" _
                              & " ,tblLogin.UserName AS [User]" _
                              & " FROM tblOut1 INNER JOIN tblLogin ON tblLogin.Sr = tblOut1.[User]" _
                              & " WHERE (tblOut1.[Date] + tblOut1.[Time] BETWEEN '" & timFrom & "' AND '" & timTill & "')" & Cashier _
                              & " UNION ALL" _
                              & " SELECT tblCash.[Date] AS [Date], CONVERT(NVARCHAR(5), tblCash.[Time], 108) AS [Time], tblCash.Indication," _
                              & " tblCash.[Type], tblCash.Qnty AS Amount," _
                              & " (CASE WHEN tblCash.Currency = 0 THEN 'USD' WHEN tblCash.Currency = 1 THEN 'EUR' WHEN tblCash.Currency = 2 THEN 'EGP'" _
                              & " WHEN tblCash.Currency = 3 THEN 'GBP' WHEN tblCash.Currency = 4 THEN 'RUB' ELSE 'UAH' END) AS Currency" _
                              & " ,tblLogin.UserName AS [User]" _
                              & " FROM tblCash INNER JOIN tblLogin ON tblCash.[User] = tblLogin.Sr" _
                              & " WHERE (tblCash.[Date] + tblCash.[Time] BETWEEN '" & timFrom & "' AND '" & timTill & "')" & Cashier _
                              & " )" _
                              & " ORDER BY [Date], [Time]"


        Dim ds As New ReportsDS
        Dim da As New SqlDataAdapter(Query, frmMain.myConn)
        da.Fill(ds.Tables("tblDaily"))

        Dim Report As New XtraDailyMonitor
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
End Class
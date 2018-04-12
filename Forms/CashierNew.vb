Imports System.ComponentModel
Imports System.Text
Imports DevExpress.Skins
Imports DevExpress.LookAndFeel
Imports DevExpress.UserSkins
Imports DevExpress.XtraBars
Imports DevExpress.XtraBars.Ribbon
Imports DevExpress.XtraBars.Helpers
Imports System.Data.SqlClient
Imports DevExpress.XtraLayout
Imports System.IO
Imports System.Collections.Generic
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.XtraTabbedMdi
Imports System.Collections
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraPrinting.Native
Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing.Printing


Public Class CashierNew
    Public Shared myConn As New SqlConnection(GV.myConn)
    Public Shared InvoiceLogs As String = ""

    Dim counter As Integer = 0
    Dim itemPackage As Boolean = False
    Dim SusInvoice As String = ""
    'Dim dueAmount As Single = 0
    Shared Sub New()
        DevExpress.UserSkins.BonusSkins.Register()
        DevExpress.Skins.SkinManager.EnableFormSkins()
    End Sub
    Public Sub New()
        InitializeComponent()
        Me.InitSkinGallery()
        If Not My.Settings.Theme = "" Then
            UserLookAndFeel.Default.SkinName = My.Settings.Theme.ToString()
        End If
    End Sub

    Private Sub InitSkinGallery()
        SkinHelper.InitSkinGallery(rgbiSkins, True)
    End Sub

    'Private Function GetRest(ByVal Currency As Integer) As Single
    '    Dim rate, rest As Single

    '    Select Case cbPaidCurrency.SelectedIndex
    '        Case 0
    '            rate = Val(tbTotal.Text.Replace("$", ""))
    '        Case 1
    '            rate = Val(txtREUR.Text)
    '        Case 2
    '            rate = Val(txtREGP.Text)
    '        Case 3
    '            rate = Val(txtRGBP.Text)
    '        Case 4
    '            rate = Val(txtRRUB.Text)
    '        Case 5
    '            rate = Val(txtRUAH.Text)
    '    End Select

    '    rest = Math.Round(Val(tbPaid.Text) - rate, 2, MidpointRounding.AwayFromZero)
    '    rest = rest * Val(tbTotal.Text.Replace("$", "")) / rate

    '    Select Case Currency
    '        Case 0
    '            rate = Val(tbTotal.Text.Replace("$", ""))
    '        Case 1
    '            rate = Val(txtREUR.Text)
    '        Case 2
    '            rate = Val(txtREGP.Text)
    '        Case 3
    '            rate = Val(txtRGBP.Text)
    '        Case 4
    '            rate = Val(txtRRUB.Text)
    '        Case 5
    '            rate = Val(txtRUAH.Text)
    '    End Select
    '    rest = rest * rate / Val(tbTotal.Text.Replace("$", ""))
    '    rest = Math.Round(rest, 2, MidpointRounding.AwayFromZero)
    '    Return rest
    'End Function

    Private Function GetCurrency() As String
        Dim Query As String = "SELECT TOP(1) * FROM tblCurrency ORDER BY PrKey DESC;"
        Dim result As String
        Using cmd = New SqlCommand(Query, myConn)
            If myConn.State = ConnectionState.Closed Then
                myConn.Open()
            End If

            Using dr As SqlDataReader = cmd.ExecuteReader
                If dr.Read() Then
                    result = "1;" & dr(3) & ";" & dr(4) & ";" & dr(5) & ";" & dr(6) & ";" & dr(7)
                Else
                    result = "0;0;0;0;0;0"
                End If
            End Using
            myConn.Close()
        End Using
        Return result
    End Function

    Private Sub Change()
        Dim result() As String = GetCurrency().Split(";")
        Dim rest As Single

        rest = Val(tbTotal.Text.Replace("$", ""))
        Dim usd, eur, le, rub, uah, sterling, visa As Single
        usd = Val(pUSD.Text) - Val(cUSD.Text)
        eur = (Val(pEUR.Text) - Val(cEUR.Text)) / Val(result(1))
        le = (Val(pEGP.Text) - Val(cEGP.Text)) / Val(result(2))
        rub = (Val(pRUB.Text) - Val(cRUB.Text)) / Val(result(4))
        uah = (Val(pUAH.Text) - Val(cUAH.Text)) / Val(result(5))
        sterling = (Val(pGBP.Text) - Val(cGBP.Text)) / Val(result(3))
        visa = Val(pVisa.Text) / Val(result(2))
        rest = rest - usd - eur - le - rub - uah - sterling - visa
        tbRest.Text = Math.Round(rest, 2, MidpointRounding.AwayFromZero)


    End Sub
    Private Function checkAgent(ByVal full As Boolean) As Boolean
        If oDiscountCode.Text = "" Then
            ApplyDiscount(0)
            lbDiscount.Text = "0%"
            lblAgent.Caption = ""
            lblAgent.Visibility = BarItemVisibility.Never
            Application.DoEvents()
            Return False
        End If

        Dim found As Boolean
        Dim discRate As Single = 0
        Dim Query As String = "SELECT Company, Agent, GuestDiscount" _
                              & " FROM tblAgency WHERE PinCode = '" & oDiscountCode.Text & "';"

        Using cmd = New SqlCommand(Query, myConn)
            If myConn.State = ConnectionState.Closed Then
                myConn.Open()
            End If
            Using dr As SqlDataReader = cmd.ExecuteReader
                If dr.Read() Then
                    found = True
                    discRate = dr(2)
                    lblAgent.Caption = dr(0) & " | " & dr(1)
                    lblAgent.Visibility = BarItemVisibility.Always
                    Application.DoEvents()
                Else
                    found = False
                    lblAgent.Caption = ""
                    lblAgent.Visibility = BarItemVisibility.Never
                    Application.DoEvents()
                End If
            End Using
            myConn.Close()
        End Using
        If full = True Then
            If found = True Then
                pUSD.Focus()
                pUSD.SelectAll()

                lbDiscount.Text = discRate & "%"
                ApplyDiscount(discRate)
            Else
                lbDiscount.Text = "0%"
                ApplyDiscount(0)
            End If
        End If

        Return found
    End Function
    Private Sub Authorize()
        If GlobalVariables.authority = "Cashier" Then
            'lbNetQnty.Visible = False
            oSearch.Visible = False
            LabelControl4.Visible = False
            btnIncome.Visibility = BarItemVisibility.Never
            btnExpenditure.Visibility = BarItemVisibility.Never
            btnExchange.Visibility = BarItemVisibility.Never
            btnCost.Visibility = BarItemVisibility.Never
            RibbonPageGroup2.Visible = False
            btnSettings.Visibility = BarItemVisibility.Never
            rgbiSkins.Visibility = BarItemVisibility.Never
            ''oRemove.Enabled = False
            ''btnCancelInvoice.Enabled = False
            cbSuspended.Visible = False
            btnSuspend.Visible = False
        Else
            lbNetQnty.Visible = True
            oSearch.Visible = True
            LabelControl4.Visible = True
            btnIncome.Visibility = BarItemVisibility.Always
            btnExpenditure.Visibility = BarItemVisibility.Always
            btnExchange.Visibility = BarItemVisibility.Always
            btnCost.Visibility = BarItemVisibility.Always
            RibbonPageGroup2.Visible = True
            btnSettings.Visibility = BarItemVisibility.Always
            rgbiSkins.Visibility = BarItemVisibility.Always
            oRemove.Enabled = True
            btnCancelInvoice.Enabled = True
            cbSuspended.Visible = True
            btnSuspend.Visible = True
        End If
    End Sub

    Private Sub fillSuspended()
        Dim Query As String = "SELECT CONVERT(NVARCHAR(5), tblSuspend.[Time], 8) + ' @' + CONVERT(NVARCHAR(1), tblSuspend.Memo) + '   ' + CONVERT(NVARCHAR(10), tblLogin.UserName) AS Invoice, tblSuspend.PrKey" _
                              & " FROM tblSuspend" _
                              & " INNER JOIN tblLogin ON tblSuspend.[User] = tblLogin.Sr;"

        Using cmd = New SqlCommand(Query, myConn)
            If myConn.State = ConnectionState.Closed Then
                myConn.Open()
            End If
            Dim adt As New SqlDataAdapter
            Dim ds As New DataSet()
            adt.SelectCommand = cmd
            adt.Fill(ds)
            adt.Dispose()

            cbSuspended.DataSource = ds.Tables(0)
            cbSuspended.DisplayMember = "Invoice"
            cbSuspended.ValueMember = "PrKey"
            cbSuspended.Text = Nothing

            myConn.Close()
        End Using
    End Sub
    Private Sub InvoiceRecall(ByVal Serial As String)
        If Serial = "" Then
            Exit Sub
        End If

        Dim Query As String = "SELECT tblOut1.Serial, tblOut1.[Date], CONVERT(NVARCHAR(5), tblOut1.[Time], 108) AS [Time], tblLogin.UserName, tblAgency.PinCode, tblOut1.Total," _
                              & " tblOut1.Discount, tblOut1.pUSD, tblOut1.pEGP, tblOut1.pRUB, tblOut1.pEUR, tblOut1.pUAH, tblOut1.pGBP, tblOut1.pVisa," _
                              & " tblOut1.cUSD, tblOut1.cEGP, tblOut1.cRUB, tblOut1.cEUR, tblOut1.cUAH, tblOut1.cGBP, tblOut1.Rest," _
                              & " tblOut2.Kind, tblOut2.Item, tblItems.Serial AS ItemSerial, tblItems.Name AS ItemName, tblOut2.Qnty, tblOut2.Price, tblOut2.UnitPrice, tblOut2.Discount, tblOut1.DiscountRate" _
                              & " FROM tblOut1 INNER JOIN tblOut2 ON tblOut1.Serial = tblOUt2.Serial" _
                              & " INNER JOIN tblLogin ON tblOut1.[User] = tblLogin.Sr" _
                              & " INNER JOIN tblAgency ON tblOut1.Agent = tblAgency.Code" _
                              & " INNER JOIN tblItems ON tblOut2.Item = tblItems.PrKey" _
                              & " WHERE tblOut1.Serial = " & Serial & ";"

        Dim dt As New DataTable

        Using cmd = New SqlCommand(Query, myConn)
            If myConn.State = ConnectionState.Closed Then
                myConn.Open()
            End If
            Using dr As SqlDataReader = cmd.ExecuteReader
                Try
                    dt.Load(dr)
                Catch ex As Exception

                End Try
            End Using
            myConn.Close()
            oDgv.Rows.Clear()
            For x As Integer = 0 To dt.Rows.Count - 1
                oDgv.Rows.Add(dt(x)(25), dt(x)(21), dt(x)(23), dt(x)(24), dt(x)(27), dt(x)(28), dt(x)(26), dt(x)(22))
            Next
            OutTotalize()
            If dt.Rows.Count > 0 Then
                lbDiscount.Text = "5%"
                oSerial.Text = dt.Rows(0)(0)
                'oUser.Caption = dt.Rows(0)(3) & vbTab & dt.Rows(0)(1) & " " & dt.Rows(0)(2)
                oDiscountCode.Text = dt.Rows(0)(4)
                pUSD.Text = dt.Rows(0)(7)
                pEGP.Text = dt.Rows(0)(8)
                pRUB.Text = dt.Rows(0)(9)
                pEUR.Text = dt.Rows(0)(10)
                pUAH.Text = dt.Rows(0)(11)
                pGBP.Text = dt.Rows(0)(12)
                pVisa.Text = dt.Rows(0)(13)

                cUSD.Text = dt.Rows(0)(14)
                cEGP.Text = dt.Rows(0)(15)
                cRUB.Text = dt.Rows(0)(16)
                cEUR.Text = dt.Rows(0)(17)
                cUAH.Text = dt.Rows(0)(18)
                cGBP.Text = dt.Rows(0)(19)
                tbRest.Text = dt.Rows(0)(20)
                lbDiscount.Text = dt.Rows(0)(29) & "%"
                ' oUser.Visibility = BarItemVisibility.Always
                btnSaveInvoice.Enabled = False
                'If GlobalVariables.authority <> "User" And GlobalVariables.authority <> "Cashier" Then
                btnEditInvoice.Visibility = BarItemVisibility.Always
                'End If
            Else
            ClearContents()
            'oUser.Visibility = BarItemVisibility.Never
            btnSaveInvoice.Enabled = True
            End If

        End Using

    End Sub
    Private Sub BarButtonItem9_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnExit.ItemClick
        Me.Close()
        Application.Exit()
    End Sub

    Private Sub CashierNew_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        My.Settings.Theme = UserLookAndFeel.Default.SkinName.ToString
        My.Settings.Save()
    End Sub

    Private Sub ClearContents()
        oQnty.Text = "1"
        oItemSerial.Text = Nothing
        oItemName.Text = Nothing
        lbDiscount.Text = "0%"

        oUnitPrice.Text = ""
        oSubTotal.Text = ""
        oDgv.Rows.Clear()
        oItemSerial.Focus()
        oDiscountCode.Text = Nothing
        oSearch.EditValue = ""
        pUSD.Text = ""
        pEGP.Text = ""
        pRUB.Text = ""
        pEUR.Text = ""
        pUAH.Text = ""
        pGBP.Text = ""
        pVisa.Text = ""

        cUSD.Text = ""
        cEGP.Text = ""
        cRUB.Text = ""
        cEUR.Text = ""
        cUAH.Text = ""
        cGBP.Text = ""

        InvoiceLogs = ""

        btnSaveInvoice.Enabled = True
        'oUser.Visibility = BarItemVisibility.Never
        lbDiscount.Text = "0%"
        SusInvoice = ""
        ScreenMemo(True)
        'btnEditInvoice.Visibility = BarItemVisibility.Never
    End Sub
    Public Sub ApplyDiscount(ByVal percentage As Decimal, Optional ByVal withRounding As Boolean = True)

        Dim qnty, Price, discount, value As Single
        percentage = 100 - percentage
        percentage = percentage / 100

        For x As Integer = 0 To Me.oDgv.RowCount - 1
            If Not Me.oDgv.Rows(x).Cells(1).Value = "PKG" Then
                qnty = Me.oDgv.Rows(x).Cells(0).Value
                Price = Me.oDgv.Rows(x).Cells(4).Value
                value = qnty * Price
                discount = qnty * Price * percentage

                'discount = Math.Round(discount, 4, MidpointRounding.AwayFromZero)
                If withRounding Then
                    Me.oDgv.Rows(x).Cells(6).Value = Math.Round(discount, 2, MidpointRounding.AwayFromZero)
                    Me.oDgv.Rows(x).Cells(5).Value = Math.Round(value - discount, 2, MidpointRounding.AwayFromZero)
                Else
                    Me.oDgv.Rows(x).Cells(6).Value = discount
                    Me.oDgv.Rows(x).Cells(5).Value = value - discount
                End If

            End If

        Next

        Me.OutTotalize()
    End Sub

    Private Sub ScreenMemo(ByVal Save As Boolean)
        Dim Str As String = ""
        If Save = True Then

            Str = InvoiceLogs & "$"

            For x As Integer = 0 To oDgv.RowCount - 1
                Str += oDgv.Rows(x).Cells(0).Value & ";" & oDgv.Rows(x).Cells(1).Value & ";" & oDgv.Rows(x).Cells(2).Value & ";" & _
                    oDgv.Rows(x).Cells(3).Value & ";" & oDgv.Rows(x).Cells(4).Value & ";" & oDgv.Rows(x).Cells(5).Value & ";" & oDgv.Rows(x).Cells(6).Value & ";" _
                    & oDgv.Rows(x).Cells(7).Value & "$"
            Next
            My.Settings.ScreenMemo = Str
            My.Settings.Save()
        Else
            Str = My.Settings.ScreenMemo
            If Str = "" Then
                Exit Sub
            End If

            Dim memory() As String = Str.Split("$")
            Dim record() As String
            oDgv.Rows.Clear()
            For x As Integer = 0 To memory.Count - 1
                If x = 0 Then
                    If memory(x) <> "" Then
                        InvoiceLogs = memory(x)
                    End If
                Else
                    record = memory(x).Split(";")
                    If memory(x) <> "" Then
                        oDgv.Rows.Add(record(0), record(1), record(2), record(3), record(4), record(5), record(6), record(7))
                    End If
                End If
            Next
            Call OutTotalize()

        End If


    End Sub
    Private Function QntyGet() As Single

        Dim Result() As String = GetItem(oItemSerial.Text).Split(";")


        'Show the Net Qnty
        Dim NetQuery As String
        NetQuery = "SELECT CONVERT(FLOAT, (ttlIn.Total_In - COALESCE(ttlOut.Total_Out , 0))) AS Net_Amount" _
            & " FROM tblItems" _
            & " LEFT OUTER JOIN" _
            & " (" _
            & " SELECT tblIn2.Item, SUM(tblIn2.Qnty) AS Total_In FROM tblIn2" _
            & " GROUP BY tblIn2.Item" _
            & " ) ttlIn" _
            & " ON tblItems.PrKey = ttlIn.Item" _
            & " LEFT OUTER JOIN" _
            & " (" _
            & " SELECT tblOut2.Item, SUM(tblOut2.Qnty) AS Total_Out FROM tblOut2" _
            & " GROUP BY tblOut2.Item" _
            & " ) ttlOut" _
            & " ON tblItems.PrKey = ttlOut.Item" _
            & " WHERE tblItems.PrKey = " & Result(0)

        Dim theQuant As Single
        Using cmd = New SqlCommand(NetQuery, myConn)
            If myConn.State = ConnectionState.Closed Then
                myConn.Open()
            End If
            Try
                theQuant = cmd.ExecuteScalar
            Catch ex As Exception
                theQuant = 0
            End Try
            myConn.Close()
        End Using
        'check the item if found in the grid
        For x As Integer = 0 To oDgv.Rows.Count - 1
            If (oDgv.Rows(x).Cells(7).Value.ToString = Result(0)) Then
                theQuant -= oDgv.Rows(x).Cells(0).Value
            End If
        Next
        Return theQuant

    End Function
    Private Sub saveMemory(ByVal number As Integer)
        Dim str As String = ""
        If oDgv.RowCount = 0 Then
            Exit Sub
        End If
        str = oDiscountCode.Text & ";" & lbDiscount.Text & ";" & InvoiceLogs & ";0;0;0;0;$"

        For x As Integer = 0 To oDgv.RowCount - 1
            str += oDgv.Rows(x).Cells(0).Value & ";" & oDgv.Rows(x).Cells(1).Value & ";" & oDgv.Rows(x).Cells(2).Value & ";" & _
                oDgv.Rows(x).Cells(3).Value & ";" & oDgv.Rows(x).Cells(4).Value & ";" & oDgv.Rows(x).Cells(5).Value & ";" & oDgv.Rows(x).Cells(6).Value & ";" _
                & oDgv.Rows(x).Cells(7).Value & "$"
        Next

        Dim Query1 As String = "SELECT COUNT(*) AS Found FROM tblSuspend WHERE [User] = " & GlobalVariables.ID & " AND Memo = " & number & ";"
        Dim Query2 As String = "INSERT INTO tblSuspend (Invoice, [Date], [Time], [User], Memo)" _
                              & " VALUES (@Invoice, '" & Today.ToString("MM/dd/yyyy") & "', '" & Now.ToString("HH:mm") & "', " & GlobalVariables.ID & ", " & number & ");"
        Using cmd = New SqlCommand(Query1, myConn)
            If myConn.State = ConnectionState.Closed Then
                myConn.Open()
            End If
            If cmd.ExecuteScalar = 0 Then
                cmd.CommandText = Query2
                cmd.Parameters.AddWithValue("@Invoice", str)
                cmd.ExecuteNonQuery()
                myConn.Close()
                ClearContents()
            Else
                myConn.Close()
                MsgBox("Page no. " & number & " is already used!")
            End If

        End Using

    End Sub

    Private Sub recallMemory(ByVal number As Integer, Optional ByVal User As Integer = 0)
        If oDgv.RowCount <> 0 Then
            Exit Sub
        End If
        If User = 0 Then
            User = GlobalVariables.ID
        End If
        Dim Query As String = "SELECT * FROM tblSuspend WHERE [User] = " & User & " AND Memo = " & number & ";"
        Dim str As String = ""
        Using cmd = New SqlCommand(Query, myConn)
            If myConn.State = ConnectionState.Closed Then
                myConn.Open()
            End If
            Using dr As SqlDataReader = cmd.ExecuteReader
                If dr.Read() Then
                    str = dr(1)
                    SusInvoice = dr(0)
                Else
                    str = ""
                    SusInvoice = ""
                End If
            End Using
            myConn.Close()
        End Using

        If str = "" Or str = ";$" Then
            Return
        End If

        Dim memory() As String = str.Split("$")
        Dim record() As String
        oDgv.Rows.Clear()
        For x As Integer = 0 To memory.Count - 1
            record = memory(x).Split(";")
            If x = 0 Then
                oDiscountCode.Text = record(0)
                lbDiscount.Text = record(1)
                InvoiceLogs = record(2)
            ElseIf memory(x) <> "" And x > 0 Then
                oDgv.Rows.Add(record(0), record(1), record(2), record(3), record(4), record(5), record(6), record(7))
            End If
        Next
        Call OutTotalize()

    End Sub
    Private Function GetItem(ByVal Serial As String) As String
        Dim Query As String = "DECLARE @Code NVARCHAR(MAX) = '" & Serial & "';" _
                              & " SELECT tblItems.PrKey, tblItems.Serial, tblItems.Name, tblItems.Price, tblItems.PackageUnits, tblItems.PackagePrice, tblItems.PackageSerial" _
                              & " FROM tblItems" _
                              & " LEFT OUTER JOIN tblMultiCodes ON tblItems.PrKey = tblMultiCodes.Item" _
                              & " WHERE tblItems.Serial = @Code OR tblItems.PackageSerial = @Code OR tblMultiCodes.Code = @Code"
        Dim result As String
        Using cmd = New SqlCommand(Query, myConn)
            If myConn.State = ConnectionState.Closed Then
                myConn.Open()
            End If

            Using dr As SqlDataReader = cmd.ExecuteReader
                If dr.Read() Then
                    result = dr(0).ToString & ";" & dr(1) & ";" & dr(2) & ";" & dr(3) & ";" & dr(4) & ";" & dr(5) & ";" & dr(6)
                Else
                    result = "0;0;0;0;0;0;0"
                End If
            End Using
            myConn.Close()
        End Using
        Return result
    End Function

    Private Sub Notification(ByVal Notify As String)
        '  Timer1.Enabled = False
        ' counter = 0
        'lblMonitor.Caption = Notify

        'lblMonitor.Visibility = BarItemVisibility.Always
        'Timer1.Enabled = True

    End Sub

    Private Sub SaveOrder(ByVal SaveAndPrint As Boolean)
        ''''''''''''''''
        'for demo
        Cursor = Cursors.WaitCursor
        If GV.AppDemo = True Then
            Using cmd = New SqlCommand("SELECT COUNT(Serial) FROM tblOut1", myConn)
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
Restart:

        If oDgv.RowCount = 0 Then
            MessageBox.Show("No data entered to be saved!", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information)
            oItemSerial.Focus()
        ElseIf oDiscountCode.Text = "" Or checkAgent(False) = False Then
            MessageBox.Show("You must enter a valid card code!", "Invalid Code", MessageBoxButtons.OK, MessageBoxIcon.Information)
            oDiscountCode.Focus()
            oDiscountCode.SelectAll()
        ElseIf oDiscountCode.Text = "0000" Or oDiscountCode.Text = "9999" Then
            MessageBox.Show("You cannot use this code!", "Invalid Code", MessageBoxButtons.OK, MessageBoxIcon.Information)
            oDiscountCode.Focus()
            oDiscountCode.SelectAll()
        ElseIf Val(tbRest.Text) > 1 Or Val(tbRest.Text) < -1 Then
            MessageBox.Show("You must enter the paid amount!", "No Payment", MessageBoxButtons.OK, MessageBoxIcon.Information)
            pUSD.Focus()
            pUSD.SelectAll()

        Else


            'check if the valid qnty
            If CheckQnty() = False Then
                Exit Sub
            End If



            Call frmMain.AutoRate(Today)
            Dim oDate As String = Today.ToString("MM/dd/yyyy")
            Dim oTime As String = Now.ToString("HH:mm")
            'Dim agencyDiscount As String = lbDiscount.Text.Replace("%", "")
            Dim DiscountRate As Single = Val(lbDiscount.Text.Replace("%", ""))
            'add to out1

            Dim Query As String = "INSERT INTO tblOut1 ([Date], [Time], [User], Agent, CardCode, Total, Discount, pUSD, pEGP, pRUB, pEUR, pUAH, pGBP, pVisa, cUSD, cEGP, cRUB, cEUR, cUAH, cGBP, Rest, DiscountRate)" _
                                  & " VALUES ('" & oDate & "', '" & oTime & "', " & GlobalVariables.ID & ", (SELECT Code FROM tblAgency WHERE PinCode = '" & oDiscountCode.Text & "')," _
                                  & " '" & oDiscountCode.Text & "', " & tbTotal.Text.Replace("$", "") & ", " & Val(tbDiscount.Text) & ", " & Val(pUSD.Text) & ", " & Val(pEGP.Text) & ", " & Val(pRUB.Text) & ", " & Val(pEUR.Text) & ", " & Val(pUAH.Text) & ", " & Val(pGBP.Text) & ", " & Val(pVisa.Text) _
                                  & ", " & Val(cUSD.Text) & ", " & Val(cEGP.Text) & ", " & Val(cRUB.Text) & ", " & Val(cEUR.Text) & ", " & Val(cUAH.Text) & ", " & Val(cGBP.Text) & ", " & Val(tbRest.Text) & ", " & DiscountRate & ");"



            Using cmd = New SqlCommand(Query, myConn)
                If myConn.State = ConnectionState.Closed Then
                    myConn.Open()
                End If
                cmd.ExecuteNonQuery()

                cmd.CommandText = "SELECT @@IDENTITY;"
                Using dt As SqlDataReader = cmd.ExecuteReader
                    If dt.Read() Then
                        oSerial.Text = dt(0).ToString
                    End If
                End Using
                myConn.Close()
            End Using


            If myConn.State = ConnectionState.Closed Then
                myConn.Open()
            End If
            Dim theQuery As String = "INSERT INTO tblOut2 (Serial, Kind, Item, Compound, Qnty, Price, Discount, UnitPrice, [User]) VALUES"

            For Each oRow As DataGridViewRow In oDgv.Rows
                theQuery += "('" & oSerial.Text & "', '" & oRow.Cells(1).Value & "', '" & oRow.Cells(7).Value & "', '0', '" & oRow.Cells(0).Value & "', '" & oRow.Cells(6).Value & "', '" & oRow.Cells(5).Value & "', '" & oRow.Cells(4).Value & "', '" & GlobalVariables.ID & "'), "
            Next

            theQuery = theQuery.Substring(0, theQuery.Length - 2)
            theQuery += " ; EXEC setSold;"
            If InvoiceLogs <> "" Then
                InvoiceLogs = InvoiceLogs.Substring(0, InvoiceLogs.Length - 2)
                theQuery &= " UPDATE tblLog SET cInvoice = " & oSerial.Text & " WHERE cID IN (" & InvoiceLogs & ");"
            End If
            If SusInvoice <> "" Then
                theQuery &= " DELETE FROM tblSuspend WHERE PrKey = " & SusInvoice & ";"
            End If

            Using cmd = New SqlCommand(theQuery, myConn)
                cmd.ExecuteNonQuery()
            End Using
            myConn.Close()
            'Sync.SellingCode()

            'clear
            ClearContents()

            Call Notification("Invoice Added")

            If SaveAndPrint = True Then
                ExClass.Invoice(oSerial.Text, True)
            End If

        End If

        Cursor = Cursors.Default


    End Sub
    Public Sub OutTotalize()
        Dim tSales As Decimal = 0
        Dim tDisc As Decimal = 0
        For x As Integer = 0 To oDgv.RowCount - 1
            tSales += oDgv.Rows(x).Cells(6).Value
            tDisc += oDgv.Rows(x).Cells(5).Value
        Next
        'dueAmount = Math.Round(tSales, 2, MidpointRounding.AwayFromZero)

        Dim theRate() As String = GetCurrency().Split(";")


        tbTotal.Text = "$" & Math.Round(tSales, 2, MidpointRounding.AwayFromZero)
        txtREUR.Text = Math.Round(tSales * Val(theRate(1)), 2, MidpointRounding.AwayFromZero)
        txtREGP.Text = Math.Round(tSales * Val(theRate(2)), 2, MidpointRounding.AwayFromZero)
        txtRGBP.Text = Math.Round(tSales * Val(theRate(3)), 2, MidpointRounding.AwayFromZero)
        txtRRUB.Text = Math.Round(tSales * Val(theRate(4)), 2, MidpointRounding.AwayFromZero)
        txtRUAH.Text = Math.Round(tSales * Val(theRate(5)), 2, MidpointRounding.AwayFromZero)

        tbDiscount.Text = Math.Round(tDisc, 2, MidpointRounding.AwayFromZero)
        'tbRest1.Text = GetRest(cbRest1Currency.SelectedIndex)
    End Sub

    Private Function CheckQnty() As Boolean
        If oDgv.RowCount = 0 Then
            Return True
        End If
        Dim Query As String
        Dim vQnty As Boolean = True


        Dim theEnteredItems As String = "("
        For x As Integer = 0 To oDgv.RowCount - 1
            theEnteredItems += oDgv.Rows(x).Cells(7).Value.ToString & ", "
        Next

        theEnteredItems = theEnteredItems.Substring(0, theEnteredItems.Length - 2)
        theEnteredItems += ")"
        Query = "SELECT tblItems.PrKey, COALESCE((ttlIn.Total_In - COALESCE(ttlOut.Total_Out , 0)), 0) AS Net_Amount" _
              & " FROM tblItems" _
              & " LEFT OUTER JOIN" _
              & " (" _
              & " SELECT tblIn2.Item, SUM(tblIn2.Qnty) AS Total_In FROM tblIn2" _
              & " GROUP BY tblIn2.Item" _
              & " ) ttlIn" _
              & " ON tblItems.PrKey = ttlIn.Item" _
              & " LEFT OUTER JOIN" _
              & " (" _
              & " SELECT tblOut2.Item, SUM(tblOut2.Qnty) AS Total_Out FROM tblOut2" _
              & " GROUP BY tblOut2.Item" _
              & " ) ttlOut" _
              & " ON tblItems.PrKey = ttlOut.Item" _
              & " WHERE tblItems.PrKey IN " & theEnteredItems & ";"
        Dim dt As New DataTable
        If myConn.State = ConnectionState.Closed Then
            myConn.Open()
        End If
        Using cmd = New SqlCommand(Query, myConn)
            Using dr As SqlDataReader = cmd.ExecuteReader
                dt.Load(dr)
            End Using
        End Using
        myConn.Close()
        Dim itm, stk As String
        For x As Integer = 0 To dt.Rows.Count - 1
            itm = dt.Rows(x)(0).ToString
            stk = dt.Rows(x)(1).ToString

            For y As Integer = 0 To oDgv.RowCount - 1
                If oDgv.Rows(y).Cells(7).Value = itm Then
                    oDgv.Rows(y).Cells(8).Value = stk
                End If
            Next
        Next

        For Each line As DataGridViewRow In oDgv.Rows
            If Val(line.Cells(0).Value) > Val(line.Cells(8).Value) Then
                Cursor = Cursors.Default
                MessageBox.Show("The entered quantity is more than the available amount!", "Invalid Qnty", MessageBoxButtons.OK, MessageBoxIcon.Information)
                oDgv.ClearSelection()

                line.Selected = True
                vQnty = False
                Exit For
            End If

        Next
        Return vQnty
        Cursor = Cursors.Default

    End Function

    Private Sub frmCashier_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        oItemSerial.Focus()
        oItemSerial.SelectAll()
    End Sub

    Private Sub frmCashier_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Control = True Then
            al1.Visible = True
            al2.Visible = True
            al3.Visible = True
            al5.Visible = True
            al6.Visible = True
            al7.Visible = True
            al8.Visible = True


            If e.KeyCode = Keys.D1 Then
                saveMemory(1)
            ElseIf e.KeyCode = Keys.D2 Then
                saveMemory(2)
            ElseIf e.KeyCode = Keys.D3 Then
                saveMemory(3)
            ElseIf e.KeyCode = Keys.D4 Then
                saveMemory(4)
            ElseIf e.KeyCode = Keys.D5 Then
                saveMemory(5)
            ElseIf e.KeyCode = Keys.D6 Then
                saveMemory(6)
            ElseIf e.KeyCode = Keys.D7 Then
                saveMemory(7)
            ElseIf e.KeyCode = Keys.D8 Then
                saveMemory(8)
            ElseIf e.KeyCode = Keys.D9 Then
                saveMemory(9)
            ElseIf e.KeyCode = Keys.D Then
                btnDiscount.PerformClick()
            ElseIf e.KeyCode = Keys.S Then
                btnSaveInvoice.PerformClick()
            End If
        ElseIf e.Alt = True Then
            If e.KeyCode = Keys.D1 Then
                recallMemory(1)
            ElseIf e.KeyCode = Keys.D2 Then
                recallMemory(2)
            ElseIf e.KeyCode = Keys.D3 Then
                recallMemory(3)
            ElseIf e.KeyCode = Keys.D4 Then
                recallMemory(4)
            ElseIf e.KeyCode = Keys.D5 Then
                recallMemory(5)
            ElseIf e.KeyCode = Keys.D6 Then
                recallMemory(6)
            ElseIf e.KeyCode = Keys.D7 Then
                recallMemory(7)
            ElseIf e.KeyCode = Keys.D8 Then
                recallMemory(8)
            ElseIf e.KeyCode = Keys.D9 Then
                recallMemory(9)
            End If
        End If

        If e.KeyCode = Keys.F1 Then
            oQnty.Focus()
            oQnty.SelectAll()

        ElseIf e.KeyCode = Keys.F2 Then
            oItemSerial.Focus()
            oItemSerial.SelectAll()
        ElseIf e.KeyCode = Keys.F3 Then
            oItemName.Focus()
            oItemName.SelectAll()
        ElseIf e.KeyCode = Keys.F4 Then
            e.Handled = True
            pUSD.Focus()
            pUSD.SelectAll()
        ElseIf e.KeyCode = Keys.F5 Then
            btnSaveInvoice.PerformClick()
        ElseIf e.KeyCode = Keys.F6 Then
            btnInvoicePrint.PerformClick()
        ElseIf e.KeyCode = Keys.F7 AndAlso GlobalVariables.authority = "Admin" Then
            InvoiceLogs &= CStr(ExClass.RecordLog(3)) & ", "
            ClearContents()
        ElseIf e.KeyValue = Keys.F And e.Control Then
            oSearch.Focus()
            oSearch.SelectAll()
        End If


    End Sub

    Private Sub frmCashier_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If Char.IsDigit(e.KeyChar) AndAlso oDgv.Focused = True AndAlso oDgv.RowCount <> 0 AndAlso GlobalVariables.authority = "Admin" Then

            Dim Num As String = e.KeyChar
            If IsNumeric(Num) Then
                Dim NetQuery As String = "SELECT tblItems.PrKey, tblItems.Serial, tblItems.Name, ttlIn.Total_In, COALESCE(ttlOut.Total_Out , 0) AS Total_Out,  CONVERT(FLOAT, (ttlIn.Total_In - COALESCE(ttlOut.Total_Out , 0))) AS Net_Amount" _
        & " FROM tblItems" _
        & " LEFT OUTER JOIN" _
        & " (" _
        & " SELECT tblIn2.Item, SUM(tblIn2.Qnty) AS Total_In FROM tblIn2" _
        & " GROUP BY tblIn2.Item" _
        & " ) ttlIn" _
        & " ON tblItems.PrKey = ttlIn.Item" _
        & " LEFT OUTER JOIN" _
        & " (" _
        & " SELECT tblOut2.Item, SUM(tblOut2.Qnty) AS Total_Out FROM tblOut2" _
        & " GROUP BY tblOut2.Item" _
        & " ) ttlOut" _
        & " ON tblItems.PrKey = ttlOut.Item" _
        & " WHERE tblItems.PrKey = " & oDgv.CurrentRow.Cells(7).Value & ";"
                Dim theQuant As Decimal
                Using cmd = New SqlCommand(NetQuery, myConn)
                    If myConn.State = ConnectionState.Closed Then
                        myConn.Open()
                    End If
                    Using dt As SqlDataReader = cmd.ExecuteReader
                        If dt.Read() And Not IsDBNull(dt(5)) Then
                            theQuant = dt(5)
                        Else
                            theQuant = 0
                        End If
                    End Using
                    myConn.Close()
                End Using

                'to save to log
                InvoiceLogs &= CStr(ExClass.RecordLog(5)) & ", "

                oDgv.CurrentRow.Cells(0).Value = Num
                oDgv.CurrentRow.Cells(5).Value = "0"
                oDgv.CurrentRow.Cells(6).Value = Math.Round(oDgv.CurrentRow.Cells(0).Value * oDgv.CurrentRow.Cells(4).Value, 2, MidpointRounding.AwayFromZero)
                lbNetQnty.Text = Math.Round(Val(theQuant - Val(Num)), 2, MidpointRounding.AwayFromZero)
                ScreenMemo(True)
            End If
            ApplyDiscount(Val(lbDiscount.Text.Replace("%", "")))

        ElseIf (e.KeyChar = "+" OrElse e.KeyChar = "-") AndAlso oDgv.Focused = True AndAlso oDgv.RowCount <> 0 Then
            Dim Num As Integer

            If e.KeyChar = "+" Then
                Num = oDgv.CurrentRow.Cells(0).Value + 1
            ElseIf e.KeyChar = "-" AndAlso GlobalVariables.authority = "Admin" Then
                InvoiceLogs &= CStr(ExClass.RecordLog(5)) & ", "
                Num = oDgv.CurrentRow.Cells(0).Value - 1
            End If
            ScreenMemo(True)
            Dim NetQuery As String = "SELECT tblItems.PrKey, tblItems.Serial, tblItems.Name, ttlIn.Total_In, COALESCE(ttlOut.Total_Out , 0) AS Total_Out,  (ttlIn.Total_In - COALESCE(ttlOut.Total_Out , 0)) AS Net_Amount" _
    & " FROM tblItems" _
    & " LEFT OUTER JOIN" _
    & " (" _
    & " SELECT tblIn2.Item, SUM(tblIn2.Qnty) AS Total_In FROM tblIn2" _
    & " GROUP BY tblIn2.Item" _
    & " ) ttlIn" _
    & " ON tblItems.PrKey = ttlIn.Item" _
    & " LEFT OUTER JOIN" _
    & " (" _
    & " SELECT tblOut2.Item, SUM(tblOut2.Qnty) AS Total_Out FROM tblOut2" _
    & " GROUP BY tblOut2.Item" _
    & " ) ttlOut" _
    & " ON tblItems.PrKey = ttlOut.Item" _
    & " WHERE tblItems.PrKey = " & oDgv.CurrentRow.Cells(7).Value & ";"
            Dim theQuant As Decimal
            Using cmd = New SqlCommand(NetQuery, myConn)
                If myConn.State = ConnectionState.Closed Then
                    myConn.Open()
                End If
                Using dt As SqlDataReader = cmd.ExecuteReader
                    If dt.Read() And Not IsDBNull(dt(5)) Then
                        theQuant = dt(5)
                    Else
                        theQuant = 0
                    End If
                End Using
                myConn.Close()
            End Using

            If Num = 0 AndAlso GlobalVariables.authority = "Admin" Then

                InvoiceLogs &= CStr(ExClass.RecordLog(2)) & ", "

                oDgv.Rows.Remove(oDgv.CurrentRow)
                oQnty.Text = "1"
                lbNetQnty.Text = Val(theQuant - Num)
                oItemSerial.Focus()
                oItemSerial.SelectAll()
                ScreenMemo(True)
            Else
                If GlobalVariables.authority = "Admin" Then
                    InvoiceLogs &= CStr(ExClass.RecordLog(5)) & ", "
                    oDgv.CurrentRow.Cells(0).Value = Num
                    oDgv.CurrentRow.Cells(5).Value = "0"
                    oDgv.CurrentRow.Cells(6).Value = Math.Round(oDgv.CurrentRow.Cells(0).Value * oDgv.CurrentRow.Cells(4).Value, 2, MidpointRounding.AwayFromZero)
                    lbNetQnty.Text = Val(theQuant - Num)
                    ScreenMemo(True)
                End If
            End If

            ApplyDiscount(Val(lbDiscount.Text.Replace("%", "")))
        End If
    End Sub

    Private Sub frmCashier_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.Control = False Then
            al1.Visible = False
            al2.Visible = False
            al3.Visible = False
            al5.Visible = False
            al6.Visible = False
            al7.Visible = False
            al8.Visible = False
        End If
    End Sub


    Private Sub frmCashier_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        oQnty.Height = 30
        oDiscountCode.Height = 30
        oSearch.Height = 30

        oDgv.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        oDgv.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        oDgv.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        oDgv.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        oDgv.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        oDgv.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        oDgv.Columns(7).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

        SplashScreenManager1.ShowWaitForm()

        RibbonControl.Manager.UseAltKeyForMenu = False
        BarStaticItem2.Caption = StrConv(GlobalVariables.user, VbStrConv.ProperCase)
        'Fill the items
        Dim FillQuery As String = "SELECT PrKey, Serial, Name FROM tblItems" _
                                                          & " UNION ALL" _
                                                          & " SELECT tblItems.PrKey, tblMultiCodes.Code AS Serial, tblItems.Name" _
                                                          & " FROM tblMultiCodes INNER JOIN tblItems ON tblMultiCodes.Item = tblItems.PrKey" _
                                                          & " UNION ALL" _
                                                          & " SELECT PrKey, PackageSerial AS Code, Name + '**' FROM tblItems" _
                                                          & " WHERE PackageSerial IS NOT NULL AND PackageSerial !=''" _
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

            oItemSerial.DataSource = ds.Tables(0)
            oItemSerial.DisplayMember = "Serial"
            oItemSerial.ValueMember = "PrKey"
            oSearch.EditValue = Nothing

            oItemName.DataSource = ds.Tables(0)
            oItemName.DisplayMember = "Name"
            oItemName.Text = Nothing

            myConn.Close()

        End Using

        oQnty.Text = "1"
        oItemSerial.Text = ""
        oItemSerial.Focus()

        Dim rep As New DevExpress.XtraReports.UI.XtraReport()


        CheckEdit1.Checked = My.Settings.SaveOrPrint
        Call frmMain.AutoRate(Today)
        Authorize()
        ScreenMemo(False)
        lblAgent.Visibility = BarItemVisibility.Always
        If GlobalVariables.authority = "Admin" Then
            fillSuspended()
        End If

        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub KryptonButton8_Click(sender As System.Object, e As System.EventArgs) Handles KryptonButton8.Click

        If Val(oQnty.Text) = 0 Then
            MessageBox.Show("You must enter valid quantity!", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Information)
            oQnty.Focus()
            oQnty.SelectAll()
        ElseIf oItemSerial.Text = "" Then
            MessageBox.Show("You must enter a valid code!", "Invalid Code", MessageBoxButtons.OK, MessageBoxIcon.Information)
            oItemSerial.Focus()
            oItemSerial.SelectAll()

        Else

            'check if item already exists

            Dim result() As String = GetItem(oItemSerial.Text).Split(";")
            Dim PrKey As Integer = result(0)
            If PrKey = 0 Then
                MessageBox.Show("The entered item doesn't exist!", "Invalid Item", MessageBoxButtons.OK, MessageBoxIcon.Information)
                oItemSerial.Focus()
                oItemSerial.SelectAll()
                Exit Sub
            End If

            Dim prQnty As Decimal
            Dim type As String = "SGL"
            Dim wholeQnty As Single = Math.Round(Val(oQnty.Text), 3, MidpointRounding.AwayFromZero)
            Dim dsc As Single = 0
            Dim thePrice As Single = result(3)
            If oItemSerial.Text = result(6) Then
                type = "PKG"
                wholeQnty = result(4)
                dsc = 0
                thePrice = result(5) / result(4)
                thePrice = Math.Round(thePrice, 2, MidpointRounding.AwayFromZero)
            End If


            For x As Integer = 0 To oDgv.RowCount - 1

                If (oDgv.Rows(x).Cells(7).Value.ToString = result(0)) AndAlso (oDgv.Rows(x).Cells(1).Value.ToString = type) Then
                    prQnty = oDgv.Rows(x).Cells(0).Value
                    dsc *= (wholeQnty + prQnty)
                    dsc = Math.Round(dsc, 2, MidpointRounding.AwayFromZero)
                    If type = "PKG" Then
                        oDgv.Rows(x).SetValues((wholeQnty + prQnty), type, oItemSerial.Text.ToUpper, result(2).ToUpper, thePrice, dsc, Math.Round((Val(result(5)) * ((wholeQnty + prQnty)) / Val(result(4))), 2, MidpointRounding.AwayFromZero), PrKey)
                    Else
                        oDgv.Rows(x).SetValues((wholeQnty + prQnty), type, oItemSerial.Text.ToUpper, result(2).ToUpper, thePrice, dsc, Math.Round((Val(oUnitPrice.Text) * (wholeQnty + prQnty) - dsc), 2, MidpointRounding.AwayFromZero), PrKey)
                    End If

                    ScreenMemo(True)




                    Call Notification("New quantity added!")
                    ApplyDiscount(Val(lbDiscount.Text.Replace("%", "")))
                    oQnty.Text = "1"
                    oItemSerial.Text = Nothing
                    oItemName.Text = Nothing
                    oUnitPrice.Text = ""
                    oSubTotal.Text = ""
                    oDgv.FirstDisplayedScrollingRowIndex = x
                    oDgv.ClearSelection()

                    oDgv.Rows(x).Selected = True
                    oItemSerial.Focus()
                    oItemSerial.SelectAll()
                    Exit Sub
                End If

            Next

            'Add the row to the datagrid
            dsc *= (wholeQnty + prQnty)
            dsc = Math.Round(dsc, 2, MidpointRounding.AwayFromZero)

            If type = "PKG" Then
                oDgv.Rows.Add((wholeQnty + prQnty), type, oItemSerial.Text.ToUpper, result(2).ToUpper, thePrice, dsc, Math.Round((Val(result(5)) * ((wholeQnty + prQnty)) / Val(result(4))), 2, MidpointRounding.AwayFromZero), PrKey)
            Else
                oDgv.Rows.Add((wholeQnty + prQnty), type, oItemSerial.Text.ToUpper, result(2).ToUpper, thePrice, dsc, Math.Round((Val(oUnitPrice.Text) * (wholeQnty + prQnty) - dsc), 2, MidpointRounding.AwayFromZero), PrKey)
            End If
            ScreenMemo(True)
            ' oDgv.Rows.Add((wholeQnty + prQnty), type, oItemSerial.Text.ToUpper, result(2).ToUpper, thePrice, dsc, Math.Round((Val(oUnitPrice.Text) * (wholeQnty + prQnty) - dsc), 2, MidpointRounding.AwayFromZero), PrKey)


            Call Notification("New item added!")

            ApplyDiscount(Val(lbDiscount.Text.Replace("%", "")))

            oQnty.Text = "1"
            oItemSerial.Text = Nothing
            oItemName.Text = Nothing
            oUnitPrice.Text = ""
            oSubTotal.Text = ""
            oDgv.FirstDisplayedScrollingRowIndex = oDgv.RowCount - 1
            oDgv.ClearSelection()

            oDgv.Rows(oDgv.RowCount - 1).Selected = True
            oItemSerial.Focus()
            oItemSerial.SelectAll()

        End If
        ' End If
        Call OutTotalize()

    End Sub

    Private Sub oEdit_Click(sender As System.Object, e As System.EventArgs)

        'modifiy the selected tow

        If Val(oQnty.Text) = 0 Then
            MessageBox.Show("You must enter valid quantity!", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Information)
            oQnty.Focus()
            oQnty.SelectAll()
        ElseIf oItemSerial.Text = "" Then
            MessageBox.Show("You must enter a vaild code!", "Invalid Code", MessageBoxButtons.OK, MessageBoxIcon.Information)
            oItemSerial.Focus()
            oItemSerial.SelectAll()
        ElseIf oItemName.Text = "" Then
            MessageBox.Show("You must enter a valid item name!", "Invalid Name", MessageBoxButtons.OK, MessageBoxIcon.Information)
            oItemSerial.Focus()
            oItemSerial.SelectAll()
        Else

            'check if item already exists
            Dim result() As String = GetItem(oItemSerial.Text).Split(";")
            Dim PrKey As Integer = result(0)

            If PrKey = 0 Then
                MessageBox.Show("The entered item doesn't exist!", "Invalid Item", MessageBoxButtons.OK, MessageBoxIcon.Information)
                oItemSerial.Focus()
                oItemSerial.SelectAll()
                Exit Sub
            End If



            'check if the item has been added to the grid before

            If oDgv.CurrentRow.Cells(7).Value <> result(0) Then
                For x As Integer = 0 To oDgv.RowCount - 1
                    If oDgv.Rows(x).Cells(7).Value = result(0) Then
                        MessageBox.Show("You have entered this item before!", "Duplicated Item", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                Next
            End If

            Dim cr As Integer = oDgv.CurrentRow.Index

            For x As Integer = 0 To oDgv.RowCount - 1

                If Not cr = x Then
                    If (oDgv.Rows(x).Cells(7).Value.ToString = result(0)) Then
                        MessageBox.Show("You have entered this item before!", "Duplicated Item", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        oDgv.ClearSelection()
                        oDgv.Rows(x).Selected = True
                        oItemSerial.Focus()
                        oItemSerial.SelectAll()
                        Return
                    End If
                End If
            Next


            'Add the row to the datagrid

            Dim type As String = "SGL"
            Dim wholeQnty As Single = Val(oQnty.Text)
            Dim dsc As Single = 0

            If oItemSerial.Text = result(6) Then
                type = "PKG"
                wholeQnty = result(4)
                dsc = (Val(result(3)) * wholeQnty) - Val(result(5))
                dsc = Val(result(3)) - (Val(result(5)) / Val(result(4)))
                dsc = Math.Round(dsc, 2, MidpointRounding.AwayFromZero)
            End If


            Dim theRow As String()
            theRow = New String() {(wholeQnty), type, oItemSerial.Text.ToUpper, result(2).ToUpper, Math.Round(Val(oUnitPrice.Text), 2, MidpointRounding.AwayFromZero), dsc, Math.Round((Val(oUnitPrice.Text) * (wholeQnty) - dsc), 2, MidpointRounding.AwayFromZero), PrKey}

            oDgv.CurrentRow.SetValues(theRow)

            KryptonButton8.Enabled = True
            oRemove.Enabled = True



            Call Notification("Item modified!")
            oQnty.Text = "1"
            oItemSerial.Text = Nothing
            oItemName.Text = Nothing
            oUnitPrice.Text = ""
            oSubTotal.Text = ""

            oItemSerial.Focus()
            ApplyDiscount(Val(lbDiscount.Text.Replace("%", "")))
            oQnty.SelectAll()
        End If



    End Sub

    Private Sub oRemove_Click(sender As System.Object, e As System.EventArgs) Handles oRemove.Click
        If Not oDgv.RowCount = 0 Then
            If ExClass.CheckValidity Or GlobalVariables.authority = "Admin" Or GlobalVariables.authority = "Developer" Then
                InvoiceLogs &= CStr(ExClass.RecordLog(2)) & ", "
                oDgv.Rows.Remove(oDgv.CurrentRow)

                'update the discount 
                Call OutTotalize()
                oQnty.Text = "1"
                oItemSerial.Text = Nothing
                oItemName.Text = Nothing
                oUnitPrice.Text = ""
                oSubTotal.Text = ""

                oItemSerial.Focus()
                oQnty.SelectAll()
                ScreenMemo(True)
                Notification("Current item removed!")
                Call OutTotalize()
            End If
        End If
    End Sub

    Private Sub KryptonButton5_Click(sender As System.Object, e As System.EventArgs) Handles btnSaveInvoice.Click
        If CheckEdit1.Checked = True Then
            SaveOrder(True)
        Else
            SaveOrder(False)
        End If
    End Sub

    Private Sub KryptonButton4_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelInvoice.Click
        If GlobalVariables.authority = "Admin" Then
            ExClass.RecordLog(3)
            ClearContents()
        ElseIf ExClass.CheckValidity Then
            ExClass.RecordLog(3)
            ClearContents()
        End If

    End Sub

    Private Sub krInvoicePrint_Click(sender As System.Object, e As System.EventArgs) Handles btnInvoicePrint.Click
        ExClass.Invoice(oSerial.Text, True)
    End Sub

    Private Sub krInvoiceShow_Click(sender As System.Object, e As System.EventArgs) Handles btnShowInvoice.Click
        ExClass.Invoice(oSerial.Text, False)
    End Sub

    Private Sub RepositoryItemSearchControl1_EditValueChanged(sender As Object, e As EventArgs)
        'MsgBox(oSearch.EditValue)
        ' MsgBox(oSearch.Edit.GetDisplayText(oSearch.EditValue))

    End Sub

    Private Sub oSearch_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles oSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Not oSearch.EditValue = "" Then
                InvoiceRecall(oSearch.EditValue)
            Else
                Dim txt As String = oSearch.Text
                ClearContents()
                oSearch.Text = txt
                oSearch.Focus()
                oSearch.SelectAll()
            End If
        ElseIf e.KeyCode = Keys.Escape Then
            ClearContents()
        End If
    End Sub

    Private Sub oSearch_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles oSearch.KeyPress
        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub oSearch_TextChanged(sender As Object, e As System.EventArgs) Handles oSearch.TextChanged
        If oSearch.EditValue = "" Then
            ClearContents()
        End If
    End Sub

    Private Sub oItemSerial_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles oItemSerial.KeyDown

        If e.Control = True And e.KeyCode = Keys.Enter Then
            oDiscountCode.Focus()
            oDiscountCode.SelectAll()
            Exit Sub
        End If

        If e.KeyCode = Keys.Enter And Not oItemSerial.Text = "" Then

            If oItemSerial.Text Like "5" & "*" Then
                oDiscountCode.Text = oItemSerial.Text
                oItemSerial.Text = ""
                checkAgent(True)
                Exit Sub
            End If

            'shortcut to save the invoice
            If oItemSerial.Text = " " AndAlso btnSaveInvoice.Enabled = True Then
                SaveOrder(False)
                Exit Sub
            ElseIf oItemSerial.Text = "  " AndAlso btnSaveInvoice.Enabled = True Then
                SaveOrder(True)
                Exit Sub
            ElseIf (oItemSerial.Text = " " Or oItemSerial.Text = "  ") AndAlso btnSaveInvoice.Enabled = False Then
                Exit Sub
            End If

            If Not oItemSerial.Text = "" Then
                Dim resString As String = GetItem(oItemSerial.Text)
                Dim result() As String = resString.Split(";")
                Application.DoEvents()
                If result(2) = "0" And oItemSerial.Text Like "20040" & "*" Then
                    '   oItemName.Text = result(2)
                    'Else
                    ''''to fix the barcode error!
                    Dim brcd As Int64
                    Dim extraQuery As String = "SELECT COUNT(tblItems.PrKey) FROM tblItems" _
                                               & " LEFT OUTER JOIN tblMultiCodes ON tblItems.PrKey = tblMultiCodes.Item" _
                                               & " WHERE tblItems.Serial = '" & oItemSerial.Text & "' OR tblMultiCodes.Code = '" & oItemSerial.Text & "'"
                    Using cmd = New SqlCommand(extraQuery, myConn)
                        If myConn.State = ConnectionState.Closed Then
                            myConn.Open()
                        End If
                        brcd = cmd.ExecuteScalar
                        myConn.Close()
                    End Using
                    If brcd = 0 Then
                        Try
                            '####
                            'add weighed items
                            'Dim wwcode As String
                            Dim wwQnty As Decimal = 0.0
                            Dim FstPart, SndPart As String
                            FstPart = oItemSerial.Text.Substring(0, 7)
                            SndPart = oItemSerial.Text.Substring(8, 2) & "." & oItemSerial.Text.Substring(10)
                            SndPart *= 10
                            oItemSerial.Text = FstPart
                            If myConn.State = ConnectionState.Closed Then
                                myConn.Open()
                            End If
                            Using cmd2 = New SqlCommand("SELECT * FROM tblItems WHERE Serial = '" & FstPart & "'", myConn)
                                Using dr As SqlDataReader = cmd2.ExecuteReader
                                    If dr.Read() Then
                                        wwQnty = dr(3)
                                        oUnitPrice.Text = wwQnty
                                        oQnty.Text = (Convert.ToDecimal(SndPart)) / 100
                                    Else
                                        oItemName.Text = Nothing
                                    End If
                                End Using
                            End Using
                            myConn.Close()
                        Catch ex As Exception

                        End Try

                    End If


                End If
            Else
                oItemName.Text = Nothing
            End If
            KryptonButton8.PerformClick()
        ElseIf e.Control = True And e.KeyCode = Keys.K And Not oItemSerial.Text = "" Then
            oItemSerial.Text = frmMain.FindSerial(oItemSerial.Text)
        End If

    End Sub

    Private Sub oItemSerial_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles oItemSerial.KeyPress
        If e.KeyChar = "+" And oItemSerial.Text Like "[*]" & "*" And GlobalVariables.authority = "Admin" Then
            Dim Num As String = oItemSerial.Text.Substring(1)
            If IsNumeric(Num) Then
                Num = Math.Round(Val(Num), 2, MidpointRounding.AwayFromZero)
                e.Handled = True
                Try

                    Dim NetQuery As String = "SELECT tblItems.PrKey, tblItems.Serial, tblItems.Name, ttlIn.Total_In, COALESCE(ttlOut.Total_Out , 0) AS Total_Out,  (ttlIn.Total_In - COALESCE(ttlOut.Total_Out , 0)) AS Net_Amount" _
                   & " FROM tblItems" _
                   & " LEFT OUTER JOIN" _
                   & " (" _
                   & " SELECT tblIn2.Item, SUM(tblIn2.Qnty) AS Total_In FROM tblIn2" _
                   & " GROUP BY tblIn2.Item" _
                   & " ) ttlIn" _
                   & " ON tblItems.PrKey = ttlIn.Item" _
                   & " LEFT OUTER JOIN" _
                   & " (" _
                   & " SELECT tblOut2.Item, SUM(tblOut2.Qnty) AS Total_Out FROM tblOut2" _
                   & " GROUP BY tblOut2.Item" _
                   & " ) ttlOut" _
                   & " ON tblItems.PrKey = ttlOut.Item" _
                   & " WHERE tblItems.PrKey = '" & oDgv.CurrentRow.Cells(7).Value & "'"
                    Dim theQuant As Decimal
                    Using cmd = New SqlCommand(NetQuery, myConn)
                        If myConn.State = ConnectionState.Closed Then
                            myConn.Open()
                        End If
                        Using dt As SqlDataReader = cmd.ExecuteReader
                            If dt.Read() Then
                                theQuant = dt(5)
                            End If
                        End Using
                    End Using

                    For Each row In oDgv.SelectedRows
                        row.Cells(0).Value = Num
                        row.Cells(6).Value = Math.Round(row.Cells(0).Value * row.Cells(4).Value, 2, MidpointRounding.AwayFromZero)
                    Next
                    ScreenMemo(True)
                    ApplyDiscount(Val(lbDiscount.Text.Replace("%", "")))
                Catch ex As Exception

                End Try
                oItemSerial.Text = ""
                oItemSerial.Focus()
            End If
        ElseIf e.KeyChar = "-" And Not oDgv.Rows.Count = 0 And oItemSerial.Text = "" And GlobalVariables.authority = "Admin" Then
            e.Handled = True
            If oDgv.CurrentRow.Cells(0).Value <= 1 Then
                InvoiceLogs &= CStr(ExClass.RecordLog(2)) & ", "
                oDgv.Rows.Remove(oDgv.CurrentRow)
                ScreenMemo(True)
            Else
                For Each row In oDgv.SelectedRows
                    row.Cells(0).Value -= 1
                    row.Cells(6).Value = Math.Round(row.Cells(0).Value * row.Cells(4).Value, 2, MidpointRounding.AwayFromZero)
                    row.Cells(5).Value = "0"
                    ScreenMemo(True)
                Next
            End If
            Call OutTotalize()
        ElseIf e.KeyChar = "+" And oItemSerial.Text = "" And Not oDgv.RowCount = 0 Then
            ''check the qnty

            e.Handled = True

            For Each row In oDgv.SelectedRows
                row.Cells(0).Value += 1
                row.Cells(5).Value = "0"
                row.cells(6).Value = Math.Round(row.Cells(0).Value * row.Cells(4).Value, 2, MidpointRounding.AwayFromZero)
                ScreenMemo(True)
            Next

            ApplyDiscount(Val(lbDiscount.Text.Replace("%", "")))
        End If


    End Sub

    Private Sub oItemSerial_LostFocus(sender As Object, e As System.EventArgs) Handles oItemSerial.LostFocus
        oItemSerial.Text = oItemSerial.Text.ToUpper
        Dim itmName As String = ""
        If Not oItemSerial.Text = "" Then
            Dim result() As String = GetItem(oItemSerial.Text).Split(";")
            itmName = result(2)
        End If

        If itmName = "0" Then
            oItemName.Text = ""
        Else
            oItemName.Text = itmName
        End If
    End Sub

    Private Sub oItemSerial_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles oItemSerial.SelectedIndexChanged
        If oItemSerial.Text <> "" Then

            'enter the value


            ''''To get the price:
            Dim Result() As String = GetItem(oItemSerial.Text).Split(";")

            oUnitPrice.Text = Result(3)


            Try
                'Show the Net Qnty
                Dim NetQuery As String
                NetQuery = "SELECT tblItems.PrKey, tblItems.Serial, tblItems.Name, ttlIn.Total_In, COALESCE(ttlOut.Total_Out , 0) AS Total_Out,  CONVERT(FLOAT, (ttlIn.Total_In - COALESCE(ttlOut.Total_Out , 0))) AS Net_Amount" _
                    & " FROM tblItems" _
                    & " LEFT OUTER JOIN" _
                    & " (" _
                    & " SELECT tblIn2.Item, SUM(tblIn2.Qnty) AS Total_In FROM tblIn2" _
                    & " GROUP BY tblIn2.Item" _
                    & " ) ttlIn" _
                    & " ON tblItems.PrKey = ttlIn.Item" _
                    & " LEFT OUTER JOIN" _
                    & " (" _
                    & " SELECT tblOut2.Item, SUM(tblOut2.Qnty) AS Total_Out FROM tblOut2" _
                    & " GROUP BY tblOut2.Item" _
                    & " ) ttlOut" _
                    & " ON tblItems.PrKey = ttlOut.Item" _
                    & " WHERE tblItems.PrKey = " & Result(0)

                Dim theQuant As Decimal
                Using cmd = New SqlCommand(NetQuery, myConn)
                    If myConn.State = ConnectionState.Closed Then
                        myConn.Open()
                    End If

                    Using dt As SqlDataReader = cmd.ExecuteReader
                        If dt.Read() Then
                            theQuant = dt(5)
                        Else
                            theQuant = "00"
                        End If
                    End Using

                    'check the item if found in the grid
                    For x As Integer = 0 To oDgv.Rows.Count - 1
                        If (oDgv.Rows(x).Cells(7).Value.ToString = Result(0)) Then
                            theQuant -= oDgv.Rows(x).Cells(0).Value
                        End If
                    Next
                    lbNetQnty.Text = theQuant.ToString

                    myConn.Close()

                End Using
            Catch ex As Exception
                lbNetQnty.Text = "00"
            End Try
        Else
            lbNetQnty.Text = "00"
        End If
    End Sub

    Private Sub oItemName_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles oItemName.KeyDown

        If e.KeyCode = Keys.Enter And Not oItemName.Text = "" Then
            oItemSerial.Focus()
        End If
    End Sub

    Private Sub oItemName_LostFocus(sender As Object, e As System.EventArgs) Handles oItemName.LostFocus

        If Not oItemName.Text = "" Then
            Dim Query As String
            Dim str As String = oItemName.Text
            If str Like "*" & "[**]" Then
                str = str.Substring(0, str.Length - 2)
                Query = "SELECT PackageSerial FROM tblItems WHERE Name = N'" & str & "';"
            Else
                Query = "SELECT Serial FROM tblItems WHERE Name = N'" & str & "';"
            End If
            Using cmd = New SqlCommand(Query, myConn)
                If myConn.State = ConnectionState.Closed Then
                    myConn.Open()
                End If
                Try
                    oItemSerial.Text = cmd.ExecuteScalar
                Catch ex As Exception
                    oItemSerial.Text = ""
                End Try

                myConn.Close()
            End Using
        Else
            oItemSerial.Text = Nothing
        End If

        Dim result() As String = GetItem(oItemSerial.Text).Split(";")
        oUnitPrice.Text = result(3)

    End Sub

    Private Sub oQnty_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles oQnty.EditValueChanged
        Dim str1, str2 As String
        Try
            str1 = oQnty.Text.Substring(0, oQnty.Text.IndexOf(".") + 4)
        Catch ex As Exception
            str1 = oQnty.Text
        End Try
        str2 = (Val(str1) * Val(oUnitPrice.Text))
        If str2 Like "*" & "." & "*" Then
            Try
                str2 = str2.Substring(0, str2.IndexOf(".") + 3)
            Catch ex As Exception

            End Try
        End If
        oSubTotal.Text = str2

    End Sub

    Private Sub oUnitPrice_EditValueChanged(sender As System.Object, e As System.EventArgs)
        oSubTotal.Text = Val(oQnty.Text) * Val(oUnitPrice.Text)
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        'If counter < 7 Then
        '    If lblMonitor.Visibility = BarItemVisibility.Always Then
        '        lblMonitor.Visibility = BarItemVisibility.Never
        '    Else
        '        lblMonitor.Visibility = BarItemVisibility.Always
        '    End If
        '    counter += 1
        'Else
        '    lblMonitor.Visibility = BarItemVisibility.Never
        'End If
    End Sub

    Private Sub oDiscountCode_GotFocus(sender As Object, e As EventArgs) Handles oDiscountCode.GotFocus
        oDiscountCode.SelectAll()
    End Sub

    Private Sub oDiscountCode_KeyDown(sender As Object, e As KeyEventArgs) Handles oDiscountCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            checkAgent(True)
        End If
    End Sub


    Private Sub oDgv_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles oDgv.CellClick
        Try
            oDgv.CurrentRow.Selected = True

            oQnty.Text = oDgv.CurrentRow.Cells(0).Value
            oItemName.Text = oDgv.CurrentRow.Cells(3).Value
            oItemSerial.Text = oDgv.CurrentRow.Cells(2).Value
            oUnitPrice.Text = oDgv.CurrentRow.Cells(4).Value
            oSubTotal.Text = oDgv.CurrentRow.Cells(6).Value

        Catch ex As Exception

        End Try
    End Sub

    'Private Sub tbTotal_TextChanged(sender As Object, e As System.EventArgs)
    '    Try
    '        tbRest1.Text = Val(tbPaid.Text) - Val(tbTotal.Text.Replace("$", ""))
    '    Catch ex As Exception

    '    End Try
    'End Sub

    Private Sub oUnitPrice_TextChanged(sender As Object, e As System.EventArgs) Handles oUnitPrice.TextChanged
        oSubTotal.Text = Val(oQnty.Text) * Val(oUnitPrice.Text)
    End Sub

    Private Sub oQnty_GotFocus(sender As Object, e As System.EventArgs) Handles oQnty.GotFocus
        oQnty.SelectAll()
    End Sub

    Private Sub oQnty_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles oQnty.KeyDown
        If (e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Down) And Not Val(oQnty.Text) = 0 Then
            oItemSerial.Focus()
            oItemSerial.SelectAll()
        End If
    End Sub

    Private Sub SimpleButton3_Click(sender As System.Object, e As System.EventArgs) Handles btnChangeUser.ItemClick
        frmLogin.Close()
        frmLogin.UsernameTextBox.Text = Nothing
        frmLogin.PasswordTextBox.Text = Nothing
        frmLogin.ShowDialog()
        BarStaticItem2.Caption = StrConv(GlobalVariables.user, VbStrConv.ProperCase)
        Authorize()
    End Sub

    Private Sub SimpleButton4_Click(sender As System.Object, e As System.EventArgs) Handles btnChangePassword.ItemClick
        frmPassword.ShowDialog()
    End Sub

    Private Sub SimpleButton1_Click(sender As System.Object, e As System.EventArgs) Handles btnIncome.ItemClick
        frmCash.Text = "IMPORTS"
        'frmCash.cCurrency.SelectedIndex = cbPaidCurrency.SelectedIndex
        frmCash.ShowDialog()
        oItemSerial.Focus()
        oItemSerial.SelectAll()
    End Sub

    Private Sub SimpleButton2_Click(sender As System.Object, e As System.EventArgs) Handles btnExpenditure.ItemClick
        frmCash.Text = "EXPORTS"
        'frmCash.cCurrency.SelectedIndex = cbPaidCurrency.SelectedIndex
        frmCash.ShowDialog()
        oItemSerial.Focus()
        oItemSerial.SelectAll()
    End Sub

    Private Sub SimpleButton5_Click(sender As System.Object, e As System.EventArgs) Handles btnCurrency.ItemClick
        'frmRates.Show()
        frmCurrency.ShowDialog()
    End Sub

    Private Sub oQnty_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles oQnty.KeyPress
        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) And Not e.KeyChar = "." Then
            e.Handled = True
        ElseIf e.KeyChar = "." And oQnty.Text Like "*" & "." & "*" Then
            e.Handled = True
        End If
    End Sub

    Private Sub CheckEdit1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckEdit1.CheckedChanged
        If CheckEdit1.Checked = True Then
            btnSaveInvoice.Text = "Save And Print"
        Else
            btnSaveInvoice.Text = "Save"
        End If
        My.Settings.SaveOrPrint = CheckEdit1.Checked
        My.Settings.Save()
    End Sub

    'Private Sub tbPaid_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
    '    If e.Control = True And e.KeyCode = Keys.Enter Then
    '        oItemSerial.Focus()
    '        oItemSerial.SelectAll()
    '        'ElseIf e.KeyCode = Keys.Enter Then
    '        '    btnSaveInvoice.PerformClick()
    '    ElseIf e.KeyCode = Keys.Down Then
    '        e.Handled = True
    '        If cbPaidCurrency.SelectedIndex = 5 Then
    '            cbPaidCurrency.SelectedIndex = 0
    '        Else
    '            cbPaidCurrency.SelectedIndex += 1
    '        End If
    '    ElseIf e.KeyCode = Keys.Up Then
    '        e.Handled = True
    '        If cbPaidCurrency.SelectedIndex = 0 Then
    '            cbPaidCurrency.SelectedIndex = 5
    '        Else
    '            cbPaidCurrency.SelectedIndex -= 1
    '        End If
    '    End If
    'End Sub

    'Private Sub tbPaid_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs)
    '    If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) And Not e.KeyChar = "." Then
    '        e.Handled = True
    '    ElseIf e.KeyChar = "." And tbPaid.Text Like "*" & "." & "*" Then
    '        e.Handled = True
    '    End If
    'End Sub

    Private Sub SimpleButton7_Click(sender As System.Object, e As System.EventArgs) Handles btnSettings.ItemClick
        frmMain.Show()
        Me.Close()
    End Sub

    Private Sub SimpleButton6_Click(sender As System.Object, e As System.EventArgs) Handles btnEditInvoice.ItemClick

        If GlobalVariables.authority <> "Admin" AndAlso ExClass.CheckValidity = False Then
            Exit Sub
        End If

Restart:

        If Val(tbRest.Text) > 1 Or Val(tbRest.Text) < -1 Then
            MessageBox.Show("No entered payment!", "No Payment", MessageBoxButtons.OK, MessageBoxIcon.Information)
            pUSD.Focus()
            'ElseIf Val(tbRest1.Text) < 0 Then
            '    MessageBox.Show("Paid amount is invalid!", "Wrong Payment", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    tbPaid.Focus()
            '    tbPaid.SelectAll()
            'ElseIf oDiscountCode.Text = "0000" Or oDiscountCode.Text = "9999" Then
            '    MessageBox.Show("You cannot use this code!", "Invalid Code", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    oDiscountCode.Focus()
            '    oDiscountCode.SelectAll()
            'ElseIf Val(tbRest1.Text) <= 0 Then
            '    MessageBox.Show("You must enter valid payment!", "No Payment", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    tbPaid.Focus()
            '    tbPaid.SelectAll()

        Else


            'check if the valid qnty
            If CheckQnty() = False Then
                Exit Sub
            End If
            'Dim agencyDiscount As String = lbDiscount.Text.Replace("%", "")
            Dim DiscountRate As Single = Val(lbDiscount.Text.Replace("%", ""))
            'add to out1
            OutTotalize()

            ''''''save the log
            InvoiceLogs &= CStr(ExClass.RecordLog(6)) & ", "


            Dim Query As String = "UPDATE tblOut1 SET [User] = " & GlobalVariables.ID & ", Agent = (SELECT Code FROM tblAgency WHERE PinCode = '" & oDiscountCode.Text & "')," _
                                  & " CardCode = '" & oDiscountCode.Text & "', Total = " & Val(tbTotal.Text.Replace("$", "")) _
                                  & ", Discount = " & Val(tbDiscount.Text) & ", pUSD = " & Val(pUSD.Text) & ", pEGP = " & Val(pEGP.Text) & ", pRUB = " & Val(pRUB.Text) & ", pEUR = " & Val(pEUR.Text) & ", pUAH = " & Val(pUAH.Text) & ", pGBP = " & Val(pEGP.Text) & ", pVisa = " & Val(pVisa.Text) & "," _
                                  & " cUSD = " & Val(cUSD.Text) & ", cEGP = " & Val(cEGP.Text) & ", cRUB = " & Val(cRUB.Text) & ", cEUR = " & Val(cEUR.Text) & ", cUAH = " & Val(cUAH.Text) & ", cGBP = " & Val(cEGP.Text) & ", Rest = " & Val(tbRest.Text) & ", DiscountRate = " & DiscountRate _
                                  & " WHERE Serial = '" & oSearch.EditValue & "'"

            Using cmd = New SqlCommand(Query, myConn)
                If myConn.State = ConnectionState.Closed Then
                    myConn.Open()
                End If
                cmd.ExecuteNonQuery()
                myConn.Close()

            End Using


            'Add to Out2

            'remove first then add

            If myConn.State = ConnectionState.Closed Then
                myConn.Open()
            End If


            'remove
            Dim theQuery As String = "EXEC resetSold " & oSearch.EditValue & "; DELETE FROM tblOut2 WHERE Serial = '" & oSearch.EditValue & "'; "

            If Not oDgv.RowCount = 0 Then
                theQuery += "INSERT INTO tblOut2 (Serial, Kind, Item, Compound, Qnty, Price, Discount, UnitPrice, [User]) VALUES"

                For Each oRow As DataGridViewRow In oDgv.Rows
                    theQuery += "('" & oSerial.Text & "', '" & oRow.Cells(1).Value & "', '" & oRow.Cells(7).Value & "', '0', '" & oRow.Cells(0).Value & "', '" & oRow.Cells(6).Value & "', '" & oRow.Cells(5).Value & "', '" & oRow.Cells(4).Value & "', '" & GlobalVariables.ID & "'), "
                Next

                theQuery = theQuery.Substring(0, theQuery.Length - 2)
                theQuery += "; EXEC setSold;"

                If InvoiceLogs <> "" Then
                    InvoiceLogs = InvoiceLogs.Substring(0, InvoiceLogs.Length - 2)
                End If

                theQuery &= " UPDATE tblLog SET cInvoice = " & oSerial.Text & " WHERE cID IN (" & InvoiceLogs & ");"

            End If
            Using cmd = New SqlCommand(theQuery, myConn)
                cmd.ExecuteNonQuery()
            End Using


            myConn.Close()

            'clear
            ClearContents()

            Call Notification("Invoice Modified")

            If btnSaveInvoice.Text <> "Save" Then
                btnInvoicePrint.PerformClick()
            End If

        End If

    End Sub

    Private Sub SimpleButton8_Click(sender As System.Object, e As System.EventArgs) Handles btnExpired.ItemClick

        If Not GlobalVariables.authority = "Admin" AndAlso ExClass.CheckValidity = False Then
            Exit Sub
        End If

Restart:

        Dim dia As DialogResult = MessageBox.Show("Are you sure you want to save the invoice as expired items?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If dia = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If
        If oDgv.RowCount = 0 Then
            MessageBox.Show("No data entered to be saved!", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information)
            oItemSerial.Focus()
        ElseIf Not oDiscountCode.Text = "0000" And Not oDiscountCode.Text = "9999" Then
            MessageBox.Show("You must enter the code 0000 or 9999", "No Code", MessageBoxButtons.OK, MessageBoxIcon.Information)
            oDiscountCode.Focus()
            oDiscountCode.SelectAll()
        Else
            Dim oDate As String = Today.ToString("MM/dd/yyyy")
            Dim oTime As String = Now.ToString("HH:mm")

            'check if the valid qnty
            If CheckQnty() = False Then
                Exit Sub
            End If

            'make the money as zero value
            For x As Integer = 0 To oDgv.RowCount - 1
                oDgv.Rows(x).Cells(4).Value = 0
                oDgv.Rows(x).Cells(5).Value = 0
                oDgv.Rows(x).Cells(6).Value = 0
            Next
            Call OutTotalize()
            Call frmMain.AutoRate(Today)

            Dim Query As String = "INSERT INTO tblOut1 ([Date], [Time], [User], Agent, CardCode, Total, Discount, pUSD, pEGP, pRUB, pEUR, pUAH, pGBP, pVisa, cUSD, cEGP, cRUB, cEUR, cUAH, cGBP, Rest)" _
                                  & " VALUES ('" & oDate & "', '" & oTime & "', " & GlobalVariables.ID & ", (SELECT Code FROM tblAgency WHERE PinCode = '" & oDiscountCode.Text & "')," _
                                  & " '" & oDiscountCode.Text & "', " & tbTotal.Text.Replace("$", "") & ", 0, 0, 0, 0, 0, 0, 0, 0" _
                                  & ", 0, 0, 0, 0, 0, 0, 0); "




            Using cmd = New SqlCommand(Query, myConn)
                If myConn.State = ConnectionState.Closed Then
                    myConn.Open()
                End If
                cmd.ExecuteNonQuery()

                cmd.CommandText = "SELECT @@IDENTITY;"
                Using dt As SqlDataReader = cmd.ExecuteReader
                    If dt.Read() Then
                        oSerial.Text = dt(0).ToString
                    End If
                End Using
                myConn.Close()
            End Using


            If myConn.State = ConnectionState.Closed Then
                myConn.Open()
            End If
            Dim theQuery As String = "INSERT INTO tblOut2 (Serial, Kind, Item, Compound, Qnty, Price, Discount, UnitPrice, [User]) VALUES"

            For Each oRow As DataGridViewRow In oDgv.Rows
                theQuery += "('" & oSerial.Text & "', '" & oRow.Cells(1).Value & "', '" & oRow.Cells(7).Value & "', '0', '" & oRow.Cells(0).Value & "', '" & oRow.Cells(6).Value & "', '" & oRow.Cells(5).Value & "', '" & oRow.Cells(4).Value & "', '" & GlobalVariables.ID & "'), "
            Next

            theQuery = theQuery.Substring(0, theQuery.Length - 2)

            Using cmd = New SqlCommand(theQuery, myConn)
                cmd.ExecuteNonQuery()
            End Using
            myConn.Close()

            'clear
            ClearContents()

            Call Notification("Expiry Invoice Added")

            If btnSaveInvoice.Text <> "SAVE" Then
                btnInvoicePrint.PerformClick()
            End If

        End If


    End Sub


    Private Sub SimpleButton10_Click(sender As System.Object, e As System.EventArgs) Handles btnCalculator.ItemClick
        Shell("Calc", AppWinStyle.NormalFocus, True)
    End Sub

    Private Sub oDgv_LostFocus(sender As Object, e As System.EventArgs) Handles oDgv.LostFocus
        lblIndicateTotal.Visible = False
        oQnty.Text = "1"
    End Sub

    Private Sub oDgv_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles oDgv.RowsAdded
        oDgv.Rows(oDgv.RowCount - 1).Selected = True
    End Sub

    Private Sub oDgv_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles oDgv.RowsRemoved
        If Not oDgv.RowCount = 0 Then
            oDgv.Rows(oDgv.RowCount - 1).Selected = True
        End If
    End Sub

    Private Sub oDgv_SelectionChanged(sender As Object, e As System.EventArgs) Handles oDgv.SelectionChanged
        Dim Total As Decimal = 0.0
        For x As Integer = 0 To oDgv.RowCount - 1
            If oDgv.Rows(x).Selected = True Then
                Total += oDgv.Rows(x).Cells(6).Value
            End If
        Next
        If Total <> 0 And oDgv.Focused = True Then
            lblIndicateTotal.Visible = True
            lblIndicateTotal.Text = Total
        Else
            lblIndicateTotal.Visible = False
        End If
    End Sub

    Private Sub btnCost_Click(sender As Object, e As EventArgs) Handles btnCost.ItemClick
        If oItemSerial.Text <> "" Then
            frmCheckItemCost.TextEdit1.Text = oItemSerial.Text
            frmCheckItemCost.CheckItem(frmCheckItemCost.TextEdit1.Text)
        End If

        frmCheckItemCost.TextEdit1.Focus()
        frmCheckItemCost.TextEdit1.SelectAll()
        frmCheckItemCost.ShowDialog()
        oItemSerial.Focus()
        oItemSerial.SelectAll()
    End Sub

    Private Sub btnReturn_Click(sender As Object, e As EventArgs) Handles btnReturn.ItemClick
        For x As Integer = 0 To oDgv.RowCount - 1
            If oDgv.Rows(x).Cells(0).Value > 0 Then
                oDgv.Rows(x).Cells(0).Value = "-" & oDgv.Rows(x).Cells(0).Value
                oDgv.Rows(x).Cells(6).Value = (oDgv.Rows(0).Cells(0).Value * oDgv.Rows(x).Cells(4).Value) - oDgv.Rows(x).Cells(5).Value
            End If

        Next
        OutTotalize()
        oItemSerial.Focus()
        oItemSerial.SelectAll()
    End Sub

    Private Sub lbDiscount_TextChanged(sender As Object, e As EventArgs) Handles lbDiscount.TextChanged
        If lbDiscount.Text = "0%" Then
            lbDiscount.Visible = False
        Else
            lbDiscount.Visible = True
        End If
    End Sub

    Private Sub btnExchange_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnExchange.ItemClick
        frmCash.Text = "EXCHANGE"

        frmCash.ShowDialog()
        oItemSerial.Focus()
        oItemSerial.SelectAll()
    End Sub

    Private Sub oDiscountCode_TextChanged(sender As Object, e As EventArgs) Handles oDiscountCode.TextChanged
        If oDiscountCode.Text = "" Then
            lbDiscount.Text = "0%"
            lblAgent.Caption = ""
            lblAgent.Visibility = BarItemVisibility.Never
            Application.DoEvents()
            ApplyDiscount(0)
        End If
    End Sub

    Private Sub oDiscountCode_LostFocus(sender As Object, e As EventArgs) Handles oDiscountCode.LostFocus
        checkAgent(True)
    End Sub

    Private Sub cbSuspended_GotFocus(sender As Object, e As EventArgs) Handles cbSuspended.GotFocus
        fillSuspended()
    End Sub

    Private Sub cbSuspended_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbSuspended.SelectedIndexChanged

        If cbSuspended.SelectedValue Is Nothing Or cbSuspended.Text Is Nothing Then
            recallMemory(0)
        Else
            Try
                Dim prKey As String = cbSuspended.SelectedValue


                Dim Query As String = "SELECT * FROM tblSuspend WHERE PrKey = '" & prKey & "';"
                Dim str As String = ""
                Using cmd = New SqlCommand(Query, myConn)
                    If myConn.State = ConnectionState.Closed Then
                        myConn.Open()
                    End If
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read() Then
                            str = dr(1)
                        Else
                            str = ""
                        End If
                    End Using
                    myConn.Close()
                End Using

                If str = "" Or str = ";$" Then
                    Return
                End If

                Dim memory() As String = str.Split("$")
                Dim record() As String
                oDgv.Rows.Clear()
                For x As Integer = 0 To memory.Count - 1
                    record = memory(x).Split(";")
                    If x = 0 Then
                        oDiscountCode.Text = record(0)
                        lbDiscount.Text = record(1)
                        ' tbPaid.Text = record(2)
                    ElseIf memory(x) <> "" And x > 0 Then
                        oDgv.Rows.Add(record(0), record(1), record(2), record(3), record(4), record(5), record(6), record(7))
                    End If
                Next
                Call OutTotalize()

            Catch ex As Exception
                recallMemory(0)
            End Try

        End If


    End Sub

    Private Sub cbSuspended_TextChanged(sender As Object, e As EventArgs) Handles cbSuspended.TextChanged
        If cbSuspended.Text = "" Then
            ClearContents()
        End If
    End Sub

    Private Sub btnSuspend_Click(sender As Object, e As EventArgs) Handles btnSuspend.Click
        If cbSuspended.Text = "" Then
            Exit Sub
        End If
        Dim diaR As DialogResult = MessageBox.Show("Are you sure you want to delete this suspended invoice?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If diaR = Windows.Forms.DialogResult.Yes Then

            Try
                Dim Query As String = "DELETE FROM tblSuspend WHERE PrKey = " & cbSuspended.SelectedValue & ";"
                Using cmd = New SqlCommand(Query, myConn)
                    If myConn.State = ConnectionState.Closed Then
                        myConn.Open()
                    End If
                    cmd.ExecuteNonQuery()
                    myConn.Close()
                    fillSuspended()
                End Using
            Catch ex As Exception
                MsgBox("Failed!")
            End Try



        End If
    End Sub

    Private Sub pUSD_GotFocus(sender As Object, e As EventArgs) Handles pUSD.GotFocus
        pUSD.SelectAll()
    End Sub

    Private Sub pEGP_GotFocus(sender As Object, e As EventArgs) Handles pEGP.GotFocus
        pEGP.SelectAll()
    End Sub

    Private Sub pRUB_GotFocus(sender As Object, e As EventArgs) Handles pRUB.GotFocus
        pRUB.SelectAll()
    End Sub

    Private Sub pEUR_GotFocus(sender As Object, e As EventArgs) Handles pEUR.GotFocus
        pEUR.SelectAll()
    End Sub

    Private Sub pUAH_GotFocus(sender As Object, e As EventArgs) Handles pUAH.GotFocus
        pUAH.SelectAll()
    End Sub

    Private Sub pGBP_GotFocus(sender As Object, e As EventArgs) Handles pGBP.GotFocus
        pGBP.SelectAll()
    End Sub

    Private Sub pVisa_GotFocus(sender As Object, e As EventArgs) Handles pVisa.GotFocus
        pVisa.SelectAll()
    End Sub

    Private Sub cUSD_GotFocus(sender As Object, e As EventArgs) Handles cUSD.GotFocus
        cUSD.SelectAll()
    End Sub

    Private Sub cEGP_GotFocus(sender As Object, e As EventArgs) Handles cEGP.GotFocus
        cEGP.SelectAll()
    End Sub

    Private Sub cRUB_GotFocus(sender As Object, e As EventArgs) Handles cRUB.GotFocus
        cRUB.SelectAll()
    End Sub

    Private Sub cEUR_GotFocus(sender As Object, e As EventArgs) Handles cEUR.GotFocus
        cEUR.SelectAll()
    End Sub

    Private Sub cUAH_GotFocus(sender As Object, e As EventArgs) Handles cUAH.GotFocus
        cUAH.SelectAll()
    End Sub

    Private Sub cGBP_GotFocus(sender As Object, e As EventArgs) Handles cGBP.GotFocus
        cGBP.SelectAll()
    End Sub

    Private Sub oSearch_ItemClick(sender As Object, e As ItemClickEventArgs)
        If Not oSearch.EditValue = "" Then
            InvoiceRecall(oSearch.EditValue)
        Else
            ClearContents()
        End If
    End Sub

    Private Sub cGBP_KeyDown(sender As Object, e As KeyEventArgs) Handles cGBP.KeyDown
        If e.KeyCode = Keys.Enter Then
            oItemSerial.Focus()
            oItemSerial.SelectAll()
        End If
    End Sub

    Private Sub pUSD_TextChanged(sender As Object, e As EventArgs) Handles pUSD.TextChanged
        Change()
    End Sub

    Private Sub pEGP_TextChanged(sender As Object, e As EventArgs) Handles pEGP.TextChanged
        Change()
    End Sub

    Private Sub pRUB_TextChanged(sender As Object, e As EventArgs) Handles pRUB.TextChanged
        Change()
    End Sub

    Private Sub pEUR_TextChanged(sender As Object, e As EventArgs) Handles pEUR.TextChanged
        Change()
    End Sub

    Private Sub pUAH_TextChanged(sender As Object, e As EventArgs) Handles pUAH.TextChanged
        Change()
    End Sub

    Private Sub pGBP_TextChanged(sender As Object, e As EventArgs) Handles pGBP.TextChanged
        Change()
    End Sub

    Private Sub pVisa_TextChanged(sender As Object, e As EventArgs) Handles pVisa.TextChanged
        Change()
    End Sub

    Private Sub cUSD_TextChanged(sender As Object, e As EventArgs) Handles cUSD.TextChanged
        Change()
    End Sub

    Private Sub cEGP_TextChanged(sender As Object, e As EventArgs) Handles cEGP.TextChanged
        Change()
    End Sub

    Private Sub cRUB_TextChanged(sender As Object, e As EventArgs) Handles cRUB.TextChanged
        Change()
    End Sub

    Private Sub cEUR_TextChanged(sender As Object, e As EventArgs) Handles cEUR.TextChanged
        Change()
    End Sub

    Private Sub cUAH_TextChanged(sender As Object, e As EventArgs) Handles cUAH.TextChanged
        Change()
    End Sub

    Private Sub cGBP_TextChanged(sender As Object, e As EventArgs) Handles cGBP.TextChanged
        Change()
    End Sub

    Private Sub tbTotal_TextChanged(sender As Object, e As EventArgs) Handles tbTotal.TextChanged
        Change()
    End Sub

    Private Sub btnDiscount_Click(sender As Object, e As EventArgs) Handles btnDiscount.Click
        If GlobalVariables.authority = "Admin" Then
            frmAddDiscount.ShowDialog()
        ElseIf ExClass.CheckValidity Then
            frmAddDiscount.ShowDialog()
        End If
    End Sub

End Class
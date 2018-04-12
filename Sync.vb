Imports System.Data.SqlClient
Public Class Sync
    Shared SConn As New SqlConnection("workstation id=MasterPro.mssql.somee.com;packet size=4096;user id=walid_SQLLogin_1;pwd=mxy3rvwula;data source=MasterPro.mssql.somee.com;persist security info=False;initial catalog=MasterPro")
    Shared SendCmd As String

    Shared Sub Sync()
        'If Not My.Settings.OnlineCmd = "" Then
        '    Try
        '        SConn.Open()

        '        Dim Query As String = "USE MasterPro; INSERT INTO tblSelling ([User], [Date], [Time], Invoice, Qnty, Item, Price, [Value], Cashier) VALUES " & My.Settings.OnlineCmd & "###@"
        '        Query = Query.Replace("'), ###@", "')")

        '        Using cmd = New SqlCommand(Query, SConn)
        '            cmd.ExecuteNonQuery()
        '        End Using
        '        My.Settings.OnlineCmd = ""
        '        My.Settings.Save()
        '        SConn.Close()
        '    Catch ex As Exception
        '        If SConn.State = ConnectionState.Open Then
        '            SConn.Close()
        '        End If
        '        frmCashier.CheckEdit2.Checked = False
        '    End Try
        'End If
    End Sub
   
    'Shared Function SellingCode() As String
    '    'Dim User As Integer = 1
    '    'Dim dte, tme As Date
    '    'Dim qnty, price, valu As Decimal
    '    'Dim itm, cashier, Inv As String
    '    'dte = Today
    '    'tme = Now
    '    'cashier = GlobalVariables.user
    '    'Inv = frmCashier.OSerial.Text
    '    'SendCmd = ""
    '    ''SendCmd = "USER MasterPro; INSERT INTO tblSelling ([User], [Date], [Time], Invoice, Qnty, Item, Price, [Value], Cashier) VALUES "
    '    'For x As Integer = 0 To frmCashier.oDgv.RowCount - 1
    '    '    qnty = frmCashier.oDgv.Rows(x).Cells(0).Value
    '    '    itm = frmCashier.oDgv.Rows(x).Cells(3).Value
    '    '    price = frmCashier.oDgv.Rows(x).Cells(4).Value
    '    '    valu = frmCashier.oDgv.Rows(x).Cells(5).Value

    '    '    SendCmd += "(" & User & ", '" & dte.ToString("MM/dd/yyyy") & "', '" & tme.ToString("HH:mm") & "', '" & Inv & "', " & qnty & ", '" & itm & "', " & price & ", " & valu & ", '" & cashier & "'), "
    '    'Next
    '    'My.Settings.OnlineCmd += SendCmd
    '    'My.Settings.Save()
    '    'Return SendCmd

    'End Function
End Class

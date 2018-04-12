Imports System.IO.Ports
Imports System.Security.Cryptography
Imports System.Text
Imports System.Data.SqlClient
Imports DevExpress.XtraReports.UI
Public Class ExClass
    Public Shared myConn As New SqlConnection(GV.myConn)
    Public Shared Sub PoleDisplay(ByVal Text As String)
        Dim sp As New SerialPort("COM1", 9600, Parity.Even)
        If sp.IsOpen = False Then
            sp.Open()
        End If
        'to clear the previous display
        sp.Write("")

        'first line
        sp.WriteLine(Text)
        sp.Close()
        sp.Dispose()
        sp = Nothing

    End Sub

    Public Shared Function GenerateHash(ByVal SourceText As String, Optional Type As Integer = 1) As String
        'Create an encoding object to ensure the encoding standard for the source text
        Dim Ue As New UnicodeEncoding()
        'Retrieve a byte array based on the source text
        Dim ByteSourceText() As Byte = Ue.GetBytes(SourceText)
        'Instantiate an MD5 Provider object
        Dim Md5 As New MD5CryptoServiceProvider()
        Dim SHA1 As New SHA1CryptoServiceProvider()

        'Compute the hash value from the source
        Dim ByteHash() As Byte
        If Type = 1 Then
            ByteHash = Md5.ComputeHash(ByteSourceText)
        Else
            ByteHash = SHA1.ComputeHash(ByteSourceText)
        End If
        'And convert it to String format for return
        Return Convert.ToBase64String(ByteHash)
    End Function

    Public Shared Sub Invoice(ByVal Serial As String, ByVal Print As Boolean)
        If Not Serial = "" Then


            Dim Que As String = "SELECT tblOut1.Serial, tblOut1.[Date], tblOut1.[Time], tblOut2.Qnty," _
                                & " (CASE WHEN tblOut2.Kind = 'PKG' THEN tblItems.Name + ' **' ELSE tblItems.Name END) AS [Description]," _
                                & " tblOut2.UnitPrice, (tblOut2.Qnty * tblOut2.UnitPrice) AS [Value], tblOut2.Discount, tblOut2.Price AS DueAmount, tblOut1.Total AS Total" _
                                & " , tblOut1.pUSD, tblOut1.pEGP, tblOut1.pEUR, tblOut1.pRUB, tblOut1.pGBP, tblOut1.pUAH, tblOut1.pVisa" _
                                & " , tblOut1.cUSD, tblOut1.cEGP, tblOut1.cEUR, tblOut1.cRUB, tblOut1.cGBP, tblOut1.cUAH" _
                                & " FROM tblOut1 LEFT OUTER JOIN tblOut2 ON tblOut1.Serial = tblOut2.Serial" _
                                & " INNER JOIN tblItems ON tblOut2.Item = tblItems.PrKey" _
                                & " WHERE tblOut1.Serial = " & Serial & ";"
            If myConn.State = ConnectionState.Closed Then
                myConn.Open()
            End If


            Dim ds As New ReportsDS
            Dim da As New SqlDataAdapter(Que, myConn)
            da.Fill(ds.Tables("tblReceipt"))
            myConn.Close()
            Dim Report As New XtraReceipt

            Dim ttl As Decimal = ds.Tables("tblReceipt").Rows(0)(9)
            
            Report.DataSource = ds
            Report.DataAdapter = da
            Report.DataMember = "tblReceipt"
            Report.XrTableCell4.Text = "Amount:"

            Dim tool As ReportPrintTool = New ReportPrintTool(Report)
            Report.CreateDocument()
            If Print Then
                Report.Print()
            Else
                Report.ShowPreview()
            End If

        End If
    End Sub

    Public Shared Sub Backup(ByVal Path As String)

        Dim Query As String = "BACKUP DATABASE MasterPro " _
                              & " TO DISK = '" & Path & "'" _
                              & "    WITH FORMAT," _
                              & "       MEDIANAME = 'MasterPro'," _
                              & "       NAME = 'Full Backup of MasterPro';"
        Using cmd = New SqlCommand(Query, frmMain.myConn)
            If frmMain.myConn.State = ConnectionState.Closed Then
                frmMain.myConn.Open()
            End If
            Try
                cmd.ExecuteNonQuery()
                MsgBox("Backup done successfully!")
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            frmMain.myConn.Close()
        End Using
    End Sub

    Public Shared Function CheckValidity() As Boolean
        Dim res As Boolean = False
        frmValidate.ShowDialog()
        If frmValidate.DialogResult = DialogResult.OK Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Shared Function RecordLog(ByVal Type As Integer, Optional ByVal Data1 As String = "", Optional ByVal Data2 As String = "") As Int64
        Dim Query As String = "INSERT INTO tblLog (cDate, cTime, cUser, cType, cDetails, cInvoice) VALUES ('" & Today.ToString("MM/dd/yyyy") & "', '" & Now.ToString("HH:mm") & "', @cUser, @cType, @cDetails, @cInvoice); SELECT @@IDENTITY;"
        Dim theType As String = ""
        Dim theDetails As String = ""
        Dim theInvoice As String = ""

        Select Case Type
            Case 1
                theType = "Login"
                theDetails = "Login for user: " & GlobalVariables.user & "."
                theInvoice = ""
            Case 2
                theType = "Item Removed"
                theDetails = "Qnty:(" & CashierNew.oDgv.CurrentRow.Cells(0).Value & ") Code: (" & CashierNew.oDgv.CurrentRow.Cells(2).Value & "), Name: (" & CashierNew.oDgv.CurrentRow.Cells(3).Value & "), Price: (" _
                    & CashierNew.oDgv.CurrentRow.Cells(4).Value & ")."
            Case 3
                theType = "Invoice Cleared"
                For x As Integer = 0 To CashierNew.oDgv.RowCount - 1
                    theDetails &= "Qnty: (" & CashierNew.oDgv.Rows(x).Cells(0).Value & ") Code: (" & CashierNew.oDgv.Rows(x).Cells(2).Value _
                    & "), Name: (" & CashierNew.oDgv.Rows(x).Cells(3).Value & "), Price: (" _
                    & CashierNew.oDgv.Rows(x).Cells(4).Value & ")." & vbCrLf
                Next
                theDetails &= "Total: " & CashierNew.tbTotal.Text & ""
            Case 4
                theType = "Discount"
                theDetails = frmAddDiscount.txtDiscount.Text & "$ discount added"
            Case 5
                theType = "Qnty Changed"
                theDetails = "Qnty:(" & CashierNew.oDgv.CurrentRow.Cells(0).Value & ") Code: (" & CashierNew.oDgv.CurrentRow.Cells(2).Value & "), Name: (" & CashierNew.oDgv.CurrentRow.Cells(3).Value & "), Price: (" _
                    & CashierNew.oDgv.CurrentRow.Cells(4).Value & ")."

            Case 6
                theType = "Invoice Modified"
                For x As Integer = 0 To CashierNew.oDgv.RowCount - 1
                    theDetails &= "Qnty: (" & CashierNew.oDgv.Rows(x).Cells(0).Value & ") Code: (" & CashierNew.oDgv.Rows(x).Cells(2).Value _
                    & "), Name: (" & CashierNew.oDgv.Rows(x).Cells(3).Value & "), Price: (" _
                    & CashierNew.oDgv.Rows(x).Cells(4).Value & ")." & vbCrLf
                Next
                theDetails &= "Total: " & CashierNew.tbTotal.Text & ""
        End Select


        Dim theIdentity As Int64 = 0

        Using cmd = New SqlCommand(Query, myConn)
            cmd.Parameters.AddWithValue("@cUser", GlobalVariables.ID)
            cmd.Parameters.AddWithValue("@cType", theType)
            cmd.Parameters.AddWithValue("@cDetails", theDetails)
            If theInvoice = "" Then
                Dim param As New SqlParameter("@cInvoice", SqlDbType.BigInt)
                param.Value = DBNull.Value
                cmd.Parameters.Add(param)
            Else
                cmd.Parameters.AddWithValue("@cInvoice", theInvoice)
            End If
            If myConn.State = ConnectionState.Closed Then
                myConn.Open()
            End If
            If Not GlobalVariables.authority = "Developer" Then
                theIdentity = cmd.ExecuteScalar
            End If

            myConn.Close()
        End Using

        Return theIdentity
    End Function

    
End Class

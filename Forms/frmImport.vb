Imports System.Data.SqlClient
Public Class frmImport
   Public Shared myConn As New SqlConnection(GV.myConn)
    Private Sub KryptonButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KryptonButton3.Click
        KryptonTextBox1.Text = My.Computer.Clipboard.GetText.ToUpper
        KryptonListBox1.Items.Clear()
        For Each line In KryptonTextBox1.Lines
            If line <> "" Then
                KryptonListBox1.Items.Add(line.ToUpper.Replace(vbTab, ";"))
            End If
        Next
     
    End Sub

    Private Sub KryptonButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KryptonButton2.Click
        Dim vr As String
        myConn.Open()
        For x As Integer = 0 To KryptonListBox1.Items.Count - 1
            KryptonListBox1.SelectedIndex = x
            vr = KryptonListBox1.SelectedItem
            vr = vr.Substring(vr.LastIndexOf(";") + 1)

            Dim Query As String = "SELECT Name FROM tblVendors WHERE Name = N'" & vr & "'"
            Dim Insr As String = "INSERT INTO tblVendors (Name) VALUES (N'" & vr & "')"
            Using cmd = New SqlCommand(Query, myConn)
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If Not dr.Read() Then
                        Using cmd2 = New SqlCommand(Insr, myConn)
                            cmd2.ExecuteNonQuery()
                        End Using
                    End If
                End Using
            End Using

        Next
        myConn.Close()
    End Sub

    Private Sub KryptonButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KryptonButton1.Click
        myConn.Open()
        Dim sr, name As String
        Dim pr As Decimal
        Dim line As String
        Dim temp As String
        For x As Integer = 0 To KryptonListBox1.Items.Count - 1


            KryptonListBox1.SelectedIndex = x
            line = KryptonListBox1.SelectedItem

            sr = line.Substring(0, line.IndexOf(";"))

            line = line.Substring(line.IndexOf(";") + 1)
            name = line.Substring(0, line.IndexOf(";"))
            name = name.Substring(name.IndexOf(",") + 1)

            line = line.Substring(line.IndexOf(";") + 1)
            temp = line.Substring(line.IndexOf(";") + 2)
            temp = temp.Substring(temp.IndexOf(",") + 1)
            'pr = temp.Substring(1)

            Using cmd = New SqlCommand("INSERT INTO tblItems (SErial, Name, Price, [Minimum]) VALUES ('" & sr & "', '" & name & "', '" & pr & "', 0)", myConn)
                Try
                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox("Er")
                End Try
            End Using
            '            name = line.Substring(0, line.IndexOf(";"))
            '            name = LTrim(RTrim(name))
            'recheck:
            '            If name Like "*" & "  " & "*" Then
            '                name = name.Replace("  ", " ")
            '                GoTo recheck
            '            End If
            '            name = name.Replace(":", ";")
            '            line = line.Substring(line.IndexOf(";") + 1)
            '            pr = line.Substring(0, line.IndexOf(";"))

            '            line = line.Substring(line.IndexOf(";") + 1)
            '            line = line.Substring(line.IndexOf(";") + 1)

            '            Using cmd1 = New SqlCommand("SELECT Sr FROM tblVendors WHERE Name = '" & line & "'", myConn)
            '                Using dr As SqlDataReader = cmd1.ExecuteReader
            '                    If dr.Read() Then
            '                        vr = dr(0)
            '                    Else
            '                        MsgBox("Error")
            '                    End If
            '                End Using
            '            End Using

            '            'MsgBox(sr)
            '            'Using cmd0 = New SqlCommand("select * from tblItems where Serial = '" & sr & "'", myConn)
            '            '    Using dr As SqlDataReader = cmd0.ExecuteReader
            '            '        If dr.Read() Then
            '            '            KryptonListBox2.Items.Add(name)
            '            '        Else
            '            Query = "insert into tblItems (Vendor, Serial, Name, Price) Values ('" & vr & "', '" & sr & "', '" & name & "', '" & pr & "')"
            '            Using cmd2 = New SqlCommand(Query, myConn)
            '                cmd2.ExecuteNonQuery()
            '            End Using
            '            '        End If
            '            '    End Using
            '            'End Using


        Next

        myConn.Close()
    End Sub

    Private Sub KryptonButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KryptonButton4.Click
        myConn.Open()
        Dim vr, ser As Integer
        Dim sr, itm As String
        Dim pr, qnty As Decimal
        Dim line As String
        Dim Query As String
        For x As Integer = 0 To KryptonListBox1.Items.Count - 1
            KryptonListBox1.SelectedIndex = x
            line = KryptonListBox1.SelectedItem
            sr = line.Substring(0, line.IndexOf(";"))

            line = line.Substring(line.IndexOf(";") + 1)
            name = line.Substring(0, line.IndexOf(";"))
            name = LTrim(RTrim(name))
recheck:
            If name Like "*" & "  " & "*" Then
                name = name.Replace("  ", " ")
                GoTo recheck
            End If
            name = name.Replace(":", ";")
            line = line.Substring(line.IndexOf(";") + 1)
            pr = line.Substring(0, line.IndexOf(";"))

            line = line.Substring(line.IndexOf(";") + 1)
            qnty = line.Substring(0, line.IndexOf(";"))
            line = line.Substring(line.IndexOf(";") + 1)

            Using cmd1 = New SqlCommand("SELECT Sr FROM tblVendors WHERE Name = N'" & line & "'", myConn)
                Using dr As SqlDataReader = cmd1.ExecuteReader
                    If dr.Read() Then
                        vr = dr(0)
                    Else
                        MsgBox("Error")
                    End If
                End Using
            End Using
            itm = ""
            Using cmd2 = New SqlCommand("SELECT PrKey FROM tblItems WHERE Serial = '" & sr & "' AND Name = N'" & Name & "'", myConn)
                Using dr As SqlDataReader = cmd2.ExecuteReader
                    If dr.Read() Then
                        itm = dr(0)
                    Else
                        MsgBox("Error-1")
                    End If
                End Using
            End Using

            Using cmd3 = New SqlCommand("SELECT COUNT(Vendor) AS Serial FROM tblIn WHERE Vendor = '" & vr & "'", myConn)
                Using dr As SqlDataReader = cmd3.ExecuteReader
                    If dr.Read() Then
                        ser = dr(0)
                    Else
                        MsgBox("Error-2")
                    End If
                End Using
            End Using

            Query = "INSERT INTO tblIn (Vendor, Serial, [Date], [Time], Sr, Item, Qnty, PriceEUR, [Value], [Disc%], [User])" _
                & " VALUES ('" & vr & "', 'PREVIOUS01', '10/19/2015', '10:00', '" & ser + 1 & "', '" & itm & "', '" & qnty & "', '" & pr & "', '" & qnty * pr & "', 0, 1)"
            'My.Computer.Clipboard.SetText(Query)
            Using cmd4 = New SqlCommand(Query, myConn)
                cmd4.ExecuteNonQuery()
            End Using

        Next

        myConn.Close()
    End Sub

    Private Sub KryptonTextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KryptonTextBox2.TextChanged
        If KryptonTextBox2.Text = "HELLO IT'S ME WALID!!!" Then
            KryptonButton1.Enabled = True
            KryptonButton2.Enabled = True
            KryptonButton4.Enabled = True
        Else
            KryptonButton1.Enabled = False
            KryptonButton2.Enabled = False
            KryptonButton4.Enabled = False
        End If
    End Sub

    Private Sub frmImport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        KryptonTextBox2.Text = ""
        KryptonTextBox2.Focus()
    End Sub
End Class

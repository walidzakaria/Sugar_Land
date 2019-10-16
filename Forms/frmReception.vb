Imports System.Data.SqlClient
Public Class frmReception
    Dim myConn As New SqlConnection(GV.myConn)
    Private Sub fillData(ByVal dayDate As Date)
        Dim Query As String = "SELECT tblRegistery.PrKey, CONVERT(NVARCHAR(5), tblRegistery.[Time], 8) AS [Time], tblAgency.Company, tblAgency.Agent, tblRegistery.ADT, tblRegistery.CHD, tblRegistery.INF, tblLogin.UserName AS [User], Driver" _
                              & " FROM tblRegistery INNER JOIN tblAgency ON tblRegistery.Agent = tblAgency.Code" _
                              & " INNER JOIN tblLogin ON tblRegistery.[User] = tblLogin.Sr" _
                              & " WHERE tblRegistery.[Date] = '" & dayDate.ToString("MM/dd/yyyy") & "';"

        Dim da As New SqlDataAdapter(Query, myConn)
        Dim dt As New DataTable

        If myConn.State = ConnectionState.Closed Then
            myConn.Open()
        End If
        da.Fill(dt)
        myConn.Close()
        GridControl1.DataSource = dt
        GridView2.BestFitColumns()
        GridView2.MoveLast()
    End Sub

    Private Sub getAgent()
        Dim Query As String = "SELECT Company, Agent" _
                            & " FROM tblAgency" _
                            & " WHERE PinCode = '" & txtCode.Text & "';"

        Using cmd = New SqlCommand(Query, myConn)
            If myConn.State = ConnectionState.Closed Then
                myConn.Open()
            End If
            Using dr As SqlDataReader = cmd.ExecuteReader
                If dr.Read() Then
                    lblName.Text = dr(1)
                    lblCompany.Text = dr(0)
                Else
                    lblName.Text = ""
                    lblCompany.Text = ""
                End If
            End Using
            myConn.Close()
        End Using
    End Sub

    Private Sub Clear()
        txtCode.Text = ""
        txtADT.Text = ""
        txtCHD.Text = ""
        txtINF.Text = ""
        txtCode.Focus()
    End Sub
    Private Sub frmReception_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If GlobalVariables.authority = "Admin" Or GlobalVariables.authority = "Developer" Then
            dtDate.Visible = True
            'btnRemove.Visible = True
            LabelControl1.Visible = True
        Else
            dtDate.Visible = True
            'btnRemove.Visible = True
            LabelControl1.Visible = True
        End If
        fillData(Today)
        lblName.Text = ""
        lblCompany.Text = ""

    End Sub

    Private Sub txtCode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            getAgent()
            If lblName.Text = "" Then
                txtCode.Focus()
                txtCode.SelectAll()
            Else
                txtADT.Focus()
            End If
        End If
    End Sub
    Private Sub txtCode_TextChanged(sender As Object, e As EventArgs) Handles txtCode.TextChanged
        If txtCode.Text = "" Then
            lblName.Text = ""
            lblCompany.Text = ""
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If txtCode.Text = "" Then
            MsgBox("You must fill in the code!")
            txtCode.Focus()
        ElseIf txtADT.Text = "" Then
            MsgBox("You must fill in the ADT number!")
            txtADT.Focus()
        ElseIf txtCHD.Text = "" Then
            MsgBox("You must fill in the CHD number!")
            txtCHD.Focus()
        ElseIf txtINF.Text = "" Then
            MsgBox("You must fill in the INF number!")
            txtINF.Focus()
        ElseIf txtDriver.Text = "" Then
            MsgBox("You must fill in the driver fees!")
            txtDriver.Focus()
        Else
            getAgent()
            If lblName.Text = "" Then
                MsgBox("The entered code is not valid!")
                txtCode.Focus()
                txtCode.SelectAll()
                Exit Sub
            End If

            Dim Query As String = "INSERT INTO tblRegistery ([Date], [Time], Agent, ADT, CHD, INF, [User], Driver)" _
                                  & " VALUES ('" & Today.ToString("MM/dd/yyyy") & "', '" & Now.ToString("HH:mm") & "'," _
                                  & " (SELECT Code FROM tblAgency WHERE PinCode = '" & txtCode.Text & "'), " & Val(txtADT.Text) & ", " _
                                  & Val(txtCHD.Text) & ", " & Val(txtINF.Text) & ", " & GlobalVariables.ID & ", " & Val(txtDriver.Text) & ");"
            Using cmd = New SqlCommand(Query, myConn)
                If myConn.State = ConnectionState.Closed Then
                    myConn.Open()
                End If
                cmd.ExecuteNonQuery()
                myConn.Close()
            End Using
            Clear()
            fillData(Today)
        End If


    End Sub

    Private Sub dtDate_ValueChanged(sender As Object, e As EventArgs) Handles dtDate.ValueChanged
        fillData(dtDate.Value)
    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        Dim diaR As DialogResult = MessageBox.Show("Are you sure you want to delete this row?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If diaR = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If
        If GridView2.SelectedRowsCount = 0 Then
            MsgBox("You should select the row that you need to delete!")
            Exit Sub
        End If

        Dim code As String = GridView2.GetFocusedRowCellValue("PrKey")

 
        Dim query As String = "DELETE FROM tblRegistery WHERE PrKey = " & code & ";"
            Using cmd = New SqlCommand(query, myConn)
                If myConn.State = ConnectionState.Closed Then
                    myConn.Open()
                End If
                Try
                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                MsgBox("Failed to delete!")
                End Try
                myConn.Close()
            End Using
        fillData(Today)


    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Cursor = Cursors.WaitCursor
        GridView2.ShowPrintPreview()
        Cursor = Cursors.Default
    End Sub
End Class
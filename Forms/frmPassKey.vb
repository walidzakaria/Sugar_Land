Imports System.Data.SqlClient
Imports DevExpress.XtraReports.UI
Public Class frmPassKey
    Public Shared myConn As New SqlConnection(GV.myConn)
    Private Sub frmPassKey_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Opacity = 100%
        txtOldPassword.Text = ""
        txtNewPassword.Text = ""
        txtRetype.Text = ""
    End Sub

    Private Sub frmPassKey_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        txtOldPassword.Focus()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Dim pk As String = txtOldPassword.Text
        Dim Query As String = "SELECT * FROM tblLogger WHERE PassKey = N'" & pk & "';"
        If myConn.State = ConnectionState.Closed Then
            myConn.Open()
        End If
        Using cmd = New SqlCommand(Query, myConn)
            Using dr As SqlDataReader = cmd.ExecuteReader
                If Not dr.Read() Then
                    MessageBox.Show("The pass key you entered is invalid!", "Wrong Pass Key", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtOldPassword.Focus()
                    txtOldPassword.SelectAll()
                    myConn.Close()
                    Exit Sub
                End If
            End Using
        End Using

        If txtNewPassword.Text <> txtRetype.Text Then
            MessageBox.Show("The entered pass keys are different!", "Wrong Pass Keys", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtRetype.Text = ""
            txtNewPassword.Focus()
            txtNewPassword.SelectAll()
        Else
            pk = txtNewPassword.Text
            Query = "UPDATE tblLogger SET PassKey = N'" & pk & "';"
            Using cmd = New SqlCommand(Query, myConn)
                cmd.ExecuteNonQuery()
            End Using
            MsgBox("Pass key updated successfully!")
            PrintCode(pk)
            Me.Close()
        End If

        myConn.Close()
    End Sub

    Private Sub PrintCode(ByVal Code As String)
        Cursor = Cursors.WaitCursor
        Dim Query As String
        Query = "SELECT '" & Code & "' AS PrKey;"

        Dim ds As New ReportsDS
        Dim da As New SqlDataAdapter(Query, myConn)
        da.Fill(ds.Tables("tblBarcode"))

        Dim rep As New XtraPassKey
        rep.DataSource = ds
        rep.DataAdapter = da
        rep.DataMember = "tblBarcode"
        Dim tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(rep)
        rep.CreateDocument()
        Cursor = Cursors.Default
        rep.ShowPreview()

    End Sub
End Class
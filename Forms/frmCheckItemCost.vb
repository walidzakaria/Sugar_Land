Imports System.Data.SqlClient
Public Class frmCheckItemCost

    Private Sub frmCheckCost_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        TextEdit1.Focus()

    End Sub

    Private Sub frmCheckCost_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        CashierNew.oItemSerial.Focus()
        CashierNew.oItemSerial.SelectAll()
    End Sub

    Private Sub frmCheckCost_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub frmCheckCost_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Opacity = 100%
        TextEdit1.Focus()
        TextEdit1.SelectAll()
    End Sub

    Private Sub TextEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles TextEdit1.EditValueChanged
        If TextEdit1.Text = "" Then
            LabelControl2.Text = "Item Name"
            LabelControl3.Text = "0.00"
        End If
    End Sub

    Private Sub TextEdit1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextEdit1.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter And TextEdit1.Text <> "" Then
            Call CheckItem(TextEdit1.Text)
        End If
    End Sub

    Public Sub CheckItem(ByVal Serial As String)
        Dim Query As String = "SELECT TOP(1) tblItems.Name, CONVERT(DECIMAL(19,2), tblIn2.UnitPrice) AS UnitPrice" _
                              & " FROM tblIn2 INNER JOIN tblItems ON tblIn2.Item = tblItems.PrKey" _
                              & " WHERE tblItems.Serial = '" & Serial & "'" _
                              & " ORDER BY tblIn2.PrKey DESC"

        Using cmd = New SqlCommand(Query, frmMain.myConn)
            If frmMain.myConn.State = ConnectionState.Closed Then
                frmMain.myConn.Open()
            End If
            Using dr As SqlDataReader = cmd.ExecuteReader
                If dr.Read() Then
                    LabelControl2.Text = dr(0)
                    LabelControl3.Text = dr(1)
                Else
                    LabelControl2.Text = "Item Name"
                    LabelControl3.Text = "0.00"
                    TextEdit1.Focus()
                    TextEdit1.SelectAll()
                End If
            End Using
            frmMain.myConn.Close()
        End Using
    End Sub

    Private Sub frmCheckItemCost2_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        TextEdit1.Focus()
        TextEdit1.SelectAll()
    End Sub
End Class

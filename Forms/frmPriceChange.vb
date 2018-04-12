Imports System.Data.SqlClient
Imports System.Globalization
Public Class frmPriceChange
    Private Shared myConn As New SqlConnection(GV.myConn)
    Dim PrKey As Double = 0
    Private Sub btCancel_Click(sender As System.Object, e As System.EventArgs) Handles btCancel.Click
        Me.Close()
    End Sub

    Private Sub frmPriceChange_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim NQuery As String = "SELECT tblItems.* FROM tblItems LEFT OUTER JOIN tblMultiCodes ON tblItems.PrKey = tblMultiCodes.Item" _
                                         & " WHERE tblItems.Serial = '" & frmMain.iItem.Text & "' OR tblMultiCodes.Code = '" & frmMain.iItem.Text & "';"

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
                PrKey = dt.Rows(0)(0).ToString
                tbName.Text = dt.Rows(0)(2).ToString
                tbPrice.Text = dt.Rows(0)(3).ToString
                tbMinimum.Text = dt.Rows(0)(5).ToString
                tbEnglishName.Text = dt.Rows(0)(9).ToString
            Catch ex As Exception
                tbName.Text = "No Item"
                tbPrice.Text = ""
                tbMinimum.Text = ""
                tbEnglishName.Text = ""
                PrKey = 0
            End Try

            myConn.Close()
        End Using
        tbPrice.Focus()

    End Sub

    Private Sub tbPrice_GotFocus(sender As Object, e As System.EventArgs) Handles tbPrice.GotFocus
        tbPrice.SelectAll()
    End Sub

    Private Sub tbPrice_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbPrice.KeyPress
        If Not Char.IsControl(e.KeyChar) And Not Char.IsDigit(e.KeyChar) And Not e.KeyChar = "." Then
            e.Handled = True
        ElseIf e.KeyChar = "." And tbPrice.Text Like "*" & "." & "*" Then
            e.Handled = True
        End If
    End Sub

    Private Sub tbPrice_TextChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub tbMinimum_GotFocus(sender As Object, e As System.EventArgs) Handles tbMinimum.GotFocus
        tbMinimum.SelectAll()
    End Sub

    Private Sub tbMinimum_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbMinimum.KeyPress
        If Not Char.IsControl(e.KeyChar) And Not Char.IsDigit(e.KeyChar) And Not e.KeyChar = "." Then
            e.Handled = True
        ElseIf e.KeyChar = "." And tbPrice.Text Like "*" & "." & "*" Then
            e.Handled = True
        End If
    End Sub

    Private Sub btOK_Click(sender As System.Object, e As System.EventArgs) Handles btOK.Click
        If tbName.Text = "" Then
            MsgBox("You must enter item name!")
            tbName.Focus()
            Exit Sub
        ElseIf Val(tbPrice.Text) = 0 Then
            MsgBox("You must enter item selling price!")
            tbPrice.Focus()
            tbPrice.SelectAll()
            Exit Sub
        End If

        Dim Query As String = "UPDATE tblItems SET Name = N'" & tbName.Text & "', Price = '" & Val(tbPrice.Text) & "', [Minimum] = '" & Val(tbMinimum.Text) & "', EnglishName = N'" & tbEnglishName.Text & "' WHERE PrKey = '" & PrKey & "'"
        Using cmd = New SqlCommand(Query, myConn)
            If myConn.State = ConnectionState.Closed Then
                myConn.Open()
            End If
            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox("Changes were not saved, as the item is used!")
            End Try
            myConn.Close()
            frmMain.lblSellingPrice.Text = "Selling Price: " & Val(tbPrice.Text)
            Me.Close()

        End Using
    End Sub

    Private Sub tbEnglishName_GotFocus(sender As Object, e As EventArgs) Handles tbEnglishName.GotFocus
        InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(CultureInfo.GetCultureInfo("AR-EG"))
    End Sub

    Private Sub tbEnglishName_LostFocus(sender As Object, e As EventArgs) Handles tbEnglishName.LostFocus
        InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(CultureInfo.GetCultureInfo("EN-US"))
    End Sub
End Class

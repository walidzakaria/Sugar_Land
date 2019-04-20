Imports System.Data.SqlClient
Public Class frmCategory
    Public Shared myConn As New SqlConnection(GV.myConn)

    Private Sub LoadCategories()
        Dim query As String
        Dim dt As New DataTable
        dt.Columns.Add("ID", GetType(Integer))
        dt.Columns.Add("Category", GetType(String))
        query = "SELECT * FROM tblCategory ORDER BY Category"
        Using cmd = New SqlCommand(Query, myConn)
            If myConn.State = ConnectionState.Closed Then
                myConn.Open()
            End If
            Using dr As SqlDataReader = cmd.ExecuteReader
                dt.Load(dr)
            End Using
            myConn.Close()
        End Using
        GridControl1.DataSource = Nothing
        GridControl1.DataSource = dt
    End Sub

    Private Sub frmCustomers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCategories()
        GridView1.MoveLast()
    End Sub

    Private Sub windowsUIButtonPanel_ButtonClick(sender As Object, e As DevExpress.XtraBars.Docking2010.ButtonEventArgs) Handles windowsUIButtonPanel.ButtonClick
        If e.Button.Properties.Caption = "New" Then
            GridView1.PostEditor()
            GridView1.AddNewRow()
        ElseIf e.Button.Properties.Caption = "Save" Then
            Dim Query As String = ""

            For x As Integer = 0 To GridView1.RowCount - 1
                GridView1.PostEditor()

                GridView1.UpdateCurrentRow()


                If Not IsDBNull(GridView1.GetRowCellValue(x, "Category")) Then
                    If Not Trim(GridView1.GetRowCellValue(x, "Category")) = "" Then
                        If IsDBNull(GridView1.GetRowCellValue(x, "ID")) Then
                            Query &= " INSERT INTO tblCategory (Category) VALUES (N'" & GridView1.GetRowCellValue(x, "Category") & "');"
                        Else
                            Query &= "UPDATE tblCategory SET Category = N'" & GridView1.GetRowCellValue(x, "Category") & "'" _
                                & " WHERE ID = " & GridView1.GetRowCellValue(x, "ID") & ";"
                        End If
                    End If
                End If
            Next
            If Query = "" Then
                Exit Sub
            End If
            Using cmd = New SqlCommand(Query, myConn)
                If myConn.State = ConnectionState.Closed Then
                    myConn.Open()
                End If
                cmd.ExecuteNonQuery()
                myConn.Close()
            End Using
            LoadCategories()
            frmMain.FillCategories()
            MsgBox("Saved!")

        ElseIf e.Button.Properties.Caption = "Delete" Then
            Dim DiaR As DialogResult = MessageBox.Show("Are you sure you want to delete this Category?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If DiaR = Windows.Forms.DialogResult.Yes Then
                Dim ID As String = GridView1.GetFocusedRowCellValue("ID")
                Dim Query As String = "DELETE FROM tblCategory WHERE ID = " & ID & ";"
                Using cmd = New SqlCommand(Query, myConn)
                    If myConn.State = ConnectionState.Closed Then
                        myConn.Open()
                    End If
                    Try
                        cmd.ExecuteNonQuery()
                    Catch ex As Exception
                        MsgBox("Cannot delete this Category, it's in use!")
                    End Try
                    myConn.Close()
                    LoadCategories()
                    frmMain.FillCategories()
                End Using
            End If

        End If
    End Sub


End Class
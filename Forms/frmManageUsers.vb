Public Class frmManageUsers

    Private Sub frmManageUsers_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub frmManageUsers_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DBDataSet.tblLogin' table. You can move, or remove it, as needed.
        Me.TblLoginTableAdapter.Fill(Me.DBDataSet.tblLogin)

    End Sub

    Private Sub TblLoginBindingNavigatorSaveItem_Click(sender As System.Object, e As System.EventArgs) Handles TblLoginBindingNavigatorSaveItem.Click
        Try
            Me.Validate()
            Me.TblLoginBindingSource.EndEdit()
            Me.TblLoginTableAdapter.Update(Me.DBDataSet.tblLogin)
        Catch ex As Exception
            MsgBox("Not saved")
        End Try
    End Sub

    Private Sub BindingNavigatorDeleteItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub BindingNavigatorDeleteItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorDeleteItem.Click
        Try
            Me.TblLoginBindingSource.RemoveCurrent()
            Me.TblLoginTableAdapter.Update(Me.DBDataSet.tblLogin)
        Catch ex As Exception
            MsgBox("Wasn't deleted")
        End Try
    End Sub
End Class

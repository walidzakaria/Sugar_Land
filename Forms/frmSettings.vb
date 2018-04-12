Public Class frmSettings

    Private Sub TblItemsBindingNavigatorSaveItem_Click(sender As System.Object, e As System.EventArgs) Handles TblItemsBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.TblItemsBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.DBDataSet)

    End Sub

    Private Sub frmSettings_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DBDataSet.tblItems' table. You can move, or remove it, as needed.
        'Me.TblItemsTableAdapter.Fill(Me.DBDataSet.tblItems)

    End Sub
End Class

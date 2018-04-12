Imports System.Data.SqlClient
Public Class frmRate

    Private Sub KryptonButton1_Click(sender As System.Object, e As System.EventArgs) Handles KryptonButton1.Click
        Me.Close()
    End Sub

    Private Sub KryptonButton2_Click(sender As System.Object, e As System.EventArgs) Handles KryptonButton2.Click
        If Val(KryptonTextBox3.Text) = 0 Then
            MessageBox.Show("You should enter a valid rate!", "Invalid Rate", MessageBoxButtons.OK, MessageBoxIcon.Information)
            KryptonTextBox3.Focus()
            KryptonTextBox3.SelectAll()
        Else
            Dim dup As Boolean
            Dim dat As Date
            dat = KryptonDateTimePicker1.Value

            Do Until dat > KryptonDateTimePicker2.Value.AddDays(1)
                Using cmd = New SqlCommand("SELECT * FROM tblRate WHERE [Day] = '" & dat.ToString("MM/dd/yyyy") & "'", frmMain.myConn)
                    frmMain.myConn.Open()
                    Using dt As SqlDataReader = cmd.ExecuteReader
                        If dt.Read() Then
                            dup = True
                        Else
                            dup = False
                        End If
                    End Using
                    frmMain.myConn.Close()
                End Using

                If dup = False Then
                    Using cmd = New SqlCommand("INSERT INTO tblRate (Day, Rate) VALUES ('" & dat.ToString("MM/dd/yyyy") & "', '" & Val(KryptonTextBox3.Text) & "')", frmMain.myConn)
                        frmMain.myConn.Open()
                        cmd.ExecuteNonQuery()
                        frmMain.myConn.Close()
                    End Using
                Else
                    Dim dr = DialogResult
                    dr = MessageBox.Show("Date: " & dat.ToString("dd/MM/yyyy") & " already exists. Do you want to modify it?", "Modify?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                    If dr = Windows.Forms.DialogResult.Yes Then
                        Using cmd = New SqlCommand("UPDATE tblRate SET Rate = '" & Val(KryptonTextBox3.Text) & "' WHERE Day = '" & dat.ToString("MM/dd/yyyy") & "'", frmMain.myConn)
                            frmMain.myConn.Open()
                            cmd.ExecuteNonQuery()
                            frmMain.myConn.Close()
                        End Using
                    End If

                End If

                dat = dat.AddDays(1)
            Loop
            Me.Close()
           

        End If
    End Sub

    Private Sub KryptonTextBox3_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles KryptonTextBox3.KeyPress
        If Not Char.IsControl(e.KeyChar) And Not Char.IsDigit(e.KeyChar) And Not e.KeyChar = "." Then
            e.Handled = True
        End If
        If e.KeyChar = "." And KryptonTextBox3.Text Like "*" & "." & "*" Then
            e.Handled = True
        End If
    End Sub

    Private Sub KryptonTextBox3_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles KryptonTextBox3.PreviewKeyDown
      
    End Sub

    Private Sub KryptonTextBox3_TextChanged(sender As System.Object, e As System.EventArgs) Handles KryptonTextBox3.TextChanged

    End Sub

    Private Sub KryptonDateTimePicker1_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles KryptonDateTimePicker1.PreviewKeyDown
       
    End Sub

    Private Sub KryptonDateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KryptonDateTimePicker1.ValueChanged

    End Sub

    Private Sub KryptonDateTimePicker2_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles KryptonDateTimePicker2.PreviewKeyDown
     
    End Sub

    Private Sub frmRate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class

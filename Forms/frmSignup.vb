Imports System.Windows.Forms
Imports System.Data.SqlClient

Public Class frmSignup
    Dim myConn As New SqlConnection(GV.myConn)
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    'Private Sub TblLoginBindingNavigatorSaveItem_Click(sender As System.Object, e As System.EventArgs)
    '    Me.Validate()
    '    Me.TblLoginBindingSource.EndEdit()
    '    Me.TableAdapterManager.UpdateAll(Me.DBDataSet)

    'End Sub

    Private Sub frmSignup_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DBDataSet.tblLogin' table. You can move, or remove it, as needed.

        Me.TransparencyKey = Me.BackColor

        'Me.TblLoginTableAdapter.Fill(Me.DBDataSet.tblLogin)

        'TblLoginBindingSource.AddNew()
        UsernameTextBox.Focus()
        PasswordTextBox.Text = ""
        UsernameTextBox.Text = ""
        TextBox1.Text = ""
        UsernameTextBox.Focus()

    End Sub

    Private Sub UsernameTextBox_GotFocus(sender As Object, e As System.EventArgs) Handles UsernameTextBox.GotFocus
        Try
            UsernameTextBox.SelectAll()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub UsernameTextBox_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles UsernameTextBox.KeyDown
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Enter Then
            e.Handled = True
            PasswordTextBox.Focus()
        End If
    End Sub

    Private Sub UsernameTextBox_TextChanged(sender As System.Object, e As System.EventArgs) Handles UsernameTextBox.TextChanged
        ' UsernameLabel1.Text = UsernameTextBox.Text

    End Sub

    Private Sub PasswordTextBox_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles PasswordTextBox.KeyDown
        If e.KeyCode = Keys.Up Then
            e.Handled = True
            UsernameTextBox.Focus()
        ElseIf e.KeyCode = Keys.Down Or e.KeyCode = Keys.Enter Then
            e.Handled = True
            TextBox1.Focus()
        End If
    End Sub

    Private Sub PasswordTextBox_TextChanged(sender As System.Object, e As System.EventArgs) Handles PasswordTextBox.TextChanged
        'PasswordLabel1.Text = PasswordTextBox.Text
    End Sub

    Private Sub OK_Click(sender As System.Object, e As System.EventArgs) Handles OK.Click

        If UsernameTextBox.Text = "" Then
            UsernameTextBox.Focus()
        ElseIf PasswordTextBox.Text = "" Then
            PasswordTextBox.Focus()
        ElseIf Not PasswordTextBox.Text = TextBox1.Text Then
            MessageBox.Show("You have retyped the password incorrectly. You must type the same password twice!      ", "Password Not Matching", MessageBoxButtons.OK, MessageBoxIcon.Error)
            PasswordTextBox.Text = ""
            TextBox1.Text = ""
            PasswordTextBox.Focus()
        Else

            Dim Auth As String
            If RadioButton1.Checked = True Then
                Auth = "Admin"
            ElseIf RadioButton2.Checked = True Then
                Auth = "Cashier"
            ElseIf RadioButton3.Checked = True Then
                Auth = "Receptionist"
            Else
                Auth = "Accountant"
            End If
            Dim theName As String
            theName = UsernameTextBox.Text.Substring(0, 1).ToUpper & UsernameTextBox.Text.Substring(1).ToLower

            Try
                Using Reg = New SqlCommand("INSERT INTO tblLogin (UserName, Password, Authority) Values (N'" & theName & "', '" & ExClass.GenerateHash(PasswordTextBox.Text) & "', '" & Auth & "')", myConn)
                    myConn.Open()
                    Reg.ExecuteNonQuery()
                    myConn.Close()
                End Using

                MsgBox(UsernameTextBox.Text & " has been signed up!")
                UsernameTextBox.Text = Nothing
                PasswordTextBox.Text = Nothing
                TextBox1.Text = Nothing
                RadioButton1.Checked = True

                Me.Close()
            Catch ex As Exception
                MessageBox.Show("This name already exists. Please type a different name!", "Duplicate Name", MessageBoxButtons.OK, MessageBoxIcon.Information)
                UsernameTextBox.Focus()
            End Try


        End If

    End Sub

    Private Sub Cancel_Click(sender As System.Object, e As System.EventArgs) Handles Cancel.Click
        UsernameTextBox.Text = Nothing
        PasswordTextBox.Text = Nothing
        TextBox1.Text = Nothing
        RadioButton1.Checked = True

        Me.Close()
    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Up Then
            e.Handled = True
            PasswordTextBox.Focus()
        ElseIf e.KeyCode = Keys.Down Then
            e.Handled = True
            OK.Focus()
        ElseIf e.KeyCode = Keys.Enter Then
            e.Handled = True
            OK.PerformClick()
        End If
    End Sub

End Class

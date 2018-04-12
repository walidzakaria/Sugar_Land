<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TestForm
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.tmTill = New ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker()
        Me.tmFrom = New ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker()
        Me.dailyDateTill = New ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker()
        Me.dailyDateFrom = New ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker()
        Me.cbCashiers = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(89, 75)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "mac"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(89, 104)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "mboard"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(89, 133)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 2
        Me.Button3.Text = "hdd"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.Label1.Location = New System.Drawing.Point(204, 80)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 19)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Label1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.Label2.Location = New System.Drawing.Point(204, 109)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 19)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Label2"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.Label3.Location = New System.Drawing.Point(204, 138)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 19)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Label3"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.Label4.Location = New System.Drawing.Point(441, 80)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 19)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Label4"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.Label5.Location = New System.Drawing.Point(441, 109)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 19)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Label5"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.Label6.Location = New System.Drawing.Point(441, 138)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(55, 19)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Label6"
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(143, 205)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(326, 23)
        Me.Button4.TabIndex = 9
        Me.Button4.Text = "save"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(143, 287)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(326, 23)
        Me.Button5.TabIndex = 10
        Me.Button5.Text = "Show report"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'tmTill
        '
        Me.tmTill.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tmTill.CalendarTodayDate = New Date(2015, 6, 18, 0, 0, 0, 0)
        Me.tmTill.CustomFormat = "HH:mm"
        Me.tmTill.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.tmTill.Location = New System.Drawing.Point(679, 134)
        Me.tmTill.Name = "tmTill"
        Me.tmTill.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.tmTill.ShowUpDown = True
        Me.tmTill.Size = New System.Drawing.Size(89, 25)
        Me.tmTill.StateCommon.Content.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tmTill.TabIndex = 81
        Me.tmTill.TabStop = False
        '
        'tmFrom
        '
        Me.tmFrom.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tmFrom.CalendarTodayDate = New Date(2015, 6, 18, 0, 0, 0, 0)
        Me.tmFrom.CustomFormat = "HH:mm"
        Me.tmFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.tmFrom.Location = New System.Drawing.Point(533, 134)
        Me.tmFrom.Name = "tmFrom"
        Me.tmFrom.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.tmFrom.ShowUpDown = True
        Me.tmFrom.Size = New System.Drawing.Size(89, 25)
        Me.tmFrom.StateCommon.Content.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tmFrom.TabIndex = 80
        Me.tmFrom.TabStop = False
        '
        'dailyDateTill
        '
        Me.dailyDateTill.CalendarTodayDate = New Date(2015, 9, 7, 0, 0, 0, 0)
        Me.dailyDateTill.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dailyDateTill.Location = New System.Drawing.Point(649, 79)
        Me.dailyDateTill.Name = "dailyDateTill"
        Me.dailyDateTill.Size = New System.Drawing.Size(129, 25)
        Me.dailyDateTill.StateCommon.Content.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dailyDateTill.TabIndex = 79
        '
        'dailyDateFrom
        '
        Me.dailyDateFrom.CalendarTodayDate = New Date(2015, 9, 7, 0, 0, 0, 0)
        Me.dailyDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dailyDateFrom.Location = New System.Drawing.Point(502, 80)
        Me.dailyDateFrom.Name = "dailyDateFrom"
        Me.dailyDateFrom.Size = New System.Drawing.Size(129, 25)
        Me.dailyDateFrom.StateCommon.Content.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dailyDateFrom.TabIndex = 78
        '
        'cbCashiers
        '
        Me.cbCashiers.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbCashiers.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbCashiers.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCashiers.FormattingEnabled = True
        Me.cbCashiers.Location = New System.Drawing.Point(502, 182)
        Me.cbCashiers.Name = "cbCashiers"
        Me.cbCashiers.Size = New System.Drawing.Size(276, 27)
        Me.cbCashiers.TabIndex = 82
        Me.cbCashiers.TabStop = False
        '
        'TestForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(798, 337)
        Me.Controls.Add(Me.tmTill)
        Me.Controls.Add(Me.tmFrom)
        Me.Controls.Add(Me.dailyDateTill)
        Me.Controls.Add(Me.dailyDateFrom)
        Me.Controls.Add(Me.cbCashiers)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Name = "TestForm"
        Me.Text = "TestForm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents tmTill As ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker
    Friend WithEvents tmFrom As ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker
    Friend WithEvents dailyDateTill As ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker
    Friend WithEvents dailyDateFrom As ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker
    Friend WithEvents cbCashiers As System.Windows.Forms.ComboBox
End Class

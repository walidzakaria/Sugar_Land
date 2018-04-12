<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRate
    Inherits ComponentFactory.Krypton.Toolkit.KryptonForm

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
        Me.components = New System.ComponentModel.Container()
        Me.KryptonPanel = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonDateTimePicker2 = New ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker()
        Me.KryptonButton1 = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonButton2 = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonDateTimePicker1 = New ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker()
        Me.KryptonTextBox3 = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonLabel10 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel13 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'KryptonPanel
        '
        Me.KryptonPanel.Controls.Add(Me.KryptonDateTimePicker2)
        Me.KryptonPanel.Controls.Add(Me.KryptonButton1)
        Me.KryptonPanel.Controls.Add(Me.KryptonButton2)
        Me.KryptonPanel.Controls.Add(Me.KryptonDateTimePicker1)
        Me.KryptonPanel.Controls.Add(Me.KryptonTextBox3)
        Me.KryptonPanel.Controls.Add(Me.KryptonLabel10)
        Me.KryptonPanel.Controls.Add(Me.KryptonLabel13)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Size = New System.Drawing.Size(279, 111)
        Me.KryptonPanel.TabIndex = 0
        '
        'KryptonDateTimePicker2
        '
        Me.KryptonDateTimePicker2.CalendarTodayDate = New Date(2015, 5, 28, 0, 0, 0, 0)
        Me.KryptonDateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.KryptonDateTimePicker2.Location = New System.Drawing.Point(161, 12)
        Me.KryptonDateTimePicker2.Name = "KryptonDateTimePicker2"
        Me.KryptonDateTimePicker2.Size = New System.Drawing.Size(96, 21)
        Me.KryptonDateTimePicker2.TabIndex = 1
        '
        'KryptonButton1
        '
        Me.KryptonButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.KryptonButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.KryptonButton1.Location = New System.Drawing.Point(197, 75)
        Me.KryptonButton1.Name = "KryptonButton1"
        Me.KryptonButton1.Size = New System.Drawing.Size(60, 24)
        Me.KryptonButton1.TabIndex = 4
        Me.KryptonButton1.Values.Text = "CLOSE"
        '
        'KryptonButton2
        '
        Me.KryptonButton2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.KryptonButton2.Location = New System.Drawing.Point(131, 75)
        Me.KryptonButton2.Name = "KryptonButton2"
        Me.KryptonButton2.Size = New System.Drawing.Size(60, 24)
        Me.KryptonButton2.TabIndex = 3
        Me.KryptonButton2.Values.Text = "ADD"
        '
        'KryptonDateTimePicker1
        '
        Me.KryptonDateTimePicker1.CalendarTodayDate = New Date(2015, 5, 28, 0, 0, 0, 0)
        Me.KryptonDateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.KryptonDateTimePicker1.Location = New System.Drawing.Point(59, 11)
        Me.KryptonDateTimePicker1.Name = "KryptonDateTimePicker1"
        Me.KryptonDateTimePicker1.Size = New System.Drawing.Size(96, 21)
        Me.KryptonDateTimePicker1.TabIndex = 0
        '
        'KryptonTextBox3
        '
        Me.KryptonTextBox3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.KryptonTextBox3.Location = New System.Drawing.Point(59, 38)
        Me.KryptonTextBox3.Name = "KryptonTextBox3"
        Me.KryptonTextBox3.Size = New System.Drawing.Size(198, 20)
        Me.KryptonTextBox3.TabIndex = 2
        '
        'KryptonLabel10
        '
        Me.KryptonLabel10.Location = New System.Drawing.Point(13, 38)
        Me.KryptonLabel10.Name = "KryptonLabel10"
        Me.KryptonLabel10.Size = New System.Drawing.Size(38, 20)
        Me.KryptonLabel10.TabIndex = 21
        Me.KryptonLabel10.Values.Text = "Rate:"
        '
        'KryptonLabel13
        '
        Me.KryptonLabel13.Location = New System.Drawing.Point(12, 12)
        Me.KryptonLabel13.Name = "KryptonLabel13"
        Me.KryptonLabel13.Size = New System.Drawing.Size(39, 20)
        Me.KryptonLabel13.TabIndex = 19
        Me.KryptonLabel13.Values.Text = "Date:"
        '
        'KryptonManager
        '
        Me.KryptonManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2010Silver
        '
        'frmRate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.KryptonButton1
        Me.ClientSize = New System.Drawing.Size(279, 111)
        Me.Controls.Add(Me.KryptonPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmRate"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Rate"
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        Me.KryptonPanel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents KryptonPanel As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonManager As ComponentFactory.Krypton.Toolkit.KryptonManager

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
    Friend WithEvents KryptonDateTimePicker1 As ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker
    Friend WithEvents KryptonTextBox3 As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonLabel10 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel13 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonButton1 As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents KryptonButton2 As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents KryptonDateTimePicker2 As ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker
End Class

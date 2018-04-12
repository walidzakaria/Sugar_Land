<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSync
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSync))
        Me.KryptonPanel = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.btCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.btOK = New DevExpress.XtraEditors.SimpleButton()
        Me.cmTimer = New System.Windows.Forms.ComboBox()
        Me.KryptonLabel11 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'KryptonPanel
        '
        Me.KryptonPanel.Controls.Add(Me.btCancel)
        Me.KryptonPanel.Controls.Add(Me.btOK)
        Me.KryptonPanel.Controls.Add(Me.cmTimer)
        Me.KryptonPanel.Controls.Add(Me.KryptonLabel11)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.KryptonPanel.Size = New System.Drawing.Size(372, 88)
        Me.KryptonPanel.TabIndex = 0
        '
        'btCancel
        '
        Me.btCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btCancel.Image = CType(resources.GetObject("btCancel.Image"), System.Drawing.Image)
        Me.btCancel.Location = New System.Drawing.Point(24, 47)
        Me.btCancel.Name = "btCancel"
        Me.btCancel.Size = New System.Drawing.Size(83, 29)
        Me.btCancel.TabIndex = 64
        Me.btCancel.Text = "≈·€«¡"
        '
        'btOK
        '
        Me.btOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btOK.Image = CType(resources.GetObject("btOK.Image"), System.Drawing.Image)
        Me.btOK.Location = New System.Drawing.Point(113, 47)
        Me.btOK.Name = "btOK"
        Me.btOK.Size = New System.Drawing.Size(83, 29)
        Me.btOK.TabIndex = 63
        Me.btOK.Text = "„Ê«›ﬁ"
        '
        'cmTimer
        '
        Me.cmTimer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmTimer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmTimer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmTimer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmTimer.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmTimer.FormattingEnabled = True
        Me.cmTimer.Items.AddRange(New Object() {"5 œﬁ«∆ﬁ", "10 œﬁ«∆ﬁ", "30 œﬁÌﬁ…", "”«⁄…", "”«⁄ Ì‰", "ÌÊ„Ì«", "√»œ«"})
        Me.cmTimer.Location = New System.Drawing.Point(67, 12)
        Me.cmTimer.Name = "cmTimer"
        Me.cmTimer.Size = New System.Drawing.Size(189, 21)
        Me.cmTimer.TabIndex = 61
        Me.cmTimer.TabStop = False
        '
        'KryptonLabel11
        '
        Me.KryptonLabel11.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.KryptonLabel11.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel
        Me.KryptonLabel11.Location = New System.Drawing.Point(267, 12)
        Me.KryptonLabel11.Name = "KryptonLabel11"
        Me.KryptonLabel11.Size = New System.Drawing.Size(47, 20)
        Me.KryptonLabel11.StateCommon.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Far
        Me.KryptonLabel11.StateCommon.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near
        Me.KryptonLabel11.TabIndex = 60
        Me.KryptonLabel11.Values.Text = "«· “«„‰:"
        '
        'KryptonManager
        '
        Me.KryptonManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2010Silver
        '
        'frmSync
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(372, 88)
        Me.Controls.Add(Me.KryptonPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSync"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sync"
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
    Friend WithEvents cmTimer As System.Windows.Forms.ComboBox
    Private WithEvents KryptonLabel11 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents btCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btOK As DevExpress.XtraEditors.SimpleButton
End Class

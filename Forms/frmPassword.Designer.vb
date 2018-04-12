<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPassword
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPassword))
        Me.KryptonPanel = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.btCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.KryptonLabel2 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel4 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.btOK = New DevExpress.XtraEditors.SimpleButton()
        Me.tbRetype = New DevExpress.XtraEditors.TextEdit()
        Me.tbNewPassowrd = New DevExpress.XtraEditors.TextEdit()
        Me.tbOldPassowrd = New DevExpress.XtraEditors.TextEdit()
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager()
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        CType(Me.tbRetype.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbNewPassowrd.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbOldPassowrd.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KryptonPanel
        '
        Me.KryptonPanel.Controls.Add(Me.btCancel)
        Me.KryptonPanel.Controls.Add(Me.KryptonLabel2)
        Me.KryptonPanel.Controls.Add(Me.KryptonLabel1)
        Me.KryptonPanel.Controls.Add(Me.KryptonLabel4)
        Me.KryptonPanel.Controls.Add(Me.btOK)
        Me.KryptonPanel.Controls.Add(Me.tbRetype)
        Me.KryptonPanel.Controls.Add(Me.tbNewPassowrd)
        Me.KryptonPanel.Controls.Add(Me.tbOldPassowrd)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Size = New System.Drawing.Size(432, 175)
        Me.KryptonPanel.TabIndex = 0
        '
        'btCancel
        '
        Me.btCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btCancel.Image = CType(resources.GetObject("btCancel.Image"), System.Drawing.Image)
        Me.btCancel.Location = New System.Drawing.Point(309, 134)
        Me.btCancel.Name = "btCancel"
        Me.btCancel.Size = New System.Drawing.Size(91, 29)
        Me.btCancel.TabIndex = 4
        Me.btCancel.Text = "CANCEL"
        '
        'KryptonLabel2
        '
        Me.KryptonLabel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.KryptonLabel2.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel
        Me.KryptonLabel2.Location = New System.Drawing.Point(32, 97)
        Me.KryptonLabel2.Name = "KryptonLabel2"
        Me.KryptonLabel2.Size = New System.Drawing.Size(51, 20)
        Me.KryptonLabel2.StateCommon.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Far
        Me.KryptonLabel2.StateCommon.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near
        Me.KryptonLabel2.TabIndex = 56
        Me.KryptonLabel2.Values.Text = "Retype:"
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.KryptonLabel1.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel
        Me.KryptonLabel1.Location = New System.Drawing.Point(32, 71)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Size = New System.Drawing.Size(93, 20)
        Me.KryptonLabel1.StateCommon.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Far
        Me.KryptonLabel1.StateCommon.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near
        Me.KryptonLabel1.TabIndex = 54
        Me.KryptonLabel1.Values.Text = "New Password:"
        '
        'KryptonLabel4
        '
        Me.KryptonLabel4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.KryptonLabel4.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel
        Me.KryptonLabel4.Location = New System.Drawing.Point(32, 22)
        Me.KryptonLabel4.Name = "KryptonLabel4"
        Me.KryptonLabel4.Size = New System.Drawing.Size(88, 20)
        Me.KryptonLabel4.StateCommon.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Far
        Me.KryptonLabel4.StateCommon.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near
        Me.KryptonLabel4.TabIndex = 52
        Me.KryptonLabel4.Values.Text = "Old Password:"
        '
        'btOK
        '
        Me.btOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btOK.Image = CType(resources.GetObject("btOK.Image"), System.Drawing.Image)
        Me.btOK.Location = New System.Drawing.Point(212, 134)
        Me.btOK.Name = "btOK"
        Me.btOK.Size = New System.Drawing.Size(91, 29)
        Me.btOK.TabIndex = 3
        Me.btOK.Text = "OK"
        '
        'tbRetype
        '
        Me.tbRetype.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbRetype.EnterMoveNextControl = True
        Me.tbRetype.Location = New System.Drawing.Point(139, 97)
        Me.tbRetype.Name = "tbRetype"
        Me.tbRetype.Properties.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.tbRetype.Size = New System.Drawing.Size(261, 20)
        Me.tbRetype.TabIndex = 2
        '
        'tbNewPassowrd
        '
        Me.tbNewPassowrd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbNewPassowrd.EnterMoveNextControl = True
        Me.tbNewPassowrd.Location = New System.Drawing.Point(139, 71)
        Me.tbNewPassowrd.Name = "tbNewPassowrd"
        Me.tbNewPassowrd.Properties.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.tbNewPassowrd.Size = New System.Drawing.Size(261, 20)
        Me.tbNewPassowrd.TabIndex = 1
        '
        'tbOldPassowrd
        '
        Me.tbOldPassowrd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbOldPassowrd.EnterMoveNextControl = True
        Me.tbOldPassowrd.Location = New System.Drawing.Point(139, 22)
        Me.tbOldPassowrd.Name = "tbOldPassowrd"
        Me.tbOldPassowrd.Properties.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.tbOldPassowrd.Size = New System.Drawing.Size(261, 20)
        Me.tbOldPassowrd.TabIndex = 0
        '
        'KryptonManager
        '
        Me.KryptonManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2010Silver
        '
        'frmPassword
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btCancel
        Me.ClientSize = New System.Drawing.Size(432, 175)
        Me.Controls.Add(Me.KryptonPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPassword"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Password"
        Me.TopMost = True
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        Me.KryptonPanel.PerformLayout()
        CType(Me.tbRetype.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbNewPassowrd.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbOldPassowrd.Properties, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents btCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents tbRetype As DevExpress.XtraEditors.TextEdit
    Private WithEvents KryptonLabel2 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents tbNewPassowrd As DevExpress.XtraEditors.TextEdit
    Private WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents tbOldPassowrd As DevExpress.XtraEditors.TextEdit
    Private WithEvents KryptonLabel4 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents btOK As DevExpress.XtraEditors.SimpleButton
End Class

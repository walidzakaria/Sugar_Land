<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPriceChange
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPriceChange))
        Me.KryptonPanel = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.tbName = New DevExpress.XtraEditors.TextEdit()
        Me.KryptonLabel2 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.tbMinimum = New DevExpress.XtraEditors.TextEdit()
        Me.tbPrice = New DevExpress.XtraEditors.TextEdit()
        Me.btCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.btOK = New DevExpress.XtraEditors.SimpleButton()
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel9 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager()
        Me.tbEnglishName = New DevExpress.XtraEditors.TextEdit()
        Me.KryptonLabel3 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        CType(Me.tbName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbMinimum.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbPrice.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbEnglishName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KryptonPanel
        '
        Me.KryptonPanel.Controls.Add(Me.tbEnglishName)
        Me.KryptonPanel.Controls.Add(Me.KryptonLabel3)
        Me.KryptonPanel.Controls.Add(Me.tbName)
        Me.KryptonPanel.Controls.Add(Me.KryptonLabel2)
        Me.KryptonPanel.Controls.Add(Me.tbMinimum)
        Me.KryptonPanel.Controls.Add(Me.tbPrice)
        Me.KryptonPanel.Controls.Add(Me.btCancel)
        Me.KryptonPanel.Controls.Add(Me.btOK)
        Me.KryptonPanel.Controls.Add(Me.KryptonLabel1)
        Me.KryptonPanel.Controls.Add(Me.KryptonLabel9)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Blue
        Me.KryptonPanel.Size = New System.Drawing.Size(430, 190)
        Me.KryptonPanel.TabIndex = 0
        '
        'tbName
        '
        Me.tbName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbName.EnterMoveNextControl = True
        Me.tbName.Location = New System.Drawing.Point(120, 12)
        Me.tbName.Name = "tbName"
        Me.tbName.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbName.Properties.Appearance.Options.UseFont = True
        Me.tbName.Size = New System.Drawing.Size(296, 26)
        Me.tbName.TabIndex = 0
        '
        'KryptonLabel2
        '
        Me.KryptonLabel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.KryptonLabel2.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel
        Me.KryptonLabel2.Location = New System.Drawing.Point(12, 14)
        Me.KryptonLabel2.Name = "KryptonLabel2"
        Me.KryptonLabel2.Size = New System.Drawing.Size(99, 24)
        Me.KryptonLabel2.StateCommon.ShortText.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonLabel2.StateCommon.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Far
        Me.KryptonLabel2.StateCommon.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near
        Me.KryptonLabel2.TabIndex = 67
        Me.KryptonLabel2.Values.Text = "Item Name:"
        '
        'tbMinimum
        '
        Me.tbMinimum.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbMinimum.EnterMoveNextControl = True
        Me.tbMinimum.Location = New System.Drawing.Point(120, 108)
        Me.tbMinimum.Name = "tbMinimum"
        Me.tbMinimum.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbMinimum.Properties.Appearance.Options.UseFont = True
        Me.tbMinimum.Size = New System.Drawing.Size(296, 26)
        Me.tbMinimum.TabIndex = 3
        '
        'tbPrice
        '
        Me.tbPrice.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbPrice.EnterMoveNextControl = True
        Me.tbPrice.Location = New System.Drawing.Point(120, 76)
        Me.tbPrice.Name = "tbPrice"
        Me.tbPrice.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbPrice.Properties.Appearance.Options.UseFont = True
        Me.tbPrice.Size = New System.Drawing.Size(296, 26)
        Me.tbPrice.TabIndex = 2
        '
        'btCancel
        '
        Me.btCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btCancel.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.btCancel.Appearance.Options.UseFont = True
        Me.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btCancel.Image = CType(resources.GetObject("btCancel.Image"), System.Drawing.Image)
        Me.btCancel.Location = New System.Drawing.Point(302, 149)
        Me.btCancel.Name = "btCancel"
        Me.btCancel.Size = New System.Drawing.Size(114, 29)
        Me.btCancel.TabIndex = 5
        Me.btCancel.Text = "CANCEL"
        '
        'btOK
        '
        Me.btOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btOK.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.btOK.Appearance.Options.UseFont = True
        Me.btOK.Image = CType(resources.GetObject("btOK.Image"), System.Drawing.Image)
        Me.btOK.Location = New System.Drawing.Point(182, 149)
        Me.btOK.Name = "btOK"
        Me.btOK.Size = New System.Drawing.Size(114, 29)
        Me.btOK.TabIndex = 4
        Me.btOK.Text = "OK"
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.KryptonLabel1.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel
        Me.KryptonLabel1.Location = New System.Drawing.Point(12, 110)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Size = New System.Drawing.Size(84, 24)
        Me.KryptonLabel1.StateCommon.ShortText.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonLabel1.StateCommon.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Far
        Me.KryptonLabel1.StateCommon.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near
        Me.KryptonLabel1.TabIndex = 53
        Me.KryptonLabel1.Values.Text = "Minimum:"
        '
        'KryptonLabel9
        '
        Me.KryptonLabel9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.KryptonLabel9.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel
        Me.KryptonLabel9.Location = New System.Drawing.Point(11, 78)
        Me.KryptonLabel9.Name = "KryptonLabel9"
        Me.KryptonLabel9.Size = New System.Drawing.Size(105, 24)
        Me.KryptonLabel9.StateCommon.ShortText.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonLabel9.StateCommon.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Far
        Me.KryptonLabel9.StateCommon.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near
        Me.KryptonLabel9.TabIndex = 51
        Me.KryptonLabel9.Values.Text = "Selling Price:"
        '
        'KryptonManager
        '
        Me.KryptonManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2010Silver
        '
        'tbEnglishName
        '
        Me.tbEnglishName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbEnglishName.EnterMoveNextControl = True
        Me.tbEnglishName.Location = New System.Drawing.Point(121, 44)
        Me.tbEnglishName.Name = "tbEnglishName"
        Me.tbEnglishName.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbEnglishName.Properties.Appearance.Options.UseFont = True
        Me.tbEnglishName.Size = New System.Drawing.Size(296, 26)
        Me.tbEnglishName.TabIndex = 1
        '
        'KryptonLabel3
        '
        Me.KryptonLabel3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.KryptonLabel3.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel
        Me.KryptonLabel3.Location = New System.Drawing.Point(12, 46)
        Me.KryptonLabel3.Name = "KryptonLabel3"
        Me.KryptonLabel3.Size = New System.Drawing.Size(110, 24)
        Me.KryptonLabel3.StateCommon.ShortText.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonLabel3.StateCommon.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Far
        Me.KryptonLabel3.StateCommon.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near
        Me.KryptonLabel3.TabIndex = 69
        Me.KryptonLabel3.Values.Text = "Arabic Name:"
        '
        'frmPriceChange
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(430, 190)
        Me.Controls.Add(Me.KryptonPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmPriceChange"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Price Change"
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        Me.KryptonPanel.PerformLayout()
        CType(Me.tbName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbMinimum.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbPrice.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbEnglishName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
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
    Private WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Private WithEvents KryptonLabel9 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents btCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btOK As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents tbMinimum As DevExpress.XtraEditors.TextEdit
    Friend WithEvents tbPrice As DevExpress.XtraEditors.TextEdit
    Friend WithEvents tbName As DevExpress.XtraEditors.TextEdit
    Private WithEvents KryptonLabel2 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents tbEnglishName As DevExpress.XtraEditors.TextEdit
    Private WithEvents KryptonLabel3 As ComponentFactory.Krypton.Toolkit.KryptonLabel
End Class

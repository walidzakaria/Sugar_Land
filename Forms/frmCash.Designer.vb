<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCash
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCash))
        Me.KryptonPanel = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.cCurrencyTo = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.cSumTo = New DevExpress.XtraEditors.TextEdit()
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.cCurrency = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.cIndication = New DevExpress.XtraEditors.MemoEdit()
        Me.KryptonLabel2 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.cSum = New DevExpress.XtraEditors.TextEdit()
        Me.lblTitle = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel4 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.btCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.btOK = New DevExpress.XtraEditors.SimpleButton()
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        CType(Me.cCurrencyTo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cSumTo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cCurrency.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cIndication.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cSum.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KryptonPanel
        '
        Me.KryptonPanel.Controls.Add(Me.cCurrencyTo)
        Me.KryptonPanel.Controls.Add(Me.cSumTo)
        Me.KryptonPanel.Controls.Add(Me.KryptonLabel1)
        Me.KryptonPanel.Controls.Add(Me.cCurrency)
        Me.KryptonPanel.Controls.Add(Me.cIndication)
        Me.KryptonPanel.Controls.Add(Me.KryptonLabel2)
        Me.KryptonPanel.Controls.Add(Me.cSum)
        Me.KryptonPanel.Controls.Add(Me.lblTitle)
        Me.KryptonPanel.Controls.Add(Me.KryptonLabel4)
        Me.KryptonPanel.Controls.Add(Me.btCancel)
        Me.KryptonPanel.Controls.Add(Me.btOK)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Size = New System.Drawing.Size(447, 259)
        Me.KryptonPanel.TabIndex = 0
        '
        'cCurrencyTo
        '
        Me.cCurrencyTo.Location = New System.Drawing.Point(355, 114)
        Me.cCurrencyTo.Name = "cCurrencyTo"
        Me.cCurrencyTo.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 15.0!)
        Me.cCurrencyTo.Properties.Appearance.Options.UseFont = True
        Me.cCurrencyTo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cCurrencyTo.Properties.Items.AddRange(New Object() {"USD", "EUR", "EGP", "GBP", "RUB", "UAH"})
        Me.cCurrencyTo.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cCurrencyTo.Size = New System.Drawing.Size(79, 30)
        Me.cCurrencyTo.TabIndex = 3
        '
        'cSumTo
        '
        Me.cSumTo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cSumTo.EnterMoveNextControl = True
        Me.cSumTo.Location = New System.Drawing.Point(123, 114)
        Me.cSumTo.Name = "cSumTo"
        Me.cSumTo.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 16.0!)
        Me.cSumTo.Properties.Appearance.Options.UseFont = True
        Me.cSumTo.Size = New System.Drawing.Size(226, 32)
        Me.cSumTo.TabIndex = 2
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.KryptonLabel1.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel
        Me.KryptonLabel1.Location = New System.Drawing.Point(12, 116)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Size = New System.Drawing.Size(46, 30)
        Me.KryptonLabel1.StateCommon.ShortText.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonLabel1.StateCommon.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Far
        Me.KryptonLabel1.StateCommon.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near
        Me.KryptonLabel1.TabIndex = 72
        Me.KryptonLabel1.Values.Text = "To:"
        '
        'cCurrency
        '
        Me.cCurrency.Location = New System.Drawing.Point(355, 77)
        Me.cCurrency.Name = "cCurrency"
        Me.cCurrency.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 15.0!)
        Me.cCurrency.Properties.Appearance.Options.UseFont = True
        Me.cCurrency.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cCurrency.Properties.Items.AddRange(New Object() {"USD", "EUR", "EGP", "GBP", "RUB", "UAH"})
        Me.cCurrency.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cCurrency.Size = New System.Drawing.Size(79, 30)
        Me.cCurrency.TabIndex = 1
        '
        'cIndication
        '
        Me.cIndication.Location = New System.Drawing.Point(123, 114)
        Me.cIndication.Name = "cIndication"
        Me.cIndication.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 16.0!)
        Me.cIndication.Properties.Appearance.Options.UseFont = True
        Me.cIndication.Properties.MaxLength = 200
        Me.cIndication.Size = New System.Drawing.Size(312, 80)
        Me.cIndication.TabIndex = 4
        '
        'KryptonLabel2
        '
        Me.KryptonLabel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.KryptonLabel2.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel
        Me.KryptonLabel2.Location = New System.Drawing.Point(12, 114)
        Me.KryptonLabel2.Name = "KryptonLabel2"
        Me.KryptonLabel2.Size = New System.Drawing.Size(115, 30)
        Me.KryptonLabel2.StateCommon.ShortText.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonLabel2.StateCommon.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Far
        Me.KryptonLabel2.StateCommon.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near
        Me.KryptonLabel2.TabIndex = 69
        Me.KryptonLabel2.Values.Text = "Indication:"
        '
        'cSum
        '
        Me.cSum.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cSum.EnterMoveNextControl = True
        Me.cSum.Location = New System.Drawing.Point(123, 76)
        Me.cSum.Name = "cSum"
        Me.cSum.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 16.0!)
        Me.cSum.Properties.Appearance.Options.UseFont = True
        Me.cSum.Size = New System.Drawing.Size(226, 32)
        Me.cSum.TabIndex = 0
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = False
        Me.lblTitle.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.TitleControl
        Me.lblTitle.Location = New System.Drawing.Point(12, 8)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(423, 42)
        Me.lblTitle.StateCommon.ShortText.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblTitle.StateCommon.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center
        Me.lblTitle.StateCommon.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Far
        Me.lblTitle.TabIndex = 68
        Me.lblTitle.Values.Text = "Sum Type"
        '
        'KryptonLabel4
        '
        Me.KryptonLabel4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.KryptonLabel4.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel
        Me.KryptonLabel4.Location = New System.Drawing.Point(12, 78)
        Me.KryptonLabel4.Name = "KryptonLabel4"
        Me.KryptonLabel4.Size = New System.Drawing.Size(95, 30)
        Me.KryptonLabel4.StateCommon.ShortText.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonLabel4.StateCommon.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Far
        Me.KryptonLabel4.StateCommon.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near
        Me.KryptonLabel4.TabIndex = 66
        Me.KryptonLabel4.Values.Text = "Amount:"
        '
        'btCancel
        '
        Me.btCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btCancel.Appearance.Font = New System.Drawing.Font("Tahoma", 16.0!)
        Me.btCancel.Appearance.Options.UseFont = True
        Me.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btCancel.ImageOptions.Image = CType(resources.GetObject("btCancel.ImageOptions.Image"), System.Drawing.Image)
        Me.btCancel.Location = New System.Drawing.Point(309, 207)
        Me.btCancel.Name = "btCancel"
        Me.btCancel.Size = New System.Drawing.Size(126, 38)
        Me.btCancel.TabIndex = 6
        Me.btCancel.Text = "Cancel"
        '
        'btOK
        '
        Me.btOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btOK.Appearance.Font = New System.Drawing.Font("Tahoma", 16.0!)
        Me.btOK.Appearance.Options.UseFont = True
        Me.btOK.ImageOptions.Image = CType(resources.GetObject("btOK.ImageOptions.Image"), System.Drawing.Image)
        Me.btOK.Location = New System.Drawing.Point(177, 207)
        Me.btOK.Name = "btOK"
        Me.btOK.Size = New System.Drawing.Size(126, 38)
        Me.btOK.TabIndex = 5
        Me.btOK.Text = "OK"
        '
        'KryptonManager
        '
        Me.KryptonManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2010Silver
        '
        'frmCash
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btCancel
        Me.ClientSize = New System.Drawing.Size(447, 259)
        Me.Controls.Add(Me.KryptonPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmCash"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cash"
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        Me.KryptonPanel.PerformLayout()
        CType(Me.cCurrencyTo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cSumTo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cCurrency.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cIndication.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cSum.Properties, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents btOK As DevExpress.XtraEditors.SimpleButton
    Private WithEvents KryptonLabel2 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents cSum As DevExpress.XtraEditors.TextEdit
    Private WithEvents lblTitle As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Private WithEvents KryptonLabel4 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents cIndication As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents cCurrency As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents cCurrencyTo As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents cSumTo As DevExpress.XtraEditors.TextEdit
    Private WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
End Class

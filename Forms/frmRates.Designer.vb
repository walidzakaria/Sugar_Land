<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRates
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRates))
        Me.KryptonPanel = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.OK = New DevExpress.XtraEditors.SimpleButton()
        Me.KryptonPanel2 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.CalcEdit3 = New DevExpress.XtraEditors.CalcEdit()
        Me.LabelControl12 = New DevExpress.XtraEditors.LabelControl()
        Me.CalcEdit2 = New DevExpress.XtraEditors.CalcEdit()
        Me.LabelControl11 = New DevExpress.XtraEditors.LabelControl()
        Me.CalcEdit1 = New DevExpress.XtraEditors.CalcEdit()
        Me.LabelControl19 = New DevExpress.XtraEditors.LabelControl()
        Me.KryptonPanel1 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl9 = New DevExpress.XtraEditors.LabelControl()
        Me.lbUSD = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.lbEUR = New DevExpress.XtraEditors.LabelControl()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.Cancel = New DevExpress.XtraEditors.SimpleButton()
        Me.ProgressBarControl1 = New DevExpress.XtraEditors.MarqueeProgressBarControl()
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel2.SuspendLayout()
        CType(Me.CalcEdit3.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CalcEdit2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CalcEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel1.SuspendLayout()
        CType(Me.ProgressBarControl1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KryptonPanel
        '
        Me.KryptonPanel.Controls.Add(Me.OK)
        Me.KryptonPanel.Controls.Add(Me.KryptonPanel2)
        Me.KryptonPanel.Controls.Add(Me.KryptonPanel1)
        Me.KryptonPanel.Controls.Add(Me.SimpleButton1)
        Me.KryptonPanel.Controls.Add(Me.Cancel)
        Me.KryptonPanel.Controls.Add(Me.ProgressBarControl1)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.PanelBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.SeparatorLowProfile
        Me.KryptonPanel.Size = New System.Drawing.Size(519, 223)
        Me.KryptonPanel.TabIndex = 0
        '
        'OK
        '
        Me.OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OK.Appearance.Font = New System.Drawing.Font("Tahoma", 16.0!)
        Me.OK.Appearance.Options.UseFont = True
        Me.OK.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.OK.Image = CType(resources.GetObject("OK.Image"), System.Drawing.Image)
        Me.OK.Location = New System.Drawing.Point(242, 181)
        Me.OK.Name = "OK"
        Me.OK.Size = New System.Drawing.Size(128, 34)
        Me.OK.TabIndex = 0
        Me.OK.Text = "OK"
        '
        'KryptonPanel2
        '
        Me.KryptonPanel2.Controls.Add(Me.CalcEdit3)
        Me.KryptonPanel2.Controls.Add(Me.LabelControl12)
        Me.KryptonPanel2.Controls.Add(Me.CalcEdit2)
        Me.KryptonPanel2.Controls.Add(Me.LabelControl11)
        Me.KryptonPanel2.Controls.Add(Me.CalcEdit1)
        Me.KryptonPanel2.Controls.Add(Me.LabelControl19)
        Me.KryptonPanel2.Location = New System.Drawing.Point(219, 12)
        Me.KryptonPanel2.Name = "KryptonPanel2"
        Me.KryptonPanel2.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Silver
        Me.KryptonPanel2.Size = New System.Drawing.Size(288, 141)
        Me.KryptonPanel2.TabIndex = 12
        '
        'CalcEdit3
        '
        Me.CalcEdit3.Location = New System.Drawing.Point(13, 102)
        Me.CalcEdit3.Name = "CalcEdit3"
        Me.CalcEdit3.Properties.Appearance.Font = New System.Drawing.Font("Eras Demi ITC", 14.0!)
        Me.CalcEdit3.Properties.Appearance.ForeColor = System.Drawing.Color.MidnightBlue
        Me.CalcEdit3.Properties.Appearance.Options.UseFont = True
        Me.CalcEdit3.Properties.Appearance.Options.UseForeColor = True
        Me.CalcEdit3.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CalcEdit3.Size = New System.Drawing.Size(212, 30)
        Me.CalcEdit3.TabIndex = 2
        '
        'LabelControl12
        '
        Me.LabelControl12.Appearance.Font = New System.Drawing.Font("Eras Demi ITC", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl12.Appearance.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.LabelControl12.Location = New System.Drawing.Point(235, 105)
        Me.LabelControl12.Name = "LabelControl12"
        Me.LabelControl12.Size = New System.Drawing.Size(37, 23)
        Me.LabelControl12.TabIndex = 19
        Me.LabelControl12.Text = "EGP"
        '
        'CalcEdit2
        '
        Me.CalcEdit2.Location = New System.Drawing.Point(13, 57)
        Me.CalcEdit2.Name = "CalcEdit2"
        Me.CalcEdit2.Properties.Appearance.Font = New System.Drawing.Font("Eras Demi ITC", 14.0!)
        Me.CalcEdit2.Properties.Appearance.ForeColor = System.Drawing.Color.MidnightBlue
        Me.CalcEdit2.Properties.Appearance.Options.UseFont = True
        Me.CalcEdit2.Properties.Appearance.Options.UseForeColor = True
        Me.CalcEdit2.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CalcEdit2.Size = New System.Drawing.Size(212, 30)
        Me.CalcEdit2.TabIndex = 1
        '
        'LabelControl11
        '
        Me.LabelControl11.Appearance.Font = New System.Drawing.Font("Eras Demi ITC", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl11.Appearance.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.LabelControl11.Location = New System.Drawing.Point(234, 60)
        Me.LabelControl11.Name = "LabelControl11"
        Me.LabelControl11.Size = New System.Drawing.Size(38, 23)
        Me.LabelControl11.TabIndex = 17
        Me.LabelControl11.Text = "USD"
        '
        'CalcEdit1
        '
        Me.CalcEdit1.Location = New System.Drawing.Point(13, 12)
        Me.CalcEdit1.Name = "CalcEdit1"
        Me.CalcEdit1.Properties.Appearance.Font = New System.Drawing.Font("Eras Demi ITC", 14.0!)
        Me.CalcEdit1.Properties.Appearance.ForeColor = System.Drawing.Color.MidnightBlue
        Me.CalcEdit1.Properties.Appearance.Options.UseFont = True
        Me.CalcEdit1.Properties.Appearance.Options.UseForeColor = True
        Me.CalcEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CalcEdit1.Size = New System.Drawing.Size(212, 30)
        Me.CalcEdit1.TabIndex = 0
        '
        'LabelControl19
        '
        Me.LabelControl19.Appearance.Font = New System.Drawing.Font("Eras Demi ITC", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl19.Appearance.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.LabelControl19.Location = New System.Drawing.Point(234, 15)
        Me.LabelControl19.Name = "LabelControl19"
        Me.LabelControl19.Size = New System.Drawing.Size(38, 23)
        Me.LabelControl19.TabIndex = 7
        Me.LabelControl19.Text = "EUR"
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.Controls.Add(Me.LabelControl6)
        Me.KryptonPanel1.Controls.Add(Me.LabelControl7)
        Me.KryptonPanel1.Controls.Add(Me.LabelControl8)
        Me.KryptonPanel1.Controls.Add(Me.LabelControl9)
        Me.KryptonPanel1.Controls.Add(Me.lbUSD)
        Me.KryptonPanel1.Controls.Add(Me.LabelControl1)
        Me.KryptonPanel1.Controls.Add(Me.LabelControl5)
        Me.KryptonPanel1.Controls.Add(Me.LabelControl3)
        Me.KryptonPanel1.Controls.Add(Me.LabelControl2)
        Me.KryptonPanel1.Controls.Add(Me.lbEUR)
        Me.KryptonPanel1.Location = New System.Drawing.Point(12, 12)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Silver
        Me.KryptonPanel1.Size = New System.Drawing.Size(201, 141)
        Me.KryptonPanel1.TabIndex = 11
        '
        'LabelControl6
        '
        Me.LabelControl6.Appearance.Font = New System.Drawing.Font("Eras Demi ITC", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl6.Appearance.ForeColor = System.Drawing.Color.MidnightBlue
        Me.LabelControl6.Location = New System.Drawing.Point(21, 84)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(41, 23)
        Me.LabelControl6.TabIndex = 11
        Me.LabelControl6.Text = "1.00"
        '
        'LabelControl7
        '
        Me.LabelControl7.Appearance.Font = New System.Drawing.Font("Eras Demi ITC", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl7.Appearance.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.LabelControl7.Location = New System.Drawing.Point(107, 105)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(37, 23)
        Me.LabelControl7.TabIndex = 15
        Me.LabelControl7.Text = "EGP"
        '
        'LabelControl8
        '
        Me.LabelControl8.Appearance.Font = New System.Drawing.Font("Eras Demi ITC", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl8.Appearance.ForeColor = System.Drawing.Color.MidnightBlue
        Me.LabelControl8.Location = New System.Drawing.Point(79, 84)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(12, 23)
        Me.LabelControl8.TabIndex = 13
        Me.LabelControl8.Text = "="
        '
        'LabelControl9
        '
        Me.LabelControl9.Appearance.Font = New System.Drawing.Font("Eras Demi ITC", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl9.Appearance.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.LabelControl9.Location = New System.Drawing.Point(21, 105)
        Me.LabelControl9.Name = "LabelControl9"
        Me.LabelControl9.Size = New System.Drawing.Size(38, 23)
        Me.LabelControl9.TabIndex = 12
        Me.LabelControl9.Text = "USD"
        '
        'lbUSD
        '
        Me.lbUSD.Appearance.Font = New System.Drawing.Font("Eras Demi ITC", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbUSD.Appearance.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lbUSD.Location = New System.Drawing.Point(107, 84)
        Me.lbUSD.Name = "lbUSD"
        Me.lbUSD.Size = New System.Drawing.Size(12, 23)
        Me.lbUSD.TabIndex = 14
        Me.lbUSD.Text = "0"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Eras Demi ITC", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Appearance.ForeColor = System.Drawing.Color.MidnightBlue
        Me.LabelControl1.Location = New System.Drawing.Point(18, 11)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(41, 23)
        Me.LabelControl1.TabIndex = 6
        Me.LabelControl1.Text = "1.00"
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.Font = New System.Drawing.Font("Eras Demi ITC", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl5.Appearance.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.LabelControl5.Location = New System.Drawing.Point(104, 32)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(37, 23)
        Me.LabelControl5.TabIndex = 10
        Me.LabelControl5.Text = "EGP"
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Eras Demi ITC", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Appearance.ForeColor = System.Drawing.Color.MidnightBlue
        Me.LabelControl3.Location = New System.Drawing.Point(76, 11)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(12, 23)
        Me.LabelControl3.TabIndex = 8
        Me.LabelControl3.Text = "="
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Eras Demi ITC", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Appearance.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.LabelControl2.Location = New System.Drawing.Point(18, 32)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(38, 23)
        Me.LabelControl2.TabIndex = 7
        Me.LabelControl2.Text = "EUR"
        '
        'lbEUR
        '
        Me.lbEUR.Appearance.Font = New System.Drawing.Font("Eras Demi ITC", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbEUR.Appearance.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lbEUR.Location = New System.Drawing.Point(104, 11)
        Me.lbEUR.Name = "lbEUR"
        Me.lbEUR.Size = New System.Drawing.Size(12, 23)
        Me.lbEUR.TabIndex = 9
        Me.lbEUR.Text = "0"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SimpleButton1.Appearance.Font = New System.Drawing.Font("Tahoma", 16.0!)
        Me.SimpleButton1.Appearance.Options.UseFont = True
        Me.SimpleButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.SimpleButton1.Image = CType(resources.GetObject("SimpleButton1.Image"), System.Drawing.Image)
        Me.SimpleButton1.Location = New System.Drawing.Point(12, 181)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(42, 34)
        Me.SimpleButton1.TabIndex = 5
        Me.SimpleButton1.ToolTip = "Refresh"
        '
        'Cancel
        '
        Me.Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cancel.Appearance.Font = New System.Drawing.Font("Tahoma", 16.0!)
        Me.Cancel.Appearance.Options.UseFont = True
        Me.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel.Image = CType(resources.GetObject("Cancel.Image"), System.Drawing.Image)
        Me.Cancel.Location = New System.Drawing.Point(376, 181)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(128, 34)
        Me.Cancel.TabIndex = 1
        Me.Cancel.Text = "CANCEL"
        '
        'ProgressBarControl1
        '
        Me.ProgressBarControl1.EditValue = "Loading data..."
        Me.ProgressBarControl1.Location = New System.Drawing.Point(12, 157)
        Me.ProgressBarControl1.Name = "ProgressBarControl1"
        Me.ProgressBarControl1.Properties.ShowTitle = True
        Me.ProgressBarControl1.Size = New System.Drawing.Size(495, 18)
        Me.ProgressBarControl1.TabIndex = 17
        Me.ProgressBarControl1.Visible = False
        '
        'KryptonManager
        '
        Me.KryptonManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2010Silver
        '
        'BackgroundWorker1
        '
        '
        'frmRates
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel
        Me.ClientSize = New System.Drawing.Size(519, 223)
        Me.Controls.Add(Me.KryptonPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmRates"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Rates"
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        CType(Me.KryptonPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel2.ResumeLayout(False)
        Me.KryptonPanel2.PerformLayout()
        CType(Me.CalcEdit3.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CalcEdit2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CalcEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel1.ResumeLayout(False)
        Me.KryptonPanel1.PerformLayout()
        CType(Me.ProgressBarControl1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents Cancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents KryptonPanel1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbEUR As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl9 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbUSD As DevExpress.XtraEditors.LabelControl
    Friend WithEvents KryptonPanel2 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents CalcEdit3 As DevExpress.XtraEditors.CalcEdit
    Friend WithEvents LabelControl12 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents CalcEdit2 As DevExpress.XtraEditors.CalcEdit
    Friend WithEvents LabelControl11 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents CalcEdit1 As DevExpress.XtraEditors.CalcEdit
    Friend WithEvents LabelControl19 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents ProgressBarControl1 As DevExpress.XtraEditors.MarqueeProgressBarControl
    Friend WithEvents OK As DevExpress.XtraEditors.SimpleButton
End Class

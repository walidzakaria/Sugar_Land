<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDeleteSales
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
        Me.KryptonPanel8 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.btnCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.btnConfirm = New DevExpress.XtraEditors.SimpleButton()
        Me.KryptonLabel11 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.deFrom = New DevExpress.XtraEditors.DateEdit()
        Me.deTill = New DevExpress.XtraEditors.DateEdit()
        CType(Me.KryptonPanel8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel8.SuspendLayout()
        CType(Me.deFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deTill.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deTill.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KryptonPanel8
        '
        Me.KryptonPanel8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.KryptonPanel8.Controls.Add(Me.deTill)
        Me.KryptonPanel8.Controls.Add(Me.deFrom)
        Me.KryptonPanel8.Controls.Add(Me.KryptonLabel1)
        Me.KryptonPanel8.Controls.Add(Me.btnCancel)
        Me.KryptonPanel8.Controls.Add(Me.btnConfirm)
        Me.KryptonPanel8.Controls.Add(Me.KryptonLabel11)
        Me.KryptonPanel8.Location = New System.Drawing.Point(14, 13)
        Me.KryptonPanel8.Margin = New System.Windows.Forms.Padding(4)
        Me.KryptonPanel8.Name = "KryptonPanel8"
        Me.KryptonPanel8.Size = New System.Drawing.Size(338, 151)
        Me.KryptonPanel8.TabIndex = 0
        '
        'btnCancel
        '
        Me.btnCancel.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.btnCancel.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnCancel.Appearance.Options.UseFont = True
        Me.btnCancel.Appearance.Options.UseForeColor = True
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(28, 103)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(124, 32)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "Close"
        '
        'btnConfirm
        '
        Me.btnConfirm.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.btnConfirm.Appearance.ForeColor = System.Drawing.Color.Red
        Me.btnConfirm.Appearance.Options.UseFont = True
        Me.btnConfirm.Appearance.Options.UseForeColor = True
        Me.btnConfirm.Location = New System.Drawing.Point(160, 103)
        Me.btnConfirm.Margin = New System.Windows.Forms.Padding(4)
        Me.btnConfirm.Name = "btnConfirm"
        Me.btnConfirm.Size = New System.Drawing.Size(124, 32)
        Me.btnConfirm.TabIndex = 2
        Me.btnConfirm.Text = "Confirm"
        '
        'KryptonLabel11
        '
        Me.KryptonLabel11.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel
        Me.KryptonLabel11.Location = New System.Drawing.Point(27, 25)
        Me.KryptonLabel11.Margin = New System.Windows.Forms.Padding(4)
        Me.KryptonLabel11.Name = "KryptonLabel11"
        Me.KryptonLabel11.Size = New System.Drawing.Size(94, 24)
        Me.KryptonLabel11.StateCommon.ShortText.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.KryptonLabel11.StateCommon.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Far
        Me.KryptonLabel11.StateCommon.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near
        Me.KryptonLabel11.TabIndex = 62
        Me.KryptonLabel11.Values.Text = "Date From:"
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel
        Me.KryptonLabel1.Location = New System.Drawing.Point(27, 57)
        Me.KryptonLabel1.Margin = New System.Windows.Forms.Padding(4)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Size = New System.Drawing.Size(78, 24)
        Me.KryptonLabel1.StateCommon.ShortText.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.KryptonLabel1.StateCommon.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Far
        Me.KryptonLabel1.StateCommon.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near
        Me.KryptonLabel1.TabIndex = 63
        Me.KryptonLabel1.Values.Text = "Date Till:"
        '
        'deFrom
        '
        Me.deFrom.EditValue = Nothing
        Me.deFrom.Location = New System.Drawing.Point(128, 23)
        Me.deFrom.Name = "deFrom"
        Me.deFrom.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.deFrom.Properties.Appearance.Options.UseFont = True
        Me.deFrom.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deFrom.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deFrom.Size = New System.Drawing.Size(159, 26)
        Me.deFrom.TabIndex = 64
        '
        'deTill
        '
        Me.deTill.EditValue = Nothing
        Me.deTill.Location = New System.Drawing.Point(128, 55)
        Me.deTill.Name = "deTill"
        Me.deTill.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.deTill.Properties.Appearance.Options.UseFont = True
        Me.deTill.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deTill.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deTill.Size = New System.Drawing.Size(159, 26)
        Me.deTill.TabIndex = 65
        '
        'frmDeleteSales
        '
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(365, 174)
        Me.Controls.Add(Me.KryptonPanel8)
        Me.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDeleteSales"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Delete Sales"
        CType(Me.KryptonPanel8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel8.ResumeLayout(False)
        Me.KryptonPanel8.PerformLayout()
        CType(Me.deFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deTill.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deTill.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents KryptonPanel8 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Public WithEvents KryptonLabel11 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Public WithEvents btnCancel As DevExpress.XtraEditors.SimpleButton
    Public WithEvents btnConfirm As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents deFrom As DevExpress.XtraEditors.DateEdit
    Public WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents deTill As DevExpress.XtraEditors.DateEdit
End Class

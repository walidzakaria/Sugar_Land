<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPassKey
    Inherits DevExpress.XtraSplashScreen.SplashScreen

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.btnOK = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.txtNewPassword = New DevExpress.XtraEditors.TextEdit()
        Me.txtOldPassword = New DevExpress.XtraEditors.TextEdit()
        Me.txtRetype = New DevExpress.XtraEditors.TextEdit()
        CType(Me.txtNewPassword.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtOldPassword.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRetype.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Appearance.ForeColor = System.Drawing.Color.Red
        Me.btnCancel.Appearance.Options.UseFont = True
        Me.btnCancel.Appearance.Options.UseForeColor = True
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(386, 161)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(106, 32)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "Cancel"
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOK.Appearance.ForeColor = System.Drawing.Color.Green
        Me.btnOK.Appearance.Options.UseFont = True
        Me.btnOK.Appearance.Options.UseForeColor = True
        Me.btnOK.Location = New System.Drawing.Point(187, 161)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(193, 32)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "OK"
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.LabelControl2.Appearance.Options.UseFont = True
        Me.LabelControl2.Location = New System.Drawing.Point(37, 88)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(103, 19)
        Me.LabelControl2.TabIndex = 17
        Me.LabelControl2.Text = "New Pass Key:"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.LabelControl1.Appearance.Options.UseFont = True
        Me.LabelControl1.Location = New System.Drawing.Point(37, 38)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(97, 19)
        Me.LabelControl1.TabIndex = 16
        Me.LabelControl1.Text = "Old Pass Key:"
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.LabelControl3.Appearance.Options.UseFont = True
        Me.LabelControl3.Location = New System.Drawing.Point(37, 125)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(54, 19)
        Me.LabelControl3.TabIndex = 18
        Me.LabelControl3.Text = "Retype:"
        '
        'txtNewPassword
        '
        Me.txtNewPassword.EnterMoveNextControl = True
        Me.txtNewPassword.Location = New System.Drawing.Point(169, 81)
        Me.txtNewPassword.Name = "txtNewPassword"
        Me.txtNewPassword.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtNewPassword.Properties.Appearance.Options.UseFont = True
        Me.txtNewPassword.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.txtNewPassword.Properties.Mask.EditMask = "[0-9]+"
        Me.txtNewPassword.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx
        Me.txtNewPassword.Size = New System.Drawing.Size(323, 30)
        Me.txtNewPassword.TabIndex = 20
        '
        'txtOldPassword
        '
        Me.txtOldPassword.EnterMoveNextControl = True
        Me.txtOldPassword.Location = New System.Drawing.Point(169, 36)
        Me.txtOldPassword.Name = "txtOldPassword"
        Me.txtOldPassword.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtOldPassword.Properties.Appearance.Options.UseFont = True
        Me.txtOldPassword.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.txtOldPassword.Properties.Mask.EditMask = "[0-9]+"
        Me.txtOldPassword.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx
        Me.txtOldPassword.Properties.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtOldPassword.Size = New System.Drawing.Size(323, 30)
        Me.txtOldPassword.TabIndex = 19
        '
        'txtRetype
        '
        Me.txtRetype.EnterMoveNextControl = True
        Me.txtRetype.Location = New System.Drawing.Point(169, 118)
        Me.txtRetype.Name = "txtRetype"
        Me.txtRetype.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtRetype.Properties.Appearance.Options.UseFont = True
        Me.txtRetype.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.txtRetype.Properties.Mask.EditMask = "[0-9]+"
        Me.txtRetype.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx
        Me.txtRetype.Size = New System.Drawing.Size(323, 30)
        Me.txtRetype.TabIndex = 21
        '
        'frmPassKey
        '
        Me.AllowControlsInImageMode = True
        Me.AutoFitImage = False
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(536, 217)
        Me.Controls.Add(Me.txtRetype)
        Me.Controls.Add(Me.txtNewPassword)
        Me.Controls.Add(Me.txtOldPassword)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Name = "frmPassKey"
        Me.ShowMode = DevExpress.XtraSplashScreen.ShowMode.Image
        Me.Text = "Login"
        CType(Me.txtNewPassword.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtOldPassword.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRetype.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnOK As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtNewPassword As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtOldPassword As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtRetype As DevExpress.XtraEditors.TextEdit
End Class

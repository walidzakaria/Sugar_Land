<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCurrency
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCurrency))
        Me.LabelControl19 = New DevExpress.XtraEditors.LabelControl()
        Me.OK = New DevExpress.XtraEditors.SimpleButton()
        Me.Cancel = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.txtEUR = New DevExpress.XtraEditors.TextEdit()
        Me.txtEGP = New DevExpress.XtraEditors.TextEdit()
        Me.txtGBP = New DevExpress.XtraEditors.TextEdit()
        Me.txtRUB = New DevExpress.XtraEditors.TextEdit()
        Me.txtUAH = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.lblLastUpdate = New DevExpress.XtraEditors.LabelControl()
        Me.lblUser = New DevExpress.XtraEditors.LabelControl()
        CType(Me.txtEUR.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEGP.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtGBP.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRUB.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUAH.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl19
        '
        Me.LabelControl19.Appearance.Font = New System.Drawing.Font("Eras Demi ITC", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl19.Appearance.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.LabelControl19.Location = New System.Drawing.Point(27, 15)
        Me.LabelControl19.Name = "LabelControl19"
        Me.LabelControl19.Size = New System.Drawing.Size(38, 23)
        Me.LabelControl19.TabIndex = 8
        Me.LabelControl19.Text = "EUR"
        '
        'OK
        '
        Me.OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OK.Appearance.Font = New System.Drawing.Font("Tahoma", 16.0!)
        Me.OK.Appearance.Options.UseFont = True
        Me.OK.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.OK.Image = CType(resources.GetObject("OK.Image"), System.Drawing.Image)
        Me.OK.Location = New System.Drawing.Point(456, 172)
        Me.OK.Name = "OK"
        Me.OK.Size = New System.Drawing.Size(128, 34)
        Me.OK.TabIndex = 5
        Me.OK.Text = "OK"
        '
        'Cancel
        '
        Me.Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cancel.Appearance.Font = New System.Drawing.Font("Tahoma", 16.0!)
        Me.Cancel.Appearance.Options.UseFont = True
        Me.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel.Image = CType(resources.GetObject("Cancel.Image"), System.Drawing.Image)
        Me.Cancel.Location = New System.Drawing.Point(590, 172)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(128, 34)
        Me.Cancel.TabIndex = 6
        Me.Cancel.Text = "CANCEL"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Eras Demi ITC", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Appearance.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.LabelControl1.Location = New System.Drawing.Point(27, 51)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(37, 23)
        Me.LabelControl1.TabIndex = 11
        Me.LabelControl1.Text = "EGP"
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Eras Demi ITC", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Appearance.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.LabelControl3.Location = New System.Drawing.Point(27, 159)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(43, 23)
        Me.LabelControl3.TabIndex = 15
        Me.LabelControl3.Text = "UAH"
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Eras Demi ITC", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl4.Appearance.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.LabelControl4.Location = New System.Drawing.Point(27, 123)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(38, 23)
        Me.LabelControl4.TabIndex = 14
        Me.LabelControl4.Text = "RUB"
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.Font = New System.Drawing.Font("Eras Demi ITC", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl5.Appearance.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.LabelControl5.Location = New System.Drawing.Point(27, 87)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(37, 23)
        Me.LabelControl5.TabIndex = 13
        Me.LabelControl5.Text = "GBP"
        '
        'txtEUR
        '
        Me.txtEUR.EnterMoveNextControl = True
        Me.txtEUR.Location = New System.Drawing.Point(90, 12)
        Me.txtEUR.Name = "txtEUR"
        Me.txtEUR.Properties.Appearance.Font = New System.Drawing.Font("Eras Demi ITC", 14.0!)
        Me.txtEUR.Properties.Appearance.Options.UseFont = True
        Me.txtEUR.Size = New System.Drawing.Size(178, 30)
        Me.txtEUR.TabIndex = 0
        '
        'txtEGP
        '
        Me.txtEGP.EnterMoveNextControl = True
        Me.txtEGP.Location = New System.Drawing.Point(90, 48)
        Me.txtEGP.Name = "txtEGP"
        Me.txtEGP.Properties.Appearance.Font = New System.Drawing.Font("Eras Demi ITC", 14.0!)
        Me.txtEGP.Properties.Appearance.Options.UseFont = True
        Me.txtEGP.Size = New System.Drawing.Size(178, 30)
        Me.txtEGP.TabIndex = 1
        '
        'txtGBP
        '
        Me.txtGBP.EnterMoveNextControl = True
        Me.txtGBP.Location = New System.Drawing.Point(90, 84)
        Me.txtGBP.Name = "txtGBP"
        Me.txtGBP.Properties.Appearance.Font = New System.Drawing.Font("Eras Demi ITC", 14.0!)
        Me.txtGBP.Properties.Appearance.Options.UseFont = True
        Me.txtGBP.Size = New System.Drawing.Size(178, 30)
        Me.txtGBP.TabIndex = 2
        '
        'txtRUB
        '
        Me.txtRUB.EnterMoveNextControl = True
        Me.txtRUB.Location = New System.Drawing.Point(90, 120)
        Me.txtRUB.Name = "txtRUB"
        Me.txtRUB.Properties.Appearance.Font = New System.Drawing.Font("Eras Demi ITC", 14.0!)
        Me.txtRUB.Properties.Appearance.Options.UseFont = True
        Me.txtRUB.Size = New System.Drawing.Size(178, 30)
        Me.txtRUB.TabIndex = 3
        '
        'txtUAH
        '
        Me.txtUAH.EnterMoveNextControl = True
        Me.txtUAH.Location = New System.Drawing.Point(90, 156)
        Me.txtUAH.Name = "txtUAH"
        Me.txtUAH.Properties.Appearance.Font = New System.Drawing.Font("Eras Demi ITC", 14.0!)
        Me.txtUAH.Properties.Appearance.Options.UseFont = True
        Me.txtUAH.Size = New System.Drawing.Size(178, 30)
        Me.txtUAH.TabIndex = 4
        '
        'LabelControl6
        '
        Me.LabelControl6.Appearance.Font = New System.Drawing.Font("Eras Demi ITC", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl6.Appearance.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.LabelControl6.Location = New System.Drawing.Point(354, 15)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(113, 23)
        Me.LabelControl6.TabIndex = 21
        Me.LabelControl6.Text = "Last Update:"
        '
        'LabelControl7
        '
        Me.LabelControl7.Appearance.Font = New System.Drawing.Font("Eras Demi ITC", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl7.Appearance.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.LabelControl7.Location = New System.Drawing.Point(354, 51)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(45, 23)
        Me.LabelControl7.TabIndex = 22
        Me.LabelControl7.Text = "User:"
        '
        'lblLastUpdate
        '
        Me.lblLastUpdate.Appearance.Font = New System.Drawing.Font("Eras Demi ITC", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLastUpdate.Appearance.ForeColor = System.Drawing.Color.Black
        Me.lblLastUpdate.Location = New System.Drawing.Point(482, 15)
        Me.lblLastUpdate.Name = "lblLastUpdate"
        Me.lblLastUpdate.Size = New System.Drawing.Size(113, 23)
        Me.lblLastUpdate.TabIndex = 23
        Me.lblLastUpdate.Text = "Last Update:"
        '
        'lblUser
        '
        Me.lblUser.Appearance.Font = New System.Drawing.Font("Eras Demi ITC", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUser.Appearance.ForeColor = System.Drawing.Color.Black
        Me.lblUser.Location = New System.Drawing.Point(482, 51)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(91, 23)
        Me.lblUser.TabIndex = 24
        Me.lblUser.Text = "Username"
        '
        'frmCurrency
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel
        Me.ClientSize = New System.Drawing.Size(768, 218)
        Me.Controls.Add(Me.lblUser)
        Me.Controls.Add(Me.lblLastUpdate)
        Me.Controls.Add(Me.LabelControl7)
        Me.Controls.Add(Me.LabelControl6)
        Me.Controls.Add(Me.txtUAH)
        Me.Controls.Add(Me.txtRUB)
        Me.Controls.Add(Me.txtGBP)
        Me.Controls.Add(Me.txtEGP)
        Me.Controls.Add(Me.txtEUR)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.LabelControl5)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.OK)
        Me.Controls.Add(Me.Cancel)
        Me.Controls.Add(Me.LabelControl19)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.LookAndFeel.SkinName = "Office 2013"
        Me.MaximizeBox = False
        Me.Name = "frmCurrency"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Currency"
        CType(Me.txtEUR.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEGP.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtGBP.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRUB.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUAH.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabelControl19 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents OK As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Cancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtEUR As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtEGP As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtGBP As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtRUB As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtUAH As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblLastUpdate As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblUser As DevExpress.XtraEditors.LabelControl
End Class

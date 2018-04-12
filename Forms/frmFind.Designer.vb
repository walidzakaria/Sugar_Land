<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFind
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
        Me.ListBoxControl1 = New DevExpress.XtraEditors.ListBoxControl()
        CType(Me.ListBoxControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ListBoxControl1
        '
        Me.ListBoxControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBoxControl1.Appearance.Options.UseFont = True
        Me.ListBoxControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.ListBoxControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListBoxControl1.Location = New System.Drawing.Point(0, 0)
        Me.ListBoxControl1.Name = "ListBoxControl1"
        Me.ListBoxControl1.Size = New System.Drawing.Size(184, 223)
        Me.ListBoxControl1.TabIndex = 0
        '
        'frmFind
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(184, 223)
        Me.Controls.Add(Me.ListBoxControl1)
        Me.Name = "frmFind"
        Me.Text = "Form1"
        CType(Me.ListBoxControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ListBoxControl1 As DevExpress.XtraEditors.ListBoxControl
End Class

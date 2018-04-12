<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBarcode
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBarcode))
        Me.KryptonPanel = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonPanel13 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.iDgv = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.Item = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ItemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Qnty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KryptonPanel10 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.KryptonLabel3 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel2 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.iVendor = New System.Windows.Forms.ComboBox()
        Me.KryptonLabel36 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel55 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.FlowLayoutPanel26 = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnPrintA4 = New DevExpress.XtraEditors.SimpleButton()
        Me.iSerial = New System.Windows.Forms.ComboBox()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnPrintLabels = New DevExpress.XtraEditors.SimpleButton()
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnPrintBadge = New DevExpress.XtraEditors.SimpleButton()
        Me.NumericUpDown2 = New System.Windows.Forms.NumericUpDown()
        Me.FlowLayoutPanel3 = New System.Windows.Forms.FlowLayoutPanel()
        Me.CheckEdit1 = New DevExpress.XtraEditors.CheckEdit()
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        CType(Me.KryptonPanel13, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel13.SuspendLayout()
        CType(Me.iDgv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPanel10, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel10.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.FlowLayoutPanel26.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlowLayoutPanel2.SuspendLayout()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CheckEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KryptonPanel
        '
        Me.KryptonPanel.Controls.Add(Me.KryptonPanel13)
        Me.KryptonPanel.Controls.Add(Me.KryptonPanel10)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.KryptonPanel.Size = New System.Drawing.Size(735, 406)
        Me.KryptonPanel.TabIndex = 0
        '
        'KryptonPanel13
        '
        Me.KryptonPanel13.Controls.Add(Me.iDgv)
        Me.KryptonPanel13.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel13.Location = New System.Drawing.Point(296, 0)
        Me.KryptonPanel13.Name = "KryptonPanel13"
        Me.KryptonPanel13.Padding = New System.Windows.Forms.Padding(10, 14, 10, 10)
        Me.KryptonPanel13.Size = New System.Drawing.Size(439, 406)
        Me.KryptonPanel13.TabIndex = 7
        '
        'iDgv
        '
        Me.iDgv.AllowUserToAddRows = False
        Me.iDgv.AllowUserToDeleteRows = False
        Me.iDgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.iDgv.ColumnHeadersHeight = 40
        Me.iDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Item, Me.ItemName, Me.Qnty, Me.Column1})
        Me.iDgv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.iDgv.Location = New System.Drawing.Point(10, 14)
        Me.iDgv.Name = "iDgv"
        Me.iDgv.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.iDgv.Size = New System.Drawing.Size(419, 382)
        Me.iDgv.TabIndex = 15
        Me.iDgv.TabStop = False
        '
        'Item
        '
        Me.Item.HeaderText = "Code"
        Me.Item.Name = "Item"
        Me.Item.ReadOnly = True
        Me.Item.Width = 64
        '
        'ItemName
        '
        Me.ItemName.HeaderText = "Item"
        Me.ItemName.Name = "ItemName"
        Me.ItemName.ReadOnly = True
        Me.ItemName.Width = 60
        '
        'Qnty
        '
        Me.Qnty.HeaderText = "Qnty"
        Me.Qnty.Name = "Qnty"
        Me.Qnty.Width = 62
        '
        'Column1
        '
        Me.Column1.HeaderText = "Price"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 62
        '
        'KryptonPanel10
        '
        Me.KryptonPanel10.Controls.Add(Me.TableLayoutPanel2)
        Me.KryptonPanel10.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonPanel10.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel10.Name = "KryptonPanel10"
        Me.KryptonPanel10.Padding = New System.Windows.Forms.Padding(10, 14, 10, 10)
        Me.KryptonPanel10.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Blue
        Me.KryptonPanel10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.KryptonPanel10.Size = New System.Drawing.Size(296, 406)
        Me.KryptonPanel10.TabIndex = 6
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.KryptonLabel3, 0, 6)
        Me.TableLayoutPanel2.Controls.Add(Me.KryptonLabel2, 0, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.iVendor, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.KryptonLabel36, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.KryptonLabel55, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.FlowLayoutPanel26, 1, 9)
        Me.TableLayoutPanel2.Controls.Add(Me.iSerial, 1, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.FlowLayoutPanel1, 1, 10)
        Me.TableLayoutPanel2.Controls.Add(Me.NumericUpDown1, 1, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.FlowLayoutPanel2, 1, 11)
        Me.TableLayoutPanel2.Controls.Add(Me.NumericUpDown2, 1, 6)
        Me.TableLayoutPanel2.Controls.Add(Me.FlowLayoutPanel3, 0, 9)
        Me.TableLayoutPanel2.Controls.Add(Me.CheckEdit1, 1, 8)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.TableLayoutPanel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(10, 14)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 12
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(279, 382)
        Me.TableLayoutPanel2.TabIndex = 1
        '
        'KryptonLabel3
        '
        Me.KryptonLabel3.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonLabel3.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel
        Me.KryptonLabel3.Location = New System.Drawing.Point(3, 92)
        Me.KryptonLabel3.Name = "KryptonLabel3"
        Me.KryptonLabel3.Size = New System.Drawing.Size(56, 23)
        Me.KryptonLabel3.StateCommon.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Far
        Me.KryptonLabel3.TabIndex = 12
        Me.KryptonLabel3.Values.Text = "Column:"
        '
        'KryptonLabel2
        '
        Me.KryptonLabel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonLabel2.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel
        Me.KryptonLabel2.Location = New System.Drawing.Point(24, 63)
        Me.KryptonLabel2.Name = "KryptonLabel2"
        Me.KryptonLabel2.Size = New System.Drawing.Size(35, 23)
        Me.KryptonLabel2.StateCommon.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Far
        Me.KryptonLabel2.TabIndex = 10
        Me.KryptonLabel2.Values.Text = "Line:"
        '
        'iVendor
        '
        Me.iVendor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.iVendor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.iVendor.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.iVendor.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.iVendor.FormattingEnabled = True
        Me.iVendor.Location = New System.Drawing.Point(65, 3)
        Me.iVendor.Name = "iVendor"
        Me.iVendor.Size = New System.Drawing.Size(189, 24)
        Me.iVendor.TabIndex = 0
        Me.iVendor.TabStop = False
        '
        'KryptonLabel36
        '
        Me.KryptonLabel36.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonLabel36.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel
        Me.KryptonLabel36.Location = New System.Drawing.Point(3, 7)
        Me.KryptonLabel36.Name = "KryptonLabel36"
        Me.KryptonLabel36.Size = New System.Drawing.Size(56, 20)
        Me.KryptonLabel36.StateCommon.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Far
        Me.KryptonLabel36.TabIndex = 6
        Me.KryptonLabel36.Values.Text = "Vendor:"
        '
        'KryptonLabel55
        '
        Me.KryptonLabel55.Dock = System.Windows.Forms.DockStyle.Right
        Me.KryptonLabel55.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel
        Me.KryptonLabel55.Location = New System.Drawing.Point(7, 33)
        Me.KryptonLabel55.Name = "KryptonLabel55"
        Me.KryptonLabel55.Size = New System.Drawing.Size(52, 24)
        Me.KryptonLabel55.StateCommon.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Far
        Me.KryptonLabel55.TabIndex = 4
        Me.KryptonLabel55.Values.Text = "Invoice:"
        '
        'FlowLayoutPanel26
        '
        Me.FlowLayoutPanel26.AutoSize = True
        Me.FlowLayoutPanel26.Controls.Add(Me.btnPrintA4)
        Me.FlowLayoutPanel26.Location = New System.Drawing.Point(62, 149)
        Me.FlowLayoutPanel26.Margin = New System.Windows.Forms.Padding(0)
        Me.FlowLayoutPanel26.Name = "FlowLayoutPanel26"
        Me.FlowLayoutPanel26.Padding = New System.Windows.Forms.Padding(0, 13, 0, 0)
        Me.FlowLayoutPanel26.Size = New System.Drawing.Size(195, 50)
        Me.FlowLayoutPanel26.TabIndex = 5
        '
        'btnPrintA4
        '
        Me.btnPrintA4.ImageOptions.Image = CType(resources.GetObject("btnPrintA4.ImageOptions.Image"), System.Drawing.Image)
        Me.btnPrintA4.Location = New System.Drawing.Point(3, 16)
        Me.btnPrintA4.Name = "btnPrintA4"
        Me.btnPrintA4.Size = New System.Drawing.Size(189, 31)
        Me.btnPrintA4.TabIndex = 0
        Me.btnPrintA4.Text = "Print Poster"
        '
        'iSerial
        '
        Me.iSerial.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.iSerial.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.iSerial.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.iSerial.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.iSerial.FormattingEnabled = True
        Me.iSerial.Location = New System.Drawing.Point(65, 33)
        Me.iSerial.Name = "iSerial"
        Me.iSerial.Size = New System.Drawing.Size(189, 24)
        Me.iSerial.TabIndex = 1
        Me.iSerial.TabStop = False
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoSize = True
        Me.FlowLayoutPanel1.Controls.Add(Me.btnPrintLabels)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(62, 200)
        Me.FlowLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Padding = New System.Windows.Forms.Padding(0, 13, 0, 0)
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(195, 50)
        Me.FlowLayoutPanel1.TabIndex = 7
        '
        'btnPrintLabels
        '
        Me.btnPrintLabels.ImageOptions.Image = CType(resources.GetObject("btnPrintLabels.ImageOptions.Image"), System.Drawing.Image)
        Me.btnPrintLabels.Location = New System.Drawing.Point(3, 16)
        Me.btnPrintLabels.Name = "btnPrintLabels"
        Me.btnPrintLabels.Size = New System.Drawing.Size(189, 31)
        Me.btnPrintLabels.TabIndex = 0
        Me.btnPrintLabels.Text = "Print Roll"
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.NumericUpDown1.Location = New System.Drawing.Point(65, 63)
        Me.NumericUpDown1.Maximum = New Decimal(New Integer() {12, 0, 0, 0})
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(120, 23)
        Me.NumericUpDown1.TabIndex = 2
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.AutoSize = True
        Me.FlowLayoutPanel2.Controls.Add(Me.btnPrintBadge)
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(62, 252)
        Me.FlowLayoutPanel2.Margin = New System.Windows.Forms.Padding(0)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Padding = New System.Windows.Forms.Padding(0, 13, 0, 0)
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(195, 50)
        Me.FlowLayoutPanel2.TabIndex = 11
        '
        'btnPrintBadge
        '
        Me.btnPrintBadge.ImageOptions.Image = CType(resources.GetObject("btnPrintBadge.ImageOptions.Image"), System.Drawing.Image)
        Me.btnPrintBadge.Location = New System.Drawing.Point(3, 16)
        Me.btnPrintBadge.Name = "btnPrintBadge"
        Me.btnPrintBadge.Size = New System.Drawing.Size(189, 31)
        Me.btnPrintBadge.TabIndex = 0
        Me.btnPrintBadge.Text = "Print Label"
        '
        'NumericUpDown2
        '
        Me.NumericUpDown2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.NumericUpDown2.Location = New System.Drawing.Point(65, 92)
        Me.NumericUpDown2.Maximum = New Decimal(New Integer() {4, 0, 0, 0})
        Me.NumericUpDown2.Name = "NumericUpDown2"
        Me.NumericUpDown2.Size = New System.Drawing.Size(120, 23)
        Me.NumericUpDown2.TabIndex = 3
        '
        'FlowLayoutPanel3
        '
        Me.FlowLayoutPanel3.AutoSize = True
        Me.FlowLayoutPanel3.Location = New System.Drawing.Point(0, 149)
        Me.FlowLayoutPanel3.Margin = New System.Windows.Forms.Padding(0)
        Me.FlowLayoutPanel3.Name = "FlowLayoutPanel3"
        Me.FlowLayoutPanel3.Size = New System.Drawing.Size(0, 0)
        Me.FlowLayoutPanel3.TabIndex = 5
        '
        'CheckEdit1
        '
        Me.CheckEdit1.Location = New System.Drawing.Point(65, 121)
        Me.CheckEdit1.Name = "CheckEdit1"
        Me.CheckEdit1.Properties.Caption = "Package Codes"
        Me.CheckEdit1.Size = New System.Drawing.Size(120, 20)
        Me.CheckEdit1.TabIndex = 13
        '
        'KryptonManager
        '
        Me.KryptonManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2010Silver
        '
        'frmBarcode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(735, 406)
        Me.Controls.Add(Me.KryptonPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmBarcode"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Barcode"
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        CType(Me.KryptonPanel13, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel13.ResumeLayout(False)
        CType(Me.iDgv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPanel10, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel10.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.FlowLayoutPanel26.ResumeLayout(False)
        Me.FlowLayoutPanel1.ResumeLayout(False)
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlowLayoutPanel2.ResumeLayout(False)
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CheckEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
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
    Private WithEvents KryptonPanel10 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Private WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Private WithEvents KryptonLabel36 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Private WithEvents KryptonLabel55 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Private WithEvents FlowLayoutPanel3 As System.Windows.Forms.FlowLayoutPanel
    Private WithEvents FlowLayoutPanel26 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnPrintA4 As DevExpress.XtraEditors.SimpleButton
    Private WithEvents KryptonPanel13 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents iVendor As System.Windows.Forms.ComboBox
    Friend WithEvents iSerial As System.Windows.Forms.ComboBox
    Private WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnPrintLabels As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents iDgv As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Private WithEvents KryptonLabel2 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents NumericUpDown2 As System.Windows.Forms.NumericUpDown
    Private WithEvents FlowLayoutPanel2 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnPrintBadge As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Item As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Qnty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents KryptonLabel3 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents CheckEdit1 As DevExpress.XtraEditors.CheckEdit
End Class

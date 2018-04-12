<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImport
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.KryptonPanel = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonListBox2 = New ComponentFactory.Krypton.Toolkit.KryptonListBox()
        Me.KryptonTextBox2 = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonWrapLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonWrapLabel()
        Me.KryptonButton4 = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonListBox1 = New ComponentFactory.Krypton.Toolkit.KryptonListBox()
        Me.KryptonTextBox1 = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonButton1 = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonButton2 = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonButton3 = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        Me.oDgv = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        CType(Me.oDgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KryptonPanel
        '
        Me.KryptonPanel.Controls.Add(Me.oDgv)
        Me.KryptonPanel.Controls.Add(Me.KryptonListBox2)
        Me.KryptonPanel.Controls.Add(Me.KryptonTextBox2)
        Me.KryptonPanel.Controls.Add(Me.KryptonWrapLabel1)
        Me.KryptonPanel.Controls.Add(Me.KryptonButton4)
        Me.KryptonPanel.Controls.Add(Me.KryptonListBox1)
        Me.KryptonPanel.Controls.Add(Me.KryptonTextBox1)
        Me.KryptonPanel.Controls.Add(Me.KryptonButton1)
        Me.KryptonPanel.Controls.Add(Me.KryptonButton2)
        Me.KryptonPanel.Controls.Add(Me.KryptonButton3)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Size = New System.Drawing.Size(867, 327)
        Me.KryptonPanel.TabIndex = 0
        '
        'KryptonListBox2
        '
        Me.KryptonListBox2.Location = New System.Drawing.Point(596, 3)
        Me.KryptonListBox2.Name = "KryptonListBox2"
        Me.KryptonListBox2.Size = New System.Drawing.Size(259, 280)
        Me.KryptonListBox2.TabIndex = 10
        '
        'KryptonTextBox2
        '
        Me.KryptonTextBox2.Location = New System.Drawing.Point(24, 295)
        Me.KryptonTextBox2.Name = "KryptonTextBox2"
        Me.KryptonTextBox2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.KryptonTextBox2.Size = New System.Drawing.Size(256, 20)
        Me.KryptonTextBox2.TabIndex = 8
        Me.KryptonTextBox2.UseSystemPasswordChar = True
        '
        'KryptonWrapLabel1
        '
        Me.KryptonWrapLabel1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.KryptonWrapLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.KryptonWrapLabel1.Location = New System.Drawing.Point(389, 286)
        Me.KryptonWrapLabel1.Name = "KryptonWrapLabel1"
        Me.KryptonWrapLabel1.Size = New System.Drawing.Size(205, 15)
        Me.KryptonWrapLabel1.Text = "Serial - Name - Price - Qnty - Vendors"
        '
        'KryptonButton4
        '
        Me.KryptonButton4.Enabled = False
        Me.KryptonButton4.Location = New System.Drawing.Point(24, 238)
        Me.KryptonButton4.Name = "KryptonButton4"
        Me.KryptonButton4.Size = New System.Drawing.Size(90, 25)
        Me.KryptonButton4.TabIndex = 6
        Me.KryptonButton4.Values.Text = "In"
        '
        'KryptonListBox1
        '
        Me.KryptonListBox1.Location = New System.Drawing.Point(135, 3)
        Me.KryptonListBox1.Name = "KryptonListBox1"
        Me.KryptonListBox1.Size = New System.Drawing.Size(459, 280)
        Me.KryptonListBox1.TabIndex = 1
        '
        'KryptonTextBox1
        '
        Me.KryptonTextBox1.Location = New System.Drawing.Point(396, 26)
        Me.KryptonTextBox1.Multiline = True
        Me.KryptonTextBox1.Name = "KryptonTextBox1"
        Me.KryptonTextBox1.Size = New System.Drawing.Size(180, 66)
        Me.KryptonTextBox1.TabIndex = 2
        Me.KryptonTextBox1.Text = "KryptonTextBox1"
        '
        'KryptonButton1
        '
        Me.KryptonButton1.Location = New System.Drawing.Point(24, 207)
        Me.KryptonButton1.Name = "KryptonButton1"
        Me.KryptonButton1.Size = New System.Drawing.Size(90, 25)
        Me.KryptonButton1.TabIndex = 3
        Me.KryptonButton1.Values.Text = "Item"
        '
        'KryptonButton2
        '
        Me.KryptonButton2.Enabled = False
        Me.KryptonButton2.Location = New System.Drawing.Point(24, 176)
        Me.KryptonButton2.Name = "KryptonButton2"
        Me.KryptonButton2.Size = New System.Drawing.Size(90, 25)
        Me.KryptonButton2.TabIndex = 4
        Me.KryptonButton2.Values.Text = "Vendor"
        '
        'KryptonButton3
        '
        Me.KryptonButton3.Location = New System.Drawing.Point(24, 145)
        Me.KryptonButton3.Name = "KryptonButton3"
        Me.KryptonButton3.Size = New System.Drawing.Size(90, 25)
        Me.KryptonButton3.TabIndex = 5
        Me.KryptonButton3.Values.Text = "Import"
        '
        'KryptonManager
        '
        Me.KryptonManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2010Silver
        '
        'oDgv
        '
        Me.oDgv.AllowUserToAddRows = False
        Me.oDgv.AllowUserToDeleteRows = False
        Me.oDgv.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Teal
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Teal
        Me.oDgv.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.oDgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.oDgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.oDgv.ColumnHeadersHeight = 60
        Me.oDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7, Me.Column8, Me.Column9})
        Me.oDgv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.oDgv.GridStyles.Style = ComponentFactory.Krypton.Toolkit.DataGridViewStyle.Mixed
        Me.oDgv.GridStyles.StyleBackground = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.ContextMenuHeading
        Me.oDgv.GridStyles.StyleColumn = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet
        Me.oDgv.GridStyles.StyleDataCells = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet
        Me.oDgv.GridStyles.StyleRow = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet
        Me.oDgv.Location = New System.Drawing.Point(0, 0)
        Me.oDgv.Name = "oDgv"
        Me.oDgv.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Silver
        Me.oDgv.ReadOnly = True
        Me.oDgv.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.oDgv.RowHeadersVisible = False
        Me.oDgv.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.oDgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.oDgv.Size = New System.Drawing.Size(867, 327)
        Me.oDgv.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.ContextMenuHeading
        Me.oDgv.StateCommon.DataCell.Back.Color1 = System.Drawing.Color.White
        Me.oDgv.StateCommon.DataCell.Back.Color2 = System.Drawing.Color.White
        Me.oDgv.StateCommon.DataCell.Content.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.oDgv.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.Gray
        Me.oDgv.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.Color.Gray
        Me.oDgv.StateCommon.HeaderColumn.Content.Color1 = System.Drawing.Color.White
        Me.oDgv.StateCommon.HeaderColumn.Content.Color2 = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.oDgv.StateCommon.HeaderColumn.Content.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.oDgv.StateSelected.DataCell.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.oDgv.StateSelected.DataCell.Content.Color1 = System.Drawing.Color.Black
        Me.oDgv.TabIndex = 18
        Me.oDgv.TabStop = False
        '
        'Column1
        '
        Me.Column1.HeaderText = "Qnty"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.HeaderText = "Sort"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Visible = False
        '
        'Column3
        '
        Me.Column3.HeaderText = "Code"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.HeaderText = "Item"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Column5
        '
        Me.Column5.HeaderText = "Price"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'Column6
        '
        Me.Column6.HeaderText = "Disc%"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'Column7
        '
        Me.Column7.HeaderText = "Value"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        '
        'Column8
        '
        Me.Column8.HeaderText = "PrKry"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        Me.Column8.Visible = False
        '
        'Column9
        '
        Me.Column9.HeaderText = "Stock"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        Me.Column9.Visible = False
        '
        'frmImport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(867, 327)
        Me.Controls.Add(Me.KryptonPanel)
        Me.Name = "frmImport"
        Me.Text = "frmImport"
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        Me.KryptonPanel.PerformLayout()
        CType(Me.oDgv, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents KryptonListBox1 As ComponentFactory.Krypton.Toolkit.KryptonListBox
    Friend WithEvents KryptonTextBox1 As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonButton1 As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents KryptonButton2 As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents KryptonButton3 As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents KryptonButton4 As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents KryptonTextBox2 As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonWrapLabel1 As ComponentFactory.Krypton.Toolkit.KryptonWrapLabel
    Friend WithEvents KryptonListBox2 As ComponentFactory.Krypton.Toolkit.KryptonListBox
    Friend WithEvents oDgv As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

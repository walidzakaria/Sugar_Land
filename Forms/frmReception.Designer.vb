<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReception
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReception))
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemDateEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.DefaultLookAndFeel1 = New DevExpress.LookAndFeel.DefaultLookAndFeel(Me.components)
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.btnPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.dtDate = New System.Windows.Forms.DateTimePicker()
        Me.btnRemove = New DevExpress.XtraEditors.SimpleButton()
        Me.btnAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.txtINF = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.txtCHD = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.txtADT = New DevExpress.XtraEditors.TextEdit()
        Me.lblCompany = New DevExpress.XtraEditors.LabelControl()
        Me.lblName = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.txtCode = New DevExpress.XtraEditors.TextEdit()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.txtDriver = New DevExpress.XtraEditors.TextEdit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit1.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.txtINF.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCHD.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtADT.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDriver.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridControl1
        '
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.Location = New System.Drawing.Point(0, 0)
        Me.GridControl1.MainView = Me.GridView2
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1, Me.RepositoryItemTextEdit1, Me.RepositoryItemDateEdit1})
        Me.GridControl1.Size = New System.Drawing.Size(1013, 398)
        Me.GridControl1.TabIndex = 9
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView2})
        '
        'GridView2
        '
        Me.GridView2.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridView2.Appearance.ColumnFilterButton.Options.UseFont = True
        Me.GridView2.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView2.Appearance.ColumnFilterButtonActive.Options.UseFont = True
        Me.GridView2.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView2.Appearance.CustomizationFormHint.Options.UseFont = True
        Me.GridView2.Appearance.DetailTip.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView2.Appearance.DetailTip.Options.UseFont = True
        Me.GridView2.Appearance.Empty.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView2.Appearance.Empty.Options.UseFont = True
        Me.GridView2.Appearance.EvenRow.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView2.Appearance.EvenRow.Options.UseFont = True
        Me.GridView2.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView2.Appearance.FilterCloseButton.Options.UseFont = True
        Me.GridView2.Appearance.FilterPanel.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView2.Appearance.FilterPanel.Options.UseFont = True
        Me.GridView2.Appearance.FixedLine.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView2.Appearance.FixedLine.Options.UseFont = True
        Me.GridView2.Appearance.FocusedCell.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView2.Appearance.FocusedCell.Options.UseFont = True
        Me.GridView2.Appearance.FocusedRow.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView2.Appearance.FocusedRow.Options.UseFont = True
        Me.GridView2.Appearance.FooterPanel.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView2.Appearance.FooterPanel.Options.UseFont = True
        Me.GridView2.Appearance.GroupButton.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView2.Appearance.GroupButton.Options.UseFont = True
        Me.GridView2.Appearance.GroupFooter.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView2.Appearance.GroupFooter.Options.UseFont = True
        Me.GridView2.Appearance.GroupPanel.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView2.Appearance.GroupPanel.Options.UseFont = True
        Me.GridView2.Appearance.GroupRow.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView2.Appearance.GroupRow.Options.UseFont = True
        Me.GridView2.Appearance.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridView2.Appearance.HeaderPanel.Options.UseFont = True
        Me.GridView2.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView2.Appearance.HideSelectionRow.Options.UseFont = True
        Me.GridView2.Appearance.HorzLine.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView2.Appearance.HorzLine.Options.UseFont = True
        Me.GridView2.Appearance.OddRow.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView2.Appearance.OddRow.Options.UseFont = True
        Me.GridView2.Appearance.Preview.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView2.Appearance.Preview.Options.UseFont = True
        Me.GridView2.Appearance.Row.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView2.Appearance.Row.Options.UseFont = True
        Me.GridView2.Appearance.RowSeparator.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView2.Appearance.RowSeparator.Options.UseFont = True
        Me.GridView2.Appearance.SelectedRow.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView2.Appearance.SelectedRow.Options.UseFont = True
        Me.GridView2.Appearance.TopNewRow.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView2.Appearance.TopNewRow.Options.UseFont = True
        Me.GridView2.Appearance.VertLine.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView2.Appearance.VertLine.Options.UseFont = True
        Me.GridView2.Appearance.ViewCaption.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView2.Appearance.ViewCaption.Options.UseFont = True
        Me.GridView2.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumn7, Me.GridColumn8, Me.GridColumn9})
        Me.GridView2.GridControl = Me.GridControl1
        Me.GridView2.Name = "GridView2"
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "PrKey"
        Me.GridColumn1.FieldName = "PrKey"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.AllowEdit = False
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Time"
        Me.GridColumn2.ColumnEdit = Me.RepositoryItemDateEdit1
        Me.GridColumn2.FieldName = "Time"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.OptionsColumn.AllowEdit = False
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        '
        'RepositoryItemDateEdit1
        '
        Me.RepositoryItemDateEdit1.AutoHeight = False
        Me.RepositoryItemDateEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemDateEdit1.Mask.EditMask = "HH:mm"
        Me.RepositoryItemDateEdit1.Name = "RepositoryItemDateEdit1"
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Company"
        Me.GridColumn3.FieldName = "Company"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.OptionsColumn.AllowEdit = False
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 1
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Agent"
        Me.GridColumn4.FieldName = "Agent"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.OptionsColumn.AllowEdit = False
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 2
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "ADT"
        Me.GridColumn5.FieldName = "ADT"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.OptionsColumn.AllowEdit = False
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 3
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "CHD"
        Me.GridColumn6.FieldName = "CHD"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.OptionsColumn.AllowEdit = False
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 4
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "INF"
        Me.GridColumn7.FieldName = "INF"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.OptionsColumn.AllowEdit = False
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 5
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "User"
        Me.GridColumn8.FieldName = "User"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.OptionsColumn.AllowEdit = False
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 6
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.ValueChecked = False
        '
        'RepositoryItemTextEdit1
        '
        Me.RepositoryItemTextEdit1.AutoHeight = False
        Me.RepositoryItemTextEdit1.Mask.EditMask = "\d+"
        Me.RepositoryItemTextEdit1.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx
        Me.RepositoryItemTextEdit1.Name = "RepositoryItemTextEdit1"
        '
        'DefaultLookAndFeel1
        '
        Me.DefaultLookAndFeel1.LookAndFeel.SkinName = "McSkin"
        '
        'GroupControl2
        '
        Me.GroupControl2.Appearance.BackColor = System.Drawing.Color.Tomato
        Me.GroupControl2.Appearance.Options.UseBackColor = True
        Me.GroupControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.GroupControl2.Controls.Add(Me.LabelControl3)
        Me.GroupControl2.Controls.Add(Me.txtDriver)
        Me.GroupControl2.Controls.Add(Me.btnPrint)
        Me.GroupControl2.Controls.Add(Me.dtDate)
        Me.GroupControl2.Controls.Add(Me.btnRemove)
        Me.GroupControl2.Controls.Add(Me.btnAdd)
        Me.GroupControl2.Controls.Add(Me.LabelControl7)
        Me.GroupControl2.Controls.Add(Me.txtINF)
        Me.GroupControl2.Controls.Add(Me.LabelControl6)
        Me.GroupControl2.Controls.Add(Me.txtCHD)
        Me.GroupControl2.Controls.Add(Me.LabelControl5)
        Me.GroupControl2.Controls.Add(Me.txtADT)
        Me.GroupControl2.Controls.Add(Me.lblCompany)
        Me.GroupControl2.Controls.Add(Me.lblName)
        Me.GroupControl2.Controls.Add(Me.LabelControl2)
        Me.GroupControl2.Controls.Add(Me.LabelControl1)
        Me.GroupControl2.Controls.Add(Me.txtCode)
        Me.GroupControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupControl2.Location = New System.Drawing.Point(0, 398)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.ShowCaption = False
        Me.GroupControl2.Size = New System.Drawing.Size(1013, 160)
        Me.GroupControl2.TabIndex = 10
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.Appearance.Options.UseFont = True
        Me.btnPrint.Image = CType(resources.GetObject("btnPrint.Image"), System.Drawing.Image)
        Me.btnPrint.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnPrint.Location = New System.Drawing.Point(32, 116)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(63, 39)
        Me.btnPrint.TabIndex = 35
        '
        'dtDate
        '
        Me.dtDate.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtDate.Location = New System.Drawing.Point(821, 128)
        Me.dtDate.Name = "dtDate"
        Me.dtDate.Size = New System.Drawing.Size(152, 27)
        Me.dtDate.TabIndex = 34
        '
        'btnRemove
        '
        Me.btnRemove.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRemove.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemove.Appearance.Options.UseFont = True
        Me.btnRemove.Image = CType(resources.GetObject("btnRemove.Image"), System.Drawing.Image)
        Me.btnRemove.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnRemove.Location = New System.Drawing.Point(821, 61)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(152, 39)
        Me.btnRemove.TabIndex = 33
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Appearance.Options.UseFont = True
        Me.btnAdd.Image = CType(resources.GetObject("btnAdd.Image"), System.Drawing.Image)
        Me.btnAdd.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnAdd.Location = New System.Drawing.Point(821, 16)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(152, 39)
        Me.btnAdd.TabIndex = 5
        '
        'LabelControl7
        '
        Me.LabelControl7.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.LabelControl7.Location = New System.Drawing.Point(393, 77)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(31, 19)
        Me.LabelControl7.TabIndex = 11
        Me.LabelControl7.Text = "INF:"
        '
        'txtINF
        '
        Me.txtINF.EnterMoveNextControl = True
        Me.txtINF.Location = New System.Drawing.Point(481, 76)
        Me.txtINF.Name = "txtINF"
        Me.txtINF.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.txtINF.Properties.Appearance.Options.UseFont = True
        Me.txtINF.Properties.Mask.EditMask = "\d+"
        Me.txtINF.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx
        Me.txtINF.Size = New System.Drawing.Size(161, 26)
        Me.txtINF.TabIndex = 3
        '
        'LabelControl6
        '
        Me.LabelControl6.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.LabelControl6.Location = New System.Drawing.Point(393, 45)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(38, 19)
        Me.LabelControl6.TabIndex = 9
        Me.LabelControl6.Text = "CHD:"
        '
        'txtCHD
        '
        Me.txtCHD.EnterMoveNextControl = True
        Me.txtCHD.Location = New System.Drawing.Point(481, 44)
        Me.txtCHD.Name = "txtCHD"
        Me.txtCHD.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.txtCHD.Properties.Appearance.Options.UseFont = True
        Me.txtCHD.Properties.Mask.EditMask = "\d+"
        Me.txtCHD.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx
        Me.txtCHD.Size = New System.Drawing.Size(161, 26)
        Me.txtCHD.TabIndex = 2
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.LabelControl5.Location = New System.Drawing.Point(393, 14)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(38, 19)
        Me.LabelControl5.TabIndex = 7
        Me.LabelControl5.Text = "ADT:"
        '
        'txtADT
        '
        Me.txtADT.EnterMoveNextControl = True
        Me.txtADT.Location = New System.Drawing.Point(481, 13)
        Me.txtADT.Name = "txtADT"
        Me.txtADT.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.txtADT.Properties.Appearance.Options.UseFont = True
        Me.txtADT.Properties.Mask.EditMask = "\d+"
        Me.txtADT.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx
        Me.txtADT.Size = New System.Drawing.Size(161, 26)
        Me.txtADT.TabIndex = 1
        '
        'lblCompany
        '
        Me.lblCompany.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.lblCompany.Location = New System.Drawing.Point(120, 79)
        Me.lblCompany.Name = "lblCompany"
        Me.lblCompany.Size = New System.Drawing.Size(42, 19)
        Me.lblCompany.TabIndex = 5
        Me.lblCompany.Text = "Code:"
        '
        'lblName
        '
        Me.lblName.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.lblName.Location = New System.Drawing.Point(120, 47)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(42, 19)
        Me.lblName.TabIndex = 4
        Me.lblName.Text = "Code:"
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.LabelControl2.Location = New System.Drawing.Point(32, 14)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(42, 19)
        Me.LabelControl2.TabIndex = 3
        Me.LabelControl2.Text = "Code:"
        '
        'LabelControl1
        '
        Me.LabelControl1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.LabelControl1.Location = New System.Drawing.Point(777, 132)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(38, 19)
        Me.LabelControl1.TabIndex = 2
        Me.LabelControl1.Text = "Date:"
        '
        'txtCode
        '
        Me.txtCode.Location = New System.Drawing.Point(120, 13)
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.txtCode.Properties.Appearance.Options.UseFont = True
        Me.txtCode.Size = New System.Drawing.Size(198, 26)
        Me.txtCode.TabIndex = 0
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "Driver"
        Me.GridColumn9.FieldName = "Driver"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.OptionsColumn.AllowEdit = False
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 7
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.LabelControl3.Location = New System.Drawing.Point(393, 116)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(49, 19)
        Me.LabelControl3.TabIndex = 37
        Me.LabelControl3.Text = "Driver:"
        '
        'txtDriver
        '
        Me.txtDriver.EditValue = ""
        Me.txtDriver.EnterMoveNextControl = True
        Me.txtDriver.Location = New System.Drawing.Point(481, 113)
        Me.txtDriver.Name = "txtDriver"
        Me.txtDriver.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.txtDriver.Properties.Appearance.Options.UseFont = True
        Me.txtDriver.Properties.Mask.EditMask = "\d+"
        Me.txtDriver.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx
        Me.txtDriver.Size = New System.Drawing.Size(161, 26)
        Me.txtDriver.TabIndex = 4
        '
        'frmReception
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1013, 558)
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.GroupControl2)
        Me.LookAndFeel.SkinName = "Visual Studio 2013 Blue"
        Me.Name = "frmReception"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Agents"
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit1.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        Me.GroupControl2.PerformLayout()
        CType(Me.txtINF.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCHD.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtADT.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDriver.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents DefaultLookAndFeel1 As DevExpress.LookAndFeel.DefaultLookAndFeel
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtINF As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtCHD As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtADT As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblCompany As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblName As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btnRemove As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents RepositoryItemDateEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents dtDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtDriver As DevExpress.XtraEditors.TextEdit
End Class

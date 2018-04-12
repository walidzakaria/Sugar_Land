<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSettings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSettings))
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Me.KryptonPanel = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.TblItemsGridControl = New DevExpress.XtraGrid.GridControl()
        Me.TblItemsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DBDataSet = New MASTER_pro.DBDataSet()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        'Me.TblItemsTableAdapter = New MASTER_pro.DBDataSetTableAdapters.tblItemsTableAdapter()
        Me.TableAdapterManager = New MASTER_pro.DBDataSetTableAdapters.TableAdapterManager()
        Me.TblItemsBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.TblItemsBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.odgv = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        CType(Me.TblItemsGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblItemsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DBDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblItemsBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TblItemsBindingNavigator.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.odgv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KryptonPanel
        '
        Me.KryptonPanel.Controls.Add(Me.GridControl1)
        Me.KryptonPanel.Controls.Add(Me.TblItemsGridControl)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Size = New System.Drawing.Size(705, 372)
        Me.KryptonPanel.TabIndex = 0
        '
        'TblItemsGridControl
        '
        Me.TblItemsGridControl.DataSource = Me.TblItemsBindingSource
        Me.TblItemsGridControl.Location = New System.Drawing.Point(0, 0)
        Me.TblItemsGridControl.MainView = Me.GridView1
        Me.TblItemsGridControl.Name = "TblItemsGridControl"
        Me.TblItemsGridControl.Size = New System.Drawing.Size(436, 133)
        Me.TblItemsGridControl.TabIndex = 0
        Me.TblItemsGridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'TblItemsBindingSource
        '
        Me.TblItemsBindingSource.DataMember = "tblItems"
        Me.TblItemsBindingSource.DataSource = Me.DBDataSet
        '
        'DBDataSet
        '
        Me.DBDataSet.DataSetName = "DBDataSet"
        Me.DBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.TblItemsGridControl
        Me.GridView1.Name = "GridView1"
        '
        'KryptonManager
        '
        Me.KryptonManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2010Silver
        '
        'TblItemsTableAdapter
        '
        'Me.TblItemsTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        'Me.TableAdapterManager.tblCashTableAdapter = Nothing
        'Me.TableAdapterManager.tblCompoundsTableAdapter = Nothing
        'Me.TableAdapterManager.tblDebitTableAdapter = Nothing
        'Me.TableAdapterManager.tblIn1TableAdapter = Nothing
        'Me.TableAdapterManager.tblIn2TableAdapter = Nothing
        'Me.TableAdapterManager.tblInInvoiceTableAdapter = Nothing
        'Me.TableAdapterManager.tblItemsTableAdapter = Me.TblItemsTableAdapter
        'Me.TableAdapterManager.tblLoginTableAdapter = Nothing
        'Me.TableAdapterManager.tblMasterTableAdapter = Nothing
        'Me.TableAdapterManager.tblOut1TableAdapter = Nothing
        'Me.TableAdapterManager.tblOut2TableAdapter = Nothing
        'Me.TableAdapterManager.tblRateTableAdapter = Nothing
        'Me.TableAdapterManager.tblVendorsTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = MASTER_pro.DBDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'TblItemsBindingNavigator
        '
        Me.TblItemsBindingNavigator.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.TblItemsBindingNavigator.BindingSource = Me.TblItemsBindingSource
        Me.TblItemsBindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.TblItemsBindingNavigator.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.TblItemsBindingNavigator.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TblItemsBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.TblItemsBindingNavigatorSaveItem})
        Me.TblItemsBindingNavigator.Location = New System.Drawing.Point(0, 0)
        Me.TblItemsBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.TblItemsBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.TblItemsBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.TblItemsBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.TblItemsBindingNavigator.Name = "TblItemsBindingNavigator"
        Me.TblItemsBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.TblItemsBindingNavigator.Size = New System.Drawing.Size(705, 25)
        Me.TblItemsBindingNavigator.TabIndex = 1
        Me.TblItemsBindingNavigator.Text = "BindingNavigator1"
        '
        'BindingNavigatorAddNewItem
        '
        Me.BindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorAddNewItem.Image = CType(resources.GetObject("BindingNavigatorAddNewItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorAddNewItem.Name = "BindingNavigatorAddNewItem"
        Me.BindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorAddNewItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorAddNewItem.Text = "Add new"
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(35, 22)
        Me.BindingNavigatorCountItem.Text = "of {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Total number of items"
        '
        'BindingNavigatorDeleteItem
        '
        Me.BindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorDeleteItem.Image = CType(resources.GetObject("BindingNavigatorDeleteItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
        Me.BindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorDeleteItem.Text = "Delete"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveFirstItem.Text = "Move first"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMovePreviousItem.Text = "Move previous"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Position"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 23)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Current position"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveNextItem.Text = "Move next"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveLastItem.Text = "Move last"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'TblItemsBindingNavigatorSaveItem
        '
        Me.TblItemsBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TblItemsBindingNavigatorSaveItem.Image = CType(resources.GetObject("TblItemsBindingNavigatorSaveItem.Image"), System.Drawing.Image)
        Me.TblItemsBindingNavigatorSaveItem.Name = "TblItemsBindingNavigatorSaveItem"
        Me.TblItemsBindingNavigatorSaveItem.Size = New System.Drawing.Size(23, 22)
        Me.TblItemsBindingNavigatorSaveItem.Text = "Save Data"
        '
        'GridControl1
        '
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        GridLevelNode1.RelationName = "Level1"
        Me.GridControl1.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.GridControl1.Location = New System.Drawing.Point(0, 0)
        Me.GridControl1.MainView = Me.odgv
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1, Me.RepositoryItemTextEdit1})
        Me.GridControl1.Size = New System.Drawing.Size(705, 372)
        Me.GridControl1.TabIndex = 11
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.odgv})
        '
        'odgv
        '
        Me.odgv.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.odgv.Appearance.ColumnFilterButton.Options.UseFont = True
        Me.odgv.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.odgv.Appearance.ColumnFilterButtonActive.Options.UseFont = True
        Me.odgv.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.odgv.Appearance.CustomizationFormHint.Options.UseFont = True
        Me.odgv.Appearance.DetailTip.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.odgv.Appearance.DetailTip.Options.UseFont = True
        Me.odgv.Appearance.Empty.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.odgv.Appearance.Empty.Options.UseFont = True
        Me.odgv.Appearance.EvenRow.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.odgv.Appearance.EvenRow.Options.UseFont = True
        Me.odgv.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.odgv.Appearance.FilterCloseButton.Options.UseFont = True
        Me.odgv.Appearance.FilterPanel.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.odgv.Appearance.FilterPanel.Options.UseFont = True
        Me.odgv.Appearance.FixedLine.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.odgv.Appearance.FixedLine.Options.UseFont = True
        Me.odgv.Appearance.FocusedCell.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.odgv.Appearance.FocusedCell.Options.UseFont = True
        Me.odgv.Appearance.FocusedRow.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.odgv.Appearance.FocusedRow.Options.UseFont = True
        Me.odgv.Appearance.FooterPanel.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.odgv.Appearance.FooterPanel.Options.UseFont = True
        Me.odgv.Appearance.GroupButton.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.odgv.Appearance.GroupButton.Options.UseFont = True
        Me.odgv.Appearance.GroupFooter.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.odgv.Appearance.GroupFooter.Options.UseFont = True
        Me.odgv.Appearance.GroupPanel.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.odgv.Appearance.GroupPanel.Options.UseFont = True
        Me.odgv.Appearance.GroupRow.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.odgv.Appearance.GroupRow.Options.UseFont = True
        Me.odgv.Appearance.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.odgv.Appearance.HeaderPanel.Options.UseFont = True
        Me.odgv.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.odgv.Appearance.HideSelectionRow.Options.UseFont = True
        Me.odgv.Appearance.HorzLine.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.odgv.Appearance.HorzLine.Options.UseFont = True
        Me.odgv.Appearance.OddRow.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.odgv.Appearance.OddRow.Options.UseFont = True
        Me.odgv.Appearance.Preview.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.odgv.Appearance.Preview.Options.UseFont = True
        Me.odgv.Appearance.Row.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.odgv.Appearance.Row.Options.UseFont = True
        Me.odgv.Appearance.RowSeparator.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.odgv.Appearance.RowSeparator.Options.UseFont = True
        Me.odgv.Appearance.SelectedRow.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.odgv.Appearance.SelectedRow.Options.UseFont = True
        Me.odgv.Appearance.TopNewRow.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.odgv.Appearance.TopNewRow.Options.UseFont = True
        Me.odgv.Appearance.VertLine.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.odgv.Appearance.VertLine.Options.UseFont = True
        Me.odgv.Appearance.ViewCaption.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.odgv.Appearance.ViewCaption.Options.UseFont = True
        Me.odgv.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumn7, Me.GridColumn8, Me.GridColumn9})
        Me.odgv.GridControl = Me.GridControl1
        Me.odgv.Name = "odgv"
        Me.odgv.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[False]
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Qnty"
        Me.GridColumn1.FieldName = "Qnty"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Sort"
        Me.GridColumn2.FieldName = "Sort"
        Me.GridColumn2.Name = "GridColumn2"
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Code"
        Me.GridColumn3.FieldName = "Code"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 1
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Item"
        Me.GridColumn4.FieldName = "Item"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 2
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Price"
        Me.GridColumn5.FieldName = "Price"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 3
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Disc%"
        Me.GridColumn6.FieldName = "Discount"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 4
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Value"
        Me.GridColumn7.FieldName = "Value"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 5
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "PrKey"
        Me.GridColumn8.FieldName = "PrKey"
        Me.GridColumn8.Name = "GridColumn8"
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "Stock"
        Me.GridColumn9.FieldName = "Stock"
        Me.GridColumn9.Name = "GridColumn9"
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
        'frmSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(705, 372)
        Me.Controls.Add(Me.TblItemsBindingNavigator)
        Me.Controls.Add(Me.KryptonPanel)
        Me.Name = "frmSettings"
        Me.Text = "frmSettings"
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        CType(Me.TblItemsGridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblItemsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DBDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblItemsBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TblItemsBindingNavigator.ResumeLayout(False)
        Me.TblItemsBindingNavigator.PerformLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.odgv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

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
    Friend WithEvents DBDataSet As MASTER_pro.DBDataSet
    Friend WithEvents TblItemsBindingSource As System.Windows.Forms.BindingSource
    'Friend WithEvents TblItemsTableAdapter As MASTER_pro.DBDataSetTableAdapters.tblItemsTableAdapter
    Friend WithEvents TableAdapterManager As MASTER_pro.DBDataSetTableAdapters.TableAdapterManager
    Friend WithEvents TblItemsBindingNavigator As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorAddNewItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorDeleteItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TblItemsBindingNavigatorSaveItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents TblItemsGridControl As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents odgv As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
End Class

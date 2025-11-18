<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTraPPATOrder
    Inherits System.Windows.Forms.Form

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
        Me.grdMain = New DevExpress.XtraGrid.GridControl()
        Me.grdView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.pnlBrowse = New System.Windows.Forms.Panel()
        Me.btnAllCompleted = New System.Windows.Forms.Button()
        Me.chkShowProcessBy = New System.Windows.Forms.CheckBox()
        Me.chkCheckPPAT = New System.Windows.Forms.CheckBox()
        Me.chkListJenisTransaksi = New System.Windows.Forms.CheckedListBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnExecute = New System.Windows.Forms.Button()
        Me.cboStatus = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpDateTo = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpDateFrom = New System.Windows.Forms.DateTimePicker()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.ToolBar = New System.Windows.Forms.ToolBar()
        Me.BarNew = New System.Windows.Forms.ToolBarButton()
        Me.BarDetail = New System.Windows.Forms.ToolBarButton()
        Me.BarDelete = New System.Windows.Forms.ToolBarButton()
        Me.BarSep1 = New System.Windows.Forms.ToolBarButton()
        Me.BarConfirm = New System.Windows.Forms.ToolBarButton()
        Me.BarBPNFinish = New System.Windows.Forms.ToolBarButton()
        Me.BarApproval = New System.Windows.Forms.ToolBarButton()
        Me.BarSep2 = New System.Windows.Forms.ToolBarButton()
        Me.BarClose = New System.Windows.Forms.ToolBarButton()
        Me.BarRefresh = New System.Windows.Forms.ToolBarButton()
        CType(Me.grdMain, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBrowse.SuspendLayout()
        Me.SuspendLayout()
        '
        'grdMain
        '
        Me.grdMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdMain.EmbeddedNavigator.Buttons.Append.Enabled = False
        Me.grdMain.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.grdMain.EmbeddedNavigator.Buttons.CancelEdit.Enabled = False
        Me.grdMain.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.grdMain.EmbeddedNavigator.Buttons.Edit.Enabled = False
        Me.grdMain.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.grdMain.EmbeddedNavigator.Buttons.EndEdit.Enabled = False
        Me.grdMain.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.grdMain.EmbeddedNavigator.Buttons.NextPage.Enabled = False
        Me.grdMain.EmbeddedNavigator.Buttons.NextPage.Visible = False
        Me.grdMain.EmbeddedNavigator.Buttons.PrevPage.Enabled = False
        Me.grdMain.EmbeddedNavigator.Buttons.PrevPage.Visible = False
        Me.grdMain.EmbeddedNavigator.Buttons.Remove.Enabled = False
        Me.grdMain.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.grdMain.Location = New System.Drawing.Point(0, 161)
        Me.grdMain.MainView = Me.grdView
        Me.grdMain.Name = "grdMain"
        Me.grdMain.Size = New System.Drawing.Size(1242, 310)
        Me.grdMain.TabIndex = 5
        Me.grdMain.UseEmbeddedNavigator = True
        Me.grdMain.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdView})
        '
        'grdView
        '
        Me.grdView.GridControl = Me.grdMain
        Me.grdView.Name = "grdView"
        Me.grdView.OptionsView.ColumnAutoWidth = False
        Me.grdView.OptionsView.ShowAutoFilterRow = True
        Me.grdView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        '
        'pnlBrowse
        '
        Me.pnlBrowse.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlBrowse.Controls.Add(Me.btnAllCompleted)
        Me.pnlBrowse.Controls.Add(Me.chkShowProcessBy)
        Me.pnlBrowse.Controls.Add(Me.chkCheckPPAT)
        Me.pnlBrowse.Controls.Add(Me.chkListJenisTransaksi)
        Me.pnlBrowse.Controls.Add(Me.Label8)
        Me.pnlBrowse.Controls.Add(Me.btnExecute)
        Me.pnlBrowse.Controls.Add(Me.cboStatus)
        Me.pnlBrowse.Controls.Add(Me.Label4)
        Me.pnlBrowse.Controls.Add(Me.dtpDateTo)
        Me.pnlBrowse.Controls.Add(Me.Label3)
        Me.pnlBrowse.Controls.Add(Me.dtpDateFrom)
        Me.pnlBrowse.Controls.Add(Me.Label10)
        Me.pnlBrowse.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlBrowse.Location = New System.Drawing.Point(0, 28)
        Me.pnlBrowse.Name = "pnlBrowse"
        Me.pnlBrowse.Size = New System.Drawing.Size(1242, 133)
        Me.pnlBrowse.TabIndex = 4
        '
        'btnAllCompleted
        '
        Me.btnAllCompleted.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAllCompleted.Location = New System.Drawing.Point(384, 87)
        Me.btnAllCompleted.Name = "btnAllCompleted"
        Me.btnAllCompleted.Size = New System.Drawing.Size(138, 22)
        Me.btnAllCompleted.TabIndex = 26
        Me.btnAllCompleted.Text = "Set All Completed"
        Me.btnAllCompleted.UseVisualStyleBackColor = True
        '
        'chkShowProcessBy
        '
        Me.chkShowProcessBy.AutoSize = True
        Me.chkShowProcessBy.Location = New System.Drawing.Point(384, 19)
        Me.chkShowProcessBy.Name = "chkShowProcessBy"
        Me.chkShowProcessBy.Size = New System.Drawing.Size(117, 17)
        Me.chkShowProcessBy.TabIndex = 203
        Me.chkShowProcessBy.Text = "chkShowProcessBy"
        Me.chkShowProcessBy.UseVisualStyleBackColor = True
        '
        'chkCheckPPAT
        '
        Me.chkCheckPPAT.AutoSize = True
        Me.chkCheckPPAT.Location = New System.Drawing.Point(636, 32)
        Me.chkCheckPPAT.Name = "chkCheckPPAT"
        Me.chkCheckPPAT.Size = New System.Drawing.Size(97, 17)
        Me.chkCheckPPAT.TabIndex = 201
        Me.chkCheckPPAT.Text = "Check All PPAT"
        Me.chkCheckPPAT.UseVisualStyleBackColor = True
        '
        'chkListJenisTransaksi
        '
        Me.chkListJenisTransaksi.FormattingEnabled = True
        Me.chkListJenisTransaksi.Items.AddRange(New Object() {"AKTA JUAL BELI (AJB)", "AKTA TUKAR MENUKAR (ATM)", "AKTA HIBAH (AH)", "AKTA PEMASUKAN KE DALAM PERUSAHAAN (INBERG) (APDP)", "AKTA PEMBAGIAN HAK BERSAMA (APHB)", "AKTA PEMBERIAN HAK GUNA BANGUNAN / HAK PAKAI ATAS TANAH HAK MILIK (APHGB)", "AKTA PEMBERIAN HAK TANGGUNGAN (APHT)"})
        Me.chkListJenisTransaksi.Location = New System.Drawing.Point(739, 9)
        Me.chkListJenisTransaksi.Name = "chkListJenisTransaksi"
        Me.chkListJenisTransaksi.Size = New System.Drawing.Size(456, 116)
        Me.chkListJenisTransaksi.TabIndex = 198
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.DimGray
        Me.Label8.Location = New System.Drawing.Point(633, 11)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(94, 13)
        Me.Label8.TabIndex = 197
        Me.Label8.Text = "Jenis Transaksi"
        '
        'btnExecute
        '
        Me.btnExecute.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExecute.Location = New System.Drawing.Point(285, 87)
        Me.btnExecute.Name = "btnExecute"
        Me.btnExecute.Size = New System.Drawing.Size(71, 22)
        Me.btnExecute.TabIndex = 23
        Me.btnExecute.Text = "Execute"
        Me.btnExecute.UseVisualStyleBackColor = True
        '
        'cboStatus
        '
        Me.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Items.AddRange(New Object() {"ALL", "DRAFT", "PROCESS", "BPN FINISH", "COMPLETED"})
        Me.cboStatus.Location = New System.Drawing.Point(120, 47)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(236, 21)
        Me.cboStatus.TabIndex = 16
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DimGray
        Me.Label4.Location = New System.Drawing.Point(19, 50)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 13)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Status "
        '
        'dtpDateTo
        '
        Me.dtpDateTo.CustomFormat = "dd/MM/yyyy"
        Me.dtpDateTo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDateTo.Location = New System.Drawing.Point(255, 19)
        Me.dtpDateTo.Name = "dtpDateTo"
        Me.dtpDateTo.Size = New System.Drawing.Size(101, 21)
        Me.dtpDateTo.TabIndex = 14
        Me.dtpDateTo.Value = New Date(2012, 7, 1, 0, 0, 0, 0)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DimGray
        Me.Label3.Location = New System.Drawing.Point(228, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(21, 13)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "To"
        '
        'dtpDateFrom
        '
        Me.dtpDateFrom.CustomFormat = "dd/MM/yyyy"
        Me.dtpDateFrom.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDateFrom.Location = New System.Drawing.Point(120, 19)
        Me.dtpDateFrom.Name = "dtpDateFrom"
        Me.dtpDateFrom.Size = New System.Drawing.Size(102, 21)
        Me.dtpDateFrom.TabIndex = 12
        Me.dtpDateFrom.Value = New Date(2012, 7, 1, 0, 0, 0, 0)
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.DimGray
        Me.Label10.Location = New System.Drawing.Point(19, 23)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(82, 13)
        Me.Label10.TabIndex = 11
        Me.Label10.Text = "Tanggal Akta"
        '
        'ToolBar
        '
        Me.ToolBar.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.ToolBar.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.BarNew, Me.BarDetail, Me.BarDelete, Me.BarSep1, Me.BarConfirm, Me.BarBPNFinish, Me.BarApproval, Me.BarSep2, Me.BarClose, Me.BarRefresh})
        Me.ToolBar.DropDownArrows = True
        Me.ToolBar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolBar.Location = New System.Drawing.Point(0, 0)
        Me.ToolBar.Name = "ToolBar"
        Me.ToolBar.ShowToolTips = True
        Me.ToolBar.Size = New System.Drawing.Size(1242, 28)
        Me.ToolBar.TabIndex = 3
        Me.ToolBar.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right
        '
        'BarNew
        '
        Me.BarNew.Name = "BarNew"
        Me.BarNew.Text = "New"
        '
        'BarDetail
        '
        Me.BarDetail.Name = "BarDetail"
        Me.BarDetail.Text = "Detail"
        '
        'BarDelete
        '
        Me.BarDelete.Name = "BarDelete"
        Me.BarDelete.Text = "Delete"
        '
        'BarSep1
        '
        Me.BarSep1.Name = "BarSep1"
        Me.BarSep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'BarConfirm
        '
        Me.BarConfirm.Name = "BarConfirm"
        Me.BarConfirm.Text = "Process"
        '
        'BarBPNFinish
        '
        Me.BarBPNFinish.Name = "BarBPNFinish"
        Me.BarBPNFinish.Text = "BPN Finish"
        '
        'BarApproval
        '
        Me.BarApproval.Name = "BarApproval"
        Me.BarApproval.Text = "Completed"
        '
        'BarSep2
        '
        Me.BarSep2.Name = "BarSep2"
        Me.BarSep2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'BarClose
        '
        Me.BarClose.Name = "BarClose"
        Me.BarClose.Text = "False"
        '
        'BarRefresh
        '
        Me.BarRefresh.Name = "BarRefresh"
        Me.BarRefresh.Text = "Refresh"
        '
        'frmTraPPATOrder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1242, 471)
        Me.Controls.Add(Me.grdMain)
        Me.Controls.Add(Me.pnlBrowse)
        Me.Controls.Add(Me.ToolBar)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmTraPPATOrder"
        Me.Text = "PPAT Order"
        CType(Me.grdMain, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBrowse.ResumeLayout(False)
        Me.pnlBrowse.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grdMain As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents pnlBrowse As System.Windows.Forms.Panel
    Friend WithEvents btnExecute As System.Windows.Forms.Button
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtpDateTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtpDateFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents ToolBar As System.Windows.Forms.ToolBar
    Friend WithEvents BarNew As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarDetail As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarDelete As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarSep1 As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarProcess As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarCompleted As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarSep2 As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarFalse As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarRefresh As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarClose As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarBPNFinish As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarConfirm As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarApproval As System.Windows.Forms.ToolBarButton
    Friend WithEvents chkListJenisTransaksi As System.Windows.Forms.CheckedListBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents chkCheckPPAT As System.Windows.Forms.CheckBox
    Friend WithEvents chkShowProcessBy As System.Windows.Forms.CheckBox
    Friend WithEvents btnAllCompleted As System.Windows.Forms.Button
End Class

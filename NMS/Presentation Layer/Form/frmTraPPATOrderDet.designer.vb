<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTraPPATOrderDet
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTraPPATOrderDet))
        Me.pnlDetail = New System.Windows.Forms.Panel()
        Me.grdClient1 = New DevExpress.XtraGrid.GridControl()
        Me.grdItemView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ToolBarDetail = New System.Windows.Forms.ToolBar()
        Me.BarDetNew = New System.Windows.Forms.ToolBarButton()
        Me.BarDetDetail = New System.Windows.Forms.ToolBarButton()
        Me.BarDetDelete = New System.Windows.Forms.ToolBarButton()
        Me.gbDetail = New System.Windows.Forms.GroupBox()
        Me.tbcPPAT = New System.Windows.Forms.TabControl()
        Me.tbMain = New System.Windows.Forms.TabPage()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtProcessUserID = New NMS.usTextBox()
        Me.btnUser = New System.Windows.Forms.Button()
        Me.btnFileLocation = New System.Windows.Forms.Button()
        Me.txtNoAkta = New NMS.usTextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.cboJenisTransaksi = New System.Windows.Forms.ComboBox()
        Me.txtRemarks = New System.Windows.Forms.TextBox()
        Me.txtFileLocation = New System.Windows.Forms.TextBox()
        Me.dtpTglPenyerahanDokumen = New System.Windows.Forms.DateTimePicker()
        Me.txtJenisNoHak = New System.Windows.Forms.TextBox()
        Me.txtPPATOrderID = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblRemarks = New System.Windows.Forms.Label()
        Me.lblPRDate = New System.Windows.Forms.Label()
        Me.lblPPATOrderID = New System.Windows.Forms.Label()
        Me.dtpTanggalAkta = New System.Windows.Forms.DateTimePicker()
        Me.tbTanahBangunan = New System.Windows.Forms.TabPage()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.numHargaTransaksi = New NMS.usNumeric()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.numLuasBangunan = New NMS.usNumeric()
        Me.numLuasTanah = New NMS.usNumeric()
        Me.txtLetakTanah = New NMS.usTextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tbSPPTPBB = New System.Windows.Forms.TabPage()
        Me.txtSPPTPBBNOPTahun = New System.Windows.Forms.TextBox()
        Me.numSPPTPBBNJOP = New NMS.usNumeric()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.tbSSP = New System.Windows.Forms.TabPage()
        Me.dtpSSPTanggal = New System.Windows.Forms.DateTimePicker()
        Me.numSSPHarga = New NMS.usNumeric()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tbSSB = New System.Windows.Forms.TabPage()
        Me.dtpSSBTanggal = New System.Windows.Forms.DateTimePicker()
        Me.numSSBHarga = New NMS.usNumeric()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.grdClient2 = New DevExpress.XtraGrid.GridControl()
        Me.grdItemView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ToolBarDetail2 = New System.Windows.Forms.ToolBar()
        Me.BarDetNew2 = New System.Windows.Forms.ToolBarButton()
        Me.BarDetDetail2 = New System.Windows.Forms.ToolBarButton()
        Me.BarDetDelete2 = New System.Windows.Forms.ToolBarButton()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.ToolStripEmpty = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripDraftBy = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripProcessBy = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripProcessDate = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripBPNFinishBy = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripBPNFinishDate = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripCompletedBy = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripCompletedDate = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblItem = New System.Windows.Forms.Label()
        Me.lblHead = New System.Windows.Forms.Label()
        Me.ToolBar = New System.Windows.Forms.ToolBar()
        Me.BarSave = New System.Windows.Forms.ToolBarButton()
        Me.BarClose = New System.Windows.Forms.ToolBarButton()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.numExpInterval = New System.Windows.Forms.NumericUpDown()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.pnlDetail.SuspendLayout()
        CType(Me.grdClient1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdItemView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDetail.SuspendLayout()
        Me.tbcPPAT.SuspendLayout()
        Me.tbMain.SuspendLayout()
        Me.tbTanahBangunan.SuspendLayout()
        CType(Me.numHargaTransaksi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numLuasBangunan, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numLuasTanah, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbSPPTPBB.SuspendLayout()
        CType(Me.numSPPTPBBNJOP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbSSP.SuspendLayout()
        CType(Me.numSSPHarga, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbSSB.SuspendLayout()
        CType(Me.numSSBHarga, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.grdClient2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdItemView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip.SuspendLayout()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numExpInterval, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlDetail
        '
        Me.pnlDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlDetail.Controls.Add(Me.grdClient1)
        Me.pnlDetail.Controls.Add(Me.ToolBarDetail)
        Me.pnlDetail.Location = New System.Drawing.Point(10, 314)
        Me.pnlDetail.Name = "pnlDetail"
        Me.pnlDetail.Size = New System.Drawing.Size(978, 171)
        Me.pnlDetail.TabIndex = 100
        '
        'grdClient1
        '
        Me.grdClient1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdClient1.EmbeddedNavigator.Buttons.Append.Enabled = False
        Me.grdClient1.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.grdClient1.EmbeddedNavigator.Buttons.CancelEdit.Enabled = False
        Me.grdClient1.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.grdClient1.EmbeddedNavigator.Buttons.Edit.Enabled = False
        Me.grdClient1.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.grdClient1.EmbeddedNavigator.Buttons.EndEdit.Enabled = False
        Me.grdClient1.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.grdClient1.EmbeddedNavigator.Buttons.NextPage.Enabled = False
        Me.grdClient1.EmbeddedNavigator.Buttons.NextPage.Visible = False
        Me.grdClient1.EmbeddedNavigator.Buttons.PrevPage.Enabled = False
        Me.grdClient1.EmbeddedNavigator.Buttons.PrevPage.Visible = False
        Me.grdClient1.EmbeddedNavigator.Buttons.Remove.Enabled = False
        Me.grdClient1.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.grdClient1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.grdClient1.Location = New System.Drawing.Point(0, 28)
        Me.grdClient1.MainView = Me.grdItemView
        Me.grdClient1.Name = "grdClient1"
        Me.grdClient1.Size = New System.Drawing.Size(978, 143)
        Me.grdClient1.TabIndex = 3
        Me.grdClient1.TabStop = False
        Me.grdClient1.UseEmbeddedNavigator = True
        Me.grdClient1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdItemView})
        '
        'grdItemView
        '
        Me.grdItemView.DetailHeight = 150
        Me.grdItemView.GridControl = Me.grdClient1
        Me.grdItemView.Name = "grdItemView"
        Me.grdItemView.OptionsCustomization.AllowColumnMoving = False
        Me.grdItemView.OptionsCustomization.AllowGroup = False
        Me.grdItemView.OptionsView.ColumnAutoWidth = False
        Me.grdItemView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.grdItemView.OptionsView.ShowGroupPanel = False
        '
        'ToolBarDetail
        '
        Me.ToolBarDetail.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.ToolBarDetail.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.BarDetNew, Me.BarDetDetail, Me.BarDetDelete})
        Me.ToolBarDetail.DropDownArrows = True
        Me.ToolBarDetail.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolBarDetail.Location = New System.Drawing.Point(0, 0)
        Me.ToolBarDetail.Name = "ToolBarDetail"
        Me.ToolBarDetail.ShowToolTips = True
        Me.ToolBarDetail.Size = New System.Drawing.Size(978, 28)
        Me.ToolBarDetail.TabIndex = 0
        Me.ToolBarDetail.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right
        '
        'BarDetNew
        '
        Me.BarDetNew.Name = "BarDetNew"
        Me.BarDetNew.Text = "New"
        '
        'BarDetDetail
        '
        Me.BarDetDetail.Name = "BarDetDetail"
        Me.BarDetDetail.Text = "Detail"
        '
        'BarDetDelete
        '
        Me.BarDetDelete.Name = "BarDetDelete"
        Me.BarDetDelete.Text = "Delete"
        '
        'gbDetail
        '
        Me.gbDetail.Controls.Add(Me.tbcPPAT)
        Me.gbDetail.Controls.Add(Me.Panel1)
        Me.gbDetail.Controls.Add(Me.Label9)
        Me.gbDetail.Controls.Add(Me.StatusStrip)
        Me.gbDetail.Controls.Add(Me.pnlDetail)
        Me.gbDetail.Controls.Add(Me.lblItem)
        Me.gbDetail.Controls.Add(Me.lblHead)
        Me.gbDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbDetail.Location = New System.Drawing.Point(0, 28)
        Me.gbDetail.Name = "gbDetail"
        Me.gbDetail.Size = New System.Drawing.Size(997, 714)
        Me.gbDetail.TabIndex = 3
        Me.gbDetail.TabStop = False
        '
        'tbcPPAT
        '
        Me.tbcPPAT.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.tbcPPAT.Controls.Add(Me.tbMain)
        Me.tbcPPAT.Controls.Add(Me.tbTanahBangunan)
        Me.tbcPPAT.Controls.Add(Me.tbSPPTPBB)
        Me.tbcPPAT.Controls.Add(Me.tbSSP)
        Me.tbcPPAT.Controls.Add(Me.tbSSB)
        Me.tbcPPAT.Location = New System.Drawing.Point(6, 41)
        Me.tbcPPAT.Name = "tbcPPAT"
        Me.tbcPPAT.SelectedIndex = 0
        Me.tbcPPAT.Size = New System.Drawing.Size(988, 245)
        Me.tbcPPAT.TabIndex = 1
        Me.tbcPPAT.TabStop = False
        '
        'tbMain
        '
        Me.tbMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tbMain.Controls.Add(Me.Label16)
        Me.tbMain.Controls.Add(Me.Label10)
        Me.tbMain.Controls.Add(Me.numExpInterval)
        Me.tbMain.Controls.Add(Me.txtProcessUserID)
        Me.tbMain.Controls.Add(Me.Label18)
        Me.tbMain.Controls.Add(Me.btnUser)
        Me.tbMain.Controls.Add(Me.btnFileLocation)
        Me.tbMain.Controls.Add(Me.txtNoAkta)
        Me.tbMain.Controls.Add(Me.Label23)
        Me.tbMain.Controls.Add(Me.cboJenisTransaksi)
        Me.tbMain.Controls.Add(Me.txtRemarks)
        Me.tbMain.Controls.Add(Me.txtFileLocation)
        Me.tbMain.Controls.Add(Me.dtpTglPenyerahanDokumen)
        Me.tbMain.Controls.Add(Me.txtJenisNoHak)
        Me.tbMain.Controls.Add(Me.txtPPATOrderID)
        Me.tbMain.Controls.Add(Me.Label22)
        Me.tbMain.Controls.Add(Me.Label7)
        Me.tbMain.Controls.Add(Me.Label4)
        Me.tbMain.Controls.Add(Me.Label2)
        Me.tbMain.Controls.Add(Me.Label3)
        Me.tbMain.Controls.Add(Me.lblRemarks)
        Me.tbMain.Controls.Add(Me.lblPRDate)
        Me.tbMain.Controls.Add(Me.lblPPATOrderID)
        Me.tbMain.Controls.Add(Me.dtpTanggalAkta)
        Me.tbMain.Location = New System.Drawing.Point(4, 25)
        Me.tbMain.Name = "tbMain"
        Me.tbMain.Padding = New System.Windows.Forms.Padding(3)
        Me.tbMain.Size = New System.Drawing.Size(980, 216)
        Me.tbMain.TabIndex = 0
        Me.tbMain.Text = "Main - F1"
        Me.tbMain.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(525, 77)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(73, 13)
        Me.Label10.TabIndex = 130
        Me.Label10.Text = "Diproses Oleh"
        '
        'txtProcessUserID
        '
        Me.txtProcessUserID.BackColor = System.Drawing.Color.AliceBlue
        Me.txtProcessUserID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProcessUserID.Location = New System.Drawing.Point(648, 74)
        Me.txtProcessUserID.Name = "txtProcessUserID"
        Me.txtProcessUserID.ReadOnly = True
        Me.txtProcessUserID.Size = New System.Drawing.Size(121, 21)
        Me.txtProcessUserID.TabIndex = 128
        '
        'btnUser
        '
        Me.btnUser.BackColor = System.Drawing.Color.Transparent
        Me.btnUser.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUser.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUser.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnUser.Image = CType(resources.GetObject("btnUser.Image"), System.Drawing.Image)
        Me.btnUser.Location = New System.Drawing.Point(775, 72)
        Me.btnUser.Name = "btnUser"
        Me.btnUser.Size = New System.Drawing.Size(19, 20)
        Me.btnUser.TabIndex = 129
        Me.btnUser.TabStop = False
        Me.btnUser.UseVisualStyleBackColor = False
        '
        'btnFileLocation
        '
        Me.btnFileLocation.BackColor = System.Drawing.Color.Transparent
        Me.btnFileLocation.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnFileLocation.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFileLocation.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFileLocation.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnFileLocation.Image = CType(resources.GetObject("btnFileLocation.Image"), System.Drawing.Image)
        Me.btnFileLocation.Location = New System.Drawing.Point(951, 73)
        Me.btnFileLocation.Name = "btnFileLocation"
        Me.btnFileLocation.Size = New System.Drawing.Size(19, 20)
        Me.btnFileLocation.TabIndex = 120
        Me.btnFileLocation.TabStop = False
        Me.btnFileLocation.UseVisualStyleBackColor = False
        '
        'txtNoAkta
        '
        Me.txtNoAkta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNoAkta.Location = New System.Drawing.Point(147, 40)
        Me.txtNoAkta.Name = "txtNoAkta"
        Me.txtNoAkta.Size = New System.Drawing.Size(135, 21)
        Me.txtNoAkta.TabIndex = 0
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.ForeColor = System.Drawing.Color.Black
        Me.Label23.Location = New System.Drawing.Point(12, 125)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(81, 13)
        Me.Label23.TabIndex = 27
        Me.Label23.Text = "Dokumen Client"
        '
        'cboJenisTransaksi
        '
        Me.cboJenisTransaksi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboJenisTransaksi.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboJenisTransaksi.FormattingEnabled = True
        Me.cboJenisTransaksi.Items.AddRange(New Object() {"AKTA JUAL BELI", "AKTA TUKAR MENUKAR", "AKTA HIBAH", "AKTA PEMASUKAN KE DALAM PERUSAHAAN (INBERG)", "AKTA PEMBAGIAN HAK BERSAMA", "AKTA PEMBERIAN HAK GUNA BANGUNAN / HAK PAKAI ATAS TANAH HAK MILIK", "AKTA PEMBERIAN HAK TANGGUNGAN"})
        Me.cboJenisTransaksi.Location = New System.Drawing.Point(147, 175)
        Me.cboJenisTransaksi.Name = "cboJenisTransaksi"
        Me.cboJenisTransaksi.Size = New System.Drawing.Size(333, 19)
        Me.cboJenisTransaksi.TabIndex = 4
        '
        'txtRemarks
        '
        Me.txtRemarks.BackColor = System.Drawing.Color.Azure
        Me.txtRemarks.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRemarks.Location = New System.Drawing.Point(648, 110)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtRemarks.Size = New System.Drawing.Size(319, 87)
        Me.txtRemarks.TabIndex = 7
        '
        'txtFileLocation
        '
        Me.txtFileLocation.BackColor = System.Drawing.Color.Azure
        Me.txtFileLocation.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFileLocation.Location = New System.Drawing.Point(875, 74)
        Me.txtFileLocation.Multiline = True
        Me.txtFileLocation.Name = "txtFileLocation"
        Me.txtFileLocation.ReadOnly = True
        Me.txtFileLocation.Size = New System.Drawing.Size(71, 20)
        Me.txtFileLocation.TabIndex = 6
        '
        'dtpTglPenyerahanDokumen
        '
        Me.dtpTglPenyerahanDokumen.CustomFormat = "dd/MM/yyyyy"
        Me.dtpTglPenyerahanDokumen.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTglPenyerahanDokumen.Location = New System.Drawing.Point(147, 110)
        Me.dtpTglPenyerahanDokumen.Name = "dtpTglPenyerahanDokumen"
        Me.dtpTglPenyerahanDokumen.Size = New System.Drawing.Size(95, 21)
        Me.dtpTglPenyerahanDokumen.TabIndex = 3
        Me.dtpTglPenyerahanDokumen.Value = New Date(2012, 1, 1, 0, 0, 0, 0)
        '
        'txtJenisNoHak
        '
        Me.txtJenisNoHak.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtJenisNoHak.Location = New System.Drawing.Point(648, 10)
        Me.txtJenisNoHak.Multiline = True
        Me.txtJenisNoHak.Name = "txtJenisNoHak"
        Me.txtJenisNoHak.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtJenisNoHak.Size = New System.Drawing.Size(319, 54)
        Me.txtJenisNoHak.TabIndex = 5
        '
        'txtPPATOrderID
        '
        Me.txtPPATOrderID.BackColor = System.Drawing.Color.LemonChiffon
        Me.txtPPATOrderID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPPATOrderID.Location = New System.Drawing.Point(147, 10)
        Me.txtPPATOrderID.Name = "txtPPATOrderID"
        Me.txtPPATOrderID.ReadOnly = True
        Me.txtPPATOrderID.Size = New System.Drawing.Size(135, 21)
        Me.txtPPATOrderID.TabIndex = 100
        Me.txtPPATOrderID.TabStop = False
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.ForeColor = System.Drawing.Color.Black
        Me.Label22.Location = New System.Drawing.Point(803, 77)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(66, 13)
        Me.Label22.TabIndex = 19
        Me.Label22.Text = "File Location"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(525, 110)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(48, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Remarks"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(525, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(89, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Jenis dan No Hak"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(12, 180)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Jenis Transaksi"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(12, 45)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "No Akta"
        '
        'lblRemarks
        '
        Me.lblRemarks.AutoSize = True
        Me.lblRemarks.BackColor = System.Drawing.Color.Transparent
        Me.lblRemarks.ForeColor = System.Drawing.Color.Black
        Me.lblRemarks.Location = New System.Drawing.Point(12, 110)
        Me.lblRemarks.Name = "lblRemarks"
        Me.lblRemarks.Size = New System.Drawing.Size(106, 13)
        Me.lblRemarks.TabIndex = 18
        Me.lblRemarks.Text = "Tanggal Penyerahan"
        '
        'lblPRDate
        '
        Me.lblPRDate.AutoSize = True
        Me.lblPRDate.BackColor = System.Drawing.Color.Transparent
        Me.lblPRDate.ForeColor = System.Drawing.Color.Black
        Me.lblPRDate.Location = New System.Drawing.Point(12, 75)
        Me.lblPRDate.Name = "lblPRDate"
        Me.lblPRDate.Size = New System.Drawing.Size(70, 13)
        Me.lblPRDate.TabIndex = 9
        Me.lblPRDate.Text = "Tanggal Akta"
        '
        'lblPPATOrderID
        '
        Me.lblPPATOrderID.AutoSize = True
        Me.lblPPATOrderID.BackColor = System.Drawing.Color.Transparent
        Me.lblPPATOrderID.ForeColor = System.Drawing.Color.Black
        Me.lblPPATOrderID.Location = New System.Drawing.Point(12, 15)
        Me.lblPPATOrderID.Name = "lblPPATOrderID"
        Me.lblPPATOrderID.Size = New System.Drawing.Size(77, 13)
        Me.lblPPATOrderID.TabIndex = 0
        Me.lblPPATOrderID.Text = "PPAT Order ID"
        '
        'dtpTanggalAkta
        '
        Me.dtpTanggalAkta.CustomFormat = "dd/MM/yyyyy"
        Me.dtpTanggalAkta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTanggalAkta.Location = New System.Drawing.Point(147, 70)
        Me.dtpTanggalAkta.Name = "dtpTanggalAkta"
        Me.dtpTanggalAkta.Size = New System.Drawing.Size(95, 21)
        Me.dtpTanggalAkta.TabIndex = 2
        Me.dtpTanggalAkta.Value = New Date(2012, 1, 1, 0, 0, 0, 0)
        '
        'tbTanahBangunan
        '
        Me.tbTanahBangunan.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tbTanahBangunan.Controls.Add(Me.Label15)
        Me.tbTanahBangunan.Controls.Add(Me.numHargaTransaksi)
        Me.tbTanahBangunan.Controls.Add(Me.Label14)
        Me.tbTanahBangunan.Controls.Add(Me.numLuasBangunan)
        Me.tbTanahBangunan.Controls.Add(Me.numLuasTanah)
        Me.tbTanahBangunan.Controls.Add(Me.txtLetakTanah)
        Me.tbTanahBangunan.Controls.Add(Me.Label6)
        Me.tbTanahBangunan.Controls.Add(Me.Label13)
        Me.tbTanahBangunan.Controls.Add(Me.Label5)
        Me.tbTanahBangunan.Location = New System.Drawing.Point(4, 25)
        Me.tbTanahBangunan.Name = "tbTanahBangunan"
        Me.tbTanahBangunan.Size = New System.Drawing.Size(980, 216)
        Me.tbTanahBangunan.TabIndex = 4
        Me.tbTanahBangunan.Text = "Tanah & Bangunan - F2"
        Me.tbTanahBangunan.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(535, 95)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(80, 13)
        Me.Label15.TabIndex = 197
        Me.Label15.Text = "Pengalihan Hak"
        '
        'numHargaTransaksi
        '
        Me.numHargaTransaksi.Location = New System.Drawing.Point(698, 75)
        Me.numHargaTransaksi.Maximum = New Decimal(New Integer() {-727379968, 232, 0, 0})
        Me.numHargaTransaksi.Name = "numHargaTransaksi"
        Me.numHargaTransaksi.Size = New System.Drawing.Size(211, 21)
        Me.numHargaTransaksi.TabIndex = 11
        Me.numHargaTransaksi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.numHargaTransaksi.ThousandsSeparator = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(535, 75)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(135, 13)
        Me.Label14.TabIndex = 195
        Me.Label14.Text = "Harga Transaksi Perolehan"
        '
        'numLuasBangunan
        '
        Me.numLuasBangunan.Location = New System.Drawing.Point(698, 40)
        Me.numLuasBangunan.Maximum = New Decimal(New Integer() {-727379968, 232, 0, 0})
        Me.numLuasBangunan.Name = "numLuasBangunan"
        Me.numLuasBangunan.Size = New System.Drawing.Size(113, 21)
        Me.numLuasBangunan.TabIndex = 10
        Me.numLuasBangunan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.numLuasBangunan.ThousandsSeparator = True
        '
        'numLuasTanah
        '
        Me.numLuasTanah.Location = New System.Drawing.Point(698, 10)
        Me.numLuasTanah.Maximum = New Decimal(New Integer() {-727379968, 232, 0, 0})
        Me.numLuasTanah.Name = "numLuasTanah"
        Me.numLuasTanah.Size = New System.Drawing.Size(113, 21)
        Me.numLuasTanah.TabIndex = 9
        Me.numLuasTanah.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.numLuasTanah.ThousandsSeparator = True
        '
        'txtLetakTanah
        '
        Me.txtLetakTanah.BackColor = System.Drawing.SystemColors.Window
        Me.txtLetakTanah.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLetakTanah.Location = New System.Drawing.Point(15, 40)
        Me.txtLetakTanah.Multiline = True
        Me.txtLetakTanah.Name = "txtLetakTanah"
        Me.txtLetakTanah.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtLetakTanah.Size = New System.Drawing.Size(471, 141)
        Me.txtLetakTanah.TabIndex = 8
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(535, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(87, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Luas Tanah (M2)"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(535, 45)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(105, 13)
        Me.Label13.TabIndex = 14
        Me.Label13.Text = "Luas Bangunan (M2)"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(12, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(138, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Letak Tanah dan Bangunan"
        '
        'tbSPPTPBB
        '
        Me.tbSPPTPBB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tbSPPTPBB.Controls.Add(Me.txtSPPTPBBNOPTahun)
        Me.tbSPPTPBB.Controls.Add(Me.numSPPTPBBNJOP)
        Me.tbSPPTPBB.Controls.Add(Me.Label17)
        Me.tbSPPTPBB.Controls.Add(Me.Label21)
        Me.tbSPPTPBB.Location = New System.Drawing.Point(4, 25)
        Me.tbSPPTPBB.Name = "tbSPPTPBB"
        Me.tbSPPTPBB.Size = New System.Drawing.Size(980, 216)
        Me.tbSPPTPBB.TabIndex = 5
        Me.tbSPPTPBB.Text = "SPPT PBB - F3"
        Me.tbSPPTPBB.UseVisualStyleBackColor = True
        '
        'txtSPPTPBBNOPTahun
        '
        Me.txtSPPTPBBNOPTahun.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSPPTPBBNOPTahun.Location = New System.Drawing.Point(147, 10)
        Me.txtSPPTPBBNOPTahun.Name = "txtSPPTPBBNOPTahun"
        Me.txtSPPTPBBNOPTahun.Size = New System.Drawing.Size(179, 21)
        Me.txtSPPTPBBNOPTahun.TabIndex = 12
        '
        'numSPPTPBBNJOP
        '
        Me.numSPPTPBBNJOP.Location = New System.Drawing.Point(147, 40)
        Me.numSPPTPBBNJOP.Maximum = New Decimal(New Integer() {-727379968, 232, 0, 0})
        Me.numSPPTPBBNJOP.Name = "numSPPTPBBNJOP"
        Me.numSPPTPBBNJOP.Size = New System.Drawing.Size(179, 21)
        Me.numSPPTPBBNJOP.TabIndex = 13
        Me.numSPPTPBBNJOP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.numSPPTPBBNJOP.ThousandsSeparator = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(12, 15)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(61, 13)
        Me.Label17.TabIndex = 195
        Me.Label17.Text = "NOP Tahun"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.ForeColor = System.Drawing.Color.Black
        Me.Label21.Location = New System.Drawing.Point(12, 45)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(33, 13)
        Me.Label21.TabIndex = 196
        Me.Label21.Text = "NJOP"
        '
        'tbSSP
        '
        Me.tbSSP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tbSSP.Controls.Add(Me.dtpSSPTanggal)
        Me.tbSSP.Controls.Add(Me.numSSPHarga)
        Me.tbSSP.Controls.Add(Me.Label1)
        Me.tbSSP.Controls.Add(Me.Label8)
        Me.tbSSP.Location = New System.Drawing.Point(4, 25)
        Me.tbSSP.Name = "tbSSP"
        Me.tbSSP.Size = New System.Drawing.Size(980, 216)
        Me.tbSSP.TabIndex = 2
        Me.tbSSP.Text = "SSP - F4"
        Me.tbSSP.UseVisualStyleBackColor = True
        '
        'dtpSSPTanggal
        '
        Me.dtpSSPTanggal.CustomFormat = "dd/MM/yyyyy"
        Me.dtpSSPTanggal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpSSPTanggal.Location = New System.Drawing.Point(147, 10)
        Me.dtpSSPTanggal.Name = "dtpSSPTanggal"
        Me.dtpSSPTanggal.Size = New System.Drawing.Size(95, 21)
        Me.dtpSSPTanggal.TabIndex = 14
        Me.dtpSSPTanggal.Value = New Date(2012, 1, 1, 0, 0, 0, 0)
        '
        'numSSPHarga
        '
        Me.numSSPHarga.Location = New System.Drawing.Point(147, 40)
        Me.numSSPHarga.Maximum = New Decimal(New Integer() {-727379968, 232, 0, 0})
        Me.numSSPHarga.Name = "numSSPHarga"
        Me.numSSPHarga.Size = New System.Drawing.Size(179, 21)
        Me.numSSPHarga.TabIndex = 15
        Me.numSSPHarga.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.numSSPHarga.ThousandsSeparator = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(12, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 198
        Me.Label1.Text = "Tanggal SSP"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(12, 45)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(57, 13)
        Me.Label8.TabIndex = 199
        Me.Label8.Text = "Harga SSP"
        '
        'tbSSB
        '
        Me.tbSSB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tbSSB.Controls.Add(Me.dtpSSBTanggal)
        Me.tbSSB.Controls.Add(Me.numSSBHarga)
        Me.tbSSB.Controls.Add(Me.Label11)
        Me.tbSSB.Controls.Add(Me.Label12)
        Me.tbSSB.Location = New System.Drawing.Point(4, 25)
        Me.tbSSB.Name = "tbSSB"
        Me.tbSSB.Padding = New System.Windows.Forms.Padding(3)
        Me.tbSSB.Size = New System.Drawing.Size(980, 216)
        Me.tbSSB.TabIndex = 1
        Me.tbSSB.Text = "SSB - F5"
        Me.tbSSB.UseVisualStyleBackColor = True
        '
        'dtpSSBTanggal
        '
        Me.dtpSSBTanggal.CustomFormat = "dd/MM/yyyyy"
        Me.dtpSSBTanggal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpSSBTanggal.Location = New System.Drawing.Point(147, 10)
        Me.dtpSSBTanggal.Name = "dtpSSBTanggal"
        Me.dtpSSBTanggal.Size = New System.Drawing.Size(95, 21)
        Me.dtpSSBTanggal.TabIndex = 16
        Me.dtpSSBTanggal.Value = New Date(2012, 1, 1, 0, 0, 0, 0)
        '
        'numSSBHarga
        '
        Me.numSSBHarga.Location = New System.Drawing.Point(147, 40)
        Me.numSSBHarga.Maximum = New Decimal(New Integer() {-727379968, 232, 0, 0})
        Me.numSSBHarga.Name = "numSSBHarga"
        Me.numSSBHarga.Size = New System.Drawing.Size(179, 21)
        Me.numSSBHarga.TabIndex = 17
        Me.numSSBHarga.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.numSSBHarga.ThousandsSeparator = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(12, 15)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(66, 13)
        Me.Label11.TabIndex = 202
        Me.Label11.Text = "Tanggal SSB"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(12, 45)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(57, 13)
        Me.Label12.TabIndex = 203
        Me.Label12.Text = "Harga SSB"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.grdClient2)
        Me.Panel1.Controls.Add(Me.ToolBarDetail2)
        Me.Panel1.Location = New System.Drawing.Point(10, 515)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(978, 171)
        Me.Panel1.TabIndex = 102
        '
        'grdClient2
        '
        Me.grdClient2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdClient2.EmbeddedNavigator.Buttons.Append.Enabled = False
        Me.grdClient2.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.grdClient2.EmbeddedNavigator.Buttons.CancelEdit.Enabled = False
        Me.grdClient2.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.grdClient2.EmbeddedNavigator.Buttons.Edit.Enabled = False
        Me.grdClient2.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.grdClient2.EmbeddedNavigator.Buttons.EndEdit.Enabled = False
        Me.grdClient2.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.grdClient2.EmbeddedNavigator.Buttons.NextPage.Enabled = False
        Me.grdClient2.EmbeddedNavigator.Buttons.NextPage.Visible = False
        Me.grdClient2.EmbeddedNavigator.Buttons.PrevPage.Enabled = False
        Me.grdClient2.EmbeddedNavigator.Buttons.PrevPage.Visible = False
        Me.grdClient2.EmbeddedNavigator.Buttons.Remove.Enabled = False
        Me.grdClient2.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.grdClient2.Location = New System.Drawing.Point(0, 28)
        Me.grdClient2.MainView = Me.grdItemView2
        Me.grdClient2.Name = "grdClient2"
        Me.grdClient2.Size = New System.Drawing.Size(978, 143)
        Me.grdClient2.TabIndex = 3
        Me.grdClient2.TabStop = False
        Me.grdClient2.UseEmbeddedNavigator = True
        Me.grdClient2.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdItemView2})
        '
        'grdItemView2
        '
        Me.grdItemView2.DetailHeight = 150
        Me.grdItemView2.GridControl = Me.grdClient2
        Me.grdItemView2.Name = "grdItemView2"
        Me.grdItemView2.OptionsCustomization.AllowColumnMoving = False
        Me.grdItemView2.OptionsCustomization.AllowGroup = False
        Me.grdItemView2.OptionsView.ColumnAutoWidth = False
        Me.grdItemView2.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.grdItemView2.OptionsView.ShowGroupPanel = False
        '
        'ToolBarDetail2
        '
        Me.ToolBarDetail2.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.ToolBarDetail2.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.BarDetNew2, Me.BarDetDetail2, Me.BarDetDelete2})
        Me.ToolBarDetail2.DropDownArrows = True
        Me.ToolBarDetail2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolBarDetail2.Location = New System.Drawing.Point(0, 0)
        Me.ToolBarDetail2.Name = "ToolBarDetail2"
        Me.ToolBarDetail2.ShowToolTips = True
        Me.ToolBarDetail2.Size = New System.Drawing.Size(978, 28)
        Me.ToolBarDetail2.TabIndex = 0
        Me.ToolBarDetail2.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right
        '
        'BarDetNew2
        '
        Me.BarDetNew2.Name = "BarDetNew2"
        Me.BarDetNew2.Text = "New"
        '
        'BarDetDetail2
        '
        Me.BarDetDetail2.Name = "BarDetDetail2"
        Me.BarDetDetail2.Text = "Detail"
        '
        'BarDetDelete2
        '
        Me.BarDetDelete2.Name = "BarDetDelete2"
        Me.BarDetDelete2.Text = "Delete"
        '
        'Label9
        '
        Me.Label9.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.BackColor = System.Drawing.Color.CadetBlue
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(7, 490)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(1041, 22)
        Me.Label9.TabIndex = 101
        Me.Label9.Text = "« Pihak II (Pihak yang menerima)"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'StatusStrip
        '
        Me.StatusStrip.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripEmpty, Me.ToolStripStatus, Me.ToolStripDraftBy, Me.ToolStripStatusLabel3, Me.ToolStripProcessBy, Me.ToolStripProcessDate, Me.ToolStripBPNFinishBy, Me.ToolStripBPNFinishDate, Me.ToolStripCompletedBy, Me.ToolStripCompletedDate})
        Me.StatusStrip.Location = New System.Drawing.Point(3, 689)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(991, 22)
        Me.StatusStrip.TabIndex = 118
        Me.StatusStrip.Text = "StatusStrip1"
        '
        'ToolStripEmpty
        '
        Me.ToolStripEmpty.Name = "ToolStripEmpty"
        Me.ToolStripEmpty.Size = New System.Drawing.Size(976, 17)
        Me.ToolStripEmpty.Spring = True
        '
        'ToolStripStatus
        '
        Me.ToolStripStatus.ActiveLinkColor = System.Drawing.Color.Red
        Me.ToolStripStatus.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatus.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.ToolStripStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatus.LinkColor = System.Drawing.Color.Blue
        Me.ToolStripStatus.Name = "ToolStripStatus"
        Me.ToolStripStatus.Size = New System.Drawing.Size(57, 17)
        Me.ToolStripStatus.Text = "Status : "
        Me.ToolStripStatus.Visible = False
        '
        'ToolStripDraftBy
        '
        Me.ToolStripDraftBy.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ToolStripDraftBy.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripDraftBy.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.ToolStripDraftBy.ImageTransparentColor = System.Drawing.Color.White
        Me.ToolStripDraftBy.Name = "ToolStripDraftBy"
        Me.ToolStripDraftBy.Size = New System.Drawing.Size(51, 17)
        Me.ToolStripDraftBy.Text = "Draft By :"
        Me.ToolStripDraftBy.Visible = False
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(0, 17)
        '
        'ToolStripProcessBy
        '
        Me.ToolStripProcessBy.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ToolStripProcessBy.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripProcessBy.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.ToolStripProcessBy.Name = "ToolStripProcessBy"
        Me.ToolStripProcessBy.Size = New System.Drawing.Size(61, 17)
        Me.ToolStripProcessBy.Text = "Process By :"
        Me.ToolStripProcessBy.Visible = False
        '
        'ToolStripProcessDate
        '
        Me.ToolStripProcessDate.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ToolStripProcessDate.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripProcessDate.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.ToolStripProcessDate.Name = "ToolStripProcessDate"
        Me.ToolStripProcessDate.Size = New System.Drawing.Size(66, 17)
        Me.ToolStripProcessDate.Text = "ProcessDate :"
        Me.ToolStripProcessDate.Visible = False
        '
        'ToolStripBPNFinishBy
        '
        Me.ToolStripBPNFinishBy.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ToolStripBPNFinishBy.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripBPNFinishBy.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.ToolStripBPNFinishBy.Name = "ToolStripBPNFinishBy"
        Me.ToolStripBPNFinishBy.Size = New System.Drawing.Size(76, 17)
        Me.ToolStripBPNFinishBy.Text = "BPN Finish By :"
        Me.ToolStripBPNFinishBy.Visible = False
        '
        'ToolStripBPNFinishDate
        '
        Me.ToolStripBPNFinishDate.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ToolStripBPNFinishDate.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripBPNFinishDate.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.ToolStripBPNFinishDate.Name = "ToolStripBPNFinishDate"
        Me.ToolStripBPNFinishDate.Size = New System.Drawing.Size(84, 17)
        Me.ToolStripBPNFinishDate.Text = "BPN Finish Date :"
        Me.ToolStripBPNFinishDate.Visible = False
        '
        'ToolStripCompletedBy
        '
        Me.ToolStripCompletedBy.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ToolStripCompletedBy.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripCompletedBy.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.ToolStripCompletedBy.Name = "ToolStripCompletedBy"
        Me.ToolStripCompletedBy.Size = New System.Drawing.Size(75, 17)
        Me.ToolStripCompletedBy.Text = "Completed By :"
        Me.ToolStripCompletedBy.Visible = False
        '
        'ToolStripCompletedDate
        '
        Me.ToolStripCompletedDate.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ToolStripCompletedDate.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripCompletedDate.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.ToolStripCompletedDate.Name = "ToolStripCompletedDate"
        Me.ToolStripCompletedDate.Size = New System.Drawing.Size(83, 17)
        Me.ToolStripCompletedDate.Text = "Completed Date :"
        Me.ToolStripCompletedDate.Visible = False
        '
        'lblItem
        '
        Me.lblItem.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblItem.BackColor = System.Drawing.Color.CadetBlue
        Me.lblItem.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblItem.ForeColor = System.Drawing.Color.White
        Me.lblItem.Location = New System.Drawing.Point(7, 289)
        Me.lblItem.Name = "lblItem"
        Me.lblItem.Size = New System.Drawing.Size(1041, 22)
        Me.lblItem.TabIndex = 2
        Me.lblItem.Text = "« Pihak I (Pihak yang mengalihkan)"
        Me.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblHead
        '
        Me.lblHead.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblHead.BackColor = System.Drawing.Color.CadetBlue
        Me.lblHead.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHead.ForeColor = System.Drawing.Color.White
        Me.lblHead.Location = New System.Drawing.Point(8, 16)
        Me.lblHead.Name = "lblHead"
        Me.lblHead.Size = New System.Drawing.Size(1042, 22)
        Me.lblHead.TabIndex = 0
        Me.lblHead.Text = "« PPAT Order"
        Me.lblHead.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolBar
        '
        Me.ToolBar.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.ToolBar.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.BarSave, Me.BarClose})
        Me.ToolBar.DropDownArrows = True
        Me.ToolBar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolBar.Location = New System.Drawing.Point(0, 0)
        Me.ToolBar.Name = "ToolBar"
        Me.ToolBar.ShowToolTips = True
        Me.ToolBar.Size = New System.Drawing.Size(997, 28)
        Me.ToolBar.TabIndex = 2
        Me.ToolBar.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right
        '
        'BarSave
        '
        Me.BarSave.Name = "BarSave"
        Me.BarSave.Text = "Save"
        '
        'BarClose
        '
        Me.BarClose.Name = "BarClose"
        Me.BarClose.Text = "Close"
        '
        'GridView1
        '
        Me.GridView1.Name = "GridView1"
        '
        'GridView2
        '
        Me.GridView2.Name = "GridView2"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(221, 147)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(25, 13)
        Me.Label16.TabIndex = 133
        Me.Label16.Text = "hari"
        '
        'numExpInterval
        '
        Me.numExpInterval.Location = New System.Drawing.Point(147, 145)
        Me.numExpInterval.Name = "numExpInterval"
        Me.numExpInterval.Size = New System.Drawing.Size(68, 21)
        Me.numExpInterval.TabIndex = 132
        Me.numExpInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.numExpInterval.Value = New Decimal(New Integer() {30, 0, 0, 0})
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(12, 147)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(84, 13)
        Me.Label18.TabIndex = 131
        Me.Label18.Text = "Expired Interval"
        '
        'frmTraPPATOrderDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(997, 742)
        Me.Controls.Add(Me.gbDetail)
        Me.Controls.Add(Me.ToolBar)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmTraPPATOrderDet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "PPAT Order Detail"
        Me.pnlDetail.ResumeLayout(False)
        Me.pnlDetail.PerformLayout()
        CType(Me.grdClient1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdItemView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDetail.ResumeLayout(False)
        Me.gbDetail.PerformLayout()
        Me.tbcPPAT.ResumeLayout(False)
        Me.tbMain.ResumeLayout(False)
        Me.tbMain.PerformLayout()
        Me.tbTanahBangunan.ResumeLayout(False)
        Me.tbTanahBangunan.PerformLayout()
        CType(Me.numHargaTransaksi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numLuasBangunan, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numLuasTanah, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbSPPTPBB.ResumeLayout(False)
        Me.tbSPPTPBB.PerformLayout()
        CType(Me.numSPPTPBBNJOP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbSSP.ResumeLayout(False)
        Me.tbSSP.PerformLayout()
        CType(Me.numSSPHarga, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbSSB.ResumeLayout(False)
        Me.tbSSB.PerformLayout()
        CType(Me.numSSBHarga, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.grdClient2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdItemView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numExpInterval, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlDetail As System.Windows.Forms.Panel
    Friend WithEvents grdClient1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdItemView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ToolBarDetail As System.Windows.Forms.ToolBar
    Friend WithEvents BarDetNew As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarDetDetail As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarDetDelete As System.Windows.Forms.ToolBarButton
    Friend WithEvents gbDetail As System.Windows.Forms.GroupBox
    Friend WithEvents lblItem As System.Windows.Forms.Label
    Friend WithEvents lblHead As System.Windows.Forms.Label
    Friend WithEvents ToolBar As System.Windows.Forms.ToolBar
    Friend WithEvents BarSave As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarClose As System.Windows.Forms.ToolBarButton
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripEmpty As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripDraftBy As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents grdClient2 As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdItemView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ToolBarDetail2 As System.Windows.Forms.ToolBar
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents BarDetNew2 As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarDetDetail2 As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarDetDelete2 As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolStripProcessBy As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripProcessDate As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripCompletedBy As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripCompletedDate As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tbcPPAT As System.Windows.Forms.TabControl
    Friend WithEvents tbMain As System.Windows.Forms.TabPage
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblRemarks As System.Windows.Forms.Label
    Friend WithEvents lblPRDate As System.Windows.Forms.Label
    Friend WithEvents lblPPATOrderID As System.Windows.Forms.Label
    Friend WithEvents dtpTanggalAkta As System.Windows.Forms.DateTimePicker
    Friend WithEvents tbTanahBangunan As System.Windows.Forms.TabPage
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tbSPPTPBB As System.Windows.Forms.TabPage
    Friend WithEvents tbSSP As System.Windows.Forms.TabPage
    Friend WithEvents tbSSB As System.Windows.Forms.TabPage
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents dtpTglPenyerahanDokumen As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtJenisNoHak As System.Windows.Forms.TextBox
    Friend WithEvents txtPPATOrderID As System.Windows.Forms.TextBox
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents txtFileLocation As System.Windows.Forms.TextBox
    Friend WithEvents cboJenisTransaksi As System.Windows.Forms.ComboBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtLetakTanah As NMS.usTextBox
    Friend WithEvents numLuasBangunan As NMS.usNumeric
    Friend WithEvents numLuasTanah As NMS.usNumeric
    Friend WithEvents txtSPPTPBBNOPTahun As System.Windows.Forms.TextBox
    Friend WithEvents numSPPTPBBNJOP As NMS.usNumeric
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents dtpSSPTanggal As System.Windows.Forms.DateTimePicker
    Friend WithEvents numSSPHarga As NMS.usNumeric
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dtpSSBTanggal As System.Windows.Forms.DateTimePicker
    Friend WithEvents numSSBHarga As NMS.usNumeric
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents numHargaTransaksi As NMS.usNumeric
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents ToolStripBPNFinishBy As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripBPNFinishDate As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents txtNoAkta As NMS.usTextBox
    Friend WithEvents btnFileLocation As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtProcessUserID As NMS.usTextBox
    Friend WithEvents btnUser As System.Windows.Forms.Button
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents numExpInterval As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label18 As System.Windows.Forms.Label
End Class

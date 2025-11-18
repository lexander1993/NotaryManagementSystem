<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTraCertificateOrderDet
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTraCertificateOrderDet))
        Me.pnlDetail = New System.Windows.Forms.Panel()
        Me.grdClient1 = New DevExpress.XtraGrid.GridControl()
        Me.grdItemView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ToolBarDetail = New System.Windows.Forms.ToolBar()
        Me.BarDetNew = New System.Windows.Forms.ToolBarButton()
        Me.BarDetDelete = New System.Windows.Forms.ToolBarButton()
        Me.gbDetail = New System.Windows.Forms.GroupBox()
        Me.tbcPPAT = New System.Windows.Forms.TabControl()
        Me.tbMain = New System.Windows.Forms.TabPage()
        Me.btnFileLocation = New System.Windows.Forms.Button()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtRemarks = New System.Windows.Forms.TextBox()
        Me.txtFileLocation = New System.Windows.Forms.TextBox()
        Me.dtpTglPenyerahanDokumen = New System.Windows.Forms.DateTimePicker()
        Me.txtJenisNoHak = New System.Windows.Forms.TextBox()
        Me.txtCertificateOrderID = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblRemarks = New System.Windows.Forms.Label()
        Me.lblPPATOrderID = New System.Windows.Forms.Label()
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
        Me.lblItem = New System.Windows.Forms.Label()
        Me.lblHead = New System.Windows.Forms.Label()
        Me.ToolBar = New System.Windows.Forms.ToolBar()
        Me.BarSave = New System.Windows.Forms.ToolBarButton()
        Me.BarClose = New System.Windows.Forms.ToolBarButton()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpTglPengembalianDokumen = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
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
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlDetail
        '
        Me.pnlDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlDetail.Controls.Add(Me.grdClient1)
        Me.pnlDetail.Controls.Add(Me.ToolBarDetail)
        Me.pnlDetail.Location = New System.Drawing.Point(10, 357)
        Me.pnlDetail.Name = "pnlDetail"
        Me.pnlDetail.Size = New System.Drawing.Size(978, 329)
        Me.pnlDetail.TabIndex = 100
        '
        'grdClient1
        '
        Me.grdClient1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdClient1.Location = New System.Drawing.Point(0, 28)
        Me.grdClient1.MainView = Me.grdItemView
        Me.grdClient1.Name = "grdClient1"
        Me.grdClient1.Size = New System.Drawing.Size(978, 301)
        Me.grdClient1.TabIndex = 1
        Me.grdClient1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdItemView})
        '
        'grdItemView
        '
        Me.grdItemView.GridControl = Me.grdClient1
        Me.grdItemView.Name = "grdItemView"
        Me.grdItemView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.grdItemView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[True]
        '
        'ToolBarDetail
        '
        Me.ToolBarDetail.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.ToolBarDetail.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.BarDetNew, Me.BarDetDelete})
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
        'BarDetDelete
        '
        Me.BarDetDelete.Name = "BarDetDelete"
        Me.BarDetDelete.Text = "Delete"
        '
        'gbDetail
        '
        Me.gbDetail.Controls.Add(Me.tbcPPAT)
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
        Me.tbcPPAT.Location = New System.Drawing.Point(6, 41)
        Me.tbcPPAT.Name = "tbcPPAT"
        Me.tbcPPAT.SelectedIndex = 0
        Me.tbcPPAT.Size = New System.Drawing.Size(988, 289)
        Me.tbcPPAT.TabIndex = 1
        Me.tbcPPAT.TabStop = False
        '
        'tbMain
        '
        Me.tbMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tbMain.Controls.Add(Me.Label1)
        Me.tbMain.Controls.Add(Me.dtpTglPengembalianDokumen)
        Me.tbMain.Controls.Add(Me.Label2)
        Me.tbMain.Controls.Add(Me.btnFileLocation)
        Me.tbMain.Controls.Add(Me.Label23)
        Me.tbMain.Controls.Add(Me.txtRemarks)
        Me.tbMain.Controls.Add(Me.txtFileLocation)
        Me.tbMain.Controls.Add(Me.dtpTglPenyerahanDokumen)
        Me.tbMain.Controls.Add(Me.txtJenisNoHak)
        Me.tbMain.Controls.Add(Me.txtCertificateOrderID)
        Me.tbMain.Controls.Add(Me.Label22)
        Me.tbMain.Controls.Add(Me.Label7)
        Me.tbMain.Controls.Add(Me.Label4)
        Me.tbMain.Controls.Add(Me.lblRemarks)
        Me.tbMain.Controls.Add(Me.lblPPATOrderID)
        Me.tbMain.Location = New System.Drawing.Point(4, 25)
        Me.tbMain.Name = "tbMain"
        Me.tbMain.Padding = New System.Windows.Forms.Padding(3)
        Me.tbMain.Size = New System.Drawing.Size(980, 260)
        Me.tbMain.TabIndex = 0
        Me.tbMain.Text = "Main - F1"
        Me.tbMain.UseVisualStyleBackColor = True
        '
        'btnFileLocation
        '
        Me.btnFileLocation.BackColor = System.Drawing.Color.Transparent
        Me.btnFileLocation.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnFileLocation.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFileLocation.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFileLocation.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnFileLocation.Image = CType(resources.GetObject("btnFileLocation.Image"), System.Drawing.Image)
        Me.btnFileLocation.Location = New System.Drawing.Point(863, 10)
        Me.btnFileLocation.Name = "btnFileLocation"
        Me.btnFileLocation.Size = New System.Drawing.Size(19, 20)
        Me.btnFileLocation.TabIndex = 120
        Me.btnFileLocation.TabStop = False
        Me.btnFileLocation.UseVisualStyleBackColor = False
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.ForeColor = System.Drawing.Color.Black
        Me.Label23.Location = New System.Drawing.Point(12, 58)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(81, 13)
        Me.Label23.TabIndex = 27
        Me.Label23.Text = "Dokumen Client"
        '
        'txtRemarks
        '
        Me.txtRemarks.BackColor = System.Drawing.Color.Azure
        Me.txtRemarks.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRemarks.Location = New System.Drawing.Point(584, 43)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtRemarks.Size = New System.Drawing.Size(386, 198)
        Me.txtRemarks.TabIndex = 7
        '
        'txtFileLocation
        '
        Me.txtFileLocation.BackColor = System.Drawing.Color.Azure
        Me.txtFileLocation.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFileLocation.Location = New System.Drawing.Point(584, 11)
        Me.txtFileLocation.Multiline = True
        Me.txtFileLocation.Name = "txtFileLocation"
        Me.txtFileLocation.ReadOnly = True
        Me.txtFileLocation.Size = New System.Drawing.Size(273, 20)
        Me.txtFileLocation.TabIndex = 6
        Me.txtFileLocation.TabStop = False
        '
        'dtpTglPenyerahanDokumen
        '
        Me.dtpTglPenyerahanDokumen.CustomFormat = "dd/MM/yyyyy"
        Me.dtpTglPenyerahanDokumen.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTglPenyerahanDokumen.Location = New System.Drawing.Point(147, 43)
        Me.dtpTglPenyerahanDokumen.Name = "dtpTglPenyerahanDokumen"
        Me.dtpTglPenyerahanDokumen.Size = New System.Drawing.Size(95, 21)
        Me.dtpTglPenyerahanDokumen.TabIndex = 3
        Me.dtpTglPenyerahanDokumen.Value = New Date(2012, 1, 1, 0, 0, 0, 0)
        '
        'txtJenisNoHak
        '
        Me.txtJenisNoHak.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtJenisNoHak.Location = New System.Drawing.Point(147, 125)
        Me.txtJenisNoHak.Multiline = True
        Me.txtJenisNoHak.Name = "txtJenisNoHak"
        Me.txtJenisNoHak.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtJenisNoHak.Size = New System.Drawing.Size(350, 116)
        Me.txtJenisNoHak.TabIndex = 5
        '
        'txtCertificateOrderID
        '
        Me.txtCertificateOrderID.BackColor = System.Drawing.Color.LemonChiffon
        Me.txtCertificateOrderID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCertificateOrderID.Location = New System.Drawing.Point(147, 10)
        Me.txtCertificateOrderID.Name = "txtCertificateOrderID"
        Me.txtCertificateOrderID.ReadOnly = True
        Me.txtCertificateOrderID.Size = New System.Drawing.Size(135, 21)
        Me.txtCertificateOrderID.TabIndex = 100
        Me.txtCertificateOrderID.TabStop = False
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.ForeColor = System.Drawing.Color.Black
        Me.Label22.Location = New System.Drawing.Point(515, 15)
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
        Me.Label7.Location = New System.Drawing.Point(515, 46)
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
        Me.Label4.Location = New System.Drawing.Point(12, 125)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(89, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Jenis dan No Hak"
        '
        'lblRemarks
        '
        Me.lblRemarks.AutoSize = True
        Me.lblRemarks.BackColor = System.Drawing.Color.Transparent
        Me.lblRemarks.ForeColor = System.Drawing.Color.Black
        Me.lblRemarks.Location = New System.Drawing.Point(12, 43)
        Me.lblRemarks.Name = "lblRemarks"
        Me.lblRemarks.Size = New System.Drawing.Size(106, 13)
        Me.lblRemarks.TabIndex = 18
        Me.lblRemarks.Text = "Tanggal Penyerahan"
        '
        'lblPPATOrderID
        '
        Me.lblPPATOrderID.AutoSize = True
        Me.lblPPATOrderID.BackColor = System.Drawing.Color.Transparent
        Me.lblPPATOrderID.ForeColor = System.Drawing.Color.Black
        Me.lblPPATOrderID.Location = New System.Drawing.Point(12, 15)
        Me.lblPPATOrderID.Name = "lblPPATOrderID"
        Me.lblPPATOrderID.Size = New System.Drawing.Size(102, 13)
        Me.lblPPATOrderID.TabIndex = 0
        Me.lblPPATOrderID.Text = "Certificate Order ID"
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
        Me.tbTanahBangunan.Size = New System.Drawing.Size(980, 260)
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
        'lblItem
        '
        Me.lblItem.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblItem.BackColor = System.Drawing.Color.CadetBlue
        Me.lblItem.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblItem.ForeColor = System.Drawing.Color.White
        Me.lblItem.Location = New System.Drawing.Point(7, 332)
        Me.lblItem.Name = "lblItem"
        Me.lblItem.Size = New System.Drawing.Size(1041, 22)
        Me.lblItem.TabIndex = 2
        Me.lblItem.Text = "« Process ( Kantor -> BPN)    BPN Finish ( BPN ->Kantor)"
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
        Me.lblHead.Text = "« Certificate Order"
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(12, 96)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 13)
        Me.Label1.TabIndex = 123
        Me.Label1.Text = "Dokumen Client"
        '
        'dtpTglPengembalianDokumen
        '
        Me.dtpTglPengembalianDokumen.CustomFormat = "dd/MM/yyyyy"
        Me.dtpTglPengembalianDokumen.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTglPengembalianDokumen.Location = New System.Drawing.Point(147, 81)
        Me.dtpTglPengembalianDokumen.Name = "dtpTglPengembalianDokumen"
        Me.dtpTglPengembalianDokumen.Size = New System.Drawing.Size(95, 21)
        Me.dtpTglPengembalianDokumen.TabIndex = 121
        Me.dtpTglPengembalianDokumen.Value = New Date(2012, 1, 1, 0, 0, 0, 0)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(12, 81)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(114, 13)
        Me.Label2.TabIndex = 122
        Me.Label2.Text = "Tanggal Pengembalian"
        '
        'frmTraCertificateOrderDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(997, 742)
        Me.Controls.Add(Me.gbDetail)
        Me.Controls.Add(Me.ToolBar)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmTraCertificateOrderDet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Certificate Order Detail"
        Me.pnlDetail.ResumeLayout(False)
        Me.pnlDetail.PerformLayout()
        CType(Me.grdClient1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdItemView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDetail.ResumeLayout(False)
        Me.tbcPPAT.ResumeLayout(False)
        Me.tbMain.ResumeLayout(False)
        Me.tbMain.PerformLayout()
        Me.tbTanahBangunan.ResumeLayout(False)
        Me.tbTanahBangunan.PerformLayout()
        CType(Me.numHargaTransaksi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numLuasBangunan, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numLuasTanah, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlDetail As System.Windows.Forms.Panel
    Friend WithEvents ToolBarDetail As System.Windows.Forms.ToolBar
    Friend WithEvents BarDetNew As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarDetDelete As System.Windows.Forms.ToolBarButton
    Friend WithEvents gbDetail As System.Windows.Forms.GroupBox
    Friend WithEvents lblItem As System.Windows.Forms.Label
    Friend WithEvents lblHead As System.Windows.Forms.Label
    Friend WithEvents ToolBar As System.Windows.Forms.ToolBar
    Friend WithEvents BarSave As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarClose As System.Windows.Forms.ToolBarButton
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents tbcPPAT As System.Windows.Forms.TabControl
    Friend WithEvents tbMain As System.Windows.Forms.TabPage
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblRemarks As System.Windows.Forms.Label
    Friend WithEvents lblPPATOrderID As System.Windows.Forms.Label
    Friend WithEvents tbTanahBangunan As System.Windows.Forms.TabPage
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents dtpTglPenyerahanDokumen As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtJenisNoHak As System.Windows.Forms.TextBox
    Friend WithEvents txtCertificateOrderID As System.Windows.Forms.TextBox
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents txtFileLocation As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtLetakTanah As NMS.usTextBox
    Friend WithEvents numLuasBangunan As NMS.usNumeric
    Friend WithEvents numLuasTanah As NMS.usNumeric
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents numHargaTransaksi As NMS.usNumeric
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents btnFileLocation As System.Windows.Forms.Button
    Friend WithEvents grdClient1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdItemView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpTglPengembalianDokumen As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class

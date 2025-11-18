<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTraPaymentOutDet
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTraPaymentOutDet))
        Me.gbDetail = New System.Windows.Forms.GroupBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txtPaymentOutID = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnNoAkta = New System.Windows.Forms.Button()
        Me.numBiaya = New System.Windows.Forms.NumericUpDown()
        Me.txtNamaClient = New System.Windows.Forms.TextBox()
        Me.txtNoAkta = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtPaymentInID = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.dtpTanggalKwitansi = New System.Windows.Forms.DateTimePicker()
        Me.txtRemarks = New System.Windows.Forms.TextBox()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.ToolStripEmpty = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripCreatedDate = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripModifiedDate = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblHead = New System.Windows.Forms.Label()
        Me.ToolBar = New System.Windows.Forms.ToolBar()
        Me.BarSave = New System.Windows.Forms.ToolBarButton()
        Me.BarClose = New System.Windows.Forms.ToolBarButton()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.cboStatus = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.numExpInterval = New System.Windows.Forms.NumericUpDown()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.gbDetail.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.numBiaya, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip.SuspendLayout()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numExpInterval, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbDetail
        '
        Me.gbDetail.Controls.Add(Me.Panel2)
        Me.gbDetail.Controls.Add(Me.StatusStrip)
        Me.gbDetail.Controls.Add(Me.lblHead)
        Me.gbDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbDetail.Location = New System.Drawing.Point(0, 28)
        Me.gbDetail.Name = "gbDetail"
        Me.gbDetail.Size = New System.Drawing.Size(790, 469)
        Me.gbDetail.TabIndex = 3
        Me.gbDetail.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.cboStatus)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.Label15)
        Me.Panel2.Controls.Add(Me.numExpInterval)
        Me.Panel2.Controls.Add(Me.Label13)
        Me.Panel2.Controls.Add(Me.txtPaymentOutID)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.btnNoAkta)
        Me.Panel2.Controls.Add(Me.numBiaya)
        Me.Panel2.Controls.Add(Me.txtNamaClient)
        Me.Panel2.Controls.Add(Me.txtNoAkta)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.txtPaymentInID)
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Controls.Add(Me.dtpTanggalKwitansi)
        Me.Panel2.Controls.Add(Me.txtRemarks)
        Me.Panel2.Location = New System.Drawing.Point(8, 41)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(779, 398)
        Me.Panel2.TabIndex = 148
        '
        'txtPaymentOutID
        '
        Me.txtPaymentOutID.BackColor = System.Drawing.SystemColors.Info
        Me.txtPaymentOutID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPaymentOutID.Location = New System.Drawing.Point(193, 10)
        Me.txtPaymentOutID.Name = "txtPaymentOutID"
        Me.txtPaymentOutID.ReadOnly = True
        Me.txtPaymentOutID.Size = New System.Drawing.Size(121, 21)
        Me.txtPaymentOutID.TabIndex = 136
        Me.txtPaymentOutID.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(15, 13)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 13)
        Me.Label5.TabIndex = 137
        Me.Label5.Text = "Payment Out ID"
        '
        'btnNoAkta
        '
        Me.btnNoAkta.BackColor = System.Drawing.Color.Transparent
        Me.btnNoAkta.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNoAkta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNoAkta.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNoAkta.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnNoAkta.Image = CType(resources.GetObject("btnNoAkta.Image"), System.Drawing.Image)
        Me.btnNoAkta.Location = New System.Drawing.Point(320, 39)
        Me.btnNoAkta.Name = "btnNoAkta"
        Me.btnNoAkta.Size = New System.Drawing.Size(19, 20)
        Me.btnNoAkta.TabIndex = 135
        Me.btnNoAkta.TabStop = False
        Me.btnNoAkta.UseVisualStyleBackColor = False
        '
        'numBiaya
        '
        Me.numBiaya.Location = New System.Drawing.Point(194, 153)
        Me.numBiaya.Maximum = New Decimal(New Integer() {1316134912, 2328, 0, 0})
        Me.numBiaya.Name = "numBiaya"
        Me.numBiaya.Size = New System.Drawing.Size(156, 21)
        Me.numBiaya.TabIndex = 5
        Me.numBiaya.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.numBiaya.ThousandsSeparator = True
        '
        'txtNamaClient
        '
        Me.txtNamaClient.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNamaClient.Location = New System.Drawing.Point(193, 92)
        Me.txtNamaClient.Name = "txtNamaClient"
        Me.txtNamaClient.Size = New System.Drawing.Size(264, 21)
        Me.txtNamaClient.TabIndex = 3
        '
        'txtNoAkta
        '
        Me.txtNoAkta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNoAkta.Location = New System.Drawing.Point(193, 65)
        Me.txtNoAkta.Name = "txtNoAkta"
        Me.txtNoAkta.Size = New System.Drawing.Size(121, 21)
        Me.txtNoAkta.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 239)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 134
        Me.Label2.Text = "Remarks"
        '
        'txtPaymentInID
        '
        Me.txtPaymentInID.BackColor = System.Drawing.SystemColors.Window
        Me.txtPaymentInID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPaymentInID.Location = New System.Drawing.Point(193, 38)
        Me.txtPaymentInID.Name = "txtPaymentInID"
        Me.txtPaymentInID.Size = New System.Drawing.Size(121, 21)
        Me.txtPaymentInID.TabIndex = 1
        Me.txtPaymentInID.TabStop = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(15, 95)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(139, 13)
        Me.Label12.TabIndex = 129
        Me.Label12.Text = "Nama Pihak Pengurus Surat"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 71)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 13)
        Me.Label4.TabIndex = 111
        Me.Label4.Text = "No Akta"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 155)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 13)
        Me.Label1.TabIndex = 133
        Me.Label1.Text = "Biaya"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 41)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 13)
        Me.Label3.TabIndex = 110
        Me.Label3.Text = "Payment In ID"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(15, 128)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(87, 13)
        Me.Label11.TabIndex = 130
        Me.Label11.Text = "Tanggal Kwitansi"
        '
        'dtpTanggalKwitansi
        '
        Me.dtpTanggalKwitansi.CustomFormat = "dd/MM/yyyy"
        Me.dtpTanggalKwitansi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpTanggalKwitansi.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTanggalKwitansi.Location = New System.Drawing.Point(193, 124)
        Me.dtpTanggalKwitansi.Name = "dtpTanggalKwitansi"
        Me.dtpTanggalKwitansi.Size = New System.Drawing.Size(99, 21)
        Me.dtpTanggalKwitansi.TabIndex = 4
        Me.dtpTanggalKwitansi.Value = New Date(2014, 9, 16, 0, 0, 0, 0)
        '
        'txtRemarks
        '
        Me.txtRemarks.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRemarks.Location = New System.Drawing.Point(193, 239)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtRemarks.Size = New System.Drawing.Size(487, 146)
        Me.txtRemarks.TabIndex = 6
        '
        'StatusStrip
        '
        Me.StatusStrip.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripEmpty, Me.ToolStripStatusLabel3, Me.ToolStripCreatedDate, Me.ToolStripModifiedDate})
        Me.StatusStrip.Location = New System.Drawing.Point(3, 444)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(784, 22)
        Me.StatusStrip.TabIndex = 118
        Me.StatusStrip.Text = "StatusStrip1"
        '
        'ToolStripEmpty
        '
        Me.ToolStripEmpty.Name = "ToolStripEmpty"
        Me.ToolStripEmpty.Size = New System.Drawing.Size(769, 17)
        Me.ToolStripEmpty.Spring = True
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(0, 17)
        '
        'ToolStripCreatedDate
        '
        Me.ToolStripCreatedDate.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ToolStripCreatedDate.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripCreatedDate.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.ToolStripCreatedDate.Name = "ToolStripCreatedDate"
        Me.ToolStripCreatedDate.Size = New System.Drawing.Size(74, 17)
        Me.ToolStripCreatedDate.Text = "Created Date : "
        Me.ToolStripCreatedDate.Visible = False
        '
        'ToolStripModifiedDate
        '
        Me.ToolStripModifiedDate.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ToolStripModifiedDate.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripModifiedDate.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.ToolStripModifiedDate.Name = "ToolStripModifiedDate"
        Me.ToolStripModifiedDate.Size = New System.Drawing.Size(73, 17)
        Me.ToolStripModifiedDate.Text = "Modified Date :"
        Me.ToolStripModifiedDate.Visible = False
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
        Me.lblHead.Size = New System.Drawing.Size(835, 22)
        Me.lblHead.TabIndex = 0
        Me.lblHead.Text = "« Payment Out Detail"
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
        Me.ToolBar.Size = New System.Drawing.Size(790, 28)
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
        'cboStatus
        '
        Me.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Items.AddRange(New Object() {"LUNAS", "BELUM LUNAS"})
        Me.cboStatus.Location = New System.Drawing.Point(194, 182)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(121, 21)
        Me.cboStatus.TabIndex = 146
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(15, 182)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 13)
        Me.Label6.TabIndex = 145
        Me.Label6.Text = "Status"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(267, 214)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(25, 13)
        Me.Label15.TabIndex = 144
        Me.Label15.Text = "hari"
        '
        'numExpInterval
        '
        Me.numExpInterval.Location = New System.Drawing.Point(194, 212)
        Me.numExpInterval.Name = "numExpInterval"
        Me.numExpInterval.Size = New System.Drawing.Size(68, 21)
        Me.numExpInterval.TabIndex = 143
        Me.numExpInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.numExpInterval.Value = New Decimal(New Integer() {7, 0, 0, 0})
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(15, 214)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(84, 13)
        Me.Label13.TabIndex = 142
        Me.Label13.Text = "Expired Interval"
        '
        'frmTraPaymentOutDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(790, 497)
        Me.Controls.Add(Me.gbDetail)
        Me.Controls.Add(Me.ToolBar)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmTraPaymentOutDet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Payment Out Detail"
        Me.gbDetail.ResumeLayout(False)
        Me.gbDetail.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.numBiaya, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numExpInterval, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gbDetail As System.Windows.Forms.GroupBox
    Friend WithEvents lblHead As System.Windows.Forms.Label
    Friend WithEvents ToolBar As System.Windows.Forms.ToolBar
    Friend WithEvents BarSave As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarClose As System.Windows.Forms.ToolBarButton
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripEmpty As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripCreatedDate As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripModifiedDate As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpTanggalKwitansi As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents txtPaymentInID As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents txtNoAkta As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNamaClient As System.Windows.Forms.TextBox
    Friend WithEvents numBiaya As System.Windows.Forms.NumericUpDown
    Friend WithEvents btnNoAkta As System.Windows.Forms.Button
    Friend WithEvents txtPaymentOutID As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents numExpInterval As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label13 As System.Windows.Forms.Label
End Class

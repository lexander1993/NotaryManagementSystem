<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.mnuMain = New System.Windows.Forms.MenuStrip()
        Me.mnuMaster = New System.Windows.Forms.ToolStripMenuItem()
        Me.UserToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UserGroupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClientToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTransaction = New System.Windows.Forms.ToolStripMenuItem()
        Me.NotaryOrderToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PPATToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CertificateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PaymentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PaymentInToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PaymentOutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuHQReports = New System.Windows.Forms.ToolStripMenuItem()
        Me.NotaryReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NotaryMonthlyReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SuratYangDisahkanToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SuratYangDibukukanToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PPATReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PPATMonthlyReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FeeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AdminFeeMonthlyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PaymentReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PaymentTransactionReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OutstandingPaymentReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTools = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuToolsLogOut = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuToolsChangePassword = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuToolsSep1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuToolsNotification = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClosePeriodToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuWindows = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuWindowsTileVertical = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuWindowsTileHorizontal = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuWindowsCascade = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuWindowsSep1 = New System.Windows.Forms.ToolStripSeparator()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblUserID = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblCompany = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblNotification = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TimerNotification = New System.Windows.Forms.Timer(Me.components)
        Me.NotificationSKMHTToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NotificationPaymentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMain.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'mnuMain
        '
        Me.mnuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuMaster, Me.mnuTransaction, Me.mnuHQReports, Me.mnuTools, Me.mnuWindows})
        Me.mnuMain.Location = New System.Drawing.Point(0, 0)
        Me.mnuMain.MdiWindowListItem = Me.mnuWindows
        Me.mnuMain.Name = "mnuMain"
        Me.mnuMain.Size = New System.Drawing.Size(882, 24)
        Me.mnuMain.TabIndex = 1
        Me.mnuMain.Text = "mnuMain"
        '
        'mnuMaster
        '
        Me.mnuMaster.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UserToolStripMenuItem, Me.UserGroupToolStripMenuItem, Me.ClientToolStripMenuItem})
        Me.mnuMaster.Name = "mnuMaster"
        Me.mnuMaster.Size = New System.Drawing.Size(55, 20)
        Me.mnuMaster.Text = "&Master"
        '
        'UserToolStripMenuItem
        '
        Me.UserToolStripMenuItem.Name = "UserToolStripMenuItem"
        Me.UserToolStripMenuItem.Size = New System.Drawing.Size(133, 22)
        Me.UserToolStripMenuItem.Text = "User"
        '
        'UserGroupToolStripMenuItem
        '
        Me.UserGroupToolStripMenuItem.Name = "UserGroupToolStripMenuItem"
        Me.UserGroupToolStripMenuItem.Size = New System.Drawing.Size(133, 22)
        Me.UserGroupToolStripMenuItem.Text = "User Group"
        '
        'ClientToolStripMenuItem
        '
        Me.ClientToolStripMenuItem.Name = "ClientToolStripMenuItem"
        Me.ClientToolStripMenuItem.Size = New System.Drawing.Size(133, 22)
        Me.ClientToolStripMenuItem.Text = "Client"
        '
        'mnuTransaction
        '
        Me.mnuTransaction.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NotaryOrderToolStripMenuItem1, Me.PPATToolStripMenuItem, Me.CertificateToolStripMenuItem, Me.PaymentToolStripMenuItem})
        Me.mnuTransaction.Name = "mnuTransaction"
        Me.mnuTransaction.Size = New System.Drawing.Size(81, 20)
        Me.mnuTransaction.Text = "&Transaction"
        '
        'NotaryOrderToolStripMenuItem1
        '
        Me.NotaryOrderToolStripMenuItem1.Name = "NotaryOrderToolStripMenuItem1"
        Me.NotaryOrderToolStripMenuItem1.Size = New System.Drawing.Size(128, 22)
        Me.NotaryOrderToolStripMenuItem1.Text = "Notary"
        '
        'PPATToolStripMenuItem
        '
        Me.PPATToolStripMenuItem.Name = "PPATToolStripMenuItem"
        Me.PPATToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.PPATToolStripMenuItem.Text = "PPAT"
        '
        'CertificateToolStripMenuItem
        '
        Me.CertificateToolStripMenuItem.Name = "CertificateToolStripMenuItem"
        Me.CertificateToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.CertificateToolStripMenuItem.Text = "Certificate"
        '
        'PaymentToolStripMenuItem
        '
        Me.PaymentToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PaymentInToolStripMenuItem, Me.PaymentOutToolStripMenuItem})
        Me.PaymentToolStripMenuItem.Name = "PaymentToolStripMenuItem"
        Me.PaymentToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.PaymentToolStripMenuItem.Text = "Payment"
        '
        'PaymentInToolStripMenuItem
        '
        Me.PaymentInToolStripMenuItem.Name = "PaymentInToolStripMenuItem"
        Me.PaymentInToolStripMenuItem.Size = New System.Drawing.Size(144, 22)
        Me.PaymentInToolStripMenuItem.Text = "Payment In"
        '
        'PaymentOutToolStripMenuItem
        '
        Me.PaymentOutToolStripMenuItem.Name = "PaymentOutToolStripMenuItem"
        Me.PaymentOutToolStripMenuItem.Size = New System.Drawing.Size(144, 22)
        Me.PaymentOutToolStripMenuItem.Text = "Payment Out"
        '
        'mnuHQReports
        '
        Me.mnuHQReports.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NotaryReportsToolStripMenuItem, Me.PPATReportsToolStripMenuItem, Me.FeeToolStripMenuItem, Me.PaymentReportToolStripMenuItem})
        Me.mnuHQReports.Name = "mnuHQReports"
        Me.mnuHQReports.Size = New System.Drawing.Size(59, 20)
        Me.mnuHQReports.Text = "&Reports"
        '
        'NotaryReportsToolStripMenuItem
        '
        Me.NotaryReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NotaryMonthlyReportToolStripMenuItem, Me.SuratYangDisahkanToolStripMenuItem, Me.SuratYangDibukukanToolStripMenuItem})
        Me.NotaryReportsToolStripMenuItem.Name = "NotaryReportsToolStripMenuItem"
        Me.NotaryReportsToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.NotaryReportsToolStripMenuItem.Text = "Notary Reports"
        '
        'NotaryMonthlyReportToolStripMenuItem
        '
        Me.NotaryMonthlyReportToolStripMenuItem.Name = "NotaryMonthlyReportToolStripMenuItem"
        Me.NotaryMonthlyReportToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.NotaryMonthlyReportToolStripMenuItem.Text = "Buku Daftar Akta"
        '
        'SuratYangDisahkanToolStripMenuItem
        '
        Me.SuratYangDisahkanToolStripMenuItem.Name = "SuratYangDisahkanToolStripMenuItem"
        Me.SuratYangDisahkanToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.SuratYangDisahkanToolStripMenuItem.Text = "Surat yang Disahkan"
        '
        'SuratYangDibukukanToolStripMenuItem
        '
        Me.SuratYangDibukukanToolStripMenuItem.Name = "SuratYangDibukukanToolStripMenuItem"
        Me.SuratYangDibukukanToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.SuratYangDibukukanToolStripMenuItem.Text = "Surat yang Dibukukan"
        '
        'PPATReportsToolStripMenuItem
        '
        Me.PPATReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PPATMonthlyReportToolStripMenuItem})
        Me.PPATReportsToolStripMenuItem.Name = "PPATReportsToolStripMenuItem"
        Me.PPATReportsToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.PPATReportsToolStripMenuItem.Text = "PPAT Reports"
        '
        'PPATMonthlyReportToolStripMenuItem
        '
        Me.PPATMonthlyReportToolStripMenuItem.Name = "PPATMonthlyReportToolStripMenuItem"
        Me.PPATMonthlyReportToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
        Me.PPATMonthlyReportToolStripMenuItem.Text = "PPAT Monthly Report"
        '
        'FeeToolStripMenuItem
        '
        Me.FeeToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AdminFeeMonthlyToolStripMenuItem})
        Me.FeeToolStripMenuItem.Name = "FeeToolStripMenuItem"
        Me.FeeToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.FeeToolStripMenuItem.Text = "Fee Report"
        '
        'AdminFeeMonthlyToolStripMenuItem
        '
        Me.AdminFeeMonthlyToolStripMenuItem.Name = "AdminFeeMonthlyToolStripMenuItem"
        Me.AdminFeeMonthlyToolStripMenuItem.Size = New System.Drawing.Size(217, 22)
        Me.AdminFeeMonthlyToolStripMenuItem.Text = "Admin Fee Monthly Report"
        '
        'PaymentReportToolStripMenuItem
        '
        Me.PaymentReportToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PaymentTransactionReportToolStripMenuItem, Me.OutstandingPaymentReportToolStripMenuItem})
        Me.PaymentReportToolStripMenuItem.Name = "PaymentReportToolStripMenuItem"
        Me.PaymentReportToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.PaymentReportToolStripMenuItem.Text = "Payment Report"
        '
        'PaymentTransactionReportToolStripMenuItem
        '
        Me.PaymentTransactionReportToolStripMenuItem.Name = "PaymentTransactionReportToolStripMenuItem"
        Me.PaymentTransactionReportToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.PaymentTransactionReportToolStripMenuItem.Text = "Payment Transaction Report"
        '
        'OutstandingPaymentReportToolStripMenuItem
        '
        Me.OutstandingPaymentReportToolStripMenuItem.Name = "OutstandingPaymentReportToolStripMenuItem"
        Me.OutstandingPaymentReportToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.OutstandingPaymentReportToolStripMenuItem.Text = "Outstanding Payment Report"
        '
        'mnuTools
        '
        Me.mnuTools.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuToolsLogOut, Me.mnuToolsChangePassword, Me.ToolStripMenuItem1, Me.mnuToolsSep1, Me.mnuToolsNotification, Me.ClosePeriodToolStripMenuItem})
        Me.mnuTools.Name = "mnuTools"
        Me.mnuTools.Size = New System.Drawing.Size(48, 20)
        Me.mnuTools.Text = "T&ools"
        '
        'mnuToolsLogOut
        '
        Me.mnuToolsLogOut.Name = "mnuToolsLogOut"
        Me.mnuToolsLogOut.Size = New System.Drawing.Size(168, 22)
        Me.mnuToolsLogOut.Text = "Log Out"
        '
        'mnuToolsChangePassword
        '
        Me.mnuToolsChangePassword.Name = "mnuToolsChangePassword"
        Me.mnuToolsChangePassword.Size = New System.Drawing.Size(168, 22)
        Me.mnuToolsChangePassword.Text = "Change Password"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(168, 22)
        Me.ToolStripMenuItem1.Text = "Help"
        '
        'mnuToolsSep1
        '
        Me.mnuToolsSep1.Name = "mnuToolsSep1"
        Me.mnuToolsSep1.Size = New System.Drawing.Size(165, 6)
        '
        'mnuToolsNotification
        '
        Me.mnuToolsNotification.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NotificationSKMHTToolStripMenuItem, Me.NotificationPaymentToolStripMenuItem})
        Me.mnuToolsNotification.Name = "mnuToolsNotification"
        Me.mnuToolsNotification.Size = New System.Drawing.Size(168, 22)
        Me.mnuToolsNotification.Text = "Notification"
        '
        'ClosePeriodToolStripMenuItem
        '
        Me.ClosePeriodToolStripMenuItem.Name = "ClosePeriodToolStripMenuItem"
        Me.ClosePeriodToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.ClosePeriodToolStripMenuItem.Text = "Close Period"
        '
        'mnuWindows
        '
        Me.mnuWindows.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuWindowsTileVertical, Me.mnuWindowsTileHorizontal, Me.mnuWindowsCascade, Me.mnuWindowsSep1})
        Me.mnuWindows.Name = "mnuWindows"
        Me.mnuWindows.Size = New System.Drawing.Size(68, 20)
        Me.mnuWindows.Text = "&Windows"
        '
        'mnuWindowsTileVertical
        '
        Me.mnuWindowsTileVertical.Name = "mnuWindowsTileVertical"
        Me.mnuWindowsTileVertical.Size = New System.Drawing.Size(151, 22)
        Me.mnuWindowsTileVertical.Text = "Tile Vertical"
        '
        'mnuWindowsTileHorizontal
        '
        Me.mnuWindowsTileHorizontal.Name = "mnuWindowsTileHorizontal"
        Me.mnuWindowsTileHorizontal.Size = New System.Drawing.Size(151, 22)
        Me.mnuWindowsTileHorizontal.Text = "Tile Horizontal"
        '
        'mnuWindowsCascade
        '
        Me.mnuWindowsCascade.Name = "mnuWindowsCascade"
        Me.mnuWindowsCascade.Size = New System.Drawing.Size(151, 22)
        Me.mnuWindowsCascade.Text = "Cascade"
        '
        'mnuWindowsSep1
        '
        Me.mnuWindowsSep1.Name = "mnuWindowsSep1"
        Me.mnuWindowsSep1.Size = New System.Drawing.Size(148, 6)
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblUserID, Me.lblCompany, Me.lblNotification})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 642)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(882, 22)
        Me.StatusStrip1.TabIndex = 3
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblUserID
        '
        Me.lblUserID.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.lblUserID.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUserID.ForeColor = System.Drawing.Color.Teal
        Me.lblUserID.Name = "lblUserID"
        Me.lblUserID.Size = New System.Drawing.Size(50, 17)
        Me.lblUserID.Text = "UserID"
        '
        'lblCompany
        '
        Me.lblCompany.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.lblCompany.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCompany.ForeColor = System.Drawing.Color.OrangeRed
        Me.lblCompany.Name = "lblCompany"
        Me.lblCompany.Size = New System.Drawing.Size(64, 17)
        Me.lblCompany.Text = "Company"
        '
        'lblNotification
        '
        Me.lblNotification.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.lblNotification.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNotification.ForeColor = System.Drawing.Color.Maroon
        Me.lblNotification.Name = "lblNotification"
        Me.lblNotification.Size = New System.Drawing.Size(91, 17)
        Me.lblNotification.Text = "Notification : 0"
        '
        'TimerNotification
        '
        Me.TimerNotification.Enabled = True
        Me.TimerNotification.Interval = 30000
        '
        'NotificationSKMHTToolStripMenuItem
        '
        Me.NotificationSKMHTToolStripMenuItem.Name = "NotificationSKMHTToolStripMenuItem"
        Me.NotificationSKMHTToolStripMenuItem.Size = New System.Drawing.Size(187, 22)
        Me.NotificationSKMHTToolStripMenuItem.Text = "Notification SKMHT"
        '
        'NotificationPaymentToolStripMenuItem
        '
        Me.NotificationPaymentToolStripMenuItem.Name = "NotificationPaymentToolStripMenuItem"
        Me.NotificationPaymentToolStripMenuItem.Size = New System.Drawing.Size(187, 22)
        Me.NotificationPaymentToolStripMenuItem.Text = "Notification Payment"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(882, 664)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.mnuMain)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.mnuMain
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Notary Management System"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.mnuMain.ResumeLayout(False)
        Me.mnuMain.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents mnuMain As System.Windows.Forms.MenuStrip
    Friend WithEvents mnuMaster As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuHQReports As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTools As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuWindows As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuWindowsTileVertical As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuWindowsTileHorizontal As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuWindowsCascade As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuWindowsSep1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuToolsLogOut As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuToolsChangePassword As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents lblUserID As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblCompany As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents mnuToolsSep1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuToolsNotification As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblNotification As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TimerNotification As System.Windows.Forms.Timer
    Friend WithEvents mnuTransaction As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClientToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NotaryOrderToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PPATToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NotaryReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PPATReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NotaryMonthlyReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PPATMonthlyReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UserToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FeeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AdminFeeMonthlyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SuratYangDisahkanToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SuratYangDibukukanToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CertificateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PaymentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PaymentInToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PaymentOutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PaymentReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PaymentTransactionReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OutstandingPaymentReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UserGroupToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClosePeriodToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NotificationSKMHTToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NotificationPaymentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class

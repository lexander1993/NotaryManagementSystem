Imports Word = Microsoft.Office.Interop.Word
Public Class frmMain

    Dim frmMstUser As frmMstUser
    Dim frmMstUserGroup As frmMstUserGroup
    Dim frmMstClient As frmMstClient
    Dim frmSysUserChangePassword As frmSysUserChangePassword
    Dim frmSysNotification As frmSysNotification
    Dim frmSysNotificationPayment As frmSysNotificationPayment
    Dim frmSysBackupRestore As frmSysBackupRestore
    Dim frmSysSalinanAkta As frmSysSalinanAkta

    Dim frmTraNotaryOrder As frmTraNotaryOrder
    Dim frmTraPPATOrder As frmTraPPATOrder
    Dim frmTraCertificateOrder As frmTraCertificateOrder
    Dim frmTraPaymentIn As frmTraPaymentIn
    Dim frmTraPaymentOut As frmTraPaymentOut

    Dim frmToolsClosePeriod As frmToolsClosePeriod

    Dim frmRptNotaryOrder As frmRptNotaryOrder
    Dim frmRptPPATOrder As frmRptPPATOrder
    Dim frmRptAdminFee As frmRptAdminFee
    Dim frmRptNotaryOrderSah As frmRptNotaryOrderSah
    Dim frmRptNotaryOrderDibukukan As frmRptNotaryOrderDibukukan
    Dim frmRptPaymentTransaction As frmRptPaymentTransaction
    Dim frmRptOutstandingPayment As frmRptOutstandingPayment

    Dim frmSysPrintAkta As frmSysPrintAkta
    Dim frmSysExportImport As frmSysExportImport
    Dim frmSysExportFileBPN As frmSysExportFileBPN

    Dim bolLogOut As Boolean

    'Untuk kolom yg tidak perlu diisi warna Azure cth Remarks
    'Untuk field AutoGenerate atau harus pilih dari master warna LemonChiffon cth NotaryOrderID


    Private Sub Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Backup Database Otomatis
        'Try
        '    Dim strBackupPath As String
        '    strBackupPath = DL.Server.BackupDatabaseAuto()
        'Catch ex As Exception
        '    UI.usForm.frmMessageBox(ex.Message)
        'End Try

        bolLogOut = False
        lblUserID.Text = "LOGIN BY : " & UI.usUserApp.UserID
        lblCompany.Text = UI.usUserApp.CompanyID


        'If UI.usUserApp.UserID = UI.usUserApp.SuperAdminID Or UI.usUserApp.UserID = UI.usUserApp.AdminID Then
        '    UserToolStripMenuItem.Visible = True
        'Fitur ditutup karena tidak digunakan
        'If UI.usUserApp.UserID = UI.usUserApp.SuperAdminID Then
        '    SalinanAktaToolStripMenuItem.Visible = True
        '    ExportFileBPNToolStripMenuItem.Visible = True
        '    BackupAndRestoreDBToolStripMenuItem.Visible = True
        '    ExportImportToolStripMenuItem.Visible = True
        '    PrintAktaToolStripMenuItem.Visible = True
        'End If

        'End If
        DL.MasterUser.GetAccessRigt()
        prvSetMenuAccess()

        'View Notification SKMHT
        'Dim Record As Integer = DL.MasterClient.NotificationRecord
        'lblNotification.Text = "NOTIFICATION : " & Record
        'If Record > 0 Then UI.usForm.frmOpen(frmSysNotification, "frmSysNotification", Me)

        ''View Notification Payment
        'Dim bolEditPayment As Boolean = DL.MasterUser.IsAccess("PAYMENT IN EDIT")
        'If bolEditPayment = True Then
        '    Dim Record2 As Integer = DL.PaymentIn.NotificationPaymentRecord
        '    If Record2 > 0 Then UI.usForm.frmOpen(frmSysNotificationPayment, "frmSysNotificationPayment", Me)
        'End If
    End Sub

    Private Sub prvSetMenuAccess()
        Dim bolEditCertificate As Boolean = DL.MasterUser.IsAccess("CERTIFICATE ORDER EDIT")
        Dim bolViewCertificate As Boolean = DL.MasterUser.IsAccess("CERTIFICATE ORDER VIEW")
        Dim bolEditPayment As Boolean = DL.MasterUser.IsAccess("PAYMENT IN EDIT")
        Dim bolViewPayment As Boolean = DL.MasterUser.IsAccess("PAYMENT IN VIEW")
        Dim bolEditAdminFee As Boolean = DL.MasterUser.IsAccess("ADMIN FEE EDIT")
        Dim bolEditMasterUser As Boolean = DL.MasterUser.IsAccess("MASTER USER EDIT")

        CertificateToolStripMenuItem.Visible = IIf(bolEditCertificate, bolEditCertificate, bolViewCertificate)
        PaymentToolStripMenuItem.Visible = IIf(bolEditPayment, bolEditPayment, bolViewPayment)
        PaymentReportToolStripMenuItem.Visible = IIf(bolEditPayment, bolEditPayment, bolViewPayment)
        ClosePeriodToolStripMenuItem.Visible = bolEditAdminFee
        UserToolStripMenuItem.Visible = bolEditMasterUser
        UserGroupToolStripMenuItem.Visible = bolEditMasterUser
        NotificationPaymentToolStripMenuItem.Visible = IIf(bolEditPayment, bolEditPayment, bolViewPayment)
    End Sub

    Private Sub Form_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If Not bolLogOut Then
            If UI.usForm.frmAskQuestion("Exit From System ?") Then
                Application.Exit()
            Else
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub mnuWindowsTileVertical_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuWindowsTileVertical.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub mnuWindowsTileHorizontal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuWindowsTileHorizontal.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub mnuToolsLogOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuToolsLogOut.Click
        If UI.usForm.frmAskQuestion("Log Out From Program ?") Then
            bolLogOut = True
            Dim frmDetail As New frmSysUserLogin
            frmDetail.Show()
            Me.Close()
        End If
    End Sub

    Private Sub UserToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserToolStripMenuItem.Click
        UI.usForm.frmOpen(frmMstUser, "frmMstUser", Me)
    End Sub

    Private Sub ClientToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClientToolStripMenuItem.Click
        UI.usForm.frmOpen(frmMstClient, "frmMstClient", Me)
    End Sub

    Private Sub mnuToolsChangePassword_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuToolsChangePassword.Click
        UI.usForm.frmOpen(frmSysUserChangePassword, "frmSysUserChangePassword", Me)
    End Sub

    Private Sub NotaryMonthlyReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NotaryMonthlyReportToolStripMenuItem.Click
        UI.usForm.frmOpen(frmRptNotaryOrder, "frmRptNotaryOrder", Me)
    End Sub

    Private Sub SuratYangDisahkanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SuratYangDisahkanToolStripMenuItem.Click
        UI.usForm.frmOpen(frmRptNotaryOrderSah, "frmRptNotaryOrderSah", Me)
    End Sub

    Private Sub SuratYangDibukukanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SuratYangDibukukanToolStripMenuItem.Click
        UI.usForm.frmOpen(frmRptNotaryOrderDibukukan, "frmRptNotaryOrderDibukukan", Me)
    End Sub

    Private Sub PPATMonthlyReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PPATMonthlyReportToolStripMenuItem.Click
        UI.usForm.frmOpen(frmRptPPATOrder, "frmRptPPATOrder", Me)
    End Sub

    Private Sub AdminFeeMonthlyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdminFeeMonthlyToolStripMenuItem.Click
        UI.usForm.frmOpen(frmRptAdminFee, "frmRptAdminFee", Me)
    End Sub

    Private Sub BackupAndRestoreDBToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        UI.usForm.frmOpen(frmSysBackupRestore, "frmSysBackupRestore", Me)
    End Sub


    Private Sub PrintAktaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        UI.usForm.frmOpen(frmSysPrintAkta, "frmSysPrintAkta", Me)
    End Sub

    Private Sub ExportImportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        UI.usForm.frmOpen(frmSysExportImport, "frmSysExportImport", Me)
    End Sub

    Private Sub SalinanAktaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        UI.usForm.frmOpen(frmSysSalinanAkta, "frmSysSalinanAkta", Me)
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        Dim oWord As Word.Application
        Dim oDoc As Word.Document
        oWord = CreateObject("Word.Application")
        oWord.Visible = True
        oDoc = oWord.Documents.Add(UI.usUserApp.Help)
    End Sub

    Private Sub ExportFileBPNToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        UI.usForm.frmOpen(frmSysExportFileBPN, "frmSysExportFileBPN", Me)
    End Sub

    Private Sub NotaryOrderToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NotaryOrderToolStripMenuItem1.Click
        UI.usForm.frmOpen(frmTraNotaryOrder, "frmTraNotaryOrder", Me)
    End Sub

    Private Sub PPATToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PPATToolStripMenuItem.Click
        UI.usForm.frmOpen(frmTraPPATOrder, "frmTraPPATOrder", Me)
    End Sub

    Private Sub CertificateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CertificateToolStripMenuItem.Click
        UI.usForm.frmOpen(frmTraCertificateOrder, "frmTraCertificateOrder", Me)
    End Sub

    Private Sub PaymentInToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PaymentInToolStripMenuItem.Click
        UI.usForm.frmOpen(frmTraPaymentIn, "frmTraPaymentIn", Me)
    End Sub

    Private Sub PaymentOutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PaymentOutToolStripMenuItem.Click
        UI.usForm.frmOpen(frmTraPaymentOut, "frmTraPaymentOut", Me)
    End Sub

    Private Sub PaymentTransactionReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PaymentTransactionReportToolStripMenuItem.Click
        UI.usForm.frmOpen(frmRptPaymentTransaction, "frmRptPaymentTransaction", Me)
    End Sub

    Private Sub OutstandingPaymentReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OutstandingPaymentReportToolStripMenuItem.Click
        UI.usForm.frmOpen(frmRptOutstandingPayment, "frmRptOutstandingPayment", Me)
    End Sub

    Private Sub UserGroupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserGroupToolStripMenuItem.Click
        UI.usForm.frmOpen(frmMstUserGroup, "frmMstUserGroup", Me)
    End Sub

    Private Sub ClosePeriodToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClosePeriodToolStripMenuItem.Click
        UI.usForm.frmOpen(frmToolsClosePeriod, "frmToolsClosePeriod", Me)
    End Sub

    Private Sub NotificationSKMHTToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NotificationSKMHTToolStripMenuItem.Click
        UI.usForm.frmOpen(frmSysNotification, "frmSysNotification", Me)
    End Sub

    Private Sub NotificationPaymentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NotificationPaymentToolStripMenuItem.Click
        UI.usForm.frmOpen(frmSysNotificationPayment, "frmSysNotificationPayment", Me)
    End Sub
End Class

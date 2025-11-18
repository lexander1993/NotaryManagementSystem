Public Class frmRptNotaryOrderVer2

    Private Const _
        cPreview = 0, cClose = 1

    Private Sub prvSetIcon()
        UI.usForm.SetToolBar(Me, ToolBar, "0,Print,1,Close")
    End Sub

    Private Sub prvSetGrid()
        UI.usForm.SetGrid(grdView, "NoUrut", "No Urut", 60, UI.usDefGrid.gString, True, True, True)
        UI.usForm.SetGrid(grdView, "NoBulanan", "No Bulanan", 80, UI.usDefGrid.gString, True, True, True)
        UI.usForm.SetGrid(grdView, "TglAkta", "Tanggal Akta", 90, UI.usDefGrid.gSmallDate, True, True, True)
        UI.usForm.SetGrid(grdView, "TglDidaftarkan", "Tanggal Didaftarkan", 90, UI.usDefGrid.gSmallDate, True)
        UI.usForm.SetGrid(grdView, "Nama1", "Nama Pihak I", 300, UI.usDefGrid.gString, True, False)
        UI.usForm.SetGrid(grdView, "Nama2", "Nama Pihak II", 300, UI.usDefGrid.gString, True, False)
        UI.usForm.SetGrid(grdView, "Nama3", "Nama Pihak III", 300, UI.usDefGrid.gString, True, False)


        'Filter
        grdView.Columns.Item("NoUrut").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdView.Columns.Item("NoBulanan").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdView.Columns.Item("TglAkta").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdView.Columns.Item("TglDidaftarkan").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdView.Columns.Item("Nama1").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdView.Columns.Item("Nama2").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdView.Columns.Item("Nama3").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains

        Dim txt1 As New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
        grdView.OptionsView.RowAutoHeight = True

        grdView.Columns.Item("Nama1").ColumnEdit = txt1
        grdView.Columns.Item("Nama2").ColumnEdit = txt1
        grdView.Columns.Item("Nama3").ColumnEdit = txt1
    End Sub

    Private Sub prvPreview()
        UI.usForm.CreateWaitDialog()

        Dim crReportFile As New rptNotaryOrder
        '  crReportFile.SetDataSource(DL.Report.NotaryOrder(dtpDateFrom.Value.Date, dtpDateTo.Value.Date, 0))
        crReportFile.SetDataSource(grdMain.DataSource)

        crReportFile.SetParameterValue("ReportTitle", txtReportTitle.Text.Trim)
        crReportFile.SetParameterValue("DateFrom", dtpDateFrom.Value.Date)
        crReportFile.SetParameterValue("DateTo", dtpDateTo.Value.Date)

        Dim frmDetail As New frmSysReport
        With frmDetail
            .MdiParent = frmMain
            .crvViewer.ReportSource = crReportFile
            .crvViewer.Refresh()
            .crvViewer.Show()
            .WindowState = FormWindowState.Maximized
            .StartPosition = FormStartPosition.CenterScreen
            .Show()
        End With

        UI.usForm.CloseWaitDialog()
    End Sub

#Region "Form Handle"

    Private Sub frmRptSummaryLocalPurchaseByCategory_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        prvSetIcon()
        prvSetGrid()
        dtpDateFrom.Value = Today.Year & "/" & Today.Month & "/" & "01 23:59:59"
        dtpDateTo.Value = dtpDateFrom.Value.AddMonths(1).AddDays(-1)
        txtReportTitle.Text = "LAPORAN BULANAN BUKU DAFTAR AKTA"
    End Sub

    Private Sub frmRptSummaryLocalPurchaseByCategory_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If UI.usForm.frmAskQuestion("Close this form?") Then
                Me.Close()
            End If
        End If
    End Sub

    Private Sub ToolBar_ButtonClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles ToolBar.ButtonClick
        Select Case e.Button.Text.Trim
            Case "Preview" : Me.prvPreview()
            Case "Close" : Me.Close()
        End Select
    End Sub

    Private Sub btnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShow.Click
        If txtReportTitle.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Report Title cannot blank")
            txtReportTitle.Focus()
            Exit Sub
        ElseIf dtpDateFrom.Value.Date > dtpDateTo.Value.Date Then
            UI.usForm.frmMessageBox("Invalid range date")
            dtpDateFrom.Focus()
            Exit Sub
        End If

        grdMain.DataSource = DL.Report.NotaryOrder(dtpDateFrom.Value.Date, dtpDateTo.Value.Date, 0)
    End Sub

#End Region


End Class
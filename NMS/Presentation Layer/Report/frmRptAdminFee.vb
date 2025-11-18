Public Class frmRptAdminFee

    Private Const _
       cPreview = 0, cPreviewSum = 1, cClose = 2

    Private Sub prvSetIcon()
        UI.usForm.SetToolBar(Me, ToolBar, "0,Print,1,Print,2,Close")
    End Sub

    Private Sub prvSetGrid()
        UI.usForm.SetGrid(grdView, "UserID", "User ID", 110, UI.usDefGrid.gString, True, True, True)
        UI.usForm.SetGrid(grdView, "OrderID", "Notary Order ID", 110, UI.usDefGrid.gString, True, True, True)
        UI.usForm.SetGrid(grdView, "NoUrut", "No Urut / No Akta", 110, UI.usDefGrid.gString, True, True, True)
        UI.usForm.SetGrid(grdView, "TglAkta", "Tanggal Akta", 90, UI.usDefGrid.gSmallDate, True, True, True)
        UI.usForm.SetGrid(grdView, "JenisTransaksi", "Jenis Transaksi", 200, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "Tipe", "Tipe", 50, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "Nama", "Nama Pihak I", 200, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "FileLocation", "Scan Data", 70, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "Remarks", "False Remarks", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdView, "TglTransaksi", "Tgl Transaksi", 90, UI.usDefGrid.gSmallDate)
        UI.usForm.SetGrid(grdView, "Fee", "Fee", 120, UI.usDefGrid.gIntNum)

        grdView.Columns.Item("Fee").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        'DevExpress.XtraGrid.Columns.GridColumn

        'Filter
        grdView.Columns.Item("UserID").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdView.Columns.Item("OrderID").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdView.Columns.Item("NoUrut").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdView.Columns.Item("JenisTransaksi").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdView.Columns.Item("Tipe").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdView.Columns.Item("Nama").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains

    End Sub

    Private Sub prvSetButton()
        'Dim bolEdit, bolView As Boolean
        ''  bolEdit = DL.MasterUser.IsAccess("ADMIN FEE EDIT")
        'bolView = DL.MasterUser.IsAccess("ADMIN FEE VIEW")

        'With ToolBar.Buttons
        '    .Item(cPreview).Enabled = IIf(bolEdit, bolEdit, bolView)
        '    .Item(cPreviewSum).Enabled = IIf(bolEdit, bolEdit, bolView)
        'End With
    End Sub

    Private Sub prvPreview(ByVal choice As String)
        Dim dtData As DataTable = DL.Report.AdminFee(dtpLastPeriod.SelectedValue, txtUserID.Text)
        Dim FileLocation As String
        Dim intPos As Integer = 0
        Try
            For Each drData1 As DataRow In dtData.Rows
                Dim SubFolder(), Files() As String
                FileLocation = drData1.Item("FileLocation")
                SubFolder = System.IO.Directory.GetDirectories(FileLocation)
                Files = System.IO.Directory.GetFiles(FileLocation)

                If SubFolder.Length = 0 And Files.Length = 0 Then
                    drData1.Item("FileLocation") = "Empty"
                Else
                    drData1.Item("FileLocation") = Files.Length & " Files"
                End If
                intPos += 1
            Next
        Catch ex As Exception
        End Try

        If choice = "Show" Then
            grdMain.DataSource = dtData
        Else
            UI.usForm.CreateWaitDialog()
            Dim crReportFile As New rptAdminFee
            crReportFile.SetDataSource(dtData)
            crReportFile.SetParameterValue("ReportTitle", "LAPORAN BULANAN FEE KARYAWAN")
            crReportFile.SetParameterValue("Period", dtpLastPeriod.Text)

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
        End If
    End Sub

    Private Sub prvPreviewSum()
        Dim dtData As DataTable = DL.Report.SummaryAdminFee(dtpLastPeriod.SelectedValue)

        UI.usForm.CreateWaitDialog()
        Dim crReportFile As New rptAdminFeeSum
        crReportFile.SetDataSource(dtData)
        crReportFile.SetParameterValue("ReportTitle", "LAPORAN BULANAN SUMMARY FEE KARYAWAN")
        crReportFile.SetParameterValue("Period", dtpLastPeriod.Text)

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

    'Private Sub Paid()
    '    If Not UI.usForm.frmAskQuestion("Update IsPaid Transaksi tanggal " & dtpDateFrom.Value.ToString("yyyyMMdd") & "-" & dtpDateTo.Value.ToString("yyyyMMdd") & " ?") Then Exit Sub
    '    DL.Report.UpdatePaid(dtpDateFrom.Value.Date, dtpDateTo.Value.Date, txtUserID.Text)
    '    UI.usForm.frmMessageBox("Transaksi berhasil diupdate menjadi IsPaid ! ")
    '    prvPreview("Show")
    'End Sub

    'Private Sub Unpaid()
    '    If Not UI.usForm.frmAskQuestion("Update Unpaid Transaksi tanggal " & dtpDateFrom.Value.ToString("yyyyMMdd") & "-" & dtpDateTo.Value.ToString("yyyyMMdd") & " ?") Then Exit Sub
    '    DL.Report.UpdateUnpaid(dtpDateFrom.Value.Date, dtpDateTo.Value.Date, txtUserID.Text)
    '    UI.usForm.frmMessageBox("Transaksi berhasil diupdate menjadi Unpaid ! ")
    '    prvPreview("Show")
    'End Sub

#Region "Form Handle"

    Private Sub frmRptSummaryLocalPurchaseByCategory_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        prvSetIcon()
        prvSetGrid()
        prvSetButton()
        dtpLastPeriod.DisplayMember = "Period"
        dtpLastPeriod.ValueMember = "PeriodStr"
        dtpLastPeriod.DataSource = DL.AdminFee.GetAllPeriod()
    End Sub

    Private Sub frmRptSummaryLocalPurchaseByCategory_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If UI.usForm.frmAskQuestion("Close this form?") Then
                Me.Close()
            End If
        End If
    End Sub

    Private Sub btnUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUser.Click
        Dim frmDetail As New frmMstUser
        With frmDetail
            .pubIsLookUp = True
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
            If .pubIsLookUpGet Then
                txtUserID.Text = .pubLUDataRow("UserID")
            End If
        End With
    End Sub

    Private Sub btnExecute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExecute.Click
        prvPreview("Show")
    End Sub

    Private Sub ToolBar_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles ToolBar.ButtonClick
        Select Case e.Button.Text.Trim
            Case "Preview Detail" : Me.prvPreview("Print")
            Case "Preview Summary" : Me.prvPreviewSum()
            Case "Close" : Me.Close()
                'Case "Paid" : Paid()
                'Case "Unpaid" : Unpaid()
        End Select
    End Sub

    Private Sub grdView_RowStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles grdView.RowStyle
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
        If (e.RowHandle >= 0) Then

            If View.GetRowCellDisplayText(e.RowHandle, View.Columns("FileLocation")) = "Empty" And _
                View.GetRowCellDisplayText(e.RowHandle, View.Columns("Tipe")) = "P" Then
                e.Appearance.BackColor = Color.LightBlue
                e.Appearance.BackColor2 = Color.WhiteSmoke
            End If

            If View.GetRowCellDisplayText(e.RowHandle, View.Columns("Tipe")) = "F-D" Or View.GetRowCellDisplayText(e.RowHandle, View.Columns("Tipe")) = "F-P" Then
                e.Appearance.BackColor = Color.Salmon
                e.Appearance.BackColor2 = Color.WhiteSmoke
            End If
        End If
    End Sub



#End Region




End Class
Public Class frmRptPPATOrder
    Private Tanggal, Bulan, Tahun, HariIni As String

    Private Const _
        cPreview = 0, cClose = 1

    Private Sub prvSetIcon()
        UI.usForm.SetToolBar(Me, ToolBar, "0,Print,1,Close")
    End Sub

    Private Sub prvSetGrid()
        UI.usForm.SetGrid(grdView, "NoAkta", "No Akta", 80, UI.usDefGrid.gString, True, True, True)
        UI.usForm.SetGrid(grdView, "TglAkta", "Tanggal Akta", 100, UI.usDefGrid.gSmallDate, True, True, True)

        UI.usForm.SetGrid(grdView, "JenisTransaksi", "Jenis Transaksi", 130, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "JenisNoHak", "Jenis dan No Hak", 150, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "Nama1", "Nama Pihak I", 300, UI.usDefGrid.gString, True, False)
        UI.usForm.SetGrid(grdView, "Nama2", "Nama Pihak II", 300, UI.usDefGrid.gString, True, False)

        UI.usForm.SetGrid(grdView, "LetakTanahBangunan", "Letak Tanah dan Bangunan", 150, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "LuasTanahM2", "Luas Tanah (M2)", 80, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "LuasBangunanM2", "Luas Bangunan (M2)", 80, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "HargaTransaksi", "Harga Transaksi", 120, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "SPPTPBBNOPTahun", "SPPT PBB NOP Tahun", 120, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "SPPTPBBNJOP", "SPPT PBB NJOP", 120, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "SSPTanggal", "SSP Tanggal", 100, UI.usDefGrid.gSmallDate)
        UI.usForm.SetGrid(grdView, "SSPHarga", "SSP Harga", 120, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "SSBTanggal", "SSB Tanggal", 100, UI.usDefGrid.gSmallDate)
        UI.usForm.SetGrid(grdView, "SSBHarga", "SSB Harga", 120, UI.usDefGrid.gReal2Num)
        UI.usForm.SetGrid(grdView, "Remarks", "Remarks", 150, UI.usDefGrid.gString)

        'Filter Contains
        grdView.Columns.Item("NoAkta").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdView.Columns.Item("JenisTransaksi").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdView.Columns.Item("JenisNoHak").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains

        grdView.Columns.Item("Nama1").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
       grdView.Columns.Item("Nama2").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
       

        Dim txt1 As New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
        grdView.OptionsView.RowAutoHeight = True
       
        grdView.Columns.Item("Nama1").ColumnEdit = txt1
        grdView.Columns.Item("Nama2").ColumnEdit = txt1
        'grdView.Columns.Item("JenisTransaksi").ColumnEdit = txt1
        'grdView.Columns.Item("JenisNoHak").ColumnEdit = txt1
        'grdView.Columns.Item("LetakTanahBangunan").ColumnEdit = txt1
        'grdView.Columns.Item("HargaTransaksi").ColumnEdit = txt1
        'grdView.Columns.Item("SPPTPBBNOPTahun").ColumnEdit = txt1
        'grdView.Columns.Item("SPPTPBBNJOP").ColumnEdit = txt1
        'grdView.Columns.Item("SSPTanggal").ColumnEdit = txt1
        'grdView.Columns.Item("SSPHarga").ColumnEdit = txt1
        'grdView.Columns.Item("SSBTanggal").ColumnEdit = txt1
        'grdView.Columns.Item("SSBHarga").ColumnEdit = txt1
        'grdView.Columns.Item("SSBTanggal").ColumnEdit = txt1
        'grdView.Columns.Item("Remarks").ColumnEdit = txt1

    End Sub

    Private Sub btnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShow.Click
        Dim sb As New System.Text.StringBuilder
        Dim intI As Integer
        Dim strJenisTransaksi As String = ""

        For intI = 0 To Me.chkListJenisTransaksi.Items.Count - 1
            If chkListJenisTransaksi.GetItemChecked(intI) = True Then
                sb.Append("'" & intI.ToString & "', ")
            End If
        Next

        If sb.ToString <> "" Then
            strJenisTransaksi = Mid(sb.ToString, 1, Len(sb.ToString) - 2)
        End If

        If txtReportTitle.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Report Title cannot blank")
            txtReportTitle.Focus()
            Exit Sub
        ElseIf dtpDateFrom.Value.Date > dtpDateTo.Value.Date Then
            UI.usForm.frmMessageBox("Invalid range date")
            dtpDateFrom.Focus()
            Exit Sub
        ElseIf strJenisTransaksi.Trim = "" Then
            UI.usForm.frmMessageBox("Please select Jenis Transaksi")
            Exit Sub
        End If

        grdMain.DataSource = DL.Report.PPATOrder(dtpDateFrom.Value.Date, _
                                                             dtpDateTo.Value.Date, _
                                                             strJenisTransaksi)


    End Sub

    Private Sub prvPreview()
        'Dim sb As New System.Text.StringBuilder
        'Dim intI As Integer
        'Dim strJenisTransaksi As String = ""

        'For intI = 0 To Me.chkListJenisTransaksi.Items.Count - 1
        '    If chkListJenisTransaksi.GetItemChecked(intI) = True Then
        '        sb.Append("'" & intI.ToString & "', ")
        '    End If
        'Next

        'If sb.ToString <> "" Then
        '    strJenisTransaksi = Mid(sb.ToString, 1, Len(sb.ToString) - 2)
        'End If


        'If txtReportTitle.Text.Trim = "" Then
        '    UI.usForm.frmMessageBox("Report Title cannot blank")
        '    txtReportTitle.Focus()
        '    Exit Sub
        'ElseIf dtpDateFrom.Value.Date > dtpDateTo.Value.Date Then
        '    UI.usForm.frmMessageBox("Invalid range date")
        '    dtpDateFrom.Focus()
        '    Exit Sub
        'ElseIf strJenisTransaksi.Trim = "" Then
        '    UI.usForm.frmMessageBox("Please select Jenis Transaksi")
        '    Exit Sub
        'End If
        txtReportTitle.Focus()
        UI.usForm.CreateWaitDialog()

        Dim crReportFile As New rptPPATOrder
        'crReportFile.SetDataSource(DL.Report.PPATOrder(dtpDateFrom.Value.Date, _
        '                                                     dtpDateTo.Value.Date, _
        '                                                     strJenisTransaksi))

        crReportFile.SetDataSource(grdMain.DataSource)

        crReportFile.SetParameterValue("ReportTitle", txtReportTitle.Text.Trim)
        crReportFile.SetParameterValue("Nama", UI.usUserApp.AdminName)
        crReportFile.SetParameterValue("Jalan", UI.usUserApp.AdminAddress)
        crReportFile.SetParameterValue("NPWP", UI.usUserApp.AdminNPWP)
        crReportFile.SetParameterValue("DaerahKerja", UI.usUserApp.AdminDaerahKerja)
        crReportFile.SetParameterValue("Month", Bulan)
        crReportFile.SetParameterValue("Year", dtpDateFrom.Value.Year)
        crReportFile.SetParameterValue("Footer", txtFooter.Text)
        crReportFile.SetParameterValue("FooterNama", txtFooterNama.Text)

        'Dim frm As New frmSysReport
        'frm.Report = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        'With frm
        '    .Report.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4
        '    .Report.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait
        '    .MdiParent = frmMain
        '    .crvViewer.ReportSource = crReportFile
        '    .crvViewer.Refresh()
        '    .crvViewer.Show()
        '    .WindowState = FormWindowState.Maximized
        '    .StartPosition = FormStartPosition.CenterScreen
        '    .Show()
        'End With

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


        Tanggal = Today.ToString("dd")
        Bulan = UI.Terbilang.Bulan(CInt(Today.ToString("MM")))
        Tahun = Today.ToString("yyyy")

        HariIni = Tanggal & " " & Bulan & " " & Tahun

        dtpDateFrom.Value = Today.Year & "/" & Today.Month & "/" & "01 23:59:59"
        dtpDateTo.Value = dtpDateFrom.Value.AddMonths(1).AddDays(-1)
        txtReportTitle.Text = "LAPORAN BULANAN PEMBUATAN AKTA OLEH PPAT"
        txtFooter.Text = "DELI SERDANG, " & HariIni & vbCrLf & "PPAT DELI SERDANG"
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

    Private Sub chkListAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCheckAll.CheckedChanged
        Dim intI As Integer
        For intI = 0 To chkListJenisTransaksi.Items.Count - 1
            If chkCheckAll.Checked Then
                chkListJenisTransaksi.SetItemChecked(intI, True)
            Else
                chkListJenisTransaksi.SetItemChecked(intI, False)
            End If
        Next
    End Sub

#End Region

    
End Class
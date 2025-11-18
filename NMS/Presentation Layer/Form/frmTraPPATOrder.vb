Public Class frmTraPPATOrder

#Region "Look Up"

    Private bolLookUp As Boolean = False
    Private bolLookUpGet As Boolean = False
    Private strLUPPATOrderID As String
    Private dtrLUDataRow As DataRow

    Public WriteOnly Property pubIsLookUp() As Boolean
        Set(ByVal Value As Boolean)
            bolLookUp = Value
        End Set
    End Property

    Public ReadOnly Property pubIsLookUpGet() As String
        Get
            Return bolLookUpGet
        End Get
    End Property

    Public Property pubLUPPATOrderID() As String
        Get
            Return strLUPPATOrderID
        End Get
        Set(ByVal Value As String)
            strLUPPATOrderID = Value
        End Set
    End Property

    Public Property pubLUDataRow() As DataRow
        Get
            Return dtrLUDataRow
        End Get
        Set(ByVal Value As DataRow)
            dtrLUDataRow = Value
        End Set
    End Property

#End Region

#Region "Function"
    Private Const _
        cNew = 0, cDetail = 1, cDelete = 2, cProcess = 4, cBPNFinish = 5, cCompleted = 6, cFalse = 8, cRefresh = 9

    Private intPos As Integer
    Private clsData As New VO.PPATOrder

    Private Sub prvSetIcon()
        UI.usForm.SetToolBar(Me, ToolBar, "0,New,1,Detail,2,Delete,4,Submit,5,History,6,Approved,8,Cancel,9,Refresh")
    End Sub

    Private Sub prvSetButton()
        Dim bolEdit, bolView, bolProcess, bolBPNFinish, bolComplete, bolFalse As Boolean
        bolEdit = DL.MasterUser.IsAccess("PPAT ORDER EDIT")
        bolView = DL.MasterUser.IsAccess("PPAT ORDER VIEW")
        bolProcess = DL.MasterUser.IsAccess("PPAT ORDER PROCESS")
        bolBPNFinish = DL.MasterUser.IsAccess("PPAT ORDER BPN FINISH")
        bolComplete = DL.MasterUser.IsAccess("PPAT ORDER COMPLETE")
        bolFalse = DL.MasterUser.IsAccess("PPAT ORDER FALSE")

        With ToolBar.Buttons
            .Item(cNew).Enabled = bolEdit
            .Item(cDetail).Enabled = IIf(bolEdit, bolEdit, bolView)
            .Item(cDelete).Enabled = bolEdit
            .Item(cProcess).Enabled = bolProcess
            .Item(cBPNFinish).Enabled = bolBPNFinish
            .Item(cCompleted).Enabled = bolComplete
            .Item(cFalse).Enabled = bolFalse
        End With
    End Sub

    Private Sub prvSetGrid()
        UI.usForm.SetGrid(grdView, "PPATOrderID", "PPAT Order ID", 120, UI.usDefGrid.gString, True, True, True)
        UI.usForm.SetGrid(grdView, "NoAkta", "No Akta", 80, UI.usDefGrid.gString, True, True, True)
        UI.usForm.SetGrid(grdView, "TglAkta", "Tanggal Akta", 100, UI.usDefGrid.gSmallDate, True, True, True)

        UI.usForm.SetGrid(grdView, "JenisTransaksi", "Jenis Transaksi", 130, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "JenisNoHak", "Jenis dan No Hak", 150, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "Status", "Status", 70, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "NoID", "No ID Pihak I", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "Nama", "Nama Pihak I", 140, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "NoID2", "No ID Pihak II", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "Nama2", "Nama Pihak II", 140, UI.usDefGrid.gString)

        UI.usForm.SetGrid(grdView, "IsFalseLevelStr", "Is False Creator", 110, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "IsFalse", "Is False", 70, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "IsFalseBy", "Is False By", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "IsFalseDate", "Is False Date", 150, UI.usDefGrid.gFullDate)
        UI.usForm.SetGrid(grdView, "IsFalseRemarks", "Is False Remarks", 150, UI.usDefGrid.gString)

        ' UI.usForm.SetGrid(grdView, "FileLocation", "File Location", 150, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "Remarks", "Remarks", 150, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "FileLocation", "Scan Data", 70, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "DraftBy", "Draft By", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "DraftDate", "Draft Date", 150, UI.usDefGrid.gFullDate)
        UI.usForm.SetGrid(grdView, "ProcessBy", "Process By", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "ProcessDate", "Process Date", 150, UI.usDefGrid.gFullDate)
        UI.usForm.SetGrid(grdView, "ProcessRemarks", "Process Remarks", 150, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "BPNFinishBy", "BPN Finish By", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "BPNFinishDate", "BPN Finish Date", 150, UI.usDefGrid.gFullDate)
        UI.usForm.SetGrid(grdView, "BPNFinishRemarks", "BPN Finish Remarks", 150, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "CompletedBy", "Completed By", 140, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "CompletedDate", "Completed Date", 150, UI.usDefGrid.gFullDate)
        UI.usForm.SetGrid(grdView, "CompletedRemarks", "Completed Remarks", 180, UI.usDefGrid.gString)

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

        ' grdView.Columns.Item("TglAkta").SortOrder = DevExpress.Data.Column


        grdView.Columns.Item("NoID").AppearanceCell.BackColor = Color.LightYellow
        grdView.Columns.Item("Nama").AppearanceCell.BackColor = Color.LightYellow
        grdView.Columns.Item("NoID2").AppearanceCell.BackColor = Color.LightYellow
        grdView.Columns.Item("Nama2").AppearanceCell.BackColor = Color.LightYellow
        grdView.Columns.Item("IsFalseLevelStr").AppearanceCell.BackColor = Color.LightYellow
        grdView.Columns.Item("IsFalse").AppearanceCell.BackColor = Color.LightYellow
        grdView.Columns.Item("FileLocation").AppearanceCell.BackColor = Color.LightBlue

        'Filter Contains
        grdView.Columns.Item("PPATOrderID").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdView.Columns.Item("NoAkta").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdView.Columns.Item("JenisTransaksi").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdView.Columns.Item("JenisNoHak").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdView.Columns.Item("Status").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdView.Columns.Item("NoID").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdView.Columns.Item("Nama").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdView.Columns.Item("NoID2").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdView.Columns.Item("Nama2").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdView.Columns.Item("IsFalseBy").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
       



    End Sub

    Private Sub prvSetLookUp()
        If bolLookUp Then
            UI.usForm.GridMoveRow(grdView, "PPATOrderID", strLUPPATOrderID)
        End If
    End Sub

    Private Sub prvGet()
        intPos = grdView.FocusedRowHandle
        If bolLookUp And intPos >= 0 Then
            strLUPPATOrderID = grdView.GetDataRow(intPos).Item("PPATOrderID")
            dtrLUDataRow = grdView.GetDataRow(grdView.FocusedRowHandle)
            bolLookUpGet = True
            Me.Close()
        End If
    End Sub

    Private Sub prvNew()
        Dim frmDetail As New frmTraPPATOrderDet
        With frmDetail
            .pubIsNew = True
            .pubShowDialog(Me)
        End With
    End Sub

    Private Sub prvDetail()
        intPos = grdView.FocusedRowHandle
        Dim frmDetail As New frmTraPPATOrderDet
        With frmDetail
            .pubIsNew = False
            .pubPPATOrderID = grdView.GetDataRow(intPos).Item("PPATOrderID")
            .pubShowDialog(Me)
            If .pubIsSave Then pubRefresh()
        End With
    End Sub

    Private Sub prvDelete()
        intPos = grdView.FocusedRowHandle
        If grdView.GetDataRow(intPos).Item("Status") <> "DRAFT" Then
            UI.usForm.frmMessageBox("Delete hanya untuk transaksi Status : DRAFT ! ")
            Exit Sub
        End If

        Dim strPPATOrderID As String = grdView.GetDataRow(intPos).Item("PPATOrderID")
        Try
            If Not UI.usForm.frmAskQuestion("Hapus PPAT Order ID " & strPPATOrderID & " ?") Then Exit Sub
            DL.PPATOrder.DeleteClient1(strPPATOrderID)
            DL.PPATOrder.DeleteClient2(strPPATOrderID)
            DL.PPATOrder.DeleteHeader(strPPATOrderID)
            Try
                RmDir(UI.usUserApp.FileLocation & strPPATOrderID)
            Catch ex As Exception
                Kill(UI.usUserApp.FileLocation & strPPATOrderID & "\*.*")
                RmDir(UI.usUserApp.FileLocation & strPPATOrderID)
            End Try
            UI.usForm.frmMessageBox(strPPATOrderID & " berhasil dihapus ! ")
            pubRefresh()
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try

    End Sub

    Private Sub prvProcess()
        intPos = grdView.FocusedRowHandle
        If grdView.GetDataRow(intPos).Item("Status") = "BPN FINISH" Then
            UI.usForm.frmMessageBox("Status BPN Finish tidak bisa melakukan proses ini !")
            Exit Sub
        End If

        If grdView.GetDataRow(intPos).Item("Status") = "COMPLETED" Then
            UI.usForm.frmMessageBox("Status COMPLETED tidak bisa melakukan proses ini !")
            Exit Sub
        End If

        If grdView.GetDataRow(intPos).Item("FileLocation") = "Empty" Then
            UI.usForm.frmMessageBox("Scan Data yang kosong tidak bisa melanjutkan ke status Process !")
            Exit Sub
        End If

        Dim frmDetail As New frmTraPPATOrderProcess
        With frmDetail
            .pubPPATOrderID = grdView.GetDataRow(intPos).Item("PPATOrderID")
            .pubStatus = grdView.GetDataRow(intPos).Item("Status")
            .ShowDialog()
            If .pubIsSave Then pubRefresh()
        End With
    End Sub

    Private Sub prvBPNFinish()
        intPos = grdView.FocusedRowHandle
        If grdView.GetDataRow(intPos).Item("Status") = "DRAFT" Then
            UI.usForm.frmMessageBox("Status DRAFT tidak bisa melakukan proses ini !")
            Exit Sub
        End If

        If grdView.GetDataRow(intPos).Item("Status") = "COMPLETED" Then
            UI.usForm.frmMessageBox("Status COMPLETED tidak bisa melakukan proses ini !")
            Exit Sub
        End If

        Dim frmDetail As New frmTraPPATOrderBPNFinish
        With frmDetail
            .pubPPATOrderID = grdView.GetDataRow(intPos).Item("PPATOrderID")
            .pubStatus = grdView.GetDataRow(intPos).Item("Status")
            .ShowDialog()
            If .pubIsSave Then pubRefresh()
        End With
    End Sub

    Private Sub prvCompleted()
        intPos = grdView.FocusedRowHandle
        If grdView.GetDataRow(intPos).Item("Status") = "DRAFT" Then
            UI.usForm.frmMessageBox("Status DRAFT tidak bisa melakukan proses ini !")
            Exit Sub
        End If

        If grdView.GetDataRow(intPos).Item("Status") = "PROCESS" Then
            UI.usForm.frmMessageBox("Status PROCESS tidak bisa melakukan proses ini !")
            Exit Sub
        End If

        Dim frmDetail As New frmTraPPATOrderCompleted
        With frmDetail
            .pubPPATOrderID = grdView.GetDataRow(intPos).Item("PPATOrderID")
            .pubStatus = grdView.GetDataRow(intPos).Item("Status")
            .ShowDialog()
            If .pubIsSave Then pubRefresh()
        End With
    End Sub

    Private Sub prvFalse()
        intPos = grdView.FocusedRowHandle
        'If grdView.GetDataRow(intPos).Item("Status") <> "COMPLETED" Then
        '    UI.usForm.frmMessageBox("Hanya Status COMPLETED bisa melakukan proses ini !")
        '    Exit Sub
        'End If

        Dim frmDetail As New frmTraPPATOrderFalse
        With frmDetail
            .pubPPATOrderID = grdView.GetDataRow(intPos).Item("PPATOrderID")
            .pubStatus = grdView.GetDataRow(intPos).Item("Status")
            .pubDraftBy = grdView.GetDataRow(intPos).Item("DraftBy")
            .pubProcessBy = grdView.GetDataRow(intPos).Item("ProcessBy")
            .pubIsFalse = grdView.GetDataRow(intPos).Item("IsFalse")
            .ShowDialog()
            If .pubIsSave Then pubRefresh()
        End With
    End Sub

    Private Sub prvQuery()
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

        If dtpDateFrom.Value > dtpDateTo.Value Then
            UI.usForm.frmMessageBox("Period Wrong")
            dtpDateFrom.Focus()
            Exit Sub
        End If

        If strJenisTransaksi.Trim = "" Then
            UI.usForm.frmMessageBox("Please select Jenis Transaksi")
            Exit Sub
        End If

        Dim dtData As DataTable = DL.PPATOrder.ListData(dtpDateFrom.Value, dtpDateTo.Value, cboStatus.SelectedIndex, strJenisTransaksi, False, chkShowProcessBy.Checked)
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


        Try
            grdMain.DataSource = dtData
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try
        'prvSetButton()
    End Sub

    Public Sub pubRefresh(Optional ByVal strSearch As String = "")
        With grdView
            If Not grdView.FocusedValue Is Nothing And strSearch = "" Then
                strSearch = grdView.GetDataRow(grdView.FocusedRowHandle).Item("PPATOrderID")
            End If
            prvQuery()
            If grdView.RowCount > 0 Then UI.usForm.GridMoveRow(grdView, "PPATOrderID", strSearch)
        End With
    End Sub

#End Region

#Region "Form Handle"

    Private Sub Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtpDateFrom.Value = Today.Year & "/" & Today.Month & "/" & "01 23:59:59"
        dtpDateTo.Value = dtpDateFrom.Value.AddMonths(1).AddDays(-1)
        cboStatus.SelectedIndex = 0
             chkShowProcessBy.Text = "Filter yg diproses oleh " & UI.usUserApp.UserID
        chkCheckPPAT.Checked = True
        prvSetIcon()
        prvSetButton()
        prvSetGrid()
        prvQuery()
    End Sub

    Private Sub ToolBar_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles ToolBar.ButtonClick
        If e.Button.Text = "New" Then
            prvNew()
        ElseIf e.Button.Text = "Refresh" Then
            pubRefresh()
        ElseIf grdView.FocusedRowHandle >= 0 Then
            Select Case e.Button.Text
                Case "Detail" : prvDetail()
                Case "Delete" : prvDelete()
                Case "Process" : prvProcess()
                Case "BPN Finish" : prvBPNFinish()
                Case "Completed" : prvCompleted()
                Case "False" : prvFalse()
            End Select
        End If
    End Sub

    Private Sub btnExecute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExecute.Click
        prvQuery()
    End Sub

    Private Sub grdMain_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdMain.DoubleClick
        'Me.prvGet()
        prvDetail()
    End Sub

    Private Sub grdView_RowStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles grdView.RowStyle
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
        If (e.RowHandle >= 0) Then
            Dim strIsFalse As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("IsFalse"))
            If strIsFalse = "Checked" Then
                e.Appearance.BackColor = Color.Salmon
                e.Appearance.BackColor2 = Color.WhiteSmoke
            End If
        End If
    End Sub

    Private Sub chkCheckPPAT_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCheckPPAT.CheckedChanged
        Dim intI As Integer
        For intI = 0 To chkListJenisTransaksi.Items.Count - 1
            If chkCheckPPAT.Checked Then
                chkListJenisTransaksi.SetItemChecked(intI, True)
            Else
                chkListJenisTransaksi.SetItemChecked(intI, False)
            End If
        Next
    End Sub

    'Agar Data Grid View Berwarna
    'Private Sub grdView_RowStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles grdView.RowStyle
    '    Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
    '    If (e.RowHandle >= 0) Then
    '        Dim strStatus As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Status"))
    '        If strStatus = "DRAFT" Then
    '            e.Appearance.BackColor = Color.DeepSkyBlue
    '            e.Appearance.BackColor2 = Color.LightCyan
    '        ElseIf strStatus = "PROCESS" Then
    '            e.Appearance.BackColor = Color.MediumPurple
    '            e.Appearance.BackColor2 = Color.LightCyan
    '        ElseIf strStatus = "COMPLETED" Then
    '            e.Appearance.BackColor = Color.LawnGreen
    '            e.Appearance.BackColor2 = Color.LightCyan
    '        End If
    '    End If
    'End Sub

#End Region

    Private Sub btnAllCompleted_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAllCompleted.Click
        If cboStatus.SelectedIndex <> 3 Then
            UI.usForm.frmMessageBox("Set All Completed hanya utk status BPN Finish")
            Exit Sub
        End If

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

        Try
            If Not UI.usForm.frmAskQuestion("Update semua data di list menjadi status COMPLETED ?") Then Exit Sub
            Dim dtData As DataTable = DL.PPATOrder.ListData(dtpDateFrom.Value, dtpDateTo.Value, cboStatus.SelectedIndex, strJenisTransaksi, False, chkShowProcessBy.Checked)
            Dim intPos As Integer = 0
            For Each drData1 As DataRow In dtData.Rows
                clsData.PPATOrderID = drData1.Item("PPATOrderID")
                clsData.Status = 4
                clsData.CompletedDate = Today
                clsData.CompletedRemarks = "SET ALL COMPLETED"
                DL.PPATOrder.UpdateCompleted(clsData)
                intPos += 1
            Next
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try
        UI.usForm.frmMessageBox("Update successful")
        prvQuery()
    End Sub
End Class
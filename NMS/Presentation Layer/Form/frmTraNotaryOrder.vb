Imports System.Net.Mail


Public Class frmTraNotaryOrder

#Region "Look Up"

    Private bolLookUp As Boolean = False
    Private bolLookUpGet As Boolean = False
    Private strLUNotaryOrderID As String
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

    Public Property pubLUNotaryOrderID() As String
        Get
            Return strLUNotaryOrderID
        End Get
        Set(ByVal Value As String)
            strLUNotaryOrderID = Value
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
        cNew = 0, cDetail = 1, cDelete = 2, cProcess = 4, cCompleted = 5, cFalse = 7, cRefresh = 8

    Private intPos As Integer
    Private clsData As New VO.NotaryOrder

    Private Sub prvSetIcon()
        UI.usForm.SetToolBar(Me, ToolBar, "0,New,1,Detail,2,Delete,4,Submit,5,Approved,7,Cancel,8,Refresh")
    End Sub

    Private Sub prvSetButton()
        Dim bolEdit, bolView, bolProcess, bolComplete, bolFalse As Boolean
        bolEdit = DL.MasterUser.IsAccess("NOTARY ORDER EDIT")
        bolView = DL.MasterUser.IsAccess("NOTARY ORDER VIEW")
        bolProcess = DL.MasterUser.IsAccess("NOTARY ORDER PROCESS")
        bolComplete = DL.MasterUser.IsAccess("NOTARY ORDER COMPLETE")
        bolFalse = DL.MasterUser.IsAccess("NOTARY ORDER FALSE")

        With ToolBar.Buttons
            .Item(cNew).Enabled = bolEdit
            .Item(cDetail).Enabled = IIf(bolEdit, bolEdit, bolView)
            .Item(cDelete).Enabled = bolEdit
            .Item(cProcess).Enabled = bolProcess
            .Item(cCompleted).Enabled = bolComplete
            .Item(cFalse).Enabled = bolFalse
        End With
    End Sub

    Private Sub prvSetGrid()
        UI.usForm.SetGrid(grdView, "NotaryOrderID", "Notary Order ID", 110, UI.usDefGrid.gString, True, True, True)
        UI.usForm.SetGrid(grdView, "JenisAkta", "Jenis Akta", 110, UI.usDefGrid.gString, True, True, True)
        UI.usForm.SetGrid(grdView, "NoUrut", "No Urut", 60, UI.usDefGrid.gString, True, True, True)
        UI.usForm.SetGrid(grdView, "NoBulanan", "No Bulanan", 80, UI.usDefGrid.gString, True, True, True)
        UI.usForm.SetGrid(grdView, "TglAkta", "Tanggal Akta", 90, UI.usDefGrid.gSmallDate, True, True, True)
        UI.usForm.SetGrid(grdView, "SifatAkta", "Sifat Akta", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "JenisTransaksi", "Jenis Transaksi", 120, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "Status", "Status", 70, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "NoID", "No ID Pihak I", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "Nama", "Nama Pihak I", 150, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "NoID2", "No ID Pihak II", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "Nama2", "Nama Pihak II", 150, UI.usDefGrid.gString)

        UI.usForm.SetGrid(grdView, "IsFalseLevelStr", "Is False Creator", 110, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "IsFalse", "Is False", 70, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "IsFalseBy", "Is False By", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "IsFalseDate", "Is False Date", 150, UI.usDefGrid.gFullDate)
        UI.usForm.SetGrid(grdView, "IsFalseRemarks", "Is False Remarks", 150, UI.usDefGrid.gString)
     
        UI.usForm.SetGrid(grdView, "Remarks", "Remarks", 150, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "FileLocation", "Scan Data", 70, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "DraftBy", "Draft By", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "DraftDate", "Draft Date", 150, UI.usDefGrid.gFullDate)
        UI.usForm.SetGrid(grdView, "ProcessBy", "Process By", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "ProcessDate", "Process Date", 150, UI.usDefGrid.gFullDate)
        UI.usForm.SetGrid(grdView, "ProcessRemarks", "Process Remarks", 150, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "CompletedBy", "Completed By", 140, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "CompletedDate", "Completed Date", 150, UI.usDefGrid.gFullDate)
        UI.usForm.SetGrid(grdView, "CompletedRemarks", "Completed Remarks", 180, UI.usDefGrid.gString)

        grdView.Columns.Item("NoID").AppearanceCell.BackColor = Color.LightYellow
        grdView.Columns.Item("Nama").AppearanceCell.BackColor = Color.LightYellow
        grdView.Columns.Item("NoID2").AppearanceCell.BackColor = Color.LightYellow
        grdView.Columns.Item("Nama2").AppearanceCell.BackColor = Color.LightYellow
        grdView.Columns.Item("IsFalseLevelStr").AppearanceCell.BackColor = Color.LightYellow
        grdView.Columns.Item("IsFalse").AppearanceCell.BackColor = Color.LightYellow
        grdView.Columns.Item("FileLocation").AppearanceCell.BackColor = Color.LightBlue

        'Filter
        grdView.Columns.Item("NotaryOrderID").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdView.Columns.Item("JenisAkta").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdView.Columns.Item("NoUrut").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdView.Columns.Item("NoBulanan").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdView.Columns.Item("SifatAkta").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdView.Columns.Item("JenisTransaksi").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdView.Columns.Item("Status").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdView.Columns.Item("NoID").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdView.Columns.Item("Nama").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdView.Columns.Item("NoID2").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdView.Columns.Item("Nama2").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdView.Columns.Item("IsFalseBy").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains

    End Sub

    Private Sub prvSetLookUp()
        If bolLookUp Then
            UI.usForm.GridMoveRow(grdView, "NotaryOrderID", strLUNotaryOrderID)
        End If
    End Sub

    Private Sub prvGet()
        intPos = grdView.FocusedRowHandle
        If bolLookUp And intPos >= 0 Then
            strLUNotaryOrderID = grdView.GetDataRow(intPos).Item("NotaryOrderID")
            dtrLUDataRow = grdView.GetDataRow(grdView.FocusedRowHandle)
            bolLookUpGet = True
            Me.Close()
        End If
    End Sub

    Private Sub prvNew()
        Dim frmDetail As New frmTraNotaryOrderDet
        With frmDetail
            .pubIsNew = True
            .pubShowDialog(Me)
        End With
    End Sub

    Private Sub prvDetail()
        intPos = grdView.FocusedRowHandle
        Dim frmDetail As New frmTraNotaryOrderDet
        With frmDetail
            .pubIsNew = False
            .pubNotaryOrderID = grdView.GetDataRow(intPos).Item("NotaryOrderID")
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

        Dim strNotaryOrderID As String = grdView.GetDataRow(intPos).Item("NotaryOrderID")
        Try
            If Not UI.usForm.frmAskQuestion("Hapus Notary Order ID " & strNotaryOrderID & " ?") Then Exit Sub
            DL.NotaryOrder.DeleteClient3(strNotaryOrderID)
            DL.NotaryOrder.DeleteClient2(strNotaryOrderID)
            DL.NotaryOrder.DeleteClient1(strNotaryOrderID)
            DL.NotaryOrder.DeleteHeader(strNotaryOrderID)
            Try
                RmDir(UI.usUserApp.FileLocation & strNotaryOrderID)
            Catch ex As Exception
                Kill(UI.usUserApp.FileLocation & strNotaryOrderID & "\*.*")
                RmDir(UI.usUserApp.FileLocation & strNotaryOrderID)
            End Try

            UI.usForm.frmMessageBox(strNotaryOrderID & " berhasil dihapus ! ")
            pubRefresh()
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try

    End Sub

    Private Sub prvProcess()
        intPos = grdView.FocusedRowHandle
        If grdView.GetDataRow(intPos).Item("Status") = "COMPLETED" Then
            UI.usForm.frmMessageBox("Status COMPLETED tidak bisa melakukan proses ini !")
            Exit Sub
        End If

        If grdView.GetDataRow(intPos).Item("FileLocation") = "Empty" Then
            UI.usForm.frmMessageBox("Scan Data yang kosong tidak bisa melanjutkan ke status Process !")
            Exit Sub
        End If

        Dim frmDetail As New frmTraNotaryOrderProcess
        With frmDetail
            .pubNotaryOrderID = grdView.GetDataRow(intPos).Item("NotaryOrderID")
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

        Dim frmDetail As New frmTraNotaryOrderCompleted
        With frmDetail
            .pubNotaryOrderID = grdView.GetDataRow(intPos).Item("NotaryOrderID")
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

        Dim frmDetail As New frmTraNotaryOrderFalse
        With frmDetail
            .pubNotaryOrderID = grdView.GetDataRow(intPos).Item("NotaryOrderID")
            .pubStatus = grdView.GetDataRow(intPos).Item("Status")
            .pubDraftBy = grdView.GetDataRow(intPos).Item("DraftBy")
            .pubProcessBy = grdView.GetDataRow(intPos).Item("ProcessBy")
            .pubIsFalse = grdView.GetDataRow(intPos).Item("IsFalse")
            .ShowDialog()
            If .pubIsSave Then pubRefresh()
        End With
    End Sub

    Private Sub prvQuery()
        If dtpDateFrom.Value > dtpDateTo.Value Then
            UI.usForm.frmMessageBox("Period Wrong")
            dtpDateFrom.Focus()
            Exit Sub
        End If

        Dim dtData As DataTable = DL.NotaryOrder.ListData(dtpDateFrom.Value, dtpDateTo.Value, cboStatus.SelectedIndex, False, chkShowProcessBy.Checked)
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
                strSearch = grdView.GetDataRow(grdView.FocusedRowHandle).Item("NotaryOrderID")
            End If
            prvQuery()
            If grdView.RowCount > 0 Then UI.usForm.GridMoveRow(grdView, "NotaryOrderID", strSearch)
        End With
    End Sub

#End Region

#Region "Form Handle"

    Private Sub Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtpDateFrom.Value = Today.Year & "/" & Today.Month & "/" & "01 23:59:59"
        dtpDateTo.Value = dtpDateFrom.Value.AddMonths(1).AddDays(-1)
        cboStatus.SelectedIndex = 0
        chkShowProcessBy.Text = "Filter yg diproses oleh " & UI.usUserApp.UserID
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

    Private Sub btnAllCompleted_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAllCompleted.Click
        If cboStatus.SelectedIndex <> 2 Then
            UI.usForm.frmMessageBox("Set All Completed hanya utk status Process")
            Exit Sub
        End If

        Try
            If Not UI.usForm.frmAskQuestion("Update semua data di list menjadi status COMPLETED ?") Then Exit Sub
            Dim dtData As DataTable = DL.NotaryOrder.ListData(dtpDateFrom.Value, dtpDateTo.Value, cboStatus.SelectedIndex, False, chkShowProcessBy.Checked)
            Dim intPos As Integer = 0
            For Each drData1 As DataRow In dtData.Rows
                clsData.NotaryOrderID = drData1.Item("NotaryOrderID")
                clsData.Status = 3
                clsData.CompletedRemarks = "SET ALL COMPLETED"
                DL.NotaryOrder.UpdateCompleted(clsData)
                intPos += 1
            Next
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try
        UI.usForm.frmMessageBox("Update successful")
        prvQuery()
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

    
End Class
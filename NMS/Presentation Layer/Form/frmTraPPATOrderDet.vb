Public Class frmTraPPATOrderDet
#Region "Property"

    Private frmParent As frmTraPPATOrder
    Private frmParentClient As frmMstClientDet
    Private frmParentNotification As frmSysNotification
    Private bolNew, bolSave, bolClient As Boolean
    Private strPPATOrderID As String = ""

    Public WriteOnly Property pubIsNew() As Boolean
        Set(ByVal Value As Boolean)
            bolNew = Value
        End Set
    End Property

    Public ReadOnly Property pubIsSave() As Boolean
        Get
            Return bolSave
        End Get
    End Property

    Public WriteOnly Property pubIsClient() As Boolean
        Set(ByVal Value As Boolean)
            bolClient = Value
        End Set
    End Property

    Public Property pubPPATOrderID() As String
        Get
            Return strPPATOrderID
        End Get
        Set(ByVal Value As String)
            strPPATOrderID = Value
        End Set
    End Property

#End Region

#Region "Function"

    Private Const _
       cSave = 0, cExit = 1

    Private clsData As New VO.PPATOrder
    'intPos menentukan index tiap datagridview 1,2,3
    Private intPos1 As Integer
    Private intPos2 As Integer
    Private intPosTemp As Integer

    Public Sub pubShowDialog(ByVal frmGetParent As Form)
        frmParent = frmGetParent
        Me.ShowDialog()
    End Sub

    Public Sub pubShowDialogClient(ByVal frmGetParentClient As Form)
        frmParentClient = frmGetParentClient
        Me.ShowDialog()
    End Sub

    Public Sub pubShowDialogNotification(ByVal frmGetParentNotification As Form)
        frmParentNotification = frmGetParentNotification
        Me.ShowDialog()
    End Sub

    Private Sub prvSetIcon()
        UI.usForm.SetToolBar(Me, ToolBar, "0,Save,1,Close")
        UI.usForm.SetToolBar(Me, ToolBarDetail, "0,New,1,Detail,2,Delete")
        UI.usForm.SetToolBar(Me, ToolBarDetail2, "0,New,1,Detail,2,Delete")
    End Sub

    Private Sub prvSetButton()
        Dim bolEdit As Boolean
        bolEdit = DL.MasterUser.IsAccess("PPAT ORDER EDIT")

        With ToolBar.Buttons
            .Item(0).Enabled = bolEdit
        End With
    End Sub

    Private Sub prvSetTitleForm()
        If bolNew Then
            Me.Text += " [new] "
        Else
            Me.Text += " [edit] " & strPPATOrderID
        End If
    End Sub

    Private Sub prvFillForm()
        'clsData utk menampung entity PPATOrder
        'grdClient1.DataSource Harus diset agar tidak error wkt Fill Data Grid
        Try
            clsData = DL.PPATOrder.GetDetail(strPPATOrderID)
            grdClient1.DataSource = DL.PPATOrder.ListClient1(strPPATOrderID)
            grdClient2.DataSource = DL.PPATOrder.ListClient2(strPPATOrderID)

            grdItemView.Columns.Item("Index").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
            grdItemView2.Columns.Item("Index").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending

            If Not bolNew Then
                txtPPATOrderID.Text = strPPATOrderID
                txtNoAkta.Text = clsData.NoAkta
                dtpTanggalAkta.Value = clsData.TglAkta
                cboJenisTransaksi.SelectedIndex = clsData.JenisTransaksi
                numExpInterval.Value = clsData.ExpInterval
                txtJenisNoHak.Text = clsData.JenisNoHak
                txtProcessUserID.Text = clsData.ProcessUserID
                txtLetakTanah.Text = clsData.LetakTanahBangunan
                numLuasTanah.Value = clsData.LuasTanahM2
                numLuasBangunan.Value = clsData.LuasBangunanM2
                numHargaTransaksi.Value = clsData.HargaTransaksi
                txtSPPTPBBNOPTahun.Text = clsData.SPPTPBBNOPTahun
                numSPPTPBBNJOP.Value = clsData.SPPTPBBNJOP
                dtpSSPTanggal.Value = clsData.SSPTanggal
                numSSPHarga.Value = clsData.SSPHarga
                dtpSSBTanggal.Value = clsData.SSBTanggal
                numSSBHarga.Value = clsData.SSBHarga

                txtFileLocation.Text = clsData.FileLocation
                txtRemarks.Text = clsData.Remarks
                dtpTglPenyerahanDokumen.Value = clsData.TglPenyerahanDokumen
                Me.tbcPPAT.SelectedIndex = 0

                If clsData.StatusStr = "DRAFT" Then
                    ToolStripStatus.Text = "STATUS : " & clsData.StatusStr
                    ToolStripDraftBy.Text = "DRAFT BY : " & clsData.DraftBy

                    ToolStripStatus.Visible = True
                    ToolStripDraftBy.Visible = True
                    ToolStripStatus.BackColor = ToolStripDraftBy.BackColor

                ElseIf clsData.StatusStr = "PROCESS" Then
                    ToolStripStatus.Text = "STATUS : " & clsData.StatusStr
                    ToolStripDraftBy.Text = "DRAFT BY : " & clsData.DraftBy
                    ToolStripProcessBy.Text = "PROCESS BY : " & clsData.ProcessBy
                    ToolStripProcessDate.Text = "PROCESS DATE : " & Format(clsData.ProcessDate, UI.usDefCons.DateFull)

                    ToolStripStatus.Visible = True
                    ToolStripDraftBy.Visible = True
                    ToolStripProcessBy.Visible = True
                    ToolStripProcessDate.Visible = True
                    ToolStripStatus.BackColor = ToolStripProcessBy.BackColor

                ElseIf clsData.StatusStr = "BPN FINISH" Then
                    ToolStripStatus.Text = "STATUS : " & clsData.StatusStr
                    ToolStripDraftBy.Text = "DRAFT BY : " & clsData.DraftBy
                    ToolStripProcessBy.Text = "PROCESS BY : " & clsData.ProcessBy
                    ToolStripProcessDate.Text = "PROCESS DATE : " & Format(clsData.ProcessDate, UI.usDefCons.DateFull)
                    ToolStripBPNFinishBy.Text = "BPN FINISH BY : " & clsData.BPNFinishBy
                    ToolStripBPNFinishDate.Text = "BPN FINISH DATE : " & Format(clsData.BPNFinishDate, UI.usDefCons.DateFull)

                    ToolStripStatus.Visible = True
                    ToolStripDraftBy.Visible = True
                    ToolStripProcessBy.Visible = True
                    ToolStripProcessDate.Visible = True
                    ToolStripBPNFinishBy.Visible = True
                    ToolStripBPNFinishDate.Visible = True
                    ToolStripStatus.BackColor = ToolStripBPNFinishBy.BackColor

                ElseIf clsData.StatusStr = "COMPLETED" Then
                    ToolStripStatus.Text = "STATUS : " & clsData.StatusStr
                    ToolStripDraftBy.Text = "DRAFT BY : " & clsData.DraftBy
                    ToolStripProcessBy.Text = "PROCESS BY : " & clsData.ProcessBy
                    ToolStripProcessDate.Text = "PROCESS DATE : " & Format(clsData.ProcessDate, UI.usDefCons.DateFull)
                    ToolStripBPNFinishBy.Text = "BPN FINISH BY : " & clsData.BPNFinishBy
                    ToolStripBPNFinishDate.Text = "BPN FINISH DATE : " & Format(clsData.BPNFinishDate, UI.usDefCons.DateFull)
                    ToolStripCompletedBy.Text = "COMPLETED BY : " & clsData.CompletedBy
                    ToolStripCompletedDate.Text = "COMPLETED DATE : " & Format(clsData.CompletedDate, UI.usDefCons.DateFull)

                    ToolStripStatus.Visible = True
                    ToolStripDraftBy.Visible = True
                    ToolStripProcessBy.Visible = True
                    ToolStripProcessDate.Visible = True
                    ToolStripBPNFinishBy.Visible = True
                    ToolStripBPNFinishDate.Visible = True
                    ToolStripCompletedBy.Visible = True
                    ToolStripCompletedDate.Visible = True
                    ToolStripStatus.BackColor = ToolStripCompletedBy.BackColor
                End If
            Else
                dtpTanggalAkta.Value = Today
                dtpTglPenyerahanDokumen.Value = Today
                dtpSSPTanggal.Value = Today
                dtpSSBTanggal.Value = Today
                cboJenisTransaksi.SelectedIndex = 0

            End If
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try
    End Sub

    Private Sub prvSetGrid()
        grdItemView.OptionsView.ColumnAutoWidth = False
        UI.usForm.SetGrid(grdItemView, "Index", "Index", 70, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdItemView, "JenisID", "Jenis ID", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemView, "NoID", "No ID", 130, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemView, "WargaNegara", "Warga Negara", 120, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemView, "Negara", "Negara", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemView, "Title", "Title", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdItemView, "Nama", "Nama", 130, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemView, "TempatLahir", "Tempat Lahir", 120, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemView, "TglLahir", "Tanggal Lahir", 100, UI.usDefGrid.gSmallDate)
        UI.usForm.SetGrid(grdItemView, "TglLahirStr", "TglLahirStr", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdItemView, "Alamat", "Alamat", 150, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemView, "Pekerjaan", "Pekerjaan", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemView, "NoNPWP", "No NPWP", 130, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemView, "NoTelp", "No Telepon", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemView, "NoHP", "No HP", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemView, "Remarks", "Keterangan", 150, UI.usDefGrid.gString)
    End Sub

    Private Sub prvSetGrid2()
        grdItemView2.OptionsView.ColumnAutoWidth = False
        UI.usForm.SetGrid(grdItemView2, "Index", "Index", 70, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdItemView2, "JenisID", "Jenis ID", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemView2, "NoID", "No ID", 130, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemView2, "WargaNegara", "Warga Negara", 120, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemView2, "Negara", "Negara", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemView2, "Title", "Title", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdItemView2, "Nama", "Nama", 130, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemView2, "TempatLahir", "Tempat Lahir", 120, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemView2, "TglLahir", "Tanggal Lahir", 100, UI.usDefGrid.gSmallDate)
        UI.usForm.SetGrid(grdItemView2, "TglLahirStr", "TglLahirStr", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdItemView2, "Alamat", "Alamat", 150, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemView2, "Pekerjaan", "Pekerjaan", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemView2, "NoNPWP", "No NPWP", 130, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemView2, "NoTelp", "No Telepon", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemView2, "NoHP", "No HP", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemView2, "Remarks", "Keterangan", 150, UI.usDefGrid.gString)
    End Sub

    Public Sub pubRefresh()
        grdClient1.Refresh()
        grdClient2.Refresh()
    End Sub

    Private Function ValidateData() As Boolean
        If Not bolNew And clsData.StatusStr = "COMPLETED" Then
            UI.usForm.frmMessageBox("Edit Data tidak bisa untuk Status COMPLETED")
            Return False
        End If

        If grdItemView.RowCount = 0 Then
            UI.usForm.frmMessageBox("Pihak I harus diisi")
            Return False
        End If

        'If grdItemView2.RowCount = 0 Then
        '    UI.usForm.frmMessageBox("Pihak II harus diisi")
        '    Return False
        'End If

        If DL.PPATOrder.CheckValidNoAkta(dtpTanggalAkta.Value, txtNoAkta.Text, txtPPATOrderID.Text) Then
            UI.usForm.frmMessageBox("No Akta tidak boleh sama dalam satu bulan")
            Return False
        End If

        If txtProcessUserID.Text = "" Then
            UI.usForm.frmMessageBox("Nama Admin yang memproses akta harus diisi")
            Return False
        End If

        Return True
    End Function

    Private Sub prvSave()
        If Not ValidateData() Then Exit Sub

        'Jika New Generate PPAT Order Baru
        If bolNew Then txtPPATOrderID.Text = DL.PPATOrder.PPATOrderID(Today)

        'Simpan Header PPAT Order di VO
        clsData.PPATOrderID = txtPPATOrderID.Text
        clsData.NoAkta = txtNoAkta.Text
        clsData.TglAkta = dtpTanggalAkta.Value
        clsData.JenisTransaksi = cboJenisTransaksi.SelectedIndex
        clsData.ExpInterval = numExpInterval.Value
        clsData.JenisNoHak = txtJenisNoHak.Text
        clsData.ProcessUserID = txtProcessUserID.Text
        clsData.LetakTanahBangunan = txtLetakTanah.Text
        clsData.LuasTanahM2 = numLuasTanah.Value
        clsData.LuasBangunanM2 = numLuasBangunan.Value
        clsData.HargaTransaksi = numHargaTransaksi.Value
        clsData.SPPTPBBNOPTahun = txtSPPTPBBNOPTahun.Text
        clsData.SPPTPBBNJOP = numSPPTPBBNJOP.Value
        clsData.SSPTanggal = dtpSSPTanggal.Value
        clsData.SSPHarga = numSSPHarga.Value
        clsData.SSBTanggal = dtpSSBTanggal.Value
        clsData.SSBHarga = numSSBHarga.Value

        txtFileLocation.Text = UI.usUserApp.FileLocation & txtPPATOrderID.Text
        clsData.FileLocation = txtFileLocation.Text
        clsData.Remarks = txtRemarks.Text
        clsData.TglPenyerahanDokumen = dtpTglPenyerahanDokumen.Value


        'Simpan Client1 PPAT Order di VO
        Dim dtData1 As DataTable = grdClient1.DataSource
        Dim clsDataClient1 As VO.PPATClientDet1
        Dim clsDataAllClient1() As VO.PPATClientDet1
        ReDim clsDataAllClient1(grdItemView.RowCount - 1)

        'ubah semua intPos
        Dim intPos1 As Integer = 0
        For Each drData1 As DataRow In dtData1.Rows
            clsDataClient1 = New VO.PPATClientDet1
            clsDataClient1.PPATOrderID = txtPPATOrderID.Text
            clsDataClient1.Index = drData1.Item("Index")
            clsDataClient1.JenisID = drData1.Item("JenisID")
            clsDataClient1.NoID = drData1.Item("NoID")
            clsDataClient1.WargaNegara = drData1.Item("WargaNegara")
            clsDataClient1.Negara = drData1.Item("Negara")
            clsDataClient1.Title = drData1.Item("Title")
            clsDataClient1.Nama = drData1.Item("Nama")
            clsDataClient1.TempatLahir = drData1.Item("TempatLahir")
            clsDataClient1.TglLahir = drData1.Item("TglLahir")
            clsDataClient1.TglLahirStr = drData1.Item("TglLahirStr")
            clsDataClient1.Alamat = drData1.Item("Alamat")
            clsDataClient1.Pekerjaan = drData1.Item("Pekerjaan")
            clsDataClient1.NoNPWP = drData1.Item("NoNPWP")
            clsDataClient1.NoTelp = drData1.Item("NoTelp")
            clsDataClient1.NoHP = drData1.Item("NoHP")
            clsDataClient1.Remarks = drData1.Item("Remarks")
            clsDataAllClient1(intPos1) = clsDataClient1
            intPos1 += 1
        Next

        'Simpan Client2 PPAT Order di VO
        Dim dtData2 As DataTable = grdClient2.DataSource
        Dim clsDataClient2 As VO.PPATClientDet2
        Dim clsDataAllClient2() As VO.PPATClientDet2
        ReDim clsDataAllClient2(grdItemView2.RowCount - 1)

        Dim intPos2 As Integer = 0
        For Each drData2 As DataRow In dtData2.Rows
            clsDataClient2 = New VO.PPATClientDet2
            clsDataClient2.PPATOrderID = txtPPATOrderID.Text
            clsDataClient2.Index = drData2.Item("Index")
            clsDataClient2.JenisID = drData2.Item("JenisID")
            clsDataClient2.NoID = drData2.Item("NoID")
            clsDataClient2.WargaNegara = drData2.Item("WargaNegara")
            clsDataClient2.Negara = drData2.Item("Negara")
            clsDataClient2.Title = drData2.Item("Title")
            clsDataClient2.Nama = drData2.Item("Nama")
            clsDataClient2.TempatLahir = drData2.Item("TempatLahir")
            clsDataClient2.TglLahir = drData2.Item("TglLahir")
            clsDataClient2.TglLahirStr = drData2.Item("TglLahirStr")
            clsDataClient2.Alamat = drData2.Item("Alamat")
            clsDataClient2.Pekerjaan = drData2.Item("Pekerjaan")
            clsDataClient2.NoNPWP = drData2.Item("NoNPWP")
            clsDataClient2.NoTelp = drData2.Item("NoTelp")
            clsDataClient2.NoHP = drData2.Item("NoHP")
            clsDataClient2.Remarks = drData2.Item("Remarks")
            clsDataAllClient2(intPos2) = clsDataClient2
            intPos2 += 1
        Next

        Try
            'Simpan semua Data Header dan Client Detail
            DL.PPATOrder.SaveAllData(bolNew, txtPPATOrderID.Text, clsData, clsDataAllClient1, clsDataAllClient2)
            bolSave = True
            If bolNew Then
                UI.usForm.frmMessageBox("Save Success ! PPAT Order ID : " & txtPPATOrderID.Text)
                MkDir(txtFileLocation.Text)
                prvFileLocation()
                frmParent.pubRefresh(txtPPATOrderID.Text)
                bolNew = False
            Else
                UI.usForm.frmMessageBox("Update Success ! PPAT Order ID : " & txtPPATOrderID.Text)
                If bolClient = False Then frmParent.pubRefresh(txtPPATOrderID.Text)
                Me.Close()
            End If
        Catch ex As Exception
            bolSave = False
            UI.usForm.frmMessageBox(ex.Message)
        End Try
    End Sub

    Private Sub prvClient1New()
        Dim frmDetail As New frmTraPPATOrderClient1
        If grdItemView.RowCount = 0 Then
            intPosTemp = 0
        Else
            intPos1 = grdItemView.RowCount - 1
            intPosTemp = grdItemView.GetDataRow(intPos1).Item("Index")
        End If
        With frmDetail
            .pubIsNew = True
            .pubIndex = intPosTemp
            .pubShowDialog(Me)
        End With
    End Sub

    Private Sub prvClient1Detail()
        intPos1 = grdItemView.FocusedRowHandle
        Dim frmDetail As New frmTraPPATOrderClient1
        With frmDetail
            .pubIsNew = False
            .pubPPATOrderID = txtPPATOrderID.Text
            .pubNoID = grdItemView.GetDataRow(intPos1).Item("NoID")
            .pubShowDialog(Me)
        End With
    End Sub

    Private Sub prvClient1Delete()
        Dim dtTable As DataTable = grdClient1.DataSource
        intPos1 = grdItemView.FocusedRowHandle
        Dim strNoID As String = grdItemView.GetDataRow(intPos1).Item("NoID")
        Dim strNama As String = grdItemView.GetDataRow(intPos1).Item("Nama")

        If UI.usForm.frmAskQuestion("Delete Pihak I No ID : " & strNoID & " Nama : " & strNama & " ?") Then
            For Each drdata As DataRow In dtTable.Rows
                If drdata.Item("NoID") = strNoID And drdata.Item("Nama") = strNama Then
                    drdata.Delete()
                End If
            Next
            dtTable.AcceptChanges()
            pubRefresh()
        End If
    End Sub

    Private Sub prvClient2New()
        Dim frmDetail As New frmTraPPATOrderClient2
        If grdItemView2.RowCount = 0 Then
            intPosTemp = 0
        Else
            intPos2 = grdItemView2.RowCount - 1
            intPosTemp = grdItemView2.GetDataRow(intPos2).Item("Index")
        End If
        With frmDetail
            .pubIsNew = True
            .pubIndex = intPosTemp
            .pubShowDialog(Me)
        End With
    End Sub

    Private Sub prvClient2Detail()
        intPos2 = grdItemView2.FocusedRowHandle
        Dim frmDetail As New frmTraPPATOrderClient2
        With frmDetail
            .pubIsNew = False
            .pubPPATOrderID = txtPPATOrderID.Text
            .pubNoID = grdItemView2.GetDataRow(intPos2).Item("NoID")
            .pubShowDialog(Me)
        End With
    End Sub

    Private Sub prvClient2Delete()
        Dim dtTable As DataTable = grdClient2.DataSource
        intPos2 = grdItemView2.FocusedRowHandle
        Dim strNoID As String = grdItemView2.GetDataRow(intPos2).Item("NoID")
        Dim strNama As String = grdItemView2.GetDataRow(intPos2).Item("Nama")

        If UI.usForm.frmAskQuestion("Delete Pihak II No ID : " & strNoID & " Nama : " & strNama & " ?") Then
            For Each drdata As DataRow In dtTable.Rows
                If drdata.Item("NoID") = strNoID And drdata.Item("Nama") = strNama Then
                    drdata.Delete()
                End If
            Next
            dtTable.AcceptChanges()
            pubRefresh()
        End If
    End Sub

    Private Sub prvFileLocation()
        If txtFileLocation.Text = "" Then
            UI.usForm.frmMessageBox("File Location tidak boleh kosong")
            Exit Sub
        End If

        'Dim frmDetail As New frmSysFileLocation
        'With frmDetail
        '    .pubPath = txtFileLocation.Text
        '    .pubShowDialogPPAT(Me)
        'End With

        Dim OpenFileDialog1 As New OpenFileDialog
        With OpenFileDialog1
            .Filter = "All Files (*.*)|*.*"
            .Multiselect = True
            .InitialDirectory = txtFileLocation.Text
            If Not OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.Cancel Then
                Using fileprocess As Process = Process.Start(OpenFileDialog1.FileName)
                    fileprocess.WaitForExit()
                End Using
            End If
        End With
    End Sub

#End Region

#Region "Form Handle"

    Private Sub Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        prvSetIcon()
        prvSetGrid()
        prvSetGrid2()
        prvFillForm()
        prvSetButton()
        pubRefresh()
    End Sub

    Private Sub ToolBar_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles ToolBar.ButtonClick
        If e.Button.Text = "Save" Then
            prvSave()
        Else
            Me.Close()
        End If
    End Sub

    Private Sub ToolBarDetail_ButtonClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles ToolBarDetail.ButtonClick
        If e.Button.Text = "New" Then
            prvClient1New()
        ElseIf grdItemView.FocusedRowHandle >= 0 Then
            Select Case e.Button.Text
                Case "Detail" : prvClient1Detail()
                Case "Delete" : prvClient1Delete()
            End Select
        End If
    End Sub

    Private Sub ToolBarDetail2_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles ToolBarDetail2.ButtonClick
        If e.Button.Text = "New" Then
            prvClient2New()
        ElseIf grdItemView2.FocusedRowHandle >= 0 Then
            Select Case e.Button.Text
                Case "Detail" : prvClient2Detail()
                Case "Delete" : prvClient2Delete()
            End Select
        End If
    End Sub

    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown, tbcPPAT.KeyDown, grdClient2.KeyDown, grdClient1.KeyDown
        If e.KeyCode = Keys.Escape Then
            If UI.usForm.frmAskQuestion("Close PPAT Order ?") Then Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Me.tbcPPAT.SelectedIndex = 0
        ElseIf e.KeyCode = Keys.F2 Then
            Me.tbcPPAT.SelectedIndex = 1
        ElseIf e.KeyCode = Keys.F3 Then
            Me.tbcPPAT.SelectedIndex = 2
        ElseIf e.KeyCode = Keys.F4 Then
            Me.tbcPPAT.SelectedIndex = 3
        ElseIf e.KeyCode = Keys.F5 Then
            Me.tbcPPAT.SelectedIndex = 4
        End If
    End Sub

    'Private Sub txtRemarks_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRemarks.Leave
    '    If txtJenisNoHak.Text <> "" Then
    '        Me.tbcPPAT.SelectedIndex = 1
    '    End If
    'End Sub

    'Private Sub numHargaTransaksi_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numHargaTransaksi.Leave
    '    If txtLetakTanah.Text <> "" And numLuasTanah.Value <> 0 And numLuasBangunan.Value <> 0 And numHargaTransaksi.Value <> 0 Then
    '        Me.tbcPPAT.SelectedIndex = 2
    '    End If
    'End Sub

    'Private Sub numSPPTPBBNJOP_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numSPPTPBBNJOP.Leave
    '    If txtSPPTPBBNOPTahun.Text <> "" And numSPPTPBBNJOP.Value <> 0 Then
    '        Me.tbcPPAT.SelectedIndex = 3
    '    End If
    'End Sub

    'Private Sub numSSPHarga_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numSSPHarga.Leave
    '    If numSSPHarga.Value <> 0 Then
    '        Me.tbcPPAT.SelectedIndex = 4
    '    End If
    'End Sub

    'Private Sub numSSBHarga_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numSSBHarga.Leave
    '    If numSSBHarga.Value <> 0 Then
    '        Me.tbcPPAT.SelectedIndex = 0
    '    End If
    'End Sub

    Private Sub btnFileLocation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFileLocation.Click
        prvFileLocation()
    End Sub

    Private Sub btnUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUser.Click
        Dim frmDetail As New frmMstUser
        With frmDetail
            .pubIsLookUp = True
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
            If .pubIsLookUpGet Then
                txtProcessUserID.Text = .pubLUDataRow("UserID")
            End If
        End With
    End Sub

#End Region

End Class
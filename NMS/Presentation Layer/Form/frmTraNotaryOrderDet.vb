Public Class frmTraNotaryOrderDet
#Region "Property"

    Private frmParent As frmTraNotaryOrder
    Private frmParentClient As frmMstClientDet
    Private frmParentNotification As frmSysNotification
    Private bolNew, bolSave, bolClient As Boolean
    Private strNotaryOrderID As String = ""

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

    Public Property pubNotaryOrderID() As String
        Get
            Return strNotaryOrderID
        End Get
        Set(ByVal Value As String)
            strNotaryOrderID = Value
        End Set
    End Property

#End Region

#Region "Function"

    Private Const _
       cSave = 0, cExit = 1

    Private clsData As New VO.NotaryOrder
    'intPos menentukan index tiap datagridview 1,2,3
    Private intPos1 As Integer
    Private intPos2 As Integer
    Private intPos3 As Integer
    Private intPosTemp As Integer
    'Public dtNotaryClient1 As DataTable

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
        UI.usForm.SetToolBar(Me, ToolBarDetail3, "0,New,1,Detail,2,Delete")
    End Sub

    Private Sub prvSetTitleForm()
        If bolNew Then
            Me.Text += " [new] "
        Else
            Me.Text += " [edit] " & strNotaryOrderID
        End If
    End Sub

    Private Sub prvSetButton()
        Dim bolEdit As Boolean
        bolEdit = DL.MasterUser.IsAccess("NOTARY ORDER EDIT")
      
        With ToolBar.Buttons
            .Item(0).Enabled = bolEdit
        End With
    End Sub

    Private Sub prvFillForm()
        'clsData utk menampung entity NotaryOrder
        'grdItem.DataSource Harus diset agar tidak error wkt Fill Data Grid
        Try
            clsData = DL.NotaryOrder.GetDetail(strNotaryOrderID)
            grdClient1.DataSource = DL.NotaryOrder.ListClient1(strNotaryOrderID)
            grdClient2.DataSource = DL.NotaryOrder.ListClient2(strNotaryOrderID)
            grdClient3.DataSource = DL.NotaryOrder.ListClient3(strNotaryOrderID)

            'untuk mengurutkan data Index
            grdItemView.Columns.Item("Index").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
            grdItemView2.Columns.Item("Index").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
            grdItemView3.Columns.Item("Index").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending

            If Not bolNew Then
                txtNotaryOrderID.Text = strNotaryOrderID
                cboJenisAkta.SelectedIndex = clsData.JenisAkta
                txtNoUrut.Text = clsData.NoUrut
                txtNoBulanan.Text = clsData.NoBulanan
                dtpTanggalAkta.Value = clsData.TglAkta
                dtpTglDidaftarkan.Value = clsData.TglDidaftarkan
                cboJenisTransaksi.Text = clsData.JenisTransaksi
                txtSifatAkta.Text = clsData.SifatAkta
                txtFileLocation.Text = clsData.FileLocation
                txtRemarks.Text = clsData.Remarks
                txtProcessUserID.Text = clsData.ProcessUserID
                numExpInterval.Value = clsData.ExpInterval


                If clsData.StatusStr = "DRAFT" Then
                    ToolStripStatus.Text = "STATUS : " & clsData.StatusStr
                    ToolStripDraftBy.Text = "DRAFT BY : " & clsData.DraftBy
                    ToolStripDraftDate.Text = "DRAFT DATE : " & Format(clsData.DraftDate, UI.usDefCons.DateFull)

                    ToolStripStatus.Visible = True
                    ToolStripDraftBy.Visible = True
                    ToolStripDraftDate.Visible = True
                    ToolStripStatus.BackColor = ToolStripDraftBy.BackColor

                ElseIf clsData.StatusStr = "PROCESS" Then
                    ToolStripStatus.Text = "STATUS : " & clsData.StatusStr
                    ToolStripDraftBy.Text = "DRAFT BY : " & clsData.DraftBy
                    ToolStripDraftDate.Text = "DRAFT DATE : " & Format(clsData.DraftDate, UI.usDefCons.DateFull)
                    ToolStripProcessBy.Text = "PROCESS BY : " & clsData.ProcessBy
                    ToolStripProcessDate.Text = "PROCESS DATE : " & Format(clsData.ProcessDate, UI.usDefCons.DateFull)

                    ToolStripStatus.Visible = True
                    ToolStripDraftBy.Visible = True
                    ToolStripDraftDate.Visible = True
                    ToolStripProcessBy.Visible = True
                    ToolStripProcessDate.Visible = True
                    ToolStripStatus.BackColor = ToolStripProcessBy.BackColor

                ElseIf clsData.StatusStr = "COMPLETED" Then
                    ToolStripStatus.Text = "STATUS : " & clsData.StatusStr
                    ToolStripDraftBy.Text = "DRAFT BY : " & clsData.DraftBy
                    ToolStripDraftDate.Text = "DRAFT DATE : " & Format(clsData.DraftDate, UI.usDefCons.DateFull)
                    ToolStripProcessBy.Text = "PROCESS BY : " & clsData.ProcessBy
                    ToolStripProcessDate.Text = "PROCESS DATE : " & Format(clsData.ProcessDate, UI.usDefCons.DateFull)
                    ToolStripCompletedBy.Text = "COMPLETED BY : " & clsData.CompletedBy
                    ToolStripCompletedDate.Text = "COMPLETED DATE : " & Format(clsData.CompletedDate, UI.usDefCons.DateFull)

                    ToolStripStatus.Visible = True
                    ToolStripDraftBy.Visible = True
                    ToolStripDraftDate.Visible = True
                    ToolStripProcessBy.Visible = True
                    ToolStripProcessDate.Visible = True
                    ToolStripCompletedBy.Visible = True
                    ToolStripCompletedDate.Visible = True
                    ToolStripStatus.BackColor = ToolStripCompletedBy.BackColor

                End If
            Else
                dtpTanggalAkta.Value = Today
                dtpTglDidaftarkan.Value = Today
                cboJenisTransaksi.SelectedIndex = 0
                cboJenisAkta.SelectedIndex = 0
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

    Private Sub prvSetGrid3()
        grdItemView3.OptionsView.ColumnAutoWidth = False
        UI.usForm.SetGrid(grdItemView3, "Index", "Index", 70, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdItemView3, "JenisID", "Jenis ID", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemView3, "NoID", "No ID", 130, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemView3, "WargaNegara", "Warga Negara", 120, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemView3, "Negara", "Negara", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemView3, "Title", "Title", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdItemView3, "Nama", "Nama", 130, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemView3, "TempatLahir", "Tempat Lahir", 120, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemView3, "TglLahir", "Tanggal Lahir", 100, UI.usDefGrid.gSmallDate)
        UI.usForm.SetGrid(grdItemView3, "TglLahirStr", "TglLahirStr", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdItemView3, "Alamat", "Alamat", 150, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemView3, "Pekerjaan", "Pekerjaan", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemView3, "NoNPWP", "No NPWP", 130, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemView3, "NoTelp", "No Telepon", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemView3, "NoHP", "No HP", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdItemView3, "Remarks", "Keterangan", 150, UI.usDefGrid.gString)
    End Sub

    Public Sub pubRefresh()
        grdClient1.Refresh()
        grdClient2.Refresh()
        grdClient3.Refresh()
    End Sub

    Private Function ValidateData() As Boolean
        If Not bolNew And clsData.StatusStr = "COMPLETED" Then
            UI.usForm.frmMessageBox("Edit Data tidak bisa untuk Status COMPLETED")
            Return False
        End If

        If txtSifatAkta.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Sifat Akta harus diisi !")
            txtSifatAkta.Focus()
            Return False
        End If

        'If txtFileLocation.Text.Trim = "" Then
        '    UI.usForm.frmMessageBox("File Location harus diisi")
        '    txtFileLocation.Focus()
        '    Return False
        'End If

        If cboJenisTransaksi.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Jenis Transaksi harus diisi")
            cboJenisTransaksi.Focus()
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

        If DL.NotaryOrder.CheckValidNoUrut(txtNoUrut.Text, txtNotaryOrderID.Text) Then
            UI.usForm.frmMessageBox("No Urut tidak boleh duplikat")
            Return False
        End If

        If DL.NotaryOrder.CheckValidNoBulanan(dtpTanggalAkta.Value, txtNoBulanan.Text, txtNotaryOrderID.Text) Then
            UI.usForm.frmMessageBox("No Bulanan tidak boleh sama dalam satu bulan")
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

        'Jika New Generate Notary Order Baru
        If bolNew Then txtNotaryOrderID.Text = DL.NotaryOrder.NotaryOrderID(Today)

        'Simpan Header Notary Order di VO
        clsData.NotaryOrderID = txtNotaryOrderID.Text
        clsData.JenisAkta = cboJenisAkta.SelectedIndex
        clsData.NoUrut = txtNoUrut.Text
        clsData.NoBulanan = txtNoBulanan.Text
        clsData.TglAkta = dtpTanggalAkta.Value
        clsData.TglDidaftarkan = dtpTglDidaftarkan.Value
        clsData.SifatAkta = txtSifatAkta.Text
        clsData.JenisTransaksi = cboJenisTransaksi.Text
        txtFileLocation.Text = UI.usUserApp.FileLocation & txtNotaryOrderID.Text
        clsData.FileLocation = txtFileLocation.Text
        clsData.Remarks = txtRemarks.Text
        clsData.ProcessUserID = txtProcessUserID.Text
        clsData.ExpInterval = numExpInterval.Value

        'Simpan Client1 Notary Order di VO
        Dim dtData1 As DataTable = grdClient1.DataSource
        Dim clsDataClient1 As VO.NotaryClientDet1
        Dim clsDataAllClient1() As VO.NotaryClientDet1
        ReDim clsDataAllClient1(grdItemView.RowCount - 1)

        'ubah semua intPos
        Dim intPos1 As Integer = 0
        For Each drData1 As DataRow In dtData1.Rows
            clsDataClient1 = New VO.NotaryClientDet1
            clsDataClient1.NotaryOrderID = txtNotaryOrderID.Text
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

        'Simpan Client2 Notary Order di VO
        Dim dtData2 As DataTable = grdClient2.DataSource
        Dim clsDataClient2 As VO.NotaryClientDet2
        Dim clsDataAllClient2() As VO.NotaryClientDet2
        ReDim clsDataAllClient2(grdItemView2.RowCount - 1)

        Dim intPos2 As Integer = 0
        For Each drData2 As DataRow In dtData2.Rows
            clsDataClient2 = New VO.NotaryClientDet2
            clsDataClient2.NotaryOrderID = txtNotaryOrderID.Text
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

        'Simpan Client3 Notary Order di VO
        Dim dtData3 As DataTable = grdClient3.DataSource
        Dim clsDataClient3 As VO.NotaryClientDet3
        Dim clsDataAllClient3() As VO.NotaryClientDet3
        ReDim clsDataAllClient3(grdItemView3.RowCount - 1)

        Dim intPos3 As Integer = 0
        For Each drData3 As DataRow In dtData3.Rows
            clsDataClient3 = New VO.NotaryClientDet3
            clsDataClient3.NotaryOrderID = txtNotaryOrderID.Text
            clsDataClient3.Index = drData3.Item("Index")
            clsDataClient3.JenisID = drData3.Item("JenisID")
            clsDataClient3.NoID = drData3.Item("NoID")
            clsDataClient3.WargaNegara = drData3.Item("WargaNegara")
            clsDataClient3.Negara = drData3.Item("Negara")
            clsDataClient3.Title = drData3.Item("Title")
            clsDataClient3.Nama = drData3.Item("Nama")
            clsDataClient3.TempatLahir = drData3.Item("TempatLahir")
            clsDataClient3.TglLahir = drData3.Item("TglLahir")
            clsDataClient3.TglLahirStr = drData3.Item("TglLahirStr")
            clsDataClient3.Alamat = drData3.Item("Alamat")
            clsDataClient3.Pekerjaan = drData3.Item("Pekerjaan")
            clsDataClient3.NoNPWP = drData3.Item("NoNPWP")
            clsDataClient3.NoTelp = drData3.Item("NoTelp")
            clsDataClient3.NoHP = drData3.Item("NoHP")
            clsDataClient3.Remarks = drData3.Item("Remarks")
            clsDataAllClient3(intPos3) = clsDataClient3
            intPos3 += 1
        Next


        Try
            'Simpan semua Data Header dan Client Detail
            DL.NotaryOrder.SaveAllData(bolNew, txtNotaryOrderID.Text, clsData, clsDataAllClient1, clsDataAllClient2, clsDataAllClient3)
            bolSave = True
            If bolNew Then
                UI.usForm.frmMessageBox("Save Success ! Notary Order ID : " & txtNotaryOrderID.Text)
                'buat folder baru
                MkDir(txtFileLocation.Text)
                prvFileLocation()
                frmParent.pubRefresh(txtNotaryOrderID.Text)
                bolNew = False
            Else
                UI.usForm.frmMessageBox("Update Success ! Notary Order ID : " & txtNotaryOrderID.Text)
                If bolClient = False Then frmParent.pubRefresh(txtNotaryOrderID.Text)
                Me.Close()
            End If
        Catch ex As Exception
            bolSave = False
            UI.usForm.frmMessageBox(ex.Message)
        End Try
    End Sub

    Private Sub prvClient1New()
        Dim frmDetail As New frmTraNotaryOrderClient1
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
        Dim frmDetail As New frmTraNotaryOrderClient1
        With frmDetail
            .pubIsNew = False
            .pubNotaryOrderID = txtNotaryOrderID.Text
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
        Dim frmDetail As New frmTraNotaryOrderClient2
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
        Dim frmDetail As New frmTraNotaryOrderClient2
        With frmDetail
            .pubIsNew = False
            .pubNotaryOrderID = txtNotaryOrderID.Text
            .pubNoID = grdItemView2.GetDataRow(intPos2).Item("NoID")
            .pubShowDialog(Me)
        End With
        pubRefresh()
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

    Private Sub prvClient3New()
        Dim frmDetail As New frmTraNotaryOrderClient3
        If grdItemView3.RowCount = 0 Then
            intPosTemp = 0
        Else
            intPos3 = grdItemView3.RowCount - 1
            intPosTemp = grdItemView3.GetDataRow(intPos3).Item("Index")
        End If
        With frmDetail
            .pubIsNew = True
            .pubIndex = intPosTemp
            .pubShowDialog(Me)
        End With
    End Sub

    Private Sub prvClient3Detail()
        intPos3 = grdItemView3.FocusedRowHandle
        Dim frmDetail As New frmTraNotaryOrderClient3
        With frmDetail
            .pubIsNew = False
            .pubNotaryOrderID = txtNotaryOrderID.Text
            .pubNoID = grdItemView3.GetDataRow(intPos3).Item("NoID")
            .pubShowDialog(Me)
        End With
        pubRefresh()
    End Sub

    Private Sub prvClient3Delete()
        Dim dtTable As DataTable = grdClient3.DataSource
        intPos3 = grdItemView3.FocusedRowHandle
        Dim strNoID As String = grdItemView3.GetDataRow(intPos3).Item("NoID")
        Dim strNama As String = grdItemView3.GetDataRow(intPos3).Item("Nama")

        If UI.usForm.frmAskQuestion("Delete Pihak III No ID : " & strNoID & " Nama : " & strNama & " ?") Then
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
        '    .pubShowDialogNotary(Me)
        'End With

        'Dim OpenFileDialog1 As New OpenFileDialog
        'With OpenFileDialog1
        '    .Filter = "All Files (*.*)|*.*"
        '    .Multiselect = True
        '    .InitialDirectory = txtFileLocation.Text
        '    If Not OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.Cancel Then
        '        Using fileprocess As Process = Process.Start(OpenFileDialog1.FileName)
        '            fileprocess.WaitForExit()
        '        End Using
        '    End If
        'End With

        Dim OpenFileDialog1 As New OpenFileDialog
        With OpenFileDialog1
            .Filter = "All Files (*.*)|*.*"
            .Multiselect = True
            .InitialDirectory = txtFileLocation.Text
            If Not OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.Cancel Then
                'Using fileprocess As Process = Process.Start(OpenFileDialog1.FileName)
                '    fileprocess.WaitForExit()
                'End Using

                Dim FileInfo As New ProcessStartInfo
                FileInfo.FileName = OpenFileDialog1.FileName
                Process.Start(FileInfo)
            End If
        End With
    End Sub

    Private Sub prvPrint()
        If txtNotaryOrderID.Text = "" Then
            UI.usForm.frmMessageBox("Notary Order ID tidak boleh kosong")
            Exit Sub
        End If

        'If cboJenisTransaksi.Text = "AKTA JAMINAN FIDUSIA" Then
        '    Dim frmDetail As New frmTraNotaryOrderPrint
        '    With frmDetail
        '        .pubNotaryOrderID = txtNotaryOrderID.Text
        '        .pubPath = txtFileLocation.Text
        '        .pubShowDialog(Me)
        '    End With
        'Else

        Dim frmDetail As New frmTraNotaryOrderPrintBlank
        With frmDetail
            .pubNotaryOrderID = txtNotaryOrderID.Text
            .pubPath = txtFileLocation.Text
            .pubShowDialog(Me)
        End With

        'End If

    End Sub

#End Region

#Region "Form Handle"

    Private Sub Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        prvSetIcon()
        prvSetGrid()
        prvSetGrid2()
        prvSetGrid3()
        prvFillForm()
        pubRefresh()
        prvSetButton()
    End Sub

    Private Sub ToolBar_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles ToolBar.ButtonClick
        If e.Button.Text = "Save" Then
            prvSave()
            'ElseIf e.Button.Text = "Print Akta" Then
            '    prvPrint()
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

    Private Sub ToolBarDetail3_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles ToolBarDetail3.ButtonClick
        If e.Button.Text = "New" Then
            prvClient3New()
        ElseIf grdItemView3.FocusedRowHandle >= 0 Then
            Select Case e.Button.Text
                Case "Detail" : prvClient3Detail()
                Case "Delete" : prvClient3Delete()
            End Select
        End If
    End Sub

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
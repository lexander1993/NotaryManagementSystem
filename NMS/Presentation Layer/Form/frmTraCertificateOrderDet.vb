Imports DevExpress.XtraGrid.Views.Grid
Public Class frmTraCertificateOrderDet

#Region "Property"

    Private frmParent As frmTraCertificateOrder
    Private frmParentClient As frmMstClientDet
    Private frmParentNotification As frmSysNotification
    Private bolNew, bolSave, bolClient As Boolean
    Private strCertificateOrderID As String = ""

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

    Public Property pubCertificateOrderID() As String
        Get
            Return strCertificateOrderID
        End Get
        Set(ByVal Value As String)
            strCertificateOrderID = Value
        End Set
    End Property

#End Region

#Region "Function"

    Private Const _
       cSave = 0, cExit = 1

    Private clsData As New VO.CertificateOrder
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
        UI.usForm.SetToolBar(Me, ToolBarDetail, "0,New,1,Delete")
    End Sub

    Private Sub prvSetButton()
        Dim bolEdit As Boolean
        bolEdit = DL.MasterUser.IsAccess("CERTIFICATE ORDER EDIT")

        With ToolBar.Buttons
            .Item(0).Enabled = bolEdit
        End With
    End Sub

    Private Sub prvSetTitleForm()
        If bolNew Then
            Me.Text += " [new] "
        Else
            Me.Text += " [edit] " & strCertificateOrderID
        End If
    End Sub

    Private Sub prvFillForm()
        'clsData utk menampung entity PPATOrder
        'grdClient1.DataSource Harus diset agar tidak error wkt Fill Data Grid
        Try
            clsData = DL.CertificateOrder.GetDetail(strCertificateOrderID)
            grdClient1.DataSource = DL.CertificateOrder.ListDetail(strCertificateOrderID)

            grdItemView.Columns.Item("Index").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending

            If Not bolNew Then
                txtCertificateOrderID.Text = strCertificateOrderID
                txtJenisNoHak.Text = clsData.JenisNoHak
                txtFileLocation.Text = clsData.FileLocation
                txtRemarks.Text = clsData.Remarks
                dtpTglPenyerahanDokumen.Value = clsData.TglPenyerahanDokumen
                dtpTglPengembalianDokumen.Value = clsData.TglPengembalianDokumen
                txtLetakTanah.Text = clsData.LetakTanahBangunan
                numLuasTanah.Value = clsData.LuasTanahM2
                numLuasBangunan.Value = clsData.LuasBangunanM2
                numHargaTransaksi.Value = clsData.HargaTransaksi
            Else
                dtpTglPenyerahanDokumen.Value = Today
                dtpTglPengembalianDokumen.Value = Today.AddYears(-10)
            End If
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try
    End Sub

    Private Sub prvSetGrid()
        grdItemView.OptionsView.ColumnAutoWidth = False
        UI.usForm.SetGrid(grdItemView, "Index", "Index", 70, UI.usDefGrid.gIntNum, False, False)
        UI.usForm.SetGrid(grdItemView, "JenisTransaksi", "Jenis Transaksi", 150, UI.usDefGrid.gString, True, False)
        UI.usForm.SetGrid(grdItemView, "ProcessBy", "Process By", 100, UI.usDefGrid.gString, True, False)
        UI.usForm.SetGrid(grdItemView, "ProcessDate", "Process Date", 100, UI.usDefGrid.gSmallDate, True, False)
        UI.usForm.SetGrid(grdItemView, "ProcessRemarks", "Process Remarks", 200, UI.usDefGrid.gString, True, False)
        UI.usForm.SetGrid(grdItemView, "BPNFinishBy", "BPN Finish By", 100, UI.usDefGrid.gString, True, False)
        UI.usForm.SetGrid(grdItemView, "BPNFinishDate", "BPN Finish Date", 100, UI.usDefGrid.gSmallDate, True, False)
        UI.usForm.SetGrid(grdItemView, "BPNFinishRemarks", "BPN Finish Remarks", 200, UI.usDefGrid.gString, True, False)

        Dim cb1 As New DevExpress.XtraEditors.Repository.RepositoryItemComboBox
        Dim cb2 As New DevExpress.XtraEditors.Repository.RepositoryItemComboBox
        Dim cb3 As New DevExpress.XtraEditors.Repository.RepositoryItemComboBox
        Dim dtp1 As New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
        Dim dtp2 As New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
        Dim txt1 As New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
        Dim txt2 As New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
        cb1.CharacterCasing = CharacterCasing.Upper
        cb2.CharacterCasing = CharacterCasing.Upper
        cb3.CharacterCasing = CharacterCasing.Upper
        dtp1.EditMask = "dd/MM/yyyy"
        dtp2.EditMask = "dd/MM/yyyy"
        txt1.CharacterCasing = CharacterCasing.Upper
        txt2.CharacterCasing = CharacterCasing.Upper

        grdItemView.Columns.Item("JenisTransaksi").ColumnEdit = cb1
        cb1.Items.Add("CEK BERSIH")
        cb1.Items.Add("ROYA")
        cb1.Items.Add("BALIK NAMA")
        cb1.Items.Add("GANTI BLANKO")
        cb1.Items.Add("MOHON HAK")
        cb1.Items.Add("PENINGKATAN HAK")
        cb1.Items.Add("PEMASANGAN HAK TANGGUNGAN")

        Dim dt As DataTable = DL.MasterUser.ListData(2)
        grdItemView.Columns.Item("ProcessBy").ColumnEdit = cb2
        grdItemView.Columns.Item("BPNFinishBy").ColumnEdit = cb3

        Dim intPos As Integer = 0
        For Each drData As DataRow In dt.Rows
            cb2.Items.Add(drData.Item("UserID"))
            cb3.Items.Add(drData.Item("UserID"))
            intPos += 1
        Next

        grdItemView.Columns.Item("ProcessDate").ColumnEdit = dtp1
        grdItemView.Columns.Item("BPNFinishDate").ColumnEdit = dtp2
        grdItemView.Columns.Item("ProcessRemarks").ColumnEdit = txt1
        grdItemView.Columns.Item("BPNFinishRemarks").ColumnEdit = txt2

    End Sub

    Public Sub pubRefresh()
        grdClient1.Refresh()
    End Sub

    Private Sub prvSave()
        txtCertificateOrderID.Focus()

        If bolNew Then txtCertificateOrderID.Text = DL.CertificateOrder.CertificateOrderID(Today)

        'Simpan Header PPAT Order di VO
        clsData.CertificateOrderID = txtCertificateOrderID.Text
        clsData.TglPenyerahanDokumen = dtpTglPenyerahanDokumen.Value
        clsData.TglPengembalianDokumen = dtpTglPengembalianDokumen.Value
        clsData.JenisNoHak = txtJenisNoHak.Text
        txtFileLocation.Text = UI.usUserApp.FileLocation & txtCertificateOrderID.Text
        clsData.FileLocation = txtFileLocation.Text
        clsData.Remarks = txtRemarks.Text

        clsData.LetakTanahBangunan = txtLetakTanah.Text
        clsData.LuasTanahM2 = numLuasTanah.Value
        clsData.LuasBangunanM2 = numLuasBangunan.Value
        clsData.HargaTransaksi = numHargaTransaksi.Value

        Dim dtData1 As DataTable = grdClient1.DataSource
        Dim clsDataClient1 As VO.CertificateOrderDet
        Dim clsDataAllClient1() As VO.CertificateOrderDet
        ReDim clsDataAllClient1(grdItemView.RowCount - 1)

        Dim intPos1 As Integer = 0
        For Each drData1 As DataRow In dtData1.Rows
            clsDataClient1 = New VO.CertificateOrderDet
            clsDataClient1.CertificateOrderID = txtCertificateOrderID.Text

            clsDataClient1.Index = drData1.Item("Index")

            If drData1.Item("JenisTransaksi") IsNot System.DBNull.Value Then
                clsDataClient1.JenisTransaksi = drData1.Item("JenisTransaksi")
            Else
                clsDataClient1.JenisTransaksi = ""
            End If

            If drData1.Item("ProcessBy") IsNot System.DBNull.Value Then
                clsDataClient1.ProcessBy = drData1.Item("ProcessBy")
            Else
                clsDataClient1.ProcessBy = ""
            End If

            If drData1.Item("ProcessDate") IsNot System.DBNull.Value Then
                clsDataClient1.ProcessDate = drData1.Item("ProcessDate")
            Else
                clsDataClient1.ProcessDate = Today.AddYears(100)
            End If

            If drData1.Item("ProcessRemarks") IsNot System.DBNull.Value Then
                clsDataClient1.ProcessRemarks = drData1.Item("ProcessRemarks")
            Else
                clsDataClient1.ProcessRemarks = ""
            End If

            If drData1.Item("BPNFinishBy") IsNot System.DBNull.Value Then
                clsDataClient1.BPNFinishBy = drData1.Item("BPNFinishBy")
            Else
                clsDataClient1.BPNFinishBy = ""
            End If

            If drData1.Item("BPNFinishDate") IsNot System.DBNull.Value Then
                clsDataClient1.BPNFinishDate = drData1.Item("BPNFinishDate")
            Else
                clsDataClient1.BPNFinishDate = Today.AddYears(100)
            End If

            If drData1.Item("BPNFinishRemarks") IsNot System.DBNull.Value Then
                clsDataClient1.BPNFinishRemarks = drData1.Item("BPNFinishRemarks")
            Else
                clsDataClient1.BPNFinishRemarks = ""
            End If

            clsDataAllClient1(intPos1) = clsDataClient1
            intPos1 += 1
        Next

        Try
            DL.CertificateOrder.SaveAllData(bolNew, txtCertificateOrderID.Text, clsData, clsDataAllClient1)
            bolSave = True
            If bolNew Then
                UI.usForm.frmMessageBox("Save Success ! Certificate Order ID : " & txtCertificateOrderID.Text)
                MkDir(txtFileLocation.Text)
                prvFileLocation()
                frmParent.pubRefresh(txtCertificateOrderID.Text)
                bolNew = False
            Else
                UI.usForm.frmMessageBox("Update Success ! Certificate Order ID : " & txtCertificateOrderID.Text)
                If bolClient = False Then frmParent.pubRefresh(txtCertificateOrderID.Text)
                Me.Close()
            End If
        Catch ex As Exception
            bolSave = False
            UI.usForm.frmMessageBox(ex.Message)
        End Try
    End Sub

    Private Sub prvClient1New()
        If grdItemView.RowCount = 0 Then
            intPosTemp = 1
        Else
            intPos1 = grdItemView.RowCount - 1
            intPosTemp = grdItemView.GetDataRow(intPos1).Item("Index") + 1
        End If

        Dim dtTable As DataTable
        Dim dtRow As DataRow
        dtTable = grdClient1.DataSource
        dtRow = dtTable.NewRow
        dtRow.BeginEdit()
        dtRow.Item("Index") = intPosTemp
        dtRow.EndEdit()

        dtTable.Rows.Add(dtRow)
        dtTable.AcceptChanges()
        grdClient1.DataSource = dtTable
        pubRefresh()
    End Sub

    Private Sub prvClient1Delete()
        txtCertificateOrderID.Focus()
        Dim dtTable As DataTable = grdClient1.DataSource
        intPos1 = grdItemView.FocusedRowHandle
        Dim strJenisTransaksi As String = IIf(grdItemView.GetDataRow(intPos1).Item("JenisTransaksi") Is System.DBNull.Value, "-", grdItemView.GetDataRow(intPos1).Item("JenisTransaksi"))
        Dim intIndex As Integer = grdItemView.GetDataRow(intPos1).Item("Index")

        If UI.usForm.frmAskQuestion("Delete Jenis Transaksi : " & strJenisTransaksi & " ?") Then
            For Each drdata As DataRow In dtTable.Rows
                If drdata.Item("Index") = intIndex Then
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
        prvSetButton()
        prvSetGrid()
        prvFillForm()
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
                Case "Delete" : prvClient1Delete()
            End Select
        End If
    End Sub

    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown, tbcPPAT.KeyDown
        If e.KeyCode = Keys.Escape Then
            If UI.usForm.frmAskQuestion("Close Certificate Order ?") Then Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Me.tbcPPAT.SelectedIndex = 0
        ElseIf e.KeyCode = Keys.F2 Then
            Me.tbcPPAT.SelectedIndex = 1
        End If
    End Sub

    Private Sub btnFileLocation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFileLocation.Click
        prvFileLocation()
    End Sub

#End Region


End Class
Public Class frmTraCertificateOrder

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
        cNew = 0, cDetail = 1, cDelete = 2, cRefresh = 4

    Private intPos As Integer

    Private Sub prvSetIcon()
        UI.usForm.SetToolBar(Me, ToolBar, "0,New,1,Detail,2,Delete,4,Refresh")
    End Sub

    Private Sub prvSetButton()
        Dim bolEdit, bolView As Boolean
        bolEdit = DL.MasterUser.IsAccess("CERTIFICATE ORDER EDIT")
        bolView = DL.MasterUser.IsAccess("CERTIFICATE ORDER VIEW")

        With ToolBar.Buttons
            .Item(cNew).Enabled = bolEdit
            .Item(cDetail).Enabled = IIf(bolEdit, bolEdit, bolView)
            .Item(cDelete).Enabled = bolEdit
        End With
    End Sub

    Private Sub prvSetGrid()
        UI.usForm.SetGrid(grdView, "CertificateOrderID", "Certificate Order ID", 120, UI.usDefGrid.gString, True, True, True)
        UI.usForm.SetGrid(grdView, "TglPenyerahanDokumen", "Tgl Penyerahan Dokumen", 150, UI.usDefGrid.gSmallDate, True, True, True)
        UI.usForm.SetGrid(grdView, "JenisNoHak", "Jenis dan No Hak", 120, UI.usDefGrid.gString, True, True, True)
        UI.usForm.SetGrid(grdView, "Remarks", "Remarks", 120, UI.usDefGrid.gString, True, True, True)
        UI.usForm.SetGrid(grdView, "FileLocation", "Scan Data", 70, UI.usDefGrid.gString, True, True, True)

        UI.usForm.SetGrid(grdView, "Index", "Index", 70, UI.usDefGrid.gIntNum, False)
        UI.usForm.SetGrid(grdView, "JenisTransaksi", "Jenis Transaksi", 150, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "ProcessBy", "ProcessBy", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "ProcessDate", "Process Date", 100, UI.usDefGrid.gSmallDate)
        UI.usForm.SetGrid(grdView, "ProcessRemarks", "Process Remarks", 150, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "BPNFinishBy", "BPNFinishBy", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "BPNFinishDate", "BPN Finish Date", 100, UI.usDefGrid.gSmallDate)
        UI.usForm.SetGrid(grdView, "BPNFinishRemarks", "BPN Finish Remarks", 150, UI.usDefGrid.gString)


        'Filter Contains
        grdView.Columns.Item("CertificateOrderID").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdView.Columns.Item("TglPenyerahanDokumen").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdView.Columns.Item("JenisNoHak").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdView.Columns.Item("JenisTransaksi").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdView.Columns.Item("Remarks").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains

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
        Dim frmDetail As New frmTraCertificateOrderDet
        With frmDetail
            .pubIsNew = True
            .pubShowDialog(Me)
        End With
    End Sub

    Private Sub prvDetail()
        intPos = grdView.FocusedRowHandle
        Dim frmDetail As New frmTraCertificateOrderDet
        With frmDetail
            .pubIsNew = False
            .pubCertificateOrderID = grdView.GetDataRow(intPos).Item("CertificateOrderID")
            .pubShowDialog(Me)
            If .pubIsSave Then pubRefresh()
        End With
    End Sub

    Private Sub prvDelete()
        intPos = grdView.FocusedRowHandle

        Dim strCertificateOrderID As String = grdView.GetDataRow(intPos).Item("CertificateOrderID")
        Try
            If Not UI.usForm.frmAskQuestion("Hapus Certificate Order ID " & strCertificateOrderID & " ?") Then Exit Sub
            DL.CertificateOrder.DeleteDetail(strCertificateOrderID)
            DL.CertificateOrder.DeleteHeader(strCertificateOrderID)
            Try
                RmDir(UI.usUserApp.FileLocation & strCertificateOrderID)
            Catch ex As Exception
                Kill(UI.usUserApp.FileLocation & strCertificateOrderID & "\*.*")
                RmDir(UI.usUserApp.FileLocation & strCertificateOrderID)
            End Try
            UI.usForm.frmMessageBox(strCertificateOrderID & " berhasil dihapus ! ")
            pubRefresh()
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try

    End Sub

    Private Sub prvQuery()
        If dtpDateFrom.Value > dtpDateTo.Value Then
            UI.usForm.frmMessageBox("Period Wrong")
            dtpDateFrom.Focus()
            Exit Sub
        End If

        Dim dtData As DataTable = DL.CertificateOrder.ListData(dtpDateFrom.Value, dtpDateTo.Value)
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
                strSearch = grdView.GetDataRow(grdView.FocusedRowHandle).Item("CertificateOrderID")
            End If
            prvQuery()
            If grdView.RowCount > 0 Then UI.usForm.GridMoveRow(grdView, "CertificateOrderID", strSearch)
        End With
    End Sub

#End Region

#Region "Form Handle"

    Private Sub Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtpDateFrom.Value = Today.Year & "/" & Today.Month & "/" & "01 23:59:59"
        dtpDateTo.Value = dtpDateFrom.Value.AddMonths(1).AddDays(-1)
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
            End Select
        End If
    End Sub

    Private Sub btnExecute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExecute.Click
        prvQuery()
    End Sub

    Private Sub grdMain_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdMain.DoubleClick
        prvDetail()
    End Sub

#End Region

End Class
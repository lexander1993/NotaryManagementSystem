Public Class frmTraPaymentIn

#Region "Look Up"

    Private bolLookUp As Boolean = False
    Private bolLookUpGet As Boolean = False
    Private intLUPaymentInID As Integer
    Private strLUNoAkta As String
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

    Public Property pubLUNoAkta() As String
        Get
            Return strLUNoAkta
        End Get
        Set(ByVal Value As String)
            strLUNoAkta = Value
        End Set
    End Property

    Public Property pubLUPaymentInID() As String
        Get
            Return intLUPaymentInID
        End Get
        Set(ByVal Value As String)
            intLUPaymentInID = Value
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
        bolEdit = DL.MasterUser.IsAccess("PAYMENT IN EDIT")
        bolView = DL.MasterUser.IsAccess("PAYMENT IN VIEW")

        With ToolBar.Buttons
            .Item(cNew).Enabled = bolEdit
            .Item(cDetail).Enabled = IIf(bolEdit, bolEdit, bolView)
            .Item(cDelete).Enabled = bolEdit
        End With
    End Sub

    Private Sub prvSetGrid()
        UI.usForm.SetGrid(grdView, "PInID", "Payment In ID", 100, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdView, "NoAkta", "No Akta", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "NamaClient", "Nama Client", 200, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "PDate", "Tanggal Kwitansi", 100, UI.usDefGrid.gSmallDate)
        UI.usForm.SetGrid(grdView, "B", "Biaya", 150, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdView, "Status", "Status", 80, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "Remarks", "Remarks", 200, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "IsOther", "IsOther", 100, UI.usDefGrid.gBoolean)
     
        UI.usForm.SetGrid(grdView, "CreatedBy", "Created By", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "CreatedDate", "Created Date", 130, UI.usDefGrid.gFullDate)
        UI.usForm.SetGrid(grdView, "ModifiedBy", "Modified By", 120, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "ModifiedDate", "Modified Date", 130, UI.usDefGrid.gFullDate)
        UI.usForm.SetGrid(grdView, "POutID", "Payment Out ID", 100, UI.usDefGrid.gIntNum, False)

    End Sub

    Private Sub prvSetLookUp()
        If bolLookUp Then
            UI.usForm.GridMoveRow(grdView, "PaymentInID", intLUPaymentInID)
        End If
    End Sub

    Private Sub prvGet()
        intPos = grdView.FocusedRowHandle
        If bolLookUp And intPos >= 0 Then
            intLUPaymentInID = grdView.GetDataRow(intPos).Item("PInID")
            strLUNoAkta = grdView.GetDataRow(intPos).Item("NoAkta")
            dtrLUDataRow = grdView.GetDataRow(grdView.FocusedRowHandle)
            bolLookUpGet = True
            Me.Close()
        End If
    End Sub

    Private Sub prvNew()
        Dim frmDetail As New frmTraPaymentInDet
        With frmDetail
            .pubIsNew = True
            .pubShowDialog(Me)
        End With
    End Sub

    Private Sub prvDetail()
        intPos = grdView.FocusedRowHandle
        Dim frmDetail As New frmTraPaymentInDet
        With frmDetail
            .pubIsNew = False
            .pubPaymentInID = grdView.GetDataRow(intPos).Item("PInID")
            .pubShowDialog(Me)
            If .pubIsSave Then pubRefresh()
        End With
    End Sub

    Private Sub prvDelete()
        intPos = grdView.FocusedRowHandle
        Dim intPaymentInID As Integer = grdView.GetDataRow(intPos).Item("PInID")
        Try
            If DL.PaymentIn.CheckPOutUse(intPaymentInID) = True Then
                UI.usForm.frmMessageBox("Payment In ID :" & intPaymentInID & " sudah dipakai dalam Payment Out ! ")
                Exit Sub
            End If
            If Not UI.usForm.frmAskQuestion("Hapus Payment In ID : " & intPaymentInID & " ?") Then Exit Sub
            DL.PaymentIn.DeleteHeader(intPaymentInID)
            UI.usForm.frmMessageBox("Payment In ID :" & intPaymentInID & " berhasil dihapus ! ")
            pubRefresh()
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try
    End Sub

    Private Sub prvQuery()
        Try
            grdMain.DataSource = DL.PaymentIn.ListData(dtpDateFrom.Value, dtpDateTo.Value)
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try
        'prvSetButton()
    End Sub

    Public Sub pubRefresh(Optional ByVal strSearch As String = "")
        With grdView
            If Not grdView.FocusedValue Is Nothing And strSearch = "" Then
                strSearch = grdView.GetDataRow(grdView.FocusedRowHandle).Item("NoAkta")
            End If
            prvQuery()
            If grdView.RowCount > 0 Then UI.usForm.GridMoveRow(grdView, "NoAkta", strSearch)
        End With
    End Sub

#End Region

#Region "Form Handle"

    Private Sub Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtpDateFrom.Value = Today.Year & "/" & Today.Month & "/" & "01 23:59:59"
        dtpDateTo.Value = dtpDateFrom.Value.AddMonths(1).AddDays(-1)
        prvSetIcon()
        prvSetGrid()
        prvQuery()
        prvSetButton()
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
        If bolLookUp = True Then
            Me.prvGet()
        Else
            prvDetail()
        End If
    End Sub

    Private Sub grdView_RowStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles grdView.RowStyle
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
        If (e.RowHandle >= 0) Then
            If (View.GetRowCellDisplayText(e.RowHandle, View.Columns("POutID")) <> "") Then
                e.Appearance.BackColor = Color.LightYellow
            End If
            Dim bolOth As Boolean = IIf(View.GetRowCellDisplayText(e.RowHandle, View.Columns("IsOther")) = "Unchecked", False, True)
            If bolOth = True Then
                e.Appearance.BackColor = Color.LightYellow
            End If
        End If
    End Sub

#End Region

End Class
Public Class frmSysNotification

#Region "Look Up"

    Private strLUNoID As String
    Private dtrLUDataRow As DataRow

    Public Property pubLUNoID() As String
        Get
            Return strLUNoID
        End Get
        Set(ByVal Value As String)
            strLUNoID = Value
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
        cDetail = 0, cRefresh = 1

    Private intPos As Integer

    Private Sub prvSetIcon()
        UI.usForm.SetToolBar(Me, ToolBar, "0,Get,1,Refresh")
    End Sub

    Private Sub prvSetGrid()
        UI.usForm.SetGrid(grdView, "OrderID", "Order ID", 120, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "TglAkta", "Tanggal Akta", 100, UI.usDefGrid.gSmallDate)
        UI.usForm.SetGrid(grdView, "NoUrut", "No. Urut / No. Akta", 120, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "JenisTransaksi", "Jenis Transaksi", 150, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "Status", "Status", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "ExpiredStatus", "Expired Status", 120, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "DraftBy", "Draft By", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "DraftDate", "Draft Date", 150, UI.usDefGrid.gFullDate)
        UI.usForm.SetGrid(grdView, "ProcessBy", "Process By", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "ProcessDate", "Process Date", 150, UI.usDefGrid.gFullDate)
        UI.usForm.SetGrid(grdView, "CompletedBy", "Completed By", 140, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "CompletedDate", "Completed Date", 150, UI.usDefGrid.gFullDate)

        grdView.Columns.Item("ExpiredStatus").SortOrder = DevExpress.Data.ColumnSortOrder.Descending
    End Sub

    Private Sub grdView_RowStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles grdView.RowStyle
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
        If (e.RowHandle >= 0) Then
            Dim strExpiredStatus As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("ExpiredStatus"))
            If strExpiredStatus = "EXPIRED" Then
                e.Appearance.BackColor = Color.Salmon
                e.Appearance.BackColor2 = Color.WhiteSmoke
            Else
                e.Appearance.BackColor = Color.Yellow
                e.Appearance.BackColor2 = Color.WhiteSmoke
            End If
        End If
    End Sub

    Private Sub prvDetail()
        intPos = grdView.FocusedRowHandle

        Dim OrderID As String = grdView.GetDataRow(intPos).Item("OrderID")
        If OrderID.Substring(0, 2) = "NT" Then
            Dim frmDetail As New frmTraNotaryOrderDet
            With frmDetail
                .pubIsNew = False
                .pubNotaryOrderID = OrderID
                .pubIsClient = True
                .pubShowDialogNotification(Me)
                If .pubIsSave Then pubRefresh()
            End With
        ElseIf OrderID.Substring(0, 2) = "PT" Then
            Dim frmDetail As New frmTraPPATOrderDet
            With frmDetail
                .pubIsNew = False
                .pubPPATOrderID = OrderID
                .pubIsClient = True
                .pubShowDialogNotification(Me)
                If .pubIsSave Then pubRefresh()
            End With
        End If
    End Sub

    Private Sub prvQuery()
        Try
            grdMain.DataSource = DL.MasterClient.ListNotification()
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try

        Dim Record As Integer = DL.MasterClient.NotificationRecord

        frmMain.lblNotification.Text = "NOTIFICATION : " & Record
    End Sub

    Public Sub pubRefresh(Optional ByVal strSearch As String = "")
        With grdView
            If Not grdView.FocusedValue Is Nothing And strSearch = "" Then
                strSearch = grdView.GetDataRow(grdView.FocusedRowHandle).Item("OrderID")
            End If
            prvQuery()
            If grdView.RowCount > 0 Then UI.usForm.GridMoveRow(grdView, "OrderID", strSearch)
        End With
    End Sub

#End Region

#Region "Form Handle"

    Private Sub Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        prvSetIcon()
        prvSetGrid()
        prvQuery()
    End Sub

    Private Sub ToolBar_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles ToolBar.ButtonClick
        If e.Button.Text = "Refresh" Then
            pubRefresh()
        ElseIf grdView.FocusedRowHandle >= 0 Then
            Select Case e.Button.Text
                Case "Get" : prvDetail()
            End Select
        End If
    End Sub

    Private Sub grdMain_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdMain.DoubleClick
        prvDetail()
    End Sub
    
#End Region

  
End Class
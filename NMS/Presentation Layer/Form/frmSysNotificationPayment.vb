Public Class frmSysNotificationPayment

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
        UI.usForm.SetGrid(grdView, "PaymentType", "Type", 70, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "PInID", "Payment ID", 100, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdView, "NoAkta", "No. Akta", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "NamaClient", "Nama Client", 150, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "PDate", "Payment Date", 100, UI.usDefGrid.gSmallDate)
        UI.usForm.SetGrid(grdView, "B", "Biaya", 100, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdView, "ExpDays", "Expired Days", 100, UI.usDefGrid.gIntNum)

        grdView.Columns.Item("PaymentType").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
    End Sub

    Private Sub grdView_RowStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles grdView.RowStyle
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
        If (e.RowHandle >= 0) Then
            Dim intExpDays As Integer = View.GetRowCellDisplayText(e.RowHandle, View.Columns("ExpDays"))
            If intExpDays <= 14 Then
                e.Appearance.BackColor = Color.Yellow
                e.Appearance.BackColor2 = Color.WhiteSmoke
            Else
                e.Appearance.BackColor = Color.Salmon
                e.Appearance.BackColor2 = Color.WhiteSmoke
            End If
        End If
    End Sub

    Private Sub prvDetail()
        intPos = grdView.FocusedRowHandle

        Dim PaymentID As String = grdView.GetDataRow(intPos).Item("PInID")
        Dim Type As String = grdView.GetDataRow(intPos).Item("PaymentType")
        If Type = "IN" Then
            Dim frmDetail As New frmTraPaymentInDet
            With frmDetail
                .pubIsNew = False
                .pubPaymentInID = PaymentID
                .pubShowDialogNotification(Me)
                If .pubIsSave Then pubRefresh()
            End With
        ElseIf Type = "OUT" Then
            Dim frmDetail As New frmTraPaymentOutDet
            With frmDetail
                .pubIsNew = False
                .pubPaymentOutID = PaymentID
                .pubShowDialogNotification(Me)
                If .pubIsSave Then pubRefresh()
            End With
        End If
    End Sub

    Private Sub prvQuery()
        Try
            grdMain.DataSource = DL.PaymentIn.ListNotification()
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try

    End Sub

    Public Sub pubRefresh(Optional ByVal strSearch As String = "")
        With grdView
            If Not grdView.FocusedValue Is Nothing And strSearch = "" Then
                strSearch = grdView.GetDataRow(grdView.FocusedRowHandle).Item("PInID")
            End If
            prvQuery()
            If grdView.RowCount > 0 Then UI.usForm.GridMoveRow(grdView, "PInID", strSearch)
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
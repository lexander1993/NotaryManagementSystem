Public Class frmMstClientDet

#Region "Look Up"

    Private frmParent As frmMstClient
    Private bolLookUp As Boolean = False
    Private bolLookUpGet As Boolean = False
    Private strLUNoID As String
    Private strLUNama As String
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

    Public Property pubLUNoID() As String
        Get
            Return strLUNoID
        End Get
        Set(ByVal Value As String)
            strLUNoID = Value
        End Set
    End Property

    Public Property pubLUNama() As String
        Get
            Return strLUNama
        End Get
        Set(ByVal Value As String)
            strLUNama = Value
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
    
        grdView.Columns.Item("TglAkta").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
    End Sub

    Private Sub prvSetLookUp()
        If bolLookUp Then
            UI.usForm.GridMoveRow(grdView, "NoID", strLUNoID)
        End If
    End Sub

    Private Sub prvSetTitleForm()
        Me.Text += " [" & pubLUNama & "]"
    End Sub

    Public Sub pubShowDialog(ByVal frmGetParent As Form)
        frmParent = frmGetParent
        Me.ShowDialog()
    End Sub

    Private Sub prvGet()
        intPos = grdView.FocusedRowHandle
        If bolLookUp And intPos >= 0 Then
            strLUNoID = grdView.GetDataRow(intPos).Item("NoID")
            dtrLUDataRow = grdView.GetDataRow(grdView.FocusedRowHandle)
            bolLookUpGet = True
            Me.Close()
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
                .pubShowDialogClient(Me)
                If .pubIsSave Then pubRefresh()
            End With
        ElseIf OrderID.Substring(0, 2) = "PT" Then
            Dim frmDetail As New frmTraPPATOrderDet
            With frmDetail
                .pubIsNew = False
                .pubPPATOrderID = OrderID
                .pubIsClient = True
                .pubShowDialogClient(Me)
                If .pubIsSave Then pubRefresh()
            End With
        End If
    End Sub

    Private Sub prvQuery()
        Try
            grdMain.DataSource = DL.MasterClient.ListDataDetail(pubLUNoID)
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try
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
        prvSetTitleForm()
        prvQuery()
    End Sub

    Private Sub ToolBar_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles ToolBar.ButtonClick
        If e.Button.Text = "Refresh" Then
            pubRefresh()
        ElseIf grdView.FocusedRowHandle >= 0 Then
            Select Case e.Button.Text
                Case "Detail" : prvDetail()
            End Select
        End If
    End Sub

    Private Sub grdMain_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdMain.DoubleClick
        If bolLookUp = True Then
            Me.prvGet()
        Else
            prvDetail()
        End If
    End Sub

   
#End Region


End Class
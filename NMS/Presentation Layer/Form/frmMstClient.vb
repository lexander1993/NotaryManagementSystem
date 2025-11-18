Public Class frmMstClient

#Region "Look Up"

    Private bolLookUp As Boolean = False
    Private bolLookUpGet As Boolean = False
    Private strLUNoID As String
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
        UI.usForm.SetToolBar(Me, ToolBar, "0,List,1,Refresh")
    End Sub

    Private Sub prvSetGrid()
        UI.usForm.SetGrid(grdView, "JenisID", "Jenis ID", 60, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "NoID", "No ID", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "Nama", "Nama", 150, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "WargaNegara", "Warga Negara", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "Negara", "Negara", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdView, "TempatLahir", "Tempat Lahir", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdView, "TglLahir", "Tgl Lahir", 100, UI.usDefGrid.gSmallDate, False)
        UI.usForm.SetGrid(grdView, "Pekerjaan", "Pekerjaan", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdView, "Alamat", "Alamat", 150, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "NoHP", "No HP", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "JumlahOrder", "Jumlah Order", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "Title", "Title", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdView, "TglLahirStr", "TglLahirStr", 100, UI.usDefGrid.gString, False)

        grdView.Columns.Item("Nama").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
    End Sub

    Private Sub prvSetLookUp()
        If bolLookUp Then
            UI.usForm.GridMoveRow(grdView, "NoID", strLUNoID)
        End If
    End Sub

    Private Sub prvSetButton()
        Dim bolView As Boolean
        bolView = DL.MasterUser.IsAccess("MASTER CLIENT VIEW HISTORY")

        With ToolBar.Buttons
            .Item(cDetail).Enabled = bolView
        End With
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
        Dim frmDetail As New frmMstClientDet
        With frmDetail
            .pubLUNoID = grdView.GetDataRow(intPos).Item("NoID")
            .pubLUNama = grdView.GetDataRow(intPos).Item("Nama")
            .pubShowDialog(Me)
        End With
    End Sub

    Private Sub prvQuery()
        Try
            grdMain.DataSource = DL.MasterClient.ListData(txtNoID.Text, txtNama.Text)
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try
    End Sub

    Public Sub pubRefresh(Optional ByVal strSearch As String = "")
        With grdView
            If Not grdView.FocusedValue Is Nothing And strSearch = "" Then
                strSearch = grdView.GetDataRow(grdView.FocusedRowHandle).Item("NoID")
            End If
            prvQuery()
            If grdView.RowCount > 0 Then UI.usForm.GridMoveRow(grdView, "NoID", strSearch)
        End With
    End Sub

#End Region

#Region "Form Handle"

    Private Sub Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        prvSetIcon()
        prvSetGrid()
        prvQuery()
        prvSetButton()
    End Sub

    Private Sub ToolBar_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles ToolBar.ButtonClick
        If e.Button.Text = "Refresh" Then
            pubRefresh()
        ElseIf grdView.FocusedRowHandle >= 0 Then
            Select Case e.Button.Text
                Case "Order History" : prvDetail()
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

    Private Sub txtNoID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNoID.TextChanged
        prvQuery()
    End Sub

    Private Sub txtNama_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNama.TextChanged
        prvQuery()
    End Sub

#End Region

   
End Class
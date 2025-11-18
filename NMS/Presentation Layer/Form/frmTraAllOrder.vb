Public Class frmTraAllOrder

#Region "Look Up"

    Private bolLookUp As Boolean = False
    Private bolLookUpGet As Boolean = False
    Private strLUNoAkta As String
    Private strLUNamaClient As String
    Private intLURow As Integer
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

    Public Property pubLURow() As Integer
        Get
            Return intLURow
        End Get
        Set(ByVal Value As Integer)
            intLURow = Value
        End Set
    End Property

    Public Property pubLUNoAkta() As String
        Get
            Return strLUNoAkta
        End Get
        Set(ByVal Value As String)
            strLUNoAkta = Value
        End Set
    End Property

    Public Property pubLUNamaClient() As String
        Get
            Return strLUNamaClient
        End Get
        Set(ByVal Value As String)
            strLUNamaClient = Value
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
       cRefresh = 0

    Private intPos As Integer

    Private Sub prvSetIcon()
        UI.usForm.SetToolBar(Me, ToolBar, "0,Refresh")
    End Sub

    Private Sub prvSetGrid()
        UI.usForm.SetGrid(grdView, "Row", "Row", 100, UI.usDefGrid.gString, False)
        UI.usForm.SetGrid(grdView, "NoAkta", "No Urut / No Akta", 120, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "Nama", "Nama Client", 200, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "TglAkta", "Tanggal Akta", 120, UI.usDefGrid.gSmallDate)
        UI.usForm.SetGrid(grdView, "JenisTransaksi", "Jenis Transaksi", 200, UI.usDefGrid.gString)
    End Sub

    Private Sub prvSetLookUp()
        If bolLookUp Then
            UI.usForm.GridMoveRow(grdView, "Row", intLURow)
        End If
    End Sub

    Private Sub prvGet()
        intPos = grdView.FocusedRowHandle
        If bolLookUp And intPos >= 0 Then
            intLURow = grdView.GetDataRow(intPos).Item("Row")
            strLUNoAkta = grdView.GetDataRow(intPos).Item("NoAkta")
            strLUNamaClient = grdView.GetDataRow(intPos).Item("Nama")
            dtrLUDataRow = grdView.GetDataRow(grdView.FocusedRowHandle)
            bolLookUpGet = True
            Me.Close()
        End If
    End Sub

    Private Sub prvQuery()
        Try
            grdMain.DataSource = DL.PaymentIn.ListAllOrder(dtpDateFrom.Value, dtpDateTo.Value, cboJenisTransaksi.SelectedIndex)
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try
    End Sub

    Public Sub pubRefresh(Optional ByVal strSearch As String = "")
        With grdView
            If Not grdView.FocusedValue Is Nothing And strSearch = "" Then
                strSearch = grdView.GetDataRow(grdView.FocusedRowHandle).Item("Row")
            End If
            prvQuery()
            If grdView.RowCount > 0 Then UI.usForm.GridMoveRow(grdView, "Row", strSearch)
        End With
    End Sub

#End Region

#Region "Form Handle"

    Private Sub Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cboJenisTransaksi.SelectedIndex = 2
        dtpDateFrom.Value = Today.Year & "/" & Today.Month & "/" & "01 23:59:59"
        dtpDateTo.Value = dtpDateFrom.Value.AddMonths(1).AddDays(-1)
        prvSetIcon()
        prvSetGrid()
        prvQuery()
    End Sub

    Private Sub ToolBar_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles ToolBar.ButtonClick
        If e.Button.Text = "Refresh" Then
            pubRefresh()
        End If
    End Sub

    Private Sub btnExecute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExecute.Click
        prvQuery()
    End Sub

    Private Sub grdMain_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdMain.DoubleClick
        If bolLookUp = True Then
            Me.prvGet()
        End If
    End Sub

#End Region


End Class
Public Class frmTraPaymentOut

#Region "Function"
    Private Const _
        cNew = 0, cDetail = 1, cDelete = 2, cRefresh = 4

    Private intPos As Integer

    Private Sub prvSetIcon()
        UI.usForm.SetToolBar(Me, ToolBar, "0,New,1,Detail,2,Delete,4,Refresh")
    End Sub

    Private Sub prvSetButton()
        Dim bolEdit, bolView As Boolean
        bolEdit = DL.MasterUser.IsAccess("PAYMENT OUT EDIT")
        bolView = DL.MasterUser.IsAccess("PAYMENT OUT VIEW")

        With ToolBar.Buttons
            .Item(cNew).Enabled = bolEdit
            .Item(cDetail).Enabled = IIf(bolEdit, bolEdit, bolView)
            .Item(cDelete).Enabled = bolEdit
        End With
    End Sub

    Private Sub prvSetGrid()
        UI.usForm.SetGrid(grdView, "POutID", "Payment Out ID", 100, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdView, "PInID", "Payment In ID", 100, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdView, "NoAkta", "No Akta", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "NamaClient", "Nama Client", 200, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "PDate", "Tanggal Kwitansi", 100, UI.usDefGrid.gSmallDate)
        UI.usForm.SetGrid(grdView, "B", "Biaya", 150, UI.usDefGrid.gIntNum)
        UI.usForm.SetGrid(grdView, "Remarks", "Remarks", 200, UI.usDefGrid.gString)

        UI.usForm.SetGrid(grdView, "CreatedBy", "Created By", 100, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "CreatedDate", "Created Date", 130, UI.usDefGrid.gFullDate)
        UI.usForm.SetGrid(grdView, "ModifiedBy", "Modified By", 120, UI.usDefGrid.gString)
        UI.usForm.SetGrid(grdView, "ModifiedDate", "Modified Date", 130, UI.usDefGrid.gFullDate)
    End Sub

    Private Sub prvNew()
        Dim frmDetail As New frmTraPaymentOutDet
        With frmDetail
            .pubIsNew = True
            .pubShowDialog(Me)
        End With
    End Sub

    Private Sub prvDetail()
        intPos = grdView.FocusedRowHandle
        Dim frmDetail As New frmTraPaymentOutDet
        With frmDetail
            .pubIsNew = False
            .pubPaymentOutID = grdView.GetDataRow(intPos).Item("POutID")
            .pubShowDialog(Me)
            If .pubIsSave Then pubRefresh()
        End With
    End Sub

    Private Sub prvDelete()
        intPos = grdView.FocusedRowHandle
        Dim intPaymentOutID As Integer = grdView.GetDataRow(intPos).Item("POutID")
        Try
            If Not UI.usForm.frmAskQuestion("Hapus Payment Out ID : " & intPaymentOutID & " ?") Then Exit Sub
            DL.PaymentOut.DeleteHeader(intPaymentOutID)
            UI.usForm.frmMessageBox("Payment In ID :" & intPaymentOutID & " berhasil dihapus ! ")
            pubRefresh()
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try
    End Sub

    Private Sub prvQuery()
        Try
            grdMain.DataSource = DL.PaymentOut.ListData(dtpDateFrom.Value, dtpDateTo.Value)
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try
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

#End Region


End Class
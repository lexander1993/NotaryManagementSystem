Public Class frmToolsClosePeriod

    Private Const _
        cPreview = 0, cClose = 1

    Private Sub prvSetIcon()
        UI.usForm.SetToolBar(Me, ToolBar, "0,Save,1,Reject")
    End Sub

    Private Sub prvClosePeriod()
        If Not UI.usForm.frmAskQuestion("Close Period transaksi tanggal " & dtpDateFrom.Value.ToString("dd-MM-yyyy") & " - " & dtpDateTo.Value.ToString("dd-MM-yyyy") & " ?") Then Exit Sub
        Try
            DL.AdminFee.ClosePeriod(dtpDateFrom.Value.Date, dtpDateTo.Value.Date, numHargaFee.Value)
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.ToString)
        End Try
        UI.usForm.frmMessageBox("Close Period berhasil !")
        SetDate()
    End Sub

    Private Sub prvUnclosePeriod()
        If Not UI.usForm.frmAskQuestion("Unclose Period transaksi tanggal " & dtpLastPeriod.Value.ToString("dd-MM-yyyy") & " ?") Then Exit Sub
        Try
            DL.AdminFee.UnClosePeriod(dtpLastPeriod.Value.Date)
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.ToString)
        End Try
        UI.usForm.frmMessageBox("Periode Transaksi " & dtpLastPeriod.Value.ToString("dd-MM-yyyy") & " berhasil diunclose ")
        SetDate()
    End Sub

    Private Sub SetDate()
        dtpLastPeriod.Value = DL.AdminFee.GetLastPeriod
        dtpDateFrom.Value = dtpLastPeriod.Value.AddDays(1)
        dtpDateTo.Value = Today
    End Sub

#Region "Form Handle"

    Private Sub frmRptSummaryLocalPurchaseByCategory_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        prvSetIcon()
        SetDate()
    End Sub

    Private Sub frmRptSummaryLocalPurchaseByCategory_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If UI.usForm.frmAskQuestion("Close this form?") Then
                Me.Close()
            End If
        End If
    End Sub

    Private Sub ToolBar_ButtonClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles ToolBar.ButtonClick
        Select Case e.Button.Text.Trim
            Case "Close Period" : Me.prvClosePeriod()
            Case "Unclose Period" : Me.prvUnclosePeriod()
            Case "Close" : Me.Close()
        End Select
    End Sub

#End Region

End Class
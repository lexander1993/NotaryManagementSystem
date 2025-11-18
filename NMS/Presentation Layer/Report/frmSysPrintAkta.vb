Public Class frmSysPrintAkta

    Dim oDocument As Object

    Private Const _
        cPreview = 0, cClose = 1

    Private Sub prvSetIcon()
        UI.usForm.SetToolBar(Me, ToolBar, "0,Print,1,Close")
    End Sub

    Private Sub prvPreview()
        'If txtReportTitle.Text.Trim = "" Then
        '    UI.usForm.frmMessageBox("Report Title cannot blank")
        '    txtReportTitle.Focus()
        '    Exit Sub
        'End If

        Dim crReportFile As New rptPrintAkta
        'crReportFile.SetDataSource(DL.Report.NotaryOrder()

        crReportFile.SetParameterValue("Line1", "| " & TextBox1.Text)
        crReportFile.SetParameterValue("Line2", "| " & TextBox2.Text)
        crReportFile.SetParameterValue("Line3", "| " & TextBox3.Text.Trim)

        Dim frmDetail As New frmSysReport
        With frmDetail
            .MdiParent = frmMain
            .crvViewer.ReportSource = crReportFile
            .crvViewer.Refresh()
            .crvViewer.Show()
            .WindowState = FormWindowState.Maximized
            .StartPosition = FormStartPosition.CenterScreen
            .Show()
        End With
    End Sub

#Region "Form Handle"

    'Private Sub frmRptSummaryLocalPurchaseByCategory_Load(ByVal sender As Object, ByVal e As System.EventArgs)
    '    prvSetIcon()

    'End Sub

    Private Sub frmRptSummaryLocalPurchaseByCategory_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            If UI.usForm.frmAskQuestion("Close this form?") Then
                Me.Close()
            End If
        End If
    End Sub

    Private Sub ToolBar_ButtonClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles ToolBar.ButtonClick
        Select Case e.Button.Text.Trim
            Case "Preview" : Me.prvPreview()
            Case "Close" : Me.Close()
        End Select
    End Sub
#End Region

    Private Sub Button1_Click(ByVal sender As System.Object, _
      ByVal e As System.EventArgs) Handles Button1.Click

        Dim strFileName As String

        'Find the Office document.
        With OpenFileDialog1
            .FileName = ""
            .ShowDialog()
            strFileName = .FileName
        End With

        'If the user does not cancel, open the document.
        If strFileName.Length Then
            oDocument = Nothing
            WebBrowser1.Navigate(strFileName)
        End If

    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As  _
       System.EventArgs) Handles MyBase.Load

        Button1.Text = "Browse"

        With OpenFileDialog1
            .Filter = "Office Documents " & _
            "(*.doc, *.xls, *.ppt)|*.doc;*.xls;*.ppt"
            .FilterIndex = 1
        End With

    End Sub

    Private Sub Form1_Closing(ByVal sender As Object, ByVal e As  _
       System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        oDocument = Nothing

    End Sub

    'Private Sub WebBrowser1_Navigated(ByVal sender As Object, ByVal e As System.Windows.Forms.WebBrowserNavigatedEventArgs) Handles WebBrowser1.Navigated

    '    On Error Resume Next

    '    oDocument = e.pDisp.Document

    '    'Note: You can use the reference to the document object to
    '    '      automate the document server.
    '    MsgBox("File opened by: " & oDocument.Application.Name)

    'End Sub
End Class
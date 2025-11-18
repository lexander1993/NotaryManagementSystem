Public Class frmTraPPATOrderProcess

#Region "Property"

    Private frmParent As frmTraPPATOrder
    Private bolSave As Boolean
    Private strPPATOrderID As String
    Private strStatus As String

    Public ReadOnly Property pubIsSave() As Boolean
        Get
            Return bolSave
        End Get
    End Property

    Public Property pubStatus() As String
        Get
            Return strStatus
        End Get
        Set(ByVal Value As String)
            strStatus = Value
        End Set
    End Property

    Public Property pubPPATOrderID() As String
        Get
            Return strPPATOrderID
        End Get
        Set(ByVal Value As String)
            strPPATOrderID = Value
        End Set
    End Property

#End Region

#Region "Function"
    Private Const _
       cSave = 0, cClose = 1

    Private clsData As New VO.PPATOrder

    Public Sub pubShowDialog(ByVal frmGetParent As Form)
        frmParent = frmGetParent
        Me.ShowDialog()
    End Sub

    Private Sub prvSetIcon()
        UI.usForm.SetToolBar(Me, ToolBar, "0,Save,1,Close")
    End Sub

    Private Sub prvSetTitle()
        Me.Text += " [PPAT Order ID : " & strPPATOrderID & "]"
    End Sub

    Private Sub prvFillForm()
        dtpProcessDate.Value = Today
        If strStatus = "DRAFT" Then
            rdProcess.Checked = True
            rdCancelProcess.Enabled = False
        ElseIf strStatus = "PROCESS" Then
            rdCancelProcess.Checked = True
            rdProcess.Enabled = False
            dtpProcessDate.Enabled = False
            txtRemarks.ReadOnly = True
        End If
    End Sub

    Private Sub prvSave()
        'If strStatus = "DRAFT" And txtRemarks.Text = "" Then
        '    UI.usForm.frmMessageBox("Remarks harus diisi !")
        '    txtRemarks.Focus()
        '    Exit Sub
        'End If

        clsData.PPATOrderID = strPPATOrderID
        clsData.Status = IIf(rdProcess.Checked = True, 2, 1)
        clsData.ProcessDate = dtpProcessDate.Value
        clsData.ProcessRemarks = txtRemarks.Text

        Try
            If rdProcess.Checked = True Then
                If Not UI.usForm.frmAskQuestion("Update Status to PROCESS ?") Then Exit Sub
            Else
                If Not UI.usForm.frmAskQuestion("Update Status to DRAFT (Cancel Proces) ?") Then Exit Sub
            End If
            DL.PPATOrder.UpdateProcess(clsData)

            bolSave = True
            Me.Close()
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
            bolSave = False
        End Try
    End Sub

#End Region

#Region "Form Handle"

    Private Sub Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        prvSetIcon()
        prvFillForm()
        prvSetTitle()
    End Sub

    Private Sub ToolBar_ButtonClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles ToolBar.ButtonClick
        If e.Button.Text = "Save" Then
            prvSave()
        Else
            Me.Close()
        End If
    End Sub

#End Region

   
End Class
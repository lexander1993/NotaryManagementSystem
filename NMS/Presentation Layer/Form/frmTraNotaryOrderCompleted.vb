Public Class frmTraNotaryOrderCompleted

#Region "Property"

    Private frmParent As frmTraNotaryOrder
    Private bolSave As Boolean
    Private strNotaryOrderID As String
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

    Public Property pubNotaryOrderID() As String
        Get
            Return strNotaryOrderID
        End Get
        Set(ByVal Value As String)
            strNotaryOrderID = Value
        End Set
    End Property

#End Region

#Region "Function"
    Private Const _
       cSave = 0, cClose = 1

    Private clsData As New VO.NotaryOrder

    Public Sub pubShowDialog(ByVal frmGetParent As Form)
        frmParent = frmGetParent
        Me.ShowDialog()
    End Sub

    Private Sub prvSetIcon()
        UI.usForm.SetToolBar(Me, ToolBar, "0,Save,1,Close")
    End Sub

    Private Sub prvSetTitle()
        Me.Text += " [Notary Order ID : " & strNotaryOrderID & "]"
    End Sub

    Private Sub prvFillForm()
        If strStatus = "PROCESS" Then
            rdCompleted.Checked = True
            rdCancelCompleted.Enabled = False
        ElseIf strStatus = "COMPLETED" Then
            rdCancelCompleted.Checked = True
            rdCompleted.Enabled = False
            txtRemarks.ReadOnly = True
        End If
    End Sub

    Private Sub prvSave()
        'If strStatus = "PROCESS" And txtRemarks.Text = "" Then
        '    UI.usForm.frmMessageBox("Remarks harus diisi !")
        '    txtRemarks.Focus()
        '    Exit Sub
        'End If

        clsData.NotaryOrderID = strNotaryOrderID
        clsData.Status = IIf(rdCompleted.Checked = True, 3, 2)
        clsData.CompletedRemarks = txtRemarks.Text

        Try
            If rdCompleted.Checked = True Then
                If Not UI.usForm.frmAskQuestion("Update Status to COMPLETED ?") Then Exit Sub
            Else
                If Not UI.usForm.frmAskQuestion("Update Status to PROCESS (Cancel Completed) ?") Then Exit Sub
            End If
            DL.NotaryOrder.UpdateCompleted(clsData)

            UI.usForm.frmMessageBox("Update successful")
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
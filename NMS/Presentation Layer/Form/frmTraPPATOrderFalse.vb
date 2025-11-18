Public Class frmTraPPATOrderFalse

#Region "Property"

    Private frmParent As frmTraPPATOrder
    Private bolSave As Boolean
    Private strPPATOrderID, strStatus, strDraftBy, strProcessBy As String
    Private bolIsFalse As Boolean

    Public ReadOnly Property pubIsSave() As Boolean
        Get
            Return bolSave
        End Get
    End Property

    Public Property pubIsFalse() As Boolean
        Get
            Return bolIsFalse
        End Get
        Set(ByVal Value As Boolean)
            bolIsFalse = Value
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

    Public Property pubStatus() As String
        Get
            Return strStatus
        End Get
        Set(ByVal Value As String)
            strStatus = Value
        End Set
    End Property

    Public Property pubDraftBy() As String
        Get
            Return strDraftBy
        End Get
        Set(ByVal Value As String)
            strDraftBy = Value
        End Set
    End Property

    Public Property pubProcessBy() As String
        Get
            Return strProcessBy
        End Get
        Set(ByVal Value As String)
            strProcessBy = Value
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
        cboIsFalseLevel.SelectedIndex = 0
        ToolStripStatus.Text = "STATUS : " & strStatus
        ToolStripDraftBy.Text = "DRAFT BY : " & strDraftBy
        ToolStripProcessBy.Text = "PROCESS BY : " & strProcessBy
        If bolIsFalse = False Then
            rdFalse.Checked = True
            rdCancelFalse.Enabled = False
        ElseIf bolIsFalse = True Then
            rdCancelFalse.Checked = True
            cboIsFalseLevel.Enabled = False
            rdFalse.Enabled = False
            txtRemarks.ReadOnly = True
        End If
    End Sub

    Private Sub prvSave()
        'If bolIsFalse = 0 And txtRemarks.Text = "" Then
        '    UI.usForm.frmMessageBox("Remarks harus diisi !")
        '    txtRemarks.Focus()
        '    Exit Sub
        'End If

        clsData.PPATOrderID = strPPATOrderID
        clsData.IsFalse = IIf(rdFalse.Checked = True, 1, 0)
        clsData.IsFalseRemarks = txtRemarks.Text
        clsData.IsFalseLevel = cboIsFalseLevel.SelectedIndex

        Try
            If rdFalse.Checked = True Then
                If Not UI.usForm.frmAskQuestion("Update IsFalse = TRUE ?") Then Exit Sub
            Else
                If Not UI.usForm.frmAskQuestion("Update IsFalse = FALSE (Cancel False) ?") Then Exit Sub
            End If
            DL.PPATOrder.UpdateIsFalse(clsData)

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
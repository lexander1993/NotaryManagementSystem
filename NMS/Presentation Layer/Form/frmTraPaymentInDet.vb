Public Class frmTraPaymentInDet
#Region "Property"

    Private frmParent As frmTraPaymentIn
    Private frmParentNotification As frmSysNotificationPayment 
    Private bolNew, bolSave As Boolean
    Private intPaymentInID As Integer = 0

    Public WriteOnly Property pubIsNew() As Boolean
        Set(ByVal Value As Boolean)
            bolNew = Value
        End Set
    End Property

    Public ReadOnly Property pubIsSave() As Boolean
        Get
            Return bolSave
        End Get
    End Property

    Public Property pubPaymentInID() As Integer
        Get
            Return intPaymentInID
        End Get
        Set(ByVal Value As Integer)
            intPaymentInID = Value
        End Set
    End Property

#End Region

#Region "Function"

    Private Const _
       cSave = 0, cExit = 1

    Private clsData As New VO.PaymentIn

    Public Sub pubShowDialog(ByVal frmGetParent As Form)
        frmParent = frmGetParent
        Me.ShowDialog()
    End Sub

    Public Sub pubShowDialogNotification(ByVal frmGetParentNotification As Form)
        frmParentNotification = frmGetParentNotification
        Me.ShowDialog()
    End Sub

    Private Sub prvSetIcon()
        UI.usForm.SetToolBar(Me, ToolBar, "0,Save,1,Close")
    End Sub

    Private Sub prvSetTitleForm()
        If bolNew Then
            Me.Text += " [new] "
        Else
            Me.Text += " [edit] " & intPaymentInID
        End If
    End Sub

    Private Sub prvSetButton()
        Dim bolEdit As Boolean
        bolEdit = DL.MasterUser.IsAccess("PAYMENT IN EDIT")

        With ToolBar.Buttons
            .Item(0).Enabled = bolEdit
        End With
    End Sub

    Private Sub prvFillForm()
        Try
            If Not bolNew Then
                clsData = DL.PaymentIn.GetDetail(intPaymentInID)

                txtPaymentInID.Text = intPaymentInID
                txtNoAkta.Text = clsData.NoAkta
                txtNamaClient.Text = clsData.NamaClient
                dtpTanggalKwitansi.Value = clsData.PDate
                numBiaya.Value = clsData.B
                txtRemarks.Text = clsData.Remarks
                chkIsOtherPayment.Checked = clsData.IsOther
                cboStatus.SelectedIndex = clsData.Status
                numExpInterval.Value = clsData.ExpInterval

                ToolStripCreatedDate.Text = "CREATED DATE : " & Format(clsData.CreatedDate, UI.usDefCons.DateFull)
                ToolStripModifiedDate.Text = "MODIFIED DATE : " & Format(clsData.ModifiedDate, UI.usDefCons.DateFull)
                ToolStripCreatedDate.Visible = True
                ToolStripModifiedDate.Visible = True
            Else
                dtpTanggalKwitansi.Value = Today
                cboStatus.SelectedIndex = 0
            End If
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try
    End Sub

    Private Function ValidateData() As Boolean
        If txtNoAkta.Text.Trim = "" Then
            If UI.usForm.frmAskQuestion("No Akta belum diisi, lanjut simpan data ?") = False Then
                Return False
            End If
        End If

        If txtNamaClient.Text = "" Then
            UI.usForm.frmMessageBox("Nama Client harus diisi !")
            txtNamaClient.Focus()
            Return False
        End If

        If numBiaya.Value <= 0 Then
            UI.usForm.frmMessageBox("Biaya harus diisi !")
            txtPaymentInID.Focus()
            Return False
        End If

        If txtRemarks.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Remarks harus diisi !")
            txtRemarks.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub prvSave()
        txtPaymentInID.Focus()
        If Not ValidateData() Then Exit Sub

        clsData.PInID = IIf(bolNew = True, 0, intPaymentInID)
        clsData.NoAkta = txtNoAkta.Text.Trim
        clsData.NamaClient = txtNamaClient.Text.Trim
        clsData.PDate = dtpTanggalKwitansi.Value
        clsData.B = numBiaya.Value
        clsData.Remarks = txtRemarks.Text
        clsData.IsOther = chkIsOtherPayment.Checked
        clsData.Status = cboStatus.SelectedIndex
        clsData.ExpInterval = numExpInterval.Value

        Try
            'Simpan semua Data Header dan Detail
            DL.PaymentIn.SaveData(bolNew, clsData)
            bolSave = True
            If bolNew Then
                UI.usForm.frmMessageBox("Save Success Payment In !")
            Else
                UI.usForm.frmMessageBox("Update Success Payment In !")
            End If
            Try
                frmParent.pubRefresh(txtNoAkta.Text)
                Me.Close()
            Catch ex As Exception
                frmParentNotification.pubRefresh(intPaymentInID)
                Me.Close()
            End Try
        Catch ex As Exception
            bolSave = False
            UI.usForm.frmMessageBox(ex.Message)
        End Try
    End Sub



#End Region

#Region "Form Handle"

    Private Sub Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        prvSetIcon()
        prvSetTitleForm()
        prvFillForm()
        prvSetButton()
        SetToSelectAllWhenFocusControl(Me)
    End Sub

    Private Sub ToolBar_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles ToolBar.ButtonClick
        If e.Button.Text = "Save" Then
            prvSave()
        Else
            Me.Close()
        End If
    End Sub

    Private Sub NumericUpDown_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim child As NumericUpDown = CType(sender, NumericUpDown)
        child.Select(0, child.Value.ToString("N" + child.DecimalPlaces.ToString()).Length)
    End Sub

    Private Sub TextBox_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim child As TextBox = CType(sender, TextBox)
        child.SelectAll()
    End Sub

    Private Sub ComboBox_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim child As ComboBox = CType(sender, ComboBox)
        child.SelectAll()
    End Sub

    Private Sub SetToSelectAllWhenFocusControl(ByVal currentControl As Control)
        For Each child As Control In currentControl.Controls
            If (child.GetType().Name = "TextBox") Then
                AddHandler child.GotFocus, AddressOf TextBox_GotFocus
            ElseIf (child.GetType().Name = "ComboBox") Then
                AddHandler child.GotFocus, AddressOf ComboBox_GotFocus
            ElseIf (child.GetType().Name = "NumericUpDown") Then
                AddHandler child.GotFocus, AddressOf NumericUpDown_GotFocus
            ElseIf (child.Controls.Count > 0) Then
                SetToSelectAllWhenFocusControl(child)
            End If
        Next
    End Sub
#End Region


   
    Private Sub btnNoAkta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNoAkta.Click
        Dim frmDetail As New frmTraAllOrder
        With frmDetail
            .pubIsLookUp = True
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
            If .pubIsLookUpGet Then
                txtNoAkta.Text = .pubLUDataRow("NoAkta")
                txtNamaClient.Text = .pubLUDataRow("Nama")
            End If
        End With
    End Sub
End Class
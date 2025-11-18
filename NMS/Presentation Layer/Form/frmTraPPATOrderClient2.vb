Public Class frmTraPPATOrderClient2

#Region "Property"

    Private frmParent As frmTraPPATOrderDet
    Private strNoID As String
    Private intIndex As Integer
    Private intIndexPlus1 As Integer
    Private bolNew As Boolean
    Private strPPATOrderID As String

    Public WriteOnly Property pubIsNew() As Boolean
        Set(ByVal Value As Boolean)
            bolNew = Value
        End Set
    End Property

    Public Property pubPPATOrderID() As String
        Get
            Return strPPATOrderID
        End Get
        Set(ByVal value As String)
            strPPATOrderID = value
        End Set
    End Property

    Public Property pubNoID() As String
        Get
            Return strNoID
        End Get
        Set(ByVal Value As String)
            strNoID = Value
        End Set
    End Property

    Public Property pubIndex() As Integer
        Get
            Return intIndex
        End Get
        Set(ByVal Value As Integer)
            intIndex = Value
        End Set
    End Property

#End Region

    Private dtTable As DataTable
    Private dtRow, dtRowUpd As DataRow

    Public Sub pubShowDialog(ByVal frmGetParent As Form)
        frmParent = frmGetParent
        Me.ShowDialog()
    End Sub

    Private Sub prvSetIcon()
        UI.usForm.SetToolBar(Me, ToolBar, "0,Add,1,Close")
    End Sub

    Private Sub prvSetTitleForm()
        If bolNew Then
            Me.Text += " [new] "
        Else
            Me.Text += " [edit] "
        End If
    End Sub

    Private Function ValidateData() As Boolean
        If cboJenisID.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Jenis ID harus diisi")
            cboJenisID.Focus()
            Return False
        End If

        If txtNoID.Text.Trim = "" Then
            UI.usForm.frmMessageBox("No ID harus diisi")
            txtNoID.Focus()
            Return False
        End If

        If cboWargaNegara.Text = "WNA" And txtNegara.Text = "" Then
            UI.usForm.frmMessageBox("Nama Negara harus diisi")
            txtNegara.Focus()
            Return False
        End If

        If txtNama.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Nama harus diisi !")
            txtNama.Focus()
            Return False
        End If

        If txtTempatLahir.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Tempat Lahir harus diisi !")
            txtTempatLahir.Focus()
            Return False
        End If

        If dtpTglLahir.Value = Today Then
            UI.usForm.frmMessageBox("Tanggal Lahir harus diisi dengan benar !")
            dtpTglLahir.Focus()
            Return False
        End If

        If txtAlamat.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Alamat harus diisi !")
            txtAlamat.Focus()
            Return False
        End If

        If txtPekerjaan.Text.Trim = "" Then
            UI.usForm.frmMessageBox("Pekerjaan harus diisi !")
            txtPekerjaan.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub prvAdd()
        cboJenisID.Focus()
        If Not ValidateData() Then Exit Sub

        If bolNew Then
            If Not UI.usForm.frmAskQuestion("Add This Data ?") Then Exit Sub
        Else
            If Not UI.usForm.frmAskQuestion("Edit This Data ?") Then Exit Sub
        End If

        dtTable = frmParent.grdClient2.DataSource

        Dim bolFind As Boolean = False
        For Each drData As DataRow In dtTable.Rows
            If drData.Item("NoID") = txtNoID.Text Then
                If bolNew Then
                    bolFind = True
                Else
                    drData.Delete()
                End If
            End If
        Next
        If bolNew Then
            If bolFind Then
                UI.usForm.frmMessageBox("Client ID already in Client View")
                Exit Sub
            End If
        Else
            dtTable.AcceptChanges()
        End If

        dtRow = dtTable.NewRow
        dtRow.BeginEdit()
        dtRow.Item("Index") = IIf(bolNew, intIndexPlus1, intIndex)
        dtRow.Item("JenisID") = cboJenisID.Text
        dtRow.Item("NoID") = txtNoID.Text.Trim
        dtRow.Item("WargaNegara") = cboWargaNegara.Text.Trim
        dtRow.Item("Negara") = txtNegara.Text.Trim
        dtRow.Item("Nama") = txtNama.Text
        dtRow.Item("TempatLahir") = txtTempatLahir.Text
        dtRow.Item("TglLahir") = dtpTglLahir.Value
        dtRow.Item("Alamat") = txtAlamat.Text
        dtRow.Item("Pekerjaan") = txtPekerjaan.Text
        dtRow.Item("NoNPWP") = txtNoNPWP.Text
        dtRow.Item("NoTelp") = txtNoTelepon.Text.Trim
        dtRow.Item("NoHP") = txtNoHp.Text.Trim
        dtRow.Item("Remarks") = txtKet.Text.Trim
        dtRow.Item("Title") = cboTitle.Text
        dtRow.Item("TglLahirStr") = txtTglLahirStr.Text.Trim
        dtRow.EndEdit()

        dtTable.Rows.Add(dtRow)
        dtTable.AcceptChanges()
        frmParent.grdClient2.DataSource = dtTable
        frmParent.pubRefresh()

        Me.Close()
    End Sub

    Private Sub prvFillForm()
        dtTable = frmParent.grdClient2.DataSource
        If bolNew Then
            cboWargaNegara.SelectedIndex = 0
            cboJenisID.SelectedIndex = 0
            dtpTglLahir.Value = Today
            intIndexPlus1 = intIndex + 1
        Else
            cboJenisID.Enabled = False
            txtNoID.Enabled = False

            For Each drData As DataRow In dtTable.Rows
                If drData.Item("NoID") = strNoID Then
                    intIndex = drData.Item("Index")
                    cboJenisID.Text = drData.Item("JenisID")
                    txtNoID.Text = drData.Item("NoID")
                    cboWargaNegara.Text = drData.Item("WargaNegara")
                    txtNegara.Text = drData.Item("Negara")
                    txtNama.Text = drData.Item("Nama")
                    txtTempatLahir.Text = drData.Item("TempatLahir")
                    dtpTglLahir.Text = drData.Item("TglLahir")
                    txtAlamat.Text = drData.Item("Alamat")
                    txtPekerjaan.Text = drData.Item("Pekerjaan")
                    txtNoNPWP.Text = drData.Item("NoNPWP")
                    txtNoTelepon.Text = drData.Item("NoTelp")
                    txtNoHp.Text = drData.Item("NoHp")
                    txtKet.Text = drData.Item("Remarks")
                    cboTitle.Text = drData.Item("Title")
                    txtTglLahirStr.Text = drData.Item("TglLahirStr")
                End If
            Next
        End If

    End Sub

#Region "Form Handle"

    Private Sub frmTraPOItem_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        prvSetIcon()
        prvSetTitleForm()
        prvFillForm()
    End Sub

    Private Sub ToolBar_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles ToolBar.ButtonClick
        If e.Button.Text = "Close" Then
            Me.Close()
        Else
            prvAdd()
        End If
    End Sub

    Private Sub cboWargaNegara_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboWargaNegara.SelectedIndexChanged
        If cboWargaNegara.Text = "WNI" Then
            txtNegara.Visible = False
            txtNegara.Text = ""
        Else
            txtNegara.Visible = True
        End If
    End Sub

    Private Sub btnID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnID.Click
        Dim frmDetail As New frmMstClient
        With frmDetail
            .pubIsLookUp = True
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
            If .pubIsLookUpGet Then
                cboJenisID.Text = .pubLUDataRow("JenisID")
                txtNoID.Text = .pubLUDataRow("NoID")
                cboWargaNegara.Text = .pubLUDataRow("WargaNegara")
                txtNegara.Text = .pubLUDataRow("Negara")
                txtNama.Text = .pubLUDataRow("Nama")
                txtTempatLahir.Text = .pubLUDataRow("TempatLahir")
                dtpTglLahir.Value = .pubLUDataRow("TglLahir")
                txtAlamat.Text = .pubLUDataRow("Alamat")
                txtPekerjaan.Text = .pubLUDataRow("Pekerjaan")
                cboTitle.Text = .pubLUDataRow("Title")
                txtTglLahirStr.Text = .pubLUDataRow("TglLahirStr")
            End If
        End With
    End Sub

    Private Sub dtpTglLahir_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpTglLahir.ValueChanged
        Dim Tanggal, Bulan, Tahun As String
        Tanggal = UI.Terbilang.Terbilang(CDbl(dtpTglLahir.Value.ToString("dd"))).Trim
        Bulan = UI.Terbilang.Bulan(CInt(dtpTglLahir.Value.ToString("MM")))
        Tahun = UI.Terbilang.Terbilang(CDbl(dtpTglLahir.Value.ToString("yyyy"))).Trim

        txtTglLahirStr.Text = dtpTglLahir.Value.ToString("dd-MM-yyyy") & " (" & Tanggal & " " & Bulan & " " & Tahun & ")"
    End Sub

#End Region

End Class
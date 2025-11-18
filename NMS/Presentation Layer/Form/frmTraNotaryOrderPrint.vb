Imports Word = Microsoft.Office.Interop.Word

'Imports Office = Microsoft.Office.Core
'Imports Microsoft.Office.Interop
'Imports VBIDE = Microsoft.Vbe.Interop

Public Class frmTraNotaryOrderPrint

#Region "Property"

    Private frmParent As frmTraNotaryOrderDet
    Private bolNew, bolSave As Boolean
    Private strNotaryOrderID As String = ""
    Private strPath As String = ""
    Private oWord As Word.Application
    Private oDoc As Word.Document


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

    Public Property pubNotaryOrderID() As String
        Get
            Return strNotaryOrderID
        End Get
        Set(ByVal Value As String)
            strNotaryOrderID = Value
        End Set
    End Property

    Public Property pubPath() As String
        Get
            Return strPath
        End Get
        Set(ByVal Value As String)
            strPath = Value
        End Set
    End Property

#End Region

#Region "Function"

    Private Const _
       cPrint = 0, cExit = 1

    Private clsData As New VO.NotaryOrder
    Private clsDataPI As New VO.NotaryClientDet1
    Private clsDataPI2 As New VO.NotaryClientDet1
    Private clsDataPII As New VO.NotaryClientDet2

    Public Sub pubShowDialog(ByVal frmGetParent As Form)
        frmParent = frmGetParent
        Me.ShowDialog()
    End Sub

    Private Sub prvSetIcon()
        UI.usForm.SetToolBar(Me, ToolBar, "0,Print,1,Close")
    End Sub

    Private Sub prvSetTitleForm()
        Me.Text += " [edit] " & strNotaryOrderID
    End Sub

    Private Sub prvFillForm()

        'clsData utk menampung entity PPATOrder
        'grdClient1.DataSource Harus diset agar tidak error wkt Fill Data Grid

        Try
            clsData = DL.NotaryOrder.GetDetail(strNotaryOrderID)
            clsDataPI = DL.NotaryOrder.GetPihakI(strNotaryOrderID)
            clsDataPI2 = DL.NotaryOrder.GetPihakI2(strNotaryOrderID)
            clsDataPII = DL.NotaryOrder.GetPihakII(strNotaryOrderID)

            cboTempatDiresmikan.SelectedIndex = 0
            txtJenisTransaksi.Text = clsData.JenisTransaksi
            txtNoAkta.Text = clsData.NoBulanan
            txtHariTanggalPukul.Text = ""
            txtNamaNotaris.Text = UI.usUserApp.AdminName
            txtKabupaten.Text = UI.usUserApp.AdminDaerahKerja
            txtWilayah.Text = "Propinsi Sumatera Utara"

            cboTitlePI.Text = clsDataPI.Title
            txtNamaPI.Text = clsDataPI.Nama
            txtTempatLahirPI.Text = clsDataPI.TempatLahir
            txtTanggalLahirPI.Text = clsDataPI.TglLahirStr
            txtWNPI.Text = clsDataPI.WargaNegara
            txtPekerjaanPI.Text = clsDataPI.Pekerjaan
            txtAlamatPI.Text = clsDataPI.Alamat
            txtJenisIDPI.Text = clsDataPI.JenisID
            txtNOIDPI.Text = clsDataPI.NoID

            cboTitlePI2.Text = clsDataPI2.Title
            txtNamaPI2.Text = clsDataPI2.Nama
            txtTempatLahirPI2.Text = clsDataPI2.TempatLahir
            txtTanggalLahirPI2.Text = clsDataPI2.TglLahirStr
            txtWNPI2.Text = clsDataPI2.WargaNegara
            txtPekerjaanPI2.Text = clsDataPI2.Pekerjaan
            txtAlamatPI2.Text = clsDataPI2.Alamat
            txtJenisIDPI2.Text = clsDataPI2.JenisID
            txtNOIDPI2.Text = clsDataPI2.NoID

            cboTitlePII.Text = clsDataPII.Title
            txtNamaPII.Text = clsDataPII.Nama
            txtTempatLahirPII.Text = clsDataPII.TempatLahir
            txtTanggalLahirPII.Text = clsDataPII.TglLahirStr
            txtWNPII.Text = clsDataPII.WargaNegara
            txtPekerjaanPII.Text = clsDataPII.Pekerjaan
            txtAlamatPII.Text = clsDataPII.Alamat
            txtJenisIDPII.Text = clsDataPII.JenisID
            txtNOIDPII.Text = clsDataPII.NoID

            'Tempat lahir, alamat, pekerjaan normal case di master user, ntclient 1,2

        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try

    End Sub

    Private Sub prvPrint()
        If Not UI.usForm.frmAskQuestion("Buat Draft Akta ?") Then Exit Sub
        UI.usForm.CreateWaitDialog()
        oWord = CreateObject("Word.Application")
        oWord.Visible = True
        oDoc = oWord.Documents.Add(UI.usUserApp.TemplateLocation)

        'Di template Anda, Anda dapat menentukan bookmark sehingga Anda otomatisasi klien dapat mengisi variabel teks pada lokasi tertentu dalam dokumen, sebagai berikut:
        oDoc.Bookmarks.Item("JenisTransaksi").Range.Text = txtJenisTransaksi.Text
        oDoc.Bookmarks.Item("NomorAkta").Range.Text = txtNoAkta.Text
        oDoc.Bookmarks.Item("HariTanggalPukul").Range.Text = txtHariTanggalPukul.Text
        oDoc.Bookmarks.Item("TempatDiresmikan").Range.Text = cboTempatDiresmikan.Text
        oDoc.Bookmarks.Item("NamaNotaris").Range.Text = txtNamaNotaris.Text
        oDoc.Bookmarks.Item("Kabupaten").Range.Text = txtKabupaten.Text
        oDoc.Bookmarks.Item("Wilayah").Range.Text = txtWilayah.Text


        oDoc.Bookmarks.Item("TitlePI").Range.Text = cboTitlePI.Text
        oDoc.Bookmarks.Item("NamaPI").Range.Text = txtNamaPI.Text
        oDoc.Bookmarks.Item("TempatLahirPI").Range.Text = txtTempatLahirPI.Text
        oDoc.Bookmarks.Item("TanggalLahirPI").Range.Text = txtTanggalLahirPI.Text
        oDoc.Bookmarks.Item("WargaNegaraPI").Range.Text = txtWNPI.Text
        oDoc.Bookmarks.Item("PekerjaanPI").Range.Text = txtPekerjaanPI.Text
        oDoc.Bookmarks.Item("AlamatPI").Range.Text = txtAlamatPI.Text
        oDoc.Bookmarks.Item("JenisIDPI").Range.Text = txtJenisIDPI.Text
        oDoc.Bookmarks.Item("NoIDPI").Range.Text = txtNOIDPI.Text

        oDoc.Bookmarks.Item("TitlePIA").Range.Text = cboTitlePI.Text
        oDoc.Bookmarks.Item("NamaPIA").Range.Text = txtNamaPI.Text

        oDoc.Bookmarks.Item("TitlePI2").Range.Text = cboTitlePI2.Text
        oDoc.Bookmarks.Item("NamaPI2").Range.Text = txtNamaPI2.Text
        oDoc.Bookmarks.Item("TempatLahirPI2").Range.Text = txtTempatLahirPI2.Text
        oDoc.Bookmarks.Item("TanggalLahirPI2").Range.Text = txtTanggalLahirPI2.Text
        oDoc.Bookmarks.Item("WargaNegaraPI2").Range.Text = txtWNPI2.Text
        oDoc.Bookmarks.Item("PekerjaanPI2").Range.Text = txtPekerjaanPI2.Text
        oDoc.Bookmarks.Item("AlamatPI2").Range.Text = txtAlamatPI2.Text
        oDoc.Bookmarks.Item("JenisIDPI2").Range.Text = txtJenisIDPI2.Text
        oDoc.Bookmarks.Item("NoIDPI2").Range.Text = txtNOIDPI2.Text

        oDoc.Bookmarks.Item("TitlePII").Range.Text = cboTitlePII.Text
        oDoc.Bookmarks.Item("NamaPII").Range.Text = txtNamaPII.Text
        oDoc.Bookmarks.Item("TempatLahirPII").Range.Text = txtTempatLahirPII.Text
        oDoc.Bookmarks.Item("TanggalLahirPII").Range.Text = txtTanggalLahirPII.Text
        oDoc.Bookmarks.Item("WargaNegaraPII").Range.Text = txtWNPII.Text
        oDoc.Bookmarks.Item("PekerjaanPII").Range.Text = txtPekerjaanPII.Text
        oDoc.Bookmarks.Item("AlamatPII").Range.Text = txtAlamatPII.Text
        oDoc.Bookmarks.Item("JenisIDPII").Range.Text = txtJenisIDPII.Text
        oDoc.Bookmarks.Item("NoIDPII").Range.Text = txtNOIDPII.Text
        oDoc.Bookmarks.Item("KeteranganPII").Range.Text = txtKeteranganPII.Text

        oDoc.Bookmarks.Item("TitlePIIA").Range.Text = cboTitlePII.Text
        oDoc.Bookmarks.Item("NamaPIIA").Range.Text = txtNamaPII.Text

        oDoc.Bookmarks.Item("NoSuratPK").Range.Text = txtNOSuratPerjanjianKredit.Text
        oDoc.Bookmarks.Item("JlhHtgPokok").Range.Text = txtJlhHutangPokok.Text
        oDoc.Bookmarks.Item("NilaiPenjaminan").Range.Text = txtNilaiPenjaminan.Text
        oDoc.Bookmarks.Item("NilaiPenjaminanA").Range.Text = txtNilaiPenjaminan.Text
        oDoc.Bookmarks.Item("NamaBendaJaminan").Range.Text = txtNamaBendaPenjaminan.Text

        oDoc.Bookmarks.Item("Rincian1").Range.Text = txtR1H.Text
        oDoc.Bookmarks.Item("Rincian2").Range.Text = txtR2H.Text
        oDoc.Bookmarks.Item("Rincian3").Range.Text = txtR3H.Text
        oDoc.Bookmarks.Item("Rincian4").Range.Text = txtR4H.Text
        oDoc.Bookmarks.Item("Rincian5").Range.Text = txtR5H.Text
        oDoc.Bookmarks.Item("Rincian6").Range.Text = txtR6H.Text
        oDoc.Bookmarks.Item("Rincian7").Range.Text = txtR7H.Text
        oDoc.Bookmarks.Item("Rincian8").Range.Text = txtR8H.Text

        oDoc.Bookmarks.Item("Ket1").Range.Text = txtR1D.Text
        oDoc.Bookmarks.Item("Ket2").Range.Text = txtR2D.Text
        oDoc.Bookmarks.Item("Ket3").Range.Text = txtR3D.Text
        oDoc.Bookmarks.Item("Ket4").Range.Text = txtR4D.Text
        oDoc.Bookmarks.Item("Ket5").Range.Text = txtR5D.Text
        oDoc.Bookmarks.Item("Ket6").Range.Text = txtR6D.Text
        oDoc.Bookmarks.Item("Ket7").Range.Text = txtR7D.Text
        oDoc.Bookmarks.Item("Ket8").Range.Text = txtR8D.Text

        oDoc.Bookmarks.Item("TitleS1").Range.Text = cboTitleS1.Text
        oDoc.Bookmarks.Item("NamaS1").Range.Text = txtNamaS1.Text
        oDoc.Bookmarks.Item("TempatLahirS1").Range.Text = txtTempatLahirS1.Text
        oDoc.Bookmarks.Item("TanggalLahirS1").Range.Text = txtTanggalLahirS1.Text
        oDoc.Bookmarks.Item("WargaNegaraS1").Range.Text = txtWNS1.Text
        oDoc.Bookmarks.Item("PekerjaanS1").Range.Text = txtPekerjaanS1.Text
        oDoc.Bookmarks.Item("AlamatS1").Range.Text = txtAlamatS1.Text
        oDoc.Bookmarks.Item("JenisIDS1").Range.Text = IIf(txtJenisIDS1.Text = "KTP", "Kartu Tanda Penduduk Republik Indonesia", txtJenisIDS1.Text)
        oDoc.Bookmarks.Item("NoIDS1").Range.Text = txtNOIDS1.Text

        oDoc.Bookmarks.Item("TitleS2").Range.Text = cboTitleS2.Text
        oDoc.Bookmarks.Item("NamaS2").Range.Text = txtNamaS2.Text
        oDoc.Bookmarks.Item("TempatLahirS2").Range.Text = txtTempatLahirS2.Text
        oDoc.Bookmarks.Item("TanggalLahirS2").Range.Text = txtTanggalLahirS2.Text
        oDoc.Bookmarks.Item("WargaNegaraS2").Range.Text = txtWNS2.Text
        oDoc.Bookmarks.Item("PekerjaanS2").Range.Text = txtPekerjaanS2.Text
        oDoc.Bookmarks.Item("AlamatS2").Range.Text = txtAlamatS2.Text
        oDoc.Bookmarks.Item("JenisIDS2").Range.Text = IIf(txtJenisIDS2.Text = "KTP", "Kartu Tanda Penduduk Republik Indonesia", txtJenisIDS2.Text)
        oDoc.Bookmarks.Item("NoIDS2").Range.Text = txtNoIDS2.Text

        GarisHorizontal()

        If txtNamaPI2.Text = "" Then
            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToBookmark, Name:="NoIDPI2")
            With oWord.ActiveDocument.Bookmarks
                .DefaultSorting = Word.WdBookmarkSortBy.wdSortByName
                .ShowHidden = False
            End With
            oWord.Selection.MoveDown(Unit:=Word.WdUnits.wdLine, Count:=1)
            oWord.Selection.HomeKey(Unit:=Word.WdUnits.wdLine)
            oWord.Selection.MoveUp(Unit:=Word.WdUnits.wdLine, Count:=4, Extend:=Word.WdMovementType.wdExtend)
            oWord.Selection.Delete(Unit:=Word.WdUnits.wdCharacter, Count:=1)
        End If
    End Sub


    Private Sub GarisHorizontal()
        'utk tambah paragraf di akhir document
        'Dim Pos As Double
        'Dim oRng As Word.Range

        'oWord.Selection.EndKey(Unit:=Word.WdUnits.wdLine)
        'Pos = oWord.InchesToPoints(7.75)
        'oDoc.Bookmarks.Item("\endofdoc").Range.InsertParagraphAfter()
        'Do
        '    oRng = oDoc.Bookmarks.Item("\endofdoc").Range
        '    oRng.ParagraphFormat.SpaceAfter = 0
        '    oRng.InsertParagraphAfter()
        'Loop While Pos >= oRng.Information(Word.WdInformation.wdVerticalPositionRelativeToTextBoundary)

        Dim d1, d2 As Long
        Dim h, i, jb As Integer

        ' nparas=selection.paragraphs.count
        oWord.Selection.WholeStory()
        jb = oWord.Selection.Range.ComputeStatistics(Word.WdStatistic.wdStatisticLines)   'Count Number of lines

        oWord.Selection.HomeKey(Unit:=Word.WdUnits.wdStory)
        'menuju ke baris selanjutnya
        oWord.Selection.GoToNext(Word.WdGoToItem.wdGoToLine)
        oWord.Selection.GoToNext(Word.WdGoToItem.wdGoToLine)
        'lewati tanggal hari ini
        oWord.Selection.GoToNext(Word.WdGoToItem.wdGoToLine)
        oWord.Selection.GoToNext(Word.WdGoToItem.wdGoToLine)
        oWord.Selection.GoToNext(Word.WdGoToItem.wdGoToLine)

        For h = 1 To jb
            oWord.Selection.EndKey()
            oWord.Selection.Start = oWord.Selection.End - 1

            If oWord.Selection.Text = "#" Then
                oWord.Selection.Delete()
                oWord.Selection.MoveStart(Unit:=Word.WdUnits.wdCharacter, Count:=1)
                GoTo lewat
            ElseIf oWord.Selection.Text = "@" Then
                oWord.Selection.MoveEnd(Unit:=Word.WdUnits.wdCharacter, Count:=1)
                oWord.Selection.Delete()
                GoTo Usai
            End If

            oWord.Selection.Collapse(Direction:=Word.WdCollapseDirection.wdCollapseEnd)
            oWord.Selection.EndKey()
            d1 = oWord.Selection.Information(Word.WdInformation.wdHorizontalPositionRelativeToTextBoundary)
            d2 = d1
            For i = 1 To 200

                oWord.Selection.InsertAfter("-")
                oWord.Selection.Collapse(Direction:=Word.WdCollapseDirection.wdCollapseEnd)
                d1 = oWord.Selection.Information(Word.WdInformation.wdHorizontalPositionRelativeToTextBoundary)
                If d1 < d2 Then Exit For
                d2 = d1
            Next i
            oWord.Selection.TypeBackspace()
            oWord.Selection.MoveStart(Unit:=Word.WdUnits.wdCharacter, Count:=1)
lewat:
            oWord.StatusBar = "Processing Row " & h & " from " & jb & " Rows - By NMS"
        Next h
Usai:
        UI.usForm.CloseWaitDialog()
        MsgBox("Document has been created" & vbCr & "By NMS")

    End Sub

#End Region

#Region "Form Handle"

    Private Sub Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        prvSetIcon()
        prvFillForm()
    End Sub

    Private Sub ToolBar_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles ToolBar.ButtonClick
        If e.Button.Text = "Print" Then
            prvPrint()
        Else
            Me.Close()
        End If
    End Sub

    Private Sub btnSaksi1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaksi1.Click
        Dim frmDetail As New frmMstUser
        With frmDetail
            .pubIsLookUp = True
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
            If .pubIsLookUpGet Then
                cboTitleS1.Text = .pubLUDataRow("Title")
                txtNamaS1.Text = .pubLUDataRow("UserName")
                txtTempatLahirS1.Text = .pubLUDataRow("BirthPlace")
                txtTanggalLahirS1.Text = .pubLUDataRow("BirthDate")
                txtTanggalLahirS1.Text = .pubLUDataRow("BirthDateStr")
                txtWNS1.Text = "Warga Negara Indonesia"
                txtPekerjaanS1.Text = .pubLUDataRow("UserPosition")
                txtAlamatS1.Text = .pubLUDataRow("Address")
                txtJenisIDS1.Text = .pubLUDataRow("IDType")
                txtNOIDS1.Text = .pubLUDataRow("IDNumber")
            End If
        End With
    End Sub

    Private Sub btnSaksi2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaksi2.Click
        Dim frmDetail As New frmMstUser
        With frmDetail
            .pubIsLookUp = True
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
            If .pubIsLookUpGet Then
                cboTitleS2.Text = .pubLUDataRow("Title")
                txtNamaS2.Text = .pubLUDataRow("UserName")
                txtTempatLahirS2.Text = .pubLUDataRow("BirthPlace")
                txtTanggalLahirS2.Text = .pubLUDataRow("BirthDateStr")
                txtWNS2.Text = "Warga Negara Indonesia"
                txtPekerjaanS2.Text = .pubLUDataRow("UserPosition")
                txtAlamatS2.Text = .pubLUDataRow("Address")
                txtJenisIDS2.Text = .pubLUDataRow("IDType")
                txtNoIDS2.Text = .pubLUDataRow("IDNumber")
            End If
        End With
    End Sub

    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown, tbcPPAT.KeyDown, grdClient2.KeyDown, grdClient1.KeyDown
        If e.KeyCode = Keys.Escape Then
            If UI.usForm.frmAskQuestion("Close Notary Order Print?") Then Me.Close()
        ElseIf e.KeyCode = Keys.F1 Then
            Me.tbcPPAT.SelectedIndex = 0
        ElseIf e.KeyCode = Keys.F2 Then
            Me.tbcPPAT.SelectedIndex = 1
        ElseIf e.KeyCode = Keys.F3 Then
            Me.tbcPPAT.SelectedIndex = 2
        ElseIf e.KeyCode = Keys.F4 Then
            Me.tbcPPAT.SelectedIndex = 3
        ElseIf e.KeyCode = Keys.F5 Then
            Me.tbcPPAT.SelectedIndex = 4
        End If
    End Sub

#End Region

End Class
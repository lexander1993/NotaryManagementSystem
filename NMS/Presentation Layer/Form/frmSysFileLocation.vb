
Public Class frmSysFileLocation
#Region "Property"

    Private frmParentNotary As frmTraNotaryOrderDet
    Private frmParentPPAT As frmTraPPATOrderDet
    Private strPath As String = ""
    Private strFileName As String = ""
    Dim bmp As Bitmap

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

    Public Sub pubShowDialogNotary(ByVal frmGetParentNotary As Form)
        frmParentNotary = frmGetParentNotary
        Me.ShowDialog()
    End Sub

    Public Sub pubShowDialogPPAT(ByVal frmGetParentPPAT As Form)
        frmParentPPAT = frmGetParentPPAT
        Me.ShowDialog()
    End Sub

    Private Sub prvSetTitleForm()
        Me.Text += " " + strPath
    End Sub

    Private Sub prvSearch()
        With OpenFileDialog1
            .Filter = "Picture Files (*.BMP; *.GIF; *.JPG; *.JPEG)|*.BMP;*.GIF;*.JPG;*.JPEG|Bitmap Files (*.BMP)|*.BMP|GIF Files (*.GIF)|*.GIF|JPEG Files (*.JPG)|*.JPG|All FIles (*.*)|*.*"
            If Not OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.Cancel Then
                bmp = New Bitmap(.FileName)
                pbShow.Image = bmp
            End If
        End With
    End Sub

    Private Sub prvOpen()
        'With OpenFileDialog1
        '    '  .Filter = "Picture Files (*.BMP; *.GIF; *.JPG; *.JPEG)|*.BMP;*.GIF;*.JPG;*.JPEG|Bitmap Files (*.BMP)|*.BMP|GIF Files (*.GIF)|*.GIF|JPEG Files (*.JPG)|*.JPG|All FIles (*.*)|*.*"
        '    .Filter = "All FIles (*.*)|*.*"
        '    .Multiselect = True
        '    .InitialDirectory = strPath
        '    If Not OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.Cancel Then
        '        '    bmp = New Bitmap(.FileName)
        '        '    pbShow.Image = bmp
        '    End If
        'End With

        With OpenFileDialog1
            '  .Filter = "Picture Files (*.BMP; *.GIF; *.JPG; *.JPEG)|*.BMP;*.GIF;*.JPG;*.JPEG|Bitmap Files (*.BMP)|*.BMP|GIF Files (*.GIF)|*.GIF|JPEG Files (*.JPG)|*.JPG|All FIles (*.*)|*.*"
            .Filter = "All Files (*.*)|*.*"
            .Multiselect = True
            .InitialDirectory = strPath

            If Not OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.Cancel Then

                Using fileprocess As Process = Process.Start(OpenFileDialog1.FileName)
                    fileprocess.WaitForExit()
                End Using



            End If
        End With

    End Sub

    Private Sub prvSave()
        If Not UI.usForm.frmAskQuestion("Simpan gambar ke " & strPath & " ?") Then Exit Sub
        With SaveFileDialog1
            .Filter = "JPEG Files (*.JPG)|*.jpg"
            .InitialDirectory = strPath
            If Not SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.Cancel Then
                strFileName = SaveFileDialog1.FileName
                Try
                    bmp = Me.pbShow.Image
                    bmp.Save(strFileName)
                    UI.usForm.frmMessageBox("Gambar berhasil disimpan !")
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If
        End With
    End Sub

#End Region

#Region "Form Handle"

    Private Sub Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        prvSetTitleForm()
        pbOpen.SizeMode = PictureBoxSizeMode.StretchImage
        pbSave.SizeMode = PictureBoxSizeMode.StretchImage
        pbShow.SizeMode = PictureBoxSizeMode.StretchImage
    End Sub

    Private Sub pbOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbOpen.Click
        prvOpen()
    End Sub

    Private Sub pbSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbSave.Click
        prvSave()
    End Sub

   

#End Region



End Class
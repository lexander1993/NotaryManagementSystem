Public Class frmSysCaptureLocation
    Private strPath As String = "C:\Users\alexander.yen\Music\Playlists"

    Private Const _
       cBackup = 0, cRestore = 1, cClose = 2

    Private Sub prvSetIcon()
        UI.usForm.SetToolBar(Me, ToolBar, "0,Submit,1,Reject,2,Close")
    End Sub

    Private Sub prvBackUp()


        'If txtBackup.Text = "" Then
        '    UI.usForm.frmMessageBox("Tentukan Lokasi Backup yang dituju")
        '    txtBackup.Focus()
        '    Exit Sub
        'End If

        'If Not UI.usForm.frmAskQuestion("Backup database ? ") Then Exit Sub
        'BL.Server.ServerDefault()
        'Try
        '    strBackupPath = DL.Server.BackupDatabase(txtBackup.Text)
        '    UI.usForm.frmMessageBox("Backup database berhasil !" & vbCrLf & "File Path : " & strBackupPath)
        '    Me.Close()
        'Catch ex As Exception
        '    UI.usForm.frmMessageBox(ex.Message)
        'End Try

    End Sub

    Private Sub prvRestore()

        If txtRestore.Text = "" Then
            UI.usForm.frmMessageBox("Pilih File *.bak utk Restore Database")
            txtRestore.Focus()
            Exit Sub
        End If

        If Not UI.usForm.frmAskQuestion("Apakah anda yakin merestore database ?") Then Exit Sub
        Try
            DL.Server.RestoreDatabase(txtRestore.Text)
            UI.usForm.frmMessageBox("Restore database berhasil ! Aplikasi akan direstart")
            Me.Close()
            Application.Restart()
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try
    End Sub


#Region "Form Handle"

    Private Sub Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtBackup.CharacterCasing = CharacterCasing.Normal
        txtRestore.CharacterCasing = CharacterCasing.Normal
        txtBackup.Text = "D:\BackupDB\NMS\"
        cbType.SelectedIndex = 1
        prvSetIcon()
        PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage


        ' Button1.Text = "Browse"

        'With OpenFileDialog1
        '    .Filter = "Office Documents " & _
        '    "(*.doc, *.xls, *.ppt)|*.doc;*.xls;*.ppt"
        '    .FilterIndex = 1
        'End With

        With OpenFileDialog1
            .Filter = "Picture " & _
            "(*.jpg, *.jpeg, *.gif)|*.jpg;*.jpeg;*.gif"
            .FilterIndex = 1
        End With

    End Sub

    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If UI.usForm.frmAskQuestion("Close This Form ?") Then Me.Close()
        End If
    End Sub

    Private Sub ToolBar_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles ToolBar.ButtonClick
        If e.Button.Text = "Backup" Then
            prvBackUp()
        ElseIf e.Button.Text = "Restore" Then
            prvRestore()
        Else
            Me.Close()
        End If
    End Sub

    Private Sub btnRestore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRestore.Click
        Dim PathFile As String = Nothing
        OpenFileDialog1.Filter = "|*.jpg"
        OpenFileDialog1.FileName = ""
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            PathFile = OpenFileDialog1.FileName 'nama path lengkap
            ' txtRestore.Text = PathFile
            ' txtRestore.Text = PathFile.Substring(PathFile.LastIndexOf("\") + 1)
            txtRestore.Text = PathFile.Substring(0, PathFile.LastIndexOf("\"))

        End If

        ' txtRestore.Text = OpenFileDialog1.SafeFileName fungsi utk menampilkan nama file saja
    End Sub

#End Region

    Private Sub cbType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbType.SelectedIndexChanged
        If cbType.SelectedIndex = 0 Then
            PanelBackup.Visible = True
            PanelRestore.Visible = False
            With ToolBar.Buttons
                .Item(cBackup).Enabled = True
                .Item(cRestore).Enabled = False
            End With
        Else
            PanelBackup.Visible = False
            PanelRestore.Visible = True
            With ToolBar.Buttons
                .Item(cBackup).Enabled = False
                .Item(cRestore).Enabled = True
            End With
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim oDocument As Object
        Dim strFileName As String

        'cek jika location not exist message box
        With OpenFileDialog1
            .FileName = ""
            .CheckPathExists.Equals(strPath)
            .InitialDirectory = strPath
            .ShowDialog()
            strFileName = .FileName
        End With

        'If the user does not cancel, open the document.
        If strFileName.Length Then
            oDocument = Nothing
            WebBrowser1.Navigate(strFileName)
        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim sPath As String = "D:\NMS Data\"
        Dim bmp As Bitmap

        SaveFileDialog1.Filter = "Bitmap image (*.bmp)|*.bmp"
        SaveFileDialog1.ShowDialog()
        sPath = SaveFileDialog1.FileName

        Try
            bmp = Me.PictureBox1.Image
            bmp.Save(sPath)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpen.Click
        Dim bmp As Bitmap
        With OpenFileDialog1
            .Filter = "Picture Files (*.BMP; *.GIF; *.JPG)|*.BMP;*.GIF;*.JPG|Bitmap Files (*.BMP)|*.BMP|GIF Files (*.GIF)|*.GIF|JPEG Files (*.JPG)|*.JPG|All FIles (*.*)|*.*"
            .ShowDialog()
            bmp = New Bitmap(.FileName)
            PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
            PictureBox1.Image = bmp
        End With
    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        MkDir (“D:\Agus”)
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click

    End Sub
End Class
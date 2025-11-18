Public Class frmSysBackupRestore
    Private strBackupPath As String

    Private Const _
       cBackup = 0, cRestore = 1, cClose = 2

    Private Sub prvSetIcon()
        UI.usForm.SetToolBar(Me, ToolBar, "0,Submit,1,Reject,2,Close")
    End Sub

    Private Sub prvBackUp()

        If txtBackup.Text = "" Then
            UI.usForm.frmMessageBox("Tentukan Lokasi Backup yang dituju")
            txtBackup.Focus()
            Exit Sub
        End If

        If Not UI.usForm.frmAskQuestion("Backup database ? ") Then Exit Sub
        BL.Server.ServerDefault()
        Try
            strBackupPath = DL.Server.BackupDatabase(txtBackup.Text)
            UI.usForm.frmMessageBox("Backup database berhasil !" & vbCrLf & "File Path : " & strBackupPath)
            Me.Close()
        Catch ex As Exception
            UI.usForm.frmMessageBox(ex.Message)
        End Try

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
        txtBackup.Text = UI.usUserApp.BackupLocation             '"D:\BackupDB\NMS\"
        cbType.SelectedIndex = 0
        prvSetIcon()
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
        OpenFileDialog1.Filter = "|*.bak"
        OpenFileDialog1.FileName = ""
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            PathFile = OpenFileDialog1.FileName 'nama path lengkap
            txtRestore.Text = PathFile
            ' txtRestore.Text = PathFile.Substring(PathFile.LastIndexOf("\") + 1)
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
End Class
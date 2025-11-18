Public Class frmSysExportFileBPN

    Private Const _
        cPreview = 0, cClose = 1

    Private Sub prvSetIcon()
        UI.usForm.SetToolBar(Me, ToolBar, "0,Submit,1,Close")
    End Sub

    Private Sub frmSysExportFileBPN_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        prvSetIcon()
        dtpDateFrom.Value = Today.Year & "/" & Today.Month & "/" & "01 23:59:59"
        dtpDateTo.Value = dtpDateFrom.Value.AddMonths(1).AddDays(-1)
    End Sub

    Private Sub ToolBar_ButtonClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles ToolBar.ButtonClick
        Select Case e.Button.Text.Trim
            Case "Export" : Me.Export()
            Case "Close" : Me.Close()
        End Select
    End Sub

    Private Sub Export()
        Dim ExportFileBPNNotaris, ExportFileBPNPPAT As DataTable
        Dim ExportFileBPNLocationNotaris, ExportFileBPNLocationPPAT, NoAkta As String
        Dim SubFolder(), Files(), EmptyFolderMsg As String
        ExportFileBPNLocationNotaris = UI.usUserApp.ExportFileLocation & dtpDateFrom.Value.ToString("yyyyMMdd") & "-" & dtpDateTo.Value.ToString("yyyyMMdd") & "\Notaris\"
        ExportFileBPNLocationPPAT = UI.usUserApp.ExportFileLocation & dtpDateFrom.Value.ToString("yyyyMMdd") & "-" & dtpDateTo.Value.ToString("yyyyMMdd") & "\PPAT\"

        ExportFileBPNNotaris = DL.NotaryOrder.ListData(dtpDateFrom.Value, dtpDateTo.Value, 2, True)
        ExportFileBPNPPAT = DL.PPATOrder.ListData(dtpDateFrom.Value, dtpDateTo.Value, 2, "", True)

        EmptyFolderMsg = ""
        Try
            For Each drData As DataRow In ExportFileBPNNotaris.Rows
                SubFolder = System.IO.Directory.GetDirectories(UI.usUserApp.FileLocation & drData.Item("NotaryOrderID"))
                Files = System.IO.Directory.GetFiles(UI.usUserApp.FileLocation & drData.Item("NotaryOrderID"))
                If SubFolder.Length = 0 And Files.Length = 0 Then
                    EmptyFolderMsg += drData.Item("NoUrut") & "-" & drData.Item("NoBulanan") & vbCrLf
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            For Each drData As DataRow In ExportFileBPNPPAT.Rows
                SubFolder = System.IO.Directory.GetDirectories(UI.usUserApp.FileLocation & drData.Item("PPATOrderID"))
                Files = System.IO.Directory.GetFiles(UI.usUserApp.FileLocation & drData.Item("PPATOrderID"))
                If SubFolder.Length = 0 And Files.Length = 0 Then
                    NoAkta = Replace(drData.Item("NoAkta"), "/", "-")
                    EmptyFolderMsg += NoAkta & vbCrLf
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        If EmptyFolderMsg <> "" Then
            UI.usForm.frmMessageBox("Failed Export File BPN. Please scan :" & vbCrLf & EmptyFolderMsg)
            Exit Sub
        End If

        UI.usForm.CreateWaitDialog()

        'Notary
        Try
            MkDir(ExportFileBPNLocationNotaris)
        Catch ex As Exception
            System.IO.Directory.Delete(ExportFileBPNLocationNotaris, True)
            MkDir(ExportFileBPNLocationNotaris)
        End Try

        Try
            For Each drData As DataRow In ExportFileBPNNotaris.Rows
                MkDir(ExportFileBPNLocationNotaris & "\" & drData.Item("NoUrut") & "-" & drData.Item("NoBulanan") & "\")
                My.Computer.FileSystem.CopyDirectory(UI.usUserApp.FileLocation & drData.Item("NotaryOrderID") & "\", ExportFileBPNLocationNotaris & drData.Item("NoUrut") & "-" & drData.Item("NoBulanan") & "\")
            Next
        Catch ex As Exception
            UI.usForm.frmMessageBox("Cek kembali No Urut dan No Bulanan yg sama")
        End Try

        'PPAT
        Try
            MkDir(ExportFileBPNLocationPPAT)
        Catch ex As Exception
            System.IO.Directory.Delete(ExportFileBPNLocationPPAT, True)
            MkDir(ExportFileBPNLocationPPAT)
        End Try

        Try
            For Each drData As DataRow In ExportFileBPNPPAT.Rows
                NoAkta = Replace(drData.Item("NoAkta"), "/", "-")
                MkDir(ExportFileBPNLocationPPAT & "\" & NoAkta & "\")
                My.Computer.FileSystem.CopyDirectory(UI.usUserApp.FileLocation & drData.Item("PPATOrderID") & "\", ExportFileBPNLocationPPAT & NoAkta & "\")
            Next
        Catch ex As Exception
            UI.usForm.frmMessageBox("Cek kembali No Akta PPAT yang sama")
        End Try
        UI.usForm.CloseWaitDialog()
        UI.usForm.frmMessageBox("Export File BPN have been finished")
    End Sub

End Class
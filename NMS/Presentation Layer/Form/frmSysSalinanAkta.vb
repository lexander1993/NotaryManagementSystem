Imports Word = Microsoft.Office.Interop.Word

Public Class frmSysSalinanAkta

    Private oWord As Word.Application
    Private oDoc As Word.Document
    Private PathFile As String = Nothing

    Private Sub prvOpen()
        '   Dim PathFile As String = Nothing
        OpenFileDialog1.Filter = "Document (*.doc; *.docx)|*.doc;*.docx|All FIles (*.*)|*.*"
        OpenFileDialog1.FileName = ""
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            PathFile = OpenFileDialog1.FileName 'nama path lengkap
            txtPrintOutLocation.Text = PathFile

            If Not UI.usForm.frmAskQuestion("Buat Salinan Akta dari lokasi file " & PathFile & " ?") Then Exit Sub
            UI.usForm.CreateWaitDialog()
            oWord = CreateObject("Word.Application")
            oWord.Visible = True
            oDoc = oWord.Documents.Add(txtPrintOutLocation.Text)
            GarisPinggir()
            UI.usForm.CloseWaitDialog()
            UI.usForm.frmMessageBox("Salinan Akta selesai")

            'If Not UI.usForm.frmAskQuestion("Periksa Salinan Akta Anda di Ms. Word. " & vbCrLf & "Apakah anda ingin langsung print duplex Salinan Akta?") Then Exit Sub
            'PrintDuplex()
        End If
    End Sub

    Private Sub GarisPinggir()
        'oWord.Run("GarisPinggir")  untuk run module yg dibuat di word
        oWord.Selection.WholeStory()
        With oWord.Selection.ParagraphFormat
            With .Borders(Word.WdBorderType.wdBorderLeft)
                .LineStyle = Word.WdLineStyle.wdLineStyleSingle
                .LineWidth = Word.WdLineWidth.wdLineWidth050pt
                .Color = Word.WdColor.wdColorAutomatic
            End With
            .Borders(Word.WdBorderType.wdBorderRight).LineStyle = Word.WdLineStyle.wdLineStyleNone
            .Borders(Word.WdBorderType.wdBorderTop).LineStyle = Word.WdLineStyle.wdLineStyleNone
            .Borders(Word.WdBorderType.wdBorderBottom).LineStyle = Word.WdLineStyle.wdLineStyleNone
            .Borders(Word.WdBorderType.wdBorderHorizontal).LineStyle = Word.WdLineStyle.wdLineStyleNone
            With .Borders
                .DistanceFromTop = 1
                .DistanceFromLeft = 4
                .DistanceFromBottom = 1
                .DistanceFromRight = 4
                .Shadow = False
            End With
        End With

        oWord.Selection.HomeKey(Unit:=Word.WdUnits.wdStory)
        oWord.Selection.GoToNext(Word.WdGoToItem.wdGoToLine)
        oWord.Selection.EndKey()
        oWord.Selection.MoveUp(Unit:=Word.WdUnits.wdLine, Count:=2, Extend:=Word.WdMovementType.wdExtend)
        With oWord.Selection.ParagraphFormat
            .Borders(Word.WdBorderType.wdBorderLeft).LineStyle = Word.WdLineStyle.wdLineStyleNone
            .Borders(Word.WdBorderType.wdBorderRight).LineStyle = Word.WdLineStyle.wdLineStyleNone
            .Borders(Word.WdBorderType.wdBorderTop).LineStyle = Word.WdLineStyle.wdLineStyleNone
            .Borders(Word.WdBorderType.wdBorderBottom).LineStyle = Word.WdLineStyle.wdLineStyleNone
            .Borders(Word.WdBorderType.wdBorderHorizontal).LineStyle = Word.WdLineStyle.wdLineStyleNone
            With .Borders
                .DistanceFromTop = 1
                .DistanceFromLeft = 4
                .DistanceFromBottom = 1
                .DistanceFromRight = 4
                .Shadow = False
            End With
        End With

        Dim y As Double
        Dim jb As Integer

        '''''''garis pinggir horizontal
        'ActiveDocument.Shapes.AddLine(titik1x, titik1Y,titik1x, titik2y).Select

        'Halaman Awal
        oWord.ActiveDocument.Shapes.AddLine(130, 153.0#, 200, 153).Select()
        oWord.ActiveDocument.Shapes.AddLine(130, 156.0#, 200, 156).Select()
        'titik utk hal 1 bawah
        'oWord.ActiveDocument.Shapes.AddLine(130, 735.0#, 200, 735).Select()
        'oWord.ActiveDocument.Shapes.AddLine(130, 738.0#, 200, 738).Select()

        oWord.ActiveDocument.Bookmarks("\page").Range.Select()
        oWord.Selection.EndKey()
        oWord.Selection.HomeKey()
        y = oWord.Selection.Range.Information(Word.WdInformation.wdVerticalPositionRelativeToPage) + 20
        oWord.ActiveDocument.Shapes.AddLine(130, y, 200, y).Select()
        'oWord.ActiveDocument.Shapes.AddLine(130, y + 3, 200, y + 3).Select()

        'oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToPage, Which:=Word.WdGoToDirection.wdGoToNext)
        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToPage, Which:=Word.WdGoToDirection.wdGoToAbsolute, Count:=(2))

        'Current Page: y = Selection.Information(wdActiveEndPageNumber)
        Dim Total = oWord.Selection.Information(Word.WdInformation.wdNumberOfPagesInDocument) - 1

        For i = 1 To Total - 1
            ' oWord.ActiveDocument.Shapes.AddLine(130, 112.0#, 200, 112).Select()
            oWord.ActiveDocument.Shapes.AddLine(130, 115.0#, 200, 115).Select()

            'oWord.ActiveDocument.Bookmarks("\page").Range.Select()
            'oWord.Selection.EndKey()
            'oWord.Selection.HomeKey()

            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToPage, Which:=Word.WdGoToDirection.wdGoToAbsolute, Count:=(i + 2))
            oWord.Selection.MoveUp(Unit:=Word.WdUnits.wdLine, Count:=1)
            jb = oWord.Selection.Information(Word.WdInformation.wdFirstCharacterLineNumber)
            y = oWord.Selection.Range.Information(Word.WdInformation.wdVerticalPositionRelativeToPage) + 20
            If y < 140 Then
                If jb = 30 Then
                    y += 599.25   'Jika Ms Office 2007 harus ditambah karena ada bug 
                ElseIf jb = 29 Then
                    y += 579.75
                ElseIf jb = 28 Then
                    y += 560.25
                End If
            End If

            'If y < 140 Then
            '    Dim baris As Integer
            '    baris = 30 - jb
            '    y = y + 599.25 - (baris * 19.5)  'Jika Ms Office 2007 harus ditambah karena ada bug 
            'End If
            oWord.ActiveDocument.Shapes.AddLine(130, y, 200, y).Select()
            ' oWord.ActiveDocument.Shapes.AddLine(130, y + 3, 200, y + 3).Select()

            ' oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToPage, Which:=Word.WdGoToDirection.wdGoToNext)
            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToPage, Which:=Word.WdGoToDirection.wdGoToAbsolute, Count:=(i + 2))
        Next i

        'Halaman terakhir
        oWord.ActiveDocument.Shapes.AddLine(130, 115.0#, 200, 115).Select()

        oWord.ActiveDocument.Bookmarks("\page").Range.Select()
        oWord.Selection.EndKey()
        oWord.Selection.HomeKey()
        jb = oWord.Selection.Information(Word.WdInformation.wdFirstCharacterLineNumber)
        y = oWord.Selection.Range.Information(Word.WdInformation.wdVerticalPositionRelativeToPage) + 20

        If y < 140 Then
            Dim baris As Integer
            baris = 30 - jb
            y = y + 599.25 - ((baris + 1) * 19.5)  'Jika Ms Office 2007 harus ditambah karena ada bug 
        End If

        oWord.ActiveDocument.Shapes.AddLine(130, y, 200, y).Select()
        oWord.ActiveDocument.Shapes.AddLine(130, y + 3, 200, y + 3).Select()
        oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToPage, Which:=Word.WdGoToDirection.wdGoToNext)

        oWord.Selection.HomeKey(Unit:=Word.WdUnits.wdStory)

        'oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToPage, Which:=Word.WdGoToDirection.wdGoToNext)
        ''Titik utk hal 2 atas
        'oWord.ActiveDocument.Shapes.AddLine(130, 112.0#, 200, 112).Select()
        'oWord.ActiveDocument.Shapes.AddLine(130, 115.0#, 200, 115).Select()

        ''titik utk hal 2 bawah
        'oWord.ActiveDocument.Shapes.AddLine(130, 735.0#, 200, 735).Select()
        'oWord.ActiveDocument.Shapes.AddLine(130, 738.0#, 200, 738).Select()

        'oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToPage, Which:=Word.WdGoToDirection.wdGoToNext)


    End Sub

    Private Sub PrintDuplex()
        oWord.Application.PrintOut(FileName:="", Range:=Word.WdPrintOutRange.wdPrintAllDocument, Item:= _
               Word.WdPrintOutItem.wdPrintDocumentContent, Copies:=1, Pages:="", PageType:=Word.WdPrintOutPages.wdPrintAllPages, _
               ManualDuplexPrint:=False, Collate:=True, Background:=True, PrintToFile:= _
               False, PrintZoomColumn:=2, PrintZoomRow:=1, PrintZoomPaperWidth:=0, _
               PrintZoomPaperHeight:=0)
    End Sub

    Private Sub pbSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbSearch.Click
        prvOpen()
    End Sub

    'Private Sub btnPrintDuplex_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintDuplex.Click
    '    OpenFileDialog1.Filter = "Document (*.doc; *.docx)|*.doc;*.docx|All Files (*.*)|*.*"
    '    OpenFileDialog1.FileName = ""
    '    If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
    '        PathFile = OpenFileDialog1.FileName 'nama path lengkap
    '        txtPrintOutLocation.Text = PathFile

    '        If Not UI.usForm.frmAskQuestion("Print Duplex Salinan Akta dari lokasi file " & PathFile & " ?") Then Exit Sub
    '        UI.usForm.CreateWaitDialog()
    '        oWord = CreateObject("Word.Application")
    '        oWord.Visible = True
    '        oDoc = oWord.Documents.Add(txtPrintOutLocation.Text)
    '        PrintDuplex()
    '        UI.usForm.CloseWaitDialog()
    '        UI.usForm.frmMessageBox("Print Akta selesai")

    '    End If
    'End Sub


    Private Sub btn30lines_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn30lines.Click
        OpenFileDialog1.Filter = "Document (*.doc; *.docx)|*.doc;*.docx|All FIles (*.*)|*.*"
        OpenFileDialog1.FileName = ""
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            PathFile = OpenFileDialog1.FileName 'nama path lengkap
            txtPrintOutLocation.Text = PathFile

            If Not UI.usForm.frmAskQuestion("Set Akta 30 baris dari lokasi file " & PathFile & " ?") Then Exit Sub
            UI.usForm.CreateWaitDialog()
            oWord = CreateObject("Word.Application")
            oWord.Visible = True
            oDoc = oWord.Documents.Open(txtPrintOutLocation.Text)
            ThirtyLine()
            UI.usForm.CloseWaitDialog()
            UI.usForm.frmMessageBox("Set Akta 30 baris selesai")
        End If

    End Sub

    Public Sub ThirtyLine()
        Dim jb, Total As Integer

        oWord.Selection.HomeKey(Unit:=Word.WdUnits.wdStory)

        Total = oWord.Selection.Information(Word.WdInformation.wdNumberOfPagesInDocument) - 1
        For i = 1 To Total
            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToPage, Which:=Word.WdGoToDirection.wdGoToAbsolute, Count:=(i + 1))
            oWord.Selection.MoveUp(Unit:=Word.WdUnits.wdLine, Count:=1)
            '  oWord.Selection.Bookmarks("\page").Range.Select()
            ' jb = oWord.Selection.Range.ComputeStatistics(Word.WdStatistic.wdStatisticLines)
            jb = oWord.Selection.Information(Word.WdInformation.wdFirstCharacterLineNumber)
            oWord.Selection.GoTo(What:=Word.WdGoToItem.wdGoToPage, Which:=Word.WdGoToDirection.wdGoToAbsolute, Count:=(i + 1))

            If jb < 30 Then
                oWord.Selection.MoveDown(Unit:=Word.WdUnits.wdLine, Count:=1)
                oWord.Selection.TypeParagraph()
            End If
            oWord.Selection.MoveDown(Unit:=Word.WdUnits.wdLine, Count:=1)
        Next i

        oWord.Selection.HomeKey(Unit:=Word.WdUnits.wdStory)
    End Sub

    Private Sub btnSalinanAkta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalinanAkta.Click
        prvOpen()
    End Sub

    Private Sub btnCekDirektory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCekDirektory.Click
        Dim SubFolder(), Files() As String
        SubFolder = System.IO.Directory.GetDirectories(txtCekDirektori.Text)
        Files = System.IO.Directory.GetFiles(txtCekDirektori.Text)

        If SubFolder.Length = 0 And Files.Length = 0 Then
            MsgBox("EMPTY")
        Else
            MsgBox("NOT EMPTY")
        End If
    End Sub

   
End Class
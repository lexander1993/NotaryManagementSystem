Imports System.Data
Imports System.Data.SqlClient
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Data.OleDb
Imports System.Configuration
Imports Outlook = Microsoft.Office.Interop.Outlook
Imports System.Runtime.InteropServices

Imports System.Net.Mail
Imports System.Net.Mime

Public Class frmSysExportImport

    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'If Not UI.usForm.frmAskQuestion("Export data dari tanggal " & dtpDateFrom.Value.ToString("dd-MM-yyyy") & " s/d " & dtpDateTo.Value.ToString("dd-MM-yyyy") & " ?") Then Exit Sub
        'Try
        '    Dim i, j As Integer
        '    'Excel WorkBook object 
        '    Dim xlApp As Microsoft.Office.Interop.Excel.Application
        '    Dim xlWorkBook As Microsoft.Office.Interop.Excel.Workbook
        '    Dim xlWorkSheet As Microsoft.Office.Interop.Excel.Worksheet
        '    Dim misValue As Object = System.Reflection.Missing.Value
        '    'xlApp = New Microsoft.Office.Interop.Excel.ApplicationClass
        '    xlWorkBook = xlApp.Workbooks.Add(misValue)

        '    ' Sheet Name or Number

        '    Dim xlWorkSheetNO, xlWorkSheetNOC1, xlWorkSheetNOC2, xlWorkSheetNOC3 As Excel.Worksheet
        '    Dim xlWorkSheetPO, xlWorkSheetPOC1, xlWorkSheetPOC2 As Excel.Worksheet

        '    xlWorkSheetNO = xlWorkBook.Worksheets.Add()
        '    xlWorkSheetNOC1 = xlWorkBook.Worksheets.Add()
        '    xlWorkSheetNOC2 = xlWorkBook.Worksheets.Add()
        '    xlWorkSheetNOC3 = xlWorkBook.Worksheets.Add()
        '    xlWorkSheetPO = xlWorkBook.Worksheets.Add()
        '    xlWorkSheetPOC1 = xlWorkBook.Worksheets.Add()
        '    xlWorkSheetPOC2 = xlWorkBook.Worksheets.Add()

        '    xlWorkSheetNO.Name = "NotaryOrder"
        '    xlWorkSheetNOC1.Name = "NotaryOrderClient1"
        '    xlWorkSheetNOC2.Name = "NotaryOrderClient2"
        '    xlWorkSheetNOC3.Name = "NotaryOrderClient3"
        '    xlWorkSheetPO.Name = "PPATOrder"
        '    xlWorkSheetPOC1.Name = "PPATOrderClient1"
        '    xlWorkSheetPOC2.Name = "PPATOrderClient2"

        '    xlWorkBook.Worksheets("Sheet1").Delete()
        '    xlWorkBook.Worksheets("Sheet2").Delete()
        '    xlWorkBook.Worksheets("Sheet3").Delete()

        '    Try
        '        'NotaryOrder
        '        xlWorkSheet = xlWorkBook.Sheets("NotaryOrder")
        '        Dim ds As New DataSet
        '        ds = DL.ExportImport.ListNotaryOrder(dtpDateFrom.Value, dtpDateTo.Value)
        '        'COLUMN NAME ADD IN EXCEL SHEET OR HEADING MUST 2 CELLS
        '        xlWorkSheet.Cells(1, 1).Value = "EXPORT DATA FROM "
        '        xlWorkSheet.Cells(1, 2).Value = dtpDateFrom.Value.ToString("yyyyMMdd") & "-" & dtpDateTo.Value.ToString("yyyyMMdd")

        '        ' SQL Table Transfer to Excel
        '        For i = 0 To ds.Tables(0).Rows.Count - 1
        '            'Column
        '            For j = 0 To ds.Tables(0).Columns.Count - 1
        '                ' this i change to header line cells >>>
        '                xlWorkSheet.Cells(i + 2, j + 1) = _
        '                ds.Tables(0).Rows(i).Item(j)
        '            Next
        '        Next

        '        'NotaryOrderClient1
        '        xlWorkSheet = xlWorkBook.Sheets("NotaryOrderClient1")

        '        ds = DL.ExportImport.ListNotaryOrderClient1(dtpDateFrom.Value, dtpDateTo.Value)
        '        xlWorkSheet.Cells(1, 1).Value = "EXPORT DATA FROM "
        '        xlWorkSheet.Cells(1, 2).Value = dtpDateFrom.Value.ToString("yyyyMMdd") & "-" & dtpDateTo.Value.ToString("yyyyMMdd")
        '        For i = 0 To ds.Tables(0).Rows.Count - 1
        '            For j = 0 To ds.Tables(0).Columns.Count - 1
        '                xlWorkSheet.Cells(i + 2, j + 1) = _
        '                ds.Tables(0).Rows(i).Item(j)
        '            Next
        '        Next

        '        'NotaryOrderClient2
        '        xlWorkSheet = xlWorkBook.Sheets("NotaryOrderClient2")

        '        ds = DL.ExportImport.ListNotaryOrderClient2(dtpDateFrom.Value, dtpDateTo.Value)
        '        xlWorkSheet.Cells(1, 1).Value = "EXPORT DATA FROM "
        '        xlWorkSheet.Cells(1, 2).Value = dtpDateFrom.Value.ToString("yyyyMMdd") & "-" & dtpDateTo.Value.ToString("yyyyMMdd")
        '        For i = 0 To ds.Tables(0).Rows.Count - 1
        '            For j = 0 To ds.Tables(0).Columns.Count - 1
        '                xlWorkSheet.Cells(i + 2, j + 1) = _
        '                ds.Tables(0).Rows(i).Item(j)
        '            Next
        '        Next

        '        'NotaryOrderClient3
        '        xlWorkSheet = xlWorkBook.Sheets("NotaryOrderClient3")

        '        ds = DL.ExportImport.ListNotaryOrderClient3(dtpDateFrom.Value, dtpDateTo.Value)
        '        xlWorkSheet.Cells(1, 1).Value = "EXPORT DATA FROM "
        '        xlWorkSheet.Cells(1, 2).Value = dtpDateFrom.Value.ToString("yyyyMMdd") & "-" & dtpDateTo.Value.ToString("yyyyMMdd")

        '        For i = 0 To ds.Tables(0).Rows.Count - 1
        '            For j = 0 To ds.Tables(0).Columns.Count - 1
        '                xlWorkSheet.Cells(i + 2, j + 1) = _
        '                ds.Tables(0).Rows(i).Item(j)
        '            Next
        '        Next

        '        'PPATOrder
        '        xlWorkSheet = xlWorkBook.Sheets("PPATOrder")
        '        ds = DL.ExportImport.PPATOrder(dtpDateFrom.Value, dtpDateTo.Value)
        '        'COLUMN NAME ADD IN EXCEL SHEET OR HEADING 
        '        xlWorkSheet.Cells(1, 1).Value = "EXPORT DATA FROM "
        '        xlWorkSheet.Cells(1, 2).Value = dtpDateFrom.Value.ToString("yyyyMMdd") & "-" & dtpDateTo.Value.ToString("yyyyMMdd")
        '        ' SQL Table Transfer to Excel
        '        For i = 0 To ds.Tables(0).Rows.Count - 1
        '            'Column
        '            For j = 0 To ds.Tables(0).Columns.Count - 1
        '                ' this i change to header line cells >>>
        '                xlWorkSheet.Cells(i + 2, j + 1) = _
        '                ds.Tables(0).Rows(i).Item(j)
        '            Next
        '        Next

        '        'PPATOrderClient1
        '        xlWorkSheet = xlWorkBook.Sheets("PPATOrderClient1")

        '        ds = DL.ExportImport.ListPPATOrderClient1(dtpDateFrom.Value, dtpDateTo.Value)
        '        xlWorkSheet.Cells(1, 1).Value = "EXPORT DATA FROM "
        '        xlWorkSheet.Cells(1, 2).Value = dtpDateFrom.Value.ToString("yyyyMMdd") & "-" & dtpDateTo.Value.ToString("yyyyMMdd")
        '        For i = 0 To ds.Tables(0).Rows.Count - 1
        '            For j = 0 To ds.Tables(0).Columns.Count - 1
        '                xlWorkSheet.Cells(i + 2, j + 1) = _
        '                ds.Tables(0).Rows(i).Item(j)
        '            Next
        '        Next

        '        'PPATOrderClient2
        '        xlWorkSheet = xlWorkBook.Sheets("PPATOrderClient2")

        '        ds = DL.ExportImport.ListPPATOrderClient2(dtpDateFrom.Value, dtpDateTo.Value)
        '        xlWorkSheet.Cells(1, 1).Value = "EXPORT DATA FROM "
        '        xlWorkSheet.Cells(1, 2).Value = dtpDateFrom.Value.ToString("yyyyMMdd") & "-" & dtpDateTo.Value.ToString("yyyyMMdd")
        '        For i = 0 To ds.Tables(0).Rows.Count - 1
        '            For j = 0 To ds.Tables(0).Columns.Count - 1
        '                xlWorkSheet.Cells(i + 2, j + 1) = _
        '                ds.Tables(0).Rows(i).Item(j)
        '            Next
        '        Next


        '        ' Save as path of excel sheet
        '        xlWorkSheet.SaveAs(UI.usUserApp.ExportLocation & dtpDateFrom.Value.ToString("yyyyMMdd") & "-" & dtpDateTo.Value.ToString("yyyyMMdd") & ".xls")
        '        xlWorkBook.Close()
        '        xlApp.Quit()
        '        releaseObject(xlApp)
        '        releaseObject(xlWorkBook)
        '        releaseObject(xlWorkSheet)

        '        UI.usForm.frmMessageBox("File export data tersimpan di " & UI.usUserApp.ExportLocation & dtpDateFrom.Value.ToString("yyyyMMdd") & "-" & dtpDateTo.Value.ToString("yyyyMMdd") & ".xls")
        '    Catch ex As Exception
        '        UI.usForm.frmMessageBox(ex.Message)
        '    End Try
        'Catch ex As Exception
        '    UI.usForm.frmMessageBox(ex.Message)
        'End Try
    End Sub

    Private Sub btnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImport.Click

        Dim MyConnection As System.Data.OleDb.OleDbConnection
        Dim DtSet As System.Data.DataSet
        Dim MyCommand As System.Data.OleDb.OleDbDataAdapter

        Dim fBrowse As New OpenFileDialog
        With fBrowse
            .Filter = "Excel files(*.xls)|*.xls|All files (*.*)|*.*"
            .FilterIndex = 1
            .Title = "Import data from Excel file"
        End With

        If fBrowse.ShowDialog() = Windows.Forms.DialogResult.OK Then

            Dim fname As String
            fname = fBrowse.FileName

            If Not UI.usForm.frmAskQuestion("Apakah anda yakin import data dari " & fname) Then Exit Sub

            MyConnection = New System.Data.OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source='" & fname & " '; " & "Extended Properties=Excel 8.0;")

            MyCommand = New System.Data.OleDb.OleDbDataAdapter("select * from [NotaryOrder$]", MyConnection)
            MyCommand.TableMappings.Add("Table", "Test")
            DtSet = New System.Data.DataSet
            MyCommand.Fill(DtSet)
            MyConnection.Close()

            Dim intPos As Integer = 0
            Dim clsNotaryOrder As VO.NotaryOrder
            Dim clsDataAllNotaryOrder() As VO.NotaryOrder
            ReDim clsDataAllNotaryOrder(DtSet.Tables(0).Rows.Count - 1)


            For Each Drr As DataRow In DtSet.Tables(0).Rows
                clsNotaryOrder = New VO.NotaryOrder
                clsNotaryOrder.NotaryOrderID = Drr(0).ToString
                clsNotaryOrder.NoUrut = Drr(1).ToString
                clsNotaryOrder.NoBulanan = Drr(2).ToString
                clsNotaryOrder.TglAkta = Drr(3).ToString
                clsNotaryOrder.SifatAkta = Drr(4).ToString
                clsNotaryOrder.JenisTransaksi = Drr(5).ToString
                clsNotaryOrder.Status = Drr(6).ToString
                clsNotaryOrder.FileLocation = Drr(7).ToString
                clsNotaryOrder.Remarks = Drr(8).ToString
                clsNotaryOrder.DraftBy = Drr(9).ToString
                clsNotaryOrder.DraftDate = Drr(10).ToString
                clsNotaryOrder.ProcessBy = Drr(11).ToString
                clsNotaryOrder.ProcessDate = Drr(12).ToString
                clsNotaryOrder.ProcessRemarks = Drr(13).ToString
                clsNotaryOrder.CompletedBy = Drr(14).ToString
                clsNotaryOrder.CompletedDate = Drr(15).ToString
                clsNotaryOrder.CompletedRemarks = Drr(16).ToString
                clsNotaryOrder.IsFalse = Drr(17).ToString
                clsNotaryOrder.IsFalseBy = Drr(18).ToString
                clsNotaryOrder.IsFalseDate = Drr(19).ToString
                clsNotaryOrder.IsFalseRemarks = Drr(20).ToString
                clsNotaryOrder.ModifiedBy = Drr(21).ToString
                clsNotaryOrder.ModifiedDate = Drr(22).ToString
                clsNotaryOrder.TglDidaftarkan = Drr(23).ToString
                clsNotaryOrder.JenisAkta = Drr(24).ToString
                clsNotaryOrder.IsFalseLevel = Drr(25).ToString
                clsDataAllNotaryOrder(intPos) = clsNotaryOrder
                intPos += 1
            Next

            MyCommand = New System.Data.OleDb.OleDbDataAdapter("select * from [NotaryOrderClient1$]", MyConnection)
            MyCommand.TableMappings.Add("Table", "Test")
            DtSet = New System.Data.DataSet
            MyCommand.Fill(DtSet)
            MyConnection.Close()

            Dim intPos1 As Integer = 0
            Dim clsNotaryOrderClient1 As VO.NotaryClientDet1
            Dim clsDataAllNotaryOrderClient1() As VO.NotaryClientDet1
            ReDim clsDataAllNotaryOrderClient1(DtSet.Tables(0).Rows.Count - 1)

            For Each Drr As DataRow In DtSet.Tables(0).Rows
                clsNotaryOrderClient1 = New VO.NotaryClientDet1
                clsNotaryOrderClient1.NotaryOrderID = Drr(0).ToString
                clsNotaryOrderClient1.Index = Drr(1).ToString
                clsNotaryOrderClient1.JenisID = Drr(2).ToString
                clsNotaryOrderClient1.NoID = Drr(3).ToString
                clsNotaryOrderClient1.WargaNegara = Drr(4).ToString
                clsNotaryOrderClient1.Negara = Drr(5).ToString
                clsNotaryOrderClient1.Nama = Drr(6).ToString
                clsNotaryOrderClient1.TempatLahir = Drr(7).ToString
                clsNotaryOrderClient1.TglLahir = Drr(8).ToString
                clsNotaryOrderClient1.Alamat = Drr(9).ToString
                clsNotaryOrderClient1.NoNPWP = Drr(10).ToString
                clsNotaryOrderClient1.NoTelp = Drr(11).ToString
                clsNotaryOrderClient1.NoHP = Drr(12).ToString
                clsNotaryOrderClient1.Remarks = Drr(13).ToString
                clsNotaryOrderClient1.Pekerjaan = Drr(14).ToString
                clsNotaryOrderClient1.Title = Drr(15).ToString
                clsNotaryOrderClient1.TglLahirStr = Drr(16).ToString
                clsDataAllNotaryOrderClient1(intPos1) = clsNotaryOrderClient1
                intPos1 += 1
            Next

            MyCommand = New System.Data.OleDb.OleDbDataAdapter("select * from [NotaryOrderClient2$]", MyConnection)
            MyCommand.TableMappings.Add("Table", "Test")
            DtSet = New System.Data.DataSet
            MyCommand.Fill(DtSet)
            MyConnection.Close()

            Dim intPos2 As Integer = 0
            Dim clsNotaryOrderClient2 As VO.NotaryClientDet2
            Dim clsDataAllNotaryOrderClient2() As VO.NotaryClientDet2
            ReDim clsDataAllNotaryOrderClient2(DtSet.Tables(0).Rows.Count - 1)

            For Each Drr As DataRow In DtSet.Tables(0).Rows
                clsNotaryOrderClient2 = New VO.NotaryClientDet2
                clsNotaryOrderClient2.NotaryOrderID = Drr(0).ToString
                clsNotaryOrderClient2.Index = Drr(1).ToString
                clsNotaryOrderClient2.JenisID = Drr(2).ToString
                clsNotaryOrderClient2.NoID = Drr(3).ToString
                clsNotaryOrderClient2.WargaNegara = Drr(4).ToString
                clsNotaryOrderClient2.Negara = Drr(5).ToString
                clsNotaryOrderClient2.Nama = Drr(6).ToString
                clsNotaryOrderClient2.TempatLahir = Drr(7).ToString
                clsNotaryOrderClient2.TglLahir = Drr(8).ToString
                clsNotaryOrderClient2.Alamat = Drr(9).ToString
                clsNotaryOrderClient2.NoNPWP = Drr(10).ToString
                clsNotaryOrderClient2.NoTelp = Drr(11).ToString
                clsNotaryOrderClient2.NoHP = Drr(12).ToString
                clsNotaryOrderClient2.Remarks = Drr(13).ToString
                clsNotaryOrderClient2.Pekerjaan = Drr(14).ToString
                clsNotaryOrderClient2.Title = Drr(15).ToString
                clsNotaryOrderClient2.TglLahirStr = Drr(16).ToString
                clsDataAllNotaryOrderClient2(intPos2) = clsNotaryOrderClient2
                intPos2 += 1
            Next

            MyCommand = New System.Data.OleDb.OleDbDataAdapter("select * from [NotaryOrderClient3$]", MyConnection)
            MyCommand.TableMappings.Add("Table", "Test")
            DtSet = New System.Data.DataSet
            MyCommand.Fill(DtSet)
            MyConnection.Close()
            Dim intPos3 As Integer = 0
            Dim clsNotaryOrderClient3 As VO.NotaryClientDet3
            Dim clsDataAllNotaryOrderClient3() As VO.NotaryClientDet3
            ReDim clsDataAllNotaryOrderClient3(DtSet.Tables(0).Rows.Count - 1)


            For Each Drr As DataRow In DtSet.Tables(0).Rows
                clsNotaryOrderClient3 = New VO.NotaryClientDet3
                clsNotaryOrderClient3.NotaryOrderID = Drr(0).ToString
                clsNotaryOrderClient3.Index = Drr(1).ToString
                clsNotaryOrderClient3.JenisID = Drr(2).ToString
                clsNotaryOrderClient3.NoID = Drr(3).ToString
                clsNotaryOrderClient3.WargaNegara = Drr(4).ToString
                clsNotaryOrderClient3.Negara = Drr(5).ToString
                clsNotaryOrderClient3.Nama = Drr(6).ToString
                clsNotaryOrderClient3.TempatLahir = Drr(7).ToString
                clsNotaryOrderClient3.TglLahir = Drr(8).ToString
                clsNotaryOrderClient3.Alamat = Drr(9).ToString
                clsNotaryOrderClient3.NoNPWP = Drr(10).ToString
                clsNotaryOrderClient3.NoTelp = Drr(11).ToString
                clsNotaryOrderClient3.NoHP = Drr(12).ToString
                clsNotaryOrderClient3.Remarks = Drr(13).ToString
                clsNotaryOrderClient3.Pekerjaan = Drr(14).ToString
                clsNotaryOrderClient3.Title = Drr(15).ToString
                clsNotaryOrderClient3.TglLahirStr = Drr(16).ToString
                clsDataAllNotaryOrderClient3(intPos3) = clsNotaryOrderClient3
                intPos3 += 1
            Next

            '''''''''''''''''''''''''''''''''''''''''''PPAT'''''''''''''''''''''''''''''''''''''''''''''''
            MyCommand = New System.Data.OleDb.OleDbDataAdapter("select * from [PPATOrder$]", MyConnection)
            MyCommand.TableMappings.Add("Table", "Test")
            DtSet = New System.Data.DataSet
            MyCommand.Fill(DtSet)
            MyConnection.Close()

            Dim intPos4 As Integer = 0
            Dim clsPPATOrder As VO.PPATOrder
            Dim clsDataAllPPATOrder() As VO.PPATOrder
            ReDim clsDataAllPPATOrder(DtSet.Tables(0).Rows.Count - 1)

            '"VALUES (@PPATOrderID, @NoAkta, @TglAkta, @JenisTransaksi, @JenisNoHak, @LetakTanahBangunan, @LuasTanahM2, @LuasBangunanM2, " & _
            '   "@HargaTransaksi,@SPPTPBBNOPTahun,@SPPTPBBNJOP,@SSPTanggal,@SSPHarga,@SSBTanggal,@SSBHarga, @FileLocation, @Remarks, @Status, " & _
            '   "@DraftBy, @DraftDate, @ProcessBy, @ProcessDate, @ProcessRemarks,@BPNFinishBy, @BPNFinishDate, @BPNFinishRemarks, " & _
            '   "@CompletedBy, @CompletedDate, @CompletedRemarks, @IsFalse, @IsFalseBy, @IsFalseDate, @IsFalseRemarks, @ModifiedBy, @ModifiedDate) "


            For Each Drr As DataRow In DtSet.Tables(0).Rows
                clsPPATOrder = New VO.PPATOrder
                clsPPATOrder.PPATOrderID = Drr(0).ToString
                clsPPATOrder.NoAkta = Drr(1).ToString
                clsPPATOrder.TglAkta = Drr(2).ToString
                clsPPATOrder.JenisTransaksi = Drr(3).ToString
                clsPPATOrder.JenisNoHak = Drr(4).ToString
                clsPPATOrder.LetakTanahBangunan = Drr(5).ToString
                clsPPATOrder.LuasTanahM2 = Drr(6).ToString
                clsPPATOrder.LuasBangunanM2 = Drr(7).ToString
                clsPPATOrder.HargaTransaksi = Drr(8).ToString
                clsPPATOrder.SPPTPBBNOPTahun = Drr(9).ToString
                clsPPATOrder.SPPTPBBNJOP = Drr(10).ToString
                clsPPATOrder.SSPTanggal = Drr(11).ToString
                clsPPATOrder.SSPHarga = Drr(12).ToString
                clsPPATOrder.SSBTanggal = Drr(13).ToString
                clsPPATOrder.SSBHarga = Drr(14).ToString
                clsPPATOrder.FileLocation = Drr(15).ToString
                clsPPATOrder.Remarks = Drr(16).ToString
                clsPPATOrder.Status = Drr(17).ToString
                clsPPATOrder.DraftBy = Drr(18).ToString
                clsPPATOrder.DraftDate = Drr(19).ToString
                clsPPATOrder.ProcessBy = Drr(20).ToString
                clsPPATOrder.ProcessDate = Drr(21).ToString
                clsPPATOrder.ProcessRemarks = Drr(22).ToString
                clsPPATOrder.BPNFinishBy = Drr(23).ToString
                clsPPATOrder.BPNFinishDate = Drr(24).ToString
                clsPPATOrder.BPNFinishRemarks = Drr(25).ToString
                clsPPATOrder.CompletedBy = Drr(26).ToString
                clsPPATOrder.CompletedDate = Drr(27).ToString
                clsPPATOrder.CompletedRemarks = Drr(28).ToString
                clsPPATOrder.IsFalse = Drr(29).ToString
                clsPPATOrder.IsFalseBy = Drr(30).ToString
                clsPPATOrder.IsFalseDate = Drr(31).ToString
                clsPPATOrder.IsFalseRemarks = Drr(32).ToString
                clsPPATOrder.ModifiedBy = Drr(33).ToString
                clsPPATOrder.ModifiedDate = Drr(34).ToString
                clsPPATOrder.TglPenyerahanDokumen = Drr(35).ToString
                clsPPATOrder.IsFalseLevel = Drr(36).ToString
                clsDataAllPPATOrder(intPos4) = clsPPATOrder
                intPos4 += 1
            Next


            MyCommand = New System.Data.OleDb.OleDbDataAdapter("select * from [PPATOrderClient1$]", MyConnection)
            MyCommand.TableMappings.Add("Table", "Test")
            DtSet = New System.Data.DataSet
            MyCommand.Fill(DtSet)
            MyConnection.Close()

            Dim intPos5 As Integer = 0
            Dim clsPPATOrderClient1 As VO.PPATClientDet1
            Dim clsDataAllPPATOrderClient1() As VO.PPATClientDet1
            ReDim clsDataAllPPATOrderClient1(DtSet.Tables(0).Rows.Count - 1)

            For Each Drr As DataRow In DtSet.Tables(0).Rows
                clsPPATOrderClient1 = New VO.PPATClientDet1
                clsPPATOrderClient1.PPATOrderID = Drr(0).ToString
                clsPPATOrderClient1.Index = Drr(1).ToString
                clsPPATOrderClient1.JenisID = Drr(2).ToString
                clsPPATOrderClient1.NoID = Drr(3).ToString
                clsPPATOrderClient1.WargaNegara = Drr(4).ToString
                clsPPATOrderClient1.Negara = Drr(5).ToString
                clsPPATOrderClient1.Nama = Drr(6).ToString
                clsPPATOrderClient1.TempatLahir = Drr(7).ToString
                clsPPATOrderClient1.TglLahir = Drr(8).ToString
                clsPPATOrderClient1.Alamat = Drr(9).ToString
                clsPPATOrderClient1.NoNPWP = Drr(10).ToString
                clsPPATOrderClient1.NoTelp = Drr(11).ToString
                clsPPATOrderClient1.NoHP = Drr(12).ToString
                clsPPATOrderClient1.Remarks = Drr(13).ToString
                clsPPATOrderClient1.Pekerjaan = Drr(14).ToString
                clsPPATOrderClient1.Title = Drr(15).ToString
                clsPPATOrderClient1.TglLahirStr = Drr(16).ToString
                clsDataAllPPATOrderClient1(intPos5) = clsPPATOrderClient1
                intPos5 += 1
            Next

            MyCommand = New System.Data.OleDb.OleDbDataAdapter("select * from [PPATOrderClient2$]", MyConnection)
            MyCommand.TableMappings.Add("Table", "Test")
            DtSet = New System.Data.DataSet
            MyCommand.Fill(DtSet)
            MyConnection.Close()

            Dim intPos6 As Integer = 0
            Dim clsPPATOrderClient2 As VO.PPATClientDet2
            Dim clsDataAllPPATOrderClient2() As VO.PPATClientDet2
            ReDim clsDataAllPPATOrderClient2(DtSet.Tables(0).Rows.Count - 1)

            For Each Drr As DataRow In DtSet.Tables(0).Rows
                clsPPATOrderClient2 = New VO.PPATClientDet2
                clsPPATOrderClient2.PPATOrderID = Drr(0).ToString
                clsPPATOrderClient2.Index = Drr(1).ToString
                clsPPATOrderClient2.JenisID = Drr(2).ToString
                clsPPATOrderClient2.NoID = Drr(3).ToString
                clsPPATOrderClient2.WargaNegara = Drr(4).ToString
                clsPPATOrderClient2.Negara = Drr(5).ToString
                clsPPATOrderClient2.Nama = Drr(6).ToString
                clsPPATOrderClient2.TempatLahir = Drr(7).ToString
                clsPPATOrderClient2.TglLahir = Drr(8).ToString
                clsPPATOrderClient2.Alamat = Drr(9).ToString
                clsPPATOrderClient2.NoNPWP = Drr(10).ToString
                clsPPATOrderClient2.NoTelp = Drr(11).ToString
                clsPPATOrderClient2.NoHP = Drr(12).ToString
                clsPPATOrderClient2.Remarks = Drr(13).ToString
                clsPPATOrderClient2.Pekerjaan = Drr(14).ToString
                clsPPATOrderClient2.Title = Drr(15).ToString
                clsPPATOrderClient2.TglLahirStr = Drr(16).ToString
                clsDataAllPPATOrderClient2(intPos6) = clsPPATOrderClient2
                intPos6 += 1
            Next

            Try
                'Simpan semua Data Header dan Client Detail
                DL.ExportImport.SaveAllData(clsDataAllNotaryOrder, clsDataAllNotaryOrderClient1, clsDataAllNotaryOrderClient2, clsDataAllNotaryOrderClient3, clsDataAllPPATOrder, clsDataAllPPATOrderClient1, clsDataAllPPATOrderClient2)

                UI.usForm.frmMessageBox("Import Data Success ! ")

            Catch ex As Exception
                UI.usForm.frmMessageBox(ex.Message)
            End Try

        End If
    End Sub

    Private Sub frmSysExportImport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtpDateFrom.Value = Today.Year & "/" & Today.Month & "/" & "01 23:59:59"
        dtpDateTo.Value = dtpDateFrom.Value.AddMonths(1).AddDays(-1)
        cboJenisTransaksi.SelectedIndex = 0

    End Sub

    Private Sub cboJenisTransaksi_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboJenisTransaksi.SelectedIndexChanged
        If cboJenisTransaksi.SelectedIndex = 0 Then
            Panel1.Visible = True
            btnImport.Visible = False
        Else
            Panel1.Visible = False
            btnImport.Visible = True
        End If
    End Sub

    Private Sub btnMasterUserExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMasterUserExport.Click
        'If Not UI.usForm.frmAskQuestion("Export data Master User") Then Exit Sub
        'Try
        '    Dim i, j As Integer
        '    'Excel WorkBook object 
        '    Dim xlApp As Microsoft.Office.Interop.Excel.Application
        '    Dim xlWorkBook As Microsoft.Office.Interop.Excel.Workbook
        '    Dim xlWorkSheet As Microsoft.Office.Interop.Excel.Worksheet
        '    Dim misValue As Object = System.Reflection.Missing.Value
        '    xlApp = New Microsoft.Office.Interop.Excel.ApplicationClass
        '    xlWorkBook = xlApp.Workbooks.Add(misValue)

        '    ' Sheet Name or Number

        '    Dim xlWorkSheetNO As Excel.Worksheet

        '    xlWorkSheetNO = xlWorkBook.Worksheets.Add()

        '    xlWorkSheetNO.Name = "MasterUser"

        '    xlWorkBook.Worksheets("Sheet1").Delete()
        '    xlWorkBook.Worksheets("Sheet2").Delete()
        '    xlWorkBook.Worksheets("Sheet3").Delete()

        '    Try
        '        'NotaryOrder
        '        xlWorkSheet = xlWorkBook.Sheets("MasterUser")
        '        Dim ds As New DataSet
        '        ds = DL.ExportImport.ListMasterUser()
        '        'COLUMN NAME ADD IN EXCEL SHEET OR HEADING MUST 2 CELLS
        '        xlWorkSheet.Cells(1, 1).Value = "EXPORT DATA FROM "
        '        xlWorkSheet.Cells(1, 2).Value = "MASTER USER"

        '        ' SQL Table Transfer to Excel
        '        For i = 0 To ds.Tables(0).Rows.Count - 1
        '            'Column
        '            For j = 0 To ds.Tables(0).Columns.Count - 1
        '                ' this i change to header line cells >>>
        '                xlWorkSheet.Cells(i + 2, j + 1) = _
        '                ds.Tables(0).Rows(i).Item(j)
        '            Next
        '        Next

        '        ' Save as path of excel sheet
        '        xlWorkSheet.SaveAs(UI.usUserApp.ExportLocation & "MasterUser.xls")
        '        xlWorkBook.Close()
        '        xlApp.Quit()
        '        releaseObject(xlApp)
        '        releaseObject(xlWorkBook)
        '        releaseObject(xlWorkSheet)

        '        UI.usForm.frmMessageBox("File export data tersimpan di MasterUser.xls")
        '    Catch ex As Exception
        '        UI.usForm.frmMessageBox(ex.Message)
        '    End Try
        'Catch ex As Exception
        '    UI.usForm.frmMessageBox(ex.Message)
        'End Try
    End Sub

    Private Sub btnMasterUserImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMasterUserImport.Click
        Dim MyConnection As System.Data.OleDb.OleDbConnection
        Dim DtSet As System.Data.DataSet
        Dim MyCommand As System.Data.OleDb.OleDbDataAdapter

        Dim fBrowse As New OpenFileDialog
        With fBrowse
            .Filter = "Excel files(*.xls)|*.xls|All files (*.*)|*.*"
            .FilterIndex = 1
            .Title = "Import data from Excel file"
        End With

        If fBrowse.ShowDialog() = Windows.Forms.DialogResult.OK Then

            Dim fname As String
            fname = fBrowse.FileName

            If Not UI.usForm.frmAskQuestion("Apakah anda yakin import data dari " & fname) Then Exit Sub

            MyConnection = New System.Data.OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source='" & fname & " '; " & "Extended Properties=Excel 8.0;")

            MyCommand = New System.Data.OleDb.OleDbDataAdapter("select * from [MasterUser$]", MyConnection)
            MyCommand.TableMappings.Add("Table", "Test")
            DtSet = New System.Data.DataSet
            MyCommand.Fill(DtSet)
            MyConnection.Close()

            Dim intPos As Integer = 0
            Dim clsMasterUser As VO.MasterUser
            Dim clsDataAllMasterUser() As VO.MasterUser
            ReDim clsDataAllMasterUser(DtSet.Tables(0).Rows.Count - 1)

            For Each Drr As DataRow In DtSet.Tables(0).Rows
                clsMasterUser = New VO.MasterUser
                clsMasterUser.LocationID = Drr(0).ToString
                clsMasterUser.UserID = Drr(1).ToString
                clsMasterUser.LocationName = Drr(2).ToString
                clsMasterUser.UserName = Drr(3).ToString
                clsMasterUser.Password = Drr(4).ToString
                clsMasterUser.UserPosition = Drr(5).ToString
                clsMasterUser.BirthPlace = Drr(6).ToString
                clsMasterUser.BirthDate = Drr(7).ToString
                clsMasterUser.Address = Drr(8).ToString
                clsMasterUser.IDType = Drr(9).ToString
                clsMasterUser.IDNumber = Drr(10).ToString
                clsMasterUser.NPWPNumber = Drr(11).ToString
                clsMasterUser.JamsostekID = Drr(12).ToString
                clsMasterUser.NoHP = Drr(13).ToString
                clsMasterUser.Remarks = Drr(14).ToString
                clsMasterUser.StartWorkingDate = Drr(15).ToString
                clsMasterUser.CreatedDate = Drr(16).ToString
                clsMasterUser.ModifiedDate = Drr(17).ToString
                clsMasterUser.IsActive = Drr(18).ToString
                clsMasterUser.IsMasterUser = Drr(19).ToString
                clsMasterUser.IsNotary = Drr(20).ToString
                clsMasterUser.IsNotaryNew = Drr(21).ToString
                clsMasterUser.IsNotaryProcess = Drr(22).ToString
                clsMasterUser.IsNotaryCompleted = Drr(23).ToString
                clsMasterUser.IsNotaryFalse = Drr(24).ToString
                clsMasterUser.IsPPAT = Drr(25).ToString
                clsMasterUser.IsPPATNew = Drr(26).ToString
                clsMasterUser.IsPPATProcess = Drr(27).ToString
                clsMasterUser.IsPPATBPNFinish = Drr(28).ToString
                clsMasterUser.IsPPATCompleted = Drr(29).ToString
                clsMasterUser.IsPPATFalse = Drr(30).ToString
                clsMasterUser.Title = Drr(31).ToString
                clsMasterUser.BirthDateStr = Drr(32).ToString
                clsDataAllMasterUser(intPos) = clsMasterUser
                intPos += 1
            Next

            Try
                'Simpan semua Data Header dan Client Detail
                DL.ExportImport.SaveMasterUser(clsDataAllMasterUser)

                UI.usForm.frmMessageBox("Import Data Success ! ")

            Catch ex As Exception
                UI.usForm.frmMessageBox(ex.Message)
            End Try
        End If

    End Sub

    Private Sub btnSendEmail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSendEmail.Click
        Dim objMissing As Object = Type.Missing
        Dim objOutlook As Outlook.Application = Nothing
        Dim objNS As Outlook.NameSpace = Nothing
        Dim objMail As Outlook.MailItem = Nothing

        Try
            objOutlook = New Outlook.Application()
            objNS = objOutlook.GetNamespace("MAPI")

            ' Log on by using a dialog box to choose the profile.
            objNS.Logon(objMissing, objMissing, False, False)

            ' create an email message
            objMail = CType(objOutlook.CreateItem(Outlook.OlItemType.olMailItem), Outlook.MailItem)

            ' Set the properties of the email.
            With objMail
                .Subject = txtSubject.Text
                .To = txtTo.Text
                .Body = txtContent.Text
                .Send()
            End With
            objOutlook = Nothing
            objMail = Nothing

        Catch ex As Exception

        Finally
            If Not objMail Is Nothing Then
                Marshal.FinalReleaseComObject(objMail)
                objMail = Nothing
            End If

            If Not objNS Is Nothing Then
                Marshal.FinalReleaseComObject(objNS)
                objNS = Nothing
            End If

            If Not objOutlook Is Nothing Then
                Marshal.FinalReleaseComObject(objOutlook)
                objOutlook = Nothing
            End If
        End Try

    End Sub

  
    Private Sub btnNETmail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNETmail.Click
        Try
            Dim Success As Boolean = False

            Dim EMail As New System.Net.Mail.MailMessage
            Dim SMTPServer As New System.Net.Mail.SmtpClient
            Dim Authentication As New Net.NetworkCredential("login name/email", "password")

            EMail.To.Add(txtTo.Text)
            EMail.From = New System.Net.Mail.MailAddress(txtFrom.Text)
            EMail.Body = txtContent.Text
            EMail.Subject = txtSubject.Text

            SMTPServer.Host = txtHost.Text    '10.70.70.60
            SMTPServer.Port = CInt(txtPort.Text)
            SMTPServer.Credentials = Authentication

            SMTPServer.Send(EMail)
            UI.usForm.frmMessageBox("Email has been sent")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
       
    End Sub

    
End Class
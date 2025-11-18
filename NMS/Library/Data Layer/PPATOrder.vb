Imports System.Data.SqlClient

Namespace DL

    Public Class PPATOrder

        Public Shared Function PPATOrderID(ByVal dtTglAkta As DateTime) As String
            Dim strPPATOrderID As String = ""
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader
            Try
                If Not SQL.bolUseTrans Then SQL.OpenConnection()
                With sqlcmdExecute
                    .Connection = SQL.sqlConn
                    .CommandText = _
                    "BEGIN " & _
                    "    DECLARE @TMP  int, @Year int, @Month int " & _
                    "    SET @Year = Year(@TglAkta) " & _
                    "    SET @Month = Month(@TglAkta) " & _
                    "    SET @TMP = ISNULL(CAST((SELECT Top 1 RIGHT(PPATOrderID, 6) " & _
                    "	 FROM NMS_traPPATOrder WHERE Year(DraftDate) = @Year AND Month(DraftDate) = @Month AND SUBSTRING(PPATOrderID,3,3) = @LocationInitial " & _
                    "	 Order By PPATOrderID Desc) as int),0) + 1 " & _
                    "    SELECT('PT' + @LocationInitial +  Right(Cast(@Year as varchar(4)), 2) + " & _
                    "    dbo.udf_strZero(cast(@Month as varchar(2)),2,0) + dbo.udf_strZero(Cast(@TMP as varchar(6)),6,0)) AS PPATOrderID " & _
                    "END "

                    .Parameters.Add("@TglAkta", SqlDbType.DateTime).Value = dtTglAkta
                    .Parameters.Add("@LocationInitial", SqlDbType.VarChar).Value = UI.usUserApp.LocationID

                    If SQL.bolUseTrans Then .Transaction = SQL.sqlTrans
                End With
                sqlrdData = sqlcmdExecute.ExecuteReader(CommandBehavior.SingleRow)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        strPPATOrderID = .Item("PPATOrderID")
                    End If
                    .Close()
                End With
                If Not SQL.bolUseTrans Then SQL.CloseConnection()
            Catch ex As Exception
                Throw ex
            End Try
            Return strPPATOrderID
        End Function


        Public Shared Function ListData(ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime, ByVal intStatus As Integer, ByVal strJenisTransaksi As String, Optional ByVal IsFileBPNExport As Boolean = False, Optional ByVal IsFilterProcessBy As Boolean = False) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                 "SELECT A.PPATOrderID,NoAkta,TglAkta, CASE JenisTransaksi WHEN 0 THEN 'AJB' WHEN 1 THEN 'ATM' WHEN 2 THEN 'AH' WHEN 3 THEN 'APDP' WHEN 4 THEN 'APHB' WHEN 5 THEN 'APHGB' WHEN 6 THEN 'APHT' WHEN 7 THEN 'ROYA' WHEN 8 THEN 'BALIK NAMA' WHEN 9 THEN 'GANTI BLANKO' WHEN 10 THEN 'MOHON HAK' WHEN 11 THEN 'PENINGKATAN HAK' WHEN 12 THEN 'PEMASANGAN HAK TANGGUNGAN' END AS JenisTransaksi, JenisNoHak,LetakTanahBangunan " & _
                 ",LuasTanahM2,LuasBangunanM2,HargaTransaksi,SPPTPBBNOPTahun,SPPTPBBNJOP,SSPTanggal,SSPHarga,SSBTanggal,SSBHarga " & _
                 ",CASE Status WHEN 1 THEN 'DRAFT' WHEN 2 THEN 'PROCESS' WHEN 3 THEN 'BPN FINISH' WHEN 4 THEN 'COMPLETED' END AS Status, FileLocation,Remarks," & _
                 "DraftBy, DraftDate, ProcessBy, ProcessDate, ProcessRemarks,BPNFinishBy, BPNFinishDate, BPNFinishRemarks, CompletedBy, CompletedDate, CompletedRemarks, " & _
                 "IsFalse, IsFalseBy, IsFalseDate, IsFalseRemarks, CASE IsFalseLevel WHEN 0 THEN 'DRAFT' WHEN 1 THEN 'PROCESS' WHEN 2 THEN 'DRAFT AND PROCESS' WHEN 3 THEN '' END AS IsFalseLevelStr, B.NoID ,B.Nama, C.NoID AS NoID2, C.Nama AS Nama2 FROM NMS_traPPATOrder A " & _
                 "INNER JOIN (SELECT PPATOrderID, NoID, Nama FROM NMS_traPPATOrderClient1 WHERE [INDEX]=1) B ON A.PPATOrderID =B.PPATOrderID " & _
                 "LEFT JOIN (SELECT PPATOrderID, NoID, Nama FROM NMS_traPPATOrderClient2 WHERE [INDEX]=1) C ON A.PPATOrderID =C.PPATOrderID " & _
                 "WHERE CONVERT(VARCHAR(8),TglAkta,112)>=  CONVERT(VARCHAR(8), @DateFrom,112) " & _
                 "AND CONVERT(VARCHAR(8),TglAkta,112)<= CONVERT(VARCHAR(8), @DateTo,112)  "

                If IsFileBPNExport = False Then
                    .CommandText += "AND JenisTransaksi IN (" & strJenisTransaksi.Trim & ")  "
                End If

                If intStatus > 0 Then
                    .CommandText += " AND Status=@Status "
                End If

                If IsFileBPNExport = True Then
                    .CommandText += " AND A.NoAkta <>'' "
                End If

                If IsFilterProcessBy = True Then
                    .CommandText += " AND A.ProcessUserID=@ProcessUserID "
                End If

                .Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = dtmDateFrom
                .Parameters.Add("@DateTo", SqlDbType.DateTime).Value = dtmDateTo
                .Parameters.Add("@Status", SqlDbType.Int).Value = intStatus
                .Parameters.Add("@ProcessUserID", SqlDbType.VarChar).Value = UI.usUserApp.UserID

            End With
            Return SQL.QueryDataTable(sqlcmdExecute)
        End Function

        Public Shared Function ListClient1(ByVal strPPATOrderID As String) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                    "SELECT PPATOrderID, [Index], JenisID, NoID, WargaNegara, Negara, Nama, TempatLahir, TglLahir, Alamat, Pekerjaan, NoNPWP, NoTelp, NoHP, Remarks, Title, TglLahirStr FROM NMS_traPPATOrderClient1 " & _
                    "WHERE PPATOrderID=@PPATOrderID " & _
                    "ORDER BY [Index] "
                .Parameters.Add("@PPATOrderID", SqlDbType.VarChar, 20).Value = strPPATOrderID
            End With
            Return SQL.QueryDataTable(sqlcmdExecute)
        End Function

        Public Shared Function ListClient2(ByVal strPPATOrderID As String) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                    "SELECT PPATOrderID, [Index], JenisID, NoID, WargaNegara, Negara, Nama, TempatLahir, TglLahir, Alamat, Pekerjaan, NoNPWP, NoTelp, NoHP, Remarks, Title, TglLahirStr FROM NMS_traPPATOrderClient2 " & _
                    "WHERE PPATOrderID=@PPATOrderID " & _
                    "ORDER BY [Index] "
                .Parameters.Add("@PPATOrderID", SqlDbType.VarChar, 20).Value = strPPATOrderID
            End With
            Return SQL.QueryDataTable(sqlcmdExecute)
        End Function

        Public Shared Function GetDetail(ByVal strPPATOrderID As String) As VO.PPATOrder
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader
            Dim clsReturn As New VO.PPATOrder
            Try
                If Not SQL.bolUseTrans Then SQL.OpenConnection()
                With sqlcmdExecute
                    .Connection = SQL.sqlConn
                    .CommandText = _
                       "SELECT PPATOrderID,NoAkta,TglAkta,JenisTransaksi,JenisNoHak,LetakTanahBangunan " & _
                       ",LuasTanahM2,LuasBangunanM2,HargaTransaksi,SPPTPBBNOPTahun,SPPTPBBNJOP,SSPTanggal,SSPHarga,SSBTanggal,SSBHarga " & _
                       ",CASE Status WHEN 1 THEN 'DRAFT' WHEN 2 THEN 'PROCESS' WHEN 3 THEN 'BPN FINISH' WHEN 4 THEN 'COMPLETED' END AS Status " & _
                       ",FileLocation,Remarks,DraftBy,DraftDate, ProcessBy,ProcessDate, BPNFinishBy, BPNFinishDate, CompletedBy, CompletedDate " & _
                       ",TglPenyerahanDokumen, ProcessUserID, ExpInterval FROM NMS_traPPATOrder " & _
                       "WHERE PPATOrderID=@PPATOrderID "

                    .Parameters.Add("@PPATOrderID", SqlDbType.VarChar, 20).Value = strPPATOrderID

                    If SQL.bolUseTrans Then .Transaction = SQL.sqlTrans
                End With
                sqlrdData = sqlcmdExecute.ExecuteReader(CommandBehavior.SingleResult)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        clsReturn.PPATOrderID = .Item("PPATOrderID")
                        clsReturn.NoAkta = .Item("NoAkta")
                        clsReturn.TglAkta = .Item("TglAkta")
                        clsReturn.JenisTransaksi = .Item("JenisTransaksi")
                        clsReturn.JenisNoHak = .Item("JenisNoHak")
                        clsReturn.LetakTanahBangunan = .Item("LetakTanahBangunan")
                        clsReturn.LuasTanahM2 = .Item("LuasTanahM2")
                        clsReturn.LuasBangunanM2 = .Item("LuasBangunanM2")
                        clsReturn.HargaTransaksi = .Item("HargaTransaksi")
                        clsReturn.SPPTPBBNOPTahun = .Item("SPPTPBBNOPTahun")
                        clsReturn.SPPTPBBNJOP = .Item("SPPTPBBNJOP")
                        clsReturn.SSPTanggal = .Item("SSPTanggal")
                        clsReturn.SSPHarga = .Item("SSPHarga")
                        clsReturn.SSBTanggal = .Item("SSBTanggal")
                        clsReturn.SSBHarga = .Item("SSBHarga")
                        clsReturn.StatusStr = .Item("Status")
                        clsReturn.FileLocation = .Item("FileLocation")
                        clsReturn.Remarks = .Item("Remarks")
                        clsReturn.DraftBy = .Item("DraftBy")
                        clsReturn.DraftDate = .Item("DraftDate")
                        clsReturn.ProcessBy = .Item("ProcessBy")
                        clsReturn.ProcessDate = .Item("ProcessDate")
                        clsReturn.BPNFinishBy = .Item("BPNFinishBy")
                        clsReturn.BPNFinishDate = .Item("BPNFinishDate")
                        clsReturn.CompletedBy = .Item("CompletedBy")
                        clsReturn.CompletedDate = .Item("CompletedDate")
                        clsReturn.TglPenyerahanDokumen = .Item("TglPenyerahanDokumen")
                        clsReturn.ProcessUserID = .Item("ProcessUserID")
                        clsReturn.ExpInterval = .Item("ExpInterval")
                    End If
                    .Close()
                End With
                If Not SQL.bolUseTrans Then SQL.CloseConnection()
            Catch ex As Exception
                Throw ex
            End Try
            Return clsReturn
        End Function

        Public Shared Sub SaveAllData(ByVal bolNew As Boolean, ByVal strPPATOrderID As String, ByVal clsData As VO.PPATOrder, ByVal clsClient1() As VO.PPATClientDet1, ByVal clsClient2() As VO.PPATClientDet2)
            Dim intI As Integer = 1
            Dim intI2 As Integer = 1
            Dim intI3 As Integer = 1

            DL.SQL.OpenConnection()
            DL.SQL.BeginTransaction()
            Try
                'Save Header
                DL.PPATOrder.SaveData(bolNew, clsData)

                'Save Client1
                If Not bolNew Then DL.PPATOrder.DeleteClient1(strPPATOrderID)
                For Each DataItem As VO.PPATClientDet1 In clsClient1
                    DL.PPATOrder.SaveClient1(DataItem)
                    intI += 1
                Next

                'Save Client2
                If Not bolNew Then DL.PPATOrder.DeleteClient2(strPPATOrderID)
                For Each DataItem As VO.PPATClientDet2 In clsClient2
                    DL.PPATOrder.SaveClient2(DataItem)
                    intI2 += 1
                Next


                DL.SQL.CommitTransaction()
            Catch ex As Exception
                DL.SQL.RollBackTransaction()
                Throw ex
            Finally
                DL.SQL.CloseConnection()
            End Try


        End Sub

        Public Shared Sub SaveData(ByVal bolNew As Boolean, ByVal clsData As VO.PPATOrder)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                If bolNew Then
                    .CommandText = _
                        "INSERT INTO NMS_traPPATOrder (PPATOrderID,NoAkta,TglAkta,JenisTransaksi,JenisNoHak,LetakTanahBangunan " & _
                        ",LuasTanahM2,LuasBangunanM2,HargaTransaksi,SPPTPBBNOPTahun,SPPTPBBNJOP,SSPTanggal,SSPHarga " & _
                        ",SSBTanggal,SSBHarga,FileLocation,Remarks,DraftBy,DraftDate,ModifiedBy, TglPenyerahanDokumen, ProcessUserID, ExpInterval) " & _
                        "VALUES (@PPATOrderID,@NoAkta,@TglAkta,@JenisTransaksi,@JenisNoHak,@LetakTanahBangunan " & _
                        ",@LuasTanahM2,@LuasBangunanM2,@HargaTransaksi,@SPPTPBBNOPTahun,@SPPTPBBNJOP,@SSPTanggal,@SSPHarga " & _
                        ",@SSBTanggal,@SSBHarga,@FileLocation,@Remarks,@DraftBy,GETDATE(), @ModifiedBy, @TglPenyerahanDokumen, @ProcessUserID, @ExpInterval) "

                Else
                    .CommandText = _
                        "UPDATE NMS_traPPATOrder " & _
                        "SET NoAkta=@NoAkta,TglAkta=@TglAkta,JenisTransaksi=@JenisTransaksi,JenisNoHak=@JenisNoHak,LetakTanahBangunan=@LetakTanahBangunan " & _
                        ",LuasTanahM2=@LuasTanahM2,LuasBangunanM2=@LuasBangunanM2,HargaTransaksi=@HargaTransaksi,SPPTPBBNOPTahun=@SPPTPBBNOPTahun " & _
                        ",SPPTPBBNJOP=@SPPTPBBNJOP,SSPTanggal=@SSPTanggal,SSPHarga=@SSPHarga " & _
                        ",SSBTanggal=@SSBTanggal,SSBHarga=@SSBHarga,FileLocation=@FileLocation,Remarks=@Remarks, ModifiedBy=@ModifiedBy, ModifiedDate=GETDATE(), " & _
                        "TglPenyerahanDokumen=@TglPenyerahanDokumen, ProcessUserID=@ProcessUserID, ExpInterval=@ExpInterval " & _
                        "WHERE PPATOrderID=@PPATOrderID "
                End If

                .Parameters.Add("@PPATOrderID", SqlDbType.VarChar).Value = clsData.PPATOrderID
                .Parameters.Add("@NoAkta", SqlDbType.VarChar).Value = clsData.NoAkta
                .Parameters.Add("@TglAkta", SqlDbType.DateTime).Value = clsData.TglAkta
                .Parameters.Add("@JenisTransaksi", SqlDbType.Int).Value = clsData.JenisTransaksi
                .Parameters.Add("@ExpInterval", SqlDbType.Int).Value = clsData.ExpInterval
                .Parameters.Add("@JenisNoHak", SqlDbType.VarChar).Value = clsData.JenisNoHak
                .Parameters.Add("@LetakTanahBangunan", SqlDbType.VarChar).Value = clsData.LetakTanahBangunan
                .Parameters.Add("@LuasTanahM2", SqlDbType.Decimal).Value = clsData.LuasTanahM2
                .Parameters.Add("@LuasBangunanM2", SqlDbType.Decimal).Value = clsData.LuasBangunanM2
                .Parameters.Add("@HargaTransaksi", SqlDbType.Decimal).Value = clsData.HargaTransaksi
                .Parameters.Add("@SPPTPBBNOPTahun", SqlDbType.VarChar).Value = clsData.SPPTPBBNOPTahun
                .Parameters.Add("@SPPTPBBNJOP", SqlDbType.Decimal).Value = clsData.SPPTPBBNJOP
                .Parameters.Add("@SSPTanggal", SqlDbType.DateTime).Value = clsData.SSPTanggal
                .Parameters.Add("@SSPHarga", SqlDbType.Decimal).Value = clsData.SSPHarga
                .Parameters.Add("@SSBTanggal", SqlDbType.DateTime).Value = clsData.SSBTanggal
                .Parameters.Add("@SSBHarga", SqlDbType.Decimal).Value = clsData.SSBHarga
                .Parameters.Add("@FileLocation", SqlDbType.VarChar).Value = clsData.FileLocation
                .Parameters.Add("@Remarks", SqlDbType.VarChar).Value = clsData.Remarks
                .Parameters.Add("@DraftBy", SqlDbType.VarChar).Value = UI.usUserApp.UserID
                .Parameters.Add("@ModifiedBy", SqlDbType.VarChar).Value = UI.usUserApp.UserID
                .Parameters.Add("@TglPenyerahanDokumen", SqlDbType.DateTime).Value = clsData.TglPenyerahanDokumen
                .Parameters.Add("@ProcessUserID", SqlDbType.VarChar).Value = clsData.ProcessUserID

            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub DeleteHeader(ByVal strPPATOrderID As String)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                    "DELETE NMS_traPPATOrder WHERE PPATOrderID=@PPATOrderID "

                .Parameters.Add("@PPATOrderID", SqlDbType.VarChar, 20).Value = strPPATOrderID
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub SaveClient1(ByVal clsData As VO.PPATClientDet1)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                "INSERT INTO NMS_traPPATOrderClient1 (PPATOrderID, [Index], JenisID, NoID, WargaNegara, Negara, Nama, TempatLahir, TglLahir, Alamat, Pekerjaan, NoNPWP, NoTelp, NoHP, Remarks, Title, TglLahirStr) " & _
                "VALUES (@PPATOrderID, @Index, @JenisID, @NoID, @WargaNegara, @Negara, @Nama, @TempatLahir, @TglLahir, @Alamat, @Pekerjaan, @NoNPWP, @NoTelp, @NoHP, @Remarks, @Title, @TglLahirStr) "

                .Parameters.Add("@PPATOrderID", SqlDbType.VarChar).Value = clsData.PPATOrderID
                .Parameters.Add("@Index", SqlDbType.Int).Value = clsData.Index
                .Parameters.Add("@JenisID", SqlDbType.VarChar).Value = clsData.JenisID.ToUpper
                .Parameters.Add("@NoID", SqlDbType.VarChar).Value = clsData.NoID
                .Parameters.Add("@WargaNegara", SqlDbType.VarChar).Value = clsData.WargaNegara
                .Parameters.Add("@Negara", SqlDbType.VarChar).Value = clsData.Negara
                .Parameters.Add("@Nama", SqlDbType.VarChar).Value = clsData.Nama
                .Parameters.Add("@TempatLahir", SqlDbType.VarChar).Value = clsData.TempatLahir
                .Parameters.Add("@TglLahir", SqlDbType.DateTime).Value = clsData.TglLahir
                .Parameters.Add("@Alamat", SqlDbType.VarChar).Value = clsData.Alamat
                .Parameters.Add("@Pekerjaan", SqlDbType.VarChar).Value = clsData.Pekerjaan
                .Parameters.Add("@NoNPWP", SqlDbType.VarChar).Value = clsData.NoNPWP
                .Parameters.Add("@NoTelp", SqlDbType.VarChar).Value = clsData.NoTelp
                .Parameters.Add("@NoHP", SqlDbType.VarChar).Value = clsData.NoHP
                .Parameters.Add("@Remarks", SqlDbType.VarChar).Value = clsData.Remarks
                .Parameters.Add("@Title", SqlDbType.VarChar).Value = clsData.Title
                .Parameters.Add("@TglLahirStr", SqlDbType.VarChar).Value = clsData.TglLahirStr

            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub DeleteClient1(ByVal strPPATOrderID As String)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                    "DELETE NMS_traPPATOrderClient1 WHERE PPATOrderID=@PPATOrderID "

                .Parameters.Add("@PPATOrderID", SqlDbType.VarChar, 20).Value = strPPATOrderID
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub SaveClient2(ByVal clsData As VO.PPATClientDet2)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                "INSERT INTO NMS_traPPATOrderClient2 (PPATOrderID, [Index], JenisID, NoID, WargaNegara, Negara, Nama, TempatLahir, TglLahir, Alamat, Pekerjaan, NoNPWP, NoTelp, NoHP, Remarks, Title, TglLahirStr) " & _
                "VALUES (@PPATOrderID, @Index, @JenisID, @NoID, @WargaNegara, @Negara, @Nama, @TempatLahir, @TglLahir, @Alamat, @Pekerjaan, @NoNPWP, @NoTelp, @NoHP, @Remarks, @Title, @TglLahirStr) "

                .Parameters.Add("@PPATOrderID", SqlDbType.VarChar).Value = clsData.PPATOrderID
                .Parameters.Add("@Index", SqlDbType.Int).Value = clsData.Index
                .Parameters.Add("@JenisID", SqlDbType.VarChar).Value = clsData.JenisID.ToUpper
                .Parameters.Add("@NoID", SqlDbType.VarChar).Value = clsData.NoID
                .Parameters.Add("@WargaNegara", SqlDbType.VarChar).Value = clsData.WargaNegara
                .Parameters.Add("@Negara", SqlDbType.VarChar).Value = clsData.Negara
                .Parameters.Add("@Nama", SqlDbType.VarChar).Value = clsData.Nama
                .Parameters.Add("@TempatLahir", SqlDbType.VarChar).Value = clsData.TempatLahir
                .Parameters.Add("@TglLahir", SqlDbType.DateTime).Value = clsData.TglLahir
                .Parameters.Add("@Alamat", SqlDbType.VarChar).Value = clsData.Alamat
                .Parameters.Add("@Pekerjaan", SqlDbType.VarChar).Value = clsData.Pekerjaan
                .Parameters.Add("@NoNPWP", SqlDbType.VarChar).Value = clsData.NoNPWP
                .Parameters.Add("@NoTelp", SqlDbType.VarChar).Value = clsData.NoTelp
                .Parameters.Add("@NoHP", SqlDbType.VarChar).Value = clsData.NoHP
                .Parameters.Add("@Remarks", SqlDbType.VarChar).Value = clsData.Remarks
                .Parameters.Add("@Title", SqlDbType.VarChar).Value = clsData.Title
                .Parameters.Add("@TglLahirStr", SqlDbType.VarChar).Value = clsData.TglLahirStr

            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub DeleteClient2(ByVal strPPATOrderID As String)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                    "DELETE NMS_traPPATOrderClient2 WHERE PPATOrderID=@PPATOrderID "

                .Parameters.Add("@PPATOrderID", SqlDbType.VarChar, 20).Value = strPPATOrderID
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub UpdateProcess(ByVal clsData As VO.PPATOrder)
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader
            Dim clsReturn As New VO.PPATOrder
            Try
                If Not SQL.bolUseTrans Then SQL.OpenConnection()
                With sqlcmdExecute
                    .Connection = SQL.sqlConn
                    .CommandText = _
                        "SELECT TOP 1 ProcessUserID FROM NMS_traPPATOrder " & _
                        "WHERE PPATOrderID=@PPATOrderID "

                    .Parameters.Add("@Status", SqlDbType.Int).Value = clsData.Status
                    .Parameters.Add("@ProcessBy", SqlDbType.VarChar).Value = UI.usUserApp.UserID
                    .Parameters.Add("@ProcessDate", SqlDbType.DateTime).Value = clsData.ProcessDate
                    .Parameters.Add("@ProcessRemarks", SqlDbType.VarChar).Value = clsData.ProcessRemarks
                    .Parameters.Add("@PPATOrderID", SqlDbType.VarChar).Value = clsData.PPATOrderID
                    .Parameters.Add("@ModifiedBy", SqlDbType.VarChar).Value = UI.usUserApp.UserID

                    If SQL.bolUseTrans Then .Transaction = SQL.sqlTrans
                End With
                sqlrdData = sqlcmdExecute.ExecuteReader(CommandBehavior.SingleResult)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        clsReturn.ProcessUserID = .Item("ProcessUserID")
                    End If
                    .Close()
                End With
                If Not SQL.bolUseTrans Then SQL.CloseConnection()
            Catch ex As Exception
                Throw ex
            End Try

            If clsReturn.ProcessUserID <> UI.usUserApp.UserID Then
                UI.usForm.frmMessageBox(UI.usUserApp.UserID & " tidak bisa memproses akta yang diproses oleh " & clsReturn.ProcessUserID)
                Exit Sub
            End If

            sqlcmdExecute.CommandText = ""
            With sqlcmdExecute
                .CommandText = _
                    "IF @Status=1 " & _
                    "UPDATE NMS_traPPATOrder " & _
                    "SET Status=@Status, ProcessBy='', ProcessDate=DraftDate, ProcessRemarks='', ModifiedBy=@ModifiedBy, ModifiedDate=GETDATE() " & _
                    "WHERE PPATOrderID=@PPATOrderID " & _
                    "ELSE " & _
                    "UPDATE NMS_traPPATOrder " & _
                    "SET Status=@Status, ProcessBy=@ProcessBy, ProcessDate=GETDATE(), ProcessRemarks=@ProcessRemarks, ModifiedBy=@ModifiedBy, ModifiedDate=GETDATE() " & _
                    "WHERE PPATOrderID=@PPATOrderID "
            End With

            UI.usForm.frmMessageBox("Update successful")
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub UpdateBPNFinish(ByVal clsData As VO.PPATOrder)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                    "IF @Status=2 " & _
                    "UPDATE NMS_traPPATOrder " & _
                    "SET Status=@Status, BPNFinishBy='', BPNFinishDate=DraftDate, BPNFinishRemarks='', ModifiedBy=@ModifiedBy, ModifiedDate=GETDATE() " & _
                    "WHERE PPATOrderID=@PPATOrderID " & _
                    "ELSE " & _
                    "UPDATE NMS_traPPATOrder " & _
                    "SET Status=@Status, BPNFinishBy=@BPNFinishBy, BPNFinishDate=@BPNFinishDate, BPNFinishRemarks=@BPNFinishRemarks, ModifiedBy=@ModifiedBy, ModifiedDate=GETDATE() " & _
                    "WHERE PPATOrderID=@PPATOrderID "

                .Parameters.Add("@Status", SqlDbType.Int).Value = clsData.Status
                .Parameters.Add("@BPNFinishBy", SqlDbType.VarChar).Value = UI.usUserApp.UserID
                .Parameters.Add("@BPNFinishDate", SqlDbType.DateTime).Value = clsData.BPNFinishDate
                .Parameters.Add("@BPNFinishRemarks", SqlDbType.VarChar).Value = clsData.BPNFinishRemarks
                .Parameters.Add("@PPATOrderID", SqlDbType.VarChar).Value = clsData.PPATOrderID
                .Parameters.Add("@ModifiedBy", SqlDbType.VarChar).Value = UI.usUserApp.UserID
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub UpdateCompleted(ByVal clsData As VO.PPATOrder)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                    "IF @Status=3 " & _
                    "UPDATE NMS_traPPATOrder " & _
                    "SET Status=@Status, CompletedBy='', CompletedDate=ProcessDate, CompletedRemarks='' " & _
                    "WHERE PPATOrderID=@PPATOrderID " & _
                    "ELSE " & _
                    "UPDATE NMS_traPPATOrder " & _
                    "SET Status=@Status, CompletedBy=@CompletedBy, CompletedDate=GETDATE(), CompletedRemarks=@CompletedRemarks " & _
                    "WHERE PPATOrderID=@PPATOrderID "

                .Parameters.Add("@Status", SqlDbType.Int).Value = clsData.Status
                .Parameters.Add("@CompletedBy", SqlDbType.VarChar).Value = UI.usUserApp.UserID
                .Parameters.Add("@CompletedDate", SqlDbType.DateTime).Value = clsData.CompletedDate
                .Parameters.Add("@CompletedRemarks", SqlDbType.VarChar).Value = clsData.CompletedRemarks
                .Parameters.Add("@PPATOrderID", SqlDbType.VarChar).Value = clsData.PPATOrderID
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub UpdateIsFalse(ByVal clsData As VO.PPATOrder)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                    "IF @IsFalse=0 " & _
                    "UPDATE NMS_traPPATOrder " & _
                    "SET IsFalse=@IsFalse, IsFalseBy='', IsFalseDate=DraftDate, IsFalseRemarks='', IsFalseLevel=3 " & _
                    "WHERE PPATOrderID=@PPATOrderID " & _
                    "ELSE " & _
                    "UPDATE NMS_traPPATOrder " & _
                    "SET IsFalse=@IsFalse, IsFalseBy=@IsFalseBy, IsFalseDate=GETDATE(), IsFalseRemarks=@IsFalseRemarks, IsFalseLevel=@IsFalseLevel " & _
                    "WHERE PPATOrderID=@PPATOrderID "

                .Parameters.Add("@IsFalse", SqlDbType.Bit).Value = clsData.IsFalse
                .Parameters.Add("@IsFalseRemarks", SqlDbType.VarChar).Value = clsData.IsFalseRemarks
                .Parameters.Add("@IsFalseBy", SqlDbType.VarChar).Value = UI.usUserApp.UserID
                .Parameters.Add("@PPATOrderID", SqlDbType.VarChar).Value = clsData.PPATOrderID
                .Parameters.Add("@IsFalseLevel", SqlDbType.Int).Value = clsData.IsFalseLevel
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Function CheckValidNoAkta(ByVal dtTglAkta As DateTime, ByVal strNoAkta As String, ByVal strPPATOrderID As String) As Boolean
            Dim bolValid As Boolean = False
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader
            Try
                If Not SQL.bolUseTrans Then SQL.OpenConnection()
                With sqlcmdExecute
                    .Connection = SQL.sqlConn
                    .CommandText = _
                        "SELECT TOP 1 1 AS Result " & _
                        "FROM NMS_traPPATOrder " & _
                        "WHERE NoAkta =@NoAkta AND NoAkta <>'' AND CONVERT(VARCHAR(6),TglAkta,112)=CONVERT(VARCHAR(6),@TglAkta,112)  "

                    If strPPATOrderID <> "" Then
                        .CommandText += "AND PPATOrderID<>@PPATOrderID"
                    End If
                    .Parameters.Add("@TglAkta", SqlDbType.DateTime).Value = dtTglAkta
                    .Parameters.Add("@NoAkta", SqlDbType.VarChar).Value = strNoAkta
                    .Parameters.Add("@PPATOrderID", SqlDbType.VarChar).Value = strPPATOrderID

                    If SQL.bolUseTrans Then .Transaction = SQL.sqlTrans
                End With
                sqlrdData = sqlcmdExecute.ExecuteReader(CommandBehavior.SingleRow)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        bolValid = .Item("Result")
                    End If
                    .Close()
                End With
                If Not SQL.bolUseTrans Then SQL.CloseConnection()
            Catch ex As Exception
                Throw ex
            End Try
            Return bolValid
        End Function



    End Class

End Namespace

Imports System.Data.SqlClient

Namespace DL

    Public Class NotaryOrder

        Public Shared Function NotaryOrderID(ByVal dtTglAkta As DateTime) As String
            Dim strNotaryOrderID As String = ""
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
                    "    SET @TMP = ISNULL(CAST((SELECT Top 1 RIGHT(NotaryOrderID, 6) " & _
                    "	 FROM NMS_traNotaryOrder WHERE Year(DraftDate) = @Year AND Month(DraftDate) = @Month AND SUBSTRING(NotaryOrderID,3,3) = @LocationInitial " & _
                    "	 Order By NotaryOrderID Desc) as int),0) + 1 " & _
                    "    SELECT('NT' + @LocationInitial +  Right(Cast(@Year as varchar(4)), 2) + " & _
                    "    dbo.udf_strZero(cast(@Month as varchar(2)),2,0) + dbo.udf_strZero(Cast(@TMP as varchar(6)),6,0)) AS NotaryOrderID " & _
                    "END "

                    .Parameters.Add("@TglAkta", SqlDbType.DateTime).Value = dtTglAkta
                    .Parameters.Add("@LocationInitial", SqlDbType.VarChar).Value = UI.usUserApp.LocationID

                    If SQL.bolUseTrans Then .Transaction = SQL.sqlTrans
                End With
                sqlrdData = sqlcmdExecute.ExecuteReader(CommandBehavior.SingleRow)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        strNotaryOrderID = .Item("NotaryOrderID")
                    End If
                    .Close()
                End With
                If Not SQL.bolUseTrans Then SQL.CloseConnection()
            Catch ex As Exception
                Throw ex
            End Try
            Return strNotaryOrderID
        End Function

        Public Shared Function ListData(ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime, ByVal intStatus As Integer, Optional ByVal IsFileBPNExport As Boolean = False, Optional ByVal IsFilterProcessBy As Boolean = False) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                "SELECT A.NotaryOrderID, CASE JenisAkta WHEN 0 THEN 'BUKU DAFTAR AKTA' WHEN 1 THEN 'SURAT YANG DISAHKAN' WHEN 2 THEN 'SURAT YANG DIBUKUKAN' END AS JenisAkta, NoUrut, NoBulanan, TglAkta, SifatAkta, JenisTransaksi, " & _
                "CASE Status WHEN 1 THEN 'DRAFT' WHEN 2 THEN 'PROCESS' WHEN 3 THEN 'COMPLETED' END AS Status, FileLocation, Remarks, " & _
                "DraftBy, DraftDate, ProcessBy, ProcessDate, ProcessRemarks, CompletedBy, CompletedDate, CompletedRemarks, IsFalse, IsFalseBy, IsFalseDate, IsFalseRemarks, " & _
                "CASE IsFalseLevel WHEN 0 THEN 'DRAFT' WHEN 1 THEN 'PROCESS' WHEN 2 THEN 'DRAFT AND PROCESS' WHEN 3 THEN '' END AS IsFalseLevelStr, B.NoID ,B.Nama, C.NoID AS NoID2, C.Nama AS Nama2 FROM NMS_traNotaryOrder A   " & _
                "INNER JOIN (SELECT NotaryOrderID, NoID, Nama FROM NMS_traNotaryOrderClient1 WHERE [INDEX]=1) B ON A.NotaryOrderID =B.NotaryOrderID " & _
                "LEFT JOIN (SELECT NotaryOrderID, NoID, Nama FROM NMS_traNotaryOrderClient2 WHERE [INDEX]=1) C ON A.NotaryOrderID =C.NotaryOrderID " & _
                "WHERE CONVERT(VARCHAR(8),TglAkta,112)>=  CONVERT(VARCHAR(8), @DateFrom,112) " & _
                "AND CONVERT(VARCHAR(8),TglAkta,112)<= CONVERT(VARCHAR(8), @DateTo,112)  "

                If intStatus > 0 Then
                    .CommandText += " AND Status=@Status "
                End If

                If IsFileBPNExport = True Then
                    .CommandText += " AND A.NoUrut <>'' AND A.NoBulanan <>'' "
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

        Public Shared Function ListClient1(ByVal strNotaryOrderID As String) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                    "SELECT NotaryOrderID, [Index], JenisID, NoID, WargaNegara, Negara, Nama, TempatLahir, TglLahir, Alamat, Pekerjaan, NoNPWP, NoTelp, NoHP, Remarks, Title, TglLahirStr FROM NMS_traNotaryOrderClient1 " & _
                    "WHERE NotaryOrderID=@NotaryOrderID " & _
                    "ORDER BY [Index] "
                .Parameters.Add("@NotaryOrderID", SqlDbType.VarChar, 20).Value = strNotaryOrderID
            End With
            Return SQL.QueryDataTable(sqlcmdExecute)
        End Function

        Public Shared Function ListClient2(ByVal strNotaryOrderID As String) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                    "SELECT NotaryOrderID, [Index], JenisID, NoID, WargaNegara, Negara, Nama, TempatLahir, TglLahir, Alamat, Pekerjaan, NoNPWP, NoTelp, NoHP, Remarks, Title, TglLahirStr FROM NMS_traNotaryOrderClient2 " & _
                    "WHERE NotaryOrderID=@NotaryOrderID " & _
                    "ORDER BY [Index] "
                .Parameters.Add("@NotaryOrderID", SqlDbType.VarChar, 20).Value = strNotaryOrderID
            End With
            Return SQL.QueryDataTable(sqlcmdExecute)
        End Function

        Public Shared Function ListClient3(ByVal strNotaryOrderID As String) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                    "SELECT NotaryOrderID, [Index], JenisID, NoID, WargaNegara, Negara, Nama, TempatLahir, TglLahir, Alamat, Pekerjaan, NoNPWP, NoTelp, NoHP, Remarks, Title, TglLahirStr FROM NMS_traNotaryOrderClient3 " & _
                    "WHERE NotaryOrderID=@NotaryOrderID " & _
                    "ORDER BY [Index] "
                .Parameters.Add("@NotaryOrderID", SqlDbType.VarChar, 20).Value = strNotaryOrderID
            End With
            Return SQL.QueryDataTable(sqlcmdExecute)
        End Function

        Public Shared Function GetDetail(ByVal strNotaryOrderID As String) As VO.NotaryOrder
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader
            Dim clsReturn As New VO.NotaryOrder
            Try
                If Not SQL.bolUseTrans Then SQL.OpenConnection()
                With sqlcmdExecute
                    .Connection = SQL.sqlConn
                    .CommandText = _
                        "SELECT NotaryOrderID, NoUrut, NoBulanan, TglAkta, TglDidaftarkan, SifatAkta, JenisTransaksi, CASE Status WHEN 1 THEN 'DRAFT' WHEN 2 THEN 'PROCESS' WHEN 3 THEN 'COMPLETED' END AS Status, " & _
                        "FileLocation, Remarks, DraftBy, DraftDate, ProcessBy, ProcessDate, CompletedBy, CompletedDate, JenisAkta, ProcessUserID, ExpInterval FROM NMS_traNotaryOrder " & _
                        "WHERE NotaryOrderID=@NotaryOrderID "

                    .Parameters.Add("@NotaryOrderID", SqlDbType.VarChar, 20).Value = strNotaryOrderID

                    If SQL.bolUseTrans Then .Transaction = SQL.sqlTrans
                End With
                sqlrdData = sqlcmdExecute.ExecuteReader(CommandBehavior.SingleResult)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        clsReturn.NotaryOrderID = .Item("NotaryOrderID")
                        clsReturn.JenisAkta = .Item("JenisAkta")
                        clsReturn.NoUrut = .Item("NoUrut")
                        clsReturn.NoBulanan = .Item("NoBulanan")
                        clsReturn.TglAkta = .Item("TglAkta")
                        clsReturn.TglDidaftarkan = .Item("TglDidaftarkan")
                        clsReturn.SifatAkta = .Item("SifatAkta")
                        clsReturn.JenisTransaksi = .Item("JenisTransaksi")
                        clsReturn.StatusStr = .Item("Status")
                        clsReturn.FileLocation = .Item("FileLocation")
                        clsReturn.Remarks = .Item("Remarks")
                        clsReturn.DraftBy = .Item("DraftBy")
                        clsReturn.DraftDate = .Item("DraftDate")
                        clsReturn.ProcessBy = .Item("ProcessBy")
                        clsReturn.ProcessDate = .Item("ProcessDate")
                        clsReturn.CompletedBy = .Item("CompletedBy")
                        clsReturn.CompletedDate = .Item("CompletedDate")
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

        Public Shared Sub SaveAllData(ByVal bolNew As Boolean, ByVal strNotaryOrderID As String, ByVal clsData As VO.NotaryOrder, ByVal clsClient1() As VO.NotaryClientDet1, ByVal clsClient2() As VO.NotaryClientDet2, ByVal clsClient3() As VO.NotaryClientDet3)
            Dim intI As Integer = 1
            Dim intI2 As Integer = 1
            Dim intI3 As Integer = 1

            DL.SQL.OpenConnection()
            DL.SQL.BeginTransaction()
            Try
                'Save Header
                DL.NotaryOrder.SaveData(bolNew, clsData)

                'Save Client1
                If Not bolNew Then DL.NotaryOrder.DeleteClient1(strNotaryOrderID)
                For Each DataItem As VO.NotaryClientDet1 In clsClient1
                    DL.NotaryOrder.SaveClient1(DataItem)
                    intI += 1
                Next

                'Save Client2
                If Not bolNew Then DL.NotaryOrder.DeleteClient2(strNotaryOrderID)
                For Each DataItem As VO.NotaryClientDet2 In clsClient2
                    DL.NotaryOrder.SaveClient2(DataItem)
                    intI2 += 1
                Next

                'Save Client3
                If Not bolNew Then DL.NotaryOrder.DeleteClient3(strNotaryOrderID)
                For Each DataItem As VO.NotaryClientDet3 In clsClient3
                    DL.NotaryOrder.SaveClient3(DataItem)
                    intI3 += 1
                Next


                DL.SQL.CommitTransaction()
            Catch ex As Exception
                DL.SQL.RollBackTransaction()
                Throw ex
            Finally
                DL.SQL.CloseConnection()
            End Try


        End Sub

        Public Shared Sub SaveData(ByVal bolNew As Boolean, ByVal clsData As VO.NotaryOrder)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                If bolNew Then
                    .CommandText = _
                        "INSERT INTO NMS_traNotaryOrder (NotaryOrderID, NoUrut, NoBulanan, TglAkta, SifatAkta, JenisTransaksi, FileLocation, Remarks, DraftBy, DraftDate, ModifiedBy, TglDidaftarkan, JenisAkta, ProcessUserID, ExpInterval) " & _
                        "VALUES (@NotaryOrderID, @NoUrut, @NoBulanan, @TglAkta, @SifatAkta, @JenisTransaksi, @FileLocation, @Remarks, @DraftBy, GETDATE(), @ModifiedBy, @TglDidaftarkan, @JenisAkta, @ProcessUserID, @ExpInterval) "

                Else
                    .CommandText = _
                        "UPDATE NMS_traNotaryOrder SET " & _
                        "   NoUrut=@NoUrut, NoBulanan=@NoBulanan, TglAkta=@TglAkta, SifatAkta=@SifatAkta, JenisTransaksi=@JenisTransaksi, " & _
                        "   Remarks=@Remarks, FileLocation=@FileLocation, ModifiedBy=@ModifiedBy, ModifiedDate=GETDATE(), TglDidaftarkan=@TglDidaftarkan, " & _
                        "   JenisAkta=@JenisAkta, ProcessUserID=@ProcessUserID, ExpInterval=@ExpInterval " & _
                        "   WHERE NotaryOrderID=@NotaryOrderID "
                End If

                .Parameters.Add("@NotaryOrderID", SqlDbType.VarChar).Value = clsData.NotaryOrderID
                .Parameters.Add("@JenisAkta", SqlDbType.Int).Value = clsData.JenisAkta
                .Parameters.Add("@NoUrut", SqlDbType.VarChar).Value = clsData.NoUrut
                .Parameters.Add("@NoBulanan", SqlDbType.VarChar).Value = clsData.NoBulanan
                .Parameters.Add("@TglAkta", SqlDbType.DateTime).Value = clsData.TglAkta
                .Parameters.Add("@SifatAkta", SqlDbType.VarChar).Value = clsData.SifatAkta
                .Parameters.Add("@JenisTransaksi", SqlDbType.VarChar).Value = clsData.JenisTransaksi.ToUpper
                .Parameters.Add("@FileLocation", SqlDbType.VarChar).Value = clsData.FileLocation
                .Parameters.Add("@Remarks", SqlDbType.VarChar).Value = clsData.Remarks
                .Parameters.Add("@DraftBy", SqlDbType.VarChar).Value = UI.usUserApp.UserID
                .Parameters.Add("@ModifiedBy", SqlDbType.VarChar).Value = UI.usUserApp.UserID
                .Parameters.Add("@TglDidaftarkan", SqlDbType.DateTime).Value = clsData.TglDidaftarkan
                .Parameters.Add("@ProcessUserID", SqlDbType.VarChar).Value = clsData.ProcessUserID
                .Parameters.Add("@ExpInterval", SqlDbType.Int).Value = clsData.ExpInterval

            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub SaveClient1(ByVal clsData As VO.NotaryClientDet1)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                "INSERT INTO NMS_traNotaryOrderClient1 (NotaryOrderID, [Index], JenisID, NoID, WargaNegara, Negara, Nama, TempatLahir, TglLahir, Alamat, Pekerjaan, NoNPWP, NoTelp, NoHP, Remarks, Title, TglLahirStr) " & _
                "VALUES (@NotaryOrderID, @Index, @JenisID, @NoID, @WargaNegara, @Negara, @Nama, @TempatLahir, @TglLahir, @Alamat, @Pekerjaan, @NoNPWP, @NoTelp, @NoHP, @Remarks, @Title, @TglLahirStr) "

                .Parameters.Add("@NotaryOrderID", SqlDbType.VarChar).Value = clsData.NotaryOrderID
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

        Public Shared Sub DeleteHeader(ByVal strNotaryOrderID As String)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                    "DELETE NMS_traNotaryOrder WHERE NotaryOrderID=@NotaryOrderID "

                .Parameters.Add("@NotaryOrderID", SqlDbType.VarChar, 20).Value = strNotaryOrderID
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub DeleteClient1(ByVal strNotaryOrderID As String)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                    "DELETE NMS_traNotaryOrderClient1 WHERE NotaryOrderID=@NotaryOrderID "

                .Parameters.Add("@NotaryOrderID", SqlDbType.VarChar, 20).Value = strNotaryOrderID
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub SaveClient2(ByVal clsData As VO.NotaryClientDet2)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                "INSERT INTO NMS_traNotaryOrderClient2 (NotaryOrderID, [Index], JenisID, NoID, WargaNegara, Negara, Nama, TempatLahir, TglLahir, Alamat, Pekerjaan, NoNPWP, NoTelp, NoHP, Remarks, Title, TglLahirStr) " & _
                "VALUES (@NotaryOrderID, @Index, @JenisID, @NoID, @WargaNegara, @Negara, @Nama, @TempatLahir, @TglLahir, @Alamat, @Pekerjaan, @NoNPWP, @NoTelp, @NoHP, @Remarks, @Title, @TglLahirStr) "

                .Parameters.Add("@NotaryOrderID", SqlDbType.VarChar).Value = clsData.NotaryOrderID
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

        Public Shared Sub DeleteClient2(ByVal strNotaryOrderID As String)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                    "DELETE NMS_traNotaryOrderClient2 WHERE NotaryOrderID=@NotaryOrderID "

                .Parameters.Add("@NotaryOrderID", SqlDbType.VarChar, 20).Value = strNotaryOrderID
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub SaveClient3(ByVal clsData As VO.NotaryClientDet3)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                "INSERT INTO NMS_traNotaryOrderClient3 (NotaryOrderID, [Index], JenisID, NoID, WargaNegara, Negara, Nama, TempatLahir, TglLahir, Alamat, Pekerjaan, NoNPWP, NoTelp, NoHP, Remarks, Title, TglLahirStr) " & _
                "VALUES (@NotaryOrderID, @Index, @JenisID, @NoID, @WargaNegara, @Negara, @Nama, @TempatLahir, @TglLahir, @Alamat, @Pekerjaan, @NoNPWP, @NoTelp, @NoHP, @Remarks, @Title, @TglLahirStr) "

                .Parameters.Add("@NotaryOrderID", SqlDbType.VarChar).Value = clsData.NotaryOrderID
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


        Public Shared Sub DeleteClient3(ByVal strNotaryOrderID As String)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                    "DELETE NMS_traNotaryOrderClient3 WHERE NotaryOrderID=@NotaryOrderID "

                .Parameters.Add("@NotaryOrderID", SqlDbType.VarChar, 20).Value = strNotaryOrderID
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub UpdateProcess(ByVal clsData As VO.NotaryOrder)
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader
            Dim clsReturn As New VO.NotaryOrder
            Try
                If Not SQL.bolUseTrans Then SQL.OpenConnection()
                With sqlcmdExecute
                    .Connection = SQL.sqlConn
                    .CommandText = _
                        "SELECT TOP 1 ProcessUserID FROM NMS_traNotaryOrder " & _
                        "WHERE NotaryOrderID=@NotaryOrderID "

                    .Parameters.Add("@Status", SqlDbType.Int).Value = clsData.Status
                    .Parameters.Add("@ProcessBy", SqlDbType.VarChar).Value = UI.usUserApp.UserID
                    .Parameters.Add("@ProcessRemarks", SqlDbType.VarChar).Value = clsData.ProcessRemarks
                    .Parameters.Add("@NotaryOrderID", SqlDbType.VarChar).Value = clsData.NotaryOrderID
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
                    "UPDATE NMS_traNotaryOrder " & _
                    "SET Status=@Status, ProcessBy='', ProcessDate=DraftDate, ProcessRemarks='', ModifiedBy=@ModifiedBy, ModifiedDate=GETDATE() " & _
                    "WHERE NotaryOrderID=@NotaryOrderID " & _
                    "ELSE " & _
                    "UPDATE NMS_traNotaryOrder " & _
                    "SET Status=@Status, ProcessBy=@ProcessBy, ProcessDate=GETDATE(), ProcessRemarks=@ProcessRemarks, ModifiedBy=@ModifiedBy, ModifiedDate=GETDATE() " & _
                    "WHERE NotaryOrderID=@NotaryOrderID "
            End With
            UI.usForm.frmMessageBox("Update successful")
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub UpdateCompleted(ByVal clsData As VO.NotaryOrder)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                    "IF @Status=2 " & _
                    "UPDATE NMS_traNotaryOrder " & _
                    "SET Status=@Status, CompletedBy='', CompletedDate=ProcessDate, CompletedRemarks='' " & _
                    "WHERE NotaryOrderID=@NotaryOrderID " & _
                    "ELSE " & _
                    "UPDATE NMS_traNotaryOrder " & _
                    "SET Status=@Status, CompletedBy=@CompletedBy, CompletedDate=GETDATE(), CompletedRemarks=@CompletedRemarks " & _
                    "WHERE NotaryOrderID=@NotaryOrderID "

                .Parameters.Add("@Status", SqlDbType.Int).Value = clsData.Status
                .Parameters.Add("@CompletedBy", SqlDbType.VarChar).Value = UI.usUserApp.UserID
                .Parameters.Add("@CompletedRemarks", SqlDbType.VarChar).Value = clsData.CompletedRemarks
                .Parameters.Add("@NotaryOrderID", SqlDbType.VarChar).Value = clsData.NotaryOrderID
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub UpdateIsFalse(ByVal clsData As VO.NotaryOrder)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                    "IF @IsFalse=0 " & _
                    "UPDATE NMS_traNotaryOrder " & _
                    "SET IsFalse=@IsFalse, IsFalseBy='', IsFalseDate=DraftDate, IsFalseRemarks='', IsFalseLevel=3 " & _
                    "WHERE NotaryOrderID=@NotaryOrderID " & _
                    "ELSE " & _
                    "UPDATE NMS_traNotaryOrder " & _
                    "SET IsFalse=@IsFalse, IsFalseBy=@IsFalseBy, IsFalseDate=GETDATE(), IsFalseRemarks=@IsFalseRemarks, IsFalseLevel=@IsFalseLevel " & _
                    "WHERE NotaryOrderID=@NotaryOrderID "

                .Parameters.Add("@IsFalse", SqlDbType.Bit).Value = clsData.IsFalse
                .Parameters.Add("@IsFalseBy", SqlDbType.VarChar).Value = UI.usUserApp.UserID
                .Parameters.Add("@IsFalseRemarks", SqlDbType.VarChar).Value = clsData.IsFalseRemarks
                .Parameters.Add("@NotaryOrderID", SqlDbType.VarChar).Value = clsData.NotaryOrderID
                .Parameters.Add("@IsFalseLevel", SqlDbType.Int).Value = clsData.IsFalseLevel
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Function CheckValidNoBulanan(ByVal dtTglAkta As DateTime, ByVal strNoBulanan As String, ByVal strNotaryOrderID As String) As Boolean
            Dim bolValid As Boolean = False
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader
            Try
                If Not SQL.bolUseTrans Then SQL.OpenConnection()
                With sqlcmdExecute
                    .Connection = SQL.sqlConn
                    .CommandText = _
                        "SELECT TOP 1 1 AS Result " & _
                        "FROM NMS_traNotaryOrder " & _
                        "WHERE NoBulanan =@NoBulanan AND NoBulanan <>'' AND CONVERT(VARCHAR(6),TglAkta,112)=CONVERT(VARCHAR(6),@TglAkta,112)  "

                    If strNotaryOrderID <> "" Then
                        .CommandText += "AND NotaryOrderID<>@NotaryOrderID"
                    End If
                    .Parameters.Add("@TglAkta", SqlDbType.DateTime).Value = dtTglAkta
                    .Parameters.Add("@NoBulanan", SqlDbType.VarChar).Value = strNoBulanan
                    .Parameters.Add("@NotaryOrderID", SqlDbType.VarChar).Value = strNotaryOrderID

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

        Public Shared Function CheckValidNoUrut(ByVal strNoUrut As String, ByVal strNotaryOrderID As String) As Boolean
            Dim bolValid As Boolean = False
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader
            Try
                If Not SQL.bolUseTrans Then SQL.OpenConnection()
                With sqlcmdExecute
                    .Connection = SQL.sqlConn
                    .CommandText = _
                        "SELECT TOP 1 1 AS Result " & _
                        "FROM NMS_traNotaryOrder " & _
                        "WHERE NoUrut =@NoUrut AND NoUrut <>'' "

                    If strNotaryOrderID <> "" Then
                        .CommandText += "AND NotaryOrderID<>@NotaryOrderID"
                    End If

                    .Parameters.Add("@NoUrut", SqlDbType.VarChar).Value = strNoUrut
                    .Parameters.Add("@NotaryOrderID", SqlDbType.VarChar).Value = strNotaryOrderID

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

        Public Shared Function GetPihakI(ByVal strNotaryOrderID As String) As VO.NotaryClientDet1
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader
            Dim clsReturn As New VO.NotaryClientDet1
            Try
                If Not SQL.bolUseTrans Then SQL.OpenConnection()
                With sqlcmdExecute
                    .Connection = SQL.sqlConn
                    .CommandText = _
                        "SELECT Nama, TempatLahir AS TempatLahir, " & _
                        "CASE WargaNegara WHEN 'WNI' THEN 'Warga Negara Indonesia' " & _
                        "WHEN 'WNA' THEN 'Warga Negara Asing dari Negara ' + Negara ELSE WargaNegara END AS WargaNegara, Pekerjaan, Alamat, " & _
                        "CASE JenisID WHEN 'KTP' THEN 'Kartu Tanda Penduduk Republik Indonesia' ELSE JenisID END AS JenisID, NoID, Title, TglLahirStr FROM NMS_traNotaryOrderClient1 " & _
                        "WHERE NotaryOrderID=@NotaryOrderID AND [INDEX]=1 "

                    .Parameters.Add("@NotaryOrderID", SqlDbType.VarChar, 20).Value = strNotaryOrderID

                    If SQL.bolUseTrans Then .Transaction = SQL.sqlTrans
                End With
                sqlrdData = sqlcmdExecute.ExecuteReader(CommandBehavior.SingleResult)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        clsReturn.Nama = .Item("Nama")
                        clsReturn.TempatLahir = .Item("TempatLahir")
                        clsReturn.TglLahirStr = .Item("TglLahirStr")
                        clsReturn.WargaNegara = .Item("WargaNegara")
                        clsReturn.Pekerjaan = .Item("Pekerjaan")
                        clsReturn.Alamat = .Item("Alamat")
                        clsReturn.JenisID = .Item("JenisID")
                        clsReturn.NoID = .Item("NoID")
                        clsReturn.Title = .Item("Title")
                    End If
                    .Close()
                End With
                If Not SQL.bolUseTrans Then SQL.CloseConnection()
            Catch ex As Exception
                Throw ex
            End Try
            Return clsReturn
        End Function

        Public Shared Function GetPihakI2(ByVal strNotaryOrderID As String) As VO.NotaryClientDet1
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader
            Dim clsReturn As New VO.NotaryClientDet1
            Try
                If Not SQL.bolUseTrans Then SQL.OpenConnection()
                With sqlcmdExecute
                    .Connection = SQL.sqlConn
                    .CommandText = _
                        "SELECT Nama, TempatLahir AS TempatLahir, " & _
                        "CASE WargaNegara WHEN 'WNI' THEN 'Warga Negara Indonesia' " & _
                        "WHEN 'WNA' THEN 'Warga Negara Asing dari Negara ' + Negara ELSE WargaNegara END AS WargaNegara, Pekerjaan, Alamat, " & _
                        "CASE JenisID WHEN 'KTP' THEN 'Kartu Tanda Penduduk Republik Indonesia' ELSE JenisID END AS JenisID, NoID, Title, TglLahirStr FROM NMS_traNotaryOrderClient1 " & _
                        "WHERE NotaryOrderID=@NotaryOrderID AND [INDEX]=2 "

                    .Parameters.Add("@NotaryOrderID", SqlDbType.VarChar, 20).Value = strNotaryOrderID

                    If SQL.bolUseTrans Then .Transaction = SQL.sqlTrans
                End With
                sqlrdData = sqlcmdExecute.ExecuteReader(CommandBehavior.SingleResult)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        clsReturn.Nama = .Item("Nama")
                        clsReturn.TempatLahir = .Item("TempatLahir")
                        clsReturn.TglLahirStr = .Item("TglLahirStr")
                        clsReturn.WargaNegara = .Item("WargaNegara")
                        clsReturn.Pekerjaan = .Item("Pekerjaan")
                        clsReturn.Alamat = .Item("Alamat")
                        clsReturn.JenisID = .Item("JenisID")
                        clsReturn.NoID = .Item("NoID")
                        clsReturn.Title = .Item("Title")
                        clsReturn.TglLahirStr = .Item("TglLahirStr")
                    End If
                    .Close()
                End With
                If Not SQL.bolUseTrans Then SQL.CloseConnection()
            Catch ex As Exception
                Throw ex
            End Try
            Return clsReturn
        End Function

        Public Shared Function GetPihakII(ByVal strNotaryOrderID As String) As VO.NotaryClientDet2
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader
            Dim clsReturn As New VO.NotaryClientDet2
            Try
                If Not SQL.bolUseTrans Then SQL.OpenConnection()
                With sqlcmdExecute
                    .Connection = SQL.sqlConn
                    .CommandText = _
                        "SELECT Nama, TempatLahir AS TempatLahir, " & _
                        "CASE WargaNegara WHEN 'WNI' THEN 'Warga Negara Indonesia' " & _
                        "WHEN 'WNA' THEN 'Warga Negara Asing dari Negara ' + Negara ELSE WargaNegara END AS WargaNegara, Pekerjaan, Alamat, " & _
                        "CASE JenisID WHEN 'KTP' THEN 'Kartu Tanda Penduduk Republik Indonesia' ELSE JenisID END AS JenisID, NoID, Title, TglLahirStr FROM NMS_traNotaryOrderClient2 " & _
                        "WHERE NotaryOrderID=@NotaryOrderID AND [INDEX]=1 "

                    .Parameters.Add("@NotaryOrderID", SqlDbType.VarChar, 20).Value = strNotaryOrderID

                    If SQL.bolUseTrans Then .Transaction = SQL.sqlTrans
                End With
                sqlrdData = sqlcmdExecute.ExecuteReader(CommandBehavior.SingleResult)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        clsReturn.Nama = .Item("Nama")
                        clsReturn.TempatLahir = .Item("TempatLahir")
                        clsReturn.TglLahirStr = .Item("TglLahirStr")
                        clsReturn.WargaNegara = .Item("WargaNegara")
                        clsReturn.Pekerjaan = .Item("Pekerjaan")
                        clsReturn.Alamat = .Item("Alamat")
                        clsReturn.JenisID = .Item("JenisID")
                        clsReturn.NoID = .Item("NoID")
                        clsReturn.Title = .Item("Title")
                        clsReturn.TglLahirStr = .Item("TglLahirStr")
                    End If
                    .Close()
                End With
                If Not SQL.bolUseTrans Then SQL.CloseConnection()
            Catch ex As Exception
                Throw ex
            End Try
            Return clsReturn
        End Function
        
        Public Shared Function GetPihakII2(ByVal strNotaryOrderID As String) As VO.NotaryClientDet2
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader
            Dim clsReturn As New VO.NotaryClientDet2
            Try
                If Not SQL.bolUseTrans Then SQL.OpenConnection()
                With sqlcmdExecute
                    .Connection = SQL.sqlConn
                    .CommandText = _
                        "SELECT Nama, TempatLahir AS TempatLahir, " & _
                        "CASE WargaNegara WHEN 'WNI' THEN 'Warga Negara Indonesia' " & _
                        "WHEN 'WNA' THEN 'Warga Negara Asing dari Negara ' + Negara ELSE WargaNegara END AS WargaNegara, Pekerjaan, Alamat, " & _
                        "CASE JenisID WHEN 'KTP' THEN 'Kartu Tanda Penduduk Republik Indonesia' ELSE JenisID END AS JenisID, NoID, Title, TglLahirStr FROM NMS_traNotaryOrderClient2 " & _
                        "WHERE NotaryOrderID=@NotaryOrderID AND [INDEX]=2 "

                    .Parameters.Add("@NotaryOrderID", SqlDbType.VarChar, 20).Value = strNotaryOrderID

                    If SQL.bolUseTrans Then .Transaction = SQL.sqlTrans
                End With
                sqlrdData = sqlcmdExecute.ExecuteReader(CommandBehavior.SingleResult)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        clsReturn.Nama = .Item("Nama")
                        clsReturn.TempatLahir = .Item("TempatLahir")
                        clsReturn.TglLahirStr = .Item("TglLahirStr")
                        clsReturn.WargaNegara = .Item("WargaNegara")
                        clsReturn.Pekerjaan = .Item("Pekerjaan")
                        clsReturn.Alamat = .Item("Alamat")
                        clsReturn.JenisID = .Item("JenisID")
                        clsReturn.NoID = .Item("NoID")
                        clsReturn.Title = .Item("Title")
                        clsReturn.TglLahirStr = .Item("TglLahirStr")
                    End If
                    .Close()
                End With
                If Not SQL.bolUseTrans Then SQL.CloseConnection()
            Catch ex As Exception
                Throw ex
            End Try
            Return clsReturn
        End Function
       
    End Class

End Namespace

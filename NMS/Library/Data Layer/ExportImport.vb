Imports System.Data.SqlClient

Namespace DL

    Public Class ExportImport

        Public Shared Function ListNotaryOrder(ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime) As DataSet
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                "SELECT NotaryOrderID, NoUrut, NoBulanan, TglAkta, SifatAkta, JenisTransaksi, Status, FileLocation, Remarks, " & _
                "DraftBy, DraftDate, ProcessBy, ProcessDate, ProcessRemarks, CompletedBy, CompletedDate, CompletedRemarks, " & _
                "IsFalse, IsFalseBy, IsFalseDate, IsFalseRemarks, ModifiedBy, ModifiedDate, TglDidaftarkan, JenisAkta, IsFalseLevel FROM NMS_traNotaryOrder " & _
                "WHERE CONVERT(VARCHAR(8),TglAkta,112)>=  CONVERT(VARCHAR(8), @DateFrom,112) " & _
                "AND CONVERT(VARCHAR(8),TglAkta,112)<= CONVERT(VARCHAR(8), @DateTo,112)  "

                .Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = dtmDateFrom
                .Parameters.Add("@DateTo", SqlDbType.DateTime).Value = dtmDateTo
            End With
            Return SQL.QueryDataSet(sqlcmdExecute)
        End Function

        Public Shared Function ListNotaryOrderClient1(ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime) As DataSet
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                    "SELECT A.NotaryOrderID, [Index], JenisID, NoID, WargaNegara, Negara, Nama, TempatLahir, " & _
                    "TglLahir, Alamat, NoNPWP, NoTelp, NoHP, A.Remarks, Pekerjaan, Title, TglLahirStr FROM NMS_traNotaryOrderClient1 A " & _
                    "INNER JOIN NMS_traNotaryOrder B ON A.NotaryOrderID =B.NotaryOrderID  " & _
                    "WHERE CONVERT(VARCHAR(8),TglAkta,112)>=  CONVERT(VARCHAR(8), @DateFrom,112) " & _
                    "AND CONVERT(VARCHAR(8),TglAkta,112)<= CONVERT(VARCHAR(8), @DateTo,112)  "

                .Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = dtmDateFrom
                .Parameters.Add("@DateTo", SqlDbType.DateTime).Value = dtmDateTo
            End With
            Return SQL.QueryDataSet(sqlcmdExecute)
        End Function

        Public Shared Function ListNotaryOrderClient2(ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime) As DataSet
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                    "SELECT A.NotaryOrderID, [Index], JenisID, NoID, WargaNegara, Negara, Nama, TempatLahir, " & _
                    "TglLahir, Alamat, NoNPWP, NoTelp, NoHP, A.Remarks, Pekerjaan, Title, TglLahirStr FROM NMS_traNotaryOrderClient2 A " & _
                    "INNER JOIN NMS_traNotaryOrder B ON A.NotaryOrderID =B.NotaryOrderID  " & _
                    "WHERE CONVERT(VARCHAR(8),TglAkta,112)>=  CONVERT(VARCHAR(8), @DateFrom,112) " & _
                    "AND CONVERT(VARCHAR(8),TglAkta,112)<= CONVERT(VARCHAR(8), @DateTo,112)  "

                .Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = dtmDateFrom
                .Parameters.Add("@DateTo", SqlDbType.DateTime).Value = dtmDateTo
            End With
            Return SQL.QueryDataSet(sqlcmdExecute)
        End Function

        Public Shared Function ListNotaryOrderClient3(ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime) As DataSet
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                    "SELECT A.NotaryOrderID, [Index], JenisID, NoID, WargaNegara, Negara, Nama, TempatLahir, " & _
                    "TglLahir, Alamat, NoNPWP, NoTelp, NoHP, A.Remarks, Pekerjaan, Title, TglLahirStr FROM NMS_traNotaryOrderClient3 A " & _
                    "INNER JOIN NMS_traNotaryOrder B ON A.NotaryOrderID =B.NotaryOrderID  " & _
                    "WHERE CONVERT(VARCHAR(8),TglAkta,112)>=  CONVERT(VARCHAR(8), @DateFrom,112) " & _
                    "AND CONVERT(VARCHAR(8),TglAkta,112)<= CONVERT(VARCHAR(8), @DateTo,112)  "

                .Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = dtmDateFrom
                .Parameters.Add("@DateTo", SqlDbType.DateTime).Value = dtmDateTo
            End With
            Return SQL.QueryDataSet(sqlcmdExecute)
        End Function

        Public Shared Function PPATOrder(ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime) As DataSet
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                "SELECT PPATOrderID, NoAkta, TglAkta, JenisTransaksi, JenisNoHak, LetakTanahBangunan ,LuasTanahM2,LuasBangunanM2, " & _
                "HargaTransaksi,SPPTPBBNOPTahun,SPPTPBBNJOP,SSPTanggal,SSPHarga,SSBTanggal,SSBHarga, FileLocation, Remarks, Status, " & _
                "DraftBy, DraftDate, ProcessBy, ProcessDate, ProcessRemarks,BPNFinishBy, BPNFinishDate, BPNFinishRemarks, " & _
                "CompletedBy, CompletedDate, CompletedRemarks, IsFalse, IsFalseBy, IsFalseDate, IsFalseRemarks, " & _
                "ModifiedBy, ModifiedDate, TglPenyerahanDokumen, IsFalseLevel FROM NMS_traPPATOrder  " & _
                "WHERE CONVERT(VARCHAR(8),TglAkta,112)>=  CONVERT(VARCHAR(8), @DateFrom,112) " & _
                "AND CONVERT(VARCHAR(8),TglAkta,112)<= CONVERT(VARCHAR(8), @DateTo,112)  "

                .Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = dtmDateFrom
                .Parameters.Add("@DateTo", SqlDbType.DateTime).Value = dtmDateTo
            End With
            Return SQL.QueryDataSet(sqlcmdExecute)
        End Function

        Public Shared Function ListPPATOrderClient1(ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime) As DataSet
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                    "SELECT A.PPATOrderID, [Index], JenisID, NoID, WargaNegara, Negara, Nama, TempatLahir, " & _
                    "TglLahir, Alamat, NoNPWP, NoTelp, NoHP, A.Remarks, Pekerjaan, Title, TglLahirStr FROM NMS_traPPATOrderClient1 A " & _
                    "INNER JOIN NMS_traPPATOrder B ON A.PPATOrderID =B.PPATOrderID  " & _
                    "WHERE CONVERT(VARCHAR(8),TglAkta,112)>=  CONVERT(VARCHAR(8), @DateFrom,112) " & _
                    "AND CONVERT(VARCHAR(8),TglAkta,112)<= CONVERT(VARCHAR(8), @DateTo,112)  "

                .Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = dtmDateFrom
                .Parameters.Add("@DateTo", SqlDbType.DateTime).Value = dtmDateTo
            End With
            Return SQL.QueryDataSet(sqlcmdExecute)
        End Function

        Public Shared Function ListPPATOrderClient2(ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime) As DataSet
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                    "SELECT A.PPATOrderID, [Index], JenisID, NoID, WargaNegara, Negara, Nama, TempatLahir, " & _
                    "TglLahir, Alamat, NoNPWP, NoTelp, NoHP, A.Remarks, Pekerjaan, Title, TglLahirStr FROM NMS_traPPATOrderClient2 A " & _
                    "INNER JOIN NMS_traPPATOrder B ON A.PPATOrderID =B.PPATOrderID  " & _
                    "WHERE CONVERT(VARCHAR(8),TglAkta,112)>=  CONVERT(VARCHAR(8), @DateFrom,112) " & _
                    "AND CONVERT(VARCHAR(8),TglAkta,112)<= CONVERT(VARCHAR(8), @DateTo,112)  "

                .Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = dtmDateFrom
                .Parameters.Add("@DateTo", SqlDbType.DateTime).Value = dtmDateTo
            End With
            Return SQL.QueryDataSet(sqlcmdExecute)
        End Function

        Public Shared Sub SaveAllData(ByVal clsNotaryOrder() As VO.NotaryOrder, ByVal clsNotaryOrderClient1() As VO.NotaryClientDet1, ByVal clsNotaryOrderClient2() As VO.NotaryClientDet2, ByVal clsNotaryOrderClient3() As VO.NotaryClientDet3, ByVal clsPPATOrder() As VO.PPATOrder, ByVal clsPPATOrderClient1() As VO.PPATClientDet1, ByVal clsPPATOrderClient2() As VO.PPATClientDet2)
            Dim intI As Integer = 1
            Dim intI1 As Integer = 1
            Dim intI2 As Integer = 1
            Dim intI3 As Integer = 1
            Dim intI4 As Integer = 1
            Dim intI5 As Integer = 1
            Dim intI6 As Integer = 1

            DL.SQL.OpenConnection()
            DL.SQL.BeginTransaction()
            Try

                'Save NotaryOrder
                If clsNotaryOrder.Length > 0 Then
                    For Each DataItem As VO.NotaryOrder In clsNotaryOrder
                        DL.ExportImport.SaveNotaryOrder(DataItem)
                        intI += 1
                    Next
                End If

                'Save NotaryOrderClient
                If clsNotaryOrderClient1.Length > 0 Then
                    For Each DataItem As VO.NotaryClientDet1 In clsNotaryOrderClient1
                        DL.ExportImport.SaveNotaryOrderClient1(DataItem)
                        intI1 += 1
                    Next
                End If

                If clsNotaryOrderClient2.Length > 0 Then
                    For Each DataItem As VO.NotaryClientDet2 In clsNotaryOrderClient2
                        DL.ExportImport.SaveNotaryOrderClient2(DataItem)
                        intI2 += 1
                    Next
                End If

                If clsNotaryOrderClient3.Length > 0 Then
                    For Each DataItem As VO.NotaryClientDet3 In clsNotaryOrderClient3
                        DL.ExportImport.SaveNotaryOrderClient3(DataItem)
                        intI3 += 1
                    Next
                End If

                'Save PPATOrder
                If clsPPATOrder.Length > 0 Then
                    For Each DataItem As VO.PPATOrder In clsPPATOrder
                        DL.ExportImport.SavePPATOrder(DataItem)
                        intI4 += 1
                    Next
                End If

                'Save PPATOrderClient
                If clsPPATOrderClient1.Length > 0 Then
                    For Each DataItem As VO.PPATClientDet1 In clsPPATOrderClient1
                        DL.ExportImport.SavePPATOrderClient1(DataItem)
                        intI5 += 1
                    Next
                End If

                If clsPPATOrderClient2.Length > 0 Then
                    For Each DataItem As VO.PPATClientDet2 In clsPPATOrderClient2
                        DL.ExportImport.SavePPATOrderClient2(DataItem)
                        intI6 += 1
                    Next
                End If


                DL.SQL.CommitTransaction()
            Catch ex As Exception
                DL.SQL.RollBackTransaction()
                Throw ex
            Finally
                DL.SQL.CloseConnection()
            End Try


        End Sub

        Public Shared Function CheckValidNotaryOrder(ByVal strNotaryOrder As String) As Boolean
            Dim bolValid As Boolean = False
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader
            Try
                If Not SQL.bolUseTrans Then SQL.OpenConnection()
                With sqlcmdExecute
                    .Connection = SQL.sqlConn
                    .CommandText = _
                        "SELECT TOP 1 1 AS Result " & _
                        "FROM NMS_traNotaryOrder " & _
                        "WHERE NotaryOrderID=@NotaryOrderID "

                    .Parameters.Add("@NotaryOrderID", SqlDbType.VarChar).Value = strNotaryOrder

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

        Public Shared Sub SaveNotaryOrder(ByVal clsData As VO.NotaryOrder)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                If CheckValidNotaryOrder(clsData.NotaryOrderID) Then
                    DL.NotaryOrder.DeleteClient3(clsData.NotaryOrderID)
                    DL.NotaryOrder.DeleteClient2(clsData.NotaryOrderID)
                    DL.NotaryOrder.DeleteClient1(clsData.NotaryOrderID)
                    DL.NotaryOrder.DeleteHeader(clsData.NotaryOrderID)
                End If

                .CommandText = _
                "INSERT INTO NMS_traNotaryOrder(NotaryOrderID, NoUrut, NoBulanan, TglAkta, SifatAkta, JenisTransaksi, Status, FileLocation, Remarks, " & _
                "DraftBy, DraftDate, ProcessBy, ProcessDate, ProcessRemarks, CompletedBy, CompletedDate, CompletedRemarks, " & _
                "IsFalse, IsFalseBy, IsFalseDate, IsFalseRemarks, ModifiedBy, ModifiedDate, TglDidaftarkan, JenisAkta, IsFalseLevel )  " & _
                "VALUES (@NotaryOrderID, @NoUrut, @NoBulanan, @TglAkta, @SifatAkta, @JenisTransaksi, @Status, @FileLocation, @Remarks, " & _
                "@DraftBy, @DraftDate, @ProcessBy, @ProcessDate, @ProcessRemarks, @CompletedBy, @CompletedDate, @CompletedRemarks, " & _
                "@IsFalse, @IsFalseBy, @IsFalseDate, @IsFalseRemarks, @ModifiedBy, @ModifiedDate, @TglDidaftarkan, @JenisAkta, @IsFalseLevel )  "

                .Parameters.Add("@NotaryOrderID", SqlDbType.VarChar).Value = clsData.NotaryOrderID
                .Parameters.Add("@NoUrut", SqlDbType.VarChar).Value = clsData.NoUrut
                .Parameters.Add("@NoBulanan", SqlDbType.VarChar).Value = clsData.NoBulanan
                .Parameters.Add("@TglAkta", SqlDbType.DateTime).Value = clsData.TglAkta
                .Parameters.Add("@SifatAkta", SqlDbType.VarChar).Value = clsData.SifatAkta
                .Parameters.Add("@JenisTransaksi", SqlDbType.VarChar).Value = clsData.JenisTransaksi
                .Parameters.Add("@Status", SqlDbType.Int).Value = clsData.Status
                .Parameters.Add("@FileLocation", SqlDbType.VarChar).Value = clsData.FileLocation
                .Parameters.Add("@Remarks", SqlDbType.VarChar).Value = clsData.Remarks
                .Parameters.Add("@DraftBy", SqlDbType.VarChar).Value = clsData.DraftBy
                .Parameters.Add("@DraftDate", SqlDbType.DateTime).Value = clsData.DraftDate
                .Parameters.Add("@ProcessBy", SqlDbType.VarChar).Value = clsData.ProcessBy
                .Parameters.Add("@ProcessDate", SqlDbType.DateTime).Value = clsData.ProcessDate
                .Parameters.Add("@ProcessRemarks", SqlDbType.VarChar).Value = clsData.ProcessRemarks
                .Parameters.Add("@CompletedBy", SqlDbType.VarChar).Value = clsData.CompletedBy
                .Parameters.Add("@CompletedDate", SqlDbType.DateTime).Value = clsData.CompletedDate
                .Parameters.Add("@CompletedRemarks", SqlDbType.VarChar).Value = clsData.CompletedRemarks
                .Parameters.Add("@IsFalse", SqlDbType.Bit).Value = clsData.IsFalse
                .Parameters.Add("@IsFalseBy", SqlDbType.VarChar).Value = clsData.IsFalseBy
                .Parameters.Add("@IsFalseDate", SqlDbType.DateTime).Value = clsData.IsFalseDate
                .Parameters.Add("@IsFalseRemarks", SqlDbType.VarChar).Value = clsData.IsFalseRemarks
                .Parameters.Add("@ModifiedBy", SqlDbType.VarChar).Value = clsData.ModifiedBy
                .Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = clsData.ModifiedDate
                .Parameters.Add("@TglDidaftarkan", SqlDbType.DateTime).Value = clsData.TglDidaftarkan
                .Parameters.Add("@JenisAkta", SqlDbType.Int).Value = clsData.JenisAkta
                .Parameters.Add("@IsFalseLevel", SqlDbType.Int).Value = clsData.IsFalseLevel

            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub SaveNotaryOrderClient1(ByVal clsData As VO.NotaryClientDet1)
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

        Public Shared Sub SaveNotaryOrderClient2(ByVal clsData As VO.NotaryClientDet2)
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

        Public Shared Sub SaveNotaryOrderClient3(ByVal clsData As VO.NotaryClientDet3)
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


        Public Shared Function CheckValidPPATOrder(ByVal strPPATOrder As String) As Boolean
            Dim bolValid As Boolean = False
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader
            Try
                If Not SQL.bolUseTrans Then SQL.OpenConnection()
                With sqlcmdExecute
                    .Connection = SQL.sqlConn
                    .CommandText = _
                        "SELECT TOP 1 1 AS Result " & _
                        "FROM NMS_traPPATOrder " & _
                        "WHERE PPATOrderID=@PPATOrderID "

                    .Parameters.Add("@PPATOrderID", SqlDbType.VarChar).Value = strPPATOrder

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

        Public Shared Sub SavePPATOrder(ByVal clsData As VO.PPATOrder)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                If CheckValidPPATOrder(clsData.PPATOrderID) Then
                    DL.PPATOrder.DeleteClient2(clsData.PPATOrderID)
                    DL.PPATOrder.DeleteClient1(clsData.PPATOrderID)
                    DL.PPATOrder.DeleteHeader(clsData.PPATOrderID)
                End If

                .CommandText = _
                "INSERT INTO NMS_traPPATOrder(PPATOrderID, NoAkta, TglAkta, JenisTransaksi, JenisNoHak, LetakTanahBangunan, LuasTanahM2, LuasBangunanM2, " & _
                "HargaTransaksi,SPPTPBBNOPTahun,SPPTPBBNJOP,SSPTanggal,SSPHarga,SSBTanggal,SSBHarga, FileLocation, Remarks, Status, " & _
                "DraftBy, DraftDate, ProcessBy, ProcessDate, ProcessRemarks,BPNFinishBy, BPNFinishDate, BPNFinishRemarks, " & _
                "CompletedBy, CompletedDate, CompletedRemarks, IsFalse, IsFalseBy, IsFalseDate, IsFalseRemarks, ModifiedBy, ModifiedDate, TglPenyerahanDokumen, IsFalseLevel) " & _
                "VALUES (@PPATOrderID, @NoAkta, @TglAkta, @JenisTransaksi, @JenisNoHak, @LetakTanahBangunan, @LuasTanahM2, @LuasBangunanM2, " & _
                "@HargaTransaksi,@SPPTPBBNOPTahun,@SPPTPBBNJOP,@SSPTanggal,@SSPHarga,@SSBTanggal,@SSBHarga, @FileLocation, @Remarks, @Status, " & _
                "@DraftBy, @DraftDate, @ProcessBy, @ProcessDate, @ProcessRemarks,@BPNFinishBy, @BPNFinishDate, @BPNFinishRemarks, " & _
                "@CompletedBy, @CompletedDate, @CompletedRemarks, @IsFalse, @IsFalseBy, @IsFalseDate, @IsFalseRemarks, @ModifiedBy, @ModifiedDate, @TglPenyerahanDokumen, @IsFalseLevel) "

                .Parameters.Add("@PPATOrderID", SqlDbType.VarChar).Value = clsData.PPATOrderID
                .Parameters.Add("@NoAkta", SqlDbType.VarChar).Value = clsData.NoAkta
                .Parameters.Add("@TglAkta", SqlDbType.DateTime).Value = clsData.TglAkta
                .Parameters.Add("@JenisTransaksi", SqlDbType.Int).Value = clsData.JenisTransaksi
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
                .Parameters.Add("@Status", SqlDbType.Int).Value = clsData.Status
                .Parameters.Add("@DraftBy", SqlDbType.VarChar).Value = clsData.DraftBy
                .Parameters.Add("@DraftDate", SqlDbType.DateTime).Value = clsData.DraftDate
                .Parameters.Add("@ProcessBy", SqlDbType.VarChar).Value = clsData.ProcessBy
                .Parameters.Add("@ProcessDate", SqlDbType.DateTime).Value = clsData.ProcessDate
                .Parameters.Add("@ProcessRemarks", SqlDbType.VarChar).Value = clsData.ProcessRemarks
                .Parameters.Add("@BPNFinishBy", SqlDbType.VarChar).Value = clsData.BPNFinishBy
                .Parameters.Add("@BPNFinishDate", SqlDbType.DateTime).Value = clsData.BPNFinishDate
                .Parameters.Add("@BPNFinishRemarks", SqlDbType.VarChar).Value = clsData.BPNFinishRemarks
                .Parameters.Add("@CompletedBy", SqlDbType.VarChar).Value = clsData.CompletedBy
                .Parameters.Add("@CompletedDate", SqlDbType.DateTime).Value = clsData.CompletedDate
                .Parameters.Add("@CompletedRemarks", SqlDbType.VarChar).Value = clsData.CompletedRemarks
                .Parameters.Add("@IsFalse", SqlDbType.Bit).Value = clsData.IsFalse
                .Parameters.Add("@IsFalseBy", SqlDbType.VarChar).Value = clsData.IsFalseBy
                .Parameters.Add("@IsFalseDate", SqlDbType.DateTime).Value = clsData.IsFalseDate
                .Parameters.Add("@IsFalseRemarks", SqlDbType.VarChar).Value = clsData.IsFalseRemarks
                .Parameters.Add("@ModifiedBy", SqlDbType.VarChar).Value = clsData.ModifiedBy
                .Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = clsData.ModifiedDate
                .Parameters.Add("@TglPenyerahanDokumen", SqlDbType.DateTime).Value = clsData.TglPenyerahanDokumen
                .Parameters.Add("@IsFalseLevel", SqlDbType.Int).Value = clsData.IsFalseLevel


            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub SavePPATOrderClient1(ByVal clsData As VO.PPATClientDet1)
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

        Public Shared Sub SavePPATOrderClient2(ByVal clsData As VO.PPATClientDet2)
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

        Public Shared Function ListMasterUser() As DataSet
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                    "SELECT LocationID, UserID, LocationName,UserName,Password,UserPosition,BirthPlace,BirthDate,Address, " & _
                    "IDType,IDNumber,NPWPNumber,JamsostekID,NoHP,Remarks,StartWorkingDate,CreatedDate,ModifiedDate,IsActive, " & _
                    "IsMasterUser,IsNotary,IsNotaryNew,IsNotaryProcess,IsNotaryCompleted,IsNotaryFalse,IsPPAT,IsPPATNew, " & _
                    "IsPPATProcess,IsPPATBPNFinish,IsPPATCompleted,IsPPATFalse,Title,BirthDateStr " & _
                    "FROM NMS_mstUser "
            End With
            Return SQL.QueryDataSet(sqlcmdExecute)
        End Function

        Public Shared Sub SaveMasterUser(ByVal clsMasterUser() As VO.MasterUser)
            Dim intI As Integer = 1
            DL.SQL.OpenConnection()
            DL.SQL.BeginTransaction()
            Try
                'Save NotaryOrder
                If clsMasterUser.Length > 0 Then
                    For Each DataItem As VO.MasterUser In clsMasterUser
                        DL.ExportImport.SaveMasterUserDet(DataItem)
                        intI += 1
                    Next
                End If

                DL.SQL.CommitTransaction()
            Catch ex As Exception
                DL.SQL.RollBackTransaction()
                Throw ex
            Finally
                DL.SQL.CloseConnection()
            End Try
        End Sub

        Public Shared Sub SaveMasterUserDet(ByVal clsData As VO.MasterUser)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                    "INSERT INTO NMS_mstUser (LocationID, UserID, LocationName,UserName,Password,UserPosition,BirthPlace,BirthDate,Address, " & _
                    "IDType,IDNumber,NPWPNumber,JamsostekID,NoHP,Remarks,StartWorkingDate,CreatedDate,ModifiedDate,IsActive, " & _
                    "IsMasterUser,IsNotary,IsNotaryNew,IsNotaryProcess,IsNotaryCompleted,IsNotaryFalse,IsPPAT,IsPPATNew, " & _
                    "IsPPATProcess,IsPPATBPNFinish,IsPPATCompleted,IsPPATFalse,Title,BirthDateStr) " & _
                    "VALUES (@LocationID, @UserID, @LocationName,@UserName,@Password,@UserPosition,@BirthPlace,@BirthDate,@Address, " & _
                    "@IDType,@IDNumber,@NPWPNumber,@JamsostekID,@NoHP,@Remarks,@StartWorkingDate,@CreatedDate,@ModifiedDate,@IsActive, " & _
                    "@IsMasterUser,@IsNotary,@IsNotaryNew,@IsNotaryProcess,@IsNotaryCompleted,@IsNotaryFalse,@IsPPAT,@IsPPATNew, " & _
                    "@IsPPATProcess,@IsPPATBPNFinish,@IsPPATCompleted,@IsPPATFalse,@Title,@BirthDateStr) "


                .Parameters.Add("@LocationID", SqlDbType.VarChar).Value = clsData.LocationID
                .Parameters.Add("@UserID", SqlDbType.VarChar).Value = clsData.UserID
                .Parameters.Add("@LocationName", SqlDbType.VarChar).Value = clsData.LocationName
                .Parameters.Add("@UserName", SqlDbType.VarChar).Value = clsData.UserName
                .Parameters.Add("@Password", SqlDbType.VarChar).Value = BL.UserAccess.PasswordEncrypt("abcde")
                .Parameters.Add("@UserPosition", SqlDbType.VarChar).Value = clsData.UserPosition
                .Parameters.Add("@BirthPlace", SqlDbType.VarChar).Value = clsData.BirthPlace
                .Parameters.Add("@BirthDate", SqlDbType.DateTime).Value = clsData.BirthDate
                .Parameters.Add("@Address", SqlDbType.VarChar).Value = clsData.Address
                .Parameters.Add("@IDType", SqlDbType.VarChar).Value = clsData.IDType.ToUpper
                .Parameters.Add("@IDNumber", SqlDbType.VarChar).Value = clsData.IDNumber
                .Parameters.Add("@NPWPNumber", SqlDbType.VarChar).Value = clsData.NPWPNumber
                .Parameters.Add("@JamsostekID", SqlDbType.VarChar).Value = clsData.JamsostekID
                .Parameters.Add("@NoHP", SqlDbType.VarChar).Value = clsData.NoHP
                .Parameters.Add("@Remarks", SqlDbType.VarChar).Value = clsData.Remarks
                .Parameters.Add("@StartWorkingDate", SqlDbType.DateTime).Value = clsData.StartWorkingDate
                .Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = clsData.CreatedDate
                .Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = clsData.ModifiedDate
                .Parameters.Add("@IsActive", SqlDbType.Int).Value = clsData.IsActive
                .Parameters.Add("@IsMasterUser", SqlDbType.Bit).Value = clsData.IsMasterUser
                .Parameters.Add("@IsNotary", SqlDbType.Bit).Value = clsData.IsNotary
                .Parameters.Add("@IsNotaryNew", SqlDbType.Bit).Value = clsData.IsNotaryNew
                .Parameters.Add("@IsNotaryProcess", SqlDbType.Bit).Value = clsData.IsNotaryProcess
                .Parameters.Add("@IsNotaryCompleted", SqlDbType.Bit).Value = clsData.IsNotaryCompleted
                .Parameters.Add("@IsNotaryFalse", SqlDbType.Bit).Value = clsData.IsNotaryFalse
                .Parameters.Add("@IsPPAT", SqlDbType.Bit).Value = clsData.IsPPAT
                .Parameters.Add("@IsPPATNew", SqlDbType.Bit).Value = clsData.IsPPATNew
                .Parameters.Add("@IsPPATProcess", SqlDbType.Bit).Value = clsData.IsPPATProcess
                .Parameters.Add("@IsPPATBPNFinish", SqlDbType.Bit).Value = clsData.IsPPATBPNFinish
                .Parameters.Add("@IsPPATCompleted", SqlDbType.Bit).Value = clsData.IsPPATCompleted
                .Parameters.Add("@IsPPATFalse", SqlDbType.Bit).Value = clsData.IsPPATFalse
                .Parameters.Add("@Title", SqlDbType.VarChar).Value = clsData.Title
                .Parameters.Add("@BirthDateStr", SqlDbType.VarChar).Value = clsData.BirthDateStr

            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

    End Class

End Namespace

Imports System.Data.SqlClient

Namespace DL

    Public Class Report

        Public Shared Function NotaryOrder(ByVal dtDateFrom As DateTime, _
                                            ByVal dtDateTo As DateTime, _
                                            ByVal intJenisAkta As Integer) As DataTable

            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                "SELECT NoUrut as NoUrut, NoBulanan, TglAkta, TglDidaftarkan, SifatAkta, Nama1, Nama2, ISNULL(Nama3,'') AS Nama3  FROM ( " & _
                "SELECT 1 AS JenisClient, [INDEX], NoUrut, NoBulanan, TglAkta, TglDidaftarkan, SifatAkta, B.Nama+CHAR(10)+CHAR(13)+B.Remarks As Nama1, '' As Nama2, '' As Nama3, JenisAkta " & _
                "FROM NMS_traNotaryOrder A " & _
                "INNER JOIN NMS_traNotaryOrderClient1 B ON " & _
                "A.NotaryOrderID =B.NotaryOrderID " & _
                "WHERE [INDEX]<(CASE WHEN A.JenisTransaksi ='AKTA JAMINAN FIDUSIA' THEN 2 WHEN A.JenisTransaksi <>'AKTA JAMINAN FIDUSIA' THEN 100 END) " & _
                "UNION ALL " & _
                "SELECT 2 AS JenisClient, [INDEX], NoUrut, NoBulanan, TglAkta, TglDidaftarkan, SifatAkta, '' As Nama1, C.Nama+CHAR(10)+CHAR(13)+C.Remarks As Nama2, '' As Nama3, JenisAkta " & _
                "FROM NMS_traNotaryOrder A " & _
                "INNER JOIN NMS_traNotaryOrderClient2 C ON " & _
                "A.NotaryOrderID =C.NotaryOrderID " & _
                "WHERE [INDEX]<(CASE WHEN A.JenisTransaksi ='AKTA JAMINAN FIDUSIA' THEN 2 WHEN A.JenisTransaksi <>'AKTA JAMINAN FIDUSIA' THEN 100 END) " & _
                "UNION ALL " & _
                "SELECT 3 AS JenisClient, [INDEX],NoUrut, NoBulanan, TglAkta, TglDidaftarkan, SifatAkta, '' As Nama1, '' As Nama2, D.Nama+CHAR(10)+CHAR(13)+D.Remarks As Nama3, JenisAkta " & _
                "FROM NMS_traNotaryOrder A " & _
                "LEFT JOIN NMS_traNotaryOrderClient3 D ON  " & _
                "A.NotaryOrderID =D.NotaryOrderID  )X " & _
                "WHERE CONVERT(VARCHAR(8),TglAkta,112)>=  CONVERT(VARCHAR(8), @DateFrom,112) " & _
                "AND CONVERT(VARCHAR(8),TglAkta,112)<= CONVERT(VARCHAR(8), @DateTo,112) AND JenisAkta=@JenisAkta AND NoUrut<>'' " & _
                "ORDER BY NoUrut, NoBulanan, JenisClient, [INDEX], Nama1 DESC, Nama2 DESC, Nama3 DESC "

                .Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = dtDateFrom
                .Parameters.Add("@DateTo", SqlDbType.DateTime).Value = dtDateTo
                .Parameters.Add("@JenisAkta", SqlDbType.Int).Value = intJenisAkta
            End With
            Return SQL.QueryDataTable(sqlcmdExecute)
        End Function

        Public Shared Function PPATOrder(ByVal dtDateFrom As DateTime, ByVal dtDateTo As DateTime, ByVal strJenisTransaksi As String) As DataTable

            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                "SELECT NoAkta, TglAkta, CASE JenisTransaksi WHEN 0 THEN 'AJB' WHEN 1 THEN 'ATM' WHEN 2 THEN 'AH' WHEN 3 THEN 'APDP' WHEN 4 THEN 'APHB' WHEN 5 THEN 'APHGB' WHEN 6 THEN 'APHT' END AS JenisTransaksi , " & _
                "JenisNoHak, LetakTanahBangunan, LuasTanahM2, LuasBangunanM2, HargaTransaksi/1000 AS HargaTransaksi , " & _
                "SPPTPBBNOPTahun, SPPTPBBNJOP/1000 AS SPPTPBBNJOP, CASE JenisTransaksi WHEN 6 THEN NULL ELSE SSPTanggal END AS SSPTanggal, SSPHarga, CASE JenisTransaksi WHEN 6 THEN NULL ELSE SSBTanggal END AS SSBTanggal, SSBHarga, A.Remarks, " & _
                "B.Nama+' '+B.Remarks+CHAR(10)+CHAR(13)+B.Alamat+CHAR(10)+CASE WHEN B.NoNPWP <> '' THEN CHAR(13) ELSE '' END +B.NoNPWP AS Nama1," & _
                "C.Nama+' '+C.Remarks+CHAR(10)+CHAR(13)+C.Alamat+CHAR(10)+CASE WHEN ISNULL(C.NoNPWP,'') <> '' THEN CHAR(13) ELSE '' END +C.NoNPWP AS Nama2 FROM NMS_traPPATOrder A  " & _
                "INNER JOIN NMS_traPPATOrderClient1 B " & _
                "ON A.PPATOrderID =B.PPATOrderID  " & _
                "LEFT JOIN NMS_traPPATOrderClient2 C " & _
                "ON A.PPATOrderID =C.PPATOrderID AND B.[Index] = C.[Index] " & _
                "WHERE JenisTransaksi IN (" & strJenisTransaksi.Trim & ") AND NoAkta<>'' " & _
                "AND CONVERT(VARCHAR(8),TglAkta,112)>=  CONVERT(VARCHAR(8), @DateFrom,112) " & _
                "AND CONVERT(VARCHAR(8),TglAkta,112)<= CONVERT(VARCHAR(8), @DateTo,112) "

                .CommandText += "ORDER BY NoAkta, B.[Index], C.[Index] "

                .Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = dtDateFrom
                .Parameters.Add("@DateTo", SqlDbType.DateTime).Value = dtDateTo
            End With
            Return SQL.QueryDataTable(sqlcmdExecute)
        End Function

        Public Shared Function AdminFee(ByVal strPeriod As String, ByVal strUserID As String) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                "SELECT UserID, OrderID, NoUrut, TglAkta, JenisTransaksi,   " & _
                "Tipe, Nama, FileLocation, Remarks, TglTransaksi, Fee FROM NMS_traAdminFee  " & _
                "WHERE CONVERT(VARCHAR(8),Period,112)= @Period   " & _
                "AND (@UserID='' OR UserID=@UserID) " 

                .Parameters.Add("@Period", SqlDbType.VarChar).Value = strPeriod
                .Parameters.Add("@UserID", SqlDbType.VarChar).Value = strUserID
            End With
            Return SQL.QueryDataTable(sqlcmdExecute)
        End Function

        Public Shared Function SummaryAdminFee(ByVal strPeriod As String) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                "SELECT UserID,SUM(CASE WHEN Fee>0 THEN 1 ELSE 0 END) AS TrueNumber,  " & _
                "SUM(CASE WHEN Fee<0 THEN 1 ELSE 0 END) AS FalseNumber, " & _
                "SUM(CASE WHEN Fee>0 THEN Fee ELSE 0 END) AS TrueFee,  " & _
                "ABS(SUM(CASE WHEN Fee<0 THEN Fee ELSE 0 END)) AS FalseFee  FROM NMS_traAdminFee " & _
                "where CONVERT(VARCHAR(8),Period,112)= CONVERT(VARCHAR(8), @Period,112)  " & _
                "GROUP BY UserID  " & _
                "ORDER BY UserID "

                .Parameters.Add("@Period", SqlDbType.VarChar).Value = strPeriod

            End With
            Return SQL.QueryDataTable(sqlcmdExecute)
        End Function

        'Old Query
        'Public Shared Function AdminFee(ByVal dtDateFrom As DateTime, _
        '                                ByVal dtDateTo As DateTime, _
        '                                ByVal strUserID As String, ByVal decFee As Decimal) As DataTable

        '    Dim sqlcmdExecute As New SqlCommand
        '    With sqlcmdExecute
        '        .CommandText = _
        '        "SELECT DraftBy AS UserID, A.NotaryOrderID, NoUrut+' - '+NoBulanan AS NoUrut, TglAkta, JenisTransaksi, " & _
        '        "'D' AS Tipe, IsFalseRemarks, CASE IsFalseLevel WHEN 0 THEN 1 WHEN 2 THEN 1 ELSE 0 END AS IsFalse, " & _
        '        "FileLocation, DraftDate AS CreatedDate, IsPaidDraft, DraftPaymentDate, " & _
        '        "CASE IsFalseLevel WHEN 0 THEN 0 WHEN 2 THEN 0 ELSE @Fee END AS Fee, B.Nama FROM NMS_traNotaryOrder A " & _
        '        "INNER JOIN NMS_traNotaryOrderClient1 B ON A.NotaryOrderID =B.NotaryOrderID AND B.[Index] =1 " & _
        '        "WHERE CONVERT(VARCHAR(8),DraftDate,112)>=  CONVERT(VARCHAR(8), @DateFrom,112) " & _
        '        "AND CONVERT(VARCHAR(8),DraftDate,112)<= CONVERT(VARCHAR(8), @DateTo,112) AND (@UserID='' OR DraftBy=@UserID) AND DraftBy<>'' " & _
        '        "UNION ALL  " & _
        '        "SELECT ProcessBy, A.NotaryOrderID, NoUrut+' - '+NoBulanan AS NoUrut, TglAkta, JenisTransaksi, 'P' AS Tipe,  " & _
        '        "IsFalseRemarks, CASE IsFalseLevel WHEN 1 THEN 1 WHEN 2 THEN 1 ELSE 0 END AS IsFalse, FileLocation,  " & _
        '        "ProcessDate, IsPaidProcess, ProcessPaymentDate, " & _
        '        "CASE IsFalseLevel WHEN 1 THEN 0 WHEN 2 THEN 0 ELSE @Fee END AS Fee, Nama  " & _
        '        "FROM NMS_traNotaryOrder A " & _
        '        "INNER JOIN NMS_traNotaryOrderClient1 B ON A.NotaryOrderID =B.NotaryOrderID AND B.[Index] =1  " & _
        '        "WHERE CONVERT(VARCHAR(8),ProcessDate,112)>=  CONVERT(VARCHAR(8), @DateFrom,112)   " & _
        '        "AND CONVERT(VARCHAR(8),ProcessDate,112)<= CONVERT(VARCHAR(8), @DateTo,112) AND (@UserID='' OR ProcessBy=@UserID) AND ProcessBy<>''   " & _
        '        "UNION ALL   " & _
        '        "SELECT DraftBy, A.PPATOrderID, NoAkta, TglAkta, CASE JenisTransaksi WHEN 0 THEN 'AJB' WHEN 1 THEN 'ATM' WHEN 2 THEN 'AH' WHEN 3 THEN 'APDP' WHEN 4 THEN 'APHB' WHEN 5 THEN 'APHGB' WHEN 6 THEN 'APHT' END AS JenisTransaksi, " & _
        '        "'D' AS Tipe, IsFalseRemarks, CASE IsFalseLevel WHEN 0 THEN 1 WHEN 2 THEN 1 ELSE 0 END AS IsFalse, FileLocation,  " & _
        '        "DraftDate, IsPaidDraft, DraftPaymentDate, CASE IsFalseLevel WHEN 0 THEN 0 WHEN 2 THEN 0 ELSE @Fee END AS Fee, Nama  " & _
        '        "FROM NMS_traPPATOrder A " & _
        '        "INNER JOIN NMS_traPPATOrderClient1 B ON A.PPATOrderID =B.PPATOrderID AND B.[Index] =1  " & _
        '        "WHERE CONVERT(VARCHAR(8),DraftDate,112)>=  CONVERT(VARCHAR(8), @DateFrom,112) " & _
        '        "AND CONVERT(VARCHAR(8),DraftDate,112)<= CONVERT(VARCHAR(8), @DateTo,112) AND (@UserID='' OR DraftBy=@UserID) AND DraftBy<>''  " & _
        '        "UNION ALL  " & _
        '        "SELECT ProcessBy, A.PPATOrderID, NoAkta, TglAkta, CASE JenisTransaksi WHEN 0 THEN 'AJB' WHEN 1 THEN 'ATM' WHEN 2 THEN 'AH' WHEN 3 THEN 'APDP' WHEN 4 THEN 'APHB' WHEN 5 THEN 'APHGB' WHEN 6 THEN 'APHT' END AS JenisTransaksi, " & _
        '        "'P' AS Tipe, IsFalseRemarks, CASE IsFalseLevel WHEN 1 THEN 1 WHEN 2 THEN 1 ELSE 0 END AS IsFalse, FileLocation, " & _
        '        "ProcessDate, IsPaidProcess, ProcessPaymentDate, " & _
        '        "CASE IsFalseLevel WHEN 1 THEN 0 WHEN 2 THEN 0 ELSE @Fee END AS Fee, Nama " & _
        '        "FROM NMS_traPPATOrder A " & _
        '        "INNER JOIN NMS_traPPATOrderClient1 B ON A.PPATOrderID =B.PPATOrderID AND B.[Index] =1  " & _
        '        "WHERE CONVERT(VARCHAR(8),ProcessDate,112)>=  CONVERT(VARCHAR(8), @DateFrom,112) " & _
        '        "AND CONVERT(VARCHAR(8),ProcessDate,112)<= CONVERT(VARCHAR(8), @DateTo,112) AND (@UserID='' OR ProcessBy=@UserID) AND ProcessBy<>''  "

        '        .Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = dtDateFrom
        '        .Parameters.Add("@DateTo", SqlDbType.DateTime).Value = dtDateTo
        '        .Parameters.Add("@UserID", SqlDbType.VarChar).Value = strUserID
        '        .Parameters.Add("@Fee", SqlDbType.Decimal).Value = decFee
        '    End With
        '    Return SQL.QueryDataTable(sqlcmdExecute)
        'End Function

        Public Shared Sub UpdatePaid(ByVal dtDateFrom As DateTime, _
                                        ByVal dtDateTo As DateTime, _
                                        ByVal strUserID As String)


            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                "UPDATE NMS_traNotaryOrder " & _
                "SET IsPaidDraft =1, DraftPaymentDate =GETDATE() " & _
                "WHERE CONVERT(VARCHAR(8),DraftDate,112)>=  CONVERT(VARCHAR(8), @DateFrom,112)  " & _
                "AND CONVERT(VARCHAR(8),DraftDate,112)<= CONVERT(VARCHAR(8), @DateTo,112) AND (@UserID='' OR DraftBy=@UserID) AND DraftBy<>''  "

                .Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = dtDateFrom
                .Parameters.Add("@DateTo", SqlDbType.DateTime).Value = dtDateTo
                .Parameters.Add("@UserID", SqlDbType.VarChar).Value = strUserID
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute)
            Catch ex As Exception
                Throw ex
            End Try

            sqlcmdExecute.CommandText = ""
            With sqlcmdExecute
                .CommandText = _
                "UPDATE NMS_traNotaryOrder " & _
                "SET IsPaidProcess =1, ProcessPaymentDate =GETDATE() " & _
                "WHERE CONVERT(VARCHAR(8),ProcessDate,112)>=  CONVERT(VARCHAR(8), @DateFrom,112) " & _
                "AND CONVERT(VARCHAR(8),ProcessDate,112)<= CONVERT(VARCHAR(8), @DateTo,112) AND (@UserID='' OR ProcessBy=@UserID) AND ProcessBy<>'' "

            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute)
            Catch ex As Exception
                Throw ex
            End Try

            sqlcmdExecute.CommandText = ""
            With sqlcmdExecute
                .CommandText = _
                "UPDATE NMS_traPPATOrder " & _
                "SET IsPaidDraft =1, DraftPaymentDate =GETDATE() " & _
                "WHERE CONVERT(VARCHAR(8),DraftDate,112)>=  CONVERT(VARCHAR(8), @DateFrom,112)  " & _
                "AND CONVERT(VARCHAR(8),DraftDate,112)<= CONVERT(VARCHAR(8), @DateTo,112) AND (@UserID='' OR DraftBy=@UserID) AND DraftBy<>''  "

            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute)
            Catch ex As Exception
                Throw ex
            End Try

            sqlcmdExecute.CommandText = ""
            With sqlcmdExecute
                .CommandText = _
                "UPDATE NMS_traPPATOrder " & _
                "SET IsPaidProcess =1, ProcessPaymentDate =GETDATE() " & _
                "WHERE CONVERT(VARCHAR(8),ProcessDate,112)>=  CONVERT(VARCHAR(8), @DateFrom,112) " & _
                "AND CONVERT(VARCHAR(8),ProcessDate,112)<= CONVERT(VARCHAR(8), @DateTo,112) AND (@UserID='' OR ProcessBy=@UserID) AND ProcessBy<>'' "

            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute)
            Catch ex As Exception
                Throw ex
            End Try

        End Sub

        Public Shared Sub UpdateUnpaid(ByVal dtDateFrom As DateTime, _
                                        ByVal dtDateTo As DateTime, _
                                        ByVal strUserID As String)


            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                "UPDATE NMS_traNotaryOrder " & _
                "SET IsPaidDraft =0, DraftPaymentDate =NULL " & _
                "WHERE CONVERT(VARCHAR(8),DraftDate,112)>=  CONVERT(VARCHAR(8), @DateFrom,112)  " & _
                "AND CONVERT(VARCHAR(8),DraftDate,112)<= CONVERT(VARCHAR(8), @DateTo,112) AND (@UserID='' OR DraftBy=@UserID) AND DraftBy<>''  "

                .Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = dtDateFrom
                .Parameters.Add("@DateTo", SqlDbType.DateTime).Value = dtDateTo
                .Parameters.Add("@UserID", SqlDbType.VarChar).Value = strUserID
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute)
            Catch ex As Exception
                Throw ex
            End Try

            sqlcmdExecute.CommandText = ""
            With sqlcmdExecute
                .CommandText = _
                "UPDATE NMS_traNotaryOrder " & _
                "SET IsPaidProcess =0, ProcessPaymentDate =NULL " & _
                "WHERE CONVERT(VARCHAR(8),ProcessDate,112)>=  CONVERT(VARCHAR(8), @DateFrom,112) " & _
                "AND CONVERT(VARCHAR(8),ProcessDate,112)<= CONVERT(VARCHAR(8), @DateTo,112) AND (@UserID='' OR ProcessBy=@UserID) AND ProcessBy<>'' "

            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute)
            Catch ex As Exception
                Throw ex
            End Try

            sqlcmdExecute.CommandText = ""
            With sqlcmdExecute
                .CommandText = _
                "UPDATE NMS_traPPATOrder " & _
                "SET IsPaidDraft =0, DraftPaymentDate =NULL " & _
                "WHERE CONVERT(VARCHAR(8),DraftDate,112)>=  CONVERT(VARCHAR(8), @DateFrom,112)  " & _
                "AND CONVERT(VARCHAR(8),DraftDate,112)<= CONVERT(VARCHAR(8), @DateTo,112) AND (@UserID='' OR DraftBy=@UserID) AND DraftBy<>''  "

            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute)
            Catch ex As Exception
                Throw ex
            End Try

            sqlcmdExecute.CommandText = ""
            With sqlcmdExecute
                .CommandText = _
                "UPDATE NMS_traPPATOrder " & _
                "SET IsPaidProcess =0, ProcessPaymentDate =NULL " & _
                "WHERE CONVERT(VARCHAR(8),ProcessDate,112)>=  CONVERT(VARCHAR(8), @DateFrom,112) " & _
                "AND CONVERT(VARCHAR(8),ProcessDate,112)<= CONVERT(VARCHAR(8), @DateTo,112) AND (@UserID='' OR ProcessBy=@UserID) AND ProcessBy<>'' "

            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute)
            Catch ex As Exception
                Throw ex
            End Try

        End Sub

        Public Shared Function PaymentTransaction(ByVal dtDateFrom As DateTime, ByVal dtDateTo As DateTime) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                "SELECT 1 AS Type, PInID, NoAkta, NamaClient, PDate, B*10000 AS B, Remarks, IsOther FROM NMS_traPIn    " & _
                "WHERE CONVERT(VARCHAR(8),PDate,112)>=CONVERT(VARCHAR(8),@DateFrom,112)   " & _
                "AND CONVERT(VARCHAR(8),PDate,112)<=CONVERT(VARCHAR(8),@DateTo,112)  " & _
                "UNION ALL " & _
                "SELECT 2 AS Type, POutID, NoAkta, NamaClient, PDate, B*10000 AS B, Remarks, " & _
                "CAST(CASE PInID WHEN 0 THEN 1 ELSE 0 END AS BIT) AS IsOther FROM NMS_traPOut    " & _
                "WHERE CONVERT(VARCHAR(8),PDate,112)>=CONVERT(VARCHAR(8),@DateFrom,112)   " & _
                "AND CONVERT(VARCHAR(8),PDate,112)<=CONVERT(VARCHAR(8),@DateTo,112)  "

                .Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = dtDateFrom
                .Parameters.Add("@DateTo", SqlDbType.DateTime).Value = dtDateTo
            End With
            Return SQL.QueryDataTable(sqlcmdExecute)
        End Function

        Public Shared Function OutstandingPayment(ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                "SELECT A.PInID, A.NoAkta, A.NamaClient, A.PDate, MAX(B.POutID) AS POutID, MAX(B.PDate) AS PDateOut, " & _
                "(A.B*10000) AS B,SUM(B.B*10000) AS BOut,(A.B*10000)- SUM(B.B*10000) AS Margin, " & _
                "CASE WHEN (A.B*10000)- SUM(B.B*10000)>0 THEN (A.B*10000)- SUM(B.B*10000) ELSE 0 END AS Untung, " & _
                "CASE WHEN (A.B*10000)- SUM(B.B*10000)<0 THEN ABS((A.B*10000)- SUM(B.B*10000)) ELSE 0 END AS Rugi, " & _
                "CASE WHEN B.PInID IS NULL THEN A.B*10000 ELSE 0 END AS Outstanding " & _
                "FROM NMS_traPIn A    " & _
                "LEFT JOIN NMS_traPOut B ON A.PInID=B.PInID      " & _
                "WHERE CONVERT(VARCHAR(8),A.PDate,112)>=CONVERT(VARCHAR(8),@DateFrom,112)     " & _
                "AND CONVERT(VARCHAR(8),A.PDate,112)<=CONVERT(VARCHAR(8),@DateTo,112) " & _
                "AND A.IsOther=0 " & _
                "GROUP BY A.PInID, A.NoAkta, A.NamaClient, A.PDate,A.B,B.PInID  " & _
                "ORDER BY PInID  "

                .Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = dtmDateFrom
                .Parameters.Add("@DateTo", SqlDbType.DateTime).Value = dtmDateTo

            End With
            Return SQL.QueryDataTable(sqlcmdExecute)
        End Function

    End Class

End Namespace
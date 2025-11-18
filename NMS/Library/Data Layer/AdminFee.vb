Imports System.Data.SqlClient

Namespace DL

    Public Class AdminFee

        Public Shared Sub ClosePeriod(ByVal dtDateFrom As DateTime, ByVal dtDateTo As DateTime, _
                                       ByVal decFee As Decimal)


            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                "INSERT INTO NMS_traAdminFee  " & vbNewLine & _
                "(Period,UserID,OrderID,NoUrut,TglAkta,JenisTransaksi,Tipe,FileLocation,Remarks,Nama,Fee,TglTransaksi,CreatedBy) " & vbNewLine & _
                "SELECT @DateTo AS Period, DraftBy AS UserID, A.NotaryOrderID, A.NoUrut+' - '+NoBulanan AS NoUrut, A.TglAkta, A.JenisTransaksi,  " & vbNewLine & _
                "'D' AS Tipe, A.FileLocation, '' AS Remarks, B.Nama, @Fee AS Fee, DraftDate AS TglTransaksi, @CreatedBy as CreatedBy FROM NMS_traNotaryOrder A " & vbNewLine & _
                "INNER JOIN NMS_traNotaryOrderClient1 B ON A.NotaryOrderID =B.NotaryOrderID AND B.[Index] =1 " & vbNewLine & _
                "LEFT JOIN NMS_traAdminFee C ON A.NotaryOrderID=C.OrderID AND C.Tipe='D'  " & vbNewLine & _
                "WHERE CONVERT(VARCHAR(8),A.TglAkta,112)>= '20160101' AND C.OrderID IS NULL AND " & vbNewLine & _
                "CONVERT(VARCHAR(8),DraftDate,112)>=CONVERT(VARCHAR(8), @DateFrom,112) " & vbNewLine & _
                "AND CONVERT(VARCHAR(8),DraftDate,112)<= CONVERT(VARCHAR(8), @DateTo,112) AND DraftBy<>''  " & vbNewLine & _
                "UNION ALL " & vbNewLine & _
                "SELECT @DateTo AS Period, ProcessBy, A.NotaryOrderID, A.NoUrut+' - '+NoBulanan AS NoUrut, A.TglAkta, A.JenisTransaksi, " & vbNewLine & _
                "'P' AS Tipe,A.FileLocation,'' AS Remarks, B.Nama, @Fee, ProcessDate, @CreatedBy  " & vbNewLine & _
                "FROM NMS_traNotaryOrder A " & vbNewLine & _
                "INNER JOIN NMS_traNotaryOrderClient1 B ON A.NotaryOrderID =B.NotaryOrderID AND B.[Index] =1 " & vbNewLine & _
                "LEFT JOIN NMS_traAdminFee C ON A.NotaryOrderID=C.OrderID AND C.Tipe='P' " & vbNewLine & _
                "WHERE CONVERT(VARCHAR(8),A.TglAkta,112)>= '20160101' AND C.OrderID IS NULL AND " & vbNewLine & _
                "CONVERT(VARCHAR(8),ProcessDate,112)>=CONVERT(VARCHAR(8), @DateFrom,112) " & vbNewLine & _
                "AND CONVERT(VARCHAR(8),ProcessDate,112)<= CONVERT(VARCHAR(8), @DateTo,112) AND ProcessBy<>'' " & vbNewLine & _
                "UNION ALL " & vbNewLine & _
                "SELECT @DateTo, DraftBy, A.PPATOrderID, NoAkta, A.TglAkta, CASE A.JenisTransaksi WHEN 0 THEN 'AJB' WHEN 1 THEN 'ATM' WHEN 2 THEN 'AH' WHEN 3 THEN 'APDP' WHEN 4 THEN 'APHB' WHEN 5 THEN 'APHGB' WHEN 6 THEN 'APHT' END AS JenisTransaksi, " & vbNewLine & _
                "'D' AS Tipe, A.FileLocation, '' AS Remarks, B.Nama, @Fee, DraftDate, @CreatedBy  " & vbNewLine & _
                "FROM NMS_traPPATOrder A " & vbNewLine & _
                "INNER JOIN NMS_traPPATOrderClient1 B ON A.PPATOrderID =B.PPATOrderID AND B.[Index] =1  " & vbNewLine & _
                "LEFT JOIN NMS_traAdminFee C ON A.PPATOrderID=C.OrderID AND C.Tipe='D' " & vbNewLine & _
                "WHERE CONVERT(VARCHAR(8),A.TglAkta,112)>= '20160101' AND C.OrderID IS NULL AND  " & vbNewLine & _
                "CONVERT(VARCHAR(8),DraftDate,112)>=CONVERT(VARCHAR(8), @DateFrom,112) " & vbNewLine & _
                "AND CONVERT(VARCHAR(8),DraftDate,112)<= CONVERT(VARCHAR(8), @DateTo,112) AND DraftBy<>''  " & vbNewLine & _
                "UNION ALL  " & vbNewLine & _
                "SELECT @DateTo, ProcessBy, A.PPATOrderID, NoAkta, A.TglAkta, CASE A.JenisTransaksi WHEN 0 THEN 'AJB' WHEN 1 THEN 'ATM' WHEN 2 THEN 'AH' WHEN 3 THEN 'APDP' WHEN 4 THEN 'APHB' WHEN 5 THEN 'APHGB' WHEN 6 THEN 'APHT' END AS JenisTransaksi, " & vbNewLine & _
                "'P' AS Tipe, A.FileLocation, '' AS Remarks,B.Nama,@Fee ,ProcessDate, @CreatedBy  " & vbNewLine & _
                "FROM NMS_traPPATOrder A " & vbNewLine & _
                "INNER JOIN NMS_traPPATOrderClient1 B ON A.PPATOrderID =B.PPATOrderID AND B.[Index] =1  " & vbNewLine & _
                "LEFT JOIN NMS_traAdminFee C ON A.PPATOrderID=C.OrderID AND C.Tipe='P' " & vbNewLine & _
                "WHERE CONVERT(VARCHAR(8),A.TglAkta,112)>= '20160101' AND C.OrderID IS NULL AND " & vbNewLine & _
                "CONVERT(VARCHAR(8),ProcessDate,112)>=CONVERT(VARCHAR(8), @DateFrom,112) " & vbNewLine & _
                "AND CONVERT(VARCHAR(8),ProcessDate,112)<= CONVERT(VARCHAR(8), @DateTo,112) AND ProcessBy<>'' ---IS FALSE " & vbNewLine & _
                "UNION ALL " & vbNewLine & _
                "SELECT @DateTo AS Period, DraftBy AS UserID, A.NotaryOrderID, A.NoUrut+' - '+NoBulanan AS NoUrut, A.TglAkta, A.JenisTransaksi, " & vbNewLine & _
                "'F-D' AS Tipe, A.FileLocation, '' AS Remarks, B.Nama, -@Fee, IsFalseDate, @CreatedBy FROM NMS_traNotaryOrder A " & vbNewLine & _
                "INNER JOIN NMS_traNotaryOrderClient1 B ON A.NotaryOrderID =B.NotaryOrderID AND B.[Index] =1  " & vbNewLine & _
                "LEFT JOIN NMS_traAdminFee C ON A.NotaryOrderID=C.OrderID AND C.Tipe='F-D' " & vbNewLine & _
                "WHERE CONVERT(VARCHAR(8),A.TglAkta,112)>= '20160101' AND C.OrderID IS NULL AND " & vbNewLine & _
                "CONVERT(VARCHAR(8),IsFalseDate,112)>=CONVERT(VARCHAR(8), @DateFrom,112) " & vbNewLine & _
                "AND CONVERT(VARCHAR(8),IsFalseDate,112)<= CONVERT(VARCHAR(8), @DateTo,112) AND DraftBy<>''  " & vbNewLine & _
                "AND IsFalseLevel IN (0,2) " & vbNewLine & _
                "UNION ALL " & vbNewLine & _
                "SELECT @DateTo, ProcessBy, A.NotaryOrderID, A.NoUrut+' - '+NoBulanan AS NoUrut, A.TglAkta, A.JenisTransaksi,  " & vbNewLine & _
                "'F-P' AS Tipe,A.FileLocation,'' AS Remarks, B.Nama, -@Fee, IsFalseDate, @CreatedBy  " & vbNewLine & _
                "FROM NMS_traNotaryOrder A  " & vbNewLine & _
                "INNER JOIN NMS_traNotaryOrderClient1 B ON A.NotaryOrderID =B.NotaryOrderID AND B.[Index] =1  " & vbNewLine & _
                "LEFT JOIN NMS_traAdminFee C ON A.NotaryOrderID=C.OrderID AND C.Tipe='F-P' " & vbNewLine & _
                "WHERE CONVERT(VARCHAR(8),A.TglAkta,112)>= '20160101' AND C.OrderID IS NULL AND " & vbNewLine & _
                "CONVERT(VARCHAR(8),IsFalseDate,112)>=CONVERT(VARCHAR(8), @DateFrom,112) " & vbNewLine & _
                "AND CONVERT(VARCHAR(8),IsFalseDate,112)<= CONVERT(VARCHAR(8), @DateTo,112) AND ProcessBy<>'' " & vbNewLine & _
                "AND IsFalseLevel IN (1,2)  " & vbNewLine & _
                "UNION ALL " & vbNewLine & _
                "SELECT @DateTo, DraftBy, A.PPATOrderID, NoAkta, A.TglAkta, CASE A.JenisTransaksi WHEN 0 THEN 'AJB' WHEN 1 THEN 'ATM' WHEN 2 THEN 'AH' WHEN 3 THEN 'APDP' WHEN 4 THEN 'APHB' WHEN 5 THEN 'APHGB' WHEN 6 THEN 'APHT' END AS JenisTransaksi, " & vbNewLine & _
                "'F-D' AS Tipe, A.FileLocation, '' AS Remarks, B.Nama, -@Fee, IsFalseDate, @CreatedBy  " & vbNewLine & _
                "FROM NMS_traPPATOrder A " & vbNewLine & _
                "INNER JOIN NMS_traPPATOrderClient1 B ON A.PPATOrderID =B.PPATOrderID AND B.[Index] =1 " & vbNewLine & _
                "LEFT JOIN NMS_traAdminFee C ON A.PPATOrderID=C.OrderID AND C.Tipe='F-D' " & vbNewLine & _
                "WHERE CONVERT(VARCHAR(8),A.TglAkta,112)>= '20160101' AND C.OrderID IS NULL AND " & vbNewLine & _
                "CONVERT(VARCHAR(8),IsFalseDate,112)>=CONVERT(VARCHAR(8), @DateFrom,112) " & vbNewLine & _
                "AND CONVERT(VARCHAR(8),IsFalseDate,112)<= CONVERT(VARCHAR(8), @DateTo,112) AND DraftBy<>'' " & vbNewLine & _
                "AND IsFalseLevel IN (0,2)  " & vbNewLine & _
                "UNION ALL  " & vbNewLine & _
                "SELECT @DateTo, ProcessBy, A.PPATOrderID, NoAkta, A.TglAkta, CASE A.JenisTransaksi WHEN 0 THEN 'AJB' WHEN 1 THEN 'ATM' WHEN 2 THEN 'AH' WHEN 3 THEN 'APDP' WHEN 4 THEN 'APHB' WHEN 5 THEN 'APHGB' WHEN 6 THEN 'APHT' END AS JenisTransaksi, " & vbNewLine & _
                "'F-P' AS Tipe, A.FileLocation, '' AS Remarks,B.Nama,-@Fee, IsFalseDate, @CreatedBy  " & vbNewLine & _
                "FROM NMS_traPPATOrder A " & vbNewLine & _
                "INNER JOIN NMS_traPPATOrderClient1 B ON A.PPATOrderID =B.PPATOrderID AND B.[Index] =1 " & vbNewLine & _
                "LEFT JOIN NMS_traAdminFee C ON A.PPATOrderID=C.OrderID AND C.Tipe='F-P'  " & vbNewLine & _
                "WHERE CONVERT(VARCHAR(8),A.TglAkta,112)>= '20160101' AND C.OrderID IS NULL AND " & vbNewLine & _
                "CONVERT(VARCHAR(8),IsFalseDate,112)>=CONVERT(VARCHAR(8), @DateFrom,112) " & vbNewLine & _
                "AND CONVERT(VARCHAR(8),IsFalseDate,112)<= CONVERT(VARCHAR(8), @DateTo,112) AND ProcessBy<>'' " & vbNewLine & _
                "AND IsFalseLevel IN (1,2) "

                .Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = dtDateFrom
                .Parameters.Add("@DateTo", SqlDbType.DateTime).Value = dtDateTo
                .Parameters.Add("@Fee", SqlDbType.Decimal).Value = decFee
                .Parameters.Add("@Createdby", SqlDbType.VarChar).Value = UI.usUserApp.UserID
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute)
            Catch ex As Exception
                Throw ex
            End Try

        End Sub

        Public Shared Sub UnClosePeriod(ByVal dtDateFrom As DateTime)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                "DELETE FROM NMS_traAdminFee WHERE CONVERT(VARCHAR(8),Period,112)=CONVERT(VARCHAR(8), @DateFrom,112)  "

                .Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = dtDateFrom

            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute)
            Catch ex As Exception
                Throw ex
            End Try

        End Sub

        Public Shared Function GetLastPeriod() As DateTime
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader
            Dim clsReturn As DateTime
            Try
                If Not SQL.bolUseTrans Then SQL.OpenConnection()
                With sqlcmdExecute
                    .Connection = SQL.sqlConn
                    .CommandText = _
                        "SELECT ISNULL(MAX(Period),'2015/12/31') AS Period FROM NMS_traAdminFee "

                    If SQL.bolUseTrans Then .Transaction = SQL.sqlTrans
                End With
                sqlrdData = sqlcmdExecute.ExecuteReader(CommandBehavior.SingleResult)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        clsReturn = .Item("Period")
              
                    End If
                    .Close()
                End With
                If Not SQL.bolUseTrans Then SQL.CloseConnection()
            Catch ex As Exception
                Throw ex
            End Try
            Return clsReturn
        End Function

        Public Shared Function GetAllPeriod() As DataTable

            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                "SELECT TOP 12 CONVERT(VARCHAR(10),Period,103) AS Period, CONVERT(VARCHAR(10),Period,112) AS PeriodStr FROM NMS_traAdminFee " & _
                "GROUP BY Period  " & _
                "ORDER BY Period DESC "

            End With
            Return SQL.QueryDataTable(sqlcmdExecute)
        End Function

    End Class

End Namespace
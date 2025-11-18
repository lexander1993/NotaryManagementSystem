Imports System.Data.SqlClient

Namespace DL

    Public Class CertificateOrder

        Public Shared Function CertificateOrderID(ByVal dtTglAkta As DateTime) As String
            Dim strCertificateOrderID As String = ""
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
                    "    SET @TMP = ISNULL(CAST((SELECT Top 1 RIGHT(CertificateOrderID, 6) " & _
                    "	 FROM NMS_traCertificateOrder WHERE Year(CreatedDate) = @Year AND Month(CreatedDate) = @Month AND SUBSTRING(CertificateOrderID,3,3) = @LocationInitial " & _
                    "	 Order By CertificateOrderID Desc) as int),0) + 1 " & _
                    "    SELECT('CT' + @LocationInitial +  Right(Cast(@Year as varchar(4)), 2) + " & _
                    "    dbo.udf_strZero(cast(@Month as varchar(2)),2,0) + dbo.udf_strZero(Cast(@TMP as varchar(6)),6,0)) AS CertificateOrderID " & _
                    "END "

                    .Parameters.Add("@TglAkta", SqlDbType.DateTime).Value = dtTglAkta
                    .Parameters.Add("@LocationInitial", SqlDbType.VarChar).Value = UI.usUserApp.LocationID

                    If SQL.bolUseTrans Then .Transaction = SQL.sqlTrans
                End With
                sqlrdData = sqlcmdExecute.ExecuteReader(CommandBehavior.SingleRow)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        strCertificateOrderID = .Item("CertificateOrderID")
                    End If
                    .Close()
                End With
                If Not SQL.bolUseTrans Then SQL.CloseConnection()
            Catch ex As Exception
                Throw ex
            End Try
            Return strCertificateOrderID
        End Function


        Public Shared Function ListData(ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                 "SELECT A.CertificateOrderID, A.TglPenyerahanDokumen, A.JenisNoHak, A.FileLocation, A.Remarks, " & _
                 "B.[Index], B.JenisTransaksi, B.ProcessBy, B.ProcessDate, B.ProcessRemarks, " & _
                 "B.BPNFinishBy, B.BPNFinishDate, B.BPNFinishRemarks  " & _
                 "FROM NMS_traCertificateOrder A " & _
                 "LEFT JOIN NMS_traCertificateOrderDet B ON " & _
                 "A.CertificateOrderID =B.CertificateOrderID  " & _
                 "WHERE CONVERT(VARCHAR(8),A.TglPenyerahanDokumen,112)>=  CONVERT(VARCHAR(8), @DateFrom,112) " & _
                 "AND CONVERT(VARCHAR(8),A.TglPenyerahanDokumen,112)<= CONVERT(VARCHAR(8), @DateTo,112)  " & _
                 "ORDER BY A.CertificateOrderID, B.[Index] "

                .Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = dtmDateFrom
                .Parameters.Add("@DateTo", SqlDbType.DateTime).Value = dtmDateTo

            End With
            Return SQL.QueryDataTable(sqlcmdExecute)
        End Function

        Public Shared Function ListDetail(ByVal strCertificateOrderID As String) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                    "SELECT [Index], CertificateOrderID, JenisTransaksi, ProcessBy, ProcessDate, ProcessRemarks, BPNFinishBy, BPNFinishDate, BPNFinishRemarks FROM NMS_traCertificateOrderDet " & _
                    "WHERE CertificateOrderID=@CertificateOrderID "

                .Parameters.Add("@CertificateOrderID", SqlDbType.VarChar, 20).Value = strCertificateOrderID
            End With
            Return SQL.QueryDataTable(sqlcmdExecute)
        End Function


        Public Shared Function GetDetail(ByVal strCertificateOrderID As String) As VO.CertificateOrder
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader
            Dim clsReturn As New VO.CertificateOrder
            Try
                If Not SQL.bolUseTrans Then SQL.OpenConnection()
                With sqlcmdExecute
                    .Connection = SQL.sqlConn
                    .CommandText = _
                       "SELECT CertificateOrderID,TglPenyerahanDokumen,TglPengembalianDokumen,JenisNoHak,FileLocation,Remarks,LetakTanahBangunan " & _
                       ",LuasTanahM2,LuasBangunanM2,HargaTransaksi " & _
                       "FROM NMS_traCertificateOrder " & _
                       "WHERE CertificateOrderID=@CertificateOrderID "

                    .Parameters.Add("@CertificateOrderID", SqlDbType.VarChar, 20).Value = strCertificateOrderID

                    If SQL.bolUseTrans Then .Transaction = SQL.sqlTrans
                End With
                sqlrdData = sqlcmdExecute.ExecuteReader(CommandBehavior.SingleResult)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        clsReturn.CertificateOrderID = .Item("CertificateOrderID")
                        clsReturn.TglPenyerahanDokumen = .Item("TglPenyerahanDokumen")
                        clsReturn.TglPengembalianDokumen = .Item("TglPengembalianDokumen")
                        clsReturn.JenisNoHak = .Item("JenisNoHak")
                        clsReturn.FileLocation = .Item("FileLocation")
                        clsReturn.Remarks = .Item("Remarks")
                        clsReturn.LetakTanahBangunan = .Item("LetakTanahBangunan")
                        clsReturn.LuasTanahM2 = .Item("LuasTanahM2")
                        clsReturn.LuasBangunanM2 = .Item("LuasBangunanM2")
                        clsReturn.HargaTransaksi = .Item("HargaTransaksi")
                    End If
                    .Close()
                End With
                If Not SQL.bolUseTrans Then SQL.CloseConnection()
            Catch ex As Exception
                Throw ex
            End Try
            Return clsReturn
        End Function

        Public Shared Sub SaveAllData(ByVal bolNew As Boolean, ByVal strCertificateOrderID As String, ByVal clsData As VO.CertificateOrder, ByVal clsClient1() As VO.CertificateOrderDet)
            Dim intI As Integer = 1

            DL.SQL.OpenConnection()
            DL.SQL.BeginTransaction()
            Try
                'Save Header
                DL.CertificateOrder.SaveData(bolNew, clsData)

                'Save Client1
                If Not bolNew Then DL.CertificateOrder.DeleteDetail(strCertificateOrderID)
                For Each DataItem As VO.CertificateOrderDet In clsClient1
                    If DataItem IsNot Nothing Then
                        DL.CertificateOrder.SaveDetail(DataItem)
                    End If
                    intI += 1
                Next

                DL.SQL.CommitTransaction()
            Catch ex As Exception
                DL.SQL.RollBackTransaction()
                Throw ex
            Finally
                DL.SQL.CloseConnection()
            End Try


        End Sub

        Public Shared Sub SaveData(ByVal bolNew As Boolean, ByVal clsData As VO.CertificateOrder)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                If bolNew Then
                    .CommandText = _
                        "INSERT INTO NMS_traCertificateOrder (CertificateOrderID,TglPenyerahanDokumen,TglPengembalianDokumen,FileLocation,Remarks,JenisNoHak,LetakTanahBangunan " & _
                        ",LuasTanahM2,LuasBangunanM2,HargaTransaksi,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate) " & _
                        "VALUES (@CertificateOrderID,@TglPenyerahanDokumen,@TglPengembalianDokumen,@FileLocation,@Remarks,@JenisNoHak,@LetakTanahBangunan " & _
                        ",@LuasTanahM2,@LuasBangunanM2,@HargaTransaksi,@CreatedBy,GETDATE(),@ModifiedBy,GETDATE() ) "

                Else
                    .CommandText = _
                        "UPDATE NMS_traCertificateOrder " & _
                        "SET TglPenyerahanDokumen=@TglPenyerahanDokumen,TglPengembalianDokumen=@TglPengembalianDokumen,FileLocation=@FileLocation,Remarks=@Remarks,JenisNoHak=@JenisNoHak,LetakTanahBangunan=@LetakTanahBangunan " & _
                        ",LuasTanahM2=@LuasTanahM2,LuasBangunanM2=@LuasBangunanM2,HargaTransaksi=@HargaTransaksi, ModifiedBy=@ModifiedBy, ModifiedDate=GETDATE() " & _
                        "WHERE CertificateOrderID=@CertificateOrderID "
                End If

                .Parameters.Add("@CertificateOrderID", SqlDbType.VarChar).Value = clsData.CertificateOrderID
                .Parameters.Add("@TglPenyerahanDokumen", SqlDbType.DateTime).Value = clsData.TglPenyerahanDokumen
                .Parameters.Add("@TglPengembalianDokumen", SqlDbType.DateTime).Value = clsData.TglPengembalianDokumen
                .Parameters.Add("@JenisNoHak", SqlDbType.VarChar).Value = clsData.JenisNoHak
                .Parameters.Add("@FileLocation", SqlDbType.VarChar).Value = clsData.FileLocation
                .Parameters.Add("@Remarks", SqlDbType.VarChar).Value = clsData.Remarks
                .Parameters.Add("@LetakTanahBangunan", SqlDbType.VarChar).Value = clsData.LetakTanahBangunan
                .Parameters.Add("@LuasTanahM2", SqlDbType.Decimal).Value = clsData.LuasTanahM2
                .Parameters.Add("@LuasBangunanM2", SqlDbType.Decimal).Value = clsData.LuasBangunanM2
                .Parameters.Add("@HargaTransaksi", SqlDbType.Decimal).Value = clsData.HargaTransaksi
                .Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = UI.usUserApp.UserID
                .Parameters.Add("@ModifiedBy", SqlDbType.VarChar).Value = UI.usUserApp.UserID
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub DeleteHeader(ByVal strCertificateOrderID As String)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                    "DELETE NMS_traCertificateOrder WHERE CertificateOrderID=@CertificateOrderID "

                .Parameters.Add("@CertificateOrderID", SqlDbType.VarChar, 20).Value = strCertificateOrderID
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub SaveDetail(ByVal clsData As VO.CertificateOrderDet)
            If clsData.JenisTransaksi = "" Then Exit Sub
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                "INSERT INTO NMS_traCertificateOrderDet (CertificateOrderID, [Index], JenisTransaksi, ProcessBy, ProcessDate, ProcessRemarks, BPNFinishBy, BPNFinishDate, BPNFinishRemarks) " & _
                "VALUES (@CertificateOrderID, @Index, @JenisTransaksi, @ProcessBy, @ProcessDate, @ProcessRemarks, @BPNFinishBy, @BPNFinishDate, @BPNFinishRemarks) "


                .Parameters.Add("@CertificateOrderID", SqlDbType.VarChar).Value = clsData.CertificateOrderID
                .Parameters.Add("@Index", SqlDbType.Int).Value = clsData.Index
                .Parameters.Add("@JenisTransaksi", SqlDbType.VarChar).Value = clsData.JenisTransaksi
                .Parameters.Add("@ProcessBy", SqlDbType.VarChar).Value = clsData.ProcessBy
                If clsData.ProcessDate = Today.AddYears(100) Then
                    .Parameters.Add("@ProcessDate", SqlDbType.DateTime).Value = System.DBNull.Value
                Else
                    .Parameters.Add("@ProcessDate", SqlDbType.DateTime).Value = clsData.ProcessDate
                End If
                .Parameters.Add("@ProcessRemarks", SqlDbType.VarChar).Value = clsData.ProcessRemarks
                .Parameters.Add("@BPNFinishBy", SqlDbType.VarChar).Value = clsData.BPNFinishBy
                If clsData.BPNFinishDate = Today.AddYears(100) Then
                    .Parameters.Add("@BPNFinishDate", SqlDbType.DateTime).Value = System.DBNull.Value
                Else
                    .Parameters.Add("@BPNFinishDate", SqlDbType.DateTime).Value = clsData.BPNFinishDate
                End If
                .Parameters.Add("@BPNFinishRemarks", SqlDbType.VarChar).Value = clsData.BPNFinishRemarks
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub DeleteDetail(ByVal strCertificateOrderID As String)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                    "DELETE NMS_traCertificateOrderDet WHERE CertificateOrderID=@CertificateOrderID "

                .Parameters.Add("@CertificateOrderID", SqlDbType.VarChar, 20).Value = strCertificateOrderID
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

    End Class

End Namespace

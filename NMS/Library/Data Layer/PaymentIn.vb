Imports System.Data.SqlClient

Namespace DL

    Public Class PaymentIn

        Public Shared Function ListData(ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                "SELECT A.PInID, A.NoAkta, A.NamaClient, A.PDate, A.B*10000 AS B, A.Remarks, A.IsOther, A.CreatedBy, " & _
                "A.CreatedDate, A.ModifiedBy, A.ModifiedDate, MAX(B.POutID) AS POutID , CASE A.Status WHEN 0 THEN 'LUNAS' ELSE 'BELUM LUNAS' END AS Status FROM NMS_traPIn A " & _
                "LEFT JOIN NMS_traPOut B ON A.PInID=B.PInID  " & _
                "WHERE CONVERT(VARCHAR(8),A.PDate,112)>=CONVERT(VARCHAR(8),@DateFrom,112)   " & _
                "AND CONVERT(VARCHAR(8),A.PDate,112)<=CONVERT(VARCHAR(8),@DateTo,112)  " & _
                "GROUP BY A.PInID, A.NoAkta, A.NamaClient, A.PDate, A.B, A.Remarks, A.IsOther, A.CreatedBy, " & _
                "A.CreatedDate, A.ModifiedBy, A.ModifiedDate,A.Status "


                .Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = dtmDateFrom
                .Parameters.Add("@DateTo", SqlDbType.DateTime).Value = dtmDateTo

            End With
            Return SQL.QueryDataTable(sqlcmdExecute)
        End Function

        Public Shared Function ListAllOrder(ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime, ByVal intTransType As Integer) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                If intTransType = 0 Then
                    .CommandText = _
                    "SELECT ROW_NUMBER() OVER(ORDER BY A.NoUrut) AS Row, " & _
                    "A.NoUrut AS NoAkta, B.Nama, A.TglAkta, JenisTransaksi  FROM NMS_traNotaryOrder A    " & _
                    "INNER JOIN NMS_traNotaryOrderClient1 B ON A.NotaryOrderID=B.NotaryOrderID AND B.[Index]=1   " & _
                    "WHERE CONVERT(VARCHAR(8),TglAkta,112)>=CONVERT(VARCHAR(8),@DateFrom,112)   " & _
                    "AND CONVERT(VARCHAR(8),TglAkta,112)<=CONVERT(VARCHAR(8),@DateTo,112)    " & _
                    "AND A.NoUrut<>''   "
                ElseIf intTransType = 1 Then
                    .CommandText = _
                    "SELECT ROW_NUMBER() OVER(ORDER BY A.NoAkta) AS Row, " & _
                    "A.NoAkta, B.Nama, A.TglAkta, CASE JenisTransaksi WHEN 0 THEN 'AJB' WHEN 1 THEN 'ATM' WHEN 2 THEN 'AH' WHEN 3 THEN 'APDP' WHEN 4 THEN 'APHB' WHEN 5 THEN 'APHGB' WHEN 6 THEN 'APHT' WHEN 7 THEN 'ROYA' WHEN 8 THEN 'BALIK NAMA' WHEN 9 THEN 'GANTI BLANKO' WHEN 10 THEN 'MOHON HAK' WHEN 11 THEN 'PENINGKATAN HAK' WHEN 12 THEN 'PEMASANGAN HAK TANGGUNGAN' END AS JenisTransaksi  FROM NMS_traPPATOrder A    " & _
                    "INNER JOIN NMS_traPPATOrderClient1 B ON A.PPATOrderID=B.PPATOrderID AND B.[Index]=1   " & _
                    "WHERE CONVERT(VARCHAR(8),TglAkta,112)>=CONVERT(VARCHAR(8),@DateFrom,112)   " & _
                    "AND CONVERT(VARCHAR(8),TglAkta,112)<=CONVERT(VARCHAR(8),@DateTo,112)    " & _
                    "AND A.NoAkta<>'' "
                Else
                    .CommandText = _
                    "SELECT ROW_NUMBER() OVER(ORDER BY A.NoAkta) AS Row, " & _
                    "NoAkta, Nama, TglAkta, JenisTransaksi FROM ( " & _
                    "SELECT A.NoUrut AS NoAkta, B.Nama, A.TglAkta, JenisTransaksi  FROM NMS_traNotaryOrder A    " & _
                    "INNER JOIN NMS_traNotaryOrderClient1 B ON A.NotaryOrderID=B.NotaryOrderID AND B.[Index]=1   " & _
                    "WHERE CONVERT(VARCHAR(8),TglAkta,112)>=CONVERT(VARCHAR(8),@DateFrom,112)   " & _
                    "AND CONVERT(VARCHAR(8),TglAkta,112)<=CONVERT(VARCHAR(8),@DateTo,112)    " & _
                    "AND A.NoUrut<>''   " & _
                    "UNION ALL   " & _
                    "SELECT A.NoAkta, B.Nama, A.TglAkta, CASE JenisTransaksi WHEN 0 THEN 'AJB' WHEN 1 THEN 'ATM' WHEN 2 THEN 'AH' WHEN 3 THEN 'APDP' WHEN 4 THEN 'APHB' WHEN 5 THEN 'APHGB' WHEN 6 THEN 'APHT' WHEN 7 THEN 'ROYA' WHEN 8 THEN 'BALIK NAMA' WHEN 9 THEN 'GANTI BLANKO' WHEN 10 THEN 'MOHON HAK' WHEN 11 THEN 'PENINGKATAN HAK' WHEN 12 THEN 'PEMASANGAN HAK TANGGUNGAN' END AS JenisTransaksi FROM NMS_traPPATOrder A    " & _
                    "INNER JOIN NMS_traPPATOrderClient1 B ON A.PPATOrderID=B.PPATOrderID AND B.[Index]=1   " & _
                    "WHERE CONVERT(VARCHAR(8),TglAkta,112)>=CONVERT(VARCHAR(8),@DateFrom,112)   " & _
                    "AND CONVERT(VARCHAR(8),TglAkta,112)<=CONVERT(VARCHAR(8),@DateTo,112)    " & _
                    "AND A.NoAkta<>''  " & _
                    ") A "
                End If

                .Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = dtmDateFrom
                .Parameters.Add("@DateTo", SqlDbType.DateTime).Value = dtmDateTo

            End With
            Return SQL.QueryDataTable(sqlcmdExecute)
        End Function

        Public Shared Function GetDetail(ByVal intPaymentInID As Integer) As VO.PaymentIn
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader
            Dim clsReturn As New VO.PaymentIn
            Try
                If Not SQL.bolUseTrans Then SQL.OpenConnection()
                With sqlcmdExecute
                    .Connection = SQL.sqlConn
                    .CommandText = _
                     "SELECT PInID, NoAkta, NamaClient, PDate, B*10000 AS B, Remarks, IsOther, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, Status, ExpInterval  FROM NMS_traPIn  " & _
                     "WHERE PInID=@PInID "

                    .Parameters.Add("@PInID ", SqlDbType.Int).Value = intPaymentInID

                    If SQL.bolUseTrans Then .Transaction = SQL.sqlTrans
                End With
                sqlrdData = sqlcmdExecute.ExecuteReader(CommandBehavior.SingleResult)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        clsReturn.PInID = .Item("PInID")
                        clsReturn.NoAkta = .Item("NoAkta")
                        clsReturn.NamaClient = .Item("NamaClient")
                        clsReturn.PDate = .Item("PDate")
                        clsReturn.B = .Item("B")
                        clsReturn.Remarks = .Item("Remarks")
                        clsReturn.IsOther = .Item("IsOther")
                        clsReturn.CreatedBy = .Item("CreatedBy")
                        clsReturn.CreatedDate = .Item("CreatedDate")
                        clsReturn.ModifiedBy = .Item("ModifiedBy")
                        clsReturn.ModifiedDate = .Item("ModifiedDate")
                        clsReturn.Status = .Item("Status")
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

        Public Shared Sub SaveData(ByVal bolNew As Boolean, ByVal clsData As VO.PaymentIn)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                If bolNew Then
                    .CommandText = _
                        "INSERT INTO NMS_traPIn (NoAkta,NamaClient,PDate,B,Remarks,IsOther,CreatedBy,Status,ExpInterval) " & _
                        "VALUES (@NoAkta,@NamaClient,@PDate,@B,@Remarks,@IsOther,@User,@Status,@ExpInterval) "
                Else
                    .CommandText = _
                        "UPDATE NMS_traPIn SET " & _
                        "   NoAkta=@NoAkta, NamaClient=@NamaClient, PDate=@PDate, B=@B, Remarks=@Remarks, IsOther=@IsOther, " & _
                        "   ModifiedBy=@User, ModifiedDate=GETDATE(), Status=@Status, ExpInterval=@ExpInterval " & _
                        "   WHERE PInID=@PInID "
                End If

                .Parameters.Add("@PInID", SqlDbType.Int).Value = clsData.PInID
                .Parameters.Add("@NoAkta", SqlDbType.VarChar).Value = clsData.NoAkta
                .Parameters.Add("@NamaClient", SqlDbType.VarChar).Value = clsData.NamaClient
                .Parameters.Add("@PDate", SqlDbType.DateTime).Value = clsData.PDate
                .Parameters.Add("@B", SqlDbType.Decimal).Value = (clsData.B / 10000)
                .Parameters.Add("@Remarks", SqlDbType.VarChar).Value = clsData.Remarks
                .Parameters.Add("@IsOther", SqlDbType.Bit).Value = clsData.IsOther
                .Parameters.Add("@User", SqlDbType.VarChar).Value = UI.usUserApp.UserID
                .Parameters.Add("@Status", SqlDbType.Int).Value = clsData.Status
                .Parameters.Add("@ExpInterval", SqlDbType.Int).Value = clsData.ExpInterval
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub DeleteHeader(ByVal intPaymentInID As Integer)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                    "DELETE NMS_traPIn WHERE PInID=@PInID "

                .Parameters.Add("@PInID", SqlDbType.Int).Value = intPaymentInID
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Function ListRecapitulation(ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                "SELECT A.PInID, A.NoAkta AS NoAktaIn, A.NamaClient, A.PDate AS PDateIn, A.B*10000 AS BiayaIn, A.Remarks AS RemarksIn, " & _
                "B.POutID, B.NoAkta AS NoAktaOut, B.B*10000 AS BiayaOut, B.PDate AS PDateOut,B.Remarks AS RemarksOut, " & _
                "(A.B*10000)-(B.B*10000) AS Margin " & _
                "FROM NMS_traPIn A  " & _
                "LEFT JOIN NMS_traPOut B ON A.PInID=B.PInID    " & _
                "WHERE CONVERT(VARCHAR(8),A.PDate,112)>=CONVERT(VARCHAR(8),@DateFrom,112)   " & _
                "AND CONVERT(VARCHAR(8),A.PDate,112)<=CONVERT(VARCHAR(8),@DateTo,112)  "

                .Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = dtmDateFrom
                .Parameters.Add("@DateTo", SqlDbType.DateTime).Value = dtmDateTo

            End With
            Return SQL.QueryDataTable(sqlcmdExecute)
        End Function

        Public Shared Function CheckPOutUse(ByVal intPInID As Integer) As Boolean
            Dim bolValid As Boolean = False
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader
            Try
                If Not SQL.bolUseTrans Then SQL.OpenConnection()
                With sqlcmdExecute
                    .Connection = SQL.sqlConn
                    .CommandText = _
                        "SELECT TOP 1 1 AS Result " & _
                        "FROM NMS_traPOut " & _
                        "WHERE PInID =@PInID  "

                    .Parameters.Add("@PInID", SqlDbType.Int).Value = intPInID

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

        Public Shared Function NotificationPaymentRecord() As Integer
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader
            Dim intRecord As Integer = 0
            Try
                If Not SQL.bolUseTrans Then SQL.OpenConnection()
                With sqlcmdExecute
                    .Connection = SQL.sqlConn
                    .CommandText = _
                    "SELECT COUNT (*) AS Notification FROM (   " & vbNewLine & _
                    "SELECT 1 AS N FROM NMS_traPIn    " & vbNewLine & _
                    "WHERE ((ExpInterval) - DATEDIFF(DAY,PDate,GETDATE()) < 0 )  " & vbNewLine & _
                    "AND Status=1 " & vbNewLine & _
                    "UNION ALL " & vbNewLine & _
                    "SELECT 1 AS N FROM NMS_traPOut   " & vbNewLine & _
                    "WHERE ((ExpInterval) - DATEDIFF(DAY,PDate,GETDATE()) < 0 )  " & vbNewLine & _
                    "AND Status=1 " & vbNewLine & _
                    ") A "

                    If SQL.bolUseTrans Then .Transaction = SQL.sqlTrans
                End With
                sqlrdData = sqlcmdExecute.ExecuteReader(CommandBehavior.SingleRow)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        intRecord = .Item("Notification")
                        If intRecord > 30 Then intRecord = 30
                    End If
                    .Close()
                End With
                If Not SQL.bolUseTrans Then SQL.CloseConnection()
            Catch ex As Exception
                Throw ex
            End Try
            Return intRecord
        End Function

        Public Shared Function ListNotification() As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                "SELECT 'IN' AS PaymentType, PInID,NoAkta,NamaClient,PDate,B*10000 AS B,DATEDIFF(DAY,PDate,GETDATE()) AS ExpDays  " & vbNewLine & _
                "FROM NMS_traPIn  " & vbNewLine & _
                "WHERE ((ExpInterval) - DATEDIFF(DAY,PDate,GETDATE()) < 0 )  " & vbNewLine & _
                "AND Status=1 " & vbNewLine & _
                "UNION ALL " & vbNewLine & _
                "SELECT 'OUT' AS PaymentType, POutID,NoAkta,NamaClient,PDate,B*10000 AS B,DATEDIFF(DAY,PDate,GETDATE()) AS ExpDays  " & vbNewLine & _
                "FROM NMS_traPOut  " & vbNewLine & _
                "WHERE ((ExpInterval) - DATEDIFF(DAY,PDate,GETDATE()) < 0 )  " & vbNewLine & _
                "AND Status=1 "

            End With
            Return SQL.QueryDataTable(sqlcmdExecute)
        End Function


    End Class

End Namespace

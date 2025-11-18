Imports System.Data.SqlClient

Namespace DL

    Public Class PaymentOut

        Public Shared Function ListData(ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                "SELECT POutID, PInID, NoAkta, NamaClient, PDate, B*10000 AS B, Remarks, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, CASE Status WHEN 0 THEN 'LUNAS' ELSE 'BELUM LUNAS' END AS Status   FROM NMS_traPOut  " & _
                "WHERE CONVERT(VARCHAR(8),PDate,112)>=CONVERT(VARCHAR(8),@DateFrom,112) " & _
                "AND CONVERT(VARCHAR(8),PDate,112)<=CONVERT(VARCHAR(8),@DateTo,112) "

                .Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = dtmDateFrom
                .Parameters.Add("@DateTo", SqlDbType.DateTime).Value = dtmDateTo

            End With
            Return SQL.QueryDataTable(sqlcmdExecute)
        End Function

        Public Shared Function GetDetail(ByVal intPaymentOutID As Integer) As VO.PaymentIn
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader
            Dim clsReturn As New VO.PaymentIn
            Try
                If Not SQL.bolUseTrans Then SQL.OpenConnection()
                With sqlcmdExecute
                    .Connection = SQL.sqlConn
                    .CommandText = _
                     "SELECT POutID, PInID, NoAkta, NamaClient, PDate, B*10000 AS B, Remarks, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, Status, ExpInterval   FROM NMS_traPOut  " & _
                     "WHERE POutID=@POutID "

                    .Parameters.Add("@POutID ", SqlDbType.Int).Value = intPaymentOutID

                    If SQL.bolUseTrans Then .Transaction = SQL.sqlTrans
                End With
                sqlrdData = sqlcmdExecute.ExecuteReader(CommandBehavior.SingleResult)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        clsReturn.POutID = .Item("POutID")
                        clsReturn.PInID = .Item("PInID")
                        clsReturn.NoAkta = .Item("NoAkta")
                        clsReturn.NamaClient = .Item("NamaClient")
                        clsReturn.PDate = .Item("PDate")
                        clsReturn.B = .Item("B")
                        clsReturn.Remarks = .Item("Remarks")
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
                        "INSERT INTO NMS_traPOut (PInID,NoAkta,NamaClient,PDate,B,Remarks,CreatedBy,Status,ExpInterval) " & _
                        "VALUES (@PInID,@NoAkta,@NamaClient,@PDate,@B,@Remarks,@User,@Status,@ExpInterval) "
                Else
                    .CommandText = _
                        "UPDATE NMS_traPOut SET " & _
                        "   PInID=@PInID, NoAkta=@NoAkta, NamaClient=@NamaClient, PDate=@PDate, B=@B, Remarks=@Remarks, " & _
                        "   ModifiedBy=@User, ModifiedDate=GETDATE(), Status=@Status, ExpInterval=@ExpInterval " & _
                        "   WHERE POutID=@POutID "
                End If

                .Parameters.Add("@POutID", SqlDbType.Int).Value = clsData.POutID
                .Parameters.Add("@PInID", SqlDbType.Int).Value = clsData.PInID
                .Parameters.Add("@NoAkta", SqlDbType.VarChar).Value = clsData.NoAkta
                .Parameters.Add("@NamaClient", SqlDbType.VarChar).Value = clsData.NamaClient
                .Parameters.Add("@PDate", SqlDbType.DateTime).Value = clsData.PDate
                .Parameters.Add("@B", SqlDbType.Decimal).Value = (clsData.B / 10000)
                .Parameters.Add("@Remarks", SqlDbType.VarChar).Value = clsData.Remarks
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

        Public Shared Sub DeleteHeader(ByVal intPaymentOutID As Integer)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                    "DELETE NMS_traPOut WHERE POutID=@POutID "

                .Parameters.Add("@POutID", SqlDbType.Int).Value = intPaymentOutID
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Function CheckPIn(ByVal intPInID As Integer) As Boolean
            Dim bolValid As Boolean = False
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader
            Try
                If Not SQL.bolUseTrans Then SQL.OpenConnection()
                With sqlcmdExecute
                    .Connection = SQL.sqlConn
                    .CommandText = _
                        "SELECT TOP 1 1 AS Result " & _
                        "FROM NMS_traPIn " & _
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

    End Class

End Namespace

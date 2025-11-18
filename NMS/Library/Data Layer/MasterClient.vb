Imports System.Data.SqlClient

Namespace DL

    Public Class MasterClient

        Public Shared Function ListData(ByVal strNoID As String, ByVal strNama As String) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                    "SELECT TOP 100 JenisID, NoID, Nama, WargaNegara, Negara, TempatLahir, TglLahir, " & _
                    "MAX(Pekerjaan) AS Pekerjaan, MAX(Alamat) AS Alamat, MAX(NoHP) AS NoHP, COUNT(NotaryOrderID) AS JumlahOrder, MAX(Title) AS Title, MAX(TglLahirStr) AS TglLahirStr FROM( " & _
                    "SELECT JenisID, NoID, Nama, WargaNegara, Negara, TempatLahir, TglLahir, Pekerjaan, Alamat, NoHP, NotaryOrderID, Title, TglLahirStr FROM NMS_traNotaryOrderClient1 UNION ALL " & _
                    "SELECT JenisID, NoID, Nama, WargaNegara, Negara, TempatLahir, TglLahir, Pekerjaan, Alamat, NoHP, NotaryOrderID, Title, TglLahirStr FROM NMS_traNotaryOrderClient2 UNION ALL " & _
                    "SELECT JenisID, NoID, Nama, WargaNegara, Negara, TempatLahir, TglLahir, Pekerjaan, Alamat, NoHP, NotaryOrderID, Title, TglLahirStr FROM NMS_traNotaryOrderClient3 UNION ALL " & _
                    "SELECT JenisID, NoID, Nama, WargaNegara, Negara, TempatLahir, TglLahir, Pekerjaan, Alamat, NoHP, PPATOrderID, Title, TglLahirStr FROM NMS_traPPATOrderClient1 UNION ALL " & _
                    "SELECT JenisID, NoID, Nama, WargaNegara, Negara, TempatLahir, TglLahir, Pekerjaan, Alamat, NoHP, PPATOrderID, Title, TglLahirStr FROM NMS_traPPATOrderClient2 ) X  " & _
                    "WHERE 1=1 "

                If strNoID <> "" Then
                    .CommandText += "AND NoID LIKE '%" & strNoID & "%' "
                End If

                If strNama <> "" Then
                    .CommandText += "AND Nama LIKE '%" & strNama & "%' "
                End If

                .CommandText += "GROUP BY JenisID, NoID, Nama, WargaNegara, Negara, TempatLahir, TglLahir "

            End With
            Return SQL.QueryDataTable(sqlcmdExecute)
        End Function

        Public Shared Function ListDataDetail(ByVal strNoID As String) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                    "SELECT A.NotaryOrderID AS OrderID, TglAkta, NoUrut, JenisTransaksi, " & _
                    "CASE Status WHEN 1 THEN 'DRAFT' WHEN 2 THEN 'PROCESS' WHEN 3 THEN 'COMPLETED' END AS Status " & _
                    "FROM NMS_traNotaryOrder A " & _
                    "INNER JOIN ( " & _
                    "SELECT NotaryOrderID  FROM NMS_traNotaryOrderClient1 WHERE NoID =@NoID UNION ALL " & _
                    "SELECT NotaryOrderID  FROM NMS_traNotaryOrderClient2 WHERE NoID =@NoID UNION ALL " & _
                    "SELECT NotaryOrderID  FROM NMS_traNotaryOrderClient3 WHERE NoID =@NoID )X " & _
                    "ON A.NotaryOrderID =X.NotaryOrderID " & _
                    "UNION ALL " & _
                    "SELECT A.PPATOrderID, TglAkta, NoAkta, " & _
                    "CASE JenisTransaksi WHEN 0 THEN 'AJB' WHEN 1 THEN 'ATM' WHEN 2 THEN 'AH' WHEN 3 THEN 'APDP' WHEN 4 THEN 'APHB' WHEN 5 THEN 'APHGB' WHEN 6 THEN 'APHT' END AS JenisTransaksi, " & _
                    "CASE Status WHEN 1 THEN 'DRAFT' WHEN 2 THEN 'PROCESS' WHEN 3 THEN 'BPN FINISH' WHEN 4 THEN 'COMPLETED' END AS Status " & _
                    "FROM NMS_traPPATOrder A " & _
                    "INNER JOIN ( " & _
                    "SELECT PPATOrderID  FROM NMS_traPPATOrderClient1 WHERE NoID =@NoID UNION ALL " & _
                    "SELECT PPATOrderID  FROM NMS_traPPATOrderClient2 WHERE NoID =@NoID  )X " & _
                    "ON A.PPATOrderID =X.PPATOrderID "

                .Parameters.Add("@NoID", SqlDbType.VarChar).Value = strNoID
            End With
            Return SQL.QueryDataTable(sqlcmdExecute)
        End Function

        'Public Shared Function ListNotification() As DataTable
        '    Dim sqlcmdExecute As New SqlCommand
        '    With sqlcmdExecute
        '        .CommandText = _
        '            "SELECT NotaryOrderID AS OrderID, TglAkta, NoUrut, JenisTransaksi, CASE Status WHEN 1 THEN 'DRAFT' WHEN 2 THEN 'PROCESS' WHEN 3 THEN 'COMPLETED' END AS Status, " & _
        '            "CASE (ExpInterval) - DATEDIFF(DAY,TglAkta,GETDATE()) WHEN (3) THEN 'SISA 3 HARI' WHEN (2) THEN 'SISA 2 HARI' WHEN (1) THEN 'SISA 1 HARI' ELSE 'EXPIRED' END AS ExpiredStatus " & _
        '            "FROM NMS_traNotaryOrder WHERE ((ExpInterval) - DATEDIFF(DAY,TglAkta,GETDATE()) <= 3) AND Status <>3  " & _
        '            "UNION ALL " & _
        '            "SELECT PPATOrderID, TglAkta, NoAkta, " & _
        '            "CASE JenisTransaksi WHEN 0 THEN 'AJB' WHEN 1 THEN 'ATM' WHEN 2 THEN 'AH' WHEN 3 THEN 'APDP' WHEN 4 THEN 'APHB' WHEN 5 THEN 'APHGB' WHEN 6 THEN 'APHT' END AS JenisTransaksi, " & _
        '            "CASE Status WHEN 1 THEN 'DRAFT' WHEN 2 THEN 'PROCESS' WHEN 3 THEN 'BPN FINISH' WHEN 4 THEN 'COMPLETED' END AS Status, " & _
        '            "CASE (ExpInterval) - DATEDIFF(DAY,TglAkta,GETDATE()) WHEN (3) THEN 'SISA 3 HARI' WHEN (2) THEN 'SISA 2 HARI' WHEN (1) THEN 'SISA 1 HARI' ELSE 'EXPIRED' END AS ExpiredStatus " & _
        '            "FROM NMS_traPPATOrder WHERE ((ExpInterval) - DATEDIFF(DAY,TglAkta,GETDATE()) <= 3) AND Status <>4 "

        '    End With
        '    Return SQL.QueryDataTable(sqlcmdExecute)
        'End Function

        Public Shared Function ListNotification() As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                    "SELECT TOP 30 NotaryOrderID AS OrderID, TglAkta, NoUrut, JenisTransaksi, CASE Status WHEN 1 THEN 'DRAFT' WHEN 2 THEN 'PROCESS' WHEN 3 THEN 'COMPLETED' END AS Status, " & _
                    "CASE (ExpInterval) - DATEDIFF(DAY,TglAkta,GETDATE()) WHEN (3) THEN 'SISA 3 HARI' WHEN (2) THEN 'SISA 2 HARI' WHEN (1) THEN 'SISA 1 HARI' ELSE 'EXPIRED' END AS ExpiredStatus, " & _
                    "DraftBy, DraftDate, ProcessBy, ProcessDate, CompletedBy, CompletedDate " & _
                    "FROM NMS_traNotaryOrder WHERE ((ExpInterval) - DATEDIFF(DAY,TglAkta,GETDATE()) <= 3) AND Status <>3 AND JenisTransaksi ='SURAT KUASA MEMBEBANKAN HAK TANGGUNGAN'  "

            End With
            Return SQL.QueryDataTable(sqlcmdExecute)
        End Function

        Public Shared Function NotificationRecord() As Integer
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader
            Dim intRecord As Integer = 0
            Try
                If Not SQL.bolUseTrans Then SQL.OpenConnection()
                With sqlcmdExecute
                    .Connection = SQL.sqlConn
                    .CommandText = _
                        "SELECT COUNT (*) AS Notification FROM ( " & _
                        "SELECT 1 AS N FROM NMS_traNotaryOrder  WHERE ((ExpInterval) - DATEDIFF(DAY,TglAkta,GETDATE()) <= 3) AND Status <>3 AND JenisTransaksi ='SURAT KUASA MEMBEBANKAN HAK TANGGUNGAN' ) A "
                       
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

    End Class

End Namespace

Imports System.Data.SqlClient

Namespace DL

    Public Class Server

        'Melistkan daftar server yang ada untuk diganti password
        'Public Shared Function ServerList() As DataTable
        '    Dim sqlcmdExecute As New SqlCommand
        '    With sqlcmdExecute
        '        .CommandText = _
        '            "SELECT " & _
        '            "   Server, DBName, UserID, UserPassword " & _
        '            "FROM CPS_sysServerList " & _
        '            "GROUP BY " & _
        '            "   Server, DBName, UserID, UserPassword " & _
        '            "ORDER BY Server "
        '    End With
        '    Return SQL.QueryDataTable(sqlcmdExecute)
        'End Function

        Public Shared Function ServerAllCompanyList() As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                    "SELECT " & _
                    "   CompanyID, Server, DBName, UserID, UserPassword, IsLinkCFM, IsLinkInventory " & _
                    "FROM CPS_sysServerList " & _
                    "ORDER BY " & _
                    "   CompanyID "
            End With
            Return SQL.QueryDataTable(sqlcmdExecute)
        End Function

        Public Shared Function ServerByCompany(ByVal strCompanyID As String) As VO.Server
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader
            Dim clsReturn As New VO.Server
            Try
                If Not SQL.bolUseTrans Then SQL.OpenConnection()
                With sqlcmdExecute
                    .Connection = SQL.sqlConn
                    .CommandText = _
                        "SELECT TOP 1  " & _
                        "   Server, DBName, UserID, UserPassword " & _
                        "FROM CPS_sysServerList " & _
                        "WHERE " & _
                        "   CompanyID=@CompanyID "

                    .Parameters.Add("@CompanyID", SqlDbType.VarChar, 10).Value = strCompanyID
                    If SQL.bolUseTrans Then .Transaction = SQL.sqlTrans

                End With
                sqlrdData = sqlcmdExecute.ExecuteReader(CommandBehavior.SingleRow)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        clsReturn.CompanyID = strCompanyID
                        clsReturn.Server = .Item("Server")
                        clsReturn.DBName = .Item("DBName")
                        clsReturn.UserID = .Item("UserID")
                        clsReturn.UserPassword = .Item("UserPassword")
                    End If
                    .Close()
                End With
                If Not SQL.bolUseTrans Then SQL.CloseConnection()
            Catch ex As Exception
                Throw ex
            End Try
            Return clsReturn
        End Function

        Public Shared Function BackupDatabase(ByVal strBackup As String) As String
            Dim strBackupName As String = ""
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader
            Try
                If Not SQL.bolUseTrans Then SQL.OpenConnectionMaster()
                With sqlcmdExecute
                    .Connection = SQL.sqlConn
                    .CommandText = _
                        "EXECUTE master.dbo.usp_NMS_sysBackup @fileName, @db_name "

                    'Penggunaan query langsung tdk bisa untuk syntax BACK UP

                    .Parameters.Add("@fileName", SqlDbType.VarChar).Value = strBackup
                    .Parameters.Add("@db_name", SqlDbType.VarChar).Value = "NMS"

                    If SQL.bolUseTrans Then .Transaction = SQL.sqlTrans
                End With
                sqlrdData = sqlcmdExecute.ExecuteReader(CommandBehavior.SingleRow)
                With sqlrdData
                    If .HasRows Then
                        .Read()
                        strBackupName = .Item("@fileName")
                    End If
                    .Close()
                End With

                If Not SQL.bolUseTrans Then SQL.CloseConnection()
            Catch ex As Exception
                Throw ex
            End Try
            Return strBackupName
        End Function

        Public Shared Function RestoreDatabase(ByVal strRestore As String) As String
            Dim strBackupName As String = ""
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader

            Try
                If Not SQL.bolUseTrans Then SQL.OpenConnectionMaster()
                With sqlcmdExecute
                    .Connection = SQL.sqlConn
                    .CommandText = _
                        "ALTER DATABASE NMS SET SINGLE_USER WITH ROLLBACK IMMEDIATE " & _
                        "RESTORE DATABASE NMS " & _
                        "FROM DISK = @fileName " & _
                        "ALTER DATABASE NMS SET MULTI_USER "

                    '"EXECUTE master.dbo.usp_NMS_sysRestore @fileName, @db_name "

                    .Parameters.Add("@fileName", SqlDbType.VarChar).Value = strRestore
                    .Parameters.Add("@db_name", SqlDbType.VarChar).Value = "NMS"

                    If SQL.bolUseTrans Then .Transaction = SQL.sqlTrans
                End With
                sqlrdData = sqlcmdExecute.ExecuteReader(CommandBehavior.SingleRow)
                If Not SQL.bolUseTrans Then SQL.CloseConnection()

            Catch ex As Exception
                Throw ex
            End Try
            Return strBackupName
        End Function

        Public Shared Function CheckLastBackup() As Boolean
            Dim bolValid As Boolean = False
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader
            Try
                If Not SQL.bolUseTrans Then SQL.OpenConnection()
                With sqlcmdExecute
                    .Connection = SQL.sqlConn
                    .CommandText = _
                        "SELECT TOP 1 1 AS Result " & _
                        "FROM NMS_mstBackup " & _
                        "WHERE DATEDIFF(D,(SELECT TOP 1 BackupDate FROM NMS_mstBackup ORDER BY BackupDate DESC),GETDATE()) >=7 " & _
                        "ORDER BY BackupDate DESC "

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

        Public Shared Sub SaveBackupDate()
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .CommandText = _
                "INSERT INTO NMS_mstBackup(BackupDate) VALUES (GETDATE()) "
            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Function BackupDatabaseAuto() As String
            If CheckLastBackup() Then
                Dim strBackupName As String = ""
                Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader
                Try
                    If Not SQL.bolUseTrans Then SQL.OpenConnectionMaster()
                    With sqlcmdExecute
                        .Connection = SQL.sqlConn
                        .CommandText = _
                            "EXECUTE master.dbo.usp_NMS_sysBackup @fileName, @db_name "

                        'Penggunaan query langsung tdk bisa untuk syntax BACK UP

                        .Parameters.Add("@fileName", SqlDbType.VarChar).Value = UI.usUserApp.BackupLocation
                        .Parameters.Add("@db_name", SqlDbType.VarChar).Value = "NMS"

                        If SQL.bolUseTrans Then .Transaction = SQL.sqlTrans
                    End With
                    sqlrdData = sqlcmdExecute.ExecuteReader(CommandBehavior.SingleRow)
                    With sqlrdData
                        If .HasRows Then
                            .Read()
                            strBackupName = .Item("@fileName")
                        End If
                        .Close()
                    End With

                    SaveBackupDate()

                    If Not SQL.bolUseTrans Then SQL.CloseConnection()
                Catch ex As Exception
                    Throw ex
                End Try
                Return strBackupName
            End If
            Return Nothing
        End Function

    End Class

End Namespace

Namespace VO

    Public Class PPATOrder


        Private strPPATOrderID, strNoAkta, strJenisTransaksi, strJenisNoHak, strLetakTanahBangunan, strSPPTPBBNOPTahun, strStatus As String
        Private dtTglAkta, dtSSPTanggal, dtSSBTanggal As DateTime
        Private decLuasTanahM2, decLuasBangunanM2, decHargaTransaksi, decSPPTPBBNJOP, decSSPHarga, decSSBHarga As Decimal
        Private strFileLocation, strRemarks, strDraftBy, strProcessBy, strProcessRemarks, strBPNFinishBy, strBPNFinishRemarks, strCompletedBy, strCompletedRemarks, strModifiedBy As String
        Private dtDraftDate, dtProcessDate, dtBPNFinishDate, dtCompletedDate, dtIsFalseDate, dtModifiedDate, dtTglPenyerahanDokumen As DateTime
        Private bolIsFalse As Boolean
        Private intStatus, intJenisTransaksi, intIsFalseLevel, intExpInterval As Integer
        Private strIsFalseBy, strIsFalseRemarks, strIsFalseLevelStr, strProcessUserID As String

        Public Property PPATOrderID() As String
            Get
                Return strPPATOrderID
            End Get
            Set(ByVal value As String)
                strPPATOrderID = value
            End Set
        End Property

        Public Property NoAkta() As String
            Get
                Return strNoAkta
            End Get
            Set(ByVal value As String)
                strNoAkta = value
            End Set
        End Property

        Public Property TglAkta() As DateTime
            Get
                Return dtTglAkta
            End Get
            Set(ByVal value As DateTime)
                dtTglAkta = value
            End Set
        End Property

        Public Property JenisTransaksi() As Integer
            Get
                Return intJenisTransaksi
            End Get
            Set(ByVal value As Integer)
                intJenisTransaksi = value
            End Set
        End Property

        Public Property JenisTransaksiStr() As String
            Get
                Return strJenisTransaksi
            End Get
            Set(ByVal value As String)
                strJenisTransaksi = value
            End Set
        End Property

        Public Property JenisNoHak() As String
            Get
                Return strJenisNoHak
            End Get
            Set(ByVal value As String)
                strJenisNoHak = value
            End Set
        End Property

        Public Property LetakTanahBangunan() As String
            Get
                Return strLetakTanahBangunan
            End Get
            Set(ByVal value As String)
                strLetakTanahBangunan = value
            End Set
        End Property

        Public Property LuasTanahM2() As Decimal
            Get
                Return decLuasTanahM2
            End Get
            Set(ByVal value As Decimal)
                decLuasTanahM2 = value
            End Set
        End Property

        Public Property LuasBangunanM2() As Decimal
            Get
                Return decLuasBangunanM2
            End Get
            Set(ByVal value As Decimal)
                decLuasBangunanM2 = value
            End Set
        End Property

        Public Property HargaTransaksi() As Decimal
            Get
                Return decHargaTransaksi
            End Get
            Set(ByVal value As Decimal)
                decHargaTransaksi = value
            End Set
        End Property

        Public Property SPPTPBBNOPTahun() As String
            Get
                Return strSPPTPBBNOPTahun
            End Get
            Set(ByVal value As String)
                strSPPTPBBNOPTahun = value
            End Set
        End Property

        Public Property SPPTPBBNJOP() As Decimal
            Get
                Return decSPPTPBBNJOP
            End Get
            Set(ByVal value As Decimal)
                decSPPTPBBNJOP = value
            End Set
        End Property

        Public Property SSPTanggal() As DateTime
            Get
                Return dtSSPTanggal
            End Get
            Set(ByVal value As DateTime)
                dtSSPTanggal = value
            End Set
        End Property

        Public Property SSPHarga() As Decimal
            Get
                Return decSSPHarga
            End Get
            Set(ByVal value As Decimal)
                decSSPHarga = value
            End Set
        End Property

        Public Property SSBTanggal() As DateTime
            Get
                Return dtSSBTanggal
            End Get
            Set(ByVal value As DateTime)
                dtSSBTanggal = value
            End Set
        End Property

        Public Property SSBHarga() As Decimal
            Get
                Return decSSBHarga
            End Get
            Set(ByVal value As Decimal)
                decSSBHarga = value
            End Set
        End Property

        Public Property FileLocation() As String
            Get
                Return strFileLocation
            End Get
            Set(ByVal value As String)
                strFileLocation = value
            End Set
        End Property

        Public Property Remarks() As String
            Get
                Return strRemarks
            End Get
            Set(ByVal value As String)
                strRemarks = value
            End Set
        End Property

        Public Property Status() As Integer
            Get
                Return intStatus
            End Get
            Set(ByVal value As Integer)
                intStatus = value
            End Set
        End Property

        Public Property StatusStr() As String
            Get
                Return strStatus
            End Get
            Set(ByVal value As String)
                strStatus = value
            End Set
        End Property

        Public Property DraftBy() As String
            Get
                Return strDraftBy
            End Get
            Set(ByVal value As String)
                strDraftBy = value
            End Set
        End Property

        Public Property DraftDate() As DateTime
            Get
                Return dtDraftDate
            End Get
            Set(ByVal value As DateTime)
                dtDraftDate = value
            End Set
        End Property

        Public Property ProcessBy() As String
            Get
                Return strProcessBy
            End Get
            Set(ByVal value As String)
                strProcessBy = value
            End Set
        End Property

        Public Property ProcessDate() As DateTime
            Get
                Return dtProcessDate
            End Get
            Set(ByVal value As DateTime)
                dtProcessDate = value
            End Set
        End Property

        Public Property ProcessRemarks() As String
            Get
                Return strProcessRemarks
            End Get
            Set(ByVal value As String)
                strProcessRemarks = value
            End Set
        End Property

        Public Property BPNFinishBy() As String
            Get
                Return strBPNFinishBy
            End Get
            Set(ByVal value As String)
                strBPNFinishBy = value
            End Set
        End Property

        Public Property BPNFinishDate() As DateTime
            Get
                Return dtBPNFinishDate
            End Get
            Set(ByVal value As DateTime)
                dtBPNFinishDate = value
            End Set
        End Property

        Public Property BPNFinishRemarks() As String
            Get
                Return strBPNFinishRemarks
            End Get
            Set(ByVal value As String)
                strBPNFinishRemarks = value
            End Set
        End Property

        Public Property CompletedBy() As String
            Get
                Return strCompletedBy
            End Get
            Set(ByVal value As String)
                strCompletedBy = value
            End Set
        End Property


        Public Property CompletedDate() As DateTime
            Get
                Return dtCompletedDate
            End Get
            Set(ByVal value As DateTime)
                dtCompletedDate = value
            End Set
        End Property

        Public Property CompletedRemarks() As String
            Get
                Return strCompletedRemarks
            End Get
            Set(ByVal value As String)
                strCompletedRemarks = value
            End Set
        End Property

        Public Property IsFalse() As Boolean
            Get
                Return bolIsFalse
            End Get
            Set(ByVal value As Boolean)
                bolIsFalse = value
            End Set
        End Property

        Public Property IsFalseBy() As String
            Get
                Return strIsFalseBy
            End Get
            Set(ByVal value As String)
                strIsFalseBy = value
            End Set
        End Property

        Public Property IsFalseDate() As DateTime
            Get
                Return dtIsFalseDate
            End Get
            Set(ByVal value As DateTime)
                dtIsFalseDate = value
            End Set
        End Property

        Public Property IsFalseRemarks() As String
            Get
                Return strIsFalseRemarks
            End Get
            Set(ByVal value As String)
                strIsFalseRemarks = value
            End Set
        End Property

        Public Property ModifiedBy() As String
            Get
                Return strModifiedBy
            End Get
            Set(ByVal value As String)
                strModifiedBy = value
            End Set
        End Property

        Public Property ModifiedDate() As DateTime
            Get
                Return dtModifiedDate
            End Get
            Set(ByVal value As DateTime)
                dtModifiedDate = value
            End Set
        End Property

        Public Property TglPenyerahanDokumen() As DateTime
            Get
                Return dtTglPenyerahanDokumen
            End Get
            Set(ByVal value As DateTime)
                dtTglPenyerahanDokumen = value
            End Set
        End Property

        Public Property IsFalseLevel() As Integer
            Get
                Return intIsFalseLevel
            End Get
            Set(ByVal value As Integer)
                intIsFalseLevel = value
            End Set
        End Property

        Public Property IsFalseLevelStr() As String
            Get
                Return strIsFalseLevelStr
            End Get
            Set(ByVal value As String)
                strIsFalseLevelStr = value
            End Set
        End Property

        Public Property ProcessUserID() As String
            Get
                Return strProcessUserID
            End Get
            Set(ByVal value As String)
                strProcessUserID = value
            End Set
        End Property

        Public Property ExpInterval() As Integer
            Get
                Return intExpInterval
            End Get
            Set(ByVal value As Integer)
                intExpInterval = value
            End Set
        End Property

    End Class

End Namespace
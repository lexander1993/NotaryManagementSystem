Namespace VO

    Public Class NotaryOrder


        Private strNotaryOrderID, strNoUrut, strNoBulanan, strSifatAkta, strJenisTransaksi, strStatus As String
        Private intStatus, intJenisAkta, intIsFalseLevel, intExpInterval As Integer
        Private strFileLocation, strRemarks, strDraftBy, strProcessBy, strProcessRemarks, strCompletedBy, strCompletedRemarks, strModifiedBy As String
        Private dtTglAkta, dtDraftDate, dtProcessDate, dtCompletedDate, dtIsFalseDate, dtTglDidaftarkan, dtModifiedDate As DateTime
        Private bolIsFalse As Boolean
        Private strIsFalseBy, strIsFalseRemarks, strJenisAkta, strIsFalseLevelStr, strProcessUserID As String

        Public Property NotaryOrderID() As String
            Get
                Return strNotaryOrderID
            End Get
            Set(ByVal value As String)
                strNotaryOrderID = value
            End Set
        End Property

        Public Property NoUrut() As String
            Get
                Return strNoUrut
            End Get
            Set(ByVal value As String)
                strNoUrut = value
            End Set
        End Property

        Public Property NoBulanan() As String
            Get
                Return strNoBulanan
            End Get
            Set(ByVal value As String)
                strNoBulanan = value
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

        Public Property SifatAkta() As String
            Get
                Return strSifatAkta
            End Get
            Set(ByVal value As String)
                strSifatAkta = value
            End Set
        End Property

        Public Property JenisTransaksi() As String
            Get
                Return strJenisTransaksi
            End Get
            Set(ByVal value As String)
                strJenisTransaksi = value
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

        Public Property TglDidaftarkan() As DateTime
            Get
                Return dtTglDidaftarkan
            End Get
            Set(ByVal value As DateTime)
                dtTglDidaftarkan = value
            End Set
        End Property

        Public Property JenisAkta() As Integer
            Get
                Return intJenisAkta
            End Get
            Set(ByVal value As Integer)
                intJenisAkta = value
            End Set
        End Property

        Public Property JenisAktaStr() As String
            Get
                Return strJenisAkta
            End Get
            Set(ByVal value As String)
                strJenisAkta = value
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
Namespace VO

    Public Class PaymentIn

        Private intPInID, intPOutID, intStatus, intExpInterval As Integer
        Private strNoAkta, strNamaClient, strRemarks, strCreatedBy, strModifiedBy As String
        Private dtPDate, dtCreatedDate, dtModifiedDate As DateTime
        Private decB As Decimal
        Private bolIsOther As Boolean

        Public Property PInID() As Integer
            Get
                Return intPInID
            End Get
            Set(ByVal value As Integer)
                intPInID = value
            End Set
        End Property

        Public Property POutID() As Integer
            Get
                Return intPOutID
            End Get
            Set(ByVal value As Integer)
                intPOutID = value
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

        Public Property NamaClient() As String
            Get
                Return strNamaClient
            End Get
            Set(ByVal value As String)
                strNamaClient = value
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

        Public Property CreatedBy() As String
            Get
                Return strCreatedBy
            End Get
            Set(ByVal value As String)
                strCreatedBy = value
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

        Public Property PDate() As DateTime
            Get
                Return dtPDate
            End Get
            Set(ByVal value As DateTime)
                dtPDate = value
            End Set
        End Property

        Public Property CreatedDate() As DateTime
            Get
                Return dtCreatedDate
            End Get
            Set(ByVal value As DateTime)
                dtCreatedDate = value
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

        Public Property B() As Decimal
            Get
                Return decB
            End Get
            Set(ByVal value As Decimal)
                decB = value
            End Set
        End Property

        Public Property IsOther() As Boolean
            Get
                Return bolIsOther
            End Get
            Set(ByVal value As Boolean)
                bolIsOther = value
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
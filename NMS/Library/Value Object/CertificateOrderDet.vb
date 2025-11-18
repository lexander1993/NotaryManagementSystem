Namespace VO

    Public Class CertificateOrderDet

        Private strCertificateOrderID, strJenisTransaksi, strProcessBy, strBPNFinishBy, strProcessRemarks, strBPNFinishRemarks As String
        Private dtProcessDate, dtBPNFinishDate As DateTime
        Private intIndex As Integer

        Public Property CertificateOrderID() As String
            Get
                Return strCertificateOrderID
            End Get
            Set(ByVal value As String)
                strCertificateOrderID = value
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

        Public Property Index() As Integer
            Get
                Return intIndex
            End Get
            Set(ByVal value As Integer)
                intIndex = value
            End Set
        End Property


    End Class

End Namespace
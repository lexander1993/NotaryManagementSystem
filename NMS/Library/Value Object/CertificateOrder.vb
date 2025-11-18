Namespace VO

    Public Class CertificateOrder


        Private strCertificateOrderID, strJenisNoHak, strLetakTanahBangunan As String
        Private decLuasTanahM2, decLuasBangunanM2, decHargaTransaksi As Decimal
        Private strFileLocation, strRemarks, strModifiedBy As String
        Private dtModifiedDate, dtTglPenyerahanDokumen, dtTglPengembalianDokumen As DateTime

        Public Property CertificateOrderID() As String
            Get
                Return strCertificateOrderID
            End Get
            Set(ByVal value As String)
                strCertificateOrderID = value
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

        Public Property TglPengembalianDokumen() As DateTime
            Get
                Return dtTglPengembalianDokumen
            End Get
            Set(ByVal value As DateTime)
                dtTglPengembalianDokumen = value
            End Set
        End Property


    End Class

End Namespace
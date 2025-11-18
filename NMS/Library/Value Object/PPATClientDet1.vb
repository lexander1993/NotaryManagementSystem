Namespace VO

    Public Class PPATClientDet1

        Private strPPATOrderID, strJenisID, strNoID, strWargaNegara, strNegara, strNama, strTempatLahir, strTitle, strTglLahir As String
        Private dtTglLahir As DateTime
        Private strAlamat, strPekerjaan, strNoNPWP, strNoTelp, strNoHP, strRemarks As String
        Private intIndex As Integer

        Public Property PPATOrderID() As String
            Get
                Return strPPATOrderID
            End Get
            Set(ByVal value As String)
                strPPATOrderID = value
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

        Public Property JenisID() As String
            Get
                Return strJenisID
            End Get
            Set(ByVal value As String)
                strJenisID = value
            End Set
        End Property

        Public Property NoID() As String
            Get
                Return strNoID
            End Get
            Set(ByVal value As String)
                strNoID = value
            End Set
        End Property

        Public Property WargaNegara() As String
            Get
                Return strWargaNegara
            End Get
            Set(ByVal value As String)
                strWargaNegara = value
            End Set
        End Property

        Public Property Negara() As String
            Get
                Return strNegara
            End Get
            Set(ByVal value As String)
                strNegara = value
            End Set
        End Property

        Public Property Nama() As String
            Get
                Return strNama
            End Get
            Set(ByVal value As String)
                strNama = value
            End Set
        End Property

        Public Property TempatLahir() As String
            Get
                Return strTempatLahir
            End Get
            Set(ByVal value As String)
                strTempatLahir = value
            End Set
        End Property

        Public Property TglLahir() As DateTime
            Get
                Return dtTglLahir
            End Get
            Set(ByVal value As DateTime)
                dtTglLahir = value
            End Set
        End Property

        Public Property TglLahirStr() As String
            Get
                Return strTglLahir
            End Get
            Set(ByVal value As String)
                strTglLahir = value
            End Set
        End Property

        Public Property Alamat() As String
            Get
                Return strAlamat
            End Get
            Set(ByVal value As String)
                strAlamat = value
            End Set
        End Property

        Public Property Pekerjaan() As String
            Get
                Return strPekerjaan
            End Get
            Set(ByVal value As String)
                strPekerjaan = value
            End Set
        End Property

        Public Property NoNPWP() As String
            Get
                Return strNoNPWP
            End Get
            Set(ByVal value As String)
                strNoNPWP = value
            End Set
        End Property

        Public Property NoTelp() As String
            Get
                Return strNoTelp
            End Get
            Set(ByVal value As String)
                strNoTelp = value
            End Set
        End Property

        Public Property NoHP() As String
            Get
                Return strNoHP
            End Get
            Set(ByVal value As String)
                strNoHP = value
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

        Public Property Title() As String
            Get
                Return strTitle
            End Get
            Set(ByVal value As String)
                strTitle = value
            End Set
        End Property

    End Class

End Namespace
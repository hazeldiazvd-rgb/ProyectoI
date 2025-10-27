Public Class Doctor

    Private _IDMedico As Integer
    Private _Nombre As String
    Private _PrimerApellido As String
    Private _SegundoApellido As String
    Private _Especialidad As String
    Private _Telefono As Integer
    Private _Correo As String
    Private _Cedula As String

    Public Sub New(idMedico As Integer, nombre As String, primerApellido As String, segundoApellido As String, especialidad As String, telefono As Integer, correo As String, cedula As String)
        Me.IDMedico = idMedico
        Me.Nombre = nombre
        Me.PrimerApellido = primerApellido
        Me.SegundoApellido = segundoApellido
        Me.Especialidad = especialidad
        Me.Telefono = telefono
        Me.Correo = correo
        Me.Cedula = cedula
    End Sub

    Public Sub New(idMedico As Integer)
        Me.IDMedico = idMedico
    End Sub

    Public Sub New()
        ' Constructor vacío
    End Sub

    Public Property IDMedico As Integer
        Get
            Return _IDMedico
        End Get
        Set(value As Integer)
            _IDMedico = value
        End Set
    End Property

    Public Property Nombre As String
        Get
            Return _Nombre
        End Get
        Set(value As String)
            _Nombre = value
        End Set
    End Property

    Public Property PrimerApellido As String
        Get
            Return _PrimerApellido
        End Get
        Set(value As String)
            _PrimerApellido = value
        End Set
    End Property

    Public Property SegundoApellido As String
        Get
            Return _SegundoApellido
        End Get
        Set(value As String)
            _SegundoApellido = value
        End Set
    End Property

    Public Property Especialidad As String
        Get
            Return _Especialidad
        End Get
        Set(value As String)
            _Especialidad = value
        End Set
    End Property

    Public Property Telefono As Integer
        Get
            Return _Telefono
        End Get
        Set(value As Integer)
            _Telefono = value
        End Set
    End Property

    Public Property Correo As String
        Get
            Return _Correo
        End Get
        Set(value As String)
            _Correo = value
        End Set
    End Property

    Public Property Cedula As String
        Get
            Return _Cedula
        End Get
        Set(value As String)
            _Cedula = value
        End Set
    End Property



End Class

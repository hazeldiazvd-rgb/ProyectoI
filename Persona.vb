Public Class Persona
    Private _Cedula As Integer
    Private _Nombre As String
    Private _PrimerApellido As String
    Private _SegundoApellido As String
    Private _Telefono As Integer
    Private _Nacionalidad As String
    Private _Edad As Integer
    Private _Correo As String

    Public Sub New(cedula As Integer, nombre As String, primerApellido As String, segundoApellido As String, telefono As Integer, nacionalidad As String, edad As Integer, correo As String)
        Me.Cedula = cedula
        Me.Nombre = nombre
        Me.PrimerApellido = primerApellido
        Me.SegundoApellido = segundoApellido
        Me.Telefono = telefono
        Me.Nacionalidad = nacionalidad
        Me.Edad = edad
        Me.Correo = correo
    End Sub

    Public Sub New(cedula As Integer)
        Me.Cedula = cedula
    End Sub

    Public Sub New()
        ' Constructor vacío para permitir instanciación sin parámetros
    End Sub

    Public Property Cedula As Integer
        Get
            Return _Cedula
        End Get
        Set(value As Integer)
            _Cedula = value
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

    Public Property Telefono As Integer
        Get
            Return _Telefono
        End Get
        Set(value As Integer)
            _Telefono = value
        End Set
    End Property

    Public Property Nacionalidad As String
        Get
            Return _Nacionalidad
        End Get
        Set(value As String)
            _Nacionalidad = value
        End Set
    End Property

    Public Property Edad As Integer
        Get
            Return _Edad
        End Get
        Set(value As Integer)
            _Edad = value
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

End Class


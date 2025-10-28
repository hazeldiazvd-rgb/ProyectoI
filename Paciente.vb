Public Class Paciente


    Private _IdConsulta As Integer
    Private _CedulaPersona As Integer
    Private _IdDoctor As Integer
    Private _MotivoConsulta As String
    Private _Diagnostico As String

    Public Sub New(idConsulta As Integer, cedulaPersona As Integer, idDoctor As Integer, motivoConsulta As String, diagnostico As String)
        Me.IdConsulta = idConsulta
        Me.CedulaPersona = cedulaPersona
        Me.IdDoctor = idDoctor
        Me.MotivoConsulta = motivoConsulta
        Me.Diagnostico = diagnostico
    End Sub

    Public Sub New(idConsulta As Integer)
        Me.IdConsulta = idConsulta
    End Sub

    Public Sub New()
        ' Constructor vacío
    End Sub

    Public Property IdConsulta As Integer
        Get
            Return _IdConsulta
        End Get
        Set(value As Integer)
            _IdConsulta = value
        End Set
    End Property

    Public Property CedulaPersona As Integer
        Get
            Return _CedulaPersona
        End Get
        Set(value As Integer)
            _CedulaPersona = value
        End Set
    End Property

    Public Property IdDoctor As Integer
        Get
            Return _IdDoctor
        End Get
        Set(value As Integer)
            _IdDoctor = value
        End Set
    End Property

    Public Property MotivoConsulta As String
        Get
            Return _MotivoConsulta
        End Get
        Set(value As String)
            _MotivoConsulta = value
        End Set
    End Property

    Public Property Diagnostico As String
        Get
            Return _Diagnostico
        End Get
        Set(value As String)
            _Diagnostico = value
        End Set
    End Property

    Public Sub New(idConsulta As Integer, motivoConsulta As String, diagnostico As String)
        Me.IdConsulta = idConsulta
        Me.MotivoConsulta = motivoConsulta
        Me.Diagnostico = diagnostico
    End Sub

End Class

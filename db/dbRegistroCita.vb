Imports System.Data.SqlClient

Public Class dbRegistroCita
    Private ReadOnly ConnectionString As String = ConfigurationManager.ConnectionStrings("Proyecto-Progra3ConnectionString").ConnectionString

    Public Function createPaciente(p As Paciente) As Boolean
        Try
            Using con As New SqlConnection(ConnectionString)
                con.Open()
                Dim query As String = "INSERT INTO Paciente (CedulaPersona, IdDoctor, MotivoConsulta, Diagnostico) VALUES (@CedulaPersona, @IdDoctor, @MotivoConsulta, @Diagnostico)"
                Dim cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@CedulaPersona", p.CedulaPersona)
                cmd.Parameters.AddWithValue("@IdDoctor", p.IdDoctor)
                cmd.Parameters.AddWithValue("@MotivoConsulta", p.MotivoConsulta)
                cmd.Parameters.AddWithValue("@Diagnostico", p.Diagnostico)
                Return cmd.ExecuteNonQuery() > 0
            End Using
        Catch
            Return False
        End Try
    End Function

    Public Function updatePaciente(p As Paciente) As Boolean
        Try
            Using con As New SqlConnection(ConnectionString)
                con.Open()
                Dim query As String = "UPDATE Paciente SET MotivoConsulta=@MotivoConsulta, Diagnostico=@Diagnostico WHERE IdConsulta=@IdConsulta"
                Dim cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@MotivoConsulta", p.MotivoConsulta)
                cmd.Parameters.AddWithValue("@Diagnostico", p.Diagnostico)
                cmd.Parameters.AddWithValue("@IdConsulta", p.IdConsulta)
                Return cmd.ExecuteNonQuery() > 0
            End Using
        Catch
            Return False
        End Try
    End Function

    Public Function deletePaciente(idConsulta As Integer) As Boolean
        Try
            Using con As New SqlConnection(ConnectionString)
                con.Open()
                Dim query As String = "DELETE FROM Paciente WHERE IdConsulta=@IdConsulta"
                Dim cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@IdConsulta", idConsulta)
                Return cmd.ExecuteNonQuery() > 0
            End Using
        Catch
            Return False
        End Try
    End Function
End Class

Imports System.Data.SqlClient

Public Class DataBaseHelper

    Private ReadOnly ConnectionString As String = ConfigurationManager.ConnectionStrings("Proyecto-Progra3ConnectionString").ConnectionString

    Public Function create(Persona As Persona) As Boolean
        Try
            Dim sql As String = "INSERT INTO Persona (Cedula, Nombre, PrimerApellido, SegundoApellido, Telefono, Nacionalidad, Edad, Correo) VALUES (@Cedula, @Nombre, @PrimerApellido, @SegundoApellido, @Telefono, @Nacionalidad, @Edad, @Correo)"
            Dim Parametros As New List(Of SqlParameter) From {
            New SqlParameter("@Cedula", Persona.Cedula),
            New SqlParameter("@Nombre", Persona.Nombre),
            New SqlParameter("@PrimerApellido", Persona.PrimerApellido),
            New SqlParameter("@SegundoApellido", Persona.SegundoApellido),
            New SqlParameter("@Telefono", Persona.Telefono),
            New SqlParameter("@Nacionalidad", Persona.Nacionalidad),
            New SqlParameter("@Edad", Persona.Edad),
            New SqlParameter("@Correo", Persona.Correo)
        }

            Using connetion As New SqlConnection(ConnectionString)
                Using command As New SqlCommand(sql, connetion)
                    command.Parameters.AddRange(Parametros.ToArray())
                    connetion.Open()
                    command.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            Return False
        End Try

        Return True
    End Function


    Public Function delete(ByVal Cedula As Integer) As Boolean
        Try
            Dim sql As String = "DELETE FROM Persona WHERE Cedula = @Cedula"
            Dim Parametros As New List(Of SqlParameter) From {
            New SqlParameter("@Cedula", Cedula)
        }

            Using connection As New SqlConnection(ConnectionString)
                Using command As New SqlCommand(sql, connection)
                    command.Parameters.AddRange(Parametros.ToArray())
                    connection.Open()
                    command.ExecuteNonQuery()
                End Using
            End Using

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function


    Public Function update(ByVal Persona As Persona) As Boolean
        Try
            Dim sql As String = "UPDATE Persona SET Nombre = @Nombre, PrimerApellido = @PrimerApellido, SegundoApellido = @SegundoApellido, Telefono = @Telefono, Nacionalidad = @Nacionalidad, Edad = @Edad, Correo = @Correo WHERE Cedula = @Cedula"
            Dim Parametros As New List(Of SqlParameter) From {
            New SqlParameter("@Cedula", Persona.Cedula),
            New SqlParameter("@Nombre", Persona.Nombre),
            New SqlParameter("@PrimerApellido", Persona.PrimerApellido),
            New SqlParameter("@SegundoApellido", Persona.SegundoApellido),
            New SqlParameter("@Telefono", Persona.Telefono),
            New SqlParameter("@Nacionalidad", Persona.Nacionalidad),
            New SqlParameter("@Edad", Persona.Edad),
            New SqlParameter("@Correo", Persona.Correo)
        }

            Using connection As New SqlConnection(ConnectionString)
                Using command As New SqlCommand(sql, connection)
                    command.Parameters.AddRange(Parametros.ToArray())
                    connection.Open()
                    command.ExecuteNonQuery()
                End Using
            End Using

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function


    ' Crear Doctor
    Public Function createDoctor(ByVal doctor As Doctor) As Boolean
        Try
            Dim sql As String = "INSERT INTO Doctor (IDMedico, Nombre, PrimerApellido, SegundoApellido, Especialidad, Telefono, Correo, Cedula) 
                             VALUES (@IDMedico, @Nombre, @PrimerApellido, @SegundoApellido, @Especialidad, @Telefono, @Correo, @Cedula)"
            Dim parametros As New List(Of SqlParameter) From {
            New SqlParameter("@IDMedico", doctor.IDMedico),
            New SqlParameter("@Nombre", doctor.Nombre),
            New SqlParameter("@PrimerApellido", doctor.PrimerApellido),
            New SqlParameter("@SegundoApellido", doctor.SegundoApellido),
            New SqlParameter("@Especialidad", doctor.Especialidad),
            New SqlParameter("@Telefono", doctor.Telefono),
            New SqlParameter("@Correo", doctor.Correo),
            New SqlParameter("@Cedula", doctor.Cedula)
        }

            Using connection As New SqlConnection(ConnectionString)
                Using command As New SqlCommand(sql, connection)
                    command.Parameters.AddRange(parametros.ToArray())
                    connection.Open()
                    command.ExecuteNonQuery()
                End Using
            End Using
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    ' Eliminar Doctor
    Public Function deleteDoctor(ByVal idMedico As Integer) As Boolean
        Try
            Dim sql As String = "DELETE FROM Doctor WHERE IDMedico = @IDMedico"
            Dim parametros As New List(Of SqlParameter) From {
            New SqlParameter("@IDMedico", idMedico)
        }

            Using connection As New SqlConnection(ConnectionString)
                Using command As New SqlCommand(sql, connection)
                    command.Parameters.AddRange(parametros.ToArray())
                    connection.Open()
                    command.ExecuteNonQuery()
                End Using
            End Using
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    ' Actualizar Doctor
    Public Function updateDoctor(ByVal doctor As Doctor) As Boolean
        Try
            Dim sql As String = "UPDATE Doctor SET Nombre = @Nombre, PrimerApellido = @PrimerApellido, SegundoApellido = @SegundoApellido, 
                             Especialidad = @Especialidad, Telefono = @Telefono, Correo = @Correo, Cedula = @Cedula 
                             WHERE IDMedico = @IDMedico"
            Dim parametros As New List(Of SqlParameter) From {
            New SqlParameter("@IDMedico", doctor.IDMedico),
            New SqlParameter("@Nombre", doctor.Nombre),
            New SqlParameter("@PrimerApellido", doctor.PrimerApellido),
            New SqlParameter("@SegundoApellido", doctor.SegundoApellido),
            New SqlParameter("@Especialidad", doctor.Especialidad),
            New SqlParameter("@Telefono", doctor.Telefono),
            New SqlParameter("@Correo", doctor.Correo),
            New SqlParameter("@Cedula", doctor.Cedula)
        }

            Using connection As New SqlConnection(ConnectionString)
                Using command As New SqlCommand(sql, connection)
                    command.Parameters.AddRange(parametros.ToArray())
                    connection.Open()
                    command.ExecuteNonQuery()
                End Using
            End Using
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function


    ' ---------------- MÉTODOS PARA PACIENTE ----------------
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
                Dim query As String = "UPDATE Paciente SET CedulaPersona=@CedulaPersona, IdDoctor=@IdDoctor, MotivoConsulta=@MotivoConsulta, Diagnostico=@Diagnostico WHERE IdConsulta=@IdConsulta"
                Dim cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@CedulaPersona", p.CedulaPersona)
                cmd.Parameters.AddWithValue("@IdDoctor", p.IdDoctor)
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


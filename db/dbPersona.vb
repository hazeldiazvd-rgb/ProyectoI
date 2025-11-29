Imports System.Data.SqlClient

Public Class dbPersona

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
End Class

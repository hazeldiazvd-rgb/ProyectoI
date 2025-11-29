Imports System.Data.SqlClient

Public Class dbDoctor
    Private ReadOnly ConnectionString As String = ConfigurationManager.ConnectionStrings("Proyecto-Progra3ConnectionString").ConnectionString

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

End Class

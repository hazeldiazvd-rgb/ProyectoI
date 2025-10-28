Imports System.Data.SqlClient

Public Class FormPaciente
    Inherits System.Web.UI.Page
    Public paciente As New Paciente()
    Protected dbHelper As New DataBaseHelper()

    Private ReadOnly ConnectionString As String = ConfigurationManager.ConnectionStrings("Proyecto-Progra3ConnectionString").ConnectionString

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
    End Sub


    Protected Sub txtCedulaPersona_TextChanged(sender As Object, e As EventArgs)
        Try
            Using con As New SqlConnection(ConnectionString)
                con.Open()
                Dim cmd As New SqlCommand("SELECT Nombre, PrimerApellido, SegundoApellido FROM Persona WHERE Cedula=@Cedula", con)
                cmd.Parameters.AddWithValue("@Cedula", txtCedulaPersona.Text)
                Dim reader = cmd.ExecuteReader()
                If reader.Read() Then
                    lblDatosPersona.Text = $"{reader("Nombre")} {reader("PrimerApellido")} {reader("SegundoApellido")}"
                Else
                    lblDatosPersona.Text = "Persona no encontrada"
                End If
                reader.Close()
            End Using
        Catch ex As Exception
            lblDatosPersona.Text = "Error al buscar persona"
        End Try
    End Sub


    Protected Sub txtIdDoctor_TextChanged(sender As Object, e As EventArgs)
        Try
            Using con As New SqlConnection(ConnectionString)
                con.Open()
                Dim cmd As New SqlCommand("SELECT Nombre, PrimerApellido, SegundoApellido, Especialidad FROM Doctor WHERE IDMedico=@IDMedico", con)
                cmd.Parameters.AddWithValue("@IDMedico", txtIdDoctor.Text)
                Dim reader = cmd.ExecuteReader()
                If reader.Read() Then
                    lblDatosDoctor.Text = $"{reader("Nombre")} {reader("PrimerApellido")} {reader("SegundoApellido")} - {reader("Especialidad")}"
                Else
                    lblDatosDoctor.Text = "Doctor no encontrado"
                End If
                reader.Close()
            End Using
        Catch ex As Exception
            lblDatosDoctor.Text = "Error al buscar doctor"
        End Try
    End Sub


    ' GUARDAR NUEVO PACIENTE
    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs)
        Try
            paciente.CedulaPersona = Convert.ToInt32(txtCedulaPersona.Text)
            paciente.IdDoctor = Convert.ToInt32(txtIdDoctor.Text)
            paciente.MotivoConsulta = txtMotivoConsulta.Text
            paciente.Diagnostico = txtDiagnostico.Text

            If dbHelper.createPaciente(paciente) Then
                lblMensaje.Text = "Paciente creado correctamente"
                LimpiarCampos()
            Else
                lblMensaje.Text = "Error al crear el paciente"
            End If

            gvPacientes.DataBind()
        Catch ex As Exception
            lblMensaje.Text = "Error: " & ex.Message
        End Try
    End Sub

    ' ELIMINAR PACIENTE
    Protected Sub gvPacientes_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)
        Try
            Dim idConsulta As Integer = Convert.ToInt32(gvPacientes.DataKeys(e.RowIndex).Value)
            If dbHelper.deletePaciente(idConsulta) Then
                lblMensaje.Text = "Paciente eliminado"
            Else
                lblMensaje.Text = "Error al eliminar el paciente"
            End If
            e.Cancel = True
            gvPacientes.DataBind()
        Catch ex As Exception
            lblMensaje.Text = "Error al eliminar: " & ex.Message
        End Try
    End Sub

    ' ACTUALIZAR DESDE EDICIÓN EN GRIDVIEW
    Protected Sub gvPacientes_RowUpdating(sender As Object, e As GridViewUpdateEventArgs)
        Try
            Dim idConsulta As Integer = Convert.ToInt32(gvPacientes.DataKeys(e.RowIndex).Value)
            Dim paciente As New Paciente(
                idConsulta,
                Convert.ToInt32(e.NewValues("CedulaPersona")),
                Convert.ToInt32(e.NewValues("IdDoctor")),
                e.NewValues("MotivoConsulta").ToString(),
                e.NewValues("Diagnostico").ToString()
            )

            If dbHelper.updatePaciente(paciente) Then
                lblMensaje.Text = "Paciente actualizado"
            Else
                lblMensaje.Text = "Error al actualizar"
            End If

            gvPacientes.EditIndex = -1
            gvPacientes.DataBind()
            e.Cancel = True
        Catch ex As Exception
            lblMensaje.Text = "Error al actualizar: " & ex.Message
        End Try
    End Sub

    ' SELECCIONAR PARA FORMULARIO

    Protected Sub gvPacientes_SelectedIndexChanged(sender As Object, e As EventArgs)
        Try
            Dim row As GridViewRow = gvPacientes.SelectedRow

            txtCedulaPersona.Text = CType(row.FindControl("lblCedula"), Label).Text
            txtIdDoctor.Text = CType(row.FindControl("lblIdDoctor"), Label).Text
            txtMotivoConsulta.Text = HttpUtility.HtmlDecode(CType(row.FindControl("lblMotivoConsulta"), Label).Text)
            txtDiagnostico.Text = HttpUtility.HtmlDecode(CType(row.FindControl("lblDiagnostico"), Label).Text)

            editando.Value = gvPacientes.DataKeys(row.RowIndex).Value.ToString()
        Catch ex As Exception
            lblMensaje.Text = "Error al seleccionar: " & ex.Message
        End Try
    End Sub

    ' BOTÓN PARA ACTUALIZAR DESDE TEXTBOX
    Protected Sub btnActualizar_Click(sender As Object, e As EventArgs)
        Try
            Dim paciente As New Paciente(
                Convert.ToInt32(editando.Value),
                Convert.ToInt32(txtCedulaPersona.Text),
                Convert.ToInt32(txtIdDoctor.Text),
                txtMotivoConsulta.Text,
                txtDiagnostico.Text
            )

            If dbHelper.updatePaciente(paciente) Then
                lblMensaje.Text = "Paciente actualizado correctamente"
                LimpiarCampos()
            Else
                lblMensaje.Text = "Error al actualizar el paciente"
            End If

            gvPacientes.DataBind()
            gvPacientes.EditIndex = -1
        Catch ex As Exception
            lblMensaje.Text = "Error: " & ex.Message
        End Try
    End Sub

    ' MÉTODOS PARA EDICIÓN EN GRIDVIEW
    Protected Sub gvPacientes_RowEditing(sender As Object, e As GridViewEditEventArgs)
        gvPacientes.EditIndex = e.NewEditIndex
        gvPacientes.DataBind()
    End Sub

    Protected Sub gvPacientes_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs)
        gvPacientes.EditIndex = -1
        gvPacientes.DataBind()
    End Sub

    ' LIMPIAR CAMPOS
    Private Sub LimpiarCampos()
        txtCedulaPersona.Text = ""
        txtIdDoctor.Text = ""
        txtMotivoConsulta.Text = ""
        txtDiagnostico.Text = ""
        editando.Value = ""
    End Sub


End Class

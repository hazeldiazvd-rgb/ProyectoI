Public Class FormDoctor
    Inherits System.Web.UI.Page
    Public doctor As New Doctor()
    Protected dbHelper As New DataBaseHelper()


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub


    ' Guardar nuevo doctor
    Protected Sub btn_guardar_Click(sender As Object, e As EventArgs)
        Try
            doctor.IDMedico = Convert.ToInt32(txtIDMedico.Text)
            doctor.Nombre = txtNombre.Text
            doctor.PrimerApellido = txtPrimerApellido.Text
            doctor.SegundoApellido = txtSegundoApellido.Text
            doctor.Especialidad = txtEspecialidad.Text
            doctor.Telefono = Convert.ToInt32(txtTelefono.Text)
            doctor.Correo = txtCorreo.Text
            doctor.Cedula = txtCedula.Text

            If dbHelper.createDoctor(doctor) Then
                lblMensaje.Text = "Doctor creado correctamente"
                LimpiarCampos()
            Else
                lblMensaje.Text = "Error al crear el doctor"
            End If

            gvDoctores.DataBind()
        Catch ex As Exception
            lblMensaje.Text = "Error: " & ex.Message
        End Try
    End Sub

    ' Eliminar doctor
    Protected Sub gvDoctores_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)
        Try
            Dim idMedico As Integer = Convert.ToInt32(gvDoctores.DataKeys(e.RowIndex).Value)
            If dbHelper.deleteDoctor(idMedico) Then
                lblMensaje.Text = "Doctor eliminado"
            Else
                lblMensaje.Text = "Error al eliminar el doctor"
            End If
            e.Cancel = True
            gvDoctores.DataBind()
        Catch ex As Exception
            lblMensaje.Text = "Error al eliminar: " & ex.Message
        End Try
    End Sub

    ' Actualizar desde edición en GridView
    Protected Sub gvDoctores_RowUpdating(sender As Object, e As GridViewUpdateEventArgs)
        Try
            Dim idMedico As Integer = Convert.ToInt32(gvDoctores.DataKeys(e.RowIndex).Value)
            Dim doctor As New Doctor(
                idMedico,
                e.NewValues("Nombre").ToString(),
                e.NewValues("PrimerApellido").ToString(),
                e.NewValues("SegundoApellido").ToString(),
                e.NewValues("Especialidad").ToString(),
                Convert.ToInt32(e.NewValues("Telefono")),
                e.NewValues("Correo").ToString(),
                e.NewValues("Cedula").ToString()
            )

            If dbHelper.updateDoctor(doctor) Then
                lblMensaje.Text = "Doctor actualizado"
            Else
                lblMensaje.Text = "Error al actualizar"
            End If

            gvDoctores.EditIndex = -1
            gvDoctores.DataBind()
            e.Cancel = True
        Catch ex As Exception
            lblMensaje.Text = "Error al actualizar: " & ex.Message
        End Try
    End Sub

    ' Seleccionar fila para cargar datos en los TextBox
    Protected Sub gvDoctores_SelectedIndexChanged(sender As Object, e As EventArgs)
        Try
            Dim row As GridViewRow = gvDoctores.SelectedRow
            txtIDMedico.Text = gvDoctores.DataKeys(row.RowIndex).Value.ToString()
            txtNombre.Text = row.Cells(2).Text
            txtPrimerApellido.Text = row.Cells(3).Text
            txtSegundoApellido.Text = row.Cells(4).Text
            txtEspecialidad.Text = row.Cells(5).Text
            txtTelefono.Text = row.Cells(6).Text
            txtCorreo.Text = row.Cells(7).Text
            txtCedula.Text = row.Cells(8).Text
            editando.Value = txtIDMedico.Text
        Catch ex As Exception
            lblMensaje.Text = "Error al seleccionar: " & ex.Message
        End Try
    End Sub

    ' Botón para actualizar desde los TextBox
    Protected Sub btnActualizar_Click(sender As Object, e As EventArgs)
        Try
            Dim doctor As New Doctor(
                Convert.ToInt32(editando.Value),
                txtNombre.Text,
                txtPrimerApellido.Text,
                txtSegundoApellido.Text,
                txtEspecialidad.Text,
                Convert.ToInt32(txtTelefono.Text),
                txtCorreo.Text,
                txtCedula.Text
            )

            If dbHelper.updateDoctor(doctor) Then
                lblMensaje.Text = "Doctor actualizado correctamente"
                LimpiarCampos()
            Else
                lblMensaje.Text = "Error al actualizar el doctor"
            End If

            gvDoctores.DataBind()
            gvDoctores.EditIndex = -1
        Catch ex As Exception
            lblMensaje.Text = "Error: " & ex.Message
        End Try
    End Sub

    ' Métodos para edición en GridView (evitar errores)
    Protected Sub gvDoctores_RowEditing(sender As Object, e As GridViewEditEventArgs)
        gvDoctores.EditIndex = e.NewEditIndex
        gvDoctores.DataBind()
    End Sub

    Protected Sub gvDoctores_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs)
        gvDoctores.EditIndex = -1
        gvDoctores.DataBind()
    End Sub

    ' Limpiar campos
    Private Sub LimpiarCampos()
        txtIDMedico.Text = ""
        txtNombre.Text = ""
        txtPrimerApellido.Text = ""
        txtSegundoApellido.Text = ""
        txtEspecialidad.Text = ""
        txtTelefono.Text = ""
        txtCorreo.Text = ""
        txtCedula.Text = ""
    End Sub


End Class
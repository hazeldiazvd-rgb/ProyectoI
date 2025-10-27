Public Class Personas
    Inherits System.Web.UI.Page
    Public persona As New Persona()
    Protected dbHelper As New DataBaseHelper()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btn_guardar_Click(sender As Object, e As EventArgs)

        Persona.Cedula = txtCedula.Text
        Persona.Nombre = txtNombre.Text
        persona.PrimerApellido = txtPrimerApellido.Text
        persona.SegundoApellido = txtSegundoApellido.Text
        persona.Telefono = txtTelefono.Text
        persona.Nacionalidad = txtNacionalidad.Text
        persona.Edad = txtEdad.Text
        persona.Correo = txtCorreo.Text

        If dbHelper.create(Persona) Then
            lblMensaje.Text = "Persona creada"
            txtCedula.Text = ""
            txtNombre.Text = ""
            txtPrimerApellido.Text = ""
            txtSegundoApellido.Text = ""
            txtTelefono.Text = ""
            txtNacionalidad.Text = ""
            txtEdad.Text = ""
            txtCorreo.Text = ""
        Else
            lblMensaje.Text = "Ocurrio un error"
        End If

        gvPersonas.DataBind()

    End Sub

    Protected Sub gvPersonas_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)
        Try
            Dim cedula As Integer = Convert.ToInt32(gvPersonas.DataKeys(e.RowIndex).Value)
            If dbHelper.delete(cedula) Then
                lblMensaje.Text = "Persona eliminada"
            Else
                lblMensaje.Text = "Error al eliminar la persona"
            End If
            e.Cancel = True
            gvPersonas.DataBind()
        Catch ex As Exception
            lblMensaje.Text = "Error al eliminar la persona: " & ex.Message
        End Try
    End Sub

    Protected Sub gvPersonas_RowEditing(sender As Object, e As GridViewEditEventArgs)

    End Sub

    Protected Sub gvPersonas_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs)

        gvPersonas.EditIndex = -1
        gvPersonas.DataBind()


    End Sub



    Protected Sub gvPersonas_RowUpdating(sender As Object, e As GridViewUpdateEventArgs)
        Dim cedula As Integer = Convert.ToInt32(gvPersonas.DataKeys(e.RowIndex).Value)

        Dim persona As New Persona(
        cedula,
        e.NewValues("Nombre").ToString(),
        e.NewValues("PrimerApellido").ToString(),
        e.NewValues("SegundoApellido").ToString(),
        Convert.ToInt32(e.NewValues("Telefono")),
        e.NewValues("Nacionalidad").ToString(),
        Convert.ToInt32(e.NewValues("Edad")),
        e.NewValues("Correo").ToString()
    )

        If dbHelper.update(persona) Then
            lblMensaje.Text = "Persona actualizada"
        Else
            lblMensaje.Text = "Error al actualizar"
        End If

        gvPersonas.EditIndex = -1
        gvPersonas.DataBind()
        e.Cancel = True
    End Sub

    Protected Sub gvPersonas_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim row As GridViewRow = gvPersonas.SelectedRow
        Dim cedula As String = gvPersonas.DataKeys(row.RowIndex).Value.ToString()

        ' Asignar valores a los TextBox (ajusta los índices según el orden de tus columnas)
        txtCedula.Text = cedula
        txtNombre.Text = row.Cells(2).Text
        txtPrimerApellido.Text = row.Cells(3).Text
        txtSegundoApellido.Text = row.Cells(4).Text
        txtTelefono.Text = row.Cells(5).Text
        txtNacionalidad.Text = row.Cells(6).Text
        txtEdad.Text = row.Cells(7).Text
        txtCorreo.Text = row.Cells(8).Text

        ' Guardar la cedula en el HiddenField para usarla en la actualización
        editando.Value = cedula
    End Sub


    Private Sub LimpiarCampos()
        txtCedula.Text = ""
        txtNombre.Text = ""
        txtPrimerApellido.Text = ""
        txtSegundoApellido.Text = ""
        txtTelefono.Text = ""
        txtNacionalidad.Text = ""
        txtEdad.Text = ""
        txtCorreo.Text = ""
    End Sub



    Protected Sub btnActualizar_Click(sender As Object, e As EventArgs)
        Dim persona As New Persona(
            Convert.ToInt32(editando.Value), ' Cedula como clave
            txtNombre.Text,
            txtPrimerApellido.Text,
            txtSegundoApellido.Text,
            Convert.ToInt32(txtTelefono.Text),
            txtNacionalidad.Text,
            Convert.ToInt32(txtEdad.Text),
            txtCorreo.Text
        )

        If dbHelper.update(persona) Then
            lblMensaje.Text = "Persona actualizada correctamente"
            LimpiarCampos()
        Else
            lblMensaje.Text = "Error al actualizar la persona"
        End If

        gvPersonas.DataBind()
        gvPersonas.EditIndex = -1
    End Sub

End Class
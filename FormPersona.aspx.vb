Public Class FormPersona
    Inherits System.Web.UI.Page
    Public persona As New Persona()
    Protected dbHelper As New DataBaseHelper()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btn_guardar_Click(sender As Object, e As EventArgs)

        persona.Cedula = txtCedula.Text
        persona.Nombre = txtNombre.Text
        persona.PrimerApellido = txtPrimerApellido.Text
        persona.SegundoApellido = txtSegundoApellido.Text
        persona.Telefono = txtTelefono.Text
        persona.Nacionalidad = txtNacionalidad.Text
        persona.Edad = txtEdad.Text
        persona.Correo = txtCorreo.Text

        If dbHelper.create(persona) Then
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

    Protected Sub btnActualizar_Click(sender As Object, e As EventArgs)
        Try
            ' Validación
            If String.IsNullOrWhiteSpace(txtTelefono.Text) OrElse Not IsNumeric(txtTelefono.Text) Then
                lblMensaje.Text = "Teléfono debe ser numérico"
                Exit Sub
            End If

            If String.IsNullOrWhiteSpace(txtEdad.Text) OrElse Not IsNumeric(txtEdad.Text) Then
                lblMensaje.Text = "Edad debe ser numérica"
                Exit Sub
            End If

            Dim persona As New Persona(
            Convert.ToInt32(editando.Value),
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
        Catch ex As Exception
            lblMensaje.Text = "Error: " & ex.Message
        End Try
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

        txtCedula.Text = cedula
        txtNombre.Text = HttpUtility.HtmlDecode(row.Cells(3).Text)
        txtPrimerApellido.Text = HttpUtility.HtmlDecode(row.Cells(4).Text)
        txtSegundoApellido.Text = HttpUtility.HtmlDecode(row.Cells(5).Text)
        txtTelefono.Text = HttpUtility.HtmlDecode(row.Cells(6).Text)
        txtNacionalidad.Text = HttpUtility.HtmlDecode(row.Cells(7).Text)
        txtEdad.Text = HttpUtility.HtmlDecode(row.Cells(8).Text)
        txtCorreo.Text = HttpUtility.HtmlDecode(row.Cells(9).Text)

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



End Class
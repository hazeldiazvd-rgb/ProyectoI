Public Class Menu
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnDoctor_Click(sender As Object, e As EventArgs)
        Response.Redirect("FormDoctor.aspx")
    End Sub

    Protected Sub btnPaciente_Click(sender As Object, e As EventArgs)
        Response.Redirect("FormPaciente.aspx")
    End Sub

    Protected Sub btnPersona_Click(sender As Object, e As EventArgs)
        Response.Redirect("FormPersona.aspx")
    End Sub

End Class
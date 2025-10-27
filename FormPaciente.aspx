
<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="FormPaciente.aspx.vb" Inherits="ProyectoI.FormPaciente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <h2 class="mb-3">Formulario de Pacientes</h2>

    <asp:HiddenField ID="editando" runat="server" />

    <!-- Cédula Persona -->
    <div class="mb-3">
        <asp:TextBox ID="txtCedulaPersona" CssClass="form-control" placeholder="Cédula Persona" runat="server" AutoPostBack="true" OnTextChanged="txtCedulaPersona_TextChanged" />
        <asp:Label ID="lblDatosPersona" runat="server" CssClass="text-primary fw-bold" />
    </div>

    <!-- ID Doctor -->
    <div class="mb-3">
        <asp:TextBox ID="txtIdDoctor" CssClass="form-control" placeholder="ID Doctor" runat="server" AutoPostBack="true" OnTextChanged="txtIdDoctor_TextChanged" />
        <asp:Label ID="lblDatosDoctor" runat="server" CssClass="text-primary fw-bold" />
    </div>

    <!-- Motivo de Consulta -->
    <div class="mb-3">
        <asp:TextBox ID="txtMotivoConsulta" CssClass="form-control" placeholder="Motivo de Consulta" runat="server" />
    </div>

    <!-- Diagnóstico -->
    <div class="mb-3">
        <asp:TextBox ID="txtDiagnostico" CssClass="form-control" placeholder="Diagnóstico" TextMode="MultiLine" Rows="3" runat="server" />
    </div>

    <!-- Botones -->
    <div class="mb-3">
        <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-primary" Text="Guardar" OnClick="btnGuardar_Click" />
        <asp:Button ID="btnActualizar" runat="server" CssClass="btn btn-success" Text="Actualizar" OnClick="btnActualizar_Click" />
    </div>

    <!-- Mensaje -->
    <asp:Label ID="lblMensaje" runat="server" CssClass="fw-bold text-danger" />

    <!-- GridView -->
    <asp:GridView ID="gvPacientes" CssClass="table table-striped table-bordered mt-3" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSourcePaciente"
        DataKeyNames="IdConsulta"
        OnRowDeleting="gvPacientes_RowDeleting"
        OnSelectedIndexChanged="gvPacientes_SelectedIndexChanged"
        OnRowEditing="gvPacientes_RowEditing"
        OnRowCancelingEdit="gvPacientes_RowCancelingEdit"
        OnRowUpdating="gvPacientes_RowUpdating">
        <Columns>
            <asp:CommandField ShowEditButton="true" ControlStyle-CssClass="btn btn-primary" />
            <asp:CommandField ShowSelectButton="true" ControlStyle-CssClass="btn btn-success" />
            <asp:BoundField DataField="IdConsulta" HeaderText="ID Consulta" ReadOnly="True" />
            <asp:BoundField DataField="CedulaPersona" HeaderText="Cédula Paciente" />
            <asp:BoundField DataField="IdDoctor" HeaderText="Codigo Doctor" />
            <asp:BoundField DataField="MotivoConsulta" HeaderText="Motivo de Consulta" />
            <asp:BoundField DataField="Diagnostico" HeaderText="Diagnóstico" />
            <asp:CommandField ShowDeleteButton="true" ControlStyle-CssClass="btn btn-danger" />
        </Columns>
    </asp:GridView>

    <!-- SqlDataSource -->
    <asp:SqlDataSource ID="SqlDataSourcePaciente" runat="server"
        ConnectionString="<%$ ConnectionStrings:Proyecto-Progra3ConnectionString %>"
        SelectCommand="SELECT * FROM Paciente" />
</asp:Content>

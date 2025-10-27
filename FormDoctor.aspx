<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="FormDoctor.aspx.vb" Inherits="ProyectoI.FormDoctor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<style>
        .btn-hover-move {
            transition: transform 0.5s ease, box-shadow 0.2s;
        }
        .btn-hover-move:hover {
            transform: translateY(-4px) scale(1.04);
            box-shadow: 0 6px 18px rgba(0,0,0,0.3);
        }
    </style>

    <asp:HiddenField ID="editando" runat="server" />

    <div class="container d-flex flex-column mb-3 gap-2">
        <asp:TextBox ID="txtIDMedico" CssClass="form-control" placeholder="ID Médico" runat="server"></asp:TextBox>
        <asp:TextBox ID="txtNombre" CssClass="form-control" placeholder="Nombre" runat="server"></asp:TextBox>
        <asp:TextBox ID="txtPrimerApellido" CssClass="form-control" placeholder="Primer Apellido" runat="server"></asp:TextBox>
        <asp:TextBox ID="txtSegundoApellido" CssClass="form-control" placeholder="Segundo Apellido" runat="server"></asp:TextBox>
        <asp:TextBox ID="txtEspecialidad" CssClass="form-control" placeholder="Especialidad" runat="server"></asp:TextBox>
        <asp:TextBox ID="txtTelefono" CssClass="form-control" placeholder="Teléfono" runat="server"></asp:TextBox>
        <asp:TextBox ID="txtCorreo" CssClass="form-control" placeholder="Correo" runat="server"></asp:TextBox>
        <asp:TextBox ID="txtCedula" CssClass="form-control" placeholder="Cédula" runat="server"></asp:TextBox>

        <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-primary btn-hover-move" Text="Guardar" OnClick="btn_guardar_Click" />
        <asp:Button ID="btnActualizar" runat="server" CssClass="btn btn-success btn-hover-move" Text="Actualizar" OnClick="btnActualizar_Click" />

        <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
    </div>

    <asp:GridView ID="gvDoctores" CssClass="table table-striped table-hover table-info" runat="server" AutoGenerateColumns="False"
        DataSourceID="SqlDataSource" DataKeyNames="IDMedico"
        OnRowDeleting="gvDoctores_RowDeleting" OnRowEditing="gvDoctores_RowEditing"
        OnRowCancelingEdit="gvDoctores_RowCancelingEdit" OnRowUpdating="gvDoctores_RowUpdating"
        OnSelectedIndexChanged="gvDoctores_SelectedIndexChanged">
        <Columns>
            <asp:CommandField ShowEditButton="true" ControlStyle-CssClass="btn btn-primary" />
            <asp:CommandField ShowSelectButton="true" ControlStyle-CssClass="btn btn-success" />
            <asp:BoundField DataField="IDMedico" HeaderText="ID Médico" ReadOnly="True" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="PrimerApellido" HeaderText="Primer Apellido" />
            <asp:BoundField DataField="SegundoApellido" HeaderText="Segundo Apellido" />
            <asp:BoundField DataField="Especialidad" HeaderText="Especialidad" />
            <asp:BoundField DataField="Telefono" HeaderText="Teléfono" />
            <asp:BoundField DataField="Correo" HeaderText="Correo" />
            <asp:BoundField DataField="Cedula" HeaderText="Cédula" />
            <asp:CommandField ShowDeleteButton="true" ControlStyle-CssClass="btn btn-danger" />
        </Columns>
    </asp:GridView>

<asp:SqlDataSource ID="SqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:Proyecto-Progra3ConnectionString %>" ProviderName="<%$ ConnectionStrings:Proyecto-Progra3ConnectionString.ProviderName %>" SelectCommand="SELECT * FROM [Doctor]"></asp:SqlDataSource>

</asp:Content>

<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="FormPersona.aspx.vb" Inherits="ProyectoI.FormPersona" %>
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

    <asp:HiddenField ID="editando" runat="server"/> 

<div class="container d-flex flex-column mb-3 gap-2">

    <asp:TextBox ID="txtCedula" CssClass="form-control" placeholder="Cedula" runat="server"></asp:TextBox>
    <asp:TextBox ID="txtNombre" CssClass="form-control" placeholder="Nombre" runat="server"></asp:TextBox>
    <asp:TextBox ID="txtPrimerApellido" CssClass="form-control" placeholder="PrimerApellido" runat="server"></asp:TextBox>
    <asp:TextBox ID="txtSegundoApellido" CssClass="form-control" placeholder="SegundoApellido" runat="server"></asp:TextBox>
    <asp:TextBox ID="txtTelefono" CssClass="form-control" placeholder="Telefono" runat="server"></asp:TextBox>
    <asp:TextBox ID="txtNacionalidad" CssClass="form-control" placeholder="Nacionalidad" runat="server"></asp:TextBox>
    <asp:TextBox ID="txtEdad" CssClass="form-control" placeholder="Edad" runat="server"></asp:TextBox>
    <asp:TextBox ID="txtCorreo" CssClass="form-control" placeholder="Correo" runat="server"></asp:TextBox>

    <asp:Button ID="btnMostrar" runat="server" CssClass="btn btn-primary btn-hover-move" Text="Guardar" OnClick="btn_guardar_Click" />
    <asp:Button ID="btnActualizar" runat="server" CssClass="btn btn-primary btn-hover-move" Text="Actualizar" OnClick="btnActualizar_Click" />

    <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>

</div>
<asp:GridView ID="gvPersonas" CssClass="table table-striped table-hover table-success" runat="server" AutoGenerateColumns="False"
    DataSourceID="SqlDataSourceDoctor" DataKeyNames="Cedula" OnRowDeleting="gvPersonas_RowDeleting" 
    OnRowEditing="gvPersonas_RowEditing" OnRowCancelingEdit="gvPersonas_RowCancelingEdit" OnRowUpdating="gvPersonas_RowUpdating" OnSelectedIndexChanged="gvPersonas_SelectedIndexChanged">
    <Columns>
        <asp:CommandField ShowEditButton="true" ControlStyle-CssClass="btn btn-primary" />
        <asp:CommandField ShowSelectButton="true" ControlStyle-CssClass="btn btn-success" />
        <asp:BoundField DataField="Cedula" HeaderText="Cedula" ReadOnly="True" SortExpression="Cedula" />
        <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
        <asp:BoundField DataField="PrimerApellido" HeaderText="PrimerApellido" SortExpression="PrimerApellido" />
        <asp:BoundField DataField="SegundoApellido" HeaderText="SegundoApellido" SortExpression="SegundoApellido" />
        <asp:BoundField DataField="Telefono" HeaderText="Telefono" SortExpression="Telefono" />
        <asp:BoundField DataField="Nacionalidad" HeaderText="Nacionalidad" SortExpression="Nacionalidad" />
        <asp:BoundField DataField="Edad" HeaderText="Edad" SortExpression="Edad" />
        <asp:BoundField DataField="Correo" HeaderText="Correo" SortExpression="Correo" />
        <asp:CommandField ShowDeleteButton="true" ControlStyle-CssClass="btn btn-danger" />
    </Columns>
</asp:GridView>

    
<asp:SqlDataSource ID="SqlDataSourceDoctor" runat="server" ConnectionString="<%$ ConnectionStrings:Proyecto-Progra3ConnectionString %>" ProviderName="<%$ ConnectionStrings:Proyecto-Progra3ConnectionString.ProviderName %>" SelectCommand="SELECT * FROM [Persona]"></asp:SqlDataSource>

</asp:Content>

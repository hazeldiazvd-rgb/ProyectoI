<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Menu.aspx.vb" 
    Inherits="ProyectoI.Menu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    
<style>
        .menu-container {
            background: #fff;
            padding: 40px;
            border-radius: 12px;
            box-shadow: 0 4px 12px rgba(0, 0, 0, 0.2);
            text-align: center;
            max-width: 400px;
            margin: 50px auto;
        }

        .menu-container h2 {
            color: #333;
            margin-bottom: 30px;
            font-size: 26px;
        }

        .menu-button {
            display: block !important;
            width: 100% !important;
            padding: 15px !important;
            margin: 10px 0 !important;
            font-size: 18px !important;
            font-weight: bold !important;
            color: #fff !important;
            background-color: #007bff !important;
            border: none !important;
            border-radius: 8px !important;
            cursor: pointer;
            transition: background-color 0.3s ease, transform 0.2s ease;
        }

        .menu-button:hover {
            background-color: #0056b3 !important;
            transform: scale(1.05);
        }
    </style>


    <div class="menu-container">
    <h2>Seleccione el formulario</h2>
    <asp:Button ID="btnDoctor" runat="server" Text="Doctor" OnClick="btnDoctor_Click" />
    <asp:Button ID="btnPaciente" runat="server" Text="Paciente" OnClick="btnPaciente_Click" />
    <asp:Button ID="btnPersona" runat="server" Text="Persona" OnClick="btnPersona_Click" />
    </div>
</asp:Content>

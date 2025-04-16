<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SistemaReservaciones.Pages.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="login-container">
        <h2>Iniciar sesión</h2>

        <asp:Label ID="lblErrorMessage" runat="server" Text="Label"></asp:Label>
        
        <!-- Formulario de Login -->
        
        <asp:Label ID="lblEmail" runat="server" Text="Correo electrónico" AssociatedControlID="txtEmail" />
        <br />
        <asp:TextBox ID="txtEmail" runat="server" CssClass="input-field" Placeholder="Ingrese su correo electrónico" />
        <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ErrorMessage="Campo Requerido" ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="lblPassword" runat="server" Text="Contraseña" AssociatedControlID="txtPassword" />
        <br />
        <asp:TextBox ID="txtPassword" runat="server" CssClass="input-field" TextMode="Password" Placeholder="Ingrese su contraseña" />
        <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ErrorMessage="Campo Requerido" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
        <br />

        <!-- Mensaje de error -->
        <asp:Label ID="Label1" runat="server" ForeColor="Red" Visible="false" />
        <br />
        <asp:Button ID="btnLogin" runat="server" Text="Iniciar sesión"  CssClass="btn-login" OnClick="btnLogin_Click"/>
        <br />

    </div>
</asp:Content>


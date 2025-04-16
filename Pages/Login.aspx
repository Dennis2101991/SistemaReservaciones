<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SistemaReservaciones.Pages.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid p-0" style="background-image: url('https://example.com/tu-imagen-de-hotel.jpg');
             background-size: cover; background-position: center; height: 100vh;">
         
        <div class="overlay d-flex justify-content-center align-items-center" style="background: rgba(0, 0, 0, 0.5); height: 100%;">
             
            <div class="container py-5">
            <div class="row justify-content-center">
            <div class="col-md-6 col-lg-4">
                <h1 class="display-4 text-white text-center mb-4">Iniciar sesión</h1>
        
                   <!-- Formulario de Login -->
                   <div class="card p-4">
                       <asp:Label ID="lblEmail" runat="server" Text="Correo electrónico" AssociatedControlID="txtEmail" CssClass="form-label"/>
                       <br />
                       <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control mb-3 input-field" Placeholder="Ingrese su correo electrónico" />
                       <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ErrorMessage="Campo Requerido" ControlToValidate="txtEmail" CssClass="text-danger" ></asp:RequiredFieldValidator>
                       <br />
                       <asp:Label ID="lblPassword" runat="server" Text="Contraseña" AssociatedControlID="txtPassword" CssClass="form-label" />
                       <br />
                       <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control mb-3 input-field" TextMode="Password" Placeholder="Ingrese su contraseña" />
                       <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ErrorMessage="Campo Requerido" ControlToValidate="txtPassword" CssClass="text-danger"></asp:RequiredFieldValidator>
                       <br /><br />

                       <!-- Mensaje de error -->
                       <asp:Label ID="lblMensajeError" runat="server" ForeColor="Red" Visible="false" CssClass="mb-3" />
                       <br /><br />
                       <asp:Button ID="btnLogin" runat="server" Text="Iniciar sesión"  CssClass="btn btn-primary btn-lg" OnClick="btnLogin_Click"/>
                   </div>
            </div>
            </div>
            </div>
         </div>
    </div>
</asp:Content>


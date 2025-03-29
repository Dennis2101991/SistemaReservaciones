<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Misreservaciones.aspx.cs" Inherits="SistemaReservaciones.Pages.Misreservaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Mis reservaciones</h1>
    <div style="margin-bottom: 10px">
        <%--Redirige a la página para realizar una nueva reservación por medio del formulario --%>
        <a href="NuevaReservacion.aspx">Nueva reservación</a> 
    </div>

    <div>
        <asp:HiddenField ID="hdnidReservacion" runat="server" /> <%-- Código oculto--%>
        <div>
            <span>Hotel</span>
            <asp:TextBox ID="txtHotel" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div>
            <span>Fecha Entrada</span>
            <asp:TextBox ID="txtFechaEntrada" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div>
            <span>Fecha Salida</span>
            <asp:TextBox ID="txtFechaSalida" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div>
            <span>Costo</span>
            <asp:TextBox ID="txtCosto" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div>
            <span>Estado</span>
            <asp:TextBox ID="txtEstado" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>

</asp:Content>

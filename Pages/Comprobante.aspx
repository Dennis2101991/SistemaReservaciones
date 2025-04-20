<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Comprobante.aspx.cs" Inherits="SistemaReservaciones.Pages.Comprobante" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

   
    <div class="container mt-4">
        <h1 class="text-center">Comprobante de Reservación</h1>
        <hr />
        <div class="card">
            <div class="card-header bg-primary text-white">
                Detalles de la Reservación
            </div>
            <div class="card-body">
                <p><strong>Nombre del Cliente:</strong> <asp:Label ID="lblCliente" runat="server"></asp:Label></p>
                <p><strong>Hotel:</strong> <asp:Label ID="lblHotel" runat="server"></asp:Label></p>
                <p><strong>Habitación:</strong> <asp:Label ID="lblHabitacion" runat="server"></asp:Label></p>
                <p><strong>Fecha de Entrada:</strong> <asp:Label ID="lblFechaEntrada" runat="server"></asp:Label></p>
                <p><strong>Fecha de Salida:</strong> <asp:Label ID="lblFechaSalida" runat="server"></asp:Label></p>
                <p><strong>Total de Días:</strong> <asp:Label ID="lblTotalDias" runat="server"></asp:Label></p>
                <p><strong>Costo Total:</strong> <asp:Label ID="lblCostoTotal" runat="server"></asp:Label></p>
            </div>
            <div class="card-footer text-center">
                <asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="btn btn-secondary" PostBackUrl="~/Pages/GestionarReservaciones.aspx" />
            </div>
        </div>
    </div>



</asp:Content>

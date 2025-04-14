<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GestionarReservaciones.aspx.cs" Inherits="SistemaReservaciones.Pages.GestionarReservaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
    <h2>Consulta de Reservaciones - Empleados</h2>

  
        <div class="col-md-4">
            <asp:Button ID="btnBuscar" runat="server" CssClass="btn btn-primary" Text="Buscar" OnClick="btnBuscar_Click" />
        </div>
        
    </div>

    <!-- Mensajes -->
    <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger" Visible="false"></asp:Label>

    <!-- Resultados -->
  <asp:GridView ID="gvReservaciones" runat="server" CssClass="table table-striped" AutoGenerateColumns="false" 
    OnRowCommand="gvReservaciones_RowCommand">
    <Columns>
        <asp:BoundField DataField="Id" HeaderText="ID Reservación" />
        <asp:BoundField DataField="NombreUsuario" HeaderText="Nombre del Usuario" />
        <asp:BoundField DataField="Correo" HeaderText="Correo Electrónico" />
        <asp:BoundField DataField="FechaEntrada" HeaderText="Fecha de Entrada" DataFormatString="{0:yyyy-MM-dd}" />
        <asp:BoundField DataField="FechaSalida" HeaderText="Fecha de Salida" DataFormatString="{0:yyyy-MM-dd}" />
        <asp:BoundField DataField="NombreHotel" HeaderText="Nombre del Hotel" />
        <asp:BoundField DataField="NumeroHabitacion" HeaderText="Número de Habitación" />
        <asp:BoundField DataField="EstadoReservacion" HeaderText="Estado de la Reservación" />

       
        <asp:TemplateField HeaderText="Modificar">
            <ItemTemplate>
                <asp:Button ID="btnModificar" runat="server" Text="Modificar" CssClass="btn btn-primary"
                    CommandName="Modificar" CommandArgument='<%# Eval("Id") %>' />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>



</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarReservacion.aspx.cs" Inherits="SistemaReservaciones.Pages.Modificar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
   <h2>Editar Reservación</h2>

<asp:HiddenField ID="hdnReserva" runat="server" />

<asp:Label ID="lblMensaje" runat="server" CssClass="text-danger" />
<div class="form-group">
    <label for="lblNombreCliente">Nombre del Cliente:</label>
    <asp:Label ID="lblNombreCliente" runat="server" CssClass="form-control" />
</div>
<div class="form-group">
    <label for="ddlHotel">Hotel:</label>
    <asp:DropDownList ID="ddlHotel" runat="server" CssClass="form-control" AutoPostBack="true">
        <asp:ListItem Text="Seleccione un hotel" Value="" />
    </asp:DropDownList>
</div>
<div class="form-group">
    <label for="ddlHabitacion">Habitación:</label>
    <asp:DropDownList ID="ddlHabitacion" runat="server" CssClass="form-control" AutoPostBack="true" />
</div>
<div class="form-group">
    <label for="ddlAdultos">Cantidad de Adultos:</label>
    <asp:DropDownList ID="ddlAdultos" runat="server" CssClass="form-control" AutoPostBack="true"/>
</div>
<div class="form-group">
    <label for="ddlNinos">Cantidad de Niños:</label>
    <asp:DropDownList ID="ddlNinos" runat="server" CssClass="form-control" AutoPostBack="true"/>
</div>
<div class="form-group">
    <label for="txtFechaEntrada">Fecha de entrada:</label>
    <asp:TextBox ID="txtFechaEntrada" runat="server" CssClass="form-control" placeholder="dd/MM/yyyy" AutoPostBack="true"></asp:TextBox>
    <ajaxToolkit:CalendarExtender ID="ceFechaEntrada" runat="server" TargetControlID="txtFechaEntrada" Format="dd/MM/yyyy" />
</div>
<div class="form-group">
    <label for="txtFechaSalida">Fecha de salida:</label>
    <asp:TextBox ID="txtFechaSalida" runat="server" CssClass="form-control" placeholder="dd/MM/yyyy" AutoPostBack="true"></asp:TextBox>
    <ajaxToolkit:CalendarExtender ID="ceFechaSalida" runat="server" TargetControlID="txtFechaSalida" Format="dd/MM/yyyy" />
</div>
<div class="form-group">
    <label for="txtTotal">Total de la reserva:</label>
    <asp:TextBox ID="txtTotal" runat="server" CssClass="form-control" ReadOnly="true" />
</div>
<div class="form-group">
    <asp:Button ID="btnguardar" runat="server" Text="Actualizar" CssClass="btn btn-primary" OnClick="btnguardar_Click"/>
    <asp:Button ID="btnEliminar" runat="server" Text="Borrar" CssClass="btn btn-secondary"
    OnClick="btnEliminar_Click" OnClientClick="return confirm('¿Está seguro de que desea cancelar esta reservación?');" />
    <a href="Misreservaciones.aspx" class="btn btn-light">Atrás</a>

</div>

</div>

  

</asp:Content>

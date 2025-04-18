<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConsultarReserva.aspx.cs" Inherits="SistemaReservaciones.Pages.ConsultarReserva" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-group">
        <label for="lblNombreCliente">Nombre del Cliente:</label>
        <asp:Label ID="lblNombreCliente" runat="server" CssClass="form-control" />
    </div>
    <div class="form-group">
        <label for="ddlHotel">Hotel:</label>
        <asp:DropDownList ID="ddlHotel" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlHotel_SelectedIndexChanged">
            <asp:ListItem Text="Seleccione un hotel" Value="" />
        </asp:DropDownList>
    </div>
    <div class="form-group">
        <label for="ddlHabitacion">Habitación:</label>
        <asp:DropDownList ID="ddlHabitacion" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlHabitacion_SelectedIndexChanged" />
    </div>
    <div class="form-group">
        <label for="ddlAdultos">Cantidad de Adultos:</label>
        <asp:DropDownList ID="ddlAdultos" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlCantidad_SelectedIndexChanged" />
    </div>
    <div class="form-group">
        <label for="ddlNinos">Cantidad de Niños:</label>
        <asp:DropDownList ID="ddlNinos" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlCantidad_SelectedIndexChanged" />
    </div>
    <div class="form-group">
        <label for="txtFechaEntrada">Fecha Entrada:</label>
        <asp:TextBox ID="txtFechaEntrada" runat="server" CssClass="form-control" placeholder="dd/MM/yyyy" AutoPostBack="true" OnTextChanged="txtFecha_TextChanged"></asp:TextBox>
        <ajaxToolkit:CalendarExtender ID="ceFechaEntrada" runat="server" TargetControlID="txtFechaEntrada" Format="dd/MM/yyyy" />
        <asp:RequiredFieldValidator ID="rfvFechaEntrada" runat="server" ErrorMessage="Campo Requerido" ControlToValidate="txtFechaEntrada" CssClass="text-danger" Display="Dynamic" />
    </div>
    <div class="form-group">
        <label for="txtFechaSalida">Fecha Salida:</label>
        <asp:TextBox ID="txtFechaSalida" runat="server" CssClass="form-control" placeholder="dd/MM/yyyy" AutoPostBack="true" OnTextChanged="txtFecha_TextChanged"></asp:TextBox>
        <ajaxToolkit:CalendarExtender ID="ceFechaSalida" runat="server" TargetControlID="txtFechaSalida" Format="dd/MM/yyyy" />
        <asp:RequiredFieldValidator ID="rfvFechaSalida" runat="server" ErrorMessage="Campo Requerido" ControlToValidate="txtFechaSalida" CssClass="text-danger" Display="Dynamic" />
        <asp:CompareValidator ID="cvFechas" runat="server" ControlToCompare="txtFechaEntrada" ControlToValidate="txtFechaSalida" Operator="GreaterThan" Type="Date" ErrorMessage="La fecha de salida debe ser mayor a la fecha de entrada." CssClass="text-danger" Display="Dynamic" />
    </div>
    <div class="form-group">
        <label for="txtDiasReserva">Días de la reserva:</label>
        <asp:TextBox ID="txtDiasReserva" runat="server" CssClass="form-control" />
    </div>
    <div class="form-group">
        <label for="txtCostoTotal">Costo Total:</label>
        <asp:TextBox ID="txtCostoTotal" runat="server" CssClass="form-control" ReadOnly="true" />
    </div>
    <div class="form-group">
        <asp:Button ID="btnActualizarReservacion" runat="server" Text="Actualizar Reservación" CssClass="btn btn-primary" OnClick="btnActualizarReservacion_Click" />
        <asp:Button ID="btnCancelarReservacion" runat="server" Text="Cancelar Reservación" CssClass="btn btn-danger" OnClick="btnCancelarReservacion_Click" />
        <asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="btn btn-secondary" PostBackUrl="~/Pages/GestionarReservaciones.aspx" />
    </div>
</asp:Content>

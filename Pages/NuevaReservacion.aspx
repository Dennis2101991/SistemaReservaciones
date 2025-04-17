<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NuevaReservacion.aspx.cs" Inherits="SistemaReservaciones.Pages.NuevaReservacion" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2>Nueva Reservación</h2>
        <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger" />
        <div class="form-group">
            <label for="ddlHotel">Hotel:</label>
            <asp:DropDownList ID="ddlHotel" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlHotel_SelectedIndexChanged">
                <asp:ListItem Text="Seleccione un hotel" Value="" />
            </asp:DropDownList>
        </div>
        <div class="form-group">
            <label for="ddlHabitacion">Habitación:</label>
            <asp:DropDownList ID="ddlHabitacion" runat="server" CssClass="form-control" />
        </div>
        <div class="form-group">
            <label for="txtFechaEntrada">Fecha de entrada:</label>
            <asp:TextBox ID="txtFechaEntrada" runat="server" CssClass="form-control" placeholder="dd/MM/yyyy"></asp:TextBox>
            <ajaxToolkit:CalendarExtender ID="ceFechaEntrada" runat="server" TargetControlID="txtFechaEntrada" Format="dd/MM/yyyy" />
            <asp:RequiredFieldValidator ID="rfvFechaEntrada" runat="server" ErrorMessage="Campo Requerido" ControlToValidate="txtFechaEntrada" CssClass="text-danger" Display="Dynamic" />
            <asp:RangeValidator ID="rvFechaEntrada" runat="server" ControlToValidate="txtFechaEntrada" ErrorMessage="Ingrese una fecha válida desde hoy en adelante." ForeColor="Red" MinimumValue='<%# DateTime.Now.ToString("yyyy-MM-dd") %>' MaximumValue="9999-12-31" Type="Date" Display="Dynamic" />
        </div>
        <div class="form-group">
            <label for="txtFechaSalida">Fecha de salida:</label>
            <asp:TextBox ID="txtFechaSalida" runat="server" CssClass="form-control" placeholder="dd/MM/yyyy"></asp:TextBox>
            <ajaxToolkit:CalendarExtender ID="ceFechaSalida" runat="server" TargetControlID="txtFechaSalida" Format="dd/MM/yyyy" />
            <asp:RequiredFieldValidator ID="rfvFechaSalida" runat="server" ErrorMessage="Campo Requerido" ControlToValidate="txtFechaSalida" CssClass="text-danger" Display="Dynamic" />
            <asp:CompareValidator ID="cvFechas" runat="server" ControlToCompare="txtFechaEntrada" ControlToValidate="txtFechaSalida" Operator="GreaterThanEqual" Type="Date" ErrorMessage="La fecha de salida debe ser mayor o igual a la fecha de entrada." CssClass="text-danger" Display="Dynamic" />
        </div>
        <div class="form-group">
            <asp:Button ID="btnReservar" runat="server" Text="Reservar" CssClass="btn btn-primary" OnClick="btnReservar_Click" />
        </div>
    </div>
</asp:Content>

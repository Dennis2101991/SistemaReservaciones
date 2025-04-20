<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CrearReservacion.aspx.cs" Inherits="SistemaReservaciones.Pages.NuevaReservacion" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        function calcularTotal() {
            __doPostBack('CalcularTotal', '');
        }
    </script>

    <div class="container py-5">
        <div class="card shadow">
            <div class="card-header bg-primary text-white text-center">
                <h3 class="mb-0">Nueva Reservación</h3>
            </div>
            <div class="card-body">
                <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger mb-3 d-block" />

                <div class="mb-3">
                    <label for="lblNombreCliente" class="form-label">Nombre del Cliente:</label>
                    <asp:Label ID="lblNombreCliente" runat="server" CssClass="form-control fw-bold" />
                </div>

                <div class="mb-3">
                    <label for="ddlHotel" class="form-label">Hotel:</label>
                    <asp:DropDownList ID="ddlHotel" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlHotel_SelectedIndexChanged">
                        <asp:ListItem Text="Seleccione un hotel" Value="" />
                    </asp:DropDownList>
                </div>

                <div class="mb-3">
                    <label for="ddlHabitacion" class="form-label">Habitación:</label>
                    <asp:DropDownList ID="ddlHabitacion" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlHabitacion_SelectedIndexChanged" />
                </div>

                <div class="mb-3">
                    <label for="ddlAdultos" class="form-label">Cantidad de Adultos:</label>
                    <asp:DropDownList ID="ddlAdultos" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlCantidad_SelectedIndexChanged" />
                </div>

                <div class="mb-3">
                    <label for="ddlNinos" class="form-label">Cantidad de Niños:</label>
                    <asp:DropDownList ID="ddlNinos" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlCantidad_SelectedIndexChanged" />
                </div>

                <div class="mb-3">
                    <label for="txtFechaEntrada" class="form-label">Fecha de entrada:</label>
                    <asp:TextBox ID="txtFechaEntrada" runat="server" CssClass="form-control" placeholder="dd/MM/yyyy" AutoPostBack="true" OnTextChanged="txtFecha_TextChanged" />
                    <ajaxToolkit:CalendarExtender ID="ceFechaEntrada" runat="server" TargetControlID="txtFechaEntrada" Format="dd/MM/yyyy" />
                    <asp:RequiredFieldValidator ID="rfvFechaEntrada" runat="server" ErrorMessage="Campo Requerido" ControlToValidate="txtFechaEntrada" CssClass="text-danger" Display="Dynamic" />
                </div>

                <div class="mb-3">
                    <label for="txtFechaSalida" class="form-label">Fecha de salida:</label>
                    <asp:TextBox ID="txtFechaSalida" runat="server" CssClass="form-control" placeholder="dd/MM/yyyy" AutoPostBack="true" OnTextChanged="txtFecha_TextChanged" />
                    <ajaxToolkit:CalendarExtender ID="ceFechaSalida" runat="server" TargetControlID="txtFechaSalida" Format="dd/MM/yyyy" />
                    <asp:RequiredFieldValidator ID="rfvFechaSalida" runat="server" ErrorMessage="Campo Requerido" ControlToValidate="txtFechaSalida" CssClass="text-danger" Display="Dynamic" />
                    <asp:CompareValidator ID="cvFechas" runat="server" ControlToCompare="txtFechaEntrada" ControlToValidate="txtFechaSalida" Operator="GreaterThan" Type="Date" ErrorMessage="La fecha de salida debe ser mayor a la fecha de entrada." CssClass="text-danger" Display="Dynamic" />
                </div>

                <div class="mb-3">
                    <label for="txtTotal" class="form-label">Total de la reserva:</label>
                    <asp:TextBox ID="txtTotal" runat="server" CssClass="form-control" ReadOnly="true" />
                </div>

                <div class="text-end">
                    <asp:Button ID="btnReservar" runat="server" Text="Reservar" CssClass="btn btn-success me-2" OnClick="btnReservar_Click" />
                    <asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="btn btn-secondary" OnClick="btnRegresar_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>



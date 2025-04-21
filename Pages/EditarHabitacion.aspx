<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarHabitacion.aspx.cs" Inherits="SistemaReservaciones.Pages.EditarHabitacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Editar habitación</h2>

    <asp:ValidationSummary ID="vsErrores" runat="server" CssClass="alert alert-danger" HeaderText="Corrige los siguientes errores:" />

    <!-- HOTEL (solo lectura) -->
    <div class="form-group">
        <label for="lblHotel">Hotel:</label>
        <asp:TextBox ID="lblHotel" runat="server" CssClass="form-control" ReadOnly="true" />
    </div>

    <!-- NÚMERO DE HABITACIÓN -->
    <div class="form-group">
        <label for="txtNumero">Número de habitación:</label>
        <asp:TextBox ID="txtNumero" runat="server" CssClass="form-control" MaxLength="10" ToolTip="Ej. T102" />
        <asp:RequiredFieldValidator ID="rfvNumero" runat="server" ControlToValidate="txtNumero" 
            ErrorMessage="⚠️ El número de habitación es obligatorio." Display="Dynamic" CssClass="text-danger" />
    </div>

    <!-- CAPACIDAD MÁXIMA -->
    <div class="form-group">
        <label for="txtCapacidad">Capacidad máxima:</label>
        <asp:TextBox ID="txtCapacidad" runat="server" CssClass="form-control" TextMode="Number" />
        <asp:RequiredFieldValidator ID="rfvCapacidad" runat="server" ControlToValidate="txtCapacidad" 
            ErrorMessage="⚠️ La capacidad es obligatoria." Display="Dynamic" CssClass="text-danger" />
        <asp:RangeValidator ID="rvCapacidad" runat="server" ControlToValidate="txtCapacidad" MinimumValue="1" MaximumValue="8" Type="Integer"
            ErrorMessage="⚠️ La capacidad debe estar entre 1 y 8." Display="Dynamic" CssClass="text-danger" />
    </div>

    <!-- DESCRIPCIÓN -->
    <div class="form-group">
        <label for="txtDescripcion">Descripción:</label>
        <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" MaxLength="500" />
        <asp:RequiredFieldValidator ID="rfvDescripcion" runat="server" ControlToValidate="txtDescripcion" 
            ErrorMessage="⚠️ La descripción es obligatoria." Display="Dynamic" CssClass="text-danger" />
    </div>

    <!-- BOTONES -->
    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-success" OnClick="btnGuardar_Click" />
    <asp:Button ID="btnInactivar" runat="server" Text="Inactivar" CssClass="btn btn-warning ml-2" OnClick="btnInactivar_Click" />
    <a href="GestionarHabitaciones.aspx" class="btn btn-secondary ml-2">Regresar</a>


</asp:Content>

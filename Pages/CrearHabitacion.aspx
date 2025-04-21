<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CrearHabitacion.aspx.cs" Inherits="SistemaReservaciones.Pages.CrearHabitacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <h2>Crear habitación</h2>

    <asp:ValidationSummary ID="vsErrores" runat="server" CssClass="alert alert-danger" HeaderText="Corrige los siguientes errores:" />

    <!-- HOTEL -->
    <div class="form-group">
        <label for="ddlHotel">Hotel:</label>
        <asp:DropDownList ID="ddlHotel" runat="server" CssClass="form-control">
            <asp:ListItem Text="-- Seleccione un hotel --" Value="" />
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="rfvHotel" runat="server" ControlToValidate="ddlHotel" InitialValue=""
            ErrorMessage="⚠️ Debe seleccionar un hotel." CssClass="text-danger" Display="Dynamic" />
    </div>
    <!-- Número de habitación -->
<asp:Label ID="lblNumero" runat="server" Text="Número de habitación:"></asp:Label><br />
<asp:TextBox ID="txtNumero" runat="server" MaxLength="10" CssClass="form-control" ToolTip="Ej. T102"></asp:TextBox>
<asp:RequiredFieldValidator 
    ID="rfvNumero" 
    runat="server" 
    ControlToValidate="txtNumero"
    ErrorMessage="⚠ Debe ingresar un número de habitación."
    Display="Dynamic"
    CssClass="text-danger">
</asp:RequiredFieldValidator>
<br />

   <!-- Capacidad máxima -->
<asp:Label ID="lblCapacidad" runat="server" Text="Capacidad máxima:" />
<br />
<asp:TextBox ID="txtCapacidad" runat="server" TextMode="Number" CssClass="form-control" />
<br />

<!-- VALIDADOR: requerido -->
<asp:RequiredFieldValidator 
    ID="rfvCapacidad" 
    runat="server" 
    ControlToValidate="txtCapacidad"
    ErrorMessage="⚠️ Este campo es obligatorio."
    CssClass="text-danger"
    Display="Dynamic" />

<!-- VALIDADOR: rango entre 1 y 8 -->
<asp:RangeValidator 
    ID="rvCapacidad" 
    runat="server"
    ControlToValidate="txtCapacidad"
    MinimumValue="1"
    MaximumValue="8"
    Type="Integer"
    ErrorMessage="⚠️ Solo se permiten números entre 1 y 8."
    CssClass="text-danger"
    Display="Dynamic" />

    <!-- DESCRIPCIÓN -->
    <div class="form-group">
        <label for="txtDescripcion">Descripción:</label>
        <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" TextMode="MultiLine" MaxLength="500" Rows="4" />
        <asp:RequiredFieldValidator ID="rfvDescripcion" runat="server" ControlToValidate="txtDescripcion"
            ErrorMessage="⚠️ La descripción es obligatoria." CssClass="text-danger" Display="Dynamic" />
    </div>

    <!-- BOTONES -->
    <div class="form-group mt-3">
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click"/>
        <a href="GestionarHabitaciones.aspx" class="btn btn-secondary">Regresar</a>
    </div>
    <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
</asp:Content>

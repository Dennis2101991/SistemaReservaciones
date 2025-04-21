<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetalleReservacion.aspx.cs" Inherits="SistemaReservaciones.Pages.DetalleReservacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">
        <h2>Detalle de reservación</h2>

        <table class="table table-bordered w-50">
            <tr>
                <th># reservación</th>
                <td><asp:Label ID="lblId" runat="server" /></td>
            </tr>
            <tr>
                <th>Hotel</th>
                <td><asp:Label ID="lblHotel" runat="server" /></td>
            </tr>
            <tr>
                <th>Habitación</th>
                <td><asp:Label ID="lblHabitacion" runat="server" /></td>
            </tr>
            <tr>
                <th>Cliente</th>
                <td><asp:Label ID="lblCliente" runat="server" /></td>
            </tr>
            <tr>
                <th>Fecha de entrada</th>
                <td><asp:Label ID="lblFechaEntrada" runat="server" /></td>
            </tr>
            <tr>
                <th>Fecha de salida</th>
                <td><asp:Label ID="lblFechaSalida" runat="server" /></td>
            </tr>
            <tr>
                <th>Días de la reserva</th>
                <td><asp:Label ID="lblDias" runat="server" /></td>
            </tr>
            <tr>
                <th>Número de niños</th>
                <td><asp:Label ID="lblNinos" runat="server" /></td>
            </tr>
            <tr>
                <th>Número de adultos</th>
                <td><asp:Label ID="lblAdultos" runat="server" /></td>
            </tr>
            <tr>
    <th>Costo total</th>
    <td><asp:Label ID="lblCosto" runat="server" /></td>
</tr>

        </table>

        <div class="mt-3">
            <asp:Button ID="btnEditar" runat="server" Text="Editar reservación" CssClass="btn btn-primary" OnClick="btnEditar_Click" />
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar reservación" CssClass="btn btn-danger" OnClick="btnCancelar_Click" />
            <asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="btn btn-secondary" OnClick="btnRegresar_Click" />
        </div>

        <hr />
        <h4>Lista de acciones realizadas</h4>

        <asp:GridView ID="gvBitacora" runat="server" CssClass="table table-striped table-bordered" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                <asp:BoundField DataField="Accion" HeaderText="Acción" />
                <asp:BoundField DataField="NombreUsuario" HeaderText="Realizado por" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GestionarHabitaciones.aspx.cs" Inherits="SistemaReservaciones.Pages.GestionarHabitaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container mt-5">
        <h2 class="text-center text-primary mb-4">Gestión de Habitaciones</h2>

        <asp:Label ID="lblMensaje" runat="server" CssClass="alert alert-danger d-none" />

        <!-- Dropdown de hoteles -->
        <div class="form-group">
            <label for="ddlHotel">Seleccione un hotel:</label>
            <asp:DropDownList ID="ddlHotel" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlHotel_SelectedIndexChanged">
                <asp:ListItem Text="-- Seleccione --" Value="" />
            </asp:DropDownList>
        </div>
        <!-- Formulario de habitación -->
<div class="card my-4 shadow-sm">
    <div class="card-header bg-info text-white">
        <strong>Formulario de Habitación</strong>
    </div>
    <div class="card-body">
        <asp:HiddenField ID="hdnIdHabitacion" runat="server" />
        <div class="form-row">
            <div class="form-group col-md-6">
                <label for="txtNumeroHabitacion">Número de Habitación:</label>
                <asp:TextBox ID="txtNumeroHabitacion" runat="server" CssClass="form-control" />
            </div>
            <div class="form-group col-md-6">
                <label for="ddlEstado">Estado:</label>
                <asp:DropDownList ID="ddlEstado" runat="server" CssClass="form-control">
                    <asp:ListItem Text="Activo" Value="A" />
                    <asp:ListItem Text="Inactivo" Value="I" />
                </asp:DropDownList>
            </div>
            <div class="form-group col-md-6">
    <label for="txtCapacidad">Capacidad Máxima:</label>
    <asp:TextBox ID="txtCapacidad" runat="server" CssClass="form-control" TextMode="Number" />
<div class="form-group col-md-6">
    <label for="txtDescripcion">Descripción:</label>
    <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" />
</div>

</div>
     </div>
</div>        
        </div>

        <!-- Botones -->
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-success" OnClick="btnGuardar_Click" />
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-secondary ml-2" OnClick="btnCancelar_Click" />
        
    </div>
</div>

        <!-- Tabla de habitaciones -->
<h4>Habitaciones del hotel seleccionado:</h4>
<asp:GridView ID="gvHabitaciones" runat="server" CssClass="table table-bordered table-hover" 
    AutoGenerateColumns="False" OnRowCommand="gvHabitaciones_RowCommand">
    <Columns>
        <asp:BoundField DataField="idHabitacion" HeaderText="ID" />
        <asp:BoundField DataField="numeroHabitacion" HeaderText="Número" />
        <asp:BoundField DataField="estado" HeaderText="Estado" />

        
        <asp:TemplateField HeaderText="Acciones">
            <ItemTemplate>
                <asp:Button ID="btnEditar" runat="server" Text="Editar" CommandName="Editar"
                    CommandArgument='<%# Eval("idHabitacion") %>' CssClass="btn btn-warning btn-sm mr-1" />

                <asp:Button ID="btnDesactivar" runat="server" Text="Desactivar" CommandName="Desactivar"
                    CommandArgument='<%# Eval("idHabitacion") %>' CssClass="btn btn-danger btn-sm"
                    Visible='<%# Eval("estado").ToString() == "A" %>' />

                <asp:Button ID="btnActivar" runat="server" Text="Activar" CommandName="Activar"
                    CommandArgument='<%# Eval("idHabitacion") %>' CssClass="btn btn-success btn-sm"
                    Visible='<%# Eval("estado").ToString() == "I" %>' />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>

    </div>
    <script type="text/javascript">
    setTimeout(function () {
        var alerta = document.getElementById('<%= lblMensaje.ClientID %>');
        if (alerta) {
            alerta.style.display = 'none';
        }
    }, 5000); // Se oculta después de 5 segundos
    </script>

</asp:Content>



<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CrearReservacion.aspx.cs" Inherits="SistemaReservaciones.Pages.NuevaReservacion" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        function calcularTotal() {
            __doPostBack('CalcularTotal', '');
        }
    </script>

    <div class="container">
     <div class="container-fluid p-0" style="background-image: url('https://example.com/tu-imagen-de-hotel.jpg'); background-size: cover; background-position: center; height: 100vh;">
       <div class="overlay d-flex flex-column align-items-center justify-content-start" style="background: rgba(0, 0, 0, 0.5); min-height: 100vh; padding-top: 40px;">
       
           
        <div class="text-white text-center mb-4">
                <h1 class="display-4">Nueva Reservación</h1>
        </div>

         <div class="container text-white">
           <div class="row justify-content-start">
            <div class="col-md-6">
            <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger" />

             <div class="form-group">
                <label for="ddlHotel" >Hotel:</label>
                <asp:DropDownList ID="ddlHotel" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlHotel_SelectedIndexChanged">
                    <asp:ListItem Text="Seleccione un hotel" Value="" />
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvHotel" runat="server" ControlToValidate="ddlHotel" InitialValue="" ErrorMessage="Seleccione un hotel" 
                            CssClass="text-danger" Display="Dynamic" />
            </div>
            
            <div class="form-group" style="max-width: 280px;">
                <label for="lblNombreCliente">Cliente:</label>
                <asp:Label ID="lblNombreCliente" runat="server" CssClass="form-control" />
            </div>  

           
            <div class="form-group">
                <label for="txtFechaEntrada">Fecha de entrada:</label>
                <asp:TextBox ID="txtFechaEntrada" runat="server" CssClass="form-control" placeholder="dd/MM/yyyy" AutoPostBack="true" OnTextChanged="txtFecha_TextChanged"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="ceFechaEntrada" runat="server" TargetControlID="txtFechaEntrada" Format="dd/MM/yyyy" />
                <asp:RequiredFieldValidator ID="rfvFechaEntrada" runat="server" ErrorMessage="Campo Requerido" ControlToValidate="txtFechaEntrada" CssClass="text-danger" Display="Dynamic" />
            </div>

            <div class="form-group">
                <label for="txtFechaSalida">Fecha de salida:</label>
                <asp:TextBox ID="txtFechaSalida" runat="server" CssClass="form-control" placeholder="dd/MM/yyyy" AutoPostBack="true" OnTextChanged="txtFecha_TextChanged"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="ceFechaSalida" runat="server" TargetControlID="txtFechaSalida" Format="dd/MM/yyyy" />
                <asp:RequiredFieldValidator ID="rfvFechaSalida" runat="server" ErrorMessage="Campo Requerido" ControlToValidate="txtFechaSalida" CssClass="text-danger" Display="Dynamic" />
                <asp:CompareValidator ID="cvFechas" runat="server" ControlToCompare="txtFechaEntrada" ControlToValidate="txtFechaSalida" Operator="GreaterThan" Type="Date" ErrorMessage="La fecha de salida debe ser mayor a la fecha de entrada." CssClass="text-danger" Display="Dynamic" />
            </div>

              <div class="form-group">
                 <label for="ddlHabitacion" >Habitación:</label>
                 <asp:DropDownList ID="ddlHabitacion" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlHabitacion_SelectedIndexChanged" />

             </div>

             <div class="form-group">
                 <label for="ddlAdultos">Número de adultos:</label>
                 <asp:DropDownList ID="ddlAdultos" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlCantidad_SelectedIndexChanged" />
                     <asp:RangeValidator ID="rvAdultos" runat="server" ControlToValidate="ddlAdultos" MinimumValue="1" MaximumValue="999" Type="Integer" 
                                         ForeColor="Red" ErrorMessage="El número de adultos debe ser mayor a cero." Display="Dynamic" />
             </div>

             <div class="form-group">
                 <label for="ddlNinos">Número de niños:</label>
                 <asp:DropDownList ID="ddlNinos" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlCantidad_SelectedIndexChanged" />
                     <asp:RangeValidator ID="rvNinos" runat="server" ControlToValidate="ddlNinos" MinimumValue="0" MaximumValue="999" Type="Integer" 
                                         ForeColor="Red" ErrorMessage="El número de niños debe ser mayor o igual a cero." Display="Dynamic" />
             </div>
            <div class="form-group">
                <label for="txtTotal">Total de la reserva:</label>
                <asp:TextBox ID="txtTotal" runat="server" CssClass="form-control" ReadOnly="true" />
            </div>
            

            <div class="form-group mt-4 text-center">
                <asp:Button ID="btnReservar" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnReservar_Click" />
                <asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="btn btn-secondary" OnClick="btnRegresar_Click" />
            </div>
                    </div>
                </div>
            </div>
         </div>
        </div>
    </div>

 
</asp:Content>



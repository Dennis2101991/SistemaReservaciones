<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GestionarReservaciones.aspx.cs" Inherits="SistemaReservaciones.Pages.GestionarReservaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


  <div class="container-fluid p-0" style="background-image: url('https://example.com/tu-imagen-de-hotel.jpg'); background-size: cover; background-position: center; height: 100vh;">
      <div class="overlay d-flex justify-content-center align-items-center" style="background: rgba(0, 0, 0, 0.5); min-height: 100vh;">
          <div class="container py-5 text-center" style="z-index: 10;">


    <h1 class="display-4 text-white text-center mb-4">Gestionar Reservaciones</h1>

    <!-- Filtro de búsqueda -->
            <div class="mb-4">
              <div class="row">
                <div class="col-md-3">
                  <div class="form-group">
                    <label for="ddlCliente" class="text-white">Cliente:</label>
                    <asp:DropDownList ID="ddlCliente" runat="server" CssClass="form-control" AutoPostBack="true">
                      <asp:ListItem Text="Seleccione un cliente" Value="" />
                    </asp:DropDownList>
                  </div>
                </div>
                <div class="col-md-3">
                  <div class="form-group">
                    <label for="txtFechaEntrada" class="text-white">Fecha de entrada:</label>
                    <asp:TextBox ID="txtFechaEntrada" runat="server" CssClass="form-control" placeholder="dd/MM/yyyy"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvFechaEntrada" runat="server" ErrorMessage="Campo Requerido" ControlToValidate="txtFechaEntrada" CssClass="text-danger" ></asp:RequiredFieldValidator>
                  </div>
                </div>
                <div class="col-md-3">
                  <div class="form-group">
                    <label for="txtFechaSalida" class="text-white">Fecha de salida:</label>
                    <asp:TextBox ID="txtFechaSalida" runat="server" CssClass="form-control" placeholder="dd/MM/yyyy"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="rfvFechaSalida" runat="server" ErrorMessage="Campo Requerido" ControlToValidate="txtFechaSalida" CssClass="text-danger" ></asp:RequiredFieldValidator>
                      <asp:CompareValidator 
                            ID="cvFechas" runat="server" ControlToCompare="txtFechaEntrada" ControlToValidate="txtFechaSalida" Operator="GreaterThanEqual" Type="Date" 
                            ErrorMessage="La fecha de salida debe ser mayor o igual a la fecha de entrada." CssClass="text-danger" Display="Dynamic" />
                  </div>
                </div>
                <div class="col-md-3">
                  <div class="form-group">
                    <label class="text-white d-block" style="visibility:hidden">Filtro</label>
                    <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" CssClass="btn btn-primary btn-block" OnClick="btnFiltrar_Click" CausesValidation="true"/>
                  </div>
                </div>
              </div>
            </div>

              <div class="mb-4 text-start">
                <a href="NuevaReservacion.aspx" class="btn btn-primary btn-lg">Nueva Reservación</a>
            </div>
      
      <!-- GridView que muestra todas las reservaciones -->
            <asp:GridView ID="gvReservaciones" runat="server" AutoGenerateColumns="false" CssClass="table table-striped" OnRowCommand="gvReservaciones_RowCommand">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="# reservacion" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="NombreUsuario" HeaderText="Cliente" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                    <asp:BoundField DataField="NombreHotel" HeaderText="Hotel" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                    <asp:BoundField DataField="FechaEntrada" HeaderText="Fecha entrada" DataFormatString="{0:dd/MM/yyyy}" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="FechaSalida" HeaderText="Fecha salida" DataFormatString="{0:dd/MM/yyyy}" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="CostoTotal" HeaderText="Costo" DataFormatString="{0:$#,0.00}" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" />
                    <asp:BoundField DataField="EstadoReservacion" HeaderText="Estado" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />

                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:Button ID="btnConsultar" runat="server" Text="Consultar" CssClass="btn btn-primary"
                                CommandName="Consultar" CommandArgument='<%# Eval("Id") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
          </div>
      </div>
  </div>


</asp:Content>

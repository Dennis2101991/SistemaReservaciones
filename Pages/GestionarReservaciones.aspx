<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GestionarReservaciones.aspx.cs" Inherits="SistemaReservaciones.Pages.GestionarReservaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


  <div class="container-fluid p-0" style="background-image: url('https://example.com/tu-imagen-de-hotel.jpg'); background-size: cover; background-position: center; height: 100vh;">
      <div class="overlay d-flex justify-content-center align-items-center" style="background: rgba(0, 0, 0, 0.5); height:100%;">
          <div class="container py-5">

        <h1 class="display-4 text-white text-center mb-4">Gestión de Reservaciones - Empleados</h1>
              <div class="text-left mb-4">
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

<%@ Page Title="Mis Reservaciones" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Misreservaciones.aspx.cs" Inherits="SistemaReservaciones.Pages.Misreservaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    

  <div class="container-fluid p-0" style="background-image: url('https://example.com/tu-imagen-de-hotel.jpg'); background-size: cover; background-position: center; height: 100vh;">
      <div class="overlay d-flex justify-content-center align-items-center" style="background: rgba(0, 0, 0, 0.5); height:100%;">
          <div class="container py-5">

              <h1 class="display-4 text-white text-center mb-4">Mis Reservaciones</h1>
              <div class="text-left mb-4">
                  <a href="NuevaReservacion.aspx" class="btn btn-primary btn-lg">Nueva Reservación</a>
              </div>
              <!-- GridView que muestra las reservaciones del usuario -->
              <div class="card p-4 bg-light">
                  <asp:GridView ID="gvMisReservaciones" runat="server" AutoGenerateColumns="false" CssClass="table table-striped">
                      <Columns>

                          <asp:BoundField DataField="idReservacion" HeaderText="# reservacion" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                          <asp:BoundField DataField="NombreHotel" HeaderText="Hotel" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                          <asp:BoundField DataField="fechaEntrada" HeaderText="Fecha entrada" DataFormatString="{0:dd/MM/yyyy}" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                          <asp:BoundField DataField="fechaSalida" HeaderText="Fecha salida" DataFormatString="{0:dd/MM/yyyy}" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                          <asp:BoundField DataField="costoTotal" HeaderText="Costo" DataFormatString="{0:$#,0.00}" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" />
                          <asp:BoundField DataField="EstadoVisual" HeaderText="Estado" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />

                          <asp:TemplateField HeaderText="">
                              <ItemTemplate>
                                  <asp:HyperLink ID="hlConsultar" runat="server" Text="Consultar" 
                                      NavigateUrl='<%# "ConsultarReserva.aspx?id=" + Eval("idReservacion") %>' />
                              </ItemTemplate>
                          </asp:TemplateField>

                      </Columns>
                  </asp:GridView>
              </div>
          </div>
      </div>
  </div>


</asp:Content>



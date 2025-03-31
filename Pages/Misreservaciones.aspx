<%@ Page Title="Mis Reservaciones" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Misreservaciones.aspx.cs" Inherits="SistemaReservaciones.Pages.Misreservaciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Contenedor principal con imagen de fondo -->
    <div class="container-fluid p-0" style="background-image: url('https://example.com/tu-imagen-de-hotel.jpg'); background-size: cover; background-position: center; height: 100vh;">
        <div class="overlay d-flex justify-content-center align-items-center" style="background: rgba(0, 0, 0, 0.5); height: 100%;">
            
            
            <div class="container py-5">
                <h1 class="display-4 text-white text-center mb-4">Mis Reservaciones</h1>

                <!-- Enlace para nueva reservación, estilizado con Bootstrap -->
                <div class="text-center mb-4">
                    <a href="NuevaReservacion.aspx" class="btn btn-primary btn-lg">Nueva Reservación</a>
                </div>

                
                <div class="card p-4 bg-light">
                    <h3 class="card-title mb-4">Detalles de la Reservación</h3>
                    
                    <div class="row">
                       
                        <div class="col-md-6 mb-3">
                            <label for="txtHotel" class="form-label">Hotel</label>
                            <asp:TextBox ID="txtHotel" runat="server" CssClass="form-control" placeholder="Ingrese el nombre del hotel"></asp:TextBox>
                        </div>

                        
                        <div class="col-md-6 mb-3">
                            <label for="txtFechaEntrada" class="form-label">Fecha de Entrada</label>
                            <asp:TextBox ID="txtFechaEntrada" runat="server" CssClass="form-control" placeholder="dd/mm/yyyy"></asp:TextBox>
                        </div>
                    </div>

                    <div class="row">
                        
                        <div class="col-md-6 mb-3">
                            <label for="txtFechaSalida" class="form-label">Fecha de Salida</label>
                            <asp:TextBox ID="txtFechaSalida" runat="server" CssClass="form-control" placeholder="dd/mm/yyyy"></asp:TextBox>
                        </div>

                        
                        <div class="col-md-6 mb-3">
                            <label for="txtCosto" class="form-label">Costo</label>
                            <asp:TextBox ID="txtCosto" runat="server" CssClass="form-control" placeholder="Monto de la reservación"></asp:TextBox>
                        </div>
                    </div>

                    <div class="row">
                       
                        <div class="col-md-6 mb-3">
                            <label for="txtEstado" class="form-label">Estado</label>
                            <asp:TextBox ID="txtEstado" runat="server" CssClass="form-control" placeholder="Estado de la reservación"></asp:TextBox>
                        </div>
                    </div>

                   
                    <asp:HiddenField ID="hdnidReservacion" runat="server" /> 
                </div>
            </div>
        </div>
    </div>

</asp:Content>



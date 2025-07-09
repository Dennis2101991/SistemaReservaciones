<%@ Page Title="Hotel Paradise" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Principal.aspx.cs" Inherits="SistemaReservaciones.Pages.Principal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

  
    <div class="container-fluid p-0">
        <div class="hero-section" style="background-image: url('https://example.com/tu-imagen-de-hotel.jpg'); height: 100vh; background-size: cover; background-position: center;"> <!-- aca le ingresamos la imagen por medio de un link directo de internet  -->
            <div class="overlay text-center d-flex justify-content-center align-items-center" style="background: rgba(0, 0, 0, 0.5); height: 100%; color: white;">
                <div class="hero-content">
                    <h1 class="display-3">Bienvenido a Hotel Paradise</h1>
                    <p class="lead">Tu experiencia de descanso y lujo</p>
                    <a href="Login.aspx" class="btn btn-warning btn-lg">Reserva Ahora</a> <!-- en este link vamos a redirecionar hacia la pagina de reservaciones  -->
                </div>
            </div>
        </div>
    </div>

   
    <div class="container py-5" id="reservar">
        <h2 class="text-center mb-4">Reserva tu habitación</h2>
        <p class="text-center lead">Elige entre nuestras cómodas habitaciones y disfruta de un servicio excepcional. ¡Haz tu reserva ahora!</p>
        <div class="d-flex justify-content-center">
            <button class="btn btn-warning btn-lg">Ver Habitaciones</button>
        </div>
    </div>

    <!-- Pie de pagina  -->

    <!-- Pie de pagina  -->
    <footer class="text-center py-4">
        <p>&copy; 2025 Hotel Paradise. Todos los derechos reservados.</p>
    </footer>

</asp:Content>


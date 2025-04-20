<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ComprobanteReservacion.aspx.cs" Inherits="SistemaReservaciones.Pages.ComprobanteReservacion" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Comprobante de Reservación</title>
  
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body class="bg-light">
    <form id="form1" runat="server">
        <div class="container mt-5">
            <div class="card shadow-lg">
                <div class="card-header bg-primary text-white text-center">
                    <h3 class="mb-0">Comprobante de Reservación</h3>
                </div>
                <div class="card-body">
                    <div class="mb-3">
                        <strong>Hotel:</strong>
                        <asp:Label ID="lblHotel" runat="server" CssClass="ms-2" />
                    </div>
                    <div class="mb-3">
                        <strong>Cliente:</strong>
                        <asp:Label ID="lblCliente" runat="server" CssClass="ms-2" />
                    </div>
                    <div class="mb-3">
                        <strong>Fecha Entrada:</strong>
                        <asp:Label ID="lblFechaEntrada" runat="server" CssClass="ms-2" />
                    </div>
                    <div class="mb-3">
                        <strong>Fecha Salida:</strong>
                        <asp:Label ID="lblFechaSalida" runat="server" CssClass="ms-2" />
                    </div>
                    <div class="mb-3">
                        <strong>Habitación:</strong>
                        <asp:Label ID="lblHabitacion" runat="server" CssClass="ms-2" />
                    </div>
                    <div class="mb-3">
                        <strong>Costo Total:</strong>
                        <asp:Label ID="lblTotal" runat="server" CssClass="ms-2" />
                    </div>

                    <div class="d-flex justify-content-between mt-4">
                        <asp:Button ID="btnImprimir" runat="server" Text="Imprimir" CssClass="btn btn-success" OnClientClick="window.print();return false;" />
                        <a href="MisReservaciones.aspx" class="btn btn-outline-primary">Volver a mis reservaciones</a>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>


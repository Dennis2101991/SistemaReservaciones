<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Bitacora.aspx.cs" Inherits="SistemaReservaciones.Pages.Bitacora" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registro de Bitácora</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-5">
            <h2 class="text-center mb-4">Registro de Bitácora</h2>
            <asp:GridView ID="gvBitacora" runat="server" CssClass="table table-striped"
                AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="idBitacora" HeaderText="ID Bitácora" />
                    <asp:BoundField DataField="idReservacion" HeaderText="ID Reservación" />
                    <asp:BoundField DataField="idPersona" HeaderText="ID Persona" />
                    <asp:BoundField DataField="accionRealizada" HeaderText="Acción" />
                    <asp:BoundField DataField="fechaDeLaAccion" HeaderText="Fecha de la Acción" DataFormatString="{0:dd/MM/yyyy HH:mm:ss}" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>

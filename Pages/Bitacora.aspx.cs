﻿using System;
using System.Linq;
using DataModels;


namespace SistemaReservaciones.Pages
{
    public partial class Bitacora : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["idPersona"] == null)
                {
                    Response.Redirect("Login.aspx");
                    return;
                }

            }
            CargarBitacora();
        }


        private void CargarBitacora()
        {
            using (var db = new PvProyectoFinalDB("Conn")) // conexion a db
            {
                var registros = db.SpConsultarBitacora();
                gvBitacora.DataSource = registros;
                gvBitacora.DataBind();
            }
        }

    }
}

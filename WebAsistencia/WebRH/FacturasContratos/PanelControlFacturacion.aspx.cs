﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FacturasContratos_PanelControlFacturacion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnIngresarFacturas_Click(object sender, EventArgs e)
    {
        Response.Redirect("PresentacionDeFacturas.aspx");
    }

    protected void btnConsultaFacturas_Click(object sender, EventArgs e)
    {
        Response.Redirect("ConsultaDeFacturas.aspx");
    }

    protected void btnPaseFacturaContabilidad_Click(object sender, EventArgs e)
    {
        Response.Redirect("PaseFacturaContabilidad.aspx");
    }

    //protected void btnCertificarPersonasNoCertificadas_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("PersonasNoCertificadasAsigArea.aspx");
    //}

}
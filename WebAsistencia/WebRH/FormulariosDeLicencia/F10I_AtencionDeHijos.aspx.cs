﻿#region

using System;
using System.Threading;
using System.Web.UI.WebControls;
using WSViaticos;
using System.Collections.Generic;
using System.Web;
using System.Text;

#endregion

public partial class FormulariosDeLicencia_Default : System.Web.UI.Page
{
    ConceptoDeLicencia _Concepto;
    private String pathPdfTemplate = "\\Licenciaspdf\\Licencia Especial por Atención de hijos menores.pdf";// path del pdf que se rellenara
    private String nombrePdf = "Licencia\u00A0Especial\u00A0por\u00A0Atencion\u00A0de\u00A0hijos\u00A0menores.pdf";// nombre del pdf que se generara

    #region CargaContenidos
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = Titulo();
        ((Label)this.Master.FindControl("LTitulo")).Text = Titulo();
        ((Label)this.Master.FindControl("LResumenNormativa")).Text = Normativa();
        ((Label)this.Master.FindControl("LProcedimiento")).Text = Procedimiento();
        this.AceptarCancelar1.PuedeAceptar = false;
        this.AceptarCancelar1.Acepto += new EventHandler(AceptarCancelar1_Acepto);

        _Concepto = new ConceptoDeLicencia();
        _Concepto.Id = 11;


        //this.TextBox1.Attributes.Add("onkeyup", "javascript:activarSubmit(" + this.TextBox1.ClientID + "," + this.TBDesde.ClientID + "," + this.TextBox2.ClientID + "," + this.AceptarCancelar1.BotonAceptar.ClientID + ");");
        //this.TextBox2.Attributes.Add("onkeyup", "javascript:activarSubmit(" + this.TextBox1.ClientID + "," + this.TBDesde.ClientID + "," + this.TextBox2.ClientID + "," + this.AceptarCancelar1.BotonAceptar.ClientID + ");");

    }

    private string Titulo()
    {
        return @"Solicitud de Licencia Especial por Atención de hijos menores (Decreto 3.413/79 - Anexo I - Cap. III - Art. 10 i ) (CCT - Art. 142) ";
    }

    private string Procedimiento()
    {
        return @"<b>Procedimiento a seguir:</b><br>
1. Complete e imprima el formulario (desde el botón correspondiente)<br>
2. Con la firma del responsable directo (rango no inferior a Director) y la notificación del agente, remita el formulario a la Dirección de Administración. ";
    }

    private string Normativa()
    {
        return @"De acuerdo a lo especificado por el <b>Art. 10, inciso i) del Decreto 3.413/79 (Anexo I - Cap. III) y por el Convenio Colectivo de Trabajo en su Art. 142:</b><br>
El agente (varón o mujer) que tenga hijos menores de edad, en caso de fallecer la madre, madrastra, padre o tutor de los menores, tendrá derecho a <b>treinta (30)</b> días corridos de licencia, sin perjuicio de la que le pueda corresponder por fallecimiento. ";

    }

    #endregion

    #region LogicaDeEventos

    void AceptarCancelar1_Acepto(object sender, EventArgs e)
    {
        Licencia l = new Licencia();
        l.Desde = DateTime.Parse(this.TBDesde.Text);
        l.Hasta = l.Desde;
        l.Concepto = _Concepto;
        l.Persona = (Persona)Session["persona"];
        l.Persona.Area = (Area)Session["areaActual"];
        l.Auditoria = new Auditoria();
        l.Auditoria.UsuarioDeCarga = (Usuario)Session["usuario"];

        try
        {
            WSViaticosSoapClient s = new WSViaticosSoapClient();
            //WSViaticos.WSViaticos s = new WSViaticos.WSViaticos();
            string error = s.CargarLicencia(l);
            if (error == null)
            {
                //genero el pdf como respuesta
                this.GenerarPdf(this.pathPdfTemplate, this.nombrePdf, System.Web.HttpContext.Current.Response, l);
           
            }
            else
            {
                ((Label)this.Master.FindControl("LError")).Text = error;
            }
        }
        catch (ThreadAbortException)
        {
            Response.Redirect("~\\Principal.aspx");
        }
    }

    protected void BCalendarioDesde_Click(object sender, EventArgs e)
    {
        this.Calendar1.Visible = !this.Calendar1.Visible;
        if (this.Calendar1.Visible)
            this.AceptarCancelar1.PuedeAceptar = false;
        else
            ValidarDatos();
    }

    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {

        this.TBDesde.Text = this.Calendar1.SelectedDate.ToShortDateString();
        this.Calendar1.Visible = !this.Calendar1.Visible;
        if (this.Calendar1.Visible)
            this.AceptarCancelar1.PuedeAceptar = false;
        else
            ValidarDatos();

    }

    protected void TBApellido_TextChanged(object sender, EventArgs e)
    {
        ValidarDatos();
    }
    protected void TBDocumento_TextChanged(object sender, EventArgs e)
    {
        this.ValidarDatos();
    }

    private void ValidarDatos()
    {
        bool DatosValidos = true;

        if (this.TBDesde.Text == null)
            DatosValidos = false;
        else
            if (this.TBDesde.Text == "")
                DatosValidos = false;

        switch (this.TBApellido.Text)
        {
            case null:
                DatosValidos = false;
                break;
            case "":
                DatosValidos = false;
                break;
        }

        switch (this.TBDocumento.Text)
        {
            case null:
                DatosValidos = false;
                break;
            case "":
                DatosValidos = false;
                break;
        }

        this.AceptarCancelar1.PuedeAceptar = DatosValidos;
    }

    #endregion

    private void GenerarPdf(string pathPdfTemplate, string nombrePdf, System.Web.HttpResponse respuestaHTTP, Licencia l)
    {
        //diccionario donde guardar los keys y valores a llenar en los pdf
        Dictionary<string, string> dic = new Dictionary<string, string>();
        //clase que realiza el relleno del pdf
        RellenadorPdf rellenador = new RellenadorPdf();
        
        //lleno el diccionario  

        //obtengo la fecha actual del server, posteriormente tomo solo la parte de la fecha
        //tambien se puede usar "MM/dd/yyyy" para que me retorne exactamente esa cantidad de digitos

        dic.Add("nyap", l.Persona.Apellido + ", " + l.Persona.Nombre);
        dic.Add("dni", Convert.ToString(l.Persona.Documento));
        dic.Add("area", l.Persona.Area.Nombre);
        dic.Add("categoria", l.Persona.Categoria + " " + l.Persona.Grado + " " + l.Persona.Nivel);
        dic.Add("d1", l.Desde.ToShortDateString());
        /*los siguientes dos datos no son del mismo solicitante???*/
        dic.Add("nyap2", this.TBApellido.Text);
        dic.Add("dni2", this.TBDocumento.Text);
        dic.Add("fechaSolicitud", (DateTime.Now.Date).ToString("d"));

        rellenador.FillPDF(Server.MapPath("~") + pathPdfTemplate, nombrePdf, dic, respuestaHTTP);


    }


}

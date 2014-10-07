﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WSViaticos;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public partial class RegistroPostular_FormCaptchaRegistro : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btn_registrar_Click(object sender, EventArgs e)
    {
        if (ValidarCampos())
        {
            var servicio = Servicio();
            var personas = servicio.BuscarPersonas(JsonConvert.SerializeObject(new { Documento = Convert.ToInt32(this.txt_dni_registro.Text) }));
            if (personas.Length > 0)
            {
                this.lb_mensajeError.Text = "El documento ingresado ya está registrado, inicie sesión con el usuario asignado. Si no los recuerda, utilice la opción: '¿Olvidó sus datos?' o comuníquese con <br/> Recursos Humanos.";
                ScriptManager.RegisterStartupScript(this, GetType(), "RegistroHecho", "RegistroHecho();", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "RegistroOk", "RegistroOk();", true);
                //hay que llamar a la otra pantalla

            }
            
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "RegistroError", "RegistroError();", true);
        }
                   
    }

    private bool ValidarCampos()
    {
        //Validar el formato de la pantalla
        if (ValidarDNI() && ValidarCaptcha())
        {
            return true;
        }
        else 
        { 
            return false; 
        }
    }

    private bool ValidarDNI()
    {
        int dni = 0;
        try
        {
            dni = Convert.ToInt32(this.txt_dni_registro.Text);
        }
        catch (Exception)
        {
            this.lb_mensajeError.Text = "El formato del DNI no es válido.";
            return false; 
        }
       

        if (100000 < dni && dni < 99999999) //arreglar
        {
            return true;
        }
        else 
        {
            this.lb_mensajeError.Text = "El formato del DNI no es válido.";
            return false; 
        }
    }

    private bool ValidarCaptcha()
    {
        if (txtImg.Text.ToString().ToLower().Equals(Session["RandomNumero"].ToString().ToLower()))
        { 
            return true; 
        }
        else 
        {
            this.lb_mensajeError.Text = "Los dígitos ingresados no coninciden con los de la Imagen.";
            return false; 
        }
    }

    private WSViaticosSoapClient Servicio()
    {
        return new WSViaticosSoapClient();
    }
}
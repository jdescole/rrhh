﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SeleccionDeArea.aspx.cs"
    Inherits="SeleccionDeArea" %>
<%@ Register Src="ControlArea.ascx" TagName="ControlArea" TagPrefix="uc1" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Administrar áreas</title>
    <link rel="stylesheet" href="Estilos/EstilosSeleccionDeArea.css" type="text/css" runat="server" />    
    <link rel="stylesheet" href="Protocolo/VistaDeArea.css" type="text/css" runat="server" />
    <%= Referencias.Css("")%>
</head>

<form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="True"></asp:ScriptManager>
    <uc2:BarraMenu ID="BarraMenu" runat="server" UrlImagenes="Imagenes/" UrlEstilos="Estilos/" />
    <div class="contenedor_principal contenedor_principal_seleccion_areas">
        <legend style="text-shadow: 2px 2px 5px rgba(150, 150, 150, 1);">
            Áreas a Administrar 
            <a id="btn_consultar_areas" class="btn btn-primary" href="Protocolo/ConsultaProtocolo.aspx"> 
                Consultar Todas las Areas 
            </a>
        </legend>
        <div id="contenedor_areas_usuario">          
        </div> 
        <asp:HiddenField ID="areasDelUsuarioJSON" runat="server" EnableViewState="true"/>
    </div>

     <div id="plantillas">
        <div id="plantilla_vista_area" class="vista_area dialog_vista_area">
            <div class="encabezado ui-dialog-titlebar">
                <div id="nombre_area" class="ui-dialog-title"></div>
            </div>
            <div class="contenido">
                <div><div class="titulo">Responsable:</div> <div id="responsable" class="valor"></div></div>
                <div><div class="titulo">Dirección:</div> <div id="direccion" class="valor"></div></div>
                <div><div class="titulo">Teléfono:</div> <div id="telefono" class="valor"></div></div>
                <div><div class="titulo">Fax:</div> <div id="fax" class="valor"></div></div>
                <div><div class="titulo">Mail:</div> <div id="mail" class="valor"></div></div>
                <div id="asistentes"></div>
                <div class="botonera">
                    <a id="btn_administrar_personal"> Administrar Personal </a>
                    <a id="btn_solicitar_modificacion"> Solicitar Modificación De Datos </a>
                </div>
            </div>
        </div>
        <div id="plantilla_vista_asistente" class="vista_asistente">
            <div><div id="cargo" class="titulo"></div> <div id="resumen" class="valor"></div></div>                 
        </div>
    </div>
</form>
</body>

<script type="text/javascript" src="Scripts/jquery-ui-1.10.2.custom/js/jquery-1.9.1.js"></script>
<script type="text/javascript" src="Scripts/jquery-ui-1.10.2.custom/js/jquery-ui-1.10.2.custom.min.js"></script>

<script type="text/javascript" src="PantallaDeSeleccionDeAreas.js"></script>
<script type="text/javascript" src="Protocolo/Area.js"></script>
<script type="text/javascript" src="Protocolo/VistaDeArea.js"></script>
<script type="text/javascript" src="Protocolo/VistaDeAsistente.js"></script>
<script type="text/javascript" src="Scripts/Sesion.js"></script>
<script type="text/javascript" src="Scripts/ProveedorAjax.js"></script>

<script type="text/javascript">
    $(document).ready(function () {
        var seleccion_de_areas = new PantallaDeSeleccionDeAreas();
    });
</script>
</html>

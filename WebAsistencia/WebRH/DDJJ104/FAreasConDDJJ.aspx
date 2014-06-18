﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FAreasConDDJJ.aspx.cs" Inherits="DDJJ104_FAreasConDDJJ" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <%= Referencias.Css("../")%>
    <%= Referencias.Javascript("../") %>

    <%--<link rel="stylesheet" type="text/css" href="Style.css" />--%>
</head>


<body>
    <form id="form1" runat="server">
    <uc2:BarraMenu ID="BarraMenu" UrlPassword="../" runat="server" Feature="<span style='font-size:20px; font-weight: bold;'></span>" UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />

    <fieldset>
        <legend>Areas a Administrar</legend>
    </fieldset>

    <div>    
        <select runat="server" title="Seleccione un mes" id="cmbMeses" name="Meses" enableviewstate="false"
            style="text-transform: capitalize;">
        </select>
    </div>
    <div id="ContenedorGrilla" runat="server">
    </div>
    
    <div id="progressbar">
        <div class="ui-progressbar-overlay" " > Cargando... </div>    
    </div>
    
    <asp:HiddenField ID="AreasJSON" runat="server" EnableViewState="true" />
    
    </form>
</body>


<script src="DDJJ.js" type="text/javascript"></script>


</html>

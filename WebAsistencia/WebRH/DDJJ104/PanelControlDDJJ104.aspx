﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PanelControlDDJJ104.aspx.cs" Inherits="DDJJ104_PanelControlDDJJ104" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <%= Referencias.Css("../")%>
    <%= Referencias.Javascript("../") %>
</head>
<body>
    <form id="form1" runat="server">

    <uc2:BarraMenu ID="BarraMenu1" UrlPassword="../" runat="server" Feature="<span style='font-size:20px; font-weight: bold;'></span>" UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />

    
    <div style="" align="center">
        <div style="display: block; width: 60%; padding: 0; margin-bottom: 27px; font-size: 19.5px;
            line-height: 36px; color: #333333; border: 0; border-bottom: 1px solid #e5e5e5;
            text-shadow: 2px 2px 5px rgba(150, 150, 150, 1); text-align: left;">
            Men&uacute; de DDJJ 104
            
            
            <div id="DivBotonCertificarPersonasNoCertificadas" runat="server" style="display: block; float:right;
                margin-top: 4px; margin-left: 4px; border: #0055cc;" >
                <asp:Button runat="server" ID="btnCertificarPersonasNoCertificadas" 
                    RequiereFuncionalidad="63" CssClass="btn btn-primary" 
                    Text="Certificar personas no certificadas" UseSubmitBehavior="True" 
                    onclick="btnCertificarPersonasNoCertificadas_Click" />
            </div>
            
            <div id="DivBotonPersonasNoCertificadas" runat="server"   style="display: block; float:right;
                margin-top: 4px; margin-left: 4px; border: #0055cc;" >
                <asp:Button runat="server" ID="btnPersonasNoCertificadas" 
                    RequiereFuncionalidad="62" CssClass="btn btn-primary" 
                    Text="Personas no certificadas" UseSubmitBehavior="True" 
                    onclick="btnPersonasNoCertificadas_Click" />
            </div>

            <div id="DivBotonConsultarDDJJ" runat="server"   style="display: block; float:right;
                margin-top: 4px; margin-left: 4px; border: #0055cc;" >
                <asp:Button runat="server" ID="btnConsultaDDJJ" RequiereFuncionalidad="61" CssClass="btn btn-primary" 
                    Text="Consultar DDJJ" UseSubmitBehavior="True" 
                    onclick="btnConsultaDDJJ_Click"/> 
            </div>
            
            <div id="DivBotonCertificarArea" runat="server"  style="display: block; float:right;
                margin-top: 4px; margin-left: 4px; border: #0055cc;" >
                <asp:Button runat="server" ID="btnCertificarArea" RequiereFuncionalidad="22" CssClass="btn btn-primary" 
                    Text="Certificar Areas" UseSubmitBehavior="True"
                    onclick="btnCertificarArea_Click" /> 
            </div>
            

        </div>
    </div>

    </form>
</body>
</html>
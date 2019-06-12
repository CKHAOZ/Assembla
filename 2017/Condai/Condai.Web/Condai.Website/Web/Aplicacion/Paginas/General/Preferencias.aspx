<%@ Page Title="" Language="C#" MasterPageFile="~/Web/Aplicacion/Paginas/MasterPage/Condai.Master" AutoEventWireup="true" CodeBehind="Preferencias.aspx.cs" Inherits="Condai.Web.Web.Aplicacion.Paginas.General.Preferencias" %>
<asp:Content ID="conPrincipal" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="conSecundario" ContentPlaceHolderID="cphPrincipal" runat="server">
    <!-- Service -->
    <asp:ScriptManager ID="scrPrincipal" runat="server" EnablePageMethods="true" EnableScriptGlobalization="true"
        EnableScriptLocalization="true" EnablePartialRendering="true">
        <Services>
            <asp:ServiceReference Path="~/servicios/Aplicacion/MasterPage/MasterPage.svc" />
        </Services>
    </asp:ScriptManager>
</asp:Content>

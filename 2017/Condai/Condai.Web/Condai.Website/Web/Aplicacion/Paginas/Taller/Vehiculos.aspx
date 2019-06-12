<%@ Page Title="" Language="C#" MasterPageFile="~/Web/Aplicacion/Paginas/MasterPage/Condai.Master" AutoEventWireup="true" CodeBehind="Vehiculos.aspx.cs" Inherits="Condai.Web.Web.Aplicacion.Paginas.Taller.Vehiculos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPrincipal" runat="server">
    <!-- Service -->
    <asp:ScriptManager ID="scrPrincipal" runat="server" EnablePageMethods="true" EnableScriptGlobalization="true"
        EnableScriptLocalization="true" EnablePartialRendering="true">
        <Services>
            <asp:ServiceReference Path="~/servicios/Aplicacion/MasterPage/MasterPage.svc" />
        </Services>
    </asp:ScriptManager>
</asp:Content>

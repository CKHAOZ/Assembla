<%@ Page Title="" Language="C#" MasterPageFile="~/Web/Aplicacion/Paginas/MasterPage/Condai.Master" AutoEventWireup="true" CodeBehind="Condai.aspx.cs" Inherits="Condai.Web.Web.Aplicacion.Condai.Condai" %>
<asp:Content ID="conTitle" ContentPlaceHolderID="head" runat="server">
     <!-- link : Condai Usuario -->
    <link href="../../../../style/Aplicacion/Condai/Condai.css" rel="stylesheet" />
    <script>
        setTimeout(function () {
            $('#hdfCondai').val('1');
        }, 500);
    </script>
</asp:Content>
<asp:Content ID="conSecundario" ContentPlaceHolderID="cphPrincipal" runat="server">
    <!-- Service -->
    <asp:ScriptManager ID="scrPrincipal" runat="server" EnablePageMethods="true" EnableScriptGlobalization="true"
        EnableScriptLocalization="true" EnablePartialRendering="true">
        <Services>
            <asp:ServiceReference Path="~/servicios/Aplicacion/MasterPage/MasterPage.svc" />
        </Services>
    </asp:ScriptManager>
     <!-- Condai -->
    <div class="divPrincipal">
        <h3 id="lblBienvenida"></h3>
    </div>
</asp:Content>

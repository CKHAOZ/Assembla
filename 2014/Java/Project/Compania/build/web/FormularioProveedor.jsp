<%-- 
    Document   : FormularioClases
    Created on : 11/09/2014, 07:08:43 PM
    Author     : EQUIPO19
--%>

<%@page import="Datos.Listados"%>
<%@page contentType="text/html" pageEncoding="UTF-8" import="Datos.Proveedor"%>
<html>
    <head>
        <title>PROVEEDOR</title>
    </head>
    <body>
        <h4 style="text-align: center">Proveedor</h4>
        <br>
        <%
            Proveedor pro = new Proveedor();
            
            pro.Nombre = request.getParameter("Nombre");
            pro.Direccion = request.getParameter("Direccion");
            pro.Nit = request.getParameter("Nit");
            pro.Telefono = request.getParameter("Telefono");
            pro.Correo = request.getParameter("Correo");

            Listados objetoListas = new Listados();
            
            objetoListas.GuardarProveedor(pro);
        %>

        <form name="Datos_proveedor" action="./FormularioProveedor.jsp"> 
            <center>
                Nombre: <input type="text" name="Nombre" value="" /><br>
                Direccion: <input type="text" name="Direccion" value="" /><br> 
                Nit: <input type="text" name="Nit" value="" /><br>
                Telefono: <input type="text" name="Telefono" value="" /><br>
                Correo: <input type="text" name="Correo" value="" /><br>
                <input type="submit" value="Guardar" name="Guardar" />
                <input type="button" value="Fin" name="btnFin" onclick="location.href='Fin.jsp'"/></center> <br>
            </center>
        </form>
         <% 
            for (int i = 0; i < objetoListas.listaProveedor.size(); i++) 
            {
                Proveedor prov = objetoListas.listaProveedor.get(i);
                            
                out.print("</br>");
                
                out.print("&nbsp; <b>Nombre: </b>" + prov.Nombre);
                out.print("&nbsp; <b>Dirección: </b>" + prov.Direccion);
                out.print("&nbsp; <b>Nit: </b>" + prov.Nit);
                out.print("&nbsp; <b>Telefono: </b>" + prov.Telefono);
                out.print("&nbsp; <b>Correo: </b>" + prov.Correo);
                
                out.print("</br>");
            }
            %>
 
</body>
</html>

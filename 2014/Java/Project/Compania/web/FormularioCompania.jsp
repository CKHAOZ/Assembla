<%-- 
    Document   : Formulario
    Created on : 14/09/2014, 06:53:29 PM
    Author     : User
--%>


<%@page import="Datos.Listados"%>
<%@page import="java.util.ArrayList"%>
<%@page contentType="text/html" pageEncoding="UTF-8" import="Datos.Compania"%>
<html>
    <head>
        <title>COMPAÑIA</title>
    </head>
    <body>
        <h4 style="text-align: center">Compañia</h4>
        <br>
        <%  
            Compania Comp = new Compania();
            
            Comp.Nombre = request.getParameter("Nombre");
            Comp.Direccion = request.getParameter("Direccion");
            Comp.Telefono = request.getParameter("Telefono");
            Comp.Nit = request.getParameter("Nit");
            Comp.Correo = request.getParameter("Correo");

            Listados objetoListas = new Listados();
            
            objetoListas.GuardarCompania(Comp);
        %>
        
        <form name="Datos_Compania" action="./FormularioCompania.jsp">
            <center>
                Nombre  <input type="text" name="Nombre" value="" /><br>
                Direccion  <input type="text" name="Direccion" value="" /><br>
                Telefono  <input type="text" name="Telefono" value="" /><br>
                Nit  <input type="text" name="Nit" value="" /><br>
                Correo  <input type="text" name="Correo" value="" /><br>
            
                <br/>
                
               <input type="submit" value="Guardar" />              

               <input type="button" value="Siguiente" name="btnRegresar" onclick="location.href='FormularioCliente.jsp'"/>     
               
            </center>
        </form>
      
         <% 
            for (int i = 0; i < objetoListas.listaCompania.size(); i++) 
            {
                Compania CompExistente = objetoListas.listaCompania.get(i);
                            
                out.print("</br>");
                
                out.print("&nbsp; <b>Nombre: </b>" + CompExistente.Nombre);
                out.print("&nbsp; <b>Dirección: </b>" + CompExistente.Direccion);
                out.print("&nbsp; <b>Telefono: </b>" + CompExistente.Telefono);
                out.print("&nbsp; <b>Nit: </b>" + CompExistente.Nit);
                out.print("&nbsp; <b>Correo: </b>" + CompExistente.Correo);
                
                out.print("</br>");
            }
            %>
        
    </body>
</html>

<%@page import="Datos.Listados"%>
<%@page import="Datos.Compania"%>
<%@page import="Datos.Cliente"%>
<%@page contentType="text/html" pageEncoding="UTF-8"%>
<html>
    <head>
        <title>JSP Page</title>
    </head>
    <body>
        
        <h4 style="text-align: center">Cliente</h4>
        <br>
        <% 
           Cliente Cli = new Cliente();
            
            Cli.Nombre = request.getParameter("Nombre");
            Cli.Apellido1 = request.getParameter("Apellido1");
            Cli.Apellido2 = request.getParameter("Apellido2");
            Cli.Telefono = request.getParameter("Telefono");
            Cli.Direccion = request.getParameter("Direccion");
            Cli.Correo = request.getParameter("Correo");

            Listados objetoListas = new Listados();
            
            objetoListas.GuardarCliente(Cli);
        %>

        <form style="text-align: center" name="Datos_cliente" action="./FormularioCliente.jsp"> 
            Nombre: <input type="text" name="Nombre" value="" /><br>
            Primer Apellido: <input type="text" name="Apellido1" value="" /><br> 
            Segubdo Apellido: <input type="text" name="Apellido2" value="" /><br>
            Telefono: <input type="text" name="Telefono" value="" /><br>
            Direccion: <input type="text" name="Direccion" value="" /><br>
            Correo: <input type="text" name="Correo" value="" /><br>
            <br/>
            <input type="submit" value="Guardar"/> 
            <input type="button" value="Siguiente" name="btnRegresar" onclick="location.href='FormularioProveedor.jsp'"/></center> <br>
        
        </form>
        
         <% 
            for (int i = 0; i < objetoListas.listaCliente.size(); i++) 
            {
                Cliente Clie = objetoListas.listaCliente.get(i);
                            
                out.print("</br>");
                
                out.print("&nbsp; <b>Nombre: </b>" + Clie.Nombre);
                out.print("&nbsp; <b>Apellido 1:  </b>" + Clie.Apellido1);
                out.print("&nbsp; <b>Apellido 2: </b>" + Clie.Apellido2);
                out.print("&nbsp; <b>Telefono:  </b>" + Clie.Telefono);
                out.print("&nbsp; <b>Dirección: </b>" + Clie.Direccion);
                out.print("&nbsp; <b>Correo: </b>" + Clie.Correo);
                
                out.print("</br>");
            }
            %>
        
    </body>
</html>

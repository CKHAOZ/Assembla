<%@page import="Aerolinea.Reportes"%>
<%@page import="Aerolinea.Destinos"%>
<%@page contentType="text/html" pageEncoding="UTF-8"%>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>Destinos</title>
    </head>
    <body>
    <br>
        <% 
            Destinos destino = new Destinos();
            
            destino.Destino = request.getParameter("txtDestino");
            destino.Valor = request.getParameter("txtValor");
           
            Reportes objDestino = new Reportes();
            
            objDestino.GuardarDestino(destino);
        %>
         <form name="Destinos" action="./Destinos.jsp">
        <center>
        <h2> Destinos </h2>
             <table>
            <tr>
                <td>Destino</td>
                <td><input name="txtDestino" type="text" />  </td>
            </tr>
            <tr>
                <td>Valor</td>
                <td><input name="txtValor" type="text" />  </td>
            </tr>
        </table>
        <br/>
        <input type="submit" value="Guardar" />
        <br/>
        <br/>
        <input type="button" value="Regresar" name="btnRegresar" onclick="location.href='./'"/>
        </center>
         </form>
        <% 
            for (int i = 0; i < objDestino.listaDestino.size(); i++) 
            {
                Destinos destinoLeer = objDestino.listaDestino.get(i);

                out.print("</br>");

                out.print("&nbsp; <b>Destino </b>" + destinoLeer.Destino);
                out.print("&nbsp; <b>Valor:  </b>" + destinoLeer.Valor);

                out.print("</br>");
            }
            
            session.setAttribute("ListaDestinos", objDestino.listaDestino);
        %>
    
    </body>
</html>

<%@page import="java.util.ArrayList"%>
<%@page import="Aerolinea.Vuelos"%>
<%@page contentType="text/html" pageEncoding="UTF-8"%>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>Reportes</title>
    </head>
    <body>
    <center>
        <h2> Vuelos </h2>
         <% 
            ArrayList<Vuelos> listaVuelos = (ArrayList<Vuelos>)session.getAttribute("sesionVuelos");

            if (listaVuelos != null) {
                for (int i = 0; i < listaVuelos.size(); i++) 
                {
                    Vuelos vueloLeer = listaVuelos.get(i);

                    out.print("</br>");

                    out.print("&nbsp; <b>Destino: </b>" + vueloLeer.Destino);
                    out.print("&nbsp; <b>Fecha: </b>" + vueloLeer.Fecha);
                    out.print("&nbsp; <b>Hora:  </b>" + vueloLeer.Hora);
                    out.print("&nbsp; <b>Valor:  </b>" + vueloLeer.Valor);

                    out.print("</br>");
                }
            }
        %>
    </center>
    </body>
</html>

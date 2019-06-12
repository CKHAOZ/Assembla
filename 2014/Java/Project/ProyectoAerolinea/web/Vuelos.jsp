<%@page import="java.util.ArrayList"%>
<%@page import="Aerolinea.Destinos"%>
<%@page import="Aerolinea.Reportes"%>
<%@page import="Aerolinea.Vuelos"%>
<%@page contentType="text/html" pageEncoding="UTF-8"%>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>Vuelos</title>
    </head>
    <body>
       <br>
        <% 
            ArrayList<Destinos> listaDestinosGuardados = (ArrayList<Destinos>)session.getAttribute("ListaDestinos");
            
            Vuelos vuelo = new Vuelos();
            
            Reportes objVuelos = new Reportes();
            
            vuelo.Fecha = request.getParameter("txtFecha");
            vuelo.Hora = request.getParameter("txtHora");
            vuelo.IdayVuelta = request.getParameter("IdayVuelta");
            vuelo.Destino = objVuelos.BuscarDestino(request.getParameter("destino"));            
            vuelo.Valor = objVuelos.BuscarValor(request.getParameter("destino"));
            
            objVuelos.GuardarVuelo(vuelo);
        %>
        <form style="text-align: center" name="Destinos" action="./Vuelos.jsp"> 
            
   <center>
       <h2> Vuelos </h2>
       <table>
            <tr>
                <td>Fecha</td>
                <td>
                    <input name="txtFecha" type="text" />  
                </td>
            </tr>
            <tr>
                <td>Hora</td>
                <td>
                    <input name="txtHora" type="text" />  
                </td>
            </tr>
              <tr>
                <td>Destinos</td>
                <td>
                    <select name="destino">
                        <option value=""> Seleccione </option>
                    <%
                        ArrayList<Destinos> listaDestino = (ArrayList<Destinos>)session.getAttribute("ListaDestinos");
             
                        if (listaDestino != null) 
                        {
                            for (int i = 0; i < listaDestino.size(); i++) 
                            {
                                Destinos destinoLeer = listaDestino.get(i);

                                out.print("<option value="+destinoLeer.Destino+":"+ destinoLeer.Valor+">"+destinoLeer.Destino);
                            }
                        }
                    %>
                    </select>
                </td>
            </tr>
            <tr>
                <td>Ida y Vuelta</td>
                <td>
                    <select name="IdayVuelta">
                        <option value=""> Seleccione </option>
                        <option value="SI">SI</option>
                        <option value="NO">NO</option>
                    </select>
                </td>
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
            for (int i = 0; i < objVuelos.listaVuelos.size(); i++) 
            {
                Vuelos vueloLeer = objVuelos.listaVuelos.get(i);

                out.print("</br>");

                out.print("&nbsp; <b>Fecha </b>" + vueloLeer.Fecha);
                out.print("&nbsp; <b>Hora  </b>" + vueloLeer.Hora);
                out.print("&nbsp; <b>Destino  </b>" + vueloLeer.Destino);
                out.print("&nbsp; <b>Valor  </b>" + vueloLeer.Valor);
                out.print("&nbsp; <b>Ida y Vuelta  </b>" + vueloLeer.IdayVuelta);

                out.print("</br>");
            }
            
            session.setAttribute("sesionVuelos", objVuelos.listaVuelos);
        %>
        
    </body>
</html>

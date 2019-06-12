package Aerolinea;
import java.util.ArrayList;
public class Reportes {

    public static ArrayList<Destinos> listaDestino;
    public static ArrayList<Vuelos> listaVuelos;    

    public void GuardarDestino(Destinos destinoNuevo)
    {
        if (listaDestino == null) {
            listaDestino = new ArrayList<>();                
        }
        
        if (destinoNuevo.Destino != ""&&destinoNuevo.Destino != null) {
            listaDestino.add(destinoNuevo);    
        }        
    }
    
    public void GuardarVuelo(Vuelos vueloNuevo)
    {
        if (listaVuelos == null) {
            listaVuelos = new ArrayList<>();                
        }
        
        if (vueloNuevo.Destino == null) {
            vueloNuevo.Destino = "";                    
        }
        
        if (vueloNuevo.Fecha !="" &&vueloNuevo.Fecha != null) {
            listaVuelos.add(vueloNuevo);    
        }        
    }
    
    public String BuscarValor(String destinoNombre)
    {
        String resultado = "";
        if (destinoNombre != "" && destinoNombre != null) {
            String[] valores = destinoNombre.split(":");
            if (valores.length > 1) {
                resultado = valores[1];    
            }        
        }
        return resultado;       
    }
    
    public String BuscarDestino(String destinoNombre)
     {
        String resultado = "";
         if (destinoNombre != ""&& destinoNombre!=null) {
            String[] valores = destinoNombre.split(":");
            if (valores.length > 0) {
                resultado = valores[0];    
            }        
         }
        return resultado;       
    }
    
}

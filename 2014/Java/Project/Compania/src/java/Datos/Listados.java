package Datos;

import java.util.ArrayList;

public class Listados {
    
    public static ArrayList<Compania> listaCompania;
    public static ArrayList<Cliente> listaCliente;
    public static ArrayList<Proveedor> listaProveedor;
    
    public void GuardarCompania(Compania companiaNueva)
    {
        if (listaCompania == null) {
            listaCompania = new ArrayList<>();                
        }
        
        if (companiaNueva.Nombre != null) {
            listaCompania.add(companiaNueva);    
        }        
    }
    
    public void GuardarCliente(Cliente clienteNuevo)
    {
        if (listaCliente == null) {
            listaCliente = new ArrayList<>();                
        }
        
        if (clienteNuevo.Nombre != null) {
            listaCliente.add(clienteNuevo);
        }
    }           
    
    public void GuardarProveedor(Proveedor ProveedorNuevo)
    {
        if (listaProveedor == null) {
            listaProveedor = new ArrayList<>();                
        }
        
        if (ProveedorNuevo.Nombre != null) {
            listaProveedor.add(ProveedorNuevo);
        }
    }    
}

using Condai.Almacenamiento;
using System.IO;
using Condai.Entity;
using Condai.Entity.Base;

namespace Condai.BLL
{
    public class BLLUsuarios
    {
        #region [ Atributos ]

        public string parIdUsuarios = "BCK";
        public string parValorUsuarios = "BUS";

        #endregion

        #region [ Propiedades ]

        private static BLLUsuarios obj = new BLLUsuarios();

        public static BLLUsuarios Instancia
        {
            get { return obj; }
        }

        #endregion

        #region [ Metodos ]
        
        public bool CargarImagenUsuario(string keyName, Stream data)
        {
            bool resultado = false;

            Transaccion<Base_Parametro> trUsuarios = BLLParametros.Instancia.LeerParametro(parIdUsuarios, parValorUsuarios);

            if (trUsuarios.Estado == Estado.Correcto)
            {
                Base_Parametro parametroUsuario = (Base_Parametro)trUsuarios.Dato;

                Transaccion<bool> trAws = Aws.Instancia.CargarArchivo(parametroUsuario.parDescripcion, keyName, data);

                if (trAws.Estado == Estado.Correcto)
                    resultado = trAws.Dato;
            }
            
            return resultado;
        }

        #endregion
    }
}

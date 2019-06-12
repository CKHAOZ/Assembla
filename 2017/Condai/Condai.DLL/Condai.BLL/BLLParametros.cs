using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Condai.Entity;
using Condai.Tools;
using Condai.Entity.Base;

namespace Condai.BLL
{
    public class BLLParametros
    {
        #region [ Atributos ]

        private static string Dll = "Condai.BLL.BLLParametros";

        #endregion
        
        #region [ Propiedades ]

        private static BLLParametros obj = new BLLParametros();

        #endregion

        #region [ Construstor ]

        public static BLLParametros Instancia
        {
            get { return obj; }
        }

        #endregion

        #region [ Metodos ]

        public Transaccion<Base_Parametro> LeerParametro(string parId, string parValor)
        {
            Transaccion<Base_Parametro> resultado = ManejoTransaccion<Base_Parametro>.Instancia.InicializarTransaccion(Dll);

            Transaccion<Base_Parametro> tr = DAL.DALParametros.Instancia.LeerParametro(parId, parValor);

            if (tr.Estado == Estado.Correcto)
            {
                resultado = ManejoTransaccion<Base_Parametro>.Instancia.Resultado(Estado.Correcto, resultado, tr.Dato, "Cargado");
            }
            else
            {
                resultado = ManejoTransaccion<Base_Parametro>.Instancia.Resultado(Estado.Error, resultado, null, "El parametro no se encuentra");
            }

            return resultado;
        }

        #endregion
    }
}

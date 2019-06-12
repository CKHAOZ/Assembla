using Condai.Entity;
using Condai.Entity.Base;
using System;
using System.Linq.Expressions;

namespace Condai.DAL
{
    public class DALParametros
    {
        #region [ Propiedades ]

        private static DALParametros obj = new DALParametros();

        public static DALParametros Instancia { get { return obj; } }

        #endregion

        #region [ Metodos ]

        public Transaccion<Base_Parametro> LeerParametro(string parId, string parValor)
        {
            Transaccion<Base_Parametro> resultado = new Transaccion<Base_Parametro>();

            RepositorioBase<Base_Parametro> contexto = new RepositorioBase<Base_Parametro>();

            Expression<Func<Base_Parametro, bool>> linq = (i => i.parId == parId && i.parValor == parValor);
            
            resultado = contexto.SeleccionaObjeto(linq);

            contexto.Dispose();

            return resultado;
        }

        #endregion
    }
}

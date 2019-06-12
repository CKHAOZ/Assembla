using System;
using System.Linq.Expressions;
using Condai.Entity;
using Condai.Entity.Base;

namespace Condai.DAL
{
    public class DALParametrosCascada
    {
        #region [ Propiedades ]

        private static DALParametrosCascada obj = new DALParametrosCascada();

        public static DALParametrosCascada Instancia { get { return obj; } }

        #endregion
        
        #region [ Metodos ]

        public Transaccion<Base_ParametroCascada> LeerParametros(string parId, string parValor)
        {
            Transaccion<Base_ParametroCascada> resultado = new Transaccion<Base_ParametroCascada>();

            RepositorioBase <Base_ParametroCascada> contexto = new RepositorioBase<Base_ParametroCascada>();

            Expression<Func<Base_ParametroCascada, bool>> linq = (i => i.parId1 == parId && i.parValor1 == parValor);

            resultado = contexto.SeleccionaObjeto(linq);

            contexto.Dispose();

            return resultado;
        }
        
        #endregion
    }
}

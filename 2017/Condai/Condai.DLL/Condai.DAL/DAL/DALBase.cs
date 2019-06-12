using Condai.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Condai.Entity.Base;

namespace Condai.DAL
{
    public class DALBase
    {
        #region [ Propiedades ]

        private static DALBase obj = new DALBase();

        public static DALBase Instancia { get { return obj; } }

        #endregion

        #region [ Metodos ]

        public Transaccion<List<Base_Menu>> ObtenerMenu(bool estado)
        {
            Transaccion<List<Base_Menu>> resultado = new Transaccion<List<Base_Menu>>();
            
            RepositorioBase<Base_Menu> contexto = new RepositorioBase<Base_Menu>();
            
            Expression<Func<Base_Menu, bool>> linq = (i => i.menActivo == true);

            Expression<Func<Base_Menu, int>> linqOrden = (i => i.menOrden);

            resultado = contexto.SeleccionaListado(linq, 25, linqOrden);

            contexto.Dispose();

            return resultado;
        }

        #endregion
    }
}

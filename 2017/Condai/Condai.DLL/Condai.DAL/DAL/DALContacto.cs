using Condai.Entity;
using System;
using System.Linq.Expressions;
using Condai.Entity.Contacto;

namespace Condai.DAL
{
    public class DALContacto
    {
        #region [ Propiedades ]

        private static DALContacto obj = new DALContacto();

        public static DALContacto Instancia { get { return obj; } }

        #endregion

        #region [ Metodos ]

        public Transaccion<int> AgregarContacto(Contacto_Inquietud add)
        {
            Transaccion<int> resultado = new Transaccion<int>();
            
            RepositorioContacto<Contacto_Inquietud> contexto = new RepositorioContacto<Contacto_Inquietud>();

            resultado = contexto.InsertarObjeto(add);

            contexto.Dispose();

            return resultado;
        }

        public Transaccion<Contacto_Inquietud> LeerContactoInquietud(int codigo)
        {
            Transaccion<Contacto_Inquietud> resultado = new Transaccion<Contacto_Inquietud>();

            RepositorioContacto<Contacto_Inquietud> contexto = new RepositorioContacto<Contacto_Inquietud>();

            Expression<Func<Contacto_Inquietud, bool>> linq = (i => i.id == codigo);

            resultado = contexto.SeleccionaObjeto(linq);

            contexto.Dispose();
            
            return resultado;
        }
        
        #endregion
    }
}

using Condai.Entity;
using Condai.Tools;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Condai.DAL
{
    public abstract class Repositorio<TEntity> : IDisposable where TEntity : class
    {
        #region [ Atributos ]

        private static string DLL = "Condai.DAL.Repositorio";

        private static string INSERTAROBJETO = "InsertarObjeto";

        private static string ELIMINAROBJETO = "EliminarObjeto";

        private static string ACTUALIZAROBJETO = "ActualizarObjeto";

        private static string SELECCIONAOBJETO = "SeleccionaObjeto";

        private static string SELECCIONALISTADOSINTOP = "SeleccionarListadoSinTop";

        private static string SELECCIONARLISTADO = "SeleccionarListado";

        #endregion

        #region [ Propiedades ]

        public abstract DbContext Contexto { get; }

        private DbSet<TEntity> EntitySet
        {
            get
            {
                return Contexto.Set<TEntity>();
            }
        }

        #endregion

        #region [ Constructor ]

        public Repositorio()
        {
            Contexto.Configuration.ProxyCreationEnabled = false;
            Contexto.Configuration.ValidateOnSaveEnabled = false;
        }

        #endregion

        #region [ Metodos ]

        public Transaccion<int> InsertarObjeto(TEntity nuevo)
        {
            Transaccion<int> resultado = ManejoTransaccion<int>.Instancia.InicializarTransaccion(DLL);

            int executeSaveChanges = 0;

            try
            {
                EntitySet.Add(nuevo);
                executeSaveChanges = Contexto.SaveChanges();
                resultado = ManejoTransaccion<int>.Instancia.Resultado<int>(Estado.Correcto, resultado, executeSaveChanges, INSERTAROBJETO);
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException oe)
            {
                executeSaveChanges = 0;
                resultado = ManejoTransaccion<int>.Instancia.Resultado<int>(Estado.Error, resultado, executeSaveChanges, (oe.InnerException.InnerException.Message != string.Empty ? oe.InnerException.InnerException.Message : oe.Message), oe.StackTrace);
            }
            catch (Exception oe)
            {
                executeSaveChanges = 0;
                resultado = ManejoTransaccion<int>.Instancia.Resultado<int>(Estado.Error, resultado, executeSaveChanges, (oe.InnerException.InnerException.Message != string.Empty ? oe.InnerException.InnerException.Message : oe.Message), oe.StackTrace);
            }

            return resultado;
        }

        public Transaccion<bool> EliminarObjeto(TEntity entidad)
        {
            Transaccion<bool> resultado = ManejoTransaccion<bool>.Instancia.InicializarTransaccion(DLL);

            bool executeDelete = false;

            try
            {
                EntitySet.Attach(entidad);
                EntitySet.Remove(entidad);
                executeDelete = Contexto.SaveChanges() > 0;
                resultado = ManejoTransaccion<bool>.Instancia.Resultado<bool>(Estado.Correcto, resultado, executeDelete, ELIMINAROBJETO);
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException oe)
            {
                executeDelete = false;
                resultado = ManejoTransaccion<TEntity>.Instancia.Resultado<bool>(Estado.Error, resultado, executeDelete, (oe.InnerException.InnerException.Message != string.Empty ? oe.InnerException.InnerException.Message : oe.Message), oe.StackTrace);
            }
            catch (Exception oe)
            {
                executeDelete = false;
                resultado = ManejoTransaccion<TEntity>.Instancia.Resultado<bool>(Estado.Error, resultado, executeDelete, (oe.InnerException.InnerException.Message != string.Empty ? oe.InnerException.InnerException.Message : oe.Message), oe.StackTrace);
            }

            return resultado;
        }

        public Transaccion<bool> ActualizarObjeto(TEntity entidad)
        {
            Transaccion<bool> resultado = ManejoTransaccion<bool>.Instancia.InicializarTransaccion(DLL);

            bool executeUpdate = false;

            try
            {
                EntitySet.Attach(entidad);
                Contexto.Entry(entidad).State = EntityState.Modified;
                executeUpdate = Contexto.SaveChanges() > 0;
                resultado = ManejoTransaccion<bool>.Instancia.Resultado<bool>(Estado.Correcto, resultado, executeUpdate, ACTUALIZAROBJETO);
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException oe)
            {
                executeUpdate = false;
                resultado = ManejoTransaccion<TEntity>.Instancia.Resultado<bool>(Estado.Error, resultado, executeUpdate, (oe.InnerException.InnerException.Message != string.Empty ? oe.InnerException.InnerException.Message : oe.Message), oe.StackTrace);
            }
            catch (Exception oe)
            {
                executeUpdate = false;
                resultado = ManejoTransaccion<TEntity>.Instancia.Resultado<bool>(Estado.Error, resultado, executeUpdate, (oe.InnerException.InnerException.Message != string.Empty ? oe.InnerException.InnerException.Message : oe.Message), oe.StackTrace);
            }

            return resultado;
        }

        public Transaccion<TEntity> SeleccionaObjeto(System.Linq.Expressions.Expression<Func<TEntity, bool>> linq)
        {
            Transaccion<TEntity> resultado = ManejoTransaccion<TEntity>.Instancia.InicializarTransaccion(DLL);

            TEntity execute = null;
            
            try
            {
                execute = EntitySet.FirstOrDefault(linq);

                if (execute == null)
                    resultado = ManejoTransaccion<TEntity>.Instancia.Resultado<TEntity>(Estado.Alerta, resultado, execute, SELECCIONAOBJETO);
                else
                    resultado = ManejoTransaccion<TEntity>.Instancia.Resultado<TEntity>(Estado.Correcto, resultado, execute, SELECCIONAOBJETO);
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException oe)
            {
                execute = null;
                resultado = ManejoTransaccion<TEntity>.Instancia.Resultado<TEntity>(Estado.Error, resultado, execute, (oe.InnerException.InnerException.Message != string.Empty ? oe.InnerException.InnerException.Message : oe.Message), oe.StackTrace);
            }
            catch (Exception oe)
            {
                execute = null;
                resultado = ManejoTransaccion<TEntity>.Instancia.Resultado<TEntity>(Estado.Error, resultado, execute, (oe.InnerException.InnerException.Message != string.Empty ? oe.InnerException.InnerException.Message : oe.Message), oe.StackTrace);
            }

            return resultado;
        }

        public Transaccion<List<TEntity>> SeleccionaListado(System.Linq.Expressions.Expression<Func<TEntity, bool>> linq)
        {
            Transaccion<List<TEntity>> resultado = ManejoTransaccion<List<TEntity>>.Instancia.InicializarTransaccion(DLL);

            List<TEntity> executeList = null;
            
            try
            {
                executeList = EntitySet.Where(linq).ToList();

                if (executeList.Count > 0)
                    resultado = ManejoTransaccion<List<TEntity>>.Instancia.Resultado<List<TEntity>>(Estado.Correcto, resultado, executeList, SELECCIONALISTADOSINTOP);
                else
                    resultado = ManejoTransaccion<List<TEntity>>.Instancia.Resultado<List<TEntity>>(Estado.Alerta, resultado, executeList, SELECCIONALISTADOSINTOP);
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException oe)
            {
                executeList = null;
                resultado = ManejoTransaccion<List<TEntity>>.Instancia.Resultado<List<TEntity>>(Estado.Error, resultado, executeList, (oe.InnerException.InnerException.Message != string.Empty ? oe.InnerException.InnerException.Message : oe.Message), oe.StackTrace);
            }
            catch (Exception oe)
            {
                executeList = null;
                resultado = ManejoTransaccion<List<TEntity>>.Instancia.Resultado<List<TEntity>>(Estado.Error, resultado, executeList, (oe.InnerException.InnerException.Message != string.Empty ? oe.InnerException.InnerException.Message : oe.Message), oe.StackTrace);
            }

            return resultado;
        }

        public Transaccion<List<TEntity>> SeleccionaListado(System.Linq.Expressions.Expression<Func<TEntity, bool>> linq,
                                                         int top,
                                                         System.Linq.Expressions.Expression<Func<TEntity, int>> OrderBy)
        {
            Transaccion<List<TEntity>> resultado = ManejoTransaccion<List<TEntity>>.Instancia.InicializarTransaccion(DLL);

            List<TEntity> executeList = null;
            
            try
            {
                executeList = EntitySet.Where(linq).OrderBy(OrderBy).Take(top).ToList();

                if (executeList.Count > 0)
                    resultado = ManejoTransaccion<List<TEntity>>.Instancia.Resultado<List<TEntity>>(Estado.Correcto, resultado, executeList, SELECCIONARLISTADO);
                else
                    resultado = ManejoTransaccion<List<TEntity>>.Instancia.Resultado<List<TEntity>>(Estado.Alerta, resultado, executeList, SELECCIONARLISTADO);
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException oe)
            {
                executeList = null;
                resultado = ManejoTransaccion<List<TEntity>>.Instancia.Resultado<List<TEntity>>(Estado.Error, resultado, executeList, (oe.InnerException.InnerException.Message != string.Empty ? oe.InnerException.InnerException.Message : oe.Message), oe.StackTrace);
            }
            catch (Exception oe)
            {
                executeList = null;
                resultado = ManejoTransaccion<List<TEntity>>.Instancia.Resultado<List<TEntity>>(Estado.Error, resultado, executeList, (oe.InnerException.InnerException.Message != string.Empty ? oe.InnerException.InnerException.Message : oe.Message), oe.StackTrace);
            }

            return resultado;
        }
        #endregion

        #region [ Eventos]

        public void Dispose()
        {
            if (Contexto != null)
                Contexto.Dispose();
        }

        #endregion                
    }
}

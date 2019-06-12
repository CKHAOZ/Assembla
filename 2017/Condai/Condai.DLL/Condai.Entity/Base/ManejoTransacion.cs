using System;
using System.Xml.Linq;

namespace Condai.Entity
{
    public class ManejoTransaccion<TEntity>
    {
        #region [ Propiedades ]

        private static ManejoTransaccion<TEntity> obj = new ManejoTransaccion<TEntity>();

        #endregion

        #region [ Construcctor ]

        public static ManejoTransaccion<TEntity> Instancia
        {
            get { return obj; }
        }

        #endregion

        #region  [ Base ]

        public Transaccion<TEntity> InicializarTransaccion(string dll)
        {
            return (new Entity.Transaccion<TEntity>()
            {
                Dll = dll
            });
        }

        #endregion

        #region [ Metodos ]

        public Transaccion<T> Resultado<T>(Estado estado,
                                           Transaccion<T> transaccion,
                                           T dato,
                                           string mensaje)
        {
            return Resultado(estado, transaccion, 0, dato, mensaje, string.Empty);
        }

        public Transaccion<T> Resultado<T>(Estado estado,
                                          Transaccion<T> transaccion,
                                          T dato,
                                          string mensaje,
                                          string mensajeError)
        {
            return Resultado(estado, transaccion, 0, dato, mensaje, mensajeError);
        }

        public Transaccion<T> Resultado<T>(Estado estado,
                                           Transaccion<T> transaccion,
                                           int idTransaccion,
                                           T dato,
                                           string mensaje,
                                           string mensajeError)
        {
            return Resultado(estado, transaccion, transaccion.Dll, idTransaccion, dato, mensaje, mensajeError);
        }

        public Transaccion<T> Resultado<T>(Estado estado,
                                           Transaccion<T> transaccion,
                                           string dll,
                                           int idTransaccion,
                                           T dato,
                                           string mensaje,
                                           string mensajeError)
        {
            Func<object, Transaccion<T>> FuncionPersonalizada = oRes =>
            {
                return new Transaccion<T>
                {
                    Dll = dll,
                    IdTransaccion = idTransaccion,
                    Estado = estado,
                    Resultado = (int)estado,
                    Error = mensajeError,
                    Mensaje = mensaje,
                    Dato = (T)oRes
                };
            };

            return transaccion = FuncionPersonalizada(dato);
        }

        #endregion
    }
}
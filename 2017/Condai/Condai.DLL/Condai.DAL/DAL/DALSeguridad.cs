using Condai.Tools;
using System;
using System.Linq.Expressions;
using Condai.Entity;
using Condai.Entity.Seguridad;

namespace Condai.DAL
{
    public class DALSeguridad
    {
        #region [ Propiedades ]

        private static string Dll = "Condai.DAL.DALSeguridad";

        private static DALSeguridad obj = new DALSeguridad();

        public static DALSeguridad Instancia { get { return obj; } }

        #endregion

        #region [ Metodos ]

        public Transaccion<Seguridad_Usuario> ObtenerUsuario(string usuario)
        {
            Transaccion<Seguridad_Usuario> resultado = new Transaccion<Seguridad_Usuario>();

            RepositorioSeguridad<Seguridad_Usuario> contexto = new RepositorioSeguridad<Seguridad_Usuario>();

            Expression<Func<Seguridad_Usuario, bool>> linq = (i => i.usuUsuario.Equals(usuario, StringComparison.OrdinalIgnoreCase));

            resultado = contexto.SeleccionaObjeto(linq);

            contexto.Dispose();

            return resultado;
        }

        public Transaccion<Seguridad_Usuario> ObtenerUsuario(int usuId, string usuario)
        {
            Transaccion<Seguridad_Usuario> resultado = new Transaccion<Seguridad_Usuario>();

            RepositorioSeguridad<Seguridad_Usuario> contexto = new RepositorioSeguridad<Seguridad_Usuario>();

            Expression<Func<Seguridad_Usuario, bool>> linq = (i => i.usuId == usuId && i.usuUsuario.Equals(usuario));

            resultado = contexto.SeleccionaObjeto(linq);

            contexto.Dispose();

            return resultado;
        }

        public Transaccion<int> AgregarUsuario(Seguridad_Usuario usuario)
        {
            Transaccion<int> resultado = new Transaccion<int>();

            RepositorioSeguridad<Seguridad_Usuario> contexto = new RepositorioSeguridad<Seguridad_Usuario>();

            resultado = contexto.InsertarObjeto(usuario);

            contexto.Dispose();

            return resultado;
        }

        public Transaccion<bool> ActualizarUsuario(Seguridad_Usuario usuario)
        {
            Transaccion<bool> resultado = ManejoTransaccion<bool>.Instancia.InicializarTransaccion(Dll);

            Transaccion<Seguridad_Usuario> tr = ObtenerUsuario(usuario.usuId, usuario.usuUsuario);

            Seguridad_Usuario usuarioBD = new Seguridad_Usuario();

            if (tr.Estado == Estado.Correcto)
            {
                usuarioBD = (Seguridad_Usuario)tr.Dato;

                RepositorioSeguridad<Seguridad_Usuario> contexto = new RepositorioSeguridad<Seguridad_Usuario>();

                //Campos para hacer actualización
                if (usuarioBD != null)
                {
                    usuarioBD.usuDescripcion = usuario.usuDescripcion;
                    usuarioBD.usuNombre = usuario.usuNombre;
                    usuarioBD.usuApellido = usuario.usuApellido;
                    usuarioBD.usuCorreo = usuario.usuCorreo;
                    usuarioBD.usuTelefono = usuario.usuTelefono;
                }

                resultado = contexto.ActualizarObjeto(usuarioBD);

                contexto.Dispose();
            }
            else
                resultado = ManejoTransaccion<bool>.Instancia.Resultado<bool>(Estado.Error, resultado, false, "Error actualizando usuario");

            return resultado;
        }

        public Transaccion<bool> ActualizarContrasena(Seguridad_Usuario usuario)
        {
            Transaccion<bool> resultado = ManejoTransaccion<bool>.Instancia.InicializarTransaccion(Dll);

            RepositorioSeguridad<Seguridad_Usuario> contexto = new RepositorioSeguridad<Seguridad_Usuario>();

            resultado = contexto.ActualizarObjeto(usuario);

            contexto.Dispose();

            return resultado;
        }
        
        public Transaccion<bool> EliminarUsuario(Seguridad_Usuario usuario)
        {
            Transaccion<bool> resultado = ManejoTransaccion<bool>.Instancia.InicializarTransaccion(Dll);

            RepositorioSeguridad<Seguridad_Usuario> contexto = new RepositorioSeguridad<Seguridad_Usuario>();

            resultado = contexto.ActualizarObjeto(usuario);

            contexto.Dispose();

            return resultado;
        }

        #endregion
    }
}
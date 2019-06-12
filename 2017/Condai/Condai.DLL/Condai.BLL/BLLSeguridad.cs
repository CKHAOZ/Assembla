using Condai.Entity;
using Condai.Tools;
using Condai.Entity.Seguridad;

namespace Condai.BLL
{
    public class BLLSeguridad
    {
        #region [ Atributos ]

        private static string Dll = "Condai.BLL.BLLSeguridad";

        #endregion

        #region [ Propiedades ]
        
        private static BLLSeguridad obj = new BLLSeguridad();

        #endregion

        #region [ Construstor ]
        
        public static BLLSeguridad Instancia
        {
            get { return obj; }
        }

        #endregion

        #region [ Metodos ]
        
        public Transaccion<Seguridad_Usuario> ValidarUsuario(string usuario, string contrasena)
        {
            Transaccion<Seguridad_Usuario> resultado = ManejoTransaccion<Seguridad_Usuario>.Instancia.InicializarTransaccion(Dll);

            Transaccion<Seguridad_Usuario> tr = Condai.DAL.DALSeguridad.Instancia.ObtenerUsuario(usuario);

            if (tr.Estado == Entity.Estado.Correcto)
            {
                Seguridad_Usuario resultadoUsuario = (Seguridad_Usuario)tr.Dato;
                
                if (resultadoUsuario.usuClave.Equals(Condai.Tools.Seguridad.Cryptography.Instancia.Encriptar(contrasena)))
                {
                    resultadoUsuario.usuClave = string.Empty;
                    
                    resultado.Dato = resultadoUsuario;

                    resultado = ManejoTransaccion<Seguridad_Usuario>.Instancia.Resultado<Seguridad_Usuario>(Estado.Correcto, tr, resultadoUsuario.usuId, resultado.Dato, "Cargado", string.Empty);
                }
                else
                    resultado = ManejoTransaccion<Seguridad_Usuario>.Instancia.Resultado<Seguridad_Usuario>(Estado.Error, tr, null, "La contraseña es incorrecta");
            }
            else
                resultado = ManejoTransaccion<Seguridad_Usuario>.Instancia.Resultado<Seguridad_Usuario>(Estado.Error, tr, null, "El usuario no se encuentra");

            return resultado;
        }

        public Transaccion<int> AgregarUsuario(Seguridad_Usuario usuario)
        {
            Transaccion<int> resultado = ManejoTransaccion<int>.Instancia.InicializarTransaccion(Dll);

            Transaccion<int> tr = Condai.DAL.DALSeguridad.Instancia.AgregarUsuario(usuario);

            if (tr.Estado == Entity.Estado.Correcto && tr.IdTransaccion > 0)
            {
                resultado = ManejoTransaccion<int>.Instancia.Resultado<int>(Estado.Correcto, tr, tr.Dato, "Usuario creado");
            }
            else
                resultado = ManejoTransaccion<int>.Instancia.Resultado<int>(Estado.Correcto, tr, -2, "El usuario ya existe");

            return resultado;
        }

        public Transaccion<bool> ActualizarUsuario(Seguridad_Usuario usuario)
        {
            Transaccion<bool> resultado = ManejoTransaccion<bool>.Instancia.InicializarTransaccion(Dll);

            Transaccion<bool> tr = Condai.DAL.DALSeguridad.Instancia.ActualizarUsuario(usuario);

            if (tr.Estado == Entity.Estado.Correcto && tr.IdTransaccion > 0)
            {
                resultado = ManejoTransaccion<bool>.Instancia.Resultado<bool>(Estado.Correcto, resultado, tr.Dato, "Usuario actualizado");
            }
            else
                resultado = ManejoTransaccion<bool>.Instancia.Resultado<bool>(Estado.Error, resultado, false, "Error actualizando usuario");

            return resultado;
        }

        public Transaccion<Seguridad_Usuario> ActualizarContrasena(int idUsuario, string usuario, string contrasenaActual, string contrasenaNueva)
        {
            Transaccion<Seguridad_Usuario> resultado = ManejoTransaccion<Seguridad_Usuario>.Instancia.InicializarTransaccion(Dll);

            Transaccion<Seguridad_Usuario> trUsuario = Condai.DAL.DALSeguridad.Instancia.ObtenerUsuario(idUsuario, usuario);
            
            if (trUsuario.Estado == Estado.Correcto)
	        {
		        Seguridad_Usuario usuarioBD = (Seguridad_Usuario)trUsuario.Dato;
                if (usuarioBD != null)
                {
                    if (usuarioBD.usuClave.Equals(Tools.Seguridad.Cryptography.Instancia.Encriptar(contrasenaActual)))
                    {
                        //Campos para actualizar
                        usuarioBD.usuClave = Tools.Seguridad.Cryptography.Instancia.Encriptar(contrasenaNueva);

                        Transaccion<bool> tr = Condai.DAL.DALSeguridad.Instancia.ActualizarContrasena(usuarioBD);

                        if (tr.Estado == Entity.Estado.Correcto && tr.IdTransaccion > 0)
                        {
                            resultado = ManejoTransaccion<Seguridad_Usuario>.Instancia.Resultado<Seguridad_Usuario>(Estado.Correcto, resultado, usuarioBD, "Contraseña actualizada");
                        }
                        else
                            resultado = ManejoTransaccion<Seguridad_Usuario>.Instancia.Resultado<Seguridad_Usuario>(Estado.Error, resultado, null, "Error actualizando contraseña");
                    }
                    else
                        resultado = ManejoTransaccion<Seguridad_Usuario>.Instancia.Resultado<Seguridad_Usuario>(Estado.Error, resultado, null, "Clave incorrecta");
                }
                else
                    resultado = ManejoTransaccion<Seguridad_Usuario>.Instancia.Resultado<Seguridad_Usuario>(Estado.Error, resultado, null, "Usuario no existe");
	        }
            else
                resultado = ManejoTransaccion<Seguridad_Usuario>.Instancia.Resultado<Seguridad_Usuario>(Estado.Error, resultado, null, "Usuario no existe");

            return resultado;
        }

        public Transaccion<bool> EliminarUsuario(int idUsuario, string usuario)
        {
            Transaccion<bool> resultado = ManejoTransaccion<bool>.Instancia.InicializarTransaccion(Dll);

            Transaccion<Seguridad_Usuario> trUsuario = Condai.DAL.DALSeguridad.Instancia.ObtenerUsuario(idUsuario, usuario);

            if (trUsuario.Estado == Estado.Correcto)
            {
                Seguridad_Usuario usuarioBD = (Seguridad_Usuario)trUsuario.Dato;
                if (usuarioBD != null)
                {
                    //Campos para actualizar
                    usuarioBD.usuActivo = false;

                    Transaccion<bool> tr = Condai.DAL.DALSeguridad.Instancia.EliminarUsuario(usuarioBD);

                    if (tr.Estado == Entity.Estado.Correcto && tr.IdTransaccion > 0)
                        resultado = ManejoTransaccion<bool>.Instancia.Resultado<bool>(Estado.Correcto, resultado, true, "Usuario inhabilitado");
                    else
                        resultado = ManejoTransaccion<bool>.Instancia.Resultado<bool>(Estado.Error, resultado, false, "Error inhabilitando usuario");
                }
                else
                    resultado = ManejoTransaccion<bool>.Instancia.Resultado<bool>(Estado.Alerta, resultado, false, "Usuario no existe");
            }
            else
                resultado = ManejoTransaccion<bool>.Instancia.Resultado<bool>(Estado.Alerta, resultado, false, "Usuario no existe");

            return resultado;
        }
        
        #endregion
    }
}


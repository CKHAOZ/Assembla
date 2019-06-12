using Condai.Entity;
using Condai.Tools.Formato;
using System.ServiceModel;
using System.ServiceModel.Activation;
using Condai.Entity.Seguridad;

namespace Condai.Web.servicios.Aplicacion.Seguridad
{
    [ServiceContract(Namespace = "ServerCondai.Web")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Seguridad
    {   
        [OperationContract]
        public string ValidarUsuario(string usuario, string contrasena)
        {
            return Formato.Instancia.Serializar(Condai.BLL.BLLSeguridad.Instancia.ValidarUsuario(usuario, contrasena));
        }

        [OperationContract]
        public string ActualizarUsuario(string usuario)
        {
            Seguridad_Usuario usuarioActualizado = (Seguridad_Usuario)Formato.Instancia.Deserializar(usuario);

            return Formato.Instancia.Serializar(Condai.BLL.BLLSeguridad.Instancia.ActualizarUsuario(usuarioActualizado));
        }

        [OperationContract]
        public string ActualizarContrasena(int idUsuario, string usuario, string contrasenaActual, string contrasenaNueva)
        {
            return Formato.Instancia.Serializar(Condai.BLL.BLLSeguridad.Instancia.ActualizarContrasena(idUsuario, usuario, contrasenaActual, contrasenaNueva));
        }
    }
}

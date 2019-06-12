using Condai.Entity;
using Condai.Tools.Formato;
using System.ServiceModel;
using System.ServiceModel.Activation;
using Condai.Entity.Contacto;

namespace Condai.Web.Eventos.servicios.Aplicacion.Login
{
    [ServiceContract(Namespace = "ServerCondai.Web")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Login
    {
        [OperationContract]
        public string GuardarInquietud(string inquietud)
        {
            Contacto_Inquietud contactoInquietud = (Contacto_Inquietud)Formato.Instancia.Deserializar(inquietud);

            return Formato.Instancia.Serializar(Condai.BLL.BLLContacto.Instancia.AgregarContacto(contactoInquietud));
        }
    }
}

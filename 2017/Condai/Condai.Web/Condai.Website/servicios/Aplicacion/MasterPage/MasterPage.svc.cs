using Condai.Entity;
using Condai.Tools.Formato;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Activation;
using Condai.Entity.Base;

namespace Condai.Web.servicios.Aplicacion.MasterPage
{
    [ServiceContract(Namespace = "ServerCondai.Web")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class MasterPage
    {
        [OperationContract]
        public string ObtenerMenu()
        {
            Transaccion<List<Base_Menu>> tr = Condai.BLL.BLLBase.Instancia.ObtenerMenu(true);

            List<Base_Menu> listadoMenu = null;

            if (tr.Estado == Estado.Correcto)
                listadoMenu = tr.Dato;

            return Formato.Instancia.Serializar(listadoMenu);
        }
    }
}

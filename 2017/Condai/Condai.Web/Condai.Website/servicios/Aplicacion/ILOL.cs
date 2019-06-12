using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Condai.Web.servicios.Aplicacion
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ILOL" in both code and config file together.
    [ServiceContract]
    public interface ILOL
    {
        [OperationContract]
        void DoWork();
    }
}

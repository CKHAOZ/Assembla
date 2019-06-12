using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Condai.Entity;
using Condai.Entity.Base;

namespace Condai.Console
{
    public class TestingGeneral
    {
        public static void ObtenerMenu()
        {
            Transaccion<List<Base_Menu>> tr = Condai.BLL.BLLBase.Instancia.ObtenerMenu(true);
        }
    }
}

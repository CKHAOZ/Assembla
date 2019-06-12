using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Condai.Entity;
using Condai.Entity.Seguridad;

namespace Condai.Console
{
    public class TestingSeguridad
    {
        public static void ValidarUsuario()
        {
            Transaccion<Seguridad_Usuario> tr = Condai.BLL.BLLSeguridad.Instancia.ValidarUsuario("System", "condai*");
        }
    }
}

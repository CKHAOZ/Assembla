using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Condai.Console
{
    public class TestingAlmacenamiento
    {
        public static void ObtenerAdjuntoUrl()
        {
            Condai.Almacenamiento.Aws.Instancia.ObtenerRutaAdjunto();
        }

        public static void CargarArchivo()
        {
            Condai.Almacenamiento.Aws.Instancia.CargarArchivo(null,null,null);
        }
    }
}

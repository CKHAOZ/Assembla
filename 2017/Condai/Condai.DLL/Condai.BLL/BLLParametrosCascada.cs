using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Condai.BLL
{
    public class BLLParametrosCascada
    {
        #region [ Propiedades ]

        private static BLLParametrosCascada obj = new BLLParametrosCascada();

        #endregion

        #region [ Construstor ]

        public static BLLParametrosCascada Instancia
        {
            get { return obj; }
        }

        #endregion
    

    }
}

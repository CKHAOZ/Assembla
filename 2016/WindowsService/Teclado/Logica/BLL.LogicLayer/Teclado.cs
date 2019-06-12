using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.LogicLayer
{
    public class Teclado
    {
        #region [ Attributes ]

        private static Teclado obj = new Teclado();

        #endregion

        #region [ Propiedades ]

        public static Teclado Instance
        {
            get { return obj; }
        }

        #endregion

        #region [ Constructor ]

        public Teclado()
        {

        }

        #endregion

        #region [ Metodos ]

        public void IniciarTeclado()
        {
            Tools.Texto.Instance.EscribirMensaje("¿Esta funcionando el windows service?");
        }

        #endregion
    }
}

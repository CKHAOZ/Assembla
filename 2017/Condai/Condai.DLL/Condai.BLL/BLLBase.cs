using System;
using Condai.Entity;
using Condai.Entity.Base;
using System.Collections.Generic;

namespace Condai.BLL
{
    public class BLLBase
    {
        private static BLLBase obj = new BLLBase();

        public static BLLBase Instancia
        {
            get { return obj; }
        }

        public Transaccion<List<Base_Menu>> ObtenerMenu(bool estado)
        {
            return Condai.DAL.DALBase.Instancia.ObtenerMenu(estado);
        }
    }
}
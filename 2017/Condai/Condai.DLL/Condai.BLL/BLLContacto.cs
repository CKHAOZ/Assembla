using System;
using Condai.Entity;
using Condai.Entity.Contacto;

namespace Condai.BLL
{
    public class BLLContacto
    {
        private static BLLContacto obj = new BLLContacto();

        public static BLLContacto Instancia
        {
            get { return obj; }
        }

        public Transaccion<int> AgregarContacto(Contacto_Inquietud nuevoContacto)
        {
            nuevoContacto.FechaRegistro = DateTime.Now;

            return Condai.DAL.DALContacto.Instancia.AgregarContacto(nuevoContacto);
        }
    }
}


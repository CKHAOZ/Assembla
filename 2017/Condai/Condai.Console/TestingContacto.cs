using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Condai.Entity;
using Condai.Entity.Contacto;

namespace Condai.Console
{
    public class TestingContacto
    {
        public static void NuevoInquietud()
        {
            //Save inquietud

            Contacto_Inquietud inq = new Contacto_Inquietud()
            {
                Correo = "bcubillos@shc-colombia.com",
                Duda = "¿Donde Viven?",
                NombreApellido = "Bryan Alejandro Cubillos Prieto",
                Ocupacion = "Ingeniero de Sistemas",
                Pais = "Colombia",
                Telefono = 3202267864,
                FechaRegistro = DateTime.Now
            };

            Condai.BLL.BLLContacto.Instancia.AgregarContacto(inq);
        }
    }
}

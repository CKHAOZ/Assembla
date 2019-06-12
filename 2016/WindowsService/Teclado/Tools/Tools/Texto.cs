using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    public class Texto
    {
        #region [ Attributes ]

        private static Texto obj = new Texto();

        #endregion

        #region [ Propiedades ]

        private static string Documento { get; set; }

        public static Texto Instance
        {
            get { return obj; }
        }

        #endregion

        #region [ Constructor ]

        public Texto()
        {

        }

        #endregion

        #region [ Metodos ]
        
        public void EstablecerDocumentoActual()
        {
            Documento = string.Format("WriteLines_{0}-{1}-{2}.txt", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        }

        public string EstablecerRutaActual()
        {
            // Set a variable to the My Documents path.
            string ruta = string.Format(@"D:\WindowsService\Logs\");
            
            // Si el path no existe, lo creó.
            if (System.IO.Directory.Exists(ruta) == false)
                System.IO.Directory.CreateDirectory(ruta);
            
            return ruta;
        }

        public string AgregarHoraEjecucion(string msj)
        {
            string mensaje = string.Empty;

            mensaje = string.Format("{0}: {1}", DateTime.Now, msj);

            return mensaje;
        }

        public void EscribirMensaje(string mensaje)
        {
            // Establecer documento para escribir.
            if (Documento == null)
                Tools.Texto.Instance.EstablecerDocumentoActual();

            // Conozco la ruta actual 
            string ruta = EstablecerRutaActual();

            // Documento actual
            string doc = string.Concat(ruta, Documento);

            // Se agrega información adicional importante al mensaje:
            mensaje = AgregarHoraEjecucion(mensaje);

            // Si el documento existe Continuó escribiendo ahí.
            if (System.IO.File.Exists(doc))
            {
                using (StreamWriter outFile = new StreamWriter(doc, true))
                    outFile.WriteLine(mensaje);

            } // Write the string array to a new file named "WriteLines.txt".
            else {
                using (StreamWriter outputFile = new StreamWriter(doc))
                    outputFile.WriteLine(mensaje);
            }
        }

        #endregion
    }
}

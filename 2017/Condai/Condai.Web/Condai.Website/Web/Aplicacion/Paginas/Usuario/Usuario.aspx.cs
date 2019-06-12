using Condai.Almacenamiento;
using System;
using System.IO;

namespace Condai.Web.Web.Aplicacion.Paginas.Usuario
{
    public partial class Usuario : System.Web.UI.Page
    {
        #region [ Eventos ]
        
        protected void Page_Load(object sender, EventArgs e)
        {
            Aws.Instancia.ObtenerRutaAdjunto();
        }
        
        protected void btnSubirImagen_Click(object sender, EventArgs e)
        {
            if (fupImagenUsuario.HasFile)
            {
                MemoryStream data = new MemoryStream(fupImagenUsuario.FileBytes);
                string fileName = Path.GetFileName(fupImagenUsuario.PostedFile.FileName);

                BLL.BLLUsuarios.Instancia.CargarImagenUsuario(fileName, data);
            }
        }

        #endregion
    }
}
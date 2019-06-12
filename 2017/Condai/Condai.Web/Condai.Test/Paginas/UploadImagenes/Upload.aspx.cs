using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Condai.Web.Test.Paginas.UploadImagenes
{
    public partial class Upload : System.Web.UI.Page
    {
        protected System.Web.UI.HtmlControls.HtmlInputFile File1;

        protected System.Web.UI.HtmlControls.HtmlInputButton Submit1;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        override protected void OnInit(EventArgs e)
        {
            InitializeComponent();
            base.OnInit(e);
        }

        private void InitializeComponent()
        {
            this.Submit1.ServerClick += new System.EventHandler(this.Submit1_ServerClick);
            this.Load += new System.EventHandler(this.Page_Load);
        }

        private void Submit1_ServerClick(object sender, System.EventArgs e)
        {
            if ((File1.PostedFile != null) && (File1.PostedFile.ContentLength > 0))
            {
                string fn = System.IO.Path.GetFileName(File1.PostedFile.FileName);
                string SaveLocation = Server.MapPath("Data") + "\\" + fn;
                try
                {
                    File1.PostedFile.SaveAs(SaveLocation);
                    Response.Write("El archivo se ha cargado.");
                }
                catch (Exception ex)
                {
                    Response.Write("Error : " + ex.Message);
                    //Nota: Exception.Message devuelve un mensaje detallado que describe la excepción actual. 
                    //Por motivos de seguridad, no se recomienda devolver Exception.Message a los usuarios finales de 
                    //entornos de producción. Sería más aconsejable devolver un mensaje de error genérico. 
                }
            }
            else
            {
                Response.Write("Seleccione un archivo que cargar.");
            }
        }
    }
}
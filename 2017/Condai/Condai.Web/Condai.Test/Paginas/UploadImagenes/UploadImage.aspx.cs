using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Condai.Web.Test.Paginas.UploadImagenes
{
    public partial class UploadImage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCargarImagen_Click(object sender, EventArgs e)
        {
            

            System.IO.File.Copy(hdfRuta.Value, @"D:\a.png");
        }
    }
}
using System;
using System.IO;

namespace Condai.Web.Test.Paginas.UploadImagenes
{
    public partial class NetUploadImage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Upload(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                //string fileName = "test.txt";
                //string textToAdd = "Example text in file";

                //using (FileStream fs = new FileStream(fileName, FileMode.CreateNew))
                //{
                //    using (StreamWriter writer = new StreamWriter(fs))
                //    {
                //        writer.Write(textToAdd);
                //    }
                //}
                
                MemoryStream data = new MemoryStream(FileUpload1.FileBytes);

                ////File.WriteAllBytes(, data);

                ////FileStream fs = new FileStream()

                //Stream s = ;

                //MemoryStream d = new MemoryStream();
                ////d.WriteTo(s);

                //d.CopyTo(s)

                string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                Condai.Almacenamiento.Aws.Instancia.CargarArchivo(string.Empty, fileName, data);
                
                /*

                    object documento = FileUpload1.PostedFile.GetType();

                    
                    FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Images/") + fileName);
                    Response.Redirect(Request.Url.AbsoluteUri);

                */
            }
        }
    }
}
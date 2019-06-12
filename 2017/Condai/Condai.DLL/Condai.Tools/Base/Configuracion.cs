using System.Configuration;

namespace Condai.Tools
{
    public class Configuracion
    {
        #region [ Aws configuración para S3 ]
        
        public static string RegionAws
        {
            get { return ConfigurationManager.AppSettings["regionAws"]; }
        }

        public static string UsuarioAws
        {
            get { return ConfigurationManager.AppSettings["usuarioAws"]; }
        }

        public static string AccessKey
        {
            get { return ConfigurationManager.AppSettings["accessKey"]; }
        }

        public static string SecretKey
        {
            get { return ConfigurationManager.AppSettings["secretKey"]; }
        }

        #endregion
    }
}

using Condai.Entity;

namespace Condai.DAL
{
    public class DALLogin
    {
        private static DALLogin obj = new DALLogin();

        public static DALLogin Instance
        {
            get { return obj; }
        }

        public int AgregarInquietud(Login_Inquietud inquietudNuevo)
        {
            RepositorioLogin<Login_Inquietud> contexto = new RepositorioLogin<Login_Inquietud>();

            return contexto.InsertarObjeto(inquietudNuevo);
        }
    }
}

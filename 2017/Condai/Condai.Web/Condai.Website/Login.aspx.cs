using System;

namespace Condai.Web
{
    public partial class Login : System.Web.UI.Page
    {
        #region [ Propiedad ]

        private string Usuario
        {
            get
            {
                if (Session["CondaiUsuario"] != null)
                {
                    return Session["CondaiUsuario"].ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                if (value != null && value.ToString() != string.Empty)
                {
                    Session["CondaiUsuario"] = value.ToString();
                }
                else
                {
                    Session["CondaiUsuario"] = null;
                }
            }
        }

        #endregion

        #region [ Event ]

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GuardarUsuario_Click(object sender, EventArgs e)
        {
            Usuario = this.hdfUsuario.Value;
            Response.Redirect(@"~\Web\Aplicacion\Paginas\Condai\Condai.aspx");
        }

        #endregion
    }
}
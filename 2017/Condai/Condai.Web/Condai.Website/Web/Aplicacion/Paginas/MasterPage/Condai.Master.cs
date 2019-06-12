using System;

namespace Condai.Web.Web.MasterPage
{
    public partial class Condai : System.Web.UI.MasterPage
    {
        #region [ Propiedad ]

        private string Usuario {
            get {
                    if (Session["CondaiUsuario"] != null)
                    {
                        return Session["CondaiUsuario"].ToString();
                    }
                    else
                    {
                        return string.Empty;
                    }
                }
            set {
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
            if (Usuario == string.Empty)
            {
                Response.Redirect(@"~\Login.aspx");
            }
            else
            {
                this.hdfSeguridadUsuario.Value = Usuario;
            }
        }

        protected void GuardarUsuario_Click(object sender, EventArgs e)
        {
            Usuario = this.hdfUsuarioUP.Value;
            Response.Redirect(@"~\Web\Aplicacion\Paginas\Usuario\Usuario.aspx");
        }

        protected void lnkCerrarSesion_Click(object sender, EventArgs e)
        {
            //Elimino Sesion de Usuario Actual
            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();

            //Redirecciono a pagina de login.
            Response.Redirect(@"~\Login.aspx");
        }
                
        #endregion
    }
}
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using HarunaNet.Entities;
using HarunaNet.BusinessRules;

namespace HarunaNet.SisWeb
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, ImageClickEventArgs e)
        {
            string msgConfirmacao = string.Empty;

            Resultado resultado = new Resultado();
            Usuario u = new Usuario();

            UsuarioFacade UsuarioF = new UsuarioFacade();

            u.Login = tbLogin.Text;
            u.Senha = tbSenha.Text;

            resultado = UsuarioF.Autenticar(u, ref resultado);
            if (resultado.Sucesso)
            {
                Session.Add("USUARIO", u);
                Response.Redirect("Default.aspx");
            }
            else
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "ResultadoConfirmação", "alert('" + resultado.Mensagens[0].Descricoes[0].ToString() + "');", true);
            }

        }
    }
}
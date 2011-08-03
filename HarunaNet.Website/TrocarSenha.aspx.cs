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
using HarunaNet.Framework.Utils;

namespace HarunaNet.SisWeb
{
    public partial class trocarsenha : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string script = "$dvModalLoader.jqmHide();$dvDetTrocaSenha.jqmShow();";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "abre", script, true);
            }
           
            
        }

        protected void btnSalvarTrocaSenha_Click(object sender, EventArgs e)
        {
            Resultado resultado = new Resultado();
            UsuarioFacade usuarioFacade = new UsuarioFacade();
            string msg = "";
            string script = "";
            try
            {

                Usuario u = (Usuario)Session["USUARIO"];
                u.NovaSenha = txtSenhaNova1.Text;

                resultado = usuarioFacade.AlterarSenha(u);
                msg = resultado.Mensagens[0].Descricoes[0].ToString();

                script = Consts.JavaScript.Alert(Consts.Funcoes.Replacer4js(msg.ToString()), false);

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alerta", script, true);

                txtSenhaAtual.Text = "";
                txtSenhaNova1.Text = "";
                txtSenhaNova2.Text = "";

                script = "$dvDetTrocaSenha.jqmHide();";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "abre", script, true);

                }
            catch { }


        }

        protected void btnCancelarTrocaSenha_Click(object sender, EventArgs e)
        {
            Fechar();
        }

        protected void Fechar()
        {
            txtSenhaAtual.Text = "";
            txtSenhaNova1.Text = "";
            txtSenhaNova2.Text = "";
            string script = "$dvDetTrocaSenha.jqmHide();";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "abre", script, true);
            Response.Redirect("~/default.aspx");
        }
    }
}
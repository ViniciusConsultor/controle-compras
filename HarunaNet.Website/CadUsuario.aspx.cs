using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using HarunaNet.Entities;
using HarunaNet.BusinessRules;
using System.Collections.Generic;
using HarunaNet.Framework.Utils;

namespace HarunaNet.SisWeb
{
    public partial class CadUsuario : System.Web.UI.Page
    {
        UsuarioFacade usuarioFacade = new UsuarioFacade();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Populando o combo-box de Pesquisa de Perfil

                Resultado resultado = new Resultado();
                List<Modulo> oModulo = new List<Modulo>();

                ViewState.Add("CodigoPerfil", "0");
                ViewState.Add("UsuID", "0");

                List<Perfil> ListaPerfil = new PerfilFacade().Listar(ref resultado);
                //Populando o combo-box de Pesquisa de Perfil
                ddlPesqPerfilUsu.DataSource = ListaPerfil;
                ddlPesqPerfilUsu.DataValueField = "PerfilId";
                ddlPesqPerfilUsu.DataTextField = "Descricao";
                ddlPesqPerfilUsu.DataBind();
                ddlPesqPerfilUsu.Items.Insert(0, new ListItem("--TODOS--", "0"));

                //Populando o combo-box de seleção de perfil do cadastro de usuários
                ddlPerfilUsuario.DataSource = ListaPerfil;
                ddlPerfilUsuario.DataValueField = "PerfilId";
                ddlPerfilUsuario.DataTextField = "Descricao";
                ddlPerfilUsuario.DataBind();
                
                //Populando o combo-box de Àrea do usuários
                ddlArea.DataSource = new GrupoFacade().Listar(ref resultado);
                ddlArea.DataValueField = "ID";
                ddlArea.DataTextField = "Nome";
                ddlArea.DataBind();

            }
        }

        #region Cadastro de Usuários

        protected void btnInserirUsuario_Click(object sender, EventArgs e)
        {

            Resultado resultado = new Resultado();
            tbxCodigoUsuario.Text = "";
            tbxNomeUsuario.Text = "";
            tbxLoginUsuario.Text = "";
            tbxSenhaUsuario.Text = "";
            ddlPerfilUsuario.SelectedIndex = 0;
            ddlStatus.SelectedIndex = 0;
            ViewState["UsuID"] = "0";

            ddlPerfilUsuario.DataSource = new PerfilFacade().Listar(ref resultado);
            ddlPerfilUsuario.DataValueField = "PerfilId";
            ddlPerfilUsuario.DataTextField = "Descricao";
            ddlPerfilUsuario.DataBind();

            string script = "$dvModalLoader.jqmHide();$dvDetCadUsu.jqmShow();";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "abre", script, true);
        }

        protected void btnCancelarCadUsu_Click(object sender, EventArgs e)
        {
            Fechar();
        }

        protected void btnSalvarUsuario_Click(object sender, EventArgs e)
        {
            SalvarUsuario();
        }

        protected void btnPesquisarUsu_Click(object sender, EventArgs e)
        {
            PesquisarUsuario();
        }

        protected void btnEditarUsuario_Click(object sender, EventArgs e)
        {
            int key = Int32.Parse(gvPesqUsuarios.DataKeys[Int32.Parse((sender as ImageButton).CommandArgument)].Value.ToString());
            ExibirDadosUsuario(key);
        }

        protected void btnExcluirUsuario_Click(object sender, EventArgs e)
        {
            string msg = "";

            Resultado resultado = new Resultado();
            resultado = usuarioFacade.Excluir(Int32.Parse(gvPesqUsuarios.DataKeys[Int32.Parse((sender as ImageButton).CommandArgument)].Value.ToString()));
            if (resultado.Sucesso)
            {
                PesquisarUsuario();
            }
            string script = Consts.JavaScript.Alert(Consts.Funcoes.Replacer4js(msg), false);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alerta", script, true);
        }

        protected void gvPesqUsuarios_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType.Equals(DataControlRowType.DataRow))
            {
                (e.Row.FindControl("lbPerfil") as Label).Text = (e.Row.DataItem as Usuario).Perfil.Descricao;
                (e.Row.FindControl("btnEditarUsuario") as ImageButton).CommandArgument = e.Row.RowIndex.ToString();
                (e.Row.FindControl("btnExcluirUsuario") as ImageButton).CommandArgument = e.Row.RowIndex.ToString();
            }
        }

        private void SalvarUsuario()
        {
            string script = "";
            string msg = "";
            Resultado resultado = new Resultado();
            if (ViewState["UsuID"].ToString().Equals("0") && tbxSenhaUsuario.Text.Trim().Equals(""))
            {
                script = Consts.JavaScript.Alert(Consts.Funcoes.Replacer4js("O campo SENHA é obrigatório na inserção"), false);
            }
            else
            {
                Usuario oUsuarios = new Usuario();
                try
                {
                    oUsuarios.UsuarioId = Int32.Parse(ViewState["UsuID"].ToString());
                    oUsuarios.Nome = tbxNomeUsuario.Text;
                    oUsuarios.Email = txtemail.Text;
                    oUsuarios.Login = tbxLoginUsuario.Text;
                    oUsuarios.PerfilId = Int32.Parse(ddlPerfilUsuario.SelectedValue);
                    oUsuarios.Area.ID = Int32.Parse(ddlArea.SelectedValue);
                    oUsuarios.Status = ddlStatus.SelectedValue;
                    oUsuarios.Senha = tbxSenhaUsuario.Text.Trim() == "" ? null : tbxSenhaUsuario.Text.Trim();

                    if (ViewState["UsuID"].ToString().Equals("0"))
                    {
                        resultado = usuarioFacade.Inserir(oUsuarios);
                        msg = "Usuário Cadastrado com Sucesso!";
                        if (resultado.Sucesso)
                        {
                            LiparCampos();
                            PesquisarUsuario();
                        }
                    }
                    else
                    {
                        resultado = usuarioFacade.Alterar(oUsuarios);
                        msg = resultado.Mensagens[0].Descricoes[0].ToString();
                    }

                    if (resultado.Sucesso)
                    {
                        LiparCampos();
                        PesquisarUsuario();
                    }
                    script = Consts.JavaScript.Alert(Consts.Funcoes.Replacer4js(msg.ToString()), false);
                }
                finally
                {
                    Fechar();
                }
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alerta", script, true);
        }

        private void ExibirDadosUsuario(int pUID)
        {
            Usuario oUsuario = new Usuario();
            try
            {
                oUsuario = usuarioFacade.GetByID(pUID);
                //oTUsuarios.SetByID();
                tbxCodigoUsuario.Text = oUsuario.UsuarioId.ToString();
                tbxNomeUsuario.Text = oUsuario.Nome.ToString();
                tbxLoginUsuario.Text = oUsuario.Login.ToString();
                txtemail.Text = oUsuario.Email.ToString();
                ddlPerfilUsuario.SelectedValue = oUsuario.Perfil.PerfilId.ToString();
                ddlStatus.SelectedValue = oUsuario.Status.ToString();
                ViewState["UsuID"] = oUsuario.UsuarioId.ToString();
                tbxSenhaUsuario.Text = "";
                string script = "$dvModalLoader.jqmHide();$dvDetCadUsu.jqmShow();";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "abre", script, true);
            }
            finally
            {
                //oUsuario.Dispose();
            }
        }

        private void PesquisarUsuario()
        {
            Resultado resultado = new Resultado();
            gvPesqUsuarios.DataSource = new UsuarioFacade().Listar(tbxPesqNomeUsu.Text.Trim().ToUpper(), ref resultado);
            gvPesqUsuarios.DataKeyNames = new string[1] { "UsuarioId" };
            gvPesqUsuarios.DataBind();
        }

        private void LiparCampos()
        {
            txtemail.Text = "";
            tbxNomeUsuario.Text = "";
            tbxLoginUsuario.Text = "";
            tbxSenhaUsuario.Text = "";
        }
        
        protected void btn_Voltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx", false);
        }
        
        private void Fechar()
        {
            ViewState["UsuID"] = "0";
            LiparCampos();
            string script = "$dvDetCadUsu.jqmHide();";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "abre", script, true);
        }
        #endregion
    }
}
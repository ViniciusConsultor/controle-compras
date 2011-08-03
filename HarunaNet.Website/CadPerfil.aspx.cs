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
using System.Collections.Generic;
using HarunaNet.Framework.Utils;
namespace HarunaNet.SisWeb
{
    public partial class CadPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState.Add("CodigoPerfil", "0");



            }
        }

        protected void gvCadPerfil_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex > -1)
            {
                (e.Row.FindControl("btnEditarPerfil") as ImageButton).CommandArgument = e.Row.RowIndex.ToString();
                (e.Row.FindControl("btnExcluirPerfil") as ImageButton).CommandArgument = e.Row.RowIndex.ToString();
            }
        }

        protected void gvModulosPerfil_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex > -1)
            {
                (e.Row.FindControl("chkPermissaoModulo") as CheckBox).Checked = (e.Row.DataItem as Modulo).PodeAcessar.Equals(1);
            }
        }

        private void SalvarDadosPerfil()
        {
            Perfil oPerfil = new Perfil();
            PerfilFacade oPerfilFacade = new PerfilFacade();
            Resultado resultado = new Resultado();
            String oMenssagem = string.Empty;
            bool ok = false;
            string script = "";
            try
            {
                oPerfil.PerfilId = tbxCodigoPerfil.Text.Equals("") ? 0 : Int32.Parse(tbxCodigoPerfil.Text);
                oPerfil.Descricao = tbxDescricaoPerfil.Text;


                oPerfil.Modulos = new ModuloFacade().Listar(ref resultado);

                //Atribui os valores selecionados no gridview nos módulos que pode acessar
                foreach (GridViewRow r in gvModulosPerfil.Rows)
                {
                    if (r.RowType.Equals(DataControlRowType.DataRow))
                    {
                        oPerfil.Modulos[r.RowIndex].PodeAcessar = (r.FindControl("chkPermissaoModulo") as CheckBox).Checked ? 1 : 0;
                    }
                }

                //resultado = oPerfilFacade.Inserir(oPerfil);
                resultado = (ViewState["CodigoPerfil"].ToString().Equals("0") ? oPerfilFacade.Inserir(oPerfil) : oPerfilFacade.Atualizar(oPerfil));
                if (resultado.Sucesso)
                {
                    oMenssagem = ViewState["CodigoPerfil"].ToString().Equals("0") ? "Perfil Cadastrado com Sucesso!" : "Perfil Alterado com Sucesso!";
                    ViewState["CodigoPerfil"] = oPerfil.PerfilId.ToString();
                    tbxCodigoPerfil.Text = oPerfil.PerfilId.ToString();
                    PesquisarPerfil();
                    
                }
                script = Consts.JavaScript.Alert(Consts.Funcoes.Replacer4js(oMenssagem), false);
            }
            finally
            {
                Fechar();
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alerta", script, true);
        }

        private void ExibirDadosPerfil(string pID)
        {
            Perfil oTUsrPerfil = new Perfil();
            Resultado resultado = new Resultado();
            try
            {
                oTUsrPerfil = new PerfilFacade().Seleciona(Convert.ToInt32(pID), ref resultado);
                tbxCodigoPerfil.Text = oTUsrPerfil.PerfilId.ToString();
                tbxDescricaoPerfil.Text = oTUsrPerfil.Descricao.ToString();
                ViewState["CodigoPerfil"] = oTUsrPerfil.PerfilId.ToString();

                //Grid de módulos com acesso
                gvModulosPerfil.DataSource = oTUsrPerfil.Modulos;
                gvModulosPerfil.DataKeyNames = new string[1] { "ModuloID" };
                gvModulosPerfil.DataBind();

                string script = "$dvModalLoader.jqmHide();$dvDetCadPerfil.jqmShow();";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "abre", script, true);
            }
            finally
            {
                // oTUsrPerfil.Dispose();
            }
        }

        private void PesquisarPerfil()
        {
            Resultado resultado = new Resultado();
            gvCadPerfil.DataSource = new PerfilFacade().Listar(ref resultado);// .ListarPerfis(tbxPesquisaDescPerfil.Text.ToUpper());
            gvCadPerfil.DataKeyNames = new string[1] { "PerfilId" };
            gvCadPerfil.DataBind();
        }

        protected void btnInserirPerfil_Click(object sender, EventArgs e)
        {
            tbxCodigoPerfil.Text = "";
            tbxDescricaoPerfil.Text = "";
            ViewState["CodigoPerfil"] = "0";
            Resultado resultado = new Resultado();
            //Grid de módulos com acesso
            List<Modulo> oModulo = new ModuloFacade().Listar(ref resultado);
            
            gvModulosPerfil.DataSource = oModulo;
            gvModulosPerfil.DataKeyNames = new string[1] { "ModuloID" };
            gvModulosPerfil.DataBind();


            string script = "$dvModalLoader.jqmHide();$dvDetCadPerfil.jqmShow();";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "abre", script, true);
        }

        protected void btnSalvarPerfil_Click(object sender, EventArgs e)
        {
            SalvarDadosPerfil();
        }

        protected void btnCancelarCadPerfil_Click(object sender, EventArgs e)
        {
            Fechar();
        }

        protected void btnPesquisarPerfil_Click(object sender, EventArgs e)
        {
            PesquisarPerfil();
        }

        protected void btnEditarPerfil_Click(object sender, EventArgs e)
        {
            string id = gvCadPerfil.DataKeys[Int32.Parse((sender as ImageButton).CommandArgument)].Value.ToString();
            ExibirDadosPerfil(id);
        }

        protected void btnExcluirPerfil_Click(object sender, EventArgs e)
        {
            string msg = "";
            //if (TPerfilUsuario.Excluir(Int32.Parse(gvCadPerfil.DataKeys[Int32.Parse((sender as Button).CommandArgument)].Value.ToString()), out msg))
            //{
            //    PesquisarPerfil();
            //}
            string script = Consts.JavaScript.Alert(Consts.Funcoes.Replacer4js(msg), false);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alerta", script, true);
        }

        protected void btn_Voltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx", false);
        }

        protected void Fechar()
        {
            ViewState["CodigoPerfil"] = "0";
            string script = "$dvDetCadPerfil.jqmHide();";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "abre", script, true);
        }
    }
}
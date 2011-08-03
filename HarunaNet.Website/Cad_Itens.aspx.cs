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
    public partial class Cad_Itens : PaginaBase
    {

        #region Eventos

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState.Add("CodigoItem", "0");

                Resultado resultado = new Resultado();

                ddlCategoria.DataSource = new CategoriaFacade().Listar(ref resultado);
                ddlCategoria.DataValueField = "CategoriaID";
                ddlCategoria.DataTextField = "Nome";
                ddlCategoria.DataBind();

                ddlCategoria.Items.Insert(0, new ListItem(" --Selecione uma categoria-- ", "0"));
            }
        }

        protected void btnPesquisarItem_Click(object sender, ImageClickEventArgs e)
        {

            ListaItens();

        }

        protected void btnExcluir_Click(object sender, ImageClickEventArgs e)
        {
            Resultado resultado = new Resultado();

            Item oItem = new Item();
            oItem.ItemID = Int32.Parse(gvCaditens.DataKeys[Int32.Parse((sender as ImageButton).CommandArgument)].Value.ToString());
            oItem.Status = 2;

            string msg = "";
            resultado = new ItemFacade().Excluir(oItem);
            if (resultado.Sucesso)
            {
                ListaItens();
                msg = "Item excluído com sucesso!";
            }
            else
                msg = "Erro ao excluído item!";

            string script = Consts.JavaScript.Alert(Consts.Funcoes.Replacer4js(msg), false);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alerta", script, true);
        }

        protected void btnInserirItem_Click(object sender, ImageClickEventArgs e)
        {

            if (Convert.ToInt32(ddlCategoria.SelectedValue) > 0)
            {
                ViewState["CodigoItem"] = "0";
                Resultado resultado = new Resultado();

                lbl_CategoriaDesc.Text = ddlCategoria.SelectedItem.ToString();

                string script = "$dvModalLoader.jqmHide();$dvDetCadItens.jqmShow();";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "abre", script, true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "CadastroItens", "alert('Selecione uma Categoria para inserir um novo intem!');", true);
            }

        }

        protected void btnCancelarCadItem_Click(object sender, EventArgs e)
        {
            Fechar();
        }

        protected void btnSalvarItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (ViewState["CodigoItem"].ToString() != "0" )
                {
                    Resultado resultado = new Resultado();

                    Item oItem = new Item();
                    oItem.ItemID = Convert.ToInt32(ViewState["CodigoItem"].ToString());
                    oItem.Nome = tbxDescricaoItem.Text;

                    string msg = "";
                    resultado = new ItemFacade().Atualiza(oItem);
                    if (resultado.Sucesso)
                    {
                        ListaItens();
                        msg = "Item Alterado com sucesso!";
                    }
                    else
                        msg = "Erro ao alterar o item!";

                    string script = Consts.JavaScript.Alert(Consts.Funcoes.Replacer4js(msg), false);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alerta", script, true);
                }
                else
                    SalvarDadosItens();
            }
            finally
            {
                Fechar();
            }
        }

        #endregion

        //-----------------------------------------------------------------------

        #region Métodos

        private void Fechar()
        {
            ViewState["CodigoItem"] = "0";
            string script = "$dvDetCadItens.jqmHide();";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "fecha", script, true);
        }

        private void SalvarDadosItens()
        {
            Item oItem = new Item();
            Resultado resultado = new Resultado();
            String oMenssagem = string.Empty;

            string script = "";

            try
            {
                oItem.Nome = tbxDescricaoItem.Text;
                oItem.Categoria = new Categoria();
                oItem.Categoria.CategoriaID = Convert.ToInt32(ddlCategoria.SelectedValue);

                resultado = new ItemFacade().Inserir(oItem);

                if (resultado.Sucesso)
                {
                    oMenssagem = "Item Cadastrado com Sucesso!";
                    ViewState["CodigoItem"] = resultado.Id.ToString();
                    ListaItens();

                }
                script = Consts.JavaScript.Alert(Consts.Funcoes.Replacer4js(oMenssagem), false);
            }
            finally
            {
                Fechar();
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alerta", script, true);
        }

        private void ListaItens()
        {
            Resultado resultado = new Resultado();

            gvCaditens.DataSource = new ItemFacade().Listar(Convert.ToInt32(ddlCategoria.SelectedValue), ref resultado);
            gvCaditens.DataKeyNames = new string[1] { "ItemID" };
            gvCaditens.DataBind();
        }

        #endregion

        protected void gvCaditens_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType.Equals(DataControlRowType.DataRow))
            {
                (e.Row.FindControl("btnEditarItem") as ImageButton).CommandArgument = e.Row.RowIndex.ToString();
                (e.Row.FindControl("btnExcluir") as ImageButton).CommandArgument = e.Row.RowIndex.ToString();
            }
        }

        private void ExibirDadosItem(string pID)
        {
            Item oItem = new Item();
            Resultado resultado = new Resultado();
            try
            {
                oItem = new ItemFacade().Seleciona(Convert.ToInt32(pID), ref resultado);
                tbxDescricaoItem.Text = oItem.Nome.ToString();
                lbl_CategoriaDesc.Text = oItem.Categoria.Nome;
                ViewState["CodigoItem"] = oItem.ItemID.ToString();


                string script = "$dvModalLoader.jqmHide();$dvDetCadItens.jqmShow();";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "abre", script, true);
            }
            finally
            {
                // oTUsrPerfil.Dispose();
            }
        }

        protected void btnEditarItem_Click(object sender, ImageClickEventArgs e)
        {
            ViewState["CodigoItem"] = gvCaditens.DataKeys[Int32.Parse((sender as ImageButton).CommandArgument)].Value.ToString();
            string id = ViewState["CodigoItem"].ToString();
            ExibirDadosItem(id);
        }
    }
}
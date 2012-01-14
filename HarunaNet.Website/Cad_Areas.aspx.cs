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
    public partial class Cad_Areas : PaginaBase
    {

        #region Eventos

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PreencheGrid();
            }
        }

        protected void btnPesquisarItem_Click(object sender, ImageClickEventArgs e)
        {

          

        }

        protected void btnExcluir_Click(object sender, ImageClickEventArgs e)
        {
           
        }

        protected void btnInserirItem_Click(object sender, ImageClickEventArgs e)
        {

            if (String.IsNullOrEmpty(txtArea.Text))
            {
            }
            else
            {
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
                //if (ViewState["CodigoItem"].ToString() != "0" )
                //{
                //    Resultado resultado = new Resultado();

                //    Item oItem = new Item();
                //    oItem.ItemID = Convert.ToInt32(ViewState["CodigoItem"].ToString());
                //    oItem.Nome = tbxDescricaoItem.Text;

                //    string msg = "";
                //    resultado = new ItemFacade().Atualiza(oItem);
                //    if (resultado.Sucesso)
                //    {
                //        ListaItens();
                //        msg = "Item Alterado com sucesso!";
                //    }
                //    else
                //        msg = "Erro ao alterar o item!";

                //    string script = Consts.JavaScript.Alert(Consts.Funcoes.Replacer4js(msg), false);
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alerta", script, true);
                //}
                //else
                //    SalvarDadosItens();
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
                
                script = Consts.JavaScript.Alert(Consts.Funcoes.Replacer4js(oMenssagem), false);
            }
            finally
            {
                Fechar();
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alerta", script, true);
        }

        private void PreencheGrid()
        {
            Resultado resultado = new Resultado();

            gvCadAreas.DataSource = new GrupoFacade().Listar(ref resultado); //ItemFacade().Listar(Convert.ToInt32(ddlCategoria.SelectedValue), ref resultado);
            gvCadAreas.DataKeyNames = new string[1] { "Id" };
            gvCadAreas.DataBind();
        }

        #endregion

        protected void gvCadAreas_RowDataBound(object sender, GridViewRowEventArgs e)
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

            }
            finally
            {
                // oTUsrPerfil.Dispose();
            }
        }

        protected void btnEditarItem_Click(object sender, ImageClickEventArgs e)
        {
            ViewState["CodigoItem"] = gvCadAreas.DataKeys[Int32.Parse((sender as ImageButton).CommandArgument)].Value.ToString();
            string id = ViewState["CodigoItem"].ToString();
            ExibirDadosItem(id);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

using HarunaNet.BusinessRules;
using HarunaNet.Entities;

namespace HarunaNet.SisWeb
{
    public partial class PedidosLista : PaginaBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                Resultado resultado = new Resultado();
                Ped_ItemFacade oPedFacade = new Ped_ItemFacade();
                List<Compras> oPedCompras = new List<Compras>();
                oPedCompras = oPedFacade.Listar(ref resultado);

                if (resultado.Sucesso)
                {
                    ListaGridPersistida = oPedCompras;
                    gvListaPed.DataSource = (List<Compras>)ListaGridPersistida;
                    gvListaPed.DataBind();
                }
                else
                {
                    lblMensagem.Text = resultado.Mensagens[0].Descricoes[0].ToString();
                    lblMensagem.Visible = true;
                }

            }
        }

        protected void grdOnda_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //    try
            //    {
            //        if (e.Row.RowType == DataControlRowType.DataRow)
            //        {
            //            ImageButton imgEditar = (ImageButton)e.Row.Cells[4].FindControl("imgEditar");
            //            imgEditar.CommandArgument = e.Row.RowIndex.ToString();
            //            ScriptManager1.RegisterPostBackControl(imgEditar);

            //            ImageButton imgExcluir = (ImageButton)e.Row.Cells[4].FindControl("imgExcluir");
            //            imgExcluir.CommandArgument = e.Row.RowIndex.ToString();
            //            imgExcluir.OnClientClick = "javascript:return confirmaAtualizacao('" + e.Row.Cells[1].Text + "')";

            //            //Controle de Acesso
            //            switch (((MasterPadrao)Master).maiorAcesso)
            //            {
            //                case TipoAcessoEnum.ControleTotal:
            //                    imgEditar.ImageUrl = "~/library/img/ic_editar.gif";
            //                    imgEditar.AlternateText = "Editar";
            //                    break;
            //                default:
            //                    imgEditar.ImageUrl = "~/library/img/ic_consultar.gif";
            //                    imgEditar.AlternateText = "Consultar";

            //                    imgExcluir.Visible = false;
            //                    break;
            //            }
            //        }
            //    }
            //    catch
            //    {
            //        Response.Redirect("~/sessaoExpirada.aspx", true);
            //    }
        }

        protected void grdOnda_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //switch (e.CommandName)
            //{
            //    case "Excluir":
            //        idOnda = Convert.ToInt32(grdOnda.DataKeys[Convert.ToInt32(e.CommandArgument)][0]);
            //        ExcluirOnda();
            //        break;
            //    case "Editar":
            //        idOnda = Convert.ToInt32(grdOnda.DataKeys[Convert.ToInt32(e.CommandArgument)][0]);
            //        EditarOnda();
            //        break;
            //} 
        }

        protected void grdOnda_Sorting(object sender, GridViewSortEventArgs e)
        {
            //if (sortExpression != e.SortExpression)
            //{
            //    sortDirection = 1; //ASC
            //}
            //else
            //{
            //    sortDirection *= -1; //DESC
            //}

            //sortExpression = e.SortExpression;
            //PreencheGrid();
        }

        protected void gvListaPed_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvListaPed.PageIndex = e.NewPageIndex;
            gvListaPed.DataSource = (List<Compras>)ListaGridPersistida;
            gvListaPed.DataBind();
        }

        protected void lnkPesquisar_Click(object sender, EventArgs e)
        {
            //grdOnda.PageIndex = 0;
            //PreencheGrid();
            //ScriptManager.RegisterStartupScript(UpdatePanel1, typeof(string), "pesquisaFiltro", "ExibirPesquisa();", true);
        }

        protected void btn_Voltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx", false);
        }

    }
}
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

using HarunaNet.BusinessRules;
using HarunaNet.Entities;

namespace HarunaNet.SisWeb
{
    public partial class AprovacaoItem : PaginaBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                Resultado resultado = new Resultado();
                PedidoFacade oAprovacaoFacade = new PedidoFacade();

                List<Aprovacao> oAprovacao = new List<Aprovacao>();
                oAprovacao = oAprovacaoFacade.ListaAprovacao(ref resultado);

                if (resultado.Sucesso)
                {
                    ListaGridPersistida = oAprovacao;
                    gvListaAprov.DataSource = (List<Aprovacao>)ListaGridPersistida;
                    gvListaAprov.DataBind();
                }

            }
        }

        protected void gvListaAprov_Sorting(object sender, GridViewSortEventArgs e)
        {

        }

        protected void gvListaAprov_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex > -1)
            {
                (e.Row.FindControl("btnAprovar") as ImageButton).CommandArgument = e.Row.RowIndex.ToString();
                (e.Row.FindControl("btnReprovar") as ImageButton).CommandArgument = e.Row.RowIndex.ToString();
            }
        }

        protected void gvListaAprov_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void gvListaAprov_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvListaAprov.PageIndex = e.NewPageIndex;
            gvListaAprov.DataSource = (List<Aprovacao>)ListaGridPersistida;
            gvListaAprov.DataBind();//s PreencherGrid();
        }

        protected void btnAprovar_Click(object sender, EventArgs e)
        {

            Resultado resultado = new Resultado();
            PedidoFacade oAprovacaoFacade = new PedidoFacade();
            resultado = new PedidoFacade().Aprovar(Convert.ToInt32(gvListaAprov.DataKeys[Int32.Parse((sender as ImageButton).CommandArgument)].Value.ToString()));

            if (resultado.Sucesso)
            {

                List<Aprovacao> oAprovacao = new List<Aprovacao>();
                oAprovacao = oAprovacaoFacade.ListaAprovacao(ref resultado);

                ListaGridPersistida = oAprovacao;
                gvListaAprov.DataSource = (List<Aprovacao>)ListaGridPersistida;
                gvListaAprov.DataBind();

            }
        }

        protected void btnReprovar_Click(object sender, EventArgs e)
        {

            Resultado resultado = new Resultado();
            PedidoFacade oAprovacaoFacade = new PedidoFacade();
            resultado = new PedidoFacade().Cancelar(Convert.ToInt32(gvListaAprov.DataKeys[Int32.Parse((sender as ImageButton).CommandArgument)].Value.ToString()));
           
            if (resultado.Sucesso)
            {

                List<Aprovacao> oAprovacao = new List<Aprovacao>();
                oAprovacao = oAprovacaoFacade.ListaAprovacao(ref resultado);

                ListaGridPersistida = oAprovacao;
                gvListaAprov.DataSource = (List<Aprovacao>)ListaGridPersistida;
                gvListaAprov.DataBind();

            }
        }

        protected void btn_Voltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx", false);
        }
    }
}
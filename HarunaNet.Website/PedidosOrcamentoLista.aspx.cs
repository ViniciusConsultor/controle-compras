using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

using HarunaNet.BusinessRules;
using HarunaNet.Entities;

namespace HarunaNet.SisWeb
{
    public partial class PedidosOrcamentoLista : PaginaBase
    {

        public int IdPedidoOrcamento
        {
            get { return Convert.ToInt32(ViewState["IdPedidoOrcamento"]); }
            set { ViewState["IdPedidoOrcamento"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Resultado resultado = new Resultado();

                List<PedidosOrcamentos> ListaPedidosOrcamento = new PedOrcamentoFacade().Listar(ref resultado);

                if (resultado.Sucesso)
                {
                    gvListaPed.DataSource = ListaGridPersistida = ListaPedidosOrcamento;
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
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Button btnCotar = (Button)e.Row.FindControl("btnCotar");

                if (!(btnCotar == null))
                {
                    ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnCotar);
                    btnCotar.CommandArgument = e.Row.RowIndex.ToString();

                }
            }
        }

        protected void grdOnda_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Cotar")
            {
                this.IdPedidoOrcamento = Convert.ToInt32(gvListaPed.DataKeys[Convert.ToInt32(e.CommandArgument.ToString())]["Cod_PedidosOrcamentos"].ToString());
                Server.Transfer("PedidosOrcamentoEdit.aspx", false);

            }
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
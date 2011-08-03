using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HarunaNet.Entities;
using HarunaNet.BusinessRules;

namespace HarunaNet.SisWeb
{
    public partial class MeusPedidosItens : PaginaBase
    {

        public int IdPedido
        {
            get { return Convert.ToInt32(ViewState["IdPedido"]); }
            set { ViewState["IdPedido"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Context.Handler is meuspedidos)
                {
                    Resultado resultado = new Resultado();
                    IdPedido = ((meuspedidos)Context.Handler).IdPedido;
                }

                lblTitulo.Text = "Lista de itens do Pedido de Número: " + IdPedido.ToString();

                ListaGridPersistida = GetDados();
                gvListaPed.DataSource = (List<Ped_Item>)ListaGridPersistida;
                gvListaPed.DataBind();
            }
        }

        public List<Ped_Item> GetDados()
        {

            Resultado resultado = new Resultado();
            Ped_ItemFacade oPedFacade = new Ped_ItemFacade();
            List<Ped_Item> oPedidosListaItem = new List<Ped_Item>();

            oPedidosListaItem = oPedFacade.ListaItensByNumPed(IdPedido, ref resultado);

            return oPedidosListaItem;
        }

        protected void btn_Voltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("meuspedidos.aspx", false);
        }

        protected void gvListaPed_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Label olblStatus = (Label)e.Row.Cells[2].FindControl("lblStatusItem");

                switch (Convert.ToInt32(olblStatus.Text))
                {

                    case 1:
                        olblStatus.Text = StatusItemPedido.Em_Aberto.ToString();
                        break;
                    case 2:
                        olblStatus.Text = StatusItemPedido.Em_Andamento.ToString();
                        break;
                    case 3:
                        olblStatus.Text = StatusItemPedido.Aguardando_Entrega.ToString();
                        break;
                    case 4:
                        olblStatus.Text = StatusItemPedido.Finalizado.ToString();
                        break;
                    case 5:
                        olblStatus.Text = StatusItemPedido.Indisponível.ToString();
                        break;
                    case 6:
                        olblStatus.Text = StatusItemPedido.Cancelado.ToString();
                        break;
                }



            }
        }

        protected void gvListaPed_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvListaPed.PageIndex = e.NewPageIndex;
            gvListaPed.DataSource = (List<Ped_Item>)ListaGridPersistida;
            gvListaPed.DataBind();
        }

       

    }
}
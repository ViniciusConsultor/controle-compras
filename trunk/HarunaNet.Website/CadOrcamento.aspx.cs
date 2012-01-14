using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using HarunaNet.Framework.Utils;
using HarunaNet.BusinessRules;
using HarunaNet.Entities;
using System.Text;
namespace HarunaNet.SisWeb
{
    public partial class CadOrcamento : PaginaBase
    {
        #region Atributos e Propriedades
        protected Ped_ItemFacade oPedItemFacade = new Ped_ItemFacade();
        protected PedidoFacade oPedidoFacade = new PedidoFacade();

        public int idPedido
        {
            get { return ViewState["idPedido"] == null ? int.MinValue : Convert.ToInt32(ViewState["idPedido"]); }
            set { ViewState["idPedido"] = value; }
        }
        #endregion

        #region Eventos

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                CarregaCombos();
                if (((Usuario)Session["USUARIO"]).Perfil.PerfilId != 3)
                {
                    trArea.Visible = true;
                }
            }
        }

        protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlItem.Enabled = true;
            Resultado resultado = new Resultado();

            ddlItem.DataSource = new ItemFacade().Listar(Convert.ToInt32(ddlCategoria.SelectedValue), ref resultado);
            ddlItem.DataValueField = "ItemID";
            ddlItem.DataTextField = "Nome";
            ddlItem.DataBind();

            ddlItem.Items.Insert(0, new ListItem(" --Selecione um item-- ", "0"));


            for (int i = 0; i < ddlItem.Items.Count; i++)
            {
                ddlItem.Items[i].Attributes.Add("title", ddlItem.Items[i].Text);
            }

        }

        protected void btnAddItem_Click(object sender, ImageClickEventArgs e)
        {
            if (Page.IsValid)
            {
                if (ddlItem.SelectedIndex > 0)
                {
                    Resultado resultado = new Resultado();
                    List<PedidosOrcamentos> ListaOrcamento = null;

                    PedidosOrcamentos ItemOrcamento = new PedidosOrcamentos();

                    if (ListaGridPersistida != null)
                    {
                        ListaOrcamento = (List<PedidosOrcamentos>)ListaGridPersistida;
                    }
                    else
                    {
                        ListaOrcamento = new List<PedidosOrcamentos>();
                    }

                    Projetos oProd = new Projetos();
                    oProd.ProjetoID = Convert.ToInt32(ddlProjeto.SelectedValue);
                    oProd.Nome = ddlProjeto.SelectedItem.ToString();

                    Categoria oCat = new Categoria();
                    oCat.CategoriaID = Convert.ToInt32(ddlCategoria.SelectedValue);
                    oCat.Nome = ddlCategoria.SelectedItem.ToString();

                    Grupo oArea = new Grupo();
                    if (((Usuario)Session["USUARIO"]).Perfil.PerfilId != 3)
                    {
                        oArea.ID = Convert.ToInt32(ddlArea.SelectedValue);
                        oArea.Nome = ddlArea.SelectedItem.ToString();
                    }
                    else
                    {
                        oArea = ((Usuario)Session["USUARIO"]).Area;
                    }

                    Item oItem = new Item();
                    oItem.ItemID = Convert.ToInt32(ddlItem.SelectedValue);
                    oItem.Nome = ddlItem.SelectedItem.ToString();
                    oItem.Categoria = oCat;

                    ItemOrcamento.Cod_PedidosOrcamentos = ListaOrcamento.Count + 1;
                    ItemOrcamento.Item = oItem;
                    ItemOrcamento.Projeto = oProd;
                    ItemOrcamento.Area = oArea;
                    ItemOrcamento.Quantidade = Convert.ToInt32(txtQuantidade.Text);
                    ItemOrcamento.Data_PedidoOrcamento = DateTime.Now;
                    ItemOrcamento.Status = Convert.ToInt32(StatusItemPedido.Em_Aberto);

                    if (txtOutros.Text.ToString() != string.Empty)
                    {
                        ItemOrcamento.Outros = txtOutros.Text.ToString();
                    }
                    if (txtDesc.Text.ToString() != string.Empty)
                    {
                        ItemOrcamento.Descricao = txtDesc.Text.ToString();
                    }

                    string msgConfirmacao = string.Empty;

                    //resultado = oPedItemFacade.Validar(ItemOrcamento);

                    //if (resultado.Sucesso)
                    //{
                    ListaGridPersistida = ListaOrcamento;
                    ListaOrcamento.Add(ItemOrcamento);
                    gvPedItens.DataSource = (List<PedidosOrcamentos>)ListaGridPersistida;
                    gvPedItens.DataBind();
                    btnSalvar.Visible = true;
                    btnCancelar.Visible = true;
                    ddlCategoria.Enabled = false;
                    //}
                }

                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ResultadoConfirmação", "alert('Selecione um Item para adicionar a lista!');", true);
                }

                ddlCategoria_SelectedIndexChanged(null, null);
                txtDesc.Text = "";
                txtOutros.Text = "";
                txtQuantidade.Text = "";
            }
        }

        protected void btnCancelar_Click(object sender, ImageClickEventArgs e)
        {
            ddlItem.Items.Clear();
            CarregaCombos();
            ListaGridPersistida = null;

            gvPedItens.DataBind();
            txtQuantidade.Text = string.Empty;
            txtOutros.Text = string.Empty;
            lblOutros.Visible = false;
            txtOutros.Visible = false;

        }

        protected void btnSalvar_Click(object sender, ImageClickEventArgs e)
        {

            if (ListaGridPersistida == null)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ResultadoConfirmação", "alert('Adicione ao menos um Item para fazer um orçamento!');", true);
            }
            else
            {
                Resultado resultado = new Resultado();
                List<Orcamentos> Lista = (List<Orcamentos>)ListaGridPersistida;
                
                StringBuilder sb = new StringBuilder();
                string msgConfirmacao = string.Empty;

                //Incluir
                //resultado =  oPedidoFacade.Incluir(opedido);
                msgConfirmacao = "Pedido incluído com sucesso!";

                idPedido = resultado.Id;

                if (resultado.Sucesso)
                {
                    Response.Redirect("PedidoConfirmacao.aspx?ped=" + idPedido);
                }
                else
                {
                    lblMensagem.Visible = false;
                    for (int msg = 0; msg < resultado.Mensagens.Count; msg++)
                    {
                        switch (resultado.Mensagens[msg].Campo)
                        {
                            case "PedidoItem":
                                lblMensagem.Text = resultado.Mensagens[msg].Descricoes[0];
                                lblMensagem.Visible = true;
                                break;
                            default:
                                lblMensagem.Text = resultado.Mensagens[msg].Descricoes[0];
                                lblMensagem.Visible = true;
                                break;
                        }
                    }
                }
            }

        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            List<PedidosOrcamentos> oListaPedItem = (List<PedidosOrcamentos>)ListaGridPersistida;

            foreach (PedidosOrcamentos item in (List<PedidosOrcamentos>)ListaGridPersistida)
            {
                if (item.Cod_PedidosOrcamentos == int.Parse(gvPedItens.DataKeys[int.Parse((sender as ImageButton).CommandArgument)].Value.ToString()))
                {
                    oListaPedItem.Remove(item);
                    break;
                }
            }
            ListaGridPersistida = oListaPedItem;
            ////Grid de Ramo
            gvPedItens.DataSource = (List<PedidosOrcamentos>)ListaGridPersistida;
            gvPedItens.DataBind();


            if (((List<PedidosOrcamentos>)ListaGridPersistida).Count == 0)
            {
                btnSalvar.Visible = false;
            }

        }

        protected void gvPedItens_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType.Equals(DataControlRowType.DataRow))
            {
                (e.Row.FindControl("lblPedItemID") as Label).Text = (e.Row.DataItem as PedidosOrcamentos).Cod_PedidosOrcamentos.ToString();
                (e.Row.FindControl("btnExcluir") as ImageButton).CommandArgument = e.Row.RowIndex.ToString();
            }
        }

        protected void ddlItem_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (ddlItem.SelectedItem.ToString().Trim() == "Outros")
            {
                lblOutros.Visible = true;
                txtOutros.Visible = true;
            }
            else
            {
                lblOutros.Visible = false;
                txtOutros.Visible = false;
            }

        }

        #endregion

        #region Métodos
        public void CarregaCombos()
        {

            Resultado resultado = new Resultado();
            ddlProjeto.DataSource = new ProjetosFacade().Listar(ref resultado);
            ddlProjeto.DataValueField = "ProjetoID";
            ddlProjeto.DataTextField = "Nome";
            ddlProjeto.DataBind();
            ddlProjeto.Items.Insert(0, new ListItem(" --Selecione um projeto-- ", "0"));

            ddlCategoria.DataSource = new CategoriaFacade().Listar(ref resultado);
            ddlCategoria.DataValueField = "CategoriaID";
            ddlCategoria.DataTextField = "Nome";
            ddlCategoria.DataBind();
            ddlCategoria.Items.Insert(0, new ListItem(" --Selecione uma categoria-- ", "0"));

            ddlArea.DataSource = new GrupoFacade().Listar(ref resultado);
            ddlArea.DataValueField = "ID";
            ddlArea.DataTextField = "Nome";
            ddlArea.DataBind();
            ddlArea.Items.Insert(0, new ListItem(" --Selecione uma área-- ", "0"));

            ddlUnidadeMedida.DataSource = new UnidadeMedidaFacade().Listar(ref resultado);
            ddlUnidadeMedida.DataValueField = "ID";
            ddlUnidadeMedida.DataTextField = "NomeAbreviado";
            ddlUnidadeMedida.DataBind();
            ddlUnidadeMedida.Items.Insert(0, new ListItem(" --Selecione uma unidade de medida-- ", "0"));

        }
        #endregion

    }
}
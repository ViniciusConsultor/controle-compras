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
    public partial class PedidosCadastro : PaginaBase
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
                    List<Ped_Item> listaPedItem = null;

                    Ped_Item ItemPedido = new Ped_Item();

                    if (ListaGridPersistida != null)
                    {
                        listaPedItem = (List<Ped_Item>)ListaGridPersistida;
                    }
                    else
                    {
                        listaPedItem = new List<Ped_Item>();
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

                    ItemPedido.PedidoItensID = listaPedItem.Count + 1;
                    ItemPedido.Item = oItem;
                    ItemPedido.Projeto = oProd;
                    ItemPedido.Area = oArea;
                    ItemPedido.Quantidade = Convert.ToInt32(txtQuantidade.Text);
                    ItemPedido.Data_Pedido = DateTime.Now;
                    ItemPedido.Status = Convert.ToInt32(StatusItemPedido.Em_Aberto);

                    if (txtOutros.Text.ToString() != string.Empty)
                    {
                        ItemPedido.Outros = txtOutros.Text.ToString();
                    }
                    if (txtDesc.Text.ToString() != string.Empty)
                    {
                        ItemPedido.Descrição = txtDesc.Text.ToString();
                    }

                    string msgConfirmacao = string.Empty;

                    resultado = oPedItemFacade.Validar(ItemPedido);

                    if (resultado.Sucesso)
                    {
                        ListaGridPersistida = listaPedItem;
                        listaPedItem.Add(ItemPedido);
                        gvPedItens.DataSource = (List<Ped_Item>)ListaGridPersistida;
                        gvPedItens.DataBind();
                        btnSalvar.Visible = true;
                        btnCancelar.Visible = true;
                    }
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
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ResultadoConfirmação", "alert('Adicione ao menos um Item para fazer um pedido!');", true);
            }
            else
            {
                Resultado resultado = new Resultado();
                Pedido opedido = new Pedido();

                opedido.DataPedido = DateTime.Now;
                opedido.DataOrcamento = DateTime.Now;
                opedido.Status = Conversion.preencheCampoInt(StatusPedido.Em_Aberto);
                opedido.Itens = (List<Ped_Item>)ListaGridPersistida;
                opedido.Usuario_ID = ((Usuario)Session["USUARIO"]).UsuarioId;

                StringBuilder sb = new StringBuilder();
                string msgConfirmacao = string.Empty;

                //Incluir
                resultado = oPedidoFacade.Incluir(opedido);
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
                            //case "Operacao":
                            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "ResultadoConfirmação", "alert('Erro ao confirmar a operação! Nenhuma alteração efetuada');", true);
                            //    break;
                        }
                    }
                }
            }

        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            List<Ped_Item> oListaPedItem = (List<Ped_Item>)ListaGridPersistida;

            foreach (Ped_Item item in (List<Ped_Item>)ListaGridPersistida)
            {
                if (item.PedidoItensID == int.Parse(gvPedItens.DataKeys[int.Parse((sender as ImageButton).CommandArgument)].Value.ToString()))
                {
                    oListaPedItem.Remove(item);
                    break;
                }
            }
            ListaGridPersistida = oListaPedItem;
            ////Grid de Ramo
            gvPedItens.DataSource = (List<Ped_Item>)ListaGridPersistida;
            gvPedItens.DataBind();


            if (((List<Ped_Item>)ListaGridPersistida).Count == 0)
            {
                btnSalvar.Visible = false;
            }

        }

        protected void gvPedItens_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType.Equals(DataControlRowType.DataRow))
            {
                (e.Row.FindControl("lblPedItemID") as Label).Text = (e.Row.DataItem as Ped_Item).PedidoItensID.ToString();
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
            ddlArea.Items.Insert(0, new ListItem(" --Selecione uma àrea-- ", "0"));

        }
        #endregion
       
    }
}
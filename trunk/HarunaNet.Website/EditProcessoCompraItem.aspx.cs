using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HarunaNet.Entities;
using HarunaNet.BusinessRules;
using HarunaNet.Framework.Utils;

namespace HarunaNet.SisWeb
{
    public partial class EditProcessoCompraItem : PaginaBase
    {
        protected ProcessoCompraItem oPCompraItem
        {
            get { return (ProcessoCompraItem)ViewState["Objeto"]; }
            set { ViewState["Objeto"] = value; }
        }
        List<Status> StatusItem = null;
        protected int Key;
        protected int CDP;

        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Resultado resultado = new Resultado();

                ddl_Fornecedor.DataSource = new FornecedorFacade().Listar(ref resultado, new Entities.Fornecedor());
                ddl_Fornecedor.DataValueField = "FornecedorID";
                ddl_Fornecedor.DataTextField = "NomeFantasia";
                ddl_Fornecedor.DataBind();
                ddl_Fornecedor.Items.Insert(0, new ListItem("", "0"));


                ddl_TpDocumento.DataSource = new TipoDocumentoFacade().Listar(ref resultado);
                ddl_TpDocumento.DataBind();
                ddl_TpDocumento.Items.Insert(0, new ListItem("", "0"));


                ddl_Status.DataSource = StatusItem = new Ped_ItemFacade().ListarStatus(ref resultado);
                ddl_Status.DataValueField = "StatusId";
                ddl_Status.DataTextField = "Descricao";
                ddl_Status.DataBind();
                ddl_Status.Items.Insert(0, new ListItem("", "0"));

                if (Context.Handler is ProcessoCompraItens)
                {
                    oPCompraItem = ((ProcessoCompraItens)Context.Handler).oProcessoCompraItem;
                    Key = ((ProcessoCompraItens)Context.Handler).Key;
                    ListaGridPersistida = ((ProcessoCompraItens)Context.Handler).Lista;
                    CDP = ((ProcessoCompraItens)Context.Handler).CDP;
                }

                oPCompraItem = ((List<ProcessoCompraItem>)ListaGridPersistida).Find(delegate(ProcessoCompraItem itm)
                {
                    return itm.CodItem == Key;
                });

                lbl_NumPedido.Text = oPCompraItem.CodPedido.ToString();
                lbl_Projeto.Text = oPCompraItem.NomeProjeto.ToString();
                lbl_NomeUsuario.Text = oPCompraItem.NomeUsuario.ToString();

                lbl_Item.Text = oPCompraItem.Outros.ToString().Trim() == "" ? oPCompraItem.NomeItem.ToString() : oPCompraItem.NomeItem.ToString() + "-" + oPCompraItem.Outros.ToString();
                lbl_Quantidade.Text = oPCompraItem.Quantidade.ToString();

                txt_QtdComprada.Text = oPCompraItem.QuantidadeComprada > 0 ? oPCompraItem.QuantidadeComprada.ToString() : "";
                txt_Valor.Text = oPCompraItem.ValorUnitario > 0 ? oPCompraItem.ValorUnitario.ToString() : "";

                dt_DataCompra.Text = oPCompraItem.DataCompra == DateTime.MinValue ? "" : oPCompraItem.DataCompra.ToShortDateString();
                dt_PrevisaoEntrega.Text = oPCompraItem.DataPrevisaoEntrega == DateTime.MinValue ? "" : oPCompraItem.DataPrevisaoEntrega.ToShortDateString();
                dt_Entrega.Text = oPCompraItem.DataEntrega == DateTime.MinValue ? "" : oPCompraItem.DataEntrega.ToShortDateString();

                ddl_Fornecedor.SelectedValue = oPCompraItem.Fornecedor.FornecedorID > 0 ? oPCompraItem.Fornecedor.FornecedorID.ToString() : "0";
                ddl_TpDocumento.SelectedValue = oPCompraItem.TpDocumentoFiscal > 0 ? oPCompraItem.TpDocumentoFiscal.ToString() : "0";

                ddl_Status.SelectedValue = oPCompraItem.Status.ToString();

                txt_NotaFiscal.Text = oPCompraItem.NotaFiscal > 0 ? oPCompraItem.NotaFiscal.ToString() : "";
                txt_NFSerie.Text = oPCompraItem.NotaSerie.ToString();
                dt_EmissaoNF.Text = oPCompraItem.DataEmissaoNota == DateTime.MinValue ? "" : oPCompraItem.DataEmissaoNota.ToShortDateString();

                //if (oPCompraItem.Status == 3)
                //{
                //    txt_QtdComprada.Enabled = false;
                //    txt_QtdComprada.Enabled = false;
                //    txt_Valor.Enabled = false;
                //    ddl_Fornecedor.Enabled = false;
                //}
            }
        }

        protected void btnSalvarItem_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(ddl_Status.SelectedValue) == 6)
            {
                string script = "$dvModalLoader.jqmHide();$dvDescCancelar.jqmShow();";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "abre", script, true);
            }
            else
            {
                salvar();
            }
        }

        protected void btnCancelarCadUsu_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ProcessoCompraItens.aspx?cdp=" + oPCompraItem.CodProcesso);

        }
        #endregion

        public void LiparCampos()
        {


            lblErroDataCompra.Text = "";
            lblErroDTEntrega.Text = "";
            lblErroFornecedor.Text = "";
            lblErroPrevisaoEntrega.Text = "";
            lblErroQtdComprada.Text = "";
            lblErroValor.Text = "";
            //lblMensagem.Text = "";

            lbl_NumPedido.Text = "";
            lbl_Projeto.Text = "";
            lbl_NomeUsuario.Text = "";
            lbl_Item.Text = "";
            lbl_Quantidade.Text = "";

            ddl_Fornecedor.SelectedValue = "0";
            ddl_Status.SelectedValue = "0";

            txt_QtdComprada.Text = "";
            txt_Valor.Text = "";
            txt_NotaFiscal.Text = "";

            txt_NFSerie.Text = "";
            dt_EmissaoNF.Text = "";
        }

        protected void btnSalvarDesc_Click(object sender, EventArgs e)
        {
            salvar();
                
        }

        private void salvar()
        {
            HarunaNet.Entities.Fornecedor oFornecedor = new HarunaNet.Entities.Fornecedor();
            ProcessoCompraItem oProcessoCompraItemCopia = new ProcessoCompraItem();

            oProcessoCompraItemCopia = oPCompraItem;
            oFornecedor.FornecedorID = Convert.ToInt32(ddl_Fornecedor.SelectedValue);
            oPCompraItem.Fornecedor = oFornecedor;
            oPCompraItem.NextStatus = Convert.ToInt32(ddl_Status.SelectedValue);

            oPCompraItem.QuantidadeComprada = txt_QtdComprada.Text.ToString() == "" ? 0 : Convert.ToInt32(txt_QtdComprada.Text);
            oPCompraItem.ValorUnitario = txt_Valor.Text.ToString() == "" ? 0 : Convert.ToDecimal(txt_Valor.Text);
            oPCompraItem.DataCompra = dt_DataCompra.Text.Trim() != "" ? Convert.ToDateTime(dt_DataCompra.Text) : DateTime.MinValue;
            oPCompraItem.DataPrevisaoEntrega = dt_PrevisaoEntrega.Text.Trim() != "" ? Convert.ToDateTime(dt_PrevisaoEntrega.Text) : DateTime.MinValue;
            oPCompraItem.DataEntrega = dt_Entrega.Text.Trim() != "" ? Convert.ToDateTime(dt_Entrega.Text) : DateTime.MinValue;

            oPCompraItem.DescMotivoCancelamento = txt_DescMotivoCancelamento.Text.Trim();

            if (txt_NotaFiscal.Text.ToString().Trim() != "")
            {
                oPCompraItem.TpDocumentoFiscal = Convert.ToInt32(ddl_TpDocumento.SelectedValue);
                oPCompraItem.NotaFiscal = Convert.ToInt32(txt_NotaFiscal.Text);
                oPCompraItem.DataEmissaoNota = dt_EmissaoNF.Text.Trim() != "" ? Convert.ToDateTime(dt_EmissaoNF.Text) : DateTime.MinValue;
                oPCompraItem.NotaSerie = txt_NFSerie.Text.ToString();
            }
            Resultado resultado = new Resultado();
            resultado = new Ped_ItemFacade().AtualizaItemCompra(oPCompraItem);

            if (resultado.Sucesso)
            {
                LiparCampos();

                string msg = "Item autalizado com sucesso!";

                string script = Consts.JavaScript.Alert(Consts.Funcoes.Replacer4js(msg), false);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alerta", script, true);

                Response.Redirect("~/ProcessoCompraItens.aspx?cdp=" + oPCompraItem.CodProcesso);
            }
            else
            {
                lblErroDTEntrega.Visible = false;
                lblErroPrevisaoEntrega.Visible = false;
                lblErroFornecedor.Visible = false;

                for (int msg = 0; msg < resultado.Mensagens.Count; msg++)
                {
                    switch (resultado.Mensagens[msg].Campo)
                    {
                        case "DataCompra":
                            lblErroDataCompra.Text = resultado.Mensagens[msg].Descricoes[0];
                            lblErroDataCompra.Visible = true;
                            break;
                        case "Valor":
                            lblErroValor.Text = resultado.Mensagens[msg].Descricoes[0];
                            lblErroValor.Visible = true;
                            break;
                        case "Fornecedor":
                            lblErroFornecedor.Text = resultado.Mensagens[msg].Descricoes[0];
                            lblErroFornecedor.Visible = true;
                            break;
                        case "QuantidadeComprada":
                            lblErroQtdComprada.Text = resultado.Mensagens[msg].Descricoes[0];
                            lblErroQtdComprada.Visible = true;
                            break;
                        case "PrevisaoEntrega":
                            lblErroPrevisaoEntrega.Text = resultado.Mensagens[msg].Descricoes[0];
                            lblErroPrevisaoEntrega.Visible = true;
                            break;
                        case "DataEntrega":
                            lblErroDTEntrega.Text = resultado.Mensagens[msg].Descricoes[0];
                            lblErroDTEntrega.Visible = true;
                            //ScriptManager.RegisterStartupScript(this, this.GetType(), "ResultadoConfirmação", "alert('Erro ao confirmar a operação! Nenhuma alteração efetuada');", true);
                            break;
                        case "DescMotivoCancelamento":

                            lblErroDTEntrega.Visible = true;
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "ResultadoConfirmação", "alert(' " + resultado.Mensagens[msg].Descricoes[0].ToString() + "');", true);
                            break;
                    }
                }

            }
        }

        protected void btnCancelarDesc_Click(object sender, EventArgs e)
        {
            txt_DescMotivoCancelamento.Text = "";
            string script = "$dvDescCancelar.jqmHide();";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "abre", script, true);
        }

    }
}
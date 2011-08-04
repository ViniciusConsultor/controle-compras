using System;
using System.Collections.Generic;
using System.Web.UI;

using HarunaNet.BusinessRules;
using HarunaNet.Entities;
using System.Web.UI.WebControls;
using HarunaNet.Framework.Utils;

namespace HarunaNet.SisWeb
{
    public partial class ProcessoCompraItens : PaginaBase
    {
        List<Status> StatusItem = null;
        public ProcessoCompraItem oProcessoCompraItem
        {
            get { return (ProcessoCompraItem)ViewState["Objeto"]; }
            set { ViewState["Objeto"] = value; }
        }

        public int CDP;
        public List<ProcessoCompraItem> Lista { get { return (List<ProcessoCompraItem>)ListaGridPersistida; } }

        public int Key { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                AtualizaGrid();
                Resultado resultado = new Resultado();
            }
        }

        internal void AtualizaGrid()
        {
            ListaGridPersistida = GetDados();
            gvListaPCompraItens.DataSource = (List<ProcessoCompraItem>)ListaGridPersistida;
            gvListaPCompraItens.DataBind();
        }

        public List<ProcessoCompraItem> GetDados()
        {
            Resultado resultado = new Resultado();
            Ped_ItemFacade oPedFacade = new Ped_ItemFacade();
            List<ProcessoCompraItem> oPedidosListaItem = new List<ProcessoCompraItem>();

            CDP = Convert.ToInt32(Request.QueryString["CDP"]);
            oPedidosListaItem = oPedFacade.ListaItensProcessoCompra(CDP, ref resultado);

            return oPedidosListaItem;
        }

        protected List<Ped_Item> SalvaItens()
        {

            List<Ped_Item> ListaPedItens = new List<Ped_Item>();

            foreach (GridViewRow item in gvListaPCompraItens.Rows)
            {
                if (item.RowType == DataControlRowType.DataRow)
                {
                    TextBox txtvalor = (TextBox)item.FindControl("txtValorunitario");
                    TextBox txtPrevisaoEntrega = (TextBox)item.FindControl("txtDtEntrega");
                    CheckBox chkDisp = (CheckBox)item.FindControl("chkDisponibilidade");
                    Label lblCodProcesso = (Label)item.FindControl("lblCodProcesso");
                    if (txtvalor.Text != null && txtvalor.Text != String.Empty || chkDisp.Checked)
                    {
                        Ped_Item PedItem = new Ped_Item();
                        PedItem.PedidoItensID = Convert.ToInt32(((Label)item.FindControl("llbPedItemID")).Text);
                        if (txtvalor.Text != null && txtvalor.Text != String.Empty)
                            PedItem.ValorUnitario = Convert.ToDecimal(txtvalor.Text);
                        else
                            PedItem.ValorUnitario = 0;

                        if (txtPrevisaoEntrega.Text != null && txtPrevisaoEntrega.Text != String.Empty)
                            PedItem.Data_PrevisaoEntrega = Convert.ToDateTime(txtPrevisaoEntrega.Text);
                        else
                            PedItem.Data_PrevisaoEntrega = DateTime.MinValue;

                        if (chkDisp.Checked)
                            PedItem.Status = Conversion.preencheCampoInt(StatusItemPedido.Indisponível);
                        else
                            PedItem.Status = Conversion.preencheCampoInt(StatusItemPedido.Aguardando_Entrega); ;

                        PedItem.CodProcesso = Conversion.preencheCampoInt(lblCodProcesso.Text);
                        ListaPedItens.Add(PedItem);
                    }
                }
            }
            return ListaPedItens;
        }

        protected void btn_Fechar_Click(object sender, EventArgs e)
        {

            try
            {
                Resultado resultado = new Resultado();
                resultado = new PCompra_Facade().Fechar((List<ProcessoCompraItem>)ListaGridPersistida);
                if (resultado.Sucesso)
                {

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ResultadoConfirmação", "alert('" + resultado.Mensagens[0].Descricoes[0] + "');", true);


                }
                else {

                    for (int msg = 0; msg < resultado.Mensagens.Count; msg++)
                    {
                        switch (resultado.Mensagens[msg].Campo)
                        {
                            case "ProcessoCompraFechar":
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "ResultadoConfirmação", "alert('" + resultado.Mensagens[msg].Descricoes[0] + "');", true);
                                break;

                        }
                    }
                
                }

            }
            catch (Exception ex)
            {
                
                throw ex;
            }

            //List<Ped_Item> ListaPedItens = SalvaItens();
            //if (ListaPedItens.Count > 0)
            //{
            //    Resultado resultado = new Resultado();
            //    resultado = new Ped_ItemFacade().AtualizaValor(ListaPedItens);
            //    if (resultado.Sucesso)
            //    {
            //        ProcessoCompra oProcessoCompra = new ProcessoCompra();

            //        oProcessoCompra.Status = Conversion.preencheCampoInt(StatusPedido.Aguardando_Entrega);
            //        oProcessoCompra.CodProcessoCompra = Convert.ToInt32(Request.QueryString["CDP"]);
            //        resultado = new Ped_ItemFacade().AtualizaStatusProcessoCompra(oProcessoCompra);

            //        if (resultado.Sucesso)
            //        {

            //            string msg = "Processo de Compra Finalizado, Aguardando Entrega!";

            //            string script = Consts.JavaScript.Alert(Consts.Funcoes.Replacer4js(msg), false);
            //            ScriptManager.RegisterStartupScript(this, this.GetType(), "alerta", script, true);

            //        }
            //    }
            //}
        }

        protected void btn_Voltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProcessoCompra.aspx");
        }

        protected void chkDisponibilidade_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void gvListaPCompraItens_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (((ProcessoCompraItem)(e.Row.DataItem)).Status > 3)
                {
                    e.Row.Cells[e.Row.Cells.Count -1].BackColor = System.Drawing.Color.FromArgb(255, 94, 94);
                    e.Row.Cells[e.Row.Cells.Count - 1].ForeColor = System.Drawing.Color.WhiteSmoke;
                }
                else if (((ProcessoCompraItem)(e.Row.DataItem)).Status == 3)
                {
                    e.Row.Cells[e.Row.Cells.Count - 1].BackColor = System.Drawing.Color.FromArgb(254, 255, 187);
                    e.Row.Cells[e.Row.Cells.Count - 1].ForeColor = System.Drawing.Color.WhiteSmoke;
                }
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            Key = Int32.Parse((sender as ImageButton).CommandArgument);
            Server.Transfer("EditProcessoCompraItem.aspx", false);
            // Response.Redirect("EditProcessoCompraItem.aspx?id=" + Int32.Parse((sender as ImageButton).CommandArgument));

            //LiparCampos();

            //oProcessoCompraItem = ((List<ProcessoCompraItem>)ListaGridPersistida).Find(delegate(ProcessoCompraItem itm)
            //{
            //    return itm.CodItem == key;
            //});

            //lbl_NumPedido.Text = oProcessoCompraItem.CodPedido.ToString();
            //lbl_Projeto.Text = oProcessoCompraItem.NomeProjeto.ToString();
            //lbl_NomeUsuario.Text = oProcessoCompraItem.NomeUsuario.ToString();

            //lbl_Item.Text = oProcessoCompraItem.Outros.ToString().Trim() == "" ? oProcessoCompraItem.NomeItem.ToString() : oProcessoCompraItem.NomeItem.ToString() + "-" + oProcessoCompraItem.Outros.ToString();
            //lbl_Quantidade.Text = oProcessoCompraItem.Quantidade.ToString();

            //txt_QtdComprada.Text = oProcessoCompraItem.QuantidadeComprada > 0 ? oProcessoCompraItem.QuantidadeComprada.ToString() : "";
            //txt_Valor.Text = oProcessoCompraItem.ValorUnitario > 0 ? oProcessoCompraItem.ValorUnitario.ToString() : "";

            //dt_DataCompra.Text = oProcessoCompraItem.DataCompra == DateTime.MinValue ? "" : oProcessoCompraItem.DataCompra.ToShortDateString();
            //dt_PrevisaoEntrega.Text = oProcessoCompraItem.DataPrevisaoEntrega == DateTime.MinValue ? "" : oProcessoCompraItem.DataPrevisaoEntrega.ToShortDateString();
            //dt_Entrega.Text = oProcessoCompraItem.DataEntrega == DateTime.MinValue ? "" : oProcessoCompraItem.DataEntrega.ToShortDateString();

            //txt_NotaFiscal.Text = oProcessoCompraItem.NotaFiscal > 0 ? oProcessoCompraItem.NotaFiscal.ToString() : "";

            //ddl_Fornecedor.SelectedValue = oProcessoCompraItem.Fornecedor.FornecedorID > 0 ? oProcessoCompraItem.Fornecedor.FornecedorID.ToString() : "0";
            //ddl_Status.SelectedValue = oProcessoCompraItem.Status.ToString();

            //if (oProcessoCompraItem.Status == 3)
            //{
            //    txt_QtdComprada.Enabled = false;
            //    txt_QtdComprada.Enabled = false;
            //    txt_Valor.Enabled = false;
            //    ddl_Fornecedor.Enabled = false;
            //}

            //string script = "$dvModalLoader.jqmHide();$dvEditarPedido.jqmShow();";
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "abre", script, true);
        }

        //protected void btnSalvarItem_Click(object sender, EventArgs e)
        //{
        //    //Fornecedor oFornecedor = new Fornecedor();
        //    //ProcessoCompraItem oProcessoCompraItemCopia = new ProcessoCompraItem();

        //    //oProcessoCompraItemCopia = oProcessoCompraItem;
        //    //oFornecedor.FornecedorID = Convert.ToInt32(ddl_Fornecedor.SelectedValue);
        //    //oProcessoCompraItem.Fornecedor = oFornecedor;
        //    //oProcessoCompraItem.NextStatus = Convert.ToInt32(ddl_Status.SelectedValue);

        //    //oProcessoCompraItem.QuantidadeComprada = txt_QtdComprada.Text.ToString() == "" ? 0 : Convert.ToInt32(txt_QtdComprada.Text);
        //    //oProcessoCompraItem.ValorUnitario = txt_Valor.Text.ToString() == "" ? 0 : Convert.ToDecimal(txt_Valor.Text);
        //    //oProcessoCompraItem.DataCompra = dt_DataCompra.Text.Trim() != "" ? Convert.ToDateTime(dt_DataCompra.Text) : DateTime.MinValue;
        //    //oProcessoCompraItem.DataPrevisaoEntrega = dt_PrevisaoEntrega.Text.Trim() != "" ? Convert.ToDateTime(dt_PrevisaoEntrega.Text) : DateTime.MinValue;
        //    //oProcessoCompraItem.DataEntrega = dt_Entrega.Text.Trim() != "" ? Convert.ToDateTime(dt_Entrega.Text) : DateTime.MinValue;

        //    //if (txt_NotaFiscal.Text.ToString().Trim() != "")
        //    //    oProcessoCompraItem.NotaFiscal = Convert.ToInt32(txt_NotaFiscal.Text);

        //    //Resultado resultado = new Resultado();
        //    //resultado = new Ped_ItemFacade().AtualizaItemCompra(oProcessoCompraItem);

        //    //if (resultado.Sucesso)
        //    //{
        //    //    AtualizaGrid();
        //    //    LiparCampos();

        //    //    string msg = "Item autalizado com sucesso!";

        //    //    string script = Consts.JavaScript.Alert(Consts.Funcoes.Replacer4js(msg), false);
        //    //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alerta", script, true);

        //    //     script = "$dvEditarPedido.jqmHide();";
        //    //    ScriptManager.RegisterStartupScript(this, this.GetType(), "abre", script, true);
        //    //}
        //    //else
        //    //{
        //    //    lblErroDTEntrega.Visible = false;
        //    //    lblErroPrevisaoEntrega.Visible = false;
        //    //    lblErroFornecedor.Visible = false;

        //    //    for (int msg = 0; msg < resultado.Mensagens.Count; msg++)
        //    //    {
        //    //        switch (resultado.Mensagens[msg].Campo)
        //    //        {
        //    //            case "DataCompra":
        //    //                lblErroDataCompra.Text = resultado.Mensagens[msg].Descricoes[0];
        //    //                lblErroDataCompra.Visible = true;
        //    //                break;
        //    //            case "Valor":
        //    //                lblErroValor.Text = resultado.Mensagens[msg].Descricoes[0];
        //    //                lblErroValor.Visible = true;
        //    //                break;
        //    //            case "Fornecedor":
        //    //                lblErroFornecedor.Text = resultado.Mensagens[msg].Descricoes[0];
        //    //                lblErroFornecedor.Visible = true;
        //    //                break;
        //    //            case "QuantidadeComprada":
        //    //                lblErroQtdComprada.Text = resultado.Mensagens[msg].Descricoes[0];
        //    //                lblErroQtdComprada.Visible = true;
        //    //                break;
        //    //            case "PrevisaoEntrega":
        //    //                lblErroPrevisaoEntrega.Text = resultado.Mensagens[msg].Descricoes[0];
        //    //                lblErroPrevisaoEntrega.Visible = true;
        //    //                break;
        //    //            case "DataEntrega":
        //    //                lblErroDTEntrega.Text = resultado.Mensagens[msg].Descricoes[0];
        //    //                lblErroDTEntrega.Visible = true;
        //    //                //ScriptManager.RegisterStartupScript(this, this.GetType(), "ResultadoConfirmação", "alert('Erro ao confirmar a operação! Nenhuma alteração efetuada');", true);
        //    //                break;
        //    //        }
        //    //    }
        //    //}
        //}

        //public void LiparCampos()
        //{


        //    lblErroDataCompra.Text = "";
        //    lblErroDTEntrega.Text = "";
        //    lblErroFornecedor.Text = "";
        //    lblErroPrevisaoEntrega.Text = "";
        //    lblErroQtdComprada.Text = "";
        //    lblErroValor.Text = "";
        //    lblMensagem.Text = "";

        //    lbl_NumPedido.Text = "";
        //    lbl_Projeto.Text = "";
        //    lbl_NomeUsuario.Text = "";
        //    lbl_Item.Text = "";
        //    lbl_Quantidade.Text = "";

        //    ddl_Fornecedor.SelectedValue = "0";
        //    ddl_Status.SelectedValue = "0";

        //    txt_QtdComprada.Text = "";
        //    txt_Valor.Text = "";
        //    txt_NotaFiscal.Text = "";

        //    txt_NFSerie.Text = "";
        //    dt_EmissaoNF.Text = "";
        //}

        protected void btnCancelarCadUsu_Click(object sender, EventArgs e)
        {
            //LiparCampos();
            string script = "$dvEditarPedido.jqmHide();";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "abre", script, true);
        }
        
        public void validaFechamento(object source, ServerValidateEventArgs args)
        {
            args.IsValid = false;
        }

        public void rfvValor_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = false;
        }


    }
}
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using HarunaNet.BusinessRules;
using HarunaNet.Entities;

namespace HarunaNet.SisWeb
{
    public partial class PedidosOrcamentoEdit : PaginaBase
    {
        protected PedidosOrcamentos Orcamento
        {
            get { return (PedidosOrcamentos)ViewState["Orcamento"]; }
            set { ViewState["Orcamento"] = value; }
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Context.Handler is PedidosOrcamentoLista)
                {
                    Resultado resultado = new Resultado();
                    Orcamento = new PedOrcamentoFacade().Obter(ref resultado, ((PedidosOrcamentoLista)Context.Handler).IdPedidoOrcamento);
                    if (resultado.Sucesso)
                    {
                        PreencheOrcamentos(Orcamento);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Resultado", "alert('" + resultado.Mensagens[0].Descricoes[0].ToString() + "'); location.href='PedidosOrcamentoLista.aspx';", true);
                    }
                }
            }
        }

        protected void PreencheOrcamentos(PedidosOrcamentos pedOrcamento)
        {

            txtProjeto.Text = pedOrcamento.Projeto.Nome.ToString();
            //lblNomeArea.Text = pedOrcamento.Area.Nome.ToString();
            txtCategoria.Text = pedOrcamento.Item.Categoria.Nome.ToString();
            txtItem.Text = pedOrcamento.Item.Nome.ToString();
            txtQuantidade.Text = pedOrcamento.Quantidade.ToString();
            txtFinalidade.Text = pedOrcamento.Finalidade == null ? string.Empty : pedOrcamento.Finalidade.ToString();

        }

        protected void btnVoltar_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("default.aspx", false);
        }

        protected void imgSalvarCotacao_Click(object sender, ImageClickEventArgs e)
        {
            Resultado resultado = new Resultado();
            List<Orcamentos> ListaOrcamento = new List<Orcamentos>();
            Orcamentos orcamento = new Orcamentos();

            orcamento.Fornecedor = new FornecedorFacade().Obter(ref resultado, Convert.ToInt32(hdfIdFornecedor.Value));
            orcamento.Cod_Orcamento = 1;    
            orcamento.Valor = Convert.ToDecimal(txtValor.Text);
            //orcamento.Quantidade = Convert.ToInt32(txtQuantidade.Text);
            orcamento.Desconto = Convert.ToDecimal(txtDesconto.Text);


            ListaOrcamento.Add(orcamento);

            rptOrcamentos.DataSource = ListaOrcamento;
            rptOrcamentos.DataBind();
        }

      
    }
}
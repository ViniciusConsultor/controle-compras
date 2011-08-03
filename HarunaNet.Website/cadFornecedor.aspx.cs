using System;
using System.Web.UI;
using HarunaNet.Entities;
using HarunaNet.BusinessRules;
using HarunaNet.Framework.Utils;

namespace HarunaNet.SisWeb
{
    public partial class cadFornecedor : PaginaBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Resultado resultado = new Resultado();
                int FornecedorID = Convert.ToInt32(Request.QueryString["id"]);
                HarunaNet.Entities.Fornecedor oFornecedor = new FornecedorFacade().Obter(ref resultado, FornecedorID);
                if (oFornecedor.FornecedorID >= 0)
                {
                    ObterDados(oFornecedor);
                }
            }
        }

        protected void ObterDados(HarunaNet.Entities.Fornecedor oFornecedor)
        {
            FornecedorID.Value = oFornecedor.FornecedorID.ToString();
            txtNomeFantasia.Text = oFornecedor.NomeFantasia;
            txtRazaoSocial.Text  = oFornecedor.RazaoSocial;
            txtCNPJ.Text = oFornecedor.CNPJ;
            txtInscEstadual.Text = oFornecedor.InscricaoEstadual;
            txtInscMunicipal.Text = oFornecedor.InscricaoMunicipal;
            txtEndereco.Text = oFornecedor.Logradouro;
            txtBairro.Text= oFornecedor.Bairro;
            txtCEP.Text = oFornecedor.CEP;
            txtCidade.Text = oFornecedor.Cidade;
            txtUF.Text = oFornecedor.UF;
            txtTelefone1.Text = oFornecedor.Telefone_1;
            txtRamal1.Text = oFornecedor.Ramal_1;
            txtTelefone2.Text = oFornecedor.Telefone_2;
            txtRamal2.Text = oFornecedor.Ramal_2;
            txtCelular.Text = oFornecedor.Celular;
            txtEmail.Text = oFornecedor.Email;
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {

            HarunaNet.Entities.Fornecedor oFornecedor = new HarunaNet.Entities.Fornecedor();
            Resultado resultado = new Resultado();
            try
            {
                oFornecedor.FornecedorID = FornecedorID.Value.Trim() != String.Empty ? Convert.ToInt32(FornecedorID.Value) : 0;
                oFornecedor.NomeFantasia = txtNomeFantasia.Text;
                oFornecedor.RazaoSocial = txtRazaoSocial.Text;
                oFornecedor.CNPJ = txtCNPJ.Text;
                oFornecedor.InscricaoEstadual = txtInscEstadual.Text;
                oFornecedor.InscricaoMunicipal = txtInscMunicipal.Text;
                oFornecedor.Logradouro = txtEndereco.Text;
                oFornecedor.Bairro = txtBairro.Text;
                oFornecedor.CEP = txtCEP.Text;
                oFornecedor.Cidade = txtCidade.Text;
                oFornecedor.UF = txtUF.Text;
                oFornecedor.Telefone_1 = txtTelefone1.Text;
                oFornecedor.Ramal_1 = txtRamal1.Text;
                oFornecedor.Telefone_2 = txtTelefone2.Text;
                oFornecedor.Ramal_2 = txtRamal2.Text;
                oFornecedor.Celular = txtCelular.Text;
                oFornecedor.Email = txtEmail.Text;
                oFornecedor.Status = 1;

                resultado = new FornecedorFacade().Salvar(oFornecedor);
                if (resultado.Sucesso)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alerta", Consts.JavaScript.Alert(Consts.Funcoes.Replacer4js(resultado.Mensagens[0].Descricoes[0].ToString()), false), true);
                    //Response.Redirect("~/Fornecedor.aspx");
                    btnCancelar.Text = "Voltar";
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alerta", Consts.JavaScript.Alert(Consts.Funcoes.Replacer4js(resultado.Mensagens[0].Descricoes[0].ToString()), false), true);
                }

            }
            catch(Exception ex)
            {
                //Fechar();
            }


        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Fornecedor.aspx");
        }


    }
}
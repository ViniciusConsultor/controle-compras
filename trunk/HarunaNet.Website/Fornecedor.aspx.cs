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
    public partial class Fornecedor : PaginaBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetDados();
            }
        }

       

        protected void btnPesquisar_Click(object sender, ImageClickEventArgs e)
        {
            GetDados();
        }

        private void GetDados()
        {
            Resultado resultado = new Resultado();
            HarunaNet.Entities.Fornecedor oFornecedor = new Entities.Fornecedor();
            oFornecedor.NomeFantasia = txtNomeFantasia.Text.Trim() != "" ? txtNomeFantasia.Text : null;
            oFornecedor.Status = Convert.ToInt32(ddlStatus.SelectedValue);
            grdFornecedores.DataSource = new FornecedorFacade().Listar(ref resultado, oFornecedor);// UsuarioFacade().Listar(tbxPesqNomeUsu.Text.Trim().ToUpper(), ref resultado);
            grdFornecedores.DataKeyNames = new string[1] { "FornecedorId" };
            grdFornecedores.DataBind();
        }
        protected void grdFornecedores_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType.Equals(DataControlRowType.DataRow))
            {
                (e.Row.FindControl("btnEditar") as ImageButton).CommandArgument = e.Row.RowIndex.ToString();
                (e.Row.FindControl("btnExcluir") as ImageButton).CommandArgument = e.Row.RowIndex.ToString();
            }
        }

        protected void btnInserir_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/cadFornecedor.aspx");
        }

        protected void btnEditar_Click(object sender, ImageClickEventArgs e)
        {
            int key = Int32.Parse(grdFornecedores.DataKeys[Int32.Parse((sender as ImageButton).CommandArgument)].Value.ToString());
            Response.Redirect("~/cadFornecedor.aspx?id=" + key);
        }
    }
}
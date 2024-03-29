﻿using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

using HarunaNet.BusinessRules;
using HarunaNet.Entities;

namespace HarunaNet.SisWeb
{
    public partial class meuspedidos : PaginaBase
    {
        private string sortExpression
        {
            get { return ViewState["sortExpression"].ToString(); }
            set { ViewState["sortExpression"] = value; }
        }

        public int IdPedido
        {
            get { return Convert.ToInt32(ViewState["IdPedido"]); }
            set { ViewState["IdPedido"] = value; }
        }

        private int sortDirection
        {
            get { return Convert.ToInt32(ViewState["sortDirection"]); }
            set { ViewState["sortDirection"] = value; }
        }
               
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                sortExpression = "DataPedido";
                sortDirection = 1;
                
                if (((Usuario)Session["USUARIO"]).Perfil.PerfilId == 1)
                {

                    PesquisarUsuario();
                    ddlusuario.Visible = true;
                    lblUsuario.Visible = true;
                    ddlusuario.SelectedValue = ((Usuario)Session["USUARIO"]).UsuarioId.ToString();
                }
                PreencherGrid(ddlusuario.SelectedValue == "" ? ((Usuario)Session["USUARIO"]).UsuarioId : Convert.ToInt32(ddlusuario.SelectedValue));
            }
        }

        private void PesquisarUsuario()
        {
            Resultado resultado = new Resultado();
            ddlusuario.DataSource = new UsuarioFacade().Listar("", ref resultado);
            ddlusuario.DataValueField = "UsuarioId";
            ddlusuario.DataTextField = "Nome";
            ddlusuario.DataBind();
        }

        private void PreencherGrid(int usuarioID)
        {
            Resultado resultado = new Resultado();
            PedidoFacade oPedFacade = new PedidoFacade();
            List<MeusPedidos> oPedidos = new List<MeusPedidos>();
            oPedidos = oPedFacade.Listar(usuarioID, ref resultado);

            gvListaMeusPed.DataSource = null;
            gvListaMeusPed.DataBind();

            if (resultado.Sucesso)
            {
                lblMensagem.Visible = false;
                ListaGridPersistida = oPedidos;
                gvListaMeusPed.DataSource = (List<MeusPedidos>)ListaGridPersistida;
                gvListaMeusPed.DataBind();
            }
            else
            {
                lblMensagem.Text = resultado.Mensagens[0].Descricoes[0].ToString();
                lblMensagem.Visible = false;
            }

        }

        protected void gvListaMeusPed_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton imgEditar = (ImageButton)e.Row.Cells[3].FindControl("imgEditar");
                imgEditar.CommandArgument = e.Row.RowIndex.ToString();

                ScriptManager scriptManager = (ScriptManager)((MasterPrincipal)Master).FindControl("ScriptManager1");
                scriptManager.RegisterPostBackControl(imgEditar);

                Label olblStatus = (Label)e.Row.Cells[2].FindControl("lblStatus");

                switch (Convert.ToInt32(olblStatus.Text))
                {
                   
                    case 1:
                        olblStatus.Text = StatusPedido.Em_Aberto.ToString();
                        break;
                    case 2:
                        olblStatus.Text = StatusPedido.Em_Andamento.ToString();
                        break;
                    case 3:
                        olblStatus.Text = StatusPedido.Aguardando_Entrega.ToString();
                        break;
                    case 4:
                        olblStatus.Text = StatusPedido.Finalizado.ToString();
                        break;
                    case 5:
                        olblStatus.Text = StatusPedido.Finalizado_Pendencias.ToString();
                        break;
                    case 9:
                        olblStatus.Text = StatusPedido.Cancelado.ToString();
                        break;
                }



            }
        }

        protected void gvListaMeusPed_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {

                case "Editar":
                    IdPedido = Convert.ToInt32(gvListaMeusPed.DataKeys[Convert.ToInt32(e.CommandArgument)][0]);
                    EditarGrupoNotasExecucao();
                    break;
            }
        }

        protected void gvListaMeusPed_Sorting(object sender, GridViewSortEventArgs e)
        {
            if (sortExpression != e.SortExpression)
            {
                sortDirection = 1; //ASC
            }
            else
            {
                sortDirection *= -1; //DESC
            }

            sortExpression = e.SortExpression;
            PreencherGrid(ddlusuario.SelectedValue == "" ? ((Usuario)Session["USUARIO"]).UsuarioId : Convert.ToInt32(ddlusuario.SelectedValue));
        }

        protected void gvListaMeusPed_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvListaMeusPed.PageIndex = e.NewPageIndex;
            PreencherGrid(ddlusuario.SelectedValue == "" ? ((Usuario)Session["USUARIO"]).UsuarioId : Convert.ToInt32(ddlusuario.SelectedValue));
        }

        protected void btn_Voltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx",false);
        }

        private void EditarGrupoNotasExecucao()
        {
            Server.Transfer("MeusPedidosItens.aspx",true);
        }

        protected void ddlusuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            PreencherGrid(ddlusuario.SelectedValue == "" ? ((Usuario)Session["USUARIO"]).UsuarioId : Convert.ToInt32(ddlusuario.SelectedValue));
        }
    }
}
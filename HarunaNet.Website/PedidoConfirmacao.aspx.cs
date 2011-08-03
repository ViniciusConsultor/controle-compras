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
    public partial class PedidoConfirmacao : PaginaBase
    {
        string mensagemCorpoTableHTML = String.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {

            Ped_ItemFacade oPed_ItemFacade = new Ped_ItemFacade();
            if (!Page.IsPostBack)
            {
                lblTexto.Text = "Anote o número do seu pedido ";
                lblNumero.Text =  String.Format("{0:D6}", Request.QueryString["ped"].ToString());
                Resultado resultado = new Resultado();
                
                ListaGridPersistida =  oPed_ItemFacade.ListaItensByNumPed(Convert.ToInt32(Request.QueryString["ped"].ToString()), ref resultado);
                List<Ped_Item> lista_pedidos = (List<Ped_Item>)ListaGridPersistida;

                string mensagemHTML = String.Empty;
               
                
                mensagemHTML = "<html>";
                mensagemHTML += "<head><style type='text/css'>body {font-family: Verdana;font-size: 10px;color: #333;text-decoration: none;}table,th,td{border:1px solid black;border-collapse: collapse;border-color:#ffffff;}    th{background-color:#fff; color: #da251d;}td{padding:2px;background-color:#fff; }tr.d0 td {background-color: #ececeb; }tr.d1 td {background-color: #dededd; } #conteudo{ font-size: 14px; margin: 50px 0 15px 0;background-color: #dededd;padding: 20px 0 20px 10px; color: #da251d; font-weight:bold;}</style></head>";
                mensagemHTML += "<body>";
                mensagemHTML += "<img src='http://www.haruna.com.br/library/img/mail_resposta.png' />";
                mensagemHTML += "<div id='conteudo'>" + lblTexto.Text + " " + lblNumero.Text + ".</div>";
                mensagemHTML += "<table  width='100%'>";
                mensagemHTML += "<tr>";
                mensagemHTML += "<th>Projeto</th><th>Área</th><th>Categoria</th><th>Item</th><th>Quantidade</th>";
                mensagemHTML += "</tr>";

                mensagemCorpoTableHTML = "";
                for (int i = 0; i < lista_pedidos.Count; i++)
                {
                    if ((i % 2) ==0)
                        mensagemCorpoTableHTML += "<tr class='d0'>";
                    else
                        mensagemCorpoTableHTML += "<tr class='d1'>";

                    mensagemCorpoTableHTML += "<td>" + lista_pedidos[i].Projeto.Nome.ToString() + "</td>";
                    mensagemCorpoTableHTML += "<td>" + lista_pedidos[i].Area.Nome.ToString() + "</td>";
                    mensagemCorpoTableHTML += "<td>" + lista_pedidos[i].Item.Categoria.Nome + "</td>";
                    mensagemCorpoTableHTML += "<td>" + lista_pedidos[i].Item.Nome;
                    if (lista_pedidos[i].Outros != String.Empty)
                        mensagemCorpoTableHTML += " - " + lista_pedidos[i].Outros;
                    mensagemCorpoTableHTML += "</td>";
                    mensagemCorpoTableHTML += "<td>" + lista_pedidos[i].Quantidade + "</td>";
                    mensagemCorpoTableHTML += "</tr>";
                    
                }
                mensagemHTML += mensagemCorpoTableHTML;
                mensagemHTML += "</table>";
                mensagemHTML += "</html>";
                mensagemHTML += "</body>";

                Literal1.Visible = false;
                
                gvPedItens.DataSource = lista_pedidos;
                gvPedItens.DataBind();

                Mail sendMail = new Mail();

                sendMail.Assunto = "Confirmação do Pedido";

                Usuario u = (Usuario)Session["USUARIO"];
                sendMail.AdicionarDestinatario(TipoDestinatario.Para, u.Email.ToString());

                sendMail.CorpoHTML =  mensagemHTML;
                sendMail.EnableSsl = true;
                sendMail.Enviar().ToString();

                Envio_Mail();

            }
        }


        private void Envio_Mail()
        {
            Usuario u = (Usuario)Session["USUARIO"];
           string mtextoPedido = "O Usuário " + u.Nome +  " fez uma nova solicitação de Compra número";
            List<Ped_Item> lista_pedidos = (List<Ped_Item>)ListaGridPersistida;

            string mensagemHTML = String.Empty;

            mensagemHTML = "<html>";
            mensagemHTML += "<head><style type='text/css'>body {font-family: Verdana;font-size: 10px;color: #333;text-decoration: none;}table,th,td{border:1px solid black;border-collapse: collapse;border-color:#ffffff;}    th{background-color:#fff; color: #da251d;}td{padding:2px;background-color:#fff; }tr.d0 td {background-color: #ececeb; }tr.d1 td {background-color: #dededd; } #conteudo{ font-size: 14px; margin: 50px 0 15px 0;background-color: #dededd;padding: 20px 0 20px 10px; color: #da251d; font-weight:bold;}</style></head>";
            mensagemHTML += "<body>";
            mensagemHTML += "<img src='http://www.haruna.com.br/library/img/mail_resposta.png' />";
            mensagemHTML += "<div id='conteudo'>" + mtextoPedido + " " + lblNumero.Text + ".</div>";
            mensagemHTML += "<table  width='100%'>";
            mensagemHTML += "<tr>";
            mensagemHTML += "<th>Projeto</th><th>Área</th><th>Categoria</th><th>Item</th><th>Quantidade</th>";
            mensagemHTML += "</tr>";


            mensagemHTML += mensagemCorpoTableHTML;

            mensagemHTML += "</table>";
            mensagemHTML += "</html>";
            mensagemHTML += "</body>";
                       

            Mail sendMail = new Mail();

            sendMail.Assunto = "Solicitação de Pedidos";

            sendMail.AdicionarDestinatario(TipoDestinatario.Para, "compras@haruna.com.br");

            sendMail.CorpoHTML = mensagemHTML;
            sendMail.EnableSsl = true;
            sendMail.Enviar().ToString();
        }
        protected void btn_Voltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx", false);
        }
    }
}
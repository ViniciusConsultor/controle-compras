using System;
using System.Web.UI;
using HarunaNet.Entities;
using HarunaNet.BusinessRules;
using HarunaNet.Framework.Utils;
using System.Reflection;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxMenu;
using System.Data;

using System.Configuration;
using System.Collections.Specialized;
using System.Web;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace HarunaNet.SisWeb
{
    public partial class MasterPrincipal : System.Web.UI.MasterPage
    {
        UsuarioFacade UsuarioFac = new UsuarioFacade();
        #region Eventos

        protected void Page_Load(object sender, EventArgs e)
        {
            Resultado resultado = new Resultado();
            //Verifica se o usuário terá acesso a esta página
            if (Session["USUARIO"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                Usuario u = (Usuario)Session["USUARIO"];


                resultado = UsuarioFac.TemAcesso(u, Consts.Funcoes.FormName(Request.Url.AbsolutePath), ref resultado);

                if (!resultado.Sucesso)
                {
                    Response.Redirect("login.aspx");
                }
                else
                {
                    lbl_logado.Text = "<b>Seja bem-vindo&nbsp;" + u.Nome + "&nbsp;&nbsp;</b>";

                    List<menu> listaModuloAcesso = new List<menu>();

                    foreach (menu item in u.ItensMenu)
                    {
                        if (item.Visivel)
                        {
                            listaModuloAcesso.Add(item);
                        }
                    }
                                        
                    rptMenu.DataSource = listaModuloAcesso;
                    rptMenu.DataBind();
                   
                }
            }
        }

        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    Resultado resultado = new Resultado();
        //    //Verifica se o usuário terá acesso a esta página
        //    if (Session["USUARIO"] == null)
        //    {
        //        Response.Redirect("login.aspx");
        //    }
        //    else
        //    {
        //        Usuario u = (Usuario)Session["USUARIO"];

        //        resultado = UsuarioFac.TemAcesso(u, Consts.Funcoes.FormName(Request.Url.AbsolutePath), ref resultado);

        //        if (!resultado.Sucesso)
        //        {
        //            Response.Redirect("login.aspx");
        //        }
        //        else
        //        {
        //            lbl_logado.Text = "<b>Seja bem-vindo&nbsp;" + u.Nome + "&nbsp;&nbsp;</b>";

        //            BuildMenu(MenuGeral, u.ItensMenu);

        //        }
        //    }
        //}

        protected void BuildMenu(ASPxMenu menu, List<menu> ListaMenu)
        {

            // Build Menu Items
            Dictionary<string, DevExpress.Web.ASPxMenu.MenuItem> menuItems =
         new Dictionary<string, DevExpress.Web.ASPxMenu.MenuItem>();

            foreach (menu item in ListaMenu)
            {
                DevExpress.Web.ASPxMenu.MenuItem itemMenu = CreateMenuItem(item);
                string itemID = item.CodMenu.ToString();
                string parentID = item.ItemPai.ToString();

                if (menuItems.ContainsKey(parentID))
                    menuItems[parentID].Items.Add(itemMenu);
                else
                {
                    if (parentID == "0") // It's Root Item
                        menu.Items.Add(itemMenu);
                }
                menuItems.Add(itemID, itemMenu);
            }
        }

        private DevExpress.Web.ASPxMenu.MenuItem CreateMenuItem(menu item)
        {
            DevExpress.Web.ASPxMenu.MenuItem ret = new DevExpress.Web.ASPxMenu.MenuItem();
            ret.Text = item.ItemMenu.ToString();
            ret.NavigateUrl = item.Pagina + ".aspx";
            //ret.Image.Url = row["ImageUrl"].ToString();
            return ret;
        }

        private void OrdenarLista(ref List<menu> oModulos)
        {
            oModulos.Sort(delegate(menu p1, menu p2)
            {
                Type t = typeof(menu);
                PropertyInfo prop = t.GetProperty("ItemMenu");
                object p1Value = prop.GetValue(p1, null);
                object p2Value = prop.GetValue(p2, null);
                return ((IComparable)p1Value).CompareTo(((IComparable)p2Value));
            });
        }

        #endregion
        private void CarregaMenu()
        {
            //mnuPrincipal.Items.Clear();
            //Usuario u = (Usuario)Session["USUARIO"];
            //if (u.ItensMenu.Count > 0)
            //{
            //    System.Web.UI.WebControls.MenuItem i = new System.Web.UI.WebControls.MenuItem();

            //    foreach (menu item in u.ItensMenu)
            //    {
            //        if (item.Visivel)
            //        {

            //            if (item.Pagina != "")
            //                i = new System.Web.UI.WebControls.MenuItem(item.ItemMenu, item.ItemMenu, string.Empty, @"~/" + item.Pagina + ".aspx");
            //            else
            //                i = new System.Web.UI.WebControls.MenuItem(item.ItemMenu);


            //            mnuPrincipal.Items.Add(i);
            //            if (item.itens != null)
            //            {
            //                foreach (menu itemfilho in item.itens)
            //                    i.ChildItems.Add(new System.Web.UI.WebControls.MenuItem(itemfilho.ItemMenu, itemfilho.ItemMenu, string.Empty, @"~/" + itemfilho.Pagina + ".aspx"));
            //            }
            //        }
            //    }
            //}
            //else
            //{
            //    mnuPrincipal.Visible = false;
            //}
        }
    }
}
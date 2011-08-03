using System;
using System.Web.UI;
using HarunaNet.Entities;
using HarunaNet.BusinessRules;
using HarunaNet.Framework.Utils;
using System.Reflection;
using System.Collections.Generic;
using System.Web.UI.WebControls;

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

                    if (u.Perfil.PerfilId == 1)
                    {

                        menu.Visible = false;
                        CarregaMenu();
                        //    rptMenuADM.DataSource = listaModuloAcesso;
                        //    rptMenuADM.DataBind();
                        //    menuADM.Visible = true;
                    }
                    else
                    {
                        mnuPrincipal.Visible = false;
                        rptMenu.DataSource = listaModuloAcesso;
                        rptMenu.DataBind();
                    }
                }
            }
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
            mnuPrincipal.Items.Clear();
            Usuario u = (Usuario)Session["USUARIO"];
            if (u.ItensMenu.Count > 0)
            {
                MenuItem i = new MenuItem();

                foreach (menu item in u.ItensMenu)
                {
                    if (item.Visivel)
                    {
                        
                        if (item.Pagina != "")
                            i = new MenuItem(item.ItemMenu, item.ItemMenu, string.Empty, @"~/" + item.Pagina + ".aspx");
                        else
                            i = new MenuItem(item.ItemMenu);

                        
                        mnuPrincipal.Items.Add(i);
                        if (item.itens != null)
                        {
                            foreach (menu itemfilho in item.itens)
                                i.ChildItems.Add(new MenuItem(itemfilho.ItemMenu, itemfilho.ItemMenu, string.Empty, @"~/" + itemfilho.Pagina + ".aspx"));
                        }
                    }
                }
            }
            else
            {
                mnuPrincipal.Visible = false;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web.Security;

namespace HarunaNet.Framework.Utils
{
    /// <summary>
    /// Classe abstrata para p�gina web.
    /// </summary>
    public abstract class Page : System.Web.UI.Page
    {
        #region Atributos
        private bool m_refreshState;
        private bool m_isRefresh;
        #endregion

        #region Propriedades
        /// <summary>
        /// Get retorno se o postback
        /// foi gerado ao chamar o "Refresh" da p�gina
        /// </summary>
        public bool IsRefresh
        {
            get { return m_isRefresh; }
        }
        #endregion

        #region M�todos
        /// <summary>
        /// M�todo que carrega o ViewState e compara
        ///  o �ltimo valor com o atual para identificar
        /// o Refresh
        /// </summary>
        /// <param name="savedState">Objeto de estado da p�gina atual.</param>
        protected override void LoadViewState(object savedState)
        {
            object[] AllStates = (object[])savedState;
            base.LoadViewState(AllStates[0]);
            m_refreshState = Convert.ToBoolean(AllStates[1]);
            m_isRefresh = m_refreshState == Convert.ToBoolean(Session["__ISREFRESH"]);
        }

        /// <summary>
        /// M�todo que salva o ViewState atual
        /// </summary>
        /// <returns>Estado da p�gina salvo.</returns>
        protected override object SaveViewState()
        {
            Session["__ISREFRESH"] = m_refreshState;
            object[] AllStates = new object[2];
            AllStates[0] = base.SaveViewState();
            AllStates[1] = !((m_refreshState));
            return AllStates;
        }

        /// <summary>
        /// Altera a posi��o do campos ocultos do aspnet para o topo da p�gina, evitando assim o
        /// erro de valida��o do post.
        /// </summary>
        /// <param name="writer">HTML writer.</param>
        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            System.IO.StringWriter stringWriter =
                new System.IO.StringWriter();
            HtmlTextWriter htmlWriter = new HtmlTextWriter(stringWriter);
            base.Render(htmlWriter);
            string html = stringWriter.ToString();
            string[] aspnet_formelems = new string[5];
            aspnet_formelems[0] = "__EVENTTARGET";
            aspnet_formelems[1] = "__EVENTARGUMENT";
            aspnet_formelems[2] = "__VIEWSTATE";
            aspnet_formelems[3] = "__EVENTVALIDATION";
            aspnet_formelems[4] = "__VIEWSTATEENCRYPTED";
            foreach (string elem in aspnet_formelems)
            {
                //Response.Write("input type=""hidden"" name=""" & abc.ToString & """")
                int StartPoint = html.IndexOf("<input type=\"hidden\" name=\"" +
                  elem.ToString() + "\"");
                if (StartPoint >= 0)
                {
                    //does __VIEWSTATE exist?
                    int EndPoint = html.IndexOf("/>", StartPoint) + 2;
                    string ViewStateInput = html.Substring(StartPoint,
                      EndPoint - StartPoint);
                    html = html.Remove(StartPoint, EndPoint - StartPoint);
                    int FormStart = html.IndexOf("<form");
                    int EndForm = html.IndexOf(">", FormStart) + 1;
                    if (EndForm >= 0)
                        html = html.Insert(EndForm, ViewStateInput);
                }
            }

            writer.Write(html);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(EventArgs e)
        {
            if (null == Session["Usuario"])
            {
                if (Request.IsAuthenticated)
                {
                    FormsAuthentication.SignOut();
                }
                Response.Clear();
                Response.Redirect(FormsAuthentication.LoginUrl);
            }
            base.OnInit(e);
        }
        #endregion
    }
}

using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Web.UI;
using System.Configuration;

namespace HarunaNet.Framework.Utils.Mail
{
    /// <summary>
    /// SendMail Class. Contains methods to send an e-mail
    /// </summary>
    [Serializable]
    public class SendMail : Page
    {
        #region Methods
        /// <summary>
        /// Sends an E-mail with the EMailClass Object Information
        /// </summary>
        /// <param name="oEMailClass">Mail's Propierties Class</param>
        public void EnviarEMailClass(EMailClass oEMailClass)
        {
            try
            {
                MailMessage oMailMessage = new MailMessage();
                oMailMessage.To.Add(oEMailClass.To);
                if (!string.IsNullOrEmpty(oEMailClass.CC))
                    oMailMessage.CC.Add(oEMailClass.CC);

                oMailMessage.Subject = oEMailClass.Subject;
                oMailMessage.From = new MailAddress(ConfigurationManager.AppSettings["MailUser"].ToString());
                oMailMessage.IsBodyHtml = true;

                if (!string.IsNullOrEmpty(oEMailClass.Attachment))
                    oMailMessage.Attachments.Add(new Attachment(oEMailClass.Attachment));

                oMailMessage.Body = oEMailClass.Message;
                oMailMessage.Priority = MailPriority.Normal;
                SmtpClient oSmtpClient = new SmtpClient(ConfigurationManager.AppSettings["MailSmtp"].ToString());
                oSmtpClient.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["MailUser"].ToString(), ConfigurationManager.AppSettings["MailPass"].ToString());
                oSmtpClient.Send(oMailMessage);
                oMailMessage.Dispose();
            }
            catch (SmtpException ex)
            {
                throw new SmtpException("Houve um problema no envio de e-mail \n" + ex.ToString());
            }
        }

        /// <summary>
        /// Montagem do template de e-mail
        /// </summary>
        /// <param name="titulo">Título da Mensagem</param>
        /// <param name="corpo">Corpo da Mensagem</param>
        /// <returns>E-mail a ser enviado</returns>
        public string MontarCorpoEMail(TAM.UI.Mail.EMailClass.TipoMensagem tipo)
        {
            string path = string.Empty;
            switch (tipo)
            {
                case EMailClass.TipoMensagem.AvaliacaoIniciada:
                    path = Server.MapPath("avaliacaoiniciada.html").Replace("\\adm", "").Replace("avaliacaoiniciada.html", "");
                    path += @"Templates\avaliacaoiniciada.html";
                    break;
                case EMailClass.TipoMensagem.BloqueioDeEquipe:
                    path = Server.MapPath("bloqueioequipe.html").Replace("\\adm", "").Replace("bloqueioequipe.html", "");
                    path += @"Templates\bloqueioequipe.html";
                    break;
                case EMailClass.TipoMensagem.PermissaoDeEquipe:
                    path = Server.MapPath("permissaoequipe.html").Replace("\\adm", "").Replace("permissaoequipe.html", "");
                    path += @"Templates\permissaoequipe.html";
                    break;
                case EMailClass.TipoMensagem.PossuiMensagens:
                    path = Server.MapPath("possuimensagens.html").Replace("\\adm", "").Replace("possuimensagens.html", "");
                    path += @"Templates\possuimensagens.html";
                    break;
            }
            using (StreamReader oStreamReader = new StreamReader(path))
            {
                string email = oStreamReader.ReadToEnd();
                //email = email.Replace("#TITULO#", titulo);
                oStreamReader.Close();
                return email;
            }
        }

        /// <summary>
        /// Returns a bool value identifying if an internet connection exist
        /// </summary>
        /// <returns>True/False</returns>
        public bool IsConnected()
        {
            System.Uri Url = new System.Uri("http://www.microsoft.com");
            System.Net.WebRequest WebReq;
            System.Net.WebResponse Resp;
            WebReq = System.Net.WebRequest.Create(Url);

            try
            {
                Resp = WebReq.GetResponse();
                Resp.Close();
                WebReq = null;
                return true;
            }
            catch
            {
                WebReq = null;
                return false;
            }
        }
        #endregion
    }
} 

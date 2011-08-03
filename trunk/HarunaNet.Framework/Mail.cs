using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;

namespace HarunaNet.Framework.Utils
{
    /// <summary>
    /// Define o tipo de destinat�rio do e-mail.
    /// </summary>
    public enum TipoDestinatario
    {
        /// <summary>
        /// Destinat�rio do e-mail para.
        /// </summary>
        Para,
        /// <summary>
        /// Destinat�rio do e-mail copiado.
        /// </summary>
        ComCopia,
        /// <summary>
        /// Destinat�rio do e-mail oculto.
        /// </summary>
        ComCopiaOculta
    }

    /// <summary>
    /// Clase de envio de e-mail.
    /// </summary>
    public class Mail
    {
        #region Membros privados
        private string m_corpoTexto;
        private string m_corpoHTML;
        private bool m_EnableSsl;
        private MailMessage m_mensagem;
        #endregion

        #region Propriedades
        /// <summary>
        /// Get or Set emissor do email.
        /// </summary>
        public MailAddress De
        {
            get { return m_mensagem.From; }
            set { m_mensagem.From = value; }
        }


        /// <summary>
        /// Get or Set assunto do email.
        /// </summary>
        public bool EnableSsl
        {
            get { return m_EnableSsl; }
            set { m_EnableSsl = value; }
        }
        /// <summary>
        /// Get or Set assunto do email.
        /// </summary>
        public string Assunto
        {
            get { return m_mensagem.Subject; }
            set { m_mensagem.Subject = value; }
        }
        /// <summary>
        /// Get or Set corpo no formato somente texto do email.
        /// </summary>
        public string CorpoTexto
        {
            get { return m_corpoTexto; }
            set { m_corpoTexto = value; }
        }
        /// <summary>
        /// Get or Set corpo no formato HTML do email.
        /// </summary>
        public string CorpoHTML
        {
            get { return m_corpoHTML; }
            set { m_corpoHTML = value; }
        } 
        #endregion

        #region Construtor
        /// <summary>
        /// Construtor para envio de E-mail.
        /// </summary>
        public Mail()
        {
            m_mensagem = new MailMessage();
            m_corpoHTML = string.Empty;
            m_corpoTexto = string.Empty;
        }
        #endregion

        #region M�todos
        /// <summary>
        /// Enviar o email.
        /// </summary>
        /// <returns>Envio com sucesso ou falha do email.</returns>
        public bool Enviar()
        {
            SmtpClient smtp = new SmtpClient();
            
            string MailDeliveryMethod = ConfigurationManager.AppSettings["MailDeliveryMethod"].ToString();
            string MailPickupDirectoryLocation = ConfigurationManager.AppSettings["MailPickupDirectoryLocation"].ToString();
            string MailHost = ConfigurationManager.AppSettings["MailHost"].ToString();
            string MailPort = ConfigurationManager.AppSettings["MailPort"].ToString();
            string MailUser = ConfigurationManager.AppSettings["MailUser"].ToString();
            string MailPassword = ConfigurationManager.AppSettings["MailPassword"].ToString();

            switch (MailDeliveryMethod)
            {
                case "Network":
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    break;
                case "PickupDirectoryFromIis":
                    smtp.DeliveryMethod = SmtpDeliveryMethod.PickupDirectoryFromIis;
                    break;
                case "SpecifiedPickupDirectory":
                    smtp.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    break;
                default:
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    break;
            }

            if (smtp.DeliveryMethod == SmtpDeliveryMethod.Network)
            {
                smtp.Host = MailHost;
                smtp.Port = int.Parse(MailPort);
            }
            else if (smtp.DeliveryMethod == SmtpDeliveryMethod.SpecifiedPickupDirectory)
            {
                smtp.PickupDirectoryLocation = MailPickupDirectoryLocation;
                
            }

            if (MailUser != string.Empty)
            {
                smtp.Credentials = new NetworkCredential(MailUser, MailPassword);
            }

            if (m_mensagem.To.Count == 0 && m_mensagem.CC.Count == 0 && m_mensagem.Bcc.Count == 0)
            {
                throw new ArgumentException("N�o foi informado e-mail de destinat�rio");
            }

            if (m_mensagem.From == null)
            {
                if (m_mensagem.To.Count > 0)
                    m_mensagem.From = m_mensagem.To[0];
                else
                    throw new ArgumentException("N�o foi informado e-mail do remetente!");
            }

            if (m_mensagem.Subject == string.Empty)
            {
                throw new ArgumentException("N�o foi informado assunto!");
            }

            if (m_corpoHTML.Equals(string.Empty) && m_corpoTexto.Equals(string.Empty))
            {
                throw new ArgumentException("N�o foi informado corpo da mensagem!");
            }

            if (m_corpoHTML != string.Empty)
            {
                AlternateView view = AlternateView.CreateAlternateViewFromString(m_corpoHTML, new ContentType("text/html"));
                m_mensagem.AlternateViews.Add(view);
                m_mensagem.Body = m_corpoHTML;
                m_mensagem.IsBodyHtml = true;
            }
            else
            {
                m_mensagem.IsBodyHtml = false;
            }
            if (m_corpoTexto != string.Empty)
            {
                AlternateView view = AlternateView.CreateAlternateViewFromString(m_corpoTexto, new ContentType("text/plain"));
                m_mensagem.AlternateViews.Add(view);
                if (!m_mensagem.IsBodyHtml)
                    m_mensagem.Body = CorpoTexto;
            }

            try
            {
                smtp.Send(m_mensagem);
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Adiciona destinat�rios extras para o email.
        /// </summary>
        /// <param name="tipoDestinatario">Tipo do destinat�rio.</param>
        /// <param name="email">Endere�o do destinat�rio do email.</param>
        public void AdicionarDestinatario(TipoDestinatario tipoDestinatario, string email)
        {
            AdicionarDestinatario(tipoDestinatario, string.Empty, email);
        }

        /// <summary>
        /// Adiciona destinat�rios extras para o email.
        /// </summary>
        /// <param name="tipoDestinatario">Tipo do destinat�rio.</param>
        /// <param name="nome">Nome do destinat�rio.</param>
        /// <param name="email">Endere�o do destinat�rio do email.</param>
        public void AdicionarDestinatario(TipoDestinatario tipoDestinatario, string nome, string email)
        {
            MailAddress endereco;
            if (!nome.Equals(string.Empty))
                endereco = new MailAddress(email, nome, Encoding.GetEncoding("ISO-8859-1"));
            else
                endereco = new MailAddress(email);
            switch (tipoDestinatario)
            {
                case TipoDestinatario.Para:
                    m_mensagem.To.Add(endereco);
                    break;
                case TipoDestinatario.ComCopia:
                    m_mensagem.CC.Add(endereco);
                    break;
                case TipoDestinatario.ComCopiaOculta:
                    m_mensagem.Bcc.Add(endereco);
                    break;
            }
        }

        /// <summary>
        /// Adiciona anexo.
        /// </summary>
        /// <param name="path">Caminho do anexo.</param>
        public void AdiconarAnexo(string path)
        {
            m_mensagem.Attachments.Add(new Attachment(path));
        } 
        #endregion
    }
}

using System;
namespace HarunaNet.Framework.Utils.Mail
{
    /// <summary>
    /// EMail Class. Contains the propierties of Mail
    /// </summary>
    [Serializable]
    public class EMailClass
    {
        #region Attributes
        private string from;
        private string to;
        private string cc;
        private string subject;
        private string message;
        private string smtpclient;
        private int port;
        private string user;
        private string password;
        private string attachment;
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the User's Password
        /// </summary>
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        /// <summary>
        /// Gets or sets the Mail User
        /// </summary>
        public string User
        {
            get { return user; }
            set { user = value; }
        }

        /// <summary>
        /// Gets or sets the Server's Port
        /// </summary>
        public int Port
        {
            get { return port; }
            set { port = value; }
        }

        /// <summary>
        /// Gets or sets the Smtp Client Server
        /// </summary>
        public string Smtpclient
        {
            get { return smtpclient; }
            set { smtpclient = value; }
        }

        /// <summary>
        /// Gets or sets the Mail's Message
        /// </summary>
        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        /// <summary>
        /// Gets or sets the Mail's Subject
        /// </summary>
        public string Subject
        {
            get { return subject; }
            set { subject = value; }
        }

        /// <summary>
        /// Gets or sets the Mail's CC (Copy) that the mail will be sent
        /// </summary>
        public string CC
        {
            get { return cc; }
            set { cc = value; }
        }

        /// <summary>
        /// Gets or sets the Mail's Recipient
        /// </summary>
        public string To
        {
            get { return to; }
            set { to = value; }
        }

        /// <summary>
        /// Gets or sets the Mail adress From
        /// </summary>
        public string From
        {
            get { return from; }
            set { from = value; }
        }

        /// <summary>
        /// Gets or sets the Mail's Attachment
        /// </summary>
        public string Attachment
        {
            get { return attachment; }
            set { attachment = value; }
        }
        #endregion

        #region Contructors
        public EMailClass()
        {
        }
        #endregion

        #region Enums
        public enum TipoMensagem
        {
            BloqueioDeEquipe = 1,
            PermissaoDeEquipe = 2,
            AvaliacaoIniciada = 3,
            PossuiMensagens = 4
        }
        #endregion
    }
}

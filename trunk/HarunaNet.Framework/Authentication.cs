using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.DirectoryServices;

namespace HarunaNet.Framework.Utils
{
    public sealed class Authentication
    {
        /// <summary>
        /// Construtor da classe
        /// </summary>
        public Authentication()
        {
        }

        #region Static members
        public static string UserName(string loginDomain)
        {
            string domain = loginDomain.Substring(0, loginDomain.LastIndexOf(@"\"));
            string login = loginDomain.Substring(loginDomain.LastIndexOf(@"\") + 1);

            string nome = string.Empty;

            if (DirectoryEntry.Exists("LDAP://" + domain))
            {
                using (DirectorySearcher ds = new DirectorySearcher())
                {
                    ds.SearchRoot = new DirectoryEntry("LDAP://" + domain);
                    ds.Filter = string.Format("(|(&(objectCategory=user)(sAMAccountName={0})))", login);
                    SearchResult src = ds.FindOne();

                    if (src != null)
                    {
                        nome = src.Properties["displayName"][0].ToString();
                    }
                }
            }
            else
            {
                throw new Exception("Domínio não encontrado");
            }

            return nome;
        }
        #endregion
    }
}

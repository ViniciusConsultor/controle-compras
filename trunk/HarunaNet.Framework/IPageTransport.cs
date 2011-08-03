using System;
using System.Collections.Generic;
using System.Text;

namespace HarunaNet.Framework.Utils
{
    /// <summary>
    /// Ações disponiveis para uam página web.
    /// </summary>
    public enum PageAction
    { 
        /// <summary>
        /// Nenhuma ação.
        /// </summary>
        None = 0,
        /// <summary>
        /// Ação de inserção.
        /// </summary>
        Insert = 1,
        /// <summary>
        /// Ação de atualização.
        /// </summary>
        Update = 2,
        /// <summary>
        /// Ação de exclusão.
        /// </summary>
        Delete = 3,
        /// <summary>
        /// Ação de visualização.
        /// </summary>
        View = 4
    }
    /// <summary>
    /// Interface para transporte de dados entre páginas utilizando o contexto.
    /// </summary>
    public interface IPageTransport
    {
        /// <summary>
        /// Get / Set da ação de destino da página.
        /// </summary>
        PageAction Action
        {
            get;set;
        }
        /// <summary>
        /// Get / Set do valor sendo transportado.
        /// </summary>
        object Value
        {
            get;set;
        }

        /// <summary>
        /// Objetos de retono da página.
        /// </summary>
        List<PageReturnObject> ReturnObjects
        {
            get;set;
        }
    }   
}

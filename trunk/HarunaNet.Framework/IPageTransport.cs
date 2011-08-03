using System;
using System.Collections.Generic;
using System.Text;

namespace HarunaNet.Framework.Utils
{
    /// <summary>
    /// A��es disponiveis para uam p�gina web.
    /// </summary>
    public enum PageAction
    { 
        /// <summary>
        /// Nenhuma a��o.
        /// </summary>
        None = 0,
        /// <summary>
        /// A��o de inser��o.
        /// </summary>
        Insert = 1,
        /// <summary>
        /// A��o de atualiza��o.
        /// </summary>
        Update = 2,
        /// <summary>
        /// A��o de exclus�o.
        /// </summary>
        Delete = 3,
        /// <summary>
        /// A��o de visualiza��o.
        /// </summary>
        View = 4
    }
    /// <summary>
    /// Interface para transporte de dados entre p�ginas utilizando o contexto.
    /// </summary>
    public interface IPageTransport
    {
        /// <summary>
        /// Get / Set da a��o de destino da p�gina.
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
        /// Objetos de retono da p�gina.
        /// </summary>
        List<PageReturnObject> ReturnObjects
        {
            get;set;
        }
    }   
}

using System;
using System.Collections.Generic;
using System.Text;

namespace HarunaNet.Framework.Utils
{
    /// <summary>
    /// Objeto de retorno de uma p�gina.
    /// </summary>
    [Serializable()]
    public class PageReturnObject
    {
        private string m_pageName;
        private object m_value;
        private PageAction m_action;

        /// <summary>
        /// Nome da p�gina.
        /// </summary>
        public string PageName
        {
            get { return m_pageName; }
            set { m_pageName = value; }
        }

        /// <summary>
        /// Valor de retorno.
        /// </summary>
        public object Value
        {
            get { return m_value; }
            set { m_value = value; }
        }

        /// <summary>
        /// A��o da p�gina.
        /// </summary>
        public PageAction Action
        {
            get { return m_action; }
            set { m_action = value; }
        }

        /// <summary>
        /// Construtor da classe.
        /// </summary>
        public PageReturnObject()
            : this(string.Empty, null, PageAction.None)
        {

        }

        /// <summary>
        /// Construtor da classe.
        /// </summary>
        /// <param name="pageName">Nome da p�gina.</param>
        /// <param name="value">Valor de retorno.</param>
        /// <param name="action">A��o da p�gina.</param>
        public PageReturnObject(string pageName
        , object value
        , PageAction action)
        {
            m_pageName = pageName;
            m_value = value;
            m_action = action;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace HarunaNet.Entities
{
    [DataContract(Namespace = "HarunaNet.Entities")]
    public class Mensagem
    {
        #region Atributos
        private string m_campo;
        private List<string> m_descricoes;
        #endregion

        #region Propriedades
        /// <summary>
        /// Nome do campo a ser validado
        /// </summary>
        /// 
        [DataMember()]
        [DataObjectField(false, false, false)]
        public string Campo
        {
            get { return m_campo; }
            set { m_campo = value; }
        }

        /// <summary>
        /// Lista de menssagens de validação
        /// </summary>
        /// [DataMember()]
        [DataObjectField(false, false, false)]
        public List<string> Descricoes
        {
            get { return m_descricoes; }
            set { m_descricoes = value; }
        }
        #endregion

        #region Construtores
        /// <summary>
        /// Construtor da classe.
        /// </summary>
        public Mensagem()
        {
            this.m_descricoes = new List<string>();
            this.m_campo = string.Empty;
        }
        #endregion
        
        #region Métodos Estáticos
        public static Mensagem Cria(string campo, string descricao)
        {
            Mensagem m = new Mensagem();
            m.Campo = campo;
            m.Descricoes.Add(descricao);

            return m;
        }
        #endregion
    }
}

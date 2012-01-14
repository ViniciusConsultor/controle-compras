using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace HarunaNet.Entities
{
    [DataContract(Namespace = "HarunaNet.Entities")]
    public class Resultado
    {
        #region Atributos
        private bool m_sucesso;
        private List<Mensagem> m_mensagens;
        private int m_id;        
        #endregion

        #region Propriedades
        /// <summary>
        /// Status que informa se a operação ocorreu com sucesso
        /// </summary>
        /// 
        [DataMember()]
        [DataObjectField(false, false, false)]
        public bool Sucesso
        {
            get { return m_sucesso; }
            set { m_sucesso = value; }
        }
        /// <summary>
        /// Lista dos campos e mensagens de validação
        /// </summary>
        /// [DataMember()]
        [DataObjectField(false, false, false)]
        public List<Mensagem> Mensagens
        {
            get { return m_mensagens; }
            set { m_mensagens = value; }
        }
        /// <summary>
        /// Identificador único dos resultado
        /// </summary>
        ///
        /// [DataMember()]
        
        [DataMember()]
        [DataObjectField(true, false, false)]
        public int Id
        {
            get { return m_id; }
            set { m_id = value; }
        }
        #endregion

        #region Construtores
        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="sucesso">Sucesso.</param>
        /// <param name="mensagens">Mensagens.</param>
        /// <param name="id">Id.</param>
        public Resultado(bool sucesso, List<Mensagem> mensagens, int id)
        {
            this.m_sucesso = sucesso;
            this.m_mensagens = mensagens;
            this.m_id = id;
        }

        /// <summary>
        /// Construtor vazio da classe.
        /// </summary>
        public Resultado()
            : this(false, new List<Mensagem>(), int.MinValue)
        {
            
        }
        #endregion

        #region Métodos Estáticos
        public static Resultado operator +(Resultado value1, Resultado value2)
        {
            Merge(value1, value2);
            return new Resultado((value1.m_sucesso && value2.Sucesso), value1.Mensagens, value1.Id);
        }

        private static void Merge(Resultado value1, Resultado value2)
        {
            foreach (Mensagem mensagem in value2.Mensagens)
            {
                if (!value1.Mensagens.Exists(
                    delegate(Mensagem m)
                    {
                        return m.Descricoes.Exists(
                            delegate(string s)
                            {
                                return mensagem.Descricoes.Contains(s);
                            });
                    }))
                {
                    value1.Mensagens.Add(mensagem);
                }
            }
        }
        #endregion
    }
}

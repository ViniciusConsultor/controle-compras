using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace HarunaNet.Entities
{
     [Serializable()]
    [DataContract(Namespace = "HarunaNet.Entities")]
    public class PedListaItem
    {
        public Item Item { get; set; }
        public int CodPedido { get; set; }
        public string CodPedidos { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataPrevisaoEntrega { get; set; }
        public decimal ValorUnitario { get; set; }
        public string Outros { get; set; }
        public string NomeItem { get; set; }
        public int CodItem { get; set; }
        public int Status { get; set; }
        public string Empresa { get; set; }
        public string Solicitante { get; set; }
        public string Area { get; set; }
                
        #region Constructors

        /// <summary>
        /// Construtor vazio
        /// </summary>
        public PedListaItem()
        {
            this.Item = new Item();
        }
        #endregion
    }
}

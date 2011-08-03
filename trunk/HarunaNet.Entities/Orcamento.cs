using System;
using System.Collections.Generic;
using System.Text;

namespace HarunaNet.Entities
{
    [Serializable()]
    public class Orcamento
    {
        public int OrcamentoID { get; set; }
        public Pedido Pedido { get; set; }
        public Item Item { get; set; }
        public Fornecedor Fornecedor { get; set;}
        public decimal Valor { get; set; }
    }
}

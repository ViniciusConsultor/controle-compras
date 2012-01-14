using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace HarunaNet.Entities
{
     [Serializable()]
    [DataContract(Namespace = "HarunaNet.Entities")]
    public class Pedido
    {
        public int PedidoID { get; set; }
        public int CategoriaID { get; set; }
        public List<Ped_Item> Itens { get; set; }
        //public List<Orcamentos> Orcamento { get; set; }
        public DateTime DataPedido { get; set; }
        public DateTime DataOrcamento { get; set; }
        public DateTime DataPedidoForn { get; set; }
        public DateTime DataOrcamentoForn { get; set; }
        public DateTime DataPrevEntrega { get; set; }
        public int Usuario_ID { get; set; }
        public int Status { get; set; }

    }
}



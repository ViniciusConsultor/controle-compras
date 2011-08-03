using System;
using System.Collections.Generic;
using System.Text;

namespace HarunaNet.Entities
{
     [Serializable()]
    public class Aprovacao
    {
        public int CodigoPedido{ get; set; }
        public int CodigoItem { get; set; }
        public DateTime DataPedido { get; set; }
        public string Item { get; set; }
        public string Descrição { get; set; }
        public string NomeSolicitante { get; set; }
        public int Status { get; set; }
    }
}

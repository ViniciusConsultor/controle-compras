using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
namespace HarunaNet.Entities
{
     [DataContract(Namespace = "HarunaNet.Entities")]
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

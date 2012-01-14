using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
namespace HarunaNet.Entities
{

    [Serializable()]
    [DataContract(Namespace = "HarunaNet.Entities")]
    public class Orcamentos
    {
        public int Cod_Orcamento	{ get; set; }
        public double Valor	{ get; set; }
        public Fornecedor Fornecedor	{ get; set; }
        public string Cond_Pagamento	{ get; set; }
        public DateTime DataEntrega	{ get; set; }
        public int Desconto	{ get; set; }
        public string OBS	{ get; set; }
        public int DataOrcamento	{ get; set; }
        public Usuario usuario { get; set; }

    }
}

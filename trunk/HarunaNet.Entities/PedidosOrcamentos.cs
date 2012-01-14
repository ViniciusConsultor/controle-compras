using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
namespace HarunaNet.Entities
{

    [Serializable()]
    [DataContract(Namespace = "HarunaNet.Entities")]
    public class PedidosOrcamentos
    {
        public int Cod_PedidosOrcamentos { get; set; }
        public List<Orcamentos> OrcamentosRealizados { get; set; }
        public Item Item { get; set; }
        public UnidadeMedida UnidadeMedida { get; set; }
        public Projetos Projeto { get; set; }
        public double Quantidade { get; set; }
        public DateTime DataNecessidade { get; set; }
        public int UsuarioPedido { get; set; }
        public DateTime Data_PedidoOrcamento { get; set; }
        public int Status { get; set; }
        public Grupo Area { get; set; }
        public string Outros { get; set; }
        public string Descricao { get; set; }

    }
}

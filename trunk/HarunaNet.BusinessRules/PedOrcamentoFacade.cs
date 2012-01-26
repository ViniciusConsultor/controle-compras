
using HarunaNet.BusinessRules.Process;
using HarunaNet.Entities;
using System.Collections.Generic;

namespace HarunaNet.BusinessRules
{
    public class PedOrcamentoFacade
    {
        public Resultado Incluir(List<PedidosOrcamentos> ListaPedOrcamento)
        {
            return new PedOrcamentoProcess().Incluir(ListaPedOrcamento);
        }

        public List<PedidosOrcamentos> Listar(ref Resultado resuldado)
        {
            return new PedOrcamentoProcess().Listar(ref resuldado);
        }

        public PedidosOrcamentos Obter(ref Resultado resuldado, int IdPedidosOrcamento)
        {
            return new PedOrcamentoProcess().Obter(ref resuldado, IdPedidosOrcamento);
        }
    }
}

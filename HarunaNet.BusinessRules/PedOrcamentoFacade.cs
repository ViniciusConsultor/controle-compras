
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
    }
}

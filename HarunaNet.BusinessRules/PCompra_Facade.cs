using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

using HarunaNet.BusinessRules;
using HarunaNet.BusinessRules.Process;
using HarunaNet.BusinessRules.Validation;
using HarunaNet.Entities;


namespace HarunaNet.BusinessRules
{
    public class PCompra_Facade
    {
        public List<ProcessoCompra> Listar(ref Resultado resultado)
        {
            return new PCompraProcess().Listar(ref resultado);
        }
        public Resultado Fechar(List<ProcessoCompraItem> ListaProcessoCompraItem)
        {
            return new PCompraProcess().Fechar(ListaProcessoCompraItem);
        }

    }
}

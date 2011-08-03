using System;
using System.Collections.Generic;
using System.Text;

using HarunaNet.DataLayer;
using HarunaNet.Entities;
using HarunaNet.Framework.Utils;


namespace HarunaNet.BusinessRules.Validation
{
    public class PedItemValidation
    {
        private Ped_Item m_PedidosItens;
        private ProcessoCompraItem _ProcessoCompraItem;

        private Resultado m_resultado = new Resultado();

        private List<Mensagem> m_mensagem = new List<Mensagem>();

        public PedItemValidation()
        {
           this.m_resultado.Sucesso = true;
        }

        public PedItemValidation(Ped_Item oPedItem)
        {
            this.m_PedidosItens = oPedItem;
            this.m_resultado.Sucesso = true;
        }

        public Resultado Validar()
        {
            m_resultado.Sucesso = Valid.IsNumber(m_PedidosItens.Quantidade.ToString());
            return m_resultado;
        }

        public Resultado ValidarProcessoCompraItem(ProcessoCompraItem oPedItem)
        {

            if (oPedItem.Status > 2)
                m_resultado.Sucesso = true;
            else
                m_resultado.Sucesso = oPedItem.Quantidade == oPedItem.QuantidadeComprada;

            return m_resultado;
        }






    }
}

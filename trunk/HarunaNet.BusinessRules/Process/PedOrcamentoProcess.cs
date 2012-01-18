
using HarunaNet.DataLayer;
using HarunaNet.Entities;
using System.Collections.Generic;


namespace HarunaNet.BusinessRules.Process
{
    public class PedOrcamentoProcess
    {
        /// <summary>
        /// Inclui um novo Pedido de Orçamento
        /// </summary>
        /// <param name="pedOrcamento">Pedido de Orçamento a ser incluído</param>
        /// <returns>Resultado</returns>
        internal Resultado Incluir(List<PedidosOrcamentos> ListaPedOrcamento)
        {
            Resultado resultado = new Resultado();
            
            foreach (PedidosOrcamentos item in ListaPedOrcamento)
            {
                resultado = new PedOrcamentoData().Incluir(item);
                if (!resultado.Sucesso)
                {
                    break;
                }
            }


            if (!resultado.Sucesso)
            {
                Mensagem mensagem = new Mensagem();
                mensagem.Campo = "Orçamento";
                mensagem.Descricoes.Insert(0, "Erro ao inserir Pedido de Orçamento.");

                resultado.Mensagens.Add(mensagem);
                resultado.Sucesso = false;
            }
            return resultado;
        }
    }
}

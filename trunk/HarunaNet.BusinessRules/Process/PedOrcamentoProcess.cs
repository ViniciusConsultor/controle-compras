
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


        internal List<PedidosOrcamentos> Listar(ref Resultado resultado)
        {
            List<PedidosOrcamentos> Lista = new PedOrcamentoData().Listar();

            if (Lista.Count == 0)
            {
                Mensagem mensagem = new Mensagem();
                mensagem.Campo = "Orcamento";
                mensagem.Descricoes.Add("Nenhuma Pedido de Orçamento encontrado!");

                resultado.Mensagens.Add(mensagem);
                resultado.Sucesso = false;
            }
            else
            {
                resultado.Sucesso = true;
            }

            return Lista;
        }

        internal PedidosOrcamentos Obter(ref Resultado resultado, int IdPedidosOrcamento)
        {
            PedidosOrcamentos pedidosOrcamentos = new PedOrcamentoData().Obter(IdPedidosOrcamento);

            if (resultado.Sucesso)
            {
                resultado.Sucesso = true;
            }
            else
            {
                Mensagem mensagem = new Mensagem();
                mensagem.Campo = "PedidosOrcamentos";
                mensagem.Descricoes.Add("Nenhuma Orçamento encontrado!");

                resultado.Mensagens.Add(mensagem);
                resultado.Sucesso = false;
            }

            return pedidosOrcamentos;
        }
    }
}

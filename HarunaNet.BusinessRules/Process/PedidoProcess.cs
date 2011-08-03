using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Xml;

using HarunaNet.DataLayer;
using HarunaNet.BusinessRules;
using HarunaNet.Entities;
using HarunaNet.BusinessRules.Validation;
using HarunaNet.Framework.Utils;


namespace HarunaNet.BusinessRules.Process
{
    public class PedidoProcess
    {
        /// <summary>
        /// Incluir um novo Grupo
        /// </summary>
        /// <param name="Grupo">Grupo a ser incluído</param>
        /// <returns>Resultado</returns>
        public Resultado Incluir(Pedido oPedido)
        {
            PedidoData oPedidoData = new PedidoData();
            Resultado resultado = new PedidoValidation().ValidarPedido(oPedido);

            if (resultado.Sucesso)
            {
                resultado = oPedidoData.Incluir(oPedido);

                if (!resultado.Sucesso)
                {
                    Mensagem mensagem = new Mensagem();
                    mensagem.Campo = "Pedido";
                    mensagem.Descricoes.Insert(0, "Erro ao inserir Pedido!");

                    resultado.Mensagens.Add(mensagem);
                    resultado.Sucesso = false;
                }
            }
            return resultado;
        }

        public List<MeusPedidos> Listar(int usuarioId, ref Resultado resultado)
        {
            List<MeusPedidos> listaPedido = new PedidoData().Listar(usuarioId);


            if (listaPedido.Count == 0)
            {
                Mensagem mensagem = new Mensagem();
                mensagem.Campo = "MeusPedidos";
                mensagem.Descricoes.Add("Nenhum Pedido Encontrado!");

                resultado.Mensagens.Add(mensagem);
                resultado.Sucesso = false;
            }
            else
            {
                resultado.Sucesso = true;
            }

            return listaPedido;
        }
        
        public List<Aprovacao> ListaAprovacao(ref Resultado resultado)
        {
            List<Aprovacao> oListaAprovacao = new PedidoData().ListaAprovacao();

            if (oListaAprovacao.Count == 0)
            {
                Mensagem mensagem = new Mensagem();
                mensagem.Campo = "ItensAprovacao";
                mensagem.Descricoes.Add("Não há nunhum item para aprovação!");

                resultado.Mensagens.Add(mensagem);
                resultado.Sucesso = false;
            }
            else
            {
                resultado.Sucesso = true;
            }

            return oListaAprovacao;
        }
        
        public Resultado IncluirItens(List<Ped_Item> olistPedItem, Int32 PedidoItem)
        {
            Ped_ItemData oPedItemData = new Ped_ItemData();
            Resultado resultado = new Resultado();

            foreach (Ped_Item item in olistPedItem)
            {
                resultado = oPedItemData.Incluir(item, PedidoItem);

            }
            return resultado;
        }

        public Resultado AtualizaStatus(int CodPedido, int Status)
        {
            return new PedidoData().AtualizaStatus(CodPedido, Status);
        }

        public Resultado Aprovar(int CodPedItem)
        {
            return new PedidoData().Aprovar(CodPedItem);
        }

        public Resultado Cancelar(int CodPedItem)
        {
            return new PedidoData().Cancelar(CodPedItem);
        }

    }
}

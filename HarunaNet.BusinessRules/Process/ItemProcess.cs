using System.Collections.Generic;

using HarunaNet.DataLayer;
using HarunaNet.Entities;

namespace HarunaNet.BusinessRules.Process
{
    internal class ItemProcess
    {
        public List<Item> Listar(int CategoriaID, ref Resultado resultado)
        {
            List<Item> listaItem = new ItemData().Listar(CategoriaID);

            if (listaItem.Count == 0)
            {
                Mensagem mensagem = new Mensagem();
                mensagem.Campo = "Item";
                mensagem.Descricoes.Add("Nenhuma item encontrado!");

                resultado.Mensagens.Add(mensagem);
                resultado.Sucesso = false;
            }
            else
            {

                resultado.Sucesso = true;
            }

            return listaItem;
        }

        public Resultado Incluir(Item oItem)
        {
            PedidoData oPedidoData = new PedidoData();
            Resultado resultado = new ItemData().Incluir_Item(oItem);

            if (!resultado.Sucesso)
            {
                Mensagem mensagem = new Mensagem();
                mensagem.Campo = "Item";
                mensagem.Descricoes.Insert(0, "Erro ao inserir Item!");

                resultado.Mensagens.Add(mensagem);
                resultado.Sucesso = false;
            }
            return resultado;
        }
        
        public Resultado Atualiza(Item oItem)
        {
            PedidoData oPedidoData = new PedidoData();
            Resultado resultado = new ItemData().Atualiza(oItem);

            if (!resultado.Sucesso)
            {
                Mensagem mensagem = new Mensagem();
                mensagem.Campo = "AtualizaItem";
                mensagem.Descricoes.Insert(0, "Erro ao Atualizar Item!");

                resultado.Mensagens.Add(mensagem);
                resultado.Sucesso = false;
            }
            return resultado;
        }

        public Resultado Exluir(Item oItem)
        {
            PedidoData oPedidoData = new PedidoData();
            Resultado resultado = new ItemData().Atualiza(oItem);

            if (resultado.Sucesso)
            {
                Mensagem mensagem = new Mensagem();
                mensagem.Campo = "AtualizaItem";
                mensagem.Descricoes.Insert(0, "Erro ao Excluir Item!");

                resultado.Mensagens.Add(mensagem);
                resultado.Sucesso = false;
            }
            return resultado;

        }

        public Item Seleciona(int ID, ref Resultado resultado)
        {
            Item listaItem = new ItemData().Seleciona(ID);

            if (listaItem  != null)
            {
                Mensagem mensagem = new Mensagem();
                mensagem.Campo = "Item";
                mensagem.Descricoes.Add("Nenhuma item encontrado!");

                resultado.Mensagens.Add(mensagem);
                resultado.Sucesso = false;
            }
            else
            {

                resultado.Sucesso = true;
            }

            return listaItem;
        }

    }
}

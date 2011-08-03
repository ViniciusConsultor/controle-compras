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
    public class Ped_ItemFacade
    {
        public Resultado Validar(Ped_Item oPedItem)
        {
            return new PedItemProcess().Validar(oPedItem);
        }

        public List<Compras> Listar(ref Resultado resultado)
        {
            return new PedItemProcess().Listar(ref resultado);
        }

        public List<ProcessoCompraItem> ListaItensProcessoCompra(int CodPCompra, ref Resultado resultado)
        {
            return new PedItemProcess().ListaItensProcessoCompra(CodPCompra, ref resultado);
        }
        
        public List<PedListaItem> ListaItensPCompraPorCodigo(int CodPCompra, ref Resultado resultado)
        {
            return new PedItemProcess().ListaItensPCompraPorCodigo(CodPCompra, ref resultado);
        }
        
        public List<PedListaItem> ListaItensCompra(int CategoriaID, int CC_ID, ref Resultado resultado)
        {
            return new PedItemProcess().ListaItensCompra(CategoriaID, CC_ID, ref resultado);
        }

        public List<Ped_Item> ListaItensByNumPed(int CategoriaID, ref Resultado resultado)
        {
            return new PedItemProcess().ListarByNumPed(CategoriaID, ref resultado);
        }

        public Resultado AtualizaStatus(int CodPedido, int Status)
        {
            return new  PedItemProcess().AtualizaStatus(CodPedido, Status);
        }

        public Resultado AtualizaProcessoCompra(int CategoriaID, int CC_ID)
        {
            return new PedItemProcess().AtualizaProcessoCompra(CategoriaID, CC_ID);
        }
        
        public Resultado AtualizaValor(List<Ped_Item> ListaPedItens)
        {
            return new PedItemProcess().AtualizaValor(ListaPedItens);
        }
        
        public Resultado AtualizaStatusProcessoCompra(ProcessoCompra CC_ID)
        {
            return new PedItemProcess().AtualizaStatusProcessoCompra(CC_ID);
        }

        public List<Status> ListarStatus(ref Resultado resultado)
        {
            return new PedItemProcess().ListaStatus(ref resultado);
        }

        public Resultado AtualizaItemCompra(ProcessoCompraItem pPCItem)
        {
            return new PedItemProcess().AtualizaItemCompra(pPCItem);
        }

    }
}

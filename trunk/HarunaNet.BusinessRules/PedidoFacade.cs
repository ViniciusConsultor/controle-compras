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
    public class PedidoFacade
    {
        /// <summary>
        /// Incluir um Grupo
        /// </summary>
        /// <param name="grupo">Grupo a ser incluída</param>
        /// <returns>Resultado</returns>
        public Resultado Incluir(Pedido oPedidos)
        {
            PedidoProcess oPedidoProcess = new PedidoProcess();
            Resultado resultado = new Resultado();
            int CodPed;

            //using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew))
            //{
            resultado = oPedidoProcess.Incluir(oPedidos);
            if (resultado.Sucesso)
            {
                CodPed = resultado.Id;
                oPedidos.PedidoID = resultado.Id;
                resultado = oPedidoProcess.IncluirItens(oPedidos.Itens, oPedidos.PedidoID);
                resultado.Id = CodPed;
                //if (resultado.Sucesso)
                //{
                //    scope.Complete();
                //}
            }
            //}



            //List<String> oCategoria = new List<string>();
            //foreach (Ped_Item itm in oPedidos.Itens)
            //{
            //    oCategoria.Add(itm.Item.Categoria.Nome.ToString());
            //}

            //Dictionary<string, bool> Distinct = new Dictionary<string, bool>();
            //foreach (string value in oCategoria)
            //{
            //    Distinct[value] = true;
            //}

            //List<string> CategoriaDistinct = new List<string>();
            //CategoriaDistinct.AddRange(Distinct.Keys);

            //foreach (String itmDistinct in CategoriaDistinct)
            //{
            //    Pedido ped = new Pedido();
            //    List<Ped_Item> itens = new List<Ped_Item>();

            //    foreach (Ped_Item item in oPedidos.Itens)
            //    {
            //        if (itmDistinct.ToString() == item.Item.Categoria.Nome.ToString())
            //        {
            //            itens.Add(item);
            //        }
            //    }

            //    ped.Status = oPedidos.Status;
            //    ped.Usuario_ID = oPedidos.Usuario_ID;
            //    ped.DataPedido = oPedidos.DataPedido;
            //    ped.DataOrcamento = oPedidos.DataOrcamento;
            //    ped.Itens = itens;

            //    resultado = oPedidoProcess.Incluir(ped);
            //    if (resultado.Sucesso)
            //    {
            //        ped.PedidoID = resultado.Id;
            //        resultado = oPedidoProcess.IncluirItens(ped.Itens, ped.PedidoID);

            //    }
            //}

            return resultado;
        }
        
        public List<Aprovacao> ListaAprovacao(ref Resultado resultado)
        {
            return new PedidoProcess().ListaAprovacao(ref resultado);
        }
        
        public List<MeusPedidos> Listar(int usuarioId, ref Resultado resultado)
        {
            return new PedidoProcess().Listar(usuarioId, ref resultado);
        }
        
        public Resultado AtualizaStatus(int CodPedido, int Status)
        {
            return new PedidoProcess().AtualizaStatus(CodPedido, Status);
        }

        public Resultado Aprovar(int CodPedItem)
        {
            return new PedidoProcess().Aprovar(CodPedItem);
        }

        public Resultado Cancelar(int CodPedItem)
        {
            return new PedidoProcess().Cancelar(CodPedItem);
        }
    }
}




